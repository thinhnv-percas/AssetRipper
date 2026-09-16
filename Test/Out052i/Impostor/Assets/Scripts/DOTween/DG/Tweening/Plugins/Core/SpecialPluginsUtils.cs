using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins.Core
{
	[Token(Token = "0x2000094")]
	internal static class SpecialPluginsUtils
	{
		[Token(Token = "0x6000375")]
		[Address(RVA = "0xC22254", Offset = "0xC22254", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = UnityEngine.Transform;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3579D]) = v39;\nL_0028:\n\tgoto L_FFFFFFFF;\n\tv171 = UnityEngine.Transform::get_position(t.target);\n\tv210 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]) - v171.y;\n\tv208 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) - v171.z;\n\tv181 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]) == 2;\n\tif (v181) goto L_FFFFFFFF;\n\tv190 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]) == 4;\n\tv211 = t.endValue - v171;\n\tif (v190) goto L_FFFFFFFF;\n\tv206 = *([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]) != 8;\n\tif (v206) goto L_006B;\n\tgoto L_006B;\n\tgoto L_006B;\nL_006B:\n\t// 107 MakeStruct v107 @ AGGC26328_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v211 @ V0_v2 (System.Single), v210 @ V1_v3 (System.Single), v208 @ V2_v3 (System.Single)\n\t// 108 MakeStruct v104 @ AGGC26328_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150], [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+154], [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+158]\n\tv214 = UnityEngine.Quaternion::LookRotation(v107, v104);\n\tv219 = UnityEngine.Quaternion::Internal_ToEulerRad(v214);\n\tv223 = v219 * 57.29578f;\n\tv224 = v219.y * 57.29578f;\n\tv225 = v219.z * 57.29578f;\n\t// 124 MakeStruct v116 @ AGGC2634C_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v223 @ V0_v5 (System.Single), v224 @ V1_v6 (System.Single), v225 @ V2_v6 (System.Single)\n\tv128 = UnityEngine.Quaternion::Internal_MakePositive(v116);\n\tt.endValue = v128;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]) = v128.y;\n\t*([t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]) = v128.z;\n\treturn 1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetLookAt(TweenerCore<Quaternion, Vector3, QuaternionOptions> t)
		{
			//IL_0196: Expected F4, but got I
			//IL_01ab: Expected F4, but got I
			//IL_01c0: Expected F4, but got I
			Transform transform = t.target as Transform;
			Vector3 position = ((Transform)t.target).position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+134]");
			float y = 0f - position.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+138]");
			float z = 0f - position.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]");
			float x;
			if ((nint)0 != 2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]");
				bool flag = (nint)0 == 4;
				x = t.endValue.x - position.x;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+14C]");
					if ((nint)0 == 8)
					{
						z = 0f;
					}
				}
				else
				{
					y = 0f;
				}
			}
			else
			{
				x = 0f;
			}
			Vector3 forward = default(Vector3);
			forward.x = x;
			forward.y = y;
			forward.z = z;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+150]");
			Vector3 upwards = default(Vector3);
			upwards.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+154]");
			upwards.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [t @ X0 (DG.Tweening.Core.TweenerCore`3<UnityEngine.Quaternion, UnityEngine.Vector3, DG.Tweening.Plugins.Options.QuaternionOptions>)+158]");
			upwards.z = 0f;
			Quaternion rotation = Quaternion.LookRotation(forward, upwards);
			Vector3 vector = Quaternion.Internal_ToEulerRad(rotation);
			float x2 = vector.x * 57.29578f;
			float y2 = vector.y * 57.29578f;
			float z2 = vector.z * 57.29578f;
			Vector3 euler = default(Vector3);
			euler.x = x2;
			euler.y = y2;
			euler.z = z2;
			Vector3 vector2 = (t.endValue = Quaternion.Internal_MakePositive(euler));
			_ = vector2.y;
			_ = vector2.z;
			return true;
		}

		[Token(Token = "0x6000376")]
		[Address(RVA = "0xC282E0", Offset = "0xC282E0", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = t.getter == 0;\n\tif (v8) goto L_0050;\n\tv83 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv52 = t.endValue;\n\tt.isSpeedBased = 0;\n\tt.<isRelative>k__BackingField = 0;\n\tt.easeType = 6;\n\tt.customEase = 0;\n\tv22 = v52.Length < 1;\n\tif (v22) goto L_FFFFFFFF;\n\tv49 = v52.Length & 0xFFFFFFFF;\nL_0031:\n\tv171 = v52 + v64;\n\tv55 = v55 + 1;\n\tv136 = v49 == v55;\n\tv124 = v75 + *([v171 @ X11_v8+20]);\n\tv122 = v76 + *([v171 @ X11_v8+28]);\n\t*([v171 @ X11_v8+20]) = v124;\n\t*([v171 @ X11_v8+28]) = v122;\n\tif (v136) goto L_FFFFFFFF;\n\tv52 = t.endValue;\n\tv64 = v64 + 0xC;\n\tv271 = t.endValue == 0;\n\tv151 = ~v271;\n\tif (v151) goto L_0031;\n\tthrow System.NullReferenceException;\nL_004D:\n\treturn returnVal1;\n\tv61 = new System.IndexOutOfRangeException();\n\tv68 = new System.NullReferenceException();\nL_0050:\n\tv108 = new System.NullReferenceException();\n\tgoto L_005D;\n\tgoto L_005D;\nL_005D:\n\tv187 = v230 != 1;\n\tif (v187) goto L_0079;\n\tv227 = 0x1854E70(v108, v230, v228, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\tv221 = *([v227 @ X0_v9]);\n\tv272 = \"il2cpp_vm_class_is_assignable_from\"(System.Object, *([v221 @ X8_v4]), v228, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\tv273 = v272 & 1;\n\tv223 = v273 == 0;\n\tif (v223) goto L_006F;\n\tv274 = 0x1854E80(v272, *([v221 @ X8_v4]), v228, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\tgoto L_004D;\nL_006F:\n\tv276 = 0x1854E90(8, *([v221 @ X8_v4]), v228, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\t*([v276 @ X0_v15]) = *([v227 @ X0_v9]);\n\tv230 = 0x185A000 + 0xF88;\n\tv278 = 0x1854EA0(v276, v230, 0, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\tv233 = 0x1854E80(v278, v230, 0, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\nL_0079:\n\tv240 = 0xBD3CD0(v234, v230, 0, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\treturnVal2 = 0x9DACB4(v240, v230, 0, v70, v71, v72, v73, v74, v75, v89, v76, v88, v77, v78, v79, v80);\n\treturn returnVal2;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetPunch(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_00ae: Expected I4, but got I8
			//IL_00d3: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_011b: Expected O, but got I
			if (t.getter != null)
			{
				object obj = t.getter();
				Vector3[] endValue = t.endValue;
				t.isSpeedBased = false;
				t._003CisRelative_003Ek__BackingField = false;
				t.easeType = Ease.OutQuad;
				t.customEase = null;
				if (endValue.Length >= 1)
				{
					int num = (int)(endValue.Length & 0xFFFFFFFFL);
					int num2 = 0;
					int num3 = 0;
					object obj3 = default(object);
					object obj5 = default(object);
					while (true)
					{
						object obj2 = (nint)endValue + num3;
						num2++;
						bool flag = num == num2;
						nint num4 = (nint)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X11_v8+20]");
						object obj4 = num4 + 0;
						nint num5 = (nint)obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X11_v8+28]");
						object obj6 = num5 + 0;
						if (flag)
						{
							break;
						}
						endValue = t.endValue;
						num3 += 12;
						if (t.endValue == null)
						{
							throw new NullReferenceException();
						}
					}
				}
				return true;
			}
			NullReferenceException ex = new NullReferenceException();
			nint num6 = default(nint);
			bool flag2 = num6 != 1;
			NullReferenceException ex2 = ex;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj8 = default(object);
				object obj7 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj9 = default(object);
				if ((int)((nint)obj9 & 1) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					return false;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E90 (native __cxa_allocate_exception)");
				object obj10 = obj8;
				num6 = 25538440;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EA0 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				NullReferenceException ex3 = default(NullReferenceException);
				ex2 = ex3;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			bool result = default(bool);
			return result;
		}

		[Token(Token = "0x6000377")]
		[Address(RVA = "0xC28414", Offset = "0xC28414", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetPunch(t);\n\tv9 = v6 == 0;\n\tif (v9) goto L_0010;\n\tt.easeType = 1;\nL_0010:\n\treturn v6;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetShake(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			bool flag = SetPunch(t);
			if (flag)
			{
				t.easeType = Ease.Linear;
			}
			return flag;
		}

		[Token(Token = "0x6000378")]
		[Address(RVA = "0xC28440", Offset = "0xC28440", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv36 = UnityEngine.Camera;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A3579E]) = v56;\nL_001F:\n\tv58 = DG.Tweening.Plugins.Core.SpecialPluginsUtils::SetShake(t);\n\tv62 = v58 == 0;\n\tif (v62) goto L_FFFFFFFF;\n\tv110 = t.target;\n\tv111 = t.target == 0;\n\tif (v111) goto L_FFFFFFFF;\n\tv329 = *([v110 @ X8_v7 (System.Object)]) != UnityEngine.Camera;\n\tif (v329) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tgoto L_0048;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v411, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0048:\n\tv102 = UnityEngine.Object::op_Equality(v108, 0);\n\tv104 = v102 == 0;\n\tif (v104) goto L_004E;\n\tgoto L_00C3;\nL_004E:\n\t;\n\tv210 = DG.Tweening.Core.DOGetter`1<UnityEngine.Vector3>::Invoke(t.getter);\n\tv211 = UnityEngine.Component::get_transform(v108);\n\tv167 = t.endValue;\n\tv162 = v167.Length < 1;\n\tif (v162) goto L_FFFFFFFF;\n\tv154 = v167.Length & 0xFFFFFFFF;\nL_007E:\n\tv151 = v167 + v160;\n\tv448 = UnityEngine.Transform::get_localRotation(v211);\n\tv127 = *([v151 @ X25_v7+20]) - v45;\n\tv124 = *([v151 @ X25_v7+24]) - v46;\n\tv121 = *([v151 @ X25_v7+28]) - v47;\n\t// 141 MakeStruct v113 @ AGGC2C588_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v127 @ V4_v6, v124 @ V5_v6, v121 @ V6_v6\n\tv437 = UnityEngine.Quaternion::op_Multiply(v448, v113);\n\tv157 = v157 + 1;\n\tv133 = v47 + v437.z;\n\tv136 = v46 + v437.y;\n\tv139 = v45 + v437;\n\tv194 = v154 == v157;\n\t*([v151 @ X25_v7+20]) = v139;\n\t*([v151 @ X25_v7+24]) = v136;\n\t*([v151 @ X25_v7+28]) = v133;\n\tif (v194) goto L_FFFFFFFF;\n\tv167 = t.endValue;\n\tv160 = v160 + 0xC;\n\tv453 = t.endValue == 0;\n\tv214 = ~v453;\n\tif (v214) goto L_007E;\n\tthrow System.NullReferenceException;\nL_00C3:\n\treturn returnVal1;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool SetCameraShakePosition(TweenerCore<Vector3, Vector3[], Vector3ArrayOptions> t)
		{
			//IL_012c: Expected I4, but got I8
			//IL_0151: Expected O, but got I
			//IL_0174: Expected O, but got I
			//IL_018a: Expected O, but got I
			//IL_01a0: Expected O, but got I
			//IL_01ad: Expected F4, but got O
			//IL_01ba: Expected F4, but got O
			//IL_01c7: Expected F4, but got O
			if (SetShake(t))
			{
				object target = t.target;
				UnityEngine.Object obj2;
				if (t.target != null)
				{
					object obj = (((object)target.GetType() != typeof(Camera)) ? null : t.target);
					obj2 = (UnityEngine.Object)obj;
				}
				else
				{
					obj2 = null;
				}
				if (!(obj2 == null))
				{
					object obj3 = t.getter();
					Transform transform = ((Component)obj2).transform;
					Vector3[] endValue = t.endValue;
					if (endValue.Length >= 1)
					{
						int num = (int)(endValue.Length & 0xFFFFFFFFL);
						int num2 = 0;
						int num3 = 0;
						object obj6 = default(object);
						object obj8 = default(object);
						object obj10 = default(object);
						Vector3 vector = default(Vector3);
						while (true)
						{
							object obj4 = (nint)endValue + num3;
							Quaternion localRotation = transform.localRotation;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X25_v7+20]");
							object obj5 = -(nint)obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X25_v7+24]");
							object obj7 = -(nint)obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X25_v7+28]");
							object obj9 = -(nint)obj10;
							vector.x = (float)obj5;
							vector.y = (float)obj7;
							vector.z = (float)obj9;
							Vector3 vector2 = localRotation * vector;
							num2++;
							float num4 = (float)obj10 + vector2.z;
							float num5 = (float)obj8 + vector2.y;
							float num6 = (float)obj6 + vector2.x;
							if (num == num2)
							{
								break;
							}
							endValue = t.endValue;
							num3 += 12;
							if (t.endValue == null)
							{
								throw new NullReferenceException();
							}
						}
					}
					return true;
				}
			}
			return false;
		}
	}
}
