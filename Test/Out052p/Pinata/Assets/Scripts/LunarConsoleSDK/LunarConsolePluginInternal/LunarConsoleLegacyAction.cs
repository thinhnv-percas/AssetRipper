using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Serializable]
	[Token(Token = "0x200001C")]
	public class LunarConsoleLegacyAction
	{
		[Token(Token = "0x4000052")]
		private static readonly object[] kEmptyArgs;

		[SerializeField]
		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x10")]
		private string m_name;

		[SerializeField]
		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x18")]
		private GameObject m_target;

		[SerializeField]
		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x20")]
		private string m_componentTypeName;

		[SerializeField]
		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x28")]
		private string m_componentMethodName;

		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x30")]
		private Type m_componentType;

		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x38")]
		private MethodInfo m_componentMethod;

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x13E29F0", Offset = "0x13E29F0", Length = "0x260")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EDC170]);\n\tv21 = *([v20 @ X8_v53]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AE2]) = v40;\nL_0016:\n\tv43 = System.String::IsNullOrEmpty(this.m_name);\n\tv45 = v43 == 0;\n\tif (v45) goto L_0038;\n\tgoto L_002F;\n\tv59 = *([v48 @ X0_v45+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002F;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002F:\n\tLunarConsolePluginInternal.Log::w(\"Unable to register action: name is null or empty\");\n\treturn;\nL_0038:\n\tgoto L_0041;\n\tv74 = *([v55 @ X0_v4+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0041;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v55, v42, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0041:\n\tv84 = UnityEngine.Object::op_Equality(this.m_target, 0);\n\tv86 = v84 == 0;\n\tif (v86) goto L_006B;\n\t// 73 NewArr v166 @ X0_v37 (System.Object[]), typeof(System.Object[]), 1\n\tv174 = this.m_name == 0;\n\tif (v174) goto L_0057;\n\t// 83 IsInst v202 @ X0_v43, typeof(System.Object), this.m_name (System.String)\nL_0057:\n\tv209 = v166.Length == 0;\n\tif (v209) goto L_00CF;\n\tv166[0] = this.m_name;\n\tgoto L_FFFFFFFF;\n\tv269 = *([v248 @ X0_v39+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_FFFFFFFF;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v248, v203, v83, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00B6;\nL_006B:\n\tv169 = System.String::IsNullOrEmpty(this.m_componentMethodName);\n\tv145 = v169 == 0;\n\tif (v145) goto L_00BC;\n\t// 115 NewArr v181 @ X0_v24 (System.Object[]), typeof(System.Object[]), 2\n\tv252 = this.m_name == 0;\n\tif (v252) goto L_0081;\n\t// 125 IsInst v258 @ X0_v35, typeof(System.Object), this.m_name (System.String)\nL_0081:\n\tv235 = v181.Length == 0;\n\tif (v235) goto L_00CF;\n\tv181[0] = this.m_name;\n\tv292 = UnityEngine.Object::get_name(this.m_target);\n\tv293 = v292 == 0;\n\tif (v293) goto L_0093;\n\t// 143 IsInst v259 @ X0_v33, typeof(System.Object), v292 @ X0_v27 (System.String)\nL_0093:\n\tv296 = v181.Length < 1;\n\tv227 = ~v296;\n\tv225 = v181.Length - 1;\n\tv221 = v225 == 0;\n\tv297 = ~v227;\n\tv211 = v297 | v221;\n\tif (v211) goto L_00CF;\n\tv181[1] = v292;\n\tgoto L_FFFFFFFF;\n\tv304 = *([v300 @ X0_v29+E0]);\n\tv305 = v304 == 0;\n\tv306 = ~v305;\n\tif (v306) goto L_FFFFFFFF;\n\tv307 = \"il2cpp_codegen_runtime_class_init\"(v300, v229, v83, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00B6:\n\tLunarConsolePluginInternal.Log::w(*([v152 @ X8_v7 (System.String)]), v290);\n\treturn;\nL_00BC:\n\tv198 = new System.Action();\n\tSystem.Action::.ctor(v198, this, Il2CppMethodInfo);\n\tLunarConsolePlugin.LunarConsole::RegisterAction(this.m_name, v198);\n\treturn;\n\tv191 = new System.NullReferenceException();\nL_00CF:\n\tv242 = new System.IndexOutOfRangeException();\n\tgoto L_00D4;\n\tv268 = new System.ArrayTypeMismatchException();\nL_00D4:\n\tthrow v279;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Register()
		{
			//IL_01ef: Expected O, but got I4
			if (string.IsNullOrEmpty(m_name))
			{
				Log.w("Unable to register action: name is null or empty");
				return;
			}
			string format;
			object[] args;
			if (m_target == null)
			{
				object[] array = new object[1];
				if (m_name != null)
				{
					object obj = m_name as object;
				}
				if (array.Length != 0)
				{
					array[0] = m_name;
					format = "Unable to register action '{0}': target GameObject is missing";
					args = array;
					goto IL_02b6;
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(m_componentMethodName))
				{
					Action action = Invoke;
					LunarConsole.RegisterAction(m_name, action);
					return;
				}
				object[] array2 = new object[2];
				if (m_name != null)
				{
					object obj2 = m_name as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = m_name;
					string name = m_target.name;
					if (name != null)
					{
						object obj3 = name as object;
					}
					bool flag = array2.Length < 1;
					bool flag2 = !flag;
					object obj4 = array2.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array2[1] = name;
						format = "Unable to register action '{0}' for '{1}': function is missing";
						args = array2;
						goto IL_02b6;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_02b6:
			Log.w(format, args);
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x13E2C50", Offset = "0x13E2C50", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED9E98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AE3]) = v38;\nL_0016:\n\tv42 = new System.Action();\n\tSystem.Action::.ctor(v42, this, Il2CppMethodInfo);\n\tLunarConsolePlugin.LunarConsole::UnregisterAction(v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Unregister()
		{
			Action action = Invoke;
			LunarConsole.UnregisterAction(action);
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x13E2CC0", Offset = "0x13E2CC0", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EF44B8]);\n\tv23 = *([v22 @ X8_v82]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028AE4]) = v42;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(this.m_target, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_004E;\n\t// 45 NewArr v67 @ X0_v85 (System.Object[]), typeof(System.Object[]), 1\n\tv71 = v67 == 0;\n\tif (v71) goto L_0168;\n\tv82 = this.m_name == 0;\n\tif (v82) goto L_003B;\n\t// 55 IsInst v172 @ X0_v91, typeof(System.Object), this.m_name (System.String)\nL_003B:\n\tv179 = v67.Length == 0;\n\tif (v179) goto L_0161;\n\tv67[0] = this.m_name;\n\tgoto L_FFFFFFFF;\n\tv277 = *([v196 @ X0_v87+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_FFFFFFFF;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v196, v173, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_00E7;\nL_004E:\n\tv69 = this.m_componentTypeName == 0;\n\tif (v69) goto L_00BF;\n\tv73 = this.m_componentMethodName == 0;\n\tif (v73) goto L_00BF;\n\tgoto L_0063;\n\tv182 = *([v165 @ X0_v34+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0063;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v165, v58, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0063:\n\tv191 = System.Type::op_Equality(this.m_componentType, 0);\n\tv240 = v191 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0070;\n\tv291 = System.Reflection.MethodInfo::op_Equality(this.m_componentMethod, 0);\n\tv296 = v291 == 0;\n\tif (v296) goto L_0075;\nL_0070:\n\tv298 = LunarConsolePluginInternal.LunarConsoleLegacyAction::ResolveInvocation(this);\n\tv373 = v298 == 0;\n\tif (v373) goto L_0106;\nL_0075:\n\tv145 = this.m_target == 0;\n\tif (v145) goto L_0168;\n\tv461 = UnityEngine.GameObject::GetComponent(this.m_target, this.m_componentType);\n\tgoto L_0089;\n\tv466 = *([v462 @ X8_v33+E0]);\n\tv467 = v466 == 0;\n\tv468 = ~v467;\n\tif (v468) goto L_0089;\n\tv474 = v462;\n\tv470 = \"il2cpp_codegen_runtime_class_init\"(v474, v459, v460, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0089:\n\tv473 = UnityEngine.Object::op_Equality(v461, 0);\n\tv476 = v473 == 0;\n\tif (v476) goto L_00F0;\n\t// 145 NewArr v141 @ X0_v68 (System.Object[]), typeof(System.Object[]), 1\n\tv146 = v141 == 0;\n\tif (v146) goto L_0168;\n\tv490 = this.m_componentType == 0;\n\tif (v490) goto L_009F;\n\t// 155 IsInst v266 @ X0_v75, typeof(System.Object), this.m_componentType (System.Type)\nL_009F:\n\tv222 = v141.Length == 0;\n\tif (v222) goto L_0161;\n\tv141[0] = this.m_componentType;\n\tgoto L_00B9;\n\tv504 = *([v499 @ X0_v70+E0]);\n\tv505 = v504 == 0;\n\tv506 = ~v505;\n\tif (v506) goto L_00B9;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v499, v214, v132, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B9:\n\tLunarConsolePluginInternal.Log::w(\"Missing component {0}\", v141);\n\treturn;\nL_00BF:\n\t// 191 NewArr v80 @ X0_v27 (System.Object[]), typeof(System.Object[]), 1\n\tv147 = v80 == 0;\n\tif (v147) goto L_0168;\n\tv193 = this.m_name == 0;\n\tif (v193) goto L_00CD;\n\t// 201 IsInst v245 @ X0_v33, typeof(System.Object), this.m_name (System.String)\nL_00CD:\n\tv223 = v80.Length == 0;\n\tif (v223) goto L_0161;\n\tv80[0] = this.m_name;\n\tgoto L_FFFFFFFF;\n\tv374 = *([v301 @ X0_v29+E0]);\n\tv375 = v374 == 0;\n\tv376 = ~v375;\n\tif (v376) goto L_FFFFFFFF;\n\tv377 = \"il2cpp_codegen_runtime_class_init\"(v301, v215, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00E7:\n\tLunarConsolePluginInternal.Log::e(*([v333 @ X8_v5 (System.String)]), v335);\n\treturn;\nL_00F0:\n\tgoto L_00F6;\n\tv484 = *([v480 @ X0_v45+E0]);\n\tv485 = v484 == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_00F6;\n\tv488 = \"il2cpp_codegen_runtime_class_init\"(v480, v359, v132, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00F6:\n\tv363 = this.m_componentMethod == 0;\n\tif (v363) goto L_0108;\n\tv400 = System.Reflection.MethodBase::Invoke(this.m_componentMethod, v461, v403.kEmptyArgs);\nL_0106:\n\treturn;\nL_0108:\n\tv361 = new System.NullReferenceException();\n\tgoto L_0115;\nL_0115:\n\tgoto L_0174;\n\tv512 = 0x6D2BC0(v361, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv386 = *([v512 @ X0_v50 (Il2CppClass<UnityEngine.Object>)]);\n\tv515 = \"il2cpp_vm_class_is_assignable_from\"(System.Reflection.TargetInvocationException, *([v386 @ X20_v18]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv516 = v515 & 1;\n\tv444 = v516 == 0;\n\tif (v444) goto L_0129;\n\tv383 = 0x6D2490(v515, *([v386 @ X20_v18]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv384 = v386 == 0;\n\tif (v384) goto L_0168;\n\tgoto L_0136;\nL_0129:\n\tv440 = 0x13E837C(v515, *([v386 @ X20_v18]), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n\tX1 = *([X8]);\n\tX0 = *([1EDD000]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0169;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0136:\n\t// 310 NewArr v142 @ X0_v56 (System.Object[]), typeof(System.Object[]), 1\n\tv148 = v142 == 0;\n\tif (v148) goto L_0168;\n\tv519 = this.m_name == 0;\n\tif (v519) goto L_0144;\n\t// 320 IsInst v267 @ X0_v63, typeof(System.Object), this.m_name (System.String)\nL_0144:\n\tv224 = v142.Length == 0;\n\tif (v224) goto L_0161;\n\tv142[0] = this.m_name;\n\tgoto L_015F;\n\tv529 = *([v525 @ X0_v58+E0]);\n\tv530 = v529 == 0;\n\tv531 = ~v530;\n\tif (v531) goto L_015F;\n\tv533 = \"il2cpp_codegen_runtime_class_init\"(v525, v216, v132, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_015F:\n\tLunarConsolePluginInternal.Log::e(*([v386 @ X20_v18+28]), \"Exception while invoking action '{0}'\", v142);\n\treturn;\nL_0161:\n\tv233 = new System.IndexOutOfRangeException();\n\tgoto L_0166;\n\tv276 = new System.ArrayTypeMismatchException();\nL_0166:\n\tthrow v319;\nL_0168:\n\tthrow System.NullReferenceException;\nL_0169:\n\t;\n\tv287 = 0x6D2490(v238, v236, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0174:\n\tv370 = 0x6D2380(v361, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv387 = 0x846AA4(v370, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 219 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Invoke()
		{
			string format;
			object[] args;
			if (m_target == null)
			{
				object[] array = new object[1];
				if (array != null)
				{
					if (m_name != null)
					{
						object obj = m_name as object;
					}
					if (array.Length == 0)
					{
						goto IL_04ee;
					}
					array[0] = m_name;
					format = "Can't invoke action '{0}': target is not set";
					args = array;
					goto IL_0526;
				}
			}
			else if (m_componentTypeName != null && m_componentMethodName != null)
			{
				if ((m_componentType == null || m_componentMethod == null) && !ResolveInvocation())
				{
					return;
				}
				if ((object)m_target != null)
				{
					Component component = m_target.GetComponent(m_componentType);
					if (!(component == null))
					{
						if ((object)m_componentMethod != null)
						{
							object obj2 = m_componentMethod.Invoke(component, kEmptyArgs);
							return;
						}
						NullReferenceException ex = new NullReferenceException();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
						return;
					}
					object[] array2 = new object[1];
					if (array2 != null)
					{
						if ((object)m_componentType != null)
						{
							object obj3 = m_componentType as object;
						}
						if (array2.Length != 0)
						{
							array2[0] = m_componentType;
							Log.w("Missing component {0}", array2);
							return;
						}
						goto IL_04ee;
					}
				}
			}
			else
			{
				object[] array3 = new object[1];
				if (array3 != null)
				{
					if (m_name != null)
					{
						object obj4 = m_name as object;
					}
					if (array3.Length == 0)
					{
						goto IL_04ee;
					}
					array3[0] = m_name;
					format = "Can't invoke action '{0}': method is not set";
					args = array3;
					goto IL_0526;
				}
			}
			throw new NullReferenceException();
			IL_04ee:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
			throw ex3;
			IL_0526:
			Log.e(format, args);
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x13E30F8", Offset = "0x13E30F8", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECB138]);\n\tv21 = *([v20 @ X8_v56]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AE5]) = v40;\nL_001B:\n\tgoto L_0022;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0022;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0022:\n\tv56 = 0x1835000 + 0x844;\n\tv58 = 0x8D83FC(this.m_componentTypeName, v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = System.Type::GetType(v58);\n\tv60 = v64 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_002B;\n\tv64 = System.Type::GetType(this.m_componentTypeName);\nL_002B:\n\tthis.m_componentType = v64;\n\tv67 = System.Type::op_Equality(v64, 0);\n\tv69 = v67 == 0;\n\tif (v69) goto L_005F;\n\t// 54 NewArr v74 @ X0_v71 (System.Object[]), typeof(System.Object[]), 1\n\tv85 = this.m_componentTypeName == 0;\n\tif (v85) goto L_0044;\n\t// 64 IsInst v99 @ X0_v78, typeof(System.Object), this.m_componentTypeName (System.String)\n\tv103 = v99 == 0;\n\tif (v103) goto L_00B5;\nL_0044:\n\tv106 = v74.Length == 0;\n\tif (v106) goto L_00B1;\n\tv74[0] = this.m_componentTypeName;\n\tgoto L_0057;\n\tv139 = *([v118 @ X0_v73+E0]);\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0057;\n\tv143 = \"il2cpp_codegen_runtime_class_init\"(v118, v100, v66, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\tLunarConsolePluginInternal.Log::w(\"Can't resolve type {0}\", v74);\n\tgoto L_FFFFFFFF;\nL_005F:\n\tv82 = System.Type::GetMethod(this.m_componentType, this.m_componentMethodName, 0x34);\n\tthis.m_componentMethod = v82;\n\tv95 = System.Reflection.MethodInfo::op_Equality(v82, 0);\n\tv115 = v95 == 0;\n\tif (v115) goto L_FFFFFFFF;\n\t// 107 NewArr v129 @ X0_v59 (System.Object[]), typeof(System.Object[]), 2\n\tv206 = this.m_componentMethod == 0;\n\tif (v206) goto L_0078;\n\t// 117 IsInst v280 @ X0_v69, typeof(System.Object), this.m_componentMethod (System.Reflection.MethodInfo)\n\tv284 = v280 == 0;\n\tif (v284) goto L_00C3;\nL_0078:\n\tv347 = v129.Length;\n\tv287 = v129.Length == 0;\n\tif (v287) goto L_00BB;\n\tv129[0] = this.m_componentMethod;\n\tv298 = this.m_componentType == 0;\n\tif (v298) goto L_0086;\n\t// 130 IsInst v342 @ X0_v67, typeof(System.Object), this.m_componentType (System.Type)\n\tv346 = v342 == 0;\n\tif (v346) goto L_00C7;\n\tv347 = v129.Length;\nL_0086:\n\tv349 = v347 < 1;\n\tv263 = ~v349;\n\tv262 = v347 - 1;\n\tv260 = v262 == 0;\n\tv350 = ~v263;\n\tv255 = v350 | v260;\n\tif (v255) goto L_00BF;\n\tv129[1] = this.m_componentType;\n\tgoto L_00A3;\n\tv381 = *([v360 @ X0_v62+E0]);\n\tv382 = v381 == 0;\n\tv383 = ~v382;\n\tif (v383) goto L_00A3;\n\tv385 = \"il2cpp_codegen_runtime_class_init\"(v360, v343, v94, v81, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A3:\n\tLunarConsolePluginInternal.Log::w(\"Can't resolve method {0} of type {1}\", v129);\n\tgoto L_00AD;\nL_00AD:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\tv92 = new System.NullReferenceException();\nL_00B1:\n\tv113 = new System.IndexOutOfRangeException();\n\tthrow v113;\nL_00B5:\n\tv138 = new System.ArrayTypeMismatchException();\n\tthrow v138;\n\tv216 = new System.NullReferenceException();\nL_00BB:\n\tv297 = new System.IndexOutOfRangeException();\n\tthrow v297;\nL_00BF:\n\tv354 = new System.IndexOutOfRangeException();\n\tthrow v354;\nL_00C3:\n\tv338 = new System.ArrayTypeMismatchException();\n\tthrow v338;\nL_00C7:\n\tv380 = new System.ArrayTypeMismatchException();\n\tthrow v380;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tif (1) goto L_0105;\n\tv393 = 0x6D2BC0(v389, 0, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv273 = *([v393 @ X0_v18]);\n\tv266 = *([v273 @ X19_v7 (System.Exception)]);\n\tv406 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, v266, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv407 = v406 & 1;\n\tv398 = v407 == 0;\n\tif (v398) goto L_00FB;\n\tv408 = 0x6D2490(v406, v266, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00F8;\n\tv419 = *([v413 @ X0_v26+E0]);\n\tv420 = v419 == 0;\n\tv421 = ~v420;\n\tif (v421) goto L_00F8;\n\tv423 = \"il2cpp_codegen_runtime_class_init\"(v413, v266, v264, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00F8:\n\tLunarConsolePluginInternal.Log::e(v273, v266);\n\tgoto L_FFFFFFFF;\nL_00FB:\n\tv410 = 0x6D1E60(8, v266, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv400 = *([v393 @ X0_v18]);\n\t*([v410 @ X0_v22]) = v400;\n\tv395 = 0x1E8A000 + 0x870;\n\tv418 = 0x6D2A00(v410, v395, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv397 = 0x6D2490(v418, v395, 0, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0105:\n\tv402 = 0x6D2380(v249, v243, v241, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = 0x846AA4(v402, v243, v241, v239, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool ResolveInvocation()
		{
			//IL_0206: Expected O, but got I4
			//IL_035d: Expected O, but got I
			//IL_028e: Expected O, but got I4
			int num = 25382912 + 2116;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D83FC");
			string typeName = default(string);
			Type type = Type.GetType(typeName);
			if ((object)type == null)
			{
				type = Type.GetType(m_componentTypeName);
			}
			m_componentType = type;
			if (type == null)
			{
				object[] array = new object[1];
				if (m_componentTypeName != null)
				{
					object obj = m_componentTypeName as object;
					if (obj == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						throw ex;
					}
				}
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
					throw ex2;
				}
				array[0] = m_componentTypeName;
				Log.w("Can't resolve type {0}", array);
			}
			else
			{
				if (!((m_componentMethod = m_componentType.GetMethod(m_componentMethodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)) == null))
				{
					return true;
				}
				object[] array2 = new object[2];
				if ((object)m_componentMethod != null)
				{
					object obj2 = m_componentMethod as object;
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
						throw ex3;
					}
				}
				object obj3 = array2.Length;
				if (array2.Length == 0)
				{
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				array2[0] = m_componentMethod;
				if ((object)m_componentType != null)
				{
					object obj4 = m_componentType as object;
					if (obj4 == null)
					{
						ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
						throw ex5;
					}
					obj3 = array2.Length;
				}
				bool flag = (long)(IntPtr)obj3 < 1L;
				bool flag2 = !flag;
				object obj5 = (long)(IntPtr)obj3 - 1L;
				bool flag3 = obj5 == null;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
					throw ex6;
				}
				array2[1] = m_componentType;
				Log.w("Can't resolve method {0} of type {1}", array2);
			}
			return false;
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x13E3418", Offset = "0x13E3418", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0F5D8]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AE6]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(this.m_name);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0030;\n\tgoto L_0028;\n\tv63 = *([v46 @ X0_v23+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0028;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v46, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tLunarConsolePluginInternal.Log::w(\"Missing action name\");\nL_0030:\n\tgoto L_0039;\n\tv70 = *([v59 @ X0_v5+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0039;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v59, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0039:\n\tv80 = UnityEngine.Object::op_Equality(this.m_target, 0);\n\tv82 = v80 == 0;\n\tif (v82) goto L_0054;\n\tgoto L_004C;\n\tv102 = *([v85 @ X0_v18+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_004C;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v85, v78, v79, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004C:\n\tLunarConsolePluginInternal.Log::w(\"Missing action target\");\nL_0054:\n\tgoto L_005D;\n\tv109 = *([v98 @ X0_v10+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_005D;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v98, v78, v79, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005D:\n\tv119 = System.Type::op_Inequality(this.m_componentType, 0);\n\tv121 = v119 == 0;\n\tif (v121) goto L_0071;\n\tv123 = this.m_componentMethodName == 0;\n\tif (v123) goto L_0071;\n\tv135 = LunarConsolePluginInternal.LunarConsoleLegacyAction::ResolveInvocation(this);\n\treturn;\nL_0071:\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Validate()
		{
			if (string.IsNullOrEmpty(m_name))
			{
				Log.w("Missing action name");
			}
			if (m_target == null)
			{
				Log.w("Missing action target");
			}
			if (m_componentType != null && m_componentMethodName != null)
			{
				bool flag = ResolveInvocation();
			}
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x13E3550", Offset = "0x13E3550", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsoleLegacyAction()
		{
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x13E3558", Offset = "0x13E3558", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EAB740]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AE7]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\tv44.kEmptyArgs = v40;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LunarConsoleLegacyAction()
		{
			object[] array = new object[0];
			kEmptyArgs = array;
		}
	}
}
