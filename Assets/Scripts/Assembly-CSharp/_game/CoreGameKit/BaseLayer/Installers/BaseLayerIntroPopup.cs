using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000691")]
	public class BaseLayerIntroPopup : IBaseLayerIntroElement
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000692")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4001672")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4001673")]
			public static Action<BaseLayerIntroPopup> _003C_003E9__5_0;

			[Token(Token = "0x6001BDE")]
			[Address(RVA = "0x3D65974", Offset = "0x3D65974", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001BDF")]
			[Address(RVA = "0x3D659D8", Offset = "0x3D659D8", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal void _003CPlay_003Eb__5_0(BaseLayerIntroPopup t)
			{
				if (t._onComplete != null)
				{
					t._onComplete();
				}
			}
		}

		[Token(Token = "0x400166F")]
		[FieldOffset(Offset = "0x10")]
		private ILevel _level;

		[Token(Token = "0x4001670")]
		[FieldOffset(Offset = "0x18")]
		private Tween _tween;

		[Token(Token = "0x4001671")]
		[FieldOffset(Offset = "0x28")]
		private Action _onComplete;

		[Token(Token = "0x6001BD9")]
		[Address(RVA = "0x3D65774", Offset = "0x3D65774", Length = "0x58")]
		public IBaseLayerIntroElement GetInstance()
		{
			return new BaseLayerIntroPopup();
		}

		[Inject(false)]
		[Token(Token = "0x6001BDA")]
		[Address(RVA = "0x3D657D4", Offset = "0x3D657D4", Length = "0x4")]
		public void Initialize()
		{
		}

		[Token(Token = "0x6001BDB")]
		[Address(RVA = "0x3D657D8", Offset = "0x3D657D8", Length = "0x168")]
		public void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerIntroPopup::Play");
		}

		[Token(Token = "0x6001BDC")]
		[Address(RVA = "0x3D65940", Offset = "0x3D65940", Length = "0x34")]
		public void Stop()
		{
			_tween.Stop();
			_onComplete = null;
		}

		[Token(Token = "0x6001BDD")]
		[Address(RVA = "0x3D657CC", Offset = "0x3D657CC", Length = "0x8")]
		public BaseLayerIntroPopup()
		{
		}
	}
}
