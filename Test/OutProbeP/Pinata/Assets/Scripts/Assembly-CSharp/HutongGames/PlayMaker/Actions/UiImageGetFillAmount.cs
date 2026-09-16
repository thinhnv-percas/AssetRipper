using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7616F0", Offset = "0x7616F0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7616F0", Offset = "0x7616F0")]
	[Token(Token = "0x20003EA")]
	public class UiImageGetFillAmount : ComponentAction<Image>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D39D4", Offset = "0x7D39D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D39D4", Offset = "0x7D39D4")]
		[Token(Token = "0x4001E72")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D3A6C", Offset = "0x7D3A6C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3A6C", Offset = "0x7D3A6C")]
		[Token(Token = "0x4001E73")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat ImageFillAmount;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3ACC", Offset = "0x7D3ACC")]
		[Token(Token = "0x4001E74")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001E75")]
		[FieldOffset(Offset = "0x78")]
		private Image image;

		[Token(Token = "0x600136C")]
		[Address(RVA = "0x979560", Offset = "0x979560", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			ImageFillAmount = null;
		}

		[Token(Token = "0x600136D")]
		[Address(RVA = "0x97956C", Offset = "0x97956C", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiImageGetFillAmount)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				image = cachedComponent;
			}
			DoGetFillAmount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600136E")]
		[Address(RVA = "0x9796A4", Offset = "0x9796A4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFillAmount();
		}

		[Token(Token = "0x600136F")]
		[Address(RVA = "0x97960C", Offset = "0x97960C", Length = "0x98")]
		private void DoGetFillAmount()
		{
			if (this.image != null)
			{
				Image image = this.image;
				FsmFloat imageFillAmount = ImageFillAmount;
				imageFillAmount.Value = image.fillAmount;
			}
		}

		[Token(Token = "0x6001370")]
		[Address(RVA = "0x9796A8", Offset = "0x9796A8", Length = "0x50")]
		public UiImageGetFillAmount()
		{
		}
	}
}
