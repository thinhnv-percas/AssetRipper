using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.Unity.Settings;
using Firebase;
using GameAnalyticsSDK;
using LunarConsolePluginInternal;
using Morpeh.Globals;
using Morpeh.Hypercasual.Code.Utils;
using Mycom.Tracker.Unity;
using Sirenix.Utilities;
using UnityEngine;
using com.adjust.sdk;

namespace Morpeh.Hypercasual
{
	[CreateAssetMenu]
	[Token(Token = "0x2000005")]
	public class AnalyticsSystem : LateUpdateSystem
	{
		[Token(Token = "0x4000010")]
		private static bool isInitialized;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x28")]
		public GlobalEventString evnt;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x30")]
		public GameObject appMetrica;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x38")]
		public GameObject gameAnalytics;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x40")]
		public GameObject adjust;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x48")]
		public GameObject appsFlyer;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary<string, object> tempDictionary0;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x58")]
		private Dictionary<string, object> tempDictionary1;

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1632474", Offset = "0x1632474", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1EE5848]);\n\tv33 = *([v32 @ X8_v70]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202A4D3]) = v52;\nL_0020:\n\tgoto L_0029;\n\tv59 = *([v55 @ X0_v2 (Il2CppClass<Morpeh.Hypercasual.AnalyticsSystem>)+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0029;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv63 = Morpeh.Hypercasual.AnalyticsSystem;\nL_0029:\n\tv68 = ~v66.isInitialized;\n\tif (v68) goto L_003B;\n\treturn;\nL_003B:\n\tgoto L_0044;\n\tv133 = *([v62 @ X0_v3 (Il2CppClass<Morpeh.Hypercasual.AnalyticsSystem>)+E0]);\n\tv134 = v133 == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_0044;\n\tv138 = \"il2cpp_codegen_runtime_class_init\"(v62, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv148 = Morpeh.Hypercasual.AnalyticsSystem;\n\tv141 = *([v148 @ X8_v65+B8]);\nL_0044:\n\tv140.isInitialized = 1;\n\tv146 = Sirenix.Utilities.GlobalConfig`1<Morpeh.Hypercasual.Code.Utils.KeysConfig>::get_Instance();\n\tv154 = v146.Analytics.AppMetrica;\n\tv155 = v146.Analytics.MyTracker;\n\tgoto L_005E;\n\tv203 = *([v156 @ X0_v12+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_005E;\n\tv207 = \"il2cpp_codegen_runtime_class_init\"(v156, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_005E:\n\tv181 = Firebase.FirebaseApp::get_DefaultInstance();\n\tv225 = Firebase.FirebaseApp::get_Options(v181);\n\tgoto L_0078;\n\tv230 = *([v222 @ X8_v15+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\t// 110 ConditionalJump @b23, v232 @ TEMP_v50\n\tv235 = v222;\n\tv233 = \"il2cpp_codegen_runtime_class_init\"(v235, v211, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0078:\n\tLunarConsolePluginInternal.CVarExtension::Set(v239.FirebaseAppID, v225.<AppId>k__BackingField);\n\tLunarConsolePluginInternal.CVarExtension::Set(v244.FirebaseAppKey, v225.<ApiKey>k__BackingField);\n\tgoto L_008F;\n\tv253 = *([v250 @ X0_v20+E0]);\n\tv254 = v253 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_008F;\n\tv257 = \"il2cpp_codegen_runtime_class_init\"(v250, v242, v243, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_008F:\n\tv260 = Facebook.Unity.Settings.FacebookSettings::get_AppId();\n\tLunarConsolePluginInternal.CVarExtension::Set(v249.FacebookAppId, v260);\n\tv183 = UnityEngine.GameObject::GetComponent(this.appMetrica);\n\tv183.ApiKeyAndroid = v154.Android;\n\tv183.ApiKeyIOS = v154.iOS;\n\tLunarConsolePluginInternal.CVarExtension::Set(v268.AppMetricaAndroid, v154.Android);\n\tLunarConsolePluginInternal.CVarExtension::Set(v198.AppMetricaiOS, v154.iOS);\n\tMorpeh.Hypercasual.AnalyticsSystem::<OnAwake>g__CreateGO|6_0(this.appMetrica);\n\tv185 = UnityEngine.GameObject::GetComponent(this.adjust);\n\tv185.appToken = v146.Analytics.Adjust;\n\tLunarConsolePluginInternal.CVarExtension::Set(v276.Adjust, v146.Analytics.Adjust);\n\tMorpeh.Hypercasual.AnalyticsSystem::<OnAwake>g__CreateGO|6_0(this.adjust);\n\tMorpeh.Hypercasual.AnalyticsSystem::<OnAwake>g__CreateGO|6_0(this.gameAnalytics);\n\tGameAnalyticsSDK.GameAnalytics::Initialize();\n\tgoto L_00D5;\n\tv287 = *([v283 @ X0_v36+E0]);\n\tv288 = v287 == 0;\n\tv289 = ~v288;\n\tif (v289) goto L_00D5;\n\tv291 = \"il2cpp_codegen_runtime_class_init\"(v283, v275, v163, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00D5:\n\tv186 = Tenjin::getInstance(v146.Analytics);\n\tv296 = BaseTenjin::Connect(v186);\n\tLunarConsolePluginInternal.CVarExtension::Set(v300.Tenjin, v146.Analytics);\n\tMorpeh.Hypercasual.AnalyticsSystem::<OnAwake>g__CreateGO|6_0(this.appsFlyer);\n\tgoto L_00F2;\n\tv309 = *([v305 @ X0_v43+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_00F2;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v305, v298, v299, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00F2:\n\tAppsFlyer::setAppsFlyerKey(v146.Analytics.AppsFlyer);\n\tAppsFlyer::init(v146.Analytics.AppsFlyer, \"AppsFlyerTrackerCallbacks\");\n\tv324 = v146 + 0x50;\n\tv327 = 0xDC3560(v324, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tLunarConsolePluginInternal.CVarExtension::Set(v326.AppsFlyerAppID, v327);\n\tLunarConsolePluginInternal.CVarExtension::Set(v223.AppsFlyerDevKey, v146.Analytics.AppsFlyer);\n\tLunarConsolePluginInternal.CVarExtension::Set(v335.MyTrackeriOS, v155.iOS);\n\tLunarConsolePluginInternal.CVarExtension::Set(v339.MyTrackerAndroid, v155.Android);\n\tgoto L_0126;\n\tv348 = *([v344 @ X0_v53+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_0126;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v344, v338, v85, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0126:\n\tMycom.Tracker.Unity.MyTracker::Create(v155.Android);\n\tMycom.Tracker.Unity.MyTracker::Init();\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAwake()
		{
			//IL_0207: Expected O, but got I
			if (!isInitialized)
			{
				isInitialized = true;
				KeysConfig instance = GlobalConfig<KeysConfig>.Instance;
				KeysConfig.PlatformPair platformPair = instance.Analytics.AppMetrica;
				KeysConfig.PlatformPair myTracker = instance.Analytics.MyTracker;
				FirebaseApp defaultInstance = FirebaseApp.DefaultInstance;
				AppOptions options = defaultInstance.Options;
				AnalyticsVariables.FirebaseAppID.Set(options.AppId);
				AnalyticsVariables.FirebaseAppKey.Set(options.ApiKey);
				string appId = FacebookSettings.AppId;
				AnalyticsVariables.FacebookAppId.Set(appId);
				AppMetrica component = appMetrica.GetComponent<AppMetrica>();
				component.ApiKeyAndroid = platformPair.Android;
				component.ApiKeyIOS = platformPair.iOS;
				AnalyticsVariables.AppMetricaAndroid.Set(platformPair.Android);
				AnalyticsVariables.AppMetricaiOS.Set(platformPair.iOS);
				CreateGO(appMetrica);
				Adjust component2 = adjust.GetComponent<Adjust>();
				component2.appToken = instance.Analytics.Adjust;
				AnalyticsVariables.Adjust.Set(instance.Analytics.Adjust);
				CreateGO(adjust);
				CreateGO(gameAnalytics);
				GameAnalytics.Initialize();
				BaseTenjin instance2 = Tenjin.getInstance((string)instance.Analytics);
				instance2.Connect();
				AnalyticsVariables.Tenjin.Set((string)instance.Analytics);
				CreateGO(appsFlyer);
				AppsFlyer.setAppsFlyerKey(instance.Analytics.AppsFlyer);
				AppsFlyer.init(instance.Analytics.AppsFlyer, "AppsFlyerTrackerCallbacks");
				object obj = (long)(IntPtr)instance + 80L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				string value = default(string);
				AnalyticsVariables.AppsFlyerAppID.Set(value);
				AnalyticsVariables.AppsFlyerDevKey.Set(instance.Analytics.AppsFlyer);
				AnalyticsVariables.MyTrackeriOS.Set(myTracker.iOS);
				AnalyticsVariables.MyTrackerAndroid.Set(myTracker.Android);
				MyTracker.Create(myTracker.Android);
				MyTracker.Init();
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x1632848", Offset = "0x1632848", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFF890]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A4D6]) = v38;\nL_0019:\n\tgoto L_0023;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0023;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::Instantiate(prefab);\n\tv61 = UnityEngine.Object::get_name(v56);\n\tv76 = System.String::Replace(v61, \"(Clone)\", v72.Empty);\n\tUnityEngine.Object::set_name(v56, v76);\n\tUnityEngine.Object::DontDestroyOnLoad(v56);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void CreateGO(GameObject prefab)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(prefab);
				string text = gameObject.name;
				string text2 = text.Replace("(Clone)", string.Empty);
				gameObject.name = text2;
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
			}
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x1632918", Offset = "0x1632918", Length = "0x4C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1ECD1A0]);\n\tv35 = *([v34 @ X8_v77]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, deltaTime, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A4D4]) = v54;\nL_0024:\n\tv63 = Morpeh.Globals.BaseGlobalEvent`1<System.String>::get_IsPublished(this.evnt);\n\tv153 = v63 == 0;\n\tif (v153) goto L_0196;\n\tv141 = Morpeh.Globals.BaseGlobalEvent`1<System.String>::get_BatchedChanges(this.evnt);\n\tv438 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v141);\nL_0041:\n\t;\n\tv520 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(&v437 @ stack_-98_v13 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>), *([v279 @ X24_v16 (Il2CppMethodInfo)]), \"\\\"\");\n\tv557 = v520 & 1;\n\tv291 = v557 == 0;\n\tif (v291) goto L_0139;\n\tv425 = \"SzArrayNew\"(*([v276 @ X26_v16 (Il2CppClass<System.Char[]>)]), 1, \"\\\"\", v768, v40, v41, v42, v43, v437, v45, v46, v47, v48, v49, v50, v51);\n\tv471 = v425.Length == 0;\n\tif (v471) goto L_014A;\n\tv425[0] = v269;\n\tv590 = System.String::Split(v479, v425);\n\tv859 = v590.Length;\n\tv751 = v590.Length - 1;\n\tv752 = v751 & 0x80000000;\n\tv753 = v752 == 0;\n\tv754 = ~v753;\n\tif (v754) goto L_00C7;\n\tv131 = v590.Length - 2;\n\tgoto L_0069;\nL_0066:\n\tv859 = v590.Length;\n\tv129 = v129 - 1;\n\tv131 = v131 - 1;\nL_0069:\n\tv116 = v859 - 1;\n\tv74 = v129 != v116;\n\tif (v74) goto L_008F;\n\tv822 = v859 == 0;\n\tif (v822) goto L_013B;\n\tv836 = 1;\n\t// 129 Box v839 @ X0_v89 (System.Object), typeof(System.Int32), &v836 @ X8_v72 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this.tempDictionary0, v590[v116 @ X9_v22], v839);\n\tgoto L_00BB;\nL_008F:\n\tv826 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v826);\n\tthis.tempDictionary1 = v826;\n\tv158 = v129 < 1;\n\tif (v158) goto L_00BB;\n\tv859 = v590.Length;\n\tv872 = v129 < v590.Length;\n\tv174 = ~v872;\n\tif (v174) goto L_0142;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v826, v590[v129 @ X26_v20], this.tempDictionary0);\n\tthis.tempDictionary0 = this.tempDictionary1;\nL_00BB:\n\tv880 = v131 & 0x80000000;\n\tv781 = v880 == 0;\n\tif (v781) goto L_0066;\nL_00C7:\n\tgoto L_00CE;\n\tv810 = *([v786 @ X0_v56+E0]);\n\tv811 = v810 == 0;\n\tv812 = ~v811;\n\tif (v812) goto L_00CE;\n\tv814 = \"il2cpp_codegen_runtime_class_init\"(v786, v643, v631, v622, v40, v41, v42, v43, v125, v45, v46, v47, v48, v49, v50, v51);\nL_00CE:\n\tv645 = AppMetrica::get_Instance();\n\tv859 = v590.Length;\n\tv647 = v590.Length == 0;\n\tif (v647) goto L_0152;\n\tv859 = *([v645 @ X0_v59 (IYandexAppMetrica)]);\n\tv864 = *([v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+126]) == 0;\n\tif (v864) goto L_00FB;\n\tv912 = *([v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+B0]) + 8;\nL_00E1:\n\t;\n\tv927 = *([v912 @ X11_v18-8]) == IYandexAppMetrica;\n\tif (v927) goto L_00FD;\n\tv913 = v913 + 1;\n\tv935 = v913 < *([v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+126]);\n\tv907 = ~v935;\n\tv912 = v912 + 0x10;\n\tv891 = ~v907;\n\tif (v891) goto L_00E1;\nL_00FB:\n\tv942 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v645, IYandexAppMetrica, 7);\n\tgoto L_0102;\nL_00FD:\n\t;\n\tv937 = *([v912 @ X11_v18]) + 7;\n\tv938 = v937 << 4;\n\tv859 = v859 + v938;\n\tv942 = v859 + 0x130;\nL_0102:\n\tv859 = *([v942 @ X0_v60]);\n\t*([v942 @ X0_v60])(v945, v645, v590[0], this.tempDictionary0, *([v942 @ X0_v60+8]), v40, v41, v42, v43, v437, v45, v46, v47, v48, v49, v50, v51);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Clear(this.tempDictionary0);\n\tv747 = this.tempDictionary1 == 0;\n\tif (v747) goto L_0159;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Clear(this.tempDictionary1);\n\tv955 = System.String::Replace(v479, \">\", \" > \");\n\tv962 = System.String::Concat(\"[Analytics]: Sended \\\"\", v955, \"\\\"\");\n\tgoto L_0133;\n\tv969 = *([v965 @ X0_v69+E0]);\n\tv970 = v969 == 0;\n\tv971 = ~v970;\n\tif (v971) goto L_0133;\n\tv973 = \"il2cpp_codegen_runtime_class_init\"(v965, v956, v503, v498, v40, v41, v42, v43, v125, v45, v46, v47, v48, v49, v50, v51);\nL_0133:\n\tUnityEngine.Debug::Log(v962);\n\tgoto L_0041;\nL_0139:\n\tv288 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v437 @ stack_-98_v13 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tgoto L_0196;\nL_013B:\n\tv840 = new System.IndexOutOfRangeException();\n\tthrow v840;\n\tv139 = new System.NullReferenceException();\n\tv151 = new System.NullReferenceException();\nL_0142:\n\tv205 = new System.IndexOutOfRangeException();\n\tthrow v205;\n\tthrow System.NullReferenceException;\n\tv432 = new System.NullReferenceException();\nL_014A:\n\tv474 = new System.IndexOutOfRangeException();\n\tthrow v474;\n\tthrow System.NullReferenceException;\n\tv596 = new System.NullReferenceException();\nL_0152:\n\tv651 = new System.IndexOutOfRangeException();\n\tthrow v651;\n\tv690 = new System.NullReferenceException();\n\tv730 = new System.NullReferenceException();\nL_0159:\n\tv749 = new System.NullReferenceException();\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\n\tgoto L_017C;\nL_017C:\n\tv213 = Il2CppMethodInfo != 1;\n\tif (v213) goto L_0197;\n\tv790 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v749, Il2CppMethodInfo, v749);\n\tv818 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v790, Il2CppMethodInfo, v749);\n\tv287 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v264 @ stack_-80_v3 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv843 = *([v790 @ X0_v10]) == 0;\n\tv290 = ~v843;\n\tif (v290) goto L_019B;\nL_0196:\n\treturn;\nL_0197:\n\tv791 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v749, Il2CppMethodInfo, v749);\nL_019B:\n\tthrow System.TypeLoadException;\n// 259 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnUpdate(float deltaTime)
		{
			//IL_0069: Expected I, but got O
			//IL_05d0: Expected O, but got I
			//IL_00eb: Expected O, but got I4
			//IL_00fe: Expected I4, but got I8
			//IL_0136: Expected O, but got I4
			//IL_052b: Expected O, but got I
			//IL_02aa: Expected I, but got O
			//IL_0365: Expected O, but got I4
			//IL_05ad: Expected I, but got O
			//IL_02e8: Expected O, but got I
			//IL_055d: Expected I4, but got I8
			//IL_015c: Expected O, but got I
			//IL_016b: Expected O, but got I
			//IL_0374: Unknown result type (might be due to invalid IL or missing references)
			//IL_0379: Expected O, but got Unknown
			//IL_03a5: Expected O, but got I
			//IL_0334: Expected O, but got I
			//IL_0511: Expected O, but got I
			//IL_04bc: Expected O, but got I
			//IL_04cb: Expected O, but got I
			//IL_042d: Expected I, but got O
			if (!evnt.IsPublished)
			{
				return;
			}
			List<string> batchedChanges = evnt.BatchedChanges;
			List<string>.Enumerator enumerator = batchedChanges.GetEnumerator();
			int num = 62;
			IntPtr intPtr = (IntPtr)typeof(char[]);
			IntPtr intPtr2 = (IntPtr)0;
			List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
			object obj = default(object);
			char[] array = default(char[]);
			string text = default(string);
			object obj8 = default(object);
			List<string>.Enumerator enumerator3;
			while (true)
			{
				((Dictionary<string, object>)enumerator2).Add((string)(long)intPtr2, (object)"\"");
				IYandexAppMetrica instance;
				IntPtr intPtr3;
				IntPtr intPtr4;
				if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"SzArrayNew\"");
					if (array.Length != 0)
					{
						array[0] = (char)num;
						string[] array2 = text.Split(array);
						intPtr3 = (IntPtr)array2.Length;
						object obj2 = array2.Length - 1;
						if ((int)((long)(IntPtr)obj2 & 0x80000000L) == 0)
						{
							object obj3 = array2.Length - 2;
							object obj4 = obj2;
							while (true)
							{
								object obj5 = (long)intPtr3 - 1L;
								if (obj4 == obj5)
								{
									if (intPtr3 == (IntPtr)0)
									{
										IndexOutOfRangeException ex = new IndexOutOfRangeException();
										throw ex;
									}
									int num2 = 1;
									object value = num2;
									tempDictionary0.Add(array2[obj5], value);
									intPtr4 = (IntPtr)0;
								}
								else
								{
									Dictionary<string, object> dictionary = (tempDictionary1 = new Dictionary<string, object>());
									if ((long)(IntPtr)obj4 >= 1L)
									{
										intPtr3 = (IntPtr)array2.Length;
										if ((long)(IntPtr)obj4 >= (long)array2.Length)
										{
											IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
											throw ex2;
										}
										dictionary.Add(array2[obj4], tempDictionary0);
										tempDictionary0 = tempDictionary1;
										intPtr4 = (IntPtr)0;
									}
								}
								if ((int)((long)(IntPtr)obj3 & 0x80000000L) == 0)
								{
									intPtr3 = (IntPtr)array2.Length;
									obj4 = (long)(IntPtr)obj4 - 1L;
									obj3 = (long)(IntPtr)obj3 - 1L;
									continue;
								}
								break;
							}
						}
						instance = AppMetrica.Instance;
						intPtr3 = (IntPtr)array2.Length;
						if (array2.Length != 0)
						{
							intPtr3 = (IntPtr)instance;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_034d;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+B0]");
							object obj6 = 0L + 8L;
							int num3 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v912 @ X11_v18-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IYandexAppMetrica))
								{
									break;
								}
								num3++;
								int num4 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v859 @ X8_v38 (Il2CppClass<IYandexAppMetrica>)+126]");
								bool flag = (long)num4 < 0L;
								bool flag2 = !flag;
								obj6 = (long)(IntPtr)obj6 + 16L;
								if (!flag2)
								{
									continue;
								}
								goto IL_034d;
							}
							object obj7 = obj6 + 7;
							int num5 = (int)((long)(IntPtr)obj7 << 4);
							intPtr3 = (IntPtr)(void*)((long)intPtr3 + (long)num5);
							obj8 = (long)intPtr3 + 304L;
							goto IL_05a5;
						}
						IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
						throw ex3;
					}
					IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
					throw ex4;
				}
				enumerator2.Dispose();
				return;
				IL_05a5:
				intPtr3 = (IntPtr)obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v942 @ X0_v60] (should have been resolved before IL gen)");
				tempDictionary0.Clear();
				bool flag3 = tempDictionary1 == null;
				enumerator3 = enumerator2;
				if (flag3)
				{
					break;
				}
				tempDictionary1.Clear();
				string text2 = text.Replace(">", " > ");
				string message = "[Analytics]: Sended \"" + text2 + "\"";
				Debug.Log(message);
				intPtr4 = (IntPtr)null;
				num = 62;
				continue;
				IL_034d:
				((Dictionary<string, object>)instance).Add((string)(object)typeof(IYandexAppMetrica), (object)7);
				goto IL_05a5;
			}
			NullReferenceException ex5 = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				((Dictionary<string, object>)(object)ex5).Add((string)0, (object)ex5);
				object obj9 = default(object);
				((Dictionary<string, object>)obj9).Add((string)0, (object)ex5);
				enumerator3.Dispose();
				if (obj9 == null)
				{
					return;
				}
			}
			else
			{
				((Dictionary<string, object>)(object)ex5).Add((string)0, (object)ex5);
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1632DDC", Offset = "0x1632DDC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F08AE8]);\n\tv23 = *([v22 @ X8_v4]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202A4D5]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tthis.tempDictionary0 = v46;\n\tv52 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v52);\n\tthis.tempDictionary1 = v52;\n\tMorpeh.LateUpdateSystem::.ctor(this);\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnalyticsSystem()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			tempDictionary0 = dictionary;
			Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
			tempDictionary1 = dictionary2;
		}
	}
}
