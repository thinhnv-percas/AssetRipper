using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200002C")]
	internal static class ReflectionUtils
	{
		[CompilerGenerated]
		[Token(Token = "0x2000039")]
		private sealed class _003C_003Ec__DisplayClass12_0
		{
			[Token(Token = "0x40000A9")]
			[FieldOffset(Offset = "0x10")]
			public Type attributeType;

			[Token(Token = "0x600019B")]
			[Address(RVA = "0x13E5224", Offset = "0x13E5224", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass12_0()
			{
			}

			internal bool _003CFindAttributeTypes_003Eb__0(Type type)
			{
				//IL_002f: Expected I4, but got O
				object[] customAttributes = type.GetCustomAttributes(attributeType, inherit: false);
				bool flag = customAttributes == null;
				bool result = (byte)(int)customAttributes != 0;
				if (!flag)
				{
					bool flag2 = customAttributes.Length == 0;
					bool flag3 = !flag2;
					result = flag3;
				}
				return result;
			}
		}

		[Token(Token = "0x400007E")]
		private static readonly object[] EMPTY_INVOKE_ARGS;

		[Token(Token = "0x6000123")]
		[Address(RVA = "0x13DDC84", Offset = "0x13DDC84", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC37C0]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, invokeArgs, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AEF]) = v41;\nL_0015:\n\tv42 = del == 0;\n\tif (v42) goto L_0037;\n\tv46 = System.Delegate::get_Method(del);\n\tgoto L_0032;\n\tv63 = *([v54 @ X8_v11+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv85 = v54;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v85, v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0032:\n\treturnVal1 = LunarConsolePluginInternal.ReflectionUtils::Invoke(del.m_target, v46, invokeArgs);\n\treturn returnVal1;\nL_0037:\n\tv50 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v50, \"del\");\n\tthrow v50;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Invoke(Delegate del, string[] invokeArgs)
		{
			if (del != null)
			{
				MethodInfo method = del.Method;
				return Invoke(del.Target, method, invokeArgs);
			}
			ArgumentNullException ex = new ArgumentNullException("del");
			throw ex;
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0x13E3EA4", Offset = "0x13E3EA4", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1EBACA8]);\n\tv37 = *([v36 @ X8_v35]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, method, invokeArgs, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2028AF0]) = v54;\nL_0022:\n\tv60 = System.Reflection.MethodBase::GetParameters(method);\n\tv136 = v60.Length == 0;\n\tif (v136) goto L_0086;\n\tv201 = new System.Collections.Generic.List`1<System.Object>();\n\tSystem.Collections.Generic.List`1<System.Object>::.ctor(v201, invokeArgs.Length);\n\tv123 = new LunarConsolePluginInternal.Iterator`1<System.String>();\n\tLunarConsolePluginInternal.Iterator`1<System.String>::.ctor(v123, invokeArgs);\n\tv195 = v60.Length;\n\tv75 = v60.Length < 1;\n\tif (v75) goto L_0096;\nL_0051:\n\tv339 = v67 < v195;\n\tv106 = ~v339;\n\tif (v106) goto L_00B8;\n\tgoto L_006A;\n\tv355 = *([v348 @ X0_v28+E0]);\n\tv356 = v355 == 0;\n\tv357 = ~v356;\n\tif (v357) goto L_006A;\n\tv359 = \"il2cpp_codegen_runtime_class_init\"(v348, v185, v111, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_006A:\n\tv122 = LunarConsolePluginInternal.ReflectionUtils::ResolveInvokeParameter(v60[v67 @ X25_v8 (System.Int32)], v123);\n\tSystem.Collections.Generic.List`1<System.Object>::Add(v201, v122);\n\tv195 = v60.Length;\n\tv67 = v67 + 1;\n\tv319 = v67 < v60.Length;\n\tif (v319) goto L_0051;\n\tgoto L_0096;\nL_0086:\n\tgoto L_008E;\n\tv202 = *([v163 @ X0_v14 (Il2CppClass<LunarConsolePluginInternal.ReflectionUtils>)+E0]);\n\tv203 = v202 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_008E;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v163, v59, invokeArgs, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv206 = LunarConsolePluginInternal.ReflectionUtils;\nL_008E:\n\tv264 = v209.EMPTY_INVOKE_ARGS;\n\tgoto L_00B4;\nL_0096:\n\tv256 = System.Collections.Generic.List`1<System.Object>::ToArray(v201);\n\tgoto L_00B4;\n\tv252 = *([v263 @ X8_v27+E0]);\n\tv363 = v252 == 0;\n\tv258 = ~v363;\n\tif (v258) goto L_00B4;\n\tv364 = v263;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v364, v250, v247, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00B4:\n\treturnVal2 = LunarConsolePluginInternal.ReflectionUtils::Invoke(target, method, v264);\n\treturn returnVal2;\n\tv160 = new System.NullReferenceException();\nL_00B8:\n\tv197 = new System.IndexOutOfRangeException();\n\tthrow v197;\n\treturn returnVal1;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Invoke(object target, MethodInfo method, string[] invokeArgs)
		{
			ParameterInfo[] parameters = method.GetParameters();
			object[] args;
			if (parameters.Length != 0)
			{
				List<object> list = new List<object>(invokeArgs.Length);
				Iterator<string> iter = new Iterator<string>(invokeArgs);
				int num = parameters.Length;
				if (parameters.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							object item = ResolveInvokeParameter(parameters[num2], iter);
							list.Add(item);
							num = parameters.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < parameters.Length);
				}
				object[] array = list.ToArray();
				args = array;
			}
			else
			{
				args = EMPTY_INVOKE_ARGS;
			}
			return Invoke(target, method, args);
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x13E4098", Offset = "0x13E4098", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EAF6C8]);\n\tv29 = *([v28 @ X8_v16]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, method, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2028AF1]) = v46;\nL_001E:\n\tv52 = System.Reflection.MethodInfo::get_ReturnType(method);\n\tgoto L_0032;\n\tv64 = *([v57 @ X8_v8+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0032;\n\tv93 = v57;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v93, v51, args, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0032:\n\tv73 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv97 = System.Type::op_Equality(v52, v73);\n\tv86 = System.Reflection.MethodBase::Invoke(method, target, args);\n\tv141 = v97 == 0;\n\tif (v141) goto L_FFFFFFFF;\n\tv100 = ~v100_asT;\n\tif (v100) goto L_006D;\n\tv203 = \"il2cpp_vm_object_unbox\"(v86, System.Boolean, args, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv197 = *([v203 @ X0_v18]) == 0;\n\tv192 = ~v197;\n\tgoto L_006A;\nL_006A:\n\treturn returnVal2;\n\tv92 = new System.NullReferenceException();\nL_006D:\n\treturnVal1 = new System.InvalidCastException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool Invoke(object target, MethodInfo method, object[] args)
		{
			//IL_007a: Expected I4, but got O
			//IL_00e0: Expected I4, but got O
			Type returnType = method.ReturnType;
			Type typeFromHandle = typeof(bool);
			bool flag = returnType == typeFromHandle;
			object obj = method.Invoke(target, args);
			if (flag)
			{
				if ((int)((obj is bool) ? obj : null) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj2 = default(object);
					bool flag2 = obj2 == null;
					return !flag2;
				}
				InvalidCastException ex = new InvalidCastException();
				return (byte)(int)ex != 0;
			}
			return true;
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0x13E41BC", Offset = "0x13E41BC", Length = "0x968")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1F04CA8]);\n\tv33 = *([v32 @ X8_v154]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, iter, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([2028AF2]) = v51;\nL_001E:\n\tv55 = System.Reflection.ParameterInfo::get_IsOptional(param);\n\tv170 = v55 == 0;\n\tif (v170) goto L_0031;\n\tv199 = LunarConsolePluginInternal.Iterator`1<System.String>::HasNext(iter, 1);\n\tv201 = v199 == 0;\n\tif (v201) goto L_00AD;\nL_0031:\n\tv208 = System.Reflection.ParameterInfo::get_ParameterType(param);\n\tgoto L_0045;\n\tv223 = *([v211 @ X8_v14+E0]);\n\tv224 = v223 == 0;\n\tv225 = ~v224;\n\tif (v225) goto L_0045;\n\tv235 = v211;\n\tv227 = \"il2cpp_codegen_runtime_class_init\"(v235, v207, v194, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0045:\n\tv231 = System.Type::GetTypeFromHandle(System.String[]);\n\tv238 = System.Type::op_Equality(v208, v231);\n\tv260 = v238 == 0;\n\tif (v260) goto L_008E;\n\tv114 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v114);\n\tv344 = LunarConsolePluginInternal.Iterator`1<System.String>::HasNext(iter, 1);\n\tv348 = v344 == 0;\n\tif (v348) goto L_0085;\nL_0069:\n\tgoto L_0070;\n\tv405 = *([v392 @ X0_v200+E0]);\n\tv406 = v405 == 0;\n\tv407 = ~v406;\n\tgoto L_0070;\n\tv409 = \"il2cpp_codegen_runtime_class_init\"(v392, v388, v89, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0070:\n\tv115 = LunarConsolePluginInternal.ReflectionUtils::NextArg(iter);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v114, v115);\n\tv366 = LunarConsolePluginInternal.Iterator`1<System.String>::HasNext(iter, 1);\n\tv494 = v366 == 0;\n\tv368 = ~v494;\n\tif (v368) goto L_0069;\nL_0085:\n\tv400 = System.Collections.Generic.List`1<System.String>::ToArray(v114);\n\tgoto L_01F6;\nL_008E:\n\tgoto L_0096;\n\tv326 = *([v319 @ X0_v23+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0096;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v319, v236, v88, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0096:\n\tv335 = System.Type::GetTypeFromHandle(System.String);\n\tv339 = System.Type::op_Equality(v208, v335);\n\tv346 = v339 == 0;\n\tif (v346) goto L_00C4;\n\tgoto L_00AB;\n\tv369 = *([v351 @ X0_v186+E0]);\n\tv370 = v369 == 0;\n\tv371 = ~v370;\n\tif (v371) goto L_00AB;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v351, v336, v338, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00AB:\n\tv377 = LunarConsolePluginInternal.ReflectionUtils::NextArg(iter);\n\tgoto L_01F6;\nL_00AD:\n\tv245 = param->klass;\n\tv251 = param->klass->vtable[11];\n\tv252 = param->klass->vtable[11];\n\t// 188 IndirectJump v251 @ X2_v41, param @ X0 (System.Reflection.ParameterInfo), param @ X0 (System.Reflection.ParameterInfo), v252 @ X1_v70, v251 @ X2_v41, v36 @ X3, v37 @ X4, v38 @ X5, v39 @ X6, v40 @ X7, v41 @ V0 (System.Single), v417 @ V1_v2 (System.Single), v498 @ V2_v3 (System.Single), v495 @ V3_v3 (System.Single), v45 @ V4, v46 @ V5, v47 @ V6, v48 @ V7\nL_00C4:\n\tgoto L_00CC;\n\tv378 = *([v356 @ X0_v29+E0]);\n\tv379 = v378 == 0;\n\tv380 = ~v379;\n\tif (v380) goto L_00CC;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v356, v336, v338, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00CC:\n\tv387 = System.Type::GetTypeFromHandle(System.Single);\n\tv404 = System.Type::op_Equality(v208, v387);\n\tv448 = v404 == 0;\n\tif (v448) goto L_00EF;\n\tgoto L_00E1;\n\tv464 = *([v451 @ X0_v180+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_00E1;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v451, v401, v403, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00E1:\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tgoto L_01EA;\nL_00EF:\n\tgoto L_00F7;\n\tv473 = *([v456 @ X0_v37+E0]);\n\tv474 = v473 == 0;\n\tv475 = ~v474;\n\tif (v475) goto L_00F7;\n\tv477 = \"il2cpp_codegen_runtime_class_init\"(v456, v401, v403, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00F7:\n\tv482 = System.Type::GetTypeFromHandle(System.Int32);\n\tv492 = System.Type::op_Equality(v208, v482);\n\tv524 = v492 == 0;\n\tif (v524) goto L_0118;\n\tgoto L_010C;\n\tv538 = *([v527 @ X0_v174+E0]);\n\tv539 = v538 == 0;\n\tv540 = ~v539;\n\tif (v540) goto L_010C;\n\tv542 = \"il2cpp_codegen_runtime_class_init\"(v527, v489, v491, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_010C:\n\tv546 = LunarConsolePluginInternal.ReflectionUtils::NextIntArg(iter);\n\tgoto L_FFFFFFFF;\nL_0118:\n\tgoto L_0120;\n\tv547 = *([v532 @ X0_v45+E0]);\n\tv548 = v547 == 0;\n\tv549 = ~v548;\n\tif (v549) goto L_0120;\n\tv551 = \"il2cpp_codegen_runtime_class_init\"(v532, v489, v491, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0120:\n\tv556 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv563 = System.Type::op_Equality(v208, v556);\n\tv573 = v563 == 0;\n\tif (v573) goto L_0145;\n\tgoto L_0135;\n\tv587 = *([v576 @ X0_v168+E0]);\n\tv588 = v587 == 0;\n\tv589 = ~v588;\n\tif (v589) goto L_0135;\n\tv591 = \"il2cpp_codegen_runtime_class_init\"(v576, v560, v562, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0135:\n\tv568 = LunarConsolePluginInternal.ReflectionUtils::NextBoolArg(iter);\n\tgoto L_01EA;\nL_0145:\n\tgoto L_014D;\n\tv594 = *([v581 @ X0_v51+E0]);\n\tv595 = v594 == 0;\n\tv596 = ~v595;\n\tif (v596) goto L_014D;\n\tv598 = \"il2cpp_codegen_runtime_class_init\"(v581, v560, v562, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_014D:\n\tv603 = System.Type::GetTypeFromHandle(UnityEngine.Vector2);\n\tv608 = System.Type::op_Equality(v208, v603);\n\tv610 = v608 == 0;\n\tif (v610) goto L_0179;\n\tgoto L_0162;\n\tv624 = *([v613 @ X0_v159+E0]);\n\tv625 = v624 == 0;\n\tv626 = ~v625;\n\tif (v626) goto L_0162;\n\tv628 = \"il2cpp_codegen_runtime_class_init\"(v613, v605, v607, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0162:\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv652 = 0;\n\tv655 = 0x1588A6C(&v652 @ stack_-60_v7 (System.Single), 0, 0, v36, v37, v38, v39, v40, v41, v41, v498, v495, v45, v46, v47, v48);\n\tgoto L_FFFFFFFF;\nL_0179:\n\tgoto L_0181;\n\tv633 = *([v618 @ X0_v58+E0]);\n\tv634 = v633 == 0;\n\tv635 = ~v634;\n\tif (v635) goto L_0181;\n\tv637 = \"il2cpp_codegen_runtime_class_init\"(v618, v605, v607, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0181:\n\tv642 = System.Type::GetTypeFromHandle(UnityEngine.Vector3);\n\tv649 = System.Type::op_Equality(v208, v642);\n\tv657 = v649 == 0;\n\tif (v657) goto L_01B4;\n\tgoto L_0196;\n\tv707 = *([v665 @ X0_v149+E0]);\n\tv708 = v707 == 0;\n\tv709 = ~v708;\n\tif (v709) goto L_0196;\n\tv711 = \"il2cpp_codegen_runtime_class_init\"(v665, v646, v648, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0196:\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv687 = 0;\n\tv735 = 0x1586898(&v687 @ stack_-60_v6 (System.Single), 0, 0, v36, v37, v38, v39, v40, v41, v41, v41, v495, v45, v46, v47, v48);\n\tgoto L_FFFFFFFF;\nL_01B4:\n\tgoto L_01BC;\n\tv715 = *([v670 @ X0_v64+E0]);\n\tv716 = v715 == 0;\n\tv717 = ~v716;\n\tif (v717) goto L_01BC;\n\tv719 = \"il2cpp_codegen_runtime_class_init\"(v670, v646, v648, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_01BC:\n\tv724 = System.Type::GetTypeFromHandle(UnityEngine.Vector4);\n\tv729 = System.Type::op_Equality(v208, v724);\n\tv733 = v729 == 0;\n\tif (v733) goto L_01FE;\n\tgoto L_01D1;\n\tv748 = *([v738 @ X0_v138+E0]);\n\tv749 = v748 == 0;\n\tv750 = ~v749;\n\tif (v750) goto L_01D1;\n\tv752 = \"il2cpp_codegen_runtime_class_init\"(v738, v727, v697, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_01D1:\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv41 = LunarConsolePluginInternal.ReflectionUtils::NextFloatArg(iter);\n\tv686 = 0;\n\tv787 = 0x158BA74(&v686 @ stack_-60_v5 (System.Single), 0, 0, v36, v37, v38, v39, v40, v41, v41, v41, v41, v45, v46, v\n// ... truncated")]
		private static object ResolveInvokeParameter(ParameterInfo param, Iterator<string> iter)
		{
			//IL_01db: Expected I, but got O
			//IL_01eb: Expected O, but got I
			//IL_01fb: Expected O, but got I
			//IL_0266: Expected O, but got I4
			//IL_026e: Expected O, but got F4
			//IL_027c: Expected I, but got O
			//IL_02ea: Expected O, but got I4
			//IL_0915: Expected O, but got I4
			//IL_091d: Expected I, but got O
			//IL_0366: Expected O, but got I4
			//IL_0410: Expected O, but got I4
			//IL_041e: Expected I, but got O
			//IL_092a: Expected O, but got F4
			//IL_04d4: Expected O, but got I4
			//IL_04e2: Expected I, but got O
			//IL_05ae: Expected O, but got I4
			//IL_05bc: Expected I, but got O
			Type parameterType = default(Type);
			if (!param.IsOptional || iter.HasNext())
			{
				parameterType = param.ParameterType;
				Type typeFromHandle = typeof(string[]);
				if (parameterType == typeFromHandle)
				{
					List<string> list = new List<string>();
					if (iter.HasNext())
					{
						do
						{
							string item = NextArg(iter);
							list.Add(item);
						}
						while (iter.HasNext());
					}
					return list.ToArray();
				}
				Type typeFromHandle2 = typeof(string);
				if (parameterType == typeFromHandle2)
				{
					return NextArg(iter);
				}
			}
			else
			{
				IntPtr intPtr = (IntPtr)param;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v151 (Il2CppClass<System.Reflection.ParameterInfo>)+1E0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v151 (Il2CppClass<System.Reflection.ParameterInfo>)+1E8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v251 @ X2_v41 (should have been resolved before IL gen)");
			}
			Type typeFromHandle3 = typeof(float);
			if (parameterType == typeFromHandle3)
			{
				float num = NextFloatArg(iter);
				object obj3 = 0;
				object obj4 = num;
				IntPtr intPtr2 = (IntPtr)typeof(float);
			}
			else
			{
				Type typeFromHandle4 = typeof(int);
				int num3;
				object typeFromHandle5;
				object obj4;
				IntPtr intPtr2;
				if (parameterType == typeFromHandle4)
				{
					int num2 = NextIntArg(iter);
					num3 = num2;
					object obj3 = 0;
					typeFromHandle5 = typeof(int);
				}
				else
				{
					Type typeFromHandle6 = typeof(bool);
					object obj3;
					if (!(parameterType == typeFromHandle6))
					{
						Type typeFromHandle7 = typeof(Vector2);
						float num5;
						if (parameterType == typeFromHandle7)
						{
							float num = NextFloatArg(iter);
							num = NextFloatArg(iter);
							float num4 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
							num5 = 0f;
							float num6 = num;
							obj3 = 0;
							intPtr2 = (IntPtr)typeof(Vector2);
						}
						else
						{
							Type typeFromHandle8 = typeof(Vector3);
							if (parameterType == typeFromHandle8)
							{
								float num = NextFloatArg(iter);
								num = NextFloatArg(iter);
								num = NextFloatArg(iter);
								float num7 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
								float num8 = num;
								num5 = 0f;
								float num6 = num;
								obj3 = 0;
								intPtr2 = (IntPtr)typeof(Vector3);
							}
							else
							{
								Type typeFromHandle9 = typeof(Vector4);
								float num;
								if (!(parameterType == typeFromHandle9))
								{
									Type typeFromHandle10 = typeof(int[]);
									if (parameterType == typeFromHandle10)
									{
										List<int> list2 = new List<int>();
										if (iter.HasNext())
										{
											do
											{
												int item2 = NextIntArg(iter);
												list2.Add(item2);
											}
											while (iter.HasNext());
										}
										return list2.ToArray();
									}
									Type typeFromHandle11 = typeof(float[]);
									if (parameterType == typeFromHandle11)
									{
										List<float> list3 = new List<float>();
										if (iter.HasNext())
										{
											do
											{
												num = NextFloatArg(iter);
												list3.Add(num);
											}
											while (iter.HasNext());
										}
										return list3.ToArray();
									}
									Type typeFromHandle12 = typeof(bool[]);
									if (parameterType == typeFromHandle12)
									{
										List<bool> list4 = new List<bool>();
										if (iter.HasNext())
										{
											do
											{
												bool item3 = NextBoolArg(iter);
												list4.Add(item3);
											}
											while (iter.HasNext());
										}
										return list4.ToArray();
									}
									Type type = default(Type);
									string message = "Unsupported value type: " + type;
									ReflectionException ex = new ReflectionException(message);
									throw ex;
								}
								num = NextFloatArg(iter);
								num = NextFloatArg(iter);
								num = NextFloatArg(iter);
								num = NextFloatArg(iter);
								float num9 = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
								float num8 = num;
								num5 = 0f;
								float num6 = num;
								num = 0f;
								obj3 = 0;
								intPtr2 = (IntPtr)typeof(Vector4);
							}
						}
						obj4 = num5;
						goto IL_08fe;
					}
					bool flag = NextBoolArg(iter);
					num3 = (flag ? 1 : 0);
					obj3 = 0;
					typeFromHandle5 = typeof(bool);
				}
				obj4 = num3;
				intPtr2 = (IntPtr)typeFromHandle5;
			}
			goto IL_08fe;
			IL_08fe:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object result = default(object);
			return result;
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x13E4D24", Offset = "0x13E4D24", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA64F0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AF3]) = v38;\nL_001A:\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = LunarConsolePluginInternal.ReflectionUtils::NextArg(iter);\n\tv59 = System.Int32::TryParse(v54, &v56 @ stack_-24_v2 (System.Int32));\n\tv61 = v59 == 0;\n\tif (v61) goto L_0038;\n\treturn v56;\nL_0038:\n\tv75 = System.String::Concat(\"Can't parse int arg: '\", v54, \"'\");\n\tv97 = new LunarConsolePluginInternal.ReflectionException();\n\tLunarConsolePluginInternal.ReflectionException::.ctor(v97, v75);\n\tthrow v97;\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int NextIntArg(Iterator<string> iter)
		{
			string text = NextArg(iter);
			if (int.TryParse(text, out var result))
			{
				return result;
			}
			string message = "Can't parse int arg: '" + text + "'";
			ReflectionException ex = new ReflectionException(message);
			throw ex;
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x13E4C38", Offset = "0x13E4C38", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F00C80]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, returnVal2, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AF4]) = v38;\nL_001A:\n\tgoto L_0021;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, returnVal2, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv54 = LunarConsolePluginInternal.ReflectionUtils::NextArg(iter);\n\tv59 = System.Single::TryParse(v54, &v56 @ stack_-24_v2 (System.Single));\n\tv61 = v59 == 0;\n\tif (v61) goto L_0038;\n\treturn v56;\nL_0038:\n\tv75 = System.String::Concat(\"Can't parse float arg: '\", v54, \"'\");\n\tv98 = new LunarConsolePluginInternal.ReflectionException();\n\tLunarConsolePluginInternal.ReflectionException::.ctor(v98, v75);\n\tthrow v98;\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float NextFloatArg(Iterator<string> iter)
		{
			string text = NextArg(iter);
			if (float.TryParse(text, out var result))
			{
				return result;
			}
			string message = "Can't parse float arg: '" + text + "'";
			ReflectionException ex = new ReflectionException(message);
			throw ex;
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0x13E4E10", Offset = "0x13E4E10", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECBC18]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AF5]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tv53 = LunarConsolePluginInternal.ReflectionUtils::NextArg(iter);\n\tv56 = System.String::ToLower(v53);\n\tv63 = System.String::op_Equality(v56, \"1\");\n\tv85 = v63 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_FFFFFFFF;\n\tv98 = System.String::op_Equality(v56, \"yes\");\n\tv114 = v98 == 0;\n\tv107 = ~v114;\n\tif (v107) goto L_FFFFFFFF;\n\tv104 = System.String::op_Equality(v56, \"true\");\n\tv106 = v104 == 0;\n\tif (v106) goto L_004E;\nL_0048:\n\treturn returnVal1;\nL_004E:\n\tv155 = System.String::op_Equality(v56, \"0\");\n\tv157 = v155 == 0;\n\tv158 = ~v157;\n\tif (v158) goto L_FFFFFFFF;\n\tv164 = System.String::op_Equality(v56, \"no\");\n\tv168 = v164 == 0;\n\tv166 = ~v168;\n\tif (v166) goto L_FFFFFFFF;\n\tv69 = System.String::op_Equality(v56, \"false\");\n\tv71 = v69 == 0;\n\tif (v71) goto L_0071;\n\tgoto L_0048;\n\tthrow System.NullReferenceException;\nL_0071:\n\tv83 = System.String::Concat(\"Can't parse bool arg: '\", iter, \"'\");\n\tv92 = new LunarConsolePluginInternal.ReflectionException();\n\tLunarConsolePluginInternal.ReflectionException::.ctor(v92, v83);\n\tthrow v92;\n\treturn returnVal2;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool NextBoolArg(Iterator<string> iter)
		{
			string text = NextArg(iter);
			switch (text.ToLower())
			{
			case "1":
			case "yes":
			case "true":
				return true;
			case "0":
			case "no":
			case "false":
				return false;
			default:
			{
				string message = "Can't parse bool arg: '" + (string)(object)iter + "'";
				ReflectionException ex = new ReflectionException(message);
				throw ex;
			}
			}
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x13E4B24", Offset = "0x13E4B24", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EA7C08]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AF6]) = v38;\nL_001A:\n\tv45 = LunarConsolePluginInternal.Iterator`1<System.String>::HasNext(iter, 1);\n\tv49 = v45 == 0;\n\tif (v49) goto L_004D;\n\tv63 = LunarConsolePluginInternal.Iterator`1<System.String>::Next(iter);\n\tgoto L_0032;\n\tv81 = *([v71 @ X8_v16+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_0032;\n\tv90 = v71;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v90, v62, v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv89 = LunarConsolePluginInternal.StringUtils::UnArg(v63);\n\tgoto L_0047;\n\tv116 = *([v94 @ X8_v19+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_0047;\n\tv121 = v94;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v121, v62, v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\treturn v89;\n\tthrow System.NullReferenceException;\nL_004D:\n\tv58 = new LunarConsolePluginInternal.ReflectionException();\n\tLunarConsolePluginInternal.ReflectionException::.ctor(v58, \"Unexpected end of args\");\n\tthrow v58;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string NextArg(Iterator<string> iter)
		{
			if (iter.HasNext())
			{
				string value = iter.Next();
				return StringUtils.UnArg(value);
			}
			ReflectionException ex = new ReflectionException("Unexpected end of args");
			throw ex;
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x13E5150", Offset = "0x13E5150", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsValidArg(string arg)
		{
			return true;
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x13D8574", Offset = "0x13D8574", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED1C60]);\n\tv29 = *([v28 @ X8_v17]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2028AF7]) = v48;\nL_001B:\n\tv52 = new System.Collections.Generic.List`1<System.Reflection.Assembly>();\n\tSystem.Collections.Generic.List`1<System.Reflection.Assembly>::.ctor(v52);\n\tv58 = System.AppDomain::get_CurrentDomain();\n\tv61 = System.AppDomain::GetAssemblies(v58);\n\tv213 = v61.Length;\n\tv125 = v61.Length < 1;\n\tif (v125) goto L_0071;\nL_003C:\n\tv214 = v70 < v213;\n\tv100 = ~v214;\n\tif (v100) goto L_0074;\n\tv231 = System.Func`2<System.Reflection.Assembly, System.Boolean>::Invoke(filter, v61[v70 @ X23_v5 (System.Int32)]);\n\tv236 = v231 == 0;\n\tif (v236) goto L_0058;\n\tSystem.Collections.Generic.List`1<System.Reflection.Assembly>::Add(v52, v61[v70 @ X23_v5 (System.Int32)]);\nL_0058:\n\tv213 = v61.Length;\n\tv70 = v70 + 1;\n\tv185 = v70 < v61.Length;\n\tif (v185) goto L_003C;\nL_0071:\n\treturn v52;\n\tv223 = new System.NullReferenceException();\nL_0074:\n\tv226 = new System.IndexOutOfRangeException();\n\tthrow v226;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Assembly> ListAssemblies(Func<Assembly, bool> filter)
		{
			List<Assembly> list = new List<Assembly>();
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			int num = assemblies.Length;
			if (assemblies.Length >= 1)
			{
				int num2 = 0;
				do
				{
					if (num2 < num)
					{
						if (filter(assemblies[num2]))
						{
							list.Add(assemblies[num2]);
						}
						num = assemblies.Length;
						num2++;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (num2 < assemblies.Length);
			}
			return list;
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x96C4F8", Offset = "0x96C4F8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EF9008]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021559]) = v41;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_003D;\n\tv67 = *([v63 @ X8_v9+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_003D;\n\tv83 = v63;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v83, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\treturnVal1 = LunarConsolePluginInternal.ReflectionUtils::FindAttributeTypes(assembly, v59);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Type> FindAttributeTypes<T>(Assembly assembly) where T : Attribute
		{
			Type typeFromHandle = typeof(T);
			return FindAttributeTypes(assembly, typeFromHandle);
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x13E5158", Offset = "0x13E5158", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EB2908]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, attributeType, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AF8]) = v41;\nL_0018:\n\tv45 = new LunarConsolePluginInternal.ReflectionUtils+<>c__DisplayClass12_0();\n\tSystem.Object::.ctor(v45);\n\tv45.attributeType = attributeType;\n\tv52 = new LunarConsolePluginInternal.ReflectionTypeFilter();\n\tv58 = Il2CppMethodInfo;\n\tv52.m_target = v45;\n\tv52.method = Il2CppMethodInfo;\n\tv52.method_ptr = *([v58 @ X8_v9 (Il2CppMethodInfo)]);\n\tgoto L_003F;\n\tv66 = *([v62 @ X0_v8+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_003F;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003F:\n\treturnVal2 = LunarConsolePluginInternal.ReflectionUtils::FindTypes(assembly, v52);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static List<Type> FindAttributeTypes(Assembly assembly, Type attributeType)
		{
			_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_1 = new _003C_003Ec__DisplayClass12_0();
			_003C_003Ec__DisplayClass12_1.attributeType = attributeType;
			ReflectionTypeFilter reflectionTypeFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)reflectionTypeFilter).m_target = _003C_003Ec__DisplayClass12_1;
			((Delegate)reflectionTypeFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass12_0._003CFindAttributeTypes_003Eb__0);
			((Delegate)reflectionTypeFilter).method_ptr = method_ptr;
			return FindTypes(assembly, reflectionTypeFilter);
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x13E522C", Offset = "0x13E522C", Length = "0x460")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ED1620]);\n\tv35 = *([v34 @ X8_v59]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, filter, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2028AF9]) = v53;\nL_001B:\n\tv54 = &v55 @ stack_-70;\n\tv60 = new System.Collections.Generic.List`1<System.Type>();\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v60);\n\tgoto L_0033;\n\tv71 = *([v67 @ X0_v4+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_0033;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, v64, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0033:\n\tv79 = LunarConsolePluginInternal.ReflectionUtils::GetAssemblyTypes(assembly);\n\tgoto L_0064;\n\tv152 = *([v83 @ X8_v42+B0]);\n\tv153 = 0;\n\tv154 = v152 + 8;\n\tv156 = *([v237 @ X11_v30-8]);\n\tv243 = v156 == v86;\n\tif (v243) goto L_005D;\n\tv178 = v238 + 1;\n\tv248 = v178 < v85;\n\tv174 = ~v248;\n\tv176 = v237 + 0x10;\n\tv158 = ~v174;\n\tif (v158) goto L_FFFFFFFF;\n\tv179 = v80;\n\tv180 = 0;\n\tv181 = 0x8909C4(v179, v86, v180, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0064;\nL_005D:\n\tv249 = *([v237 @ X11_v30]);\n\tv250 = v249 << 4;\n\tv251 = v83 + v250;\n\tv252 = v251 + 0x130;\nL_0064:\n\tv220 = System.Collections.Generic.IEnumerable`1<System.Type>::GetEnumerator(v79);\n\tv222 = v220 == 0;\n\tif (v222) goto L_00E8;\nL_0072:\n\tgoto L_0099;\n\tv383 = *([v359 @ X8_v46+B0]);\n\tv384 = 0;\n\tv385 = v383 + 8;\n\tv387 = *([v432 @ X11_v25-8]);\n\tv438 = v387 == v360;\n\tif (v438) goto L_0092;\n\tv409 = v433 + 1;\n\tv534 = v409 < v361;\n\tv405 = ~v534;\n\tv407 = v432 + 0x10;\n\tv389 = ~v405;\n\tif (v389) goto L_FFFFFFFF;\n\tv410 = v141;\n\tv411 = 0;\n\tv412 = 0x8909C4(v410, v360, v411, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0099;\nL_0092:\n\tv535 = *([v432 @ X11_v25]);\n\tv536 = v535 << 4;\n\tv537 = v359 + v536;\n\tv538 = v537 + 0x130;\nL_0099:\n\tv482 = System.Collections.IEnumerator::MoveNext(v220);\n\tv544 = v482 == 0;\n\tif (v544) goto L_00DC;\n\tgoto L_00C8;\n\tv701 = *([v640 @ X8_v50+B0]);\n\tv702 = 0;\n\tv703 = v701 + 8;\n\tv705 = *([v757 @ X11_v20-8]);\n\tv763 = v705 == v641;\n\tif (v763) goto L_00C1;\n\tv727 = v758 + 1;\n\tv780 = v727 < v642;\n\tv723 = ~v780;\n\tv725 = v757 + 0x10;\n\tv707 = ~v723;\n\tif (v707) goto L_FFFFFFFF;\n\tv728 = v141;\n\tv729 = 0;\n\tv730 = 0x8909C4(v728, v641, v729, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00C8;\nL_00C1:\n\tv781 = *([v757 @ X11_v20]);\n\tv782 = v781 << 4;\n\tv783 = v640 + v782;\n\tv784 = v783 + 0x130;\nL_00C8:\n\tv789 = System.Collections.Generic.IEnumerator`1<System.Type>::get_Current(v220);\n\tv353 = LunarConsolePluginInternal.ReflectionTypeFilter::Invoke(filter, v789);\n\tv356 = v353 == 0;\n\tif (v356) goto L_0072;\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v60, v789);\n\tgoto L_0072;\nL_00DC:\n\t*([v54 @ X24_v1]) = 0x3F;\n\tv644 = v220 == 0;\n\tv484 = ~v644;\n\tif (v484) goto L_010A;\n\tgoto L_0132;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00E8:\n\tv226 = new System.NullReferenceException();\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00FB;\n\tgoto L_00FB;\n\tgoto L_00FB;\nL_00FB:\n\tv266 = v371 != 1;\n\tif (v266) goto L_0158;\n\tv271 = 0x6D2BC0(v226, v371, v367, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv485 = *([v271 @ X0_v54]);\n\tv364 = 0x6D2490(v271, v371, v367, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv414 = v478 == 0;\n\tif (v414) goto L_0132;\nL_010A:\n\tgoto L_0131;\n\tv545 = *([v490 @ X8_v36+B0]);\n\tv546 = 0;\n\tv547 = v545 + 8;\n\tv549 = *([v655 @ X11_v9-8]);\n\tv661 = v549 == v493;\n\tif (v661) goto L_012A;\n\tv571 = v656 + 1;\n\tv731 = v571 < v492;\n\tv567 = ~v731;\n\tv569 = v655 + 0x10;\n\tv551 = ~v567;\n\tif (v551) goto L_FFFFFFFF;\n\tv572 = v478;\n\tv573 = 0;\n\tv574 = 0x8909C4(v572, v493, v573, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0131;\nL_012A:\n\tv732 = *([v655 @ X11_v9]);\n\tv733 = v732 << 4;\n\tv734 = v490 + v733;\n\tv735 = v734 + 0x130;\nL_0131:\n\tSystem.IDisposable::Dispose(v220);\nL_0132:\n\tv527 = v275 + 1;\n\tv529 = v527 == 0;\n\tif (v529) goto L_0146;\n\tv575 = v524 == 0;\n\tif (v575) goto L_019B;\n\tv671 = *([v54 @ X24_v1+v275 @ X23_v2 (System.Int32)*4]) == 0x3F;\n\tif (v671) goto L_019B;\n\tgoto L_014B;\nL_0146:\n\tv576 = v524 == 0;\n\tif (v576) goto L_019B;\nL_014B:\n\tv315 = new System.TypeLoadException();\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_0158:\n\tv331 = 0 != 1;\n\tif (v331) goto L_01AE;\n\tv366 = 0x6D2BC0(v377, 0, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv370 = *([v366 @ X0_v14]);\n\tv420 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v370 @ X21_v4 (System.Exception)]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv532 = v420 & 1;\n\tv533 = v532 == 0;\n\tif (v533) goto L_019D;\n\tv577 = 0x6D2490(v420, *([v370 @ X21_v4 (System.Exception)]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t// 363 NewArr v695 @ X0_v29 (System.Object[]), typeof(System.Object[]), 1\n\tv768 = assembly == 0;\n\tif (v768) goto L_0178;\n\t// 372 IsInst v794 @ X0_v36, typeof(System.Object), assembly @ X0 (System.Reflection.Assembly)\nL_0178:\n\tv775 = v695.Length == 0;\n\tif (v775) goto L_01A5;\n\tv695[0] = assembly;\n\tgoto L_018C;\n\tv816 = *([v803 @ X0_v31+E0]);\n\tv817 = v816 == 0;\n\tv818 = ~v817;\n\tif (v818) goto L_018C;\n\tv820 = \"il2cpp_codegen_runtime_class_init\"(v803, v771, v284, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_018C:\n\tLunarConsolePluginInternal.Log::e(v370, \"Unable to list types for assembly: {0}\", v695);\nL_019B:\n\treturn v60;\nL_019D:\n\tv579 = 0x6D1E60(8, *([v370 @ X21_v4 (System.Exception)]), 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\t*([v579 @ X0_v25]) = *([v366 @ X0_v14]);\n\tv698 = 0x1E8A000 + 0x870;\n\tv700 = 0x6D2A00(v579, v698, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv746 = new System.NullReferenceException();\nL_01A5:\n\tv779 = new System.IndexOutOfRangeException();\n\tgoto L_01AA;\n\tv810 = new System.ArrayTypeMismatchException();\nL_01AA:\n\tthrow v809;\nL_01AE:\n\tv382 = 0x6D2380(v377, 0, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturnVal1 = 0x846AA4(v382, 0, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn returnVal1;\n// 247 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Type> FindTypes(Assembly assembly, ReflectionTypeFilter filter)
		{
			//IL_0103: Expected I4, but got O
			//IL_006a: Expected O, but got I4
			//IL_013b: Expected I4, but got O
			object obj2 = default(object);
			object obj = obj2;
			List<Type> list = new List<Type>();
			IEnumerable<Type> assemblyTypes = GetAssemblyTypes(assembly);
			IEnumerator<Type> enumerator = assemblyTypes.GetEnumerator();
			int num2;
			int num3;
			int num4;
			int num5;
			NullReferenceException ex2;
			if (enumerator == null)
			{
				NullReferenceException ex = new NullReferenceException();
				int num = default(int);
				bool flag = num != 1;
				ex2 = ex;
				if (flag)
				{
					goto IL_03d4;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj3 = default(object);
				num2 = (int)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<Type> enumerator2 = default(IEnumerator<Type>);
				bool flag2 = enumerator2 == null;
				num3 = -1;
				num4 = -1;
				num5 = (int)obj3;
				if (flag2)
				{
					goto IL_03a9;
				}
			}
			else
			{
				while (enumerator.MoveNext())
				{
					Type current = enumerator.Current;
					if (filter(current))
					{
						list.Add(current);
					}
				}
				obj = 63;
				bool flag3 = enumerator == null;
				bool flag4 = !flag3;
				num3 = 0;
				num2 = 0;
				if (!flag4)
				{
					num4 = 0;
					num5 = 0;
					goto IL_03a9;
				}
			}
			enumerator.Dispose();
			num4 = num3;
			num5 = num2;
			goto IL_03a9;
			IL_03a9:
			if (num4 + 1 != 0)
			{
				if (num5 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v275 @ X23_v2 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)63)
					{
						goto IL_01b2;
					}
				}
			}
			else if (num5 != 0)
			{
				goto IL_01b2;
			}
			goto IL_02b3;
			IL_02b3:
			return list;
			IL_01b2:
			TypeLoadException ex3 = new TypeLoadException();
			ex2 = (NullReferenceException)(object)ex3;
			goto IL_03d4;
			IL_03d4:
			if (0 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj4 = default(object);
				Exception exception = (Exception)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj5 = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj5 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					object[] array = new object[1];
					if ((object)assembly != null)
					{
						object obj6 = assembly as object;
					}
					if (array.Length != 0)
					{
						array[0] = assembly;
						Log.e(exception, "Unable to list types for assembly: {0}", array);
						goto IL_02b3;
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj7 = obj4;
					int num6 = 32022528 + 2160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					NullReferenceException ex4 = new NullReferenceException();
				}
				IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
				IndexOutOfRangeException ex6 = default(IndexOutOfRangeException);
				throw ex6;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			List<Type> result = default(List<Type>);
			return result;
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x13E568C", Offset = "0x13E568C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EFADF8]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2028AFA]) = v46;\nL_0017:\n\tv47 = assembly == 0;\n\tif (v47) goto L_0029;\n\tv52 = System.Reflection.Assembly::GetTypes(assembly);\nL_0027:\n\treturn returnVal1;\nL_0029:\n\tv54 = new System.NullReferenceException();\n\tv130 = v166 != 1;\n\tif (v130) goto L_00B5;\n\tv179 = 0x6D2BC0(v54, v166, v215, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv207 = *([v179 @ X0_v10 (System.Type)]);\n\tv211 = \"il2cpp_vm_class_is_assignable_from\"(System.Reflection.ReflectionTypeLoadException, *([v207 @ X20_v5 (Il2CppClass<System.Type>)]), v215, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv212 = v211 & 1;\n\tv213 = v212 == 0;\n\tif (v213) goto L_00AB;\n\tv214 = 0x6D2490(v211, *([v207 @ X20_v5 (Il2CppClass<System.Type>)]), v215, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv246 = new System.Collections.Generic.List`1<System.Type>();\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v246);\n\tv111 = *([v207 @ X20_v5 (Il2CppClass<System.Type>)+88]);\n\tv338 = *([v111 @ X20_v8+18]);\n\tv303 = *([v111 @ X20_v8+18]) < 1;\n\tif (v303) goto L_FFFFFFFF;\nL_0063:\n\tv339 = v260 < v338;\n\tv340 = ~v339;\n\tif (v340) goto L_00A4;\n\tv259 = v260 << 3;\n\tv348 = v111 + v259;\n\tv257 = v348 + 0x20;\n\tgoto L_007E;\n\tv359 = *([v349 @ X0_v30+E0]);\n\tv360 = v359 == 0;\n\tv361 = ~v360;\n\tif (v361) goto L_007E;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v349, v334, v323, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007E:\n\tv284 = System.Type::op_Inequality(*([v257 @ X24_v10]), 0);\n\tv356 = v284 == 0;\n\tif (v356) goto L_0094;\n\tv368 = v260 < *([v111 @ X20_v8+18]);\n\tv279 = ~v368;\n\tif (v279) goto L_00A4;\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v246, *([v257 @ X24_v10]));\nL_0094:\n\tv338 = *([v111 @ X20_v8+18]);\n\tv260 = v260 + 1;\n\tv309 = v260 < *([v111 @ X20_v8+18]);\n\tif (v309) goto L_0063;\n\tgoto L_0027;\nL_00A4:\n\tv358 = new System.IndexOutOfRangeException();\n\tthrow v358;\n\tthrow System.NullReferenceException;\nL_00AB:\n\tv242 = 0x6D1E60(8, *([v207 @ X20_v5 (Il2CppClass<System.Type>)]), v215, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\t*([v242 @ X0_v15]) = *([v179 @ X0_v10 (System.Type)]);\n\tv166 = 0x1E8A000 + 0x870;\n\tv248 = 0x6D2A00(v242, v166, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv198 = 0x6D2490(v248, v166, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B5:\n\tv204 = 0x6D2380(v172, v166, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturnVal2 = 0x846AA4(v204, v166, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\treturn returnVal2;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IEnumerable<Type> GetAssemblyTypes(Assembly assembly)
		{
			//IL_0062: Expected I, but got O
			//IL_00cb: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			if ((object)assembly != null)
			{
				return assembly.GetTypes();
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			bool flag = intPtr != (IntPtr)1;
			NullReferenceException ex2 = ex;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Type type = default(Type);
				IntPtr intPtr2 = (IntPtr)type;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
				object obj = default(object);
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					List<Type> list = new List<Type>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X20_v5 (Il2CppClass<System.Type>)+88]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X20_v8+18]");
					int num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X20_v8+18]");
					if (0L >= 1L)
					{
						int num2 = 0;
						while (true)
						{
							if (num2 < num)
							{
								int num3 = num2 << 3;
								object obj3 = (long)(IntPtr)obj2 + (long)num3;
								object obj4 = (long)(IntPtr)obj3 + 32L;
								if ((Type)obj4 != null)
								{
									int num4 = num2;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X20_v8+18]");
									if ((long)num4 >= 0L)
									{
										goto IL_0201;
									}
									list.Add((Type)obj4);
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X20_v8+18]");
								num = 0;
								num2++;
								int num5 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X20_v8+18]");
								if ((long)num5 >= 0L)
								{
									break;
								}
								continue;
							}
							goto IL_0201;
							IL_0201:
							IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
							throw ex3;
						}
					}
					return list;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
				object obj5 = type;
				intPtr = (IntPtr)(32022528 + 2160);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				NullReferenceException ex4 = default(NullReferenceException);
				ex2 = ex4;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
			IEnumerable<Type> result = default(IEnumerable<Type>);
			return result;
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x13E5850", Offset = "0x13E5850", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1F01008]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AFB]) = v35;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (System.Object[]), typeof(System.Object[]), 0\n\tv44.EMPTY_INVOKE_ARGS = v40;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ReflectionUtils()
		{
			object[] eMPTY_INVOKE_ARGS = new object[0];
			EMPTY_INVOKE_ARGS = eMPTY_INVOKE_ARGS;
		}
	}
}
