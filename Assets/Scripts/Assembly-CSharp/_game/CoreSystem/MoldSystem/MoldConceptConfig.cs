using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.Utils;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[CreateAssetMenu(menuName = "Game/Mold Concept Config")]
	[Token(Token = "0x200049C")]
	public class MoldConceptConfig : ScriptableObject, IMoldMaterialProvider
	{
		[Serializable]
		[Token(Token = "0x200049D")]
		public struct MoldMaterialEntry
		{
			[Token(Token = "0x4000F41")]
			[FieldOffset(Offset = "0x0")]
			public GameColor gameColor;

			[Token(Token = "0x4000F42")]
			[FieldOffset(Offset = "0x8")]
			public Material moldMaterial;

			[Token(Token = "0x4000F43")]
			[FieldOffset(Offset = "0x10")]
			public Material moldInsideMaterial;
		}

		[SerializeField]
		[Token(Token = "0x4000F3A")]
		[FieldOffset(Offset = "0x18")]
		private string m_conceptId;

		[SerializeField]
		[Token(Token = "0x4000F3B")]
		[FieldOffset(Offset = "0x20")]
		private string m_displayName;

		[SerializeField]
		[Token(Token = "0x4000F3C")]
		[FieldOffset(Offset = "0x28")]
		private Sprite m_thumbnail;

		[SerializeField]
		[Token(Token = "0x4000F3D")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_moldPrefab;

		[SerializeField]
		[Token(Token = "0x4000F3E")]
		[FieldOffset(Offset = "0x38")]
		private MoldMaterialEntry[] m_materials;

		[SerializeField]
		[Token(Token = "0x4000F3F")]
		[FieldOffset(Offset = "0x40")]
		private Material m_hiddenMoldMaterial;

		[SerializeField]
		[Token(Token = "0x4000F40")]
		[FieldOffset(Offset = "0x48")]
		private List<Pair<GameColor, Color>> m_moldFillColors;

		[Token(Token = "0x170001A8")]
		public string ConceptId
		{
			[Token(Token = "0x6001327")]
			[Address(RVA = "0x3CE6AC8", Offset = "0x3CE6AC8", Length = "0x8")]
			get
			{
				return m_conceptId;
			}
		}

		[Token(Token = "0x170001A9")]
		public string DisplayName
		{
			[Token(Token = "0x6001328")]
			[Address(RVA = "0x3CE6AD0", Offset = "0x3CE6AD0", Length = "0x8")]
			get
			{
				return m_displayName;
			}
		}

		[Token(Token = "0x170001AA")]
		public Sprite Thumbnail
		{
			[Token(Token = "0x6001329")]
			[Address(RVA = "0x3CE6AD8", Offset = "0x3CE6AD8", Length = "0x8")]
			get
			{
				return m_thumbnail;
			}
		}

		[Token(Token = "0x170001AB")]
		public GameObject MoldPrefab
		{
			[Token(Token = "0x600132A")]
			[Address(RVA = "0x3CE6AE0", Offset = "0x3CE6AE0", Length = "0x8")]
			get
			{
				return m_moldPrefab;
			}
		}

		[Token(Token = "0x170001AC")]
		public Material HiddenMoldMaterial
		{
			[Token(Token = "0x600132D")]
			[Address(RVA = "0x3CE6D60", Offset = "0x3CE6D60", Length = "0x8")]
			get
			{
				return m_hiddenMoldMaterial;
			}
		}

		[Token(Token = "0x600132B")]
		[Address(RVA = "0x3CE6AE8", Offset = "0x3CE6AE8", Length = "0xF4")]
		public MoldMaterialSet GetMoldMaterials(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldConceptConfig::GetMoldMaterials");
			return default;
		}

		[Token(Token = "0x600132C")]
		[Address(RVA = "0x3CE6BDC", Offset = "0x3CE6BDC", Length = "0x184")]
		public Color GetFillColor(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldConceptConfig::GetFillColor");
			return default;
		}

		[Token(Token = "0x600132E")]
		[Address(RVA = "0x3CE6D68", Offset = "0x3CE6D68", Length = "0x8")]
		public MoldConceptConfig()
		{
		}
	}
}
