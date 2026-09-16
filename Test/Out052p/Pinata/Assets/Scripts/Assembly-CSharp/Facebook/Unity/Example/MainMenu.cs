using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005F")]
	internal sealed class MainMenu : MenuBase
	{
		[Token(Token = "0x6000294")]
		[Address(RVA = "0xA098F0", Offset = "0xA098F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool ShowBackButton()
		{
			return false;
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0xA098F8", Offset = "0xA098F8", Length = "0x904")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv36 = *([1EF3AF8]);\n\tv37 = *([v36 @ X8_v194]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021CB3]) = v56;\nL_0020:\n\tv61 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0029;\n\tv66 = v61;\n\tv67 = 0x8907BC(v66, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv70 = *([v61 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0029:\n\tv71 = *([v61 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv72 = v71 == 0;\n\tif (v72) goto L_004A;\n\tv74 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0036;\n\tv96 = v74;\n\tv97 = 0x8907BC(v96, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv98 = *([v74 @ X20_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv84 = ~v98;\n\tif (v84) goto L_004A;\n\tgoto L_004A;\n\tv114 = v89;\n\tv115 = 0x8907BC(v114, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004A:\n\tgoto L_0050;\n\tv99 = v91;\n\tv100 = 0x8907BC(v99, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0050:\n\tUnityEngine.GUILayout::BeginVertical(v102.Value);\n\tgoto L_005E;\n\tv118 = *([v110 @ X0_v6+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_005E;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v110, v103, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_005E:\n\tv126 = UnityEngine.GUI::get_enabled();\n\tv132 = Facebook.Unity.Example.ConsoleBase::Button(this, \"FB.Init\");\n\tv134 = v132 == 0;\n\tif (v134) goto L_00AF;\n\tv138 = new Facebook.Unity.InitDelegate();\n\tFacebook.Unity.InitDelegate::.ctor(v138, this, Il2CppMethodInfo);\n\tv183 = new Facebook.Unity.HideUnityDelegate();\n\tFacebook.Unity.HideUnityDelegate::.ctor(v183, this, Il2CppMethodInfo);\n\tgoto L_008E;\n\tv231 = *([v222 @ X0_v199+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_008E;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v222, v209, v211, v210, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_008E:\n\tFacebook.Unity.FB::Init(v138, v183, 0);\n\tgoto L_009E;\n\tv274 = *([1EB8180]);\n\tv275 = *([v274 @ X8_v183]);\n\tv276 = \"il2cpp_codegen_initialize_method\"(v275, v239, v240, v151, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv279 = 0 | 1;\n\t*([2021D31]) = v279;\nL_009E:\n\tgoto L_00AB;\n\tv293 = *([v280 @ X0_v203 (Il2CppClass<Facebook.Unity.FB>)+E0]);\n\tv294 = v293 == 0;\n\tv295 = ~v294;\n\tgoto L_00AB;\n\tv306 = \"il2cpp_codegen_runtime_class_init\"(v280, v239, v240, v151, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv297 = Facebook.Unity.FB;\nL_00AB:\n\tv155 = System.String::Concat(\"FB.Init() called with \", v159.<AppId>k__BackingField);\n\tthis.status = v155;\nL_00AF:\n\tv162 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_00B8;\n\tv173 = v162;\n\tv174 = 0x8907BC(v173, v152, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv177 = *([v162 @ X21_v3 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_00B8:\n\tv178 = *([v162 @ X21_v3 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv179 = v178 == 0;\n\tif (v179) goto L_00D9;\n\tv185 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_00C5;\n\tv212 = v185;\n\tv213 = 0x8907BC(v212, v152, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00C5:\n\tv214 = *([v185 @ X21_v40 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv197 = ~v214;\n\tif (v197) goto L_00D9;\n\tgoto L_00D9;\n\tv241 = v191;\n\tv242 = 0x8907BC(v241, v152, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00D9:\n\tgoto L_00DF;\n\tv215 = v202;\n\tv216 = 0x8907BC(v215, v152, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00DF:\n\tUnityEngine.GUILayout::BeginHorizontal(v218.Value);\n\tv230 = v126 == 0;\n\tif (v230) goto L_FFFFFFFF;\n\tgoto L_00F0;\n\tv255 = *([v247 @ X0_v178+E0]);\n\tv256 = v255 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_00F0;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v247, v219, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_00F0:\n\tv263 = Facebook.Unity.FB::get_IsInitialized();\n\tgoto L_00F8;\nL_00F8:\n\tgoto L_0100;\n\tv284 = *([v269 @ X0_v18+E0]);\n\tv285 = v284 == 0;\n\tv286 = ~v285;\n\tgoto L_0100;\n\tv288 = \"il2cpp_codegen_runtime_class_init\"(v269, v219, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0100:\n\tUnityEngine.GUI::set_enabled(v264);\n\tv305 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Login\");\n\tv308 = v305 == 0;\n\tif (v308) goto L_0115;\n\tFacebook.Unity.Example.MainMenu::CallFBLogin(this);\n\tthis.status = \"Login called\";\nL_0115:\n\tgoto L_011C;\n\tv321 = *([v315 @ X0_v24+E0]);\n\tv322 = v321 == 0;\n\tv323 = ~v322;\n\tgoto L_011C;\n\tv325 = \"il2cpp_codegen_runtime_class_init\"(v315, v304, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_011C:\n\tv329 = Facebook.Unity.FB::get_IsLoggedIn();\n\tgoto L_012B;\n\tv335 = *([v330 @ X8_v30+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_012B;\n\tv344 = v330;\n\tv340 = \"il2cpp_codegen_runtime_class_init\"(v344, v304, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_012B:\n\tUnityEngine.GUI::set_enabled(v329);\n\tv349 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Get publish_actions\");\n\tv351 = v349 == 0;\n\tif (v351) goto L_0140;\n\tFacebook.Unity.Example.MainMenu::CallFBLoginForPublish(this);\n\tthis.status = \"Login (for publish_actions) called\";\nL_0140:\n\tgoto L_014D;\n\tv364 = *([v358 @ X0_v33 (Il2CppClass<UnityEngine.GUIContent>)+E0]);\n\tv365 = v364 == 0;\n\tv366 = ~v365;\n\tgoto L_014D;\n\tv378 = \"il2cpp_codegen_runtime_class_init\"(v358, v348, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv368 = UnityEngine.GUIContent;\nL_014D:\n\t// 333 NewArr v377 @ X0_v36 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tgoto L_015D;\n\tv386 = *([v382 @ X8_v39+E0]);\n\tv387 = v386 == 0;\n\tv388 = ~v387;\n\tgoto L_015D;\n\tv395 = v382;\n\tv391 = \"il2cpp_codegen_runtime_class_init\"(v395, v374, v146, v150, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_015D:\n\tv394 = Facebook.Unity.Constants::get_IsMobile();\n\tv400 = v394 == 0;\n\tv405 = ~v400;\n\tv406 = ~v405;\n\tif (v406) goto L_FFFFFFFF;\n\tgoto L_016E;\nL_016E:\n\tv410 = UnityEngine.GUILayout::MinWidth(v409);\n\tv413 = v410 == 0;\n\tif (v413) goto L_017B;\n\t// 375 IsInst v449 @ X0_v166, typeof(UnityEngine.GUILayoutOption), v410 @ X0_v41 (UnityEngine.GUILayoutOption)\nL_017B:\n\tv456 = v377.Length == 0;\n\tif (v456) goto L_0305;\n\tv377[0] = v410;\n\tUnityEngine.GUILayout::Label(v372.none, v377);\n\tUnityEngine.GUILayout::EndHorizontal();\n\tv520 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_018F;\n\tv525 = v520;\n\tv526 = 0x8907BC(v525, v478, v433, v150, v42, v43, v44, v45, v409, v47, v48, v49, v50, v51, v52, v53);\n\tv529 = *([v520 @ X21_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_018F:\n\tv530 = *([v520 @ X21_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv531 = v530 == 0;\n\tif (v531) goto L_01B0;\n\tv578 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_019C;\n\tv600 = v578;\n\tv601 = 0x8907BC(v600, v478, v433, v150, v42, v43, v44, v45, v409, v47, v48, v49, v50, v51, v52, v53);\nL_019C:\n\tv602 = *([v578 @ X21_v35 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv590 = ~v602;\n\tif (v590) goto L_01B0;\n\tgoto L_01B0;\n\tv615 = v584;\n\tv616 = 0x8907BC(v615, v478, v433, v150, v42, v43, v44, v45, v409, v47, v48, v49, v50, v51, v52, v53);\nL_01B0:\n\tgoto L_01B6;\n\tv603 = v595;\n\tv604 = 0x8907BC(v603, v478, v433, v150, v42, v43, v44, v45, v409, v47, v48, v49, v50, v51, v52, v53);\nL_01B6:\n\tUnityEngine.GUILayout::BeginHorizontal(v606.Value);\n\t// 444 NewArr v614 @ X0_v59 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 1\n\tv620 = Facebook.Unity.Constants::get_IsMobi\n// ... truncated")]
		protected override void GetGui()
		{
			//IL_045c: Expected O, but got I4
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X20_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v74 @ X20_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginVertical();
			bool flag = GUI.enabled;
			if (Button("FB.Init"))
			{
				InitDelegate onInitComplete = OnInitComplete;
				HideUnityDelegate onHideUnity = OnHideUnity;
				FB.Init(onInitComplete, onHideUnity);
				string text = "FB.Init() called with " + FB.AppId;
				status = text;
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X21_v3 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ X21_v40 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginHorizontal();
			int num;
			if (flag)
			{
				bool isInitialized = FB.IsInitialized;
				num = (isInitialized ? 1 : 0);
			}
			else
			{
				num = 0;
			}
			GUI.enabled = (byte)num != 0;
			if (Button("Login"))
			{
				CallFBLogin();
				status = "Login called";
			}
			bool isLoggedIn = FB.IsLoggedIn;
			GUI.enabled = isLoggedIn;
			if (Button("Get publish_actions"))
			{
				CallFBLoginForPublish();
				status = "Login (for publish_actions) called";
			}
			GUILayoutOption[] array = new GUILayoutOption[1];
			float minWidth = ((!Constants.IsMobile) ? 48f : 0f);
			GUILayoutOption gUILayoutOption = GUILayout.MinWidth(minWidth);
			if (gUILayoutOption != null)
			{
				object obj = gUILayoutOption as GUILayoutOption;
			}
			if (array.Length != 0)
			{
				array[0] = gUILayoutOption;
				GUILayout.Label(GUIContent.none, array);
				GUILayout.EndHorizontal();
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v520 @ X21_v13 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v578 @ X21_v35 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.BeginHorizontal();
				GUILayoutOption[] array2 = new GUILayoutOption[1];
				float minWidth2 = ((!Constants.IsMobile) ? 48f : 0f);
				GUILayoutOption gUILayoutOption2 = GUILayout.MinWidth(minWidth2);
				if (gUILayoutOption2 != null)
				{
					object obj2 = gUILayoutOption2 as GUILayoutOption;
				}
				if (array2.Length != 0)
				{
					array2[0] = gUILayoutOption2;
					GUILayout.Label(GUIContent.none, array2);
					GUILayout.EndHorizontal();
					bool flag2 = Button("Logout");
					if (flag2)
					{
						((MainMenu)flag2).CallFBLogout();
						status = "Logout called";
					}
					int num2;
					if (flag)
					{
						bool isInitialized2 = FB.IsInitialized;
						num2 = (isInitialized2 ? 1 : 0);
					}
					else
					{
						num2 = 0;
					}
					GUI.enabled = (byte)num2 != 0;
					if (Button("Share Dialog"))
					{
						Type typeFromHandle = typeof(DialogShare);
						SwitchMenu(typeFromHandle);
					}
					if (Button("App Requests"))
					{
						Type typeFromHandle2 = typeof(AppRequests);
						SwitchMenu(typeFromHandle2);
					}
					if (Button("Graph Request"))
					{
						Type typeFromHandle3 = typeof(GraphRequest);
						SwitchMenu(typeFromHandle3);
					}
					if (Constants.IsWeb && Button("Pay"))
					{
						Type typeFromHandle4 = typeof(Pay);
						SwitchMenu(typeFromHandle4);
					}
					if (Button("App Events"))
					{
						Type typeFromHandle5 = typeof(AppEvents);
						SwitchMenu(typeFromHandle5);
					}
					if (Button("App Links"))
					{
						Type typeFromHandle6 = typeof(AppLinks);
						SwitchMenu(typeFromHandle6);
					}
					if (Constants.IsMobile && Button("Access Token"))
					{
						Type typeFromHandle7 = typeof(AccessTokenMenu);
						SwitchMenu(typeFromHandle7);
					}
					GUILayout.EndVertical();
					GUI.enabled = flag;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0xA0A1FC", Offset = "0xA0A1FC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EC9F10]);\n\tv21 = *([v20 @ X8_v24]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CB4]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v44);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v44, \"public_profile\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(v44, \"email\");\n\tSystem.Collections.Generic.List`1<System.String>::Add(v44, \"user_friends\");\n\tv97 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>::.ctor(v97, this, Il2CppMethodInfo);\n\tgoto L_0055;\n\tv110 = *([v106 @ X0_v11+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_0055;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v106, v101, v103, v72, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0055:\n\tFacebook.Unity.FB::LogInWithReadPermissions(v44, v97);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CallFBLogin()
		{
			List<string> list = new List<string>();
			list.Add("public_profile");
			list.Add("email");
			list.Add("user_friends");
			FacebookDelegate<ILoginResult> callback = base.HandleResult;
			FB.LogInWithReadPermissions(list, callback);
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0xA0A324", Offset = "0xA0A324", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EEF250]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CB5]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v44);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v44, \"publish_actions\");\n\tv62 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.ILoginResult>::.ctor(v62, this, Il2CppMethodInfo);\n\tgoto L_0049;\n\tv100 = *([v96 @ X0_v9+E0]);\n\tv101 = v100 == 0;\n\tv102 = ~v101;\n\tif (v102) goto L_0049;\n\tv104 = \"il2cpp_codegen_runtime_class_init\"(v96, v67, v69, v70, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0049:\n\tFacebook.Unity.FB::LogInWithPublishPermissions(v44, v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CallFBLoginForPublish()
		{
			List<string> list = new List<string>();
			list.Add("publish_actions");
			FacebookDelegate<ILoginResult> callback = base.HandleResult;
			FB.LogInWithPublishPermissions(list, callback);
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0xA0A41C", Offset = "0xA0A41C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE8DB8]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2021CB6]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\tFacebook.Unity.FB::LogOut();\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CallFBLogout()
		{
			FB.LogOut();
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0xA0A47C", Offset = "0xA0A47C", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAD968]);\n\tv19 = *([v18 @ X8_v31]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CB7]) = v38;\nL_0018:\n\tthis.status = \"Success - Check log for details\";\n\tthis.lastResponse = \"Success Response: OnInitComplete Called\\n\";\n\tgoto L_0028;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tv59 = Facebook.Unity.FB::get_IsLoggedIn();\n\t// 48 Box v67 @ X0_v7 (System.Object), typeof(System.Boolean), &v59 @ X0_v5 (System.Boolean)\n\tv70 = Facebook.Unity.FB::get_IsInitialized();\n\t// 57 Box v76 @ X0_v11 (System.Object), typeof(System.Boolean), &v70 @ X0_v9 (System.Boolean)\n\tv84 = System.String::Format(\"OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'\", v67, v76);\n\tgoto L_0051;\n\tv92 = *([v88 @ X8_v16+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0051;\n\tv100 = v88;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v100, v80, v79, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0051:\n\tFacebook.Unity.Example.LogView::AddLog(v84);\n\tgoto L_0061;\n\tv106 = *([1EB68B0]);\n\tv107 = *([v106 @ X8_v27]);\n\tv108 = \"il2cpp_codegen_initialize_method\"(v107, v80, v79, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv111 = 0 | 1;\n\t*([2021D32]) = v111;\nL_0061:\n\t;\n\tv117 = v115.<CurrentAccessToken>k__BackingField == 0;\n\tif (v117) goto L_007B;\n\tv121 = Facebook.Unity.AccessToken::ToString(v115.<CurrentAccessToken>k__BackingField);\n\tgoto L_0075;\n\tv140 = *([v122 @ X8_v25+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0075;\n\tv145 = v122;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v145, v120, v79, v81, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0075:\n\tFacebook.Unity.Example.LogView::AddLog(v121);\nL_007B:\n\treturn;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnInitComplete()
		{
			status = "Success - Check log for details";
			lastResponse = "Success Response: OnInitComplete Called\n";
			bool isLoggedIn = FB.IsLoggedIn;
			object arg = isLoggedIn;
			bool isInitialized = FB.IsInitialized;
			object arg2 = isInitialized;
			string log = $"OnInitCompleteCalled IsLoggedIn='{arg}' IsInitialized='{arg2}'";
			LogView.AddLog(log);
			if (AccessToken.CurrentAccessToken != null)
			{
				string log2 = AccessToken.CurrentAccessToken.ToString();
				LogView.AddLog(log2);
			}
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0xA0A610", Offset = "0xA0A610", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv23 = *([1EAC948]);\n\tv24 = *([v23 @ X8_v18]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, isGameShown, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021CB8]) = v42;\nL_001A:\n\tthis.status = \"Success - Check log for details\";\n\t// 31 Box v51 @ X0_v3 (System.Object), typeof(System.Boolean), &isGameShown @ X1 (System.Boolean)\n\tv58 = System.String::Format(\"Success Response: OnHideUnity Called {0}\\n\", v51);\n\tthis.lastResponse = v58;\n\tv61 = 0xE8F14C(&isGameShown @ X1 (System.Boolean), 0, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv68 = System.String::Concat(\"Is game shown: \", v61);\n\tgoto L_0041;\n\tv76 = *([v72 @ X8_v16+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0041;\n\tv84 = v72;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v84, v64, v65, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0041:\n\tFacebook.Unity.Example.LogView::AddLog(v68);\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnHideUnity(bool isGameShown)
		{
			status = "Success - Check log for details";
			object arg = isGameShown;
			string text = $"Success Response: OnHideUnity Called {arg}\n";
			lastResponse = text;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E8F14C (inside System.BitConverter::.cctor +0x64)");
			string text2 = default(string);
			string log = "Is game shown: " + text2;
			LogView.AddLog(log);
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0xA0A700", Offset = "0xA0A700", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n")]
		public MainMenu()
		{
		}
	}
}
