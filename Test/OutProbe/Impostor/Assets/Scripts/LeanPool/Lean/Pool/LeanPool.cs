using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Lean.Pool
{
	[Token(Token = "0x2000009")]
	public static class LeanPool
	{
		[Token(Token = "0x400001F")]
		public const string HelpUrlPrefix = "https://carloswilkes.github.io/Documentation/LeanPool#";

		[Token(Token = "0x4000020")]
		public const string ComponentPathPrefix = "Lean/Pool/Lean ";

		[Token(Token = "0x4000021")]
		public static Dictionary<GameObject, LeanGameObjectPool> Links;

		[Token(Token = "0x600003A")]
		[Address(RVA = "0xC77EB0", Offset = "0xC77EB0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tgoto L_0027;\n\tv39 = 0xB3490C(methodInfo, parent, worldPositionStays, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0027:\n\tgoto L_002C;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v47, parent, worldPositionStays, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002C:\n\tv59 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv64 = v59 == 0;\n\tif (v64) goto L_0042;\n\tgoto L_003C;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v69, v57, v58, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_0077;\nL_0042:\n\tv83 = UnityEngine.Component::get_gameObject(prefab);\n\tgoto L_0051;\n\tv128 = v107;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v128, v82, v58, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv134 = Lean.Pool.LeanPool::Spawn(v83, parent, worldPositionStays);\n\tgoto L_005D;\n\tv159 = v102;\n\tv160 = \"il2cpp_codegen_runtime_class_init\"(v159, v133, v131, v85, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005D:\n\tv94 = UnityEngine.Object::op_Inequality(v134, 0);\n\tv117 = v94 == 0;\n\tif (v117) goto L_0077;\n\treturnVal3 = UnityEngine.GameObject::GetComponent(v134);\n\treturn returnVal3;\nL_0077:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn<T>(T prefab, Transform parent, bool worldPositionStays = false) where T : Component
		{
			if (prefab == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
			}
			else
			{
				GameObject gameObject = prefab.gameObject;
				GameObject gameObject2 = Spawn(gameObject, parent, worldPositionStays);
				if (gameObject2 != null)
				{
					return gameObject2.GetComponent<T>();
				}
			}
			return null;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0xC78018", Offset = "0xC78018", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tgoto L_0038;\n\tv57 = 0xB3490C(methodInfo, parent, methodInfo, v50, v51, v52, v53, v54, position, position.y, position.z, rotation, rotation.y, rotation.z, rotation.w, v55);\nL_0038:\n\tgoto L_003D;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v65, parent, methodInfo, v50, v51, v52, v53, v54, position, v0, v2, rotation, v3, v5, v6, v55);\nL_003D:\n\tv77 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv82 = v77 == 0;\n\tif (v82) goto L_0053;\n\tgoto L_004D;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v87, v75, v76, v50, v51, v52, v53, v54, position, v0, v2, rotation, v3, v5, v6, v55);\nL_004D:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_009C;\nL_0053:\n\tv101 = UnityEngine.Component::get_gameObject(prefab);\n\tgoto L_006A;\n\tv178 = v143;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v178, v100, v76, v50, v51, v52, v53, v54, position, v0, v2, rotation, v3, v5, v6, v55);\nL_006A:\n\tv184 = Lean.Pool.LeanPool::Spawn(v101, position, rotation, parent);\n\tgoto L_0076;\n\tv229 = v128;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v229, v182, v183, v50, v51, v52, v53, v54, v111, v138, v136, v109, v134, v132, v130, v55);\nL_0076:\n\tv120 = UnityEngine.Object::op_Inequality(v184, 0);\n\tv156 = v120 == 0;\n\tif (v156) goto L_009C;\n\treturnVal3 = UnityEngine.GameObject::GetComponent(v184);\n\treturn returnVal3;\nL_009C:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null) where T : Component
		{
			if (prefab == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
			}
			else
			{
				GameObject gameObject = prefab.gameObject;
				GameObject gameObject2 = Spawn(gameObject, position, rotation, parent);
				if (gameObject2 != null)
				{
					return gameObject2.GetComponent<T>();
				}
			}
			return null;
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0xC77D64", Offset = "0xC77D64", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tgoto L_0023;\n\tv33 = 0xB3490C(methodInfo, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0023:\n\tgoto L_0028;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0028:\n\tv53 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv58 = v53 == 0;\n\tif (v58) goto L_003E;\n\tgoto L_0038;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v63, v51, v52, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0038:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_006D;\nL_003E:\n\tv77 = UnityEngine.Component::get_gameObject(prefab);\n\tgoto L_004B;\n\tv115 = v98;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v115, v76, v52, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_004B:\n\tv120 = Lean.Pool.LeanPool::Spawn(v77);\n\tgoto L_0057;\n\tv140 = v92;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v140, v119, v52, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0057:\n\tv86 = UnityEngine.Object::op_Inequality(v120, 0);\n\tv107 = v86 == 0;\n\tif (v107) goto L_006D;\n\treturnVal3 = UnityEngine.GameObject::GetComponent(v120);\n\treturn returnVal3;\nL_006D:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Spawn<T>(T prefab) where T : Component
		{
			if (prefab == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
			}
			else
			{
				GameObject gameObject = prefab.gameObject;
				GameObject gameObject2 = Spawn(gameObject);
				if (gameObject2 != null)
				{
					return gameObject2.GetComponent<T>();
				}
			}
			return null;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x1361F38", Offset = "0x1361F38", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv42 = UnityEngine.Debug;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, parent, worldPositionStays, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv66 = Lean.Pool.LeanPool;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, parent, worldPositionStays, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv75 = UnityEngine.Object;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, parent, worldPositionStays, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv80 = \"Attempting to spawn a null prefab.\";\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, parent, worldPositionStays, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A36996]) = v60;\nL_002C:\n\tgoto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v61, parent, worldPositionStays, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0031:\n\tv73 = UnityEngine.Object::op_Equality(v351, 0);\n\tv78 = v73 == 0;\n\tif (v78) goto L_0048;\n\tgoto L_0041;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v84, v71, v72, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0041:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_00E3;\nL_0048:\n\tv96 = UnityEngine.GameObject::get_transform(v351);\n\tgoto L_0054;\n\tv200 = v112;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v200, v95, v72, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0054:\n\tv107 = UnityEngine.Object::op_Inequality(v175, 0);\n\tv239 = v107 == 0;\n\tif (v239) goto L_00A4;\n\tv241 = worldPositionStays == 0;\n\tif (v241) goto L_00A4;\n\tv106 = UnityEngine.GameObject::get_transform(v351);\n\tv169 = UnityEngine.Transform::get_position(v106);\n\tv167 = v169.y;\n\tv165 = v169.z;\n\tgoto L_0075;\n\tv288 = UnityEngine.Quaternion;\n\tv289 = \"il2cpp_codegen_initialize_runtime_metadata\"(v288, v255, v101, methodInfo, v45, v46, v47, v48, v256, v267, v268, v52, v53, v54, v55, v56);\n\tv292 = 1;\n\t*([1A3551A]) = v292;\nL_0075:\n\tv297 = UnityEngine.Quaternion;\n\tv298 = *([v297 @ X8_v15 (Il2CppClass<UnityEngine.Quaternion>)+B8]);\n\tgoto L_0090;\n\tv321 = UnityEngine.Vector3;\n\tv322 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, v255, v101, methodInfo, v45, v46, v47, v48, v256, v267, v268, v52, v53, v54, v55, v56);\n\tv325 = 1;\n\t*([1A35658]) = v325;\nL_0090:\n\tgoto L_FFFFFFFF;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v332, v255, v101, methodInfo, v45, v46, v47, v48, v256, v267, v268, v52, v53, v54, v55, v56);\n\tgoto L_00D1;\nL_00A4:\n\tv169 = UnityEngine.Transform::get_localPosition(v96);\n\tv167 = v169.y;\n\tv165 = v169.z;\n\tv254 = UnityEngine.Transform::get_localRotation(v96);\n\tv266 = UnityEngine.Transform::get_localScale(v96);\n\tgoto L_FFFFFFFF;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v283, v261, v101, methodInfo, v45, v46, v47, v48, v266, v276, v277, v259, v53, v54, v55, v56);\nL_00D1:\n\t// 209 MakeStruct v123 @ AGG13661B0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v169 @ V0_v2 (UnityEngine.Vector3), v167 @ V1_v2 (System.Single), v165 @ V2_v2 (System.Single)\n\t// 210 MakeStruct v120 @ AGG13661B0_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v155 @ V3_v2 (UnityEngine.Quaternion), v153 @ V4_v2 (System.Single), v151 @ V5_v2 (System.Single), v149 @ V6_v2 (System.Single)\n\treturnVal2 = Lean.Pool.LeanPool::Spawn(v351, v123, v120, v140, v175, v173);\nL_00E3:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject Spawn(GameObject prefab, Transform parent, bool worldPositionStays = false)
		{
			//IL_01d9: Expected I, but got O
			//IL_01e2: Expected I, but got O
			//IL_00fa: Expected F4, but got I
			//IL_010a: Expected F4, but got I
			//IL_011a: Expected F4, but got I
			GameObject gameObject = default(GameObject);
			if (gameObject == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
				return null;
			}
			Transform transform = gameObject.transform;
			Transform transform2 = default(Transform);
			Vector3 vector;
			float y;
			float z;
			Vector3 localScale;
			float w;
			float z2;
			float y2;
			Quaternion quaternion;
			bool worldPositionStays2;
			if (transform2 != null && worldPositionStays)
			{
				Transform transform3 = gameObject.transform;
				vector = transform3.position;
				y = vector.y;
				z = vector.z;
				nint num = (nint)typeof(Quaternion);
				nint num2 = (nint)Quaternion.identity;
				localScale = Vector3.one;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v16 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]");
				w = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v16 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]");
				z2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X8_v16 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]");
				y2 = 0f;
				quaternion = Quaternion.identity;
				worldPositionStays2 = true;
			}
			else
			{
				vector = transform.localPosition;
				y = vector.y;
				z = vector.z;
				Quaternion localRotation = transform.localRotation;
				Vector3 localScale2 = transform.localScale;
				localScale = localScale2;
				w = localRotation.w;
				z2 = localRotation.z;
				y2 = localRotation.y;
				quaternion = localRotation;
				worldPositionStays2 = false;
			}
			Vector3 localPosition = default(Vector3);
			localPosition.x = vector.x;
			localPosition.y = y;
			localPosition.z = z;
			Quaternion localRotation2 = default(Quaternion);
			localRotation2.x = quaternion.x;
			localRotation2.y = y2;
			localRotation2.z = z2;
			localRotation2.w = w;
			return Spawn(gameObject, localPosition, localRotation2, localScale, transform2, worldPositionStays2);
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x1362514", Offset = "0x1362514", Length = "0x25C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv52 = UnityEngine.Debug;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, parent, methodInfo, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\n\tv70 = Lean.Pool.LeanPool;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, parent, methodInfo, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\n\tv79 = UnityEngine.Object;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, parent, methodInfo, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\n\tv84 = \"Attempting to spawn a null prefab.\";\n\tv62 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, parent, methodInfo, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\n\tv64 = 1;\n\t*([1A36997]) = v64;\nL_0036:\n\tgoto L_003B;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v65, parent, methodInfo, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\nL_003B:\n\tv77 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv82 = v77 == 0;\n\tif (v82) goto L_0052;\n\tgoto L_004B;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v87, v75, v76, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\nL_004B:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_00C9;\nL_0052:\n\tgoto L_0057;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v91, v75, v76, v55, v56, v57, v58, v59, position, v0, v2, rotation, v3, v5, v6, v60);\nL_0057:\n\tv106 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv109 = v106 == 0;\n\tif (v109) goto L_0099;\n\tv337 = UnityEngine.Transform::InverseTransformPoint(parent, position);\n\tv346 = UnityEngine.Transform::get_rotation(parent);\n\tv350 = UnityEngine.Quaternion::Inverse(v346);\n\tv356 = rotation * v350.w;\n\tv357 = rotation.w * v350;\n\tv358 = rotation.y * v350.w;\n\tv224 = rotation.w * v350.y;\n\tv223 = rotation.z * v350;\n\tv222 = rotation.y * v350;\n\tv359 = rotation * v350;\n\tv221 = rotation.z * v350.w;\n\tv360 = rotation.w * v350.w;\n\tv220 = rotation.w * v350.z;\n\tv249 = rotation.z * v350.y;\n\tv219 = rotation * v350.z;\n\tv218 = rotation * v350.y;\n\tv257 = rotation.y * v350.y;\n\tv361 = v356 + v357;\n\tv362 = v358 + v224;\n\tv225 = v221 + v220;\n\tv363 = v360 - v359;\n\tv217 = rotation.y * v350.z;\n\tv255 = rotation.z * v350.z;\n\tv228 = v249 + v361;\n\tv253 = v219 + v362;\n\tv251 = v222 + v225;\n\tv231 = v363 - v257;\n\tv242 = v228 - v217;\n\tv186 = v253 - v223;\n\tv244 = v251 - v218;\n\tv246 = v231 - v255;\nL_0099:\n\tv340 = UnityEngine.GameObject::get_transform(prefab);\n\tv352 = UnityEngine.Transform::get_localScale(v340);\n\tgoto L_00B8;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v368, v351, v105, v55, v56, v57, v58, v59, v352, v364, v365, v227, v252, v250, v248, v134);\nL_00B8:\n\t// 184 MakeStruct v114 @ AGG1366744_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v178 @ V14_v4 (UnityEngine.Vector3), v238 @ V12_v4 (System.Single), v240 @ V11_v4 (System.Single)\n\t// 185 MakeStruct v111 @ AGG1366744_2_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v184 @ V13_v4 (UnityEngine.Quaternion), v186 @ V10_v4 (System.Single), v244 @ V9_v4 (System.Single), v246 @ V8_v4 (System.Single)\n\treturnVal1 = Lean.Pool.LeanPool::Spawn(prefab, v114, v111, v352, parent, 0);\nL_00C9:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			//IL_0368: Expected O, but got F4
			if (prefab == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
				return null;
			}
			bool flag = parent != null;
			bool flag2 = !flag;
			Vector3 vector = position;
			float y = position.y;
			float z = position.z;
			Quaternion quaternion = rotation;
			float y2 = rotation.y;
			float z2 = rotation.z;
			float w = rotation.w;
			if (!flag2)
			{
				Vector3 vector2 = parent.InverseTransformPoint(position);
				Quaternion rotation2 = parent.rotation;
				Quaternion quaternion2 = Quaternion.Inverse(rotation2);
				Quaternion quaternion3 = default(Quaternion);
				float num = quaternion3.x * quaternion2.w;
				float num2 = rotation.w * quaternion2.x;
				float num3 = rotation.y * quaternion2.w;
				float num4 = rotation.w * quaternion2.y;
				float num5 = rotation.z * quaternion2.x;
				float num6 = rotation.y * quaternion2.x;
				float num7 = quaternion3.x * quaternion2.x;
				float num8 = rotation.z * quaternion2.w;
				float num9 = rotation.w * quaternion2.w;
				float num10 = rotation.w * quaternion2.z;
				float num11 = rotation.z * quaternion2.y;
				float num12 = quaternion3.x * quaternion2.z;
				float num13 = quaternion3.x * quaternion2.y;
				float num14 = rotation.y * quaternion2.y;
				float num15 = num + num2;
				float num16 = num3 + num4;
				float num17 = num8 + num10;
				float num18 = num9 - num7;
				float num19 = rotation.y * quaternion2.z;
				float num20 = rotation.z * quaternion2.z;
				float num21 = num11 + num15;
				float num22 = num12 + num16;
				float num23 = num6 + num17;
				float num24 = num18 - num14;
				float num25 = num21 - num19;
				y2 = num22 - num5;
				z2 = num23 - num13;
				w = num24 - num20;
				vector = vector2;
				y = vector2.y;
				z = vector2.z;
				quaternion = (Quaternion)num25;
			}
			Transform transform = prefab.transform;
			Vector3 localScale = transform.localScale;
			Vector3 localPosition = default(Vector3);
			localPosition.x = vector.x;
			localPosition.y = y;
			localPosition.z = z;
			Quaternion localRotation = default(Quaternion);
			localRotation.x = quaternion.x;
			localRotation.y = y2;
			localRotation.z = z2;
			localRotation.w = w;
			return Spawn(prefab, localPosition, localRotation, localScale, parent, worldPositionStays: false);
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x1362770", Offset = "0x1362770", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv34 = UnityEngine.Debug;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv60 = Lean.Pool.LeanPool;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv69 = UnityEngine.Object;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv74 = \"Attempting to spawn a null prefab.\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A36998]) = v54;\nL_0028:\n\tgoto L_002D;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002D:\n\tv67 = UnityEngine.Object::op_Equality(prefab, 0);\n\tv72 = v67 == 0;\n\tif (v72) goto L_0044;\n\tgoto L_003D;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v78, v65, v66, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_003D:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\n\tgoto L_0086;\nL_0044:\n\tv90 = UnityEngine.GameObject::get_transform(prefab);\n\tv174 = UnityEngine.Transform::get_localPosition(v90);\n\tv210 = UnityEngine.Transform::get_localRotation(v90);\n\tv216 = UnityEngine.Transform::get_localScale(v90);\n\tgoto L_0078;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v221, v215, v66, v38, v39, v40, v41, v42, v216, v217, v218, v213, v47, v48, v49, v50);\nL_0078:\n\treturnVal2 = Lean.Pool.LeanPool::Spawn(prefab, v174, v210, v216, 0, 0);\nL_0086:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject Spawn(GameObject prefab)
		{
			if (prefab == null)
			{
				Debug.LogError("Attempting to spawn a null prefab.");
				return null;
			}
			Transform transform = prefab.transform;
			Vector3 localPosition = transform.localPosition;
			Quaternion localRotation = transform.localRotation;
			Vector3 localScale = transform.localScale;
			return Spawn(prefab, localPosition, localRotation, localScale, null, worldPositionStays: false);
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x13621DC", Offset = "0x13621DC", Length = "0x338")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0051;\n\tv56 = UnityEngine.Debug;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv106 = UnityEngine.GameObject;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv119 = Lean.Pool.LeanGameObjectPool;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv180 = Lean.Pool.LeanPool;\n\tv181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v180, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv250 = UnityEngine.Object;\n\tv251 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv339 = \"Attempting to spawn a null prefab.\";\n\tv340 = \"il2cpp_codegen_initialize_runtime_metadata\"(v339, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv351 = \")\";\n\tv352 = \"il2cpp_codegen_initialize_runtime_metadata\"(v351, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv362 = \"You're attempting to spawn a clone that hasn't been despawned. Make sure all your Spawn and Despawn calls match, you shouldn't be manually destroying them!\";\n\tv363 = \"il2cpp_codegen_initialize_runtime_metadata\"(v362, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv368 = \"LeanPool (\";\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v368, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\n\tv67 = 1;\n\t*([1A36999]) = v67;\nL_0051:\n\tgoto L_0058;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, parent, worldPositionStays, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\nL_0058:\n\tv83 = UnityEngine.Object::op_Inequality(prefab, 0);\n\tv88 = v83 == 0;\n\tif (v88) goto L_00EC;\n\tgoto L_0067;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v95, v81, v82, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\nL_0067:\n\tv113 = Lean.Pool.LeanGameObjectPool::TryFindPoolByPrefab(prefab, &v111 @ stack_-78_v4 (Lean.Pool.LeanGameObjectPool));\n\tv122 = v113 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_00A7;\n\tv254 = UnityEngine.Object::get_name(prefab);\n\tv348 = System.String::Concat(\"LeanPool (\", v254, \")\");\n\tv275 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v275, v348);\n\tv192 = UnityEngine.GameObject::AddComponent(v275);\n\tLean.Pool.LeanGameObjectPool::set_Prefab(v192, prefab);\nL_00A7:\n\tv158 = Lean.Pool.LeanGameObjectPool::TrySpawn(v192, &v144 @ stack_-80_v6 (UnityEngine.GameObject), localPosition, localRotation, localScale, parent, worldPositionStays);\n\tv160 = v158 == 0;\n\tif (v160) goto L_FFFFFFFF;\n\tgoto L_00BD;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v357, v156, v154, v146, v59, v60, v61, v62, v142, v177, v175, v131, v173, v171, v169, v63);\n\tv366 = Lean.Pool.LeanPool;\nL_00BD:\n\tv276 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Remove(v287.Links, v144);\n\tv374 = v276 == 0;\n\tif (v374) goto L_00D8;\n\tv389 = ~v192.Recycle;\n\tv381 = ~v389;\n\tif (v381) goto L_00D8;\n\tgoto L_00D3;\n\tv397 = \"il2cpp_codegen_runtime_class_init\"(v393, v272, v267, v146, v59, v60, v61, v62, v142, v177, v175, v131, v173, v171, v169, v63);\nL_00D3:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to spawn a clone that hasn't been despawned. Make sure all your Spawn and Despawn calls match, you shouldn't be manually destroying them!\", v144);\nL_00D8:\n\tgoto L_00E4;\n\tv390 = \"il2cpp_codegen_runtime_class_init\"(v385, v273, v268, v146, v59, v60, v61, v62, v142, v177, v175, v131, v173, v171, v169, v63);\n\tv392 = Lean.Pool.LeanPool;\nL_00E4:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Add(v288.Links, v144, v192);\n\tgoto L_0102;\nL_00EC:\n\tgoto L_00F0;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v99, v81, v82, methodInfo, v59, v60, v61, v62, localPosition, v0, v2, localRotation, v3, v5, v6, v63);\nL_00F0:\n\tUnityEngine.Debug::LogError(\"Attempting to spawn a null prefab.\");\nL_0102:\n\treturn v221;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static GameObject Spawn(GameObject prefab, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			if (prefab != null)
			{
				LeanGameObjectPool foundPool = default(LeanGameObjectPool);
				LeanGameObjectPool leanGameObjectPool = default(LeanGameObjectPool);
				if (!LeanGameObjectPool.TryFindPoolByPrefab(prefab, ref foundPool))
				{
					string name = prefab.name;
					string name2 = "LeanPool (" + name + ")";
					GameObject gameObject = new GameObject(name2);
					leanGameObjectPool = gameObject.AddComponent<LeanGameObjectPool>();
					leanGameObjectPool.Prefab = prefab;
				}
				GameObject clone = default(GameObject);
				if (leanGameObjectPool.TrySpawn(ref clone, localPosition, localRotation, localScale, parent, worldPositionStays))
				{
					if (Links.Remove(clone) && !leanGameObjectPool.Recycle)
					{
						Debug.LogWarning("You're attempting to spawn a clone that hasn't been despawned. Make sure all your Spawn and Despawn calls match, you shouldn't be manually destroying them!", clone);
					}
					Links.Add(clone, leanGameObjectPool);
					return clone;
				}
			}
			else
			{
				Debug.LogError("Attempting to spawn a null prefab.");
			}
			return null;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x13628FC", Offset = "0x13628FC", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv121 = Il2CppMethodInfo;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv130 = Lean.Pool.LeanGameObjectPool;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv146 = Lean.Pool.LeanPool;\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv165 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v165, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv39 = 1;\n\t*([1A3699A]) = v39;\nL_0028:\n\tv43 = 0;\n\tgoto L_0032;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v40, v20, v21, v22, v23, v24, v25, v26, v41, v28, v29, v30, v31, v32, v33, v34);\n\tv53 = Lean.Pool.LeanGameObjectPool;\nL_0032:\n\tv56 = v54.Instances == 0;\n\tif (v56) goto L_0064;\n\tv72 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>::GetEnumerator(v54.Instances);\nL_0043:\n\tv128 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::MoveNext(&v43 @ stack_-60_v1 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\n\tv133 = v128 == 0;\n\tif (v133) goto L_004E;\n\tLean.Pool.LeanGameObjectPool::DespawnAll(v148);\n\tgoto L_0043;\nL_004E:\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(&v43 @ stack_-60_v1 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\nL_004F:\n\tv180 = *([v106 @ X22_v2 (Il2CppClass<Lean.Pool.LeanPool>)]);\n\tgoto L_0056;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v170, v104, v21, v22, v23, v24, v25, v26, v41, v28, v29, v30, v31, v32, v33, v34);\n\tv181 = *([v106 @ X22_v2 (Il2CppClass<Lean.Pool.LeanPool>)]);\nL_0056:\n\tv114 = *([v180 @ X0_v23+B8]);\n\tv112 = *([v114 @ X8_v13]) == 0;\n\tif (v112) goto L_0064;\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>::Clear(*([v114 @ X8_v13]));\n\treturn;\n\tv108 = new System.NullReferenceException();\nL_0064:\n\tv119 = new System.NullReferenceException();\n\tgoto L_0071;\n\tgoto L_0071;\nL_0071:\n\tv144 = v102 != 1;\n\tif (v144) goto L_0081;\n\tv152 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::MoveNext(v119);\n\tv174 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::MoveNext(v152);\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(&v43 @ stack_-60_v1 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\n\tv158 = ~v152.m_value;\n\tif (v158) goto L_004F;\n\tthrow System.OutOfMemoryException;\nL_0081:\n\tgoto L_0087;\n\tX19 = X0;\nL_0087:\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(&v43 @ stack_-60_v1 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\n\tgoto L_008E;\n\tv187 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(v119);\nL_008E:\n\tv190 = new System.OutOfMemoryException();\n\tv197 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(v190);\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void DespawnAll()
		{
			//IL_01aa: Expected I, but got O
			//IL_0068: Expected I, but got O
			//IL_0075: Expected O, but got I
			//IL_0149: Expected O, but got I
			LinkedList<LeanGameObjectPool>.Enumerator enumerator = default(LinkedList<LeanGameObjectPool>.Enumerator);
			bool flag = LeanGameObjectPool.Instances == null;
			nint num = 0;
			nint num2 = (nint)typeof(LeanPool);
			if (!flag)
			{
				LinkedList<LeanGameObjectPool>.Enumerator enumerator2 = LeanGameObjectPool.Instances.GetEnumerator();
				LeanGameObjectPool leanGameObjectPool = default(LeanGameObjectPool);
				while (enumerator.MoveNext())
				{
					leanGameObjectPool.DespawnAll();
				}
				enumerator.Dispose();
				num2 = (nint)typeof(LeanPool);
				goto IL_006d;
			}
			goto IL_0084;
			IL_0084:
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				bool flag2 = ((LinkedList<LeanGameObjectPool>.Enumerator*)ex)->MoveNext();
				bool flag3 = (flag2 ? ((LinkedList<LeanGameObjectPool>.Enumerator*)1) : ((LinkedList<LeanGameObjectPool>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag2 ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
				goto IL_006d;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((LinkedList<LeanGameObjectPool>.Enumerator*)ex2)->Dispose();
			return;
			IL_006d:
			object obj = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v23+B8]");
			object obj2 = 0;
			bool flag4 = obj2 == null;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			IntPtr intPtr2 = default(IntPtr);
			num2 = intPtr2;
			if (!flag4)
			{
				((Dictionary<object, object>)obj2).Clear();
				return;
			}
			goto IL_0084;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x1362AC8", Offset = "0x1362AC8", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Lean.Pool.LeanPool;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = UnityEngine.Object;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3699B]) = v41;\nL_001C:\n\tgoto L_0021;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0044;\n\tv64 = UnityEngine.Component::get_gameObject(clone);\n\tgoto L_003C;\n\tv92 = v83;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v92, v63, v52, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\nL_003C:\n\tLean.Pool.LeanPool::Despawn(v64, delay);\n\treturn;\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Despawn(Component clone, float delay = 0f)
		{
			if (clone != null)
			{
				GameObject gameObject = clone.gameObject;
				Despawn(gameObject, delay);
			}
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x1362B90", Offset = "0x1362B90", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv63 = Lean.Pool.LeanGameObjectPool;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv79 = Lean.Pool.LeanPool;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv91 = UnityEngine.Object;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv135 = \"You're attempting to despawn a gameObject that wasn't spawned from this pool\";\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv140 = \"You're attempting to despawn a null gameObject\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3699C]) = v41;\nL_002E:\n\tgoto L_0035;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v25, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\nL_0035:\n\tv56 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv61 = v56 == 0;\n\tif (v61) goto L_0067;\n\tgoto L_004C;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v68, v54, v55, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv83 = Lean.Pool.LeanPool;\nL_004C:\n\tv99 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v84.Links, clone, &v96 @ stack_-28_v5 (System.Object));\n\tv138 = v99 == 0;\n\tif (v138) goto L_0074;\n\tgoto L_005F;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v141, v97, v95, v98, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tv183 = Lean.Pool.LeanPool;\nL_005F:\n\tv192 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Remove(v115.Links, clone);\n\tgoto L_0081;\nL_0067:\n\tgoto L_FFFFFFFF;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v72, v54, v55, v26, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\nL_006C:\n\tUnityEngine.Debug::LogWarning(v124, clone);\n\tgoto L_0088;\nL_0074:\n\tgoto L_0078;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v147, v97, v95, v98, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\nL_0078:\n\tv187 = Lean.Pool.LeanGameObjectPool::TryFindPoolByClone(clone, &v102 @ stack_-28_v6 (Lean.Pool.LeanGameObjectPool));\n\tv194 = v187 == 0;\n\tif (v194) goto L_008D;\nL_0081:\n\tLean.Pool.LeanGameObjectPool::Despawn(v96, clone, delay);\nL_0088:\n\treturn;\nL_008D:\n\tgoto L_FFFFFFFF;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v197, v123, v95, v98, v27, v28, v29, v30, delay, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006C;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Despawn(GameObject clone, float delay = 0f)
		{
			string message;
			if (clone != null)
			{
				object value;
				LeanGameObjectPool pool = default(LeanGameObjectPool);
				if (Links.TryGetValue(clone, out *(LeanGameObjectPool*)(&value)))
				{
					bool flag = Links.Remove(clone);
				}
				else if (!LeanGameObjectPool.TryFindPoolByClone(clone, ref pool))
				{
					message = "You're attempting to despawn a gameObject that wasn't spawned from this pool";
					goto IL_00fb;
				}
				((LeanGameObjectPool)value).Despawn(clone, delay);
				return;
			}
			message = "You're attempting to despawn a null gameObject";
			goto IL_00fb;
			IL_00fb:
			Debug.LogWarning(message, clone);
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x1362D68", Offset = "0x1362D68", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Lean.Pool.LeanPool;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3699D]) = v38;\nL_001A:\n\tgoto L_001F;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001F:\n\tv50 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv52 = v50 == 0;\n\tif (v52) goto L_003F;\n\tv60 = UnityEngine.Component::get_gameObject(clone);\n\tgoto L_0038;\n\tv84 = v75;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v84, v59, v49, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tLean.Pool.LeanPool::Detach(v60);\n\treturn;\nL_003F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Detach(Component clone)
		{
			if (clone != null)
			{
				GameObject gameObject = clone.gameObject;
				Detach(gameObject);
			}
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x1362E1C", Offset = "0x1362E1C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv60 = Lean.Pool.LeanGameObjectPool;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv76 = Lean.Pool.LeanPool;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv88 = UnityEngine.Object;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv132 = \"You're attempting to detach a gameObject that wasn't spawned from this pool\";\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv137 = \"You're attempting to detach a null gameObject\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v137, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3699E]) = v38;\nL_002C:\n\tgoto L_0033;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tv53 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv58 = v53 == 0;\n\tif (v58) goto L_0065;\n\tgoto L_004A;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v65, v51, v52, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv80 = Lean.Pool.LeanPool;\nL_004A:\n\tv96 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v81.Links, clone, &v93 @ stack_-28_v5 (System.Object));\n\tv135 = v96 == 0;\n\tif (v135) goto L_0072;\n\tgoto L_005D;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v138, v94, v92, v95, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv175 = Lean.Pool.LeanPool;\nL_005D:\n\tv184 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Remove(v112.Links, clone);\n\tgoto L_007E;\nL_0065:\n\tgoto L_FFFFFFFF;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v69, v51, v52, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_006A:\n\tUnityEngine.Debug::LogWarning(v121, clone);\n\tgoto L_0084;\nL_0072:\n\tgoto L_0076;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v144, v94, v92, v95, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0076:\n\tv179 = Lean.Pool.LeanGameObjectPool::TryFindPoolByClone(clone, &v99 @ stack_-28_v6 (Lean.Pool.LeanGameObjectPool));\n\tv186 = v179 == 0;\n\tif (v186) goto L_0089;\nL_007E:\n\tLean.Pool.LeanGameObjectPool::Detach(v93, clone);\nL_0084:\n\treturn;\nL_0089:\n\tgoto L_FFFFFFFF;\n\tv192 = \"il2cpp_codegen_runtime_class_init\"(v189, v120, v92, v95, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tgoto L_006A;\n\tthrow System.NullReferenceException;\n\treturn;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Detach(GameObject clone)
		{
			string message;
			if (clone != null)
			{
				object value;
				LeanGameObjectPool pool = default(LeanGameObjectPool);
				if (Links.TryGetValue(clone, out *(LeanGameObjectPool*)(&value)))
				{
					bool flag = Links.Remove(clone);
				}
				else if (!LeanGameObjectPool.TryFindPoolByClone(clone, ref pool))
				{
					message = "You're attempting to detach a gameObject that wasn't spawned from this pool";
					goto IL_00f7;
				}
				((LeanGameObjectPool)value).Detach(clone);
				return;
			}
			message = "You're attempting to detach a null gameObject";
			goto IL_00f7;
			IL_00f7:
			Debug.LogWarning(message, clone);
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x1362FEC", Offset = "0x1362FEC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Lean.Pool.LeanPool;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A3699F]) = v43;\nL_001E:\n\tv45 = new System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::.ctor(v45);\n\tv56.Links = v45;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LeanPool()
		{
			Dictionary<GameObject, LeanGameObjectPool> links = new Dictionary<GameObject, LeanGameObjectPool>();
			Links = links;
		}
	}
}
