using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.GameBootstrap.Core;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Token(Token = "0x2000652")]
	public class BaseLayerExitService : IBaseLayerExitService
	{
		[Inject(false)]
		[Token(Token = "0x40015B6")]
		[FieldOffset(Offset = "0x10")]
		private GameStateController _gameStateController;

		[Token(Token = "0x6001AD3")]
		[Address(RVA = "0x3D57318", Offset = "0x3D57318", Length = "0x1C")]
		public void Exit()
		{
			_gameStateController.SwitchToMenuLayer();
		}

		[Token(Token = "0x6001AD4")]
		[Address(RVA = "0x3D57334", Offset = "0x3D57334", Length = "0x8")]
		public BaseLayerExitService()
		{
		}
	}
}
