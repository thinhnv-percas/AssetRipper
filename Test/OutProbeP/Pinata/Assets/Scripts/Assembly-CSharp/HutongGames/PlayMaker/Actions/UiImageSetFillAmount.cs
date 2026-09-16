using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761790", Offset = "0x761790")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761790", Offset = "0x761790")]
	[Token(Token = "0x20003EC")]
	public class UiImageSetFillAmount : ComponentAction<Image>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3C48", Offset = "0x7D3C48")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3C48", Offset = "0x7D3C48")]
		[Token(Token = "0x4001E79")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D3CE0", Offset = "0x7D3CE0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3CE0", Offset = "0x7D3CE0")]
		[Token(Token = "0x4001E7A")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat ImageFillAmount;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3D44", Offset = "0x7D3D44")]
		[Token(Token = "0x4001E7B")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001E7C")]
		[FieldOffset(Offset = "0x78")]
		private Image image;

		[Token(Token = "0x6001375")]
		[Address(RVA = "0x979874", Offset = "0x979874", Length = "0x34")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat imageFillAmount = 1f;
			ImageFillAmount = imageFillAmount;
			everyFrame = false;
		}

		[Token(Token = "0x6001376")]
		[Address(RVA = "0x9798A8", Offset = "0x9798A8", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiImageSetFillAmount)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				image = cachedComponent;
			}
			DoSetFillAmount();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001377")]
		[Address(RVA = "0x9799F8", Offset = "0x9799F8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFillAmount();
		}

		[Token(Token = "0x6001378")]
		[Address(RVA = "0x979948", Offset = "0x979948", Length = "0xB0")]
		private void DoSetFillAmount()
		{
			if (image != null)
			{
				float value = ImageFillAmount.Value;
				image.fillAmount = value;
			}
		}

		[Token(Token = "0x6001379")]
		[Address(RVA = "0x9799FC", Offset = "0x9799FC", Length = "0x50")]
		public UiImageSetFillAmount()
		{
		}
	}
}
