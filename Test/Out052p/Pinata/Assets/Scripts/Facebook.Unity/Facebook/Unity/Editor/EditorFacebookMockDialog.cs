using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000057")]
	internal abstract class EditorFacebookMockDialog : MonoBehaviour
	{
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x18")]
		private Rect modalRect;

		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x28")]
		private GUIStyle modalStyle;

		[CompilerGenerated]
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x30")]
		internal Utilities.Callback<ResultContainer> _003CCallback_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x38")]
		internal string _003CCallbackID_003Ek__BackingField;

		[Token(Token = "0x17000074")]
		public Utilities.Callback<ResultContainer> Callback
		{
			[CompilerGenerated]
			[Token(Token = "0x600020A")]
			[Address(RVA = "0xD28188", Offset = "0xD28188", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Callback>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected get
			{
				return _003CCallback_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x600020B")]
			[Address(RVA = "0xD28190", Offset = "0xD28190", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Callback>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Callback = value;
			}
		}

		[Token(Token = "0x17000075")]
		public string CallbackID
		{
			[CompilerGenerated]
			[Token(Token = "0x600020C")]
			[Address(RVA = "0xD28198", Offset = "0xD28198", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CallbackID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			protected get
			{
				return _003CCallbackID_003Ek__BackingField;
			}
			[CompilerGenerated]
			[Token(Token = "0x600020D")]
			[Address(RVA = "0xD281A0", Offset = "0xD281A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CallbackID>k__BackingField = value;\n\treturn;\n")]
			set
			{
				CallbackID = value;
			}
		}

		[Token(Token = "0x17000076")]
		protected abstract string DialogTitle
		{
			[Token(Token = "0x600020E")]
			get;
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0xD281A8", Offset = "0xD281A8", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EC72E0]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BD2]) = v40;\nL_0015:\n\tv42 = UnityEngine.Screen::get_width();\n\tv45 = UnityEngine.Screen::get_height();\n\tv46 = v42 - 0x14;\n\tv47 = v45 - 0x14;\n\tv52 = 0;\n\tv56 = 0x10CCF64(&v52 @ stack_-40_v1 (System.Single), 0, v24, v25, v26, v27, v28, v29, 10f, 10f, v46, v47, v34, v35, v36, v37);\n\tthis.modalRect.m_XMin = 0f;\n\tthis.modalRect.m_YMin = v59;\n\tthis.modalRect.m_Height = v61;\n\tv65 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v65, 1, 1);\n\tv74 = 0;\n\tv79 = 0x101059C(&v74 @ stack_-50_v1, 0, 1, 0, v26, v27, v28, v29, 0.2f, 0.2f, 0.2f, 1f, v34, v35, v36, v37);\n\t// 71 MakeStruct v91 @ AGGD2829C_3_v3 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v83 @ stack_-4C, 0, v86 @ stack_-44\n\tUnityEngine.Texture2D::SetPixel(v65, 0, 0, v91);\n\tUnityEngine.Texture2D::Apply(v65);\n\tv105 = new UnityEngine.GUIStyle();\n\tUnityEngine.GUIStyle::.ctor(v105);\n\tthis.modalStyle = v105;\n\tv124 = UnityEngine.GUIStyle::get_normal(v105);\n\tUnityEngine.GUIStyleState::set_background(v124, v65);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Start()
		{
			//IL_0024: Expected F4, but got O
			//IL_0055: Expected O, but got I4
			//IL_007f: Expected F4, but got O
			//IL_009a: Expected F4, but got O
			int width = Screen.width;
			int height = Screen.height;
			int num = width - 20;
			int num2 = height - 20;
			float num3 = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			modalRect.x = 0f;
			object obj = default(object);
			modalRect.y = (float)obj;
			float height2 = default(float);
			modalRect.height = height2;
			Texture2D texture2D = new Texture2D(1, 1);
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color color = default(Color);
			color.r = 0f;
			object obj3 = default(object);
			color.g = (float)obj3;
			color.b = 0f;
			object obj4 = default(object);
			color.a = (float)obj4;
			texture2D.SetPixel(0, 0, color);
			texture2D.Apply();
			GUIStyleState normal = (modalStyle = new GUIStyle()).normal;
			normal.background = texture2D;
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0xD28308", Offset = "0xD28308", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1EEC810]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2023BD3]) = v50;\nL_001D:\n\tv55 = UnityEngine.Object::GetHashCode(this);\n\tv65 = new UnityEngine.GUI+WindowFunction();\n\tUnityEngine.GUI+WindowFunction::.ctor(v65, this, Il2CppMethodInfo);\n\tv76 = Facebook.Unity.Editor.EditorFacebookMockDialog::get_DialogTitle(this);\n\tgoto L_0057;\n\tv85 = *([v81 @ X8_v12+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0057;\n\tv113 = v81;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v113, v75, v71, v69, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0057:\n\t// 87 MakeStruct v111 @ AGGD28408_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), this.modalRect (UnityEngine.Rect), this.modalRect.m_YMin (System.Single), this.modalRect.m_Width (System.Single), this.modalRect.m_Height (System.Single)\n\tv112 = UnityEngine.GUI::ModalWindow(v55, v111, v65, v76, this.modalStyle);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnGUI()
		{
			int hashCode = GetHashCode();
			GUI.WindowFunction func = OnGUIDialog;
			string dialogTitle = DialogTitle;
			Rect clientRect = default(Rect);
			clientRect.x = modalRect.x;
			clientRect.y = modalRect.y;
			clientRect.width = modalRect.width;
			clientRect.height = modalRect.height;
			Rect rect = GUI.ModalWindow(hashCode, clientRect, func, dialogTitle, modalStyle);
		}

		[Token(Token = "0x6000211")]
		protected abstract void DoGui();

		[Token(Token = "0x6000212")]
		protected abstract void SendSuccessResult();

		[Token(Token = "0x6000213")]
		[Address(RVA = "0xD2840C", Offset = "0xD2840C", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EFED40]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023BD4]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tv54 = 1;\n\t// 35 Box v55 @ X0_v5 (System.Object), typeof(System.Boolean), &v54 @ X8_v9 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"cancelled\", v55);\n\tv87 = System.String::IsNullOrEmpty(this.<CallbackID>k__BackingField);\n\tv89 = v87 == 0;\n\tv90 = ~v89;\n\tif (v90) goto L_003F;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v44, \"callback_id\", this.<CallbackID>k__BackingField);\nL_003F:\n\tv121 = Facebook.Unity.Utilities::ToJson(v44);\n\tv74 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v74, v121);\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::Invoke(this.<Callback>k__BackingField, v74);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SendCancelResult()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			int num = 1;
			object value = (byte)num != 0;
			dictionary.set_Item("cancelled", value);
			if (!string.IsNullOrEmpty(CallbackID))
			{
				dictionary.set_Item("callback_id", (object)CallbackID);
			}
			string result = dictionary.ToJson();
			ResultContainer obj = new ResultContainer(result);
			Callback(obj);
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0xD2853C", Offset = "0xD2853C", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EAFDC0]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, errorMessage, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023BD5]) = v43;\nL_0019:\n\tv47 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v47);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v47, \"error\", errorMessage);\n\tv84 = System.String::IsNullOrEmpty(this.<CallbackID>k__BackingField);\n\tv86 = v84 == 0;\n\tv87 = ~v86;\n\tif (v87) goto L_003A;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::set_Item(v47, \"callback_id\", this.<CallbackID>k__BackingField);\nL_003A:\n\tv120 = Facebook.Unity.Utilities::ToJson(v47);\n\tv69 = new Facebook.Unity.ResultContainer();\n\tFacebook.Unity.ResultContainer::.ctor(v69, v120);\n\tFacebook.Unity.Utilities+Callback`1<Facebook.Unity.ResultContainer>::Invoke(this.<Callback>k__BackingField, v69);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal virtual void SendErrorResult(string errorMessage)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.set_Item("error", (object)errorMessage);
			if (!string.IsNullOrEmpty(CallbackID))
			{
				dictionary.set_Item("callback_id", (object)CallbackID);
			}
			string result = dictionary.ToJson();
			ResultContainer obj = new ResultContainer(result);
			Callback(obj);
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0xD28650", Offset = "0xD28650", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1EFFCE0]);\n\tv35 = *([v34 @ X8_v52]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, windowId, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023BD6]) = v54;\nL_001D:\n\tUnityEngine.GUILayout::Space(10f);\n\t// 34 NewArr v61 @ X0_v4 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::BeginVertical(v61);\n\t// 39 NewArr v65 @ X0_v6 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::Label(\"Warning! Mock dialog responses will NOT match production dialogs\", v65);\n\t// 49 NewArr v74 @ X0_v9 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::Label(\"Test your app on one of the supported platforms\", v74);\n\tv85 = Facebook.Unity.Editor.EditorFacebookMockDialog::DoGui(this);\n\tUnityEngine.GUILayout::EndVertical();\n\t// 66 NewArr v89 @ X0_v15 (UnityEngine.GUILayoutOption[]), typeof(UnityEngine.GUILayoutOption[]), 0\n\tUnityEngine.GUILayout::BeginHorizontal(v89);\n\tUnityEngine.GUILayout::FlexibleSpace();\n\tv95 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v95, \"Send Success\");\n\tgoto L_005E;\n\tv107 = *([v103 @ X0_v19+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_005E;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v103, v100, v98, v39, v40, v41, v42, v43, v55, v45, v46, v47, v48, v49, v50, v51);\nL_005E:\n\tv115 = UnityEngine.GUI::get_skin();\n\tv118 = UnityEngine.GUISkin::get_button(v115);\n\tgoto L_0074;\n\tv203 = *([v199 @ X8_v15+E0]);\n\tv204 = v203 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_0074;\n\tv262 = v199;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v262, v117, v98, v39, v40, v41, v42, v43, v55, v45, v46, v47, v48, v49, v50, v51);\nL_0074:\n\tv153 = UnityEngine.GUILayoutUtility::GetRect(v95, v118);\n\tv265 = UnityEngine.GUI::Button(v153, v95);\n\tv267 = v265 == 0;\n\tif (v267) goto L_0094;\n\tv272 = Facebook.Unity.Editor.EditorFacebookMockDialog::SendSuccessResult(this);\n\tgoto L_0092;\n\tv289 = *([v275 @ X0_v82+E0]);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_0092;\n\tv293 = \"il2cpp_codegen_runtime_class_init\"(v275, v271, v212, v39, v40, v41, v42, v43, v153, v148, v143, v138, v48, v49, v50, v51);\nL_0092:\n\tUnityEngine.Object::Destroy(this);\nL_0094:\n\tv288 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v288, \"Send Cancel\");\n\tgoto L_00A6;\n\tv300 = *([v296 @ X0_v33+E0]);\n\tv301 = v300 == 0;\n\tv302 = ~v301;\n\tif (v302) goto L_00A6;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v296, v176, v171, v39, v40, v41, v42, v43, v153, v148, v143, v138, v48, v49, v50, v51);\nL_00A6:\n\tv181 = UnityEngine.GUI::get_skin();\n\tv308 = UnityEngine.GUISkin::get_button(v181);\n\tgoto L_00BA;\n\tv312 = *([v192 @ X8_v21+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_00BA;\n\tv319 = v192;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v319, v307, v171, v39, v40, v41, v42, v43, v153, v148, v143, v138, v48, v49, v50, v51);\nL_00BA:\n\tv154 = UnityEngine.GUILayoutUtility::GetRect(v288, v308);\n\tv182 = UnityEngine.GUI::get_skin();\n\tv322 = UnityEngine.GUISkin::get_button(v182);\n\tv326 = UnityEngine.GUI::Button(v154, v288, v322);\n\tv328 = v326 == 0;\n\tif (v328) goto L_00E9;\n\tv333 = Facebook.Unity.Editor.EditorFacebookMockDialog::SendCancelResult(this);\n\tgoto L_00E7;\n\tv350 = *([v336 @ X0_v73+E0]);\n\tv351 = v350 == 0;\n\tv352 = ~v351;\n\tif (v352) goto L_00E7;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v336, v332, v325, v39, v40, v41, v42, v43, v155, v150, v145, v140, v48, v49, v50, v51);\nL_00E7:\n\tUnityEngine.Object::Destroy(this);\nL_00E9:\n\tv349 = new UnityEngine.GUIContent();\n\tUnityEngine.GUIContent::.ctor(v349, \"Send Error\");\n\tgoto L_00FB;\n\tv361 = *([v357 @ X0_v48+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_00FB;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v357, v178, v173, v39, v40, v41, v42, v43, v155, v150, v145, v140, v48, v49, v50, v51);\nL_00FB:\n\tv183 = UnityEngine.GUI::get_skin();\n\tv369 = UnityEngine.GUISkin::get_button(v183);\n\tgoto L_010F;\n\tv373 = *([v194 @ X8_v27+E0]);\n\tv374 = v373 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_010F;\n\tv380 = v194;\n\tv377 = \"il2cpp_codegen_runtime_class_init\"(v380, v368, v173, v39, v40, v41, v42, v43, v155, v150, v145, v140, v48, v49, v50, v51);\nL_010F:\n\tv156 = UnityEngine.GUILayoutUtility::GetRect(v288, v369);\n\tv184 = UnityEngine.GUI::get_skin();\n\tv383 = UnityEngine.GUISkin::get_button(v184);\n\tv387 = UnityEngine.GUI::Button(v156, v349, v383);\n\tv389 = v387 == 0;\n\tif (v389) goto L_014E;\n\tv397 = Facebook.Unity.Editor.EditorFacebookMockDialog::SendErrorResult(this, \"Error: Error button pressed\");\n\tgoto L_013F;\n\tv409 = *([v400 @ X0_v64+E0]);\n\tv410 = v409 == 0;\n\tv411 = ~v410;\n\tif (v411) goto L_013F;\n\tv413 = \"il2cpp_codegen_runtime_class_init\"(v400, v394, v396, v39, v40, v41, v42, v43, v235, v233, v231, v229, v48, v49, v50, v51);\nL_013F:\n\tUnityEngine.Object::Destroy(this);\nL_014E:\n\tUnityEngine.GUILayout::EndHorizontal();\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 225 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnGUIDialog(int windowId)
		{
			GUILayout.Space(10f);
			GUILayoutOption[] options = new GUILayoutOption[0];
			GUILayout.BeginVertical(options);
			GUILayoutOption[] options2 = new GUILayoutOption[0];
			GUILayout.Label("Warning! Mock dialog responses will NOT match production dialogs", options2);
			GUILayoutOption[] options3 = new GUILayoutOption[0];
			GUILayout.Label("Test your app on one of the supported platforms", options3);
			DoGui();
			GUILayout.EndVertical();
			GUILayoutOption[] options4 = new GUILayoutOption[0];
			GUILayout.BeginHorizontal(options4);
			GUILayout.FlexibleSpace();
			GUIContent content = new GUIContent("Send Success");
			GUISkin skin = GUI.skin;
			GUIStyle button = skin.button;
			Rect rect = GUILayoutUtility.GetRect(content, button);
			if (GUI.Button(rect, content))
			{
				SendSuccessResult();
				Object.Destroy(this);
			}
			GUIContent content2 = new GUIContent("Send Cancel");
			GUISkin skin2 = GUI.skin;
			GUIStyle button2 = skin2.button;
			Rect rect2 = GUILayoutUtility.GetRect(content2, button2);
			GUISkin skin3 = GUI.skin;
			GUIStyle button3 = skin3.button;
			if (GUI.Button(rect2, content2, button3))
			{
				SendCancelResult();
				Object.Destroy(this);
			}
			GUIContent content3 = new GUIContent("Send Error");
			GUISkin skin4 = GUI.skin;
			GUIStyle button4 = skin4.button;
			Rect rect3 = GUILayoutUtility.GetRect(content2, button4);
			GUISkin skin5 = GUI.skin;
			GUIStyle button5 = skin5.button;
			if (GUI.Button(rect3, content3, button5))
			{
				SendErrorResult("Error: Error button pressed");
				Object.Destroy(this);
			}
			GUILayout.EndHorizontal();
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0xD258BC", Offset = "0xD258BC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal EditorFacebookMockDialog()
		{
		}
	}
}
