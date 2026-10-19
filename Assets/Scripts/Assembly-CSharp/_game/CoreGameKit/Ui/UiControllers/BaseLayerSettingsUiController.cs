using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.StateSystem.Runtime;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Installers;
using _game.CoreGameKit.UiControllers;

namespace _game.CoreGameKit.Ui.UiControllers
{
	[Token(Token = "0x200053D")]
	public class BaseLayerSettingsUiController : UIController
	{
		[Inject(true)]
		[Token(Token = "0x40011A7")]
		[FieldOffset(Offset = "0x48")]
		private IInputProvider _inputProvider;

		[Inject(false)]
		[Token(Token = "0x40011A8")]
		[FieldOffset(Offset = "0x50")]
		private BaseLayerStateMachine _stateMachine;

		[Token(Token = "0x40011A9")]
		[FieldOffset(Offset = "0x58")]
		private State _showState;

		[Inject(false)]
		[Token(Token = "0x60015F0")]
		[Address(RVA = "0x3D16DB0", Offset = "0x3D16DB0", Length = "0x140")]
		private void Construct(BaseLayerWaitState waitState)
		{
			if (_inputProvider != null)
			{
				_inputProvider.SetEnabled(b: false);
			}
			BaseLayerStateMachine stateMachine = _stateMachine;
			_showState = stateMachine.CurrentState;
			if (_showState != null)
			{
				BaseLayerReadyState baseLayerReadyState = _showState as BaseLayerReadyState;
				if (baseLayerReadyState != null)
				{
					return;
				}
			}
			_stateMachine.SetState(waitState);
		}

		[Token(Token = "0x60015F1")]
		[Address(RVA = "0x3D16EF0", Offset = "0x3D16EF0", Length = "0x110")]
		public override void Hide()
		{
			if (_inputProvider != null)
			{
				_inputProvider.SetEnabled(b: true);
			}
			if (_showState != null)
			{
				BaseLayerReadyState baseLayerReadyState = _showState as BaseLayerReadyState;
				if (baseLayerReadyState != null)
				{
					goto IL_0050;
				}
			}
			_stateMachine.SetState(_showState);
			goto IL_0050;
			IL_0050:
			base.Hide();
		}

		[Token(Token = "0x60015F2")]
		[Address(RVA = "0x3D17000", Offset = "0x3D17000", Length = "0x8")]
		public BaseLayerSettingsUiController()
		{
		}
	}
}
