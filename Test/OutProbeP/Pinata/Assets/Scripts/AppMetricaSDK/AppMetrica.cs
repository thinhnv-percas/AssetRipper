using System;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000002")]
public class AppMetrica : MonoBehaviour
{
	[Token(Token = "0x4000001")]
	public const string VERSION = "3.4.0";

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x18")]
	public string ApiKeyAndroid;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x20")]
	public string ApiKeyIOS;

	[SerializeField]
	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x28")]
	private bool ExceptionsReporting;

	[SerializeField]
	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x2C")]
	private uint SessionTimeoutSec;

	[SerializeField]
	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x30")]
	private bool LocationTracking;

	[SerializeField]
	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x31")]
	private bool Logs;

	[SerializeField]
	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x32")]
	private bool HandleFirstActivationAsUpdate;

	[SerializeField]
	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x33")]
	private bool StatisticsSending;

	[Token(Token = "0x400000A")]
	private static bool _isInitialized = false;

	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x34")]
	private bool _actualPauseStatus;

	[Token(Token = "0x400000C")]
	private static IYandexAppMetrica _metrica = null;

	[Token(Token = "0x400000D")]
	private static object syncRoot;

	[Token(Token = "0x17000001")]
	public static IYandexAppMetrica Instance
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x15BA7AC", Offset = "0x15BA7AC", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1ED04E8]);\n\tv23 = *([v22 @ X8_v42]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([2029918]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0025;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v47, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv55 = AppMetrica;\nL_0025:\n\tv60 = v58._metrica == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_00A8;\n\tgoto L_0038;\n\tv120 = *([v54 @ X0_v3 (Il2CppClass<AppMetrica>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0038;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv188 = AppMetrica;\n\tv127 = *([v188 @ X8_v37+B8]);\nL_0038:\n\tSystem.Threading.Monitor::Enter(v126.syncRoot, &v67 @ stack_-34_v4 (System.Boolean));\n\tgoto L_0046;\n\tv189 = *([v148 @ X0_v12 (Il2CppClass<AppMetrica>)+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tgoto L_0046;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v148, v129, v131, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv193 = AppMetrica;\nL_0046:\n\tv198 = v196._metrica == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_006F;\n\tv202 = UnityEngine.Application::get_platform();\n\tv206 = v202 != 0xB;\n\tif (v206) goto L_006F;\n\tv247 = new YandexAppMetricaAndroid();\n\tYandexAppMetricaAndroid::.ctor(v247);\n\tgoto L_0069;\n\tv287 = *([v277 @ X0_v39 (Il2CppClass<AppMetrica>)+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_0069;\n\tv298 = \"il2cpp_codegen_runtime_class_init\"(v277, v129, v131, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv290 = AppMetrica;\nL_0069:\n\tv229._metrica = v247;\n\tgoto L_006F;\nL_006F:\n\tgoto L_0078;\n\tv234 = *([v223 @ X0_v14 (Il2CppClass<AppMetrica>)+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tgoto L_0078;\n\tv248 = \"il2cpp_codegen_runtime_class_init\"(v223, v129, v131, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv238 = AppMetrica;\nL_0078:\n\tv243 = v241._metrica == 0;\n\tif (v243) goto L_0080;\n\tgoto L_0095;\nL_0080:\n\tv254 = new YandexAppMetricaDummy();\n\tSystem.Object::.ctor(v254);\n\tgoto L_0093;\n\tv293 = *([v283 @ X0_v27 (Il2CppClass<AppMetrica>)+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tif (v295) goto L_0093;\n\tv301 = \"il2cpp_codegen_runtime_class_init\"(v283, v257, v131, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv296 = AppMetrica;\nL_0093:\n\tv274._metrica = v254;\nL_0095:\n\tv275 = ~v67;\n\tif (v275) goto L_009A;\n\tSystem.Threading.Monitor::Exit(v126.syncRoot);\nL_009A:\n\tv111 = v75 + 1;\n\tv94 = v111 == 0;\n\tv79 = ~v94;\n\tif (v79) goto L_00A8;\n\tv292 = v77 == 0;\n\tv110 = ~v292;\n\tif (v110) goto L_00BD;\nL_00A8:\n\tgoto L_00B9;\n\tv132 = *([v116 @ X0_v5 (Il2CppClass<AppMetrica>)+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_00B9;\n\tv152 = \"il2cpp_codegen_runtime_class_init\"(v116, v70, v68, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv136 = AppMetrica;\nL_00B9:\n\treturn v139._metrica;\nL_00BD:\n\tv300 = new System.TypeLoadException();\n\tgoto L_00CB;\n\tgoto L_00CB;\n\tgoto L_00CB;\nL_00CB:\n\tgoto L_00D1;\n\tv303 = 0x6D2BC0(v300, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv77 = *([v303 @ X0_v21]);\n\tv270 = 0x6D2490(v303, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0095;\nL_00D1:\n\treturnVal2 = 0x6D2380(v300, 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn returnVal2;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			if (_metrica == null)
			{
				bool lockTaken = default(bool);
				Monitor.Enter(syncRoot, ref lockTaken);
				if (_metrica == null)
				{
					RuntimePlatform platform = Application.platform;
					if (platform == RuntimePlatform.Android)
					{
						YandexAppMetricaAndroid metrica = new YandexAppMetricaAndroid();
						_metrica = metrica;
					}
				}
				int num;
				int num2;
				if (_metrica != null)
				{
					num = 0;
					num2 = 0;
				}
				else
				{
					YandexAppMetricaDummy metrica2 = new YandexAppMetricaDummy();
					_metrica = metrica2;
					num = 0;
					num2 = 0;
				}
				if (lockTaken)
				{
					Monitor.Exit(syncRoot);
				}
				if (num + 1 == 0 && num2 != 0)
				{
					TypeLoadException ex = new TypeLoadException();
					Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					IYandexAppMetrica result = default(IYandexAppMetrica);
					return result;
				}
			}
			return _metrica;
		}
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x15BAA58", Offset = "0x15BAA58", Length = "0x2B8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tv30 = &v31 @ stack_-128;\n\tgoto L_001C;\n\tv36 = *([1EC4EF0]);\n\tv37 = *([v36 @ X8_v18]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2029919]) = v56;\nL_001C:\n\t*([v24 @ X29_v1-C0]) = 0;\n\t*([v24 @ X29_v1-B8]) = 0;\n\t*([v24 @ X29_v1-C8]) = 0;\n\t*([v30 @ X21_v1+16]) = 0;\n\t*([v30 @ X21_v1+E]) = 0;\n\t*([v30 @ X21_v1+6]) = 0;\n\tv67 = 0;\n\tv68 = System.Nullable`1<System.Int32>::.ctor(&v67 @ stack_-130_v1 (System.Nullable`1<System.Int32>), this.SessionTimeoutSec);\n\tv74 = 0;\n\tv76 = System.Nullable`1<System.Boolean>::.ctor(&v74 @ stack_-134_v1 (System.Nullable`1<System.Boolean>), this.Logs);\n\tv81 = 0;\n\tv82 = System.Nullable`1<System.Boolean>::.ctor(&v81 @ stack_-138_v1 (System.Nullable`1<System.Boolean>), this.HandleFirstActivationAsUpdate);\n\tv87 = 0;\n\tv88 = System.Nullable`1<System.Boolean>::.ctor(&v87 @ stack_-13C_v1 (System.Nullable`1<System.Boolean>), this.StatisticsSending);\n\t*([v24 @ X29_v1-C8]) = 0;\n\t*([v24 @ X29_v1-C0]) = 0;\n\t*([v24 @ X29_v1-B8]) = 0;\n\t*([v30 @ X21_v1+28]) = 0;\n\t*([v30 @ X21_v1+36]) = *([v30 @ X21_v1+E]);\n\tv97 = 0;\n\tv98 = System.Nullable`1<System.Boolean>::.ctor(&v97 @ stack_-140_v1 (System.Nullable`1<System.Boolean>), this.LocationTracking);\n\tgoto L_005E;\n\tv106 = *([v102 @ X0_v12 (Il2CppClass<AppMetrica>)+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_005E;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v102, v93, v94, v41, v42, v43, v44, v45, v89, v90, v48, v49, v50, v51, v52, v53);\nL_005E:\n\tv113 = AppMetrica::get_Instance();\n\tv127 = v113 == 0;\n\tif (v127) goto L_00CF;\n\tv141 = *([v113 @ X0_v14 (IYandexAppMetrica)]);\n\tv145 = *([v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v145) goto L_009E;\n\tv199 = *([v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_0089:\n\tv205 = *([v199 @ X11_v5-8]) == IYandexAppMetrica;\n\tif (v205) goto L_00A1;\n\tv200 = v200 + 1;\n\tv288 = v200 < *([v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv178 = ~v288;\n\tv199 = v199 + 0x10;\n\tv154 = ~v178;\n\tif (v154) goto L_0089;\nL_009E:\n\tv297 = 0x8909C4(v113, IYandexAppMetrica, 3, v41, v42, v43, v44, v45, *([v30 @ X21_v1+36]), *([v30 @ X21_v1+28]), *([v30 @ X21_v1+36]), v49, v50, v51, v52, v53);\n\tgoto L_00A8;\nL_00A1:\n\tv290 = *([v199 @ X11_v5]) + 3;\n\tv291 = v290 << 4;\n\tv292 = v141 + v291;\n\tv297 = v292 + 0x130;\nL_00A8:\n\t*([v24 @ X29_v1-B0]) = this.ApiKeyAndroid;\n\t*([v24 @ X29_v1-A8]) = 0;\n\t*([v24 @ X29_v1-90]) = *([v24 @ X29_v1-B8]);\n\t*([v24 @ X29_v1-88]) = 0;\n\t*([v30 @ X21_v1+78]) = *([v24 @ X29_v1-C8]);\n\t*([v24 @ X29_v1-80]) = 0;\n\t*([v24 @ X29_v1-7E]) = 0;\n\t*([v24 @ X29_v1-7C]) = 0;\n\t*([v24 @ X29_v1-7A]) = 0;\n\t*([v24 @ X29_v1-78]) = 0;\n\t*([v30 @ X21_v1+A2]) = *([v30 @ X21_v1+28]);\n\t*([v30 @ X21_v1+B0]) = *([v30 @ X21_v1+36]);\n\t*([v24 @ X29_v1-58]) = 0;\n\t*([v24 @ X29_v1-52]) = 0;\n\t*([v30 @ X21_v1+C2]) = 0;\n\tv272 = &v25 @ stack_-10_v2 - 0xB0;\n\t*([v297 @ X0_v16])(v302, v113, v272, *([v297 @ X0_v16+8]), v41, v42, v43, v44, v45, *([v30 @ X21_v1+36]), *([v30 @ X21_v1+28]), *([v30 @ X21_v1+36]), v49, v50, v51, v52, v53);\n\tAppMetrica::ProcessCrashReports(this);\n\treturn;\nL_00CF:\n\tthrow System.NullReferenceException;\n// 144 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetupMetrica()
	{
		//IL_00a4: Expected I, but got O
		//IL_02c1: Expected O, but got I
		//IL_00df: Expected O, but got I
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0183: Expected O, but got I
		//IL_0192: Expected O, but got I
		//IL_012b: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		object obj4 = default(object);
		object obj3 = obj4;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		int? num = null;
		num = (int)SessionTimeoutSec;
		bool? flag = null;
		flag = Logs;
		bool? flag2 = null;
		flag2 = HandleFirstActivationAsUpdate;
		bool? flag3 = null;
		flag3 = StatisticsSending;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X21_v1+E]");
		_ = 0;
		bool? flag4 = null;
		flag4 = LocationTracking;
		IYandexAppMetrica instance = Instance;
		if (instance != null)
		{
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0144;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+B0]");
			object obj5 = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v199 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v11 (Il2CppClass<IYandexAppMetrica>)+126]");
				bool flag5 = (long)num3 < 0L;
				bool flag6 = !flag5;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_0144;
			}
			object obj6 = obj5 + 3;
			int num4 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr + (long)num4;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_023b;
		}
		throw new NullReferenceException();
		IL_023b:
		_ = ApiKeyAndroid;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-B8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-C8]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X21_v1+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X21_v1+36]");
		_ = 0;
		_ = 0;
		_ = 0;
		_ = 0;
		object obj9 = (long)(IntPtr)obj2 - 176L;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v297 @ X0_v16] (should have been resolved before IL gen)");
		ProcessCrashReports();
		return;
		IL_0144:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_023b;
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x15BAEF8", Offset = "0x15BAEF8", Length = "0x120")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED6F68]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202991A]) = v38;\nL_0019:\n\tgoto L_0022;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = AppMetrica;\nL_0022:\n\tv54 = ~v52._isInitialized;\n\tif (v54) goto L_0041;\n\tv58 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_003C;\n\tv82 = *([v65 @ X8_v14+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_003C;\n\tv102 = v65;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v102, v57, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tUnityEngine.Object::Destroy(v58);\n\treturn;\nL_0041:\n\tgoto L_004C;\n\tv69 = *([v48 @ X0_v3 (Il2CppClass<AppMetrica>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_004C;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv103 = AppMetrica;\n\tv77 = *([v103 @ X8_v10+B8]);\nL_004C:\n\tv76._isInitialized = 1;\n\tv81 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_005E;\n\tv104 = *([v98 @ X8_v9+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tgoto L_005E;\n\tv127 = v98;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v127, v80, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005E:\n\tUnityEngine.Object::DontDestroyOnLoad(v81);\n\tAppMetrica::SetupMetrica(this);\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		if (_isInitialized)
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		_isInitialized = true;
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
		SetupMetrica();
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x15BB018", Offset = "0x15BB018", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EFD788]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202991B]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = AppMetrica::get_Instance();\n\tv53 = *([v49 @ X0_v4 (IYandexAppMetrica)]);\n\tv57 = *([v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v57) goto L_0045;\n\tv110 = *([v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_0030:\n\tv116 = *([v110 @ X11_v5-8]) == IYandexAppMetrica;\n\tif (v116) goto L_0048;\n\tv111 = v111 + 1;\n\tv167 = v111 < *([v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv90 = ~v167;\n\tv110 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_0030;\nL_0045:\n\tv174 = 0x8909C4(v49, IYandexAppMetrica, 4, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004C;\nL_0048:\n\tv169 = *([v110 @ X11_v5]) + 4;\n\tv170 = v169 << 4;\n\tv171 = v53 + v170;\n\tv174 = v171 + 0x130;\nL_004C:\n\tv129 = *([v174 @ X0_v6]);\n\tv151 = *([v174 @ X0_v6+8]);\n\t// 83 IndirectJump v129 @ X2_v2, v49 @ X0_v4 (IYandexAppMetrica), v49 @ X0_v4 (IYandexAppMetrica), v151 @ X1_v2, v129 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		//IL_001b: Expected I, but got O
		//IL_0155: Expected O, but got I
		//IL_0056: Expected O, but got I
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00fa: Expected O, but got I
		//IL_0109: Expected O, but got I
		//IL_00a2: Expected O, but got I
		IYandexAppMetrica instance = Instance;
		IntPtr intPtr = (IntPtr)instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00bb;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00bb;
		}
		object obj2 = obj + 4;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_013d;
		IL_00bb:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_013d;
		IL_013d:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X0_v6+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X2_v2 (should have been resolved before IL gen)");
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0x15BB0EC", Offset = "0x15BB0EC", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EF6898]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202991C]) = v38;\nL_0014:\n\tv40 = ~this.ExceptionsReporting;\n\tif (v40) goto L_002F;\n\tv44 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v44, this, Il2CppMethodInfo);\n\tUnityEngine.Application::add_logMessageReceived(v44);\n\treturn;\nL_002F:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		if (ExceptionsReporting)
		{
			Application.LogCallback value = HandleLog;
			Application.logMessageReceived += value;
		}
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0x15BB174", Offset = "0x15BB174", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECC5D8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202991D]) = v38;\nL_0014:\n\tv40 = ~this.ExceptionsReporting;\n\tif (v40) goto L_002F;\n\tv44 = new UnityEngine.Application+LogCallback();\n\tUnityEngine.Application+LogCallback::.ctor(v44, this, Il2CppMethodInfo);\n\tUnityEngine.Application::remove_logMessageReceived(v44);\n\treturn;\nL_002F:\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		if (ExceptionsReporting)
		{
			Application.LogCallback value = HandleLog;
			Application.logMessageReceived -= value;
		}
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x15BB1FC", Offset = "0x15BB1FC", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EAF768]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pauseStatus, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202991E]) = v41;\nL_001A:\n\tv47 = this._actualPauseStatus == 0;\n\tv52 = ~v47;\n\tv54 = v52 ^ pauseStatus;\n\tv56 = v54 == 0;\n\tif (v56) goto L_0064;\n\tthis._actualPauseStatus = pauseStatus;\n\tv63 = pauseStatus == 0;\n\tif (v63) goto L_0067;\n\tgoto L_0036;\n\tv130 = *([v60 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv131 = v130 == 0;\n\tv132 = ~v131;\n\tif (v132) goto L_0036;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v60, pauseStatus, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0036:\n\tv137 = AppMetrica::get_Instance();\n\tv305 = *([v137 @ X0_v16 (IYandexAppMetrica)]);\n\tv155 = *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v155) goto L_FFFFFFFF;\n\tv229 = *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_0049:\n\tv235 = *([v229 @ X11_v12-8]) == IYandexAppMetrica;\n\tif (v235) goto L_0098;\n\tv230 = v230 + 1;\n\tv282 = v230 < *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv185 = ~v282;\n\tv229 = v229 + 0x10;\n\tv169 = ~v185;\n\tif (v169) goto L_0049;\n\tgoto L_0095;\nL_0064:\n\treturn;\nL_0067:\n\tgoto L_006D;\n\tv138 = *([v60 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_006D;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v60, pauseStatus, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv145 = AppMetrica::get_Instance();\n\tv305 = *([v145 @ X0_v13 (IYandexAppMetrica)]);\n\tv162 = *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v162) goto L_FFFFFFFF;\n\tv271 = *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_0080:\n\tv277 = *([v271 @ X11_v7-8]) == IYandexAppMetrica;\n\tif (v277) goto L_009B;\n\tv272 = v272 + 1;\n\tv285 = v272 < *([v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv213 = ~v285;\n\tv271 = v271 + 0x10;\n\tv197 = ~v213;\n\tif (v197) goto L_0080;\nL_0095:\n\tv311 = 0x8909C4(v312, v252, v241, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_009F;\nL_0098:\n\tv300 = *([v229 @ X11_v12]) + 5;\n\tgoto L_009C;\nL_009B:\n\tv300 = *([v271 @ X11_v7]) + 4;\nL_009C:\n\tv306 = v300 << 4;\n\tv307 = v305 + v306;\n\tv311 = v307 + 0x130;\nL_009F:\n\tv82 = *([v311 @ X0_v5]);\n\tv105 = *([v311 @ X0_v5+8]);\n\t// 168 IndirectJump v82 @ X2_v2, v312 @ X19_v4 (IYandexAppMetrica), v312 @ X19_v4 (IYandexAppMetrica), v105 @ X1_v3, v82 @ X2_v2, v26 @ X3, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnApplicationPause(bool pauseStatus)
	{
		//IL_0127: Expected I, but got O
		//IL_01de: Expected I, but got O
		//IL_0047: Expected I, but got O
		//IL_0162: Expected O, but got I
		//IL_00fe: Expected I, but got O
		//IL_02d7: Expected O, but got I
		//IL_0082: Expected O, but got I
		//IL_02fe: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Expected O, but got Unknown
		//IL_01ae: Expected O, but got I
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_00ce: Expected O, but got I
		bool flag = !_actualPauseStatus;
		bool flag2 = !flag;
		if (!(flag2 ^ pauseStatus))
		{
			return;
		}
		_actualPauseStatus = pauseStatus;
		IYandexAppMetrica instance;
		IntPtr intPtr;
		object obj2 = default(object);
		IYandexAppMetrica instance2;
		if (pauseStatus)
		{
			instance = Instance;
			intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v229 @ X11_v12-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]");
				bool flag3 = (long)num2 < 0L;
				bool flag4 = !flag3;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_00e7;
			}
			obj2 = obj + 5;
		}
		else
		{
			instance2 = Instance;
			intPtr = (IntPtr)instance2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01c7;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+B0]");
			object obj3 = 0L + 8L;
			int num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ X11_v7-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X8_v10 (Il2CppClass<IYandexAppMetrica>)+126]");
				bool flag5 = (long)num4 < 0L;
				bool flag6 = !flag5;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_01c7;
			}
			obj2 = obj3 + 4;
		}
		goto IL_02e1;
		IL_02e1:
		int num5 = (int)((long)(IntPtr)obj2 << 4);
		object obj4 = (long)intPtr + (long)num5;
		object obj5 = (long)(IntPtr)obj4 + 304L;
		goto IL_02bf;
		IL_01c7:
		int num6 = 4;
		IntPtr intPtr2 = (IntPtr)typeof(IYandexAppMetrica);
		IYandexAppMetrica yandexAppMetrica = instance2;
		goto IL_0281;
		IL_02bf:
		object obj6 = obj5;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X0_v5+8]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ X2_v2 (should have been resolved before IL gen)");
		goto IL_02e1;
		IL_00e7:
		num6 = 5;
		intPtr2 = (IntPtr)typeof(IYandexAppMetrica);
		yandexAppMetrica = instance;
		goto IL_0281;
		IL_0281:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_02bf;
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0x15BAD10", Offset = "0x15BAD10", Length = "0x1E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF5CC0]);\n\tv35 = *([v34 @ X8_v25]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202991F]) = v54;\nL_001B:\n\tv55 = this.ExceptionsReporting;\n\tv56 = ~this.ExceptionsReporting;\n\tif (v56) goto L_00BF;\n\tgoto L_002B;\n\tv164 = *([v59 @ X0_v3+E0]);\n\tv165 = v164 == 0;\n\tv166 = ~v165;\n\tif (v166) goto L_002B;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v59, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_002B:\n\tv141 = UnityEngine.CrashReport::get_reports();\n\tv290 = v141.Length;\n\tv105 = v141.Length < 1;\n\tif (v105) goto L_00BF;\nL_0045:\n\tv292 = v254 < v290;\n\tv263 = ~v292;\n\tif (v263) goto L_00C0;\n\tv151 = v141[v254 @ X24_v5 (System.Int32)];\n\tv297 = v151.time;\n\t// 90 Box v301 @ X0_v15 (System.Object), typeof(System.DateTime), &v297 @ X8_v14 (System.DateTime)\n\tv315 = System.String::Format(\"Time: {0}\\nText: {1}\", v301, v151.text);\n\tgoto L_006D;\n\tv312 = *([v270 @ X8_v16+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_006D;\n\tv318 = v270;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v318, v249, v246, v244, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_006D:\n\tv266 = AppMetrica::get_Instance();\n\tv319 = *([v266 @ X0_v19 (IYandexAppMetrica)]);\n\tv143 = *([v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v143) goto L_0094;\n\tv354 = *([v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_007F:\n\tv368 = *([v354 @ X11_v8-8]) == IYandexAppMetrica;\n\tif (v368) goto L_0097;\n\tv353 = v353 + 1;\n\tv373 = v353 < *([v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv348 = ~v373;\n\tv354 = v354 + 0x10;\n\tv332 = ~v348;\n\tif (v332) goto L_007F;\nL_0094:\n\tv389 = 0x8909C4(v266, IYandexAppMetrica, 8, 0, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_009B;\nL_0097:\n\tv375 = *([v354 @ X11_v8]) + 8;\n\tv376 = v375 << 4;\n\tv55 = v319 + v376;\n\tv389 = v55 + 0x130;\nL_009B:\n\tv55 = *([v389 @ X0_v20]);\n\t*([v389 @ X0_v20])(v394, v266, \"Crash\", v315, *([v389 @ X0_v20+8]), v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tUnityEngine.CrashReport::Remove(v141[v254 @ X24_v5 (System.Int32)]);\n\tv290 = v141.Length;\n\tv254 = v254 + 1;\n\tv104 = v254 < v141.Length;\n\tif (v104) goto L_0045;\nL_00BF:\n\treturn;\nL_00C0:\n\tv295 = new System.IndexOutOfRangeException();\n\tthrow v295;\n\tthrow System.NullReferenceException;\n// 136 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ProcessCrashReports()
	{
		//IL_00ba: Expected I, but got O
		//IL_0212: Expected I4, but got O
		//IL_00f5: Expected O, but got I
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01a7: Expected O, but got I4
		//IL_0141: Expected O, but got I
		bool exceptionsReporting = ExceptionsReporting;
		if (!ExceptionsReporting)
		{
			return;
		}
		CrashReport[] reports = CrashReport.reports;
		int num = reports.Length;
		if (reports.Length < 1)
		{
			return;
		}
		int num2 = 0;
		object obj3 = default(object);
		while (num2 < num)
		{
			CrashReport crashReport = reports[num2];
			DateTime time = crashReport.time;
			object arg = time;
			string text = $"Time: {arg}\nText: {crashReport.text}";
			IYandexAppMetrica instance = Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_015a;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+B0]");
			object obj = 0L + 8L;
			int num3 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
				{
					break;
				}
				num3++;
				int num4 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ X8_v17 (Il2CppClass<IYandexAppMetrica>)+126]");
				bool flag = (long)num4 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_015a;
			}
			object obj2 = obj + 8;
			int num5 = (int)((long)(IntPtr)obj2 << 4);
			exceptionsReporting = (byte)((ulong)(long)intPtr + (ulong)num5) != 0;
			obj3 = (exceptionsReporting ? 1 : 0) + 304;
			goto IL_020a;
			IL_015a:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_020a;
			IL_020a:
			exceptionsReporting = (byte)(int)obj3 != 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v389 @ X0_v20] (should have been resolved before IL gen)");
			reports[num2].Remove();
			num = reports.Length;
			num2++;
			if (num2 >= reports.Length)
			{
				return;
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0x15BB380", Offset = "0x15BB380", Length = "0x108")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1F0B470]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, condition, stackTrace, type, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2029920]) = v44;\nL_0020:\n\tv54 = type != 4;\n\tif (v54) goto L_005F;\n\tgoto L_002E;\n\tv67 = *([v57 @ X0_v2 (Il2CppClass<AppMetrica>)+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_002E;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v57, condition, stackTrace, type, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_002E:\n\tv74 = AppMetrica::get_Instance();\n\tv138 = *([v74 @ X0_v4 (IYandexAppMetrica)]);\n\tv122 = *([v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v122) goto L_0056;\n\tv182 = *([v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_0041:\n\tv188 = *([v182 @ X11_v5-8]) == IYandexAppMetrica;\n\tif (v188) goto L_0061;\n\tv183 = v183 + 1;\n\tv193 = v183 < *([v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv164 = ~v193;\n\tv182 = v182 + 0x10;\n\tv148 = ~v164;\n\tif (v148) goto L_0041;\nL_0056:\n\tv200 = 0x8909C4(v74, IYandexAppMetrica, 8, type, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0065;\nL_005F:\n\treturn;\nL_0061:\n\tv195 = *([v182 @ X11_v5]) + 8;\n\tv196 = v195 << 4;\n\tv197 = v138 + v196;\n\tv200 = v197 + 0x130;\nL_0065:\n\tv78 = *([v200 @ X0_v6]);\n\tv76 = *([v200 @ X0_v6+8]);\n\t// 113 IndirectJump v78 @ X4_v1, v74 @ X0_v4 (IYandexAppMetrica), v74 @ X0_v4 (IYandexAppMetrica), condition @ X1 (System.String), stackTrace @ X2 (System.String), v76 @ X3_v1, v78 @ X4_v1, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void HandleLog(string condition, string stackTrace, LogType type)
	{
		//IL_0020: Expected I, but got O
		//IL_0176: Expected O, but got I
		//IL_005b: Expected O, but got I
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_0100: Expected O, but got I
		//IL_010f: Expected O, but got I
		//IL_00a7: Expected O, but got I
		if (type != LogType.Exception)
		{
			return;
		}
		IYandexAppMetrica instance = Instance;
		IntPtr intPtr = (IntPtr)instance;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]");
		if ((IntPtr)0 == (IntPtr)0)
		{
			goto IL_00c0;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+B0]");
		object obj = 0L + 8L;
		int num = 0;
		while (true)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v182 @ X11_v5-8]");
			if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
			{
				break;
			}
			num++;
			int num2 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v7 (Il2CppClass<IYandexAppMetrica>)+126]");
			bool flag = (long)num2 < 0L;
			bool flag2 = !flag;
			obj = (long)(IntPtr)obj + 16L;
			if (!flag2)
			{
				continue;
			}
			goto IL_00c0;
		}
		object obj2 = obj + 8;
		int num3 = (int)((long)(IntPtr)obj2 << 4);
		object obj3 = (long)intPtr + (long)num3;
		object obj4 = (long)(IntPtr)obj3 + 304L;
		goto IL_015e;
		IL_015e:
		object obj5 = obj4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ X0_v6+8]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v78 @ X4_v1 (should have been resolved before IL gen)");
		return;
		IL_00c0:
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
		goto IL_015e;
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0x15BB488", Offset = "0x15BB488", Length = "0x24")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ExceptionsReporting = 1;\n\tthis.SessionTimeoutSec = 0xA;\n\tthis.LocationTracking = 1;\n\tthis.Logs = 1;\n\tthis.StatisticsSending = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AppMetrica()
	{
		ExceptionsReporting = true;
		SessionTimeoutSec = 10u;
		LocationTracking = true;
		Logs = true;
		StatisticsSending = true;
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0x15BB4AC", Offset = "0x15BB4AC", Length = "0x84")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EBAD70]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029921]) = v37;\nL_0016:\n\tv41._isInitialized = 0;\n\tv43._metrica = 0;\n\tv47 = new UnityEngine.Object();\n\tUnityEngine.Object::.ctor(v47);\n\tv51.syncRoot = v47;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static AppMetrica()
	{
		UnityEngine.Object obj = new UnityEngine.Object();
		syncRoot = obj;
	}
}
