using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Setup;
using UnityEngine;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000019")]
	public class GA_SpecialEvents : MonoBehaviour
	{
		[Token(Token = "0x4000095")]
		private static int _frameCountAvg;

		[Token(Token = "0x4000096")]
		private static float _lastUpdateAvg;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x18")]
		private int _frameCountCrit;

		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x1C")]
		private float _lastUpdateCrit;

		[Token(Token = "0x4000099")]
		private static int _criticalFpsCount;

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x15A1DF4", Offset = "0x15A1DF4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = GameAnalyticsSDK.Events.GA_SpecialEvents::SubmitFPSRoutine(this);\n\tv15 = UnityEngine.MonoBehaviour::StartCoroutine(this, v10);\n\tv17 = GameAnalyticsSDK.Events.GA_SpecialEvents::CheckCriticalFPSRoutine(this);\n\tv24 = UnityEngine.MonoBehaviour::StartCoroutine(this, v17);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			IEnumerator routine = SubmitFPSRoutine();
			Coroutine coroutine = StartCoroutine(routine);
			IEnumerator routine2 = CheckCriticalFPSRoutine();
			Coroutine coroutine2 = StartCoroutine(routine2);
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73C5CC", Offset = "0x73C5CC")]
		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x15A1E38", Offset = "0x15A1E38", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EDEF80]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20297E0]) = v35;\nL_0014:\n\tv39 = new GameAnalyticsSDK.Events.GA_SpecialEvents+<SubmitFPSRoutine>d__6();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator SubmitFPSRoutine()
		{
			while (Application.isPlaying)
			{
				Settings settingsGA = GameAnalytics.SettingsGA;
				if (settingsGA != null)
				{
					Settings settingsGA2 = GameAnalytics.SettingsGA;
					if (settingsGA2.SubmitFpsAverage)
					{
						yield return new WaitForSeconds(30f);
						SubmitFPS();
						continue;
					}
					break;
				}
				break;
			}
		}

		[Attribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x73C630", Offset = "0x73C630")]
		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x15A1E98", Offset = "0x15A1E98", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EE0690]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297E1]) = v38;\nL_0016:\n\tv42 = new GameAnalyticsSDK.Events.GA_SpecialEvents+<CheckCriticalFPSRoutine>d__7();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator CheckCriticalFPSRoutine()
		{
			_003CCheckCriticalFPSRoutine_003Ed__7 _003CCheckCriticalFPSRoutine_003Ed__8 = null;
			_003CCheckCriticalFPSRoutine_003Ed__8._003C_003E1__state = 0;
			_003CCheckCriticalFPSRoutine_003Ed__8._003C_003E4__this = this;
			return _003CCheckCriticalFPSRoutine_003Ed__8;
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0x15A1F64", Offset = "0x15A1F64", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC3320]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20297E2]) = v40;\nL_0014:\n\tv41 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tgoto L_0026;\n\tv49 = *([v45 @ X8_v3+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv60 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v41, 0);\n\tv62 = v59 == 0;\n\tif (v62) goto L_0041;\n\tv63 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv70 = ~v63.SubmitFpsAverage;\n\tif (v70) goto L_0041;\n\tgoto L_003F;\n\tv112 = *([v105 @ X0_v18 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_003F;\n\tv140 = \"il2cpp_codegen_runtime_class_init\"(v105, v57, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv115 = GameAnalyticsSDK.Events.GA_SpecialEvents;\nL_003F:\n\tv65 = v72._frameCountAvg + 1;\n\tv72._frameCountAvg = v65;\nL_0041:\n\tv76 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tgoto L_0051;\n\tv96 = *([v78 @ X8_v5+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_0051;\n\tv109 = v78;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v109, v57, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0051:\n\tv103 = UnityEngine.Object::op_Inequality(v76, 0);\n\tv111 = v103 == 0;\n\tif (v111) goto L_0064;\n\tv90 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv137 = ~v90.SubmitFpsCritical;\n\tif (v137) goto L_0064;\n\tv138 = v38._frameCountCrit + 1;\n\tv38._frameCountCrit = v138;\nL_0064:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update()
		{
			//IL_0056: Expected I4, but got O
			//IL_0121: Expected I4, but got O
			Settings settingsGA = GameAnalytics.SettingsGA;
			if (settingsGA != null)
			{
				Settings settingsGA2 = GameAnalytics.SettingsGA;
				bool flag = !settingsGA2.SubmitFpsAverage;
				bool flag2 = (byte)(int)settingsGA2 != 0;
				if (!flag)
				{
					int frameCountAvg = _frameCountAvg + 1;
					_frameCountAvg = frameCountAvg;
					flag2 = (byte)(int)typeof(GA_SpecialEvents) != 0;
				}
			}
			Settings settingsGA3 = GameAnalytics.SettingsGA;
			if (settingsGA3 != null)
			{
				Settings settingsGA4 = GameAnalytics.SettingsGA;
				if (settingsGA4.SubmitFpsCritical)
				{
					int frameCountCrit = _frameCountCrit + 1;
					_frameCountCrit = frameCountCrit;
				}
			}
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x15A2088", Offset = "0x15A2088", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED73F0]);\n\tv19 = *([v18 @ X8_v37]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20297E3]) = v39;\nL_0013:\n\tv40 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tgoto L_0025;\n\tv48 = *([v44 @ X8_v3+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv59 = v44;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v59, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(v40, 0);\n\tv61 = v58 == 0;\n\tif (v61) goto L_0079;\n\tv62 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv114 = ~v62.SubmitFpsAverage;\n\tif (v114) goto L_0079;\n\tv163 = UnityEngine.Time::get_unscaledTime();\n\tgoto L_0041;\n\tv234 = *([v169 @ X0_v26 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv235 = v234 == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_0041;\n\tv243 = \"il2cpp_codegen_runtime_class_init\"(v169, v56, v57, v23, v24, v25, v26, v27, v163, v29, v30, v31, v32, v33, v34, v35);\n\tv237 = GameAnalyticsSDK.Events.GA_SpecialEvents;\nL_0041:\n\tv101 = v163 - v120._lastUpdateAvg;\n\tv66 = v101 <= 1f;\n\tif (v66) goto L_0079;\n\tgoto L_005E;\n\tv247 = *([v111 @ X0_v27 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv248 = v247 == 0;\n\tv249 = ~v248;\n\tif (v249) goto L_005E;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v111, v56, v57, v23, v24, v25, v26, v27, v105, v29, v30, v31, v32, v33, v34, v35);\n\tv275 = GameAnalyticsSDK.Events.GA_SpecialEvents;\n\tv253 = *([v275 @ X8_v32+B8]);\nL_005E:\n\tv100 = v252._frameCountAvg / v101;\n\tv104 = UnityEngine.Time::get_unscaledTime();\n\tv263._lastUpdateAvg = v104;\n\tv119._frameCountAvg = 0;\n\tv64 = v100 <= 0;\n\tif (v64) goto L_0079;\n\tGameAnalyticsSDK.GameAnalytics::NewDesignEvent(\"GA:AverageFPS\", v100);\nL_0079:\n\tv123 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tgoto L_0089;\n\tv154 = *([v125 @ X8_v6+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0089;\n\tv164 = v125;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v164, v56, v57, v23, v24, v25, v26, v27, v102, v29, v30, v31, v32, v33, v34, v35);\nL_0089:\n\tv161 = UnityEngine.Object::op_Inequality(v123, 0);\n\tv166 = v161 == 0;\n\tif (v166) goto L_00C8;\n\tv148 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv227 = ~v148.SubmitFpsCritical;\n\tif (v227) goto L_00C8;\n\tgoto L_00AC;\n\tv267 = *([v257 @ X0_v15 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_00AC;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v257, v144, v142, v23, v24, v25, v26, v27, v102, v29, v30, v31, v32, v33, v34, v35);\n\tv270 = GameAnalyticsSDK.Events.GA_SpecialEvents;\nL_00AC:\n\tv213 = v272._criticalFpsCount < 1;\n\tif (v213) goto L_00C8;\n\tgoto L_00BE;\n\tv282 = *([v225 @ X0_v16 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\tif (v284) goto L_00BE;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v225, v144, v142, v23, v24, v25, v26, v27, v102, v29, v30, v31, v32, v33, v34, v35);\n\tv292 = GameAnalyticsSDK.Events.GA_SpecialEvents;\n\tv293 = *([v292 @ X8_v16+B8]);\n\tv289 = *([v293 @ X8_v17+8]);\nL_00BE:\n\tGameAnalyticsSDK.GameAnalytics::NewDesignEvent(\"GA:CriticalFPS\", v272._criticalFpsCount);\n\tv229._criticalFpsCount = 0;\nL_00C8:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SubmitFPS()
		{
			//IL_0056: Expected I4, but got O
			//IL_0142: Expected I4, but got O
			//IL_01d5: Expected F4, but got I4
			//IL_008e: Expected I4, but got O
			Settings settingsGA = GameAnalytics.SettingsGA;
			if (settingsGA != null)
			{
				Settings settingsGA2 = GameAnalytics.SettingsGA;
				bool flag = !settingsGA2.SubmitFpsAverage;
				bool flag2 = (byte)(int)settingsGA2 != 0;
				if (!flag)
				{
					float unscaledTime = Time.unscaledTime;
					float num = unscaledTime - _lastUpdateAvg;
					bool flag3 = !(num > 1f);
					flag2 = (byte)(int)typeof(GA_SpecialEvents) != 0;
					if (!flag3)
					{
						float num2 = (float)_frameCountAvg / num;
						float unscaledTime2 = Time.unscaledTime;
						_lastUpdateAvg = unscaledTime2;
						_frameCountAvg = 0;
						bool flag4 = !(num2 > 0f);
						flag2 = false;
						if (!flag4)
						{
							GameAnalytics.NewDesignEvent("GA:AverageFPS", num2);
							flag2 = (byte)(int)"GA:AverageFPS" != 0;
						}
					}
				}
			}
			Settings settingsGA3 = GameAnalytics.SettingsGA;
			if (settingsGA3 != null)
			{
				Settings settingsGA4 = GameAnalytics.SettingsGA;
				if (settingsGA4.SubmitFpsCritical && _criticalFpsCount >= 1)
				{
					GameAnalytics.NewDesignEvent("GA:CriticalFPS", _criticalFpsCount);
					_criticalFpsCount = 0;
				}
			}
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x15A233C", Offset = "0x15A233C", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE3C48]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20297E4]) = v40;\nL_0014:\n\tv41 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tgoto L_0026;\n\tv49 = *([v45 @ X8_v5+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0026;\n\tv60 = v45;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0026:\n\tv59 = UnityEngine.Object::op_Inequality(v41, 0);\n\tv62 = v59 == 0;\n\tif (v62) goto L_0070;\n\tv63 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv116 = ~v63.SubmitFpsCritical;\n\tif (v116) goto L_0070;\n\tv169 = UnityEngine.Time::get_unscaledTime();\n\tv101 = v169 - v38._lastUpdateCrit;\n\tv67 = v101 < 1f;\n\tif (v67) goto L_0070;\n\tv167 = UnityEngine.Time::get_unscaledTime();\n\tv38._lastUpdateCrit = v167;\n\tv38._frameCountCrit = 0;\n\tv113 = GameAnalyticsSDK.GameAnalytics::get_SettingsGA();\n\tv103 = v38._frameCountCrit / v101;\n\tv175 = v103 < v113.FpsCriticalThreshold;\n\tv97 = ~v175;\n\tv93 = v103 - v113.FpsCriticalThreshold;\n\tv85 = v93 == 0;\n\tv176 = ~v85;\n\tv65 = v97 & v176;\n\tif (v65) goto L_0070;\n\tgoto L_0068;\n\tv182 = *([v178 @ X0_v13 (Il2CppClass<GameAnalyticsSDK.Events.GA_SpecialEvents>)+E0]);\n\tv183 = v182 == 0;\n\tv184 = ~v183;\n\tif (v184) goto L_0068;\n\tv188 = \"il2cpp_codegen_runtime_class_init\"(v178, v57, v58, v25, v26, v27, v28, v29, v106, v103, v32, v33, v34, v35, v36, v37);\n\tv185 = GameAnalyticsSDK.Events.GA_SpecialEvents;\nL_0068:\n\tv109 = v121._criticalFpsCount + 1;\n\tv121._criticalFpsCount = v109;\nL_0070:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CheckCriticalFPS()
		{
			Settings settingsGA = GameAnalytics.SettingsGA;
			if (!(settingsGA != null))
			{
				return;
			}
			Settings settingsGA2 = GameAnalytics.SettingsGA;
			if (!settingsGA2.SubmitFpsCritical)
			{
				return;
			}
			float unscaledTime = Time.unscaledTime;
			float num = unscaledTime - _lastUpdateCrit;
			if (!(num < 1f))
			{
				float unscaledTime2 = Time.unscaledTime;
				_lastUpdateCrit = unscaledTime2;
				_frameCountCrit = 0;
				Settings settingsGA3 = GameAnalytics.SettingsGA;
				float num2 = (float)_frameCountCrit / num;
				bool flag = num2 < (float)settingsGA3.FpsCriticalThreshold;
				bool flag2 = !flag;
				float num3 = num2 - (float)settingsGA3.FpsCriticalThreshold;
				bool flag3 = num3 == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int criticalFpsCount = _criticalFpsCount + 1;
					_criticalFpsCount = criticalFpsCount;
				}
			}
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x15A245C", Offset = "0x15A245C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GA_SpecialEvents()
		{
		}
	}
}
