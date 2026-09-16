using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75B3C0", Offset = "0x75B3C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75B3C0", Offset = "0x75B3C0")]
	[Token(Token = "0x20002E4")]
	public class PlayerPrefsSetFloat : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7C0B80", Offset = "0x7C0B80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0B80", Offset = "0x7C0B80")]
		[Token(Token = "0x40018D9")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] keys;

		[Token(Token = "0x40018DA")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] values;

		[Token(Token = "0x6000E74")]
		[Address(RVA = "0xB1ABA4", Offset = "0xB1ABA4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB7298]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022571]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmString[]), typeof(HutongGames.PlayMaker.FsmString[]), 1\n\tthis.keys = v43;\n\t// 29 NewArr v48 @ X0_v5 (HutongGames.PlayMaker.FsmFloat[]), typeof(HutongGames.PlayMaker.FsmFloat[]), 1\n\tthis.values = v48;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString[] array = new FsmString[1];
			keys = array;
			FsmFloat[] array2 = new FsmFloat[1];
			values = array2;
		}

		[Token(Token = "0x6000E75")]
		[Address(RVA = "0xB1AC14", Offset = "0xB1AC14", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F0D9C0]);\n\tv25 = *([v24 @ X8_v24]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022572]) = v44;\nL_0016:\n\tv182 = this.keys;\nL_0026:\n\tv51 = v141 >= v182.Length;\n\tif (v51) goto L_00B4;\n\tv222 = v141 < v182.Length;\n\tv134 = ~v222;\n\tif (v134) goto L_00B7;\n\tv145 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v182[v141 @ X21_v5 (System.Int32)]);\n\tv326 = v145 == 0;\n\tif (v326) goto L_005B;\n\tv157 = this.keys;\n\tv333 = v141 < v157.Length;\n\tv269 = ~v333;\n\tif (v269) goto L_00B7;\n\tv312 = HutongGames.PlayMaker.FsmString::get_Value(v157[v141 @ X21_v5 (System.Int32)]);\n\tv329 = System.String::Equals(v312, \"\");\n\tv337 = v329 == 0;\n\tv331 = ~v337;\n\tif (v331) goto L_00A3;\nL_005B:\n\tv158 = this.keys;\n\tv334 = v141 < v158.Length;\n\tv136 = ~v334;\n\tif (v136) goto L_00B7;\n\tv147 = HutongGames.PlayMaker.FsmString::get_Value(v158[v141 @ X21_v5 (System.Int32)]);\n\tv159 = this.values;\n\tv335 = v141 < v159.Length;\n\tv137 = ~v335;\n\tif (v137) goto L_00B7;\n\tv148 = HutongGames.PlayMaker.NamedVariable::get_IsNone(v159[v141 @ X21_v5 (System.Int32)]);\n\tv357 = v148 == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_00A2;\n\tv160 = this.values;\n\tv363 = v141 < v160.Length;\n\tv270 = ~v363;\n\tif (v270) goto L_00B7;\n\tv338 = HutongGames.PlayMaker.FsmFloat::get_Value(v160[v141 @ X21_v5 (System.Int32)]);\nL_00A2:\n\tUnityEngine.PlayerPrefs::SetFloat(v147, v338);\nL_00A3:\n\tv182 = this.keys;\n\tv141 = v141 + 1;\n\tv355 = this.keys == 0;\n\tv150 = ~v355;\n\tif (v150) goto L_0026;\n\tthrow System.NullReferenceException;\nL_00B4:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv272 = new System.NullReferenceException();\nL_00B7:\n\tv279 = new System.IndexOutOfRangeException();\n\tthrow v279;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
							goto IL_022e;
						}
					}
					FsmString[] array3 = keys;
					if (num >= array3.Length)
					{
						break;
					}
					string value2 = array3[num].Value;
					FsmFloat[] array4 = values;
					if (num >= array4.Length)
					{
						break;
					}
					bool isNone = array4[num].IsNone;
					bool flag = !isNone;
					bool flag2 = !flag;
					float value3 = 0f;
					if (!flag2)
					{
						FsmFloat[] array5 = values;
						if (num >= array5.Length)
						{
							break;
						}
						value3 = array5[num].Value;
					}
					PlayerPrefs.SetFloat(value2, value3);
					goto IL_022e;
				}
				Finish();
				return;
				IL_022e:
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

		[Token(Token = "0x6000E76")]
		[Address(RVA = "0xB1ADA4", Offset = "0xB1ADA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PlayerPrefsSetFloat()
		{
		}
	}
}
