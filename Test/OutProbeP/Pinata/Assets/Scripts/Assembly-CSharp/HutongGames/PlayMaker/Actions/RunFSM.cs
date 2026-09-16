using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E900", Offset = "0x75E900")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E900", Offset = "0x75E900")]
	[Token(Token = "0x200036D")]
	public class RunFSM : RunFSMAction
	{
		[Token(Token = "0x4001BB6")]
		[FieldOffset(Offset = "0x58")]
		public FsmTemplateControl fsmTemplateControl;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAD20", Offset = "0x7CAD20")]
		[Token(Token = "0x4001BB7")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt storeID;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAD34", Offset = "0x7CAD34")]
		[Token(Token = "0x4001BB8")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent finishEvent;

		[Token(Token = "0x6001106")]
		[Address(RVA = "0xB24A6C", Offset = "0xB24A6C", Length = "0x64")]
		public override void Reset()
		{
			FsmTemplateControl fsmTemplateControl = new FsmTemplateControl();
			runFsm = null;
			this.fsmTemplateControl = fsmTemplateControl;
			storeID = null;
		}

		[Token(Token = "0x6001107")]
		[Address(RVA = "0xB24AD0", Offset = "0xB24AD0", Length = "0xAC")]
		public override void Awake()
		{
			FsmTemplateControl fsmTemplateControl = this.fsmTemplateControl;
			if (fsmTemplateControl.fsmTemplate != null && Application.isPlaying)
			{
				Fsm fsm = Fsm.CreateSubFsm(this.fsmTemplateControl);
				runFsm = fsm;
			}
		}

		[Token(Token = "0x6001108")]
		[Address(RVA = "0xB24B7C", Offset = "0xB24B7C", Length = "0xB8")]
		public override void OnEnter()
		{
			//IL_00cb: Expected I, but got O
			//IL_00db: Expected O, but got I
			//IL_00eb: Expected O, but got I
			if (runFsm != null)
			{
				this.fsmTemplateControl.UpdateValues();
				this.fsmTemplateControl.ApplyOverrides(runFsm);
				runFsm.OnEnable();
				Fsm fsm = runFsm;
				if (!fsm.Started)
				{
					fsm.Start();
				}
				FsmTemplateControl fsmTemplateControl = this.fsmTemplateControl;
				FsmInt fsmInt = storeID;
				fsmInt.Value = fsmTemplateControl.ID;
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v6 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSM>)+510]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X8_v6 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSM>)+518]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v67 @ X2_v4 (should have been resolved before IL gen)");
			}
			Finish();
		}

		[Token(Token = "0x6001109")]
		[Address(RVA = "0xB24C34", Offset = "0xB24C34", Length = "0x58")]
		protected override void CheckIfFinished()
		{
			Fsm fsm = runFsm;
			if (runFsm == null || fsm.Finished)
			{
				Finish();
				Fsm.Event(finishEvent);
			}
		}

		[Token(Token = "0x600110A")]
		[Address(RVA = "0xB24C8C", Offset = "0xB24C8C", Length = "0x68")]
		public RunFSM()
		{
			FsmTemplateControl fsmTemplateControl = new FsmTemplateControl();
			this.fsmTemplateControl = fsmTemplateControl;
		}
	}
}
