using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Rendering;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000072")]
	public static class StencilMaterial
	{
		[Token(Token = "0x2000073")]
		private class MatEntry
		{
			[Token(Token = "0x400023E")]
			[FieldOffset(Offset = "0x10")]
			public Material baseMat;

			[Token(Token = "0x400023F")]
			[FieldOffset(Offset = "0x18")]
			public Material customMat;

			[Token(Token = "0x4000240")]
			[FieldOffset(Offset = "0x20")]
			public int count;

			[Token(Token = "0x4000241")]
			[FieldOffset(Offset = "0x24")]
			public int stencilId;

			[Token(Token = "0x4000242")]
			[FieldOffset(Offset = "0x28")]
			public StencilOp operation;

			[Token(Token = "0x4000243")]
			[FieldOffset(Offset = "0x2C")]
			public CompareFunction compareFunction;

			[Token(Token = "0x4000244")]
			[FieldOffset(Offset = "0x30")]
			public int readMask;

			[Token(Token = "0x4000245")]
			[FieldOffset(Offset = "0x34")]
			public int writeMask;

			[Token(Token = "0x4000246")]
			[FieldOffset(Offset = "0x38")]
			public bool useAlphaClip;

			[Token(Token = "0x4000247")]
			[FieldOffset(Offset = "0x3C")]
			public ColorWriteMask colorMask;

			[Token(Token = "0x60004A2")]
			[Address(RVA = "0x18383E0", Offset = "0x18383E0", Length = "0x10")]
			public MatEntry()
			{
			}
		}

		[Token(Token = "0x400023D")]
		private static List<MatEntry> m_List;

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("Use Material.Add instead.", true)]
		[Token(Token = "0x600049B")]
		[Address(RVA = "0x183793C", Offset = "0x183793C", Length = "0x8")]
		public static Material Add(Material baseMat, int stencilID)
		{
			return null;
		}

		[Token(Token = "0x600049C")]
		[Address(RVA = "0x1837944", Offset = "0x1837944", Length = "0x8C")]
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask)
		{
			return null;
		}

		[Token(Token = "0x600049D")]
		[Address(RVA = "0x1838338", Offset = "0x1838338", Length = "0xA8")]
		private static void LogWarningWhenNotInBatchmode(string warning, Object context)
		{
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0x18379D0", Offset = "0x18379D0", Length = "0x968")]
		public static Material Add(Material baseMat, int stencilID, StencilOp operation, CompareFunction compareFunction, ColorWriteMask colorWriteMask, int readMask, int writeMask)
		{
			return null;
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0x18383F0", Offset = "0x18383F0", Length = "0x1C0")]
		public static void Remove(Material customMat)
		{
		}

		[Token(Token = "0x60004A0")]
		[Address(RVA = "0x18385B0", Offset = "0x18385B0", Length = "0x120")]
		public static void ClearAll()
		{
		}
	}
}
