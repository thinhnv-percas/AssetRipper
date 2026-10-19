using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AllIn1SpriteShader
{
	[Token(Token = "0x2000010")]
	public class DemoItem : MonoBehaviour
	{
		[Token(Token = "0x4000042")]
		private static readonly Vector3 lookAtZ;

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3C201DC", Offset = "0x3C201DC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv57 = UnityEngine.Transform::get_position(v52);\n\tgoto L_0034;\nL_0034:\n\tv98 = v57.z + v109.lookAtZ.z;\n\tv100 = v57.y + v109.lookAtZ.y;\n\tv102 = v57 + v109.lookAtZ;\n\t// 67 MakeStruct v83 @ AGG3C20298_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v102 @ V0_v4 (System.Single), v100 @ V1_v4 (System.Single), v98 @ V2_v3 (System.Single)\n\tUnityEngine.Transform::LookAt(v48, v83);\n\treturn;\nL_0018:\n\tv48 = UnityEngine.Component::get_transform(this);\n\tv52 = UnityEngine.Component::get_transform(this);\n")]
		private void Update()
		{
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Vector3 position = transform2.position;
			float z = position.z + lookAtZ.z;
			float y = position.y + lookAtZ.y;
			float x = position.x + lookAtZ.x;
			Vector3 worldPosition = default(Vector3);
			worldPosition.x = x;
			worldPosition.y = y;
			worldPosition.z = z;
			transform.LookAt(worldPosition);
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3C202A0", Offset = "0x3C202A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DemoItem()
		{
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3C202A8", Offset = "0x3C202A8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tv40.lookAtZ.x = 0f;\n\tv40.lookAtZ.z = 1f;\n\treturn;\n")]
		static DemoItem()
		{
			lookAtZ.x = 0f;
			lookAtZ.z = 1f;
		}
	}
}
