using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7311F8", Offset = "0x7311F8")]
	[Token(Token = "0x2000059")]
	public class Giphy : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x200012A")]
		private class UploadSuccessResponse
		{
			[Serializable]
			[Token(Token = "0x20001D7")]
			public class UploadSuccessData
			{
				[Token(Token = "0x4000702")]
				[FieldOffset(Offset = "0x10")]
				public string id;

				[Token(Token = "0x6000D47")]
				[Address(RVA = "0xBF4F10", Offset = "0xBF4F10", Length = "0x58")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED2CC8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EDD]) = v38;\nL_0018:\n\tthis.id = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public UploadSuccessData()
				{
					id = "";
				}
			}

			[Token(Token = "0x4000511")]
			[FieldOffset(Offset = "0x10")]
			public UploadSuccessData data;

			[Token(Token = "0x6000992")]
			[Address(RVA = "0xBF4EAC", Offset = "0xBF4EAC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDECD8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EDC]) = v38;\nL_0016:\n\tv42 = new EasyMobile.Giphy+UploadSuccessResponse+UploadSuccessData();\n\tEasyMobile.Giphy+UploadSuccessResponse+UploadSuccessData::.ctor(v42);\n\tthis.data = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public UploadSuccessResponse()
			{
				UploadSuccessData uploadSuccessData = new UploadSuccessData();
				data = uploadSuccessData;
			}
		}

		[Token(Token = "0x4000219")]
		private static Giphy _instance;

		[Obsolete]
		[Token(Token = "0x400021A")]
		public const string GIPHY_PUBLIC_BETA_KEY = "dc6zaTOxFJmzC";

		[Token(Token = "0x400021B")]
		public const string GIPHY_UPLOAD_PATH = "https://upload.giphy.com/v1/gifs";

		[Token(Token = "0x400021C")]
		public const string GIPHY_BASE_URL = "http://giphy.com/gifs/";

		[Token(Token = "0x400021D")]
		private static int _apiUseCount;

		[Token(Token = "0x17000149")]
		public static Giphy Instance
		{
			[Token(Token = "0x600046C")]
			[Address(RVA = "0xBF41A4", Offset = "0xBF41A4", Length = "0x164")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA8828]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 0 | 1;\n\t*([2022ED2]) = v41;\nL_001A:\n\tgoto L_0029;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v44, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv52 = EasyMobile.Giphy;\nL_0029:\n\tgoto L_0033;\n\tv64 = *([v58 @ X8_v5+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tgoto L_0033;\n\tv75 = v58;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v75, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv74 = UnityEngine.Object::op_Equality(v57._instance, 0);\n\tv77 = v74 == 0;\n\tif (v77) goto L_0068;\n\tv81 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v81, \"Giphy\");\n\tv139 = UnityEngine.GameObject::AddComponent(v81);\n\tgoto L_0056;\n\tv145 = *([v141 @ X8_v17 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_0056;\n\tv158 = v141;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v158, v138, v85, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv152 = EasyMobile.Giphy;\nL_0056:\n\tv153._instance = v139;\n\tgoto L_0063;\n\tv159 = *([v154 @ X0_v20+E0]);\n\tv160 = v159 == 0;\n\tv161 = ~v160;\n\tgoto L_0063;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v154, v138, v85, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0063:\n\tUnityEngine.Object::DontDestroyOnLoad(v81);\nL_0068:\n\tgoto L_0078;\n\tv105 = *([v98 @ X0_v8 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_0078;\n\tv121 = \"il2cpp_codegen_runtime_class_init\"(v98, v86, v84, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv109 = EasyMobile.Giphy;\nL_0078:\n\treturn v112._instance;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 72 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (_instance == null)
				{
					GameObject gameObject = new GameObject("Giphy");
					Giphy instance = gameObject.AddComponent<Giphy>();
					_instance = instance;
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
				return _instance;
			}
		}

		[Token(Token = "0x1700014A")]
		public static bool IsUsingAPI
		{
			[Token(Token = "0x600046D")]
			[Address(RVA = "0xBF4308", Offset = "0xBF4308", Length = "0x70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB5778]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2022ED3]) = v35;\nL_0017:\n\tgoto L_0025;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0025;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = EasyMobile.Giphy;\nL_0025:\n\tv56 = v49._apiUseCount < 0;\n\tv57 = v49._apiUseCount == 0;\n\tv59 = v49._apiUseCount ^ v49._apiUseCount;\n\tv60 = v49._apiUseCount & v59;\n\tv61 = v60 < 0;\n\tv62 = v56 == v61;\n\tv63 = ~v57;\n\tv64 = v62 & v63;\n\treturn v64;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = _apiUseCount < 0;
				bool flag2 = _apiUseCount == 0;
				int num = _apiUseCount ^ _apiUseCount;
				int num2 = _apiUseCount & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Obsolete]
		[Token(Token = "0x600046E")]
		[Address(RVA = "0xBF4378", Offset = "0xBF4378", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EE1E48]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2022ED4]) = v47;\nL_001E:\n\tv53 = content.localImagePath;\n\tgoto L_003B;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_003B;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback, methodInfo, v34, v35, v36, v53, v38, v39, v40, v41, v42, v43, v44);\nL_003B:\n\tEasyMobile.Giphy::Upload(\"\", \"dc6zaTOxFJmzC\", &v53 @ V0_v2 (System.String), uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Upload(GiphyUploadParams content, Action<float> uploadProgressCallback, Action<string> uploadCompletedCallback, Action<string> uploadFailedCallback)
		{
			//IL_0024: Expected O, but got Ref
			string localImagePath = content.localImagePath;
			Upload("", "dc6zaTOxFJmzC", (GiphyUploadParams)(&localImagePath), uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback);
		}

		[Token(Token = "0x600046F")]
		[Address(RVA = "0xBF4450", Offset = "0xBF4450", Length = "0x32C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv40 = *([1EF2E40]);\n\tv41 = *([v40 @ X8_v58]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, apiKey, content, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2022ED5]) = v55;\nL_0020:\n\tv58 = System.String::IsNullOrEmpty(content.localImagePath);\n\tv60 = v58 == 0;\n\tif (v60) goto L_003B;\n\tv63 = System.String::IsNullOrEmpty(content.sourceImageUrl);\n\tv67 = v63 == 0;\n\tif (v67) goto L_003B;\n\tgoto L_FFFFFFFF;\n\tv91 = *([v77 @ X0_v61+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_FFFFFFFF;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v77, v62, content, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0106;\nL_003B:\n\tv70 = System.String::IsNullOrEmpty(content.localImagePath);\n\tv73 = v70 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_0048;\n\tv83 = System.IO.File::Exists(content.localImagePath);\n\tv87 = v83 == 0;\n\tif (v87) goto L_00F1;\nL_0048:\n\tv90 = System.String::IsNullOrEmpty(apiKey);\n\tv105 = v90 == 0;\n\tif (v105) goto L_005A;\n\tv149 = v134.Empty;\n\tgoto L_005E;\nL_005A:\n\tv141 = System.String::Concat(\"?api_key=\", apiKey);\nL_005E:\n\tv155 = System.String::Concat(\"https://upload.giphy.com/v1/gifs\", v149);\n\tv208 = new UnityEngine.WWWForm();\n\tUnityEngine.WWWForm::.ctor(v208);\n\tUnityEngine.WWWForm::AddField(v208, \"api_key\", apiKey);\n\tUnityEngine.WWWForm::AddField(v208, \"username\", username);\n\tv230 = System.String::IsNullOrEmpty(content.localImagePath);\n\tv232 = v230 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0091;\n\tv236 = System.IO.File::Exists(content.localImagePath);\n\tv246 = v236 == 0;\n\tif (v246) goto L_0091;\n\tv258 = System.IO.File::ReadAllBytes(content.localImagePath);\n\tUnityEngine.WWWForm::AddBinaryData(v208, \"file\", v258);\nL_0091:\n\tv251 = System.String::IsNullOrEmpty(content.sourceImageUrl);\n\tv254 = v251 == 0;\n\tv255 = ~v254;\n\tif (v255) goto L_009F;\n\tUnityEngine.WWWForm::AddField(v208, \"source_image_url\", content.sourceImageUrl);\nL_009F:\n\tv272 = System.String::IsNullOrEmpty(content.tags);\n\tv275 = v272 == 0;\n\tv276 = ~v275;\n\tif (v276) goto L_00AD;\n\tUnityEngine.WWWForm::AddField(v208, \"tags\", content.tags);\nL_00AD:\n\tv290 = System.String::IsNullOrEmpty(content.sourcePostUrl);\n\tv292 = v290 == 0;\n\tv293 = ~v292;\n\tif (v293) goto L_00BA;\n\tUnityEngine.WWWForm::AddField(v208, \"source_post_url\", content.sourcePostUrl);\nL_00BA:\n\tv306 = ~content.isHidden;\n\tif (v306) goto L_00CB;\n\tUnityEngine.WWWForm::AddField(v208, \"is_hidden\", \"true\");\nL_00CB:\n\tgoto L_00D1;\n\tv326 = *([v322 @ X0_v35 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_00D1;\n\tv330 = \"il2cpp_codegen_runtime_class_init\"(v322, v317, v316, v315, uploadCompletedCallback, uploadFailedCallback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00D1:\n\tv332 = EasyMobile.Giphy::get_Instance();\n\tv219 = EasyMobile.Giphy::CRUpload(v155, v208, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback);\n\tv178 = UnityEngine.MonoBehaviour::StartCoroutine(v332, v219);\n\treturn;\nL_00F1:\n\tgoto L_FFFFFFFF;\n\tv142 = *([v127 @ X0_v56+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_FFFFFFFF;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v127, v82, content, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0106:\n\tUnityEngine.Debug::LogError(*([v111 @ X8_v3 (System.String)]));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 183 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Upload(string username, string apiKey, GiphyUploadParams content, Action<float> uploadProgressCallback, Action<string> uploadCompletedCallback, Action<string> uploadFailedCallback)
		{
			string message;
			if (string.IsNullOrEmpty(content.localImagePath) && string.IsNullOrEmpty(content.sourceImageUrl))
			{
				message = "UploadToGiphy FAILED: no image was specified for uploading.";
			}
			else
			{
				if (string.IsNullOrEmpty(content.localImagePath) || File.Exists(content.localImagePath))
				{
					string text;
					if (string.IsNullOrEmpty(apiKey))
					{
						text = string.Empty;
					}
					else
					{
						string text2 = "?api_key=" + apiKey;
						text = text2;
					}
					string uploadPath = "https://upload.giphy.com/v1/gifs" + text;
					WWWForm wWWForm = new WWWForm();
					wWWForm.AddField("api_key", apiKey);
					wWWForm.AddField("username", username);
					if (!string.IsNullOrEmpty(content.localImagePath) && File.Exists(content.localImagePath))
					{
						byte[] contents = File.ReadAllBytes(content.localImagePath);
						wWWForm.AddBinaryData("file", contents);
					}
					if (!string.IsNullOrEmpty(content.sourceImageUrl))
					{
						wWWForm.AddField("source_image_url", content.sourceImageUrl);
					}
					if (!string.IsNullOrEmpty(content.tags))
					{
						wWWForm.AddField("tags", content.tags);
					}
					if (!string.IsNullOrEmpty(content.sourcePostUrl))
					{
						wWWForm.AddField("source_post_url", content.sourcePostUrl);
					}
					if (content.isHidden)
					{
						wWWForm.AddField("is_hidden", "true");
					}
					Giphy instance = Instance;
					IEnumerator routine = CRUpload(uploadPath, wWWForm, uploadProgressCallback, uploadCompletedCallback, uploadFailedCallback);
					Coroutine coroutine = instance.StartCoroutine(routine);
					return;
				}
				message = "UploadToGiphy FAILED: (local) file not found.";
			}
			Debug.LogError(message);
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7348C8", Offset = "0x7348C8")]
		[Token(Token = "0x6000470")]
		[Address(RVA = "0xBF4784", Offset = "0xBF4784", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1EBC7D0]);\n\tv35 = *([v34 @ X8_v6]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, form, uploadProgressCB, uploadCompletedCB, uploadFailedCB, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022ED6]) = v50;\nL_001E:\n\tv54 = new EasyMobile.Giphy+<CRUpload>d__12();\n\tSystem.Object::.ctor(v54);\n\tv54.<>1__state = 0;\n\tv54.uploadPath = uploadPath;\n\tv54.form = form;\n\tv54.uploadProgressCB = uploadProgressCB;\n\tv54.uploadCompletedCB = uploadCompletedCB;\n\tv54.uploadFailedCB = uploadFailedCB;\n\treturn v54;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static IEnumerator CRUpload(string uploadPath, WWWForm form, Action<float> uploadProgressCB, Action<string> uploadCompletedCB, Action<string> uploadFailedCB)
		{
			_003CCRUpload_003Ed__12 _003CCRUpload_003Ed__13 = null;
			_003CCRUpload_003Ed__13._003C_003E1__state = 0;
			_003CCRUpload_003Ed__13.uploadPath = uploadPath;
			_003CCRUpload_003Ed__13.form = form;
			_003CCRUpload_003Ed__13.uploadProgressCB = uploadProgressCB;
			_003CCRUpload_003Ed__13.uploadCompletedCB = uploadCompletedCB;
			_003CCRUpload_003Ed__13.uploadFailedCB = uploadFailedCB;
			return _003CCRUpload_003Ed__13;
		}

		[Token(Token = "0x6000471")]
		[Address(RVA = "0xBF484C", Offset = "0xBF484C", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EC8350]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022ED7]) = v42;\nL_001B:\n\tgoto L_002A;\n\tv49 = *([v45 @ X0_v2 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = EasyMobile.Giphy;\nL_002A:\n\tgoto L_0034;\n\tv65 = *([v59 @ X8_v5+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0034;\n\tv76 = v59;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v76, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0034:\n\tv75 = UnityEngine.Object::op_Equality(v58._instance, 0);\n\tv78 = v75 == 0;\n\tif (v78) goto L_0061;\n\tgoto L_0046;\n\tv86 = *([v79 @ X0_v13 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0046;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v79, v73, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv90 = EasyMobile.Giphy;\nL_0046:\n\tv93._instance = this;\n\tv96 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_005D;\n\tv123 = *([v103 @ X8_v10+E0]);\n\tv124 = v123 == 0;\n\tv125 = ~v124;\n\tgoto L_005D;\n\tv139 = v103;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v139, v95, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005D:\n\tUnityEngine.Object::DontDestroyOnLoad(v96);\n\treturn;\nL_0061:\n\tv85 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0077;\n\tv108 = *([v97 @ X8_v6+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0077;\n\tv138 = v97;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v138, v84, v74, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0077:\n\tUnityEngine.Object::Destroy(v85);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
			else
			{
				GameObject obj = base.gameObject;
				UnityEngine.Object.Destroy(obj);
			}
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0xBF4994", Offset = "0xBF4994", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EEF9A0]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022ED8]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = EasyMobile.Giphy;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(this, v56._instance);\n\tv76 = v73 == 0;\n\tif (v76) goto L_004A;\n\tgoto L_0043;\n\tv92 = *([v77 @ X0_v8 (Il2CppClass<EasyMobile.Giphy>)+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v77, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv95 = EasyMobile.Giphy;\nL_0043:\n\tv86._instance = 0;\nL_004A:\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (this == _instance)
			{
				_instance = null;
			}
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0xBF4A64", Offset = "0xBF4A64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Giphy()
		{
		}
	}
}
