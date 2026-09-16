using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200004C")]
	public class DelayedEvent
	{
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x10")]
		private readonly Fsm fsm;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x18")]
		private readonly FsmEvent fsmEvent;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x20")]
		internal readonly FsmEventTarget eventTarget;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x28")]
		private FsmEventData eventData;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x30")]
		private float timer;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x34")]
		private float delay;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x38")]
		private bool eventFired;

		[Token(Token = "0x17000056")]
		public FsmEvent FsmEvent
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x9D7980", Offset = "0x9D7980", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.fsmEvent;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return FsmEvent;
			}
		}

		[Token(Token = "0x17000057")]
		public float Timer
		{
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x9D7988", Offset = "0x9D7988", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.timer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Timer;
			}
		}

		[Token(Token = "0x17000058")]
		public bool Finished
		{
			[Token(Token = "0x6000164")]
			[Address(RVA = "0x9D82D0", Offset = "0x9D82D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.eventFired;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Finished;
			}
		}

		[Token(Token = "0x600015B")]
		[Address(RVA = "0x9D7990", Offset = "0x9D7990", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EEB088]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, fsm, fsmEvent, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021A16]) = v47;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tthis.timer = delay;\n\tthis.delay = delay;\n\tthis.fsm = fsm;\n\tthis.fsmEvent = fsmEvent;\n\tgoto L_0032;\n\tv56 = *([v52 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0032;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v52, v49, fsmEvent, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\n\tv60 = HutongGames.PlayMaker.Fsm;\nL_0032:\n\tv68 = new HutongGames.PlayMaker.FsmEventData();\n\tHutongGames.PlayMaker.FsmEventData::.ctor(v68, v64.EventData);\n\tgoto L_0044;\n\tv79 = *([v75 @ X0_v7+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_0044;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v75, v70, v71, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\nL_0044:\n\tv87 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv68.SentByFsm = v87;\n\tv90 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv68.SentByState = v90;\n\tv94 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingAction();\n\tv68.SentByAction = v94;\n\tthis.eventData = v68;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(Fsm fsm, FsmEvent fsmEvent, float delay)
		{
			timer = delay;
			this.delay = delay;
			this.fsm = fsm;
			this.fsmEvent = fsmEvent;
			eventData = new FsmEventData(Fsm.EventData)
			{
				SentByFsm = FsmExecutionStack.ExecutingFsm,
				SentByState = FsmExecutionStack.ExecutingState,
				SentByAction = FsmExecutionStack.ExecutingAction
			};
		}

		[Token(Token = "0x600015C")]
		[Address(RVA = "0x9D7AA0", Offset = "0x9D7AA0", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EF8898]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, fsm, fsmEventName, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2021A17]) = v47;\nL_001F:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, fsm, fsmEventName, methodInfo, v34, v35, v36, v37, delay, v38, v39, v40, v41, v42, v43, v44);\nL_0027:\n\tv63 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(fsmEventName);\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(this, fsm, v63, delay);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(Fsm fsm, string fsmEventName, float delay)
			: this(fsm, FsmEvent.GetFsmEvent(fsmEventName), delay)
		{
		}

		[Token(Token = "0x600015D")]
		[Address(RVA = "0x9D7B38", Offset = "0x9D7B38", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(this, fsm, fsmEvent, delay);\n\tthis.eventTarget = eventTarget;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(Fsm fsm, FsmEventTarget eventTarget, FsmEvent fsmEvent, float delay)
			: this(fsm, fsmEvent, delay)
		{
			this.eventTarget = eventTarget;
		}

		[Token(Token = "0x600015E")]
		[Address(RVA = "0x9D7B64", Offset = "0x9D7B64", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(this, fsm, fsmEvent, delay);\n\tthis.eventTarget = eventTarget;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(Fsm fsm, FsmEventTarget eventTarget, string fsmEvent, float delay)
			: this(fsm, fsmEvent, delay)
		{
			this.eventTarget = eventTarget;
		}

		[Token(Token = "0x600015F")]
		[Address(RVA = "0x9D7B90", Offset = "0x9D7B90", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = PlayMakerFSM::get_Fsm(fsm);\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(this, v22, fsmEvent, delay);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(PlayMakerFSM fsm, FsmEvent fsmEvent, float delay)
			: this(fsm.Fsm, fsmEvent, delay)
		{
		}

		[Token(Token = "0x6000160")]
		[Address(RVA = "0x9D7BE4", Offset = "0x9D7BE4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = PlayMakerFSM::get_Fsm(fsm);\n\tHutongGames.PlayMaker.DelayedEvent::.ctor(this, v22, fsmEventName, delay);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DelayedEvent(PlayMakerFSM fsm, string fsmEventName, float delay)
			: this(fsm.Fsm, fsmEventName, delay)
		{
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x9D7C38", Offset = "0x9D7C38", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EBDC28]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021A18]) = v42;\nL_0017:\n\tv45 = UnityEngine.Time::get_deltaTime();\n\tv46 = this.timer - v45;\n\tthis.timer = v46;\n\tv56 = v46 >= 0;\n\tif (v56) goto L_0060;\n\tgoto L_0035;\n\tv85 = *([v59 @ X0_v4 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_0035;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v26, v27, v28, v29, v30, v31, v46, v33, v34, v35, v36, v37, v38, v39);\n\tv89 = HutongGames.PlayMaker.Fsm;\nL_0035:\n\tv92.EventData = this.eventData;\n\tv71 = this.eventTarget;\n\tv94 = this.fsm;\n\tv95 = this.eventTarget == 0;\n\tif (v95) goto L_0041;\n\tv112 = v94 == 0;\n\tv113 = ~v112;\n\tif (v113) goto L_0044;\n\tgoto L_0061;\nL_0041:\n\tv118 = this.fsmEvent == 0;\n\tif (v118) goto L_0048;\n\tv71 = v94.<EventTarget>k__BackingField;\nL_0044:\n\tHutongGames.PlayMaker.Fsm::Event(v94, v71, this.fsmEvent);\nL_0048:\n\tHutongGames.PlayMaker.Fsm::UpdateStateChanges(this.fsm);\n\tthis.eventFired = 1;\n\tthis.eventData = 0;\n\tgoto L_0058;\n\tv128 = *([v124 @ X0_v10 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_0058;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v124, v71, v64, v27, v28, v29, v30, v31, v46, v33, v34, v35, v36, v37, v38, v39);\n\tv131 = HutongGames.PlayMaker.Fsm;\nL_0058:\n\tv77.EventData = v92.EventData;\nL_0060:\n\treturn;\nL_0061:\n\tthrow System.NullReferenceException;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			float deltaTime = Time.deltaTime;
			if (!((timer = Timer - deltaTime) < 0f))
			{
				return;
			}
			Fsm.EventData = eventData;
			FsmEventTarget fsmEventTarget = eventTarget;
			Fsm fsm = this.fsm;
			if (eventTarget != null)
			{
				if (fsm == null)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				if (FsmEvent == null)
				{
					goto IL_0068;
				}
				fsmEventTarget = fsm.EventTarget;
			}
			fsm.Event(fsmEventTarget, FsmEvent);
			goto IL_0068;
			IL_0068:
			this.fsm.UpdateStateChanges();
			eventFired = true;
			eventData = null;
			Fsm.EventData = Fsm.EventData;
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x9D82A0", Offset = "0x9D82A0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.timer / this.delay;\n\treturnVal1 = 1f - v3;\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetProgress()
		{
			float num = Timer / delay;
			return 1f - num;
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x9D82B4", Offset = "0x9D82B4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = delayedEvent == 0;\n\tif (v0) goto L_0010;\n\tv7 = delayedEvent.eventFired == 0;\n\tv12 = ~v7;\n\treturn v12;\nL_0010:\n\treturn 1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool WasSent(DelayedEvent delayedEvent)
		{
			if (delayedEvent != null)
			{
				bool flag = !delayedEvent.Finished;
				return !flag;
			}
			return true;
		}
	}
}
