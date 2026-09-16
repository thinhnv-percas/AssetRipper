using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758F88", Offset = "0x758F88")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758F88", Offset = "0x758F88")]
	[Token(Token = "0x2000272")]
	public class StringCompare : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B6FFC", Offset = "0x7B6FFC")]
		[Token(Token = "0x4001669")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[Token(Token = "0x400166A")]
		[FieldOffset(Offset = "0x58")]
		public FsmString compareTo;

		[Token(Token = "0x400166B")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent equalEvent;

		[Token(Token = "0x400166C")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent notEqualEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B7038", Offset = "0x7B7038")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7038", Offset = "0x7B7038")]
		[Token(Token = "0x400166D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool storeResult;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B7088", Offset = "0x7B7088")]
		[Token(Token = "0x400166E")]
		[FieldOffset(Offset = "0x78")]
		public bool everyFrame;

		[Token(Token = "0x6000C33")]
		[Address(RVA = "0x99E68C", Offset = "0x99E68C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F04130]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217BB]) = v38;\nL_0013:\n\tthis.stringVariable = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.everyFrame = 0;\n\tthis.compareTo = v43;\n\tthis.equalEvent = 0;\n\tthis.notEqualEvent = 0;\n\tthis.storeResult = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			stringVariable = null;
			FsmString fsmString = "";
			everyFrame = false;
			compareTo = fsmString;
			equalEvent = null;
			notEqualEvent = null;
			storeResult = null;
		}

		[Token(Token = "0x6000C34")]
		[Address(RVA = "0x99E6F0", Offset = "0x99E6F0", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringCompare::DoStringCompare(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoStringCompare();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C35")]
		[Address(RVA = "0x99E7CC", Offset = "0x99E7CC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringCompare::DoStringCompare(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoStringCompare();
		}

		[Token(Token = "0x6000C36")]
		[Address(RVA = "0x99E72C", Offset = "0x99E72C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.stringVariable == 0;\n\tif (v13) goto L_0039;\n\tv15 = this.compareTo == 0;\n\tif (v15) goto L_0039;\n\tv41 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tv70 = HutongGames.PlayMaker.FsmString::get_Value(this.compareTo);\n\tv35 = System.String::op_Equality(v41, v70);\n\tv29 = this.storeResult;\n\tv88 = this.storeResult == 0;\n\tif (v88) goto L_0020;\n\tv29.value = v35;\nL_0020:\n\tv91 = v35 == 0;\n\tif (v91) goto L_0030;\n\tv52 = this.equalEvent;\n\tv33 = this.equalEvent == 0;\n\tif (v33) goto L_0039;\nL_002E:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v52);\n\treturn;\nL_0030:\n\tv52 = this.notEqualEvent;\n\tv92 = this.notEqualEvent == 0;\n\tv32 = ~v92;\n\tif (v32) goto L_002E;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStringCompare()
		{
			if (stringVariable == null || compareTo == null)
			{
				return;
			}
			string value = stringVariable.Value;
			string value2 = compareTo.Value;
			bool flag = value == value2;
			FsmBool fsmBool = storeResult;
			if (storeResult != null)
			{
				fsmBool.value = flag;
			}
			FsmEvent fsmEvent;
			if (flag)
			{
				fsmEvent = equalEvent;
				if (equalEvent == null)
				{
					return;
				}
			}
			else
			{
				fsmEvent = notEqualEvent;
				if (notEqualEvent == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000C37")]
		[Address(RVA = "0x99E7D0", Offset = "0x99E7D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringCompare()
		{
		}
	}
}
