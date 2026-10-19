using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AlmostEngine
{
	[Token(Token = "0x200000A")]
	public class SceneUtils
	{
		[Token(Token = "0x600001A")]
		[Address(RVA = "0x3C45F00", Offset = "0x3C45F00", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.SceneManagement.SceneUtility::GetScenePathByBuildIndex(id);\n\tv15 = v11.Length - 6;\n\tv19 = System.String::Substring(v11, 0, v15);\n\tv33 = System.String::LastIndexOf(v11, 0x2F);\n\tv64 = v33 + 1;\n\treturnVal2 = System.String::Substring(v19, v64);\n\treturn returnVal2;\n")]
		public static string GetSceneName(int id)
		{
			string scenePathByBuildIndex = SceneUtility.GetScenePathByBuildIndex(id);
			int length = scenePathByBuildIndex.Length - 6;
			string text = scenePathByBuildIndex.Substring(0, length);
			int num = scenePathByBuildIndex.LastIndexOf('/');
			int startIndex = num + 1;
			return text.Substring(startIndex);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x4C9279C", Offset = "0x4C9279C", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tgoto L_0022;\nL_0022:\n\tv71 = new v68();\n\tSystem.Collections.Generic.List`1<T>::.ctor(v71);\n\tgoto L_0033;\nL_0033:\n\tv92 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv94 = UnityEngine.Resources::FindObjectsOfTypeAll(v92);\n\tv108 = v94.Length < 1;\n\tif (v108) goto L_00EF;\nL_FFFFFFFF:\n\tv143 = 0;\n\tgoto L_006E;\nL_004F:\n\tSystem.Collections.Generic.List`1<T>::Add(v71, v210);\nL_0051:\n\tv143 = v143 + 1;\n\tv244 = v143 >= v94.Length;\n\tif (v244) goto L_00EF;\nL_006E:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v370_asT @ TEMPCOND_v9 (UnityEngine.Component), typeof(UnityEngine.Component), v94[v143 @ X25_v6 (System.Int32)]\n\tv370 = v370_asT == 0;\n\tif (v370) goto L_00FB;\n\tv388 = UnityEngine.Component::get_gameObject(v94[v143 @ X25_v6 (System.Int32)]);\n\tv382 = AlmostEngine.SceneUtils::IsPrefab(v388);\n\tv391 = v382 == 0;\n\tv392 = ~v391;\n\tif (v392) goto L_0051;\n\tv394 = getInactive == 0;\n\tv383 = ~v394;\n\tif (v383) goto L_00BB;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v148_asT @ TEMPCOND_v12 (UnityEngine.Component), typeof(UnityEngine.Component), v94[v143 @ X25_v6 (System.Int32)]\n\tv148 = v148_asT == 0;\n\tif (v148) goto L_00FB;\n\tv208 = UnityEngine.Component::get_gameObject(v94[v143 @ X25_v6 (System.Int32)]);\n\tv419 = UnityEngine.GameObject::get_activeInHierarchy(v208);\n\tv421 = ~v419;\n\tif (v421) goto L_0051;\nL_00BB:\n\tgoto L_00C1;\n\tgoto L_004F;\nL_00EF:\n\treturn v71;\n\tv73 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv68 = Il2CppClass<System.Collections.Generic.List`1<T>>;\n\tgoto L_0022;\nL_00FB:\n\tv206 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_00FF:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\nL_00C1:\n\tv210 = 0x21C11D0(v94[v143 @ X25_v6 (System.Int32)], Il2CppClass<T>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv305 = v210 == 0;\n\tif (v305) goto L_00FF;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<T> FindAllSceneObjects<T>(bool getInactive = true) where T : Component
		{
			nint num = 0;
			List<T> list = new List<T>();
			Type typeFromHandle = typeof(T);
			UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeFromHandle);
			if (array.Length >= 1)
			{
				int num2 = 0;
				T val = default(T);
				do
				{
					if (array[num2] is Component)
					{
						GameObject gameObject = ((Component)array[num2]).gameObject;
						if (!IsPrefab(gameObject))
						{
							if (!getInactive)
							{
								if (!(array[num2] is Component))
								{
									goto IL_0211;
								}
								GameObject gameObject2 = ((Component)array[num2]).gameObject;
								if (!gameObject2.activeInHierarchy)
								{
									goto IL_0088;
								}
							}
							Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
							if ((object)val == null)
							{
								return (List<T>)(object)new InvalidCastException();
							}
							list.Add(val);
						}
						goto IL_0088;
					}
					goto IL_0211;
					IL_0088:
					num2++;
					continue;
					IL_0211:
					InvalidCastException ex = new InvalidCastException();
					throw new NullReferenceException();
				}
				while (num2 < array.Length);
			}
			return list;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3C45F64", Offset = "0x3C45F64", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.GameObject::get_scene(obj);\n\tv26 = v9;\n\tv29 = UnityEngine.SceneManagement.Scene::get_name(&v26 @ stack_-14_v1 (UnityEngine.SceneManagement.Scene));\n\tv34 = v29 == 0;\n\treturn v34;\n")]
		public static bool IsPrefab(GameObject obj)
		{
			Scene scene = obj.scene;
			Scene scene2 = scene;
			string name = scene2.name;
			return name == null;
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3C45FA4", Offset = "0x3C45FA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SceneUtils()
		{
		}
	}
}
