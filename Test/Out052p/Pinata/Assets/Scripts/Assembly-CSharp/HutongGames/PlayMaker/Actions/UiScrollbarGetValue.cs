using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7620A0", Offset = "0x7620A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7620A0", Offset = "0x7620A0")]
	[Token(Token = "0x2000409")]
	public class UiScrollbarGetValue : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D70EC", Offset = "0x7D70EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D70EC", Offset = "0x7D70EC")]
		[Token(Token = "0x4001F0C")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D7184", Offset = "0x7D7184")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7184", Offset = "0x7D7184")]
		[Token(Token = "0x4001F0D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D71E4", Offset = "0x7D71E4")]
		[Token(Token = "0x4001F0E")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001F0F")]
		[FieldOffset(Offset = "0x78")]
		private Scrollbar scrollbar;

		[Token(Token = "0x6001405")]
		[Address(RVA = "0x981350", Offset = "0x981350", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			value = null;
		}

		[Token(Token = "0x6001406")]
		[Address(RVA = "0x98135C", Offset = "0x98135C", Length = "0xA0")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarGetValue)+30]");
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

		[Token(Token = "0x6001407")]
		[Address(RVA = "0x98149C", Offset = "0x98149C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetValue();
		}

		[Token(Token = "0x6001408")]
		[Address(RVA = "0x9813FC", Offset = "0x9813FC", Length = "0xA0")]
		private void DoGetValue()
		{
			if (scrollbar != null)
			{
				FsmFloat fsmFloat = value;
				float num = scrollbar.value;
				fsmFloat.Value = num;
			}
		}

		[Token(Token = "0x6001409")]
		[Address(RVA = "0x9814A0", Offset = "0x9814A0", Length = "0x50")]
		public UiScrollbarGetValue()
		{
		}
	}
}
