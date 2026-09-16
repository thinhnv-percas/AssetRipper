using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761010", Offset = "0x761010")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761010", Offset = "0x761010")]
	[Token(Token = "0x20003D4")]
	public class UiLayoutElementSetValues : ComponentAction<LayoutElement>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1534", Offset = "0x7D1534")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1534", Offset = "0x7D1534")]
		[Token(Token = "0x4001DDC")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7D15CC", Offset = "0x7D15CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D15CC", Offset = "0x7D15CC")]
		[Token(Token = "0x4001DDD")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat minWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D162C", Offset = "0x7D162C")]
		[Token(Token = "0x4001DDE")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat minHeight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1664", Offset = "0x7D1664")]
		[Token(Token = "0x4001DDF")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat preferredWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D169C", Offset = "0x7D169C")]
		[Token(Token = "0x4001DE0")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat preferredHeight;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D16D4", Offset = "0x7D16D4")]
		[Token(Token = "0x4001DE1")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat flexibleWidth;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D170C", Offset = "0x7D170C")]
		[Token(Token = "0x4001DE2")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat flexibleHeight;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7D1744", Offset = "0x7D1744")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D1744", Offset = "0x7D1744")]
		[Token(Token = "0x4001DE3")]
		[FieldOffset(Offset = "0x98")]
		public bool everyFrame;

		[Token(Token = "0x4001DE4")]
		[FieldOffset(Offset = "0xA0")]
		private LayoutElement layoutElement;

		[Token(Token = "0x6001304")]
		[Address(RVA = "0x97DAA4", Offset = "0x97DAA4", Length = "0x128")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			minWidth = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			minHeight = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			preferredWidth = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			preferredHeight = fsmFloat4;
			FsmFloat fsmFloat5 = new FsmFloat();
			fsmFloat5.useVariable = true;
			flexibleWidth = fsmFloat5;
			FsmFloat fsmFloat6 = new FsmFloat();
			fsmFloat6.useVariable = true;
			flexibleHeight = fsmFloat6;
		}

		[Token(Token = "0x6001305")]
		[Address(RVA = "0x97DBCC", Offset = "0x97DBCC", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiLayoutElementSetValues)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				layoutElement = cachedComponent;
			}
			DoSetValues();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001306")]
		[Address(RVA = "0x97DE78", Offset = "0x97DE78", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValues();
		}

		[Token(Token = "0x6001307")]
		[Address(RVA = "0x97DC6C", Offset = "0x97DC6C", Length = "0x20C")]
		private void DoSetValues()
		{
			//IL_026b: Expected I, but got O
			//IL_027b: Expected O, but got I
			//IL_028b: Expected O, but got I
			while (!(this.layoutElement == null))
			{
				if (!minWidth.IsNone)
				{
					float value = minWidth.Value;
					this.layoutElement.minWidth = value;
				}
				if (!minHeight.IsNone)
				{
					float value2 = minHeight.Value;
					this.layoutElement.minHeight = value2;
				}
				if (!preferredWidth.IsNone)
				{
					float value3 = preferredWidth.Value;
					this.layoutElement.preferredWidth = value3;
				}
				if (!preferredHeight.IsNone)
				{
					float value4 = preferredHeight.Value;
					this.layoutElement.preferredHeight = value4;
				}
				if (!flexibleWidth.IsNone)
				{
					float value5 = flexibleWidth.Value;
					this.layoutElement.flexibleWidth = value5;
				}
				if (flexibleHeight.IsNone)
				{
					break;
				}
				LayoutElement layoutElement = this.layoutElement;
				float value6 = flexibleHeight.Value;
				IntPtr intPtr = (IntPtr)layoutElement;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v15 (Il2CppClass<UnityEngine.UI.LayoutElement>)+3D0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v15 (Il2CppClass<UnityEngine.UI.LayoutElement>)+3D8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v146 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6001308")]
		[Address(RVA = "0x97DE7C", Offset = "0x97DE7C", Length = "0x50")]
		public UiLayoutElementSetValues()
		{
		}
	}
}
