using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B420", Offset = "0x75B420")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B420", Offset = "0x75B420")]
	[Token(Token = "0x20002E5")]
	public class PlayerPrefsSetInt : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7C0C10", Offset = "0x7C0C10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0C10", Offset = "0x7C0C10")]
		[Token(Token = "0x40018DB")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] keys;

		[Token(Token = "0x40018DC")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt[] values;

		[Token(Token = "0x6000E77")]
		[Address(RVA = "0xB1ADAC", Offset = "0xB1ADAC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0FD48]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022573]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.keys = v43;\n\t// 29 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 1\n\tthis.values = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString[] array = new FsmString[1];
			keys = array;
			FsmInt[] array2 = new FsmInt[1];
			values = array2;
		}

		[Token(Token = "0x6000E78")]
		[Address(RVA = "0xB1AE1C", Offset = "0xB1AE1C", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F09550]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022574]) = v44;\nL_0016:\n\tv178 = this.keys;\nL_0026:\n\tv51 = v137 >= v178.Length;\n\tif (v51) goto L_00B5;\n\tv217 = v137 < v178.Length;\n\tv130 = ~v217;\n\tif (v130) goto L_00B8;\n\tv141 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v178[v137 @ X21_v5 (System.Int32)]);\n\tv318 = v141 == 0;\n\tif (v318) goto L_005B;\n\tv153 = this.keys;\n\tv325 = v137 < v153.Length;\n\tv262 = ~v325;\n\tif (v262) goto L_00B8;\n\tv304 = HutongGames.PlayMaker.FsmString::get_Value(v153[v137 @ X21_v5 (System.Int32)]);\n\tv321 = System.String::Equals(v304, \"\");\n\tv329 = v321 == 0;\n\tv323 = ~v329;\n\tif (v323) goto L_00A4;\nL_005B:\n\tv154 = this.keys;\n\tv326 = v137 < v154.Length;\n\tv132 = ~v326;\n\tif (v132) goto L_00B8;\n\tv143 = HutongGames.PlayMaker.FsmString::get_Value(v154[v137 @ X21_v5 (System.Int32)]);\n\tv155 = this.values;\n\tv327 = v137 < v155.Length;\n\tv133 = ~v327;\n\tif (v133) goto L_00B8;\n\tv144 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v155[v137 @ X21_v5 (System.Int32)]);\n\tv349 = v144 == 0;\n\tif (v349) goto L_008B;\n\tgoto L_00A3;\nL_008B:\n\tv156 = this.values;\n\tv354 = v137 < v156.Length;\n\tv263 = ~v354;\n\tif (v263) goto L_00B8;\n\tv353 = HutongGames.PlayMaker.FsmInt::get_Value(v156[v137 @ X21_v5 (System.Int32)]);\nL_00A3:\n\tUnityEngine.PlayerPrefs::SetInt(v143, v332);\nL_00A4:\n\tv178 = this.keys;\n\tv137 = v137 + 1;\n\tv347 = this.keys == 0;\n\tv146 = ~v347;\n\tif (v146) goto L_0026;\n\tthrow System.NullReferenceException;\nL_00B5:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv265 = new System.NullReferenceException();\nL_00B8:\n\tv272 = new System.IndexOutOfRangeException();\n\tthrow v272;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
							goto IL_021e;
						}
					}
					FsmString[] array3 = keys;
					if (num >= array3.Length)
					{
						break;
					}
					string value2 = array3[num].Value;
					FsmInt[] array4 = values;
					if (num >= array4.Length)
					{
						break;
					}
					int value3;
					if (array4[num].IsNone)
					{
						value3 = 0;
					}
					else
					{
						FsmInt[] array5 = values;
						if (num >= array5.Length)
						{
							break;
						}
						int value4 = array5[num].Value;
						value3 = value4;
					}
					PlayerPrefs.SetInt(value2, value3);
					goto IL_021e;
				}
				Finish();
				return;
				IL_021e:
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

		[Token(Token = "0x6000E79")]
		[Address(RVA = "0xB1AFB4", Offset = "0xB1AFB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsSetInt()
		{
		}
	}
}
