using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace Lean.Pool
{
	[AddComponentMenu("Lean/Pool/Lean GameObject Pool")]
	[HelpURL("https://carloswilkes.github.io/Documentation/LeanPool#LeanGameObjectPool")]
	[ExecuteInEditMode]
	[Token(Token = "0x2000006")]
	public class LeanGameObjectPool : MonoBehaviour, ISerializationCallbackReceiver
	{
		[Serializable]
		[Token(Token = "0x2000007")]
		public class Delay
		{
			[Token(Token = "0x4000017")]
			[FieldOffset(Offset = "0x10")]
			public GameObject Clone;

			[Token(Token = "0x4000018")]
			[FieldOffset(Offset = "0x18")]
			public float Life;

			[Token(Token = "0x6000039")]
			[Address(RVA = "0x1361708", Offset = "0x1361708", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Delay()
			{
			}
		}

		[Token(Token = "0x2000008")]
		public enum NotificationType
		{
			[Token(Token = "0x400001A")]
			None = 0,
			[Token(Token = "0x400001B")]
			SendMessage = 1,
			[Token(Token = "0x400001C")]
			BroadcastMessage = 2,
			[Token(Token = "0x400001D")]
			IPoolable = 3,
			[Token(Token = "0x400001E")]
			BroadcastIPoolable = 4
		}

		[Token(Token = "0x4000007")]
		public static LinkedList<LeanGameObjectPool> Instances;

		[SerializeField]
		[FormerlySerializedAs("Prefab")]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		private GameObject prefab;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x28")]
		public NotificationType Notification;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x2C")]
		public int Preload;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x30")]
		public int Capacity;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x34")]
		public bool Recycle;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x35")]
		public bool Persist;

		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x36")]
		public bool Stamp;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x37")]
		public bool Warnings;

		[SerializeField]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x38")]
		private List<GameObject> spawnedClonesList;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x40")]
		private HashSet<GameObject> spawnedClonesHashSet;

		[SerializeField]
		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x48")]
		private List<GameObject> despawnedClones;

		[SerializeField]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x50")]
		private List<Delay> delays;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x58")]
		private LinkedListNode<LeanGameObjectPool> node;

		[Token(Token = "0x4000015")]
		private static Dictionary<GameObject, LeanGameObjectPool> prefabMap;

		[Token(Token = "0x4000016")]
		private static List<IPoolable> tempPoolables;

		[Token(Token = "0x17000001")]
		public GameObject Prefab
		{
			[Token(Token = "0x6000010")]
			[Address(RVA = "0x135EC9C", Offset = "0x135EC9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.prefab;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Prefab;
			}
			[Token(Token = "0x600000F")]
			[Address(RVA = "0x135E934", Offset = "0x135E934", Length = "0x94")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A36974]) = v40;\nL_001A:\n\tgoto L_001F;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v41, value, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = UnityEngine.Object::op_Inequality(value, this.prefab);\n\tv53 = v51 == 0;\n\tif (v53) goto L_0035;\n\tLean.Pool.LeanGameObjectPool::UnregisterPrefab(this);\n\tthis.prefab = value;\n\tLean.Pool.LeanGameObjectPool::RegisterPrefab(this);\n\treturn;\nL_0035:\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != Prefab)
				{
					UnregisterPrefab();
					prefab = value;
					RegisterPrefab();
				}
			}
		}

		[Token(Token = "0x17000002")]
		public int Spawned
		{
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x135EFD0", Offset = "0x135EFD0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36977]) = v34;\nL_0013:\n\tv35 = this.spawnedClonesList;\n\tv39 = this.spawnedClonesHashSet;\n\treturnVal1 = v39._count + v35._size;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<GameObject> list = spawnedClonesList;
				HashSet<GameObject> hashSet = spawnedClonesHashSet;
				return hashSet.Count + list.Count;
			}
		}

		[Token(Token = "0x17000003")]
		public int Despawned
		{
			[Token(Token = "0x6000014")]
			[Address(RVA = "0x135F034", Offset = "0x135F034", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A36978]) = v33;\nL_0010:\n\tv34 = this.despawnedClones;\n\treturn v34._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<GameObject> list = despawnedClones;
				return list.Count;
			}
		}

		[Token(Token = "0x17000004")]
		public int Total
		{
			[Token(Token = "0x6000015")]
			[Address(RVA = "0x135F07C", Offset = "0x135F07C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = Lean.Pool.LeanGameObjectPool::get_Spawned(this);\n\tv12 = Lean.Pool.LeanGameObjectPool::get_Despawned(this);\n\treturnVal1 = v12 + v8;\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int spawned = Spawned;
				int despawned = Despawned;
				return despawned + spawned;
			}
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x135ECA4", Offset = "0x135ECA4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, foundPool, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Lean.Pool.LeanGameObjectPool;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, foundPool, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36975]) = v41;\nL_001C:\n\tgoto L_002E;\n\tv48 = \"il2cpp_codegen_runtime_class_init\"(v42, foundPool, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv50 = Lean.Pool.LeanGameObjectPool;\nL_002E:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v51.prefabMap, prefab, foundPool);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TryFindPoolByPrefab(GameObject prefab, ref LeanGameObjectPool foundPool)
		{
			return prefabMap.TryGetValue(prefab, out foundPool);
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x135ED34", Offset = "0x135ED34", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv135 = Lean.Pool.LeanGameObjectPool;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv176 = Il2CppMethodInfo;\n\tv177 = \"il2cpp_codegen_initialize_runtime_metadata\"(v176, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv195 = Il2CppMethodInfo;\n\tv196 = \"il2cpp_codegen_initialize_runtime_metadata\"(v195, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv232 = UnityEngine.Object;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v232, pool, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A36976]) = v55;\nL_003C:\n\tgoto L_0041;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v56, pool, methodInfo, v39, v40, v41, v42, v43, v57, v45, v46, v47, v48, v49, v50, v51);\n\tv69 = Lean.Pool.LeanGameObjectPool;\nL_0041:\n\tv72 = v70.Instances == 0;\n\tif (v72) goto L_00AE;\n\tv91 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>::GetEnumerator(v70.Instances);\nL_005A:\n\tv155 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::MoveNext(&v90 @ stack_-B8_v3 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\n\tv171 = v155 == 0;\n\tif (v171) goto L_FFFFFFFF;\n\tv235 = System.Collections.Generic.HashSet`1<System.Object>::Contains(*([v178 @ stack_-78+40]), clone);\n\tv316 = v235 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_008A;\n\tv320 = *([v178 @ stack_-78+38]);\n\tv152 = *([v320 @ X8_v18+18]) - 1;\nL_0071:\n\tv365 = v152 & 0x80000000;\n\tv366 = v365 == 0;\n\tv147 = ~v366;\n\tif (v147) goto L_005A;\n\tv370 = System.Collections.Generic.List`1<System.Object>::get_Item(*([v178 @ stack_-78+38]), v152);\n\tgoto L_0085;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v371, v369, v368, v39, v40, v41, v42, v43, v107, v105, v46, v47, v48, v49, v50, v51);\nL_0085:\n\tv358 = UnityEngine.Object::op_Equality(v370, clone);\n\tv152 = v152 - 1;\n\tv359 = v358 == 0;\n\tif (v359) goto L_0071;\nL_008A:\n\t*([pool @ X1 (Lean.Pool.LeanGameObjectPool&)]) = v178;\nL_008E:\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>::Dispose(&v90 @ stack_-B8_v3 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>));\nL_0091:\n\tv288 = v280 - 5;\n\tv290 = v288 == 0;\n\treturnVal1 = v283 & v290;\n\treturn returnVal1;\n\tgoto L_008E;\n\tv203 = new System.NullReferenceException();\n\tv208 = new System.NullReferenceException();\n\tv243 = new System.NullReferenceException();\n\tv118 = new System.NullReferenceException();\nL_00AE:\n\tv127 = new System.NullReferenceException();\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\n\tgoto L_00C1;\nL_00C1:\n\tv166 = v113 != 1;\n\tif (v166) goto L_FFFFFFFF;\n\tv173 = 0x1854E70(v127, v113, v94, v39, v40, v41, v42, v43, v90, v131, v46, v47, v48, v49, v50, v51);\n\tv189 = *([v173 @ X0_v16]);\n\tv182 = 0x1854E80(v173, v113, v94, v39, v40, v41, v42, v43, v90, v131, v46, v47, v48, v49, v50, v51);\n\tSystem.Collections.Generic.LinkedList`1+Enumerator::Dispose /* +1 sharing this address */(&v102 @ stack_-90_v2 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>), *([v110 @ X24_v1 (Il2CppMethodInfo)]));\n\tv309 = *([v173 @ X0_v16]) == 0;\n\tv188 = ~v309;\n\tif (v188) goto L_00D3;\n\tgoto L_0091;\n\tgoto L_00D7;\nL_00D3:\n\tv186 = new System.OutOfMemoryException();\nL_00D7:\n\tSystem.Collections.Generic.LinkedList`1+Enumerator::Dispose /* +1 sharing this address */(&v102 @ stack_-90_v2 (System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>+Enumerator<Lean.Pool.LeanGameObjectPool>), *([v110 @ X24_v1 (Il2CppMethodInfo)]));\n\tv229 = v189 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_00DE;\n\tv311 = 0xBD3CD0(v190, *([v110 @ X24_v1 (Il2CppMethodInfo)]), v94, v39, v40, v41, v42, v43, v90, v131, v46, v47, v48, v49, v50, v51);\nL_00DE:\n\tv314 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v314, *([v110 @ X24_v1 (Il2CppMethodInfo)]), v94, v39, v40, v41, v42, v43, v90, v131, v46, v47, v48, v49, v50, v51);\n\treturn returnVal2;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static bool TryFindPoolByClone(GameObject clone, ref LeanGameObjectPool pool)
		{
			//IL_0183: Expected I4, but got O
			//IL_0033: Expected O, but got I
			//IL_006f: Expected O, but got I
			//IL_0274: Expected I4, but got I8
			//IL_00ab: Expected O, but got I
			bool flag = Instances == null;
			LinkedList<LeanGameObjectPool>.Enumerator enumerator2 = default(LinkedList<LeanGameObjectPool>.Enumerator);
			LinkedList<LeanGameObjectPool>.Enumerator enumerator = enumerator2;
			nint num = 0;
			int num3;
			bool flag4;
			if (!flag)
			{
				LinkedList<LeanGameObjectPool>.Enumerator enumerator3 = Instances.GetEnumerator();
				bool flag2;
				object obj3 = default(object);
				while (true)
				{
					flag2 = enumerator2.MoveNext();
					if (flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_-78+40]");
						if (!((HashSet<object>)0).Contains(clone))
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_-78+38]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X8_v18+18]");
							int num2 = (int)(-1);
							while ((int)(num2 & 0x80000000L) == 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ stack_-78+38]");
								UnityEngine.Object obj2 = (UnityEngine.Object)((List<object>)0)[num2];
								bool flag3 = obj2 == clone;
								num2--;
								if (!flag3)
								{
									continue;
								}
								goto IL_00f0;
							}
							continue;
						}
						goto IL_00f0;
					}
					num3 = 9;
					break;
					IL_00f0:
					ref LeanGameObjectPool reference = ref *(LeanGameObjectPool*)obj3;
					num3 = 5;
					break;
				}
				enumerator2.Dispose();
				flag4 = flag2;
				goto IL_0106;
			}
			NullReferenceException ex = new NullReferenceException();
			ref LeanGameObjectPool reference2 = default(ref LeanGameObjectPool);
			int num4;
			if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2) == (void*)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				object obj4 = default(object);
				num4 = (int)obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E9D9E4 (System.Collections.Generic.LinkedList`1+Enumerator::Dispose, and 1 more at this address)");
				if (obj4 == null)
				{
					num3 = 0;
					flag4 = false;
					goto IL_0106;
				}
				OutOfMemoryException ex2 = new OutOfMemoryException();
				NullReferenceException ex3 = (NullReferenceException)(object)ex2;
			}
			else
			{
				num4 = 0;
				NullReferenceException ex3 = ex;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @E9D9E4 (System.Collections.Generic.LinkedList`1+Enumerator::Dispose, and 1 more at this address)");
			if (num4 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @BD3CD0");
			}
			OutOfMemoryException ex4 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
			bool result = default(bool);
			return result;
			IL_0106:
			int num5 = num3 - 5;
			bool flag5 = num5 == 0;
			return flag4 && flag5;
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x135F0A8", Offset = "0x135F0A8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = 0;\n\tv4 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, &v3 @ stack_-8_v1 (UnityEngine.GameObject));\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Spawn()
		{
			GameObject clone = null;
			bool flag = TrySpawn(ref clone);
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x135F248", Offset = "0x135F248", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = 0;\n\tv20 = UnityEngine.Component::get_transform(this);\n\tv23 = UnityEngine.Transform::get_localRotation(v20);\n\tv55 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, &v19 @ stack_-28_v1 (UnityEngine.GameObject), position, v23, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Spawn(Vector3 position)
		{
			GameObject clone = null;
			Transform transform = base.transform;
			Quaternion localRotation = transform.localRotation;
			bool flag = TrySpawn(ref clone, position, localRotation);
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x135F50C", Offset = "0x135F50C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = 0;\n\tv9 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, &v7 @ stack_-8_v1 (UnityEngine.GameObject), parent, worldPositionStays);\n\treturn 0;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject Spawn(Transform parent, bool worldPositionStays = false)
		{
			GameObject clone = null;
			bool flag = TrySpawn(ref clone, parent, worldPositionStays);
			return null;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x135F7D0", Offset = "0x135F7D0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0;\n\tv15 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, &v12 @ stack_-8_v1 (UnityEngine.GameObject), position, rotation, parent);\n\treturn 0;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObject Spawn(Vector3 position, Quaternion rotation, Transform parent = null)
		{
			GameObject clone = null;
			bool flag = TrySpawn(ref clone, position, rotation, parent);
			return null;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x135F534", Offset = "0x135F534", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv44 = UnityEngine.Debug;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, clone, parent, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv68 = UnityEngine.Object;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, clone, parent, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv77 = \"You're attempting to spawn from a pool with a null prefab\";\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, clone, parent, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A36979]) = v61;\nL_002B:\n\tgoto L_0030;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, clone, parent, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0030:\n\tv75 = UnityEngine.Object::op_Equality(v336.prefab, 0);\n\tv79 = v75 == 0;\n\tif (v79) goto L_004B;\n\tv81 = ~v336.Warnings;\n\tif (v81) goto L_FFFFFFFF;\n\tgoto L_0044;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v88, v73, v74, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0044:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to spawn from a pool with a null prefab\", v336);\n\tgoto L_00D8;\nL_004B:\n\tgoto L_0050;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v82, v73, v74, worldPositionStays, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0050:\n\tv107 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv186 = v107 == 0;\n\tif (v186) goto L_0096;\n\tv235 = v130 == 0;\n\tif (v235) goto L_0096;\n\tv244 = UnityEngine.GameObject::get_transform(v336.prefab);\n\tv158 = UnityEngine.Transform::get_position(v244);\n\tv156 = v158.y;\n\tv154 = v158.z;\n\tgoto L_0073;\n\tv282 = UnityEngine.Quaternion;\n\tv283 = \"il2cpp_codegen_initialize_runtime_metadata\"(v282, v269, v106, worldPositionStays, methodInfo, v47, v48, v49, v270, v271, v272, v53, v54, v55, v56, v57);\n\tv286 = 1;\n\t*([1A3551A]) = v286;\nL_0073:\n\tv291 = UnityEngine.Quaternion;\n\tv292 = *([v291 @ X8_v11 (Il2CppClass<UnityEngine.Quaternion>)+B8]);\n\tgoto L_FFFFFFFF;\n\tv301 = UnityEngine.Vector3;\n\tv302 = \"il2cpp_codegen_initialize_runtime_metadata\"(v301, v269, v106, worldPositionStays, methodInfo, v47, v48, v49, v270, v271, v272, v53, v54, v55, v56, v57);\n\tv305 = 1;\n\t*([1A35658]) = v305;\n\tgoto L_00C5;\nL_0096:\n\tv239 = UnityEngine.Component::get_transform(v336);\n\tv158 = UnityEngine.Transform::get_localPosition(v239);\n\tv156 = v158.y;\n\tv154 = v158.z;\n\tv262 = UnityEngine.Component::get_transform(v336);\n\tv258 = UnityEngine.Transform::get_localRotation(v262);\n\tv263 = UnityEngine.Component::get_transform(v336);\n\tv340 = UnityEngine.Transform::get_localScale(v263);\nL_00C5:\n\t// 197 MakeStruct v115 @ AGG136379C_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v158 @ V0_v2 (UnityEngine.Vector3), v156 @ V1_v2 (System.Single), v154 @ V2_v2 (System.Single)\n\t// 198 MakeStruct v112 @ AGG136379C_3_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v146 @ V3_v2 (UnityEngine.Quaternion), v125 @ V4_v2 (System.Single), v123 @ V5_v2 (System.Single), v121 @ V6_v2 (System.Single)\n\treturnVal1 = Lean.Pool.LeanGameObjectPool::TrySpawn(v336, v162, v115, v112, v127, parent, 1);\nL_00D8:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrySpawn(ref GameObject clone, Transform parent, bool worldPositionStays = false)
		{
			//IL_01bf: Expected I, but got O
			//IL_01c8: Expected I, but got O
			//IL_026a: Expected F4, but got I
			//IL_027a: Expected F4, but got I
			//IL_028a: Expected F4, but got I
			if (Prefab == null)
			{
				if (Warnings)
				{
					Debug.LogWarning("You're attempting to spawn from a pool with a null prefab", this);
				}
				return false;
			}
			bool flag = default(bool);
			Vector3 vector;
			float y;
			float z;
			float w;
			float z2;
			float y2;
			Vector3 localScale;
			Quaternion quaternion;
			if (parent != null && flag)
			{
				Transform transform = Prefab.transform;
				vector = transform.position;
				y = vector.y;
				z = vector.z;
				nint num = (nint)typeof(Quaternion);
				nint num2 = (nint)Quaternion.identity;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X8_v12 (Il2CppStaticFields<UnityEngine.Quaternion>)+C]");
				w = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X8_v12 (Il2CppStaticFields<UnityEngine.Quaternion>)+8]");
				z2 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X8_v12 (Il2CppStaticFields<UnityEngine.Quaternion>)+4]");
				y2 = 0f;
				localScale = Vector3.one;
				quaternion = Quaternion.identity;
			}
			else
			{
				Transform transform2 = base.transform;
				vector = transform2.localPosition;
				y = vector.y;
				z = vector.z;
				Transform transform3 = base.transform;
				Quaternion localRotation = transform3.localRotation;
				Transform transform4 = base.transform;
				Vector3 localScale2 = transform4.localScale;
				w = localRotation.w;
				z2 = localRotation.z;
				y2 = localRotation.y;
				localScale = localScale2;
				quaternion = localRotation;
			}
			Vector3 localPosition = default(Vector3);
			localPosition.x = vector.x;
			localPosition.y = y;
			localPosition.z = z;
			Quaternion localRotation2 = default(Quaternion);
			localRotation2.x = quaternion.x;
			localRotation2.y = y2;
			localRotation2.z = z2;
			localRotation2.w = w;
			ref GameObject clone2 = default(ref GameObject);
			return TrySpawn(ref clone2, localPosition, localRotation2, localScale, parent, worldPositionStays: true);
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x135F2CC", Offset = "0x135F2CC", Length = "0x240")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv54 = UnityEngine.Debug;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, clone, parent, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\n\tv72 = UnityEngine.Object;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, clone, parent, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\n\tv81 = \"You're attempting to spawn from a pool with a null prefab\";\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, clone, parent, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\n\tv65 = 1;\n\t*([1A3697A]) = v65;\nL_0035:\n\tgoto L_003A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, clone, parent, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\nL_003A:\n\tv79 = UnityEngine.Object::op_Equality(this.prefab, 0);\n\tv83 = v79 == 0;\n\tif (v83) goto L_0055;\n\tv85 = ~this.Warnings;\n\tif (v85) goto L_FFFFFFFF;\n\tgoto L_004E;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v92, v77, v78, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\nL_004E:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to spawn from a pool with a null prefab\", this);\n\tgoto L_00BF;\nL_0055:\n\tgoto L_005A;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v86, v77, v78, methodInfo, v57, v58, v59, v60, position, v0, v2, rotation, v3, v5, v6, v61);\nL_005A:\n\tv111 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv215 = v111 == 0;\n\tif (v215) goto L_0098;\n\tv331 = UnityEngine.Transform::InverseTransformPoint(parent, position);\n\tv338 = UnityEngine.Transform::get_rotation(parent);\n\tv342 = UnityEngine.Quaternion::Inverse(v338);\n\tv348 = rotation * v342.w;\n\tv349 = rotation.w * v342;\n\tv350 = rotation.y * v342.w;\n\tv294 = rotation.w * v342.y;\n\tv293 = rotation.z * v342;\n\tv292 = rotation.y * v342;\n\tv351 = rotation * v342;\n\tv291 = rotation.z * v342.w;\n\tv352 = rotation.w * v342.w;\n\tv290 = rotation.w * v342.z;\n\tv315 = rotation.z * v342.y;\n\tv289 = rotation * v342.z;\n\tv288 = rotation * v342.y;\n\tv323 = rotation.y * v342.y;\n\tv353 = v348 + v349;\n\tv354 = v350 + v294;\n\tv295 = v291 + v290;\n\tv355 = v352 - v351;\n\tv287 = rotation.y * v342.z;\n\tv321 = rotation.z * v342.z;\n\tv298 = v315 + v353;\n\tv319 = v289 + v354;\n\tv317 = v292 + v295;\n\tv301 = v355 - v323;\n\tv310 = v298 - v287;\n\tv185 = v319 - v293;\n\tv187 = v317 - v288;\n\tv189 = v301 - v321;\nL_0098:\n\tv334 = UnityEngine.GameObject::get_transform(this.prefab);\n\tv344 = UnityEngine.Transform::get_localScale(v334);\n\t// 173 MakeStruct v119 @ AGG13634DC_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v177 @ V14_v4 (UnityEngine.Vector3), v179 @ V12_v4 (System.Single), v181 @ V11_v4 (System.Single)\n\t// 174 MakeStruct v116 @ AGG13634DC_3_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v183 @ V13_v4 (UnityEngine.Quaternion), v185 @ V10_v4 (System.Single), v187 @ V9_v4 (System.Single), v189 @ V8_v4 (System.Single)\n\treturnVal1 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, clone, v119, v116, v344, parent, 0);\nL_00BF:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrySpawn(ref GameObject clone, Vector3 position, Quaternion rotation, Transform parent = null)
		{
			//IL_038f: Expected O, but got F4
			if (Prefab == null)
			{
				if (Warnings)
				{
					Debug.LogWarning("You're attempting to spawn from a pool with a null prefab", this);
				}
				return false;
			}
			bool flag = parent != null;
			bool flag2 = !flag;
			Vector3 vector = position;
			float y = position.y;
			float z = position.z;
			Quaternion quaternion = rotation;
			float y2 = rotation.y;
			float z2 = rotation.z;
			float w = rotation.w;
			if (!flag2)
			{
				Vector3 vector2 = parent.InverseTransformPoint(position);
				Quaternion rotation2 = parent.rotation;
				Quaternion quaternion2 = Quaternion.Inverse(rotation2);
				Quaternion quaternion3 = default(Quaternion);
				float num = quaternion3.x * quaternion2.w;
				float num2 = rotation.w * quaternion2.x;
				float num3 = rotation.y * quaternion2.w;
				float num4 = rotation.w * quaternion2.y;
				float num5 = rotation.z * quaternion2.x;
				float num6 = rotation.y * quaternion2.x;
				float num7 = quaternion3.x * quaternion2.x;
				float num8 = rotation.z * quaternion2.w;
				float num9 = rotation.w * quaternion2.w;
				float num10 = rotation.w * quaternion2.z;
				float num11 = rotation.z * quaternion2.y;
				float num12 = quaternion3.x * quaternion2.z;
				float num13 = quaternion3.x * quaternion2.y;
				float num14 = rotation.y * quaternion2.y;
				float num15 = num + num2;
				float num16 = num3 + num4;
				float num17 = num8 + num10;
				float num18 = num9 - num7;
				float num19 = rotation.y * quaternion2.z;
				float num20 = rotation.z * quaternion2.z;
				float num21 = num11 + num15;
				float num22 = num12 + num16;
				float num23 = num6 + num17;
				float num24 = num18 - num14;
				float num25 = num21 - num19;
				y2 = num22 - num5;
				z2 = num23 - num13;
				w = num24 - num20;
				vector = vector2;
				y = vector2.y;
				z = vector2.z;
				quaternion = (Quaternion)num25;
			}
			Transform transform = Prefab.transform;
			Vector3 localScale = transform.localScale;
			Vector3 localPosition = default(Vector3);
			localPosition.x = vector.x;
			localPosition.y = y;
			localPosition.z = z;
			Quaternion localRotation = default(Quaternion);
			localRotation.x = quaternion.x;
			localRotation.y = y2;
			localRotation.z = z2;
			localRotation.w = w;
			return TrySpawn(ref clone, localPosition, localRotation, localScale, parent, worldPositionStays: false);
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x135F0C0", Offset = "0x135F0C0", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv36 = UnityEngine.Debug;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, clone, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv62 = UnityEngine.Object;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, clone, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv71 = \"You're attempting to spawn from a pool with a null prefab\";\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, clone, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A3697B]) = v55;\nL_0027:\n\tgoto L_002C;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, clone, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_002C:\n\tv69 = UnityEngine.Object::op_Equality(this.prefab, 0);\n\tv73 = v69 == 0;\n\tif (v73) goto L_0047;\n\tv75 = ~this.Warnings;\n\tif (v75) goto L_FFFFFFFF;\n\tgoto L_0040;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v80, v67, v68, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0040:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to spawn from a pool with a null prefab\", this);\n\tgoto L_0080;\nL_0047:\n\tv95 = UnityEngine.GameObject::get_transform(this.prefab);\n\tv202 = UnityEngine.Transform::get_localPosition(v95);\n\tv207 = UnityEngine.Transform::get_localRotation(v95);\n\tv213 = UnityEngine.Transform::get_localScale(v95);\n\treturnVal1 = Lean.Pool.LeanGameObjectPool::TrySpawn(this, clone, v202, v207, v213, 0, 0);\nL_0080:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool TrySpawn(ref GameObject clone)
		{
			if (Prefab == null)
			{
				if (Warnings)
				{
					Debug.LogWarning("You're attempting to spawn from a pool with a null prefab", this);
				}
				return false;
			}
			Transform transform = Prefab.transform;
			Vector3 localPosition = transform.localPosition;
			Quaternion localRotation = transform.localRotation;
			Vector3 localScale = transform.localScale;
			return TrySpawn(ref clone, localPosition, localRotation, localScale, null, worldPositionStays: false);
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x135F7F0", Offset = "0x135F7F0", Length = "0x3B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004F;\n\tv70 = UnityEngine.Debug;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv96 = Il2CppMethodInfo;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv101 = Il2CppMethodInfo;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv110 = Il2CppMethodInfo;\n\tv111 = \"il2cpp_codegen_initialize_runtime_metadata\"(v110, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv332 = Il2CppMethodInfo;\n\tv333 = \"il2cpp_codegen_initialize_runtime_metadata\"(v332, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv478 = UnityEngine.Object;\n\tv479 = \"il2cpp_codegen_initialize_runtime_metadata\"(v478, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv549 = \"This pool contained a null despawned clone, did you accidentally destroy it?\";\n\tv550 = \"il2cpp_codegen_initialize_runtime_metadata\"(v549, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv554 = \"You're attempting to spawn from a pool with a null prefab\";\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v554, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\n\tv80 = 1;\n\t*([1A3697C]) = v80;\nL_004F:\n\tgoto L_0054;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v81, clone, parent, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\nL_0054:\n\tv94 = UnityEngine.Object::op_Inequality(this.prefab, 0);\n\tv99 = v94 == 0;\n\tif (v99) goto L_00AB;\n\tv482 = this.despawnedClones;\n\tv122 = v482._size < 1;\n\tv262 = v482._size - 1;\n\tif (v122) goto L_00C8;\nL_0076:\n\tv484 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v482, v262);\n\t*([clone @ X1 (UnityEngine.GameObject&)]) = v484;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::RemoveAt(this.despawnedClones, v262);\n\tgoto L_0088;\n\tv569 = \"il2cpp_codegen_runtime_class_init\"(v558, v556, v555, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\nL_0088:\n\tv574 = UnityEngine.Object::op_Inequality(*([clone @ X1 (UnityEngine.GameObject&)]), 0);\n\tv588 = v574 == 0;\n\tv589 = ~v588;\n\tif (v589) goto L_012A;\n\tv600 = ~this.Warnings;\n\tif (v600) goto L_009D;\n\tgoto L_0099;\n\tv614 = \"il2cpp_codegen_runtime_class_init\"(v606, v572, v573, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\nL_0099:\n\tUnityEngine.Debug::LogWarning(\"This pool contained a null despawned clone, did you accidentally destroy it?\", this);\nL_009D:\n\tv215 = v262 < 1;\n\tv262 = v262 - 1;\n\tif (v215) goto L_00C8;\n\tv482 = this.despawnedClones;\n\tv616 = this.despawnedClones == 0;\n\tv248 = ~v616;\n\tif (v248) goto L_0076;\n\tgoto L_015A;\nL_00AB:\n\tv108 = ~this.Warnings;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_00BA;\n\tv364 = \"il2cpp_codegen_runtime_class_init\"(v278, v92, v93, worldPositionStays, methodInfo, v73, v74, v75, localPosition, v0, v2, localRotation, v3, v5, v6, v76);\nL_00BA:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to spawn from a pool with a null prefab\", this);\n\tgoto L_0159;\nL_00C8:\n\tv363 = this.Capacity < 1;\n\tif (v363) goto L_00EB;\n\tv486 = Lean.Pool.LeanGameObjectPool::get_Spawned(this);\n\tv320 = Lean.Pool.LeanGameObjectPool::get_Despawned(this);\n\tv283 = v320 + v486;\n\tv285 = v283 >= this.Capacity;\n\tif (v285) goto L_0110;\nL_00EB:\n\tv492 = Lean.Pool.LeanGameObjectPool::CreateClone(this, localPosition, localRotation, localScale, parent, worldPositionStays);\n\t*([clone @ X1 (UnityEngine.GameObject&)]) = v492;\n\tv552 = ~this.Recycle;\n\tif (v552) goto L_0133;\n\tv243 = this.spawnedClonesList;\n\tv259 = v243._items;\n\tv137 = v243._version + 1;\n\tv243._version = v137;\n\tv576 = v243._size;\n\tv578 = v243._size < v259.Length;\n\tv579 = ~v578;\n\tif (v579) goto L_0138;\n\tv591 = v243._size + 1;\n\tv243._size = v591;\n\tv259[v576 @ X10_v6 (System.Int32)] = v492;\n\tgoto L_013F;\nL_0110:\n\tv322 = ~this.Recycle;\n\tif (v322) goto L_FFFFFFFF;\n\tv433 = Lean.Pool.LeanGameObjectPool::TryDespawnOldest(this, clone, 0);\n\tv436 = v433 == 0;\n\tif (v436) goto L_0159;\nL_012A:\n\tLean.Pool.LeanGameObjectPool::SpawnClone(this, *([clone @ X1 (UnityEngine.GameObject&)]), localPosition, localRotation, localScale, parent, worldPositionStays);\n\tgoto L_0159;\nL_0133:\n\tv568 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Add(this.spawnedClonesHashSet, v492);\n\tgoto L_013F;\nL_0138:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::AddWithResize(v243, v492);\nL_013F:\n\tUnityEngine.GameObject::SetActive(*([clone @ X1 (UnityEngine.GameObject&)]), 1);\n\tLean.Pool.LeanGameObjectPool::InvokeOnSpawn(this, *([clone @ X1 (UnityEngine.GameObject&)]));\nL_0159:\n\treturn v442;\nL_015A:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 252 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool TrySpawn(ref GameObject clone, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			//IL_03d5: Expected I4, but got O
			ref GameObject reference;
			if (Prefab != null)
			{
				List<GameObject> list = despawnedClones;
				bool flag = list.Count < 1;
				int num = list.Count - 1;
				if (flag)
				{
					goto IL_0196;
				}
				while (true)
				{
					GameObject gameObject = list[num];
					reference = ref *(GameObject*)gameObject;
					despawnedClones.RemoveAt(num);
					if (clone != null)
					{
						break;
					}
					if (Warnings)
					{
						Debug.LogWarning("This pool contained a null despawned clone, did you accidentally destroy it?", this);
					}
					bool flag2 = num < 1;
					num--;
					if (!flag2)
					{
						list = despawnedClones;
						if (despawnedClones == null)
						{
							NullReferenceException ex = new NullReferenceException();
							return (byte)(int)ex != 0;
						}
						continue;
					}
					goto IL_0196;
				}
				goto IL_0343;
			}
			if (Warnings)
			{
				Debug.LogWarning("You're attempting to spawn from a pool with a null prefab", this);
			}
			goto IL_0188;
			IL_0188:
			bool result = false;
			goto IL_03c2;
			IL_0343:
			SpawnClone(clone, localPosition, localRotation, localScale, parent, worldPositionStays);
			result = true;
			goto IL_03c2;
			IL_0196:
			if (Capacity >= 1)
			{
				int spawned = Spawned;
				int despawned = Despawned;
				int num2 = despawned + spawned;
				if (num2 >= Capacity)
				{
					if (!Recycle)
					{
						goto IL_0188;
					}
					bool flag3 = TryDespawnOldest(ref clone, registerDespawned: false);
					bool flag4 = !flag3;
					result = false;
					if (!flag4)
					{
						goto IL_0343;
					}
					goto IL_03c2;
				}
			}
			GameObject gameObject2 = CreateClone(localPosition, localRotation, localScale, parent, worldPositionStays);
			reference = ref *(GameObject*)gameObject2;
			if (Recycle)
			{
				List<GameObject> list2 = spawnedClonesList;
				GameObject[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = gameObject2;
				}
				else
				{
					list2.Add(gameObject2);
				}
			}
			else
			{
				bool flag5 = spawnedClonesHashSet.Add(gameObject2);
			}
			clone.SetActive(value: true);
			InvokeOnSpawn(clone);
			result = true;
			goto IL_03c2;
			IL_03c2:
			return result;
		}

		[ContextMenu("Despawn Oldest")]
		[Token(Token = "0x600001E")]
		[Address(RVA = "0x13603C8", Offset = "0x13603C8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = 0;\n\tv5 = Lean.Pool.LeanGameObjectPool::TryDespawnOldest(this, &v3 @ stack_-8_v1 (UnityEngine.GameObject), 1);\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DespawnOldest()
		{
			GameObject clone = null;
			bool flag = TryDespawnOldest(ref clone, registerDespawned: true);
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x1360250", Offset = "0x1360250", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv34 = UnityEngine.Debug;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv126 = Il2CppMethodInfo;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv175 = UnityEngine.Object;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv224 = \"This pool contained a null spawned clone, did you accidentally destroy it?\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, clone, registerDespawned, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A3697D]) = v52;\nL_002A:\n\tLean.Pool.LeanGameObjectPool::MergeSpawnedClonesToList(this);\n\tv140 = this.spawnedClonesList;\nL_0044:\n\tv73 = v140._size <= 0;\n\tif (v73) goto L_0078;\n\tv177 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v140, 0);\n\t*([clone @ X1 (UnityEngine.GameObject&)]) = v177;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::RemoveAt(this.spawnedClonesList, 0);\n\tgoto L_005A;\n\tv230 = \"il2cpp_codegen_runtime_class_init\"(v227, v226, v225, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_005A:\n\tv165 = UnityEngine.Object::op_Inequality(*([clone @ X1 (UnityEngine.GameObject&)]), 0);\n\tv234 = v165 == 0;\n\tv167 = ~v234;\n\tif (v167) goto L_0074;\n\tv236 = ~this.Warnings;\n\tif (v236) goto L_006C;\n\tgoto L_006B;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v237, v156, v158, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_006B:\n\tUnityEngine.Debug::LogWarning(\"This pool contained a null spawned clone, did you accidentally destroy it?\", this);\nL_006C:\n\tv140 = this.spawnedClonesList;\n\tv246 = this.spawnedClonesList == 0;\n\tv116 = ~v246;\n\tif (v116) goto L_0044;\n\tthrow System.NullReferenceException;\nL_0074:\n\tLean.Pool.LeanGameObjectPool::DespawnNow(this, *([clone @ X1 (UnityEngine.GameObject&)]), registerDespawned);\nL_0078:\n\tv202 = v140._size < 0;\n\tv203 = v140._size == 0;\n\tv205 = v140._size ^ v140._size;\n\tv206 = v140._size & v205;\n\tv207 = v206 < 0;\n\tv218 = v202 == v207;\n\tv219 = ~v203;\n\tv220 = v218 & v219;\n\treturn v220;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool TryDespawnOldest(ref GameObject clone, bool registerDespawned)
		{
			MergeSpawnedClonesToList();
			List<GameObject> list = spawnedClonesList;
			while (list.Count > 0)
			{
				GameObject gameObject = list[0];
				ref GameObject reference = ref *(GameObject*)gameObject;
				spawnedClonesList.RemoveAt(0);
				if (!(clone != null))
				{
					if (Warnings)
					{
						Debug.LogWarning("This pool contained a null spawned clone, did you accidentally destroy it?", this);
					}
					list = spawnedClonesList;
					if (spawnedClonesList == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				DespawnNow(clone, registerDespawned);
				break;
			}
			bool flag = list.Count < 0;
			bool flag2 = list.Count == 0;
			int num = list.Count ^ list.Count;
			int num2 = list.Count & num;
			bool flag3 = num2 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[ContextMenu("Despawn All")]
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x1360584", Offset = "0x1360584", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv49 = Lean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv137 = Il2CppMethodInfo;\n\tv138 = \"il2cpp_codegen_initialize_runtime_metadata\"(v137, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv223 = Il2CppMethodInfo;\n\tv224 = \"il2cpp_codegen_initialize_runtime_metadata\"(v223, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv244 = Il2CppMethodInfo;\n\tv245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v244, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv256 = Il2CppMethodInfo;\n\tv257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv264 = UnityEngine.Object;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A3697E]) = v46;\nL_002F:\n\tLean.Pool.LeanGameObjectPool::MergeSpawnedClonesToList(this);\n\tv141 = this.spawnedClonesList;\n\tv134 = v141._size - 1;\nL_003F:\n\tv144 = v134 & 0x80000000;\n\tv145 = v144 == 0;\n\tv146 = ~v145;\n\tif (v146) goto L_0061;\n\tv197 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v141, v134);\n\tgoto L_0051;\n\tv246 = v129;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v246, v196, v195, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0051:\n\tv252 = UnityEngine.Object::op_Inequality(v197, 0);\n\tv259 = v252 == 0;\n\tif (v259) goto L_0059;\n\tLean.Pool.LeanGameObjectPool::DespawnNow(this, v197, 1);\nL_0059:\n\tv141 = this.spawnedClonesList;\n\tv134 = v134 - 1;\n\tv269 = this.spawnedClonesList == 0;\n\tv125 = ~v269;\n\tif (v125) goto L_003F;\n\tgoto L_0090;\nL_0061:\n\tv130 = v141._version + 1;\n\tv141._size = 0;\n\tv141._version = v130;\n\tv71 = v141._size < 1;\n\tif (v71) goto L_0074;\n\tSystem.Array::Clear(v141._items, 0, v141._size);\nL_0074:\n\tv171 = this.delays;\n\tv177 = v171._size - 1;\nL_0079:\n\tv261 = v177 & 0x80000000;\n\tv262 = v261 == 0;\n\tv173 = ~v262;\n\tif (v173) goto L_0093;\n\tv271 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::get_Item(v171, v177);\n\tgoto L_008A;\n\tv274 = v128;\n\tv275 = \"il2cpp_codegen_runtime_class_init\"(v274, v270, v111, v69, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_008A:\n\tLean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>::Despawn(v271);\n\tv171 = this.delays;\n\tv177 = v177 - 1;\n\tv278 = this.delays == 0;\n\tv124 = ~v278;\n\tif (v124) goto L_0079;\nL_0090:\n\tv170 = new System.NullReferenceException();\nL_0093:\n\tv180 = *([v170 @ X0_v4 (System.NullReferenceException)+1C]) + 1;\n\tv170._message = 0;\n\t*([v170 @ X0_v4 (System.NullReferenceException)+1C]) = v180;\n\tv191 = v170._message < 1;\n\tif (v191) goto L_00BB;\n\tSystem.Array::Clear(v170._className, 0, v170._message);\n\treturn;\nL_00BB:\n\treturn;\n// 115 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DespawnAll()
		{
			//IL_024c: Expected I4, but got I8
			//IL_0286: Expected I4, but got I8
			//IL_01d6: Expected O, but got I
			//IL_0223: Expected I4, but got O
			MergeSpawnedClonesToList();
			List<GameObject> list = spawnedClonesList;
			int num = list.Count - 1;
			NullReferenceException ex;
			while (true)
			{
				if ((int)(num & 0x80000000L) == 0)
				{
					UnityEngine.Object obj = list[num];
					if (obj != null)
					{
						DespawnNow((GameObject)obj);
					}
					list = spawnedClonesList;
					num--;
					if (spawnedClonesList != null)
					{
						continue;
					}
					goto IL_01b2;
				}
				int version = list._version + 1;
				list._size = 0;
				list._version = version;
				if (list.Count >= 1)
				{
					Array.Clear(list._items, 0, list.Count);
				}
				List<Delay> list2 = delays;
				int num2 = list2.Count - 1;
				while (true)
				{
					int num3 = (int)(num2 & 0x80000000L);
					bool flag = num3 == 0;
					bool flag2 = !flag;
					ex = (NullReferenceException)(object)list2;
					if (flag2)
					{
						break;
					}
					Delay instance = list2[num2];
					LeanClassPool<Delay>.Despawn(instance);
					list2 = delays;
					num2--;
					if (delays != null)
					{
						continue;
					}
					goto IL_01b2;
				}
				break;
				IL_01b2:
				ex = new NullReferenceException();
				break;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X0_v4 (System.NullReferenceException)+1C]");
			object obj2 = (nint)0 + (nint)1;
			((Exception)ex)._message = null;
			if ((nint)((Exception)ex)._message >= 1)
			{
				Array.Clear((Array)(object)((Exception)ex)._className, 0, (int)((Exception)ex)._message);
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x1360780", Offset = "0x1360780", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv32 = UnityEngine.Debug;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv70 = Il2CppMethodInfo;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv87 = UnityEngine.Object;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv196 = \"You're attempting to despawn a null gameObject\";\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A3697F]) = v50;\nL_002D:\n\tgoto L_0032;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v51, clone, methodInfo, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\nL_0032:\n\tv63 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv68 = v63 == 0;\n\tif (v68) goto L_0053;\n\tv83 = t <= 0;\n\tif (v83) goto L_0070;\n\tLean.Pool.LeanGameObjectPool::DespawnWithDelay(this, clone, t);\n\treturn;\nL_0053:\n\tv85 = ~this.Warnings;\n\tif (v85) goto L_00B8;\n\tgoto L_006C;\n\tv197 = \"il2cpp_codegen_runtime_class_init\"(v105, v61, v62, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\nL_006C:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to despawn a null gameObject\", this);\n\treturn;\nL_0070:\n\tLean.Pool.LeanGameObjectPool::TryDespawn(this, clone);\n\tv266 = this.delays;\n\tv152 = v266._size < 1;\n\tv261 = v266._size - 1;\n\tif (v152) goto L_00B8;\nL_0086:\n\tv255 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::get_Item(v266, v261);\n\tgoto L_0094;\n\tv270 = v181;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v270, v251, v249, v35, v36, v37, v38, v39, t, v40, v41, v42, v43, v44, v45, v46);\nL_0094:\n\tv274 = UnityEngine.Object::op_Equality(v255.Clone, clone);\n\tv276 = v274 == 0;\n\tif (v276) goto L_00A1;\n\tSystem.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::RemoveAt(this.delays, v261);\nL_00A1:\n\tv153 = v261 < 1;\n\tv261 = v261 - 1;\n\tif (v153) goto L_00B8;\n\tv266 = this.delays;\n\tv280 = this.delays == 0;\n\tv257 = ~v280;\n\tif (v257) goto L_0086;\n\tthrow System.NullReferenceException;\nL_00B8:\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Despawn(GameObject clone, float t = 0f)
		{
			if (clone != null)
			{
				if (t > 0f)
				{
					Despawn(clone, t);
					return;
				}
				TryDespawn(clone);
				List<Delay> list = delays;
				bool flag = list.Count < 1;
				int num = list.Count - 1;
				if (flag)
				{
					return;
				}
				while (true)
				{
					Delay delay = list[num];
					if (delay.Clone == clone)
					{
						delays.RemoveAt(num);
					}
					bool flag2 = num < 1;
					num--;
					if (!flag2)
					{
						list = delays;
						if (delays == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					break;
				}
			}
			else if (Warnings)
			{
				Debug.LogWarning("You're attempting to despawn a null gameObject", this);
			}
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x1360C4C", Offset = "0x1360C4C", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv28 = UnityEngine.Debug;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv119 = Il2CppMethodInfo;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv282 = UnityEngine.Object;\n\tv283 = \"il2cpp_codegen_initialize_runtime_metadata\"(v282, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv300 = \"You're attempting to detach a GameObject that wasn't spawned from this pool.\";\n\tv301 = \"il2cpp_codegen_initialize_runtime_metadata\"(v300, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv305 = \"You're attempting to detach a null GameObject\";\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v305, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A36980]) = v47;\nL_0034:\n\tgoto L_0039;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v48, clone, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0039:\n\tv60 = UnityEngine.Object::op_Inequality(clone, 0);\n\tv65 = v60 == 0;\n\tif (v65) goto L_009C;\n\tv125 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Remove(this.spawnedClonesHashSet, clone);\n\tv230 = v125 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_005E;\n\tv285 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this.spawnedClonesList, clone);\n\tv307 = v285 == 0;\n\tv288 = ~v307;\n\tif (v288) goto L_005E;\n\tv209 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this.despawnedClones, clone);\n\tv287 = v209 == 0;\n\tif (v287) goto L_00B7;\nL_005E:\n\tv312 = this.delays;\n\tv198 = v312._size < 1;\n\tv176 = v312._size - 1;\n\tif (v198) goto L_00CE;\nL_0073:\n\tv163 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::get_Item(v312, v176);\n\tgoto L_0081;\n\tv317 = v171;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v317, v156, v151, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0081:\n\tv321 = UnityEngine.Object::op_Equality(v163.Clone, clone);\n\tv328 = v321 == 0;\n\tif (v328) goto L_008E;\n\tSystem.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::RemoveAt(this.delays, v176);\nL_008E:\n\tv142 = v176 < 1;\n\tv176 = v176 - 1;\n\tif (v142) goto L_00CE;\n\tv312 = this.delays;\n\tv334 = this.delays == 0;\n\tv165 = ~v334;\n\tif (v165) goto L_0073;\n\tthrow System.NullReferenceException;\nL_009C:\n\tv117 = ~this.Warnings;\n\tif (v117) goto L_00CE;\n\tgoto L_FFFFFFFF;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v179, v106, v104, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B4:\n\tUnityEngine.Debug::LogWarning(*([v276 @ X8_v4 (System.String)]), v266);\n\treturn;\nL_00B7:\n\tv212 = ~this.Warnings;\n\tif (v212) goto L_00CE;\n\tgoto L_FFFFFFFF;\n\tv329 = \"il2cpp_codegen_runtime_class_init\"(v324, v206, v204, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_00B4;\nL_00CE:\n\treturn;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Detach(GameObject clone)
		{
			UnityEngine.Object context;
			string message;
			if (clone != null)
			{
				if (spawnedClonesHashSet.Remove(clone) || spawnedClonesList.Remove(clone) || despawnedClones.Remove(clone))
				{
					List<Delay> list = delays;
					bool flag = list.Count < 1;
					int num = list.Count - 1;
					if (flag)
					{
						return;
					}
					while (true)
					{
						Delay delay = list[num];
						if (delay.Clone == clone)
						{
							delays.RemoveAt(num);
						}
						bool flag2 = num < 1;
						num--;
						if (!flag2)
						{
							list = delays;
							if (delays == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						break;
					}
					return;
				}
				if (!Warnings)
				{
					return;
				}
				context = clone;
				message = "You're attempting to detach a GameObject that wasn't spawned from this pool.";
			}
			else
			{
				if (!Warnings)
				{
					return;
				}
				context = this;
				message = "You're attempting to detach a null GameObject";
			}
			Debug.LogWarning(message, context);
		}

		[ContextMenu("Preload One More")]
		[Token(Token = "0x6000023")]
		[Address(RVA = "0x1360E7C", Offset = "0x1360E7C", Length = "0x2F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv32 = UnityEngine.Debug;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv59 = Il2CppMethodInfo;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv68 = UnityEngine.Object;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv73 = \"Attempting to preload a null prefab.\";\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv82 = \"You've preloaded more than the pool capacity, please verify you're preloading the intended amount.\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A36981]) = v52;\nL_002B:\n\tgoto L_0030;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0030:\n\tv66 = UnityEngine.Object::op_Inequality(this.prefab, 0);\n\tv71 = v66 == 0;\n\tif (v71) goto L_0094;\n\tgoto L_0049;\n\tv84 = UnityEngine.Vector3;\n\tv85 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, v64, v65, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv88 = 1;\n\t*([1A35519]) = v88;\nL_0049:\n\tgoto L_005B;\n\tv235 = UnityEngine.Quaternion;\n\tv236 = \"il2cpp_codegen_initialize_runtime_metadata\"(v235, v64, v65, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv239 = 1;\n\t*([1A3551A]) = v239;\nL_005B:\n\tgoto L_0073;\n\tv355 = UnityEngine.Vector3;\n\tv356 = \"il2cpp_codegen_initialize_runtime_metadata\"(v355, v64, v65, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv359 = 1;\n\t*([1A35658]) = v359;\nL_0073:\n\tv367 = Lean.Pool.LeanGameObjectPool::CreateClone(this, v94.zeroVector, v244.identityQuaternion, v362.oneVector, 0, 0);\n\tv348 = this.despawnedClones;\n\tv387 = v348._items;\n\tv389 = v348._version + 1;\n\tv348._version = v389;\n\tv201 = v348._size;\n\tv401 = v348._size < v387.Length;\n\tv189 = ~v401;\n\tif (v189) goto L_00A6;\n\tv402 = v348._size + 1;\n\tv348._size = v402;\n\tv387[v201 @ X11_v6 (System.Int32)] = v367;\n\tgoto L_00AC;\nL_0094:\n\tv80 = ~this.Warnings;\n\tif (v80) goto L_0106;\n\tgoto L_FFFFFFFF;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v102, v64, v65, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tgoto L_00F8;\nL_00A6:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::AddWithResize(v348, v367);\nL_00AC:\n\tUnityEngine.GameObject::SetActive(v367, 0);\n\tv414 = UnityEngine.GameObject::get_transform(v367);\n\tv397 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v414, v397, 0);\n\tv213 = ~this.Warnings;\n\tif (v213) goto L_0106;\n\tv145 = this.Capacity < 1;\n\tif (v145) goto L_0106;\n\tv419 = Lean.Pool.LeanGameObjectPool::get_Spawned(this);\n\tv211 = Lean.Pool.LeanGameObjectPool::get_Despawned(this);\n\tv198 = v211 + v419;\n\tv146 = v198 <= this.Capacity;\n\tif (v146) goto L_0106;\n\tgoto L_FFFFFFFF;\n\tv429 = \"il2cpp_codegen_runtime_class_init\"(v426, v208, v206, v148, v37, v38, v39, v40, v121, v131, v129, v127, v125, v123, v119, v48);\nL_00F8:\n\tUnityEngine.Debug::LogWarning(*([v347 @ X8_v4 (System.String)]), this);\n\treturn;\nL_0106:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 193 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PreloadOneMore()
		{
			string message;
			if (!(Prefab != null))
			{
				if (!Warnings)
				{
					return;
				}
				message = "Attempting to preload a null prefab.";
			}
			else
			{
				GameObject gameObject = CreateClone(Vector3.zero, Quaternion.identity, Vector3.one, null, worldPositionStays: false);
				List<GameObject> list = despawnedClones;
				GameObject[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = gameObject;
				}
				else
				{
					list.Add(gameObject);
				}
				gameObject.SetActive(value: false);
				Transform transform = gameObject.transform;
				Transform parent = base.transform;
				transform.SetParent(parent, worldPositionStays: false);
				if (!Warnings || Capacity < 1)
				{
					return;
				}
				int spawned = Spawned;
				int despawned = Despawned;
				int num = despawned + spawned;
				if (num <= Capacity)
				{
					return;
				}
				message = "You've preloaded more than the pool capacity, please verify you're preloading the intended amount.";
			}
			Debug.LogWarning(message, this);
		}

		[ContextMenu("Preload All")]
		[Token(Token = "0x6000024")]
		[Address(RVA = "0x1361174", Offset = "0x1361174", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = UnityEngine.Object;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv94 = \"Attempting to preload a null prefab\";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36982]) = v34;\nL_0021:\n\tv46 = this.Preload < 1;\n\tif (v46) goto L_0064;\n\tgoto L_002F;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_002F:\n\tv81 = UnityEngine.Object::op_Inequality(this.prefab, 0);\n\tv83 = v81 == 0;\n\tif (v83) goto L_004B;\n\tv125 = Lean.Pool.LeanGameObjectPool::get_Spawned(this);\n\tv128 = Lean.Pool.LeanGameObjectPool::get_Despawned(this);\n\tv86 = this.Preload;\n\tv89 = v128 + v125;\nL_0043:\n\tv58 = v89 >= v86;\n\tif (v58) goto L_0064;\n\tLean.Pool.LeanGameObjectPool::PreloadOneMore(this);\n\tv86 = this.Preload;\n\tv89 = v89 + 1;\n\tgoto L_0043;\nL_004B:\n\tv84 = ~this.Warnings;\n\tif (v84) goto L_0064;\n\tgoto L_005E;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v131, v78, v76, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_005E:\n\tUnityEngine.Debug::LogWarning(\"Attempting to preload a null prefab\", this);\n\treturn;\nL_0064:\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PreloadAll()
		{
			if (Preload < 1)
			{
				return;
			}
			if (Prefab != null)
			{
				int spawned = Spawned;
				int despawned = Despawned;
				int preload = Preload;
				for (int i = despawned + spawned; i < preload; i++)
				{
					PreloadOneMore();
					preload = Preload;
				}
			}
			else if (Warnings)
			{
				Debug.LogWarning("Attempting to preload a null prefab", this);
			}
		}

		[ContextMenu("Clean")]
		[Token(Token = "0x6000025")]
		[Address(RVA = "0x1361278", Offset = "0x1361278", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv111 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A36983]) = v40;\nL_001C:\n\tv79 = this.despawnedClones;\n\tv82 = v79._size - 1;\nL_0025:\n\tv83 = v82 & 0x80000000;\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_003F;\n\tv113 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v79, v82);\n\tgoto L_0036;\n\tv140 = v68;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v140, v112, v60, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0036:\n\tUnityEngine.Object::DestroyImmediate(v113);\n\tv79 = this.despawnedClones;\n\tv82 = v82 - 1;\n\tv144 = this.despawnedClones == 0;\n\tv66 = ~v144;\n\tif (v66) goto L_0025;\n\tv92 = new System.NullReferenceException();\nL_003F:\n\tv98 = *([v92 @ X0_v3 (System.NullReferenceException)+1C]) + 1;\n\tv92._message = 0;\n\t*([v92 @ X0_v3 (System.NullReferenceException)+1C]) = v98;\n\tv109 = v92._message < 1;\n\tif (v109) goto L_0061;\n\tSystem.Array::Clear(v92._className, 0, v92._message);\n\treturn;\nL_0061:\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clean()
		{
			//IL_0112: Expected I4, but got I8
			//IL_00a2: Expected O, but got I
			//IL_00ef: Expected I4, but got O
			List<GameObject> list = despawnedClones;
			int num = list.Count - 1;
			NullReferenceException ex;
			while (true)
			{
				int num2 = (int)(num & 0x80000000L);
				bool flag = num2 == 0;
				bool flag2 = !flag;
				ex = (NullReferenceException)(object)list;
				if (flag2)
				{
					break;
				}
				UnityEngine.Object obj = list[num];
				UnityEngine.Object.DestroyImmediate(obj);
				list = despawnedClones;
				num--;
				if (despawnedClones == null)
				{
					ex = new NullReferenceException();
					break;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v92 @ X0_v3 (System.NullReferenceException)+1C]");
			object obj2 = (nint)0 + (nint)1;
			((Exception)ex)._message = null;
			if ((nint)((Exception)ex)._message >= 1)
			{
				Array.Clear((Array)(object)((Exception)ex)._className, 0, (int)((Exception)ex)._message);
			}
		}

		[Token(Token = "0x6000026")]
		[Address(RVA = "0x1361370", Offset = "0x1361370", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = UnityEngine.Application;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv37 = UnityEngine.Object;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v37, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36984]) = v34;\nL_0014:\n\tLean.Pool.LeanGameObjectPool::PreloadAll(this);\n\tv39 = ~this.Persist;\n\tif (v39) goto L_0039;\n\tgoto L_0021;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\tv47 = UnityEngine.Application::get_isPlaying();\n\tv49 = v47 == 0;\n\tif (v49) goto L_0039;\n\tgoto L_0033;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0033:\n\tUnityEngine.Object::DontDestroyOnLoad(this);\n\treturn;\nL_0039:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Awake()
		{
			PreloadAll();
			if (Persist && Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(this);
			}
		}

		[Token(Token = "0x6000027")]
		[Address(RVA = "0x1361414", Offset = "0x1361414", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Lean.Pool.LeanGameObjectPool;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36985]) = v38;\nL_001A:\n\tgoto L_0025;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv47 = Lean.Pool.LeanGameObjectPool;\nL_0025:\n\tv55 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>::AddLast(v48.Instances, this);\n\tthis.node = v55;\n\tLean.Pool.LeanGameObjectPool::RegisterPrefab(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnEnable()
		{
			LinkedListNode<LeanGameObjectPool> linkedListNode = Instances.AddLast(this);
			node = linkedListNode;
			RegisterPrefab();
		}

		[Token(Token = "0x6000028")]
		[Address(RVA = "0x13614A0", Offset = "0x13614A0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Lean.Pool.LeanGameObjectPool;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv41 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36986]) = v38;\nL_0017:\n\tLean.Pool.LeanGameObjectPool::UnregisterPrefab(this);\n\tgoto L_0027;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv48 = Lean.Pool.LeanGameObjectPool;\nL_0027:\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>::Remove(v49.Instances, this.node);\n\tthis.node = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnDisable()
		{
			UnregisterPrefab();
			Instances.Remove(node);
			node = null;
		}

		[Token(Token = "0x6000029")]
		[Address(RVA = "0x1361530", Offset = "0x1361530", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv34 = UnityEngine.Debug;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv168 = Lean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv220 = Il2CppMethodInfo;\n\tv221 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv227 = Il2CppMethodInfo;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv230 = Il2CppMethodInfo;\n\tv231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv235 = UnityEngine.Object;\n\tv236 = \"il2cpp_codegen_initialize_runtime_metadata\"(v235, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv240 = \"Attempting to update the delayed destruction of a prefab clone that no longer exists, did you accidentally delete it?\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A36987]) = v54;\nL_002F:\n\tv224 = this.delays;\n\tv64 = v224._size < 1;\n\tv165 = v224._size - 1;\n\tif (v64) goto L_00B1;\nL_004E:\n\tv154 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::get_Item(v224, v165);\n\tv233 = UnityEngine.Time::get_deltaTime();\n\tv91 = v154.Life - v233;\n\tv154.Life = v91;\n\tv85 = v91 > 0;\n\tif (v85) goto L_0096;\n\tSystem.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::RemoveAt(this.delays, v165);\n\tgoto L_0072;\n\tv265 = \"il2cpp_codegen_runtime_class_init\"(v261, v259, v258, v38, v39, v40, v41, v42, v91, v44, v45, v46, v47, v48, v49, v50);\nL_0072:\n\tLean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>::Despawn(v154);\n\tgoto L_007D;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v269, v267, v258, v38, v39, v40, v41, v42, v91, v44, v45, v46, v47, v48, v49, v50);\nL_007D:\n\tv250 = UnityEngine.Object::op_Inequality(v154.Clone, 0);\n\tv252 = v250 == 0;\n\tif (v252) goto L_0087;\n\tLean.Pool.LeanGameObjectPool::Despawn(this, v154.Clone, 0f);\n\tgoto L_0096;\nL_0087:\n\tv253 = ~this.Warnings;\n\tif (v253) goto L_0096;\n\tgoto L_0092;\n\tv278 = \"il2cpp_codegen_runtime_class_init\"(v276, v244, v246, v38, v39, v40, v41, v42, v91, v44, v45, v46, v47, v48, v49, v50);\nL_0092:\n\tUnityEngine.Debug::LogWarning(\"Attempting to update the delayed destruction of a prefab clone that no longer exists, did you accidentally delete it?\", this);\nL_0096:\n\tv138 = v165 < 1;\n\tv165 = v165 - 1;\n\tif (v138) goto L_00B1;\n\tv224 = this.delays;\n\tv260 = this.delays == 0;\n\tv157 = ~v260;\n\tif (v157) goto L_004E;\n\tthrow System.NullReferenceException;\nL_00B1:\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Update()
		{
			List<Delay> list = delays;
			bool flag = list.Count < 1;
			int num = list.Count - 1;
			if (flag)
			{
				return;
			}
			while (true)
			{
				Delay delay = list[num];
				float deltaTime = Time.deltaTime;
				if (!((delay.Life -= deltaTime) > 0f))
				{
					delays.RemoveAt(num);
					LeanClassPool<Delay>.Despawn(delay);
					if (delay.Clone != null)
					{
						Despawn(delay.Clone);
					}
					else if (Warnings)
					{
						Debug.LogWarning("Attempting to update the delayed destruction of a prefab clone that no longer exists, did you accidentally delete it?", this);
					}
				}
				bool flag2 = num < 1;
				num--;
				if (!flag2)
				{
					list = delays;
					if (delays == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x600002A")]
		[Address(RVA = "0x135EAF0", Offset = "0x135EAF0", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv59 = Lean.Pool.LeanGameObjectPool;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv101 = UnityEngine.Object;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv129 = \").\";\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv142 = \"You have multiple pools managing the same prefab (\";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36988]) = v38;\nL_002A:\n\tgoto L_002F;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\tv52 = UnityEngine.Object::op_Inequality(this.prefab, 0);\n\tv57 = v52 == 0;\n\tif (v57) goto L_007F;\n\tgoto L_0046;\n\tv103 = \"il2cpp_codegen_runtime_class_init\"(v64, v50, v51, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv105 = Lean.Pool.LeanGameObjectPool;\nL_0046:\n\tv136 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v106.prefabMap, this.prefab, &v75 @ stack_-28_v4 (System.Object));\n\tv144 = v136 == 0;\n\tif (v144) goto L_006D;\n\tv150 = UnityEngine.Object::get_name(this.prefab);\n\tv162 = System.String::Concat(\"You have multiple pools managing the same prefab (\", v150, \").\");\n\tgoto L_0067;\n\tv167 = v93;\n\tv168 = \"il2cpp_codegen_runtime_class_init\"(v167, v158, v160, v73, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0067:\n\tUnityEngine.Debug::LogWarning(v162, v75);\n\tgoto L_007F;\nL_006D:\n\tgoto L_0079;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v145, v132, v134, v135, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv153 = Lean.Pool.LeanGameObjectPool;\nL_0079:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Add(v140.prefabMap, this.prefab, this);\nL_007F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RegisterPrefab()
		{
			if (Prefab != null)
			{
				object value;
				if (prefabMap.TryGetValue(Prefab, out *(LeanGameObjectPool*)(&value)))
				{
					string text = Prefab.name;
					string message = "You have multiple pools managing the same prefab (" + text + ").";
					Debug.LogWarning(message, (UnityEngine.Object)value);
				}
				else
				{
					prefabMap.Add(Prefab, this);
				}
			}
		}

		[Token(Token = "0x600002B")]
		[Address(RVA = "0x135E9C8", Offset = "0x135E9C8", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv16 = Il2CppMethodInfo;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv48 = Lean.Pool.LeanGameObjectPool;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv90 = UnityEngine.Object;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A36989]) = v36;\nL_001D:\n\tv40 = System.Object::Equals(this.prefab, 0);\n\tv45 = v40 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_005E;\n\tgoto L_0035;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v53, v38, v39, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv93 = Lean.Pool.LeanGameObjectPool;\nL_0035:\n\tv73 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::TryGetValue(v94.prefabMap, this.prefab, &v68 @ stack_-28_v4 (System.Object));\n\tv77 = v73 == 0;\n\tif (v77) goto L_005E;\n\tgoto L_0045;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v123, v65, v61, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0045:\n\tv74 = UnityEngine.Object::op_Equality(v68, this);\n\tv78 = v74 == 0;\n\tif (v78) goto L_005E;\n\tgoto L_0058;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v130, v66, v62, v58, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv136 = Lean.Pool.LeanGameObjectPool;\nL_0058:\n\tv72 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::Remove(v119.prefabMap, this.prefab);\nL_005E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void UnregisterPrefab()
		{
			object value;
			if (!object.Equals(Prefab, null) && prefabMap.TryGetValue(Prefab, out *(LeanGameObjectPool*)(&value)) && (UnityEngine.Object)value == this)
			{
				bool flag = prefabMap.Remove(Prefab);
			}
		}

		[Token(Token = "0x600002C")]
		[Address(RVA = "0x136094C", Offset = "0x136094C", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv36 = Lean.Pool.LeanGameObjectPool+Delay;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv117 = Lean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>;\n\tv118 = \"il2cpp_codegen_initialize_runtime_metadata\"(v117, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv133 = Il2CppMethodInfo;\n\tv134 = \"il2cpp_codegen_initialize_runtime_metadata\"(v133, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv238 = Il2CppMethodInfo;\n\tv239 = \"il2cpp_codegen_initialize_runtime_metadata\"(v238, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv245 = Il2CppMethodInfo;\n\tv246 = \"il2cpp_codegen_initialize_runtime_metadata\"(v245, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv251 = UnityEngine.Object;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v251, clone, methodInfo, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A3698A]) = v54;\nL_002D:\n\tv55 = this.delays;\n\tv112 = v55._size - 1;\nL_003C:\n\tv129 = v112 & 0x80000000;\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_006C;\n\tv97 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::get_Item(this.delays, v112);\n\tgoto L_0053;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v252, v84, v89, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\nL_0053:\n\tv124 = UnityEngine.Object::op_Equality(v97.Clone, clone);\n\tv112 = v112 - 1;\n\tv126 = v124 == 0;\n\tif (v126) goto L_003C;\n\tv277 = v97.Life <= t;\n\tif (v277) goto L_00A7;\n\tv97.Life = t;\n\tgoto L_00A7;\nL_006C:\n\tgoto L_006F;\n\tv240 = \"il2cpp_codegen_runtime_class_init\"(v135, v83, v88, v39, v40, v41, v42, v43, t, v44, v45, v46, v47, v48, v49, v50);\nL_006F:\n\tv243 = Lean.Pool.LeanClassPool`1<Lean.Pool.LeanGameObjectPool+Delay>::Spawn();\n\tv248 = v243 == 0;\n\tv249 = ~v248;\n\tif (v249) goto L_007D;\n\tv98 = new Lean.Pool.LeanGameObjectPool+Delay();\n\tSystem.Object::.ctor(v98);\nL_007D:\n\tv114.Clone = clone;\n\tv114.Life = t;\n\tv99 = this.delays;\n\tv110 = v99._items;\n\tv77 = v99._version + 1;\n\tv99._version = v77;\n\tv153 = v99._size;\n\tv264 = v99._size < v110.Length;\n\tv187 = ~v264;\n\tif (v187) goto L_00B9;\n\tv278 = v99._size + 1;\n\tv99._size = v278;\n\tv110[v153 @ X10_v5 (System.Int32)] = v114;\nL_00A7:\n\treturn;\nL_00B9:\n\tSystem.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::AddWithResize(v99, v114);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DespawnWithDelay(GameObject clone, float t)
		{
			//IL_0208: Expected I4, but got I8
			List<Delay> list = delays;
			int num = list.Count - 1;
			while (true)
			{
				if ((int)(num & 0x80000000L) == 0)
				{
					Delay delay = delays[num];
					bool flag = delay.Clone == clone;
					num--;
					if (flag)
					{
						if (delay.Life > t)
						{
							delay.Life = t;
						}
						break;
					}
					continue;
				}
				Delay delay2 = LeanClassPool<Delay>.Spawn();
				bool flag2 = delay2 == null;
				bool flag3 = !flag2;
				Delay delay3 = delay2;
				if (!flag3)
				{
					Delay delay4 = new Delay();
					delay3 = delay4;
				}
				delay3.Clone = clone;
				delay3.Life = t;
				List<Delay> list2 = delays;
				Delay[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = delay3;
				}
				else
				{
					list2.Add(delay3);
				}
				break;
			}
		}

		[Token(Token = "0x600002D")]
		[Address(RVA = "0x1360B50", Offset = "0x1360B50", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, clone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, clone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, clone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv63 = \"You're attempting to despawn a GameObject that wasn't spawned from this pool, make sure your Spawn and Despawn calls match.\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, clone, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A3698B]) = v37;\nL_0022:\n\tv47 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Remove(this.spawnedClonesHashSet, clone);\n\tv60 = v47 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_003A;\n\tv69 = System.Collections.Generic.List`1<UnityEngine.GameObject>::Remove(this.spawnedClonesList, clone);\n\tv71 = v69 == 0;\n\tif (v71) goto L_003D;\nL_003A:\n\tLean.Pool.LeanGameObjectPool::DespawnNow(this, clone, 1);\n\treturn;\nL_003D:\n\tv92 = ~this.Warnings;\n\tif (v92) goto L_0058;\n\tgoto L_0051;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v109, v67, v65, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0051:\n\tUnityEngine.Debug::LogWarning(\"You're attempting to despawn a GameObject that wasn't spawned from this pool, make sure your Spawn and Despawn calls match.\", clone);\n\treturn;\nL_0058:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void TryDespawn(GameObject clone)
		{
			if (spawnedClonesHashSet.Remove(clone) || spawnedClonesList.Remove(clone))
			{
				DespawnNow(clone);
			}
			else if (Warnings)
			{
				Debug.LogWarning("You're attempting to despawn a GameObject that wasn't spawned from this pool, make sure your Spawn and Despawn calls match.", clone);
			}
		}

		[Token(Token = "0x600002E")]
		[Address(RVA = "0x1360484", Offset = "0x1360484", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, clone, register, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A3698C]) = v39;\nL_0015:\n\tv41 = register == 0;\n\tif (v41) goto L_003C;\n\tv42 = this.despawnedClones;\n\tv96 = v42._items;\n\tv97 = v42._version + 1;\n\tv42._version = v97;\n\tv79 = v42._size;\n\tv123 = v42._size < v96.Length;\n\tv73 = ~v123;\n\tif (v73) goto L_0039;\n\tv83 = v42._size + 1;\n\tv42._size = v83;\n\tv96[v79 @ X10_v5 (System.Int32)] = clone;\n\tgoto L_003C;\nL_0039:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::AddWithResize(v42, clone);\nL_003C:\n\tLean.Pool.LeanGameObjectPool::InvokeOnDespawn(this, clone);\n\tUnityEngine.GameObject::SetActive(clone, 0);\n\tv161 = UnityEngine.GameObject::get_transform(clone);\n\tv115 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v161, v115, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DespawnNow(GameObject clone, bool register = true)
		{
			if (register)
			{
				List<GameObject> list = despawnedClones;
				GameObject[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = clone;
				}
				else
				{
					list.Add(clone);
				}
			}
			InvokeOnDespawn(clone);
			clone.SetActive(value: false);
			Transform transform = clone.transform;
			Transform parent = base.transform;
			transform.SetParent(parent, worldPositionStays: false);
		}

		[Token(Token = "0x600002F")]
		[Address(RVA = "0x135FDEC", Offset = "0x135FDEC", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv53 = \" \";\n\tv54 = localPosition;\n\tv55 = v6;\n\tv56 = v5;\n\tv57 = v3;\n\tv58 = localRotation;\n\tv59 = v2;\n\tv60 = v0;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, parent, worldPositionStays, methodInfo, v63, v64, v65, v66, localPosition, v0, v2, localRotation, v3, v5, v6, v67);\n\tv71 = v54;\n\tv85 = v55;\n\tv93 = v60;\n\tv91 = v59;\n\tv69 = v58;\n\tv89 = v57;\n\tv87 = v56;\n\tv83 = 1;\n\t*([1A3698D]) = v83;\nL_0039:\n\t// 57 MakeStruct v100 @ AGG1363E84_2_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v70 @ V0_v1 (UnityEngine.Vector3), v70.y (System.Single), v70.z (System.Single)\n\t// 58 MakeStruct v101 @ AGG1363E84_3_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v68 @ V3_v1 (UnityEngine.Quaternion), v68.y (System.Single), v68.z (System.Single), v68.w (System.Single)\n\tv102 = Lean.Pool.LeanGameObjectPool::DoInstantiate(v81, v81.prefab, v100, v101, localScale, parent, worldPositionStays);\n\tv109 = UnityEngine.Object::get_name(v81.prefab);\n\tv134 = ~v81.Stamp;\n\tif (v134) goto L_FFFFFFFF;\n\tv137 = Lean.Pool.LeanGameObjectPool::get_Spawned(v81);\n\tv181 = Lean.Pool.LeanGameObjectPool::get_Despawned(v81);\n\tv130 = v181 + v137;\n\tv186 = System.Int32::ToString(&v130 @ X8_v6 (System.Int32));\n\tv122 = System.String::Concat(v109, \" \", v186);\n\tgoto L_0062;\nL_0062:\n\tUnityEngine.Object::set_name(v190, v149);\n\treturn v102;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject CreateClone(Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			Vector3 localPosition2 = default(Vector3);
			Vector3 vector = default(Vector3);
			localPosition2.x = vector.x;
			localPosition2.y = vector.y;
			localPosition2.z = vector.z;
			Quaternion localRotation2 = default(Quaternion);
			Quaternion quaternion = default(Quaternion);
			localRotation2.x = quaternion.x;
			localRotation2.y = quaternion.y;
			localRotation2.z = quaternion.z;
			localRotation2.w = quaternion.w;
			GameObject gameObject = DoInstantiate(Prefab, localPosition2, localRotation2, localScale, parent, worldPositionStays);
			string text = Prefab.name;
			string text4;
			UnityEngine.Object obj;
			if (Stamp)
			{
				int spawned = Spawned;
				int despawned = Despawned;
				string text2 = (despawned + spawned).ToString();
				string text3 = text + " " + text2;
				text4 = text3;
				obj = gameObject;
			}
			else
			{
				text4 = text;
				obj = gameObject;
			}
			obj.name = text4;
			return gameObject;
		}

		[Token(Token = "0x6000030")]
		[Address(RVA = "0x1361A28", Offset = "0x1361A28", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, prefab, parent, worldPositionStays, methodInfo, v67, v68, v69, v40, v0, v2, localRotation, v3, v5, v6, v36);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, prefab, parent, worldPositionStays, methodInfo, v67, v68, v69, v40, v0, v2, localRotation, v3, v5, v6, v36);\n\tv85 = UnityEngine.Object;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, prefab, parent, worldPositionStays, methodInfo, v67, v68, v69, v40, v0, v2, localRotation, v3, v5, v6, v36);\n\tv74 = 1;\n\t*([1A3698E]) = v74;\nL_0036:\n\tv75 = UnityEngine.Object;\n\tv77 = *([v75 @ X0_v2 (Il2CppClass<UnityEngine.Object>)+E0]) == 0;\n\tif (v77) goto L_0056;\n\tv82 = worldPositionStays == 0;\n\tif (v82) goto L_0067;\nL_0052:\n\treturnVal1 = UnityEngine.Object::Instantiate(prefab, parent, 1);\n\treturn returnVal1;\nL_0056:\n\tv128 = worldPositionStays == 0;\n\tv88 = ~v128;\n\tif (v88) goto L_0052;\nL_0067:\n\tv126 = UnityEngine.Object::Instantiate(prefab, localPosition, localRotation, parent);\n\tv203 = UnityEngine.GameObject::get_transform(v126);\n\tUnityEngine.Transform::set_localPosition(v203, localPosition);\n\tv207 = UnityEngine.GameObject::get_transform(v126);\n\tUnityEngine.Transform::set_localRotation(v207, localRotation);\n\tv208 = UnityEngine.GameObject::get_transform(v126);\n\t// 138 MakeStruct v132 @ AGG1365BB0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), localScale @ stack_0 (UnityEngine.Vector3), v41 @ stack_4, v37 @ stack_8\n\tUnityEngine.Transform::set_localScale(v208, v132);\n\treturn v126;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GameObject DoInstantiate(GameObject prefab, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			//IL_011f: Expected I, but got O
			//IL_00f2: Expected F4, but got O
			//IL_00ff: Expected F4, but got O
			nint num = (nint)typeof(UnityEngine.Object);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v2 (Il2CppClass<UnityEngine.Object>)+E0]");
			if ((nint)0 != 0)
			{
				if (worldPositionStays)
				{
					goto IL_0022;
				}
			}
			else if (worldPositionStays)
			{
				goto IL_0022;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(prefab, localPosition, localRotation, parent);
			Transform transform = gameObject.transform;
			transform.localPosition = localPosition;
			Transform transform2 = gameObject.transform;
			transform2.localRotation = localRotation;
			Transform transform3 = gameObject.transform;
			Vector3 localScale2 = default(Vector3);
			Vector3 vector = default(Vector3);
			localScale2.x = vector.x;
			object obj = default(object);
			localScale2.y = (float)obj;
			object obj2 = default(object);
			localScale2.z = (float)obj2;
			transform3.localScale = localScale2;
			return gameObject;
			IL_0022:
			return UnityEngine.Object.Instantiate(prefab, parent, worldPositionStays: true);
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x135FBA0", Offset = "0x135FBA0", Length = "0x24C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, clone, parent, worldPositionStays, methodInfo, v68, v69, v70, v41, v0, v2, localRotation, v3, v5, v6, v71);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, clone, parent, worldPositionStays, methodInfo, v68, v69, v70, v41, v0, v2, localRotation, v3, v5, v6, v71);\n\tv86 = UnityEngine.Object;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, clone, parent, worldPositionStays, methodInfo, v68, v69, v70, v41, v0, v2, localRotation, v3, v5, v6, v71);\n\tv167 = UnityEngine.SceneManagement.SceneManager;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v167, clone, parent, worldPositionStays, methodInfo, v68, v69, v70, v41, v0, v2, localRotation, v3, v5, v6, v71);\n\tv75 = 1;\n\t*([1A3698F]) = v75;\nL_0039:\n\tv77 = ~this.Recycle;\n\tif (v77) goto L_0063;\n\tv81 = this.spawnedClonesList;\n\tv91 = v81._items;\n\tv93 = v81._version + 1;\n\tv81._version = v93;\n\tv145 = v81._size;\n\tv168 = v81._size < v91.Length;\n\tv137 = ~v168;\n\tif (v137) goto L_006C;\n\tv149 = v81._size + 1;\n\tv81._size = v149;\n\tv91[v145 @ X10_v5 (System.Int32)] = clone;\n\tv170 = clone == 0;\n\tv155 = ~v170;\n\tif (v155) goto L_0071;\n\tgoto L_00C9;\nL_0063:\n\tv152 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Add(this.spawnedClonesHashSet, clone);\n\tv169 = clone == 0;\n\tv156 = ~v169;\n\tif (v156) goto L_0071;\n\tgoto L_00C9;\nL_006C:\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::AddWithResize(v81, clone);\nL_0071:\n\tv153 = UnityEngine.GameObject::get_transform(clone);\n\tUnityEngine.Transform::SetParent(v153, 0, 0);\n\tUnityEngine.Transform::set_localPosition(v153, localPosition);\n\tUnityEngine.Transform::set_localRotation(v153, localRotation);\n\t// 143 MakeStruct v175 @ AGG1363D40_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), localScale @ stack_0 (UnityEngine.Vector3), v40 @ stack_4, v42 @ stack_8\n\tUnityEngine.Transform::set_localScale(v153, v175);\n\tUnityEngine.Transform::SetParent(v153, parent, worldPositionStays);\n\tgoto L_009F;\n\tv272 = \"il2cpp_codegen_runtime_class_init\"(v268, v267, v265, v186, methodInfo, v68, v69, v70, v232, v242, v240, v181, v3, v5, v6, v71);\nL_009F:\n\tv277 = UnityEngine.Object::op_Equality(parent, 0);\n\tv279 = v277 == 0;\n\tif (v279) goto L_00B4;\n\tgoto L_00AC;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v282, v275, v276, v186, methodInfo, v68, v69, v70, v232, v242, v240, v181, v3, v5, v6, v71);\nL_00AC:\n\tv297 = UnityEngine.SceneManagement.SceneManager::GetActiveScene();\n\tv289 = v297 & 0xFFFFFFFF;\n\tUnityEngine.SceneManagement.SceneManager::MoveGameObjectToScene(clone, v289);\nL_00B4:\n\tUnityEngine.GameObject::SetActive(clone, 1);\n\tLean.Pool.LeanGameObjectPool::InvokeOnSpawn(this, clone);\n\treturn;\nL_00C9:\n\tthrow System.NullReferenceException;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SpawnClone(GameObject clone, Vector3 localPosition, Quaternion localRotation, Vector3 localScale, Transform parent, bool worldPositionStays)
		{
			//IL_0190: Expected F4, but got O
			//IL_019d: Expected F4, but got O
			//IL_020b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0210: Expected O, but got Unknown
			if (Recycle)
			{
				List<GameObject> list = spawnedClonesList;
				GameObject[] items = list._items;
				int version = list._version + 1;
				list._version = version;
				int count = list.Count;
				if (list.Count < items.Length)
				{
					int size = list.Count + 1;
					list._size = size;
					items[count] = clone;
					if ((object)clone == null)
					{
						goto IL_0240;
					}
				}
				else
				{
					list.Add(clone);
				}
			}
			else
			{
				bool flag = spawnedClonesHashSet.Add(clone);
				if ((object)clone == null)
				{
					goto IL_0240;
				}
			}
			Transform transform = clone.transform;
			transform.SetParent(null, worldPositionStays: false);
			transform.localPosition = localPosition;
			transform.localRotation = localRotation;
			Vector3 localScale2 = default(Vector3);
			Vector3 vector = default(Vector3);
			localScale2.x = vector.x;
			object obj = default(object);
			localScale2.y = (float)obj;
			object obj2 = default(object);
			localScale2.z = (float)obj2;
			transform.localScale = localScale2;
			transform.SetParent(parent, worldPositionStays);
			if (parent == null)
			{
				Scene activeScene = SceneManager.GetActiveScene();
				Scene scene = (Scene)(activeScene & 0xFFFFFFFFL);
				SceneManager.MoveGameObjectToScene(clone, scene);
			}
			clone.SetActive(value: true);
			InvokeOnSpawn(clone);
			return;
			IL_0240:
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000032")]
		[Address(RVA = "0x135FF40", Offset = "0x135FF40", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv71 = Lean.Pool.IPoolable;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv88 = Lean.Pool.LeanGameObjectPool;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv91 = Il2CppMethodInfo;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv97 = \"OnSpawn\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36990]) = v41;\nL_0027:\n\tv43 = v38.Notification - 1;\n\tv44 = v43 < 3;\n\tv45 = ~v44;\n\tv46 = v43 - 3;\n\tv48 = v46 == 0;\n\tv53 = ~v48;\n\tv54 = v45 & v53;\n\tif (v54) goto L_0142;\n\tv59 = 0x44C000 + 0x750;\n\tv62 = *([v59 @ X9_v2 (System.Int32)+v43 @ X8_v4 (System.Int32)]) << 2;\n\tv63 = 0x1363FE4 + v62;\n\t// 58 IndirectJump v63 @ X10_v2 (System.Int32), v38 @ X0_v1 (Lean.Pool.LeanGameObjectPool), v38 @ X0_v1 (Lean.Pool.LeanGameObjectPool), clone @ X1 (UnityEngine.GameObject), methodInfo @ X2 (Il2CppMethodInfo), v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tif (TEMP) goto L_0143;\n\tX8 = *([193A730]);\n\tX0 = X19;\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = *([X8]);\n\tX2 = 1;\n\tX3 = 0;\n\tX30 = stack[0];\n\tX23 = stack[8];\n\t// 73 ShiftStack 48\n\tUnityEngine.GameObject::SendMessage(X0, X1, X2, X3);\n\treturn;\n\tif (TEMP) goto L_0143;\n\tX8 = *([193A730]);\n\tX0 = X19;\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = *([X8]);\n\tX2 = 1;\n\tX3 = 0;\n\tX30 = stack[0];\n\tX23 = stack[8];\n\t// 90 ShiftStack 48\n\tUnityEngine.GameObject::BroadcastMessage(X0, X1, X2, X3);\n\treturn;\n\tX21 = *([193A688]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0065;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tTEMP = X19 == 0;\n\tif (TEMP) goto L_0143;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX8 = *([X8+B8]);\n\tX9 = *([193A710]);\n\tX1 = *([X8+10]);\n\tX2 = *([X9]);\n\tUnityEngine.GameObject::GetComponents /* +1 sharing this address */(X0, X1, X2);\n\tX0 = *([X21]);\n\tX8 = *([X0+B8]);\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0143;\n\tX8 = *([X8+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X8 - 1;\n\tif (N) goto L_0142;\n\tX22 = *([193A728]);\n\tX23 = *([193A718]);\nL_0084:\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008A;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_008A:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+10]);\n\tif (TEMP) goto L_0143;\n\tX2 = *([X22]);\n\tX1 = X19;\n\tX0 = System.Collections.Generic.List`1<System.Object>::get_Item(X0, X1, X2);\n\tif (TEMP) goto L_0143;\n\tX8 = *([X0]);\n\tX1 = *([X23]);\n\tX20 = X0;\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_00B3;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_009B:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00B7;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_009B;\nL_00B3:\n\tX0 = X20;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00BB;\nL_00B7:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_00BB:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X20;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X19 < 1;\n\tC = ~C;\n\tTEMP1 = X19 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ 1;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X19 - 1;\n\tif (N) goto L_0142;\n\tX0 = *([X21]);\n\tgoto L_0084;\n\tX21 = *([193A688]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D4;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D4:\n\tTEMP = X19 == 0;\n\tif (TEMP) goto L_0143;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX8 = *([X8+B8]);\n\tX9 = *([193A708]);\n\tX1 = *([X8+10]);\n\tX2 = *([X9]);\n\tUnityEngine.GameObject::GetComponentsInChildren /* +1 sharing this address */(X0, X1, X2);\n\tX0 = *([X21]);\n\tX8 = *([X0+B8]);\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0143;\n\tX8 = *([X8+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X8 - 1;\n\tif (N) goto L_0142;\n\tX22 = *([193A728]);\n\tX23 = *([193A718]);\nL_00F3:\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F9;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_00F9:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+10]);\n\tif (TEMP) goto L_0143;\n\tX2 = *([X22]);\n\tX1 = X19;\n\tX0 = System.Collections.Generic.List`1<System.Object>::get_Item(X0, X1, X2);\n\tif (TEMP) goto L_0143;\n\tX8 = *([X0]);\n\tX1 = *([X23]);\n\tX20 = X0;\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_0122;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_010A:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0126;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_010A;\nL_0122:\n\tX0 = X20;\n\tX2 = 0;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_012A;\nL_0126:\n\tX9 = *([X10]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_012A:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X20;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X19 < 1;\n\tC = ~C;\n\tTEMP1 = X19 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ 1;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X19 - 1;\n\tif (N) goto L_0142;\n\tX0 = *([X21]);\n\tgoto L_00F3;\nL_0142:\n\treturn;\nL_0143:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InvokeOnSpawn(GameObject clone)
		{
			int num = (int)(Notification - 1);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4505600 + 1872;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v2 (System.Int32)+v43 @ X8_v4 (System.Int32)]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 20332516 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000033")]
		[Address(RVA = "0x1361710", Offset = "0x1361710", Length = "0x318")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv71 = Lean.Pool.IPoolable;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv88 = Lean.Pool.LeanGameObjectPool;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv91 = Il2CppMethodInfo;\n\tv92 = \"il2cpp_codegen_initialize_runtime_metadata\"(v91, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv94 = Il2CppMethodInfo;\n\tv95 = \"il2cpp_codegen_initialize_runtime_metadata\"(v94, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv97 = \"OnDespawn\";\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v97, clone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A36991]) = v41;\nL_0027:\n\tv43 = v38.Notification - 1;\n\tv44 = v43 < 3;\n\tv45 = ~v44;\n\tv46 = v43 - 3;\n\tv48 = v46 == 0;\n\tv53 = ~v48;\n\tv54 = v45 & v53;\n\tif (v54) goto L_0144;\n\tv59 = 0x44C000 + 0x754;\n\tv62 = *([v59 @ X9_v2 (System.Int32)+v43 @ X8_v4 (System.Int32)]) << 2;\n\tv63 = 0x13657B4 + v62;\n\t// 58 IndirectJump v63 @ X10_v2 (System.Int32), v38 @ X0_v1 (Lean.Pool.LeanGameObjectPool), v38 @ X0_v1 (Lean.Pool.LeanGameObjectPool), clone @ X1 (UnityEngine.GameObject), methodInfo @ X2 (Il2CppMethodInfo), v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tif (TEMP) goto L_0145;\n\tX8 = *([193A800]);\n\tX0 = X19;\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = *([X8]);\n\tX2 = 1;\n\tX3 = 0;\n\tX30 = stack[0];\n\tX23 = stack[8];\n\t// 73 ShiftStack 48\n\tUnityEngine.GameObject::SendMessage(X0, X1, X2, X3);\n\treturn;\n\tif (TEMP) goto L_0145;\n\tX8 = *([193A800]);\n\tX0 = X19;\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX1 = *([X8]);\n\tX2 = 1;\n\tX3 = 0;\n\tX30 = stack[0];\n\tX23 = stack[8];\n\t// 90 ShiftStack 48\n\tUnityEngine.GameObject::BroadcastMessage(X0, X1, X2, X3);\n\treturn;\n\tX21 = *([193A688]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0065;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0065:\n\tTEMP = X19 == 0;\n\tif (TEMP) goto L_0145;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX8 = *([X8+B8]);\n\tX9 = *([193A710]);\n\tX1 = *([X8+10]);\n\tX2 = *([X9]);\n\tUnityEngine.GameObject::GetComponents /* +1 sharing this address */(X0, X1, X2);\n\tX0 = *([X21]);\n\tX8 = *([X0+B8]);\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0145;\n\tX8 = *([X8+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X8 - 1;\n\tif (N) goto L_0144;\n\tX22 = *([193A728]);\n\tX23 = *([193A718]);\nL_0084:\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008A;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_008A:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+10]);\n\tif (TEMP) goto L_0145;\n\tX2 = *([X22]);\n\tX1 = X19;\n\tX0 = System.Collections.Generic.List`1<System.Object>::get_Item(X0, X1, X2);\n\tif (TEMP) goto L_0145;\n\tX8 = *([X0]);\n\tX1 = *([X23]);\n\tX20 = X0;\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_00B3;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_009B:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00B7;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_009B;\nL_00B3:\n\tX2 = 1;\n\tX0 = X20;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00BC;\nL_00B7:\n\tX9 = *([X10]);\n\tX9 = X9 + 1;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_00BC:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X20;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X19 < 1;\n\tC = ~C;\n\tTEMP1 = X19 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ 1;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X19 - 1;\n\tif (N) goto L_0144;\n\tX0 = *([X21]);\n\tgoto L_0084;\n\tX21 = *([193A688]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D5;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D5:\n\tTEMP = X19 == 0;\n\tif (TEMP) goto L_0145;\n\tX8 = *([X21]);\n\tX0 = X19;\n\tX8 = *([X8+B8]);\n\tX9 = *([193A708]);\n\tX1 = *([X8+10]);\n\tX2 = *([X9]);\n\tUnityEngine.GameObject::GetComponentsInChildren /* +1 sharing this address */(X0, X1, X2);\n\tX0 = *([X21]);\n\tX8 = *([X0+B8]);\n\tX8 = *([X8+10]);\n\tif (TEMP) goto L_0145;\n\tX8 = *([X8+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X8 - 1;\n\tif (N) goto L_0144;\n\tX22 = *([193A728]);\n\tX23 = *([193A718]);\nL_00F4:\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FA;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_00FA:\n\tX8 = *([X0+B8]);\n\tX0 = *([X8+10]);\n\tif (TEMP) goto L_0145;\n\tX2 = *([X22]);\n\tX1 = X19;\n\tX0 = System.Collections.Generic.List`1<System.Object>::get_Item(X0, X1, X2);\n\tif (TEMP) goto L_0145;\n\tX8 = *([X0]);\n\tX1 = *([X23]);\n\tX20 = X0;\n\tX9 = *([X8+12E]);\n\tif (TEMP) goto L_0123;\n\tX10 = *([X8+B0]);\n\tX10 = X10 + 8;\nL_010B:\n\tX11 = *([X10-8]);\n\tC = X11 < X1;\n\tC = ~C;\n\tTEMP1 = X11 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X11 ^ X1;\n\tTEMP3 = X11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0127;\n\tC = X9 < 1;\n\tC = ~C;\n\tTEMP1 = X9 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ 1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX9 = X9 - 1;\n\tX10 = X10 + 0x10;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_010B;\nL_0123:\n\tX2 = 1;\n\tX0 = X20;\n\tX0 = 0xB349B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_012C;\nL_0127:\n\tX9 = *([X10]);\n\tX9 = X9 + 1;\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x138;\nL_012C:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X20;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X19 < 1;\n\tC = ~C;\n\tTEMP1 = X19 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ 1;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX19 = X19 - 1;\n\tif (N) goto L_0144;\n\tX0 = *([X21]);\n\tgoto L_00F4;\nL_0144:\n\treturn;\nL_0145:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InvokeOnDespawn(GameObject clone)
		{
			int num = (int)(Notification - 1);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4505600 + 1876;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X9_v2 (System.Int32)+v43 @ X8_v4 (System.Int32)]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 20338612 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x13603E4", Offset = "0x13603E4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv82 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A36992]) = v34;\nL_0016:\n\tv35 = this.spawnedClonesHashSet;\n\tv51 = *([v35 @ X1_v1 (System.Collections.Generic.IEnumerable`1<System.Object>)+20]) < 1;\n\tif (v51) goto L_003D;\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::AddRange(this.spawnedClonesList, v35);\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Clear(this.spawnedClonesHashSet);\n\treturn;\nL_003D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void MergeSpawnedClonesToList()
		{
			IEnumerable<object> collection = spawnedClonesHashSet;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ X1_v1 (System.Collections.Generic.IEnumerable`1<System.Object>)+20]");
			if ((nint)0 >= (nint)1)
			{
				spawnedClonesList.AddRange((IEnumerable<GameObject>)collection);
				spawnedClonesHashSet.Clear();
			}
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x1361BE0", Offset = "0x1361BE0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLean.Pool.LeanGameObjectPool::MergeSpawnedClonesToList(this);\n\treturn;\n")]
		public void OnBeforeSerialize()
		{
			MergeSpawnedClonesToList();
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x1361BE4", Offset = "0x1361BE4", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv95 = Il2CppMethodInfo;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv152 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v152, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A36993]) = v38;\nL_001C:\n\tv40 = ~this.Recycle;\n\tif (v40) goto L_0025;\nL_0024:\n\treturn;\nL_0025:\n\tv155 = this.spawnedClonesList;\n\tv149 = v155._size - 1;\nL_002E:\n\tv158 = v149 & 0x80000000;\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_0044;\n\tv141 = System.Collections.Generic.List`1<UnityEngine.GameObject>::get_Item(v155, v149);\n\tv167 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>::Add(this.spawnedClonesHashSet, v141);\n\tv155 = this.spawnedClonesList;\n\tv149 = v149 - 1;\n\tv168 = this.spawnedClonesList == 0;\n\tv143 = ~v168;\n\tif (v143) goto L_002E;\n\tv80 = new System.NullReferenceException();\nL_0044:\n\tv84 = *([v80 @ X0_v3 (System.NullReferenceException)+1C]) + 1;\n\tv80._message = 0;\n\t*([v80 @ X0_v3 (System.NullReferenceException)+1C]) = v84;\n\tv46 = v80._message < 1;\n\tif (v46) goto L_0024;\n\tSystem.Array::Clear(v80._className, 0, v80._message);\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnAfterDeserialize()
		{
			//IL_0137: Expected I4, but got I8
			//IL_00bc: Expected O, but got I
			//IL_0109: Expected I4, but got O
			if (Recycle)
			{
				return;
			}
			List<GameObject> list = spawnedClonesList;
			int num = list.Count - 1;
			NullReferenceException ex;
			while (true)
			{
				int num2 = (int)(num & 0x80000000L);
				bool flag = num2 == 0;
				bool flag2 = !flag;
				ex = (NullReferenceException)(object)list;
				if (flag2)
				{
					break;
				}
				GameObject item = list[num];
				bool flag3 = spawnedClonesHashSet.Add(item);
				list = spawnedClonesList;
				num--;
				if (spawnedClonesList == null)
				{
					ex = new NullReferenceException();
					break;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X0_v3 (System.NullReferenceException)+1C]");
			object obj = (nint)0 + (nint)1;
			((Exception)ex)._message = null;
			if ((nint)((Exception)ex)._message >= 1)
			{
				Array.Clear((Array)(object)((Exception)ex)._className, 0, (int)((Exception)ex)._message);
			}
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x1361CD8", Offset = "0x1361CD8", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv64 = System.Collections.Generic.HashSet`1<UnityEngine.GameObject>;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv74 = Il2CppMethodInfo;\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv79 = System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv84 = System.Collections.Generic.List`1<UnityEngine.GameObject>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v84, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A36994]) = v58;\nL_0033:\n\tthis.Notification = 3;\n\tthis.Warnings = 1;\n\tv62 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v62);\n\tthis.spawnedClonesList = v62;\n\tv72 = new System.Collections.Generic.HashSet`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.HashSet`1<UnityEngine.GameObject>::.ctor(v72);\n\tthis.spawnedClonesHashSet = v72;\n\tv82 = new System.Collections.Generic.List`1<UnityEngine.GameObject>();\n\tSystem.Collections.Generic.List`1<UnityEngine.GameObject>::.ctor(v82);\n\tthis.despawnedClones = v82;\n\tv88 = new System.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>();\n\tSystem.Collections.Generic.List`1<Lean.Pool.LeanGameObjectPool+Delay>::.ctor(v88);\n\tthis.delays = v88;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LeanGameObjectPool()
		{
			Notification = NotificationType.IPoolable;
			Warnings = true;
			List<GameObject> list = new List<GameObject>();
			spawnedClonesList = list;
			HashSet<GameObject> hashSet = new HashSet<GameObject>();
			spawnedClonesHashSet = hashSet;
			List<GameObject> list2 = new List<GameObject>();
			despawnedClones = list2;
			List<Delay> list3 = new List<Delay>();
			delays = list3;
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x1361E0C", Offset = "0x1361E0C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv63 = System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv68 = Lean.Pool.LeanGameObjectPool;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv75 = Il2CppMethodInfo;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv80 = System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv92 = System.Collections.Generic.List`1<Lean.Pool.IPoolable>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv59 = 1;\n\t*([1A36995]) = v59;\nL_0036:\n\tv61 = new System.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>();\n\tSystem.Collections.Generic.LinkedList`1<Lean.Pool.LeanGameObjectPool>::.ctor(v61);\n\tv71.Instances = v61;\n\tv73 = new System.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.GameObject, Lean.Pool.LeanGameObjectPool>::.ctor(v73);\n\tv83.prefabMap = v73;\n\tv85 = new System.Collections.Generic.List`1<Lean.Pool.IPoolable>();\n\tSystem.Collections.Generic.List`1<Lean.Pool.IPoolable>::.ctor(v85);\n\tv100.tempPoolables = v85;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LeanGameObjectPool()
		{
			LinkedList<LeanGameObjectPool> instances = new LinkedList<LeanGameObjectPool>();
			Instances = instances;
			Dictionary<GameObject, LeanGameObjectPool> dictionary = new Dictionary<GameObject, LeanGameObjectPool>();
			prefabMap = dictionary;
			List<IPoolable> list = new List<IPoolable>();
			tempPoolables = list;
		}
	}
}
