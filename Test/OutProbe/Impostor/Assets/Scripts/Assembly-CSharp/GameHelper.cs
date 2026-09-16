using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[Token(Token = "0x2000023")]
public static class GameHelper
{
	[Token(Token = "0x400007E")]
	public static Vector3 bottomLeft;

	[Token(Token = "0x400007F")]
	public static Vector3 topRight;

	[Token(Token = "0x60000D7")]
	[Address(RVA = "0xBFF23C", Offset = "0xBFF23C", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = UnityEngine.Camera::get_main();\n\tv6 = UnityEngine.Camera::get_aspect(v3);\n\treturnVal1 = v6 / 0.5625f;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static float GetRatio()
	{
		Camera main = Camera.main;
		float aspect = main.aspect;
		return aspect / 0.5625f;
	}

	[Token(Token = "0x60000D8")]
	[Address(RVA = "0xBFF268", Offset = "0xBFF268", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = UnityEngine.Object;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A355FD]) = v39;\nL_0017:\n\tv43 = UnityEngine.Transform::get_childCount(t);\n\tv103 = v43 < 1;\n\tif (v103) goto L_004E;\nL_002B:\n\tv85 = UnityEngine.Transform::GetChild(t, v52);\n\tv174 = UnityEngine.Component::get_gameObject(v85);\n\tgoto L_003A;\n\tv176 = v139;\n\tv177 = \"il2cpp_codegen_runtime_class_init\"(v176, v173, v45, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003A:\n\tUnityEngine.Object::Destroy(v174);\n\tv52 = v52 + 1;\n\tv115 = v43 != v52;\n\tif (v115) goto L_002B;\nL_004E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void DeleteAllChilds(this Transform t)
	{
		int childCount = t.childCount;
		if (childCount >= 1)
		{
			int num = 0;
			do
			{
				Transform child = t.GetChild(num);
				GameObject gameObject = child.gameObject;
				UnityEngine.Object.Destroy(gameObject);
				num++;
			}
			while (childCount != num);
		}
	}

	[Token(Token = "0x60000D9")]
	[Address(RVA = "0xBFF320", Offset = "0xBFF320", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = UnityEngine.Transform::get_childCount(t);\n\tv82 = v12 < 1;\n\tif (v82) goto L_0036;\nL_001B:\n\tv48 = UnityEngine.Transform::GetChild(t, v17);\n\tv49 = UnityEngine.Component::get_gameObject(v48);\n\tUnityEngine.GameObject::SetActive(v49, 0);\n\tv17 = v17 + 1;\n\tv90 = v12 != v17;\n\tif (v90) goto L_001B;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void HideAllChilds(this Transform t)
	{
		int childCount = t.childCount;
		if (childCount >= 1)
		{
			int num = 0;
			do
			{
				Transform child = t.GetChild(num);
				GameObject gameObject = child.gameObject;
				gameObject.SetActive(value: false);
				num++;
			}
			while (childCount != num);
		}
	}

	[Token(Token = "0x60000DA")]
	[Address(RVA = "0xBFF3A8", Offset = "0xBFF3A8", Length = "0xB0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355FE]) = v37;\nL_0016:\n\tv41 = UnityEngine.Transform::get_childCount(t);\n\tv99 = v41 < 1;\n\tif (v99) goto L_004B;\nL_0029:\n\tv81 = UnityEngine.Transform::GetChild(t, 0);\n\tv167 = UnityEngine.Component::get_gameObject(v81);\n\tgoto L_0038;\n\tv169 = v133;\n\tv170 = \"il2cpp_codegen_runtime_class_init\"(v169, v166, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0038:\n\tUnityEngine.Object::DestroyImmediate(v167);\n\tv135 = v87 - 1;\n\tv109 = v87 != 1;\n\tif (v109) goto L_0029;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void DeleteDestroyImmediateAllChilds(this Transform t)
	{
		int childCount = t.childCount;
		if (childCount >= 1)
		{
			int num = childCount;
			bool flag;
			do
			{
				Transform child = t.GetChild(0);
				GameObject gameObject = child.gameObject;
				UnityEngine.Object.DestroyImmediate(gameObject);
				int num2 = num - 1;
				flag = num != 1;
				num = num2;
			}
			while (flag);
		}
	}

	[Token(Token = "0x60000DB")]
	[Address(RVA = "0xBFF458", Offset = "0xBFF458", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = 0x1854EE0(digits, methodInfo, v13, v14, v15, v16, v17, v18, 10f, digits, v19, v20, v21, v22, v23, v24);\n\tv25 = 10f * value;\n\tv30 = 0x1854ED0(&v29 @ stack_-8_v1 (System.Single), methodInfo, v13, v14, v15, v16, v17, v18, v25, digits, v19, v20, v21, v22, v23, v24);\n\tv40 = v25 >= 0;\n\tif (v40) goto L_0031;\n\tv51 = v25 != -0.5d;\n\tif (v51) goto L_0045;\n\tgoto L_0037;\nL_0031:\n\tv62 = v25 != 0.5d;\n\tif (v62) goto L_0049;\nL_0037:\n\tv86 = v108 + v83;\n\tv87 = v108 & 1;\n\tv89 = v87 == 0;\n\tv92 = ~v89;\n\tif (v92) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tgoto L_004C;\nL_0045:\n\tv66 = v25 + -0.5f;\n\tv108 = UnityEngine.Mathf::Ceil(v66);\n\tgoto L_004C;\nL_0049:\n\tv71 = v25 + 0.5f;\n\tv108 = UnityEngine.Mathf::Floor(v71);\nL_004C:\n\treturnVal1 = v108 / 10f;\n\treturn returnVal1;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static float Round(float value, int digits)
	{
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected I4, but got Unknown
		Il2CppRuntime.Boundary("SYSTEM_API:powf", "Method not found @1854EE0 (native powf)");
		float num = 10f * value;
		Il2CppRuntime.Boundary("SYSTEM_API:modf", "Method not found @1854ED0 (native modf)");
		float num2;
		float num3 = default(float);
		float num4;
		if (num < 0f)
		{
			if ((double)num != -0.5)
			{
				float f = num + -0.5f;
				num2 = Mathf.Ceil(f);
				goto IL_0123;
			}
			num2 = num3;
			num4 = -1f;
		}
		else
		{
			if ((double)num != 0.5)
			{
				float f2 = num + 0.5f;
				num2 = Mathf.Floor(f2);
				goto IL_0123;
			}
			num2 = num3;
			num4 = 1f;
		}
		float num5 = num2 + num4;
		if ((num2 & 1) != 0)
		{
			num2 = num5;
		}
		goto IL_0123;
		IL_0123:
		return num2 / 10f;
	}

	[Token(Token = "0x60000DC")]
	[Address(RVA = "0xBFF4FC", Offset = "0xBFF4FC", Length = "0x140")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv20 = GameHelper;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv58 = System.Collections.Generic.List`1<UnityEngine.Object>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv65 = UnityEngine.SceneManagement.SceneManager;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A355FF]) = v41;\nL_0025:\n\tgoto L_0028;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0028:\n\tv56 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv63 = UnityEngine.SceneManagement.Scene::GetRootGameObjects(&v56 @ X0_v5 (UnityEngine.SceneManagement.Scene));\n\tv69 = new System.Collections.Generic.List`1<UnityEngine.Object>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Object>::.ctor(v69);\n\tv85 = v63.Length < 1;\n\tif (v85) goto L_0079;\nL_0057:\n\tv213 = UnityEngine.GameObject::get_transform(v63[v96 @ X22_v5 (System.Int32)]);\n\tgoto L_0062;\n\tv216 = v214;\n\tv217 = \"il2cpp_codegen_runtime_class_init\"(v216, v212, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0062:\n\tGameHelper::FindAllChild(v213, &v69 @ X0_v9 (System.Collections.Generic.List`1<UnityEngine.Object>));\n\tv96 = v96 + 1;\n\tv149 = v96 < v63.Length;\n\tif (v149) goto L_0057;\nL_0079:\n\treturn v69;\n\tv129 = new System.IndexOutOfRangeException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static List<UnityEngine.Object> GetAllObjectsInScene()
	{
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		List<UnityEngine.Object> list = new List<UnityEngine.Object>();
		if (rootGameObjects.Length >= 1)
		{
			int num = 0;
			do
			{
				Transform transform = rootGameObjects[num].transform;
				FindAllChild(transform, ref list);
				num++;
			}
			while (num < rootGameObjects.Length);
		}
		return list;
	}

	[Token(Token = "0x60000DD")]
	[Address(RVA = "0xBFF63C", Offset = "0xBFF63C", Length = "0x380")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = GameHelper;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, list, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv48 = System.IDisposable;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, list, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv122 = System.Collections.IEnumerator;\n\tv123 = \"il2cpp_codegen_initialize_runtime_metadata\"(v122, list, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv167 = Il2CppMethodInfo;\n\tv168 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, list, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv225 = UnityEngine.Transform;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, list, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A35600]) = v45;\nL_0024:\n\tv50 = list->klass;\n\tv53 = UnityEngine.Component::get_gameObject(t);\n\tv117 = v50._items;\n\tv100 = v50._version + 1;\n\tv50._version = v100;\n\tv152 = v50._size;\n\tv227 = v50._size < v117.Length;\n\tv148 = ~v227;\n\tif (v148) goto L_004A;\n\tv228 = v50._size + 1;\n\tv50._size = v228;\n\tv117[v152 @ X10_v21 (System.Int32)] = v53;\n\tgoto L_004F;\nL_004A:\n\tSystem.Collections.Generic.List`1<UnityEngine.Object>::AddWithResize(v50, v53);\nL_004F:\n\tv158 = UnityEngine.Transform::GetEnumerator(t);\nL_005D:\n\tgoto L_0083;\n\tv381 = *([v295 @ X8_v20+B0]);\n\tv382 = v381 + 8;\n\tv402 = *([v455 @ X10_v35-8]);\n\tv461 = v402 == v296;\n\tif (v461) goto L_007C;\n\tv406 = v456 - 1;\n\tv404 = v455 + 0x10;\n\tv384 = v456 != 1;\n\tif (v384) goto L_FFFFFFFF;\n\tv407 = v114;\n\tv408 = 0;\n\tv409 = 0xB349B4(v407, v296, v408, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0083;\nL_007C:\n\tv513 = *([v455 @ X10_v35]);\n\tv514 = v513 << 4;\n\tv515 = v295 + v514;\n\tv516 = v515 + 0x138;\nL_0083:\n\tv330 = System.Collections.IEnumerator::MoveNext(v158);\n\tv332 = v330 == 0;\n\tif (v332) goto L_FFFFFFFF;\n\tgoto L_00B2;\n\tv619 = *([v566 @ X8_v23+B0]);\n\tv620 = v619 + 8;\n\tv640 = *([v666 @ X10_v30-8]);\n\tv672 = v640 == v567;\n\tif (v672) goto L_00AA;\n\tv644 = v667 - 1;\n\tv642 = v666 + 0x10;\n\tv622 = v667 != 1;\n\tif (v622) goto L_FFFFFFFF;\n\tv645 = 1;\n\tv646 = v114;\n\tv647 = 0xB349B4(v646, v567, v645, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00B2;\nL_00AA:\n\tv678 = *([v666 @ X10_v30]);\n\tv679 = v678 + 1;\n\tv680 = v679 << 4;\n\tv681 = v566 + v680;\n\tv682 = v681 + 0x138;\nL_00B2:\n\tv700 = System.Collections.IEnumerator::get_Current(v158);\n\tgoto L_00BA;\n\tv705 = \"il2cpp_codegen_runtime_class_init\"(v701, v698, v66, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00BA:\n\tv110 = v700 == 0;\n\tif (v110) goto L_00DC;\n\tgoto L_FFFFFFFF;\n\tv718 = v718_asT == 0;\n\tif (v718) goto L_011E;\nL_00DC:\n\tGameHelper::FindAllChild(v700, list);\n\tgoto L_005D;\nL_00DF:\n\tv208 = *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]);\n\tv339 = \"il2cpp_codegen_object_is_inst\"(v214, *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]), v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv410 = v339 == 0;\n\tif (v410) goto L_0110;\n\tv466 = *([v339 @ X0_v4 (System.Collections.IEnumerator)]);\n\tv581 = *([v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv470 = *([v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v470) goto L_0106;\n\tv580 = *([v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00F1:\n\tv586 = *([v580 @ X10_v7-8]) == *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]);\n\tif (v586) goto L_0109;\n\tv546 = v581 - 1;\n\tv580 = v580 + 0x10;\n\tv524 = v581 != 1;\n\tif (v524) goto L_00F1;\nL_0106:\n\t;\n\tgoto L_010D;\nL_0109:\n\tv650 = *([v580 @ X10_v7]) << 4;\n\tv651 = v466 + v650;\n\tv653 = v651 + 0x138;\nL_010D:\n\tv208 = *([v653 @ X0_v6+8]);\n\tv486 = System.IDisposable::Dispose(v339);\nL_0110:\n\tv489 = v217 == 0;\n\tv213 = ~v489;\n\tif (v213) goto L_0122;\n\treturn;\nL_011E:\n\tv108 = new System.InvalidCastException();\n\tv120 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0122:\n\tv223 = new System.OutOfMemoryException();\n\tgoto L_0130;\n\tgoto L_0130;\n\tgoto L_0130;\n\tgoto L_0130;\nL_0130:\n\tv244 = v208 != 1;\n\tif (v244) goto L_0138;\n\tv248 = 0x1854E70(v223, v208, v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv217 = *([v248 @ X0_v30]);\n\tv252 = 0x1854E80(v248, v208, v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_00DF;\nL_0138:\n\tgoto L_013A;\n\tstack[8] = X0;\nL_013A:\n\tv372 = *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]);\n\tv255 = \"il2cpp_codegen_object_is_inst\"(v214, *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]), v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv260 = v255 == 0;\n\tif (v260) goto L_016D;\n\tv340 = *([v255 @ X0_v16]);\n\tv501 = *([v340 @ X8_v11+12E]);\n\tv343 = *([v340 @ X8_v11+12E]) == 0;\n\tif (v343) goto L_0161;\n\tv500 = *([v340 @ X8_v11+B0]) + 8;\nL_014C:\n\tv506 = *([v500 @ X10_v15-8]) == *([v180 @ X22_v3 (Il2CppClass<System.IDisposable>)]);\n\tif (v506) goto L_0164;\n\tv436 = v501 - 1;\n\tv500 = v500 + 0x10;\n\tv414 = v501 != 1;\n\tif (v414) goto L_014C;\nL_0161:\n\t;\n\tgoto L_0168;\nL_0164:\n\tv560 = *([v500 @ X10_v15]) << 4;\n\tv561 = v340 + v560;\n\tv563 = v561 + 0x138;\nL_0168:\n\tv372 = *([v563 @ X0_v24+8]);\n\tv375 = System.IDisposable::Dispose(v255);\nL_016D:\n\tgoto L_0171;\n\tv441 = 0xBD3CD0(v223, v372, v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0171:\n\tv444 = new System.OutOfMemoryException();\n\tv511 = 0x9DACB4(v444, v372, v346, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n// 225 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void FindAllChild(Transform t, ref List<UnityEngine.Object> list)
	{
		//IL_0158: Expected I, but got O
		//IL_015d: Expected I, but got O
		//IL_04b9: Expected O, but got I
		//IL_017b: Expected I, but got O
		//IL_018b: Expected O, but got I
		//IL_0217: Expected I, but got O
		//IL_049b: Expected O, but got I
		//IL_01c6: Expected O, but got I
		//IL_04ed: Expected O, but got I
		//IL_02d5: Expected I4, but got O
		//IL_022a: Expected I4, but got O
		//IL_0238: Expected O, but got I
		//IL_0247: Expected O, but got I
		//IL_0264: Expected I, but got O
		//IL_0269: Expected I, but got O
		//IL_030b: Expected O, but got I
		//IL_01da: Expected O, but got I
		//IL_01e9: Expected O, but got I
		//IL_0397: Expected I, but got O
		//IL_0552: Expected O, but got I
		//IL_0346: Expected O, but got I
		//IL_03aa: Expected I4, but got O
		//IL_03b8: Expected O, but got I
		//IL_03c7: Expected O, but got I
		//IL_035a: Expected O, but got I
		//IL_0369: Expected O, but got I
		List<UnityEngine.Object> list2 = list;
		GameObject gameObject = t.gameObject;
		UnityEngine.Object[] items = list2._items;
		int version = list2._version + 1;
		list2._version = version;
		int count = list2.Count;
		if (list2.Count < items.Length)
		{
			int size = list2.Count + 1;
			list2._size = size;
			items[count] = gameObject;
		}
		else
		{
			list2.Add(gameObject);
		}
		IEnumerator enumerator = t.GetEnumerator();
		IEnumerator enumerator3 = default(IEnumerator);
		object obj7 = default(object);
		object obj9 = default(object);
		nint num;
		nint num2;
		object obj;
		while (true)
		{
			object obj8;
			if (!enumerator.MoveNext())
			{
				num = (nint)typeof(IDisposable);
				num2 = unchecked((nint)null);
				IEnumerator enumerator2 = enumerator;
				int num3 = 0;
				while (true)
				{
					obj = num;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					if (enumerator3 == null)
					{
						goto IL_043f;
					}
					nint num4 = (nint)enumerator3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
					if ((nint)0 == 0)
					{
						goto IL_0211;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X8_v5 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
					object obj3 = (nint)0 + (nint)8;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v580 @ X10_v7-8]");
						if (0 == num)
						{
							break;
						}
						object obj4 = (nint)obj2 - 1;
						obj3 = (nint)obj3 + 16;
						bool flag = (nint)obj2 != 1;
						obj2 = obj4;
						if (flag)
						{
							continue;
						}
						goto IL_0211;
					}
					int num5 = obj3 << 4;
					object obj5 = num4 + num5;
					object obj6 = (nint)obj5 + 312;
					goto IL_048b;
					IL_043f:
					if (num3 == 0)
					{
						return;
					}
					OutOfMemoryException ex = new OutOfMemoryException();
					if ((nint)obj == 1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
						num3 = (int)obj7;
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						continue;
					}
					break;
					IL_0211:
					num2 = unchecked((nint)null);
					goto IL_048b;
					IL_048b:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v653 @ X0_v6+8]");
					obj = 0;
					((IDisposable)enumerator3).Dispose();
					enumerator2 = enumerator3;
					goto IL_043f;
				}
				obj8 = num;
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
				if (obj9 != null)
				{
					object obj10 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v11+12E]");
					object obj11 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v11+12E]");
					if ((nint)0 == 0)
					{
						goto IL_0391;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X8_v11+B0]");
					object obj12 = (nint)0 + (nint)8;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v500 @ X10_v15-8]");
						if (0 == num)
						{
							break;
						}
						object obj13 = (nint)obj11 - 1;
						obj12 = (nint)obj12 + 16;
						bool flag2 = (nint)obj11 != 1;
						obj11 = obj13;
						if (flag2)
						{
							continue;
						}
						goto IL_0391;
					}
					int num6 = obj12 << 4;
					object obj14 = (nint)obj10 + num6;
					object obj15 = (nint)obj14 + 312;
					goto IL_0542;
				}
				goto IL_03e0;
			}
			object current = enumerator.Current;
			if (current != null)
			{
				Transform transform = current as Transform;
				if ((object)transform == null)
				{
					break;
				}
			}
			FindAllChild((Transform)current, ref list);
			continue;
			IL_0391:
			num2 = unchecked((nint)null);
			goto IL_0542;
			IL_03e0:
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_0542:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v563 @ X0_v24+8]");
			obj8 = 0;
			((IDisposable)obj9).Dispose();
			goto IL_03e0;
		}
		InvalidCastException ex3 = new InvalidCastException();
		num = (nint)typeof(IDisposable);
		num2 = unchecked((nint)null);
		obj = typeof(Transform);
		NullReferenceException ex4 = new NullReferenceException();
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000DE")]
	[Address(RVA = "0xBFF9BC", Offset = "0xBFF9BC", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, maxWidth, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv44 = UnityEngine.Object;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, maxWidth, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35601]) = v41;\nL_0020:\n\tgoto L_0025;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v48, maxWidth, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv102 = UnityEngine.Object::op_Equality(img.m_Sprite, 0);\n\tv104 = v102 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_005A;\n\tv95 = &v77 @ stack_-48;\n\tv155 = UnityEngine.Sprite::get_bounds(img.m_Sprite);\n\tv158 = UnityEngine.Sprite::get_bounds(img.m_Sprite);\n\tv89 = UnityEngine.Component::GetComponent(img);\n\tv161 = *([v95 @ X8_v8+10]) + *([v95 @ X8_v8+10]);\n\tv150 = v158.m_Extents + v158.m_Extents;\n\tv162 = v161 / v150;\n\tv151 = v162 * maxWidth;\n\t// 81 MakeStruct v148 @ AGGC03A94_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), maxWidth @ X1 (System.Int32), v151 @ V1_v4 (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(v89, v148);\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void SetSizeFollowWidth(this Image img, int maxWidth)
	{
		//IL_00a5: Expected O, but got I
		if (!(img.sprite == null))
		{
			object obj2 = default(object);
			object obj = obj2;
			Bounds bounds = img.sprite.bounds;
			Bounds bounds2 = img.sprite.bounds;
			RectTransform component = img.GetComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v8+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v8+10]");
			object obj3 = num + 0;
			float num2 = bounds2.m_Extents.x + bounds2.m_Extents.x;
			float num3 = (float)obj3 / num2;
			float y = num3 * (float)maxWidth;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = maxWidth;
			sizeDelta.y = y;
			component.sizeDelta = sizeDelta;
		}
	}

	[Token(Token = "0x60000DF")]
	[Address(RVA = "0xBFFAB0", Offset = "0xBFFAB0", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, maxHeight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv44 = UnityEngine.Object;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, maxHeight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A35602]) = v41;\nL_0020:\n\tgoto L_0025;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v48, maxHeight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv102 = UnityEngine.Object::op_Equality(img.m_Sprite, 0);\n\tv104 = v102 == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_005A;\n\tv95 = &v77 @ stack_-48;\n\tv155 = UnityEngine.Sprite::get_bounds(img.m_Sprite);\n\tv158 = UnityEngine.Sprite::get_bounds(img.m_Sprite);\n\tv89 = UnityEngine.Component::GetComponent(img);\n\tv161 = *([v95 @ X8_v8+10]) + *([v95 @ X8_v8+10]);\n\tv150 = v158.m_Extents + v158.m_Extents;\n\tv162 = v161 / v150;\n\tv151 = maxHeight / v162;\n\t// 81 MakeStruct v148 @ AGGC03B88_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v151 @ V0_v4 (System.Single), maxHeight @ X1 (System.Int32)\n\tUnityEngine.RectTransform::set_sizeDelta(v89, v148);\nL_005A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void SetSizeFollowHeight(this Image img, int maxHeight)
	{
		//IL_00a5: Expected O, but got I
		if (!(img.sprite == null))
		{
			object obj2 = default(object);
			object obj = obj2;
			Bounds bounds = img.sprite.bounds;
			Bounds bounds2 = img.sprite.bounds;
			RectTransform component = img.GetComponent<RectTransform>();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v8+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ X8_v8+10]");
			object obj3 = num + 0;
			float num2 = bounds2.m_Extents.x + bounds2.m_Extents.x;
			float num3 = (float)obj3 / num2;
			float x = (float)maxHeight / num3;
			Vector2 sizeDelta = default(Vector2);
			sizeDelta.x = x;
			sizeDelta.y = maxHeight;
			component.sizeDelta = sizeDelta;
		}
	}

	[Token(Token = "0x60000E0")]
	[Address(RVA = "0xBFFBA4", Offset = "0xBFFBA4", Length = "0xF4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Camera::get_main();\n\tv18 = UnityEngine.Camera::get_orthographicSize(v15);\n\tv51 = UnityEngine.Screen::get_height();\n\tv34 = UnityEngine.Screen::get_width();\n\tv35 = UnityEngine.SpriteRenderer::get_sprite(sprite);\n\tv103 = UnityEngine.Sprite::get_bounds(v35);\n\tv107 = v103.m_Extents + v103.m_Extents;\n\tgoto L_0035;\n\tv110 = UnityEngine.Vector3;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, v93, v37, v38, v39, v40, v41, v42, v104, v43, v44, v45, v46, v47, v48, v49);\n\tv113 = 1;\n\t*([1A35658]) = v113;\nL_0035:\n\tv117 = v18 + v18;\n\tv120 = v117 / v51;\n\tv121 = v120 * v34;\n\tv122 = v121 / v18;\n\tv127 = v82.oneVector * v122;\n\treturnVal2 = v127 / v107;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static Vector3 GetSizeScaleOfSprite(SpriteRenderer sprite)
	{
		Camera main = Camera.main;
		float orthographicSize = main.orthographicSize;
		int height = Screen.height;
		int width = Screen.width;
		Sprite sprite2 = sprite.sprite;
		Bounds bounds = sprite2.bounds;
		float num = bounds.m_Extents.x + bounds.m_Extents.x;
		float num2 = orthographicSize + orthographicSize;
		float num3 = num2 / (float)height;
		float num4 = num3 * (float)width;
		float num5 = num4 / orthographicSize;
		float num6 = Vector3.one.x * num5;
		float x = num6 / num;
		Vector3 result = default(Vector3);
		result.x = x;
		return result;
	}

	[Token(Token = "0x60000E1")]
	[Address(RVA = "0xBFFC98", Offset = "0xBFFC98", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = 0;\n\tv6 = UnityEngine.ColorUtility::TryParseHtmlString(hex, &v4 @ stack_-20_v1 (UnityEngine.Color));\n\treturn 0;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static Color GetColorFromString(string hex)
	{
		Color color = default(Color);
		bool flag = ColorUtility.TryParseHtmlString(hex, out color);
		return default(Color);
	}

	[Token(Token = "0x60000E2")]
	[Address(RVA = "0xBFFCC4", Offset = "0xBFFCC4", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = GameHelper;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35603]) = v34;\nL_0011:\n\tv36 = UnityEngine.Camera::get_main();\n\t// 27 MakeStruct v45 @ AGGC03D14_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 1119092736, 0\n\tv46 = UnityEngine.Camera::ScreenToWorldPoint(v36, v45);\n\tv67 = GameHelper;\n\tv63 = *([v67 @ X8_v5 (Il2CppClass<GameHelper>)+B8]);\n\tv63.bottomLeft = v46;\n\t*([v63 @ X8_v6 (Il2CppStaticFields<GameHelper>)+4]) = v46.y;\n\t*([v63 @ X8_v6 (Il2CppStaticFields<GameHelper>)+8]) = v46.z;\n\tv69 = UnityEngine.Camera::get_main();\n\tv71 = UnityEngine.Screen::get_width();\n\tv59 = UnityEngine.Screen::get_height();\n\t// 51 MakeStruct v75 @ AGGC03D60_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v71 @ X0_v9 (System.Int32), v59 @ X0_v11 (System.Int32), 0\n\tv87 = UnityEngine.Camera::ScreenToWorldPoint(v69, v75);\n\tv101 = GameHelper;\n\tv94 = *([v101 @ X8_v7 (Il2CppClass<GameHelper>)+B8]);\n\tv94.topRight = v87;\n\t*([v94 @ X8_v8 (Il2CppStaticFields<GameHelper>)+10]) = v87.y;\n\t*([v94 @ X8_v8 (Il2CppStaticFields<GameHelper>)+14]) = v87.z;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	static GameHelper()
	{
		//IL_004e: Expected I, but got O
		//IL_0057: Expected I, but got O
		//IL_00e2: Expected I, but got O
		//IL_00eb: Expected I, but got O
		Camera main = Camera.main;
		Vector3 position = default(Vector3);
		position.x = 0f;
		position.y = 90f;
		position.z = 0f;
		Vector3 vector = main.ScreenToWorldPoint(position);
		nint num = (nint)typeof(GameHelper);
		nint num2 = (nint)bottomLeft;
		bottomLeft = vector;
		_ = vector.y;
		_ = vector.z;
		Camera main2 = Camera.main;
		int width = Screen.width;
		int height = Screen.height;
		Vector3 position2 = default(Vector3);
		position2.x = width;
		position2.y = height;
		position2.z = 0f;
		Vector3 vector2 = main2.ScreenToWorldPoint(position2);
		nint num3 = (nint)typeof(GameHelper);
		nint num4 = (nint)bottomLeft;
		topRight = vector2;
		_ = vector2.y;
		_ = vector2.z;
	}
}
