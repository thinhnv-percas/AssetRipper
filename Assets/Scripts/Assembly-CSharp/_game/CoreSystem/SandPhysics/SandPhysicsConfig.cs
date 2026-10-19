using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics
{
	[CreateAssetMenu(fileName = "SandPhysicsConfig", menuName = "Game/Sand Physics Config")]
	[Token(Token = "0x20000A7")]
	public class SandPhysicsConfig : ScriptableObject
	{
		[SerializeField]
		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x18")]
		private int m_particlesPerCube;

		[SerializeField]
		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x1C")]
		private float m_particleRadius;

		[SerializeField]
		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x20")]
		private float m_particleVisualSize;

		[SerializeField]
		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x24")]
		private float m_referenceEffectiveCubeSize;

		[SerializeField]
		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x28")]
		private bool m_shrinkBlockerQuadByParticleRadius;

		[SerializeField]
		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x2C")]
		private float2 m_gravity;

		[SerializeField]
		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x34")]
		private float m_maxSpeed;

		[SerializeField]
		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x38")]
		private float m_restitution;

		[SerializeField]
		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x3C")]
		private float m_friction;

		[SerializeField]
		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x40")]
		private float m_damping;

		[SerializeField]
		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x44")]
		private float m_subThresholdDamping;

		[SerializeField]
		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x48")]
		private float m_contactDamping;

		[SerializeField]
		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x4C")]
		private float m_settleVelocityThreshold;

		[SerializeField]
		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x50")]
		private int m_settleFrameCount;

		[SerializeField]
		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x54")]
		private int m_settleDecayRate;

		[SerializeField]
		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x58")]
		private float m_wakeUpRadius;

		[SerializeField]
		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x5C")]
		private float m_isolatedSettleRadius;

		[SerializeField]
		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x60")]
		private int m_isolatedSettleFrameThreshold;

		[SerializeField]
		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x64")]
		private int m_wallPenetrationRescueFrames;

		[SerializeField]
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x68")]
		private float m_twoSidedCatchRadii;

		[SerializeField]
		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x6C")]
		private float m_flowZoneHeight;

		[SerializeField]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x70")]
		private float m_flowZoneGravityMultiplier;

		[SerializeField]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x74")]
		private float m_flowZoneDamping;

		[SerializeField]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x78")]
		private float2 m_flowZoneConvergeForce;

		[SerializeField]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x80")]
		private int m_physicsTickRate;

		[SerializeField]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x84")]
		private int m_maxSubSteps;

		[SerializeField]
		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x88")]
		private int m_solverIterations;

		[SerializeField]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x8C")]
		private float m_maxRadiiPerStep;

		[SerializeField]
		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x90")]
		private float m_spatialHashCellSizeMultiplier;

		[SerializeField]
		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x94")]
		private int m_settleUpdateInterval;

		[SerializeField]
		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x98")]
		private float m_sameColorCorrectionScale;

		[SerializeField]
		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x9C")]
		private float m_diffColorCorrectionScale;

		[SerializeField]
		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0xA0")]
		private float m_movingCubePushStrength;

		[SerializeField]
		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0xA4")]
		private float m_breakJitterStrength;

		[SerializeField]
		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0xA8")]
		private int m_spawnGraceFrames;

		[SerializeField]
		[Token(Token = "0x4000204")]
		[FieldOffset(Offset = "0xAC")]
		private float m_spawnGraceCorrectionScale;

		[Token(Token = "0x17000053")]
		public float2 Gravity
		{
			[Token(Token = "0x60002A3")]
			[Address(RVA = "0x3C7B37C", Offset = "0x3C7B37C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Gravity;\n")]
			get
			{
				return m_gravity;
			}
		}

		[Token(Token = "0x17000054")]
		public float MaxSpeed
		{
			[Token(Token = "0x60002A4")]
			[Address(RVA = "0x3C7B384", Offset = "0x3C7B384", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxSpeed;\n")]
			get
			{
				return m_maxSpeed;
			}
		}

		[Token(Token = "0x17000055")]
		public float Restitution
		{
			[Token(Token = "0x60002A5")]
			[Address(RVA = "0x3C7B38C", Offset = "0x3C7B38C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Restitution;\n")]
			get
			{
				return m_restitution;
			}
		}

		[Token(Token = "0x17000056")]
		public float Friction
		{
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x3C7B394", Offset = "0x3C7B394", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Friction;\n")]
			get
			{
				return m_friction;
			}
		}

		[Token(Token = "0x17000057")]
		public float Damping
		{
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x3C7B39C", Offset = "0x3C7B39C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Damping;\n")]
			get
			{
				return m_damping;
			}
		}

		[Token(Token = "0x17000058")]
		public float SubThresholdDamping
		{
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0x3C7B3A4", Offset = "0x3C7B3A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SubThresholdDamping;\n")]
			get
			{
				return m_subThresholdDamping;
			}
		}

		[Token(Token = "0x17000059")]
		public float ContactDamping
		{
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0x3C7B3AC", Offset = "0x3C7B3AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ContactDamping;\n")]
			get
			{
				return m_contactDamping;
			}
		}

		[Token(Token = "0x1700005A")]
		public float SettleVelocityThreshold
		{
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0x3C7B3B4", Offset = "0x3C7B3B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SettleVelocityThreshold;\n")]
			get
			{
				return m_settleVelocityThreshold;
			}
		}

		[Token(Token = "0x1700005B")]
		public int SettleFrameCount
		{
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0x3C7B3BC", Offset = "0x3C7B3BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SettleFrameCount;\n")]
			get
			{
				return m_settleFrameCount;
			}
		}

		[Token(Token = "0x1700005C")]
		public int SettleDecayRate
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0x3C7B3C4", Offset = "0x3C7B3C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SettleDecayRate;\n")]
			get
			{
				return m_settleDecayRate;
			}
		}

		[Token(Token = "0x1700005D")]
		public float WakeUpRadius
		{
			[Token(Token = "0x60002AD")]
			[Address(RVA = "0x3C7B3CC", Offset = "0x3C7B3CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WakeUpRadius;\n")]
			get
			{
				return m_wakeUpRadius;
			}
		}

		[Token(Token = "0x1700005E")]
		public float IsolatedSettleRadius
		{
			[Token(Token = "0x60002AE")]
			[Address(RVA = "0x3C7B3D4", Offset = "0x3C7B3D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsolatedSettleRadius;\n")]
			get
			{
				return m_isolatedSettleRadius;
			}
		}

		[Token(Token = "0x1700005F")]
		public int IsolatedSettleFrameThreshold
		{
			[Token(Token = "0x60002AF")]
			[Address(RVA = "0x3C7B3DC", Offset = "0x3C7B3DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsolatedSettleFrameThreshold;\n")]
			get
			{
				return m_isolatedSettleFrameThreshold;
			}
		}

		[Token(Token = "0x17000060")]
		public int WallPenetrationRescueFrames
		{
			[Token(Token = "0x60002B0")]
			[Address(RVA = "0x3C7B3E4", Offset = "0x3C7B3E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.WallPenetrationRescueFrames;\n")]
			get
			{
				return m_wallPenetrationRescueFrames;
			}
		}

		[Token(Token = "0x17000061")]
		public float FlowZoneHeight
		{
			[Token(Token = "0x60002B1")]
			[Address(RVA = "0x3C7B3EC", Offset = "0x3C7B3EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FlowZoneHeight;\n")]
			get
			{
				return m_flowZoneHeight;
			}
		}

		[Token(Token = "0x17000062")]
		public float FlowZoneGravityMultiplier
		{
			[Token(Token = "0x60002B2")]
			[Address(RVA = "0x3C7B3F4", Offset = "0x3C7B3F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FlowZoneGravityMultiplier;\n")]
			get
			{
				return m_flowZoneGravityMultiplier;
			}
		}

		[Token(Token = "0x17000063")]
		public float FlowZoneDamping
		{
			[Token(Token = "0x60002B3")]
			[Address(RVA = "0x3C7B3FC", Offset = "0x3C7B3FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FlowZoneDamping;\n")]
			get
			{
				return m_flowZoneDamping;
			}
		}

		[Token(Token = "0x17000064")]
		public float2 FlowZoneConvergeForce
		{
			[Token(Token = "0x60002B4")]
			[Address(RVA = "0x3C7B404", Offset = "0x3C7B404", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FlowZoneConvergeForce;\n")]
			get
			{
				return m_flowZoneConvergeForce;
			}
		}

		[Token(Token = "0x17000065")]
		public float TwoSidedCatchRadii
		{
			[Token(Token = "0x60002B5")]
			[Address(RVA = "0x3C7B40C", Offset = "0x3C7B40C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TwoSidedCatchRadii;\n")]
			get
			{
				return m_twoSidedCatchRadii;
			}
		}

		[Token(Token = "0x17000066")]
		public float MovingCubePushStrength
		{
			[Token(Token = "0x60002B6")]
			[Address(RVA = "0x3C7B414", Offset = "0x3C7B414", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MovingCubePushStrength;\n")]
			get
			{
				return m_movingCubePushStrength;
			}
		}

		[Token(Token = "0x17000067")]
		public float BreakJitterStrength
		{
			[Token(Token = "0x60002B7")]
			[Address(RVA = "0x3C7B41C", Offset = "0x3C7B41C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BreakJitterStrength;\n")]
			get
			{
				return m_breakJitterStrength;
			}
		}

		[Token(Token = "0x17000068")]
		public int SpawnGraceFrames
		{
			[Token(Token = "0x60002B8")]
			[Address(RVA = "0x3C7B424", Offset = "0x3C7B424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SpawnGraceFrames;\n")]
			get
			{
				return m_spawnGraceFrames;
			}
		}

		[Token(Token = "0x17000069")]
		public float SpawnGraceCorrectionScale
		{
			[Token(Token = "0x60002B9")]
			[Address(RVA = "0x3C7B42C", Offset = "0x3C7B42C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SpawnGraceCorrectionScale;\n")]
			get
			{
				return m_spawnGraceCorrectionScale;
			}
		}

		[Token(Token = "0x1700006A")]
		public int PhysicsTickRate
		{
			[Token(Token = "0x60002BA")]
			[Address(RVA = "0x3C7B434", Offset = "0x3C7B434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.PhysicsTickRate;\n")]
			get
			{
				return m_physicsTickRate;
			}
		}

		[Token(Token = "0x1700006B")]
		public int MaxSubSteps
		{
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0x3C7B43C", Offset = "0x3C7B43C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxSubSteps;\n")]
			get
			{
				return m_maxSubSteps;
			}
		}

		[Token(Token = "0x1700006C")]
		public int SolverIterations
		{
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0x3C7B444", Offset = "0x3C7B444", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SolverIterations;\n")]
			get
			{
				return m_solverIterations;
			}
		}

		[Token(Token = "0x1700006D")]
		public float MaxRadiiPerStep
		{
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0x3C7B44C", Offset = "0x3C7B44C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.MaxRadiiPerStep;\n")]
			get
			{
				return m_maxRadiiPerStep;
			}
		}

		[Token(Token = "0x1700006E")]
		public float SpatialHashCellSizeMultiplier
		{
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0x3C7B454", Offset = "0x3C7B454", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SpatialHashCellSizeMultiplier;\n")]
			get
			{
				return m_spatialHashCellSizeMultiplier;
			}
		}

		[Token(Token = "0x1700006F")]
		public int SettleUpdateInterval
		{
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0x3C7B45C", Offset = "0x3C7B45C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SettleUpdateInterval;\n")]
			get
			{
				return m_settleUpdateInterval;
			}
		}

		[Token(Token = "0x17000070")]
		public float SameColorCorrectionScale
		{
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0x3C7B464", Offset = "0x3C7B464", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.SameColorCorrectionScale;\n")]
			get
			{
				return m_sameColorCorrectionScale;
			}
		}

		[Token(Token = "0x17000071")]
		public float DiffColorCorrectionScale
		{
			[Token(Token = "0x60002C1")]
			[Address(RVA = "0x3C7B46C", Offset = "0x3C7B46C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.DiffColorCorrectionScale;\n")]
			get
			{
				return m_diffColorCorrectionScale;
			}
		}

		[Token(Token = "0x17000072")]
		public float BlockerCollisionInset
		{
			[Token(Token = "0x60002C2")]
			[Address(RVA = "0x3C7B474", Offset = "0x3C7B474", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.m_shrinkBlockerQuadByParticleRadius != 1;\n\treturnVal1 = 0;\n\tif (v12) goto L_000E;\n\treturnVal1 = this.m_particleRadius;\nL_000E:\n\treturn returnVal1;\n")]
			get
			{
				bool flag = !m_shrinkBlockerQuadByParticleRadius;
				float result = 0f;
				if (!flag)
				{
					result = m_particleRadius;
				}
				return result;
			}
		}

		[Token(Token = "0x60002C3")]
		[Address(RVA = "0x3C7B48C", Offset = "0x3C7B48C", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv82 = this.m_referenceEffectiveCubeSize;\n\tv69 = this.m_referenceEffectiveCubeSize == 0;\n\tv70 = this.m_referenceEffectiveCubeSize < 0;\n\tv71 = ~v70;\n\tv74 = ~v71;\n\tv75 = v74 | v69;\n\tif (v75) goto L_006C;\n\tv100 = effectiveCubeSize / this.m_referenceEffectiveCubeSize;\n\tv103 = v100 * this.m_particlesPerCube;\n\tv104 = v100 * v103;\n\tgoto L_0046;\nL_0046:\n\tv132 = v104 / 3f;\n\tgoto L_004C;\nL_004C:\n\tv144 = 0x8BF6AF4(&v173 @ stack_-68_v7 (System.Double), methodInfo, v39, v40, v41, v42, v43, v44, v132, v103, v46, v47, v48, v49, v50, v51);\n\tv157 = v132 < 0;\n\tv161 = v132 == v132;\n\tv162 = ~v161;\n\tv163 = v157 == v162;\n\tif (v163) goto L_00AE;\n\tv194 = v132 == -0.5d;\n\tv201 = ~v194;\n\tif (v201) goto L_00C7;\nL_FFFFFFFF:\n\tv252 = -1d;\nL_FFFFFFFF:\n\tv259 = v173;\nL_FFFFFFFF:\n\tv262 = v173;\n\tgoto L_00BA;\nL_006C:\n\tv91 = effectiveCubeSize;\n\tv93 = 0xB7D5000 + 0x538;\n\tv96 = \"il2cpp_vm_object_box\"(*([v93 @ X25_v4 (System.Int32)+78]), &v91 @ stack_-68_v2 (System.Single), v39, v40, v41, v42, v43, v44, v82, v45, v46, v47, v48, v49, v50, v51);\n\tv114 = this.m_referenceEffectiveCubeSize;\n\tv117 = \"il2cpp_vm_object_box\"(*([v93 @ X25_v4 (System.Int32)+78]), &v114 @ stack_-6C_v2 (System.Single), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, this.m_referenceEffectiveCubeSize, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv131 = System.String::Format(\"(effective={0}, reference={1}). \", v96, v117);\n\tv230 = System.String::Concat(\"ComputeForCellSize: invalid size \", v131, \"Returning base values.\");\n\tgoto L_008C;\nL_00AE:\n\tv217 = v132 == 0.5d;\n\tv224 = ~v217;\n\tif (v224) goto L_00CA;\nL_FFFFFFFF:\n\tv252 = 1d;\nL_FFFFFFFF:\n\tv259 = v173;\nL_FFFFFFFF:\n\tv262 = v173;\nL_FFFFFFFF:\n\tv276 = v259;\n\tgoto L_00C6;\nL_00C7:\n\tv237 = v132 + -0.5d;\n\tv276 = System.Math::Ceiling(v237);\n\tgoto L_00CD;\nL_00CA:\n\tv242 = v132 + 0.5d;\n\tv276 = System.Math::Floor(v242);\nL_00CD:\n\tv290 = v276 << 1;\n\tv315 = v276 + v290;\n\tv338 = this.m_particleRadius;\n\tv298 = v276 == 0x7FF0000000000000;\n\tv306 = ~v298;\n\tif (v306) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv315 = 0xFFFFFFFF80000000;\n\tgoto L_FFFFFFFF;\nL_0025:\n\tv57 = effectiveCubeSize == 0;\n\tv58 = effectiveCubeSize < 0;\n\tv59 = ~v58;\n\tv62 = ~v59;\n\tv63 = v62 | v57;\nL_FFFFFFFF:\n\tv82 = effectiveCubeSize;\n\tif (v63) goto L_006C;\nL_00BA:\n\tv276 = v259 + v252;\n\tv265 = v262 & 1;\n\tv267 = v265 == 0;\n\tv270 = ~v267;\n\tif (v270) goto L_00C6;\nL_008C:\n\tUnityEngine.Debug::LogWarning(v230);\n\tv244 = this.m_particlesPerCube;\n\tv338 = this.m_particleRadius;\n\tgoto L_00E6;\nL_00E6:\n\treturnVal1 = v244 | v338;\n\treturn returnVal1;\nL_00C6:\n\tgoto L_00CD;\nL_FFFFFFFF:\n\tv244 = v315;\n")]
		public SandParticleParams ComputeForCellSize(float effectiveCubeSize)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsConfig::ComputeForCellSize");
			return default;
		}

		[Token(Token = "0x60002C4")]
		[Address(RVA = "0x3C7B710", Offset = "0x3C7B710", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_particlesPerCube = 0x78;\n\tthis.m_particleRadius = 3.5652197146395728E-12d;\n\tthis.m_referenceEffectiveCubeSize = 0.8f;\n\tthis.m_shrinkBlockerQuadByParticleRadius = 1;\n\tthis.Gravity = -474480.75d;\n\tthis.MaxSpeed = *([9307DC0]);\n\tthis.SubThresholdDamping = 5.49316536535116E-05d;\n\tthis.SettleVelocityThreshold = 0.05f;\n\tthis.SettleFrameCount = 4.2439915844E-314d;\n\tthis.WakeUpRadius = 3.8146987284548574E-07d;\n\tthis.IsolatedSettleFrameThreshold = 6.36598737734E-313d;\n\tthis.TwoSidedCatchRadii = *([9307DD0]);\n\tthis.FlowZoneConvergeForce = *([9307DE0]);\n\tthis.SolverIterations = 3;\n\tthis.MaxRadiiPerStep = 2.0000004786998034d;\n\tthis.SettleUpdateInterval = 2;\n\tthis.SameColorCorrectionScale = *([9307DF0]);\n\tthis.SpawnGraceFrames = 0x3D4CCCCD0000000F;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public SandPhysicsConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsConfig::.ctor");
		}
	}
}
