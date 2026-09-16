using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7313F0", Offset = "0x7313F0")]
	[Token(Token = "0x20000C5")]
	internal class RuntimeHelper : MonoBehaviour
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20001A7")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400067B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400067C")]
			public static Action _003C_003E9__15_0;

			[Token(Token = "0x6000CCA")]
			[Address(RVA = "0xB52324", Offset = "0xB52324", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EF6BB0]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022798]) = v37;\nL_0015:\n\tv41 = new EasyMobile.Internal.RuntimeHelper+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000CCB")]
			[Address(RVA = "0xB52388", Offset = "0xB52388", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal void _003CToMainThread_003Eb__15_0()
			{
			}
		}

		[Token(Token = "0x40003AB")]
		private static RuntimeHelper mInstance;

		[Token(Token = "0x40003AC")]
		private static List<Action> mToMainThreadQueue;

		[Token(Token = "0x40003AD")]
		[FieldOffset(Offset = "0x18")]
		private List<Action> localToMainThreadQueue;

		[Token(Token = "0x40003AE")]
		private static bool mIsToMainThreadQueueEmpty;

		[Token(Token = "0x40003AF")]
		private static List<Action<bool>> mPauseCallbackQueue;

		[Token(Token = "0x40003B0")]
		private static List<Action<bool>> mFocusCallbackQueue;

		[Token(Token = "0x40003B1")]
		private static bool mIsDummy;

		[Token(Token = "0x17000226")]
		public static RuntimeHelper Instance
		{
			[Token(Token = "0x6000720")]
			[Address(RVA = "0xB50D3C", Offset = "0xB50D3C", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EFA0D0]);\n\tv17 = *([v16 @ X8_v18]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2022783]) = v37;\nL_0018:\n\tgoto L_0027;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = EasyMobile.Internal.RuntimeHelper;\nL_0027:\n\tgoto L_0031;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv71 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v71, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Equality(v53.mInstance, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_0044;\n\tgoto L_003F;\n\tv88 = *([v74 @ X0_v13 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv89 = v88 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_003F;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v74, v68, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003F:\n\tEasyMobile.Internal.RuntimeHelper::Init();\nL_0044:\n\tgoto L_0052;\n\tv92 = *([v84 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0052;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v84, v68, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv96 = EasyMobile.Internal.RuntimeHelper;\nL_0052:\n\treturn v99.mInstance;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (mInstance == null)
				{
					Init();
				}
				return mInstance;
			}
		}

		[Token(Token = "0x6000721")]
		[Address(RVA = "0xB50E1C", Offset = "0xB50E1C", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC3580]);\n\tv21 = *([v20 @ X8_v29]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022784]) = v41;\nL_001A:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = EasyMobile.Internal.RuntimeHelper;\nL_0029:\n\tgoto L_0033;\n\tv64 = *([v58 @ X8_v5+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv75 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v75, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv74 = UnityEngine.Object::op_Inequality(v57.mInstance, 0);\n\tv77 = v74 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0092;\n\tv80 = UnityEngine.Application::get_isPlaying();\n\tv98 = v80 == 0;\n\tif (v98) goto L_0077;\n\tv132 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v132, \"EM_RuntimeHelper\");\n\tUnityEngine.Object::set_hideFlags(v132, 0x3D);\n\tv154 = UnityEngine.GameObject::AddComponent(v132);\n\tgoto L_0060;\n\tv161 = *([v156 @ X8_v19 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0060;\n\tv174 = v156;\n\tv165 = \"il2cpp_codegen_runtime_class_init\"(v174, v153, v108, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv168 = EasyMobile.Internal.RuntimeHelper;\nL_0060:\n\tv169.mInstance = v154;\n\tgoto L_0074;\n\tv175 = *([v170 @ X0_v24+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tgoto L_0074;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v170, v153, v108, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0074:\n\tUnityEngine.Object::DontDestroyOnLoad(v132);\n\treturn;\nL_0077:\n\tv134 = new EasyMobile.Internal.RuntimeHelper();\n\tEasyMobile.Internal.RuntimeHelper::.ctor(v134);\n\tgoto L_0087;\n\tv143 = *([v136 @ X0_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0087;\n\tv155 = \"il2cpp_codegen_runtime_class_init\"(v136, v72, v73, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv146 = EasyMobile.Internal.RuntimeHelper;\nL_0087:\n\tv148.mInstance = v134;\n\tv88.mIsDummy = 1;\nL_0092:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Init()
		{
			if (!(mInstance != null))
			{
				if (Application.isPlaying)
				{
					GameObject gameObject = new GameObject("EM_RuntimeHelper");
					gameObject.hideFlags = HideFlags.HideAndDontSave;
					RuntimeHelper runtimeHelper = gameObject.AddComponent<RuntimeHelper>();
					mInstance = runtimeHelper;
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
				else
				{
					RuntimeHelper runtimeHelper2 = new RuntimeHelper();
					mInstance = runtimeHelper2;
					mIsDummy = true;
				}
			}
		}

		[Token(Token = "0x6000722")]
		[Address(RVA = "0xB51038", Offset = "0xB51038", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB4B70]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022785]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tEasyMobile.Internal.RuntimeHelper::Init();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void InitIfNeeded()
		{
			Init();
		}

		[Token(Token = "0x6000723")]
		[Address(RVA = "0xB51094", Offset = "0xB51094", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECD608]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022786]) = v35;\nL_0017:\n\tgoto L_0026;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0026;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Internal.RuntimeHelper;\nL_0026:\n\tgoto L_0034;\n\tv58 = *([v52 @ X8_v7+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tgoto L_0034;\n\tv72 = v52;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v72, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0034:\n\treturnVal1 = UnityEngine.Object::op_Inequality(v51.mInstance, 0);\n\treturn returnVal1;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsInitialized()
		{
			return mInstance != null;
		}

		[Token(Token = "0x6000724")]
		[Address(RVA = "0xB5112C", Offset = "0xB5112C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF7320]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022787]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\treturnVal1 = EasyMobile.RuntimeManager::GetAppInstallationTimestamp();\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static DateTime GetAppInstallationTime()
		{
			return RuntimeManager.GetAppInstallationTimestamp();
		}

		[Token(Token = "0x6000725")]
		[Address(RVA = "0xB5118C", Offset = "0xB5118C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ECE458]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022788]) = v38;\nL_0013:\n\tv39 = routine == 0;\n\tif (v39) goto L_0033;\n\tgoto L_0021;\n\tv51 = *([v42 @ X0_v3 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tif (v53) goto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv58 = EasyMobile.Internal.RuntimeHelper::get_Instance();\n\treturnVal2 = UnityEngine.MonoBehaviour::StartCoroutine(v58, routine);\n\treturn returnVal2;\nL_0033:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Coroutine RunCoroutine(IEnumerator routine)
		{
			if (routine != null)
			{
				RuntimeHelper instance = Instance;
				return instance.StartCoroutine(routine);
			}
			return null;
		}

		[Token(Token = "0x6000726")]
		[Address(RVA = "0xB51214", Offset = "0xB51214", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F04598]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022789]) = v38;\nL_0013:\n\tv39 = routine == 0;\n\tif (v39) goto L_0032;\n\tgoto L_0021;\n\tv50 = *([v42 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0021:\n\tv57 = EasyMobile.Internal.RuntimeHelper::get_Instance();\n\tUnityEngine.MonoBehaviour::StopCoroutine(v57, routine);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void EndCoroutine(IEnumerator routine)
		{
			if (routine != null)
			{
				RuntimeHelper instance = Instance;
				instance.StopCoroutine(routine);
			}
		}

		[Token(Token = "0x6000727")]
		[Address(RVA = "0xB51298", Offset = "0xB51298", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EEE968]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202278A]) = v40;\nL_0017:\n\tv44 = new EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass15_0();\n\tSystem.Object::.ctor(v44);\n\tv44.act = act;\n\tv48 = act == 0;\n\tif (v48) goto L_0032;\n\tv54 = new System.Action();\n\tSystem.Action::.ctor(v54, v44, Il2CppMethodInfo);\n\tgoto L_005F;\nL_0032:\n\tgoto L_003A;\n\tv67 = *([v57 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_003A;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v57, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv71 = EasyMobile.Internal.RuntimeHelper+<>c;\nL_003A:\n\tv115 = v74.<>9__15_0;\n\tv76 = v74.<>9__15_0 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_005F;\n\tgoto L_004D;\n\tv120 = *([v70 @ X0_v9 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_004D;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v70, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv132 = EasyMobile.Internal.RuntimeHelper+<>c;\n\tv126 = *([v132 @ X8_v16+B8]);\nL_004D:\n\tv113 = new System.Action();\n\tSystem.Action::.ctor(v113, v125.<>9, Il2CppMethodInfo);\n\tv117.<>9__15_0 = v113;\nL_005F:\n\treturn v115;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Action ToMainThread(Action act)
		{
			Action act2 = act;
			Action result;
			if (act != null)
			{
				Action action3 = default(Action);
				Action action = delegate
				{
					Action action2 = action3;
					if (action3 == null)
					{
						action2 = (action3 = delegate
						{
							act2();
						});
					}
					RunOnMainThread(action2);
				};
				result = action;
			}
			else
			{
				result = _003C_003Ec._003C_003E9__15_0;
				if (_003C_003Ec._003C_003E9__15_0 == null)
				{
					result = (_003C_003Ec._003C_003E9__15_0 = delegate
					{
					});
				}
			}
			return result;
		}

		[Token(Token = "0x6000728")]
		[Address(RVA = "0x11B1B94", Offset = "0x11B1B94", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = v19;\n\tv25 = 0x8907BC(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0014:\n\tv42 = new Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>>();\n\tv47 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v42);\n\tv42.act = act;\n\tv50 = act == 0;\n\tif (v50) goto L_0032;\n\tgoto L_0029;\n\tv63 = v53;\n\tv64 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v63, v45);\nL_0029:\n\tv67 = new Il2CppClass<System.Action`1<T>>();\n\tv108 = System.Action`1<T>::.ctor(v67, v42, Il2CppMethodInfo);\n\tgoto L_00B9;\nL_0032:\n\tv58 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_003B;\n\tv68 = v58;\n\tv69 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v68, v45);\n\tv72 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]);\nL_003B:\n\tv73 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]) & 0x200;\n\tv74 = v73 == 0;\n\tif (v74) goto L_0057;\n\tv110 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_0048;\n\tv152 = v110;\n\tv153 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v152, v45);\nL_0048:\n\tv154 = *([v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+E0]) == 0;\n\tv120 = ~v154;\n\tif (v120) goto L_0057;\n\tgoto L_0057;\n\tv167 = v122;\n\tv168 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v167, v45);\nL_0057:\n\tv127 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_005F;\n\tv155 = v127;\n\tv156 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v155, v45);\nL_005F:\n\tv149 = *([v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+B8]);\n\tv145 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+8]);\n\tv157 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+8]) == 0;\n\tv142 = ~v157;\n\tif (v142) goto L_00B9;\n\tv162 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_006E;\n\tv171 = v162;\n\tv172 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v171, v45);\n\tv175 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]);\nL_006E:\n\tv176 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]) & 0x200;\n\tv177 = v176 == 0;\n\tif (v177) goto L_008F;\n\tv179 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_007B;\n\tv201 = v179;\n\tv202 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v201, v45);\nL_007B:\n\tv203 = *([v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+E0]) == 0;\n\tv189 = ~v203;\n\tif (v189) goto L_008F;\n\tgoto L_008F;\n\tv222 = v191;\n\tv223 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v222, v45);\nL_008F:\n\tgoto L_009A;\n\tv204 = v196;\n\tv205 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v204, v45);\n\tv208 = Il2CppMethodRgctx<EasyMobile.Internal.RuntimeHelper::ToMainThread>;\nL_009A:\n\tgoto L_009E;\n\tv217 = v133;\n\tv218 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass16_0`1<T>::.ctor(v217, v45);\nL_009E:\n\tv221 = new Il2CppClass<System.Action`1<T>>();\n\tv227 = System.Action`1<T>::.ctor(v221, v209.<>9, Il2CppMethodInfo);\n\tv151 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>;\n\tgoto L_00AF;\n\tv232 = v151;\n\tv233 = System.Action`1<T>::.ctor(v232, v137, v135, v136);\nL_00AF:\n\tv148 = *([v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+B8]);\n\t*([v148 @ X8_v23 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+8]) = v221;\nL_00B9:\n\treturn v145;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Action<T> ToMainThread<T>(Action<T> act)
		{
			//IL_00da: Expected O, but got I
			Action<T> act2 = act;
			Action<T> result;
			if (act != null)
			{
				Action<T> action = delegate(T arg)
				{
					Action action3 = delegate
					{
						//IL_0039: Expected O, but got I
						Action<T> action4 = act2;
						T val = arg;
						IntPtr intPtr9 = (IntPtr)0;
						object obj = (long)intPtr9;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v35 @ X3_v1 (should have been resolved before IL gen)");
					};
					RunOnMainThread(action3);
				};
				result = action;
			}
			else
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+8]");
				result = (Action<T>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					Action<T> action2 = delegate
					{
					};
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__16`1<T>>)+B8]");
					IntPtr intPtr8 = (IntPtr)0;
					result = action2;
				}
			}
			return result;
		}

		[Token(Token = "0x6000729")]
		[Address(RVA = "0x11B1DA0", Offset = "0x11B1DA0", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = v19;\n\tv25 = 0x8907BC(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0014:\n\tv42 = new Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>>();\n\tv47 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v42);\n\tv42.act = act;\n\tv50 = act == 0;\n\tif (v50) goto L_0032;\n\tgoto L_0029;\n\tv63 = v53;\n\tv64 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v63, v45);\nL_0029:\n\tv67 = new Il2CppClass<System.Action`2<T1, T2>>();\n\tv108 = System.Action`2<T1, T2>::.ctor(v67, v42, Il2CppMethodInfo);\n\tgoto L_00B9;\nL_0032:\n\tv58 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_003B;\n\tv68 = v58;\n\tv69 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v68, v45);\n\tv72 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]);\nL_003B:\n\tv73 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]) & 0x200;\n\tv74 = v73 == 0;\n\tif (v74) goto L_0057;\n\tv110 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_0048;\n\tv152 = v110;\n\tv153 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v152, v45);\nL_0048:\n\tv154 = *([v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+E0]) == 0;\n\tv120 = ~v154;\n\tif (v120) goto L_0057;\n\tgoto L_0057;\n\tv167 = v122;\n\tv168 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v167, v45);\nL_0057:\n\tv127 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_005F;\n\tv155 = v127;\n\tv156 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v155, v45);\nL_005F:\n\tv149 = *([v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+B8]);\n\tv145 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+8]);\n\tv157 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+8]) == 0;\n\tv142 = ~v157;\n\tif (v142) goto L_00B9;\n\tv162 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_006E;\n\tv171 = v162;\n\tv172 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v171, v45);\n\tv175 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]);\nL_006E:\n\tv176 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]) & 0x200;\n\tv177 = v176 == 0;\n\tif (v177) goto L_008F;\n\tv179 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_007B;\n\tv201 = v179;\n\tv202 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v201, v45);\nL_007B:\n\tv203 = *([v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+E0]) == 0;\n\tv189 = ~v203;\n\tif (v189) goto L_008F;\n\tgoto L_008F;\n\tv222 = v191;\n\tv223 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v222, v45);\nL_008F:\n\tgoto L_009A;\n\tv204 = v196;\n\tv205 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v204, v45);\n\tv208 = Il2CppMethodRgctx<EasyMobile.Internal.RuntimeHelper::ToMainThread>;\nL_009A:\n\tgoto L_009E;\n\tv217 = v133;\n\tv218 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass17_0`2<T1, T2>::.ctor(v217, v45);\nL_009E:\n\tv221 = new Il2CppClass<System.Action`2<T1, T2>>();\n\tv227 = System.Action`2<T1, T2>::.ctor(v221, v209.<>9, Il2CppMethodInfo);\n\tv151 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>;\n\tgoto L_00AF;\n\tv232 = v151;\n\tv233 = System.Action`2<T1, T2>::.ctor(v232, v137, v135, v136);\nL_00AF:\n\tv148 = *([v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+B8]);\n\t*([v148 @ X8_v23 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+8]) = v221;\nL_00B9:\n\treturn v145;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Action<T1, T2> ToMainThread<T1, T2>(Action<T1, T2> act)
		{
			//IL_00da: Expected O, but got I
			Action<T1, T2> act2 = act;
			Action<T1, T2> result;
			if (act != null)
			{
				Action<T1, T2> action = delegate(T1 arg1, T2 arg2)
				{
					Action action3 = delegate
					{
						//IL_0043: Expected O, but got I
						Action<T1, T2> action4 = act2;
						T1 val = arg1;
						T2 val2 = arg2;
						IntPtr intPtr9 = (IntPtr)0;
						object obj = (long)intPtr9;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v36 @ X4_v1 (should have been resolved before IL gen)");
					};
					RunOnMainThread(action3);
				};
				result = action;
			}
			else
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+8]");
				result = (Action<T1, T2>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					Action<T1, T2> action2 = delegate
					{
					};
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__17`2<T1, T2>>)+B8]");
					IntPtr intPtr8 = (IntPtr)0;
					result = action2;
				}
			}
			return result;
		}

		[Token(Token = "0x600072A")]
		[Address(RVA = "0x11B1FAC", Offset = "0x11B1FAC", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv24 = v19;\n\tv25 = 0x8907BC(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0014:\n\tv42 = new Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>>();\n\tv47 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v42);\n\tv42.act = act;\n\tv50 = act == 0;\n\tif (v50) goto L_0032;\n\tgoto L_0029;\n\tv63 = v53;\n\tv64 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v63, v45);\nL_0029:\n\tv67 = new Il2CppClass<System.Action`3<T1, T2, T3>>();\n\tv108 = System.Action`3<T1, T2, T3>::.ctor(v67, v42, Il2CppMethodInfo);\n\tgoto L_00B9;\nL_0032:\n\tv58 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_003B;\n\tv68 = v58;\n\tv69 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v68, v45);\n\tv72 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]);\nL_003B:\n\tv73 = *([v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]) & 0x200;\n\tv74 = v73 == 0;\n\tif (v74) goto L_0057;\n\tv110 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_0048;\n\tv152 = v110;\n\tv153 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v152, v45);\nL_0048:\n\tv154 = *([v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+E0]) == 0;\n\tv120 = ~v154;\n\tif (v120) goto L_0057;\n\tgoto L_0057;\n\tv167 = v122;\n\tv168 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v167, v45);\nL_0057:\n\tv127 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_005F;\n\tv155 = v127;\n\tv156 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v155, v45);\nL_005F:\n\tv149 = *([v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+B8]);\n\tv145 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+8]);\n\tv157 = *([v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+8]) == 0;\n\tv142 = ~v157;\n\tif (v142) goto L_00B9;\n\tv162 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_006E;\n\tv171 = v162;\n\tv172 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v171, v45);\n\tv175 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]);\nL_006E:\n\tv176 = *([v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]) & 0x200;\n\tv177 = v176 == 0;\n\tif (v177) goto L_008F;\n\tv179 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_007B;\n\tv201 = v179;\n\tv202 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v201, v45);\nL_007B:\n\tv203 = *([v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+E0]) == 0;\n\tv189 = ~v203;\n\tif (v189) goto L_008F;\n\tgoto L_008F;\n\tv222 = v191;\n\tv223 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v222, v45);\nL_008F:\n\tgoto L_009A;\n\tv204 = v196;\n\tv205 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v204, v45);\n\tv208 = Il2CppMethodRgctx<EasyMobile.Internal.RuntimeHelper::ToMainThread>;\nL_009A:\n\tgoto L_009E;\n\tv217 = v133;\n\tv218 = EasyMobile.Internal.RuntimeHelper+<>c__DisplayClass18_0`3<T1, T2, T3>::.ctor(v217, v45);\nL_009E:\n\tv221 = new Il2CppClass<System.Action`3<T1, T2, T3>>();\n\tv227 = System.Action`3<T1, T2, T3>::.ctor(v221, v209.<>9, Il2CppMethodInfo);\n\tv151 = Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>;\n\tgoto L_00AF;\n\tv232 = v151;\n\tv233 = System.Action`3<T1, T2, T3>::.ctor(v232, v137, v135, v136);\nL_00AF:\n\tv148 = *([v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+B8]);\n\t*([v148 @ X8_v23 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+8]) = v221;\nL_00B9:\n\treturn v145;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Action<T1, T2, T3> ToMainThread<T1, T2, T3>(Action<T1, T2, T3> act)
		{
			//IL_00da: Expected O, but got I
			Action<T1, T2, T3> act2 = act;
			Action<T1, T2, T3> result;
			if (act != null)
			{
				Action<T1, T2, T3> action = delegate(T1 arg1, T2 arg2, T3 arg3)
				{
					Action action3 = delegate
					{
						//IL_004d: Expected O, but got I
						Action<T1, T2, T3> action4 = act2;
						T2 val = arg2;
						T3 val2 = arg3;
						T1 val3 = arg1;
						IntPtr intPtr9 = (IntPtr)0;
						object obj = (long)intPtr9;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v37 @ X5_v1 (should have been resolved before IL gen)");
					};
					RunOnMainThread(action3);
				};
				result = action;
			}
			else
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X20_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X20_v14 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X20_v6 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+8]");
				result = (Action<T1, T2, T3>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X8_v12 (Il2CppStaticFields<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X20_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr6 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X20_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					Action<T1, T2, T3> action2 = delegate
					{
					};
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X19_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper+<>c__18`3<T1, T2, T3>>)+B8]");
					IntPtr intPtr8 = (IntPtr)0;
					result = action2;
				}
			}
			return result;
		}

		[Token(Token = "0x600072B")]
		[Address(RVA = "0xB513D4", Offset = "0xB513D4", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EAB360]);\n\tv23 = *([v22 @ X8_v46]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202278B]) = v42;\nL_0016:\n\tv44 = action == 0;\n\tif (v44) goto L_0096;\n\tgoto L_0027;\n\tv55 = *([v47 @ X0_v22 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0027;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv59 = EasyMobile.Internal.RuntimeHelper;\nL_0027:\n\tv64 = v62.mIsDummy + 7;\n\tv65 = ~v64;\n\tv67 = v65 & 7;\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0092;\n\tgoto L_0037;\n\tv158 = *([v58 @ X0_v23 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0037;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tv165 = EasyMobile.Internal.RuntimeHelper::IsInitialized();\n\tv215 = v165 == 0;\n\tif (v215) goto L_0080;\n\tgoto L_0047;\n\tv234 = *([v216 @ X0_v26 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_0047;\n\tv252 = \"il2cpp_codegen_runtime_class_init\"(v216, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv238 = EasyMobile.Internal.RuntimeHelper;\nL_0047:\n\tv145 = v241.mToMainThreadQueue;\n\tSystem.Threading.Monitor::Enter(v241.mToMainThreadQueue, &v167 @ stack_-34_v3 (System.Boolean));\n\tgoto L_005A;\n\tv259 = *([v253 @ X0_v29 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv260 = v259 == 0;\n\tv261 = ~v260;\n\tgoto L_005A;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v253, v206, v207, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv263 = EasyMobile.Internal.RuntimeHelper;\nL_005A:\n\tv210 = v211.mToMainThreadQueue == 0;\n\tif (v210) goto L_00A3;\n\tSystem.Collections.Generic.List`1<System.Action>::Add(v211.mToMainThreadQueue, action);\n\tv280 = System.Collections.Generic.List`1<System.Action>::Add(v211.mToMainThreadQueue, action);\n\tv284.mIsToMainThreadQueueEmpty = 0;\nL_0068:\n\tv285 = ~v167;\n\tif (v285) goto L_006D;\n\tSystem.Threading.Monitor::Exit(v145);\nL_006D:\n\tv135 = v120 + 1;\n\tv112 = v135 == 0;\n\tv100 = ~v112;\n\tif (v100) goto L_0092;\n\tv136 = v139 == 0;\n\tif (v136) goto L_0092;\n\tthrow System.TypeLoadException;\nL_0080:\n\tgoto L_008A;\n\tv244 = *([v229 @ X0_v18+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tif (v246) goto L_008A;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v229, v220, v125, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008A:\n\tUnityEngine.Debug::LogError(\"Using RunOnMainThread without initializing Helper.\");\nL_0092:\n\treturn;\nL_0096:\n\tv54 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v54, \"action\");\n\tthrow v54;\nL_00A3:\n\tv213 = new System.NullReferenceException();\n\tgoto L_00AE;\nL_00AE:\n\tv178 = &v167 @ stack_-34_v3 (System.Boolean) != 1;\n\tif (v178) goto L_00B5;\n\tv251 = 0x6D2BC0(v213, &v167 @ stack_-34_v3 (System.Boolean), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv139 = *([v251 @ X0_v10]);\n\tv258 = 0x6D2490(v251, &v167 @ stack_-34_v3 (System.Boolean), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0068;\nL_00B5:\n\tv195 = 0x6D2380(v213, &v167 @ stack_-34_v3 (System.Boolean), 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RunOnMainThread(Action action)
		{
			//IL_0120: Expected O, but got I4
			//IL_01b9: Expected O, but got I4
			//IL_01c2: Expected I4, but got O
			//IL_0165: Expected I4, but got O
			bool lockTaken = default(bool);
			List<Action> obj2;
			if (action != null)
			{
				object obj = (mIsDummy ? 1 : 0) + 7;
				int num = (int)(~obj);
				if ((num & 7) != 0)
				{
					return;
				}
				if (IsInitialized())
				{
					obj2 = mToMainThreadQueue;
					Monitor.Enter(mToMainThreadQueue, ref lockTaken);
					int num2;
					int num3;
					if (mToMainThreadQueue != null)
					{
						mToMainThreadQueue.Add(action);
						mToMainThreadQueue.Add(action);
						mIsToMainThreadQueueEmpty = false;
						num2 = 0;
						num3 = 0;
					}
					else
					{
						NullReferenceException ex = new NullReferenceException();
						if (!lockTaken)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
							return;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj3 = default(object);
						num3 = (int)obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						num2 = -1;
					}
					if (lockTaken)
					{
						Monitor.Exit(obj2);
					}
					if (num2 + 1 == 0 && num3 != 0)
					{
						throw new TypeLoadException();
					}
				}
				else
				{
					Debug.LogError("Using RunOnMainThread without initializing Helper.");
				}
				return;
			}
			ArgumentNullException ex2 = new ArgumentNullException("action");
			lockTaken = false;
			obj2 = (List<Action>)33693696;
			throw ex2;
		}

		[Token(Token = "0x600072C")]
		[Address(RVA = "0xB515DC", Offset = "0xB515DC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED3FB8]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202278C]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b20\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Internal.RuntimeHelper;\nL_0028:\n\tv60 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Contains(v52.mFocusCallbackQueue, callback);\n\tv71 = v60 == 0;\n\tif (v71) goto L_0036;\n\treturn;\nL_0036:\n\tgoto L_004A;\n\tv96 = *([v76 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\t// 58 ConditionalJump @b21, v98 @ TEMP_v16\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v76, v58, v59, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = EasyMobile.Internal.RuntimeHelper;\nL_004A:\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Add(v68.mFocusCallbackQueue, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddFocusCallback(Action<bool> callback)
		{
			if (!mFocusCallbackQueue.Contains(callback))
			{
				mFocusCallbackQueue.Add(callback);
			}
		}

		[Token(Token = "0x600072D")]
		[Address(RVA = "0xB516AC", Offset = "0xB516AC", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFA948]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202278D]) = v38;\nL_0019:\n\tgoto L_002D;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b13\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Internal.RuntimeHelper;\nL_002D:\n\treturnVal1 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Remove(v52.mFocusCallbackQueue, callback);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool RemoveFocusCallback(Action<bool> callback)
		{
			return mFocusCallbackQueue.Remove(callback);
		}

		[Token(Token = "0x600072E")]
		[Address(RVA = "0xB51730", Offset = "0xB51730", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EADCE8]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202278E]) = v38;\nL_0019:\n\tgoto L_0028;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b20\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Internal.RuntimeHelper;\nL_0028:\n\tv60 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Contains(v52.mPauseCallbackQueue, callback);\n\tv71 = v60 == 0;\n\tif (v71) goto L_0036;\n\treturn;\nL_0036:\n\tgoto L_004A;\n\tv96 = *([v76 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\t// 58 ConditionalJump @b21, v98 @ TEMP_v16\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v76, v58, v59, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = EasyMobile.Internal.RuntimeHelper;\nL_004A:\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Add(v68.mPauseCallbackQueue, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void AddPauseCallback(Action<bool> callback)
		{
			if (!mPauseCallbackQueue.Contains(callback))
			{
				mPauseCallbackQueue.Add(callback);
			}
		}

		[Token(Token = "0x600072F")]
		[Address(RVA = "0xB51800", Offset = "0xB51800", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6408]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202278F]) = v38;\nL_0019:\n\tgoto L_002D;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b13\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = EasyMobile.Internal.RuntimeHelper;\nL_002D:\n\treturnVal1 = System.Collections.Generic.List`1<System.Action`1<System.Boolean>>::Remove(v52.mPauseCallbackQueue, callback);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool RemovePauseCallback(Action<bool> callback)
		{
			return mPauseCallbackQueue.Remove(callback);
		}

		[Token(Token = "0x6000730")]
		[Address(RVA = "0xAD90E4", Offset = "0xAD90E4", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EE0E58]);\n\tv31 = *([v30 @ X8_v37]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, val, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20223DB]) = v48;\nL_0019:\n\tv49 = &v50 @ stack_-50;\n\tv52 = dict == 0;\n\tif (v52) goto L_00D9;\n\tgoto L_0026;\n\tv119 = v54;\n\tv120 = 0x8907BC(v119, val, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0026:\n\tv122 = dict->klass;\n\tv124 = *([v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+126]) == 0;\n\tif (v124) goto L_0049;\n\tv177 = *([v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+B0]) + 8;\nL_0032:\n\tv182 = *([v177 @ X11_v30-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey, TVal>>>;\n\tif (v182) goto L_004B;\n\tv176 = v176 + 1;\n\tv189 = v176 < *([v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+126]);\n\tv147 = ~v189;\n\tv177 = v177 + 0x10;\n\tv131 = ~v147;\n\tif (v131) goto L_0032;\nL_0049:\n\tgoto L_0051;\nL_004B:\n\t;\nL_0051:\n\tv215 = System.Collections.Generic.IEnumerable`1<System.Collections.Generic.KeyValuePair`2<TKey, TVal>>::GetEnumerator(dict);\nL_005B:\n\tgoto L_0082;\n\tv454 = *([v326 @ X8_v20+B0]);\n\tv455 = 0;\n\tv456 = v454 + 8;\n\tv458 = *([v543 @ X11_v25-8]);\n\tv548 = v458 == v327;\n\tif (v548) goto L_007B;\n\tv478 = v542 + 1;\n\tv577 = v478 < v328;\n\tv476 = ~v577;\n\tv480 = v543 + 0x10;\n\tv460 = ~v476;\n\tif (v460) goto L_FFFFFFFF;\n\tv481 = v112;\n\tv482 = 0;\n\tv483 = 0x8909C4(v481, v327, v482, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0082;\nL_007B:\n\tv578 = *([v543 @ X11_v25]);\n\tv579 = v578 << 4;\n\tv580 = v326 + v579;\n\tv581 = v580 + 0x130;\nL_0082:\n\tv602 = System.Collections.IEnumerator::MoveNext(v215);\n\tv604 = v602 == 0;\n\tif (v604) goto L_FFFFFFFF;\n\tgoto L_008F;\n\tv624 = v615;\n\tv625 = 0x8907BC(v624, v600, v584, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_008F:\n\tv627 = *([v215 @ X0_v23 (System.Collections.IEnumerator)]);\n\tv629 = *([v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]) == 0;\n\tif (v629) goto L_FFFFFFFF;\n\tv677 = *([v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_009B:\n\tv682 = *([v677 @ X11_v20-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<TKey, TVal>>>;\n\tif (v682) goto L_00B4;\n\tv676 = v676 + 1;\n\tv687 = v676 < *([v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]);\n\tv657 = ~v687;\n\tv677 = v677 + 0x10;\n\tv641 = ~v657;\n\tif (v641) goto L_009B;\n\tgoto L_00B8;\nL_00B4:\n\tv689 = *([v677 @ X11_v20]) << 4;\n\tv690 = v627 + v689;\n\tv693 = v690 + 0x130;\nL_00B8:\n\tv485 = *([v693 @ X0_v35+8]);\n\tv488 = System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<TKey, TVal>>::get_Current(v215);\n\tv319 = *([v485 @ X1_v16]);\n\t*([v319 @ X8_v30+130])(v315, *([v693 @ X0_v35+8]), val, *([v319 @ X8_v30+138]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv697 = v315 & 1;\n\tv317 = v697 == 0;\n\tif (v317) goto L_005B;\n\tgoto L_00CF;\nL_00CF:\n\t*([v49 @ X23_v1]) = v375;\n\tv634 = v215 == 0;\n\tv368 = ~v634;\n\tif (v368) goto L_00F6;\n\tgoto L_011E;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_00D9:\n\tv118 = new System.NullReferenceException();\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\nL_00E7:\n\tv165 = v69 != 1;\n\tif (v165) goto L_014D;\n\tv187 = 0x6D2BC0(v118, v69, v67, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv372 = *([v187 @ X0_v18]);\n\tv218 = 0x6D2490(v187, v69, v67, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv325 = v215 == 0;\n\tif (v325) goto L_011E;\nL_00F6:\n\tgoto L_011D;\n\tv492 = *([v379 @ X8_v8+B0]);\n\tv493 = 0;\n\tv494 = v492 + 8;\n\tv496 = *([v564 @ X11_v8-8]);\n\tv569 = v496 == v382;\n\tif (v569) goto L_0116;\n\tv516 = v563 + 1;\n\tv605 = v516 < v381;\n\tv514 = ~v605;\n\tv518 = v564 + 0x10;\n\tv498 = ~v514;\n\tif (v498) goto L_FFFFFFFF;\n\tv519 = v369;\n\tv520 = 0;\n\tv521 = 0x8909C4(v519, v382, v520, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_011D;\nL_0116:\n\tv606 = *([v564 @ X11_v8]);\n\tv607 = v606 << 4;\n\tv608 = v379 + v607;\n\tv609 = v608 + 0x130;\nL_011D:\n\tSystem.IDisposable::Dispose(v369);\nL_011E:\n\tv407 = v269 + 1;\n\tv245 = v407 == 0;\n\tif (v245) goto L_013D;\n\tv526 = *([v49 @ X23_v1+v269 @ X21_v2 (System.Int32)*4]) == 0x56;\n\tif (v526) goto L_014C;\n\tv264 = v271 == 0;\n\tif (v264) goto L_014C;\n\tv244 = *([v49 @ X23_v1+v269 @ X21_v2 (System.Int32)*4]) == 0x4B;\n\tif (v244) goto L_014C;\n\tgoto L_0151;\nL_013D:\n\tv531 = v271 == 0;\n\tv265 = ~v531;\n\tif (v265) goto L_0151;\nL_014C:\n\treturn v575;\nL_014D:\n\tv188 = 0x6D2380(v118, v69, v67, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0151:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static TKey GetKeyForValue<TKey, TVal>(IDictionary<TKey, TVal> dict, TVal val)
		{
			//IL_0012: Expected I, but got O
			//IL_0296: Expected I4, but got O
			//IL_02d3: Expected I4, but got O
			//IL_004d: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_0487: Expected O, but got I4
			//IL_00d1: Expected I, but got O
			//IL_046d: Expected O, but got I
			//IL_010c: Expected O, but got I
			//IL_018c: Expected I4, but got O
			//IL_019a: Expected O, but got I
			//IL_01a9: Expected O, but got I
			//IL_0158: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = dict == null;
			IEnumerator enumerator = default(IEnumerator);
			IDictionary<TKey, TVal> dictionary = (IDictionary<TKey, TVal>)enumerator;
			int num6;
			int num7;
			TKey val2;
			int num9;
			int num10;
			TKey result;
			if (!flag)
			{
				IntPtr intPtr = (IntPtr)dict;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+B0]");
					object obj3 = 0L + 8L;
					int num = 0;
					bool flag3;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ X11_v30-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v15 (Il2CppClass<System.Collections.Generic.IDictionary`2<TKey, TVal>>)+126]");
							bool flag2 = (long)num2 < 0L;
							flag3 = !flag2;
							obj3 = (long)(IntPtr)obj3 + 16L;
							continue;
						}
						break;
					}
					while (!flag3);
				}
				enumerator = dict.GetEnumerator();
				int num8;
				object obj9 = default(object);
				object obj10 = default(object);
				while (true)
				{
					object obj6;
					if (enumerator.MoveNext())
					{
						IntPtr intPtr2 = (IntPtr)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0171;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj4 = 0L + 8L;
						int num3 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v677 @ X11_v20-8]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								break;
							}
							num3++;
							int num4 = num3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v627 @ X8_v27 (Il2CppClass<System.Collections.IEnumerator>)+126]");
							bool flag4 = (long)num4 < 0L;
							bool flag5 = !flag4;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag5)
							{
								continue;
							}
							goto IL_0171;
						}
						int num5 = obj4 << 4;
						object obj5 = (long)intPtr2 + (long)num5;
						obj6 = (long)(IntPtr)obj5 + 304L;
						goto IL_045d;
					}
					num6 = 0;
					num7 = 0;
					num8 = 75;
					val2 = (TKey)null;
					break;
					IL_045d:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v693 @ X0_v35+8]");
					object obj7 = 0;
					TKey current = (TKey)((IEnumerator<KeyValuePair<TKey, TVal>>)enumerator).Current;
					object obj8 = obj7;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v319 @ X8_v30+130] (should have been resolved before IL gen)");
					if ((int)((long)(IntPtr)obj9 & 1L) == 0)
					{
						continue;
					}
					num6 = 0;
					num7 = 0;
					num8 = 86;
					val2 = current;
					break;
					IL_0171:
					obj6 = obj10;
					goto IL_045d;
				}
				obj = num8;
				bool flag6 = enumerator == null;
				bool flag7 = !flag6;
				dictionary = (IDictionary<TKey, TVal>)enumerator;
				if (!flag7)
				{
					num9 = num6;
					num10 = num7;
					result = val2;
					goto IL_04b7;
				}
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				TVal val3 = default(TVal);
				if ((IntPtr)val3 != (IntPtr)1)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					goto IL_03a2;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj11 = default(object);
				num7 = (int)obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				bool flag8 = enumerator == null;
				num6 = -1;
				val2 = (TKey)null;
				num9 = -1;
				num10 = (int)obj11;
				result = (TKey)null;
				if (flag8)
				{
					goto IL_04b7;
				}
			}
			((IDisposable)dictionary).Dispose();
			num9 = num6;
			num10 = num7;
			result = val2;
			goto IL_04b7;
			IL_04b7:
			if (num9 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v1+v269 @ X21_v2 (System.Int32)*4]");
				if ((IntPtr)0 != (IntPtr)86)
				{
					bool flag9 = num10 == 0;
					result = (TKey)null;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X23_v1+v269 @ X21_v2 (System.Int32)*4]");
						bool flag10 = (IntPtr)0 == (IntPtr)75;
						result = (TKey)null;
						if (!flag10)
						{
							goto IL_03a2;
						}
					}
				}
			}
			else
			{
				if (num10 != 0)
				{
					goto IL_03a2;
				}
				result = (TKey)null;
			}
			return result;
			IL_03a2:
			return (TKey)new TypeLoadException();
		}

		[Token(Token = "0x6000731")]
		[Address(RVA = "0xB51884", Offset = "0xB51884", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFAC68]);\n\tv19 = *([v18 @ X8_v33]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2022790]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = EasyMobile.Internal.RuntimeHelper;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Equality(v55.mInstance, 0);\n\tv75 = v72 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_00C1;\n\tgoto L_0044;\n\tv150 = *([v77 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv151 = v150 == 0;\n\tv152 = ~v151;\n\tif (v152) goto L_0044;\n\tv191 = \"il2cpp_codegen_runtime_class_init\"(v77, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv154 = EasyMobile.Internal.RuntimeHelper;\nL_0044:\n\tv129 = 0x8D8210(EasyMobile.Internal.RuntimeHelper, 0, 0, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv134 = ~v139.mIsToMainThreadQueueEmpty;\n\tif (v134) goto L_00C1;\n\tgoto L_0053;\n\tv196 = *([v192 @ X0_v11 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tif (v198) goto L_0053;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v192, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv199 = EasyMobile.Internal.RuntimeHelper;\nL_0053:\n\tv202 = v140.mPauseCallbackQueue;\n\tv88 = v202._size > 0;\n\tif (v88) goto L_00C1;\n\tgoto L_006F;\n\tv230 = *([v130 @ X0_v12 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_006F;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v130, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv234 = EasyMobile.Internal.RuntimeHelper;\n\tv236 = *([v234 @ X0_v35+B8]);\nL_006F:\n\tv217 = v141.mFocusCallbackQueue;\n\tv86 = v217._size > 0;\n\tif (v86) goto L_00C1;\n\tgoto L_008C;\n\tv243 = *([v131 @ X0_v17 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_008C;\n\tv255 = \"il2cpp_codegen_runtime_class_init\"(v131, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv248 = EasyMobile.Internal.RuntimeHelper;\n\tv251 = *([v248 @ X0_v33+B8]);\nL_008C:\n\tv253 = ~v250.mIsDummy;\n\tv254 = ~v253;\n\tif (v254) goto L_00B2;\n\tgoto L_009E;\n\tv271 = *([v247 @ X0_v18 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv272 = v271 == 0;\n\tv273 = ~v272;\n\t// 150 ConditionalJump @b53, v273 @ TEMP_v49\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v247, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv286 = EasyMobile.Internal.RuntimeHelper;\n\tv277 = *([v286 @ X8_v24+B8]);\nL_009E:\n\tv284 = UnityEngine.Component::get_gameObject(v229.mInstance);\n\tgoto L_00AD;\n\tv290 = *([v266 @ X8_v23+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_00AD;\n\tv296 = v266;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v296, v283, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00AD:\n\tUnityEngine.Object::Destroy(v284);\nL_00B2:\n\tgoto L_00BA;\n\tv278 = *([v261 @ X0_v19 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tgoto L_00BA;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v261, v122, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv281 = EasyMobile.Internal.RuntimeHelper;\nL_00BA:\n\tv138.mInstance = 0;\nL_00C1:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DestroyProxy()
		{
			if (mInstance == null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8210");
			if (!mIsToMainThreadQueueEmpty)
			{
				return;
			}
			List<Action<bool>> list = mPauseCallbackQueue;
			if (list.Count > 0)
			{
				return;
			}
			List<Action<bool>> list2 = mFocusCallbackQueue;
			if (list2.Count <= 0)
			{
				if (!mIsDummy)
				{
					GameObject obj = mInstance.gameObject;
					UnityEngine.Object.Destroy(obj);
				}
				mInstance = null;
			}
		}

		[Token(Token = "0x6000732")]
		[Address(RVA = "0xB51A64", Offset = "0xB51A64", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF3080]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022791]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_002B;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002B;\n\tv62 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v62, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tUnityEngine.Object::DontDestroyOnLoad(v41);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x6000733")]
		[Address(RVA = "0xB51AE0", Offset = "0xB51AE0", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EAF8D8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022792]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = EasyMobile.Internal.RuntimeHelper;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(v56.mInstance, this);\n\tv76 = v73 == 0;\n\tif (v76) goto L_004A;\n\tgoto L_0043;\n\tv92 = *([v77 @ X0_v8 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = EasyMobile.Internal.RuntimeHelper;\nL_0043:\n\tv86.mInstance = 0;\nL_004A:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (mInstance == this)
			{
				mInstance = null;
			}
		}

		[Token(Token = "0x6000734")]
		[Address(RVA = "0xB51BB0", Offset = "0xB51BB0", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EF63B8]);\n\tv25 = *([v24 @ X8_v40]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022793]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = EasyMobile.Internal.RuntimeHelper;\nL_0026:\n\tv61 = ~v59.mIsDummy;\n\tv62 = ~v61;\n\tif (v62) goto L_00BE;\n\tgoto L_0035;\n\tv145 = *([v55 @ X0_v3 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0035;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv201 = EasyMobile.Internal.RuntimeHelper;\n\tv152 = *([v201 @ X8_v35+B8]);\nL_0035:\n\tv124 = 0x8D8210(EasyMobile.Internal.RuntimeHelper, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv197 = v151.mIsToMainThreadQueueEmpty + 7;\n\tv198 = ~v197;\n\tv132 = v198 & 7;\n\tv200 = v132 == 0;\n\tv128 = ~v200;\n\tif (v128) goto L_00BE;\n\tSystem.Collections.Generic.List`1<System.Action>::Clear(this.localToMainThreadQueue);\n\tgoto L_0055;\n\tv285 = *([v241 @ X0_v31 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_0055;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v241, v206, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv289 = EasyMobile.Internal.RuntimeHelper;\nL_0055:\n\tSystem.Threading.Monitor::Enter(v292.mToMainThreadQueue, &v296 @ stack_-34_v9 (System.Boolean));\n\tgoto L_006A;\n\tv347 = *([v326 @ X0_v34+E0]);\n\tv348 = v347 == 0;\n\tv349 = ~v348;\n\t// 95 Jump @b22\n\tv350 = \"il2cpp_codegen_runtime_class_init\"(v326, v295, v298, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006A:\n\tSystem.Collections.Generic.List`1<System.Action>::AddRange(this.localToMainThreadQueue, v354.mToMainThreadQueue);\n\tv344 = v345.mToMainThreadQueue == 0;\n\tif (v344) goto L_00C6;\n\tSystem.Collections.Generic.List`1<System.Action>::Clear(v345.mToMainThreadQueue);\n\tv362 = System.Collections.Generic.List`1<System.Action>::AddRange(v345.mToMainThreadQueue, Il2CppMethodInfo);\n\tv368.mIsToMainThreadQueueEmpty = 1;\nL_007A:\n\tv378 = ~v296;\n\tif (v378) goto L_007F;\n\tSystem.Threading.Monitor::Exit(v292.mToMainThreadQueue);\nL_007F:\n\tv381 = v118 + 1;\n\tv263 = v381 == 0;\n\tv257 = ~v263;\n\tif (v257) goto L_0089;\n\tv382 = v268 == 0;\n\tv276 = ~v382;\n\tif (v276) goto L_00C3;\nL_0089:\n\tv113 = this.localToMainThreadQueue;\nL_0097:\n\tv92 = v137 >= v113._size;\n\tif (v92) goto L_00BE;\n\tv404 = v113._size < v137;\n\tv223 = ~v404;\n\tv217 = v113._size - v137;\n\tv225 = v217 == 0;\n\tv405 = ~v225;\n\tv219 = v223 & v405;\n\tif (v219) goto L_00A7;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00A7:\n\tv408 = v113._items;\n\tSystem.Action::Invoke(v408[v137 @ X20_v8 (System.Int32)]);\n\tv113 = this.localToMainThreadQueue;\n\tv137 = v137 + 1;\n\tv409 = this.localToMainThreadQueue == 0;\n\tv390 = ~v409;\n\tif (v390) goto L_0097;\n\tthrow System.NullReferenceException;\nL_00BE:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00C3:\n\tthrow System.TypeLoadException;\n\tv324 = new System.NullReferenceException();\nL_00C6:\n\tv346 = new System.NullReferenceException();\n\tgoto L_00D3;\n\tgoto L_00D3;\n\tgoto L_00D3;\nL_00D3:\n\tv168 = v354.mToMainThreadQueue != 1;\n\tif (v168) goto L_00DA;\n\tv358 = System.Collections.Generic.List`1<System.Action>::AddRange(v346, v354.mToMainThreadQueue);\n\tv268 = *([v358 @ X0_v21 (System.Collections.Generic.List`1<System.Action>)]);\n\tv361 = System.Collections.Generic.List`1<System.Action>::AddRange(v358, v354.mToMainThreadQueue);\n\tgoto L_007A;\nL_00DA:\n\tv188 = System.Collections.Generic.List`1<System.Action>::AddRange(v346, v354.mToMainThreadQueue);\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_02a5: Expected O, but got I4
			//IL_02ae: Expected I4, but got O
			//IL_005e: Expected O, but got I
			//IL_0072: Expected I, but got O
			//IL_0232: Expected I, but got O
			if (mIsDummy)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D8210");
			object obj = (mIsToMainThreadQueueEmpty ? 1 : 0) + 7;
			int num = (int)(~obj);
			if ((num & 7) != 0)
			{
				return;
			}
			localToMainThreadQueue.Clear();
			bool lockTaken = default(bool);
			Monitor.Enter(mToMainThreadQueue, ref lockTaken);
			localToMainThreadQueue.AddRange(mToMainThreadQueue);
			IntPtr intPtr;
			int num2;
			if (mToMainThreadQueue != null)
			{
				mToMainThreadQueue.Clear();
				mToMainThreadQueue.AddRange((IEnumerable<Action>)0);
				mIsToMainThreadQueueEmpty = true;
				intPtr = (IntPtr)null;
				num2 = 0;
			}
			else
			{
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)mToMainThreadQueue != (IntPtr)1)
				{
					((List<Action>)(object)ex).AddRange((IEnumerable<Action>)mToMainThreadQueue);
					return;
				}
				((List<Action>)(object)ex).AddRange((IEnumerable<Action>)mToMainThreadQueue);
				List<Action> list = default(List<Action>);
				intPtr = (IntPtr)list;
				list.AddRange(mToMainThreadQueue);
				num2 = -1;
			}
			if (lockTaken)
			{
				Monitor.Exit(mToMainThreadQueue);
			}
			if (num2 + 1 != 0 || intPtr == (IntPtr)0)
			{
				List<Action> list2 = localToMainThreadQueue;
				int num3 = 0;
				while (num3 < list2.Count)
				{
					bool flag = list2.Count < num3;
					bool flag2 = !flag;
					int num4 = list2.Count - num3;
					bool flag3 = num4 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Action[] items = list2._items;
					items[num3]();
					list2 = localToMainThreadQueue;
					num3++;
					if (localToMainThreadQueue == null)
					{
						throw new NullReferenceException();
					}
				}
				return;
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000735")]
		[Address(RVA = "0xB51DEC", Offset = "0xB51DEC", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv32 = *([1EDC298]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, focused, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([2022794]) = v52;\n\tgoto L_0096;\nL_002C:\n\tgoto L_0038;\n\tv219 = *([v118 @ X0_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0038;\n\tv233 = EasyMobile.Internal.RuntimeHelper;\n\tv154 = *([v233 @ X8_v17 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+B8]);\n\tv148 = v154.mFocusCallbackQueue;\nL_0038:\n\tv226 = v102._size < v109;\n\tv99 = ~v226;\n\tv96 = v102._size - v109;\n\tv90 = v96 == 0;\n\tv227 = ~v90;\n\tv75 = v99 & v227;\n\tif (v75) goto L_0046;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0046:\n\tv232 = v102._items;\n\tv106 = v232[v109 @ X20_v3 (System.Int32)] == 0;\n\tif (v106) goto L_0051;\n\tSystem.Action`1<System.Boolean>::Invoke(v232[v109 @ X20_v3 (System.Int32)], focused);\nL_004F:\n\tv109 = v109 + 1;\n\tgoto L_0096;\nL_0051:\n\tthrow System.NullReferenceException;\n\tstack[C] = X20;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C8;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX0 = *([X22]);\n\tX1 = *([X20]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BE;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX21 = X0;\n\tX0 = X20;\n\tX9 = *([X8+1C0]);\n\tX1 = *([X8+1C8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X23]);\n\tX2 = *([X24]);\n\tX3 = X0;\n\tX1 = X21;\n\tX0 = X8;\n\tX4 = 0;\n\tX0 = System.String::Concat(X0, X1, X2, X3, X4);\n\tX8 = *([X25]);\n\tX20 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_008B;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008B;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008B:\n\tX0 = X20;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX20 = stack[C];\n\tX21 = *([1F08E98]);\n\tgoto L_004F;\nL_0096:\n\tgoto L_009E;\n\tv115 = *([v111 @ X0_v3 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_009E;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v111, v67, v69, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv119 = EasyMobile.Internal.RuntimeHelper;\nL_009E:\n\tv102 = v122.mFocusCallbackQueue;\n\tv137 = v109 < v102._size;\n\tif (v137) goto L_002C;\n\treturn;\n\tthrow System.NullReferenceException;\nL_00BE:\n\tv187 = System.Action`1<System.Boolean>::Invoke(8, v67, v69);\n\t*([v187 @ X0_v7]) = EasyMobile.Internal.RuntimeHelper;\n\tv196 = 0x1E8A000 + 0x870;\n\tv229 = 0x6D2A00(v187, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00C7;\nL_00C7:\n\tv234 = 0x6D2490(v229, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00C8:\n\t;\n\tv236 = 0x6D2380(v229, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv211 = 0x846AA4(v236, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationFocus(bool focused)
		{
			int num = 0;
			while (true)
			{
				List<Action<bool>> list = mFocusCallbackQueue;
				if (num < list.Count)
				{
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Action<bool>[] items = list._items;
					if (items[num] != null)
					{
						items[num](focused);
						num++;
						continue;
					}
					throw new NullReferenceException();
				}
				break;
			}
		}

		[Token(Token = "0x6000736")]
		[Address(RVA = "0xB52014", Offset = "0xB52014", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv32 = *([1F0B810]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, paused, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0 | 1;\n\t*([2022795]) = v52;\n\tgoto L_0096;\nL_002C:\n\tgoto L_0038;\n\tv219 = *([v118 @ X0_v4 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0038;\n\tv233 = EasyMobile.Internal.RuntimeHelper;\n\tv154 = *([v233 @ X8_v17 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+B8]);\n\tv148 = v154.mPauseCallbackQueue;\nL_0038:\n\tv226 = v102._size < v109;\n\tv99 = ~v226;\n\tv96 = v102._size - v109;\n\tv90 = v96 == 0;\n\tv227 = ~v90;\n\tv75 = v99 & v227;\n\tif (v75) goto L_0046;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0046:\n\tv232 = v102._items;\n\tv106 = v232[v109 @ X20_v3 (System.Int32)] == 0;\n\tif (v106) goto L_0051;\n\tSystem.Action`1<System.Boolean>::Invoke(v232[v109 @ X20_v3 (System.Int32)], paused);\nL_004F:\n\tv109 = v109 + 1;\n\tgoto L_0096;\nL_0051:\n\tthrow System.NullReferenceException;\n\tstack[C] = X20;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00C8;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tX20 = *([X21]);\n\tX0 = *([X22]);\n\tX1 = *([X20]);\n\tX0 = 0x8D845C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00BE;\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX9 = *([X8+180]);\n\tX1 = *([X8+188]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X20]);\n\tX21 = X0;\n\tX0 = X20;\n\tX9 = *([X8+1C0]);\n\tX1 = *([X8+1C8]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X23]);\n\tX2 = *([X24]);\n\tX3 = X0;\n\tX1 = X21;\n\tX0 = X8;\n\tX4 = 0;\n\tX0 = System.String::Concat(X0, X1, X2, X3, X4);\n\tX8 = *([X25]);\n\tX20 = X0;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_008B;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008B;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_008B:\n\tX0 = X20;\n\tX1 = 0;\n\tUnityEngine.Debug::LogError(X0, X1);\n\tX20 = stack[C];\n\tX21 = *([1F08E98]);\n\tgoto L_004F;\nL_0096:\n\tgoto L_009E;\n\tv115 = *([v111 @ X0_v3 (Il2CppClass<EasyMobile.Internal.RuntimeHelper>)+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_009E;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v111, v67, v69, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv119 = EasyMobile.Internal.RuntimeHelper;\nL_009E:\n\tv102 = v122.mPauseCallbackQueue;\n\tv137 = v109 < v102._size;\n\tif (v137) goto L_002C;\n\treturn;\n\tthrow System.NullReferenceException;\nL_00BE:\n\tv187 = System.Action`1<System.Boolean>::Invoke(8, v67, v69);\n\t*([v187 @ X0_v7]) = EasyMobile.Internal.RuntimeHelper;\n\tv196 = 0x1E8A000 + 0x870;\n\tv229 = 0x6D2A00(v187, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00C7;\nL_00C7:\n\tv234 = 0x6D2490(v229, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_00C8:\n\t;\n\tv236 = 0x6D2380(v229, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv211 = 0x846AA4(v236, v196, 0, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool paused)
		{
			int num = 0;
			while (true)
			{
				List<Action<bool>> list = mPauseCallbackQueue;
				if (num < list.Count)
				{
					bool flag = list.Count < num;
					bool flag2 = !flag;
					int num2 = list.Count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Action<bool>[] items = list._items;
					if (items[num] != null)
					{
						items[num](paused);
						num++;
						continue;
					}
					throw new NullReferenceException();
				}
				break;
			}
		}

		[Token(Token = "0x6000737")]
		[Address(RVA = "0xB50FC8", Offset = "0xB50FC8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv17 = *([1EB6DD8]);\n\tv18 = *([v17 @ X8_v6]);\n\tv19 = \"il2cpp_codegen_initialize_method\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 0 | 1;\n\t*([2022796]) = v37;\nL_0015:\n\tv40 = 0xB5DE1C(v35, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F05610]);\n\tX20 = X0;\n\tX1 = *([X8]);\n\tSystem.Collections.Generic.List`1::.ctor /* +161 sharing this address */(X0, X1);\n\t*([X19+18]) = X20;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX0 = X19;\n\tX1 = 0;\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 36 ShiftStack 32\n\tUnityEngine.MonoBehaviour::.ctor(X0, X1);\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RuntimeHelper()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B5DE1C (inside EasyMobile.ManifestGenerator.Elements.PermissionGroupElement+<get_AllAvailableAttributes>d__6::System.Collections.IEnumerable.GetEnumerator +0x10)");
		}

		[Token(Token = "0x6000738")]
		[Address(RVA = "0xB5223C", Offset = "0xB5223C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA56D0]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022797]) = v41;\nL_0017:\n\tv45 = new System.Collections.Generic.List`1<System.Action>();\n\tSystem.Collections.Generic.List`1<System.Action>::.ctor(v45);\n\tv53.mToMainThreadQueue = v45;\n\tv54 = System.Collections.Generic.List`1<System.Action>::.ctor(v45);\n\tv58.mIsToMainThreadQueueEmpty = 1;\n\tv61 = new System.Collections.Generic.List`1<System.Action`1<System.Boolean>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::.ctor(v61);\n\tv67.mPauseCallbackQueue = v61;\n\tv69 = new System.Collections.Generic.List`1<System.Action`1<System.Boolean>>();\n\tSystem.Collections.Generic.List`1<System.Action`1<System.Boolean>>::.ctor(v69);\n\tv73.mFocusCallbackQueue = v69;\n\tv74.mIsDummy = 0;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static RuntimeHelper()
		{
			List<Action> list = new List<Action>();
			mToMainThreadQueue = list;
			mIsToMainThreadQueueEmpty = true;
			List<Action<bool>> list2 = new List<Action<bool>>();
			mPauseCallbackQueue = list2;
			List<Action<bool>> list3 = new List<Action<bool>>();
			mFocusCallbackQueue = list3;
			mIsDummy = false;
		}
	}
}
