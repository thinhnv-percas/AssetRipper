using System;
using System.Collections;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Facebook.Unity
{
	[Token(Token = "0x2000046")]
	public class CodelessCrawler : MonoBehaviour
	{
		[Token(Token = "0x4000077")]
		private static bool isGeneratingSnapshot;

		[Token(Token = "0x4000078")]
		private static Camera mainCamera;

		[Token(Token = "0x6000173")]
		[Address(RVA = "0xD22418", Offset = "0xD22418", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1F08340]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B8E]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>::.ctor(v42, this, Il2CppMethodInfo);\n\tUnityEngine.SceneManagement.SceneManager::add_activeSceneChanged(v42);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Awake()
		{
			UnityAction<Scene, Scene> value = onActiveSceneChanged;
			SceneManager.activeSceneChanged += value;
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0xD22494", Offset = "0xD22494", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1ED36E0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023B8F]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0029;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v43, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Facebook.Unity.CodelessCrawler;\nL_0029:\n\tgoto L_0033;\n\tv63 = *([v57 @ X8_v7+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tgoto L_0033;\n\tv74 = v57;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v74, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0033:\n\tv73 = UnityEngine.Object::op_Equality(0, v56.mainCamera);\n\tv76 = v73 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0051;\n\tgoto L_0048;\n\tv94 = *([v78 @ X0_v15 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\t// 64 ConditionalJump @b29, v96 @ TEMP_v28\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v78, v71, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = Facebook.Unity.CodelessCrawler;\nL_0048:\n\tv85 = UnityEngine.Behaviour::get_isActiveAndEnabled(v89.mainCamera);\n\tv118 = v85 == 0;\n\tv87 = ~v118;\n\tif (v87) goto L_0058;\nL_0051:\n\tgoto L_0057;\n\tv103 = *([v90 @ X0_v12 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0057;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v90, v82, v72, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0057:\n\tFacebook.Unity.CodelessCrawler::updateMainCamera();\nL_0058:\n\tv116 = Facebook.Unity.CodelessCrawler::GenSnapshot(v113);\n\tv127 = UnityEngine.MonoBehaviour::StartCoroutine(this, v116);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CaptureViewHierarchy(string message)
		{
			//IL_0074: Expected O, but got I4
			CodelessCrawler codelessCrawler;
			if (!(null == mainCamera))
			{
				bool flag = mainCamera.isActiveAndEnabled;
				bool flag2 = !flag;
				bool flag3 = !flag2;
				codelessCrawler = (CodelessCrawler)flag;
				if (flag3)
				{
					goto IL_00a0;
				}
			}
			updateMainCamera();
			codelessCrawler = (CodelessCrawler)(object)typeof(CodelessCrawler);
			goto IL_00a0;
			IL_00a0:
			IEnumerator routine = codelessCrawler.GenSnapshot();
			Coroutine coroutine = StartCoroutine(routine);
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xD2261C", Offset = "0xD2261C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EC77F8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023B90]) = v35;\nL_0014:\n\tv39 = new Facebook.Unity.CodelessCrawler+<GenSnapshot>d__4();\n\tSystem.Object::.ctor(v39);\n\tv39.<>1__state = 0;\n\treturn v39;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator GenSnapshot()
		{
			int num = default(int);
			if (num != 0)
			{
				yield break;
			}
			yield return new WaitForEndOfFrame();
			if (!isGeneratingSnapshot)
			{
				isGeneratingSnapshot = true;
				StringBuilder stringBuilder = new StringBuilder();
				string arg = GenBase64Screenshot();
				stringBuilder.AppendFormat("{{\"screenshot\":\"{0}\",", arg);
				SceneManager.GetActiveScene();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
				object arg2 = default(object);
				stringBuilder.AppendFormat("\"screenname\":\"{0}\",", arg2);
				string arg3 = GenViewJson();
				stringBuilder.AppendFormat("\"view\":[{0}]}}", arg3);
				string json = stringBuilder.ToString();
				FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
				if (currentPlatform != FacebookUnityPlatform.IOS && currentPlatform == FacebookUnityPlatform.Android)
				{
					SendAndroid(json);
				}
				isGeneratingSnapshot = false;
			}
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0xD226A8", Offset = "0xD226A8", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EDBC20]);\n\tv21 = *([v20 @ X8_v27]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023B91]) = v40;\nL_0017:\n\tv44 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v44, \"com.facebook.appevents.codeless.ViewIndexer\");\n\t// 34 NewArr v54 @ X0_v5 (System.Object[]), typeof(System.Object[]), 1\n\tv57 = json == 0;\n\tif (v57) goto L_002F;\n\t// 43 IsInst v63 @ X0_v35, typeof(System.Object), json @ X0 (System.String)\n\tv67 = v63 == 0;\n\tif (v67) goto L_0084;\nL_002F:\n\tv70 = v54.Length == 0;\n\tif (v70) goto L_007E;\n\tv54[0] = json;\n\tUnityEngine.AndroidJavaObject::CallStatic(v44, \"sendToServerUnityInstance\", v54);\nL_0043:\n\tgoto L_006A;\n\tv207 = *([v202 @ X8_v10+B0]);\n\tv208 = 0;\n\tv209 = v207 + 8;\n\tv211 = *([v249 @ X11_v6-8]);\n\tv254 = v211 == v205;\n\tif (v254) goto L_0063;\n\tv231 = v248 + 1;\n\tv261 = v231 < v204;\n\tv229 = ~v261;\n\tv233 = v249 + 0x10;\n\tv213 = ~v229;\n\tif (v213) goto L_FFFFFFFF;\n\tv234 = v48;\n\tv235 = 0;\n\tv236 = 0x8909C4(v234, v205, v235, v189, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006A;\nL_0063:\n\tv262 = *([v249 @ X11_v6]);\n\tv263 = v262 << 4;\n\tv264 = v202 + v263;\n\tv265 = v264 + 0x130;\nL_006A:\n\tSystem.IDisposable::Dispose(v44);\n\tv287 = v190 + 1;\n\tv289 = v287 == 0;\n\tv292 = ~v289;\n\tif (v292) goto L_007B;\nL_0072:\n\tv294 = v159 == 0;\n\tv157 = ~v294;\n\tif (v157) goto L_008B;\nL_007B:\n\treturn;\n\tv59 = new System.NullReferenceException();\nL_007E:\n\tv75 = new System.IndexOutOfRangeException();\n\tthrow v75;\n\tv85 = new System.NullReferenceException();\nL_0084:\n\tv90 = new System.ArrayTypeMismatchException();\n\tthrow v90;\nL_008B:\n\tv165 = new System.TypeLoadException();\n\tgoto L_0097;\nL_0097:\n\tgoto L_009F;\n\tv259 = 0x6D2BC0(v165, 0, 0, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv159 = *([v259 @ X0_v17]);\n\tv195 = 0x6D2490(v259, 0, 0, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv197 = v44 == 0;\n\tif (v197) goto L_0072;\n\tgoto L_0043;\nL_009F:\n\tv260 = 0x6D2380(v165, 0, 0, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SendAndroid(string json)
		{
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.facebook.appevents.codeless.ViewIndexer");
			object[] array = new object[1];
			if (json != null)
			{
				object obj = json as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
			}
			if (array.Length != 0)
			{
				array[0] = json;
				androidJavaClass.CallStatic("sendToServerUnityInstance", array);
				int num = 0;
				int num2 = 0;
				((IDisposable)androidJavaClass).Dispose();
				if (num + 1 == 0 && num2 != 0)
				{
					TypeLoadException ex2 = new TypeLoadException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				}
				return;
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			throw ex3;
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0xD2285C", Offset = "0xD2285C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		private static void SendIos(string json)
		{
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0xD22860", Offset = "0xD22860", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED4A78]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2023B92]) = v39;\nL_0014:\n\tv41 = UnityEngine.Screen::get_width();\n\tv44 = UnityEngine.Screen::get_height();\n\tv50 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v50, v41, v44);\n\tv56 = UnityEngine.Screen::get_width();\n\tv59 = UnityEngine.Screen::get_height();\n\tv63 = 0;\n\tv68 = 0x10CCF64(&v63 @ stack_-40_v1, 0, v44, 0, v24, v25, v26, v27, 0, 0, v56, v59, v32, v33, v34, v35);\n\t// 59 MakeStruct v80 @ AGGD22928_1_v1 (UnityEngine.Rect), typeof(UnityEngine.Rect), 0, v72 @ stack_-3C, 0, v75 @ stack_-34\n\tUnityEngine.Texture2D::ReadPixels(v50, v80, 0, 0);\n\tUnityEngine.Texture2D::Apply(v50);\n\tv87 = UnityEngine.ImageConversion::EncodeToJPG(v50);\n\tgoto L_0053;\n\tv124 = *([v120 @ X8_v8+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_0053;\n\tv134 = v120;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v134, v86, v78, v79, v24, v25, v26, v27, v70, v71, v73, v74, v32, v33, v34, v35);\nL_0053:\n\tv133 = System.Convert::ToBase64String(v87);\n\tgoto L_0064;\n\tv141 = *([v112 @ X8_v11+E0]);\n\tv142 = v141 == 0;\n\tv143 = ~v142;\n\tif (v143) goto L_0064;\n\tv147 = v112;\n\tv145 = \"il2cpp_codegen_runtime_class_init\"(v147, v132, v78, v79, v24, v25, v26, v27, v70, v71, v73, v74, v32, v33, v34, v35);\nL_0064:\n\tUnityEngine.Object::Destroy(v50);\n\treturn v133;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GenBase64Screenshot()
		{
			//IL_0025: Expected O, but got I4
			//IL_004f: Expected F4, but got O
			//IL_006a: Expected F4, but got O
			int width = Screen.width;
			int height = Screen.height;
			Texture2D texture2D = new Texture2D(width, height);
			int width2 = Screen.width;
			int height2 = Screen.height;
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Rect source = default(Rect);
			source.x = 0f;
			object obj2 = default(object);
			source.y = (float)obj2;
			source.width = 0f;
			object obj3 = default(object);
			source.height = (float)obj3;
			texture2D.ReadPixels(source, 0, 0);
			texture2D.Apply();
			byte[] inArray = texture2D.EncodeToJPG();
			string result = Convert.ToBase64String(inArray);
			UnityEngine.Object.Destroy(texture2D);
			return result;
		}

		[Token(Token = "0x6000179")]
		[Address(RVA = "0xD229CC", Offset = "0xD229CC", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB3660]);\n\tv25 = *([v24 @ X8_v56]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 0 | 1;\n\t*([2023B93]) = v45;\nL_0017:\n\tv47 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv47 = 0x10D468C(&v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv57 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v57);\n\tv47 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv65 = 0x10D454C(&v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), 0, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv73 = System.Text.StringBuilder::AppendFormat(v57, \"{{\\\"classname\\\":\\\"{0}\\\",\\\"childviews\\\":[\", v65);\n\tv147 = *([v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)+18]) < 1;\n\tif (v147) goto L_0076;\nL_0053:\n\tv155 = v246 << 3;\n\tv275 = v47 + v155;\n\tgoto L_0061;\n\tv397 = *([v274 @ X0_v72+E0]);\n\tv398 = v397 == 0;\n\tv399 = ~v398;\n\tif (v399) goto L_0061;\n\tv401 = \"il2cpp_codegen_runtime_class_init\"(v274, v257, v256, v71, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0061:\n\tFacebook.Unity.CodelessCrawler::GenChild(*([v275 @ X8_v50+20]), v57);\n\tv180 = System.Text.StringBuilder::Append(v57, \",\");\n\tv246 = v246 + 1;\n\tv158 = v246 < *([v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)+18]);\n\tif (v158) goto L_0053;\nL_0076:\n\tv187 = System.Text.StringBuilder::get_Length(v57);\n\tv270 = v187 - 1;\n\tv273 = System.Text.StringBuilder::get_Chars(v57, v270);\n\tv395 = v273 & 0xFFFF;\n\tv97 = v395 != 0x2C;\n\tif (v97) goto L_0092;\n\tv456 = System.Text.StringBuilder::get_Length(v57);\n\tv459 = v456 - 1;\n\tSystem.Text.StringBuilder::set_Length(v57, v459);\nL_0092:\n\t// 146 NewArr v130 @ X0_v31 (System.Object[]), typeof(System.Object[]), 8\n\tv502 = \"0\" == 0;\n\tif (v502) goto L_00A5;\n\t// 157 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv482 = v47 == 0;\n\tif (v482) goto L_0170;\nL_00A5:\n\tv130[0] = \"0\";\n\tv507 = UnityEngine.Screen::get_height();\n\t// 173 Box v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Int32), &v507 @ X0_v35 (System.Int32)\n\tv513 = v47 == 0;\n\tif (v513) goto L_00C5;\n\t// 180 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)\n\tv483 = v47 == 0;\n\tif (v483) goto L_0170;\nL_00C5:\n\tv130[1] = v47;\n\tv519 = UnityEngine.Screen::get_width();\n\t// 203 Box v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Int32), &v519 @ X0_v40 (System.Int32)\n\tv524 = v47 == 0;\n\tif (v524) goto L_00E2;\n\t// 210 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)\n\tv484 = v47 == 0;\n\tif (v484) goto L_0170;\nL_00E2:\n\tv130[2] = v47;\n\tv530 = \"0\" == 0;\n\tif (v530) goto L_00F9;\n\t// 232 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv485 = v47 == 0;\n\tif (v485) goto L_0170;\nL_00F9:\n\tv130[3] = \"0\";\n\tv535 = \"0\" == 0;\n\tif (v535) goto L_0110;\n\t// 255 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv486 = v47 == 0;\n\tif (v486) goto L_0170;\nL_0110:\n\tv130[4] = \"0\";\n\tv540 = \"0\" == 0;\n\tif (v540) goto L_0127;\n\t// 278 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv487 = v47 == 0;\n\tif (v487) goto L_0170;\nL_0127:\n\tv130[5] = \"0\";\n\tv545 = \"0\" == 0;\n\tif (v545) goto L_013E;\n\t// 301 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv488 = v47 == 0;\n\tif (v488) goto L_0170;\nL_013E:\n\tv130[6] = \"0\";\n\tv550 = \"0\" == 0;\n\tif (v550) goto L_0158;\n\t// 324 IsInst v47 @ X0_v3 (UnityEngine.SceneManagement.Scene), typeof(System.Object), \"0\"\n\tv489 = v47 == 0;\n\tif (v489) goto L_0170;\nL_0158:\n\tv130[7] = \"0\";\n\tv559 = System.Text.StringBuilder::AppendFormat(v57, \"],\\\"classtypebitmask\\\":\\\"{0}\\\",\\\"tag\\\":\\\"0\\\",\\\"dimension\\\":{{\\\"height\\\":{1},\\\"width\\\":{2},\\\"scrolly\\\":{3},\\\"left\\\":{4},\\\"top\\\":{5},\\\"scrollx\\\":{6},\\\"visibility\\\":{7}}}}}\", v130);\n\treturnVal2 = System.Text.StringBuilder::ToString(v57);\n\treturn returnVal2;\n\tv394 = new System.IndexOutOfRangeException();\nL_016F:\n\tv453 = new System.TypeLoadException();\nL_0170:\n\tv446 = new System.ArrayTypeMismatchException();\n\tgoto L_016F;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 274 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string GenViewJson()
		{
			//IL_0087: Unknown result type (might be due to invalid IL or missing references)
			//IL_008c: Expected O, but got Unknown
			//IL_00a6: Expected O, but got I
			Scene activeScene = SceneManager.GetActiveScene();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D468C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0x218)");
			StringBuilder stringBuilder = new StringBuilder();
			activeScene = SceneManager.GetActiveScene();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10D454C (inside UnityEngine.SceneManagement.Scene::GetRootGameObjectsInternal +0xD8)");
			object arg = default(object);
			StringBuilder stringBuilder2 = stringBuilder.AppendFormat("{{\"classname\":\"{0}\",\"childviews\":[", arg);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)+18]");
			if (0L >= 1L)
			{
				int num = 0;
				int num3;
				do
				{
					int num2 = num << 3;
					object obj = activeScene + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X8_v50+20]");
					GenChild((GameObject)0, stringBuilder);
					StringBuilder stringBuilder3 = stringBuilder.Append(",");
					num++;
					num3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v3 (UnityEngine.SceneManagement.Scene)+18]");
				}
				while ((long)num3 < 0L);
			}
			int length = stringBuilder.Length;
			int index = length - 1;
			char c = stringBuilder.get_Chars(index);
			int num4 = c & 0xFFFF;
			if (num4 == 44)
			{
				int length2 = stringBuilder.Length;
				int length3 = length2 - 1;
				stringBuilder.Length = length3;
			}
			object[] array = new object[8];
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[0] = "0";
			int height = Screen.height;
			activeScene = (Scene)(object)height;
			if ((object)activeScene != null)
			{
				activeScene = (Scene)(activeScene as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[1] = activeScene;
			int width = Screen.width;
			activeScene = (Scene)(object)width;
			if ((object)activeScene != null)
			{
				activeScene = (Scene)(activeScene as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[2] = activeScene;
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[3] = "0";
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[4] = "0";
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[5] = "0";
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[6] = "0";
			if ("0" != null)
			{
				activeScene = (Scene)("0" as object);
				if ((object)activeScene == null)
				{
					goto IL_04d7;
				}
			}
			array[7] = "0";
			StringBuilder stringBuilder4 = stringBuilder.AppendFormat("],\"classtypebitmask\":\"{0}\",\"tag\":\"0\",\"dimension\":{{\"height\":{1},\"width\":{2},\"scrolly\":{3},\"left\":{4},\"top\":{5},\"scrollx\":{6},\"visibility\":{7}}}}}", array);
			return stringBuilder.ToString();
			IL_04d7:
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x600017A")]
		[Address(RVA = "0xD22D5C", Offset = "0xD22D5C", Length = "0x82C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0025;\n\tv42 = *([1EABCB0]);\n\tv43 = *([v42 @ X8_v100]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, builder, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023B94]) = v61;\nL_0025:\n\tv67 = UnityEngine.Object::get_name(curObj);\n\tv326 = System.Text.StringBuilder::AppendFormat(builder, \"{{\\\"classname\\\":\\\"{0}\\\",\\\"childviews\\\":[\", v67);\n\tv303 = UnityEngine.GameObject::get_transform(curObj);\n\tv419 = UnityEngine.Transform::get_childCount(v303);\n\tv430 = v419 < 1;\n\tif (v430) goto L_0090;\nL_004E:\n\tv484 = UnityEngine.GameObject::GetComponent(curObj);\n\tgoto L_005E;\n\tv494 = *([v318 @ X8_v95+E0]);\n\tv495 = v494 == 0;\n\tv496 = ~v495;\n\tgoto L_005E;\n\tv517 = v318;\n\tv498 = \"il2cpp_codegen_runtime_class_init\"(v517, v482, v477, v195, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_005E:\n\tv502 = UnityEngine.Object::op_Equality(0, v484);\n\tv519 = v502 == 0;\n\tif (v519) goto L_0081;\n\tv304 = UnityEngine.GameObject::get_transform(curObj);\n\tv305 = UnityEngine.Transform::GetChild(v304, v263);\n\tv571 = UnityEngine.Component::get_gameObject(v305);\n\tgoto L_007C;\n\tv594 = *([v533 @ X8_v97+E0]);\n\tv595 = v594 == 0;\n\tv596 = ~v595;\n\tif (v596) goto L_007C;\n\tv604 = v533;\n\tv598 = \"il2cpp_codegen_runtime_class_init\"(v604, v570, v294, v195, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_007C:\n\tFacebook.Unity.CodelessCrawler::GenChild(v571, builder);\n\tv531 = System.Text.StringBuilder::Append(builder, \",\");\nL_0081:\n\tv263 = v263 + 1;\n\tv445 = v263 < v419;\n\tif (v445) goto L_004E;\nL_0090:\n\tv474 = System.Text.StringBuilder::get_Length(builder);\n\tv485 = v474 - 1;\n\tv488 = System.Text.StringBuilder::get_Chars(builder, v485);\n\tv492 = v488 & 0xFFFF;\n\tv160 = v492 != 0x2C;\n\tif (v160) goto L_00AC;\n\tv505 = System.Text.StringBuilder::get_Length(builder);\n\tv509 = v505 - 1;\n\tSystem.Text.StringBuilder::set_Length(builder, v509);\nL_00AC:\n\tv516 = UnityEngine.GameObject::GetComponentInParent(curObj);\n\tv525 = UnityEngine.GameObject::GetComponent(curObj);\n\tgoto L_00C7;\n\tv541 = *([v537 @ X8_v13+E0]);\n\tv542 = v541 == 0;\n\tv543 = ~v542;\n\tif (v543) goto L_00C7;\n\tv551 = v537;\n\tv545 = \"il2cpp_codegen_runtime_class_init\"(v551, v524, v506, v195, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_00C7:\n\tv550 = UnityEngine.Object::op_Inequality(0, v525);\n\tv553 = v550 == 0;\n\tif (v553) goto L_01FF;\n\tgoto L_00D8;\n\tv572 = *([v554 @ X0_v83+E0]);\n\tv573 = v572 == 0;\n\tv574 = ~v573;\n\tif (v574) goto L_00D8;\n\tv576 = \"il2cpp_codegen_runtime_class_init\"(v554, v548, v549, v195, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_00D8:\n\tv561 = UnityEngine.Object::op_Inequality(0, v516);\n\tv563 = v561 == 0;\n\tif (v563) goto L_01FF;\n\tv306 = UnityEngine.GameObject::GetComponent(curObj);\n\tv256 = UnityEngine.RectTransform::get_rect(v306);\n\tv212 = UnityEngine.GameObject::get_transform(curObj);\n\tv127 = UnityEngine.Transform::get_position(v212);\n\tv959 = UnityEngine.Canvas::get_renderMode(v516);\n\tgoto L_0110;\n\tv969 = *([v319 @ X8_v57+E0]);\n\tv970 = v969 == 0;\n\tv971 = ~v970;\n\tif (v971) goto L_0110;\n\tv981 = v319;\n\tv973 = \"il2cpp_codegen_runtime_class_init\"(v981, v958, v200, v195, v47, v48, v49, v50, v127, v123, v119, v116, v55, v56, v57, v58);\nL_0110:\n\tv128 = Facebook.Unity.CodelessCrawler::getScreenCoordinate(v127, v959);\n\tv307 = UnityEngine.GameObject::GetComponent(curObj);\n\tv991 = UnityEngine.Component::GetComponentInChildren(v307);\n\tgoto L_012C;\n\tv999 = *([v228 @ X8_v60+E0]);\n\tv1000 = v999 == 0;\n\tv1001 = ~v1000;\n\tif (v1001) goto L_012C;\n\tv1010 = v228;\n\tv1003 = \"il2cpp_codegen_runtime_class_init\"(v1010, v990, v200, v195, v47, v48, v49, v50, v128, v124, v120, v116, v55, v56, v57, v58);\nL_012C:\n\tv213 = UnityEngine.Object::op_Inequality(0, v991);\n\tv1012 = v213 == 0;\n\tif (v1012) goto L_0146;\n\tv1049 = UnityEngine.UI.Text::get_text(v991);\n\tv1022 = System.String::Concat(\"\\\"text\\\":\\\"\", v1049, \"\\\",\");\nL_0146:\n\t// 326 NewArr v1061 @ X0_v104 (System.Object[]), typeof(System.Object[]), 9\n\tgoto L_0153;\n\tv1058 = *([v229 @ X8_v64+E0]);\n\tv1059 = v1058 == 0;\n\tv1060 = ~v1059;\n\tgoto L_0153;\n\tv1068 = v229;\n\tv1062 = \"il2cpp_codegen_runtime_class_init\"(v1068, v208, v202, v196, v47, v48, v49, v50, v128, v124, v120, v116, v55, v56, v57, v58);\nL_0153:\n\tv214 = Facebook.Unity.CodelessCrawler::getClasstypeBitmaskButton();\n\tv1072 = v214 == 0;\n\tif (v1072) goto L_0160;\n\t// 348 IsInst v902 @ X0_v142, typeof(System.Object), v214 @ X0_v105 (System.String)\nL_0160:\n\tv814 = v1061.Length == 0;\n\tif (v814) goto L_0309;\n\tv1061[0] = v214;\n\tv1083 = 0x10CD188(&v256 @ V0_v7 (UnityEngine.Rect), 0, v784, v782, v47, v48, v49, v50, v128, v128.y, v127.z, v256.m_Height, v55, v56, v57, v58);\n\tv1088 = &v31 @ stack_-10_v2 - 0x44;\n\t*([v30 @ X29_v1-44]) = v128;\n\t// 364 Box v1090 @ X0_v110, typeof(System.Int32), v1088 @ X1_v59\n\tv1092 = v1090 == 0;\n\tif (v1092) goto L_0177;\n\t// 371 IsInst v903 @ X0_v140, typeof(System.Object), v1090 @ X0_v110\nL_0177:\n\tv1099 = v1061.Length < 1;\n\tv770 = ~v1099;\n\tv758 = v1061.Length - 1;\n\tv734 = v758 == 0;\n\tv1100 = ~v770;\n\tv674 = v1100 | v734;\n\tif (v674) goto L_0309;\n\tv1061[1] = v1090;\n\tv1104 = 0x10CD178(&v256 @ V0_v7 (UnityEngine.Rect), 0, v784, v782, v47, v48, v49, v50, v128, v128.y, v127.z, v256.m_Height, v55, v56, v57, v58);\n\t// 395 Box v1112 @ X0_v115, typeof(System.Int32), &v128 @ V0_v10 (UnityEngine.Vector2)\n\tv1115 = v1112 == 0;\n\tif (v1115) goto L_0196;\n\t// 402 IsInst v904 @ X0_v138, typeof(System.Object), v1112 @ X0_v115\nL_0196:\n\tv1118 = v1061.Length < 2;\n\tv771 = ~v1118;\n\tv759 = v1061.Length - 2;\n\tv735 = v759 == 0;\n\tv1119 = ~v771;\n\tv675 = v1119 | v735;\n\tif (v675) goto L_0309;\n\tv1061[2] = v1112;\n\tv635 = 0;\n\t// 422 Box v1122 @ X0_v118, typeof(System.Int32), &v635 @ stack_-94_v7\n\tv1123 = v1122 == 0;\n\tif (v1123) goto L_01B1;\n\t// 429 IsInst v905 @ X0_v136, typeof(System.Object), v1122 @ X0_v118\nL_01B1:\n\tv1126 = v1061.Length < 3;\n\tv772 = ~v1126;\n\tv760 = v1061.Length - 3;\n\tv736 = v760 == 0;\n\tv1127 = ~v772;\n\tv676 = v1127 | v736;\n\tif (v676) goto L_0309;\n\tv1061[3] = v1122;\n\tv1130 = 0x10CD178(&v256 @ V0_v7 (UnityEngine.Rect), 0, v784, v782, v47, v48, v49, v50, v128, v128.y, v127.z, v256.m_Height, v55, v56, v57, v58);\n\tgoto L_01D0;\n\tv1137 = *([v1133 @ X0_v122+E0]);\n\tv1138 = v1137 == 0;\n\tv1139 = ~v1138;\n\tif (v1139) goto L_01D0;\n\tv1141 = \"il2cpp_codegen_runtime_class_init\"(v1133, v1129, v202, v196, v47, v48, v49, v50, v128, v124, v120, v116, v55, v56, v57, v58);\nL_01D0:\n\tv51 = v128 * -0.5f;\n\tv51 = v128 + v51;\n\t// 469 Box v1148 @ X0_v125, typeof(System.Int32), &v51 @ V0 (System.Single)\n\tv1149 = v1148 == 0;\n\tif (v1149) goto L_01E0;\n\t// 476 IsInst v906 @ X0_v133, typeof(System.Object), v1148 @ X0_v125\nL_01E0:\n\tv1152 = v1061.Length < 4;\n\tv773 = ~v1152;\n\tv761 = v1061.Length - 4;\n\tv737 = v761 == 0;\n\tv1153 = ~v773;\n\tv677 = v1153 | v737;\n\tif (v677) goto L_0309;\n\tv1061[4] = v1148;\n\tv1155 = UnityEngine.Screen::get_height();\n\tv1157 = 0x10CD188(&v256 @ V0_v7 (UnityEngine.Rect), 0, v784, v782, v47, v48, v49, v50, v51, v128.y, v127.z, v256.m_Height, v55, v56, v57, v58);\n\tv51 = v51 * -0.5f;\n\tv363 = v1155 - v128.y;\n\tv51 = v363 + v51;\n\tgoto L_028F;\nL_01FF:\n\t// 511 NewArr v591 @ X0_v55 (System.Object[]), typeof(System.Object[]), 9\n\tgoto L_020E;\n\tv588 = *([v230 @ X8_v37+E0]);\n\tv589 = v588 == 0;\n\tv590 = ~v589;\n\tif (v590) goto L_020E;\n\tv603 = v230;\n\tv592 = \"il2cpp_codegen_runtime_class_init\"(v603, v209, v203, v195, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_020E:\n\tv215 = Facebook.Unity.CodelessCrawler::getClasstypeBitmaskButton();\n\tv606 = v215 == 0;\n\tif (v606) goto L_021B;\n\t// 535 IsInst v611 @ X0_v80, typeof(System.Object), v215 @ X0_v56 (System.String)\nL_021B:\n\tv618 = v591.Length == 0;\n\tif (v618) goto L_0309;\n\tv591[0] = v215;\n\tv622 = &v31 @ stack_-10_v2 - 0x44;\n\t*([v30 @ X29_v1-44]) = 0;\n\t// 547 Box v624 @ X0_v59, typeof(System.Int32), v622 @ X1_v33\n\tv946 = v624 == 0;\n\tif (v946) goto L_022E;\n\t// 554 IsInst v907 @ X0_v78, typeof(System.Object), v624 @ X0_v59\nL_022E:\n\tv952 = v591.Length < 1;\n\tv774 = ~v952;\n\tv762 = v591.Length - 1;\n\tv738 = v762 == 0;\n\tv953 = ~v774;\n\tv678 = v953 | v738;\n\tif (v678) goto L_0309;\n\tv591[1] = v624;\n\tv638 = 0;\n\t// 574 Box v956 @ X0_v62, t\n// ... truncated")]
		private static void GenChild(GameObject curObj, StringBuilder builder)
		{
			//IL_0800: Expected O, but got I
			//IL_080f: Expected I4, but got O
			//IL_086e: Expected O, but got I4
			//IL_08be: Expected O, but got I4
			//IL_08c7: Expected I4, but got O
			//IL_0926: Expected O, but got I4
			//IL_02f7: Expected O, but got I4
			//IL_0976: Expected O, but got I4
			//IL_097f: Expected I4, but got O
			//IL_09de: Expected O, but got I4
			//IL_0340: Expected O, but got I4
			//IL_0a2e: Expected O, but got I4
			//IL_0a37: Expected I4, but got O
			//IL_0a96: Expected O, but got I4
			//IL_03dd: Expected O, but got I
			//IL_03eb: Expected I4, but got O
			//IL_0afc: Expected I, but got O
			//IL_0b05: Expected O, but got I4
			//IL_0b13: Expected I, but got O
			//IL_044f: Expected O, but got I4
			//IL_0b5f: Expected O, but got I4
			//IL_04a9: Expected I4, but got O
			//IL_0baf: Expected O, but got I4
			//IL_0c16: Expected O, but got I4
			//IL_050d: Expected O, but got I4
			//IL_055d: Expected O, but got I4
			//IL_0566: Expected I4, but got O
			//IL_0ca3: Expected O, but got I4
			//IL_0ccf: Expected O, but got I4
			//IL_05c5: Expected O, but got I4
			//IL_0e05: Expected O, but got I
			//IL_064d: Expected I4, but got F4
			//IL_06ac: Expected O, but got I4
			//IL_0d4f: Expected O, but got I4
			//IL_075d: Expected I, but got O
			//IL_076b: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			string arg = curObj.name;
			StringBuilder stringBuilder = builder.AppendFormat("{{\"classname\":\"{0}\",\"childviews\":[", arg);
			Transform transform = curObj.transform;
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num = 0;
				do
				{
					Button component = curObj.GetComponent<Button>();
					if (null == component)
					{
						Transform transform2 = curObj.transform;
						Transform child = transform2.GetChild(num);
						GameObject curObj2 = child.gameObject;
						GenChild(curObj2, builder);
						StringBuilder stringBuilder2 = builder.Append(",");
					}
					num++;
				}
				while (num < childCount);
			}
			int length = builder.Length;
			int index = length - 1;
			char c = builder.get_Chars(index);
			int num2 = c & 0xFFFF;
			if (num2 == 44)
			{
				int length2 = builder.Length;
				int length3 = length2 - 1;
				builder.Length = length3;
			}
			UnityEngine.Canvas componentInParent = curObj.GetComponentInParent<UnityEngine.Canvas>();
			Button component2 = curObj.GetComponent<Button>();
			bool flag = null != component2;
			bool flag2 = !flag;
			string text = null;
			string text2;
			object[] array2;
			if (!flag2)
			{
				bool flag3 = null != componentInParent;
				bool flag4 = !flag3;
				text = null;
				if (!flag4)
				{
					RectTransform component3 = curObj.GetComponent<RectTransform>();
					Rect rect = component3.rect;
					Transform transform3 = curObj.transform;
					Vector3 position = transform3.position;
					RenderMode renderMode = componentInParent.renderMode;
					Vector2 screenCoordinate = getScreenCoordinate(position, renderMode);
					Button component4 = curObj.GetComponent<Button>();
					Text componentInChildren = component4.GetComponentInChildren<Text>();
					bool flag5 = null != componentInChildren;
					bool flag6 = !flag5;
					object obj3 = 0;
					text = null;
					text2 = "";
					if (!flag6)
					{
						string text3 = componentInChildren.text;
						string text4 = "\"text\":\"" + text3 + "\",";
						obj3 = 0;
						text = "\",";
						text2 = text4;
					}
					object[] array = new object[9];
					string classtypeBitmaskButton = getClasstypeBitmaskButton();
					if (classtypeBitmaskButton != null)
					{
						object obj4 = classtypeBitmaskButton as object;
					}
					if (array.Length != 0)
					{
						array[0] = classtypeBitmaskButton;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
						object obj5 = (long)(IntPtr)obj2 - 68L;
						object obj6 = (int)obj5;
						if (obj6 != null)
						{
							object obj7 = obj6 as object;
						}
						bool flag7 = array.Length < 1;
						bool flag8 = !flag7;
						object obj8 = array.Length - 1;
						bool flag9 = obj8 == null;
						bool flag10 = !flag8;
						if (!(flag10 || flag9))
						{
							array[1] = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
							object obj9 = (int)screenCoordinate;
							if (obj9 != null)
							{
								object obj10 = obj9 as object;
							}
							bool flag11 = array.Length < 2;
							bool flag12 = !flag11;
							object obj11 = array.Length - 2;
							bool flag13 = obj11 == null;
							bool flag14 = !flag12;
							if (!(flag14 || flag13))
							{
								array[2] = obj9;
								object obj12 = 0;
								object obj13 = (int)obj12;
								if (obj13 != null)
								{
									object obj14 = obj13 as object;
								}
								bool flag15 = array.Length < 3;
								bool flag16 = !flag15;
								object obj15 = array.Length - 3;
								bool flag17 = obj15 == null;
								bool flag18 = !flag16;
								if (!(flag18 || flag17))
								{
									array[3] = obj13;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
									float num3 = screenCoordinate.x * -0.5f;
									num3 = screenCoordinate.x + num3;
									object obj16 = (int)num3;
									if (obj16 != null)
									{
										object obj17 = obj16 as object;
									}
									bool flag19 = array.Length < 4;
									bool flag20 = !flag19;
									object obj18 = array.Length - 4;
									bool flag21 = obj18 == null;
									bool flag22 = !flag20;
									if (!(flag22 || flag21))
									{
										array[4] = obj16;
										int height = Screen.height;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
										num3 *= -0.5f;
										float num4 = (float)height - screenCoordinate.y;
										num3 = num4 + num3;
										float num5 = num3;
										array2 = array;
										IntPtr intPtr = (IntPtr)typeof(int);
										IntPtr intPtr2 = (IntPtr)typeof(int);
										goto IL_0db5;
									}
								}
							}
						}
					}
					goto IL_0d7d;
				}
			}
			object[] array3 = new object[9];
			string classtypeBitmaskButton2 = getClasstypeBitmaskButton();
			if (classtypeBitmaskButton2 != null)
			{
				object obj19 = classtypeBitmaskButton2 as object;
			}
			if (array3.Length != 0)
			{
				array3[0] = classtypeBitmaskButton2;
				object obj20 = (long)(IntPtr)obj2 - 68L;
				_ = 0;
				object obj21 = (int)obj20;
				if (obj21 != null)
				{
					object obj22 = obj21 as object;
				}
				bool flag23 = array3.Length < 1;
				bool flag24 = !flag23;
				object obj23 = array3.Length - 1;
				bool flag25 = obj23 == null;
				bool flag26 = !flag24;
				if (!(flag26 || flag25))
				{
					array3[1] = obj21;
					object obj24 = 0;
					object obj25 = (int)obj24;
					if (obj25 != null)
					{
						object obj26 = obj25 as object;
					}
					bool flag27 = array3.Length < 2;
					bool flag28 = !flag27;
					object obj27 = array3.Length - 2;
					bool flag29 = obj27 == null;
					bool flag30 = !flag28;
					if (!(flag30 || flag29))
					{
						array3[2] = obj25;
						object obj12 = 0;
						object obj28 = (int)obj12;
						if (obj28 != null)
						{
							object obj29 = obj28 as object;
						}
						bool flag31 = array3.Length < 3;
						bool flag32 = !flag31;
						object obj30 = array3.Length - 3;
						bool flag33 = obj30 == null;
						bool flag34 = !flag32;
						if (!(flag34 || flag33))
						{
							array3[3] = obj28;
							object obj31 = 0;
							object obj32 = (int)obj31;
							if (obj32 != null)
							{
								object obj33 = obj32 as object;
							}
							bool flag35 = array3.Length < 4;
							bool flag36 = !flag35;
							object obj34 = array3.Length - 4;
							bool flag37 = obj34 == null;
							bool flag38 = !flag36;
							if (!(flag38 || flag37))
							{
								array3[4] = obj32;
								float num5 = 0f;
								array2 = array3;
								IntPtr intPtr = (IntPtr)typeof(int);
								object obj3 = 0;
								IntPtr intPtr2 = (IntPtr)typeof(int);
								text2 = "";
								goto IL_0db5;
							}
						}
					}
				}
			}
			goto IL_0d7d;
			IL_0d7d:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_0db5:
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj35 = default(object);
			if (obj35 != null)
			{
				object obj36 = obj35 as object;
			}
			bool flag39 = array2.Length < 5;
			bool flag40 = !flag39;
			object obj37 = array2.Length - 5;
			bool flag41 = obj37 == null;
			bool flag42 = !flag40;
			if (!(flag42 || flag41))
			{
				array2[5] = obj35;
				object obj38 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object obj39 = default(object);
				if (obj39 != null)
				{
					object obj40 = obj39 as object;
				}
				bool flag43 = array2.Length < 6;
				bool flag44 = !flag43;
				object obj41 = array2.Length - 6;
				bool flag45 = obj41 == null;
				bool flag46 = !flag44;
				if (!(flag46 || flag45))
				{
					array2[6] = obj39;
					string visibility = getVisibility(curObj);
					if (visibility != null)
					{
						object obj42 = visibility as object;
					}
					object obj43 = array2.Length;
					bool flag47 = array2.Length < 7;
					bool flag48 = !flag47;
					object obj44 = array2.Length - 7;
					bool flag49 = obj44 == null;
					bool flag50 = !flag48;
					if (!(flag50 || flag49))
					{
						array2[7] = visibility;
						if (text2 != null)
						{
							object obj45 = text2 as object;
							obj43 = array2.Length;
						}
						bool flag51 = (long)(IntPtr)obj43 < 8L;
						bool flag52 = !flag51;
						object obj46 = (long)(IntPtr)obj43 - 8L;
						bool flag53 = obj46 == null;
						bool flag54 = !flag52;
						if (!(flag54 || flag53))
						{
							array2[8] = text2;
							StringBuilder stringBuilder3 = builder.AppendFormat("],{8}\"classtypebitmask\":\"{0}\",\"tag\":\"0\",\"dimension\":{{\"height\":{1},\"width\":{2},\"scrolly\":{3},\"left\":{4},\"top\":{5},\"scrollx\":{6},\"visibility\":{7}}}}}", array2);
							return;
						}
					}
				}
			}
			goto IL_0d7d;
		}

		[Token(Token = "0x600017B")]
		[Address(RVA = "0xD237B4", Offset = "0xD237B4", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0F770]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, arg0, arg1, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023B95]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, arg0, arg1, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\tFacebook.Unity.CodelessCrawler::updateMainCamera();\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void onActiveSceneChanged(Scene arg0, Scene arg1)
		{
			updateMainCamera();
		}

		[Token(Token = "0x600017C")]
		[Address(RVA = "0xD225A4", Offset = "0xD225A4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv16 = *([1EAD610]);\n\tv17 = *([v16 @ X8_v8]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2023B96]) = v37;\nL_0013:\n\tv39 = UnityEngine.Camera::get_main();\n\tgoto L_0024;\n\tv47 = *([v43 @ X8_v3 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv61 = v43;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v61, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = Facebook.Unity.CodelessCrawler;\nL_0024:\n\tv56.mainCamera = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void updateMainCamera()
		{
			Camera main = Camera.main;
			mainCamera = main;
		}

		[Token(Token = "0x600017D")]
		[Address(RVA = "0xD23588", Offset = "0xD23588", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EE1C98]);\n\tv31 = *([v30 @ X8_v24]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, position, v0, v2, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2023B97]) = v47;\nL_001B:\n\tv48 = renderMode == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tgoto L_0032;\n\tv76 = *([v51 @ X0_v8 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0032;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v34, v35, v36, v37, v38, v39, position, v0, v2, v40, v41, v42, v43, v44);\n\tv80 = Facebook.Unity.CodelessCrawler;\nL_0032:\n\tgoto L_003C;\n\tv121 = *([v72 @ X8_v14+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tgoto L_003C;\n\tv148 = v72;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v148, methodInfo, v34, v35, v36, v37, v38, v39, position, v0, v2, v40, v41, v42, v43, v44);\nL_003C:\n\tv66 = UnityEngine.Object::op_Equality(0, v85.mainCamera);\n\tv68 = v66 == 0;\n\tif (v68) goto L_0047;\n\tgoto L_0063;\nL_0047:\n\tgoto L_0057;\n\tv177 = *([v151 @ X0_v13 (Il2CppClass<Facebook.Unity.CodelessCrawler>)+E0]);\n\tv178 = v177 == 0;\n\tv179 = ~v178;\n\t// 75 ConditionalJump @b29, v179 @ TEMP_v25\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v151, v61, v59, v35, v36, v37, v38, v39, position, v0, v2, v40, v41, v42, v43, v44);\n\tv181 = Facebook.Unity.CodelessCrawler;\nL_0057:\n\tv93 = UnityEngine.Camera::WorldToScreenPoint(v172.mainCamera, position);\nL_0063:\n\tgoto L_0075;\n\tv128 = *([v116 @ X0_v3+E0]);\n\tv129 = v128 == 0;\n\tv130 = ~v129;\n\tgoto L_0075;\n\tv132 = \"il2cpp_codegen_runtime_class_init\"(v116, v95, v94, v35, v36, v37, v38, v39, v92, v114, v112, v40, v41, v42, v43, v44);\nL_0075:\n\t// 117 MakeStruct v146 @ AGGD236CC_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v102 @ V9_v2 (UnityEngine.Vector3), v104 @ V8_v2 (System.Single), v106 @ V10_v2 (System.Single)\n\treturnVal1 = UnityEngine.Vector2::op_Implicit(v146);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn position;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector2 getScreenCoordinate(Vector3 position, RenderMode renderMode)
		{
			Vector3 vector;
			float y;
			float z;
			if (renderMode == RenderMode.ScreenSpaceOverlay || null == mainCamera)
			{
				vector = position;
				y = position.y;
				z = position.z;
			}
			else
			{
				Vector3 vector2 = mainCamera.WorldToScreenPoint(position);
				vector = vector2;
				y = vector2.y;
				z = vector2.z;
			}
			Vector3 vector3 = default(Vector3);
			vector3.x = vector.x;
			vector3.y = y;
			vector3.z = z;
			return vector3;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xD236D4", Offset = "0xD236D4", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = *([1F05F00]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023B98]) = v35;\nL_0011:\n\tv36 = Facebook.Unity.Constants::get_CurrentPlatform();\n\tv52 = v36 != 2;\n\tif (v52) goto L_FFFFFFFF;\n\tgoto L_0030;\nL_0030:\n\tv65 = v36 != 1;\n\tif (v65) goto L_003B;\n\tgoto L_003B;\nL_003B:\n\treturn *([v68 @ X8_v6 (System.String)]);\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string getClasstypeBitmaskButton()
		{
			FacebookUnityPlatform currentPlatform = Constants.CurrentPlatform;
			string result = ((currentPlatform != FacebookUnityPlatform.IOS) ? "0" : "16");
			if (currentPlatform == FacebookUnityPlatform.Android)
			{
				result = "4";
			}
			return result;
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0xD23740", Offset = "0xD23740", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC6968]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023B99]) = v38;\nL_0017:\n\tv42 = UnityEngine.GameObject::get_activeInHierarchy(gameObj);\n\tv51 = v42 == 0;\n\tv56 = ~v51;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_002E;\nL_002E:\n\treturn *([v82 @ X8_v5 (System.String)]);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string getVisibility(GameObject gameObj)
		{
			if (gameObj.activeInHierarchy)
			{
				return "0";
			}
			return "8";
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xD23810", Offset = "0xD23810", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CodelessCrawler()
		{
		}
	}
}
