using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[ExecuteInEditMode]
[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E728", Offset = "0x73E728")]
[Token(Token = "0x2000012")]
public class PlayMakerGUI : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	[Token(Token = "0x200008B")]
	private sealed class _003C_003Ec
	{
		[Token(Token = "0x4000365")]
		public static readonly _003C_003Ec _003C_003E9;

		[Token(Token = "0x4000366")]
		public static Comparison<PlayMakerFSM> _003C_003E9__65_0;

		[Token(Token = "0x6000691")]
		[Address(RVA = "0xE5A540", Offset = "0xE5A540", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1ECC100]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2024816]) = v37;\nL_0015:\n\tv41 = new PlayMakerGUI+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static _003C_003Ec()
		{
			_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
			_003C_003E9 = _003C_003Ec2;
		}

		[Token(Token = "0x6000692")]
		[Address(RVA = "0xE5A5A4", Offset = "0xE5A5A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public _003C_003Ec()
		{
		}

		internal int _003CDrawStateLabels_003Eb__65_0(PlayMakerFSM x, PlayMakerFSM y)
		{
			GameObject gameObject = x.gameObject;
			string name = gameObject.name;
			GameObject gameObject2 = y.gameObject;
			string name2 = gameObject2.name;
			return string.CompareOrdinal(name, name2);
		}
	}

	[Token(Token = "0x400001E")]
	public static readonly List<PlayMakerFSM> fsmList;

	[Token(Token = "0x400001F")]
	public static Fsm SelectedFSM;

	[Token(Token = "0x4000020")]
	private static readonly GUIContent labelContent;

	[Token(Token = "0x4000021")]
	[FieldOffset(Offset = "0x18")]
	public bool previewOnGUI;

	[Token(Token = "0x4000022")]
	[FieldOffset(Offset = "0x19")]
	public bool enableGUILayout;

	[Token(Token = "0x4000023")]
	[FieldOffset(Offset = "0x1A")]
	public bool drawStateLabels;

	[Token(Token = "0x4000024")]
	[FieldOffset(Offset = "0x1B")]
	public bool enableStateLabelsInBuilds;

	[Token(Token = "0x4000025")]
	[FieldOffset(Offset = "0x1C")]
	public bool GUITextureStateLabels;

	[Token(Token = "0x4000026")]
	[FieldOffset(Offset = "0x1D")]
	public bool GUITextStateLabels;

	[Token(Token = "0x4000027")]
	[FieldOffset(Offset = "0x1E")]
	public bool filterLabelsWithDistance;

	[Token(Token = "0x4000028")]
	[FieldOffset(Offset = "0x20")]
	public float maxLabelDistance;

	[Token(Token = "0x4000029")]
	[FieldOffset(Offset = "0x24")]
	public bool controlMouseCursor;

	[Token(Token = "0x400002A")]
	[FieldOffset(Offset = "0x28")]
	public float labelScale;

	[Token(Token = "0x400002B")]
	private static readonly List<PlayMakerFSM> SortedFsmList;

	[Token(Token = "0x400002C")]
	private static GameObject labelGameObject;

	[Token(Token = "0x400002D")]
	private static float fsmLabelIndex;

	[Token(Token = "0x400002E")]
	private static PlayMakerGUI instance;

	[Token(Token = "0x400002F")]
	public static GUISkin guiSkin;

	[Token(Token = "0x4000030")]
	public static Color guiColor;

	[Token(Token = "0x4000031")]
	public static Color guiBackgroundColor;

	[Token(Token = "0x4000032")]
	public static Color guiContentColor;

	[Token(Token = "0x4000033")]
	public static Matrix4x4 guiMatrix;

	[Token(Token = "0x4000037")]
	private const float MaxLabelWidth = 200f;

	[Token(Token = "0x4000038")]
	private static GUIStyle stateLabelStyle;

	[Token(Token = "0x4000039")]
	private static Texture2D stateLabelBackground;

	[Token(Token = "0x400003A")]
	[FieldOffset(Offset = "0x2C")]
	private float initLabelScale;

	[Token(Token = "0x17000022")]
	public static bool EnableStateLabels
	{
		[Token(Token = "0x600007D")]
		[Address(RVA = "0xE57558", Offset = "0xE57558", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1F06610]);\n\tv17 = *([v16 @ X8_v48]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20247F5]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tPlayMakerGUI::InitInstance();\n\tv52 = UnityEngine.Application::get_isEditor();\n\tv56 = v52 == 0;\n\tif (v56) goto L_006C;\n\tgoto L_0038;\n\tv61 = *([v53 @ X8_v5 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0038;\n\tv95 = v53;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v95, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv69 = PlayMakerGUI;\nL_0038:\n\tgoto L_0041;\n\tv96 = *([v73 @ X0_v37+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_0041;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v73, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0041:\n\tv106 = UnityEngine.Object::op_Inequality(v72.instance, 0);\n\tv120 = v106 == 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_0055;\n\tv151 = *([v123 @ X0_v41 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv152 = v151 == 0;\n\tv153 = ~v152;\n\t// 77 ConditionalJump @b59, v153 @ TEMP_v68\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v123, v104, v105, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv155 = PlayMakerGUI;\nL_0055:\n\tv134 = UnityEngine.Behaviour::get_enabled(v142.instance);\n\tv138 = v134 == 0;\n\tif (v138) goto L_FFFFFFFF;\n\tgoto L_0065;\n\tv270 = *([v262 @ X0_v45 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_0065;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v262, v129, v105, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv273 = PlayMakerGUI;\nL_0065:\n\tv259 = v276.instance;\n\tv198 = v259.drawStateLabels;\n\tgoto L_00C2;\nL_006C:\n\tgoto L_007C;\n\tv78 = *([v53 @ X8_v5 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_007C;\n\tv107 = v53;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v107, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv86 = PlayMakerGUI;\nL_007C:\n\tgoto L_0085;\n\tv108 = *([v90 @ X0_v17+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tgoto L_0085;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v90, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0085:\n\tv118 = UnityEngine.Object::op_Inequality(v89.instance, 0);\n\tv122 = v118 == 0;\n\tif (v122) goto L_FFFFFFFF;\n\tgoto L_0099;\n\tv205 = *([v147 @ X0_v21 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\t// 145 ConditionalJump @b63, v207 @ TEMP_v42\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v147, v116, v117, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv209 = PlayMakerGUI;\nL_0099:\n\tv135 = UnityEngine.Behaviour::get_enabled(v143.instance);\n\tv139 = v135 == 0;\n\tif (v139) goto L_FFFFFFFF;\n\tgoto L_00A9;\n\tv277 = *([v266 @ X0_v25 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_00A9;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v266, v130, v117, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv280 = PlayMakerGUI;\nL_00A9:\n\tv298 = v283.instance;\n\tv140 = ~v298.drawStateLabels;\n\tif (v140) goto L_FFFFFFFF;\n\tgoto L_00BD;\n\tv251 = *([v136 @ X0_v26 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv296 = v251 == 0;\n\tv297 = ~v296;\n\tif (v297) goto L_00BD;\n\tv299 = PlayMakerGUI;\n\tv300 = *([v299 @ X8_v23 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv258 = v300.instance;\nL_00BD:\n\tv198 = v298.enableStateLabelsInBuilds;\nL_00C2:\n\tv177 = v198 == 0;\n\tv162 = ~v177;\n\tgoto L_00D0;\nL_00D0:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			InitInstance();
			bool flag;
			if (Application.isEditor)
			{
				if (instance != null && instance.enabled)
				{
					PlayMakerGUI playMakerGUI = instance;
					flag = playMakerGUI.drawStateLabels;
					goto IL_016e;
				}
			}
			else if (instance != null && instance.enabled)
			{
				PlayMakerGUI playMakerGUI2 = instance;
				if (playMakerGUI2.drawStateLabels)
				{
					flag = playMakerGUI2.enableStateLabelsInBuilds;
					goto IL_016e;
				}
			}
			return false;
			IL_016e:
			bool flag2 = !flag;
			return !flag2;
		}
		[Token(Token = "0x600007E")]
		[Address(RVA = "0xE578F0", Offset = "0xE578F0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED9EB8]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247F6]) = v40;\nL_001A:\n\tgoto L_0020;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tPlayMakerGUI::InitInstance();\n\tgoto L_0033;\n\tv63 = *([v58 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0033;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Inequality(v57.instance, 0);\n\tv75 = v73 == 0;\n\tif (v75) goto L_004E;\n\tgoto L_0043;\n\tv93 = *([v76 @ X0_v9 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0043;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v76, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv96 = PlayMakerGUI;\nL_0043:\n\tv87 = v99.instance;\n\tv87.drawStateLabels = value;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			InitInstance();
			if (instance != null)
			{
				PlayMakerGUI playMakerGUI = instance;
				playMakerGUI.drawStateLabels = value;
			}
		}
	}

	[Token(Token = "0x17000023")]
	public static bool EnableStateLabelsInBuild
	{
		[Token(Token = "0x600007F")]
		[Address(RVA = "0xE579D4", Offset = "0xE579D4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EDC348]);\n\tv17 = *([v16 @ X8_v25]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20247F7]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tPlayMakerGUI::InitInstance();\n\tgoto L_0031;\n\tv60 = *([v55 @ X0_v4+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0031;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v55, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Inequality(v54.instance, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_FFFFFFFF;\n\tgoto L_0045;\n\tv86 = *([v73 @ X0_v11 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\t// 61 ConditionalJump @b29, v88 @ TEMP_v28\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v73, v68, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv90 = PlayMakerGUI;\nL_0045:\n\tv80 = UnityEngine.Behaviour::get_enabled(v84.instance);\n\tv82 = v80 == 0;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0055;\n\tv165 = *([v161 @ X0_v19 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0055;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v161, v78, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv168 = PlayMakerGUI;\nL_0055:\n\tv159 = v171.instance;\n\tv112 = v159.enableStateLabelsInBuilds == 0;\n\tv97 = ~v112;\n\tgoto L_006B;\nL_006B:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			InitInstance();
			if (instance != null && instance.enabled)
			{
				PlayMakerGUI playMakerGUI = instance;
				bool flag = !playMakerGUI.enableStateLabelsInBuilds;
				return !flag;
			}
			return false;
		}
		[Token(Token = "0x6000080")]
		[Address(RVA = "0xE57AF0", Offset = "0xE57AF0", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EDE338]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20247F8]) = v40;\nL_001A:\n\tgoto L_0020;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0020;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tPlayMakerGUI::InitInstance();\n\tgoto L_0033;\n\tv63 = *([v58 @ X0_v4+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0033;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Inequality(v57.instance, 0);\n\tv75 = v73 == 0;\n\tif (v75) goto L_004E;\n\tgoto L_0043;\n\tv93 = *([v76 @ X0_v9 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_0043;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v76, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv96 = PlayMakerGUI;\nL_0043:\n\tv87 = v99.instance;\n\tv87.enableStateLabelsInBuilds = value;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			InitInstance();
			if (instance != null)
			{
				PlayMakerGUI playMakerGUI = instance;
				playMakerGUI.enableStateLabelsInBuilds = value;
			}
		}
	}

	[Token(Token = "0x17000024")]
	public static PlayMakerGUI Instance
	{
		[Token(Token = "0x6000082")]
		[Address(RVA = "0xE57BD4", Offset = "0xE57BD4", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB7470]);\n\tv17 = *([v16 @ X8_v26]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20247FA]) = v37;\nL_0018:\n\tgoto L_001E;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_001E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001E:\n\tPlayMakerGUI::InitInstance();\n\tgoto L_0031;\n\tv60 = *([v55 @ X0_v4+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0031;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v55, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Equality(v54.instance, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_005A;\n\tv76 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v76, \"PlayMakerGUI\");\n\tv118 = UnityEngine.GameObject::AddComponent(v76);\n\tgoto L_0054;\n\tv136 = *([v132 @ X8_v19 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv137 = v136 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_0054;\n\tv142 = v132;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v142, v85, v80, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv141 = PlayMakerGUI;\nL_0054:\n\tv87.instance = v118;\n\tgoto L_005A;\nL_005A:\n\tgoto L_0069;\n\tv100 = *([v92 @ X8_v8 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tgoto L_0069;\n\tv121 = v92;\n\tv105 = \"il2cpp_codegen_runtime_class_init\"(v121, v84, v83, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv108 = PlayMakerGUI;\nL_0069:\n\treturn v109.instance;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			InitInstance();
			if (instance == null)
			{
				GameObject gameObject = new GameObject("PlayMakerGUI");
				PlayMakerGUI playMakerGUI = gameObject.AddComponent<PlayMakerGUI>();
				instance = playMakerGUI;
			}
			return instance;
		}
	}

	[Token(Token = "0x17000025")]
	public static bool Enabled
	{
		[Token(Token = "0x6000083")]
		[Address(RVA = "0xE57D14", Offset = "0xE57D14", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EB9CB0]);\n\tv17 = *([v16 @ X8_v15]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20247FB]) = v37;\nL_0018:\n\tgoto L_0027;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0027;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = PlayMakerGUI;\nL_0027:\n\tgoto L_0031;\n\tv60 = *([v54 @ X8_v7+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0031;\n\tv71 = v54;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v71, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0031:\n\tv70 = UnityEngine.Object::op_Inequality(v53.instance, 0);\n\tv73 = v70 == 0;\n\tif (v73) goto L_0052;\n\tgoto L_004A;\n\tv83 = *([v74 @ X0_v8 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\t// 61 ConditionalJump @b23, v85 @ TEMP_v17\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v74, v68, v69, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv87 = PlayMakerGUI;\nL_004A:\n\treturnVal2 = UnityEngine.Behaviour::get_enabled(v90.instance);\n\treturn returnVal2;\nL_0052:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if (instance != null)
			{
				return instance.enabled;
			}
			return false;
		}
	}

	[Token(Token = "0x17000026")]
	public static GUISkin GUISkin
	{
		[Token(Token = "0x6000084")]
		[Address(RVA = "0xE57DF4", Offset = "0xE57DF4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE4F58]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247FC]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0024:\n\treturn v49.guiSkin;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return guiSkin;
		}
		[Token(Token = "0x6000085")]
		[Address(RVA = "0xE57E5C", Offset = "0xE57E5C", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA9950]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247FD]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerGUI;\nL_0021:\n\tv52.guiSkin = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			guiSkin = value;
		}
	}

	[Token(Token = "0x17000027")]
	public static Color GUIColor
	{
		[Token(Token = "0x6000086")]
		[Address(RVA = "0xE57EC8", Offset = "0xE57EC8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBC150]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247FE]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0027:\n\treturn v49.guiColor;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return guiColor;
		}
		[Token(Token = "0x6000087")]
		[Address(RVA = "0xE57F34", Offset = "0xE57F34", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1EEEB60]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20247FF]) = v47;\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv58 = PlayMakerGUI;\nL_0029:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv61.guiColor = value;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+44]) = value.g;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+48]) = value.b;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+4C]) = value.a;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			//IL_0013: Expected I, but got O
			//IL_0021: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)fsmList;
			guiColor = value;
			_ = value.g;
			_ = value.b;
			_ = value.a;
		}
	}

	[Token(Token = "0x17000028")]
	public static Color GUIBackgroundColor
	{
		[Token(Token = "0x6000088")]
		[Address(RVA = "0xE57FC0", Offset = "0xE57FC0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F05D18]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024800]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0027:\n\treturn v49.guiBackgroundColor;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return guiBackgroundColor;
		}
		[Token(Token = "0x6000089")]
		[Address(RVA = "0xE5802C", Offset = "0xE5802C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1EBEF30]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2024801]) = v47;\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv58 = PlayMakerGUI;\nL_0029:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv61.guiBackgroundColor = value;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+54]) = value.g;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+58]) = value.b;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+5C]) = value.a;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			//IL_0013: Expected I, but got O
			//IL_0021: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)fsmList;
			guiBackgroundColor = value;
			_ = value.g;
			_ = value.b;
			_ = value.a;
		}
	}

	[Token(Token = "0x17000029")]
	public static Color GUIContentColor
	{
		[Token(Token = "0x600008A")]
		[Address(RVA = "0xE580B8", Offset = "0xE580B8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDE930]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024802]) = v35;\nL_0017:\n\tgoto L_0027;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0027:\n\treturn v49.guiContentColor;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return guiContentColor;
		}
		[Token(Token = "0x600008B")]
		[Address(RVA = "0xE58124", Offset = "0xE58124", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1EB8568]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2024803]) = v47;\n\tgoto L_0029;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv58 = PlayMakerGUI;\nL_0029:\n\tv61 = *([v57 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv61.guiContentColor = value;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+64]) = value.g;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+68]) = value.b;\n\t*([v61 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+6C]) = value.a;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			//IL_0013: Expected I, but got O
			//IL_0021: Expected I, but got O
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)fsmList;
			guiContentColor = value;
			_ = value.g;
			_ = value.b;
			_ = value.a;
		}
	}

	[Token(Token = "0x1700002A")]
	public unsafe static Matrix4x4 GUIMatrix
	{
		[Token(Token = "0x600008C")]
		[Address(RVA = "0xE581B0", Offset = "0xE581B0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv18 = *([1EB4C28]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2024804]) = v39;\n\tgoto L_0020;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0020;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = PlayMakerGUI;\nL_0020:\n\tv53 = *([returnVal1 @ X0_v3 (UnityEngine.Matrix4x4)+B8]);\n\treturnBuffer.m03 = *([v53 @ X8_v4+A0]);\n\treturnBuffer.m02 = *([v53 @ X8_v4+90]);\n\treturnBuffer.m01 = *([v53 @ X8_v4+80]);\n\treturnBuffer.m00 = *([v53 @ X8_v4+70]);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_0028: Expected O, but got I
			//IL_003d: Expected F4, but got I
			//IL_0038: Expected native int or pointer, but got O
			//IL_0052: Expected F4, but got I
			//IL_004d: Expected native int or pointer, but got O
			//IL_0067: Expected F4, but got I
			//IL_0062: Expected native int or pointer, but got O
			//IL_007c: Expected F4, but got I
			//IL_0077: Expected native int or pointer, but got O
			Matrix4x4 typeFromHandle = (Matrix4x4)typeof(PlayMakerGUI);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [returnVal1 @ X0_v3 (UnityEngine.Matrix4x4)+B8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4+A0]");
			Matrix4x4 matrix4x = default(Matrix4x4);
			((Matrix4x4*)(IntPtr)matrix4x)->m03 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4+90]");
			((Matrix4x4*)(IntPtr)matrix4x)->m02 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4+80]");
			((Matrix4x4*)(IntPtr)matrix4x)->m01 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v4+70]");
			((Matrix4x4*)(IntPtr)matrix4x)->m00 = 0f;
			return typeFromHandle;
		}
		[Token(Token = "0x600008D")]
		[Address(RVA = "0xE58238", Offset = "0xE58238", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv18 = *([1ECCC00]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024805]) = v38;\n\tgoto L_0028;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0028;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v22, v23, v24, v25, v26, v27, v45, v29, v30, v31, v32, v33, v34, v35);\n\tv57 = PlayMakerGUI;\nL_0028:\n\tv60 = *([v56 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+B8]);\n\t*([v60 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+A0]) = value.m03;\n\t*([v60 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+90]) = value.m02;\n\t*([v60 @ X8_v5 (Il2CppStaticFields<PlayMakerGUI>)+80]) = value.m01;\n\tv60.guiMatrix = value.m00;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			//IL_0013: Expected I, but got O
			//IL_0021: Expected I, but got O
			//IL_004d: Expected O, but got F4
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)fsmList;
			_ = value.m03;
			_ = value.m02;
			_ = value.m01;
			guiMatrix = (Matrix4x4)value.m00;
		}
	}

	[Token(Token = "0x1700002B")]
	[field: Token(Token = "0x4000034")]
	public static Texture MouseCursor
	{
		[Token(Token = "0x600008E")]
		[Address(RVA = "0xE582E8", Offset = "0xE582E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EC5DB0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024806]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0024:\n\treturn v49.<MouseCursor>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x600008F")]
		[Address(RVA = "0xE58350", Offset = "0xE58350", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB9938]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024807]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerGUI;\nL_0021:\n\tv52.<MouseCursor>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set;
	}

	[Token(Token = "0x1700002C")]
	[field: Token(Token = "0x4000035")]
	public static bool LockCursor
	{
		[Token(Token = "0x6000090")]
		[Address(RVA = "0xE583BC", Offset = "0xE583BC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEC890]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024808]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0024:\n\treturn v49.<LockCursor>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x6000091")]
		[Address(RVA = "0xE58424", Offset = "0xE58424", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED0608]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024809]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerGUI;\nL_0022:\n\tv52.<LockCursor>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set;
	}

	[Token(Token = "0x1700002D")]
	[field: Token(Token = "0x4000036")]
	public static bool HideCursor
	{
		[Token(Token = "0x6000092")]
		[Address(RVA = "0xE58494", Offset = "0xE58494", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB48D8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202480A]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_0024:\n\treturn v49.<HideCursor>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x6000093")]
		[Address(RVA = "0xE584FC", Offset = "0xE584FC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF7558]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202480B]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = PlayMakerGUI;\nL_0022:\n\tv52.<HideCursor>k__BackingField = value;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set;
	}

	[Token(Token = "0x6000081")]
	[Address(RVA = "0xE57780", Offset = "0xE57780", Length = "0x170")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF2D10]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20247F9]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = PlayMakerGUI;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Equality(v55.instance, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_008B;\n\tgoto L_0047;\n\tv140 = *([v78 @ X0_v8+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0047;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v78, v70, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tv149 = System.Type::GetTypeFromHandle(PlayMakerGUI);\n\tgoto L_0056;\n\tv193 = *([v188 @ X8_v12+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_0056;\n\tv202 = v188;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v202, v148, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0056:\n\tv201 = UnityEngine.Object::FindObjectOfType(v149);\n\tgoto L_0065;\n\tv207 = *([v203 @ X8_v13 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0065;\n\tv214 = v203;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v214, v124, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv213 = PlayMakerGUI;\nL_0065:\n\tv130 = v201 == 0;\n\tif (v130) goto L_0084;\n\tgoto L_FFFFFFFF;\n\tv227 = v227_asT == 0;\n\tif (v227) goto L_008E;\nL_0084:\n\tv126.instance = v201;\nL_008B:\n\treturn;\nL_008E:\n\tthrow System.InvalidCastException;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void InitInstance()
	{
		if (!(instance == null))
		{
			return;
		}
		Type typeFromHandle = typeof(PlayMakerGUI);
		UnityEngine.Object obj = UnityEngine.Object.FindObjectOfType(typeFromHandle);
		if ((object)obj != null)
		{
			PlayMakerGUI playMakerGUI = obj as PlayMakerGUI;
			if ((object)playMakerGUI == null)
			{
				throw new InvalidCastException();
			}
		}
		instance = (PlayMakerGUI)obj;
	}

	[Token(Token = "0x6000094")]
	[Address(RVA = "0xE5856C", Offset = "0xE5856C", Length = "0x270")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED9920]);\n\tv23 = *([v22 @ X8_v34]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202480C]) = v42;\nL_001B:\n\tgoto L_002A;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = PlayMakerGUI;\nL_002A:\n\tgoto L_0034;\n\tv65 = *([v59 @ X8_v5+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv76 = v59;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0034:\n\tv75 = UnityEngine.Object::op_Inequality(v58.stateLabelBackground, 0);\n\tv78 = v75 == 0;\n\tif (v78) goto L_0056;\n\tgoto L_0049;\n\tv101 = *([v79 @ X0_v35 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv102 = v101 == 0;\n\tv103 = ~v102;\n\tif (v103) goto L_0049;\n\tv115 = \"il2cpp_codegen_runtime_class_init\"(v79, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv105 = PlayMakerGUI;\nL_0049:\n\tgoto L_0052;\n\tv116 = *([v94 @ X8_v30+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tgoto L_0052;\n\tv125 = v94;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v125, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0052:\n\tUnityEngine.Object::Destroy(v108.stateLabelBackground);\nL_0056:\n\tv100 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v100, 1, 1);\n\tgoto L_0068;\n\tv126 = *([v121 @ X0_v10 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tif (v128) goto L_0068;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v121, v111, v112, v113, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv130 = PlayMakerGUI;\nL_0068:\n\tv133.stateLabelBackground = v100;\n\tv137 = UnityEngine.Color::get_white();\n\tUnityEngine.Texture2D::SetPixel(v134.stateLabelBackground, 0, 0, v137);\n\tUnityEngine.Texture2D::Apply(v179.stateLabelBackground);\n\tv167 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v167);\n\tv193 = UnityEngine.GUIStyle::get_normal(v167);\n\tUnityEngine.GUIStyleState::set_background(v193, v174.stateLabelBackground);\n\tv243 = UnityEngine.GUIStyle::get_normal(v167);\n\tv149 = UnityEngine.Color::get_white();\n\tUnityEngine.GUIStyleState::set_textColor(v243, v149);\n\tv214 = this.labelScale * 10f;\n\tUnityEngine.GUIStyle::set_fontSize(v167, v214);\n\tUnityEngine.GUIStyle::set_alignment(v167, 3);\n\tv256 = new UnityEngine.RectOffset();\n\tUnityEngine.RectOffset::.ctor(v256, 4, 4, 1, 1);\n\tUnityEngine.GUIStyle::set_padding(v167, v256);\n\tv261.stateLabelStyle = v167;\n\tthis.initLabelScale = this.labelScale;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void InitLabelStyle()
	{
		//IL_010a: Expected I4, but got F4
		if (stateLabelBackground != null)
		{
			UnityEngine.Object.Destroy(stateLabelBackground);
		}
		Texture2D texture2D = new Texture2D(1, 1);
		stateLabelBackground = texture2D;
		Color white = Color.white;
		stateLabelBackground.SetPixel(0, 0, white);
		stateLabelBackground.Apply();
		GUIStyle gUIStyle = new GUIStyle();
		GUIStyleState normal = gUIStyle.normal;
		normal.background = stateLabelBackground;
		GUIStyleState normal2 = gUIStyle.normal;
		Color white2 = Color.white;
		normal2.textColor = white2;
		float num = labelScale * 10f;
		gUIStyle.fontSize = (int)num;
		gUIStyle.alignment = TextAnchor.MiddleLeft;
		RectOffset padding = new RectOffset(4, 4, 1, 1);
		gUIStyle.padding = padding;
		stateLabelStyle = gUIStyle;
		initLabelScale = labelScale;
	}

	[Token(Token = "0x6000095")]
	[Address(RVA = "0xE587DC", Offset = "0xE587DC", Length = "0x39C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EAE6E0]);\n\tv35 = *([v34 @ X8_v83]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202480D]) = v54;\nL_0021:\n\tgoto L_002F;\n\tv61 = *([v57 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\t// 37 Jump @b77\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = PlayMakerGUI;\nL_002F:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Clear(v68.SortedFsmList);\n\tgoto L_0040;\n\tv165 = *([v161 @ X0_v7+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_0040;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v161, v74, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0040:\n\tgoto L_004B;\n\tv234 = *([1F06658]);\n\tv235 = *([v234 @ X8_v77]);\n\tv236 = \"il2cpp_codegen_initialize_method\"(v235, v74, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv239 = 0 | 1;\n\t*([2021A8F]) = v239;\nL_004B:\n\tgoto L_0053;\n\tv244 = *([v240 @ X0_v10 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv245 = v244 == 0;\n\tv246 = ~v245;\n\tgoto L_0053;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v240, v74, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv248 = PlayMakerFSM;\nL_0053:\n\tv252 = v251.fsmList;\n\tv265 = v252._size < 1;\n\tif (v265) goto L_00C7;\n\tgoto L_006F;\nL_006F:\n\tgoto L_0078;\n\tv399 = *([v377 @ X0_v43+E0]);\n\tv400 = v399 == 0;\n\tv401 = ~v400;\n\tgoto L_0078;\n\tv403 = \"il2cpp_codegen_runtime_class_init\"(v377, v146, v82, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0078:\n\tgoto L_0080;\n\tv421 = v158;\n\tv422 = \"il2cpp_codegen_initialize_method\"(v421, v146, v82, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\t*([2021A8F]) = v92;\nL_0080:\n\tgoto L_0088;\n\tv442 = *([v424 @ X0_v46 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv443 = v442 == 0;\n\tv444 = ~v443;\n\tgoto L_0088;\n\tv462 = \"il2cpp_codegen_runtime_class_init\"(v424, v146, v82, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv445 = PlayMakerFSM;\nL_0088:\n\tv269 = v340.fsmList;\n\tv464 = v95 < v269._size;\n\tv134 = ~v464;\n\tv102 = ~v134;\n\tif (v102) goto L_0099;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0099:\n\tv473 = v269._items;\n\tv485 = PlayMakerFSM::get_Active(v473[v95 @ X26_v6 (System.Int32)]);\n\tv499 = v485 == 0;\n\tif (v499) goto L_00B6;\n\tgoto L_00B5;\n\tv532 = *([v516 @ X0_v53 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\t// 172 ConditionalJump @b83, v534 @ TEMP_v76\n\tv545 = \"il2cpp_codegen_runtime_class_init\"(v516, v146, v82, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv536 = PlayMakerGUI;\nL_00B5:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Add(v155.SortedFsmList, v473[v95 @ X26_v6 (System.Int32)]);\nL_00B6:\n\tv95 = v95 + 1;\n\tv354 = v95 < v252._size;\n\tif (v354) goto L_006F;\nL_00C7:\n\tgoto L_00D7;\n\tv384 = *([v372 @ X8_v19 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv385 = v384 == 0;\n\tv386 = ~v385;\n\tif (v386) goto L_00D7;\n\tv409 = v372;\n\tv389 = \"il2cpp_codegen_runtime_class_init\"(v409, v363, v350, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv392 = PlayMakerGUI;\nL_00D7:\n\tgoto L_00DF;\n\tv410 = *([v395 @ X0_v17 (Il2CppClass<PlayMakerGUI+<>c>)+E0]);\n\tv411 = v410 == 0;\n\tv412 = ~v411;\n\tgoto L_00DF;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v395, v363, v350, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv414 = PlayMakerGUI+<>c;\nL_00DF:\n\tv267 = v417.<>9__65_0;\n\tv419 = v417.<>9__65_0 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_0106;\n\tgoto L_00F2;\n\tv448 = *([v413 @ X0_v18 (Il2CppClass<PlayMakerGUI+<>c>)+E0]);\n\tv449 = v448 == 0;\n\tv450 = ~v449;\n\tif (v450) goto L_00F2;\n\tv453 = \"il2cpp_codegen_runtime_class_init\"(v413, v363, v350, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv474 = PlayMakerGUI+<>c;\n\tv455 = *([v474 @ X8_v52+B8]);\nL_00F2:\n\tv438 = new System.Comparison`1<PlayMakerFSM>();\n\tSystem.Comparison`1<PlayMakerFSM>::.ctor(v438, v454.<>9, Il2CppMethodInfo);\n\tv441.<>9__65_0 = v438;\nL_0106:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Sort(v394.SortedFsmList, v267);\n\tgoto L_0113;\n\tv476 = *([v468 @ X0_v21 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv477 = v476 == 0;\n\tv478 = ~v477;\n\tif (v478) goto L_0113;\n\tv486 = \"il2cpp_codegen_runtime_class_init\"(v468, v318, v184, v180, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv479 = PlayMakerGUI;\nL_0113:\n\tv482.labelGameObject = 0;\n\tv341 = v483.SortedFsmList;\n\tv497 = v341._size < 1;\n\tif (v497) goto L_0170;\n\tgoto L_012B;\nL_012B:\n\tgoto L_0133;\n\tv539 = *([v525 @ X0_v24 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv540 = v539 == 0;\n\tv541 = ~v540;\n\tgoto L_0133;\n\tv546 = \"il2cpp_codegen_runtime_class_init\"(v525, v319, v184, v180, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv542 = PlayMakerGUI;\nL_0133:\n\tv315 = v342.SortedFsmList;\n\tv548 = v268 < v315._size;\n\tv310 = ~v548;\n\tv278 = ~v310;\n\tif (v278) goto L_0144;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0144:\n\tv550 = v315._items;\n\tv317 = v550[v268 @ X21_v9 (System.Int32)];\n\tv338 = v317.fsm;\n\tv338.owner = v550[v268 @ X21_v9 (System.Int32)];\n\tv339 = v317.fsm;\n\tv514 = ~v339.showStateLabel;\n\tif (v514) goto L_0156;\n\tPlayMakerGUI::DrawStateLabel(this, v550[v268 @ X21_v9 (System.Int32)]);\nL_0156:\n\tv268 = v268 + 1;\n\tv503 = v268 < v341._size;\n\tif (v503) goto L_012B;\nL_0170:\n\treturn;\n\tv148 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void DrawStateLabels()
	{
		SortedFsmList.Clear();
		List<PlayMakerFSM> list = PlayMakerFSM.fsmList;
		if (list.Count >= 1)
		{
			int num = 0;
			do
			{
				List<PlayMakerFSM> list2 = PlayMakerFSM.fsmList;
				if (num >= list2.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				PlayMakerFSM[] items = list2._items;
				if (items[num].Active)
				{
					SortedFsmList.Add(items[num]);
				}
				num++;
			}
			while (num < list.Count);
		}
		Comparison<PlayMakerFSM> comparison = _003C_003Ec._003C_003E9__65_0;
		if (_003C_003Ec._003C_003E9__65_0 == null)
		{
			comparison = (_003C_003Ec._003C_003E9__65_0 = delegate(PlayMakerFSM x, PlayMakerFSM y)
			{
				GameObject gameObject = x.gameObject;
				string strA = gameObject.name;
				GameObject gameObject2 = y.gameObject;
				string strB = gameObject2.name;
				return string.CompareOrdinal(strA, strB);
			});
		}
		SortedFsmList.Sort(comparison);
		labelGameObject = null;
		List<PlayMakerFSM> sortedFsmList = SortedFsmList;
		if (sortedFsmList.Count < 1)
		{
			return;
		}
		int num2 = 0;
		do
		{
			List<PlayMakerFSM> sortedFsmList2 = SortedFsmList;
			if (num2 >= sortedFsmList2.Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items2 = sortedFsmList2._items;
			PlayMakerFSM playMakerFSM = items2[num2];
			Fsm fsm = playMakerFSM.fsm;
			fsm.Owner = items2[num2];
			Fsm fsm2 = playMakerFSM.fsm;
			if (fsm2.ShowStateLabel)
			{
				DrawStateLabel(items2[num2]);
			}
			num2++;
		}
		while (num2 < sortedFsmList.Count);
	}

	[Token(Token = "0x6000096")]
	[Address(RVA = "0xE58B78", Offset = "0xE58B78", Length = "0x73C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = *([1F0DDF0]);\n\tv45 = *([v44 @ X8_v90]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, fsm, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([202480E]) = v63;\nL_0026:\n\tgoto L_002F;\n\tv70 = *([v66 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_002F;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v66, fsm, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv74 = PlayMakerGUI;\nL_002F:\n\tv79 = v77.stateLabelStyle == 0;\n\tif (v79) goto L_0051;\n\tgoto L_0041;\n\tv129 = *([v85 @ X0_v140+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0041;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v85, fsm, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\nL_0041:\n\tv134 = this.initLabelScale - this.labelScale;\n\tv117 = UnityEngine.Mathf::Abs(v134);\n\tv90 = v117 <= 0.1f;\n\tif (v90) goto L_0053;\nL_0051:\n\tPlayMakerGUI::InitLabelStyle(this);\nL_0053:\n\tv152 = UnityEngine.Camera::get_main();\n\tgoto L_0065;\n\tv163 = *([v159 @ X8_v8+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_0065;\n\tv174 = v159;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v174, fsm, methodInfo, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\nL_0065:\n\tv173 = UnityEngine.Object::op_Equality(v152, 0);\n\tv176 = v173 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_020C;\n\tv407 = UnityEngine.Component::get_gameObject(fsm);\n\tv648 = UnityEngine.Camera::get_main();\n\tgoto L_0081;\n\tv660 = *([v382 @ X8_v12+E0]);\n\tv661 = v660 == 0;\n\tv662 = ~v661;\n\tif (v662) goto L_0081;\n\tv667 = v382;\n\tv664 = \"il2cpp_codegen_runtime_class_init\"(v667, v406, v172, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\nL_0081:\n\tv368 = UnityEngine.Object::op_Equality(v407, v648);\n\tv669 = v368 == 0;\n\tv374 = ~v669;\n\tif (v374) goto L_020C;\n\tv672 = UnityEngine.Component::get_gameObject(fsm);\n\tgoto L_009C;\n\tv678 = *([v673 @ X8_v13 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv679 = v678 == 0;\n\tv680 = ~v679;\n\tif (v680) goto L_009C;\n\tv692 = v673;\n\tv683 = \"il2cpp_codegen_runtime_class_init\"(v692, v671, v297, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\n\tv686 = PlayMakerGUI;\nL_009C:\n\tgoto L_00A5;\n\tv693 = *([v687 @ X0_v27+E0]);\n\tv694 = v693 == 0;\n\tv695 = ~v694;\n\tgoto L_00A5;\n\tv697 = \"il2cpp_codegen_runtime_class_init\"(v687, v671, v297, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\nL_00A5:\n\tv702 = UnityEngine.Object::op_Equality(v672, v688.labelGameObject);\n\tv706 = v702 == 0;\n\tif (v706) goto L_00BD;\n\tgoto L_00B8;\n\tv711 = *([v703 @ X8_v17 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv712 = v711 == 0;\n\tv713 = ~v712;\n\tif (v713) goto L_00B8;\n\tv737 = v703;\n\tv716 = \"il2cpp_codegen_runtime_class_init\"(v737, v701, v298, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\n\tv719 = PlayMakerGUI;\nL_00B8:\n\tv723 = v720.fsmLabelIndex + 1f;\n\tv720.fsmLabelIndex = v723;\n\tgoto L_00D0;\nL_00BD:\n\tgoto L_00C8;\n\tv724 = *([v703 @ X8_v17 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv725 = v724 == 0;\n\tv726 = ~v725;\n\tif (v726) goto L_00C8;\n\tv747 = v703;\n\tv729 = \"il2cpp_codegen_runtime_class_init\"(v747, v701, v298, v48, v49, v50, v51, v52, v145, v144, v55, v56, v57, v58, v59, v60);\n\tv732 = PlayMakerGUI;\nL_00C8:\n\tv733.fsmLabelIndex = 0f;\n\tv736 = UnityEngine.Component::get_gameObject(fsm);\n\tv740.labelGameObject = v736;\nL_00D0:\n\tgoto L_00D8;\n\tv748 = *([v383 @ X8_v18+E0]);\n\tv749 = v748 == 0;\n\tv750 = ~v749;\n\tgoto L_00D8;\n\tv756 = v383;\n\tv752 = \"il2cpp_codegen_runtime_class_init\"(v756, v738, v298, v48, v49, v50, v51, v52, v355, v350, v55, v56, v57, v58, v59, v60);\nL_00D8:\n\tv755 = PlayMakerGUI::GenerateStateLabel(fsm);\n\tv369 = System.String::IsNullOrEmpty(v755);\n\tv758 = v369 == 0;\n\tv375 = ~v758;\n\tif (v375) goto L_020C;\n\tgoto L_00F1;\n\tv763 = *([v759 @ X0_v36 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv764 = v763 == 0;\n\tv765 = ~v764;\n\t// 232 ConditionalJump @b159, v765 @ TEMP_v114\n\tv773 = \"il2cpp_codegen_runtime_class_init\"(v759, v303, v298, v48, v49, v50, v51, v52, v355, v350, v55, v56, v57, v58, v59, v60);\n\tv767 = PlayMakerGUI;\nL_00F1:\n\tUnityEngine.GUIContent::set_text(v770.labelContent, v755);\n\tv835 = UnityEngine.GUIStyle::CalcSize(v830.stateLabelStyle, v830.labelContent);\n\tgoto L_010D;\n\tv843 = *([v839 @ X0_v42+E0]);\n\tv844 = v843 == 0;\n\tv845 = ~v844;\n\tif (v845) goto L_010D;\n\tv847 = \"il2cpp_codegen_runtime_class_init\"(v839, v786, v299, v48, v49, v50, v51, v52, v835, v836, v55, v56, v57, v58, v59, v60);\nL_010D:\n\tv792 = this.labelScale * 10f;\n\tv776 = this.labelScale * 200f;\n\tv796 = UnityEngine.Mathf::Clamp(v835, v792, v776);\n\tv856 = ~this.GUITextureStateLabels;\n\tv857 = ~v856;\n\tif (v857) goto L_011C;\n\tv859 = ~this.GUITextStateLabels;\n\tif (v859) goto L_020E;\nL_011C:\n\tv805 = UnityEngine.Component::get_gameObject(fsm);\n\tv806 = UnityEngine.GameObject::get_transform(v805);\n\tv797 = UnityEngine.Transform::get_position(v806);\n\tv872 = UnityEngine.Screen::get_width();\n\tv807 = UnityEngine.Component::get_gameObject(fsm);\n\tv808 = UnityEngine.GameObject::get_transform(v807);\n\tv888 = v797 * v872;\n\tv891 = UnityEngine.Transform::get_position(v808);\n\tv905 = UnityEngine.Screen::get_height();\n\tv522 = v891.y * v905;\nL_0141:\n\tv937 = UnityEngine.Screen::get_height();\n\tgoto L_015A;\n\tv942 = *([v938 @ X8_v32 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv943 = v942 == 0;\n\tv944 = ~v943;\n\tgoto L_015A;\n\tv958 = v938;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v958, v465, v299, v48, v49, v50, v51, v52, v925, v923, v919, v917, v430, v208, v59, v60);\n\tv949 = PlayMakerGUI;\nL_015A:\n\tgoto L_0161;\n\tv959 = *([v952 @ X0_v49+E0]);\n\tv960 = v959 == 0;\n\tv961 = ~v960;\n\tgoto L_0161;\n\tv963 = \"il2cpp_codegen_runtime_class_init\"(v952, v465, v299, v48, v49, v50, v51, v52, v925, v923, v919, v917, v430, v208, v59, v60);\nL_0161:\n\tv967 = UnityEngine.GUI::get_backgroundColor();\n\tv515 = UnityEngine.GUI::get_color();\n\tv538 = fsm.fsm;\n\tv538.owner = fsm;\n\tv526 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm.fsm);\n\tv990 = v526 == 0;\n\tif (v990) goto L_FFFFFFFF;\n\tv539 = fsm.fsm;\n\tv539.owner = fsm;\n\tv811 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm.fsm);\n\tv379 = v811.colorIndex;\n\tgoto L_0191;\nL_0191:\n\tgoto L_0197;\n\tv1002 = *([v998 @ X0_v56 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv1003 = v1002 == 0;\n\tv1004 = ~v1003;\n\tgoto L_0197;\n\tv1006 = \"il2cpp_codegen_runtime_class_init\"(v998, v651, v299, v48, v49, v50, v51, v52, v515, v510, v453, v446, v430, v208, v59, v60);\nL_0197:\n\tv653 = PlayMakerPrefs::get_Colors();\n\tv1008 = v379 < v653.Length;\n\tv345 = ~v1008;\n\tif (v345) goto L_02A6;\n\tv252 = v379 << 4;\n\tv1011 = v653 + v252;\n\tv1012 = v951.fsmLabelIndex * -15f;\n\tv248 = v937 - v522;\n\tv1016 = v1012 * this.labelScale;\n\tv363 = v248 + v1016;\n\tv245 = 0;\n\tv1020 = 0x101059C(&v245 @ stack_-90_v2, 0, 0, v48, v49, v50, v51, v52, *([v1011 @ X8_v44+20]), v653[v379 @ X19_v7 (System.Byte)].g, v653[v379 @ X19_v7 (System.Byte)].b, 0.5f, v248, v876.z, v59, v60);\n\tgoto L_01C5;\n\tv1025 = *([v1021 @ X0_v61+E0]);\n\tv1026 = v1025 == 0;\n\tv1027 = ~v1026;\n\tif (v1027) goto L_01C5;\n\tv1029 = \"il2cpp_codegen_runtime_class_init\"(v1021, v1019, v299, v48, v49, v50, v51, v52, v1013, v1014, v1015, v1017, v248, v208, v59, v60);\nL_01C5:\n\t// 453 MakeStruct v239 @ AGGE59064_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v1034 @ stack_-8C, 0, v1037 @ stack_-84\n\tUnityEngine.GUI::set_backgroundColor(v239);\n\tv1040 = UnityEngine.Color::get_white();\n\tUnityEngine.GUI::set_contentColor(v1040);\n\tv233 = 0;\n\tv1051 = 0x10CCF64(&v233 @ stack_-A0_v2, 0, 0, v48, v49, v50, v51, v52, v278, v363, v796, v835.y, v248, v876.z, v59, v60);\n\tgoto L_01EB;\n\tv1056 = *([v1052 @ X0_v68 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv1057 = v1056 == 0;\n\tv1058 = ~v1057;\n\tif (v1058) goto L_01EB;\n\tv1069 = \"il2cpp_codegen_runtime_class_init\"(v1052, v1050, v299, v48, v49, v50, v51, v52, v1045, v1047, v1048, v1049, v248, v208, v59, v60);\n\tv1060 = PlayMakerGUI;\nL_01EB:\n\t// 491 MakeStruct v180 @ AGGE590CC_0_v2 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v1064 @ stack_-9C, 0, v1067 @ stack_-94\n\tUnityEngine.GUI::Label(v180, v755, v381.stateLabelStyle);\n\tUnityEngine.GUI::set_backgroundColor(v967);\n\tUnityEngine.GUI::set_color(v515);\nL_020C:\n\treturn;\nL_020E:\n\tv8\n// ... truncated")]
	private void DrawStateLabel(PlayMakerFSM fsm)
	{
		//IL_0402: Expected O, but got I
		//IL_044c: Expected O, but got I4
		//IL_0476: Expected F4, but got O
		//IL_0491: Expected F4, but got O
		//IL_04ba: Expected O, but got I4
		//IL_0748: Expected F4, but got O
		//IL_0763: Expected F4, but got O
		if (stateLabelStyle != null)
		{
			float f = initLabelScale - labelScale;
			float num = Mathf.Abs(f);
			if (!(num > 0.1f))
			{
				goto IL_0057;
			}
		}
		InitLabelStyle();
		goto IL_0057;
		IL_0057:
		Camera main = Camera.main;
		if (main == null)
		{
			return;
		}
		GameObject gameObject = fsm.gameObject;
		Camera main2 = Camera.main;
		if (gameObject == main2)
		{
			return;
		}
		GameObject gameObject2 = fsm.gameObject;
		if (gameObject2 == labelGameObject)
		{
			float num2 = fsmLabelIndex + 1f;
			fsmLabelIndex = num2;
		}
		else
		{
			fsmLabelIndex = 0f;
			GameObject gameObject3 = fsm.gameObject;
			labelGameObject = gameObject3;
		}
		string text = GenerateStateLabel(fsm);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		labelContent.text = text;
		Vector2 vector = stateLabelStyle.CalcSize(labelContent);
		float min = labelScale * 10f;
		float max = labelScale * 200f;
		float num3 = Mathf.Clamp(vector.x, min, max);
		float num5;
		if (GUITextureStateLabels || GUITextStateLabels)
		{
			GameObject gameObject4 = fsm.gameObject;
			Transform transform = gameObject4.transform;
			Vector3 position = transform.position;
			int width = Screen.width;
			GameObject gameObject5 = fsm.gameObject;
			Transform transform2 = gameObject5.transform;
			float num4 = position.x * (float)width;
			Vector3 position2 = transform2.position;
			int height = Screen.height;
			num5 = position2.y * (float)height;
			float num6 = num4;
		}
		else
		{
			if (filterLabelsWithDistance)
			{
				Camera main3 = Camera.main;
				Transform transform3 = main3.transform;
				Vector3 position3 = transform3.position;
				Transform transform4 = fsm.transform;
				Vector3 position4 = transform4.position;
				float num7 = Vector3.Distance(position3, position4);
				if (num7 > maxLabelDistance)
				{
					return;
				}
			}
			Camera main4 = Camera.main;
			Transform transform5 = main4.transform;
			Transform transform6 = fsm.transform;
			Vector3 position5 = transform6.position;
			Vector3 vector2 = transform5.InverseTransformPoint(position5);
			bool flag = vector2.z < 0f;
			bool flag2 = !flag;
			bool flag3 = vector2.z == 0f;
			bool flag4 = !flag2;
			if (flag4 || flag3)
			{
				return;
			}
			Camera main5 = Camera.main;
			Transform transform7 = fsm.transform;
			Vector3 position6 = transform7.position;
			Vector3 vector3 = main5.WorldToScreenPoint(position6);
			Vector2 vector4 = vector3;
			float num8 = num3 * -0.5f;
			float num9 = vector4.x + num8;
			float num6 = num9;
			num5 = vector4.y;
		}
		int height2 = Screen.height;
		Color backgroundColor = GUI.backgroundColor;
		Color color = GUI.color;
		Fsm fsm2 = fsm.fsm;
		fsm2.Owner = fsm;
		FsmState activeState = fsm.fsm.ActiveState;
		byte b;
		if (activeState != null)
		{
			Fsm fsm3 = fsm.fsm;
			fsm3.Owner = fsm;
			FsmState activeState2 = fsm.fsm.ActiveState;
			b = activeState2.colorIndex;
		}
		else
		{
			b = 0;
		}
		Color[] colors = PlayMakerPrefs.Colors;
		if (b < colors.Length)
		{
			int num10 = b << 4;
			object obj = (long)(IntPtr)colors + (long)num10;
			float num11 = fsmLabelIndex * -15f;
			float num12 = (float)height2 - num5;
			float num13 = num11 * labelScale;
			float num14 = num12 + num13;
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color backgroundColor2 = default(Color);
			backgroundColor2.r = 0f;
			object obj3 = default(object);
			backgroundColor2.g = (float)obj3;
			backgroundColor2.b = 0f;
			object obj4 = default(object);
			backgroundColor2.a = (float)obj4;
			GUI.backgroundColor = backgroundColor2;
			Color white = Color.white;
			GUI.contentColor = white;
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect position7 = default(Rect);
			position7.x = 0f;
			object obj6 = default(object);
			position7.y = (float)obj6;
			position7.width = 0f;
			object obj7 = default(object);
			position7.height = (float)obj7;
			GUI.Label(position7, text, stateLabelStyle);
			GUI.backgroundColor = backgroundColor;
			GUI.color = color;
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000097")]
	[Address(RVA = "0xE592B4", Offset = "0xE592B4", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EACAD0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202480F]) = v38;\nL_0015:\n\tv40 = fsm.fsm;\n\tv40.owner = fsm;\n\tv45 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm.fsm);\n\tv63 = v45 == 0;\n\tif (v63) goto L_FFFFFFFF;\n\tv49 = fsm.fsm;\n\tv49.owner = fsm;\n\tv57 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm.fsm);\n\tv75 = v57 + 0x40;\n\tgoto L_0035;\nL_0035:\n\treturn *([v75 @ X8_v6 (System.String)]);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static string GenerateStateLabel(PlayMakerFSM fsm)
	{
		//IL_00a2: Expected O, but got I
		Fsm fsm2 = fsm.fsm;
		fsm2.Owner = fsm;
		FsmState activeState = fsm.fsm.ActiveState;
		if (activeState != null)
		{
			Fsm fsm3 = fsm.fsm;
			fsm3.Owner = fsm;
			FsmState activeState2 = fsm.fsm.ActiveState;
			return (string)((long)(IntPtr)activeState2 + 64L);
		}
		return "[DISABLED]";
	}

	[Token(Token = "0x6000098")]
	[Address(RVA = "0xE593C0", Offset = "0xE593C0", Length = "0x110")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECA870]);\n\tv21 = *([v20 @ X8_v22]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024810]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = PlayMakerGUI;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(v56.instance, 0);\n\tv76 = v73 == 0;\n\tif (v76) goto L_0051;\n\tgoto L_0043;\n\tv87 = *([v77 @ X0_v11 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_0043;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv91 = PlayMakerGUI;\nL_0043:\n\tv94.instance = this;\n\treturn;\nL_0051:\n\tgoto L_0061;\n\tv100 = *([v83 @ X0_v7+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0061;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v83, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0061:\n\tUnityEngine.Debug::LogWarning(\"There should only be one PlayMakerGUI per scene!\");\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		if (!(instance == null))
		{
			Debug.LogWarning("There should only be one PlayMakerGUI per scene!");
		}
		else
		{
			instance = this;
		}
	}

	[Token(Token = "0x6000099")]
	[Address(RVA = "0xE594D0", Offset = "0xE594D0", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void OnEnable()
	{
	}

	[Token(Token = "0x600009A")]
	[Address(RVA = "0xE594D4", Offset = "0xE594D4", Length = "0xB98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\tgoto L_0021;\n\tv42 = *([1EC8F98]);\n\tv43 = *([v42 @ X8_v241]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([2024811]) = v62;\nL_0021:\n\t*([v32 @ X29_v1-D0]) = 0;\n\t*([v32 @ X29_v1-C0]) = 0;\n\t*([v32 @ X29_v1-F0]) = 0;\n\t*([v32 @ X29_v1-E0]) = 0;\n\tUnityEngine.MonoBehaviour::set_useGUILayout(this, this.enableGUILayout);\n\tgoto L_0049;\n\tv89 = *([v85 @ X0_v3+E0]);\n\tv90 = v89 == 0;\n\tv91 = ~v90;\n\tgoto L_0049;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v85, v80, v82, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_0049:\n\tgoto L_0054;\n\tv101 = *([1ECF9A0]);\n\tv102 = *([v101 @ X8_v237]);\n\tv103 = \"il2cpp_codegen_initialize_method\"(v102, v80, v82, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv106 = 0 | 1;\n\t*([2024862]) = v106;\nL_0054:\n\tgoto L_0063;\n\tv111 = *([v107 @ X0_v6 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0063;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v107, v80, v82, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv115 = PlayMakerGUI;\nL_0063:\n\tgoto L_006D;\n\tv127 = *([v121 @ X8_v9+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tgoto L_006D;\n\tv138 = v121;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v138, v80, v82, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_006D:\n\tv137 = UnityEngine.Object::op_Inequality(v120.guiSkin, 0);\n\tv140 = v137 == 0;\n\tif (v140) goto L_00A6;\n\tgoto L_007E;\n\tv163 = *([v141 @ X0_v231+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_007E;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v141, v135, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_007E:\n\tgoto L_0089;\n\tv185 = *([1ECF9A0]);\n\tv186 = *([v185 @ X8_v232]);\n\tv187 = \"il2cpp_codegen_initialize_method\"(v186, v135, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv190 = 0 | 1;\n\t*([2024862]) = v190;\nL_0089:\n\tgoto L_0098;\n\tv206 = *([v191 @ X0_v234 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv207 = v206 == 0;\n\tv208 = ~v207;\n\tgoto L_0098;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v191, v135, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv210 = PlayMakerGUI;\nL_0098:\n\tgoto L_00A1;\n\tv237 = *([v156 @ X8_v229+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\tgoto L_00A1;\n\tv256 = v156;\n\tv241 = \"il2cpp_codegen_runtime_class_init\"(v256, v135, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_00A1:\n\tUnityEngine.GUI::set_skin(v215.guiSkin);\nL_00A6:\n\tgoto L_00B0;\n\tv173 = *([v159 @ X0_v12+E0]);\n\tv174 = v173 == 0;\n\tv175 = ~v174;\n\tif (v175) goto L_00B0;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v159, v147, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_00B0:\n\tgoto L_00BB;\n\tv196 = *([1ED9F68]);\n\tv197 = *([v196 @ X8_v218]);\n\tv198 = \"il2cpp_codegen_initialize_method\"(v197, v147, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv201 = 0 | 1;\n\t*([2024863]) = v201;\nL_00BB:\n\tgoto L_00CD;\n\tv218 = *([v202 @ X0_v15 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv219 = v218 == 0;\n\tv220 = ~v219;\n\tgoto L_00CD;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v202, v147, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\n\tv222 = PlayMakerGUI;\nL_00CD:\n\tgoto L_00D9;\n\tv243 = *([v230 @ X0_v17+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tgoto L_00D9;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v230, v147, v136, v47, v48, v49, v50, v51, v63, v53, v54, v55, v56, v57, v58, v59);\nL_00D9:\n\tUnityEngine.GUI::set_color(v226.guiColor);\n\tgoto L_00E9;\n\tv262 = *([1EDF088]);\n\tv263 = *([v262 @ X8_v213]);\n\tv264 = \"il2cpp_codegen_initialize_method\"(v263, v147, v136, v47, v48, v49, v50, v51, v250, v251, v252, v253, v56, v57, v58, v59);\n\tv267 = 0 | 1;\n\t*([2024864]) = v267;\nL_00E9:\n\tgoto L_00F7;\n\tv272 = *([v268 @ X0_v21 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\tgoto L_00F7;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v268, v147, v136, v47, v48, v49, v50, v51, v250, v251, v252, v253, v56, v57, v58, v59);\n\tv276 = PlayMakerGUI;\nL_00F7:\n\tUnityEngine.GUI::set_backgroundColor(v279.guiBackgroundColor);\n\tgoto L_0107;\n\tv292 = *([1EC09B8]);\n\tv293 = *([v292 @ X8_v209]);\n\tv294 = \"il2cpp_codegen_initialize_method\"(v293, v147, v136, v47, v48, v49, v50, v51, v281, v282, v283, v284, v56, v57, v58, v59);\n\tv297 = 0 | 1;\n\t*([2024865]) = v297;\nL_0107:\n\tgoto L_0115;\n\tv302 = *([v298 @ X0_v25 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv303 = v302 == 0;\n\tv304 = ~v303;\n\tgoto L_0115;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v298, v147, v136, v47, v48, v49, v50, v51, v281, v282, v283, v284, v56, v57, v58, v59);\n\tv306 = PlayMakerGUI;\nL_0115:\n\tUnityEngine.GUI::set_contentColor(v309.guiContentColor);\n\tv318 = ~this.previewOnGUI;\n\tif (v318) goto L_0122;\n\tv320 = UnityEngine.Application::get_isPlaying();\n\tv323 = v320 == 0;\n\tif (v323) goto L_0369;\nL_0122:\n\tgoto L_0130;\n\tv329 = *([v324 @ X0_v30 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\t// 294 ConditionalJump @b247, v331 @ TEMP_v241\n\tv343 = \"il2cpp_codegen_runtime_class_init\"(v324, v147, v136, v47, v48, v49, v50, v51, v311, v312, v313, v314, v56, v57, v58, v59);\n\tv333 = PlayMakerGUI;\nL_0130:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::Clear(v336.fsmList);\n\tgoto L_0144;\n\tv696 = *([v586 @ X0_v38+E0]);\n\tv697 = v696 == 0;\n\tv698 = ~v697;\n\tif (v698) goto L_0144;\n\tv700 = \"il2cpp_codegen_runtime_class_init\"(v586, v346, v136, v47, v48, v49, v50, v51, v311, v312, v313, v314, v56, v57, v58, v59);\nL_0144:\n\tgoto L_014F;\n\tv879 = *([1F06658]);\n\tv880 = *([v879 @ X8_v199]);\n\tv881 = \"il2cpp_codegen_initialize_method\"(v880, v346, v136, v47, v48, v49, v50, v51, v311, v312, v313, v314, v56, v57, v58, v59);\n\tv884 = 0 | 1;\n\t*([2021A8F]) = v884;\nL_014F:\n\tgoto L_015E;\n\tv972 = *([v885 @ X0_v41 (Il2CppClass<PlayMakerFSM>)+E0]);\n\tv973 = v972 == 0;\n\tv974 = ~v973;\n\t// 339 Jump @b249\n\tv977 = \"il2cpp_codegen_runtime_class_init\"(v885, v346, v136, v47, v48, v49, v50, v51, v311, v312, v313, v314, v56, v57, v58, v59);\n\tv975 = PlayMakerFSM;\nL_015E:\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::AddRange(v585.fsmList, v979.fsmList);\n\tgoto L_01F7;\nL_0164:\n\tgoto L_0170;\n\tv1025 = *([v671 @ X0_v46 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv1026 = v1025 == 0;\n\tv1027 = ~v1026;\n\tif (v1027) goto L_0170;\n\tv1043 = PlayMakerGUI;\n\tv684 = *([v1043 @ X8_v194 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv693 = v684.fsmList;\nL_0170:\n\tv1033 = v1031._size < v498;\n\tv491 = ~v1033;\n\tv484 = v1031._size - v498;\n\tv470 = v484 == 0;\n\tv1034 = ~v470;\n\tv435 = v491 & v1034;\n\tif (v435) goto L_017E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_017E:\n\tv1038 = v1031._items;\n\tv570 = v1038[v498 @ X23_v7 (System.Int32)];\n\tgoto L_018F;\n\tv1044 = *([v1039 @ X0_v183+E0]);\n\tv1045 = v1044 == 0;\n\tv1046 = ~v1045;\n\tif (v1046) goto L_018F;\n\tv1048 = \"il2cpp_codegen_runtime_class_init\"(v1039, v520, v513, v47, v48, v49, v50, v51, v311, v312, v313, v314, v56, v57, v58, v59);\nL_018F:\n\tv666 = UnityEngine.Object::op_Equality(v1038[v498 @ X23_v7 (System.Int32)], 0);\n\tv1052 = v666 == 0;\n\tv1053 = ~v1052;\n\tif (v1053) goto L_01F2;\n\tv667 = PlayMakerFSM::get_Active(v1038[v498 @ X23_v7 (System.Int32)]);\n\tv1055 = v667 == 0;\n\tif (v1055) goto L_01F2;\n\tv561 = *([v570 @ X20_v20 (UnityEngine.Object)+18]);\n\t*([v561 @ X8_v181+20]) = v1038[v498 @ X23_v7 (System.Int32)];\n\tv668 = HutongGames.PlayMaker.Fsm::get_ActiveState(*([v570 @ X20_v20 (UnityEngine.Object)+18]));\n\tv1056 = v668 == 0;\n\tif (v1056) goto L_01F2;\n\tv686 = *([v570 @ X20_v20 (UnityEngine.Object)+18]);\n\t*([v686 @ X8_v182+20]) = v1038[v498 @ X23_v7 (System.Int32)];\n\tv687 = *([v570 @ X20_v20 (UnityEngine.Object)+18]);\n\tv1132 = *([v687 @ X8_v183+14B]) == 0;\n\tv1057 = ~v1132;\n\tif (v1057) goto L_01F2;\n\t*([v687 @ X8_v183+20]) = v1038[v498 @ X23_v7 (System.Int32)];\n\tPlayMakerGUI::CallOnGUI(v668, *([v570 @ X20_v20 (UnityEngine.Object)+18]));\n\tv562 = *([v570 @ X20_v20 (UnityEngine.Object)+18]);\nL_01B8:\n\t*([v562 @ X8_v185+20]) = v1038[v498 @ X23_v7 (System.Int32)];\n\tv541 = HutongGames.PlayMaker.Fsm::get_SubFsmList(*([v570 @ X20_v20 (UnityEngine.Object)+18]));\n\tv437 \n// ... truncated")]
	private unsafe void OnGUI()
	{
		//IL_01e6: Expected O, but got I
		//IL_04f1: Expected O, but got F4
		//IL_0502: Expected F4, but got O
		//IL_050b: Expected O, but got Ref
		//IL_020f: Expected O, but got I
		//IL_0240: Expected O, but got I
		//IL_0263: Expected O, but got I
		//IL_0539: Expected O, but got I
		//IL_0549: Expected O, but got I
		//IL_0559: Expected F4, but got I
		//IL_0569: Expected O, but got I
		//IL_0712: Expected O, but got I
		//IL_0722: Expected O, but got I
		//IL_0732: Expected F4, but got I
		//IL_0742: Expected O, but got I
		//IL_02bb: Expected O, but got I
		//IL_02cb: Expected O, but got I
		//IL_08c6: Expected F4, but got I
		//IL_078e: Expected F4, but got I
		//IL_02ef: Expected O, but got I
		//IL_079c: Expected O, but got Ref
		//IL_032c: Expected O, but got I
		//IL_091c: Expected I, but got O
		//IL_092a: Expected I, but got O
		//IL_0962: Expected O, but got I
		//IL_0355: Expected O, but got I
		//IL_0660: Expected O, but got I
		//IL_068b: Expected F4, but got I
		//IL_06a0: Expected F4, but got I
		//IL_06b5: Expected F4, but got I
		//IL_06ca: Expected F4, but got I
		//IL_06df: Expected F4, but got I
		object obj2 = default(object);
		object obj = obj2;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		base.useGUILayout = enableGUILayout;
		if (guiSkin != null)
		{
			GUI.skin = guiSkin;
		}
		GUI.color = guiColor;
		GUI.backgroundColor = guiBackgroundColor;
		GUI.contentColor = guiContentColor;
		if (!previewOnGUI || Application.isPlaying)
		{
			fsmList.Clear();
			fsmList.AddRange(PlayMakerFSM.fsmList);
			int num = 0;
			while (true)
			{
				List<PlayMakerFSM> list = fsmList;
				if (num >= list.Count)
				{
					break;
				}
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				PlayMakerFSM[] items = list._items;
				UnityEngine.Object obj3 = items[num];
				if (!(items[num] == null) && items[num].Active)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
					object obj4 = 0;
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
					FsmState activeState = ((Fsm)0).ActiveState;
					if (activeState != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
						object obj5 = 0;
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ X8_v183+14B]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							_ = items[num];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
							((PlayMakerGUI)(object)activeState).CallOnGUI((Fsm)0);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
							object obj7 = 0;
							int num3 = 0;
							while (true)
							{
								_ = items[num];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
								List<Fsm> subFsmList = ((Fsm)0).SubFsmList;
								if (num3 >= subFsmList.Count)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
								object obj8 = 0;
								_ = items[num];
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
								List<Fsm> subFsmList2 = ((Fsm)0).SubFsmList;
								bool flag5 = subFsmList2.Count < num3;
								bool flag6 = !flag5;
								int num4 = subFsmList2.Count - num3;
								bool flag7 = num4 == 0;
								bool flag8 = !flag7;
								bool flag9 = flag6 && flag8;
								PlayMakerGUI playMakerGUI = (PlayMakerGUI)(object)subFsmList2;
								if (!flag9)
								{
									throw new ArgumentOutOfRangeException();
								}
								Fsm[] items2 = subFsmList2._items;
								playMakerGUI.CallOnGUI(items2[num3]);
								num3++;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X20_v20 (UnityEngine.Object)+18]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									throw new NullReferenceException();
								}
							}
						}
					}
				}
				num++;
			}
			if (!Application.isPlaying)
			{
				return;
			}
			Event current = Event.current;
			EventType type = current.type;
			if (type != EventType.Repaint)
			{
				return;
			}
			Matrix4x4 matrix = GUI.matrix;
			float num5 = default(float);
			object obj9 = num5;
			Matrix4x4 identity = Matrix4x4.identity;
			num5 = (float)obj9;
			GUI.matrix = (Matrix4x4)(&num5);
			bool flag10 = MouseCursor != null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-90]");
			object obj10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-80]");
			object obj11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-B0]");
			float num6 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A0]");
			object obj12 = 0;
			if (flag10)
			{
				Vector3 mousePosition = Input.mousePosition;
				int width = MouseCursor.width;
				int height = Screen.height;
				Vector3 mousePosition2 = Input.mousePosition;
				int height2 = MouseCursor.height;
				int width2 = MouseCursor.width;
				int height3 = MouseCursor.height;
				float num7 = (float)width * 0.5f;
				num6 = (float)height - mousePosition2.y;
				float num8 = (float)height2 * 0.5f;
				float num9 = mousePosition.x - num7;
				float num10 = num6 - num8;
				object obj13 = (long)(IntPtr)obj2 - 176L;
				_ = 0;
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A4]");
				num6 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-B0]");
				Rect position = default(Rect);
				position.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-AC]");
				position.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A8]");
				position.width = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A4]");
				position.height = 0f;
				GUI.DrawTexture(position, MouseCursor);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-90]");
				obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-80]");
				obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-B0]");
				num6 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A0]");
				obj12 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-F0]");
			num6 = 0f;
			if (drawStateLabels)
			{
				if (EnableStateLabels)
				{
					DrawStateLabels();
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-F0]");
				num6 = 0f;
			}
			GUI.matrix = (Matrix4x4)(&num6);
			Matrix4x4 identity2 = Matrix4x4.identity;
			_ = identity2.m02;
			_ = identity2.m03;
			_ = identity2.m00;
			_ = identity2.m01;
			IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
			IntPtr intPtr2 = (IntPtr)fsmList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-80]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-90]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-A0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-B0]");
			guiMatrix = (Matrix4x4)0;
			if (controlMouseCursor)
			{
				Cursor.lockState = (LockCursor ? CursorLockMode.Locked : CursorLockMode.None);
				bool visible = !HideCursor;
				Cursor.visible = visible;
			}
		}
		else
		{
			DoEditGUI();
		}
	}

	[Token(Token = "0x600009B")]
	[Address(RVA = "0xE5A1C0", Offset = "0xE5A1C0", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm);\n\tv67 = v15 == 0;\n\tif (v67) goto L_004F;\n\tv89 = HutongGames.PlayMaker.Fsm::get_ActiveState(fsm);\n\tv90 = HutongGames.PlayMaker.FsmState::get_Actions(v89);\n\tv55 = v90.Length;\n\tv119 = v90.Length < 1;\n\tif (v119) goto L_004F;\nL_0026:\n\tv190 = v26 < v55;\n\tv52 = ~v190;\n\tif (v52) goto L_0050;\n\tv91 = v90[v26 @ X20_v6 (System.Int32)];\n\tv152 = ~v91.active;\n\tif (v152) goto L_003C;\n\tv196 = HutongGames.PlayMaker.FsmStateAction::OnGUI(v90[v26 @ X20_v6 (System.Int32)]);\nL_003C:\n\tv55 = v90.Length;\n\tv26 = v26 + 1;\n\tv118 = v26 < v90.Length;\n\tif (v118) goto L_0026;\nL_004F:\n\treturn;\nL_0050:\n\tv191 = new System.IndexOutOfRangeException();\n\tthrow v191;\n\tthrow System.NullReferenceException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void CallOnGUI(Fsm fsm)
	{
		FsmState activeState = fsm.ActiveState;
		if (activeState == null)
		{
			return;
		}
		FsmState activeState2 = fsm.ActiveState;
		FsmStateAction[] actions = activeState2.Actions;
		int num = actions.Length;
		if (actions.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (num2 < num)
		{
			FsmStateAction fsmStateAction = actions[num2];
			if (fsmStateAction.Active)
			{
				actions[num2].OnGUI();
			}
			num = actions.Length;
			num2++;
			if (num2 >= actions.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600009C")]
	[Address(RVA = "0xE5A274", Offset = "0xE5A274", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ECA990]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024812]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = PlayMakerGUI;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(v56.instance, this);\n\tv76 = v73 == 0;\n\tif (v76) goto L_004A;\n\tgoto L_0043;\n\tv92 = *([v77 @ X0_v8 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = PlayMakerGUI;\nL_0043:\n\tv86.instance = 0;\nL_004A:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		if (instance == this)
		{
			instance = null;
		}
	}

	[Token(Token = "0x600009D")]
	[Address(RVA = "0xE5A06C", Offset = "0xE5A06C", Length = "0x154")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv16 = *([1EC9360]);\n\tv17 = *([v16 @ X8_v28]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2024813]) = v37;\nL_0018:\n\tgoto L_0020;\n\tv44 = *([v40 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tgoto L_0020;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v40, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = PlayMakerGUI;\nL_0020:\n\tv122 = v51.SelectedFSM;\n\tv53 = v51.SelectedFSM == 0;\n\tif (v53) goto L_0039;\n\tgoto L_0032;\n\tv132 = *([v47 @ X0_v3 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0032;\n\tv136 = PlayMakerGUI;\n\tv182 = *([v136 @ X0_v25 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv139 = v182.SelectedFSM;\nL_0032:\n\tv115 = ~v122.handleOnGUI;\n\tif (v115) goto L_003D;\nL_0039:\n\treturn;\nL_003D:\n\tgoto L_0049;\n\tv183 = *([v109 @ X0_v8 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv184 = v183 == 0;\n\tv185 = ~v184;\n\tif (v185) goto L_0049;\n\tv210 = PlayMakerGUI;\n\tv211 = *([v210 @ X8_v20 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv189 = v211.SelectedFSM;\nL_0049:\n\tv116 = v122.editState == 0;\n\tif (v116) goto L_0039;\n\tv111 = HutongGames.PlayMaker.FsmState::get_IsInitialized(v122.editState);\n\tv117 = v111 == 0;\n\tif (v117) goto L_0039;\n\tv112 = HutongGames.PlayMaker.FsmState::get_Actions(v122.editState);\n\tv254 = v112.Length;\n\tv63 = v112.Length < 1;\n\tif (v63) goto L_0039;\nL_0065:\n\tv264 = v238 < v254;\n\tv234 = ~v264;\n\tif (v234) goto L_008B;\n\tv242 = v112[v238 @ X20_v7 (System.Int32)];\n\tv119 = ~v242.enabled;\n\tif (v119) goto L_007B;\n\tv269 = HutongGames.PlayMaker.FsmStateAction::OnGUI(v112[v238 @ X20_v7 (System.Int32)]);\nL_007B:\n\tv254 = v112.Length;\n\tv238 = v238 + 1;\n\tv64 = v238 < v112.Length;\n\tif (v64) goto L_0065;\n\tgoto L_0039;\n\tv247 = new System.NullReferenceException();\nL_008B:\n\tv255 = new System.IndexOutOfRangeException();\n\tthrow v255;\n\tthrow System.NullReferenceException;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void DoEditGUI()
	{
		Fsm selectedFSM = SelectedFSM;
		if (SelectedFSM == null || selectedFSM.HandleOnGUI || selectedFSM.EditState == null || !selectedFSM.EditState.IsInitialized)
		{
			return;
		}
		FsmStateAction[] actions = selectedFSM.EditState.Actions;
		int num = actions.Length;
		if (actions.Length < 1)
		{
			return;
		}
		int num2 = 0;
		while (num2 < num)
		{
			FsmStateAction fsmStateAction = actions[num2];
			if (fsmStateAction.Enabled)
			{
				actions[num2].OnGUI();
			}
			num = actions.Length;
			num2++;
			if (num2 >= actions.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x600009E")]
	[Address(RVA = "0xE5A344", Offset = "0xE5A344", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F088F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024814]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerGUI;\nL_001F:\n\tv49.instance = 0;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnApplicationQuit()
	{
		instance = null;
	}

	[Token(Token = "0x600009F")]
	[Address(RVA = "0xE5A3AC", Offset = "0xE5A3AC", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.previewOnGUI = 0x101;\n\tthis.drawStateLabels = 1;\n\tthis.maxLabelDistance = 10f;\n\tthis.controlMouseCursor = 1;\n\tthis.labelScale = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerGUI()
	{
		previewOnGUI = true;
		enableGUILayout = true;
		drawStateLabels = true;
		maxLabelDistance = 10f;
		controlMouseCursor = true;
		labelScale = 1f;
	}

	[Token(Token = "0x60000A0")]
	[Address(RVA = "0xE5A3D8", Offset = "0xE5A3D8", Length = "0x168")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA58D0]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2024815]) = v41;\nL_0017:\n\tv45 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v45);\n\tv53.fsmList = v45;\n\tv57 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v57);\n\tv61.labelContent = v57;\n\tv63 = new System.Collections.Generic.List`1<PlayMakerFSM>();\n\tSystem.Collections.Generic.List`1<PlayMakerFSM>::.ctor(v63);\n\tv68.SortedFsmList = v63;\n\tv69 = UnityEngine.Color::get_white();\n\tv73 = PlayMakerGUI;\n\tv75 = *([v73 @ X8_v11 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv75.guiColor = v69;\n\t*([v75 @ X8_v12 (Il2CppStaticFields<PlayMakerGUI>)+44]) = v69.g;\n\t*([v75 @ X8_v12 (Il2CppStaticFields<PlayMakerGUI>)+48]) = v69.b;\n\t*([v75 @ X8_v12 (Il2CppStaticFields<PlayMakerGUI>)+4C]) = v69.a;\n\tv76 = UnityEngine.Color::get_white();\n\tv80 = PlayMakerGUI;\n\tv82 = *([v80 @ X8_v13 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv82.guiBackgroundColor = v76;\n\t*([v82 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+54]) = v76.g;\n\t*([v82 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+58]) = v76.b;\n\t*([v82 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+5C]) = v76.a;\n\tv83 = UnityEngine.Color::get_white();\n\tv87 = PlayMakerGUI;\n\tv88 = *([v87 @ X8_v15 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv88.guiContentColor = v83;\n\t*([v88 @ X8_v16 (Il2CppStaticFields<PlayMakerGUI>)+64]) = v83.g;\n\t*([v88 @ X8_v16 (Il2CppStaticFields<PlayMakerGUI>)+68]) = v83.b;\n\t*([v88 @ X8_v16 (Il2CppStaticFields<PlayMakerGUI>)+6C]) = v83.a;\n\tgoto L_0063;\n\tv95 = *([v91 @ X0_v11+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_0063;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v91, v64, v24, v25, v26, v27, v28, v29, v83, v84, v85, v86, v34, v35, v36, v37);\nL_0063:\n\tv105 = UnityEngine.Matrix4x4::get_identity();\n\tv122 = PlayMakerGUI;\n\tv124 = *([v122 @ X8_v22 (Il2CppClass<PlayMakerGUI>)+B8]);\n\t*([v124 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+A0]) = v105.m03;\n\t*([v124 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+90]) = v105.m02;\n\t*([v124 @ X8_v23 (Il2CppStaticFields<PlayMakerGUI>)+80]) = v105.m01;\n\tv124.guiMatrix = v105.m00;\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static PlayMakerGUI()
	{
		//IL_0042: Expected I, but got O
		//IL_004b: Expected I, but got O
		//IL_0089: Expected I, but got O
		//IL_0092: Expected I, but got O
		//IL_00d5: Expected I, but got O
		//IL_00de: Expected I, but got O
		//IL_0121: Expected I, but got O
		//IL_012a: Expected I, but got O
		//IL_0156: Expected O, but got F4
		List<PlayMakerFSM> list = new List<PlayMakerFSM>();
		fsmList = list;
		GUIContent gUIContent = new GUIContent();
		labelContent = gUIContent;
		List<PlayMakerFSM> sortedFsmList = new List<PlayMakerFSM>();
		SortedFsmList = sortedFsmList;
		Color white = Color.white;
		IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
		IntPtr intPtr2 = (IntPtr)fsmList;
		guiColor = white;
		_ = white.g;
		_ = white.b;
		_ = white.a;
		Color white2 = Color.white;
		IntPtr intPtr3 = (IntPtr)typeof(PlayMakerGUI);
		IntPtr intPtr4 = (IntPtr)fsmList;
		guiBackgroundColor = white2;
		_ = white2.g;
		_ = white2.b;
		_ = white2.a;
		Color white3 = Color.white;
		IntPtr intPtr5 = (IntPtr)typeof(PlayMakerGUI);
		IntPtr intPtr6 = (IntPtr)fsmList;
		guiContentColor = white3;
		_ = white3.g;
		_ = white3.b;
		_ = white3.a;
		Matrix4x4 identity = Matrix4x4.identity;
		IntPtr intPtr7 = (IntPtr)typeof(PlayMakerGUI);
		IntPtr intPtr8 = (IntPtr)fsmList;
		_ = identity.m03;
		_ = identity.m02;
		_ = identity.m01;
		guiMatrix = (Matrix4x4)identity.m00;
	}
}
