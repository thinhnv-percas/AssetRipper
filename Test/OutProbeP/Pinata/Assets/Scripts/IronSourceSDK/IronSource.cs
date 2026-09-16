using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000003")]
public class IronSource : IronSourceIAgent
{
	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x10")]
	private IronSourceIAgent _platformAgent;

	[Token(Token = "0x4000007")]
	private static IronSource _instance;

	[Token(Token = "0x4000008")]
	private const string UNITY_PLUGIN_VERSION = "6.13.0";

	[Token(Token = "0x4000009")]
	public const string GENDER_MALE = "male";

	[Token(Token = "0x400000A")]
	public const string GENDER_FEMALE = "female";

	[Token(Token = "0x400000B")]
	public const string GENDER_UNKNOWN = "unknown";

	[Token(Token = "0x17000001")]
	public static IronSource Agent
	{
		[Token(Token = "0x6000031")]
		[Address(RVA = "0x15913B0", Offset = "0x15913B0", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ECF8D8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029695]) = v37;\nL_0016:\n\tv47 = v41._instance;\n\tv43 = v41._instance == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_0029;\n\tv45 = new IronSource();\n\tIronSource::.ctor(v45);\n\tv57._instance = v45;\n\tv47 = v59._instance;\nL_0029:\n\treturn v47;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			IronSource instance = _instance;
			if (_instance == null)
			{
				IronSource instance2 = new IronSource();
				_instance = instance2;
				instance = _instance;
			}
			return instance;
		}
	}

	[Token(Token = "0x6000030")]
	[Address(RVA = "0x1591264", Offset = "0x1591264", Length = "0x14C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EC41D0]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029694]) = v38;\nL_0015:\n\tSystem.Object::.ctor(this);\n\tv44 = new AndroidAgent();\n\tAndroidAgent::.ctor(v44);\n\tthis._platformAgent = v44;\n\tgoto L_002E;\n\tv55 = *([v48 @ X0_v5+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_002E;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v48, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv64 = System.Type::GetTypeFromHandle(IronSourceEvents);\n\t// 53 NewArr v71 @ X0_v10 (System.Type[]), typeof(System.Type[]), 1\n\tv74 = v64 == 0;\n\tif (v74) goto L_0042;\n\t// 62 IsInst v79 @ X0_v26, typeof(System.Type), v64 @ X0_v8 (System.Type)\nL_0042:\n\tv86 = v71.Length == 0;\n\tif (v86) goto L_005E;\n\tv71[0] = v64;\n\tv95 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v95, \"IronSourceEvents\", v71);\n\tv130 = UnityEngine.GameObject::GetComponent(v95);\n\treturn;\n\tv75 = new System.NullReferenceException();\nL_005E:\n\tv91 = new System.IndexOutOfRangeException();\n\tgoto L_0065;\n\tv103 = new System.NullReferenceException();\n\tv110 = new System.ArrayTypeMismatchException();\nL_0065:\n\tthrow v115;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IronSource()
	{
		AndroidAgent platformAgent = new AndroidAgent();
		_platformAgent = platformAgent;
		Type typeFromHandle = typeof(IronSourceEvents);
		Type[] array = new Type[1];
		if ((object)typeFromHandle != null)
		{
			object obj = typeFromHandle as Type;
		}
		if (array.Length != 0)
		{
			array[0] = typeFromHandle;
			IronSourceEvents component = new GameObject("IronSourceEvents", array).GetComponent<IronSourceEvents>();
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
		throw ex2;
	}

	[Token(Token = "0x6000032")]
	[Address(RVA = "0x158EAF4", Offset = "0x158EAF4", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB4D70]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029696]) = v35;\nL_0018:\n\treturn \"6.13.0\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string pluginVersion()
	{
		return "6.13.0";
	}

	[Token(Token = "0x6000033")]
	[Address(RVA = "0x158EB3C", Offset = "0x158EB3C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Application::get_unityVersion();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static string unityVersion()
	{
		return Application.unityVersion;
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0x159142C", Offset = "0x159142C", Length = "0xC4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB8038]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pause, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029697]) = v41;\nL_001E:\n\tgoto L_004C;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = v42;\n\tv91 = 0;\n\tv92 = 0x8909C4(v90, v48, v91, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004C;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 << 4;\n\tv169 = v45 + v168;\n\tv170 = v169 + 0x130;\nL_004C:\n\tIronSourceIAgent::onApplicationPause(this._platformAgent, pause);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onApplicationPause(bool pause)
	{
		_platformAgent.onApplicationPause(pause);
	}

	[Token(Token = "0x6000035")]
	[Address(RVA = "0x15914F0", Offset = "0x15914F0", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDEB58]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, age, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029698]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 1;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), age @ X1 (System.Int32), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setAge(int age)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 1;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000036")]
	[Address(RVA = "0x15915B8", Offset = "0x15915B8", Length = "0x1D4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F09E58]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, gender, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029699]) = v41;\nL_001C:\n\tv48 = System.String::Equals(gender, \"male\");\n\tv72 = v48 == 0;\n\tif (v72) goto L_004C;\n\tv293 = this._platformAgent;\n\tv295 = *([v293 @ X19_v5 (IronSourceIAgent)]);\n\tv151 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v151) goto L_00A8;\n\tv285 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0033:\n\tv245 = *([v285 @ X11_v2-8]) == IronSourceIAgent;\n\tif (v245) goto L_00AB;\n\tv239 = v239 + 1;\n\tv253 = v239 < *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv195 = ~v253;\n\tv285 = v285 + 0x10;\n\tv163 = ~v195;\n\tif (v163) goto L_0033;\n\tgoto L_00A8;\nL_004C:\n\tv56 = System.String::Equals(gender, \"female\");\n\tv153 = v56 == 0;\n\tif (v153) goto L_007C;\n\tv293 = this._platformAgent;\n\tv295 = *([v293 @ X19_v5 (IronSourceIAgent)]);\n\tv215 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v215) goto L_00A8;\n\tv285 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0063:\n\tv271 = *([v285 @ X11_v2-8]) == IronSourceIAgent;\n\tif (v271) goto L_00AB;\n\tv283 = v283 + 1;\n\tv323 = v283 < *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv196 = ~v323;\n\tv285 = v285 + 0x10;\n\tv164 = ~v196;\n\tif (v164) goto L_0063;\n\tgoto L_00A8;\nL_007C:\n\tv57 = System.String::Equals(gender, \"unknown\");\n\tv130 = v57 == 0;\n\tif (v130) goto L_00C0;\n\tv293 = this._platformAgent;\n\tv295 = *([v293 @ X19_v5 (IronSourceIAgent)]);\n\tv214 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v214) goto L_00A8;\n\tv285 = *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0093:\n\tv272 = *([v285 @ X11_v2-8]) == IronSourceIAgent;\n\tif (v272) goto L_00AB;\n\tv284 = v284 + 1;\n\tv337 = v284 < *([v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv194 = ~v337;\n\tv285 = v285 + 0x10;\n\tv162 = ~v194;\n\tif (v162) goto L_0093;\nL_00A8:\n\tv304 = 0x8909C4(v293, v208, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_00AF;\nL_00AB:\n\tv298 = *([v285 @ X11_v2]) + 2;\n\tv299 = v298 << 4;\n\tv300 = v295 + v299;\n\tv304 = v300 + 0x130;\nL_00AF:\n\tv76 = *([v304 @ X0_v7]);\n\tv125 = *([v304 @ X0_v7+8]);\n\t// 185 IndirectJump v76 @ X3_v1, v293 @ X19_v5 (IronSourceIAgent), v293 @ X19_v5 (IronSourceIAgent), v306 @ X20_v2 (System.String), v125 @ X2_v4, v76 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_00C0:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setGender(string gender)
	{
		//IL_004b: Expected I, but got O
		//IL_0070: Expected I, but got O
		//IL_0164: Expected I, but got O
		//IL_0189: Expected I, but got O
		//IL_027d: Expected I, but got O
		//IL_02a2: Expected I, but got O
		//IL_0450: Expected O, but got I
		//IL_009d: Expected O, but got I
		//IL_01b6: Expected O, but got I
		//IL_02cf: Expected O, but got I
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_036d: Expected O, but got Unknown
		//IL_038a: Expected O, but got I
		//IL_0399: Expected O, but got I
		//IL_00e9: Expected O, but got I
		//IL_0202: Expected O, but got I
		//IL_031b: Expected O, but got I
		//IL_0334: Expected I, but got O
		//IL_0110: Expected I, but got O
		//IL_0229: Expected I, but got O
		IntPtr intPtr;
		object obj;
		IntPtr intPtr2;
		string text;
		if (gender.Equals("male"))
		{
			IronSourceIAgent platformAgent = _platformAgent;
			intPtr = (IntPtr)platformAgent;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (IntPtr)0 == (IntPtr)0;
			intPtr2 = (IntPtr)typeof(IronSourceIAgent);
			text = "male";
			if (flag)
			{
				goto IL_034b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]");
			obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X11_v2-8]");
				bool flag2 = (IntPtr)0 == (IntPtr)typeof(IronSourceIAgent);
				text = "male";
				if (flag2)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_0102;
			}
		}
		else if (gender.Equals("female"))
		{
			IronSourceIAgent platformAgent = _platformAgent;
			intPtr = (IntPtr)platformAgent;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag5 = (IntPtr)0 == (IntPtr)0;
			intPtr2 = (IntPtr)typeof(IronSourceIAgent);
			text = "female";
			if (flag5)
			{
				goto IL_034b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]");
			obj = 0L + 8L;
			int num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X11_v2-8]");
				bool flag6 = (IntPtr)0 == (IntPtr)typeof(IronSourceIAgent);
				text = "female";
				if (flag6)
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
				bool flag7 = (long)num4 < 0L;
				bool flag8 = !flag7;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_021b;
			}
		}
		else
		{
			if (!gender.Equals("unknown"))
			{
				return;
			}
			IronSourceIAgent platformAgent = _platformAgent;
			intPtr = (IntPtr)platformAgent;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag9 = (IntPtr)0 == (IntPtr)0;
			intPtr2 = (IntPtr)typeof(IronSourceIAgent);
			text = "unknown";
			if (flag9)
			{
				goto IL_034b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+B0]");
			obj = 0L + 8L;
			int num5 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ X11_v2-8]");
				bool flag10 = (IntPtr)0 == (IntPtr)typeof(IronSourceIAgent);
				text = "unknown";
				if (flag10)
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v4 (Il2CppClass<IronSourceIAgent>)+126]");
				bool flag11 = (long)num6 < 0L;
				bool flag12 = !flag11;
				obj = (long)(IntPtr)obj + 16L;
				bool flag13 = !flag12;
				intPtr2 = (IntPtr)typeof(IronSourceIAgent);
				text = "unknown";
				if (flag13)
				{
					continue;
				}
				goto IL_034b;
			}
		}
		object obj2 = obj + 2;
		int num7 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num7;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0438;
		IL_034b:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0438;
		IL_021b:
		intPtr2 = (IntPtr)typeof(IronSourceIAgent);
		text = "female";
		goto IL_034b;
		IL_0438:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v304 @ X0_v7+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v76 @ X3_v1 (should have been resolved before IL gen)");
		return;
		IL_0102:
		intPtr2 = (IntPtr)typeof(IronSourceIAgent);
		text = "male";
		goto IL_034b;
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0x159178C", Offset = "0x159178C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFCD98]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, segment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202969A]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 3;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), segment @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setMediationSegment(string segment)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 3;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0x1591854", Offset = "0x1591854", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE5E78]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202969B]) = v38;\nL_0013:\n\tv39 = this._platformAgent;\n\tv42 = *([v39 @ X19_v2 (IronSourceIAgent)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, IronSourceIAgent, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 4;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (IronSourceIAgent), v39 @ X19_v2 (IronSourceIAgent), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string getAdvertiserId()
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 4;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
		return null;
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0x159190C", Offset = "0x159190C", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA7818]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202969C]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 5;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 5;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::validateIntegration(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void validateIntegration()
	{
		_platformAgent.validateIntegration();
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0x15919C4", Offset = "0x15919C4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFC398]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, track, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202969D]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 6, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 6;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), track @ X1 (System.Boolean), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void shouldTrackNetworkState(bool track)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 6;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x600003B")]
	[Address(RVA = "0x1591A8C", Offset = "0x1591A8C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC8408]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, dynamicUserId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202969E]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 7, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 7;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), dynamicUserId @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool setDynamicUserId(string dynamicUserId)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 7;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		return false;
	}

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x1591B54", Offset = "0x1591B54", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED2F50]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, enabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202969F]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 8;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), enabled @ X1 (System.Boolean), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setAdaptersDebug(bool enabled)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 8;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x600003D")]
	[Address(RVA = "0x1591C1C", Offset = "0x1591C1C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1ECAD60]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20296A0]) = v44;\nL_0020:\n\tgoto L_0051;\n\tv55 = *([v48 @ X8_v3+B0]);\n\tv56 = 0;\n\tv57 = v55 + 8;\n\tv59 = *([v106 @ X11_v5-8]);\n\tv112 = v59 == v51;\n\tif (v112) goto L_0040;\n\tv92 = v107 + 1;\n\tv173 = v92 < v50;\n\tv86 = ~v173;\n\tv89 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_FFFFFFFF;\n\tv93 = 9;\n\tv94 = v45;\n\tv95 = 0x8909C4(v94, v51, v93, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0051;\nL_0040:\n\tv174 = *([v106 @ X11_v5]);\n\tv175 = v174 + 9;\n\tv176 = v175 << 4;\n\tv177 = v48 + v176;\n\tv178 = v177 + 0x130;\nL_0051:\n\tIronSourceIAgent::setMetaData(this._platformAgent, key, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setMetaData(string key, string value)
	{
		_platformAgent.setMetaData(key, value);
	}

	[Token(Token = "0x600003E")]
	[Address(RVA = "0x1591CEC", Offset = "0x1591CEC", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F0F108]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, userId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296A1]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0xA;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0xA;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::setUserId(this._platformAgent, userId);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setUserId(string userId)
	{
		_platformAgent.setUserId(userId);
	}

	[Token(Token = "0x600003F")]
	[Address(RVA = "0x1591DB4", Offset = "0x1591DB4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED36B0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, appKey, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296A2]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0xB;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0xB;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::init(this._platformAgent, appKey);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void init(string appKey)
	{
		_platformAgent.init(appKey);
	}

	[Token(Token = "0x6000040")]
	[Address(RVA = "0x1591E7C", Offset = "0x1591E7C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE03A8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appKey, adUnits, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20296A3]) = v44;\nL_0017:\n\tv45 = this._platformAgent;\n\tv48 = *([v45 @ X21_v2 (IronSourceIAgent)]);\n\tv52 = *([v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v52) goto L_003E;\n\tv106 = *([v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0029:\n\tv112 = *([v106 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v112) goto L_0041;\n\tv107 = v107 + 1;\n\tv173 = v107 < *([v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv86 = ~v173;\n\tv106 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_0029;\nL_003E:\n\tv180 = 0x8909C4(v45, IronSourceIAgent, 0xC, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0045;\nL_0041:\n\tv175 = *([v106 @ X11_v5]) + 0xC;\n\tv176 = v175 << 4;\n\tv177 = v48 + v176;\n\tv180 = v177 + 0x130;\nL_0045:\n\tv122 = *([v180 @ X0_v4]);\n\tv120 = *([v180 @ X0_v4+8]);\n\t// 81 IndirectJump v122 @ X4_v1, v45 @ X21_v2 (IronSourceIAgent), v45 @ X21_v2 (IronSourceIAgent), appKey @ X1 (System.String), adUnits @ X2 (System.String[]), v120 @ X3_v1, v122 @ X4_v1, v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void init(string appKey, params string[] adUnits)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 12;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v180 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v122 @ X4_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000041")]
	[Address(RVA = "0x1591F4C", Offset = "0x1591F4C", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1ED39C8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appKey, adUnits, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20296A4]) = v44;\nL_0020:\n\tgoto L_0051;\n\tv55 = *([v48 @ X8_v3+B0]);\n\tv56 = 0;\n\tv57 = v55 + 8;\n\tv59 = *([v106 @ X11_v5-8]);\n\tv112 = v59 == v51;\n\tif (v112) goto L_0040;\n\tv92 = v107 + 1;\n\tv173 = v92 < v50;\n\tv86 = ~v173;\n\tv89 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_FFFFFFFF;\n\tv93 = 0xD;\n\tv94 = v45;\n\tv95 = 0x8909C4(v94, v51, v93, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0051;\nL_0040:\n\tv174 = *([v106 @ X11_v5]);\n\tv175 = v174 + 0xD;\n\tv176 = v175 << 4;\n\tv177 = v48 + v176;\n\tv178 = v177 + 0x130;\nL_0051:\n\tIronSourceIAgent::initISDemandOnly(this._platformAgent, appKey, adUnits);\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void initISDemandOnly(string appKey, params string[] adUnits)
	{
		_platformAgent.initISDemandOnly(appKey, adUnits);
	}

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x159201C", Offset = "0x159201C", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEFFF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296A5]) = v38;\nL_0013:\n\tv39 = this._platformAgent;\n\tv42 = *([v39 @ X19_v2 (IronSourceIAgent)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, IronSourceIAgent, 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0xE;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (IronSourceIAgent), v39 @ X19_v2 (IronSourceIAgent), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showRewardedVideo()
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 14;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x15920D4", Offset = "0x15920D4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC9108]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296A6]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 0xF, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0xF;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), placementName @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showRewardedVideo(string placementName)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 15;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x159219C", Offset = "0x159219C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EC6B08]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296A7]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x12;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x12;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tinterfaceTailCallResult = IronSourceIAgent::getPlacementInfo(this._platformAgent, placementName);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourcePlacement getPlacementInfo(string placementName)
	{
		return _platformAgent.getPlacementInfo(placementName);
	}

	[Token(Token = "0x6000045")]
	[Address(RVA = "0x1592264", Offset = "0x1592264", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA8678]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296A8]) = v38;\nL_0013:\n\tv39 = this._platformAgent;\n\tv42 = *([v39 @ X19_v2 (IronSourceIAgent)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, IronSourceIAgent, 0x10, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0x10;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (IronSourceIAgent), v39 @ X19_v2 (IronSourceIAgent), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isRewardedVideoAvailable()
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 16;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
		return false;
	}

	[Token(Token = "0x6000046")]
	[Address(RVA = "0x159231C", Offset = "0x159231C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EA6D28]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296A9]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x11;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x11;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tinterfaceTailCallResult = IronSourceIAgent::isRewardedVideoPlacementCapped(this._platformAgent, placementName);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isRewardedVideoPlacementCapped(string placementName)
	{
		return _platformAgent.isRewardedVideoPlacementCapped(placementName);
	}

	[Token(Token = "0x6000047")]
	[Address(RVA = "0x15923E4", Offset = "0x15923E4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ECB788]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, parameters, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296AA]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x13;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x13;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::setRewardedVideoServerParams(this._platformAgent, parameters);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setRewardedVideoServerParams(Dictionary<string, string> parameters)
	{
		_platformAgent.setRewardedVideoServerParams(parameters);
	}

	[Token(Token = "0x6000048")]
	[Address(RVA = "0x15924AC", Offset = "0x15924AC", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE8FF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296AB]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x14;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x14;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::clearRewardedVideoServerParams(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void clearRewardedVideoServerParams()
	{
		_platformAgent.clearRewardedVideoServerParams();
	}

	[Token(Token = "0x6000049")]
	[Address(RVA = "0x1592564", Offset = "0x1592564", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EE76A8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296AC]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x15;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x15;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::showISDemandOnlyRewardedVideo(this._platformAgent, instanceId);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showISDemandOnlyRewardedVideo(string instanceId)
	{
		_platformAgent.showISDemandOnlyRewardedVideo(instanceId);
	}

	[Token(Token = "0x600004A")]
	[Address(RVA = "0x159262C", Offset = "0x159262C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EBAE68]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296AD]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x16;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x16;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::loadISDemandOnlyRewardedVideo(this._platformAgent, instanceId);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadISDemandOnlyRewardedVideo(string instanceId)
	{
		_platformAgent.loadISDemandOnlyRewardedVideo(instanceId);
	}

	[Token(Token = "0x600004B")]
	[Address(RVA = "0x15926F4", Offset = "0x15926F4", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EC8398]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296AE]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x17;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x17;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tinterfaceTailCallResult = IronSourceIAgent::isISDemandOnlyRewardedVideoAvailable(this._platformAgent, instanceId);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isISDemandOnlyRewardedVideoAvailable(string instanceId)
	{
		return _platformAgent.isISDemandOnlyRewardedVideoAvailable(instanceId);
	}

	[Token(Token = "0x600004C")]
	[Address(RVA = "0x15927BC", Offset = "0x15927BC", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0CA88]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296AF]) = v38;\nL_0013:\n\tv39 = this._platformAgent;\n\tv42 = *([v39 @ X19_v2 (IronSourceIAgent)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, IronSourceIAgent, 0x18, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0x18;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (IronSourceIAgent), v39 @ X19_v2 (IronSourceIAgent), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadInterstitial()
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 24;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x600004D")]
	[Address(RVA = "0x1592874", Offset = "0x1592874", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0B1C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296B0]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x19;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x19;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::showInterstitial(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showInterstitial()
	{
		_platformAgent.showInterstitial();
	}

	[Token(Token = "0x600004E")]
	[Address(RVA = "0x159292C", Offset = "0x159292C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F0B580]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B1]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x1A;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x1A;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::showInterstitial(this._platformAgent, placementName);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showInterstitial(string placementName)
	{
		_platformAgent.showInterstitial(placementName);
	}

	[Token(Token = "0x600004F")]
	[Address(RVA = "0x15929F4", Offset = "0x15929F4", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F03560]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296B2]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x1B;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x1B;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = IronSourceIAgent::isInterstitialReady(this._platformAgent);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isInterstitialReady()
	{
		return _platformAgent.isInterstitialReady();
	}

	[Token(Token = "0x6000050")]
	[Address(RVA = "0x1592AAC", Offset = "0x1592AAC", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAC590]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B3]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 0x1C, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1C;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), placementName @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isInterstitialPlacementCapped(string placementName)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 28;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		return false;
	}

	[Token(Token = "0x6000051")]
	[Address(RVA = "0x1592B74", Offset = "0x1592B74", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB59A8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B4]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x1D;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x1D;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::loadISDemandOnlyInterstitial(this._platformAgent, instanceId);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadISDemandOnlyInterstitial(string instanceId)
	{
		_platformAgent.loadISDemandOnlyInterstitial(instanceId);
	}

	[Token(Token = "0x6000052")]
	[Address(RVA = "0x1592C3C", Offset = "0x1592C3C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF0470]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B5]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 0x1E, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1E;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), instanceId @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showISDemandOnlyInterstitial(string instanceId)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 30;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000053")]
	[Address(RVA = "0x1592D04", Offset = "0x1592D04", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECC968]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, instanceId, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B6]) = v41;\nL_0015:\n\tv42 = this._platformAgent;\n\tv45 = *([v42 @ X20_v2 (IronSourceIAgent)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, IronSourceIAgent, 0x1F, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1F;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (IronSourceIAgent), v42 @ X20_v2 (IronSourceIAgent), instanceId @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isISDemandOnlyInterstitialReady(string instanceId)
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 31;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
		return false;
	}

	[Token(Token = "0x6000054")]
	[Address(RVA = "0x1592DCC", Offset = "0x1592DCC", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB79B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296B7]) = v38;\nL_0013:\n\tv39 = this._platformAgent;\n\tv42 = *([v39 @ X19_v2 (IronSourceIAgent)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == IronSourceIAgent;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, IronSourceIAgent, 0x20, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0x20;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (IronSourceIAgent), v39 @ X19_v2 (IronSourceIAgent), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showOfferwall()
	{
		//IL_000d: Expected I, but got O
		//IL_0151: Expected O, but got I
		//IL_0048: Expected O, but got I
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00ec: Expected O, but got I
		//IL_00fb: Expected O, but got I
		//IL_0094: Expected O, but got I
		IronSourceIAgent platformAgent = _platformAgent;
		IntPtr intPtr = (IntPtr)platformAgent;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00ad;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IronSourceIAgent))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<IronSourceIAgent>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00ad;
		}
		object obj2 = obj + 32;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_0139;
		IL_00ad:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_0139;
		IL_0139:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000055")]
	[Address(RVA = "0x1592E84", Offset = "0x1592E84", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EF1178]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296B8]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x21;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x21;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::showOfferwall(this._platformAgent, placementName);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void showOfferwall(string placementName)
	{
		_platformAgent.showOfferwall(placementName);
	}

	[Token(Token = "0x6000056")]
	[Address(RVA = "0x1592F4C", Offset = "0x1592F4C", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA5AA0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296B9]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x23;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x23;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::getOfferwallCredits(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void getOfferwallCredits()
	{
		_platformAgent.getOfferwallCredits();
	}

	[Token(Token = "0x6000057")]
	[Address(RVA = "0x1593004", Offset = "0x1593004", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED7EC0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296BA]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x22;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x22;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = IronSourceIAgent::isOfferwallAvailable(this._platformAgent);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isOfferwallAvailable()
	{
		return _platformAgent.isOfferwallAvailable();
	}

	[Token(Token = "0x6000058")]
	[Address(RVA = "0x15930BC", Offset = "0x15930BC", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1EFA5D0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, size, position, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20296BB]) = v44;\nL_0020:\n\tgoto L_0051;\n\tv55 = *([v48 @ X8_v3+B0]);\n\tv56 = 0;\n\tv57 = v55 + 8;\n\tv59 = *([v106 @ X11_v5-8]);\n\tv112 = v59 == v51;\n\tif (v112) goto L_0040;\n\tv92 = v107 + 1;\n\tv173 = v92 < v50;\n\tv86 = ~v173;\n\tv89 = v106 + 0x10;\n\tv62 = ~v86;\n\tif (v62) goto L_FFFFFFFF;\n\tv93 = 0x24;\n\tv94 = v45;\n\tv95 = 0x8909C4(v94, v51, v93, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0051;\nL_0040:\n\tv174 = *([v106 @ X11_v5]);\n\tv175 = v174 + 0x24;\n\tv176 = v175 << 4;\n\tv177 = v48 + v176;\n\tv178 = v177 + 0x130;\nL_0051:\n\tIronSourceIAgent::loadBanner(this._platformAgent, size, position);\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position)
	{
		_platformAgent.loadBanner(size, position);
	}

	[Token(Token = "0x6000059")]
	[Address(RVA = "0x159318C", Offset = "0x159318C", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EE6148]);\n\tv31 = *([v30 @ X8_v8]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, size, position, placementName, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20296BC]) = v47;\nL_0022:\n\tgoto L_0055;\n\tv58 = *([v51 @ X8_v3+B0]);\n\tv59 = 0;\n\tv60 = v58 + 8;\n\tv62 = *([v109 @ X11_v5-8]);\n\tv115 = v62 == v54;\n\tif (v115) goto L_0042;\n\tv95 = v110 + 1;\n\tv180 = v95 < v53;\n\tv89 = ~v180;\n\tv92 = v109 + 0x10;\n\tv65 = ~v89;\n\tif (v65) goto L_FFFFFFFF;\n\tv96 = 0x25;\n\tv97 = v48;\n\tv98 = 0x8909C4(v97, v54, v96, placementName, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0055;\nL_0042:\n\tv181 = *([v109 @ X11_v5]);\n\tv182 = v181 + 0x25;\n\tv183 = v182 << 4;\n\tv184 = v51 + v183;\n\tv185 = v184 + 0x130;\nL_0055:\n\tIronSourceIAgent::loadBanner(this._platformAgent, size, position, placementName);\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void loadBanner(IronSourceBannerSize size, IronSourceBannerPosition position, string placementName)
	{
		_platformAgent.loadBanner(size, position, placementName);
	}

	[Token(Token = "0x600005A")]
	[Address(RVA = "0x159326C", Offset = "0x159326C", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA59F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296BD]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x26;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x26;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::destroyBanner(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void destroyBanner()
	{
		_platformAgent.destroyBanner();
	}

	[Token(Token = "0x600005B")]
	[Address(RVA = "0x1593324", Offset = "0x1593324", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE1060]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296BE]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x27;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x27;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::displayBanner(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void displayBanner()
	{
		_platformAgent.displayBanner();
	}

	[Token(Token = "0x600005C")]
	[Address(RVA = "0x15933DC", Offset = "0x15933DC", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF9E10]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296BF]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x28;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x28;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tIronSourceIAgent::hideBanner(this._platformAgent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void hideBanner()
	{
		_platformAgent.hideBanner();
	}

	[Token(Token = "0x600005D")]
	[Address(RVA = "0x1593494", Offset = "0x1593494", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EC3F78]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementName, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296C0]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x29;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x29;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tinterfaceTailCallResult = IronSourceIAgent::isBannerPlacementCapped(this._platformAgent, placementName);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool isBannerPlacementCapped(string placementName)
	{
		return _platformAgent.isBannerPlacementCapped(placementName);
	}

	[Token(Token = "0x600005E")]
	[Address(RVA = "0x159355C", Offset = "0x159355C", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ECA478]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, segment, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296C1]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x2A;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x2A;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::setSegment(this._platformAgent, segment);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setSegment(IronSourceSegment segment)
	{
		_platformAgent.setSegment(segment);
	}

	[Token(Token = "0x600005F")]
	[Address(RVA = "0x1593624", Offset = "0x1593624", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB3F18]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, consent, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296C2]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x2B;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x2B;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tIronSourceIAgent::setConsent(this._platformAgent, consent);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void setConsent(bool consent)
	{
		_platformAgent.setConsent(consent);
	}
}
