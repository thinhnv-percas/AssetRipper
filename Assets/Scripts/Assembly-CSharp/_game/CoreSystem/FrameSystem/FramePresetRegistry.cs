using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem
{
	[CreateAssetMenu(fileName = "FramePresetRegistry", menuName = "Game/Frame Preset Registry")]
	[Token(Token = "0x20004E6")]
	public class FramePresetRegistry : ScriptableObject
	{
		[Serializable]
		[Token(Token = "0x20004E7")]
		public struct Entry
		{
			[Token(Token = "0x400105A")]
			[FieldOffset(Offset = "0x0")]
			public FramePresetType presetType;

			[Token(Token = "0x400105B")]
			[FieldOffset(Offset = "0x8")]
			public FramePresetConfig config;
		}

		[SerializeField]
		[Token(Token = "0x4001059")]
		[FieldOffset(Offset = "0x18")]
		private Entry[] m_entries;

		[Token(Token = "0x60014A8")]
		[Address(RVA = "0x3CFB864", Offset = "0x3CFB864", Length = "0x114")]
		public FramePresetConfig Get(FramePresetType type)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FramePresetRegistry::Get");
			return default;
		}

		[Token(Token = "0x60014A9")]
		[Address(RVA = "0x3CFB978", Offset = "0x3CFB978", Length = "0x8")]
		public FramePresetRegistry()
		{
		}
	}
}
