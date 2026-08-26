using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public struct TableType
	{
		[CompilerGenerated]
		private WasmType _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private ResizableLimits _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A;

		public WasmType ElementType
		{
			get;
			private set;
		}

		public ResizableLimits Limits
		{
			get;
			private set;
		}

		public TableType(WasmType elementType, ResizableLimits limits)
		{
			ElementType = elementType;
			Limits = limits;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteWasmType(ElementType);
			Limits.WriteTo(writer);
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("(elem_type: ");
			DumpHelpers.DumpWasmType(ElementType, writer);
			writer.Write(", limits: ");
			Limits.Dump(writer);
			writer.Write(")");
		}

		public static TableType ReadFrom(BinaryWasmReader reader)
		{
			WasmType elementType = reader.ReadWasmType();
			ResizableLimits limits = reader.ReadResizableLimits();
			return new TableType(elementType, limits);
		}
	}
}
