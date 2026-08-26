using Mono.Cecil.Cil;
using Mono.Cecil.PE;
using System;
using System.IO;

namespace Mono.Cecil
{
	internal static class ModuleWriter
	{
		public static void WriteModuleTo(ModuleDefinition module, Stream stream, WriterParameters parameters)
		{
			if ((module.Attributes & ModuleAttributes.ILOnly) == (ModuleAttributes)0)
			{
				throw new NotSupportedException("Writing mixed-mode assemblies is not supported");
			}
			if (module.HasImage && module.ReadingMode == ReadingMode.Deferred)
			{
				new ImmediateModuleReader(module.Image).ReadModule(module, resolve: false);
			}
			module.MetadataSystem.Clear();
			if (module.assembly != null)
			{
				AssemblyNameDefinition name = module.assembly.Name;
			}
			string fullyQualifiedName = stream.GetFullyQualifiedName();
			ISymbolWriterProvider symbolWriterProvider = parameters.SymbolWriterProvider;
			ISymbolWriter symbolWriter = GetSymbolWriter(module, fullyQualifiedName, symbolWriterProvider);
			MetadataBuilder metadata = new MetadataBuilder(module, fullyQualifiedName, symbolWriterProvider, symbolWriter);
			BuildMetadata(module, metadata);
			if (module.symbol_reader != null)
			{
				module.symbol_reader.Dispose();
			}
			ImageWriter.CreateWriter(module, metadata, stream).WriteImage();
			symbolWriter?.Dispose();
		}

		private static void BuildMetadata(ModuleDefinition module, MetadataBuilder metadata)
		{
			if (!module.HasImage)
			{
				metadata.BuildMetadata();
			}
			else
			{
				module.Read(metadata, delegate(MetadataBuilder builder, MetadataReader _)
				{
					builder.BuildMetadata();
					return builder;
				});
			}
		}

		private static ISymbolWriter GetSymbolWriter(ModuleDefinition module, string fq_name, ISymbolWriterProvider symbol_writer_provider)
		{
			return symbol_writer_provider?.GetSymbolWriter(module, fq_name);
		}
	}
}
