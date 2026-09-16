using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000054")]
	public static class Utils
	{
		[Token(Token = "0x4000183")]
		private static Assembly[] _loadedAssemblies;

		[Token(Token = "0x4000184")]
		private static readonly string[] _defAssembliesToQuery;

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x107A058", Offset = "0x107A058", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EE6790]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, degrees, magnitude, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([20269DB]) = v43;\nL_001C:\n\tv50 = degrees * 0.017453292f;\n\tgoto L_0026;\n\tv53 = *([v46 @ X0_v2 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v46, v27, v28, v29, v30, v31, v32, v33, v48, magnitude, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv61 = 0x6D3020(UnityEngine.Mathf, v27, v28, v29, v30, v31, v32, v33, v50, magnitude, v34, v35, v36, v37, v38, v39);\n\tv64 = 0x6D2D20(v61, v27, v28, v29, v30, v31, v32, v33, v50, magnitude, v34, v35, v36, v37, v38, v39);\n\tv65 = v50 * magnitude;\n\tv66 = v50 * magnitude;\n\tv68 = 0;\n\tv73 = 0x1586898(&v68 @ stack_-40_v1 (UnityEngine.Vector3), 0, v28, v29, v30, v31, v32, v33, v65, v66, 0, v65, v36, v37, v38, v39);\n\treturn 0;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3 Vector3FromAngle(float degrees, float magnitude)
		{
			float num = degrees * ((float)Math.PI / 180f);
			Il2CppRuntime.Boundary("SYSTEM_API:cosf", "Method not found @6D3020 (native cosf)");
			Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
			float num2 = num * magnitude;
			float num3 = num * magnitude;
			Vector3 vector = default(Vector3);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			return default(Vector3);
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x107A120", Offset = "0x107A120", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv42 = *([1EA4C88]);\n\tv43 = *([v42 @ X8_v15]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, v45, v46, v47, v48, v49, v50, v51, from, v0, v2, to, v3, v5, v52, v53);\n\tv57 = 0 | 1;\n\t*([20269DC]) = v57;\nL_0029:\n\tgoto L_0030;\n\tv64 = *([v60 @ X0_v2+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0030;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v45, v46, v47, v48, v49, v50, v51, from, v0, v2, to, v3, v5, v52, v53);\nL_0030:\n\tv72 = UnityEngine.Vector2::get_right();\n\tgoto L_0049;\n\tv82 = *([v78 @ X0_v5+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0049;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v78, v45, v46, v47, v48, v49, v50, v51, v72, v73, v2, to, v3, v5, v52, v53);\nL_0049:\n\tv98 = UnityEngine.Vector3::op_Subtraction(to, from);\n\tv106 = UnityEngine.Vector2::op_Implicit(v98);\n\tv115 = UnityEngine.Vector2::Angle(v72, v106);\n\tv121 = UnityEngine.Vector2::op_Implicit(v72);\n\tv130 = UnityEngine.Vector3::Cross(v121, v98);\n\tv138 = v130.z < 0;\n\tv139 = v130.z == 0;\n\tv141 = v130.z ^ v130.z;\n\tv142 = v130.z & v141;\n\tv143 = v142 < 0;\n\tv154 = 360f - v115;\n\tv148 = v138 == v143;\n\tv149 = ~v139;\n\tv150 = v148 & v149;\n\tv151 = ~v150;\n\tif (v151) goto L_FFFFFFFF;\n\tgoto L_008A;\nL_008A:\n\treturnVal1 = -v154;\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static float Angle2D(Vector3 from, Vector3 to)
		{
			//IL_00ad: Expected O, but got F4
			//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Expected I4, but got Unknown
			Vector2 right = Vector2.right;
			Vector3 vector = to - from;
			Vector2 to2 = vector;
			float num = Vector2.Angle(right, to2);
			Vector3 lhs = right;
			Vector3 vector2 = Vector3.Cross(lhs, vector);
			bool flag = vector2.z < 0f;
			bool flag2 = vector2.z == 0f;
			object obj = vector2.z ^ vector2.z;
			int num2 = vector2.z & (long)(IntPtr)obj;
			bool flag3 = num2 < 0;
			float num3 = 360f - num;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (!(flag4 && flag5))
			{
				num3 = num;
			}
			return 0f - num3;
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x107A270", Offset = "0x107A270", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-10_v2;\n\t*([v28 @ X29_v1-4]) = *([v28 @ X29_v1+1C]);\n\t*([v28 @ X29_v1-8]) = *([v28 @ X29_v1+18]);\n\tgoto L_002F;\n\tv46 = *([1EB7410]);\n\tv47 = *([v46 @ X8_v14]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, v49, v50, v51, v52, v53, v54, v55, point, v36, v2, pivot, v3, v5, v56, v57);\n\tv61 = 0 | 1;\n\t*([20269DD]) = v61;\nL_002F:\n\tgoto L_003E;\n\tv68 = *([v64 @ X0_v2+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tgoto L_003E;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v64, v49, v50, v51, v52, v53, v54, v55, point, v36, v2, pivot, v3, v5, v56, v57);\nL_003E:\n\tv84 = UnityEngine.Vector3::op_Subtraction(point, pivot);\n\tgoto L_0058;\n\tv96 = *([v92 @ X0_v5+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0058;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, v49, v50, v51, v52, v53, v54, v55, v84, v85, v86, v78, v79, v80, v56, v57);\nL_0058:\n\t// 88 MakeStruct v111 @ AGG107A364_0_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v28 @ X29_v1+10], [v28 @ X29_v1+14], [v28 @ X29_v1-8], [v28 @ X29_v1-4]\n\tv113 = UnityEngine.Quaternion::op_Multiply(v111, v84);\n\treturnVal1 = UnityEngine.Vector3::op_Addition(v113, pivot);\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
		{
			//IL_0052: Expected F4, but got I
			//IL_0067: Expected F4, but got I
			//IL_007c: Expected F4, but got I
			//IL_0091: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+1C]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+18]");
			_ = 0;
			Vector3 vector = point - pivot;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+10]");
			Quaternion quaternion = default(Quaternion);
			quaternion.x = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1+14]");
			quaternion.y = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-8]");
			quaternion.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-4]");
			quaternion.w = 0f;
			Vector3 vector2 = quaternion * vector;
			return vector2 + pivot;
		}

		[Token(Token = "0x60002D9")]
		[Address(RVA = "0x107A394", Offset = "0x107A394", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv38 = *([1F04FE0]);\n\tv39 = *([v38 @ X8_v15]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, v41, v42, v43, v44, v45, v46, v47, a, v0, v2, b, v3, v5, v48, v49);\n\tv53 = 0 | 1;\n\t*([20269DE]) = v53;\nL_0027:\n\tgoto L_0030;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0030;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, v41, v42, v43, v44, v45, v46, v47, a, v0, v2, b, v3, v5, v48, v49);\nL_0030:\n\tv70 = UnityEngine.Mathf::Approximately(a, b);\n\tv72 = v70 == 0;\n\tif (v72) goto L_0069;\n\tgoto L_0041;\n\tv97 = *([v73 @ X0_v8+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0041;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v73, v41, v42, v43, v44, v45, v46, v47, v67, v68, v2, b, v3, v5, v48, v49);\nL_0041:\n\tv80 = UnityEngine.Mathf::Approximately(a.y, b.y);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0069;\n\tgoto L_005C;\n\tv137 = *([v133 @ X0_v12+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_005C;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v41, v42, v43, v44, v45, v46, v47, v78, v86, v2, b, v3, v5, v48, v49);\nL_005C:\n\treturnVal2 = UnityEngine.Mathf::Approximately(a.z, b.z);\n\treturn returnVal2;\nL_0069:\n\treturn 0;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Vector3AreApproximatelyEqual(Vector3 a, Vector3 b)
		{
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			if (Mathf.Approximately(vector.x, vector2.x) && Mathf.Approximately(a.y, b.y))
			{
				return Mathf.Approximately(a.z, b.z);
			}
			return false;
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0x106F624", Offset = "0x106F624", Length = "0x2AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv28 = *([1EF60B8]);\n\tv29 = *([v28 @ X8_v43]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20269DF]) = v48;\nL_0020:\n\tv57 = 0x1825000 + 0x4A8;\nL_0025:\n\tgoto L_002D;\n\tv117 = *([v113 @ X0_v3 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv118 = v117 == 0;\n\tv119 = ~v118;\n\tgoto L_002D;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v113, v64, v66, v62, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv121 = DG.Tweening.Core.Utils;\nL_002D:\n\tv237 = v124._defAssembliesToQuery;\n\tv76 = v58 >= v237.Length;\n\tif (v76) goto L_0077;\n\tgoto L_004B;\n\tv150 = *([v120 @ X0_v4 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv241 = v150 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_004B;\n\tv309 = DG.Tweening.Core.Utils;\n\tv310 = *([v309 @ X8_v37 (Il2CppClass<DG.Tweening.Core.Utils>)+B8]);\n\tv191 = v310._defAssembliesToQuery;\nL_004B:\n\tv244 = v58 < v237.Length;\n\tv100 = ~v244;\n\tif (v100) goto L_0105;\n\tv264 = System.String::Format(\"{0}, {1}\", typeName, v237[v58 @ X25_v2 (System.Int32)]);\n\tgoto L_006A;\n\tv330 = *([v112 @ X8_v36+E0]);\n\tv331 = v330 == 0;\n\tv332 = ~v331;\n\tif (v332) goto L_006A;\n\tv400 = v112;\n\tv334 = \"il2cpp_codegen_runtime_class_init\"(v400, v263, v67, v63, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_006A:\n\tv337 = 0x8D83FC(v264, v57, v237[v58 @ X25_v2 (System.Int32)], 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturnVal2 = System.Type::GetType(v337);\n\tv409 = returnVal2 == 0;\n\tv410 = ~v409;\n\tif (v410) goto L_0102;\n\treturnVal2 = System.Type::GetType(v264);\n\tv58 = v58 + 1;\n\tv110 = returnVal2 == 0;\n\tif (v110) goto L_0025;\n\tgoto L_0102;\nL_0077:\n\tgoto L_0080;\n\tv245 = *([v120 @ X0_v4 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_0080;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v120, v64, v66, v62, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv254 = DG.Tweening.Core.Utils;\n\tv249 = *([v254 @ X8_v33+B8]);\nL_0080:\n\tv256 = v248._loadedAssemblies == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_009A;\n\tv266 = System.AppDomain::get_CurrentDomain();\n\tv338 = System.AppDomain::GetAssemblies(v266);\n\tgoto L_0097;\n\tv411 = *([v402 @ X8_v28 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv412 = v411 == 0;\n\tv413 = ~v412;\n\tif (v413) goto L_0097;\n\tv427 = v402;\n\tv414 = \"il2cpp_codegen_runtime_class_init\"(v427, v268, v66, v62, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv416 = DG.Tweening.Core.Utils;\nL_0097:\n\tv276._loadedAssemblies = v338;\nL_009A:\n\tv195 = 0x1825000 + 0x4A8;\nL_009F:\n\tgoto L_00A7;\n\tv339 = *([v326 @ X0_v17 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv340 = v339 == 0;\n\tv341 = ~v340;\n\tgoto L_00A7;\n\tv406 = \"il2cpp_codegen_runtime_class_init\"(v326, v144, v146, v142, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv342 = DG.Tweening.Core.Utils;\nL_00A7:\n\tv238 = v345._loadedAssemblies;\n\tv154 = v138 >= v238.Length;\n\tif (v154) goto L_FFFFFFFF;\n\tgoto L_00C5;\n\tv151 = *([v185 @ X0_v18 (Il2CppClass<DG.Tweening.Core.Utils>)+E0]);\n\tv428 = v151 == 0;\n\tv429 = ~v428;\n\tif (v429) goto L_00C5;\n\tv432 = DG.Tweening.Core.Utils;\n\tv433 = *([v432 @ X8_v24 (Il2CppClass<DG.Tweening.Core.Utils>)+B8]);\n\tv192 = v433._loadedAssemblies;\nL_00C5:\n\tv431 = v138 < v238.Length;\n\tv227 = ~v431;\n\tif (v227) goto L_0105;\n\tv437 = System.Reflection.Assembly::GetName(v238[v138 @ X25_v9 (System.Int32)]);\n\tv441 = System.String::Format(\"{0}, {1}\", typeName, v437);\n\tgoto L_00EC;\n\tv445 = *([v325 @ X8_v23+E0]);\n\tv446 = v445 == 0;\n\tv447 = ~v446;\n\tif (v447) goto L_00EC;\n\tv453 = v325;\n\tv449 = \"il2cpp_codegen_runtime_class_init\"(v453, v439, v318, v316, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00EC:\n\tv452 = 0x8D83FC(v441, v195, v437, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturnVal2 = System.Type::GetType(v452);\n\tv454 = returnVal2 == 0;\n\tv425 = ~v454;\n\tif (v425) goto L_0102;\n\treturnVal2 = System.Type::GetType(v441);\n\tv138 = v138 + 1;\n\tv323 = returnVal2 == 0;\n\tif (v323) goto L_009F;\n\tgoto L_0102;\nL_0102:\n\treturn returnVal2;\n\tv197 = new System.NullReferenceException();\nL_0105:\n\tv240 = new System.IndexOutOfRangeException();\n\tthrow v240;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type GetLooseScriptType(string typeName)
		{
			int num = 25317376 + 1192;
			int num2 = 0;
			Type type;
			string typeName3 = default(string);
			string typeName5 = default(string);
			while (true)
			{
				string[] defAssembliesToQuery = _defAssembliesToQuery;
				if (num2 < defAssembliesToQuery.Length)
				{
					if (num2 < defAssembliesToQuery.Length)
					{
						string typeName2 = $"{typeName}, {defAssembliesToQuery[num2]}";
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D83FC");
						type = Type.GetType(typeName3);
						if ((object)type != null)
						{
							break;
						}
						type = Type.GetType(typeName2);
						num2++;
						if ((object)type != null)
						{
							break;
						}
						continue;
					}
				}
				else
				{
					if (_loadedAssemblies == null)
					{
						AppDomain currentDomain = AppDomain.CurrentDomain;
						Assembly[] assemblies = currentDomain.GetAssemblies();
						_loadedAssemblies = assemblies;
					}
					int num3 = 25317376 + 1192;
					int num4 = 0;
					while (true)
					{
						Assembly[] loadedAssemblies = _loadedAssemblies;
						if (num4 < loadedAssemblies.Length)
						{
							if (num4 >= loadedAssemblies.Length)
							{
								break;
							}
							AssemblyName name = loadedAssemblies[num4].GetName();
							string typeName4 = $"{typeName}, {name}";
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D83FC");
							type = Type.GetType(typeName5);
							if ((object)type != null)
							{
								goto end_IL_025e;
							}
							type = Type.GetType(typeName4);
							num4++;
							if ((object)type != null)
							{
								goto end_IL_025e;
							}
							continue;
						}
						type = null;
						goto end_IL_025e;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
				continue;
				end_IL_025e:
				break;
			}
			return type;
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0x107A4A0", Offset = "0x107A4A0", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1F028A8]);\n\tv17 = *([v16 @ X8_v25]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20269E0]) = v37;\nL_0016:\n\t// 22 NewArr v42 @ X0_v3 (System.String[]), typeof(System.String[]), 3\n\tv48 = \"DOTween.Modules\" == 0;\n\tif (v48) goto L_0024;\n\t// 33 IsInst v94 @ X0_v20, typeof(System.String), \"DOTween.Modules\"\nL_0024:\n\tv149 = v42.Length;\n\tv101 = v42.Length == 0;\n\tif (v101) goto L_0066;\n\tv42[0] = \"DOTween.Modules\";\n\tv106 = \"Assembly-CSharp\" == 0;\n\tif (v106) goto L_0034;\n\t// 48 IsInst v190 @ X0_v19, typeof(System.String), \"Assembly-CSharp\"\n\tv149 = v42.Length;\nL_0034:\n\tv200 = v149 < 1;\n\tv132 = ~v200;\n\tv129 = v149 - 1;\n\tv123 = v129 == 0;\n\tv201 = ~v132;\n\tv108 = v201 | v123;\n\tif (v108) goto L_0066;\n\tv42[1] = \"Assembly-CSharp\";\n\tv206 = \"Assembly-CSharp-firstpass\" == 0;\n\tif (v206) goto L_004D;\n\t// 73 IsInst v191 @ X0_v18, typeof(System.String), \"Assembly-CSharp-firstpass\"\n\tv149 = v42.Length;\nL_004D:\n\tv208 = v149 < 2;\n\tv133 = ~v208;\n\tv130 = v149 - 2;\n\tv124 = v130 == 0;\n\tv209 = ~v133;\n\tv109 = v209 | v124;\n\tif (v109) goto L_0066;\n\tv42[2] = \"Assembly-CSharp-firstpass\";\n\tv170._defAssembliesToQuery = v42;\n\treturn;\nL_0066:\n\tv150 = new System.IndexOutOfRangeException();\n\tgoto L_006B;\n\tv198 = new System.ArrayTypeMismatchException();\nL_006B:\n\tthrow v203;\n\tthrow System.NullReferenceException;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Utils()
		{
			//IL_0040: Expected O, but got I4
			//IL_0171: Expected O, but got I
			//IL_00ad: Expected O, but got I4
			//IL_01cf: Expected O, but got I
			//IL_0100: Expected O, but got I4
			string[] array = new string[3];
			if ("DOTween.Modules" != null)
			{
				object obj = "DOTween.Modules" as string;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = "DOTween.Modules";
				if ("Assembly-CSharp" != null)
				{
					object obj3 = "Assembly-CSharp" as string;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = "Assembly-CSharp";
					if ("Assembly-CSharp-firstpass" != null)
					{
						object obj5 = "Assembly-CSharp-firstpass" as string;
						obj2 = array.Length;
					}
					bool flag5 = (long)(IntPtr)obj2 < 2L;
					bool flag6 = !flag5;
					object obj6 = (long)(IntPtr)obj2 - 2L;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = "Assembly-CSharp-firstpass";
						_defAssembliesToQuery = array;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
