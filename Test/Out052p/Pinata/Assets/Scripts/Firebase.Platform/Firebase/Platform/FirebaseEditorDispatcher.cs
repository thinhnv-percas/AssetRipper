using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform
{
	[Token(Token = "0x2000003")]
	internal sealed class FirebaseEditorDispatcher
	{
		[CompilerGenerated]
		[Token(Token = "0x4000008")]
		private static Action _003C_003Ef__mg_0024cache0;

		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		private static Action _003C_003Ef__mg_0024cache1;

		[CompilerGenerated]
		[Token(Token = "0x400000A")]
		private static Action _003C_003Ef__mg_0024cache2;

		[Token(Token = "0x17000003")]
		private static Type EditorApplicationType
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x15E5FD4", Offset = "0x15E5FD4", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA9C20]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F5C]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv52 = 0x1841000 + 0xE3A;\n\tv55 = 0x8D83FC(\"UnityEditor.EditorApplication, UnityEditor\", v52, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\treturnVal1 = System.Type::GetType(v55);\n\tv57 = returnVal1 == 0;\n\tif (v57) goto L_0031;\n\treturn returnVal1;\nL_0031:\n\treturnVal2 = System.Type::GetType(\"UnityEditor.EditorApplication, UnityEditor\");\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = 25432064 + 3642;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D83FC");
				string typeName = default(string);
				Type type = Type.GetType(typeName);
				if ((object)type != null)
				{
					return type;
				}
				return Type.GetType("UnityEditor.EditorApplication, UnityEditor");
			}
		}

		[Token(Token = "0x17000004")]
		public static bool EditorIsPlaying
		{
			[Token(Token = "0x6000011")]
			[Address(RVA = "0x15E6064", Offset = "0x15E6064", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EA8F18]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F5D]) = v35;\nL_0011:\n\tv36 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorApplicationType();\n\tv37 = v36 == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv42 = System.Type::GetProperty(v36, \"isPlaying\");\n\tv47 = v42 == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv95 = *([v42 @ X0_v6 (System.Reflection.PropertyInfo)]);\n\tv98 = System.Reflection.PropertyInfo::GetValue(v42, 0, 0);\n\tv144 = ~v144_asT;\n\tif (v144) goto L_0049;\n\tv146 = \"il2cpp_vm_object_unbox\"(v98, System.Boolean, 0, *([v95 @ X8_v7 (Il2CppClass<System.Reflection.PropertyInfo>)+2C8]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv67 = *([v146 @ X0_v11]) == 0;\n\tv52 = ~v67;\n\tgoto L_0047;\nL_0047:\n\treturn returnVal1;\n\tv145 = new System.NullReferenceException();\nL_0049:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003c: Expected I, but got O
				//IL_005d: Expected I4, but got O
				//IL_00c3: Expected I4, but got O
				Type editorApplicationType = EditorApplicationType;
				if ((object)editorApplicationType != null)
				{
					PropertyInfo property = editorApplicationType.GetProperty("isPlaying");
					if ((object)property != null)
					{
						IntPtr intPtr = (IntPtr)property;
						object value = property.GetValue(null, null);
						if ((int)((value is bool) ? value : null) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							bool flag = obj == null;
							return !flag;
						}
						InvalidCastException ex = new InvalidCastException();
						return (byte)(int)ex != 0;
					}
				}
				return true;
			}
		}

		[Token(Token = "0x17000005")]
		public static bool EditorIsPlayingOrWillChangePlaymode
		{
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x15E611C", Offset = "0x15E611C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1EB03B0]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F5E]) = v35;\nL_0011:\n\tv36 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorApplicationType();\n\tv37 = v36 == 0;\n\tif (v37) goto L_FFFFFFFF;\n\tv42 = System.Type::GetProperty(v36, \"isPlayingOrWillChangePlaymode\");\n\tv47 = v42 == 0;\n\tif (v47) goto L_FFFFFFFF;\n\tv95 = *([v42 @ X0_v6 (System.Reflection.PropertyInfo)]);\n\tv98 = System.Reflection.PropertyInfo::GetValue(v42, 0, 0);\n\tv144 = ~v144_asT;\n\tif (v144) goto L_0049;\n\tv146 = \"il2cpp_vm_object_unbox\"(v98, System.Boolean, 0, *([v95 @ X8_v7 (Il2CppClass<System.Reflection.PropertyInfo>)+2C8]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv67 = *([v146 @ X0_v11]) == 0;\n\tv52 = ~v67;\n\tgoto L_0047;\nL_0047:\n\treturn returnVal1;\n\tv145 = new System.NullReferenceException();\nL_0049:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_003c: Expected I, but got O
				//IL_005d: Expected I4, but got O
				//IL_00c3: Expected I4, but got O
				Type editorApplicationType = EditorApplicationType;
				if ((object)editorApplicationType != null)
				{
					PropertyInfo property = editorApplicationType.GetProperty("isPlayingOrWillChangePlaymode");
					if ((object)property != null)
					{
						IntPtr intPtr = (IntPtr)property;
						object value = property.GetValue(null, null);
						if ((int)((value is bool) ? value : null) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
							object obj = default(object);
							bool flag = obj == null;
							return !flag;
						}
						InvalidCastException ex = new InvalidCastException();
						return (byte)(int)ex != 0;
					}
				}
				return true;
			}
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x15E61D4", Offset = "0x15E61D4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE8788]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F5F]) = v39;\nL_0013:\n\tv40 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorApplicationType();\n\tv41 = v40 == 0;\n\tif (v41) goto L_0049;\n\tv46 = System.Type::GetField(v40, \"update\");\n\tv71 = v56.<>f__mg$cache0;\n\tv58 = v56.<>f__mg$cache0 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0041;\n\tv86 = new System.Action();\n\tSystem.Action::.ctor(v86, 0, Il2CppMethodInfo);\n\tv102.<>f__mg$cache0 = v86;\n\tv71 = v96.<>f__mg$cache0;\nL_0041:\n\tFirebase.Platform.FirebaseEditorDispatcher::AddRemoveCallbackToField(v46, v71, 0, 1, \"Firebase failed to register for editor update calls. Most Firebase features will fail, as callbacks will notwork properly. This is caused by being unable to resolvethe necessary fields from the UnityEditor.dll.\");\n\treturn;\nL_0049:\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StartEditorUpdate()
		{
			Type editorApplicationType = EditorApplicationType;
			if ((object)editorApplicationType != null)
			{
				FieldInfo field = editorApplicationType.GetField("update");
				Action callback = _003C_003Ef__mg_0024cache0;
				if (_003C_003Ef__mg_0024cache0 == null)
				{
					Action action = Update;
					_003C_003Ef__mg_0024cache0 = action;
					callback = _003C_003Ef__mg_0024cache0;
				}
				AddRemoveCallbackToField(field, callback, null, add: true, "Firebase failed to register for editor update calls. Most Firebase features will fail, as callbacks will notwork properly. This is caused by being unable to resolvethe necessary fields from the UnityEditor.dll.");
			}
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x15E649C", Offset = "0x15E649C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBF8E0]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F60]) = v39;\nL_0013:\n\tv40 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorApplicationType();\n\tv41 = v40 == 0;\n\tif (v41) goto L_0046;\n\tv46 = System.Type::GetField(v40, \"update\");\n\tv74 = v56.<>f__mg$cache1;\n\tv58 = v56.<>f__mg$cache1 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_003E;\n\tv89 = new System.Action();\n\tSystem.Action::.ctor(v89, 0, Il2CppMethodInfo);\n\tv90.<>f__mg$cache1 = v89;\n\tv74 = v99.<>f__mg$cache1;\nL_003E:\n\tFirebase.Platform.FirebaseEditorDispatcher::AddRemoveCallbackToField(v46, v74, 0, 0, 0);\n\treturn;\nL_0046:\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void StopEditorUpdate()
		{
			Type editorApplicationType = EditorApplicationType;
			if ((object)editorApplicationType != null)
			{
				FieldInfo field = editorApplicationType.GetField("update");
				Action callback = _003C_003Ef__mg_0024cache1;
				if (_003C_003Ef__mg_0024cache1 == null)
				{
					Action action = Update;
					_003C_003Ef__mg_0024cache1 = action;
					callback = _003C_003Ef__mg_0024cache1;
				}
				AddRemoveCallbackToField(field, callback, null, add: false);
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x15E6578", Offset = "0x15E6578", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE81F8]);\n\tv17 = *([v16 @ X8_v16]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F61]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EBC788]);\n\tv57 = *([v56 @ X8_v12]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2029FBF]) = v61;\nL_002D:\n\tgoto L_003D;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\t// 49 Jump @b19\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Firebase.Platform.FirebaseHandler;\nL_003D:\n\tFirebase.Platform.FirebaseHandler::Update(v73.firebaseHandler);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Update()
		{
			FirebaseHandler.firebaseHandler.Update();
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x15E680C", Offset = "0x15E680C", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB6B50]);\n\tv27 = *([v26 @ X8_v42]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2029F62]) = v46;\nL_0017:\n\tv47 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorApplicationType();\n\tv49 = v47 == 0;\n\tif (v49) goto L_0090;\n\tv55 = System.Type::GetEvent(v47, \"playModeStateChanged\");\n\tv65 = v55 == 0;\n\tif (v65) goto L_0096;\n\tgoto L_0033;\n\tv150 = *([v127 @ X0_v12+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0033;\n\tv154 = \"il2cpp_codegen_runtime_class_init\"(v127, v54, v53, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0033:\n\tv137 = 0x1841000 + 0xE3A;\n\tv160 = 0x8D83FC(\"UnityEditor.PlayModeStateChange, UnityEditor\", v137, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv168 = System.Type::GetType(v160);\n\tv184 = v168 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0048;\n\tv139 = System.Type::GetType(\"UnityEditor.PlayModeStateChange, UnityEditor\");\n\tv141 = v139 == 0;\n\tif (v141) goto L_0096;\nL_0048:\n\tgoto L_0050;\n\tv199 = *([v193 @ X0_v18+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0050;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v193, v137, v53, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0050:\n\tv208 = System.Type::GetTypeFromHandle(Firebase.Platform.FirebaseEditorDispatcher);\n\tv215 = System.Type::GetMethod(v208, \"PlayModeStateChangedWithArg\", 0x28);\n\t// 95 NewArr v225 @ X0_v33 (System.Type[]), typeof(System.Type[]), 1\n\t// 102 IsInst v241 @ X0_v35, typeof(System.Type), v84 @ X21_v7 (System.Type)\n\tv243 = v241 == 0;\n\tif (v243) goto L_00CE;\n\tv225[0] = v84;\n\tv270 = System.Reflection.MethodInfo::MakeGenericMethod(v215, v225);\n\tv275 = System.Reflection.EventInfo::get_EventHandlerType(v55);\n\tv279 = System.Delegate::CreateDelegate(v275, 0, v270);\n\tv118 = *([v55 @ X0_v4 (System.Reflection.EventInfo)]);\n\tv111 = v44 == 0;\n\tif (v111) goto L_00BF;\n\tv71 = *([v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+240]);\n\tv74 = *([v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+248]);\n\tgoto L_00CC;\nL_0090:\n\treturn;\nL_0096:\n\tv149 = System.Type::GetField(v47, \"playmodeStateChanged\");\n\tv94 = v165.<>f__mg$cache2;\n\tv167 = v165.<>f__mg$cache2 == 0;\n\tv110 = ~v167;\n\tif (v110) goto L_00BD;\n\tv172 = new System.Action();\n\tSystem.Action::.ctor(v172, 0, Il2CppMethodInfo);\n\tv175.<>f__mg$cache2 = v172;\n\tv94 = v182.<>f__mg$cache2;\nL_00BD:\n\tFirebase.Platform.FirebaseEditorDispatcher::AddRemoveCallbackToField(v149, v94, 0, v44, 0);\n\treturn;\nL_00BF:\n\tv71 = *([v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+2A0]);\n\tv74 = *([v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+2A8]);\nL_00CC:\n\t// 204 IndirectJump v71 @ X4_v2, v55 @ X0_v4 (System.Reflection.EventInfo), v55 @ X0_v4 (System.Reflection.EventInfo), 0, v279 @ X0_v41 (System.Delegate), v74 @ X3_v10, v71 @ X4_v2, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tv230 = new System.NullReferenceException();\nL_00CE:\n\tv246 = new System.ArrayTypeMismatchException();\n\tgoto L_00D3;\n\tv254 = new System.IndexOutOfRangeException();\nL_00D3:\n\tthrow v253;\n\tthrow System.NullReferenceException;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ListenToPlayState(bool start = true)
		{
			//IL_0182: Expected I, but got O
			//IL_0246: Expected O, but got I
			//IL_0256: Expected O, but got I
			//IL_01af: Expected O, but got I
			//IL_01bf: Expected O, but got I
			Type editorApplicationType = EditorApplicationType;
			if ((object)editorApplicationType == null)
			{
				return;
			}
			EventInfo eventInfo = editorApplicationType.GetEvent("playModeStateChanged");
			if ((object)eventInfo == null)
			{
				goto IL_01c5;
			}
			int num = 25432064 + 3642;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D83FC");
			string typeName = default(string);
			Type type = Type.GetType(typeName);
			bool flag = (object)type == null;
			bool flag2 = !flag;
			Type type2 = type;
			if (!flag2)
			{
				Type type3 = Type.GetType("UnityEditor.PlayModeStateChange, UnityEditor");
				bool flag3 = (object)type3 == null;
				type2 = type3;
				if (flag3)
				{
					goto IL_01c5;
				}
			}
			Type typeFromHandle = typeof(FirebaseEditorDispatcher);
			MethodInfo method = typeFromHandle.GetMethod("PlayModeStateChangedWithArg", BindingFlags.Static | BindingFlags.NonPublic);
			Type[] array = new Type[1];
			object obj = type2 as Type;
			bool flag4 = default(bool);
			if (obj != null)
			{
				array[0] = type2;
				MethodInfo method2 = method.MakeGenericMethod(array);
				Type eventHandlerType = eventInfo.EventHandlerType;
				Delegate obj2 = Delegate.CreateDelegate(eventHandlerType, null, method2);
				IntPtr intPtr = (IntPtr)eventInfo;
				if (flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+240]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+248]");
					object obj4 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+2A0]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v37 (Il2CppClass<System.Reflection.EventInfo>)+2A8]");
					object obj4 = 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ X4_v2 (should have been resolved before IL gen)");
				goto IL_029e;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
			throw ex2;
			IL_029e:
			FieldInfo field = default(FieldInfo);
			Action callback = default(Action);
			AddRemoveCallbackToField(field, callback, null, flag4);
			return;
			IL_01c5:
			field = editorApplicationType.GetField("playmodeStateChanged");
			callback = _003C_003Ef__mg_0024cache2;
			if (_003C_003Ef__mg_0024cache2 == null)
			{
				Action action = PlayModeStateChanged;
				_003C_003Ef__mg_0024cache2 = action;
				callback = _003C_003Ef__mg_0024cache2;
			}
			goto IL_029e;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15E6AAC", Offset = "0x15E6AAC", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EE8860]);\n\tv17 = *([v16 @ X8_v81]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F63]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EBC788]);\n\tv57 = *([v56 @ X8_v77]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2029FBF]) = v61;\nL_002D:\n\tgoto L_0035;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0035;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Firebase.Platform.FirebaseHandler;\nL_0035:\n\tv74 = v73.firebaseHandler;\n\tv78 = ~v74.<IsPlayMode>k__BackingField;\n\tv79 = ~v78;\n\tif (v79) goto L_0085;\n\tv96 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorIsPlaying();\n\tv100 = v96 == 0;\n\tif (v100) goto L_0085;\n\tFirebase.Platform.FirebaseEditorDispatcher::StopEditorUpdate();\n\tgoto L_004E;\n\tv161 = *([v150 @ X0_v42+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_004E;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v150, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_004E:\n\tgoto L_0059;\n\tv175 = *([1EBC788]);\n\tv176 = *([v175 @ X8_v71]);\n\tv177 = \"il2cpp_codegen_initialize_method\"(v176, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv180 = 0 | 1;\n\t*([2029FBF]) = v180;\nL_0059:\n\tgoto L_0064;\n\tv188 = *([v181 @ X0_v45 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv189 = v188 == 0;\n\tv190 = ~v189;\n\t// 93 Jump @b71\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v181, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv192 = Firebase.Platform.FirebaseHandler;\nL_0064:\n\tFirebase.Platform.FirebaseHandler::StartMonoBehaviour(v109.firebaseHandler);\n\tgoto L_0073;\n\tv216 = *([1EBC788]);\n\tv217 = *([v216 @ X8_v67]);\n\tv218 = \"il2cpp_codegen_initialize_method\"(v217, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv221 = 0 | 1;\n\t*([2029FBF]) = v221;\nL_0073:\n\tgoto L_007B;\n\tv237 = *([v222 @ X0_v49 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tgoto L_007B;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v222, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv240 = Firebase.Platform.FirebaseHandler;\nL_007B:\n\tv91 = v243.firebaseHandler;\n\tv91.<IsPlayMode>k__BackingField = 1;\n\tgoto L_00F0;\nL_0085:\n\tgoto L_008E;\n\tv112 = *([v97 @ X0_v12+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tgoto L_008E;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v97, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_008E:\n\tgoto L_0099;\n\tv123 = *([1EBC788]);\n\tv124 = *([v123 @ X8_v49]);\n\tv125 = \"il2cpp_codegen_initialize_method\"(v124, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv128 = 0 | 1;\n\t*([2029FBF]) = v128;\nL_0099:\n\tgoto L_00A1;\n\tv154 = *([v129 @ X0_v15 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tgoto L_00A1;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v129, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv157 = Firebase.Platform.FirebaseHandler;\nL_00A1:\n\tv92 = v160.firebaseHandler;\n\tv173 = ~v92.<IsPlayMode>k__BackingField;\n\tif (v173) goto L_00F0;\n\tv185 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorIsPlayingOrWillChangePlaymode();\n\tv196 = v185 == 0;\n\tv187 = ~v196;\n\tif (v187) goto L_00F0;\n\tgoto L_00B9;\n\tv205 = *([v198 @ X0_v18+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_00B9;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v198, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_00B9:\n\tgoto L_00C4;\n\tv227 = *([1EBC788]);\n\tv228 = *([v227 @ X8_v44]);\n\tv229 = \"il2cpp_codegen_initialize_method\"(v228, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv232 = 0 | 1;\n\t*([2029FBF]) = v232;\nL_00C4:\n\tgoto L_00CF;\n\tv244 = *([v233 @ X0_v21 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\t// 200 Jump @b78\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v233, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv247 = Firebase.Platform.FirebaseHandler;\nL_00CF:\n\tFirebase.Platform.FirebaseHandler::StopMonoBehaviour(Firebase.Platform.FirebaseHandler);\n\tFirebase.Platform.FirebaseEditorDispatcher::StartEditorUpdate();\n\tgoto L_00DF;\n\tv257 = *([1EBC788]);\n\tv258 = *([v257 @ X8_v40]);\n\tv259 = \"il2cpp_codegen_initialize_method\"(v258, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv262 = 0 | 1;\n\t*([2029FBF]) = v262;\nL_00DF:\n\tgoto L_00E7;\n\tv267 = *([v263 @ X0_v24 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tgoto L_00E7;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v263, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv270 = Firebase.Platform.FirebaseHandler;\nL_00E7:\n\tv94 = v273.firebaseHandler;\n\tv94.<IsPlayMode>k__BackingField = 0;\nL_00F0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PlayModeStateChanged()
		{
			FirebaseHandler firebaseHandler = FirebaseHandler.firebaseHandler;
			if (!firebaseHandler.IsPlayMode && EditorIsPlaying)
			{
				StopEditorUpdate();
				FirebaseHandler.firebaseHandler.StartMonoBehaviour();
				FirebaseHandler firebaseHandler2 = FirebaseHandler.firebaseHandler;
				firebaseHandler2.IsPlayMode = true;
				return;
			}
			FirebaseHandler firebaseHandler3 = FirebaseHandler.firebaseHandler;
			if (firebaseHandler3.IsPlayMode && !EditorIsPlayingOrWillChangePlaymode)
			{
				((FirebaseHandler)(object)typeof(FirebaseHandler)).StopMonoBehaviour();
				StartEditorUpdate();
				FirebaseHandler firebaseHandler4 = FirebaseHandler.firebaseHandler;
				firebaseHandler4.IsPlayMode = false;
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0xBB3D64", Offset = "0xBB3D64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFirebase.Platform.FirebaseEditorDispatcher::PlayModeStateChanged();\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void PlayModeStateChangedWithArg<T>(T t)
		{
			PlayModeStateChanged();
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x15E62BC", Offset = "0x15E62BC", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1ECB248]);\n\tv35 = *([v34 @ X8_v23]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, callback, target, add, errorMessage, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2029F64]) = v50;\nL_001B:\n\tv51 = eventField == 0;\n\tif (v51) goto L_008F;\n\tv57 = System.Reflection.FieldInfo::GetValue(eventField, 0);\n\tv58 = v57 == 0;\n\tif (v58) goto L_0037;\n\tgoto L_FFFFFFFF;\nL_0037:\n\tv139 = add == 0;\n\tif (v139) goto L_0068;\nL_003D:\n\tv178 = System.Reflection.FieldInfo::get_FieldType(eventField);\n\tv200 = System.Delegate::get_Method(callback);\n\tv306 = System.Delegate::CreateDelegate(v178, target, v200);\n\tv311 = v172 == 0;\n\tif (v311) goto L_008B;\n\tv340 = System.Delegate::Combine(v172, v306);\n\tgoto L_FFFFFFFF;\n\tv155 = v155_asT == 0;\n\tif (v155) goto L_FFFFFFFF;\n\tgoto L_0065;\nL_0065:\n\tv301 = add == 0;\n\tv170 = ~v301;\n\tif (v170) goto L_003D;\nL_0068:\n\tv102 = v106 == 0;\n\tif (v102) goto L_008F;\n\tv218 = System.Reflection.FieldInfo::get_FieldType(eventField);\n\tv309 = System.Delegate::get_Method(callback);\n\tv316 = System.Delegate::CreateDelegate(v218, target, v309);\n\tv340 = System.Delegate::Remove(v106, v316);\nL_008B:\n\tSystem.Reflection.FieldInfo::SetValue(eventField, 0, v259);\n\treturn;\nL_008F:\n\tv109 = System.String::IsNullOrEmpty(errorMessage);\n\tv141 = v109 == 0;\n\tif (v141) goto L_00A3;\n\treturn;\nL_00A3:\n\tgoto L_00B4;\n\tv295 = *([v192 @ X0_v5+E0]);\n\tv296 = v295 == 0;\n\tv297 = ~v296;\n\tif (v297) goto L_00B4;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v192, v108, v95, add, errorMessage, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00B4:\n\tFirebase.Platform.FirebaseLogger::LogMessage(4, errorMessage);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddRemoveCallbackToField(FieldInfo eventField, Action callback, object target = null, bool add = true, string errorMessage = null)
		{
			Delegate obj;
			Delegate obj5;
			if ((object)eventField != null)
			{
				object value = eventField.GetValue(null);
				Delegate obj2;
				if (value == null)
				{
					bool flag = !add;
					obj = null;
					obj2 = null;
					if (!flag)
					{
						goto IL_005e;
					}
				}
				else
				{
					Delegate obj3 = value as Delegate;
					object obj4 = (((object)obj3 == null) ? null : value);
					bool flag2 = !add;
					bool flag3 = !flag2;
					obj = (Delegate)obj4;
					obj2 = (Delegate)obj4;
					if (flag3)
					{
						goto IL_005e;
					}
				}
				if (obj2 != null)
				{
					Type fieldType = eventField.FieldType;
					MethodInfo method = callback.Method;
					Delegate value2 = Delegate.CreateDelegate(fieldType, target, method);
					obj5 = Delegate.Remove(obj2, value2);
					goto IL_017f;
				}
			}
			if (!string.IsNullOrEmpty(errorMessage))
			{
				FirebaseLogger.LogMessage(PlatformLogLevel.Error, errorMessage);
			}
			return;
			IL_01e9:
			Delegate value3;
			eventField.SetValue(null, value3);
			return;
			IL_017f:
			value3 = obj5;
			goto IL_01e9;
			IL_005e:
			Type fieldType2 = eventField.FieldType;
			MethodInfo method2 = callback.Method;
			Delegate obj6 = Delegate.CreateDelegate(fieldType2, target, method2);
			bool flag4 = (object)obj == null;
			value3 = obj6;
			if (!flag4)
			{
				obj5 = Delegate.Combine(obj, obj6);
				goto IL_017f;
			}
			goto IL_01e9;
		}
	}
}
