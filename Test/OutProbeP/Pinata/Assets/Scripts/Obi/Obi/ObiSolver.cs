using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744820", Offset = "0x744820")]
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000042")]
	public sealed class ObiSolver : MonoBehaviour
	{
		[Token(Token = "0x20000B2")]
		public enum UpdateMode
		{
			[Token(Token = "0x40002FA")]
			FixedUpdate = 0,
			[Token(Token = "0x40002FB")]
			AfterFixedUpdate = 1,
			[Token(Token = "0x40002FC")]
			LateUpdate = 2
		}

		[Token(Token = "0x20000B3")]
		public class ObiCollisionEventArgs : EventArgs
		{
			[Token(Token = "0x40002FD")]
			[FieldOffset(Offset = "0x10")]
			public ObiList<Oni.Contact> contacts;

			[Token(Token = "0x6000556")]
			[Address(RVA = "0x102D044", Offset = "0x102D044", Length = "0xA8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EDBF38]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026257]) = v38;\nL_0016:\n\tv42 = new Obi.ObiList`1<Oni+Contact>();\n\tObi.ObiList`1<Oni+Contact>::.ctor(v42);\n\tthis.contacts = v42;\n\tgoto L_0030;\n\tv53 = *([v49 @ X0_v4+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0030;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, v46, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\tSystem.EventArgs::.ctor(this);\n\treturn;\n\tX8 = X1 & 1;\n\tX9 = 0 | 0x3F800000;\n\t*([X0]) = X2;\n\t*([X0+4]) = X3;\n\t*([X0+C]) = X8;\n\t*([X0+8]) = X9;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ObiCollisionEventArgs()
			{
				ObiList<Oni.Contact> obiList = new ObiList<Oni.Contact>();
				contacts = obiList;
				base._002Ector();
			}
		}

		[Serializable]
		[Token(Token = "0x20000B4")]
		public class ParticleInActor
		{
			[Token(Token = "0x40002FE")]
			[FieldOffset(Offset = "0x10")]
			public ObiActor actor;

			[Token(Token = "0x40002FF")]
			[FieldOffset(Offset = "0x18")]
			public int indexInActor;

			[Token(Token = "0x6000557")]
			[Address(RVA = "0x1024C58", Offset = "0x1024C58", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.actor = 0;\n\tthis.indexInActor = 0xFFFFFFFF;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ParticleInActor()
			{
				actor = null;
				indexInActor = -1;
			}

			[Token(Token = "0x6000558")]
			[Address(RVA = "0x1029CF8", Offset = "0x1029CF8", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.actor = actor;\n\tthis.indexInActor = indexInActor;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ParticleInActor(ObiActor actor, int indexInActor)
			{
				this.actor = actor;
				this.indexInActor = indexInActor;
			}
		}

		[Token(Token = "0x20000B5")]
		public delegate void SolverCallback(ObiSolver solver);

		[Token(Token = "0x20000B6")]
		public delegate void SolverStepCallback(ObiSolver solver, float stepTime);

		[Token(Token = "0x20000B7")]
		public delegate void CollisionCallback(ObiSolver solver, ObiCollisionEventArgs contacts);

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20000B8")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000300")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000301")]
			public static Func<ParticleInActor, bool> _003C_003E9__114_0;

			[Token(Token = "0x6000565")]
			[Address(RVA = "0x102D1F0", Offset = "0x102D1F0", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EB7140]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2026255]) = v37;\nL_0015:\n\tv41 = new Obi.ObiSolver+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000566")]
			[Address(RVA = "0x102D254", Offset = "0x102D254", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003Cget_AllocParticleCount_003Eb__114_0(ParticleInActor s)
			{
				if (s != null)
				{
					return s.actor != null;
				}
				return false;
			}
		}

		[Token(Token = "0x4000102")]
		private static ProfilerMarker m_StateInterpolationPerfMarker;

		[Token(Token = "0x4000103")]
		private static ProfilerMarker m_UpdateVisibilityPerfMarker;

		[Token(Token = "0x4000104")]
		private static ProfilerMarker m_GetSolverBoundsPerfMarker;

		[Token(Token = "0x4000105")]
		private static ProfilerMarker m_TestBoundsPerfMarker;

		[Token(Token = "0x4000106")]
		private static ProfilerMarker m_GetAllCamerasPerfMarker;

		[Token(Token = "0x4000107")]
		private static int initialCapacity;

		[CompilerGenerated]
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x18")]
		private CollisionCallback m_OnCollision;

		[CompilerGenerated]
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x20")]
		private CollisionCallback m_OnParticleCollision;

		[CompilerGenerated]
		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x28")]
		private SolverCallback m_OnUpdateParameters;

		[CompilerGenerated]
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x30")]
		private SolverStepCallback m_OnBeginStep;

		[CompilerGenerated]
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x38")]
		private SolverStepCallback m_OnSubstep;

		[CompilerGenerated]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x40")]
		private SolverCallback m_OnEndStep;

		[CompilerGenerated]
		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x48")]
		private SolverCallback m_OnInterpolate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x745E18", Offset = "0x745E18")]
		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x50")]
		public bool simulateWhenInvisible;

		[ChildrenOnly]
		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x54")]
		public Oni.SolverParameters parameters;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x745E60", Offset = "0x745E60")]
		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x7C")]
		public float worldLinearInertiaScale;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x745E78", Offset = "0x745E78")]
		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x80")]
		public float worldAngularInertiaScale;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x88")]
		public List<ObiActor> actors;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x90")]
		public ParticleInActor[] m_ParticleToActor;

		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x98")]
		private int[] activeParticles;

		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0xA0")]
		private int activeParticleCount;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0xA4")]
		public bool activeParticleCountChanged;

		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0xA8")]
		private IntPtr oniSolver;

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0xB0")]
		private ObiCollisionEventArgs collisionArgs;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0xB8")]
		private ObiCollisionEventArgs particleCollisionArgs;

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0xC0")]
		private float m_MaxScale;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0xC4")]
		private Bounds bounds;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0xE0")]
		private Plane[] planes;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0xE8")]
		private Camera[] sceneCameras;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0xF0")]
		private bool isVisible;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0xF4")]
		public Oni.ConstraintParameters distanceConstraintParameters;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x104")]
		public Oni.ConstraintParameters bendingConstraintParameters;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x114")]
		public Oni.ConstraintParameters particleCollisionConstraintParameters;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x124")]
		public Oni.ConstraintParameters particleFrictionConstraintParameters;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x134")]
		public Oni.ConstraintParameters collisionConstraintParameters;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x144")]
		public Oni.ConstraintParameters frictionConstraintParameters;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x154")]
		public Oni.ConstraintParameters skinConstraintParameters;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x164")]
		public Oni.ConstraintParameters volumeConstraintParameters;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x174")]
		public Oni.ConstraintParameters shapeMatchingConstraintParameters;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x184")]
		public Oni.ConstraintParameters tetherConstraintParameters;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x194")]
		public Oni.ConstraintParameters pinConstraintParameters;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x1A4")]
		public Oni.ConstraintParameters stitchConstraintParameters;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x1B4")]
		public Oni.ConstraintParameters densityConstraintParameters;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x1C4")]
		public Oni.ConstraintParameters stretchShearConstraintParameters;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x1D4")]
		public Oni.ConstraintParameters bendTwistConstraintParameters;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x1E4")]
		public Oni.ConstraintParameters chainConstraintParameters;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x1F8")]
		public Color[] m_Colors;

		[NonSerialized]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x200")]
		private ObiNativeVector4List m_Positions;

		[NonSerialized]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x208")]
		private ObiNativeVector4List m_RestPositions;

		[NonSerialized]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x210")]
		private ObiNativeVector4List m_PrevPositions;

		[NonSerialized]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x218")]
		private ObiNativeVector4List m_StartPositions;

		[NonSerialized]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x220")]
		private ObiNativeVector4List m_RenderablePositions;

		[NonSerialized]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x228")]
		private ObiNativeQuaternionList m_Orientations;

		[NonSerialized]
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x230")]
		private ObiNativeQuaternionList m_RestOrientations;

		[NonSerialized]
		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x238")]
		private ObiNativeQuaternionList m_PrevOrientations;

		[NonSerialized]
		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x240")]
		private ObiNativeQuaternionList m_StartOrientations;

		[NonSerialized]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x248")]
		private ObiNativeQuaternionList m_RenderableOrientations;

		[NonSerialized]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x250")]
		private ObiNativeVector4List m_Velocities;

		[NonSerialized]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x258")]
		private ObiNativeVector4List m_AngularVelocities;

		[NonSerialized]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x260")]
		private ObiNativeFloatList m_InvMasses;

		[NonSerialized]
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x268")]
		private ObiNativeFloatList m_InvRotationalMasses;

		[NonSerialized]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x270")]
		private ObiNativeVector4List m_InvInertiaTensors;

		[NonSerialized]
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x278")]
		private ObiNativeVector4List m_ExternalForces;

		[NonSerialized]
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x280")]
		private ObiNativeVector4List m_ExternalTorques;

		[NonSerialized]
		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x288")]
		private ObiNativeVector4List m_Wind;

		[NonSerialized]
		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x290")]
		private ObiNativeVector4List m_PositionDeltas;

		[NonSerialized]
		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x298")]
		private ObiNativeQuaternionList m_OrientationDeltas;

		[NonSerialized]
		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x2A0")]
		private ObiNativeIntList m_PositionConstraintCounts;

		[NonSerialized]
		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x2A8")]
		private ObiNativeIntList m_OrientationConstraintCounts;

		[NonSerialized]
		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x2B0")]
		private ObiNativeIntList m_Phases;

		[NonSerialized]
		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x2B8")]
		private ObiNativeVector4List m_Anisotropies;

		[NonSerialized]
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x2C0")]
		private ObiNativeVector4List m_PrincipalRadii;

		[NonSerialized]
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x2C8")]
		private ObiNativeVector4List m_Normals;

		[NonSerialized]
		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x2D0")]
		private ObiNativeVector4List m_Vorticities;

		[NonSerialized]
		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x2D8")]
		private ObiNativeVector4List m_FluidData;

		[NonSerialized]
		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x2E0")]
		private ObiNativeVector4List m_UserData;

		[NonSerialized]
		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x2E8")]
		private ObiNativeFloatList m_SmoothingRadii;

		[NonSerialized]
		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x2F0")]
		private ObiNativeFloatList m_Buoyancies;

		[NonSerialized]
		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x2F8")]
		private ObiNativeFloatList m_RestDensities;

		[NonSerialized]
		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x300")]
		private ObiNativeFloatList m_Viscosities;

		[NonSerialized]
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x308")]
		private ObiNativeFloatList m_SurfaceTension;

		[NonSerialized]
		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x310")]
		private ObiNativeFloatList m_VortConfinement;

		[NonSerialized]
		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x318")]
		private ObiNativeFloatList m_AtmosphericDrag;

		[NonSerialized]
		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x320")]
		private ObiNativeFloatList m_AtmosphericPressure;

		[NonSerialized]
		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x328")]
		private ObiNativeFloatList m_Diffusion;

		[Token(Token = "0x17000056")]
		public IntPtr OniSolver
		{
			[Token(Token = "0x600030C")]
			[Address(RVA = "0x10249D4", Offset = "0x10249D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.oniSolver;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OniSolver;
			}
		}

		[Token(Token = "0x17000057")]
		public unsafe Bounds Bounds
		{
			[Token(Token = "0x600030D")]
			[Address(RVA = "0x10249DC", Offset = "0x10249DC", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = this.bounds.m_Extents.y;\n\treturnBuffer.m_Center = this.bounds;\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001b: Expected native int or pointer, but got O
				_ = this.bounds.m_Extents.y;
				Bounds bounds = default(Bounds);
				((Bounds*)(IntPtr)bounds)->m_Center = (Vector3)this.bounds;
				return (Bounds)this;
			}
		}

		[Token(Token = "0x17000058")]
		public bool IsVisible
		{
			[Token(Token = "0x600030E")]
			[Address(RVA = "0x10249F0", Offset = "0x10249F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isVisible;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsVisible;
			}
		}

		[Token(Token = "0x17000059")]
		public float maxScale
		{
			[Token(Token = "0x600030F")]
			[Address(RVA = "0x10249F8", Offset = "0x10249F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_MaxScale;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return maxScale;
			}
		}

		[Token(Token = "0x1700005A")]
		public int AllocParticleCount
		{
			[Token(Token = "0x6000310")]
			[Address(RVA = "0x1024A00", Offset = "0x1024A00", Length = "0x100")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1F02110]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026218]) = v42;\nL_0016:\n\tv44 = Obi.ObiSolver::get_particleToActor(this);\n\tgoto L_0027;\n\tv52 = *([v48 @ X8_v3 (Il2CppClass<Obi.ObiSolver+<>c>)+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_0027;\n\tv65 = v48;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv60 = Obi.ObiSolver+<>c;\nL_0027:\n\tv88 = v61.<>9__114_0;\n\tv63 = v61.<>9__114_0 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0054;\n\tgoto L_003B;\n\tv102 = *([v59 @ X8_v4 (Il2CppClass<Obi.ObiSolver+<>c>)+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_003B;\n\tv114 = v59;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v114, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv110 = Obi.ObiSolver+<>c;\n\tv106 = *([v110 @ X8_v15+B8]);\nL_003B:\n\tv83 = new System.Func`2<Obi.ObiSolver+ParticleInActor, System.Boolean>();\n\tSystem.Func`2<Obi.ObiSolver+ParticleInActor, System.Boolean>::.ctor(v83, v105.<>9, Il2CppMethodInfo);\n\tv87.<>9__114_0 = v83;\nL_0054:\n\treturnVal1 = System.Linq.Enumerable::Count(v44, v88);\n\treturn returnVal1;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ParticleInActor[] source = particleToActor;
				Func<ParticleInActor, bool> predicate = _003C_003Ec._003C_003E9__114_0;
				if (_003C_003Ec._003C_003E9__114_0 == null)
				{
					predicate = (_003C_003Ec._003C_003E9__114_0 = (ParticleInActor s) => s != null && s.actor != null);
				}
				return source.Count(predicate);
			}
		}

		[Token(Token = "0x1700005B")]
		public ParticleInActor[] particleToActor
		{
			[Token(Token = "0x6000311")]
			[Address(RVA = "0x1024B00", Offset = "0x1024B00", Length = "0x158")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EF6338]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026219]) = v48;\nL_0018:\n\tv108 = this.m_ParticleToActor;\n\tv50 = this.m_ParticleToActor == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_007A;\n\tgoto L_002E;\n\tv120 = *([v54 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_002E;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v54, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv124 = Obi.ObiSolver;\nL_002E:\n\t// 46 NewArr v131 @ X0_v7 (ParticleInActor[]), typeof(ParticleInActor[]), v128.initialCapacity (System.Int32)\n\tthis.m_ParticleToActor = v131;\n\tgoto L_0059;\nL_0036:\n\tv215 = new Obi.ObiSolver+ParticleInActor();\n\tSystem.Object::.ctor(v215);\n\tv215.actor = 0;\n\tv215.indexInActor = 0xFFFFFFFF;\n\tv218 = v215 == 0;\n\tif (v218) goto L_0047;\n\t// 67 IsInst v224 @ X0_v21, typeof(Obi.ObiSolver+ParticleInActor), v215 @ X0_v12 (Obi.ObiSolver+ParticleInActor)\nL_0047:\n\tv228 = v98 < v108.Length;\n\tv191 = ~v228;\n\tif (v191) goto L_007D;\n\tv193 = v98 + 1;\n\tv108[v98 @ X23_v4 (System.Int32)] = v215;\nL_0059:\n\tgoto L_0061;\n\tv205 = *([v201 @ X0_v9 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tgoto L_0061;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v201, v94, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv208 = Obi.ObiSolver;\nL_0061:\n\tv108 = this.m_ParticleToActor;\n\tv59 = v98 < v210.initialCapacity;\n\tif (v59) goto L_0036;\nL_007A:\n\treturn v108;\n\tv220 = new System.NullReferenceException();\nL_007D:\n\tv241 = new System.IndexOutOfRangeException();\n\tgoto L_0082;\n\tv242 = new System.ArrayTypeMismatchException();\nL_0082:\n\tthrow v244;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ParticleInActor[] array = m_ParticleToActor;
				if (m_ParticleToActor == null)
				{
					ParticleInActor[] array2 = new ParticleInActor[initialCapacity];
					m_ParticleToActor = array2;
					int num = 0;
					IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
					while (true)
					{
						array = m_ParticleToActor;
						if (num < initialCapacity)
						{
							ParticleInActor particleInActor = new ParticleInActor();
							particleInActor.actor = null;
							particleInActor.indexInActor = -1;
							if (particleInActor != null)
							{
								object obj = particleInActor as ParticleInActor;
							}
							if (num < array.Length)
							{
								int num2 = num + 1;
								array[num] = particleInActor;
								num = num2;
								continue;
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex2;
						}
						break;
					}
				}
				return array;
			}
		}

		[Token(Token = "0x1700005C")]
		public Color[] colors
		{
			[Token(Token = "0x6000312")]
			[Address(RVA = "0x1024C88", Offset = "0x1024C88", Length = "0x110")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAA6E8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621A]) = v42;\nL_0015:\n\tv104 = this.m_Colors;\n\tv44 = this.m_Colors == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_006B;\n\tgoto L_002B;\n\tv113 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_002B;\n\tv167 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv117 = Obi.ObiSolver;\nL_002B:\n\t// 43 NewArr v123 @ X0_v7 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v121.initialCapacity (System.Int32)\n\tthis.m_Colors = v123;\n\tgoto L_004D;\nL_0030:\n\tv155 = UnityEngine.Color::get_white();\n\tv208 = v96 < v104.Length;\n\tv186 = ~v208;\n\tif (v186) goto L_006E;\n\tv170 = v96 << 4;\n\tv192 = v104 + v170;\n\tv187 = v96 + 1;\n\t*([v192 @ X8_v15+20]) = v155;\n\tv104[v96 @ X22_v4 (System.Int32)].g = v155.g;\n\tv104[v96 @ X22_v4 (System.Int32)].b = v155.b;\n\tv104[v96 @ X22_v4 (System.Int32)].a = v155.a;\nL_004D:\n\tgoto L_0055;\n\tv198 = *([v194 @ X0_v9 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tgoto L_0055;\n\tv206 = \"il2cpp_codegen_runtime_class_init\"(v194, v59, v26, v27, v28, v29, v30, v31, v94, v92, v90, v88, v36, v37, v38, v39);\n\tv201 = Obi.ObiSolver;\nL_0055:\n\tv104 = this.m_Colors;\n\tv53 = v96 < v203.initialCapacity;\n\tif (v53) goto L_0030;\nL_006B:\n\treturn v104;\n\tv210 = new System.NullReferenceException();\nL_006E:\n\tv213 = new System.IndexOutOfRangeException();\n\tthrow v213;\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_005d: Expected O, but got I
				Color[] array = m_Colors;
				if (m_Colors == null)
				{
					Color[] array2 = new Color[initialCapacity];
					m_Colors = array2;
					int num = 0;
					while (true)
					{
						array = m_Colors;
						if (num < initialCapacity)
						{
							Color white = Color.white;
							if (num < array.Length)
							{
								int num2 = num << 4;
								object obj = (long)(IntPtr)array + (long)num2;
								int num3 = num + 1;
								array[num].g = white.g;
								array[num].b = white.b;
								array[num].a = white.a;
								num = num3;
								continue;
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						break;
					}
				}
				return array;
			}
		}

		[Token(Token = "0x1700005D")]
		public ObiNativeVector4List positions
		{
			[Token(Token = "0x6000313")]
			[Address(RVA = "0x1024D98", Offset = "0x1024D98", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED8F50]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621B]) = v42;\nL_0015:\n\treturnVal1 = this.m_Positions;\n\tv44 = this.m_Positions == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Positions = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Positions;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Positions;
				if (m_Positions == null)
				{
					(m_Positions = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_Positions;
				}
				return result;
			}
		}

		[Token(Token = "0x1700005E")]
		public ObiNativeVector4List restPositions
		{
			[Token(Token = "0x6000314")]
			[Address(RVA = "0x1024E6C", Offset = "0x1024E6C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB1608]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621C]) = v42;\nL_0015:\n\treturnVal1 = this.m_RestPositions;\n\tv44 = this.m_RestPositions == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_RestPositions = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_RestPositions;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_RestPositions;
				if (m_RestPositions == null)
				{
					(m_RestPositions = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_RestPositions;
				}
				return result;
			}
		}

		[Token(Token = "0x1700005F")]
		public ObiNativeVector4List prevPositions
		{
			[Token(Token = "0x6000315")]
			[Address(RVA = "0x1024F40", Offset = "0x1024F40", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEB468]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621D]) = v42;\nL_0015:\n\treturnVal1 = this.m_PrevPositions;\n\tv44 = this.m_PrevPositions == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_PrevPositions = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_PrevPositions;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_PrevPositions;
				if (m_PrevPositions == null)
				{
					(m_PrevPositions = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_PrevPositions;
				}
				return result;
			}
		}

		[Token(Token = "0x17000060")]
		public ObiNativeVector4List startPositions
		{
			[Token(Token = "0x6000316")]
			[Address(RVA = "0x1025014", Offset = "0x1025014", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF4980]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621E]) = v42;\nL_0015:\n\treturnVal1 = this.m_StartPositions;\n\tv44 = this.m_StartPositions == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_StartPositions = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_StartPositions;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_StartPositions;
				if (m_StartPositions == null)
				{
					(m_StartPositions = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_StartPositions;
				}
				return result;
			}
		}

		[Token(Token = "0x17000061")]
		public ObiNativeVector4List renderablePositions
		{
			[Token(Token = "0x6000317")]
			[Address(RVA = "0x10250E8", Offset = "0x10250E8", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA51A8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202621F]) = v42;\nL_0015:\n\treturnVal1 = this.m_RenderablePositions;\n\tv44 = this.m_RenderablePositions == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_RenderablePositions = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_RenderablePositions;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_RenderablePositions;
				if (m_RenderablePositions == null)
				{
					(m_RenderablePositions = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_RenderablePositions;
				}
				return result;
			}
		}

		[Token(Token = "0x17000062")]
		public ObiNativeQuaternionList orientations
		{
			[Token(Token = "0x6000318")]
			[Address(RVA = "0x10251BC", Offset = "0x10251BC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC9680]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026220]) = v42;\nL_0015:\n\treturnVal1 = this.m_Orientations;\n\tv44 = this.m_Orientations == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Orientations = v89;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Orientations;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeQuaternionList result = m_Orientations;
				if (m_Orientations == null)
				{
					(m_Orientations = new ObiNativeQuaternionList(initialCapacity)).count = initialCapacity;
					result = m_Orientations;
				}
				return result;
			}
		}

		[Token(Token = "0x17000063")]
		public ObiNativeQuaternionList restOrientations
		{
			[Token(Token = "0x6000319")]
			[Address(RVA = "0x1025290", Offset = "0x1025290", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE87F0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026221]) = v42;\nL_0015:\n\treturnVal1 = this.m_RestOrientations;\n\tv44 = this.m_RestOrientations == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_RestOrientations = v89;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_RestOrientations;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeQuaternionList result = m_RestOrientations;
				if (m_RestOrientations == null)
				{
					(m_RestOrientations = new ObiNativeQuaternionList(initialCapacity)).count = initialCapacity;
					result = m_RestOrientations;
				}
				return result;
			}
		}

		[Token(Token = "0x17000064")]
		public ObiNativeQuaternionList prevOrientations
		{
			[Token(Token = "0x600031A")]
			[Address(RVA = "0x1025364", Offset = "0x1025364", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F02D88]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026222]) = v42;\nL_0015:\n\treturnVal1 = this.m_PrevOrientations;\n\tv44 = this.m_PrevOrientations == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_PrevOrientations = v89;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_PrevOrientations;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeQuaternionList result = m_PrevOrientations;
				if (m_PrevOrientations == null)
				{
					(m_PrevOrientations = new ObiNativeQuaternionList(initialCapacity)).count = initialCapacity;
					result = m_PrevOrientations;
				}
				return result;
			}
		}

		[Token(Token = "0x17000065")]
		public ObiNativeQuaternionList startOrientations
		{
			[Token(Token = "0x600031B")]
			[Address(RVA = "0x1025438", Offset = "0x1025438", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB0850]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026223]) = v42;\nL_0015:\n\treturnVal1 = this.m_StartOrientations;\n\tv44 = this.m_StartOrientations == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_StartOrientations = v89;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_StartOrientations;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeQuaternionList result = m_StartOrientations;
				if (m_StartOrientations == null)
				{
					(m_StartOrientations = new ObiNativeQuaternionList(initialCapacity)).count = initialCapacity;
					result = m_StartOrientations;
				}
				return result;
			}
		}

		[Token(Token = "0x17000066")]
		public ObiNativeQuaternionList renderableOrientations
		{
			[Token(Token = "0x600031C")]
			[Address(RVA = "0x102550C", Offset = "0x102550C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED2AA0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026224]) = v42;\nL_0015:\n\treturnVal1 = this.m_RenderableOrientations;\n\tv44 = this.m_RenderableOrientations == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeQuaternionList();\n\tObi.ObiNativeQuaternionList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_RenderableOrientations = v89;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_RenderableOrientations;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeQuaternionList result = m_RenderableOrientations;
				if (m_RenderableOrientations == null)
				{
					(m_RenderableOrientations = new ObiNativeQuaternionList(initialCapacity)).count = initialCapacity;
					result = m_RenderableOrientations;
				}
				return result;
			}
		}

		[Token(Token = "0x17000067")]
		public ObiNativeVector4List velocities
		{
			[Token(Token = "0x600031D")]
			[Address(RVA = "0x10255E0", Offset = "0x10255E0", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBE220]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026225]) = v42;\nL_0015:\n\treturnVal1 = this.m_Velocities;\n\tv44 = this.m_Velocities == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Velocities = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Velocities;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Velocities;
				if (m_Velocities == null)
				{
					(m_Velocities = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_Velocities;
				}
				return result;
			}
		}

		[Token(Token = "0x17000068")]
		public ObiNativeVector4List angularVelocities
		{
			[Token(Token = "0x600031E")]
			[Address(RVA = "0x10256B4", Offset = "0x10256B4", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA4A88]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026226]) = v42;\nL_0015:\n\treturnVal1 = this.m_AngularVelocities;\n\tv44 = this.m_AngularVelocities == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_AngularVelocities = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_AngularVelocities;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_AngularVelocities;
				if (m_AngularVelocities == null)
				{
					(m_AngularVelocities = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_AngularVelocities;
				}
				return result;
			}
		}

		[Token(Token = "0x17000069")]
		public ObiNativeFloatList invMasses
		{
			[Token(Token = "0x600031F")]
			[Address(RVA = "0x1025788", Offset = "0x1025788", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF8178]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026227]) = v42;\nL_0015:\n\treturnVal1 = this.m_InvMasses;\n\tv44 = this.m_InvMasses == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_InvMasses = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_InvMasses;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_InvMasses;
				if (m_InvMasses == null)
				{
					(m_InvMasses = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_InvMasses;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006A")]
		public ObiNativeFloatList invRotationalMasses
		{
			[Token(Token = "0x6000320")]
			[Address(RVA = "0x102585C", Offset = "0x102585C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBDD58]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026228]) = v42;\nL_0015:\n\treturnVal1 = this.m_InvRotationalMasses;\n\tv44 = this.m_InvRotationalMasses == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_InvRotationalMasses = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_InvRotationalMasses;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_InvRotationalMasses;
				if (m_InvRotationalMasses == null)
				{
					(m_InvRotationalMasses = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_InvRotationalMasses;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006B")]
		public ObiNativeVector4List invInertiaTensors
		{
			[Token(Token = "0x6000321")]
			[Address(RVA = "0x1025930", Offset = "0x1025930", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFA6D0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026229]) = v42;\nL_0015:\n\treturnVal1 = this.m_InvInertiaTensors;\n\tv44 = this.m_InvInertiaTensors == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_InvInertiaTensors = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_InvInertiaTensors;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_InvInertiaTensors;
				if (m_InvInertiaTensors == null)
				{
					(m_InvInertiaTensors = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_InvInertiaTensors;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006C")]
		public ObiNativeVector4List externalForces
		{
			[Token(Token = "0x6000322")]
			[Address(RVA = "0x1025A04", Offset = "0x1025A04", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EAFC18]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622A]) = v42;\nL_0015:\n\treturnVal1 = this.m_ExternalForces;\n\tv44 = this.m_ExternalForces == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_ExternalForces = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_ExternalForces;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_ExternalForces;
				if (m_ExternalForces == null)
				{
					(m_ExternalForces = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_ExternalForces;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006D")]
		public ObiNativeVector4List externalTorques
		{
			[Token(Token = "0x6000323")]
			[Address(RVA = "0x1025AD8", Offset = "0x1025AD8", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC5CB0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622B]) = v42;\nL_0015:\n\treturnVal1 = this.m_ExternalTorques;\n\tv44 = this.m_ExternalTorques == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_ExternalTorques = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_ExternalTorques;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_ExternalTorques;
				if (m_ExternalTorques == null)
				{
					(m_ExternalTorques = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_ExternalTorques;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006E")]
		public ObiNativeVector4List wind
		{
			[Token(Token = "0x6000324")]
			[Address(RVA = "0x1025BAC", Offset = "0x1025BAC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC4C48]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622C]) = v42;\nL_0015:\n\treturnVal1 = this.m_Wind;\n\tv44 = this.m_Wind == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Wind = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Wind;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Wind;
				if (m_Wind == null)
				{
					(m_Wind = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_Wind;
				}
				return result;
			}
		}

		[Token(Token = "0x1700006F")]
		public ObiNativeVector4List positionDeltas
		{
			[Token(Token = "0x6000325")]
			[Address(RVA = "0x1025C80", Offset = "0x1025C80", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA91E8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622D]) = v42;\nL_0015:\n\treturnVal1 = this.m_PositionDeltas;\n\tv44 = this.m_PositionDeltas == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_PositionDeltas = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_PositionDeltas;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_PositionDeltas;
				if (m_PositionDeltas == null)
				{
					(m_PositionDeltas = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_PositionDeltas;
				}
				return result;
			}
		}

		[Token(Token = "0x17000070")]
		public ObiNativeQuaternionList orientationDeltas
		{
			[Token(Token = "0x6000326")]
			[Address(RVA = "0x1025D54", Offset = "0x1025D54", Length = "0x104")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED9B78]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622E]) = v42;\nL_0015:\n\treturnVal1 = this.m_OrientationDeltas;\n\tv44 = this.m_OrientationDeltas == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0052;\n\tgoto L_002E;\n\tv95 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv96 = v95 == 0;\n\tv97 = ~v96;\n\tif (v97) goto L_002E;\n\tv134 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv99 = Obi.ObiSolver;\nL_002E:\n\tv56 = 0;\n\tv109 = 0x10CB640(&v56 @ stack_-40_v2, 0, v26, v27, v28, v29, v30, v31, 0, 0, 0, 0, v36, v37, v38, v39);\n\tv137 = new Obi.ObiNativeQuaternionList();\n\t// 61 MakeStruct v64 @ AGG1025E0C_3_v2 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, v138 @ stack_-3C, 0, v139 @ stack_-34\n\tObi.ObiNativeQuaternionList::.ctor(v137, v102.initialCapacity, 0x10, v64);\n\tthis.m_OrientationDeltas = v137;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::set_count(v137, v86.initialCapacity);\n\treturnVal1 = this.m_OrientationDeltas;\nL_0052:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0073: Expected O, but got I4
				//IL_00b4: Expected F4, but got O
				//IL_00cf: Expected F4, but got O
				ObiNativeQuaternionList result = m_OrientationDeltas;
				if (m_OrientationDeltas == null)
				{
					object obj = 0;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CB640 (inside UnityEngine.QualitySettings::get_activeColorSpace +0x34)");
					Quaternion defaultValue = default(Quaternion);
					ObiNativeQuaternionList obiNativeQuaternionList = new ObiNativeQuaternionList(initialCapacity, 16, defaultValue);
					defaultValue.x = 0f;
					object obj2 = default(object);
					defaultValue.y = (float)obj2;
					defaultValue.z = 0f;
					object obj3 = default(object);
					defaultValue.w = (float)obj3;
					m_OrientationDeltas = obiNativeQuaternionList;
					obiNativeQuaternionList.count = initialCapacity;
					result = m_OrientationDeltas;
				}
				return result;
			}
		}

		[Token(Token = "0x17000071")]
		public ObiNativeIntList positionConstraintCounts
		{
			[Token(Token = "0x6000327")]
			[Address(RVA = "0x1025E58", Offset = "0x1025E58", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB1C80]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202622F]) = v42;\nL_0015:\n\treturnVal1 = this.m_PositionConstraintCounts;\n\tv44 = this.m_PositionConstraintCounts == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_PositionConstraintCounts = v89;\n\tObi.ObiNativeList`1<System.Int32>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_PositionConstraintCounts;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeIntList result = m_PositionConstraintCounts;
				if (m_PositionConstraintCounts == null)
				{
					(m_PositionConstraintCounts = new ObiNativeIntList(initialCapacity)).count = initialCapacity;
					result = m_PositionConstraintCounts;
				}
				return result;
			}
		}

		[Token(Token = "0x17000072")]
		public ObiNativeIntList orientationConstraintCounts
		{
			[Token(Token = "0x6000328")]
			[Address(RVA = "0x1025F2C", Offset = "0x1025F2C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EA36C0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026230]) = v42;\nL_0015:\n\treturnVal1 = this.m_OrientationConstraintCounts;\n\tv44 = this.m_OrientationConstraintCounts == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_OrientationConstraintCounts = v89;\n\tObi.ObiNativeList`1<System.Int32>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_OrientationConstraintCounts;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeIntList result = m_OrientationConstraintCounts;
				if (m_OrientationConstraintCounts == null)
				{
					(m_OrientationConstraintCounts = new ObiNativeIntList(initialCapacity)).count = initialCapacity;
					result = m_OrientationConstraintCounts;
				}
				return result;
			}
		}

		[Token(Token = "0x17000073")]
		public ObiNativeIntList phases
		{
			[Token(Token = "0x6000329")]
			[Address(RVA = "0x1026000", Offset = "0x1026000", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDA258]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026231]) = v42;\nL_0015:\n\treturnVal1 = this.m_Phases;\n\tv44 = this.m_Phases == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeIntList();\n\tObi.ObiNativeIntList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Phases = v89;\n\tObi.ObiNativeList`1<System.Int32>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Phases;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeIntList result = m_Phases;
				if (m_Phases == null)
				{
					(m_Phases = new ObiNativeIntList(initialCapacity)).count = initialCapacity;
					result = m_Phases;
				}
				return result;
			}
		}

		[Token(Token = "0x17000074")]
		public ObiNativeVector4List anisotropies
		{
			[Token(Token = "0x600032A")]
			[Address(RVA = "0x10260D4", Offset = "0x10260D4", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F06BC8]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026232]) = v42;\nL_0015:\n\treturnVal1 = this.m_Anisotropies;\n\tv44 = this.m_Anisotropies == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0047;\n\tgoto L_002B;\n\tv81 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tif (v83) goto L_002B;\n\tv111 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv85 = Obi.ObiSolver;\nL_002B:\n\tv92 = new Obi.ObiNativeVector4List();\n\tv102 = v89.initialCapacity << 1;\n\tv100 = v89.initialCapacity + v102;\n\tObi.ObiNativeVector4List::.ctor(v92, v100, 0x10);\n\tthis.m_Anisotropies = v92;\n\tv64 = v115.initialCapacity << 1;\n\tv62 = v115.initialCapacity + v64;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v92, v62);\n\treturnVal1 = this.m_Anisotropies;\nL_0047:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Anisotropies;
				if (m_Anisotropies == null)
				{
					int capacity = default(int);
					ObiNativeVector4List obiNativeVector4List = new ObiNativeVector4List(capacity);
					int num = initialCapacity << 1;
					capacity = initialCapacity + num;
					m_Anisotropies = obiNativeVector4List;
					int num2 = initialCapacity << 1;
					int count = initialCapacity + num2;
					obiNativeVector4List.count = count;
					result = m_Anisotropies;
				}
				return result;
			}
		}

		[Token(Token = "0x17000075")]
		public ObiNativeVector4List principalRadii
		{
			[Token(Token = "0x600032B")]
			[Address(RVA = "0x10261AC", Offset = "0x10261AC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF77E0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026233]) = v42;\nL_0015:\n\treturnVal1 = this.m_PrincipalRadii;\n\tv44 = this.m_PrincipalRadii == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_PrincipalRadii = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_PrincipalRadii;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_PrincipalRadii;
				if (m_PrincipalRadii == null)
				{
					(m_PrincipalRadii = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_PrincipalRadii;
				}
				return result;
			}
		}

		[Token(Token = "0x17000076")]
		public ObiNativeVector4List normals
		{
			[Token(Token = "0x600032C")]
			[Address(RVA = "0x1026280", Offset = "0x1026280", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB1940]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026234]) = v42;\nL_0015:\n\treturnVal1 = this.m_Normals;\n\tv44 = this.m_Normals == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Normals = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Normals;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Normals;
				if (m_Normals == null)
				{
					(m_Normals = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_Normals;
				}
				return result;
			}
		}

		[Token(Token = "0x17000077")]
		public ObiNativeVector4List vorticities
		{
			[Token(Token = "0x600032D")]
			[Address(RVA = "0x1026354", Offset = "0x1026354", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE9848]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026235]) = v42;\nL_0015:\n\treturnVal1 = this.m_Vorticities;\n\tv44 = this.m_Vorticities == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Vorticities = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Vorticities;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_Vorticities;
				if (m_Vorticities == null)
				{
					(m_Vorticities = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_Vorticities;
				}
				return result;
			}
		}

		[Token(Token = "0x17000078")]
		public ObiNativeVector4List fluidData
		{
			[Token(Token = "0x600032E")]
			[Address(RVA = "0x1026428", Offset = "0x1026428", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFAB58]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026236]) = v42;\nL_0015:\n\treturnVal1 = this.m_FluidData;\n\tv44 = this.m_FluidData == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_FluidData = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_FluidData;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_FluidData;
				if (m_FluidData == null)
				{
					(m_FluidData = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_FluidData;
				}
				return result;
			}
		}

		[Token(Token = "0x17000079")]
		public ObiNativeVector4List userData
		{
			[Token(Token = "0x600032F")]
			[Address(RVA = "0x10264FC", Offset = "0x10264FC", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED68B0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026237]) = v42;\nL_0015:\n\treturnVal1 = this.m_UserData;\n\tv44 = this.m_UserData == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeVector4List();\n\tObi.ObiNativeVector4List::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_UserData = v89;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_UserData;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeVector4List result = m_UserData;
				if (m_UserData == null)
				{
					(m_UserData = new ObiNativeVector4List(initialCapacity)).count = initialCapacity;
					result = m_UserData;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007A")]
		public ObiNativeFloatList smoothingRadii
		{
			[Token(Token = "0x6000330")]
			[Address(RVA = "0x10265D0", Offset = "0x10265D0", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBB308]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026238]) = v42;\nL_0015:\n\treturnVal1 = this.m_SmoothingRadii;\n\tv44 = this.m_SmoothingRadii == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_SmoothingRadii = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_SmoothingRadii;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_SmoothingRadii;
				if (m_SmoothingRadii == null)
				{
					(m_SmoothingRadii = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_SmoothingRadii;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007B")]
		public ObiNativeFloatList buoyancies
		{
			[Token(Token = "0x6000331")]
			[Address(RVA = "0x10266A4", Offset = "0x10266A4", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED8958]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026239]) = v42;\nL_0015:\n\treturnVal1 = this.m_Buoyancies;\n\tv44 = this.m_Buoyancies == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Buoyancies = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Buoyancies;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_Buoyancies;
				if (m_Buoyancies == null)
				{
					(m_Buoyancies = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_Buoyancies;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007C")]
		public ObiNativeFloatList restDensities
		{
			[Token(Token = "0x6000332")]
			[Address(RVA = "0x1026778", Offset = "0x1026778", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F07C48]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623A]) = v42;\nL_0015:\n\treturnVal1 = this.m_RestDensities;\n\tv44 = this.m_RestDensities == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_RestDensities = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_RestDensities;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_RestDensities;
				if (m_RestDensities == null)
				{
					(m_RestDensities = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_RestDensities;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007D")]
		public ObiNativeFloatList viscosities
		{
			[Token(Token = "0x6000333")]
			[Address(RVA = "0x102684C", Offset = "0x102684C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC71E0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623B]) = v42;\nL_0015:\n\treturnVal1 = this.m_Viscosities;\n\tv44 = this.m_Viscosities == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Viscosities = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Viscosities;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_Viscosities;
				if (m_Viscosities == null)
				{
					(m_Viscosities = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_Viscosities;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007E")]
		public ObiNativeFloatList surfaceTension
		{
			[Token(Token = "0x6000334")]
			[Address(RVA = "0x1026920", Offset = "0x1026920", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F104E0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623C]) = v42;\nL_0015:\n\treturnVal1 = this.m_SurfaceTension;\n\tv44 = this.m_SurfaceTension == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_SurfaceTension = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_SurfaceTension;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_SurfaceTension;
				if (m_SurfaceTension == null)
				{
					(m_SurfaceTension = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_SurfaceTension;
				}
				return result;
			}
		}

		[Token(Token = "0x1700007F")]
		public ObiNativeFloatList vortConfinement
		{
			[Token(Token = "0x6000335")]
			[Address(RVA = "0x10269F4", Offset = "0x10269F4", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EC5DF0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623D]) = v42;\nL_0015:\n\treturnVal1 = this.m_VortConfinement;\n\tv44 = this.m_VortConfinement == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_VortConfinement = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_VortConfinement;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_VortConfinement;
				if (m_VortConfinement == null)
				{
					(m_VortConfinement = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_VortConfinement;
				}
				return result;
			}
		}

		[Token(Token = "0x17000080")]
		public ObiNativeFloatList atmosphericDrag
		{
			[Token(Token = "0x6000336")]
			[Address(RVA = "0x1026AC8", Offset = "0x1026AC8", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED7F10]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623E]) = v42;\nL_0015:\n\treturnVal1 = this.m_AtmosphericDrag;\n\tv44 = this.m_AtmosphericDrag == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_AtmosphericDrag = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_AtmosphericDrag;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_AtmosphericDrag;
				if (m_AtmosphericDrag == null)
				{
					(m_AtmosphericDrag = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_AtmosphericDrag;
				}
				return result;
			}
		}

		[Token(Token = "0x17000081")]
		public ObiNativeFloatList atmosphericPressure
		{
			[Token(Token = "0x6000337")]
			[Address(RVA = "0x1026B9C", Offset = "0x1026B9C", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF4538]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202623F]) = v42;\nL_0015:\n\treturnVal1 = this.m_AtmosphericPressure;\n\tv44 = this.m_AtmosphericPressure == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_AtmosphericPressure = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_AtmosphericPressure;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_AtmosphericPressure;
				if (m_AtmosphericPressure == null)
				{
					(m_AtmosphericPressure = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_AtmosphericPressure;
				}
				return result;
			}
		}

		[Token(Token = "0x17000082")]
		public ObiNativeFloatList diffusion
		{
			[Token(Token = "0x6000338")]
			[Address(RVA = "0x1026C70", Offset = "0x1026C70", Length = "0xD4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EDAE00]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026240]) = v42;\nL_0015:\n\treturnVal1 = this.m_Diffusion;\n\tv44 = this.m_Diffusion == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_0044;\n\tgoto L_002B;\n\tv78 = *([v48 @ X0_v4 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tif (v80) goto L_002B;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv82 = Obi.ObiSolver;\nL_002B:\n\tv89 = new Obi.ObiNativeFloatList();\n\tObi.ObiNativeFloatList::.ctor(v89, v86.initialCapacity, 0x10);\n\tthis.m_Diffusion = v89;\n\tObi.ObiNativeList`1<System.Single>::set_count(v89, v69.initialCapacity);\n\treturnVal1 = this.m_Diffusion;\nL_0044:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				ObiNativeFloatList result = m_Diffusion;
				if (m_Diffusion == null)
				{
					(m_Diffusion = new ObiNativeFloatList(initialCapacity)).count = initialCapacity;
					result = m_Diffusion;
				}
				return result;
			}
		}

		[Token(Token = "0x1400000C")]
		public event CollisionCallback OnCollision
		{
			[CompilerGenerated]
			[Token(Token = "0x60002FE")]
			[Address(RVA = "0x10240DC", Offset = "0x10240DC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F08318]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620A]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+CollisionCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnCollision;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CollisionCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x60002FF")]
			[Address(RVA = "0x1024180", Offset = "0x1024180", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF36A0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620B]) = v43;\nL_0017:\n\tv45 = this + 0x18;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+CollisionCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 24L;
				Delegate obj2 = this.m_OnCollision;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CollisionCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x1400000D")]
		public event CollisionCallback OnParticleCollision
		{
			[CompilerGenerated]
			[Token(Token = "0x6000300")]
			[Address(RVA = "0x1024224", Offset = "0x1024224", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC73F8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620C]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+CollisionCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_OnParticleCollision;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CollisionCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000301")]
			[Address(RVA = "0x10242C8", Offset = "0x10242C8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE2F40]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620D]) = v43;\nL_0017:\n\tv45 = this + 0x20;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+CollisionCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 32L;
				Delegate obj2 = this.m_OnParticleCollision;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(CollisionCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x1400000E")]
		public event SolverCallback OnUpdateParameters
		{
			[CompilerGenerated]
			[Token(Token = "0x6000302")]
			[Address(RVA = "0x102436C", Offset = "0x102436C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC4A68]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620E]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_OnUpdateParameters;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000303")]
			[Address(RVA = "0x1024410", Offset = "0x1024410", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0C380]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202620F]) = v43;\nL_0017:\n\tv45 = this + 0x28;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 40L;
				Delegate obj2 = this.m_OnUpdateParameters;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x1400000F")]
		public event SolverStepCallback OnBeginStep
		{
			[CompilerGenerated]
			[Token(Token = "0x6000304")]
			[Address(RVA = "0x10244B4", Offset = "0x10244B4", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAA548]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026210]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_OnBeginStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverStepCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000305")]
			[Address(RVA = "0x1024558", Offset = "0x1024558", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBB3D0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026211]) = v43;\nL_0017:\n\tv45 = this + 0x30;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 48L;
				Delegate obj2 = this.m_OnBeginStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverStepCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000010")]
		public event SolverStepCallback OnSubstep
		{
			[CompilerGenerated]
			[Token(Token = "0x6000306")]
			[Address(RVA = "0x10245FC", Offset = "0x10245FC", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0DFA8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026212]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_OnSubstep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverStepCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000307")]
			[Address(RVA = "0x10246A0", Offset = "0x10246A0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EAF0C8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026213]) = v43;\nL_0017:\n\tv45 = this + 0x38;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverStepCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 56L;
				Delegate obj2 = this.m_OnSubstep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverStepCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000011")]
		public event SolverCallback OnEndStep
		{
			[CompilerGenerated]
			[Token(Token = "0x6000308")]
			[Address(RVA = "0x1024744", Offset = "0x1024744", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EF72B0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026214]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_OnEndStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x6000309")]
			[Address(RVA = "0x10247E8", Offset = "0x10247E8", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1F0E1B0]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026215]) = v43;\nL_0017:\n\tv45 = this + 0x40;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 64L;
				Delegate obj2 = this.m_OnEndStep;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x14000012")]
		public event SolverCallback OnInterpolate
		{
			[CompilerGenerated]
			[Token(Token = "0x600030A")]
			[Address(RVA = "0x102488C", Offset = "0x102488C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED6C98]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026216]) = v43;\nL_0017:\n\tv45 = this + 0x48;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 72L;
				Delegate obj2 = this.m_OnInterpolate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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
			[Token(Token = "0x600030B")]
			[Address(RVA = "0x1024930", Offset = "0x1024930", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EE6E88]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2026217]) = v43;\nL_0017:\n\tv45 = this + 0x48;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiSolver+SolverCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 72L;
				Delegate obj2 = this.m_OnInterpolate;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(SolverCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
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

		[Token(Token = "0x6000339")]
		[Address(RVA = "0x1026D44", Offset = "0x1026D44", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiSolver::Initialize(this);\n\treturn;\n")]
		private void OnEnable()
		{
			Initialize();
		}

		[Token(Token = "0x600033A")]
		[Address(RVA = "0x1026E78", Offset = "0x1026E78", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EB6160]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026241]) = v38;\nL_0017:\n\t// 23 NewArr v43 @ X0_v3 (System.Single[]), typeof(System.Single[]), 3\n\tv47 = UnityEngine.Component::get_transform(this);\n\tv50 = UnityEngine.Transform::get_lossyScale(v47);\n\tv129 = v43.Length == 0;\n\tif (v129) goto L_006D;\n\tv43[0] = v50;\n\tv90 = UnityEngine.Component::get_transform(this);\n\tv85 = UnityEngine.Transform::get_lossyScale(v90);\n\tv186 = v43.Length < 1;\n\tv77 = ~v186;\n\tv74 = v43.Length - 1;\n\tv68 = v74 == 0;\n\tv187 = ~v77;\n\tv53 = v187 | v68;\n\tif (v53) goto L_006D;\n\tv43[1] = v85.y;\n\tv91 = UnityEngine.Component::get_transform(this);\n\tv123 = UnityEngine.Transform::get_lossyScale(v91);\n\tv189 = v43.Length < 2;\n\tv117 = ~v189;\n\tv115 = v43.Length - 2;\n\tv111 = v115 == 0;\n\tv190 = ~v117;\n\tv101 = v190 | v111;\n\tif (v101) goto L_006D;\n\tv43[2] = v123.z;\n\tgoto L_0064;\n\tv197 = *([v193 @ X0_v18+E0]);\n\tv198 = v197 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_0064;\n\tv201 = \"il2cpp_codegen_runtime_class_init\"(v193, v126, v22, v23, v24, v25, v26, v27, v123, v121, v119, v31, v32, v33, v34, v35);\nL_0064:\n\tv171 = UnityEngine.Mathf::Max(v43);\n\tthis.m_MaxScale = v171;\n\treturn;\n\tv98 = new System.NullReferenceException();\nL_006D:\n\tv132 = new System.IndexOutOfRangeException();\n\tthrow v132;\n\tthrow System.NullReferenceException;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0095: Expected O, but got I4
			//IL_0129: Expected O, but got I4
			float[] array = new float[3];
			Transform transform = base.transform;
			Vector3 lossyScale = transform.lossyScale;
			if (array.Length != 0)
			{
				array[0] = lossyScale.x;
				Transform transform2 = base.transform;
				Vector3 lossyScale2 = transform2.lossyScale;
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj = array.Length - 1;
				bool flag3 = obj == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = lossyScale2.y;
					Transform transform3 = base.transform;
					Vector3 lossyScale3 = transform3.lossyScale;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj2 = array.Length - 2;
					bool flag7 = obj2 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = lossyScale3.z;
						float num = Mathf.Max(array);
						m_MaxScale = num;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0x1026F94", Offset = "0x1026F94", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1ED22A0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv80 = 0 | 1;\n\t*([2026242]) = v80;\n\tgoto L_001B;\nL_0014:\n\tv92 = v81._items;\n\tv72 = v81._size - 1;\n\tv75 = Obi.ObiSolver::RemoveActor(this, v92[v72 @ X9_v3 (System.Int32)]);\nL_001B:\n\tv81 = this.actors;\n\tv40 = v81._size > 0;\n\tif (v40) goto L_0014;\n\tObi.ObiSolver::Teardown(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			while (true)
			{
				List<ObiActor> list = actors;
				if (list.Count > 0)
				{
					ObiActor[] items = list._items;
					int num = list.Count - 1;
					bool flag = RemoveActor(items[num]);
					continue;
				}
				break;
			}
			Teardown();
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0x1026D48", Offset = "0x1026D48", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC7460]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026243]) = v38;\nL_0016:\n\tv42 = System.IntPtr::op_Equality(this.oniSolver, 0);\n\tv44 = v42 == 0;\n\tif (v44) goto L_005E;\n\tv48 = new System.Collections.Generic.List`1<Obi.ObiActor>();\n\tSystem.Collections.Generic.List`1<Obi.ObiActor>::.ctor(v48);\n\tthis.actors = v48;\n\tgoto L_0036;\n\tv82 = *([v78 @ X0_v6 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0036;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v78, v56, v41, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv86 = Obi.ObiSolver;\nL_0036:\n\t// 54 NewArr v93 @ X0_v9 (System.Int32[]), typeof(System.Int32[]), v89.initialCapacity (System.Int32)\n\tthis.activeParticles = v93;\n\t// 62 NewArr v101 @ X0_v11 (ParticleInActor[]), typeof(ParticleInActor[]), v97.initialCapacity (System.Int32)\n\tthis.m_ParticleToActor = v101;\n\t// 70 NewArr v106 @ X0_v13 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v104.initialCapacity (System.Int32)\n\tthis.m_Colors = v106;\n\tv109 = Oni::CreateSolver(v71.initialCapacity);\n\tthis.oniSolver = v109;\n\tObi.ObiSolver::PushParticleArrays(this);\n\tObi.ObiSolver::InitializeTransformFrame(this);\n\tObi.ObiSolver::UpdateParameters(this);\n\treturn;\nL_005E:\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			if (OniSolver == (IntPtr)0)
			{
				List<ObiActor> list = new List<ObiActor>();
				actors = list;
				int[] array = new int[initialCapacity];
				activeParticles = array;
				ParticleInActor[] array2 = new ParticleInActor[initialCapacity];
				m_ParticleToActor = array2;
				Color[] array3 = new Color[initialCapacity];
				m_Colors = array3;
				IntPtr intPtr = Oni.CreateSolver(initialCapacity);
				oniSolver = intPtr;
				PushParticleArrays();
				Initialize();
				UpdateParameters();
			}
		}

		[Token(Token = "0x600033D")]
		[Address(RVA = "0x1027178", Offset = "0x1027178", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEA628]);\n\tv19 = *([v18 @ X8_v4]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026244]) = v38;\nL_0014:\n\tObi.ObiSolver::FreeParticleArrays(this);\n\tOni::DestroySolver(this.oniSolver);\n\tthis.oniSolver = 0;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Teardown()
		{
			FreeParticleArrays();
			Oni.DestroySolver(OniSolver);
			oniSolver = (IntPtr)0;
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0x1027264", Offset = "0x1027264", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EDC2B8]);\n\tv21 = *([v20 @ X8_v4]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026245]) = v40;\nL_0016:\n\tv43 = Obi.ObiSolver::get_positions(this);\n\tOni::SetParticlePositions(this.oniSolver, v43.m_AlignedPtr);\n\tv86 = Obi.ObiSolver::get_prevPositions(this);\n\tOni::SetParticlePreviousPositions(this.oniSolver, v86.m_AlignedPtr);\n\tv87 = Obi.ObiSolver::get_restPositions(this);\n\tOni::SetRestPositions(this.oniSolver, v87.m_AlignedPtr);\n\tv88 = Obi.ObiSolver::get_orientations(this);\n\tOni::SetParticleOrientations(this.oniSolver, v88.m_AlignedPtr);\n\tv89 = Obi.ObiSolver::get_prevOrientations(this);\n\tOni::SetParticlePreviousOrientations(this.oniSolver, v89.m_AlignedPtr);\n\tv90 = Obi.ObiSolver::get_restOrientations(this);\n\tOni::SetRestOrientations(this.oniSolver, v90.m_AlignedPtr);\n\tv91 = Obi.ObiSolver::get_velocities(this);\n\tOni::SetParticleVelocities(this.oniSolver, v91.m_AlignedPtr);\n\tv92 = Obi.ObiSolver::get_angularVelocities(this);\n\tOni::SetParticleAngularVelocities(this.oniSolver, v92.m_AlignedPtr);\n\tv93 = Obi.ObiSolver::get_invMasses(this);\n\tOni::SetParticleInverseMasses(this.oniSolver, v93.m_AlignedPtr);\n\tv94 = Obi.ObiSolver::get_invRotationalMasses(this);\n\tOni::SetParticleInverseRotationalMasses(this.oniSolver, v94.m_AlignedPtr);\n\tv95 = Obi.ObiSolver::get_principalRadii(this);\n\tOni::SetParticlePrincipalRadii(this.oniSolver, v95.m_AlignedPtr);\n\tv96 = Obi.ObiSolver::get_phases(this);\n\tOni::SetParticlePhases(this.oniSolver, v96.m_AlignedPtr);\n\tv97 = Obi.ObiSolver::get_renderablePositions(this);\n\tOni::SetRenderableParticlePositions(this.oniSolver, v97.m_AlignedPtr);\n\tv98 = Obi.ObiSolver::get_renderableOrientations(this);\n\tOni::SetRenderableParticleOrientations(this.oniSolver, v98.m_AlignedPtr);\n\tv99 = Obi.ObiSolver::get_anisotropies(this);\n\tOni::SetParticleAnisotropies(this.oniSolver, v99.m_AlignedPtr);\n\tv100 = Obi.ObiSolver::get_smoothingRadii(this);\n\tOni::SetParticleSmoothingRadii(this.oniSolver, v100.m_AlignedPtr);\n\tv101 = Obi.ObiSolver::get_buoyancies(this);\n\tOni::SetParticleBuoyancy(this.oniSolver, v101.m_AlignedPtr);\n\tv102 = Obi.ObiSolver::get_restDensities(this);\n\tOni::SetParticleRestDensities(this.oniSolver, v102.m_AlignedPtr);\n\tv103 = Obi.ObiSolver::get_viscosities(this);\n\tOni::SetParticleViscosities(this.oniSolver, v103.m_AlignedPtr);\n\tv104 = Obi.ObiSolver::get_surfaceTension(this);\n\tOni::SetParticleSurfaceTension(this.oniSolver, v104.m_AlignedPtr);\n\tv105 = Obi.ObiSolver::get_vortConfinement(this);\n\tOni::SetParticleVorticityConfinement(this.oniSolver, v105.m_AlignedPtr);\n\tv106 = Obi.ObiSolver::get_atmosphericDrag(this);\n\tv107 = Obi.ObiSolver::get_atmosphericPressure(this);\n\tOni::SetParticleAtmosphericDragPressure(this.oniSolver, v106.m_AlignedPtr, v107.m_AlignedPtr);\n\tv108 = Obi.ObiSolver::get_diffusion(this);\n\tOni::SetParticleDiffusion(this.oniSolver, v108.m_AlignedPtr);\n\tv109 = Obi.ObiSolver::get_vorticities(this);\n\tOni::SetParticleVorticities(this.oniSolver, v109.m_AlignedPtr);\n\tv110 = Obi.ObiSolver::get_fluidData(this);\n\tOni::SetParticleFluidData(this.oniSolver, v110.m_AlignedPtr);\n\tv111 = Obi.ObiSolver::get_userData(this);\n\tOni::SetParticleUserData(this.oniSolver, v111.m_AlignedPtr);\n\tv112 = Obi.ObiSolver::get_externalForces(this);\n\tOni::SetParticleExternalForces(this.oniSolver, v112.m_AlignedPtr);\n\tv113 = Obi.ObiSolver::get_externalTorques(this);\n\tOni::SetParticleExternalTorques(this.oniSolver, v113.m_AlignedPtr);\n\tv114 = Obi.ObiSolver::get_wind(this);\n\tOni::SetParticleWinds(this.oniSolver, v114.m_AlignedPtr);\n\tv115 = Obi.ObiSolver::get_positionDeltas(this);\n\tOni::SetParticlePositionDeltas(this.oniSolver, v115.m_AlignedPtr);\n\tv116 = Obi.ObiSolver::get_orientationDeltas(this);\n\tOni::SetParticleOrientationDeltas(this.oniSolver, v116.m_AlignedPtr);\n\tv117 = Obi.ObiSolver::get_positionConstraintCounts(this);\n\tOni::SetParticlePositionConstraintCounts(this.oniSolver, v117.m_AlignedPtr);\n\tv118 = Obi.ObiSolver::get_orientationConstraintCounts(this);\n\tOni::SetParticleOrientationConstraintCounts(this.oniSolver, v118.m_AlignedPtr);\n\tv119 = Obi.ObiSolver::get_normals(this);\n\tOni::SetParticleNormals(this.oniSolver, v119.m_AlignedPtr);\n\tv120 = Obi.ObiSolver::get_invInertiaTensors(this);\n\tOni::SetParticleInverseInertiaTensors(this.oniSolver, v120.m_AlignedPtr);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void PushParticleArrays()
		{
			ObiNativeVector4List obiNativeVector4List = positions;
			Oni.SetParticlePositions(OniSolver, obiNativeVector4List.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List2 = prevPositions;
			Oni.SetParticlePreviousPositions(OniSolver, obiNativeVector4List2.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List3 = restPositions;
			Oni.SetRestPositions(OniSolver, obiNativeVector4List3.m_AlignedPtr);
			ObiNativeQuaternionList obiNativeQuaternionList = orientations;
			Oni.SetParticleOrientations(OniSolver, obiNativeQuaternionList.m_AlignedPtr);
			ObiNativeQuaternionList obiNativeQuaternionList2 = prevOrientations;
			Oni.SetParticlePreviousOrientations(OniSolver, obiNativeQuaternionList2.m_AlignedPtr);
			ObiNativeQuaternionList obiNativeQuaternionList3 = restOrientations;
			Oni.SetRestOrientations(OniSolver, obiNativeQuaternionList3.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List4 = velocities;
			Oni.SetParticleVelocities(OniSolver, obiNativeVector4List4.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List5 = angularVelocities;
			Oni.SetParticleAngularVelocities(OniSolver, obiNativeVector4List5.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList = invMasses;
			Oni.SetParticleInverseMasses(OniSolver, obiNativeFloatList.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList2 = invRotationalMasses;
			Oni.SetParticleInverseRotationalMasses(OniSolver, obiNativeFloatList2.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List6 = principalRadii;
			Oni.SetParticlePrincipalRadii(OniSolver, obiNativeVector4List6.m_AlignedPtr);
			ObiNativeIntList obiNativeIntList = phases;
			Oni.SetParticlePhases(OniSolver, obiNativeIntList.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List7 = renderablePositions;
			Oni.SetRenderableParticlePositions(OniSolver, obiNativeVector4List7.m_AlignedPtr);
			ObiNativeQuaternionList obiNativeQuaternionList4 = renderableOrientations;
			Oni.SetRenderableParticleOrientations(OniSolver, obiNativeQuaternionList4.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List8 = anisotropies;
			Oni.SetParticleAnisotropies(OniSolver, obiNativeVector4List8.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList3 = smoothingRadii;
			Oni.SetParticleSmoothingRadii(OniSolver, obiNativeFloatList3.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList4 = buoyancies;
			Oni.SetParticleBuoyancy(OniSolver, obiNativeFloatList4.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList5 = restDensities;
			Oni.SetParticleRestDensities(OniSolver, obiNativeFloatList5.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList6 = viscosities;
			Oni.SetParticleViscosities(OniSolver, obiNativeFloatList6.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList7 = surfaceTension;
			Oni.SetParticleSurfaceTension(OniSolver, obiNativeFloatList7.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList8 = vortConfinement;
			Oni.SetParticleVorticityConfinement(OniSolver, obiNativeFloatList8.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList9 = atmosphericDrag;
			ObiNativeFloatList obiNativeFloatList10 = atmosphericPressure;
			Oni.SetParticleAtmosphericDragPressure(OniSolver, obiNativeFloatList9.m_AlignedPtr, obiNativeFloatList10.m_AlignedPtr);
			ObiNativeFloatList obiNativeFloatList11 = diffusion;
			Oni.SetParticleDiffusion(OniSolver, obiNativeFloatList11.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List9 = vorticities;
			Oni.SetParticleVorticities(OniSolver, obiNativeVector4List9.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List10 = fluidData;
			Oni.SetParticleFluidData(OniSolver, obiNativeVector4List10.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List11 = userData;
			Oni.SetParticleUserData(OniSolver, obiNativeVector4List11.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List12 = externalForces;
			Oni.SetParticleExternalForces(OniSolver, obiNativeVector4List12.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List13 = externalTorques;
			Oni.SetParticleExternalTorques(OniSolver, obiNativeVector4List13.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List14 = wind;
			Oni.SetParticleWinds(OniSolver, obiNativeVector4List14.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List15 = positionDeltas;
			Oni.SetParticlePositionDeltas(OniSolver, obiNativeVector4List15.m_AlignedPtr);
			ObiNativeQuaternionList obiNativeQuaternionList5 = orientationDeltas;
			Oni.SetParticleOrientationDeltas(OniSolver, obiNativeQuaternionList5.m_AlignedPtr);
			ObiNativeIntList obiNativeIntList2 = positionConstraintCounts;
			Oni.SetParticlePositionConstraintCounts(OniSolver, obiNativeIntList2.m_AlignedPtr);
			ObiNativeIntList obiNativeIntList3 = orientationConstraintCounts;
			Oni.SetParticleOrientationConstraintCounts(OniSolver, obiNativeIntList3.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List16 = normals;
			Oni.SetParticleNormals(OniSolver, obiNativeVector4List16.m_AlignedPtr);
			ObiNativeVector4List obiNativeVector4List17 = invInertiaTensors;
			Oni.SetParticleInverseInertiaTensors(OniSolver, obiNativeVector4List17.m_AlignedPtr);
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0x10278F8", Offset = "0x10278F8", Length = "0x37C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC8A08]);\n\tv25 = *([v24 @ X8_v4]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026246]) = v44;\nL_0017:\n\tv46 = Obi.ObiSolver::get_startPositions(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v46);\n\tv95 = Obi.ObiSolver::get_startOrientations(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v95);\n\tv96 = Obi.ObiSolver::get_positions(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v96);\n\tv97 = Obi.ObiSolver::get_prevPositions(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v97);\n\tv98 = Obi.ObiSolver::get_restPositions(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v98);\n\tv99 = Obi.ObiSolver::get_velocities(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v99);\n\tv100 = Obi.ObiSolver::get_orientations(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v100);\n\tv101 = Obi.ObiSolver::get_prevOrientations(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v101);\n\tv102 = Obi.ObiSolver::get_restOrientations(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v102);\n\tv103 = Obi.ObiSolver::get_angularVelocities(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v103);\n\tv104 = Obi.ObiSolver::get_invMasses(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v104);\n\tv105 = Obi.ObiSolver::get_invRotationalMasses(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v105);\n\tv106 = Obi.ObiSolver::get_principalRadii(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v106);\n\tv107 = Obi.ObiSolver::get_phases(this);\n\tObi.ObiNativeList`1<System.Int32>::Dispose(v107);\n\tv108 = Obi.ObiSolver::get_renderablePositions(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v108);\n\tv109 = Obi.ObiSolver::get_renderableOrientations(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v109);\n\tv110 = Obi.ObiSolver::get_anisotropies(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v110);\n\tv111 = Obi.ObiSolver::get_smoothingRadii(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v111);\n\tv112 = Obi.ObiSolver::get_buoyancies(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v112);\n\tv113 = Obi.ObiSolver::get_restDensities(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v113);\n\tv114 = Obi.ObiSolver::get_viscosities(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v114);\n\tv115 = Obi.ObiSolver::get_surfaceTension(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v115);\n\tv116 = Obi.ObiSolver::get_vortConfinement(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v116);\n\tv117 = Obi.ObiSolver::get_atmosphericDrag(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v117);\n\tv118 = Obi.ObiSolver::get_atmosphericPressure(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v118);\n\tv119 = Obi.ObiSolver::get_diffusion(this);\n\tObi.ObiNativeList`1<System.Single>::Dispose(v119);\n\tv120 = Obi.ObiSolver::get_vorticities(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v120);\n\tv121 = Obi.ObiSolver::get_fluidData(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v121);\n\tv122 = Obi.ObiSolver::get_userData(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v122);\n\tv123 = Obi.ObiSolver::get_externalForces(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v123);\n\tv124 = Obi.ObiSolver::get_externalTorques(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v124);\n\tv125 = Obi.ObiSolver::get_wind(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v125);\n\tv126 = Obi.ObiSolver::get_positionDeltas(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v126);\n\tv127 = Obi.ObiSolver::get_orientationDeltas(this);\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::Dispose(v127);\n\tv128 = Obi.ObiSolver::get_positionConstraintCounts(this);\n\tObi.ObiNativeList`1<System.Int32>::Dispose(v128);\n\tv129 = Obi.ObiSolver::get_orientationConstraintCounts(this);\n\tObi.ObiNativeList`1<System.Int32>::Dispose(v129);\n\tv130 = Obi.ObiSolver::get_normals(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v130);\n\tv131 = Obi.ObiSolver::get_invInertiaTensors(this);\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::Dispose(v131);\n\tv234 = this + 0x1F8;\n\tv186 = 0x6D26F0(v234, 0, 0x138, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 186 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void FreeParticleArrays()
		{
			//IL_0392: Expected O, but got I
			ObiNativeVector4List obiNativeVector4List = startPositions;
			obiNativeVector4List.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList = startOrientations;
			obiNativeQuaternionList.Dispose();
			ObiNativeVector4List obiNativeVector4List2 = positions;
			obiNativeVector4List2.Dispose();
			ObiNativeVector4List obiNativeVector4List3 = prevPositions;
			obiNativeVector4List3.Dispose();
			ObiNativeVector4List obiNativeVector4List4 = restPositions;
			obiNativeVector4List4.Dispose();
			ObiNativeVector4List obiNativeVector4List5 = velocities;
			obiNativeVector4List5.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList2 = orientations;
			obiNativeQuaternionList2.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList3 = prevOrientations;
			obiNativeQuaternionList3.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList4 = restOrientations;
			obiNativeQuaternionList4.Dispose();
			ObiNativeVector4List obiNativeVector4List6 = angularVelocities;
			obiNativeVector4List6.Dispose();
			ObiNativeFloatList obiNativeFloatList = invMasses;
			obiNativeFloatList.Dispose();
			ObiNativeFloatList obiNativeFloatList2 = invRotationalMasses;
			obiNativeFloatList2.Dispose();
			ObiNativeVector4List obiNativeVector4List7 = principalRadii;
			obiNativeVector4List7.Dispose();
			ObiNativeIntList obiNativeIntList = phases;
			obiNativeIntList.Dispose();
			ObiNativeVector4List obiNativeVector4List8 = renderablePositions;
			obiNativeVector4List8.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList5 = renderableOrientations;
			obiNativeQuaternionList5.Dispose();
			ObiNativeVector4List obiNativeVector4List9 = anisotropies;
			obiNativeVector4List9.Dispose();
			ObiNativeFloatList obiNativeFloatList3 = smoothingRadii;
			obiNativeFloatList3.Dispose();
			ObiNativeFloatList obiNativeFloatList4 = buoyancies;
			obiNativeFloatList4.Dispose();
			ObiNativeFloatList obiNativeFloatList5 = restDensities;
			obiNativeFloatList5.Dispose();
			ObiNativeFloatList obiNativeFloatList6 = viscosities;
			obiNativeFloatList6.Dispose();
			ObiNativeFloatList obiNativeFloatList7 = surfaceTension;
			obiNativeFloatList7.Dispose();
			ObiNativeFloatList obiNativeFloatList8 = vortConfinement;
			obiNativeFloatList8.Dispose();
			ObiNativeFloatList obiNativeFloatList9 = atmosphericDrag;
			obiNativeFloatList9.Dispose();
			ObiNativeFloatList obiNativeFloatList10 = atmosphericPressure;
			obiNativeFloatList10.Dispose();
			ObiNativeFloatList obiNativeFloatList11 = diffusion;
			obiNativeFloatList11.Dispose();
			ObiNativeVector4List obiNativeVector4List10 = vorticities;
			obiNativeVector4List10.Dispose();
			ObiNativeVector4List obiNativeVector4List11 = fluidData;
			obiNativeVector4List11.Dispose();
			ObiNativeVector4List obiNativeVector4List12 = userData;
			obiNativeVector4List12.Dispose();
			ObiNativeVector4List obiNativeVector4List13 = externalForces;
			obiNativeVector4List13.Dispose();
			ObiNativeVector4List obiNativeVector4List14 = externalTorques;
			obiNativeVector4List14.Dispose();
			ObiNativeVector4List obiNativeVector4List15 = wind;
			obiNativeVector4List15.Dispose();
			ObiNativeVector4List obiNativeVector4List16 = positionDeltas;
			obiNativeVector4List16.Dispose();
			ObiNativeQuaternionList obiNativeQuaternionList6 = orientationDeltas;
			obiNativeQuaternionList6.Dispose();
			ObiNativeIntList obiNativeIntList2 = positionConstraintCounts;
			obiNativeIntList2.Dispose();
			ObiNativeIntList obiNativeIntList3 = orientationConstraintCounts;
			obiNativeIntList3.Dispose();
			ObiNativeVector4List obiNativeVector4List17 = normals;
			obiNativeVector4List17.Dispose();
			ObiNativeVector4List obiNativeVector4List18 = invInertiaTensors;
			obiNativeVector4List18.Dispose();
			object obj = (long)(IntPtr)this + 504L;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
		}

		[Token(Token = "0x6000340")]
		[Address(RVA = "0x1029404", Offset = "0x1029404", Length = "0x68C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EAFF28]);\n\tv29 = *([v28 @ X8_v17]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, count, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026247]) = v47;\nL_0019:\n\tv49 = Obi.ObiSolver::get_positions(this);\n\tv63 = v49.m_Count > count;\n\tif (v63) goto L_01CF;\n\tv399 = Obi.ObiSolver::get_startPositions(this);\n\t// 54 MakeStruct v180 @ AGG102948C_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v399, count, v180);\n\tv400 = Obi.ObiSolver::get_positions(this);\n\t// 66 MakeStruct v176 @ AGG10294B4_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v400, count, v176);\n\tv401 = Obi.ObiSolver::get_prevPositions(this);\n\t// 78 MakeStruct v172 @ AGG10294DC_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v401, count, v172);\n\tv402 = Obi.ObiSolver::get_restPositions(this);\n\t// 90 MakeStruct v168 @ AGG1029504_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v402, count, v168);\n\tv403 = Obi.ObiSolver::get_startOrientations(this);\n\t// 104 MakeStruct v161 @ AGG1029534_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v403, count, v161);\n\tv404 = Obi.ObiSolver::get_orientations(this);\n\t// 116 MakeStruct v157 @ AGG102955C_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v404, count, v157);\n\tv405 = Obi.ObiSolver::get_prevOrientations(this);\n\t// 128 MakeStruct v153 @ AGG1029584_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v405, count, v153);\n\tv406 = Obi.ObiSolver::get_restOrientations(this);\n\t// 140 MakeStruct v149 @ AGG10295AC_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v406, count, v149);\n\tv407 = Obi.ObiSolver::get_renderablePositions(this);\n\t// 152 MakeStruct v145 @ AGG10295D4_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v407, count, v145);\n\tv408 = Obi.ObiSolver::get_renderableOrientations(this);\n\t// 164 MakeStruct v141 @ AGG10295FC_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v408, count, v141);\n\tv409 = Obi.ObiSolver::get_velocities(this);\n\t// 176 MakeStruct v137 @ AGG1029624_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v409, count, v137);\n\tv410 = Obi.ObiSolver::get_angularVelocities(this);\n\t// 188 MakeStruct v133 @ AGG102964C_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v410, count, v133);\n\tv411 = Obi.ObiSolver::get_invMasses(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v411, count, 0f);\n\tv412 = Obi.ObiSolver::get_invRotationalMasses(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v412, count, 0f);\n\tv413 = Obi.ObiSolver::get_principalRadii(this);\n\t// 218 MakeStruct v129 @ AGG10296B4_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v413, count, v129);\n\tv414 = Obi.ObiSolver::get_phases(this);\n\tObi.ObiNativeList`1<System.Int32>::ResizeInitialized(v414, count, 0);\n\tv415 = Obi.ObiSolver::get_anisotropies(this);\n\tv117 = count << 1;\n\tv199 = count + v117;\n\t// 241 MakeStruct v113 @ AGG1029700_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v415, v199, v113);\n\tv416 = Obi.ObiSolver::get_smoothingRadii(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v416, count, 0f);\n\tv417 = Obi.ObiSolver::get_buoyancies(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v417, count, 0f);\n\tv418 = Obi.ObiSolver::get_restDensities(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v418, count, 0f);\n\tv419 = Obi.ObiSolver::get_viscosities(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v419, count, 0f);\n\tv420 = Obi.ObiSolver::get_surfaceTension(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v420, count, 0f);\n\tv421 = Obi.ObiSolver::get_vortConfinement(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v421, count, 0f);\n\tv422 = Obi.ObiSolver::get_atmosphericDrag(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v422, count, 0f);\n\tv423 = Obi.ObiSolver::get_atmosphericPressure(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v423, count, 0f);\n\tv424 = Obi.ObiSolver::get_diffusion(this);\n\tObi.ObiNativeList`1<System.Single>::ResizeInitialized(v424, count, 0f);\n\tv425 = Obi.ObiSolver::get_vorticities(this);\n\t// 325 MakeStruct v109 @ AGG1029824_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v425, count, v109);\n\tv426 = Obi.ObiSolver::get_fluidData(this);\n\t// 337 MakeStruct v105 @ AGG102984C_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v426, count, v105);\n\tv427 = Obi.ObiSolver::get_userData(this);\n\t// 349 MakeStruct v101 @ AGG1029874_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v427, count, v101);\n\tv428 = Obi.ObiSolver::get_externalForces(this);\n\t// 361 MakeStruct v97 @ AGG102989C_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v428, count, v97);\n\tv429 = Obi.ObiSolver::get_externalTorques(this);\n\t// 373 MakeStruct v93 @ AGG10298C4_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v429, count, v93);\n\tv430 = Obi.ObiSolver::get_wind(this);\n\t// 385 MakeStruct v89 @ AGG10298EC_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v430, count, v89);\n\tv431 = Obi.ObiSolver::get_positionDeltas(this);\n\t// 397 MakeStruct v85 @ AGG1029914_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v431, count, v85);\n\tv693 = Obi.ObiSolver::get_orientationDeltas(this);\n\tv81 = 0;\n\tv555 = Obi.ObiNativeList`1<System.Int32>::ResizeInitialized(&v81 @ stack_-50_v4, 0, Il2CppMethodInfo);\n\t// 420 MakeStruct v73 @ AGG102995C_2_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), 0, v695 @ stack_-4C, 0, v696 @ stack_-44\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::ResizeInitialized(v693, count, v73);\n\tv432 = Obi.ObiSolver::get_positionConstraintCounts(this);\n\tObi.ObiNativeList`1<System.Int32>::ResizeInitialized(v432, count, 0);\n\tv433 = Obi.ObiSolver::get_orientationConstraintCounts(this);\n\tObi.ObiNativeList`1<System.Int32>::ResizeInitialized(v433, count, 0);\n\tv434 = Obi.ObiSolver::get_normals(this);\n\t// 448 MakeStruct v69 @ AGG10299BC_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v434, count, v69);\n\tv435 = Obi.ObiSolver::get_invInertiaTensors(this);\n\t// 460 MakeStruct v486 @ AGG10299E4_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), 0, 0, 0, 0\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::ResizeInitialized(v435, count, v486);\nL_01CF:\n\tv498 = this + 0x98;\n\tv499 = this.activeParticles;\n\tv373 = v499.Length > count;\n\tif (v373) goto L_0206;\n\tv569 = count << 1;\n\tSystem.Array::Resize(v498, v569);\n\tv646 = this + 0x90;\n\tSystem.Array::Resize(v646, v569);\n\tv\n// ... truncated")]
		private unsafe void EnsureParticleArraysCapacity(int count)
		{
			//IL_091d: Expected O, but got I4
			//IL_094d: Expected F4, but got O
			//IL_0968: Expected F4, but got O
			ObiNativeVector4List obiNativeVector4List = positions;
			if (obiNativeVector4List.count <= count)
			{
				ObiNativeVector4List obiNativeVector4List2 = startPositions;
				Vector4 value = default(Vector4);
				value.x = 0f;
				value.y = 0f;
				value.z = 0f;
				value.w = 0f;
				obiNativeVector4List2.ResizeInitialized(count, value);
				ObiNativeVector4List obiNativeVector4List3 = positions;
				Vector4 value2 = default(Vector4);
				value2.x = 0f;
				value2.y = 0f;
				value2.z = 0f;
				value2.w = 0f;
				obiNativeVector4List3.ResizeInitialized(count, value2);
				ObiNativeVector4List obiNativeVector4List4 = prevPositions;
				Vector4 value3 = default(Vector4);
				value3.x = 0f;
				value3.y = 0f;
				value3.z = 0f;
				value3.w = 0f;
				obiNativeVector4List4.ResizeInitialized(count, value3);
				ObiNativeVector4List obiNativeVector4List5 = restPositions;
				Vector4 value4 = default(Vector4);
				value4.x = 0f;
				value4.y = 0f;
				value4.z = 0f;
				value4.w = 0f;
				obiNativeVector4List5.ResizeInitialized(count, value4);
				ObiNativeQuaternionList obiNativeQuaternionList = startOrientations;
				Quaternion value5 = default(Quaternion);
				value5.x = 0f;
				value5.y = 0f;
				value5.z = 0f;
				value5.w = 0f;
				obiNativeQuaternionList.ResizeInitialized(count, value5);
				ObiNativeQuaternionList obiNativeQuaternionList2 = orientations;
				Quaternion value6 = default(Quaternion);
				value6.x = 0f;
				value6.y = 0f;
				value6.z = 0f;
				value6.w = 0f;
				obiNativeQuaternionList2.ResizeInitialized(count, value6);
				ObiNativeQuaternionList obiNativeQuaternionList3 = prevOrientations;
				Quaternion value7 = default(Quaternion);
				value7.x = 0f;
				value7.y = 0f;
				value7.z = 0f;
				value7.w = 0f;
				obiNativeQuaternionList3.ResizeInitialized(count, value7);
				ObiNativeQuaternionList obiNativeQuaternionList4 = restOrientations;
				Quaternion value8 = default(Quaternion);
				value8.x = 0f;
				value8.y = 0f;
				value8.z = 0f;
				value8.w = 0f;
				obiNativeQuaternionList4.ResizeInitialized(count, value8);
				ObiNativeVector4List obiNativeVector4List6 = renderablePositions;
				Vector4 value9 = default(Vector4);
				value9.x = 0f;
				value9.y = 0f;
				value9.z = 0f;
				value9.w = 0f;
				obiNativeVector4List6.ResizeInitialized(count, value9);
				ObiNativeQuaternionList obiNativeQuaternionList5 = renderableOrientations;
				Quaternion value10 = default(Quaternion);
				value10.x = 0f;
				value10.y = 0f;
				value10.z = 0f;
				value10.w = 0f;
				obiNativeQuaternionList5.ResizeInitialized(count, value10);
				ObiNativeVector4List obiNativeVector4List7 = velocities;
				Vector4 value11 = default(Vector4);
				value11.x = 0f;
				value11.y = 0f;
				value11.z = 0f;
				value11.w = 0f;
				obiNativeVector4List7.ResizeInitialized(count, value11);
				ObiNativeVector4List obiNativeVector4List8 = angularVelocities;
				Vector4 value12 = default(Vector4);
				value12.x = 0f;
				value12.y = 0f;
				value12.z = 0f;
				value12.w = 0f;
				obiNativeVector4List8.ResizeInitialized(count, value12);
				ObiNativeFloatList obiNativeFloatList = invMasses;
				obiNativeFloatList.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList2 = invRotationalMasses;
				obiNativeFloatList2.ResizeInitialized(count, 0f);
				ObiNativeVector4List obiNativeVector4List9 = principalRadii;
				Vector4 value13 = default(Vector4);
				value13.x = 0f;
				value13.y = 0f;
				value13.z = 0f;
				value13.w = 0f;
				obiNativeVector4List9.ResizeInitialized(count, value13);
				ObiNativeIntList obiNativeIntList = phases;
				obiNativeIntList.ResizeInitialized(count, 0);
				ObiNativeVector4List obiNativeVector4List10 = anisotropies;
				int num = count << 1;
				int newCount = count + num;
				Vector4 value14 = default(Vector4);
				value14.x = 0f;
				value14.y = 0f;
				value14.z = 0f;
				value14.w = 0f;
				obiNativeVector4List10.ResizeInitialized(newCount, value14);
				ObiNativeFloatList obiNativeFloatList3 = smoothingRadii;
				obiNativeFloatList3.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList4 = buoyancies;
				obiNativeFloatList4.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList5 = restDensities;
				obiNativeFloatList5.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList6 = viscosities;
				obiNativeFloatList6.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList7 = surfaceTension;
				obiNativeFloatList7.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList8 = vortConfinement;
				obiNativeFloatList8.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList9 = atmosphericDrag;
				obiNativeFloatList9.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList10 = atmosphericPressure;
				obiNativeFloatList10.ResizeInitialized(count, 0f);
				ObiNativeFloatList obiNativeFloatList11 = diffusion;
				obiNativeFloatList11.ResizeInitialized(count, 0f);
				ObiNativeVector4List obiNativeVector4List11 = vorticities;
				Vector4 value15 = default(Vector4);
				value15.x = 0f;
				value15.y = 0f;
				value15.z = 0f;
				value15.w = 0f;
				obiNativeVector4List11.ResizeInitialized(count, value15);
				ObiNativeVector4List obiNativeVector4List12 = fluidData;
				Vector4 value16 = default(Vector4);
				value16.x = 0f;
				value16.y = 0f;
				value16.z = 0f;
				value16.w = 0f;
				obiNativeVector4List12.ResizeInitialized(count, value16);
				ObiNativeVector4List obiNativeVector4List13 = userData;
				Vector4 value17 = default(Vector4);
				value17.x = 0f;
				value17.y = 0f;
				value17.z = 0f;
				value17.w = 0f;
				obiNativeVector4List13.ResizeInitialized(count, value17);
				ObiNativeVector4List obiNativeVector4List14 = externalForces;
				Vector4 value18 = default(Vector4);
				value18.x = 0f;
				value18.y = 0f;
				value18.z = 0f;
				value18.w = 0f;
				obiNativeVector4List14.ResizeInitialized(count, value18);
				ObiNativeVector4List obiNativeVector4List15 = externalTorques;
				Vector4 value19 = default(Vector4);
				value19.x = 0f;
				value19.y = 0f;
				value19.z = 0f;
				value19.w = 0f;
				obiNativeVector4List15.ResizeInitialized(count, value19);
				ObiNativeVector4List obiNativeVector4List16 = wind;
				Vector4 value20 = default(Vector4);
				value20.x = 0f;
				value20.y = 0f;
				value20.z = 0f;
				value20.w = 0f;
				obiNativeVector4List16.ResizeInitialized(count, value20);
				ObiNativeVector4List obiNativeVector4List17 = positionDeltas;
				Vector4 value21 = default(Vector4);
				value21.x = 0f;
				value21.y = 0f;
				value21.z = 0f;
				value21.w = 0f;
				obiNativeVector4List17.ResizeInitialized(count, value21);
				ObiNativeQuaternionList obiNativeQuaternionList6 = orientationDeltas;
				object obj = 0;
				((ObiNativeList<int>)obj).ResizeInitialized(0, 0);
				Quaternion value22 = default(Quaternion);
				value22.x = 0f;
				object obj2 = default(object);
				value22.y = (float)obj2;
				value22.z = 0f;
				object obj3 = default(object);
				value22.w = (float)obj3;
				obiNativeQuaternionList6.ResizeInitialized(count, value22);
				ObiNativeIntList obiNativeIntList2 = positionConstraintCounts;
				obiNativeIntList2.ResizeInitialized(count, 0);
				ObiNativeIntList obiNativeIntList3 = orientationConstraintCounts;
				obiNativeIntList3.ResizeInitialized(count, 0);
				ObiNativeVector4List obiNativeVector4List18 = normals;
				Vector4 value23 = default(Vector4);
				value23.x = 0f;
				value23.y = 0f;
				value23.z = 0f;
				value23.w = 0f;
				obiNativeVector4List18.ResizeInitialized(count, value23);
				ObiNativeVector4List obiNativeVector4List19 = invInertiaTensors;
				Vector4 value24 = default(Vector4);
				value24.x = 0f;
				value24.y = 0f;
				value24.z = 0f;
				value24.w = 0f;
				obiNativeVector4List19.ResizeInitialized(count, value24);
			}
			ref int[] reference = ref *(int[]*)((long)(IntPtr)this + 152L);
			int[] array = reference;
			if (array.Length <= count)
			{
				int newSize = count << 1;
				Array.Resize(ref reference, newSize);
				Array.Resize(ref *(ParticleInActor[]*)((long)(IntPtr)this + 144L), newSize);
				Array.Resize(ref *(Color[]*)((long)(IntPtr)this + 504L), newSize);
				PushParticleArrays();
				ObiNativeVector4List obiNativeVector4List20 = positions;
				Oni.SetCapacity(OniSolver, obiNativeVector4List20.capacity);
			}
		}

		[Token(Token = "0x6000341")]
		[Address(RVA = "0x1029B38", Offset = "0x1029B38", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv38 = *([1EF5050]);\n\tv39 = *([v38 @ X8_v27]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, actor, particleIndices, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2026248]) = v56;\n\tgoto L_00A4;\nL_0026:\n\tv157 = v198 + 1;\n\tObi.ObiSolver::EnsureParticleArraysCapacity(this, v157);\n\tv253 = Obi.ObiSolver::get_particleToActor(this);\n\tv314 = v253[v198 @ X22_v7 (System.Int32)] == 0;\n\tif (v314) goto L_0066;\n\tv145 = Obi.ObiSolver::get_particleToActor(this);\n\tv153 = v145[v198 @ X22_v7 (System.Int32)];\n\tgoto L_0061;\n\tv343 = *([v339 @ X0_v27+E0]);\n\tv344 = v343 == 0;\n\tv345 = ~v344;\n\tif (v345) goto L_0061;\n\tv347 = \"il2cpp_codegen_runtime_class_init\"(v339, v134, v73, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0061:\n\tv191 = UnityEngine.Object::op_Equality(v153.actor, 0);\n\tv194 = v191 == 0;\n\tif (v194) goto L_00A4;\nL_0066:\n\tv335 = Obi.ObiSolver::get_particleToActor(this);\n\tv146 = new Obi.ObiSolver+ParticleInActor();\n\tSystem.Object::.ctor(v146);\n\t*([v146 @ X0_v21 (System.Object)+10]) = actor;\n\t*([v146 @ X0_v21 (System.Object)+18]) = v138;\n\tv342 = v146 == 0;\n\tif (v342) goto L_0087;\n\t// 119 IsInst v232 @ X0_v24, typeof(Obi.ObiSolver+ParticleInActor), v146 @ X0_v21 (System.Object)\n\tv234 = v232 == 0;\n\tif (v234) goto L_00BB;\nL_0087:\n\tv335[v198 @ X22_v7 (System.Int32)] = v146;\n\tv199 = v198 + 1;\n\tv188 = v138 + 1;\n\tparticleIndices[v138 @ X24_v6 (System.Int32)] = v198;\nL_00A4:\n\tv66 = v138 < particleIndices.Length;\n\tif (v66) goto L_0026;\n\treturn;\n\tv288 = new System.IndexOutOfRangeException();\nL_00B7:\n\tv297 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\n\tv160 = new System.NullReferenceException();\nL_00BB:\n\tv238 = new System.ArrayTypeMismatchException();\n\tgoto L_00B7;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AllocateParticles(ObiActor actor, int[] particleIndices)
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				if (num >= particleIndices.Length)
				{
					return;
				}
				int num3 = num2 + 1;
				EnsureParticleArraysCapacity(num3);
				ParticleInActor[] array = particleToActor;
				if (array[num2] != null)
				{
					ParticleInActor[] array2 = particleToActor;
					ParticleInActor particleInActor = array2[num2];
					bool flag = particleInActor.actor == null;
					bool flag2 = !flag;
					num2 = num3;
					if (flag2)
					{
						continue;
					}
				}
				ParticleInActor[] array3 = particleToActor;
				object obj = new ParticleInActor();
				if (obj != null)
				{
					object obj2 = obj as ParticleInActor;
					if (obj2 == null)
					{
						break;
					}
				}
				array3[num2] = (ParticleInActor)obj;
				int num4 = num2 + 1;
				int num5 = num + 1;
				particleIndices[num] = num2;
				num = num5;
				num2 = num4;
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			TypeLoadException ex2 = new TypeLoadException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000342")]
		[Address(RVA = "0x1029D34", Offset = "0x1029D34", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECD510]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, actor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026249]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, actor, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(actor, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_0031;\n\tgoto L_0079;\nL_0031:\n\tv88 = System.Collections.Generic.List`1<Obi.ObiActor>::IndexOf(this.actors, actor);\n\tv128 = v88 & 0x80000000;\n\tv129 = v128 == 0;\n\tif (v129) goto L_FFFFFFFF;\n\tv148 = Obi.ObiActor::get_blueprint(actor);\n\tgoto L_004B;\n\tv152 = *([v143 @ X8_v12+E0]);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tif (v154) goto L_004B;\n\tv159 = v143;\n\tv156 = \"il2cpp_codegen_runtime_class_init\"(v159, v147, v87, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_004B:\n\tv140 = UnityEngine.Object::op_Inequality(v148, 0);\n\tv141 = v140 == 0;\n\tif (v141) goto L_FFFFFFFF;\n\tv98 = Obi.ObiActor::get_blueprint(actor);\n\tv163 = Obi.ObiActorBlueprint::get_particleCount(v98);\n\t// 93 NewArr v168 @ X0_v25 (System.Int32[]), typeof(System.Int32[]), v163 @ X0_v23 (System.Int32)\n\tObi.ObiSolver::AllocateParticles(this, actor, v168);\n\tactor.solverIndices = v168;\n\tSystem.Collections.Generic.List`1<Obi.ObiActor>::Add(this.actors, actor);\n\tv139 = Obi.ObiActor::LoadBlueprint(actor, this);\nL_0079:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AddActor(ObiActor actor)
		{
			//IL_0063: Expected I4, but got I8
			if (actor == null)
			{
				return false;
			}
			int num = actors.IndexOf(actor);
			if ((int)(num & 0x80000000L) != 0)
			{
				ObiActorBlueprint blueprint = actor.blueprint;
				if (blueprint != null)
				{
					ObiActorBlueprint blueprint2 = actor.blueprint;
					int particleCount = blueprint2.particleCount;
					int[] array = new int[particleCount];
					AllocateParticles(actor, array);
					actor.solverIndices = array;
					actors.Add(actor);
					actor.LoadBlueprint(this);
				}
			}
			return true;
		}

		[Token(Token = "0x6000343")]
		[Address(RVA = "0x1027010", Offset = "0x1027010", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EDBA50]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, actor, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([202624A]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, actor, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(actor, 0);\n\tv62 = v60 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_FFFFFFFF;\n\tv109 = System.Collections.Generic.List`1<Obi.ObiActor>::IndexOf(this.actors, actor);\n\tv211 = v109 & 0x80000000;\n\tv212 = v211 == 0;\n\tv112 = ~v212;\n\tif (v112) goto L_FFFFFFFF;\n\tv239 = Obi.ObiActor::UnloadBlueprint(actor, this);\n\tv270 = actor.solverIndices;\nL_004D:\n\tv121 = v158 >= v270.Length;\n\tif (v121) goto L_0082;\n\tv171 = Obi.ObiSolver::get_particleToActor(this);\n\tv179 = actor.solverIndices;\n\tv274 = v158 < v179.Length;\n\tv155 = ~v274;\n\tif (v155) goto L_008D;\n\tv279 = v179[v158 @ X22_v7 (System.Int32)] < v171.Length;\n\tv250 = ~v279;\n\tif (v250) goto L_008D;\n\tv171[v179[v158 @ X22_v7 (System.Int32)]] = 0;\n\tv270 = actor.solverIndices;\n\tv158 = v158 + 1;\n\tv281 = actor.solverIndices == 0;\n\tv254 = ~v281;\n\tif (v254) goto L_004D;\n\tthrow System.NullReferenceException;\n\tgoto L_008C;\nL_0082:\n\tSystem.Collections.Generic.List`1<Obi.ObiActor>::RemoveAt(this.actors, v109);\n\tactor.solverIndices = 0;\nL_008C:\n\treturn returnVal1;\nL_008D:\n\tv277 = new System.IndexOutOfRangeException();\n\tthrow v277;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool RemoveActor(ObiActor actor)
		{
			//IL_0060: Expected I4, but got I8
			if (!(actor == null))
			{
				int num = actors.IndexOf(actor);
				if ((int)(num & 0x80000000L) == 0)
				{
					actor.UnloadBlueprint(this);
					int[] solverIndices = actor.solverIndices;
					int num2 = 0;
					while (true)
					{
						if (num2 < solverIndices.Length)
						{
							ParticleInActor[] array = particleToActor;
							int[] solverIndices2 = actor.solverIndices;
							if (num2 >= solverIndices2.Length || solverIndices2[num2] >= array.Length)
							{
								break;
							}
							array[solverIndices2[num2]] = null;
							solverIndices = actor.solverIndices;
							num2++;
							if (actor.solverIndices == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
						actors.RemoveAt(num);
						actor.solverIndices = null;
						return true;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
			}
			return false;
		}

		[Token(Token = "0x6000344")]
		[Address(RVA = "0x10277B8", Offset = "0x10277B8", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this + 0x54;\n\tOni::SetSolverParameters(this.oniSolver, v11);\n\tv14 = this + 0xF4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 4, v14);\n\tv18 = this + 0x104;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 3, v18);\n\tv21 = this + 0x114;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 9, v21);\n\tv24 = this + 0x124;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0xF, v24);\n\tv27 = this + 0x134;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0xB, v27);\n\tv30 = this + 0x144;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0x10, v30);\n\tv33 = this + 0x1B4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0xA, v33);\n\tv36 = this + 0x154;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0xC, v36);\n\tv39 = this + 0x164;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 1, v39);\n\tv42 = this + 0x174;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 5, v42);\n\tv45 = this + 0x184;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0, v45);\n\tv48 = this + 0x194;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 8, v48);\n\tv51 = this + 0x1A4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 0xE, v51);\n\tv54 = this + 0x1C4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 7, v54);\n\tv57 = this + 0x1D4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 6, v57);\n\tv60 = this + 0x1E4;\n\tOni::SetConstraintGroupParameters(this.oniSolver, 2, v60);\n\tv63 = this.OnUpdateParameters == 0;\n\tif (v63) goto L_0057;\n\tObi.ObiSolver+SolverCallback::Invoke(this.OnUpdateParameters, this);\n\treturn;\nL_0057:\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateParameters()
		{
			Oni.SetSolverParameters(OniSolver, ref *(Oni.SolverParameters*)((long)(IntPtr)this + 84L));
			Oni.SetConstraintGroupParameters(OniSolver, 4, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 244L));
			Oni.SetConstraintGroupParameters(OniSolver, 3, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 260L));
			Oni.SetConstraintGroupParameters(OniSolver, 9, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 276L));
			Oni.SetConstraintGroupParameters(OniSolver, 15, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 292L));
			Oni.SetConstraintGroupParameters(OniSolver, 11, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 308L));
			Oni.SetConstraintGroupParameters(OniSolver, 16, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 324L));
			Oni.SetConstraintGroupParameters(OniSolver, 10, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 436L));
			Oni.SetConstraintGroupParameters(OniSolver, 12, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 340L));
			Oni.SetConstraintGroupParameters(OniSolver, 1, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 356L));
			Oni.SetConstraintGroupParameters(OniSolver, 5, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 372L));
			Oni.SetConstraintGroupParameters(OniSolver, 0, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 388L));
			Oni.SetConstraintGroupParameters(OniSolver, 8, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 404L));
			Oni.SetConstraintGroupParameters(OniSolver, 14, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 420L));
			Oni.SetConstraintGroupParameters(OniSolver, 7, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 452L));
			Oni.SetConstraintGroupParameters(OniSolver, 6, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 468L));
			Oni.SetConstraintGroupParameters(OniSolver, 2, ref *(Oni.ConstraintParameters*)((long)(IntPtr)this + 484L));
			if (this.OnUpdateParameters != null)
			{
				this.OnUpdateParameters(this);
			}
		}

		[Token(Token = "0x6000345")]
		[Address(RVA = "0x102A3C8", Offset = "0x102A3C8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EB18F0]);\n\tv21 = *([v20 @ X8_v20]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202624B]) = v40;\nL_0015:\n\tv42 = ~this.activeParticleCountChanged;\n\tif (v42) goto L_0096;\n\tv246 = this.actors;\n\tthis.activeParticleCount = 0;\nL_0026:\n\tv257 = v177 >= v246._size;\n\tif (v257) goto L_008E;\n\tv261 = v246._size < v177;\n\tv172 = ~v261;\n\tv167 = v246._size - v177;\n\tv157 = v167 == 0;\n\tv262 = ~v157;\n\tv133 = v172 & v262;\n\tif (v133) goto L_0036;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0036:\n\tv264 = v246._items;\n\tv192 = v264[v177 @ X21_v6 (System.Int32)];\n\tv179 = UnityEngine.Behaviour::get_isActiveAndEnabled(v264[v177 @ X21_v6 (System.Int32)]);\n\tv267 = v179 == 0;\n\tif (v267) goto L_0084;\n\tv279 = *([v192 @ X20_v8 (UnityEngine.Behaviour)+60]) < 1;\n\tif (v279) goto L_0084;\n\tv189 = this.activeParticleCount;\nL_0051:\n\tv110 = *([v192 @ X20_v8 (UnityEngine.Behaviour)+68]);\n\tv301 = v123 < *([v110 @ X10_v7+18]);\n\tv174 = ~v301;\n\tif (v174) goto L_0097;\n\tv119 = this.activeParticles;\n\tv311 = v189 < v119.Length;\n\tv309 = ~v311;\n\tif (v309) goto L_0097;\n\tv312 = v123 << 2;\n\tv313 = v110 + v312;\n\tv123 = v123 + 1;\n\tv119[v189 @ X8_v14 (System.Int32)] = *([v313 @ X10_v8+20]);\n\tv189 = this.activeParticleCount + 1;\n\tthis.activeParticleCount = v189;\n\tv284 = v123 < *([v192 @ X20_v8 (UnityEngine.Behaviour)+60]);\n\tif (v284) goto L_0051;\nL_0084:\n\tv246 = this.actors;\n\tv177 = v177 + 1;\n\tv295 = this.actors == 0;\n\tv182 = ~v295;\n\tif (v182) goto L_0026;\n\tthrow System.NullReferenceException;\nL_008E:\n\tv94 = Oni::SetActiveParticles(this.oniSolver, this.activeParticles, this.activeParticleCount);\n\tthis.activeParticleCountChanged = 0;\nL_0096:\n\treturn;\nL_0097:\n\tv310 = new System.IndexOutOfRangeException();\n\tthrow v310;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void PushActiveParticles()
		{
			//IL_02c4: Expected O, but got I
			//IL_01b3: Expected O, but got I
			if (!activeParticleCountChanged)
			{
				return;
			}
			List<ObiActor> list = actors;
			activeParticleCount = 0;
			int num = 0;
			while (num < list.Count)
			{
				bool flag = list.Count < num;
				bool flag2 = !flag;
				int num2 = list.Count - num;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiActor[] items = list._items;
				Behaviour behaviour = items[num];
				if (items[num].isActiveAndEnabled)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X20_v8 (UnityEngine.Behaviour)+60]");
					if (0L >= 1L)
					{
						int num3 = activeParticleCount;
						int num4 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X20_v8 (UnityEngine.Behaviour)+68]");
							object obj = 0;
							int num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X10_v7+18]");
							if ((long)num5 < 0L)
							{
								int[] array = activeParticles;
								if (num3 < array.Length)
								{
									int num6 = num4 << 2;
									object obj2 = (long)(IntPtr)obj + (long)num6;
									num4++;
									int num7 = num3;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X10_v8+20]");
									array[num7] = 0;
									num3 = ++activeParticleCount;
									int num8 = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X20_v8 (UnityEngine.Behaviour)+60]");
									if ((long)num8 >= 0L)
									{
										break;
									}
									continue;
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
					}
				}
				list = actors;
				num++;
				if (actors == null)
				{
					throw new NullReferenceException();
				}
			}
			int num9 = Oni.SetActiveParticles(OniSolver, activeParticles, activeParticleCount);
			activeParticleCountChanged = false;
		}

		[Token(Token = "0x6000346")]
		[Address(RVA = "0x102A5BC", Offset = "0x102A5BC", Length = "0x780")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = &v26 @ stack_-1E0_v1;\n\tgoto L_001D;\n\tv35 = *([1ED5BB8]);\n\tv36 = *([v35 @ X8_v115]);\n\tv37 = \"il2cpp_codegen_initialize_method\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202624C]) = v55;\nL_001D:\n\tv56 = &v57 @ stack_-200;\n\t*([v25 @ X19_v1+178]) = 0;\n\t*([v25 @ X19_v1+170]) = 0;\n\t*([v25 @ X19_v1+168]) = 0;\n\t*([v25 @ X19_v1+160]) = 0;\n\t*([v25 @ X19_v1+148]) = 0;\n\t*([v25 @ X19_v1+150]) = 0;\n\t*([v25 @ X19_v1+140]) = 0;\n\tgoto L_0037;\n\tv65 = *([v61 @ X0_v2 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0037;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv69 = Obi.ObiSolver;\nL_0037:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v72.m_UpdateVisibilityPerfMarker);\n\tgoto L_0049;\n\tv81 = *([v77 @ X0_v5 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv82 = v81 == 0;\n\tv83 = ~v82;\n\tgoto L_0049;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v77, v73, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv87 = Obi.ObiSolver;\nL_0049:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v90.m_GetSolverBoundsPerfMarker);\n\tgoto L_0057;\n\tv102 = *([v98 @ X0_v8+E0]);\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tgoto L_0057;\n\tv106 = \"il2cpp_codegen_runtime_class_init\"(v98, v94, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0057:\n\tv110 = UnityEngine.Vector3::get_zero();\n\t*([v25 @ X19_v1+170]) = v110;\n\t*([v25 @ X19_v1+174]) = v110.y;\n\t*([v25 @ X19_v1+178]) = v110.z;\n\tv114 = UnityEngine.Vector3::get_zero();\n\t*([v25 @ X19_v1+160]) = v114;\n\t*([v25 @ X19_v1+164]) = v114.y;\n\t*([v25 @ X19_v1+168]) = v114.z;\n\tv118 = &v26 @ stack_-1E0_v1 + 0x170;\n\tv119 = &v26 @ stack_-1E0_v1 + 0x160;\n\tOni::GetBounds(this.oniSolver, v118, v119);\n\tv1209 = *([v25 @ X19_v1+174]);\n\tv1208 = *([v25 @ X19_v1+178]);\n\tv1205 = *([v25 @ X19_v1+160]);\n\tv1204 = *([v25 @ X19_v1+164]);\n\tv126 = this + 0xC4;\n\tv128 = 0x100E76C(v126, 0, v119, v40, v41, v42, v43, v44, *([v25 @ X19_v1+170]), *([v25 @ X19_v1+174]), *([v25 @ X19_v1+178]), *([v25 @ X19_v1+160]), *([v25 @ X19_v1+164]), *([v25 @ X19_v1+168]), v51, v52);\n\tv130 = 0;\n\t*([v56 @ X26_v1]) = 0x4E;\nL_0077:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v90.m_GetSolverBoundsPerfMarker);\n\tgoto L_0088;\nL_0088:\n\tv149 = *([v56 @ X26_v1+v130 @ X27_v3 (System.Int32)*4]) != 0x4E;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_0091;\n\tgoto L_018B;\nL_0091:\n\tv1192 = &v26 @ stack_-1E0_v1 + 0xC0;\n\t*([v25 @ X19_v1+D0]) = this.bounds.m_Extents.y;\n\t*([v1192 @ X28_v15]) = this.bounds;\n\tgoto L_00A1;\n\tv243 = *([v185 @ X0_v82+E0]);\n\tv244 = v243 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_00A1;\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v185, v133, v119, v40, v41, v42, v43, v44, v183, v121, v122, v123, v124, v125, v51, v52);\nL_00A1:\n\tv1210 = *([v1192 @ X28_v15]);\n\t*([v25 @ X19_v1+130]) = *([v25 @ X19_v1+D0]);\n\t*([v1192 @ X28_v15+60]) = *([v1192 @ X28_v15]);\n\tv252 = &v26 @ stack_-1E0_v1 + 0x120;\n\tv253 = Obi.ObiUtils::AreValid(v252);\n\tv286 = v253 == 0;\n\tif (v286) goto L_0239;\n\tgoto L_00B7;\n\tv445 = *([v330 @ X0_v86 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv446 = v445 == 0;\n\tv447 = ~v446;\n\tif (v447) goto L_00B7;\n\tv531 = \"il2cpp_codegen_runtime_class_init\"(v330, v133, v119, v40, v41, v42, v43, v44, v251, v121, v122, v123, v124, v125, v51, v52);\n\tv449 = Obi.ObiSolver;\nL_00B7:\n\t*([v25 @ X19_v1+10]) = v452.m_TestBoundsPerfMarker;\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v452.m_TestBoundsPerfMarker);\n\t*([v25 @ X19_v1+110]) = this.bounds.m_Extents.y;\n\t*([v1192 @ X28_v15+40]) = this.bounds;\n\tv279 = UnityEngine.Component::get_transform(this);\n\tv680 = UnityEngine.Transform::get_localToWorldMatrix(v279);\n\tgoto L_00D1;\n\tv955 = *([v796 @ X0_v92+E0]);\n\tv956 = v955 == 0;\n\tv957 = ~v956;\n\tif (v957) goto L_00D1;\n\tv959 = \"il2cpp_codegen_runtime_class_init\"(v796, v679, v119, v40, v41, v42, v43, v44, v276, v121, v122, v123, v124, v125, v51, v52);\nL_00D1:\n\tv1208 = *([v1192 @ X28_v15+30]);\n\tv1204 = *([v1192 @ X28_v15+10]);\n\tv1209 = *([v1192 @ X28_v15+20]);\n\tv1205 = *([v1192 @ X28_v15]);\n\t*([v25 @ X19_v1+A0]) = *([v25 @ X19_v1+110]);\n\t*([v25 @ X19_v1+80]) = *([v1192 @ X28_v15+30]);\n\t*([v25 @ X19_v1+90]) = *([v1192 @ X28_v15+40]);\n\t*([v25 @ X19_v1+60]) = *([v1192 @ X28_v15+10]);\n\t*([v25 @ X19_v1+70]) = *([v1192 @ X28_v15+20]);\n\t*([v25 @ X19_v1+50]) = *([v1192 @ X28_v15]);\n\tv965 = &v26 @ stack_-1E0_v1 + 0x90;\n\tv966 = &v26 @ stack_-1E0_v1 + 0x50;\n\tv967 = Obi.ObiUtils::Transform(v965, v966);\n\tthis.bounds.m_Extents.y = *([v25 @ X19_v1+B8]);\n\tv1210 = *([v25 @ X19_v1+A8]);\n\tthis.bounds = *([v25 @ X19_v1+A8]);\n\tgoto L_00F3;\n\tv1081 = *([v1049 @ X0_v96 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv1082 = v1081 == 0;\n\tv1083 = ~v1082;\n\tif (v1083) goto L_00F3;\n\tv1150 = \"il2cpp_codegen_runtime_class_init\"(v1049, v966, v119, v40, v41, v42, v43, v44, v320, v228, v226, v220, v218, v125, v51, v52);\n\tv1085 = Obi.ObiSolver;\nL_00F3:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v1088.m_GetAllCamerasPerfMarker);\n\tv405 = this + 0xE8;\n\tv1152 = UnityEngine.Camera::get_allCamerasCount();\n\tSystem.Array::Resize(v405, v1152);\n\tv1226 = UnityEngine.Camera::GetAllCameras(*([v405 @ X24_v25 (UnityEngine.Camera[]&)]));\n\tv1211 = v665 + 1;\n\t*([v56 @ X26_v1+v1211 @ X27_v22 (System.Int32)*4]) = 0xBD;\nL_0106:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v1088.m_GetAllCamerasPerfMarker);\n\tv1249 = v1211 + 1;\n\tv1251 = v1249 == 0;\n\tif (v1251) goto L_FFFFFFFF;\n\tv1264 = *([v56 @ X26_v1+v1211 @ X27_v22 (System.Int32)*4]) != 0xBD;\n\tif (v1264) goto L_FFFFFFFF;\n\tv1211 = v1211 - 1;\n\tgoto L_011E;\n\tgoto L_0192;\nL_011E:\n\tv193 = this.sceneCameras;\n\tv238 = v193.Length;\n\tv1279 = v193.Length < 1;\n\tif (v1279) goto L_0159;\nL_012F:\n\tv1305 = v198 < v238;\n\tv212 = ~v1305;\n\tif (v212) goto L_0184;\n\tUnityEngine.GeometryUtility::CalculateFrustumPlanes(v193[v198 @ X25_v28 (System.Int32)], this.planes);\n\t*([v25 @ X19_v1+40]) = this.bounds.m_Extents.y;\n\tv1210 = this.bounds;\n\t*([v25 @ X19_v1+30]) = this.bounds;\n\tv627 = &v26 @ stack_-1E0_v1 + 0x30;\n\tv1213 = UnityEngine.GeometryUtility::TestPlanesAABB(this.planes, v627);\n\tv1314 = v1213 == 0;\n\tv1291 = ~v1314;\n\tif (v1291) goto L_015E;\n\tv238 = v193.Length;\n\tv198 = v198 + 1;\n\tv1282 = v198 < v193.Length;\n\tif (v1282) goto L_012F;\nL_0159:\n\tv665 = v1211 + 1;\nL_015B:\n\t*([v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]) = v1148;\n\tgoto L_0214;\nL_015E:\n\tv1317 = ~this.isVisible;\n\tv1215 = ~v1317;\n\tif (v1215) goto L_01F7;\n\tthis.isVisible = 1;\n\tv636 = this.actors == 0;\n\tif (v636) goto L_0194;\n\tv1322 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(this.actors);\n\tv1210 = *([v1192 @ X28_v15+40]);\n\t*([v25 @ X19_v1+150]) = *([v25 @ X19_v1+110]);\n\t*([v1192 @ X28_v15+80]) = *([v1192 @ X28_v15+40]);\nL_0172:\n\tv1333 = &v26 @ stack_-1E0_v1 + 0x140;\n\tv1069 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(v1333);\n\tv1071 = v1069 == 0;\n\tif (v1071) goto L_0180;\n\tv525 = *([v25 @ X19_v1+150]);\n\tv1332 = *([v525 @ X0_v117]);\n\t*([v1332 @ X8_v100+310])(v1330, v525, this.isVisible, *([v1332 @ X8_v100+318]), v40, v41, v42, v43, v44, v1210, v1209, v1208, v1205, v1204, *([v25 @ X19_v1+168]), v51, v52);\n\tgoto L_0172;\nL_0180:\n\tv665 = v1211 + 1;\n\t*([v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]) = 0x1B2;\n\tgoto L_01E1;\nL_0184:\n\tv1310 = new System.IndexOutOfRangeException();\n\tthrow v1310;\nL_018B:\n\tv242 = new System.TypeLoadException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\nL_0192:\n\tv444 = new System.TypeLoadException();\n\tv530 = new System.NullReferenceException();\nL_0194:\n\tv639 = new System.NullReferenceException();\n\tgoto L_01D8;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_019D;\n\tgoto L_019D;\nL_019D:\n\tX8 = X1;\n\tX2 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_020C;\n\tX0 = X2;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto\n// ... truncated")]
		private unsafe void UpdateVisibility()
		{
			//IL_0b21: Expected I, but got O
			//IL_0b30: Expected I, but got O
			//IL_0097: Expected O, but got I
			//IL_00a7: Expected O, but got I
			//IL_00b7: Expected O, but got I
			//IL_00c7: Expected O, but got I
			//IL_00d3: Expected O, but got I
			//IL_00f9: Expected O, but got I4
			//IL_0c5c: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_019a: Expected O, but got I
			//IL_09db: Expected I, but got O
			//IL_0b45: Expected I, but got O
			//IL_083c: Expected O, but got I
			//IL_0cca: Expected O, but got I
			//IL_01f4: Expected O, but got I
			//IL_0204: Expected O, but got I
			//IL_0214: Expected O, but got I
			//IL_0271: Expected O, but got I
			//IL_0280: Expected O, but got I
			//IL_02ad: Expected F4, but got I
			//IL_02bd: Expected O, but got I
			//IL_02cf: Expected O, but got I
			//IL_0b76: Expected I, but got O
			//IL_08ce: Expected O, but got I
			//IL_086b: Expected O, but got I
			//IL_0c27: Expected I, but got O
			//IL_0934: Expected I, but got O
			//IL_09bd: Expected I4, but got O
			//IL_05fd: Expected I4, but got O
			//IL_0709: Expected I4, but got O
			//IL_0620: Expected O, but got I
			//IL_03d1: Expected O, but got I
			//IL_07b8: Expected I4, but got I8
			//IL_04bf: Expected I4, but got O
			//IL_04f4: Expected O, but got I
			//IL_0bd3: Expected O, but got I
			//IL_0523: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			object obj4 = default(object);
			object obj3 = obj4;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateVisibilityPerfMarker);
			ProfilerMarker.Internal_Begin((IntPtr)m_GetSolverBoundsPerfMarker);
			Vector3 zero = Vector3.zero;
			_ = zero.y;
			_ = zero.z;
			Vector3 zero2 = Vector3.zero;
			_ = zero2.y;
			_ = zero2.z;
			Oni.GetBounds(OniSolver, ref *(Vector3*)((long)(IntPtr)obj2 + 368L), ref *(Vector3*)((long)(IntPtr)obj2 + 352L));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+174]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+178]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+160]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+164]");
			object obj8 = 0;
			object obj9 = (long)(IntPtr)this + 196L;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E76C (inside UnityEngine.Bounds::op_Inequality +0x4C)");
			int num = 0;
			obj3 = 78;
			ProfilerMarker.Internal_End((IntPtr)m_GetSolverBoundsPerfMarker);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v130 @ X27_v3 (System.Int32)*4]");
			Bounds bounds;
			int num3;
			int num4;
			int num2;
			int num7;
			if ((IntPtr)0 == (IntPtr)78)
			{
				num2 = -1;
				object obj10 = (long)(IntPtr)obj2 + 192L;
				_ = this.bounds.m_Extents.y;
				obj10 = this.bounds;
				bounds = (Bounds)obj10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+D0]");
				_ = 0;
				Bounds bounds2 = (Bounds)((long)(IntPtr)obj2 + 288L);
				bool flag = bounds2.AreValid();
				bool flag2 = !flag;
				num3 = 0;
				if (!flag2)
				{
					_ = m_TestBoundsPerfMarker;
					ProfilerMarker.Internal_Begin((IntPtr)m_TestBoundsPerfMarker);
					_ = this.bounds.m_Extents.y;
					_ = this.bounds;
					Transform transform = base.transform;
					Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+30]");
					obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+10]");
					obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+20]");
					obj5 = 0;
					obj7 = obj10;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+110]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+20]");
					_ = 0;
					Bounds b = (Bounds)((long)(IntPtr)obj2 + 144L);
					Matrix4x4 m = (Matrix4x4)((long)(IntPtr)obj2 + 80L);
					Bounds bounds3 = b.Transform(m);
					ref Vector3 extents = ref this.bounds.m_Extents;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+B8]");
					extents.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+A8]");
					bounds = (Bounds)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+A8]");
					this.bounds = (Bounds)0;
					ProfilerMarker.Internal_Begin((IntPtr)m_GetAllCamerasPerfMarker);
					ref Camera[] reference = ref *(Camera[]*)((long)(IntPtr)this + 232L);
					int allCamerasCount = Camera.allCamerasCount;
					Array.Resize(ref reference, allCamerasCount);
					int allCameras = Camera.GetAllCameras(reference);
					num4 = num2 + 1;
					_ = 189;
					ProfilerMarker.Internal_End((IntPtr)m_GetAllCamerasPerfMarker);
					if (num4 + 1 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v1211 @ X27_v22 (System.Int32)*4]");
						if ((IntPtr)0 == (IntPtr)189)
						{
							num4--;
							Camera[] array = reference;
							int num5 = array.Length;
							if (array.Length < 1)
							{
								goto IL_0447;
							}
							int num6 = 0;
							Bounds bounds4;
							while (true)
							{
								if (num6 < num5)
								{
									GeometryUtility.CalculateFrustumPlanes(array[num6], planes);
									_ = this.bounds.m_Extents.y;
									bounds = this.bounds;
									_ = this.bounds;
									bounds4 = (Bounds)((long)(IntPtr)obj2 + 48L);
									if (GeometryUtility.TestPlanesAABB(planes, bounds4))
									{
										break;
									}
									num5 = array.Length;
									num6++;
									if (num6 < array.Length)
									{
										continue;
									}
									goto IL_0447;
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
							}
							bool flag3 = !IsVisible;
							bool flag4 = !flag3;
							num3 = 0;
							if (!flag4)
							{
								isVisible = true;
								bool flag5 = actors == null;
								num7 = (int)bounds4;
								num2 = num4;
								if (flag5)
								{
									goto IL_05a8;
								}
								List<ObiActor>.Enumerator enumerator = actors.GetEnumerator();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+40]");
								bounds = (Bounds)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+110]");
								_ = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1192 @ X28_v15+40]");
								_ = 0;
								while (true)
								{
									List<ObiActor>.Enumerator enumerator2 = (List<ObiActor>.Enumerator)((long)(IntPtr)obj2 + 320L);
									if (!((List<ObiActor>.Enumerator*)enumerator2)->MoveNext())
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+150]");
									object obj11 = 0;
									object obj12 = obj11;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1332 @ X8_v100+310] (should have been resolved before IL gen)");
								}
								num2 = num4 + 1;
								_ = 434;
								num3 = 0;
								goto IL_0611;
							}
							goto IL_06a9;
						}
					}
					num2 = num4;
					TypeLoadException ex2 = new TypeLoadException();
					NullReferenceException ex3 = new NullReferenceException();
					num7 = 0;
					goto IL_05a8;
				}
				goto IL_07f2;
			}
			num2 = 0;
			TypeLoadException ex4 = new TypeLoadException();
			throw new NullReferenceException();
			IL_0a8b:
			int num8;
			if (num8 == 0)
			{
				return;
			}
			TypeLoadException ex5 = new TypeLoadException();
			NullReferenceException ex6 = null;
			num7 = 0;
			goto IL_0ad0;
			IL_0ad0:
			Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_0447:
			num2 = num4 + 1;
			num3 = 0;
			int num9 = 345;
			goto IL_071d;
			IL_0c61:
			int num10;
			bool flag6 = num10 != 1;
			object obj13 = obj8;
			object obj14 = obj7;
			object obj15 = obj6;
			object obj16 = obj5;
			Bounds bounds5 = bounds;
			ex5 = (TypeLoadException)(object)ex6;
			if (!flag6)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj17 = default(object);
				num3 = (int)obj17;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				goto IL_09d1;
			}
			goto IL_0ad0;
			IL_0611:
			List<ObiActor>.Enumerator enumerator3 = (List<ObiActor>.Enumerator)((long)(IntPtr)obj2 + 320L);
			((List<ObiActor>.Enumerator*)enumerator3)->Dispose();
			if (num2 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)434)
				{
					goto IL_071d;
				}
			}
			bool flag7 = num3 == 0;
			bool flag8 = !flag7;
			num4 = num2;
			if (!flag8)
			{
				goto IL_06a9;
			}
			TypeLoadException ex7 = new TypeLoadException();
			ex6 = (NullReferenceException)(object)ex7;
			num7 = 0;
			num10 = 0;
			goto IL_0bfd;
			IL_07f2:
			TypeLoadException ex8;
			if (IsVisible)
			{
				isVisible = false;
				List<ObiActor>.Enumerator enumerator4 = actors.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+18]");
				bounds = (Bounds)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+18]");
				_ = 0;
				while (true)
				{
					List<ObiActor>.Enumerator enumerator5 = (List<ObiActor>.Enumerator)((long)(IntPtr)obj2 + 320L);
					if (!((List<ObiActor>.Enumerator*)enumerator5)->MoveNext())
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+150]");
					object obj18 = 0;
					object obj19 = obj18;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v688 @ X8_v42+310] (should have been resolved before IL gen)");
				}
				num2++;
				_ = 434;
				List<ObiActor>.Enumerator enumerator6 = (List<ObiActor>.Enumerator)((long)(IntPtr)obj2 + 320L);
				((List<ObiActor>.Enumerator*)enumerator6)->Dispose();
				if (num2 + 1 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]");
					if ((IntPtr)0 == (IntPtr)434)
					{
						goto IL_092a;
					}
				}
				if (num3 != 0)
				{
					ex8 = new TypeLoadException();
					num7 = 0;
					goto IL_0991;
				}
			}
			num2++;
			_ = 434;
			goto IL_09d1;
			IL_09d1:
			ProfilerMarker.Internal_End((IntPtr)m_UpdateVisibilityPerfMarker);
			int num11 = num2 + 1;
			bool flag9 = num11 == 0;
			num8 = num3;
			obj13 = obj8;
			obj14 = obj7;
			obj15 = obj6;
			obj16 = obj5;
			bounds5 = bounds;
			if (!flag9)
			{
				goto IL_0a36;
			}
			goto IL_0a8b;
			IL_0bfd:
			if (num10 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj20 = default(object);
				num3 = (int)obj20;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				goto IL_071d;
			}
			goto IL_0c61;
			IL_0a36:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]");
			bool flag10 = (IntPtr)0 == (IntPtr)434;
			num8 = num3;
			obj13 = obj8;
			obj14 = obj7;
			obj15 = obj6;
			obj16 = obj5;
			bounds5 = bounds;
			if (!flag10)
			{
				goto IL_0a8b;
			}
			return;
			IL_092a:
			ProfilerMarker.Internal_End((IntPtr)m_UpdateVisibilityPerfMarker);
			goto IL_0a36;
			IL_0991:
			ex6 = (NullReferenceException)(object)ex8;
			num10 = num7;
			goto IL_0c61;
			IL_06a9:
			num2 = num4 + 1;
			num9 = 434;
			goto IL_071d;
			IL_05a8:
			NullReferenceException ex9 = new NullReferenceException();
			bool flag11 = num7 != 1;
			ex6 = ex9;
			num10 = num7;
			if (!flag11)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj21 = default(object);
				num3 = (int)obj21;
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				goto IL_0611;
			}
			goto IL_0bfd;
			IL_071d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ X19_v1+10]");
			ProfilerMarker.Internal_End((IntPtr)0);
			if (num2 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)434)
				{
					goto IL_092a;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X26_v1+v665 @ X27_v15 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)345)
				{
					int num12 = (int)(0xFFFFFFFFL ^ num2);
					num2 += num12;
					goto IL_07f2;
				}
			}
			if (num3 == 0)
			{
				goto IL_07f2;
			}
			ex8 = new TypeLoadException();
			num7 = 0;
			Bounds bounds6 = default(Bounds);
			bounds = bounds6;
			goto IL_0991;
		}

		[Token(Token = "0x6000347")]
		[Address(RVA = "0x1027694", Offset = "0x1027694", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = *([1F08AD0]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202624D]) = v44;\nL_001E:\n\tv53 = UnityEngine.Component::get_transform(this);\n\tv56 = UnityEngine.Transform::get_position(v53);\n\tgoto L_0039;\n\tv121 = *([v117 @ X0_v6+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0039;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v117, v55, v28, v29, v30, v31, v32, v33, v56, v113, v114, v37, v38, v39, v40, v41);\nL_0039:\n\tv99 = UnityEngine.Vector4::op_Implicit(v56);\n\tv105 = UnityEngine.Component::get_transform(this);\n\tv56 = UnityEngine.Transform::get_lossyScale(v105);\n\tv100 = UnityEngine.Vector4::op_Implicit(v56);\n\tv106 = UnityEngine.Component::get_transform(this);\n\tv170 = UnityEngine.Transform::get_rotation(v106);\n\tOni::InitializeFrame(this.oniSolver, &v99 @ V0_v4 (UnityEngine.Vector4), &v100 @ V0_v6 (UnityEngine.Vector4), &v170 @ V0_v7 (UnityEngine.Quaternion));\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitializeTransformFrame()
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector4 translation = position;
			Transform transform2 = base.transform;
			position = transform2.lossyScale;
			Vector4 scale = position;
			Transform transform3 = base.transform;
			Quaternion rotation = transform3.rotation;
			Oni.InitializeFrame(OniSolver, ref translation, ref scale, ref rotation);
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x102B564", Offset = "0x102B564", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv28 = *([1EB8ED0]);\n\tv29 = *([v28 @ X8_v11]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, dt, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202624E]) = v47;\nL_0020:\n\tv56 = UnityEngine.Component::get_transform(this);\n\tv59 = UnityEngine.Transform::get_position(v56);\n\tgoto L_003B;\n\tv124 = *([v120 @ X0_v6+E0]);\n\tv125 = v124 == 0;\n\tv126 = ~v125;\n\tif (v126) goto L_003B;\n\tv128 = \"il2cpp_codegen_runtime_class_init\"(v120, v58, v32, v33, v34, v35, v36, v37, v59, v116, v117, v40, v41, v42, v43, v44);\nL_003B:\n\tv102 = UnityEngine.Vector4::op_Implicit(v59);\n\tv108 = UnityEngine.Component::get_transform(this);\n\tv59 = UnityEngine.Transform::get_lossyScale(v108);\n\tv103 = UnityEngine.Vector4::op_Implicit(v59);\n\tv109 = UnityEngine.Component::get_transform(this);\n\tv198 = UnityEngine.Transform::get_rotation(v109);\n\tOni::UpdateFrame(this.oniSolver, &v102 @ V0_v4 (UnityEngine.Vector4), &v103 @ V0_v6 (UnityEngine.Vector4), &v198 @ V0_v7 (UnityEngine.Quaternion), dt);\n\tOni::ApplyFrame(this.oniSolver, 0f, 0f, this.worldLinearInertiaScale, this.worldAngularInertiaScale, dt);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateTransformFrame(float dt)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector4 translation = position;
			Transform transform2 = base.transform;
			position = transform2.lossyScale;
			Vector4 scale = position;
			Transform transform3 = base.transform;
			Quaternion rotation = transform3.rotation;
			Oni.UpdateFrame(OniSolver, ref translation, ref scale, ref rotation, dt);
			Oni.ApplyFrame(OniSolver, 0f, 0f, worldLinearInertiaScale, worldAngularInertiaScale, dt);
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x102B850", Offset = "0x102B850", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA8C80]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, stepTime, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202624F]) = v41;\nL_0019:\n\tv46 = 0;\n\tv47 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv51 = v47 == 0;\n\tif (v51) goto L_0098;\n\tv55 = System.IntPtr::op_Equality(this.oniSolver, 0);\n\tv113 = v55 == 0;\n\tv99 = ~v113;\n\tif (v99) goto L_0098;\n\tv153 = Obi.ObiSolver::get_startPositions(this);\n\tv156 = Obi.ObiSolver::get_positions(this);\n\tv158 = v153 == 0;\n\tif (v158) goto L_006F;\n\tObi.ObiNativeList`1<UnityEngine.Vector4>::CopyFrom(v153, v156);\n\tv185 = Obi.ObiSolver::get_startOrientations(this);\n\tv174 = Obi.ObiSolver::get_orientations(this);\n\tv177 = v185 == 0;\n\tif (v177) goto L_006F;\n\tObi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v185, v174);\n\tObi.ObiSolver::PushActiveParticles(this);\n\tOni::RecalculateInertiaTensors(this.oniSolver);\n\tv218 = this.OnBeginStep == 0;\n\tif (v218) goto L_004F;\n\tObi.ObiSolver+SolverStepCallback::Invoke(this.OnBeginStep, this, stepTime);\nL_004F:\n\tv193 = this.actors == 0;\n\tif (v193) goto L_006F;\n\tv236 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(this.actors);\nL_005A:\n\tv248 = Obi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>), Il2CppMethodInfo);\n\tv249 = v248 & 1;\n\tv226 = v249 == 0;\n\tif (v226) goto L_006B;\n\tv250 = 0;\n\tv246 = *([v250 @ X0_v45 (System.Int32)]);\n\t*([v246 @ X8_v25+2D0])(v244, 0, *([v246 @ X8_v25+2D8]), Il2CppMethodInfo, v27, v28, v29, v30, v31, stepTime, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005A;\nL_006B:\n\tv224 = Obi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>), Il2CppMethodInfo);\n\tgoto L_0089;\n\tthrow System.NullReferenceException;\nL_006F:\n\tv197 = new System.NullReferenceException();\n\tgoto L_007B;\n\tgoto L_007B;\nL_007B:\n\tv116 = v188 != 1;\n\tif (v116) goto L_009B;\n\tv202 = Obi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v197, v188);\n\tv206 = Obi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v202, v188);\n\tv210 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv219 = *([v202 @ X0_v19 (Obi.ObiNativeList`1<UnityEngine.Quaternion>)]) == 0;\n\tv211 = ~v219;\n\tif (v211) goto L_009F;\nL_0089:\n\tv230 = ~this.simulateWhenInvisible;\n\tv231 = ~v230;\n\tif (v231) goto L_0091;\n\tv100 = ~this.isVisible;\n\tif (v100) goto L_FFFFFFFF;\nL_0091:\n\treturnVal1 = Oni::CollisionDetection(this.oniSolver, stepTime);\nL_0098:\n\treturn returnVal1;\n\tgoto L_0098;\nL_009B:\n\tv203 = Obi.ObiNativeList`1<UnityEngine.Quaternion>::CopyFrom(v197, v188);\nL_009F:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPtr BeginStep(float stepTime)
		{
			//IL_007a: Expected O, but got I
			//IL_02a0: Expected I, but got O
			//IL_02f4: Expected O, but got I
			//IL_019c: Expected O, but got I
			//IL_0182: Expected O, but got I4
			List<ObiActor>.Enumerator enumerator = default(List<ObiActor>.Enumerator);
			bool flag = base.isActiveAndEnabled;
			bool flag2 = !flag;
			IntPtr result = default(IntPtr);
			if (!flag2)
			{
				bool flag3 = OniSolver == (IntPtr)0;
				bool flag4 = !flag3;
				bool flag5 = !flag4;
				result = default(IntPtr);
				if (!flag5)
				{
					ObiNativeVector4List obiNativeVector4List = startPositions;
					ObiNativeVector4List obiNativeVector4List2 = positions;
					bool flag6 = obiNativeVector4List == null;
					ObiNativeList<Quaternion> obiNativeList = (ObiNativeList<Quaternion>)0;
					if (!flag6)
					{
						obiNativeVector4List.CopyFrom(obiNativeVector4List2);
						ObiNativeQuaternionList obiNativeQuaternionList = startOrientations;
						ObiNativeQuaternionList obiNativeQuaternionList2 = orientations;
						bool flag7 = obiNativeQuaternionList == null;
						obiNativeList = (ObiNativeList<Quaternion>)(object)obiNativeVector4List2;
						if (!flag7)
						{
							obiNativeQuaternionList.CopyFrom(obiNativeQuaternionList2);
							PushActiveParticles();
							Oni.RecalculateInertiaTensors(OniSolver);
							bool flag8 = this.OnBeginStep == null;
							obiNativeList = obiNativeQuaternionList2;
							if (!flag8)
							{
								this.OnBeginStep(this, stepTime);
								obiNativeList = (ObiNativeList<Quaternion>)(object)this;
							}
							if (actors != null)
							{
								List<ObiActor>.Enumerator enumerator2 = actors.GetEnumerator();
								object obj = default(object);
								while (true)
								{
									((ObiNativeList<Quaternion>)enumerator).CopyFrom((ObiNativeList<Quaternion>)0);
									if ((int)((long)(IntPtr)obj & 1L) == 0)
									{
										break;
									}
									int num = 0;
									object obj2 = num;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v246 @ X8_v25+2D0] (should have been resolved before IL gen)");
								}
								((ObiNativeList<Quaternion>)enumerator).CopyFrom((ObiNativeList<Quaternion>)0);
								goto IL_0213;
							}
						}
					}
					NullReferenceException ex = new NullReferenceException();
					if ((IntPtr)obiNativeList == (IntPtr)1)
					{
						((ObiNativeList<Quaternion>)(object)ex).CopyFrom(obiNativeList);
						ObiNativeList<Quaternion> obiNativeList2 = default(ObiNativeList<Quaternion>);
						obiNativeList2.CopyFrom(obiNativeList);
						enumerator.Dispose();
						if (obiNativeList2 == null)
						{
							goto IL_0213;
						}
					}
					else
					{
						((ObiNativeList<Quaternion>)(object)ex).CopyFrom(obiNativeList);
					}
					TypeLoadException ex2 = new TypeLoadException();
					return (IntPtr)ex2;
				}
			}
			goto IL_026c;
			IL_026c:
			return result;
			IL_0213:
			if (simulateWhenInvisible || IsVisible)
			{
				return Oni.CollisionDetection(OniSolver, stepTime);
			}
			result = default(IntPtr);
			goto IL_026c;
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x102BF70", Offset = "0x102BF70", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECCB08]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, substepTime, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2026250]) = v41;\nL_0019:\n\tv46 = 0;\n\tv47 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv51 = v47 == 0;\n\tif (v51) goto L_007D;\n\tv53 = ~this.simulateWhenInvisible;\n\tv54 = ~v53;\n\tif (v54) goto L_002A;\n\tv99 = ~this.isVisible;\n\tif (v99) goto L_FFFFFFFF;\nL_002A:\n\tv114 = System.IntPtr::op_Inequality(this.oniSolver, 0);\n\tv98 = v114 == 0;\n\tif (v98) goto L_007D;\n\tv155 = this.OnSubstep == 0;\n\tif (v155) goto L_0037;\n\tObi.ObiSolver+SolverStepCallback::Invoke(this.OnSubstep, this, substepTime);\nL_0037:\n\tv161 = this.actors == 0;\n\tif (v161) goto L_0058;\n\tv166 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(this.actors);\nL_0042:\n\tv190 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv193 = v190 == 0;\n\tif (v193) goto L_0053;\n\tv196 = 0;\n\tv188 = *([v196 @ X0_v31 (System.Int32)]);\n\t*([v188 @ X8_v19+2E0])(v186, 0, *([v188 @ X8_v19+2E8]), 0, v27, v28, v29, v30, v31, substepTime, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0042;\nL_0053:\n\tv201 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tgoto L_0073;\n\tgoto L_007D;\n\tv172 = new System.NullReferenceException();\nL_0058:\n\tv179 = new System.NullReferenceException();\n\tgoto L_0064;\n\tgoto L_0064;\nL_0064:\n\tv117 = Il2CppMethodInfo != 1;\n\tif (v117) goto L_007E;\n\tv194 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(v179);\n\tv203 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(v194);\n\tv207 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v46 @ stack_-48_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv217 = ~v194.m_value;\n\tv208 = ~v217;\n\tif (v208) goto L_0082;\nL_0073:\n\tObi.ObiSolver::UpdateTransformFrame(this, substepTime);\n\treturnVal1 = Oni::Step(this.oniSolver, substepTime);\nL_007D:\n\treturn returnVal1;\nL_007E:\n\tv195 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(v179);\nL_0082:\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe IntPtr Substep(float substepTime)
		{
			//IL_01f1: Expected I, but got O
			//IL_00ff: Expected O, but got I4
			List<ObiActor>.Enumerator enumerator = default(List<ObiActor>.Enumerator);
			bool flag = base.isActiveAndEnabled;
			bool flag2 = !flag;
			IntPtr result = default(IntPtr);
			if (!flag2)
			{
				if (simulateWhenInvisible || IsVisible)
				{
					bool flag3 = OniSolver != (IntPtr)0;
					bool flag4 = !flag3;
					result = default(IntPtr);
					if (!flag4)
					{
						if (this.OnSubstep != null)
						{
							this.OnSubstep(this, substepTime);
						}
						if (actors != null)
						{
							List<ObiActor>.Enumerator enumerator2 = actors.GetEnumerator();
							while (enumerator.MoveNext())
							{
								int num = 0;
								object obj = num;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v188 @ X8_v19+2E0] (should have been resolved before IL gen)");
							}
							enumerator.Dispose();
							goto IL_01aa;
						}
						NullReferenceException ex = new NullReferenceException();
						if ((IntPtr)0 == (IntPtr)1)
						{
							bool flag5 = ((List<ObiActor>.Enumerator*)ex)->MoveNext();
							bool flag6 = (flag5 ? ((List<ObiActor>.Enumerator*)1) : ((List<ObiActor>.Enumerator*)null))->MoveNext();
							enumerator.Dispose();
							if (!((bool*)(flag5 ? 1 : 0))->m_value)
							{
								goto IL_01aa;
							}
						}
						else
						{
							bool flag7 = ((List<ObiActor>.Enumerator*)ex)->MoveNext();
						}
						TypeLoadException ex2 = new TypeLoadException();
						return (IntPtr)ex2;
					}
				}
				else
				{
					result = default(IntPtr);
				}
			}
			return result;
			IL_01aa:
			UpdateTransformFrame(substepTime);
			return Oni.Step(OniSolver, substepTime);
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x102C1A8", Offset = "0x102C1A8", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB2248]);\n\tv19 = *([v18 @ X8_v34]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026251]) = v38;\nL_0015:\n\tv41 = 0;\n\tv45 = System.IntPtr::op_Equality(this.oniSolver, 0);\n\tv47 = v45 == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_00BF;\n\tv50 = this.OnCollision == 0;\n\tif (v50) goto L_004D;\n\tv118 = Oni::GetConstraintCount(this.oniSolver, 0xB);\n\tv176 = this.collisionArgs;\n\tv177 = this.collisionArgs == 0;\n\tif (v177) goto L_00A1;\n\tv202 = v176.contacts == 0;\n\tif (v202) goto L_00A1;\n\tObi.ObiList`1<Oni+Contact>::SetCount(v176.contacts, v118);\n\tv120 = v118 < 1;\n\tif (v120) goto L_0047;\n\tv233 = this.collisionArgs;\n\tv225 = this.collisionArgs == 0;\n\tif (v225) goto L_00A1;\n\tv234 = v233.contacts;\n\tv226 = v233.contacts == 0;\n\tif (v226) goto L_00A1;\n\tOni::GetCollisionContacts(this.oniSolver, v234.data, v118);\nL_0047:\n\tv144 = this.OnCollision == 0;\n\tif (v144) goto L_00A1;\n\tv137 = this.collisionArgs;\n\tObi.ObiSolver+CollisionCallback::Invoke(this.OnCollision, this, this.collisionArgs);\nL_004D:\n\tv150 = this.OnParticleCollision == 0;\n\tif (v150) goto L_007B;\n\tv180 = Oni::GetConstraintCount(this.oniSolver, 9);\n\tv235 = this.particleCollisionArgs;\n\tv227 = this.particleCollisionArgs == 0;\n\tif (v227) goto L_00A1;\n\tv262 = v235.contacts == 0;\n\tif (v262) goto L_00A1;\n\tObi.ObiList`1<Oni+Contact>::SetCount(v235.contacts, v180);\n\tv181 = v180 < 1;\n\tif (v181) goto L_0075;\n\tv236 = this.particleCollisionArgs;\n\tv228 = this.particleCollisionArgs == 0;\n\tif (v228) goto L_00A1;\n\tv237 = v236.contacts;\n\tv229 = v236.contacts == 0;\n\tif (v229) goto L_00A1;\n\tOni::GetParticleCollisionContacts(this.oniSolver, v237.data, v180);\nL_0075:\n\tv196 = this.OnParticleCollision == 0;\n\tif (v196) goto L_00A1;\n\tv92 = this.particleCollisionArgs;\n\tObi.ObiSolver+CollisionCallback::Invoke(this.OnParticleCollision, this, this.particleCollisionArgs);\nL_007B:\n\tOni::ResetForces(this.oniSolver);\n\tv241 = this.OnEndStep == 0;\n\tif (v241) goto L_0082;\n\tObi.ObiSolver+SolverCallback::Invoke(this.OnEndStep, this);\nL_0082:\n\tv263 = this.actors == 0;\n\tif (v263) goto L_00A1;\n\tv276 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(this.actors);\nL_008D:\n\tv301 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv102 = v301 == 0;\n\tif (v102) goto L_009D;\n\tv309 = 0;\n\tv299 = *([v309 @ X0_v28 (System.Int32)]);\n\t*([v299 @ X8_v19+2F0])(v297, 0, *([v299 @ X8_v19+2F8]), v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_008D;\nL_009D:\n\tv99 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tgoto L_00BF;\n\tthrow System.NullReferenceException;\nL_00A1:\n\tv266 = new System.NullReferenceException();\n\tgoto L_00AD;\n\tgoto L_00AD;\nL_00AD:\n\tv56 = v255 != 1;\n\tif (v56) goto L_00C0;\n\tv286 = 0x6D2BC0(v266, v255, v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv302 = 0x6D2490(v286, v255, v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv98 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv312 = *([v286 @ X0_v11]) == 0;\n\tv101 = ~v312;\n\tif (v101) goto L_00C4;\nL_00BF:\n\treturn;\nL_00C0:\n\tv287 = 0x6D2380(v266, v255, v92, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00C4:\n\tthrow System.TypeLoadException;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void EndStep()
		{
			//IL_03f2: Expected I4, but got O
			//IL_0225: Expected O, but got I
			//IL_00c8: Expected O, but got I
			//IL_0295: Expected O, but got I
			//IL_042a: Expected O, but got I4
			//IL_013c: Expected O, but got I
			//IL_030c: Expected O, but got I
			//IL_0172: Expected O, but got I4
			//IL_017f: Expected I4, but got O
			//IL_0342: Expected O, but got I4
			//IL_034f: Expected I4, but got O
			List<ObiActor>.Enumerator enumerator = default(List<ObiActor>.Enumerator);
			if (OniSolver == (IntPtr)0)
			{
				return;
			}
			bool flag = this.OnCollision == null;
			ObiCollisionEventArgs e = null;
			ObiSolver obiSolver = null;
			if (flag)
			{
				goto IL_01c9;
			}
			int constraintCount = Oni.GetConstraintCount(OniSolver, 11);
			ObiCollisionEventArgs e2 = collisionArgs;
			bool flag2 = collisionArgs == null;
			int num = 0;
			ObiCollisionEventArgs e3;
			if (!flag2)
			{
				bool flag3 = e2.contacts == null;
				e3 = null;
				num = 11;
				if (!flag3)
				{
					e2.contacts.SetCount(constraintCount);
					bool flag4 = constraintCount < 1;
					e3 = (ObiCollisionEventArgs)0;
					num = constraintCount;
					if (flag4)
					{
						goto IL_0184;
					}
					ObiCollisionEventArgs e4 = collisionArgs;
					bool flag5 = collisionArgs == null;
					e3 = null;
					num = 11;
					if (!flag5)
					{
						ObiList<Oni.Contact> contacts = e4.contacts;
						bool flag6 = e4.contacts == null;
						e3 = (ObiCollisionEventArgs)0;
						num = constraintCount;
						if (!flag6)
						{
							Oni.GetCollisionContacts(OniSolver, contacts.Data, constraintCount);
							e3 = (ObiCollisionEventArgs)constraintCount;
							num = (int)contacts.Data;
							goto IL_0184;
						}
					}
				}
			}
			goto IL_051c;
			IL_0354:
			if (this.OnParticleCollision != null)
			{
				e3 = particleCollisionArgs;
				this.OnParticleCollision(this, particleCollisionArgs);
				obiSolver = this;
				goto IL_0399;
			}
			goto IL_051c;
			IL_051c:
			NullReferenceException ex = new NullReferenceException();
			if (num == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_0184:
			if (this.OnCollision != null)
			{
				e = collisionArgs;
				this.OnCollision(this, collisionArgs);
				obiSolver = this;
				goto IL_01c9;
			}
			goto IL_051c;
			IL_0399:
			Oni.ResetForces(OniSolver);
			if (this.OnEndStep != null)
			{
				this.OnEndStep(this);
				obiSolver = this;
			}
			bool flag7 = actors == null;
			num = (int)obiSolver;
			if (!flag7)
			{
				List<ObiActor>.Enumerator enumerator2 = actors.GetEnumerator();
				while (enumerator.MoveNext())
				{
					int num2 = 0;
					object obj2 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v299 @ X8_v19+2F0] (should have been resolved before IL gen)");
				}
				enumerator.Dispose();
				return;
			}
			goto IL_051c;
			IL_01c9:
			bool flag8 = this.OnParticleCollision == null;
			e3 = e;
			if (flag8)
			{
				goto IL_0399;
			}
			int constraintCount2 = Oni.GetConstraintCount(OniSolver, 9);
			ObiCollisionEventArgs e5 = particleCollisionArgs;
			bool flag9 = particleCollisionArgs == null;
			e3 = (ObiCollisionEventArgs)0;
			num = constraintCount;
			if (!flag9)
			{
				bool flag10 = e5.contacts == null;
				e3 = e;
				num = 9;
				if (!flag10)
				{
					e5.contacts.SetCount(constraintCount2);
					bool flag11 = constraintCount2 < 1;
					e3 = (ObiCollisionEventArgs)0;
					num = constraintCount2;
					if (flag11)
					{
						goto IL_0354;
					}
					ObiCollisionEventArgs e6 = particleCollisionArgs;
					bool flag12 = particleCollisionArgs == null;
					e3 = e;
					num = 9;
					if (!flag12)
					{
						ObiList<Oni.Contact> contacts2 = e6.contacts;
						bool flag13 = e6.contacts == null;
						e3 = (ObiCollisionEventArgs)0;
						num = constraintCount2;
						if (!flag13)
						{
							Oni.GetParticleCollisionContacts(OniSolver, contacts2.Data, constraintCount2);
							e3 = (ObiCollisionEventArgs)constraintCount2;
							num = (int)contacts2.Data;
							goto IL_0354;
						}
					}
				}
			}
			goto IL_051c;
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x102CA5C", Offset = "0x102CA5C", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = *([1F0B838]);\n\tv31 = *([v30 @ X8_v24]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, stepTime, unsimulatedTime, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2026252]) = v48;\nL_001D:\n\tv53 = 0;\n\tv54 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv56 = v54 == 0;\n\tif (v56) goto L_00B9;\n\tv60 = System.IntPtr::op_Equality(this.oniSolver, 0);\n\tv123 = v60 == 0;\n\tv106 = ~v123;\n\tif (v106) goto L_00B9;\n\tv171 = ~this.simulateWhenInvisible;\n\tv172 = ~v171;\n\tif (v172) goto L_0037;\n\tv174 = ~this.isVisible;\n\tif (v174) goto L_0057;\nL_0037:\n\tgoto L_0042;\n\tv205 = *([v179 @ X0_v34 (Il2CppClass<Obi.ObiSolver>)+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_0042;\n\tv216 = \"il2cpp_codegen_runtime_class_init\"(v179, v58, v59, v35, v36, v37, v38, v39, stepTime, unsimulatedTime, v40, v41, v42, v43, v44, v45);\n\tv209 = Obi.ObiSolver;\nL_0042:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v202.m_StateInterpolationPerfMarker);\n\tv218 = Obi.ObiSolver::get_startPositions(this);\n\tv241 = Obi.ObiSolver::get_startOrientations(this);\n\tv198 = v241 == 0;\n\tif (v198) goto L_007E;\n\tv100 = v241.m_AlignedPtr;\n\tOni::ApplyPositionInterpolation(this.oniSolver, v218.m_AlignedPtr, v241.m_AlignedPtr, v94, v92);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v202.m_StateInterpolationPerfMarker);\nL_0057:\n\tObi.ObiSolver::UpdateVisibility(v200);\n\tv215 = v200.OnInterpolate == 0;\n\tif (v215) goto L_0064;\n\tObi.ObiSolver+SolverCallback::Invoke(v200.OnInterpolate, v200);\nL_0064:\n\tv228 = System.Collections.Generic.List`1<Obi.ObiActor>::GetEnumerator(v200.actors);\nL_0069:\n\tv287 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::MoveNext(&v53 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tv107 = v287 == 0;\n\tif (v107) goto L_0079;\n\tv292 = 0;\n\tv285 = *([v292 @ X0_v31 (System.Int32)]);\n\t*([v285 @ X8_v15+300])(v283, 0, *([v285 @ X8_v15+308]), v100, v35, v36, v37, v38, v39, v148, v146, v40, v41, v42, v43, v44, v45);\n\tgoto L_0069;\nL_0079:\n\tv104 = System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>::Dispose(&v53 @ stack_-58_v1 (System.Collections.Generic.List`1<Obi.ObiActor>+Enumerator<Obi.ObiActor>));\n\tgoto L_00B9;\n\tv233 = new System.NullReferenceException();\n\tv239 = new System.NullReferenceException();\n\tv263 = new System.NullReferenceException();\nL_007E:\n\tv278 = new System.NullReferenceException();\n\tgoto L_008D;\n\tgoto L_008D;\n\tgoto L_009A;\n\tgoto L_008D;\n\tgoto L_008D;\nL_008D:\n\tv126 = v275 != 1;\n\tif (v126) goto L_00BA;\n\tv295 = 0x6D2BC0(v278, v275, v190, v35, v36, v37, v38, v39, v148, v146, v40, v41, v42, v43, v44, v45);\n\tv297 = 0x6D2490(v295, v275, v190, v35, v36, v37, v38, v39, v148, v146, v40, v41, v42, v43, v44, v45);\n\tUnity.Profiling.ProfilerMarker::Internal_End(v168);\n\tv199 = *([v295 @ X0_v13]) == 0;\n\tif (v199) goto L_0057;\n\tgoto L_00BE;\n\tgoto L_009A;\nL_009A:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00BA;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EAB9C0]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BB;\nL_00B9:\n\treturn;\nL_00BA:\n\tv296 = 0x6D2380(v278, v275, v190, v35, v36, v37, v38, v39, v148, v146, v40, v41, v42, v43, v44, v45);\nL_00BB:\n\t;\nL_00BE:\n\tthrow System.TypeLoadException;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Interpolate(float stepTime, float unsimulatedTime)
		{
			//IL_0270: Expected I, but got O
			//IL_00fa: Expected I, but got O
			//IL_0174: Expected O, but got I4
			List<ObiActor>.Enumerator enumerator = default(List<ObiActor>.Enumerator);
			if (!base.isActiveAndEnabled || OniSolver == (IntPtr)0)
			{
				return;
			}
			ObiSolver obiSolver;
			if (!simulateWhenInvisible)
			{
				bool flag = !IsVisible;
				IntPtr intPtr = default(IntPtr);
				obiSolver = this;
				if (flag)
				{
					goto IL_0105;
				}
			}
			ProfilerMarker.Internal_Begin((IntPtr)m_StateInterpolationPerfMarker);
			ObiNativeVector4List obiNativeVector4List = startPositions;
			ObiNativeQuaternionList obiNativeQuaternionList = startOrientations;
			if (obiNativeQuaternionList != null)
			{
				IntPtr intPtr = obiNativeQuaternionList.m_AlignedPtr;
				float delta_seconds = default(float);
				float unsimulated_time = default(float);
				Oni.ApplyPositionInterpolation(OniSolver, obiNativeVector4List.m_AlignedPtr, obiNativeQuaternionList.m_AlignedPtr, delta_seconds, unsimulated_time);
				ProfilerMarker.Internal_End((IntPtr)m_StateInterpolationPerfMarker);
				obiSolver = this;
				goto IL_0105;
			}
			NullReferenceException ex = new NullReferenceException();
			object obj = default(object);
			if ((IntPtr)obj == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				IntPtr markerPtr = default(IntPtr);
				ProfilerMarker.Internal_End(markerPtr);
				object obj2 = default(object);
				bool flag2 = obj2 == null;
				IntPtr intPtr2 = default(IntPtr);
				IntPtr intPtr = intPtr2;
				ObiSolver obiSolver2 = default(ObiSolver);
				obiSolver = obiSolver2;
				if (flag2)
				{
					goto IL_0105;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_0105:
			obiSolver.UpdateVisibility();
			if (obiSolver.OnInterpolate != null)
			{
				obiSolver.OnInterpolate(obiSolver);
			}
			List<ObiActor>.Enumerator enumerator2 = obiSolver.actors.GetEnumerator();
			while (enumerator.MoveNext())
			{
				int num = 0;
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v285 @ X8_v15+300] (should have been resolved before IL gen)");
			}
			enumerator.Dispose();
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x102CD50", Offset = "0x102CD50", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ED8080]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2026253]) = v42;\nL_0019:\n\tthis.simulateWhenInvisible = 1;\n\tv54 = 0x158BA74(&v49 @ stack_-40_v2, 0, v26, v27, v28, v29, v30, v31, 0, -9.81f, 0, 0, v36, v37, v38, v39);\n\tv64 = 0;\n\tv68 = 0x102CF78(&v64 @ stack_-68_v1 (Oni+SolverParameters), 0, v26, v27, v28, v29, v30, v31, v49, v57, v59, v61, 0, v37, v38, v39);\n\tthis.parameters.maxDepenetration = 0f;\n\tthis.parameters.gravity.z = 0f;\n\tthis.parameters = 0;\n\tv75 = new System.Collections.Generic.List`1<Obi.ObiActor>();\n\tSystem.Collections.Generic.List`1<Obi.ObiActor>::.ctor(v75);\n\tthis.actors = v75;\n\tthis.activeParticleCountChanged = 1;\n\tv83 = new Obi.ObiSolver+ObiCollisionEventArgs();\n\tObi.ObiSolver+ObiCollisionEventArgs::.ctor(v83);\n\tthis.collisionArgs = v83;\n\tv86 = new Obi.ObiSolver+ObiCollisionEventArgs();\n\tObi.ObiSolver+ObiCollisionEventArgs::.ctor(v86);\n\tthis.particleCollisionArgs = v86;\n\tthis.m_MaxScale = 1f;\n\t// 79 NewArr v93 @ X0_v13 (UnityEngine.Plane[]), typeof(UnityEngine.Plane[]), 6\n\tthis.planes = v93;\n\t// 85 NewArr v98 @ X0_v15 (UnityEngine.Camera[]), typeof(UnityEngine.Camera[]), 1\n\tthis.sceneCameras = v98;\n\tthis.isVisible = 1;\n\tthis.distanceConstraintParameters = *([1821E70]);\n\tthis.bendingConstraintParameters = *([1821E80]);\n\tthis.particleCollisionConstraintParameters = *([1821E90]);\n\tthis.particleFrictionConstraintParameters = 0x100000001;\n\tthis.particleFrictionConstraintParameters.SORFactor = *([1821EA0]);\n\tthis.collisionConstraintParameters.SORFactor = *([1821EB0]);\n\tthis.frictionConstraintParameters.SORFactor = *([1821EA0]);\n\tthis.skinConstraintParameters.SORFactor = *([1821EC0]);\n\tthis.volumeConstraintParameters.SORFactor = *([1821ED0]);\n\tthis.shapeMatchingConstraintParameters.SORFactor = *([1821EB0]);\n\tthis.tetherConstraintParameters.SORFactor = *([1821ED0]);\n\tthis.pinConstraintParameters.SORFactor = *([1821EC0]);\n\tthis.stitchConstraintParameters.SORFactor = *([1821EC0]);\n\tthis.densityConstraintParameters.SORFactor = *([1821EE0]);\n\tthis.stretchShearConstraintParameters.SORFactor = *([1821EE0]);\n\tthis.bendTwistConstraintParameters.SORFactor = *([1821EE0]);\n\tthis.chainConstraintParameters.SORFactor = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\t// 149 ShiftStack -80\n\tstack[0] = V11;\n\tstack[8] = V10;\n\tstack[10] = V9;\n\tstack[18] = V8;\n\tstack[20] = X21;\n\tstack[30] = X20;\n\tstack[38] = X19;\n\tstack[40] = X29;\n\tstack[48] = X30;\n\tX29 = &stack[40];\n\tX8 = *([20267CD]);\n\tV8 = V3;\n\tV9 = V2;\n\tV10 = V1;\n\tV11 = V0;\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B2;\n\tX8 = *([1EE4858]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20267CD]) = X8;\nL_00B2:\n\t*([X20]) = 0;\n\tX8 = *([1F0E218]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00BF;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00BF;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00BF:\n\tV0 = V11;\n\tV1 = V10;\n\tV2 = V9;\n\tV3 = V8;\n\tX0 = 0;\n\t// 196 MakeStruct AGG102D004_0, typeof(UnityEngine.Vector4), V0, V1, V2, V3\n\tV0 = UnityEngine.Vector4::op_Implicit(AGG102D004_0, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X20+8]) = V0;\n\t*([X20+C]) = V1;\n\tV0 = *([1821EF0]);\n\tX8 = 0xB717;\n\tX8 = X8 | 0x38D10000;\n\t*([X20+10]) = V2;\n\t*([X20+4]) = X19;\n\t*([X20+14]) = V0;\n\t*([X20+24]) = X8;\n\tX29 = stack[40];\n\tX30 = stack[48];\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX21 = stack[20];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 219 ShiftStack 80\n\treturn;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiSolver()
		{
			//IL_00af: Expected O, but got I
			//IL_00c1: Expected O, but got I
			//IL_00d3: Expected O, but got I
			//IL_00e2: Expected O, but got I8
			//IL_00f9: Expected F4, but got I
			//IL_0110: Expected F4, but got I
			//IL_0127: Expected F4, but got I
			//IL_013e: Expected F4, but got I
			//IL_0155: Expected F4, but got I
			//IL_016c: Expected F4, but got I
			//IL_0183: Expected F4, but got I
			//IL_019a: Expected F4, but got I
			//IL_01b1: Expected F4, but got I
			//IL_01c8: Expected F4, but got I
			//IL_01df: Expected F4, but got I
			//IL_01f6: Expected F4, but got I
			base._002Ector();
			simulateWhenInvisible = true;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
			Oni.SolverParameters solverParameters = default(Oni.SolverParameters);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @102CF78 (inside Obi.ObiSolver::.ctor +0x228)");
			parameters.maxDepenetration = 0f;
			parameters.gravity.z = 0f;
			parameters = default(Oni.SolverParameters);
			List<ObiActor> list = new List<ObiActor>();
			actors = list;
			activeParticleCountChanged = true;
			ObiCollisionEventArgs e = new ObiCollisionEventArgs();
			collisionArgs = e;
			ObiCollisionEventArgs e2 = new ObiCollisionEventArgs();
			particleCollisionArgs = e2;
			m_MaxScale = 1f;
			Plane[] array = new Plane[6];
			planes = array;
			Camera[] array2 = new Camera[1];
			sceneCameras = array2;
			isVisible = true;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821E70]");
			distanceConstraintParameters = (Oni.ConstraintParameters)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821E80]");
			bendingConstraintParameters = (Oni.ConstraintParameters)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821E90]");
			particleCollisionConstraintParameters = (Oni.ConstraintParameters)0;
			particleFrictionConstraintParameters = (Oni.ConstraintParameters)4294967297L;
			ref Oni.ConstraintParameters reference = ref particleFrictionConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EA0]");
			reference.SORFactor = 0f;
			ref Oni.ConstraintParameters reference2 = ref collisionConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EB0]");
			reference2.SORFactor = 0f;
			ref Oni.ConstraintParameters reference3 = ref frictionConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EA0]");
			reference3.SORFactor = 0f;
			ref Oni.ConstraintParameters reference4 = ref skinConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EC0]");
			reference4.SORFactor = 0f;
			ref Oni.ConstraintParameters reference5 = ref volumeConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821ED0]");
			reference5.SORFactor = 0f;
			ref Oni.ConstraintParameters reference6 = ref shapeMatchingConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EB0]");
			reference6.SORFactor = 0f;
			ref Oni.ConstraintParameters reference7 = ref tetherConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821ED0]");
			reference7.SORFactor = 0f;
			ref Oni.ConstraintParameters reference8 = ref pinConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EC0]");
			reference8.SORFactor = 0f;
			ref Oni.ConstraintParameters reference9 = ref stitchConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EC0]");
			reference9.SORFactor = 0f;
			ref Oni.ConstraintParameters reference10 = ref densityConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EE0]");
			reference10.SORFactor = 0f;
			ref Oni.ConstraintParameters reference11 = ref stretchShearConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EE0]");
			reference11.SORFactor = 0f;
			ref Oni.ConstraintParameters reference12 = ref bendTwistConstraintParameters;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1821EE0]");
			reference12.SORFactor = 0f;
			chainConstraintParameters.SORFactor = 1f;
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x102D0EC", Offset = "0x102D0EC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC03C8]);\n\tv15 = *([v14 @ X8_v24]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2026254]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"ApplyStateInterpolation\", 0);\n\tv47.m_StateInterpolationPerfMarker = v41;\n\tv51 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateVisibility\", 0);\n\tv55.m_UpdateVisibilityPerfMarker = v51;\n\tv59 = Unity.Profiling.ProfilerMarker::Internal_Create(\"GetSolverBounds\", 0);\n\tv63.m_GetSolverBoundsPerfMarker = v59;\n\tv67 = Unity.Profiling.ProfilerMarker::Internal_Create(\"TestBoundsAgainstCameras\", 0);\n\tv71.m_TestBoundsPerfMarker = v67;\n\tv75 = Unity.Profiling.ProfilerMarker::Internal_Create(\"GetAllCameras\", 0);\n\tv77.m_GetAllCamerasPerfMarker = v75;\n\tv78.initialCapacity = 0x100;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiSolver()
		{
			//IL_008d: Expected O, but got I
			//IL_00b2: Expected O, but got I
			//IL_000e: Expected O, but got I
			//IL_0033: Expected O, but got I
			//IL_005d: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("ApplyStateInterpolation", default(Unity.Profiling.MarkerFlags));
			m_StateInterpolationPerfMarker = (ProfilerMarker)(long)intPtr;
			IntPtr intPtr2 = ProfilerMarker.Internal_Create("UpdateVisibility", default(Unity.Profiling.MarkerFlags));
			m_UpdateVisibilityPerfMarker = (ProfilerMarker)(long)intPtr2;
			IntPtr intPtr3 = ProfilerMarker.Internal_Create("GetSolverBounds", default(Unity.Profiling.MarkerFlags));
			m_GetSolverBoundsPerfMarker = (ProfilerMarker)(long)intPtr3;
			IntPtr intPtr4 = ProfilerMarker.Internal_Create("TestBoundsAgainstCameras", default(Unity.Profiling.MarkerFlags));
			m_TestBoundsPerfMarker = (ProfilerMarker)(long)intPtr4;
			IntPtr intPtr5 = ProfilerMarker.Internal_Create("GetAllCameras", default(Unity.Profiling.MarkerFlags));
			m_GetAllCamerasPerfMarker = (ProfilerMarker)(long)intPtr5;
			initialCapacity = 256;
		}
	}
}
