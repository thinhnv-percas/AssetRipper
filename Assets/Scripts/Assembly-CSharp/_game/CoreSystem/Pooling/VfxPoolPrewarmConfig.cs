using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.Pooling
{
	[CreateAssetMenu(fileName = "VfxPoolPrewarmConfig", menuName = "SandOut/Pooling/VfxPoolPrewarmConfig")]
	[Token(Token = "0x2000128")]
	public class VfxPoolPrewarmConfig : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x2000129")]
		public struct Entry
		{
			[Token(Token = "0x40003D7")]
			[FieldOffset(Offset = "0x0")]
			public GameObject prefab;

			[Min(0f)]
			[Token(Token = "0x40003D8")]
			[FieldOffset(Offset = "0x8")]
			public int prewarmCount;

			[Min(1f)]
			[Token(Token = "0x40003D9")]
			[FieldOffset(Offset = "0xC")]
			public int defaultCapacity;

			[Min(1f)]
			[Token(Token = "0x40003DA")]
			[FieldOffset(Offset = "0x10")]
			public int maxSize;
		}

		[SerializeField]
		[Token(Token = "0x40003D6")]
		[FieldOffset(Offset = "0x18")]
		internal List<Entry> m_entries;

		[Token(Token = "0x17000091")]
		public IReadOnlyList<Entry> Entries
		{
			[Token(Token = "0x60005FE")]
			[Address(RVA = "0x3DB0C60", Offset = "0x3DB0C60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_entries;\n")]
			get
			{
				return m_entries;
			}
		}

		[Token(Token = "0x60005FF")]
		[Address(RVA = "0x3DB0C68", Offset = "0x3DB0C68", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.Pooling.VfxPoolPrewarmConfig+Entry>::.ctor(v48);\n\tthis.m_entries = v48;\n")]
		public VfxPoolPrewarmConfig()
		{
			List<Entry> entries = new List<Entry>();
			m_entries = entries;
		}
	}
}
