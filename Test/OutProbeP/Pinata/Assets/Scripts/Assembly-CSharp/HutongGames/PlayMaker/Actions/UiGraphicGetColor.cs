using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761650", Offset = "0x761650")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761650", Offset = "0x761650")]
	[Token(Token = "0x20003E8")]
	public class UiGraphicGetColor : ComponentAction<Graphic>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3684", Offset = "0x7D3684")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3684", Offset = "0x7D3684")]
		[Token(Token = "0x4001E64")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D371C", Offset = "0x7D371C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D371C", Offset = "0x7D371C")]
		[Token(Token = "0x4001E65")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor color;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D377C", Offset = "0x7D377C")]
		[Token(Token = "0x4001E66")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001E67")]
		[FieldOffset(Offset = "0x78")]
		private Graphic uiComponent;

		[Token(Token = "0x6001361")]
		[Address(RVA = "0x978F44", Offset = "0x978F44", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
			color = null;
		}

		[Token(Token = "0x6001362")]
		[Address(RVA = "0x978F4C", Offset = "0x978F4C", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGraphicGetColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				uiComponent = cachedComponent;
			}
			DoGetColorValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001363")]
		[Address(RVA = "0x979098", Offset = "0x979098", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetColorValue();
		}

		[Token(Token = "0x6001364")]
		[Address(RVA = "0x978FEC", Offset = "0x978FEC", Length = "0xAC")]
		private void DoGetColorValue()
		{
			if (uiComponent != null)
			{
				FsmColor fsmColor = this.color;
				Color color = uiComponent.color;
				Color value = default(Color);
				fsmColor.value = value;
				float g = default(float);
				fsmColor.value.g = g;
				float b = default(float);
				fsmColor.value.b = b;
				float a = default(float);
				fsmColor.value.a = a;
			}
		}

		[Token(Token = "0x6001365")]
		[Address(RVA = "0x97909C", Offset = "0x97909C", Length = "0x50")]
		public UiGraphicGetColor()
		{
		}
	}
}
