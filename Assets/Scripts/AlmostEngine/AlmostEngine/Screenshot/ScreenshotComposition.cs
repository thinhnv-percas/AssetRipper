using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x2000016")]
	public class ScreenshotComposition
	{
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x10")]
		public bool m_Active;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x18")]
		public string m_Name;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x20")]
		public ScreenshotComposer m_Composer;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3C30D64", Offset = "0x3C30D64", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.m_Active = 1;\n\tthis.m_Name = \"New composition\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ScreenshotComposition()
		{
			m_Active = true;
			m_Name = "New composition";
		}
	}
}
