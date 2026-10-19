using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Examples
{
	[Token(Token = "0x2000004")]
	public class Bounce : MonoBehaviour
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x20")]
		private Vector3 m_Origin;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x2C")]
		private float m_Offset;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3C2DFD0", Offset = "0x3C2DFD0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Component::get_transform(this);\n\tv16 = UnityEngine.Transform::get_position(v13);\n\tthis.m_Origin.x = v16;\n\tthis.m_Origin.y = v16.y;\n\tthis.m_Origin.z = v16.z;\n\tv35 = UnityEngine.Random::get_value();\n\tv39 = v35 * 0x40490FDB;\n\tthis.m_Offset = v39;\n\treturn;\n")]
		private void Start()
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			m_Origin.x = position.x;
			m_Origin.y = position.y;
			m_Origin.z = position.z;
			float value = UnityEngine.Random.value;
			float offset = value * (float)Math.PI;
			m_Offset = offset;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3C2E028", Offset = "0x3C2E028", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = UnityEngine.Component::get_transform(this);\n\tv32 = UnityEngine.Time::get_time();\n\tv37 = v32 * 3f;\n\tv38 = this.m_Offset + v37;\n\tv39 = 0x8BF749C(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v38, 3f, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv54 = UnityEngine.Mathf::Abs(v38);\n\tv55 = this.m_Origin.y + v54;\n\t// 47 MakeStruct v70 @ AGG3C2E0A8_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.m_Origin (UnityEngine.Vector3), v55 @ V1_v2 (System.Single), this.m_Origin.z (System.Single)\n\tUnityEngine.Transform::set_position(v25, v70);\n\treturn;\n")]
		private void Update()
		{
			Transform transform = base.transform;
			float time = Time.time;
			float num = time * 3f;
			float f = m_Offset + num;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num2 = Mathf.Abs(f);
			float y = m_Origin.y + num2;
			Vector3 position = default(Vector3);
			position.x = m_Origin.x;
			position.y = y;
			position.z = m_Origin.z;
			transform.position = position;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3C2E0B0", Offset = "0x3C2E0B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public Bounce()
		{
		}
	}
}
