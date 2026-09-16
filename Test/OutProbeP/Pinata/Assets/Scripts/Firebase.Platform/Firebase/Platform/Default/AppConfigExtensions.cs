using System;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase.Platform.Default
{
	[Token(Token = "0x2000016")]
	internal class AppConfigExtensions : IAppConfigExtensions
	{
		[Token(Token = "0x4000034")]
		private static readonly Uri DefaultUpdateUrl;

		[Token(Token = "0x4000035")]
		private static readonly string Default;

		[Token(Token = "0x4000036")]
		private static readonly object Sync;

		[Token(Token = "0x4000037")]
		internal static AppConfigExtensions _instance;

		[Token(Token = "0x4000038")]
		private static readonly Dictionary<int, Dictionary<string, string>> SStringState;

		[Token(Token = "0x1700001C")]
		public static IAppConfigExtensions Instance
		{
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x15E58B8", Offset = "0x15E58B8", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB2CF0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F4E]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.Default.AppConfigExtensions>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.Default.AppConfigExtensions;\nL_0024:\n\treturn v49._instance;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _instance;
			}
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x15E58B0", Offset = "0x15E58B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AppConfigExtensions()
		{
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x15E5920", Offset = "0x15E5920", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1F07FA8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, app, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F4F]) = v35;\nL_001A:\n\treturn v41.Empty;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string GetWriteablePath(IFirebaseAppPlatform app)
		{
			return string.Empty;
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x15E5970", Offset = "0x15E5970", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC9400]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, app, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029F50]) = v38;\nL_0019:\n\tgoto L_002C;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.Default.AppConfigExtensions>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_002C;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v41, app, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = Firebase.Platform.Default.AppConfigExtensions;\nL_002C:\n\treturnVal1 = Firebase.Platform.Default.AppConfigExtensions::GetState(app, 5, v53.SStringState);\n\treturn returnVal1;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual string GetCertPemFile(IFirebaseAppPlatform app)
		{
			return GetState(app, 5, SStringState);
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xB888A0", Offset = "0xB888A0", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1EE30E8]);\n\tv33 = *([v32 @ X8_v51]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, state, store, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2022A04]) = v49;\nL_001C:\n\tv52 = app == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_007B;\n\tgoto L_002F;\n\tv122 = *([v56 @ X0_v55+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_002F;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v56, state, store, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_002F:\n\tgoto L_003A;\n\tv145 = *([1ED0FC8]);\n\tv146 = *([v145 @ X8_v46]);\n\tv147 = \"il2cpp_codegen_initialize_method\"(v146, state, store, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv150 = 0 | 1;\n\t*([2022B9C]) = v150;\nL_003A:\n\tgoto L_0042;\n\tv157 = *([v151 @ X0_v58 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tgoto L_0042;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v151, state, store, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv161 = Firebase.Platform.FirebaseHandler;\nL_0042:\n\tv115 = v164.<AppUtils>k__BackingField;\n\tv165 = v164.<AppUtils>k__BackingField == 0;\n\tif (v165) goto L_011B;\n\tv176 = *([v115 @ X22_v9 (Firebase.Platform.IFirebaseAppUtils)]);\n\tv109 = *([v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]) == 0;\n\tif (v109) goto L_0069;\n\tv371 = *([v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]) + 8;\nL_0054:\n\tv377 = *([v371 @ X11_v16-8]) == Firebase.Platform.IFirebaseAppUtils;\n\tif (v377) goto L_006C;\n\tv372 = v372 + 1;\n\tv406 = v372 < *([v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]);\n\tv323 = ~v406;\n\tv371 = v371 + 0x10;\n\tv307 = ~v323;\n\tif (v307) goto L_0054;\nL_0069:\n\tv412 = 0x8909C4(v164.<AppUtils>k__BackingField, Firebase.Platform.IFirebaseAppUtils, 2, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_0073;\nL_006C:\n\tv408 = *([v371 @ X11_v16]) + 2;\n\tv409 = v408 << 4;\n\tv410 = v176 + v409;\n\tv412 = v410 + 0x130;\nL_0073:\n\t*([v412 @ X0_v60])(v107, v164.<AppUtils>k__BackingField, *([v412 @ X0_v60+8]), v67, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_007B:\n\tgoto L_0086;\n\tv133 = *([v118 @ X0_v3 (Il2CppClass<Firebase.Platform.Default.AppConfigExtensions>)+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tgoto L_0086;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v118, v98, v66, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv137 = Firebase.Platform.Default.AppConfigExtensions;\nL_0086:\n\tSystem.Threading.Monitor::Enter(v140.Sync);\n\tgoto L_00B6;\n\tv229 = *([v167 @ X8_v9+B0]);\n\tv230 = 0;\n\tv231 = v229 + 8;\n\tv233 = *([v341 @ X11_v8-8]);\n\tv347 = v233 == v170;\n\tif (v347) goto L_00AF;\n\tv255 = v342 + 1;\n\tv392 = v255 < v169;\n\tv251 = ~v392;\n\tv253 = v341 + 0x10;\n\tv235 = ~v251;\n\tif (v235) goto L_FFFFFFFF;\n\tv256 = v110;\n\tv257 = 0;\n\tv258 = 0x8909C4(v256, v170, v257, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_00B6;\nL_00AF:\n\tv393 = *([v341 @ X11_v8]);\n\tv394 = v393 << 4;\n\tv395 = v167 + v394;\n\tv396 = v395 + 0x130;\nL_00B6:\n\tv402 = Firebase.Platform.IFirebaseAppPlatform::get_Name(v110);\n\tv405 = System.String::IsNullOrEmpty(v402);\n\tv430 = v405 == 0;\n\tif (v430) goto L_00D3;\n\tgoto L_00CA;\n\tv506 = *([v432 @ X0_v34 (Il2CppClass<Firebase.Platform.Default.AppConfigExtensions>)+E0]);\n\tv507 = v506 == 0;\n\tv508 = ~v507;\n\tif (v508) goto L_00CA;\n\tv522 = \"il2cpp_codegen_runtime_class_init\"(v432, v286, v264, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv509 = Firebase.Platform.Default.AppConfigExtensions;\nL_00CA:\n\tv296 = v440.Default;\nL_00D3:\n\tv518 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.Dictionary`2<System.String, T>>::TryGetValue(store, state, &v515 @ stack_-48_v3 (System.Collections.Generic.Dictionary`2<System.String, T>));\n\tv520 = v518 == 0;\n\tv521 = ~v520;\n\tif (v521) goto L_00F9;\n\tgoto L_00E2;\n\tv559 = v524;\n\tv560 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.Dictionary`2<System.String, T>>::TryGetValue(v559, v517, v514, v512);\nL_00E2:\n\tv563 = new Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, T>>();\n\tv572 = System.Collections.Generic.Dictionary`2<System.String, T>::.ctor(v563);\n\tv535 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.Dictionary`2<System.String, T>>::set_Item(store, state, v563);\nL_00F9:\n\tv567 = System.Collections.Generic.Dictionary`2<System.String, T>::TryGetValue(v563, v296, &v540 @ stack_-50_v2 (T));\n\tv546 = v567 == 0;\n\tv544 = ~v546;\n\tv539 = ~v544;\n\tif (v539) goto L_FFFFFFFF;\n\tgoto L_0109;\nL_0109:\n\tSystem.Threading.Monitor::Exit(v140.Sync);\nL_0114:\n\treturn v554;\n\tthrow System.NullReferenceException;\n\tv300 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_011B:\n\tv228 = new System.NullReferenceException();\n\tgoto L_012B;\n\tgoto L_012B;\n\tgoto L_012B;\n\tgoto L_012B;\n\tgoto L_012B;\n\tgoto L_012B;\nL_012B:\n\tv391 = v418 != 1;\n\tif (v391) goto L_013A;\n\tv415 = 0x6D2BC0(v228, v418, v416, v186, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv431 = 0x6D2490(v415, v418, v416, v186, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tSystem.Threading.Monitor::Exit(v226);\n\tv423 = *([v415 @ X0_v48]) == 0;\n\tif (v423) goto L_0114;\n\tv421 = new System.TypeLoadException();\nL_013A:\n\treturnVal1 = 0x6D2380(v228, 0, 0, v186, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\treturn returnVal1;\n// 187 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static T GetState<T>(IFirebaseAppPlatform app, int state, Dictionary<int, Dictionary<string, T>> store)
		{
			//IL_0017: Expected I, but got O
			//IL_00cf: Expected O, but got I4
			//IL_0052: Expected O, but got I
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00ff: Expected O, but got I
			//IL_010e: Expected O, but got I
			//IL_009e: Expected O, but got I
			bool flag = app == null;
			bool flag2 = !flag;
			IFirebaseAppPlatform firebaseAppPlatform = app;
			T result;
			object obj5;
			if (!flag2)
			{
				IFirebaseAppUtils _003CAppUtils_003Ek__BackingField = FirebaseHandler.AppUtils;
				if (FirebaseHandler.AppUtils != null)
				{
					IntPtr intPtr = (IntPtr)_003CAppUtils_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00b7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v371 @ X11_v16-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IFirebaseAppUtils))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X8_v40 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
						bool flag3 = (long)num2 < 0L;
						bool flag4 = !flag3;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag4)
						{
							continue;
						}
						goto IL_00b7;
					}
					object obj2 = obj + 2;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					object obj4 = (long)(IntPtr)obj3 + 304L;
					obj5 = store;
					goto IL_0317;
				}
				NullReferenceException ex = new NullReferenceException();
				int num4 = default(int);
				if (num4 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
					object obj6 = default(object);
					Monitor.Exit(obj6);
					object obj7 = default(object);
					bool flag5 = obj7 == null;
					result = (T)null;
					if (flag5)
					{
						goto IL_01e6;
					}
					TypeLoadException ex2 = new TypeLoadException();
					ex = (NullReferenceException)(object)ex2;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
				T result2 = default(T);
				return result2;
			}
			goto IL_032e;
			IL_00b7:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			obj5 = 2;
			goto IL_0317;
			IL_01e6:
			return result;
			IL_0317:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v412 @ X0_v60] (should have been resolved before IL gen)");
			IFirebaseAppPlatform firebaseAppPlatform2 = default(IFirebaseAppPlatform);
			firebaseAppPlatform = firebaseAppPlatform2;
			goto IL_032e;
			IL_032e:
			Monitor.Enter(Sync);
			string name = firebaseAppPlatform.Name;
			bool flag6 = string.IsNullOrEmpty(name);
			bool flag7 = !flag6;
			string key = name;
			if (!flag7)
			{
				key = Default;
			}
			Dictionary<string, T> dictionary = default(Dictionary<string, T>);
			if (!store.TryGetValue(state, out var _))
			{
				dictionary = new Dictionary<string, T>();
				store.set_Item(state, dictionary);
			}
			result = ((!dictionary.TryGetValue(key, out var value2)) ? ((T)null) : value2);
			Monitor.Exit(Sync);
			goto IL_01e6;
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x15E59F0", Offset = "0x15E59F0", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB0138]);\n\tv17 = *([v16 @ X8_v23]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F51]) = v37;\nL_0015:\n\tv41 = new System.Uri();\n\tSystem.Uri::.ctor(v41, \"https://www.gstatic.com/firebase/ssl/roots.pem\");\n\tv51.DefaultUpdateUrl = v41;\n\tv54.Default = \"DEFAULT\";\n\tv59 = new System.Object();\n\tSystem.Object::.ctor(v59);\n\tv63.Sync = v59;\n\tv64 = new Firebase.Platform.Default.AppConfigExtensions();\n\tSystem.Object::.ctor(v64);\n\tv68._instance = v64;\n\tv72 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v72);\n\tv78.SStringState = v72;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AppConfigExtensions()
		{
			Uri defaultUpdateUrl = new Uri("https://www.gstatic.com/firebase/ssl/roots.pem");
			DefaultUpdateUrl = defaultUpdateUrl;
			Default = "DEFAULT";
			object sync = new object();
			Sync = sync;
			AppConfigExtensions instance = new AppConfigExtensions();
			_instance = instance;
			Dictionary<int, Dictionary<string, string>> sStringState = new Dictionary<int, Dictionary<string, string>>();
			SStringState = sStringState;
		}
	}
}
