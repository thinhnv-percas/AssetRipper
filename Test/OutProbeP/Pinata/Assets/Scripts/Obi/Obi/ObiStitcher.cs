using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[Token(Token = "0x200005A")]
	public class ObiStitcher : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x20000BF")]
		public class Stitch
		{
			[Token(Token = "0x4000311")]
			[FieldOffset(Offset = "0x10")]
			public int particleIndex1;

			[Token(Token = "0x4000312")]
			[FieldOffset(Offset = "0x14")]
			public int particleIndex2;

			[Token(Token = "0x6000577")]
			[Address(RVA = "0x102EE18", Offset = "0x102EE18", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.particleIndex1 = particleIndex1;\n\tthis.particleIndex2 = particleIndex2;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public Stitch(int particleIndex1, int particleIndex2)
			{
				this.particleIndex1 = particleIndex1;
				this.particleIndex2 = particleIndex2;
			}
		}

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x18")]
		private List<Stitch> stitches;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x20")]
		private ObiActor actor1;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x28")]
		private ObiActor actor2;

		[HideInInspector]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x30")]
		public ObiNativeIntList particleIndices;

		[HideInInspector]
		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x38")]
		public ObiNativeFloatList stiffnesses;

		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0x40")]
		private IntPtr batch;

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x48")]
		private bool inSolver;

		[Token(Token = "0x17000092")]
		public ObiActor Actor1
		{
			[Token(Token = "0x60003C3")]
			[Address(RVA = "0x102E700", Offset = "0x102E700", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.actor1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Actor1;
			}
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x102E2E8", Offset = "0x102E2E8", Length = "0x2B4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EDCFC8]);\n\tv29 = *([v28 @ X8_v34]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202625C]) = v47;\nL_001F:\n\tgoto L_0028;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0028:\n\tv65 = UnityEngine.Object::op_Inequality(this.actor1, value);\n\tv67 = v65 == 0;\n\tif (v67) goto L_00E3;\n\tgoto L_003A;\n\tv113 = *([v68 @ X0_v7+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003A;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v68, v63, v64, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003A:\n\tv123 = UnityEngine.Object::op_Inequality(this.actor1, 0);\n\tv164 = v123 == 0;\n\tif (v164) goto L_007E;\n\tv169 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v169, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintLoaded(this.actor1, v169);\n\tv229 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v229, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintUnloaded(this.actor1, v229);\n\tv245 = this.actor1;\n\tgoto L_0071;\n\tv269 = *([v266 @ X0_v41+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0071;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v266, v224, v218, v173, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0071:\n\tv181 = UnityEngine.Object::op_Inequality(v245.m_Solver, 0);\n\tv184 = v181 == 0;\n\tif (v184) goto L_007E;\n\tv257 = this.actor1;\n\tv186 = *([v257 @ X0_v45 (Obi.ObiActor)]);\n\tv280 = Obi.ObiActor::get_blueprint(v257);\n\tObi.ObiStitcher::RemoveFromSolver(this, *([v186 @ X8_v28 (Il2CppClass<Obi.ObiActor>)+228]));\nL_007E:\n\tthis.actor1 = value;\n\tgoto L_008C;\n\tv199 = *([v189 @ X0_v16+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_008C;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v189, v176, v174, v81, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_008C:\n\tv92 = UnityEngine.Object::op_Inequality(value, 0);\n\tv95 = v92 == 0;\n\tif (v95) goto L_00E3;\n\tv231 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v231, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(this.actor1, v231);\n\tv232 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v232, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintUnloaded(this.actor1, v232);\n\tv248 = this.actor1;\n\tgoto L_00C3;\n\tv281 = *([v277 @ X0_v26+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_00C3;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v277, v227, v221, v82, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00C3:\n\tv93 = UnityEngine.Object::op_Inequality(v248.m_Solver, 0);\n\tv96 = v93 == 0;\n\tif (v96) goto L_00E3;\n\tv258 = this.actor1;\n\tv156 = *([v258 @ X0_v30 (Obi.ObiActor)]);\n\tv289 = Obi.ObiActor::get_blueprint(v258);\n\tObi.ObiStitcher::Actor_OnBlueprintLoaded(this, *([v156 @ X8_v19 (Il2CppClass<Obi.ObiActor>)+228]), 0);\n\treturn;\nL_00E3:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0111: Expected I, but got O
				//IL_0130: Expected O, but got I
				//IL_0219: Expected I, but got O
				//IL_0239: Expected O, but got I
				if (!(Actor1 != value))
				{
					return;
				}
				if (Actor1 != null)
				{
					ObiActor.ActorBlueprintCallback value2 = Actor_OnBlueprintLoaded;
					Actor1.OnBlueprintLoaded -= value2;
					ObiActor.ActorBlueprintCallback value3 = Actor_OnBlueprintUnloaded;
					Actor1.OnBlueprintUnloaded -= value3;
					ObiActor obiActor = Actor1;
					if (obiActor.solver != null)
					{
						ObiActor obiActor2 = Actor1;
						IntPtr intPtr = (IntPtr)obiActor2;
						ObiActorBlueprint blueprint = obiActor2.blueprint;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v28 (Il2CppClass<Obi.ObiActor>)+228]");
						RemoveFromSolver(0);
					}
				}
				actor1 = value;
				if (value != null)
				{
					ObiActor.ActorBlueprintCallback value4 = Actor_OnBlueprintLoaded;
					Actor1.OnBlueprintLoaded += value4;
					ObiActor.ActorBlueprintCallback value5 = Actor_OnBlueprintUnloaded;
					Actor1.OnBlueprintUnloaded += value5;
					ObiActor obiActor3 = Actor1;
					if (obiActor3.solver != null)
					{
						ObiActor obiActor4 = Actor1;
						IntPtr intPtr2 = (IntPtr)obiActor4;
						ObiActorBlueprint blueprint2 = obiActor4.blueprint;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v19 (Il2CppClass<Obi.ObiActor>)+228]");
						Actor_OnBlueprintLoaded((ObiActor)0, null);
					}
				}
			}
		}

		[Token(Token = "0x17000093")]
		public ObiActor Actor2
		{
			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x102E9BC", Offset = "0x102E9BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.actor2;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Actor2;
			}
			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x102E708", Offset = "0x102E708", Length = "0x2B4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1F0C860]);\n\tv29 = *([v28 @ X8_v34]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202625D]) = v47;\nL_001F:\n\tgoto L_0028;\n\tv55 = *([v51 @ X0_v2+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_0028;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v51, value, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0028:\n\tv65 = UnityEngine.Object::op_Inequality(this.actor2, value);\n\tv67 = v65 == 0;\n\tif (v67) goto L_00E3;\n\tgoto L_003A;\n\tv113 = *([v68 @ X0_v7+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_003A;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v68, v63, v64, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_003A:\n\tv123 = UnityEngine.Object::op_Inequality(this.actor2, 0);\n\tv164 = v123 == 0;\n\tif (v164) goto L_007E;\n\tv169 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v169, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintLoaded(this.actor2, v169);\n\tv229 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v229, this, Il2CppMethodInfo);\n\tObi.ObiActor::remove_OnBlueprintUnloaded(this.actor2, v229);\n\tv245 = this.actor2;\n\tgoto L_0071;\n\tv269 = *([v266 @ X0_v41+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0071;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v266, v224, v218, v173, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0071:\n\tv181 = UnityEngine.Object::op_Inequality(v245.m_Solver, 0);\n\tv184 = v181 == 0;\n\tif (v184) goto L_007E;\n\tv257 = this.actor2;\n\tv186 = *([v257 @ X0_v45 (Obi.ObiActor)]);\n\tv280 = Obi.ObiActor::get_blueprint(v257);\n\tObi.ObiStitcher::RemoveFromSolver(this, *([v186 @ X8_v28 (Il2CppClass<Obi.ObiActor>)+228]));\nL_007E:\n\tthis.actor2 = value;\n\tgoto L_008C;\n\tv199 = *([v189 @ X0_v16+E0]);\n\tv200 = v199 == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_008C;\n\tv203 = \"il2cpp_codegen_runtime_class_init\"(v189, v176, v174, v81, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_008C:\n\tv92 = UnityEngine.Object::op_Inequality(value, 0);\n\tv95 = v92 == 0;\n\tif (v95) goto L_00E3;\n\tv231 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v231, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(this.actor2, v231);\n\tv232 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v232, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintUnloaded(this.actor2, v232);\n\tv248 = this.actor2;\n\tgoto L_00C3;\n\tv281 = *([v277 @ X0_v26+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_00C3;\n\tv285 = \"il2cpp_codegen_runtime_class_init\"(v277, v227, v221, v82, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00C3:\n\tv93 = UnityEngine.Object::op_Inequality(v248.m_Solver, 0);\n\tv96 = v93 == 0;\n\tif (v96) goto L_00E3;\n\tv258 = this.actor2;\n\tv156 = *([v258 @ X0_v30 (Obi.ObiActor)]);\n\tv289 = Obi.ObiActor::get_blueprint(v258);\n\tObi.ObiStitcher::Actor_OnBlueprintLoaded(this, *([v156 @ X8_v19 (Il2CppClass<Obi.ObiActor>)+228]), 0);\n\treturn;\nL_00E3:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 153 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0111: Expected I, but got O
				//IL_0130: Expected O, but got I
				//IL_0219: Expected I, but got O
				//IL_0239: Expected O, but got I
				if (!(Actor2 != value))
				{
					return;
				}
				if (Actor2 != null)
				{
					ObiActor.ActorBlueprintCallback value2 = Actor_OnBlueprintLoaded;
					Actor2.OnBlueprintLoaded -= value2;
					ObiActor.ActorBlueprintCallback value3 = Actor_OnBlueprintUnloaded;
					Actor2.OnBlueprintUnloaded -= value3;
					ObiActor obiActor = Actor2;
					if (obiActor.solver != null)
					{
						ObiActor obiActor2 = Actor2;
						IntPtr intPtr = (IntPtr)obiActor2;
						ObiActorBlueprint blueprint = obiActor2.blueprint;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v28 (Il2CppClass<Obi.ObiActor>)+228]");
						RemoveFromSolver(0);
					}
				}
				actor2 = value;
				if (value != null)
				{
					ObiActor.ActorBlueprintCallback value4 = Actor_OnBlueprintLoaded;
					Actor2.OnBlueprintLoaded += value4;
					ObiActor.ActorBlueprintCallback value5 = Actor_OnBlueprintUnloaded;
					Actor2.OnBlueprintUnloaded += value5;
					ObiActor obiActor3 = Actor2;
					if (obiActor3.solver != null)
					{
						ObiActor obiActor4 = Actor2;
						IntPtr intPtr2 = (IntPtr)obiActor4;
						ObiActorBlueprint blueprint2 = obiActor4.blueprint;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X8_v19 (Il2CppClass<Obi.ObiActor>)+228]");
						Actor_OnBlueprintLoaded((ObiActor)0, null);
					}
				}
			}
		}

		[Token(Token = "0x17000094")]
		public int StitchCount
		{
			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x102E9C4", Offset = "0x102E9C4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC9B28]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202625E]) = v38;\nL_0013:\n\tv39 = this.stitches;\n\treturn v39._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<Stitch> list = stitches;
				return list.Count;
			}
		}

		[Token(Token = "0x17000095")]
		public IEnumerable<Stitch> Stitches
		{
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x102EA18", Offset = "0x102EA18", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EB7B78]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202625F]) = v38;\nL_001E:\n\treturnVal1 = System.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>::AsReadOnly(this.stitches);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return stitches.AsReadOnly();
			}
		}

		[Token(Token = "0x60003C8")]
		[Address(RVA = "0x102EA70", Offset = "0x102EA70", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EAE158]);\n\tv25 = *([v24 @ X8_v29]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026260]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Inequality(this.actor1, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0051;\n\tv69 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v69, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(this.actor1, v69);\n\tv132 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v132, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintUnloaded(this.actor1, v132);\nL_0051:\n\tgoto L_005A;\n\tv98 = *([v87 @ X0_v10+E0]);\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_005A;\n\tv102 = \"il2cpp_codegen_runtime_class_init\"(v87, v77, v75, v72, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005A:\n\tv108 = UnityEngine.Object::op_Inequality(this.actor2, 0);\n\tv111 = v108 == 0;\n\tif (v111) goto L_0085;\n\tv133 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v133, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintLoaded(this.actor2, v133);\n\tv134 = new Obi.ObiActor+ActorBlueprintCallback();\n\tObi.ObiActor+ActorBlueprintCallback::.ctor(v134, this, Il2CppMethodInfo);\n\tObi.ObiActor::add_OnBlueprintUnloaded(this.actor2, v134);\nL_0085:\n\tgoto L_008E;\n\tv167 = *([v160 @ X0_v15+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_008E;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v160, v153, v151, v149, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_008E:\n\tv177 = UnityEngine.Object::op_Inequality(this.actor1, 0);\n\tv217 = v177 == 0;\n\tif (v217) goto L_00B8;\n\tgoto L_00A0;\n\tv230 = *([v221 @ X0_v20+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_00A0;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v221, v175, v176, v149, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A0:\n\tv227 = UnityEngine.Object::op_Inequality(this.actor2, 0);\n\tv202 = v227 == 0;\n\tif (v202) goto L_00B8;\n\tv199 = Oni::EnableBatch(this.batch, 1);\n\treturn;\nL_00B8:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			if (Actor1 != null)
			{
				ObiActor.ActorBlueprintCallback value = Actor_OnBlueprintLoaded;
				Actor1.OnBlueprintLoaded += value;
				ObiActor.ActorBlueprintCallback value2 = Actor_OnBlueprintUnloaded;
				Actor1.OnBlueprintUnloaded += value2;
			}
			if (Actor2 != null)
			{
				ObiActor.ActorBlueprintCallback value3 = Actor_OnBlueprintLoaded;
				Actor2.OnBlueprintLoaded += value3;
				ObiActor.ActorBlueprintCallback value4 = Actor_OnBlueprintUnloaded;
				Actor2.OnBlueprintUnloaded += value4;
			}
			if (Actor1 != null && Actor2 != null)
			{
				bool flag = Oni.EnableBatch(batch, enabled: true);
			}
		}

		[Token(Token = "0x60003C9")]
		[Address(RVA = "0x102ED5C", Offset = "0x102ED5C", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = Oni::EnableBatch(this.batch, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDisable()
		{
			bool flag = Oni.EnableBatch(batch, enabled: false);
		}

		[Token(Token = "0x60003CA")]
		[Address(RVA = "0x102ED68", Offset = "0x102ED68", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1ED3B98]);\n\tv29 = *([v28 @ X8_v12]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, particle1, particle2, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2026261]) = v46;\nL_001C:\n\tv51 = new Obi.ObiStitcher+Stitch();\n\tSystem.Object::.ctor(v51);\n\tv51.particleIndex1 = particle1;\n\tv51.particleIndex2 = particle2;\n\tSystem.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>::Add(this.stitches, v51);\n\tv66 = this.stitches;\n\treturnVal2 = v66._size - 1;\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int AddStitch(int particle1, int particle2)
		{
			Stitch item = new Stitch(particle1, particle2);
			stitches.Add(item);
			List<Stitch> list = stitches;
			return list.Count - 1;
		}

		[Token(Token = "0x60003CB")]
		[Address(RVA = "0x102EE50", Offset = "0x102EE50", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECE0F8]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, index, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026262]) = v41;\nL_0015:\n\tv42 = index & 0x80000000;\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_003C;\n\tv45 = this.stitches;\n\tv48 = v45._size <= index;\n\tif (v48) goto L_003C;\n\tSystem.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>::RemoveAt(v45, index);\n\treturn;\nL_003C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveStitch(int index)
		{
			//IL_0059: Expected I4, but got I8
			if ((int)(index & 0x80000000L) == 0)
			{
				List<Stitch> list = stitches;
				if (list.Count > index)
				{
					list.RemoveAt(index);
				}
			}
		}

		[Token(Token = "0x60003CC")]
		[Address(RVA = "0x102EED8", Offset = "0x102EED8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEEE28]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026263]) = v38;\nL_0019:\n\tSystem.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>::Clear(this.stitches);\n\tObi.ObiStitcher::PushDataToSolver(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			stitches.Clear();
			PushDataToSolver();
		}

		[Token(Token = "0x60003CD")]
		[Address(RVA = "0x102E59C", Offset = "0x102E59C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiStitcher::RemoveFromSolver(this, actor);\n\treturn;\n")]
		private void Actor_OnBlueprintUnloaded(ObiActor actor, ObiActorBlueprint blueprint)
		{
			RemoveFromSolver(actor);
		}

		[Token(Token = "0x60003CE")]
		[Address(RVA = "0x102E5A0", Offset = "0x102E5A0", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EFCB38]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, actor, blueprint, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026264]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, actor, blueprint, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.actor1, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0077;\n\tgoto L_0036;\n\tv92 = *([v61 @ X0_v7+E0]);\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0036;\n\tv96 = \"il2cpp_codegen_runtime_class_init\"(v61, v56, v57, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0036:\n\tv78 = UnityEngine.Object::op_Inequality(this.actor2, 0);\n\tv80 = v78 == 0;\n\tif (v80) goto L_0077;\n\tv85 = this.actor1;\n\tv81 = ~v85.m_Loaded;\n\tif (v81) goto L_0077;\n\tv72 = this.actor2;\n\tv82 = ~v72.m_Loaded;\n\tif (v82) goto L_0077;\n\tgoto L_0055;\n\tv143 = *([v137 @ X0_v13+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0055;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v137, v76, v74, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0055:\n\tv150 = UnityEngine.Object::op_Inequality(v85.m_Solver, v72.m_Solver);\n\tv119 = v150 == 0;\n\tif (v119) goto L_007F;\n\tgoto L_006F;\n\tv158 = *([v154 @ X0_v18+E0]);\n\tv159 = v158 == 0;\n\tv160 = ~v159;\n\tif (v160) goto L_006F;\n\tv162 = \"il2cpp_codegen_runtime_class_init\"(v154, v112, v109, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_006F:\n\tUnityEngine.Debug::LogError(\"ObiStitcher cannot handle actors in different solvers.\");\n\treturn;\nL_0077:\n\treturn;\nL_007F:\n\tObi.ObiStitcher::AddToSolver(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Actor_OnBlueprintLoaded(ObiActor actor, ObiActorBlueprint blueprint)
		{
			if (!(Actor1 != null) || !(Actor2 != null))
			{
				return;
			}
			ObiActor obiActor = Actor1;
			if (!obiActor.isLoaded)
			{
				return;
			}
			ObiActor obiActor2 = Actor2;
			if (obiActor2.isLoaded)
			{
				if (obiActor.solver != obiActor2.solver)
				{
					Debug.LogError("ObiStitcher cannot handle actors in different solvers.");
				}
				else
				{
					AddToSolver();
				}
			}
		}

		[Token(Token = "0x60003CF")]
		[Address(RVA = "0x102F1D4", Offset = "0x102F1D4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = Oni::CreateBatch(0xE);\n\tv13 = this.actor1;\n\tthis.batch = v11;\n\tv16 = v13.m_Solver;\n\tv38 = Oni::AddBatch(v16.oniSolver, v11);\n\tthis.inSolver = 1;\n\tObi.ObiStitcher::PushDataToSolver(this);\n\tv61 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv48 = v61 == 0;\n\tif (v48) goto L_002A;\n\tObi.ObiStitcher::OnEnable(this);\n\treturn;\nL_002A:\n\tv53 = Oni::EnableBatch(this.batch, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddToSolver()
		{
			IntPtr intPtr = Oni.CreateBatch(14);
			ObiActor obiActor = Actor1;
			batch = intPtr;
			ObiSolver solver = obiActor.solver;
			IntPtr intPtr2 = Oni.AddBatch(solver.OniSolver, intPtr);
			inSolver = true;
			PushDataToSolver();
			if (base.isActiveAndEnabled)
			{
				OnEnable();
			}
			else
			{
				bool flag = Oni.EnableBatch(batch, enabled: false);
			}
		}

		[Token(Token = "0x60003D0")]
		[Address(RVA = "0x102F168", Offset = "0x102F168", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDE710]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, info, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026265]) = v38;\nL_0013:\n\tv39 = this.actor1;\n\tv41 = v39.m_Solver;\n\tOni::RemoveBatch(v41.oniSolver, this.batch);\n\tthis.batch = 0;\n\tthis.inSolver = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RemoveFromSolver(object info)
		{
			ObiActor obiActor = Actor1;
			ObiSolver solver = obiActor.solver;
			Oni.RemoveBatch(solver.OniSolver, batch);
			batch = (IntPtr)0;
			inSolver = false;
		}

		[Token(Token = "0x60003D1")]
		[Address(RVA = "0x102EF38", Offset = "0x102EF38", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1F06A58]);\n\tv29 = *([v28 @ X8_v32]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026266]) = v48;\nL_0019:\n\tv50 = ~this.inSolver;\n\tif (v50) goto L_00E1;\n\tv51 = this.stitches;\n\tv166 = v51._size << 1;\n\tObi.ObiNativeList`1<System.Int32>::ResizeUninitialized(this.particleIndices, v166);\n\tv207 = this.stitches;\n\tObi.ObiNativeList`1<System.Single>::ResizeUninitialized(this.stiffnesses, v207._size);\n\tv155 = this.stitches;\nL_0041:\n\tv83 = v219 >= v155._size;\n\tif (v83) goto L_00BC;\n\tv209 = this.actor1;\n\tv144 = v209.solverIndices;\n\tv338 = v155._size < v219;\n\tv138 = ~v338;\n\tv131 = v155._size - v219;\n\tv117 = v131 == 0;\n\tv339 = ~v117;\n\tv84 = v138 & v339;\n\tif (v84) goto L_0056;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0056:\n\tv341 = v155._items;\n\tv210 = v341[v219 @ X20_v7 (System.Int32)];\n\tv211 = v210.particleIndex1;\n\tv343 = v210.particleIndex1 < v144.Length;\n\tv139 = ~v343;\n\tif (v139) goto L_00E4;\n\tv169 = v151 - 1;\n\tv186 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v169, v144[v211 @ X8_v19 (System.Int32)]);\n\tv212 = this.actor2;\n\tv145 = this.stitches;\n\tv156 = v212.solverIndices;\n\tv347 = v145._size < v219;\n\tv140 = ~v347;\n\tv133 = v145._size - v219;\n\tv119 = v133 == 0;\n\tv348 = ~v119;\n\tv85 = v140 & v348;\n\tif (v85) goto L_008D;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008D:\n\tv350 = v145._items;\n\tv213 = v350[v219 @ X20_v7 (System.Int32)];\n\tv214 = v213.particleIndex2;\n\tv352 = v213.particleIndex2 < v156.Length;\n\tv141 = ~v352;\n\tif (v141) goto L_00E4;\n\tv355 = Obi.ObiNativeIntList::set_Item(this.particleIndices, v151, v156[v214 @ X8_v26 (System.Int32)]);\n\tv188 = Obi.ObiNativeFloatList::set_Item(this.stiffnesses, v219, 0f);\n\tv155 = this.stitches;\n\tv219 = v219 + 1;\n\tv151 = v151 + 2;\n\tv356 = this.stitches == 0;\n\tv202 = ~v356;\n\tif (v202) goto L_0041;\n\tgoto L_00E3;\nL_00BC:\n\tv216 = this.particleIndices;\n\tv181 = this.stiffnesses;\n\tOni::SetStitchConstraints(this.batch, v216.m_AlignedPtr, v181.m_AlignedPtr, v155._size);\n\tv217 = this.stitches;\n\tOni::SetActiveConstraints(this.batch, v217._size);\n\treturn;\nL_00E1:\n\treturn;\nL_00E3:\n\tv317 = new System.NullReferenceException();\nL_00E4:\n\tv321 = new System.IndexOutOfRangeException();\n\tthrow v321;\n\treturn;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PushDataToSolver()
		{
			if (!inSolver)
			{
				return;
			}
			List<Stitch> list = stitches;
			int newCount = list.Count << 1;
			particleIndices.ResizeUninitialized(newCount);
			List<Stitch> list2 = stitches;
			stiffnesses.ResizeUninitialized(list2.Count);
			List<Stitch> list3 = stitches;
			int num = 1;
			int num2 = 0;
			while (true)
			{
				if (num2 < list3.Count)
				{
					ObiActor obiActor = Actor1;
					int[] solverIndices = obiActor.solverIndices;
					bool flag = list3.Count < num2;
					bool flag2 = !flag;
					int num3 = list3.Count - num2;
					bool flag3 = num3 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					Stitch[] items = list3._items;
					Stitch stitch = items[num2];
					int particleIndex = stitch.particleIndex1;
					if (stitch.particleIndex1 >= solverIndices.Length)
					{
						break;
					}
					int index = num - 1;
					particleIndices.set_Item(index, solverIndices[particleIndex]);
					ObiActor obiActor2 = Actor2;
					List<Stitch> list4 = stitches;
					int[] solverIndices2 = obiActor2.solverIndices;
					bool flag5 = list4.Count < num2;
					bool flag6 = !flag5;
					int num4 = list4.Count - num2;
					bool flag7 = num4 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						throw new ArgumentOutOfRangeException();
					}
					Stitch[] items2 = list4._items;
					Stitch stitch2 = items2[num2];
					int particleIndex2 = stitch2.particleIndex2;
					if (stitch2.particleIndex2 >= solverIndices2.Length)
					{
						break;
					}
					particleIndices.set_Item(num, solverIndices2[particleIndex2]);
					stiffnesses.set_Item(num2, 0f);
					list3 = stitches;
					num2++;
					num += 2;
					if (stitches == null)
					{
						NullReferenceException ex = new NullReferenceException();
						break;
					}
					continue;
				}
				ObiNativeIntList obiNativeIntList = particleIndices;
				ObiNativeFloatList obiNativeFloatList = stiffnesses;
				Oni.SetStitchConstraints(batch, obiNativeIntList.m_AlignedPtr, obiNativeFloatList.m_AlignedPtr, list3.Count);
				List<Stitch> list5 = stitches;
				Oni.SetActiveConstraints(batch, list5.Count);
				return;
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60003D2")]
		[Address(RVA = "0x102F504", Offset = "0x102F504", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF3F90]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026267]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>();\n\tSystem.Collections.Generic.List`1<Obi.ObiStitcher+Stitch>::.ctor(v42);\n\tthis.stitches = v42;\n\tv50 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v50, 8, 0x10);\n\tthis.particleIndices = v50;\n\tv58 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v58, 8, 0x10);\n\tthis.stiffnesses = v58;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiStitcher()
		{
			List<Stitch> list = new List<Stitch>();
			stitches = list;
			ObiNativeIntList obiNativeIntList = new ObiNativeIntList();
			particleIndices = obiNativeIntList;
			ObiNativeFloatList obiNativeFloatList = new ObiNativeFloatList();
			stiffnesses = obiNativeFloatList;
		}
	}
}
