using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000059")]
	public class SkeletonGraphicMirror : MonoBehaviour
	{
		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonRenderer source;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x28")]
		public bool mirrorOnStart;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0x29")]
		public bool restoreOnDisable;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0x30")]
		private SkeletonGraphic skeletonGraphic;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0x38")]
		private Skeleton originalSkeleton;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0x40")]
		private bool originalFreeze;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0x48")]
		private Texture2D overrideTexture;

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x1518910", Offset = "0x1518910", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A83]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonGraphic = v40;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			SkeletonGraphic component = GetComponent<SkeletonGraphic>();
			skeletonGraphic = component;
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x1518960", Offset = "0x1518960", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.mirrorOnStart;\n\tif (v2) goto L_0005;\n\tSpine.Unity.Examples.SkeletonGraphicMirror::StartMirroring(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (mirrorOnStart)
			{
				StartMirroring();
			}
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0x1518AA4", Offset = "0x1518AA4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonGraphic::UpdateMesh(this.skeletonGraphic);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			skeletonGraphic.UpdateMesh();
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x1518AC0", Offset = "0x1518AC0", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.restoreOnDisable;\n\tif (v2) goto L_0005;\n\tSpine.Unity.Examples.SkeletonGraphicMirror::RestoreIndependentSkeleton(this);\n\treturn;\nL_0005:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (restoreOnDisable)
			{
				RestoreIndependentSkeleton();
			}
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x1518970", Offset = "0x1518970", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = System.String;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A84]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.source, 0);\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_006B;\n\tgoto L_002F;\n\tv86 = \"il2cpp_codegen_runtime_class_init\"(v55, v49, v50, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002F:\n\tv73 = UnityEngine.Object::op_Equality(this.skeletonGraphic, 0);\n\tv117 = v73 == 0;\n\tv76 = ~v117;\n\tif (v76) goto L_006B;\n\tv118 = this.skeletonGraphic;\n\tv118.startingAnimation = v123.Empty;\n\tv126 = this.originalSkeleton == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_0045;\n\tthis.originalSkeleton = v118.skeleton;\n\tthis.originalFreeze = v118.freeze;\nL_0045:\n\tv128 = this.source;\n\tv118.freeze = 1;\n\tv118.skeleton = v128.skeleton;\n\tgoto L_0056;\n\tv137 = \"il2cpp_codegen_runtime_class_init\"(v134, v70, v67, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0056:\n\tv74 = UnityEngine.Object::op_Inequality(this.overrideTexture, 0);\n\tv77 = v74 == 0;\n\tif (v77) goto L_006B;\n\tSpine.Unity.SkeletonGraphic::set_OverrideTexture(this.skeletonGraphic, this.overrideTexture);\n\treturn;\nL_006B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void StartMirroring()
		{
			if (!(source == null) && !(this.skeletonGraphic == null))
			{
				SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
				skeletonGraphic.startingAnimation = string.Empty;
				if (originalSkeleton == null)
				{
					originalSkeleton = skeletonGraphic.Skeleton;
					originalFreeze = skeletonGraphic.freeze;
				}
				SkeletonRenderer skeletonRenderer = source;
				skeletonGraphic.freeze = true;
				skeletonGraphic.Skeleton = skeletonRenderer.skeleton;
				if (overrideTexture != null)
				{
					this.skeletonGraphic.OverrideTexture = overrideTexture;
				}
			}
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0x1518B10", Offset = "0x1518B10", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, newOverrideTexture, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37A85]) = v40;\nL_0015:\n\tthis.overrideTexture = newOverrideTexture;\n\tgoto L_001F;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, newOverrideTexture, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv50 = UnityEngine.Object::op_Inequality(newOverrideTexture, 0);\n\tv52 = v50 == 0;\n\tif (v52) goto L_0036;\n\tSpine.Unity.SkeletonGraphic::set_OverrideTexture(this.skeletonGraphic, this.overrideTexture);\n\treturn;\nL_0036:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateTexture(Texture2D newOverrideTexture)
		{
			overrideTexture = newOverrideTexture;
			if (newOverrideTexture != null)
			{
				skeletonGraphic.OverrideTexture = overrideTexture;
			}
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x1518AD0", Offset = "0x1518AD0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.originalSkeleton == 0;\n\tif (v6) goto L_0014;\n\tv8 = this.skeletonGraphic;\n\tv8.skeleton = this.originalSkeleton;\n\tv8.freeze = this.originalFreeze;\n\tSpine.Unity.SkeletonGraphic::set_OverrideTexture(v8, 0);\n\tthis.originalSkeleton = 0;\nL_0014:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RestoreIndependentSkeleton()
		{
			if (originalSkeleton != null)
			{
				SkeletonGraphic skeletonGraphic = this.skeletonGraphic;
				skeletonGraphic.Skeleton = originalSkeleton;
				skeletonGraphic.freeze = originalFreeze;
				skeletonGraphic.OverrideTexture = null;
				originalSkeleton = null;
			}
		}

		[Token(Token = "0x6000178")]
		[Address(RVA = "0x1518BA8", Offset = "0x1518BA8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mirrorOnStart = 0x101;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonGraphicMirror()
		{
			mirrorOnStart = true;
			restoreOnDisable = true;
		}
	}
}
