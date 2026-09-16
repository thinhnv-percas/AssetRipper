using AssetRipperInjected;
using CodeStage.AntiCheat.Storage;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000010")]
public class GameController : MonoBehaviour
{
	[Token(Token = "0x4000030")]
	public static GameController Ins;

	[Token(Token = "0x4000031")]
	[FieldOffset(Offset = "0x20")]
	public GamePlayController gamePlayController;

	[Token(Token = "0x4000032")]
	[FieldOffset(Offset = "0x28")]
	public GameObject tutorialHand;

	[Token(Token = "0x4000033")]
	[FieldOffset(Offset = "0x30")]
	private float resetTime;

	[Token(Token = "0x4000034")]
	[FieldOffset(Offset = "0x38")]
	public Transform[] posList;

	[Token(Token = "0x4000035")]
	[FieldOffset(Offset = "0x40")]
	private Vector3 currentPos;

	[Token(Token = "0x4000036")]
	[FieldOffset(Offset = "0x4C")]
	public bool isTutorialLevel;

	[Token(Token = "0x6000063")]
	[Address(RVA = "0xBF9544", Offset = "0xBF9544", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GameController;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355D1]) = v37;\nL_0015:\n\tv39.Ins = this;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Ins = this;
	}

	[Token(Token = "0x6000064")]
	[Address(RVA = "0xBF9590", Offset = "0xBF9590", Length = "0x2BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv24 = System.Boolean;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv63 = CodeStage.AntiCheat.Storage.ObscuredPrefs;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv85 = SingletonMonoDontDestroy`1<GUIManager>;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv144 = SingletonMonoDontDestroy`1<GameManager>;\n\tv145 = \"il2cpp_codegen_initialize_runtime_metadata\"(v144, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv148 = \"RemoveAds\";\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv172 = \"Level\";\n\tv173 = \"il2cpp_codegen_initialize_runtime_metadata\"(v172, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv176 = \"canVibrate\";\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv179 = \"isSoundOn\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v179, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A355D2]) = v44;\nL_003C:\n\tgoto L_0041;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0041:\n\tv61 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tgoto L_004D;\n\tv73 = v65;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v73, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_004D:\n\tv79 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetInt(\"Level\", 0);\n\tv61.currentLevel = v79;\n\tv90 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv113 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetBool(\"RemoveAds\", 0);\n\tv90.isRemoveAds = v113;\n\tv114 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv185 = v114.currentLevel == 0;\n\tv186 = ~v185;\n\tif (v186) goto L_0083;\n\tthis.isTutorialLevel = 1;\n\tgoto L_0078;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v188, v103, v99, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0078:\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetBool(\"isSoundOn\", 1);\n\tCodeStage.AntiCheat.Storage.ObscuredPrefs::SetBool(\"canVibrate\", 1);\nL_0083:\n\tgoto L_0086;\n\tv210 = \"il2cpp_codegen_runtime_class_init\"(v200, v194, v192, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0086:\n\tv213 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tgoto L_0092;\n\tv216 = v133;\n\tv217 = \"il2cpp_codegen_runtime_class_init\"(v216, v194, v192, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0092:\n\tv115 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetBool(\"isSoundOn\", 0);\n\tv213.isSoundTurnOn = v115;\n\tv222 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tv116 = CodeStage.AntiCheat.Storage.ObscuredPrefs::GetBool(\"canVibrate\", 0);\n\tv222.canVibrate = v116;\n\tv117 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tv227 = v117.isSoundTurnOn;\n\t// 175 Box v232 @ X0_v32 (System.Object), typeof(System.Boolean), &v227 @ X9_v4 (System.Boolean)\n\tgoto L_00BA;\n\tv236 = v233;\n\tv237 = \"il2cpp_codegen_runtime_class_init\"(v236, v229, v101, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00BA:\n\tUnityEngine.Debug::Log(v232);\n\tv136 = this.gamePlayController;\n\tDataController::LoadMap(v136.DataController);\n\tv120 = SingletonMonoDontDestroy`1<GUIManager>::get_Instance();\n\tGUIManager::SetDefaultGUI(v120);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 140 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		int currentLevel = ObscuredPrefs.GetInt("Level");
		instance.currentLevel = currentLevel;
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		bool isRemoveAds = ObscuredPrefs.GetBool("RemoveAds");
		instance2.isRemoveAds = isRemoveAds;
		GameManager instance3 = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance3.currentLevel == 0)
		{
			isTutorialLevel = true;
			ObscuredPrefs.SetBool("isSoundOn", value: true);
			ObscuredPrefs.SetBool("canVibrate", value: true);
		}
		GUIManager instance4 = SingletonMonoDontDestroy<GUIManager>.Instance;
		bool isSoundTurnOn = ObscuredPrefs.GetBool("isSoundOn");
		instance4.isSoundTurnOn = isSoundTurnOn;
		GUIManager instance5 = SingletonMonoDontDestroy<GUIManager>.Instance;
		bool canVibrate = ObscuredPrefs.GetBool("canVibrate");
		instance5.canVibrate = canVibrate;
		GUIManager instance6 = SingletonMonoDontDestroy<GUIManager>.Instance;
		bool isSoundTurnOn2 = instance6.isSoundTurnOn;
		object message = isSoundTurnOn2;
		Debug.Log(message);
		GamePlayController gamePlayController = this.gamePlayController;
		gamePlayController.DataController.LoadMap();
		GUIManager instance7 = SingletonMonoDontDestroy<GUIManager>.Instance;
		instance7.SetDefaultGUI();
	}

	[Token(Token = "0x6000065")]
	[Address(RVA = "0xBF9DB0", Offset = "0xBF9DB0", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.posList;\n\tv14 = UnityEngine.Component::get_transform(v4[0]);\n\tv50 = UnityEngine.Transform::get_position(v14);\n\tthis.currentPos = v50;\n\tthis.currentPos.y = v50.y;\n\tthis.currentPos.z = v50.z;\n\treturn;\n\tv22 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetHandToCurrentBox()
	{
		Transform[] array = posList;
		Transform transform = array[0].transform;
		Vector3 vector = (currentPos = transform.position);
		currentPos.y = vector.y;
		currentPos.z = vector.z;
	}

	[Token(Token = "0x6000066")]
	[Address(RVA = "0xBF9DFC", Offset = "0xBF9DFC", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.posList;\n\tv24 = UnityEngine.Component::get_transform(v4[1]);\n\tv87 = UnityEngine.Transform::get_position(v24);\n\tthis.currentPos = v87;\n\tthis.currentPos.y = v87.y;\n\tthis.currentPos.z = v87.z;\n\treturn;\n\tv50 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetHandToSelectedBox()
	{
		Transform[] array = posList;
		Transform transform = array[1].transform;
		Vector3 vector = (currentPos = transform.position);
		currentPos.y = vector.y;
		currentPos.z = vector.z;
	}

	[Token(Token = "0x6000067")]
	[Address(RVA = "0xBF9E4C", Offset = "0xBF9E4C", Length = "0x4C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.posList;\n\tv14 = UnityEngine.Component::get_transform(v4[0]);\n\tv50 = UnityEngine.Transform::get_position(v14);\n\tthis.currentPos = v50;\n\tthis.currentPos.y = v50.y;\n\tthis.currentPos.z = v50.z;\n\treturn;\n\tv22 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void SetupTutorial()
	{
		Transform[] array = posList;
		Transform transform = array[0].transform;
		Vector3 vector = (currentPos = transform.position);
		currentPos.y = vector.y;
		currentPos.z = vector.z;
	}

	[Token(Token = "0x6000068")]
	[Address(RVA = "0xBF9E98", Offset = "0xBF9E98", Length = "0xD8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = UnityEngine.GameObject::get_transform(this.tutorialHand);\n\tv23 = this.resetTime <= 0;\n\tif (v23) goto L_0043;\n\tv120 = UnityEngine.Transform::get_position(v20);\n\tv133 = UnityEngine.Time::get_deltaTime();\n\tv137 = UnityEngine.Time::get_deltaTime();\n\tv139 = v133 * 0.5f;\n\tv152 = v137 * 0.5f;\n\tv153 = v120 - v139;\n\tv144 = v120.y + v152;\n\t// 53 MakeStruct v138 @ AGGBFDF20_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v153 @ V0_v7 (System.Single), v144 @ V1_v6 (System.Single), v120.z (System.Single)\n\tUnityEngine.Transform::set_position(v20, v138);\n\tv155 = UnityEngine.Time::get_deltaTime();\n\tv96 = this.resetTime - v155;\n\tgoto L_0046;\nL_0043:\n\t// 67 MakeStruct v126 @ AGGBFDF4C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.currentPos (UnityEngine.Vector3), this.currentPos.y (System.Single), this.currentPos.z (System.Single)\n\tUnityEngine.Transform::set_position(v20, v126);\nL_0046:\n\tthis.resetTime = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void MoveHand()
	{
		Transform transform = tutorialHand.transform;
		float num3;
		if (resetTime > 0f)
		{
			Vector3 position = transform.position;
			float deltaTime = Time.deltaTime;
			float deltaTime2 = Time.deltaTime;
			float num = deltaTime * 0.5f;
			float num2 = deltaTime2 * 0.5f;
			float x = position.x - num;
			float y = position.y + num2;
			Vector3 position2 = default(Vector3);
			position2.x = x;
			position2.y = y;
			position2.z = position.z;
			transform.position = position2;
			float deltaTime3 = Time.deltaTime;
			num3 = resetTime - deltaTime3;
		}
		else
		{
			Vector3 position3 = default(Vector3);
			position3.x = currentPos.x;
			position3.y = currentPos.y;
			position3.z = currentPos.z;
			transform.position = position3;
			num3 = 1f;
		}
		resetTime = num3;
	}

	[Token(Token = "0x6000069")]
	[Address(RVA = "0xBF9F70", Offset = "0xBF9F70", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = UnityEngine.Object;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A355D3]) = v33;\nL_0011:\n\tv35 = ~this.isTutorialLevel;\n\tif (v35) goto L_0027;\n\tgoto L_001F;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001F:\n\tv48 = UnityEngine.Object::op_Equality(this.tutorialHand, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002D;\nL_0027:\n\treturn;\nL_002D:\n\tGameController::MoveHand(this);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Update()
	{
		if (isTutorialLevel && !(tutorialHand == null))
		{
			MoveHand();
		}
	}

	[Token(Token = "0x600006A")]
	[Address(RVA = "0xBF9FF0", Offset = "0xBF9FF0", Length = "0x10")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.resetTime = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public GameController()
	{
		resetTime = 1f;
	}
}
