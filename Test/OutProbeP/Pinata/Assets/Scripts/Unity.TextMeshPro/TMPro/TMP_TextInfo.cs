using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000056")]
	public class TMP_TextInfo
	{
		[Token(Token = "0x40003D8")]
		private static Vector2 k_InfinityVectorPositive;

		[Token(Token = "0x40003D9")]
		private static Vector2 k_InfinityVectorNegative;

		[Token(Token = "0x40003DA")]
		[FieldOffset(Offset = "0x10")]
		public TMP_Text textComponent;

		[Token(Token = "0x40003DB")]
		[FieldOffset(Offset = "0x18")]
		public int characterCount;

		[Token(Token = "0x40003DC")]
		[FieldOffset(Offset = "0x1C")]
		public int spriteCount;

		[Token(Token = "0x40003DD")]
		[FieldOffset(Offset = "0x20")]
		public int spaceCount;

		[Token(Token = "0x40003DE")]
		[FieldOffset(Offset = "0x24")]
		public int wordCount;

		[Token(Token = "0x40003DF")]
		[FieldOffset(Offset = "0x28")]
		public int linkCount;

		[Token(Token = "0x40003E0")]
		[FieldOffset(Offset = "0x2C")]
		public int lineCount;

		[Token(Token = "0x40003E1")]
		[FieldOffset(Offset = "0x30")]
		public int pageCount;

		[Token(Token = "0x40003E2")]
		[FieldOffset(Offset = "0x34")]
		public int materialCount;

		[Token(Token = "0x40003E3")]
		[FieldOffset(Offset = "0x38")]
		public TMP_CharacterInfo[] characterInfo;

		[Token(Token = "0x40003E4")]
		[FieldOffset(Offset = "0x40")]
		public TMP_WordInfo[] wordInfo;

		[Token(Token = "0x40003E5")]
		[FieldOffset(Offset = "0x48")]
		public TMP_LinkInfo[] linkInfo;

		[Token(Token = "0x40003E6")]
		[FieldOffset(Offset = "0x50")]
		public TMP_LineInfo[] lineInfo;

		[Token(Token = "0x40003E7")]
		[FieldOffset(Offset = "0x58")]
		public TMP_PageInfo[] pageInfo;

		[Token(Token = "0x40003E8")]
		[FieldOffset(Offset = "0x60")]
		public TMP_MeshInfo[] meshInfo;

		[Token(Token = "0x40003E9")]
		[FieldOffset(Offset = "0x68")]
		private TMP_MeshInfo[] m_CachedMeshInfo;

		[Token(Token = "0x60004CF")]
		[Address(RVA = "0xC89ED8", Offset = "0xC89ED8", Length = "0xDC")]
		public TMP_TextInfo()
		{
		}

		[Token(Token = "0x60004D0")]
		[Address(RVA = "0xC89FB4", Offset = "0xC89FB4", Length = "0x13C")]
		public TMP_TextInfo(TMP_Text textComponent)
		{
		}

		[Token(Token = "0x60004D1")]
		[Address(RVA = "0xC8A0F0", Offset = "0xC8A0F0", Length = "0x68")]
		public void Clear()
		{
		}

		[Token(Token = "0x60004D2")]
		[Address(RVA = "0xC8A158", Offset = "0xC8A158", Length = "0x80")]
		public void ClearMeshInfo(bool updateMesh)
		{
		}

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0xC8A1D8", Offset = "0xC8A1D8", Length = "0x7C")]
		public void ClearAllMeshInfo()
		{
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0xC8A254", Offset = "0xC8A254", Length = "0x84")]
		public void ResetVertexLayout(bool isVolumetric)
		{
		}

		[Token(Token = "0x60004D5")]
		[Address(RVA = "0xC8A2D8", Offset = "0xC8A2D8", Length = "0x7C")]
		public void ClearUnusedVertices(MaterialReference[] materials)
		{
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0xC8A354", Offset = "0xC8A354", Length = "0x21C")]
		public void ClearLineInfo()
		{
		}

		[Token(Token = "0x60004D7")]
		[Address(RVA = "0xC8A570", Offset = "0xC8A570", Length = "0x3E4")]
		public TMP_MeshInfo[] CopyMeshInfoVertexData()
		{
			return null;
		}

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0xCE01F8", Offset = "0xCE01F8", Length = "0xA0")]
		public static void Resize<T>(ref T[] array, int size)
		{
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0xCE0298", Offset = "0xCE0298", Length = "0xE4")]
		public static void Resize<T>(ref T[] array, int size, bool isBlockAllocated)
		{
		}
	}
}
