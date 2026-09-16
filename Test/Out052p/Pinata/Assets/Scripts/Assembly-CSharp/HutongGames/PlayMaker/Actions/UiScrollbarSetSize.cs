using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7621E0", Offset = "0x7621E0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7621E0", Offset = "0x7621E0")]
	[Token(Token = "0x200040D")]
	public class UiScrollbarSetSize : ComponentAction<Scrollbar>
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D7668", Offset = "0x7D7668")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7668", Offset = "0x7D7668")]
		[Token(Token = "0x4001F21")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7700", Offset = "0x7D7700")]
		[Attribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D7700", Offset = "0x7D7700")]
		[Token(Token = "0x4001F22")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat value;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D7764", Offset = "0x7D7764")]
		[Token(Token = "0x4001F23")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetOnExit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D779C", Offset = "0x7D779C")]
		[Token(Token = "0x4001F24")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x4001F25")]
		[FieldOffset(Offset = "0x80")]
		private Scrollbar scrollbar;

		[Token(Token = "0x4001F26")]
		[FieldOffset(Offset = "0x88")]
		private float originalValue;

		[Token(Token = "0x600141A")]
		[Address(RVA = "0x981EE8", Offset = "0x981EE8", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			value = null;
			resetOnExit = null;
			gameObject = null;
		}

		[Token(Token = "0x600141B")]
		[Address(RVA = "0x981EF8", Offset = "0x981EF8", Length = "0xCC")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiScrollbarSetSize)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				this.scrollbar = cachedComponent;
			}
			if (resetOnExit.Value)
			{
				Scrollbar scrollbar = this.scrollbar;
				originalValue = scrollbar.size;
			}
			DoSetValue();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600141C")]
		[Address(RVA = "0x982074", Offset = "0x982074", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetValue();
		}

		[Token(Token = "0x600141D")]
		[Address(RVA = "0x981FC4", Offset = "0x981FC4", Length = "0xB0")]
		private void DoSetValue()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @98F770 (inside PEButtonScript::.ctor +0x14)");
		}

		[Token(Token = "0x600141E")]
		[Address(RVA = "0x982078", Offset = "0x982078", Length = "0xAC")]
		public override void OnExit()
		{
			if (!(scrollbar == null) && resetOnExit.Value)
			{
				scrollbar.size = originalValue;
			}
		}

		[Token(Token = "0x600141F")]
		[Address(RVA = "0x982124", Offset = "0x982124", Length = "0x50")]
		public UiScrollbarSetSize()
		{
		}
	}
}
