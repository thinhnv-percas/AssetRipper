using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[HideInInspector]
	[Token(Token = "0x2000026")]
	internal class AnalyticsService
	{
		[Token(Token = "0x2000027")]
		public enum SessionState
		{
			[Token(Token = "0x4000079")]
			kSessionStopped = 0,
			[Token(Token = "0x400007A")]
			kSessionStarted = 1,
			[Token(Token = "0x400007B")]
			kSessionPaused = 2,
			[Token(Token = "0x400007C")]
			kSessionResumed = 3
		}

		[Token(Token = "0x4000073")]
		private static SessionState m_PlayerSessionState;

		[Token(Token = "0x4000074")]
		private static string m_PlayerSessionId;

		[Token(Token = "0x4000075")]
		private static ulong m_PlayerSessionElapsedTime;

		[Token(Token = "0x4000076")]
		private static ulong m_PlayerSessionForegroundTime;

		[Token(Token = "0x4000077")]
		private static ulong m_PlayerSessionBackgroundTime;

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x15C5D78", Offset = "0x15C5D78", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = *([1EDCB60]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202998E]) = v35;\nL_0015:\n\tv39.m_PlayerSessionState = 0;\n\tv43.m_PlayerSessionId = \"\";\n\tv45.m_PlayerSessionElapsedTime = 0;\n\tv46.m_PlayerSessionForegroundTime = 0;\n\tv47.m_PlayerSessionBackgroundTime = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize()
		{
			//IL_002c: Expected I8, but got I4
			//IL_0036: Expected I8, but got I4
			//IL_0040: Expected I8, but got I4
			m_PlayerSessionState = default(SessionState);
			m_PlayerSessionId = "";
			m_PlayerSessionElapsedTime = 0uL;
			m_PlayerSessionForegroundTime = 0uL;
			m_PlayerSessionBackgroundTime = 0uL;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x15C5DF8", Offset = "0x15C5DF8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnPlayerQuit()
		{
			onPlayerStateChanged(default(SessionState));
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x15C6098", Offset = "0x15C6098", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = paused == 0;\n\tv7 = ~v3;\n\tif (v7) goto L_FFFFFFFF;\n\tv8 = 2 + 1;\n\tgoto L_000C;\nL_000C:\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(v10);\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnPlayerPaused(bool paused)
		{
			SessionState sessionState;
			if (!paused)
			{
				int num = 2 + 1;
				sessionState = (SessionState)num;
			}
			else
			{
				sessionState = SessionState.kSessionPaused;
			}
			onPlayerStateChanged(sessionState);
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x15C60A8", Offset = "0x15C60A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UDP.Analytics.AnalyticsService::onPlayerStateChanged(1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnAppAwake()
		{
			onPlayerStateChanged(SessionState.kSessionStarted);
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x15C5E00", Offset = "0x15C5E00", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv20 = *([1EE1748]);\n\tv21 = *([v20 @ X8_v51]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202998F]) = v40;\nL_0022:\n\tv55 = v44.m_PlayerSessionState != v38;\n\tif (v55) goto L_002B;\nL_002A:\n\treturn;\nL_002B:\n\tv75 = v44.m_PlayerSessionState == 0;\n\tif (v75) goto L_0054;\n\tv134 = UnityEngine.UDP.Analytics.PlatformWrapper::GetCurrentMillisecondsInUTC();\n\tv138.m_PlayerSessionState = v38;\n\tv139 = v38 == 0;\n\tif (v139) goto L_00B5;\n\tv145 = v38 == 1;\n\tif (v145) goto L_005F;\n\tv170 = v38 != 3;\n\tif (v170) goto L_00C6;\n\tgoto L_007A;\nL_0054:\n\tv57 = v38 != 1;\n\tif (v57) goto L_002A;\n\tv140 = UnityEngine.UDP.Analytics.PlatformWrapper::GetCurrentMillisecondsInUTC();\n\tv160.m_PlayerSessionState = 1;\nL_005F:\n\tv188 = UnityEngine.UDP.Analytics.PlatformWrapper::GetPlayerPrefsString(\"udp.player_sessionId\");\n\tv214.m_PlayerSessionId = v188;\n\tv218 = UnityEngine.PlayerPrefs::GetInt(\"udp.player_session_elapsed_time\", 0);\n\tv259.m_PlayerSessionElapsedTime = v218;\n\tv241 = UnityEngine.PlayerPrefs::GetInt(\"udp.player_session_background_time\", 0);\n\tv230.m_PlayerSessionBackgroundTime = v241;\nL_007A:\n\tv246.m_PlayerSessionForegroundTime = v245;\n\tv254 = System.String::op_Equality(v249.m_PlayerSessionId, \"\");\n\tv307 = v254 == 0;\n\tif (v307) goto L_0089;\n\tgoto L_009C;\nL_0089:\n\tv339 = v245 - v246.m_PlayerSessionBackgroundTime;\n\tv340 = v339 < 0x1B7740;\n\tv327 = ~v340;\n\tv326 = v339 - 0x1B7740;\n\tv324 = v326 == 0;\n\tv341 = ~v324;\n\tv319 = v327 & v341;\n\tif (v319) goto L_009C;\n\tv361 = v332.m_PlayerSessionElapsedTime == 0;\n\tv329 = ~v361;\n\tif (v329) goto L_00F2;\nL_009C:\n\tv359.m_PlayerSessionElapsedTime = 0;\n\tv360 = UnityEngine.UDP.Analytics.PlatformWrapper::GenerateRandomId();\n\tv369.m_PlayerSessionId = v360;\n\tUnityEngine.PlayerPrefs::SetString(\"udp.player_sessionId\", v371.m_PlayerSessionId);\n\tv274 = v367.m_PlayerSessionElapsedTime;\n\tgoto L_FFFFFFFF;\nL_00B5:\n\tUnityEngine.PlayerPrefs::SetString(\"udp.player_sessionId\", \"\");\n\tUnityEngine.PlayerPrefs::SetInt(\"udp.player_session_elapsed_time\", 0);\n\tgoto L_00E7;\nL_00C6:\n\tv200 = v134 - v197.m_PlayerSessionForegroundTime;\n\tv210 = v197.m_PlayerSessionForegroundTime != 0;\n\tif (v210) goto L_FFFFFFFF;\n\tgoto L_00D6;\nL_00D6:\n\tv309 = v197.m_PlayerSessionElapsedTime + v308;\n\tv197.m_PlayerSessionElapsedTime = v309;\n\tv310.m_PlayerSessionBackgroundTime = v134;\n\tUnityEngine.PlayerPrefs::SetInt(\"udp.player_session_elapsed_time\", v312.m_PlayerSessionElapsedTime);\n\tv274 = v344.m_PlayerSessionBackgroundTime;\nL_00E7:\n\tUnityEngine.PlayerPrefs::SetInt(v295, v273);\nL_00F2:\n\tUnityEngine.UDP.Analytics.AnalyticsClient::OnPlayerSessionStateChanged(v129.m_PlayerSessionState, v129.m_PlayerSessionId, v94);\n\treturn;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void onPlayerStateChanged(SessionState sessionState)
		{
			//IL_02c7: Expected I8, but got I4
			//IL_00ee: Expected I8, but got I4
			//IL_0343: Expected I8, but got I4
			//IL_0106: Expected I4, but got I8
			//IL_019f: Expected I8, but got I4
			//IL_0187: Expected I8, but got I4
			//IL_0377: Expected I4, but got I8
			//IL_024e: Expected I8, but got I4
			//IL_0320: Expected I4, but got I8
			SessionState sessionState2 = default(SessionState);
			if (m_PlayerSessionState == sessionState2)
			{
				return;
			}
			int value;
			string key;
			ulong num;
			ulong num4;
			string text;
			if (m_PlayerSessionState != SessionState.kSessionStopped)
			{
				ulong currentMillisecondsInUTC = PlatformWrapper.GetCurrentMillisecondsInUTC();
				m_PlayerSessionState = sessionState2;
				if (sessionState2 == SessionState.kSessionStopped)
				{
					PlayerPrefs.SetString("udp.player_sessionId", "");
					PlayerPrefs.SetInt("udp.player_session_elapsed_time", 0);
					value = 0;
					key = "udp.player_session_background_time";
					goto IL_032d;
				}
				bool flag = sessionState2 == SessionState.kSessionStarted;
				num = currentMillisecondsInUTC;
				if (!flag)
				{
					if (sessionState2 == SessionState.kSessionResumed)
					{
						num = currentMillisecondsInUTC;
						goto IL_02df;
					}
					long num2 = (long)(currentMillisecondsInUTC - m_PlayerSessionForegroundTime);
					long num3 = ((m_PlayerSessionForegroundTime != 0) ? num2 : 0);
					long playerSessionElapsedTime = (long)m_PlayerSessionElapsedTime + num3;
					m_PlayerSessionElapsedTime = (ulong)playerSessionElapsedTime;
					m_PlayerSessionBackgroundTime = currentMillisecondsInUTC;
					PlayerPrefs.SetInt("udp.player_session_elapsed_time", (int)m_PlayerSessionElapsedTime);
					num4 = m_PlayerSessionBackgroundTime;
					text = "udp.player_session_background_time";
					goto IL_0318;
				}
			}
			else
			{
				if (sessionState2 != SessionState.kSessionStarted)
				{
					return;
				}
				ulong currentMillisecondsInUTC2 = PlatformWrapper.GetCurrentMillisecondsInUTC();
				m_PlayerSessionState = SessionState.kSessionStarted;
				num = currentMillisecondsInUTC2;
			}
			string playerPrefsString = PlatformWrapper.GetPlayerPrefsString("udp.player_sessionId");
			m_PlayerSessionId = playerPrefsString;
			int num5 = PlayerPrefs.GetInt("udp.player_session_elapsed_time", 0);
			m_PlayerSessionElapsedTime = (ulong)num5;
			int num6 = PlayerPrefs.GetInt("udp.player_session_background_time", 0);
			m_PlayerSessionBackgroundTime = (ulong)num6;
			goto IL_02df;
			IL_0260:
			ulong sessionElapsedTime;
			AnalyticsClient.OnPlayerSessionStateChanged(m_PlayerSessionState, m_PlayerSessionId, sessionElapsedTime);
			return;
			IL_032d:
			PlayerPrefs.SetInt(key, value);
			sessionElapsedTime = 0uL;
			goto IL_0260;
			IL_0318:
			value = (int)num4;
			key = text;
			goto IL_032d;
			IL_02df:
			m_PlayerSessionForegroundTime = num;
			if (!(m_PlayerSessionId == ""))
			{
				int num7 = (int)(num - m_PlayerSessionBackgroundTime);
				bool flag2 = num7 < 1800000;
				bool flag3 = !flag2;
				int num8 = num7 - 1800000;
				bool flag4 = num8 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					bool flag6 = m_PlayerSessionElapsedTime == 0;
					bool flag7 = !flag6;
					sessionElapsedTime = 0uL;
					if (flag7)
					{
						goto IL_0260;
					}
				}
			}
			m_PlayerSessionElapsedTime = 0uL;
			string playerSessionId = PlatformWrapper.GenerateRandomId();
			m_PlayerSessionId = playerSessionId;
			PlayerPrefs.SetString("udp.player_sessionId", m_PlayerSessionId);
			num4 = m_PlayerSessionElapsedTime;
			text = "udp.player_session_elapsed_time";
			goto IL_0318;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x15C5BE8", Offset = "0x15C5BE8", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EE8050]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029990]) = v35;\nL_0016:\n\tv41 = v39.m_PlayerSessionState | 2;\n\tv51 = v41 != 3;\n\tif (v51) goto L_0039;\n\tv52 = UnityEngine.UDP.Analytics.PlatformWrapper::GetCurrentMillisecondsInUTC();\n\tv56 = v55.m_PlayerSessionElapsedTime;\n\tv58 = v52 - *([v56 @ X8_v8 (System.UInt64)+18]);\n\tv68 = *([v56 @ X8_v8 (System.UInt64)+18]) != 0;\n\tif (v68) goto L_FFFFFFFF;\n\tgoto L_0037;\nL_0037:\n\treturnVal1 = v56 + v82;\n\tgoto L_003E;\nL_0039:\n\treturnVal1 = v39.m_PlayerSessionElapsedTime;\nL_003E:\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ulong GetPlayerSessionElapsedTime()
		{
			//IL_002c: Expected I4, but got I8
			int num = (int)(m_PlayerSessionState | SessionState.kSessionPaused);
			if (num == 3)
			{
				ulong currentMillisecondsInUTC = PlatformWrapper.GetCurrentMillisecondsInUTC();
				ulong playerSessionElapsedTime = m_PlayerSessionElapsedTime;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v8 (System.UInt64)+18]");
				int num2 = (int)(currentMillisecondsInUTC - 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X8_v8 (System.UInt64)+18]");
				int num3 = (((IntPtr)0 != (IntPtr)0) ? num2 : 0);
				return playerSessionElapsedTime + (ulong)num3;
			}
			return m_PlayerSessionElapsedTime;
		}
	}
}
