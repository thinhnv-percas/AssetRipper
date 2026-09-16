using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[Token(Token = "0x2000011")]
public class PlayMakerGlobals : ScriptableObject
{
	[Token(Token = "0x400001B")]
	private static PlayMakerGlobals instance;

	[SerializeField]
	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0x18")]
	private FsmVariables variables;

	[SerializeField]
	[Token(Token = "0x400001D")]
	[FieldOffset(Offset = "0x20")]
	private List<string> events;

	[Token(Token = "0x1700001A")]
	[field: Token(Token = "0x4000016")]
	public static bool Initialized
	{
		[Token(Token = "0x6000065")]
		[Address(RVA = "0xE5A618", Offset = "0xE5A618", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1ED5D68]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024817]) = v35;\nL_001A:\n\treturn v41.<Initialized>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x6000066")]
		[Address(RVA = "0xE5A668", Offset = "0xE5A668", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDA710]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024818]) = v38;\nL_0018:\n\tv43.<Initialized>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private set;
	}

	[Token(Token = "0x1700001B")]
	[field: Token(Token = "0x4000017")]
	public static bool IsPlayingInEditor
	{
		[Token(Token = "0x6000067")]
		[Address(RVA = "0xE5A6C0", Offset = "0xE5A6C0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1F01D18]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024819]) = v35;\nL_001A:\n\treturn v41.<IsPlayingInEditor>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x6000068")]
		[Address(RVA = "0xE5A710", Offset = "0xE5A710", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE5148]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202481A]) = v38;\nL_0018:\n\tv43.<IsPlayingInEditor>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private set;
	}

	[Token(Token = "0x1700001C")]
	[field: Token(Token = "0x4000018")]
	public static bool IsPlaying
	{
		[Token(Token = "0x6000069")]
		[Address(RVA = "0xE5A768", Offset = "0xE5A768", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EBE930]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202481B]) = v35;\nL_001A:\n\treturn v41.<IsPlaying>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x600006A")]
		[Address(RVA = "0xE5A7B8", Offset = "0xE5A7B8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF4BD8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202481C]) = v38;\nL_0018:\n\tv43.<IsPlaying>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private set;
	}

	[Token(Token = "0x1700001D")]
	[field: Token(Token = "0x4000019")]
	public static bool IsEditor
	{
		[Token(Token = "0x600006B")]
		[Address(RVA = "0xE5A810", Offset = "0xE5A810", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EAEFD0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202481D]) = v35;\nL_001A:\n\treturn v41.<IsEditor>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x600006C")]
		[Address(RVA = "0xE5A860", Offset = "0xE5A860", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F05A18]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202481E]) = v38;\nL_0018:\n\tv43.<IsEditor>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private set;
	}

	[Token(Token = "0x1700001E")]
	[field: Token(Token = "0x400001A")]
	public static bool IsBuilding
	{
		[Token(Token = "0x600006D")]
		[Address(RVA = "0xE5A8B8", Offset = "0xE5A8B8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EBF9E8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202481F]) = v35;\nL_001A:\n\treturn v41.<IsBuilding>k__BackingField;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get;
		[Token(Token = "0x600006E")]
		[Address(RVA = "0xE5A908", Offset = "0xE5A908", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED48D0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024820]) = v38;\nL_0018:\n\tv43.<IsBuilding>k__BackingField = value;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set;
	}

	[Token(Token = "0x1700001F")]
	public static PlayMakerGlobals Instance
	{
		[Token(Token = "0x6000071")]
		[Address(RVA = "0xE4A0A8", Offset = "0xE4A0A8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1F0CAE0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024822]) = v35;\nL_0011:\n\tPlayMakerGlobals::Initialize();\n\treturn v41.instance;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			Initialize();
			return instance;
		}
	}

	[Token(Token = "0x17000020")]
	public FsmVariables Variables
	{
		[Token(Token = "0x6000073")]
		[Address(RVA = "0xE5AADC", Offset = "0xE5AADC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.variables;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Variables;
		}
		[Token(Token = "0x6000074")]
		[Address(RVA = "0xE5AAE4", Offset = "0xE5AAE4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.variables = value;\n\treturn;\n")]
		set
		{
			Variables = value;
		}
	}

	[Token(Token = "0x17000021")]
	public List<string> Events
	{
		[Token(Token = "0x6000075")]
		[Address(RVA = "0xE5AAEC", Offset = "0xE5AAEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.events;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Events;
		}
		[Token(Token = "0x6000076")]
		[Address(RVA = "0xE5AAF4", Offset = "0xE5AAF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.events = value;\n\treturn;\n")]
		set
		{
			Events = value;
		}
	}

	[Token(Token = "0x600006F")]
	[Address(RVA = "0xE5A960", Offset = "0xE5A960", Length = "0x12C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Application::get_isEditor();\n\tv15 = v13 == 0;\n\tif (v15) goto L_FFFFFFFF;\n\tv17 = UnityEngine.Application::get_isPlaying();\n\tgoto L_0015;\nL_0015:\n\tgoto L_0021;\n\tv27 = *([1EDD5D0]);\n\tv28 = *([v27 @ X8_v28]);\n\tv29 = \"il2cpp_codegen_initialize_method\"(v28, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv46 = 0 | 1;\n\t*([2024869]) = v46;\nL_0021:\n\tv52.<IsPlayingInEditor>k__BackingField = v20;\n\tv53 = UnityEngine.Application::get_isPlaying();\n\tv55 = v53 == 0;\n\tif (v55) goto L_002C;\n\tgoto L_003A;\nL_002C:\n\tgoto L_FFFFFFFF;\n\tv73 = *([1ED6970]);\n\tv74 = *([v73 @ X8_v25]);\n\tv75 = \"il2cpp_codegen_initialize_method\"(v74, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv77 = 0 | 1;\n\t*([2021A8E]) = v77;\nL_003A:\n\tgoto L_0044;\n\tv80 = *([1F08DA0]);\n\tv81 = *([v80 @ X8_v18]);\n\tv82 = \"il2cpp_codegen_initialize_method\"(v81, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv84 = 0 | 1;\n\t*([202486A]) = v84;\nL_0044:\n\tv88.<IsPlaying>k__BackingField = v63;\n\tv89 = UnityEngine.Application::get_isEditor();\n\tgoto L_0055;\n\tv96 = *([1EFDBA8]);\n\tv97 = *([v96 @ X8_v15]);\n\tv98 = \"il2cpp_codegen_initialize_method\"(v97, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv100 = 0 | 1;\n\t*([202486B]) = v100;\nL_0055:\n\tv104.<IsEditor>k__BackingField = v89;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void InitApplicationFlags()
	{
		int num;
		if (Application.isEditor)
		{
			bool isPlaying = Application.isPlaying;
			num = (isPlaying ? 1 : 0);
		}
		else
		{
			num = 0;
		}
		IsPlayingInEditor = (byte)num != 0;
		int num2 = ((Application.isPlaying || IsBuilding) ? 1 : 0);
		IsPlaying = (byte)num2 != 0;
		bool isEditor = Application.isEditor;
		IsEditor = isEditor;
	}

	[Token(Token = "0x6000070")]
	[Address(RVA = "0xE55408", Offset = "0xE55408", Length = "0x2AC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EEDA00]);\n\tv23 = *([v22 @ X8_v59]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2024821]) = v43;\nL_0019:\n\tgoto L_0025;\n\tv49 = *([1EA4B08]);\n\tv50 = *([v49 @ X8_v56]);\n\tv51 = \"il2cpp_codegen_initialize_method\"(v50, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = 0 | 1;\n\t*([2024861]) = v54;\nL_0025:\n\tv60 = ~v58.<Initialized>k__BackingField;\n\tv61 = ~v60;\n\tif (v61) goto L_00F2;\n\tPlayMakerGlobals::InitApplicationFlags();\n\tgoto L_003A;\n\tv185 = *([v131 @ X0_v4+E0]);\n\tv186 = v185 == 0;\n\tv187 = ~v186;\n\tif (v187) goto L_003A;\n\tv189 = \"il2cpp_codegen_runtime_class_init\"(v131, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_003A:\n\tv194 = System.Type::GetTypeFromHandle(PlayMakerGlobals);\n\tv201 = UnityEngine.Resources::Load(\"PlayMakerGlobals\", v194);\n\tgoto L_0053;\n\tv209 = *([v205 @ X8_v19+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0053;\n\tv220 = v205;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v220, v197, v198, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0053:\n\tv219 = UnityEngine.Object::op_Inequality(v201, 0);\n\tv222 = v219 == 0;\n\tif (v222) goto L_00B1;\n\tgoto L_0065;\n\tv232 = *([1F0AEA0]);\n\tv233 = *([v232 @ X8_v51]);\n\tv234 = \"il2cpp_codegen_initialize_method\"(v233, v217, v218, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv237 = 0 | 1;\n\t*([202486C]) = v237;\nL_0065:\n\tv241 = ~v239.<IsPlayingInEditor>k__BackingField;\n\tif (v241) goto L_00B6;\n\tv244 = v201 == 0;\n\tif (v244) goto L_0089;\n\tgoto L_FFFFFFFF;\n\tv301 = v301_asT == 0;\n\tif (v301) goto L_00F6;\nL_0089:\n\tv316 = UnityEngine.ScriptableObject::CreateInstance();\n\tv364.instance = v316;\n\tv248 = v383.instance;\n\tv387 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v387, *([v201 @ X0_v9 (UnityEngine.Object)+18]));\n\tv248.variables = v387;\n\tv249 = v395.instance;\n\tv278 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v278, *([v201 @ X0_v9 (UnityEngine.Object)+20]));\n\tv249.events = v278;\n\tgoto L_00DF;\nL_00B1:\n\tv230 = UnityEngine.ScriptableObject::CreateInstance();\n\tv243.instance = v230;\n\tgoto L_00DF;\nL_00B6:\n\tv245 = v201 == 0;\n\tif (v245) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00DA;\n\tv379 = v379_asT == 0;\n\tif (v379) goto L_FFFFFFFF;\n\tgoto L_00DA;\nL_00DA:\n\tv239.instance = v275;\nL_00DF:\n\tgoto L_00E9;\n\tv342 = *([1F00D20]);\n\tv343 = *([v342 @ X8_v26]);\n\tv344 = \"il2cpp_codegen_initialize_method\"(v343, v110, v108, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv346 = 0 | 1;\n\t*([202486D]) = v346;\nL_00E9:\n\tv119.<Initialized>k__BackingField = 1;\nL_00F2:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00F6:\n\tthrow System.InvalidCastException;\n// 169 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void Initialize()
	{
		//IL_00e6: Expected O, but got I
		if (Initialized)
		{
			return;
		}
		InitApplicationFlags();
		Type typeFromHandle = typeof(PlayMakerGlobals);
		UnityEngine.Object obj = Resources.Load("PlayMakerGlobals", typeFromHandle);
		if (!(obj != null))
		{
			PlayMakerGlobals playMakerGlobals = ScriptableObject.CreateInstance<PlayMakerGlobals>();
			instance = playMakerGlobals;
		}
		else if (IsPlayingInEditor)
		{
			if ((object)obj != null)
			{
				PlayMakerGlobals playMakerGlobals2 = obj as PlayMakerGlobals;
				if ((object)playMakerGlobals2 == null)
				{
					throw new InvalidCastException();
				}
			}
			PlayMakerGlobals playMakerGlobals3 = ScriptableObject.CreateInstance<PlayMakerGlobals>();
			instance = playMakerGlobals3;
			PlayMakerGlobals playMakerGlobals4 = instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X0_v9 (UnityEngine.Object)+18]");
			FsmVariables fsmVariables = new FsmVariables((FsmVariables)0);
			playMakerGlobals4.Variables = fsmVariables;
			PlayMakerGlobals playMakerGlobals5 = instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X0_v9 (UnityEngine.Object)+20]");
			List<string> list = new List<string>(0);
			playMakerGlobals5.Events = list;
		}
		else
		{
			UnityEngine.Object obj2;
			if ((object)obj == null)
			{
				obj2 = null;
			}
			else
			{
				PlayMakerGlobals playMakerGlobals6 = obj as PlayMakerGlobals;
				obj2 = (((object)playMakerGlobals6 == null) ? null : obj);
			}
			instance = (PlayMakerGlobals)obj2;
		}
		Initialized = true;
	}

	[Token(Token = "0x6000072")]
	[Address(RVA = "0xE5AA8C", Offset = "0xE5AA8C", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EE1C00]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024823]) = v35;\nL_0015:\n\tv39.instance = 0;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void ResetInstance()
	{
		instance = null;
	}

	[Token(Token = "0x6000077")]
	[Address(RVA = "0xE5AAFC", Offset = "0xE5AAFC", Length = "0x100")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EBF418]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2024824]) = v41;\nL_001C:\n\tv48 = System.Collections.Generic.List`1<System.String>::Contains(this.events, eventName);\n\tv67 = v48 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_002F;\n\tSystem.Collections.Generic.List`1<System.String>::Add(this.events, eventName);\nL_002F:\n\tgoto L_0037;\n\tv102 = *([v77 @ X0_v7+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_0037;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v77, v70, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0037:\n\tv111 = HutongGames.PlayMaker.FsmEvent::FindEvent(eventName);\n\tv113 = v111 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_004F;\n\tgoto L_0048;\n\tv123 = *([v115 @ X0_v14+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_0048;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v115, v110, v50, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0048:\n\tv55 = HutongGames.PlayMaker.FsmEvent::GetFsmEvent(eventName);\nL_004F:\n\tHutongGames.PlayMaker.FsmEvent::set_IsGlobal(v121, 1);\n\treturn v121;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public FsmEvent AddEvent(string eventName)
	{
		if (!Events.Contains(eventName))
		{
			Events.Add(eventName);
		}
		FsmEvent fsmEvent = FsmEvent.FindEvent(eventName);
		bool flag = fsmEvent == null;
		bool flag2 = !flag;
		FsmEvent fsmEvent2 = fsmEvent;
		if (!flag2)
		{
			FsmEvent fsmEvent3 = FsmEvent.GetFsmEvent(eventName);
			fsmEvent2 = fsmEvent3;
		}
		fsmEvent2.IsGlobal = true;
		return fsmEvent2;
	}

	[Token(Token = "0x6000078")]
	[Address(RVA = "0xE5ABFC", Offset = "0xE5ABFC", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF0F28]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024825]) = v38;\nL_0013:\n\tv39 = PlayMakerGlobals::get_Instance();\n\tv57 = System.Collections.Generic.List`1<System.String>::Contains(v39.events, v36);\n\tv59 = v57 == 0;\n\tif (v59) goto L_0027;\n\treturn;\nL_0027:\n\tv48 = PlayMakerGlobals::get_Instance();\n\tSystem.Collections.Generic.List`1<System.String>::Add(v48.events, v36);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void AddGlobalEvent(string eventName)
	{
		PlayMakerGlobals playMakerGlobals = Instance;
		string item = default(string);
		if (!playMakerGlobals.Events.Contains(item))
		{
			PlayMakerGlobals playMakerGlobals2 = Instance;
			playMakerGlobals2.Events.Add(item);
		}
	}

	[Token(Token = "0x6000079")]
	[Address(RVA = "0xE5AC94", Offset = "0xE5AC94", Length = "0xCC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EDABA8]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2024826]) = v40;\nL_0017:\n\tv44 = new PlayMakerGlobals+<>c__DisplayClass36_0();\n\tSystem.Object::.ctor(v44);\n\tv44.eventName = eventName;\n\tv48 = PlayMakerGlobals::get_Instance();\n\tv61 = new System.Predicate`1<System.String>();\n\tSystem.Predicate`1<System.String>::.ctor(v61, v44, Il2CppMethodInfo);\n\tv96 = System.Collections.Generic.List`1<System.String>::RemoveAll(v48.events, v61);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void RemoveGlobalEvent(string eventName)
	{
		PlayMakerGlobals playMakerGlobals = Instance;
		Predicate<string> match = (string m) => m == eventName;
		int num = playMakerGlobals.Events.RemoveAll(match);
	}

	[Token(Token = "0x600007A")]
	[Address(RVA = "0xE5AD68", Offset = "0xE5AD68", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	public void OnEnable()
	{
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0xE5AD6C", Offset = "0xE5AD6C", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EBD888]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024827]) = v35;\nL_0015:\n\tgoto L_0020;\n\tv41 = *([1F00D20]);\n\tv42 = *([v41 @ X8_v10]);\n\tv43 = \"il2cpp_codegen_initialize_method\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = 0 | 1;\n\t*([202486D]) = v46;\nL_0020:\n\tv50.<Initialized>k__BackingField = 0;\n\tv52.instance = 0;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnDestroy()
	{
		Initialized = false;
		instance = null;
	}

	[Token(Token = "0x600007C")]
	[Address(RVA = "0xE5ADEC", Offset = "0xE5ADEC", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF4F60]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024828]) = v38;\nL_0016:\n\tv42 = new HutongGames.PlayMaker.FsmVariables();\n\tHutongGames.PlayMaker.FsmVariables::.ctor(v42);\n\tthis.variables = v42;\n\tv47 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v47);\n\tthis.events = v47;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerGlobals()
	{
		FsmVariables fsmVariables = new FsmVariables();
		Variables = fsmVariables;
		List<string> list = new List<string>();
		Events = list;
	}
}
