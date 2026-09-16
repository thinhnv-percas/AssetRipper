using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760980", Offset = "0x760980")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760980", Offset = "0x760980")]
	[Token(Token = "0x20003BF")]
	public class UiGetSelectedGameObject : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D0874", Offset = "0x7D0874")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D0874", Offset = "0x7D0874")]
		[Token(Token = "0x4001DB1")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject StoreGameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D08C4", Offset = "0x7D08C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D08C4", Offset = "0x7D08C4")]
		[Token(Token = "0x4001DB2")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent ObjectChangedEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D0914", Offset = "0x7D0914")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D0914", Offset = "0x7D0914")]
		[Token(Token = "0x4001DB3")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x4001DB4")]
		[FieldOffset(Offset = "0x68")]
		private GameObject lastGameObject;

		[Token(Token = "0x60012AD")]
		[Address(RVA = "0x9788BC", Offset = "0x9788BC", Length = "0xC")]
		public override void Reset()
		{
			StoreGameObject = null;
			everyFrame = false;
		}

		[Token(Token = "0x60012AE")]
		[Address(RVA = "0x9788C8", Offset = "0x9788C8", Length = "0x38")]
		public override void OnEnter()
		{
			GetCurrentSelectedGameObject();
			GameObject value = StoreGameObject.Value;
			lastGameObject = value;
		}

		[Token(Token = "0x60012AF")]
		[Address(RVA = "0x97898C", Offset = "0x97898C", Length = "0xDC")]
		public override void OnUpdate()
		{
			GetCurrentSelectedGameObject();
			GameObject value = StoreGameObject.Value;
			if (value != lastGameObject && ObjectChangedEvent != null)
			{
				Fsm.Event(ObjectChangedEvent);
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60012B0")]
		[Address(RVA = "0x978900", Offset = "0x978900", Length = "0x8C")]
		private void GetCurrentSelectedGameObject()
		{
			EventSystem current = EventSystem.current;
			StoreGameObject.Value = current.currentSelectedGameObject;
		}

		[Token(Token = "0x60012B1")]
		[Address(RVA = "0x978A68", Offset = "0x978A68", Length = "0x8")]
		public UiGetSelectedGameObject()
		{
		}
	}
}
