using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760750", Offset = "0x760750")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760750", Offset = "0x760750")]
	[Token(Token = "0x20003B7")]
	public class UiCanvasGroupSetProperties : ComponentAction<CanvasGroup>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7CF818", Offset = "0x7CF818")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF818", Offset = "0x7CF818")]
		[Token(Token = "0x4001D71")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF8B0", Offset = "0x7CF8B0")]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CF8B0", Offset = "0x7CF8B0")]
		[Token(Token = "0x4001D72")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat alpha;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF904", Offset = "0x7CF904")]
		[Token(Token = "0x4001D73")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool interactable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF93C", Offset = "0x7CF93C")]
		[Token(Token = "0x4001D74")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool blocksRaycasts;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF974", Offset = "0x7CF974")]
		[Token(Token = "0x4001D75")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool ignoreParentGroup;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF9AC", Offset = "0x7CF9AC")]
		[Token(Token = "0x4001D76")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001D77")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x4001D78")]
		[FieldOffset(Offset = "0x98")]
		private CanvasGroup component;

		[Token(Token = "0x4001D79")]
		[FieldOffset(Offset = "0xA0")]
		private float originalAlpha;

		[Token(Token = "0x4001D7A")]
		[FieldOffset(Offset = "0xA4")]
		private bool originalInteractable;

		[Token(Token = "0x4001D7B")]
		[FieldOffset(Offset = "0xA5")]
		private bool originalBlocksRaycasts;

		[Token(Token = "0x4001D7C")]
		[FieldOffset(Offset = "0xA6")]
		private bool originalIgnoreParentGroup;

		[Token(Token = "0x6001289")]
		[Address(RVA = "0x9A36FC", Offset = "0x9A36FC", Length = "0xF0")]
		public override void Reset()
		{
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			alpha = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			interactable = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = true;
			blocksRaycasts = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = true;
			ignoreParentGroup = fsmBool3;
			resetOnExit = null;
			everyFrame = false;
		}

		[Token(Token = "0x600128A")]
		[Address(RVA = "0x9A37EC", Offset = "0x9A37EC", Length = "0x140")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiCanvasGroupSetProperties)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				component = cachedComponent;
				if (cachedComponent != null)
				{
					float num = component.alpha;
					originalAlpha = num;
					bool flag = component.interactable;
					originalInteractable = flag;
					bool flag2 = component.blocksRaycasts;
					originalBlocksRaycasts = flag2;
					bool ignoreParentGroups = component.ignoreParentGroups;
					originalIgnoreParentGroup = ignoreParentGroups;
				}
			}
			DoAction();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600128B")]
		[Address(RVA = "0x9A3AA4", Offset = "0x9A3AA4", Length = "0x4")]
		public override void OnUpdate()
		{
			DoAction();
		}

		[Token(Token = "0x600128C")]
		[Address(RVA = "0x9A392C", Offset = "0x9A392C", Length = "0x178")]
		private void DoAction()
		{
			if (!(component == null))
			{
				if (!alpha.IsNone)
				{
					float value = alpha.Value;
					component.alpha = value;
				}
				if (!interactable.IsNone)
				{
					bool value2 = interactable.Value;
					component.interactable = value2;
				}
				if (!blocksRaycasts.IsNone)
				{
					bool value3 = blocksRaycasts.Value;
					component.blocksRaycasts = value3;
				}
				if (!ignoreParentGroup.IsNone)
				{
					bool value4 = ignoreParentGroup.Value;
					component.ignoreParentGroups = value4;
				}
			}
		}

		[Token(Token = "0x600128D")]
		[Address(RVA = "0x9A3AA8", Offset = "0x9A3AA8", Length = "0x138")]
		public override void OnExit()
		{
			if (!(component == null) && resetOnExit.Value)
			{
				if (!alpha.IsNone)
				{
					component.alpha = originalAlpha;
				}
				if (!interactable.IsNone)
				{
					component.interactable = originalInteractable;
				}
				if (!blocksRaycasts.IsNone)
				{
					component.blocksRaycasts = originalBlocksRaycasts;
				}
				if (!ignoreParentGroup.IsNone)
				{
					component.ignoreParentGroups = originalIgnoreParentGroup;
				}
			}
		}

		[Token(Token = "0x600128E")]
		[Address(RVA = "0x9A3BE0", Offset = "0x9A3BE0", Length = "0x50")]
		public UiCanvasGroupSetProperties()
		{
		}
	}
}
