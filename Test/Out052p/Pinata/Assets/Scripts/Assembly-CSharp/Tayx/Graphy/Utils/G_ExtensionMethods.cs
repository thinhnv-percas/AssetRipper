using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Tayx.Graphy.Utils
{
	[Token(Token = "0x200002F")]
	public static class G_ExtensionMethods
	{
		[Token(Token = "0x6000157")]
		[Address(RVA = "0x1642FDC", Offset = "0x1642FDC", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EE9D98]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, active, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AB10]) = v41;\nL_0017:\n\tv44 = 0;\n\tv45 = gameObjects == 0;\n\tif (v45) goto L_0038;\n\tv51 = System.Collections.Generic.List`1<UnityEngine.GameObject>::GetEnumerator(gameObjects);\nL_0025:\n\tv75 = System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>));\n\tv87 = v75 == 0;\n\tif (v87) goto L_0034;\n\tUnityEngine.GameObject::SetActive(0, active);\n\tgoto L_0025;\nL_0034:\n\tv94 = System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>));\n\tgoto L_0058;\n\tthrow System.NullReferenceException;\nL_0038:\n\tv66 = new System.NullReferenceException();\n\tgoto L_0044;\n\tgoto L_0044;\nL_0044:\n\tv85 = Il2CppMethodInfo != 1;\n\tif (v85) goto L_0059;\n\tv88 = 0x6D2BC0(v66, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv96 = 0x6D2490(v88, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv100 = System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.GameObject>+Enumerator<UnityEngine.GameObject>));\n\tv143 = *([v88 @ X0_v11]) == 0;\n\tv102 = ~v143;\n\tif (v102) goto L_005D;\nL_0058:\n\treturn gameObjects;\nL_0059:\n\tv89 = 0x6D2380(v66, Il2CppMethodInfo, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005D:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<GameObject> SetAllActive(this List<GameObject> gameObjects, bool active)
		{
			//IL_0026: Expected I, but got O
			List<GameObject>.Enumerator enumerator = default(List<GameObject>.Enumerator);
			if (gameObjects != null)
			{
				List<GameObject>.Enumerator enumerator2 = gameObjects.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((GameObject)null).SetActive(active);
					IntPtr intPtr = (IntPtr)null;
				}
				enumerator.Dispose();
				goto IL_00af;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					goto IL_00af;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (List<GameObject>)(object)new TypeLoadException();
			IL_00af:
			return gameObjects;
		}

		[Token(Token = "0x6000158")]
		[Address(RVA = "0x1643140", Offset = "0x1643140", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB45F0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, active, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AB11]) = v41;\nL_0017:\n\tv150 = images._size;\n\tv54 = images._size < 1;\n\tif (v54) goto L_005E;\nL_0025:\n\tv151 = v150 < v96;\n\tv87 = ~v151;\n\tv84 = v150 - v96;\n\tv78 = v84 == 0;\n\tv152 = ~v78;\n\tv63 = v87 & v152;\n\tif (v63) goto L_0033;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0033:\n\tv175 = images._items;\n\tv124 = UnityEngine.Component::get_gameObject(v175[v96 @ X21_v6 (System.Int32)]);\n\tv182 = active - v96;\n\tv184 = v182 == 0;\n\tUnityEngine.GameObject::SetActive(v124, v184);\n\tv150 = images._size;\n\tv96 = v96 + 1;\n\tv106 = v96 < images._size;\n\tif (v106) goto L_0025;\nL_005E:\n\treturn images;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Image> SetOneActive(this List<Image> images, int active)
		{
			int count = images.Count;
			if (images.Count >= 1)
			{
				int num = 0;
				do
				{
					bool flag = count < num;
					bool flag2 = !flag;
					int num2 = count - num;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Image[] items = images._items;
					GameObject gameObject = items[num].gameObject;
					int num3 = active - num;
					bool active2 = num3 == 0;
					gameObject.SetActive(active2);
					count = images.Count;
					num++;
				}
				while (num < images.Count);
			}
			return images;
		}

		[Token(Token = "0x6000159")]
		[Address(RVA = "0x16431FC", Offset = "0x16431FC", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EF4508]);\n\tv23 = *([v22 @ X8_v15]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, active, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202AB12]) = v41;\nL_0017:\n\tv44 = 0;\n\tv45 = images == 0;\n\tif (v45) goto L_003D;\n\tv51 = System.Collections.Generic.List`1<UnityEngine.UI.Image>::GetEnumerator(images);\nL_0025:\n\tv77 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::MoveNext(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv89 = v77 == 0;\n\tif (v89) goto L_0038;\n\tv72 = UnityEngine.Component::get_gameObject(0);\n\tUnityEngine.GameObject::SetActive(v72, active);\n\tgoto L_0025;\nL_0038:\n\tv98 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tgoto L_005F;\n\tv115 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_003D:\n\tv66 = new System.NullReferenceException();\n\tgoto L_004B;\n\tgoto L_004B;\n\tgoto L_004B;\n\tgoto L_004B;\nL_004B:\n\tv87 = v54 != 1;\n\tif (v87) goto L_0060;\n\tv90 = 0x6D2BC0(v66, v54, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv100 = 0x6D2490(v90, v54, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv104 = System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>::Dispose(&v44 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.UI.Image>+Enumerator<UnityEngine.UI.Image>));\n\tv150 = *([v90 @ X0_v11]) == 0;\n\tv106 = ~v150;\n\tif (v106) goto L_0064;\nL_005F:\n\treturn images;\nL_0060:\n\tv91 = 0x6D2380(v66, v54, v52, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0064:\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<Image> SetAllActive(this List<Image> images, bool active)
		{
			//IL_0038: Expected I, but got O
			List<Image>.Enumerator enumerator = default(List<Image>.Enumerator);
			if (images != null)
			{
				List<Image>.Enumerator enumerator2 = images.GetEnumerator();
				while (enumerator.MoveNext())
				{
					GameObject gameObject = ((Component)null).gameObject;
					gameObject.SetActive(active);
					IntPtr intPtr = (IntPtr)null;
				}
				enumerator.Dispose();
				goto IL_00c3;
			}
			NullReferenceException ex = new NullReferenceException();
			bool flag = default(bool);
			if (flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					goto IL_00c3;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			return (List<Image>)(object)new TypeLoadException();
			IL_00c3:
			return images;
		}
	}
}
