using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HighlightPlus
{
	[ExecuteAlways]
	[DefaultExecutionOrder(-100)]
	[Token(Token = "0x200002C")]
	public class HighlightLabelPoolManager : MonoBehaviour
	{
		[Token(Token = "0x4000208")]
		private static HighlightLabelPoolManager instance;

		[Token(Token = "0x4000209")]
		private static readonly Dictionary<GameObject, Queue<HighlightLabel>> labelPools;

		[Token(Token = "0x400020A")]
		private static readonly HashSet<HighlightLabel> activeLabels;

		[Token(Token = "0x400020B")]
		private static readonly int initialPoolSize;

		[Token(Token = "0x400020C")]
		private const string LABEL_INSTANCE_NAME = "Highlight Plus Label";

		[Token(Token = "0x400020D")]
		private const string LABEL_POOL_NAME = "Highlight Plus Label Pool Manager";

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x7727820", Offset = "0x7727820", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0016;\nL_0016:\n\tHighlightPlus.HighlightLabelPoolManager::DestroySceneLabels();\n\treturn;\n")]
		private static void DomainReloadDisabledSupport()
		{
			DestroySceneLabels();
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x7727A28", Offset = "0x7727A28", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv69 = 0xB292000 + 0x5A0;\n\tgoto L_001B;\nL_001B:\n\tgoto L_001F;\nL_001F:\n\tv83 = UnityEngine.Object::op_Equality(v53.instance, 0);\n\tv94 = ~v83;\n\tif (v94) goto L_004F;\n\tgoto L_002B;\nL_004F:\n\tgoto L_0052;\nL_0052:\n\tv106 = *([v69 @ X22_v5 (System.Int32)]);\n\tv108 = *([v106 @ X0_v41+E4]) == 0;\n\tif (v108) goto L_0077;\n\tv125 = UnityEngine.Object::op_Inequality(v104.instance, this);\n\tv166 = ~v125;\n\tv167 = ~v166;\n\tif (v167) goto L_007C;\nL_FFFFFFFF:\n\t;\n\tgoto L_0068;\nL_0068:\n\tHighlightPlus.HighlightLabelPoolManager::ClearPools();\n\treturn;\nL_0077:\n\tv171 = UnityEngine.Object::op_Inequality(v104.instance, this);\n\tv183 = ~v171;\n\tif (v183) goto L_FFFFFFFF;\nL_007C:\n\tv191 = UnityEngine.Component::get_gameObject(this);\n\tv210 = *([v69 @ X22_v5 (System.Int32)]);\n\tv211 = *([v210 @ X8_v13+E4]) == 0;\n\tif (v211) goto L_008E;\n\tUnityEngine.Object::DestroyImmediate(v191);\nL_FFFFFFFF:\n\t;\n\tgoto L_0068;\nL_008E:\n\tUnityEngine.Object::DestroyImmediate(v191);\nL_FFFFFFFF:\n\t;\n\tgoto L_0068;\nL_002B:\n\tv101.instance = this;\nL_FFFFFFFF:\n\t;\n\tgoto L_0068;\n")]
		private void OnEnable()
		{
			//IL_0058: Expected O, but got I4
			//IL_00fb: Expected O, but got I4
			int num = 187244544 + 1440;
			if (!(instance == null))
			{
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X0_v41+E4]");
				if ((nint)0 != 0)
				{
					if (!(instance != this))
					{
						goto IL_00b6;
					}
				}
				else if (!(instance != this))
				{
					goto IL_00b6;
				}
				GameObject obj2 = base.gameObject;
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v13+E4]");
				if ((nint)0 != 0)
				{
					UnityEngine.Object.DestroyImmediate(obj2);
				}
				else
				{
					UnityEngine.Object.DestroyImmediate(obj2);
				}
			}
			else
			{
				instance = this;
			}
			goto IL_00b6;
			IL_00b6:
			ClearPools();
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x7727E44", Offset = "0x7727E44", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0013;\nL_0013:\n\tv45 = v43.labelPools == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tgoto L_0040;\nL_0030:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::Clear(v43.labelPools);\n\tSystem.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::Clear(v73.activeLabels);\n\treturn;\nL_0040:\n\tthrow System.NullReferenceException;\n")]
		private void OnDestroy()
		{
			if (labelPools != null)
			{
				labelPools.Clear();
				activeLabels.Clear();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x7727888", Offset = "0x7727888", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tv53 = 0xB2CF000 + 0xF48;\n\tgoto L_0019;\nL_0019:\n\tv75 = HighlightPlus.Misc::FindObjectsOfType /* +1 sharing this address */(1, *([v53 @ X20_v14 (System.Int32)]));\n\tv66 = v75 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0045;\n\tgoto L_0095;\nL_0045:\n\tv92 = *([v75 @ X0_v3+18]) < 1;\n\tif (v92) goto L_0083;\n\tv102 = v75 + 0x20;\n\tv106 = 0;\n\tgoto L_005B;\nL_004D:\n\tUnityEngine.Object::DestroyImmediate(v260);\nL_004E:\n\tv106 = v106 + 1;\n\tv157 = v106 >= *([v75 @ X0_v3+18]);\n\tif (v157) goto L_0083;\nL_005B:\n\t;\n\tgoto L_0063;\nL_0063:\n\tv240 = UnityEngine.Object::op_Inequality(*([v102 @ X23_v4+v106 @ X21_v5 (System.Int32)*8]), 0);\n\tv243 = ~v240;\n\tif (v243) goto L_004E;\n\tgoto L_0072;\nL_0072:\n\tv260 = UnityEngine.Component::get_gameObject(*([v102 @ X23_v4+v106 @ X21_v5 (System.Int32)*8]));\n\tgoto L_004D;\nL_0083:\n\tgoto L_0085;\nL_0085:\n\tHighlightPlus.HighlightLabelPoolManager::ClearPools();\n\tv242.instance = 0;\n\treturn;\nL_0095:\n\tthrow System.NullReferenceException;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void DestroySceneLabels()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightLabelPoolManager::DestroySceneLabels");
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x7727C00", Offset = "0x7727C00", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv101 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv53 = *([v101 @ X22_v4 (System.Int32)]);\n\tv55 = *([v53 @ X0_v65+E4]) == 0;\n\tif (v55) goto L_0045;\n\tv76 = UnityEngine.Object::op_Inequality(v51.instance, 0);\n\tv89 = ~v76;\n\tv90 = ~v89;\n\tif (v90) goto L_004C;\n\tgoto L_00AD;\nL_0045:\n\tv94 = UnityEngine.Object::op_Inequality(v51.instance, 0);\n\tv103 = ~v94;\n\tv101 = v101;\n\tif (v103) goto L_00AD;\nL_004C:\n\tgoto L_0054;\nL_0054:\n\tv186 = UnityEngine.Component::get_transform(v166.instance);\n\tv159 = UnityEngine.Transform::get_childCount(v186);\n\tv143 = v159 < 1;\n\tif (v143) goto L_00AD;\n\tv234 = v159;\n\tgoto L_0078;\nL_0066:\n\tUnityEngine.Object::DestroyImmediate(v309);\nL_0072:\n\tv120 = v234 <= 0;\n\tif (v120) goto L_00AD;\nL_0078:\n\tgoto L_0080;\nL_0080:\n\tv219 = UnityEngine.Component::get_transform(v230.instance);\n\tv234 = v234 - 1;\n\tv283 = UnityEngine.Transform::GetChild(v219, v234);\n\tv284 = *([v101 @ X22_v4 (System.Int32)]);\n\tv285 = *([v284 @ X0_v22+E4]) == 0;\n\tif (v285) goto L_0097;\n\tv289 = UnityEngine.Object::op_Inequality(v283, 0);\n\tv291 = ~v289;\n\tif (v291) goto L_0072;\n\tgoto L_009E;\nL_0097:\n\tv295 = UnityEngine.Object::op_Inequality(v283, 0);\n\tv301 = ~v295;\n\tif (v301) goto L_0072;\nL_009E:\n\tv309 = UnityEngine.Component::get_gameObject(v283);\n\tgoto L_0066;\nL_00AD:\n\tgoto L_00B7;\nL_00B7:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::Clear(v182.labelPools);\n\tSystem.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::Clear(v232.activeLabels);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void ClearPools()
		{
			//IL_0021: Expected O, but got I4
			//IL_016f: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v65+E4]");
			if ((nint)0 != 0)
			{
				if (instance != null)
				{
					goto IL_00b8;
				}
			}
			else
			{
				bool flag = instance != null;
				bool flag2 = !flag;
				num = num;
				if (!flag2)
				{
					goto IL_00b8;
				}
			}
			goto IL_0204;
			IL_0204:
			labelPools.Clear();
			activeLabels.Clear();
			return;
			IL_00b8:
			Transform transform = instance.transform;
			int childCount = transform.childCount;
			if (childCount >= 1)
			{
				int num2 = childCount;
				do
				{
					Transform transform2 = instance.transform;
					num2--;
					Transform child = transform2.GetChild(num2);
					object obj2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ X0_v22+E4]");
					if ((nint)0 != 0)
					{
						if (!(child != null))
						{
							continue;
						}
					}
					else if (!(child != null))
					{
						continue;
					}
					GameObject obj3 = child.gameObject;
					UnityEngine.Object.DestroyImmediate(obj3);
				}
				while (num2 > 0);
			}
			goto IL_0204;
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x7727F08", Offset = "0x7727F08", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49.labelPools == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_003A;\n\tgoto L_0080;\nL_003A:\n\tv70 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::ContainsKey(v49.labelPools, prefab);\n\tv90 = v70 == 0;\n\tif (v90) goto L_004A;\nL_0045:\n\treturn;\nL_004A:\n\tgoto L_0052;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::set_Item(v173.labelPools, prefab, v81);\n\tv135 = 0;\n\tgoto L_006A;\nL_0064:\n\tv194 = HighlightPlus.HighlightLabelPoolManager::CreatePooledLabel(prefab);\n\tv135 = v135 + 1;\n\tgoto L_0064;\nL_0080:\n\tthrow System.NullReferenceException;\nL_0052:\n\tv81 = new System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>();\n\tSystem.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>::.ctor(v81);\nL_006A:\n\tgoto L_0078;\nL_0078:\n\tv96 = v135 >= v205.initialPoolSize;\n\tif (v96) goto L_0045;\n")]
		private static void InitializePool(GameObject prefab)
		{
			if (labelPools != null)
			{
				if (!labelPools.ContainsKey(prefab))
				{
					Queue<HighlightLabel> value = new Queue<HighlightLabel>();
					labelPools[prefab] = value;
					for (int i = 0; i < initialPoolSize; i++)
					{
						HighlightLabel highlightLabel = CreatePooledLabel(prefab);
					}
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x7728084", Offset = "0x7728084", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv55 = 0xB2D1000 + 0x110;\n\tgoto L_001A;\nL_001A:\n\tv77 = UnityEngine.Object::Instantiate /* +1 sharing this address */(prefab, *([v55 @ X21_v10 (System.Int32)]));\n\tv68 = v77 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_004A;\n\tgoto L_0093;\nL_004A:\n\tUnityEngine.Object::set_name(v77, \"Highlight Plus Label\");\n\tv130 = UnityEngine.GameObject::get_transform(v77);\n\tgoto L_005B;\nL_005B:\n\tv109 = UnityEngine.Component::get_transform(v122.instance);\n\tUnityEngine.Transform::SetParent(v130, v109, 0);\n\tv110 = UnityEngine.GameObject::GetComponentInChildren(v77);\n\tv110.labelPrefab = prefab;\n\tv110.isPooled = 1;\n\tUnityEngine.GameObject::SetActive(v77, 0);\n\tv112 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::get_Item(v123.labelPools, prefab);\n\tSystem.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>::Enqueue(v112, v110);\n\treturn v110;\nL_0093:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n")]
		private static HighlightLabel CreatePooledLabel(GameObject prefab)
		{
			int num = 187502592 + 272;
			Il2CppRuntime.Boundary("MANAGED", "Method not found @4B0134C (UnityEngine.Object::Instantiate, and 1 more at this address)");
			UnityEngine.Object obj = default(UnityEngine.Object);
			if ((object)obj != null)
			{
				obj.name = "Highlight Plus Label";
				Transform transform = ((GameObject)obj).transform;
				Transform parent = instance.transform;
				transform.SetParent(parent, worldPositionStays: false);
				HighlightLabel componentInChildren = ((GameObject)obj).GetComponentInChildren<HighlightLabel>();
				componentInChildren.labelPrefab = prefab;
				componentInChildren.isPooled = true;
				((GameObject)obj).SetActive(false);
				Queue<HighlightLabel> queue = labelPools[prefab];
				queue.Enqueue(componentInChildren);
				return componentInChildren;
			}
			return (HighlightLabel)(object)new NullReferenceException();
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x772826C", Offset = "0x772826C", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tv51 = 0xB292000 + 0x5A0;\n\tgoto L_001A;\nL_001A:\n\tv59 = *([v51 @ X22_v12 (System.Int32)]);\n\tv61 = *([v59 @ X8_v41+E4]) == 0;\n\tif (v61) goto L_00BB;\n\tv81 = UnityEngine.Object::op_Equality(v57.instance, 0);\n\tv96 = ~v81;\n\tv97 = ~v96;\nL_FFFFFFFF:\n\t;\n\tif (v97) goto L_00C3;\nL_0027:\n\tgoto L_002D;\nL_002D:\n\tHighlightPlus.HighlightLabelPoolManager::InitializePool(prefab);\nL_FFFFFFFF:\n\tv232 = 0;\n\tgoto L_0038;\nL_0038:\n\tv236 = UnityEngine.Object::op_Equality(v232, 0);\n\tv294 = ~v236;\n\tif (v294) goto L_0076;\n\tgoto L_0048;\nL_0048:\n\tv272 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::get_Item(v285.labelPools, prefab);\n\tv180 = v272.Count <= 0;\n\tif (v180) goto L_0076;\n\tgoto L_0066;\nL_0066:\n\tv273 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::get_Item(v286.labelPools, prefab);\n\tv399 = System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>::Dequeue(v273);\nL_FFFFFFFF:\n\tv232 = v399;\n\tgoto L_0038;\nL_0076:\n\tgoto L_007B;\nL_007B:\n\tv365 = UnityEngine.Object::op_Inequality(v232, 0);\n\tv369 = ~v365;\n\tif (v369) goto L_00E4;\n\tgoto L_FFFFFFFF;\nL_00BB:\n\tv101 = UnityEngine.Object::op_Equality(v57.instance, 0);\n\tv111 = ~v101;\nL_FFFFFFFF:\n\t;\n\tif (v111) goto L_0027;\nL_00C3:\n\tv130 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v130, \"Highlight Plus Label Pool Manager\");\n\tv241 = UnityEngine.GameObject::AddComponent(v130);\n\tgoto L_00D8;\nL_00E4:\n\tgoto L_00E7;\nL_00E7:\n\tv384 = HighlightPlus.HighlightLabelPoolManager::CreatePooledLabel(prefab);\nL_FFFFFFFF:\n\tv289 = v384;\nL_00F2:\n\tv398 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::Add(v287.activeLabels, v289);\n\treturn v289;\nL_FFFFFFFF:\n\tv289 = v232;\n\tgoto L_00F2;\nL_00D8:\n\tv319.instance = v241;\nL_FFFFFFFF:\n\t;\n\tgoto L_002D;\n")]
		public static HighlightLabel GetLabelInstance(GameObject prefab)
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X8_v41+E4]");
			if ((nint)0 != 0)
			{
				if (!(instance == null))
				{
					goto IL_007f;
				}
			}
			else if (!(instance == null))
			{
				goto IL_007f;
			}
			GameObject gameObject = new GameObject("Highlight Plus Label Pool Manager");
			HighlightLabelPoolManager highlightLabelPoolManager = gameObject.AddComponent<HighlightLabelPoolManager>();
			instance = highlightLabelPoolManager;
			goto IL_007f;
			IL_007f:
			InitializePool(prefab);
			UnityEngine.Object obj2 = null;
			while (obj2 == null)
			{
				Queue<HighlightLabel> queue = labelPools[prefab];
				if (queue.Count > 0)
				{
					Queue<HighlightLabel> queue2 = labelPools[prefab];
					HighlightLabel highlightLabel = queue2.Dequeue();
					obj2 = highlightLabel;
					continue;
				}
				break;
			}
			HighlightLabel highlightLabel3;
			if (!(obj2 != null))
			{
				HighlightLabel highlightLabel2 = CreatePooledLabel(prefab);
				highlightLabel3 = highlightLabel2;
			}
			else
			{
				highlightLabel3 = (HighlightLabel)obj2;
			}
			bool flag = activeLabels.Add(highlightLabel3);
			return highlightLabel3;
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x7726BAC", Offset = "0x7726BAC", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tgoto L_002D;\nL_002D:\n\tv83 = UnityEngine.Object::op_Inequality(label.labelPrefab, 0);\n\tv88 = ~v83;\n\tv89 = ~v88;\n\tif (v89) goto L_003F;\n\tgoto L_0079;\nL_003F:\n\tgoto L_004A;\nL_004A:\n\tv133 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::ContainsKey(v72.labelPools, label.labelPrefab);\n\tv134 = ~v133;\n\tif (v134) goto L_0079;\n\tgoto L_005C;\nL_005C:\n\tv60 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::get_Item(v73.labelPools, label.labelPrefab);\n\tSystem.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>::Enqueue(v60, label);\n\tv104 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::Remove(v71.activeLabels, label);\n\treturn;\nL_0079:\n\treturn;\n")]
		public static void ReturnToPool(HighlightLabel label)
		{
			if (label.labelPrefab != null && labelPools.ContainsKey(label.labelPrefab))
			{
				Queue<HighlightLabel> queue = labelPools[label.labelPrefab];
				queue.Enqueue(label);
				bool flag = activeLabels.Remove(label);
			}
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x772857C", Offset = "0x772857C", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv45 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv53 = *([v45 @ X21_v10 (System.Int32)]);\n\tv55 = *([v53 @ X0_v27+E4]) == 0;\n\tif (v55) goto L_0046;\n\tv76 = UnityEngine.Object::op_Equality(v51.instance, 0);\n\tv90 = v76 == 0;\n\tif (v90) goto L_004F;\nL_0029:\n\treturn;\nL_0046:\n\tv94 = UnityEngine.Object::op_Equality(v51.instance, 0);\n\tv121 = v94 == 0;\n\tv100 = ~v121;\n\tif (v100) goto L_0029;\nL_004F:\n\tgoto L_005D;\nL_005D:\n\tHighlightPlus.HighlightLabelPoolManager::LateUpdate(HighlightPlus.HighlightLabelPoolManager);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Refresh()
		{
			//IL_0021: Expected O, but got I4
			int num = 187244544 + 1440;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v27+E4]");
			if ((nint)0 != 0)
			{
				if (instance == null)
				{
					return;
				}
			}
			else if (instance == null)
			{
				return;
			}
			((HighlightLabelPoolManager)(object)typeof(HighlightLabelPoolManager)).LateUpdate();
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x7728688", Offset = "0x7728688", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\nL_0012:\n\tgoto L_001E;\nL_001E:\n\t;\n\tv74 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::GetEnumerator(v47.activeLabels);\n\tv88 = v74._current;\n\tv91 = v74._set;\n\tgoto L_003F;\nL_003F:\n\tv123 = UnityEngine.Object::op_Equality(v74._current, 0);\n\tv267 = v123 == 0;\n\tv145 = ~v267;\n\tif (v145) goto L_0031;\n\tv125 = v74._current == 0;\n\tif (v125) goto L_008F;\n\tv302 = *([v88 @ stack_-58_v4 (HighlightPlus.HighlightLabel)+50]) & 1;\n\tv146 = v302 == 0;\n\tif (v146) goto L_0031;\n\tv152 = *([v88 @ stack_-58_v4 (HighlightPlus.HighlightLabel)]);\n\t*([v152 @ X8_v19 (Il2CppClass<UnityEngine.Object>)+238])(v305, v74._current, *([v152 @ X8_v19 (Il2CppClass<UnityEngine.Object>)+240]), 0, v28, v29, v30, v31, v32, v74._set, v34, v35, v36, v37, v38, v39, v40);\n\tv307 = UnityEngine.Component::get_gameObject(v74._current);\n\tv181 = v307 == 0;\n\tif (v181) goto L_0091;\n\tv142 = UnityEngine.GameObject::get_activeSelf(v307);\n\tv310 = v142 == 0;\n\tv147 = ~v310;\n\tif (v147) goto L_0031;\n\tv143 = UnityEngine.Component::get_gameObject(v74._current);\n\tUnityEngine.GameObject::SetActive(v143, 1);\n\tgoto L_0031;\nL_0065:\n\tSystem.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>::Dispose(&v91 @ stack_-50_v4 (System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>));\nL_006D:\n\treturn;\nL_008F:\n\tv131 = new System.NullReferenceException();\n\tv257 = 0;\n\tgoto L_0094;\nL_0091:\n\tv179 = new System.NullReferenceException();\n\tv177 = v131;\n\tgoto L_0094;\nL_0094:\n\t// 148 Interrupt\n\tgoto L_00A7;\nL_00A7:\n\tv202 = 0 != 1;\n\tif (v202) goto L_00B6;\n\tv256 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv299 = 0x8BF5BF4(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>::Dispose(&v91 @ stack_-50_v4 (System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>));\n\tv245 = *([v256 @ X0_v8]) == 0;\n\tif (v245) goto L_006D;\n\tv260 = new System.OutOfMemoryException();\n\tv257 = *([v256 @ X0_v8]);\n\tv177 = v260;\nL_00B6:\n\tv265 = 0x359B380(&v257 @ stack_-68_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv301 = 0x8BF0368(v177, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv293 = 0xA1B8(v301, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0031:\n\tv155 = System.Collections.Generic.HashSet`1<System.Object>+Enumerator<System.Object>::MoveNext(&v91 @ stack_-50_v4 (System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>));\n\tv160 = v155 == 0;\n\tif (v160) goto L_0065;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void LateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightLabelPoolManager::LateUpdate");
		}

		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x77288B8", Offset = "0x77288B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HighlightLabelPoolManager()
		{
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x77288C0", Offset = "0x77288C0", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv75 = new System.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>();\n\tSystem.Collections.Generic.HashSet`1<HighlightPlus.HighlightLabel>::.ctor(v75);\n\tv81.activeLabels = v75;\n\tv86.initialPoolSize = 5;\n\treturn;\nL_002C:\n\tv57 = new System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, System.Collections.Generic.Queue`1<HighlightPlus.HighlightLabel>>::.ctor(v57);\n\tv67.labelPools = v57;\n")]
		static HighlightLabelPoolManager()
		{
			Dictionary<GameObject, Queue<HighlightLabel>> dictionary = new Dictionary<GameObject, Queue<HighlightLabel>>();
			labelPools = dictionary;
			HashSet<HighlightLabel> hashSet = new HashSet<HighlightLabel>();
			activeLabels = hashSet;
			initialPoolSize = 5;
		}
	}
}
