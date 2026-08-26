using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;

namespace Wasm
{
	public sealed class FunctionType
	{
		[CompilerGenerated]
		internal List<WasmValueType> _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		internal List<WasmValueType> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020;

		public WasmType Form => WasmType.Func;

		public List<WasmValueType> ParameterTypes
		{
			get;
			internal set;
		}

		public List<WasmValueType> ReturnTypes
		{
			get;
			internal set;
		}

		public FunctionType()
		{
			ParameterTypes = new List<WasmValueType>();
			ReturnTypes = new List<WasmValueType>();
		}

		public FunctionType(IEnumerable<WasmValueType> parameterTypes, IEnumerable<WasmValueType> returnTypes)
		{
			ParameterTypes = new List<WasmValueType>(parameterTypes);
			ReturnTypes = new List<WasmValueType>(returnTypes);
		}

		internal FunctionType(List<WasmValueType> parameterTypes, List<WasmValueType> returnTypes)
		{
			ParameterTypes = parameterTypes;
			ReturnTypes = returnTypes;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteWasmType(Form);
			writer.WriteVarUInt32((uint)ParameterTypes.Count);
			foreach (WasmValueType parameterType in ParameterTypes)
			{
				writer.WriteWasmValueType(parameterType);
			}
			writer.WriteVarUInt32((uint)ReturnTypes.Count);
			foreach (WasmValueType returnType in ReturnTypes)
			{
				writer.WriteWasmValueType(returnType);
			}
		}

		public void Dump(TextWriter writer)
		{
			writer.Write("func(");
			for (int i = 0; i < ParameterTypes.Count; i++)
			{
				if (i > 0)
				{
					writer.Write(", ");
				}
				DumpHelpers.DumpWasmType(ParameterTypes[i], writer);
			}
			writer.Write(") returns (");
			for (int j = 0; j < ReturnTypes.Count; j++)
			{
				if (j > 0)
				{
					writer.Write(", ");
				}
				DumpHelpers.DumpWasmType(ReturnTypes[j], writer);
			}
			writer.Write(")");
		}

		public override string ToString()
		{
			StringWriter stringWriter = new StringWriter();
			Dump(stringWriter);
			return stringWriter.ToString();
		}

		public static FunctionType ReadFrom(BinaryWasmReader reader)
		{
			WasmType wasmType = reader.ReadWasmType();
			if (wasmType != WasmType.Func)
			{
				throw new WasmException("Invalid 'form' value ('" + wasmType + "') for function type.");
			}
			uint num = reader.ReadVarUInt32();
			List<WasmValueType> list = new List<WasmValueType>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(reader.ReadWasmValueType());
			}
			uint num3 = reader.ReadVarUInt32();
			List<WasmValueType> list2 = new List<WasmValueType>((int)num3);
			for (uint num4 = 0u; num4 < num3; num4++)
			{
				list2.Add(reader.ReadWasmValueType());
			}
			return new FunctionType(list, list2);
		}
	}
}
