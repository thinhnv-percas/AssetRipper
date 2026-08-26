using System.CodeDom.Compiler;
using System.IO;

namespace Wasm
{
	public class DumpHelpers
	{
		public static string FormatHex(byte value)
		{
			return $"0x{value:x02}";
		}

		public static string FormatHex(ushort value)
		{
			return $"0x{value:x04}";
		}

		public static string FormatHex(uint value)
		{
			return $"0x{value:x08}";
		}

		public static void DumpStream(Stream stream, TextWriter writer)
		{
			bool flag = true;
			while (true)
			{
				int num = stream.ReadByte();
				if (num == -1)
				{
					break;
				}
				if (flag)
				{
					flag = false;
				}
				else
				{
					writer.Write(" ");
				}
				writer.Write(FormatHex((byte)num));
			}
		}

		public static void DumpBytes(byte[] bytes, TextWriter writer)
		{
			using (MemoryStream stream = new MemoryStream(bytes))
			{
				DumpStream(stream, writer);
			}
		}

		public static string WasmTypeToString(WasmType value)
		{
			switch (value)
			{
			case WasmType.AnyFunc:
				return "anyfunc";
			case WasmType.Empty:
				return "empty";
			case WasmType.Float32:
				return "f32";
			case WasmType.Float64:
				return "f64";
			case WasmType.Func:
				return "funcdef";
			case WasmType.Int32:
				return "i32";
			case WasmType.Int64:
				return "i64";
			default:
				return "unknown type (code: " + value + ")";
			}
		}

		public static string WasmTypeToString(WasmValueType value)
		{
			return WasmTypeToString((WasmType)value);
		}

		public static void DumpWasmType(WasmType value, TextWriter writer)
		{
			writer.Write(WasmTypeToString(value));
		}

		public static void DumpWasmType(WasmValueType value, TextWriter writer)
		{
			DumpWasmType((WasmType)value, writer);
		}

		public static TextWriter CreateIndentedTextWriter(TextWriter writer, string indentation)
		{
			return new IndentedTextWriter(writer, indentation)
			{
				Indent = 1
			};
		}

		public static TextWriter CreateIndentedTextWriter(TextWriter writer)
		{
			return CreateIndentedTextWriter(writer, "    ");
		}
	}
}
