using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B240", Offset = "0x75B240")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B240", Offset = "0x75B240")]
	[Token(Token = "0x20002E0")]
	public class PlayerPrefsGetFloat : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7C08C4", Offset = "0x7C08C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C08C4", Offset = "0x7C08C4")]
		[Token(Token = "0x40018CF")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] keys;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C0954", Offset = "0x7C0954")]
		[Token(Token = "0x40018D0")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] variables;

		[Token(Token = "0x6000E68")]
		[Address(RVA = "0xB1A3C4", Offset = "0xB1A3C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBDFF8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022569]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.keys = v43;\n\t// 29 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 1\n\tthis.variables = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString[] array = new FsmString[1];
			keys = array;
			FsmFloat[] array2 = new FsmFloat[1];
			variables = array2;
		}

		[Token(Token = "0x6000E69")]
		[Address(RVA = "0xB1A434", Offset = "0xB1A434", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EA4F28]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202256A]) = v46;\nL_0017:\n\tv218 = this.keys;\nL_0027:\n\tv53 = v173 >= v218.Length;\n\tif (v53) goto L_00CA;\n\tv261 = v173 < v218.Length;\n\tv164 = ~v261;\n\tif (v164) goto L_00CC;\n\tv177 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v218[v173 @ X21_v5 (System.Int32)]);\n\tv373 = v177 == 0;\n\tif (v373) goto L_005C;\n\tv192 = this.keys;\n\tv380 = v173 < v192.Length;\n\tv298 = ~v380;\n\tif (v298) goto L_00CC;\n\tv360 = HutongGames.PlayMaker.FsmString::get_Value(v192[v173 @ X21_v5 (System.Int32)]);\n\tv376 = System.String::Equals(v360, \"\");\n\tv385 = v376 == 0;\n\tv378 = ~v385;\n\tif (v378) goto L_00B8;\nL_005C:\n\tv193 = this.variables;\n\tv381 = v173 < v193.Length;\n\tv166 = ~v381;\n\tif (v166) goto L_00CC;\n\tv77 = this.keys;\n\tv382 = v173 < v77.Length;\n\tv167 = ~v382;\n\tif (v167) goto L_00CC;\n\tv63 = v193[v173 @ X21_v5 (System.Int32)];\n\tv179 = HutongGames.PlayMaker.FsmString::get_Value(v77[v173 @ X21_v5 (System.Int32)]);\n\tv194 = this.variables;\n\tv389 = v173 < v194.Length;\n\tv168 = ~v389;\n\tif (v168) goto L_00CC;\n\tv180 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v194[v173 @ X21_v5 (System.Int32)]);\n\tv391 = v180 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_00B4;\n\tv195 = this.variables;\n\tv399 = v173 < v195.Length;\n\tv299 = ~v399;\n\tif (v299) goto L_00CC;\n\tv393 = HutongGames.PlayMaker.FsmFloat::get_Value(v195[v173 @ X21_v5 (System.Int32)]);\nL_00B4:\n\tv59 = UnityEngine.PlayerPrefs::GetFloat(v179, v393);\n\tv63.value = v59;\nL_00B8:\n\tv218 = this.keys;\n\tv173 = v173 + 1;\n\tv388 = this.keys == 0;\n\tv183 = ~v388;\n\tif (v183) goto L_0027;\n\tthrow System.NullReferenceException;\nL_00CA:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00CC:\n\tv304 = new System.IndexOutOfRangeException();\n\tthrow v304;\n\tthrow System.NullReferenceException;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmString[] array = keys;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					if (num >= array.Length)
					{
						break;
					}
					if (array[num].IsNone)
					{
						FsmString[] array2 = keys;
						if (num >= array2.Length)
						{
							break;
						}
						string value = array2[num].Value;
						if (value.Equals(""))
						{
							goto IL_02b7;
						}
					}
					FsmFloat[] array3 = variables;
					if (num >= array3.Length)
					{
						break;
					}
					FsmString[] array4 = keys;
					if (num >= array4.Length)
					{
						break;
					}
					FsmFloat fsmFloat = array3[num];
					string value2 = array4[num].Value;
					FsmFloat[] array5 = variables;
					if (num >= array5.Length)
					{
						break;
					}
					bool isNone = array5[num].IsNone;
					bool flag = !isNone;
					bool flag2 = !flag;
					float defaultValue = 0f;
					if (!flag2)
					{
						FsmFloat[] array6 = variables;
						if (num >= array6.Length)
						{
							break;
						}
						defaultValue = array6[num].Value;
					}
					float value3 = PlayerPrefs.GetFloat(value2, defaultValue);
					fsmFloat.Value = value3;
					goto IL_02b7;
				}
				Finish();
				return;
				IL_02b7:
				array = keys;
				num++;
				if (keys == null)
				{
					throw new NullReferenceException();
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000E6A")]
		[Address(RVA = "0xB1A5E8", Offset = "0xB1A5E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsGetFloat()
		{
		}
	}
}
