using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Rendering;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000037")]
	public static class StencilMaterial
	{
		[Token(Token = "0x20000AA")]
		private class MatEntry
		{
			[Token(Token = "0x40002E3")]
			[FieldOffset(Offset = "0x10")]
			public Material baseMat;

			[Token(Token = "0x40002E4")]
			[FieldOffset(Offset = "0x18")]
			public Material customMat;

			[Token(Token = "0x40002E5")]
			[FieldOffset(Offset = "0x20")]
			public int count;

			[Token(Token = "0x40002E6")]
			[FieldOffset(Offset = "0x24")]
			public int stencilId;

			[Token(Token = "0x40002E7")]
			[FieldOffset(Offset = "0x28")]
			public StencilOp operation;

			[Token(Token = "0x40002E8")]
			[FieldOffset(Offset = "0x2C")]
			public CompareFunction compareFunction;

			[Token(Token = "0x40002E9")]
			[FieldOffset(Offset = "0x30")]
			public int readMask;

			[Token(Token = "0x40002EA")]
			[FieldOffset(Offset = "0x34")]
			public int writeMask;

			[Token(Token = "0x40002EB")]
			[FieldOffset(Offset = "0x38")]
			public bool useAlphaClip;

			[Token(Token = "0x40002EC")]
			[FieldOffset(Offset = "0x3C")]
			public ColorWriteMask colorMask;

			[Token(Token = "0x6000676")]
			[Address(RVA = "0xED9A6C", Offset = "0xED9A6C", Length = "0x10")]
			public MatEntry()
			{
			}
		}

		[Token(Token = "0x400015B")]
		private static List<MatEntry> m_List;

		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72A34C", Offset = "0x72A34C")]
		[Obsolete]
		[Token(Token = "0x6000405")]
		[Address(RVA = "0xED9A64", Offset = "0xED9A64", Length = "0x8")]
		public static Material Add(Material baseMat, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x6000406")]
		[Address(RVA = "0xEC80F0", Offset = "0xEC80F0", Length = "0x9C")]
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask)
		{
			return null;
		}

		[Token(Token = "0x6000407")]
		[Address(RVA = "0xEC818C", Offset = "0xEC818C", Length = "0x828")]
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask, int readMask, int writeMask)
		{
			return null;
		}

		[Token(Token = "0x6000408")]
		[Address(RVA = "0xEC77C4", Offset = "0xEC77C4", Length = "0x1B8")]
		public static void Remove(Material customMat)
		{
		}

		[Token(Token = "0x6000409")]
		[Address(RVA = "0xED9A7C", Offset = "0xED9A7C", Length = "0x118")]
		public static void ClearAll()
		{
		}
	}
}
