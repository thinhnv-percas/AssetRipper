using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761600", Offset = "0x761600")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761600", Offset = "0x761600")]
	[Token(Token = "0x20003E7")]
	public class UiGraphicCrossFadeColor : ComponentAction<Graphic>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D342C", Offset = "0x7D342C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D342C", Offset = "0x7D342C")]
		[Token(Token = "0x4001E5A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D34C4", Offset = "0x7D34C4")]
		[Token(Token = "0x4001E5B")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor color;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D34FC", Offset = "0x7D34FC")]
		[Token(Token = "0x4001E5C")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat red;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3534", Offset = "0x7D3534")]
		[Token(Token = "0x4001E5D")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat green;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D356C", Offset = "0x7D356C")]
		[Token(Token = "0x4001E5E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat blue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D35A4", Offset = "0x7D35A4")]
		[Token(Token = "0x4001E5F")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat alpha;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D35DC", Offset = "0x7D35DC")]
		[Token(Token = "0x4001E60")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3614", Offset = "0x7D3614")]
		[Token(Token = "0x4001E61")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool ignoreTimeScale;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D364C", Offset = "0x7D364C")]
		[Token(Token = "0x4001E62")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool useAlpha;

		[Token(Token = "0x4001E63")]
		[FieldOffset(Offset = "0xA8")]
		private Graphic uiComponent;

		[Token(Token = "0x600135E")]
		[Address(RVA = "0x978BE8", Offset = "0x978BE8", Length = "0xF8")]
		public override void Reset()
		{
			gameObject = null;
			color = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			red = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			green = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			blue = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			alpha = fsmFloat4;
			useAlpha = null;
			FsmFloat fsmFloat5 = 1f;
			duration = fsmFloat5;
			ignoreTimeScale = null;
		}

		[Token(Token = "0x600135F")]
		[Address(RVA = "0x978CE0", Offset = "0x978CE0", Length = "0x214")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGraphicCrossFadeColor)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Graphic graphic;
			if (UpdateCache(ownerDefaultTarget))
			{
				graphic = cachedComponent;
				uiComponent = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				graphic = uiComponent;
			}
			Color color = graphic.color;
			bool isNone = this.color.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = default(float);
			float a = num;
			float num2 = default(float);
			float b = num2;
			float num3 = default(float);
			float g = num3;
			Color color3 = default(Color);
			Color color2 = color3;
			if (!flag2)
			{
				FsmColor fsmColor = this.color;
				color2 = fsmColor.value;
				g = fsmColor.value.g;
				b = fsmColor.value.b;
				a = fsmColor.value.a;
			}
			bool isNone2 = red.IsNone;
			bool flag3 = !isNone2;
			bool flag4 = !flag3;
			float r = color2.r;
			if (!flag4)
			{
				float value = red.Value;
				r = value;
			}
			if (!green.IsNone)
			{
				float value2 = green.Value;
				g = value2;
			}
			if (!blue.IsNone)
			{
				float value3 = blue.Value;
				b = value3;
			}
			if (!alpha.IsNone)
			{
				float value4 = alpha.Value;
				a = value4;
			}
			float value5 = duration.Value;
			bool value6 = ignoreTimeScale.Value;
			bool value7 = useAlpha.Value;
			Color targetColor = default(Color);
			targetColor.r = r;
			targetColor.g = g;
			targetColor.b = b;
			targetColor.a = a;
			uiComponent.CrossFadeColor(targetColor, value5, value6, value7);
			Finish();
		}

		[Token(Token = "0x6001360")]
		[Address(RVA = "0x978EF4", Offset = "0x978EF4", Length = "0x50")]
		public UiGraphicCrossFadeColor()
		{
		}
	}
}
