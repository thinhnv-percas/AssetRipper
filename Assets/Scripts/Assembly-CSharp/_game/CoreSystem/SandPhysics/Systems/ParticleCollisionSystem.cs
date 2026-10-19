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
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(IntegratePositionSystem))]
	[UpdateBefore(typeof(WallCollisionSystem))]
	[Token(Token = "0x20000B5")]
	public struct ParticleCollisionSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000B6")]
		private struct GatherCollisionDataJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000B7")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000B8")]
				public struct TypeHandle
				{
					[ReadOnly]
					[Token(Token = "0x400025A")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400025B")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400025C")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleRadius> ___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400025D")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400025E")]
					[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
					public ComponentTypeHandle<ParticleGameColor> ___game_CoreSystem_SandPhysics_Components_ParticleGameColor_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400025F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
					public ComponentTypeHandle<ParticleSpawnAge> ___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000342")]
					[Address(RVA = "0x3C80660", Offset = "0x3C80660", Length = "0x1CC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v113 @ stack_-E0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>);\n\tgoto L_003B;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle = *([v106 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v30 @ X23_v1+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v106 @ X8_v7+20]);\n\tv127 = &v135 @ stack_-108_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = *([v127 @ X8_v9]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = *([v127 @ X8_v9+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = *([v127 @ X8_v9+20]);\n\tv149 = &v156 @ stack_-130_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleGameColor>);\n\tv153 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleGameColor_RO_ComponentTypeHandle = *([v149 @ X8_v11]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+B0]) = *([v149 @ X8_v11+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+C0]) = *([v149 @ X8_v11+20]);\n\tv174 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RO_ComponentTypeHandle = v174.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+D8]) = v174.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+E8]) = v174.m_Length;\n\treturn;\nL_003B:\n\tv75 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v80;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = *([v30 @ X23_v1+50]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v30 @ X23_v1+60]);\n\tv84 = &v92 @ stack_-B8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv88 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle = *([v84 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v84 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v84 @ X8_v5+20]);\n\tv106 = &v113 @ stack_-E0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>);\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000343")]
					[Address(RVA = "0x3C7F01C", Offset = "0x3C7F01C", Length = "0x128")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleGameColor>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleGameColor_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleGameColor>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSpawnAge>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSpawnAge_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSpawnAge>), state);\n\treturn;\nL_0039:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>), state);\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x4000258")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x4000259")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600033A")]
				[Address(RVA = "0x3C7FE98", Offset = "0x3C7FE98", Length = "0x348")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv90 = v86;\n\tv94 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v94;\n\tv102 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v102;\n\tv110 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v110;\n\tv117 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v117;\n\tv122 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v122;\n\tv127 = Unity.Entities.EntityQueryBuilder::WithAll(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv90 = v127;\n\tv133 = Unity.Entities.EntityQueryBuilder::Build(&v90 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v133;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+F8]) = state;\n\tv136 = Unity.Entities.EntityQueryBuilder::Reset(&v70 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v70 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_003B:\n\tv70 = 0;\n\tv74 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v70 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), v74);\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAll(&v70 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<ParticleRadius>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAll<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAll<ParticleGameColor>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithAll<ParticleSpawnAge>();
					entityQueryBuilder3 = entityQueryBuilder8;
					EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder9;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder10 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x600033B")]
				[Address(RVA = "0x3C801E0", Offset = "0x3C801E0", Length = "0x204")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C8003C(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tv73 = &v74 @ stack_-10_v3;\n\tv77 = &v78 @ stack_-E0;\n\tgoto L_0050;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+50]) = *([v137 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+60]) = *([v77 @ X23_v1+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+70]) = *([v137 @ X8_v7+20]);\n\tv158 = &v159 @ stack_-108;\n\tv162 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+78]) = *([v158 @ X8_v9]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+88]) = *([v158 @ X8_v9+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+98]) = *([v158 @ X8_v9+20]);\n\tv180 = &v181 @ stack_-130;\n\tv184 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+A0]) = *([v180 @ X8_v11]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+B0]) = *([v180 @ X8_v11+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+C0]) = *([v180 @ X8_v11+20]);\n\tv205 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+C8]) = v205.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+D8]) = v205.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+E8]) = v205.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0022;\nL_0050:\n\tv107 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+20]) = *([v73 @ X29_v2-60]);\n\tv35.__TypeHandle = *([v77 @ X23_v1+50]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+10]) = *([v77 @ X23_v1+60]);\n\tv115 = &v116 @ stack_-B8;\n\tv119 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+28]) = *([v115 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+38]) = *([v115 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData)+48]) = *([v115 @ X8_v5+20]);\n\tv137 = &v78 @ stack_-E0;\n\tv140 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600033C")]
				[Address(RVA = "0x3C803E4", Offset = "0x3C803E4", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x70;\n\tv54 = 0x8BF6A34(v51, this, 0xF0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref GatherCollisionDataJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600033D")]
				[Address(RVA = "0x3C80464", Offset = "0x3C80464", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x70;\n\tv60 = 0x8BF6A34(v57, this, 0xF0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref GatherCollisionDataJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600033E")]
				[Address(RVA = "0x3C804FC", Offset = "0x3C804FC", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x70;\n\tv60 = 0x8BF6A34(v57, this, 0xF0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, dependency, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref GatherCollisionDataJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600033F")]
				[Address(RVA = "0x3C80598", Offset = "0x3C80598", Length = "0x50")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = query;\n\tquery.__seqno = query.__seqno;\n\tv19 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv21 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v19);\n\tv25 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArray(&v16 @ stack_-30_v1 (Unity.Entities.EntityQuery), v21);\n\tjob.__ChunkBaseEntityIndices = v25;\n\t*([job @ X1 (GatherCollisionDataJob&)+168]) = v21;\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref GatherCollisionDataJob job, EntityQuery query, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000340")]
				[Address(RVA = "0x3C805E8", Offset = "0x3C805E8", Length = "0x74")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = query;\n\tquery.__seqno = query.__seqno;\n\tv29 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv31 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v29);\n\tv39 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v24 @ stack_-40_v1 (Unity.Entities.EntityQuery), v31, dependency, &v35 @ stack_-50_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v39;\n\t*([job @ X1 (GatherCollisionDataJob&)+168]) = v31;\n\treturn v35;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref GatherCollisionDataJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000341")]
				[Address(RVA = "0x3C8065C", Offset = "0x3C8065C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref GatherCollisionDataJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000B9")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000344")]
				[Address(RVA = "0x3C8082C", Offset = "0x3C8082C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x400024F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> positions;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000250")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float2> velocities;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000251")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<float> radii;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000252")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<bool> settled;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000253")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public NativeArray<bool> ghosted;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000254")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public NativeArray<int> colors;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000255")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public NativeArray<ushort> spawnAges;

			[Token(Token = "0x4000256")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			[Token(Token = "0x4000257")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x160")]
			public NativeArray<int> __ChunkBaseEntityIndices;

			[Token(Token = "0x6000320")]
			[Address(RVA = "0x3C7F548", Offset = "0x3C7F548", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = this.positions;\n\t*([v30 @ X9_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]) = pos.value;\n\tv33 = this.velocities;\n\t*([v33 @ X9_v2 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]) = vel.value;\n\tv36 = this.radii;\n\t*([v36 @ X8_v3 (Unity.Collections.NativeArray`1<System.Single>)+idx @ X1 (System.Int32)*4]) = rad.value;\n\tv38 = st.flags;\n\tv43 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(&v38 @ stack_-44_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv44 = this.settled;\n\t*([v44 @ X8_v6 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]) = v43;\n\tv38 = st.flags;\n\tv51 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(&v38 @ stack_-44_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv53 = v51 == 0;\n\tif (v53) goto L_002E;\n\tv63 = 1;\n\tgoto L_0034;\nL_002E:\n\tv38 = st.flags;\n\tv63 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(&v38 @ stack_-44_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\nL_0034:\n\tv67 = this.ghosted;\n\t*([v67 @ X8_v10 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]) = v63;\n\tv69 = this.colors;\n\t*([v69 @ X9_v3 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]) = color.value;\n\tv71 = this.spawnAges;\n\t*([v71 @ X9_v4 (Unity.Collections.NativeArray`1<System.UInt16>)+idx @ X1 (System.Int32)*2]) = age.value;\n\treturn;\n")]
			private void Execute([EntityIndexInQuery] int idx, in ParticlePosition pos, in ParticleVelocity vel, in ParticleRadius rad, in ParticleState st, in ParticleGameColor color, in ParticleSpawnAge age)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x6000321")]
			[Address(RVA = "0x3C7F638", Offset = "0x3C7F638", Length = "0x700")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tgoto L_0053;\n\tv106 = this + 0xE8;\n\tv107 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v106);\n\tv115 = this + 0x110;\n\tv116 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v115);\n\tv124 = this + 0x138;\n\tv125 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v124);\n\tv132 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv138 = useEnabledMask == 0;\n\tif (v138) goto L_0128;\n\tv144 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv145 = v144 ^ chunkEnabledMask.Byte0;\n\t// 127 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 128 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 129 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 130 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 131 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 132 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv146 = v65 + v145;\n\tv148 = v146 < 5;\n\tv149 = ~v148;\n\tv150 = v146 - 5;\n\tv152 = v150 == 0;\n\tv157 = ~v152;\n\tv158 = v149 & v157;\n\tif (v158) goto L_0172;\nL_FFFFFFFF:\n\tv315 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv341 = 0;\nL_FFFFFFFF:\n\tv769 = 0;\n\tgoto L_00A3;\nL_FFFFFFFF:\n\tv315 = chunkEnabledMask.Byte0;\n\tv248 = v514;\n\tv553 = ~v540;\n\tv555 = ~v514;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v240 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v553, v555);\n\tv332 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v240);\n\tv337 = v332 == 0;\n\tif (v337) goto L_0237;\n\tv774 = v514 + v341;\n\tv341 = v332 + v774;\n\tv659 = v774 >= v341;\n\tif (v659) goto L_FFFFFFFF;\n\tv670 = v332 + v769;\nL_FFFFFFFF:\n\tv771 = v332;\n\tv846 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v107, v774);\n\tv856 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v116, v774);\n\tv871 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v125, v774);\n\tv692 = v769 + *([v777 @ X8_v67 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::Execute(this, v692, v782, v819, v834, v846, v856, v871);\n\tv774 = v774 + 1;\n\tv769 = v769 + 1;\n\tv700 = v771 - 1;\n\tv681 = v771 != 1;\nL_FFFFFFFF:\n\tv771 = v700;\n\tif (v681) goto L_00D6;\nL_FFFFFFFF:\n\tv769 = v670;\n\tgoto L_FFFFFFFF;\nL_0128:\n\tv169 = v132 < 1;\n\tif (v169) goto L_0237;\nL_FFFFFFFF:\n\tv485 = 0;\n\tv600 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v107, v485);\n\tv633 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v116, v485);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v125, v485);\n\tv328 = v485 + *([v489 @ X8_v10 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::Execute(this, v328, v495, v523, v550, v600, v633, v646);\n\tv485 = v485 + 1;\n\tv262 = v132 != v485;\n\tif (v262) goto L_012D;\n\tgoto L_0237;\nL_0172:\n\tv188 = v132 - 0x40;\n\tv189 = v188 < 0;\n\tv191 = v132 ^ 0x40;\n\tv192 = v132 ^ v188;\n\tv193 = v191 & v192;\n\tv194 = v193 < 0;\n\tv196 = v189 == v194;\n\tv197 = ~v196;\n\tv198 = ~v197;\n\tif (v198) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv362 = v132;\n\tgoto L_018C;\nL_FFFFFFFF:\n\tv362 = 0x40;\nL_FFFFFFFF:\n\tv367 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv589 = 0;\nL_FFFFFFFF:\n\tv387 = 0;\n\tgoto L_01A1;\nL_0195:\n\tv367 = v367 >> 1;\n\tv589 = v589 + 1;\n\tv572 = v362 == v589;\n\tif (v572) goto L_01E7;\nL_01A1:\n\tv594 = v367 & 1;\n\tv338 = v594 == 0;\n\tif (v338) goto L_0195;\n\tv604 = this.__ChunkBaseEntityIndices;\n\tv611 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v589);\n\tv639 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v89, v589);\n\tv665 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v98, v589);\n\tv711 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v107, v589);\n\tv788 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v116, v589);\n\tv824 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v125, v589);\n\tv618 = *([v604 @ X8_v29 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v387;\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::Execute(this, v618, v611, v639, v665, v711, v788, v824);\n\tv387 = v387 + 1;\n\tgoto L_0195;\nL_01E7:\n\tv263 = v132 < 0x41;\n\tif (v263) goto L_0237;\n\tv667 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv736 = 0x40;\n\tgoto L_01FA;\nL_01EE:\n\tv363 = v667 >> 1;\n\tv736 = v736 + 1;\n\tv293 = v132 == v736;\nL_FFFFFFFF:\n\tv667 = v363;\n\tif (v293) goto L_0237;\nL_01FA:\n\tv740 = v667 & 1;\n\tv339 = v740 == 0;\n\tif (v339) goto L_01EE;\n\tv791 = this.__ChunkBaseEntityIndices;\n\tv798 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v736);\n\tv830 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v89, v736);\n\tv840 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v98, v736);\n\tv852 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v107, v736);\n\tv862 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v116, v736);\n\tv876 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v125, v736);\n\tv805 = *([v791 @ X8_v47 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v387;\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::Execute(this, v805, v798, v830, v840, v852, v862, v876);\n\tv387 = v387 + 1;\n\tgoto L_01EE;\nL_0237:\n\tv393 = *([A4731E0]);\n\tv404 = *([v393 @ X9_v3]) != *([v37 @ X8_v2]);\n\tif (v404) goto L_0252;\n\treturn;\nL_0252:\n\tv508 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0053:\n\tv79 = this + 0x70;\n\tv80 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v79);\n\tv88 = this + 0x98;\n\tv89 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v88);\n\tv97 = this + 0xC0;\n\tv98 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v97);\nL_00A3:\n\tv455 = v315;\n\tv459 = Unity.Entities.EnabledBitUtility::ShiftRight(&v455 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v341);\n\tv455 = v459;\n\tv512 = v341;\n\tv514 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v459);\n\tv540 = Unity.Entities.EnabledBitUtility::ShiftRight(&v455 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v514);\nL_00D6:\n\tv777 = this.__ChunkBaseEntityIndices;\n\tv782 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v774);\n\tv819 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v89, v774);\n\tv834 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v98, v774);\nL_012D:\n\tv489 = this.__ChunkBaseEntityIndices;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v485);\n\tv523 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v89, v485);\n\tv550 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v98, v485);\nL_018C:\n\tv264 = v132 < 1;\n\tif (v264) goto L_0237;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob::Execute");
			}

			[Token(Token = "0x6000322")]
			[Address(RVA = "0x3C7FD38", Offset = "0x3C7FD38", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.GatherCollisionDataJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000323")]
			[Address(RVA = "0x3C7FD8C", Offset = "0x3C7FD8C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000324")]
			[Address(RVA = "0x3C7FD98", Offset = "0x3C7FD98", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000325")]
			[Address(RVA = "0x3C7FDA4", Offset = "0x3C7FDA4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000326")]
			[Address(RVA = "0x3C7FDB0", Offset = "0x3C7FDB0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000327")]
			[Address(RVA = "0x3C7FDBC", Offset = "0x3C7FDBC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000328")]
			[Address(RVA = "0x3C7FDC8", Offset = "0x3C7FDC8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000329")]
			[Address(RVA = "0x3C7FDD4", Offset = "0x3C7FDD4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600032A")]
			[Address(RVA = "0x3C7FDE0", Offset = "0x3C7FDE0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600032B")]
			[Address(RVA = "0x3C7FDEC", Offset = "0x3C7FDEC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600032C")]
			[Address(RVA = "0x3C7FDF8", Offset = "0x3C7FDF8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600032D")]
			[Address(RVA = "0x3C7FE04", Offset = "0x3C7FE04", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600032E")]
			[Address(RVA = "0x3C7FE10", Offset = "0x3C7FE10", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600032F")]
			[Address(RVA = "0x3C7FE1C", Offset = "0x3C7FE1C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000330")]
			[Address(RVA = "0x3C7FE28", Offset = "0x3C7FE28", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000331")]
			[Address(RVA = "0x3C7FE34", Offset = "0x3C7FE34", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000332")]
			[Address(RVA = "0x3C7FE40", Offset = "0x3C7FE40", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000333")]
			[Address(RVA = "0x3C7FE4C", Offset = "0x3C7FE4C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000334")]
			[Address(RVA = "0x3C7FE58", Offset = "0x3C7FE58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000335")]
			[Address(RVA = "0x3C7FE64", Offset = "0x3C7FE64", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000336")]
			[Address(RVA = "0x3C7FE70", Offset = "0x3C7FE70", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000337")]
			[Address(RVA = "0x3C7FE7C", Offset = "0x3C7FE7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000338")]
			[Address(RVA = "0x3C7FE88", Offset = "0x3C7FE88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000339")]
			[Address(RVA = "0x3C7FE94", Offset = "0x3C7FE94", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000BA")]
		private struct WriteBackCollisionJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000BB")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000BC")]
				public struct TypeHandle
				{
					[Token(Token = "0x4000266")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x4000267")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000367")]
					[Address(RVA = "0x3C81308", Offset = "0x3C81308", Length = "0xC4")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv53 = &v60 @ stack_-68_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv57 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = *([v53 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = *([v53 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v53 @ X8_v3+10]);\n\tv78 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = v78.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = v78.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = v78.m_Length;\n\treturn;\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000368")]
					[Address(RVA = "0x3C7F294", Offset = "0x3C7F294", Length = "0x88")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x4000264")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x4000265")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600035F")]
				[Address(RVA = "0x3C80DAC", Offset = "0x3C80DAC", Length = "0x208")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv70 = v69;\n\tv74 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tv70 = v74;\n\tv79 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tv70 = v79;\n\tv85 = Unity.Entities.EntityQueryBuilder::Build(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v85;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+58]) = state;\n\tv88 = Unity.Entities.EntityQueryBuilder::Reset(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0023:\n\tv54 = 0;\n\tv58 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), v58);\n\tv69 = Unity.Entities.EntityQueryBuilder::WithAll(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SandParticle>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000360")]
				[Address(RVA = "0x3C80FB4", Offset = "0x3C80FB4", Length = "0xD8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = ~assignDefaultQuery;\n\tif (v22) goto L_001B;\n\tv27 = 0x3C80EB0(this, state, 0, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001B:\n\tgoto L_0025;\nL_0025:\n\tv61 = &v68 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle);\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+20]) = *([v61 @ X8_v3+20]);\n\tthis.__TypeHandle = *([v61 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+10]) = *([v61 @ X8_v3+10]);\n\tv86 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+28]) = v86.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+38]) = v86.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData)+48]) = v86.m_Length;\n\treturn;\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000361")]
				[Address(RVA = "0x3C8108C", Offset = "0x3C8108C", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x20;\n\tv54 = 0x8BF6A34(v51, this, 0x50, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref WriteBackCollisionJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000362")]
				[Address(RVA = "0x3C8110C", Offset = "0x3C8110C", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x20;\n\tv60 = 0x8BF6A34(v57, this, 0x50, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref WriteBackCollisionJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000363")]
				[Address(RVA = "0x3C811A4", Offset = "0x3C811A4", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x20;\n\tv60 = 0x8BF6A34(v57, this, 0x50, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, dependency, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref WriteBackCollisionJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000364")]
				[Address(RVA = "0x3C81240", Offset = "0x3C81240", Length = "0x50")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = query;\n\tquery.__seqno = query.__seqno;\n\tv19 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv21 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v19);\n\tv25 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArray(&v16 @ stack_-30_v1 (Unity.Entities.EntityQuery), v21);\n\tjob.__ChunkBaseEntityIndices = v25;\n\t*([job @ X1 (WriteBackCollisionJob&)+78]) = v21;\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref WriteBackCollisionJob job, EntityQuery query, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000365")]
				[Address(RVA = "0x3C81290", Offset = "0x3C81290", Length = "0x74")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = query;\n\tquery.__seqno = query.__seqno;\n\tv29 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv31 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v29);\n\tv39 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v24 @ stack_-40_v1 (Unity.Entities.EntityQuery), v31, dependency, &v35 @ stack_-50_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v39;\n\t*([job @ X1 (WriteBackCollisionJob&)+78]) = v31;\n\treturn v35;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref WriteBackCollisionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000366")]
				[Address(RVA = "0x3C81304", Offset = "0x3C81304", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref WriteBackCollisionJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000BD")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000369")]
				[Address(RVA = "0x3C813CC", Offset = "0x3C813CC", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			[Token(Token = "0x4000260")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> posOut;

			[ReadOnly]
			[Token(Token = "0x4000261")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float2> velOut;

			[Token(Token = "0x4000262")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			[Token(Token = "0x4000263")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			public NativeArray<int> __ChunkBaseEntityIndices;

			[Token(Token = "0x6000345")]
			[Address(RVA = "0x3C80830", Offset = "0x3C80830", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.posOut;\n\tpos.value = *([v0 @ X8_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]);\n\tv5 = this.velOut;\n\tvel.value = *([v5 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]);\n\treturn;\n")]
			private void Execute([EntityIndexInQuery] int idx, ref ParticlePosition pos, ref ParticleVelocity vel)
			{
				//IL_001f: Expected O, but got I
				//IL_003e: Expected O, but got I
				NativeArray<float2> nativeArray = posOut;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]");
				pos.value = (float2)0;
				NativeArray<float2> nativeArray2 = velOut;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]");
				vel.value = (float2)0;
			}

			[CompilerGenerated]
			[Token(Token = "0x6000346")]
			[Address(RVA = "0x3C8084C", Offset = "0x3C8084C", Length = "0x400")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tgoto L_0032;\n\tv92 = useEnabledMask == 0;\n\tif (v92) goto L_00CA;\n\tv95 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv96 = v95 ^ chunkEnabledMask.Byte0;\n\t// 70 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 71 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 72 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 73 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 74 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 75 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv97 = v57 + v96;\n\tv99 = v97 < 5;\n\tv100 = ~v99;\n\tv101 = v97 - 5;\n\tv103 = v101 == 0;\n\tv108 = ~v103;\n\tv109 = v100 & v108;\n\tif (v109) goto L_00F0;\nL_FFFFFFFF:\n\tv546 = 0;\nL_FFFFFFFF:\n\tv240 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv272 = 0;\n\tgoto L_0064;\nL_FFFFFFFF:\n\tv240 = chunkEnabledMask.Byte0;\n\tv418 = ~v412;\n\tv420 = ~v389;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v161 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v418, v420);\n\tv257 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v161);\n\tv262 = v257 == 0;\n\tif (v262) goto L_0170;\n\tv567 = v389 + v272;\n\tv272 = v257 + v567;\n\tv489 = v567 >= v272;\n\tif (v489) goto L_FFFFFFFF;\n\tv493 = v257 + v546;\nL_FFFFFFFF:\n\tv566 = v257;\n\tv567 = v567 + 1;\n\tv546 = v546 + 1;\n\tv521 = v566 - 1;\n\tv502 = v566 != 1;\nL_FFFFFFFF:\n\tv566 = v521;\n\tif (v502) goto L_0099;\nL_FFFFFFFF:\n\tv546 = v493;\n\tgoto L_FFFFFFFF;\nL_00CA:\n\tv120 = v87 < 1;\n\tif (v120) goto L_0170;\nL_FFFFFFFF:\n\tv366 = 0;\n\tv366 = v366 + 1;\n\tv187 = v87 != v366;\n\tif (v187) goto L_00D1;\n\tgoto L_0170;\nL_00F0:\n\tv130 = v87 - 0x40;\n\tv131 = v130 < 0;\n\tv133 = v87 ^ 0x40;\n\tv134 = v87 ^ v130;\n\tv135 = v133 & v134;\n\tv136 = v135 < 0;\n\tv138 = v131 == v136;\n\tv139 = ~v138;\n\tv140 = ~v139;\n\tif (v140) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv274 = v87;\n\tgoto L_010A;\nL_FFFFFFFF:\n\tv274 = 0x40;\nL_FFFFFFFF:\n\tv180 = 0;\nL_FFFFFFFF:\n\tv184 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv449 = 0;\n\tgoto L_011E;\nL_0112:\n\tv184 = v184 >> 1;\n\tv449 = v449 + 1;\n\tv434 = v274 == v449;\n\tif (v434) goto L_0142;\nL_011E:\n\tv450 = v184 & 1;\n\tv263 = v450 == 0;\n\tif (v263) goto L_0112;\n\tv453 = this.__ChunkBaseEntityIndices;\n\tv461 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v71, v449);\n\tv474 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v449);\n\tv465 = *([v453 @ X8_v14 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v180;\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::Execute(this, v465, v461, v474);\n\tv180 = v180 + 1;\n\tgoto L_0112;\nL_0142:\n\tv188 = v87 < 0x41;\n\tif (v188) goto L_0170;\n\tv491 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv539 = 0x40;\n\tgoto L_0154;\nL_0148:\n\tv291 = v491 >> 1;\n\tv539 = v539 + 1;\n\tv218 = v87 == v539;\nL_FFFFFFFF:\n\tv491 = v291;\n\tif (v218) goto L_0170;\nL_0154:\n\tv543 = v491 & 1;\n\tv264 = v543 == 0;\n\tif (v264) goto L_0148;\n\tv572 = this.__ChunkBaseEntityIndices;\n\tv580 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v71, v539);\n\tv598 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v539);\n\tv584 = *([v572 @ X8_v22 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v180;\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::Execute(this, v584, v580, v598);\n\tv180 = v180 + 1;\n\tgoto L_0148;\nL_0170:\n\tv294 = *([A4731E0]);\n\tv305 = *([v294 @ X9_v3]) != *([v37 @ X8_v2]);\n\tif (v305) goto L_018B;\n\treturn;\nL_018B:\n\tv385 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0032:\n\tv70 = this + 0x20;\n\tv71 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v70);\n\tv79 = this + 0x48;\n\tv80 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v79);\n\tv87 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\nL_0064:\n\tv345 = v240;\n\tv349 = Unity.Entities.EnabledBitUtility::ShiftRight(&v345 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v272);\n\tv345 = v349;\n\tv389 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v349);\n\tv412 = Unity.Entities.EnabledBitUtility::ShiftRight(&v345 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v389);\nL_0099:\n\tv519 = this.__ChunkBaseEntityIndices;\n\tv571 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v71, v567);\n\tv593 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v567);\n\tv513 = v546 + *([v519 @ X8_v32 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::Execute(this, v513, v571, v593);\nL_00D1:\n\tv278 = this.__ChunkBaseEntityIndices;\n\tv372 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v71, v366);\n\tv395 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v80, v366);\n\tv253 = v366 + *([v278 @ X8_v9 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::Execute(this, v253, v372, v395);\nL_010A:\n\tv189 = v87 < 1;\n\tif (v189) goto L_0170;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob::Execute");
			}

			[Token(Token = "0x6000347")]
			[Address(RVA = "0x3C80C4C", Offset = "0x3C80C4C", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.WriteBackCollisionJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000348")]
			[Address(RVA = "0x3C80CA0", Offset = "0x3C80CA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000349")]
			[Address(RVA = "0x3C80CAC", Offset = "0x3C80CAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600034A")]
			[Address(RVA = "0x3C80CB8", Offset = "0x3C80CB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600034B")]
			[Address(RVA = "0x3C80CC4", Offset = "0x3C80CC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600034C")]
			[Address(RVA = "0x3C80CD0", Offset = "0x3C80CD0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600034D")]
			[Address(RVA = "0x3C80CDC", Offset = "0x3C80CDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600034E")]
			[Address(RVA = "0x3C80CE8", Offset = "0x3C80CE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600034F")]
			[Address(RVA = "0x3C80CF4", Offset = "0x3C80CF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000350")]
			[Address(RVA = "0x3C80D00", Offset = "0x3C80D00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000351")]
			[Address(RVA = "0x3C80D0C", Offset = "0x3C80D0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000352")]
			[Address(RVA = "0x3C80D18", Offset = "0x3C80D18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000353")]
			[Address(RVA = "0x3C80D24", Offset = "0x3C80D24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000354")]
			[Address(RVA = "0x3C80D30", Offset = "0x3C80D30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000355")]
			[Address(RVA = "0x3C80D3C", Offset = "0x3C80D3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000356")]
			[Address(RVA = "0x3C80D48", Offset = "0x3C80D48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000357")]
			[Address(RVA = "0x3C80D54", Offset = "0x3C80D54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000358")]
			[Address(RVA = "0x3C80D60", Offset = "0x3C80D60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000359")]
			[Address(RVA = "0x3C80D6C", Offset = "0x3C80D6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600035A")]
			[Address(RVA = "0x3C80D78", Offset = "0x3C80D78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600035B")]
			[Address(RVA = "0x3C80D84", Offset = "0x3C80D84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600035C")]
			[Address(RVA = "0x3C80D90", Offset = "0x3C80D90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600035D")]
			[Address(RVA = "0x3C80D9C", Offset = "0x3C80D9C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600035E")]
			[Address(RVA = "0x3C80DA8", Offset = "0x3C80DA8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000BE")]
		private struct ResolveCollisionsJob : IJobParallelFor
		{
			[ReadOnly]
			[Token(Token = "0x4000268")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> positions;

			[ReadOnly]
			[Token(Token = "0x4000269")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float2> velocities;

			[ReadOnly]
			[Token(Token = "0x400026A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<float> radii;

			[ReadOnly]
			[Token(Token = "0x400026B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<bool> settled;

			[ReadOnly]
			[Token(Token = "0x400026C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public NativeArray<bool> ghosted;

			[ReadOnly]
			[Token(Token = "0x400026D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public NativeArray<int> colors;

			[ReadOnly]
			[Token(Token = "0x400026E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public NativeArray<ushort> spawnAges;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x400026F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			public NativeArray<float2> posOut;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000270")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			public NativeArray<float2> velOut;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000271")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
			public NativeArray<int> contactCounts;

			[ReadOnly]
			[Token(Token = "0x4000272")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
			public NativeParallelMultiHashMap<int2, int> grid;

			[Token(Token = "0x4000273")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
			public float cellSize;

			[Token(Token = "0x4000274")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB4")]
			public float restitution;

			[Token(Token = "0x4000275")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB8")]
			public float contactDamping;

			[Token(Token = "0x4000276")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xBC")]
			public float maxCorrection;

			[Token(Token = "0x4000277")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC0")]
			public bool isFirstIteration;

			[Token(Token = "0x4000278")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC4")]
			public float sameColorCorrectionScale;

			[Token(Token = "0x4000279")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
			public float diffColorCorrectionScale;

			[Token(Token = "0x400027A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xCC")]
			public int spawnGraceFrames;

			[Token(Token = "0x400027B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xD0")]
			public float spawnGraceCorrectionScale;

			[Token(Token = "0x600036A")]
			[Address(RVA = "0x3C813D0", Offset = "0x3C813D0", Length = "0x4EC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv80 = this.ghosted;\n\tv82 = *([v80 @ X8_v6 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) & 1;\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0230;\n\tv218 = this.positions;\n\tv220 = this.velocities;\n\tv608 = *([v220 @ X8_v9 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv222 = this.radii;\n\tgoto L_004F;\nL_0052:\n\tv268 = UnityEngine.Mathf::Floor(v240);\n\tv269 = v246 / this.cellSize;\n\tgoto L_0063;\nL_0067:\n\tv285 = UnityEngine.Mathf::Floor(v269);\n\tv489 = v290.zero;\n\tv307 = v269 << 0x20;\n\tv296 = v285 == 0x7F800000;\n\tv304 = ~v296;\n\tif (v304) goto L_0082;\nL_FFFFFFFF:\n\tv307 = 0x8000000000000000;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv320 = 0xFFFFFFFF80000000;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv320 = v268;\nL_009A:\n\tv362 = v362 + 1;\n\tv358 = v362 == 2;\nL_FFFFFFFF:\n\tv449 = v113;\nL_FFFFFFFF:\n\tv485 = v172;\nL_FFFFFFFF:\n\tv489 = v367;\n\tif (v358) goto L_0185;\nL_00A7:\n\tv134 = v362 + v320;\nL_FFFFFFFF:\n\tv394 = -1;\n\tgoto L_00B6;\nL_00AA:\n\tv394 = v394 + 1;\n\tv409 = v394 == 2;\nL_FFFFFFFF:\n\tv449 = v113;\nL_FFFFFFFF:\n\tv485 = v172;\nL_FFFFFFFF:\n\tv489 = v367;\n\tif (v409) goto L_009A;\nL_00B6:\n\tv129 = v394 << 0x20;\n\tv423 = v307 + v129;\n\tv427 = v423 | v134;\n\tv431 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetFirstValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v427, &v429 @ stack_-94_v5 (System.Int32), &v69 @ stack_-A8_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv432 = ~v431;\n\tv433 = ~v432;\n\tif (v433) goto L_00D6;\nL_FFFFFFFF:\n\tv113 = v449;\nL_FFFFFFFF:\n\tv172 = v485;\nL_FFFFFFFF:\n\tv367 = v489;\n\tgoto L_00AA;\nL_00C4:\n\tv485 = v485 + 1;\n\tv555 = v449 * v721;\n\tv557 = v489 + v555;\nL_FFFFFFFF:\n\tv489 = v557;\nL_00D6:\n\tv503 = v429 == i;\n\tif (v503) goto L_00CA;\n\tv517 = this.ghosted;\n\tv519 = *([v517 @ X9_v14 (Unity.Collections.NativeArray`1<System.Boolean>)+v429 @ stack_-94_v5 (System.Int32)]) & 1;\n\tv520 = v519 == 0;\n\tv521 = ~v520;\n\tif (v521) goto L_00CA;\n\tv568 = this.positions;\n\tv553 = this.radii;\n\tgoto L_00F3;\nL_00F5:\n\tv556 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) + *([v553 @ X9_v17 (Unity.Collections.NativeArray`1<System.Single>)+v429 @ stack_-94_v5 (System.Int32)*4]);\n\tv449 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) - *([v568 @ X9_v16 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v429 @ stack_-94_v5 (System.Int32)*8]);\n\tv589 = v449 * v449;\n\t// 249 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv558 = UnityEngine.Mathf::Sqrt(v589);\n\tv615 = v558 < v556;\n\tv538 = ~v615;\n\tif (v538) goto L_FFFFFFFF;\n\tv550 = v558 < 0x358637BD;\n\tv548 = v558 == 0x358637BD;\n\tv644 = v558 == v558;\n\tv540 = ~v644;\n\tgoto L_0114;\nL_FFFFFFFF:\n\tv540 = 0;\nL_FFFFFFFF:\n\tv548 = 1;\nL_FFFFFFFF:\n\tv550 = 0;\n\t// 280 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv449 = v449 / 0x358637BD;\n\tv747 = v742 < 0x3E99999A;\n\tv748 = v742 == 0x3E99999A;\n\tv751 = v742 == v742;\n\tv754 = ~v751;\n\tv755 = v747 == v754;\n\tv524 = ~v748;\n\tv756 = v755 & v524;\n\tif (v756) goto L_0139;\n\tv797 = v742 < 0xFFFFFFFFBE99999A;\n\tif (v797) goto L_0139;\n\tgoto L_015B;\n\tv863 = this.spawnAges;\n\tv890 = *([v863 @ X10_v14 (Unity.Collections.NativeArray`1<System.UInt16>)+v429 @ stack_-94_v5 (System.Int32)*2]);\n\tv866 = *([v863 @ X10_v14 (Unity.Collections.NativeArray`1<System.UInt16>)+i @ X1 (System.Int32)*2]) < *([v863 @ X10_v14 (Unity.Collections.NativeArray`1<System.UInt16>)+v429 @ stack_-94_v5 (System.Int32)*2]);\n\tv867 = ~v866;\n\tv875 = ~v867;\n\tv876 = ~v875;\n\tif (v876) goto L_0170;\nL_FFFFFFFF:\n\tv890 = *([v863 @ X10_v14 (Unity.Collections.NativeArray`1<System.UInt16>)+i @ X1 (System.Int32)*2]);\n\tgoto L_0170;\n\tgoto L_00C4;\nL_0185:\n\tv574 = this.contactCounts;\n\t*([v574 @ X8_v42 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = v172;\n\tv575 = v172 == 0;\n\tif (v575) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv778 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tgoto L_0193;\nL_0193:\n\t// 403 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv715 = UnityEngine.Mathf::Sqrt(*([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]));\n\tv653 = v715 < this.maxCorrection;\n\tv654 = v715 == this.maxCorrection;\n\tv657 = v715 == v715;\n\tv658 = this.maxCorrection == this.maxCorrection;\n\tv659 = v657 & v658;\n\tv660 = ~v659;\n\tv661 = v653 == v660;\n\tv662 = ~v654;\n\tv663 = v661 & v662;\nL_FFFFFFFF:\n\tv777 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tif (v663) goto L_01DC;\n\tv694 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) < 0x322BCC77;\n\tv695 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) == 0x322BCC77;\n\tv698 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) == *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]);\n\tv701 = ~v698;\n\tv702 = v694 == v701;\n\tv703 = ~v695;\n\tv704 = v702 & v703;\nL_FFFFFFFF:\n\tv767 = v367;\n\tif (v704) goto L_01F4;\nL_FFFFFFFF:\n\tv777 = v778;\nL_FFFFFFFF:\n\tv607 = v367;\n\tgoto L_0218;\nL_FFFFFFFF:\n\tv111 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tgoto L_0219;\nL_01DC:\n\t// 476 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv719 = v367 / v715;\n\tv767 = v719 * v721;\n\t// 480 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv726 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) < 0x322BCC77;\n\tv727 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) == 0x322BCC77;\n\tv730 = *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) == *([v222 @ X8_v10 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]);\n\tv733 = ~v730;\n\tv734 = v726 == v733;\n\tv735 = ~v734;\n\tv736 = v735 | v727;\nL_FFFFFFFF:\n\tv778 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\nL_FFFFFFFF:\n\tv607 = v767;\n\tif (v736) goto L_0218;\nL_01F4:\n\tgoto L_01FF;\n\t// 528 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv787 = v788 + v113;\n\tv893 = v785 * v894;\n\t// 533 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv784 = v893 * v787;\n\tv608 = v608 + v784;\nL_FFFFFFFF:\n\tv777 = v778;\nL_FFFFFFFF:\n\tv607 = v767;\nL_0028:\n\tv69 = 0;\n\tv71 = this.settled;\n\tv74 = *([v71 @ X8_v3 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) & 1;\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_0230;\nL_0230:\n\treturn;\nL_004F:\n\tv240 = *([v218 @ X8_v8 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) / this.cellSize;\n\tgoto L_0052;\nL_0063:\n\tgoto L_0067;\nL_0082:\n\tv309 = v268 == 0x7F800000;\n\tv317 = ~v309;\n\tif (v317) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv362 = -1;\nL_FFFFFFFF:\n\tv485 = 0;\n\tgoto L_00A7;\nL_00CA:\n\t;\n\tv493 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetNextValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), &v429 @ stack_-94_v5 (System.Int32), &v69 @ stack_-A8_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv495 = v493 == 0;\nL_FFFFFFFF:\n\tv113 = v449;\nL_FFFFFFFF:\n\tv172 = v485;\nL_FFFFFFFF:\n\tv367 = v489;\n\tif (v495) goto L_00AA;\nL_00F3:\n\tgoto L_00F5;\nL_0114:\n\tv667 = v550 == v540;\n\tv668 = ~v667;\n\tv526 = v668 | v548;\n\tif (v526) goto L_00CA;\nL_0139:\n\tv815 = this.colors;\n\tv830 = *([v815 @ X8_v31 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) != *([v815 @ X8_v31 (Unity.Collections.NativeArray`1<System.Int32>)+v429 @ stack_-94_v5 (System.Int32)*4]);\n\tif (v830) goto L_015B;\nL_015B:\n\tv859 = this.spawnGraceFrames < 1;\n\tif (v859) goto L_00C4;\nL_0170:\n\tv898 = this.spawnGraceFrames < v890;\n\tv887 = ~v898;\n\tv8\n// ... truncated")]
			public void Execute(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.ResolveCollisionsJob::Execute");
			}
		}

		[Token(Token = "0x20000BF")]
		private struct TypeHandle
		{
			[Token(Token = "0x400027C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public GatherCollisionDataJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_GatherCollisionDataJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x400027D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x100")]
			public WriteBackCollisionJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_WriteBackCollisionJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x600036B")]
			[Address(RVA = "0x3C818BC", Offset = "0x3C818BC", Length = "0xEC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = 0x3C8003C(this, state, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0x3C80218(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv41 = this + 0x100;\n\tv44 = 0x3C80EB0(v41, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0029;\nL_0029:\n\tv62 = &v69 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob+InternalCompilerQueryAndHandleData);\n\tv66 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_WriteBackCollisionJob_WithDefaultQuery_JobEntityTypeHandle = *([v62 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+TypeHandle)+110]) = *([v62 @ X8_v3+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+TypeHandle)+120]) = *([v62 @ X8_v3+20]);\n\tv87 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+TypeHandle)+128]) = v87.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+TypeHandle)+138]) = v87.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+TypeHandle)+148]) = v87.m_Length;\n\treturn;\n")]
			public unsafe void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x400024D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x400024E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x160")]
		private EntityQuery __query_677296250_0;

		[Token(Token = "0x6000317")]
		[Address(RVA = "0x3C7E7DC", Offset = "0x3C7E7DC", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0x3C7E830", Offset = "0x3C7E830", Length = "0x6F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\tgoto L_0026;\n\tgoto L_006A;\nL_006A:\n\tv410 = UnityEngine.Object::op_Equality(v116.Config, 0);\n\tv416 = v410 == 0;\n\tv398 = 0;\n\tv403 = 0;\n\tif (v416) goto L_0078;\n\tgoto L_0211;\nL_0078:\n\tv407 = v116.Buffers;\n\tv418 = v116.Buffers == 0;\n\tif (v418) goto L_0211;\n\tv393 = v116.Config;\n\tv419 = v116.Config == 0;\n\tif (v419) goto L_0212;\n\t*([v32 @ X29_v1-B0]) = this.__query_677296250_0;\n\tv637 = &v33 @ stack_-10_v2 - 0xB0;\n\tv413 = Unity.Entities.EntityQuery::CalculateEntityCount(v637);\n\tv345 = v413 < 2;\n\tif (v345) goto L_0211;\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::EnsureCapacity(v116.Buffers, v413);\n\tv660 = v407.Positions;\n\tv672 = Unity.Entities.SystemState::get_Dependency(state);\n\tv690 = v407.Positions;\n\t*([v32 @ X29_v1-90]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_GatherCollisionDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery;\n\t*([v32 @ X29_v1-88]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_GatherCollisionDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery.__seqno;\n\t*([v32 @ X29_v1-A0]) = 0;\n\t*([v32 @ X29_v1-98]) = 0;\n\tv700 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv713 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v700);\n\tv725 = &v33 @ stack_-10_v2 - 0x90;\n\tv726 = &v33 @ stack_-10_v2 - 0xA0;\n\tv730 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(v725, v713, v672, v726);\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0119;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Copy(v407.Velocities, v407.VelOut, v413);\n\tv930 = v407.PosOut;\n\tv946 = v407.PosNext;\n\t*([v32 @ X29_v1-D0]) = v407.VelNext;\n\t*([v32 @ X29_v1-C0]) = v407.VelOut;\n\tv839 = v393.SolverIterations < 1;\n\tv229 = v393.SolverIterations;\n\tif (v839) goto L_01B9;\n\tv942 = 0;\n\tv800 = v1022;\n\tUnity.Jobs.JobHandle::Complete(&v800 @ stack_-260_v3 (Unity.Jobs.JobHandle));\n\tv942 = v942 + 1;\n\t*([v32 @ X29_v1-D0]) = *([v32 @ X29_v1-C0]);\n\t*([v32 @ X29_v1-C0]) = *([v32 @ X29_v1-D0]);\n\tv880 = v393.SolverIterations != v942;\n\tv229 = v393.SolverIterations;\n\tv930 = v946;\n\tv946 = v946;\n\tif (v880) goto L_015A;\nL_01B9:\n\tv904 = v229 & 1;\n\tv415 = v904 == 0;\n\tif (v415) goto L_01DF;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Copy(v407.PosNext, v407.PosOut, v413);\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Copy(v407.VelNext, v407.VelOut, v413);\nL_01DF:\n\tv978 = Unity.Entities.SystemState::get_Dependency(state);\n\tv690 = *([v807 @ X19_v10]);\n\tv995 = 0x3C7EDD4(this, &v690 @ stack_-450_v2 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_WriteBackCollisionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_WriteBackCollisionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery.__seqno, v978, 0, state, 0, 0, 0, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv800 = v995;\n\tUnity.Jobs.JobHandle::Complete(&v800 @ stack_-260_v3 (Unity.Jobs.JobHandle));\nL_0211:\n\treturn;\nL_0212:\n\tv638 = new System.NullReferenceException();\n\tv470 = 0;\n\tv398.__seqno = v47;\n\tv653 = Unity.Entities.SystemState::get_WorldUpdateAllocator(v50);\n\tv659 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v653);\n\tv679 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v470 @ stack_-510_v1 (Unity.Entities.EntityQuery), v659, v48, &v464 @ stack_-520_v2 (Unity.Jobs.JobHandle));\n\t*([v403 @ X1_v2 (UnityEngine.Object)+70]) = v679;\n\t*([v403 @ X1_v2 (UnityEngine.Object)+78]) = v659;\n\tgoto L_024F;\nL_0026:\n\t*([v32 @ X29_v1-B0]) = 0;\n\t*([v32 @ X29_v1-A8]) = 0;\n\t*([v32 @ X29_v1-C0]) = 0;\n\t*([v32 @ X29_v1-B8]) = 0;\n\t*([v32 @ X29_v1-D0]) = 0;\n\t*([v32 @ X29_v1-C8]) = 0;\n\tgoto L_005D;\nL_0119:\n\tv284 = &v690 @ stack_-450_v2 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob);\n\tv798 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(&v690 @ stack_-450_v2 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ParticleCollisionSystem_GatherCollisionDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, *([v32 @ X29_v1-A0]), v730);\n\tv800 = v798;\n\tUnity.Jobs.JobHandle::Complete(&v800 @ stack_-260_v3 (Unity.Jobs.JobHandle));\n\tv807 = v116.Buffers + 0x80;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::Copy(v407.Positions, v407.PosOut, v413);\nL_015A:\n\tv951 = Unity.Entities.SystemState::get_Dependency(state);\n\tv986 = _game.CoreSystem.SandPhysics.SandPhysicsBuffers::BuildSpatialHash(v116.Buffers, v413, v116.<Params>k__BackingField.SpatialHashCellSize, v951, v930);\n\tv660.velocities = *([v32 @ X29_v1-C0]);\n\tv660.radii = v407.Radii;\n\tv660.settled = v407.Settled;\n\tv660.ghosted = v407.Ghosted;\n\tv660.colors = v407.Colors;\n\tv660.spawnAges = v407.SpawnAges;\n\t*([v32 @ X29_v1-90]) = v407.ContactCounts;\n\t*([v284 @ X26_v8+A0]) = v407.SpatialGrid;\n\t*([v284 @ X26_v8+C1]) = 0;\n\t*([v284 @ X26_v8+C3]) = 0;\n\tv875 = v930;\n\t*([v284 @ X26_v8+80]) = *([v32 @ X29_v1-D0]);\n\t*([v284 @ X26_v8+90]) = v407.ContactCounts;\n\tv1018 = &v1019 @ stack_-48B;\n\t*([v1018 @ X9_v8+FF]) = v393.SameColorCorrectionScale;\n\tv1022 = Unity.Jobs.IJobParallelForExtensions::Schedule(&v875 @ stack_-450_v6 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v413, 0x40, v986);\nL_024F:\n\tv722 = v638 + 0x100;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v722, v50);\n\tv734 = v638 + 0x128;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v734, v50);\n\tgoto L_0263;\nL_0263:\n\tv761 = v403 + 0x20;\n\tv762 = v638 + 0x100;\n\tv764 = 0x8BF6A34(v761, v762, 0x50, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv619 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(v403, 0, v464, *([v403 @ X1_v2 (UnityEngine.Object)+70]));\n\treturn;\nL_005D:\n\tv116 = v115.<Current>k__BackingField;\n\tv117 = v115.<Current>k__BackingField == 0;\n\tif (v117) goto L_0211;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000319")]
		[Address(RVA = "0x3C7EF24", Offset = "0x3C7EF24", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = query;\n\tquery.__seqno = query.__seqno;\n\tv42 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv44 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v42);\n\tv52 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v36 @ stack_-60_v1 (Unity.Entities.EntityQuery), v44, dependency, &v48 @ stack_-70_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v52;\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob)+168]) = v44;\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+GatherCollisionDataJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0039;\nL_0039:\n\tv79 = job + 0x70;\n\tv82 = 0x8BF6A34(v79, this, 0xF0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, v48, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(GatherCollisionDataJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600031A")]
		[Address(RVA = "0x3C7F144", Offset = "0x3C7F144", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = query;\n\tquery.__seqno = query.__seqno;\n\tv46 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv48 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v46);\n\tv56 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v40 @ stack_-70_v1 (Unity.Entities.EntityQuery), v48, dependency, &v52 @ stack_-80_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v56;\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem+WriteBackCollisionJob)+78]) = v48;\n\tgoto L_003E;\nL_003E:\n\tv85 = this + 0x100;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v85, state);\n\tv90 = this + 0x128;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v90, state);\n\tgoto L_0052;\nL_0052:\n\tv105 = job + 0x20;\n\tv106 = this + 0x100;\n\tv108 = 0x8BF6A34(v105, v106, 0x50, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, v52, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_1(WriteBackCollisionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem::__ScheduleViaJobChunkExtension_1");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600031B")]
		[Address(RVA = "0x3C7F31C", Offset = "0x3C7F31C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_677296250_0 = v61;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+168]) = state;\n\tv64 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SandParticle, ParticlePosition, ParticleVelocity, ParticleRadius, ParticleState>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQuery _query_677296250_ = entityQueryBuilder3.Build(ref state);
			__query_677296250_0 = _query_677296250_;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0x3C7F3D0", Offset = "0x3C7F3D0", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv60 = v59;\n\tv65 = Unity.Entities.EntityQueryBuilder::Build(&v60 @ stack_-90_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_677296250_0 = v65;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+168]) = state;\n\tv68 = Unity.Entities.EntityQueryBuilder::Reset(&v49 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v49 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder));\n\tv74 = 0x3C8003C(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv78 = 0x3C80218(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv79 = this + 0x100;\n\tv82 = 0x3C80EB0(v79, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0052;\nL_0019:\n\tv49 = 0;\n\tv53 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v49 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder), v53);\n\tv59 = Unity.Entities.EntityQueryBuilder::WithAll(&v49 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder));\nL_0052:\n\tv100 = &v49 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder);\n\tv103 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tv49 = v49._builderDataPtr;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+100]) = v49._builderDataPtr;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+110]) = *([v100 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+120]) = *([v100 @ X8_v5+20]);\n\tv123 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+128]) = v123.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+138]) = v123.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem)+148]) = v123.m_Length;\n\treturn;\n")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600031D")]
		[Address(RVA = "0x3C7E780", Offset = "0x3C7E780", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600031E")]
		[Address(RVA = "0x3C7E7D4", Offset = "0x3C7E7D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((ParticleCollisionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600031F")]
		[Address(RVA = "0x3C7E7D8", Offset = "0x3C7E7D8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ParticleCollisionSystem::OnCreateForCompiler(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ParticleCollisionSystem::__codegen__OnCreateForCompiler");
		}
	}
}
