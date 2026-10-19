using System;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreGameKit.BaseLayer.Services;
using _game.CoreSystem.ConveyorSystem;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Serializable]
	[Token(Token = "0x2000699")]
	public class BaseLayerConveyorUpgradeElement : IBaseLayerIntroElement
	{
		[Token(Token = "0x4001681")]
		[FieldOffset(Offset = "0x10")]
		public string TargetFeatureId;

		[Token(Token = "0x4001682")]
		[FieldOffset(Offset = "0x18")]
		private ILevel _level;

		[Token(Token = "0x4001683")]
		[FieldOffset(Offset = "0x20")]
		private InputBlockService _inputBlockService;

		[Token(Token = "0x4001684")]
		[FieldOffset(Offset = "0x28")]
		private IDisposable _inputBlock;

		[Token(Token = "0x4001685")]
		[FieldOffset(Offset = "0x30")]
		private Sequence _sequence;

		[Token(Token = "0x4001686")]
		[FieldOffset(Offset = "0x40")]
		internal ConveyorController _controller;

		[Token(Token = "0x6001BFA")]
		[Address(RVA = "0x3D66524", Offset = "0x3D66524", Length = "0xB8")]
		public IBaseLayerIntroElement GetInstance()
		{
			BaseLayerConveyorUpgradeElement baseLayerConveyorUpgradeElement = (BaseLayerConveyorUpgradeElement)FormatterServices.GetUninitializedObject(typeof(BaseLayerConveyorUpgradeElement));
			baseLayerConveyorUpgradeElement.TargetFeatureId = "extra_space";
			baseLayerConveyorUpgradeElement.TargetFeatureId = TargetFeatureId;
			return baseLayerConveyorUpgradeElement;
		}

		[Token(Token = "0x6001BFB")]
		[Address(RVA = "0x3D665DC", Offset = "0x3D665DC", Length = "0x7C")]
		public BaseLayerConveyorUpgradeElement(string targetFeatureId)
		{
			TargetFeatureId = "extra_space";
			TargetFeatureId = targetFeatureId;
		}

		[Inject(false)]
		[Token(Token = "0x6001BFC")]
		[Address(RVA = "0x3D66658", Offset = "0x3D66658", Length = "0x34")]
		public void Initialize(ILevel level, InputBlockService inputBlockService)
		{
			_level = level;
			_inputBlockService = inputBlockService;
		}

		[Token(Token = "0x6001BFD")]
		[Address(RVA = "0x3D6668C", Offset = "0x3D6668C", Length = "0x8")]
		public void BindConveyor(ConveyorController controller)
		{
			_controller = controller;
		}

		[Token(Token = "0x6001BFE")]
		[Address(RVA = "0x3D66694", Offset = "0x3D66694", Length = "0x2D0")]
		public unsafe void Play(Action onComplete)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BaseLayerConveyorUpgradeElement::Play");
		}

		[Token(Token = "0x6001BFF")]
		[Address(RVA = "0x3D6696C", Offset = "0x3D6696C", Length = "0xBC")]
		public void Stop()
		{
			_sequence.Stop();
			if (_inputBlock != null)
			{
				_inputBlock.Dispose();
			}
			_inputBlock = null;
		}
	}
}
