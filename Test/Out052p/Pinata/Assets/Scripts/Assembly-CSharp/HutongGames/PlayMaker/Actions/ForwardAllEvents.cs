using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D760", Offset = "0x75D760")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D760", Offset = "0x75D760")]
	[Token(Token = "0x200034C")]
	public class ForwardAllEvents : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C94A8", Offset = "0x7C94A8")]
		[Token(Token = "0x4001B08")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget forwardTo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C94E0", Offset = "0x7C94E0")]
		[Token(Token = "0x4001B09")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent[] exceptThese;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9518", Offset = "0x7C9518")]
		[Token(Token = "0x4001B0A")]
		[FieldOffset(Offset = "0x60")]
		public bool eatEvents;

		[Token(Token = "0x600107D")]
		[Address(RVA = "0xB77078", Offset = "0xB77078", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EE15C8]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022934]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v46);\n\tv46.target = 3;\n\tthis.forwardTo = v46;\n\t// 37 NewArr v55 @ X0_v12 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tgoto L_0038;\n\tv93 = *([v75 @ X8_v11+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0038;\n\tv102 = v75;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v102, v53, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0038:\n\tgoto L_0043;\n\tv104 = *([1EB5FD8]);\n\tv105 = *([v104 @ X8_v23]);\n\tv106 = \"il2cpp_codegen_initialize_method\"(v105, v53, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv109 = 0 | 1;\n\t*([20229DD]) = v109;\nL_0043:\n\tgoto L_004E;\n\tv129 = *([v110 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\t// 71 Jump @b30\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v110, v53, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv132 = HutongGames.PlayMaker.FsmEvent;\nL_004E:\n\tv136 = v135.<Finished>k__BackingField == 0;\n\tif (v136) goto L_0057;\n\t// 83 IsInst v157 @ X0_v19, typeof(HutongGames.PlayMaker.FsmEvent), v135.<Finished>k__BackingField (HutongGames.PlayMaker.FsmEvent)\nL_0057:\n\tv88 = v55.Length == 0;\n\tif (v88) goto L_0067;\n\tv55[0] = v135.<Finished>k__BackingField;\n\tthis.exceptThese = v55;\n\tthis.eatEvents = 1;\n\treturn;\n\tv73 = new System.NullReferenceException();\nL_0067:\n\tv92 = new System.IndexOutOfRangeException();\n\tgoto L_006C;\n\tv120 = new System.ArrayTypeMismatchException();\nL_006C:\n\tthrow v119;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmEventTarget fsmEventTarget = new FsmEventTarget();
			fsmEventTarget.target = FsmEventTarget.EventTarget.FSMComponent;
			forwardTo = fsmEventTarget;
			FsmEvent[] array = new FsmEvent[1];
			if (FsmEvent.Finished != null)
			{
				object obj = FsmEvent.Finished as FsmEvent;
			}
			if (array.Length != 0)
			{
				array[0] = FsmEvent.Finished;
				exceptThese = array;
				eatEvents = true;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600107E")]
		[Address(RVA = "0xB771C4", Offset = "0xB771C4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.exceptThese;\n\tv13 = this.exceptThese == 0;\n\tif (v13) goto L_0041;\n\tv25 = v10.Length < 1;\n\tif (v25) goto L_0041;\nL_0019:\n\tv123 = v79 < v10.Length;\n\tv97 = ~v123;\n\tif (v97) goto L_0055;\n\tv140 = v10[v79 @ X10_v5 (System.Int32)] == fsmEvent;\n\tif (v140) goto L_FFFFFFFF;\n\tv79 = v79 + 1;\n\tv33 = v79 < v10.Length;\n\tif (v33) goto L_0019;\nL_0041:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.forwardTo, fsmEvent);\n\tv129 = this.eatEvents == 0;\n\tv134 = ~v129;\nL_0052:\n\treturn returnVal2;\n\tgoto L_0052;\nL_0055:\n\tv145 = new System.IndexOutOfRangeException();\n\tthrow v145;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Event(FsmEvent fsmEvent)
		{
			FsmEvent[] array = exceptThese;
			if (exceptThese != null && array.Length >= 1)
			{
				int num = 0;
				do
				{
					if (num < array.Length)
					{
						if (array[num] != fsmEvent)
						{
							num++;
							continue;
						}
						return false;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num < array.Length);
			}
			Fsm.Event(forwardTo, fsmEvent);
			bool flag = !eatEvents;
			return !flag;
		}

		[Token(Token = "0x600107F")]
		[Address(RVA = "0xB77260", Offset = "0xB77260", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ForwardAllEvents()
		{
		}
	}
}
