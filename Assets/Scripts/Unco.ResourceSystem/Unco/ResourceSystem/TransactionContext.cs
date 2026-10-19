using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.ResourceSystem
{
	[Serializable]
	[Token(Token = "0x2000012")]
	public struct TransactionContext
	{
		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x0")]
		public string Source;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x8")]
		public string CustomData;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x10")]
		public bool SuppressEvents;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x11")]
		public bool SuppressAnalytics;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x14")]
		public int Level;

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x81D24FC", Offset = "0x81D24FC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.Source = v27;\n\treturnBuffer.SuppressEvents = 0;\n\treturn returnBuffer;\n")]
		public static TransactionContext Create(string source, int level, string customData = "")
		{
			TransactionContext result = default(TransactionContext);
			string source2 = default(string);
			result.Source = source2;
			result.SuppressEvents = false;
			return result;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x81D2660", Offset = "0x81D2660", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.Source = v20;\n\treturnBuffer.SuppressEvents = 0x101;\n\treturn returnBuffer;\n")]
		public static TransactionContext Silent(string source, int level)
		{
			TransactionContext result = default(TransactionContext);
			string source2 = default(string);
			result.Source = source2;
			result.SuppressEvents = true;
			return result;
		}
	}
}
