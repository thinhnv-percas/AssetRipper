using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759028", Offset = "0x759028")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759028", Offset = "0x759028")]
	[Token(Token = "0x2000274")]
	public class StringSwitch : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B7264", Offset = "0x7B7264")]
		[Token(Token = "0x4001675")]
		[FieldOffset(Offset = "0x50")]
		public FsmString stringVariable;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7B72A0", Offset = "0x7B72A0")]
		[Token(Token = "0x4001676")]
		[FieldOffset(Offset = "0x58")]
		public FsmString[] compareTo;

		[Token(Token = "0x4001677")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent[] sendEvent;

		[Token(Token = "0x4001678")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000C3D")]
		[Address(RVA = "0x99ED7C", Offset = "0x99ED7C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBD880]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217BF]) = v38;\nL_0013:\n\tthis.stringVariable = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.compareTo = v43;\n\t// 30 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tthis.sendEvent = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			stringVariable = null;
			FsmString[] array = new FsmString[1];
			compareTo = array;
			FsmEvent[] array2 = new FsmEvent[1];
			sendEvent = array2;
			everyFrame = false;
		}

		[Token(Token = "0x6000C3E")]
		[Address(RVA = "0x99EDF4", Offset = "0x99EDF4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringSwitch::DoStringSwitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoStringSwitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C3F")]
		[Address(RVA = "0x99EF34", Offset = "0x99EF34", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.StringSwitch::DoStringSwitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoStringSwitch();
		}

		[Token(Token = "0x6000C40")]
		[Address(RVA = "0x99EE30", Offset = "0x99EE30", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.stringVariable);\n\tv117 = v19 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0054;\n\tv242 = this.compareTo;\nL_0020:\n\tv22 = v83 >= v242.Length;\n\tif (v22) goto L_0054;\n\tv141 = HutongGames.PlayMaker.FsmString::get_Value(this.stringVariable);\n\tv135 = this.compareTo;\n\tv244 = v83 < v135.Length;\n\tv72 = ~v244;\n\tif (v72) goto L_0074;\n\tv246 = HutongGames.PlayMaker.FsmString::get_Value(v135[v83 @ X21_v7 (System.Int32)]);\n\tv142 = System.String::op_Equality(v141, v246);\n\tv249 = v142 == 0;\n\tv250 = ~v249;\n\tif (v250) goto L_0055;\n\tv242 = this.compareTo;\n\tv83 = v83 + 1;\n\tv251 = this.compareTo == 0;\n\tv198 = ~v251;\n\tif (v198) goto L_0020;\n\tthrow System.NullReferenceException;\nL_0054:\n\treturn;\nL_0055:\n\tv88 = this.sendEvent;\n\tv252 = v83 < v88.Length;\n\tv73 = ~v252;\n\tif (v73) goto L_0074;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v88[v83 @ X21_v7 (System.Int32)]);\n\treturn;\n\tv102 = new System.NullReferenceException();\nL_0074:\n\tv143 = new System.IndexOutOfRangeException();\n\tthrow v143;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoStringSwitch()
		{
			if (stringVariable.IsNone)
			{
				return;
			}
			FsmString[] array = compareTo;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				string value = stringVariable.Value;
				FsmString[] array2 = compareTo;
				if (num >= array2.Length)
				{
					break;
				}
				string value2 = array2[num].Value;
				if (!(value == value2))
				{
					array = compareTo;
					num++;
					if (compareTo == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				FsmEvent[] array3 = sendEvent;
				if (num >= array3.Length)
				{
					break;
				}
				Fsm.Event(array3[num]);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000C41")]
		[Address(RVA = "0x99EF38", Offset = "0x99EF38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringSwitch()
		{
		}
	}
}
