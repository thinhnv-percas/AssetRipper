using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AssetRipperInjected;
using Cpp2ILInjected;
using Firebase.Unity;
using UnityEngine;

namespace Firebase.Platform
{
	[Token(Token = "0x2000004")]
	public sealed class FirebaseHandler
	{
		[Token(Token = "0x2000005")]
		internal class ApplicationFocusChangedEventArgs : EventArgs
		{
			[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B374", Offset = "0x72B374")]
			[CompilerGenerated]
			[Token(Token = "0x4000014")]
			[FieldOffset(Offset = "0x10")]
			internal bool _003CHasFocus_003Ek__BackingField;

			[Token(Token = "0x1700000B")]
			public bool HasFocus
			{
				[CompilerGenerated]
				[Token(Token = "0x6000030")]
				[Address(RVA = "0x15E7F40", Offset = "0x15E7F40", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<HasFocus>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					_003CHasFocus_003Ek__BackingField = value;
				}
			}

			[Token(Token = "0x600002F")]
			[Address(RVA = "0x15E799C", Offset = "0x15E799C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F06288]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F76]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ApplicationFocusChangedEventArgs()
			{
			}
		}

		[Token(Token = "0x400000B")]
		private static FirebaseMonoBehaviour firebaseMonoBehaviour;

		[Token(Token = "0x400000D")]
		internal static int tickCount;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B328", Offset = "0x72B328")]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x10")]
		internal bool _003CIsPlayMode_003Ek__BackingField;

		[Token(Token = "0x4000010")]
		internal static FirebaseHandler firebaseHandler;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<EventArgs> Updated;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<ApplicationFocusChangedEventArgs> ApplicationFocusChanged;

		[CompilerGenerated]
		[Token(Token = "0x4000013")]
		private static Func<bool> _003C_003Ef__am_0024cache0;

		[Token(Token = "0x17000006")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B2B0", Offset = "0x72B2B0")]
		[field: Token(Token = "0x400000C")]
		public static IFirebaseAppUtils AppUtils
		{
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x15E7158", Offset = "0x15E7158", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0F168]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F66]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseHandler;\nL_0024:\n\treturn v49.<AppUtils>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x15E71C0", Offset = "0x15E71C0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECF358]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F67]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.FirebaseHandler;\nL_0021:\n\tv52.<AppUtils>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x17000007")]
		public static int TickCount
		{
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x15E722C", Offset = "0x15E722C", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA3FC0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F68]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseHandler;\nL_0024:\n\treturn v49.tickCount;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return tickCount;
			}
		}

		[Token(Token = "0x17000008")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72B2EC", Offset = "0x72B2EC")]
		[field: Token(Token = "0x400000E")]
		private static Dispatcher ThreadDispatcher
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x15E7294", Offset = "0x15E7294", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEBEA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F69]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseHandler;\nL_0024:\n\treturn v49.<ThreadDispatcher>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x15E72FC", Offset = "0x15E72FC", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBC8C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F6A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Firebase.Platform.FirebaseHandler;\nL_0021:\n\tv52.<ThreadDispatcher>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set;
		}

		[Token(Token = "0x17000009")]
		public bool IsPlayMode
		{
			[CompilerGenerated]
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x15E7368", Offset = "0x15E7368", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IsPlayMode>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsPlayMode;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x15E7370", Offset = "0x15E7370", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IsPlayMode>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CIsPlayMode_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700000A")]
		internal static FirebaseHandler DefaultInstance
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x15E7428", Offset = "0x15E7428", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F10C30]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029F6D]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Firebase.Platform.FirebaseHandler;\nL_0024:\n\treturn v49.firebaseHandler;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return firebaseHandler;
			}
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x15E7000", Offset = "0x15E7000", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF1190]);\n\tv17 = *([v16 @ X8_v24]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F65]) = v37;\nL_0018:\n\tgoto L_0022;\n\tv44 = *([v40 @ X0_v2+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0022;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0022:\n\tgoto L_002D;\n\tv56 = *([1EFF588]);\n\tv57 = *([v56 @ X8_v20]);\n\tv58 = \"il2cpp_codegen_initialize_method\"(v57, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv61 = 0 | 1;\n\t*([2029FC0]) = v61;\nL_002D:\n\tgoto L_003A;\n\tv66 = *([v62 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseAppUtilsStub>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_003A;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v62, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv70 = Firebase.Platform.FirebaseAppUtilsStub;\nL_003A:\n\tgoto L_0047;\n\tv81 = *([1EDAB38]);\n\tv82 = *([v81 @ X8_v16]);\n\tv83 = \"il2cpp_codegen_initialize_method\"(v82, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv86 = 0 | 1;\n\t*([2029FC1]) = v86;\nL_0047:\n\tgoto L_004F;\n\tv93 = *([v89 @ X0_v8 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tgoto L_004F;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v89, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv97 = Firebase.Platform.FirebaseHandler;\nL_004F:\n\tv100.<AppUtils>k__BackingField = v73._instance;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FirebaseHandler()
		{
			AppUtils = FirebaseAppUtilsStub._instance;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x15E70F4", Offset = "0x15E70F4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv12 = UnityEngine.Application::get_isEditor();\n\tv14 = v12 == 0;\n\tif (v14) goto L_001D;\n\tv15 = Firebase.Platform.FirebaseEditorDispatcher::get_EditorIsPlaying();\n\tthis.<IsPlayMode>k__BackingField = v15;\n\tFirebase.Platform.FirebaseEditorDispatcher::ListenToPlayState(1);\n\tv28 = ~this.<IsPlayMode>k__BackingField;\n\tv22 = ~v28;\n\tif (v22) goto L_0023;\n\tFirebase.Platform.FirebaseEditorDispatcher::StartEditorUpdate();\n\treturn;\nL_001D:\n\tthis.<IsPlayMode>k__BackingField = 1;\nL_0023:\n\tFirebase.Platform.FirebaseHandler::StartMonoBehaviour(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private FirebaseHandler()
		{
			if (Application.isEditor)
			{
				bool editorIsPlaying = FirebaseEditorDispatcher.EditorIsPlaying;
				IsPlayMode = editorIsPlaying;
				FirebaseEditorDispatcher.ListenToPlayState();
				if (!IsPlayMode)
				{
					FirebaseEditorDispatcher.StartEditorUpdate();
					return;
				}
			}
			else
			{
				IsPlayMode = true;
			}
			StartMonoBehaviour();
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x15E6D4C", Offset = "0x15E6D4C", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF25B0]);\n\tv21 = *([v20 @ X8_v33]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F6B]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Firebase.Platform.FirebaseHandler;\nL_0023:\n\tv56 = v54.firebaseHandler == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0035;\n\tgoto L_0031;\n\tv74 = *([v50 @ X0_v3 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0031;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv85 = Firebase.Platform.FirebaseHandler;\n\tv78 = *([v85 @ X8_v29+B8]);\nL_0031:\n\tv69.firebaseHandler = this;\nL_0035:\n\tv73 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v73, \"Firebase Services\");\n\tv90 = UnityEngine.GameObject::AddComponent(v73);\n\tgoto L_0051;\n\tv98 = *([v93 @ X8_v13 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_0051;\n\tv133 = v93;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v133, v89, v81, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv106 = Firebase.Platform.FirebaseHandler;\nL_0051:\n\tv107.firebaseMonoBehaviour = v90;\n\tgoto L_005F;\n\tv134 = *([v110 @ X0_v12+E0]);\n\tv135 = v134 == 0;\n\tv136 = ~v135;\n\tgoto L_005F;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v110, v89, v81, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_005F:\n\tFirebase.Unity.UnitySynchronizationContext::Create(v73);\n\tgoto L_0074;\n\tv148 = *([v144 @ X0_v15+E0]);\n\tv149 = v148 == 0;\n\tv150 = ~v149;\n\tif (v150) goto L_0074;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v144, v89, v81, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0074:\n\tUnityEngine.Object::DontDestroyOnLoad(v73);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void StartMonoBehaviour()
		{
			if (firebaseHandler == null)
			{
				firebaseHandler = this;
			}
			GameObject gameObject = new GameObject("Firebase Services");
			FirebaseMonoBehaviour firebaseMonoBehaviour = gameObject.AddComponent<FirebaseMonoBehaviour>();
			FirebaseHandler.firebaseMonoBehaviour = firebaseMonoBehaviour;
			UnitySynchronizationContext.Create(gameObject);
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15E6EA8", Offset = "0x15E6EA8", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EF3DC8]);\n\tv17 = *([v16 @ X8_v29]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029F6C]) = v37;\nL_0018:\n\tgoto L_0027;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = Firebase.Platform.FirebaseHandler;\nL_0027:\n\tgoto L_0031;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv71 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Inequality(v53.firebaseMonoBehaviour, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_007A;\n\tgoto L_0042;\n\tv82 = *([v74 @ X0_v7 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0042;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v74, v68, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv86 = Firebase.Platform.FirebaseHandler;\nL_0042:\n\tv91 = v89.<>f__am$cache0 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_0062;\n\tv119 = new System.Func`1<System.Boolean>();\n\tSystem.Func`1<System.Boolean>::.ctor(v119, 0, Il2CppMethodInfo);\n\tgoto L_005E;\n\tv153 = *([v148 @ X0_v17 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv154 = v153 == 0;\n\tv155 = ~v154;\n\tif (v155) goto L_005E;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v148, v123, v121, v120, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv156 = Firebase.Platform.FirebaseHandler;\nL_005E:\n\tv131.<>f__am$cache0 = v119;\nL_0062:\n\tgoto L_0073;\n\tv140 = *([v126 @ X0_v9 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_0073;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v126, v122, v100, v98, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv144 = Firebase.Platform.FirebaseHandler;\nL_0073:\n\tv106 = Firebase.Platform.FirebaseHandler::RunOnMainThread(v110.<>f__am$cache0);\n\treturn;\nL_007A:\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void StopMonoBehaviour()
		{
			if (!(firebaseMonoBehaviour != null))
			{
				return;
			}
			if (_003C_003Ef__am_0024cache0 == null)
			{
				Func<bool> func = [Token(Token = "0x600002D")] [Address(RVA = "0x15E7AD4", Offset = "0x15E7AD4", Length = "0x130")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEC578]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029F73]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = Firebase.Platform.FirebaseHandler;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Inequality(v55.firebaseMonoBehaviour, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_006A;\n\tgoto L_0042;\n\tv100 = *([v78 @ X0_v9 (Il2CppClass<Firebase.Unity.UnitySynchronizationContext>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0042;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v78, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tFirebase.Unity.UnitySynchronizationContext::Destroy();\n\tgoto L_0053;\n\tv124 = *([v120 @ X0_v11 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\t// 75 ConditionalJump @b30, v126 @ TEMP_v26\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v120, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv128 = Firebase.Platform.FirebaseHandler;\nL_0053:\n\tv134 = UnityEngine.Component::get_gameObject(v117.firebaseMonoBehaviour);\n\tgoto L_0062;\n\tv138 = *([v91 @ X8_v14+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0062;\n\tv143 = v91;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v143, v133, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tUnityEngine.Object::Destroy(v134);\nL_006A:\n\treturn 1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
				{
					if (firebaseMonoBehaviour != null)
					{
						UnitySynchronizationContext.Destroy();
						GameObject gameObject = firebaseMonoBehaviour.gameObject;
						UnityEngine.Object.Destroy(gameObject);
					}
					return true;
				};
				_003C_003Ef__am_0024cache0 = func;
			}
			bool flag = RunOnMainThread(_003C_003Ef__am_0024cache0);
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0xAD9DE0", Offset = "0xAD9DE0", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EF6B60]);\n\tv25 = *([v24 @ X8_v33]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20223E1]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1EAB290]);\n\tv63 = *([v62 @ X8_v29]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2022408]) = v67;\nL_0031:\n\tgoto L_003A;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = Firebase.Platform.FirebaseHandler;\nL_003A:\n\tv81 = v79.<ThreadDispatcher>k__BackingField == 0;\n\tif (v81) goto L_0072;\n\tgoto L_0048;\n\tv87 = *([v75 @ X0_v6 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0048;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0048:\n\tgoto L_0053;\n\tv116 = *([1EAB290]);\n\tv117 = *([v116 @ X8_v23]);\n\tv118 = \"il2cpp_codegen_initialize_method\"(v117, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv121 = 0 | 1;\n\t*([2022408]) = v121;\nL_0053:\n\tgoto L_005B;\n\tv149 = *([v122 @ X0_v13 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tgoto L_005B;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v122, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv153 = Firebase.Platform.FirebaseHandler;\nL_005B:\n\tv137 = v112.<ThreadDispatcher>k__BackingField;\n\tv129 = Il2CppMethodInfo;\n\tv127 = *([v129 @ X2_v2 (Il2CppMethodInfo)]);\n\t// 105 IndirectJump v127 @ X3_v1, v137 @ X0_v15 (Firebase.Dispatcher), v137 @ X0_v15 (Firebase.Dispatcher), f @ X0 (System.Func`1<TResult>), methodof(Firebase.Dispatcher::Run), v127 @ X3_v1, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0072:\n\tv103 = Il2CppMethodInfo;\n\tv104 = *([v103 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 119 IndirectJump v104 @ X2_v1, f @ X0 (System.Func`1<TResult>), f @ X0 (System.Func`1<TResult>), methodof(System.Func`1<TResult>::Invoke), v104 @ X2_v1, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TResult RunOnMainThread<TResult>(Func<TResult> f)
		{
			//IL_003a: Expected O, but got I
			//IL_0022: Expected O, but got I
			while (true)
			{
				if (ThreadDispatcher != null)
				{
					Dispatcher dispatcher = ThreadDispatcher;
					IntPtr intPtr = (IntPtr)0;
					object obj = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v127 @ X3_v1 (should have been resolved before IL gen)");
				}
				IntPtr intPtr2 = (IntPtr)0;
				object obj2 = (long)intPtr2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v104 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0xBAFD10", Offset = "0xBAFD10", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ECD560]);\n\tv25 = *([v24 @ X8_v32]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2022C37]) = v43;\nL_001C:\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0026:\n\tgoto L_0031;\n\tv62 = *([1EDE7B0]);\n\tv63 = *([v62 @ X8_v28]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv67 = 0 | 1;\n\t*([2022408]) = v67;\nL_0031:\n\tgoto L_003A;\n\tv72 = *([v68 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_003A;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v68, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv76 = Firebase.Platform.FirebaseHandler;\nL_003A:\n\tv81 = v79.<ThreadDispatcher>k__BackingField == 0;\n\tif (v81) goto L_0070;\n\tgoto L_0048;\n\tv96 = *([v75 @ X0_v6 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0048;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0048:\n\tgoto L_0053;\n\tv133 = *([1EDE7B0]);\n\tv134 = *([v133 @ X8_v22]);\n\tv135 = \"il2cpp_codegen_initialize_method\"(v134, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv138 = 0 | 1;\n\t*([2022408]) = v138;\nL_0053:\n\tgoto L_005B;\n\tv143 = *([v139 @ X0_v10 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tgoto L_005B;\n\tv150 = \"il2cpp_codegen_runtime_class_init\"(v139, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv147 = Firebase.Platform.FirebaseHandler;\nL_005B:\n\tv117 = v127.<ThreadDispatcher>k__BackingField;\n\tv109 = Il2CppMethodInfo;\n\tv107 = *([v109 @ X2_v2 (Il2CppMethodInfo)]);\n\t// 105 IndirectJump v107 @ X3_v1, v117 @ X0_v12 (Firebase.Dispatcher), v117 @ X0_v12 (Firebase.Dispatcher), f @ X0 (System.Func`1<TResult>), methodof(Firebase.Dispatcher::RunAsync), v107 @ X3_v1, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_0070:\n\tv92 = Il2CppMethodInfo;\n\tv93 = *([v92 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 117 IndirectJump v93 @ X2_v1, f @ X0 (System.Func`1<TResult>), f @ X0 (System.Func`1<TResult>), methodof(Firebase.Dispatcher::RunAsyncNow), v93 @ X2_v1, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Task<TResult> RunOnMainThreadAsync<TResult>(Func<TResult> f)
		{
			//IL_003a: Expected O, but got I
			//IL_0022: Expected O, but got I
			while (true)
			{
				if (ThreadDispatcher != null)
				{
					Dispatcher dispatcher = ThreadDispatcher;
					IntPtr intPtr = (IntPtr)0;
					object obj = (long)intPtr;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v107 @ X3_v1 (should have been resolved before IL gen)");
				}
				IntPtr intPtr2 = (IntPtr)0;
				object obj2 = (long)intPtr2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v93 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x15E7490", Offset = "0x15E7490", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFDD40]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F6E]) = v40;\nL_0017:\n\tv44 = new Firebase.Platform.FirebaseHandler+<CreatePartialOnMainThread>c__AnonStorey0();\n\tSystem.Object::.ctor(v44);\n\tv44.appUtils = appUtils;\n\tv51 = new System.Action();\n\tSystem.Action::.ctor(v51, v44, Il2CppMethodInfo);\n\tgoto L_005F;\n\tv137 = *([v133 @ X8_v10+B0]);\n\tv138 = 0;\n\tv139 = v137 + 8;\n\tv141 = *([v177 @ X11_v5-8]);\n\tv183 = v141 == v136;\n\tif (v183) goto L_0051;\n\tv163 = v178 + 1;\n\tv188 = v163 < v135;\n\tv159 = ~v188;\n\tv161 = v177 + 0x10;\n\tv143 = ~v159;\n\tif (v143) goto L_FFFFFFFF;\n\tv164 = v14;\n\tv165 = 0;\n\tv166 = 0x8909C4(v164, v136, v165, v55, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_005F;\nL_0051:\n\tv189 = *([v177 @ X11_v5]);\n\tv190 = v189 << 4;\n\tv191 = v133 + v190;\n\tv192 = v191 + 0x130;\nL_005F:\n\tFirebase.Platform.IFirebaseAppUtils::TranslateDllNotFoundException(appUtils, v51);\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void CreatePartialOnMainThread(IFirebaseAppUtils appUtils)
		{
			IFirebaseAppUtils appUtils2 = appUtils;
			Action action = [Token(Token = "0x6000032")] [Address(RVA = "0x15E7CCC", Offset = "0x15E7CCC", Length = "0x274")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF7630]);\n\tv23 = *([v22 @ X8_v57]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029F75]) = v42;\nL_001E:\n\tgoto L_0026;\n\tv52 = *([v45 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv61 = System.Type::GetTypeFromHandle(Firebase.Platform.FirebaseHandler);\n\tSystem.Threading.Monitor::Enter(v61);\n\tgoto L_0039;\n\tv70 = *([v66 @ X0_v6 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0039;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v66, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv74 = Firebase.Platform.FirebaseHandler;\nL_0039:\n\tv79 = v77.firebaseHandler == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_00BC;\n\tgoto L_004A;\n\tv104 = *([v73 @ X0_v7 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_004A;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v73, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004A:\n\tgoto L_FFFFFFFF;\n\tv116 = *([1EDAB38]);\n\tv117 = *([v116 @ X8_v51]);\n\tv118 = \"il2cpp_codegen_initialize_method\"(v117, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv121 = 0 | 1;\n\t*([2029FC1]) = v121;\n\tgoto L_005D;\n\tv126 = *([v122 @ X0_v12 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tgoto L_005D;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v122, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv130 = Firebase.Platform.FirebaseHandler;\nL_005D:\n\tv133.<AppUtils>k__BackingField = this.appUtils;\n\tgoto L_006D;\n\tv140 = *([1EF7910]);\n\tv141 = *([v140 @ X8_v47]);\n\tv142 = \"il2cpp_codegen_initialize_method\"(v141, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv144 = Firebase.Platform.FirebaseHandler;\n\tv146 = 0 | 1;\n\t*([2022408]) = v146;\nL_006D:\n\tgoto L_0076;\n\tv150 = *([v143 @ X0_v14 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tgoto L_0076;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v143, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv154 = Firebase.Platform.FirebaseHandler;\nL_0076:\n\tv159 = v157.<ThreadDispatcher>k__BackingField == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_00A2;\n\tv165 = new Firebase.Dispatcher();\n\tFirebase.Dispatcher::.ctor(v165);\n\tgoto L_008E;\n\tv186 = *([v178 @ X0_v26+E0]);\n\tv187 = v186 == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_008E;\n\tv190 = \"il2cpp_codegen_runtime_class_init\"(v178, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008E:\n\tgoto L_FFFFFFFF;\n\tv202 = *([1F07AE8]);\n\tv203 = *([v202 @ X8_v42]);\n\tv204 = \"il2cpp_codegen_initialize_method\"(v203, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv207 = 0 | 1;\n\t*([2029FC2]) = v207;\n\tgoto L_00A1;\n\tv213 = *([v208 @ X0_v29 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv214 = v213 == 0;\n\tv215 = ~v214;\n\tgoto L_00A1;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v208, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv216 = Firebase.Platform.FirebaseHandler;\nL_00A1:\n\tv174.<ThreadDispatcher>k__BackingField = v165;\nL_00A2:\n\tv175 = new v167();\n\tFirebase.Platform.FirebaseHandler::.ctor(v175);\n\tgoto L_00B2;\n\tv196 = *([v182 @ X0_v19 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tgoto L_00B2;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v182, v62, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv199 = Firebase.Platform.FirebaseHandler;\nL_00B2:\n\tv95.firebaseHandler = v175;\nL_00BC:\n\tSystem.Threading.Monitor::Exit(v61);\n\treturn;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\nL_00C1:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00DD;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Threading.Monitor::Exit(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DE;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX22 = stack[0];\n\tX21 = stack[8];\n\t// 219 ShiftStack 48\n\treturn;\nL_00DD:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00DE:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
			{
				//IL_0085: Expected I, but got O
				//IL_00d1: Expected I, but got O
				Type typeFromHandle = typeof(FirebaseHandler);
				Monitor.Enter(typeFromHandle);
				if (FirebaseHandler.firebaseHandler == null)
				{
					IntPtr intPtr = (IntPtr)typeof(FirebaseHandler);
					AppUtils = appUtils2;
					if (ThreadDispatcher == null)
					{
						Dispatcher dispatcher = new Dispatcher();
						intPtr = (IntPtr)typeof(FirebaseHandler);
						ThreadDispatcher = dispatcher;
					}
					FirebaseHandler firebaseHandler = new FirebaseHandler();
					FirebaseHandler.firebaseHandler = firebaseHandler;
				}
				Monitor.Exit(typeFromHandle);
			};
			appUtils.TranslateDllNotFoundException(action);
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x15E75A4", Offset = "0x15E75A4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F07008]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F6F]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tFirebase.Platform.FirebaseHandler::CreatePartialOnMainThread(appUtils);\n\tFirebase.Unity.UnityPlatformServices::SetupServices();\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Create(IFirebaseAppUtils appUtils)
		{
			CreatePartialOnMainThread(appUtils);
			UnityPlatformServices.SetupServices();
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x15E6624", Offset = "0x15E6624", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDF3A8]);\n\tv21 = *([v20 @ X8_v41]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F70]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EF7910]);\n\tv60 = *([v59 @ X8_v37]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2022408]) = v64;\nL_002F:\n\tgoto L_003A;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\t// 51 Jump @b39\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = Firebase.Platform.FirebaseHandler;\nL_003A:\n\tFirebase.Dispatcher::PollJobs(v76.<ThreadDispatcher>k__BackingField);\n\tgoto L_004A;\n\tv96 = *([1EF3128]);\n\tv97 = *([v96 @ X8_v32]);\n\tv98 = \"il2cpp_codegen_initialize_method\"(v97, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv101 = 0 | 1;\n\t*([2022B9C]) = v101;\nL_004A:\n\tgoto L_0052;\n\tv106 = *([v102 @ X0_v13 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tgoto L_0052;\n\tv176 = \"il2cpp_codegen_runtime_class_init\"(v102, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv109 = Firebase.Platform.FirebaseHandler;\nL_0052:\n\tv92 = v90.<AppUtils>k__BackingField;\n\tv178 = *([v92 @ X20_v5 (Firebase.Platform.IFirebaseAppUtils)]);\n\tv182 = *([v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]) == 0;\n\tif (v182) goto L_0079;\n\tv223 = *([v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]) + 8;\nL_0064:\n\tv229 = *([v223 @ X11_v5-8]) == Firebase.Platform.IFirebaseAppUtils;\n\tif (v229) goto L_007C;\n\tv224 = v224 + 1;\n\tv234 = v224 < *([v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]);\n\tv205 = ~v234;\n\tv223 = v223 + 0x10;\n\tv189 = ~v205;\n\tif (v189) goto L_0064;\nL_0079:\n\tv242 = 0x8909C4(v92, Firebase.Platform.IFirebaseAppUtils, 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0083;\nL_007C:\n\tv236 = *([v223 @ X11_v5]) + 1;\n\tv237 = v236 << 4;\n\tv238 = v178 + v237;\n\tv242 = v238 + 0x130;\nL_0083:\n\t*([v242 @ X0_v15])(v257, v92, *([v242 @ X0_v15+8]), 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv249 = this.Updated == 0;\n\tif (v249) goto L_0094;\n\tv257 = new System.Action();\n\tSystem.Action::.ctor(v257, this, Il2CppMethodInfo);\n\tFirebase.ExceptionAggregator::Wrap(v257);\nL_0094:\n\tFirebase.ExceptionAggregator::ThrowAndClearPendingExceptions();\n\tgoto L_00A2;\n\tv268 = *([v264 @ X0_v19 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_00A2;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v264, v157, v125, v120, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv271 = Firebase.Platform.FirebaseHandler;\nL_00A2:\n\tv159 = v171.tickCount + 1;\n\tv171.tickCount = v159;\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void Update()
		{
			//IL_0021: Expected I, but got O
			//IL_005c: Expected O, but got I
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_0100: Expected O, but got I
			//IL_010f: Expected O, but got I
			//IL_00a8: Expected O, but got I
			ThreadDispatcher.PollJobs();
			IFirebaseAppUtils firebaseAppUtils = AppUtils;
			IntPtr intPtr = (IntPtr)firebaseAppUtils;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00c1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v223 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IFirebaseAppUtils))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ X8_v16 (Il2CppClass<Firebase.Platform.IFirebaseAppUtils>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00c1;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0189;
			IL_00c1:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0189;
			IL_0189:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v242 @ X0_v15] (should have been resolved before IL gen)");
			if (Updated != null)
			{
				Action action = [Token(Token = "0x600002E")] [Address(RVA = "0x15E7C6C", Offset = "0x15E7C6C", Length = "0x60")] [NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv18 = *([1EBC8C8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029F74]) = v38;\nL_0020:\n\tSystem.EventHandler`1<System.EventArgs>::Invoke(this.Updated, this, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")] () =>
				{
					Updated(this, null);
				};
				ExceptionAggregator.Wrap(action);
			}
			ExceptionAggregator.ThrowAndClearPendingExceptions();
			int num4 = tickCount + 1;
			tickCount = num4;
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x15E78F4", Offset = "0x15E78F4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EC3610]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, hasFocus, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029F71]) = v41;\nL_0016:\n\tv43 = this.ApplicationFocusChanged == 0;\n\tif (v43) goto L_0036;\n\tv47 = new Firebase.Platform.FirebaseHandler+ApplicationFocusChangedEventArgs();\n\tFirebase.Platform.FirebaseHandler+ApplicationFocusChangedEventArgs::.ctor(v47);\n\tv47.<HasFocus>k__BackingField = hasFocus;\n\tSystem.EventHandler`1<Firebase.Platform.FirebaseHandler+ApplicationFocusChangedEventArgs>::Invoke(this.ApplicationFocusChanged, 0, v47);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void OnApplicationFocus(bool hasFocus)
		{
			if (ApplicationFocusChanged != null)
			{
				ApplicationFocusChangedEventArgs e = new ApplicationFocusChangedEventArgs();
				e._003CHasFocus_003Ek__BackingField = hasFocus;
				ApplicationFocusChanged(null, e);
			}
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x15E7A04", Offset = "0x15E7A04", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EF4388]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029F72]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Firebase.Platform.FirebaseHandler;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(behaviour, v56.firebaseMonoBehaviour);\n\tv76 = v73 == 0;\n\tif (v76) goto L_004A;\n\tgoto L_0043;\n\tv92 = *([v77 @ X0_v8 (Il2CppClass<Firebase.Platform.FirebaseHandler>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = Firebase.Platform.FirebaseHandler;\nL_0043:\n\tv86.firebaseMonoBehaviour = 0;\nL_004A:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void OnMonoBehaviourDestroyed(FirebaseMonoBehaviour behaviour)
		{
			if (behaviour == firebaseMonoBehaviour)
			{
				firebaseMonoBehaviour = null;
			}
		}
	}
}
