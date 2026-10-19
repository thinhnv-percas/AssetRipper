using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem
{
	[CreateAssetMenu(fileName = "FramePreset", menuName = "Game/Frame Preset Config")]
	[Token(Token = "0x20004E5")]
	public class FramePresetConfig : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4001055")]
		[FieldOffset(Offset = "0x18")]
		private FramePresetType m_presetType;

		[SerializeField]
		[Token(Token = "0x4001056")]
		[FieldOffset(Offset = "0x20")]
		internal FrameData m_frameData;

		[SerializeField]
		[Token(Token = "0x4001057")]
		[FieldOffset(Offset = "0x40")]
		internal Vector2 m_playableSeedPoint;

		[SerializeField]
		[Token(Token = "0x4001058")]
		[FieldOffset(Offset = "0x48")]
		private GameObject m_conveyorPrefab;

		[Token(Token = "0x170001C7")]
		public FramePresetType PresetType
		{
			[Token(Token = "0x60014A2")]
			[Address(RVA = "0x3CFB670", Offset = "0x3CFB670", Length = "0x8")]
			get
			{
				return m_presetType;
			}
		}

		[Token(Token = "0x170001C8")]
		public FrameData FrameData
		{
			[Token(Token = "0x60014A3")]
			[Address(RVA = "0x3CFB678", Offset = "0x3CFB678", Length = "0xC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FramePresetConfig::get_FrameData");
				return default;
			}
		}

		[Token(Token = "0x170001C9")]
		public Vector2 PlayableSeedPoint
		{
			[Token(Token = "0x60014A4")]
			[Address(RVA = "0x3CFB684", Offset = "0x3CFB684", Length = "0x8")]
			get
			{
				return m_playableSeedPoint;
			}
		}

		[Token(Token = "0x170001CA")]
		public GameObject ConveyorPrefab
		{
			[Token(Token = "0x60014A5")]
			[Address(RVA = "0x3CFB68C", Offset = "0x3CFB68C", Length = "0x8")]
			get
			{
				return m_conveyorPrefab;
			}
		}

		[Token(Token = "0x60014A6")]
		[Address(RVA = "0x3CFB694", Offset = "0x3CFB694", Length = "0x1C8")]
		public void SetFrameData(FrameData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FramePresetConfig::SetFrameData");
		}

		[Token(Token = "0x60014A7")]
		[Address(RVA = "0x3CFB85C", Offset = "0x3CFB85C", Length = "0x8")]
		public FramePresetConfig()
		{
		}
	}
}
