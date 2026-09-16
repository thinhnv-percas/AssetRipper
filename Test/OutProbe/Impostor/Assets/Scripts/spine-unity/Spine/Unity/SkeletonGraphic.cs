using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace Spine.Unity
{
	[AddComponentMenu("Spine/SkeletonGraphic (Unity UI Canvas)")]
	[ExecuteAlways]
	[RequireComponent(typeof(CanvasRenderer), typeof(RectTransform))]
	[DisallowMultipleComponent]
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonGraphic-Component")]
	[Token(Token = "0x200007E")]
	public class SkeletonGraphic : MaskableGraphic, ISkeletonComponent, IAnimationStateComponent, ISkeletonAnimation, IHasSkeletonDataAsset
	{
		[Token(Token = "0x200007F")]
		public delegate void SkeletonRendererDelegate(SkeletonGraphic skeletonGraphic);

		[Token(Token = "0x400031C")]
		[FieldOffset(Offset = "0xD8")]
		public SkeletonDataAsset skeletonDataAsset;

		[SpineSkin(null, "skeletonDataAsset", true, false, true)]
		[Token(Token = "0x400031D")]
		[FieldOffset(Offset = "0xE0")]
		public string initialSkinName;

		[Token(Token = "0x400031E")]
		[FieldOffset(Offset = "0xE8")]
		public bool initialFlipX;

		[Token(Token = "0x400031F")]
		[FieldOffset(Offset = "0xE9")]
		public bool initialFlipY;

		[SpineAnimation(null, "skeletonDataAsset", true, false)]
		[Token(Token = "0x4000320")]
		[FieldOffset(Offset = "0xF0")]
		public string startingAnimation;

		[Token(Token = "0x4000321")]
		[FieldOffset(Offset = "0xF8")]
		public bool startingLoop;

		[Token(Token = "0x4000322")]
		[FieldOffset(Offset = "0xFC")]
		public float timeScale;

		[Token(Token = "0x4000323")]
		[FieldOffset(Offset = "0x100")]
		public bool freeze;

		[Token(Token = "0x4000324")]
		[FieldOffset(Offset = "0x104")]
		protected UpdateMode updateMode;

		[Token(Token = "0x4000325")]
		[FieldOffset(Offset = "0x108")]
		public UpdateMode updateWhenInvisible;

		[Token(Token = "0x4000326")]
		[FieldOffset(Offset = "0x10C")]
		public bool unscaledTime;

		[Token(Token = "0x4000327")]
		[FieldOffset(Offset = "0x10D")]
		public bool allowMultipleCanvasRenderers;

		[Token(Token = "0x4000328")]
		[FieldOffset(Offset = "0x110")]
		public List<CanvasRenderer> canvasRenderers;

		[Token(Token = "0x4000329")]
		public const string SeparatorPartGameObjectName = "Part";

		[SerializeField]
		[SpineSlot(null, null, false, true, false)]
		[Token(Token = "0x400032A")]
		[FieldOffset(Offset = "0x118")]
		protected string[] separatorSlotNames;

		[NonSerialized]
		[Token(Token = "0x400032B")]
		[FieldOffset(Offset = "0x120")]
		public readonly List<Slot> separatorSlots;

		[Token(Token = "0x400032C")]
		[FieldOffset(Offset = "0x128")]
		public bool enableSeparatorSlots;

		[SerializeField]
		[Token(Token = "0x400032D")]
		[FieldOffset(Offset = "0x130")]
		protected List<Transform> separatorParts;

		[Token(Token = "0x400032E")]
		[FieldOffset(Offset = "0x138")]
		public bool updateSeparatorPartLocation;

		[Token(Token = "0x400032F")]
		[FieldOffset(Offset = "0x139")]
		private bool wasUpdatedAfterInit;

		[Token(Token = "0x4000330")]
		[FieldOffset(Offset = "0x140")]
		private Texture baseTexture;

		[NonSerialized]
		[Token(Token = "0x4000331")]
		[FieldOffset(Offset = "0x148")]
		private readonly Dictionary<Texture, Texture> customTextureOverride;

		[NonSerialized]
		[Token(Token = "0x4000332")]
		[FieldOffset(Offset = "0x150")]
		private readonly Dictionary<Texture, Material> customMaterialOverride;

		[Token(Token = "0x4000333")]
		[FieldOffset(Offset = "0x158")]
		private Texture overrideTexture;

		[Token(Token = "0x4000334")]
		[FieldOffset(Offset = "0x160")]
		protected Skeleton skeleton;

		[CompilerGenerated]
		[Token(Token = "0x4000335")]
		[FieldOffset(Offset = "0x168")]
		private SkeletonRendererDelegate m_OnRebuild;

		[CompilerGenerated]
		[Token(Token = "0x4000336")]
		[FieldOffset(Offset = "0x170")]
		private SkeletonRendererDelegate m_OnMeshAndMaterialsUpdated;

		[Token(Token = "0x4000337")]
		[FieldOffset(Offset = "0x178")]
		protected AnimationState state;

		[SerializeField]
		[Token(Token = "0x4000338")]
		[FieldOffset(Offset = "0x180")]
		protected MeshGenerator meshGenerator;

		[Token(Token = "0x4000339")]
		[FieldOffset(Offset = "0x188")]
		private DoubleBuffered<MeshRendererBuffers.SmartMesh> meshBuffers;

		[Token(Token = "0x400033A")]
		[FieldOffset(Offset = "0x190")]
		private SkeletonRendererInstruction currentInstructions;

		[Token(Token = "0x400033B")]
		[FieldOffset(Offset = "0x198")]
		private readonly ExposedList<Mesh> meshes;

		[CompilerGenerated]
		[Token(Token = "0x400033C")]
		[FieldOffset(Offset = "0x1A0")]
		private UpdateBonesDelegate m_BeforeApply;

		[CompilerGenerated]
		[Token(Token = "0x400033D")]
		[FieldOffset(Offset = "0x1A8")]
		private UpdateBonesDelegate m_UpdateLocal;

		[CompilerGenerated]
		[Token(Token = "0x400033E")]
		[FieldOffset(Offset = "0x1B0")]
		private UpdateBonesDelegate m_UpdateWorld;

		[CompilerGenerated]
		[Token(Token = "0x400033F")]
		[FieldOffset(Offset = "0x1B8")]
		private UpdateBonesDelegate m_UpdateComplete;

		[CompilerGenerated]
		[Token(Token = "0x4000340")]
		[FieldOffset(Offset = "0x1C0")]
		private MeshGeneratorDelegate m_OnPostProcessVertices;

		[Token(Token = "0x17000193")]
		public SkeletonDataAsset SkeletonDataAsset
		{
			[Token(Token = "0x6000540")]
			[Address(RVA = "0x155B53C", Offset = "0x155B53C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonDataAsset;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return skeletonDataAsset;
			}
		}

		[Token(Token = "0x17000194")]
		public UpdateMode UpdateMode
		{
			[Token(Token = "0x6000541")]
			[Address(RVA = "0x155B544", Offset = "0x155B544", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.updateMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UpdateMode;
			}
			[Token(Token = "0x6000542")]
			[Address(RVA = "0x155B54C", Offset = "0x155B54C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = value;\n\treturn;\n")]
			set
			{
				UpdateMode = value;
			}
		}

		[Token(Token = "0x17000195")]
		public List<Transform> SeparatorParts
		{
			[Token(Token = "0x6000543")]
			[Address(RVA = "0x155B554", Offset = "0x155B554", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.separatorParts;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SeparatorParts;
			}
		}

		[Token(Token = "0x17000196")]
		public Dictionary<Texture, Texture> CustomTextureOverride
		{
			[Token(Token = "0x6000546")]
			[Address(RVA = "0x155B730", Offset = "0x155B730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.customTextureOverride;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomTextureOverride;
			}
		}

		[Token(Token = "0x17000197")]
		public Dictionary<Texture, Material> CustomMaterialOverride
		{
			[Token(Token = "0x6000547")]
			[Address(RVA = "0x155B738", Offset = "0x155B738", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.customMaterialOverride;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomMaterialOverride;
			}
		}

		[Token(Token = "0x17000198")]
		public Texture OverrideTexture
		{
			[Token(Token = "0x6000548")]
			[Address(RVA = "0x155B740", Offset = "0x155B740", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.overrideTexture;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OverrideTexture;
			}
			[Token(Token = "0x6000549")]
			[Address(RVA = "0x155B748", Offset = "0x155B748", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.overrideTexture = value;\n\tv10 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv16 = Spine.Unity.SkeletonGraphic::get_mainTexture(this);\n\tUnityEngine.CanvasRenderer::SetTexture(v10, v16);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				overrideTexture = value;
				CanvasRenderer canvasRenderer = base.canvasRenderer;
				Texture texture = mainTexture;
				canvasRenderer.SetTexture(texture);
			}
		}

		[Token(Token = "0x17000199")]
		public override Texture mainTexture
		{
			[Token(Token = "0x600054A")]
			[Address(RVA = "0x155B798", Offset = "0x155B798", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C21]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.overrideTexture, 0);\n\tv51 = v48 == 0;\n\tv56 = ~v51;\n\tv57 = ~v56;\n\tif (v57) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\treturn *([this @ X0 (Spine.Unity.SkeletonGraphic)+v60 @ X8_v5 (System.Int32)]);\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0076: Expected O, but got I
				if (OverrideTexture != null)
				{
					int num = 344;
				}
				else
				{
					int num = 320;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Spine.Unity.SkeletonGraphic)+v60 @ X8_v5 (System.Int32)]");
				return (Texture)0;
			}
		}

		[Token(Token = "0x1700019A")]
		public Skeleton Skeleton
		{
			[Token(Token = "0x6000556")]
			[Address(RVA = "0x155C060", Offset = "0x155C060", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeleton;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Skeleton;
			}
			[Token(Token = "0x6000557")]
			[Address(RVA = "0x155C068", Offset = "0x155C068", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.skeleton = value;\n\treturn;\n")]
			set
			{
				Skeleton = value;
			}
		}

		[Token(Token = "0x1700019B")]
		public SkeletonData SkeletonData
		{
			[Token(Token = "0x6000558")]
			[Address(RVA = "0x155C070", Offset = "0x155C070", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.skeleton;\n\tv2 = this.skeleton == 0;\n\tif (v2) goto L_0006;\n\treturn v0.data;\nL_0006:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Skeleton skeleton = Skeleton;
				if (Skeleton != null)
				{
					return skeleton.Data;
				}
				return null;
			}
		}

		[Token(Token = "0x1700019C")]
		public bool IsValid
		{
			[Token(Token = "0x6000559")]
			[Address(RVA = "0x1554D80", Offset = "0x1554D80", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.skeleton == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = Skeleton == null;
				return !flag;
			}
		}

		[Token(Token = "0x1700019D")]
		public AnimationState AnimationState
		{
			[Token(Token = "0x600055E")]
			[Address(RVA = "0x155C1C8", Offset = "0x155C1C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.state;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AnimationState;
			}
		}

		[Token(Token = "0x1700019E")]
		public MeshGenerator MeshGenerator
		{
			[Token(Token = "0x600055F")]
			[Address(RVA = "0x155C1D0", Offset = "0x155C1D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.meshGenerator;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MeshGenerator;
			}
		}

		[Token(Token = "0x14000016")]
		public event SkeletonRendererDelegate OnRebuild
		{
			[CompilerGenerated]
			[Token(Token = "0x600055A")]
			[Address(RVA = "0x1556CEC", Offset = "0x1556CEC", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C24]) = v38;\nL_0016:\n\tv42 = this + 0x168;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 360;
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
			[Token(Token = "0x600055B")]
			[Address(RVA = "0x1556C4C", Offset = "0x1556C4C", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C25]) = v38;\nL_0016:\n\tv42 = this + 0x168;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 360;
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

		[Token(Token = "0x14000017")]
		public event SkeletonRendererDelegate OnMeshAndMaterialsUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x600055C")]
			[Address(RVA = "0x155C088", Offset = "0x155C088", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C26]) = v38;\nL_0016:\n\tv42 = this + 0x170;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 368;
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
			[Token(Token = "0x600055D")]
			[Address(RVA = "0x155C128", Offset = "0x155C128", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C27]) = v38;\nL_0016:\n\tv42 = this + 0x170;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonGraphic+SkeletonRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 368;
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

		[Token(Token = "0x14000018")]
		public event UpdateBonesDelegate BeforeApply
		{
			[CompilerGenerated]
			[Token(Token = "0x6000565")]
			[Address(RVA = "0x155C714", Offset = "0x155C714", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C2B]) = v38;\nL_0016:\n\tv42 = this + 0x1A0;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 416;
				Delegate obj2 = this.m_BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x6000566")]
			[Address(RVA = "0x155C7B4", Offset = "0x155C7B4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C2C]) = v38;\nL_0016:\n\tv42 = this + 0x1A0;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 416;
				Delegate obj2 = this.m_BeforeApply;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x14000019")]
		public event UpdateBonesDelegate UpdateLocal
		{
			[CompilerGenerated]
			[Token(Token = "0x6000567")]
			[Address(RVA = "0x155C854", Offset = "0x155C854", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C2D]) = v38;\nL_0016:\n\tv42 = this + 0x1A8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 424;
				Delegate obj2 = this.m_UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x6000568")]
			[Address(RVA = "0x155C8F4", Offset = "0x155C8F4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C2E]) = v38;\nL_0016:\n\tv42 = this + 0x1A8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 424;
				Delegate obj2 = this.m_UpdateLocal;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x1400001A")]
		public event UpdateBonesDelegate UpdateWorld
		{
			[CompilerGenerated]
			[Token(Token = "0x6000569")]
			[Address(RVA = "0x155C994", Offset = "0x155C994", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C2F]) = v38;\nL_0016:\n\tv42 = this + 0x1B0;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 432;
				Delegate obj2 = this.m_UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x600056A")]
			[Address(RVA = "0x155CA34", Offset = "0x155CA34", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C30]) = v38;\nL_0016:\n\tv42 = this + 0x1B0;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 432;
				Delegate obj2 = this.m_UpdateWorld;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x1400001B")]
		public event UpdateBonesDelegate UpdateComplete
		{
			[CompilerGenerated]
			[Token(Token = "0x600056B")]
			[Address(RVA = "0x155CAD4", Offset = "0x155CAD4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C31]) = v38;\nL_0016:\n\tv42 = this + 0x1B8;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 440;
				Delegate obj2 = this.m_UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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
			[Token(Token = "0x600056C")]
			[Address(RVA = "0x155CB74", Offset = "0x155CB74", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.UpdateBonesDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C32]) = v38;\nL_0016:\n\tv42 = this + 0x1B8;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.UpdateBonesDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 440;
				Delegate obj2 = this.m_UpdateComplete;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(UpdateBonesDelegate))
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

		[Token(Token = "0x1400001C")]
		public event MeshGeneratorDelegate OnPostProcessVertices
		{
			[CompilerGenerated]
			[Token(Token = "0x600056D")]
			[Address(RVA = "0x155CC14", Offset = "0x155CC14", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.MeshGeneratorDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C33]) = v38;\nL_0016:\n\tv42 = this + 0x1C0;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.MeshGeneratorDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 448;
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
			[Token(Token = "0x600056E")]
			[Address(RVA = "0x155CCB4", Offset = "0x155CCB4", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = Spine.Unity.MeshGeneratorDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C34]) = v38;\nL_0016:\n\tv42 = this + 0x1C0;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.MeshGeneratorDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v42, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 448;
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

		[Token(Token = "0x6000544")]
		[Address(RVA = "0x155B55C", Offset = "0x155B55C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = UnityEngine.GameObject;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, parent, material, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = UnityEngine.Object;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, parent, material, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv62 = \"New Spine GameObject\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, parent, material, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37C1F]) = v52;\nL_0024:\n\tv54 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v54, \"New Spine GameObject\");\n\tv66 = Spine.Unity.SkeletonGraphic::AddSkeletonGraphicComponent(v54, skeletonDataAsset, material);\n\tgoto L_0038;\n\tv72 = v67;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v72, v64, v65, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_0038:\n\tv78 = UnityEngine.Object::op_Inequality(parent, 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0051;\n\tv89 = UnityEngine.Component::get_transform(v66);\n\tUnityEngine.Transform::SetParent(v89, parent, 0);\nL_0051:\n\treturn v66;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonGraphic NewSkeletonGraphicGameObject(SkeletonDataAsset skeletonDataAsset, Transform parent, Material material)
		{
			GameObject gameObject = new GameObject("New Spine GameObject");
			SkeletonGraphic skeletonGraphic = AddSkeletonGraphicComponent(gameObject, skeletonDataAsset, material);
			if (parent != null)
			{
				Transform transform = skeletonGraphic.transform;
				transform.SetParent(parent, worldPositionStays: false);
			}
			return skeletonGraphic;
		}

		[Token(Token = "0x6000545")]
		[Address(RVA = "0x155B65C", Offset = "0x155B65C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, skeletonDataAsset, material, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, skeletonDataAsset, material, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C20]) = v40;\nL_001F:\n\tv50 = UnityEngine.GameObject::AddComponent(gameObject);\n\tgoto L_002B;\n\tv70 = v65;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v70, v48, material, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_002B:\n\tv59 = UnityEngine.Object::op_Inequality(skeletonDataAsset, 0);\n\tv97 = v59 == 0;\n\tif (v97) goto L_0042;\n\tv106 = UnityEngine.UI.Graphic::set_material(v50, material);\n\tv50.skeletonDataAsset = skeletonDataAsset;\n\tSpine.Unity.SkeletonGraphic::Initialize(v50, 0);\nL_0042:\n\treturn v50;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonGraphic AddSkeletonGraphicComponent(GameObject gameObject, SkeletonDataAsset skeletonDataAsset, Material material)
		{
			SkeletonGraphic skeletonGraphic = gameObject.AddComponent<SkeletonGraphic>();
			if (skeletonDataAsset != null)
			{
				skeletonGraphic.material = material;
				skeletonGraphic.skeletonDataAsset = skeletonDataAsset;
				skeletonGraphic.Initialize(overwrite: false);
			}
			return skeletonGraphic;
		}

		[Token(Token = "0x600054B")]
		[Address(RVA = "0x155B810", Offset = "0x155B810", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.EventSystems.UIBehaviour::Awake(this);\n\tv8 = this.skeleton == 0;\n\tif (v8) goto L_000F;\n\treturn;\nL_000F:\n\tSpine.Unity.SkeletonGraphic::Initialize(this, 0);\n\tv24 = this->klass;\n\tv18 = this->klass->vtable[37];\n\tv15 = this->klass->vtable[37];\n\t// 24 IndirectJump v18 @ X3_v1, this @ X0 (Spine.Unity.SkeletonGraphic), this @ X0 (Spine.Unity.SkeletonGraphic), 3, v15 @ X2_v1, v18 @ X3_v1, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Awake()
		{
			//IL_0036: Expected I, but got O
			//IL_0046: Expected O, but got I
			//IL_0056: Expected O, but got I
			base.Awake();
			if (Skeleton == null)
			{
				Initialize(overwrite: false);
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X8_v2 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+388]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X8_v2 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+390]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v18 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0x155B858", Offset = "0x155B858", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UI.Graphic::Rebuild(this, update);\n\tv13 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv16 = UnityEngine.CanvasRenderer::get_cull(v13);\n\tv68 = v16 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0033;\n\tv22 = update != 3;\n\tif (v22) goto L_0021;\n\tSpine.Unity.SkeletonGraphic::UpdateMesh(this);\nL_0021:\n\tv82 = ~this.allowMultipleCanvasRenderers;\n\tif (v82) goto L_0033;\n\tv52 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::Clear(v52);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Rebuild(CanvasUpdate update)
		{
			base.Rebuild(update);
			CanvasRenderer canvasRenderer = base.canvasRenderer;
			if (!canvasRenderer.cull)
			{
				if (update == CanvasUpdate.PreRender)
				{
					UpdateMesh();
				}
				if (allowMultipleCanvasRenderers)
				{
					CanvasRenderer canvasRenderer2 = base.canvasRenderer;
					canvasRenderer2.Clear();
				}
			}
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0x155B954", Offset = "0x155B954", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv68 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C22]) = v34;\nL_001B:\n\tv37 = 0;\n\tUnityEngine.UI.MaskableGraphic::OnDisable(this);\n\tv44 = this.canvasRenderers == 0;\n\tif (v44) goto L_0040;\n\tv56 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::GetEnumerator(this.canvasRenderers);\nL_002D:\n\tv75 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v37 @ stack_-38_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv77 = v75 == 0;\n\tif (v77) goto L_0039;\n\tUnityEngine.CanvasRenderer::Clear(0);\n\tgoto L_002D;\nL_0039:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_003E:\n\treturn;\n\tv60 = new System.NullReferenceException();\nL_0040:\n\tv66 = new System.NullReferenceException();\n\tgoto L_004D;\n\tgoto L_004D;\nL_004D:\n\tv88 = Il2CppMethodInfo != 1;\n\tif (v88) goto L_005D;\n\tv92 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>+Enumerator<UnityEngine.CanvasRenderer>::MoveNext(v66);\n\tv132 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>+Enumerator<UnityEngine.CanvasRenderer>::MoveNext(v92);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv98 = ~v92.m_value;\n\tif (v98) goto L_003E;\n\tthrow System.OutOfMemoryException;\nL_005D:\n\tgoto L_0063;\n\tX19 = X0;\nL_0063:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v37 @ stack_-38_v1 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_006A;\n\tv158 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>+Enumerator<UnityEngine.CanvasRenderer>::Dispose(v66);\nL_006A:\n\tv161 = new System.OutOfMemoryException();\n\tv149 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>+Enumerator<UnityEngine.CanvasRenderer>::Dispose(v161);\n\treturn;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void OnDisable()
		{
			List<object>.Enumerator enumerator = default(List<object>.Enumerator);
			base.OnDisable();
			if (canvasRenderers != null)
			{
				List<CanvasRenderer>.Enumerator enumerator2 = canvasRenderers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((CanvasRenderer)null).Clear();
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((nint)0 == 1)
			{
				bool flag = ((List<CanvasRenderer>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<CanvasRenderer>.Enumerator*)1) : ((List<CanvasRenderer>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (((bool*)(flag ? 1 : 0))->m_value)
				{
					throw new OutOfMemoryException();
				}
			}
			else
			{
				enumerator.Dispose();
				OutOfMemoryException ex2 = new OutOfMemoryException();
				((List<CanvasRenderer>.Enumerator*)ex2)->Dispose();
			}
		}

		[Token(Token = "0x600054E")]
		[Address(RVA = "0x155BAAC", Offset = "0x155BAAC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = ~this.freeze;\n\tif (v6) goto L_000C;\n\treturn;\nL_000C:\n\tv11 = ~this.unscaledTime;\n\tif (v11) goto L_0012;\n\tv20 = UnityEngine.Time::get_unscaledDeltaTime();\n\tgoto L_0013;\nL_0012:\n\tv20 = UnityEngine.Time::get_deltaTime();\nL_0013:\n\tv29 = this->klass;\n\tv17 = this->klass->vtable[77];\n\tv14 = this->klass->vtable[77];\n\t// 26 IndirectJump v17 @ X2_v1, this @ X0 (Spine.Unity.SkeletonGraphic), this @ X0 (Spine.Unity.SkeletonGraphic), v14 @ X1_v1, v17 @ X2_v1, v35 @ X3, v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v20 @ V0_v1 (System.Single), v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Update()
		{
			//IL_0058: Expected I, but got O
			//IL_0068: Expected O, but got I
			//IL_0078: Expected O, but got I
			if (!freeze)
			{
				if (unscaledTime)
				{
					float unscaledDeltaTime = Time.unscaledDeltaTime;
				}
				else
				{
					float unscaledDeltaTime = Time.deltaTime;
				}
				nint num = (nint)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v3 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+608]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ X8_v3 (Il2CppClass<Spine.Unity.SkeletonGraphic>)+610]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600054F")]
		[Address(RVA = "0x155BAF8", Offset = "0x155BAF8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.skeleton == 0;\n\tif (v6) goto L_0027;\n\tthis.wasUpdatedAfterInit = 1;\n\tv20 = this.updateMode < 1;\n\tif (v20) goto L_0027;\n\tSpine.Unity.SkeletonGraphic::UpdateAnimationStatus(this, deltaTime);\n\tv24 = this.updateMode != 1;\n\tif (v24) goto L_002C;\nL_0027:\n\treturn;\nL_002C:\n\tSpine.Unity.SkeletonGraphic::ApplyAnimation(this);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Update(float deltaTime)
		{
			if (Skeleton == null)
			{
				return;
			}
			wasUpdatedAfterInit = true;
			if (UpdateMode >= UpdateMode.OnlyAnimationStatus)
			{
				Update(deltaTime);
				if (UpdateMode != UpdateMode.OnlyAnimationStatus)
				{
					ApplyAnimation();
				}
			}
		}

		[Token(Token = "0x6000550")]
		[Address(RVA = "0x155BB44", Offset = "0x155BB44", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.timeScale * deltaTime;\n\tSpine.Skeleton::Update(this.skeleton, v12);\n\tSpine.AnimationState::Update(this.state, v12);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void UpdateAnimationStatus(float deltaTime)
		{
			float delta = timeScale * deltaTime;
			Skeleton.Update(delta);
			AnimationState.Update(delta);
		}

		[Token(Token = "0x6000551")]
		[Address(RVA = "0x155BB8C", Offset = "0x155BB8C", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = this.BeforeApply == 0;\n\tif (v7) goto L_001A;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this.BeforeApply, this);\nL_001A:\n\tv46 = this.updateMode != 4;\n\tif (v46) goto L_0020;\n\tv85 = Spine.AnimationState::ApplyEventTimelinesOnly(this.state, this.skeleton);\n\tgoto L_0021;\nL_0020:\n\tv87 = Spine.AnimationState::Apply(this.state, this.skeleton);\nL_0021:\n\t;\n\tv90 = this.UpdateLocal == 0;\n\tif (v90) goto L_002D;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this.UpdateLocal, this);\nL_002D:\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\n\tv130 = this.UpdateWorld == 0;\n\tif (v130) goto L_003B;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this.UpdateWorld, this);\n\tSpine.Skeleton::UpdateWorldTransform(this.skeleton);\nL_003B:\n\t;\n\tv117 = this.UpdateComplete == 0;\n\tif (v117) goto L_0049;\n\tSpine.Unity.UpdateBonesDelegate::Invoke(this.UpdateComplete, this);\nL_0049:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ApplyAnimation()
		{
			if (this.BeforeApply != null)
			{
				this.BeforeApply(this);
			}
			if (UpdateMode == UpdateMode.OnlyEventTimelines)
			{
				bool flag = AnimationState.ApplyEventTimelinesOnly(Skeleton);
			}
			else
			{
				bool flag2 = AnimationState.Apply(Skeleton);
			}
			if (this.UpdateLocal != null)
			{
				this.UpdateLocal(this);
			}
			Skeleton.UpdateWorldTransform();
			if (this.UpdateWorld != null)
			{
				this.UpdateWorld(this);
				Skeleton.UpdateWorldTransform();
			}
			if (this.UpdateComplete != null)
			{
				this.UpdateComplete(this);
			}
		}

		[Token(Token = "0x6000552")]
		[Address(RVA = "0x155BC60", Offset = "0x155BC60", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = ~this.wasUpdatedAfterInit;\n\tv8 = ~v7;\n\tif (v8) goto L_000F;\n\tv14 = Spine.Unity.SkeletonGraphic::Update(this, 0f);\nL_000F:\n\tv37 = ~this.freeze;\n\tv38 = ~v37;\n\tif (v38) goto L_0027;\n\tv49 = this.updateMode != 3;\n\tif (v49) goto L_0027;\n\tSpine.Unity.SkeletonGraphic::UpdateMesh(this);\n\treturn;\nL_0027:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LateUpdate()
		{
			if (!wasUpdatedAfterInit)
			{
				Update(0f);
			}
			if (!freeze && UpdateMode == UpdateMode.FullUpdate)
			{
				UpdateMesh();
			}
		}

		[Token(Token = "0x6000553")]
		[Address(RVA = "0x155BCB0", Offset = "0x155BCB0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = 3;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBecameVisible()
		{
			UpdateMode = UpdateMode.FullUpdate;
		}

		[Token(Token = "0x6000554")]
		[Address(RVA = "0x155BCBC", Offset = "0x155BCBC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.updateMode = this.updateWhenInvisible;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBecameInvisible()
		{
			UpdateMode = updateWhenInvisible;
		}

		[Token(Token = "0x6000555")]
		[Address(RVA = "0x155BCC8", Offset = "0x155BCC8", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = \"\";\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37C23]) = v42;\nL_001B:\n\tv44 = this.skeleton == 0;\n\tif (v44) goto L_00AD;\n\tv48 = this.separatorSlots;\n\tv61 = v48._version + 1;\n\tv48._size = 0;\n\tv48._version = v61;\n\tv72 = v48._size < 1;\n\tif (v72) goto L_0035;\n\tSystem.Array::Clear(v48._items, 0, v48._size);\nL_0035:\n\tv220 = this.separatorSlotNames;\n\tv103 = v220.Length < 1;\n\tif (v103) goto L_00A3;\n\tv87 = v220.Length & 0xFFFFFFFF;\nL_005C:\n\tv261 = System.String::op_Equality(v220[v90 @ X21_v6 (System.Int32)], \"\");\n\tv263 = v261 == 0;\n\tv264 = ~v263;\n\tif (v264) goto L_008A;\n\tv287 = Spine.Skeleton::FindSlot(this.skeleton, v220[v90 @ X21_v6 (System.Int32)]);\n\tv288 = v287 == 0;\n\tif (v288) goto L_008A;\n\tv150 = this.separatorSlots;\n\tv161 = v150._items;\n\tv81 = v150._version + 1;\n\tv150._version = v81;\n\tv266 = v150._size;\n\tv294 = v150._size < v161.Length;\n\tv284 = ~v294;\n\tif (v284) goto L_0089;\n\tv285 = v150._size + 1;\n\tv150._size = v285;\n\tv161[v266 @ X10_v7 (System.Int32)] = v287;\n\tgoto L_008A;\nL_0089:\n\tSystem.Collections.Generic.List`1<Spine.Slot>::AddWithResize(v150, v287);\nL_008A:\n\tv90 = v90 + 1;\n\tv122 = v87 == v90;\n\tif (v122) goto L_00A3;\n\tv220 = this.separatorSlotNames;\n\tv292 = this.separatorSlotNames == 0;\n\tv152 = ~v292;\n\tif (v152) goto L_005C;\n\tthrow System.NullReferenceException;\nL_00A3:\n\tSpine.Unity.SkeletonGraphic::UpdateSeparatorPartParents(this);\n\treturn;\nL_00AD:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ReapplySeparatorSlotNames()
		{
			//IL_00c9: Expected I4, but got I8
			if (Skeleton == null)
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
			if (array.Length >= 1)
			{
				int num = (int)(array.Length & 0xFFFFFFFFL);
				int num2 = 0;
				while (true)
				{
					if (!(array[num2] == ""))
					{
						Slot slot = Skeleton.FindSlot(array[num2]);
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
					}
					num2++;
					if (num == num2)
					{
						break;
					}
					array = separatorSlotNames;
					if (separatorSlotNames == null)
					{
						throw new NullReferenceException();
					}
				}
			}
			Update();
		}

		[Token(Token = "0x6000560")]
		[Address(RVA = "0x155C1D8", Offset = "0x155C1D8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37C28]) = v33;\nL_0016:\n\tv39 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetCurrent(this.meshBuffers);\n\treturn v39.mesh;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Mesh GetLastMesh()
		{
			MeshRendererBuffers.SmartMesh current = meshBuffers.GetCurrent();
			return current.mesh;
		}

		[Token(Token = "0x6000561")]
		[Address(RVA = "0x155C234", Offset = "0x155C234", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonGraphic::UpdateMesh(this);\n\tv8 = ~this.allowMultipleCanvasRenderers;\n\tif (v8) goto L_0012;\n\treturnVal1 = Spine.Unity.SkeletonGraphic::MatchRectTransformMultipleRenderers(this);\n\treturn returnVal1;\nL_0012:\n\treturnVal2 = Spine.Unity.SkeletonGraphic::MatchRectTransformSingleRenderer(this);\n\treturn returnVal2;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool MatchRectTransformWithBounds()
		{
			UpdateMesh();
			if (allowMultipleCanvasRenderers)
			{
				return MatchRectTransformMultipleRenderers();
			}
			return MatchRectTransformSingleRenderer();
		}

		[Token(Token = "0x6000562")]
		[Address(RVA = "0x155C260", Offset = "0x155C260", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C29]) = v37;\nL_0014:\n\tv39 = Spine.Unity.SkeletonGraphic::GetLastMesh(this);\n\tgoto L_0020;\n\tv45 = v40;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(v39, 0);\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_FFFFFFFF;\n\tv77 = UnityEngine.Mesh::get_vertexCount(v39);\n\tv126 = v77 == 0;\n\tif (v126) goto L_0044;\n\tUnityEngine.Mesh::RecalculateBounds(v39);\n\tv159 = UnityEngine.Mesh::get_bounds(v39);\n\tv120 = v159.m_Center;\n\tSpine.Unity.SkeletonGraphic::SetRectTransformBounds(this, &v120 @ stack_-38_v2 (UnityEngine.Vector3));\n\tgoto L_005D;\nL_0044:\n\tv87 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\t// 75 MakeStruct v60 @ AGG1560340_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 1112014848, 1112014848\n\tUnityEngine.RectTransform::set_sizeDelta(v87, v60);\n\tv69 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\t// 85 MakeStruct v57 @ AGG1560360_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_pivot(v69, v57);\nL_005D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe bool MatchRectTransformSingleRenderer()
		{
			//IL_0097: Expected O, but got Ref
			Mesh lastMesh = GetLastMesh();
			if (!(lastMesh == null))
			{
				if (lastMesh.vertexCount != 0)
				{
					lastMesh.RecalculateBounds();
					Vector3 center = lastMesh.bounds.m_Center;
					SetRectTransformBounds((Bounds)(&center));
					return true;
				}
				RectTransform rectTransform = base.rectTransform;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = 50f;
				sizeDelta.y = 50f;
				rectTransform.sizeDelta = sizeDelta;
				RectTransform rectTransform2 = base.rectTransform;
				Vector2 pivot = default(Vector2);
				pivot.x = 0.5f;
				pivot.y = 0.5f;
				rectTransform2.pivot = pivot;
			}
			return false;
		}

		[Token(Token = "0x6000563")]
		[Address(RVA = "0x155C37C", Offset = "0x155C37C", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv336 = UnityEngine.Object;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v336, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A37C2A]) = v56;\nL_0021:\n\tv348 = this.canvasRenderers;\nL_003B:\n\tv82 = v332 >= v348._size;\n\tif (v82) goto L_0188;\n\tv307 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(v348, v332);\n\tv308 = UnityEngine.Component::get_gameObject(v307);\n\tv309 = UnityEngine.GameObject::get_activeSelf(v308);\n\tv472 = v309 == 0;\n\tif (v472) goto L_FFFFFFFF;\n\tv325 = this.meshes;\n\tv326 = v325.Items;\n\tgoto L_0068;\n\tv543 = \"il2cpp_codegen_runtime_class_init\"(v540, v262, v268, v40, v41, v42, v43, v44, v139, v144, v149, v153, v157, v161, v135, v126);\nL_0068:\n\tv310 = UnityEngine.Object::op_Equality(v326[v332 @ X20_v6 (System.Int32)], 0);\n\tv547 = v310 == 0;\n\tv490 = ~v547;\n\tif (v490) goto L_FFFFFFFF;\n\tv488 = UnityEngine.Mesh::get_vertexCount(v326[v332 @ X20_v6 (System.Int32)]);\n\tv491 = v488 == 0;\n\tif (v491) goto L_FFFFFFFF;\n\tUnityEngine.Mesh::RecalculateBounds(v326[v332 @ X20_v6 (System.Int32)]);\n\tv534 = UnityEngine.Mesh::get_bounds(v326[v332 @ X20_v6 (System.Int32)]);\n\tv558 = v298 & 1;\n\tv536 = v558 == 0;\n\tif (v536) goto L_FFFFFFFF;\n\tv646 = v534.m_Center - v534.m_Extents;\n\tv560 = v295 - v281;\n\tv662 = *([v534 @ X0_v29 (UnityEngine.Bounds)+4]) - *([v534 @ X0_v29 (UnityEngine.Bounds)+10]);\n\tv562 = v289 - v277;\n\tv679 = *([v534 @ X0_v29 (UnityEngine.Bounds)+8]) - *([v534 @ X0_v29 (UnityEngine.Bounds)+14]);\n\tv573 = v285 - v273;\n\tv765 = *([v534 @ X0_v29 (UnityEngine.Bounds)+8]) + *([v534 @ X0_v29 (UnityEngine.Bounds)+14]);\n\tv575 = v560 >= v646;\n\tif (v575) goto L_FFFFFFFF;\n\tgoto L_00A9;\nL_00A9:\n\tv580 = v281 + v295;\n\tv760 = *([v534 @ X0_v29 (UnityEngine.Bounds)+4]) + *([v534 @ X0_v29 (UnityEngine.Bounds)+10]);\n\tv613 = v562 >= v662;\n\tif (v613) goto L_FFFFFFFF;\n\tgoto L_00BA;\nL_00BA:\n\tv579 = v277 + v289;\n\tv744 = v534.m_Center + v534.m_Extents;\n\tv627 = v573 >= v679;\n\tif (v627) goto L_FFFFFFFF;\n\tgoto L_00C4;\nL_00C4:\n\tv633 = v580 - v646;\n\tv634 = v633 < 0;\n\tv635 = v633 == 0;\n\tv636 = v580 ^ v646;\n\tv637 = v580 ^ v633;\n\tv638 = v636 & v637;\n\tv639 = v638 < 0;\n\tv578 = v273 + v285;\n\tv640 = v634 == v639;\n\tv641 = ~v635;\n\tv642 = v640 & v641;\n\tv643 = ~v642;\n\tif (v643) goto L_00D7;\n\tgoto L_00D7;\nL_00D7:\n\tv649 = v579 - v662;\n\tv650 = v649 < 0;\n\tv651 = v649 == 0;\n\tv652 = v579 ^ v662;\n\tv653 = v579 ^ v649;\n\tv654 = v652 & v653;\n\tv655 = v654 < 0;\n\tv656 = v650 == v655;\n\tv657 = ~v651;\n\tv658 = v656 & v657;\n\tv659 = ~v658;\n\tif (v659) goto L_00E9;\n\tgoto L_00E9;\nL_00E9:\n\tv665 = v578 - v679;\n\tv666 = v665 < 0;\n\tv667 = v665 == 0;\n\tv668 = v578 ^ v679;\n\tv669 = v578 ^ v665;\n\tv670 = v668 & v669;\n\tv671 = v670 < 0;\n\tv672 = v646 - v602;\n\tv673 = v666 == v671;\n\tv674 = ~v667;\n\tv675 = v673 & v674;\n\tv676 = ~v675;\n\tif (v676) goto L_00FA;\n\tgoto L_00FA;\nL_00FA:\n\tv680 = v662 - v616;\n\tv681 = v672 * 0.5f;\n\tv682 = v679 - v630;\n\tv683 = v680 * 0.5f;\n\tv684 = v602 + v681;\n\tv582 = v682 * 0.5f;\n\tv685 = v616 + v683;\n\tv584 = v684 - v681;\n\tv687 = v681 + v684;\n\tv688 = v630 + v582;\n\tv585 = v685 - v683;\n\tv699 = v683 + v685;\n\tv583 = v688 - v582;\n\tv701 = v584 >= v744;\n\tif (v701) goto L_FFFFFFFF;\n\tgoto L_011F;\nL_011F:\n\tv713 = v585 >= v760;\n\tif (v713) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_012E:\n\tv725 = v583 >= v765;\n\tif (v725) goto L_FFFFFFFF;\n\tgoto L_0136;\nL_0136:\n\tv730 = v687 - v744;\n\tv731 = v730 < 0;\n\tv732 = v730 == 0;\n\tv733 = v687 ^ v744;\n\tv734 = v687 ^ v730;\n\tv735 = v733 & v734;\n\tv736 = v735 < 0;\n\tv737 = v582 + v688;\n\tv738 = v731 == v736;\n\tv739 = ~v732;\n\tv740 = v738 & v739;\n\tv741 = ~v740;\n\tif (v741) goto L_0149;\n\tgoto L_0149;\nL_0149:\n\tv747 = v699 - v760;\n\tv748 = v747 < 0;\n\tv749 = v747 == 0;\n\tv750 = v699 ^ v760;\n\tv751 = v699 ^ v747;\n\tv752 = v750 & v751;\n\tv753 = v752 < 0;\n\tv754 = v748 == v753;\n\tv755 = ~v749;\n\tv756 = v754 & v755;\n\tv757 = ~v756;\n\tif (v757) goto L_015B;\n\tgoto L_015B;\nL_015B:\n\tv598 = v737 - v765;\n\tv597 = v598 < 0;\n\tv596 = v598 == 0;\n\tv595 = v737 ^ v765;\n\tv594 = v737 ^ v598;\n\tv593 = v595 & v594;\n\tv592 = v593 < 0;\n\tv762 = v597 == v592;\n\tv576 = ~v596;\n\tv577 = v762 & v576;\n\tv581 = ~v577;\n\tif (v581) goto L_016B;\n\tgoto L_016B;\nL_016B:\n\tv766 = v744 - v584;\n\tv767 = v760 - v585;\n\tv768 = v765 - v583;\n\tv588 = v766 * 0.5f;\n\tv143 = v767 * 0.5f;\n\tv138 = v768 * 0.5f;\n\tv591 = v584 + v588;\n\tv156 = v585 + v143;\n\tv152 = v583 + v138;\n\tgoto L_017C;\nL_017C:\n\tv348 = this.canvasRenderers;\n\tv332 = v332 + 1;\n\tv538 = this.canvasRenderers == 0;\n\tv314 = ~v538;\n\tif (v314) goto L_003B;\n\tthrow System.NullReferenceException;\nL_0188:\n\tv355 = v298 & 1;\n\tv356 = v355 == 0;\n\tif (v356) goto L_0197;\n\tSpine.Unity.SkeletonGraphic::SetRectTransformBounds(this, &v295 @ V9_v5 (UnityEngine.Vector3));\n\tgoto L_01AA;\nL_0197:\n\tv311 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\t// 414 MakeStruct v103 @ AGG156064C_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 1112014848, 1112014848\n\tUnityEngine.RectTransform::set_sizeDelta(v311, v103);\n\tv312 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\t// 424 MakeStruct v367 @ AGG156066C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 0.5f\n\tUnityEngine.RectTransform::set_pivot(v312, v367);\nL_01AA:\n\treturnVal1 = v298 & 1;\n\treturn returnVal1;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe bool MatchRectTransformMultipleRenderers()
		{
			//IL_0411: Expected O, but got Ref
			//IL_019f: Expected F4, but got I
			//IL_01af: Expected F4, but got I
			//IL_01cc: Expected F4, but got I
			//IL_01dc: Expected F4, but got I
			//IL_05a6: Expected O, but got F4
			//IL_05b3: Expected O, but got F4
			//IL_065d: Expected I4, but got F4
			//IL_066a: Expected I4, but got F4
			//IL_0703: Expected I4, but got F4
			//IL_0710: Expected I4, but got F4
			//IL_08e1: Expected O, but got F4
			//IL_08ee: Expected O, but got F4
			//IL_0998: Expected O, but got F4
			//IL_09a5: Expected O, but got F4
			//IL_0a40: Expected O, but got F4
			//IL_0a4d: Expected O, but got F4
			//IL_0b3c: Expected O, but got F4
			//IL_0b44: Expected O, but got F4
			List<CanvasRenderer> list = canvasRenderers;
			float num = 0f;
			float num2 = 0f;
			Vector3 vector = default(Vector3);
			float num3 = 0f;
			float num4 = 0f;
			Vector3 vector2 = default(Vector3);
			int num5 = 0;
			int num6 = 0;
			while (num6 < list.Count)
			{
				Component component = list[num6];
				GameObject gameObject = component.gameObject;
				float num8;
				float num9;
				Vector3 vector3;
				float num10;
				float num11;
				Vector3 vector4;
				if (gameObject.activeSelf)
				{
					ExposedList<Mesh> exposedList = meshes;
					Mesh[] items = exposedList.Items;
					if (!(items[num6] == null) && items[num6].vertexCount != 0)
					{
						items[num6].RecalculateBounds();
						Bounds bounds = items[num6].bounds;
						int num7 = num5 & 1;
						bool flag = num7 == 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+14]");
						num8 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+10]");
						num9 = 0f;
						vector3 = bounds.m_Extents;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+8]");
						num10 = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+4]");
						num11 = 0f;
						vector4 = bounds.m_Center;
						if (!flag)
						{
							float num12 = bounds.m_Center.x - bounds.m_Extents.x;
							float num13 = vector2.x - vector.x;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+4]");
							float num14 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+10]");
							float num15 = num14 - 0f;
							float num16 = num4 - num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+8]");
							float num17 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+14]");
							float num18 = num17 - 0f;
							float num19 = num3 - num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+8]");
							float num20 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+14]");
							float num21 = num20 + 0f;
							float num22 = ((!(num13 < num12)) ? num12 : num13);
							float num23 = vector.x + vector2.x;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+4]");
							float num24 = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v534 @ X0_v29 (UnityEngine.Bounds)+10]");
							float num25 = num24 + 0f;
							float num26 = ((!(num16 < num15)) ? num15 : num16);
							float num27 = num2 + num4;
							float num28 = bounds.m_Center.x + bounds.m_Extents.x;
							float num29 = ((!(num19 < num18)) ? num18 : num19);
							float num30 = num23 - num12;
							bool flag2 = num30 < 0f;
							bool flag3 = num30 == 0f;
							object obj = num23 ^ num12;
							object obj2 = num23 ^ num30;
							int num31 = (int)((nint)obj & (nint)obj2);
							bool flag4 = num31 < 0;
							float num32 = num + num3;
							bool flag5 = flag2 == flag4;
							bool flag6 = !flag3;
							if (flag5 && flag6)
							{
								num12 = num23;
							}
							float num33 = num27 - num15;
							bool flag7 = num33 < 0f;
							bool flag8 = num33 == 0f;
							int num34 = num27 ^ num15;
							int num35 = num27 ^ num33;
							int num36 = num34 & num35;
							bool flag9 = num36 < 0;
							bool flag10 = flag7 == flag9;
							bool flag11 = !flag8;
							if (flag10 && flag11)
							{
								num15 = num27;
							}
							float num37 = num32 - num18;
							bool flag12 = num37 < 0f;
							bool flag13 = num37 == 0f;
							int num38 = num32 ^ num18;
							int num39 = num32 ^ num37;
							int num40 = num38 & num39;
							bool flag14 = num40 < 0;
							float num41 = num12 - num22;
							bool flag15 = flag12 == flag14;
							bool flag16 = !flag13;
							if (flag15 && flag16)
							{
								num18 = num32;
							}
							float num42 = num15 - num26;
							float num43 = num41 * 0.5f;
							float num44 = num18 - num29;
							float num45 = num42 * 0.5f;
							float num46 = num22 + num43;
							float num47 = num44 * 0.5f;
							float num48 = num26 + num45;
							float num49 = num46 - num43;
							float num50 = num43 + num46;
							float num51 = num29 + num47;
							float num52 = num48 - num45;
							float num53 = num45 + num48;
							float num54 = num51 - num47;
							if (!(num49 < num28))
							{
								num49 = num28;
							}
							if (!(num52 < num25))
							{
								num52 = num25;
							}
							if (!(num54 < num21))
							{
								num54 = num21;
							}
							float num55 = num50 - num28;
							bool flag17 = num55 < 0f;
							bool flag18 = num55 == 0f;
							object obj3 = num50 ^ num28;
							object obj4 = num50 ^ num55;
							int num56 = (int)((nint)obj3 & (nint)obj4);
							bool flag19 = num56 < 0;
							float num57 = num47 + num51;
							bool flag20 = flag17 == flag19;
							bool flag21 = !flag18;
							if (flag20 && flag21)
							{
								num28 = num50;
							}
							float num58 = num53 - num25;
							bool flag22 = num58 < 0f;
							bool flag23 = num58 == 0f;
							object obj5 = num53 ^ num25;
							object obj6 = num53 ^ num58;
							int num59 = (int)((nint)obj5 & (nint)obj6);
							bool flag24 = num59 < 0;
							bool flag25 = flag22 == flag24;
							bool flag26 = !flag23;
							if (flag25 && flag26)
							{
								num25 = num53;
							}
							float num60 = num57 - num21;
							bool flag27 = num60 < 0f;
							bool flag28 = num60 == 0f;
							object obj7 = num57 ^ num21;
							object obj8 = num57 ^ num60;
							int num61 = (int)((nint)obj7 & (nint)obj8);
							bool flag29 = num61 < 0;
							bool flag30 = flag27 == flag29;
							bool flag31 = !flag28;
							if (flag30 && flag31)
							{
								num21 = num57;
							}
							float num62 = num28 - num49;
							float num63 = num25 - num52;
							float num64 = num21 - num54;
							float num65 = num62 * 0.5f;
							num9 = num63 * 0.5f;
							num8 = num64 * 0.5f;
							float num66 = num49 + num65;
							num11 = num52 + num9;
							num10 = num54 + num8;
							vector3 = (Vector3)num65;
							vector4 = (Vector3)num66;
						}
						num5 = 1;
						goto IL_0b6d;
					}
				}
				num8 = num;
				num9 = num2;
				vector3 = vector;
				num10 = num3;
				num11 = num4;
				vector4 = vector2;
				goto IL_0b6d;
				IL_0b6d:
				list = canvasRenderers;
				num6++;
				bool flag32 = canvasRenderers == null;
				bool flag33 = !flag32;
				vector2 = vector4;
				num = num8;
				num2 = num9;
				vector = vector3;
				num3 = num10;
				num4 = num11;
				vector2 = vector4;
				if (!flag33)
				{
					throw new NullReferenceException();
				}
			}
			if ((num5 & 1) != 0)
			{
				SetRectTransformBounds((Bounds)(&vector2));
			}
			else
			{
				RectTransform rectTransform = base.rectTransform;
				Vector2 sizeDelta = default(Vector2);
				sizeDelta.x = 50f;
				sizeDelta.y = 50f;
				rectTransform.sizeDelta = sizeDelta;
				RectTransform rectTransform2 = base.rectTransform;
				Vector2 pivot = default(Vector2);
				pivot.x = 0.5f;
				pivot.y = 0.5f;
				rectTransform2.pivot = pivot;
			}
			return (byte)(num5 & 1) != 0;
		}

		[Token(Token = "0x6000564")]
		[Address(RVA = "0x155C6A0", Offset = "0x155C6A0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv16 = combinedBounds.m_Extents + combinedBounds.m_Extents;\n\t// 16 MakeStruct v21 @ AGG15606D4_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v16 @ V0_v2 (System.Single), v18 @ V0.S1\n\tUnityEngine.RectTransform::set_sizeDelta(v14, v21);\n\tv33 = UnityEngine.UI.Graphic::get_rectTransform(this);\n\tv73 = combinedBounds.m_Center / v16;\n\tv60 = 0x3F - v73;\n\t// 34 MakeStruct v51 @ AGG156070C_1_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v60 @ V0_v5 (System.Single), v18 @ V0.S1\n\tUnityEngine.RectTransform::set_pivot(v33, v51);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetRectTransformBounds(Bounds combinedBounds)
		{
			//IL_004c: Expected F4, but got O
			//IL_00ab: Expected F4, but got O
			RectTransform rectTransform = base.rectTransform;
			Vector2 sizeDelta = default(Vector2);
			float num = (sizeDelta.x = combinedBounds.m_Extents.x + combinedBounds.m_Extents.x);
			object obj = default(object);
			sizeDelta.y = (float)obj;
			rectTransform.sizeDelta = sizeDelta;
			RectTransform rectTransform2 = base.rectTransform;
			float num2 = combinedBounds.m_Center.x / num;
			float x = 8.8E-44f - num2;
			Vector2 pivot = default(Vector2);
			pivot.x = x;
			pivot.y = (float)obj;
			rectTransform2.pivot = pivot;
		}

		[Token(Token = "0x600056F")]
		[Address(RVA = "0x155CD54", Offset = "0x155CD54", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv146 = Il2CppMethodInfo;\n\tv147 = \"il2cpp_codegen_initialize_runtime_metadata\"(v146, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv155 = Il2CppMethodInfo;\n\tv156 = \"il2cpp_codegen_initialize_runtime_metadata\"(v155, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv168 = Il2CppMethodInfo;\n\tv169 = \"il2cpp_codegen_initialize_runtime_metadata\"(v168, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv198 = UnityEngine.Object;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37C35]) = v46;\nL_002D:\n\tv49 = 0;\n\tthis.skeleton = 0;\n\tv52 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::Clear(v52);\n\tv151 = this.canvasRenderers;\nL_0050:\n\tv62 = v141 >= v151._size;\n\tif (v62) goto L_0064;\n\tv126 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(v151, v141);\n\tUnityEngine.CanvasRenderer::Clear(v126);\n\tv151 = this.canvasRenderers;\n\tv141 = v141 + 1;\n\tv204 = this.canvasRenderers == 0;\n\tv130 = ~v204;\n\tif (v130) goto L_0050;\n\tthrow System.NullReferenceException;\nL_0064:\n\tv166 = Spine.ExposedList`1<UnityEngine.Mesh>::GetEnumerator(this.meshes);\nL_0067:\n\tv191 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v49 @ stack_-68_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv196 = v191 == 0;\n\tif (v196) goto L_0078;\n\tgoto L_0074;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v199, v189, v99, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0074:\n\tUnityEngine.Object::Destroy(0);\n\tgoto L_0067;\nL_0078:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v49 @ stack_-68_v1 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0079:\n\t;\n\tSpine.ExposedList`1<UnityEngine.Mesh>::Clear(this.meshes, 1);\n\treturn;\n\tgoto L_008B;\nL_008B:\n\tX21 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00A2;\n\tX0 = X21;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = *([X23]);\n\tX0 = &stack[8];\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_0079;\n\tX0 = X20;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A2:\n\tX20 = 0;\n\tgoto L_00A5;\n\tX21 = X0;\nL_00A5:\n\tX1 = *([X23]);\n\tX0 = &stack[8];\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AD;\n\tX0 = X21;\n\tX0 = 0xBD3CD0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AD:\n\tX0 = X20;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = 0x9DACB4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			ExposedList<object>.Enumerator enumerator = default(ExposedList<object>.Enumerator);
			Skeleton = null;
			CanvasRenderer canvasRenderer = base.canvasRenderer;
			canvasRenderer.Clear();
			List<CanvasRenderer> list = canvasRenderers;
			int num = 0;
			while (num < list.Count)
			{
				CanvasRenderer canvasRenderer2 = list[num];
				canvasRenderer2.Clear();
				list = canvasRenderers;
				num++;
				if (canvasRenderers == null)
				{
					throw new NullReferenceException();
				}
			}
			ExposedList<Mesh>.Enumerator enumerator2 = meshes.GetEnumerator();
			while (enumerator.MoveNext())
			{
				UnityEngine.Object.Destroy(null);
			}
			enumerator.Dispose();
			meshes.Clear();
		}

		[Token(Token = "0x6000570")]
		[Address(RVA = "0x155CF64", Offset = "0x155CF64", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv30 = UnityEngine.Application;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv148 = Il2CppMethodInfo;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv153 = Il2CppMethodInfo;\n\tv154 = \"il2cpp_codegen_initialize_runtime_metadata\"(v153, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv208 = Il2CppMethodInfo;\n\tv209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv224 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>;\n\tv225 = \"il2cpp_codegen_initialize_runtime_metadata\"(v224, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv233 = UnityEngine.Object;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v233, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37C36]) = v50;\nL_0036:\n\tv55 = new System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::.ctor(v55);\n\tv65 = this.canvasRenderers == 0;\n\tif (v65) goto L_00CA;\n\tv84 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::GetEnumerator(this.canvasRenderers);\nL_0052:\n\tv195 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v83 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv211 = v195 == 0;\n\tif (v211) goto L_00B9;\n\tv236 = UnityEngine.Component::get_gameObject(v151);\n\tv177 = UnityEngine.GameObject::get_activeSelf(v236);\n\tv328 = v177 == 0;\n\tif (v328) goto L_0082;\n\tv331 = v55._items;\n\tv329 = v55._version + 1;\n\tv55._version = v329;\n\tv170 = v55._size;\n\tv341 = v55._size < v331.Length;\n\tv164 = ~v341;\n\tif (v164) goto L_00A7;\n\tv167 = v55._size + 1;\n\tv55._size = v167;\n\tv331[v170 @ X10_v7 (System.Int32)] = v151;\n\tgoto L_0052;\nL_0082:\n\tgoto L_0085;\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v332, v172, v86, v34, v35, v36, v37, v38, v128, v40, v41, v42, v43, v44, v45, v46);\nL_0085:\n\tv340 = UnityEngine.Application::get_isEditor();\n\tv343 = v340 == 0;\n\tif (v343) goto L_0096;\n\tgoto L_0090;\n\tv357 = \"il2cpp_codegen_runtime_class_init\"(v345, v172, v86, v34, v35, v36, v37, v38, v128, v40, v41, v42, v43, v44, v45, v46);\nL_0090:\n\tv350 = UnityEngine.Application::get_isPlaying();\n\tv352 = v350 == 0;\n\tif (v352) goto L_00AB;\nL_0096:\n\tv356 = UnityEngine.Component::get_gameObject(v151);\n\tgoto L_00A0;\n\tv363 = \"il2cpp_codegen_runtime_class_init\"(v360, v355, v86, v34, v35, v36, v37, v38, v128, v40, v41, v42, v43, v44, v45, v46);\nL_00A0:\n\tUnityEngine.Object::Destroy(v356);\n\tgoto L_0052;\nL_00A7:\n\tSystem.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::AddWithResize(v55, v151);\n\tgoto L_0052;\nL_00AB:\n\tv367 = UnityEngine.Component::get_gameObject(v151);\n\tgoto L_00B5;\n\tv370 = \"il2cpp_codegen_runtime_class_init\"(v368, v366, v86, v34, v35, v36, v37, v38, v128, v40, v41, v42, v43, v44, v45, v46);\nL_00B5:\n\tUnityEngine.Object::DestroyImmediate(v367);\n\tgoto L_0052;\nL_00B9:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v83 @ stack_-88_v3 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_00BA:\n\tthis.canvasRenderers = v55;\n\treturn;\n\tv237 = new System.NullReferenceException();\n\tv283 = new System.NullReferenceException();\n\tv325 = new System.NullReferenceException();\n\tv138 = new System.NullReferenceException();\nL_00CA:\n\tv146 = new System.NullReferenceException();\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\n\tgoto L_00E0;\nL_00E0:\n\tv206 = v135 != 1;\n\tif (v206) goto L_00EE;\n\tv213 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::.ctor(v146);\n\tv229 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::.ctor(v213);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v125 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv219 = *([v213 @ X0_v16 (System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>)]) == 0;\n\tif (v219) goto L_00BA;\n\tthrow System.OutOfMemoryException;\nL_00EE:\n\tgoto L_00F2;\n\tX21 = X0;\nL_00F2:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v125 @ stack_-70_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00F9;\n\tv317 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::AddWithResize(v146, *([v131 @ X23_v1 (Il2CppMethodInfo)]));\nL_00F9:\n\tv320 = new System.OutOfMemoryException();\n\tv309 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::AddWithResize(v320, *([v131 @ X23_v1 (Il2CppMethodInfo)]));\n\treturn;\n// 151 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TrimRenderers()
		{
			//IL_0248: Expected O, but got I
			List<CanvasRenderer> list = new List<CanvasRenderer>();
			bool flag = canvasRenderers == null;
			List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
			List<object>.Enumerator enumerator = enumerator2;
			nint num = 0;
			if (!flag)
			{
				List<CanvasRenderer>.Enumerator enumerator3 = canvasRenderers.GetEnumerator();
				Component component = default(Component);
				while (enumerator2.MoveNext())
				{
					GameObject gameObject = component.gameObject;
					if (gameObject.activeSelf)
					{
						CanvasRenderer[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = (CanvasRenderer)component;
						}
						else
						{
							list.Add((CanvasRenderer)component);
						}
					}
					else if (!Application.isEditor || Application.isPlaying)
					{
						GameObject obj = component.gameObject;
						UnityEngine.Object.Destroy(obj);
					}
					else
					{
						GameObject obj2 = component.gameObject;
						UnityEngine.Object.DestroyImmediate(obj2);
					}
				}
				enumerator2.Dispose();
			}
			else
			{
				NullReferenceException ex = (NullReferenceException)(object)new List<CanvasRenderer>();
				IntPtr intPtr = default(IntPtr);
				if (intPtr != (IntPtr)1)
				{
					enumerator.Dispose();
					OutOfMemoryException ex2 = new OutOfMemoryException();
					((List<CanvasRenderer>)(object)ex2).Add((CanvasRenderer)num);
					return;
				}
				enumerator.Dispose();
				List<CanvasRenderer> list2 = default(List<CanvasRenderer>);
				if (list2 != null)
				{
					throw new OutOfMemoryException();
				}
			}
			canvasRenderers = list;
		}

		[Token(Token = "0x6000571")]
		[Address(RVA = "0x1556D94", Offset = "0x1556D94", Length = "0x3A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv20 = Spine.AnimationState;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv160 = UnityEngine.Object;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv239 = Spine.Skeleton;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v239, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 1;\n\t*([1A37C37]) = v39;\nL_0020:\n\tv41 = this.skeleton == 0;\n\tif (v41) goto L_002C;\n\tv46 = overwrite == 0;\n\tif (v46) goto L_0168;\nL_002C:\n\tgoto L_0031;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v51, overwrite, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0031:\n\tv132 = UnityEngine.Object::op_Equality(this.skeletonDataAsset, 0);\n\tv237 = v132 == 0;\n\tv137 = ~v237;\n\tif (v137) goto L_0168;\n\tv133 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 0);\n\tv138 = v133 == 0;\n\tif (v138) goto L_0168;\n\tv384 = this.skeletonDataAsset;\n\tv146 = v384.atlasAssets;\n\tv139 = v146.Length == 0;\n\tif (v139) goto L_0168;\n\tv134 = Spine.Unity.AtlasAssetBase::get_MaterialCount(v146[0]);\n\tv84 = v134 < 1;\n\tif (v84) goto L_0168;\n\tv266 = this.skeletonDataAsset;\n\tv440 = v266.stateData;\n\tv433 = v266.stateData == 0;\n\tv434 = ~v433;\n\tif (v434) goto L_006A;\n\tv437 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(v266, 0);\n\tv440 = v266.stateData;\nL_006A:\n\tv444 = new Spine.AnimationState();\n\tSpine.AnimationState::.ctor(v444, v440);\n\tthis.state = v444;\n\tv220 = v444 == 0;\n\tif (v220) goto L_0170;\n\tv345 = new Spine.Skeleton();\n\tSpine.Skeleton::.ctor(v345, v133);\n\tif (this.initialFlipX) goto L_FFFFFFFF;\n\tgoto L_008F;\nL_008F:\n\tv345.scaleX = v256;\n\tif (this.initialFlipY) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv345.scaleY = v262;\n\tthis.skeleton = v345;\n\tSpine.Unity.SkeletonGraphic::InitMeshBuffers(this);\n\tv386 = this.skeletonDataAsset;\n\tv387 = v386.atlasAssets;\n\tv348 = Spine.Unity.AtlasAssetBase::get_PrimaryMaterial(v387[0]);\n\tv466 = UnityEngine.Material::get_mainTexture(v348);\n\tthis.baseTexture = v466;\n\tv469 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv349 = Spine.Unity.SkeletonGraphic::get_mainTexture(this);\n\tUnityEngine.CanvasRenderer::SetTexture(v469, v349);\n\tv474 = System.String::IsNullOrEmpty(this.initialSkinName);\n\tv476 = v474 == 0;\n\tv477 = ~v476;\n\tif (v477) goto L_00D4;\n\tSpine.Skeleton::SetSkin(this.skeleton, this.initialSkinName);\nL_00D4:\n\tv390 = this.separatorSlots;\n\tv316 = v390._version + 1;\n\tv390._size = 0;\n\tv390._version = v316;\n\tv270 = v390._size < 1;\n\tif (v270) goto L_00EC;\n\tSystem.Array::Clear(v390._items, 0, v390._size);\nL_00EC:\n\tv392 = this.separatorSlotNames;\nL_00F2:\n\t;\n\tv269 = v399 >= v392.Length;\n\tif (v269) goto L_013A;\n\tv379 = this.separatorSlots;\n\tv354 = Spine.Skeleton::FindSlot(this.skeleton, v392[v399 @ X21_v13 (System.Int32)]);\n\tv394 = v379._items;\n\tv248 = v379._version + 1;\n\tv379._version = v248;\n\tv246 = v379._size;\n\tv502 = v379._size < v394.Length;\n\tv307 = ~v502;\n\tif (v307) goto L_0131;\n\tv503 = v379._size + 1;\n\tv379._size = v503;\n\tv394[v246 @ X10_v8 (System.Int32)] = v354;\n\tgoto L_0132;\nL_0131:\n\tSystem.Collections.Generic.List`1<Spine.Slot>::AddWithResize(v379, v354);\nL_0132:\n\tv392 = this.separatorSlotNames;\n\tv399 = v399 + 1;\n\tv511 = this.separatorSlotNames == 0;\n\tv359 = ~v511;\n\tif (v359) goto L_00F2;\n\tthrow System.NullReferenceException;\nL_013A:\n\tthis.wasUpdatedAfterInit = 0;\n\tv415 = System.String::IsNullOrEmpty(this.startingAnimation);\n\tv417 = v415 == 0;\n\tv418 = ~v417;\n\tif (v418) goto L_0154;\n\tv356 = Spine.Unity.SkeletonDataAsset::GetSkeletonData(this.skeletonDataAsset, 0);\n\tv424 = Spine.SkeletonData::FindAnimation(v356, this.startingAnimation);\n\tv426 = v424 == 0;\n\tif (v426) goto L_0154;\n\tv423 = Spine.AnimationState::SetAnimation(this.state, 0, v424, this.startingLoop);\nL_0154:\n\t;\n\tv141 = this.OnRebuild == 0;\n\tif (v141) goto L_0168;\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::Invoke(this.OnRebuild, this);\nL_0168:\n\treturn;\nL_0170:\n\tSpine.Unity.SkeletonGraphic::Clear(this);\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 254 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(bool overwrite)
		{
			if ((Skeleton != null && !overwrite) || this.skeletonDataAsset == null)
			{
				return;
			}
			SkeletonData skeletonData = this.skeletonDataAsset.GetSkeletonData(quiet: false);
			if (skeletonData == null)
			{
				return;
			}
			SkeletonDataAsset skeletonDataAsset = this.skeletonDataAsset;
			AtlasAssetBase[] atlasAssets = skeletonDataAsset.atlasAssets;
			if (atlasAssets.Length == 0)
			{
				return;
			}
			int materialCount = atlasAssets[0].MaterialCount;
			if (materialCount < 1)
			{
				return;
			}
			SkeletonDataAsset skeletonDataAsset2 = this.skeletonDataAsset;
			AnimationStateData stateData = skeletonDataAsset2.stateData;
			if (skeletonDataAsset2.stateData == null)
			{
				SkeletonData skeletonData2 = skeletonDataAsset2.GetSkeletonData(quiet: false);
				stateData = skeletonDataAsset2.stateData;
			}
			if ((state = new AnimationState(stateData)) != null)
			{
				Skeleton skeleton = new Skeleton(skeletonData);
				float scaleX = (initialFlipX ? (-1f) : 1f);
				skeleton.ScaleX = scaleX;
				float scaleY = (initialFlipY ? (-1f) : 1f);
				skeleton.ScaleY = scaleY;
				Skeleton = skeleton;
				InitMeshBuffers();
				SkeletonDataAsset skeletonDataAsset3 = this.skeletonDataAsset;
				AtlasAssetBase[] atlasAssets2 = skeletonDataAsset3.atlasAssets;
				Material primaryMaterial = atlasAssets2[0].PrimaryMaterial;
				Texture texture = primaryMaterial.mainTexture;
				baseTexture = texture;
				CanvasRenderer canvasRenderer = base.canvasRenderer;
				Texture texture2 = mainTexture;
				canvasRenderer.SetTexture(texture2);
				if (!string.IsNullOrEmpty(initialSkinName))
				{
					Skeleton.SetSkin(initialSkinName);
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
					Slot slot = Skeleton.FindSlot(array[num]);
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
				wasUpdatedAfterInit = false;
				if (!string.IsNullOrEmpty(startingAnimation))
				{
					SkeletonData skeletonData3 = this.skeletonDataAsset.GetSkeletonData(quiet: false);
					Animation animation = skeletonData3.FindAnimation(startingAnimation);
					if (animation != null)
					{
						TrackEntry trackEntry = AnimationState.SetAnimation(0, animation, startingLoop);
					}
				}
				if (this.OnRebuild != null)
				{
					this.OnRebuild(this);
				}
			}
			else
			{
				Clear();
			}
		}

		[Token(Token = "0x6000572")]
		[Address(RVA = "0x155B8D4", Offset = "0x155B8D4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.skeleton == 0;\n\tif (v8) goto L_0029;\n\tv13 = UnityEngine.UI.Graphic::get_color(this);\n\t// 14 MakeStruct v30 @ AGG155F900_1_v2 (UnityEngine.Color), typeof(UnityEngine.Color), v20 @ V0, v21 @ V1, v22 @ V2, v23 @ V3\n\tSpine.Unity.SkeletonExtensions::SetColor(this.skeleton, v30);\n\tv50 = ~this.allowMultipleCanvasRenderers;\n\tif (v50) goto L_0018;\n\tSpine.Unity.SkeletonGraphic::UpdateMeshMultipleCanvasRenderers(this, this.currentInstructions);\n\tgoto L_0019;\nL_0018:\n\tSpine.Unity.SkeletonGraphic::UpdateMeshSingleCanvasRenderer(this);\nL_0019:\n\t;\n\tv45 = this.OnMeshAndMaterialsUpdated == 0;\n\tif (v45) goto L_0029;\n\tSpine.Unity.SkeletonGraphic+SkeletonRendererDelegate::Invoke(this.OnMeshAndMaterialsUpdated, this);\nL_0029:\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateMesh()
		{
			//IL_0036: Expected F4, but got O
			//IL_0043: Expected F4, but got O
			//IL_0050: Expected F4, but got O
			//IL_005d: Expected F4, but got O
			if (Skeleton != null)
			{
				Color color = base.color;
				Color color2 = default(Color);
				object obj = default(object);
				color2.r = (float)obj;
				object obj2 = default(object);
				color2.g = (float)obj2;
				object obj3 = default(object);
				color2.b = (float)obj3;
				object obj4 = default(object);
				color2.a = (float)obj4;
				Skeleton.SetColor(color2);
				if (allowMultipleCanvasRenderers)
				{
					UpdateMeshMultipleCanvasRenderers(currentInstructions);
				}
				else
				{
					UpdateMeshSingleCanvasRenderer();
				}
				if (this.OnMeshAndMaterialsUpdated != null)
				{
					this.OnMeshAndMaterialsUpdated(this);
				}
			}
		}

		[Token(Token = "0x6000573")]
		[Address(RVA = "0x155DE68", Offset = "0x155DE68", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Spine.Unity.MeshGenerator;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37C38]) = v33;\nL_0011:\n\tv35 = this.skeleton == 0;\n\tif (v35) goto L_0028;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0021:\n\treturnVal2 = Spine.Unity.MeshGenerator::RequiresMultipleSubmeshesByDrawOrder(this.skeleton);\n\treturn returnVal2;\nL_0028:\n\treturn 0;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasMultipleSubmeshInstructions()
		{
			if (Skeleton != null)
			{
				return MeshGenerator.RequiresMultipleSubmeshesByDrawOrder(Skeleton);
			}
			return false;
		}

		[Token(Token = "0x6000574")]
		[Address(RVA = "0x155D278", Offset = "0x155D278", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv49 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C39]) = v34;\nL_0017:\n\tv36 = this.meshBuffers == 0;\n\tif (v36) goto L_0032;\n\tv43 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.meshBuffers);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Clear(v43);\n\tv60 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.meshBuffers);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Clear(v60);\n\treturn;\nL_0032:\n\tv47 = new Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>();\n\tSpine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::.ctor(v47);\n\tthis.meshBuffers = v47;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void InitMeshBuffers()
		{
			if (meshBuffers != null)
			{
				MeshRendererBuffers.SmartMesh next = meshBuffers.GetNext();
				next.Clear();
				MeshRendererBuffers.SmartMesh next2 = meshBuffers.GetNext();
				next2.Clear();
			}
			else
			{
				DoubleBuffered<MeshRendererBuffers.SmartMesh> doubleBuffered = new DoubleBuffered<MeshRendererBuffers.SmartMesh>();
				meshBuffers = doubleBuffered;
			}
		}

		[Token(Token = "0x6000575")]
		[Address(RVA = "0x155D33C", Offset = "0x155D33C", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv20 = Il2CppMethodInfo;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv289 = Spine.Unity.MeshGenerator;\n\tv290 = \"il2cpp_codegen_initialize_runtime_metadata\"(v289, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv338 = UnityEngine.Object;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37C3A]) = v40;\nL_001C:\n\tv41 = this.canvasRenderers;\n\tv57 = v41._size < 1;\n\tif (v57) goto L_0037;\n\tSpine.Unity.SkeletonGraphic::DisableUnusedCanvasRenderers(this, 0);\nL_0037:\n\tv344 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.meshBuffers);\n\tgoto L_0046;\n\tv400 = v272;\n\tv401 = \"il2cpp_codegen_runtime_class_init\"(v400, v342, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0046:\n\tSpine.Unity.MeshGenerator::GenerateSingleSubmeshInstruction(this.currentInstructions, this.skeleton, 0);\n\tv236 = Spine.Unity.SkeletonRendererInstruction::GeometryNotEqual(this.currentInstructions, v344.instructionUsed);\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\tv167 = this.currentInstructions;\n\tv406 = ~v167.hasActiveClipping;\n\tif (v406) goto L_0089;\n\tv274 = v167.submeshInstructions;\n\tv180 = v274.Count < 1;\n\tif (v180) goto L_0089;\n\tv275 = v274.Items;\n\tv115 = &v275[0];\n\tSpine.Unity.MeshGenerator::AddSubmesh(this.meshGenerator, &v115 @ V1_v6 (Spine.Unity.SubmeshInstruction), v236);\n\tgoto L_008E;\nL_0089:\n\tSpine.Unity.MeshGenerator::BuildMeshWithArrays(this.meshGenerator, v167, v236);\nL_008E:\n\tv430 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_009A;\n\tv434 = v277;\n\tv435 = \"il2cpp_codegen_runtime_class_init\"(v434, v429, v419, v129, v25, v26, v27, v28, v120, v116, v126, v32, v33, v34, v35, v36);\nL_009A:\n\tv439 = UnityEngine.Object::op_Inequality(v430, 0);\n\tv441 = v439 == 0;\n\tif (v441) goto L_00AB;\n\tv240 = UnityEngine.UI.Graphic::get_canvas(this);\n\tv121 = UnityEngine.Canvas::get_referencePixelsPerUnit(v240);\n\tSpine.Unity.MeshGenerator::ScaleVertexData(this.meshGenerator, v121);\nL_00AB:\n\t;\n\tv448 = this.OnPostProcessVertices == 0;\n\tif (v448) goto L_00D2;\n\tv473 = Spine.Unity.MeshGenerator::get_Buffers(this.meshGenerator);\n\tv474 = v473.vertexCount;\n\tSpine.Unity.MeshGeneratorDelegate::Invoke(this.OnPostProcessVertices, &v474 @ stack_-60_v5 (System.Int32));\nL_00D2:\n\tSpine.Unity.MeshGenerator::FillVertexData(this.meshGenerator, v344.mesh);\n\tv479 = v236 == 0;\n\tif (v479) goto L_00E1;\n\tSpine.Unity.MeshGenerator::FillTriangles(this.meshGenerator, v344.mesh);\nL_00E1:\n\tSpine.Unity.MeshGenerator::FillLateVertexData(this.meshGenerator, v344.mesh);\n\tv244 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tUnityEngine.CanvasRenderer::SetMesh(v244, v344.mesh);\n\tSpine.Unity.SkeletonRendererInstruction::Set(v344.instructionUsed, this.currentInstructions);\n\tv279 = this.currentInstructions;\n\tv280 = v279.submeshInstructions;\n\tv183 = v280.Count < 1;\n\tif (v183) goto L_0154;\n\tv281 = v280.Items;\n\tgoto L_0113;\n\tv509 = \"il2cpp_codegen_runtime_class_init\"(v506, v175, v138, v129, v25, v26, v27, v28, v123, v117, v126, v32, v33, v34, v35, v36);\nL_0113:\n\tv246 = UnityEngine.Object::op_Inequality(*([v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]), 0);\n\tv499 = v246 == 0;\n\tif (v499) goto L_0154;\n\tv515 = UnityEngine.Material::get_mainTexture(*([v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]));\n\tgoto L_0128;\n\tv518 = v502;\n\tv519 = \"il2cpp_codegen_runtime_class_init\"(v518, v514, v139, v129, v25, v26, v27, v28, v123, v117, v126, v32, v33, v34, v35, v36);\nL_0128:\n\tv497 = UnityEngine.Object::op_Inequality(this.baseTexture, v515);\n\tv500 = v497 == 0;\n\tif (v500) goto L_0154;\n\tv525 = UnityEngine.Material::get_mainTexture(*([v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]));\n\tthis.baseTexture = v525;\n\tgoto L_013A;\n\tv529 = \"il2cpp_codegen_runtime_class_init\"(v526, v524, v489, v129, v25, v26, v27, v28, v123, v117, v126, v32, v33, v34, v35, v36);\nL_013A:\n\tv498 = UnityEngine.Object::op_Equality(this.overrideTexture, 0);\n\tv501 = v498 == 0;\n\tif (v501) goto L_0154;\n\tv535 = UnityEngine.UI.Graphic::get_canvasRenderer(this);\n\tv247 = Spine.Unity.SkeletonGraphic::get_mainTexture(this);\n\tUnityEngine.CanvasRenderer::SetTexture(v535, v247);\nL_0154:\n\treturn;\n\tv287 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 256 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe void UpdateMeshSingleCanvasRenderer()
		{
			//IL_0200: Expected O, but got Ref
			//IL_010f: Expected O, but got Ref
			//IL_0127: Expected O, but got Ref
			//IL_0309: Expected O, but got I
			//IL_033b: Expected O, but got I
			//IL_0385: Expected O, but got I
			List<CanvasRenderer> list = canvasRenderers;
			if (list.Count >= 1)
			{
				DisableUnusedCanvasRenderers(0);
			}
			MeshRendererBuffers.SmartMesh next = meshBuffers.GetNext();
			MeshGenerator.GenerateSingleSubmeshInstruction(currentInstructions, Skeleton, null);
			bool flag = SkeletonRendererInstruction.GeometryNotEqual(currentInstructions, next.instructionUsed);
			MeshGenerator.Begin();
			SkeletonRendererInstruction skeletonRendererInstruction = currentInstructions;
			if (skeletonRendererInstruction.hasActiveClipping)
			{
				ExposedList<SubmeshInstruction> submeshInstructions = skeletonRendererInstruction.submeshInstructions;
				if (submeshInstructions.Count >= 1)
				{
					SubmeshInstruction[] items = submeshInstructions.Items;
					SubmeshInstruction submeshInstruction = (SubmeshInstruction)System.Runtime.CompilerServices.Unsafe.AsPointer(ref items[0]);
					MeshGenerator.AddSubmesh((SubmeshInstruction)(&submeshInstruction), flag);
					goto IL_0146;
				}
			}
			MeshGenerator.BuildMeshWithArrays(skeletonRendererInstruction, flag);
			goto IL_0146;
			IL_0146:
			Canvas canvas = base.canvas;
			if (canvas != null)
			{
				Canvas canvas2 = base.canvas;
				float referencePixelsPerUnit = canvas2.referencePixelsPerUnit;
				MeshGenerator.ScaleVertexData(referencePixelsPerUnit);
			}
			if (this.OnPostProcessVertices != null)
			{
				int vertexCount = MeshGenerator.Buffers.vertexCount;
				this.OnPostProcessVertices((MeshGeneratorBuffers)(&vertexCount));
			}
			MeshGenerator.FillVertexData(next.mesh);
			if (flag)
			{
				MeshGenerator.FillTriangles(next.mesh);
			}
			MeshGenerator.FillLateVertexData(next.mesh);
			CanvasRenderer canvasRenderer = base.canvasRenderer;
			canvasRenderer.SetMesh(next.mesh);
			next.instructionUsed.Set(currentInstructions);
			SkeletonRendererInstruction skeletonRendererInstruction2 = currentInstructions;
			ExposedList<SubmeshInstruction> submeshInstructions2 = skeletonRendererInstruction2.submeshInstructions;
			if (submeshInstructions2.Count < 1)
			{
				return;
			}
			SubmeshInstruction[] items2 = submeshInstructions2.Items;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]");
			if (!((UnityEngine.Object)0 != null))
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]");
			Texture texture = ((Material)0).mainTexture;
			if (baseTexture != texture)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v281 @ X8_v18 (Spine.Unity.SubmeshInstruction[])+30]");
				Texture texture2 = ((Material)0).mainTexture;
				baseTexture = texture2;
				if (OverrideTexture == null)
				{
					CanvasRenderer canvasRenderer2 = base.canvasRenderer;
					Texture texture3 = mainTexture;
					canvasRenderer2.SetTexture(texture3);
				}
			}
		}

		[Token(Token = "0x6000576")]
		[Address(RVA = "0x155D700", Offset = "0x155D700", Length = "0x768")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = &v37 @ stack_-C0;\n\tgoto L_003E;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv559 = Il2CppMethodInfo;\n\tv560 = \"il2cpp_codegen_initialize_runtime_metadata\"(v559, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv637 = Il2CppMethodInfo;\n\tv638 = \"il2cpp_codegen_initialize_runtime_metadata\"(v637, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv726 = Il2CppMethodInfo;\n\tv727 = \"il2cpp_codegen_initialize_runtime_metadata\"(v726, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv744 = Il2CppMethodInfo;\n\tv745 = \"il2cpp_codegen_initialize_runtime_metadata\"(v744, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv844 = Il2CppMethodInfo;\n\tv845 = \"il2cpp_codegen_initialize_runtime_metadata\"(v844, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv909 = Spine.Unity.MeshGenerator;\n\tv910 = \"il2cpp_codegen_initialize_runtime_metadata\"(v909, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv914 = UnityEngine.Object;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v914, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\n\tv61 = 1;\n\t*([1A37C3B]) = v61;\nL_003E:\n\t*([v36 @ X29_v1+F]) = 0;\n\tv70 = ~this.enableSeparatorSlots;\n\tif (v70) goto L_FFFFFFFF;\n\tv429 = this.separatorSlots;\n\tv85 = v429._size < 0;\n\tv86 = v429._size == 0;\n\tv88 = v429._size ^ v429._size;\n\tv89 = v429._size & v88;\n\tv90 = v89 < 0;\n\tv91 = v85 == v90;\n\tv92 = ~v86;\n\tv93 = v91 & v92;\n\tgoto L_005F;\nL_005F:\n\tgoto L_0068;\n\tv634 = \"il2cpp_codegen_runtime_class_init\"(v555, currentInstructions, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0068:\n\tSpine.Unity.MeshGenerator::GenerateSkeletonRendererInstruction(currentInstructions, this.skeleton, 0, v429, v350, 0);\n\tv523 = currentInstructions.submeshInstructions;\n\tSpine.Unity.SkeletonGraphic::EnsureCanvasRendererCount(this, v523.Count);\n\tSpine.Unity.SkeletonGraphic::EnsureMeshesCount(this, v523.Count);\n\tSpine.Unity.SkeletonGraphic::EnsureSeparatorPartCount(this);\n\tv917 = UnityEngine.UI.Graphic::get_canvas(this);\n\tgoto L_0088;\n\tv920 = v524;\n\tv921 = \"il2cpp_codegen_runtime_class_init\"(v920, v916, v297, v289, v286, v283, v280, v49, v50, v51, v52, v53, v54, v55, v56, v57);\nL_0088:\n\tv435 = UnityEngine.Object::op_Equality(v917, 0);\n\tv925 = v435 == 0;\n\tif (v925) goto L_0093;\n\tgoto L_0095;\nL_0093:\n\tv50 = UnityEngine.Canvas::get_referencePixelsPerUnit(v917);\nL_0095:\n\tv525 = this.meshes;\n\tv937 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::get_Count(this.customMaterialOverride);\n\tv960 = v937 == 0;\n\tif (v960) goto L_00AA;\n\tgoto L_00B7;\nL_00AA:\n\tv979 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>::get_Count(this.customTextureOverride);\n\tv975 = v979 == 0;\n\tv970 = ~v975;\nL_00B7:\n\tv542 = this.separatorSlots;\n\tv986 = v542._size == 0;\n\tif (v986) goto L_00C9;\n\tv611 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(this.separatorParts, 0);\n\tgoto L_00CC;\nL_00C9:\n\tv611 = UnityEngine.Component::get_transform(this);\nL_00CC:\n\tv614 = ~this.updateSeparatorPartLocation;\n\tif (v614) goto L_0119;\n\tv612 = this.separatorParts;\nL_00DC:\n\tv358 = v351 >= v612._size;\n\tif (v358) goto L_0119;\n\tv1009 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(v612, v351);\n\tv440 = UnityEngine.Component::get_transform(this);\n\tv247 = UnityEngine.Transform::get_position(v440);\n\tv51 = v247.y;\n\tUnityEngine.Transform::set_position(v1009, v247);\n\tv1022 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(this.separatorParts, v351);\n\tv442 = UnityEngine.Component::get_transform(this);\n\tv244 = UnityEngine.Transform::get_rotation(v442);\n\tv51 = v244.y;\n\tUnityEngine.Transform::set_rotation(v1022, v244);\n\tv612 = this.separatorParts;\n\tv351 = v351 + 1;\n\tv1053 = this.separatorParts == 0;\n\tv467 = ~v1053;\n\tif (v467) goto L_00DC;\n\tv550 = new System.NullReferenceException();\nL_0119:\n\tv633 = v274 < 1;\n\tif (v633) goto L_0271;\n\tv642 = v525.Items + 0x20;\n\tv644 = &v161 @ stack_-120 (System.Single) + 0x19;\nL_0124:\n\tv528 = v514.submeshInstructions;\n\tv530 = v528.Items + v519;\n\tv51 = *([v530 @ X8_v36]);\n\tv50 = *([v530 @ X8_v36+19]);\n\t*([v506 @ X29_v6+F]) = *([v530 @ X8_v36+28]);\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\t*([v506 @ X29_v6+2F]) = *([v506 @ X29_v6+F]);\n\t*([v644 @ X8_v31+F]) = *([v506 @ X29_v6+2F]);\n\t*([v644 @ X8_v31]) = *([v530 @ X8_v36+19]);\n\tSpine.Unity.MeshGenerator::AddSubmesh(this.meshGenerator, &v51 @ V1 (System.Single), 1);\n\tSpine.Unity.MeshGenerator::ScaleVertexData(this.meshGenerator, v255);\n\tv935 = this.OnPostProcessVertices == 0;\n\tif (v935) goto L_0194;\n\tv963 = Spine.Unity.MeshGenerator::get_Buffers(this.meshGenerator);\n\tv965 = v963.vertexCount;\n\tSpine.Unity.MeshGeneratorDelegate::Invoke(this.OnPostProcessVertices, &v965 @ stack_-A0_v8 (System.Int32));\nL_0194:\n\tSpine.Unity.MeshGenerator::FillVertexData(this.meshGenerator, *([v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]));\n\tSpine.Unity.MeshGenerator::FillTriangles(this.meshGenerator, *([v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]));\n\tSpine.Unity.MeshGenerator::FillLateVertexData(this.meshGenerator, *([v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]));\n\tv451 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(this.canvasRenderers, v352);\n\tv452 = UnityEngine.Component::get_gameObject(v451);\n\tUnityEngine.GameObject::SetActive(v452, 1);\n\tUnityEngine.CanvasRenderer::SetMesh(v451, *([v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]));\n\tUnityEngine.CanvasRenderer::set_materialCount(v451, 1);\n\tv453 = UnityEngine.Component::get_transform(v451);\n\tv1020 = UnityEngine.Transform::get_parent(v453);\n\tv1025 = UnityEngine.Component::get_transform(v238);\n\tgoto L_01D6;\n\tv1030 = v537;\n\tv1031 = \"il2cpp_codegen_runtime_class_init\"(v1030, v1024, v307, v291, v287, v284, v281, v49, v253, v232, v222, v212, v54, v55, v56, v57);\nL_01D6:\n\tv1035 = UnityEngine.Object::op_Inequality(v1020, v1025);\n\tv1037 = v1035 == 0;\n\tif (v1037) goto L_0206;\n\tv1041 = UnityEngine.Component::get_transform(v451);\n\tv455 = UnityEngine.Component::get_transform(v238);\n\tUnityEngine.Transform::SetParent(v1041, v455, 0);\n\tv1061 = UnityEngine.Component::get_transform(v451);\n\tgoto L_01FD;\n\tv1081 = UnityEngine.Vector3;\n\tv1082 = \"il2cpp_codegen_initialize_runtime_metadata\"(v1081, v346, v313, v293, v287, v284, v281, v49, v253, v232, v222, v212, v54, v55, v56, v57);\n\tv1084 = 1;\n\t*([1A35519]) = v1084;\nL_01FD:\n\tv1088 = UnityEngine.Vector3;\n\tv1051 = *([v1088 @ X8_v65 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tv233 = *([v1051 @ X8_v66 (Il2CppStaticFields<UnityEngine.Vector3>)+4]);\n\tv223 = *([v1051 @ X8_v66 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tUnityEngine.Transform::set_localPosition(v1061, v1051.zeroVector);\nL_0206:\n\tv456 = UnityEngine.Component::get_transform(v451);\n\tUnityEngine.Transform::SetSiblingIndex(v456, v202);\n\tv1057 = *([v530 @ X8_v36+18]) & 1;\n\tv1058 = v1057 == 0;\n\tv1059 = ~v1058;\n\tif (v1059) goto L_021A;\n\tv202 = v202 + 1;\n\tgoto L_0221;\nL_021A:\n\tv1071 = v200 + 1;\n\tv1072 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(this.separatorParts, v1071);\nL_0221:\n\tv1077 = v98 == 0;\n\tif (v1077) goto L_024F;\n\tv459 = UnityEngine.Material::get_mainTexture(*([v530 @ X8_v36+10]));\n\tv1102 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::TryGetValue(this\n// ... truncated")]
		protected unsafe void UpdateMeshMultipleCanvasRenderers(SkeletonRendererInstruction currentInstructions)
		{
			//IL_027d: Expected O, but got I4
			//IL_0489: Expected O, but got I
			//IL_0498: Expected O, but got I
			//IL_0a2f: Expected O, but got I4
			//IL_04dc: Expected O, but got I
			//IL_04e4: Expected F4, but got O
			//IL_04f5: Expected F4, but got I
			//IL_0545: Expected O, but got I
			//IL_0559: Expected O, but got Ref
			//IL_0608: Expected O, but got I
			//IL_0624: Expected O, but got I
			//IL_05d2: Expected O, but got Ref
			//IL_05ec: Expected F4, but got O
			//IL_0640: Expected O, but got I
			//IL_03d8: Expected O, but got I4
			//IL_0692: Expected O, but got I
			//IL_0761: Expected I, but got O
			//IL_076a: Expected I, but got O
			//IL_078a: Expected F4, but got I
			//IL_092f: Expected O, but got I
			//IL_086f: Expected O, but got I
			//IL_0afc: Expected O, but got F4
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			List<Slot> list;
			bool flag7;
			if (enableSeparatorSlots)
			{
				list = separatorSlots;
				bool flag = list.Count < 0;
				bool flag2 = list.Count == 0;
				int num = list.Count ^ list.Count;
				int num2 = list.Count & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				bool flag6 = flag4 && flag5;
				flag7 = flag6;
			}
			else
			{
				flag7 = false;
				list = null;
			}
			MeshGenerator.GenerateSkeletonRendererInstruction(currentInstructions, Skeleton, null, list, flag7);
			ExposedList<SubmeshInstruction> submeshInstructions = currentInstructions.submeshInstructions;
			EnsureCanvasRendererCount(submeshInstructions.Count);
			EnsureMeshesCount(submeshInstructions.Count);
			EnsureSeparatorPartCount();
			Canvas canvas = base.canvas;
			float num3;
			if (canvas == null)
			{
				num3 = 100f;
			}
			else
			{
				float referencePixelsPerUnit = canvas.referencePixelsPerUnit;
				num3 = referencePixelsPerUnit;
			}
			ExposedList<Mesh> exposedList = meshes;
			bool flag8;
			if (CustomMaterialOverride.Count != 0)
			{
				flag8 = true;
			}
			else
			{
				int count = CustomTextureOverride.Count;
				bool flag9 = count == 0;
				bool flag10 = !flag9;
				flag8 = flag10;
			}
			List<Slot> list2 = separatorSlots;
			Transform transform = ((list2.Count == 0) ? base.transform : SeparatorParts[0]);
			bool flag11 = !updateSeparatorPartLocation;
			bool flag12 = flag8;
			Transform transform2 = transform;
			object obj4 = default(object);
			object obj3 = obj4;
			int count2 = submeshInstructions.Count;
			object obj5 = 0;
			bool flag13 = false;
			bool flag14 = flag7;
			object obj6 = obj2;
			SkeletonRendererInstruction skeletonRendererInstruction = currentInstructions;
			float num5;
			float z = default(float);
			if (!flag11)
			{
				List<Transform> list3 = SeparatorParts;
				int num4 = 0;
				while (true)
				{
					bool flag15 = num4 >= list3.Count;
					flag12 = flag8;
					transform2 = transform;
					obj3 = obj4;
					count2 = submeshInstructions.Count;
					obj5 = 0;
					flag13 = false;
					flag14 = flag7;
					obj6 = obj2;
					skeletonRendererInstruction = currentInstructions;
					if (flag15)
					{
						break;
					}
					Transform transform3 = list3[num4];
					Transform transform4 = base.transform;
					Vector3 position = transform4.position;
					num5 = position.y;
					transform3.position = position;
					Transform transform5 = SeparatorParts[num4];
					Transform transform6 = base.transform;
					Quaternion rotation = transform6.rotation;
					num5 = rotation.y;
					transform5.rotation = rotation;
					list3 = SeparatorParts;
					num4++;
					bool flag16 = SeparatorParts == null;
					bool flag17 = !flag16;
					flag12 = flag8;
					transform2 = transform;
					obj3 = obj4;
					float referencePixelsPerUnit = rotation.x;
					count2 = submeshInstructions.Count;
					obj5 = 0;
					flag13 = false;
					flag14 = flag7;
					obj6 = obj2;
					skeletonRendererInstruction = currentInstructions;
					float w = rotation.w;
					z = rotation.z;
					referencePixelsPerUnit = rotation.x;
					if (!flag17)
					{
						NullReferenceException ex = new NullReferenceException();
						w = rotation.w;
						z = rotation.z;
						break;
					}
				}
			}
			if (count2 >= 1)
			{
				object obj7 = (nint)exposedList.Items + 32;
				float num6 = default(float);
				object obj8 = (nint)num6 + 25;
				int num7 = 0;
				int num8 = 0;
				float num9 = z;
				int num10 = 0;
				int num11 = 32;
				Material material = default(Material);
				bool flag19;
				do
				{
					ExposedList<SubmeshInstruction> submeshInstructions2 = skeletonRendererInstruction.submeshInstructions;
					object obj9 = (nint)submeshInstructions2.Items + num11;
					num5 = (float)obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+19]");
					float referencePixelsPerUnit = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+28]");
					_ = 0;
					MeshGenerator.Begin();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ X29_v6+F]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v506 @ X29_v6+2F]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+19]");
					obj8 = 0;
					MeshGenerator.AddSubmesh((SubmeshInstruction)(&num5));
					MeshGenerator.ScaleVertexData(num3);
					bool flag18 = this.OnPostProcessVertices == null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+19]");
					int num12 = 0;
					referencePixelsPerUnit = num3;
					if (!flag18)
					{
						MeshGeneratorBuffers buffers = MeshGenerator.Buffers;
						int vertexCount = buffers.vertexCount;
						this.OnPostProcessVertices((MeshGeneratorBuffers)(&vertexCount));
						num12 = buffers.vertexCount;
						referencePixelsPerUnit = (float)buffers.uvBuffer;
					}
					MeshGenerator obj10 = MeshGenerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]");
					obj10.FillVertexData((Mesh)0);
					MeshGenerator obj11 = MeshGenerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]");
					obj11.FillTriangles((Mesh)0);
					MeshGenerator obj12 = MeshGenerator;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]");
					obj12.FillLateVertexData((Mesh)0);
					Component component = canvasRenderers[num10];
					GameObject gameObject = component.gameObject;
					gameObject.SetActive(value: true);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v642 @ X9_v8+v352 @ X23_v10 (System.Int32)*8]");
					((CanvasRenderer)component).SetMesh((Mesh)0);
					((CanvasRenderer)component).materialCount = 1;
					Transform transform7 = component.transform;
					Transform parent = transform7.parent;
					Transform transform8 = transform2.transform;
					if (parent != transform8)
					{
						Transform transform9 = component.transform;
						Transform parent2 = transform2.transform;
						transform9.SetParent(parent2, worldPositionStays: false);
						Transform transform10 = component.transform;
						nint num13 = (nint)typeof(Vector3);
						nint num14 = (nint)Vector3.zero;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ X8_v66 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
						num12 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1051 @ X8_v66 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
						num9 = 0f;
						transform10.localPosition = Vector3.zero;
						referencePixelsPerUnit = Vector3.zero.x;
					}
					Transform transform11 = component.transform;
					transform11.SetSiblingIndex(num8);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+18]");
					if ((int)((nint)0 & (nint)1) == 0)
					{
						num8++;
					}
					else
					{
						int num15 = num7 + 1;
						Transform transform12 = SeparatorParts[num15];
						num7 = num15;
						num8 = 0;
						transform2 = transform12;
					}
					Texture texture3;
					Material material2;
					CanvasRenderer canvasRenderer;
					if (flag12)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+10]");
						Texture texture = ((Material)0).mainTexture;
						object value;
						if (!CustomMaterialOverride.TryGetValue(texture, out *(Material*)(&value)))
						{
							material = base.material;
							value = material;
						}
						object value2;
						Texture texture2 = (Texture)((!CustomTextureOverride.TryGetValue(texture, out *(Texture*)(&value2))) ? texture : value2);
						texture3 = texture2;
						material2 = material;
						canvasRenderer = (CanvasRenderer)component;
					}
					else
					{
						Material material3 = base.materialForRendering;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v530 @ X8_v36+10]");
						Texture texture4 = ((Material)0).mainTexture;
						texture3 = texture4;
						material2 = material3;
						canvasRenderer = (CanvasRenderer)component;
					}
					canvasRenderer.SetMaterial(material2, texture3);
					num10++;
					num11 += 48;
					flag19 = count2 != num10;
					num5 = num12;
					num6 = num12;
					num5 = num12;
					obj6 = referencePixelsPerUnit;
				}
				while (flag19);
			}
			DisableUnusedCanvasRenderers(count2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ stack_-188_v2+28]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ SYSREG+28]");
			if (num16 != 0)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			}
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0x155DF94", Offset = "0x155DF94", Length = "0x320")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv203 = UnityEngine.GameObject;\n\tv204 = \"il2cpp_codegen_initialize_runtime_metadata\"(v203, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv312 = System.Int32;\n\tv313 = \"il2cpp_codegen_initialize_runtime_metadata\"(v312, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv409 = Il2CppMethodInfo;\n\tv410 = \"il2cpp_codegen_initialize_runtime_metadata\"(v409, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv418 = Il2CppMethodInfo;\n\tv419 = \"il2cpp_codegen_initialize_runtime_metadata\"(v418, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv427 = UnityEngine.RectTransform;\n\tv428 = \"il2cpp_codegen_initialize_runtime_metadata\"(v427, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv435 = System.Type[];\n\tv436 = \"il2cpp_codegen_initialize_runtime_metadata\"(v435, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv442 = System.Type;\n\tv443 = \"il2cpp_codegen_initialize_runtime_metadata\"(v442, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv445 = \"Renderer{0}\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v445, targetCount, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37C3C]) = v53;\nL_0035:\n\tv54 = this.canvasRenderers;\n\tv59 = v54._size;\n\tv69 = v54._size >= targetCount;\n\tif (v69) goto L_00FD;\nL_0052:\n\t// 82 Box v329 @ X0_v12 (System.Object), typeof(System.Int32), &v59 @ X25_v4 (System.Int32)\n\tv416 = System.String::Format(\"Renderer{0}\", v329);\n\t// 96 NewArr v425 @ X0_v16 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0070;\n\tv437 = v195;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v437, v422, v123, v100, v38, v39, v40, v41, v91, v97, v94, v45, v46, v47, v48, v49);\nL_0070:\n\tv180 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv446 = v180 == 0;\n\tif (v446) goto L_007F;\n\t// 121 IsInst v404 @ X0_v43, typeof(System.Type), v180 @ X0_v19 (System.Type)\n\tv405 = v404 == 0;\n\tif (v405) goto L_0100;\nL_007F:\n\tv425[0] = v180;\n\tv181 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v181, v416, v425);\n\tv454 = UnityEngine.GameObject::get_transform(v181);\n\tv182 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v454, v182, 0);\n\tv459 = UnityEngine.GameObject::get_transform(v181);\n\tgoto L_00A7;\n\tv463 = v200;\n\tv464 = \"il2cpp_codegen_initialize_runtime_metadata\"(v463, v133, v125, v102, v38, v39, v40, v41, v91, v97, v94, v45, v46, v47, v48, v49);\n\tv465 = 1;\n\t*([1A35519]) = v465;\nL_00A7:\n\t;\n\tUnityEngine.Transform::set_localPosition(v459, v469.zeroVector);\n\tv183 = UnityEngine.GameObject::AddComponent(v181);\n\tv197 = this.canvasRenderers;\n\tv108 = v197._items;\n\tv83 = v197._version + 1;\n\tv197._version = v83;\n\tv84 = v197._size;\n\tv473 = v197._size < v108.Length;\n\tv175 = ~v473;\n\tif (v175) goto L_00D4;\n\tv474 = v197._size + 1;\n\tv197._size = v474;\n\tv108[v84 @ X11_v8 (System.Int32)] = v183;\n\tgoto L_00D7;\nL_00D4:\n\tSystem.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::AddWithResize(v197, v183);\nL_00D7:\n\tv184 = UnityEngine.GameObject::AddComponent(v181);\n\tUnityEngine.UI.MaskableGraphic::set_maskable(v184, this.m_Maskable);\n\tv254 = UnityEngine.UI.Graphic::set_raycastTarget(v184, 0);\n\tv59 = v59 + 1;\n\tv234 = targetCount != v59;\n\tif (v234) goto L_0052;\nL_00FD:\n\treturn;\n\tv201 = new System.NullReferenceException();\n\tv310 = new System.IndexOutOfRangeException();\nL_0100:\n\tv407 = new System.ArrayTypeMismatchException();\n\tthrow v407;\n\treturn;\n// 181 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void EnsureCanvasRendererCount(int targetCount)
		{
			List<CanvasRenderer> list = canvasRenderers;
			int num = list.Count;
			if (list.Count >= targetCount)
			{
				return;
			}
			while (true)
			{
				object arg = num;
				string text = $"Renderer{arg}";
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(RectTransform);
				if ((object)typeFromHandle != null)
				{
					object obj = typeFromHandle as Type;
					if (obj == null)
					{
						break;
					}
				}
				array[0] = typeFromHandle;
				GameObject gameObject = new GameObject(text, array);
				Transform transform = gameObject.transform;
				Transform parent = base.transform;
				transform.SetParent(parent, worldPositionStays: false);
				Transform transform2 = gameObject.transform;
				transform2.localPosition = Vector3.zero;
				CanvasRenderer canvasRenderer = gameObject.AddComponent<CanvasRenderer>();
				List<CanvasRenderer> list2 = canvasRenderers;
				CanvasRenderer[] items = list2._items;
				int version = list2._version + 1;
				list2._version = version;
				int count = list2.Count;
				if (list2.Count < items.Length)
				{
					int size = list2.Count + 1;
					list2._size = size;
					items[count] = canvasRenderer;
				}
				else
				{
					list2.Add(canvasRenderer);
				}
				RawImage rawImage = gameObject.AddComponent<RawImage>();
				rawImage.maskable = maskable;
				rawImage.raycastTarget = false;
				num++;
				if (targetCount == num)
				{
					return;
				}
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0x155DED8", Offset = "0x155DED8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, usedCount, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv41 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, usedCount, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37C3D]) = v37;\nL_0015:\n\tv111 = this.canvasRenderers;\nL_0024:\n\tv45 = v95 >= v111._size;\n\tif (v45) goto L_0047;\n\tv83 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(v111, v95);\n\tUnityEngine.CanvasRenderer::Clear(v83);\n\tv85 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(this.canvasRenderers, v95);\n\tv86 = UnityEngine.Component::get_gameObject(v85);\n\tUnityEngine.GameObject::SetActive(v86, 0);\n\tv111 = this.canvasRenderers;\n\tv95 = v95 + 1;\n\tv135 = this.canvasRenderers == 0;\n\tv88 = ~v135;\n\tif (v88) goto L_0024;\n\tthrow System.NullReferenceException;\nL_0047:\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void DisableUnusedCanvasRenderers(int usedCount)
		{
			List<CanvasRenderer> list = canvasRenderers;
			int num = usedCount;
			while (num < list.Count)
			{
				CanvasRenderer canvasRenderer = list[num];
				canvasRenderer.Clear();
				Component component = canvasRenderers[num];
				GameObject gameObject = component.gameObject;
				gameObject.SetActive(value: false);
				list = canvasRenderers;
				num++;
				if (canvasRenderers == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0x155E2B4", Offset = "0x155E2B4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, targetCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = UnityEngine.Mesh;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, targetCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv130 = UnityEngine.Object;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, targetCount, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37C3E]) = v45;\nL_001C:\n\tv46 = this.meshes;\n\tSpine.ExposedList`1<UnityEngine.Mesh>::EnsureCapacity(this.meshes, targetCount);\n\tv125 = this.meshes;\n\tv76 = v46.Count >= targetCount;\n\tif (v76) goto L_0081;\n\tv64 = v46.Count << 3;\n\tv61 = v125.Items + v64;\n\tv59 = targetCount - v46.Count;\n\tv57 = v61 + 0x20;\nL_0050:\n\tgoto L_0055;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v236, v221, v220, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0055:\n\tv258 = UnityEngine.Object::op_Equality(*([v57 @ X24_v5]), 0);\n\tv200 = v258 == 0;\n\tif (v200) goto L_006A;\n\tv251 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v251);\n\t*([v57 @ X24_v5]) = v251;\nL_006A:\n\tv57 = v57 + 8;\n\tv185 = v59 - 1;\n\tv188 = v59 != 1;\n\tif (v188) goto L_0050;\nL_0081:\n\treturn;\n\tv114 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void EnsureMeshesCount(int targetCount)
		{
			//IL_006d: Expected O, but got I
			//IL_008e: Expected O, but got I
			//IL_00fe: Expected O, but got I
			ExposedList<Mesh> exposedList = meshes;
			meshes.EnsureCapacity(targetCount);
			ExposedList<Mesh> exposedList2 = meshes;
			if (exposedList.Count >= targetCount)
			{
				return;
			}
			int num = exposedList.Count << 3;
			object obj = (nint)exposedList2.Items + num;
			int num2 = targetCount - exposedList.Count;
			object obj2 = (nint)obj + 32;
			bool flag;
			do
			{
				if ((UnityEngine.Object)obj2 == null)
				{
					Mesh mesh = new Mesh();
					obj2 = mesh;
				}
				obj2 = (nint)obj2 + 8;
				int num3 = num2 - 1;
				flag = num2 != 1;
				num2 = num3;
			}
			while (flag);
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0x155E3E4", Offset = "0x155E3E4", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0034;\n\tv32 = UnityEngine.GameObject;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv56 = System.Int32;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv178 = Il2CppMethodInfo;\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv294 = Il2CppMethodInfo;\n\tv295 = \"il2cpp_codegen_initialize_runtime_metadata\"(v294, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv375 = Il2CppMethodInfo;\n\tv376 = \"il2cpp_codegen_initialize_runtime_metadata\"(v375, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv382 = UnityEngine.RectTransform;\n\tv383 = \"il2cpp_codegen_initialize_runtime_metadata\"(v382, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv402 = System.Type[];\n\tv403 = \"il2cpp_codegen_initialize_runtime_metadata\"(v402, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv413 = System.Type;\n\tv414 = \"il2cpp_codegen_initialize_runtime_metadata\"(v413, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv422 = \"{0}[{1}]\";\n\tv423 = \"il2cpp_codegen_initialize_runtime_metadata\"(v422, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv428 = \"Part\";\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37C3F]) = v52;\nL_0034:\n\tv53 = this.separatorSlots;\n\tv59 = v53._size == 0;\n\tif (v59) goto L_00F3;\n\tv150 = this.separatorParts;\n\tv233 = v150._size;\n\tv146 = v53._size + 1;\n\tv205 = v150._size >= v146;\n\tif (v205) goto L_00F3;\nL_0058:\n\t// 88 Box v400 @ X0_v12 (System.Object), typeof(System.Int32), &v233 @ X24_v6 (System.Int32)\n\tv411 = System.String::Format(\"{0}[{1}]\", \"Part\", v400);\n\t// 105 NewArr v420 @ X0_v16 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_0077;\n\tv429 = v169;\n\tv430 = \"il2cpp_codegen_runtime_class_init\"(v429, v417, v107, v103, v37, v38, v39, v40, v74, v80, v77, v44, v45, v46, v47, v48);\nL_0077:\n\tv155 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv433 = v155 == 0;\n\tif (v433) goto L_0086;\n\t// 128 IsInst v370 @ X0_v39, typeof(System.Type), v155 @ X0_v19 (System.Type)\n\tv371 = v370 == 0;\n\tif (v371) goto L_00F6;\nL_0086:\n\tv420[0] = v155;\n\tv156 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v156, v411, v420);\n\tv440 = UnityEngine.GameObject::get_transform(v156);\n\tv157 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v440, v157, 0);\n\tv445 = UnityEngine.GameObject::get_transform(v156);\n\tgoto L_00AC;\n\tv449 = v175;\n\tv450 = \"il2cpp_codegen_initialize_runtime_metadata\"(v449, v101, v109, v105, v37, v38, v39, v40, v74, v80, v77, v44, v45, v46, v47, v48);\n\tv451 = 1;\n\t*([1A35519]) = v451;\nL_00AC:\n\t;\n\tUnityEngine.Transform::set_localPosition(v445, v171.zeroVector);\n\tv94 = this.separatorParts;\n\tv158 = UnityEngine.GameObject::get_transform(v156);\n\tv172 = v94._items;\n\tv90 = v94._version + 1;\n\tv94._version = v90;\n\tv192 = v94._size;\n\tv457 = v94._size < v172.Length;\n\tv458 = ~v457;\n\tif (v458) goto L_00D9;\n\tv466 = v94._size + 1;\n\tv94._size = v466;\n\tv172[v192 @ X10_v10 (System.Int32)] = v158;\n\tgoto L_00DA;\nL_00D9:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::AddWithResize(v94, v158);\nL_00DA:\n\tv233 = v233 + 1;\n\tv204 = v146 != v233;\n\tif (v204) goto L_0058;\nL_00F3:\n\treturn;\n\tv176 = new System.NullReferenceException();\n\tv292 = new System.IndexOutOfRangeException();\nL_00F6:\n\tv373 = new System.ArrayTypeMismatchException();\n\tthrow v373;\n\treturn;\n// 170 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void EnsureSeparatorPartCount()
		{
			List<Slot> list = separatorSlots;
			if (list.Count == 0)
			{
				return;
			}
			List<Transform> list2 = SeparatorParts;
			int num = list2.Count;
			int num2 = list.Count + 1;
			if (list2.Count >= num2)
			{
				return;
			}
			while (true)
			{
				object arg = num;
				string text = string.Format("{0}[{1}]", "Part", arg);
				Type[] array = new Type[1];
				Type typeFromHandle = typeof(RectTransform);
				if ((object)typeFromHandle != null)
				{
					object obj = typeFromHandle as Type;
					if (obj == null)
					{
						break;
					}
				}
				array[0] = typeFromHandle;
				GameObject gameObject = new GameObject(text, array);
				Transform transform = gameObject.transform;
				Transform parent = base.transform;
				transform.SetParent(parent, worldPositionStays: false);
				Transform transform2 = gameObject.transform;
				transform2.localPosition = Vector3.zero;
				List<Transform> list3 = SeparatorParts;
				Transform transform3 = gameObject.transform;
				Transform[] items = list3._items;
				int version = list3._version + 1;
				list3._version = version;
				int count = list3.Count;
				if (list3.Count < items.Length)
				{
					int size = list3.Count + 1;
					list3._size = size;
					items[count] = transform3;
				}
				else
				{
					list3.Add(transform3);
				}
				num++;
				if (num2 == num)
				{
					return;
				}
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x600057B")]
		[Address(RVA = "0x155BE54", Offset = "0x155BE54", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv28 = Il2CppMethodInfo;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv219 = Il2CppMethodInfo;\n\tv220 = \"il2cpp_codegen_initialize_runtime_metadata\"(v219, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv264 = Il2CppMethodInfo;\n\tv265 = \"il2cpp_codegen_initialize_runtime_metadata\"(v264, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv278 = Il2CppMethodInfo;\n\tv279 = \"il2cpp_codegen_initialize_runtime_metadata\"(v278, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv294 = \"Part\";\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v294, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A37C40]) = v48;\nL_0026:\n\tv49 = this.separatorSlots;\n\tv55 = v49._size == 0;\n\tif (v55) goto L_002E;\n\tv177 = v49._size + 1;\n\tgoto L_0089;\nL_002E:\n\tv270 = this.canvasRenderers;\nL_0044:\n\tv59 = v213 >= v270._size;\n\tif (v59) goto L_FFFFFFFF;\n\tv182 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::get_Item(v270, v213);\n\tv183 = UnityEngine.Component::get_transform(v182);\n\tv184 = UnityEngine.Transform::get_parent(v183);\n\tv185 = UnityEngine.Object::get_name(v184);\n\tv310 = System.String::Contains(v185, \"Part\");\n\tv312 = v310 == 0;\n\tif (v312) goto L_0082;\n\tv315 = UnityEngine.Component::get_transform(v182);\n\tv186 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::SetParent(v315, v186, 0);\n\tv330 = UnityEngine.Component::get_transform(v182);\n\tgoto L_0081;\n\tv333 = v178;\n\tv334 = \"il2cpp_codegen_initialize_runtime_metadata\"(v333, v155, v163, v131, v33, v34, v35, v36, v117, v125, v121, v40, v41, v42, v43, v44);\n\t*([1A35519]) = v166;\nL_0081:\n\tUnityEngine.Transform::set_localPosition(v330, v324.zeroVector);\nL_0082:\n\tv270 = this.canvasRenderers;\n\tv213 = v213 + 1;\n\tv325 = this.canvasRenderers == 0;\n\tv200 = ~v325;\n\tif (v200) goto L_0044;\n\tgoto L_00B7;\nL_0089:\n\tv248 = this.separatorParts;\nL_0099:\n\tv60 = v215 >= v248._size;\n\tif (v60) goto L_00C3;\n\tv188 = System.Collections.Generic.List`1<UnityEngine.Transform>::get_Item(v248, v215);\n\tv189 = UnityEngine.Component::get_gameObject(v188);\n\tv99 = v215 - v177;\n\tv93 = v99 < 0;\n\tv81 = v215 ^ v177;\n\tv75 = v215 ^ v99;\n\tv69 = v81 & v75;\n\tv63 = v69 < 0;\n\tv307 = v93 == v63;\n\tv57 = ~v307;\n\tUnityEngine.GameObject::SetActive(v189, v57);\n\tv248 = this.separatorParts;\n\tv215 = v215 + 1;\n\tv308 = this.separatorParts == 0;\n\tv193 = ~v308;\n\tif (v193) goto L_0099;\nL_00B7:\n\tthrow System.NullReferenceException;\nL_00C3:\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void UpdateSeparatorPartParents()
		{
			List<Slot> list = separatorSlots;
			int num;
			if (list.Count != 0)
			{
				num = list.Count + 1;
			}
			else
			{
				List<CanvasRenderer> list2 = canvasRenderers;
				int num2 = 0;
				while (num2 < list2.Count)
				{
					Component component = list2[num2];
					Transform transform = component.transform;
					Transform parent = transform.parent;
					string text = parent.name;
					if (text.Contains("Part"))
					{
						Transform transform2 = component.transform;
						Transform parent2 = base.transform;
						transform2.SetParent(parent2, worldPositionStays: false);
						Transform transform3 = component.transform;
						transform3.localPosition = Vector3.zero;
					}
					list2 = canvasRenderers;
					num2++;
					if (canvasRenderers != null)
					{
						continue;
					}
					goto IL_0274;
				}
				num = 0;
			}
			List<Transform> list3 = SeparatorParts;
			int num3 = 0;
			do
			{
				if (num3 < list3.Count)
				{
					Component component2 = list3[num3];
					GameObject gameObject = component2.gameObject;
					int num4 = num3 - num;
					bool flag = num4 < 0;
					int num5 = num3 ^ num;
					int num6 = num3 ^ num4;
					int num7 = num5 & num6;
					bool flag2 = num7 < 0;
					bool flag3 = flag == flag2;
					bool active = !flag3;
					gameObject.SetActive(active);
					list3 = SeparatorParts;
					num3++;
					continue;
				}
				return;
			}
			while (SeparatorParts != null);
			goto IL_0274;
			IL_0274:
			throw new NullReferenceException();
		}

		[Token(Token = "0x600057C")]
		[Address(RVA = "0x155E6D8", Offset = "0x155E6D8", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0058;\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv82 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv88 = System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv93 = Il2CppMethodInfo;\n\tv94 = \"il2cpp_codegen_initialize_runtime_metadata\"(v93, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv98 = Spine.ExposedList`1<UnityEngine.Mesh>;\n\tv99 = \"il2cpp_codegen_initialize_runtime_metadata\"(v98, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv103 = Il2CppMethodInfo;\n\tv104 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv108 = Il2CppMethodInfo;\n\tv109 = \"il2cpp_codegen_initialize_runtime_metadata\"(v108, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv114 = Il2CppMethodInfo;\n\tv115 = \"il2cpp_codegen_initialize_runtime_metadata\"(v114, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv119 = System.Collections.Generic.List`1<Spine.Slot>;\n\tv120 = \"il2cpp_codegen_initialize_runtime_metadata\"(v119, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv126 = System.Collections.Generic.List`1<UnityEngine.Transform>;\n\tv127 = \"il2cpp_codegen_initialize_runtime_metadata\"(v126, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv133 = System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>;\n\tv134 = \"il2cpp_codegen_initialize_runtime_metadata\"(v133, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv140 = Spine.Unity.MeshGenerator;\n\tv141 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv145 = Spine.Unity.SkeletonRendererInstruction;\n\tv146 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv152 = System.String[];\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v152, methodInfo, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv70 = 1;\n\t*([1A37C41]) = v70;\nL_0058:\n\tthis.timeScale = 1f;\n\tthis.updateMode = 3;\n\tv75 = new System.Collections.Generic.List`1<UnityEngine.CanvasRenderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.CanvasRenderer>::.ctor(v75);\n\tthis.canvasRenderers = v75;\n\t// 98 NewArr v86 @ X0_v5 (System.String[]), typeof(System.String[]), 0\n\tthis.separatorSlotNames = v86;\n\tv91 = new System.Collections.Generic.List`1<Spine.Slot>();\n\tSystem.Collections.Generic.List`1<Spine.Slot>::.ctor(v91);\n\tthis.separatorSlots = v91;\n\tv101 = new System.Collections.Generic.List`1<UnityEngine.Transform>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::.ctor(v101);\n\tthis.separatorParts = v101;\n\tthis.updateSeparatorPartLocation = 0x101;\n\tv112 = new System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Texture>::.ctor(v112);\n\tthis.customTextureOverride = v112;\n\tv124 = new System.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Texture, UnityEngine.Material>::.ctor(v124);\n\tthis.customMaterialOverride = v124;\n\tv138 = new Spine.Unity.MeshGenerator();\n\tSpine.Unity.MeshGenerator::.ctor(v138);\n\tthis.meshGenerator = v138;\n\tv150 = new Spine.Unity.SkeletonRendererInstruction();\n\tSpine.Unity.SkeletonRendererInstruction::.ctor(v150);\n\tthis.currentInstructions = v150;\n\tv158 = new Spine.ExposedList`1<UnityEngine.Mesh>();\n\tSpine.ExposedList`1<UnityEngine.Mesh>::.ctor(v158);\n\tthis.meshes = v158;\n\tUnityEngine.UI.MaskableGraphic::.ctor(this);\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonGraphic()
		{
			timeScale = 1f;
			UpdateMode = UpdateMode.FullUpdate;
			List<CanvasRenderer> list = new List<CanvasRenderer>();
			canvasRenderers = list;
			string[] array = new string[0];
			separatorSlotNames = array;
			List<Slot> list2 = new List<Slot>();
			separatorSlots = list2;
			List<Transform> list3 = new List<Transform>();
			separatorParts = list3;
			updateSeparatorPartLocation = true;
			wasUpdatedAfterInit = true;
			Dictionary<Texture, Texture> dictionary = new Dictionary<Texture, Texture>();
			customTextureOverride = dictionary;
			Dictionary<Texture, Material> dictionary2 = new Dictionary<Texture, Material>();
			customMaterialOverride = dictionary2;
			MeshGenerator meshGenerator = new MeshGenerator();
			this.meshGenerator = meshGenerator;
			SkeletonRendererInstruction skeletonRendererInstruction = new SkeletonRendererInstruction();
			currentInstructions = skeletonRendererInstruction;
			ExposedList<Mesh> exposedList = new ExposedList<Mesh>();
			meshes = exposedList;
		}
	}
}
