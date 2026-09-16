using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x754BCC", Offset = "0x754BCC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x754BCC", Offset = "0x754BCC")]
	[Token(Token = "0x20001A2")]
	public class ColorRamp : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACDA8", Offset = "0x7ACDA8")]
		[Token(Token = "0x4001323")]
		[FieldOffset(Offset = "0x50")]
		public FsmColor[] colors;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACDF4", Offset = "0x7ACDF4")]
		[Token(Token = "0x4001324")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat sampleAt;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7ACE40", Offset = "0x7ACE40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACE40", Offset = "0x7ACE40")]
		[Token(Token = "0x4001325")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor storeColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7ACEA0", Offset = "0x7ACEA0")]
		[Token(Token = "0x4001326")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x60008E0")]
		[Address(RVA = "0xA910FC", Offset = "0xA910FC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F07B68]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221F5]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (HutongGames.PlayMaker.FsmColor[]), typeof(HutongGames.PlayMaker.FsmColor[]), 3\n\tthis.colors = v43;\n\tv46 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.sampleAt = v46;\n\tthis.storeColor = 0;\n\tthis.everyFrame = 0;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmColor[] array = new FsmColor[3];
			colors = array;
			FsmFloat fsmFloat = 0f;
			sampleAt = fsmFloat;
			storeColor = null;
			everyFrame = false;
		}

		[Token(Token = "0x60008E1")]
		[Address(RVA = "0xA91168", Offset = "0xA91168", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ColorRamp::DoColorRamp(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoColorRamp();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60008E2")]
		[Address(RVA = "0xA91398", Offset = "0xA91398", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.ColorRamp::DoColorRamp(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoColorRamp();
		}

		[Token(Token = "0x60008E3")]
		[Address(RVA = "0xA911A4", Offset = "0xA911A4", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1F10B50]);\n\tv31 = *([v30 @ X8_v33]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20221F6]) = v50;\nL_0019:\n\tv51 = this.colors;\n\tv52 = this.colors == 0;\n\tif (v52) goto L_0081;\n\tv54 = v51.Length == 0;\n\tif (v54) goto L_0081;\n\tv132 = this.sampleAt == 0;\n\tif (v132) goto L_0081;\n\tv133 = this.storeColor == 0;\n\tif (v133) goto L_0081;\n\tv220 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sampleAt);\n\tv221 = this.colors;\n\tgoto L_003B;\n\tv327 = *([v225 @ X0_v10+E0]);\n\tv328 = v327 == 0;\n\tv329 = ~v328;\n\tif (v329) goto L_003B;\n\tv331 = \"il2cpp_codegen_runtime_class_init\"(v225, v126, v34, v35, v36, v37, v38, v39, v220, v41, v42, v43, v44, v45, v46, v47);\nL_003B:\n\tv317 = v221.Length - 1;\n\tv301 = UnityEngine.Mathf::Clamp(v220, 0f, v317);\n\tv323 = this.colors;\n\tv252 = v301 != 0;\n\tif (v252) goto L_005F;\n\tv337 = v323.Length == 0;\n\tif (v337) goto L_00CE;\n\tv364 = v323[0];\n\tv346 = v323[0] == 0;\n\tv311 = ~v346;\n\tif (v311) goto L_006B;\n\tgoto L_00CD;\nL_005F:\n\tv253 = v301 != v323.Length;\n\tif (v253) goto L_0086;\n\tv338 = v323.Length == 0;\n\tif (v338) goto L_00CE;\n\tv369 = v323.Length << 0x20;\n\tv370 = 0xFFFFFFFF00000000 + v369;\n\tv246 = v370 >> 0x1D;\n\tv371 = v323 + v246;\n\tv364 = *([v371 @ X8_v27+20]);\nL_006B:\n\tv124 = v364.value;\n\tv118 = v364.value.g;\n\tv116 = v364.value.b;\n\tv81 = v364.value.a;\nL_006F:\n\tv135 = this.storeColor;\n\tv135.value = v124;\n\tv135.value.g = v118;\n\tv135.value.b = v116;\n\tv135.value.a = v81;\nL_0081:\n\treturn;\nL_0086:\n\tgoto L_008E;\n\tv372 = *([v347 @ X0_v14+E0]);\n\tv373 = v372 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_008E;\n\tv376 = \"il2cpp_codegen_runtime_class_init\"(v347, v126, v34, v35, v36, v37, v38, v39, v302, v297, v295, v43, v44, v45, v46, v47);\nL_008E:\n\tv307 = UnityEngine.Mathf::FloorToInt(v301);\n\tv393 = v307 < v323.Length;\n\tv292 = ~v393;\n\tif (v292) goto L_00CE;\n\tv320 = v323[v307 @ X0_v17 (System.Int32)];\n\tv324 = this.colors;\n\tv308 = UnityEngine.Mathf::CeilToInt(v301);\n\tv396 = v308 < v324.Length;\n\tv293 = ~v396;\n\tif (v293) goto L_00CE;\n\tv321 = v324[v308 @ X0_v19 (System.Int32)];\n\tv398 = UnityEngine.Mathf::Floor(v301);\n\tv399 = v301 - v398;\n\t// 197 MakeStruct v380 @ AGGA91378_0_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v320.value (UnityEngine.Color), v320.value.g (System.Single), v320.value.b (System.Single), v320.value.a (System.Single)\n\t// 198 MakeStruct v379 @ AGGA91378_1_v5 (UnityEngine.Color), typeof(UnityEngine.Color), v321.value (UnityEngine.Color), v321.value.g (System.Single), v321.value.b (System.Single), v321.value.a (System.Single)\n\tv124 = UnityEngine.Color::Lerp(v380, v379, v399);\n\tv118 = v124.g;\n\tv116 = v124.b;\n\tv81 = v124.a;\n\tgoto L_006F;\nL_00CD:\n\tv326 = new System.NullReferenceException();\nL_00CE:\n\tv343 = new System.IndexOutOfRangeException();\n\tthrow v343;\n\treturn;\n// 127 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoColorRamp()
		{
			//IL_01aa: Expected O, but got I8
			//IL_01c7: Expected O, but got I
			//IL_01d7: Expected O, but got I
			FsmColor[] array = colors;
			if (colors == null || array.Length == 0 || sampleAt == null || storeColor == null)
			{
				return;
			}
			float value = sampleAt.Value;
			FsmColor[] array2 = colors;
			float max = (float)array2.Length - float.Epsilon;
			float num = Mathf.Clamp(value, 0f, max);
			FsmColor[] array3 = colors;
			FsmColor fsmColor;
			Color value2;
			float g;
			float b2;
			float a2;
			if (num == 0f)
			{
				if (array3.Length != 0)
				{
					fsmColor = array3[0];
					if (array3[0] != null)
					{
						goto IL_01dc;
					}
					NullReferenceException ex = new NullReferenceException();
				}
			}
			else if (num == (float)array3.Length)
			{
				if (array3.Length != 0)
				{
					int num2 = array3.Length << 32;
					object obj = -4294967296L + num2;
					int num3 = (int)((long)(IntPtr)obj >> 29);
					object obj2 = (long)(IntPtr)array3 + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X8_v27+20]");
					fsmColor = (FsmColor)0;
					goto IL_01dc;
				}
			}
			else
			{
				int num4 = Mathf.FloorToInt(num);
				if (num4 < array3.Length)
				{
					FsmColor fsmColor2 = array3[num4];
					FsmColor[] array4 = colors;
					int num5 = Mathf.CeilToInt(num);
					if (num5 < array4.Length)
					{
						FsmColor fsmColor3 = array4[num5];
						float num6 = Mathf.Floor(num);
						float t = num - num6;
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
						value2 = Color.Lerp(a, b, t);
						g = value2.g;
						b2 = value2.b;
						a2 = value2.a;
						goto IL_0478;
					}
				}
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_0478:
			FsmColor fsmColor4 = storeColor;
			fsmColor4.value = value2;
			fsmColor4.value.g = g;
			fsmColor4.value.b = b2;
			fsmColor4.value.a = a2;
			return;
			IL_01dc:
			value2 = fsmColor.value;
			g = fsmColor.value.g;
			b2 = fsmColor.value.b;
			a2 = fsmColor.value.a;
			goto IL_0478;
		}

		[Token(Token = "0x60008E4")]
		[Address(RVA = "0xA9139C", Offset = "0xA9139C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE2CE8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221F7]) = v38;\nL_0013:\n\tv39 = this.colors;\n\tv48 = v39.Length - 2;\n\tv49 = v48 < 0;\n\tv51 = v39.Length ^ 2;\n\tv52 = v39.Length ^ v48;\n\tv53 = v51 & v52;\n\tv54 = v53 < 0;\n\tv56 = v49 == v54;\n\tv57 = ~v56;\n\tv58 = ~v57;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			//IL_0015: Expected O, but got I4
			FsmColor[] array = colors;
			object obj = array.Length - 2;
			bool flag = (long)(IntPtr)obj < 0L;
			int num = array.Length ^ 2;
			int num2 = (int)((long)array.Length ^ (long)(IntPtr)obj);
			int num3 = num & num2;
			bool flag2 = num3 < 0;
			if (flag != flag2)
			{
				return "Define at least 2 colors to make a gradient.";
			}
			return null;
		}

		[Token(Token = "0x60008E5")]
		[Address(RVA = "0xA91404", Offset = "0xA91404", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ColorRamp()
		{
		}
	}
}
