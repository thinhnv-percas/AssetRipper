using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(SkeletonRenderer))]
	[ExecuteInEditMode]
	[Token(Token = "0x2000078")]
	public class SpineGauge : MonoBehaviour
	{
		[Range(0f, 1f)]
		[Token(Token = "0x40002B0")]
		[FieldOffset(Offset = "0x20")]
		public float fillPercent;

		[Token(Token = "0x40002B1")]
		[FieldOffset(Offset = "0x28")]
		public AnimationReferenceAsset fillAnimation;

		[Token(Token = "0x40002B2")]
		[FieldOffset(Offset = "0x30")]
		private SkeletonRenderer skeletonRenderer;

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x1520BF0", Offset = "0x1520BF0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37AC3]) = v37;\nL_0015:\n\tv40 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonRenderer = v40;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			SkeletonRenderer component = GetComponent<SkeletonRenderer>();
			skeletonRenderer = component;
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x1520C40", Offset = "0x1520C40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.SpineGauge::SetGaugePercent(this, this.fillPercent);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			SetGaugePercent(fillPercent);
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x1520C48", Offset = "0x1520C48", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = UnityEngine.Object;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, percent, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37AC4]) = v40;\nL_001A:\n\tgoto L_001F;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v25, v26, v27, v28, v29, v30, percent, v31, v32, v33, v34, v35, v36, v37);\nL_001F:\n\tv51 = UnityEngine.Object::op_Equality(this.skeletonRenderer, 0);\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0050;\n\tv55 = this.skeletonRenderer;\n\tv58 = v55.skeleton == 0;\n\tif (v58) goto L_0050;\n\tv71 = Spine.Unity.AnimationReferenceAsset::get_Animation(this.fillAnimation);\n\tSpine.Animation::Apply(v71, v55.skeleton, 0f, percent, 0, 0, 1f, 0, 0);\n\tv92 = UnityEngine.Time::get_deltaTime();\n\tSpine.Skeleton::Update(v55.skeleton, v92);\n\tSpine.Skeleton::UpdateWorldTransform(v55.skeleton);\n\treturn;\nL_0050:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetGaugePercent(float percent)
		{
			if (!(this.skeletonRenderer == null))
			{
				SkeletonRenderer skeletonRenderer = this.skeletonRenderer;
				if (skeletonRenderer.skeleton != null)
				{
					Animation animation = fillAnimation.Animation;
					animation.Apply(skeletonRenderer.skeleton, 0f, percent, loop: false, null, 1f, default(MixBlend), default(MixDirection));
					float deltaTime = Time.deltaTime;
					skeletonRenderer.skeleton.Update(deltaTime);
					skeletonRenderer.skeleton.UpdateWorldTransform();
				}
			}
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0x1520D38", Offset = "0x1520D38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineGauge()
		{
		}
	}
}
