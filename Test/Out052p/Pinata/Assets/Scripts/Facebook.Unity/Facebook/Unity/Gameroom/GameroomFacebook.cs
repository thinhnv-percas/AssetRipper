using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Facebook.MiniJSON;

namespace Facebook.Unity.Gameroom
{
	[Token(Token = "0x200004D")]
	internal sealed class GameroomFacebook : FacebookBase, IGameroomFacebookImplementation, IPayFacebook, IFacebook, IFacebookResultHandler
	{
		[Token(Token = "0x200004E")]
		public delegate void OnComplete(ResultContainer resultContainer);

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x28")]
		private string appId;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x30")]
		private IGameroomWrapper gameroomWrapper;

		[CompilerGenerated]
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x38")]
		private bool _003CLimitEventUsage_003Ek__BackingField;

		[Token(Token = "0x17000066")]
		public override bool LimitEventUsage
		{
			[CompilerGenerated]
			[Token(Token = "0x60001AF")]
			[Address(RVA = "0xD2E768", Offset = "0xD2E768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<LimitEventUsage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LimitEventUsage;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B0")]
			[Address(RVA = "0xD2E770", Offset = "0xD2E770", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<LimitEventUsage>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CLimitEventUsage_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000067")]
		public override string SDKName
		{
			[Token(Token = "0x60001B1")]
			[Address(RVA = "0xD2E77C", Offset = "0xD2E77C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EADE50]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C33]) = v35;\nL_0018:\n\treturn \"FBGameroomSDK\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "FBGameroomSDK";
			}
		}

		[Token(Token = "0x17000068")]
		public override string SDKVersion
		{
			[Token(Token = "0x60001B2")]
			[Address(RVA = "0xD2E7C4", Offset = "0xD2E7C4", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB8790]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023C34]) = v35;\nL_0018:\n\treturn \"0.0.1\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "0.0.1";
			}
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0xD2E600", Offset = "0xD2E600", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EDB078]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023C32]) = v40;\nL_0014:\n\tv41 = Facebook.Unity.Gameroom.GameroomFacebook::GetGameroomWrapper();\n\tv47 = new Facebook.Unity.CallbackManager();\n\tFacebook.Unity.CallbackManager::.ctor(v47);\n\tSystem.Object::.ctor(v38);\n\tv38.<CallbackManager>k__BackingField = v47;\n\tv38.gameroomWrapper = v41;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameroomFacebook()
		{
			IGameroomWrapper gameroomWrapper = GetGameroomWrapper();
			CallbackManager callbackManager = new CallbackManager();
			CallbackManager = callbackManager;
			this.gameroomWrapper = gameroomWrapper;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xD2E72C", Offset = "0xD2E72C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<CallbackManager>k__BackingField = callbackManager;\n\tthis.gameroomWrapper = gameroomWrapper;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameroomFacebook(IGameroomWrapper gameroomWrapper, CallbackManager callbackManager)
		{
			CallbackManager = callbackManager;
			this.gameroomWrapper = gameroomWrapper;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0xD2B5CC", Offset = "0xD2B5CC", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF81E8]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appId, hideUnityDelegate, onInitComplete, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2023C35]) = v44;\nL_0017:\n\tthis.onInitCompleteDelegate = onInitComplete;\n\tthis.appId = appId;\n\tv46 = this.gameroomWrapper;\n\tv49 = new Facebook.Unity.Gameroom.GameroomFacebook+OnComplete();\n\tv52 = this->klass;\n\tv53 = this->klass->vtable[43];\n\tv49.m_target = this;\n\tv49.method = this->klass->vtable[43];\n\tv49.method_ptr = v53.m_value;\n\tv63 = *([v46 @ X19_v2 (Facebook.Unity.Gameroom.IGameroomWrapper)]);\n\tv67 = *([v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]) == 0;\n\tif (v67) goto L_004D;\n\tv172 = *([v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]) + 8;\nL_0038:\n\tv178 = *([v172 @ X11_v5-8]) == Facebook.Unity.Gameroom.IGameroomWrapper;\n\tif (v178) goto L_0050;\n\tv173 = v173 + 1;\n\tv183 = v173 < *([v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]);\n\tv99 = ~v183;\n\tv172 = v172 + 0x10;\n\tv75 = ~v99;\n\tif (v75) goto L_0038;\nL_004D:\n\tv190 = 0x8909C4(v46, Facebook.Unity.Gameroom.IGameroomWrapper, 2, onInitComplete, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0054;\nL_0050:\n\tv185 = *([v172 @ X11_v5]) + 2;\n\tv186 = v185 << 4;\n\tv187 = v63 + v186;\n\tv190 = v187 + 0x130;\nL_0054:\n\tv112 = *([v190 @ X0_v6]);\n\tv119 = *([v190 @ X0_v6+8]);\n\t// 95 IndirectJump v112 @ X3_v1, v46 @ X19_v2 (Facebook.Unity.Gameroom.IGameroomWrapper), v46 @ X19_v2 (Facebook.Unity.Gameroom.IGameroomWrapper), v49 @ X0_v3 (Facebook.Unity.Gameroom.GameroomFacebook+OnComplete), v119 @ X2_v2, v112 @ X3_v1, methodInfo @ X4 (Il2CppMethodInfo), v31 @ X5, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Init(string appId, HideUnityDelegate hideUnityDelegate, InitDelegate onInitComplete)
		{
			//IL_000a: Expected I, but got O
			//IL_0058: Expected I, but got O
			//IL_01b0: Expected O, but got I
			//IL_0093: Expected O, but got I
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_0132: Expected O, but got I
			//IL_0141: Expected O, but got I
			//IL_00df: Expected O, but got I
			onInitCompleteDelegate = onInitComplete;
			this.appId = appId;
			IGameroomWrapper gameroomWrapper = this.gameroomWrapper;
			OnComplete onComplete = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v6 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3E8]");
			IntPtr intPtr2 = (IntPtr)0;
			((Delegate)onComplete).m_target = this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v6 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3E8]");
			((Delegate)onComplete).method = (IntPtr)0;
			((Delegate)onComplete).method_ptr = (IntPtr)((IntPtr*)intPtr2)->m_value;
			IntPtr intPtr3 = (IntPtr)gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v172 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IGameroomWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f8;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr3 + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0198;
			IL_00f8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0198;
			IL_0198:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0xD2E81C", Offset = "0xD2E81C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECAC68]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, appId, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C36]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v42);\n\tv48 = this->klass;\n\tv53 = this->klass->vtable[41];\n\tv55 = this->klass->vtable[41];\n\t// 42 IndirectJump v53 @ X5_v1, this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook), this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook), \"fb_mobile_activate_app\", 0, v42 @ X0_v3 (System.Collections.Generic.Dictionary`2<System.String, System.Object>), v55 @ X4_v1, v53 @ X5_v1, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ActivateApp(string appId = null)
		{
			//IL_0014: Expected I, but got O
			//IL_0024: Expected O, but got I
			//IL_0034: Expected O, but got I
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v53 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0xD2E8A4", Offset = "0xD2E8A4", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv31 = *([1EC1A70]);\n\tv32 = *([v31 @ X8_v46]);\n\tv33 = \"il2cpp_codegen_initialize_method\"(v32, logEvent, valueToSum, parameters, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023C37]) = v48;\nL_001A:\n\tv49 = parameters == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0030;\n\tv54 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v54);\nL_0030:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"_eventName\", logEvent);\n\tv73 = valueToSum & 0xFF00000000;\n\tv74 = v73 == 0;\n\tif (v74) goto L_0049;\n\tv79 = 0x115CAB0(&valueToSum @ X2 (System.Nullable`1<System.Single>), Il2CppMethodInfo, logEvent, Il2CppMethodInfo, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\t// 62 Box v117 @ X0_v30 (System.Object), typeof(System.Single), &v38 @ V0\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v60, \"_valueToSum\", v117);\nL_0049:\n\tv96 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v96);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"event\", \"CUSTOM_APP_EVENTS\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"application_tracking_enabled\", \"0\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"advertiser_tracking_enabled\", \"0\");\n\tgoto L_0079;\n\tv180 = *([v176 @ X0_v13+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_0079;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v176, v173, v170, v171, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0079:\n\tv188 = Facebook.MiniJSON.Json+Serializer::Serialize(v60);\n\tv195 = System.String::Format(\"[{0}]\", v188);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::Add(v96, \"custom_events\", v195);\n\tv207 = System.String::Format(\"{0}/activities\", this.appId);\n\tgoto L_00A0;\n\tv214 = *([v145 @ X8_v32+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_00A0;\n\tv219 = v145;\n\tv218 = \"il2cpp_codegen_runtime_class_init\"(v219, v203, v205, v198, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00A0:\n\tFacebook.Unity.FB::API(v207, 1, 0, v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogEvent(string logEvent, float? valueToSum, Dictionary<string, object> parameters)
		{
			//IL_0040: Unknown result type (might be due to invalid IL or missing references)
			//IL_0045: Expected I4, but got Unknown
			//IL_0075: Expected F4, but got O
			bool flag = parameters == null;
			bool flag2 = !flag;
			Dictionary<string, object> dictionary = parameters;
			if (!flag2)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary = dictionary2;
			}
			dictionary.Add("_eventName", logEvent);
			if ((int)((_003F?)valueToSum & 0xFF00000000L) != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115CAB0 (inside System.Nullable`1<System.Int64>::Unbox +0xC0)");
				object obj = default(object);
				object value = (float)obj;
				dictionary.Add("_valueToSum", value);
			}
			Dictionary<string, string> dictionary3 = new Dictionary<string, string>();
			dictionary3.Add("event", "CUSTOM_APP_EVENTS");
			dictionary3.Add("application_tracking_enabled", "0");
			dictionary3.Add("advertiser_tracking_enabled", "0");
			string arg = Json.Serializer.Serialize(dictionary);
			string value2 = $"[{arg}]";
			dictionary3.Add("custom_events", value2);
			string query = $"{appId}/activities";
			FB.API(query, HttpMethod.POST, null, dictionary3);
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0xD2EAFC", Offset = "0xD2EAFC", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EF04D8]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, currency, parameters, methodInfo, v34, v35, v36, v37, logPurchase, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023C38]) = v47;\nL_0019:\n\tv48 = parameters == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_002F;\n\tv53 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v53);\nL_002F:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v59, \"currency\", currency);\n\tv75 = 0;\n\tv78 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(&v75 @ stack_-38_v1 (System.Nullable`1<System.Single>), Il2CppMethodInfo, currency);\n\tv88 = Facebook.Unity.Gameroom.GameroomFacebook::AppEventsLogEvent(this, \"fb_mobile_purchase\", 0, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppEventsLogPurchase(float logPurchase, string currency, Dictionary<string, object> parameters)
		{
			//IL_004c: Expected O, but got I
			bool flag = parameters == null;
			bool flag2 = !flag;
			Dictionary<string, object> dictionary = parameters;
			if (!flag2)
			{
				Dictionary<string, object> dictionary2 = new Dictionary<string, object>();
				dictionary = dictionary2;
			}
			dictionary.Add("currency", currency);
			((Dictionary<string, object>)(float?)null).Add((string)0, (object)currency);
			AppEventsLogEvent("fb_mobile_purchase", null, dictionary);
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0xD2EBF4", Offset = "0xD2EBF4", Length = "0x444")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_0025;\n\tv48 = *([1F0E330]);\n\tv49 = *([v48 @ X8_v50]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, message, actionType, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023C39]) = v61;\nL_0025:\n\tv65 = filters == 0;\n\tif (v65) goto L_FFFFFFFF;\n\tgoto L_0056;\n\tv73 = *([v67 @ X8_v32+B0]);\n\tv74 = 0;\n\tv75 = v73 + 8;\n\tv77 = *([v195 @ X11_v35-8]);\n\tv201 = v77 == v70;\n\tif (v201) goto L_004F;\n\tv110 = v196 + 1;\n\tv212 = v110 < v69;\n\tv104 = ~v212;\n\tv107 = v195 + 0x10;\n\tv80 = ~v104;\n\tif (v80) goto L_FFFFFFFF;\n\tv111 = v30;\n\tv112 = 0;\n\tv113 = 0x8909C4(v111, v70, v112, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_0056;\n\tgoto L_0113;\nL_004F:\n\tv213 = *([v195 @ X11_v35]);\n\tv214 = v213 << 4;\n\tv215 = v67 + v214;\n\tv216 = v215 + 0x130;\nL_0056:\n\tv237 = System.Collections.Generic.IEnumerable`1<System.Object>::GetEnumerator(filters);\n\tgoto L_0087;\n\tv301 = *([v248 @ X8_v35+B0]);\n\tv302 = 0;\n\tv303 = v301 + 8;\n\tv305 = *([v379 @ X11_v30-8]);\n\tv385 = v305 == v251;\n\tif (v385) goto L_0080;\n\tv327 = v380 + 1;\n\tv396 = v327 < v250;\n\tv323 = ~v396;\n\tv325 = v379 + 0x10;\n\tv307 = ~v323;\n\tif (v307) goto L_FFFFFFFF;\n\tv328 = v238;\n\tv329 = 0;\n\tv330 = 0x8909C4(v328, v251, v329, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_0087;\nL_0080:\n\tv397 = *([v379 @ X11_v30]);\n\tv398 = v397 << 4;\n\tv399 = v248 + v398;\n\tv400 = v399 + 0x130;\nL_0087:\n\tv421 = System.Collections.IEnumerator::MoveNext(v237);\n\tv423 = v421 == 0;\n\tif (v423) goto L_00D7;\n\tgoto L_00B8;\n\tv504 = *([v445 @ X8_v39+B0]);\n\tv505 = 0;\n\tv506 = v504 + 8;\n\tv508 = *([v636 @ X11_v25-8]);\n\tv642 = v508 == v448;\n\tif (v642) goto L_00B1;\n\tv530 = v637 + 1;\n\tv773 = v530 < v447;\n\tv526 = ~v773;\n\tv528 = v636 + 0x10;\n\tv510 = ~v526;\n\tif (v510) goto L_FFFFFFFF;\n\tv531 = v238;\n\tv532 = 0;\n\tv533 = 0x8909C4(v531, v448, v532, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_00B8;\nL_00B1:\n\tv774 = *([v636 @ X11_v25]);\n\tv775 = v774 << 4;\n\tv776 = v445 + v775;\n\tv777 = v776 + 0x130;\nL_00B8:\n\tv483 = System.Collections.Generic.IEnumerator`1<System.Object>::get_Current(v237);\n\tv485 = v483 == 0;\n\tif (v485) goto L_00D7;\n\tv540 = *([v483 @ X0_v54 (System.Int32)]) != System.String;\n\tif (v540) goto L_FFFFFFFF;\n\tgoto L_00D0;\nL_00D0:\n\tv873 = v237 == 0;\n\tv572 = ~v873;\n\tif (v572) goto L_00DF;\n\tgoto L_0107;\nL_00D7:\n\tv491 = v237 == 0;\n\tif (v491) goto L_0107;\nL_00DF:\n\tgoto L_0106;\n\tv647 = *([v585 @ X8_v28+B0]);\n\tv648 = 0;\n\tv649 = v647 + 8;\n\tv651 = *([v791 @ X11_v16-8]);\n\tv797 = v651 == v588;\n\tif (v797) goto L_00FF;\n\tv673 = v792 + 1;\n\tv812 = v673 < v587;\n\tv669 = ~v812;\n\tv671 = v791 + 0x10;\n\tv653 = ~v669;\n\tif (v653) goto L_FFFFFFFF;\n\tv674 = v577;\n\tv675 = 0;\n\tv676 = 0x8909C4(v674, v588, v675, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_0106;\nL_00FF:\n\tv813 = *([v791 @ X11_v16]);\n\tv814 = v813 << 4;\n\tv815 = v585 + v814;\n\tv816 = v815 + 0x130;\nL_0106:\n\tSystem.IDisposable::Dispose(v577);\nL_0107:\n\tv167 = v179 + 1;\n\tv146 = v167 == 0;\n\tv136 = ~v146;\n\tif (v136) goto L_0113;\n\tv677 = v129 == 0;\n\tv166 = ~v677;\n\tif (v166) goto L_01A1;\nL_0113:\n\tv183 = this.gameroomWrapper;\n\tv184 = v181 == 0;\n\tif (v184) goto L_FFFFFFFF;\n\tv210 = System.Nullable`1<Facebook.Unity.OGActionType>::ToString(&actionType @ X2 (System.Nullable`1<Facebook.Unity.OGActionType>));\n\tgoto L_011F;\nL_011F:\n\tv246 = Facebook.Unity.Utilities::ToCommaSeparateList(v170);\n\tv300 = Facebook.Unity.Utilities::ToCommaSeparateList(v174);\n\tv368 = v366 == 0;\n\tif (v368) goto L_013E;\n\tv394 = System.Nullable`1<System.Int32>::get_Value(&maxRecipients @ X7 (System.Nullable`1<System.Int32>));\n\tv237 = 0xDC3560(&v394 @ X0_v33 (System.Int32), 0, actionType, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_013E;\nL_013E:\n\tv502 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v24 @ X29_v1+20]));\n\tv237 = new Facebook.Unity.Gameroom.GameroomFacebook+OnComplete();\n\tv772 = this->klass;\n\tv624 = this->klass->vtable[46];\n\t*([v237 @ X0_v47 (System.Collections.IEnumerator)+20]) = this;\n\tthis->klass->vtable[46] = this->klass->vtable[46];\n\tthis->klass->vtable[46]->methodPtr = this->klass->vtable[46]->methodPtr;\n\tv803 = *([v183 @ X26_v6 (Facebook.Unity.Gameroom.IGameroomWrapper)]);\n\tv753 = *([v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]) == 0;\n\tif (v753) goto L_0174;\n\tv862 = *([v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]) + 8;\nL_015F:\n\tv868 = *([v862 @ X11_v9-8]) == Facebook.Unity.Gameroom.IGameroomWrapper;\n\tif (v868) goto L_0177;\n\tv863 = v863 + 1;\n\tv874 = v863 < *([v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]);\n\tv842 = ~v874;\n\tv862 = v862 + 0x10;\n\tv826 = ~v842;\n\tif (v826) goto L_015F;\nL_0174:\n\tv237 = 0x8909C4(v183, Facebook.Unity.Gameroom.IGameroomWrapper, 6, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_018B;\nL_0177:\n\tv876 = *([v862 @ X11_v9]) + 6;\n\tv877 = v876 << 4;\n\tv878 = v803 + v877;\n\tv237 = v878 + 0x130;\nL_018B:\n\t*([v237 @ X0_v47 (System.Collections.IEnumerator)])(v237, v183, this.appId, message, v244, objectId, v246, v168, v300, v51, v52, v53, v54, v55, v56, v57, v58);\n\treturn;\n\tthrow System.NullReferenceException;\n\tv282 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_01A1:\n\tv364 = new System.TypeLoadException();\n\tgoto L_01AD;\nL_01AD:\n\tgoto L_01B7;\n\tv237 = 0x6D2BC0(v364, 0, 0, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv541 = *([v237 @ X0_v47 (System.Collections.IEnumerator)]);\n\tv237 = 0x6D2490(v237, 0, 0, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv678 = v357 == 0;\n\tv571 = ~v678;\n\tif (v571) goto L_00DF;\n\tgoto L_0107;\nL_01B7:\n\tv237 = 0x6D2380(v364, 0, 0, objectId, to, filters, excludeIds, maxRecipients, v51, v52, v53, v54, v55, v56, v57, v58);\n\treturn;\n// 269 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void AppRequest(string message, OGActionType? actionType, string objectId, IEnumerable<string> to, IEnumerable<object> filters, IEnumerable<string> excludeIds, int? maxRecipients, string data, string title, FacebookDelegate<IAppRequestResult> callback)
		{
			//IL_01e1: Expected O, but got I
			//IL_01f4: Expected I, but got O
			//IL_0204: Expected O, but got I
			//IL_0225: Expected I, but got O
			//IL_044f: Expected I4, but got O
			//IL_0260: Expected O, but got I
			//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_02e2: Expected O, but got Unknown
			//IL_02ff: Expected O, but got I
			//IL_030e: Expected O, but got I
			//IL_02ac: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			IEnumerable<string> list;
			IEnumerable<string> list2;
			int num;
			if (filters == null)
			{
				num = 0;
				list = to;
				list2 = excludeIds;
				goto IL_015d;
			}
			IEnumerator enumerator = filters.GetEnumerator();
			bool flag = enumerator.MoveNext();
			bool flag2 = !flag;
			OGActionType? oGActionType = null;
			int num3;
			int num4;
			IEnumerable<string> enumerable;
			IEnumerator enumerator2;
			IEnumerable<string> enumerable2;
			int num5;
			int num6;
			int num7;
			if (!flag2)
			{
				int num2 = (int)((IEnumerator<object>)enumerator).Current;
				bool flag3 = num2 == 0;
				oGActionType = null;
				if (!flag3)
				{
					num3 = (((IntPtr)num2 == (IntPtr)typeof(string)) ? num2 : 0);
					bool flag4 = enumerator == null;
					bool flag5 = !flag4;
					num4 = 0;
					enumerable = to;
					enumerator2 = enumerator;
					enumerable2 = excludeIds;
					num5 = 0;
					if (!flag5)
					{
						num6 = 0;
						oGActionType = null;
						num = num3;
						list = to;
						list2 = excludeIds;
						num7 = 0;
						goto IL_04c9;
					}
					goto IL_04ff;
				}
			}
			bool flag6 = enumerator == null;
			num4 = 0;
			num3 = 0;
			enumerable = to;
			enumerator2 = enumerator;
			enumerable2 = excludeIds;
			num5 = 0;
			num6 = 0;
			num = 0;
			list = to;
			list2 = excludeIds;
			num7 = 0;
			if (flag6)
			{
				goto IL_04c9;
			}
			goto IL_04ff;
			IL_02c5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_05a1;
			IL_05a1:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v237 @ X0_v47 (System.Collections.IEnumerator)] (should have been resolved before IL gen)");
			return;
			IL_04ff:
			((IDisposable)enumerator2).Dispose();
			num6 = num4;
			oGActionType = null;
			num = num3;
			list = enumerable;
			list2 = enumerable2;
			num7 = num5;
			goto IL_04c9;
			IL_04c9:
			if (num7 + 1 != 0 || num6 == 0)
			{
				goto IL_015d;
			}
			TypeLoadException ex = new TypeLoadException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_015d:
			IGameroomWrapper gameroomWrapper = this.gameroomWrapper;
			object obj3 = default(object);
			if (obj3 != null)
			{
				string text = oGActionType.ToString();
				string text2 = text;
			}
			else
			{
				string text2 = null;
			}
			string text3 = list.ToCommaSeparateList();
			string text4 = list2.ToCommaSeparateList();
			object obj4 = default(object);
			if (obj4 != null)
			{
				int? num8 = default(int?);
				int value = num8.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			}
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+20]");
			string text5 = callbackManager.AddFacebookDelegate((FacebookDelegate<IAppRequestResult>)0);
			enumerator = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ X8_v17 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+418]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v772 @ X8_v17 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+418]");
			_ = 0;
			IntPtr intPtr2 = (IntPtr)gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_02c5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]");
			object obj6 = 0L + 8L;
			int num9 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v862 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IGameroomWrapper))
				{
					break;
				}
				num9++;
				int num10 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v803 @ X8_v19 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
				bool flag7 = (long)num10 < 0L;
				bool flag8 = !flag7;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_02c5;
			}
			object obj7 = obj6 + 6;
			int num11 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr2 + (long)num11;
			enumerator = (IEnumerator)((long)(IntPtr)obj8 + 304L);
			goto IL_05a1;
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0xD2F038", Offset = "0xD2F038", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\tgoto L_002A;\n\tv48 = *([1F08898]);\n\tv49 = *([v48 @ X8_v28]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023C3A]) = v61;\nL_002A:\n\tgoto L_0033;\n\tv70 = *([v66 @ X0_v2+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_0033;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, toId, link, linkName, linkCaption, linkDescription, picture, mediaSource, v51, v52, v53, v54, v55, v56, v57, v58);\nL_0033:\n\tv80 = System.Uri::op_Inequality(link, 0);\n\tv83 = v80 == 0;\n\tif (v83) goto L_0044;\n\tv93 = System.Uri::ToString(link);\nL_0044:\n\tgoto L_004D;\n\tv128 = *([v97 @ X0_v9+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tgoto L_004D;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v97, v90, v79, linkName, linkCaption, linkDescription, picture, mediaSource, v51, v52, v53, v54, v55, v56, v57, v58);\nL_004D:\n\tv115 = System.Uri::op_Inequality(picture, 0);\n\tv152 = v115 == 0;\n\tif (v152) goto L_0061;\n\tv157 = System.Uri::ToString(picture);\nL_0061:\n\tv260 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v24 @ X29_v1+10]));\n\tv116 = new Facebook.Unity.Gameroom.GameroomFacebook+OnComplete();\n\tv265 = this->klass;\n\tv126 = this->klass->vtable[47];\n\t*([v116 @ X0_v17+20]) = this;\n\tthis->klass->vtable[47] = this->klass->vtable[47];\n\tthis->klass->vtable[47]->methodPtr = this->klass->vtable[47]->methodPtr;\n\tgoto L_00AA;\n\tv271 = *([v267 @ X8_v17+B0]);\n\tv272 = 0;\n\tv273 = v271 + 8;\n\tv275 = *([v311 @ X11_v5-8]);\n\tv317 = v275 == v270;\n\tif (v317) goto L_0097;\n\tv297 = v312 + 1;\n\tv322 = v297 < v269;\n\tv293 = ~v322;\n\tv295 = v311 + 0x10;\n\tv277 = ~v293;\n\tif (v277) goto L_FFFFFFFF;\n\tv298 = 5;\n\tv299 = v65;\n\tv300 = 0x8909C4(v299, v270, v298, linkName, linkCaption, linkDescription, picture, mediaSource, v51, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_00AA;\nL_0097:\n\tv323 = *([v311 @ X11_v5]);\n\tv324 = v323 + 5;\n\tv325 = v324 << 4;\n\tv326 = v267 + v325;\n\tv327 = v326 + 0x130;\nL_00AA:\n\tFacebook.Unity.Gameroom.IGameroomWrapper::DoFeedShareRequest(this.gameroomWrapper, this.appId, toId, v88, linkName, linkCaption, linkDescription, v104);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void FeedShare(string toId, Uri link, string linkName, string linkCaption, string linkDescription, Uri picture, string mediaSource, FacebookDelegate<IShareResult> callback)
		{
			//IL_00b8: Expected O, but got I
			//IL_00cb: Expected I, but got O
			//IL_00db: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = link != null;
			bool flag2 = !flag;
			string link2 = null;
			if (!flag2)
			{
				string text = link.ToString();
				link2 = text;
			}
			bool flag3 = picture != null;
			bool flag4 = !flag3;
			string pictureLink = null;
			if (!flag4)
			{
				string text2 = picture.ToString();
				pictureLink = text2;
			}
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+10]");
			string text3 = callbackManager.AddFacebookDelegate((FacebookDelegate<IShareResult>)0);
			object obj3 = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X8_v15 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+428]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X8_v15 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+428]");
			_ = 0;
			gameroomWrapper.DoFeedShareRequest(appId, toId, link2, linkName, linkCaption, linkDescription, pictureLink, null, null, null);
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0xD2F238", Offset = "0xD2F238", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = Facebook.Unity.Gameroom.GameroomFacebook::FeedShare(this, 0, contentURL, contentTitle, 0, contentDescription, photoURL, 0);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void ShareLink(Uri contentURL, string contentTitle, string contentDescription, Uri photoURL, FacebookDelegate<IShareResult> callback)
		{
			FeedShare(null, contentURL, contentTitle, null, contentDescription, photoURL, null, null);
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0xD2F290", Offset = "0xD2F290", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = &v5 @ stack_-10_v2;\n\tFacebook.Unity.Gameroom.GameroomFacebook::PayImpl(this, product, 0, action, quantity, quantityMin, quantityMax, requestId, pricepointId, *([v4 @ X29_v1+10]), 0, *([v4 @ X29_v1+18]));\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Pay(string product, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, FacebookDelegate<IPayResult> callback)
		{
			//IL_0044: Expected O, but got I
			//IL_0044: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1+10]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X29_v1+18]");
			PayImpl(product, null, action, quantity, quantityMin, quantityMax, requestId, pricepointId, (string)(long)intPtr, null, (FacebookDelegate<IPayResult>)0);
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xD2F504", Offset = "0xD2F504", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EAF8D0]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, callback, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023C3B]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void GetAppLink(FacebookDelegate<IAppLinkResult> callback)
		{
			NotSupportedException ex = new NotSupportedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xD2F568", Offset = "0xD2F568", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Gameroom.GameroomFacebook::LoginWithPermissions(this, scope, callback);\n\treturn;\n")]
		public override void LogInWithPublishPermissions(IEnumerable<string> scope, FacebookDelegate<ILoginResult> callback)
		{
			LoginWithPermissions(scope, callback);
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xD2F6A8", Offset = "0xD2F6A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Gameroom.GameroomFacebook::LoginWithPermissions(this, scope, callback);\n\treturn;\n")]
		public override void LogInWithReadPermissions(IEnumerable<string> scope, FacebookDelegate<ILoginResult> callback)
		{
			LoginWithPermissions(scope, callback);
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xD2F6AC", Offset = "0xD2F6AC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EAA008]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C3C]) = v41;\nL_0019:\n\tv46 = new Facebook.Unity.AppRequestResult();\n\tFacebook.Unity.AppRequestResult::.ctor(v46, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v46);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnAppRequestsComplete(ResultContainer resultContainer)
		{
			AppRequestResult result = new AppRequestResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xD2F72C", Offset = "0xD2F72C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv13 = *([1EEC370]);\n\tv14 = *([v13 @ X8_v8]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, resultContainer, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([2023C3D]) = v34;\nL_0014:\n\tv38 = new System.NotSupportedException();\n\tSystem.NotSupportedException::.ctor(v38);\n\tthrow System.TypeLoadException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGetAppLinkComplete(ResultContainer resultContainer)
		{
			NotSupportedException ex = new NotSupportedException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xD2F790", Offset = "0xD2F790", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBDB38]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C3E]) = v41;\nL_0018:\n\tv45 = new Facebook.Unity.LoginResult();\n\tFacebook.Unity.LoginResult::.ctor(v45, resultContainer);\n\tv48 = this->klass;\n\tv54 = this->klass->vtable[48];\n\tv55 = this->klass->vtable[48];\n\t// 39 IndirectJump v54 @ X3_v1, this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook), this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook), v45 @ X0_v3 (Facebook.Unity.LoginResult), v55 @ X2_v1, v54 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnLoginComplete(ResultContainer resultContainer)
		{
			//IL_0018: Expected I, but got O
			//IL_0028: Expected O, but got I
			//IL_0038: Expected O, but got I
			LoginResult loginResult = new LoginResult(resultContainer);
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+430]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v5 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+438]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xD2F80C", Offset = "0xD2F80C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC8380]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C3F]) = v41;\nL_0019:\n\tv46 = new Facebook.Unity.ShareResult();\n\tFacebook.Unity.ShareResult::.ctor(v46, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v46);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnShareLinkComplete(ResultContainer resultContainer)
		{
			ShareResult result = new ShareResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xD2F88C", Offset = "0xD2F88C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB6FC0]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, resultContainer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023C40]) = v41;\nL_0019:\n\tv46 = new Facebook.Unity.PayResult();\n\tFacebook.Unity.PayResult::.ctor(v46, resultContainer);\n\tFacebook.Unity.CallbackManager::OnFacebookResponse(this.<CallbackManager>k__BackingField, v46);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPayComplete(ResultContainer resultContainer)
		{
			PayResult result = new PayResult(resultContainer);
			CallbackManager.OnFacebookResponse(result);
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xD2F90C", Offset = "0xD2F90C", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0A078]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C41]) = v38;\nL_001C:\n\tgoto L_0043;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v39;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v45, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0043;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 << 4;\n\tv162 = v42 + v161;\n\tv163 = v162 + 0x130;\nL_0043:\n\tv176 = Facebook.Unity.Gameroom.IGameroomWrapper::get_PipeResponse(this.gameroomWrapper);\n\tv131 = v176 == 0;\n\tv121 = ~v131;\n\treturn v121;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HaveReceivedPipeResponse()
		{
			IDictionary<string, object> pipeResponse = gameroomWrapper.PipeResponse;
			bool flag = pipeResponse == null;
			return !flag;
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xD2F9CC", Offset = "0xD2F9CC", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = *([1EF10A8]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, callbackId, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023C42]) = v43;\nL_001F:\n\tgoto L_0046;\n\tv130 = *([v47 @ X8_v4+B0]);\n\tv131 = 0;\n\tv132 = v130 + 8;\n\tv134 = *([v171 @ X11_v18-8]);\n\tv176 = v134 == v50;\n\tif (v176) goto L_003F;\n\tv154 = v170 + 1;\n\tv233 = v154 < v49;\n\tv152 = ~v233;\n\tv156 = v171 + 0x10;\n\tv136 = ~v152;\n\tif (v136) goto L_FFFFFFFF;\n\tv157 = v44;\n\tv158 = 0;\n\tv159 = 0x8909C4(v157, v50, v158, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0046;\nL_003F:\n\tv234 = *([v171 @ X11_v18]);\n\tv235 = v234 << 4;\n\tv236 = v47 + v235;\n\tv237 = v236 + 0x130;\nL_0046:\n\tv116 = Facebook.Unity.Gameroom.IGameroomWrapper::get_PipeResponse(this.gameroomWrapper);\n\tv127 = this.gameroomWrapper;\n\tv241 = *([v127 @ X21_v4 (Facebook.Unity.Gameroom.IGameroomWrapper)]);\n\tv244 = *([v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]) == 0;\n\tif (v244) goto L_006D;\n\tv286 = *([v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]) + 8;\nL_0058:\n\tv291 = *([v286 @ X11_v13-8]) == Facebook.Unity.Gameroom.IGameroomWrapper;\n\tif (v291) goto L_0070;\n\tv285 = v285 + 1;\n\tv296 = v285 < *([v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]);\n\tv267 = ~v296;\n\tv286 = v286 + 0x10;\n\tv251 = ~v267;\n\tif (v251) goto L_0058;\nL_006D:\n\tv303 = 0x8909C4(v127, Facebook.Unity.Gameroom.IGameroomWrapper, 1, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0078;\nL_0070:\n\tv298 = *([v286 @ X11_v13]) + 1;\n\tv299 = v298 << 4;\n\tv300 = v241 + v299;\n\tv303 = v300 + 0x130;\nL_0078:\n\t*([v303 @ X0_v8])(v117, v127, 0, *([v303 @ X0_v8+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv307 = *([v116 @ X0_v7 (System.Collections.Generic.IDictionary`2<System.String, System.Object>)]);\n\tv222 = *([v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]) == 0;\n\tif (v222) goto L_00A2;\n\tv355 = *([v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]) + 8;\nL_008D:\n\tv360 = *([v355 @ X11_v8-8]) == System.Collections.Generic.IDictionary`2<System.String, System.Object>;\n\tif (v360) goto L_00A5;\n\tv354 = v354 + 1;\n\tv365 = v354 < *([v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]);\n\tv336 = ~v365;\n\tv355 = v355 + 0x10;\n\tv320 = ~v336;\n\tif (v320) goto L_008D;\nL_00A2:\n\tv372 = 0x8909C4(v116, System.Collections.Generic.IDictionary`2<System.String, System.Object>, 4, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00AE;\nL_00A5:\n\tv367 = *([v355 @ X11_v8]) + 4;\n\tv368 = v367 << 4;\n\tv369 = v307 + v368;\n\tv372 = v369 + 0x130;\nL_00AE:\n\t*([v372 @ X0_v11])(v375, v116, \"callback_id\", callbackId, *([v372 @ X0_v11+8]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturnVal2 = Facebook.Unity.Utilities::ToJson(v116);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetPipeResponse(string callbackId)
		{
			//IL_0012: Expected I, but got O
			//IL_004d: Expected O, but got I
			//IL_0108: Expected I, but got O
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0143: Expected O, but got I
			//IL_0099: Expected O, but got I
			//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c5: Expected O, but got Unknown
			//IL_01e2: Expected O, but got I
			//IL_01f1: Expected O, but got I
			//IL_018f: Expected O, but got I
			IDictionary<string, object> pipeResponse = this.gameroomWrapper.PipeResponse;
			IGameroomWrapper gameroomWrapper = this.gameroomWrapper;
			IntPtr intPtr = (IntPtr)gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v286 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IGameroomWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v241 @ X8_v7 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_023e;
			IL_00b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_023e;
			IL_023e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v303 @ X0_v8] (should have been resolved before IL gen)");
			IntPtr intPtr2 = (IntPtr)pipeResponse;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_01a8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+B0]");
			object obj5 = 0L + 8L;
			int num4 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v355 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IDictionary<string, object>))
				{
					break;
				}
				num4++;
				int num5 = num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v10 (Il2CppClass<System.Collections.Generic.IDictionary`2<System.String, System.Object>>)+126]");
				bool flag3 = (long)num5 < 0L;
				bool flag4 = !flag3;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_01a8;
			}
			object obj6 = obj5 + 4;
			int num6 = (int)((long)(IntPtr)obj6 << 4);
			object obj7 = (long)intPtr2 + (long)num6;
			object obj8 = (long)(IntPtr)obj7 + 304L;
			goto IL_0277;
			IL_0277:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v372 @ X0_v11] (should have been resolved before IL gen)");
			return pipeResponse.ToJson();
			IL_01a8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0277;
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0xD2E680", Offset = "0xD2E680", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EE4FB8]);\n\tv17 = *([v16 @ X8_v12]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023C43]) = v37;\nL_0016:\n\tv42 = System.Reflection.Assembly::Load(\"Facebook.Unity.Gameroom\");\n\tv50 = System.Reflection.Assembly::GetType(v42, \"Facebook.Unity.Gameroom.GameroomWrapper\");\n\tv52 = System.Activator::CreateInstance(v50);\n\tv55 = v52 == 0;\n\tif (v55) goto L_0032;\n\t// 42 IsInst returnVal1 @ X0_v10 (Facebook.Unity.Gameroom.IGameroomWrapper), typeof(Facebook.Unity.Gameroom.IGameroomWrapper), v52 @ X0_v9 (System.Object)\n\tv66 = returnVal1 == 0;\n\tif (v66) goto L_0036;\nL_0032:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0036:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IGameroomWrapper GetGameroomWrapper()
		{
			Assembly assembly = Assembly.Load("Facebook.Unity.Gameroom");
			Type type = assembly.GetType("Facebook.Unity.Gameroom.GameroomWrapper");
			object obj = Activator.CreateInstance(type);
			bool flag = obj == null;
			IGameroomWrapper gameroomWrapper = (IGameroomWrapper)obj;
			if (!flag)
			{
				gameroomWrapper = obj as IGameroomWrapper;
				if (gameroomWrapper == null)
				{
					return (IGameroomWrapper)new InvalidCastException();
				}
			}
			return gameroomWrapper;
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0xD2F2E4", Offset = "0xD2F2E4", Length = "0x220")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-10_v2;\n\t*([v24 @ X29_v1-60]) = quantityMax;\n\t*([v24 @ X29_v1-58]) = quantityMin;\n\t*([v24 @ X29_v1-64]) = quantity;\n\tgoto L_0026;\n\tv47 = *([1ED7658]);\n\tv48 = *([v47 @ X8_v32]);\n\tv49 = \"il2cpp_codegen_initialize_method\"(v48, product, productId, action, quantity, quantityMin, quantityMax, requestId, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv60 = 0 | 1;\n\t*([2023C44]) = v60;\nL_0026:\n\tthis = &v25 @ stack_-10_v2 - 0x64;\n\tv66 = this.gameroomWrapper;\n\tthis = 0xDC3560(this, 0, productId, action, quantity, quantityMin, quantityMax, requestId, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv73 = quantityMin & 0xFF00000000;\n\tv74 = v73 == 0;\n\tif (v74) goto L_0040;\n\tv77 = &v25 @ stack_-10_v2 - 0x58;\n\tv79 = System.Nullable`1<System.Int32>::get_Value(v77);\n\tv85 = 0xDC3560(&v79 @ X0_v26 (System.Int32), 0, productId, action, quantity, quantityMin, quantityMax, requestId, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv91 = *([v24 @ X29_v1-5C]);\n\tgoto L_0041;\nL_0040:\n\tv91 = quantityMax >> 0x20;\nL_0041:\n\tv93 = v91 & 0xFF;\n\tv94 = v93 == 0;\n\tif (v94) goto L_0057;\n\tv97 = &v25 @ stack_-10_v2 - 0x60;\n\tv99 = System.Nullable`1<System.Int32>::get_Value(v97);\n\tthis = 0xDC3560(&v99 @ X0_v22 (System.Int32), 0, productId, action, quantity, quantityMin, quantityMax, requestId, v50, v51, v52, v53, v54, v55, v56, v57);\n\tgoto L_0057;\nL_0057:\n\tv117 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, *([v24 @ X29_v1+28]));\n\tthis = new Facebook.Unity.Gameroom.GameroomFacebook+OnComplete();\n\tv135 = Il2CppMethodInfo;\n\t*([this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook)+20]) = this;\n\t*([this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook)+28]) = Il2CppMethodInfo;\n\t*([this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook)+10]) = *([v135 @ X8_v19 (Il2CppMethodInfo)]);\n\tv143 = *([v66 @ X24_v1 (Facebook.Unity.Gameroom.IGameroomWrapper)]);\n\tv150 = *([v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]) == 0;\n\tif (v150) goto L_008F;\n\tv299 = *([v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]) + 8;\nL_007A:\n\tv305 = *([v299 @ X11_v5-8]) == Facebook.Unity.Gameroom.IGameroomWrapper;\n\tif (v305) goto L_0092;\n\tv300 = v300 + 1;\n\tv310 = v300 < *([v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]);\n\tv281 = ~v310;\n\tv299 = v299 + 0x10;\n\tv265 = ~v281;\n\tif (v265) goto L_007A;\nL_008F:\n\tthis = 0x8909C4(v66, Facebook.Unity.Gameroom.IGameroomWrapper, 4, action, quantity, quantityMin, quantityMax, requestId, v50, v51, v52, v53, v54, v55, v56, v57);\n\tgoto L_00A8;\nL_0092:\n\tv312 = *([v299 @ X11_v5]) + 4;\n\tv313 = v312 << 4;\n\tv314 = v143 + v313;\n\tthis = v314 + 0x130;\nL_00A8:\n\t*([this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook)])(this, v66, this.appId, \"pay\", action, product, productId, this, v86, v50, v51, v52, v53, v54, v55, v56, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void PayImpl(string product, string productId, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, string developerPayload, FacebookDelegate<IPayResult> callback)
		{
			//IL_01ef: Expected O, but got I
			//IL_0210: Unknown result type (might be due to invalid IL or missing references)
			//IL_0215: Expected I4, but got Unknown
			//IL_0072: Expected I4, but got O
			//IL_002b: Expected O, but got I
			//IL_00c7: Expected O, but got I
			//IL_008f: Expected O, but got I
			//IL_00f2: Expected I, but got O
			//IL_012d: Expected O, but got I
			//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
			//IL_01af: Expected O, but got Unknown
			//IL_01cc: Expected O, but got I
			//IL_01db: Expected O, but got I
			//IL_0179: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			GameroomFacebook gameroomFacebook = (GameroomFacebook)((long)(IntPtr)obj2 - 100L);
			IGameroomWrapper gameroomWrapper = this.gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			int num2;
			if ((int)((_003F?)quantityMin & 0xFF00000000L) != 0)
			{
				int? num = (int?)(object)((long)(IntPtr)obj2 - 88L);
				int value = ((int?*)num)->Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-5C]");
				num2 = 0;
				int num4 = default(int);
				int num3 = num4;
			}
			else
			{
				num2 = (object?)quantityMax >> 32;
				int num3 = 0;
			}
			if ((num2 & 0xFF) != 0)
			{
				int? num5 = (int?)(object)((long)(IntPtr)obj2 - 96L);
				int value2 = ((int?*)num5)->Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC3560 (inside System.InvalidCastException::.ctor +0x288)");
			}
			CallbackManager callbackManager = CallbackManager;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1+28]");
			string text = callbackManager.AddFacebookDelegate((FacebookDelegate<IPayResult>)0);
			gameroomFacebook = null;
			IntPtr intPtr = (IntPtr)0;
			_ = 0;
			IntPtr intPtr2 = (IntPtr)gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0192;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]");
			object obj3 = 0L + 8L;
			int num6 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v299 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IGameroomWrapper))
				{
					break;
				}
				num6++;
				int num7 = num6;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v20 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
				bool flag = (long)num7 < 0L;
				bool flag2 = !flag;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_0192;
			}
			object obj4 = obj3 + 4;
			int num8 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr2 + (long)num8;
			gameroomFacebook = (GameroomFacebook)((long)(IntPtr)obj5 + 304L);
			goto IL_0287;
			IL_0192:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0287;
			IL_0287:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (Facebook.Unity.Gameroom.GameroomFacebook)] (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xD2F56C", Offset = "0xD2F56C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED6D40]);\n\tv31 = *([v30 @ X8_v15]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, scope, callback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023C45]) = v48;\nL_0019:\n\tv49 = this.appId;\n\tv50 = this.gameroomWrapper;\n\tv52 = Facebook.Unity.Utilities::ToCommaSeparateList(scope);\n\tv61 = Facebook.Unity.CallbackManager::AddFacebookDelegate(this.<CallbackManager>k__BackingField, callback);\n\tv70 = new Facebook.Unity.Gameroom.GameroomFacebook+OnComplete();\n\tv83 = this->klass;\n\tv76 = this->klass->vtable[44];\n\t*([v70 @ X0_v10+20]) = this;\n\tthis->klass->vtable[44] = this->klass->vtable[44];\n\tthis->klass->vtable[44]->methodPtr = this->klass->vtable[44]->methodPtr;\n\tv160 = *([v50 @ X20_v1 (Facebook.Unity.Gameroom.IGameroomWrapper)]);\n\tv146 = *([v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]) == 0;\n\tif (v146) goto L_005A;\n\tv204 = *([v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]) + 8;\nL_0045:\n\tv210 = *([v204 @ X11_v5-8]) == Facebook.Unity.Gameroom.IGameroomWrapper;\n\tif (v210) goto L_005D;\n\tv205 = v205 + 1;\n\tv215 = v205 < *([v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]);\n\tv186 = ~v215;\n\tv204 = v204 + 0x10;\n\tv170 = ~v186;\n\tif (v170) goto L_0045;\nL_005A:\n\tv222 = 0x8909C4(v50, Facebook.Unity.Gameroom.IGameroomWrapper, 3, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0061;\nL_005D:\n\tv217 = *([v204 @ X11_v5]) + 3;\n\tv218 = v217 << 4;\n\tv219 = v160 + v218;\n\tv222 = v219 + 0x130;\nL_0061:\n\tv93 = *([v222 @ X0_v11]);\n\tv91 = *([v222 @ X0_v11+8]);\n\t// 113 IndirectJump v93 @ X6_v1, v50 @ X20_v1 (Facebook.Unity.Gameroom.IGameroomWrapper), v50 @ X20_v1 (Facebook.Unity.Gameroom.IGameroomWrapper), v49 @ X19_v2 (System.String), v52 @ X0_v3 (System.String), v61 @ X0_v8 (System.String), v70 @ X0_v10, v91 @ X5_v1, v93 @ X6_v1, v37 @ X7, v38 @ V0, v39 @ V1, v40 @ V2, v41 @ V3, v42 @ V4, v43 @ V5, v44 @ V6, v45 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoginWithPermissions(IEnumerable<string> scope, FacebookDelegate<ILoginResult> callback)
		{
			//IL_0027: Expected I, but got O
			//IL_0037: Expected O, but got I
			//IL_0058: Expected I, but got O
			//IL_01ae: Expected O, but got I
			//IL_0093: Expected O, but got I
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_0115: Expected O, but got Unknown
			//IL_0132: Expected O, but got I
			//IL_0141: Expected O, but got I
			//IL_00df: Expected O, but got I
			string text = appId;
			IGameroomWrapper gameroomWrapper = this.gameroomWrapper;
			string text2 = scope.ToCommaSeparateList();
			string text3 = CallbackManager.AddFacebookDelegate(callback);
			object obj = null;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3F8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v8 (Il2CppClass<Facebook.Unity.Gameroom.GameroomFacebook>)+3F8]");
			_ = 0;
			IntPtr intPtr2 = (IntPtr)gameroomWrapper;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+B0]");
			object obj3 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IGameroomWrapper))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v10 (Il2CppClass<Facebook.Unity.Gameroom.IGameroomWrapper>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f8;
			}
			object obj4 = obj3 + 3;
			int num3 = (int)((long)(IntPtr)obj4 << 4);
			object obj5 = (long)intPtr2 + (long)num3;
			object obj6 = (long)(IntPtr)obj5 + 304L;
			goto IL_0196;
			IL_00f8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0196;
			IL_0196:
			object obj7 = obj6;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X0_v11+8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v93 @ X6_v1 (should have been resolved before IL gen)");
		}
	}
}
