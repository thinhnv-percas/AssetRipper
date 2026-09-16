using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x759848", Offset = "0x759848")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x759848", Offset = "0x759848")]
	[Token(Token = "0x200028E")]
	public class RandomInt : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8A8C", Offset = "0x7B8A8C")]
		[Token(Token = "0x40016E0")]
		[FieldOffset(Offset = "0x50")]
		public FsmInt min;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8AD8", Offset = "0x7B8AD8")]
		[Token(Token = "0x40016E1")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt max;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B8B24", Offset = "0x7B8B24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8B24", Offset = "0x7B8B24")]
		[Token(Token = "0x40016E2")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8B84", Offset = "0x7B8B84")]
		[Token(Token = "0x40016E3")]
		[FieldOffset(Offset = "0x68")]
		public bool inclusiveMax;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B8BBC", Offset = "0x7B8BBC")]
		[Token(Token = "0x40016E4")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool noRepeat;

		[Token(Token = "0x40016E5")]
		[FieldOffset(Offset = "0x78")]
		private int randomIndex;

		[Token(Token = "0x40016E6")]
		[FieldOffset(Offset = "0x7C")]
		private int lastIndex;

		[Token(Token = "0x6000CB1")]
		[Address(RVA = "0xB1CDA0", Offset = "0xB1CDA0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.min = v12;\n\tv15 = HutongGames.PlayMaker.FsmInt::op_Implicit(0x64);\n\tthis.max = v15;\n\tthis.storeResult = 0;\n\tthis.inclusiveMax = 0;\n\tv18 = HutongGames.PlayMaker.FsmBool::op_Implicit(1);\n\tthis.noRepeat = v18;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmInt fsmInt = 0;
			min = fsmInt;
			FsmInt fsmInt2 = 100;
			max = fsmInt2;
			storeResult = null;
			inclusiveMax = false;
			FsmBool fsmBool = true;
			noRepeat = fsmBool;
		}

		[Token(Token = "0x6000CB2")]
		[Address(RVA = "0xB1CDF0", Offset = "0xB1CDF0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RandomInt::PickRandom(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			PickRandom();
			Finish();
		}

		[Token(Token = "0x6000CB3")]
		[Address(RVA = "0xB1CE18", Offset = "0xB1CE18", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA81A0]);\n\tv23 = *([v22 @ X8_v21]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022587]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmBool::get_Value(this.noRepeat);\n\tv145 = v46 == 0;\n\tif (v145) goto L_0085;\n\tv190 = HutongGames.PlayMaker.FsmInt::get_Value(this.max);\n\tv115 = this + 0x50;\n\tv202 = HutongGames.PlayMaker.FsmInt::get_Value(this.min);\n\tv91 = v190 == v202;\n\tif (v91) goto L_008B;\n\tv252 = ~this.inclusiveMax;\n\tv206 = ~v252;\n\tif (v206) goto L_008B;\n\tv232 = HutongGames.PlayMaker.FsmInt::get_Value(this.max);\n\tv259 = HutongGames.PlayMaker.FsmInt::get_Value(this.min);\n\tgoto L_0053;\n\tv265 = *([v209 @ X8_v14+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\tif (v267) goto L_0053;\n\tv271 = v209;\n\tv269 = \"il2cpp_codegen_runtime_class_init\"(v271, v258, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0053:\n\tv270 = v232 - v259;\n\tv203 = UnityEngine.Mathf::Abs(v270);\n\tv53 = v203 < 2;\n\tif (v53) goto L_008B;\nL_0067:\n\tv233 = HutongGames.PlayMaker.FsmInt::get_Value(this.min);\n\tv279 = HutongGames.PlayMaker.FsmInt::get_Value(this.max);\n\tv229 = v279 + this.inclusiveMax;\n\tv178 = UnityEngine.Random::Range(v233, v229);\n\tthis.randomIndex = v178;\n\tv223 = v178 == this.lastIndex;\n\tif (v223) goto L_0067;\n\tv184 = this.storeResult;\n\tthis.lastIndex = v178;\n\tv282 = this.storeResult == 0;\n\tv238 = ~v282;\n\tif (v238) goto L_009B;\n\tgoto L_00A5;\nL_0085:\n\tv115 = this + 0x50;\nL_008B:\n\tv214 = HutongGames.PlayMaker.FsmInt::get_Value(*([v115 @ X22_v2]));\n\tv251 = HutongGames.PlayMaker.FsmInt::get_Value(this.max);\n\tv230 = v251 + this.inclusiveMax;\n\tv178 = UnityEngine.Random::Range(v214, v230);\n\tv184 = this.storeResult;\n\tthis.randomIndex = v178;\nL_009B:\n\tv184.value = v178;\n\treturn;\nL_00A5:\n\tthrow System.NullReferenceException;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PickRandom()
		{
			//IL_01c0: Expected O, but got I
			//IL_004c: Expected O, but got I
			object obj;
			int num3;
			FsmInt fsmInt;
			if (noRepeat.Value)
			{
				int value = max.Value;
				obj = (long)(IntPtr)this + 80L;
				int value2 = min.Value;
				if (value != value2 && !inclusiveMax)
				{
					int value3 = max.Value;
					int value4 = min.Value;
					int value5 = value3 - value4;
					int num = Mathf.Abs(value5);
					if (num >= 2)
					{
						do
						{
							int value6 = min.Value;
							int value7 = max.Value;
							int num2 = value7 + (inclusiveMax ? 1 : 0);
							num3 = (randomIndex = UnityEngine.Random.Range(value6, num2));
						}
						while (num3 == lastIndex);
						fsmInt = storeResult;
						lastIndex = num3;
						if (storeResult == null)
						{
							throw new NullReferenceException();
						}
						goto IL_0224;
					}
				}
			}
			else
			{
				obj = (long)(IntPtr)this + 80L;
			}
			int value8 = ((FsmInt)obj).Value;
			int value9 = max.Value;
			int num4 = value9 + (inclusiveMax ? 1 : 0);
			num3 = UnityEngine.Random.Range(value8, num4);
			fsmInt = storeResult;
			randomIndex = num3;
			goto IL_0224;
			IL_0224:
			fsmInt.Value = num3;
		}

		[Token(Token = "0x6000CB4")]
		[Address(RVA = "0xB1CFC8", Offset = "0xB1CFC8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.lastIndex = 0xFFFFFFFF;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RandomInt()
		{
			lastIndex = -1;
		}
	}
}
