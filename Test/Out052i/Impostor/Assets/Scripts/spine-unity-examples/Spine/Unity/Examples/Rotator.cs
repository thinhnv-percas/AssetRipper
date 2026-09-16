using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x2000048")]
	public class Rotator : MonoBehaviour
	{
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x20")]
		public Vector3 direction;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x2C")]
		public float speed;

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x1514E50", Offset = "0x1514E50", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_transform(this);\n\tv22 = UnityEngine.Time::get_deltaTime();\n\tv25 = this.speed * v22;\n\tv27 = v25 * 0x42C80000;\n\tv28 = this.direction.z * v27;\n\tv29 = this.direction.y * v27;\n\tv30 = this.direction * v27;\n\t// 35 MakeStruct v39 @ AGG1518EB0_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v30 @ V0_v4 (System.Single), v29 @ V1_v2 (System.Single), v28 @ V2_v1 (System.Single)\n\tUnityEngine.Transform::Rotate(v15, v39);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			Transform transform = base.transform;
			float deltaTime = Time.deltaTime;
			float num = speed * deltaTime;
			float num2 = num * 100f;
			float z = direction.z * num2;
			float y = direction.y * num2;
			float x = direction.x * num2;
			Vector3 eulers = default(Vector3);
			eulers.x = x;
			eulers.y = y;
			eulers.z = z;
			transform.Rotate(eulers);
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x1514EB8", Offset = "0x1514EB8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.direction = *([4079C0]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Rotator()
		{
			//IL_0018: Expected O, but got I
			base._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [4079C0]");
			direction = (Vector3)0;
		}
	}
}
