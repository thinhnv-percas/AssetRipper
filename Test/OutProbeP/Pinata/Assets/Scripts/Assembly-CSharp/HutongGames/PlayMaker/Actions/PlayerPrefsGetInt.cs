using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B2A0", Offset = "0x75B2A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B2A0", Offset = "0x75B2A0")]
	[Token(Token = "0x20002E1")]
	public class PlayerPrefsGetInt : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7C0968", Offset = "0x7C0968")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0968", Offset = "0x7C0968")]
		[Token(Token = "0x40018D1")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] keys;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C09F8", Offset = "0x7C09F8")]
		[Token(Token = "0x40018D2")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt[] variables;

		[Token(Token = "0x6000E6B")]
		[Address(RVA = "0xB1A5F0", Offset = "0xB1A5F0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBE030]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202256B]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.keys = v43;\n\t// 29 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 1\n\tthis.variables = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString[] array = new FsmString[1];
			keys = array;
			FsmInt[] array2 = new FsmInt[1];
			variables = array2;
		}

		[Token(Token = "0x6000E6C")]
		[Address(RVA = "0xB1A660", Offset = "0xB1A660", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFB200]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202256C]) = v46;\nL_0017:\n\tv214 = this.keys;\nL_0027:\n\tv53 = v169 >= v214.Length;\n\tif (v53) goto L_00CB;\n\tv256 = v169 < v214.Length;\n\tv160 = ~v256;\n\tif (v160) goto L_00CD;\n\tv173 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v214[v169 @ X21_v5 (System.Int32)]);\n\tv365 = v173 == 0;\n\tif (v365) goto L_005C;\n\tv188 = this.keys;\n\tv372 = v169 < v188.Length;\n\tv292 = ~v372;\n\tif (v292) goto L_00CD;\n\tv352 = HutongGames.PlayMaker.FsmString::get_Value(v188[v169 @ X21_v5 (System.Int32)]);\n\tv368 = System.String::Equals(v352, \"\");\n\tv377 = v368 == 0;\n\tv370 = ~v377;\n\tif (v370) goto L_00B9;\nL_005C:\n\tv189 = this.variables;\n\tv373 = v169 < v189.Length;\n\tv162 = ~v373;\n\tif (v162) goto L_00CD;\n\tv73 = this.keys;\n\tv374 = v169 < v73.Length;\n\tv163 = ~v374;\n\tif (v163) goto L_00CD;\n\tv58 = v189[v169 @ X21_v5 (System.Int32)];\n\tv175 = HutongGames.PlayMaker.FsmString::get_Value(v73[v169 @ X21_v5 (System.Int32)]);\n\tv190 = this.variables;\n\tv381 = v169 < v190.Length;\n\tv164 = ~v381;\n\tif (v164) goto L_00CD;\n\tv176 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v190[v169 @ X21_v5 (System.Int32)]);\n\tv383 = v176 == 0;\n\tif (v383) goto L_009D;\n\tgoto L_00B5;\nL_009D:\n\tv191 = this.variables;\n\tv390 = v169 < v191.Length;\n\tv293 = ~v390;\n\tif (v293) goto L_00CD;\n\tv387 = HutongGames.PlayMaker.FsmInt::get_Value(v191[v169 @ X21_v5 (System.Int32)]);\nL_00B5:\n\tv177 = UnityEngine.PlayerPrefs::GetInt(v175, v84);\n\tv58.value = v177;\nL_00B9:\n\tv214 = this.keys;\n\tv169 = v169 + 1;\n\tv380 = this.keys == 0;\n\tv179 = ~v380;\n\tif (v179) goto L_0027;\n\tthrow System.NullReferenceException;\nL_00CB:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00CD:\n\tv298 = new System.IndexOutOfRangeException();\n\tthrow v298;\n\tthrow System.NullReferenceException;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
							goto IL_02a3;
						}
					}
					FsmInt[] array3 = variables;
					if (num >= array3.Length)
					{
						break;
					}
					FsmString[] array4 = keys;
					if (num >= array4.Length)
					{
						break;
					}
					FsmInt fsmInt = array3[num];
					string value2 = array4[num].Value;
					FsmInt[] array5 = variables;
					if (num >= array5.Length)
					{
						break;
					}
					int defaultValue;
					if (array5[num].IsNone)
					{
						defaultValue = 0;
					}
					else
					{
						FsmInt[] array6 = variables;
						if (num >= array6.Length)
						{
							break;
						}
						int value3 = array6[num].Value;
						defaultValue = value3;
					}
					int value4 = PlayerPrefs.GetInt(value2, defaultValue);
					fsmInt.Value = value4;
					goto IL_02a3;
				}
				Finish();
				return;
				IL_02a3:
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

		[Token(Token = "0x6000E6D")]
		[Address(RVA = "0xB1A81C", Offset = "0xB1A81C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsGetInt()
		{
		}
	}
}
