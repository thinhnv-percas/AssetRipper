using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[Token(Token = "0x2000002")]
public class AdManager : MonoBehaviour
{
	[Header("Admob Ad Units :")]
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x20")]
	private string idBanner;

	[Token(Token = "0x4000002")]
	[FieldOffset(Offset = "0x28")]
	private string idInterstitial;

	[Token(Token = "0x4000003")]
	[FieldOffset(Offset = "0x30")]
	private string idReward;

	[Token(Token = "0x4000004")]
	[FieldOffset(Offset = "0x38")]
	private AndroidJavaObject currentActivity;

	[Token(Token = "0x4000005")]
	[FieldOffset(Offset = "0x40")]
	private AndroidJavaClass UnityPlayer;

	[Token(Token = "0x4000006")]
	[FieldOffset(Offset = "0x48")]
	private AndroidJavaObject context;

	[Token(Token = "0x4000007")]
	[FieldOffset(Offset = "0x50")]
	private AndroidJavaObject toast;

	[Header("Toggle Admob Ads :")]
	[Token(Token = "0x4000008")]
	[FieldOffset(Offset = "0x58")]
	private bool bannerAdEnabled;

	[Token(Token = "0x4000009")]
	[FieldOffset(Offset = "0x59")]
	private bool interstitialAdEnabled;

	[Token(Token = "0x400000A")]
	[FieldOffset(Offset = "0x5A")]
	private bool rewardedAdEnabled;

	[HideInInspector]
	[Token(Token = "0x400000B")]
	[FieldOffset(Offset = "0x60")]
	public BannerView AdBanner;

	[HideInInspector]
	[Token(Token = "0x400000C")]
	[FieldOffset(Offset = "0x68")]
	public InterstitialAd AdInterstitial;

	[HideInInspector]
	[Token(Token = "0x400000D")]
	[FieldOffset(Offset = "0x70")]
	public RewardedAd AdReward;

	[Token(Token = "0x400000E")]
	[FieldOffset(Offset = "0x78")]
	public GameObject GDPR;

	[Token(Token = "0x400000F")]
	public static AdManager Instance;

	[Token(Token = "0x4000010")]
	[FieldOffset(Offset = "0x80")]
	public bool _firstInit;

	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x88")]
	public Action InteralADAction;

	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x90")]
	public Action RewardAction;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0xBF417C", Offset = "0xBF417C", Length = "0x290")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = AdManager;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv60 = UnityEngine.AndroidJavaClass;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv91 = Il2CppMethodInfo;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv106 = UnityEngine.Object;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv112 = UnityEngine.SceneManagement.SceneManager;\n\tv113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v112, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv151 = UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv168 = \"getApplicationContext\";\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv176 = \"com.unity3d.player.UnityPlayer\";\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv189 = \"currentActivity\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3559D]) = v42;\nL_003E:\n\tgoto L_0043;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0043:\n\tv58 = UnityEngine.Object::op_Equality(v45.Instance, 0);\n\tv63 = v58 == 0;\n\tif (v63) goto L_00B4;\n\tgoto L_0053;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v67, v56, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0053:\n\tUnityEngine.Object::DontDestroyOnLoad(this);\n\tv94 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v94, \"com.unity3d.player.UnityPlayer\");\n\tthis.UnityPlayer = v94;\n\tv160 = UnityEngine.AndroidJavaObject::GetStatic(v94, \"currentActivity\");\n\tthis.currentActivity = v160;\n\tgoto L_0076;\n\tv179 = UnityEngine.AndroidJavaObject::GetStatic(Il2CppMethodInfo, \"currentActivity\");\nL_0076:\n\tgoto L_007B;\n\tv190 = UnityEngine.AndroidJavaObject::GetStatic(v183, v158, v159);\nL_007B:\n\tgoto L_FFFFFFFF;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v191, v158, v159, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0089;\n\tv202 = UnityEngine.AndroidJavaObject::GetStatic(v198, v158, v159);\nL_0089:\n\tv205 = *([v162 @ X0_v26+B8]);\n\tv210 = UnityEngine.AndroidJavaObject::Call(v160, \"getApplicationContext\", *([v205 @ X8_v18]));\n\tthis.context = v210;\n\tv212.Instance = this;\n\tv216 = new UnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>();\n\tUnityEngine.Events.UnityAction`2<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.LoadSceneMode>::.ctor(v216, this, Il2CppMethodInfo);\n\tgoto L_00B0;\n\tv225 = \"il2cpp_codegen_runtime_class_init\"(v223, v219, v126, v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00B0:\n\tUnityEngine.SceneManagement.SceneManager::add_sceneLoaded(v216);\n\treturn;\nL_00B4:\n\tv77 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00C5;\n\tv95 = v85;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v95, v76, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00C5:\n\tUnityEngine.Object::Destroy(v77);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 135 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected void Awake()
	{
		//IL_00a0: Expected O, but got I
		//IL_00b5: Expected O, but got I
		if (Instance == null)
		{
			UnityEngine.Object.DontDestroyOnLoad(this);
			object obj = (currentActivity = (AndroidJavaObject)(UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")).GetStatic<object>("currentActivity"));
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v26+B8]");
			object args = 0;
			object obj3 = ((AndroidJavaObject)obj).Call<object>("getApplicationContext", (object[])args);
			context = (AndroidJavaObject)obj3;
			Instance = this;
			UnityAction<Scene, LoadSceneMode> value = delegate
			{
				int num = PlayerPrefs.GetInt("npa", -1);
				if (num + 1 != 0)
				{
					if (_firstInit)
					{
						InitAd();
					}
					else
					{
						ShowBanner();
					}
				}
				else
				{
					GDPR.SetActive(value: true);
					Time.timeScale = 0f;
				}
			};
			SceneManager.sceneLoaded += value;
		}
		else
		{
			GameObject obj4 = base.gameObject;
			UnityEngine.Object.Destroy(obj4);
		}
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0xBF440C", Offset = "0xBF440C", Length = "0x13C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = UnityEngine.AndroidJavaRunnable;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv45 = System.Object[];\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv54 = AdManager+<>c__DisplayClass17_0;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv89 = \"runOnUiThread\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, message, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A3559E]) = v41;\nL_0022:\n\tv43 = new AdManager+<>c__DisplayClass17_0();\n\tSystem.Object::.ctor(v43);\n\tv43.message = message;\n\tv43.<>4__this = this;\n\t// 51 NewArr v65 @ X0_v12 (System.Object[]), typeof(System.Object[]), 1\n\tv74 = new UnityEngine.AndroidJavaRunnable();\n\tUnityEngine.AndroidJavaRunnable::.ctor(v74, v43, Il2CppMethodInfo);\n\tv118 = v74 == 0;\n\tif (v118) goto L_004A;\n\t// 68 IsInst v107 @ X0_v18, typeof(System.Object), v74 @ X0_v14 (UnityEngine.AndroidJavaRunnable)\n\tv109 = v107 == 0;\n\tif (v109) goto L_005D;\nL_004A:\n\tv65[0] = v74;\n\tUnityEngine.AndroidJavaObject::Call(this.currentActivity, \"runOnUiThread\", v65);\n\treturn;\n\tv87 = new System.NullReferenceException();\n\tv101 = new System.IndexOutOfRangeException();\nL_005D:\n\tv115 = new System.ArrayTypeMismatchException();\n\tthrow v115;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ShowToast(string message)
	{
		object[] array = new object[1];
		AndroidJavaRunnable androidJavaRunnable = delegate
		{
			//IL_0246: Expected O, but got I
			//IL_025b: Expected O, but got I
			AndroidJavaClass androidJavaClass = new AndroidJavaClass("android.widget.Toast");
			object[] array2 = new object[1];
			if (message != null)
			{
				androidJavaClass = (AndroidJavaClass)(message as object);
				if (androidJavaClass == null)
				{
					goto IL_0273;
				}
			}
			array2[0] = message;
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("java.lang.String", array2);
			AdManager adManager = this;
			object[] array3 = new object[3];
			AdManager adManager2 = this;
			if (adManager2.context != null)
			{
				androidJavaClass = (AndroidJavaClass)(adManager2.context as object);
				if (androidJavaClass == null)
				{
					goto IL_0273;
				}
			}
			array3[0] = adManager2.context;
			if (androidJavaObject != null)
			{
				androidJavaClass = (AndroidJavaClass)(androidJavaObject as object);
				if (androidJavaClass == null)
				{
					goto IL_0273;
				}
			}
			array3[1] = androidJavaObject;
			int num = androidJavaClass.GetStatic<int>("LENGTH_SHORT");
			androidJavaClass = (AndroidJavaClass)(object)num;
			if (androidJavaClass != null)
			{
				androidJavaClass = (AndroidJavaClass)(androidJavaClass as object);
				if (androidJavaClass == null)
				{
					goto IL_0273;
				}
			}
			array3[2] = androidJavaClass;
			object obj2 = androidJavaClass.CallStatic<object>("makeText", array3);
			adManager.toast = (AndroidJavaObject)obj2;
			AdManager adManager3 = this;
			androidJavaClass = (AndroidJavaClass)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (UnityEngine.AndroidJavaClass)+B8]");
			object args = 0;
			adManager3.toast.Call("show", (object[])args);
			return;
			IL_0273:
			ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
			throw ex2;
		};
		if (androidJavaRunnable != null)
		{
			object obj = androidJavaRunnable as object;
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		array[0] = androidJavaRunnable;
		currentActivity.Call("runOnUiThread", array);
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0xBF4550", Offset = "0xBF4550", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \"npa\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3559F]) = v38;\nL_0019:\n\tUnityEngine.PlayerPrefs::SetInt(\"npa\", 0);\n\tUnityEngine.GameObject::SetActive(this.GDPR, 0);\n\tUnityEngine.Time::set_timeScale(1f);\n\tv54 = ~this._firstInit;\n\tif (v54) goto L_002F;\n\tAdManager::InitAd(this);\nL_002F:\n\tgoto L_0038;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v75, v48, v49, v22, v23, v24, v25, v26, v51, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tUnityEngine.Object::Destroy(this.GDPR);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnUserClickAccept()
	{
		PlayerPrefs.SetInt("npa", 0);
		GDPR.SetActive(value: false);
		Time.timeScale = 1f;
		if (_firstInit)
		{
			InitAd();
		}
		UnityEngine.Object.Destroy(GDPR);
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0xBF46FC", Offset = "0xBF46FC", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = \"npa\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355A0]) = v38;\nL_0019:\n\tUnityEngine.PlayerPrefs::SetInt(\"npa\", 1);\n\tUnityEngine.GameObject::SetActive(this.GDPR, 0);\n\tUnityEngine.Time::set_timeScale(1f);\n\tv54 = ~this._firstInit;\n\tif (v54) goto L_002F;\n\tAdManager::InitAd(this);\nL_002F:\n\tgoto L_0038;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v75, v48, v49, v22, v23, v24, v25, v26, v51, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tUnityEngine.Object::Destroy(this.GDPR);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnUserClickCancel()
	{
		PlayerPrefs.SetInt("npa", 1);
		GDPR.SetActive(value: false);
		Time.timeScale = 1f;
		if (_firstInit)
		{
			InitAd();
		}
		UnityEngine.Object.Destroy(GDPR);
	}

	[Token(Token = "0x6000005")]
	[Address(RVA = "0xBF47B0", Offset = "0xBF47B0", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv43 = \"http://polarisgamestudio.epizy.com/policy.html\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A355A1]) = v35;\nL_001A:\n\tgoto L_0022;\n\tv44 = \"il2cpp_codegen_runtime_class_init\"(v36, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tUnityEngine.Application::OpenURL(\"http://polarisgamestudio.epizy.com/policy.html\");\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnUserClickPrivacyPolicy()
	{
		Application.OpenURL("http://polarisgamestudio.epizy.com/policy.html");
	}

	[Token(Token = "0x6000006")]
	[Address(RVA = "0xBF4818", Offset = "0xBF4818", Length = "0x164")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = UnityEngine.Object;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = \"CanvasGDPR\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv64 = \"npa\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355A2]) = v38;\nL_0022:\n\tUnityEngine.PlayerPrefs::SetInt(\"npa\", 0xFFFFFFFF);\n\tv46 = this.AdBanner == 0;\n\tif (v46) goto L_0029;\n\tGoogleMobileAds.Api.BannerView::Destroy(this.AdBanner);\nL_0029:\n\tv53 = this.AdInterstitial == 0;\n\tif (v53) goto L_0030;\n\tGoogleMobileAds.Api.InterstitialAd::Destroy(this.AdInterstitial);\nL_0030:\n\tv62 = UnityEngine.PlayerPrefs::GetInt(\"npa\", 0xFFFFFFFF);\n\tv65 = v62 + 1;\n\tv67 = v65 == 0;\n\tv70 = ~v67;\n\tif (v70) goto L_0068;\n\tgoto L_0044;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v74, v60, v61, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0044:\n\tv106 = UnityEngine.Object::op_Equality(this.GDPR, 0);\n\tv121 = v106 == 0;\n\tif (v121) goto L_005E;\n\tv128 = UnityEngine.Resources::Load(\"CanvasGDPR\");\n\tgoto L_005B;\n\tv140 = v130;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v140, v127, v105, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_005B:\n\tv136 = UnityEngine.Object::Instantiate(v128);\n\tthis.GDPR = v136;\n\tgoto L_0063;\nL_005E:\n\tv136 = this.GDPR;\nL_0063:\n\tUnityEngine.GameObject::SetActive(v136, 1);\n\tUnityEngine.Time::set_timeScale(0f);\nL_0068:\n\tthis._firstInit = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ClickAD()
	{
		PlayerPrefs.SetInt("npa", -1);
		if (AdBanner != null)
		{
			AdBanner.Destroy();
		}
		if (AdInterstitial != null)
		{
			AdInterstitial.Destroy();
		}
		int num = PlayerPrefs.GetInt("npa", -1);
		if (num + 1 == 0)
		{
			GameObject gameObject;
			if (GDPR == null)
			{
				GameObject original = Resources.Load<GameObject>("CanvasGDPR");
				gameObject = (GDPR = UnityEngine.Object.Instantiate(original));
			}
			else
			{
				gameObject = GDPR;
			}
			gameObject.SetActive(value: true);
			Time.timeScale = 0f;
		}
		_firstInit = true;
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0xBF4604", Offset = "0xBF4604", Length = "0xF8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = System.Action`1<GoogleMobileAds.Api.InitializationStatus>;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv51 = GoogleMobileAds.Api.RequestConfiguration+Builder;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A355A3]) = v42;\nL_0020:\n\tv44 = new GoogleMobileAds.Api.RequestConfiguration+Builder();\n\tGoogleMobileAds.Api.RequestConfiguration+Builder::.ctor(v44);\n\tv55 = 0;\n\tSystem.Nullable`1<System.Int32Enum>::.ctor(&v55 @ stack_-28_v1 (System.Nullable`1<System.Int32Enum>), 0xFFFFFFFF);\n\tv63 = GoogleMobileAds.Api.RequestConfiguration+Builder::SetTagForChildDirectedTreatment(v44, 0);\n\tv75 = GoogleMobileAds.Api.RequestConfiguration+Builder::build(v63);\n\tv96 = new System.Action`1<GoogleMobileAds.Api.InitializationStatus>();\n\tSystem.Action`1<GoogleMobileAds.Api.InitializationStatus>::.ctor(v96, this, Il2CppMethodInfo);\n\tGoogleMobileAds.Api.MobileAds::Initialize(v96);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void InitAd()
	{
		//IL_007d: Expected I4, but got I8
		RequestConfiguration.Builder builder = new RequestConfiguration.Builder();
		System.Int32Enum? int32Enum = null;
		int32Enum = (System.Int32Enum)(-1);
		RequestConfiguration.Builder builder2 = builder.SetTagForChildDirectedTreatment(null);
		RequestConfiguration requestConfiguration = builder2.build();
		Action<InitializationStatus> initCompleteAction = delegate
		{
			Action action = delegate
			{
				ShowBanner();
				RequestRewardAd();
				RequestInterstitialAd();
				_firstInit = false;
			};
			MobileAdsEventExecutor.ExecuteInUpdate(action);
		};
		MobileAds.Initialize(initCompleteAction);
	}

	[Token(Token = "0x6000008")]
	[Address(RVA = "0xBF49A4", Offset = "0xBF49A4", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.AdBanner == 0;\n\tif (v7) goto L_000A;\n\tGoogleMobileAds.Api.BannerView::Destroy(this.AdBanner);\nL_000A:\n\tv12 = this.AdInterstitial == 0;\n\tif (v12) goto L_0015;\n\tGoogleMobileAds.Api.InterstitialAd::Destroy(this.AdInterstitial);\n\treturn;\nL_0015:\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDestroy()
	{
		if (AdBanner != null)
		{
			AdBanner.Destroy();
		}
		if (AdInterstitial != null)
		{
			AdInterstitial.Destroy();
		}
	}

	[Token(Token = "0x6000009")]
	[Address(RVA = "0xBF49D8", Offset = "0xBF49D8", Length = "0x6C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355A4]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0025;\n\tv46 = v41;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v46, v39, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0025:\n\tUnityEngine.Object::Destroy(v40);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Destroy()
	{
		GameObject obj = base.gameObject;
		UnityEngine.Object.Destroy(obj);
	}

	[Token(Token = "0x600000A")]
	[Address(RVA = "0xBF4A44", Offset = "0xBF4A44", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.rewardedAdEnabled;\n\tif (v4) goto L_FFFFFFFF;\n\tv6 = this.AdReward == 0;\n\tif (v6) goto L_FFFFFFFF;\n\tv11 = GoogleMobileAds.Api.RewardedAd::IsLoaded(this.AdReward);\n\tv13 = v11 == 0;\n\tif (v13) goto L_FFFFFFFF;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool IsRewardAdLoaded()
	{
		if (rewardedAdEnabled && AdReward != null && AdReward.IsLoaded())
		{
			return true;
		}
		return false;
	}

	[Token(Token = "0x600000B")]
	[Address(RVA = "0xBF4A78", Offset = "0xBF4A78", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv14 = GoogleMobileAds.Api.AdRequest+Builder;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = \"npa\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A355A5]) = v35;\nL_0015:\n\tv37 = new GoogleMobileAds.Api.AdRequest+Builder();\n\tGoogleMobileAds.Api.AdRequest+Builder::.ctor(v37);\n\tv37 = GoogleMobileAds.Api.AdRequest+Builder::TagForChildDirectedTreatment(v37, 0);\n\tv74 = UnityEngine.PlayerPrefs::GetInt(\"npa\", 1);\n\tv61 = System.Int32::ToString(&v74 @ X0_v9 (System.Int32));\n\tv37 = GoogleMobileAds.Api.AdRequest+Builder::AddExtra(v37, \"npa\", v61);\n\treturnVal2 = GoogleMobileAds.Api.AdRequest+Builder::Build(v37);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private AdRequest CreateAdRequest()
	{
		AdRequest.Builder builder = new AdRequest.Builder();
		builder = builder.TagForChildDirectedTreatment(tagForChildDirectedTreatment: false);
		string value = PlayerPrefs.GetInt("npa", 1).ToString();
		builder = builder.AddExtra("npa", value);
		return builder.Build();
	}

	[Token(Token = "0x600000C")]
	[Address(RVA = "0xBF4B40", Offset = "0xBF4B40", Length = "0xE0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = GoogleMobileAds.Api.AdSize;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = GoogleMobileAds.Api.BannerView;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A355A6]) = v40;\nL_0017:\n\tv42 = ~this.bannerAdEnabled;\n\tif (v42) goto L_004B;\n\tv48 = this.AdBanner == 0;\n\tif (v48) goto L_0027;\n\tGoogleMobileAds.Api.BannerView::Destroy(this.AdBanner);\nL_0027:\n\tgoto L_002D;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v57, v56, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv97 = GoogleMobileAds.Api.AdSize;\nL_002D:\n\tv99 = new GoogleMobileAds.Api.BannerView();\n\tGoogleMobileAds.Api.BannerView::.ctor(v99, this.idBanner, v92.Banner, 1);\n\tthis.AdBanner = v99;\n\tv100 = AdManager::CreateAdRequest(v99);\n\tGoogleMobileAds.Api.BannerView::LoadAd(v99, v100);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ShowBanner()
	{
		if (bannerAdEnabled)
		{
			if (AdBanner != null)
			{
				AdBanner.Destroy();
			}
			BannerView bannerView = (AdBanner = new BannerView(idBanner, AdSize.Banner, AdPosition.Bottom));
			AdRequest request = ((AdManager)(object)bannerView).CreateAdRequest();
			bannerView.LoadAd(request);
		}
	}

	[Token(Token = "0x600000D")]
	[Address(RVA = "0xBF4C20", Offset = "0xBF4C20", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = \"npa\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355A7]) = v34;\nL_0014:\n\tUnityEngine.PlayerPrefs::SetInt(\"npa\", 0xFFFFFFFF);\n\tAdManager::LoadLevel(1);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void AdsButtonPressed()
	{
		PlayerPrefs.SetInt("npa", -1);
		LoadLevel(1);
	}

	[Token(Token = "0x600000E")]
	[Address(RVA = "0xBF4C70", Offset = "0xBF4C70", Length = "0xC8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = UnityEngine.SceneManagement.SceneManager;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv88 = \"LEVELLOADER LoadLevel Error: invalid scene specified\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A355A8]) = v34;\nL_0016:\n\tv35 = levelIndex & 0x80000000;\n\tv36 = v35 == 0;\n\tv37 = ~v36;\n\tif (v37) goto L_0047;\n\tgoto L_0023;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0023:\n\tv75 = UnityEngine.SceneManagement.SceneManager::get_sceneCountInBuildSettings();\n\tv48 = v75 <= levelIndex;\n\tif (v48) goto L_0047;\n\tgoto L_003D;\n\tv127 = \"il2cpp_codegen_runtime_class_init\"(v102, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003D:\n\tUnityEngine.SceneManagement.SceneManager::LoadScene(levelIndex);\n\treturn;\nL_0047:\n\tgoto L_004F;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v82, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_004F:\n\tUnityEngine.Debug::LogWarning(\"LEVELLOADER LoadLevel Error: invalid scene specified\");\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void LoadLevel(int levelIndex)
	{
		//IL_0063: Expected I4, but got I8
		if ((int)(levelIndex & 0x80000000L) == 0)
		{
			int sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;
			if (sceneCountInBuildSettings > levelIndex)
			{
				SceneManager.LoadScene(levelIndex);
				return;
			}
		}
		Debug.LogWarning("LEVELLOADER LoadLevel Error: invalid scene specified");
	}

	[Token(Token = "0x600000F")]
	[Address(RVA = "0xBF497C", Offset = "0xBF497C", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.AdBanner == 0;\n\tif (v2) goto L_0006;\n\tGoogleMobileAds.Api.BannerView::Destroy(this.AdBanner);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DestroyBannerAd()
	{
		if (AdBanner != null)
		{
			AdBanner.Destroy();
		}
	}

	[Token(Token = "0x6000010")]
	[Address(RVA = "0xBF4D38", Offset = "0xBF4D38", Length = "0xDC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = System.EventHandler`1<System.EventArgs>;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = GoogleMobileAds.Api.InterstitialAd;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A355A9]) = v46;\nL_0021:\n\tv49 = new GoogleMobileAds.Api.InterstitialAd();\n\tGoogleMobileAds.Api.InterstitialAd::.ctor(v49, this.idInterstitial);\n\tthis.AdInterstitial = v49;\n\tv59 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v59, this, Il2CppMethodInfo);\n\tGoogleMobileAds.Api.InterstitialAd::add_OnAdClosed(v49, v59);\n\tv71 = AdManager::CreateAdRequest(v49);\n\tGoogleMobileAds.Api.InterstitialAd::LoadAd(this.AdInterstitial, v71);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RequestInterstitialAd()
	{
		InterstitialAd interstitialAd = (AdInterstitial = new InterstitialAd(idInterstitial));
		EventHandler<EventArgs> value = HandleInterstitialAdClosed;
		interstitialAd.OnAdClosed += value;
		AdRequest request = ((AdManager)(object)interstitialAd).CreateAdRequest();
		AdInterstitial.LoadAd(request);
	}

	[Token(Token = "0x6000011")]
	[Address(RVA = "0xBF4E14", Offset = "0xBF4E14", Length = "0x44")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~this.interstitialAdEnabled;\n\tif (v6) goto L_001B;\n\tv9 = this.AdInterstitial == 0;\n\tif (v9) goto L_001B;\n\tv14 = GoogleMobileAds.Api.InterstitialAd::IsLoaded(this.AdInterstitial);\n\tv17 = v14 == 0;\n\tif (v17) goto L_001B;\n\tGoogleMobileAds.Api.InterstitialAd::Show(this.AdInterstitial);\n\treturn;\nL_001B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ShowInterstitialAd()
	{
		if (interstitialAdEnabled && AdInterstitial != null && AdInterstitial.IsLoaded())
		{
			AdInterstitial.Show();
		}
	}

	[Token(Token = "0x6000012")]
	[Address(RVA = "0xBF4E58", Offset = "0xBF4E58", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.interstitialAdEnabled;\n\tif (v4) goto L_FFFFFFFF;\n\tv6 = this.AdInterstitial == 0;\n\tif (v6) goto L_FFFFFFFF;\n\tv11 = GoogleMobileAds.Api.InterstitialAd::IsLoaded(this.AdInterstitial);\n\tv13 = v11 == 0;\n\tif (v13) goto L_FFFFFFFF;\n\tgoto L_0012;\nL_0012:\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool IsInterstitialAdLoad()
	{
		if (interstitialAdEnabled && AdInterstitial != null && AdInterstitial.IsLoaded())
		{
			return true;
		}
		return false;
	}

	[Token(Token = "0x6000013")]
	[Address(RVA = "0xBF4990", Offset = "0xBF4990", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.AdInterstitial == 0;\n\tif (v2) goto L_0006;\n\tGoogleMobileAds.Api.InterstitialAd::Destroy(this.AdInterstitial);\n\treturn;\nL_0006:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void DestroyInterstitialAd()
	{
		if (AdInterstitial != null)
		{
			AdInterstitial.Destroy();
		}
	}

	[Token(Token = "0x6000014")]
	[Address(RVA = "0xBF4E8C", Offset = "0xBF4E8C", Length = "0x138")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv62 = System.EventHandler`1<System.EventArgs>;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv69 = GoogleMobileAds.Api.RewardedAd;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A355AA]) = v46;\nL_0027:\n\tv49 = new GoogleMobileAds.Api.RewardedAd();\n\tGoogleMobileAds.Api.RewardedAd::.ctor(v49, this.idReward);\n\tthis.AdReward = v49;\n\tv60 = new System.EventHandler`1<System.EventArgs>();\n\tSystem.EventHandler`1<System.EventArgs>::.ctor(v60, this, Il2CppMethodInfo);\n\tGoogleMobileAds.Api.RewardedAd::add_OnAdClosed(v49, v60);\n\tv87 = new System.EventHandler`1<GoogleMobileAds.Api.Reward>();\n\tSystem.EventHandler`1<GoogleMobileAds.Api.Reward>::.ctor(v87, this, Il2CppMethodInfo);\n\tGoogleMobileAds.Api.RewardedAd::add_OnUserEarnedReward(this.AdReward, v87);\n\tv88 = AdManager::CreateAdRequest(this.AdReward);\n\tGoogleMobileAds.Api.RewardedAd::LoadAd(this.AdReward, v88);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RequestRewardAd()
	{
		RewardedAd rewardedAd = (AdReward = new RewardedAd(idReward));
		EventHandler<EventArgs> value = HandleOnRewardedAdClosed;
		rewardedAd.OnAdClosed += value;
		EventHandler<Reward> value2 = HandleOnRewardedAdWatched;
		AdReward.OnUserEarnedReward += value2;
		AdRequest request = ((AdManager)(object)AdReward).CreateAdRequest();
		AdReward.LoadAd(request);
	}

	[Token(Token = "0x6000015")]
	[Address(RVA = "0xBF4FC4", Offset = "0xBF4FC4", Length = "0x94")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = \"Reward based video ad is not ready yet\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A355AB]) = v33;\nL_0011:\n\tv35 = ~this.rewardedAdEnabled;\n\tif (v35) goto L_0029;\n\tv42 = GoogleMobileAds.Api.RewardedAd::IsLoaded(this.AdReward);\n\tv58 = v42 == 0;\n\tif (v58) goto L_002B;\n\tGoogleMobileAds.Api.RewardedAd::Show(this.AdReward);\n\treturn;\nL_0029:\n\treturn;\nL_002B:\n\tAdManager::RequestRewardAd(this);\n\tAdManager::ShowToast(this, \"Reward based video ad is not ready yet\");\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ShowRewardAd()
	{
		if (rewardedAdEnabled)
		{
			if (AdReward.IsLoaded())
			{
				AdReward.Show();
				return;
			}
			RequestRewardAd();
			ShowToast("Reward based video ad is not ready yet");
		}
	}

	[Token(Token = "0x6000016")]
	[Address(RVA = "0xBF5058", Offset = "0xBF5058", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = GoogleMobileAds.Api.RewardedAd::IsLoaded(this.AdReward);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public bool IsCanShowRewardAD()
	{
		return AdReward.IsLoaded();
	}

	[Token(Token = "0x6000017")]
	[Address(RVA = "0xBF5074", Offset = "0xBF5074", Length = "0x54")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.InteralADAction == 0;\n\tif (v7) goto L_0013;\n\tSystem.Action::Invoke(this.InteralADAction);\n\tv27 = this.InteralADAction == 0;\n\tif (v27) goto L_0013;\n\tSystem.Action::Invoke(this.InteralADAction);\nL_0013:\n\tv39 = this.AdInterstitial == 0;\n\tif (v39) goto L_001B;\n\tGoogleMobileAds.Api.InterstitialAd::Destroy(this.AdInterstitial);\nL_001B:\n\tAdManager::RequestInterstitialAd(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void HandleInterstitialAdClosed(object sender, EventArgs e)
	{
		if (InteralADAction != null)
		{
			InteralADAction();
			if (InteralADAction != null)
			{
				InteralADAction();
			}
		}
		if (AdInterstitial != null)
		{
			AdInterstitial.Destroy();
		}
		RequestInterstitialAd();
	}

	[Token(Token = "0x6000018")]
	[Address(RVA = "0xBF50C8", Offset = "0xBF50C8", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAdManager::RequestRewardAd(this);\n\treturn;\n")]
	private void HandleOnRewardedAdClosed(object sender, EventArgs e)
	{
		RequestRewardAd();
	}

	[Token(Token = "0x6000019")]
	[Address(RVA = "0xBF50CC", Offset = "0xBF50CC", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.RewardAction == 0;\n\tif (v7) goto L_000B;\n\tSystem.Action::Invoke(this.RewardAction);\nL_000B:\n\tthis.RewardAction = 0;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void HandleOnRewardedAdWatched(object sender, Reward e)
	{
		if (RewardAction != null)
		{
			RewardAction();
		}
		RewardAction = null;
	}

	[Token(Token = "0x600001A")]
	[Address(RVA = "0xBF50F8", Offset = "0xBF50F8", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = \"ca-app-pub\";\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355AC]) = v37;\nL_0016:\n\tthis.bannerAdEnabled = 0x101;\n\tthis.rewardedAdEnabled = 1;\n\tthis.idBanner = \"ca-app-pub\";\n\tthis.idInterstitial = \"ca-app-pub\";\n\tthis.idReward = \"ca-app-pub\";\n\tthis._firstInit = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AdManager()
	{
		bannerAdEnabled = true;
		interstitialAdEnabled = true;
		rewardedAdEnabled = true;
		idBanner = "ca-app-pub";
		idInterstitial = "ca-app-pub";
		idReward = "ca-app-pub";
		_firstInit = true;
	}
}
