using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Obi
{
	[Attribute(Type = typeof(RequireComponent), RVA = "0x744AAC", Offset = "0x744AAC")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x744AAC", Offset = "0x744AAC")]
	[Token(Token = "0x2000056")]
	public class ObiParticleDragger : MonoBehaviour
	{
		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x18")]
		public float springStiffness;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x1C")]
		public float springDamping;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x20")]
		public bool drawSpring;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x28")]
		private LineRenderer lineRenderer;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x30")]
		private ObiParticlePicker picker;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x38")]
		private ObiParticlePicker.ParticlePickEventArgs pickArgs;

		[Token(Token = "0x60003AA")]
		[Address(RVA = "0xC294E0", Offset = "0xC294E0", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EA7F18]);\n\tv29 = *([v28 @ X8_v15]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023142]) = v48;\nL_001C:\n\tv53 = UnityEngine.Component::GetComponent(this);\n\tthis.lineRenderer = v53;\n\tv58 = UnityEngine.Component::GetComponent(this);\n\tthis.picker = v58;\n\tv64 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v64, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::AddListener(v58.OnParticlePicked, v64);\n\tv147 = this.picker;\n\tv141 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v141, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::AddListener(v147.OnParticleDragged, v141);\n\tv148 = this.picker;\n\tv143 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v143, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::AddListener(v148.OnParticleReleased, v143);\n\treturn;\n\tv81 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			LineRenderer component = GetComponent<LineRenderer>();
			lineRenderer = component;
			ObiParticlePicker obiParticlePicker = (picker = GetComponent<ObiParticlePicker>());
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call = Picker_OnParticleDragged;
			obiParticlePicker.OnParticlePicked.AddListener(call);
			ObiParticlePicker obiParticlePicker2 = picker;
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call2 = Picker_OnParticleDragged;
			obiParticlePicker2.OnParticleDragged.AddListener(call2);
			ObiParticlePicker obiParticlePicker3 = picker;
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call3 = Picker_OnParticleReleased;
			obiParticlePicker3.OnParticleReleased.AddListener(call3);
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0xC29648", Offset = "0xC29648", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EEDA70]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2023143]) = v48;\nL_0018:\n\tv49 = this.picker;\n\tv55 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v55, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::RemoveListener(v49.OnParticlePicked, v55);\n\tv95 = this.picker;\n\tv85 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v85, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::RemoveListener(v95.OnParticleDragged, v85);\n\tv96 = this.picker;\n\tv87 = new UnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>();\n\tUnityEngine.Events.UnityAction`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(v87, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::RemoveListener(v96.OnParticleReleased, v87);\n\tUnityEngine.LineRenderer::set_positionCount(this.lineRenderer, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			ObiParticlePicker obiParticlePicker = picker;
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call = Picker_OnParticleDragged;
			obiParticlePicker.OnParticlePicked.RemoveListener(call);
			ObiParticlePicker obiParticlePicker2 = picker;
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call2 = Picker_OnParticleDragged;
			obiParticlePicker2.OnParticleDragged.RemoveListener(call2);
			ObiParticlePicker obiParticlePicker3 = picker;
			UnityAction<ObiParticlePicker.ParticlePickEventArgs> call3 = Picker_OnParticleReleased;
			obiParticlePicker3.OnParticleReleased.RemoveListener(call3);
			lineRenderer.positionCount = 0;
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0xC29794", Offset = "0xC29794", Length = "0x398")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv38 = *([1EE7D50]);\n\tv39 = *([v38 @ X8_v30]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2023144]) = v58;\nL_001D:\n\tv59 = this.picker;\n\tgoto L_0030;\n\tv272 = *([v64 @ X0_v6+E0]);\n\tv273 = v272 == 0;\n\tv274 = ~v273;\n\tif (v274) goto L_0030;\n\tv276 = \"il2cpp_codegen_runtime_class_init\"(v64, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0030:\n\tv238 = UnityEngine.Object::op_Inequality(v59.solver, 0);\n\tv347 = v238 == 0;\n\tif (v347) goto L_0153;\n\tv348 = this.pickArgs == 0;\n\tif (v348) goto L_0153;\n\tv239 = UnityEngine.Component::get_transform(v59.solver);\n\tv261 = this.pickArgs;\n\t// 69 MakeStruct v198 @ AGGC29850_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v261.worldPosition (UnityEngine.Vector3), v261.worldPosition.y (System.Single), v261.worldPosition.z (System.Single)\n\tv494 = UnityEngine.Transform::InverseTransformPoint(v239, v198);\n\tgoto L_005D;\n\tv505 = *([v501 @ X0_v13+E0]);\n\tv506 = v505 == 0;\n\tv507 = ~v506;\n\tif (v507) goto L_005D;\n\tv509 = \"il2cpp_codegen_runtime_class_init\"(v501, v493, v215, v43, v44, v45, v46, v47, v494, v495, v496, v51, v52, v53, v54, v55);\nL_005D:\n\tv210 = UnityEngine.Vector4::op_Implicit(v494);\n\tv240 = Obi.ObiSolver::get_invMasses(v59.solver);\n\tv262 = this.pickArgs;\n\tv375 = Obi.ObiNativeFloatList::get_Item(v240, v262.particleIndex);\n\tv143 = v210 <= 0;\n\tif (v143) goto L_0153;\n\tv241 = Obi.ObiSolver::get_positions(v59.solver);\n\tv263 = this.pickArgs;\n\tv523 = Obi.ObiNativeVector4List::get_Item(v241, v263.particleIndex);\n\tv242 = Obi.ObiSolver::get_velocities(v59.solver);\n\tv264 = this.pickArgs;\n\tv527 = Obi.ObiNativeVector4List::get_Item(v242, v264.particleIndex);\n\tv243 = Obi.ObiSolver::get_externalForces(v59.solver);\n\tv265 = this.pickArgs;\n\tgoto L_00C3;\n\tv532 = *([v529 @ X0_v27+E0]);\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\tif (v534) goto L_00C3;\n\tv536 = \"il2cpp_codegen_runtime_class_init\"(v529, v227, v218, v43, v44, v45, v46, v47, v210, v205, v200, v175, v52, v53, v54, v55);\nL_00C3:\n\tv547 = UnityEngine.Vector4::op_Subtraction(v210, v210);\n\tv553 = UnityEngine.Vector4::op_Multiply(v547, this.springStiffness);\n\tv563 = UnityEngine.Vector4::op_Multiply(v210, this.springDamping);\n\tv573 = UnityEngine.Vector4::op_Subtraction(v553, v563);\n\tVector4_arg = UnityEngine.Vector4::op_Division(v573, v210);\n\tv578 = Obi.ObiNativeVector4List::set_Item(v243, v265.particleIndex, Vector4_arg);\n\tv477 = ~this.drawSpring;\n\tif (v477) goto L_0165;\n\tUnityEngine.LineRenderer::set_positionCount(this.lineRenderer, 2);\n\tgoto L_0119;\n\tv583 = *([v579 @ X0_v37+E0]);\n\tv584 = v583 == 0;\n\tv585 = ~v584;\n\tif (v585) goto L_0119;\n\tv587 = \"il2cpp_codegen_runtime_class_init\"(v579, v228, v219, v43, v44, v45, v46, v47, v211, v206, v201, v176, v115, v117, v111, v113);\nL_0119:\n\tv212 = UnityEngine.Vector4::op_Implicit(v210);\n\tUnityEngine.LineRenderer::SetPosition(this.lineRenderer, 0, v212);\n\tv213 = UnityEngine.Vector4::op_Implicit(v210);\n\tUnityEngine.LineRenderer::SetPosition(this.lineRenderer, 1, v213);\n\treturn;\nL_0153:\n\treturn;\nL_0165:\n\tUnityEngine.LineRenderer::set_positionCount(this.lineRenderer, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 289 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FixedUpdate()
		{
			ObiParticlePicker obiParticlePicker = picker;
			if (!(obiParticlePicker.solver != null) || pickArgs == null)
			{
				return;
			}
			Transform transform = obiParticlePicker.solver.transform;
			ObiParticlePicker.ParticlePickEventArgs e = pickArgs;
			Vector3 position = default(Vector3);
			position.x = e.worldPosition.x;
			position.y = e.worldPosition.y;
			position.z = e.worldPosition.z;
			Vector3 vector = transform.InverseTransformPoint(position);
			Vector4 vector2 = vector;
			ObiNativeFloatList invMasses = obiParticlePicker.solver.invMasses;
			ObiParticlePicker.ParticlePickEventArgs e2 = pickArgs;
			float num = invMasses.get_Item(e2.particleIndex);
			if (vector2.x > 0f)
			{
				ObiNativeVector4List positions = obiParticlePicker.solver.positions;
				ObiParticlePicker.ParticlePickEventArgs e3 = pickArgs;
				Vector4 vector3 = positions.get_Item(e3.particleIndex);
				ObiNativeVector4List velocities = obiParticlePicker.solver.velocities;
				ObiParticlePicker.ParticlePickEventArgs e4 = pickArgs;
				Vector4 vector4 = velocities.get_Item(e4.particleIndex);
				ObiNativeVector4List externalForces = obiParticlePicker.solver.externalForces;
				ObiParticlePicker.ParticlePickEventArgs e5 = pickArgs;
				Vector4 vector5 = vector2 - vector2;
				Vector4 vector6 = vector5 * springStiffness;
				Vector4 vector7 = vector2 * springDamping;
				Vector4 vector8 = vector6 - vector7;
				Vector4 value = vector8 / vector2.x;
				externalForces.set_Item(e5.particleIndex, value);
				if (drawSpring)
				{
					lineRenderer.positionCount = 2;
					Vector3 position2 = vector2;
					lineRenderer.SetPosition(0, position2);
					Vector3 position3 = vector2;
					lineRenderer.SetPosition(1, position3);
				}
				else
				{
					lineRenderer.positionCount = 0;
				}
			}
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0xC29B2C", Offset = "0xC29B2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.pickArgs = e;\n\treturn;\n")]
		private void Picker_OnParticleDragged(ObiParticlePicker.ParticlePickEventArgs e)
		{
			pickArgs = e;
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0xC29B34", Offset = "0xC29B34", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.pickArgs = 0;\n\tUnityEngine.LineRenderer::set_positionCount(this.lineRenderer, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Picker_OnParticleReleased(ObiParticlePicker.ParticlePickEventArgs e)
		{
			pickArgs = null;
			lineRenderer.positionCount = 0;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0xC29B5C", Offset = "0xC29B5C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.springStiffness = 500f;\n\tthis.drawSpring = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleDragger()
		{
			springStiffness = 500f;
			drawSpring = true;
		}
	}
}
