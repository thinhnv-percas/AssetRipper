using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics.Events;

namespace UnityEngine.UDP.Analytics
{
	[HideInInspector]
	[Token(Token = "0x2000021")]
	internal static class AnalyticsClient
	{
		[Token(Token = "0x2000022")]
		private enum State
		{
			[Token(Token = "0x400006C")]
			kStateNotReady = 0,
			[Token(Token = "0x400006D")]
			kStateReady = 1,
			[Token(Token = "0x400006E")]
			kStatePrepared = 2,
			[Token(Token = "0x400006F")]
			kStateStarted = 3,
			[Token(Token = "0x4000070")]
			kStatePaused = 4,
			[Token(Token = "0x4000071")]
			kStateStopped = 5
		}

		[Token(Token = "0x4000063")]
		internal static SessionInfo m_sessionInfo;

		[Token(Token = "0x4000064")]
		private static bool m_IsNewSession;

		[Token(Token = "0x4000065")]
		private static State m_State;

		[Token(Token = "0x4000066")]
		private static bool m_InStateTransition;

		[Token(Token = "0x4000067")]
		private static string m_AppId;

		[Token(Token = "0x4000068")]
		private static string m_ClientId;

		[Token(Token = "0x4000069")]
		private static string m_TargetStore;

		[Token(Token = "0x400006A")]
		private static bool m_AppInstalled;

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x15C4EC0", Offset = "0x15C4EC0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EA8700]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appId, targetStore, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202997F]) = v44;\nL_001B:\n\tv48.m_ClientId = clientId;\n\tv49.m_AppId = appId;\n\tv50.m_TargetStore = targetStore;\n\tv54 = new UnityEngine.UDP.Analytics.SessionInfo();\n\tSystem.Object::.ctor(v54);\n\tv58.m_sessionInfo = v54;\n\tv59 = UnityEngine.UDP.Analytics.PlatformWrapper::GetAppInstalled();\n\tv63.m_AppInstalled = v59;\n\tv70 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(1);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(string clientId, string appId, string targetStore)
		{
			m_ClientId = clientId;
			m_AppId = appId;
			m_TargetStore = targetStore;
			SessionInfo sessionInfo = new SessionInfo();
			m_sessionInfo = sessionInfo;
			bool appInstalled = PlatformWrapper.GetAppInstalled();
			m_AppInstalled = appInstalled;
			bool flag = RequestStateChange(State.kStateReady);
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x15C507C", Offset = "0x15C507C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1ECE0D8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sessionId, sessionElapsedTime, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029980]) = v41;\nL_0016:\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SetSessionId(sessionId);\n\tv47 = sessionState == 3;\n\tif (v47) goto L_FFFFFFFF;\n\tv56 = sessionState == 2;\n\tif (v56) goto L_FFFFFFFF;\n\tv66 = sessionState == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tv85 = UnityEngine.UDP.Analytics.AnalyticsClient::CloseService();\n\treturn;\n\tgoto L_0044;\nL_0044:\n\tv102 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(v94);\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnPlayerSessionStateChanged(AnalyticsService.SessionState sessionState, string sessionId, ulong sessionElapsedTime)
		{
			SetSessionId(sessionId);
			State state;
			switch (sessionState)
			{
			case AnalyticsService.SessionState.kSessionStopped:
			{
				bool flag = CloseService();
				return;
			}
			case AnalyticsService.SessionState.kSessionPaused:
				state = State.kStatePaused;
				break;
			default:
				state = State.kStateStarted;
				break;
			}
			bool flag2 = RequestStateChange(state);
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x15C521C", Offset = "0x15C521C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(3);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool StartSession()
		{
			return RequestStateChange(State.kStateStarted);
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x15C5214", Offset = "0x15C5214", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(3);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ResumeSession()
		{
			return RequestStateChange(State.kStateStarted);
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x15C520C", Offset = "0x15C520C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(4);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool PauseSession()
		{
			return RequestStateChange(State.kStatePaused);
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x15C5224", Offset = "0x15C5224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(5);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool StopSession()
		{
			return RequestStateChange(State.kStateStopped);
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x15C51A4", Offset = "0x15C51A4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ED12E8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029981]) = v35;\nL_0016:\n\tv41 = v39.m_State == 0;\n\tif (v41) goto L_FFFFFFFF;\n\tv43 = UnityEngine.UDP.Analytics.AnalyticsClient::RequestStateChange(5);\n\tgoto L_0021;\nL_0021:\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool CloseService()
		{
			if (m_State != State.kStateNotReady)
			{
				bool flag = RequestStateChange(State.kStateStopped);
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x15C4FD8", Offset = "0x15C4FD8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([2029982]) & 1;\n\tv15 = v14 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_001B;\n\treturnVal1 = 0x15CCEC0(state, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn returnVal1;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2029982]) = X8;\nL_001B:\n\tv42 = ~v40.m_InStateTransition;\n\tv43 = ~v42;\n\tif (v43) goto L_0034;\n\tv46 = 0;\n\tv40.m_InStateTransition = 1;\n\tv48 = UnityEngine.UDP.Analytics.AnalyticsClient::DetermineNextState(state, &v46 @ stack_-24_v3 (UnityEngine.UDP.Analytics.AnalyticsClient+State));\n\tv55 = v48 == 0;\n\tif (v55) goto L_002D;\n\tv52 = UnityEngine.UDP.Analytics.AnalyticsClient::ProcessState(0);\nL_002D:\n\tv57.m_InStateTransition = 0;\nL_0034:\n\treturn v52;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool RequestStateChange(State state)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2029982]");
			if (0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15CCEC0 (inside UnityEngine.UDP.Utils::.cctor +0x88)");
				bool result = default(bool);
				return result;
			}
			bool flag = !m_InStateTransition;
			bool flag2 = !flag;
			bool result2 = false;
			if (!flag2)
			{
				State nextState = default(State);
				m_InStateTransition = true;
				bool flag3 = DetermineNextState(state, ref nextState);
				bool flag4 = !flag3;
				result2 = false;
				if (!flag4)
				{
					result2 = ProcessState(default(State));
				}
				m_InStateTransition = false;
			}
			return result2;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x15C522C", Offset = "0x15C522C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC06F0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, nextState, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2029983]) = v41;\nL_0015:\n\t*([nextState @ X1 (State&)]) = requestedState;\n\tv56 = v45.m_State != requestedState;\n\tif (v56) goto L_002C;\n\tgoto L_0069;\nL_002C:\n\tv90 = v45.m_State == 5;\n\tif (v90) goto L_0048;\n\tv128 = v45.m_State == 1;\n\tif (v128) goto L_004F;\n\tv143 = v45.m_State == 0;\n\tv141 = ~v143;\n\tif (v141) goto L_FFFFFFFF;\nL_0048:\n\tv58 = requestedState != 1;\n\tif (v58) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_004F:\n\tv73 = requestedState == 4;\n\tif (v73) goto L_FFFFFFFF;\n\tv145 = requestedState != 3;\n\tif (v145) goto L_FFFFFFFF;\n\t*([nextState @ X1 (State&)]) = 2;\nL_0069:\n\treturn returnVal1;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static bool DetermineNextState(State requestedState, ref State nextState)
		{
			ref State reference = ref *(State*)(int)requestedState;
			if (m_State != requestedState)
			{
				if (m_State == State.kStateStopped)
				{
					goto IL_0078;
				}
				if (m_State != State.kStateReady)
				{
					if (m_State == State.kStateNotReady)
					{
						goto IL_0078;
					}
				}
				else
				{
					if (requestedState == State.kStatePaused)
					{
						goto IL_0005;
					}
					if (requestedState == State.kStateStarted)
					{
						reference = ref *(State*)2;
					}
				}
				goto IL_0115;
			}
			goto IL_0005;
			IL_0115:
			return true;
			IL_0005:
			return false;
			IL_0078:
			if (requestedState != State.kStateReady)
			{
				goto IL_0005;
			}
			goto IL_0115;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x15C52DC", Offset = "0x15C52DC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = nextState - 1;\n\tv8 = v6 < 4;\n\tv9 = ~v8;\n\tv10 = v6 - 4;\n\tv12 = v10 == 0;\n\tv17 = ~v12;\n\tv18 = v9 & v17;\n\tif (v18) goto L_001A;\n\tv20 = 0x183B000 + 0xEA4;\n\tv22 = *([v20 @ X9_v2 (System.Int32)+v6 @ X8_v1 (System.Int32)*4]) + v20;\n\t// 21 IndirectJump v22 @ X8_v3, nextState @ X0 (UnityEngine.UDP.Analytics.AnalyticsClient+State), nextState @ X0 (UnityEngine.UDP.Analytics.AnalyticsClient+State), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnEnterStateReady(X0);\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnEnterStatePrepared(X0);\n\tgoto L_0020;\nL_001A:\n\tgoto L_0024;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnEnterStateStarted(X0);\n\tgoto L_0020;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnEnterStatePaused(X0);\n\tgoto L_0020;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnEnterStateStopped(X0);\nL_0020:\n\tX0 = 0 | 1;\nL_0024:\n\treturn 0;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool ProcessState(State nextState)
		{
			//IL_008f: Expected O, but got I
			int num = (int)(nextState - 1);
			bool flag = num < 4;
			bool flag2 = !flag;
			int num2 = num - 4;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25407488 + 3748;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v2 (System.Int32)+v6 @ X8_v1 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X8_v3 (should have been resolved before IL gen)");
			}
			return false;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x15C5338", Offset = "0x15C5338", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1ED39D8]);\n\tv17 = *([v16 @ X8_v20]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029984]) = v37;\nL_0016:\n\tgoto L_0022;\n\tv43 = *([1EAB5E0]);\n\tv44 = *([v43 @ X8_v17]);\n\tv45 = \"il2cpp_codegen_initialize_method\"(v44, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv48 = 0 | 1;\n\t*([20299F7]) = v48;\nL_0022:\n\tv53.m_State = 1;\n\tv55 = v54.m_sessionInfo;\n\tv55.m_AppId = v54.m_AppId;\n\tv59 = v58.m_sessionInfo;\n\tv59.m_ClientId = v58.m_ClientId;\n\tv66 = v68.m_sessionInfo;\n\tv66.m_TargetStore = v68.m_TargetStore;\n\tv62 = v81.m_sessionInfo;\n\tv71 = UnityEngine.UDP.Analytics.PlatformWrapper::GetRuntimePlatformString();\n\tv62.m_Platform = v71;\n\tv63 = v82.m_sessionInfo;\n\tv72 = UnityEngine.SystemInfo::get_deviceModel();\n\tv63.m_SystemInfo = v72;\n\tv64 = v83.m_sessionInfo;\n\tv73 = UnityEngine.SystemInfo::get_deviceUniqueIdentifier();\n\tv64.m_DeviceId = v73;\n\tv84 = v106.m_sessionInfo;\n\tv84.m_Vr = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnterStateReady()
		{
			m_State = State.kStateReady;
			SessionInfo sessionInfo = m_sessionInfo;
			sessionInfo.MAppId = m_AppId;
			SessionInfo sessionInfo2 = m_sessionInfo;
			sessionInfo2.MClientId = m_ClientId;
			SessionInfo sessionInfo3 = m_sessionInfo;
			sessionInfo3.MTargetStore = m_TargetStore;
			SessionInfo sessionInfo4 = m_sessionInfo;
			string runtimePlatformString = PlatformWrapper.GetRuntimePlatformString();
			sessionInfo4.MPlatform = runtimePlatformString;
			SessionInfo sessionInfo5 = m_sessionInfo;
			string deviceModel = SystemInfo.deviceModel;
			sessionInfo5.MSystemInfo = deviceModel;
			SessionInfo sessionInfo6 = m_sessionInfo;
			string deviceUniqueIdentifier = SystemInfo.deviceUniqueIdentifier;
			sessionInfo6.MDeviceId = deviceUniqueIdentifier;
			SessionInfo sessionInfo7 = m_sessionInfo;
			sessionInfo7.m_Vr = false;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x15C5454", Offset = "0x15C5454", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EEDDE8]);\n\tv15 = *([v14 @ X8_v13]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029985]) = v35;\nL_0015:\n\tgoto L_0021;\n\tv41 = *([1EAB5E0]);\n\tv42 = *([v41 @ X8_v10]);\n\tv43 = \"il2cpp_codegen_initialize_method\"(v42, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = 0 | 1;\n\t*([20299F7]) = v46;\nL_0021:\n\tv51.m_State = 2;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnterStatePrepared()
		{
			m_State = State.kStatePrepared;
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x15C54CC", Offset = "0x15C54CC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F00BE8]);\n\tv19 = *([v18 @ X8_v22]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029986]) = v39;\nL_0017:\n\tgoto L_0023;\n\tv45 = *([1EAB5E0]);\n\tv46 = *([v45 @ X8_v19]);\n\tv47 = \"il2cpp_codegen_initialize_method\"(v46, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv50 = 0 | 1;\n\t*([20299F7]) = v50;\nL_0023:\n\tv55.m_State = 3;\n\tv58 = ~v56.m_IsNewSession;\n\tif (v58) goto L_0049;\n\tv63 = new UnityEngine.UDP.Analytics.Events.AppStartEvent();\n\tUnityEngine.UDP.Analytics.Events.AppStartEvent::.ctor(v63, v56.m_sessionInfo);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v63);\n\tv89 = ~v80.m_AppInstalled;\n\tv77 = ~v89;\n\tif (v77) goto L_0049;\n\tv93 = new UnityEngine.UDP.Analytics.Events.AppInstallEvent();\n\tUnityEngine.UDP.Analytics.Events.AppInstallEvent::.ctor(v93, v80.m_sessionInfo);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v93);\n\tv95.m_AppInstalled = 1;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SavePersistentValue();\nL_0049:\n\tv78.m_IsNewSession = 0;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnterStateStarted()
		{
			m_State = State.kStateStarted;
			if (m_IsNewSession)
			{
				AppStartEvent e = new AppStartEvent(m_sessionInfo);
				EventDispatcher.DispatchEvent(e);
				if (!m_AppInstalled)
				{
					AppInstallEvent e2 = new AppInstallEvent(m_sessionInfo);
					EventDispatcher.DispatchEvent(e2);
					m_AppInstalled = true;
					SavePersistentValue();
				}
			}
			m_IsNewSession = false;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x15C55D8", Offset = "0x15C55D8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SendAppRunningEvent();\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SavePersistentValue();\n\tgoto L_0017;\n\tv14 = *([1EAB5E0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv34 = 0 | 1;\n\t*([20299F7]) = v34;\nL_0017:\n\tv39.m_State = 4;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnterStatePaused()
		{
			SendAppRunningEvent();
			SavePersistentValue();
			m_State = State.kStatePaused;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x15C5634", Offset = "0x15C5634", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv16 = *([1F0A6F0]);\n\tv17 = *([v16 @ X8_v11]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2029987]) = v37;\nL_0020:\n\tv52 = v41.m_State != 3;\n\tif (v52) goto L_002A;\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SendAppRunningEvent();\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SavePersistentValue();\nL_002A:\n\tv59 = new UnityEngine.UDP.Analytics.Events.AppStopEvent();\n\tUnityEngine.UDP.Analytics.Events.AppStopEvent::.ctor(v59, v53.m_sessionInfo);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v59);\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnterStateStopped()
		{
			if (m_State == State.kStateStarted)
			{
				SendAppRunningEvent();
				SavePersistentValue();
			}
			AppStopEvent e = new AppStopEvent(m_sessionInfo);
			EventDispatcher.DispatchEvent(e);
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x15C597C", Offset = "0x15C597C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SendAppRunningEvent();\n\tUnityEngine.UDP.Analytics.AnalyticsClient::SavePersistentValue();\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void OnEnteringStatePausedOrStopped()
		{
			SendAppRunningEvent();
			SavePersistentValue();
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x15C5A20", Offset = "0x15C5A20", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F108F8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2029988]) = v39;\nL_0018:\n\tv45 = UnityEngine.UDP.Analytics.AnalyticsService::GetPlayerSessionElapsedTime();\n\tv51 = new UnityEngine.UDP.Analytics.Events.AppRunningEvent();\n\tUnityEngine.UDP.Analytics.Events.AppRunningEvent::.ctor(v51, v43.m_sessionInfo, v45);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v51);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SendAppRunningEvent()
		{
			ulong playerSessionElapsedTime = AnalyticsService.GetPlayerSessionElapsedTime();
			AppRunningEvent e = new AppRunningEvent(m_sessionInfo, playerSessionElapsedTime);
			EventDispatcher.DispatchEvent(e);
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x15C592C", Offset = "0x15C592C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EB0220]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029989]) = v35;\nL_001A:\n\tUnityEngine.UDP.Analytics.PlatformWrapper::SetAppInstalled(v41.m_AppInstalled);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SavePersistentValue()
		{
			PlatformWrapper.SetAppInstalled(m_AppInstalled);
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x15C5AA8", Offset = "0x15C5AA8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Analytics.AnalyticsService::GetPlayerSessionElapsedTime();\n\treturn returnVal1;\n")]
		private static ulong GetPlayerSessionElapsedTime()
		{
			return AnalyticsService.GetPlayerSessionElapsedTime();
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x15C5114", Offset = "0x15C5114", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFCCD0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202998A]) = v38;\nL_0017:\n\tv43 = v42.m_sessionInfo;\n\tv48 = System.String::op_Inequality(v43.m_SessionId, sessionId);\n\tv50.m_IsNewSession = v48;\n\tv61 = v65.m_sessionInfo;\n\tv61.m_SessionId = sessionId;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetSessionId(string sessionId)
		{
			SessionInfo sessionInfo = m_sessionInfo;
			bool isNewSession = sessionInfo.MSessionId != sessionId;
			m_IsNewSession = isNewSession;
			SessionInfo sessionInfo2 = m_sessionInfo;
			sessionInfo2.MSessionId = sessionId;
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x15C5C6C", Offset = "0x15C5C6C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB0438]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202998B]) = v38;\nL_0017:\n\tv42.m_State = state;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetState(State state)
		{
			m_State = state;
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x15C5CC0", Offset = "0x15C5CC0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EB3CD0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202998C]) = v35;\nL_001A:\n\treturn v41.m_sessionInfo;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SessionInfo GetSessionInfo()
		{
			return m_sessionInfo;
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x15C5D10", Offset = "0x15C5D10", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = *([1EFE6E0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202998D]) = v35;\nL_001A:\n\tv45 = v40.m_sessionInfo + 0x18;\n\tv55 = v40.m_sessionInfo != 0;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_002D:\n\treturn *([v58 @ X8_v8 (System.String)]);\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetSessionId()
		{
			//IL_0030: Expected O, but got I
			string result = (string)((long)(IntPtr)m_sessionInfo + 24L);
			if (m_sessionInfo == null)
			{
				return "";
			}
			return result;
		}
	}
}
