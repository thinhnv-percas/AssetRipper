using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.BoosterSystem.MoldSwap.Core;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.PlayMode.Debug
{
	[Token(Token = "0x200047F")]
	public class MoldSwapTester : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000E8D")]
		[FieldOffset(Offset = "0x20")]
		private bool m_alwaysSwapOverride;

		[Inject(false)]
		[Token(Token = "0x4000E8E")]
		[FieldOffset(Offset = "0x28")]
		private MoldSwapScorer _scorer;

		[Inject(false)]
		[Token(Token = "0x4000E8F")]
		[FieldOffset(Offset = "0x30")]
		private MoldSwapController _controller;

		[Inject(false)]
		[Token(Token = "0x4000E90")]
		[FieldOffset(Offset = "0x38")]
		private EntityManager _em;

		[Token(Token = "0x60012A4")]
		[Address(RVA = "0x3CD72F0", Offset = "0x3CD72F0", Length = "0x10")]
		public MoldSwapTester()
		{
			m_alwaysSwapOverride = true;
		}
	}
}
