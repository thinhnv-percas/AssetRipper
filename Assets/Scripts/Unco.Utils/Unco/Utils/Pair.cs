using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Utils
{
	[Serializable]
	[Token(Token = "0x2000006")]
	public struct Pair<T, TK>
	{
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x0")]
		public T Key;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x0")]
		public TK Value;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x5EA1BDC", Offset = "0x5EA1BDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Key = keyC;\n\t*([this @ X0 (Unco.Utils.Pair`2<T, TK>)+4]) = valueC;\n\treturn;\n")]
		public Pair(T keyC, TK valueC)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Pair::.ctor");
			this = default;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x5EA1BE4", Offset = "0x5EA1BE4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([key @ X1 (T&)]) = this.Key;\n\tthis->klass+0x4 = this->klass+0x4;\n\treturn;\n")]
		public void Deconstruct(out T key, out TK value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Pair::Deconstruct");
			key = default;
			value = default;
		}
	}
}
