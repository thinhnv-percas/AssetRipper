using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758E48", Offset = "0x758E48")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758E48", Offset = "0x758E48")]
	[Token(Token = "0x200026E")]
	public class IntCompare : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001655")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt integer1;

		[RequiredField]
		[Token(Token = "0x4001656")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt integer2;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B6D0C", Offset = "0x7B6D0C")]
		[Token(Token = "0x4001657")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent equal;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B6D44", Offset = "0x7B6D44")]
		[Token(Token = "0x4001658")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent lessThan;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B6D7C", Offset = "0x7B6D7C")]
		[Token(Token = "0x4001659")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent greaterThan;

		[Token(Token = "0x400165A")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000C1F")]
		[Address(RVA = "0xA383A4", Offset = "0xA383A4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.integer1 = v12;\n\tv15 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.everyFrame = 0;\n\tthis.integer2 = v15;\n\tthis.equal = 0;\n\tthis.lessThan = 0;\n\tthis.greaterThan = 0;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = 0;
			integer1 = fsmInt;
			FsmInt fsmInt2 = 0;
			everyFrame = false;
			integer2 = fsmInt2;
			equal = null;
			lessThan = null;
			greaterThan = null;
		}

		[Token(Token = "0x6000C20")]
		[Address(RVA = "0xA383E8", Offset = "0xA383E8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntCompare::DoIntCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIntCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C21")]
		[Address(RVA = "0xA38518", Offset = "0xA38518", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntCompare::DoIntCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIntCompare();
		}

		[Token(Token = "0x6000C22")]
		[Address(RVA = "0xA38424", Offset = "0xA38424", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer1);\n\tv126 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer2);\n\tv18 = v15 != v126;\n\tif (v18) goto L_0027;\n\tv161 = this.fsm;\n\tv157 = this.equal;\n\tgoto L_0062;\nL_0027:\n\tv121 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer1);\n\tv174 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer2);\n\tv19 = v121 >= v174;\n\tif (v19) goto L_0043;\n\tv161 = this.fsm;\n\tv157 = this.lessThan;\n\tgoto L_0062;\nL_0043:\n\tv122 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer1);\n\tv162 = HutongGames.PlayMaker.FsmInt::get_Value(this.integer2);\n\tv20 = v122 <= v162;\n\tif (v20) goto L_0069;\n\tv161 = this.fsm;\n\tv157 = this.greaterThan;\nL_0062:\n\tHutongGames.PlayMaker.Fsm::Event(v161, v157);\n\treturn;\nL_0069:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIntCompare()
		{
			int value = integer1.Value;
			int value2 = integer2.Value;
			Fsm fsm;
			FsmEvent fsmEvent;
			if (value == value2)
			{
				fsm = Fsm;
				fsmEvent = equal;
			}
			else
			{
				int value3 = integer1.Value;
				int value4 = integer2.Value;
				if (value3 < value4)
				{
					fsm = Fsm;
					fsmEvent = lessThan;
				}
				else
				{
					int value5 = integer1.Value;
					int value6 = integer2.Value;
					if (value5 <= value6)
					{
						return;
					}
					fsm = Fsm;
					fsmEvent = greaterThan;
				}
			}
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000C23")]
		[Address(RVA = "0xA3851C", Offset = "0xA3851C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EBBCC8]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E29]) = v40;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv57 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.equal);\n\tv59 = v57 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv82 = *([v60 @ X0_v9+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0034;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v60, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv69 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.lessThan);\n\tv72 = v69 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_0045;\n\tv107 = *([v103 @ X0_v13+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0045;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v103, v66, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv70 = HutongGames.PlayMaker.FsmEvent::IsNullOrEmpty(this.greaterThan);\n\tv73 = v70 == 0;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\treturn *([v93 @ X8_v5 (System.String)]);\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(equal) && FsmEvent.IsNullOrEmpty(lessThan) && FsmEvent.IsNullOrEmpty(greaterThan))
			{
				return "Action sends no events!";
			}
			return "";
		}

		[Token(Token = "0x6000C24")]
		[Address(RVA = "0xA38608", Offset = "0xA38608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntCompare()
		{
		}
	}
}
