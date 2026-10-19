using System;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000373")]
	public static class CurvePromptSection
	{
		[Token(Token = "0x6000E3C")]
		[Address(RVA = "0x3F07D20", Offset = "0x3F07D20", Length = "0x4A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv66 = curve == 0;\n\tif (v66) goto L_0127;\n\tv73 = UnityEngine.AnimationCurve::Evaluate(curve, 0f);\n\tv101 = v73 < 1f;\n\tv102 = v73 == 1f;\n\tv105 = v73 == v73;\n\tv106 = 1f == 1f;\n\tv107 = v105 & v106;\n\tv108 = ~v107;\n\tv109 = v101 == v108;\n\tv110 = ~v102;\n\tv111 = v109 & v110;\n\tv112 = ~v111;\n\tif (v112) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv137 = 1f;\n\tgoto L_0041;\nL_FFFFFFFF:\n\tv137 = v73;\nL_FFFFFFFF:\n\tv165 = 0;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv165 = v137;\n\tv210 = System.Text.StringBuilder::AppendLine(v60, v201);\n\tv218 = UnityEngine.AnimationCurve::Evaluate(curve, 0.25f);\n\tv288 = v218 < 1f;\n\tv289 = v218 == 1f;\n\tv292 = v218 == v218;\n\tv293 = 1f == 1f;\n\tv294 = v292 & v293;\n\tv295 = ~v294;\n\tv296 = v288 == v295;\n\tv297 = ~v289;\n\tv298 = v296 & v297;\n\tv299 = ~v298;\n\tif (v299) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv311 = 1f;\n\tgoto L_0076;\nL_FFFFFFFF:\n\tv311 = v218;\nL_FFFFFFFF:\n\tv331 = 0;\n\tgoto L_0083;\nL_FFFFFFFF:\n\tv331 = v311;\n\tv364 = System.Text.StringBuilder::AppendLine(v60, v355);\n\tv371 = UnityEngine.AnimationCurve::Evaluate(curve, 0.5f);\n\tv416 = v371 < 1f;\n\tv417 = v371 == 1f;\n\tv420 = v371 == v371;\n\tv421 = 1f == 1f;\n\tv422 = v420 & v421;\n\tv423 = ~v422;\n\tv424 = v416 == v423;\n\tv425 = ~v417;\n\tv426 = v424 & v425;\n\tv427 = ~v426;\n\tif (v427) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv437 = 1f;\n\tgoto L_00AA;\nL_FFFFFFFF:\n\tv437 = v371;\nL_FFFFFFFF:\n\tv448 = 0;\n\tgoto L_00B7;\nL_FFFFFFFF:\n\tv448 = v437;\n\tv467 = System.Text.StringBuilder::AppendLine(v60, v463);\n\tv471 = UnityEngine.AnimationCurve::Evaluate(curve, 0.75f);\n\tv472 = v471 < 1f;\n\tv473 = v471 == 1f;\n\tv476 = v471 == v471;\n\tv477 = 1f == 1f;\n\tv478 = v476 & v477;\n\tv479 = ~v478;\n\tv480 = v472 == v479;\n\tv481 = ~v473;\n\tv482 = v480 & v481;\n\tv483 = ~v482;\n\tif (v483) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv486 = 1f;\n\tgoto L_00DE;\nL_FFFFFFFF:\n\tv486 = v471;\nL_FFFFFFFF:\n\tv380 = 0;\n\tgoto L_00EB;\nL_FFFFFFFF:\n\tv380 = v486;\n\tv511 = System.Text.StringBuilder::AppendLine(v60, v508);\n\tv401 = UnityEngine.AnimationCurve::Evaluate(curve, 1f);\n\tv515 = v401 < 1f;\n\tv516 = v401 == 1f;\n\tv519 = v401 == v401;\n\tv391 = 1f == 1f;\n\tv520 = v519 & v391;\n\tv521 = ~v520;\n\tv522 = v515 == v521;\n\tv385 = ~v516;\n\tv387 = v522 & v385;\n\tv523 = ~v387;\n\tif (v523) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv381 = 1f;\n\tgoto L_0112;\nL_FFFFFFFF:\n\tv381 = v401;\nL_FFFFFFFF:\n\tv403 = 0;\n\tgoto L_011F;\nL_FFFFFFFF:\n\tv403 = v381;\nL_0127:\n\tv154 = 0;\n\tv76 = 0xB7D5000 + 0x538;\n\tv79 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = 0x3F000000;\n\tv118 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv127 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v79, v118);\n\tv148 = System.Text.StringBuilder::AppendLine(v60, v127);\n\tv154 = 0x3E800000;\n\tv157 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = 0x3F000000;\n\tv176 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv191 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v157, v176);\n\tv205 = System.Text.StringBuilder::AppendLine(v60, v191);\n\tv211 = 0x3F000000;\n\tv214 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v211 @ stack_-64_v5 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = 0x3F000000;\n\tv223 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv304 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v214, v223);\n\tv310 = System.Text.StringBuilder::AppendLine(v60, v304);\n\tv154 = 0x3F400000;\n\tv323 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = 0x3F000000;\n\tv330 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv341 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v323, v330);\n\tv350 = System.Text.StringBuilder::AppendLine(v60, v341);\n\tv154 = 0x3F800000;\n\tv360 = \"il2cpp_vm_object_box\"(*([v76 @ X21_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv406 = *([v76 @ X21_v5 (System.Int32)+78]);\nL_FFFFFFFF:\n\tv115 = 0x3F000000;\nL_FFFFFFFF:\n\tv412 = v360;\n\treturnVal2 = System.Text.StringBuilder::ToString(v60);\n\treturn returnVal2;\nL_019B:\n\tv68 = curve == 0;\nL_FFFFFFFF:\n\tv84 = 0.5f;\n\tif (v68) goto L_01A2;\n\tv84 = UnityEngine.AnimationCurve::Evaluate(curve, 0f);\nL_01A2:\n\tv88 = v84 < 1f;\n\tv89 = v84 == 1f;\n\tv92 = v84 == v84;\n\tv93 = 1f == 1f;\n\tv94 = v92 & v93;\n\tv95 = ~v94;\n\tv96 = v88 == v95;\n\tv97 = ~v89;\n\tv98 = v96 & v97;\n\tv99 = ~v98;\n\tif (v99) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv128 = 1f;\n\tgoto L_01B3;\nL_FFFFFFFF:\n\tv128 = v84;\nL_FFFFFFFF:\n\tv158 = 0;\n\tgoto L_01C0;\nL_FFFFFFFF:\n\tv158 = v128;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0022:\n\tv60 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v60);\n\tv65 = v60 == 0;\n\tif (v65) goto L_019B;\nL_0041:\n\tv138 = v73 < 0;\n\tv144 = ~v138;\n\tif (v144) goto L_FFFFFFFF;\nL_004D:\n\tv154 = 0;\n\tv168 = 0xB7D5000 + 0x538;\n\tv171 = \"il2cpp_vm_object_box\"(*([v168 @ X23_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v73, v137, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = v165;\n\tv186 = \"il2cpp_vm_object_box\"(*([v168 @ X23_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv201 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v171, v186);\nL_0076:\n\tv312 = v218 < 0;\n\tv318 = ~v312;\n\tif (v318) goto L_FFFFFFFF;\nL_0083:\n\tv154 = 0x3E800000;\n\tv336 = \"il2cpp_vm_object_box\"(*([v168 @ X23_v5 (System.Int32)+78]), &v154 @ stack_-64_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v218, v311, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv115 = v331;\n\tv346 = \"il2cpp_vm_object_box\"(*([v168 @ X23_v5 (System.Int32)+78]), &v115 @ stack_-68_v3 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv355 = System.String::Format(\"- t={0:F2} -> {1:F2}\", v336, v346);\nL_00AA:\n\n// ... truncated")]
		public static string Sample(AnimationCurve curve)
		{
			//IL_06a0: Expected O, but got I
			//IL_0a34: Expected O, but got I
			StringBuilder stringBuilder = new StringBuilder();
			int num4;
			float num6;
			if (stringBuilder != null)
			{
				object arg9;
				if (curve != null)
				{
					float num = curve.Evaluate(0f);
					bool flag = num < 1f;
					bool flag2 = num == 1f;
					bool flag3 = num == num;
					bool flag4 = 1f == 1f;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					bool flag7 = flag == flag6;
					bool flag8 = !flag2;
					float num2 = ((!(flag7 && flag8)) ? num : 1f);
					float num3 = ((!(num < 0f)) ? num2 : 0f);
					num4 = 0;
					int num5 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = num3;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					object arg2 = default(object);
					string value = $"- t={arg:F2} -> {arg2:F2}";
					StringBuilder stringBuilder2 = stringBuilder.AppendLine(value);
					float num7 = curve.Evaluate(0.25f);
					bool flag9 = num7 < 1f;
					bool flag10 = num7 == 1f;
					bool flag11 = num7 == num7;
					bool flag12 = 1f == 1f;
					bool flag13 = flag11 && flag12;
					bool flag14 = !flag13;
					bool flag15 = flag9 == flag14;
					bool flag16 = !flag10;
					float num8 = ((!(flag15 && flag16)) ? num7 : 1f);
					float num9 = ((!(num7 < 0f)) ? num8 : 0f);
					num4 = 1048576000;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = num9;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg3 = default(object);
					object arg4 = default(object);
					string value2 = $"- t={arg3:F2} -> {arg4:F2}";
					StringBuilder stringBuilder3 = stringBuilder.AppendLine(value2);
					float num10 = curve.Evaluate(0.5f);
					bool flag17 = num10 < 1f;
					bool flag18 = num10 == 1f;
					bool flag19 = num10 == num10;
					bool flag20 = 1f == 1f;
					bool flag21 = flag19 && flag20;
					bool flag22 = !flag21;
					bool flag23 = flag17 == flag22;
					bool flag24 = !flag18;
					float num11 = ((!(flag23 && flag24)) ? num10 : 1f);
					float num12 = ((!(num10 < 0f)) ? num11 : 0f);
					num4 = 1056964608;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = num12;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg5 = default(object);
					object arg6 = default(object);
					string value3 = $"- t={arg5:F2} -> {arg6:F2}";
					StringBuilder stringBuilder4 = stringBuilder.AppendLine(value3);
					float num13 = curve.Evaluate(0.75f);
					bool flag25 = num13 < 1f;
					bool flag26 = num13 == 1f;
					bool flag27 = num13 == num13;
					bool flag28 = 1f == 1f;
					bool flag29 = flag27 && flag28;
					bool flag30 = !flag29;
					bool flag31 = flag25 == flag30;
					bool flag32 = !flag26;
					float num14 = ((!(flag31 && flag32)) ? num13 : 1f);
					float num15 = ((!(num13 < 0f)) ? num14 : 0f);
					num4 = 1061158912;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = num15;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg7 = default(object);
					object arg8 = default(object);
					string value4 = $"- t={arg7:F2} -> {arg8:F2}";
					StringBuilder stringBuilder5 = stringBuilder.AppendLine(value4);
					float num16 = curve.Evaluate(1f);
					bool flag33 = num16 < 1f;
					bool flag34 = num16 == 1f;
					bool flag35 = num16 == num16;
					bool flag36 = 1f == 1f;
					bool flag37 = flag35 && flag36;
					bool flag38 = !flag37;
					bool flag39 = flag33 == flag38;
					bool flag40 = !flag34;
					float num17 = ((!(flag39 && flag40)) ? num16 : 1f);
					float num18 = ((!(num16 < 0f)) ? num17 : 0f);
					num4 = 1065353216;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X23_v5 (System.Int32)+78]");
					object obj = 0;
					num6 = num18;
					object obj2 = default(object);
					arg9 = obj2;
				}
				else
				{
					num4 = 0;
					int num19 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = 0.5f;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg10 = default(object);
					object arg11 = default(object);
					string value5 = $"- t={arg10:F2} -> {arg11:F2}";
					StringBuilder stringBuilder6 = stringBuilder.AppendLine(value5);
					num4 = 1048576000;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = 0.5f;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg12 = default(object);
					object arg13 = default(object);
					string value6 = $"- t={arg12:F2} -> {arg13:F2}";
					StringBuilder stringBuilder7 = stringBuilder.AppendLine(value6);
					float num20 = 0.5f;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = 0.5f;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg14 = default(object);
					object arg15 = default(object);
					string value7 = $"- t={arg14:F2} -> {arg15:F2}";
					StringBuilder stringBuilder8 = stringBuilder.AppendLine(value7);
					num4 = 1061158912;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					num6 = 0.5f;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg16 = default(object);
					object arg17 = default(object);
					string value8 = $"- t={arg16:F2} -> {arg17:F2}";
					StringBuilder stringBuilder9 = stringBuilder.AppendLine(value8);
					num4 = 1065353216;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X21_v5 (System.Int32)+78]");
					object obj = 0;
					num6 = 0.5f;
					object obj3 = default(object);
					arg9 = obj3;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg18 = default(object);
				string value9 = $"- t={arg9:F2} -> {arg18:F2}";
				StringBuilder stringBuilder10 = stringBuilder.AppendLine(value9);
				return stringBuilder.ToString();
			}
			bool flag41 = curve == null;
			float num21 = 0.5f;
			if (!flag41)
			{
				num21 = curve.Evaluate(0f);
			}
			bool flag42 = num21 < 1f;
			bool flag43 = num21 == 1f;
			bool flag44 = num21 == num21;
			bool flag45 = 1f == 1f;
			bool flag46 = flag44 && flag45;
			bool flag47 = !flag46;
			bool flag48 = flag42 == flag47;
			bool flag49 = !flag43;
			float num22 = ((!(flag48 && flag49)) ? num21 : 1f);
			float num23 = ((!(num21 < 0f)) ? num22 : 0f);
			num4 = 0;
			int num24 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			num6 = num23;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg19 = default(object);
			object arg20 = default(object);
			string text = $"- t={arg19:F2} -> {arg20:F2}";
			return (string)(object)new NullReferenceException();
		}

		[Token(Token = "0x6000E3D")]
		[Address(RVA = "0x3F081C0", Offset = "0x3F081C0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv75 = System.Text.StringBuilder::AppendLine(v49, \"How conveyor occupancy actually moves:\");\n\tv83 = System.Text.StringBuilder::AppendLine(v49, \"- A broken cube yields 3 units of sand that land on the conveyor belt. A unit leaves the belt only by being absorbed into a FRONT-ROW mold cell of the SAME color; each cell absorbs exactly one unit (the cell behind it then advances to the front).\");\n\tv89 = System.Text.StringBuilder::AppendLine(v49, \"- Absorption is therefore PARTIAL by default: if the front row exposes one cell of the broken color backed by a different color, 1 of the 3 units drains and 2 stay on the belt. Occupancy RISES whenever arriving units exceed what the current front row can absorb, and FALLS while the front absorbs them.\");\n\tv117 = System.Text.StringBuilder::AppendLine(v49, \"- Accumulation does NOT require monochrome regions or fully mismatched colors — any mix of colors piles up the belt while the front row exposes fewer matching cells than the units arriving. WHEN each color drains is decided by the mold layout (placed after you), not by clustering cube colors.\");\n\tv121 = System.Text.StringBuilder::AppendLine(v49, \"- That is the entire mechanic. The curve above simply describes WHEN the level wants sand piling up versus draining.\");\n\tv105 = System.Text.StringBuilder::ToString(v105);\n\treturn v49;\nL_0027:\n\tv49 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v49);\n")]
		private static string Mechanic()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurvePromptSection::Mechanic");
			return default;
		}

		[Token(Token = "0x6000E3E")]
		[Address(RVA = "0x3F082EC", Offset = "0x3F082EC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv67 = System.Text.StringBuilder::AppendLine(v46, \"## Conveyor fill curve — build a grid this occupancy shape is achievable on\");\n\tv72 = System.Text.StringBuilder::AppendLine(v46, \"Target belt occupancy (0 = empty, 1 = full) across normalized play time (0 = first tap, 1 = last). The deterministic mold-placement step that runs AFTER you is what actually realizes this curve — your grid only decides whether it CAN:\");\n\tv74 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.CurvePromptSection::Sample(curve);\n\tv98 = System.Text.StringBuilder::Append(v46, v74);\n\tv101 = System.Text.StringBuilder::AppendLine(v46);\n\tv102 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.CurvePromptSection::Mechanic();\n\tv106 = System.Text.StringBuilder::Append(v46, v102);\n\tv109 = System.Text.StringBuilder::AppendLine(v46);\n\tv113 = System.Text.StringBuilder::AppendLine(v46, \"Do not try to engineer the curve cube by cube — occupancy is decided by the mold layout, not by you. Treat the curve as a supply-side feasibility check on your grid: where it wants high occupancy, enough cubes must be breakable around that stretch of play for units to pile up; where it wants low occupancy, the play should not be forced to dump large bursts of sand. Build the most interesting grid the brief asks for first, then sanity-check it against the curve. In design-notes.md, note where you expect occupancy to rise and where it drains.\");\n\tv84 = System.Text.StringBuilder::ToString(v84);\n\treturn v46;\nL_0020:\n\tv46 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v46);\n")]
		public static string DesignerSection(AnimationCurve curve)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurvePromptSection::DesignerSection");
			return default;
		}

		[Token(Token = "0x6000E3F")]
		[Address(RVA = "0x3F08410", Offset = "0x3F08410", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv67 = System.Text.StringBuilder::AppendLine(v46, \"## Conveyor fill curve — keep this in mind while ordering your taps\");\n\tv72 = System.Text.StringBuilder::AppendLine(v46, \"Target belt occupancy (0 = empty, 1 = full) across normalized play time (0 = first tap, 1 = last):\");\n\tv74 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.CurvePromptSection::Sample(curve);\n\tv98 = System.Text.StringBuilder::Append(v46, v74);\n\tv101 = System.Text.StringBuilder::AppendLine(v46);\n\tv102 = _game.CoreSystem.New.LevelGeneratorSystem.Driver.CurvePromptSection::Mechanic();\n\tv106 = System.Text.StringBuilder::Append(v46, v102);\n\tv109 = System.Text.StringBuilder::AppendLine(v46);\n\tv113 = System.Text.StringBuilder::AppendLine(v46, \"There are NO molds on the board yet: a deterministic mold-placement step runs AFTER you and arranges the molds to fit this curve around the tap order you author. So do not reason about molds, and do not try to engineer the curve yourself — author the most natural, fun play order, and simply keep the target shape in mind when choosing between otherwise equal taps.\");\n\tv84 = System.Text.StringBuilder::ToString(v84);\n\treturn v46;\nL_0020:\n\tv46 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v46);\n")]
		public static string PathSection(AnimationCurve curve)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurvePromptSection::PathSection");
			return default;
		}
	}
}
