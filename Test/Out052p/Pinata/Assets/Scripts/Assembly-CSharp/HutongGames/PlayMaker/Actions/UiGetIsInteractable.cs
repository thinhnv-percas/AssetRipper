using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761150", Offset = "0x761150")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761150", Offset = "0x761150")]
	[Token(Token = "0x20003D8")]
	public class UiGetIsInteractable : ComponentAction<Selectable>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D1F1C", Offset = "0x7D1F1C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1F1C", Offset = "0x7D1F1C")]
		[Token(Token = "0x4001DFD")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D1FB4", Offset = "0x7D1FB4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D1FB4", Offset = "0x7D1FB4")]
		[Token(Token = "0x4001DFE")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isInteractable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D2004", Offset = "0x7D2004")]
		[Token(Token = "0x4001DFF")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent isInteractableEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D203C", Offset = "0x7D203C")]
		[Token(Token = "0x4001E00")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent isNotInteractableEvent;

		[Token(Token = "0x4001E01")]
		[FieldOffset(Offset = "0x80")]
		private Selectable selectable;

		[Token(Token = "0x4001E02")]
		[FieldOffset(Offset = "0x88")]
		private bool originalState;

		[Token(Token = "0x6001318")]
		[Address(RVA = "0x9A5FB8", Offset = "0x9A5FB8", Length = "0xC")]
		public override void Reset()
		{
			gameObject = null;
			isInteractableEvent = null;
		}

		[Token(Token = "0x6001319")]
		[Address(RVA = "0x9A5FC4", Offset = "0x9A5FC4", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGetIsInteractable)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				selectable = cachedComponent;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x600131A")]
		[Address(RVA = "0x9A6050", Offset = "0x9A6050", Length = "0xDC")]
		private void DoGetValue()
		{
			//IL_00b3: Expected O, but got I
			if (!(selectable == null))
			{
				bool flag = selectable.IsInteractable();
				FsmBool fsmBool = isInteractable;
				fsmBool.value = flag;
				FsmEvent fsmEvent = ((!flag) ? isNotInteractableEvent : isInteractableEvent);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiGetIsInteractable)+30]");
				((Fsm)0).Event(fsmEvent);
			}
		}

		[Token(Token = "0x600131B")]
		[Address(RVA = "0x9A612C", Offset = "0x9A612C", Length = "0x50")]
		public UiGetIsInteractable()
		{
		}
	}
}
