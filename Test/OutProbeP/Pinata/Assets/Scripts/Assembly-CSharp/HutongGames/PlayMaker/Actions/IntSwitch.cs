using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758E98", Offset = "0x758E98")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758E98", Offset = "0x758E98")]
	[Token(Token = "0x200026F")]
	public class IntSwitch : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B6DB4", Offset = "0x7B6DB4")]
		[Token(Token = "0x400165B")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt intVariable;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7B6DF0", Offset = "0x7B6DF0")]
		[Token(Token = "0x400165C")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt[] compareTo;

		[Token(Token = "0x400165D")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent[] sendEvent;

		[Token(Token = "0x400165E")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000C25")]
		[Address(RVA = "0xA387C0", Offset = "0xA387C0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0C870]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E2B]) = v38;\nL_0013:\n\tthis.intVariable = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 1\n\tthis.compareTo = v43;\n\t// 30 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tthis.sendEvent = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			intVariable = null;
			FsmInt[] array = new FsmInt[1];
			compareTo = array;
			FsmEvent[] array2 = new FsmEvent[1];
			sendEvent = array2;
			everyFrame = false;
		}

		[Token(Token = "0x6000C26")]
		[Address(RVA = "0xA38838", Offset = "0xA38838", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntSwitch::DoIntSwitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIntSwitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C27")]
		[Address(RVA = "0xA3896C", Offset = "0xA3896C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.IntSwitch::DoIntSwitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIntSwitch();
		}

		[Token(Token = "0x6000C28")]
		[Address(RVA = "0xA38874", Offset = "0xA38874", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.intVariable);\n\tv114 = v19 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_0056;\n\tv244 = this.compareTo;\nL_0020:\n\tv22 = v79 >= v244.Length;\n\tif (v22) goto L_0056;\n\tv137 = HutongGames.PlayMaker.FsmInt::get_Value(this.intVariable);\n\tv131 = this.compareTo;\n\tv246 = v79 < v131.Length;\n\tv68 = ~v246;\n\tif (v68) goto L_0076;\n\tv138 = HutongGames.PlayMaker.FsmInt::get_Value(v131[v79 @ X21_v7 (System.Int32)]);\n\tv194 = v137 == v138;\n\tif (v194) goto L_0057;\n\tv244 = this.compareTo;\n\tv79 = v79 + 1;\n\tv248 = this.compareTo == 0;\n\tv200 = ~v248;\n\tif (v200) goto L_0020;\n\tthrow System.NullReferenceException;\nL_0056:\n\treturn;\nL_0057:\n\tv84 = this.sendEvent;\n\tv249 = v79 < v84.Length;\n\tv69 = ~v249;\n\tif (v69) goto L_0076;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v84[v79 @ X21_v7 (System.Int32)]);\n\treturn;\n\tv98 = new System.NullReferenceException();\nL_0076:\n\tv139 = new System.IndexOutOfRangeException();\n\tthrow v139;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIntSwitch()
		{
			if (intVariable.IsNone)
			{
				return;
			}
			FsmInt[] array = compareTo;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				int value = intVariable.Value;
				FsmInt[] array2 = compareTo;
				if (num >= array2.Length)
				{
					break;
				}
				int value2 = array2[num].Value;
				if (value != value2)
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

		[Token(Token = "0x6000C29")]
		[Address(RVA = "0xA38970", Offset = "0xA38970", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntSwitch()
		{
		}
	}
}
