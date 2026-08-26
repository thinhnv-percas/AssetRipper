#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using dnlib.DotNet.MD;
using dnlib.DotNet.Pdb.Symbols;
using dnlib.DotNet.Pdb.WindowsPdb;
using dnlib.DotNet.Writer;
using dnlib.IO;
using dnlib.PE;

namespace dnlib.DotNet.Pdb.Dss;

internal static class SymbolReaderWriterFactory
{
	private static readonly Guid CLSID_CorSymReader_SxS = new Guid("0A3976C5-4529-4ef8-B0B0-42EED37082CD");

	private static Type CorSymReader_Type;

	private static readonly Guid CLSID_CorSymWriter_SxS = new Guid(182640304u, 63745, 18315, 187, 159, 136, 30, 232, 6, 103, 136);

	private static Type CorSymWriterType;

	private static volatile bool canTry_Microsoft_DiaSymReader_Native = true;

	[DllImport("Microsoft.DiaSymReader.Native.x86.dll", EntryPoint = "CreateSymReader")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymReader_x86(ref Guid id, [MarshalAs(UnmanagedType.IUnknown)] out object symReader);

	[DllImport("Microsoft.DiaSymReader.Native.amd64.dll", EntryPoint = "CreateSymReader")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymReader_x64(ref Guid id, [MarshalAs(UnmanagedType.IUnknown)] out object symReader);

	[DllImport("Microsoft.DiaSymReader.Native.arm.dll", EntryPoint = "CreateSymReader")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymReader_arm(ref Guid id, [MarshalAs(UnmanagedType.IUnknown)] out object symReader);

	[DllImport("Microsoft.DiaSymReader.Native.x86.dll", EntryPoint = "CreateSymWriter")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymWriter_x86(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] out object symWriter);

	[DllImport("Microsoft.DiaSymReader.Native.amd64.dll", EntryPoint = "CreateSymWriter")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymWriter_x64(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] out object symWriter);

	[DllImport("Microsoft.DiaSymReader.Native.arm.dll", EntryPoint = "CreateSymWriter")]
	[DefaultDllImportSearchPaths(DllImportSearchPath.AssemblyDirectory | DllImportSearchPath.SafeDirectories)]
	private static extern void CreateSymWriter_arm(ref Guid guid, [MarshalAs(UnmanagedType.IUnknown)] out object symWriter);

	public static SymbolReader Create(PdbReaderContext pdbContext, dnlib.DotNet.MD.Metadata metadata, DataReaderFactory pdbStream)
	{
		ISymUnmanagedReader symUnmanagedReader = null;
		SymbolReaderImpl symbolReaderImpl = null;
		ReaderMetaDataImport readerMetaDataImport = null;
		DataReaderIStream dataReaderIStream = null;
		bool flag = true;
		try
		{
			if (pdbStream == null)
			{
				return null;
			}
			ImageDebugDirectory codeViewDebugDirectory = pdbContext.CodeViewDebugDirectory;
			if (codeViewDebugDirectory == null)
			{
				return null;
			}
			if (!pdbContext.TryGetCodeViewData(out var guid, out var age))
			{
				return null;
			}
			symUnmanagedReader = CreateSymUnmanagedReader(pdbContext.Options);
			if (symUnmanagedReader == null)
			{
				return null;
			}
			readerMetaDataImport = new ReaderMetaDataImport(metadata);
			dataReaderIStream = new DataReaderIStream(pdbStream);
			int num = symUnmanagedReader.Initialize(readerMetaDataImport, null, null, dataReaderIStream);
			if (num < 0)
			{
				return null;
			}
			symbolReaderImpl = new SymbolReaderImpl(symUnmanagedReader, new object[3] { pdbStream, readerMetaDataImport, dataReaderIStream });
			if (!symbolReaderImpl.MatchesModule(guid, codeViewDebugDirectory.TimeDateStamp, age))
			{
				return null;
			}
			flag = false;
			return symbolReaderImpl;
		}
		catch (IOException)
		{
		}
		catch (InvalidCastException)
		{
		}
		catch (COMException)
		{
		}
		finally
		{
			if (flag)
			{
				pdbStream?.Dispose();
				symbolReaderImpl?.Dispose();
				readerMetaDataImport?.Dispose();
				dataReaderIStream?.Dispose();
				(symUnmanagedReader as ISymUnmanagedDispose)?.Destroy();
			}
		}
		return null;
	}

	private static ISymUnmanagedReader CreateSymUnmanagedReader(PdbReaderOptions options)
	{
		bool flag = (options & PdbReaderOptions.NoDiaSymReader) == 0;
		bool flag2 = (options & PdbReaderOptions.NoOldDiaSymReader) == 0;
		if (flag && canTry_Microsoft_DiaSymReader_Native)
		{
			try
			{
				Guid id = CLSID_CorSymReader_SxS;
				Machine processCpuArchitecture = ProcessorArchUtils.GetProcessCpuArchitecture();
				object symReader;
				switch (processCpuArchitecture)
				{
				case Machine.AMD64:
					CreateSymReader_x64(ref id, out symReader);
					break;
				case Machine.I386:
					CreateSymReader_x86(ref id, out symReader);
					break;
				case Machine.ARMNT:
					CreateSymReader_arm(ref id, out symReader);
					break;
				default:
					Debug.Fail($"Microsoft.DiaSymReader.Native doesn't support this CPU arch: {processCpuArchitecture}");
					symReader = null;
					break;
				}
				if (symReader is ISymUnmanagedReader result)
				{
					return result;
				}
			}
			catch (DllNotFoundException)
			{
				Debug.WriteLine("Microsoft.DiaSymReader.Native not found, using diasymreader.dll instead");
			}
			catch
			{
			}
			canTry_Microsoft_DiaSymReader_Native = false;
		}
		if (flag2)
		{
			return (ISymUnmanagedReader)Activator.CreateInstance(CorSymReader_Type ?? (CorSymReader_Type = Type.GetTypeFromCLSID(CLSID_CorSymReader_SxS)));
		}
		return null;
	}

	private static ISymUnmanagedWriter2 CreateSymUnmanagedWriter2(PdbWriterOptions options)
	{
		bool flag = (options & PdbWriterOptions.NoDiaSymReader) == 0;
		bool flag2 = (options & PdbWriterOptions.NoOldDiaSymReader) == 0;
		if (flag && canTry_Microsoft_DiaSymReader_Native)
		{
			try
			{
				Guid guid = CLSID_CorSymWriter_SxS;
				Machine processCpuArchitecture = ProcessorArchUtils.GetProcessCpuArchitecture();
				object symWriter;
				switch (processCpuArchitecture)
				{
				case Machine.AMD64:
					CreateSymWriter_x64(ref guid, out symWriter);
					break;
				case Machine.I386:
					CreateSymWriter_x86(ref guid, out symWriter);
					break;
				case Machine.ARMNT:
					CreateSymWriter_arm(ref guid, out symWriter);
					break;
				default:
					Debug.Fail($"Microsoft.DiaSymReader.Native doesn't support this CPU arch: {processCpuArchitecture}");
					symWriter = null;
					break;
				}
				if (symWriter is ISymUnmanagedWriter2 result)
				{
					return result;
				}
			}
			catch (DllNotFoundException)
			{
				Debug.WriteLine("Microsoft.DiaSymReader.Native not found, using diasymreader.dll instead");
			}
			catch
			{
			}
			canTry_Microsoft_DiaSymReader_Native = false;
		}
		if (flag2)
		{
			return (ISymUnmanagedWriter2)Activator.CreateInstance(CorSymWriterType ?? (CorSymWriterType = Type.GetTypeFromCLSID(CLSID_CorSymWriter_SxS)));
		}
		return null;
	}

	public static SymbolWriter Create(PdbWriterOptions options, string pdbFileName)
	{
		if (File.Exists(pdbFileName))
		{
			File.Delete(pdbFileName);
		}
		return new SymbolWriterImpl(CreateSymUnmanagedWriter2(options), pdbFileName, File.Create(pdbFileName), options, ownsStream: true);
	}

	public static SymbolWriter Create(PdbWriterOptions options, Stream pdbStream, string pdbFileName)
	{
		return new SymbolWriterImpl(CreateSymUnmanagedWriter2(options), pdbFileName, pdbStream, options, ownsStream: false);
	}
}
