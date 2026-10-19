using System;
using Cpp2ILInjected;
using Reflex.Attributes;
using Unco.EventBusSystem.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils.UncoInput;

namespace _game.CoreGameKit.IntroScene
{
	[Serializable]
	[Token(Token = "0x20005F7")]
	public class UncoEventSystem
	{
		[Inject(false)]
		[Token(Token = "0x400148A")]
		[FieldOffset(Offset = "0x10")]
		private UncoStandaloneInputModule _inputModule;

		[Inject(false)]
		[Token(Token = "0x400148B")]
		[FieldOffset(Offset = "0x18")]
		private EventBus _eventBus;

		[Token(Token = "0x6001981")]
		[Address(RVA = "0x3D492F4", Offset = "0x3D492F4", Length = "0x1C")]
		public void Click(Vector2 data)
		{
			_inputModule.Click(data);
		}

		[Token(Token = "0x6001982")]
		[Address(RVA = "0x3D49310", Offset = "0x3D49310", Length = "0x1C")]
		public void ProcessTouchPress(PointerEventData data, bool pressed, bool released)
		{
			_inputModule.ProcessTouch(data, pressed, released);
		}

		[Token(Token = "0x6001983")]
		[Address(RVA = "0x3D46CEC", Offset = "0x3D46CEC", Length = "0x8")]
		public UncoEventSystem()
		{
		}
	}
}
