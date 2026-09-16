using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000055")]
	public class MoveAndRotate : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000472")]
		public class Vector3andSpace
		{
			[Token(Token = "0x40020DC")]
			[FieldOffset(Offset = "0x10")]
			public Vector3 value;

			[Token(Token = "0x40020DD")]
			[FieldOffset(Offset = "0x1C")]
			public Space space;

			[Token(Token = "0x6001589")]
			[Address(RVA = "0x98D6F4", Offset = "0x98D6F4", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.space = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Vector3andSpace()
			{
				space = Space.Self;
			}
		}

		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x18")]
		public Vector3andSpace moveUnitsPerSecond;

		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x20")]
		public Vector3andSpace rotateDegreesPerSecond;

		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x28")]
		public bool ignoreTimescale;

		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x2C")]
		private float m_LastRealTime;

		[Token(Token = "0x6000256")]
		[Address(RVA = "0x98D584", Offset = "0x98D584", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis.m_LastRealTime = v11;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			m_LastRealTime = realtimeSinceStartup;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x98D5AC", Offset = "0x98D5AC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1ED4428]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20216F5]) = v46;\nL_0018:\n\tv48 = UnityEngine.Time::get_fixedDeltaTime();\n\tv51 = ~this.ignoreTimescale;\n\tif (v51) goto L_0026;\n\tv53 = UnityEngine.Time::get_realtimeSinceStartup();\n\tv58 = v53 - this.m_LastRealTime;\n\tv57 = UnityEngine.Time::get_realtimeSinceStartup();\n\tthis.m_LastRealTime = v57;\nL_0026:\n\tv64 = UnityEngine.Component::get_transform(this);\n\tv65 = this.moveUnitsPerSecond;\n\tgoto L_003F;\n\tv125 = *([v73 @ X0_v9+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_003F;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v73, v63, v30, v31, v32, v33, v34, v35, v56, v54, v38, v39, v40, v41, v42, v43);\nL_003F:\n\t// 63 MakeStruct v89 @ AGG98D66C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v65.value (UnityEngine.Vector3), v65.value.y (System.Single), v65.value.z (System.Single)\n\tv105 = UnityEngine.Vector3::op_Multiply(v89, v58);\n\tv118 = this.moveUnitsPerSecond;\n\tUnityEngine.Transform::Translate(v64, v105, v118.space);\n\tv109 = UnityEngine.Component::get_transform(this);\n\tv119 = this.rotateDegreesPerSecond;\n\t// 89 MakeStruct v79 @ AGG98D6B4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v119.value (UnityEngine.Vector3), v119.value.y (System.Single), v119.value.z (System.Single)\n\tv106 = UnityEngine.Vector3::op_Multiply(v79, v58);\n\tv120 = this.moveUnitsPerSecond;\n\tUnityEngine.Transform::Rotate(v109, v106, v120.space);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			float fixedDeltaTime = Time.fixedDeltaTime;
			bool flag = !ignoreTimescale;
			float num = fixedDeltaTime;
			if (!flag)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				num = realtimeSinceStartup - m_LastRealTime;
				float realtimeSinceStartup2 = Time.realtimeSinceStartup;
				m_LastRealTime = realtimeSinceStartup2;
			}
			Transform transform = base.transform;
			Vector3andSpace vector3andSpace = moveUnitsPerSecond;
			Vector3 vector = default(Vector3);
			vector.x = vector3andSpace.value.x;
			vector.y = vector3andSpace.value.y;
			vector.z = vector3andSpace.value.z;
			Vector3 translation = vector * num;
			Vector3andSpace vector3andSpace2 = moveUnitsPerSecond;
			transform.Translate(translation, vector3andSpace2.space);
			Transform transform2 = base.transform;
			Vector3andSpace vector3andSpace3 = rotateDegreesPerSecond;
			Vector3 vector2 = default(Vector3);
			vector2.x = vector3andSpace3.value.x;
			vector2.y = vector3andSpace3.value.y;
			vector2.z = vector3andSpace3.value.z;
			Vector3 eulers = vector2 * num;
			Vector3andSpace vector3andSpace4 = moveUnitsPerSecond;
			transform2.Rotate(eulers, vector3andSpace4.space);
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x98D6EC", Offset = "0x98D6EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MoveAndRotate()
		{
		}
	}
}
