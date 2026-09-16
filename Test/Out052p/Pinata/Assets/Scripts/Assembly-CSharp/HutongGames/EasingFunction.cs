using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames
{
	[Token(Token = "0x200006D")]
	public class EasingFunction
	{
		[Token(Token = "0x2000476")]
		public enum Ease
		{
			[Token(Token = "0x40020E9")]
			EaseInQuad = 0,
			[Token(Token = "0x40020EA")]
			EaseOutQuad = 1,
			[Token(Token = "0x40020EB")]
			EaseInOutQuad = 2,
			[Token(Token = "0x40020EC")]
			EaseInCubic = 3,
			[Token(Token = "0x40020ED")]
			EaseOutCubic = 4,
			[Token(Token = "0x40020EE")]
			EaseInOutCubic = 5,
			[Token(Token = "0x40020EF")]
			EaseInQuart = 6,
			[Token(Token = "0x40020F0")]
			EaseOutQuart = 7,
			[Token(Token = "0x40020F1")]
			EaseInOutQuart = 8,
			[Token(Token = "0x40020F2")]
			EaseInQuint = 9,
			[Token(Token = "0x40020F3")]
			EaseOutQuint = 10,
			[Token(Token = "0x40020F4")]
			EaseInOutQuint = 11,
			[Token(Token = "0x40020F5")]
			EaseInSine = 12,
			[Token(Token = "0x40020F6")]
			EaseOutSine = 13,
			[Token(Token = "0x40020F7")]
			EaseInOutSine = 14,
			[Token(Token = "0x40020F8")]
			EaseInExpo = 15,
			[Token(Token = "0x40020F9")]
			EaseOutExpo = 16,
			[Token(Token = "0x40020FA")]
			EaseInOutExpo = 17,
			[Token(Token = "0x40020FB")]
			EaseInCirc = 18,
			[Token(Token = "0x40020FC")]
			EaseOutCirc = 19,
			[Token(Token = "0x40020FD")]
			EaseInOutCirc = 20,
			[Token(Token = "0x40020FE")]
			Linear = 21,
			[Token(Token = "0x40020FF")]
			Spring = 22,
			[Token(Token = "0x4002100")]
			EaseInBounce = 23,
			[Token(Token = "0x4002101")]
			EaseOutBounce = 24,
			[Token(Token = "0x4002102")]
			EaseInOutBounce = 25,
			[Token(Token = "0x4002103")]
			EaseInBack = 26,
			[Token(Token = "0x4002104")]
			EaseOutBack = 27,
			[Token(Token = "0x4002105")]
			EaseInOutBack = 28,
			[Token(Token = "0x4002106")]
			EaseInElastic = 29,
			[Token(Token = "0x4002107")]
			EaseOutElastic = 30,
			[Token(Token = "0x4002108")]
			EaseInOutElastic = 31,
			[Token(Token = "0x4002109")]
			CustomCurve = 32
		}

		[Token(Token = "0x2000477")]
		public delegate float Function(float s, float e, float v);

		[Token(Token = "0x40002BB")]
		private const float NATURAL_LOG_OF_2 = 0.6931472f;

		[Token(Token = "0x40002BC")]
		public static AnimationCurve AnimationCurve;

		[Token(Token = "0x60002BF")]
		[Address(RVA = "0xA0C26C", Offset = "0xA0C26C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EC4738]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CCB]) = v44;\nL_001D:\n\tgoto L_002E;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002E;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_002E:\n\treturnVal1 = UnityEngine.Mathf::Lerp(start, end, value);\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Linear(float start, float end, float value)
		{
			return Mathf.Lerp(start, end, value);
		}

		[Token(Token = "0x60002C0")]
		[Address(RVA = "0xA0C2F4", Offset = "0xA0C2F4", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EA8CE8]);\n\tv33 = *([v32 @ X8_v12]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, start, end, value, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([2021CCC]) = v50;\nL_0020:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, v35, v36, v37, v38, v39, v40, v41, start, end, value, v42, v43, v44, v45, v46);\nL_0028:\n\tv66 = UnityEngine.Mathf::Clamp01(value);\n\tv73 = v66 * 2.5f;\n\tv74 = v66 * v73;\n\tv75 = v66 * v74;\n\tv76 = v66 * 3.1415927f;\n\tv77 = v75 + 0.2f;\n\tv78 = v76 * v77;\n\tv79 = 0x6D2D20(0, v35, v36, v37, v38, v39, v40, v41, v78, v76, 0.2f, v42, v43, v44, v45, v46);\n\tv83 = 1f - v66;\n\tv86 = 0x6D1A90(v79, v35, v36, v37, v38, v39, v40, v41, v83, 2.2f, 0.2f, v42, v43, v44, v45, v46);\n\tv89 = v78 * v83;\n\tv90 = v66 + v89;\n\tv93 = v83 * 1.2f;\n\tv94 = v93 + 1f;\n\tv95 = v94 * v90;\n\tv96 = end - start;\n\tv97 = v96 * v95;\n\treturnVal1 = v97 + start;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Spring(float start, float end, float value)
		{
			float num = Mathf.Clamp01(value);
			float num2 = num * 2.5f;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = num * (float)Math.PI;
			float num6 = num4 + 0.2f;
			float num7 = num5 * num6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num8 = 1f - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1A90 (native powf)");
			float num9 = num7 * num8;
			float num10 = num + num9;
			float num11 = num8 * 1.2f;
			float num12 = num11 + 1f;
			float num13 = num12 * num10;
			float num14 = end - start;
			float num15 = num14 * num13;
			return num15 + start;
		}

		[Token(Token = "0x60002C1")]
		[Address(RVA = "0xA0C3F8", Offset = "0xA0C3F8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\treturnVal1 = v5 + start;\n\treturn returnVal1;\n")]
		public static float EaseInQuad(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			return num3 + start;
		}

		[Token(Token = "0x60002C2")]
		[Address(RVA = "0xA0C40C", Offset = "0xA0C40C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = v0 * value;\n\tv6 = value + -2f;\n\tv7 = v4 * v6;\n\treturnVal1 = start - v7;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuad(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = value + -2f;
			float num4 = num2 * num3;
			return start - num4;
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0xA0C428", Offset = "0xA0C428", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0015;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv31 = v0 * v18;\n\tgoto L_001C;\nL_0015:\n\tv22 = v0 + -1f;\n\tv23 = v12 * -0.5f;\n\tv25 = v22 + -2f;\n\tv26 = v22 * v25;\n\tv27 = v26 + -1f;\n\tv31 = v23 * v27;\nL_001C:\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuad(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num5;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				num5 = num * num4;
			}
			else
			{
				float num6 = num + -1f;
				float num7 = num2 * -0.5f;
				float num8 = num6 + -2f;
				float num9 = num6 * num8;
				float num10 = num9 + -1f;
				num5 = num7 * num10;
			}
			return num5 + start;
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0xA0C47C", Offset = "0xA0C47C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\treturnVal1 = v6 + start;\n\treturn returnVal1;\n")]
		public static float EaseInCubic(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			return num4 + start;
		}

		[Token(Token = "0x60002C5")]
		[Address(RVA = "0xA0C494", Offset = "0xA0C494", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv6 = end - start;\n\tv9 = v4 + 1f;\n\tv10 = v6 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutCubic(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = end - start;
			float num5 = num3 + 1f;
			float num6 = num4 * num5;
			return num6 + start;
		}

		[Token(Token = "0x60002C6")]
		[Address(RVA = "0xA0C4BC", Offset = "0xA0C4BC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0015;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv32 = v0 * v19;\n\tgoto L_001D;\nL_0015:\n\tv22 = v0 + -2f;\n\tv23 = v22 * v22;\n\tv25 = v22 * v23;\n\tv27 = v12 * 0.5f;\n\tv28 = v25 + 2f;\n\tv32 = v27 * v28;\nL_001D:\n\treturnVal1 = v32 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutCubic(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num6;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				num6 = num * num5;
			}
			else
			{
				float num7 = num + -2f;
				float num8 = num7 * num7;
				float num9 = num7 * num8;
				float num10 = num2 * 0.5f;
				float num11 = num9 + 2f;
				num6 = num10 * num11;
			}
			return num6 + start;
		}

		[Token(Token = "0x60002C7")]
		[Address(RVA = "0xA0C514", Offset = "0xA0C514", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\tv7 = v6 * value;\n\treturnVal1 = v7 + start;\n\treturn returnVal1;\n")]
		public static float EaseInQuart(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			float num5 = num4 * value;
			return num5 + start;
		}

		[Token(Token = "0x60002C8")]
		[Address(RVA = "0xA0C530", Offset = "0xA0C530", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv5 = v1 * v4;\n\tv6 = end - start;\n\tv9 = v5 + -1f;\n\tv10 = v6 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuart(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = end - start;
			float num6 = num4 + -1f;
			float num7 = num5 * num6;
			return start - num7;
		}

		[Token(Token = "0x60002C9")]
		[Address(RVA = "0xA0C558", Offset = "0xA0C558", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0017;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv20 = v0 * v19;\n\tv33 = v0 * v20;\n\tgoto L_001E;\nL_0017:\n\tv24 = v0 + -2f;\n\tv25 = v12 * -0.5f;\n\tv26 = v24 * v24;\n\tv27 = v24 * v26;\n\tv28 = v24 * v27;\n\tv29 = v28 + -2f;\n\tv33 = v25 * v29;\nL_001E:\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuart(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num7;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				float num6 = num * num5;
				num7 = num * num6;
			}
			else
			{
				float num8 = num + -2f;
				float num9 = num2 * -0.5f;
				float num10 = num8 * num8;
				float num11 = num8 * num10;
				float num12 = num8 * num11;
				float num13 = num12 + -2f;
				num7 = num9 * num13;
			}
			return num7 + start;
		}

		[Token(Token = "0x60002CA")]
		[Address(RVA = "0xA0C5B4", Offset = "0xA0C5B4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * value;\n\tv5 = v3 * value;\n\tv6 = v5 * value;\n\tv7 = v6 * value;\n\tv8 = v7 * value;\n\treturnVal1 = v8 + start;\n\treturn returnVal1;\n")]
		public static float EaseInQuint(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = num3 * value;
			float num5 = num4 * value;
			float num6 = num5 * value;
			return num6 + start;
		}

		[Token(Token = "0x60002CB")]
		[Address(RVA = "0xA0C5D4", Offset = "0xA0C5D4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = value + -1f;\n\tv3 = v1 * v1;\n\tv4 = v1 * v3;\n\tv5 = v1 * v4;\n\tv6 = v1 * v5;\n\tv8 = end - start;\n\tv11 = v6 + 1f;\n\tv12 = v8 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuint(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * num;
			float num3 = num * num2;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = end - start;
			float num7 = num5 + 1f;
			float num8 = num6 * num7;
			return num8 + start;
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xA0C604", Offset = "0xA0C604", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0017;\n\tv17 = v12 * 0.5f;\n\tv18 = v17 * v0;\n\tv19 = v0 * v18;\n\tv20 = v0 * v19;\n\tv21 = v0 * v20;\n\tv36 = v0 * v21;\n\tgoto L_0021;\nL_0017:\n\tv24 = v0 + -2f;\n\tv25 = v24 * v24;\n\tv26 = v24 * v25;\n\tv27 = v24 * v26;\n\tv29 = v24 * v27;\n\tv31 = v12 * 0.5f;\n\tv32 = v29 + 2f;\n\tv36 = v31 * v32;\nL_0021:\n\treturnVal1 = v36 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuint(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num8;
			if (num < 1f)
			{
				float num3 = num2 * 0.5f;
				float num4 = num3 * num;
				float num5 = num * num4;
				float num6 = num * num5;
				float num7 = num * num6;
				num8 = num * num7;
			}
			else
			{
				float num9 = num + -2f;
				float num10 = num9 * num9;
				float num11 = num9 * num10;
				float num12 = num9 * num11;
				float num13 = num9 * num12;
				float num14 = num2 * 0.5f;
				float num15 = num13 + 2f;
				num8 = num14 * num15;
			}
			return num8 + start;
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xA0C66C", Offset = "0xA0C66C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EDF500]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CCD]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 1.5707964f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv63 = v47 * v61;\n\tv64 = v47 - v63;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			float num3 = num * num2;
			float num4 = num - num3;
			return num4 + start;
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xA0C704", Offset = "0xA0C704", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA6AC0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CCE]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 1.5707964f;\n\tv62 = 0x6D2D20(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv63 = v47 * v61;\n\treturnVal1 = v63 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num3 = num * num2;
			return num3 + start;
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xA0C798", Offset = "0xA0C798", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EAA570]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CCF]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 3.1415927f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv65 = v47 * -0.5f;\n\tv66 = v61 + -1f;\n\tv67 = v65 * v66;\n\treturnVal1 = v67 + start;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutSine(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * (float)Math.PI;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			float num3 = num * -0.5f;
			float num4 = num2 + -1f;
			float num5 = num3 * num4;
			return num5 + start;
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xA0C83C", Offset = "0xA0C83C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA3B28]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD0]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value + -1f;\n\tv62 = v60 * 10f;\n\tv63 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v62, 10f, value, v36, v37, v38, v39, v40);\n\tv64 = v47 * v62;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInExpo(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num2 * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xA0C8D4", Offset = "0xA0C8D4", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA57C0]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD1]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value * -10f;\n\tv61 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v60, end, value, v36, v37, v38, v39, v40);\n\tv63 = 1f - v60;\n\tv64 = v47 * v63;\n\treturnVal1 = v64 + start;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutExpo(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * -10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num3 = 1f - num2;
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xA0C96C", Offset = "0xA0C96C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA6110]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD2]) = v44;\nL_0019:\n\tv47 = value + value;\n\tv58 = end - start;\n\tv59 = v47 >= 1f;\n\tif (v59) goto L_003B;\n\tgoto L_0032;\n\tv70 = *([v60 @ X0_v7 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0032;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, v29, v30, v31, v32, v33, v34, v35, v48, end, value, v36, v37, v38, v39, v40);\nL_0032:\n\tv78 = v47 + -1f;\n\tv100 = v78 * 10f;\n\tv81 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v100, 10f, value, v36, v37, v38, v39, v40);\n\tv99 = v58 * 0.5f;\n\tgoto L_004C;\nL_003B:\n\tv66 = v47 + -1f;\n\tgoto L_0046;\n\tv82 = *([v64 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0046;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v64, v29, v30, v31, v32, v33, v34, v35, v65, end, value, v36, v37, v38, v39, v40);\nL_0046:\n\tv90 = v66 * -10f;\n\tv91 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v90, end, value, v36, v37, v38, v39, v40);\n\tv99 = v58 * 0.5f;\n\tv100 = 2f - v90;\nL_004C:\n\tv105 = v99 * v100;\n\treturnVal1 = v105 + start;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutExpo(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num4;
			float num5;
			if (num < 1f)
			{
				float num3 = num + -1f;
				num4 = num3 * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				num5 = num2 * 0.5f;
			}
			else
			{
				float num6 = num + -1f;
				float num7 = num6 * -10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				num5 = num2 * 0.5f;
				num4 = 2f - num7;
			}
			float num8 = num5 * num4;
			return num8 + start;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0xA0CA5C", Offset = "0xA0CA5C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EEB098]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD3]) = v44;\nL_001D:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0023:\n\tv58 = value * value;\n\tv60 = 1f - v58;\n\tv75 = UnityEngine.Mathf::Sqrt(v60);\n\tv64 = v75 - v75;\n\tv67 = v75 ^ v75;\n\tv68 = v75 ^ v64;\n\tv69 = v67 & v68;\n\tv70 = v69 < 0;\n\tv71 = end - start;\n\tv72 = ~v70;\n\tif (v72) goto L_0036;\n\tv74 = 0x6D2F50(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v60, v60, value, v36, v37, v38, v39, v40);\nL_0036:\n\tv78 = v75 + -1f;\n\tv79 = v71 * v78;\n\treturnVal1 = start - v79;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInCirc(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			float num = value * value;
			float num2 = 1f - num;
			float num3 = Mathf.Sqrt(num2);
			float num4 = num3 - num3;
			object obj = num3 ^ num3;
			object obj2 = num3 ^ num4;
			int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num5 < 0;
			float num6 = end - start;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num3 = num2;
			}
			float num7 = num3 + -1f;
			float num8 = num6 * num7;
			return start - num8;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0xA0CB08", Offset = "0xA0CB08", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EBDF20]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD4]) = v44;\nL_001A:\n\tv48 = value + -1f;\n\tgoto L_0025;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0025;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v29, v30, v31, v32, v33, v34, v35, v47, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = v48 * v48;\n\tv62 = 1f - v60;\n\tv77 = UnityEngine.Mathf::Sqrt(v62);\n\tv66 = v77 - v77;\n\tv69 = v77 ^ v77;\n\tv70 = v77 ^ v66;\n\tv71 = v69 & v70;\n\tv72 = v71 < 0;\n\tv73 = end - start;\n\tv74 = ~v72;\n\tif (v74) goto L_0037;\n\tv76 = 0x6D2F50(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v62, v62, value, v36, v37, v38, v39, v40);\nL_0037:\n\tv79 = v73 * v77;\n\treturnVal1 = v79 + start;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutCirc(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			float num = value + -1f;
			float num2 = num * num;
			float num3 = 1f - num2;
			float num4 = Mathf.Sqrt(num3);
			float num5 = num4 - num4;
			object obj = num4 ^ num4;
			object obj2 = num4 ^ num5;
			int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num6 < 0;
			float num7 = end - start;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num4 = num3;
			}
			float num8 = num7 * num4;
			return num8 + start;
		}

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0xA0CBB4", Offset = "0xA0CBB4", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EF0BA0]);\n\tv31 = *([v30 @ X8_v13]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([2021CD5]) = v48;\nL_001B:\n\tv51 = value + value;\n\tv62 = v51 >= 1f;\n\tif (v62) goto L_0038;\n\tgoto L_0032;\n\tv73 = *([v63 @ X0_v8 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0032;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v63, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\nL_0032:\n\tv95 = v51 * v51;\n\tgoto L_0045;\nL_0038:\n\tv69 = v51 + -2f;\n\tgoto L_0042;\n\tv83 = *([v67 @ X0_v5 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0042;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v67, v33, v34, v35, v36, v37, v38, v39, v68, end, value, v40, v41, v42, v43, v44);\nL_0042:\n\tv95 = v69 * v69;\nL_0045:\n\tv99 = 1f - v95;\n\tv114 = UnityEngine.Mathf::Sqrt(v99);\n\tv103 = v114 - v114;\n\tv106 = v114 ^ v114;\n\tv107 = v114 ^ v103;\n\tv108 = v106 & v107;\n\tv109 = v108 < 0;\n\tv110 = end - start;\n\tv111 = ~v109;\n\tif (v111) goto L_0055;\n\tv113 = 0x6D2F50(v96, v33, v34, v35, v36, v37, v38, v39, v99, v99, value, v40, v41, v42, v43, v44);\nL_0055:\n\tv116 = v110 * v93;\n\tv117 = v94 + v114;\n\tv118 = v116 * v117;\n\treturnVal1 = v118 + start;\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutCirc(float start, float end, float value)
		{
			//IL_005c: Expected I, but got O
			//IL_0013: Expected I, but got O
			//IL_0149: Expected O, but got F4
			//IL_0156: Expected O, but got F4
			float num = value + value;
			float num2;
			float num3;
			float num4;
			if (num < 1f)
			{
				IntPtr intPtr = (IntPtr)typeof(Mathf);
				num2 = num * num;
				num3 = -0.5f;
				num4 = -1f;
			}
			else
			{
				float num5 = num + -2f;
				IntPtr intPtr = (IntPtr)typeof(Mathf);
				num2 = num5 * num5;
				num3 = 0.5f;
				num4 = 1f;
			}
			float num6 = 1f - num2;
			float num7 = Mathf.Sqrt(num6);
			float num8 = num7 - num7;
			object obj = num7 ^ num7;
			object obj2 = num7 ^ num8;
			int num9 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num9 < 0;
			float num10 = end - start;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num7 = num6;
			}
			float num11 = num10 * num3;
			float num12 = num4 + num7;
			float num13 = num11 * num12;
			return num13 + start;
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0xA0CCAC", Offset = "0xA0CCAC", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv15 = 1f - value;\n\tv19 = HutongGames.EasingFunction::EaseOutBounce(0f, v12, v15);\n\tv23 = v12 - v19;\n\treturnVal1 = v23 + start;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInBounce(float start, float end, float value)
		{
			float num = end - start;
			float value2 = 1f - value;
			float num2 = EaseOutBounce(0f, num, value2);
			float num3 = num - num2;
			return num3 + start;
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0xA0CCE8", Offset = "0xA0CCE8", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = end - start;\n\tv15 = value >= 0.36363637f;\n\tif (v15) goto L_001E;\n\tv18 = value * 7.5625f;\n\tv44 = v18 * value;\n\tgoto L_004C;\nL_001E:\n\tv31 = value >= 0.72727275f;\n\tif (v31) goto L_0036;\n\tv77 = value + -0.54545456f;\n\tv78 = v77 * 7.5625f;\n\tv79 = v77 * v78;\n\tv44 = v79 + 0.75f;\n\tgoto L_004C;\nL_0036:\n\tv49 = value >= 0.9090909090909091d;\n\tif (v49) goto L_0048;\n\tv85 = value + -0.8181818f;\n\tv86 = v85 * 7.5625f;\n\tv87 = v85 * v86;\n\tv44 = v87 + 0.9375f;\n\tgoto L_004C;\nL_0048:\n\tv91 = value + -0.95454544f;\n\tv67 = v91 * 7.5625f;\n\tv92 = v91 * v67;\n\tv44 = v92 + 0.984375f;\nL_004C:\n\tv74 = v2 * v44;\n\treturnVal1 = v74 + start;\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutBounce(float start, float end, float value)
		{
			float num = end - start;
			float num3;
			if (value < 0.36363637f)
			{
				float num2 = value * 7.5625f;
				num3 = num2 * value;
			}
			else if (value < 0.72727275f)
			{
				float num4 = value + -0.54545456f;
				float num5 = num4 * 7.5625f;
				float num6 = num4 * num5;
				num3 = num6 + 0.75f;
			}
			else if ((double)value < 0.9090909090909091)
			{
				float num7 = value + -0.8181818f;
				float num8 = num7 * 7.5625f;
				float num9 = num7 * num8;
				num3 = num9 + 0.9375f;
			}
			else
			{
				float num10 = value + -21f / 22f;
				float num11 = num10 * 7.5625f;
				float num12 = num10 * num11;
				num3 = num12 + 63f / 64f;
			}
			float num13 = num * num3;
			return num13 + start;
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0xA0CDB8", Offset = "0xA0CDB8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = end - start;\n\tv29 = value + value;\n\tv30 = value >= 0.5f;\n\tif (v30) goto L_0022;\n\tv32 = 1f - v29;\n\tv36 = HutongGames.EasingFunction::EaseOutBounce(0f, v17, v32);\n\tv43 = v17 - v36;\n\tv52 = v43 * 0.5f;\n\tgoto L_0029;\nL_0022:\n\tv39 = v29 + -1f;\n\tv42 = HutongGames.EasingFunction::EaseOutBounce(0f, v17, v39);\n\tv46 = v42 * 0.5f;\n\tv47 = v17 * 0.5f;\n\tv52 = v47 + v46;\nL_0029:\n\treturnVal1 = v52 + start;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutBounce(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + value;
			float num5;
			if (value < 0.5f)
			{
				float value2 = 1f - num2;
				float num3 = EaseOutBounce(0f, num, value2);
				float num4 = num - num3;
				num5 = num4 * 0.5f;
			}
			else
			{
				float value3 = num2 + -1f;
				float num6 = EaseOutBounce(0f, num, value3);
				float num7 = num6 * 0.5f;
				float num8 = num * 0.5f;
				num5 = num8 + num7;
			}
			return num5 + start;
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0xA0CE3C", Offset = "0xA0CE3C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = end - start;\n\tv7 = v4 * value;\n\tv9 = v7 * value;\n\tv10 = value * 2.70158f;\n\tv11 = v10 + -1.70158f;\n\tv12 = v9 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInBack(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * value;
			float num3 = num2 * value;
			float num4 = value * 2.70158f;
			float num5 = num4 + -1.70158f;
			float num6 = num3 * num5;
			return num6 + start;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0xA0CE6C", Offset = "0xA0CE6C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = value + -1f;\n\tv7 = v4 * 2.70158f;\n\tv8 = v4 * v4;\n\tv9 = end - start;\n\tv12 = v7 + 1.70158f;\n\tv13 = v8 * v12;\n\tv15 = v13 + 1f;\n\tv16 = v9 * v15;\n\treturnVal1 = v16 + start;\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutBack(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * 2.70158f;
			float num3 = num * num;
			float num4 = end - start;
			float num5 = num2 + 1.70158f;
			float num6 = num3 * num5;
			float num7 = num6 + 1f;
			float num8 = num4 * num7;
			return num8 + start;
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0xA0CEAC", Offset = "0xA0CEAC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_001C;\n\tv45 = v12 * 0.5f;\n\tv22 = v0 * v0;\n\tv23 = v0 * 3.5949094f;\n\tv24 = v23 + -2.5949094f;\n\tv47 = v22 * v24;\n\tgoto L_0027;\nL_001C:\n\tv29 = v0 + -2f;\n\tv45 = v12 * 0.5f;\n\tv34 = v29 * v29;\n\tv35 = v29 * 3.5949094f;\n\tv36 = v35 + 2.5949094f;\n\tv37 = v34 * v36;\n\tv47 = v37 + 2f;\nL_0027:\n\tv48 = v45 * v47;\n\treturnVal1 = v48 + start;\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutBack(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3;
			float num7;
			if (num < 1f)
			{
				num3 = num2 * 0.5f;
				float num4 = num * num;
				float num5 = num * 3.5949094f;
				float num6 = num5 + -2.5949094f;
				num7 = num4 * num6;
			}
			else
			{
				float num8 = num + -2f;
				num3 = num2 * 0.5f;
				float num9 = num8 * num8;
				float num10 = num8 * 3.5949094f;
				float num11 = num10 + 2.5949094f;
				float num12 = num9 * num11;
				num7 = num12 + 2f;
			}
			float num13 = num3 * num7;
			return num13 + start;
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0xA0CF30", Offset = "0xA0CF30", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EF9668]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2021CD6]) = v46;\nL_001C:\n\tv51 = value == 0;\n\tif (v51) goto L_0059;\n\tv66 = end - start;\n\tv67 = value != 1f;\n\tif (v67) goto L_0034;\n\tv93 = v66 + start;\n\tgoto L_0059;\nL_0034:\n\tv76 = value + -1f;\n\tgoto L_0040;\n\tv116 = *([v112 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0040;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v112, v31, v32, v33, v34, v35, v36, v37, v111, end, value, v38, v39, v40, v41, v42);\nL_0040:\n\tv123 = v76 * 10f;\n\tv124 = 0x6D28C0(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v123, end, value, v38, v39, v40, v41, v42);\n\tv128 = v76 + -0.075f;\n\tv129 = v128 * 6.2831855f;\n\tv130 = v129 / 0.3f;\n\tv90 = 0x6D2D20(v124, v31, v32, v33, v34, v35, v36, v37, v130, 6.2831855f, 0.3f, v38, v39, v40, v41, v42);\n\tv71 = v66 * v123;\n\tv88 = v71 * v130;\n\tv93 = start - v88;\nL_0059:\n\treturn v93;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInElastic(float start, float end, float value)
		{
			bool flag = value == 0f;
			float result = start;
			if (!flag)
			{
				float num = end - start;
				if (value == 1f)
				{
					result = num + start;
				}
				else
				{
					float num2 = value + -1f;
					float num3 = num2 * 10f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
					float num4 = num2 + -0.075f;
					float num5 = num4 * ((float)Math.PI * 2f);
					float num6 = num5 / 0.3f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
					float num7 = num * num3;
					float num8 = num7 * num6;
					result = start - num8;
				}
			}
			return result;
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0xA0D018", Offset = "0xA0D018", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EF64E0]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2021CD7]) = v46;\nL_001C:\n\tv51 = value == 0;\n\tif (v51) goto L_0058;\n\tv66 = end - start;\n\tv67 = value != 1f;\n\tif (v67) goto L_0037;\n\tv92 = v66 + start;\n\tgoto L_0058;\nL_0037:\n\tgoto L_003E;\n\tv113 = *([v109 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003E;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v109, v31, v32, v33, v34, v35, v36, v37, v56, end, value, v38, v39, v40, v41, v42);\nL_003E:\n\tv120 = value * -10f;\n\tv121 = 0x6D28C0(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v120, end, value, v38, v39, v40, v41, v42);\n\tv125 = value + -0.075f;\n\tv126 = v125 * 6.2831855f;\n\tv127 = v126 / 0.3f;\n\tv89 = 0x6D2D20(v121, v31, v32, v33, v34, v35, v36, v37, v127, 6.2831855f, 0.3f, v38, v39, v40, v41, v42);\n\tv71 = v66 * v120;\n\tv128 = v71 * v127;\n\tv87 = v66 + v128;\n\tv92 = v87 + start;\nL_0058:\n\treturn v92;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutElastic(float start, float end, float value)
		{
			bool flag = value == 0f;
			float result = start;
			if (!flag)
			{
				float num = end - start;
				if (value == 1f)
				{
					result = num + start;
				}
				else
				{
					float num2 = value * -10f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
					float num3 = value + -0.075f;
					float num4 = num3 * ((float)Math.PI * 2f);
					float num5 = num4 / 0.3f;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
					float num6 = num * num2;
					float num7 = num6 * num5;
					float num8 = num + num7;
					result = num8 + start;
				}
			}
			return result;
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0xA0D0FC", Offset = "0xA0D0FC", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ED2150]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2021CD8]) = v46;\nL_001C:\n\tv51 = value == 0;\n\tif (v51) goto L_0085;\n\tv56 = value + value;\n\tv67 = end - start;\n\tv68 = v56 != 2f;\n\tif (v68) goto L_0040;\n\tv109 = v67 + start;\n\tgoto L_0085;\nL_0040:\n\tv74 = v56 + -1f;\n\tv79 = v56 >= 1f;\n\tif (v79) goto L_0062;\n\tgoto L_004D;\n\tv139 = *([v133 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_004D;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v133, v31, v32, v33, v34, v35, v36, v37, v56, v130, v131, v38, v39, v40, v41, v42);\nL_004D:\n\tv146 = v74 * 10f;\n\tv147 = 0x6D28C0(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v146, -1f, 1f, v38, v39, v40, v41, v42);\n\tv160 = v74 + -0.075f;\n\tv161 = v160 * 6.2831855f;\n\tv162 = v161 / 0.3f;\n\tv105 = 0x6D2D20(v147, v31, v32, v33, v34, v35, v36, v37, v162, 6.2831855f, 0.3f, v38, v39, v40, v41, v42);\n\tv169 = v67 * v146;\n\tv170 = v169 * v162;\n\tv102 = v170 * -0.5f;\n\tv109 = start + v102;\n\tgoto L_0085;\nL_0062:\n\tgoto L_0069;\n\tv148 = *([v133 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0069;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v133, v31, v32, v33, v34, v35, v36, v37, v56, v130, v131, v38, v39, v40, v41, v42);\nL_0069:\n\tv155 = v74 * -10f;\n\tv156 = 0x6D28C0(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v155, -1f, 1f, v38, v39, v40, v41, v42);\n\tv166 = v74 + -0.075f;\n\tv167 = v166 * 6.2831855f;\n\tv168 = v167 / 0.3f;\n\tv104 = 0x6D2D20(v156, v31, v32, v33, v34, v35, v36, v37, v168, 6.2831855f, 0.3f, v38, v39, v40, v41, v42);\n\tv171 = v67 * v155;\n\tv172 = v171 * v168;\n\tv173 = v172 * 0.5f;\n\tv101 = v67 + v173;\n\tv109 = v101 + start;\nL_0085:\n\treturn v109;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutElastic(float start, float end, float value)
		{
			bool flag = value == 0f;
			float result = start;
			if (!flag)
			{
				float num = value + value;
				float num2 = end - start;
				if (num == 2f)
				{
					result = num2 + start;
				}
				else
				{
					float num3 = num + -1f;
					if (num < 1f)
					{
						float num4 = num3 * 10f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
						float num5 = num3 + -0.075f;
						float num6 = num5 * ((float)Math.PI * 2f);
						float num7 = num6 / 0.3f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
						float num8 = num2 * num4;
						float num9 = num8 * num7;
						float num10 = num9 * -0.5f;
						result = start + num10;
					}
					else
					{
						float num11 = num3 * -10f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
						float num12 = num3 + -0.075f;
						float num13 = num12 * ((float)Math.PI * 2f);
						float num14 = num13 / 0.3f;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
						float num15 = num2 * num11;
						float num16 = num15 * num14;
						float num17 = num16 * 0.5f;
						float num18 = num2 + num17;
						result = num18 + start;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0xA0D260", Offset = "0xA0D260", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = end - start;\n\treturn returnVal1;\n")]
		public static float LinearD(float start, float end, float value)
		{
			return end - start;
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0xA0D268", Offset = "0xA0D268", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 + v0;\n\treturnVal1 = v3 * value;\n\treturn returnVal1;\n")]
		public static float EaseInQuadD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num + num;
			return num2 * value;
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0xA0D278", Offset = "0xA0D278", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = value + -2f;\n\tv6 = v0 * value;\n\tv7 = -v6;\n\tv8 = v0 * v4;\n\treturnVal1 = v7 - v8;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuadD(float start, float end, float value)
		{
			//IL_0037: Expected O, but got F4
			float num = end - start;
			float num2 = value + -2f;
			float num3 = num * value;
			object obj = 0f - num3;
			float num4 = num * num2;
			return (float)obj - num4;
		}

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0xA0D294", Offset = "0xA0D294", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv2 = end - start;\n\tv7 = v0 + -1f;\n\tv21 = 1f - v7;\n\tv18 = v0 >= 1f;\n\tif (v18) goto L_0015;\n\tgoto L_0015;\nL_0015:\n\treturnVal1 = v2 * v21;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuadD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3 = num + -1f;
			float num4 = 1f - num3;
			if (num < 1f)
			{
				num4 = num;
			}
			return num2 * num4;
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0xA0D2BC", Offset = "0xA0D2BC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = v0 * 3f;\n\tv5 = v4 * value;\n\treturnVal1 = v5 * value;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInCubicD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * 3f;
			float num3 = num2 * value;
			return num3 * value;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0xA0D2D4", Offset = "0xA0D2D4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = end - start;\n\tv5 = value + -1f;\n\tv7 = v1 * 3f;\n\tv8 = v7 * v5;\n\treturnVal1 = v5 * v8;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutCubicD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num * 3f;
			float num4 = num3 * num2;
			return num2 * num4;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0xA0D2F4", Offset = "0xA0D2F4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv2 = end - start;\n\tv21 = v0 + -2f;\n\tv18 = v0 >= 1f;\n\tif (v18) goto L_0015;\n\tgoto L_0015;\nL_0015:\n\tv22 = v2 * 1.5f;\n\tv23 = v22 * v21;\n\treturnVal1 = v21 * v23;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutCubicD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3 = num + -2f;
			if (num < 1f)
			{
				num3 = num;
			}
			float num4 = num2 * 1.5f;
			float num5 = num4 * num3;
			return num3 * num5;
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0xA0D324", Offset = "0xA0D324", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = v0 * 4f;\n\tv5 = v4 * value;\n\tv7 = v5 * value;\n\treturnVal1 = v7 * value;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInQuartD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * 4f;
			float num3 = num2 * value;
			float num4 = num3 * value;
			return num4 * value;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0xA0D340", Offset = "0xA0D340", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = end - start;\n\tv5 = value + -1f;\n\tv7 = v1 * -4f;\n\tv8 = v7 * v5;\n\tv9 = v5 * v8;\n\treturnVal1 = v5 * v9;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuartD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num * -4f;
			float num4 = num3 * num2;
			float num5 = num2 * num4;
			return num2 * num5;
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0xA0D364", Offset = "0xA0D364", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = value + value;\n\tv3 = end - start;\n\tv17 = v25 + -2f;\n\tv18 = v25 >= 1f;\n\tif (v18) goto L_FFFFFFFF;\n\tgoto L_0015;\nL_0015:\n\tv22 = v25 >= 1f;\n\tif (v22) goto L_FFFFFFFF;\n\tgoto L_001B;\nL_001B:\n\tv26 = v3 * v21;\n\tv27 = v25 * v26;\n\tv28 = v25 * v27;\n\treturnVal1 = v25 * v28;\n\treturn returnVal1;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuartD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3 = num + -2f;
			float num4 = ((!(num < 1f)) ? (-2f) : 2f);
			if (!(num < 1f))
			{
				num = num3;
			}
			float num5 = num2 * num4;
			float num6 = num * num5;
			float num7 = num * num6;
			return num * num7;
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0xA0D39C", Offset = "0xA0D39C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = v0 * 5f;\n\tv5 = v4 * value;\n\tv7 = v5 * value;\n\tv8 = v7 * value;\n\treturnVal1 = v8 * value;\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInQuintD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * 5f;
			float num3 = num2 * value;
			float num4 = num3 * value;
			float num5 = num4 * value;
			return num5 * value;
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0xA0D3BC", Offset = "0xA0D3BC", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = end - start;\n\tv5 = value + -1f;\n\tv7 = v1 * 5f;\n\tv8 = v7 * v5;\n\tv9 = v5 * v8;\n\tv10 = v5 * v9;\n\treturnVal1 = v5 * v10;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutQuintD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num * 5f;
			float num4 = num3 * num2;
			float num5 = num2 * num4;
			float num6 = num2 * num5;
			return num2 * num6;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0xA0D3E4", Offset = "0xA0D3E4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv2 = end - start;\n\tv21 = v0 + -2f;\n\tv18 = v0 >= 1f;\n\tif (v18) goto L_0015;\n\tgoto L_0015;\nL_0015:\n\tv22 = v2 * 2.5f;\n\tv23 = v22 * v21;\n\tv24 = v21 * v23;\n\tv25 = v21 * v24;\n\treturnVal1 = v21 * v25;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutQuintD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			float num3 = num + -2f;
			if (num < 1f)
			{
				num3 = num;
			}
			float num4 = num2 * 2.5f;
			float num5 = num4 * num3;
			float num6 = num3 * num5;
			float num7 = num3 * num6;
			return num3 * num7;
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0xA0D41C", Offset = "0xA0D41C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB88A0]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CD9]) = v44;\nL_001D:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value * 1.5707964f;\n\tv61 = 0x6D2D20(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v60, end, value, v36, v37, v38, v39, v40);\n\tv64 = end - start;\n\tv71 = v64 * 0.5f;\n\tv72 = v71 * 3.1415927f;\n\treturnVal1 = v72 * v60;\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInSineD(float start, float end, float value)
		{
			float num = value * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num2 = end - start;
			float num3 = num2 * 0.5f;
			float num4 = num3 * (float)Math.PI;
			return num4 * num;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0xA0D4C0", Offset = "0xA0D4C0", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EF6658]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDA]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 1.5707964f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv63 = v47 * 1.5707964f;\n\treturnVal1 = v63 * v61;\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutSineD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * ((float)Math.PI / 2f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			float num3 = num * ((float)Math.PI / 2f);
			return num3 * num2;
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0xA0D554", Offset = "0xA0D554", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EBAEB8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDB]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0026:\n\tv61 = value * 3.1415927f;\n\tv62 = 0x6D3020(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, end, value, v36, v37, v38, v39, v40);\n\tv64 = v47 * 0.5f;\n\tv70 = v64 * 3.1415927f;\n\treturnVal1 = v70 * v61;\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutSineD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * (float)Math.PI;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			float num3 = num * 0.5f;
			float num4 = num3 * (float)Math.PI;
			return num4 * num2;
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0xA0D5F0", Offset = "0xA0D5F0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EB4AA8]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDC]) = v44;\nL_001D:\n\tgoto L_0024;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0024;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0024:\n\tv59 = value + -1f;\n\tv61 = v59 * 10f;\n\tv62 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v61, 10f, value, v36, v37, v38, v39, v40);\n\tv65 = end - start;\n\tv71 = v65 * 6.931472f;\n\treturnVal1 = v71 * v61;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInExpoD(float start, float end, float value)
		{
			float num = value + -1f;
			float num2 = num * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num3 = end - start;
			float num4 = num3 * 6.931472f;
			return num4 * num2;
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xA0D690", Offset = "0xA0D690", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE43F0]);\n\tv27 = *([v26 @ X8_v10]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDD]) = v44;\nL_0019:\n\tv47 = end - start;\n\tgoto L_0025;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0025;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = value * -10f;\n\tv62 = v60 + 1f;\n\tv63 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v62, 1f, value, v36, v37, v38, v39, v40);\n\tv69 = v47 * 3.465736f;\n\treturnVal1 = v69 * v62;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutExpoD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * -10f;
			float num3 = num2 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num4 = num * 3.465736f;
			return num4 * num3;
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0xA0D730", Offset = "0xA0D730", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE3DD8]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDE]) = v44;\nL_0019:\n\tv47 = value + value;\n\tv58 = end - start;\n\tv59 = v47 >= 1f;\n\tif (v59) goto L_003D;\n\tgoto L_0032;\n\tv70 = *([v60 @ X0_v7 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0032;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v60, v29, v30, v31, v32, v33, v34, v35, v48, end, value, v36, v37, v38, v39, v40);\nL_0032:\n\tv78 = v47 + -1f;\n\tv80 = v78 * 10f;\n\tv81 = 0x6D28C0(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v80, 10f, value, v36, v37, v38, v39, v40);\n\tv94 = v58 * 3.465736f;\n\treturnVal1 = v94 * v80;\n\tgoto L_0055;\nL_003D:\n\tv66 = v47 + -1f;\n\tgoto L_0048;\n\tv82 = *([v64 @ X0_v3+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0048;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v64, v29, v30, v31, v32, v33, v34, v35, v65, end, value, v36, v37, v38, v39, v40);\nL_0048:\n\tv90 = v66 * 10f;\n\tv91 = 0x6D28C0(*([1818000]), v29, v30, v31, v32, v33, v34, v35, v90, end, value, v36, v37, v38, v39, v40);\n\tv98 = v58 * 3.465736f;\n\treturnVal1 = v98 / v90;\nL_0055:\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutExpoD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			if (num < 1f)
			{
				float num3 = num + -1f;
				float num4 = num3 * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				float num5 = num2 * 3.465736f;
				return num5 * num4;
			}
			float num6 = num + -1f;
			float num7 = num6 * 10f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num8 = num2 * 3.465736f;
			return num8 / num7;
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0xA0D820", Offset = "0xA0D820", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EEA578]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CDF]) = v44;\nL_001D:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\nL_0023:\n\tv58 = value * value;\n\tv60 = 1f - v58;\n\tv74 = UnityEngine.Mathf::Sqrt(v60);\n\tv64 = v74 - v74;\n\tv67 = v74 ^ v74;\n\tv68 = v74 ^ v64;\n\tv69 = v67 & v68;\n\tv70 = v69 < 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0034;\n\tv73 = 0x6D2F50(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v60, v60, value, v36, v37, v38, v39, v40);\nL_0034:\n\tv76 = end - start;\n\tv77 = v76 * value;\n\treturnVal1 = v77 / v74;\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInCircD(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			float num = value * value;
			float num2 = 1f - num;
			float num3 = Mathf.Sqrt(num2);
			float num4 = num3 - num3;
			object obj = num3 ^ num3;
			object obj2 = num3 ^ num4;
			int num5 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			if (num5 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num3 = num2;
			}
			float num6 = end - start;
			float num7 = num6 * value;
			return num7 / num3;
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0xA0D8C4", Offset = "0xA0D8C4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE8F38]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CE0]) = v44;\nL_001A:\n\tv48 = value + -1f;\n\tgoto L_0025;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0025;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v29, v30, v31, v32, v33, v34, v35, v47, end, value, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = v48 * v48;\n\tv62 = 1f - v60;\n\tv77 = UnityEngine.Mathf::Sqrt(v62);\n\tv66 = v77 - v77;\n\tv69 = v77 ^ v77;\n\tv70 = v77 ^ v66;\n\tv71 = v69 & v70;\n\tv72 = v71 < 0;\n\tv73 = end - start;\n\tv74 = ~v72;\n\tif (v74) goto L_0037;\n\tv76 = 0x6D2F50(UnityEngine.Mathf, v29, v30, v31, v32, v33, v34, v35, v62, v62, value, v36, v37, v38, v39, v40);\nL_0037:\n\tv79 = v73 * v48;\n\tv80 = -v79;\n\treturnVal1 = v80 / v77;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutCircD(float start, float end, float value)
		{
			//IL_004d: Expected O, but got F4
			//IL_005a: Expected O, but got F4
			//IL_00cf: Expected O, but got F4
			float num = value + -1f;
			float num2 = num * num;
			float num3 = 1f - num2;
			float num4 = Mathf.Sqrt(num3);
			float num5 = num4 - num4;
			object obj = num4 ^ num4;
			object obj2 = num4 ^ num5;
			int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag = num6 < 0;
			float num7 = end - start;
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
				num4 = num3;
			}
			float num8 = num7 * num;
			object obj3 = 0f - num8;
			return (float)obj3 / num4;
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0xA0D970", Offset = "0xA0D970", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv28 = *([1EB9440]);\n\tv29 = *([v28 @ X8_v13]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, v31, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\n\tv46 = 0 | 1;\n\t*([2021CE1]) = v46;\nL_001A:\n\tv49 = value + value;\n\tv60 = end - start;\n\tv61 = v49 >= 1f;\n\tif (v61) goto L_0046;\n\tgoto L_0032;\n\tv72 = *([v62 @ X0_v8 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0032;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v62, v31, v32, v33, v34, v35, v36, v37, start, end, value, v38, v39, v40, v41, v42);\nL_0032:\n\tv79 = v49 * v49;\n\tv80 = 1f - v79;\n\tv133 = UnityEngine.Mathf::Sqrt(v80);\n\tv94 = v133 - v133;\n\tv97 = v133 ^ v133;\n\tv98 = v133 ^ v94;\n\tv99 = v97 & v98;\n\tv100 = v99 < 0;\n\tv101 = ~v100;\n\tif (v101) goto L_0042;\n\tv113 = 0x6D2F50(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v80, v80, value, v38, v39, v40, v41, v42);\nL_0042:\n\tv132 = v60 * v49;\n\tgoto L_0067;\nL_0046:\n\tv68 = v49 + -2f;\n\tgoto L_0050;\n\tv82 = *([v66 @ X0_v3 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0050;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v66, v31, v32, v33, v34, v35, v36, v37, v67, end, value, v38, v39, v40, v41, v42);\nL_0050:\n\tv89 = v68 * v68;\n\tv90 = 1f - v89;\n\tv133 = UnityEngine.Mathf::Sqrt(v90);\n\tv104 = v133 - v133;\n\tv107 = v133 ^ v133;\n\tv108 = v133 ^ v104;\n\tv109 = v107 & v108;\n\tv110 = v109 < 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0060;\n\tv118 = 0x6D2F50(UnityEngine.Mathf, v31, v32, v33, v34, v35, v36, v37, v90, v90, value, v38, v39, v40, v41, v42);\nL_0060:\n\tv121 = v60 * v68;\n\tv132 = -v121;\nL_0067:\n\tv143 = v133 + v133;\n\treturnVal1 = v132 / v143;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutCircD(float start, float end, float value)
		{
			//IL_011e: Expected O, but got F4
			//IL_012b: Expected O, but got F4
			//IL_0052: Expected O, but got F4
			//IL_005f: Expected O, but got F4
			float num = value + value;
			float num2 = end - start;
			float num5;
			float num8;
			if (num < 1f)
			{
				float num3 = num * num;
				float num4 = 1f - num3;
				num5 = Mathf.Sqrt(num4);
				float num6 = num5 - num5;
				object obj = num5 ^ num5;
				object obj2 = num5 ^ num6;
				int num7 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				if (num7 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
					num5 = num4;
				}
				num8 = num2 * num;
			}
			else
			{
				float num9 = num + -2f;
				float num10 = num9 * num9;
				float num11 = 1f - num10;
				num5 = Mathf.Sqrt(num11);
				float num12 = num5 - num5;
				object obj3 = num5 ^ num5;
				object obj4 = num5 ^ num12;
				int num13 = (int)((long)(IntPtr)obj3 & (long)(IntPtr)obj4);
				if (num13 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
					num5 = num11;
				}
				float num14 = num2 * num9;
				num8 = 0f - num14;
			}
			float num15 = num5 + num5;
			return num8 / num15;
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0xA0DA68", Offset = "0xA0DA68", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv52 = 1f - value;\n\tv5 = end - start;\n\tv11 = v52 < 0.36363637f;\n\tif (v11) goto L_0032;\n\tv28 = v52 >= 0.72727275f;\n\tif (v28) goto L_0023;\n\tgoto L_002F;\nL_0023:\n\tv69 = 0x1818000 + 0x6C8;\n\tv72 = v52 - 0.9090909090909091d;\n\tv73 = v72 < 0;\n\tv35 = *([v69 @ X9_v4 (System.Int32)+v73 @ N_v5 (System.Boolean)*4]);\nL_002F:\n\tv52 = v52 - v35;\nL_0032:\n\tv60 = v5 + v5;\n\tv61 = v60 * 7.5625f;\n\treturnVal1 = v61 * v52;\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInBounceD(float start, float end, float value)
		{
			//IL_00b2: Expected F4, but got I
			float num = 1f - value;
			float num2 = end - start;
			if (!(num < 0.36363637f))
			{
				float num3;
				if (num < 0.72727275f)
				{
					num3 = 0.54545456f;
				}
				else
				{
					int num4 = 25264128 + 1736;
					float num5 = num - 0.90909094f;
					bool flag = num5 < 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X9_v4 (System.Int32)+v73 @ N_v5 (System.Boolean)*4]");
					num3 = 0f;
				}
				num -= num3;
			}
			float num6 = num2 + num2;
			float num7 = num6 * 7.5625f;
			return num7 * num;
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0xA0DADC", Offset = "0xA0DADC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = end - start;\n\tv9 = v27 < 0.36363637f;\n\tif (v9) goto L_0030;\n\tv26 = v27 >= 0.72727275f;\n\tif (v26) goto L_0021;\n\tgoto L_002D;\nL_0021:\n\tv67 = 0x1818000 + 0x6C8;\n\tv70 = v27 - 0.9090909090909091d;\n\tv71 = v70 < 0;\n\tv35 = *([v67 @ X9_v4 (System.Int32)+v71 @ N_v5 (System.Boolean)*4]);\nL_002D:\n\tv27 = v27 - v35;\nL_0030:\n\tv58 = v2 + v2;\n\tv59 = v58 * 7.5625f;\n\treturnVal1 = v59 * v27;\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutBounceD(float start, float end, float value)
		{
			//IL_00a2: Expected F4, but got I
			float num = end - start;
			float num2 = default(float);
			if (!(num2 < 0.36363637f))
			{
				float num3;
				if (num2 < 0.72727275f)
				{
					num3 = 0.54545456f;
				}
				else
				{
					int num4 = 25264128 + 1736;
					float num5 = num2 - 0.90909094f;
					bool flag = num5 < 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X9_v4 (System.Int32)+v71 @ N_v5 (System.Boolean)*4]");
					num3 = 0f;
				}
				num2 -= num3;
			}
			float num6 = num + num;
			float num7 = num6 * 7.5625f;
			return num7 * num2;
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0xA0DB48", Offset = "0xA0DB48", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = end - start;\n\tv16 = value + value;\n\tv17 = value >= 0.5f;\n\tif (v17) goto L_0014;\n\tv51 = 1f - v16;\n\tgoto L_0018;\nL_0014:\n\tv51 = v16 + -1f;\nL_0018:\n\tv27 = v51 < 0.36363637f;\n\tif (v27) goto L_0042;\n\tv44 = v51 >= 0.72727275f;\n\tif (v44) goto L_0033;\n\tgoto L_003F;\nL_0033:\n\tv85 = 0x1818000 + 0x6C8;\n\tv88 = v51 - 0.9090909090909091d;\n\tv89 = v88 < 0;\n\tv70 = *([v85 @ X9_v4 (System.Int32)+v89 @ N_v6 (System.Boolean)*4]);\nL_003F:\n\tv51 = v51 - v70;\nL_0042:\n\tv75 = v2 + v2;\n\tv76 = v75 * 7.5625f;\n\tv77 = v76 * v51;\n\treturnVal1 = v77 * 0.5f;\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutBounceD(float start, float end, float value)
		{
			//IL_00de: Expected F4, but got I
			float num = end - start;
			float num2 = value + value;
			float num3 = ((!(value < 0.5f)) ? (num2 + -1f) : (1f - num2));
			if (!(num3 < 0.36363637f))
			{
				float num4;
				if (num3 < 0.72727275f)
				{
					num4 = 0.54545456f;
				}
				else
				{
					int num5 = 25264128 + 1736;
					float num6 = num3 - 0.90909094f;
					bool flag = num6 < 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X9_v4 (System.Int32)+v89 @ N_v6 (System.Boolean)*4]");
					num4 = 0f;
				}
				num3 -= num4;
			}
			float num7 = num + num;
			float num8 = num7 * 7.5625f;
			float num9 = num8 * num3;
			return num9 * 0.5f;
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0xA0DBDC", Offset = "0xA0DBDC", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = end - start;\n\tv7 = v4 * 8.10474f;\n\tv8 = v4 * -3.40316f;\n\tv9 = v7 * value;\n\tv11 = v9 * value;\n\tv12 = v8 * value;\n\treturnVal1 = v11 + v12;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInBackD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = num * 8.10474f;
			float num3 = num * -3.40316f;
			float num4 = num2 * value;
			float num5 = num4 * value;
			float num6 = num3 * value;
			return num5 + num6;
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0xA0DC0C", Offset = "0xA0DC0C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = end - start;\n\tv7 = value + -1f;\n\tv10 = v7 * 2.70158f;\n\tv11 = v7 + v7;\n\tv12 = v7 * v10;\n\tv13 = v10 + 1.70158f;\n\tv14 = v11 * v13;\n\tv15 = v12 + v14;\n\treturnVal1 = v1 * v15;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutBackD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num2 * 2.70158f;
			float num4 = num2 + num2;
			float num5 = num2 * num3;
			float num6 = num3 + 1.70158f;
			float num7 = num4 * num6;
			float num8 = num5 + num7;
			return num * num8;
		}

		[Token(Token = "0x60002FA")]
		[Address(RVA = "0xA0DC48", Offset = "0xA0DC48", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = value + value;\n\tv12 = end - start;\n\tv15 = v0 >= 1f;\n\tif (v15) goto L_0021;\n\tv20 = v12 * v0;\n\tv21 = v12 * 0.5f;\n\tv23 = v21 * 3.5949094f;\n\tv24 = v0 * 3.5949094f;\n\tv25 = v0 * v23;\n\tv26 = v24 + -2.5949094f;\n\tv27 = v0 * v25;\n\tv28 = v20 * v26;\n\treturnVal1 = v27 + v28;\n\treturn returnVal1;\nL_0021:\n\tv34 = v0 + -2f;\n\tv36 = v12 * 0.5f;\n\tv38 = v34 + v34;\n\tv39 = v34 * 3.5949094f;\n\tv40 = v34 * v39;\n\tv41 = v39 + 2.5949094f;\n\tv42 = v38 * v41;\n\tv43 = v40 + v42;\n\treturnVal2 = v36 * v43;\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutBackD(float start, float end, float value)
		{
			float num = value + value;
			float num2 = end - start;
			if (num < 1f)
			{
				float num3 = num2 * num;
				float num4 = num2 * 0.5f;
				float num5 = num4 * 3.5949094f;
				float num6 = num * 3.5949094f;
				float num7 = num * num5;
				float num8 = num6 + -2.5949094f;
				float num9 = num * num7;
				float num10 = num3 * num8;
				return num9 + num10;
			}
			float num11 = num + -2f;
			float num12 = num2 * 0.5f;
			float num13 = num11 + num11;
			float num14 = num11 * 3.5949094f;
			float num15 = num11 * num14;
			float num16 = num14 + 2.5949094f;
			float num17 = num13 * num16;
			float num18 = num15 + num17;
			return num12 * num18;
		}

		[Token(Token = "0x60002FB")]
		[Address(RVA = "0xA0DCD8", Offset = "0xA0DCD8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EDA178]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([2021CE2]) = v48;\nL_001B:\n\tv51 = end - start;\n\tgoto L_002D;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_002D;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\nL_002D:\n\tv70 = value + -1f;\n\tv71 = v70 + -0.075f;\n\tv72 = v71 * 6.2831855f;\n\tv73 = v72 / 0.3f;\n\tv75 = 0x6D3020(UnityEngine.Mathf, v33, v34, v35, v36, v37, v38, v39, v73, -0.075f, 6.2831855f, v40, v41, v42, v43, v44);\n\tv78 = 0x6D2D20(v75, v33, v34, v35, v36, v37, v38, v39, v73, -0.075f, 6.2831855f, v40, v41, v42, v43, v44);\n\tv81 = v70 * 10f;\n\tv83 = v81 + 1f;\n\tv84 = 0x6D28C0(v78, v33, v34, v35, v36, v37, v38, v39, v83, 1f, 6.2831855f, v40, v41, v42, v43, v44);\n\tv92 = v51 * -6.2831855f;\n\tv93 = v51 * -3.465736f;\n\tv94 = v92 * v73;\n\tv95 = v93 * v73;\n\tv96 = v94 / 0.3f;\n\tv101 = v95 * v83;\n\treturnVal1 = v96 + v101;\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInElasticD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num3 = num2 + -0.075f;
			float num4 = num3 * ((float)Math.PI * 2f);
			float num5 = num4 / 0.3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num6 = num2 * 10f;
			float num7 = num6 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num8 = num * ((float)Math.PI * -2f);
			float num9 = num * -3.465736f;
			float num10 = num8 * num5;
			float num11 = num9 * num5;
			float num12 = num10 / 0.3f;
			float num13 = num11 * num7;
			return num12 + num13;
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0xA0DDE0", Offset = "0xA0DDE0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EDA320]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\n\tv48 = 0 | 1;\n\t*([2021CE3]) = v48;\nL_001B:\n\tv51 = end - start;\n\tgoto L_0027;\n\tv56 = *([v52 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tgoto L_0027;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v52, v33, v34, v35, v36, v37, v38, v39, start, end, value, v40, v41, v42, v43, v44);\nL_0027:\n\tv64 = value * -10f;\n\tv66 = v64 + 1f;\n\tv67 = 0x6D28C0(UnityEngine.Mathf, v33, v34, v35, v36, v37, v38, v39, v66, 1f, value, v40, v41, v42, v43, v44);\n\tv75 = value + -0.075f;\n\tv76 = v75 * 6.2831855f;\n\tv77 = v76 / 0.3f;\n\tv79 = 0x6D3020(v67, v33, v34, v35, v36, v37, v38, v39, v77, 6.2831855f, value, v40, v41, v42, v43, v44);\n\tv82 = 0x6D2D20(v79, v33, v34, v35, v36, v37, v38, v39, v77, 6.2831855f, value, v40, v41, v42, v43, v44);\n\tv90 = v51 * 3.1415927f;\n\tv91 = v51 * -3.465736f;\n\tv92 = v90 * v66;\n\tv93 = v91 * v66;\n\tv94 = v92 * v77;\n\tv99 = v94 / 0.3f;\n\tv100 = v93 * v77;\n\treturnVal1 = v99 + v100;\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOutElasticD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value * -10f;
			float num3 = num2 + 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
			float num4 = value + -0.075f;
			float num5 = num4 * ((float)Math.PI * 2f);
			float num6 = num5 / 0.3f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num7 = num * (float)Math.PI;
			float num8 = num * -3.465736f;
			float num9 = num7 * num3;
			float num10 = num8 * num3;
			float num11 = num9 * num6;
			float num12 = num11 / 0.3f;
			float num13 = num10 * num6;
			return num12 + num13;
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0xA0DEE4", Offset = "0xA0DEE4", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EDEB50]);\n\tv33 = *([v32 @ X8_v20]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, v35, v36, v37, v38, v39, v40, v41, start, end, value, v42, v43, v44, v45, v46);\n\tv50 = 0 | 1;\n\t*([2021CE4]) = v50;\nL_001E:\n\tv55 = end - start;\n\tv66 = value + -1f;\n\tv68 = value >= 1f;\n\tif (v68) goto L_0055;\n\tgoto L_0036;\n\tv73 = *([v56 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v56, v35, v36, v37, v38, v39, v40, v41, v53, v54, value, v42, v43, v44, v45, v46);\nL_0036:\n\tv81 = v66 * 10f;\n\tv82 = 0x6D28C0(UnityEngine.Mathf, v35, v36, v37, v38, v39, v40, v41, v81, 1f, value, v42, v43, v44, v45, v46);\n\tv107 = v66 + -2f;\n\tv108 = v107 * 6.2831855f;\n\tv109 = v108 / 0.3f;\n\tv110 = 0x6D2D20(v82, v35, v36, v37, v38, v39, v40, v41, v109, 1f, value, v42, v43, v44, v45, v46);\n\tv118 = v66 + -0.075f;\n\tv119 = v118 * 6.2831855f;\n\tv148 = v119 / 0.3f;\n\tv121 = 0x6D3020(v110, v35, v36, v37, v38, v39, v40, v41, v148, 1f, value, v42, v43, v44, v45, v46);\n\tv129 = v55 * -3.465736f;\n\tv130 = v55 * 3.1415927f;\n\tv131 = v129 * v81;\n\tv145 = v131 * v109;\n\tv144 = v130 * v81;\n\tgoto L_0076;\nL_0055:\n\tgoto L_0061;\n\tv83 = *([v56 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0061;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v56, v35, v36, v37, v38, v39, v40, v41, v53, v54, value, v42, v43, v44, v45, v46);\nL_0061:\n\tv96 = v66 + -0.075f;\n\tv97 = v96 * 6.2831855f;\n\tv98 = v97 / 0.3f;\n\tv100 = 0x6D3020(UnityEngine.Mathf, v35, v36, v37, v38, v39, v40, v41, v98, 6.2831855f, value, v42, v43, v44, v45, v46);\n\tv113 = v66 * 10f;\n\tv114 = 0x6D28C0(v100, v35, v36, v37, v38, v39, v40, v41, v113, 6.2831855f, value, v42, v43, v44, v45, v46);\n\tv124 = 0x6D2D20(v114, v35, v36, v37, v38, v39, v40, v41, v98, 6.2831855f, value, v42, v43, v44, v45, v46);\n\tv138 = v113 * 0.3f;\n\tv139 = v55 * 3.1415927f;\n\tv140 = v139 * v98;\n\tv145 = v140 / v138;\n\tv144 = v55 * 3.465736f;\nL_0076:\n\tv155 = v148 * v144;\n\tv156 = v155 / v153;\n\treturnVal1 = v145 - v156;\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOutElasticD(float start, float end, float value)
		{
			float num = end - start;
			float num2 = value + -1f;
			float num9;
			float num13;
			float num14;
			float num15;
			if (value < 1f)
			{
				float num3 = num2 * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				float num4 = num2 + -2f;
				float num5 = num4 * ((float)Math.PI * 2f);
				float num6 = num5 / 0.3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
				float num7 = num2 + -0.075f;
				float num8 = num7 * ((float)Math.PI * 2f);
				num9 = num8 / 0.3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
				float num10 = num * -3.465736f;
				float num11 = num * (float)Math.PI;
				float num12 = num10 * num3;
				num13 = num12 * num6;
				num14 = num11 * num3;
				num15 = 0.3f;
			}
			else
			{
				float num16 = num2 + -0.075f;
				float num17 = num16 * ((float)Math.PI * 2f);
				float num18 = num17 / 0.3f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
				float num19 = num2 * 10f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D28C0 (native exp2f)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
				float num20 = num19 * 0.3f;
				float num21 = num * (float)Math.PI;
				float num22 = num21 * num18;
				num13 = num22 / num20;
				num14 = num * 3.465736f;
				num9 = num18;
				num15 = num19;
			}
			float num23 = num9 * num14;
			float num24 = num23 / num15;
			return num13 - num24;
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0xA0E07C", Offset = "0xA0E07C", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-10_v2;\n\tgoto L_0022;\n\tv36 = *([1ED4778]);\n\tv37 = *([v36 @ X8_v14]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, v39, v40, v41, v42, v43, v44, v45, start, end, value, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([2021CE5]) = v54;\nL_0022:\n\tgoto L_002A;\n\tv61 = *([v57 @ X0_v2+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_002A;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, v39, v40, v41, v42, v43, v44, v45, start, end, value, v46, v47, v48, v49, v50);\nL_002A:\n\tv70 = UnityEngine.Mathf::Clamp01(value);\n\tv75 = end - start;\n\tv76 = 1f - v70;\n\tv78 = 0x6D1A90(0, v39, v40, v41, v42, v43, v44, v45, v76, 1.2f, value, v46, v47, v48, v49, v50);\n\t*([v22 @ X29_v1-4]) = v76;\n\tv84 = v70 * 2.5f;\n\tv85 = v70 * v84;\n\tv86 = v70 * v85;\n\tv87 = v70 * 3.1415927f;\n\tv88 = v86 + 0.2f;\n\tv89 = v87 * v88;\n\tv91 = 0x6D2D20(v78, v39, v40, v41, v42, v43, v44, v45, v89, 0.2f, v87, v46, v47, v48, v49, v50);\n\t*([v22 @ X29_v1-8]) = v89;\n\tv96 = 0x6D1A90(v91, v39, v40, v41, v42, v43, v44, v45, v76, 2.2f, v87, v46, v47, v48, v49, v50);\n\tv99 = 0x6D3020(v96, v39, v40, v41, v42, v43, v44, v45, v89, 2.2f, v87, v46, v47, v48, v49, v50);\n\tv103 = 0x6D1A90(v99, v39, v40, v41, v42, v43, v44, v45, v76, 2.2f, v87, v46, v47, v48, v49, v50);\n\tv106 = 0x6D2D20(v103, v39, v40, v41, v42, v43, v44, v45, v89, 2.2f, v87, v46, v47, v48, v49, v50);\n\tv112 = v76 * 6f;\n\tv114 = v70 / 5f;\n\tv115 = v112 / 5f;\n\tv117 = v88 * 3.1415927f;\n\tv118 = v76 * v89;\n\tv119 = v114 + v118;\n\tv120 = *([v22 @ X29_v1-4]) * -2.2f;\n\tv121 = v70 * 23.561945f;\n\tv122 = v70 * v121;\n\tv123 = v70 * v122;\n\tv124 = v123 + v117;\n\tv128 = v115 + 1f;\n\tv129 = v76 * v124;\n\tv130 = v120 * *([v22 @ X29_v1-8]);\n\tv131 = v89 * v129;\n\tv132 = v75 * 6f;\n\tv133 = v75 * v128;\n\tv134 = v130 + v131;\n\tv146 = v134 + 1f;\n\tv147 = v133 * v146;\n\tv148 = v132 * v119;\n\treturnVal1 = v147 - v148;\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float SpringD(float start, float end, float value)
		{
			object obj2 = default(object);
			object obj = obj2;
			float num = Mathf.Clamp01(value);
			float num2 = end - start;
			float num3 = 1f - num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1A90 (native powf)");
			float num4 = num * 2.5f;
			float num5 = num * num4;
			float num6 = num * num5;
			float num7 = num * (float)Math.PI;
			float num8 = num6 + 0.2f;
			float num9 = num7 * num8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1A90 (native powf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1A90 (native powf)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
			float num10 = num3 * 6f;
			float num11 = num / 5f;
			float num12 = num10 / 5f;
			float num13 = num8 * (float)Math.PI;
			float num14 = num3 * num9;
			float num15 = num11 + num14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-4]");
			float num16 = 0f * -2.2f;
			float num17 = num * 23.561945f;
			float num18 = num * num17;
			float num19 = num * num18;
			float num20 = num19 + num13;
			float num21 = num12 + 1f;
			float num22 = num3 * num20;
			float num23 = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-8]");
			float num24 = num23 * 0f;
			float num25 = num9 * num22;
			float num26 = num2 * 6f;
			float num27 = num2 * num21;
			float num28 = num24 + num25;
			float num29 = num28 + 1f;
			float num30 = num27 * num29;
			float num31 = num26 * num15;
			return num30 - num31;
		}

		[Token(Token = "0x60002FF")]
		[Address(RVA = "0xA0E230", Offset = "0xA0E230", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EF4BF8]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, start, end, value, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021CE6]) = v44;\nL_001C:\n\tv50 = v48.AnimationCurve == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tv53 = UnityEngine.AnimationCurve::Evaluate(v48.AnimationCurve, value);\n\tgoto L_002B;\nL_002B:\n\tgoto L_003C;\n\tv67 = *([v63 @ X0_v3+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_003C;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, v59, v30, v31, v32, v33, v34, v35, v60, end, value, v36, v37, v38, v39, v40);\nL_003C:\n\treturnVal1 = UnityEngine.Mathf::Lerp(start, end, v61);\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float CustomCurve(float start, float end, float value)
		{
			float t;
			if (AnimationCurve != null)
			{
				float num = AnimationCurve.Evaluate(value);
				t = num;
			}
			else
			{
				t = value;
			}
			return Mathf.Lerp(start, end, t);
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0xA0E2EC", Offset = "0xA0E2EC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEBFE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CE7]) = v38;\nL_0013:\n\tv39 = v36 < 0x20;\n\tv40 = ~v39;\n\tv41 = v36 - 0x20;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_002B;\n\tv52 = 0x1818000 + 0x6D0;\n\tv56 = *([v52 @ X9_v2 (System.Int32)+v36 @ X0_v1 (HutongGames.EasingFunction+Ease)*4]) + v52;\n\t// 38 IndirectJump v56 @ X8_v5, v36 @ X0_v1 (HutongGames.EasingFunction+Ease), v36 @ X0_v1 (HutongGames.EasingFunction+Ease), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX19 = *([1F0CD78]);\n\tgoto L_0088;\nL_002B:\n\tgoto L_0096;\n\tX19 = *([1EBFD88]);\n\tgoto L_0088;\n\tX19 = *([1F0E8A8]);\n\tgoto L_0088;\n\tX19 = *([1EF7388]);\n\tgoto L_0088;\n\tX19 = *([1EB4D60]);\n\tgoto L_0088;\n\tX19 = *([1EFE648]);\n\tgoto L_0088;\n\tX19 = *([1EB7548]);\n\tgoto L_0088;\n\tX19 = *([1ECABD8]);\n\tgoto L_0088;\n\tX19 = *([1EA7528]);\n\tgoto L_0088;\n\tX19 = *([1EF4B30]);\n\tgoto L_0088;\n\tX19 = *([1EF9E98]);\n\tgoto L_0088;\n\tX19 = *([1EB44D0]);\n\tgoto L_0088;\n\tX19 = *([1EC0B20]);\n\tgoto L_0088;\n\tX19 = *([1EE0AF0]);\n\tgoto L_0088;\n\tX19 = *([1EA6F80]);\n\tgoto L_0088;\n\tX19 = *([1ED4B28]);\n\tgoto L_0088;\n\tX19 = *([1EBF5F8]);\n\tgoto L_0088;\n\tX19 = *([1EEBE28]);\n\tgoto L_0088;\n\tX19 = *([1F07520]);\n\tgoto L_0088;\n\tX19 = *([1EAC0F0]);\n\tgoto L_0088;\n\tX19 = *([1EEBC50]);\n\tgoto L_0088;\n\tX19 = *([1ED23D8]);\n\tgoto L_0088;\n\tX19 = *([1F0BD30]);\n\tgoto L_0088;\n\tX19 = *([1F10CA0]);\n\tgoto L_0088;\n\tX19 = *([1F05778]);\n\tgoto L_0088;\n\tX19 = *([1EB2C68]);\n\tgoto L_0088;\n\tX19 = *([1EC0A80]);\n\tgoto L_0088;\n\tX19 = *([1EA8360]);\n\tgoto L_0088;\n\tX19 = *([1EE7B28]);\n\tgoto L_0088;\n\tX19 = *([1ECAB60]);\n\tgoto L_0088;\n\tX19 = *([1EB7210]);\n\tgoto L_0088;\n\tX19 = *([1EB9548]);\nL_0088:\n\tX8 = 0x1EF7000;\n\tX8 = *([1EF7DD0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8]);\n\t*([X0+20]) = 0;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\nL_0096:\n\treturn 0;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Function GetEasingFunction(Ease easingFunction)
		{
			//IL_0029: Expected O, but got I
			Ease ease = default(Ease);
			bool flag = ease < Ease.CustomCurve;
			bool flag2 = !flag;
			int num = (int)(ease - 32);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 1744;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v36 @ X0_v1 (HutongGames.EasingFunction+Ease)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v5 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0xA0E508", Offset = "0xA0E508", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE6CF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CE8]) = v38;\nL_0013:\n\tv39 = v36 < 0x1F;\n\tv40 = ~v39;\n\tv41 = v36 - 0x1F;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_002B;\n\tv52 = 0x1818000 + 0x754;\n\tv56 = *([v52 @ X9_v2 (System.Int32)+v36 @ X0_v1 (HutongGames.EasingFunction+Ease)*4]) + v52;\n\t// 38 IndirectJump v56 @ X8_v5, v36 @ X0_v1 (HutongGames.EasingFunction+Ease), v36 @ X0_v1 (HutongGames.EasingFunction+Ease), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX19 = *([1EEDF30]);\n\tgoto L_0085;\nL_002B:\n\tgoto L_0093;\n\tX19 = *([1EAB628]);\n\tgoto L_0085;\n\tX19 = *([1ECDD10]);\n\tgoto L_0085;\n\tX19 = *([1ECEE08]);\n\tgoto L_0085;\n\tX19 = *([1EF3EE0]);\n\tgoto L_0085;\n\tX19 = *([1EF9278]);\n\tgoto L_0085;\n\tX19 = *([1EDB338]);\n\tgoto L_0085;\n\tX19 = *([1EEA100]);\n\tgoto L_0085;\n\tX19 = *([1EC4E90]);\n\tgoto L_0085;\n\tX19 = *([1EB7960]);\n\tgoto L_0085;\n\tX19 = *([1EBDD50]);\n\tgoto L_0085;\n\tX19 = *([1EEA088]);\n\tgoto L_0085;\n\tX19 = *([1EA7598]);\n\tgoto L_0085;\n\tX19 = *([1EB2BB8]);\n\tgoto L_0085;\n\tX19 = *([1EDA2D0]);\n\tgoto L_0085;\n\tX19 = *([1EC2530]);\n\tgoto L_0085;\n\tX19 = *([1F00DE8]);\n\tgoto L_0085;\n\tX19 = *([1ECC3E8]);\n\tgoto L_0085;\n\tX19 = *([1EE8EB0]);\n\tgoto L_0085;\n\tX19 = *([1ECB8B0]);\n\tgoto L_0085;\n\tX19 = *([1ED3170]);\n\tgoto L_0085;\n\tX19 = *([1EE3F08]);\n\tgoto L_0085;\n\tX19 = *([1ECEAA8]);\n\tgoto L_0085;\n\tX19 = *([1EA6578]);\n\tgoto L_0085;\n\tX19 = *([1EE0630]);\n\tgoto L_0085;\n\tX19 = *([1EDAB88]);\n\tgoto L_0085;\n\tX19 = *([1F05C20]);\n\tgoto L_0085;\n\tX19 = *([1EEB3D8]);\n\tgoto L_0085;\n\tX19 = *([1F0EA70]);\n\tgoto L_0085;\n\tX19 = *([1EC11A8]);\n\tgoto L_0085;\n\tX19 = *([1EC0CF0]);\nL_0085:\n\tX8 = 0x1EF7000;\n\tX8 = *([1EF7DD0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8]);\n\t*([X0+20]) = 0;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\nL_0093:\n\treturn 0;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Function GetEasingFunctionDerivative(Ease easingFunction)
		{
			//IL_0029: Expected O, but got I
			Ease ease = default(Ease);
			bool flag = ease < Ease.EaseInOutElastic;
			bool flag2 = !flag;
			int num = (int)(ease - 31);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25264128 + 1876;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v2 (System.Int32)+v36 @ X0_v1 (HutongGames.EasingFunction+Ease)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ X8_v5 (should have been resolved before IL gen)");
			}
			return null;
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0xA0E708", Offset = "0xA0E708", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EasingFunction()
		{
		}
	}
}
