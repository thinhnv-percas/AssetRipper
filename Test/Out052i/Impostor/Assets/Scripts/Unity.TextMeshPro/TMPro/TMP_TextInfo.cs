using System;
using Cpp2ILInjected;
using UnityEngine;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200009D")]
	public class TMP_TextInfo
	{
		[Token(Token = "0x40005C9")]
		internal static Vector2 k_InfinityVectorPositive;

		[Token(Token = "0x40005CA")]
		internal static Vector2 k_InfinityVectorNegative;

		[Token(Token = "0x40005CB")]
		[FieldOffset(Offset = "0x10")]
		public TMP_Text textComponent;

		[Token(Token = "0x40005CC")]
		[FieldOffset(Offset = "0x18")]
		public int characterCount;

		[Token(Token = "0x40005CD")]
		[FieldOffset(Offset = "0x1C")]
		public int spriteCount;

		[Token(Token = "0x40005CE")]
		[FieldOffset(Offset = "0x20")]
		public int spaceCount;

		[Token(Token = "0x40005CF")]
		[FieldOffset(Offset = "0x24")]
		public int wordCount;

		[Token(Token = "0x40005D0")]
		[FieldOffset(Offset = "0x28")]
		public int linkCount;

		[Token(Token = "0x40005D1")]
		[FieldOffset(Offset = "0x2C")]
		public int lineCount;

		[Token(Token = "0x40005D2")]
		[FieldOffset(Offset = "0x30")]
		public int pageCount;

		[Token(Token = "0x40005D3")]
		[FieldOffset(Offset = "0x34")]
		public int materialCount;

		[Token(Token = "0x40005D4")]
		[FieldOffset(Offset = "0x38")]
		public TMP_CharacterInfo[] characterInfo;

		[Token(Token = "0x40005D5")]
		[FieldOffset(Offset = "0x40")]
		public TMP_WordInfo[] wordInfo;

		[Token(Token = "0x40005D6")]
		[FieldOffset(Offset = "0x48")]
		public TMP_LinkInfo[] linkInfo;

		[Token(Token = "0x40005D7")]
		[FieldOffset(Offset = "0x50")]
		public TMP_LineInfo[] lineInfo;

		[Token(Token = "0x40005D8")]
		[FieldOffset(Offset = "0x58")]
		public TMP_PageInfo[] pageInfo;

		[Token(Token = "0x40005D9")]
		[FieldOffset(Offset = "0x60")]
		public TMP_MeshInfo[] meshInfo;

		[Token(Token = "0x40005DA")]
		[FieldOffset(Offset = "0x68")]
		private TMP_MeshInfo[] m_CachedMeshInfo;

		[Token(Token = "0x60005EA")]
		[Address(RVA = "0x1610468", Offset = "0x1610468", Length = "0x128")]
		public TMP_TextInfo()
		{
		}

		[Token(Token = "0x60005EB")]
		[Address(RVA = "0x1610590", Offset = "0x1610590", Length = "0x12C")]
		internal TMP_TextInfo(int characterCount)
		{
		}

		[Token(Token = "0x60005EC")]
		[Address(RVA = "0x16106BC", Offset = "0x16106BC", Length = "0x16C")]
		public TMP_TextInfo(TMP_Text textComponent)
		{
		}

		[Token(Token = "0x60005ED")]
		[Address(RVA = "0x1610828", Offset = "0x1610828", Length = "0x5C")]
		public void Clear()
		{
		}

		[Token(Token = "0x60005EE")]
		[Address(RVA = "0x1610884", Offset = "0x1610884", Length = "0x12C")]
		internal void ClearAllData()
		{
		}

		[Token(Token = "0x60005EF")]
		[Address(RVA = "0x16109B0", Offset = "0x16109B0", Length = "0xB8")]
		public void ClearMeshInfo(bool updateMesh)
		{
		}

		[Token(Token = "0x60005F0")]
		[Address(RVA = "0x1610A68", Offset = "0x1610A68", Length = "0xB0")]
		public void ClearAllMeshInfo()
		{
		}

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0x1610B18", Offset = "0x1610B18", Length = "0xBC")]
		public void ResetVertexLayout(bool isVolumetric)
		{
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0x1610BD4", Offset = "0x1610BD4", Length = "0xB0")]
		public void ClearUnusedVertices(MaterialReference[] materials)
		{
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0x1610C84", Offset = "0x1610C84", Length = "0x180")]
		public void ClearLineInfo()
		{
		}

		[Token(Token = "0x60005F4")]
		[Address(RVA = "0x1610E04", Offset = "0x1610E04", Length = "0x98")]
		internal void ClearPageInfo()
		{
		}

		[Token(Token = "0x60005F5")]
		[Address(RVA = "0x1610E9C", Offset = "0x1610E9C", Length = "0x3C0")]
		public TMP_MeshInfo[] CopyMeshInfoVertexData()
		{
			return null;
		}

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0xCAC0FC", Offset = "0xCAC0FC", Length = "0x5C")]
		public static void Resize<T>(ref T[] array, int size)
		{
		}

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0xCAC270", Offset = "0xCAC270", Length = "0xA0")]
		public static void Resize<T>(ref T[] array, int size, bool isBlockAllocated)
		{
		}
	}
}
