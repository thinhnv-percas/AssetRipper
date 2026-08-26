using System.IO;
using Wasm.Binary;

namespace Wasm
{
	public abstract class ImportedValue
	{
		public string ModuleName
		{
			get;
			set;
		}

		public string FieldName
		{
			get;
			set;
		}

		public abstract ExternalKind Kind
		{
			get;
		}

		public ImportedValue(string moduleName, string fieldName)
		{
			ModuleName = moduleName;
			FieldName = fieldName;
		}

		internal abstract void WriteContentsTo(BinaryWasmWriter writer);

		internal abstract void DumpContents(TextWriter writer);

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteString(ModuleName);
			writer.WriteString(FieldName);
			writer.Writer.Write((byte)Kind);
			WriteContentsTo(writer);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("from \"{0}\" import {1} \"{2}\": ", ModuleName, Kind.ToString().ToLower(), FieldName);
			DumpContents(writer);
		}

		public static ImportedValue ReadFrom(BinaryWasmReader reader)
		{
			string moduleName = reader.ReadString();
			string fieldName = reader.ReadString();
			ExternalKind externalKind = (ExternalKind)reader.ReadByte();
			switch (externalKind)
			{
			case ExternalKind.Function:
				return new ImportedFunction(moduleName, fieldName, reader.ReadVarUInt32());
			case ExternalKind.Global:
				return new ImportedGlobal(moduleName, fieldName, GlobalType.ReadFrom(reader));
			case ExternalKind.Memory:
				return new ImportedMemory(moduleName, fieldName, MemoryType.ReadFrom(reader));
			case ExternalKind.Table:
				return new ImportedTable(moduleName, fieldName, TableType.ReadFrom(reader));
			default:
				throw new WasmException("Unknown imported value kind: " + externalKind);
			}
		}
	}
}
