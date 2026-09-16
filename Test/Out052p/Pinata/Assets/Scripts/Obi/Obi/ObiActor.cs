using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000005")]
	public abstract class ObiActor : MonoBehaviour, IObiParticleCollection
	{
		[Token(Token = "0x2000099")]
		public class ObiActorSolverArgs : EventArgs
		{
			[Token(Token = "0x40002DC")]
			[FieldOffset(Offset = "0x10")]
			private ObiSolver m_Solver;

			[Token(Token = "0x170000CE")]
			public ObiSolver solver
			{
				[Token(Token = "0x6000510")]
				[Address(RVA = "0xE38ED0", Offset = "0xE38ED0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Solver;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return solver;
				}
			}

			[Token(Token = "0x6000511")]
			[Address(RVA = "0xE38ED8", Offset = "0xE38ED8", Length = "0x7C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED5120]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, solver, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246C5]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, solver, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0023:\n\tSystem.EventArgs::.ctor(this);\n\tthis.m_Solver = solver;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiActorSolverArgs(ObiSolver solver)
			{
				m_Solver = solver;
			}
		}

		[Token(Token = "0x200009A")]
		public delegate void ActorCallback(ObiActor actor);

		[Token(Token = "0x200009B")]
		public delegate void ActorStepCallback(ObiActor actor, float stepTime);

		[Token(Token = "0x200009C")]
		public delegate void ActorBlueprintCallback(ObiActor actor, ObiActorBlueprint blueprint);

		[CompilerGenerated]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x18")]
		private ActorBlueprintCallback m_OnBlueprintLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x20")]
		private ActorBlueprintCallback m_OnBlueprintUnloaded;

		[CompilerGenerated]
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x28")]
		private ActorStepCallback m_OnBeginStep;

		[CompilerGenerated]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x30")]
		private ActorStepCallback m_OnSubstep;

		[CompilerGenerated]
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x38")]
		private ActorCallback m_OnEndStep;

		[CompilerGenerated]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x40")]
		private ActorCallback m_OnInterpolate;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x48")]
		protected ObiSolver m_Solver;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x50")]
		protected IObiConstraints[] m_Constraints;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x58")]
		protected ObiCollisionMaterial m_CollisionMaterial;

		[HideInInspector]
		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x60")]
		protected int m_ActiveParticleCount;

		[HideInInspector]
		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x68")]
		public int[] solverIndices;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x70")]
		protected bool m_Loaded;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x78")]
		private ObiActorBlueprint state;

		[Token(Token = "0x17000004")]
		public ObiSolver solver
		{
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0xE31CE0", Offset = "0xE31CE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Solver;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return solver;
			}
		}

		[Token(Token = "0x17000005")]
		public bool isLoaded
		{
			[Token(Token = "0x60000BF")]
			[Address(RVA = "0xE31CE8", Offset = "0xE31CE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Loaded;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isLoaded;
			}
		}

		[Token(Token = "0x17000006")]
		public ObiCollisionMaterial collisionMaterial
		{
			[Token(Token = "0x60000C0")]
			[Address(RVA = "0xE31CF0", Offset = "0xE31CF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_CollisionMaterial;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return collisionMaterial;
			}
			[Token(Token = "0x60000C1")]
			[Address(RVA = "0xE31CF8", Offset = "0xE31CF8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1F07820]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202469D]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(this.m_CollisionMaterial, value);\n\tv61 = v59 == 0;\n\tif (v61) goto L_0039;\n\tthis.m_CollisionMaterial = value;\n\tObi.ObiActor::PushCollisionMaterial(this);\n\treturn;\nL_0039:\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (collisionMaterial != value)
				{
					m_CollisionMaterial = value;
					PushCollisionMaterial();
				}
			}
		}

		[Token(Token = "0x17000007")]
		public int particleCount
		{
			[Token(Token = "0x60000C2")]
			[Address(RVA = "0xE31EF8", Offset = "0xE31EF8", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EE50A0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202469E]) = v38;\nL_0017:\n\tv43 = Obi.ObiActor::get_blueprint(this);\n\tgoto L_0029;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0029;\n\tv62 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v62, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv61 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv64 = v61 == 0;\n\tif (v64) goto L_FFFFFFFF;\n\tv69 = Obi.ObiActor::get_blueprint(this);\n\tv77 = v69.positions;\n\tv75 = v69.positions == 0;\n\tif (v75) goto L_FFFFFFFF;\n\treturnVal1 = v77.Length;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiActorBlueprint obiActorBlueprint = blueprint;
				if (obiActorBlueprint != null)
				{
					ObiActorBlueprint obiActorBlueprint2 = blueprint;
					Vector3[] positions = obiActorBlueprint2.positions;
					if (obiActorBlueprint2.positions != null)
					{
						return positions.Length;
					}
				}
				return 0;
			}
		}

		[Token(Token = "0x17000008")]
		public int activeParticleCount
		{
			[Token(Token = "0x60000C3")]
			[Address(RVA = "0xE31FD0", Offset = "0xE31FD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ActiveParticleCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return activeParticleCount;
			}
		}

		[Token(Token = "0x17000009")]
		public bool usesOrientedParticles
		{
			[Token(Token = "0x60000C4")]
			[Address(RVA = "0xE31FD8", Offset = "0xE31FD8", Length = "0x180")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB41D0]);\n\tv19 = *([v18 @ X8_v28]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202469F]) = v38;\nL_0017:\n\tv43 = Obi.ObiActor::get_blueprint(this);\n\tgoto L_0029;\n\tv51 = *([v47 @ X8_v6+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0029;\n\tv62 = v47;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v62, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv61 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv64 = v61 == 0;\n\tif (v64) goto L_FFFFFFFF;\n\tv69 = Obi.ObiActor::get_blueprint(this);\n\tv87 = v69.invRotationalMasses == 0;\n\tif (v87) goto L_FFFFFFFF;\n\tv82 = Obi.ObiActor::get_blueprint(this);\n\tv165 = v82.invRotationalMasses;\n\tv88 = v165.Length == 0;\n\tif (v88) goto L_FFFFFFFF;\n\tv83 = Obi.ObiActor::get_blueprint(this);\n\tv89 = v83.orientations == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tv84 = Obi.ObiActor::get_blueprint(this);\n\tv166 = v84.orientations;\n\tv90 = v166.Length == 0;\n\tif (v90) goto L_FFFFFFFF;\n\tv85 = Obi.ObiActor::get_blueprint(this);\n\tv91 = v85.restOrientations == 0;\n\tif (v91) goto L_FFFFFFFF;\n\tv104 = Obi.ObiActor::get_blueprint(this);\n\tv167 = v104.restOrientations;\n\tv135 = v167.Length == 0;\n\tv120 = ~v135;\n\tgoto L_0082;\nL_0082:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiActorBlueprint obiActorBlueprint = blueprint;
				if (obiActorBlueprint != null)
				{
					ObiActorBlueprint obiActorBlueprint2 = blueprint;
					if (obiActorBlueprint2.invRotationalMasses != null)
					{
						ObiActorBlueprint obiActorBlueprint3 = blueprint;
						float[] invRotationalMasses = obiActorBlueprint3.invRotationalMasses;
						if (invRotationalMasses.Length != 0)
						{
							ObiActorBlueprint obiActorBlueprint4 = blueprint;
							if (obiActorBlueprint4.orientations != null)
							{
								ObiActorBlueprint obiActorBlueprint5 = blueprint;
								Quaternion[] orientations = obiActorBlueprint5.orientations;
								if (orientations.Length != 0)
								{
									ObiActorBlueprint obiActorBlueprint6 = blueprint;
									if (obiActorBlueprint6.restOrientations != null)
									{
										ObiActorBlueprint obiActorBlueprint7 = blueprint;
										Quaternion[] restOrientations = obiActorBlueprint7.restOrientations;
										bool flag = restOrientations.Length == 0;
										return !flag;
									}
								}
							}
						}
					}
				}
				return false;
			}
		}

		[Token(Token = "0x1700000A")]
		public virtual bool usesAnisotropicParticles
		{
			[Token(Token = "0x60000C5")]
			[Address(RVA = "0xE32158", Offset = "0xE32158", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000B")]
		public virtual bool usesCustomExternalForces
		{
			[Token(Token = "0x60000C6")]
			[Address(RVA = "0xE32160", Offset = "0xE32160", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000C")]
		public unsafe Matrix4x4 actorLocalToSolverMatrix
		{
			[Token(Token = "0x60000C7")]
			[Address(RVA = "0xE32168", Offset = "0xE32168", Length = "0x14C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_001D;\n\tv24 = *([1F01488]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246A0]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0087;\n\tv71 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv93 = UnityEngine.Transform::get_worldToLocalMatrix(v71);\n\tv75 = UnityEngine.Component::get_transform(this);\n\tv245 = &v225 @ stack_-B0;\n\tv247 = UnityEngine.Transform::get_localToWorldMatrix(v75);\n\tv225 = *([v245 @ X8_v9]);\n\tgoto L_005A;\n\tv270 = *([v266 @ X0_v17+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_005A;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v266, v246, v61, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005A:\n\tv278 = *([v12 @ X29_v1-60]);\n\treturnVal3 = UnityEngine.Matrix4x4::op_Multiply(&v278 @ V3_v1, &v225 @ stack_-B0);\n\treturn returnVal3;\nL_0087:\n\tv69 = UnityEngine.Component::get_transform(this);\n\treturnVal2 = UnityEngine.Transform::get_localToWorldMatrix(v69);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_009c: Expected O, but got I
				//IL_00a9: Expected O, but got Ref
				//IL_00a9: Expected O, but got Ref
				object obj2 = default(object);
				object obj = obj2;
				if (solver != null)
				{
					Transform transform = solver.transform;
					Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
					Transform transform2 = base.transform;
					object obj4 = default(object);
					object obj3 = obj4;
					Matrix4x4 localToWorldMatrix = transform2.localToWorldMatrix;
					obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-60]");
					object obj5 = 0;
					return (Matrix4x4)(&obj5) * (Matrix4x4)(&obj4);
				}
				Transform transform3 = base.transform;
				return transform3.localToWorldMatrix;
			}
		}

		[Token(Token = "0x1700000D")]
		public unsafe Matrix4x4 actorSolverToLocalMatrix
		{
			[Token(Token = "0x60000C8")]
			[Address(RVA = "0xE322B4", Offset = "0xE322B4", Length = "0x140")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = &v13 @ stack_-10_v2;\n\tgoto L_001D;\n\tv24 = *([1EEDB28]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246A1]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv66 = UnityEngine.Component::get_transform(this);\n\tv69 = v62 == 0;\n\tif (v69) goto L_008F;\n\tv82 = UnityEngine.Transform::get_worldToLocalMatrix(v66);\n\tv75 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv242 = &v223 @ stack_-B0;\n\tv244 = UnityEngine.Transform::get_localToWorldMatrix(v75);\n\tv223 = *([v242 @ X8_v9]);\n\tgoto L_005B;\n\tv267 = *([v263 @ X0_v15+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_005B;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v263, v243, v61, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005B:\n\tv275 = *([v12 @ X29_v1-60]);\n\treturnVal3 = UnityEngine.Matrix4x4::op_Multiply(&v275 @ V3_v1, &v223 @ stack_-B0);\n\treturn returnVal3;\nL_008F:\n\treturnVal2 = UnityEngine.Transform::get_worldToLocalMatrix(v66);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_00a1: Expected O, but got I
				//IL_00ae: Expected O, but got Ref
				//IL_00ae: Expected O, but got Ref
				object obj2 = default(object);
				object obj = obj2;
				bool flag = solver != null;
				Transform transform = base.transform;
				if (flag)
				{
					Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
					Transform transform2 = solver.transform;
					object obj4 = default(object);
					object obj3 = obj4;
					Matrix4x4 localToWorldMatrix = transform2.localToWorldMatrix;
					obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X29_v1-60]");
					object obj5 = 0;
					return (Matrix4x4)(&obj5) * (Matrix4x4)(&obj4);
				}
				return transform.worldToLocalMatrix;
			}
		}

		[Token(Token = "0x1700000E")]
		public abstract ObiActorBlueprint blueprint
		{
			[Token(Token = "0x60000C9")]
			get;
		}

		[Token(Token = "0x14000001")]
		public event ActorBlueprintCallback OnBlueprintLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B2")]
			[Address(RVA = "0xE31530", Offset = "0xE31530", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE9450]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024691]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorBlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnBlueprintLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorBlueprintCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B3")]
			[Address(RVA = "0xE315D4", Offset = "0xE315D4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAD248]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024692]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorBlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnBlueprintLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorBlueprintCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000002")]
		public event ActorBlueprintCallback OnBlueprintUnloaded
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B4")]
			[Address(RVA = "0xE31678", Offset = "0xE31678", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC2F98]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024693]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorBlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_OnBlueprintUnloaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorBlueprintCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B5")]
			[Address(RVA = "0xE3171C", Offset = "0xE3171C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFE220]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024694]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorBlueprintCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_OnBlueprintUnloaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorBlueprintCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000003")]
		public event ActorStepCallback OnBeginStep
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B6")]
			[Address(RVA = "0xE317C0", Offset = "0xE317C0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EDBED0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024695]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_OnBeginStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorStepCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B7")]
			[Address(RVA = "0xE31864", Offset = "0xE31864", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ECEBE0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024696]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_OnBeginStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorStepCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000004")]
		public event ActorStepCallback OnSubstep
		{
			[CompilerGenerated]
			[Token(Token = "0x60000B8")]
			[Address(RVA = "0xE31908", Offset = "0xE31908", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAD700]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024697]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_OnSubstep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorStepCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000B9")]
			[Address(RVA = "0xE319AC", Offset = "0xE319AC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAFF80]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024698]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_OnSubstep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorStepCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000005")]
		public event ActorCallback OnEndStep
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0xE31A50", Offset = "0xE31A50", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEDFC0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2024699]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_OnEndStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0xE31AF4", Offset = "0xE31AF4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EFC4C0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202469A]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_OnEndStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000006")]
		public event ActorCallback OnInterpolate
		{
			[CompilerGenerated]
			[Token(Token = "0x60000BC")]
			[Address(RVA = "0xE31B98", Offset = "0xE31B98", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EEC7E0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202469B]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_OnInterpolate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0xE31C3C", Offset = "0xE31C3C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB44F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202469C]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0073: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_OnInterpolate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0xE323F4", Offset = "0xE323F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		protected void Awake()
		{
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0xE323F8", Offset = "0xE323F8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC5D30]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246A2]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponentInParent(this);\n\tthis.m_Solver = v43;\n\tObi.ObiActor::AddToSolver(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnEnable()
		{
			ObiSolver componentInParent = GetComponentInParent<ObiSolver>();
			m_Solver = componentInParent;
			AddToSolver();
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0xE325B4", Offset = "0xE325B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::RemoveFromSolver(this);\n\treturn;\n")]
		protected virtual void OnDisable()
		{
			RemoveFromSolver();
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0xE32700", Offset = "0xE32700", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::PushCollisionMaterial(this);\n\treturn;\n")]
		protected internal virtual void OnValidate()
		{
			PushCollisionMaterial();
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0xE32704", Offset = "0xE32704", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE0C78]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246A3]) = v38;\nL_0015:\n\tv41 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv43 = v41 == 0;\n\tif (v43) goto L_002C;\n\tv48 = UnityEngine.Component::GetComponentInParent(this);\n\tObi.ObiActor::SetSolver(this, v48);\n\treturn;\nL_002C:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnTransformParentChanged()
		{
			if (base.isActiveAndEnabled)
			{
				ObiSolver componentInParent = GetComponentInParent<ObiSolver>();
				SetSolver(componentInParent);
			}
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0xE32454", Offset = "0xE32454", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EB56C8]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20246A4]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0073;\n\tObi.ObiSolver::Initialize(this.m_Solver);\n\tv73 = Obi.ObiSolver::AddActor(this.m_Solver, this);\n\tv76 = v73 == 0;\n\tif (v76) goto L_006C;\n\tv136 = Obi.ObiActor::get_blueprint(this);\n\tgoto L_004A;\n\tv140 = *([v79 @ X8_v8+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_004A;\n\tv147 = v79;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v147, v135, v67, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_004A:\n\tv74 = UnityEngine.Object::op_Inequality(v136, 0);\n\tv77 = v74 == 0;\n\tif (v77) goto L_0073;\n\tv152 = Obi.ObiActor::get_blueprint(this);\n\tv128 = new Obi.ObiActorBlueprint+BlueprintCallback();\n\tv157 = this->klass;\n\tv103 = this->klass->vtable[19];\n\tv128.m_target = this;\n\tv128.method = this->klass->vtable[19];\n\tv128.method_ptr = v103.m_value;\n\tObi.ObiActorBlueprint::add_OnBlueprintGenerate(v152, v128);\n\treturn;\nL_006C:\n\tthis.m_Solver = 0;\nL_0073:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void AddToSolver()
		{
			//IL_00bd: Expected I, but got O
			if (!(solver != null))
			{
				return;
			}
			solver.Initialize();
			if (solver.AddActor(this))
			{
				ObiActorBlueprint obiActorBlueprint = blueprint;
				if (obiActorBlueprint != null)
				{
					ObiActorBlueprint obiActorBlueprint2 = blueprint;
					ObiActorBlueprint.BlueprintCallback blueprintCallback = null;
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X9_v7 (Il2CppClass<Obi.ObiActor>)+268]");
					IntPtr intPtr2 = (IntPtr)0;
					((Delegate)blueprintCallback).m_target = this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X9_v7 (Il2CppClass<Obi.ObiActor>)+268]");
					((Delegate)blueprintCallback).method = (IntPtr)0;
					((Delegate)blueprintCallback).method_ptr = (IntPtr)((IntPtr*)intPtr2)->m_value;
					obiActorBlueprint2.OnBlueprintGenerate += blueprintCallback;
				}
			}
			else
			{
				m_Solver = null;
			}
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0xE325B8", Offset = "0xE325B8", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1ECCAB0]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20246A5]) = v40;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tv58 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006A;\n\tv85 = Obi.ObiSolver::RemoveActor(this.m_Solver, this);\n\tv123 = Obi.ObiActor::get_blueprint(this);\n\tgoto L_0042;\n\tv132 = *([v75 @ X8_v8+E0]);\n\tv133 = v132 == 0;\n\tv134 = ~v133;\n\tif (v134) goto L_0042;\n\tv139 = v75;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v139, v122, v84, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0042:\n\tv71 = UnityEngine.Object::op_Inequality(v123, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_006A;\n\tv144 = Obi.ObiActor::get_blueprint(this);\n\tv129 = new Obi.ObiActorBlueprint+BlueprintCallback();\n\tv149 = this->klass;\n\tv96 = this->klass->vtable[19];\n\tv129.m_target = this;\n\tv129.method = this->klass->vtable[19];\n\tv129.method_ptr = v96.m_value;\n\tObi.ObiActorBlueprint::remove_OnBlueprintGenerate(v144, v129);\n\treturn;\nL_006A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RemoveFromSolver()
		{
			//IL_0090: Expected I, but got O
			if (solver != null)
			{
				bool flag = solver.RemoveActor(this);
				ObiActorBlueprint obiActorBlueprint = blueprint;
				if (obiActorBlueprint != null)
				{
					ObiActorBlueprint obiActorBlueprint2 = blueprint;
					ObiActorBlueprint.BlueprintCallback blueprintCallback = null;
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X9_v7 (Il2CppClass<Obi.ObiActor>)+268]");
					IntPtr intPtr2 = (IntPtr)0;
					((Delegate)blueprintCallback).m_target = this;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ X9_v7 (Il2CppClass<Obi.ObiActor>)+268]");
					((Delegate)blueprintCallback).method = (IntPtr)0;
					((Delegate)blueprintCallback).method_ptr = (IntPtr)((IntPtr*)intPtr2)->m_value;
					obiActorBlueprint2.OnBlueprintGenerate -= blueprintCallback;
				}
			}
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0xE3277C", Offset = "0xE3277C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv22 = *([1EAA538]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, newSolver, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246A6]) = v41;\nL_001C:\n\tgoto L_0025;\n\tv49 = *([v45 @ X0_v2+E0]);\n\tv50 = v49 == 0;\n\tv51 = ~v50;\n\tgoto L_0025;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, newSolver, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = UnityEngine.Object::op_Inequality(newSolver, this.m_Solver);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003B;\n\tObi.ObiActor::RemoveFromSolver(this);\n\tthis.m_Solver = newSolver;\n\tObi.ObiActor::AddToSolver(this);\n\treturn;\nL_003B:\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetSolver(ObiSolver newSolver)
		{
			if (newSolver != solver)
			{
				RemoveFromSolver();
				m_Solver = newSolver;
				AddToSolver();
			}
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0xE32978", Offset = "0xE32978", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiActor::RemoveFromSolver(this);\n\tObi.ObiActor::AddToSolver(this);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void OnBlueprintRegenerate(ObiActorBlueprint blueprint)
		{
			RemoveFromSolver();
			AddToSolver();
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0xE3299C", Offset = "0xE3299C", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EEFAB0]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, enabled, methodInfo, v38, v39, v40, v41, v42, compliance, maxCompression, v43, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([20246A7]) = v51;\nL_001F:\n\tv56 = 0;\n\tv57 = Obi.ObiActor::GetConstraintsByType(this, 4);\n\tv58 = v57 == 0;\n\tif (v58) goto L_00A7;\n\tgoto L_FFFFFFFF;\n\tv97 = v97_asT == 0;\n\tif (v97) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv105 = v105_asT == 0;\n\tif (v105) goto L_00A7;\n\tv215 = v160 == 0;\n\tif (v215) goto L_0082;\n\tv217 = *([v160 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v217) goto L_0082;\n\tv241 = System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>::GetEnumerator(*([v160 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_005B:\n\tv262 = System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>::MoveNext(&v56 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>));\n\tv150 = v262 == 0;\n\tif (v150) goto L_007D;\n\tv231 = 0;\n\tv274 = Oni::EnableBatch(v231.batch, enabled);\n\tgoto L_0073;\n\tv283 = *([v278 @ X0_v28+E0]);\n\tv284 = v283 == 0;\n\tv285 = ~v284;\n\tif (v285) goto L_0073;\n\tv287 = \"il2cpp_codegen_runtime_class_init\"(v278, v255, v253, v38, v39, v40, v41, v42, v83, v80, v77, v44, v45, v46, v47, v48);\nL_0073:\n\tv220 = UnityEngine.Mathf::Max(0f, v82);\n\tObi.ObiDistanceConstraintsBatch::SetParameters(0, v220, v79, 1f);\n\tgoto L_005B;\nL_007D:\n\tv147 = System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>::Dispose(&v56 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>));\n\tgoto L_00A7;\n\tthrow System.NullReferenceException;\nL_0082:\n\tv247 = new System.NullReferenceException();\n\tgoto L_0090;\n\tgoto L_0090;\n\tgoto L_0090;\n\tgoto L_0090;\nL_0090:\n\tv103 = v242 != 1;\n\tif (v103) goto L_00A8;\n\tv265 = 0x6D2BC0(v247, v242, v221, v38, v39, v40, v41, v42, v220, v219, v218, v44, v45, v46, v47, v48);\n\tv269 = 0x6D2490(v265, v242, v221, v38, v39, v40, v41, v42, v220, v219, v218, v44, v45, v46, v47, v48);\n\tv146 = System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>::Dispose(&v56 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiDistanceConstraintsBatch>+Enumerator<Obi.ObiDistanceConstraintsBatch>));\n\tv282 = *([v265 @ X0_v11]) == 0;\n\tv149 = ~v282;\n\tif (v149) goto L_00AC;\nL_00A7:\n\treturn;\nL_00A8:\n\tv266 = 0x6D2380(v247, v242, v221, v38, v39, v40, v41, v42, v220, v219, v218, v44, v45, v46, v47, v48);\nL_00AC:\n\tthrow System.TypeLoadException;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void PushDistanceConstraints(bool enabled, float compliance, float maxCompression)
		{
			//IL_00ad: Expected O, but got I
			//IL_011b: Expected I, but got O
			List<ObiDistanceConstraintsBatch>.Enumerator enumerator = default(List<ObiDistanceConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Distance);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiDistanceConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiDistanceConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.Distance;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiDistanceConstraintsBatch>.Enumerator enumerator2 = ((List<ObiDistanceConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float slack = default(float);
					while (enumerator.MoveNext())
					{
						ObiDistanceConstraintsBatch obiDistanceConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiDistanceConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						((ObiDistanceConstraintsBatch)null).SetParameters(num, slack, 1f);
						float num3 = 1f;
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0xE32D4C", Offset = "0xE32D4C", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1ED7228]);\n\tv33 = *([v32 @ X8_v26]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, enabled, methodInfo, v36, v37, v38, v39, v40, compliance, scale, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20246A8]) = v49;\nL_001E:\n\tv54 = 0;\n\tv55 = Obi.ObiActor::GetConstraintsByType(this, 0);\n\tv56 = v55 == 0;\n\tif (v56) goto L_00A4;\n\tgoto L_FFFFFFFF;\n\tv89 = v89_asT == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv97 = v97_asT == 0;\n\tif (v97) goto L_00A4;\n\tv204 = v152 == 0;\n\tif (v204) goto L_0080;\n\tv206 = *([v152 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v206) goto L_0080;\n\tv228 = System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>::GetEnumerator(*([v152 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_0059:\n\tv248 = System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>::MoveNext(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>));\n\tv142 = v248 == 0;\n\tif (v142) goto L_007B;\n\tv218 = 0;\n\tv261 = Oni::EnableBatch(v218.batch, enabled);\n\tgoto L_0071;\n\tv270 = *([v265 @ X0_v28+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_0071;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v265, v260, v239, v36, v37, v38, v39, v40, v78, v75, v41, v42, v43, v44, v45, v46);\nL_0071:\n\tv208 = UnityEngine.Mathf::Max(0f, v77);\n\tObi.ObiTetherConstraintsBatch::SetParameters(0, v208, v74);\n\tgoto L_0059;\nL_007B:\n\tv139 = System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>));\n\tgoto L_00A4;\n\tthrow System.NullReferenceException;\nL_0080:\n\tv234 = new System.NullReferenceException();\n\tgoto L_008E;\n\tgoto L_008E;\n\tgoto L_008E;\n\tgoto L_008E;\nL_008E:\n\tv95 = v229 != 1;\n\tif (v95) goto L_00A5;\n\tv251 = 0x6D2BC0(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv255 = 0x6D2490(v251, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv138 = System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiTetherConstraintsBatch>+Enumerator<Obi.ObiTetherConstraintsBatch>));\n\tv269 = *([v251 @ X0_v11]) == 0;\n\tv141 = ~v269;\n\tif (v141) goto L_00A9;\nL_00A4:\n\treturn;\nL_00A5:\n\tv252 = 0x6D2380(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\nL_00A9:\n\tthrow System.TypeLoadException;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void PushTetherConstraints(bool enabled, float compliance, float scale)
		{
			//IL_00ae: Expected O, but got I
			//IL_010e: Expected I, but got O
			List<ObiTetherConstraintsBatch>.Enumerator enumerator = default(List<ObiTetherConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(default(Oni.ConstraintType));
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiTetherConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiTetherConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiTetherConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiTetherConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = default(Oni.ConstraintType);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiTetherConstraintsBatch>.Enumerator enumerator2 = ((List<ObiTetherConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float scale2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiTetherConstraintsBatch obiTetherConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiTetherConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						((ObiTetherConstraintsBatch)null).SetParameters(num, scale2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0xE32F10", Offset = "0xE32F10", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1ECBEB0]);\n\tv33 = *([v32 @ X8_v26]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, enabled, methodInfo, v36, v37, v38, v39, v40, compliance, maxBending, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20246A9]) = v49;\nL_001E:\n\tv54 = 0;\n\tv55 = Obi.ObiActor::GetConstraintsByType(this, 3);\n\tv56 = v55 == 0;\n\tif (v56) goto L_00A3;\n\tgoto L_FFFFFFFF;\n\tv89 = v89_asT == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv97 = v97_asT == 0;\n\tif (v97) goto L_00A3;\n\tv204 = v152 == 0;\n\tif (v204) goto L_007F;\n\tv206 = *([v152 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v206) goto L_007F;\n\tv228 = System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>::GetEnumerator(*([v152 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_0059:\n\tv248 = System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>::MoveNext(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>));\n\tv142 = v248 == 0;\n\tif (v142) goto L_007A;\n\tv218 = 0;\n\tv260 = Oni::EnableBatch(v218.batch, enabled);\n\tgoto L_0071;\n\tv269 = *([v264 @ X0_v28+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_0071;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v264, v241, v239, v36, v37, v38, v39, v40, v78, v75, v41, v42, v43, v44, v45, v46);\nL_0071:\n\tv208 = UnityEngine.Mathf::Max(0f, v77);\n\tObi.ObiBendConstraintsBatch::SetParameters(0, v208, v74);\n\tgoto L_0059;\nL_007A:\n\tv139 = System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>));\n\tgoto L_00A3;\n\tthrow System.NullReferenceException;\nL_007F:\n\tv234 = new System.NullReferenceException();\n\tgoto L_008D;\n\tgoto L_008D;\n\tgoto L_008D;\n\tgoto L_008D;\nL_008D:\n\tv95 = v229 != 1;\n\tif (v95) goto L_00A4;\n\tv251 = 0x6D2BC0(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv255 = 0x6D2490(v251, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv138 = System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiBendConstraintsBatch>+Enumerator<Obi.ObiBendConstraintsBatch>));\n\tv268 = *([v251 @ X0_v11]) == 0;\n\tv141 = ~v268;\n\tif (v141) goto L_00A8;\nL_00A3:\n\treturn;\nL_00A4:\n\tv252 = 0x6D2380(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\nL_00A8:\n\tthrow System.TypeLoadException;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void PushBendConstraints(bool enabled, float compliance, float maxBending)
		{
			//IL_00ad: Expected O, but got I
			//IL_010d: Expected I, but got O
			List<ObiBendConstraintsBatch>.Enumerator enumerator = default(List<ObiBendConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Bending);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiBendConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiBendConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiBendConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiBendConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.Bending;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiBendConstraintsBatch>.Enumerator enumerator2 = ((List<ObiBendConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float maxBending2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiBendConstraintsBatch obiBendConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiBendConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						((ObiBendConstraintsBatch)null).SetParameters(num, maxBending2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0xE33184", Offset = "0xE33184", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv40 = *([1ED5920]);\n\tv41 = *([v40 @ X8_v26]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, enabled, methodInfo, v44, v45, v46, v47, v48, stretchCompliance, shear1Compliance, shear2Compliance, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20246AA]) = v56;\nL_0022:\n\tv61 = 0;\n\tv62 = Obi.ObiActor::GetConstraintsByType(this, 7);\n\tv63 = v62 == 0;\n\tif (v63) goto L_00B9;\n\tgoto L_FFFFFFFF;\n\tv105 = v105_asT == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv113 = v113_asT == 0;\n\tif (v113) goto L_00B9;\n\tv227 = v168 == 0;\n\tif (v227) goto L_0090;\n\tv229 = *([v168 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v229) goto L_0090;\n\tv254 = System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>::GetEnumerator(*([v168 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_005D:\n\tv277 = System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>::MoveNext(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>));\n\tv158 = v277 == 0;\n\tif (v158) goto L_008B;\n\tv244 = 0;\n\tv290 = Oni::EnableBatch(v244.batch, enabled);\n\tgoto L_0075;\n\tv299 = *([v294 @ X0_v28+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_0075;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v294, v289, v268, v44, v45, v46, v47, v48, v94, v91, v82, v49, v50, v51, v52, v53);\nL_0075:\n\tv234 = UnityEngine.Mathf::Max(0f, v93);\n\tv311 = UnityEngine.Mathf::Max(0f, v90);\n\tv315 = UnityEngine.Mathf::Max(0f, v81);\n\tObi.ObiStretchShearConstraintsBatch::SetParameters(0, v234, v311, v315);\n\tgoto L_005D;\nL_008B:\n\tv155 = System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>::Dispose(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>));\n\tgoto L_00B9;\n\tthrow System.NullReferenceException;\nL_0090:\n\tv260 = new System.NullReferenceException();\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\n\tgoto L_00A0;\nL_00A0:\n\tv111 = v255 != 1;\n\tif (v111) goto L_00BA;\n\tv280 = 0x6D2BC0(v260, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\n\tv284 = 0x6D2490(v280, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\n\tv154 = System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>::Dispose(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiStretchShearConstraintsBatch>+Enumerator<Obi.ObiStretchShearConstraintsBatch>));\n\tv298 = *([v280 @ X0_v11]) == 0;\n\tv157 = ~v298;\n\tif (v157) goto L_00BE;\nL_00B9:\n\treturn;\nL_00BA:\n\tv281 = 0x6D2380(v260, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\nL_00BE:\n\tthrow System.TypeLoadException;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void PushStretchShearConstraints(bool enabled, float stretchCompliance, float shear1Compliance, float shear2Compliance)
		{
			//IL_00ad: Expected O, but got I
			//IL_013a: Expected I, but got O
			List<ObiStretchShearConstraintsBatch>.Enumerator enumerator = default(List<ObiStretchShearConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.StretchShear);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiStretchShearConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiStretchShearConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiStretchShearConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiStretchShearConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.StretchShear;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiStretchShearConstraintsBatch>.Enumerator enumerator2 = ((List<ObiStretchShearConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float b = default(float);
					float b2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiStretchShearConstraintsBatch obiStretchShearConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiStretchShearConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						float shear1Compliance2 = Mathf.Max(0f, b);
						float shear2Compliance2 = Mathf.Max(0f, b2);
						((ObiStretchShearConstraintsBatch)null).SetParameters(num, shear1Compliance2, shear2Compliance2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0xE33394", Offset = "0xE33394", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv40 = *([1EF1C88]);\n\tv41 = *([v40 @ X8_v26]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, enabled, methodInfo, v44, v45, v46, v47, v48, torsionCompliance, bend1Compliance, bend2Compliance, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20246AB]) = v56;\nL_0022:\n\tv61 = 0;\n\tv62 = Obi.ObiActor::GetConstraintsByType(this, 6);\n\tv63 = v62 == 0;\n\tif (v63) goto L_00B8;\n\tgoto L_FFFFFFFF;\n\tv105 = v105_asT == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv113 = v113_asT == 0;\n\tif (v113) goto L_00B8;\n\tv227 = v168 == 0;\n\tif (v227) goto L_008F;\n\tv229 = *([v168 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v229) goto L_008F;\n\tv254 = System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>::GetEnumerator(*([v168 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_005D:\n\tv277 = System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>::MoveNext(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>));\n\tv158 = v277 == 0;\n\tif (v158) goto L_008A;\n\tv244 = 0;\n\tv289 = Oni::EnableBatch(v244.batch, enabled);\n\tgoto L_0075;\n\tv298 = *([v293 @ X0_v28+E0]);\n\tv299 = v298 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_0075;\n\tv302 = \"il2cpp_codegen_runtime_class_init\"(v293, v270, v268, v44, v45, v46, v47, v48, v94, v91, v82, v49, v50, v51, v52, v53);\nL_0075:\n\tv234 = UnityEngine.Mathf::Max(0f, v93);\n\tv310 = UnityEngine.Mathf::Max(0f, v90);\n\tv314 = UnityEngine.Mathf::Max(0f, v81);\n\tObi.ObiBendTwistConstraintsBatch::SetParameters(0, v234, v310, v314);\n\tgoto L_005D;\nL_008A:\n\tv155 = System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>::Dispose(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>));\n\tgoto L_00B8;\n\tthrow System.NullReferenceException;\nL_008F:\n\tv260 = new System.NullReferenceException();\n\tgoto L_009F;\n\tgoto L_009F;\n\tgoto L_009F;\n\tgoto L_009F;\n\tgoto L_009F;\n\tgoto L_009F;\nL_009F:\n\tv111 = v255 != 1;\n\tif (v111) goto L_00B9;\n\tv280 = 0x6D2BC0(v260, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\n\tv284 = 0x6D2490(v280, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\n\tv154 = System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>::Dispose(&v61 @ stack_-78_v1 (System.Collections.Generic.List`1<Obi.ObiBendTwistConstraintsBatch>+Enumerator<Obi.ObiBendTwistConstraintsBatch>));\n\tv297 = *([v280 @ X0_v11]) == 0;\n\tv157 = ~v297;\n\tif (v157) goto L_00BD;\nL_00B8:\n\treturn;\nL_00B9:\n\tv281 = 0x6D2380(v260, v255, v235, v44, v45, v46, v47, v48, v234, v233, v230, v49, v50, v51, v52, v53);\nL_00BD:\n\tthrow System.TypeLoadException;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void PushBendTwistConstraints(bool enabled, float torsionCompliance, float bend1Compliance, float bend2Compliance)
		{
			//IL_00ad: Expected O, but got I
			//IL_013a: Expected I, but got O
			List<ObiBendTwistConstraintsBatch>.Enumerator enumerator = default(List<ObiBendTwistConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.BendTwist);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiBendTwistConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiBendTwistConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiBendTwistConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiBendTwistConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.BendTwist;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiBendTwistConstraintsBatch>.Enumerator enumerator2 = ((List<ObiBendTwistConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float b = default(float);
					float b2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiBendTwistConstraintsBatch obiBendTwistConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiBendTwistConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						float bend1Compliance2 = Mathf.Max(0f, b);
						float bend2Compliance2 = Mathf.Max(0f, b2);
						((ObiBendTwistConstraintsBatch)null).SetParameters(num, bend1Compliance2, bend2Compliance2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0xE33674", Offset = "0xE33674", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1ECF208]);\n\tv31 = *([v30 @ X8_v22]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, enabled, methodInfo, v34, v35, v36, v37, v38, drag, lift, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20246AC]) = v47;\nL_001D:\n\tv52 = 0;\n\tv53 = Obi.ObiActor::GetConstraintsByType(this, 0xD);\n\tv54 = v53 == 0;\n\tif (v54) goto L_0091;\n\tgoto L_FFFFFFFF;\n\tv84 = v84_asT == 0;\n\tif (v84) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv92 = v92_asT == 0;\n\tif (v92) goto L_0091;\n\tv197 = v147 == 0;\n\tif (v197) goto L_006F;\n\tv199 = *([v147 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v199) goto L_006F;\n\tv219 = System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>::GetEnumerator(*([v147 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_0056:\n\tv236 = System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>::MoveNext(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>));\n\tv137 = v236 == 0;\n\tif (v137) goto L_006A;\n\tv210 = 0;\n\tv248 = Oni::EnableBatch(v210.batch, enabled);\n\tObi.ObiAerodynamicConstraintsBatch::SetParameters(0, v75, v72);\n\tgoto L_0056;\nL_006A:\n\tv134 = System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>::Dispose(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>));\n\tgoto L_0091;\n\tthrow System.NullReferenceException;\nL_006F:\n\tv225 = new System.NullReferenceException();\n\tgoto L_007C;\n\tgoto L_007C;\n\tgoto L_007C;\nL_007C:\n\tv90 = v220 != 1;\n\tif (v90) goto L_0092;\n\tv239 = 0x6D2BC0(v225, v220, v202, v34, v35, v36, v37, v38, v201, v200, v39, v40, v41, v42, v43, v44);\n\tv243 = 0x6D2490(v239, v220, v202, v34, v35, v36, v37, v38, v201, v200, v39, v40, v41, v42, v43, v44);\n\tv133 = System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>::Dispose(&v52 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiAerodynamicConstraintsBatch>+Enumerator<Obi.ObiAerodynamicConstraintsBatch>));\n\tv252 = *([v239 @ X0_v11]) == 0;\n\tv136 = ~v252;\n\tif (v136) goto L_0096;\nL_0091:\n\treturn;\nL_0092:\n\tv240 = 0x6D2380(v225, v220, v202, v34, v35, v36, v37, v38, v201, v200, v39, v40, v41, v42, v43, v44);\nL_0096:\n\tthrow System.TypeLoadException;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void PushAerodynamicConstraints(bool enabled, float drag, float lift)
		{
			//IL_00ad: Expected O, but got I
			//IL_00ee: Expected I, but got O
			List<ObiAerodynamicConstraintsBatch>.Enumerator enumerator = default(List<ObiAerodynamicConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Aerodynamics);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiAerodynamicConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiAerodynamicConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiAerodynamicConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiAerodynamicConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.Aerodynamics;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v147 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiAerodynamicConstraintsBatch>.Enumerator enumerator2 = ((List<ObiAerodynamicConstraintsBatch>)0).GetEnumerator();
					float drag2 = default(float);
					float lift2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiAerodynamicConstraintsBatch obiAerodynamicConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiAerodynamicConstraintsBatch.oniBatch, enabled);
						((ObiAerodynamicConstraintsBatch)null).SetParameters(drag2, lift2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0xE338D0", Offset = "0xE338D0", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv32 = *([1EDA2B0]);\n\tv33 = *([v32 @ X8_v26]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, enabled, methodInfo, v36, v37, v38, v39, v40, compliance, pressure, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20246AD]) = v49;\nL_001E:\n\tv54 = 0;\n\tv55 = Obi.ObiActor::GetConstraintsByType(this, 1);\n\tv56 = v55 == 0;\n\tif (v56) goto L_00A4;\n\tgoto L_FFFFFFFF;\n\tv89 = v89_asT == 0;\n\tif (v89) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv97 = v97_asT == 0;\n\tif (v97) goto L_00A4;\n\tv204 = v152 == 0;\n\tif (v204) goto L_0080;\n\tv206 = *([v152 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v206) goto L_0080;\n\tv228 = System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>::GetEnumerator(*([v152 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_0059:\n\tv248 = System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>::MoveNext(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>));\n\tv142 = v248 == 0;\n\tif (v142) goto L_007B;\n\tv218 = 0;\n\tv261 = Oni::EnableBatch(v218.batch, enabled);\n\tgoto L_0071;\n\tv270 = *([v265 @ X0_v28+E0]);\n\tv271 = v270 == 0;\n\tv272 = ~v271;\n\tif (v272) goto L_0071;\n\tv274 = \"il2cpp_codegen_runtime_class_init\"(v265, v260, v239, v36, v37, v38, v39, v40, v78, v75, v41, v42, v43, v44, v45, v46);\nL_0071:\n\tv208 = UnityEngine.Mathf::Max(0f, v77);\n\tObi.ObiVolumeConstraintsBatch::SetParameters(0, v208, v74);\n\tgoto L_0059;\nL_007B:\n\tv139 = System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>));\n\tgoto L_00A4;\n\tthrow System.NullReferenceException;\nL_0080:\n\tv234 = new System.NullReferenceException();\n\tgoto L_008E;\n\tgoto L_008E;\n\tgoto L_008E;\n\tgoto L_008E;\nL_008E:\n\tv95 = v229 != 1;\n\tif (v95) goto L_00A5;\n\tv251 = 0x6D2BC0(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv255 = 0x6D2490(v251, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\n\tv138 = System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>::Dispose(&v54 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiVolumeConstraintsBatch>+Enumerator<Obi.ObiVolumeConstraintsBatch>));\n\tv269 = *([v251 @ X0_v11]) == 0;\n\tv141 = ~v269;\n\tif (v141) goto L_00A9;\nL_00A4:\n\treturn;\nL_00A5:\n\tv252 = 0x6D2380(v234, v229, v209, v36, v37, v38, v39, v40, v208, v207, v41, v42, v43, v44, v45, v46);\nL_00A9:\n\tthrow System.TypeLoadException;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void PushVolumeConstraints(bool enabled, float compliance, float pressure)
		{
			//IL_00ad: Expected O, but got I
			//IL_010d: Expected I, but got O
			List<ObiVolumeConstraintsBatch>.Enumerator enumerator = default(List<ObiVolumeConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Volume);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiVolumeConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiVolumeConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiVolumeConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiVolumeConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.Volume;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiVolumeConstraintsBatch>.Enumerator enumerator2 = ((List<ObiVolumeConstraintsBatch>)0).GetEnumerator();
					float num2 = default(float);
					float num = num2;
					float pressure2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiVolumeConstraintsBatch obiVolumeConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiVolumeConstraintsBatch.oniBatch, enabled);
						num = Mathf.Max(0f, num2);
						((ObiVolumeConstraintsBatch)null).SetParameters(num, pressure2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0xE33A94", Offset = "0xE33A94", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv42 = *([1EFD310]);\n\tv43 = *([v42 @ X8_v22]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, enabled, methodInfo, v46, v47, v48, v49, v50, stiffness, yield, creep, recovery, maxDeformation, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20246AE]) = v56;\nL_0023:\n\tv61 = 0;\n\tv62 = Obi.ObiActor::GetConstraintsByType(this, 5);\n\tv63 = v62 == 0;\n\tif (v63) goto L_009E;\n\tgoto L_FFFFFFFF;\n\tv102 = v102_asT == 0;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv110 = v110_asT == 0;\n\tif (v110) goto L_009E;\n\tv224 = v165 == 0;\n\tif (v224) goto L_0079;\n\tv226 = *([v165 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v226) goto L_0079;\n\tv249 = System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>::GetEnumerator(*([v165 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_005C:\n\tv269 = System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>::MoveNext(&v61 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>));\n\tv155 = v269 == 0;\n\tif (v155) goto L_0074;\n\tv240 = 0;\n\tv282 = Oni::EnableBatch(v240.batch, enabled);\n\tObi.ObiShapeMatchingConstraintsBatch::SetParameters(0, v93, v90, v87, v84, v81);\n\tgoto L_005C;\nL_0074:\n\tv152 = System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>::Dispose(&v61 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>));\n\tgoto L_009E;\n\tthrow System.NullReferenceException;\nL_0079:\n\tv255 = new System.NullReferenceException();\n\tgoto L_0086;\n\tgoto L_0086;\n\tgoto L_0086;\nL_0086:\n\tv108 = v250 != 1;\n\tif (v108) goto L_009F;\n\tv272 = 0x6D2BC0(v255, v250, v232, v46, v47, v48, v49, v50, v231, v230, v229, v228, v227, v51, v52, v53);\n\tv276 = 0x6D2490(v272, v250, v232, v46, v47, v48, v49, v50, v231, v230, v229, v228, v227, v51, v52, v53);\n\tv151 = System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>::Dispose(&v61 @ stack_-68_v1 (System.Collections.Generic.List`1<Obi.ObiShapeMatchingConstraintsBatch>+Enumerator<Obi.ObiShapeMatchingConstraintsBatch>));\n\tv286 = *([v272 @ X0_v11]) == 0;\n\tv154 = ~v286;\n\tif (v154) goto L_00A3;\nL_009E:\n\treturn;\nL_009F:\n\tv273 = 0x6D2380(v255, v250, v232, v46, v47, v48, v49, v50, v231, v230, v229, v228, v227, v51, v52, v53);\nL_00A3:\n\tthrow System.TypeLoadException;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void PushShapeMatchingConstraints(bool enabled, float stiffness, float yield, float creep, float recovery, float maxDeformation)
		{
			//IL_00ad: Expected O, but got I
			//IL_00fa: Expected I, but got O
			List<ObiShapeMatchingConstraintsBatch>.Enumerator enumerator = default(List<ObiShapeMatchingConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.ShapeMatching);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiShapeMatchingConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiShapeMatchingConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiShapeMatchingConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiShapeMatchingConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.ShapeMatching;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiShapeMatchingConstraintsBatch>.Enumerator enumerator2 = ((List<ObiShapeMatchingConstraintsBatch>)0).GetEnumerator();
					float stiffness2 = default(float);
					float yield2 = default(float);
					float creep2 = default(float);
					float recovery2 = default(float);
					float maxDeformation2 = default(float);
					while (enumerator.MoveNext())
					{
						ObiShapeMatchingConstraintsBatch obiShapeMatchingConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiShapeMatchingConstraintsBatch.oniBatch, enabled);
						((ObiShapeMatchingConstraintsBatch)null).SetParameters(stiffness2, yield2, creep2, recovery2, maxDeformation2);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0xE33C50", Offset = "0xE33C50", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1EDAA40]);\n\tv27 = *([v26 @ X8_v22]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, enabled, methodInfo, v30, v31, v32, v33, v34, tightness, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246AF]) = v44;\nL_001B:\n\tv49 = 0;\n\tv50 = Obi.ObiActor::GetConstraintsByType(this, 2);\n\tv51 = v50 == 0;\n\tif (v51) goto L_008D;\n\tgoto L_FFFFFFFF;\n\tv78 = v78_asT == 0;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv86 = v86_asT == 0;\n\tif (v86) goto L_008D;\n\tv188 = v141 == 0;\n\tif (v188) goto L_006C;\n\tv190 = *([v141 @ X8_v7 (Obi.IObiConstraints)+28]) == 0;\n\tif (v190) goto L_006C;\n\tv209 = System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>::GetEnumerator(*([v141 @ X8_v7 (Obi.IObiConstraints)+28]));\nL_0054:\n\tv225 = System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>::MoveNext(&v49 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>));\n\tv131 = v225 == 0;\n\tif (v131) goto L_0067;\n\tv200 = 0;\n\tv237 = Oni::EnableBatch(v200.batch, enabled);\n\tObi.ObiChainConstraintsBatch::SetParameters(0, v69);\n\tgoto L_0054;\nL_0067:\n\tv128 = System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>::Dispose(&v49 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>));\n\tgoto L_008D;\n\tthrow System.NullReferenceException;\nL_006C:\n\tv215 = new System.NullReferenceException();\n\tgoto L_0079;\n\tgoto L_0079;\n\tgoto L_0079;\nL_0079:\n\tv84 = v210 != 1;\n\tif (v84) goto L_008E;\n\tv228 = 0x6D2BC0(v215, v210, v192, v30, v31, v32, v33, v34, v191, v35, v36, v37, v38, v39, v40, v41);\n\tv232 = 0x6D2490(v228, v210, v192, v30, v31, v32, v33, v34, v191, v35, v36, v37, v38, v39, v40, v41);\n\tv127 = System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>::Dispose(&v49 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiChainConstraintsBatch>+Enumerator<Obi.ObiChainConstraintsBatch>));\n\tv241 = *([v228 @ X0_v11]) == 0;\n\tv130 = ~v241;\n\tif (v130) goto L_0092;\nL_008D:\n\treturn;\nL_008E:\n\tv229 = 0x6D2380(v215, v210, v192, v30, v31, v32, v33, v34, v191, v35, v36, v37, v38, v39, v40, v41);\nL_0092:\n\tthrow System.TypeLoadException;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void PushChainConstraints(bool enabled, float tightness)
		{
			//IL_00ad: Expected O, but got I
			//IL_00ea: Expected I, but got O
			List<ObiChainConstraintsBatch>.Enumerator enumerator = default(List<ObiChainConstraintsBatch>.Enumerator);
			IObiConstraints constraintsByType = GetConstraintsByType(Oni.ConstraintType.Chain);
			if (constraintsByType == null)
			{
				return;
			}
			ObiConstraints<ObiChainConstraintsBatch> obiConstraints = constraintsByType as ObiConstraints<ObiChainConstraintsBatch>;
			IObiConstraints obiConstraints2 = ((obiConstraints == null) ? null : constraintsByType);
			ObiConstraints<ObiChainConstraintsBatch> obiConstraints3 = constraintsByType as ObiConstraints<ObiChainConstraintsBatch>;
			if (obiConstraints3 == null)
			{
				return;
			}
			bool flag = obiConstraints2 == null;
			Oni.ConstraintType constraintType = Oni.ConstraintType.Tether;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v7 (Obi.IObiConstraints)+28]");
				bool flag2 = (IntPtr)0 == (IntPtr)0;
				constraintType = Oni.ConstraintType.Chain;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v7 (Obi.IObiConstraints)+28]");
					List<ObiChainConstraintsBatch>.Enumerator enumerator2 = ((List<ObiChainConstraintsBatch>)0).GetEnumerator();
					float parameters = default(float);
					while (enumerator.MoveNext())
					{
						ObiChainConstraintsBatch obiChainConstraintsBatch = null;
						bool flag3 = Oni.EnableBatch(obiChainConstraintsBatch.oniBatch, enabled);
						((ObiChainConstraintsBatch)null).SetParameters(parameters);
						IntPtr intPtr = (IntPtr)null;
					}
					enumerator.Dispose();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			if (constraintType == Oni.ConstraintType.Volume)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0xE31D94", Offset = "0xE31D94", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv24 = *([1EF4E98]);\n\tv25 = *([v24 @ X8_v20]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20246B0]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0026;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0026:\n\tv62 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv64 = v62 == 0;\n\tif (v64) goto L_0079;\n\tv65 = this.solverIndices;\n\tv66 = this.solverIndices == 0;\n\tif (v66) goto L_0079;\n\t// 49 NewArr v129 @ X0_v8 (System.IntPtr[]), typeof(System.IntPtr[]), v65.Length\n\tv176 = this.solverIndices;\nL_0041:\n\tv131 = v171 >= v176.Length;\n\tif (v131) goto L_007A;\n\tgoto L_0051;\n\tv231 = *([v227 @ X0_v14+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0051;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v227, v206, v176, v133, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0051:\n\tv208 = UnityEngine.Object::op_Inequality(this.m_CollisionMaterial, 0);\n\tv241 = v208 == 0;\n\tif (v241) goto L_005D;\n\tv212 = this.m_CollisionMaterial;\n\tv191 = v212.oniCollisionMaterial;\nL_005D:\n\tv244 = v171 < v129.Length;\n\tv165 = ~v244;\n\tif (v165) goto L_008A;\n\tv129[v171 @ X23_v5 (System.Int32)] = v191;\n\tv176 = this.solverIndices;\n\tv171 = v171 + 1;\n\tv245 = this.solverIndices == 0;\n\tv210 = ~v245;\n\tif (v210) goto L_0041;\n\tthrow System.NullReferenceException;\nL_0079:\n\treturn;\nL_007A:\n\tv190 = this.m_Solver;\n\tOni::SetCollisionMaterials(v190.oniSolver, v129, v176, v176.Length);\n\treturn;\nL_008A:\n\tv246 = new System.IndexOutOfRangeException();\n\tthrow v246;\n\treturn;\n// 93 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void PushCollisionMaterial()
		{
			if (!(solver != null))
			{
				return;
			}
			int[] array = solverIndices;
			if (solverIndices == null)
			{
				return;
			}
			IntPtr[] array2 = new IntPtr[array.Length];
			int[] array3 = solverIndices;
			int num = 0;
			while (true)
			{
				if (num < array3.Length)
				{
					bool flag = collisionMaterial != null;
					bool flag2 = !flag;
					IntPtr intPtr = default(IntPtr);
					if (!flag2)
					{
						ObiCollisionMaterial obiCollisionMaterial = collisionMaterial;
						intPtr = obiCollisionMaterial.OniCollisionMaterial;
					}
					if (num >= array2.Length)
					{
						break;
					}
					array2[num] = intPtr;
					array3 = solverIndices;
					num++;
					if (solverIndices == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				ObiSolver obiSolver = solver;
				Oni.SetCollisionMaterials(obiSolver.OniSolver, array2, array3, array3.Length);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0xE33E94", Offset = "0xE33E94", Length = "0x5AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = actorSourceIndex & 0x80000000;\n\tv28 = v26 == 0;\n\tv29 = ~v28;\n\tif (v29) goto L_0202;\n\tv30 = this.solverIndices;\n\tv85 = v30.Length <= actorDestIndex;\n\tif (v85) goto L_0202;\n\tv471 = actorDestIndex & 0x80000000;\n\tv472 = v471 == 0;\n\tv136 = ~v472;\n\tif (v136) goto L_0202;\n\tv591 = v30.Length < actorSourceIndex;\n\tv126 = ~v591;\n\tv121 = v30.Length - actorSourceIndex;\n\tv111 = v121 == 0;\n\tv86 = v30.Length <= actorSourceIndex;\n\tif (v86) goto L_0202;\n\tv600 = ~v126;\n\tv597 = v600 | v111;\n\tif (v597) goto L_0206;\n\tv601 = v30.Length < actorDestIndex;\n\tv304 = ~v601;\n\tv301 = v30.Length - actorDestIndex;\n\tv295 = v301 == 0;\n\tv602 = ~v304;\n\tv83 = v602 | v295;\n\tif (v83) goto L_0206;\n\tv252 = Obi.ObiSolver::get_prevPositions(this.m_Solver);\n\tv515 = Obi.ObiSolver::get_prevPositions(this.m_Solver);\n\tv253 = Obi.ObiNativeVector4List::get_Item(v515, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv607 = Obi.ObiNativeVector4List::set_Item(v252, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv254 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv517 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv255 = Obi.ObiNativeVector4List::get_Item(v517, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv610 = Obi.ObiNativeVector4List::set_Item(v254, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv256 = Obi.ObiSolver::get_startPositions(this.m_Solver);\n\tv257 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv519 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv258 = Obi.ObiNativeVector4List::get_Item(v519, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv259 = Obi.ObiNativeVector4List::set_Item(v257, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv615 = Obi.ObiNativeVector4List::set_Item(v256, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv260 = Obi.ObiSolver::get_startOrientations(this.m_Solver);\n\tv261 = Obi.ObiSolver::get_orientations(this.m_Solver);\n\tv521 = Obi.ObiSolver::get_orientations(this.m_Solver);\n\tv262 = Obi.ObiNativeQuaternionList::get_Item(v521, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv263 = Obi.ObiNativeQuaternionList::set_Item(v261, v30[actorDestIndex @ X2 (System.Int32)], Quaternion_arg);\n\tv620 = Obi.ObiNativeQuaternionList::set_Item(v260, v30[actorDestIndex @ X2 (System.Int32)], Quaternion_arg);\n\tv264 = Obi.ObiSolver::get_restPositions(this.m_Solver);\n\tv523 = Obi.ObiSolver::get_restPositions(this.m_Solver);\n\tv265 = Obi.ObiNativeVector4List::get_Item(v523, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv623 = Obi.ObiNativeVector4List::set_Item(v264, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv266 = Obi.ObiSolver::get_restOrientations(this.m_Solver);\n\tv525 = Obi.ObiSolver::get_restOrientations(this.m_Solver);\n\tv267 = Obi.ObiNativeQuaternionList::get_Item(v525, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv626 = Obi.ObiNativeQuaternionList::set_Item(v266, v30[actorDestIndex @ X2 (System.Int32)], Quaternion_arg);\n\tv268 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv527 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv269 = Obi.ObiNativeVector4List::get_Item(v527, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv629 = Obi.ObiNativeVector4List::set_Item(v268, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv270 = Obi.ObiSolver::get_angularVelocities(this.m_Solver);\n\tv529 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv271 = Obi.ObiNativeVector4List::get_Item(v529, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv632 = Obi.ObiNativeVector4List::set_Item(v270, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv272 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv531 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv273 = Obi.ObiNativeFloatList::get_Item(v531, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv635 = Obi.ObiNativeFloatList::set_Item(v272, v30[actorDestIndex @ X2 (System.Int32)], v55);\n\tv274 = Obi.ObiSolver::get_invRotationalMasses(this.m_Solver);\n\tv533 = Obi.ObiSolver::get_invRotationalMasses(this.m_Solver);\n\tv275 = Obi.ObiNativeFloatList::get_Item(v533, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv638 = Obi.ObiNativeFloatList::set_Item(v274, v30[actorDestIndex @ X2 (System.Int32)], v55);\n\tv276 = Obi.ObiSolver::get_principalRadii(this.m_Solver);\n\tv535 = Obi.ObiSolver::get_principalRadii(this.m_Solver);\n\tv277 = Obi.ObiNativeVector4List::get_Item(v535, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv641 = Obi.ObiNativeVector4List::set_Item(v276, v30[actorDestIndex @ X2 (System.Int32)], Vector4_arg);\n\tv278 = Obi.ObiSolver::get_phases(this.m_Solver);\n\tv537 = Obi.ObiSolver::get_phases(this.m_Solver);\n\tv279 = Obi.ObiNativeIntList::get_Item(v537, v30[actorSourceIndex @ X1 (System.Int32)]);\n\tv645 = Obi.ObiNativeIntList::set_Item(v278, v30[actorDestIndex @ X2 (System.Int32)], v279);\n\tv280 = Obi.ObiSolver::get_colors(this.m_Solver);\n\tv81 = Obi.ObiSolver::get_colors(this.m_Solver);\n\tv647 = v30[actorSourceIndex @ X1 (System.Int32)] < v81.Length;\n\tv305 = ~v647;\n\tif (v305) goto L_0206;\n\tv648 = v30[actorDestIndex @ X2 (System.Int32)] < v280.Length;\n\tv123 = ~v648;\n\tif (v123) goto L_0206;\n\tv649 = v30[actorSourceIndex @ X1 (System.Int32)] << 4;\n\tv650 = v81 + v649;\n\tv78 = v30[actorDestIndex @ X2 (System.Int32)] << 4;\n\tv128 = v280 + v78;\n\t*([v128 @ X9_v33+20]) = *([v650 @ X8_v50+20]);\n\tv280[v74 @ X19_v6 (System.Int32)].g = v81[v76 @ X21_v6 (System.Int32)].g;\n\tv280[v74 @ X19_v6 (System.Int32)].b = v81[v76 @ X21_v6 (System.Int32)].b;\n\tv280[v74 @ X19_v6 (System.Int32)].a = v81[v76 @ X21_v6 (System.Int32)].a;\nL_0202:\n\treturn;\n\tv397 = new System.NullReferenceException();\n\tv590 = new System.NullReferenceException();\nL_0206:\n\tv599 = new System.IndexOutOfRangeException();\n\tthrow v599;\n\treturn;\n// 422 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void CopyParticle(int actorSourceIndex, int actorDestIndex)
		{
			//IL_0012: Expected I4, but got I8
			//IL_007c: Expected I4, but got I8
			//IL_01e4: Expected F4, but got O
			//IL_01f1: Expected F4, but got O
			//IL_01fe: Expected F4, but got O
			//IL_027e: Expected F4, but got O
			//IL_028b: Expected F4, but got O
			//IL_0298: Expected F4, but got O
			//IL_032c: Expected F4, but got O
			//IL_0339: Expected F4, but got O
			//IL_0346: Expected F4, but got O
			//IL_037f: Expected F4, but got O
			//IL_038c: Expected F4, but got O
			//IL_0399: Expected F4, but got O
			//IL_042d: Expected F4, but got O
			//IL_043a: Expected F4, but got O
			//IL_0447: Expected F4, but got O
			//IL_0480: Expected F4, but got O
			//IL_048d: Expected F4, but got O
			//IL_049a: Expected F4, but got O
			//IL_051a: Expected F4, but got O
			//IL_0527: Expected F4, but got O
			//IL_0534: Expected F4, but got O
			//IL_05b4: Expected F4, but got O
			//IL_05c1: Expected F4, but got O
			//IL_05ce: Expected F4, but got O
			//IL_064e: Expected F4, but got O
			//IL_065b: Expected F4, but got O
			//IL_0668: Expected F4, but got O
			//IL_06e8: Expected F4, but got O
			//IL_06f5: Expected F4, but got O
			//IL_0702: Expected F4, but got O
			//IL_084e: Expected F4, but got O
			//IL_085b: Expected F4, but got O
			//IL_0868: Expected F4, but got O
			//IL_099e: Expected O, but got I
			//IL_09c3: Expected O, but got I
			if ((int)(actorSourceIndex & 0x80000000L) != 0)
			{
				return;
			}
			int[] array = solverIndices;
			if (array.Length <= actorDestIndex || (int)(actorDestIndex & 0x80000000L) != 0)
			{
				return;
			}
			bool flag = array.Length < actorSourceIndex;
			bool flag2 = !flag;
			int num = array.Length - actorSourceIndex;
			bool flag3 = num == 0;
			if (array.Length <= actorSourceIndex)
			{
				return;
			}
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				bool flag5 = array.Length < actorDestIndex;
				bool flag6 = !flag5;
				int num2 = array.Length - actorDestIndex;
				bool flag7 = num2 == 0;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					ObiNativeVector4List prevPositions = solver.prevPositions;
					ObiNativeVector4List prevPositions2 = solver.prevPositions;
					Vector4 vector = prevPositions2.get_Item(array[actorSourceIndex]);
					Vector4 value = default(Vector4);
					float num3 = default(float);
					value.x = num3;
					object obj = default(object);
					value.y = (float)obj;
					object obj2 = default(object);
					value.z = (float)obj2;
					object obj3 = default(object);
					value.w = (float)obj3;
					prevPositions.set_Item(array[actorDestIndex], value);
					ObiNativeVector4List renderablePositions = solver.renderablePositions;
					ObiNativeVector4List renderablePositions2 = solver.renderablePositions;
					Vector4 vector2 = renderablePositions2.get_Item(array[actorSourceIndex]);
					Vector4 value2 = default(Vector4);
					value2.x = num3;
					value2.y = (float)obj;
					value2.z = (float)obj2;
					value2.w = (float)obj3;
					renderablePositions.set_Item(array[actorDestIndex], value2);
					ObiNativeVector4List startPositions = solver.startPositions;
					ObiNativeVector4List positions = solver.positions;
					ObiNativeVector4List positions2 = solver.positions;
					Vector4 vector3 = positions2.get_Item(array[actorSourceIndex]);
					Vector4 value3 = default(Vector4);
					value3.x = num3;
					value3.y = (float)obj;
					value3.z = (float)obj2;
					value3.w = (float)obj3;
					positions.set_Item(array[actorDestIndex], value3);
					Vector4 value4 = default(Vector4);
					value4.x = num3;
					value4.y = (float)obj;
					value4.z = (float)obj2;
					value4.w = (float)obj3;
					startPositions.set_Item(array[actorDestIndex], value4);
					ObiNativeQuaternionList startOrientations = solver.startOrientations;
					ObiNativeQuaternionList orientations = solver.orientations;
					ObiNativeQuaternionList orientations2 = solver.orientations;
					Quaternion quaternion = orientations2.get_Item(array[actorSourceIndex]);
					Quaternion value5 = default(Quaternion);
					value5.x = num3;
					value5.y = (float)obj;
					value5.z = (float)obj2;
					value5.w = (float)obj3;
					orientations.set_Item(array[actorDestIndex], value5);
					Quaternion value6 = default(Quaternion);
					value6.x = num3;
					value6.y = (float)obj;
					value6.z = (float)obj2;
					value6.w = (float)obj3;
					startOrientations.set_Item(array[actorDestIndex], value6);
					ObiNativeVector4List restPositions = solver.restPositions;
					ObiNativeVector4List restPositions2 = solver.restPositions;
					Vector4 vector4 = restPositions2.get_Item(array[actorSourceIndex]);
					Vector4 value7 = default(Vector4);
					value7.x = num3;
					value7.y = (float)obj;
					value7.z = (float)obj2;
					value7.w = (float)obj3;
					restPositions.set_Item(array[actorDestIndex], value7);
					ObiNativeQuaternionList restOrientations = solver.restOrientations;
					ObiNativeQuaternionList restOrientations2 = solver.restOrientations;
					Quaternion quaternion2 = restOrientations2.get_Item(array[actorSourceIndex]);
					Quaternion value8 = default(Quaternion);
					value8.x = num3;
					value8.y = (float)obj;
					value8.z = (float)obj2;
					value8.w = (float)obj3;
					restOrientations.set_Item(array[actorDestIndex], value8);
					ObiNativeVector4List velocities = solver.velocities;
					ObiNativeVector4List velocities2 = solver.velocities;
					Vector4 vector5 = velocities2.get_Item(array[actorSourceIndex]);
					Vector4 value9 = default(Vector4);
					value9.x = num3;
					value9.y = (float)obj;
					value9.z = (float)obj2;
					value9.w = (float)obj3;
					velocities.set_Item(array[actorDestIndex], value9);
					ObiNativeVector4List angularVelocities = solver.angularVelocities;
					ObiNativeVector4List velocities3 = solver.velocities;
					Vector4 vector6 = velocities3.get_Item(array[actorSourceIndex]);
					Vector4 value10 = default(Vector4);
					value10.x = num3;
					value10.y = (float)obj;
					value10.z = (float)obj2;
					value10.w = (float)obj3;
					angularVelocities.set_Item(array[actorDestIndex], value10);
					ObiNativeFloatList invMasses = solver.invMasses;
					ObiNativeFloatList invMasses2 = solver.invMasses;
					float num4 = invMasses2.get_Item(array[actorSourceIndex]);
					invMasses.set_Item(array[actorDestIndex], num3);
					ObiNativeFloatList invRotationalMasses = solver.invRotationalMasses;
					ObiNativeFloatList invRotationalMasses2 = solver.invRotationalMasses;
					float num5 = invRotationalMasses2.get_Item(array[actorSourceIndex]);
					invRotationalMasses.set_Item(array[actorDestIndex], num3);
					ObiNativeVector4List principalRadii = solver.principalRadii;
					ObiNativeVector4List principalRadii2 = solver.principalRadii;
					Vector4 vector7 = principalRadii2.get_Item(array[actorSourceIndex]);
					Vector4 value11 = default(Vector4);
					value11.x = num3;
					value11.y = (float)obj;
					value11.z = (float)obj2;
					value11.w = (float)obj3;
					principalRadii.set_Item(array[actorDestIndex], value11);
					ObiNativeIntList phases = solver.phases;
					ObiNativeIntList phases2 = solver.phases;
					int value12 = phases2.get_Item(array[actorSourceIndex]);
					phases.set_Item(array[actorDestIndex], value12);
					Color[] colors = solver.colors;
					Color[] colors2 = solver.colors;
					if (array[actorSourceIndex] < colors2.Length && array[actorDestIndex] < colors.Length)
					{
						int num6 = array[actorSourceIndex] << 4;
						object obj4 = (long)(IntPtr)colors2 + (long)num6;
						int num7 = array[actorDestIndex] << 4;
						object obj5 = (long)(IntPtr)colors + (long)num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v650 @ X8_v50+20]");
						_ = 0;
						int num8 = default(int);
						int num9 = default(int);
						colors[num8].g = colors2[num9].g;
						colors[num8].b = colors2[num9].b;
						colors[num8].a = colors2[num9].a;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0xE34440", Offset = "0xE34440", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EB0BA0]);\n\tv37 = *([v36 @ X8_v22]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, actorIndex, methodInfo, v40, v41, v42, v43, v44, position, v0, v2, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20246B1]) = v52;\nL_001E:\n\tv53 = actorIndex & 0x80000000;\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0101;\n\tv56 = this.solverIndices;\n\tv99 = v56.Length < actorIndex;\n\tv83 = ~v99;\n\tv80 = v56.Length - actorIndex;\n\tv74 = v80 == 0;\n\tv59 = v56.Length <= actorIndex;\n\tif (v59) goto L_0101;\n\tv307 = ~v83;\n\tv151 = v307 | v74;\n\tif (v151) goto L_0105;\n\tgoto L_004A;\n\tv319 = *([v315 @ X0_v8+E0]);\n\tv320 = v319 == 0;\n\tv321 = ~v320;\n\tif (v321) goto L_004A;\n\tv323 = \"il2cpp_codegen_runtime_class_init\"(v315, actorIndex, methodInfo, v40, v41, v42, v43, v44, position, v0, v2, v45, v46, v47, v48, v49);\nL_004A:\n\tv330 = UnityEngine.Vector4::op_Implicit(position);\n\tv341 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv419 = Obi.ObiNativeVector4List::get_Item(v341, v56[actorIndex @ X1 (System.Int32)]);\n\tv375 = UnityEngine.Vector4::op_Subtraction(v330, v330);\n\tv415 = v375.y;\n\tv411 = v375.z;\n\tv371 = v375.w;\n\tv385 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv430 = Obi.ObiNativeVector4List::get_Item(v385, v56[actorIndex @ X1 (System.Int32)]);\n\tVector4_arg = UnityEngine.Vector4::op_Addition(v375, v375);\n\tv433 = Obi.ObiNativeVector4List::set_Item(v385, v56[actorIndex @ X1 (System.Int32)], Vector4_arg);\n\tv387 = Obi.ObiSolver::get_prevPositions(this.m_Solver);\n\tv439 = Obi.ObiNativeVector4List::get_Item(v387, v56[actorIndex @ X1 (System.Int32)]);\n\tVector4_arg = UnityEngine.Vector4::op_Addition(Vector4_arg, v375);\n\tv442 = Obi.ObiNativeVector4List::set_Item(v387, v56[actorIndex @ X1 (System.Int32)], Vector4_arg);\n\tv389 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv448 = Obi.ObiNativeVector4List::get_Item(v389, v56[actorIndex @ X1 (System.Int32)]);\n\tVector4_arg = UnityEngine.Vector4::op_Addition(Vector4_arg, v375);\n\tv451 = Obi.ObiNativeVector4List::set_Item(v389, v56[actorIndex @ X1 (System.Int32)], Vector4_arg);\n\tv391 = Obi.ObiSolver::get_startPositions(this.m_Solver);\n\tv456 = Obi.ObiNativeVector4List::get_Item(v391, v56[actorIndex @ X1 (System.Int32)]);\n\tv247 = UnityEngine.Vector4::op_Addition(Vector4_arg, v375);\n\tv305 = v247.y;\n\tv302 = v247.z;\n\tv242 = v247.w;\n\tv294 = *([v391 @ X0_v39 (Obi.ObiNativeVector4List)]);\n\tv187 = *([v294 @ X8_v18 (Il2CppClass<Obi.ObiNativeVector4List>)+190]);\n\tv233 = *([v294 @ X8_v18 (Il2CppClass<Obi.ObiNativeVector4List>)+198]);\n\t// 246 IndirectJump v187 @ X3_v1, v391 @ X0_v39 (Obi.ObiNativeVector4List), v391 @ X0_v39 (Obi.ObiNativeVector4List), v56[actorIndex @ X1 (System.Int32)], v233 @ X2_v13, v187 @ X3_v1, v41 @ X4, v42 @ X5, v43 @ X6, v44 @ X7, v247 @ V0_v11 (UnityEngine.Vector4), v305 @ V1_v12 (System.Single), v302 @ V2_v12 (System.Single), v242 @ V3_v10 (System.Single), v375 @ V0_v7 (UnityEngine.Vector4), v415 @ V1_v8 (System.Single), v411 @ V2_v8 (System.Single), v371 @ V3_v6 (System.Single)\nL_0101:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv185 = new System.NullReferenceException();\nL_0105:\n\tv311 = new System.IndexOutOfRangeException();\n\tthrow v311;\n\treturn;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void TeleportParticle(int actorIndex, Vector3 position)
		{
			//IL_02e9: Expected I4, but got I8
			//IL_029e: Expected I, but got O
			//IL_02ae: Expected O, but got I
			//IL_02be: Expected O, but got I
			if ((int)(actorIndex & 0x80000000L) != 0)
			{
				return;
			}
			int[] array = solverIndices;
			bool flag = array.Length < actorIndex;
			bool flag2 = !flag;
			int num = array.Length - actorIndex;
			bool flag3 = num == 0;
			if (array.Length > actorIndex)
			{
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				Vector4 vector = position;
				ObiNativeVector4List positions = solver.positions;
				Vector4 vector2 = positions.get_Item(array[actorIndex]);
				Vector4 vector3 = vector - vector;
				float y = vector3.y;
				float z = vector3.z;
				float w = vector3.w;
				ObiNativeVector4List positions2 = solver.positions;
				Vector4 vector4 = positions2.get_Item(array[actorIndex]);
				Vector4 vector5 = vector3 + vector3;
				positions2.set_Item(array[actorIndex], vector5);
				ObiNativeVector4List prevPositions = solver.prevPositions;
				Vector4 vector6 = prevPositions.get_Item(array[actorIndex]);
				Vector4 vector7 = vector5 + vector3;
				prevPositions.set_Item(array[actorIndex], vector7);
				ObiNativeVector4List renderablePositions = solver.renderablePositions;
				Vector4 vector8 = renderablePositions.get_Item(array[actorIndex]);
				Vector4 vector9 = vector7 + vector3;
				renderablePositions.set_Item(array[actorIndex], vector9);
				ObiNativeVector4List startPositions = solver.startPositions;
				Vector4 vector10 = startPositions.get_Item(array[actorIndex]);
				Vector4 vector11 = vector9 + vector3;
				float y2 = vector11.y;
				float z2 = vector11.z;
				float w2 = vector11.w;
				IntPtr intPtr = (IntPtr)startPositions;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v18 (Il2CppClass<Obi.ObiNativeVector4List>)+190]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X8_v18 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v187 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0xE346FC", Offset = "0xE346FC", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE16C8]);\n\tv23 = *([v22 @ X8_v25]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, actorIndex, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20246B2]) = v41;\nL_0019:\n\tv45 = Obi.ObiSolver::get_particleToActor(this.m_Solver);\n\tv110 = this.solverIndices;\n\tv147 = v110.Length < actorIndex;\n\tv91 = ~v147;\n\tv86 = v110.Length - actorIndex;\n\tv76 = v86 == 0;\n\tv148 = ~v91;\n\tv53 = v148 | v76;\n\tif (v53) goto L_0088;\n\tv176 = v110[actorIndex @ X1 (System.Int32)] < v45.Length;\n\tv92 = ~v176;\n\tif (v92) goto L_0088;\n\tv111 = v45[v110[actorIndex @ X1 (System.Int32)]];\n\tv111.indexInActor = this.m_ActiveParticleCount;\n\tv104 = Obi.ObiSolver::get_particleToActor(this.m_Solver);\n\tv112 = this.solverIndices;\n\tv98 = this.m_ActiveParticleCount;\n\tv212 = this.m_ActiveParticleCount < v112.Length;\n\tv93 = ~v212;\n\tif (v93) goto L_0088;\n\tv214 = v112[v98 @ X9_v7 (System.Int32)] < v104.Length;\n\tv135 = ~v214;\n\tif (v135) goto L_0088;\n\tv172 = v104[v112[v98 @ X9_v7 (System.Int32)]];\n\tv172.indexInActor = actorIndex;\n\tgoto L_0085;\n\tv224 = *([v220 @ X0_v14+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_0085;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v220, v101, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0085:\n\tObi.ObiUtils::Swap(this.solverIndices, actorIndex, this.m_ActiveParticleCount);\n\treturn;\n\tv113 = new System.NullReferenceException();\nL_0088:\n\tv146 = new System.IndexOutOfRangeException();\n\tthrow v146;\n\tthrow System.NullReferenceException;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void SwapWithFirstInactiveParticle(int actorIndex)
		{
			ObiSolver.ParticleInActor[] particleToActor = solver.particleToActor;
			int[] array = solverIndices;
			bool flag = array.Length < actorIndex;
			bool flag2 = !flag;
			int num = array.Length - actorIndex;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3) && array[actorIndex] < particleToActor.Length)
			{
				ObiSolver.ParticleInActor particleInActor = particleToActor[array[actorIndex]];
				particleInActor.indexInActor = activeParticleCount;
				ObiSolver.ParticleInActor[] particleToActor2 = solver.particleToActor;
				int[] array2 = solverIndices;
				int num2 = activeParticleCount;
				if (activeParticleCount < array2.Length && array2[num2] < particleToActor2.Length)
				{
					ObiSolver.ParticleInActor particleInActor2 = particleToActor2[array2[num2]];
					particleInActor2.indexInActor = actorIndex;
					solverIndices.Swap(actorIndex, activeParticleCount);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0xE34844", Offset = "0xE34844", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = this.m_ActiveParticleCount <= actorIndex;\n\tif (v23) goto L_001A;\n\tgoto L_0027;\nL_001A:\n\tv29 = Obi.ObiActor::SwapWithFirstInactiveParticle(this, actorIndex);\n\tv44 = this.m_Solver;\n\tv45 = this.m_ActiveParticleCount + 1;\n\tthis.m_ActiveParticleCount = v45;\n\tv44.activeParticleCountChanged = 1;\nL_0027:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ActivateParticle(int actorIndex)
		{
			if (activeParticleCount > actorIndex)
			{
				return false;
			}
			SwapWithFirstInactiveParticle(actorIndex);
			ObiSolver obiSolver = solver;
			int num = activeParticleCount + 1;
			m_ActiveParticleCount = num;
			obiSolver.activeParticleCountChanged = true;
			return true;
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0xE348BC", Offset = "0xE348BC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = this.m_ActiveParticleCount <= actorIndex;\n\tif (v23) goto L_FFFFFFFF;\n\tv25 = this.m_ActiveParticleCount - 1;\n\tthis.m_ActiveParticleCount = v25;\n\tv29 = Obi.ObiActor::SwapWithFirstInactiveParticle(this, actorIndex);\n\tv43 = this.m_Solver;\n\tv43.activeParticleCountChanged = 1;\n\tgoto L_0026;\nL_0026:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool DeactivateParticle(int actorIndex)
		{
			if (activeParticleCount > actorIndex)
			{
				int num = activeParticleCount - 1;
				m_ActiveParticleCount = num;
				SwapWithFirstInactiveParticle(actorIndex);
				ObiSolver obiSolver = solver;
				obiSolver.activeParticleCountChanged = true;
				return true;
			}
			return false;
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0xE348AC", Offset = "0xE348AC", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.m_ActiveParticleCount - actorIndex;\n\tv6 = v5 < 0;\n\tv7 = v5 == 0;\n\tv8 = this.m_ActiveParticleCount ^ actorIndex;\n\tv9 = this.m_ActiveParticleCount ^ v5;\n\tv10 = v8 & v9;\n\tv11 = v10 < 0;\n\tv12 = v6 == v11;\n\tv13 = ~v7;\n\tv14 = v12 & v13;\n\treturn v14;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsParticleActive(int actorIndex)
		{
			int num = activeParticleCount - actorIndex;
			bool flag = num < 0;
			bool flag2 = num == 0;
			int num2 = activeParticleCount ^ actorIndex;
			int num3 = activeParticleCount ^ num;
			int num4 = num2 & num3;
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0xE34920", Offset = "0xE34920", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EBFDC0]);\n\tv27 = *([v26 @ X8_v21]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, selfCollisions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20246B3]) = v45;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, selfCollisions, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0027:\n\tv63 = UnityEngine.Object::op_Inequality(this.m_Solver, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_0085;\n\tv67 = UnityEngine.Application::get_isPlaying();\n\tv125 = v67 == 0;\n\tif (v125) goto L_0085;\n\tv126 = ~this.m_Loaded;\n\tif (v126) goto L_0085;\n\tv122 = Obi.ObiActor::get_particleCount(this);\n\tv83 = v122 < 1;\n\tif (v83) goto L_0085;\nL_0046:\n\tv206 = Obi.ObiSolver::get_phases(this.m_Solver);\n\tv231 = this.solverIndices;\n\tv247 = v150 < v231.Length;\n\tv243 = ~v247;\n\tif (v243) goto L_0089;\n\tv256 = Obi.ObiNativeIntList::get_Item(v206, v231[v150 @ X23_v4 (System.Int32)]);\n\tv124 = selfCollisions == 0;\n\tif (v124) goto L_0068;\n\tv117 = v256 | 0x1000000;\n\tgoto L_006D;\nL_0068:\n\tv117 = v256 & 0xFEFFFFFF;\nL_006D:\n\tv263 = Obi.ObiNativeIntList::set_Item(v206, v231[v150 @ X23_v4 (System.Int32)], v117);\n\tv79 = v150 + 1;\n\tv121 = Obi.ObiActor::get_particleCount(this);\n\tv81 = v79 < v121;\n\tif (v81) goto L_0046;\nL_0085:\n\treturn;\n\tv227 = new System.NullReferenceException();\n\tv233 = new System.NullReferenceException();\nL_0089:\n\tv246 = new System.IndexOutOfRangeException();\n\tthrow v246;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void SetSelfCollisions(bool selfCollisions)
		{
			//IL_014b: Expected I4, but got I8
			if (!(solver != null) || !Application.isPlaying || !isLoaded)
			{
				return;
			}
			int num = particleCount;
			if (num < 1)
			{
				return;
			}
			int num2 = 0;
			while (true)
			{
				ObiNativeIntList phases = solver.phases;
				int[] array = solverIndices;
				if (num2 >= array.Length)
				{
					break;
				}
				int num3 = phases.get_Item(array[num2]);
				int value = (int)((!selfCollisions) ? (num3 & 0xFEFFFFFFL) : (num3 | 0x1000000));
				phases.set_Item(array[num2], value);
				int num4 = num2 + 1;
				int num5 = particleCount;
				bool flag = num4 < num5;
				num2 = num4;
				if (!flag)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0xE32B6C", Offset = "0xE32B6C", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = type & 0x80000000;\n\tv5 = v3 == 0;\n\tv6 = ~v5;\n\tif (v6) goto L_001D;\n\tv7 = this.m_Constraints;\n\tv8 = this.m_Constraints == 0;\n\tif (v8) goto L_001D;\n\tv47 = v7.Length < type;\n\tv37 = ~v47;\n\tv34 = v7.Length - type;\n\tv28 = v34 == 0;\n\tv50 = v7.Length <= type;\n\tif (v50) goto L_001F;\n\tv81 = ~v37;\n\tv13 = v81 | v28;\n\tif (v13) goto L_0024;\nL_001D:\n\treturn returnVal1;\nL_001F:\n\treturn 0;\nL_0024:\n\tv83 = new System.IndexOutOfRangeException();\n\tthrow v83;\n\treturn returnVal3;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IObiConstraints GetConstraintsByType(Oni.ConstraintType type)
		{
			//IL_0012: Expected I4, but got I8
			int num = (int)((long)type & 0x80000000L);
			bool flag = num == 0;
			bool flag2 = !flag;
			IObiConstraints result = null;
			if (!flag2)
			{
				IObiConstraints[] constraints = m_Constraints;
				bool flag3 = m_Constraints == null;
				result = null;
				if (!flag3)
				{
					bool flag4 = constraints.Length < (int)type;
					bool flag5 = !flag4;
					int num2 = (int)(constraints.Length - type);
					bool flag6 = num2 == 0;
					if (constraints.Length <= (int)type)
					{
						return null;
					}
					bool flag7 = !flag5;
					if (flag7 || flag6)
					{
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					result = constraints[(int)type];
				}
			}
			return result;
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0xE34A74", Offset = "0xE34A74", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void UpdateParticleProperties()
		{
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xE34A78", Offset = "0xE34A78", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = ~this.m_Loaded;\n\tif (v8) goto L_001E;\n\tv9 = this.solverIndices;\n\tv53 = v9.Length < v11;\n\tv42 = ~v53;\n\tv39 = v9.Length - v11;\n\tv33 = v39 == 0;\n\tv54 = ~v42;\n\tv18 = v54 | v33;\n\tif (v18) goto L_0021;\nL_001E:\n\treturn v9[v11 @ X1_v1 (System.Int32)];\n\tv56 = new System.NullReferenceException();\nL_0021:\n\tv103 = new System.IndexOutOfRangeException();\n\tthrow v103;\n\treturn returnVal2;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetParticleRuntimeIndex(int actorIndex)
		{
			int[] array = default(int[]);
			int num = default(int);
			if (isLoaded)
			{
				array = solverIndices;
				bool flag = array.Length < num;
				bool flag2 = !flag;
				int num2 = array.Length - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				num = array[num];
			}
			return array[num];
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0xE34AC8", Offset = "0xE34AC8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1EC8038]);\n\tv31 = *([v30 @ X8_v20]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, solverIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20246B4]) = v49;\nL_001A:\n\tv51 = ~this.m_Loaded;\n\tif (v51) goto L_0061;\n\tv61 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv65 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv168 = Obi.ObiNativeVector4List::get_Item(v65, solverIndex);\n\tgoto L_0044;\n\tv175 = *([v171 @ X0_v16+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0044;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v171, v117, v112, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0044:\n\t// 68 MakeStruct v94 @ AGGE34B94_0_v2 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3\n\tv102 = UnityEngine.Vector4::op_Implicit(v94);\n\treturnVal3 = UnityEngine.Transform::TransformPoint(v61, v102);\n\treturn returnVal3;\nL_0061:\n\tgoto L_0072;\n\tv73 = *([v56 @ X0_v2+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0072;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v56, solverIndex, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\nL_0072:\n\treturnVal1 = UnityEngine.Vector3::get_zero();\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Vector3 GetParticlePosition(int solverIndex)
		{
			//IL_0050: Expected F4, but got O
			//IL_005d: Expected F4, but got O
			//IL_006a: Expected F4, but got O
			//IL_0077: Expected F4, but got O
			if (isLoaded)
			{
				Transform transform = solver.transform;
				ObiNativeVector4List renderablePositions = solver.renderablePositions;
				Vector4 vector = renderablePositions.get_Item(solverIndex);
				Vector4 vector2 = default(Vector4);
				object obj = default(object);
				vector2.x = (float)obj;
				object obj2 = default(object);
				vector2.y = (float)obj2;
				object obj3 = default(object);
				vector2.z = (float)obj3;
				object obj4 = default(object);
				vector2.w = (float)obj4;
				Vector3 position = vector2;
				return transform.TransformPoint(position);
			}
			return Vector3.zero;
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0xE34C04", Offset = "0xE34C04", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1EA9E58]);\n\tv39 = *([v38 @ X8_v17]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, solverIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([20246B5]) = v57;\nL_001E:\n\tv59 = ~this.m_Loaded;\n\tif (v59) goto L_0070;\n\tv69 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv85 = UnityEngine.Transform::get_rotation(v69);\n\tv91 = Obi.ObiSolver::get_renderableOrientations(this.m_Solver);\n\tv184 = Obi.ObiNativeQuaternionList::get_Item(v91, solverIndex);\n\tgoto L_0065;\n\tv195 = *([v190 @ X0_v13+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0065;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v190, v168, v147, v42, v43, v44, v45, v46, v85, v83, v81, v79, v51, v52, v53, v54);\nL_0065:\n\treturnVal3 = UnityEngine.Quaternion::op_Multiply(v85, v85);\n\treturn returnVal3;\nL_0070:\n\tgoto L_0085;\n\tv97 = *([v64 @ X0_v2+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0085;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v64, solverIndex, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_0085:\n\treturnVal2 = UnityEngine.Quaternion::get_identity();\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Quaternion GetParticleOrientation(int solverIndex)
		{
			if (isLoaded)
			{
				Transform transform = solver.transform;
				Quaternion rotation = transform.rotation;
				ObiNativeQuaternionList renderableOrientations = solver.renderableOrientations;
				Quaternion quaternion = renderableOrientations.get_Item(solverIndex);
				return rotation * rotation;
			}
			return Quaternion.identity;
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0xE34D64", Offset = "0xE34D64", Length = "0x3A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv46 = *([1F0ACB8]);\n\tv47 = *([v46 @ X8_v26]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, solverIndex, b1, b2, b3, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([20246B6]) = v62;\nL_0024:\n\tv66 = ~this.m_Loaded;\n\tif (v66) goto L_0111;\n\tv71 = Obi.ObiActor::get_usesAnisotropicParticles(this);\n\tv73 = v71 == 0;\n\tif (v73) goto L_0111;\n\tv230 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv190 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv170 = solverIndex << 1;\n\tv215 = solverIndex + v170;\n\tv393 = Obi.ObiNativeVector4List::get_Item(v190, v215);\n\tgoto L_0058;\n\tv403 = *([v396 @ X0_v27+E0]);\n\tv404 = v403 == 0;\n\tv405 = ~v404;\n\tif (v405) goto L_0058;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v396, v267, v163, b2, b3, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0058:\n\t// 88 MakeStruct v132 @ AGGE34E68_0_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v350 @ V0_v1 (System.Single), v348 @ V1_v1 (System.Single), v346 @ V2_v1 (System.Single), v344 @ V3_v1 (System.Single)\n\tv257 = UnityEngine.Vector4::op_Implicit(v132);\n\tv433 = UnityEngine.Transform::TransformDirection(v230, v257);\n\tv146 = UnityEngine.Vector4::op_Implicit(v433);\n\t*([b1 @ X2 (UnityEngine.Vector4&)]) = v146;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+4]) = v146.y;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+8]) = v146.z;\n\t*([b1 @ X2 (UnityEngine.Vector4&)+C]) = v146.w;\n\tv275 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv192 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv227 = v215 + 1;\n\tv438 = Obi.ObiNativeVector4List::get_Item(v192, v227);\n\tv258 = UnityEngine.Vector4::op_Implicit(v146);\n\tv440 = UnityEngine.Transform::TransformDirection(v275, v258);\n\tv147 = UnityEngine.Vector4::op_Implicit(v440);\n\t*([b2 @ X3 (UnityEngine.Vector4&)]) = v147;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+4]) = v147.y;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+8]) = v147.z;\n\t*([b2 @ X3 (UnityEngine.Vector4&)+C]) = v147.w;\n\tv277 = UnityEngine.Component::get_transform(this.m_Solver);\n\tv194 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv123 = v215 + 2;\n\tv445 = Obi.ObiNativeVector4List::get_Item(v194, v123);\n\tv259 = UnityEngine.Vector4::op_Implicit(v147);\n\tv447 = UnityEngine.Transform::TransformDirection(v277, v259);\n\tv148 = UnityEngine.Vector4::op_Implicit(v447);\n\t*([b3 @ X4 (UnityEngine.Vector4&)]) = v148;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+4]) = v148.y;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+8]) = v148.z;\n\t*([b3 @ X4 (UnityEngine.Vector4&)+C]) = v148.w;\n\tv195 = this.m_Solver;\n\tv196 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv453 = Obi.ObiNativeVector4List::get_Item(v196, v215);\n\tv457 = 0x158BA80(&v148 @ V0_v16 (UnityEngine.Vector4), 3, 0, b2, b3, methodInfo, v50, v51, v148, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\tv350 = v195.m_MaxScale * v148;\n\tv459 = 0x158BB44(b1, 3, 0, b2, b3, methodInfo, v50, v51, v350, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\tv197 = this.m_Solver;\n\tv198 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv462 = Obi.ObiNativeVector4List::get_Item(v198, v227);\n\tv466 = 0x158BA80(&v350 @ V0_v1 (System.Single), 3, 0, b2, b3, methodInfo, v50, v51, v350, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\tv350 = v197.m_MaxScale * v350;\n\tv468 = 0x158BB44(b2, 3, 0, b2, b3, methodInfo, v50, v51, v350, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\tv199 = this.m_Solver;\n\tv200 = Obi.ObiSolver::get_anisotropies(this.m_Solver);\n\tv471 = Obi.ObiNativeVector4List::get_Item(v200, v123);\n\tv474 = 0x158BA80(&v350 @ V0_v1 (System.Single), 3, 0, b2, b3, methodInfo, v50, v51, v350, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\tv350 = v199.m_MaxScale * v350;\n\tgoto L_0135;\nL_0111:\n\tv80 = this.m_Solver;\n\tv86 = Obi.ObiSolver::get_principalRadii(this.m_Solver);\n\tv295 = Obi.ObiNativeVector4List::get_Item(v86, solverIndex);\n\tv303 = 0x158BA80(&v350 @ V0_v1 (System.Single), 0, 0, b2, b3, methodInfo, v50, v51, v350, v348, v346, v344, v56, v57, v58, v59);\n\tv305 = v80.m_MaxScale * v350;\n\tv310 = 0x158BB44(b3, 3, 0, b2, b3, methodInfo, v50, v51, v305, v348, v346, v344, v56, v57, v58, v59);\n\tv391 = 0x158BB44(b2, 3, 0, b2, b3, methodInfo, v50, v51, v305, v348, v346, v344, v56, v57, v58, v59);\nL_0135:\n\tv368 = 0x158BB44(v427, v364, 0, b2, b3, methodInfo, v50, v51, v350, v148.y, v148.z, v148.w, v56, v57, v58, v59);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 248 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void GetParticleAnisotropy(int solverIndex, ref Vector4 b1, ref Vector4 b2, ref Vector4 b3)
		{
			float num3 = default(float);
			if (isLoaded && usesAnisotropicParticles)
			{
				Transform transform = solver.transform;
				ObiNativeVector4List anisotropies = solver.anisotropies;
				int num = solverIndex << 1;
				int num2 = solverIndex + num;
				Vector4 vector = anisotropies.get_Item(num2);
				Vector4 vector2 = default(Vector4);
				vector2.x = num3;
				float y = default(float);
				vector2.y = y;
				float z = default(float);
				vector2.z = z;
				float w = default(float);
				vector2.w = w;
				Vector3 direction = vector2;
				Vector3 vector3 = transform.TransformDirection(direction);
				Vector4 vector4 = vector3;
				ref Vector4 reference = ref *(Vector4*)vector4;
				_ = vector4.y;
				_ = vector4.z;
				_ = vector4.w;
				Transform transform2 = solver.transform;
				ObiNativeVector4List anisotropies2 = solver.anisotropies;
				int index = num2 + 1;
				Vector4 vector5 = anisotropies2.get_Item(index);
				Vector3 direction2 = vector4;
				Vector3 vector6 = transform2.TransformDirection(direction2);
				Vector4 vector7 = vector6;
				ref Vector4 reference2 = ref *(Vector4*)vector7;
				_ = vector7.y;
				_ = vector7.z;
				_ = vector7.w;
				Transform transform3 = solver.transform;
				ObiNativeVector4List anisotropies3 = solver.anisotropies;
				int index2 = num2 + 2;
				Vector4 vector8 = anisotropies3.get_Item(index2);
				Vector3 direction3 = vector7;
				Vector3 vector9 = transform3.TransformDirection(direction3);
				Vector4 vector10 = vector9;
				ref Vector4 reference3 = ref *(Vector4*)vector10;
				_ = vector10.y;
				_ = vector10.z;
				_ = vector10.w;
				ObiSolver obiSolver = solver;
				ObiNativeVector4List anisotropies4 = solver.anisotropies;
				Vector4 vector11 = anisotropies4.get_Item(num2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
				num3 = obiSolver.maxScale * vector10.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BB44 (inside UnityEngine.Vector3Int::.cctor +0x178)");
				ObiSolver obiSolver2 = solver;
				ObiNativeVector4List anisotropies5 = solver.anisotropies;
				Vector4 vector12 = anisotropies5.get_Item(index);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
				num3 = obiSolver2.maxScale * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BB44 (inside UnityEngine.Vector3Int::.cctor +0x178)");
				ObiSolver obiSolver3 = solver;
				ObiNativeVector4List anisotropies6 = solver.anisotropies;
				Vector4 vector13 = anisotropies6.get_Item(index2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
				num3 = obiSolver3.maxScale * num3;
				int num4 = 3;
				ref Vector4 reference4 = ref b3;
			}
			else
			{
				ObiSolver obiSolver4 = solver;
				ObiNativeVector4List principalRadii = solver.principalRadii;
				Vector4 vector14 = principalRadii.get_Item(solverIndex);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
				float num5 = obiSolver4.maxScale * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BB44 (inside UnityEngine.Vector3Int::.cctor +0x178)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BB44 (inside UnityEngine.Vector3Int::.cctor +0x178)");
				num3 = num5;
				int num4 = 3;
				ref Vector4 reference4 = ref b1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BB44 (inside UnityEngine.Vector3Int::.cctor +0x178)");
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0xE35104", Offset = "0xE35104", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = ~this.m_Loaded;\n\tif (v16) goto L_FFFFFFFF;\n\tv17 = this.m_Solver;\n\tv22 = Obi.ObiSolver::get_principalRadii(this.m_Solver);\n\tv89 = Obi.ObiNativeVector4List::get_Item(v22, solverIndex);\n\tv60 = 0x158BA80(&returnVal1 @ V0_v1 (System.Single), 0, 0, v30, v31, v32, v33, v34, returnVal1, v36, v37, v38, v39, v40, v41, v42);\n\treturnVal1 = v17.m_MaxScale * returnVal1;\n\tgoto L_0029;\nL_0029:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetParticleMaxRadius(int solverIndex)
		{
			if (isLoaded)
			{
				ObiSolver obiSolver = solver;
				ObiNativeVector4List principalRadii = solver.principalRadii;
				Vector4 vector = principalRadii.get_Item(solverIndex);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
				float num = default(float);
				return obiSolver.maxScale * num;
			}
			return 0f;
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0xE3518C", Offset = "0xE3518C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~this.m_Loaded;\n\tif (v12) goto L_002E;\n\tv21 = Obi.ObiSolver::get_colors(this.m_Solver);\n\tv112 = v21.Length < solverIndex;\n\tv70 = ~v112;\n\tv67 = v21.Length - solverIndex;\n\tv61 = v67 == 0;\n\tv113 = ~v70;\n\tv46 = v113 | v61;\n\tif (v46) goto L_0034;\n\tv90 = solverIndex << 4;\n\tv109 = v21 + v90;\n\treturn *([v109 @ X8_v5+20]);\nL_002E:\n\treturnVal1 = UnityEngine.Color::get_white();\n\treturn returnVal1;\n\tv26 = new System.NullReferenceException();\nL_0034:\n\tv76 = new System.IndexOutOfRangeException();\n\tthrow v76;\n\treturn returnVal3;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Color GetParticleColor(int solverIndex)
		{
			//IL_00aa: Expected O, but got I
			//IL_00b7: Expected O, but got I
			if (isLoaded)
			{
				Color[] colors = solver.colors;
				bool flag = colors.Length < solverIndex;
				bool flag2 = !flag;
				int num = colors.Length - solverIndex;
				bool flag3 = num == 0;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					int num2 = solverIndex << 4;
					object obj = (long)(IntPtr)colors + (long)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X8_v5+20]");
					return (Color)0;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			return Color.white;
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0xE35204", Offset = "0xE35204", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EEA8C8]);\n\tv29 = *([v28 @ X8_v20]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, newPhase, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20246B7]) = v47;\nL_001E:\n\tgoto L_0028;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0028;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, newPhase, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0028:\n\tv65 = UnityEngine.Mathf::Clamp(newPhase, 0, 0xFFFFFF);\n\tv68 = Obi.ObiActor::get_particleCount(this);\n\tv79 = v68 < 1;\n\tif (v79) goto L_0085;\nL_0039:\n\tv154 = this.solverIndices;\n\tv200 = v137 < v154.Length;\n\tv201 = ~v200;\n\tif (v201) goto L_0089;\n\tv263 = Obi.ObiSolver::get_phases(this.m_Solver);\n\tv268 = Obi.ObiNativeIntList::get_Item(v263, v154[v137 @ X24_v4 (System.Int32)]);\n\tv228 = Oni::GetFlagsFromPhase(v268);\n\tv271 = Obi.ObiSolver::get_phases(this.m_Solver);\n\tv229 = Oni::MakePhase(v65, v228);\n\tv275 = Obi.ObiNativeIntList::set_Item(v271, v154[v137 @ X24_v4 (System.Int32)], v229);\n\tv92 = v137 + 1;\n\tv118 = Obi.ObiActor::get_particleCount(this);\n\tv94 = v92 < v118;\n\tif (v94) goto L_0039;\nL_0085:\n\treturn;\n\tv236 = new System.NullReferenceException();\n\tv256 = new System.NullReferenceException();\nL_0089:\n\tv260 = new System.IndexOutOfRangeException();\n\tthrow v260;\n\treturn;\n// 106 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPhase(int newPhase)
		{
			int num = Mathf.Clamp(newPhase, 0, 16777215);
			int num2 = particleCount;
			if (num2 < 1)
			{
				return;
			}
			int num3 = 0;
			while (true)
			{
				int[] array = solverIndices;
				if (num3 >= array.Length)
				{
					break;
				}
				ObiNativeIntList phases = solver.phases;
				int phase = phases.get_Item(array[num3]);
				int flagsFromPhase = Oni.GetFlagsFromPhase(phase);
				ObiNativeIntList phases2 = solver.phases;
				int value = Oni.MakePhase(num, (Oni.ParticleFlags)flagsFromPhase);
				phases2.set_Item(array[num3], value);
				int num4 = num3 + 1;
				int num5 = particleCount;
				bool flag = num4 < num5;
				num3 = num4;
				if (!flag)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0xE35364", Offset = "0xE35364", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Application::get_isPlaying();\n\tv21 = v19 == 0;\n\tif (v21) goto L_0064;\n\tv23 = ~this.m_Loaded;\n\tif (v23) goto L_0064;\n\tv48 = this.m_ActiveParticleCount < 1;\n\tif (v48) goto L_0064;\n\tv143 = mass / this.m_ActiveParticleCount;\n\tv88 = 1f / v143;\nL_0024:\n\tv162 = this.solverIndices;\n\tv165 = v111 < v162.Length;\n\tv166 = ~v165;\n\tif (v166) goto L_0068;\n\tv221 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv233 = Obi.ObiNativeFloatList::set_Item(v221, v162[v111 @ X21_v4 (System.Int32)], v88);\n\tv232 = Obi.ObiSolver::get_invRotationalMasses(this.m_Solver);\n\tv90 = Obi.ObiNativeFloatList::set_Item(v232, v162[v111 @ X21_v4 (System.Int32)], v88);\n\tv111 = v111 + 1;\n\tv46 = v111 < this.m_ActiveParticleCount;\n\tif (v46) goto L_0024;\nL_0064:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv201 = new System.NullReferenceException();\nL_0068:\n\tv218 = new System.IndexOutOfRangeException();\n\tthrow v218;\n\treturn;\n// 83 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMass(float mass)
		{
			if (!Application.isPlaying || !isLoaded || activeParticleCount < 1)
			{
				return;
			}
			float num = mass / (float)activeParticleCount;
			float value = 1f / num;
			int num2 = 0;
			while (true)
			{
				int[] array = solverIndices;
				if (num2 >= array.Length)
				{
					break;
				}
				ObiNativeFloatList invMasses = solver.invMasses;
				invMasses.set_Item(array[num2], value);
				ObiNativeFloatList invRotationalMasses = solver.invRotationalMasses;
				invRotationalMasses.set_Item(array[num2], value);
				num2++;
				if (num2 >= activeParticleCount)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0xE35460", Offset = "0xE35460", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv44 = *([1EBEF48]);\n\tv45 = *([v44 @ X8_v41]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, com, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([20246B8]) = v63;\nL_0026:\n\tgoto L_002D;\n\tv70 = *([v66 @ X0_v2+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tgoto L_002D;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, com, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\nL_002D:\n\tv78 = UnityEngine.Vector3::get_zero();\n\t*([com @ X1 (UnityEngine.Vector3&)]) = v78;\n\t*([com @ X1 (UnityEngine.Vector3&)+4]) = v78.y;\n\t*([com @ X1 (UnityEngine.Vector3&)+8]) = v78.z;\n\tv82 = UnityEngine.Application::get_isPlaying();\n\tv85 = v82 == 0;\n\tif (v85) goto L_0169;\n\tv87 = ~this.m_Loaded;\n\tif (v87) goto L_0169;\n\tv153 = this.m_ActiveParticleCount < 1;\n\tif (v153) goto L_0169;\n\tgoto L_0056;\n\tv318 = *([v314 @ X0_v8+E0]);\n\tv319 = v318 == 0;\n\tv320 = ~v319;\n\tif (v320) goto L_0056;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v314, com, methodInfo, v48, v49, v50, v51, v52, v78, v79, v80, v56, v57, v58, v59, v60);\nL_0056:\n\tv326 = UnityEngine.Vector4::get_zero();\n\tv402 = v326.y;\n\tv638 = v326.z;\n\tv380 = v326.w;\n\tv345 = this.m_ActiveParticleCount < 1;\n\tif (v345) goto L_FFFFFFFF;\nL_0072:\n\tv437 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv516 = this.solverIndices;\n\tv561 = v265 < v516.Length;\n\tv498 = ~v561;\n\tif (v498) goto L_016D;\n\tv579 = Obi.ObiNativeFloatList::get_Item(v437, v516[v265 @ X23_v5 (System.Int32)]);\n\tv461 = v403 <= 0;\n\tif (v461) goto L_0105;\n\tv506 = Obi.ObiSolver::get_invMasses(this.m_Solver);\n\tv518 = this.solverIndices;\n\tv621 = v265 < v518.Length;\n\tv500 = ~v621;\n\tif (v500) goto L_016D;\n\tv623 = Obi.ObiNativeFloatList::get_Item(v506, v518[v265 @ X23_v5 (System.Int32)]);\n\tv508 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv520 = this.solverIndices;\n\tv624 = v265 < v520.Length;\n\tv501 = ~v624;\n\tif (v501) goto L_016D;\n\tv593 = 1f / v403;\n\tv628 = Obi.ObiNativeVector4List::get_Item(v508, v520[v265 @ X23_v5 (System.Int32)]);\n\tgoto L_00E8;\n\tv634 = *([v629 @ X0_v39+E0]);\n\tv635 = v634 == 0;\n\tv636 = ~v635;\n\tif (v636) goto L_00E8;\n\tv637 = v298;\n\tv641 = \"il2cpp_codegen_runtime_class_init\"(v629, v597, v594, v48, v49, v50, v51, v52, v626, v300, v298, v275, v243, v241, v239, v237);\n\tv639 = v637;\nL_00E8:\n\tv646 = v133 + v593;\n\t// 236 MakeStruct v583 @ AGGE35678_0_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 1f, v402 @ V1_v11 (System.Single), v638 @ V2_v11 (System.Single), v380 @ V3_v7 (System.Single)\n\tv649 = UnityEngine.Vector4::op_Multiply(v583, v593);\n\t// 250 MakeStruct v585 @ AGGE356A0_0_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v414 @ V11_v4 (UnityEngine.Vector4), v142 @ V12_v4 (System.Single), v140 @ V14_v4 (System.Single), v413 @ V9_v4 (System.Single)\n\tv614 = UnityEngine.Vector4::op_Addition(v585, v649);\n\tv402 = v614.y;\n\tv638 = v614.z;\n\tv380 = v614.w;\nL_0105:\n\tv265 = v265 + 1;\n\tv382 = v265 < this.m_ActiveParticleCount;\n\tif (v382) goto L_0072;\n\tgoto L_0119;\nL_0119:\n\tgoto L_0124;\n\tv522 = *([v432 @ X0_v12+E0]);\n\tv523 = v522 == 0;\n\tv524 = ~v523;\n\tgoto L_0124;\n\tv526 = \"il2cpp_codegen_runtime_class_init\"(v432, v131, v121, v48, v49, v50, v51, v52, v428, v427, v426, v415, v110, v108, v106, v104);\nL_0124:\n\t// 292 MakeStruct v95 @ AGGE356FC_0_v2 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v414 @ V11_v4 (UnityEngine.Vector4), v142 @ V12_v4 (System.Single), v140 @ V14_v4 (System.Single), v413 @ V9_v4 (System.Single)\n\tv531 = UnityEngine.Vector4::op_Implicit(v95);\n\t*([com @ X1 (UnityEngine.Vector3&)]) = v531;\n\t*([com @ X1 (UnityEngine.Vector3&)+4]) = v531.y;\n\t*([com @ X1 (UnityEngine.Vector3&)+8]) = v531.z;\n\tv151 = v133 <= 1E-45f;\n\tif (v151) goto L_FFFFFFFF;\n\tgoto L_014F;\n\tv570 = *([v566 @ X0_v15+E0]);\n\tv571 = v570 == 0;\n\tv572 = ~v571;\n\tif (v572) goto L_014F;\n\tv574 = \"il2cpp_codegen_runtime_class_init\"(v566, v131, v121, v48, v49, v50, v51, v52, v196, v193, v190, v146, v110, v108, v106, v104);\nL_014F:\n\tv197 = UnityEngine.Vector3::op_Division(v531, v133);\n\t*([com @ X1 (UnityEngine.Vector3&)]) = v197;\n\t*([com @ X1 (UnityEngine.Vector3&)+4]) = v197.y;\n\t*([com @ X1 (UnityEngine.Vector3&)+8]) = v197.z;\n\tgoto L_0169;\nL_0169:\n\treturn v186;\n\tthrow System.NullReferenceException;\n\tv556 = new System.NullReferenceException();\nL_016D:\n\tv565 = new System.IndexOutOfRangeException();\n\tthrow v565;\n\treturn returnVal2;\n// 264 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe float GetMass(out Vector3 com)
		{
			com = default(Vector3);
			Vector3 zero = Vector3.zero;
			ref Vector3 reference = ref *(Vector3*)zero;
			_ = zero.y;
			_ = zero.z;
			bool isPlaying = Application.isPlaying;
			bool flag = !isPlaying;
			float result = 0f;
			if (!flag)
			{
				bool flag2 = !isLoaded;
				result = 0f;
				if (!flag2)
				{
					bool flag3 = activeParticleCount < 1;
					result = 0f;
					if (!flag3)
					{
						Vector4 zero2 = Vector4.zero;
						float y = zero2.y;
						float z = zero2.z;
						float w = zero2.w;
						float num;
						float w2;
						float z2;
						float y2;
						Vector4 vector;
						if (activeParticleCount >= 1)
						{
							num = 0f;
							int num2 = 0;
							w2 = zero2.w;
							z2 = zero2.z;
							y2 = zero2.y;
							vector = zero2;
							float num3 = 0f;
							Vector4 vector3 = default(Vector4);
							Vector4 vector5 = default(Vector4);
							do
							{
								ObiNativeFloatList invMasses = solver.invMasses;
								int[] array = solverIndices;
								if (num2 < array.Length)
								{
									float num4 = invMasses.get_Item(array[num2]);
									if (!(num3 > 0f))
									{
										goto IL_03e3;
									}
									ObiNativeFloatList invMasses2 = solver.invMasses;
									int[] array2 = solverIndices;
									if (num2 < array2.Length)
									{
										float num5 = invMasses2.get_Item(array2[num2]);
										ObiNativeVector4List positions = solver.positions;
										int[] array3 = solverIndices;
										if (num2 < array3.Length)
										{
											float num6 = 1f / num3;
											Vector4 vector2 = positions.get_Item(array3[num2]);
											float num7 = num + num6;
											vector3.x = 1f;
											vector3.y = y;
											vector3.z = z;
											vector3.w = w;
											Vector4 vector4 = vector3 * num6;
											vector5.x = vector.x;
											vector5.y = y2;
											vector5.z = z2;
											vector5.w = w2;
											Vector4 vector6 = vector5 + vector4;
											y = vector6.y;
											z = vector6.z;
											w = vector6.w;
											num = num7;
											w2 = vector6.w;
											z2 = vector6.z;
											y2 = vector6.y;
											vector = vector6;
											num3 = vector6.x;
											goto IL_03e3;
										}
									}
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
								IL_03e3:
								num2++;
							}
							while (num2 < activeParticleCount);
						}
						else
						{
							num = 0f;
							w2 = zero2.w;
							z2 = zero2.z;
							y2 = zero2.y;
							vector = zero2;
						}
						Vector4 vector7 = default(Vector4);
						vector7.x = vector.x;
						vector7.y = y2;
						vector7.z = z2;
						vector7.w = w2;
						Vector3 vector8 = vector7;
						reference = ref *(Vector3*)vector8;
						_ = vector8.y;
						_ = vector8.z;
						if (num > float.Epsilon)
						{
							Vector3 vector9 = vector8 / num;
							reference = ref *(Vector3*)vector9;
							_ = vector9.y;
							_ = vector9.z;
							result = num;
						}
						else
						{
							result = num;
						}
					}
				}
			}
			return result;
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0xE357B4", Offset = "0xE357B4", Length = "0x6F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv50 = *([1EF44A0]);\n\tv51 = *([v50 @ X8_v12]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, forceMode, methodInfo, v54, v55, v56, v57, v58, force, v0, v2, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([20246B9]) = v66;\nL_0028:\n\tv68 = 0;\n\tv71 = Obi.ObiActor::GetMass(this, &v68 @ stack_-90_v1 (UnityEngine.Vector3));\n\tv74 = System.Single::IsInfinity(v71);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0048;\nL_0041:\n\treturn;\nL_0048:\n\tgoto L_0053;\n\tv191 = *([v149 @ X0_v5+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0053;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v149, v67, methodInfo, v54, v55, v56, v57, v58, v71, v0, v2, v59, v60, v61, v62, v63);\nL_0053:\n\tv113 = UnityEngine.Vector4::op_Implicit(force);\n\tv131 = v113.y;\n\tv129 = v113.z;\n\tv108 = v113.w;\n\tv199 = forceMode < 5;\n\tv106 = ~v199;\n\tv103 = forceMode - 5;\n\tv97 = v103 == 0;\n\tv200 = ~v97;\n\tv79 = v106 & v200;\n\tif (v79) goto L_0041;\n\tv155 = 0x181C000 + 0x67C;\n\tv186 = *([v155 @ X9_v2 (System.Int32)+forceMode @ X1 (UnityEngine.ForceMode)*4]) + v155;\n\t// 108 IndirectJump v186 @ X8_v7, 0, 0, &v68 @ stack_-90_v1 (UnityEngine.Vector3), methodInfo @ X2 (Il2CppMethodInfo), v54 @ X3, v55 @ X4, v56 @ X5, v57 @ X6, v58 @ X7, v113 @ V0_v3 (UnityEngine.Vector4), v131 @ V1_v3 (System.Single), v129 @ V2_v3 (System.Single), v108 @ V3_v1 (System.Single), v60 @ V4, v61 @ V5, v62 @ V6, v63 @ V7\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0077;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0077;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0077:\n\tV0 = stack[C];\n\tV1 = V11;\n\tV2 = V9;\n\tV3 = V10;\n\tV4 = V12;\n\tX0 = 0;\n\t// 125 MakeStruct AGGE358F4_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Division(AGGE358F4_0, V4, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tstack[C] = V0;\n\tX8 = *([X19+68]);\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\tif (TEMP) goto L_02CD;\n\tX23 = 0;\nL_008A:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = *([X19+48]);\n\tif (TEMP) goto L_02CF;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_externalForces(X0, X1);\n\tX8 = *([X19+68]);\n\tX20 = X0;\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02D0;\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X20]);\n\tX24 = X23;\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX21 = *([X8+20]);\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX0 = X20;\n\tX1 = X21;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+48]);\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\tV15 = V3;\n\tif (TEMP) goto L_02CF;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_invMasses(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02D0;\n\tif (TEMP) goto L_02CF;\n\tX9 = *([X0]);\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX23 = X23 + 1;\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\n\tV8 = V0;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00E2;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E2:\n\tV0 = stack[C];\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tV4 = V8;\n\tX0 = 0;\n\t// 232 MakeStruct AGGE359F0_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Division(AGGE359F0_0, V4, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = V0;\n\tV5 = V1;\n\tV6 = V2;\n\tV7 = V3;\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tV3 = V15;\n\tX0 = 0;\n\t// 246 MakeStruct AGGE35A18_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\t// 247 MakeStruct AGGE35A18_1, typeof(UnityEngine.Vector4), V4, V5, V6, V7\n\tV0 = UnityEngine.Vector4::op_Addition(AGGE35A18_0, AGGE35A18_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX1 = X21;\n\tX9 = *([X8+190]);\n\tX2 = *([X8+198]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_008A;\n\tgoto L_02CD;\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0111;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0111;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0111:\n\tV0 = stack[C];\n\tV1 = V11;\n\tV2 = V9;\n\tV3 = V10;\n\tV4 = V12;\n\tX0 = 0;\n\t// 279 MakeStruct AGGE35A6C_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Division(AGGE35A6C_0, V4, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tstack[8] = V1;\n\tstack[C] = V0;\n\tstack[4] = V2;\n\tX8 = *([X19+68]);\n\tstack[0] = V3;\n\tif (TEMP) goto L_02CD;\n\tX23 = 0;\nL_0124:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = *([X19+48]);\n\tif (TEMP) goto L_02CF;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_externalForces(X0, X1);\n\tX8 = *([X19+68]);\n\tX20 = X0;\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02D0;\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X20]);\n\tX24 = X23;\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX21 = *([X8+20]);\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX0 = X20;\n\tX1 = X21;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+48]);\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\tV15 = V3;\n\tif (TEMP) goto L_02CF;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_invMasses(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_02CD;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_02D0;\n\tif (TEMP) goto L_02CF;\n\tX9 = *([X0]);\n\tTEMPSHIFT = X24 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX23 = X23 + 1;\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\n\tV8 = V0;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_017C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_017C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_017C:\n\tV1 = stack[8];\n\tV0 = stack[C];\n\tV3 = stack[0];\n\tV2 = stack[4];\n\tV4 = V8;\n\tX0 = 0;\n\t// 386 MakeStruct AGGE35B5C_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Division(AGGE35B5C_0, V4, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX0 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\tV0 = UnityEngine.Time::get_fixedDeltaTime(X0);\n\tV4 = V0;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tX0 = 0;\n\t// 403 MakeStruct AGGE35B90_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Division(AGGE35B90_0, V4, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = V0;\n\tV5 = V1;\n\tV6 = V2;\n\tV7 = V3;\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tV3 = V15;\n\tX0 = 0;\n\t// 417 MakeStruct AGGE35BB8_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\t// 418 MakeStruct AGGE35BB8_1, typeof(UnityEngine.Vector4), V4, V5, V6, V7\n\tV0 = UnityEngine.Vector4::op_Addition(AGGE35BB8_0, AGGE35BB8_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX1 = X21;\n\tX9 = *([X8+190]);\n\tX2 = *([X8+198]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0124;\n\tgoto L_02CD;\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_02CD;\n\tX23 = 0;\nL_01B6:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = *([X19+48]);\n\tif (TEMP) got\n// ... truncated")]
		public void AddForce(Vector3 force, ForceMode forceMode)
		{
			//IL_00c0: Expected O, but got I
			while (true)
			{
				Vector3 com = default(Vector3);
				float mass = GetMass(out com);
				if (float.IsInfinity(mass))
				{
					break;
				}
				Vector4 vector = force;
				float y = vector.y;
				float z = vector.z;
				float w = vector.w;
				bool flag = forceMode < ForceMode.Acceleration;
				bool flag2 = !flag;
				int num = (int)(forceMode - 5);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25280512 + 1660;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X9_v2 (System.Int32)+forceMode @ X1 (UnityEngine.ForceMode)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v186 @ X8_v7 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0xE35EAC", Offset = "0xE35EAC", Length = "0xA50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = force.y;\n\tv2 = force.z;\n\tgoto L_0028;\n\tv50 = *([1EA87C8]);\n\tv51 = *([v50 @ X8_v8]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, forceMode, methodInfo, v54, v55, v56, v57, v58, force, v0, v2, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([20246BA]) = v66;\nL_0028:\n\tv68 = 0;\n\tv71 = Obi.ObiActor::GetMass(this, &v68 @ stack_-90_v1 (UnityEngine.Vector3));\n\tv74 = System.Single::IsInfinity(v71);\n\tv76 = v74 == 0;\n\tif (v76) goto L_0042;\nL_0041:\n\treturn;\nL_0042:\n\tv120 = forceMode < 5;\n\tv103 = ~v120;\n\tv100 = forceMode - 5;\n\tv94 = v100 == 0;\n\tv121 = ~v94;\n\tv79 = v103 & v121;\n\tif (v79) goto L_0041;\n\tv124 = 0x181C000 + 0x694;\n\tv149 = *([v124 @ X9_v2 (System.Int32)+forceMode @ X1 (UnityEngine.ForceMode)*4]) + v124;\n\t// 83 IndirectJump v149 @ X8_v5, v74 @ X0_v4 (System.Boolean), v74 @ X0_v4 (System.Boolean), &v68 @ stack_-90_v1 (UnityEngine.Vector3), methodInfo @ X2 (Il2CppMethodInfo), v54 @ X3, v55 @ X4, v56 @ X5, v57 @ X6, v58 @ X7, v71 @ V0_v1 (System.Single), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v59 @ V3, v60 @ V4, v61 @ V5, v62 @ V6, v63 @ V7\n\tX22 = *([1EE1550]);\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0060;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0060;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0060:\n\tV1 = stack[18];\n\tV2 = stack[1C];\n\tV0 = V10;\n\tV3 = V11;\n\tX0 = 0;\n\t// 101 MakeStruct AGGE35FA4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Division(AGGE35FA4_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tstack[18] = V1;\n\tstack[1C] = V0;\n\tX8 = *([X19+68]);\n\tstack[14] = V2;\n\tif (TEMP) goto L_0419;\n\tV0 = stack[30];\n\tX23 = 0;\n\tstack[10] = V0;\n\tV0 = stack[34];\n\tV13 = stack[38];\n\tstack[C] = V0;\n\tX24 = *([1F0E218]);\nL_0077:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = *([X19+48]);\n\tif (TEMP) goto L_041B;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_invMasses(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_0419;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_041C;\n\tif (TEMP) goto L_041B;\n\tX9 = *([X0]);\n\tX21 = X23;\n\tTEMPSHIFT = X21 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\n\tV8 = V0;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00AB;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00AB;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00AB:\n\tV1 = stack[18];\n\tV0 = stack[1C];\n\tV2 = stack[14];\n\tV3 = V8;\n\tX0 = 0;\n\t// 176 MakeStruct AGGE3604C_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Division(AGGE3604C_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+48]);\n\tV14 = V0;\n\tV15 = V1;\n\tV8 = V2;\n\tif (TEMP) goto L_041B;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_positions(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_0419;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_041C;\n\tif (TEMP) goto L_041B;\n\tX9 = *([X0]);\n\tTEMPSHIFT = X21 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X24]);\n\tV9 = V0;\n\tV10 = V1;\n\tV11 = V2;\n\tX8 = *([X0+12F]);\n\tV12 = V3;\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00E1;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E1;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E1:\n\tV0 = V9;\n\tV1 = V10;\n\tV2 = V11;\n\tV3 = V12;\n\tX0 = 0;\n\t// 230 MakeStruct AGGE360D4_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Implicit(AGGE360D4_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV4 = stack[C];\n\tV3 = stack[10];\n\tV5 = V13;\n\tX0 = 0;\n\t// 238 MakeStruct AGGE360E4_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 239 MakeStruct AGGE360E4_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::op_Subtraction(AGGE360E4_0, AGGE360E4_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = V0;\n\tV4 = V1;\n\tV5 = V2;\n\tV0 = V14;\n\tV1 = V15;\n\tV2 = V8;\n\tX0 = 0;\n\t// 250 MakeStruct AGGE36104_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 251 MakeStruct AGGE36104_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::Cross(AGGE36104_0, AGGE36104_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+48]);\n\tV8 = V0;\n\tV14 = V1;\n\tV15 = V2;\n\tif (TEMP) goto L_041B;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_externalForces(X0, X1);\n\tX8 = *([X19+68]);\n\tX20 = X0;\n\tif (TEMP) goto L_0419;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_041C;\n\tif (TEMP) goto L_0419;\n\tX9 = *([X20]);\n\tTEMPSHIFT = X21 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX21 = *([X8+20]);\n\tX0 = X20;\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX23 = X23 + 1;\n\tX1 = X21;\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV9 = V0;\n\tV10 = V1;\n\tV11 = V2;\n\tV12 = V3;\n\tX0 = &stack[20];\n\tV3 = 0;\n\tV0 = V8;\n\tV1 = V14;\n\tV2 = V15;\n\tX1 = 0;\n\tstack[20] = 0;\n\tstack[28] = 0;\n\tX0 = 0x158BA74(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV4 = stack[20];\n\tV5 = stack[24];\n\tV6 = stack[28];\n\tV7 = stack[2C];\n\tV0 = V9;\n\tV1 = V10;\n\tV2 = V11;\n\tV3 = V12;\n\tX0 = 0;\n\t// 312 MakeStruct AGGE361AC_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\t// 313 MakeStruct AGGE361AC_1, typeof(UnityEngine.Vector4), V4, V5, V6, V7\n\tV0 = UnityEngine.Vector4::op_Addition(AGGE361AC_0, AGGE361AC_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tX8 = *([X20]);\n\tX0 = X20;\n\tX1 = X21;\n\tX9 = *([X8+190]);\n\tX2 = *([X8+198]);\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+68]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0077;\n\tgoto L_0419;\n\tX22 = *([1EE1550]);\n\tX0 = *([X22]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0155;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0155;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0155:\n\tV1 = stack[18];\n\tV2 = stack[1C];\n\tV0 = V10;\n\tV3 = V11;\n\tX0 = 0;\n\t// 346 MakeStruct AGGE36200_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Division(AGGE36200_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tstack[18] = V1;\n\tstack[1C] = V0;\n\tX8 = *([X19+68]);\n\tstack[14] = V2;\n\tif (TEMP) goto L_0419;\n\tV0 = stack[30];\n\tX23 = 0;\n\tstack[10] = V0;\n\tV0 = stack[34];\n\tV13 = stack[38];\n\tstack[C] = V0;\n\tX24 = *([1F0E218]);\nL_016C:\n\tX8 = *([X8+18]);\n\tC = X23 < X8;\n\tC = ~C;\n\tTEMP1 = X23 - X8;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X8;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tif (TEMPCOND) goto L_0041;\n\tX0 = *([X19+48]);\n\tif (TEMP) goto L_041B;\n\tX1 = 0;\n\tX0 = Obi.ObiSolver::get_invMasses(X0, X1);\n\tX8 = *([X19+68]);\n\tif (TEMP) goto L_0419;\n\tX9 = *([X8+18]);\n\tC = X23 < X9;\n\tC = ~C;\n\tTEMP1 = X23 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X23 ^ X9;\n\tTEMP3 = X23 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_041C;\n\tif (TEMP) goto L_041B;\n\tX9 = *([X0]);\n\tX21 = X23;\n\tTEMPSHIFT = X21 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX1 = *([X8+20]);\n\tX8 = *([X9+180]);\n\tX2 = *([X9+188]);\n\tX8(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\n\tV8 = V0;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01A0;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A0;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A0:\n\tV1 = stack[18];\n\tV0 = stack[1C];\n\tV2 = stack[14];\n\tV3 = V8;\n\tX0 = 0;\n\t// 421 MakeStruct AGGE362A8_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\tV0 = UnityEngine.Vector3::op_Division(AGGE362A8_0, V3, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV0 = UnityEngine.Time::get_fixedDeltaTime(X0);\n\tV3 = V0;\n\tV0 = V8;\n\n// ... truncated")]
		public void AddTorque(Vector3 force, ForceMode forceMode)
		{
			//IL_00a1: Expected O, but got I
			float y = force.y;
			float z = force.z;
			while (true)
			{
				Vector3 com = default(Vector3);
				float mass = GetMass(out com);
				if (float.IsInfinity(mass))
				{
					break;
				}
				bool flag = forceMode < ForceMode.Acceleration;
				bool flag2 = !flag;
				int num = (int)(forceMode - 5);
				bool flag3 = num == 0;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					break;
				}
				int num2 = 25280512 + 1684;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X9_v2 (System.Int32)+forceMode @ X1 (UnityEngine.ForceMode)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v149 @ X8_v5 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0xE368FC", Offset = "0xE368FC", Length = "0x8DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv52 = *([1EF1F30]);\n\tv53 = *([v52 @ X8_v108]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, bp, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([20246BB]) = v71;\nL_002B:\n\tv80 = Obi.ObiActor::get_actorLocalToSolverMatrix(this);\n\tv81 = v80.m00;\n\tv107 = 0x10C1A04(&v81 @ stack_-120_v1 (System.Single), 0, v211, v132, v57, v58, v59, v60, v80.m03, v80.m02, v80.m01, v80.m00, v187, v182, v177, v172);\n\tv733 = this.solverIndices;\nL_005C:\n\tv285 = v540 >= v733.Length;\n\tif (v285) goto L_03B9;\n\tv941 = v540 < v733.Length;\n\tv516 = ~v941;\n\tif (v516) goto L_03E8;\n\tv1007 = bp.positions;\n\tv1008 = bp.positions == 0;\n\tif (v1008) goto L_010F;\n\tv286 = v540 >= v1007.Length;\n\tif (v286) goto L_010F;\n\tv666 = Obi.ObiSolver::get_startPositions(this.m_Solver);\n\tv667 = Obi.ObiSolver::get_prevPositions(this.m_Solver);\n\tv668 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv736 = bp.positions;\n\tv1266 = v540 < v736.Length;\n\tv518 = ~v1266;\n\tif (v518) goto L_03E8;\n\tv1304 = v540 * 0xC;\n\tv1305 = v736 + v1304;\n\tv1310 = 0x10C27FC(&v81 @ stack_-120_v1 (System.Single), 0, v211, *([v1263 @ X8_v50 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v57, v58, v59, v60, *([v1305 @ X8_v96+20]), v736[v540 @ X25_v5 (System.Int32)].y, v736[v540 @ X25_v5 (System.Int32)].z, v617, *([v749 @ X8_v89+20]), v748[v540 @ X25_v5 (System.Int32)].y, v748[v540 @ X25_v5 (System.Int32)].z, v748[v540 @ X25_v5 (System.Int32)].w);\n\tgoto L_00B8;\n\tv1389 = *([v1351 @ X0_v107+E0]);\n\tv1390 = v1389 == 0;\n\tv1391 = ~v1390;\n\tif (v1391) goto L_00B8;\n\tv1393 = \"il2cpp_codegen_runtime_class_init\"(v1351, v548, v194, v131, v57, v58, v59, v60, v1306, v1307, v1308, v597, v184, v179, v174, v169);\nL_00B8:\n\t// 184 MakeStruct v221 @ AGGE36A90_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1305 @ X8_v96+20], v736[v540 @ X25_v5 (System.Int32)].y (System.Single), v736[v540 @ X25_v5 (System.Int32)].z (System.Single)\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v221);\n\tv670 = Obi.ObiNativeVector4List::set_Item(v668, v733[v540 @ X25_v5 (System.Int32)], Vector4_arg);\n\tv671 = Obi.ObiNativeVector4List::set_Item(v667, v733[v540 @ X25_v5 (System.Int32)], Vector4_arg);\n\tv926 = *([v666 @ X0_v100 (Obi.ObiNativeVector4List)]);\n\tv1439 = Obi.ObiNativeVector4List::set_Item(v666, v733[v540 @ X25_v5 (System.Int32)], Vector4_arg);\n\tv672 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv740 = bp.positions;\n\tv1446 = v540 < v740.Length;\n\tv519 = ~v1446;\n\tif (v519) goto L_03E8;\n\tv1448 = v540 * 0xC;\n\tv741 = v740 + v1448;\n\tv1453 = 0x10C27FC(&v81 @ stack_-120_v1 (System.Single), 0, *([v926 @ X8_v101 (Il2CppClass<Obi.ObiNativeVector4List>)+198]), *([v1263 @ X8_v50 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v57, v58, v59, v60, *([v741 @ X8_v103+20]), v740[v540 @ X25_v5 (System.Int32)].y, v740[v540 @ X25_v5 (System.Int32)].z, Vector4_arg.w, *([v749 @ X8_v89+20]), v748[v540 @ X25_v5 (System.Int32)].y, v748[v540 @ X25_v5 (System.Int32)].z, v748[v540 @ X25_v5 (System.Int32)].w);\n\t// 258 MakeStruct v191 @ AGGE36B60_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v741 @ X8_v103+20], v740[v540 @ X25_v5 (System.Int32)].y (System.Single), v740[v540 @ X25_v5 (System.Int32)].z (System.Single)\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v191);\n\tv617 = Vector4_arg.w;\n\tv1026 = *([v672 @ X0_v117 (Obi.ObiNativeVector4List)]);\n\tv211 = *([v1026 @ X8_v104 (Il2CppClass<Obi.ObiNativeVector4List>)+198]);\n\tv1023 = Obi.ObiNativeVector4List::set_Item(v672, v733[v540 @ X25_v5 (System.Int32)], Vector4_arg);\nL_010F:\n\tv1027 = bp.orientations;\n\tv1028 = bp.orientations == 0;\n\tif (v1028) goto L_01B6;\n\tv287 = v540 >= v1027.Length;\n\tif (v287) goto L_01B6;\n\tv674 = Obi.ObiSolver::get_startOrientations(this.m_Solver);\n\tv675 = Obi.ObiSolver::get_prevOrientations(this.m_Solver);\n\tv676 = Obi.ObiSolver::get_orientations(this.m_Solver);\n\tv744 = bp.orientations;\n\tv1311 = v540 < v744.Length;\n\tv521 = ~v1311;\n\tif (v521) goto L_03E8;\n\tv333 = v540 << 4;\n\tv1360 = v744 + v333;\n\tgoto L_015B;\n\tv1398 = *([v1365 @ X0_v84+E0]);\n\tv1399 = v1398 == 0;\n\tv1400 = ~v1399;\n\tif (v1400) goto L_015B;\n\tv1402 = \"il2cpp_codegen_runtime_class_init\"(v1365, v555, v198, v131, v57, v58, v59, v60, v625, v649, v581, v603, v184, v179, v174, v169);\nL_015B:\n\t// 347 MakeStruct v166 @ AGGE36C38_0_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v80.m03 (System.Single), v80.m02 (System.Single), v80.m01 (System.Single), v80.m00 (System.Single)\n\t// 348 MakeStruct v161 @ AGGE36C38_1_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v1360 @ X8_v83+20], v744[v540 @ X25_v5 (System.Int32)].y (System.Single), v744[v540 @ X25_v5 (System.Int32)].z (System.Single), v744[v540 @ X25_v5 (System.Int32)].w (System.Single)\n\tQuaternion_arg = UnityEngine.Quaternion::op_Multiply(v166, v161);\n\tv678 = Obi.ObiNativeQuaternionList::set_Item(v676, v733[v540 @ X25_v5 (System.Int32)], Quaternion_arg);\n\tv679 = Obi.ObiNativeQuaternionList::set_Item(v675, v733[v540 @ X25_v5 (System.Int32)], Quaternion_arg);\n\tv1441 = Obi.ObiNativeQuaternionList::set_Item(v674, v733[v540 @ X25_v5 (System.Int32)], Quaternion_arg);\n\tv680 = Obi.ObiSolver::get_renderableOrientations(this.m_Solver);\n\tv748 = bp.orientations;\n\tv1447 = v540 < v748.Length;\n\tv522 = ~v1447;\n\tif (v522) goto L_03E8;\n\tv334 = v540 << 4;\n\tv749 = v748 + v334;\n\t// 424 MakeStruct v156 @ AGGE36D0C_0_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v80.m03 (System.Single), v80.m02 (System.Single), v80.m01 (System.Single), v80.m00 (System.Single)\n\t// 425 MakeStruct v151 @ AGGE36D0C_1_v6 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v749 @ X8_v89+20], v748[v540 @ X25_v5 (System.Int32)].y (System.Single), v748[v540 @ X25_v5 (System.Int32)].z (System.Single), v748[v540 @ X25_v5 (System.Int32)].w (System.Single)\n\tQuaternion_arg = UnityEngine.Quaternion::op_Multiply(v156, v151);\n\tv617 = Quaternion_arg.w;\n\tv1125 = *([v680 @ X0_v94 (Obi.ObiNativeQuaternionList)]);\n\tv211 = *([v1125 @ X8_v90 (Il2CppClass<Obi.ObiNativeQuaternionList>)+198]);\n\tv1122 = Obi.ObiNativeQuaternionList::set_Item(v680, v733[v540 @ X25_v5 (System.Int32)], Quaternion_arg);\nL_01B6:\n\tv1126 = bp.velocities;\n\tv1127 = bp.velocities == 0;\n\tif (v1127) goto L_01FF;\n\tv288 = v540 >= v1126.Length;\n\tif (v288) goto L_01FF;\n\tv682 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv750 = bp.velocities;\n\tv1216 = v540 < v750.Length;\n\tv524 = ~v1216;\n\tif (v524) goto L_03E8;\n\tv1238 = v540 * 0xC;\n\tv1239 = v750 + v1238;\n\tv1244 = 0x10C2868(&v81 @ stack_-120_v1 (System.Single), 0, v211, *([v1263 @ X8_v50 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v57, v58, v59, v60, *([v1239 @ X8_v74+20]), v750[v540 @ X25_v5 (System.Int32)].y, v750[v540 @ X25_v5 (System.Int32)].z, v617, *([v749 @ X8_v89+20]), v748[v540 @ X25_v5 (System.Int32)].y, v748[v540 @ X25_v5 (System.Int32)].z, v748[v540 @ X25_v5 (System.Int32)].w);\n\tgoto L_01F2;\n\tv1312 = *([v1267 @ X0_v72+E0]);\n\tv1313 = v1312 == 0;\n\tv1314 = ~v1313;\n\tif (v1314) goto L_01F2;\n\tv1316 = \"il2cpp_codegen_runtime_class_init\"(v1267, v560, v202, v131, v57, v58, v59, v60, v1240, v1241, v1242, v609, v187, v182, v177, v172);\nL_01F2:\n\t// 498 MakeStruct v146 @ AGGE36DB0_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1239 @ X8_v74+20], v750[v540 @ X25_v5 (System.Int32)].y (System.Single), v750[v540 @ X25_v5 (System.Int32)].z (System.Single)\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v146);\n\tv617 = Vector4_arg.w;\n\tv1145 = *([v682 @ X0_v69 (Obi.ObiNativeVector4List)]);\n\tv211 = *([v1145 @ X8_v77 (Il2CppClass<Obi.ObiNativeVector4List>)+198]);\n\tv1142 = Obi.ObiNativeVector4List::set_Item(v682, v733[v540 @ X25_v5 (System.Int32)], Vector4_arg);\nL_01FF:\n\tv1146 = bp.angularVelocities;\n\tv1147 = bp.angularVelocities == 0;\n\tif (v1147) goto L_0248;\n\tv289 = v540 >= v1146.Length;\n\tif (v289) goto L_0248;\n\tv684 = Obi.ObiSolver::get_angularVelocities(this.m_Solver);\n\tv752 = bp.angularVelocities;\n\tv1245 = v540 < v752.Length;\n\tv526 = ~v1245;\n\tif (v526) goto L_03E8;\n\tv1271 = v540 * 0xC;\n\tv1272 = v752 + v1271;\n\tv1277 = 0x10C2868(&v81 @ stack_-120_v1 (System.Single), 0, v211, *([v1263 @ X8_v50 (Il2CppClass<Obi.ObiNativeIntList>)+198]), v57, v58, v59, v\n// ... truncated")]
		private void LoadBlueprintParticles(ObiActorBlueprint bp)
		{
			//IL_06d8: Expected O, but got I
			//IL_0127: Expected O, but got I
			//IL_080f: Expected O, but got I
			//IL_06fc: Expected F4, but got I
			//IL_03bd: Expected O, but got I
			//IL_014b: Expected F4, but got I
			//IL_0932: Expected I, but got O
			//IL_0833: Expected F4, but got I
			//IL_0759: Expected I, but got O
			//IL_041f: Expected F4, but got I
			//IL_09dd: Expected I, but got O
			//IL_0890: Expected I, but got O
			//IL_0a9c: Expected O, but got I
			//IL_01d9: Expected I, but got O
			//IL_0ab6: Expected F4, but got I
			//IL_0c78: Expected I, but got O
			//IL_0c94: Expected O, but got I
			//IL_0ccf: Expected F4, but got I
			//IL_0bde: Expected I, but got O
			//IL_0b13: Expected I, but got O
			//IL_0db2: Expected I, but got O
			//IL_0dce: Expected O, but got I
			//IL_0e09: Expected F4, but got I
			//IL_025e: Expected O, but got I
			//IL_027d: Expected F4, but got I
			//IL_0549: Expected O, but got I
			//IL_05a6: Expected F4, but got I
			//IL_0f32: Expected O, but got I
			//IL_0f57: Expected O, but got I
			//IL_0622: Expected I, but got O
			//IL_02df: Expected I, but got O
			Matrix4x4 matrix4x = actorLocalToSolverMatrix;
			float m = matrix4x.m00;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
			int[] array = solverIndices;
			int num = 0;
			float m2 = matrix4x.m00;
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			Quaternion quaternion = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			Quaternion quaternion3 = default(Quaternion);
			Quaternion quaternion4 = default(Quaternion);
			Vector3 vector3 = default(Vector3);
			Vector3 vector4 = default(Vector3);
			Vector3 vector5 = default(Vector3);
			Vector4 value8 = default(Vector4);
			Quaternion value9 = default(Quaternion);
			int num14 = default(int);
			while (true)
			{
				if (num < array.Length)
				{
					if (num >= array.Length)
					{
						break;
					}
					Vector3[] positions = bp.positions;
					if (bp.positions != null && num < positions.Length)
					{
						ObiNativeVector4List startPositions = solver.startPositions;
						ObiNativeVector4List prevPositions = solver.prevPositions;
						ObiNativeVector4List positions2 = solver.positions;
						Vector3[] positions3 = bp.positions;
						if (num >= positions3.Length)
						{
							break;
						}
						int num2 = num * 12;
						object obj = (long)(IntPtr)positions3 + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1305 @ X8_v96+20]");
						vector.x = 0f;
						vector.y = positions3[num].y;
						vector.z = positions3[num].z;
						Vector4 value = vector;
						positions2.set_Item(array[num], value);
						prevPositions.set_Item(array[num], value);
						IntPtr intPtr = (IntPtr)startPositions;
						startPositions.set_Item(array[num], value);
						ObiNativeVector4List renderablePositions = solver.renderablePositions;
						Vector3[] positions4 = bp.positions;
						if (num >= positions4.Length)
						{
							break;
						}
						int num3 = num * 12;
						object obj2 = (long)(IntPtr)positions4 + (long)num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ X8_v103+20]");
						vector2.x = 0f;
						vector2.y = positions4[num].y;
						vector2.z = positions4[num].z;
						Vector4 value2 = vector2;
						m2 = value2.w;
						IntPtr intPtr2 = (IntPtr)renderablePositions;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1026 @ X8_v104 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						renderablePositions.set_Item(array[num], value2);
					}
					Quaternion[] orientations = bp.orientations;
					if (bp.orientations != null && num < orientations.Length)
					{
						ObiNativeQuaternionList startOrientations = solver.startOrientations;
						ObiNativeQuaternionList prevOrientations = solver.prevOrientations;
						ObiNativeQuaternionList orientations2 = solver.orientations;
						Quaternion[] orientations3 = bp.orientations;
						if (num >= orientations3.Length)
						{
							break;
						}
						int num4 = num << 4;
						object obj3 = (long)(IntPtr)orientations3 + (long)num4;
						quaternion.x = matrix4x.m03;
						quaternion.y = matrix4x.m02;
						quaternion.z = matrix4x.m01;
						quaternion.w = matrix4x.m00;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1360 @ X8_v83+20]");
						quaternion2.x = 0f;
						quaternion2.y = orientations3[num].y;
						quaternion2.z = orientations3[num].z;
						quaternion2.w = orientations3[num].w;
						Quaternion value3 = quaternion * quaternion2;
						orientations2.set_Item(array[num], value3);
						prevOrientations.set_Item(array[num], value3);
						startOrientations.set_Item(array[num], value3);
						ObiNativeQuaternionList renderableOrientations = solver.renderableOrientations;
						Quaternion[] orientations4 = bp.orientations;
						if (num >= orientations4.Length)
						{
							break;
						}
						int num5 = num << 4;
						object obj4 = (long)(IntPtr)orientations4 + (long)num5;
						quaternion3.x = matrix4x.m03;
						quaternion3.y = matrix4x.m02;
						quaternion3.z = matrix4x.m01;
						quaternion3.w = matrix4x.m00;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ X8_v89+20]");
						quaternion4.x = 0f;
						quaternion4.y = orientations4[num].y;
						quaternion4.z = orientations4[num].z;
						quaternion4.w = orientations4[num].w;
						Quaternion value4 = quaternion3 * quaternion4;
						m2 = value4.w;
						IntPtr intPtr4 = (IntPtr)renderableOrientations;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1125 @ X8_v90 (Il2CppClass<Obi.ObiNativeQuaternionList>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						renderableOrientations.set_Item(array[num], value4);
					}
					Vector3[] velocities = bp.velocities;
					if (bp.velocities != null && num < velocities.Length)
					{
						ObiNativeVector4List velocities2 = solver.velocities;
						Vector3[] velocities3 = bp.velocities;
						if (num >= velocities3.Length)
						{
							break;
						}
						int num6 = num * 12;
						object obj5 = (long)(IntPtr)velocities3 + (long)num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ X8_v74+20]");
						vector3.x = 0f;
						vector3.y = velocities3[num].y;
						vector3.z = velocities3[num].z;
						Vector4 value5 = vector3;
						m2 = value5.w;
						IntPtr intPtr5 = (IntPtr)velocities2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1145 @ X8_v77 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						velocities2.set_Item(array[num], value5);
					}
					Vector3[] angularVelocities = bp.angularVelocities;
					if (bp.angularVelocities != null && num < angularVelocities.Length)
					{
						ObiNativeVector4List angularVelocities2 = solver.angularVelocities;
						Vector3[] angularVelocities3 = bp.angularVelocities;
						if (num >= angularVelocities3.Length)
						{
							break;
						}
						int num7 = num * 12;
						object obj6 = (long)(IntPtr)angularVelocities3 + (long)num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1272 @ X8_v67+20]");
						vector4.x = 0f;
						vector4.y = angularVelocities3[num].y;
						vector4.z = angularVelocities3[num].z;
						Vector4 value6 = vector4;
						m2 = value6.w;
						IntPtr intPtr6 = (IntPtr)angularVelocities2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1166 @ X8_v70 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						angularVelocities2.set_Item(array[num], value6);
					}
					float[] invMasses = bp.invMasses;
					if (bp.invMasses != null && num < invMasses.Length)
					{
						ObiNativeFloatList invMasses2 = solver.invMasses;
						float[] invMasses3 = bp.invMasses;
						if (num >= invMasses3.Length)
						{
							break;
						}
						IntPtr intPtr7 = (IntPtr)invMasses2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1173 @ X9_v36 (Il2CppClass<Obi.ObiNativeFloatList>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						invMasses2.set_Item(array[num], invMasses3[num]);
					}
					float[] invRotationalMasses = bp.invRotationalMasses;
					if (bp.invRotationalMasses != null && num < invRotationalMasses.Length)
					{
						ObiNativeFloatList invRotationalMasses2 = solver.invRotationalMasses;
						float[] invRotationalMasses3 = bp.invRotationalMasses;
						if (num >= invRotationalMasses3.Length)
						{
							break;
						}
						IntPtr intPtr8 = (IntPtr)invRotationalMasses2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1196 @ X9_v34 (Il2CppClass<Obi.ObiNativeFloatList>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						invRotationalMasses2.set_Item(array[num], invRotationalMasses3[num]);
					}
					Vector3[] principalRadii = bp.principalRadii;
					if (bp.principalRadii != null && num < principalRadii.Length)
					{
						ObiNativeVector4List principalRadii2 = solver.principalRadii;
						Vector3[] principalRadii3 = bp.principalRadii;
						if (num >= principalRadii3.Length)
						{
							break;
						}
						int num8 = num * 12;
						object obj7 = (long)(IntPtr)principalRadii3 + (long)num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1412 @ X8_v53+20]");
						vector5.x = 0f;
						vector5.y = principalRadii3[num].y;
						vector5.z = principalRadii3[num].z;
						Vector4 value7 = vector5;
						m2 = value7.w;
						IntPtr intPtr9 = (IntPtr)principalRadii2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1234 @ X8_v55 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						principalRadii2.set_Item(array[num], value7);
					}
					int[] phases = bp.phases;
					if (bp.phases != null && num < phases.Length)
					{
						ObiNativeIntList phases2 = solver.phases;
						int[] phases3 = bp.phases;
						if (num >= phases3.Length)
						{
							break;
						}
						int num9 = Oni.MakePhase(phases3[num], default(Oni.ParticleFlags));
						IntPtr intPtr10 = (IntPtr)phases2;
						phases2.set_Item(array[num], num9);
						IntPtr intPtr3 = (IntPtr)num9;
					}
					Vector4[] restPositions = bp.restPositions;
					if (bp.restPositions != null && num < restPositions.Length)
					{
						ObiNativeVector4List restPositions2 = solver.restPositions;
						Vector4[] restPositions3 = bp.restPositions;
						if (num >= restPositions3.Length)
						{
							break;
						}
						IntPtr intPtr11 = (IntPtr)restPositions2;
						int num10 = num << 4;
						object obj8 = (long)(IntPtr)restPositions3 + (long)num10;
						m2 = restPositions3[num].w;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1282 @ X9_v27 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1436 @ X8_v45+20]");
						value8.x = 0f;
						value8.y = restPositions3[num].y;
						value8.z = restPositions3[num].z;
						value8.w = restPositions3[num].w;
						restPositions2.set_Item(array[num], value8);
					}
					Quaternion[] restOrientations = bp.restOrientations;
					if (bp.restOrientations != null && num < restOrientations.Length)
					{
						ObiNativeQuaternionList restOrientations2 = solver.restOrientations;
						Quaternion[] restOrientations3 = bp.restOrientations;
						if (num >= restOrientations3.Length)
						{
							break;
						}
						IntPtr intPtr12 = (IntPtr)restOrientations2;
						int num11 = num << 4;
						object obj9 = (long)(IntPtr)restOrientations3 + (long)num11;
						m2 = restOrientations3[num].w;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1329 @ X9_v25 (Il2CppClass<Obi.ObiNativeQuaternionList>)+198]");
						IntPtr intPtr3 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1442 @ X8_v41+20]");
						value9.x = 0f;
						value9.y = restOrientations3[num].y;
						value9.z = restOrientations3[num].z;
						value9.w = restOrientations3[num].w;
						restOrientations2.set_Item(array[num], value9);
					}
					Color[] colors = bp.colors;
					if (bp.colors != null && num < colors.Length)
					{
						Color[] colors2 = solver.colors;
						Color[] colors3 = bp.colors;
						if (num >= colors3.Length || array[num] >= colors2.Length)
						{
							break;
						}
						int num12 = num << 4;
						object obj10 = (long)(IntPtr)colors3 + (long)num12;
						int num13 = array[num] << 4;
						object obj11 = (long)(IntPtr)colors2 + (long)num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1445 @ X8_v37+20]");
						_ = 0;
						colors2[num14].g = colors3[num].g;
						colors2[num14].b = colors3[num].b;
						colors2[num14].a = colors3[num].a;
					}
					array = solverIndices;
					num++;
					if (solverIndices == null)
					{
						NullReferenceException ex = new NullReferenceException();
						break;
					}
					continue;
				}
				ObiActorBlueprint obiActorBlueprint = blueprint;
				ObiSolver obiSolver = solver;
				m_ActiveParticleCount = obiActorBlueprint.activeParticleCount;
				obiSolver.activeParticleCountChanged = true;
				solver.PushActiveParticles();
				ObiSolver obiSolver2 = solver;
				Oni.RecalculateInertiaTensors(obiSolver2.OniSolver);
				PushCollisionMaterial();
				return;
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0xE371D8", Offset = "0xE371D8", Length = "0x504")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1EFBBB8]);\n\tv35 = *([v34 @ X8_v54]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, bp, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20246BC]) = v53;\nL_0020:\n\t// 32 NewArr v59 @ X0_v3 (Obi.IObiConstraints[]), typeof(Obi.IObiConstraints[]), 17\n\tthis.m_Constraints = v59;\n\tv62 = Obi.ObiActorBlueprint::GetConstraints(bp);\n\tgoto L_0056;\n\tv219 = *([v166 @ X8_v15+B0]);\n\tv220 = 0;\n\tv221 = v219 + 8;\n\tv223 = *([v259 @ X11_v58-8]);\n\tv265 = v223 == v169;\n\tif (v265) goto L_004F;\n\tv245 = v260 + 1;\n\tv280 = v245 < v168;\n\tv241 = ~v280;\n\tv243 = v259 + 0x10;\n\tv225 = ~v241;\n\tif (v225) goto L_FFFFFFFF;\n\tv246 = v134;\n\tv247 = 0;\n\tv248 = 0x8909C4(v246, v169, v247, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0056;\nL_004F:\n\tv281 = *([v259 @ X11_v58]);\n\tv282 = v281 << 4;\n\tv283 = v166 + v282;\n\tv284 = v283 + 0x130;\nL_0056:\n\tv211 = System.Collections.Generic.IEnumerable`1<Obi.IObiConstraints>::GetEnumerator(v62);\n\tv213 = v211 == 0;\n\tif (v213) goto L_01AF;\nL_0066:\n\tgoto L_008D;\n\tv472 = *([v420 @ X8_v19+B0]);\n\tv473 = 0;\n\tv474 = v472 + 8;\n\tv476 = *([v593 @ X11_v53-8]);\n\tv599 = v476 == v421;\n\tif (v599) goto L_0086;\n\tv498 = v594 + 1;\n\tv635 = v498 < v422;\n\tv494 = ~v635;\n\tv496 = v593 + 0x10;\n\tv478 = ~v494;\n\tif (v478) goto L_FFFFFFFF;\n\tv499 = v128;\n\tv500 = 0;\n\tv501 = 0x8909C4(v499, v421, v500, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_008D;\nL_0086:\n\tv636 = *([v593 @ X11_v53]);\n\tv637 = v636 << 4;\n\tv638 = v420 + v637;\n\tv639 = v638 + 0x130;\nL_008D:\n\tv542 = System.Collections.IEnumerator::MoveNext(v211);\n\tv644 = v542 == 0;\n\tif (v644) goto L_019B;\n\tgoto L_00BC;\n\tv680 = *([v667 @ X8_v22+B0]);\n\tv681 = 0;\n\tv682 = v680 + 8;\n\tv684 = *([v720 @ X11_v48-8]);\n\tv726 = v684 == v668;\n\tif (v726) goto L_00B5;\n\tv706 = v721 + 1;\n\tv731 = v706 < v669;\n\tv702 = ~v731;\n\tv704 = v720 + 0x10;\n\tv686 = ~v702;\n\tif (v686) goto L_FFFFFFFF;\n\tv707 = v128;\n\tv708 = 0;\n\tv709 = 0x8909C4(v707, v668, v708, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00BC;\nL_00B5:\n\tv732 = *([v720 @ X11_v48]);\n\tv733 = v732 << 4;\n\tv734 = v667 + v733;\n\tv735 = v734 + 0x130;\nL_00BC:\n\tv756 = System.Collections.Generic.IEnumerator`1<Obi.IObiConstraints>::get_Current(v211);\n\tgoto L_00ED;\n\tv765 = *([v759 @ X8_v29+B0]);\n\tv766 = 0;\n\tv767 = v765 + 8;\n\tv769 = *([v846 @ X11_v43-8]);\n\tv852 = v769 == v760;\n\tif (v852) goto L_00E4;\n\tv791 = v847 + 1;\n\tv901 = v791 < v761;\n\tv787 = ~v901;\n\tv789 = v846 + 0x10;\n\tv771 = ~v787;\n\tif (v771) goto L_FFFFFFFF;\n\tv792 = 0xD;\n\tv793 = v757;\n\tv794 = 0x8909C4(v793, v760, v792, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00ED;\nL_00E4:\n\tv902 = *([v846 @ X11_v43]);\n\tv903 = v902 + 0xD;\n\tv904 = v903 << 4;\n\tv905 = v759 + v904;\n\tv906 = v905 + 0x130;\nL_00ED:\n\tv828 = Obi.IObiConstraints::Clone(v756, this);\n\tv939 = *([v828 @ X0_v52 (Obi.IObiConstraints)]);\n\tv942 = *([v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v942) goto L_0113;\n\tv999 = *([v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_00FE:\n\tv1005 = *([v999 @ X11_v38-8]) == Obi.IObiConstraints;\n\tif (v1005) goto L_0116;\n\tv1000 = v1000 + 1;\n\tv1010 = v1000 < *([v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv968 = ~v1010;\n\tv999 = v999 + 0x10;\n\tv952 = ~v968;\n\tif (v952) goto L_00FE;\nL_0113:\n\tv59 = 0x8909C4(v828, Obi.IObiConstraints, 1, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_011D;\nL_0116:\n\tv1012 = *([v999 @ X11_v38]) + 1;\n\tv1013 = v1012 << 4;\n\tv1014 = v939 + v1013;\n\tv59 = v1014 + 0x130;\nL_011D:\n\t*([v59 @ X0_v3 (Obi.IObiConstraints[])])(v59, v828, *([v59 @ X0_v3 (Obi.IObiConstraints[])+8]), v369, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv416 = v59 & 0xFF00000000;\n\tv413 = v416 == 0;\n\tif (v413) goto L_0066;\n\tv1020 = *([v828 @ X0_v52 (Obi.IObiConstraints)]);\n\tv363 = this.m_Constraints;\n\tv1023 = *([v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v1023) goto L_0145;\n\tv1064 = *([v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_0130:\n\tv1070 = *([v1064 @ X11_v33-8]) == Obi.IObiConstraints;\n\tif (v1070) goto L_0148;\n\tv1065 = v1065 + 1;\n\tv1075 = v1065 < *([v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv1046 = ~v1075;\n\tv1064 = v1064 + 0x10;\n\tv1030 = ~v1046;\n\tif (v1030) goto L_0130;\nL_0145:\n\tv59 = 0x8909C4(v828, Obi.IObiConstraints, 1, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_014F;\nL_0148:\n\tv1077 = *([v1064 @ X11_v33]) + 1;\n\tv1078 = v1077 << 4;\n\tv1079 = v1020 + v1078;\n\tv59 = v1079 + 0x130;\nL_014F:\n\t*([v59 @ X0_v3 (Obi.IObiConstraints[])])(v1085, v828, *([v59 @ X0_v3 (Obi.IObiConstraints[])+8]), v369, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv893 = System.Nullable`1<Oni+ConstraintType>::get_Value(&v1085 @ X0_v58 (System.Nullable`1<Oni+ConstraintType>));\n\t// 346 IsInst v59 @ X0_v3 (Obi.IObiConstraints[]), typeof(Obi.IObiConstraints), v828 @ X0_v52 (Obi.IObiConstraints)\n\tv934 = v59 == 0;\n\tif (v934) goto L_01A5;\n\tv1088 = v893 < v363.Length;\n\tv984 = ~v1088;\n\tif (v984) goto L_01A9;\n\tv363[v893 @ X0_v60 (Oni+ConstraintType)] = v828;\n\tv1091 = *([v828 @ X0_v52 (Obi.IObiConstraints)]);\n\tv414 = *([v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v414) goto L_018D;\n\tv1134 = *([v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_0178:\n\tv1140 = *([v1134 @ X11_v28-8]) == Obi.IObiConstraints;\n\tif (v1140) goto L_0190;\n\tv1135 = v1135 + 1;\n\tv1145 = v1135 < *([v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv1116 = ~v1145;\n\tv1134 = v1134 + 0x10;\n\tv1100 = ~v1116;\n\tif (v1100) goto L_0178;\nL_018D:\n\tv59 = 0x8909C4(v828, Obi.IObiConstraints, 7, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0197;\nL_0190:\n\tv1147 = *([v1134 @ X11_v28]) + 7;\n\tv1148 = v1147 << 4;\n\tv1149 = v1091 + v1148;\n\tv59 = v1149 + 0x130;\nL_0197:\n\t*([v59 @ X0_v3 (Obi.IObiConstraints[])])(v59, v828, *([v59 @ X0_v3 (Obi.IObiConstraints[])+8]), v369, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0066;\nL_019B:\n\tv671 = v211 == 0;\n\tv544 = ~v671;\n\tif (v544) goto L_01D2;\n\tgoto L_01FA;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv900 = new System.NullReferenceException();\nL_01A5:\n\tv938 = new System.ArrayTypeMismatchException();\n\tthrow v938;\nL_01A9:\n\tv988 = new System.IndexOutOfRangeException();\n\tthrow v988;\n\tv164 = new System.NullReferenceException();\nL_01AF:\n\tv218 = new System.NullReferenceException();\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\n\tgoto L_01C4;\nL_01C4:\n\tv279 = 0 != 1;\n\tif (v279) goto L_0215;\n\tv59 = 0x6D2BC0(v218, 0, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv545 = *([v59 @ X0_v3 (Obi.IObiConstraints[])]);\n\tv59 = 0x6D2490(v59, 0, 0, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv425 = v211 == 0;\n\tif (v425) goto L_01FA;\nL_01D2:\n\tgoto L_01F9;\n\tv604 = *([v553 @ X8_v9+B0]);\n\tv605 = 0;\n\tv606 = v604 + 8;\n\tv608 = *([v655 @ X11_v9-8]);\n\tv661 = v608 == v556;\n\tif (v661) goto L_01F2;\n\tv630 = v656 + 1;\n\tv672 = v630 < v555;\n\tv626 = ~v672;\n\tv628 = v655 + 0x10;\n\tv610 = ~v626;\n\tif (v610) goto L_FFFFFFFF;\n\tv631 = v547;\n\tv632 = 0;\n\tv633 = 0x8909C4(v631, v556, v632, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01F9;\nL_01F2:\n\tv673 = *([v655 @ X11_v9]);\n\tv674 = v673 << 4;\n\tv675 = v553 + v674;\n\tv676 = v675 + 0x130;\nL_01F9:\n\tSystem.IDisposable::Dispose(v547);\nL_01FA:\n\tv582 = v346 + 1;\n\tv320 = v582 == 0;\n\tv310 = ~v320;\n\tif (v310) goto L_0210;\n\tv634 = v340 == 0;\n\tv338 = ~v634;\n\tif (v338) goto L_0214;\nL_0210:\n\treturn;\nL_0214:\n\tv336 = new System.TypeLoadException();\nL_0215:\n\tv59 = 0x6D2380(v59, v329, v307, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\treturn;\n// 299 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadBlueprintConstraints(ObiActorBlueprint bp)
		{
			//IL_0539: Expected I, but got O
			//IL_0458: Expected I4, but got O
			//IL_0487: Expected I4, but got O
			//IL_04da: Expected I, but got O
			//IL_002e: Expected I, but got O
			//IL_05ee: Expected I4, but got I8
			//IL_0069: Expected O, but got I
			//IL_0136: Expected I, but got O
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f4: Expected O, but got Unknown
			//IL_0111: Expected O, but got I
			//IL_0120: Expected O, but got I
			//IL_00b5: Expected O, but got I
			//IL_017b: Expected O, but got I
			//IL_0201: Unknown result type (might be due to invalid IL or missing references)
			//IL_0206: Expected O, but got Unknown
			//IL_0223: Expected O, but got I
			//IL_0232: Expected O, but got I
			//IL_01c7: Expected O, but got I
			//IL_02a3: Expected I, but got O
			//IL_02de: Expected O, but got I
			//IL_0364: Unknown result type (might be due to invalid IL or missing references)
			//IL_0369: Expected O, but got Unknown
			//IL_0386: Expected O, but got I
			//IL_0395: Expected O, but got I
			//IL_032a: Expected O, but got I
			IObiConstraints[] array = (m_Constraints = new IObiConstraints[17]);
			IEnumerable<IObiConstraints> constraints = bp.GetConstraints();
			IEnumerator<IObiConstraints> enumerator = constraints.GetEnumerator();
			bool flag = enumerator == null;
			IntPtr intPtr = (IntPtr)null;
			int num = 0;
			IEnumerator<IObiConstraints> enumerator2 = enumerator;
			int num2;
			int num3;
			int num4;
			int num5;
			if (flag)
			{
				NullReferenceException ex = new NullReferenceException();
				bool flag2 = 0 != 1;
				array = (IObiConstraints[])(object)ex;
				if (flag2)
				{
					goto IL_04f0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				num2 = (int)array;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				bool flag3 = enumerator == null;
				num3 = -1;
				num4 = (int)array;
				num5 = -1;
				if (flag3)
				{
					goto IL_068a;
				}
			}
			else
			{
				Oni.ConstraintType? constraintType = default(Oni.ConstraintType?);
				while (enumerator.MoveNext())
				{
					IObiConstraints current = enumerator.Current;
					IObiConstraints obiConstraints = current.Clone(this);
					IntPtr intPtr2 = (IntPtr)obiConstraints;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_00ce;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+B0]");
					object obj = 0L + 8L;
					int num6 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v999 @ X11_v38-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
						{
							break;
						}
						num6++;
						int num7 = num6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v939 @ X8_v32 (Il2CppClass<Obi.IObiConstraints>)+126]");
						bool flag4 = (long)num7 < 0L;
						bool flag5 = !flag4;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_00ce;
					}
					object obj2 = obj + 1;
					int num8 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr2 + (long)num8;
					array = (IObiConstraints[])((long)(IntPtr)obj3 + 304L);
					int num9 = 0;
					goto IL_05d1;
					IL_01e0:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num9 = 1;
					goto IL_0635;
					IL_0635:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X0_v3 (Obi.IObiConstraints[])] (should have been resolved before IL gen)");
					Oni.ConstraintType value = constraintType.Value;
					array = (IObiConstraints[])(object)(obiConstraints as IObiConstraints);
					IObiConstraints[] constraints2;
					if (array != null)
					{
						if ((int)value < constraints2.Length)
						{
							constraints2[(int)value] = obiConstraints;
							IntPtr intPtr3 = (IntPtr)obiConstraints;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+126]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_0343;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+B0]");
							object obj4 = 0L + 8L;
							int num10 = 0;
							while (true)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1134 @ X11_v28-8]");
								if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
								{
									break;
								}
								num10++;
								int num11 = num10;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1091 @ X8_v42 (Il2CppClass<Obi.IObiConstraints>)+126]");
								bool flag6 = (long)num11 < 0L;
								bool flag7 = !flag6;
								obj4 = (long)(IntPtr)obj4 + 16L;
								if (!flag7)
								{
									continue;
								}
								goto IL_0343;
							}
							object obj5 = obj4 + 7;
							int num12 = (int)((long)(IntPtr)obj5 << 4);
							object obj6 = (long)intPtr3 + (long)num12;
							array = (IObiConstraints[])((long)(IntPtr)obj6 + 304L);
							goto IL_067b;
						}
						IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
						throw ex2;
					}
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					throw ex3;
					IL_067b:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X0_v3 (Obi.IObiConstraints[])] (should have been resolved before IL gen)");
					continue;
					IL_0343:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num9 = 7;
					goto IL_067b;
					IL_00ce:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
					num9 = 1;
					goto IL_05d1;
					IL_05d1:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v59 @ X0_v3 (Obi.IObiConstraints[])] (should have been resolved before IL gen)");
					if ((int)((long)(IntPtr)array & 0xFF00000000L) == 0)
					{
						continue;
					}
					IntPtr intPtr4 = (IntPtr)obiConstraints;
					constraints2 = m_Constraints;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_01e0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+B0]");
					object obj7 = 0L + 8L;
					int num13 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1064 @ X11_v33-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
						{
							break;
						}
						num13++;
						int num14 = num13;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ X8_v36 (Il2CppClass<Obi.IObiConstraints>)+126]");
						bool flag8 = (long)num14 < 0L;
						bool flag9 = !flag8;
						obj7 = (long)(IntPtr)obj7 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_01e0;
					}
					object obj8 = obj7 + 1;
					int num15 = (int)((long)(IntPtr)obj8 << 4);
					object obj9 = (long)intPtr4 + (long)num15;
					array = (IObiConstraints[])((long)(IntPtr)obj9 + 304L);
					goto IL_0635;
				}
				bool flag10 = enumerator == null;
				bool flag11 = !flag10;
				num2 = 0;
				enumerator2 = enumerator;
				num3 = 0;
				if (!flag11)
				{
					num4 = 0;
					num5 = 0;
					goto IL_068a;
				}
			}
			enumerator2.Dispose();
			num4 = num2;
			num5 = num3;
			goto IL_068a;
			IL_068a:
			if (num5 + 1 != 0 || num4 == 0)
			{
				return;
			}
			TypeLoadException ex4 = new TypeLoadException();
			intPtr = (IntPtr)null;
			num = 0;
			array = (IObiConstraints[])(object)ex4;
			goto IL_04f0;
			IL_04f0:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0xE37760", Offset = "0xE37760", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.m_Solver;\n\tthis.m_ActiveParticleCount = 0;\n\tv6.activeParticleCountChanged = 1;\n\tObi.ObiSolver::PushActiveParticles(this.m_Solver);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnloadBlueprintParticles()
		{
			ObiSolver obiSolver = solver;
			m_ActiveParticleCount = 0;
			obiSolver.activeParticleCountChanged = true;
			solver.PushActiveParticles();
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0xE37798", Offset = "0xE37798", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED3C10]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20246BD]) = v42;\nL_0015:\n\tv138 = this.m_Constraints;\nL_001C:\n\tgoto L_0027;\nL_001D:\n\tv169 = v169 + 1;\nL_0027:\n\tv144 = v169 >= v138.Length;\n\tif (v144) goto L_0085;\n\tv250 = v169 < v138.Length;\n\tv200 = ~v250;\n\tif (v200) goto L_0086;\n\tv116 = v138[v169 @ X9_v5 (System.Int32)];\n\tv202 = v138[v169 @ X9_v5 (System.Int32)] == 0;\n\tif (v202) goto L_001D;\n\tv257 = *([v116 @ X20_v8 (Obi.IObiConstraints)]);\n\tv260 = *([v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+126]) == 0;\n\tif (v260) goto L_005B;\n\tv294 = *([v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+B0]) + 8;\nL_0046:\n\tv307 = *([v294 @ X11_v9-8]) == Obi.IObiConstraints;\n\tif (v307) goto L_005E;\n\tv293 = v293 + 1;\n\tv312 = v293 < *([v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+126]);\n\tv287 = ~v312;\n\tv294 = v294 + 0x10;\n\tv267 = ~v287;\n\tif (v267) goto L_0046;\nL_005B:\n\tv318 = 0x8909C4(v138[v169 @ X9_v5 (System.Int32)], Obi.IObiConstraints, 8, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0065;\nL_005E:\n\tv314 = *([v294 @ X11_v9]) + 8;\n\tv315 = v314 << 4;\n\tv316 = v257 + v315;\n\tv318 = v316 + 0x130;\nL_0065:\n\t*([v318 @ X0_v10])(v108, v138[v169 @ X9_v5 (System.Int32)], *([v318 @ X0_v10+8]), 8, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv114 = this.m_Constraints;\n\tv322 = v169 < v114.Length;\n\tv99 = ~v322;\n\tif (v99) goto L_0086;\n\tv114[v169 @ X9_v5 (System.Int32)] = 0;\n\tv138 = this.m_Constraints;\n\tv169 = v169 + 1;\n\tv324 = this.m_Constraints == 0;\n\tv110 = ~v324;\n\tif (v110) goto L_001C;\n\tthrow System.NullReferenceException;\nL_0085:\n\treturn;\nL_0086:\n\tv256 = new System.IndexOutOfRangeException();\n\tthrow v256;\n\treturn;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnloadBlueprintConstraints()
		{
			//IL_008e: Expected I, but got O
			//IL_00c9: Expected O, but got I
			//IL_0146: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_0168: Expected O, but got I
			//IL_0177: Expected O, but got I
			//IL_0115: Expected O, but got I
			IObiConstraints[] constraints = m_Constraints;
			int num = 0;
			while (true)
			{
				if (num >= constraints.Length)
				{
					return;
				}
				if (num >= constraints.Length)
				{
					break;
				}
				IObiConstraints obiConstraints = constraints[num];
				if (constraints[num] == null)
				{
					num++;
					continue;
				}
				IntPtr intPtr = (IntPtr)obiConstraints;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_012e;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+B0]");
				object obj = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v294 @ X11_v9-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IObiConstraints))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v257 @ X8_v8 (Il2CppClass<Obi.IObiConstraints>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_012e;
				}
				object obj2 = obj + 8;
				int num4 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num4;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0264;
				IL_0264:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v318 @ X0_v10] (should have been resolved before IL gen)");
				IObiConstraints[] constraints2 = m_Constraints;
				if (num >= constraints2.Length)
				{
					break;
				}
				constraints2[num] = null;
				constraints = m_Constraints;
				num++;
				if (m_Constraints == null)
				{
					throw new NullReferenceException();
				}
				continue;
				IL_012e:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0264;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000F5")]
		[Address(RVA = "0xE378C4", Offset = "0xE378C4", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0022;\n\tv42 = *([1EC3AC8]);\n\tv43 = *([v42 @ X8_v36]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, bp, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([20246BE]) = v61;\nL_0022:\n\t*([v30 @ X29_v1-90]) = 0;\n\t*([v30 @ X29_v1-80]) = 0;\n\t*([v30 @ X29_v1-B0]) = 0;\n\t*([v30 @ X29_v1-A0]) = 0;\n\tgoto L_0037;\n\tv73 = *([v65 @ X0_v2+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tgoto L_0037;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v65, bp, methodInfo, v46, v47, v48, v49, v50, v64, v52, v53, v54, v55, v56, v57, v58);\nL_0037:\n\tv83 = UnityEngine.Object::op_Equality(bp, 0);\n\tv85 = v83 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0148;\n\tv90 = Obi.ObiActor::get_actorLocalToSolverMatrix(this);\n\tv239 = v90.m00;\n\tv280 = 0x10C1C58(&v239 @ stack_-140_v2 (System.Single), 0, 0, v46, v47, v48, v49, v50, v90.m03, v90.m02, v90.m01, v90.m00, v55, v56, v57, v58);\n\tv375 = &v31 @ stack_-10_v2 - 0xB0;\n\t*([v30 @ X29_v1-90]) = v369;\n\t*([v30 @ X29_v1-80]) = v371;\n\t*([v30 @ X29_v1-B0]) = v179;\n\t*([v30 @ X29_v1-A0]) = v374;\n\tv377 = 0x10C1A04(v375, 0, 0, v46, v47, v48, v49, v50, v371, v369, v374, v179, v55, v56, v57, v58);\n\tv254 = this.solverIndices;\nL_006D:\n\t;\n\tv121 = v166 >= v254.Length;\n\tif (v121) goto L_0148;\n\tv494 = v166 < v254.Length;\n\tv495 = ~v494;\n\tif (v495) goto L_014A;\n\tv557 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv589 = v557 == 0;\n\tif (v589) goto L_00E0;\n\tv467 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv411 = v254[v166 @ X22_v5 (System.Int32)] >= v467.m_Count;\n\tif (v411) goto L_00E0;\n\tv407 = bp.positions;\n\tv574 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv603 = *([v574 @ X0_v42 (Obi.ObiNativeVector4List)]);\n\tv605 = Obi.ObiNativeVector4List::get_Item(v574, v254[v166 @ X22_v5 (System.Int32)]);\n\tgoto L_00C3;\n\tv610 = *([v606 @ X0_v44+E0]);\n\tv611 = v610 == 0;\n\tv612 = ~v611;\n\tif (v612) goto L_00C3;\n\tv614 = \"il2cpp_codegen_runtime_class_init\"(v606, v604, v457, v46, v47, v48, v49, v50, v189, v192, v183, v186, v55, v56, v57, v58);\nL_00C3:\n\t// 195 MakeStruct v385 @ AGGE37A7C_0_v7 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v448 @ V0_v10 (UnityEngine.Vector3), v452 @ V1_v9 (System.Single), v440 @ V2_v9 (System.Single), v179 @ stack_-180_v2\n\tv448 = UnityEngine.Vector4::op_Implicit(v385);\n\tv452 = v448.y;\n\tv440 = v448.z;\n\tv620 = &v31 @ stack_-10_v2 - 0xB0;\n\tv468 = 0x10C27FC(v620, 0, *([v603 @ X8_v27 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v46, v47, v48, v49, v50, v448, v448.y, v448.z, v179, v55, v56, v57, v58);\n\tv628 = v166 < v407.Length;\n\tv537 = ~v628;\n\tif (v537) goto L_014A;\n\tv592 = v166 * 0xC;\n\tv593 = v407 + v592;\n\t*([v593 @ X8_v31+20]) = v448;\n\tv407[v166 @ X22_v5 (System.Int32)].y = v448.y;\n\tv407[v166 @ X22_v5 (System.Int32)].z = v448.z;\nL_00E0:\n\tv594 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv595 = v594 == 0;\n\tif (v595) goto L_0131;\n\tv469 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv412 = v254[v166 @ X22_v5 (System.Int32)] >= v469.m_Count;\n\tif (v412) goto L_0131;\n\tv409 = bp.velocities;\n\tv577 = Obi.ObiSolver::get_velocities(this.m_Solver);\n\tv621 = *([v577 @ X0_v31 (Obi.ObiNativeVector4List)]);\n\tv623 = Obi.ObiNativeVector4List::get_Item(v577, v254[v166 @ X22_v5 (System.Int32)]);\n\tgoto L_0118;\n\tv629 = *([v624 @ X0_v33+E0]);\n\tv630 = v629 == 0;\n\tv631 = ~v630;\n\tif (v631) goto L_0118;\n\tv633 = \"il2cpp_codegen_runtime_class_init\"(v624, v622, v459, v46, v47, v48, v49, v50, v450, v454, v442, v446, v55, v56, v57, v58);\nL_0118:\n\t// 280 MakeStruct v383 @ AGGE37B44_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v448 @ V0_v10 (UnityEngine.Vector3), v452 @ V1_v9 (System.Single), v440 @ V2_v9 (System.Single), v179 @ stack_-180_v2\n\tv448 = UnityEngine.Vector4::op_Implicit(v383);\n\tv452 = v448.y;\n\tv440 = v448.z;\n\tv639 = &v31 @ stack_-10_v2 - 0xB0;\n\tv470 = 0x10C2868(v639, 0, *([v621 @ X8_v20 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v46, v47, v48, v49, v50, v448, v448.y, v448.z, v179, v55, v56, v57, v58);\n\tv640 = v166 < v409.Length;\n\tv538 = ~v640;\n\tif (v538) goto L_014A;\n\tv598 = v166 * 0xC;\n\tv600 = v409 + v598;\n\t*([v600 @ X8_v24+20]) = v448;\n\tv409[v166 @ X22_v5 (System.Int32)].y = v448.y;\n\tv409[v166 @ X22_v5 (System.Int32)].z = v448.z;\nL_0131:\n\tv254 = this.solverIndices;\n\tv166 = v166 + 1;\n\tv601 = this.solverIndices == 0;\n\tv471 = ~v601;\n\tif (v471) goto L_006D;\n\tthrow System.NullReferenceException;\nL_0148:\n\treturn;\n\tv548 = new System.NullReferenceException();\nL_014A:\n\tv554 = new System.IndexOutOfRangeException();\n\tthrow v554;\n\treturn;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SaveStateToBlueprint(ObiActorBlueprint bp)
		{
			//IL_0078: Expected O, but got I
			//IL_018a: Expected I, but got O
			//IL_0344: Expected I, but got O
			//IL_01e3: Expected F4, but got O
			//IL_0219: Expected O, but got I
			//IL_039d: Expected F4, but got O
			//IL_03d3: Expected O, but got I
			//IL_026e: Expected O, but got I
			//IL_0428: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (bp == null)
			{
				return;
			}
			float m = actorLocalToSolverMatrix.m00;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1C58 (inside UnityEngine.Matrix4x4::Inverse_Injected +0x50)");
			object obj3 = (long)(IntPtr)obj2 - 176L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
			int[] array = solverIndices;
			int num = 0;
			float num2 = default(float);
			float z = num2;
			Vector3 vector2 = default(Vector3);
			Vector3 vector = vector2;
			float num3 = default(float);
			float y = num3;
			Vector4 vector4 = default(Vector4);
			object obj4 = default(object);
			Vector4 vector6 = default(Vector4);
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				if (num >= array.Length)
				{
					break;
				}
				ObiNativeVector4List positions = solver.positions;
				if (positions != null)
				{
					ObiNativeVector4List positions2 = solver.positions;
					if (array[num] < positions2.count)
					{
						Vector3[] positions3 = bp.positions;
						ObiNativeVector4List positions4 = solver.positions;
						IntPtr intPtr = (IntPtr)positions4;
						Vector4 vector3 = positions4.get_Item(array[num]);
						vector4.x = vector.x;
						vector4.y = y;
						vector4.z = z;
						vector4.w = (float)obj4;
						vector = vector4;
						y = vector.y;
						z = vector.z;
						object obj5 = (long)(IntPtr)obj2 - 176L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
						if (num >= positions3.Length)
						{
							break;
						}
						int num4 = num * 12;
						object obj6 = (long)(IntPtr)positions3 + (long)num4;
						positions3[num].y = vector.y;
						positions3[num].z = vector.z;
					}
				}
				ObiNativeVector4List velocities = solver.velocities;
				if (velocities != null)
				{
					ObiNativeVector4List velocities2 = solver.velocities;
					if (array[num] < velocities2.count)
					{
						Vector3[] velocities3 = bp.velocities;
						ObiNativeVector4List velocities4 = solver.velocities;
						IntPtr intPtr2 = (IntPtr)velocities4;
						Vector4 vector5 = velocities4.get_Item(array[num]);
						vector6.x = vector.x;
						vector6.y = y;
						vector6.z = z;
						vector6.w = (float)obj4;
						vector = vector6;
						y = vector.y;
						z = vector.z;
						object obj7 = (long)(IntPtr)obj2 - 176L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
						if (num >= velocities3.Length)
						{
							break;
						}
						int num5 = num * 12;
						object obj8 = (long)(IntPtr)velocities3 + (long)num5;
						velocities3[num].y = vector.y;
						velocities3[num].z = vector.z;
					}
				}
				array = solverIndices;
				num++;
				if (solverIndices == null)
				{
					throw new NullReferenceException();
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60000F6")]
		[Address(RVA = "0xE37BC0", Offset = "0xE37BC0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1ED0BF0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246BF]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tUnityEngine.Object::DestroyImmediate(this.state);\n\tv59 = Obi.ObiActor::get_blueprint(this);\n\tv63 = UnityEngine.Object::Instantiate(v59);\n\tthis.state = v63;\n\tObi.ObiActor::SaveStateToBlueprint(this, v63);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void StoreState()
		{
			UnityEngine.Object.DestroyImmediate(state);
			ObiActorBlueprint original = blueprint;
			SaveStateToBlueprint(state = UnityEngine.Object.Instantiate(original));
		}

		[Token(Token = "0x60000F7")]
		[Address(RVA = "0xE37C64", Offset = "0xE37C64", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F08B88]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246C0]) = v38;\nL_001A:\n\tgoto L_0027;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0027;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(this.state);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearState()
		{
			UnityEngine.Object.DestroyImmediate(state);
		}

		[Token(Token = "0x60000F8")]
		[Address(RVA = "0xE37CD0", Offset = "0xE37CD0", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB8998]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, solver, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246C1]) = v38;\nL_0017:\n\tv43 = Obi.ObiActor::get_blueprint(this);\n\tv46 = UnityEngine.Application::get_isPlaying();\n\tv48 = v46 == 0;\n\tif (v48) goto L_003C;\n\tgoto L_002E;\n\tv76 = *([v52 @ X0_v10+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_002E;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v52, v42, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002E:\n\tv65 = UnityEngine.Object::op_Inequality(this.state, 0);\n\tv67 = v65 == 0;\n\tif (v67) goto L_0038;\n\tv71 = this.state;\n\tgoto L_003C;\nL_0038:\n\tv64 = Obi.ObiActor::get_blueprint(this);\nL_003C:\n\tObi.ObiActor::LoadBlueprintParticles(this, v71);\n\tObi.ObiActor::LoadBlueprintConstraints(this, v71);\n\tthis.m_Loaded = 1;\n\tv88 = this.OnBlueprintLoaded == 0;\n\tif (v88) goto L_0053;\n\tObi.ObiActor+ActorBlueprintCallback::Invoke(this.OnBlueprintLoaded, this, 0);\n\treturn;\nL_0053:\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void LoadBlueprint(ObiSolver solver)
		{
			ObiActorBlueprint obiActorBlueprint = blueprint;
			bool isPlaying = Application.isPlaying;
			bool flag = !isPlaying;
			ObiActorBlueprint bp = obiActorBlueprint;
			if (!flag)
			{
				if (state != null)
				{
					bp = state;
				}
				else
				{
					ObiActorBlueprint obiActorBlueprint2 = blueprint;
					bp = obiActorBlueprint2;
				}
			}
			LoadBlueprintParticles(bp);
			LoadBlueprintConstraints(bp);
			m_Loaded = true;
			if (this.OnBlueprintLoaded != null)
			{
				this.OnBlueprintLoaded(this, null);
			}
		}

		[Token(Token = "0x60000F9")]
		[Address(RVA = "0xE381A8", Offset = "0xE381A8", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Application::get_isPlaying();\n\tv13 = v11 == 0;\n\tif (v13) goto L_000E;\n\tObi.ObiActor::StoreState(this);\nL_000E:\n\tObi.ObiActor::UnloadBlueprintConstraints(this);\n\tObi.ObiActor::UnloadBlueprintParticles(this);\n\tthis.m_Loaded = 0;\n\tv20 = this.OnBlueprintUnloaded == 0;\n\tif (v20) goto L_0021;\n\tObi.ObiActor+ActorBlueprintCallback::Invoke(this.OnBlueprintUnloaded, this, 0);\n\treturn;\nL_0021:\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void UnloadBlueprint(ObiSolver solver)
		{
			if (Application.isPlaying)
			{
				StoreState();
			}
			UnloadBlueprintConstraints();
			UnloadBlueprintParticles();
			m_Loaded = false;
			if (this.OnBlueprintUnloaded != null)
			{
				this.OnBlueprintUnloaded(this, null);
			}
		}

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0xE38208", Offset = "0xE38208", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.OnBeginStep == 0;\n\tif (v3) goto L_0007;\n\tObi.ObiActor+ActorStepCallback::Invoke(this.OnBeginStep, this, stepTime);\n\treturn;\nL_0007:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void BeginStep(float stepTime)
		{
			if (this.OnBeginStep != null)
			{
				this.OnBeginStep(this, stepTime);
			}
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0xE38608", Offset = "0xE38608", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.OnSubstep == 0;\n\tif (v3) goto L_0007;\n\tObi.ObiActor+ActorStepCallback::Invoke(this.OnSubstep, this, substepTime);\n\treturn;\nL_0007:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Substep(float substepTime)
		{
			if (this.OnSubstep != null)
			{
				this.OnSubstep(this, substepTime);
			}
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0xE38620", Offset = "0xE38620", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.OnEndStep == 0;\n\tif (v3) goto L_0007;\n\tObi.ObiActor+ActorCallback::Invoke(this.OnEndStep, this);\n\treturn;\nL_0007:\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void EndStep()
		{
			if (this.OnEndStep != null)
			{
				this.OnEndStep(this);
			}
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0xE389EC", Offset = "0xE389EC", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv48 = *([1EDD898]);\n\tv49 = *([v48 @ X8_v40]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65);\n\tv68 = 0 | 1;\n\t*([20246C2]) = v68;\nL_0028:\n\tv75 = UnityEngine.Application::get_isPlaying();\n\tv77 = v75 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_0140;\n\tv80 = ~this.m_Loaded;\n\tif (v80) goto L_0140;\n\tv277 = Obi.ObiActor::get_actorLocalToSolverMatrix(this);\n\tv259 = v277.m00;\n\tv305 = 0x10C1A04(&v259 @ stack_-120_v2 (System.Single), 0, v418, v53, v54, v55, v56, v57, v277.m03, v277.m02, v277.m01, v277.m00, v414, v412, v410, v408);\n\tv269 = this.solverIndices;\nL_005B:\n\t;\n\tv126 = v175 >= v269.Length;\n\tif (v126) goto L_0140;\n\tv567 = v175 < v269.Length;\n\tv503 = ~v567;\n\tif (v503) goto L_015A;\n\tv573 = Obi.ObiActor::get_blueprint(this);\n\tv605 = v573.positions == 0;\n\tif (v605) goto L_00DA;\n\tv534 = Obi.ObiActor::get_blueprint(this);\n\tv548 = v534.positions;\n\tv439 = v175 >= v548.Length;\n\tif (v439) goto L_00DA;\n\tv651 = Obi.ObiSolver::get_renderablePositions(this.m_Solver);\n\tv535 = Obi.ObiActor::get_blueprint(this);\n\tv549 = v535.positions;\n\tv656 = v175 < v549.Length;\n\tv505 = ~v656;\n\tif (v505) goto L_015A;\n\tv658 = v175 * 0xC;\n\tv659 = v549 + v658;\n\tv664 = 0x10C27FC(&v259 @ stack_-120_v2 (System.Single), 0, v418, v53, v54, v55, v56, v57, *([v659 @ X8_v33+20]), v549[v175 @ X22_v5 (System.Int32)].y, v549[v175 @ X22_v5 (System.Int32)].z, v520, *([v680 @ X8_v24+20]), v552[v175 @ X22_v5 (System.Int32)].y, v552[v175 @ X22_v5 (System.Int32)].z, v552[v175 @ X22_v5 (System.Int32)].w);\n\tgoto L_00C9;\n\tv670 = *([v665 @ X0_v45+E0]);\n\tv671 = v670 == 0;\n\tv672 = ~v671;\n\tif (v672) goto L_00C9;\n\tv674 = \"il2cpp_codegen_runtime_class_init\"(v665, v513, v106, v53, v54, v55, v56, v57, v660, v661, v662, v206, v100, v97, v94, v91);\nL_00C9:\n\t// 201 MakeStruct v421 @ AGGE38BB4_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v659 @ X8_v33+20], v549[v175 @ X22_v5 (System.Int32)].y (System.Single), v549[v175 @ X22_v5 (System.Int32)].z (System.Single)\n\tVector4_arg = UnityEngine.Vector4::op_Implicit(v421);\n\tv520 = Vector4_arg.w;\n\tv636 = *([v651 @ X0_v40 (Obi.ObiNativeVector4List)]);\n\tv418 = *([v636 @ X8_v36 (Il2CppClass<Obi.ObiNativeVector4List>)+198]);\n\tv633 = Obi.ObiNativeVector4List::set_Item(v651, v269[v175 @ X22_v5 (System.Int32)], Vector4_arg);\nL_00DA:\n\tv611 = Obi.ObiActor::get_blueprint(this);\n\tv639 = v611.orientations == 0;\n\tif (v639) goto L_0138;\n\tv537 = Obi.ObiActor::get_blueprint(this);\n\tv551 = v537.orientations;\n\tv441 = v175 >= v551.Length;\n\tif (v441) goto L_0138;\n\tv655 = Obi.ObiSolver::get_renderableOrientations(this.m_Solver);\n\tv538 = Obi.ObiActor::get_blueprint(this);\n\tv552 = v538.orientations;\n\tv669 = v175 < v552.Length;\n\tv508 = ~v669;\n\tif (v508) goto L_015A;\n\tv444 = v175 << 4;\n\tv680 = v552 + v444;\n\tgoto L_012A;\n\tv683 = *([v679 @ X0_v31+E0]);\n\tv684 = v683 == 0;\n\tv685 = ~v684;\n\tif (v685) goto L_012A;\n\tv687 = \"il2cpp_codegen_runtime_class_init\"(v679, v515, v419, v53, v54, v55, v56, v57, v526, v530, v518, v522, v100, v97, v94, v91);\nL_012A:\n\t// 298 MakeStruct v407 @ AGGE38CA4_0_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v277.m03 (System.Single), v277.m02 (System.Single), v277.m01 (System.Single), v277.m00 (System.Single)\n\t// 299 MakeStruct v405 @ AGGE38CA4_1_v5 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), [v680 @ X8_v24+20], v552[v175 @ X22_v5 (System.Int32)].y (System.Single), v552[v175 @ X22_v5 (System.Int32)].z (System.Single), v552[v175 @ X22_v5 (System.Int32)].w (System.Single)\n\tQuaternion_arg = UnityEngine.Quaternion::op_Multiply(v407, v405);\n\tv520 = Quaternion_arg.w;\n\tv648 = *([v655 @ X0_v28 (Obi.ObiNativeQuaternionList)]);\n\tv418 = *([v648 @ X8_v26 (Il2CppClass<Obi.ObiNativeQuaternionList>)+198]);\n\tv645 = Obi.ObiNativeQuaternionList::set_Item(v655, v269[v175 @ X22_v5 (System.Int32)], Quaternion_arg);\nL_0138:\n\tv269 = this.solverIndices;\n\tv175 = v175 + 1;\n\tv649 = this.solverIndices == 0;\n\tv540 = ~v649;\n\tif (v540) goto L_005B;\n\tthrow System.NullReferenceException;\nL_0140:\n\tv274 = this.OnInterpolate == 0;\n\tif (v274) goto L_0158;\n\tObi.ObiActor+ActorCallback::Invoke(this.OnInterpolate, this);\nL_0158:\n\treturn;\n\tv600 = new System.NullReferenceException();\nL_015A:\n\tv603 = new System.IndexOutOfRangeException();\n\tthrow v603;\n\treturn;\n// 259 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual void Interpolate()
		{
			//IL_0183: Expected O, but got I
			//IL_01aa: Expected F4, but got I
			//IL_0311: Expected O, but got I
			//IL_0207: Expected I, but got O
			//IL_0217: Expected O, but got I
			//IL_0374: Expected F4, but got I
			//IL_03f0: Expected I, but got O
			//IL_0400: Expected O, but got I
			if (!Application.isPlaying && isLoaded)
			{
				Matrix4x4 matrix4x = actorLocalToSolverMatrix;
				float m = matrix4x.m00;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C1A04 (inside UnityEngine.Matrix4x4::GetLossyScale_Injected +0x50)");
				int[] array = solverIndices;
				int num = 0;
				float m2 = matrix4x.m00;
				Vector3 vector = default(Vector3);
				Quaternion quaternion = default(Quaternion);
				Quaternion quaternion2 = default(Quaternion);
				while (num < array.Length)
				{
					if (num < array.Length)
					{
						ObiActorBlueprint obiActorBlueprint = blueprint;
						if (obiActorBlueprint.positions != null)
						{
							ObiActorBlueprint obiActorBlueprint2 = blueprint;
							Vector3[] positions = obiActorBlueprint2.positions;
							if (num < positions.Length)
							{
								ObiNativeVector4List renderablePositions = solver.renderablePositions;
								ObiActorBlueprint obiActorBlueprint3 = blueprint;
								Vector3[] positions2 = obiActorBlueprint3.positions;
								if (num >= positions2.Length)
								{
									goto IL_0456;
								}
								int num2 = num * 12;
								object obj = (long)(IntPtr)positions2 + (long)num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ X8_v33+20]");
								vector.x = 0f;
								vector.y = positions2[num].y;
								vector.z = positions2[num].z;
								Vector4 value = vector;
								m2 = value.w;
								IntPtr intPtr = (IntPtr)renderablePositions;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v636 @ X8_v36 (Il2CppClass<Obi.ObiNativeVector4List>)+198]");
								object obj2 = 0;
								renderablePositions.set_Item(array[num], value);
							}
						}
						ObiActorBlueprint obiActorBlueprint4 = blueprint;
						if (obiActorBlueprint4.orientations != null)
						{
							ObiActorBlueprint obiActorBlueprint5 = blueprint;
							Quaternion[] orientations = obiActorBlueprint5.orientations;
							if (num < orientations.Length)
							{
								ObiNativeQuaternionList renderableOrientations = solver.renderableOrientations;
								ObiActorBlueprint obiActorBlueprint6 = blueprint;
								Quaternion[] orientations2 = obiActorBlueprint6.orientations;
								if (num >= orientations2.Length)
								{
									goto IL_0456;
								}
								int num3 = num << 4;
								object obj3 = (long)(IntPtr)orientations2 + (long)num3;
								quaternion.x = matrix4x.m03;
								quaternion.y = matrix4x.m02;
								quaternion.z = matrix4x.m01;
								quaternion.w = matrix4x.m00;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v680 @ X8_v24+20]");
								quaternion2.x = 0f;
								quaternion2.y = orientations2[num].y;
								quaternion2.z = orientations2[num].z;
								quaternion2.w = orientations2[num].w;
								Quaternion value2 = quaternion * quaternion2;
								m2 = value2.w;
								IntPtr intPtr2 = (IntPtr)renderableOrientations;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v648 @ X8_v26 (Il2CppClass<Obi.ObiNativeQuaternionList>)+198]");
								object obj2 = 0;
								renderableOrientations.set_Item(array[num], value2);
							}
						}
						array = solverIndices;
						num++;
						if (solverIndices == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					goto IL_0456;
					IL_0456:
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			if (this.OnInterpolate != null)
			{
				this.OnInterpolate(this);
			}
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0xE38D28", Offset = "0xE38D28", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnSolverVisibilityChanged(bool visible)
		{
		}

		[Token(Token = "0x60000FF")]
		[Address(RVA = "0xE38D2C", Offset = "0xE38D2C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF3740]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20246C3]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (Obi.IObiConstraints[]), typeof(Obi.IObiConstraints[]), 0\n\tthis.m_Constraints = v43;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiActor()
		{
			IObiConstraints[] constraints = new IObiConstraints[0];
			m_Constraints = constraints;
		}
	}
}
