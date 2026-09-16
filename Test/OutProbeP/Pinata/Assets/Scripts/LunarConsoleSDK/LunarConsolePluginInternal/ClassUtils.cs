using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000027")]
	public static class ClassUtils
	{
		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xB88CBC", Offset = "0xB88CBC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = v17;\n\tv23 = 0x8907BC(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0014:\n\t// 20 IsInst v41 @ X0_v3, typeof(T), obj @ X0 (System.Object)\n\tgoto L_001F;\n\tv49 = v44;\n\tv50 = 0x8907BC(v49, v40, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv52 = v41 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\t// 35 IsInst returnVal1 @ X0_v5 (T), typeof(T), v41 @ X0_v3\n\tv63 = returnVal1 == 0;\n\tv61 = ~v63;\n\tif (v61) goto L_0031;\n\tthrow System.InvalidCastException;\nL_0031:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Cast<T>(object obj) where T : class
		{
			object obj2 = obj as T;
			T val;
			if (obj2 != null)
			{
				val = obj2 as T;
				if (val == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val = null;
			}
			return val;
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xB890D8", Offset = "0xB890D8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = v17;\n\tv23 = 0x8907BC(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0014:\n\t// 20 IsInst v41 @ X0_v3, typeof(T), obj @ X0 (System.Object)\n\tgoto L_001F;\n\tv49 = v44;\n\tv50 = 0x8907BC(v49, v40, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv52 = v41 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\t// 35 IsInst returnVal1 @ X0_v5 (T), typeof(T), v41 @ X0_v3\n\tv63 = returnVal1 == 0;\n\tv61 = ~v63;\n\tif (v61) goto L_0031;\n\tthrow System.InvalidCastException;\nL_0031:\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T TryCast<T>(object obj) where T : class
		{
			object obj2 = obj as T;
			T val;
			if (obj2 != null)
			{
				val = obj2 as T;
				if (val == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				val = null;
			}
			return val;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xB88D48", Offset = "0xB88D48", Length = "0x1A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1F07D40]);\n\tv27 = *([v26 @ X8_v28]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, args, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022A06]) = v44;\nL_001A:\n\tv48 = System.Activator::CreateInstance(t, args);\n\tgoto L_0025;\n\tv56 = v51;\n\tv57 = 0x8907BC(v56, v46, v47, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0025:\n\tv59 = v48 == 0;\n\tif (v59) goto L_FFFFFFFF;\n\t// 41 IsInst returnVal1 @ X0_v5 (T), typeof(T), v48 @ X0_v3 (System.Object)\n\tv107 = returnVal1 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0079;\n\tv134 = new System.InvalidCastException();\n\tgoto L_003B;\nL_003B:\n\tv68 = Il2CppClass<T> != 1;\n\tif (v68) goto L_008C;\n\tv166 = 0x6D2BC0(v134, Il2CppClass<T>, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv101 = *([v166 @ X0_v17]);\n\tv182 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v101 @ X20_v8 (System.Exception)]), 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv183 = v182 & 1;\n\tv184 = v183 == 0;\n\tif (v184) goto L_007B;\n\tv185 = 0x6D2490(v182, *([v101 @ X20_v8 (System.Exception)]), 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t// 78 NewArr v192 @ X0_v32 (System.Object[]), typeof(System.Object[]), 1\n\tv206 = t == 0;\n\tif (v206) goto L_005B;\n\t// 87 IsInst v221 @ X0_v39, typeof(System.Object), t @ X0 (System.Type)\nL_005B:\n\tv213 = v192.Length == 0;\n\tif (v213) goto L_0083;\n\tv192[0] = t;\n\tgoto L_0070;\n\tv236 = *([v227 @ X0_v34+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0070;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v227, v209, v47, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0070:\n\tLunarConsolePluginInternal.Log::e(v101, \"Exception while creating an instance of type '{0}'\", v192);\nL_0079:\n\treturn returnVal1;\nL_007B:\n\tv187 = 0x6D1E60(8, *([v101 @ X20_v8 (System.Exception)]), 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t*([v187 @ X0_v28]) = *([v166 @ X0_v17]);\n\tv195 = 0x1E8A000 + 0x870;\n\tv197 = 0x6D2A00(v187, v195, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv205 = new System.NullReferenceException();\nL_0083:\n\tv217 = new System.IndexOutOfRangeException();\n\tgoto L_0088;\n\tv234 = new System.ArrayTypeMismatchException();\nL_0088:\n\tthrow v233;\nL_008C:\n\tv176 = 0x6D2380(v134, Il2CppClass<T>, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturnVal2 = 0x846AA4(v176, Il2CppClass<T>, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn returnVal2;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T CreateInstance<T>(Type t, params object[] args) where T : class
		{
			object obj = Activator.CreateInstance(t, args);
			if (obj == null)
			{
				goto IL_0178;
			}
			T val = obj as T;
			if (val == null)
			{
				InvalidCastException ex = new InvalidCastException();
				if ((IntPtr)0 == (IntPtr)1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj2 = default(object);
					Exception exception = (Exception)obj2;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					object obj3 = default(object);
					if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						object[] array = new object[1];
						if ((object)t != null)
						{
							object obj4 = t as object;
						}
						if (array.Length != 0)
						{
							array[0] = t;
							Log.e(exception, "Exception while creating an instance of type '{0}'", array);
							goto IL_0178;
						}
					}
					else
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj5 = obj2;
						int num = 32022528 + 2160;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
						NullReferenceException ex2 = new NullReferenceException();
					}
					IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
					IndexOutOfRangeException ex4 = default(IndexOutOfRangeException);
					throw ex4;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				T result = default(T);
				return result;
			}
			goto IL_021b;
			IL_021b:
			return val;
			IL_0178:
			val = null;
			goto IL_021b;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x11B9974", Offset = "0x11B9974", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EC7700]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2027B17]) = v41;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\t// 44 Box v66 @ X0_v7 (System.Object), typeof(System.Int32), &value @ X0 (System.Int32)\n\tgoto L_003E;\n\tv74 = *([v70 @ X8_v11+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_003E;\n\tv85 = v70;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v85, v63, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003E:\n\tv84 = System.Enum::IsDefined(v59, v66);\n\treturn v84;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsValidEnumValue<T>(int value)
		{
			Type typeFromHandle = typeof(T);
			object value2 = value;
			return Enum.IsDefined(typeFromHandle, value2);
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x11B9A4C", Offset = "0x11B9A4C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1EE0B18]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2027B18]) = v41;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_003D;\n\tv67 = *([v63 @ X8_v9+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_003D;\n\tv83 = v63;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v83, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\treturnVal1 = System.Enum::IsDefined(v59, value);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsValidEnumValue<T>(T value)
		{
			Type typeFromHandle = typeof(T);
			return Enum.IsDefined(typeFromHandle, value);
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x13DF24C", Offset = "0x13DF24C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EFD340]);\n\tv21 = *([v20 @ X8_v42]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028AB9]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0023:\n\tv57 = System.Type::op_Inequality(type, 0);\n\tv61 = v57 == 0;\n\tif (v61) goto L_00B1;\n\tgoto L_0038;\n\tv89 = *([v63 @ X0_v8+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tif (v91) goto L_0038;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v63, v55, v56, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0038:\n\tv98 = System.Type::GetTypeFromHandle(System.Int32);\n\tv129 = System.Type::op_Equality(type, v98);\n\tv131 = v129 == 0;\n\tif (v131) goto L_004A;\n\tgoto L_FFFFFFFF;\nL_004A:\n\tgoto L_0052;\n\tv164 = *([v135 @ X0_v16+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_0052;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v135, v126, v128, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0052:\n\tv173 = System.Type::GetTypeFromHandle(System.Single);\n\tv151 = System.Type::op_Equality(type, v173);\n\tv155 = v151 == 0;\n\tif (v155) goto L_0064;\n\tgoto L_FFFFFFFF;\nL_0064:\n\tgoto L_006C;\n\tv182 = *([v178 @ X0_v22+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_006C;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v178, v146, v143, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006C:\n\tv191 = System.Type::GetTypeFromHandle(System.String);\n\tv152 = System.Type::op_Equality(type, v191);\n\tv156 = v152 == 0;\n\tif (v156) goto L_007E;\n\tgoto L_FFFFFFFF;\nL_007E:\n\tgoto L_0086;\n\tv200 = *([v196 @ X0_v28+E0]);\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_0086;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v196, v147, v144, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0086:\n\tv209 = System.Type::GetTypeFromHandle(System.Int64);\n\tv153 = System.Type::op_Equality(type, v209);\n\tv157 = v153 == 0;\n\tif (v157) goto L_0098;\n\tgoto L_FFFFFFFF;\nL_0098:\n\tgoto L_00A0;\n\tv218 = *([v214 @ X0_v34+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_00A0;\n\tv222 = \"il2cpp_codegen_runtime_class_init\"(v214, v148, v145, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00A0:\n\tv226 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv150 = System.Type::op_Equality(type, v226);\n\tv154 = v150 == 0;\n\tif (v154) goto L_00B4;\nL_00B1:\n\treturn returnVal1;\nL_00B4:\n\tv119 = type->klass;\n\tv106 = type->klass->vtable[7];\n\tv109 = type->klass->vtable[7];\n\t// 190 IndirectJump v106 @ X2_v9, type @ X0 (System.Type), type @ X0 (System.Type), v109 @ X1_v14, v106 @ X2_v9, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string TypeShortName(Type type)
		{
			//IL_01e1: Expected I, but got O
			//IL_01f1: Expected O, but got I
			//IL_0201: Expected O, but got I
			string result;
			while (true)
			{
				bool flag = type != null;
				bool flag2 = !flag;
				result = null;
				if (flag2)
				{
					break;
				}
				Type typeFromHandle = typeof(int);
				string text;
				if (type == typeFromHandle)
				{
					text = "int";
				}
				else
				{
					Type typeFromHandle2 = typeof(float);
					if (type == typeFromHandle2)
					{
						text = "float";
					}
					else
					{
						Type typeFromHandle3 = typeof(string);
						if (type == typeFromHandle3)
						{
							text = "string";
						}
						else
						{
							Type typeFromHandle4 = typeof(long);
							if (type == typeFromHandle4)
							{
								text = "long";
							}
							else
							{
								Type typeFromHandle5 = typeof(bool);
								if (!(type == typeFromHandle5))
								{
									IntPtr intPtr = (IntPtr)type;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v23 (Il2CppClass<System.Type>)+1A0]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X8_v23 (Il2CppClass<System.Type>)+1A8]");
									object obj2 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v106 @ X2_v9 (should have been resolved before IL gen)");
									continue;
								}
								text = "bool";
							}
						}
					}
				}
				result = text;
				break;
			}
			return result;
		}

		[Token(Token = "0x6000100")]
		[Address(RVA = "0x13DF488", Offset = "0x13DF488", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ECBF48]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, filter, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028ABA]) = v41;\nL_0018:\n\tv45 = new System.Collections.Generic.List`1<System.Reflection.MethodInfo>();\n\tSystem.Collections.Generic.List`1<System.Reflection.MethodInfo>::.ctor(v45);\n\treturnVal1 = LunarConsolePluginInternal.ClassUtils::ListMethods(v45, type, filter, 0x36);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MethodInfo> ListInstanceMethods(Type type, ListMethodsFilter filter)
		{
			List<MethodInfo> outList = new List<MethodInfo>();
			return ListMethods(outList, type, filter, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0x13DF508", Offset = "0x13DF508", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = LunarConsolePluginInternal.ClassUtils::ListMethods(outList, type, filter, 0x36);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MethodInfo> ListInstanceMethods(List<MethodInfo> outList, Type type, ListMethodsFilter filter)
		{
			return ListMethods(outList, type, filter, BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		}

		[Token(Token = "0x6000102")]
		[Address(RVA = "0x13DF510", Offset = "0x13DF510", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EAE888]);\n\tv33 = *([v32 @ X8_v14]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, type, filter, flags, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2028ABB]) = v49;\nL_001C:\n\t;\n\tv56 = System.Type::GetMethods(type, flags);\n\tv58 = filter == 0;\n\tif (v58) goto L_0066;\n\tv113 = v56.Length;\n\tv130 = v56.Length < 1;\n\tif (v130) goto L_0071;\nL_0037:\n\tv214 = v116 < v113;\n\tv90 = ~v214;\n\tif (v90) goto L_0072;\n\tv102 = LunarConsolePluginInternal.ListMethodsFilter::Invoke(filter, v56[v116 @ X23_v6 (System.Int32)]);\n\tv218 = v102 == 0;\n\tif (v218) goto L_0050;\n\tSystem.Collections.Generic.List`1<System.Reflection.MethodInfo>::Add(outList, v56[v116 @ X23_v6 (System.Int32)]);\nL_0050:\n\tv113 = v56.Length;\n\tv116 = v116 + 1;\n\tv186 = v116 < v56.Length;\n\tif (v186) goto L_0037;\n\tgoto L_0071;\nL_0066:\n\tSystem.Collections.Generic.List`1<System.Reflection.MethodInfo>::AddRange(outList, v56);\nL_0071:\n\treturn outList;\nL_0072:\n\tv216 = new System.IndexOutOfRangeException();\n\tthrow v216;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MethodInfo> ListMethods(List<MethodInfo> outList, Type type, ListMethodsFilter filter, BindingFlags flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
		{
			MethodInfo[] methods = type.GetMethods(flags);
			if (filter != null)
			{
				int num = methods.Length;
				if (methods.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							if (filter(methods[num2]))
							{
								outList.Add(methods[num2]);
							}
							num = methods.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < methods.Length);
				}
			}
			else
			{
				outList.AddRange(methods);
			}
			return outList;
		}

		[Token(Token = "0x6000103")]
		[Address(RVA = "0x13DF9EC", Offset = "0x13DF9EC", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EA5E90]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, prefix, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028ABC]) = v41;\nL_001B:\n\tv47 = System.Reflection.MemberInfo::get_Name(m);\n\tv51 = LunarConsolePluginInternal.StringUtils;\n\tv53 = *([v51 @ X8_v6 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]) & 2;\n\tv54 = v53 == 0;\n\tif (v54) goto L_0027;\n\tv58 = *([v51 @ X8_v6 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]) == 0;\n\tif (v58) goto L_0039;\nL_0027:\n\tv61 = prefix == 0;\n\tif (v61) goto L_0043;\nL_0029:\n\tv68 = v47 == 0;\n\tif (v68) goto L_0043;\n\treturnVal3 = System.String::StartsWith(v47, prefix, 5);\n\treturn returnVal3;\nL_0039:\n\tv100 = prefix == 0;\n\tv67 = ~v100;\n\tif (v67) goto L_0029;\nL_0043:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ShouldListMethod(MethodInfo m, string prefix)
		{
			//IL_0020: Expected I, but got O
			string name = m.Name;
			IntPtr intPtr = (IntPtr)typeof(StringUtils);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v6 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v6 (Il2CppClass<LunarConsolePluginInternal.StringUtils>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					if (prefix != null)
					{
						goto IL_0095;
					}
					goto IL_00f5;
				}
			}
			if (prefix != null)
			{
				goto IL_0095;
			}
			goto IL_00f5;
			IL_0095:
			if (name != null)
			{
				return name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
			}
			goto IL_00f5;
			IL_00f5:
			return false;
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xB88EF0", Offset = "0xB88EF0", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EA5530]);\n\tv31 = *([v30 @ X8_v32]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, name, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022A07]) = v48;\nL_0019:\n\tv49 = target == 0;\n\tif (v49) goto L_00A5;\n\tv52 = System.Object::GetType(target);\n\tv116 = System.Type::GetFields(v52, 0x3C);\n\tv261 = v116.Length;\n\tv155 = v116.Length < 1;\n\tif (v155) goto L_0064;\nL_0036:\n\tv262 = v121 < v261;\n\tv130 = ~v262;\n\tif (v130) goto L_009B;\n\tv278 = System.Reflection.MemberInfo::get_Name(v116[v121 @ X24_v7 (System.Int32)]);\n\tv188 = System.String::op_Equality(v278, name);\n\tv291 = v188 == 0;\n\tv190 = ~v291;\n\tif (v190) goto L_0075;\n\tv261 = v116.Length;\n\tv162 = v121 + 1;\n\tv164 = v162 < v116.Length;\n\tif (v164) goto L_0036;\nL_0064:\n\tv198 = System.String::Concat(\"Can't find field: \", name);\n\tv268 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v268, v198);\n\tthrow v268;\nL_0075:\n\tv302 = *([v292 @ X23_v3 (System.Reflection.FieldInfo)]);\n\tv305 = System.Reflection.FieldInfo::GetValue(v292, target);\n\tv306 = methodInfo->rgctx_data;\n\tv308 = methodInfo->rgctx_data->rgctxDataDummy;\n\tv309 = *([v308 @ X19_v4+12E]) & 1;\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_0085;\n\tv315 = 0x8907BC(v308, target, *([v302 @ X8_v14 (Il2CppClass<System.Reflection.FieldInfo>)+268]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0085:\n\tv317 = v305 == 0;\n\tif (v317) goto L_FFFFFFFF;\n\treturnVal2 = \"il2cpp_codegen_object_is_inst\"(v305, v308, *([v302 @ X8_v14 (Il2CppClass<System.Reflection.FieldInfo>)+268]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv328 = returnVal2 == 0;\n\tv326 = ~v328;\n\tif (v326) goto L_009A;\n\tthrow System.InvalidCastException;\nL_009A:\n\treturn returnVal2;\nL_009B:\n\tv271 = new System.IndexOutOfRangeException();\n\tthrow v271;\n\tv135 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_00A5:\n\tv105 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v105, \"target\");\n\tthrow v105;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetObjectField<T>(object target, string name)
		{
			//IL_0146: Expected I, but got O
			//IL_0167: Expected O, but got I
			if (target != null)
			{
				Type type = target.GetType();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				int num = fields.Length;
				if (fields.Length >= 1)
				{
					int num2 = 0;
					bool flag4;
					T val = default(T);
					do
					{
						if (num2 < num)
						{
							string name2 = fields[num2].Name;
							bool flag = name2 == name;
							bool flag2 = !flag;
							bool flag3 = !flag2;
							FieldInfo fieldInfo = fields[num2];
							if (!flag3)
							{
								num = fields.Length;
								int num3 = num2 + 1;
								flag4 = num3 < fields.Length;
								fieldInfo = fields[num2];
								num2 = num3;
								continue;
							}
							IntPtr intPtr = (IntPtr)fieldInfo;
							object value = fieldInfo.GetValue(target);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [methodInfo @ X2 (Il2CppMethodInfo)+30]");
							object obj = 0;
							object obj2 = obj;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ X19_v4+12E]");
							if (0 == 0)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8907BC");
							}
							if (value != null)
							{
								Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
								if (val == null)
								{
									throw new InvalidCastException();
								}
								return val;
							}
							return (T)null;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (flag4);
				}
				string message = "Can't find field: " + name;
				ArgumentException ex2 = new ArgumentException(message);
				throw ex2;
			}
			ArgumentNullException ex3 = new ArgumentNullException("target");
			throw ex3;
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x13DFAAC", Offset = "0x13DFAAC", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EA9CA8]);\n\tv29 = *([v28 @ X8_v46]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2028ABD]) = v48;\nL_0018:\n\tv49 = typeName == 0;\n\tif (v49) goto L_00C1;\n\tv51 = System.AppDomain::get_CurrentDomain();\n\tv118 = System.AppDomain::GetAssemblies(v51);\n\tv149 = v118 == 0;\n\tif (v149) goto L_00D0;\n\tv104 = v118.Length;\n\tv186 = v118.Length < 1;\n\tif (v186) goto L_FFFFFFFF;\nL_0033:\n\tv274 = v67 < v104;\n\tv95 = ~v274;\n\tif (v95) goto L_00BA;\n\tv371 = v118[v67 @ X23_v9 (System.Int32)];\n\tv361 = v118[v67 @ X23_v9 (System.Int32)] == 0;\n\tif (v361) goto L_0089;\n\tv368 = *([v371 @ X0_v53 (System.Reflection.Assembly)]);\n\tv394 = *([v368 @ X8_v36 (Il2CppClass<System.Reflection.Assembly>)+228]);\n\tv407 = System.Reflection.Assembly::GetTypes(v118[v67 @ X23_v9 (System.Int32)]);\n\tv362 = v407 == 0;\n\tif (v362) goto L_008C;\n\tv366 = v407.Length;\n\tv420 = v407.Length < 1;\n\tif (v420) goto L_00AB;\nL_0057:\n\tv471 = v280 < v366;\n\tv305 = ~v471;\n\tif (v305) goto L_0084;\n\tv359 = v407[v280 @ X25_v11 (System.Int32)] == 0;\n\tif (v359) goto L_0082;\n\tv479 = System.Type::get_FullName(v407[v280 @ X25_v11 (System.Int32)]);\n\tv309 = System.String::op_Equality(v479, typeName);\n\tv488 = v309 == 0;\n\tv311 = ~v488;\n\tif (v311) goto L_012C;\n\tv366 = v407.Length;\n\tv280 = v280 + 1;\n\tv436 = v280 < v407.Length;\n\tif (v436) goto L_0057;\n\tgoto L_00AB;\nL_0082:\n\tv352 = new System.NullReferenceException();\n\tgoto L_00D9;\nL_0084:\n\tv473 = new System.IndexOutOfRangeException();\n\tthrow v473;\n\tgoto L_00D9;\nL_0089:\n\tv352 = new System.NullReferenceException();\n\tgoto L_00D9;\nL_008C:\n\tv352 = new System.NullReferenceException();\n\tgoto L_00D9;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\n\tgoto L_0093;\nL_0093:\n\tX22 = X1;\n\tX21 = X0;\n\tC = X22 < 1;\n\tC = ~C;\n\tTEMP1 = X22 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X22 ^ 1;\n\tTEMP3 = X22 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00E4;\n\tX0 = X21;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX8 = *([X21]);\n\tX0 = *([X24]);\n\tX1 = *([X8]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00D1;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AB:\n\tv104 = v118.Length;\n\tv67 = v67 + 1;\n\tv216 = v67 < v118.Length;\n\tif (v216) goto L_0033;\n\tgoto L_FFFFFFFF;\nL_00BA:\n\tv372 = new System.IndexOutOfRangeException();\n\tthrow v372;\nL_00C1:\n\tv110 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v110, \"typeName\");\n\tthrow v110;\n\tthrow System.NullReferenceException;\nL_00D0:\n\tthrow System.NullReferenceException;\nL_00D1:\n\t;\n\tv258 = *([v153 @ X21_v10 (System.Type[])]);\n\t*([v188 @ X0_v38]) = v258;\n\tv260 = 0x1E8A000 + 0x870;\n\tv262 = 0x6D2A00(v188, v260, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00D9:\n\tgoto L_00E3;\n\tgoto L_00DE;\n\tgoto L_00DE;\n\tgoto L_00DE;\n\tgoto L_00DE;\nL_00DE:\n\tX22 = X1;\n\tX21 = X0;\n\tgoto L_00E4;\nL_00E3:\n\tv406 = 0x6D2490(v352, v394, v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00E4:\n\t;\n\tv215 = v394 != 1;\n\tif (v215) goto L_0140;\n\tv423 = 0x6D2BC0(v352, v394, v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv256 = *([v423 @ X0_v12]);\n\tv461 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v256 @ X20_v7 (System.Exception)]), v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv472 = v461 & 1;\n\tv363 = v472 == 0;\n\tif (v363) goto L_012E;\n\tv474 = 0x6D2490(v461, *([v256 @ X20_v7 (System.Exception)]), v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t// 256 NewArr v485 @ X0_v20 (System.Object[]), typeof(System.Object[]), 1\n\t// 263 IsInst v495 @ X0_v28, typeof(System.Object), v251 @ X19_v5 (System.String)\n\tv497 = v495 == 0;\n\tif (v497) goto L_0137;\n\tv485[0] = v251;\n\tgoto L_011F;\n\tv515 = *([v507 @ X0_v30+E0]);\n\tv516 = v515 == 0;\n\tv517 = ~v516;\n\tif (v517) goto L_011F;\n\tv519 = \"il2cpp_codegen_runtime_class_init\"(v507, v494, v326, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_011F:\n\tLunarConsolePluginInternal.Log::e(v256, \"Exception while resolving type for name '{0}'\", v485);\nL_012C:\n\treturn v277;\nL_012E:\n\tv476 = 0x6D1E60(8, *([v256 @ X20_v7 (System.Exception)]), v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t*([v476 @ X0_v16]) = *([v423 @ X0_v12]);\n\tv394 = 0x1E8A000 + 0x870;\n\tv352 = 0x6D2A00(v476, v394, 0, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_00D9;\n\tv496 = new System.NullReferenceException();\nL_0137:\n\tv502 = new System.ArrayTypeMismatchException();\n\tgoto L_013C;\n\tv511 = new System.IndexOutOfRangeException();\nL_013C:\n\tthrow v513;\nL_0140:\n\tv432 = 0x6D2380(v352, v394, v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturnVal2 = 0x846AA4(v432, v394, v375, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\treturn returnVal2;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type TypeForName(string typeName)
		{
			//IL_00b8: Expected I, but got O
			//IL_00c8: Expected O, but got I
			//IL_03fc: Expected O, but got I4
			//IL_0415: Expected I, but got O
			//IL_01e5: Expected I, but got O
			//IL_0200: Expected I, but got O
			Type result;
			string text2;
			Exception exception;
			if (typeName != null)
			{
				AppDomain currentDomain = AppDomain.CurrentDomain;
				Assembly[] assemblies = currentDomain.GetAssemblies();
				if (assemblies != null)
				{
					int num = assemblies.Length;
					if (assemblies.Length < 1)
					{
						goto IL_03cb;
					}
					int num2 = 0;
					string text = null;
					object obj = default(object);
					object obj2 = default(object);
					Type result2 = default(Type);
					while (true)
					{
						IntPtr intPtr2;
						if (num2 < num)
						{
							Assembly assembly = assemblies[num2];
							if ((object)assemblies[num2] != null)
							{
								IntPtr intPtr = (IntPtr)assembly;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v368 @ X8_v36 (Il2CppClass<System.Reflection.Assembly>)+228]");
								text = (string)0;
								Type[] types = assemblies[num2].GetTypes();
								if (types != null)
								{
									int num3 = types.Length;
									if (types.Length < 1)
									{
										goto IL_025d;
									}
									int num4 = 0;
									while (true)
									{
										if (num4 < num3)
										{
											if ((object)types[num4] == null)
											{
												break;
											}
											string fullName = types[num4].FullName;
											bool flag = fullName == typeName;
											bool flag2 = !flag;
											bool flag3 = !flag2;
											result = types[num4];
											if (flag3)
											{
												goto end_IL_049e;
											}
											num3 = types.Length;
											num4++;
											bool flag4 = num4 < types.Length;
											intPtr2 = (IntPtr)null;
											text = typeName;
											if (flag4)
											{
												continue;
											}
											goto IL_01fb;
										}
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										throw ex;
									}
									NullReferenceException ex2 = new NullReferenceException();
									text2 = typeName;
								}
								else
								{
									NullReferenceException ex2 = new NullReferenceException();
									text2 = typeName;
								}
							}
							else
							{
								NullReferenceException ex2 = new NullReferenceException();
								text2 = typeName;
							}
							while (true)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								if ((IntPtr)text == (IntPtr)1)
								{
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
									exception = (Exception)obj;
									Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
									if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
									{
										break;
									}
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
									object obj3 = obj;
									text = (string)(32022528 + 2160);
									Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
									intPtr2 = (IntPtr)null;
									continue;
								}
								Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
								return result2;
							}
							goto IL_0351;
						}
						IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
						throw ex3;
						IL_025d:
						num = assemblies.Length;
						num2++;
						if (num2 < assemblies.Length)
						{
							continue;
						}
						goto IL_03cb;
						IL_01fb:
						intPtr2 = (IntPtr)null;
						text = typeName;
						goto IL_025d;
						continue;
						end_IL_049e:
						break;
					}
					goto IL_0472;
				}
				throw new NullReferenceException();
			}
			ArgumentNullException ex4 = new ArgumentNullException("typeName");
			throw ex4;
			IL_0351:
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
			object[] array = new object[1];
			object obj4 = text2 as object;
			if (obj4 != null)
			{
				array[0] = text2;
				Log.e(exception, "Exception while resolving type for name '{0}'", array);
				goto IL_03cb;
			}
			ArrayTypeMismatchException ex5 = new ArrayTypeMismatchException();
			ArrayTypeMismatchException ex6 = default(ArrayTypeMismatchException);
			throw ex6;
			IL_0472:
			return result;
			IL_03cb:
			result = null;
			goto IL_0472;
		}
	}
}
