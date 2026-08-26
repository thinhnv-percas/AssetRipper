using DevX.Cecil.Binary;
using System;
using System.IO;
using System.Reflection;

namespace DevX.Cecil
{
	public sealed class AssemblyFactory
	{
		private AssemblyFactory()
		{
		}

		private static AssemblyDefinition GetAssembly(ImageReader irv, bool manifestOnly)
		{
			StructureReader structureReader = new StructureReader(irv, manifestOnly);
			AssemblyDefinition assemblyDefinition = new AssemblyDefinition(new AssemblyNameDefinition(), structureReader);
			assemblyDefinition.Accept(structureReader);
			return assemblyDefinition;
		}

		private static AssemblyDefinition GetAssembly(ImageReader reader)
		{
			return GetAssembly(reader, manifestOnly: false);
		}

		private static AssemblyDefinition GetAssemblyManifest(ImageReader reader)
		{
			return GetAssembly(reader, manifestOnly: true);
		}

		public static AssemblyDefinition GetAssembly(string file)
		{
			return GetAssembly(ImageReader.Read(file));
		}

		public static AssemblyDefinition GetAssembly(byte[] assembly)
		{
			return GetAssembly(ImageReader.Read(assembly));
		}

		public static AssemblyDefinition GetAssembly(Stream stream)
		{
			return GetAssembly(ImageReader.Read(stream));
		}

		public static AssemblyDefinition GetAssemblyManifest(string file)
		{
			return GetAssemblyManifest(ImageReader.Read(file));
		}

		public static AssemblyDefinition GetAssemblyManifest(byte[] assembly)
		{
			return GetAssemblyManifest(ImageReader.Read(assembly));
		}

		public static AssemblyDefinition GetAssemblyManifest(Stream stream)
		{
			return GetAssemblyManifest(ImageReader.Read(stream));
		}

		private static TargetRuntime CurrentRuntime()
		{
			Version version = typeof(object).Assembly.GetName().Version;
			switch (version.Major)
			{
			case 1:
				return (version.Minor != 0) ? TargetRuntime.NET_1_1 : TargetRuntime.NET_1_0;
			case 2:
				return TargetRuntime.NET_2_0;
			case 4:
				return TargetRuntime.NET_4_0;
			default:
				throw new NotSupportedException();
			}
		}

		public static AssemblyDefinition DefineAssembly(string name, AssemblyKind kind)
		{
			return DefineAssembly(name, name, CurrentRuntime(), kind);
		}

		public static AssemblyDefinition DefineAssembly(string name, TargetRuntime rt, AssemblyKind kind)
		{
			return DefineAssembly(name, name, rt, kind);
		}

		public static AssemblyDefinition DefineAssembly(string assemblyName, string moduleName, TargetRuntime rt, AssemblyKind kind)
		{
			AssemblyNameDefinition assemblyNameDefinition = new AssemblyNameDefinition();
			assemblyNameDefinition.Name = assemblyName;
			AssemblyDefinition assemblyDefinition = new AssemblyDefinition(assemblyNameDefinition);
			assemblyDefinition.Runtime = rt;
			assemblyDefinition.Kind = kind;
			ModuleDefinition value = new ModuleDefinition(moduleName, assemblyDefinition, main: true);
			assemblyDefinition.Modules.Add(value);
			return assemblyDefinition;
		}

		private static void WriteAssembly(AssemblyDefinition asm, BinaryWriter bw)
		{
			asm.Accept(new StructureWriter(asm, bw));
		}

		public static void SaveAssembly(AssemblyDefinition asm, string file)
		{
			using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				SaveAssembly(asm, stream);
				asm.MainModule.Image.SetFileInfo(new FileInfo(file));
			}
		}

		public static void SaveAssembly(AssemblyDefinition asm, out byte[] assembly)
		{
			MemoryBinaryWriter memoryBinaryWriter = new MemoryBinaryWriter();
			SaveAssembly(asm, memoryBinaryWriter.BaseStream);
			assembly = memoryBinaryWriter.ToArray();
		}

		public static void SaveAssembly(AssemblyDefinition asm, Stream stream)
		{
			BinaryWriter binaryWriter = new BinaryWriter(stream);
			try
			{
				WriteAssembly(asm, binaryWriter);
			}
			finally
			{
				binaryWriter.Close();
			}
			foreach (ModuleDefinition module in asm.Modules)
			{
				if (module.Controller.Writer.SaveSymbols)
				{
					module.Controller.Writer.WriteSymbols(module);
				}
			}
		}

		public static Assembly CreateReflectionAssembly(AssemblyDefinition asm, AppDomain domain)
		{
			using (MemoryBinaryWriter memoryBinaryWriter = new MemoryBinaryWriter())
			{
				WriteAssembly(asm, memoryBinaryWriter);
				return domain.Load(memoryBinaryWriter.ToArray());
				IL_001f:
				Assembly result;
				return result;
			}
		}

		public static Assembly CreateReflectionAssembly(AssemblyDefinition asm)
		{
			return CreateReflectionAssembly(asm, AppDomain.CurrentDomain);
		}
	}
}
