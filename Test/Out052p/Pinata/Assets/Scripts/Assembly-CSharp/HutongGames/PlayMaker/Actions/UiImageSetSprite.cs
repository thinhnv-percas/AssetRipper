using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7617E0", Offset = "0x7617E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7617E0", Offset = "0x7617E0")]
	[Token(Token = "0x20003ED")]
	public class UiImageSetSprite : ComponentAction<Image>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D3D7C", Offset = "0x7D3D7C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3D7C", Offset = "0x7D3D7C")]
		[Token(Token = "0x4001E7D")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3E14", Offset = "0x7D3E14")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D3E14", Offset = "0x7D3E14")]
		[Token(Token = "0x4001E7E")]
		[FieldOffset(Offset = "0x68")]
		public FsmObject sprite;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D3EAC", Offset = "0x7D3EAC")]
		[Token(Token = "0x4001E7F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001E80")]
		[FieldOffset(Offset = "0x78")]
		private Image image;

		[Token(Token = "0x4001E81")]
		[FieldOffset(Offset = "0x80")]
		private Sprite originalSprite;

		[Token(Token = "0x600137A")]
		[Address(RVA = "0x979A4C", Offset = "0x979A4C", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = false;
			resetOnExit = fsmBool;
		}

		[Token(Token = "0x600137B")]
		[Address(RVA = "0x979A7C", Offset = "0x979A7C", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiImageSetSprite)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Image image;
			if (UpdateCache(ownerDefaultTarget))
			{
				image = cachedComponent;
				this.image = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				image = this.image;
			}
			originalSprite = image.sprite;
			DoSetImageSourceValue();
			Finish();
		}

		[Token(Token = "0x600137C")]
		[Address(RVA = "0x979B28", Offset = "0x979B28", Length = "0xD4")]
		private void DoSetImageSourceValue()
		{
			if (!(image == null))
			{
				UnityEngine.Object value = this.sprite.Value;
				Sprite sprite;
				if ((object)value != null)
				{
					UnityEngine.Object obj = (((object)value.GetType() != typeof(Sprite)) ? null : value);
					sprite = (Sprite)obj;
				}
				else
				{
					sprite = null;
				}
				image.sprite = sprite;
			}
		}

		[Token(Token = "0x600137D")]
		[Address(RVA = "0x979BFC", Offset = "0x979BFC", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(image == null) && resetOnExit.Value)
			{
				image.sprite = originalSprite;
			}
		}

		[Token(Token = "0x600137E")]
		[Address(RVA = "0x979CA8", Offset = "0x979CA8", Length = "0x50")]
		public UiImageSetSprite()
		{
		}
	}
}
