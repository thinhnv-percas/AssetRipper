using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744784", Offset = "0x744784")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744784", Offset = "0x744784")]
	[Token(Token = "0x200003F")]
	public class ObiParticleRenderer : MonoBehaviour
	{
		[Token(Token = "0x40000E9")]
		private static ProfilerMarker m_DrawParticlesPerfMarker;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x18")]
		public bool render;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x20")]
		public Shader shader;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x28")]
		public Color particleColor;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x38")]
		public float radiusScale;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x40")]
		private Material material;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x48")]
		private ParticleImpostorRendering impostors;

		[Token(Token = "0x17000053")]
		public IEnumerable<Mesh> ParticleMeshes
		{
			[Token(Token = "0x60002E8")]
			[Address(RVA = "0xC2A7C8", Offset = "0xC2A7C8", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Obi.ParticleImpostorRendering::get_Meshes(this.impostors);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return impostors.Meshes;
			}
		}

		[Token(Token = "0x17000054")]
		public Material ParticleMaterial
		{
			[Token(Token = "0x60002E9")]
			[Address(RVA = "0xC2A7E4", Offset = "0xC2A7E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.material;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ParticleMaterial;
			}
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0xC2A7EC", Offset = "0xC2A7EC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA5A30]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202314E]) = v40;\nL_0017:\n\tv44 = new Obi.ParticleImpostorRendering();\n\tObi.ParticleImpostorRendering::.ctor(v44);\n\tthis.impostors = v44;\n\tv51 = UnityEngine.Component::GetComponent(this);\n\tv57 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v57, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnInterpolate(v51, v57);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			ParticleImpostorRendering particleImpostorRendering = new ParticleImpostorRendering();
			impostors = particleImpostorRendering;
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorCallback value = DrawParticles;
			component.OnInterpolate += value;
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0xC2A8B4", Offset = "0xC2A8B4", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED2310]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202314F]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tv51 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v51, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnInterpolate(v45, v51);\n\tv65 = this.impostors == 0;\n\tif (v65) goto L_0038;\n\tObi.ParticleImpostorRendering::ClearMeshes(this.impostors);\nL_0038:\n\tgoto L_0046;\n\tv94 = *([v71 @ X0_v10+E0]);\n\tv95 = v94 == 0;\n\tv96 = ~v95;\n\tif (v96) goto L_0046;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v71, v67, v61, v55, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0046:\n\tUnityEngine.Object::DestroyImmediate(this.material);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorCallback value = DrawParticles;
			component.OnInterpolate -= value;
			if (impostors != null)
			{
				impostors.ClearMeshes();
			}
			UnityEngine.Object.DestroyImmediate(ParticleMaterial);
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0xC2A99C", Offset = "0xC2A99C", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EDF6C8]);\n\tv23 = *([v22 @ X8_v29]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2023150]) = v42;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0025:\n\tv60 = UnityEngine.Object::op_Inequality(this.shader, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_009C;\n\tv89 = UnityEngine.Shader::get_isSupported(this.shader);\n\tv136 = v89 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0048;\n\tgoto L_0042;\n\tv163 = *([v147 @ X0_v35+E0]);\n\tv164 = v163 == 0;\n\tv165 = ~v164;\n\tif (v165) goto L_0042;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v147, v88, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tUnityEngine.Debug::LogWarning(\"Particle rendering shader not suported.\");\nL_0048:\n\tgoto L_0051;\n\tv170 = *([v159 @ X0_v15+E0]);\n\tv171 = v170 == 0;\n\tv172 = ~v171;\n\tif (v172) goto L_0051;\n\tv174 = \"il2cpp_codegen_runtime_class_init\"(v159, v151, v59, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tv177 = UnityEngine.Object::op_Equality(this.material, 0);\n\tv179 = v177 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_0074;\n\tv194 = UnityEngine.Material::get_shader(this.material);\n\tgoto L_006B;\n\tv209 = *([v79 @ X8_v17+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_006B;\n\tv216 = v79;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v216, v193, v91, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006B:\n\tv75 = UnityEngine.Object::op_Inequality(v194, this.shader);\n\tv77 = v75 == 0;\n\tif (v77) goto L_009C;\nL_0074:\n\tgoto L_007C;\n\tv195 = *([v188 @ X0_v20+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_007C;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v188, v183, v182, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_007C:\n\tUnityEngine.Object::DestroyImmediate(this.material);\n\tv142 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v142, this.shader);\n\tthis.material = v142;\n\tUnityEngine.Object::set_hideFlags(v142, 0x3D);\n\treturn;\nL_009C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateMaterialIfNeeded()
		{
			if (!(this.shader != null))
			{
				return;
			}
			if (!this.shader.isSupported)
			{
				Debug.LogWarning("Particle rendering shader not suported.");
			}
			if (!(ParticleMaterial == null))
			{
				Shader shader = ParticleMaterial.shader;
				if (!(shader != this.shader))
				{
					return;
				}
			}
			UnityEngine.Object.DestroyImmediate(ParticleMaterial);
			(material = new Material(this.shader)).hideFlags = HideFlags.HideAndDontSave;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0xC2AB58", Offset = "0xC2AB58", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EA4090]);\n\tv25 = *([v24 @ X8_v18]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, actor, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2023151]) = v43;\nL_001C:\n\tgoto L_0027;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<Obi.ObiParticleRenderer>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0027;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v46, actor, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = Obi.ObiParticleRenderer;\nL_0027:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v57.m_DrawParticlesPerfMarker);\n\tv64 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv66 = v64 == 0;\n\tif (v66) goto L_004E;\n\tv77 = UnityEngine.Behaviour::get_isActiveAndEnabled(actor);\n\tv80 = v77 == 0;\n\tif (v80) goto L_004E;\n\tgoto L_0046;\n\tv129 = *([v125 @ X0_v26+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0046;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v125, v74, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0046:\n\tv76 = UnityEngine.Object::op_Equality(actor.m_Solver, 0);\n\tv79 = v76 == 0;\n\tif (v79) goto L_005B;\nL_004E:\n\tObi.ParticleImpostorRendering::ClearMeshes(this.impostors);\nL_0058:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v57.m_DrawParticlesPerfMarker);\n\treturn;\nL_005B:\n\tObi.ObiParticleRenderer::CreateMaterialIfNeeded(this);\n\tv103 = this.impostors == 0;\n\tif (v103) goto L_0068;\n\tObi.ParticleImpostorRendering::UpdateMeshes(this.impostors, actor);\n\tObi.ObiParticleRenderer::DrawParticles(this);\n\tgoto L_0058;\n\tthrow System.NullReferenceException;\n\tv94 = new System.NullReferenceException();\nL_0068:\n\tv105 = new System.NullReferenceException();\n\tgoto L_0076;\n\tgoto L_0076;\n\tgoto L_0076;\n\tgoto L_0076;\nL_0076:\n\tv145 = v99 != 1;\n\tif (v145) goto L_0089;\n\tv190 = 0x6D2BC0(v105, v99, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv194 = 0x6D2490(v190, v99, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v57.m_DrawParticlesPerfMarker);\n\tv198 = *([v190 @ X0_v13]) == 0;\n\tv177 = ~v198;\n\tif (v177) goto L_008D;\n\treturn;\nL_0089:\n\tv191 = 0x6D2380(v105, v99, v97, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008D:\n\tthrow System.TypeLoadException;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DrawParticles(ObiActor actor)
		{
			//IL_0170: Expected I, but got O
			//IL_007e: Expected I, but got O
			//IL_011e: Expected I, but got O
			ProfilerMarker.Internal_Begin((IntPtr)m_DrawParticlesPerfMarker);
			if (!base.isActiveAndEnabled || !actor.isActiveAndEnabled || actor.solver == null)
			{
				impostors.ClearMeshes();
			}
			else
			{
				CreateMaterialIfNeeded();
				if (impostors == null)
				{
					NullReferenceException ex = new NullReferenceException();
					UnityEngine.Object obj = default(UnityEngine.Object);
					if ((IntPtr)obj == (IntPtr)1)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
						ProfilerMarker.Internal_End((IntPtr)m_DrawParticlesPerfMarker);
						object obj2 = default(object);
						if (obj2 == null)
						{
							return;
						}
					}
					else
					{
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
					}
					throw new TypeLoadException();
				}
				impostors.UpdateMeshes(actor);
				DrawParticles();
			}
			ProfilerMarker.Internal_End((IntPtr)m_DrawParticlesPerfMarker);
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0xC2ACE0", Offset = "0xC2ACE0", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv32 = *([1EAAA78]);\n\tv33 = *([v32 @ X8_v43]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2023152]) = v52;\nL_0021:\n\tgoto L_002A;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002A;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_002A:\n\tv70 = UnityEngine.Object::op_Inequality(this.material, 0);\n\tv72 = v70 == 0;\n\tif (v72) goto L_0189;\n\tUnityEngine.Material::SetFloat(this.material, \"_RadiusScale\", this.radiusScale);\n\tv409 = this.particleColor;\n\tv406 = this.particleColor.g;\n\tv403 = this.particleColor.b;\n\tv400 = this.particleColor.a;\n\t// 66 MakeStruct v198 @ AGGC2ADA0_2_v8 (UnityEngine.Color), typeof(UnityEngine.Color), this.particleColor (UnityEngine.Color), this.particleColor.g (System.Single), this.particleColor.b (System.Single), this.particleColor.a (System.Single)\n\tUnityEngine.Material::SetColor(this.material, \"_Color\", v198);\n\tv222 = ~this.render;\n\tif (v222) goto L_0189;\n\tv257 = Obi.ParticleImpostorRendering::get_Meshes(this.impostors);\n\tgoto L_007C;\n\tv642 = *([v635 @ X8_v20+B0]);\n\tv643 = 0;\n\tv644 = v642 + 8;\n\tv646 = *([v729 @ X11_v24-8]);\n\tv735 = v646 == v638;\n\tif (v735) goto L_0075;\n\tv668 = v730 + 1;\n\tv741 = v668 < v637;\n\tv664 = ~v741;\n\tv666 = v729 + 0x10;\n\tv648 = ~v664;\n\tif (v648) goto L_FFFFFFFF;\n\tv669 = v264;\n\tv670 = 0;\n\tv671 = 0x8909C4(v669, v638, v670, v37, v38, v39, v40, v41, v210, v207, v204, v201, v46, v47, v48, v49);\n\tgoto L_007C;\nL_0075:\n\tv742 = *([v729 @ X11_v24]);\n\tv743 = v742 << 4;\n\tv744 = v635 + v743;\n\tv745 = v744 + 0x130;\nL_007C:\n\tv610 = System.Collections.Generic.IEnumerable`1<UnityEngine.Mesh>::GetEnumerator(v257);\n\tv612 = v610 == 0;\n\tif (v612) goto L_012B;\nL_008C:\n\tgoto L_00B3;\n\tv794 = *([v790 @ X8_v24+B0]);\n\tv795 = 0;\n\tv796 = v794 + 8;\n\tv798 = *([v834 @ X11_v19-8]);\n\tv840 = v798 == v791;\n\tif (v840) goto L_00AC;\n\tv820 = v835 + 1;\n\tv845 = v820 < v792;\n\tv816 = ~v845;\n\tv818 = v834 + 0x10;\n\tv800 = ~v816;\n\tif (v800) goto L_FFFFFFFF;\n\tv821 = v539;\n\tv822 = 0;\n\tv823 = 0x8909C4(v821, v791, v822, v440, v438, v39, v40, v41, v527, v525, v523, v521, v46, v47, v48, v49);\n\tgoto L_00B3;\nL_00AC:\n\tv846 = *([v834 @ X11_v19]);\n\tv847 = v846 << 4;\n\tv848 = v790 + v847;\n\tv849 = v848 + 0x130;\nL_00B3:\n\tv707 = System.Collections.IEnumerator::MoveNext(v610);\n\tv854 = v707 == 0;\n\tif (v854) goto L_0125;\n\tgoto L_00E2;\n\tv860 = *([v855 @ X8_v27+B0]);\n\tv861 = 0;\n\tv862 = v860 + 8;\n\tv864 = *([v900 @ X11_v14-8]);\n\tv906 = v864 == v856;\n\tif (v906) goto L_00DB;\n\tv886 = v901 + 1;\n\tv911 = v886 < v857;\n\tv882 = ~v911;\n\tv884 = v900 + 0x10;\n\tv866 = ~v882;\n\tif (v866) goto L_FFFFFFFF;\n\tv887 = v539;\n\tv888 = 0;\n\tv889 = 0x8909C4(v887, v856, v888, v440, v438, v39, v40, v41, v527, v525, v523, v521, v46, v47, v48, v49);\n\tgoto L_00E2;\nL_00DB:\n\tv912 = *([v900 @ X11_v14]);\n\tv913 = v912 << 4;\n\tv914 = v855 + v913;\n\tv915 = v914 + 0x130;\nL_00E2:\n\tv921 = System.Collections.Generic.IEnumerator`1<UnityEngine.Mesh>::get_Current(v610);\n\tgoto L_00F0;\n\tv926 = *([v922 @ X0_v36+E0]);\n\tv927 = v926 == 0;\n\tv928 = ~v927;\n\tgoto L_00F0;\n\tv930 = \"il2cpp_codegen_runtime_class_init\"(v922, v919, v529, v440, v438, v39, v40, v41, v527, v525, v523, v521, v46, v47, v48, v49);\nL_00F0:\n\tv934 = UnityEngine.Matrix4x4::get_identity();\n\tv484 = v934.m00;\n\tv533 = UnityEngine.Component::get_gameObject(this);\n\tv937 = UnityEngine.GameObject::get_layer(v533);\n\tgoto L_0121;\n\tv942 = *([v938 @ X0_v43+E0]);\n\tv943 = v942 == 0;\n\tv944 = ~v943;\n\tif (v944) goto L_0121;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v938, v936, v529, v440, v438, v39, v40, v41, v527, v525, v523, v521, v46, v47, v48, v49);\nL_0121:\n\tUnityEngine.Graphics::DrawMesh(v921, &v484 @ stack_-A0_v8 (System.Single), this.material, v937);\n\tgoto L_008C;\nL_0125:\n\tv859 = v610 == 0;\n\tv709 = ~v859;\n\tif (v709) goto L_0146;\n\tgoto L_0173;\n\tv265 = new System.NullReferenceException();\n\tv540 = new System.NullReferenceException();\nL_012B:\n\tv616 = new System.NullReferenceException();\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\n\tgoto L_013C;\nL_013C:\n\tv626 = v415 != 1;\n\tif (v626) goto L_018E;\n\tv627 = 0x6D2BC0(v616, v415, v412, v83, v81, v39, v40, v41, v209, v206, v203, v200, v46, v47, v48, v49);\n\tv225 = *([v627 @ X0_v17]);\n\tv707 = 0x6D2490(v627, v415, v412, v83, v81, v39, v40, v41, v209, v206, v203, v200, v46, v47, v48, v49);\n\tv641 = v615 == 0;\n\tif (v641) goto L_0173;\nL_0146:\n\tv418 = 0xC3FC30(v707, v415, v412, v277, v274, v39, v40, v41, v409, v406, v403, v400, v46, v47, v48, v49);\n\treturn;\n\tX9 = *([X8+126]);\n\tX1 = *([1EAE000]);\n\tif (TEMP) goto L_0167;\n\tX11 = *([X8+B0]);\n\tX10 = 0;\n\tX11 = X11 + 8;\nL_014F:\n\tX12 = *([X11-8]);\n\tC = X12 < X1;\n\tC = ~C;\n\tTEMP1 = X12 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X12 ^ X1;\n\tTEMP3 = X12 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_016B;\n\tX10 = X10 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX11 = X11 + 0x10;\n\tTEMPCOND = ~C;\n\tif (TEMPCOND) goto L_014F;\nL_0167:\n\tX0 = X19;\n\tX2 = 0;\n\tX0 = 0x8909C4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_016F;\nL_016B:\n\tX9 = *([X11]);\n\tTEMPSHIFT = X9 << 4;\n\tX8 = X8 + TEMPSHIFT;\n\tX0 = X8 + 0x130;\nL_016F:\n\tX8 = *([X0]);\n\tX1 = *([X0+8]);\n\tX0 = X19;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0173:\n\tv223 = v79 + 1;\n\tv175 = v223 == 0;\n\tv160 = ~v175;\n\tif (v160) goto L_0189;\n\tv740 = v225 == 0;\n\tv221 = ~v740;\n\tif (v221) goto L_018D;\nL_0189:\n\treturn;\nL_018D:\n\tv631 = new System.TypeLoadException();\nL_018E:\n\tv419 = 0x6D2380(v616, v415, v412, v277, v274, v39, v40, v41, v409, v406, v403, v400, v46, v47, v48, v49);\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DrawParticles()
		{
			//IL_024a: Expected I4, but got O
			//IL_016f: Expected O, but got Ref
			//IL_0178: Expected O, but got I4
			//IL_01af: Expected O, but got F4
			if (!(ParticleMaterial != null))
			{
				return;
			}
			ParticleMaterial.SetFloat("_RadiusScale", radiusScale);
			Color color = particleColor;
			float g = particleColor.g;
			float b = particleColor.b;
			float a = particleColor.a;
			Color value = default(Color);
			value.r = particleColor.r;
			value.g = particleColor.g;
			value.b = particleColor.b;
			value.a = particleColor.a;
			ParticleMaterial.SetColor("_Color", value);
			if (!render)
			{
				return;
			}
			IEnumerable<Mesh> meshes = impostors.Meshes;
			IEnumerator<Mesh> enumerator = meshes.GetEnumerator();
			int num2;
			int num8;
			int num9;
			int num = default(int);
			NullReferenceException ex;
			if (enumerator == null)
			{
				ex = new NullReferenceException();
				if (num != 1)
				{
					goto IL_0315;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num2 = (int)obj;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IEnumerator<Mesh> enumerator2 = default(IEnumerator<Mesh>);
				bool flag = enumerator2 == null;
				object obj3 = default(object);
				object obj2 = obj3;
				int num4 = default(int);
				int num3 = num4;
				float num5 = default(float);
				a = num5;
				float num6 = default(float);
				b = num6;
				float num7 = default(float);
				g = num7;
				Color color2 = default(Color);
				color = color2;
				num8 = -1;
				if (!flag)
				{
					goto IL_02b4;
				}
			}
			else
			{
				while (enumerator.MoveNext())
				{
					Mesh current = enumerator.Current;
					Matrix4x4 identity = Matrix4x4.identity;
					float m = identity.m00;
					GameObject gameObject = base.gameObject;
					int layer = gameObject.layer;
					Graphics.DrawMesh(current, (Matrix4x4)(&m), ParticleMaterial, layer);
					object obj2 = 0;
					int num3 = layer;
					a = m;
					b = identity.m01;
					g = identity.m02;
					color = (Color)identity.m03;
				}
				bool flag2 = enumerator == null;
				bool flag3 = !flag2;
				num9 = 0;
				num = 0;
				if (flag3)
				{
					goto IL_02b4;
				}
				num8 = 0;
				num2 = 0;
			}
			if (num8 + 1 != 0 || num2 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num9 = 0;
			num = 0;
			ex = (NullReferenceException)(object)ex2;
			goto IL_0315;
			IL_02b4:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C3FC30 (inside Obi.ObiRopeMeshRenderer::.cctor +0x7C)");
			return;
			IL_0315:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0xC2B0A0", Offset = "0xC2B0A0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.render = 1;\n\tv12 = UnityEngine.Color::get_white();\n\tthis.particleColor = v12;\n\tthis.particleColor.g = v12.g;\n\tthis.particleColor.b = v12.b;\n\tthis.particleColor.a = v12.a;\n\tthis.radiusScale = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticleRenderer()
		{
			render = true;
			Color color = (particleColor = Color.white);
			particleColor.g = color.g;
			particleColor.b = color.b;
			particleColor.a = color.a;
			radiusScale = 1f;
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0xC2B0E4", Offset = "0xC2B0E4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EADFE0]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2023153]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"DrawParticles\", 0);\n\tv45.m_DrawParticlesPerfMarker = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiParticleRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("DrawParticles", default(Unity.Profiling.MarkerFlags));
			m_DrawParticlesPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
