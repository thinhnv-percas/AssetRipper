using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.AppLayerInstaller;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000694")]
	public class BaseLayerWinRateUsPopupElement : IBaseLayerUiActionElement
	{
		[Inject(true)]
		[Token(Token = "0x4001675")]
		[FieldOffset(Offset = "0x10")]
		private RateUsController _rateUsController;

		[Token(Token = "0x6001BE5")]
		[Address(RVA = "0x3D65B48", Offset = "0x3D65B48", Length = "0x58")]
		public IBaseLayerUiActionElement GetInstance()
		{
			return new BaseLayerWinRateUsPopupElement();
		}

		[Token(Token = "0x6001BE6")]
		[Address(RVA = "0x3D65BA8", Offset = "0x3D65BA8", Length = "0x4C")]
		public void Play(Action onComplete)
		{
			if (_rateUsController != null)
			{
				_rateUsController.TriggerLocation(default(ShowLocation));
			}
			onComplete?.Invoke();
		}

		[Token(Token = "0x6001BE7")]
		[Address(RVA = "0x3D65BF4", Offset = "0x3D65BF4", Length = "0x4")]
		public void Stop()
		{
		}

		[Token(Token = "0x6001BE8")]
		[Address(RVA = "0x3D65BA0", Offset = "0x3D65BA0", Length = "0x8")]
		public BaseLayerWinRateUsPopupElement()
		{
		}
	}
}
