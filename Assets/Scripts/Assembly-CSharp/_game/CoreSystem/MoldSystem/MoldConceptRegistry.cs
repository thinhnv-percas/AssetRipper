using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.MoldSystem
{
	[CreateAssetMenu(menuName = "Game/Mold Concept Registry")]
	[Token(Token = "0x200049E")]
	public class MoldConceptRegistry : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x4000F44")]
		[FieldOffset(Offset = "0x18")]
		private MoldConceptConfig[] m_concepts;

		[SerializeField]
		[Token(Token = "0x4000F45")]
		[FieldOffset(Offset = "0x20")]
		private MoldConceptConfig m_defaultConcept;

		[Token(Token = "0x600132F")]
		[Address(RVA = "0x3CE6D70", Offset = "0x3CE6D70", Length = "0x108")]
		public MoldConceptConfig GetConcept(string conceptId)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldConceptRegistry::GetConcept");
			return default;
		}

		[Token(Token = "0x6001330")]
		[Address(RVA = "0x3CE6E78", Offset = "0x3CE6E78", Length = "0x8")]
		public MoldConceptRegistry()
		{
		}
	}
}
