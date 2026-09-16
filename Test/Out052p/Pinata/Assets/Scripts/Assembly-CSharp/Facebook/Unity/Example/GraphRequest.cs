using System;
using System.Collections;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005E")]
	internal class GraphRequest : MenuBase
	{
		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x60")]
		private string apiQuery;

		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x68")]
		private Texture2D profilePic;

		[Token(Token = "0x6000290")]
		[Address(RVA = "0xA08778", Offset = "0xA08778", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA9DA0]);\n\tv25 = *([v24 @ X8_v84]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021CA9]) = v44;\nL_001C:\n\tgoto L_0023;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0023;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0023:\n\tv59 = UnityEngine.GUI::get_enabled();\n\tv61 = v59 == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tgoto L_0034;\n\tv70 = *([v64 @ X0_v72+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0034;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v64, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0034:\n\tv78 = Facebook.Unity.FB::get_IsLoggedIn();\n\tgoto L_003E;\nL_003E:\n\tgoto L_0046;\n\tv90 = *([v86 @ X0_v7+E0]);\n\tv91 = v90 == 0;\n\tv92 = ~v91;\n\tgoto L_0046;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v86, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0046:\n\tUnityEngine.GUI::set_enabled(v79);\n\tv103 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Basic Request - Me\");\n\tv105 = v103 == 0;\n\tif (v105) goto L_0074;\n\tv109 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>::.ctor(v109, this, Il2CppMethodInfo);\n\tgoto L_006F;\n\tv175 = *([v144 @ X0_v67+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_006F;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v144, v137, v138, v139, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_006F:\n\tFacebook.Unity.FB::API(\"/me\", 0, v109, 0);\nL_0074:\n\tv133 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Retrieve Profile Photo\");\n\tv141 = v133 == 0;\n\tif (v141) goto L_009D;\n\tv151 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>::.ctor(v151, this, Il2CppMethodInfo);\n\tgoto L_0098;\n\tv209 = *([v192 @ X0_v61+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0098;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v192, v185, v186, v187, v110, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0098:\n\tFacebook.Unity.FB::API(\"/me/picture\", 0, v151, 0);\nL_009D:\n\tv174 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Take and Upload screenshot\");\n\tv189 = v174 == 0;\n\tif (v189) goto L_00A9;\n\tv197 = Facebook.Unity.Example.GraphRequest::TakeScreenshot(this);\n\tv203 = UnityEngine.MonoBehaviour::StartCoroutine(this, v197);\nL_00A9:\n\tv206 = this + 0x60;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Request\", v206);\n\tv221 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Custom Request\");\n\tv223 = v221 == 0;\n\tif (v223) goto L_00DC;\n\tv228 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IGraphResult>::.ctor(v228, this, Il2CppMethodInfo);\n\tgoto L_00D4;\n\tv280 = *([v274 @ X0_v51+E0]);\n\tv281 = v280 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00D4;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v274, v258, v259, v260, v152, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00D4:\n\tFacebook.Unity.FB::API(this.apiQuery, 0, v228, 0);\nL_00DC:\n\tgoto L_00E5;\n\tv261 = *([v251 @ X0_v23+E0]);\n\tv262 = v261 == 0;\n\tv263 = ~v262;\n\tif (v263) goto L_00E5;\n\tv265 = \"il2cpp_codegen_runtime_class_init\"(v251, v239, v235, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00E5:\n\tv271 = UnityEngine.Object::op_Inequality(this.profilePic, 0);\n\tv279 = v271 == 0;\n\tif (v279) goto L_0124;\n\tv290 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_00F7;\n\tv313 = v290;\n\tv314 = 0x8907BC(v313, v269, v270, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv317 = *([v290 @ X21_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_00F7:\n\tv318 = *([v290 @ X21_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv319 = v318 == 0;\n\tif (v319) goto L_0118;\n\tv337 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0104;\n\tv357 = v337;\n\tv358 = 0x8907BC(v357, v269, v270, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0104:\n\tv359 = *([v337 @ X21_v11 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv349 = ~v359;\n\tif (v349) goto L_0118;\n\tgoto L_0118;\n\tv366 = v343;\n\tv367 = 0x8907BC(v366, v269, v270, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0118:\n\tgoto L_011F;\n\tv360 = v301;\n\tv361 = 0x8907BC(v360, v269, v270, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_011F:\n\tUnityEngine.GUILayout::Box(this.profilePic, v308.Value);\nL_0124:\n\tgoto L_0134;\n\tv320 = *([v309 @ X0_v28+E0]);\n\tv321 = v320 == 0;\n\tv322 = ~v321;\n\tif (v322) goto L_0134;\n\tv324 = \"il2cpp_codegen_runtime_class_init\"(v309, v298, v296, v233, v231, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0134:\n\tUnityEngine.GUI::set_enabled(v84);\n\treturn;\n// 198 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void GetGui()
		{
			int num;
			int num2;
			if (GUI.enabled)
			{
				bool isLoggedIn = FB.IsLoggedIn;
				num = (isLoggedIn ? 1 : 0);
				num2 = 1;
			}
			else
			{
				num = 0;
				num2 = 0;
			}
			GUI.enabled = (byte)num != 0;
			if (Button("Basic Request - Me"))
			{
				FacebookDelegate<IGraphResult> callback = base.HandleResult;
				FB.API("/me", default(HttpMethod), callback);
			}
			if (Button("Retrieve Profile Photo"))
			{
				FacebookDelegate<IGraphResult> callback2 = ProfilePhotoCallback;
				FB.API("/me/picture", default(HttpMethod), callback2);
			}
			if (Button("Take and Upload screenshot"))
			{
				IEnumerator routine = TakeScreenshot();
				Coroutine coroutine = StartCoroutine(routine);
			}
			LabelAndTextField("Request", ref *(string*)((long)(IntPtr)this + 96L));
			if (Button("Custom Request"))
			{
				FacebookDelegate<IGraphResult> callback3 = base.HandleResult;
				FB.API(apiQuery, default(HttpMethod), callback3);
			}
			if (profilePic != null)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ X21_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v337 @ X21_v11 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				GUILayout.Box(profilePic);
			}
			GUI.enabled = (byte)num2 != 0;
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0xA08BA4", Offset = "0xA08BA4", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = *([1ECC5F0]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, result, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021CAA]) = v43;\nL_001E:\n\tgoto L_0045;\n\tv53 = *([v46 @ X8_v3+B0]);\n\tv54 = 0;\n\tv55 = v53 + 8;\n\tv57 = *([v104 @ X11_v18-8]);\n\tv110 = v57 == v49;\n\tif (v110) goto L_003E;\n\tv90 = v105 + 1;\n\tv168 = v90 < v48;\n\tv84 = ~v168;\n\tv87 = v104 + 0x10;\n\tv60 = ~v84;\n\tif (v60) goto L_FFFFFFFF;\n\tv91 = v16;\n\tv92 = 0;\n\tv93 = 0x8909C4(v91, v49, v92, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0045;\nL_003E:\n\tv169 = *([v104 @ X11_v18]);\n\tv170 = v169 << 4;\n\tv171 = v46 + v170;\n\tv172 = v171 + 0x130;\nL_0045:\n\tv193 = Facebook.Unity.IResult::get_Error(result);\n\tv195 = System.String::IsNullOrEmpty(v193);\n\tv197 = v195 == 0;\n\tif (v197) goto L_00C4;\n\tgoto L_0078;\n\tv247 = *([v199 @ X8_v7+B0]);\n\tv248 = 0;\n\tv249 = v247 + 8;\n\tv251 = *([v287 @ X11_v13-8]);\n\tv293 = v251 == v202;\n\tif (v293) goto L_0071;\n\tv273 = v288 + 1;\n\tv298 = v273 < v201;\n\tv269 = ~v298;\n\tv271 = v287 + 0x10;\n\tv253 = ~v269;\n\tif (v253) goto L_FFFFFFFF;\n\tv274 = v16;\n\tv275 = 0;\n\tv276 = 0x8909C4(v274, v202, v275, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_0078;\nL_0071:\n\tv299 = *([v287 @ X11_v13]);\n\tv300 = v299 << 4;\n\tv301 = v199 + v300;\n\tv302 = v301 + 0x130;\nL_0078:\n\tv310 = Facebook.Unity.IGraphResult::get_Texture(result);\n\tgoto L_008A;\n\tv316 = *([v244 @ X8_v12+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tgoto L_008A;\n\tv323 = v244;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v323, v308, v303, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008A:\n\tv240 = UnityEngine.Object::op_Inequality(v310, 0);\n\tv242 = v240 == 0;\n\tif (v242) goto L_00C4;\n\tgoto L_00B9;\n\tv328 = *([v325 @ X8_v13+B0]);\n\tv329 = 0;\n\tv330 = v328 + 8;\n\tv332 = *([v368 @ X11_v8-8]);\n\tv374 = v332 == v326;\n\tif (v374) goto L_00B2;\n\tv354 = v369 + 1;\n\tv379 = v354 < v327;\n\tv350 = ~v379;\n\tv352 = v368 + 0x10;\n\tv334 = ~v350;\n\tif (v334) goto L_FFFFFFFF;\n\tv355 = v16;\n\tv356 = 0;\n\tv357 = 0x8909C4(v355, v326, v356, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tgoto L_00B9;\nL_00B2:\n\tv380 = *([v368 @ X11_v8]);\n\tv381 = v380 << 4;\n\tv382 = v325 + v381;\n\tv383 = v382 + 0x130;\nL_00B9:\n\tv239 = Facebook.Unity.IGraphResult::get_Texture(result);\n\tthis.profilePic = v239;\nL_00C4:\n\tFacebook.Unity.Example.MenuBase::HandleResult(this, result);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ProfilePhotoCallback(IGraphResult result)
		{
			string error = result.Error;
			if (string.IsNullOrEmpty(error))
			{
				Texture2D texture = result.Texture;
				if (texture != null)
				{
					Texture2D texture2 = result.Texture;
					profilePic = texture2;
				}
			}
			HandleResult(result);
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7DB918", Offset = "0x7DB918")]
		[Token(Token = "0x6000292")]
		[Address(RVA = "0xA08B30", Offset = "0xA08B30", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECA690]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CAB]) = v38;\nL_0016:\n\tv42 = new Facebook.Unity.Example.GraphRequest+<TakeScreenshot>d__4();\n\tSystem.Object::.ctor(v42);\n\tv42.<>1__state = 0;\n\tv42.<>4__this = this;\n\treturn v42;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator TakeScreenshot()
		{
			_003CTakeScreenshot_003Ed__4 _003CTakeScreenshot_003Ed__5 = null;
			_003CTakeScreenshot_003Ed__5._003C_003E1__state = 0;
			_003CTakeScreenshot_003Ed__5._003C_003E4__this = this;
			return _003CTakeScreenshot_003Ed__5;
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0xA09158", Offset = "0xA09158", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EDE340]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CAC]) = v38;\nL_0019:\n\tthis.apiQuery = v43.Empty;\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GraphRequest()
		{
			apiQuery = string.Empty;
		}
	}
}
