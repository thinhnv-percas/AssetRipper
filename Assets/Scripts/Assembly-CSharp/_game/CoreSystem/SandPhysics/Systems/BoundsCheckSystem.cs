using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.ConveyorSystem;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.SDF;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(WallCollisionSystem))]
	[UpdateBefore(typeof(SettleDetectionSystem))]
	[Token(Token = "0x20000AF")]
	public struct BoundsCheckSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[WithDisabled(new Type[] { typeof(SettledTag) })]
		[Token(Token = "0x20000B0")]
		private struct BoundsCheckJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000B1")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000B2")]
				public struct TypeHandle
				{
					[Token(Token = "0x4000248")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x4000249")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x400024A")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[Token(Token = "0x400024B")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000313")]
					[Address(RVA = "0x3C7E604", Offset = "0x3C7E604", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000314")]
					[Address(RVA = "0x3C7D4C0", Offset = "0x3C7D4C0", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x4000246")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x4000247")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600030B")]
				[Address(RVA = "0x3C7DFC4", Offset = "0x3C7DFC4", Length = "0x300")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv88 = v84;\n\tv92 = Unity.Entities.EntityQueryBuilder::WithAll(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v92;\n\tv100 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v100;\n\tv107 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v107;\n\tv112 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v112;\n\tv117 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v117;\n\tv123 = Unity.Entities.EntityQueryBuilder::Build(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v123;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv126 = Unity.Entities.EntityQueryBuilder::Reset(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0036:\n\tv68 = 0;\n\tv72 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), v72);\n\tv84 = Unity.Entities.EntityQueryBuilder::WithDisabled(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabled<SettledTag>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithAllRW<ParticleSettleCounter>();
					entityQueryBuilder3 = entityQueryBuilder8;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x600030C")]
				[Address(RVA = "0x3C7E2C4", Offset = "0x3C7E2C4", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C7E144(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600030D")]
				[Address(RVA = "0x3C7E440", Offset = "0x3C7E440", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x40;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref BoundsCheckJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600030E")]
				[Address(RVA = "0x3C7E4C0", Offset = "0x3C7E4C0", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x40;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref BoundsCheckJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600030F")]
				[Address(RVA = "0x3C7E558", Offset = "0x3C7E558", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x40;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref BoundsCheckJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000310")]
				[Address(RVA = "0x3C7E5F0", Offset = "0x3C7E5F0", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref BoundsCheckJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000311")]
				[Address(RVA = "0x3C7E5F4", Offset = "0x3C7E5F4", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref BoundsCheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000312")]
				[Address(RVA = "0x3C7E600", Offset = "0x3C7E600", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref BoundsCheckJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000B3")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000315")]
				[Address(RVA = "0x3C7E748", Offset = "0x3C7E748", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x400023B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float particleRadius;

			[ReadOnly]
			[Token(Token = "0x400023C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public NativeArray<half> sdfValues;

			[Token(Token = "0x400023D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public float2 sdfOrigin;

			[Token(Token = "0x400023E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public float sdfCellSize;

			[Token(Token = "0x400023F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public int sdfGridWidth;

			[Token(Token = "0x4000240")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int sdfGridHeight;

			[Token(Token = "0x4000241")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public float maxRadiiPerStep;

			[Token(Token = "0x4000242")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public int wallPenetrationRescueFrames;

			[Token(Token = "0x4000243")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
			public bool hasConveyor;

			[Token(Token = "0x4000244")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public float2 conveyorRescuePos;

			[Token(Token = "0x4000245")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x60002F0")]
			[Address(RVA = "0x3C7D650", Offset = "0x3C7D650", Length = "0x84")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(state);\n\tv32 = v30 == 0;\n\tv33 = ~v32;\n\tif (v33) goto L_0025;\n\tv36 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(state);\n\tv38 = v36 == 0;\n\tif (v38) goto L_0034;\nL_0025:\n\treturn;\nL_0034:\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::ResolveBoundsViaSDF(this, pos, vel, state, ctr);\n\treturn;\n")]
			private void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState state, ref ParticleSettleCounter ctr)
			{
				if (!state.IsExited && !state.IsAbsorbing)
				{
					ResolveBoundsViaSDF(ref pos, ref vel, ref state, ref ctr);
				}
			}

			[Token(Token = "0x60002F1")]
			[Address(RVA = "0x3C7D6D4", Offset = "0x3C7D6D4", Length = "0x284")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\t// 53 MakeStruct v79 @ AGG3C7D760_1_v4 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 54 MakeStruct v80 @ AGG3C7D760_5_v4 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\tv254 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::SampleWithGradient(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v79, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v80, &v77 @ stack_-58_v5 (Unity.Mathematics.float2));\n\tv97 = v254 < 0;\n\tv101 = v254 == v254;\n\tv102 = ~v101;\n\tv103 = v97 == v102;\n\tif (v103) goto L_00EC;\n\tv107 = ctr.wallPenetrationFrames + 1;\n\tctr.wallPenetrationFrames = v107;\n\tv118 = v107 >= this.wallPenetrationRescueFrames;\n\tif (v118) goto L_00D8;\n\tgoto L_0063;\n\tv303 = -v254;\n\tv304 = this.particleRadius * this.maxRadiiPerStep;\n\tv263 = v304 & 0x7FFFFFFF;\n\tv306 = v263 < 0x7F800000;\n\tv307 = ~v306;\n\tv308 = v263 - 0x7F800000;\n\tv310 = v308 == 0;\n\tv313 = ~v307;\n\tv314 = v313 | v310;\n\tv315 = ~v314;\n\tif (v315) goto L_FFFFFFFF;\n\tv332 = v304 < v303;\n\tv331 = v304 == v303;\n\tv320 = v304 == v304;\n\tv321 = v303 == v303;\n\tv322 = v320 & v321;\n\tv328 = ~v322;\n\tgoto L_0098;\nL_FFFFFFFF:\n\tv328 = 0;\nL_FFFFFFFF:\n\tv331 = 0;\nL_FFFFFFFF:\n\tv332 = 0;\n\tgoto L_00A2;\n\t// 179 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv344 = v256 * v341;\n\tv255 = vel.value - v344;\n\tvel.value = v255;\n\tgoto L_00F8;\nL_00B9:\n\tv181 = *([B193010]);\n\tv86 = *([B193010]) - this.wallPenetrationRescueFrames;\n\tv87 = v86 < 0;\n\tv88 = v86 == 0;\n\tv89 = *([B193010]) ^ this.wallPenetrationRescueFrames;\n\tv90 = *([B193010]) ^ v86;\n\tv91 = v89 & v90;\n\tv92 = v91 < 0;\n\tv93 = v87 == v92;\n\tv94 = ~v88;\n\tv95 = v93 & v94;\n\tv96 = ~v95;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_00CD;\nL_FFFFFFFF:\n\tv181 = this.wallPenetrationRescueFrames;\n\tpos.value = this.conveyorRescuePos;\n\tvel.value = v293.zero;\n\tstate.flags = 0;\n\t*([B193000]) = 0;\n\t*([B193004]) = this.conveyorRescuePos;\n\t*([B19300C]) = 0;\n\tgoto L_00EC;\nL_00EB:\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsExited(state, 1);\nL_00EC:\n\t*([B193010]) = 0;\nL_0025:\n\t// 37 MakeStruct v63 @ AGG3C7D73C_0_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 38 MakeStruct v64 @ AGG3C7D73C_4_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\tv65 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::IsInsideGrid(v63, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v64);\n\tv67 = v65 == 0;\n\tif (v67) goto L_00B9;\nL_00D8:\n\tv138 = this.hasConveyor != 1;\n\tif (v138) goto L_00EB;\nL_0063:\n\tgoto L_0067;\nL_00F8:\n\treturn;\nL_0098:\n\tv333 = v332 == v328;\n\tv204 = ~v331;\n\tv334 = v333 & v204;\n\tv206 = ~v334;\n\tif (v206) goto L_00A2;\nL_00A2:\n\t// 162 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv256 = v77 / v251;\n\tv340 = v256 * v341;\n\tv342 = pos.value + v340;\n\tpos.value = v342;\n\t// 170 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv235 = this.maxRadiiPerStep < 0;\n\tv220 = ~v235;\n\tif (v220) goto L_00F8;\nL_00CD:\n\t*([B193010]) = v181;\nL_0067:\n\tv298 = v77 * v77;\n\t// 104 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv251 = UnityEngine.Mathf::Sqrt(v298);\n\tv234 = v251 < 0x3727C5AC;\n\tif (v234) goto L_00F8;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void ResolveBoundsViaSDF(ref ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState state, ref ParticleSettleCounter ctr)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob::ResolveBoundsViaSDF");
			}

			[CompilerGenerated]
			[Token(Token = "0x60002F2")]
			[Address(RVA = "0x3C7D958", Offset = "0x3C7D958", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0xB8;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00EC;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v60 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_011F;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = 0;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = v517;\n\tv452 = ~v443;\n\tv454 = ~v420;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v195 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v452, v454);\n\tv288 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v195);\n\tv293 = v288 == 0;\n\tif (v293) goto L_01B4;\n\tv541 = v420 + v297;\n\tv517 = v288 + v541;\n\tv527 = v541 >= v517;\nL_FFFFFFFF:\n\tv579 = v288;\n\tif (v527) goto L_FFFFFFFF;\nL_00B3:\n\t;\n\tv584 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v541);\n\tv617 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v541);\n\tv640 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v541);\n\tv652 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v541);\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::Execute(this, v584, v617, v640, v652);\n\tv541 = v541 + 1;\n\tv580 = v579 - 1;\n\tv546 = v579 != 1;\nL_FFFFFFFF:\n\tv579 = v580;\n\tif (v546) goto L_00B3;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01B4;\nL_FFFFFFFF:\n\tv385 = 0;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v385);\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::Execute(this, v403, v426, v449, v488);\n\tv385 = v385 + 1;\n\tv218 = v109 != v385;\n\tif (v218) goto L_00FA;\n\tgoto L_01B4;\nL_011F:\n\tv156 = v109 - 0x40;\n\tv157 = v156 < 0;\n\tv159 = v109 ^ 0x40;\n\tv160 = v109 ^ v156;\n\tv161 = v159 & v160;\n\tv162 = v161 < 0;\n\tv164 = v157 == v162;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = v109;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv298 = 0x40;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv483 = 0;\n\tgoto L_014C;\nL_0140:\n\tv302 = v302 >> 1;\n\tv483 = v483 + 1;\n\tv469 = v298 == v483;\n\tif (v469) goto L_017B;\nL_014C:\n\tv484 = v302 & 1;\n\tv294 = v484 == 0;\n\tif (v294) goto L_0140;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v483);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v483);\n\tv533 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v483);\n\tv592 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v483);\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::Execute(this, v495, v511, v533, v592);\n\tgoto L_0140;\nL_017B:\n\tv219 = v109 < 0x41;\n\tif (v219) goto L_01B4;\n\tv535 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv596 = 0x40;\n\tgoto L_018D;\nL_0181:\n\tv299 = v535 >> 1;\n\tv596 = v596 + 1;\n\tv249 = v109 == v596;\nL_FFFFFFFF:\n\tv535 = v299;\n\tif (v249) goto L_01B4;\nL_018D:\n\tv613 = v535 & 1;\n\tv295 = v613 == 0;\n\tif (v295) goto L_0181;\n\tv623 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v596);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v596);\n\tv658 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v596);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v596);\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::Execute(this, v623, v646, v658, v663);\n\tgoto L_0181;\nL_01B4:\n\tv324 = *([A4731E0]);\n\tv335 = *([v324 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v335) goto L_01CF;\n\treturn;\nL_01CF:\n\tv416 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x40;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0x68;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0x90;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v92);\nL_0080:\n\tv375 = v271;\n\tv379 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v297);\n\tv375 = v379;\n\tv420 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v379);\n\tv443 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v420);\nL_00FA:\n\tv403 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v385);\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v385);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v385);\nL_0139:\n\tv220 = v109 < 1;\n\tif (v220) goto L_01B4;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob::Execute");
			}

			[Token(Token = "0x60002F3")]
			[Address(RVA = "0x3C7DE64", Offset = "0x3C7DE64", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem.BoundsCheckJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x60002F4")]
			[Address(RVA = "0x3C7DEB8", Offset = "0x3C7DEB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002F5")]
			[Address(RVA = "0x3C7DEC4", Offset = "0x3C7DEC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002F6")]
			[Address(RVA = "0x3C7DED0", Offset = "0x3C7DED0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002F7")]
			[Address(RVA = "0x3C7DEDC", Offset = "0x3C7DEDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002F8")]
			[Address(RVA = "0x3C7DEE8", Offset = "0x3C7DEE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60002F9")]
			[Address(RVA = "0x3C7DEF4", Offset = "0x3C7DEF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FA")]
			[Address(RVA = "0x3C7DF00", Offset = "0x3C7DF00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FB")]
			[Address(RVA = "0x3C7DF0C", Offset = "0x3C7DF0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FC")]
			[Address(RVA = "0x3C7DF18", Offset = "0x3C7DF18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FD")]
			[Address(RVA = "0x3C7DF24", Offset = "0x3C7DF24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FE")]
			[Address(RVA = "0x3C7DF30", Offset = "0x3C7DF30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60002FF")]
			[Address(RVA = "0x3C7DF3C", Offset = "0x3C7DF3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000300")]
			[Address(RVA = "0x3C7DF48", Offset = "0x3C7DF48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000301")]
			[Address(RVA = "0x3C7DF54", Offset = "0x3C7DF54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000302")]
			[Address(RVA = "0x3C7DF60", Offset = "0x3C7DF60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000303")]
			[Address(RVA = "0x3C7DF6C", Offset = "0x3C7DF6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000304")]
			[Address(RVA = "0x3C7DF78", Offset = "0x3C7DF78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000305")]
			[Address(RVA = "0x3C7DF84", Offset = "0x3C7DF84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000306")]
			[Address(RVA = "0x3C7DF90", Offset = "0x3C7DF90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000307")]
			[Address(RVA = "0x3C7DF9C", Offset = "0x3C7DF9C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000308")]
			[Address(RVA = "0x3C7DFA8", Offset = "0x3C7DFA8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000309")]
			[Address(RVA = "0x3C7DFB4", Offset = "0x3C7DFB4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600030A")]
			[Address(RVA = "0x3C7DFC0", Offset = "0x3C7DFC0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000B4")]
		private struct TypeHandle
		{
			[Token(Token = "0x400024C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public BoundsCheckJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_BoundsCheckSystem_BoundsCheckJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6000316")]
			[Address(RVA = "0x3C7E74C", Offset = "0x3C7E74C", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x3C7E144(this, state, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv36 = 0x3C7E2FC(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E144 (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x180)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E2FC (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::Init +0x38)");
			}
		}

		[Token(Token = "0x400023A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x3C7D084", Offset = "0x3C7D084", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x3C7D0D8", Offset = "0x3C7D0D8", Length = "0x348")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = *([A4731E0]);\n\tv44 = *([B78D718]) & 1;\n\tv45 = v44 == 0;\n\tif (v45) goto L_0034;\n\tv73 = 0xB293000 + 0xDC8;\n\tv52 = *([B193A9A]) & 1;\n\tv53 = v52 == 0;\n\tv91 = v73;\n\tif (v53) goto L_0043;\nL_0026:\n\tv85 = *([v73 @ X22_v10 (System.Int32)]);\n\tv86 = *([v85 @ X8_v31+B8]);\n\tv103 = *([v86 @ X8_v32]);\n\tv88 = *([v86 @ X8_v32]) == 0;\n\tv89 = ~v88;\n\tif (v89) goto L_004F;\n\tgoto L_00F8;\nL_0034:\n\t*([B193718]) = 1;\n\tv73 = 0xB293000 + 0xDC8;\n\tv122 = *([B193A9A]) & 1;\n\tv123 = v122 == 0;\n\tv80 = ~v123;\n\tv91 = v73;\n\tif (v80) goto L_0026;\nL_0043:\n\t*([B193A9A]) = 1;\n\tv119 = *([v91 @ X22_v6 (System.Int32)]);\n\tv111 = *([v119 @ X8_v26+B8]);\n\tv103 = *([v111 @ X8_v27]);\n\tv108 = *([v111 @ X8_v27]) == 0;\n\tif (v108) goto L_00F8;\nL_004F:\n\tgoto L_0053;\nL_0053:\n\tv216 = UnityEngine.Object::op_Equality(*([v103 @ X22_v4+48]), 0);\n\tv227 = v216 == 0;\n\tif (v227) goto L_0062;\n\tgoto L_00F8;\nL_0062:\n\tv229 = *([v103 @ X22_v4+68]) == 0;\n\tif (v229) goto L_00F8;\n\tv219 = _game.CoreSystem.SandPhysics.SDF.SandSDFService::get_IsBuilt(*([v103 @ X22_v4+68]));\n\tv230 = ~v219;\n\tif (v230) goto L_00F8;\n\tv409 = _game.CoreSystem.SandPhysics.SDF.SandSDFService::GetSDFData(*([v103 @ X22_v4+68]));\n\tv401 = *([v103 @ X22_v4+60]);\n\tgoto L_007B;\nL_007B:\n\tv415 = UnityEngine.Object::op_Inequality(*([v103 @ X22_v4+60]), 0);\n\tv417 = ~v415;\n\tv418 = ~v417;\n\tif (v418) goto L_008A;\n\tgoto L_00A8;\nL_008A:\n\tv439 = *([v401 @ X21_v7 (UnityEngine.Object)+188]) & 1;\n\tv429 = v439 == 0;\n\tif (v429) goto L_00A8;\n\tv452 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMin(*([v103 @ X22_v4+60]));\n\tv460 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMax(*([v103 @ X22_v4+60]));\n\tgoto L_00A8;\nL_00A8:\n\tv178 = *([v103 @ X22_v4+38]) >> 0x20;\n\tv164 = &v155 @ stack_-190_v3 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob);\n\tv459 = Unity.Entities.SystemState::get_Dependency(state);\n\tv155 = v178;\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_00D6;\nL_00F8:\n\tv237 = *([A4731E0]);\n\tv248 = *([v237 @ X9_v4]) != *([v39 @ X8_v2]);\n\tif (v248) goto L_0117;\n\treturn;\nL_0117:\n\tv267 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthrow System.NullReferenceException;\nL_00D6:\n\t*([v164 @ X26_v4+A0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+60]);\n\t*([v164 @ X26_v4+B0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+70]);\n\t*([v164 @ X26_v4+C0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+80]);\n\t*([v164 @ X26_v4+D0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+90]);\n\t*([v164 @ X26_v4+60]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+20]);\n\t*([v164 @ X26_v4+70]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+30]);\n\t*([v164 @ X26_v4+80]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+40]);\n\t*([v164 @ X26_v4+90]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_BoundsCheckSystem_BoundsCheckJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;\n\t*([v164 @ X26_v4+40]) = this.__TypeHandle;\n\t*([v164 @ X26_v4+50]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem)+10]);\n\tv485 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v155 @ stack_-190_v3 (_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_BoundsCheckSystem_BoundsCheckJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v459);\n\tUnity.Entities.SystemState::set_Dependency(state, v485);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x3C7D420", Offset = "0x3C7D420", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0023;\nL_0023:\n\tv58 = job + 0x40;\n\tv61 = 0x8BF6A34(v58, this, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(BoundsCheckJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoundsCheckSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x3C7D598", Offset = "0x3C7D598", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x3C7D5DC", Offset = "0x3C7D5DC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C7E144(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C7E2FC(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E144 (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x180)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E2FC (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x3C7CFB8", Offset = "0x3C7CFB8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x3C7D00C", Offset = "0x3C7D00C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((BoundsCheckSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x3C7D010", Offset = "0x3C7D010", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C7E144(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C7E2FC(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E144 (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x180)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C7E2FC (inside _game.CoreSystem.SandPhysics.Systems.BoundsCheckSystem+BoundsCheckJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}
	}
}
