using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758944", Offset = "0x758944")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758944", Offset = "0x758944")]
	[Token(Token = "0x2000262")]
	public class FloatSwitch : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B5DB8", Offset = "0x7B5DB8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5DB8", Offset = "0x7B5DB8")]
		[Token(Token = "0x4001615")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat floatVariable;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7B5E18", Offset = "0x7B5E18")]
		[Token(Token = "0x4001616")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] lessThan;

		[Token(Token = "0x4001617")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent[] sendEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B5E80", Offset = "0x7B5E80")]
		[Token(Token = "0x4001618")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x6000BE6")]
		[Address(RVA = "0xB76C0C", Offset = "0xB76C0C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF1CC8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022931]) = v38;\nL_0013:\n\tthis.floatVariable = 0;\n\t// 24 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 1\n\tthis.lessThan = v43;\n\t// 30 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmEvent[]), typeof(HutongGames.PlayMaker.FsmEvent[]), 1\n\tthis.sendEvent = v48;\n\tthis.everyFrame = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			floatVariable = null;
			FsmFloat[] array = new FsmFloat[1];
			lessThan = array;
			FsmEvent[] array2 = new FsmEvent[1];
			sendEvent = array2;
			everyFrame = false;
		}

		[Token(Token = "0x6000BE7")]
		[Address(RVA = "0xB76C84", Offset = "0xB76C84", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSwitch::DoFloatSwitch(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFloatSwitch();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000BE8")]
		[Address(RVA = "0xB76DC4", Offset = "0xB76DC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.FloatSwitch::DoFloatSwitch(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoFloatSwitch();
		}

		[Token(Token = "0x6000BE9")]
		[Address(RVA = "0xB76CC0", Offset = "0xB76CC0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv118 = v19 == 0;\n\tv119 = ~v118;\n\tif (v119) goto L_0056;\n\tv250 = this.lessThan;\nL_0020:\n\tv22 = v84 >= v250.Length;\n\tif (v22) goto L_0056;\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.floatVariable);\n\tv136 = this.lessThan;\n\tv252 = v84 < v136.Length;\n\tv68 = ~v252;\n\tif (v68) goto L_0076;\n\tv82 = HutongGames.PlayMaker.FsmFloat::get_Value(v136[v84 @ X20_v7 (System.Int32)]);\n\tv200 = v81 < v82;\n\tif (v200) goto L_0057;\n\tv250 = this.lessThan;\n\tv84 = v84 + 1;\n\tv254 = this.lessThan == 0;\n\tv205 = ~v254;\n\tif (v205) goto L_0020;\n\tthrow System.NullReferenceException;\nL_0056:\n\treturn;\nL_0057:\n\tv89 = this.sendEvent;\n\tv255 = v84 < v89.Length;\n\tv69 = ~v255;\n\tif (v69) goto L_0076;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v89[v84 @ X20_v7 (System.Int32)]);\n\treturn;\n\tv103 = new System.NullReferenceException();\nL_0076:\n\tv142 = new System.IndexOutOfRangeException();\n\tthrow v142;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFloatSwitch()
		{
			if (floatVariable.IsNone)
			{
				return;
			}
			FsmFloat[] array = lessThan;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				float value = floatVariable.Value;
				FsmFloat[] array2 = lessThan;
				if (num >= array2.Length)
				{
					break;
				}
				float value2 = array2[num].Value;
				if (!(value < value2))
				{
					array = lessThan;
					num++;
					if (lessThan == null)
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

		[Token(Token = "0x6000BEA")]
		[Address(RVA = "0xB76DC8", Offset = "0xB76DC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FloatSwitch()
		{
		}
	}
}
