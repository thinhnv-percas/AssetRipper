using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D7B0", Offset = "0x75D7B0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D7B0", Offset = "0x75D7B0")]
	[Token(Token = "0x200034D")]
	public class ForwardEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9550", Offset = "0x7C9550")]
		[Token(Token = "0x4001B0B")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget forwardTo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C9588", Offset = "0x7C9588")]
		[Token(Token = "0x4001B0C")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent[] eventsToForward;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C95C0", Offset = "0x7C95C0")]
		[Token(Token = "0x4001B0D")]
		[FieldOffset(Offset = "0x60")]
		public bool eatEvents;

		[Token(Token = "0x6001080")]
		[Address(RVA = "0xB77268", Offset = "0xB77268", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB4358]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022935]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmEventTarget();\n\tHutongGames.PlayMaker.FsmEventTarget::.ctor(v42);\n\tv42.target = 3;\n\tthis.forwardTo = v42;\n\tthis.eventsToForward = 0;\n\tthis.eatEvents = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmEventTarget fsmEventTarget = new FsmEventTarget();
			fsmEventTarget.target = FsmEventTarget.EventTarget.FSMComponent;
			forwardTo = fsmEventTarget;
			eventsToForward = null;
			eatEvents = true;
		}

		[Token(Token = "0x6001081")]
		[Address(RVA = "0xB772E4", Offset = "0xB772E4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.eventsToForward;\n\tv13 = this.eventsToForward == 0;\n\tif (v13) goto L_FFFFFFFF;\n\tv25 = v10.Length < 1;\n\tif (v25) goto L_FFFFFFFF;\nL_0019:\n\tv115 = v77 < v10.Length;\n\tv116 = ~v115;\n\tif (v116) goto L_0055;\n\tv163 = v10[v77 @ X10_v4 (System.Int32)] == fsmEvent;\n\tif (v163) goto L_0047;\n\tv77 = v77 + 1;\n\tv33 = v77 < v10.Length;\n\tif (v33) goto L_0019;\nL_0040:\n\treturn returnVal1;\nL_0047:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.forwardTo, fsmEvent);\n\tv89 = this.eatEvents == 0;\n\tv79 = ~v89;\n\tgoto L_0040;\nL_0055:\n\tv168 = new System.IndexOutOfRangeException();\n\tthrow v168;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Event(FsmEvent fsmEvent)
		{
			FsmEvent[] array = eventsToForward;
			if (eventsToForward != null && array.Length >= 1)
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
						Fsm.Event(forwardTo, fsmEvent);
						bool flag = !eatEvents;
						return !flag;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num < array.Length);
			}
			return false;
		}

		[Token(Token = "0x6001082")]
		[Address(RVA = "0xB77380", Offset = "0xB77380", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ForwardEvent()
		{
		}
	}
}
