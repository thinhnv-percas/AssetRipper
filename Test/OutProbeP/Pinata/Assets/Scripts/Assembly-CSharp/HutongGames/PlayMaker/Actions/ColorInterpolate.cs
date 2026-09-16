using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754B7C", Offset = "0x754B7C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754B7C", Offset = "0x754B7C")]
	[Token(Token = "0x20001A1")]
	public class ColorInterpolate : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACC40", Offset = "0x7ACC40")]
		[Token(Token = "0x400131C")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor[] colors;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACC8C", Offset = "0x7ACC8C")]
		[Token(Token = "0x400131D")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat time;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ACCD8", Offset = "0x7ACCD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACCD8", Offset = "0x7ACCD8")]
		[Token(Token = "0x400131E")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor storeColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACD38", Offset = "0x7ACD38")]
		[Token(Token = "0x400131F")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACD70", Offset = "0x7ACD70")]
		[Token(Token = "0x4001320")]
		[FieldOffset(Offset = "0x70")]
		public bool realTime;

		[Token(Token = "0x4001321")]
		[FieldOffset(Offset = "0x74")]
		private float startTime;

		[Token(Token = "0x4001322")]
		[FieldOffset(Offset = "0x78")]
		private float currentTime;

		[Token(Token = "0x60008DB")]
		[Address(RVA = "0xA90CD8", Offset = "0xA90CD8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDAD78]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221F2]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmColor[]), typeof(HutongGames.PlayMaker.FsmColor[]), 3\n\tthis.colors = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.realTime = 0;\n\tthis.storeColor = 0;\n\tthis.finishEvent = 0;\n\tthis.time = v46;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmColor[] array = new FsmColor[3];
			colors = array;
			FsmFloat fsmFloat = 1f;
			realTime = false;
			storeColor = null;
			finishEvent = null;
			time = fsmFloat;
		}

		[Token(Token = "0x60008DC")]
		[Address(RVA = "0xA90D48", Offset = "0xA90D48", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv12 = this.colors;\n\tthis.startTime = v11;\n\tthis.currentTime = 0f;\n\tv26 = v12.Length > 1;\n\tif (v26) goto L_0031;\n\tv31 = v12.Length != 1;\n\tif (v31) goto L_002F;\n\tv58 = v12[0];\n\tv50 = this.storeColor;\n\tv50.value.r = v58.value;\n\tv50.value.g = v58.value.g;\n\tv50.value.a = v58.value.a;\nL_002F:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0031:\n\tv59 = v12[0];\n\tv51 = this.storeColor;\n\tv51.value.r = v59.value;\n\tv51.value.g = v59.value.g;\n\tv51.value.a = v59.value.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
			FsmColor[] array = colors;
			startTime = realtimeSinceStartup;
			currentTime = 0f;
			if (array.Length <= 1)
			{
				if (array.Length == 1)
				{
					FsmColor fsmColor = array[0];
					FsmColor fsmColor2 = storeColor;
					fsmColor2.value.r = fsmColor.value.r;
					fsmColor2.value.g = fsmColor.value.g;
					fsmColor2.value.a = fsmColor.value.a;
				}
				Finish();
			}
			else
			{
				FsmColor fsmColor3 = array[0];
				FsmColor fsmColor4 = storeColor;
				fsmColor4.value.r = fsmColor3.value.r;
				fsmColor4.value.g = fsmColor3.value.g;
				fsmColor4.value.a = fsmColor3.value.a;
			}
		}

		[Token(Token = "0x60008DD")]
		[Address(RVA = "0xA90DF8", Offset = "0xA90DF8", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F05278]);\n\tv27 = *([v26 @ X8_v36]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20221F3]) = v46;\nL_0019:\n\tv49 = ~this.realTime;\n\tif (v49) goto L_0022;\n\tv51 = HutongGames.PlayMaker.FsmTime::get_RealtimeSinceStartup();\n\tv58 = v51 - this.startTime;\n\tgoto L_0025;\nL_0022:\n\tv51 = UnityEngine.Time::get_deltaTime();\n\tv58 = this.currentTime + v51;\nL_0025:\n\tthis.currentTime = v58;\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv111 = v58 <= v51;\n\tif (v111) goto L_005A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv250 = this.colors;\n\tv244 = v250.Length == 0;\n\tif (v244) goto L_00F7;\n\tv397 = v250.Length << 0x20;\n\tv282 = 0xFFFFFFFF00000000 + v397;\n\tv100 = v282 >> 0x1D;\n\tv398 = v250 + v100;\n\tv310 = *([v398 @ X8_v31+20]);\n\tv108 = this.storeColor;\n\tv108.value.r = *([v310 @ X8_v32+38]);\n\tv108.value.g = *([v310 @ X8_v32+3C]);\n\tv108.value.a = *([v310 @ X8_v32+44]);\n\tv404 = this.finishEvent == 0;\n\tif (v404) goto L_00F3;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\n\tgoto L_00F3;\nL_005A:\n\tv167 = this.colors;\n\tv51 = HutongGames.PlayMaker.FsmFloat::get_Value(this.time);\n\tv401 = v167.Length - 1;\n\tv231 = this.currentTime * v401;\n\tv51 = v231 / v51;\n\tv239 = 0xBCCE68(&v51 @ V0_v22 (System.Single), 0, v30, v31, v32, v33, v34, v35, 0, v231, v38, v39, v40, v41, v42, v43);\n\tv418 = this.colors;\n\tv405 = v239 & 1;\n\tv406 = v405 == 0;\n\tif (v406) goto L_0078;\n\tv413 = v418.Length == 0;\n\tv245 = ~v413;\n\tif (v245) goto L_008B;\n\tgoto L_00F7;\nL_0078:\n\tv311 = v418.Length - 1;\n\tv240 = 0xBCCE68(&v189 @ stack_-44_v9 (System.Single), 0, v30, v31, v32, v33, v34, v35, v311, v231, v38, v39, v40, v41, v42, v43);\n\tv256 = this.colors;\n\tv420 = v240 & 1;\n\tv421 = v420 == 0;\n\tif (v421) goto L_009A;\n\tv246 = v256.Length == 0;\n\tif (v246) goto L_00F7;\n\tv454 = v256.Length << 0x20;\n\tv455 = 0xFFFFFFFF00000000 + v454;\n\tv415 = v455 >> 0x1D;\n\tv418 = v256 + v415;\nL_008B:\n\tv315 = v418[0];\n\tv298 = v315.value;\n\tv296 = v315.value.g;\n\tv275 = v315.value.b;\n\tv274 = v315.value.a;\n\tgoto L_00E3;\nL_009A:\n\tgoto L_00A2;\n\tv447 = *([v428 @ X0_v20+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_00A2;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v428, v225, v30, v31, v32, v33, v34, v35, v234, v231, v38, v39, v40, v41, v42, v43);\nL_00A2:\n\tv241 = UnityEngine.Mathf::FloorToInt(v189);\n\tv456 = v241 < v256.Length;\n\tv220 = ~v456;\n\tif (v220) goto L_00F7;\n\tv313 = v256[v241 @ X0_v23 (System.Int32)];\n\tv257 = this.colors;\n\tv242 = UnityEngine.Mathf::CeilToInt(v189);\n\tv459 = v242 < v257.Length;\n\tv221 = ~v459;\n\tif (v221) goto L_00F7;\n\tv314 = v257[v242 @ X0_v25 (System.Int32)];\n\tv463 = UnityEngine.Mathf::Floor(v189);\n\tv51 = v189 - v463;\n\t// 221 MakeStruct v433 @ AGGA91044_0_v6 (UnityEngine.Color), typeof(UnityEngine.Color), v313.value (UnityEngine.Color), v313.value.g (System.Single), v313.value.b (System.Single), v313.value.a (System.Single)\n\t// 222 MakeStruct v432 @ AGGA91044_1_v6 (UnityEngine.Color), typeof(UnityEngine.Color), v314.value (UnityEngine.Color), v314.value.g (System.Single), v314.value.b (System.Single), v314.value.a (System.Single)\n\tv298 = UnityEngine.Color::Lerp(v433, v432, v51);\n\tv296 = v298.g;\n\tv275 = v298.b;\n\tv274 = v298.a;\nL_00E3:\n\tv316 = this.storeColor;\n\tv316.value = v298;\n\tv316.value.g = v296;\n\tv316.value.b = v275;\n\tv316.value.a = v274;\nL_00F3:\n\treturn;\n\tv155 = new System.NullReferenceException();\n\tv168 = new System.NullReferenceException();\nL_00F7:\n\tv258 = new System.IndexOutOfRangeException();\n\tthrow v258;\n\treturn;\n// 150 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_01bb: Expected O, but got I4
			//IL_0269: Expected O, but got I4
			//IL_00c9: Expected O, but got I8
			//IL_00e6: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0124: Expected F4, but got I
			//IL_013e: Expected F4, but got I
			//IL_0158: Expected F4, but got I
			//IL_02ef: Expected O, but got I8
			//IL_030c: Expected O, but got I
			float num;
			float realtimeSinceStartup;
			if (realTime)
			{
				realtimeSinceStartup = FsmTime.RealtimeSinceStartup;
				num = realtimeSinceStartup - startTime;
			}
			else
			{
				realtimeSinceStartup = Time.deltaTime;
				num = currentTime + realtimeSinceStartup;
			}
			currentTime = num;
			realtimeSinceStartup = time.Value;
			FsmColor[] array3;
			Color value4;
			float g;
			float b2;
			float a2;
			if (num > realtimeSinceStartup)
			{
				Finish();
				FsmColor[] array = colors;
				if (array.Length != 0)
				{
					int num2 = array.Length << 32;
					object obj = -4294967296L + num2;
					int num3 = (int)((long)(IntPtr)obj >> 29);
					object obj2 = (long)(IntPtr)array + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v398 @ X8_v31+20]");
					object obj3 = 0;
					FsmColor fsmColor = storeColor;
					ref Color value = ref fsmColor.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v32+38]");
					value.r = 0f;
					ref Color value2 = ref fsmColor.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v32+3C]");
					value2.g = 0f;
					ref Color value3 = ref fsmColor.value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ X8_v32+44]");
					value3.a = 0f;
					if (finishEvent != null)
					{
						Fsm.Event(finishEvent);
					}
					return;
				}
			}
			else
			{
				FsmColor[] array2 = colors;
				realtimeSinceStartup = time.Value;
				object obj4 = array2.Length - 1;
				float num4 = currentTime * (float)obj4;
				realtimeSinceStartup = num4 / realtimeSinceStartup;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
				array3 = colors;
				object obj5 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
				{
					if (array3.Length != 0)
					{
						goto IL_05a5;
					}
				}
				else
				{
					object obj6 = array3.Length - 1;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
					FsmColor[] array4 = colors;
					object obj7 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
					{
						if (array4.Length != 0)
						{
							int num5 = array4.Length << 32;
							object obj8 = -4294967296L + num5;
							int num6 = (int)((long)(IntPtr)obj8 >> 29);
							array3 = (FsmColor[])((long)(IntPtr)array4 + (long)num6);
							goto IL_05a5;
						}
					}
					else
					{
						float num8 = default(float);
						int num7 = Mathf.FloorToInt(num8);
						if (num7 < array4.Length)
						{
							FsmColor fsmColor2 = array4[num7];
							FsmColor[] array5 = colors;
							int num9 = Mathf.CeilToInt(num8);
							if (num9 < array5.Length)
							{
								FsmColor fsmColor3 = array5[num9];
								float num10 = Mathf.Floor(num8);
								realtimeSinceStartup = num8 - num10;
								Color a = default(Color);
								a.r = fsmColor2.value.r;
								a.g = fsmColor2.value.g;
								a.b = fsmColor2.value.b;
								a.a = fsmColor2.value.a;
								Color b = default(Color);
								b.r = fsmColor3.value.r;
								b.g = fsmColor3.value.g;
								b.b = fsmColor3.value.b;
								b.a = fsmColor3.value.a;
								value4 = Color.Lerp(a, b, realtimeSinceStartup);
								g = value4.g;
								b2 = value4.b;
								a2 = value4.a;
								goto IL_05bc;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_05a5:
			FsmColor fsmColor4 = array3[0];
			value4 = fsmColor4.value;
			g = fsmColor4.value.g;
			b2 = fsmColor4.value.b;
			a2 = fsmColor4.value.a;
			goto IL_05bc;
			IL_05bc:
			FsmColor fsmColor5 = storeColor;
			fsmColor5.value = value4;
			fsmColor5.value.g = g;
			fsmColor5.value.b = b2;
			fsmColor5.value.a = a2;
		}

		[Token(Token = "0x60008DE")]
		[Address(RVA = "0xA9108C", Offset = "0xA9108C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAF078]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221F4]) = v38;\nL_0013:\n\tv39 = this.colors;\n\tv48 = v39.Length - 1;\n\tv49 = v48 < 0;\n\tv50 = v48 == 0;\n\tv51 = v39.Length ^ 1;\n\tv52 = v39.Length ^ v48;\n\tv53 = v51 & v52;\n\tv54 = v53 < 0;\n\tv56 = v49 == v54;\n\tv57 = ~v50;\n\tv58 = v56 & v57;\n\tv59 = ~v58;\n\tif (v59) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_0031:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			//IL_0015: Expected O, but got I4
			FsmColor[] array = colors;
			object obj = array.Length - 1;
			bool flag = (long)(IntPtr)obj < 0L;
			bool flag2 = obj == null;
			int num = array.Length ^ 1;
			int num2 = (int)((long)array.Length ^ (long)(IntPtr)obj);
			int num3 = num & num2;
			bool flag3 = num3 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (flag4 && flag5)
			{
				return null;
			}
			return "Define at least 2 colors to make a gradient.";
		}

		[Token(Token = "0x60008DF")]
		[Address(RVA = "0xA910F4", Offset = "0xA910F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorInterpolate()
		{
		}
	}
}
