using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E950", Offset = "0x75E950")]
	[Token(Token = "0x200036E")]
	public abstract class RunFSMAction : FsmStateAction
	{
		[Token(Token = "0x4001BB9")]
		[FieldOffset(Offset = "0x50")]
		protected internal Fsm runFsm;

		[Token(Token = "0x600110B")]
		[Address(RVA = "0xB24CFC", Offset = "0xB24CFC", Length = "0x8")]
		public override void Reset()
		{
			runFsm = null;
		}

		[Token(Token = "0x600110C")]
		[Address(RVA = "0xB24D04", Offset = "0xB24D04", Length = "0x40")]
		public override bool Event(FsmEvent fsmEvent)
		{
			if (runFsm != null && (fsmEvent.IsGlobal || fsmEvent.IsSystemEvent))
			{
				runFsm.Event(fsmEvent);
			}
			return false;
		}

		[Token(Token = "0x600110D")]
		[Address(RVA = "0xB24D44", Offset = "0xB24D44", Length = "0x6C")]
		public override void OnEnter()
		{
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_0095: Expected O, but got I
			if (runFsm != null)
			{
				runFsm.OnEnable();
				Fsm fsm = runFsm;
				if (!fsm.Started)
				{
					fsm.Start();
				}
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v2 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+510]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v2 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+518]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v39 @ X2_v1 (should have been resolved before IL gen)");
			}
			Finish();
		}

		[Token(Token = "0x600110E")]
		[Address(RVA = "0xB24DB0", Offset = "0xB24DB0", Length = "0x50")]
		public override void OnUpdate()
		{
			//IL_002f: Expected I, but got O
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			if (runFsm != null)
			{
				runFsm.Update();
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+510]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+518]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
			}
			Finish();
		}

		[Token(Token = "0x600110F")]
		[Address(RVA = "0xB24E00", Offset = "0xB24E00", Length = "0x50")]
		public override void OnFixedUpdate()
		{
			//IL_002f: Expected I, but got O
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			if (runFsm != null)
			{
				runFsm.FixedUpdate();
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+510]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+518]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
			}
			Finish();
		}

		[Token(Token = "0x6001110")]
		[Address(RVA = "0xB24E50", Offset = "0xB24E50", Length = "0x50")]
		public override void OnLateUpdate()
		{
			//IL_002f: Expected I, but got O
			//IL_003f: Expected O, but got I
			//IL_004f: Expected O, but got I
			if (runFsm != null)
			{
				runFsm.LateUpdate();
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+510]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X8_v1 (Il2CppClass<HutongGames.PlayMaker.Actions.RunFSMAction>)+518]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X2_v1 (should have been resolved before IL gen)");
			}
			Finish();
		}

		[Token(Token = "0x6001111")]
		[Address(RVA = "0xB24EA0", Offset = "0xB24EA0", Length = "0x28")]
		public override void DoTriggerEnter(Collider other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerEnter)
			{
				fsm.OnTriggerEnter(other);
			}
		}

		[Token(Token = "0x6001112")]
		[Address(RVA = "0xB24EC8", Offset = "0xB24EC8", Length = "0x28")]
		public override void DoTriggerStay(Collider other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerStay)
			{
				fsm.OnTriggerStay(other);
			}
		}

		[Token(Token = "0x6001113")]
		[Address(RVA = "0xB24EF0", Offset = "0xB24EF0", Length = "0x28")]
		public override void DoTriggerExit(Collider other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerExit)
			{
				fsm.OnTriggerExit(other);
			}
		}

		[Token(Token = "0x6001114")]
		[Address(RVA = "0xB24F18", Offset = "0xB24F18", Length = "0x28")]
		public override void DoCollisionEnter(Collision collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionEnter)
			{
				fsm.OnCollisionEnter(collisionInfo);
			}
		}

		[Token(Token = "0x6001115")]
		[Address(RVA = "0xB24F40", Offset = "0xB24F40", Length = "0x28")]
		public override void DoCollisionStay(Collision collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionStay)
			{
				fsm.OnCollisionStay(collisionInfo);
			}
		}

		[Token(Token = "0x6001116")]
		[Address(RVA = "0xB24F68", Offset = "0xB24F68", Length = "0x28")]
		public override void DoCollisionExit(Collision collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionExit)
			{
				fsm.OnCollisionExit(collisionInfo);
			}
		}

		[Token(Token = "0x6001117")]
		[Address(RVA = "0xB24F90", Offset = "0xB24F90", Length = "0x28")]
		public override void DoParticleCollision(GameObject other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleParticleCollision)
			{
				fsm.OnParticleCollision(other);
			}
		}

		[Token(Token = "0x6001118")]
		[Address(RVA = "0xB24FB8", Offset = "0xB24FB8", Length = "0x28")]
		public override void DoControllerColliderHit(ControllerColliderHit collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleControllerColliderHit)
			{
				fsm.OnControllerColliderHit(collisionInfo);
			}
		}

		[Token(Token = "0x6001119")]
		[Address(RVA = "0xB24FE0", Offset = "0xB24FE0", Length = "0x28")]
		public override void DoTriggerEnter2D(Collider2D other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerEnter2D)
			{
				fsm.OnTriggerEnter2D(other);
			}
		}

		[Token(Token = "0x600111A")]
		[Address(RVA = "0xB25008", Offset = "0xB25008", Length = "0x28")]
		public override void DoTriggerStay2D(Collider2D other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerStay2D)
			{
				fsm.OnTriggerStay2D(other);
			}
		}

		[Token(Token = "0x600111B")]
		[Address(RVA = "0xB25030", Offset = "0xB25030", Length = "0x28")]
		public override void DoTriggerExit2D(Collider2D other)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleTriggerExit2D)
			{
				fsm.OnTriggerExit2D(other);
			}
		}

		[Token(Token = "0x600111C")]
		[Address(RVA = "0xB25058", Offset = "0xB25058", Length = "0x28")]
		public override void DoCollisionEnter2D(Collision2D collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionEnter2D)
			{
				fsm.OnCollisionEnter2D(collisionInfo);
			}
		}

		[Token(Token = "0x600111D")]
		[Address(RVA = "0xB25080", Offset = "0xB25080", Length = "0x28")]
		public override void DoCollisionStay2D(Collision2D collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionStay2D)
			{
				fsm.OnCollisionStay2D(collisionInfo);
			}
		}

		[Token(Token = "0x600111E")]
		[Address(RVA = "0xB250A8", Offset = "0xB250A8", Length = "0x28")]
		public override void DoCollisionExit2D(Collision2D collisionInfo)
		{
			Fsm fsm = runFsm;
			if (fsm.HandleCollisionExit2D)
			{
				fsm.OnCollisionExit2D(collisionInfo);
			}
		}

		[Token(Token = "0x600111F")]
		[Address(RVA = "0xB250D0", Offset = "0xB250D0", Length = "0x1C")]
		public override void OnGUI()
		{
			Fsm fsm = runFsm;
			if (runFsm != null && fsm.HandleOnGUI)
			{
				runFsm.OnGUI();
			}
		}

		[Token(Token = "0x6001120")]
		[Address(RVA = "0xB250EC", Offset = "0xB250EC", Length = "0x14")]
		public override void OnExit()
		{
			if (runFsm != null)
			{
				runFsm.Stop();
			}
		}

		[Token(Token = "0x6001121")]
		[Address(RVA = "0xB25100", Offset = "0xB25100", Length = "0x1C")]
		protected virtual void CheckIfFinished()
		{
			Fsm fsm = runFsm;
			if (runFsm == null || fsm.Finished)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001122")]
		[Address(RVA = "0xB24CF4", Offset = "0xB24CF4", Length = "0x8")]
		protected internal RunFSMAction()
		{
		}
	}
}
