using DevX.Cecil.Binary;
using DevX.Cecil.Cil;
using DevX.Cecil.Metadata;
using System.Collections;
using System.IO;

namespace DevX.Cecil
{
	internal class AssemblyStripper
	{
		private AssemblyDefinition assembly;

		private BinaryWriter writer;

		private Image original;

		private Image stripped;

		private ReflectionWriter reflection_writer;

		private MetadataWriter metadata_writer;

		private TablesHeap original_tables;

		private TablesHeap stripped_tables;

		private AssemblyStripper(AssemblyDefinition assembly, BinaryWriter writer)
		{
			this.assembly = assembly;
			this.writer = writer;
		}

		private void Strip()
		{
			FullLoad();
			ClearMethodBodies();
			CopyOriginalImage();
			PatchMethods();
			PatchFields();
			PatchResources();
			Write();
		}

		private void FullLoad()
		{
			assembly.MainModule.FullLoad();
		}

		private void ClearMethodBodies()
		{
			foreach (TypeDefinition type in assembly.MainModule.Types)
			{
				ClearMethodBodies(type.Constructors);
				ClearMethodBodies(type.Methods);
			}
		}

		private static void ClearMethodBodies(ICollection methods)
		{
			foreach (MethodDefinition method in methods)
			{
				if (method.HasBody)
				{
					method.Body.ExceptionHandlers.Clear();
					method.Body.Variables.Clear();
					method.Body.Instructions.Clear();
					method.Body.CilWorker.Emit(OpCodes.Ret);
				}
			}
		}

		private void CopyOriginalImage()
		{
			original = assembly.MainModule.Image;
			stripped = Image.CreateImage();
			stripped.Accept(new CopyImageVisitor(original));
			assembly.MainModule.Image = stripped;
			original_tables = original.MetadataRoot.Streams.TablesHeap;
			stripped_tables = stripped.MetadataRoot.Streams.TablesHeap;
			TableCollection tables = original_tables.Tables;
			foreach (IMetadataTable item in tables)
			{
				stripped_tables.Tables.Add(item);
			}
			stripped_tables.Valid = original_tables.Valid;
			stripped_tables.Sorted = original_tables.Sorted;
			reflection_writer = new ReflectionWriter(assembly.MainModule);
			reflection_writer.StructureWriter = new StructureWriter(assembly, writer);
			reflection_writer.CodeWriter.Stripped = true;
			metadata_writer = reflection_writer.MetadataWriter;
			PatchHeap(metadata_writer.StringWriter, original.MetadataRoot.Streams.StringsHeap);
			PatchHeap(metadata_writer.GuidWriter, original.MetadataRoot.Streams.GuidHeap);
			PatchHeap(metadata_writer.UserStringWriter, original.MetadataRoot.Streams.UserStringsHeap);
			PatchHeap(metadata_writer.BlobWriter, original.MetadataRoot.Streams.BlobHeap);
			if (assembly.EntryPoint != null)
			{
				metadata_writer.EntryPointToken = assembly.EntryPoint.MetadataToken.ToUInt();
			}
		}

		private static void PatchHeap(MemoryBinaryWriter heap_writer, MetadataHeap heap)
		{
			if (heap != null)
			{
				heap_writer.BaseStream.Position = 0L;
				heap_writer.Write(heap.Data);
			}
		}

		private void PatchMethods()
		{
			MethodTable methodTable = (MethodTable)stripped_tables[6];
			if (methodTable != null)
			{
				RVA rVA = RVA.Zero;
				for (int i = 0; i < methodTable.Rows.Count; i++)
				{
					MethodRow methodRow = methodTable[i];
					MetadataToken token = MetadataToken.FromMetadataRow(TokenType.Method, i);
					MethodDefinition meth = (MethodDefinition)assembly.MainModule.LookupByToken(token);
					rVA = (methodRow.RVA = ((!(rVA != RVA.Zero)) ? reflection_writer.CodeWriter.WriteMethodBody(meth) : rVA));
				}
			}
		}

		private void PatchFields()
		{
			FieldRVATable fieldRVATable = (FieldRVATable)stripped_tables[29];
			if (fieldRVATable != null)
			{
				for (int i = 0; i < fieldRVATable.Rows.Count; i++)
				{
					FieldRVARow fieldRVARow = fieldRVATable[i];
					MetadataToken token = new MetadataToken(TokenType.Field, fieldRVARow.Field);
					FieldDefinition fieldDefinition = (FieldDefinition)assembly.MainModule.LookupByToken(token);
					fieldRVARow.RVA = metadata_writer.GetDataCursor();
					metadata_writer.AddData((fieldDefinition.InitialValue.Length + 3) & -4);
					metadata_writer.AddFieldInitData(fieldDefinition.InitialValue);
				}
			}
		}

		private void PatchResources()
		{
			ManifestResourceTable manifestResourceTable = (ManifestResourceTable)stripped_tables[40];
			if (manifestResourceTable == null)
			{
				return;
			}
			for (int i = 0; i < manifestResourceTable.Rows.Count; i++)
			{
				ManifestResourceRow manifestResourceRow = manifestResourceTable[i];
				if (manifestResourceRow.Implementation.RID == 0)
				{
					foreach (Resource resource in assembly.MainModule.Resources)
					{
						EmbeddedResource embeddedResource = resource as EmbeddedResource;
						if (embeddedResource != null && !(resource.Name != original.MetadataRoot.Streams.StringsHeap[manifestResourceRow.Name]))
						{
							manifestResourceRow.Offset = metadata_writer.AddResource(embeddedResource.Data);
						}
					}
				}
			}
		}

		private void Write()
		{
			stripped.MetadataRoot.Accept(metadata_writer);
		}

		public static void StripAssembly(AssemblyDefinition assembly, string file)
		{
			using (FileStream output = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None))
			{
				new AssemblyStripper(assembly, new BinaryWriter(output)).Strip();
			}
		}
	}
}
