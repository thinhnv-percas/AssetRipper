using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7442DC", Offset = "0x7442DC")]
	[Token(Token = "0x200002B")]
	public class ObiRigidbody : ObiRigidbodyBase
	{
		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0xA0")]
		private Rigidbody unityRigidbody;

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xC32910", Offset = "0xC32910", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED38D8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023196]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityRigidbody = v43;\n\tObi.ObiRigidbodyBase::Awake(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Awake()
		{
			Rigidbody component = GetComponent<Rigidbody>();
			unityRigidbody = component;
			base.Awake();
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xC32A3C", Offset = "0xC32A3C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Rigidbody::get_velocity(this.unityRigidbody);\n\tthis.velocity = v15;\n\tthis.velocity.y = v15.y;\n\tthis.velocity.z = v15.z;\n\tv43 = UnityEngine.Rigidbody::get_angularVelocity(this.unityRigidbody);\n\tv68 = this + 0x28;\n\tthis.angularVelocity = v43;\n\tthis.angularVelocity.y = v43.y;\n\tthis.angularVelocity.z = v43.z;\n\tv70 = 0x103B4C0(v68, this.unityRigidbody, this.kinematicForParticles, 0, v33, v34, v35, v36, v43, v43.y, v43.z, v37, v38, v39, v40, v41);\n\tv61 = Obi.ObiRigidbodyBase::get_OniRigidbody(this);\n\tOni::UpdateRigidbody(v61, v68);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void UpdateIfNeeded()
		{
			Vector3 vector = (velocity = unityRigidbody.velocity);
			velocity.y = vector.y;
			velocity.z = vector.z;
			Vector3 vector2 = unityRigidbody.angularVelocity;
			ref Oni.Rigidbody reference = ref *(Oni.Rigidbody*)((long)(IntPtr)this + 40L);
			angularVelocity = vector2;
			angularVelocity.y = vector2.y;
			angularVelocity.z = vector2.z;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103B4C0 (inside Oni::GetProfilingInfo +0x6B0)");
			IntPtr rigidbody = base.OniRigidbody;
			Oni.UpdateRigidbody(rigidbody, ref reference);
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xC32B1C", Offset = "0xC32B1C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = *([1EB7180]);\n\tv35 = *([v34 @ X8_v15]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2023197]) = v54;\nL_001C:\n\tv56 = UnityEngine.Application::get_isPlaying();\n\tv58 = v56 == 0;\n\tif (v58) goto L_0039;\n\tv64 = UnityEngine.Rigidbody::get_isKinematic(this.unityRigidbody);\n\tv215 = v64 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_003B;\n\tv66 = ~this.kinematicForParticles;\n\tif (v66) goto L_003B;\nL_0039:\n\treturn;\nL_003B:\n\tv220 = Obi.ObiRigidbodyBase::get_OniRigidbody(this);\n\tv221 = this + 0x6C;\n\tOni::GetRigidbodyVelocity(v220, v221);\n\tv226 = UnityEngine.Rigidbody::get_velocity(this.unityRigidbody);\n\tgoto L_0063;\n\tv254 = *([v250 @ X0_v15+E0]);\n\tv255 = v254 == 0;\n\tv256 = ~v255;\n\tif (v256) goto L_0063;\n\tv258 = \"il2cpp_codegen_runtime_class_init\"(v250, v225, v112, v39, v40, v41, v42, v43, v226, v246, v247, v47, v48, v49, v50, v51);\nL_0063:\n\t// 99 MakeStruct v166 @ AGGC32C2C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.oniVelocities (Oni+RigidbodyVelocities), this.oniVelocities.linearVelocity.y (System.Single), this.oniVelocities.linearVelocity.z (System.Single)\n\t// 100 MakeStruct v164 @ AGGC32C2C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.velocity (UnityEngine.Vector3), this.velocity.y (System.Single), this.velocity.z (System.Single)\n\tv267 = UnityEngine.Vector3::op_Subtraction(v166, v164);\n\tv232 = UnityEngine.Vector3::op_Addition(v226, v267);\n\tUnityEngine.Rigidbody::set_velocity(this.unityRigidbody, v232);\n\tv276 = UnityEngine.Rigidbody::get_angularVelocity(this.unityRigidbody);\n\t// 139 MakeStruct v154 @ AGGC32C94_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.oniVelocities.angularVelocity (UnityEngine.Vector3), this.oniVelocities.angularVelocity.y (System.Single), this.oniVelocities.angularVelocity.z (System.Single)\n\t// 140 MakeStruct v151 @ AGGC32C94_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.angularVelocity (UnityEngine.Vector3), this.angularVelocity.y (System.Single), this.angularVelocity.z (System.Single)\n\tv289 = UnityEngine.Vector3::op_Subtraction(v154, v151);\n\tv180 = UnityEngine.Vector3::op_Addition(v276, v289);\n\tUnityEngine.Rigidbody::set_angularVelocity(this.unityRigidbody, v180);\n\treturn;\n\tv132 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void UpdateVelocities()
		{
			//IL_00a3: Expected F4, but got O
			if (Application.isPlaying && (unityRigidbody.isKinematic || !kinematicForParticles))
			{
				IntPtr rigidbody = base.OniRigidbody;
				Oni.GetRigidbodyVelocity(rigidbody, ref *(Oni.RigidbodyVelocities*)((long)(IntPtr)this + 108L));
				Vector3 vector = unityRigidbody.velocity;
				Vector3 vector2 = default(Vector3);
				vector2.x = (float)oniVelocities;
				vector2.y = oniVelocities.linearVelocity.y;
				vector2.z = oniVelocities.linearVelocity.z;
				Vector3 vector3 = default(Vector3);
				vector3.x = velocity.x;
				vector3.y = velocity.y;
				vector3.z = velocity.z;
				Vector3 vector4 = vector2 - vector3;
				Vector3 vector5 = vector + vector4;
				unityRigidbody.velocity = vector5;
				Vector3 vector6 = unityRigidbody.angularVelocity;
				Vector3 vector7 = default(Vector3);
				vector7.x = oniVelocities.angularVelocity.x;
				vector7.y = oniVelocities.angularVelocity.y;
				vector7.z = oniVelocities.angularVelocity.z;
				Vector3 vector8 = default(Vector3);
				vector8.x = angularVelocity.x;
				vector8.y = angularVelocity.y;
				vector8.z = angularVelocity.z;
				Vector3 vector9 = vector7 - vector8;
				Vector3 vector10 = vector6 + vector9;
				unityRigidbody.angularVelocity = vector10;
			}
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0xC32CEC", Offset = "0xC32CEC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8DC8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023198]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tObi.ObiRigidbodyBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRigidbody()
		{
		}
	}
}
