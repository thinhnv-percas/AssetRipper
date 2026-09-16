using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Spine.Unity
{
	[ExecuteAlways]
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	[DisallowMultipleComponent]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderer-Component")]
	[Token(Token = "0x2000087")]
	public class SkeletonRenderer : MonoBehaviour, ISkeletonComponent, IHasSkeletonDataAsset
	{
		[Serializable]
		[Token(Token = "0x2000088")]
		public class SpriteMaskInteractionMaterials
		{
			[Token(Token = "0x400038B")]
			[FieldOffset(Offset = "0x10")]
			public Material[] materialsMaskDisabled;

			[Token(Token = "0x400038C")]
			[FieldOffset(Offset = "0x18")]
			public Material[] materialsInsideMask;

			[Token(Token = "0x400038D")]
			[FieldOffset(Offset = "0x20")]
			public Material[] materialsOutsideMask;

			[Token(Token = "0x170001A8")]
			public bool AnyMaterialCreated
			{
				[Token(Token = "0x60005E1")]
				[Address(RVA = "0x1561CA0", Offset = "0x1561CA0", Length = "0x4C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.materialsMaskDisabled;\n\tv6 = v2.Length == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_FFFFFFFF;\n\tv12 = this.materialsInsideMask;\n\tv31 = v12.Length == 0;\n\tif (v31) goto L_0013;\nL_0012:\n\treturn returnVal2;\nL_0013:\n\tv13 = this.materialsOutsideMask;\n\tv52 = v13.Length == 0;\n\tv37 = ~v52;\n\tgoto L_0012;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Material[] array = materialsMaskDisabled;
					if (array.Length == 0)
					{
						Material[] array2 = materialsInsideMask;
						if (array2.Length == 0)
						{
							Material[] array3 = materialsOutsideMask;
							bool flag = array3.Length == 0;
							return !flag;
						}
					}
					return true;
				}
			}

			[Token(Token = "0x60005E2")]
			[Address(RVA = "0x1561CEC", Offset = "0x1561CEC", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = UnityEngine.Material[];\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C6F]) = v37;\nL_0015:\n\t// 21 NewArr v40 @ X0_v3 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.materialsMaskDisabled = v40;\n\t// 25 NewArr v43 @ X0_v5 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.materialsInsideMask = v43;\n\t// 29 NewArr v46 @ X0_v7 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.materialsOutsideMask = v46;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SpriteMaskInteractionMaterials()
			{
				Material[] array = new Material[0];
				materialsMaskDisabled = array;
				Material[] array2 = new Material[0];
				materialsInsideMask = array2;
				Material[] array3 = new Material[0];
				materialsOutsideMask = array3;
			}
		}

		[Token(Token = "0x2000089")]
		public delegate void InstructionDelegate(SkeletonRendererInstruction instruction);

		[Token(Token = "0x200008A")]
		public delegate void SkeletonRendererDelegate(SkeletonRenderer skeletonRenderer);

		[Token(Token = "0x4000363")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonDataAsset skeletonDataAsset;

		[SpineSkin(null, null, true, false, true)]
		[Token(Token = "0x4000364")]
		[FieldOffset(Offset = "0x28")]
		public string initialSkinName;

		[Token(Token = "0x4000365")]
		[FieldOffset(Offset = "0x30")]
		public bool initialFlipX;

		[Token(Token = "0x4000366")]
		[FieldOffset(Offset = "0x31")]
		public bool initialFlipY;

		[Token(Token = "0x4000367")]
		[FieldOffset(Offset = "0x34")]
		protected UpdateMode updateMode;

		[Token(Token = "0x4000368")]
		[FieldOffset(Offset = "0x38")]
		public UpdateMode updateWhenInvisible;

		[SerializeField]
		[FormerlySerializedAs("submeshSeparators")]
		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x4000369")]
		[FieldOffset(Offset = "0x40")]
		protected string[] separatorSlotNames;

		[NonSerialized]
		[Token(Token = "0x400036A")]
		[FieldOffset(Offset = "0x48")]
		public readonly List<Slot> separatorSlots;

		[Range(-0.1f, 0f)]
		[Token(Token = "0x400036B")]
		[FieldOffset(Offset = "0x50")]
		public float zSpacing;

		[Token(Token = "0x400036C")]
		[FieldOffset(Offset = "0x54")]
		public bool useClipping;

		[Token(Token = "0x400036D")]
		[FieldOffset(Offset = "0x55")]
		public bool immutableTriangles;

		[Token(Token = "0x400036E")]
		[FieldOffset(Offset = "0x56")]
		public bool pmaVertexColors;

		[Token(Token = "0x400036F")]
		[FieldOffset(Offset = "0x57")]
		public bool clearStateOnDisable;

		[Token(Token = "0x4000370")]
		[FieldOffset(Offset = "0x58")]
		public bool tintBlack;

		[Token(Token = "0x4000371")]
		[FieldOffset(Offset = "0x59")]
		public bool singleSubmesh;

		[Token(Token = "0x4000372")]
		[FieldOffset(Offset = "0x5A")]
		public bool fixDrawOrder;

		[FormerlySerializedAs("calculateNormals")]
		[Token(Token = "0x4000373")]
		[FieldOffset(Offset = "0x5B")]
		public bool addNormals;

		[Token(Token = "0x4000374")]
		[FieldOffset(Offset = "0x5C")]
		public bool calculateTangents;

		[Token(Token = "0x4000375")]
		[FieldOffset(Offset = "0x60")]
		public SpriteMaskInteraction maskInteraction;

		[Token(Token = "0x4000376")]
		[FieldOffset(Offset = "0x68")]
		public SpriteMaskInteractionMaterials maskMaterials;

		[Token(Token = "0x4000377")]
		public static readonly int STENCIL_COMP_PARAM_ID;

		[Token(Token = "0x4000378")]
		public const CompareFunction STENCIL_COMP_MASKINTERACTION_NONE = CompareFunction.Always;

		[Token(Token = "0x4000379")]
		public const CompareFunction STENCIL_COMP_MASKINTERACTION_VISIBLE_INSIDE = CompareFunction.LessEqual;

		[Token(Token = "0x400037A")]
		public const CompareFunction STENCIL_COMP_MASKINTERACTION_VISIBLE_OUTSIDE = CompareFunction.Greater;

		[Token(Token = "0x400037B")]
		[FieldOffset(Offset = "0x70")]
		public bool disableRenderingOnOverride;

		[CompilerGenerated]
		[Token(Token = "0x400037C")]
		[FieldOffset(Offset = "0x78")]
		private InstructionDelegate m_generateMeshOverride;

		[CompilerGenerated]
		[Token(Token = "0x400037D")]
		[FieldOffset(Offset = "0x80")]
		private MeshGeneratorDelegate m_OnPostProcessVertices;

		[NonSerialized]
		[Token(Token = "0x400037E")]
		[FieldOffset(Offset = "0x88")]
		private readonly Dictionary<Material, Material> customMaterialOverride;

		[NonSerialized]
		[Token(Token = "0x400037F")]
		[FieldOffset(Offset = "0x90")]
		private readonly Dictionary<Slot, Material> customSlotMaterials;

		[NonSerialized]
		[Token(Token = "0x4000380")]
		[FieldOffset(Offset = "0x98")]
		private readonly SkeletonRendererInstruction currentInstructions;

		[Token(Token = "0x4000381")]
		[FieldOffset(Offset = "0xA0")]
		private readonly MeshGenerator meshGenerator;

		[NonSerialized]
		[Token(Token = "0x4000382")]
		[FieldOffset(Offset = "0xA8")]
		private readonly MeshRendererBuffers rendererBuffers;

		[Token(Token = "0x4000383")]
		[FieldOffset(Offset = "0xB0")]
		private MeshRenderer meshRenderer;

		[Token(Token = "0x4000384")]
		[FieldOffset(Offset = "0xB8")]
		private MeshFilter meshFilter;

		[NonSerialized]
		[Token(Token = "0x4000385")]
		[FieldOffset(Offset = "0xC0")]
		public bool valid;

		[NonSerialized]
		[Token(Token = "0x4000386")]
		[FieldOffset(Offset = "0xC8")]
		public Skeleton skeleton;

		[CompilerGenerated]
		[Token(Token = "0x4000387")]
		[FieldOffset(Offset = "0xD0")]
		private SkeletonRendererDelegate m_OnRebuild;

		[CompilerGenerated]
		[Token(Token = "0x4000388")]
		[FieldOffset(Offset = "0xD8")]
		private SkeletonRendererDelegate m_OnMeshAndMaterialsUpdated;

		[Token(Token = "0x4000389")]
		[FieldOffset(Offset = "0xE0")]
		private MaterialPropertyBlock reusedPropertyBlock;

		[Token(Token = "0x400038A")]
		public static readonly int SUBMESH_DUMMY_PARAM_ID;

		[Token(Token = "0x170001A3")]
		public UpdateMode UpdateMode
		{
			[Token(Token = "0x60005BB")]
			[Address(RVA = "0x1561758", Offset = "0x1561758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.updateMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UpdateMode;
			}
			[Token(Token = "0x60005BC")]
			[Address(RVA = "0x1561760", Offset = "0x1561760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = value;\n\treturn;\n")]
			set
			{
				UpdateMode = value;
			}
		}

		[Token(Token = "0x170001A4")]
		public Dictionary<Material, Material> CustomMaterialOverride
		{
			[Token(Token = "0x60005C3")]
			[Address(RVA = "0x1561A80", Offset = "0x1561A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.customMaterialOverride;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomMaterialOverride;
			}
		}

		[Token(Token = "0x170001A5")]
		public Dictionary<Slot, Material> CustomSlotMaterials
		{
			[Token(Token = "0x60005C4")]
			[Address(RVA = "0x1561A88", Offset = "0x1561A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.customSlotMaterials;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomSlotMaterials;
			}
		}

		[Token(Token = "0x170001A6")]
		public Skeleton Skeleton
		{
			[Token(Token = "0x60005C5")]
			[Address(RVA = "0x1557FA4", Offset = "0x1557FA4", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = Spine.Unity.SkeletonRenderer::Initialize(this, 0);\n\treturn this.skeleton;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Initialize(overwrite: false);
				return skeleton;
			}
		}

		[Token(Token = "0x170001A7")]
		public SkeletonDataAsset SkeletonDataAsset
		{
			[Token(Token = "0x60005CA")]
			[Address(RVA = "0x1561BC8", Offset = "0x1561BC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonDataAsset;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonDataAsset;
			}
		}

		[Token(Token = "0x14000027")]
		private event InstructionDelegate generateMeshOverride
		{
			[CompilerGenerated]
			[Token(Token = "0x60005BD")]
			[Address(RVA = "0x1561768", Offset = "0x1561768", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C5C]) = v38;\nL_0014:\n\tv40 = this + 0x78;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 120;
				Delegate obj2 = this.m_generateMeshOverride;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(InstructionDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005BE")]
			[Address(RVA = "0x1561804", Offset = "0x1561804", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C5D]) = v38;\nL_0014:\n\tv40 = this + 0x78;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+InstructionDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 120;
				Delegate obj2 = this.m_generateMeshOverride;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(InstructionDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000028")]
		public event InstructionDelegate GenerateMeshOverride
		{
			[Token(Token = "0x60005BF")]
			[Address(RVA = "0x15618A0", Offset = "0x15618A0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRenderer::add_generateMeshOverride(this, value);\n\tv9 = ~this.disableRenderingOnOverride;\n\tif (v9) goto L_001E;\n\tv11 = this.generateMeshOverride == 0;\n\tif (v11) goto L_001E;\n\tv21 = Spine.Unity.SkeletonRenderer::Initialize(this, 0);\n\tUnityEngine.Renderer::set_enabled(this.meshRenderer, 0);\n\treturn;\nL_001E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				generateMeshOverride += value;
				if (disableRenderingOnOverride && this.generateMeshOverride != null)
				{
					Initialize(overwrite: false);
					meshRenderer.enabled = false;
				}
			}
			[Token(Token = "0x60005C0")]
			[Address(RVA = "0x15618F4", Offset = "0x15618F4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonRenderer::remove_generateMeshOverride(this, value);\n\tv9 = ~this.disableRenderingOnOverride;\n\tif (v9) goto L_000E;\n\tv11 = this.generateMeshOverride == 0;\n\tif (v11) goto L_0014;\nL_000E:\n\treturn;\nL_0014:\n\tv21 = Spine.Unity.SkeletonRenderer::Initialize(this, 0);\n\tUnityEngine.Renderer::set_enabled(this.meshRenderer, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				generateMeshOverride -= value;
				if (disableRenderingOnOverride && this.generateMeshOverride == null)
				{
					Initialize(overwrite: false);
					meshRenderer.enabled = true;
				}
			}
		}

		[Token(Token = "0x14000029")]
		public event MeshGeneratorDelegate OnPostProcessVertices
		{
			[CompilerGenerated]
			[Token(Token = "0x60005C1")]
			[Address(RVA = "0x1561948", Offset = "0x1561948", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.MeshGeneratorDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C5E]) = v38;\nL_0014:\n\tv40 = this + 0x80;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.MeshGeneratorDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 128;
				Delegate obj2 = this.m_OnPostProcessVertices;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(MeshGeneratorDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005C2")]
			[Address(RVA = "0x15619E4", Offset = "0x15619E4", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.MeshGeneratorDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C5F]) = v38;\nL_0014:\n\tv40 = this + 0x80;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.MeshGeneratorDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 128;
				Delegate obj2 = this.m_OnPostProcessVertices;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(MeshGeneratorDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002A")]
		public event SkeletonRendererDelegate OnRebuild
		{
			[CompilerGenerated]
			[Token(Token = "0x60005C6")]
			[Address(RVA = "0x15545FC", Offset = "0x15545FC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C60]) = v38;\nL_0014:\n\tv40 = this + 0xD0;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 208;
				Delegate obj2 = this.m_OnRebuild;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005C7")]
			[Address(RVA = "0x1554560", Offset = "0x1554560", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C61]) = v38;\nL_0014:\n\tv40 = this + 0xD0;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 208;
				Delegate obj2 = this.m_OnRebuild;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x1400002B")]
		public event SkeletonRendererDelegate OnMeshAndMaterialsUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x60005C8")]
			[Address(RVA = "0x1561A90", Offset = "0x1561A90", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C62]) = v38;\nL_0014:\n\tv40 = this + 0xD8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 216;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60005C9")]
			[Address(RVA = "0x1561B2C", Offset = "0x1561B2C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C63]) = v38;\nL_0014:\n\tv40 = this + 0xD8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 216;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0xCA30D4", Offset = "0xCA30D4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\n\tv33 = 0xB3490C(methodInfo, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv42 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v42, \"New Spine GameObject\");\n\tgoto L_0035;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v55, v50, v48, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0035:\n\treturnVal1 = Spine.Unity.SkeletonRenderer::AddSpineComponent(v42, skeletonDataAsset);\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T NewSpineGameObject<T>(SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			GameObject gameObject = new GameObject("New Spine GameObject");
			return AddSpineComponent<T>(gameObject, skeletonDataAsset);
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0xCA3024", Offset = "0xCA3024", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_001A;\n\tv34 = 0xB3490C(methodInfo, skeletonDataAsset, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_001A:\n\tv44 = UnityEngine.GameObject::AddComponent(gameObject);\n\tgoto L_0028;\n\tv66 = v59;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v66, v43, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0028:\n\tv53 = UnityEngine.Object::op_Inequality(skeletonDataAsset, 0);\n\tv91 = v53 == 0;\n\tif (v91) goto L_003B;\n\tv97 = *([v44 @ X0_v5 (T)]);\n\t*([v44 @ X0_v5 (T)+20]) = skeletonDataAsset;\n\t*([v97 @ X8_v9 (Il2CppClass<T>)+1C8])(v96, v44, 0, *([v97 @ X8_v9 (Il2CppClass<T>)+1D0]), v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003B:\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T AddSpineComponent<T>(GameObject gameObject, SkeletonDataAsset skeletonDataAsset) where T : SkeletonRenderer
		{
			//IL_0063: Expected I, but got O
			T val = gameObject.AddComponent<T>();
			if (skeletonDataAsset != null)
			{
				nint num = (nint)val;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v97 @ X8_v9 (Il2CppClass<T>)+1C8] (should have been resolved before IL gen)");
			}
			return val;
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0x1561BD0", Offset = "0x1561BD0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = methodInfo >> 0x18;\n\tv4 = v2 & 1;\n\tthis.calculateTangents = v4;\n\tv6 = methodInfo & 1;\n\tv7 = methodInfo >> 0x28;\n\tv8 = v7 & 1;\n\tthis.pmaVertexColors = v6;\n\tv9 = this.meshGenerator;\n\tthis.immutableTriangles = v8;\n\tv10 = methodInfo >> 8;\n\tv11 = v10 & 1;\n\tthis.tintBlack = v11;\n\tv12 = settings & 1;\n\tthis.useClipping = v12;\n\tv14 = settings >> 0x20;\n\tthis.zSpacing = v14;\n\tv9.settings = settings;\n\tv9.settings.zSpacing = v14;\n\tv9.settings.pmaVertexColors = methodInfo;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMeshSettings(MeshGenerator.Settings settings)
		{
			//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a6: Expected I4, but got Unknown
			//IL_00be: Expected I4, but got O
			IntPtr intPtr = default(IntPtr);
			int num = (int)((nint)intPtr >> 24);
			int num2 = num & 1;
			calculateTangents = (byte)num2 != 0;
			int num3 = (int)((nint)intPtr & 1);
			int num4 = (int)((nint)intPtr >> 40);
			int num5 = num4 & 1;
			pmaVertexColors = (byte)num3 != 0;
			MeshGenerator meshGenerator = this.meshGenerator;
			immutableTriangles = (byte)num5 != 0;
			int num6 = (int)((nint)intPtr >> 8);
			int num7 = num6 & 1;
			tintBlack = (byte)num7 != 0;
			int num8 = settings & 1;
			useClipping = (byte)num8 != 0;
			int num9 = (object)settings >> 32;
			zSpacing = num9;
			meshGenerator.settings = settings;
			meshGenerator.settings.zSpacing = num9;
			meshGenerator.settings.pmaVertexColors = (byte)(nint)intPtr != 0;
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0x1561C20", Offset = "0x1561C20", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this->klass;\n\tv3 = this->klass->vtable[9];\n\tv4 = this->klass->vtable[9];\n\t// 4 IndirectJump v3 @ X3_v1, this @ X0 (Spine.Unity.SkeletonRenderer), this @ X0 (Spine.Unity.SkeletonRenderer), 0, v4 @ X2_v1, v3 @ X3_v1, v5 @ X4, v6 @ X5, v7 @ X6, v8 @ X7, v9 @ V0, v10 @ V1, v11 @ V2, v12 @ V3, v13 @ V4, v14 @ V5, v15 @ V6, v16 @ V7\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Awake()
		{
			//IL_0005: Expected I, but got O
			//IL_0015: Expected O, but got I
			//IL_0025: Expected O, but got I
			nint num = (nint)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1C8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1D0]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0x1561C30", Offset = "0x1561C30", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.clearStateOnDisable;\n\tif (v2) goto L_000A;\n\tv4 = ~this.valid;\n\tif (v4) goto L_000A;\n\tv7 = this->klass;\n\tv8 = this->klass->vtable[8];\n\tv9 = this->klass->vtable[8];\n\t// 9 IndirectJump v8 @ X2_v1, this @ X0 (Spine.Unity.SkeletonRenderer), this @ X0 (Spine.Unity.SkeletonRenderer), v9 @ X1_v1, v8 @ X2_v1, v10 @ X3, v11 @ X4, v12 @ X5, v13 @ X6, v14 @ X7, v15 @ V0, v16 @ V1, v17 @ V2, v18 @ V3, v19 @ V4, v20 @ V5, v21 @ V6, v22 @ V7\nL_000A:\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			//IL_003b: Expected I, but got O
			//IL_004b: Expected O, but got I
			//IL_005b: Expected O, but got I
			if (clearStateOnDisable && valid)
			{
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v4 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1B8]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v7 @ X8_v4 (Il2CppClass<Spine.Unity.SkeletonRenderer>)+1C0]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v8 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60005D0")]
		[Address(RVA = "0x1561C50", Offset = "0x1561C50", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.MeshRendererBuffers::Dispose(this.rendererBuffers);\n\tthis.valid = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			rendererBuffers.Dispose();
			valid = false;
		}

		[Token(Token = "0x60005D1")]
		[Address(RVA = "0x155A650", Offset = "0x155A650", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = UnityEngine.Object;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C64]) = v42;\nL_001B:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0027;\n\tv53 = v48;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v53, v43, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv59 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0035;\n\tUnityEngine.MeshFilter::set_sharedMesh(v45, 0);\nL_0035:\n\tSpine.Unity.SkeletonRendererInstruction::Clear(this.currentInstructions);\n\tv79 = this.skeleton == 0;\n\tif (v79) goto L_0048;\n\tSpine.Skeleton::SetToSetupPose(this.skeleton);\n\treturn;\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void ClearState()
		{
			MeshFilter component = GetComponent<MeshFilter>();
			if (component != null)
			{
				component.sharedMesh = null;
			}
			currentInstructions.Clear();
			if (skeleton != null)
			{
				skeleton.SetToSetupPose();
			}
		}

		[Token(Token = "0x60005D2")]
		[Address(RVA = "0x1561C78", Offset = "0x1561C78", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.MeshGenerator::EnsureVertexCapacity(this.meshGenerator, minimumVertexCount, 0, 0, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void EnsureMeshGeneratorCapacity(int minimumVertexCount)
		{
			meshGenerator.EnsureVertexCapacity(minimumVertexCount);
		}

		[Token(Token = "0x60005D3")]
		[Address(RVA = "0x155A828", Offset = "0x155A828", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv270 = Il2CppMethodInfo;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv328 = UnityEngine.Object;\n\tv329 = \"il2cpp_codegen_initialize_runtime_metadata\"(v328, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv331 = Spine.Skeleton;\n\tv332 = \"il2cpp_codegen_initialize_runtime_metadata\"(v331, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv334 = \"default\";\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v334, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A37C65]) = v39;\nL_0026:\n\tv41 = ~this.valid;\n\tif (v41) goto L_002F;\n\tv46 = overwrite == 0;\n\tif (v46) goto L_012D;\nL_002F:\n\tSpine.Unity.SkeletonRendererInstruction::Clear(this.currentInstructions);\n\tSpine.Unity.MeshRendererBuffers::Clear(this.rendererBuffers);\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\tthis.skeleton = 0;\n\tthis.valid = 0;\n\tgoto L_0048;\n\tv341 = \"il2cpp_codegen_runtime_class_init\"(v338, v335, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0048:\n\tv113 = UnityEngine.Object::op_Equality(this.skeletonDataAsset, 0);\n\tv345 = v113 == 0;\n\tv117 = ~v345;\n\tif (v117) goto L_012D;\n\tv114 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 0);\n\tv118 = v114 == 0;\n\tif (v118) goto L_012D;\n\tthis.valid = 1;\n\tv351 = UnityEngine.Component::GetComponent(this);\n\tthis.meshFilter = v351;\n\tv230 = UnityEngine.Component::GetComponent(this);\n\tthis.meshRenderer = v230;\n\tSpine.Unity.MeshRendererBuffers::Initialize(this.rendererBuffers);\n\tv231 = new Spine.Skeleton();\n\tSpine.Skeleton::.ctor(v231, v114);\n\tif (this.initialFlipX) goto L_FFFFFFFF;\n\tgoto L_0086;\nL_0086:\n\tv231.scaleX = v159;\n\tif (this.initialFlipY) goto L_FFFFFFFF;\n\tgoto L_0097;\nL_0097:\n\tv231.scaleY = v205;\n\tthis.skeleton = v231;\n\tv379 = System.String::IsNullOrEmpty(this.initialSkinName);\n\tv381 = v379 == 0;\n\tv382 = ~v381;\n\tif (v382) goto L_00B0;\n\tv385 = System.String::Equals(this.initialSkinName, \"default\", 4);\n\tv392 = v385 == 0;\n\tv389 = ~v392;\n\tif (v389) goto L_00B0;\n\tSpine.Skeleton::SetSkin(this.skeleton, this.initialSkinName);\nL_00B0:\n\tv259 = this.separatorSlots;\n\tv152 = v259._version + 1;\n\tv259._size = 0;\n\tv259._version = v152;\n\tv149 = v259._size < 1;\n\tif (v149) goto L_00C8;\n\tSystem.Array::Clear(v259._items, 0, v259._size);\nL_00C8:\n\tv261 = this.separatorSlotNames;\nL_00D8:\n\tv148 = v267 >= v261.Length;\n\tif (v148) goto L_0118;\n\tv251 = this.separatorSlots;\n\tv236 = Spine.Skeleton::FindSlot(this.skeleton, v261[v267 @ X21_v9 (System.Int32)]);\n\tv263 = v251._items;\n\tv140 = v251._version + 1;\n\tv251._version = v140;\n\tv138 = v251._size;\n\tv414 = v251._size < v263.Length;\n\tv199 = ~v414;\n\tif (v199) goto L_010D;\n\tv415 = v251._size + 1;\n\tv251._size = v415;\n\tv263[v138 @ X10_v7 (System.Int32)] = v236;\n\tgoto L_010E;\nL_010D:\n\tSystem.Collections.Generic.List`1<Spine.Slot>::AddWithResize(v251, v236);\nL_010E:\n\tv261 = this.separatorSlotNames;\n\tv267 = v267 + 1;\n\tv423 = this.separatorSlotNames == 0;\n\tv238 = ~v423;\n\tif (v238) goto L_00D8;\n\tthrow System.NullReferenceException;\nL_0118:\n\tv115 = Spine.Unity.SkeletonRenderer::LateUpdate(this);\n\tv119 = this.OnRebuild == 0;\n\tif (v119) goto L_012D;\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::Invoke(this.OnRebuild, this);\nL_012D:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 208 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Initialize(bool overwrite)
		{
			if (valid && !overwrite)
			{
				return;
			}
			currentInstructions.Clear();
			rendererBuffers.Clear();
			meshGenerator.Begin();
			this.skeleton = null;
			valid = false;
			if (skeletonDataAsset == null)
			{
				return;
			}
			SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(quiet: false);
			if (skeletonData == null)
			{
				return;
			}
			valid = true;
			MeshFilter component = GetComponent<MeshFilter>();
			meshFilter = component;
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			meshRenderer = component2;
			rendererBuffers.Initialize();
			Skeleton skeleton = new Skeleton(skeletonData);
			float scaleX = (initialFlipX ? (-1f) : 1f);
			skeleton.ScaleX = scaleX;
			float scaleY = (initialFlipY ? (-1f) : 1f);
			skeleton.ScaleY = scaleY;
			this.skeleton = skeleton;
			if (!string.IsNullOrEmpty(initialSkinName) && !string.Equals(initialSkinName, "default", StringComparison.Ordinal))
			{
				this.skeleton.SetSkin(initialSkinName);
			}
			List<Slot> list = separatorSlots;
			int version = list._version + 1;
			list._size = 0;
			list._version = version;
			if (list.Count >= 1)
			{
				Array.Clear(list._items, 0, list.Count);
			}
			string[] array = separatorSlotNames;
			int num = 0;
			while (num < array.Length)
			{
				List<Slot> list2 = separatorSlots;
				Slot slot = this.skeleton.FindSlot(array[num]);
				Slot[] items = list2._items;
				int version2 = list2._version + 1;
				list2._version = version2;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = slot;
				}
				else
				{
					list2.Add(slot);
				}
				array = separatorSlotNames;
				num++;
				if (separatorSlotNames == null)
				{
					throw new NullReferenceException();
				}
			}
			LateUpdate();
			if (this.OnRebuild != null)
			{
				this.OnRebuild(this);
			}
		}

		[Token(Token = "0x60005D4")]
		[Address(RVA = "0x155ACE8", Offset = "0x155ACE8", Length = "0x5F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Spine.Unity.MeshGenerator;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv256 = UnityEngine.Object;\n\tv257 = \"il2cpp_codegen_initialize_runtime_metadata\"(v256, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv373 = Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v373, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C66]) = v50;\nL_0022:\n\tv52 = ~this.valid;\n\tif (v52) goto L_021A;\n\tv66 = this.updateMode != 3;\n\tif (v66) goto L_021A;\n\tv231 = UnityEngine.Renderer::get_enabled(this.meshRenderer);\n\tv632 = this.generateMeshOverride == 0;\n\tv633 = ~v632;\n\tif (v633) goto L_003C;\n\tv236 = v231 == 0;\n\tif (v236) goto L_021A;\nL_003C:\n\tv243 = this.currentInstructions;\n\tv185 = v243.submeshInstructions;\n\tv554 = Spine.Unity.MeshRendererBuffers::GetNextMesh(this.rendererBuffers);\n\tv640 = ~this.singleSubmesh;\n\tif (v640) goto L_00D8;\n\tv617 = this.skeletonDataAsset;\n\tv618 = v617.atlasAssets;\n\tv666 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v618[0]);\n\tgoto L_0068;\n\tv672 = v619;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v672, v665, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0068:\n\tSpine.Unity.MeshGenerator::GenerateSingleSubmeshInstruction(v243, this.skeleton, v666);\n\tv693 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::get_Count(this.customMaterialOverride);\n\tv517 = v693 < 1;\n\tif (v517) goto L_0087;\n\tgoto L_0086;\n\tv709 = \"il2cpp_codegen_runtime_class_init\"(v699, v692, v445, v443, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0086:\n\tSpine.Unity.MeshGenerator::TryReplaceMaterials(v243.submeshInstructions, this.customMaterialOverride);\nL_0087:\n\tv620 = this.meshGenerator;\n\tv620.settings.useClipping = this.useClipping;\n\tv620.settings.zSpacing = this.zSpacing;\n\tv620.settings.pmaVertexColors = this.pmaVertexColors;\n\tv620.settings.tintBlack = this.tintBlack;\n\tv620.settings.canvasGroupTintBlack = 0;\n\tv620.settings.calculateTangents = this.calculateTangents;\n\tv620.settings.addNormals = this.addNormals;\n\t*([v620 @ X8_v41 (Spine.Unity.MeshGenerator)+13]) = 0;\n\t*([v620 @ X8_v41 (Spine.Unity.MeshGenerator)+11]) = 0;\n\t*([v620 @ X8_v41 (Spine.Unity.MeshGenerator)+1F]) = 0;\n\tv620.settings.immutableTriangles = 0;\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\tv559 = Spine.Unity.SkeletonRendererInstruction::GeometryNotEqual(v243, v554.instructionUsed);\n\tv718 = ~v243.hasActiveClipping;\n\tif (v718) goto L_FFFFFFFF;\n\tv472 = v185.Items;\n\tv41 = *([v472 @ X9_v19 (Spine.Unity.SubmeshInstruction[])+20]);\n\tSpine.Unity.MeshGenerator::AddSubmesh(this.meshGenerator, &v41 @ V2 (Spine.Unity.SubmeshInstruction), v559);\n\tgoto L_015E;\nL_00D8:\n\tgoto L_00DE;\n\tv645 = \"il2cpp_codegen_runtime_class_init\"(v642, v491, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_00DE:\n\tv651 = this.immutableTriangles == 0;\n\tv656 = ~v651;\n\tv538 = this.generateMeshOverride == 0;\n\tv518 = ~v538;\n\tSpine.Unity.MeshGenerator::GenerateSkeletonRendererInstruction(v243, this.skeleton, this.customSlotMaterials, this.separatorSlots, v518, v656);\n\tv662 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::get_Count(this.customMaterialOverride);\n\tv195 = v662 < 1;\n\tif (v195) goto L_0114;\n\tgoto L_0113;\n\tv687 = \"il2cpp_codegen_runtime_class_init\"(v676, v661, v448, v162, v102, v105, v99, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0113:\n\tSpine.Unity.MeshGenerator::TryReplaceMaterials(v243.submeshInstructions, this.customMaterialOverride);\nL_0114:\n\tv686 = this.generateMeshOverride == 0;\n\tif (v686) goto L_0127;\n\tSpine.Unity.SkeletonRenderer+InstructionDelegate::Invoke(this.generateMeshOverride, v243);\n\tv695 = ~this.disableRenderingOnOverride;\n\tv237 = ~v695;\n\tif (v237) goto L_021A;\nL_0127:\n\tv563 = Spine.Unity.SkeletonRendererInstruction::GeometryNotEqual(v243, v554.instructionUsed);\n\tv625 = this.meshGenerator;\n\tv625.settings.useClipping = this.useClipping;\n\tv625.settings.zSpacing = this.zSpacing;\n\tv625.settings.pmaVertexColors = this.pmaVertexColors;\n\tv625.settings.tintBlack = this.tintBlack;\n\tv625.settings.canvasGroupTintBlack = 0;\n\tv625.settings.calculateTangents = this.calculateTangents;\n\tv625.settings.addNormals = this.addNormals;\n\t*([v625 @ X8_v29 (Spine.Unity.MeshGenerator)+13]) = 0;\n\t*([v625 @ X8_v29 (Spine.Unity.MeshGenerator)+11]) = 0;\n\t*([v625 @ X8_v29 (Spine.Unity.MeshGenerator)+1F]) = 0;\n\tv625.settings.immutableTriangles = 0;\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\tv751 = this.meshGenerator;\n\tv712 = ~v243.hasActiveClipping;\n\tif (v712) goto L_FFFFFFFF;\n\tSpine.Unity.MeshGenerator::BuildMesh(this.meshGenerator, v243, v563);\n\tgoto L_015E;\n\tgoto L_015D;\nL_015D:\n\tSpine.Unity.MeshGenerator::BuildMeshWithArrays(v751, v243, v735);\nL_015E:\n\t;\n\tv770 = this.OnPostProcessVertices == 0;\n\tif (v770) goto L_0185;\n\tv795 = Spine.Unity.MeshGenerator::get_Buffers(this.meshGenerator);\n\tv796 = v795.vertexCount;\n\tSpine.Unity.MeshGeneratorDelegate::Invoke(this.OnPostProcessVertices, &v796 @ stack_-90_v7 (System.Int32));\nL_0185:\n\tSpine.Unity.MeshGenerator::FillVertexData(this.meshGenerator, v554.mesh);\n\tSpine.Unity.MeshRendererBuffers::UpdateSharedMaterials(this.rendererBuffers, v243.submeshInstructions);\n\tv800 = Spine.Unity.MeshRendererBuffers::MaterialsChangedInLastUpdate(this.rendererBuffers);\n\tv802 = v483 == 0;\n\tif (v802) goto L_01AD;\n\tSpine.Unity.MeshGenerator::FillTriangles(this.meshGenerator, v554.mesh);\n\tv571 = Spine.Unity.MeshRendererBuffers::GetUpdatedSharedMaterialsArray(this.rendererBuffers);\n\tUnityEngine.Renderer::set_sharedMaterials(this.meshRenderer, v571);\n\tv822 = v800 == 0;\n\tv814 = ~v822;\n\tif (v814) goto L_01BE;\n\tgoto L_01CE;\nL_01AD:\n\tv804 = v800 == 0;\n\tif (v804) goto L_01CE;\n\tv573 = Spine.Unity.MeshRendererBuffers::GetUpdatedSharedMaterialsArray(this.rendererBuffers);\n\tUnityEngine.Renderer::set_sharedMaterials(this.meshRenderer, v573);\nL_01BE:\n\tv811 = Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials::get_AnyMaterialCreated(this.maskMaterials);\n\tv813 = v811 == 0;\n\tif (v813) goto L_01CE;\n\tv809 = new Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials();\n\tSpine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials::.ctor(v809);\n\tthis.maskMaterials = v809;\nL_01CE:\n\tSpine.Unity.MeshGenerator::FillLateVertexData(this.meshGenerator, v554.mesh);\n\tUnityEngine.MeshFilter::set_sharedMesh(this.meshFilter, v554.mesh);\n\tSpine.Unity.SkeletonRendererInstruction::Set(v554.instructionUsed, v243);\n\tgoto L_01E7;\n\tv834 = \"il2cpp_codegen_runtime_class_init\"(v828, v823, v824, v161, v101, v104, v98, v38, v159, v130, v128, v42, v43, v44, v45, v46);\nL_01E7:\n\tv837 = UnityEngine.Object::op_Inequality(this.meshRenderer, 0);\n\tv839 = v837 == 0;\n\tif (v839) goto L_01EE;\n\tSpine.Unity.SkeletonRenderer::AssignSpriteMaskMaterials(this);\nL_01EE:\n\tv842 = ~this.fixDrawOrder;\n\tif (v842) goto L_0206;\n\tv578 = UnityEngine.Renderer::get_sharedMaterials(this.meshRenderer);\n\tv843 = v578.Length < 3;\n\tif (v843) goto L_0206;\n\tSpine.Unity.SkeletonRenderer::SetMaterialSettingsToFixDrawOrder(this);\nL_0206:\n\t;\n\tv235 = this.OnMeshAndMaterialsUpdated == 0;\n\tif (v235) goto L_021A;\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::Invoke(this.OnMeshAndMaterialsUpdated, this);\nL_021A:\n\treturn;\n\tv631 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 392 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe virtual void LateUpdate()
		{
			//IL_0587: Expected O, but got Ref
			//IL_028d: Expected O, but got I
			//IL_02a5: Expected O, but got Ref
			//IL_02b5: Expected O, but got I
			if (!valid || UpdateMode != UpdateMode.FullUpdate)
			{
				return;
			}
			bool flag = meshRenderer.enabled;
			if (this.generateMeshOverride == null && !flag)
			{
				return;
			}
			SkeletonRendererInstruction skeletonRendererInstruction = currentInstructions;
			ExposedList<SubmeshInstruction> submeshInstructions = skeletonRendererInstruction.submeshInstructions;
			MeshRendererBuffers.SmartMesh nextMesh = rendererBuffers.GetNextMesh();
			bool flag3;
			bool updateTriangles;
			MeshGenerator meshGenerator2;
			if (singleSubmesh)
			{
				SkeletonDataAsset skeletonDataAsset = this.skeletonDataAsset;
				AtlasAssetBase[] atlasAssets = skeletonDataAsset.atlasAssets;
				Material primaryMaterial = atlasAssets[0].PrimaryMaterial;
				MeshGenerator.GenerateSingleSubmeshInstruction(skeletonRendererInstruction, skeleton, primaryMaterial);
				int count = CustomMaterialOverride.Count;
				if (count >= 1)
				{
					MeshGenerator.TryReplaceMaterials(skeletonRendererInstruction.submeshInstructions, CustomMaterialOverride);
				}
				MeshGenerator meshGenerator = this.meshGenerator;
				meshGenerator.settings.useClipping = useClipping;
				meshGenerator.settings.zSpacing = zSpacing;
				meshGenerator.settings.pmaVertexColors = pmaVertexColors;
				meshGenerator.settings.tintBlack = tintBlack;
				meshGenerator.settings.canvasGroupTintBlack = false;
				meshGenerator.settings.calculateTangents = calculateTangents;
				meshGenerator.settings.addNormals = addNormals;
				_ = 0;
				_ = 0;
				_ = 0;
				meshGenerator.settings.immutableTriangles = false;
				this.meshGenerator.Begin();
				bool flag2 = SkeletonRendererInstruction.GeometryNotEqual(skeletonRendererInstruction, nextMesh.instructionUsed);
				if (skeletonRendererInstruction.hasActiveClipping)
				{
					SubmeshInstruction[] items = submeshInstructions.Items;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X9_v19 (Spine.Unity.SubmeshInstruction[])+20]");
					SubmeshInstruction submeshInstruction = (SubmeshInstruction)0;
					this.meshGenerator.AddSubmesh((SubmeshInstruction)(&submeshInstruction), flag2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X9_v19 (Spine.Unity.SubmeshInstruction[])+40]");
					submeshInstruction = (SubmeshInstruction)0;
					flag3 = flag2;
					goto IL_053b;
				}
				updateTriangles = flag2;
				flag3 = flag2;
				meshGenerator2 = this.meshGenerator;
			}
			else
			{
				bool flag4 = !immutableTriangles;
				bool flag5 = !flag4;
				bool flag6 = this.generateMeshOverride == null;
				bool flag7 = !flag6;
				MeshGenerator.GenerateSkeletonRendererInstruction(skeletonRendererInstruction, skeleton, CustomSlotMaterials, separatorSlots, flag7, flag5);
				int count2 = CustomMaterialOverride.Count;
				if (count2 >= 1)
				{
					MeshGenerator.TryReplaceMaterials(skeletonRendererInstruction.submeshInstructions, CustomMaterialOverride);
				}
				if (this.generateMeshOverride != null)
				{
					this.generateMeshOverride(skeletonRendererInstruction);
					if (disableRenderingOnOverride)
					{
						return;
					}
				}
				bool flag8 = SkeletonRendererInstruction.GeometryNotEqual(skeletonRendererInstruction, nextMesh.instructionUsed);
				MeshGenerator meshGenerator3 = this.meshGenerator;
				meshGenerator3.settings.useClipping = useClipping;
				meshGenerator3.settings.zSpacing = zSpacing;
				meshGenerator3.settings.pmaVertexColors = pmaVertexColors;
				meshGenerator3.settings.tintBlack = tintBlack;
				meshGenerator3.settings.canvasGroupTintBlack = false;
				meshGenerator3.settings.calculateTangents = calculateTangents;
				meshGenerator3.settings.addNormals = addNormals;
				_ = 0;
				_ = 0;
				_ = 0;
				meshGenerator3.settings.immutableTriangles = false;
				this.meshGenerator.Begin();
				meshGenerator2 = this.meshGenerator;
				if (skeletonRendererInstruction.hasActiveClipping)
				{
					this.meshGenerator.BuildMesh(skeletonRendererInstruction, flag8);
					flag3 = flag8;
					goto IL_053b;
				}
				updateTriangles = flag8;
				flag3 = flag8;
			}
			meshGenerator2.BuildMeshWithArrays(skeletonRendererInstruction, updateTriangles);
			goto IL_053b;
			IL_053b:
			if (this.OnPostProcessVertices != null)
			{
				int vertexCount = this.meshGenerator.Buffers.vertexCount;
				this.OnPostProcessVertices((MeshGeneratorBuffers)(&vertexCount));
			}
			this.meshGenerator.FillVertexData(nextMesh.mesh);
			rendererBuffers.UpdateSharedMaterials(skeletonRendererInstruction.submeshInstructions);
			bool flag9 = rendererBuffers.MaterialsChangedInLastUpdate();
			if (flag3)
			{
				this.meshGenerator.FillTriangles(nextMesh.mesh);
				Material[] updatedSharedMaterialsArray = rendererBuffers.GetUpdatedSharedMaterialsArray();
				meshRenderer.sharedMaterials = updatedSharedMaterialsArray;
				if (flag9)
				{
					goto IL_069c;
				}
			}
			else if (flag9)
			{
				Material[] updatedSharedMaterialsArray2 = rendererBuffers.GetUpdatedSharedMaterialsArray();
				meshRenderer.sharedMaterials = updatedSharedMaterialsArray2;
				goto IL_069c;
			}
			goto IL_06e6;
			IL_069c:
			if (maskMaterials.AnyMaterialCreated)
			{
				SpriteMaskInteractionMaterials spriteMaskInteractionMaterials = new SpriteMaskInteractionMaterials();
				maskMaterials = spriteMaskInteractionMaterials;
			}
			goto IL_06e6;
			IL_06e6:
			this.meshGenerator.FillLateVertexData(nextMesh.mesh);
			meshFilter.sharedMesh = nextMesh.mesh;
			nextMesh.instructionUsed.Set(skeletonRendererInstruction);
			if (meshRenderer != null)
			{
				AssignSpriteMaskMaterials();
			}
			if (fixDrawOrder)
			{
				Material[] sharedMaterials = meshRenderer.sharedMaterials;
				if (sharedMaterials.Length >= 3)
				{
					SetMaterialSettingsToFixDrawOrder();
				}
			}
			if (this.OnMeshAndMaterialsUpdated != null)
			{
				this.OnMeshAndMaterialsUpdated(this);
			}
		}

		[Token(Token = "0x60005D5")]
		[Address(RVA = "0x15620E0", Offset = "0x15620E0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = 3;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBecameVisible()
		{
			UpdateMode = UpdateMode.FullUpdate;
		}

		[Token(Token = "0x60005D6")]
		[Address(RVA = "0x15620EC", Offset = "0x15620EC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = this.updateWhenInvisible;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBecameInvisible()
		{
			UpdateMode = updateWhenInvisible;
		}

		[Token(Token = "0x60005D7")]
		[Address(RVA = "0x15620F8", Offset = "0x15620F8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = System.Func`2<System.String, System.Boolean>;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, startsWith, clearExistingSeparators, updateStringArray, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv51 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v51, startsWith, clearExistingSeparators, updateStringArray, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv56 = Spine.Unity.SkeletonRenderer+<>c__DisplayClass75_0;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, startsWith, clearExistingSeparators, updateStringArray, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv47 = 1;\n\t*([1A37C67]) = v47;\nL_0020:\n\tv49 = new Spine.Unity.SkeletonRenderer+<>c__DisplayClass75_0();\n\tSystem.Object::.ctor(v49);\n\tv49.startsWith = startsWith;\n\tv60 = System.String::IsNullOrEmpty(startsWith);\n\tv63 = v60 == 0;\n\tif (v63) goto L_0039;\n\treturn;\nL_0039:\n\tv74 = new System.Func`2<System.String, System.Boolean>();\n\tSystem.Func`2<System.String, System.Boolean>::.ctor(v74, v49, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::FindAndApplySeparatorSlots(this, v74, clearExistingSeparators, updateStringArray);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void FindAndApplySeparatorSlots(string startsWith, bool clearExistingSeparators = true, bool updateStringArray = false)
		{
			string startsWith2 = startsWith;
			if (!string.IsNullOrEmpty(startsWith))
			{
				Func<string, bool> slotNamePredicate = (string slotName) => slotName.StartsWith(startsWith2);
				FindAndApplySeparatorSlots(slotNamePredicate, clearExistingSeparators, updateStringArray);
			}
		}

		[Token(Token = "0x60005D8")]
		[Address(RVA = "0x15621F4", Offset = "0x15621F4", Length = "0x4E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0037;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv173 = Il2CppMethodInfo;\n\tv174 = \"il2cpp_codegen_initialize_runtime_metadata\"(v173, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv240 = Il2CppMethodInfo;\n\tv241 = \"il2cpp_codegen_initialize_runtime_metadata\"(v240, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv277 = Il2CppMethodInfo;\n\tv278 = \"il2cpp_codegen_initialize_runtime_metadata\"(v277, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv402 = Il2CppMethodInfo;\n\tv403 = \"il2cpp_codegen_initialize_runtime_metadata\"(v402, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv465 = Il2CppMethodInfo;\n\tv466 = \"il2cpp_codegen_initialize_runtime_metadata\"(v465, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv512 = Il2CppMethodInfo;\n\tv513 = \"il2cpp_codegen_initialize_runtime_metadata\"(v512, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv579 = Il2CppMethodInfo;\n\tv580 = \"il2cpp_codegen_initialize_runtime_metadata\"(v579, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv584 = System.Collections.Generic.List`1<System.String>;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v584, slotNamePredicate, clearExistingSeparators, updateStringArray, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv49 = 1;\n\t*([1A37C68]) = v49;\nL_0037:\n\tv53 = slotNamePredicate == 0;\n\tif (v53) goto L_015E;\n\tv58 = ~this.valid;\n\tif (v58) goto L_015E;\n\tv176 = clearExistingSeparators == 0;\n\tif (v176) goto L_0057;\n\tv242 = this.separatorSlots;\n\tv267 = v242._version + 1;\n\tv242._size = 0;\n\tv242._version = v267;\n\tv249 = v242._size < 1;\n\tif (v249) goto L_0057;\n\tSystem.Array::Clear(v242._items, 0, v242._size);\nL_0057:\n\tv274 = this.skeleton;\n\tv463 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(v274.slots);\nL_006C:\n\tv577 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v461 @ stack_-88_v11 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv582 = v577 == 0;\n\tif (v582) goto L_00A4;\n\tv613 = v504.data;\n\tv564 = System.Func`2<System.String, System.Boolean>::Invoke(slotNamePredicate, v613.name);\n\tv639 = v564 & 1;\n\tv567 = v639 == 0;\n\tif (v567) goto L_006C;\n\tv565 = this.separatorSlots;\n\tv684 = v565._items;\n\tv685 = v565._version + 1;\n\tv565._version = v685;\n\tv537 = v565._size;\n\tv709 = v565._size < v684.Length;\n\tv556 = ~v709;\n\tif (v556) goto L_009E;\n\tv558 = v565._size + 1;\n\tv565._size = v558;\n\tv684[v537 @ X10_v23 (System.Int32)] = v504;\n\tgoto L_006C;\nL_009E:\n\tSystem.Collections.Generic.List`1<Spine.Slot>::AddWithResize(v565, v504);\n\tgoto L_006C;\nL_00A4:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v461 @ stack_-88_v11 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00A6:\n\tv147 = v156 == 0;\n\tif (v147) goto L_015E;\n\tv366 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v366);\n\tv391 = this.skeleton;\n\tv780 = Spine.ExposedList`1<Spine.Slot>::GetEnumerator(v391.slots);\nL_00C2:\n\tv735 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v461 @ stack_-88_v11 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv699 = v735 == 0;\n\tif (v699) goto L_00FB;\n\tv777 = v504.data;\n\tv447 = System.Func`2<System.String, System.Boolean>::Invoke(v150, v777.name);\n\tv847 = v447 & 1;\n\tv817 = v847 == 0;\n\tif (v817) goto L_00C2;\n\tv499 = v366._items;\n\tv470 = v366._version + 1;\n\tv366._version = v470;\n\tv801 = v366._size;\n\tv859 = v366._size < v499.Length;\n\tv811 = ~v859;\n\tif (v811) goto L_00F5;\n\tv812 = v366._size + 1;\n\tv366._size = v812;\n\tv499[v801 @ X10_v18 (System.Int32)] = v777.name;\n\tgoto L_00C2;\nL_00F5:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v366, v777.name);\n\tgoto L_00C2;\nL_00FB:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v461 @ stack_-88_v11 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00FD:\n\tv704 = v700 == 0;\n\tv705 = ~v704;\n\tif (v705) goto L_0152;\n\tv385 = this.separatorSlotNames;\n\tv749 = v385.Length < 1;\n\tif (v749) goto L_0152;\n\tv393 = v385.Length & 0xFFFFFFFF;\nL_0113:\n\tv830 = v382 < v393;\n\tv353 = ~v830;\n\tif (v353) goto L_0168;\n\tv394 = v155._items;\n\tv294 = v155._version + 1;\n\tv155._version = v294;\n\tv747 = v155._size;\n\tv837 = v155._size < v394.Length;\n\tv838 = ~v837;\n\tif (v838) goto L_0139;\n\tv848 = v155._size + 1;\n\tv155._size = v848;\n\tv394[v747 @ X10_v13 (System.Int32)] = v385[v382 @ X21_v16 (System.Int32)];\n\tgoto L_013E;\nL_0139:\n\t;\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v155, v385[v382 @ X21_v16 (System.Int32)]);\nL_013E:\n\tv393 = v385.Length;\n\tv382 = v382 + 1;\n\tv748 = v382 < v385.Length;\n\tif (v748) goto L_0113;\nL_0152:\n\tv143 = System.Collections.Generic.List`1<System.String>::ToArray(v155);\n\tthis.separatorSlotNames = v143;\nL_015E:\n\treturn;\n\tv615 = new System.NullReferenceException();\n\tv643 = new System.NullReferenceException();\n\tv656 = new System.NullReferenceException();\n\tv693 = new System.NullReferenceException();\n\tv744 = new System.NullReferenceException();\n\tv364 = new System.NullReferenceException();\n\tv400 = new System.NullReferenceException();\n\tv457 = new System.NullReferenceException();\n\tv501 = new System.NullReferenceException();\nL_0168:\n\tv531 = new System.IndexOutOfRangeException();\n\tgoto L_0179;\n\tgoto L_01A2;\n\tgoto L_0179;\n\tgoto L_0179;\n\tgoto L_0179;\n\tgoto L_0179;\nL_0179:\n\tv595 = v515 != 1;\n\tif (v595) goto L_0189;\n\tv602 = 0x1854E70(v531, v515, v223, v199, methodInfo, v35, v36, v37, v193, v39, v40, v41, v42, v43, v44, v45);\n\tv633 = 0x1854E80(v602, v515, v223, v199, methodInfo, v35, v36, v37, v193, v39, v40, v41, v42, v43, v44, v45);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v473 @ stack_-70_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv608 = *([v602 @ X0_v25]) == 0;\n\tif (v608) goto L_00FD;\n\tthrow System.OutOfMemoryException;\nL_0189:\n\tgoto L_018F;\n\tX23 = X0;\nL_018F:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v473 @ stack_-70_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_01BD;\n\tv660 = new System.OutOfMemoryException();\n\tgoto L_01A2;\n\tgoto L_01A2;\n\tgoto L_01A2;\n\tgoto L_01A2;\nL_01A2:\n\tv618 = Il2CppMethodInfo != 1;\n\tif (v618) goto L_01B2;\n\tv786 = 0x1854E70(v660, Il2CppMethodInfo, v223, v199, methodInfo, v35, v36, v37, v193, v39, v40, v41, v42, v43, v44, v45);\n\tv797 = 0x1854E80(v786, Il2CppMethodInfo, v223, v199, methodInfo, v35, v36, v37, v193, v39, v40, v41, v42, v43, v44, v45);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v473 @ stack_-70_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv629 = *([v786 @ X0_v19]) == 0;\n\tif (v629) goto L_00A6;\n\tthrow System.OutOfMemoryException;\nL_01B2:\n\tgoto L_01B8;\n\tX23 = X0;\nL_01B8:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v473 @ stack_-70_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_01BF;\nL_01BD:\n\tv682 = 0xBD3CD0(v680, v663, v223, v199, methodInfo, v35, v36, v37, v193, v39, v40, v41, v42, v43, v44, v45);\nL_01BF:\n\tv708 = new System.OutOfMemoryException();\n\tv225 = 0x9DACB4(v708, v201, v223, v199, methodInfo, v35, v36, v37, v1\n// ... truncated")]
		public void FindAndApplySeparatorSlots(Func<string, bool> slotNamePredicate, bool clearExistingSeparators = true, bool updateStringArray = false)
		{
			//IL_010e: Expected O, but got I4
			//IL_02a0: Expected O, but got I4
			//IL_040c: Expected I4, but got I8
			//IL_05a8: Expected I4, but got O
			if (slotNamePredicate == null || !valid)
			{
				return;
			}
			if (clearExistingSeparators)
			{
				List<Slot> list = separatorSlots;
				int version = list._version + 1;
				list._size = 0;
				list._version = version;
				if (list.Count >= 1)
				{
					Array.Clear(list._items, 0, list.Count);
				}
			}
			Skeleton skeleton = this.skeleton;
			ExposedList<Slot>.Enumerator enumerator = skeleton.Slots.GetEnumerator();
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			Slot slot = default(Slot);
			while (enumerator2.MoveNext())
			{
				SlotData data = slot.Data;
				object obj = slotNamePredicate(data.Name);
				if ((int)((nint)obj & 1) != 0)
				{
					List<Slot> list2 = separatorSlots;
					Slot[] items = list2._items;
					int version2 = list2._version + 1;
					list2._version = version2;
					int count = list2.Count;
					if (list2.Count < items.Length)
					{
						int size = list2.Count + 1;
						list2._size = size;
						items[count] = slot;
					}
					else
					{
						list2.Add(slot);
					}
				}
			}
			enumerator2.Dispose();
			bool flag = clearExistingSeparators;
			if (!updateStringArray)
			{
				return;
			}
			List<string> list3 = new List<string>();
			Skeleton skeleton2 = this.skeleton;
			ExposedList<Slot>.Enumerator enumerator3 = skeleton2.Slots.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				SlotData data2 = slot.Data;
				object obj2 = slotNamePredicate(data2.Name);
				if ((int)((nint)obj2 & 1) != 0)
				{
					string[] items2 = list3._items;
					int version3 = list3._version + 1;
					list3._version = version3;
					int count2 = list3.Count;
					if (list3.Count < items2.Length)
					{
						int size2 = list3.Count + 1;
						list3._size = size2;
						items2[count2] = data2.Name;
					}
					else
					{
						list3.Add(data2.Name);
					}
				}
			}
			enumerator2.Dispose();
			List<string> list4 = list3;
			IndexOutOfRangeException ex;
			IntPtr intPtr = default(IntPtr);
			ExposedList<object>.Enumerator enumerator4 = default(ExposedList<object>.Enumerator);
			object obj3 = default(object);
			string[] array2 = default(string[]);
			List<string> list5 = default(List<string>);
			while (true)
			{
				if (!flag)
				{
					string[] array = separatorSlotNames;
					if (array.Length >= 1)
					{
						int num = (int)(array.Length & 0xFFFFFFFFL);
						int num2 = 0;
						while (num2 < num)
						{
							string[] items3 = list4._items;
							int version4 = list4._version + 1;
							list4._version = version4;
							int count3 = list4.Count;
							if (list4.Count < items3.Length)
							{
								int size3 = list4.Count + 1;
								list4._size = size3;
								items3[count3] = array[num2];
							}
							else
							{
								list4.Add(array[num2]);
							}
							num = array.Length;
							num2++;
							if (num2 < array.Length)
							{
								continue;
							}
							goto IL_051a;
						}
						ex = new IndexOutOfRangeException();
						if (intPtr == (IntPtr)1)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							enumerator4.Dispose();
							bool flag2 = obj3 == null;
							flag = (byte)(int)array2 != 0;
							list4 = list5;
							if (!flag2)
							{
								throw new OutOfMemoryException();
							}
							continue;
						}
						break;
					}
				}
				goto IL_051a;
				IL_051a:
				string[] array3 = list4.ToArray();
				separatorSlotNames = array3;
				return;
			}
			enumerator4.Dispose();
			nint num3 = 0;
			IndexOutOfRangeException ex2 = ex;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
			IntPtr intPtr2 = num3;
			OutOfMemoryException ex3 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x60005D9")]
		[Address(RVA = "0x15626D8", Offset = "0x15626D8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C69]) = v38;\nL_0016:\n\tv40 = ~this.valid;\n\tif (v40) goto L_0090;\n\tv43 = this.separatorSlots;\n\tv144 = v43._version + 1;\n\tv43._size = 0;\n\tv43._version = v144;\n\tv155 = v43._size < 1;\n\tif (v155) goto L_0030;\n\tSystem.Array::Clear(v43._items, 0, v43._size);\nL_0030:\n\tv183 = this.separatorSlotNames;\n\tv72 = v183.Length < 1;\n\tif (v72) goto L_0090;\n\tv59 = v183.Length & 0xFFFFFFFF;\nL_0056:\n\tv232 = Spine.Skeleton::FindSlot(this.skeleton, v183[v186 @ X20_v6 (System.Int32)]);\n\tv233 = v232 == 0;\n\tif (v233) goto L_007A;\n\tv177 = this.separatorSlots;\n\tv185 = v177._items;\n\tv158 = v177._version + 1;\n\tv177._version = v158;\n\tv235 = v177._size;\n\tv260 = v177._size < v185.Length;\n\tv252 = ~v260;\n\tif (v252) goto L_0079;\n\tv253 = v177._size + 1;\n\tv177._size = v253;\n\tv185[v235 @ X10_v7 (System.Int32)] = v232;\n\tgoto L_007A;\nL_0079:\n\tSystem.Collections.Generic.List`1<Spine.Slot>::AddWithResize(v177, v232);\nL_007A:\n\tv186 = v186 + 1;\n\tv97 = v59 == v186;\n\tif (v97) goto L_0090;\n\tv183 = this.separatorSlotNames;\n\tv259 = this.separatorSlotNames == 0;\n\tv178 = ~v259;\n\tif (v178) goto L_0056;\n\tthrow System.NullReferenceException;\nL_0090:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ReapplySeparatorSlotNames()
		{
			//IL_00c7: Expected I4, but got I8
			if (!valid)
			{
				return;
			}
			List<Slot> list = separatorSlots;
			int version = list._version + 1;
			list._size = 0;
			list._version = version;
			if (list.Count >= 1)
			{
				Array.Clear(list._items, 0, list.Count);
			}
			string[] array = separatorSlotNames;
			if (array.Length < 1)
			{
				return;
			}
			int num = (int)(array.Length & 0xFFFFFFFFL);
			int num2 = 0;
			while (true)
			{
				Slot slot = skeleton.FindSlot(array[num2]);
				if (slot != null)
				{
					List<Slot> list2 = separatorSlots;
					Slot[] items = list2._items;
					int version2 = list2._version + 1;
					list2._version = version2;
					int count = list2.Count;
					if (list2.Count < items.Length)
					{
						int size = list2.Count + 1;
						list2._size = size;
						items[count] = slot;
					}
					else
					{
						list2.Add(slot);
					}
				}
				num2++;
				if (num != num2)
				{
					array = separatorSlotNames;
					if (separatorSlotNames == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60005DA")]
		[Address(RVA = "0x1561D64", Offset = "0x1561D64", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = UnityEngine.Application;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv44 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37C6A]) = v38;\nL_001A:\n\tgoto L_001D;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Application::get_isPlaying();\n\tv50 = v48 == 0;\n\tif (v50) goto L_0034;\n\tv52 = this.maskInteraction == 0;\n\tif (v52) goto L_0034;\n\tv63 = this.maskMaterials;\n\tv142 = v63.materialsMaskDisabled;\n\tv184 = v142.Length == 0;\n\tv59 = ~v184;\n\tif (v59) goto L_0034;\n\tv56 = UnityEngine.Renderer::get_sharedMaterials(this.meshRenderer);\n\tv63.materialsMaskDisabled = v56;\nL_0034:\n\tv64 = this.maskMaterials;\n\tv67 = v64.materialsMaskDisabled;\n\tv160 = v67.Length == 0;\n\tif (v160) goto L_0057;\n\tgoto L_004B;\n\tv238 = \"il2cpp_codegen_runtime_class_init\"(v192, v53, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_004B:\n\tv127 = UnityEngine.Object::op_Inequality(v67[0], 0);\n\tv187 = v127 == 0;\n\tif (v187) goto L_0057;\n\tv186 = this.maskInteraction == 0;\n\tif (v186) goto L_00BA;\nL_0057:\n\tv91 = this.maskInteraction == 2;\n\tif (v91) goto L_008B;\n\tv71 = this.maskInteraction != 1;\n\tif (v71) goto L_00B3;\n\tv143 = this.maskMaterials;\n\tv144 = v143.materialsInsideMask;\n\tv243 = v144.Length == 0;\n\tif (v243) goto L_0082;\n\tgoto L_007D;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v276, v116, v105, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_007D:\n\tv265 = UnityEngine.Object::op_Equality(v144[0], 0);\n\tv267 = v265 == 0;\n\tif (v267) goto L_0089;\nL_0082:\n\tv271 = Spine.Unity.SkeletonRenderer::InitSpriteMaskMaterialsInsideMask(this);\nL_0089:\n\tv231 = this.maskMaterials + 0x18;\n\tgoto L_00C2;\nL_008B:\n\tv146 = this.maskMaterials;\n\tv147 = v146.materialsOutsideMask;\n\tv242 = v147.Length == 0;\n\tif (v242) goto L_00A5;\n\tgoto L_00A0;\n\tv280 = \"il2cpp_codegen_runtime_class_init\"(v272, v116, v105, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_00A0:\n\tv251 = UnityEngine.Object::op_Equality(v147[0], 0);\n\tv253 = v251 == 0;\n\tif (v253) goto L_00AC;\nL_00A5:\n\tv257 = Spine.Unity.SkeletonRenderer::InitSpriteMaskMaterialsOutsideMask(this);\nL_00AC:\n\tv231 = this.maskMaterials + 0x20;\n\tgoto L_00C2;\nL_00B3:\n\treturn;\nL_00BA:\n\tv231 = this.maskMaterials + 0x10;\nL_00C2:\n\tUnityEngine.Renderer::set_materials(v224, *([v231 @ X8_v7]));\n\treturn;\n\tv157 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AssignSpriteMaskMaterials()
		{
			//IL_02c9: Expected O, but got I
			//IL_02ea: Expected O, but got I
			//IL_021f: Expected O, but got I
			if (Application.isPlaying && maskInteraction != SpriteMaskInteraction.None)
			{
				SpriteMaskInteractionMaterials spriteMaskInteractionMaterials = maskMaterials;
				Material[] materialsMaskDisabled = spriteMaskInteractionMaterials.materialsMaskDisabled;
				if (materialsMaskDisabled.Length == 0)
				{
					Material[] sharedMaterials = meshRenderer.sharedMaterials;
					spriteMaskInteractionMaterials.materialsMaskDisabled = sharedMaterials;
				}
			}
			SpriteMaskInteractionMaterials spriteMaskInteractionMaterials2 = maskMaterials;
			Material[] materialsMaskDisabled2 = spriteMaskInteractionMaterials2.materialsMaskDisabled;
			object materials;
			Renderer renderer;
			if (materialsMaskDisabled2.Length == 0 || !(materialsMaskDisabled2[0] != null) || maskInteraction != SpriteMaskInteraction.None)
			{
				if (maskInteraction != SpriteMaskInteraction.VisibleOutsideMask)
				{
					if (maskInteraction != SpriteMaskInteraction.VisibleInsideMask)
					{
						return;
					}
					SpriteMaskInteractionMaterials spriteMaskInteractionMaterials3 = maskMaterials;
					Material[] materialsInsideMask = spriteMaskInteractionMaterials3.materialsInsideMask;
					if (materialsInsideMask.Length == 0 || materialsInsideMask[0] == null)
					{
						bool flag = InitSpriteMaskMaterialsInsideMask();
					}
					materials = (nint)maskMaterials + 24;
					renderer = meshRenderer;
				}
				else
				{
					SpriteMaskInteractionMaterials spriteMaskInteractionMaterials4 = maskMaterials;
					Material[] materialsOutsideMask = spriteMaskInteractionMaterials4.materialsOutsideMask;
					if (materialsOutsideMask.Length == 0 || materialsOutsideMask[0] == null)
					{
						bool flag2 = InitSpriteMaskMaterialsOutsideMask();
					}
					materials = (nint)maskMaterials + 32;
					renderer = meshRenderer;
				}
			}
			else
			{
				materials = (nint)maskMaterials + 16;
				renderer = meshRenderer;
			}
			renderer.materials = (Material[])materials;
		}

		[Token(Token = "0x60005DB")]
		[Address(RVA = "0x1562818", Offset = "0x1562818", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.maskMaterials + 0x18;\n\tv7 = Spine.Unity.SkeletonRenderer::InitSpriteMaskMaterialsForMaskType(this, 4, v5);\n\treturn 1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool InitSpriteMaskMaterialsInsideMask()
		{
			bool flag = InitSpriteMaskMaterialsForMaskType(CompareFunction.LessEqual, ref *(Material[]*)((nint)maskMaterials + 24));
			return true;
		}

		[Token(Token = "0x60005DC")]
		[Address(RVA = "0x1562840", Offset = "0x1562840", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.maskMaterials + 0x20;\n\tv7 = Spine.Unity.SkeletonRenderer::InitSpriteMaskMaterialsForMaskType(this, 5, v5);\n\treturn 1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool InitSpriteMaskMaterialsOutsideMask()
		{
			bool flag = InitSpriteMaskMaterialsForMaskType(CompareFunction.Greater, ref *(Material[]*)((nint)maskMaterials + 32));
			return true;
		}

		[Token(Token = "0x60005DD")]
		[Address(RVA = "0x1562868", Offset = "0x1562868", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = UnityEngine.Material[];\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, maskFunction, materialsToFill, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = UnityEngine.Material;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, maskFunction, materialsToFill, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv124 = Spine.Unity.SkeletonRenderer;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v124, maskFunction, materialsToFill, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C6B]) = v50;\nL_001F:\n\tv51 = this.maskMaterials;\n\tv56 = v51.materialsMaskDisabled;\n\t// 41 NewArr v129 @ X0_v10 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), v56.Length\n\t*([materialsToFill @ X2 (UnityEngine.Material[]&)]) = v129;\n\tv185 = v56.Length < 1;\n\tif (v185) goto L_0090;\nL_004C:\n\tv301 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v301, *([v56 @ X22_v5 (UnityEngine.Material[])+v70 @ X25_v7 (System.Int32)*8]));\n\tgoto L_005F;\n\tv305 = \"il2cpp_codegen_runtime_class_init\"(v302, v105, v67, methodInfo, v35, v36, v37, v38, v64, v40, v41, v42, v43, v44, v45, v46);\nL_005F:\n\tUnityEngine.Material::SetFloat(v301, v120.STENCIL_COMP_PARAM_ID, maskFunction);\n\tv115 = materialsToFill->klass;\n\t// 102 IsInst v161 @ X0_v20, typeof(UnityEngine.Material), v301 @ X0_v15 (UnityEngine.Material)\n\tv164 = v161 == 0;\n\tif (v164) goto L_0093;\n\t*([v115 @ X21_v9 (UnityEngine.Material[])+v70 @ X25_v7 (System.Int32)*8]) = v301;\n\tv218 = v70 - 3;\n\tv70 = v70 + 1;\n\tv227 = v218 < v56.Length;\n\tif (v227) goto L_004C;\nL_0090:\n\treturn 1;\n\tv122 = new System.NullReferenceException();\n\tv173 = new System.IndexOutOfRangeException();\nL_0093:\n\tv211 = new System.ArrayTypeMismatchException();\n\tthrow v211;\n\treturn returnVal2;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe bool InitSpriteMaskMaterialsForMaskType(CompareFunction maskFunction, ref Material[] materialsToFill)
		{
			//IL_006c: Expected O, but got I
			//IL_008d: Expected F4, but got I4
			SpriteMaskInteractionMaterials spriteMaskInteractionMaterials = maskMaterials;
			Material[] materialsMaskDisabled = spriteMaskInteractionMaterials.materialsMaskDisabled;
			Material[] array = new Material[materialsMaskDisabled.Length];
			ref Material[] reference = ref *(Material[]*)array;
			if (materialsMaskDisabled.Length >= 1)
			{
				int num = 4;
				int num2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X22_v5 (UnityEngine.Material[])+v70 @ X25_v7 (System.Int32)*8]");
					Material material = new Material((Material)0);
					material.SetFloat(STENCIL_COMP_PARAM_ID, (float)maskFunction);
					Material[] array2 = materialsToFill;
					object obj = material as Material;
					if (obj != null)
					{
						num2 = num - 3;
						num++;
						continue;
					}
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					throw ex;
				}
				while (num2 < materialsMaskDisabled.Length);
			}
			return true;
		}

		[Token(Token = "0x60005DE")]
		[Address(RVA = "0x1561F60", Offset = "0x1561F60", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = UnityEngine.MaterialPropertyBlock;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Spine.Unity.SkeletonRenderer;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C6C]) = v40;\nL_0017:\n\tv42 = this.reusedPropertyBlock == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0026;\n\tv49 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v49);\n\tthis.reusedPropertyBlock = v49;\nL_0026:\n\tv59 = UnityEngine.Renderer::HasPropertyBlock(this.meshRenderer);\n\tv170 = v59 == 0;\n\tif (v170) goto L_FFFFFFFF;\n\tUnityEngine.Renderer::GetPropertyBlock(this.meshRenderer, this.reusedPropertyBlock);\nL_0038:\n\tv142 = UnityEngine.Renderer::get_sharedMaterials(v230);\n\tv75 = v120 >= v142.Length;\n\tif (v75) goto L_0090;\n\tv234 = v59 == 0;\n\tv235 = ~v234;\n\tif (v235) goto L_0057;\n\tUnityEngine.Renderer::GetPropertyBlock(this.meshRenderer, this.reusedPropertyBlock, v120);\nL_0057:\n\tgoto L_0061;\n\tv244 = \"il2cpp_codegen_runtime_class_init\"(v241, v134, v127, v73, v25, v26, v27, v28, v66, v30, v31, v32, v33, v34, v35, v36);\nL_0061:\n\tUnityEngine.MaterialPropertyBlock::SetFloat(this.reusedPropertyBlock, v165.SUBMESH_DUMMY_PARAM_ID, v120);\n\tUnityEngine.Renderer::SetPropertyBlock(this.meshRenderer, this.reusedPropertyBlock, v120);\n\tv147 = UnityEngine.Renderer::get_sharedMaterials(this.meshRenderer);\n\tUnityEngine.Material::set_enableInstancing(v147[v120 @ X21_v5 (System.Int32)], 0);\n\tv120 = v120 + 1;\n\tv248 = this.meshRenderer == 0;\n\tv150 = ~v248;\n\tif (v150) goto L_0038;\n\tthrow System.NullReferenceException;\nL_0090:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetMaterialSettingsToFixDrawOrder()
		{
			if (reusedPropertyBlock == null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				reusedPropertyBlock = materialPropertyBlock;
			}
			bool flag = meshRenderer.HasPropertyBlock();
			if (flag)
			{
				meshRenderer.GetPropertyBlock(reusedPropertyBlock);
			}
			int num = 0;
			Renderer renderer = meshRenderer;
			while (true)
			{
				Material[] sharedMaterials = renderer.sharedMaterials;
				if (num < sharedMaterials.Length)
				{
					if (!flag)
					{
						meshRenderer.GetPropertyBlock(reusedPropertyBlock, num);
					}
					reusedPropertyBlock.SetFloat(SUBMESH_DUMMY_PARAM_ID, num);
					meshRenderer.SetPropertyBlock(reusedPropertyBlock, num);
					Material[] sharedMaterials2 = meshRenderer.sharedMaterials;
					sharedMaterials2[num].enableInstancing = false;
					num++;
					bool flag2 = (object)meshRenderer == null;
					bool flag3 = !flag2;
					renderer = meshRenderer;
					if (!flag3)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x60005DF")]
		[Address(RVA = "0x155B340", Offset = "0x155B340", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004A;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv81 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>;\n\tv82 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv86 = System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>;\n\tv87 = \"il2cpp_codegen_initialize_runtime_metadata\"(v86, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv96 = System.Collections.Generic.List`1<Spine.Slot>;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv101 = Spine.Unity.MeshGenerator;\n\tv102 = \"il2cpp_codegen_initialize_runtime_metadata\"(v101, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv106 = Spine.Unity.MeshRendererBuffers;\n\tv107 = \"il2cpp_codegen_initialize_runtime_metadata\"(v106, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv111 = Spine.Unity.SkeletonRendererInstruction;\n\tv112 = \"il2cpp_codegen_initialize_runtime_metadata\"(v111, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv116 = Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials;\n\tv117 = \"il2cpp_codegen_initialize_runtime_metadata\"(v116, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv121 = System.String[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37C6D]) = v70;\nL_004A:\n\tthis.updateMode = 3;\n\t// 77 NewArr v74 @ X0_v3 (System.String[]), typeof(System.String[]), 0\n\tthis.separatorSlotNames = v74;\n\tv79 = new System.Collections.Generic.List`1<Spine.Slot>();\n\tSystem.Collections.Generic.List`1<Spine.Slot>::.ctor(v79);\n\tthis.separatorSlots = v79;\n\tthis.useClipping = 1;\n\tthis.pmaVertexColors = 1;\n\tv90 = new Spine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials();\n\tSpine.Unity.SkeletonRenderer+SpriteMaskInteractionMaterials::.ctor(v90);\n\tthis.maskMaterials = v90;\n\tthis.disableRenderingOnOverride = 1;\n\tv99 = new System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::.ctor(v99);\n\tthis.customMaterialOverride = v99;\n\tv109 = new System.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.Slot, UnityEngine.Material>::.ctor(v109);\n\tthis.customSlotMaterials = v109;\n\tv119 = new Spine.Unity.SkeletonRendererInstruction();\n\tSpine.Unity.SkeletonRendererInstruction::.ctor(v119);\n\tthis.currentInstructions = v119;\n\tv127 = new Spine.Unity.MeshGenerator();\n\tSpine.Unity.MeshGenerator::.ctor(v127);\n\tthis.meshGenerator = v127;\n\tv133 = new Spine.Unity.MeshRendererBuffers();\n\tSpine.Unity.MeshRendererBuffers::.ctor(v133);\n\tthis.rendererBuffers = v133;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRenderer()
		{
			UpdateMode = UpdateMode.FullUpdate;
			string[] array = new string[0];
			separatorSlotNames = array;
			List<Slot> list = new List<Slot>();
			separatorSlots = list;
			useClipping = true;
			pmaVertexColors = true;
			SpriteMaskInteractionMaterials spriteMaskInteractionMaterials = new SpriteMaskInteractionMaterials();
			maskMaterials = spriteMaskInteractionMaterials;
			disableRenderingOnOverride = true;
			Dictionary<Material, Material> dictionary = new Dictionary<Material, Material>();
			customMaterialOverride = dictionary;
			Dictionary<Slot, Material> dictionary2 = new Dictionary<Slot, Material>();
			customSlotMaterials = dictionary2;
			SkeletonRendererInstruction skeletonRendererInstruction = new SkeletonRendererInstruction();
			currentInstructions = skeletonRendererInstruction;
			MeshGenerator meshGenerator = new MeshGenerator();
			this.meshGenerator = meshGenerator;
			MeshRendererBuffers meshRendererBuffers = new MeshRendererBuffers();
			rendererBuffers = meshRendererBuffers;
		}

		[Token(Token = "0x60005E0")]
		[Address(RVA = "0x15629E0", Offset = "0x15629E0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Spine.Unity.SkeletonRenderer;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv48 = \"_StencilComp\";\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv56 = \"_Submesh\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A37C6E]) = v43;\nL_001F:\n\tv46 = UnityEngine.Shader::PropertyToID(\"_StencilComp\");\n\tv52.STENCIL_COMP_PARAM_ID = v46;\n\tv54 = UnityEngine.Shader::PropertyToID(\"_Submesh\");\n\tv62.SUBMESH_DUMMY_PARAM_ID = v54;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static SkeletonRenderer()
		{
			int sTENCIL_COMP_PARAM_ID = Shader.PropertyToID("_StencilComp");
			STENCIL_COMP_PARAM_ID = sTENCIL_COMP_PARAM_ID;
			int sUBMESH_DUMMY_PARAM_ID = Shader.PropertyToID("_Submesh");
			SUBMESH_DUMMY_PARAM_ID = sUBMESH_DUMMY_PARAM_ID;
		}
	}
}
