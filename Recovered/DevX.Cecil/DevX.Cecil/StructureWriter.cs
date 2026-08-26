using DevX.Cecil.Binary;
using DevX.Cecil.Metadata;
using System;
using System.IO;

namespace DevX.Cecil
{
	internal sealed class StructureWriter : BaseStructureVisitor
	{
		private MetadataWriter m_mdWriter;

		private MetadataTableWriter m_tableWriter;

		private MetadataRowWriter m_rowWriter;

		private AssemblyDefinition m_asm;

		private BinaryWriter m_binaryWriter;

		public AssemblyDefinition Assembly => m_asm;

		public StructureWriter(AssemblyDefinition asm, BinaryWriter writer)
		{
			m_asm = asm;
			m_binaryWriter = writer;
		}

		private static void ResetImage(ModuleDefinition mod)
		{
			Image image = Image.CreateImage();
			image.Accept(new CopyImageVisitor(mod.Image));
			mod.Image = image;
		}

		public BinaryWriter GetWriter()
		{
			return m_binaryWriter;
		}

		public override void VisitAssemblyDefinition(AssemblyDefinition asm)
		{
			if (asm.Kind != 0 && asm.EntryPoint == null)
			{
				throw new ReflectionException("Assembly does not have an entry point defined");
			}
			if ((asm.MainModule.Image.CLIHeader.Flags & RuntimeImage.ILOnly) == (RuntimeImage)0u)
			{
				throw new NotSupportedException("Can not write a mixed mode assembly");
			}
			foreach (ModuleDefinition module in asm.Modules)
			{
				if (module.Image.CLIHeader.Metadata.VirtualAddress != RVA.Zero)
				{
					ResetImage(module);
				}
			}
			asm.MetadataToken = new MetadataToken(TokenType.Assembly, 1u);
			ReflectionWriter writer = asm.MainModule.Controller.Writer;
			writer.StructureWriter = this;
			m_mdWriter = writer.MetadataWriter;
			m_tableWriter = writer.MetadataTableWriter;
			m_rowWriter = writer.MetadataRowWriter;
			if (writer.SaveSymbols)
			{
				FileStream fileStream = m_binaryWriter.BaseStream as FileStream;
				if (fileStream != null)
				{
					writer.OutputFile = fileStream.Name;
				}
			}
		}

		public override void VisitAssemblyNameDefinition(AssemblyNameDefinition name)
		{
			AssemblyTable assemblyTable = m_tableWriter.GetAssemblyTable();
			if (name.PublicKey != null && name.PublicKey.Length > 0)
			{
				name.Flags |= AssemblyFlags.PublicKey;
			}
			AssemblyRow value = m_rowWriter.CreateAssemblyRow(name.HashAlgorithm, (ushort)name.Version.Major, (ushort)name.Version.Minor, (ushort)name.Version.Build, (ushort)name.Version.Revision, name.Flags, m_mdWriter.AddBlob(name.PublicKey), m_mdWriter.AddString(name.Name), m_mdWriter.AddString(name.Culture));
			assemblyTable.Rows.Add(value);
		}

		public override void VisitAssemblyNameReferenceCollection(AssemblyNameReferenceCollection references)
		{
			foreach (AssemblyNameReference reference in references)
			{
				VisitAssemblyNameReference(reference);
			}
		}

		public override void VisitAssemblyNameReference(AssemblyNameReference name)
		{
			byte[] data = (name.PublicKey != null && name.PublicKey.Length > 0) ? name.PublicKey : ((name.PublicKeyToken == null || name.PublicKeyToken.Length <= 0) ? new byte[0] : name.PublicKeyToken);
			AssemblyRefTable assemblyRefTable = m_tableWriter.GetAssemblyRefTable();
			AssemblyRefRow value = m_rowWriter.CreateAssemblyRefRow((ushort)name.Version.Major, (ushort)name.Version.Minor, (ushort)name.Version.Build, (ushort)name.Version.Revision, name.Flags, m_mdWriter.AddBlob(data), m_mdWriter.AddString(name.Name), m_mdWriter.AddString(name.Culture), m_mdWriter.AddBlob(name.Hash));
			assemblyRefTable.Rows.Add(value);
		}

		public override void VisitResourceCollection(ResourceCollection resources)
		{
			VisitCollection(resources);
		}

		public override void VisitEmbeddedResource(EmbeddedResource res)
		{
			AddManifestResource(m_mdWriter.AddResource(res.Data), res.Name, res.Flags, new MetadataToken(TokenType.ManifestResource, 0u));
		}

		public override void VisitLinkedResource(LinkedResource res)
		{
			FileTable fileTable = m_tableWriter.GetFileTable();
			FileRow value = m_rowWriter.CreateFileRow(FileAttributes.ContainsNoMetaData, m_mdWriter.AddString(res.File), m_mdWriter.AddBlob(res.Hash));
			fileTable.Rows.Add(value);
			AddManifestResource(0u, res.Name, res.Flags, new MetadataToken(TokenType.File, (uint)(fileTable.Rows.IndexOf(value) + 1)));
		}

		public override void VisitAssemblyLinkedResource(AssemblyLinkedResource res)
		{
			AddManifestResource(impl: new MetadataToken(TokenType.AssemblyRef, (uint)(m_asm.MainModule.AssemblyReferences.IndexOf(res.Assembly) + 1)), offset: 0u, name: res.Name, flags: res.Flags);
		}

		private void AddManifestResource(uint offset, string name, ManifestResourceAttributes flags, MetadataToken impl)
		{
			ManifestResourceTable manifestResourceTable = m_tableWriter.GetManifestResourceTable();
			ManifestResourceRow value = m_rowWriter.CreateManifestResourceRow(offset, flags, m_mdWriter.AddString(name), impl);
			manifestResourceTable.Rows.Add(value);
		}

		public override void VisitModuleDefinitionCollection(ModuleDefinitionCollection modules)
		{
			VisitCollection(modules);
		}

		public override void VisitModuleDefinition(ModuleDefinition module)
		{
			if (module.Main)
			{
				ModuleTable moduleTable = m_tableWriter.GetModuleTable();
				ModuleRow value = m_rowWriter.CreateModuleRow(0, m_mdWriter.AddString(module.Name), m_mdWriter.AddGuid(module.Mvid), 0u, 0u);
				moduleTable.Rows.Add(value);
				module.MetadataToken = new MetadataToken(TokenType.Module, 1u);
				return;
			}
			throw new NotImplementedException();
		}

		public override void VisitModuleReferenceCollection(ModuleReferenceCollection modules)
		{
			VisitCollection(modules);
		}

		public override void VisitModuleReference(ModuleReference module)
		{
			ModuleRefTable moduleRefTable = m_tableWriter.GetModuleRefTable();
			ModuleRefRow value = m_rowWriter.CreateModuleRefRow(m_mdWriter.AddString(module.Name));
			moduleRefTable.Rows.Add(value);
		}

		public override void TerminateAssemblyDefinition(AssemblyDefinition asm)
		{
			foreach (ModuleDefinition module in asm.Modules)
			{
				ReflectionWriter writer = module.Controller.Writer;
				writer.VisitModuleDefinition(module);
				writer.VisitTypeReferenceCollection(module.TypeReferences);
				writer.VisitTypeDefinitionCollection(module.Types);
				writer.VisitMemberReferenceCollection(module.MemberReferences);
				writer.CompleteTypeDefinitions();
				writer.TerminateModuleDefinition(module);
			}
		}
	}
}
