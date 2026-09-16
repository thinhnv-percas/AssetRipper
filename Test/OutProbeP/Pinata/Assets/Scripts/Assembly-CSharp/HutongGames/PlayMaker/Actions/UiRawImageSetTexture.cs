using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761FB0", Offset = "0x761FB0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x761FB0", Offset = "0x761FB0")]
	[Token(Token = "0x2000406")]
	public class UiRawImageSetTexture : ComponentAction<RawImage>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6D84", Offset = "0x7D6D84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6D84", Offset = "0x7D6D84")]
		[Token(Token = "0x4001EFF")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6E1C", Offset = "0x7D6E1C")]
		[Token(Token = "0x4001F00")]
		[FieldOffset(Offset = "0x68")]
		public FsmTexture texture;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6E68", Offset = "0x7D6E68")]
		[Token(Token = "0x4001F01")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001F02")]
		[FieldOffset(Offset = "0x78")]
		private RawImage _texture;

		[Token(Token = "0x4001F03")]
		[FieldOffset(Offset = "0x80")]
		private Texture _originalTexture;

		[Token(Token = "0x60013F6")]
		[Address(RVA = "0x980504", Offset = "0x980504", Length = "0xC")]
		public override void Reset()
		{
			texture = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x60013F7")]
		[Address(RVA = "0x980510", Offset = "0x980510", Length = "0xAC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiRawImageSetTexture)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			RawImage rawImage;
			if (UpdateCache(ownerDefaultTarget))
			{
				rawImage = cachedComponent;
				_texture = cachedComponent;
				if ((object)cachedComponent == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				rawImage = _texture;
			}
			_originalTexture = rawImage.texture;
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x60013F8")]
		[Address(RVA = "0x9805BC", Offset = "0x9805BC", Length = "0xB4")]
		private void DoSetValue()
		{
			if (_texture != null)
			{
				Texture value = texture.Value;
				_texture.texture = value;
			}
		}

		[Token(Token = "0x60013F9")]
		[Address(RVA = "0x980670", Offset = "0x980670", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(_texture == null) && resetOnExit.Value)
			{
				_texture.texture = _originalTexture;
			}
		}

		[Token(Token = "0x60013FA")]
		[Address(RVA = "0x98071C", Offset = "0x98071C", Length = "0x50")]
		public UiRawImageSetTexture()
		{
		}
	}
}
