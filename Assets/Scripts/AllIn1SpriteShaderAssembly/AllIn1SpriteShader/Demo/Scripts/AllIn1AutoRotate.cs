using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader.Demo.Scripts
{
	[Token(Token = "0x200001B")]
	public class AllIn1AutoRotate : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x20")]
		private float rotationSpeed;

		[SerializeField]
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x24")]
		private Vector3 rotationAxis;

		[SerializeField]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x30")]
		private bool useLocalRotation;

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x3C24474", Offset = "0x3C24474", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = UnityEngine.Component::get_transform(this);\n\tv28 = UnityEngine.Time::get_deltaTime();\n\tv31 = this.rotationSpeed * v28;\n\tv32 = this.rotationAxis.z * v31;\n\tv33 = this.rotationAxis.y * v31;\n\tv34 = this.rotationAxis * v31;\n\t// 38 MakeStruct v45 @ AGG3C244D8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v34 @ V0_v3 (System.Single), v33 @ V1_v1 (System.Single), v32 @ V2_v1 (System.Single)\n\tUnityEngine.Transform::Rotate(v21, v45, this.useLocalRotation);\n\treturn;\n")]
		private void Update()
		{
			Transform transform = base.transform;
			float deltaTime = Time.deltaTime;
			float num = rotationSpeed * deltaTime;
			float z = rotationAxis.z * num;
			float y = rotationAxis.y * num;
			float x = rotationAxis.x * num;
			Vector3 eulers = default(Vector3);
			eulers.x = x;
			eulers.y = y;
			eulers.z = z;
			transform.Rotate(eulers, useLocalRotation ? Space.Self : Space.World);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3C244E0", Offset = "0x3C244E0", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotationSpeed = 30f;\n\tgoto L_001E;\nL_001E:\n\t*([this @ X0 (AllIn1SpriteShader.Demo.Scripts.AllIn1AutoRotate)+24]) = v49.upVector;\n\t*([this @ X0 (AllIn1SpriteShader.Demo.Scripts.AllIn1AutoRotate)+2C]) = v49.upVector.z;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public AllIn1AutoRotate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AllIn1AutoRotate::.ctor");
		}
	}
}
