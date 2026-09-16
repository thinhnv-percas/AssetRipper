using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(SkeletonRenderer))]
	[Token(Token = "0x200005E")]
	public class SkeletonRagdoll2D : MonoBehaviour
	{
		[Token(Token = "0x40001F4")]
		private static Transform parentSpaceHelper;

		[SpineBone(null, null, true, false)]
		[Header("Hierarchy")]
		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x20")]
		public string startingBoneName;

		[SpineBone(null, null, true, false)]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x28")]
		public List<string> stopBoneNames;

		[Header("Parameters")]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x30")]
		public bool applyOnStart;

		[Tooltip("Warning! You will have to re-enable and tune mix values manually if attempting to remove the ragdoll system.")]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x31")]
		public bool disableIK;

		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x32")]
		public bool disableOtherConstraints;

		[Space]
		[Tooltip("Set RootRigidbody IsKinematic to true when Apply is called.")]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x33")]
		public bool pinStartBone;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x34")]
		public float gravityScale;

		[Tooltip("If no BoundingBox Attachment is attached to a bone, this becomes the default Width or Radius of a Bone's ragdoll Rigidbody")]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x38")]
		public float thickness;

		[Tooltip("Default rotational limit value. Min is negative this value, Max is this value.")]
		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x3C")]
		public float rotationLimit;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x40")]
		public float rootMass;

		[Range(0.01f, 1f)]
		[Tooltip("If your ragdoll seems unstable or uneffected by limits, try lowering this value.")]
		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x44")]
		public float massFalloffFactor;

		[Tooltip("The layer assigned to all of the rigidbody parts.")]
		[SkeletonRagdoll.LayerField]
		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x48")]
		public int colliderLayer;

		[Range(0f, 1f)]
		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x4C")]
		public float mix;

		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x50")]
		public bool oldRagdollBehaviour;

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x58")]
		private ISkeletonAnimation targetSkeletonComponent;

		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0x60")]
		private Skeleton skeleton;

		[Token(Token = "0x4000205")]
		[FieldOffset(Offset = "0x68")]
		private Dictionary<Bone, Transform> boneTable;

		[Token(Token = "0x4000206")]
		[FieldOffset(Offset = "0x70")]
		private Transform ragdollRoot;

		[CompilerGenerated]
		[Token(Token = "0x4000207")]
		[FieldOffset(Offset = "0x78")]
		private Rigidbody2D _003CRootRigidbody_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x80")]
		private Bone _003CStartingBone_003Ek__BackingField;

		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x88")]
		private Vector2 rootOffset;

		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x90")]
		private bool isActive;

		[Token(Token = "0x1700002E")]
		public Rigidbody2D RootRigidbody
		{
			[CompilerGenerated]
			[Token(Token = "0x600019A")]
			[Address(RVA = "0x151B6B0", Offset = "0x151B6B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RootRigidbody>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RootRigidbody;
			}
			[CompilerGenerated]
			[Token(Token = "0x600019B")]
			[Address(RVA = "0x151B6B8", Offset = "0x151B6B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<RootRigidbody>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CRootRigidbody_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700002F")]
		public Bone StartingBone
		{
			[CompilerGenerated]
			[Token(Token = "0x600019C")]
			[Address(RVA = "0x151B6C0", Offset = "0x151B6C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StartingBone>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StartingBone;
			}
			[CompilerGenerated]
			[Token(Token = "0x600019D")]
			[Address(RVA = "0x151B6C8", Offset = "0x151B6C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StartingBone>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CStartingBone_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000030")]
		public Vector3 RootOffset
		{
			[Token(Token = "0x600019E")]
			[Address(RVA = "0x151B6D0", Offset = "0x151B6D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.rootOffset;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return rootOffset;
			}
		}

		[Token(Token = "0x17000031")]
		public bool IsActive
		{
			[Token(Token = "0x600019F")]
			[Address(RVA = "0x151B6DC", Offset = "0x151B6DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isActive;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsActive;
			}
		}

		[Token(Token = "0x17000032")]
		public unsafe Rigidbody2D[] RigidbodyArray
		{
			[Token(Token = "0x60001A1")]
			[Address(RVA = "0x151B74C", Offset = "0x151B74C", Length = "0x224")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv121 = Il2CppMethodInfo;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv211 = Il2CppMethodInfo;\n\tv212 = \"il2cpp_codegen_initialize_runtime_metadata\"(v211, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv224 = UnityEngine.Rigidbody2D[];\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv230 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37A93]) = v40;\nL_0028:\n\tv41 = 0;\n\tv47 = ~this.isActive;\n\tif (v47) goto L_0075;\n\tv52 = this.boneTable == 0;\n\tif (v52) goto L_0083;\n\tv62 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Count(this.boneTable);\n\t// 58 NewArr v105 @ X0_v25 (UnityEngine.Rigidbody2D[]), typeof(UnityEngine.Rigidbody2D[]), v62 @ X0_v23 (System.Int32)\n\tv109 = this.boneTable == 0;\n\tif (v109) goto L_0083;\n\tv106 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv110 = v106 == 0;\n\tif (v110) goto L_0083;\n\tv238 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v106);\nL_0054:\n\tv266 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv165 = v266 == 0;\n\tif (v165) goto L_0071;\n\tv260 = UnityEngine.Component::GetComponent(0);\n\tv91 = v91 + 1;\n\tv105[v91 @ X23_v5 (System.Int32)] = v260;\n\tgoto L_0054;\nL_0071:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_007F;\nL_0075:\n\t// 117 NewArr v55 @ X0_v5 (UnityEngine.Rigidbody2D[]), typeof(UnityEngine.Rigidbody2D[]), 0\nL_007F:\n\treturn v167;\n\tv281 = new System.IndexOutOfRangeException();\n\tv285 = new System.NullReferenceException();\n\tv104 = new System.NullReferenceException();\nL_0083:\n\tv118 = new System.NullReferenceException();\n\tgoto L_0091;\n\tgoto L_0091;\n\tgoto L_0091;\nL_0091:\n\tv127 = v99 != 1;\n\tif (v127) goto L_00A1;\n\tv216 = 0x1854E70(v118, v99, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv226 = 0x1854E80(v216, v99, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv166 = *([v216 @ X0_v18]) == 0;\n\tif (v166) goto L_007F;\n\tthrow System.OutOfMemoryException;\nL_00A1:\n\tgoto L_00A7;\n\tX20 = X0;\nL_00A7:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v41 @ stack_-48_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00AE;\n\tv243 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v118);\nL_00AE:\n\tv246 = new System.OutOfMemoryException();\n\treturnVal2 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v246);\n\treturn returnVal2;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0066: Expected O, but got I
				//IL_009f: Expected O, but got I4
				Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
				SkeletonRagdoll2D result;
				if (IsActive)
				{
					bool flag = boneTable == null;
					Rigidbody2D[] array = default(Rigidbody2D[]);
					result = (SkeletonRagdoll2D)(object)array;
					object obj = default(object);
					if (!flag)
					{
						int count = boneTable.Count;
						array = new Rigidbody2D[count];
						bool flag2 = boneTable == null;
						IntPtr intPtr = default(IntPtr);
						obj = (nint)intPtr;
						result = this;
						if (!flag2)
						{
							Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
							bool flag3 = values == null;
							obj = count;
							result = this;
							if (!flag3)
							{
								Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
								int num = 0;
								while (enumerator.MoveNext())
								{
									Rigidbody2D component = ((Component)null).GetComponent<Rigidbody2D>();
									num++;
									array[num] = component;
								}
								enumerator.Dispose();
								result = (SkeletonRagdoll2D)(object)array;
								goto IL_0224;
							}
						}
					}
					NullReferenceException ex = new NullReferenceException();
					if ((nint)obj != 1)
					{
						enumerator.Dispose();
						OutOfMemoryException ex2 = new OutOfMemoryException();
						((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex2)->Dispose();
						Rigidbody2D[] result2 = default(Rigidbody2D[]);
						return result2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator.Dispose();
					object obj2 = default(object);
					if (obj2 != null)
					{
						throw new OutOfMemoryException();
					}
				}
				else
				{
					Rigidbody2D[] array2 = new Rigidbody2D[0];
					result = (SkeletonRagdoll2D)(object)array2;
				}
				goto IL_0224;
				IL_0224:
				return (Rigidbody2D[])(object)result;
			}
		}

		[Token(Token = "0x17000033")]
		public Vector3 EstimatedSkeletonPosition
		{
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0x151469C", Offset = "0x151469C", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = UnityEngine.Rigidbody2D::get_position(this.<RootRigidbody>k__BackingField);\n\treturnVal1 = v9 - this.rootOffset;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				float x = RootRigidbody.position.x - rootOffset.x;
				Vector3 result = default(Vector3);
				result.x = x;
				return result;
			}
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x151B6E4", Offset = "0x151B6E4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.Examples.SkeletonRagdoll2D+<Start>d__33;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A92]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.Examples.SkeletonRagdoll2D+<Start>d__33();\n\tSpine.Unity.Examples.SkeletonRagdoll2D+<Start>d__33::.ctor(v39, 0);\n\tv39.<>4__this = this;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IEnumerator Start()
		{
			if (parentSpaceHelper == null)
			{
				GameObject gameObject = new GameObject("Parent Space Helper");
				Transform transform = gameObject.transform;
				parentSpaceHelper = transform;
			}
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			ISkeletonAnimation skeletonAnimation = component as ISkeletonAnimation;
			targetSkeletonComponent = skeletonAnimation;
			ISkeletonAnimation skeletonAnimation2 = targetSkeletonComponent;
			if (targetSkeletonComponent == null)
			{
				Debug.LogError("Attached Spine component does not implement ISkeletonAnimation. This script is not compatible.");
				skeletonAnimation2 = targetSkeletonComponent;
			}
			Skeleton skeleton = skeletonAnimation2.Skeleton;
			this.skeleton = skeleton;
			if (applyOnStart)
			{
				yield return null;
				Apply();
			}
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x1513634", Offset = "0x1513634", Length = "0xCBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_007D;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv482 = Il2CppMethodInfo;\n\tv483 = \"il2cpp_codegen_initialize_runtime_metadata\"(v482, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv553 = UnityEngine.Debug;\n\tv554 = \"il2cpp_codegen_initialize_runtime_metadata\"(v553, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv662 = Il2CppMethodInfo;\n\tv663 = \"il2cpp_codegen_initialize_runtime_metadata\"(v662, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv729 = Il2CppMethodInfo;\n\tv730 = \"il2cpp_codegen_initialize_runtime_metadata\"(v729, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv790 = Il2CppMethodInfo;\n\tv791 = \"il2cpp_codegen_initialize_runtime_metadata\"(v790, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv897 = Il2CppMethodInfo;\n\tv898 = \"il2cpp_codegen_initialize_runtime_metadata\"(v897, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv960 = Il2CppMethodInfo;\n\tv961 = \"il2cpp_codegen_initialize_runtime_metadata\"(v960, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1021 = Il2CppMethodInfo;\n\tv1022 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1021, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1112 = UnityEngine.GameObject;\n\tv1113 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1112, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1180 = Spine.Unity.ISkeletonAnimation;\n\tv1181 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1180, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1244 = Il2CppMethodInfo;\n\tv1245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1244, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1313 = Il2CppMethodInfo;\n\tv1314 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1313, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1375 = Il2CppMethodInfo;\n\tv1376 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1375, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1444 = Il2CppMethodInfo;\n\tv1445 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1444, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1514 = Il2CppMethodInfo;\n\tv1515 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1514, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1613 = Il2CppMethodInfo;\n\tv1614 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1613, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1676 = Il2CppMethodInfo;\n\tv1677 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1676, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1744 = Il2CppMethodInfo;\n\tv1745 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1744, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1866 = Il2CppMethodInfo;\n\tv1867 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1866, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv1939 = Il2CppMethodInfo;\n\tv1940 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1939, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2039 = System.Collections.Generic.List`1<UnityEngine.Collider2D>;\n\tv2040 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2039, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2138 = System.Collections.Generic.List`1<System.String>;\n\tv2139 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2138, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2240 = UnityEngine.Object;\n\tv2241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2240, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2375 = UnityEngine.Physics2D;\n\tv2376 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2375, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2469 = Il2CppMethodInfo;\n\tv2470 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2469, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2521 = Spine.Unity.UpdateBonesDelegate;\n\tv2522 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2521, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2553 = \"Destroyed Utility Bones: \";\n\tv2554 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2553, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2577 = \",\";\n\tv2578 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2577, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv2623 = \"RagdollRoot\";\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v2623, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A37A94]) = v58;\nL_007D:\n\tthis.isActive = 1;\n\tthis.mix = 1f;\n\tv73 = Spine.Skeleton::FindBone(this.skeleton, this.startingBoneName);\n\tthis.<StartingBone>k__BackingField = v73;\n\tSpine.Unity.Examples.SkeletonRagdoll2D::RecursivelyCreateBoneProxies(this, v73);\n\tv425 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, v73);\n\tv426 = UnityEngine.Component::GetComponent(v425);\n\tthis.<RootRigidbody>k__BackingField = v426;\n\tUnityEngine.Rigidbody2D::set_isKinematic(v426, this.pinStartBone);\n\tUnityEngine.Rigidbody2D::set_mass(this.<RootRigidbody>k__BackingField, this.rootMass);\n\tv1183 = new System.Collections.Generic.List`1<UnityEngine.Collider2D>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider2D>::.ctor(v1183);\n\tv1383 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::GetEnumerator(this.boneTable);\nL_00C6:\n\tv721 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v638 @ stack_-D8_v28 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv1616 = v721 == 0;\n\tif (v1616) goto L_023F;\n\tv654 = UnityEngine.Component::GetComponent(v1678);\n\tv658 = v1183._items;\n\tv620 = v1183._version + 1;\n\tv1183._version = v620;\n\tv859 = v1183._size;\n\tv2041 = v1183._size < v658.Length;\n\tv2042 = ~v2041;\n\tif (v2042) goto L_00F5;\n\tv2140 = v1183._size + 1;\n\tv1183._size = v2140;\n\tv658[v859 @ X10_v53 (System.Int32)] = v654;\n\tgoto L_00FA;\nL_00F5:\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider2D>::AddWithResize(v1183, v654);\nL_00FA:\n\tv845 = v73 == v1449;\n\tif (v845) goto L_0112;\n\tv886 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, *([v1449 @ stack_-C8 (System.Single)+20]));\n\tv2555 = v886 == 0;\n\tv889 = ~v2555;\n\tif (v889) goto L_01A3;\n\tgoto L_0458;\nL_0112:\n\tv1737 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v1737, \"RagdollRoot\");\n\tv1739 = v1737 == 0;\n\tif (v1739) goto L_0464;\n\tv2558 = UnityEngine.GameObject::get_transform(v1737);\n\tthis.ragdollRoot = v2558;\n\tv1605 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v2558, v1605, 0);\n\tv2833 = Spine.Skeleton::get_RootBone(this.skeleton);\n\tv846 = v2833 == v73;\n\tif (v846) goto L_0166;\n\tv1935 = v73.parent;\n\t// 326 MakeStruct v1991 @ AGG1517A64_1_v31 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1935.worldX (System.Single), v1935.worldY (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(this.ragdollRoot, v1991);\n\tv2018 = v73.parent;\n\tv2988 = v2018.parent;\n\tv2984 = v2018.arotation;\n\tv2975 = v2018.parent == 0;\n\tif (v2975) g\n// ... truncated")]
		public unsafe void Apply()
		{
			//IL_01c2: Expected O, but got I
			//IL_05fc: Expected O, but got F4
			//IL_061d: Expected O, but got F4
			//IL_080e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0813: Expected O, but got Unknown
			//IL_0820: Expected O, but got F4
			//IL_104e: Unknown result type (might be due to invalid IL or missing references)
			//IL_1053: Expected O, but got Unknown
			//IL_1060: Expected O, but got F4
			isActive = true;
			mix = 1f;
			Bone bone = (StartingBone = this.skeleton.FindBone(startingBoneName));
			RecursivelyCreateBoneProxies(bone);
			Component component = boneTable[bone];
			(RootRigidbody = component.GetComponent<Rigidbody2D>()).isKinematic = pinStartBone;
			RootRigidbody.mass = rootMass;
			List<Collider2D> list = new List<Collider2D>();
			Dictionary<Bone, Transform>.Enumerator enumerator = boneTable.GetEnumerator();
			float num2 = default(float);
			float num = num2;
			Dictionary<object, object>.Enumerator enumerator3 = default(Dictionary<object, object>.Enumerator);
			Dictionary<object, object>.Enumerator enumerator2 = enumerator3;
			Component component3 = default(Component);
			GameObject gameObject = default(GameObject);
			Vector3 localPosition = default(Vector3);
			Vector3 vector = default(Vector3);
			Dictionary<object, object>.Enumerator enumerator4;
			object obj = default(object);
			Vector3 localPosition2 = default(Vector3);
			Vector3 vector2 = default(Vector3);
			Vector2 connectedAnchor = default(Vector2);
			JointAngleLimits2D jointAngleLimits2D = default(JointAngleLimits2D);
			JointAngleLimits2D limits = default(JointAngleLimits2D);
			float num16 = default(float);
			while (true)
			{
				Component component4;
				List<Collider2D> list2;
				if (enumerator3.MoveNext())
				{
					Collider2D component2 = component3.GetComponent<Collider2D>();
					Collider2D[] items = list._items;
					int version = list._version + 1;
					list._version = version;
					int count = list.Count;
					if (list.Count < items.Length)
					{
						int size = list.Count + 1;
						list._size = size;
						items[count] = component2;
					}
					else
					{
						list.Add(component2);
					}
					if ((float)bone != num2)
					{
						Dictionary<Bone, Transform> dictionary = boneTable;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ stack_-C8 (System.Single)+20]");
						Transform transform = dictionary[(Bone)0];
						bool flag = (object)transform == null;
						bool flag2 = !flag;
						component4 = transform;
						if (flag2)
						{
							goto IL_0622;
						}
						NullReferenceException ex = new NullReferenceException();
						NullReferenceException ex2 = new NullReferenceException();
						NullReferenceException ex3 = new NullReferenceException();
						NullReferenceException ex4 = new NullReferenceException();
						NullReferenceException ex5 = new NullReferenceException();
						NullReferenceException ex6 = new NullReferenceException();
						NullReferenceException ex7 = new NullReferenceException();
						NullReferenceException ex8 = new NullReferenceException();
						NullReferenceException ex9 = new NullReferenceException();
						NullReferenceException ex10 = new NullReferenceException();
						NullReferenceException ex11 = new NullReferenceException();
						NullReferenceException ex12 = new NullReferenceException();
					}
					else
					{
						gameObject = new GameObject("RagdollRoot");
						if ((object)gameObject != null)
						{
							Transform transform2 = (ragdollRoot = gameObject.transform);
							Transform parent = base.transform;
							transform2.SetParent(parent, worldPositionStays: false);
							Bone rootBone = this.skeleton.RootBone;
							if (rootBone != bone)
							{
								Bone parent2 = bone.Parent;
								localPosition.x = parent2.WorldX;
								localPosition.y = parent2.WorldY;
								localPosition.z = 0f;
								ragdollRoot.localPosition = localPosition;
								Bone parent3 = bone.Parent;
								Bone parent4 = parent3.Parent;
								float num3 = parent3.AppliedRotation;
								bool flag3 = parent3.Parent == null;
								float num4 = parent3.AppliedRotation;
								if (!flag3)
								{
									bool flag5;
									do
									{
										parent4 = parent4.Parent;
										num3 += parent4.AppliedRotation;
										bool flag4 = parent4 == null;
										flag5 = !flag4;
										num4 = num3;
									}
									while (flag5);
								}
								float z = num4 * ((float)Math.PI / 180f);
								vector.x = 0f;
								vector.y = 0f;
								vector.z = z;
								Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
								float w = localRotation.w;
								ragdollRoot.localRotation = localRotation;
							}
							else
							{
								bool flag6 = num2 == 0f;
								enumerator4 = enumerator3;
								list2 = list;
								if (flag6)
								{
									NullReferenceException ex13 = new NullReferenceException();
									if (0 == 1)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
										enumerator4.Dispose();
										if (obj != null)
										{
											throw new OutOfMemoryException();
										}
										goto IL_08df;
									}
									break;
								}
								localPosition2.x = bone.WorldX;
								localPosition2.y = bone.WorldY;
								localPosition2.z = 0f;
								ragdollRoot.localPosition = localPosition2;
								Bone parent5 = bone.Parent;
								float num5 = bone.AppliedRotation;
								bool flag7 = bone.Parent == null;
								float num6 = bone.AppliedRotation;
								if (!flag7)
								{
									bool flag9;
									do
									{
										parent5 = parent5.Parent;
										num5 += parent5.AppliedRotation;
										bool flag8 = parent5 == null;
										flag9 = !flag8;
										num6 = num5;
									}
									while (flag9);
								}
								float z2 = num6 * ((float)Math.PI / 180f);
								vector2.x = 0f;
								vector2.y = 0f;
								vector2.z = z2;
								Quaternion localRotation2 = Quaternion.Euler(vector2 * 57.29578f);
								float w = localRotation2.w;
								ragdollRoot.localRotation = localRotation2;
							}
							Vector3 position = ((Transform)component3).position;
							Transform transform3 = base.transform;
							Vector3 position2 = transform3.position;
							float z3 = position2.z;
							float num7 = position.x - position2.x;
							num = position.y - position2.y;
							rootOffset = (Vector2)num7;
							rootOffset.y = num;
							component4 = ragdollRoot;
							enumerator2 = (Dictionary<object, object>.Enumerator)num7;
							goto IL_0622;
						}
					}
					throw gameObject;
				}
				enumerator3.Dispose();
				list2 = list;
				goto IL_08df;
				IL_0622:
				Rigidbody2D component5 = component4.GetComponent<Rigidbody2D>();
				if (component5 != null)
				{
					GameObject gameObject2 = component3.gameObject;
					HingeJoint2D hingeJoint2D = gameObject2.AddComponent<HingeJoint2D>();
					hingeJoint2D.connectedBody = component5;
					Vector3 position3 = ((Transform)component3).position;
					Vector3 vector3 = ((Transform)component4).InverseTransformPoint(position3);
					connectedAnchor.x = vector3.x;
					connectedAnchor.y = vector3.y;
					hingeJoint2D.connectedAnchor = connectedAnchor;
					Rigidbody2D component6 = hingeJoint2D.GetComponent<Rigidbody2D>();
					Rigidbody2D connectedBody = hingeJoint2D.connectedBody;
					float mass = connectedBody.mass;
					float mass2 = mass * massFalloffFactor;
					component6.mass = mass2;
					Transform transform4 = component5.transform;
					Vector3 eulerAngles = transform4.eulerAngles;
					Vector3 eulerAngles2 = ((Transform)component3).eulerAngles;
					float num8 = eulerAngles.z - eulerAngles2.z;
					float num9 = num8 + 360f;
					((List<Collider2D>)(object)component3).Add((Collider2D)null);
					float num10 = num9 - rotationLimit;
					float num11 = num9 + rotationLimit;
					float min = num10 + -360f;
					float num12 = num11 - 180f;
					bool flag10 = num12 < 0f;
					bool flag11 = num12 == 0f;
					object obj2 = num11 ^ 0x43340000;
					object obj3 = num11 ^ num12;
					int num13 = (int)((nint)obj2 & (nint)obj3);
					bool flag12 = num13 < 0;
					bool flag13 = flag10 == flag12;
					bool flag14 = !flag11;
					if (!(flag13 && flag14))
					{
						min = num10;
					}
					jointAngleLimits2D.min = min;
					float max = num11 + -360f;
					float num14 = num11 - 180f;
					bool flag15 = num14 < 0f;
					bool flag16 = num14 == 0f;
					object obj4 = num11 ^ 0x43340000;
					object obj5 = num11 ^ num14;
					int num15 = (int)((nint)obj4 & (nint)obj5);
					bool flag17 = num15 < 0;
					bool flag18 = flag15 == flag17;
					bool flag19 = !flag16;
					if (!(flag18 && flag19))
					{
						max = num11;
					}
					jointAngleLimits2D.max = max;
					limits.m_LowerAngle = jointAngleLimits2D.m_LowerAngle;
					limits.m_UpperAngle = num16;
					hingeJoint2D.limits = limits;
					hingeJoint2D.useLimits = true;
					float w = 180f;
					float z3 = -360f;
					num = num16;
					enumerator2 = (Dictionary<object, object>.Enumerator)jointAngleLimits2D;
				}
				continue;
				IL_08df:
				int num17 = list2.Count;
				if (list2.Count >= 1)
				{
					int num18 = 0;
					do
					{
						if (num17 >= 1)
						{
							int num19 = 0;
							int num20 = num17;
							bool flag20;
							do
							{
								if (num18 != num19)
								{
									Collider2D collider = list2[num18];
									Collider2D collider2 = list2[num19];
									Physics2D.IgnoreCollision(collider, collider2);
									num20 = list2.Count;
								}
								num19++;
								flag20 = num19 < num20;
								num17 = num20;
							}
							while (flag20);
						}
						num18++;
					}
					while (num18 < num17);
				}
				SkeletonUtilityBone[] componentsInChildren = GetComponentsInChildren<SkeletonUtilityBone>();
				if (componentsInChildren.Length != 0)
				{
					List<string> list3 = new List<string>();
					int num21 = componentsInChildren.Length;
					if (componentsInChildren.Length >= 1)
					{
						int num22 = 0;
						do
						{
							Component component7 = componentsInChildren[num22];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ X22_v41 (UnityEngine.Component)+30]");
							if ((nint)0 == 1)
							{
								GameObject gameObject3 = componentsInChildren[num22].gameObject;
								string text = gameObject3.name;
								string[] items2 = list3._items;
								int version2 = list3._version + 1;
								list3._version = version2;
								int count2 = list3.Count;
								if (list3.Count < items2.Length)
								{
									int size2 = list3.Count + 1;
									list3._size = size2;
									items2[count2] = text;
								}
								else
								{
									list3.Add(text);
								}
								GameObject obj6 = componentsInChildren[num22].gameObject;
								UnityEngine.Object.Destroy(obj6);
								num21 = componentsInChildren.Length;
							}
							num22++;
						}
						while (num22 < num21);
					}
					if (list3.Count >= 1)
					{
						string text2 = "Destroyed Utility Bones: ";
						int num23 = 0;
						int count3;
						do
						{
							string text3 = list3[num23];
							string text4 = text2 + text3;
							count3 = list3.Count;
							int num24 = list3.Count - 1;
							bool flag21 = num23 == num24;
							text2 = text4;
							if (!flag21)
							{
								string text5 = text4 + ",";
								count3 = list3.Count;
								text2 = text5;
							}
							num23++;
						}
						while (num23 < count3);
						Debug.LogWarning(text2);
					}
				}
				if (disableIK)
				{
					Skeleton skeleton = this.skeleton;
					ExposedList<IkConstraint> ikConstraints = skeleton.IkConstraints;
					if (ikConstraints.Count >= 1)
					{
						IkConstraint[] items3 = ikConstraints.Items;
						int num25 = 0;
						do
						{
							IkConstraint ikConstraint = items3[num25];
							num25++;
							ikConstraint.Mix = 0f;
						}
						while (ikConstraints.Count != num25);
					}
				}
				if (disableOtherConstraints)
				{
					Skeleton skeleton2 = this.skeleton;
					ExposedList<TransformConstraint> transformConstraints = skeleton2.TransformConstraints;
					if (transformConstraints.Count >= 1)
					{
						TransformConstraint[] items4 = transformConstraints.Items;
						int num26 = 0;
						do
						{
							TransformConstraint transformConstraint = items4[num26];
							num26++;
							transformConstraint.RotateMix = 0f;
							transformConstraint.ScaleMix = 0f;
						}
						while (transformConstraints.Count != num26);
					}
					ExposedList<PathConstraint> pathConstraints = skeleton2.PathConstraints;
					if (pathConstraints.Count >= 1)
					{
						PathConstraint[] items5 = pathConstraints.Items;
						int num27 = 0;
						do
						{
							PathConstraint pathConstraint = items5[num27];
							num27++;
							pathConstraint.RotateMix = 0f;
						}
						while (pathConstraints.Count != num27);
					}
				}
				UpdateBonesDelegate value = UpdateSpineSkeleton;
				targetSkeletonComponent.UpdateWorld += value;
				return;
			}
			enumerator4.Dispose();
			OutOfMemoryException ex14 = new OutOfMemoryException();
			((Dictionary<Bone, Transform>.Enumerator*)ex14)->Dispose();
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x1514944", Offset = "0x1514944", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = Spine.Unity.Examples.SkeletonRagdoll2D::SmoothMixCoroutine(this, target, duration);\n\treturnVal1 = UnityEngine.MonoBehaviour::StartCoroutine(this, v6);\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Coroutine SmoothMix(float target, float duration)
		{
			IEnumerator routine = SmoothMixCoroutine(target, duration);
			return StartCoroutine(routine);
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x151BDBC", Offset = "0x151BDBC", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Spine.Unity.Examples.SkeletonRagdoll2D+<SmoothMixCoroutine>d__40;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, target, duration, v35, v36, v37, v38, v39, v40);\n\tv43 = 1;\n\t*([1A37A95]) = v43;\nL_0018:\n\tv45 = new Spine.Unity.Examples.SkeletonRagdoll2D+<SmoothMixCoroutine>d__40();\n\tSpine.Unity.Examples.SkeletonRagdoll2D+<SmoothMixCoroutine>d__40::.ctor(v45, 0);\n\tv45.<>4__this = this;\n\tv45.target = target;\n\tv45.duration = duration;\n\treturn v45;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal IEnumerator SmoothMixCoroutine(float target, float duration)
		{
			float time = Time.time;
			float startTime = time;
			float startMix = mix;
			while (mix > 0f)
			{
				skeleton.SetBonesToSetupPose();
				float time2 = Time.time;
				float num = time2 - startTime;
				float num2 = num / duration;
				bool flag = num2 < 0f;
				float num3 = Mathf.Min(num2, 1f);
				if (flag)
				{
					num3 = 0f;
				}
				float num4 = num3 + num3;
				float num5 = num3 * 3f;
				float num6 = num3 * num4;
				float num7 = num3 * num5;
				float num8 = num3 * num6;
				float num9 = num7 - num8;
				float num10 = target * num9;
				float num11 = 1f - num9;
				float num12 = startMix * num11;
				float num13 = num10 + num12;
				mix = num13;
				yield return null;
			}
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x15146D0", Offset = "0x15146D0", Length = "0x274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv36 = UnityEngine.Debug;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv225 = Il2CppMethodInfo;\n\tv226 = \"il2cpp_codegen_initialize_runtime_metadata\"(v225, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv273 = Il2CppMethodInfo;\n\tv274 = \"il2cpp_codegen_initialize_runtime_metadata\"(v273, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv277 = \"Can't call SetSkeletonPosition while Ragdoll is not active!\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v277, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37A96]) = v53;\nL_002F:\n\tv54 = 0;\n\tv58 = ~this.isActive;\n\tif (v58) goto L_0088;\n\tv64 = UnityEngine.Component::get_transform(this);\n\tv74 = v64 == 0;\n\tif (v74) goto L_009D;\n\tv85 = UnityEngine.Transform::get_position(v64);\n\tv148 = UnityEngine.Component::get_transform(this);\n\tv154 = v148 == 0;\n\tif (v154) goto L_009D;\n\tUnityEngine.Transform::set_position(v148, worldPosition);\n\tv155 = this.boneTable == 0;\n\tif (v155) goto L_009D;\n\tv150 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv156 = v150 == 0;\n\tif (v156) goto L_009D;\n\tv159 = worldPosition - v85;\n\tv162 = worldPosition.y - v85.y;\n\tv165 = worldPosition.z - v85.z;\n\tv307 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v150);\nL_0063:\n\tv326 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv313 = v326 == 0;\n\tif (v313) goto L_0079;\n\tv330 = UnityEngine.Transform::get_position(0);\n\tv317 = v330 - v159;\n\tv179 = v330.y - v162;\n\tv174 = v330.z - v165;\n\t// 116 MakeStruct v316 @ AGG1518840_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v317 @ V0_v8 (System.Single), v179 @ V1_v3 (System.Single), v174 @ V2_v3 (System.Single)\n\tUnityEngine.Transform::set_position(0, v316);\n\tgoto L_0063;\nL_0079:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_007B:\n\tSpine.Unity.Examples.SkeletonRagdoll2D::UpdateSpineSkeleton(this, v145);\n\tv157 = this.skeleton == 0;\n\tif (v157) goto L_009D;\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\n\tgoto L_009B;\nL_0088:\n\tgoto L_008E;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v67, methodInfo, v39, v40, v41, v42, v43, v44, worldPosition, v0, v2, v45, v46, v47, v48, v49);\nL_008E:\n\tUnityEngine.Debug::LogWarning(\"Can't call SetSkeletonPosition while Ragdoll is not active!\");\nL_009B:\n\treturn;\n\tv147 = new System.NullReferenceException();\nL_009D:\n\tv184 = new System.NullReferenceException();\n\tgoto L_00AB;\n\tgoto L_00AB;\n\tgoto L_00AB;\nL_00AB:\n\tv229 = v140 != 1;\n\tif (v229) goto L_00BB;\n\tv279 = 0x1854E70(v184, v140, v39, v40, v41, v42, v43, v44, v136, v179, v174, v45, v46, v47, v48, v49);\n\tv290 = 0x1854E80(v279, v140, v39, v40, v41, v42, v43, v44, v136, v179, v174, v45, v46, v47, v48, v49);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv287 = *([v279 @ X0_v20]) == 0;\n\tif (v287) goto L_007B;\n\tthrow System.OutOfMemoryException;\nL_00BB:\n\tgoto L_00C1;\n\tX20 = X0;\nL_00C1:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v54 @ stack_-78_v1 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00C8;\n\tv298 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v184);\nL_00C8:\n\tv301 = new System.OutOfMemoryException();\n\tv259 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::Dispose(v301);\n\treturn;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetSkeletonPosition(Vector3 worldPosition)
		{
			//IL_0024: Expected O, but got I
			//IL_006e: Expected O, but got I4
			//IL_0366: Expected O, but got I
			//IL_00c5: Expected O, but got I4
			//IL_02b3: Expected O, but got I
			//IL_011c: Expected O, but got I4
			//IL_0285: Expected O, but got I
			//IL_0271: Expected O, but got F4
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = default(Dictionary<object, object>.ValueCollection.Enumerator);
			object obj;
			ISkeletonAnimation animatedSkeleton;
			Vector3 vector;
			float z;
			float y;
			if (IsActive)
			{
				Transform transform = base.transform;
				bool flag = (object)transform == null;
				obj = 0;
				if (!flag)
				{
					Vector3 position = transform.position;
					Transform transform2 = base.transform;
					bool flag2 = (object)transform2 == null;
					vector = worldPosition;
					obj = 0;
					z = worldPosition.z;
					y = worldPosition.y;
					if (!flag2)
					{
						transform2.position = worldPosition;
						bool flag3 = boneTable == null;
						vector = position;
						obj = 0;
						z = position.z;
						y = position.y;
						if (!flag3)
						{
							Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
							bool flag4 = values == null;
							vector = worldPosition;
							obj = 0;
							z = worldPosition.z;
							y = worldPosition.y;
							if (!flag4)
							{
								Vector3 vector2 = default(Vector3);
								float num = vector2.x - position.x;
								float num2 = worldPosition.y - position.y;
								float num3 = worldPosition.z - position.z;
								Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator2 = values.GetEnumerator();
								vector = worldPosition;
								z = worldPosition.z;
								y = worldPosition.y;
								Vector3 position3 = default(Vector3);
								while (enumerator.MoveNext())
								{
									Vector3 position2 = ((Transform)null).position;
									float num4 = position2.x - num;
									y = position2.y - num2;
									z = position2.z - num3;
									position3.x = num4;
									position3.y = y;
									position3.z = z;
									((Transform)null).position = position3;
									vector = (Vector3)num4;
								}
								enumerator.Dispose();
								animatedSkeleton = (ISkeletonAnimation)0;
								goto IL_028a;
							}
						}
					}
				}
				goto IL_0300;
			}
			Debug.LogWarning("Can't call SetSkeletonPosition while Ragdoll is not active!");
			return;
			IL_0300:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)obj == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj2 = default(object);
				bool flag5 = obj2 == null;
				animatedSkeleton = (ISkeletonAnimation)0;
				if (!flag5)
				{
					throw new OutOfMemoryException();
				}
				goto IL_028a;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex2)->Dispose();
			return;
			IL_028a:
			UpdateSpineSkeleton(animatedSkeleton);
			bool flag6 = skeleton == null;
			vector = worldPosition;
			obj = 0;
			z = worldPosition.z;
			y = worldPosition.y;
			if (!flag6)
			{
				skeleton.UpdateWorldTransform();
				return;
			}
			goto IL_0300;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x1514964", Offset = "0x1514964", Length = "0x2D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv160 = Il2CppMethodInfo;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv189 = Il2CppMethodInfo;\n\tv190 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv205 = Spine.Unity.ISkeletonAnimation;\n\tv206 = \"il2cpp_codegen_initialize_runtime_metadata\"(v205, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv221 = UnityEngine.Object;\n\tv222 = \"il2cpp_codegen_initialize_runtime_metadata\"(v221, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv229 = Il2CppMethodInfo;\n\tv230 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv240 = Spine.Unity.UpdateBonesDelegate;\n\tv241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv249 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v249, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37A97]) = v48;\nL_0036:\n\tthis.isActive = 0;\n\tv53 = this.boneTable == 0;\n\tif (v53) goto L_00C8;\n\tv60 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Values(this.boneTable);\n\tv145 = v60 == 0;\n\tif (v145) goto L_00C8;\n\tv176 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>::GetEnumerator(v60);\nL_0058:\n\tv216 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v108 @ stack_-88_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv224 = v216 == 0;\n\tif (v224) goto L_006E;\n\tv243 = UnityEngine.Component::get_gameObject(v192);\n\tgoto L_006A;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v250, v242, v31, v32, v33, v34, v35, v36, v105, v38, v39, v40, v41, v42, v43, v44);\nL_006A:\n\tUnityEngine.Object::Destroy(v243);\n\tgoto L_0058;\nL_006E:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v108 @ stack_-88_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_0070:\n\tv146 = this.ragdollRoot == 0;\n\tif (v146) goto L_00C8;\n\tv253 = UnityEngine.Component::get_gameObject(this.ragdollRoot);\n\tgoto L_007E;\n\tv322 = v152;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v322, v252, v92, v89, v33, v34, v35, v36, v106, v38, v39, v40, v41, v42, v43, v44);\nL_007E:\n\tUnityEngine.Object::Destroy(v253);\n\tv147 = this.boneTable == 0;\n\tif (v147) goto L_00C8;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Clear(this.boneTable);\n\tv157 = this.targetSkeletonComponent;\n\tv142 = new *([v122 @ X24_v2 (Il2CppClass<Spine.Unity.UpdateBonesDelegate>)])();\n\tv91 = *([v119 @ X23_v2 (Il2CppMethodInfo)]);\n\tSpine.Unity.UpdateBonesDelegate::.ctor(v142, this, *([v119 @ X23_v2 (Il2CppMethodInfo)]));\n\tv148 = this.targetSkeletonComponent == 0;\n\tif (v148) goto L_00C8;\n\tv328 = *([v157 @ X20_v6 (Spine.Unity.ISkeletonAnimation)]);\n\tv371 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]);\n\tv315 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]) == 0;\n\tif (v315) goto L_00AF;\n\tv370 = *([v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+B0]) + 8;\nL_009A:\n\tv376 = *([v370 @ X10_v5-8]) == *([v116 @ X22_v2 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)]);\n\tif (v376) goto L_00B2;\n\tv356 = v371 - 1;\n\tv370 = v370 + 0x10;\n\tv336 = v371 != 1;\n\tif (v336) goto L_009A;\nL_00AF:\n\t;\n\tgoto L_00BA;\nL_00B2:\n\t;\nL_00BA:\n\tv313 = Spine.Unity.ISkeletonAnimation::remove_UpdateWorld(this.targetSkeletonComponent, v142);\n\treturn;\n\tv139 = new System.NullReferenceException();\nL_00C8:\n\tv158 = new System.NullReferenceException();\n\tgoto L_00D5;\n\tgoto L_00D5;\nL_00D5:\n\tv187 = v133 != 1;\n\tif (v187) goto L_00E3;\n\tv194 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext(v158);\n\tv217 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+ValueCollection<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngine.Transform>::MoveNext(v194);\n\tv135 = *([v111 @ X27_v1 (Il2CppMethodInfo)]);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v103 @ stack_-70_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv202 = ~v194.m_value;\n\tif (v202) goto L_0070;\n\tthrow System.OutOfMemoryException;\nL_00E3:\n\tgoto L_00E7;\n\tX20 = X0;\nL_00E7:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v103 @ stack_-70_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+ValueCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_00EE;\n\tv235 = 0xBD3CD0(v158, *([v111 @ X27_v1 (Il2CppMethodInfo)]), v91, v88, v33, v34, v35, v36, v104, v38, v39, v40, v41, v42, v43, v44);\nL_00EE:\n\tv238 = new System.OutOfMemoryException();\n\tv247 = 0x9DACB4(v238, *([v111 @ X27_v1 (Il2CppMethodInfo)]), v91, v88, v33, v34, v35, v36, v104, v38, v39, v40, v41, v42, v43, v44);\n\treturn;\n// 149 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Remove()
		{
			//IL_043e: Expected O, but got I4
			//IL_046c: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_006b: Expected I, but got O
			//IL_00ef: Expected I, but got O
			//IL_0103: Expected I, but got O
			//IL_0276: Expected I, but got O
			//IL_028c: Expected I, but got O
			//IL_029c: Expected O, but got I
			//IL_02d7: Expected O, but got I
			//IL_02eb: Expected O, but got I
			//IL_02fa: Expected O, but got I
			isActive = false;
			bool flag = boneTable == null;
			object obj = 0;
			Dictionary<object, object>.ValueCollection.Enumerator enumerator2 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			Dictionary<object, object>.ValueCollection.Enumerator enumerator = enumerator2;
			nint num2 = default(nint);
			nint num = num2;
			nint num4 = default(nint);
			nint num3 = num4;
			nint num6 = default(nint);
			nint num5 = num6;
			nint num8 = default(nint);
			nint num7 = num8;
			nint num9 = (nint)this;
			object obj2 = default(object);
			IntPtr intPtr2 = default(IntPtr);
			object obj4;
			IntPtr intPtr3;
			Dictionary<object, object>.ValueCollection.Enumerator enumerator3 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			nint num10;
			IntPtr intPtr = default(IntPtr);
			if (!flag)
			{
				Dictionary<Bone, Transform>.ValueCollection values = boneTable.Values;
				bool flag2 = values == null;
				obj = obj2;
				intPtr = intPtr2;
				Dictionary<object, object>.ValueCollection.Enumerator enumerator4 = default(Dictionary<object, object>.ValueCollection.Enumerator);
				enumerator3 = enumerator4;
				enumerator = enumerator4;
				num = 0;
				num3 = (nint)typeof(ISkeletonAnimation);
				num5 = 0;
				num7 = (nint)typeof(UpdateBonesDelegate);
				num9 = 0;
				if (!flag2)
				{
					Dictionary<Bone, Transform>.ValueCollection.Enumerator enumerator5 = values.GetEnumerator();
					Component component = default(Component);
					while (enumerator4.MoveNext())
					{
						GameObject obj3 = component.gameObject;
						UnityEngine.Object.Destroy(obj3);
					}
					enumerator4.Dispose();
					obj4 = obj2;
					intPtr3 = intPtr2;
					enumerator3 = enumerator4;
					enumerator2 = enumerator4;
					num2 = 0;
					num4 = (nint)typeof(ISkeletonAnimation);
					num6 = 0;
					num8 = (nint)typeof(UpdateBonesDelegate);
					num10 = 0;
					goto IL_010f;
				}
			}
			goto IL_0331;
			IL_010f:
			bool flag3 = (object)ragdollRoot == null;
			obj = obj2;
			intPtr = intPtr2;
			enumerator3 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			Dictionary<object, object>.ValueCollection.Enumerator enumerator6 = default(Dictionary<object, object>.ValueCollection.Enumerator);
			enumerator = enumerator6;
			IntPtr intPtr4 = default(IntPtr);
			num = intPtr4;
			IntPtr intPtr5 = default(IntPtr);
			num3 = intPtr5;
			IntPtr intPtr6 = default(IntPtr);
			num5 = intPtr6;
			IntPtr intPtr7 = default(IntPtr);
			num7 = intPtr7;
			num9 = 0;
			if (!flag3)
			{
				GameObject obj5 = ragdollRoot.gameObject;
				UnityEngine.Object.Destroy(obj5);
				bool flag4 = boneTable == null;
				obj = obj4;
				intPtr = intPtr3;
				enumerator = enumerator2;
				num = num2;
				num3 = num4;
				num5 = num6;
				num7 = num8;
				num9 = num10;
				if (!flag4)
				{
					boneTable.Clear();
					ISkeletonAnimation skeletonAnimation = targetSkeletonComponent;
					UpdateBonesDelegate value = new UpdateBonesDelegate(this, num6);
					intPtr = num6;
					bool flag5 = targetSkeletonComponent == null;
					obj = obj4;
					intPtr = intPtr3;
					enumerator = enumerator2;
					num = num2;
					num3 = num4;
					num5 = num6;
					num7 = num8;
					num9 = unchecked((nint)null);
					if (!flag5)
					{
						nint num11 = (nint)skeletonAnimation;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]");
						object obj6 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+12E]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X8_v6 (Il2CppClass<Spine.Unity.ISkeletonAnimation>)+B0]");
							object obj7 = (nint)0 + (nint)8;
							bool flag6;
							do
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ X10_v5-8]");
								if (0 != num4)
								{
									object obj8 = (nint)obj6 - 1;
									obj7 = (nint)obj7 + 16;
									flag6 = (nint)obj6 != 1;
									obj6 = obj8;
									continue;
								}
								break;
							}
							while (flag6);
						}
						targetSkeletonComponent.UpdateWorld -= value;
						return;
					}
				}
			}
			goto IL_0331;
			IL_0331:
			NullReferenceException ex = new NullReferenceException();
			if (num9 == 1)
			{
				bool flag7 = ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)ex)->MoveNext();
				bool flag8 = (flag7 ? ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)1) : ((Dictionary<Bone, Transform>.ValueCollection.Enumerator*)null))->MoveNext();
				num10 = num;
				enumerator3.Dispose();
				bool flag9 = !((bool*)(flag7 ? 1 : 0))->m_value;
				obj4 = obj;
				intPtr3 = intPtr;
				enumerator2 = enumerator;
				num2 = num;
				num4 = num3;
				num6 = num5;
				num8 = num7;
				if (!flag9)
				{
					throw new OutOfMemoryException();
				}
				goto IL_010f;
			}
			enumerator3.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x151C3B4", Offset = "0x151C3B4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv67 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, boneName, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37A98]) = v37;\nL_001D:\n\tv45 = Spine.Skeleton::FindBone(this.skeleton, boneName);\n\tv68 = v45 == 0;\n\tif (v68) goto L_0046;\n\tv72 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::ContainsKey(this.boneTable, v45);\n\tv74 = v72 == 0;\n\tif (v74) goto L_0046;\n\tv55 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, v45);\n\treturnVal3 = UnityEngine.Component::GetComponent(v55);\n\treturn returnVal3;\nL_0046:\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Rigidbody2D GetRigidbody(string boneName)
		{
			Bone bone = skeleton.FindBone(boneName);
			if (bone != null && boneTable.ContainsKey(bone))
			{
				Component component = boneTable[bone];
				return component.GetComponent<Rigidbody2D>();
			}
			return null;
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x151B970", Offset = "0x151B970", Length = "0x41C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv179 = Il2CppMethodInfo;\n\tv180 = \"il2cpp_codegen_initialize_runtime_metadata\"(v179, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv182 = Il2CppMethodInfo;\n\tv183 = \"il2cpp_codegen_initialize_runtime_metadata\"(v182, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv200 = Il2CppMethodInfo;\n\tv201 = \"il2cpp_codegen_initialize_runtime_metadata\"(v200, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv219 = Il2CppMethodInfo;\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv272 = Il2CppMethodInfo;\n\tv273 = \"il2cpp_codegen_initialize_runtime_metadata\"(v272, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv311 = Il2CppMethodInfo;\n\tv312 = \"il2cpp_codegen_initialize_runtime_metadata\"(v311, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv319 = Il2CppMethodInfo;\n\tv320 = \"il2cpp_codegen_initialize_runtime_metadata\"(v319, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv325 = UnityEngine.GameObject;\n\tv326 = \"il2cpp_codegen_initialize_runtime_metadata\"(v325, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv329 = Il2CppMethodInfo;\n\tv330 = \"il2cpp_codegen_initialize_runtime_metadata\"(v329, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv332 = Il2CppMethodInfo;\n\tv333 = \"il2cpp_codegen_initialize_runtime_metadata\"(v332, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv338 = UnityEngine.Object;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, b, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A37A99]) = v41;\nL_0038:\n\tv42 = 0;\n\tv45 = b == 0;\n\tif (v45) goto L_0119;\n\tv49 = b.data;\n\tv50 = b.data == 0;\n\tif (v50) goto L_0119;\n\tv157 = this.stopBoneNames == 0;\n\tif (v157) goto L_0119;\n\tv187 = System.Collections.Generic.List`1<System.String>::Contains(this.stopBoneNames, v49.name);\n\tv203 = v187 == 0;\n\tv204 = ~v203;\n\tif (v204) goto L_0118;\n\tv148 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v148, v49.name);\n\tv158 = v148 == 0;\n\tif (v158) goto L_0119;\n\tUnityEngine.GameObject::set_layer(v148, this.colliderLayer);\n\tv149 = UnityEngine.GameObject::get_transform(v148);\n\tv159 = this.boneTable == 0;\n\tif (v159) goto L_0119;\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(this.boneTable, b, v149);\n\tv150 = UnityEngine.Component::get_transform(this);\n\tv160 = v149 == 0;\n\tif (v160) goto L_0119;\n\tUnityEngine.Transform::set_parent(v149, v150);\n\t// 119 MakeStruct v110 @ AGG151FB10_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), b.worldX (System.Single), b.worldY (System.Single), 0\n\tUnityEngine.Transform::set_localPosition(v149, v110);\n\tv350 = Spine.Bone::get_WorldRotationX(b);\n\tv354 = v350 - b.shearX;\n\tv356 = v354 * 0.017453292f;\n\t// 132 MakeStruct v107 @ AGG151FB40_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v356 @ V2_v5 (System.Single)\n\tv358 = UnityEngine.Quaternion::Internal_FromEulerRad(v107);\n\tUnityEngine.Transform::set_localRotation(v149, v358);\n\tv365 = Spine.Bone::get_WorldScaleX(b);\n\tv368 = Spine.Bone::get_WorldScaleY(b);\n\t// 153 MakeStruct v95 @ AGG151FB80_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v365 @ V0_v8 (System.Single), v368 @ V0_v9 (System.Single), 1f\n\tUnityEngine.Transform::set_localScale(v149, v95);\n\tv151 = Spine.Unity.Examples.SkeletonRagdoll2D::AttachBoundingBoxRagdollColliders(b, v148, this.skeleton, this.gravityScale);\n\tv161 = v151 == 0;\n\tif (v161) goto L_0119;\n\tv374 = v151._size == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_00DA;\n\tv171 = b.data;\n\tv162 = b.data == 0;\n\tif (v162) goto L_0119;\n\tv59 = v171.length != 0;\n\tif (v59) goto L_00C6;\n\tv152 = UnityEngine.GameObject::AddComponent(v148);\n\tv163 = v152 == 0;\n\tif (v163) goto L_0119;\n\tv381 = this.thickness * 0.5f;\n\tUnityEngine.CircleCollider2D::set_radius(v152, v381);\n\tgoto L_00DA;\nL_00C6:\n\tv153 = UnityEngine.GameObject::AddComponent(v148);\n\tv164 = v153 == 0;\n\tif (v164) goto L_0119;\n\t// 205 MakeStruct v377 @ AGG151FC10_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v171.length (System.Single), this.thickness (System.Single)\n\tUnityEngine.BoxCollider2D::set_size(v153, v377);\n\tv380 = v171.length * 0.5f;\n\t// 212 MakeStruct v376 @ AGG151FC28_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v380 @ V0_v16 (System.Single), 0\n\tUnityEngine.Collider2D::set_offset(v153, v376);\nL_00DA:\n\tv395 = UnityEngine.GameObject::GetComponent(v148);\n\tgoto L_00E8;\n\tv407 = v400;\n\tv408 = \"il2cpp_codegen_runtime_class_init\"(v407, v394, v135, v121, v26, v27, v28, v29, v119, v115, v112, v104, v34, v35, v36, v37);\nL_00E8:\n\tv412 = UnityEngine.Object::op_Equality(v395, 0);\n\tv414 = v412 == 0;\n\tif (v414) goto L_00F2;\n\tv423 = UnityEngine.GameObject::AddComponent(v148);\nL_00F2:\n\tv166 = v140 == 0;\n\tif (v166) goto L_0119;\n\tUnityEngine.Rigidbody2D::set_gravityScale(v140, this.gravityScale);\n\tv165 = b.children == 0;\n\tif (v165) goto L_0119;\n\tv431 = Spine.ExposedList`1<Spine.Bone>::GetEnumerator(b.children);\nL_0104:\n\tv440 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv253 = v440 == 0;\n\tif (v253) goto L_0110;\n\tSpine.Unity.Examples.SkeletonRagdoll2D::RecursivelyCreateBoneProxies(this, 0);\n\tgoto L_0104;\nL_0110:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0118:\n\treturn;\nL_0119:\n\tv177 = new System.NullReferenceException();\n\tgoto L_0125;\nL_0125:\n\tv198 = v122 != 1;\n\tif (v198) goto L_0135;\n\tv206 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(v177, v122, v131);\n\tv266 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::Add(v206, v122, v131);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv212 = *([v206 @ X0_v13 (System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>)]) == 0;\n\tif (v212) goto L_0118;\n\tthrow System.OutOfMemoryException;\nL_0135:\n\tgoto L_013B;\n\tX20 = X0;\nL_013B:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v42 @ stack_-48_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_0142;\n\tv314 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v177);\nL_0142:\n\tv317 = new System.OutOfMemoryException();\n\tv301 = Spine.ExposedList`1<Spine.Bone>+Enumerator<Spine.Bone>::Dispose(v317);\n\treturn;\n// 195 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void RecursivelyCreateBoneProxies(Bone b)
		{
			//IL_0658: Expected O, but got I
			//IL_0036: Expected O, but got I
			//IL_0065: Expected O, but got I
			//IL_0508: Expected O, but got I
			//IL_0423: Expected O, but got I
			//IL_03c4: Expected O, but got I
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			bool flag = b == null;
			Bone bone = b;
			IntPtr intPtr = default(IntPtr);
			Transform value = (Transform)(nint)intPtr;
			GameObject gameObject;
			if (!flag)
			{
				BoneData data = b.Data;
				bool flag2 = b.Data == null;
				bone = b;
				value = (Transform)(nint)intPtr;
				if (!flag2)
				{
					bool flag3 = stopBoneNames == null;
					bone = b;
					value = (Transform)(nint)intPtr;
					if (!flag3)
					{
						if (stopBoneNames.Contains(data.Name))
						{
							return;
						}
						gameObject = new GameObject(data.Name);
						bool flag4 = (object)gameObject == null;
						bone = (Bone)(object)data.Name;
						value = null;
						if (!flag4)
						{
							gameObject.layer = colliderLayer;
							Transform transform = gameObject.transform;
							bool flag5 = boneTable == null;
							bone = null;
							value = null;
							if (!flag5)
							{
								boneTable.Add(b, transform);
								Transform parent = base.transform;
								bool flag6 = (object)transform == null;
								bone = null;
								value = transform;
								if (!flag6)
								{
									transform.parent = parent;
									Vector3 localPosition = default(Vector3);
									localPosition.x = b.WorldX;
									localPosition.y = b.WorldY;
									localPosition.z = 0f;
									transform.localPosition = localPosition;
									float worldRotationX = b.WorldRotationX;
									float num = worldRotationX - b.ShearX;
									float z = num * ((float)Math.PI / 180f);
									Vector3 vector = default(Vector3);
									vector.x = 0f;
									vector.y = 0f;
									vector.z = z;
									Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
									transform.localRotation = localRotation;
									float worldScaleX = b.WorldScaleX;
									float worldScaleY = b.WorldScaleY;
									Vector3 localScale = default(Vector3);
									localScale.x = worldScaleX;
									localScale.y = worldScaleY;
									localScale.z = 1f;
									transform.localScale = localScale;
									List<Collider2D> list = AttachBoundingBoxRagdollColliders(b, gameObject, skeleton, gravityScale);
									bool flag7 = list == null;
									bone = (Bone)(object)gameObject;
									value = (Transform)(object)skeleton;
									if (!flag7)
									{
										if (list.Count != 0)
										{
											goto IL_04ab;
										}
										BoneData data2 = b.Data;
										bool flag8 = b.Data == null;
										bone = (Bone)(object)gameObject;
										value = (Transform)(object)skeleton;
										if (!flag8)
										{
											if (data2.Length == 0f)
											{
												CircleCollider2D circleCollider2D = gameObject.AddComponent<CircleCollider2D>();
												bool flag9 = (object)circleCollider2D == null;
												bone = (Bone)0;
												value = (Transform)(object)skeleton;
												if (!flag9)
												{
													float radius = thickness * 0.5f;
													circleCollider2D.radius = radius;
													goto IL_04ab;
												}
											}
											else
											{
												BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
												bool flag10 = (object)boxCollider2D == null;
												bone = (Bone)0;
												value = (Transform)(object)skeleton;
												if (!flag10)
												{
													Vector2 size = default(Vector2);
													size.x = data2.Length;
													size.y = thickness;
													boxCollider2D.size = size;
													float x = data2.Length * 0.5f;
													Vector2 offset = default(Vector2);
													offset.x = x;
													offset.y = 0f;
													boxCollider2D.offset = offset;
													goto IL_04ab;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			goto IL_0583;
			IL_04ab:
			Rigidbody2D component = gameObject.GetComponent<Rigidbody2D>();
			bool flag11 = component == null;
			bool flag12 = !flag11;
			bone = null;
			Rigidbody2D rigidbody2D = component;
			if (!flag12)
			{
				Rigidbody2D rigidbody2D2 = gameObject.AddComponent<Rigidbody2D>();
				bone = (Bone)0;
				rigidbody2D = rigidbody2D2;
			}
			bool flag13 = (object)rigidbody2D == null;
			value = null;
			if (!flag13)
			{
				rigidbody2D.gravityScale = gravityScale;
				bool flag14 = b.Children == null;
				bone = null;
				value = null;
				if (!flag14)
				{
					ExposedList<Bone>.Enumerator enumerator2 = b.Children.GetEnumerator();
					while (enumerator.MoveNext())
					{
						RecursivelyCreateBoneProxies(null);
					}
					enumerator.Dispose();
					return;
				}
			}
			goto IL_0583;
			IL_0583:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)bone == 1)
			{
				((Dictionary<Bone, Transform>)(object)ex).Add(bone, value);
				Dictionary<Bone, Transform> dictionary = default(Dictionary<Bone, Transform>);
				dictionary.Add(bone, value);
				enumerator.Dispose();
				if (dictionary != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((ExposedList<Bone>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x151BE38", Offset = "0x151BE38", Length = "0x57C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv48 = Il2CppMethodInfo;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv244 = Il2CppMethodInfo;\n\tv245 = \"il2cpp_codegen_initialize_runtime_metadata\"(v244, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv248 = Il2CppMethodInfo;\n\tv249 = \"il2cpp_codegen_initialize_runtime_metadata\"(v248, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv270 = Il2CppMethodInfo;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv293 = Il2CppMethodInfo;\n\tv294 = \"il2cpp_codegen_initialize_runtime_metadata\"(v293, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv384 = Il2CppMethodInfo;\n\tv385 = \"il2cpp_codegen_initialize_runtime_metadata\"(v384, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv393 = Spine.Unity.Examples.SkeletonRagdoll2D;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v393, animatedSkeleton, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv68 = 1;\n\t*([1A37A9A]) = v68;\nL_003A:\n\tv73 = this.skeleton;\n\tv74 = this.skeleton == 0;\n\tif (v74) goto L_01D9;\n\tv83 = v73.scaleX < 0;\n\tv91 = Spine.Skeleton::get_ScaleY(this.skeleton);\n\tv217 = v91 < 0;\n\tv236 = this.boneTable == 0;\n\tif (v236) goto L_01D9;\n\tv178 = v83 ^ v217;\n\tv176 = v83 | v217;\n\tv257 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::GetEnumerator(this.boneTable);\nL_0074:\n\tv377 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v173 @ stack_-F8_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv387 = v377 == 0;\n\tif (v387) goto L_01B2;\n\tv399 = this.<StartingBone>k__BackingField == v274;\n\tif (v399) goto L_008E;\n\tv579 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::get_Item(this.boneTable, *([v274 @ stack_-E8+20]));\n\tgoto L_0092;\nL_008E:\n\tv573 = this.ragdollRoot;\nL_0092:\n\tv584 = this.<StartingBone>k__BackingField - v274;\n\tv586 = v584 == 0;\n\tv592 = ~this.oldRagdollBehaviour;\n\tv593 = v586 & v592;\n\tv595 = v593 == 0;\n\tif (v595) goto L_00E0;\n\tv772 = Spine.Skeleton::get_RootBone(this.skeleton);\n\tv761 = v772 == v274;\n\tif (v761) goto L_00E0;\n\tv776 = *([v274 @ stack_-E8+20]);\n\t// 188 MakeStruct v786 @ AGG152000C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v776 @ X8_v37+74], [v776 @ X8_v37+80], 0\n\tUnityEngine.Transform::set_localPosition(this.ragdollRoot, v786);\n\tv791 = *([v274 @ stack_-E8+20]);\n\tv1157 = *([v791 @ X9_v9+20]);\n\tv1153 = *([v791 @ X9_v9+54]);\n\tv1150 = *([v791 @ X9_v9+20]) == 0;\n\tif (v1150) goto L_00CD;\nL_00C5:\n\t;\n\tv1157 = *([v1157 @ X8_v40+20]);\n\tv1153 = v1153 + *([v1157 @ X8_v40+54]);\n\tv1159 = v1157 == 0;\n\tv1156 = ~v1159;\n\tif (v1156) goto L_00C5;\nL_00CD:\n\tv1164 = v1161 * 0.017453292f;\n\t// 209 MakeStruct v783 @ AGG152004C_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, 0, v1164 @ V2_v29 (System.Single)\n\tv803 = UnityEngine.Quaternion::Internal_FromEulerRad(v783);\n\tUnityEngine.Transform::set_localRotation(this.ragdollRoot, v803);\nL_00E0:\n\tv853 = UnityEngine.Transform::get_position(v573);\n\tv937 = UnityEngine.Transform::get_rotation(v573);\n\tUnityEngine.Transform::set_position(v961.parentSpaceHelper, v853);\n\tUnityEngine.Transform::set_rotation(v1087.parentSpaceHelper, v937);\n\tv1138 = UnityEngine.Transform::get_localScale(v573);\n\tUnityEngine.Transform::set_localScale(v1142.parentSpaceHelper, v1138);\n\tv1169 = UnityEngine.Transform::get_position(v394);\n\tv1026 = UnityEngine.Transform::get_right(v394);\n\tv1122 = UnityEngine.Transform::InverseTransformDirection(v1032.parentSpaceHelper, v1026);\n\tv1178 = UnityEngine.Transform::InverseTransformPoint(v1128.parentSpaceHelper, v1169);\n\tv369 = 0x1854F00(v1128.parentSpaceHelper, 0, Il2CppMethodInfo, v52, v53, v54, v55, v56, v1122.y, v1122, v1178.z, v937.w, *([v274 @ stack_-E8+38]), v100, v96, 0);\n\tv1215 = v1122.y * 57.29578f;\n\tv1187 = v176 == 0;\n\tif (v1187) goto L_018B;\n\tv1192 = this.<StartingBone>k__BackingField == v274;\n\tif (v1192) goto L_0157;\n\tv1217 = ~v178;\n\tif (v1217) goto L_018B;\n\tv1215 = -v1215;\n\tv318 = -v1178.y;\n\tgoto L_018B;\nL_0157:\n\tv1220 = -v1178.y;\n\tv1230 = v91 >= 0;\n\tif (v1230) goto L_FFFFFFFF;\n\tgoto L_0168;\nL_0168:\n\tv1202 = -v1215;\n\tv1245 = v178 == 0;\n\tv1250 = ~v1245;\n\tv1198 = ~v1250;\n\tif (v1198) goto L_0182;\n\tgoto L_0182;\nL_0182:\n\tv1197 = v73.scaleX >= 0;\n\tif (v1197) goto L_018B;\n\tv320 = -v1178;\n\tv1215 = v1215 + 0x43340000;\nL_018B:\n\t;\n\tv102 = *([v274 @ stack_-E8+38]);\n\tv359 = this.mix < 0;\n\tv1255 = UnityEngine.Mathf::Min(this.mix, 1f);\n\tv1238 = v320 - *([v274 @ stack_-E8+30]);\n\tv1239 = v318 - *([v274 @ stack_-E8+34]);\n\tv1240 = v1215 - *([v274 @ stack_-E8+38]);\n\tv296 = ~v359;\n\tv302 = ~v296;\n\tif (v302) goto L_FFFFFFFF;\n\tgoto L_01A4;\nL_01A4:\n\tv100 = v1238 * v1255;\n\tv96 = v1239 * v1255;\n\tv1256 = v1255 * v1240;\n\tv345 = *([v274 @ stack_-E8+30]) + v100;\n\tv343 = *([v274 @ stack_-E8+34]) + v96;\n\tv367 = *([v274 @ stack_-E8+38]) + v1256;\n\t*([v274 @ stack_-E8+30]) = v345;\n\t*([v274 @ stack_-E8+34]) = v343;\n\t*([v274 @ stack_-E8+38]) = v367;\n\tgoto L_0074;\nL_01B2:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v173 @ stack_-F8_v3 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\nL_01C8:\n\treturn;\n\tv1134 = new System.NullReferenceException();\n\tv882 = new System.NullReferenceException();\n\tv887 = new System.NullReferenceException();\n\tv962 = new System.NullReferenceException();\n\tv1033 = new System.NullReferenceException();\n\tv1085 = new System.NullReferenceException();\n\tv1129 = new System.NullReferenceException();\n\tv722 = new System.NullReferenceException();\n\tv727 = new System.NullReferenceException();\n\tv567 = new System.NullReferenceException();\n\tv572 = new System.NullReferenceException();\n\tv777 = new System.NullReferenceException();\n\tv850 = new System.NullReferenceException();\n\tv931 = new System.NullReferenceException();\n\tv1001 = new System.NullReferenceException();\n\tv232 = new System.NullReferenceException();\nL_01D9:\n\tv242 = new System.NullReferenceException();\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\n\tgoto L_0203;\nL_0203:\n\tv268 = v227 != 1;\n\tif (v268) goto L_0213;\n\tv280 = 0x1854E70(v242, v227, v150, v52, v53, v54, v55, v56, v229, v168, v166, v139, v101, v99, v95, v97);\n\tv378 = 0x1854E80(v280, v227, v150, v52, v53, v54, v55, v56, v229, v168, v166, v139, v101, v99, v95, v97);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v161 @ stack_-D0_v2 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tv286 = *([v280 @ X0_v14]) == 0;\n\tif (v286) goto L_01C8;\n\tthrow System.OutOfMemoryException;\nL_0213:\n\tgoto L_0219;\n\tX19 = X0;\nL_0219:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v161 @ stack_-D0_v2 (System.Collections.Generic.Dictionary`2<System.Object, System.Object>+Enumerator<System.Object, System.Object>));\n\tgoto L_0220;\n\tv409 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>+Enumerator<Spine.Bone, UnityEngin\n// ... truncated")]
		private unsafe void UpdateSpineSkeleton(ISkeletonAnimation animatedSkeleton)
		{
			//IL_069e: Expected O, but got I
			//IL_00fe: Expected O, but got I
			//IL_0159: Expected O, but got I
			//IL_0175: Expected F4, but got I
			//IL_018a: Expected F4, but got I
			//IL_01b7: Expected O, but got I
			//IL_01cc: Expected O, but got I
			//IL_01dc: Expected O, but got I
			//IL_0203: Expected O, but got I
			//IL_0222: Expected O, but got I
			//IL_0238: Expected O, but got I
			//IL_04d0: Expected O, but got I
			//IL_04a4: Unsupported input type for neg.
			//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a9: Expected O, but got Unknown
			Skeleton skeleton = this.skeleton;
			bool flag = this.skeleton == null;
			float num2 = default(float);
			float num = num2;
			float num4 = default(float);
			float num3 = num4;
			float num6 = default(float);
			float num5 = num6;
			object obj2 = default(object);
			object obj = obj2;
			IntPtr intPtr2 = default(IntPtr);
			IntPtr intPtr = intPtr2;
			Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
			ISkeletonAnimation skeletonAnimation = null;
			float num8 = default(float);
			float num7 = num8;
			if (!flag)
			{
				bool flag2 = skeleton.ScaleX < 0f;
				num8 = this.skeleton.ScaleY;
				bool flag3 = num8 < 0f;
				bool flag4 = boneTable == null;
				num = num2;
				num3 = num4;
				num5 = num6;
				obj = obj2;
				IntPtr intPtr3 = default(IntPtr);
				intPtr = intPtr3;
				Dictionary<object, object>.Enumerator enumerator2 = default(Dictionary<object, object>.Enumerator);
				enumerator = enumerator2;
				ISkeletonAnimation skeletonAnimation2 = default(ISkeletonAnimation);
				skeletonAnimation = skeletonAnimation2;
				float num9 = default(float);
				num7 = num9;
				if (!flag4)
				{
					bool flag5 = flag2 ^ flag3;
					bool flag6 = flag2 || flag3;
					Dictionary<Bone, Transform>.Enumerator enumerator3 = boneTable.GetEnumerator();
					object obj3 = default(object);
					Vector3 localPosition = default(Vector3);
					Vector3 vector = default(Vector3);
					Transform transform3 = default(Transform);
					while (enumerator2.MoveNext())
					{
						Transform transform2;
						if (StartingBone != obj3)
						{
							Dictionary<Bone, Transform> dictionary = boneTable;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
							Transform transform = dictionary[(Bone)0];
							transform2 = transform;
						}
						else
						{
							transform2 = ragdollRoot;
						}
						object obj4 = (nint)StartingBone - (nint)obj3;
						bool flag7 = obj4 == null;
						int num10 = ((!oldRagdollBehaviour) ? 1 : 0);
						if (((flag7 ? 1u : 0u) & (uint)num10) != 0)
						{
							Bone rootBone = this.skeleton.RootBone;
							if (rootBone != obj3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
								object obj5 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ X8_v37+74]");
								localPosition.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v776 @ X8_v37+80]");
								localPosition.y = 0f;
								localPosition.z = 0f;
								ragdollRoot.localPosition = localPosition;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+20]");
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X9_v9+20]");
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X9_v9+54]");
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X9_v9+20]");
								bool flag8 = (nint)0 == 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v791 @ X9_v9+54]");
								object obj9 = 0;
								if (!flag8)
								{
									bool flag10;
									do
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ X8_v40+20]");
										obj7 = 0;
										nint num11 = (nint)obj8;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1157 @ X8_v40+54]");
										obj8 = num11 + 0;
										bool flag9 = obj7 == null;
										flag10 = !flag9;
										obj9 = obj8;
									}
									while (flag10);
								}
								float z = (float)obj9 * ((float)Math.PI / 180f);
								vector.x = 0f;
								vector.y = 0f;
								vector.z = z;
								Quaternion localRotation = Quaternion.Euler(vector * 57.29578f);
								ragdollRoot.localRotation = localRotation;
							}
						}
						Vector3 position = transform2.position;
						Quaternion rotation = transform2.rotation;
						parentSpaceHelper.position = position;
						parentSpaceHelper.rotation = rotation;
						Vector3 localScale = transform2.localScale;
						parentSpaceHelper.localScale = localScale;
						Vector3 position2 = transform3.position;
						Vector3 right = transform3.right;
						Vector3 vector2 = parentSpaceHelper.InverseTransformDirection(right);
						Vector3 vector3 = parentSpaceHelper.InverseTransformPoint(position2);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F00 (native atan2f)");
						float num12 = vector2.y * 57.29578f;
						bool flag11 = !flag6;
						float num13 = vector3.y;
						Vector3 vector4 = vector3;
						if (!flag11)
						{
							if (StartingBone != obj3)
							{
								bool flag12 = !flag5;
								num13 = vector3.y;
								vector4 = vector3;
								if (!flag12)
								{
									num12 = 0f - num12;
									num13 = 0f - vector3.y;
									vector4 = vector3;
								}
							}
							else
							{
								float num14 = 0f - vector3.y;
								num13 = ((!(num8 < 0f)) ? vector3.y : num14);
								float num15 = 0f - num12;
								if (flag5)
								{
									num12 = num15;
								}
								bool flag13 = !(skeleton.ScaleX < 0f);
								vector4 = vector3;
								if (!flag13)
								{
									vector4 = 0 - vector3;
									num12 += 180f;
								}
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						obj2 = 0;
						bool flag14 = mix < 0f;
						float num16 = Mathf.Min(mix, 1f);
						float num17 = vector4.x;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+30]");
						float num18 = num17 - 0f;
						float num19 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+34]");
						float num20 = num19 - 0f;
						float num21 = num12;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						float num22 = num21 - 0f;
						if (flag14)
						{
							num16 = 0f;
						}
						num6 = num18 * num16;
						num2 = num20 * num16;
						float num23 = num16 * num22;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+30]");
						float num24 = 0f + num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+34]");
						float num25 = 0f + num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ stack_-E8+38]");
						float num26 = 0f + num23;
					}
					enumerator2.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)skeletonAnimation == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj10 = default(object);
				if (obj10 != null)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((Dictionary<Bone, Transform>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x151C484", Offset = "0x151C484", Length = "0x520")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0056;\n\tv44 = Spine.BoundingBoxAttachment;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv81 = Il2CppMethodInfo;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv295 = Il2CppMethodInfo;\n\tv296 = \"il2cpp_codegen_initialize_runtime_metadata\"(v295, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv372 = Il2CppMethodInfo;\n\tv373 = \"il2cpp_codegen_initialize_runtime_metadata\"(v372, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv377 = Il2CppMethodInfo;\n\tv378 = \"il2cpp_codegen_initialize_runtime_metadata\"(v377, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv403 = Il2CppMethodInfo;\n\tv404 = \"il2cpp_codegen_initialize_runtime_metadata\"(v403, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv483 = Il2CppMethodInfo;\n\tv484 = \"il2cpp_codegen_initialize_runtime_metadata\"(v483, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv568 = Il2CppMethodInfo;\n\tv569 = \"il2cpp_codegen_initialize_runtime_metadata\"(v568, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv620 = Il2CppMethodInfo;\n\tv621 = \"il2cpp_codegen_initialize_runtime_metadata\"(v620, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv667 = Il2CppMethodInfo;\n\tv668 = \"il2cpp_codegen_initialize_runtime_metadata\"(v667, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv728 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>;\n\tv729 = \"il2cpp_codegen_initialize_runtime_metadata\"(v728, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv774 = System.Collections.Generic.List`1<UnityEngine.Collider2D>;\n\tv775 = \"il2cpp_codegen_initialize_runtime_metadata\"(v774, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv779 = \"ragdoll\";\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v779, go, skeleton, methodInfo, v47, v48, v49, v50, gravityScale, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A37A9B]) = v61;\nL_0056:\n\tv70 = new System.Collections.Generic.List`1<UnityEngine.Collider2D>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider2D>::.ctor(v70);\n\tv190 = skeleton.skin;\n\tv84 = skeleton.skin == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_006A;\n\tv181 = skeleton.data;\n\tv190 = v181.defaultSkin;\nL_006A:\n\tv201 = new System.Collections.Generic.List`1<Spine.Skin+SkinEntry>();\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::.ctor(v201);\n\tv388 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(skeleton.slots);\nL_0084:\n\tv509 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v387 @ stack_-F0_v9 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv571 = v509 == 0;\n\tif (v571) goto L_015C;\n\tv358 = v407 == 0;\n\tif (v358) goto L_016E;\n\tv487 = v407.bone != b;\n\tif (v487) goto L_0084;\n\tv659 = Spine.ExposedList`1<Spine.Slot>::IndexOf(skeleton.slots, v407);\n\tSpine.Skin::GetAttachments(v190, v659, v201);\n\tv785 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>::GetEnumerator(v201);\nL_00B7:\n\tv816 = System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::MoveNext(&v261 @ stack_-F0_v12 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv829 = v816 == 0;\n\tif (v829) goto L_011B;\n\tv820 = v786 == 0;\n\tif (v820) goto L_00B7;\n\tgoto L_FFFFFFFF;\n\tv235 = v235_asT == 0;\n\tif (v235) goto L_00B7;\n\tv279 = v837 == 0;\n\tif (v279) goto L_0135;\n\tv839 = System.String::ToLower(v837);\n\tv280 = v839 == 0;\n\tif (v280) goto L_0137;\n\tv817 = System.String::Contains(v839, \"ragdoll\");\n\tv821 = v817 == 0;\n\tif (v821) goto L_00B7;\n\tv847 = Spine.Unity.SkeletonUtility::AddBoundingBoxAsComponent(v786, v407, go, 0);\n\tv282 = v70 == 0;\n\tif (v282) goto L_013B;\n\tv286 = v70._items;\n\tv210 = v70._version + 1;\n\tv70._version = v210;\n\tv281 = v70._items == 0;\n\tif (v281) goto L_0139;\n\tv789 = v70._size;\n\tv851 = v70._size < v286.Length;\n\tv812 = ~v851;\n\tif (v812) goto L_0113;\n\tv792 = v70._size + 1;\n\tv70._size = v792;\n\tv286[v789 @ X10_v15 (System.Int32)] = v847;\n\tgoto L_00B7;\nL_0113:\n\tSystem.Collections.Generic.List`1<UnityEngine.Collider2D>::AddWithResize(v70, v847);\n\tgoto L_00B7;\nL_011B:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v261 @ stack_-F0_v12 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tgoto L_017C;\n\tgoto L_012C;\n\tgoto L_015C;\nL_012C:\n\tv842 = v288 & 1;\n\tv512 = v842 == 0;\n\tif (v512) goto L_0084;\n\tv510 = Spine.Unity.SkeletonUtility::AddBoneRigidbody2D(go, 0, gravityScale);\n\tgoto L_0084;\nL_0135:\n\tv273 = new System.NullReferenceException();\n\tgoto L_0183;\nL_0137:\n\tv273 = new System.NullReferenceException();\n\tgoto L_0183;\nL_0139:\n\tv273 = new System.NullReferenceException();\n\tgoto L_0183;\nL_013B:\n\tv273 = new System.NullReferenceException();\n\tgoto L_0183;\n\tgoto L_013F;\n\tgoto L_013F;\nL_013F:\n\tX25 = X0;\n\tX19 = 1;\n\tgoto L_0147;\n\tgoto L_0146;\n\tgoto L_0146;\n\tgoto L_0146;\n\tgoto L_0146;\nL_0146:\n\tX25 = X0;\nL_0147:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_016F;\n\tX0 = X25;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX26 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX25 = 0;\n\tgoto L_011B;\nL_015C:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v387 @ stack_-F0_v9 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_016D:\n\treturn v709;\nL_016E:\n\tthrow System.NullReferenceException;\nL_016F:\n\t;\nL_0175:\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>::Dispose(&v422 @ stack_-C0_v9 (System.Collections.Generic.List`1<Spine.Skin+SkinEntry>+Enumerator<Spine.Skin+SkinEntry>));\n\tv375 = v308 == 0;\n\tif (v375) goto L_0199;\n\tthrow System.OutOfMemoryException;\nL_017C:\n\tv468 = new System.OutOfMemoryException();\n\tv561 = new System.NullReferenceException();\n\tv614 = new System.NullReferenceException();\n\tv171 = new System.NullReferenceException();\n\tv273 = new System.NullReferenceException();\nL_0183:\n\tgoto L_0175;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\n\tgoto L_018E;\nL_018E:\n\tX25 = X0;\nL_0199:\n\tv401 = v269 != 1;\n\tif (v401) goto L_01A9;\n\tv470 = 0x1854E70(v273, v269, v322, v320, v298, v48, v49, v50, v345, v318, v316, v53, v54, v55, v56, v57);\n\tv562 = 0x1854E80(v470, v269, v322, v320, v298, v48, v49, v50, v345, v318, v316, v53, v54, v55, v56, v57);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v448 @ stack_-90_v9 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv476 = *([v470 @ X0_v17]) == 0;\n\tif (v476) goto L_016D;\n\tthrow System.OutOfMemoryException;\nL_01A9:\n\tgoto L_01AF;\n\tX25 = X0;\nL_01AF:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v448 @ stack_-90_v9 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_01B6;\n\tv662 = Spine.Expose\n// ... truncated")]
		private unsafe static List<Collider2D> AttachBoundingBoxRagdollColliders(Bone b, GameObject go, Skeleton skeleton, float gravityScale)
		{
			//IL_041e: Expected I, but got O
			//IL_04a1: Expected O, but got I4
			//IL_04c6: Expected I, but got O
			//IL_04e6: Expected I, but got O
			//IL_043d: Expected O, but got I4
			//IL_0462: Expected I, but got O
			//IL_0482: Expected I, but got O
			//IL_030f: Expected O, but got I4
			//IL_031e: Expected O, but got I
			//IL_02da: Expected O, but got I4
			List<Collider2D> list = new List<Collider2D>();
			Skin skin = skeleton.Skin;
			if (skeleton.Skin == null)
			{
				SkeletonData data = skeleton.Data;
				skin = data.DefaultSkin;
			}
			List<Skin.SkinEntry> list2 = new List<Skin.SkinEntry>();
			ExposedList<Slot>.Enumerator enumerator = skeleton.Slots.GetEnumerator();
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			Slot slot = default(Slot);
			List<Skin.SkinEntry>.Enumerator enumerator4 = default(List<Skin.SkinEntry>.Enumerator);
			BoundingBoxAttachment boundingBoxAttachment = default(BoundingBoxAttachment);
			string text = default(string);
			ExposedList<object>.Enumerator enumerator6;
			object obj2 = default(object);
			while (true)
			{
				List<Collider2D> result;
				if (enumerator2.MoveNext())
				{
					if (slot == null)
					{
						throw new NullReferenceException();
					}
					if (slot.Bone != b)
					{
						continue;
					}
					int slotIndex = skeleton.Slots.IndexOf(slot);
					skin.GetAttachments(slotIndex, list2);
					List<Skin.SkinEntry>.Enumerator enumerator3 = list2.GetEnumerator();
					bool flag = false;
					Skeleton skeleton2 = (Skeleton)(object)list2;
					int num = 0;
					List<Collider2D> list3;
					BoundingBoxAttachment boundingBoxAttachment3;
					List<Skin.SkinEntry>.Enumerator enumerator5;
					nint num3;
					while (true)
					{
						BoundingBoxAttachment boundingBoxAttachment4;
						Slot slot2;
						nint num2;
						List<Skin.SkinEntry>.Enumerator enumerator7;
						NullReferenceException ex;
						if (enumerator4.MoveNext())
						{
							if (boundingBoxAttachment == null)
							{
								continue;
							}
							BoundingBoxAttachment boundingBoxAttachment2 = boundingBoxAttachment as BoundingBoxAttachment;
							if (boundingBoxAttachment2 == null)
							{
								continue;
							}
							if (text != null)
							{
								string text2 = text.ToLower();
								if (text2 != null)
								{
									bool flag2 = text2.Contains("ragdoll");
									bool flag3 = !flag2;
									skeleton2 = null;
									if (!flag3)
									{
										PolygonCollider2D polygonCollider2D = SkeletonUtility.AddBoundingBoxAsComponent(boundingBoxAttachment, slot, go, isTrigger: false);
										if (list == null)
										{
											ex = new NullReferenceException();
											list3 = list;
											object obj = 0;
											boundingBoxAttachment3 = boundingBoxAttachment;
											enumerator5 = enumerator4;
											boundingBoxAttachment4 = boundingBoxAttachment;
											slot2 = slot;
											num2 = unchecked((nint)null);
											skeleton2 = (Skeleton)(object)go;
											enumerator6 = enumerator2;
											enumerator7 = enumerator4;
											num3 = (nint)polygonCollider2D;
											break;
										}
										Collider2D[] items = list._items;
										int version = list._version + 1;
										list._version = version;
										if (list._items == null)
										{
											ex = new NullReferenceException();
											list3 = list;
											object obj = 0;
											boundingBoxAttachment3 = boundingBoxAttachment;
											enumerator5 = enumerator4;
											boundingBoxAttachment4 = boundingBoxAttachment;
											slot2 = slot;
											num2 = unchecked((nint)null);
											skeleton2 = (Skeleton)(object)go;
											enumerator6 = enumerator2;
											enumerator7 = enumerator4;
											num3 = (nint)polygonCollider2D;
											break;
										}
										int count = list.Count;
										if (list.Count < items.Length)
										{
											int size = list.Count + 1;
											list._size = size;
											items[count] = polygonCollider2D;
											object obj = 0;
											flag = false;
											skeleton2 = (Skeleton)(object)go;
											num = 1;
										}
										else
										{
											list.Add(polygonCollider2D);
											object obj = 0;
											flag = false;
											skeleton2 = (Skeleton)0;
											num = 1;
										}
									}
									continue;
								}
								ex = new NullReferenceException();
								list3 = list;
								boundingBoxAttachment3 = boundingBoxAttachment;
								enumerator5 = enumerator4;
								boundingBoxAttachment4 = boundingBoxAttachment;
								slot2 = slot;
								num2 = (flag ? 1 : 0);
								enumerator6 = enumerator2;
								enumerator7 = enumerator4;
								num3 = unchecked((nint)null);
								break;
							}
							ex = new NullReferenceException();
							list3 = list;
							boundingBoxAttachment3 = boundingBoxAttachment;
							enumerator5 = enumerator4;
							boundingBoxAttachment4 = boundingBoxAttachment;
							slot2 = slot;
							num2 = (flag ? 1 : 0);
							enumerator6 = enumerator2;
							enumerator7 = enumerator4;
							num3 = 0;
							break;
						}
						enumerator4.Dispose();
						list3 = list;
						boundingBoxAttachment3 = null;
						enumerator5 = enumerator4;
						boundingBoxAttachment4 = boundingBoxAttachment;
						slot2 = slot;
						num2 = (flag ? 1 : 0);
						enumerator6 = enumerator2;
						enumerator7 = enumerator4;
						num3 = 0;
						OutOfMemoryException ex2 = new OutOfMemoryException();
						NullReferenceException ex3 = new NullReferenceException();
						NullReferenceException ex4 = new NullReferenceException();
						NullReferenceException ex5 = new NullReferenceException();
						ex = new NullReferenceException();
						break;
					}
					enumerator5.Dispose();
					if (boundingBoxAttachment3 != null)
					{
						throw new OutOfMemoryException();
					}
					if (num3 != 1)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
					enumerator6.Dispose();
					bool flag4 = obj2 == null;
					result = list3;
					if (!flag4)
					{
						throw new OutOfMemoryException();
					}
				}
				else
				{
					enumerator2.Dispose();
					result = list;
				}
				return result;
			}
			enumerator6.Dispose();
			OutOfMemoryException ex6 = new OutOfMemoryException();
			((ExposedList<Slot>.Enumerator*)ex6)->Dispose();
			List<Collider2D> result2 = default(List<Collider2D>);
			return result2;
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x151BD8C", Offset = "0x151BD8C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = b.parent;\n\tv25 = b.arotation;\n\tv6 = b.parent == 0;\n\tif (v6) goto L_0010;\nL_0009:\n\tv27 = v27.parent;\n\tv25 = v25 + v27.arotation;\n\tv31 = v27 == 0;\n\tv30 = ~v31;\n\tif (v30) goto L_0009;\nL_0010:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float GetPropagatedRotation(Bone b)
		{
			Bone parent = b.Parent;
			float num = b.AppliedRotation;
			bool flag = b.Parent == null;
			float result = b.AppliedRotation;
			if (!flag)
			{
				bool flag3;
				do
				{
					parent = parent.Parent;
					num += parent.AppliedRotation;
					bool flag2 = parent == null;
					flag3 = !flag2;
					result = num;
				}
				while (flag3);
			}
			return result;
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x151C9A4", Offset = "0x151C9A4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = flipX == 0;\n\tv8 = ~v3;\n\tv9 = ~v8;\n\tif (v9) goto L_FFFFFFFF;\n\tgoto L_0010;\nL_0010:\n\tv16 = flipY == 0;\n\tv19 = ~v16;\n\tv20 = ~v19;\n\tif (v20) goto L_001B;\n\tgoto L_001B;\nL_001B:\n\treturn returnVal1;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Vector3 FlipScale(bool flipX, bool flipY)
		{
			//IL_004a: Expected O, but got F4
			//IL_003c: Expected O, but got F4
			Vector3 result = ((!flipX) ? ((Vector3)1f) : ((Vector3)(-1f)));
			if (flipY)
			{
			}
			return result;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x151C9C4", Offset = "0x151C9C4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv75 = System.Collections.Generic.List`1<System.String>;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv80 = \"\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37A9C]) = v54;\nL_002C:\n\tthis.startingBoneName = \"\";\n\tv57 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v57);\n\tthis.stopBoneNames = v57;\n\tthis.disableIK = 1;\n\tthis.massFalloffFactor = 0.4f;\n\tthis.mix = 1f;\n\tthis.gravityScale = *([408050]);\n\tthis.oldRagdollBehaviour = 1;\n\tv73 = new System.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Bone, UnityEngine.Transform>::.ctor(v73);\n\tthis.boneTable = v73;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRagdoll2D()
		{
			//IL_006d: Expected F4, but got I
			base._002Ector();
			startingBoneName = "";
			List<string> list = new List<string>();
			stopBoneNames = list;
			disableIK = true;
			massFalloffFactor = 0.4f;
			mix = 1f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [408050]");
			gravityScale = 0f;
			oldRagdollBehaviour = true;
			Dictionary<Bone, Transform> dictionary = new Dictionary<Bone, Transform>();
			boneTable = dictionary;
		}
	}
}
