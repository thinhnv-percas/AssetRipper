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
	[UpdateAfter(typeof(BoundsCheckSystem))]
	[UpdateBefore(typeof(SyncTransformSystem))]
	[Token(Token = "0x20000EE")]
	public struct SettleDetectionSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000EF")]
		private struct GatherSettleDataJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000F0")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000F1")]
				public struct TypeHandle
				{
					[ReadOnly]
					[Token(Token = "0x400030D")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400030E")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400030F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x4000310")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000506")]
					[Address(RVA = "0x3C8F2EC", Offset = "0x3C8F2EC", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RO_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000507")]
					[Address(RVA = "0x3C8E0C0", Offset = "0x3C8E0C0", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400030B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x400030C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004FE")]
				[Address(RVA = "0x3C8EC4C", Offset = "0x3C8EC4C", Length = "0x2A8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = v78;\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v86;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v93;\n\tv98 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v98;\n\tv103 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v103;\n\tv109 = Unity.Entities.EntityQueryBuilder::Build(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v109;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv112 = Unity.Entities.EntityQueryBuilder::Reset(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002F:\n\tv62 = 0;\n\tv66 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v66);\n\tv78 = Unity.Entities.EntityQueryBuilder::WithAll(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAll<ParticleSettleCounter>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x60004FF")]
				[Address(RVA = "0x3C8EEF4", Offset = "0x3C8EEF4", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C8EDA0(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000500")]
				[Address(RVA = "0x3C8F070", Offset = "0x3C8F070", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x70;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref GatherSettleDataJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000501")]
				[Address(RVA = "0x3C8F0F0", Offset = "0x3C8F0F0", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x70;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref GatherSettleDataJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000502")]
				[Address(RVA = "0x3C8F188", Offset = "0x3C8F188", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x70;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, dependency, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref GatherSettleDataJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000503")]
				[Address(RVA = "0x3C8F224", Offset = "0x3C8F224", Length = "0x50")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = query;\n\tquery.__seqno = query.__seqno;\n\tv19 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv21 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v19);\n\tv25 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArray(&v16 @ stack_-30_v1 (Unity.Entities.EntityQuery), v21);\n\tjob.__ChunkBaseEntityIndices = v25;\n\t*([job @ X1 (GatherSettleDataJob&)+118]) = v21;\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref GatherSettleDataJob job, EntityQuery query, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000504")]
				[Address(RVA = "0x3C8F274", Offset = "0x3C8F274", Length = "0x74")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = query;\n\tquery.__seqno = query.__seqno;\n\tv29 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv31 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v29);\n\tv39 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v24 @ stack_-40_v1 (Unity.Entities.EntityQuery), v31, dependency, &v35 @ stack_-50_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v39;\n\t*([job @ X1 (GatherSettleDataJob&)+118]) = v31;\n\treturn v35;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref GatherSettleDataJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000505")]
				[Address(RVA = "0x3C8F2E8", Offset = "0x3C8F2E8", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref GatherSettleDataJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000F2")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000508")]
				[Address(RVA = "0x3C8F430", Offset = "0x3C8F430", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000302")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> positions;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000303")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float> speeds;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000304")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<bool> settled;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000305")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<bool> exitedIn;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000306")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public NativeArray<int> countersIn;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000307")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public NativeArray<float2> anchorsIn;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000308")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public NativeArray<int> isolatedFramesIn;

			[Token(Token = "0x4000309")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			[Token(Token = "0x400030A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x110")]
			public NativeArray<int> __ChunkBaseEntityIndices;

			[Token(Token = "0x60004E4")]
			[Address(RVA = "0x3C8E42C", Offset = "0x3C8E42C", Length = "0x13C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = this.positions;\n\t*([v32 @ X9_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]) = pos.value;\n\tgoto L_0026;\nL_0028:\n\tv65 = vel.value * vel.value;\n\t// 41 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv66 = UnityEngine.Mathf::Sqrt(v65);\n\tv67 = this.speeds;\n\t*([v67 @ X8_v5 (Unity.Collections.NativeArray`1<System.Single>)+idx @ X1 (System.Int32)*4]) = v66;\n\tv68 = st.flags;\n\tv69 = st.flags;\n\tv68.lastConveyorSegment = st.lastConveyorSegment;\n\tv74 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(&v69 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv75 = this.settled;\n\t*([v75 @ X8_v8 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]) = v74;\n\tv69 = st.flags;\n\tv68.lastConveyorSegment = st.lastConveyorSegment;\n\tv82 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(&v69 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv84 = v82 == 0;\n\tif (v84) goto L_0043;\n\tv96 = 1;\n\tgoto L_0049;\nL_0043:\n\tv69 = st.flags;\n\tv68.lastConveyorSegment = st.lastConveyorSegment;\n\tv96 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(&v69 @ stack_-54_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\nL_0049:\n\tv98 = this.exitedIn;\n\t*([v98 @ X8_v12 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]) = v96;\n\tv100 = this.countersIn;\n\t*([v100 @ X9_v2 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]) = ctr.framesBelowThreshold;\n\tv102 = this.anchorsIn;\n\t*([v102 @ X9_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]) = ctr.anchorPosition;\n\tv104 = this.isolatedFramesIn;\n\t*([v104 @ X9_v4 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]) = ctr.isolatedFrames;\n\treturn;\nL_0026:\n\tgoto L_0028;\n")]
			private void Execute([EntityIndexInQuery] int idx, in ParticlePosition pos, in ParticleVelocity vel, in ParticleState st, in ParticleSettleCounter ctr)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x60004E5")]
			[Address(RVA = "0x3C8E568", Offset = "0x3C8E568", Length = "0x584")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0xE8;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00F7;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v61 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_0131;\nL_FFFFFFFF:\n\tv281 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv309 = 0;\nL_FFFFFFFF:\n\tv664 = 0;\n\tgoto L_0084;\nL_FFFFFFFF:\n\tv281 = chunkEnabledMask.Byte0;\n\tv489 = ~v479;\n\tv491 = ~v456;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v207 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v489, v491);\n\tv300 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v207);\n\tv305 = v300 == 0;\n\tif (v305) goto L_01D3;\n\tv672 = v456 + v309;\n\tv309 = v300 + v672;\n\tv575 = v672 >= v309;\n\tif (v575) goto L_FFFFFFFF;\n\tv585 = v300 + v664;\nL_FFFFFFFF:\n\tv671 = v300;\n\tv729 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v672);\n\tv603 = v664 + *([v673 @ X8_v43 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::Execute(this, v603, v678, v704, v716, v729);\n\tv672 = v672 + 1;\n\tv664 = v664 + 1;\n\tv613 = v671 - 1;\n\tv591 = v671 != 1;\nL_FFFFFFFF:\n\tv671 = v613;\n\tif (v591) goto L_00B6;\nL_FFFFFFFF:\n\tv664 = v585;\n\tgoto L_FFFFFFFF;\nL_00F7:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01D3;\nL_FFFFFFFF:\n\tv428 = 0;\n\tv531 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v428);\n\tv296 = v428 + *([v433 @ X8_v9 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::Execute(this, v296, v439, v462, v486, v531);\n\tv428 = v428 + 1;\n\tv228 = v109 != v428;\n\tif (v228) goto L_0100;\n\tgoto L_01D3;\nL_0131:\n\tv163 = v109 - 0x40;\n\tv164 = v163 < 0;\n\tv166 = v109 ^ 0x40;\n\tv167 = v109 ^ v163;\n\tv168 = v166 & v167;\n\tv169 = v168 < 0;\n\tv171 = v164 == v169;\n\tv172 = ~v171;\n\tv173 = ~v172;\n\tif (v173) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv311 = v109;\n\tgoto L_014B;\nL_FFFFFFFF:\n\tv311 = 0x40;\nL_FFFFFFFF:\n\tv519 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv338 = 0;\nL_FFFFFFFF:\n\tv525 = 0;\n\tgoto L_015F;\nL_0153:\n\tv519 = v519 >> 1;\n\tv525 = v525 + 1;\n\tv506 = v311 == v525;\n\tif (v506) goto L_0194;\nL_015F:\n\tv526 = v519 & 1;\n\tv306 = v526 == 0;\n\tif (v306) goto L_0153;\n\tv533 = this.__ChunkBaseEntityIndices;\n\tv541 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v525);\n\tv559 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v525);\n\tv581 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v525);\n\tv619 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v525);\n\tv547 = *([v533 @ X8_v17 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v338;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::Execute(this, v547, v541, v559, v581, v619);\n\tv338 = v338 + 1;\n\tgoto L_0153;\nL_0194:\n\tv229 = v109 < 0x41;\n\tif (v229) goto L_01D3;\n\tv583 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv316 = v109;\nL_FFFFFFFF:\n\tv639 = 0x40;\n\tgoto L_01A6;\nL_019A:\n\tv312 = v583 >> 1;\n\tv639 = v639 + 1;\n\tv259 = v316 == v639;\nL_FFFFFFFF:\n\tv583 = v312;\n\tif (v259) goto L_01D3;\nL_01A6:\n\tv644 = v583 & 1;\n\tv307 = v644 == 0;\n\tif (v307) goto L_019A;\n\tv679 = this.__ChunkBaseEntityIndices;\n\tv687 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v639);\n\tv710 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v639);\n\tv722 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v639);\n\tv734 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v639);\n\tv693 = *([v679 @ X8_v29 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v338;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::Execute(this, v693, v687, v710, v722, v734);\n\tv338 = v338 + 1;\nL_FFFFFFFF:\n\tv316 = v109;\n\tgoto L_019A;\nL_01D3:\n\tv351 = *([A4731E0]);\n\tv362 = *([v351 @ X9_v3]) != *([v37 @ X8_v2]);\n\tif (v362) goto L_01EE;\n\treturn;\nL_01EE:\n\tv452 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x70;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0x98;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0xC0;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v92);\nL_0084:\n\tv404 = v281;\n\tv408 = Unity.Entities.EnabledBitUtility::ShiftRight(&v404 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v309);\n\tv404 = v408;\n\tv456 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v408);\n\tv479 = Unity.Entities.EnabledBitUtility::ShiftRight(&v404 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v456);\nL_00B6:\n\tv673 = this.__ChunkBaseEntityIndices;\n\tv678 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v672);\n\tv704 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v672);\n\tv716 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v672);\nL_0100:\n\tv433 = this.__ChunkBaseEntityIndices;\n\tv439 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v428);\n\tv462 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v428);\n\tv486 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v428);\nL_014B:\n\tv230 = v109 < 1;\n\tif (v230) goto L_01D3;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob::Execute");
			}

			[Token(Token = "0x60004E6")]
			[Address(RVA = "0x3C8EAEC", Offset = "0x3C8EAEC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.GatherSettleDataJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x60004E7")]
			[Address(RVA = "0x3C8EB40", Offset = "0x3C8EB40", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004E8")]
			[Address(RVA = "0x3C8EB4C", Offset = "0x3C8EB4C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004E9")]
			[Address(RVA = "0x3C8EB58", Offset = "0x3C8EB58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004EA")]
			[Address(RVA = "0x3C8EB64", Offset = "0x3C8EB64", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004EB")]
			[Address(RVA = "0x3C8EB70", Offset = "0x3C8EB70", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004EC")]
			[Address(RVA = "0x3C8EB7C", Offset = "0x3C8EB7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004ED")]
			[Address(RVA = "0x3C8EB88", Offset = "0x3C8EB88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004EE")]
			[Address(RVA = "0x3C8EB94", Offset = "0x3C8EB94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004EF")]
			[Address(RVA = "0x3C8EBA0", Offset = "0x3C8EBA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F0")]
			[Address(RVA = "0x3C8EBAC", Offset = "0x3C8EBAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F1")]
			[Address(RVA = "0x3C8EBB8", Offset = "0x3C8EBB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F2")]
			[Address(RVA = "0x3C8EBC4", Offset = "0x3C8EBC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F3")]
			[Address(RVA = "0x3C8EBD0", Offset = "0x3C8EBD0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F4")]
			[Address(RVA = "0x3C8EBDC", Offset = "0x3C8EBDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F5")]
			[Address(RVA = "0x3C8EBE8", Offset = "0x3C8EBE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F6")]
			[Address(RVA = "0x3C8EBF4", Offset = "0x3C8EBF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F7")]
			[Address(RVA = "0x3C8EC00", Offset = "0x3C8EC00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F8")]
			[Address(RVA = "0x3C8EC0C", Offset = "0x3C8EC0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004F9")]
			[Address(RVA = "0x3C8EC18", Offset = "0x3C8EC18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004FA")]
			[Address(RVA = "0x3C8EC24", Offset = "0x3C8EC24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004FB")]
			[Address(RVA = "0x3C8EC30", Offset = "0x3C8EC30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004FC")]
			[Address(RVA = "0x3C8EC3C", Offset = "0x3C8EC3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004FD")]
			[Address(RVA = "0x3C8EC48", Offset = "0x3C8EC48", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000F3")]
		private struct WriteBackSettleJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000F4")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000F5")]
				public struct TypeHandle
				{
					[Token(Token = "0x400031D")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[Token(Token = "0x400031E")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle;

					[Token(Token = "0x400031F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x4000320")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x4000321")]
					[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
					public ComponentTypeHandle<SettledTag> ___game_CoreSystem_SandPhysics_Components_SettledTag_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x600052B")]
					[Address(RVA = "0x3DA4A74", Offset = "0x3DA4A74", Length = "0x188")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = *([v103 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v103 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v103 @ X8_v7+20]);\n\tv125 = &v132 @ stack_-100_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv129 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v125 @ X8_v9]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = *([v125 @ X8_v9+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = *([v125 @ X8_v9+20]);\n\tv150 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_SettledTag_RW_ComponentTypeHandle = v150.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+B0]) = v150.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+C0]) = v150.m_Length;\n\treturn;\nL_0035:\n\tv71 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v76;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = v68;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v78;\n\tv81 = &v89 @ stack_-B0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>);\n\tv85 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle = *([v81 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v81 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v81 @ X8_v5+20]);\n\tv103 = &v111 @ stack_-D8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv107 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x600052C")]
					[Address(RVA = "0x3DA4BFC", Offset = "0x3DA4BFC", Length = "0xFC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.SettledTag>::Update(&this.___game_CoreSystem_SandPhysics_Components_SettledTag_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.SettledTag>), state);\n\treturn;\nL_0032:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>), state);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400031B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x400031C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000523")]
				[Address(RVA = "0x3DA4338", Offset = "0x3DA4338", Length = "0x300")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv88 = v84;\n\tv92 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v92;\n\tv100 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v100;\n\tv107 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v107;\n\tv112 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v112;\n\tv117 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v117;\n\tv123 = Unity.Entities.EntityQueryBuilder::Build(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v123;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+D0]) = state;\n\tv126 = Unity.Entities.EntityQueryBuilder::Reset(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0036:\n\tv68 = 0;\n\tv72 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), v72);\n\tv84 = Unity.Entities.EntityQueryBuilder::WithAll(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SandParticle>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAllRW<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticleSettleCounter>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithAllRW<SettledTag>();
					entityQueryBuilder3 = entityQueryBuilder8;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000524")]
				[Address(RVA = "0x3DA4638", Offset = "0x3DA4638", Length = "0x1C0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3DA44B8(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tv73 = &v74 @ stack_-10_v3;\n\tgoto L_004A;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+50]) = *([v133 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+60]) = *([v133 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+70]) = *([v133 @ X8_v7+20]);\n\tv155 = &v156 @ stack_-100;\n\tv159 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+78]) = *([v155 @ X8_v9]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+88]) = *([v155 @ X8_v9+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+98]) = *([v155 @ X8_v9+20]);\n\tv180 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+A0]) = v180.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+B0]) = v180.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+C0]) = v180.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0022;\nL_004A:\n\tv103 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+20]) = *([v73 @ X29_v2-58]);\n\tv35.__TypeHandle = *([v73 @ X29_v2-78]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+10]) = *([v73 @ X29_v2-68]);\n\tv111 = &v112 @ stack_-B0;\n\tv115 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+28]) = *([v111 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+38]) = *([v111 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData)+48]) = *([v111 @ X8_v5+20]);\n\tv133 = &v134 @ stack_-D8;\n\tv137 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000525")]
				[Address(RVA = "0x3DA47F8", Offset = "0x3DA47F8", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x50;\n\tv54 = 0x8BF6A34(v51, this, 0xC8, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref WriteBackSettleJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000526")]
				[Address(RVA = "0x3DA4878", Offset = "0x3DA4878", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x50;\n\tv60 = 0x8BF6A34(v57, this, 0xC8, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref WriteBackSettleJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000527")]
				[Address(RVA = "0x3DA4910", Offset = "0x3DA4910", Length = "0x9C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x50;\n\tv60 = 0x8BF6A34(v57, this, 0xC8, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, dependency, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref WriteBackSettleJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000528")]
				[Address(RVA = "0x3DA49AC", Offset = "0x3DA49AC", Length = "0x50")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = query;\n\tquery.__seqno = query.__seqno;\n\tv19 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv21 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v19);\n\tv25 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArray(&v16 @ stack_-30_v1 (Unity.Entities.EntityQuery), v21);\n\tjob.__ChunkBaseEntityIndices = v25;\n\t*([job @ X1 (WriteBackSettleJob&)+120]) = v21;\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref WriteBackSettleJob job, EntityQuery query, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000529")]
				[Address(RVA = "0x3DA49FC", Offset = "0x3DA49FC", Length = "0x74")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = query;\n\tquery.__seqno = query.__seqno;\n\tv29 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv31 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v29);\n\tv39 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v24 @ stack_-40_v1 (Unity.Entities.EntityQuery), v31, dependency, &v35 @ stack_-50_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v39;\n\t*([job @ X1 (WriteBackSettleJob&)+120]) = v31;\n\treturn v35;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref WriteBackSettleJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob.InternalCompilerQueryAndHandleData::UpdateBaseEntityIndexArray");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600052A")]
				[Address(RVA = "0x3DA4A70", Offset = "0x3DA4A70", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref WriteBackSettleJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000F6")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x600052D")]
				[Address(RVA = "0x3DA4CF8", Offset = "0x3DA4CF8", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			[Token(Token = "0x4000311")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<bool> settledOut;

			[ReadOnly]
			[Token(Token = "0x4000312")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<int> countersOut;

			[ReadOnly]
			[Token(Token = "0x4000313")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<float2> anchorsOut;

			[ReadOnly]
			[Token(Token = "0x4000314")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<int> isolatedFramesOut;

			[Token(Token = "0x4000315")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public bool hasConveyor;

			[Token(Token = "0x4000316")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x41")]
			public bool isGateClosed;

			[Token(Token = "0x4000317")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
			public float2 conveyorRescuePos;

			[Token(Token = "0x4000318")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
			public int wallPenetrationRescueFrames;

			[Token(Token = "0x4000319")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[ReadOnly]
			[Token(Token = "0x400031A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x118")]
			public NativeArray<int> __ChunkBaseEntityIndices;

			[Token(Token = "0x6000509")]
			[Address(RVA = "0x3C8F434", Offset = "0x3C8F434", Length = "0x220")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv71 = this.isolatedFramesOut;\n\tv73 = *([v71 @ X8_v15 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]) & 0x80000000;\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_0089;\n\tv87 = this.settledOut;\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsSettled(st, *([v87 @ X8_v29 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]));\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>::set_ValueRW(settledTag, *([v87 @ X8_v29 (Unity.Collections.NativeArray`1<System.Boolean>)+idx @ X1 (System.Int32)]));\n\tv118 = this.countersOut;\n\tctr.framesBelowThreshold = *([v118 @ X8_v32 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]);\n\tv120 = this.anchorsOut;\n\tctr.anchorPosition = *([v120 @ X8_v34 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+idx @ X1 (System.Int32)*8]);\n\tv122 = this.isolatedFramesOut;\n\tctr.isolatedFrames = *([v122 @ X8_v36 (Unity.Collections.NativeArray`1<System.Int32>)+idx @ X1 (System.Int32)*4]);\n\treturn;\nL_005F:\n\tv86 = this.hasConveyor != 1;\n\tif (v86) goto L_0077;\n\tpos.value = this.conveyorRescuePos;\n\tvel.value = v99.zero;\n\tst.flags = 0;\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>::set_ValueRW(settledTag, 0);\n\tctr.framesBelowThreshold = 0;\n\tctr.anchorPosition = this.conveyorRescuePos;\n\tgoto L_0079;\nL_0077:\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsExited(st, 1);\n\tctr.framesBelowThreshold = 0;\nL_0089:\n\tv94 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsVacuumReserved(st);\n\tv115 = v94 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_00BE;\n\tv136 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsOnConveyor(st);\n\tv220 = v136 == 0;\n\tv165 = ~v220;\n\tif (v165) goto L_00BE;\n\tv138 = this.hasConveyor != 1;\n\tif (v138) goto L_00BC;\n\tv223 = this.isGateClosed == 0;\n\tv166 = ~v223;\n\tif (v166) goto L_00BE;\n\tpos.value = this.conveyorRescuePos;\n\tvel.value = v228.zero;\n\tst.flags = 0;\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>::set_ValueRW(settledTag, 0);\n\tctr.framesBelowThreshold = 0;\n\tctr.anchorPosition = this.conveyorRescuePos;\n\tgoto L_00BE;\nL_00BC:\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsExited(st, 1);\n\tctr.framesBelowThreshold = 0;\nL_002C:\n\tv68 = ctr.wallPenetrationFrames >= this.wallPenetrationRescueFrames;\n\tif (v68) goto L_005F;\nL_0079:\n\tctr.isolatedFrames = 0;\n\tctr.wallPenetrationFrames = 0;\n\treturn;\nL_00BE:\n\tctr.isolatedFrames = 0;\n\treturn;\n")]
			private unsafe void Execute([EntityIndexInQuery] int idx, ref ParticleState st, ref ParticleSettleCounter ctr, ref ParticlePosition pos, ref ParticleVelocity vel, EnabledRefRW<SettledTag> settledTag)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x600050A")]
			[Address(RVA = "0x3C8F654", Offset = "0x3C8F654", Length = "0x688")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = *([A4731E0]);\n\tgoto L_004A;\n\tv103 = this + 0xC8;\n\tv104 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v103);\n\tv112 = this + 0xF0;\n\tv114 = Unity.Entities.ArchetypeChunk::GetEnabledMask(chunk, v112);\n\tv119 = v111;\n\tv111.m_PtrChunkDisabledCount = v121;\n\tv125 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv131 = useEnabledMask == 0;\n\tif (v131) goto L_0113;\n\tv137 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv138 = v137 ^ chunkEnabledMask.Byte0;\n\t// 115 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 116 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 117 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 118 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 119 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 120 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv139 = v63 + v138;\n\tv141 = v139 < 5;\n\tv142 = ~v141;\n\tv143 = v139 - 5;\n\tv145 = v143 == 0;\n\tv150 = ~v145;\n\tv151 = v142 & v150;\n\tif (v151) goto L_015A;\nL_FFFFFFFF:\n\tv304 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv338 = 0;\nL_FFFFFFFF:\n\tv753 = 0;\n\tgoto L_0094;\nL_FFFFFFFF:\n\tv304 = chunkEnabledMask.Byte0;\n\tv243 = v503;\n\tv542 = ~v528;\n\tv544 = ~v503;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v232 @ stack_-B0_v12 (Unity.Burst.Intrinsics.v128), v542, v544);\n\tv329 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v232);\n\tv334 = v329 == 0;\n\tif (v334) goto L_0216;\n\tv760 = v503 + v338;\n\tv338 = v329 + v760;\n\tv644 = v760 >= v338;\n\tif (v644) goto L_FFFFFFFF;\n\tv655 = v329 + v753;\nL_FFFFFFFF:\n\tv756 = v329;\n\tv829 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v760);\n\tv842 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v119 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v760);\n\tv663 = v842;\n\tv679 = v753 + *([v761 @ X8_v60 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::Execute(this, v679, v766, v804, v816, v829, &v663 @ stack_-B0_v14 (Unity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>));\n\tv760 = v760 + 1;\n\tv753 = v753 + 1;\n\tv685 = v756 - 1;\n\tv664 = v756 != 1;\nL_FFFFFFFF:\n\tv756 = v685;\n\tif (v664) goto L_00C7;\nL_FFFFFFFF:\n\tv753 = v655;\n\tgoto L_FFFFFFFF;\nL_0113:\n\tv162 = v125 < 1;\n\tif (v162) goto L_0216;\nL_FFFFFFFF:\n\tv474 = 0;\n\tv589 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v474);\n\tv622 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v119 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v474);\n\tv234 = v622;\n\tv325 = v474 + *([v480 @ X8_v11 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]);\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::Execute(this, v325, v486, v511, v539, v589, &v234 @ stack_-B0_v3 (Unity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>));\n\tv474 = v474 + 1;\n\tv249 = v125 != v474;\n\tif (v249) goto L_011A;\n\tgoto L_0216;\nL_015A:\n\tv179 = v125 - 0x40;\n\tv180 = v179 < 0;\n\tv182 = v125 ^ 0x40;\n\tv183 = v125 ^ v179;\n\tv184 = v182 & v183;\n\tv185 = v184 < 0;\n\tv187 = v180 == v185;\n\tv188 = ~v187;\n\tv189 = ~v188;\n\tif (v189) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv344 = v125;\n\tgoto L_0174;\nL_FFFFFFFF:\n\tv344 = 0x40;\nL_FFFFFFFF:\n\tv349 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv378 = 0;\nL_FFFFFFFF:\n\tv584 = 0;\n\tgoto L_0188;\nL_017C:\n\tv349 = v349 >> 1;\n\tv584 = v584 + 1;\n\tv561 = v344 == v584;\n\tif (v561) goto L_01CA;\nL_0188:\n\tv585 = v349 & 1;\n\tv335 = v585 == 0;\n\tif (v335) goto L_017C;\n\tv591 = this.__ChunkBaseEntityIndices;\n\tv599 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v584);\n\tv628 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v584);\n\tv650 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v584);\n\tv696 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v584);\n\tv773 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v119 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v584);\n\tv604 = v773;\n\tv609 = *([v591 @ X8_v26 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v378;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::Execute(this, v609, v599, v628, v650, v696, &v604 @ stack_-B0_v5 (Unity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>));\n\tv378 = v378 + 1;\n\tgoto L_017C;\nL_01CA:\n\tv250 = v125 < 0x41;\n\tif (v250) goto L_0216;\n\tv652 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv340 = v125;\nL_FFFFFFFF:\n\tv721 = 0x40;\n\tgoto L_01DC;\nL_01D0:\n\tv345 = v652 >> 1;\n\tv721 = v721 + 1;\n\tv280 = v340 == v721;\nL_FFFFFFFF:\n\tv652 = v345;\n\tif (v280) goto L_0216;\nL_01DC:\n\tv727 = v652 & 1;\n\tv336 = v727 == 0;\n\tif (v336) goto L_01D0;\n\tv774 = this.__ChunkBaseEntityIndices;\n\tv782 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v721);\n\tv811 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v721);\n\tv822 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v721);\n\tv835 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v721);\n\tv849 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v119 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v721);\n\tv787 = v849;\n\tv792 = *([v774 @ X8_v42 (Unity.Collections.NativeArray`1<System.Int32>)+chunkIndexInQuery @ X2 (System.Int32)*4]) + v378;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::Execute(this, v792, v782, v811, v822, v835, &v787 @ stack_-B0_v8 (Unity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.SettledTag>));\n\tv378 = v378 + 1;\nL_FFFFFFFF:\n\tv340 = v125;\n\tgoto L_01D0;\nL_0216:\n\tv386 = *([A4731E0]);\n\tv397 = *([v386 @ X9_v3]) != *([v37 @ X8_v2]);\n\tif (v397) goto L_0231;\n\treturn;\nL_0231:\n\tv499 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_004A:\n\tv76 = this + 0x50;\n\tv77 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v76);\n\tv85 = this + 0x78;\n\tv86 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v85);\n\tv94 = this + 0xA0;\n\tv95 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v94);\nL_0094:\n\tv445 = v304;\n\tv449 = Unity.Entities.EnabledBitUtility::ShiftRight(&v445 @ stack_-90_v12 (Unity.Burst.Intrinsics.v128), v338);\n\tv500 = v449;\n\tv501 = v338;\n\tv503 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v449);\n\tv528 = Unity.Entities.EnabledBitUtility::ShiftRight(&v500 @ stack_-90_v13 (Unity.Burst.Intrinsics.v128), v503);\nL_00C7:\n\tv761 = this.__ChunkBaseEntityIndices;\n\tv766 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v760);\n\tv804 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v760);\n\tv816 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v760);\nL_011A:\n\tv480 = this.__ChunkBaseEntityIndices;\n\tv486 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v474);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v474);\n\tv539 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v474);\nL_0174:\n\tv251 = v125 < 1;\n\tif (v251) goto L_0216;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob::Execute");
			}

			[Token(Token = "0x600050B")]
			[Address(RVA = "0x3C8FCDC", Offset = "0x3C8FCDC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.WriteBackSettleJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x600050C")]
			[Address(RVA = "0x3C8FD30", Offset = "0x3C8FD30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600050D")]
			[Address(RVA = "0x3C8FD3C", Offset = "0x3C8FD3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600050E")]
			[Address(RVA = "0x3C8FD48", Offset = "0x3C8FD48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600050F")]
			[Address(RVA = "0x3C8FD54", Offset = "0x3C8FD54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000510")]
			[Address(RVA = "0x3C8FD60", Offset = "0x3C8FD60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000511")]
			[Address(RVA = "0x3C8FD6C", Offset = "0x3C8FD6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000512")]
			[Address(RVA = "0x3C8FD78", Offset = "0x3C8FD78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000513")]
			[Address(RVA = "0x3C8FD84", Offset = "0x3C8FD84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000514")]
			[Address(RVA = "0x3C8FD90", Offset = "0x3C8FD90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000515")]
			[Address(RVA = "0x3C8FD9C", Offset = "0x3C8FD9C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000516")]
			[Address(RVA = "0x3C8FDA8", Offset = "0x3C8FDA8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000517")]
			[Address(RVA = "0x3C8FDB4", Offset = "0x3C8FDB4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000518")]
			[Address(RVA = "0x3C8FDC0", Offset = "0x3C8FDC0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000519")]
			[Address(RVA = "0x3C8FDCC", Offset = "0x3C8FDCC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600051A")]
			[Address(RVA = "0x3C8FDD8", Offset = "0x3C8FDD8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600051B")]
			[Address(RVA = "0x3C8FDE4", Offset = "0x3C8FDE4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600051C")]
			[Address(RVA = "0x3C8FDF0", Offset = "0x3C8FDF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600051D")]
			[Address(RVA = "0x3C8FDFC", Offset = "0x3C8FDFC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600051E")]
			[Address(RVA = "0x3C8FE08", Offset = "0x3C8FE08", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600051F")]
			[Address(RVA = "0x3C8FE14", Offset = "0x3C8FE14", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000520")]
			[Address(RVA = "0x3C8FE20", Offset = "0x3C8FE20", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000521")]
			[Address(RVA = "0x3C8FE2C", Offset = "0x3C8FE2C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000522")]
			[Address(RVA = "0x3C8FE38", Offset = "0x3C8FE38", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000F7")]
		private struct SettleJob : IJobParallelFor
		{
			[ReadOnly]
			[Token(Token = "0x4000322")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> positions;

			[ReadOnly]
			[Token(Token = "0x4000323")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float> speeds;

			[ReadOnly]
			[Token(Token = "0x4000324")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<bool> settledIn;

			[ReadOnly]
			[Token(Token = "0x4000325")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<bool> exitedIn;

			[ReadOnly]
			[Token(Token = "0x4000326")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public NativeArray<int> countersIn;

			[ReadOnly]
			[Token(Token = "0x4000327")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public NativeArray<float2> anchorsIn;

			[ReadOnly]
			[Token(Token = "0x4000328")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public NativeArray<int> isolatedFramesIn;

			[ReadOnly]
			[Token(Token = "0x4000329")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			public NativeParallelMultiHashMap<int2, int> grid;

			[Token(Token = "0x400032A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			public float cellSize;

			[Token(Token = "0x400032B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x84")]
			public float threshold;

			[Token(Token = "0x400032C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
			public int requiredFrames;

			[Token(Token = "0x400032D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8C")]
			public int settleDecayRate;

			[Token(Token = "0x400032E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x90")]
			public float wakeUpRadiusSq;

			[Token(Token = "0x400032F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x94")]
			public int wakeUpCellRadius;

			[Token(Token = "0x4000330")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x98")]
			public float positionSettleThresholdSq;

			[Token(Token = "0x4000331")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x9C")]
			public int isolatedSettleFrameThreshold;

			[Token(Token = "0x4000332")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
			public float isolatedRadiusSq;

			[Token(Token = "0x4000333")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xA4")]
			public int isolatedCellRadius;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000334")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xA8")]
			public NativeArray<bool> settledOut;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000335")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB8")]
			public NativeArray<int> countersOut;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000336")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
			public NativeArray<float2> anchorsOut;

			[NativeDisableParallelForRestriction]
			[Token(Token = "0x4000337")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xD8")]
			public NativeArray<int> isolatedFramesOut;

			[Token(Token = "0x600052E")]
			[Address(RVA = "0x3DA4CFC", Offset = "0x3DA4CFC", Length = "0x2B8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.exitedIn;\n\tv30 = *([v18 @ X8_v1 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) != 1;\n\tif (v30) goto L_0030;\n\tv31 = this.settledIn;\n\tv33 = this.settledOut;\n\t*([v33 @ X9_v23 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = *([v31 @ X8_v32 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]);\n\tv34 = this.countersIn;\n\tv36 = this.countersOut;\n\t*([v36 @ X9_v24 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = *([v34 @ X8_v34 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]);\n\tv37 = this.anchorsIn;\n\tv39 = this.anchorsOut;\n\t*([v39 @ X9_v25 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v37 @ X8_v36 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv40 = this.isolatedFramesIn;\n\tv103 = *([v40 @ X8_v38 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]);\nL_0030:\n\tv42 = this.settledIn;\n\tv44 = this.countersIn;\n\tv46 = this.anchorsIn;\n\tv179 = *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv57 = *([v42 @ X8_v4 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) != 1;\n\tif (v57) goto L_0059;\n\tv114 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+SettleJob::HasNearbyFastParticle(this, i);\n\tv249 = this.settledOut;\n\tv172 = ~v114;\n\tif (v172) goto L_0092;\n\t*([v249 @ X8_v15 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 0;\n\tv262 = this.countersOut;\n\t*([v262 @ X8_v28 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = 0;\n\tv263 = this.positions;\n\tv187 = this.anchorsOut;\n\t*([v187 @ X9_v22 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v263 @ X8_v29 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv226 = this.isolatedFramesOut;\n\t*([v226 @ X8_v31 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = 0;\n\treturn;\nL_0059:\n\tv116 = this.isolatedFramesOut;\n\t*([v116 @ X8_v6 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = 0;\n\tv119 = this.positions;\n\tv121 = this.speeds;\n\tv127 = *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) < 0x7149F2CA;\n\tv128 = *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) == 0x7149F2CA;\n\tv131 = *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) == *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv134 = ~v131;\n\tv135 = v127 == v134;\n\tv136 = ~v135;\n\tv137 = v136 | v128;\n\tv138 = ~v137;\n\tif (v138) goto L_FFFFFFFF;\n\tv272 = v118 < 0x7149F2CA;\n\tv271 = v118 == 0x7149F2CA;\n\tv254 = v118 == v118;\n\tv269 = ~v254;\n\tgoto L_007F;\nL_FFFFFFFF:\n\tv269 = 0;\nL_FFFFFFFF:\n\tv271 = 0;\nL_FFFFFFFF:\n\tv272 = 0;\n\tv279 = *([v121 @ X9_v5 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) < this.threshold;\n\tv288 = ~v279;\n\tif (v288) goto L_00BD;\nL_FFFFFFFF:\n\tv179 = *([v119 @ X8_v7 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\nL_FFFFFFFF:\n\tv333 = 1;\n\tgoto L_00DF;\nL_0092:\n\t*([v249 @ X8_v15 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 1;\n\tv266 = this.countersOut;\n\t*([v266 @ X8_v16 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = *([v44 @ X9_v3 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]);\n\tv267 = this.anchorsOut;\n\t*([v267 @ X8_v17 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v46 @ X9_v4 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv67 = _game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+SettleJob::HasNearbyActiveParticle(this, i);\n\tv63 = v67 == 0;\n\tif (v63) goto L_00F9;\nL_FFFFFFFF:\n\tv103 = 0;\n\tgoto L_0107;\nL_00A0:\n\tv289 = *([v119 @ X8_v7 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) - v179;\n\tv290 = v289 * v289;\n\t// 162 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv292 = v290 < this.positionSettleThresholdSq;\n\tv301 = ~v292;\n\tif (v301) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv333 = 2;\n\tgoto L_00B3;\nL_FFFFFFFF:\n\tv333 = 1;\nL_00BD:\n\tv324 = *([v44 @ X9_v3 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) - this.settleDecayRate;\n\tv173 = ~v324;\n\tv188 = v324 & v173;\n\tv325 = this.settledOut;\n\t*([v325 @ X10_v3 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 0;\n\tv145 = this.countersOut;\n\t*([v145 @ X10_v4 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = v188;\n\t// 208 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv227 = this.anchorsOut;\n\t// 210 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 211 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 212 NotImplemented \"Instruction BIF not yet implemented.\"\n\t*([v227 @ X8_v14 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v119 @ X8_v7 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\treturn;\nL_00DF:\n\tv189 = v333 + *([v44 @ X9_v3 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]);\n\tv146 = this.settledOut;\n\tv194 = v189 >= this.requiredFrames;\n\tif (v194) goto L_0129;\n\t*([v146 @ X10_v1 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 0;\n\tv346 = this.countersOut;\n\t*([v346 @ X8_v9 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = v189;\n\tv228 = this.anchorsOut;\n\t*([v228 @ X8_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = v179;\n\treturn;\nL_00F9:\n\tv303 = this.isolatedFramesIn;\n\tv103 = *([v303 @ X8_v24 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) + 1;\n\tv77 = v103 < this.isolatedSettleFrameThreshold;\n\tif (v77) goto L_0026;\n\tv347 = this.settledOut;\n\t*([v347 @ X8_v19 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 0;\n\tv348 = this.countersOut;\n\t*([v348 @ X8_v20 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = 0;\n\tv349 = this.positions;\n\tv351 = this.anchorsOut;\n\t*([v351 @ X9_v20 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v349 @ X8_v21 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv229 = this.isolatedFramesOut;\n\t*([v229 @ X8_v23 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = -1;\n\treturn;\nL_0129:\n\t*([v146 @ X10_v1 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) = 1;\n\tv147 = this.countersOut;\n\t*([v147 @ X10_v2 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = v189;\n\tv191 = this.anchorsOut;\n\t*([v191 @ X9_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) = *([v119 @ X8_v7 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\treturn;\nL_007F:\n\tv275 = v272 == v269;\n\tv276 = ~v275;\n\tv277 = v276 | v271;\n\tif (v277) goto L_00A0;\nL_0107:\n\tv78 = this.isolatedSettleFrameThreshold < 1;\n\tif (v78) goto L_0026;\nL_00B3:\n\tv318 = *([v121 @ X9_v5 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]) < this.threshold;\n\tif (v318) goto L_00DF;\nL_0026:\n\tv105 = this.isolatedFramesOut;\n\t*([v105 @ X9_v2 (Unity.Collections.NativeArray`1<System.Int32>)+i @ X1 (System.Int32)*4]) = v103;\n\treturn;\n")]
			public void Execute(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.SettleJob::Execute");
			}

			[Token(Token = "0x600052F")]
			[Address(RVA = "0x3DA4FB4", Offset = "0x3DA4FB4", Length = "0x264")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_003A:\n\tv115 = UnityEngine.Mathf::Floor(v86);\n\tv113 = v92 / this.cellSize;\n\tgoto L_004A;\nL_004B:\n\tv218 = this.wakeUpCellRadius;\n\tv294 = 0 - this.wakeUpCellRadius;\n\tv138 = this.wakeUpCellRadius < v294;\n\tif (v138) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_011F;\nL_0075:\n\tv236 = UnityEngine.Mathf::Floor(v113);\n\tv310 = v113 << 0x20;\n\tv314 = v236 == 0x7F800000;\n\tv321 = ~v314;\n\tif (v321) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv167 = 0x8000000000000000;\n\tgoto L_008B;\nL_FFFFFFFF:\n\tv167 = v310;\nL_FFFFFFFF:\n\tv165 = 0xFFFFFFFF80000000;\n\tgoto L_009E;\nL_FFFFFFFF:\n\tv165 = v115;\nL_009F:\n\tv294 = v294 + 1;\n\tv181 = v294 > v218;\n\tif (v181) goto L_FFFFFFFF;\nL_00AD:\n\tv254 = 0 - v218;\n\tv372 = v218 < v254;\n\tif (v372) goto L_009F;\n\tv252 = v294 + v165;\n\tgoto L_00CB;\nL_00BC:\n\tv254 = v254 + 1;\n\tv218 = this.wakeUpCellRadius;\n\tv382 = v254 > this.wakeUpCellRadius;\n\tif (v382) goto L_009F;\nL_00CB:\n\tv250 = v254 << 0x20;\n\tv427 = v167 + v250;\n\tv429 = v427 | v252;\n\tv433 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetFirstValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v429, &v431 @ stack_-74_v5 (System.Int32), &v60 @ stack_-88_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv434 = ~v433;\n\tv435 = ~v434;\n\tif (v435) goto L_00E4;\n\tgoto L_00BC;\nL_00D8:\n\t;\n\tv463 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetNextValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), &v431 @ stack_-74_v5 (System.Int32), &v60 @ stack_-88_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv465 = v463 == 0;\n\tif (v465) goto L_00BC;\nL_00E4:\n\tv471 = v431 == i;\n\tif (v471) goto L_00D8;\n\tv486 = this.settledIn;\n\tv488 = *([v486 @ X9_v9 (Unity.Collections.NativeArray`1<System.Boolean>)+v431 @ stack_-74_v5 (System.Int32)]) & 1;\n\tv489 = v488 == 0;\n\tv290 = ~v489;\n\tif (v290) goto L_00D8;\n\tv490 = this.speeds;\n\tv498 = this.threshold * 5f;\n\tv494 = *([v490 @ X9_v11 (Unity.Collections.NativeArray`1<System.Single>)+v431 @ stack_-74_v5 (System.Int32)*4]) < v498;\n\tif (v494) goto L_00D8;\n\tv263 = this.positions;\n\tv507 = *([v263 @ X9_v12 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v431 @ stack_-74_v5 (System.Int32)*8]) - *([v62 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv283 = v507 * v507;\n\t// 258 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv275 = v283 == this.wakeUpRadiusSq;\n\tv508 = v283 < this.wakeUpRadiusSq;\n\tv281 = ~v508;\n\tv510 = ~v275;\n\tv265 = v281 & v510;\n\tif (v265) goto L_00D8;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0020:\n\tv60 = 0;\n\tv62 = this.positions;\n\tgoto L_0037;\nL_004A:\n\tgoto L_004B;\nL_011F:\n\treturn returnVal1;\nL_008B:\n\tv325 = v115 == 0x7F800000;\n\tv170 = ~v325;\n\tif (v170) goto L_FFFFFFFF;\nL_009E:\n\tgoto L_00AD;\nL_0037:\n\tv86 = *([v62 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) / this.cellSize;\n\tgoto L_003A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool HasNearbyFastParticle(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.SettleJob::HasNearbyFastParticle");
				return default;
			}

			[Token(Token = "0x6000530")]
			[Address(RVA = "0x3DA5218", Offset = "0x3DA5218", Length = "0x248")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_003A:\n\tv115 = UnityEngine.Mathf::Floor(v86);\n\tv113 = v92 / this.cellSize;\n\tgoto L_004A;\nL_004B:\n\tv216 = this.isolatedCellRadius;\n\tv291 = 0 - this.isolatedCellRadius;\n\tv138 = this.isolatedCellRadius < v291;\n\tif (v138) goto L_FFFFFFFF;\n\tgoto L_0075;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0111;\nL_0075:\n\tv234 = UnityEngine.Mathf::Floor(v113);\n\tv307 = v113 << 0x20;\n\tv311 = v234 == 0x7F800000;\n\tv318 = ~v311;\n\tif (v318) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv167 = 0x8000000000000000;\n\tgoto L_008B;\nL_FFFFFFFF:\n\tv167 = v307;\nL_FFFFFFFF:\n\tv165 = 0xFFFFFFFF80000000;\n\tgoto L_009D;\nL_FFFFFFFF:\n\tv165 = v115;\nL_009E:\n\tv291 = v291 + 1;\n\tv181 = v291 > v216;\n\tif (v181) goto L_FFFFFFFF;\nL_00AC:\n\tv252 = 0 - v216;\n\tv369 = v216 < v252;\n\tif (v369) goto L_009E;\n\tv250 = v291 + v165;\n\tgoto L_00CA;\nL_00BB:\n\tv252 = v252 + 1;\n\tv216 = this.isolatedCellRadius;\n\tv379 = v252 > this.isolatedCellRadius;\n\tif (v379) goto L_009E;\nL_00CA:\n\tv248 = v252 << 0x20;\n\tv424 = v167 + v248;\n\tv426 = v424 | v250;\n\tv430 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetFirstValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v426, &v428 @ stack_-74_v5 (System.Int32), &v60 @ stack_-88_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv431 = ~v430;\n\tv432 = ~v431;\n\tif (v432) goto L_00E3;\n\tgoto L_00BB;\nL_00D7:\n\t;\n\tv460 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetNextValue(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), &v428 @ stack_-74_v5 (System.Int32), &v60 @ stack_-88_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv462 = v460 == 0;\n\tif (v462) goto L_00BB;\nL_00E3:\n\tv468 = v428 == i;\n\tif (v468) goto L_00D7;\n\tv483 = this.settledIn;\n\tv485 = *([v483 @ X9_v9 (Unity.Collections.NativeArray`1<System.Boolean>)+v428 @ stack_-74_v5 (System.Int32)]) & 1;\n\tv486 = v485 == 0;\n\tv287 = ~v486;\n\tif (v287) goto L_00D7;\n\tv261 = this.positions;\n\tv491 = *([v261 @ X9_v11 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v428 @ stack_-74_v5 (System.Int32)*8]) - *([v62 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv281 = v491 * v491;\n\t// 244 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv273 = v281 == this.isolatedRadiusSq;\n\tv492 = v281 < this.isolatedRadiusSq;\n\tv279 = ~v492;\n\tv494 = ~v273;\n\tv263 = v279 & v494;\n\tif (v263) goto L_00D7;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_0020:\n\tv60 = 0;\n\tv62 = this.positions;\n\tgoto L_0037;\nL_004A:\n\tgoto L_004B;\nL_0111:\n\treturn returnVal1;\nL_008B:\n\tv322 = v115 == 0x7F800000;\n\tv170 = ~v322;\n\tif (v170) goto L_FFFFFFFF;\nL_009D:\n\tgoto L_00AC;\nL_0037:\n\tv86 = *([v62 @ X8_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) / this.cellSize;\n\tgoto L_003A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool HasNearbyActiveParticle(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.SettleJob::HasNearbyActiveParticle");
				return default;
			}
		}

		[Token(Token = "0x20000F8")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000338")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public GatherSettleDataJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_GatherSettleDataJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x4000339")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
			public WriteBackSettleJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_WriteBackSettleJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6000531")]
			[Address(RVA = "0x3DA5460", Offset = "0x3DA5460", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData::Init(this, state, 1);\n\tv16 = this + 0xB0;\n\tv19 = 0x3DA44B8(v16, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv32 = this + 0xB0;\n\tv39 = 0x3DA4670(v32, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public unsafe void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x40002FF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private int _tickCounter;

		[Token(Token = "0x4000300")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x4000301")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x190")]
		private EntityQuery __query_1868265852_0;

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0x3C8D878", Offset = "0x3C8D878", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\tthis._tickCounter = 0;\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
			_tickCounter = 0;
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0x3C8D8D8", Offset = "0x3C8D8D8", Length = "0x6F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tgoto L_0069;\nL_0069:\n\tv447 = UnityEngine.Object::op_Equality(v125.Config, 0);\n\tv453 = v447 == 0;\n\tif (v453) goto L_0077;\n\tgoto L_0280;\nL_0077:\n\tv463 = v125.Buffers;\n\tv455 = v125.Buffers == 0;\n\tif (v455) goto L_0280;\n\tv431 = v125.Config;\n\tv683 = v431.SettleUpdateInterval;\n\tv424 = v431.SettleUpdateInterval - 1;\n\tv420 = v424 < 0;\n\tv416 = v424 == 0;\n\tv412 = v431.SettleUpdateInterval ^ 1;\n\tv407 = v431.SettleUpdateInterval ^ v424;\n\tv404 = v412 & v407;\n\tv402 = v404 < 0;\n\tv659 = v420 == v402;\n\tv394 = ~v416;\n\tv397 = v659 & v394;\n\tv392 = ~v397;\n\tif (v392) goto L_FFFFFFFF;\n\tgoto L_0091;\nL_FFFFFFFF:\n\tv683 = 1;\n\tv373 = this.__query_1868265852_0;\n\tv450 = Unity.Entities.EntityQuery::CalculateEntityCount(&v373 @ stack_-E0_v4 (Unity.Entities.EntityQuery));\n\tv456 = v450 == 0;\n\tif (v456) goto L_0280;\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::EnsureCapacity(v125.Buffers, v450);\n\tgoto L_00BC;\nL_00C1:\n\tv667 = UnityEngine.Mathf::Ceil(v661);\n\tv671 = v667 == 0x7F800000;\n\tv668 = ~v671;\n\tif (v668) goto L_00D4;\n\tgoto L_00D4;\nL_00DE:\n\tv678 = UnityEngine.Object::op_Inequality(v125.Conveyor, 0);\n\tv724 = ~v678;\n\tif (v724) goto L_011E;\n\tv736 = *([v660 @ X23_v5 (UnityEngine.Object)+188]) & 1;\n\tv726 = v736 == 0;\n\tif (v726) goto L_011E;\n\tv770 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMin(v125.Conveyor);\n\tv795 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMax(v125.Conveyor);\n\tgoto L_011E;\n\tv805 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v787 @ stack_-C0_v2 (Unity.Entities.EntityQuery), v797, v766, &v801 @ stack_-D0_v3 (Unity.Jobs.JobHandle));\n\tv812 = this + 8;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v812, state);\n\tgoto L_0178;\nL_01B0:\n\tv899 = UnityEngine.Mathf::Ceil(v369);\n\tv414 = v899 == 0x7F800000;\n\tv390 = ~v414;\n\tif (v390) goto L_01D1;\n\tgoto L_01D1;\n\tv967 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v787 @ stack_-C0_v2 (Unity.Entities.EntityQuery), v960, v946, &v801 @ stack_-D0_v3 (Unity.Jobs.JobHandle));\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v465, state);\n\tgoto L_0246;\nL_0280:\n\treturn;\nL_002B:\n\tv376.__seqno = 0;\n\tgoto L_005C;\nL_0091:\n\tv363 = this._tickCounter + 1;\n\tthis._tickCounter = v363;\n\tv252 = v363 / v683;\n\tv685 = v252 * v683;\n\tv457 = v363 != v685;\n\tif (v457) goto L_0280;\nL_00BC:\n\tv661 = v431.IsolatedSettleRadius / v125.<Params>k__BackingField.SpatialHashCellSize;\n\tgoto L_00C1;\nL_00D4:\n\tv660 = v125.Conveyor;\n\tgoto L_00DE;\nL_011E:\n\tv762 = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_GatherSettleDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery;\n\tv766 = Unity.Entities.SystemState::get_Dependency(state);\n\tv781 = v463.Positions;\n\tv787 = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_GatherSettleDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery;\n\tv762.__seqno = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_GatherSettleDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery.__seqno;\n\tv793 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv797 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v793);\nL_0178:\n\tv857 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(&v781 @ stack_-400_v2 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_GatherSettleDataJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v801, v805);\n\tv866 = _game.CoreSystem.SandPhysics.SandPhysicsBuffers::BuildSpatialHash(v125.Buffers, v450, v125.<Params>k__BackingField.SpatialHashCellSize, v857, v463.Positions, v463.ExitedIn);\n\tgoto L_01A3;\nL_01A3:\n\tv889 = &v781 @ stack_-400_v2 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob);\n\tv369 = v431.WakeUpRadius / v125.<Params>k__BackingField.SpatialHashCellSize;\n\tgoto L_01B0;\nL_01D1:\n\tv923 = v463.Positions;\n\t*([v889 @ X26_v8+A8]) = v463.SettledOut;\n\t*([v889 @ X26_v8+B8]) = v463.CountersOut;\n\t*([v889 @ X26_v8+C8]) = v463.AnchorsOut;\n\t*([v889 @ X26_v8+D8]) = v463.IsolatedFramesOut;\n\tv387 = &v923 @ stack_-400_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>);\n\tv946 = Unity.Jobs.IJobParallelForExtensions::Schedule(&v923 @ stack_-400_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v450, 0x40, v866);\n\tv327 = v463.SettledOut;\n\tv465 = this + 0xB8;\n\tv787 = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_WriteBackSettleJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery;\n\tv762.__seqno = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_WriteBackSettleJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery.__seqno;\n\tv958 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv960 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v958);\nL_0246:\n\t*([v387 @ X25_v8+F0]) = v465.___game_CoreSystem_SandPhysics_Components_SettledTag_RW_ComponentTypeHandle;\n\t*([v387 @ X25_v8+100]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+B0]);\n\t*([v387 @ X25_v8+110]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+C0]);\n\t*([v387 @ X25_v8+B0]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]);\n\t*([v387 @ X25_v8+C0]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]);\n\t*([v387 @ X25_v8+D0]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+80]);\n\t*([v387 @ X25_v8+E0]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+90]);\n\t*([v387 @ X25_v8+70]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]);\n\t*([v387 @ X25_v8+80]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+30]);\n\t*([v387 @ X25_v8+90]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+40]);\n\t*([v387 @ X25_v8+A0]) = v465.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;\n\t*([v387 @ X25_v8+50]) = v465.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;\n\t*([v387 @ X25_v8+60]) = *([v465 @ X20_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]);\n\tv993 = Unity.Entities.JobChunkExtensions::ScheduleByRef(&v327 @ stack_-400_v4 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SettleDetectionSystem_WriteBackSettleJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v801);\n\tv200 = v993;\n\tUnity.Jobs.JobHandle::Complete(&v200 @ stack_-2D0_v3 (Unity.Jobs.JobHandle));\nL_005C:\n\tv125 = v124.<Current>k__BackingField;\n\tv126 = v124.<Current>k__BackingField == 0;\n\tif (v126) goto L_0280;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004DD")]
		[Address(RVA = "0x3C8DFC8", Offset = "0x3C8DFC8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = query;\n\tquery.__seqno = query.__seqno;\n\tv42 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv44 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v42);\n\tv52 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v36 @ stack_-60_v1 (Unity.Entities.EntityQuery), v44, dependency, &v48 @ stack_-70_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v52;\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob)+118]) = v44;\n\tv55 = this + 8;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+GatherSettleDataJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v55, state);\n\tgoto L_0039;\nL_0039:\n\tv79 = job + 0x70;\n\tv80 = this + 8;\n\tv82 = 0x8BF6A34(v79, v80, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.Internal.InternalCompilerInterface+JobChunkInterface::ScheduleParallelByRef(job, query, v48, job.__ChunkBaseEntityIndices);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(GatherSettleDataJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004DE")]
		[Address(RVA = "0x3C8E198", Offset = "0x3C8E198", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = query;\n\tquery.__seqno = query.__seqno;\n\tv42 = Unity.Entities.SystemState::get_WorldUpdateAllocator(state);\n\tv44 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(v42);\n\tv52 = Unity.Entities.EntityQuery::CalculateBaseEntityIndexArrayAsync(&v36 @ stack_-60_v1 (Unity.Entities.EntityQuery), v44, dependency, &v48 @ stack_-70_v2 (Unity.Jobs.JobHandle));\n\tjob.__ChunkBaseEntityIndices = v52;\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob)+120]) = v44;\n\tv55 = this + 0xB8;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v55, state);\n\tgoto L_003A;\nL_003A:\n\tv80 = job + 0x50;\n\tv81 = this + 0xB8;\n\tv83 = 0x8BF6A34(v80, v81, 0xC8, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, v48);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_1(WriteBackSettleJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem::__ScheduleViaJobChunkExtension_1");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004DF")]
		[Address(RVA = "0x3C8E290", Offset = "0x3C8E290", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_1868265852_0 = v61;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem)+198]) = state;\n\tv64 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SandParticle, ParticlePosition, ParticleVelocity, ParticleState, ParticleSettleCounter>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQuery _query_1868265852_ = entityQueryBuilder3.Build(ref state);
			__query_1868265852_0 = _query_1868265852_;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0x3C8E344", Offset = "0x3C8E344", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_1868265852_0 = v61;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem)+198]) = state;\n\tv64 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tv67 = this + 8;\n\tv70 = 0x3C8EDA0(v67, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv71 = this + 8;\n\tv74 = 0x3C8EF2C(v71, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv75 = this + 0xB8;\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem+WriteBackSettleJob+InternalCompilerQueryAndHandleData::Init(v75, state, 1);\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004E1")]
		[Address(RVA = "0x3C8D810", Offset = "0x3C8D810", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\tself.m_value = 0;\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SettleDetectionSystem::__codegen__OnCreate");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004E2")]
		[Address(RVA = "0x3C8D870", Offset = "0x3C8D870", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((SettleDetectionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004E3")]
		[Address(RVA = "0x3C8D874", Offset = "0x3C8D874", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SettleDetectionSystem::OnCreateForCompiler(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			((SettleDetectionSystem*)self)->OnCreateForCompiler(ref *(SystemState*)state);
		}
	}
}
