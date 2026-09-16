using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761740", Offset = "0x761740")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761740", Offset = "0x761740")]
	[Token(Token = "0x20003EB")]
	public class UiImageGetSprite : ComponentAction<Image>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3B04", Offset = "0x7D3B04")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3B04", Offset = "0x7D3B04")]
		[Token(Token = "0x4001E76")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3B9C", Offset = "0x7D3B9C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D3B9C", Offset = "0x7D3B9C")]
		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D3B9C", Offset = "0x7D3B9C")]
		[Token(Token = "0x4001E77")]
		[FieldOffset(Offset = "0x68")]
		public FsmObject sprite;

		[Token(Token = "0x4001E78")]
		[FieldOffset(Offset = "0x70")]
		private Image image;

		[Token(Token = "0x6001371")]
		[Address(RVA = "0x9796F8", Offset = "0x9796F8", Length = "0x8")]
		public override void Reset()
		{
			gameObject = null;
			sprite = null;
		}

		[Token(Token = "0x6001372")]
		[Address(RVA = "0x979700", Offset = "0x979700", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiImageGetSprite)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				image = cachedComponent;
			}
			DoSetImageSourceValue();
			Finish();
		}

		[Token(Token = "0x6001373")]
		[Address(RVA = "0x97978C", Offset = "0x97978C", Length = "0x98")]
		private void DoSetImageSourceValue()
		{
			if (this.image != null)
			{
				Image image = this.image;
				FsmObject fsmObject = sprite;
				fsmObject.Value = image.sprite;
			}
		}

		[Token(Token = "0x6001374")]
		[Address(RVA = "0x979824", Offset = "0x979824", Length = "0x50")]
		public UiImageGetSprite()
		{
		}
	}
}
