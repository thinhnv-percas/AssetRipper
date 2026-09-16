using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762050", Offset = "0x762050")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762050", Offset = "0x762050")]
	[Token(Token = "0x2000408")]
	public class UiScrollbarGetDirection : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6F70", Offset = "0x7D6F70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6F70", Offset = "0x7D6F70")]
		[Token(Token = "0x4001F08")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D7008", Offset = "0x7D7008")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D7008", Offset = "0x7D7008")]
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7D7008", Offset = "0x7D7008")]
		[Token(Token = "0x4001F09")]
		[FieldOffset(Offset = "0x68")]
		public FsmEnum direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D70B4", Offset = "0x7D70B4")]
		[Token(Token = "0x4001F0A")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F0B")]
		[FieldOffset(Offset = "0x78")]
		private Scrollbar scrollbar;

		[Token(Token = "0x6001400")]
		[Address(RVA = "0x98118C", Offset = "0x98118C", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			direction = null;
		}

		[Token(Token = "0x6001401")]
		[Address(RVA = "0x981198", Offset = "0x981198", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarGetDirection)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				scrollbar = cachedComponent;
			}
			DoGetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001402")]
		[Address(RVA = "0x9812FC", Offset = "0x9812FC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001403")]
		[Address(RVA = "0x981238", Offset = "0x981238", Length = "0xC4")]
		private void DoGetValue()
		{
			if (this.scrollbar != null)
			{
				Scrollbar scrollbar = this.scrollbar;
				Scrollbar.Direction direction = scrollbar.direction;
				Enum value = direction;
				this.direction.Value = value;
			}
		}

		[Token(Token = "0x6001404")]
		[Address(RVA = "0x981300", Offset = "0x981300", Length = "0x50")]
		public UiScrollbarGetDirection()
		{
		}
	}
}
