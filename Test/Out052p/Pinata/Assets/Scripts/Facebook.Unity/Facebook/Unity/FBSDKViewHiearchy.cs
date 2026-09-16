using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Facebook.Unity
{
	[Token(Token = "0x2000049")]
	public class FBSDKViewHiearchy
	{
		[Token(Token = "0x6000190")]
		[Address(RVA = "0xD24E4C", Offset = "0xD24E4C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Facebook.Unity.FBSDKViewHiearchy::GetPath(go, 0x23);\n\treturnVal1 = Facebook.Unity.FBSDKViewHiearchy::CheckPathMatchPath(v11, path);\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CheckGameObjectMatchPath(GameObject go, List<FBSDKCodelessPathComponent> path)
		{
			List<FBSDKCodelessPathComponent> path2 = GetPath(go, 35);
			return CheckPathMatchPath(path2, path);
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0xD2C61C", Offset = "0xD2C61C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv30 = *([1F02E80]);\n\tv31 = *([v30 @ X8_v17]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, path, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([2023C10]) = v49;\nL_0027:\n\tgoto L_0030;\n\tv193 = *([v137 @ X0_v6+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tgoto L_0030;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v137, v127, v125, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0030:\n\tv201 = System.Math::Min(goPath._size, path._size);\n\tv211 = v95 >= v201;\n\tif (v211) goto L_FFFFFFFF;\n\tv104 = path._size;\n\tv214 = v93 + goPath._size;\n\tv107 = v93 + path._size;\n\tgoto L_0046;\nL_0046:\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\n\tv104 = path._size;\n\tv223 = goPath._items;\n\tv224 = v104 < v107;\n\tv87 = ~v224;\n\tv84 = v104 - v107;\n\tv78 = v84 == 0;\n\tv57 = v223[v214 @ X22_v6];\n\tv225 = ~v78;\n\tv63 = v87 & v225;\n\tif (v63) goto L_005C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005C:\n\tv232 = path._items;\n\tv105 = v232[v107 @ X21_v7 (System.Int32)];\n\tv132 = System.String::Compare(v57.<className>k__BackingField, v105.<className>k__BackingField);\n\tv95 = v95 + 1;\n\tv93 = v93 - 1;\n\tv134 = v132 == 0;\n\tif (v134) goto L_0027;\n\tgoto L_0077;\nL_0077:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CheckPathMatchPath(List<FBSDKCodelessPathComponent> goPath, List<FBSDKCodelessPathComponent> path)
		{
			//IL_0012: Expected O, but got I8
			//IL_007a: Expected O, but got I
			object obj = 4294967295L;
			int num = 0;
			int num2 = Math.Min(goPath.Count, path.Count);
			if (num < num2)
			{
				int count = path.Count;
				object obj2 = (long)(IntPtr)obj + (long)goPath.Count;
				int num3 = (int)((long)(IntPtr)obj + (long)path.Count);
				throw new ArgumentOutOfRangeException();
			}
			return true;
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0xD2C614", Offset = "0xD2C614", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Facebook.Unity.FBSDKViewHiearchy::GetPath(go, 0x23);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<FBSDKCodelessPathComponent> GetPath(GameObject go)
		{
			return GetPath(go, 35);
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xD2C748", Offset = "0xD2C748", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EC23B8]);\n\tv27 = *([v26 @ X8_v31]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, limit, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023C11]) = v45;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, limit, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv63 = UnityEngine.Object::op_Equality(go, 0);\n\tv73 = limit - 1;\n\tv76 = limit < 1;\n\tif (v76) goto L_00A3;\n\tv78 = v63 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_00A3;\n\tv118 = new System.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>();\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::.ctor(v118);\n\tgo = Facebook.Unity.FBSDKViewHiearchy::GetParent(go);\n\tgoto L_0054;\n\tv158 = *([v153 @ X8_v10+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0054;\n\tv169 = v153;\n\tv163 = \"il2cpp_codegen_runtime_class_init\"(v169, v150, v62, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0054:\n\tv168 = UnityEngine.Object::op_Inequality(go, 0);\n\tv171 = v168 == 0;\n\tif (v171) goto L_0060;\n\tv174 = Facebook.Unity.FBSDKViewHiearchy::GetPath(go, v73);\n\tgoto L_0088;\nL_0060:\n\tv178 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v178);\n\tv202 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv210 = System.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::Add(&v202 @ X0_v27 (UnityEngine.SceneManagement.Scene), 0);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v178, \"class_name\", v210);\n\tv221 = new Facebook.Unity.FBSDKCodelessPathComponent();\n\tFacebook.Unity.FBSDKCodelessPathComponent::.ctor(v221, v178);\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::Add(v118, v221);\nL_0088:\n\tv200 = Facebook.Unity.FBSDKViewHiearchy::GetAttribute(go, go);\n\tv207 = new Facebook.Unity.FBSDKCodelessPathComponent();\n\tFacebook.Unity.FBSDKCodelessPathComponent::.ctor(v207, v200);\n\tSystem.Collections.Generic.List`1<Facebook.Unity.FBSDKCodelessPathComponent>::Add(v101, v207);\nL_00A3:\n\treturn v101;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<FBSDKCodelessPathComponent> GetPath(GameObject go, int limit)
		{
			bool flag = go == null;
			int limit2 = limit - 1;
			bool flag2 = limit < 1;
			List<FBSDKCodelessPathComponent> list = null;
			if (!flag2)
			{
				bool flag3 = !flag;
				bool flag4 = !flag3;
				list = null;
				if (!flag4)
				{
					List<FBSDKCodelessPathComponent> list2 = new List<FBSDKCodelessPathComponent>();
					GameObject parent = GetParent(go);
					if (go != null)
					{
						List<FBSDKCodelessPathComponent> path = GetPath(go, limit2);
						list = path;
					}
					else
					{
						Dictionary<string, object> dictionary = new Dictionary<string, object>();
						Scene activeScene = SceneManager.GetActiveScene();
						((List<FBSDKCodelessPathComponent>)activeScene).Add((FBSDKCodelessPathComponent)null);
						object value = default(object);
						dictionary.Add("class_name", value);
						FBSDKCodelessPathComponent item = new FBSDKCodelessPathComponent(dictionary);
						list2.Add(item);
						list = list2;
					}
					Dictionary<string, object> attribute = GetAttribute(go, go);
					FBSDKCodelessPathComponent item2 = new FBSDKCodelessPathComponent(attribute);
					list.Add(item2);
				}
			}
			return list;
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xD2C948", Offset = "0xD2C948", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBBA60]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023C12]) = v38;\nL_0017:\n\tv42 = UnityEngine.GameObject::get_transform(go);\n\tv69 = UnityEngine.Transform::get_parent(v42);\n\tgoto L_002D;\n\tv97 = *([v57 @ X8_v7+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_002D;\n\tv104 = v57;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v104, v68, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv51 = UnityEngine.Object::op_Inequality(v69, 0);\n\tv86 = v51 == 0;\n\tif (v86) goto L_0042;\n\treturnVal3 = UnityEngine.Component::get_gameObject(v69);\n\treturn returnVal3;\nL_0042:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static GameObject GetParent(GameObject go)
		{
			Transform transform = go.transform;
			Transform parent = transform.parent;
			if (parent != null)
			{
				return parent.gameObject;
			}
			return null;
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xD2CA04", Offset = "0xD2CA04", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F08260]);\n\tv25 = *([v24 @ X8_v31]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, parent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023C13]) = v43;\nL_0019:\n\tv47 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v47);\n\tv55 = UnityEngine.Object::get_name(obj);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v47, \"class_name\", v55);\n\tgoto L_003E;\n\tv119 = *([v85 @ X0_v11+E0]);\n\tv120 = v119 == 0;\n\tv121 = ~v120;\n\tif (v121) goto L_003E;\n\tv123 = \"il2cpp_codegen_runtime_class_init\"(v85, v82, v57, v64, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003E:\n\tv127 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv129 = v127 == 0;\n\tif (v129) goto L_005F;\n\tv72 = UnityEngine.GameObject::get_transform(obj);\n\tv149 = UnityEngine.Transform::GetSiblingIndex(v72);\n\tgoto L_0058;\n\tv169 = *([v155 @ X8_v27+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0058;\n\tv176 = v155;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v176, v145, v68, v64, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0058:\n\tgoto L_0067;\nL_005F:\n\tgoto L_FFFFFFFF;\n\tv137 = *([v133 @ X0_v21+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_FFFFFFFF;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v133, v126, v68, v64, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0067:\n\tv157 = System.Convert::ToInt64(v149);\n\t// 110 Box v168 @ X0_v18 (System.Object), typeof(System.Int64), &v157 @ X0_v16 (System.Int64)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v47, \"index\", v168);\n\treturn v47;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Dictionary<string, object> GetAttribute(GameObject obj, GameObject parent)
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			string name = obj.name;
			dictionary.Add("class_name", name);
			int value;
			if (parent != null)
			{
				Transform transform = obj.transform;
				value = transform.GetSiblingIndex();
			}
			else
			{
				value = 0;
			}
			long num = Convert.ToInt64(value);
			object value2 = num;
			dictionary.Add("index", value2);
			return dictionary;
		}
	}
}
