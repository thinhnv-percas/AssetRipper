using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using ImageMagick.Configuration;

namespace ImageMagick;

internal static class NativeLibraryLoader
{
	private static class NativeMethods
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDllDirectory(string lpPathName);
	}

	private static volatile bool _loaded;

	private static Assembly Assembly => typeof(NativeLibraryLoader).Assembly;

	public static void Copy(Stream source, Stream destination)
	{
		source.CopyTo(destination);
	}

	public static void Load()
	{
		if (!_loaded)
		{
			_loaded = true;
			ExtractLibrary();
		}
	}

	private static string CreateCacheDirectory()
	{
		AssemblyFileVersionAttribute assemblyFileVersionAttribute = (AssemblyFileVersionAttribute)Assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), inherit: false)[0];
		string text = Path.Combine(MagickAnyCPU.CacheDirectory, "Magick.NET.net40." + assemblyFileVersionAttribute.Version);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			GrantEveryoneReadAndExecuteAccess(text);
		}
		return text;
	}

	private static void ExtractLibrary()
	{
		string text = "Magick.NET-Q8-" + (NativeLibrary.Is64Bit ? "x64" : "x86");
		string text2 = CreateCacheDirectory();
		WriteAssembly(Path.Combine(text2, text + ".Native.dll"));
		NativeMethods.SetDllDirectory(text2);
		MagickNET.Initialize(ConfigurationFiles.Default, text2);
	}

	private static void GrantEveryoneReadAndExecuteAccess(string cacheDirectory)
	{
		if (MagickAnyCPU.HasSharedCacheDirectory && MagickAnyCPU.UsesDefaultCacheDirectory)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(cacheDirectory);
			DirectorySecurity accessControl = directoryInfo.GetAccessControl();
			SecurityIdentifier identity = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			InheritanceFlags inheritanceFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
			accessControl.AddAccessRule(new FileSystemAccessRule(identity, FileSystemRights.ReadAndExecute, inheritanceFlags, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
			directoryInfo.SetAccessControl(accessControl);
		}
	}

	private static void WriteAssembly(string tempFile)
	{
		if (File.Exists(tempFile))
		{
			return;
		}
		string name = "ImageMagick.Resources.Library.Magick.NET.Native_" + (NativeLibrary.Is64Bit ? "x64" : "x86") + ".gz";
		using Stream stream = Assembly.GetManifestResourceStream(name);
		using GZipStream source = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: false);
		using FileStream destination = File.Open(tempFile, FileMode.CreateNew);
		Copy(source, destination);
	}
}
