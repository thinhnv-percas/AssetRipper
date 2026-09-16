using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x761060", Offset = "0x761060")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x761060", Offset = "0x761060")]
	[Token(Token = "0x20003D5")]
	public class UiNavigationExplicitGetProperties : ComponentAction<Selectable>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D17A4", Offset = "0x7D17A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D17A4", Offset = "0x7D17A4")]
		[Token(Token = "0x4001DE5")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D183C", Offset = "0x7D183C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D183C", Offset = "0x7D183C")]
		[Token(Token = "0x4001DE6")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject selectOnDown;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D188C", Offset = "0x7D188C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D188C", Offset = "0x7D188C")]
		[Token(Token = "0x4001DE7")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject selectOnUp;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D18DC", Offset = "0x7D18DC")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D18DC", Offset = "0x7D18DC")]
		[Token(Token = "0x4001DE8")]
		[FieldOffset(Offset = "0x78")]
		public FsmGameObject selectOnLeft;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D192C", Offset = "0x7D192C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D192C", Offset = "0x7D192C")]
		[Token(Token = "0x4001DE9")]
		[FieldOffset(Offset = "0x80")]
		public FsmGameObject selectOnRight;

		[Token(Token = "0x4001DEA")]
		[FieldOffset(Offset = "0x88")]
		private Selectable _selectable;

		[Token(Token = "0x6001309")]
		[Address(RVA = "0x97DECC", Offset = "0x97DECC", Length = "0x10")]
		public override void Reset()
		{
			selectOnRight = null;
			gameObject = null;
			selectOnUp = null;
		}

		[Token(Token = "0x600130A")]
		[Address(RVA = "0x97DEDC", Offset = "0x97DEDC", Length = "0xC8")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiNavigationExplicitGetProperties)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null)
			{
				Selectable component = ownerDefaultTarget.GetComponent<Selectable>();
				_selectable = component;
			}
			DoGetValue();
			Finish();
		}

		[Token(Token = "0x600130B")]
		[Address(RVA = "0x97DFA4", Offset = "0x97DFA4", Length = "0x298")]
		private void DoGetValue()
		{
			if (!(_selectable != null))
			{
				return;
			}
			if (!selectOnUp.IsNone)
			{
				Selectable selectable = _selectable;
				bool flag = selectable.m_Navigation.selectOnUp == null;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				GameObject value = null;
				if (!flag3)
				{
					Selectable selectable2 = _selectable;
					GameObject gameObject = selectable2.m_Navigation.selectOnUp.gameObject;
					value = gameObject;
				}
				selectOnUp.Value = value;
			}
			if (!selectOnDown.IsNone)
			{
				Selectable selectable3 = _selectable;
				bool flag4 = selectable3.m_Navigation.selectOnDown == null;
				bool flag5 = !flag4;
				bool flag6 = !flag5;
				GameObject value2 = null;
				if (!flag6)
				{
					Selectable selectable4 = _selectable;
					GameObject gameObject2 = selectable4.m_Navigation.selectOnDown.gameObject;
					value2 = gameObject2;
				}
				selectOnDown.Value = value2;
			}
			if (!selectOnLeft.IsNone)
			{
				Selectable selectable5 = _selectable;
				bool flag7 = selectable5.m_Navigation.selectOnLeft == null;
				bool flag8 = !flag7;
				bool flag9 = !flag8;
				GameObject value3 = null;
				if (!flag9)
				{
					Selectable selectable6 = _selectable;
					GameObject gameObject3 = selectable6.m_Navigation.selectOnLeft.gameObject;
					value3 = gameObject3;
				}
				selectOnLeft.Value = value3;
			}
			if (!selectOnRight.IsNone)
			{
				Selectable selectable7 = _selectable;
				bool flag10 = selectable7.m_Navigation.selectOnRight == null;
				bool flag11 = !flag10;
				bool flag12 = !flag11;
				GameObject value4 = null;
				if (!flag12)
				{
					Selectable selectable8 = _selectable;
					GameObject gameObject4 = selectable8.m_Navigation.selectOnRight.gameObject;
					value4 = gameObject4;
				}
				selectOnRight.Value = value4;
			}
		}

		[Token(Token = "0x600130C")]
		[Address(RVA = "0x97E23C", Offset = "0x97E23C", Length = "0x50")]
		public UiNavigationExplicitGetProperties()
		{
		}
	}
}
