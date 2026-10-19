using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States;
using _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors;
using _game.CoreGameKit.BaseLayer.Installers;

namespace _game.CoreGameKit.BaseLayer.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x200064F")]
	public class BaseLayerStartWithInputBehavior : IStateBehavior
	{
		[Token(Token = "0x40015A2")]
		[FieldOffset(Offset = "0x10")]
		private BaseLayerStateMachine _stateMachine;

		[Token(Token = "0x40015A3")]
		[FieldOffset(Offset = "0x18")]
		private BaseLayerState _runningState;

		[Token(Token = "0x40015A4")]
		[FieldOffset(Offset = "0x20")]
		private IInputProvider _inputProvider;

		[Inject(false)]
		[Token(Token = "0x6001ACA")]
		[Address(RVA = "0x3D56800", Offset = "0x3D56800", Length = "0x54")]
		public void Initialize(IInputProvider inputProvider, BaseLayerStateMachine stateMachine, BaseLayerRunningState runningState)
		{
			_stateMachine = stateMachine;
			_runningState = runningState;
			_inputProvider = inputProvider;
		}

		[Token(Token = "0x6001ACB")]
		[Address(RVA = "0x3D56854", Offset = "0x3D56854", Length = "0x4C")]
		public void OnStateUpdate()
		{
			if (Input.GetMouseButtonDown(0))
			{
				_stateMachine.SetState(_runningState);
			}
		}

		[Token(Token = "0x6001ACC")]
		[Address(RVA = "0x3D568A0", Offset = "0x3D568A0", Length = "0x8")]
		public BaseLayerStartWithInputBehavior()
		{
		}
	}
}
