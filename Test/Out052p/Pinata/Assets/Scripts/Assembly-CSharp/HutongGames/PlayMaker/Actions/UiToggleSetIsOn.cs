using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762820", Offset = "0x762820")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762820", Offset = "0x762820")]
	[Token(Token = "0x2000421")]
	public class UiToggleSetIsOn : ComponentAction<Toggle>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D91D0", Offset = "0x7D91D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D91D0", Offset = "0x7D91D0")]
		[Token(Token = "0x4001F8F")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9268", Offset = "0x7D9268")]
		[Token(Token = "0x4001F90")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool isOn;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D92B4", Offset = "0x7D92B4")]
		[Token(Token = "0x4001F91")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Token(Token = "0x4001F92")]
		[FieldOffset(Offset = "0x78")]
		private Toggle _toggle;

		[Token(Token = "0x4001F93")]
		[FieldOffset(Offset = "0x80")]
		private bool _originalValue;

		[Token(Token = "0x6001485")]
		[Address(RVA = "0x985674", Offset = "0x985674", Length = "0xC")]
		public override void Reset()
		{
			isOn = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x6001486")]
		[Address(RVA = "0x985680", Offset = "0x985680", Length = "0x8C")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiToggleSetIsOn)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				_toggle = cachedComponent;
			}
			DoSetValue();
			Finish();
		}

		[Token(Token = "0x6001487")]
		[Address(RVA = "0x98570C", Offset = "0x98570C", Length = "0xB8")]
		private void DoSetValue()
		{
			if (_toggle != null)
			{
				Toggle toggle = _toggle;
				_originalValue = toggle.isOn;
				bool value = isOn.Value;
				toggle.isOn = value;
			}
		}

		[Token(Token = "0x6001488")]
		[Address(RVA = "0x9857C4", Offset = "0x9857C4", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(_toggle == null) && resetOnExit.Value)
			{
				_toggle.isOn = _originalValue;
			}
		}

		[Token(Token = "0x6001489")]
		[Address(RVA = "0x985870", Offset = "0x985870", Length = "0x50")]
		public UiToggleSetIsOn()
		{
		}
	}
}
