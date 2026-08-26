using System.IO;
using System.Text;
using Wasm.Binary;

namespace Wasm.Instructions
{
	public abstract class Operator
	{
		public byte OpCode
		{
			get;
			internal set;
		}

		public WasmType DeclaringType
		{
			get;
			internal set;
		}

		public string Mnemonic
		{
			get;
			internal set;
		}

		public bool HasDeclaringType => DeclaringType != WasmType.Empty;

		public Operator(byte opCode, WasmType declaringType, string mnemonic)
		{
			OpCode = opCode;
			DeclaringType = declaringType;
			Mnemonic = mnemonic;
		}

		public abstract Instruction ReadImmediates(BinaryWasmReader reader);

		public virtual void Dump(TextWriter writer)
		{
			if (HasDeclaringType)
			{
				DumpHelpers.DumpWasmType(DeclaringType, writer);
				writer.Write(".");
			}
			writer.Write(Mnemonic);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			Dump(new StringWriter(stringBuilder));
			return stringBuilder.ToString();
		}
	}
}
