using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762870", Offset = "0x762870")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762870", Offset = "0x762870")]
	[Token(Token = "0x2000422")]
	public class GetComponent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D92EC", Offset = "0x7D92EC")]
		[Token(Token = "0x4001F94")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D9324", Offset = "0x7D9324")]
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D9324", Offset = "0x7D9324")]
		[Token(Token = "0x4001F95")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject storeComponent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D9384", Offset = "0x7D9384")]
		[Token(Token = "0x4001F96")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x600148A")]
		[Address(RVA = "0xA2A278", Offset = "0xA2A278", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			storeComponent = null;
		}

		[Token(Token = "0x600148B")]
		[Address(RVA = "0xA2A284", Offset = "0xA2A284", Length = "0x3C")]
		public override void OnEnter()
		{
			DoGetComponent();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600148C")]
		[Address(RVA = "0xA2A3AC", Offset = "0xA2A3AC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetComponent();
		}

		[Token(Token = "0x600148D")]
		[Address(RVA = "0xA2A2C0", Offset = "0xA2A2C0", Length = "0xEC")]
		private void DoGetComponent()
		{
			if (storeComponent != null)
			{
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				if (!(ownerDefaultTarget == null) && !storeComponent.IsNone)
				{
					FsmObject fsmObject = storeComponent;
					Type objectType = storeComponent.ObjectType;
					Component component = ownerDefaultTarget.GetComponent(objectType);
					fsmObject.Value = component;
				}
			}
		}

		[Token(Token = "0x600148E")]
		[Address(RVA = "0xA2A3B0", Offset = "0xA2A3B0", Length = "0x8")]
		public GetComponent()
		{
		}
	}
}
