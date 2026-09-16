using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762000", Offset = "0x762000")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762000", Offset = "0x762000")]
	[Token(Token = "0x2000407")]
	public class UiRebuild : ComponentAction<Graphic>
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D6EA0", Offset = "0x7D6EA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6EA0", Offset = "0x7D6EA0")]
		[Token(Token = "0x4001F04")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[Token(Token = "0x4001F05")]
		[FieldOffset(Offset = "0x68")]
		public CanvasUpdate canvasUpdate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D6F38", Offset = "0x7D6F38")]
		[Token(Token = "0x4001F06")]
		[FieldOffset(Offset = "0x6C")]
		public bool rebuildOnExit;

		[Token(Token = "0x4001F07")]
		[FieldOffset(Offset = "0x70")]
		private Graphic graphic;

		[Token(Token = "0x60013FB")]
		[Address(RVA = "0x98076C", Offset = "0x98076C", Length = "0x14")]
		public override void Reset()
		{
			gameObject = null;
			canvasUpdate = CanvasUpdate.LatePreRender;
			rebuildOnExit = false;
		}

		[Token(Token = "0x60013FC")]
		[Address(RVA = "0x980780", Offset = "0x980780", Length = "0x94")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.UiRebuild)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (UpdateCache(ownerDefaultTarget))
			{
				graphic = cachedComponent;
			}
			if (!rebuildOnExit)
			{
				DoAction();
			}
			Finish();
		}

		[Token(Token = "0x60013FD")]
		[Address(RVA = "0x980814", Offset = "0x980814", Length = "0xA0")]
		private void DoAction()
		{
			//IL_0049: Expected I, but got O
			//IL_0063: Expected O, but got I
			//IL_0073: Expected O, but got I
			if (this.graphic != null)
			{
				Graphic graphic = this.graphic;
				IntPtr intPtr = (IntPtr)graphic;
				CanvasUpdate canvasUpdate = this.canvasUpdate;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+380]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X8_v7 (Il2CppClass<UnityEngine.UI.Graphic>)+388]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v69 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60013FE")]
		[Address(RVA = "0x9808B4", Offset = "0x9808B4", Length = "0x10")]
		public override void OnExit()
		{
			if (rebuildOnExit)
			{
				DoAction();
			}
		}

		[Token(Token = "0x60013FF")]
		[Address(RVA = "0x9808C4", Offset = "0x9808C4", Length = "0x50")]
		public UiRebuild()
		{
		}
	}
}
