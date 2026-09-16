using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics;

namespace UnityEngine.UDP
{
	[HideInInspector]
	[Token(Token = "0x2000003")]
	internal class UdpGameManager : MonoBehaviour
	{
		[Token(Token = "0x400000E")]
		public static readonly string OBJECT_NAME = "UnityChannelGameManager";

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x15CCB88", Offset = "0x15CCB88", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB5D40]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299F1]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::Log(\"udp.gameManager.awake\");\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(1);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Debug.Log("udp.gameManager.awake");
			AnalyticsService.onPlayerStateChanged(AnalyticsService.SessionState.kSessionStarted);
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15CCBFC", Offset = "0x15CCBFC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA4CA8]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20299F2]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tUnityEngine.Debug::Log(\"udp.gameManager.start\");\n\tv58 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_003C;\n\tv66 = *([v62 @ X8_v11+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tif (v68) goto L_003C;\n\tv79 = v62;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v79, v57, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_003C:\n\tUnityEngine.Object::DontDestroyOnLoad(v58);\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Debug.Log("udp.gameManager.start");
			GameObject target = base.gameObject;
			Object.DontDestroyOnLoad(target);
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15CCCAC", Offset = "0x15CCCAC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private void Update()
		{
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15CCCB0", Offset = "0x15CCCB0", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC2C8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, pauseStatus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20299F3]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, pauseStatus, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tUnityEngine.Debug::Log(\"udp.gameManager.OnApplicationPause\");\n\tv60 = pauseStatus == 0;\n\tv64 = ~v60;\n\tif (v64) goto L_FFFFFFFF;\n\tv65 = 2 + 1;\n\tgoto L_0035;\nL_0035:\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(v67);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationPause(bool pauseStatus)
		{
			Debug.Log("udp.gameManager.OnApplicationPause");
			AnalyticsService.SessionState sessionState;
			if (!pauseStatus)
			{
				int num = 2 + 1;
				sessionState = (AnalyticsService.SessionState)num;
			}
			else
			{
				sessionState = AnalyticsService.SessionState.kSessionPaused;
			}
			AnalyticsService.onPlayerStateChanged(sessionState);
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15CCD30", Offset = "0x15CCD30", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA6528]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299F4]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tUnityEngine.Debug::Log(\"udp.gameManager.OnApplicationQuit\");\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(0);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnApplicationQuit()
		{
			Debug.Log("udp.gameManager.OnApplicationQuit");
			AnalyticsService.onPlayerStateChanged(default(AnalyticsService.SessionState));
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x15CCDA4", Offset = "0x15CCDA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UdpGameManager()
		{
		}
	}
}
