using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756C70", Offset = "0x756C70")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756C70", Offset = "0x756C70")]
	[Token(Token = "0x2000209")]
	public class ScaleGUI : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014C3")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat scaleX;

		[RequiredField]
		[Token(Token = "0x40014C4")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat scaleY;

		[RequiredField]
		[Token(Token = "0x40014C5")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat pivotX;

		[RequiredField]
		[Token(Token = "0x40014C6")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat pivotY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1FF0", Offset = "0x7B1FF0")]
		[Token(Token = "0x40014C7")]
		[FieldOffset(Offset = "0x70")]
		public bool normalized;

		[Token(Token = "0x40014C8")]
		[FieldOffset(Offset = "0x71")]
		public bool applyGlobally;

		[Token(Token = "0x40014C9")]
		[FieldOffset(Offset = "0x72")]
		private bool applied;

		[Token(Token = "0x6000A89")]
		[Address(RVA = "0xB251C8", Offset = "0xB251C8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.scaleX = v15;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.scaleY = v18;\n\tv22 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.pivotX = v22;\n\tv25 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.pivotY = v25;\n\tthis.normalized = 1;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 1f;
			scaleX = fsmFloat;
			FsmFloat fsmFloat2 = 1f;
			scaleY = fsmFloat2;
			FsmFloat fsmFloat3 = 0.5f;
			pivotX = fsmFloat3;
			FsmFloat fsmFloat4 = 0.5f;
			pivotY = fsmFloat4;
			normalized = true;
			applyGlobally = false;
		}

		[Token(Token = "0x6000A8A")]
		[Address(RVA = "0xB2523C", Offset = "0xB2523C", Length = "0x2B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = &v17 @ stack_-10_v2;\n\tgoto L_0017;\n\tv26 = *([1F08CD8]);\n\tv27 = *([v26 @ X8_v36]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20225D6]) = v46;\nL_0017:\n\t*([v16 @ X29_v1-78]) = 0;\n\tv49 = ~this.applied;\n\tv50 = ~v49;\n\tif (v50) goto L_00E9;\n\tv172 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleX);\n\tv243 = HutongGames.PlayMaker.FsmFloat::get_Value(this.scaleY);\n\tv244 = &v17 @ stack_-10_v2 - 0x78;\n\tv246 = 0x1588A6C(v244, 0, v30, v31, v32, v33, v34, v35, v172, v243, v38, v39, v40, v41, v42, v43);\n\tv249 = &v17 @ stack_-10_v2 - 0x70;\n\t*([v16 @ X29_v1-70]) = *([v16 @ X29_v1-78]);\n\t// 51 Box v251 @ X0_v10 (System.Object), typeof(System.Single), v249 @ X1_v6\n\tv133 = 0;\n\t// 58 Box v257 @ X0_v12 (System.Object), typeof(System.Int32), &v133 @ stack_-D0_v5 (System.Single)\n\tv261 = System.Object::Equals(v251, v257);\n\tv263 = v261 == 0;\n\tif (v263) goto L_0047;\n\t*([v16 @ X29_v1-78]) = 0x38D1B717;\nL_0047:\n\tv269 = &v17 @ stack_-10_v2 - 0x70;\n\t*([v16 @ X29_v1-70]) = *([v16 @ X29_v1-74]);\n\t// 73 Box v270 @ X0_v16 (System.Object), typeof(System.Single), v269 @ X1_v9\n\tv133 = 0;\n\t// 78 Box v273 @ X0_v18 (System.Object), typeof(System.Int32), &v133 @ stack_-D0_v5 (System.Single)\n\tv275 = System.Object::Equals(v270, v273);\n\tv277 = v275 == 0;\n\tif (v277) goto L_005D;\n\t*([v16 @ X29_v1-78]) = 0x38D1B717;\nL_005D:\n\tv183 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pivotX);\n\tv281 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pivotY);\n\tv286 = 0x1588A6C(&v284 @ stack_-90_v3, 0, 0, v31, v32, v33, v34, v35, v183, v281, v38, v39, v40, v41, v42, v43);\n\tv288 = ~this.normalized;\n\tif (v288) goto L_FFFFFFFF;\n\tv291 = UnityEngine.Screen::get_width();\n\tv294 = v284 * v291;\n\tv298 = UnityEngine.Screen::get_height();\n\tv127 = v124 * v298;\n\tgoto L_007E;\nL_007E:\n\t// 126 MakeStruct v60 @ AGGB253EC_0_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v16 @ X29_v1-78], [v16 @ X29_v1-74]\n\t// 127 MakeStruct v57 @ AGGB253EC_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v294 @ V0_v18, v127 @ V3_v2\n\tUnityEngine.GUIUtility::ScaleAroundPivot(v60, v57);\n\tv156 = ~this.applyGlobally;\n\tif (v156) goto L_00E9;\n\tgoto L_0092;\n\tv310 = *([v306 @ X0_v27+E0]);\n\tv311 = v310 == 0;\n\tv312 = ~v311;\n\tif (v312) goto L_0092;\n\tv314 = \"il2cpp_codegen_runtime_class_init\"(v306, v150, v131, v31, v32, v33, v34, v35, v148, v143, v76, v127, v40, v41, v42, v43);\nL_0092:\n\tv319 = UnityEngine.GUI::get_matrix();\n\tgoto L_00BB;\n\tv325 = *([v321 @ X0_v31+E0]);\n\tv326 = v325 == 0;\n\tv327 = ~v326;\n\tif (v327) goto L_00BB;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v321, v150, v131, v31, v32, v33, v34, v35, v148, v143, v76, v127, v40, v41, v42, v43);\nL_00BB:\n\tgoto L_00C7;\n\tv340 = *([1ED14F8]);\n\tv341 = *([v340 @ X8_v26]);\n\tv342 = \"il2cpp_codegen_initialize_method\"(v341, v150, v131, v31, v32, v33, v34, v35, v333, v332, v335, v334, v40, v41, v42, v43);\n\tv345 = 0 | 1;\n\t*([202262E]) = v345;\nL_00C7:\n\t*([v16 @ X29_v1-50]) = v319.m02;\n\t*([v16 @ X29_v1-40]) = v319.m03;\n\t*([v16 @ X29_v1-70]) = v319.m00;\n\t*([v16 @ X29_v1-60]) = v319.m01;\n\tgoto L_00D5;\n\tv351 = *([v347 @ X0_v34 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv352 = v351 == 0;\n\tv353 = ~v352;\n\tgoto L_00D5;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v347, v150, v131, v31, v32, v33, v34, v35, v346, v142, v75, v126, v40, v41, v42, v43);\n\tv354 = PlayMakerGUI;\nL_00D5:\n\tv158 = *([v152 @ X0_v35 (Il2CppClass<PlayMakerGUI>)+B8]);\n\t*([v158 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+A0]) = *([v16 @ X29_v1-40]);\n\t*([v158 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+90]) = *([v16 @ X29_v1-50]);\n\t*([v158 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+80]) = *([v16 @ X29_v1-60]);\n\tv158.guiMatrix = *([v16 @ X29_v1-70]);\n\tthis.applied = 1;\nL_00E9:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_003f: Expected O, but got I
			//IL_0062: Expected O, but got I
			//IL_0078: Expected F4, but got O
			//IL_008e: Expected I4, but got F4
			//IL_01e2: Expected O, but got I
			//IL_01f8: Expected F4, but got O
			//IL_020e: Expected I4, but got F4
			//IL_023d: Expected F4, but got I
			//IL_0252: Expected F4, but got I
			//IL_025f: Expected F4, but got O
			//IL_026c: Expected F4, but got O
			//IL_0161: Expected O, but got I
			//IL_017d: Expected O, but got I
			//IL_02cb: Expected I, but got O
			//IL_02d9: Expected I, but got O
			//IL_0311: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			if (!applied)
			{
				float value = scaleX.Value;
				float value2 = scaleY.Value;
				object obj3 = (long)(IntPtr)obj2 - 120L;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				object obj4 = (long)(IntPtr)obj2 - 112L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-78]");
				_ = 0;
				object objA = (float)obj4;
				float num = 0f;
				object objB = (int)num;
				if (object.Equals(objA, objB))
				{
					_ = 953267991;
				}
				object obj5 = (long)(IntPtr)obj2 - 112L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-74]");
				_ = 0;
				object objA2 = (float)obj5;
				num = 0f;
				object objB2 = (int)num;
				if (object.Equals(objA2, objB2))
				{
					_ = 953267991;
				}
				float value3 = pivotX.Value;
				float value4 = pivotY.Value;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				object obj6 = default(object);
				object obj8;
				object obj9 = default(object);
				if (normalized)
				{
					int width = Screen.width;
					object obj7 = default(object);
					obj6 = (long)(IntPtr)obj7 * (long)width;
					int height = Screen.height;
					obj8 = (long)(IntPtr)obj9 * (long)height;
				}
				else
				{
					obj8 = obj9;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-78]");
				Vector2 scale = default(Vector2);
				scale.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-74]");
				scale.y = 0f;
				Vector2 pivotPoint = default(Vector2);
				pivotPoint.x = (float)obj6;
				pivotPoint.y = (float)obj8;
				GUIUtility.ScaleAroundPivot(scale, pivotPoint);
				if (applyGlobally)
				{
					Matrix4x4 matrix = GUI.matrix;
					_ = matrix.m02;
					_ = matrix.m03;
					_ = matrix.m00;
					_ = matrix.m01;
					IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
					IntPtr intPtr2 = (IntPtr)PlayMakerGUI.fsmList;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X29_v1-70]");
					PlayMakerGUI.guiMatrix = (Matrix4x4)0;
					applied = true;
				}
			}
		}

		[Token(Token = "0x6000A8B")]
		[Address(RVA = "0xB254F0", Offset = "0xB254F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.applied = 0;\n\treturn;\n")]
		public override void OnUpdate()
		{
			applied = false;
		}

		[Token(Token = "0x6000A8C")]
		[Address(RVA = "0xB254F8", Offset = "0xB254F8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ScaleGUI()
		{
		}
	}
}
