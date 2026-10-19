using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1VfxToolkit
{
	[Token(Token = "0x2000011")]
	public class AllIn1VfxBounceAnimation : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000057")]
		[FieldOffset(Offset = "0x20")]
		private Vector3 targetOffset;

		[SerializeField]
		[Token(Token = "0x4000058")]
		[FieldOffset(Offset = "0x2C")]
		private float speed;

		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x30")]
		private Vector3 startPosition;

		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x3C")]
		private Vector3 animationMovementVector;

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x3C256D8", Offset = "0x3C256D8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_transform(this);\n\tv16 = UnityEngine.Transform::get_position(v13);\n\tthis.startPosition.x = v16;\n\tthis.startPosition.y = v16.y;\n\tthis.startPosition.z = v16.z;\n\treturn;\n")]
		private void Start()
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			startPosition.x = position.x;
			startPosition.y = position.y;
			startPosition.z = position.z;
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x3C25714", Offset = "0x3C25714", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Time::get_time();\n\tv21 = v19 * this.speed;\n\tv22 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v21, this.speed, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv37 = v21 + 1f;\n\tv39 = v37 * 0.5f;\n\tv40 = this.targetOffset * v41;\n\tv42 = this.targetOffset.z * v39;\n\tthis.animationMovementVector = v40;\n\tthis.animationMovementVector.z = v42;\n\tv45 = UnityEngine.Component::get_transform(this);\n\tv49 = this.startPosition.z + this.animationMovementVector.z;\n\tv52 = this.startPosition + this.animationMovementVector;\n\t// 44 MakeStruct v62 @ AGG3C257A0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v52 @ V0_v8 (System.Single), v54 @ V0.S1, v49 @ V2_v1 (System.Single)\n\tUnityEngine.Transform::set_position(v45, v62);\n\treturn;\n")]
		private void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxBounceAnimation::Update");
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x3C257A8", Offset = "0x3C257A8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\t*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxBounceAnimation)+20]) = v48.upVector;\n\t*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxBounceAnimation)+28]) = v48.upVector.z;\n\t*([this @ X0 (AllIn1VfxToolkit.AllIn1VfxBounceAnimation)+2C]) = 0x3F800000;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1VfxBounceAnimation()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1VfxBounceAnimation::.ctor");
		}
	}
}
