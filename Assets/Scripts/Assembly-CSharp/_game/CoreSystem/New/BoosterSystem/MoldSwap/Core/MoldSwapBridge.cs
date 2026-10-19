using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Boosters;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreGameKit.CoreSerivces.BoosterSystem.Core;

namespace _game.CoreSystem.New.BoosterSystem.MoldSwap.Core
{
	[Token(Token = "0x2000485")]
	public class MoldSwapBridge : IDisposable
	{
		[Token(Token = "0x4000E9B")]
		private const string SwapMoldBoosterId = "swap_booster";

		[Inject(false)]
		[Token(Token = "0x4000E9C")]
		[FieldOffset(Offset = "0x10")]
		private MoldSwapController _controller;

		[Inject(true)]
		[Token(Token = "0x4000E9D")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerBoosterController _boosterController;

		[Inject(true)]
		[Token(Token = "0x4000E9E")]
		[FieldOffset(Offset = "0x20")]
		private IBoosterService _boosterService;

		[Inject(true)]
		[Token(Token = "0x4000E9F")]
		[FieldOffset(Offset = "0x28")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x4000EA0")]
		[FieldOffset(Offset = "0x30")]
		private IDisposable _inputBlock;

		[Token(Token = "0x4000EA1")]
		[FieldOffset(Offset = "0x38")]
		private bool _wired;

		[Inject(false)]
		[Token(Token = "0x60012B6")]
		[Address(RVA = "0x3CD879C", Offset = "0x3CD879C", Length = "0x168")]
		private void Construct()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapBridge::Construct");
		}

		[Token(Token = "0x60012B7")]
		[Address(RVA = "0x3CD89A8", Offset = "0x3CD89A8", Length = "0x1E4")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldSwapBridge::Dispose");
		}

		[Token(Token = "0x60012B8")]
		[Address(RVA = "0x3CD8C30", Offset = "0x3CD8C30", Length = "0x148")]
		private void OnBoosterUsed(string boosterId)
		{
			if (boosterId != "swap_booster")
			{
				return;
			}
			MoldSwapController controller = _controller;
			if (!controller.IsExecuting && controller.Execute())
			{
				if (_boosterService != null)
				{
					bool flag = _boosterService.UseBooster("swap_booster");
				}
				BaseLayerBoosterController boosterController = _boosterController;
				boosterController._activeBoosterId = "swap_booster";
				if (_inputBlockService != null)
				{
					IDisposable inputBlock = _inputBlockService.RequestBlock("swap_booster", InputChannel.BoosterButtons | InputChannel.CubeInteraction);
					_inputBlock = inputBlock;
				}
			}
		}

		[Token(Token = "0x60012B9")]
		[Address(RVA = "0x3CD97F0", Offset = "0x3CD97F0", Length = "0xDC")]
		private void OnSwapCompleted()
		{
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
			if (_boosterController != null)
			{
				_boosterController.ClearActiveBooster();
			}
		}

		[Token(Token = "0x60012BA")]
		[Address(RVA = "0x3CD7A8C", Offset = "0x3CD7A8C", Length = "0x8")]
		public MoldSwapBridge()
		{
		}
	}
}
