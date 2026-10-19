using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.Controller.Runtime.States.Behaviors
{
	[Serializable]
	[Token(Token = "0x20006D6")]
	public class DebugLogBehavior : IStateBehavior
	{
		[SerializeField]
		[Token(Token = "0x40016F5")]
		[FieldOffset(Offset = "0x10")]
		private string _enterMessage;

		[SerializeField]
		[Token(Token = "0x40016F6")]
		[FieldOffset(Offset = "0x18")]
		private string _exitMessage;

		[Token(Token = "0x6001CE5")]
		[Address(RVA = "0x3D726FC", Offset = "0x3D726FC", Length = "0xA4")]
		public void OnStateEnter()
		{
			string message = "[StateBehavior] " + _enterMessage;
			Debug.Log(message);
		}

		[Token(Token = "0x6001CE6")]
		[Address(RVA = "0x3D727A0", Offset = "0x3D727A0", Length = "0xA4")]
		public void OnStateExit()
		{
			string message = "[StateBehavior] " + _exitMessage;
			Debug.Log(message);
		}

		[Token(Token = "0x6001CE7")]
		[Address(RVA = "0x3D72844", Offset = "0x3D72844", Length = "0x88")]
		public DebugLogBehavior()
		{
			_enterMessage = "State entered";
			_exitMessage = "State exited";
		}
	}
}
