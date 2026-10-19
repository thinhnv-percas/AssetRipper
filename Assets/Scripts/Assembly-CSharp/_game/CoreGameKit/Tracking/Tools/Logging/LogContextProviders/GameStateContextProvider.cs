using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;

namespace _game.CoreGameKit.Tracking.Tools.Logging.LogContextProviders
{
	[Token(Token = "0x2000594")]
	public class GameStateContextProvider : ILogContextProvider
	{
		[Token(Token = "0x400133D")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerStateMachine _stateMachine;

		[Inject(false)]
		[Token(Token = "0x60017AC")]
		[Address(RVA = "0x3D2F86C", Offset = "0x3D2F86C", Length = "0x8")]
		private void Construct(BaseLayerStateMachine stateMachine = null)
		{
			_stateMachine = stateMachine;
		}

		[Token(Token = "0x60017AD")]
		[Address(RVA = "0x3D2F874", Offset = "0x3D2F874", Length = "0x1AC")]
		public string GetContext()
		{
			BaseLayerStateMachine stateMachine = _stateMachine;
			if (_stateMachine != null)
			{
				string text;
				if (stateMachine.CurrentState != null)
				{
					Type type = stateMachine.CurrentState.GetType();
					if ((object)type == null)
					{
						NullReferenceException ex = new NullReferenceException();
						throw ex;
					}
					string name = type.Name;
					text = name;
				}
				else
				{
					text = "None";
				}
				return "{\"currentState\": \"" + text + "\"}";
			}
			return "{\"state\": \"StateMachine not available\"}";
		}

		[Token(Token = "0x60017AE")]
		[Address(RVA = "0x3D2FA20", Offset = "0x3D2FA20", Length = "0x8")]
		public GameStateContextProvider()
		{
		}
	}
}
