using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CodeStage.AntiCheat.Common
{
	[Token(Token = "0x2000052")]
	public abstract class KeepAliveBehaviour<T> : MonoBehaviour where T : KeepAliveBehaviour<T>
	{
		[Tooltip("Detector will survive new level (scene) load if checked.")]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x0")]
		public bool keepAlive;

		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x0")]
		protected int instancesInScene;

		[Token(Token = "0x17000044")]
		public static T Instance
		{
			[CompilerGenerated]
			[Token(Token = "0x6000455")]
			[Address(RVA = "0xFB6114", Offset = "0xFB6114", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\n\tv8 = 0xB348B0(v2, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\nL_000F:\n\tgoto L_0015;\n\tv31 = 0xB348B0(v26, v9, v10, v11, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23);\nL_0015:\n\treturn v33.<Instance>k__BackingField;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _003CInstance_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000456")]
			[Address(RVA = "0xFB614C", Offset = "0xFB614C", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv15 = v6;\n\tv16 = 0xB348B0(v15, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = v16;\nL_0015:\n\tgoto L_0018;\n\tv40 = 0xB348B0(v35, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0018:\n\tv42.<Instance>k__BackingField = value;\n\tgoto L_0021;\n\tv48 = 0xB348B0(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv51 = Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>;\n\tv53 = *([v51 @ X0_v6 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]) & 1;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0031;\n\tv59 = 0xB348B0(Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturn;\nL_0031:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected set
			{
				_003CInstance_003Ek__BackingField = value;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X0_v6 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
				}
			}
		}

		[Token(Token = "0x17000045")]
		protected internal static T GetOrCreateInstance
		{
			[Token(Token = "0x6000457")]
			[Address(RVA = "0xFB61C8", Offset = "0xFB61C8", Length = "0x230")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv18 = CodeStage.AntiCheat.Common.ContainerHolder;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.GameObject;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv57 = UnityEngine.Object;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv70 = \"Anti-Cheat Toolkit\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A35C8F]) = v38;\nL_0020:\n\tgoto L_0029;\n\tv47 = 0xB348B0(v39, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0029:\n\tgoto L_0033;\n\tv59 = 0xB348B0(v51, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0033:\n\tgoto L_003B;\n\tv71 = 0xB348B0(v63, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_003B:\n\tgoto L_0041;\n\tv79 = v73;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v79, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0041:\n\tv85 = UnityEngine.Object::op_Inequality(v74.<Instance>k__BackingField, 0);\n\tv87 = v85 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_00A6;\n\tgoto L_0054;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v91, v83, v84, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0054:\n\tv125 = UnityEngine.Object::op_Equality(v94.container, 0);\n\tv136 = v125 == 0;\n\tif (v136) goto L_006F;\n\tv148 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v148, \"Anti-Cheat Toolkit\");\n\tv154.container = v148;\nL_006F:\n\tgoto L_0074;\n\tv190 = 0xB348B0(v172, v150, v101, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0074:\n\tv194 = UnityEngine.GameObject::AddComponent(v158.container);\n\tgoto L_0086;\n\tv199 = v195;\n\tv200 = UnityEngine.GameObject::AddComponent(v199, v103);\n\tv203 = v200;\nL_0086:\n\tgoto L_FFFFFFFF;\n\tv210 = UnityEngine.GameObject::AddComponent(v205, v103);\n\tgoto L_0090;\n\tv218 = UnityEngine.GameObject::AddComponent(v213, v103);\nL_0090:\n\tv220 = *([v219 @ X0_v36+B8]);\n\t*([v220 @ X8_v31]) = v194;\n\tgoto L_009F;\n\tv226 = UnityEngine.GameObject::AddComponent(v221, v103);\nL_009F:\n\tgoto L_00A6;\n\tv107 = UnityEngine.GameObject::AddComponent(v108, v103);\nL_00A6:\n\tgoto L_00AF;\n\tv126 = 0xB348B0(v115, v102, v100, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00AF:\n\tgoto L_00B7;\n\tv137 = 0xB348B0(v130, v102, v100, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00B7:\n\tgoto L_00C1;\n\tv161 = 0xB348B0(v140, v102, v100, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00C1:\n\treturn v163.<Instance>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00bc: Expected O, but got I
				//IL_00d1: Expected O, but got I
				if (!(Instance != null))
				{
					if (ContainerHolder.container == null)
					{
						GameObject container = new GameObject("Anti-Cheat Toolkit");
						ContainerHolder.container = container;
					}
					T val = ContainerHolder.container.AddComponent<T>();
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X0_v36+B8]");
					object obj2 = 0;
					obj2 = val;
				}
				return Instance;
			}
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0xFB63F8", Offset = "0xFB63F8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = this.instancesInScene + 1;\n\tthis.instancesInScene = v15;\n\tgoto L_001B;\n\tv24 = 0xB348B0(v19, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001B:\n\tgoto L_001E;\n\tv46 = 0xB348B0(v41, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_001E:\n\tv49 = this->klass;\n\t*([v49 @ X9_v1 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1D8])(v54, this, *([v49 @ X9_v1 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1E0]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv55 = this->klass;\n\tv61 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1::Init(this, v48.<Instance>k__BackingField, v54);\n\tv63 = v61 == 0;\n\tif (v63) goto L_006F;\n\tgoto L_003B;\n\tv90 = v66;\n\tv91 = 0xB348B0(v90, v58, v56, v60, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv92 = v91;\nL_003B:\n\t// 59 IsInst v95 @ X0_v12 (T), typeof(T), this @ X0 (CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>)\n\tv105 = v95 == 0;\n\tif (v105) goto L_0072;\n\tgoto L_004F;\n\tv122 = 0xB348B0(v116, v74, v56, v60, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004F:\n\tgoto L_0052;\n\tv130 = 0xB348B0(v125, v74, v56, v60, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0052:\n\tv132.<Instance>k__BackingField = v95;\n\tgoto L_005B;\n\tv138 = 0xB348B0(v133, v74, v56, v60, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005B:\n\tv80 = Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>;\n\tv141 = *([v80 @ X0_v21 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]) & 1;\n\tv142 = v141 == 0;\n\tv78 = ~v142;\n\tif (v78) goto L_006F;\n\tv107 = 0xB348B0(Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>, Il2CppClass<T>, v54, *([v55 @ X8_v11 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1C0]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\nL_006F:\n\treturn;\nL_0072:\n\tthrow System.InvalidCastException;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Awake()
		{
			//IL_0029: Expected I, but got O
			//IL_0038: Expected I, but got O
			int num = instancesInScene + 1;
			instancesInScene = num;
			nint num2 = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v49 @ X9_v1 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1D8] (should have been resolved before IL gen)");
			nint num3 = (nint)this;
			string detectorName = default(string);
			if (((KeepAliveBehaviour<>)(object)this).Init(Instance, detectorName))
			{
				T val = this as T;
				if ((object)val == null)
				{
					throw new InvalidCastException();
				}
				Instance = val;
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X0_v21 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
				}
			}
		}

		[Token(Token = "0x6000459")]
		[Address(RVA = "0xFB6534", Offset = "0xFB6534", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv22 = CodeStage.AntiCheat.Common.ContainerHolder;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv62 = UnityEngine.SceneManagement.SceneManager;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv67 = UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv73 = \"Anti-Cheat Toolkit\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35C90]) = v42;\nL_0029:\n\tgoto L_0030;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0030:\n\tv60 = UnityEngine.Object::op_Equality(v45.container, 0);\n\tv65 = v60 == 0;\n\tif (v65) goto L_004F;\n\tv76 = UnityEngine.Component::get_gameObject(this);\n\tv101 = UnityEngine.Object::get_name(v76);\n\tv127 = System.String::op_Equality(v101, \"Anti-Cheat Toolkit\");\n\tv90 = v127 == 0;\n\tif (v90) goto L_004C;\n\tv133 = UnityEngine.Component::get_gameObject(this);\n\tv135.container = v133;\nL_004C:\n\tv87 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tgoto L_0052;\nL_004F:\n\tv87 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\nL_0052:\n\tv93 = this->klass;\n\tUnityEngine.Events.UnityAction`2::.ctor /* +1 sharing this address */(v87, this, *([v93 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1B0]), 0);\n\tgoto L_0068;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v122, v95, v97, v96, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0068:\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v87);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void Start()
		{
			//IL_00a8: Expected I, but got O
			UnityAction<Scene, LoadSceneMode> value;
			if (ContainerHolder.container == null)
			{
				GameObject gameObject = base.gameObject;
				string text = gameObject.name;
				if (text == "Anti-Cheat Toolkit")
				{
					GameObject container = base.gameObject;
					ContainerHolder.container = container;
				}
				value = null;
			}
			else
			{
				value = null;
			}
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @11FA4B8 (UnityEngine.Events.UnityAction`2::.ctor, and 1 more at this address)");
			SceneManager.sceneLoaded += value;
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0xFB668C", Offset = "0xFB668C", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv24 = Il2CppMethodInfo;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = UnityEngine.Object;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv65 = UnityEngine.SceneManagement.SceneManager;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv68 = UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv144 = \"Anti-Cheat Toolkit\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A35C91]) = v43;\nL_0027:\n\tv52 = UnityEngine.Component::GetComponentsInChildren(this);\n\tv56 = UnityEngine.Component::get_transform(this);\n\tv152 = UnityEngine.Transform::get_childCount(v56);\n\tv164 = v52.Length > 2;\n\tif (v164) goto L_0049;\n\tv165 = v152 == 0;\n\tif (v165) goto L_0061;\nL_0049:\n\tv169 = UnityEngine.Object::get_name(this);\n\tv195 = System.String::op_Equality(v169, \"Anti-Cheat Toolkit\");\n\tv175 = v52.Length > 2;\n\tif (v175) goto L_006E;\n\tv197 = v195 == 0;\n\tif (v197) goto L_006E;\nL_0061:\n\tv202 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_006C;\n\tv211 = v204;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v211, v201, v170, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006C:\n\tUnityEngine.Object::Destroy(v202);\nL_006E:\n\tv225 = this.instancesInScene - 1;\n\tthis.instancesInScene = v225;\n\tv227 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tv228 = this->klass;\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v227, this, *([v228 @ X8_v9 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1B0]));\n\tgoto L_0080;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v232, v229, v231, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0080:\n\tUnityEngine.SceneManagement.SceneManager::remove_sceneLoaded(v227);\n\tgoto L_0091;\n\tv248 = 0xB348B0(v243, v239, v231, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0091:\n\tgoto L_0099;\n\tv256 = 0xB348B0(v251, v239, v231, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0099:\n\tgoto L_009F;\n\tv262 = v258;\n\tv263 = \"il2cpp_codegen_runtime_class_init\"(v262, v239, v231, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_009F:\n\tv266 = UnityEngine.Object::op_Equality(v80.<Instance>k__BackingField, this);\n\tv268 = v266 == 0;\n\tif (v268) goto L_00D7;\n\tgoto L_00B3;\n\tv279 = 0xB348B0(v272, v124, v83, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B3:\n\tgoto L_00B6;\n\tv287 = 0xB348B0(v282, v124, v83, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B6:\n\tv289.<Instance>k__BackingField = 0;\n\tgoto L_00BF;\n\tv295 = 0xB348B0(v290, v124, v83, v78, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00BF:\n\tv277 = Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>;\n\tv298 = *([v277 @ X0_v29 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]) & 1;\n\tv299 = v298 == 0;\n\tv129 = ~v299;\n\tif (v129) goto L_00D7;\n\tv126 = 0xB348B0(Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>, this, 0, 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\nL_00D7:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void OnDestroy()
		{
			//IL_011b: Expected I, but got O
			Component[] componentsInChildren = GetComponentsInChildren<Component>();
			Transform transform = base.transform;
			int childCount = transform.childCount;
			if (componentsInChildren.Length > 2 || childCount != 0)
			{
				string text = base.name;
				bool flag = text == "Anti-Cheat Toolkit";
				if (componentsInChildren.Length > 2 || !flag)
				{
					goto IL_00e6;
				}
			}
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			goto IL_00e6;
			IL_00e6:
			int num = instancesInScene - 1;
			instancesInScene = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v228 @ X8_v9 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1B0]");
			UnityAction<Scene, LoadSceneMode> value = new UnityAction<Scene, LoadSceneMode>(this, (IntPtr)0);
			nint num2 = (nint)this;
			SceneManager.sceneLoaded -= value;
			if (Instance == this)
			{
				Instance = null;
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ X0_v29 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+135]");
				if ((int)((nint)0 & (nint)1) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B348B0");
				}
			}
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0xFB68D8", Offset = "0xFB68D8", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, scene, mode, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A35C92]) = v36;\nL_001F:\n\tv50 = this.instancesInScene <= 1;\n\tif (v50) goto L_0052;\n\tv51 = ~this.keepAlive;\n\tv52 = ~v51;\n\tif (v52) goto L_0059;\n\tgoto L_0034;\n\tv99 = 0xB348B0(v57, scene, mode, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0034:\n\tgoto L_003E;\n\tv118 = 0xB348B0(v102, scene, mode, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003E:\n\tgoto L_0044;\n\tv124 = v78;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v124, scene, mode, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0044:\n\tv72 = UnityEngine.Object::op_Inequality(v70.<Instance>k__BackingField, this);\n\tv74 = v72 == 0;\n\tif (v74) goto L_0059;\nL_0048:\n\tv91 = this->klass;\n\tv95 = this->klass->vtable[9];\n\tv96 = this->klass->vtable[9];\n\t// 81 IndirectJump v95 @ X2_v3, this @ X0 (CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>), this @ X0 (CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>), v96 @ X1_v3, v95 @ X2_v3, methodInfo @ X3 (Il2CppMethodInfo), v22 @ X4, v23 @ X5, v24 @ X6, v25 @ X7, v26 @ V0, v27 @ V1, v28 @ V2, v29 @ V3, v30 @ V4, v31 @ V5, v32 @ V6, v33 @ V7\nL_0052:\n\tv53 = ~this.keepAlive;\n\tif (v53) goto L_0048;\nL_0059:\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
		{
			//IL_006b: Expected I, but got O
			//IL_007b: Expected O, but got I
			//IL_008b: Expected O, but got I
			if (instancesInScene > 1)
			{
				if (!keepAlive && Instance != this)
				{
					goto IL_0066;
				}
				return;
			}
			goto IL_0095;
			IL_0066:
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1C8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ X8_v6 (Il2CppClass<CodeStage.AntiCheat.Common.KeepAliveBehaviour`1<T>>)+1D0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v95 @ X2_v3 (should have been resolved before IL gen)");
			goto IL_0095;
			IL_0095:
			if (keepAlive)
			{
				return;
			}
			goto IL_0066;
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0xFB69AC", Offset = "0xFB69AC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, instance, detectorName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35C93]) = v40;\nL_0019:\n\tgoto L_001E;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, instance, detectorName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001E:\n\tv50 = UnityEngine.Object::op_Inequality(instance, 0);\n\tv52 = v50 == 0;\n\tif (v52) goto L_003F;\n\tgoto L_002B;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v53, v48, v49, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv62 = UnityEngine.Object::op_Inequality(instance, this);\n\tv64 = v62 == 0;\n\tif (v64) goto L_003F;\n\tv65 = *([instance @ X1 (T)+20]) == 0;\n\tif (v65) goto L_003F;\n\tv127 = CodeStage.AntiCheat.Common.KeepAliveBehaviour`1::DisposeInternal(this);\n\tgoto L_0072;\nL_003F:\n\tv74 = UnityEngine.Component::get_transform(this);\n\tv98 = UnityEngine.Transform::get_parent(v74);\n\tgoto L_004F;\n\tv129 = v94;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v129, v97, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004F:\n\tv134 = UnityEngine.Object::op_Inequality(v98, 0);\n\tv144 = v134 == 0;\n\tif (v144) goto L_005F;\n\tv84 = UnityEngine.Component::get_transform(this);\n\tv85 = UnityEngine.Transform::get_root(v84);\nL_005F:\n\tv153 = UnityEngine.Component::get_gameObject(v149);\n\tgoto L_006A;\n\tv155 = v142;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v155, v152, v79, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006A:\n\tUnityEngine.Object::DontDestroyOnLoad(v153);\nL_0072:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual bool Init(T instance, string detectorName)
		{
			if (instance != null && instance != this)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [instance @ X1 (T)+20]");
				if ((nint)0 != 0)
				{
					DisposeInternal();
					return false;
				}
			}
			Transform transform = base.transform;
			Transform parent = transform.parent;
			bool flag = parent != null;
			bool flag2 = !flag;
			KeepAliveBehaviour<T> keepAliveBehaviour = this;
			if (!flag2)
			{
				Transform transform2 = base.transform;
				Transform root = transform2.root;
				keepAliveBehaviour = (KeepAliveBehaviour<T>)(object)root;
			}
			GameObject target = keepAliveBehaviour.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
			return true;
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0xFB6B04", Offset = "0xFB6B04", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35C94]) = v37;\nL_0017:\n\tgoto L_0020;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tUnityEngine.Object::Destroy(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void DisposeInternal()
		{
			UnityEngine.Object.Destroy(this);
		}

		[Token(Token = "0x600045E")]
		protected abstract string GetComponentName();

		[Token(Token = "0x600045F")]
		[Address(RVA = "0xFB6B5C", Offset = "0xFB6B5C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.keepAlive = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal KeepAliveBehaviour()
		{
			keepAlive = true;
		}
	}
}
