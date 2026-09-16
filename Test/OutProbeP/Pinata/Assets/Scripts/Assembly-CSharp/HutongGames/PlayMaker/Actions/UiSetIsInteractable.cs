using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7612E0", Offset = "0x7612E0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7612E0", Offset = "0x7612E0")]
	[Token(Token = "0x20003DD")]
	public class UiSetIsInteractable : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D276C", Offset = "0x7D276C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D276C", Offset = "0x7D276C")]
		[Token(Token = "0x4001E27")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2804", Offset = "0x7D2804")]
		[Token(Token = "0x4001E28")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool isInteractable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D283C", Offset = "0x7D283C")]
		[Token(Token = "0x4001E29")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001E2A")]
		[FieldOffset(Offset = "0x68")]
		private Selectable _selectable;

		[Token(Token = "0x4001E2B")]
		[FieldOffset(Offset = "0x70")]
		private bool _originalState;

		[Token(Token = "0x6001330")]
		[Address(RVA = "0x982DC0", Offset = "0x982DC0", Length = "0x30")]
		public override void Reset()
		{
			gameObject = null;
			isInteractable = null;
			FsmBool fsmBool = false;
			resetOnExit = fsmBool;
		}

		[Token(Token = "0x6001331")]
		[Address(RVA = "0x982DF0", Offset = "0x982DF0", Length = "0x144")]
		public override void OnEnter()
		{
			//IL_0086: Expected O, but got I
			//IL_0063: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			object obj;
			Selectable selectable;
			if (ownerDefaultTarget != null)
			{
				Selectable component = ownerDefaultTarget.GetComponent<Selectable>();
				obj = (long)(IntPtr)this + 104L;
				_selectable = component;
				selectable = component;
			}
			else
			{
				obj = (long)(IntPtr)this + 104L;
				selectable = _selectable;
			}
			if (selectable != null && resetOnExit.Value)
			{
				object obj2 = obj;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v164 @ X8_v10+2B0] (should have been resolved before IL gen)");
				object obj4 = default(object);
				int originalState = (int)((long)(IntPtr)obj4 & 1L);
				_originalState = (byte)originalState != 0;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x6001332")]
		[Address(RVA = "0x982F34", Offset = "0x982F34", Length = "0xB4")]
		private void DoSetValue()
		{
			if (_selectable != null)
			{
				bool value = isInteractable.Value;
				_selectable.interactable = value;
			}
		}

		[Token(Token = "0x6001333")]
		[Address(RVA = "0x982FE8", Offset = "0x982FE8", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(_selectable == null) && resetOnExit.Value)
			{
				_selectable.interactable = _originalState;
			}
		}

		[Token(Token = "0x6001334")]
		[Address(RVA = "0x983094", Offset = "0x983094", Length = "0x8")]
		public UiSetIsInteractable()
		{
		}
	}
}
