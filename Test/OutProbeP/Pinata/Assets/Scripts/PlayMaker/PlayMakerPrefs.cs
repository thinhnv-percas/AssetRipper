using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public class PlayMakerPrefs : ScriptableObject
{
	[Token(Token = "0x4000003")]
	private static PlayMakerPrefs instance;

	[Token(Token = "0x4000004")]
	private static readonly Color[] defaultColors;

	[Token(Token = "0x4000005")]
	private static readonly string[] defaultColorNames;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73ED7C", Offset = "0x73ED7C")]
	[SerializeField]
	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x18")]
	private bool logPerformanceWarnings;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73EDC8", Offset = "0x73EDC8")]
	[SerializeField]
	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x19")]
	private bool showEventHandlerComponents;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73EE14", Offset = "0x73EE14")]
	[SerializeField]
	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x20")]
	private Color[] colors;

	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x73EE60", Offset = "0x73EE60")]
	[SerializeField]
	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x28")]
	private string[] colorNames;

	[SerializeField]
	[Token(Token = "0x400000A")]
	[FieldOffset(Offset = "0x30")]
	private Color tweenFromColor;

	[SerializeField]
	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x40")]
	private Color tweenToColor;

	[Token(Token = "0x400000C")]
	private static Color[] minimapColors;

	[Token(Token = "0x17000002")]
	public static PlayMakerPrefs Instance
	{
		[Token(Token = "0x6000005")]
		[Address(RVA = "0xE5C1CC", Offset = "0xE5C1CC", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA3B88]);\n\tv19 = *([v18 @ X8_v32]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2024837]) = v39;\nL_0019:\n\tgoto L_0028;\n\tv46 = *([v42 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = PlayMakerPrefs;\nL_0028:\n\tgoto L_0032;\n\tv62 = *([v56 @ X8_v5+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tgoto L_0032;\n\tv73 = v56;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v73, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tv72 = UnityEngine.Object::op_Equality(v55.instance, 0);\n\tv75 = v72 == 0;\n\tif (v75) goto L_0099;\n\tv80 = UnityEngine.Resources::Load(\"PlayMakerPrefs\");\n\tgoto L_0049;\n\tv161 = *([v142 @ X8_v13 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv162 = v161 == 0;\n\tv163 = ~v162;\n\tif (v163) goto L_0049;\n\tv173 = v142;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v173, v78, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv169 = PlayMakerPrefs;\nL_0049:\n\tv171 = v80 == 0;\n\tif (v171) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_006D;\n\tv211 = v211_asT == 0;\n\tif (v211) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tv170.instance = v212;\n\tgoto L_007E;\n\tv220 = *([v216 @ X0_v16+E0]);\n\tv221 = v220 == 0;\n\tv222 = ~v221;\n\tgoto L_007E;\n\tv224 = \"il2cpp_codegen_runtime_class_init\"(v216, v78, v71, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007E:\n\tv128 = UnityEngine.Object::op_Equality(v217.instance, 0);\n\tv131 = v128 == 0;\n\tif (v131) goto L_0099;\n\tv231 = UnityEngine.ScriptableObject::CreateInstance();\n\tgoto L_0094;\n\tv236 = *([v232 @ X8_v21 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv237 = v236 == 0;\n\tv238 = ~v237;\n\tif (v238) goto L_0094;\n\tv242 = v232;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v242, v122, v120, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv241 = PlayMakerPrefs;\nL_0094:\n\tv133.instance = v231;\nL_0099:\n\tgoto L_00A8;\n\tv147 = *([v138 @ X0_v8 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv148 = v147 == 0;\n\tv149 = ~v148;\n\tgoto L_00A8;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v138, v121, v119, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = PlayMakerPrefs;\nL_00A8:\n\treturn v154.instance;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if (instance == null)
			{
				UnityEngine.Object obj = Resources.Load("PlayMakerPrefs");
				UnityEngine.Object obj2;
				if ((object)obj == null)
				{
					obj2 = null;
				}
				else
				{
					PlayMakerPrefs playMakerPrefs = obj as PlayMakerPrefs;
					obj2 = (((object)playMakerPrefs == null) ? null : obj);
				}
				instance = (PlayMakerPrefs)obj2;
				if (instance == null)
				{
					PlayMakerPrefs playMakerPrefs2 = ScriptableObject.CreateInstance<PlayMakerPrefs>();
					instance = playMakerPrefs2;
				}
			}
			return instance;
		}
	}

	[Token(Token = "0x17000003")]
	public static bool LogPerformanceWarnings
	{
		[Token(Token = "0x6000006")]
		[Address(RVA = "0xE55E54", Offset = "0xE55E54", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEA610]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024838]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.logPerformanceWarnings;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.logPerformanceWarnings;
		}
		[Token(Token = "0x6000007")]
		[Address(RVA = "0xE5C380", Offset = "0xE5C380", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F04090]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024839]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = PlayMakerPrefs::get_Instance();\n\tv52.logPerformanceWarnings = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.logPerformanceWarnings = value;
		}
	}

	[Token(Token = "0x17000004")]
	public static bool ShowEventHandlerComponents
	{
		[Token(Token = "0x6000008")]
		[Address(RVA = "0xE5C3F4", Offset = "0xE5C3F4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF9260]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202483A]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.showEventHandlerComponents;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.showEventHandlerComponents;
		}
		[Token(Token = "0x6000009")]
		[Address(RVA = "0xE5C460", Offset = "0xE5C460", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEEE20]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202483B]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = PlayMakerPrefs::get_Instance();\n\tv52.showEventHandlerComponents = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.showEventHandlerComponents = value;
		}
	}

	[Token(Token = "0x17000005")]
	public static Color TweenFromColor
	{
		[Token(Token = "0x600000A")]
		[Address(RVA = "0xE5C4D4", Offset = "0xE5C4D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB1E80]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202483C]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.tweenFromColor;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.tweenFromColor;
		}
		[Token(Token = "0x600000B")]
		[Address(RVA = "0xE5C544", Offset = "0xE5C544", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EA6B18]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202483D]) = v47;\nL_0022:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\nL_0028:\n\tv61 = PlayMakerPrefs::get_Instance();\n\tv61.tweenFromColor = value;\n\tv61.tweenFromColor.g = value.g;\n\tv61.tweenFromColor.b = value.b;\n\tv61.tweenFromColor.a = value.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.tweenFromColor = value;
			playMakerPrefs.tweenFromColor.g = value.g;
			playMakerPrefs.tweenFromColor.b = value.b;
			playMakerPrefs.tweenFromColor.a = value.a;
		}
	}

	[Token(Token = "0x17000006")]
	public static Color TweenToColor
	{
		[Token(Token = "0x600000C")]
		[Address(RVA = "0xE5C5D4", Offset = "0xE5C5D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB66B8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202483E]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, returnVal2, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.tweenToColor;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.tweenToColor;
		}
		[Token(Token = "0x600000D")]
		[Address(RVA = "0xE5C644", Offset = "0xE5C644", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EB2390]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([202483F]) = v47;\nL_0022:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, value, v0, v2, v3, v40, v41, v42, v43);\nL_0028:\n\tv61 = PlayMakerPrefs::get_Instance();\n\tv61.tweenToColor = value;\n\tv61.tweenToColor.g = value.g;\n\tv61.tweenToColor.b = value.b;\n\tv61.tweenToColor.a = value.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.tweenToColor = value;
			playMakerPrefs.tweenToColor.g = value.g;
			playMakerPrefs.tweenToColor.b = value.b;
			playMakerPrefs.tweenToColor.a = value.a;
		}
	}

	[Token(Token = "0x17000007")]
	public static Color[] Colors
	{
		[Token(Token = "0x600000E")]
		[Address(RVA = "0xE59354", Offset = "0xE59354", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED5DB0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024840]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.colors;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.colors;
		}
		[Token(Token = "0x600000F")]
		[Address(RVA = "0xE5C6D4", Offset = "0xE5C6D4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB95B0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024841]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = PlayMakerPrefs::get_Instance();\n\tv52.colors = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.colors = value;
		}
	}

	[Token(Token = "0x17000008")]
	public static string[] ColorNames
	{
		[Token(Token = "0x6000010")]
		[Address(RVA = "0xE5C744", Offset = "0xE5C744", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECEED0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024842]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = PlayMakerPrefs::get_Instance();\n\treturn v49.colorNames;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			return playMakerPrefs.colorNames;
		}
		[Token(Token = "0x6000011")]
		[Address(RVA = "0xE5C7B0", Offset = "0xE5C7B0", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0CA10]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024843]) = v38;\nL_0019:\n\tgoto L_001F;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_001F;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001F:\n\tv52 = PlayMakerPrefs::get_Instance();\n\tv52.colorNames = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			PlayMakerPrefs playMakerPrefs = Instance;
			playMakerPrefs.colorNames = value;
		}
	}

	[Token(Token = "0x17000009")]
	public static Color[] MinimapColors
	{
		[Token(Token = "0x6000013")]
		[Address(RVA = "0xE5CA18", Offset = "0xE5CA18", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBC628]);\n\tv15 = *([v14 @ X8_v17]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024845]) = v35;\nL_0017:\n\tgoto L_0020;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0020;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = PlayMakerPrefs;\nL_0020:\n\tv51 = v49.minimapColors == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0031;\n\tgoto L_002C;\n\tv66 = *([v45 @ X0_v3 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002C;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v45, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002C:\n\tPlayMakerPrefs::UpdateMinimapColors();\nL_0031:\n\tgoto L_003E;\n\tv71 = *([v57 @ X0_v4 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_003E;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v57, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv75 = PlayMakerPrefs;\nL_003E:\n\treturn v78.minimapColors;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if (minimapColors == null)
			{
				UpdateMinimapColors();
			}
			return minimapColors;
		}
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0xE5C820", Offset = "0xE5C820", Length = "0x1F8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = *([1EDA280]);\n\tv27 = *([v26 @ X8_v32]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2024844]) = v46;\nL_001F:\n\tv54 = 0;\n\tv57 = 0x10105A8(&v54 @ stack_-50_v1 (System.Single), 0, v30, v31, v32, v33, v34, v35, 0.9372549f, 0.34509805f, 0.007843138f, v39, v40, v41, v42, v43);\n\tthis.tweenFromColor.r = 0f;\n\tthis.tweenFromColor.g = v60;\n\tthis.tweenFromColor.a = v62;\n\tv64 = 0;\n\tv73 = 0x10105A8(&v64 @ stack_-60_v1 (System.Single), 0, v30, v31, v32, v33, v34, v35, 0.99215686f, 0.5882353f, 0.015686275f, v39, v40, v41, v42, v43);\n\tthis.tweenToColor.r = 0f;\n\tthis.tweenToColor.g = v76;\n\tthis.tweenToColor.a = v78;\n\tgoto L_00A2;\nL_003E:\n\tv221 = this.colors;\n\tgoto L_0065;\n\tv205 = *([v145 @ X0_v8 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv261 = v205 == 0;\n\tv262 = ~v261;\n\t// 69 ConditionalJump @b11, v262 @ TEMP_v23 (System.Boolean)\n\tv317 = PlayMakerPrefs;\n\tv318 = *([v317 @ X8_v27 (Il2CppClass<PlayMakerPrefs>)+B8]);\n\tv217 = v318.defaultColors;\nL_0065:\n\tv320 = v122 << 4;\n\tv321 = v218 + v320;\n\tv169 = v122 << 4;\n\tv207 = this.colors + v169;\n\t*([v207 @ X9_v15+20]) = *([v321 @ X8_v17+20]);\n\tv221[v122 @ X21_v2 (System.Int32)].g = v218[v122 @ X21_v2 (System.Int32)].g;\n\tv221[v122 @ X21_v2 (System.Int32)].b = v218[v122 @ X21_v2 (System.Int32)].b;\n\tv221[v122 @ X21_v2 (System.Int32)].a = v218[v122 @ X21_v2 (System.Int32)].a;\n\tv219 = v324.defaultColorNames;\n\tv86 = this.colorNames;\n\tv327 = v219[v122 @ X21_v2 (System.Int32)] == 0;\n\tif (v327) goto L_009C;\n\t// 140 IsInst v314 @ X0_v21, typeof(System.String), v219[v122 @ X21_v2 (System.Int32)]\n\tv315 = v314 == 0;\n\tif (v315) goto L_00CA;\nL_009C:\n\tv123 = v122 + 1;\n\tv86[v122 @ X21_v2 (System.Int32)] = v219[v122 @ X21_v2 (System.Int32)];\nL_00A2:\n\tgoto L_00AA;\n\tv142 = *([v138 @ X0_v7 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tgoto L_00AA;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v138, v124, v30, v31, v32, v33, v34, v35, v68, v69, v70, v39, v40, v41, v42, v43);\n\tv146 = PlayMakerPrefs;\nL_00AA:\n\tv218 = v149.defaultColors;\n\tv83 = v122 < v218.Length;\n\tif (v83) goto L_003E;\n\treturn;\n\tv223 = new System.NullReferenceException();\n\tv260 = new System.IndexOutOfRangeException();\nL_00C9:\n\tv311 = new System.TypeLoadException();\nL_00CA:\n\tv302 = new System.ArrayTypeMismatchException();\n\tgoto L_00C9;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ResetDefaultColors()
	{
		//IL_01e4: Expected F4, but got O
		//IL_022a: Expected F4, but got O
		//IL_0030: Expected O, but got I
		//IL_004e: Expected O, but got I
		float num = 0f;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
		tweenFromColor.r = 0f;
		object obj = default(object);
		tweenFromColor.g = (float)obj;
		float a = default(float);
		tweenFromColor.a = a;
		float num2 = 0f;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
		tweenToColor.r = 0f;
		object obj2 = default(object);
		tweenToColor.g = (float)obj2;
		float a2 = default(float);
		tweenToColor.a = a2;
		int num3 = 0;
		while (true)
		{
			Color[] array = defaultColors;
			if (num3 >= array.Length)
			{
				return;
			}
			Color[] array2 = colors;
			int num4 = num3 << 4;
			object obj3 = (long)(IntPtr)array + (long)num4;
			int num5 = num3 << 4;
			object obj4 = (long)(IntPtr)colors + (long)num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v321 @ X8_v17+20]");
			_ = 0;
			array2[num3].g = array[num3].g;
			array2[num3].b = array[num3].b;
			array2[num3].a = array[num3].a;
			string[] array3 = defaultColorNames;
			string[] array4 = colorNames;
			if (array3[num3] != null)
			{
				object obj5 = array3[num3] as string;
				if (obj5 == null)
				{
					break;
				}
			}
			int num6 = num3 + 1;
			array4[num3] = array3[num3];
			num3 = num6;
		}
		while (true)
		{
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			TypeLoadException ex2 = new TypeLoadException();
		}
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0xE5CC34", Offset = "0xE5CC34", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF6FE0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024846]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tPlayMakerPrefs::UpdateMinimapColors();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void SaveChanges()
	{
		UpdateMinimapColors();
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0xE5CAC0", Offset = "0xE5CAC0", Length = "0x174")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EEA810]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2024847]) = v43;\nL_001B:\n\tgoto L_0021;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0021:\n\tv57 = PlayMakerPrefs::get_Colors();\n\t// 41 NewArr v64 @ X0_v11 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v57.Length\n\tv168.minimapColors = v64;\n\tgoto L_006E;\nL_0035:\n\tgoto L_003B;\n\tv287 = *([v283 @ X0_v16 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_003B;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v283, v151, v26, v27, v28, v29, v30, v31, v93, v90, v87, v84, v36, v37, v38, v39);\nL_003B:\n\tv154 = PlayMakerPrefs::get_Colors();\n\tv294 = v148 < v154.Length;\n\tv204 = ~v294;\n\tif (v204) goto L_008D;\n\tv186 = v148 << 4;\n\tv206 = v154 + v186;\n\tv176 = v216.minimapColors;\n\tv174 = 0;\n\tv212 = 0x101059C(&v174 @ stack_-50_v5, 0, v26, v27, v28, v29, v30, v31, *([v206 @ X9_v6+20]), v154[v148 @ X20_v4 (System.Int32)].g, v154[v148 @ X20_v4 (System.Int32)].b, 0.5f, v36, v37, v38, v39);\n\tv301 = v148 < v176.Length;\n\tv228 = ~v301;\n\tif (v228) goto L_008D;\n\tv220 = v148 << 4;\n\tv234 = v176 + v220;\n\tv148 = v148 + 1;\n\t*([v234 @ X8_v22+20]) = 0;\nL_006E:\n\tgoto L_0074;\n\tv238 = *([v230 @ X0_v13 (Il2CppClass<PlayMakerPrefs>)+E0]);\n\tv239 = v238 == 0;\n\tv240 = ~v239;\n\tgoto L_0074;\n\tv242 = \"il2cpp_codegen_runtime_class_init\"(v230, v151, v26, v27, v28, v29, v30, v31, v93, v90, v87, v84, v36, v37, v38, v39);\nL_0074:\n\tv155 = PlayMakerPrefs::get_Colors();\n\tv68 = v148 < v155.Length;\n\tif (v68) goto L_0035;\n\treturn;\nL_008D:\n\tv300 = new System.IndexOutOfRangeException();\n\tthrow v300;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void UpdateMinimapColors()
	{
		//IL_0092: Expected O, but got I
		//IL_00a4: Expected O, but got I4
		//IL_00fd: Expected O, but got I
		Color[] array = Colors;
		Color[] array2 = new Color[array.Length];
		minimapColors = array2;
		int num = 0;
		while (true)
		{
			Color[] array3 = Colors;
			if (num < array3.Length)
			{
				Color[] array4 = Colors;
				if (num >= array4.Length)
				{
					break;
				}
				int num2 = num << 4;
				object obj = (long)(IntPtr)array4 + (long)num2;
				Color[] array5 = minimapColors;
				object obj2 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
				if (num >= array5.Length)
				{
					break;
				}
				int num3 = num << 4;
				object obj3 = (long)(IntPtr)array5 + (long)num3;
				num++;
				_ = 0;
				continue;
			}
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0xE5CC90", Offset = "0xE5CC90", Length = "0x96C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_0019;\n\tv28 = *([1ECB1C8]);\n\tv29 = *([v28 @ X8_v122]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2024848]) = v48;\nL_0019:\n\tthis.logPerformanceWarnings = 1;\n\t// 30 NewArr v54 @ X0_v3 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 24\n\tv57 = UnityEngine.Color::get_grey();\n\tv63 = v54.Length == 0;\n\tif (v63) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+20]) = v57;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+24]) = v57.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+28]) = v57.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+2C]) = v57.a;\n\tv164 = &v19 @ stack_-10_v2 - 0x50;\n\t*([v18 @ X29_v1-50]) = 0;\n\t*([v18 @ X29_v1-48]) = 0;\n\tv167 = 0x10105A8(v164, 0, v32, v33, v34, v35, v36, v37, 0.54509807f, 0.67058825f, 0.9411765f, v57.a, v42, v43, v44, v45);\n\tv937 = v54.Length < 1;\n\tv581 = ~v937;\n\tv534 = v54.Length - 1;\n\tv440 = v534 == 0;\n\tv938 = ~v581;\n\tv205 = v938 | v440;\n\tif (v205) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+30]) = *([v18 @ X29_v1-50]);\n\tv941 = &v19 @ stack_-10_v2 - 0x60;\n\t*([v18 @ X29_v1-60]) = 0;\n\t*([v18 @ X29_v1-58]) = 0;\n\tv774 = 0x10105A8(v941, 0, v32, v33, v34, v35, v36, v37, 0.24313726f, 0.7607843f, 0.6901961f, v57.a, v42, v43, v44, v45);\n\tv1027 = v54.Length < 2;\n\tv582 = ~v1027;\n\tv535 = v54.Length - 2;\n\tv441 = v535 == 0;\n\tv1028 = ~v582;\n\tv206 = v1028 | v441;\n\tif (v206) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+40]) = *([v18 @ X29_v1-60]);\n\tv199 = 0;\n\tv775 = 0x10105A8(&v199 @ stack_-80_v5, 0, v32, v33, v34, v35, v36, v37, 0.43137255f, 0.7607843f, 0.24313726f, v57.a, v42, v43, v44, v45);\n\tv1032 = v54.Length < 3;\n\tv583 = ~v1032;\n\tv536 = v54.Length - 3;\n\tv442 = v536 == 0;\n\tv1033 = ~v583;\n\tv207 = v1033 | v442;\n\tif (v207) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+50]) = 0;\n\tv193 = 0;\n\tv776 = 0x10105A8(&v193 @ stack_-90_v5, 0, v32, v33, v34, v35, v36, v37, 1f, 0.8745098f, 0.1882353f, v57.a, v42, v43, v44, v45);\n\tv1037 = v54.Length < 4;\n\tv584 = ~v1037;\n\tv537 = v54.Length - 4;\n\tv443 = v537 == 0;\n\tv1038 = ~v584;\n\tv208 = v1038 | v443;\n\tif (v208) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+60]) = 0;\n\tv189 = 0;\n\tv777 = 0x10105A8(&v189 @ stack_-A0_v5, 0, v32, v33, v34, v35, v36, v37, 1f, 0.5529412f, 0.1882353f, v57.a, v42, v43, v44, v45);\n\tv1042 = v54.Length < 5;\n\tv585 = ~v1042;\n\tv538 = v54.Length - 5;\n\tv444 = v538 == 0;\n\tv1043 = ~v585;\n\tv209 = v1043 | v444;\n\tif (v209) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+70]) = 0;\n\tv185 = 0;\n\tv778 = 0x10105A8(&v185 @ stack_-B0_v5, 0, v32, v33, v34, v35, v36, v37, 0.7607843f, 0.24313726f, 0.2509804f, v57.a, v42, v43, v44, v45);\n\tv1047 = v54.Length < 6;\n\tv586 = ~v1047;\n\tv539 = v54.Length - 6;\n\tv445 = v539 == 0;\n\tv1048 = ~v586;\n\tv210 = v1048 | v445;\n\tif (v210) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+80]) = 0;\n\tv181 = 0;\n\tv779 = 0x10105A8(&v181 @ stack_-C0_v5, 0, v32, v33, v34, v35, v36, v37, 0.54509807f, 0.24313726f, 0.7607843f, v57.a, v42, v43, v44, v45);\n\tv1051 = v54.Length < 7;\n\tv587 = ~v1051;\n\tv540 = v54.Length - 7;\n\tv446 = v540 == 0;\n\tv1052 = ~v587;\n\tv211 = v1052 | v446;\n\tif (v211) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+90]) = 0;\n\tv757 = UnityEngine.Color::get_grey();\n\tv1054 = v54.Length < 8;\n\tv588 = ~v1054;\n\tv541 = v54.Length - 8;\n\tv447 = v541 == 0;\n\tv1055 = ~v588;\n\tv212 = v1055 | v447;\n\tif (v212) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+A0]) = v757;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+A4]) = v757.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+A8]) = v757.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+AC]) = v757.a;\n\tv758 = UnityEngine.Color::get_grey();\n\tv1056 = v54.Length < 9;\n\tv589 = ~v1056;\n\tv542 = v54.Length - 9;\n\tv448 = v542 == 0;\n\tv1057 = ~v589;\n\tv213 = v1057 | v448;\n\tif (v213) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+B0]) = v758;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+B4]) = v758.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+B8]) = v758.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+BC]) = v758.a;\n\tv759 = UnityEngine.Color::get_grey();\n\tv1058 = v54.Length < 0xA;\n\tv590 = ~v1058;\n\tv543 = v54.Length - 0xA;\n\tv449 = v543 == 0;\n\tv1059 = ~v590;\n\tv214 = v1059 | v449;\n\tif (v214) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+C0]) = v759;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+C4]) = v759.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+C8]) = v759.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+CC]) = v759.a;\n\tv760 = UnityEngine.Color::get_grey();\n\tv1060 = v54.Length < 0xB;\n\tv591 = ~v1060;\n\tv544 = v54.Length - 0xB;\n\tv450 = v544 == 0;\n\tv1061 = ~v591;\n\tv215 = v1061 | v450;\n\tif (v215) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+D0]) = v760;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+D4]) = v760.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+D8]) = v760.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+DC]) = v760.a;\n\tv761 = UnityEngine.Color::get_grey();\n\tv1062 = v54.Length < 0xC;\n\tv592 = ~v1062;\n\tv545 = v54.Length - 0xC;\n\tv451 = v545 == 0;\n\tv1063 = ~v592;\n\tv216 = v1063 | v451;\n\tif (v216) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+E0]) = v761;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+E4]) = v761.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+E8]) = v761.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+EC]) = v761.a;\n\tv762 = UnityEngine.Color::get_grey();\n\tv1064 = v54.Length < 0xD;\n\tv593 = ~v1064;\n\tv546 = v54.Length - 0xD;\n\tv452 = v546 == 0;\n\tv1065 = ~v593;\n\tv217 = v1065 | v452;\n\tif (v217) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+F0]) = v762;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+F4]) = v762.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+F8]) = v762.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+FC]) = v762.a;\n\tv763 = UnityEngine.Color::get_grey();\n\tv1066 = v54.Length < 0xE;\n\tv594 = ~v1066;\n\tv547 = v54.Length - 0xE;\n\tv453 = v547 == 0;\n\tv1067 = ~v594;\n\tv218 = v1067 | v453;\n\tif (v218) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+100]) = v763;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+104]) = v763.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+108]) = v763.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+10C]) = v763.a;\n\tv764 = UnityEngine.Color::get_grey();\n\tv1068 = v54.Length < 0xF;\n\tv595 = ~v1068;\n\tv548 = v54.Length - 0xF;\n\tv454 = v548 == 0;\n\tv1069 = ~v595;\n\tv219 = v1069 | v454;\n\tif (v219) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+110]) = v764;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+114]) = v764.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+118]) = v764.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+11C]) = v764.a;\n\tv765 = UnityEngine.Color::get_grey();\n\tv1070 = v54.Length < 0x10;\n\tv596 = ~v1070;\n\tv549 = v54.Length - 0x10;\n\tv455 = v549 == 0;\n\tv1071 = ~v596;\n\tv220 = v1071 | v455;\n\tif (v220) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+120]) = v765;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+124]) = v765.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+128]) = v765.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+12C]) = v765.a;\n\tv766 = UnityEngine.Color::get_grey();\n\tv1072 = v54.Length < 0x11;\n\tv597 = ~v1072;\n\tv550 = v54.Length - 0x11;\n\tv456 = v550 == 0;\n\tv1073 = ~v597;\n\tv221 = v1073 | v456;\n\tif (v221) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+130]) = v766;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+134]) = v766.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+138]) = v766.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+13C]) = v766.a;\n\tv767 = UnityEngine.Color::get_grey();\n\tv1074 = v54.Length < 0x12;\n\tv598 = ~v1074;\n\tv551 = v54.Length - 0x12;\n\tv457 = v551 == 0;\n\tv1075 = ~v598;\n\tv222 = v1075 | v457;\n\tif (v222) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+140]) = v767;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+144]) = v767.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+148]) = v767.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+14C]) = v767.a;\n\tv768 = UnityEngine.Color::get_grey();\n\tv1076 = v54.Length < 0x13;\n\tv599 = ~v1076;\n\tv552 = v54.Length - 0x13;\n\tv458 = v552 == 0;\n\tv1077 = ~v599;\n\tv223 = v1077 | v458;\n\tif (v223) goto L_04A8;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+150]) = v768;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+154]) = v768.g;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+158]) = v768.b;\n\t*([v54 @ X0_v3 (UnityEngine.Color[])+15C]) = v768.a;\n\tv769 = UnityEngine.Color::get_grey();\n\tv1078 = v54.Length < 0x14;\n\tv600 = ~v1078;\n\tv5\n// ... truncated")]
	public PlayMakerPrefs()
	{
		//IL_0064: Expected O, but got I
		//IL_00ab: Expected O, but got I4
		//IL_00fc: Expected O, but got I
		//IL_0143: Expected O, but got I4
		//IL_018e: Expected O, but got I4
		//IL_01c9: Expected O, but got I4
		//IL_020d: Expected O, but got I4
		//IL_0248: Expected O, but got I4
		//IL_028c: Expected O, but got I4
		//IL_02c7: Expected O, but got I4
		//IL_030b: Expected O, but got I4
		//IL_0346: Expected O, but got I4
		//IL_038a: Expected O, but got I4
		//IL_03c5: Expected O, but got I4
		//IL_0435: Expected O, but got I4
		//IL_04c2: Expected O, but got I4
		//IL_054f: Expected O, but got I4
		//IL_05dc: Expected O, but got I4
		//IL_0669: Expected O, but got I4
		//IL_06f6: Expected O, but got I4
		//IL_0783: Expected O, but got I4
		//IL_0810: Expected O, but got I4
		//IL_089d: Expected O, but got I4
		//IL_092a: Expected O, but got I4
		//IL_09b7: Expected O, but got I4
		//IL_0a44: Expected O, but got I4
		//IL_0ad1: Expected O, but got I4
		//IL_0b5e: Expected O, but got I4
		//IL_0beb: Expected O, but got I4
		//IL_0c78: Expected O, but got I4
		//IL_0d28: Expected O, but got I4
		//IL_15ce: Expected O, but got I
		//IL_0d95: Expected O, but got I4
		//IL_162c: Expected O, but got I
		//IL_0de8: Expected O, but got I4
		//IL_168a: Expected O, but got I
		//IL_0e3b: Expected O, but got I4
		//IL_16e8: Expected O, but got I
		//IL_0e8e: Expected O, but got I4
		//IL_1746: Expected O, but got I
		//IL_0ee1: Expected O, but got I4
		//IL_17a4: Expected O, but got I
		//IL_0f34: Expected O, but got I4
		//IL_1802: Expected O, but got I
		//IL_0f87: Expected O, but got I4
		//IL_1860: Expected O, but got I
		//IL_0fda: Expected O, but got I4
		//IL_18be: Expected O, but got I
		//IL_102d: Expected O, but got I4
		//IL_191c: Expected O, but got I
		//IL_1080: Expected O, but got I4
		//IL_197a: Expected O, but got I
		//IL_10d3: Expected O, but got I4
		//IL_19d8: Expected O, but got I
		//IL_1126: Expected O, but got I4
		//IL_1a36: Expected O, but got I
		//IL_1179: Expected O, but got I4
		//IL_1a94: Expected O, but got I
		//IL_11cc: Expected O, but got I4
		//IL_1af2: Expected O, but got I
		//IL_121f: Expected O, but got I4
		//IL_1b50: Expected O, but got I
		//IL_1272: Expected O, but got I4
		//IL_1bae: Expected O, but got I
		//IL_12c5: Expected O, but got I4
		//IL_1c0c: Expected O, but got I
		//IL_1318: Expected O, but got I4
		//IL_1c6a: Expected O, but got I
		//IL_136b: Expected O, but got I4
		//IL_1cc8: Expected O, but got I
		//IL_13be: Expected O, but got I4
		//IL_1d26: Expected O, but got I
		//IL_1411: Expected O, but got I4
		//IL_1d84: Expected O, but got I
		//IL_1464: Expected O, but got I4
		//IL_1de2: Expected O, but got I
		//IL_1510: Expected F4, but got O
		//IL_14b7: Expected O, but got I4
		//IL_155b: Expected F4, but got O
		base._002Ector();
		object obj2 = default(object);
		object obj = obj2;
		logPerformanceWarnings = true;
		Color[] array = new Color[24];
		Color grey = Color.grey;
		if (array.Length != 0)
		{
			_ = grey.g;
			_ = grey.b;
			_ = grey.a;
			object obj3 = (long)(IntPtr)obj2 - 80L;
			_ = 0;
			_ = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj4 = array.Length - 1;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-50]");
				_ = 0;
				object obj5 = (long)(IntPtr)obj2 - 96L;
				_ = 0;
				_ = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj6 = array.Length - 2;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-60]");
					_ = 0;
					object obj7 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
					bool flag9 = array.Length < 3;
					bool flag10 = !flag9;
					object obj8 = array.Length - 3;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						_ = 0;
						object obj9 = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
						bool flag13 = array.Length < 4;
						bool flag14 = !flag13;
						object obj10 = array.Length - 4;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							_ = 0;
							object obj11 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
							bool flag17 = array.Length < 5;
							bool flag18 = !flag17;
							object obj12 = array.Length - 5;
							bool flag19 = obj12 == null;
							bool flag20 = !flag18;
							if (!(flag20 || flag19))
							{
								_ = 0;
								object obj13 = 0;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
								bool flag21 = array.Length < 6;
								bool flag22 = !flag21;
								object obj14 = array.Length - 6;
								bool flag23 = obj14 == null;
								bool flag24 = !flag22;
								if (!(flag24 || flag23))
								{
									_ = 0;
									object obj15 = 0;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
									bool flag25 = array.Length < 7;
									bool flag26 = !flag25;
									object obj16 = array.Length - 7;
									bool flag27 = obj16 == null;
									bool flag28 = !flag26;
									if (!(flag28 || flag27))
									{
										_ = 0;
										Color grey2 = Color.grey;
										bool flag29 = array.Length < 8;
										bool flag30 = !flag29;
										object obj17 = array.Length - 8;
										bool flag31 = obj17 == null;
										bool flag32 = !flag30;
										if (!(flag32 || flag31))
										{
											_ = grey2.g;
											_ = grey2.b;
											_ = grey2.a;
											Color grey3 = Color.grey;
											bool flag33 = array.Length < 9;
											bool flag34 = !flag33;
											object obj18 = array.Length - 9;
											bool flag35 = obj18 == null;
											bool flag36 = !flag34;
											if (!(flag36 || flag35))
											{
												_ = grey3.g;
												_ = grey3.b;
												_ = grey3.a;
												Color grey4 = Color.grey;
												bool flag37 = array.Length < 10;
												bool flag38 = !flag37;
												object obj19 = array.Length - 10;
												bool flag39 = obj19 == null;
												bool flag40 = !flag38;
												if (!(flag40 || flag39))
												{
													_ = grey4.g;
													_ = grey4.b;
													_ = grey4.a;
													Color grey5 = Color.grey;
													bool flag41 = array.Length < 11;
													bool flag42 = !flag41;
													object obj20 = array.Length - 11;
													bool flag43 = obj20 == null;
													bool flag44 = !flag42;
													if (!(flag44 || flag43))
													{
														_ = grey5.g;
														_ = grey5.b;
														_ = grey5.a;
														Color grey6 = Color.grey;
														bool flag45 = array.Length < 12;
														bool flag46 = !flag45;
														object obj21 = array.Length - 12;
														bool flag47 = obj21 == null;
														bool flag48 = !flag46;
														if (!(flag48 || flag47))
														{
															_ = grey6.g;
															_ = grey6.b;
															_ = grey6.a;
															Color grey7 = Color.grey;
															bool flag49 = array.Length < 13;
															bool flag50 = !flag49;
															object obj22 = array.Length - 13;
															bool flag51 = obj22 == null;
															bool flag52 = !flag50;
															if (!(flag52 || flag51))
															{
																_ = grey7.g;
																_ = grey7.b;
																_ = grey7.a;
																Color grey8 = Color.grey;
																bool flag53 = array.Length < 14;
																bool flag54 = !flag53;
																object obj23 = array.Length - 14;
																bool flag55 = obj23 == null;
																bool flag56 = !flag54;
																if (!(flag56 || flag55))
																{
																	_ = grey8.g;
																	_ = grey8.b;
																	_ = grey8.a;
																	Color grey9 = Color.grey;
																	bool flag57 = array.Length < 15;
																	bool flag58 = !flag57;
																	object obj24 = array.Length - 15;
																	bool flag59 = obj24 == null;
																	bool flag60 = !flag58;
																	if (!(flag60 || flag59))
																	{
																		_ = grey9.g;
																		_ = grey9.b;
																		_ = grey9.a;
																		Color grey10 = Color.grey;
																		bool flag61 = array.Length < 16;
																		bool flag62 = !flag61;
																		object obj25 = array.Length - 16;
																		bool flag63 = obj25 == null;
																		bool flag64 = !flag62;
																		if (!(flag64 || flag63))
																		{
																			_ = grey10.g;
																			_ = grey10.b;
																			_ = grey10.a;
																			Color grey11 = Color.grey;
																			bool flag65 = array.Length < 17;
																			bool flag66 = !flag65;
																			object obj26 = array.Length - 17;
																			bool flag67 = obj26 == null;
																			bool flag68 = !flag66;
																			if (!(flag68 || flag67))
																			{
																				_ = grey11.g;
																				_ = grey11.b;
																				_ = grey11.a;
																				Color grey12 = Color.grey;
																				bool flag69 = array.Length < 18;
																				bool flag70 = !flag69;
																				object obj27 = array.Length - 18;
																				bool flag71 = obj27 == null;
																				bool flag72 = !flag70;
																				if (!(flag72 || flag71))
																				{
																					_ = grey12.g;
																					_ = grey12.b;
																					_ = grey12.a;
																					Color grey13 = Color.grey;
																					bool flag73 = array.Length < 19;
																					bool flag74 = !flag73;
																					object obj28 = array.Length - 19;
																					bool flag75 = obj28 == null;
																					bool flag76 = !flag74;
																					if (!(flag76 || flag75))
																					{
																						_ = grey13.g;
																						_ = grey13.b;
																						_ = grey13.a;
																						Color grey14 = Color.grey;
																						bool flag77 = array.Length < 20;
																						bool flag78 = !flag77;
																						object obj29 = array.Length - 20;
																						bool flag79 = obj29 == null;
																						bool flag80 = !flag78;
																						if (!(flag80 || flag79))
																						{
																							_ = grey14.g;
																							_ = grey14.b;
																							_ = grey14.a;
																							Color grey15 = Color.grey;
																							bool flag81 = array.Length < 21;
																							bool flag82 = !flag81;
																							object obj30 = array.Length - 21;
																							bool flag83 = obj30 == null;
																							bool flag84 = !flag82;
																							if (!(flag84 || flag83))
																							{
																								_ = grey15.g;
																								_ = grey15.b;
																								_ = grey15.a;
																								Color grey16 = Color.grey;
																								bool flag85 = array.Length < 22;
																								bool flag86 = !flag85;
																								object obj31 = array.Length - 22;
																								bool flag87 = obj31 == null;
																								bool flag88 = !flag86;
																								if (!(flag88 || flag87))
																								{
																									_ = grey16.g;
																									_ = grey16.b;
																									_ = grey16.a;
																									Color grey17 = Color.grey;
																									bool flag89 = array.Length < 23;
																									bool flag90 = !flag89;
																									object obj32 = array.Length - 23;
																									bool flag91 = obj32 == null;
																									bool flag92 = !flag90;
																									if (!(flag92 || flag91))
																									{
																										_ = grey17.g;
																										_ = grey17.b;
																										_ = grey17.a;
																										colors = array;
																										string[] array2 = new string[24];
																										if ("Default" != null)
																										{
																											object obj33 = "Default" as string;
																										}
																										object obj34 = array2.Length;
																										if (array2.Length != 0)
																										{
																											array2[0] = "Default";
																											if ("Blue" != null)
																											{
																												object obj35 = "Blue" as string;
																												obj34 = array2.Length;
																											}
																											bool flag93 = (long)(IntPtr)obj34 < 1L;
																											bool flag94 = !flag93;
																											object obj36 = (long)(IntPtr)obj34 - 1L;
																											bool flag95 = obj36 == null;
																											bool flag96 = !flag94;
																											if (!(flag96 || flag95))
																											{
																												array2[1] = "Blue";
																												if ("Cyan" != null)
																												{
																													object obj37 = "Cyan" as string;
																													obj34 = array2.Length;
																												}
																												bool flag97 = (long)(IntPtr)obj34 < 2L;
																												bool flag98 = !flag97;
																												object obj38 = (long)(IntPtr)obj34 - 2L;
																												bool flag99 = obj38 == null;
																												bool flag100 = !flag98;
																												if (!(flag100 || flag99))
																												{
																													array2[2] = "Cyan";
																													if ("Green" != null)
																													{
																														object obj39 = "Green" as string;
																														obj34 = array2.Length;
																													}
																													bool flag101 = (long)(IntPtr)obj34 < 3L;
																													bool flag102 = !flag101;
																													object obj40 = (long)(IntPtr)obj34 - 3L;
																													bool flag103 = obj40 == null;
																													bool flag104 = !flag102;
																													if (!(flag104 || flag103))
																													{
																														array2[3] = "Green";
																														if ("Yellow" != null)
																														{
																															object obj41 = "Yellow" as string;
																															obj34 = array2.Length;
																														}
																														bool flag105 = (long)(IntPtr)obj34 < 4L;
																														bool flag106 = !flag105;
																														object obj42 = (long)(IntPtr)obj34 - 4L;
																														bool flag107 = obj42 == null;
																														bool flag108 = !flag106;
																														if (!(flag108 || flag107))
																														{
																															array2[4] = "Yellow";
																															if ("Orange" != null)
																															{
																																object obj43 = "Orange" as string;
																																obj34 = array2.Length;
																															}
																															bool flag109 = (long)(IntPtr)obj34 < 5L;
																															bool flag110 = !flag109;
																															object obj44 = (long)(IntPtr)obj34 - 5L;
																															bool flag111 = obj44 == null;
																															bool flag112 = !flag110;
																															if (!(flag112 || flag111))
																															{
																																array2[5] = "Orange";
																																if ("Red" != null)
																																{
																																	object obj45 = "Red" as string;
																																	obj34 = array2.Length;
																																}
																																bool flag113 = (long)(IntPtr)obj34 < 6L;
																																bool flag114 = !flag113;
																																object obj46 = (long)(IntPtr)obj34 - 6L;
																																bool flag115 = obj46 == null;
																																bool flag116 = !flag114;
																																if (!(flag116 || flag115))
																																{
																																	array2[6] = "Red";
																																	if ("Purple" != null)
																																	{
																																		object obj47 = "Purple" as string;
																																		obj34 = array2.Length;
																																	}
																																	bool flag117 = (long)(IntPtr)obj34 < 7L;
																																	bool flag118 = !flag117;
																																	object obj48 = (long)(IntPtr)obj34 - 7L;
																																	bool flag119 = obj48 == null;
																																	bool flag120 = !flag118;
																																	if (!(flag120 || flag119))
																																	{
																																		array2[7] = "Purple";
																																		if ("" != null)
																																		{
																																			object obj49 = "" as string;
																																			obj34 = array2.Length;
																																		}
																																		bool flag121 = (long)(IntPtr)obj34 < 8L;
																																		bool flag122 = !flag121;
																																		object obj50 = (long)(IntPtr)obj34 - 8L;
																																		bool flag123 = obj50 == null;
																																		bool flag124 = !flag122;
																																		if (!(flag124 || flag123))
																																		{
																																			array2[8] = "";
																																			if ("" != null)
																																			{
																																				object obj51 = "" as string;
																																				obj34 = array2.Length;
																																			}
																																			bool flag125 = (long)(IntPtr)obj34 < 9L;
																																			bool flag126 = !flag125;
																																			object obj52 = (long)(IntPtr)obj34 - 9L;
																																			bool flag127 = obj52 == null;
																																			bool flag128 = !flag126;
																																			if (!(flag128 || flag127))
																																			{
																																				array2[9] = "";
																																				if ("" != null)
																																				{
																																					object obj53 = "" as string;
																																					obj34 = array2.Length;
																																				}
																																				bool flag129 = (long)(IntPtr)obj34 < 10L;
																																				bool flag130 = !flag129;
																																				object obj54 = (long)(IntPtr)obj34 - 10L;
																																				bool flag131 = obj54 == null;
																																				bool flag132 = !flag130;
																																				if (!(flag132 || flag131))
																																				{
																																					array2[10] = "";
																																					if ("" != null)
																																					{
																																						object obj55 = "" as string;
																																						obj34 = array2.Length;
																																					}
																																					bool flag133 = (long)(IntPtr)obj34 < 11L;
																																					bool flag134 = !flag133;
																																					object obj56 = (long)(IntPtr)obj34 - 11L;
																																					bool flag135 = obj56 == null;
																																					bool flag136 = !flag134;
																																					if (!(flag136 || flag135))
																																					{
																																						array2[11] = "";
																																						if ("" != null)
																																						{
																																							object obj57 = "" as string;
																																							obj34 = array2.Length;
																																						}
																																						bool flag137 = (long)(IntPtr)obj34 < 12L;
																																						bool flag138 = !flag137;
																																						object obj58 = (long)(IntPtr)obj34 - 12L;
																																						bool flag139 = obj58 == null;
																																						bool flag140 = !flag138;
																																						if (!(flag140 || flag139))
																																						{
																																							array2[12] = "";
																																							if ("" != null)
																																							{
																																								object obj59 = "" as string;
																																								obj34 = array2.Length;
																																							}
																																							bool flag141 = (long)(IntPtr)obj34 < 13L;
																																							bool flag142 = !flag141;
																																							object obj60 = (long)(IntPtr)obj34 - 13L;
																																							bool flag143 = obj60 == null;
																																							bool flag144 = !flag142;
																																							if (!(flag144 || flag143))
																																							{
																																								array2[13] = "";
																																								if ("" != null)
																																								{
																																									object obj61 = "" as string;
																																									obj34 = array2.Length;
																																								}
																																								bool flag145 = (long)(IntPtr)obj34 < 14L;
																																								bool flag146 = !flag145;
																																								object obj62 = (long)(IntPtr)obj34 - 14L;
																																								bool flag147 = obj62 == null;
																																								bool flag148 = !flag146;
																																								if (!(flag148 || flag147))
																																								{
																																									array2[14] = "";
																																									if ("" != null)
																																									{
																																										object obj63 = "" as string;
																																										obj34 = array2.Length;
																																									}
																																									bool flag149 = (long)(IntPtr)obj34 < 15L;
																																									bool flag150 = !flag149;
																																									object obj64 = (long)(IntPtr)obj34 - 15L;
																																									bool flag151 = obj64 == null;
																																									bool flag152 = !flag150;
																																									if (!(flag152 || flag151))
																																									{
																																										array2[15] = "";
																																										if ("" != null)
																																										{
																																											object obj65 = "" as string;
																																											obj34 = array2.Length;
																																										}
																																										bool flag153 = (long)(IntPtr)obj34 < 16L;
																																										bool flag154 = !flag153;
																																										object obj66 = (long)(IntPtr)obj34 - 16L;
																																										bool flag155 = obj66 == null;
																																										bool flag156 = !flag154;
																																										if (!(flag156 || flag155))
																																										{
																																											array2[16] = "";
																																											if ("" != null)
																																											{
																																												object obj67 = "" as string;
																																												obj34 = array2.Length;
																																											}
																																											bool flag157 = (long)(IntPtr)obj34 < 17L;
																																											bool flag158 = !flag157;
																																											object obj68 = (long)(IntPtr)obj34 - 17L;
																																											bool flag159 = obj68 == null;
																																											bool flag160 = !flag158;
																																											if (!(flag160 || flag159))
																																											{
																																												array2[17] = "";
																																												if ("" != null)
																																												{
																																													object obj69 = "" as string;
																																													obj34 = array2.Length;
																																												}
																																												bool flag161 = (long)(IntPtr)obj34 < 18L;
																																												bool flag162 = !flag161;
																																												object obj70 = (long)(IntPtr)obj34 - 18L;
																																												bool flag163 = obj70 == null;
																																												bool flag164 = !flag162;
																																												if (!(flag164 || flag163))
																																												{
																																													array2[18] = "";
																																													if ("" != null)
																																													{
																																														object obj71 = "" as string;
																																														obj34 = array2.Length;
																																													}
																																													bool flag165 = (long)(IntPtr)obj34 < 19L;
																																													bool flag166 = !flag165;
																																													object obj72 = (long)(IntPtr)obj34 - 19L;
																																													bool flag167 = obj72 == null;
																																													bool flag168 = !flag166;
																																													if (!(flag168 || flag167))
																																													{
																																														array2[19] = "";
																																														if ("" != null)
																																														{
																																															object obj73 = "" as string;
																																															obj34 = array2.Length;
																																														}
																																														bool flag169 = (long)(IntPtr)obj34 < 20L;
																																														bool flag170 = !flag169;
																																														object obj74 = (long)(IntPtr)obj34 - 20L;
																																														bool flag171 = obj74 == null;
																																														bool flag172 = !flag170;
																																														if (!(flag172 || flag171))
																																														{
																																															array2[20] = "";
																																															if ("" != null)
																																															{
																																																object obj75 = "" as string;
																																																obj34 = array2.Length;
																																															}
																																															bool flag173 = (long)(IntPtr)obj34 < 21L;
																																															bool flag174 = !flag173;
																																															object obj76 = (long)(IntPtr)obj34 - 21L;
																																															bool flag175 = obj76 == null;
																																															bool flag176 = !flag174;
																																															if (!(flag176 || flag175))
																																															{
																																																array2[21] = "";
																																																if ("" != null)
																																																{
																																																	object obj77 = "" as string;
																																																	obj34 = array2.Length;
																																																}
																																																bool flag177 = (long)(IntPtr)obj34 < 22L;
																																																bool flag178 = !flag177;
																																																object obj78 = (long)(IntPtr)obj34 - 22L;
																																																bool flag179 = obj78 == null;
																																																bool flag180 = !flag178;
																																																if (!(flag180 || flag179))
																																																{
																																																	array2[22] = "";
																																																	if ("" != null)
																																																	{
																																																		object obj79 = "" as string;
																																																		obj34 = array2.Length;
																																																	}
																																																	bool flag181 = (long)(IntPtr)obj34 < 23L;
																																																	bool flag182 = !flag181;
																																																	object obj80 = (long)(IntPtr)obj34 - 23L;
																																																	bool flag183 = obj80 == null;
																																																	bool flag184 = !flag182;
																																																	if (!(flag184 || flag183))
																																																	{
																																																		array2[23] = "";
																																																		colorNames = array2;
																																																		float num = 0f;
																																																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
																																																		tweenFromColor.r = 0f;
																																																		object obj81 = default(object);
																																																		tweenFromColor.g = (float)obj81;
																																																		float a = default(float);
																																																		tweenFromColor.a = a;
																																																		float num2 = 0f;
																																																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
																																																		tweenToColor.r = 0f;
																																																		object obj82 = default(object);
																																																		tweenToColor.g = (float)obj82;
																																																		float a2 = default(float);
																																																		tweenToColor.a = a2;
																																																		return;
																																																	}
																																																}
																																															}
																																														}
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0xE5D5FC", Offset = "0xE5D5FC", Length = "0x414")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = &v19 @ stack_-10_v2;\n\tgoto L_001B;\n\tv26 = *([1EB2808]);\n\tv27 = *([v26 @ X8_v57]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([2024849]) = v47;\nL_001B:\n\t// 27 NewArr v52 @ X0_v3 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), 8\n\tv55 = UnityEngine.Color::get_grey();\n\tv61 = v52.Length == 0;\n\tif (v61) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+20]) = v55;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+24]) = v55.g;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+28]) = v55.b;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+2C]) = v55.a;\n\tv168 = &v19 @ stack_-10_v2 - 0x50;\n\t*([v18 @ X29_v1-50]) = 0;\n\t*([v18 @ X29_v1-48]) = 0;\n\tv171 = 0x10105A8(v168, 0, v30, v31, v32, v33, v34, v35, 0.54509807f, 0.67058825f, 0.9411765f, v55.a, v40, v41, v42, v43);\n\tv484 = v52.Length < 1;\n\tv334 = ~v484;\n\tv319 = v52.Length - 1;\n\tv289 = v319 == 0;\n\tv485 = ~v334;\n\tv214 = v485 | v289;\n\tif (v214) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+30]) = *([v18 @ X29_v1-50]);\n\tv208 = 0;\n\tv399 = 0x10105A8(&v208 @ stack_-70_v5, 0, v30, v31, v32, v33, v34, v35, 0.24313726f, 0.7607843f, 0.6901961f, v55.a, v40, v41, v42, v43);\n\tv556 = v52.Length < 2;\n\tv335 = ~v556;\n\tv320 = v52.Length - 2;\n\tv290 = v320 == 0;\n\tv557 = ~v335;\n\tv215 = v557 | v290;\n\tif (v215) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+40]) = 0;\n\tv204 = 0;\n\tv400 = 0x10105A8(&v204 @ stack_-80_v5, 0, v30, v31, v32, v33, v34, v35, 0.43137255f, 0.7607843f, 0.24313726f, v55.a, v40, v41, v42, v43);\n\tv561 = v52.Length < 3;\n\tv336 = ~v561;\n\tv321 = v52.Length - 3;\n\tv291 = v321 == 0;\n\tv562 = ~v336;\n\tv216 = v562 | v291;\n\tif (v216) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+50]) = 0;\n\tv198 = 0;\n\tv401 = 0x10105A8(&v198 @ stack_-90_v5, 0, v30, v31, v32, v33, v34, v35, 1f, 0.8745098f, 0.1882353f, v55.a, v40, v41, v42, v43);\n\tv566 = v52.Length < 4;\n\tv337 = ~v566;\n\tv322 = v52.Length - 4;\n\tv292 = v322 == 0;\n\tv567 = ~v337;\n\tv217 = v567 | v292;\n\tif (v217) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+60]) = 0;\n\tv194 = 0;\n\tv402 = 0x10105A8(&v194 @ stack_-A0_v5, 0, v30, v31, v32, v33, v34, v35, 1f, 0.5529412f, 0.1882353f, v55.a, v40, v41, v42, v43);\n\tv571 = v52.Length < 5;\n\tv338 = ~v571;\n\tv323 = v52.Length - 5;\n\tv293 = v323 == 0;\n\tv572 = ~v338;\n\tv218 = v572 | v293;\n\tif (v218) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+70]) = 0;\n\tv190 = 0;\n\tv403 = 0x10105A8(&v190 @ stack_-B0_v5, 0, v30, v31, v32, v33, v34, v35, 0.7607843f, 0.24313726f, 0.2509804f, v55.a, v40, v41, v42, v43);\n\tv576 = v52.Length < 6;\n\tv339 = ~v576;\n\tv324 = v52.Length - 6;\n\tv294 = v324 == 0;\n\tv577 = ~v339;\n\tv219 = v577 | v294;\n\tif (v219) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+80]) = 0;\n\tv186 = 0;\n\tv404 = 0x10105A8(&v186 @ stack_-C0_v5, 0, v30, v31, v32, v33, v34, v35, 0.54509807f, 0.24313726f, 0.7607843f, v55.a, v40, v41, v42, v43);\n\tv580 = v52.Length < 7;\n\tv340 = ~v580;\n\tv325 = v52.Length - 7;\n\tv295 = v325 == 0;\n\tv581 = ~v340;\n\tv220 = v581 | v295;\n\tif (v220) goto L_01B4;\n\t*([v52 @ X0_v3 (UnityEngine.Color[])+90]) = 0;\n\tv584.defaultColors = v52;\n\t// 228 NewArr v477 @ X0_v28 (System.String[]), typeof(System.String[]), 8\n\tv589 = \"Default\" == 0;\n\tif (v589) goto L_00F2;\n\t// 239 IsInst v592 @ X0_v54, typeof(System.String), \"Default\"\nL_00F2:\n\tv437 = v477.Length;\n\tv414 = v477.Length == 0;\n\tif (v414) goto L_01B4;\n\tv477[0] = \"Default\";\n\tv598 = \"Blue\" == 0;\n\tif (v598) goto L_0102;\n\t// 254 IsInst v607 @ X0_v53, typeof(System.String), \"Blue\"\n\tv437 = v477.Length;\nL_0102:\n\tv629 = v437 < 1;\n\tv341 = ~v629;\n\tv326 = v437 - 1;\n\tv296 = v326 == 0;\n\tv630 = ~v341;\n\tv221 = v630 | v296;\n\tif (v221) goto L_01B4;\n\tv477[1] = \"Blue\";\n\tv633 = \"Cyan\" == 0;\n\tif (v633) goto L_011B;\n\t// 279 IsInst v608 @ X0_v52, typeof(System.String), \"Cyan\"\n\tv437 = v477.Length;\nL_011B:\n\tv635 = v437 < 2;\n\tv342 = ~v635;\n\tv327 = v437 - 2;\n\tv297 = v327 == 0;\n\tv636 = ~v342;\n\tv222 = v636 | v297;\n\tif (v222) goto L_01B4;\n\tv477[2] = \"Cyan\";\n\tv639 = \"Green\" == 0;\n\tif (v639) goto L_0134;\n\t// 304 IsInst v609 @ X0_v51, typeof(System.String), \"Green\"\n\tv437 = v477.Length;\nL_0134:\n\tv641 = v437 < 3;\n\tv343 = ~v641;\n\tv328 = v437 - 3;\n\tv298 = v328 == 0;\n\tv642 = ~v343;\n\tv223 = v642 | v298;\n\tif (v223) goto L_01B4;\n\tv477[3] = \"Green\";\n\tv645 = \"Yellow\" == 0;\n\tif (v645) goto L_014D;\n\t// 329 IsInst v610 @ X0_v50, typeof(System.String), \"Yellow\"\n\tv437 = v477.Length;\nL_014D:\n\tv647 = v437 < 4;\n\tv344 = ~v647;\n\tv329 = v437 - 4;\n\tv299 = v329 == 0;\n\tv648 = ~v344;\n\tv224 = v648 | v299;\n\tif (v224) goto L_01B4;\n\tv477[4] = \"Yellow\";\n\tv651 = \"Orange\" == 0;\n\tif (v651) goto L_0166;\n\t// 354 IsInst v611 @ X0_v49, typeof(System.String), \"Orange\"\n\tv437 = v477.Length;\nL_0166:\n\tv653 = v437 < 5;\n\tv345 = ~v653;\n\tv330 = v437 - 5;\n\tv300 = v330 == 0;\n\tv654 = ~v345;\n\tv225 = v654 | v300;\n\tif (v225) goto L_01B4;\n\tv477[5] = \"Orange\";\n\tv657 = \"Red\" == 0;\n\tif (v657) goto L_017F;\n\t// 379 IsInst v612 @ X0_v48, typeof(System.String), \"Red\"\n\tv437 = v477.Length;\nL_017F:\n\tv659 = v437 < 6;\n\tv346 = ~v659;\n\tv331 = v437 - 6;\n\tv301 = v331 == 0;\n\tv660 = ~v346;\n\tv226 = v660 | v301;\n\tif (v226) goto L_01B4;\n\tv477[6] = \"Red\";\n\tv663 = \"Purple\" == 0;\n\tif (v663) goto L_0198;\n\t// 404 IsInst v613 @ X0_v47, typeof(System.String), \"Purple\"\n\tv437 = v477.Length;\nL_0198:\n\tv665 = v437 < 7;\n\tv347 = ~v665;\n\tv332 = v437 - 7;\n\tv302 = v332 == 0;\n\tv666 = ~v347;\n\tv227 = v666 | v302;\n\tif (v227) goto L_01B4;\n\tv477[7] = \"Purple\";\n\tv551.defaultColorNames = v477;\n\treturn;\nL_01B4:\n\tv440 = new System.IndexOutOfRangeException();\n\tgoto L_01B9;\n\tv503 = new System.ArrayTypeMismatchException();\nL_01B9:\n\tthrow v502;\n\tthrow System.NullReferenceException;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static PlayMakerPrefs()
	{
		//IL_005e: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_00f0: Expected O, but got I4
		//IL_012b: Expected O, but got I4
		//IL_016f: Expected O, but got I4
		//IL_01aa: Expected O, but got I4
		//IL_01ee: Expected O, but got I4
		//IL_0229: Expected O, but got I4
		//IL_026d: Expected O, but got I4
		//IL_02a8: Expected O, but got I4
		//IL_02ec: Expected O, but got I4
		//IL_0327: Expected O, but got I4
		//IL_036b: Expected O, but got I4
		//IL_03a6: Expected O, but got I4
		//IL_0438: Expected O, but got I4
		//IL_0711: Expected O, but got I
		//IL_04a5: Expected O, but got I4
		//IL_076f: Expected O, but got I
		//IL_04f8: Expected O, but got I4
		//IL_07cd: Expected O, but got I
		//IL_054b: Expected O, but got I4
		//IL_082b: Expected O, but got I
		//IL_059e: Expected O, but got I4
		//IL_0889: Expected O, but got I
		//IL_05f1: Expected O, but got I4
		//IL_08e7: Expected O, but got I
		//IL_0644: Expected O, but got I4
		//IL_0945: Expected O, but got I
		//IL_0697: Expected O, but got I4
		object obj2 = default(object);
		object obj = obj2;
		Color[] array = new Color[8];
		Color grey = Color.grey;
		if (array.Length != 0)
		{
			_ = grey.g;
			_ = grey.b;
			_ = grey.a;
			object obj3 = (long)(IntPtr)obj2 - 80L;
			_ = 0;
			_ = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
			bool flag = array.Length < 1;
			bool flag2 = !flag;
			object obj4 = array.Length - 1;
			bool flag3 = obj4 == null;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v18 @ X29_v1-50]");
				_ = 0;
				object obj5 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
				bool flag5 = array.Length < 2;
				bool flag6 = !flag5;
				object obj6 = array.Length - 2;
				bool flag7 = obj6 == null;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					_ = 0;
					object obj7 = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
					bool flag9 = array.Length < 3;
					bool flag10 = !flag9;
					object obj8 = array.Length - 3;
					bool flag11 = obj8 == null;
					bool flag12 = !flag10;
					if (!(flag12 || flag11))
					{
						_ = 0;
						object obj9 = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
						bool flag13 = array.Length < 4;
						bool flag14 = !flag13;
						object obj10 = array.Length - 4;
						bool flag15 = obj10 == null;
						bool flag16 = !flag14;
						if (!(flag16 || flag15))
						{
							_ = 0;
							object obj11 = 0;
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
							bool flag17 = array.Length < 5;
							bool flag18 = !flag17;
							object obj12 = array.Length - 5;
							bool flag19 = obj12 == null;
							bool flag20 = !flag18;
							if (!(flag20 || flag19))
							{
								_ = 0;
								object obj13 = 0;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
								bool flag21 = array.Length < 6;
								bool flag22 = !flag21;
								object obj14 = array.Length - 6;
								bool flag23 = obj14 == null;
								bool flag24 = !flag22;
								if (!(flag24 || flag23))
								{
									_ = 0;
									object obj15 = 0;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10105A8 (inside UnityEngine.ClassLibraryInitializer::Init +0x14)");
									bool flag25 = array.Length < 7;
									bool flag26 = !flag25;
									object obj16 = array.Length - 7;
									bool flag27 = obj16 == null;
									bool flag28 = !flag26;
									if (!(flag28 || flag27))
									{
										_ = 0;
										defaultColors = array;
										string[] array2 = new string[8];
										if ("Default" != null)
										{
											object obj17 = "Default" as string;
										}
										object obj18 = array2.Length;
										if (array2.Length != 0)
										{
											array2[0] = "Default";
											if ("Blue" != null)
											{
												object obj19 = "Blue" as string;
												obj18 = array2.Length;
											}
											bool flag29 = (long)(IntPtr)obj18 < 1L;
											bool flag30 = !flag29;
											object obj20 = (long)(IntPtr)obj18 - 1L;
											bool flag31 = obj20 == null;
											bool flag32 = !flag30;
											if (!(flag32 || flag31))
											{
												array2[1] = "Blue";
												if ("Cyan" != null)
												{
													object obj21 = "Cyan" as string;
													obj18 = array2.Length;
												}
												bool flag33 = (long)(IntPtr)obj18 < 2L;
												bool flag34 = !flag33;
												object obj22 = (long)(IntPtr)obj18 - 2L;
												bool flag35 = obj22 == null;
												bool flag36 = !flag34;
												if (!(flag36 || flag35))
												{
													array2[2] = "Cyan";
													if ("Green" != null)
													{
														object obj23 = "Green" as string;
														obj18 = array2.Length;
													}
													bool flag37 = (long)(IntPtr)obj18 < 3L;
													bool flag38 = !flag37;
													object obj24 = (long)(IntPtr)obj18 - 3L;
													bool flag39 = obj24 == null;
													bool flag40 = !flag38;
													if (!(flag40 || flag39))
													{
														array2[3] = "Green";
														if ("Yellow" != null)
														{
															object obj25 = "Yellow" as string;
															obj18 = array2.Length;
														}
														bool flag41 = (long)(IntPtr)obj18 < 4L;
														bool flag42 = !flag41;
														object obj26 = (long)(IntPtr)obj18 - 4L;
														bool flag43 = obj26 == null;
														bool flag44 = !flag42;
														if (!(flag44 || flag43))
														{
															array2[4] = "Yellow";
															if ("Orange" != null)
															{
																object obj27 = "Orange" as string;
																obj18 = array2.Length;
															}
															bool flag45 = (long)(IntPtr)obj18 < 5L;
															bool flag46 = !flag45;
															object obj28 = (long)(IntPtr)obj18 - 5L;
															bool flag47 = obj28 == null;
															bool flag48 = !flag46;
															if (!(flag48 || flag47))
															{
																array2[5] = "Orange";
																if ("Red" != null)
																{
																	object obj29 = "Red" as string;
																	obj18 = array2.Length;
																}
																bool flag49 = (long)(IntPtr)obj18 < 6L;
																bool flag50 = !flag49;
																object obj30 = (long)(IntPtr)obj18 - 6L;
																bool flag51 = obj30 == null;
																bool flag52 = !flag50;
																if (!(flag52 || flag51))
																{
																	array2[6] = "Red";
																	if ("Purple" != null)
																	{
																		object obj31 = "Purple" as string;
																		obj18 = array2.Length;
																	}
																	bool flag53 = (long)(IntPtr)obj18 < 7L;
																	bool flag54 = !flag53;
																	object obj32 = (long)(IntPtr)obj18 - 7L;
																	bool flag55 = obj32 == null;
																	bool flag56 = !flag54;
																	if (!(flag56 || flag55))
																	{
																		array2[7] = "Purple";
																		defaultColorNames = array2;
																		return;
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}
}
