using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000026")]
	public class SpineboyTargetController : MonoBehaviour
	{
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x20")]
		public SkeletonAnimation skeletonAnimation;

		[SpineBone(null, "skeletonAnimation", true, false)]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x28")]
		public string boneName;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x30")]
		public Camera cam;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x38")]
		private Bone bone;

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x150D9D8", Offset = "0x150D9D8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv45 = UnityEngine.Object;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37A14]) = v38;\nL_001B:\n\tgoto L_0020;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v39, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0020:\n\tv51 = UnityEngine.Object::op_Equality(this.skeletonAnimation, 0);\n\tv53 = v51 == 0;\n\tif (v53) goto L_002F;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tthis.skeletonAnimation = v58;\nL_002F:\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			if (skeletonAnimation == null)
			{
				SkeletonAnimation component = GetComponent<SkeletonAnimation>();
				skeletonAnimation = component;
			}
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x150DA64", Offset = "0x150DA64", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv32 = Spine.Skeleton::FindBone(v9, this.boneName);\n\tthis.bone = v32;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Bone bone = skeleton.FindBone(boneName);
			this.bone = bone;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x150DA9C", Offset = "0x150DA9C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Input::get_mousePosition();\n\tv22 = UnityEngine.Camera::ScreenToWorldPoint(this.cam, v15);\n\tv65 = UnityEngine.Component::get_transform(this.skeletonAnimation);\n\tv62 = UnityEngine.Transform::InverseTransformPoint(v65, v22);\n\tv67 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv68 = Spine.Unity.SkeletonRenderer::get_Skeleton(this.skeletonAnimation);\n\tv115 = v62 * v67.scaleX;\n\tv116 = Spine.Skeleton::get_ScaleY(v68);\n\tv103 = v62.y * v116;\n\t// 72 MakeStruct v82 @ AGG1511B60_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v115 @ V10_v4 (System.Single), v103 @ V1_v6 (System.Single), v62.z (System.Single)\n\tSpine.Unity.SkeletonExtensions::SetLocalPosition(this.bone, v82);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			Vector3 mousePosition = Input.mousePosition;
			Vector3 position = cam.ScreenToWorldPoint(mousePosition);
			Transform transform = skeletonAnimation.transform;
			Vector3 vector = transform.InverseTransformPoint(position);
			Skeleton skeleton = skeletonAnimation.Skeleton;
			Skeleton skeleton2 = skeletonAnimation.Skeleton;
			float x = vector.x * skeleton.ScaleX;
			float scaleY = skeleton2.ScaleY;
			float y = vector.y * scaleY;
			Vector3 position2 = default(Vector3);
			position2.x = x;
			position2.y = y;
			position2.z = vector.z;
			bone.SetLocalPosition(position2);
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x150DB68", Offset = "0x150DB68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SpineboyTargetController()
		{
		}
	}
}
