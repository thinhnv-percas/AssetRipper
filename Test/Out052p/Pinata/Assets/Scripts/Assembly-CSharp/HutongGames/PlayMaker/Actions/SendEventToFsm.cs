using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Obsolete]
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EAD4", Offset = "0x75EAD4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EAD4", Offset = "0x75EAD4")]
	[Token(Token = "0x2000371")]
	public class SendEventToFsm : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001BC4")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAF9C", Offset = "0x7CAF9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAF9C", Offset = "0x7CAF9C")]
		[Token(Token = "0x4001BC5")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAFEC", Offset = "0x7CAFEC")]
		[Token(Token = "0x4001BC6")]
		[FieldOffset(Offset = "0x60")]
		public FsmString sendEvent;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CB028", Offset = "0x7CB028")]
		[Token(Token = "0x4001BC7")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat delay;

		[Token(Token = "0x4001BC8")]
		[FieldOffset(Offset = "0x70")]
		private bool requireReceiver;

		[Token(Token = "0x4001BC9")]
		[FieldOffset(Offset = "0x78")]
		private GameObject go;

		[Token(Token = "0x4001BCA")]
		[FieldOffset(Offset = "0x80")]
		private DelayedEvent delayedEvent;

		[Token(Token = "0x600112B")]
		[Address(RVA = "0xB27260", Offset = "0xB27260", Length = "0x10")]
		public override void Reset()
		{
			requireReceiver = false;
			gameObject = null;
			sendEvent = null;
		}

		[Token(Token = "0x600112C")]
		[Address(RVA = "0xB27270", Offset = "0xB27270", Length = "0x264")]
		public override void OnEnter()
		{
			if (!((go = Fsm.GetOwnerDefaultTarget(gameObject)) == null))
			{
				string value = fsmName.Value;
				PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(go, value);
				if (gameObjectFsm == null)
				{
					if (requireReceiver)
					{
						string text = go.name;
						string value2 = fsmName.Value;
						string text2 = "GameObject doesn't have FsmComponent: " + text + " " + value2;
						LogError(text2);
					}
					return;
				}
				float value3 = delay.Value;
				Fsm fsm = gameObjectFsm.Fsm;
				string value4 = sendEvent.Value;
				if (!((double)value3 < 0.001))
				{
					FsmEvent fsmEvent = FsmEvent.GetFsmEvent(value4);
					float value5 = delay.Value;
					DelayedEvent delayedEvent = fsm.DelayedEvent(fsmEvent, value5);
					this.delayedEvent = delayedEvent;
					return;
				}
				fsm.Event(value4);
			}
			Finish();
		}

		[Token(Token = "0x600112D")]
		[Address(RVA = "0xB274D4", Offset = "0xB274D4", Length = "0x40")]
		public override void OnUpdate()
		{
			if (DelayedEvent.WasSent(delayedEvent))
			{
				Finish();
			}
		}

		[Token(Token = "0x600112E")]
		[Address(RVA = "0xB27514", Offset = "0xB27514", Length = "0x8")]
		public SendEventToFsm()
		{
		}
	}
}
