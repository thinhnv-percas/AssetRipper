using DevX.Cecil.Binary;
using DevX.Cecil.Metadata;
using System;
using System.IO;

namespace DevX.Cecil
{
	internal sealed class StructureReader : BaseStructureVisitor
	{
		private ImageReader m_ir;

		private Image m_img;

		private bool m_manifestOnly;

		private AssemblyDefinition m_asmDef;

		private ModuleDefinition m_module;

		private MetadataStreamCollection m_streams;

		private TablesHeap m_tHeap;

		private MetadataTableReader m_tableReader;

		public bool ManifestOnly => m_manifestOnly;

		public ImageReader ImageReader => m_ir;

		public Image Image => m_img;

		public StructureReader(ImageReader ir)
		{
			if (ir.Image.CLIHeader == null)
			{
				throw new ImageFormatException("The image is not a managed assembly");
			}
			m_ir = ir;
			m_img = ir.Image;
			m_streams = m_img.MetadataRoot.Streams;
			m_tHeap = m_streams.TablesHeap;
			m_tableReader = ir.MetadataReader.TableReader;
		}

		public StructureReader(ImageReader ir, bool manifestOnly)
			: this(ir)
		{
			m_manifestOnly = manifestOnly;
		}

		private byte[] ReadBlob(uint pointer)
		{
			if (pointer == 0)
			{
				return new byte[0];
			}
			return m_streams.BlobHeap.Read(pointer);
		}

		private string ReadString(uint pointer)
		{
			return m_streams.StringsHeap[pointer];
		}

		public override void VisitAssemblyDefinition(AssemblyDefinition asm)
		{
			if (!m_tHeap.HasTable(32))
			{
				throw new ReflectionException("No assembly manifest");
			}
			asm.MetadataToken = new MetadataToken(TokenType.Assembly, 1u);
			m_asmDef = asm;
			switch (m_img.MetadataRoot.Header.Version)
			{
			case "v1.0.3705":
				asm.Runtime = TargetRuntime.NET_1_0;
				break;
			case "v1.1.4322":
				asm.Runtime = TargetRuntime.NET_1_1;
				break;
			case "v2.0.50727":
				asm.Runtime = TargetRuntime.NET_2_0;
				break;
			case "v4.0.20506":
				asm.Runtime = TargetRuntime.NET_4_0;
				break;
			}
			if ((m_img.PEFileHeader.Characteristics & ImageCharacteristics.Dll) != 0)
			{
				asm.Kind = AssemblyKind.Dll;
			}
			else if (m_img.PEOptionalHeader.NTSpecificFields.SubSystem == SubSystem.WindowsGui || m_img.PEOptionalHeader.NTSpecificFields.SubSystem == SubSystem.WindowsCeGui)
			{
				asm.Kind = AssemblyKind.Windows;
			}
			else
			{
				asm.Kind = AssemblyKind.Console;
			}
		}

		public override void VisitAssemblyNameDefinition(AssemblyNameDefinition name)
		{
			AssemblyTable assemblyTable = m_tableReader.GetAssemblyTable();
			AssemblyRow assemblyRow = assemblyTable[0];
			name.Name = ReadString(assemblyRow.Name);
			name.Flags = assemblyRow.Flags;
			name.PublicKey = ReadBlob(assemblyRow.PublicKey);
			name.Culture = ReadString(assemblyRow.Culture);
			name.Version = new Version(assemblyRow.MajorVersion, assemblyRow.MinorVersion, assemblyRow.BuildNumber, assemblyRow.RevisionNumber);
			name.HashAlgorithm = assemblyRow.HashAlgId;
			name.MetadataToken = new MetadataToken(TokenType.Assembly, 1u);
		}

		public override void VisitAssemblyNameReferenceCollection(AssemblyNameReferenceCollection names)
		{
			if (m_tHeap.HasTable(35))
			{
				AssemblyRefTable assemblyRefTable = m_tableReader.GetAssemblyRefTable();
				for (int i = 0; i < assemblyRefTable.Rows.Count; i++)
				{
					AssemblyRefRow assemblyRefRow = assemblyRefTable[i];
					AssemblyNameReference assemblyNameReference = new AssemblyNameReference(ReadString(assemblyRefRow.Name), ReadString(assemblyRefRow.Culture), new Version(assemblyRefRow.MajorVersion, assemblyRefRow.MinorVersion, assemblyRefRow.BuildNumber, assemblyRefRow.RevisionNumber));
					assemblyNameReference.PublicKeyToken = ReadBlob(assemblyRefRow.PublicKeyOrToken);
					assemblyNameReference.Hash = ReadBlob(assemblyRefRow.HashValue);
					assemblyNameReference.Flags = assemblyRefRow.Flags;
					assemblyNameReference.MetadataToken = new MetadataToken(TokenType.AssemblyRef, (uint)(i + 1));
					names.Add(assemblyNameReference);
				}
			}
		}

		public override void VisitResourceCollection(ResourceCollection resources)
		{
			if (!m_tHeap.HasTable(40))
			{
				return;
			}
			ManifestResourceTable manifestResourceTable = m_tableReader.GetManifestResourceTable();
			FileTable fileTable = m_tableReader.GetFileTable();
			for (int i = 0; i < manifestResourceTable.Rows.Count; i++)
			{
				ManifestResourceRow manifestResourceRow = manifestResourceTable[i];
				if (manifestResourceRow.Implementation.RID == 0)
				{
					EmbeddedResource embeddedResource = new EmbeddedResource(ReadString(manifestResourceRow.Name), manifestResourceRow.Flags);
					BinaryReader dataReader = m_ir.MetadataReader.GetDataReader(m_img.CLIHeader.Resources.VirtualAddress);
					dataReader.BaseStream.Position += manifestResourceRow.Offset;
					embeddedResource.Data = dataReader.ReadBytes(dataReader.ReadInt32());
					resources.Add(embeddedResource);
					continue;
				}
				switch (manifestResourceRow.Implementation.TokenType)
				{
				case TokenType.File:
				{
					FileRow fileRow = fileTable[(int)(manifestResourceRow.Implementation.RID - 1)];
					LinkedResource linkedResource = new LinkedResource(ReadString(manifestResourceRow.Name), manifestResourceRow.Flags, ReadString(fileRow.Name));
					linkedResource.Hash = ReadBlob(fileRow.HashValue);
					resources.Add(linkedResource);
					break;
				}
				case TokenType.AssemblyRef:
				{
					AssemblyNameReference asmRef = m_module.AssemblyReferences[(int)(manifestResourceRow.Implementation.RID - 1)];
					AssemblyLinkedResource value = new AssemblyLinkedResource(ReadString(manifestResourceRow.Name), manifestResourceRow.Flags, asmRef);
					resources.Add(value);
					break;
				}
				}
			}
		}

		public override void VisitModuleDefinitionCollection(ModuleDefinitionCollection modules)
		{
			ModuleTable moduleTable = m_tableReader.GetModuleTable();
			if (moduleTable == null || moduleTable.Rows.Count != 1)
			{
				throw new ReflectionException("Can not read main module");
			}
			ModuleRow moduleRow = moduleTable[0];
			string name = ReadString(moduleRow.Name);
			ModuleDefinition moduleDefinition = new ModuleDefinition(name, m_asmDef, this, main: true);
			moduleDefinition.Mvid = m_streams.GuidHeap[moduleRow.Mvid];
			moduleDefinition.MetadataToken = new MetadataToken(TokenType.Module, 1u);
			modules.Add(moduleDefinition);
			m_module = moduleDefinition;
			m_module.Accept(this);
			FileTable fileTable = m_tableReader.GetFileTable();
			if (fileTable != null && fileTable.Rows.Count != 0)
			{
				foreach (FileRow row in fileTable.Rows)
				{
					if (row.Flags == FileAttributes.ContainsMetaData)
					{
						name = ReadString(row.Name);
						FileInfo fileInfo = new FileInfo((m_img.FileInformation == null) ? name : Path.Combine(m_img.FileInformation.DirectoryName, name));
						if (!File.Exists(fileInfo.FullName))
						{
							throw new FileNotFoundException("Module not found : " + name);
						}
						try
						{
							ImageReader imageReader = ImageReader.Read(fileInfo.FullName);
							moduleTable = (imageReader.Image.MetadataRoot.Streams.TablesHeap[0] as ModuleTable);
							if (moduleTable == null || moduleTable.Rows.Count != 1)
							{
								throw new ReflectionException("Can not read module : " + name);
							}
							moduleRow = moduleTable[0];
							ModuleDefinition moduleDefinition2 = new ModuleDefinition(name, m_asmDef, new StructureReader(imageReader, m_manifestOnly), main: false);
							moduleDefinition2.Mvid = imageReader.Image.MetadataRoot.Streams.GuidHeap[moduleRow.Mvid];
							modules.Add(moduleDefinition2);
							moduleDefinition2.Accept(this);
						}
						catch (ReflectionException)
						{
							throw;
							IL_020c:;
						}
						catch (Exception inner)
						{
							throw new ReflectionException("Can not read module : " + name, inner);
							IL_0226:;
						}
					}
				}
			}
		}

		public override void VisitModuleReferenceCollection(ModuleReferenceCollection modules)
		{
			if (m_tHeap.HasTable(26))
			{
				ModuleRefTable moduleRefTable = m_tableReader.GetModuleRefTable();
				for (int i = 0; i < moduleRefTable.Rows.Count; i++)
				{
					ModuleRefRow moduleRefRow = moduleRefTable[i];
					ModuleReference moduleReference = new ModuleReference(ReadString(moduleRefRow.Name));
					moduleReference.MetadataToken = MetadataToken.FromMetadataRow(TokenType.ModuleRef, i);
					modules.Add(moduleReference);
				}
			}
		}

		public override void TerminateAssemblyDefinition(AssemblyDefinition asm)
		{
			if (!m_manifestOnly)
			{
				foreach (ModuleDefinition module in asm.Modules)
				{
					module.Controller.Reader.VisitModuleDefinition(module);
				}
			}
		}
	}
}
