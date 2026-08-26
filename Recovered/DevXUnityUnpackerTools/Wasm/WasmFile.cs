using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class WasmFile
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020
		{
			public static readonly _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020 _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020();

			public static Predicate<Section> _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020;

			internal bool _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A(Section _0020)
			{
				return _0020 is StartSection;
			}
		}

		[CompilerGenerated]
		private VersionHeader _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		private List<Section> _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A;

		public VersionHeader Header
		{
			get;
			set;
		}

		public List<Section> Sections
		{
			get;
			private set;
		}

		public string ModuleName
		{
			get
			{
				return _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A?.ModuleName;
			}
			set
			{
				ModuleNameEntry moduleNameEntry = _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A;
				if (moduleNameEntry == null)
				{
					AddNameEntry(new ModuleNameEntry(value));
				}
				else
				{
					moduleNameEntry.ModuleName = value;
				}
			}
		}

		private ModuleNameEntry _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A
		{
			get
			{
				NameSection firstSectionOrNull = GetFirstSectionOrNull<NameSection>();
				if (firstSectionOrNull == null)
				{
					return null;
				}
				ModuleNameEntry moduleNameEntry = firstSectionOrNull.Names.OfType<ModuleNameEntry>().FirstOrDefault();
				if (moduleNameEntry == null)
				{
					return null;
				}
				return moduleNameEntry;
			}
		}

		public uint? StartFunctionIndex
		{
			get
			{
				return GetFirstSectionOrNull<StartSection>()?.StartFunctionIndex;
			}
			set
			{
				if (value.HasValue)
				{
					StartSection firstSectionOrNull = GetFirstSectionOrNull<StartSection>();
					if (firstSectionOrNull == null)
					{
						InsertSection(new StartSection(value.Value));
					}
					else
					{
						firstSectionOrNull.StartFunctionIndex = value.Value;
					}
				}
				else
				{
					Sections.RemoveAll(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A);
				}
			}
		}

		public WasmFile()
			: this(VersionHeader.MvpHeader)
		{
		}

		public WasmFile(VersionHeader header)
			: this(header, Enumerable.Empty<Section>())
		{
		}

		public WasmFile(VersionHeader header, IEnumerable<Section> sections)
		{
			Header = header;
			Sections = new List<Section>(sections);
		}

		public IList<T> GetSections<T>() where T : Section
		{
			List<T> list = new List<T>();
			for (int i = 0; i < Sections.Count; i++)
			{
				Section section = Sections[i];
				if (section is T)
				{
					list.Add((T)section);
				}
			}
			return list;
		}

		public IList<Section> GetSections(SectionName name)
		{
			List<Section> list = new List<Section>();
			for (int i = 0; i < Sections.Count; i++)
			{
				Section section = Sections[i];
				if (section.Name == name)
				{
					list.Add(section);
				}
			}
			return list;
		}

		public Section GetFirstSectionOrNull(SectionName name)
		{
			for (int i = 0; i < Sections.Count; i++)
			{
				Section section = Sections[i];
				if (section.Name == name)
				{
					return section;
				}
			}
			return null;
		}

		public T GetFirstSectionOrNull<T>() where T : Section
		{
			for (int i = 0; i < Sections.Count; i++)
			{
				Section section = Sections[i];
				if (section is T)
				{
					return (T)section;
				}
			}
			return null;
		}

		public void WriteBinaryTo(Stream target)
		{
			new BinaryWasmWriter(new BinaryWriter(target)).WriteFile(this);
		}

		public void WriteBinaryTo(string path)
		{
			using (FileStream target = File.OpenWrite(path))
			{
				WriteBinaryTo(target);
			}
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("WebAssembly module; magic number: {0}, version number: {1}", DumpHelpers.FormatHex(Header.Magic), Header.Version);
			foreach (Section section in Sections)
			{
				writer.WriteLine();
				section.Dump(writer);
			}
		}

		public static WasmFile ReadBinary(Stream source)
		{
			return new BinaryWasmReader(new BinaryReader(source)).ReadFile();
		}

		public static WasmFile ReadBinary(Stream source, Func<bool> streamIsEmpty)
		{
			return new BinaryWasmReader(new BinaryReader(source), streamIsEmpty).ReadFile();
		}

		public static WasmFile ReadBinary(string path)
		{
			using (FileStream source = File.OpenRead(path))
			{
				return ReadBinary(source);
			}
		}

		public int InsertSection(Section section)
		{
			if (!section.Name.IsCustom)
			{
				for (int i = 0; i < Sections.Count; i++)
				{
					if (!Sections[i].Name.IsCustom && section.Name.Code < Sections[i].Name.Code)
					{
						Sections.Insert(i, section);
						return i;
					}
				}
			}
			Sections.Add(section);
			return Sections.Count - 1;
		}

		public uint AddNameEntry(NameEntry entry)
		{
			NameSection nameSection = GetFirstSectionOrNull<NameSection>();
			if (nameSection == null)
			{
				InsertSection(nameSection = new NameSection());
			}
			nameSection.Names.Add(entry);
			return (uint)(nameSection.Names.Count - 1);
		}

		public uint AddMemory(MemoryType memory)
		{
			MemorySection memorySection = GetFirstSectionOrNull<MemorySection>();
			if (memorySection == null)
			{
				InsertSection(memorySection = new MemorySection());
			}
			memorySection.Memories.Add(memory);
			return (uint)(memorySection.Memories.Count - 1);
		}

		public uint AddDataSegment(DataSegment segment)
		{
			DataSection dataSection = GetFirstSectionOrNull<DataSection>();
			if (dataSection == null)
			{
				InsertSection(dataSection = new DataSection());
			}
			dataSection.Segments.Add(segment);
			return (uint)(dataSection.Segments.Count - 1);
		}

		public uint AddImport(ImportedValue import)
		{
			ImportSection importSection = GetFirstSectionOrNull<ImportSection>();
			if (importSection == null)
			{
				InsertSection(importSection = new ImportSection());
			}
			importSection.Imports.Add(import);
			return (uint)(importSection.Imports.Count - 1);
		}

		public uint AddExport(ExportedValue export)
		{
			ExportSection exportSection = GetFirstSectionOrNull<ExportSection>();
			if (exportSection == null)
			{
				InsertSection(exportSection = new ExportSection());
			}
			exportSection.Exports.Add(export);
			return (uint)(exportSection.Exports.Count - 1);
		}

		public uint AddFunctionType(FunctionType type)
		{
			TypeSection typeSection = GetFirstSectionOrNull<TypeSection>();
			if (typeSection == null)
			{
				InsertSection(typeSection = new TypeSection());
			}
			typeSection.FunctionTypes.Add(type);
			return (uint)(typeSection.FunctionTypes.Count - 1);
		}

		public uint AddTable(TableType table)
		{
			TableSection tableSection = GetFirstSectionOrNull<TableSection>();
			if (tableSection == null)
			{
				InsertSection(tableSection = new TableSection());
			}
			tableSection.Tables.Add(table);
			return (uint)(tableSection.Tables.Count - 1);
		}

		public uint AddElementSegment(ElementSegment segment)
		{
			ElementSection elementSection = GetFirstSectionOrNull<ElementSection>();
			if (elementSection == null)
			{
				InsertSection(elementSection = new ElementSection());
			}
			elementSection.Segments.Add(segment);
			return (uint)(elementSection.Segments.Count - 1);
		}

		public uint AddFunction(uint functionTypeIndex, FunctionBody functionBody)
		{
			FunctionSection functionSection = GetFirstSectionOrNull<FunctionSection>();
			if (functionSection == null)
			{
				InsertSection(functionSection = new FunctionSection());
			}
			CodeSection codeSection = GetFirstSectionOrNull<CodeSection>();
			if (codeSection == null)
			{
				InsertSection(codeSection = new CodeSection());
			}
			functionSection.FunctionTypes.Add(functionTypeIndex);
			codeSection.Bodies.Add(functionBody);
			return (uint)(functionSection.FunctionTypes.Count - 1);
		}

		public uint AddGlobal(GlobalVariable globalVariable)
		{
			GlobalSection globalSection = GetFirstSectionOrNull<GlobalSection>();
			if (globalSection == null)
			{
				InsertSection(globalSection = new GlobalSection());
			}
			globalSection.GlobalVariables.Add(globalVariable);
			return (uint)(globalSection.GlobalVariables.Count - 1);
		}
	}
}
