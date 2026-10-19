using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.ContainerSystem.Runtime;
using _game.Systems.Offers;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Token(Token = "0x20006DB")]
	public class IntroOfferBehavior : IStateBehavior
	{
		[Inject(false)]
		[Token(Token = "0x40016FA")]
		[FieldOffset(Offset = "0x10")]
		private OfferService _offerService;

		[Inject(false)]
		[Token(Token = "0x40016FB")]
		[FieldOffset(Offset = "0x18")]
		private Instancer _instancer;

		[Token(Token = "0x6001CF4")]
		[Address(RVA = "0x3D72A5C", Offset = "0x3D72A5C", Length = "0x28")]
		public void OnStateEnter()
		{
			bool flag = _offerService.TryShowNext(_instancer);
		}

		[Token(Token = "0x6001CF5")]
		[Address(RVA = "0x3D72A84", Offset = "0x3D72A84", Length = "0x8")]
		public IntroOfferBehavior()
		{
		}
	}
}
