using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7615B0", Offset = "0x7615B0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7615B0", Offset = "0x7615B0")]
	[Token(Token = "0x20003E6")]
	public class UiGraphicCrossFadeAlpha : ComponentAction<Graphic>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D32EC", Offset = "0x7D32EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D32EC", Offset = "0x7D32EC")]
		[Token(Token = "0x4001E55")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D3384", Offset = "0x7D3384")]
		[Token(Token = "0x4001E56")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat alpha;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D33BC", Offset = "0x7D33BC")]
		[Token(Token = "0x4001E57")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D33F4", Offset = "0x7D33F4")]
		[Token(Token = "0x4001E58")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool ignoreTimeScale;

		[Token(Token = "0x4001E59")]
		[FieldOffset(Offset = "0x80")]
		private Graphic uiComponent;

		[Token(Token = "0x600135B")]
		[Address(RVA = "0x978A70", Offset = "0x978A70", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			alpha = null;
			FsmFloat fsmFloat = 1f;
			duration = fsmFloat;
			ignoreTimeScale = null;
		}

		[Token(Token = "0x600135C")]
		[Address(RVA = "0x978AA0", Offset = "0x978AA0", Length = "0xF8")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGraphicCrossFadeAlpha)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			Graphic graphic;
			if (UpdateCache(ownerDefaultTarget))
			{
				graphic = cachedComponent;
				uiComponent = cachedComponent;
			}
			else
			{
				graphic = uiComponent;
			}
			float value = alpha.Value;
			float value2 = duration.Value;
			bool value3 = ignoreTimeScale.Value;
			graphic.CrossFadeAlpha(value, value2, value3);
			Finish();
		}

		[Token(Token = "0x600135D")]
		[Address(RVA = "0x978B98", Offset = "0x978B98", Length = "0x50")]
		public UiGraphicCrossFadeAlpha()
		{
		}
	}
}
