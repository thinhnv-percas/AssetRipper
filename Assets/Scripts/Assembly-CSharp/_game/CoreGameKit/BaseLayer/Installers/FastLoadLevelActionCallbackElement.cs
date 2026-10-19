using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Services.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000693")]
	public class FastLoadLevelActionCallbackElement : IBaseLayerUiActionElement
	{
		[Inject(false)]
		[Token(Token = "0x4001674")]
		[FieldOffset(Offset = "0x10")]
		private IBaseLayerCompleteService _completeService;

		[Token(Token = "0x6001BE1")]
		[Address(RVA = "0x3D65A0C", Offset = "0x3D65A0C", Length = "0x58")]
		public IBaseLayerUiActionElement GetInstance()
		{
			return new FastLoadLevelActionCallbackElement();
		}

		[Token(Token = "0x6001BE2")]
		[Address(RVA = "0x3D65A6C", Offset = "0x3D65A6C", Length = "0xD8")]
		public void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FastLoadLevelActionCallbackElement::Play");
		}

		[Token(Token = "0x6001BE3")]
		[Address(RVA = "0x3D65B44", Offset = "0x3D65B44", Length = "0x4")]
		public void Stop()
		{
		}

		[Token(Token = "0x6001BE4")]
		[Address(RVA = "0x3D65A64", Offset = "0x3D65A64", Length = "0x8")]
		public FastLoadLevelActionCallbackElement()
		{
		}
	}
}
