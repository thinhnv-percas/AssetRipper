using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x200003C")]
	internal static class SpecialPluginsUtils
	{
		[Token(Token = "0x600022C")]
		[Address(RVA = "0x1083694", Offset = "0x1083694", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EF16F0]);\n\tv31 = *([v30 @ X8_v18]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2026A5B]) = v50;\nL_001E:\n\tv55 = t.target == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_004E;\n\tgoto L_00C8;\n\tv101 = v101_asT == 0;\n\tif (v101) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_004E:\n\tv155 = UnityEngine.Transform::get_position(v149);\n\tgoto L_0069;\n\tv256 = *([v165 @ X0_v6+E0]);\n\tv257 = v256 == 0;\n\tv258 = ~v257;\n\tif (v258) goto L_0069;\n\tv260 = \"il2cpp_codegen_runtime_class_init\"(v165, v154, v34, v35, v36, v37, v38, v39, v155, v158, v159, v43, v44, v45, v46, v47);\nL_0069:\n\tv155 = UnityEngine.Vector3::op_Subtraction(t.endValue, v155);\n\tv281 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]) == 8;\n\tif (v281) goto L_FFFFFFFF;\n\tv290 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]) == 4;\n\tif (v290) goto L_FFFFFFFF;\n\tv305 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]) != 2;\n\tif (v305) goto L_009D;\n\tgoto L_009D;\n\tgoto L_009D;\nL_009D:\n\tgoto L_00AA;\n\tv320 = *([v316 @ X0_v9+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tgoto L_00AA;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v316, v154, v34, v35, v36, v37, v38, v39, v270, v271, v272, v266, v267, v268, v46, v47);\nL_00AA:\n\t// 170 MakeStruct v185 @ AGG1083810_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v308 @ V9_v3 (UnityEngine.Vector3), v310 @ V8_v3 (System.Single), v307 @ V10_v3 (System.Single)\n\t// 171 MakeStruct v182 @ AGG1083810_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+148], [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C], [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]\n\tv213 = UnityEngine.Quaternion::LookRotation(v185, v182);\n\tv331 = 0x10CC508(&v213 @ V0_v5 (UnityEngine.Quaternion), 0, v34, v35, v36, v37, v38, v39, v213, v213.y, v213.z, v213.w, *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]), *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]), v46, v47);\n\tt.endValue = v213;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+12C]) = v213.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+130]) = v213.z;\n\treturn 1;\nL_00C8:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 156 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetLookAt(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			//IL_01f2: Expected F4, but got I
			//IL_0207: Expected F4, but got I
			//IL_021c: Expected F4, but got I
			Transform transform;
			if (t.target == null)
			{
				transform = null;
			}
			else
			{
				Transform transform2 = t.target as Transform;
				object obj = (((object)transform2 == null) ? null : t.target);
				transform = (Transform)obj;
			}
			Vector3 position = transform.position;
			position = t.endValue - position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]");
			float z;
			Vector3 vector;
			float y;
			if ((IntPtr)0 != (IntPtr)8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]");
				if ((IntPtr)0 != (IntPtr)4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+144]");
					bool flag = (IntPtr)0 != (IntPtr)2;
					z = position.z;
					vector = position;
					y = position.y;
					if (!flag)
					{
						z = position.z;
						vector = default(Vector3);
						y = position.y;
					}
				}
				else
				{
					z = position.z;
					vector = position;
					y = 0f;
				}
			}
			else
			{
				z = 0f;
				vector = position;
				y = position.y;
			}
			Vector3 forward = default(Vector3);
			forward.x = vector.x;
			forward.y = y;
			forward.z = z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+148]");
			Vector3 upwards = default(Vector3);
			upwards.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]");
			upwards.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]");
			upwards.z = 0f;
			Quaternion endValue = Quaternion.LookRotation(forward, upwards);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
			t.endValue = (Vector3)endValue;
			_ = endValue.y;
			_ = endValue.z;
			return true;
		}

		[Token(Token = "0x600022D")]
		[Address(RVA = "0x108385C", Offset = "0x108385C", Length = "0x1F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv40 = *([1EB36E0]);\n\tv41 = *([v40 @ X8_v24]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([2026A5C]) = v60;\nL_0021:\n\tv63 = t.getter == 0;\n\tif (v63) goto L_00A4;\n\tv148 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv120 = t.endValue;\n\tt.isSpeedBased = 0;\n\tt.<isRelative>k__BackingField = 0;\n\tt.easeType = 6;\n\tt.customEase = 0;\n\tv200 = v120.Length < 1;\n\tif (v200) goto L_FFFFFFFF;\nL_0046:\n\t;\n\tv347 = v89 < v120.Length;\n\tv348 = ~v347;\n\tif (v348) goto L_009E;\n\tv218 = v120 + v142;\n\tgoto L_0066;\n\tv468 = *([v415 @ X0_v32+E0]);\n\tv469 = v468 == 0;\n\tv470 = ~v469;\n\tif (v470) goto L_0066;\n\tv472 = \"il2cpp_codegen_runtime_class_init\"(v415, v147, v44, v45, v46, v47, v48, v49, v342, v341, v340, v327, v326, v325, v56, v57);\nL_0066:\n\t// 102 MakeStruct v204 @ AGG1083958_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v218 @ X25_v9+20], [v218 @ X25_v9+24], [v218 @ X25_v9+28]\n\tv248 = UnityEngine.Vector3::op_Addition(v204, v148);\n\tv480 = v89 < v120.Length;\n\tv426 = ~v480;\n\tif (v426) goto L_009E;\n\tv89 = v89 + 1;\n\t*([v218 @ X25_v9+20]) = v248;\n\t*([v218 @ X25_v9+24]) = v248.y;\n\t*([v218 @ X25_v9+28]) = v248.z;\n\tv224 = v89 >= v120.Length;\n\tif (v224) goto L_FFFFFFFF;\n\tv120 = t.endValue;\n\tv142 = v142 + 0xC;\n\tv484 = t.endValue == 0;\n\tv252 = ~v484;\n\tif (v252) goto L_0046;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn returnVal1;\nL_009E:\n\tv428 = new System.IndexOutOfRangeException();\n\tthrow v428;\n\tv144 = new System.NullReferenceException();\nL_00A4:\n\tv183 = new System.NullReferenceException();\n\tgoto L_00B0;\nL_00B0:\n\tv269 = v311 != 1;\n\tif (v269) goto L_00CC;\n\tv305 = 0x6D2BC0(v183, v311, v309, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\tv394 = *([v305 @ X0_v10]);\n\tv413 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v394 @ X8_v6]), v309, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\tv467 = v413 & 1;\n\tv316 = v467 == 0;\n\tif (v316) goto L_00C2;\n\tv477 = 0x6D2490(v413, *([v394 @ X8_v6]), v309, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\tgoto L_009D;\nL_00C2:\n\tv479 = 0x6D1E60(8, *([v394 @ X8_v6]), v309, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\t*([v479 @ X0_v14]) = *([v305 @ X0_v10]);\n\tv311 = 0x1E8A000 + 0x870;\n\tv482 = 0x6D2A00(v479, v311, 0, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\tv314 = 0x6D2490(v482, v311, 0, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\nL_00CC:\n\tv322 = 0x6D2380(v317, v311, 0, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\treturnVal2 = 0x846AA4(v322, v311, 0, v45, v46, v47, v48, v49, v177, v176, v175, v154, v153, v152, v56, v57);\n\treturn returnVal2;\n// 139 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetPunch(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_00c3: Expected O, but got I
			//IL_00e0: Expected F4, but got I
			//IL_00f5: Expected F4, but got I
			//IL_010a: Expected F4, but got I
			if (t.getter != null)
			{
				Vector3 vector = t.getter();
				Vector3[] endValue = t.endValue;
				t.isSpeedBased = false;
				t._003CisRelative_003Ek__BackingField = false;
				t.easeType = Ease.OutQuad;
				t.customEase = null;
				if (endValue.Length >= 1)
				{
					int num = 0;
					int num2 = 0;
					Vector3 vector2 = default(Vector3);
					while (true)
					{
						if (num < endValue.Length)
						{
							object obj = (long)(IntPtr)endValue + (long)num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X25_v9+20]");
							vector2.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X25_v9+24]");
							vector2.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v218 @ X25_v9+28]");
							vector2.z = 0f;
							Vector3 vector3 = vector2 + vector;
							if (num < endValue.Length)
							{
								num++;
								_ = vector3.y;
								_ = vector3.z;
								if (num >= endValue.Length)
								{
									break;
								}
								endValue = t.endValue;
								num2 += 12;
								if (t.endValue == null)
								{
									throw new NullReferenceException();
								}
								continue;
							}
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
				}
				return true;
			}
			NullReferenceException ex2 = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex3 = ex2;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				object obj2 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj4 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj5 = obj3;
				intPtr = (IntPtr)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex4 = default(NullReferenceException);
				ex3 = ex4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x600022E")]
		[Address(RVA = "0x1083A4C", Offset = "0x1083A4C", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetPunch(t);\n\tv13 = v10 == 0;\n\tif (v13) goto L_FFFFFFFF;\n\tt.easeType = 1;\n\tgoto L_0014;\nL_0014:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetShake(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			if (SetPunch(t))
			{
				t.easeType = Ease.Linear;
				return true;
			}
			return false;
		}

		[Token(Token = "0x600022F")]
		[Address(RVA = "0x1083A8C", Offset = "0x1083A8C", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = &v39 @ stack_-10_v2;\n\tgoto L_0023;\n\tv48 = *([1EB97A0]);\n\tv49 = *([v48 @ X8_v29]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([2026A5D]) = v68;\nL_0023:\n\tv70 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetShake(t);\n\tv72 = v70 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tv120 = t.target;\n\tv121 = t.target == 0;\n\tif (v121) goto L_FFFFFFFF;\n\tv395 = *([v120 @ X8_v8 (System.Object)]) != UnityEngine.Camera;\n\tif (v395) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0047;\nL_0047:\n\tgoto L_0050;\n\tv551 = *([v535 @ X0_v13+E0]);\n\tv552 = v551 == 0;\n\tv553 = ~v552;\n\tgoto L_0050;\n\tv555 = \"il2cpp_codegen_runtime_class_init\"(v535, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\nL_0050:\n\tv112 = UnityEngine.Object::op_Equality(v118, 0);\n\tv114 = v112 == 0;\n\tif (v114) goto L_005C;\n\tgoto L_0109;\nL_005C:\n\tv217 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\t*([v38 @ X29_v1-44]) = v217;\n\tv255 = UnityEngine.Component::get_transform(v118);\n\tv201 = t.endValue;\n\tv539 = v201.Length < 1;\n\tif (v539) goto L_FFFFFFFF;\nL_007F:\n\t;\n\tv577 = v186 < v201.Length;\n\tv249 = ~v577;\n\tif (v249) goto L_010A;\n\tv180 = v201 + v189;\n\tv593 = UnityEngine.Transform::get_localRotation(v255);\n\tgoto L_00A4;\n\tv601 = *([v597 @ X0_v25+E0]);\n\tv602 = v601 == 0;\n\tv603 = ~v602;\n\tif (v603) goto L_00A4;\n\tv605 = \"il2cpp_codegen_runtime_class_init\"(v597, v221, v75, v53, v54, v55, v56, v57, v593, v594, v595, v596, v154, v151, v140, v65);\nL_00A4:\n\t;\n\t// 171 MakeStruct v146 @ AGG1083C28_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v180 @ X27_v8+20], [v180 @ X27_v8+24], [v180 @ X27_v8+28]\n\t// 172 MakeStruct v142 @ AGG1083C28_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v38 @ X29_v1-44], v217.y (System.Single), v217.z (System.Single)\n\tv615 = UnityEngine.Vector3::op_Subtraction(v146, v142);\n\tgoto L_00C7;\n\tv622 = *([v618 @ X0_v28+E0]);\n\tv623 = v622 == 0;\n\tv624 = ~v623;\n\tif (v624) goto L_00C7;\n\tv626 = \"il2cpp_codegen_runtime_class_init\"(v618, v221, v75, v53, v54, v55, v56, v57, v615, v616, v617, v608, v609, v613, v140, v65);\nL_00C7:\n\tv635 = UnityEngine.Quaternion::op_Multiply(v593, v615);\n\t// 207 MakeStruct v123 @ AGG1083C84_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v38 @ X29_v1-44], v217.y (System.Single), v217.z (System.Single)\n\tv216 = UnityEngine.Vector3::op_Addition(v635, v123);\n\tv638 = v186 < v201.Length;\n\tv586 = ~v638;\n\tif (v586) goto L_010A;\n\tv186 = v186 + 1;\n\t*([v180 @ X27_v8+20]) = v216;\n\t*([v180 @ X27_v8+24]) = v216.y;\n\t*([v180 @ X27_v8+28]) = v216.z;\n\tv195 = v186 >= v201.Length;\n\tif (v195) goto L_FFFFFFFF;\n\tv201 = t.endValue;\n\tv189 = v189 + 0xC;\n\tv640 = t.endValue == 0;\n\tv258 = ~v640;\n\tif (v258) goto L_007F;\n\tthrow System.NullReferenceException;\nL_0109:\n\treturn returnVal1;\nL_010A:\n\tv588 = new System.IndexOutOfRangeException();\n\tthrow v588;\n\treturn returnVal2;\n// 194 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetCameraShakePosition(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_0144: Expected O, but got I
			//IL_016f: Expected F4, but got I
			//IL_0184: Expected F4, but got I
			//IL_0199: Expected F4, but got I
			//IL_01ae: Expected F4, but got I
			//IL_020f: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			if (SetShake(t))
			{
				object target = t.target;
				UnityEngine.Object obj4;
				if (t.target != null)
				{
					object obj3 = (((object)target.GetType() != typeof(Camera)) ? null : t.target);
					obj4 = (UnityEngine.Object)obj3;
				}
				else
				{
					obj4 = null;
				}
				if (!(obj4 == null))
				{
					Vector3 vector = t.getter();
					Transform transform = ((Component)obj4).transform;
					Vector3[] endValue = t.endValue;
					if (endValue.Length >= 1)
					{
						int num = 0;
						int num2 = 0;
						Vector3 vector2 = default(Vector3);
						Vector3 vector3 = default(Vector3);
						Vector3 vector6 = default(Vector3);
						while (true)
						{
							if (num < endValue.Length)
							{
								object obj5 = (long)(IntPtr)endValue + (long)num2;
								Quaternion localRotation = transform.localRotation;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X27_v8+20]");
								vector2.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X27_v8+24]");
								vector2.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X27_v8+28]");
								vector2.z = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-44]");
								vector3.x = 0f;
								vector3.y = vector.y;
								vector3.z = vector.z;
								Vector3 vector4 = vector2 - vector3;
								Vector3 vector5 = localRotation * vector4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X29_v1-44]");
								vector6.x = 0f;
								vector6.y = vector.y;
								vector6.z = vector.z;
								Vector3 vector7 = vector5 + vector6;
								if (num < endValue.Length)
								{
									num++;
									_ = vector7.y;
									_ = vector7.z;
									if (num >= endValue.Length)
									{
										break;
									}
									endValue = t.endValue;
									num2 += 12;
									if (t.endValue == null)
									{
										throw new NullReferenceException();
									}
									continue;
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
					}
					return true;
				}
			}
			return false;
		}
	}
}
