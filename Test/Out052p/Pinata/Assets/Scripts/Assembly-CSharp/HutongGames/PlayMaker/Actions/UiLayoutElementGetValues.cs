using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760FC0", Offset = "0x760FC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760FC0", Offset = "0x760FC0")]
	[Token(Token = "0x20003D3")]
	public class UiLayoutElementGetValues : ComponentAction<LayoutElement>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1008", Offset = "0x7D1008")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1008", Offset = "0x7D1008")]
		[Token(Token = "0x4001DCC")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7D10A0", Offset = "0x7D10A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D10A0", Offset = "0x7D10A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D10A0", Offset = "0x7D10A0")]
		[Token(Token = "0x4001DCD")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool ignoreLayout;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1114", Offset = "0x7D1114")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1114", Offset = "0x7D1114")]
		[Token(Token = "0x4001DCE")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool minWidthEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1164", Offset = "0x7D1164")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1164", Offset = "0x7D1164")]
		[Token(Token = "0x4001DCF")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat minWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D11B4", Offset = "0x7D11B4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D11B4", Offset = "0x7D11B4")]
		[Token(Token = "0x4001DD0")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool minHeightEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1204", Offset = "0x7D1204")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1204", Offset = "0x7D1204")]
		[Token(Token = "0x4001DD1")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat minHeight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1254", Offset = "0x7D1254")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1254", Offset = "0x7D1254")]
		[Token(Token = "0x4001DD2")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool preferredWidthEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D12A4", Offset = "0x7D12A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D12A4", Offset = "0x7D12A4")]
		[Token(Token = "0x4001DD3")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat preferredWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D12F4", Offset = "0x7D12F4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D12F4", Offset = "0x7D12F4")]
		[Token(Token = "0x4001DD4")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool preferredHeightEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1344", Offset = "0x7D1344")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1344", Offset = "0x7D1344")]
		[Token(Token = "0x4001DD5")]
		[FieldOffset(Offset = "0xA8")]
		public FsmFloat preferredHeight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1394", Offset = "0x7D1394")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1394", Offset = "0x7D1394")]
		[Token(Token = "0x4001DD6")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool flexibleWidthEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D13E4", Offset = "0x7D13E4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D13E4", Offset = "0x7D13E4")]
		[Token(Token = "0x4001DD7")]
		[FieldOffset(Offset = "0xB8")]
		public FsmFloat flexibleWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1434", Offset = "0x7D1434")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1434", Offset = "0x7D1434")]
		[Token(Token = "0x4001DD8")]
		[FieldOffset(Offset = "0xC0")]
		public FsmBool flexibleHeightEnabled;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1484", Offset = "0x7D1484")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D1484", Offset = "0x7D1484")]
		[Token(Token = "0x4001DD9")]
		[FieldOffset(Offset = "0xC8")]
		public FsmFloat flexibleHeight;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7D14D4", Offset = "0x7D14D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D14D4", Offset = "0x7D14D4")]
		[Token(Token = "0x4001DDA")]
		[FieldOffset(Offset = "0xD0")]
		public bool everyFrame;

		[Token(Token = "0x4001DDB")]
		[FieldOffset(Offset = "0xD8")]
		private LayoutElement layoutElement;

		[Token(Token = "0x60012FF")]
		[Address(RVA = "0x97D600", Offset = "0x97D600", Length = "0x20")]
		public override void Reset()
		{
			//IL_000c: Expected O, but got I
			object obj = (long)(IntPtr)this + 96L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6001300")]
		[Address(RVA = "0x97D620", Offset = "0x97D620", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiLayoutElementGetValues)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				layoutElement = cachedComponent;
			}
			DoGetValues();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001301")]
		[Address(RVA = "0x97DA50", Offset = "0x97DA50", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValues();
		}

		[Token(Token = "0x6001302")]
		[Address(RVA = "0x97D6C0", Offset = "0x97D6C0", Length = "0x390")]
		private void DoGetValues()
		{
			if (!(layoutElement == null))
			{
				if (!ignoreLayout.IsNone)
				{
					FsmBool fsmBool = ignoreLayout;
					bool value = layoutElement.ignoreLayout;
					fsmBool.value = value;
				}
				float num2 = default(float);
				if (!minWidthEnabled.IsNone)
				{
					FsmBool fsmBool2 = minWidthEnabled;
					float num = layoutElement.minWidth;
					bool flag = num2 == 0f;
					bool value2 = !flag;
					fsmBool2.value = value2;
				}
				if (!minWidth.IsNone)
				{
					FsmFloat fsmFloat = minWidth;
					float num3 = layoutElement.minWidth;
					fsmFloat.Value = num2;
				}
				if (!minHeightEnabled.IsNone)
				{
					FsmBool fsmBool3 = minHeightEnabled;
					float num4 = layoutElement.minHeight;
					bool flag2 = num2 == 0f;
					bool value3 = !flag2;
					fsmBool3.value = value3;
				}
				if (!minHeight.IsNone)
				{
					FsmFloat fsmFloat2 = minHeight;
					float num5 = layoutElement.minHeight;
					fsmFloat2.Value = num2;
				}
				if (!preferredWidthEnabled.IsNone)
				{
					FsmBool fsmBool4 = preferredWidthEnabled;
					float num6 = layoutElement.preferredWidth;
					bool flag3 = num2 == 0f;
					bool value4 = !flag3;
					fsmBool4.value = value4;
				}
				if (!preferredWidth.IsNone)
				{
					FsmFloat fsmFloat3 = preferredWidth;
					float num7 = layoutElement.preferredWidth;
					fsmFloat3.Value = num2;
				}
				if (!preferredHeightEnabled.IsNone)
				{
					FsmBool fsmBool5 = preferredHeightEnabled;
					float num8 = layoutElement.preferredHeight;
					bool flag4 = num2 == 0f;
					bool value5 = !flag4;
					fsmBool5.value = value5;
				}
				if (!preferredHeight.IsNone)
				{
					FsmFloat fsmFloat4 = preferredHeight;
					float num9 = layoutElement.preferredHeight;
					fsmFloat4.Value = num2;
				}
				if (!flexibleWidthEnabled.IsNone)
				{
					FsmBool fsmBool6 = flexibleWidthEnabled;
					float num10 = layoutElement.flexibleWidth;
					bool flag5 = num2 == 0f;
					bool value6 = !flag5;
					fsmBool6.value = value6;
				}
				if (!flexibleWidth.IsNone)
				{
					FsmFloat fsmFloat5 = flexibleWidth;
					float num11 = layoutElement.flexibleWidth;
					fsmFloat5.Value = num2;
				}
				if (!flexibleHeightEnabled.IsNone)
				{
					FsmBool fsmBool7 = flexibleHeightEnabled;
					float num12 = layoutElement.flexibleHeight;
					bool flag6 = num2 == 0f;
					bool value7 = !flag6;
					fsmBool7.value = value7;
				}
				if (!flexibleHeight.IsNone)
				{
					FsmFloat fsmFloat6 = flexibleHeight;
					float num13 = layoutElement.flexibleHeight;
					fsmFloat6.Value = num2;
				}
			}
		}

		[Token(Token = "0x6001303")]
		[Address(RVA = "0x97DA54", Offset = "0x97DA54", Length = "0x50")]
		public UiLayoutElementGetValues()
		{
		}
	}
}
