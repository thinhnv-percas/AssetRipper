using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Lean.Pool;
using UnityEngine;
using Zitga.CsvTools.Tutorials;

[Token(Token = "0x2000022")]
public class DataController : MonoBehaviour
{
	[SerializeField]
	[Token(Token = "0x4000078")]
	[FieldOffset(Offset = "0x20")]
	private List<Stack<int>> listCols;

	[SerializeField]
	[Token(Token = "0x4000079")]
	[FieldOffset(Offset = "0x28")]
	private GameObject boxPrefab;

	[SerializeField]
	[Token(Token = "0x400007A")]
	[FieldOffset(Offset = "0x30")]
	private GameObject testCubesHolder;

	[SerializeField]
	[Token(Token = "0x400007B")]
	[FieldOffset(Offset = "0x38")]
	private float cubeSize;

	[Token(Token = "0x400007C")]
	[FieldOffset(Offset = "0x40")]
	private List<int> randomList;

	[Token(Token = "0x400007D")]
	[FieldOffset(Offset = "0x48")]
	private GamePlayController gpc;

	[Token(Token = "0x60000CD")]
	[Address(RVA = "0xBFD258", Offset = "0xBFD258", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GameController;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, totalBox, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A355F4]) = v37;\nL_0015:\n\tv40 = v39.Ins;\n\tv42 = v40.gamePlayController;\n\tv61 = totalBox <= 6;\n\tif (v61) goto L_0037;\n\tGraphicController::Set2RowBackground(v42.GraphicController);\n\treturn;\nL_0037:\n\tGraphicController::Set1RowBackground(v42.GraphicController);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void SetBackground(int totalBox)
	{
		GameController ins = GameController.Ins;
		GamePlayController gamePlayController = ins.gamePlayController;
		if (totalBox > 6)
		{
			gamePlayController.GraphicController.Set2RowBackground();
		}
		else
		{
			gamePlayController.GraphicController.Set1RowBackground();
		}
	}

	[Token(Token = "0x60000CE")]
	[Address(RVA = "0xBFD33C", Offset = "0xBFD33C", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = GameController;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355F5]) = v37;\nL_0015:\n\tv40 = v39.Ins;\n\tthis.gpc = v40.gamePlayController;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		GameController ins = GameController.Ins;
		gpc = ins.gamePlayController;
	}

	[Token(Token = "0x60000CF")]
	[Address(RVA = "0xBF984C", Offset = "0xBF984C", Length = "0x1A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv20 = GameController;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv46 = UnityEngine.Object;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv115 = Il2CppMethodInfo;\n\tv116 = \"il2cpp_codegen_initialize_runtime_metadata\"(v115, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv122 = SingletonMonoDontDestroy`1<GameManager>;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A355F6]) = v40;\nL_001F:\n\tv43 = v42.Ins;\n\tv49 = ~v43.isTutorialLevel;\n\tif (v49) goto L_002E;\n\tGameController::SetupTutorial(v43);\n\tgoto L_005D;\nL_002E:\n\tgoto L_0034;\n\tv123 = v118;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v123, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0034:\n\tv93 = UnityEngine.Object::op_Inequality(v43.tutorialHand, 0);\n\tv182 = v93 == 0;\n\tif (v182) goto L_005D;\n\tv107 = v197.Ins;\n\tv95 = UnityEngine.GameObject::get_transform(v107.tutorialHand);\n\tv96 = UnityEngine.Transform::get_parent(v95);\n\tv211 = UnityEngine.Component::get_gameObject(v96);\n\tgoto L_0054;\n\tv213 = v184;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v213, v210, v78, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0054:\n\tUnityEngine.Object::Destroy(v211);\nL_005D:\n\tgoto L_0060;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v189, v84, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0060:\n\tv97 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv52 = v97.currentLevel <= 0x1D;\n\tif (v52) goto L_0099;\n\tgoto L_0078;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v201, v84, v79, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0078:\n\tv98 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv132 = v98.currentLevel <= 0x31;\n\tif (v132) goto L_00A1;\n\tDataController::GenarateRandomMap(this);\n\treturn;\nL_0099:\n\tDataController::GenarateDataMap(this);\n\treturn;\nL_00A1:\n\tDataController::GenarateRandomDataMap(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LoadMap()
	{
		GameController ins = GameController.Ins;
		if (ins.isTutorialLevel)
		{
			ins.SetupTutorial();
		}
		else if (ins.tutorialHand != null)
		{
			GameController ins2 = GameController.Ins;
			Transform transform = ins2.tutorialHand.transform;
			Transform parent = transform.parent;
			GameObject obj = parent.gameObject;
			UnityEngine.Object.Destroy(obj);
		}
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		if (instance.currentLevel > 29)
		{
			GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
			if (instance2.currentLevel > 49)
			{
				GenarateRandomMap();
			}
			else
			{
				GenarateRandomDataMap();
			}
		}
		else
		{
			GenarateDataMap();
		}
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0xBFE624", Offset = "0xBFE624", Length = "0xF0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv121 = Il2CppMethodInfo;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv175 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A355F7]) = v42;\nL_001D:\n\tv106 = this.randomList;\nL_0031:\n\tv56 = v155 >= v106._size;\n\tif (v56) goto L_0054;\n\tv114 = this.gpc;\n\tv177 = System.Collections.Generic.List`1<System.Int32>::GetRange(v106, v155, v114.maxValueCols);\n\tv179 = System.Linq.Enumerable::Distinct(v177);\n\tv107 = System.Linq.Enumerable::Count(v179);\n\tv77 = v107 == 1;\n\tif (v77) goto L_0054;\n\tv115 = this.gpc;\n\tv106 = this.randomList;\n\tv116 = v115.maxValueCols + v155;\n\tv181 = this.randomList == 0;\n\tv109 = ~v181;\n\tif (v109) goto L_0031;\n\tthrow System.NullReferenceException;\nL_0054:\n\tv158 = v155 - v106._size;\n\tv159 = v158 < 0;\n\tv161 = v155 ^ v106._size;\n\tv162 = v155 ^ v158;\n\tv163 = v161 & v162;\n\tv164 = v163 < 0;\n\tv171 = v159 == v164;\n\treturn v171;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private bool availableRandomList()
	{
		List<int> list = randomList;
		int num = 0;
		while (num < list.Count)
		{
			GamePlayController gamePlayController = gpc;
			List<int> range = list.GetRange(num, gamePlayController.maxValueCols);
			IEnumerable<int> source = range.Distinct();
			int num2 = source.Count();
			if (num2 == 1)
			{
				break;
			}
			GamePlayController gamePlayController2 = gpc;
			list = randomList;
			int num3 = gamePlayController2.maxValueCols + num;
			bool flag = randomList == null;
			bool flag2 = !flag;
			num = num3;
			if (!flag2)
			{
				throw new NullReferenceException();
			}
		}
		int num4 = num - list.Count;
		bool flag3 = num4 < 0;
		int num5 = num ^ list.Count;
		int num6 = num ^ num4;
		int num7 = num5 & num6;
		bool flag4 = num7 < 0;
		return flag3 == flag4;
	}

	[Token(Token = "0x60000D1")]
	[Address(RVA = "0xBFE714", Offset = "0xBFE714", Length = "0x304")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv270 = Il2CppMethodInfo;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv327 = System.Collections.Generic.List`1<System.Int32>;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v327, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A355F8]) = v48;\nL_0029:\n\tv50 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v50);\n\tv306 = this.gpc;\n\tthis.randomList = v50;\n\tv299 = v306.maxCols;\n\tv77 = v306.maxCols < 1;\n\tif (v77) goto L_009E;\nL_0044:\n\tv407 = v407 + 1;\n\tv138 = v407 >= v247.maxValueCols;\n\tif (v138) goto L_0079;\n\tv226 = this.randomList;\n\tv208 = v226._items;\n\tv130 = v226._version + 1;\n\tv226._version = v130;\n\tv131 = v226._size;\n\tv448 = v226._size < v208.Length;\n\tv200 = ~v448;\n\tif (v200) goto L_0073;\n\tv120 = v226._size + 1;\n\tv226._size = v120;\n\tv208[v131 @ X11_v11 (System.Int32)] = v256;\n\tv456 = v247 == 0;\n\tv236 = ~v456;\n\tif (v236) goto L_0044;\n\tgoto L_013A;\nL_0073:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(v226, v256);\n\tv247 = this.gpc;\n\tv460 = this.gpc == 0;\n\tv237 = ~v460;\n\tif (v237) goto L_0044;\n\tgoto L_013A;\nL_0079:\n\tv299 = v247.maxCols;\n\tv263 = v263 + 1;\n\tv279 = v247.numberColors - 1;\n\tv275 = v256 < v279;\n\tif (v275) goto L_008B;\n\tgoto L_0097;\nL_008B:\n\tv256 = v256 + 1;\nL_0097:\n\tv282 = v263 < v299;\n\tif (v282) goto L_FFFFFFFF;\nL_009E:\n\tv314 = v306.numberColors * v299;\n\tv325 = v314 < 1;\n\tif (v325) goto L_012C;\n\tv83 = v314 + 1;\nL_00AC:\n\tv257 = this.randomList;\n\tv436 = UnityEngine.Random::Range(0, *([v257 @ X20_v11 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]));\n\tv443 = System.Linq.Enumerable::ElementAt(v257, v436);\n\tv265 = this.randomList;\n\tv228 = System.Linq.Enumerable::ElementAt(this.randomList, v443);\n\tv250 = *([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+10]);\n\tv122 = *([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]) + 1;\n\t*([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]) = v122;\n\tv462 = *([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) < *([v250 @ X8_v15+18]);\n\tv202 = ~v462;\n\tif (v202) goto L_00DD;\n\tv464 = *([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) + 1;\n\tv465 = *([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) << 2;\n\tv466 = v250 + v465;\n\t*([v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) = v464;\n\t*([v466 @ X8_v19+20]) = v228;\n\tgoto L_00E3;\nL_00DD:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(this.randomList, v228);\nL_00E3:\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.randomList, v443);\n\tv83 = v83 - 1;\n\tv354 = v83 > 1;\n\tif (v354) goto L_00AC;\n\tgoto L_012C;\nL_00F3:\n\tv259 = this.randomList;\n\tv447 = UnityEngine.Random::Range(0, *([v259 @ X20_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]));\n\tv455 = System.Linq.Enumerable::ElementAt(v259, v447);\n\tv267 = this.randomList;\n\tv231 = System.Linq.Enumerable::ElementAt(this.randomList, v455);\n\tv253 = *([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+10]);\n\tv125 = *([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]) + 1;\n\t*([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]) = v125;\n\tv471 = *([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) < *([v253 @ X8_v9+18]);\n\tv204 = ~v471;\n\tif (v204) goto L_0124;\n\tv473 = *([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) + 1;\n\tv474 = *([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) << 2;\n\tv475 = v253 + v474;\n\t*([v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]) = v473;\n\t*([v475 @ X8_v13+20]) = v231;\n\tgoto L_012A;\nL_0124:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(this.randomList, v231);\nL_012A:\n\tSystem.Collections.Generic.List`1<System.Int32>::RemoveAt(this.randomList, v455);\nL_012C:\n\tv230 = DataController::availableRandomList(this);\n\tv397 = v230 == 0;\n\tif (v397) goto L_00F3;\n\treturn;\nL_013A:\n\tthrow System.NullReferenceException;\n// 210 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void setUpRandomList()
	{
		//IL_03ea: Expected O, but got I
		//IL_0400: Expected O, but got I
		//IL_0285: Expected O, but got I
		//IL_029b: Expected O, but got I
		//IL_0457: Expected O, but got I
		//IL_047b: Expected O, but got I
		//IL_02f2: Expected O, but got I
		//IL_0316: Expected O, but got I
		List<int> list = new List<int>();
		GamePlayController gamePlayController = gpc;
		randomList = list;
		int maxCols = gamePlayController.maxCols;
		if (gamePlayController.maxCols >= 1)
		{
			GamePlayController gamePlayController2 = gamePlayController;
			int num = 0;
			int num2 = 0;
			bool flag;
			do
			{
				int num3 = -1;
				while (true)
				{
					num3++;
					if (num3 >= gamePlayController2.maxValueCols)
					{
						break;
					}
					List<int> list2 = randomList;
					int[] items = list2._items;
					int version = list2._version + 1;
					list2._version = version;
					int count = list2.Count;
					if (list2.Count < items.Length)
					{
						int size = list2.Count + 1;
						list2._size = size;
						items[count] = num;
						if ((object)gamePlayController2 != null)
						{
							continue;
						}
					}
					else
					{
						list2.Add(num);
						gamePlayController2 = gpc;
						if ((object)gpc != null)
						{
							continue;
						}
					}
					throw new NullReferenceException();
				}
				maxCols = gamePlayController2.maxCols;
				num2++;
				int num4 = gamePlayController2.numberColors - 1;
				num = ((num < num4) ? (num + 1) : 0);
				flag = num2 < maxCols;
				gamePlayController = gamePlayController2;
			}
			while (flag);
		}
		int num5 = gamePlayController.numberColors * maxCols;
		if (num5 >= 1)
		{
			int num6 = num5 + 1;
			do
			{
				IEnumerable<int> source = randomList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X20_v11 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
				int index = UnityEngine.Random.Range(0, 0);
				int index2 = source.ElementAt(index);
				IEnumerable<int> enumerable = randomList;
				int item = randomList.ElementAt(index2);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+10]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]");
				object obj2 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X8_v15+18]");
				if (num7 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
					object obj3 = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v265 @ X21_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
					int num8 = (int)((nint)0 << 2);
					object obj4 = (nint)obj + num8;
				}
				else
				{
					randomList.Add(item);
				}
				randomList.RemoveAt(index2);
				num6--;
			}
			while (num6 > 1);
		}
		while (!availableRandomList())
		{
			IEnumerable<int> source2 = randomList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X20_v8 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
			int index3 = UnityEngine.Random.Range(0, 0);
			int index4 = source2.ElementAt(index3);
			IEnumerable<int> enumerable2 = randomList;
			int item2 = randomList.ElementAt(index4);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+10]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+1C]");
			object obj6 = (nint)0 + (nint)1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v253 @ X8_v9+18]");
			if (num9 < 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
				object obj7 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X21_v6 (System.Collections.Generic.IEnumerable`1<System.Int32>)+18]");
				int num10 = (int)((nint)0 << 2);
				object obj8 = (nint)obj5 + num10;
			}
			else
			{
				randomList.Add(item2);
			}
			randomList.RemoveAt(index4);
		}
	}

	[Token(Token = "0x60000D2")]
	[Address(RVA = "0xBFD398", Offset = "0xBFD398", Length = "0x628")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0055;\n\tv50 = GameController;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv80 = GameHelper;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv91 = Lean.Pool.LeanPool;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv321 = Il2CppMethodInfo;\n\tv322 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv378 = Il2CppMethodInfo;\n\tv379 = \"il2cpp_codegen_initialize_runtime_metadata\"(v378, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv381 = Il2CppMethodInfo;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv458 = System.Collections.Generic.List`1<Box>;\n\tv459 = \"il2cpp_codegen_initialize_runtime_metadata\"(v458, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv462 = System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>;\n\tv463 = \"il2cpp_codegen_initialize_runtime_metadata\"(v462, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv466 = System.Math;\n\tv467 = \"il2cpp_codegen_initialize_runtime_metadata\"(v466, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv469 = Il2CppMethodInfo;\n\tv470 = \"il2cpp_codegen_initialize_runtime_metadata\"(v469, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv473 = SingletonMonoDontDestroy`1<GameManager>;\n\tv474 = \"il2cpp_codegen_initialize_runtime_metadata\"(v473, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv476 = Il2CppMethodInfo;\n\tv477 = \"il2cpp_codegen_initialize_runtime_metadata\"(v476, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv479 = Il2CppMethodInfo;\n\tv480 = \"il2cpp_codegen_initialize_runtime_metadata\"(v479, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv484 = System.Collections.Generic.Stack`1<System.Int32>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v484, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A355F9]) = v70;\nL_0055:\n\tgoto L_0058;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_0058:\n\tv85 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv93 = v85.firstLevels;\n\tv315 = v93.firstLevelsDatas;\n\tv282 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv373 = v282.currentLevel;\n\tv216 = v315[v373 @ X8_v7 (System.Int32)];\n\tv283 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv304 = this.gpc;\n\tv471 = v283.currentLevel == 0;\n\tif (v471) goto L_0086;\n\tv304.maxCols = v216.fillBox;\n\tgoto L_008A;\nL_0086:\n\tv304.maxCols = 1;\nL_008A:\n\tDataController::SetBackground(v283, v216.totalBox);\n\tv305 = this.gpc;\n\tv316 = v305.GraphicController;\n\tv284 = new System.Collections.Generic.List`1<Box>();\n\tSystem.Collections.Generic.List`1<Box>::.ctor(v284);\n\tv316.Boxes = v284;\n\tv306 = this.gpc;\n\tv205 = v216.totalBox - 1;\n\tv492 = v205 / v306.maxBoxPerRow;\n\tv200 = v492 + 1;\n\tv306.numberCols = v216.totalBox;\n\tv306.numberRows = v200;\n\tv262 = v216.totalBox - 7;\n\tv256 = v262 < 0;\n\tv244 = v216.totalBox ^ 7;\n\tv238 = v216.totalBox ^ v262;\n\tv232 = v244 & v238;\n\tv226 = v232 < 0;\n\tv306.numberColors = v216.fillBox;\n\tv496 = v216.totalBox & 1;\n\tv497 = v256 == v226;\n\tv196 = ~v497;\n\tv191 = ~v196;\n\tif (v191) goto L_FFFFFFFF;\n\tgoto L_00C1;\nL_00C1:\n\tgoto L_00CF;\n\tv504 = \"il2cpp_codegen_runtime_class_init\"(v495, v212, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_00CF:\n\tgoto L_00D2;\n\tv514 = \"il2cpp_codegen_runtime_class_init\"(v508, v212, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_00D2:\n\tv285 = new System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::.ctor(v285);\n\tv308 = this.gpc;\n\tthis.listCols = v285;\n\tv517 = v216.totalBox / v200;\n\tv183 = v517 + v186;\n\tv518 = v183 + 1;\n\t// 221 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv521 = v59 / v518;\nL_00F2:\n\tv595 = v164 >= v308.numberCols;\n\tif (v595) goto L_0250;\n\tv599 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v599);\n\tgoto L_0105;\n\tv653 = \"il2cpp_codegen_runtime_class_init\"(v648, v647, v534, v54, v55, v56, v57, v58, v547, v548, v543, v539, v538, v537, v536, v66);\n\tv655 = GameHelper;\nL_0105:\n\tv656 = *([v654 @ X0_v28 (Il2CppClass<GameHelper>)+B8]);\n\tv669 = v216.totalBox <= 6;\n\tif (v669) goto L_014F;\n\tv644 = this.gpc;\n\tv813 = v644.numberCols;\n\tv685 = v644.numberCols < 0;\n\tv688 = v644.numberCols ^ v644.numberCols;\n\tv689 = v644.numberCols & v688;\n\tv690 = v689 < 0;\n\tv691 = v685 == v690;\n\tv692 = ~v691;\n\tv693 = ~v692;\n\tif (v693) goto L_012E;\n\tv813 = v813 + 1;\n\tgoto L_012E;\nL_012E:\n\tv778 = v829.Ins;\n\tv771 = v778.gamePlayController;\n\tv772 = v771.GraphicController;\n\tv851 = v813 >> 1;\n\tv814 = v851 & 0x7FFFFFFF;\n\tv704 = v164 <= v814;\n\tif (v704) goto L_015D;\n\tv832 = v772.posRow2_2;\n\tv866 = v772.posRow2_2 == 0;\n\tv794 = ~v866;\n\tif (v794) goto L_0160;\n\tgoto L_0235;\nL_014F:\n\tv676 = v675.Ins;\n\tv815 = v676.gamePlayController;\n\tv816 = v815.GraphicController;\n\tv832 = v816.posRow1;\n\tv830 = v816.posRow1 == 0;\n\tv797 = ~v830;\n\tif (v797) goto L_0160;\n\tgoto L_0235;\nL_015D:\n\tv832 = v772.posRow1_2;\nL_0160:\n\tv835 = v164 / v183;\n\tv836 = v835 * v183;\n\tv837 = v164 - v836;\n\tv839 = v837 + 1;\n\tv840 = *([v656 @ X8_v22 (Il2CppStaticFields<GameHelper>)+8]) + 1f;\n\tv843 = v839 * 0;\n\tv158 = v840 + v843;\n\tv845 = UnityEngine.Transform::get_position(v832);\n\tgoto L_0186;\n\tv855 = v310;\n\tv856 = \"il2cpp_codegen_initialize_runtime_metadata\"(v855, v844, v534, v54, v55, v56, v57, v58, v845, v846, v847, v539, v538, v537, v536, v66);\n\tv859 = 1;\n\t*([1A3551A]) = v859;\nL_0186:\n\tgoto L_018C;\n\tv867 = \"il2cpp_codegen_runtime_class_init\"(v863, v844, v534, v54, v55, v56, v57, v58, v845, v846, v847, v539, v538, v537, v536, v66);\nL_018C:\n\tv873 = v521 * v839;\n\tv168 = v656.bottomLeft + v873;\n\t// 407 MakeStruct v126 @ AGGC017F4_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v168 @ V8_v10 (System.Single), v845.y (System.Single), v158 @ V9_v8 (System.Single)\n\tv783 = Lean.Pool.LeanPool::Spawn(this.boxPrefab, v126, v817.identityQuaternion, 0);\n\tv784 = UnityEngine.GameObject::get_transform(v783);\n\t// 421 MakeStruct v118 @ AGGC0181C_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.cubeSize (System.Single), this.cubeSize (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v784, v118);\n\tv785 = UnityEngine.GameObject::get_transform(v783);\n\tv786 = UnityEngine.GameObject::get_transform(this.testCubesHolder);\n\tUnityEngine.Transform::SetParent(v785, v786);\n\tv819 = this.gpc;\n\tv788 = UnityEngine.GameObject::GetComponent(v783);\n\tGraphicController::AddBox(v819.GraphicController, v788);\n\tv706 = v164 >= v216.fillBox;\n\tif (v706) goto L_020C;\n\tv906 = v216.boxes;\nL_01E2:\n\tv822 = v906[v164 @ X26_v6 (System.Int32)];\n\tv823 = v822.box1;\n\tv708 = v185 >= v823.Length;\n\tif (v708) goto L_020C;\n\tSystem.Collections.Generic.Stack`1<System.Int32>::Push(v599, v823[v185 @ X22_v13 (System.Int32)]);\n\tv906 = v216.boxes;\n\tv185 = v185 + 1;\n\tv922 = v216.boxes == 0;\n\tv809 = ~v922;\n\tif (v809) goto L_01E2;\n\tgoto L_0235;\nL_020C:\n\tv579 = this.listCols;\n\tv826 = v579._items;\n\tv710 = v579._version + 1;\n\tv579._version = v710;\n\tv555 = v579._size;\n\tv908 = v579._size < v826.Length;\n\tv575 = ~v908;\n\tif (v575) goto L_022E;\n\tv910 = v579._size + 1;\n\tv579._size = v910;\n\tv82\n// ... truncated")]
	public void GenarateDataMap()
	{
		//IL_02df: Expected I, but got O
		//IL_087f: Expected I, but got O
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		FirstLevels firstLevels = instance.firstLevels;
		FirstLevels.FirstLevelsData[] firstLevelsDatas = firstLevels.firstLevelsDatas;
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		int currentLevel = instance2.currentLevel;
		FirstLevels.FirstLevelsData firstLevelsData = firstLevelsDatas[currentLevel];
		GameManager instance3 = SingletonMonoDontDestroy<GameManager>.Instance;
		GamePlayController gamePlayController = gpc;
		if (instance3.currentLevel != 0)
		{
			gamePlayController.maxCols = firstLevelsData.fillBox;
		}
		else
		{
			gamePlayController.maxCols = 1;
		}
		((DataController)(object)instance3).SetBackground(firstLevelsData.totalBox);
		GamePlayController gamePlayController2 = gpc;
		GraphicController graphicController = gamePlayController2.GraphicController;
		List<Box> boxes = new List<Box>();
		graphicController.Boxes = boxes;
		GamePlayController gamePlayController3 = gpc;
		int num = firstLevelsData.totalBox - 1;
		int num2 = num / gamePlayController3.maxBoxPerRow;
		int num3 = num2 + 1;
		gamePlayController3.numberCols = firstLevelsData.totalBox;
		gamePlayController3.numberRows = num3;
		int num4 = firstLevelsData.totalBox - 7;
		bool flag = num4 < 0;
		int num5 = firstLevelsData.totalBox ^ 7;
		int num6 = firstLevelsData.totalBox ^ num4;
		int num7 = num5 & num6;
		bool flag2 = num7 < 0;
		gamePlayController3.numberColors = firstLevelsData.fillBox;
		int num8 = firstLevelsData.totalBox & 1;
		int num9 = ((flag == flag2) ? num8 : 0);
		List<Stack<int>> list = new List<Stack<int>>();
		GamePlayController gamePlayController4 = gpc;
		listCols = list;
		int num10 = firstLevelsData.totalBox / num3;
		int num11 = num10 + num9;
		int num12 = num11 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
		object obj = default(object);
		int num13 = (int)((nint)obj / num12);
		int num14 = 0;
		Vector3 position2 = default(Vector3);
		Vector3 localScale = default(Vector3);
		while (num14 < gamePlayController4.numberCols)
		{
			Stack<int> stack = new Stack<int>();
			nint num15 = (nint)typeof(GameHelper);
			nint num16 = (nint)GameHelper.bottomLeft;
			Transform transform;
			GamePlayController gamePlayController5;
			if (firstLevelsData.totalBox > 6)
			{
				gamePlayController5 = gpc;
				int num17 = gamePlayController5.numberCols;
				bool flag3 = gamePlayController5.numberCols < 0;
				int num18 = gamePlayController5.numberCols ^ gamePlayController5.numberCols;
				int num19 = gamePlayController5.numberCols & num18;
				bool flag4 = num19 < 0;
				if (flag3 != flag4)
				{
					num17++;
				}
				GameController ins = GameController.Ins;
				GamePlayController gamePlayController6 = ins.gamePlayController;
				GraphicController graphicController2 = gamePlayController6.GraphicController;
				int num20 = num17 >> 1;
				int num21 = num20 & 0x7FFFFFFF;
				if (num14 > num21)
				{
					transform = graphicController2.posRow2_2;
					if ((object)graphicController2.posRow2_2 == null)
					{
						goto IL_0851;
					}
				}
				else
				{
					transform = graphicController2.posRow1_2;
				}
			}
			else
			{
				GameController ins2 = GameController.Ins;
				GamePlayController gamePlayController7 = ins2.gamePlayController;
				GraphicController graphicController3 = gamePlayController7.GraphicController;
				transform = graphicController3.posRow1;
				if ((object)graphicController3.posRow1 == null)
				{
					goto IL_0851;
				}
			}
			int num22 = num14 / num11;
			int num23 = num22 * num11;
			int num24 = num14 - num23;
			int num25 = num24 + 1;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ X8_v22 (Il2CppStaticFields<GameHelper>)+8]");
			float num26 = 0f + 1f;
			int num27 = num25 * 0;
			float z = num26 + (float)num27;
			Vector3 position = transform.position;
			int num28 = num13 * num25;
			float x = GameHelper.bottomLeft.x + (float)num28;
			position2.x = x;
			position2.y = position.y;
			position2.z = z;
			GameObject gameObject = LeanPool.Spawn(boxPrefab, position2, Quaternion.identity);
			Transform transform2 = gameObject.transform;
			localScale.x = cubeSize;
			localScale.y = cubeSize;
			localScale.z = 1f;
			transform2.localScale = localScale;
			Transform transform3 = gameObject.transform;
			Transform parent = testCubesHolder.transform;
			transform3.SetParent(parent);
			GamePlayController gamePlayController8 = gpc;
			Box component = gameObject.GetComponent<Box>();
			gamePlayController8.GraphicController.AddBox(component);
			if (num14 < firstLevelsData.fillBox)
			{
				FirstLevels.Boxes[] boxes2 = firstLevelsData.boxes;
				int num29 = 0;
				while (true)
				{
					FirstLevels.Boxes boxes3 = boxes2[num14];
					int[] box = boxes3.box1;
					if (num29 >= box.Length)
					{
						break;
					}
					stack.Push(box[num29]);
					boxes2 = firstLevelsData.boxes;
					num29++;
					if (firstLevelsData.boxes != null)
					{
						continue;
					}
					goto IL_0851;
				}
			}
			List<Stack<int>> list2 = listCols;
			Stack<int>[] items = list2._items;
			int version = list2._version + 1;
			list2._version = version;
			int count = list2.Count;
			if (list2.Count < items.Length)
			{
				int size = list2.Count + 1;
				list2._size = size;
				items[count] = stack;
			}
			else
			{
				list2.Add(stack);
			}
			gamePlayController5 = gpc;
			num14++;
			bool flag5 = (object)gpc == null;
			bool flag6 = !flag5;
			gamePlayController4 = gpc;
			if (flag6)
			{
				continue;
			}
			goto IL_0851;
			IL_0851:
			throw new NullReferenceException();
		}
		gamePlayController4.GraphicController.SetUp(listCols);
	}

	[Token(Token = "0x60000D3")]
	[Address(RVA = "0xBFD9C0", Offset = "0xBFD9C0", Length = "0x674")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005E;\n\tv50 = GameController;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv80 = GameHelper;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv91 = Lean.Pool.LeanPool;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv330 = Il2CppMethodInfo;\n\tv331 = \"il2cpp_codegen_initialize_runtime_metadata\"(v330, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv380 = Il2CppMethodInfo;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv404 = Il2CppMethodInfo;\n\tv405 = \"il2cpp_codegen_initialize_runtime_metadata\"(v404, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv407 = System.Collections.Generic.List`1<Box>;\n\tv408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv467 = System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>;\n\tv468 = \"il2cpp_codegen_initialize_runtime_metadata\"(v467, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv471 = System.Math;\n\tv472 = \"il2cpp_codegen_initialize_runtime_metadata\"(v471, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv474 = Il2CppMethodInfo;\n\tv475 = \"il2cpp_codegen_initialize_runtime_metadata\"(v474, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv484 = SingletonMonoDontDestroy`1<GameManager>;\n\tv485 = \"il2cpp_codegen_initialize_runtime_metadata\"(v484, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv490 = Il2CppMethodInfo;\n\tv491 = \"il2cpp_codegen_initialize_runtime_metadata\"(v490, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv494 = Il2CppMethodInfo;\n\tv495 = \"il2cpp_codegen_initialize_runtime_metadata\"(v494, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv498 = Il2CppMethodInfo;\n\tv499 = \"il2cpp_codegen_initialize_runtime_metadata\"(v498, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv501 = Il2CppMethodInfo;\n\tv502 = \"il2cpp_codegen_initialize_runtime_metadata\"(v501, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv504 = Il2CppMethodInfo;\n\tv505 = \"il2cpp_codegen_initialize_runtime_metadata\"(v504, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv507 = System.Collections.Generic.Stack`1<System.Int32>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v507, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A355FA]) = v70;\nL_005E:\n\tgoto L_0061;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_0061:\n\tv85 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv93 = v85.randomLevels;\n\tv323 = v93.randomlevelsDatas;\n\tv293 = SingletonMonoDontDestroy`1<GameManager>::get_Instance();\n\tv410 = v293.currentLevel - 0x1E;\n\tv312 = v323[v410 @ X8_v8 (System.Int32)];\n\tv287 = this.gpc;\n\t// 135 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv287.numberCols = v312.fillBox;\n\tv287.numberColors = v312.numberColors;\n\tDataController::setUpRandomList(this);\n\tv488 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v488, this.randomList);\n\tv294 = new System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::.ctor(v294);\n\tv313 = this.gpc;\n\tthis.listCols = v294;\n\tDataController::SetBackground(v294, v313.numberCols);\n\tv314 = this.gpc;\n\tv218 = v314.GraphicController;\n\tv295 = new System.Collections.Generic.List`1<Box>();\n\tSystem.Collections.Generic.List`1<Box>::.ctor(v295);\n\tv218.Boxes = v295;\n\tv315 = this.gpc;\n\tv194 = v315.numberCols - 1;\n\tv514 = v194 / v315.maxBoxPerRow;\n\tv213 = v514 + 1;\n\tv315.numberRows = v213;\n\tv517 = v315.numberCols & 1;\n\tv275 = v315.numberCols - 7;\n\tv269 = v275 < 0;\n\tv257 = v315.numberCols ^ 7;\n\tv251 = v315.numberCols ^ v275;\n\tv245 = v257 & v251;\n\tv239 = v245 < 0;\n\tv521 = v269 == v239;\n\tv189 = ~v521;\n\tv184 = ~v189;\n\tif (v184) goto L_FFFFFFFF;\n\tgoto L_00D7;\nL_00D7:\n\tgoto L_00E1;\n\tv526 = \"il2cpp_codegen_runtime_class_init\"(v515, v204, v208, v54, v55, v56, v57, v58, v228, v60, v61, v62, v63, v64, v65, v66);\nL_00E1:\n\tgoto L_00E4;\n\tv533 = \"il2cpp_codegen_runtime_class_init\"(v530, v204, v208, v54, v55, v56, v57, v58, v228, v60, v61, v62, v63, v64, v65, v66);\nL_00E4:\n\tv378 = this.gpc;\n\tv535 = v315.numberCols / v213;\n\tv179 = v535 + v326;\n\tv536 = v179 + 1;\n\t// 235 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv541 = v312.fillBox / v536;\nL_0103:\n\tv356 = v352 >= v378.numberCols;\n\tif (v356) goto L_0250;\n\tv601 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v601);\n\tv605 = this.gpc;\n\tv698 = *([v362 @ X24_v10 (Il2CppClass<GameHelper>)]);\n\tgoto L_0119;\n\tv749 = \"il2cpp_codegen_runtime_class_init\"(v607, v604, v359, v54, v55, v56, v57, v58, v363, v354, v350, v346, v345, v344, v343, v66);\n\tv750 = *([v362 @ X24_v10 (Il2CppClass<GameHelper>)]);\nL_0119:\n\tv751 = *([v698 @ X0_v29+B8]);\n\tv615 = v605.numberCols <= 6;\n\tif (v615) goto L_0162;\n\tv734 = this.gpc;\n\tv735 = v734.numberCols;\n\tv675 = v734.numberCols < 0;\n\tv657 = v734.numberCols ^ v734.numberCols;\n\tv651 = v734.numberCols & v657;\n\tv645 = v651 < 0;\n\tv764 = v675 == v645;\n\tv616 = ~v764;\n\tv614 = ~v616;\n\tif (v614) goto L_0142;\n\tv735 = v735 + 1;\n\tgoto L_0142;\nL_0142:\n\tv697 = v767.Ins;\n\tv692 = v697.gamePlayController;\n\tv693 = v692.GraphicController;\n\tv736 = v735 >> 1;\n\tv617 = v352 <= v736;\n\tif (v617) goto L_0170;\n\tv770 = v693.posRow2_2;\n\tv806 = v693.posRow2_2 == 0;\n\tv715 = ~v806;\n\tif (v715) goto L_0173;\n\tgoto L_0235;\nL_0162:\n\tv737 = v758.Ins;\n\tv738 = v737.gamePlayController;\n\tv739 = v738.GraphicController;\n\tv770 = v739.posRow1;\n\tv768 = v739.posRow1 == 0;\n\tv719 = ~v768;\n\tif (v719) goto L_0173;\n\tgoto L_0235;\nL_0170:\n\tv770 = v693.posRow1_2;\nL_0173:\n\tv773 = v352 / v179;\n\tv774 = v773 * v179;\n\tv775 = v352 - v774;\n\tv777 = v775 + 1;\n\tv778 = *([v751 @ X8_v25+8]) + 1f;\n\tv781 = v777 * 0;\n\tv562 = v778 + v781;\n\tv783 = UnityEngine.Transform::get_position(v770);\n\tgoto L_019B;\n\tv793 = v322;\n\tv794 = \"il2cpp_codegen_initialize_runtime_metadata\"(v793, v782, v359, v54, v55, v56, v57, v58, v783, v784, v785, v346, v345, v344, v343, v66);\n\tv796 = 1;\n\t*([1A3551A]) = v796;\nL_019B:\n\tgoto L_01A1;\n\tv807 = \"il2cpp_codegen_runtime_class_init\"(v803, v782, v359, v54, v55, v56, v57, v58, v783, v784, v785, v346, v345, v344, v343, v66);\nL_01A1:\n\tv813 = v541 * v777;\n\tv564 = *([v751 @ X8_v25]) + v813;\n\t// 428 MakeStruct v553 @ AGGC01E7C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v564 @ V8_v9, v783.y (System.Single), v562 @ V9_v7 (System.Single)\n\tv702 = Lean.Pool.LeanPool::Spawn(this.boxPrefab, v553, v740.identityQuaternion, 0);\n\tv703 = UnityEngine.GameObject::get_transform(v702);\n\t// 442 MakeStruct v551 @ AGGC01EA4_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.cubeSize (System.Single), this.cubeSize (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v703, v551);\n\tv704 = UnityEngine.GameObject::get_transform(v702);\n\tv705 = UnityEngine.GameObject::get_transform(this.testCubesHolder);\n\tUnityEngine.Transform::SetParent(v704, v705);\n\tv742 = this.gpc;\n\tv707 = UnityEngine.GameObject::GetComponent(v702);\n\tGraphicController::AddBox(v742.GraphicController, v707);\n\tv844 = this.gpc;\n\tv829 = v3\n// ... truncated")]
	public void GenarateRandomDataMap()
	{
		//IL_00d4: Expected I4, but got O
		//IL_02d2: Expected I, but got O
		//IL_082f: Expected O, but got I
		//IL_02fd: Expected O, but got I
		//IL_0850: Expected O, but got I
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0559: Expected O, but got Unknown
		//IL_0566: Expected F4, but got O
		//IL_080a: Expected I, but got O
		GameManager instance = SingletonMonoDontDestroy<GameManager>.Instance;
		RandomLevels randomLevels = instance.randomLevels;
		RandomLevels.RandomLevelsData[] randomlevelsDatas = randomLevels.randomlevelsDatas;
		GameManager instance2 = SingletonMonoDontDestroy<GameManager>.Instance;
		int num = instance2.currentLevel - 30;
		RandomLevels.RandomLevelsData randomLevelsData = randomlevelsDatas[num];
		GamePlayController gamePlayController = gpc;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
		gamePlayController.numberCols = randomLevelsData.fillBox;
		gamePlayController.maxCols = (int)((uint)randomLevelsData.fillBox >> 32);
		gamePlayController.numberColors = randomLevelsData.numberColors;
		setUpRandomList();
		Stack<int> stack = new Stack<int>((int)randomList);
		List<Stack<int>> list = new List<Stack<int>>();
		GamePlayController gamePlayController2 = gpc;
		listCols = list;
		((DataController)(object)list).SetBackground(gamePlayController2.numberCols);
		GamePlayController gamePlayController3 = gpc;
		GraphicController graphicController = gamePlayController3.GraphicController;
		List<Box> boxes = new List<Box>();
		graphicController.Boxes = boxes;
		GamePlayController gamePlayController4 = gpc;
		int num2 = gamePlayController4.numberCols - 1;
		int num3 = num2 / gamePlayController4.maxBoxPerRow;
		int num4 = (gamePlayController4.numberRows = num3 + 1);
		int num5 = gamePlayController4.numberCols & 1;
		int num6 = gamePlayController4.numberCols - 7;
		bool flag = num6 < 0;
		int num7 = gamePlayController4.numberCols ^ 7;
		int num8 = gamePlayController4.numberCols ^ num6;
		int num9 = num7 & num8;
		bool flag2 = num9 < 0;
		int num10 = ((flag == flag2) ? num5 : 0);
		GamePlayController gamePlayController5 = gpc;
		int num11 = gamePlayController4.numberCols / num4;
		int num12 = num11 + num10;
		int num13 = num12 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
		int num14 = randomLevelsData.fillBox / num13;
		int num15 = 0;
		nint num16 = (nint)typeof(GameHelper);
		Vector3 position2 = default(Vector3);
		Vector3 localScale = default(Vector3);
		bool flag6;
		do
		{
			if (num15 < gamePlayController5.numberCols)
			{
				Stack<int> stack2 = new Stack<int>();
				GamePlayController gamePlayController6 = gpc;
				object obj = num16;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ X0_v29+B8]");
				object obj2 = 0;
				Transform transform;
				if (gamePlayController6.numberCols > 6)
				{
					GamePlayController gamePlayController7 = gpc;
					int num17 = gamePlayController7.numberCols;
					bool flag3 = gamePlayController7.numberCols < 0;
					int num18 = gamePlayController7.numberCols ^ gamePlayController7.numberCols;
					int num19 = gamePlayController7.numberCols & num18;
					bool flag4 = num19 < 0;
					if (flag3 != flag4)
					{
						num17++;
					}
					GameController ins = GameController.Ins;
					GamePlayController gamePlayController8 = ins.gamePlayController;
					GraphicController graphicController2 = gamePlayController8.GraphicController;
					int num20 = num17 >> 1;
					if (num15 > num20)
					{
						transform = graphicController2.posRow2_2;
						if ((object)graphicController2.posRow2_2 == null)
						{
							break;
						}
					}
					else
					{
						transform = graphicController2.posRow1_2;
					}
				}
				else
				{
					GameController ins2 = GameController.Ins;
					GamePlayController gamePlayController9 = ins2.gamePlayController;
					GraphicController graphicController3 = gamePlayController9.GraphicController;
					transform = graphicController3.posRow1;
					if ((object)graphicController3.posRow1 == null)
					{
						break;
					}
				}
				int num21 = num15 / num12;
				int num22 = num21 * num12;
				int num23 = num15 - num22;
				int num24 = num23 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v751 @ X8_v25+8]");
				float num25 = 0f + 1f;
				int num26 = num24 * 0;
				float z = num25 + (float)num26;
				Vector3 position = transform.position;
				int num27 = num14 * num24;
				object obj3 = obj2 + num27;
				position2.x = (float)obj3;
				position2.y = position.y;
				position2.z = z;
				GameObject gameObject = LeanPool.Spawn(boxPrefab, position2, Quaternion.identity);
				Transform transform2 = gameObject.transform;
				localScale.x = cubeSize;
				localScale.y = cubeSize;
				localScale.z = 1f;
				transform2.localScale = localScale;
				Transform transform3 = gameObject.transform;
				Transform parent = testCubesHolder.transform;
				transform3.SetParent(parent);
				GamePlayController gamePlayController10 = gpc;
				Box component = gameObject.GetComponent<Box>();
				gamePlayController10.GraphicController.AddBox(component);
				GamePlayController gamePlayController11 = gpc;
				if (num15 < gamePlayController11.maxCols)
				{
					int num28 = -1;
					while (true)
					{
						num28++;
						if (num28 >= gamePlayController11.maxValueCols)
						{
							break;
						}
						int item = stack.Peek();
						stack2.Push(item);
						int num29 = stack.Pop();
						gamePlayController11 = gpc;
						if ((object)gpc == null)
						{
							goto end_IL_08bc;
						}
					}
				}
				List<Stack<int>> list2 = listCols;
				Stack<int>[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = stack2;
				}
				else
				{
					list2.Add(stack2);
				}
				gamePlayController5 = gpc;
				num15++;
				bool flag5 = (object)gpc == null;
				flag6 = !flag5;
				num16 = (nint)typeof(GameHelper);
				continue;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v378 @ X8_v18 (GamePlayController)+28]");
			((GraphicController)0).SetUp(listCols);
			return;
			continue;
			end_IL_08bc:
			break;
		}
		while (flag6);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000D4")]
	[Address(RVA = "0xBFE034", Offset = "0xBFE034", Length = "0x5F0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0050;\n\tv48 = GameController;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv74 = GameHelper;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv301 = Il2CppMethodInfo;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv353 = Lean.Pool.LeanPool;\n\tv354 = \"il2cpp_codegen_initialize_runtime_metadata\"(v353, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv378 = Il2CppMethodInfo;\n\tv379 = \"il2cpp_codegen_initialize_runtime_metadata\"(v378, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv382 = Il2CppMethodInfo;\n\tv383 = \"il2cpp_codegen_initialize_runtime_metadata\"(v382, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv385 = Il2CppMethodInfo;\n\tv386 = \"il2cpp_codegen_initialize_runtime_metadata\"(v385, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv388 = System.Collections.Generic.List`1<Box>;\n\tv389 = \"il2cpp_codegen_initialize_runtime_metadata\"(v388, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv391 = System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>;\n\tv392 = \"il2cpp_codegen_initialize_runtime_metadata\"(v391, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv394 = System.Math;\n\tv395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv401 = Il2CppMethodInfo;\n\tv402 = \"il2cpp_codegen_initialize_runtime_metadata\"(v401, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv404 = Il2CppMethodInfo;\n\tv405 = \"il2cpp_codegen_initialize_runtime_metadata\"(v404, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv407 = Il2CppMethodInfo;\n\tv408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv410 = Il2CppMethodInfo;\n\tv411 = \"il2cpp_codegen_initialize_runtime_metadata\"(v410, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv423 = Il2CppMethodInfo;\n\tv424 = \"il2cpp_codegen_initialize_runtime_metadata\"(v423, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv428 = System.Collections.Generic.Stack`1<System.Int32>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv68 = 1;\n\t*([1A355FB]) = v68;\nL_0050:\n\tv71 = this.gpc;\n\tv71.maxBoxPerRow = *([4080C0]);\n\tv71.numberColors = 9;\n\tDataController::setUpRandomList(this);\n\tv305 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v305, this.randomList);\n\tv277 = new System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::.ctor(v277);\n\tv291 = this.gpc;\n\tthis.listCols = v277;\n\tDataController::SetBackground(v277, v291.numberCols);\n\tv292 = this.gpc;\n\tv259 = v292.GraphicController;\n\tv278 = new System.Collections.Generic.List`1<Box>();\n\tSystem.Collections.Generic.List`1<Box>::.ctor(v278);\n\tv259.Boxes = v278;\n\tv293 = this.gpc;\n\tv231 = v293.numberCols - 1;\n\tv414 = v231 / v293.maxBoxPerRow;\n\tv255 = v414 + 1;\n\tv293.numberRows = v255;\n\tv417 = v293.numberCols & 1;\n\tv221 = v293.numberCols - 7;\n\tv216 = v221 < 0;\n\tv206 = v293.numberCols ^ 7;\n\tv201 = v293.numberCols ^ v221;\n\tv196 = v206 & v201;\n\tv191 = v196 < 0;\n\tv421 = v216 == v191;\n\tv186 = ~v421;\n\tv181 = ~v186;\n\tif (v181) goto L_FFFFFFFF;\n\tgoto L_00A7;\nL_00A7:\n\tgoto L_00B1;\n\tv431 = \"il2cpp_codegen_runtime_class_init\"(v415, v241, v245, v52, v53, v54, v55, v56, v79, v58, v59, v60, v61, v62, v63, v64);\nL_00B1:\n\tgoto L_00B4;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v435, v241, v245, v52, v53, v54, v55, v56, v79, v58, v59, v60, v61, v62, v63, v64);\nL_00B4:\n\tv295 = this.gpc;\n\tv440 = v293.numberCols / v255;\n\tv176 = v440 + v251;\n\tv441 = v176 + 1;\n\t// 187 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv446 = *([4080C0]) / v441;\nL_00D3:\n\tv330 = v326 >= v295.numberCols;\n\tif (v330) goto L_0220;\n\tv506 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v506);\n\tv289 = this.gpc;\n\tv603 = *([v345 @ X24_v10 (Il2CppClass<GameHelper>)]);\n\tgoto L_00E9;\n\tv654 = \"il2cpp_codegen_runtime_class_init\"(v512, v509, v341, v52, v53, v54, v55, v56, v344, v328, v324, v320, v319, v318, v317, v64);\n\tv655 = *([v345 @ X24_v10 (Il2CppClass<GameHelper>)]);\nL_00E9:\n\tv656 = *([v603 @ X0_v22+B8]);\n\tv520 = v289.numberCols <= 6;\n\tif (v520) goto L_0132;\n\tv639 = this.gpc;\n\tv640 = v639.numberCols;\n\tv556 = v639.numberCols < 0;\n\tv538 = v639.numberCols ^ v639.numberCols;\n\tv532 = v639.numberCols & v538;\n\tv526 = v532 < 0;\n\tv669 = v556 == v526;\n\tv521 = ~v669;\n\tv519 = ~v521;\n\tif (v519) goto L_0112;\n\tv640 = v640 + 1;\n\tgoto L_0112;\nL_0112:\n\tv602 = v672.Ins;\n\tv597 = v602.gamePlayController;\n\tv598 = v597.GraphicController;\n\tv641 = v640 >> 1;\n\tv522 = v326 <= v641;\n\tif (v522) goto L_0140;\n\tv675 = v598.posRow2_2;\n\tv711 = v598.posRow2_2 == 0;\n\tv620 = ~v711;\n\tif (v620) goto L_0143;\n\tgoto L_0205;\nL_0132:\n\tv642 = v663.Ins;\n\tv643 = v642.gamePlayController;\n\tv644 = v643.GraphicController;\n\tv675 = v644.posRow1;\n\tv673 = v644.posRow1 == 0;\n\tv624 = ~v673;\n\tif (v624) goto L_0143;\n\tgoto L_0205;\nL_0140:\n\tv675 = v598.posRow1_2;\nL_0143:\n\tv678 = v326 / v176;\n\tv679 = v678 * v176;\n\tv680 = v326 - v679;\n\tv682 = v680 + 1;\n\tv683 = *([v656 @ X8_v19+8]) + 1f;\n\tv686 = v682 * 0;\n\tv468 = v683 + v686;\n\tv688 = UnityEngine.Transform::get_position(v675);\n\tgoto L_016B;\n\tv698 = v248;\n\tv699 = \"il2cpp_codegen_initialize_runtime_metadata\"(v698, v687, v341, v52, v53, v54, v55, v56, v688, v689, v690, v320, v319, v318, v317, v64);\n\tv701 = 1;\n\t*([1A3551A]) = v701;\nL_016B:\n\tgoto L_0171;\n\tv712 = \"il2cpp_codegen_runtime_class_init\"(v708, v687, v341, v52, v53, v54, v55, v56, v688, v689, v690, v320, v319, v318, v317, v64);\nL_0171:\n\tv718 = v446 * v682;\n\tv470 = *([v656 @ X8_v19]) + v718;\n\t// 380 MakeStruct v459 @ AGGC02470_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v470 @ V8_v9, v688.y (System.Single), v468 @ V9_v7 (System.Single)\n\tv607 = Lean.Pool.LeanPool::Spawn(this.boxPrefab, v459, v645.identityQuaternion, 0);\n\tv608 = UnityEngine.GameObject::get_transform(v607);\n\t// 394 MakeStruct v457 @ AGGC02498_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.cubeSize (System.Single), this.cubeSize (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v608, v457);\n\tv609 = UnityEngine.GameObject::get_transform(v607);\n\tv610 = UnityEngine.GameObject::get_transform(this.testCubesHolder);\n\tUnityEngine.Transform::SetParent(v609, v610);\n\tv647 = this.gpc;\n\tv612 = UnityEngine.GameObject::GetComponent(v607);\n\tGraphicController::AddBox(v647.GraphicController, v612);\n\tv749 = this.gpc;\n\tv734 = v326 >= v749.maxCols;\n\tif (v734) goto L_01DC;\nL_01BD:\n\tv748 = v748 + 1;\n\tv524 = v748 >= v749.maxValueCols;\n\tif (v524) goto L_01DC;\n\tv615 = System.Collections.Generic.Stack`1<System.Int32>::Peek(v305);\n\tSystem.Collections.Generic.Stack`1<System.Int32>::Push(v506, v615);\n\tv616 = System.Collections.Generic.Stack`1<System.Int32>::Pop(v305);\n\tv749 = this.gpc;\n\tv768 = this.gpc == 0;\n\tv635 = ~v768;\n\tif (v635) goto L_01BD;\n\tgoto L_0205;\nL_01DC:\n\tv499 = this.listCols;\n\tv653 = v499._items;\n\tv573 = v499._version + 1;\n\tv499._version = v573;\n\tv491 = v499._size;\n\tv754 = v499._size < v653.Length;\n\tv490 = ~v754;\n\tif (v490) goto L_01FE;\n\tv756 = v499._size + 1;\n\tv499._size = v756;\n\tv653[v491 @ X10_v8 (System.Int32)] = v506;\n\tgoto L_01FF;\nL_01FE:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::AddWithResize(v499, v506);\nL_01FF:\n\tv28\n// ... truncated")]
	public void GenarateRandomMap()
	{
		//IL_008a: Expected I4, but got O
		//IL_028b: Expected I, but got O
		//IL_02b6: Expected O, but got I
		//IL_081a: Expected O, but got I
		//IL_050d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0512: Expected O, but got Unknown
		//IL_051f: Expected F4, but got O
		//IL_07c3: Expected I, but got O
		GamePlayController gamePlayController = gpc;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080C0]");
		gamePlayController.maxBoxPerRow = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080C0]");
		gamePlayController.maxValueCols = (int)((nuint)0u >> 32);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080C0]");
		gamePlayController.numberCols = (int)((nuint)0u >> 64);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080C0]");
		gamePlayController.maxCols = (int)((nuint)0u >> 96);
		gamePlayController.numberColors = 9;
		setUpRandomList();
		Stack<int> stack = new Stack<int>((int)randomList);
		List<Stack<int>> list = new List<Stack<int>>();
		GamePlayController gamePlayController2 = gpc;
		listCols = list;
		((DataController)(object)list).SetBackground(gamePlayController2.numberCols);
		GamePlayController gamePlayController3 = gpc;
		GraphicController graphicController = gamePlayController3.GraphicController;
		List<Box> boxes = new List<Box>();
		graphicController.Boxes = boxes;
		GamePlayController gamePlayController4 = gpc;
		int num = gamePlayController4.numberCols - 1;
		int num2 = num / gamePlayController4.maxBoxPerRow;
		int num3 = (gamePlayController4.numberRows = num2 + 1);
		int num4 = gamePlayController4.numberCols & 1;
		int num5 = gamePlayController4.numberCols - 7;
		bool flag = num5 < 0;
		int num6 = gamePlayController4.numberCols ^ 7;
		int num7 = gamePlayController4.numberCols ^ num5;
		int num8 = num6 & num7;
		bool flag2 = num8 < 0;
		int num9 = ((flag == flag2) ? num4 : 0);
		GamePlayController gamePlayController5 = gpc;
		int num10 = gamePlayController4.numberCols / num3;
		int num11 = num10 + num9;
		int num12 = num11 + 1;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4080C0]");
		int num13 = (int)((nint)0 / (nint)num12);
		int num14 = 0;
		nint num15 = (nint)typeof(GameHelper);
		Vector3 position2 = default(Vector3);
		Vector3 localScale = default(Vector3);
		bool flag6;
		do
		{
			if (num14 < gamePlayController5.numberCols)
			{
				Stack<int> stack2 = new Stack<int>();
				GamePlayController gamePlayController6 = gpc;
				object obj = num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ X0_v22+B8]");
				object obj2 = 0;
				Transform transform;
				if (gamePlayController6.numberCols > 6)
				{
					GamePlayController gamePlayController7 = gpc;
					int num16 = gamePlayController7.numberCols;
					bool flag3 = gamePlayController7.numberCols < 0;
					int num17 = gamePlayController7.numberCols ^ gamePlayController7.numberCols;
					int num18 = gamePlayController7.numberCols & num17;
					bool flag4 = num18 < 0;
					if (flag3 != flag4)
					{
						num16++;
					}
					GameController ins = GameController.Ins;
					GamePlayController gamePlayController8 = ins.gamePlayController;
					GraphicController graphicController2 = gamePlayController8.GraphicController;
					int num19 = num16 >> 1;
					if (num14 > num19)
					{
						transform = graphicController2.posRow2_2;
						if ((object)graphicController2.posRow2_2 == null)
						{
							break;
						}
					}
					else
					{
						transform = graphicController2.posRow1_2;
					}
				}
				else
				{
					GameController ins2 = GameController.Ins;
					GamePlayController gamePlayController9 = ins2.gamePlayController;
					GraphicController graphicController3 = gamePlayController9.GraphicController;
					transform = graphicController3.posRow1;
					if ((object)graphicController3.posRow1 == null)
					{
						break;
					}
				}
				int num20 = num14 / num11;
				int num21 = num20 * num11;
				int num22 = num14 - num21;
				int num23 = num22 + 1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ X8_v19+8]");
				float num24 = 0f + 1f;
				int num25 = num23 * 0;
				float z = num24 + (float)num25;
				Vector3 position = transform.position;
				int num26 = num13 * num23;
				object obj3 = obj2 + num26;
				position2.x = (float)obj3;
				position2.y = position.y;
				position2.z = z;
				GameObject gameObject = LeanPool.Spawn(boxPrefab, position2, Quaternion.identity);
				Transform transform2 = gameObject.transform;
				localScale.x = cubeSize;
				localScale.y = cubeSize;
				localScale.z = 1f;
				transform2.localScale = localScale;
				Transform transform3 = gameObject.transform;
				Transform parent = testCubesHolder.transform;
				transform3.SetParent(parent);
				GamePlayController gamePlayController10 = gpc;
				Box component = gameObject.GetComponent<Box>();
				gamePlayController10.GraphicController.AddBox(component);
				GamePlayController gamePlayController11 = gpc;
				if (num14 < gamePlayController11.maxCols)
				{
					int num27 = -1;
					while (true)
					{
						num27++;
						if (num27 >= gamePlayController11.maxValueCols)
						{
							break;
						}
						int item = stack.Peek();
						stack2.Push(item);
						int num28 = stack.Pop();
						gamePlayController11 = gpc;
						if ((object)gpc == null)
						{
							goto end_IL_0884;
						}
					}
				}
				List<Stack<int>> list2 = listCols;
				Stack<int>[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = stack2;
				}
				else
				{
					list2.Add(stack2);
				}
				gamePlayController6 = gpc;
				num14++;
				bool flag5 = (object)gpc == null;
				flag6 = !flag5;
				num15 = (nint)typeof(GameHelper);
				gamePlayController5 = gpc;
				continue;
			}
			gamePlayController5.GraphicController.SetUp(listCols);
			return;
			continue;
			end_IL_0884:
			break;
		}
		while (flag6);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000D5")]
	[Address(RVA = "0xBFEB90", Offset = "0xBFEB90", Length = "0x698")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0050;\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv281 = Il2CppMethodInfo;\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv288 = GameController;\n\tv289 = \"il2cpp_codegen_initialize_runtime_metadata\"(v288, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv380 = GameHelper;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv394 = Il2CppMethodInfo;\n\tv395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv408 = Lean.Pool.LeanPool;\n\tv409 = \"il2cpp_codegen_initialize_runtime_metadata\"(v408, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv426 = Il2CppMethodInfo;\n\tv427 = \"il2cpp_codegen_initialize_runtime_metadata\"(v426, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv441 = Il2CppMethodInfo;\n\tv442 = \"il2cpp_codegen_initialize_runtime_metadata\"(v441, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv547 = Il2CppMethodInfo;\n\tv548 = \"il2cpp_codegen_initialize_runtime_metadata\"(v547, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv550 = System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>;\n\tv551 = \"il2cpp_codegen_initialize_runtime_metadata\"(v550, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv553 = System.Math;\n\tv554 = \"il2cpp_codegen_initialize_runtime_metadata\"(v553, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv556 = Il2CppMethodInfo;\n\tv557 = \"il2cpp_codegen_initialize_runtime_metadata\"(v556, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv560 = Il2CppMethodInfo;\n\tv561 = \"il2cpp_codegen_initialize_runtime_metadata\"(v560, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv564 = System.Collections.Generic.Stack`1<System.Int32>;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v564, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv68 = 1;\n\t*([1A355FC]) = v68;\nL_0050:\n\tv74 = this.gpc;\n\tv75 = this.gpc == 0;\n\tif (v75) goto L_023A;\n\tv83 = v74.numberCols + 1;\n\tv74.numberCols = v83;\n\tv87 = v83 & 1;\n\tv91 = v83 - 7;\n\tv92 = v91 < 0;\n\tv94 = v83 ^ 7;\n\tv95 = v83 ^ v91;\n\tv96 = v94 & v95;\n\tv97 = v96 < 0;\n\tv98 = v92 == v97;\n\tv99 = ~v98;\n\tv100 = ~v99;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0071;\nL_0071:\n\tgoto L_007C;\n\tv382 = \"il2cpp_codegen_runtime_class_init\"(v84, methodInfo, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv384 = GameHelper;\nL_007C:\n\tgoto L_0083;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v386, methodInfo, v51, v52, v53, v54, v55, v56, v387, v58, v59, v60, v61, v62, v63, v64);\nL_0083:\n\tgoto L_0096;\n\tv411 = UnityEngine.Vector3;\n\tv412 = \"il2cpp_codegen_initialize_runtime_metadata\"(v411, methodInfo, v51, v52, v53, v54, v55, v56, v387, v58, v59, v60, v61, v62, v63, v64);\n\tv415 = 1;\n\t*([1A35519]) = v415;\nL_0096:\n\tgoto L_00A8;\n\tv429 = UnityEngine.Quaternion;\n\tv430 = \"il2cpp_codegen_initialize_runtime_metadata\"(v429, methodInfo, v51, v52, v53, v54, v55, v56, v387, v58, v59, v60, v61, v62, v63, v64);\n\tv433 = 1;\n\t*([1A3551A]) = v433;\nL_00A8:\n\tgoto L_00B6;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v436, methodInfo, v51, v52, v53, v54, v55, v56, v387, v58, v59, v60, v61, v62, v63, v64);\nL_00B6:\n\tv249 = Lean.Pool.LeanPool::Spawn(this.boxPrefab, v421.zeroVector, v269.identityQuaternion, 0);\n\tv259 = v249 == 0;\n\tif (v259) goto L_023A;\n\tv250 = UnityEngine.GameObject::get_transform(v249);\n\tv260 = v250 == 0;\n\tif (v260) goto L_023A;\n\t// 194 MakeStruct v156 @ AGGC02DDC_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.cubeSize (System.Single), this.cubeSize (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v250, v156);\n\tv251 = UnityEngine.GameObject::get_transform(v249);\n\tv261 = this.testCubesHolder == 0;\n\tif (v261) goto L_023A;\n\tv252 = UnityEngine.GameObject::get_transform(this.testCubesHolder);\n\tv262 = v251 == 0;\n\tif (v262) goto L_023A;\n\tUnityEngine.Transform::SetParent(v251, v252);\n\tv574 = UnityEngine.GameObject::GetComponent(v249);\n\tv253 = new System.Collections.Generic.Stack`1<System.Int32>();\n\tSystem.Collections.Generic.Stack`1<System.Int32>::.ctor(v253);\n\tv263 = v574 == 0;\n\tif (v263) goto L_023A;\n\tBox::SetUp(v574, v253);\n\tv272 = this.gpc;\n\tv264 = this.gpc == 0;\n\tif (v264) goto L_023A;\n\tv255 = UnityEngine.GameObject::GetComponent(v249);\n\tv265 = v272.GraphicController == 0;\n\tif (v265) goto L_023A;\n\tGraphicController::AddBox(v272.GraphicController, v255);\n\tv256 = new System.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Stack`1<System.Int32>>::.ctor(v256);\n\tv543 = this.gpc;\n\tthis.listCols = v256;\n\tv266 = this.gpc == 0;\n\tif (v266) goto L_023A;\n\tv584 = v83 / v74.numberRows;\n\tv206 = v207 + v584;\n\tv592 = v206 + 1;\n\t// 275 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv134 = v385.bottomLeft / v592;\nL_0119:\n\tv619 = v543.GraphicController;\n\tv621 = v619.Boxes;\n\tv511 = v375 >= v621._size;\n\tif (v511) goto L_0236;\n\tv338 = v543.numberCols;\n\tgoto L_0133;\n\tv744 = \"il2cpp_codegen_runtime_class_init\"(v741, v492, v490, v52, v53, v54, v55, v56, v503, v501, v499, v497, v183, v181, v179, v64);\n\tv745 = GameHelper;\nL_0133:\n\tv746 = *([v694 @ X0_v43 (Il2CppClass<GameHelper>)+B8]);\n\tv653 = v543.numberCols <= 6;\n\tif (v653) goto L_0176;\n\tv727 = this.gpc;\n\tv728 = v727.numberCols;\n\tv678 = v727.numberCols < 0;\n\tv666 = v727.numberCols ^ v727.numberCols;\n\tv662 = v727.numberCols & v666;\n\tv658 = v662 < 0;\n\tv756 = v678 == v658;\n\tv654 = ~v756;\n\tv651 = ~v654;\n\tif (v651) goto L_015A;\n\tv728 = v728 + 1;\n\tgoto L_015A;\nL_015A:\n\tv692 = v754.Ins;\n\tv690 = v692.gamePlayController;\n\tv691 = v690.GraphicController;\n\tv729 = v728 >> 1;\n\tv655 = v375 >= v729;\n\tif (v655) goto L_0184;\n\tv698 = v691.posRow1_2;\n\tv771 = v691.posRow1_2 == 0;\n\tv709 = ~v771;\n\tif (v709) goto L_0187;\n\tgoto L_0238;\nL_0176:\n\tv730 = v751.Ins;\n\tv731 = v730.gamePlayController;\n\tv732 = v731.GraphicController;\n\tv698 = v732.posRow1;\n\tv759 = v732.posRow1 == 0;\n\tv713 = ~v759;\n\tif (v713) goto L_0187;\n\tgoto L_0238;\nL_0184:\n\tv698 = v691.posRow2_2;\nL_0187:\n\tv762 = v375 / v206;\n\tv763 = v762 * v206;\n\tv764 = v375 - v763;\n\tv765 = v764 + 1;\n\tv768 = *([v746 @ X8_v26 (Il2CppStaticFields<GameHelper>)+8]) + 1f;\n\tv331 = v134 * v765;\n\tv769 = v765 * 0;\n\tv315 = v746.bottomLeft + v331;\n\tv310 = v768 + v769;\n\tv646 = UnityEngine.Transform::get_position(v698);\n\tv733 = this.gpc;\n\tv734 = v733.GraphicController;\n\tv700 = System.Collections.Generic.List`1<Box>::get_Item(v734.Boxes, v375);\n\tv701 = UnityEngine.Component::get_transform(v700);\n\t// 430 MakeStruct v304 @ AGGC03058_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v315 @ V8_v9 (System.Single), v646.y (System.Single), v310 @ V12_v8 (System.Single)\n\tUnityEngine.Transform::set_position(v701, v304);\n\tv735 = this.gpc;\n\tv736 = v735.GraphicController;\n\tv703 = System.Collections.Generic.List`1<Box>::get_Item(v736.Boxes, v375);\n\tv774 = System.Collections.Generic.Stack`1<Imposter>::GetEnumerator(v703.imposterStack);\nL_01CA:\n\tv793 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::MoveNext(&v302 @ stack_-E8_v5 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>));\n\tv795 = v793 == 0;\n\tif (v795) goto L_01EF;\n\tv798 = System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Object>::get_Current(&v302 @ stack_-E8_v5 (System.Collections.Generic.Stack`1<System.Object>+Enumerator<System.Obje\n// ... truncated")]
	public void AddOneBox()
	{
		//IL_026f: Expected I, but got O
		//IL_02b8: Expected I, but got O
		//IL_02fa: Expected I, but got O
		//IL_0425: Expected I, but got O
		//IL_0a3b: Expected I, but got O
		//IL_076f: Expected I4, but got O
		GamePlayController gamePlayController = gpc;
		bool flag = (object)gpc == null;
		Stack<object>.Enumerator enumerator = default(Stack<object>.Enumerator);
		nint num8 = default(nint);
		int num14;
		NullReferenceException ex2;
		if (!flag)
		{
			int num = ++gamePlayController.numberCols;
			int num2 = num & 1;
			int num3 = num - 7;
			bool flag2 = num3 < 0;
			int num4 = num ^ 7;
			int num5 = num ^ num3;
			int num6 = num4 & num5;
			bool flag3 = num6 < 0;
			int num7 = ((flag2 == flag3) ? num2 : 0);
			GameObject gameObject = LeanPool.Spawn(boxPrefab, Vector3.zero, Quaternion.identity);
			bool flag4 = (object)gameObject == null;
			enumerator = default(Stack<object>.Enumerator);
			num8 = 27480064;
			if (!flag4)
			{
				Transform transform = gameObject.transform;
				bool flag5 = (object)transform == null;
				enumerator = default(Stack<object>.Enumerator);
				num8 = 27480064;
				if (!flag5)
				{
					Vector3 localScale = default(Vector3);
					localScale.x = cubeSize;
					localScale.y = cubeSize;
					localScale.z = 1f;
					transform.localScale = localScale;
					Transform transform2 = gameObject.transform;
					bool flag6 = (object)testCubesHolder == null;
					enumerator = default(Stack<object>.Enumerator);
					num8 = 27480064;
					if (!flag6)
					{
						Transform parent = testCubesHolder.transform;
						bool flag7 = (object)transform2 == null;
						enumerator = default(Stack<object>.Enumerator);
						num8 = 27480064;
						if (!flag7)
						{
							transform2.SetParent(parent);
							Box component = gameObject.GetComponent<Box>();
							Stack<int> stack = new Stack<int>();
							bool flag8 = (object)component == null;
							enumerator = default(Stack<object>.Enumerator);
							num8 = (nint)stack;
							if (!flag8)
							{
								component.SetUp(stack);
								GamePlayController gamePlayController2 = gpc;
								bool flag9 = (object)gpc == null;
								enumerator = default(Stack<object>.Enumerator);
								num8 = (nint)stack;
								if (!flag9)
								{
									Box component2 = gameObject.GetComponent<Box>();
									bool flag10 = (object)gamePlayController2.GraphicController == null;
									enumerator = default(Stack<object>.Enumerator);
									num8 = (nint)stack;
									if (!flag10)
									{
										gamePlayController2.GraphicController.AddBox(component2);
										List<Stack<int>> list = new List<Stack<int>>();
										GamePlayController gamePlayController3 = gpc;
										listCols = list;
										bool flag11 = (object)gpc == null;
										enumerator = default(Stack<object>.Enumerator);
										num8 = 0;
										if (!flag11)
										{
											int num9 = num / gamePlayController.numberRows;
											int num10 = num7 + num9;
											int num11 = num10 + 1;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
											float num12 = GameHelper.bottomLeft.x / (float)num11;
											enumerator = default(Stack<object>.Enumerator);
											int num13 = 0;
											Vector3 position2 = default(Vector3);
											Stack<object>.Enumerator enumerator3 = default(Stack<object>.Enumerator);
											while (true)
											{
												GraphicController graphicController = gamePlayController3.GraphicController;
												List<Box> boxes = graphicController.Boxes;
												if (num13 >= boxes.Count)
												{
													return;
												}
												num14 = gamePlayController3.numberCols;
												nint num15 = (nint)typeof(GameHelper);
												nint num16 = (nint)GameHelper.bottomLeft;
												Transform transform3;
												if (gamePlayController3.numberCols > 6)
												{
													GamePlayController gamePlayController4 = gpc;
													int num17 = gamePlayController4.numberCols;
													bool flag12 = gamePlayController4.numberCols < 0;
													int num18 = gamePlayController4.numberCols ^ gamePlayController4.numberCols;
													int num19 = gamePlayController4.numberCols & num18;
													bool flag13 = num19 < 0;
													if (flag12 != flag13)
													{
														num17++;
													}
													GameController ins = GameController.Ins;
													GamePlayController gamePlayController5 = ins.gamePlayController;
													GraphicController graphicController2 = gamePlayController5.GraphicController;
													int num20 = num17 >> 1;
													if (num13 < num20)
													{
														transform3 = graphicController2.posRow1_2;
														if ((object)graphicController2.posRow1_2 == null)
														{
															goto IL_096c;
														}
													}
													else
													{
														transform3 = graphicController2.posRow2_2;
													}
												}
												else
												{
													GameController ins2 = GameController.Ins;
													GamePlayController gamePlayController6 = ins2.gamePlayController;
													GraphicController graphicController3 = gamePlayController6.GraphicController;
													transform3 = graphicController3.posRow1;
													if ((object)graphicController3.posRow1 == null)
													{
														goto IL_096c;
													}
												}
												int num21 = num13 / num10;
												int num22 = num21 * num10;
												int num23 = num13 - num22;
												int num24 = num23 + 1;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v746 @ X8_v26 (Il2CppStaticFields<GameHelper>)+8]");
												float num25 = 0f + 1f;
												float num26 = num12 * (float)num24;
												int num27 = num24 * 0;
												float x = GameHelper.bottomLeft.x + num26;
												float z = num25 + (float)num27;
												Vector3 position = transform3.position;
												GamePlayController gamePlayController7 = gpc;
												GraphicController graphicController4 = gamePlayController7.GraphicController;
												Component component3 = graphicController4.Boxes[num13];
												Transform transform4 = component3.transform;
												position2.x = x;
												position2.y = position.y;
												position2.z = z;
												transform4.position = position2;
												GamePlayController gamePlayController8 = gpc;
												GraphicController graphicController5 = gamePlayController8.GraphicController;
												Box box = graphicController5.Boxes[num13];
												Stack<Imposter>.Enumerator enumerator2 = box.Imposters.GetEnumerator();
												while (enumerator3.MoveNext())
												{
													int num28 = (int)enumerator3.Current;
													GamePlayController gamePlayController9 = gpc;
													NullReferenceException ex;
													if ((object)gpc != null)
													{
														GraphicController graphicController6 = gamePlayController9.GraphicController;
														if ((object)gamePlayController9.GraphicController != null)
														{
															if (graphicController6.Boxes != null)
															{
																Box box2 = graphicController6.Boxes[num13];
																if ((object)box2 != null)
																{
																	if ((object)box2.TopBox != null)
																	{
																		Vector3 position3 = box2.TopBox.position;
																		if (num28 != 0)
																		{
																			_ = position3.y;
																			_ = position3.z;
																			num14 = num28;
																			continue;
																		}
																		ex = new NullReferenceException();
																		num14 = num28;
																	}
																	else
																	{
																		ex = new NullReferenceException();
																		num14 = num28;
																	}
																}
																else
																{
																	ex = new NullReferenceException();
																	num14 = num28;
																}
															}
															else
															{
																ex = new NullReferenceException();
																num14 = num28;
															}
														}
														else
														{
															ex = new NullReferenceException();
														}
													}
													else
													{
														ex = new NullReferenceException();
													}
													enumerator = enumerator3;
													num8 = 0;
													ex2 = ex;
													goto end_IL_0a98;
												}
												enumerator3.Dispose();
												gamePlayController3 = gpc;
												num13++;
												bool flag14 = (object)gpc == null;
												bool flag15 = !flag14;
												enumerator = enumerator3;
												if (flag15)
												{
													continue;
												}
												enumerator = enumerator3;
												goto IL_097a;
												IL_096c:
												NullReferenceException ex3 = new NullReferenceException();
												goto IL_097a;
												IL_097a:
												num8 = 0;
												goto IL_0a13;
												continue;
												end_IL_0a98:
												break;
											}
											goto IL_0aaa;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_0a13;
		IL_0aaa:
		enumerator.Dispose();
		if (num14 == 0)
		{
			Box box3 = ((List<Box>)(object)ex2)[(int)num8];
		}
		OutOfMemoryException ex4 = new OutOfMemoryException();
		Box box4 = ((List<Box>)(object)ex4)[(int)num8];
		return;
		IL_0a13:
		NullReferenceException ex5 = new NullReferenceException();
		num14 = 0;
		ex2 = ex5;
		goto IL_0aaa;
	}

	[Token(Token = "0x60000D6")]
	[Address(RVA = "0xBFF228", Offset = "0xBFF228", Length = "0x14")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cubeSize = 0.35f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DataController()
	{
		cubeSize = 0.35f;
	}
}
