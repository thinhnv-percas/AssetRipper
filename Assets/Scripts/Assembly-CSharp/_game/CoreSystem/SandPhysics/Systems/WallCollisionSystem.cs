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
using _game.CoreSystem.CollisionSystem;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.SDF;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(ParticleCollisionSystem))]
	[Token(Token = "0x20000FF")]
	public struct WallCollisionSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x2000100")]
		private struct WallCollisionJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x2000101")]
			private struct VisitedBitset
			{
				[Token(Token = "0x4000355")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				private long w0;

				[Token(Token = "0x4000356")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				private long w1;

				[Token(Token = "0x4000357")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
				private long w2;

				[Token(Token = "0x4000358")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
				private long w3;

				[Token(Token = "0x4000359")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
				private long w4;

				[Token(Token = "0x400035A")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				private long w5;

				[Token(Token = "0x400035B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
				private long w6;

				[Token(Token = "0x400035C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
				private long w7;

				[Token(Token = "0x6000586")]
				[Address(RVA = "0x3DA7354", Offset = "0x3DA7354", Length = "0xD0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 1 << idx;\n\tv3 = idx >> 6;\n\tv4 = v3 & 7;\n\tv16 = v4 > 3;\n\tif (v16) goto L_0035;\n\tv28 = v4 > 1;\n\tif (v28) goto L_0055;\n\tv41 = v4 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0076;\n\tv151 = this.w0;\n\tv75 = this.w0 & v1;\n\tv77 = v75 == 0;\n\tv80 = ~v77;\n\tif (v80) goto L_0093;\n\tv150 = this;\n\tgoto L_009D;\nL_0035:\n\tv40 = v4 > 5;\n\tif (v40) goto L_006A;\n\tv62 = v4 != 4;\n\tif (v62) goto L_0080;\n\tv150 = this + 0x20;\n\tv151 = this.w4;\n\tv106 = this.w4 & v1;\n\tv108 = v106 == 0;\n\tv111 = ~v108;\n\tif (v111) goto L_0093;\n\tgoto L_009D;\nL_0055:\n\tv52 = v4 != 2;\n\tif (v52) goto L_008A;\n\tv150 = this + 0x10;\n\tv151 = this.w2;\n\tv91 = this.w2 & v1;\n\tv93 = v91 == 0;\n\tv96 = ~v93;\n\tif (v96) goto L_0093;\n\tgoto L_009D;\nL_006A:\n\tv72 = v4 != 6;\n\tif (v72) goto L_0094;\n\tv150 = this + 0x30;\n\tv151 = this.w6;\n\tv122 = this.w6 & v1;\n\tv124 = v122 == 0;\n\tv127 = ~v124;\n\tif (v127) goto L_0093;\n\tgoto L_009D;\nL_0076:\n\tv150 = this + 8;\n\tv151 = this.w1;\n\tv83 = this.w1 & v1;\n\tv85 = v83 == 0;\n\tv88 = ~v85;\n\tif (v88) goto L_0093;\n\tgoto L_009D;\nL_0080:\n\tv150 = this + 0x28;\n\tv151 = this.w5;\n\tv114 = this.w5 & v1;\n\tv116 = v114 == 0;\n\tv119 = ~v116;\n\tif (v119) goto L_0093;\n\tgoto L_009D;\nL_008A:\n\tv150 = this + 0x18;\n\tv151 = this.w3;\n\tv99 = this.w3 & v1;\n\tv101 = v99 == 0;\n\tif (v101) goto L_009D;\nL_0093:\n\treturn 1;\nL_0094:\n\tv150 = this + 0x38;\n\tv151 = this.w7;\n\tv130 = this.w7 & v1;\n\tv132 = v130 == 0;\n\tv135 = ~v132;\n\tif (v135) goto L_0093;\nL_009D:\n\tv163 = v151 | v1;\n\tv150.w0 = v163;\n\treturn 0;\n")]
				public unsafe bool TestAndSet(int idx)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.VisitedBitset::TestAndSet");
					return default;
				}
			}

			[Token(Token = "0x2000102")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x2000103")]
				public struct TypeHandle
				{
					[Token(Token = "0x400035F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x4000360")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x4000361")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleRadius> ___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x4000362")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x600058F")]
					[Address(RVA = "0x3DA8918", Offset = "0x3DA8918", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000590")]
					[Address(RVA = "0x3DA693C", Offset = "0x3DA693C", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleRadius_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleRadius>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400035D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x400035E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000587")]
				[Address(RVA = "0x3DA8330", Offset = "0x3DA8330", Length = "0x2A8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = v78;\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v86;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v93;\n\tv98 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v98;\n\tv103 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v103;\n\tv109 = Unity.Entities.EntityQueryBuilder::Build(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v109;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv112 = Unity.Entities.EntityQueryBuilder::Reset(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002F:\n\tv62 = 0;\n\tv66 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v66);\n\tv78 = Unity.Entities.EntityQueryBuilder::WithAll(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticleRadius>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000588")]
				[Address(RVA = "0x3DA85D8", Offset = "0x3DA85D8", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3DA8484(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000589")]
				[Address(RVA = "0x3DA8754", Offset = "0x3DA8754", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x88;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref WallCollisionJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600058A")]
				[Address(RVA = "0x3DA87D4", Offset = "0x3DA87D4", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x88;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref WallCollisionJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600058B")]
				[Address(RVA = "0x3DA886C", Offset = "0x3DA886C", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x88;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref WallCollisionJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600058C")]
				[Address(RVA = "0x3DA8904", Offset = "0x3DA8904", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref WallCollisionJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600058D")]
				[Address(RVA = "0x3DA8908", Offset = "0x3DA8908", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref WallCollisionJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600058E")]
				[Address(RVA = "0x3DA8914", Offset = "0x3DA8914", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref WallCollisionJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x2000104")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000591")]
				[Address(RVA = "0x3DA8A5C", Offset = "0x3DA8A5C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			[Token(Token = "0x4000342")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> vertices;

			[ReadOnly]
			[Token(Token = "0x4000343")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<CollisionShape> shapes;

			[ReadOnly]
			[Token(Token = "0x4000344")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<float4> shapeAabbs;

			[ReadOnly]
			[Token(Token = "0x4000345")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeParallelMultiHashMap<int2, int> shapeSpatialGrid;

			[Token(Token = "0x4000346")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public float spatialGridCellSize;

			[Token(Token = "0x4000347")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
			public int shapeCount;

			[Token(Token = "0x4000348")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public int wallShapeCount;

			[Token(Token = "0x4000349")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
			public float restitution;

			[Token(Token = "0x400034A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public float friction;

			[Token(Token = "0x400034B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
			public float settleVelocityThreshold;

			[Token(Token = "0x400034C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			public float maxSpeed;

			[Token(Token = "0x400034D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x5C")]
			public float twoSidedCatchRadii;

			[ReadOnly]
			[Token(Token = "0x400034E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public NativeArray<half> sdfValues;

			[Token(Token = "0x400034F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
			public float2 sdfOrigin;

			[Token(Token = "0x4000350")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
			public float sdfCellSize;

			[Token(Token = "0x4000351")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x7C")]
			public int sdfGridWidth;

			[Token(Token = "0x4000352")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			public int sdfGridHeight;

			[Token(Token = "0x4000353")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x84")]
			public float maxRadiiPerStep;

			[Token(Token = "0x4000354")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x6000568")]
			[Address(RVA = "0x3DA6ACC", Offset = "0x3DA6ACC", Length = "0x4E4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::ResolveWallsViaSDF(this, pos, vel, radius);\n\tv220 = this.shapeCount == this.wallShapeCount;\n\tif (v220) goto L_014D;\n\tv197 = 0;\n\tv194 = v286.zero;\n\tv290 = UnityEngine.Mathf::Max(this.twoSidedCatchRadii, 1f);\n\t// 82 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv296 = 1f / this.spatialGridCellSize;\n\tgoto L_0068;\nL_0070:\n\tv321 = UnityEngine.Mathf::Floor(v316);\n\tv327 = v321 == 0x7F800000;\n\tv335 = ~v327;\n\tif (v335) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv353 = 0xFFFFFFFF80000000;\n\tgoto L_0084;\nL_FFFFFFFF:\n\tv353 = v316;\nL_0093:\n\tv406 = UnityEngine.Mathf::Floor(v385);\n\tv411 = v406 == 0x7F800000;\n\tv419 = ~v411;\n\tif (v419) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv263 = 0xFFFFFFFF80000000;\n\tgoto L_00A5;\nL_FFFFFFFF:\n\tv263 = v385;\nL_00E7:\n\tv157 = UnityEngine.Mathf::Floor(v459);\n\tv175 = v296 * v132;\n\tgoto L_00EF;\nL_00EF:\n\tv189 = UnityEngine.Mathf::Floor(v175);\n\tv498 = v189 == 0x7F800000;\n\tv505 = ~v498;\n\tif (v505) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv162 = 0xFFFFFFFF80000000;\n\tgoto L_010C;\nL_FFFFFFFF:\n\tv162 = v175;\nL_FFFFFFFF:\n\tv576 = 0xFFFFFFFF80000000;\n\tgoto L_011C;\nL_FFFFFFFF:\n\tv576 = v157;\n\tv541 = v353 - v263;\n\tv223 = v541 < 0;\n\tv219 = v541 == 0;\n\tv544 = v353 ^ v263;\n\tv545 = v353 ^ v541;\n\tv546 = v544 & v545;\n\tv200 = v546 < 0;\n\tgoto L_0138;\nL_FFFFFFFF:\n\tv200 = 0;\nL_FFFFFFFF:\n\tv219 = 0;\nL_FFFFFFFF:\n\tv223 = 0;\nL_014D:\n\treturn;\nL_FFFFFFFF:\n\tv558 = 0;\nL_FFFFFFFF:\n\tv559 = 0;\nL_FFFFFFFF:\n\tv560 = 0;\nL_FFFFFFFF:\n\tv561 = 0;\nL_FFFFFFFF:\n\tv566 = 0;\nL_FFFFFFFF:\n\tv567 = 0;\nL_FFFFFFFF:\n\tv568 = 0;\nL_FFFFFFFF:\n\tv569 = 0;\n\tgoto L_017B;\nL_016C:\n\tv576 = v576 + 1;\n\tv143 = v576 > v162;\n\tif (v143) goto L_014D;\nL_017B:\n\tv261 = v576 << 0x20;\nL_FFFFFFFF:\n\tv645 = v353;\n\tgoto L_018E;\nL_017E:\n\tv645 = v645 + 1;\n\tv617 = v645 > v263;\n\tif (v617) goto L_016C;\nL_018E:\n\t;\n\tv649 = v261 | v645;\n\tv653 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetFirstValue(&this.shapeSpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v649, &v651 @ stack_-E4_v5 (System.Int32), &v68 @ stack_-F8_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv654 = ~v653;\n\tv655 = ~v654;\n\tif (v655) goto L_01AF;\n\tgoto L_017E;\nL_0197:\n\tv952 = v795 | v752;\n\t*([v779 @ X11_v13]) = v952;\n\tv953 = this.shapeAabbs;\n\t// 412 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 413 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 414 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 415 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 417 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv955 = *([v953 @ X9_v13 (Unity.Collections.NativeArray`1<Unity.Mathematics.float4>)+v651 @ stack_-E4_v5 (System.Int32)*16]) & 1;\n\tv883 = v955 == 0;\n\tif (v883) goto L_023C;\nL_01A7:\n\t;\n\tv723 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::TryGetNextValue(&this.shapeSpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), &v651 @ stack_-E4_v5 (System.Int32), &v68 @ stack_-F8_v1 (Unity.Collections.NativeParallelMultiHashMapIterator`1<Unity.Mathematics.int2>));\n\tv725 = v723 == 0;\n\tif (v725) goto L_017E;\nL_01AF:\n\tv729 = v651 < 0x1FF;\n\tv730 = ~v729;\n\tv731 = v651 - 0x1FF;\n\tv733 = v731 == 0;\n\tv738 = ~v733;\n\tv739 = v730 & v738;\n\tif (v739) goto L_01A7;\n\tv752 = 1 << v651;\n\tv753 = v651 >> 6;\n\tv754 = v753 & 0x3FFFFFF;\n\tv766 = v754 > 3;\n\tif (v766) goto L_01F0;\n\tv902 = v754 > 1;\n\tif (v902) goto L_0210;\n\tv915 = v754 == 0;\n\tv916 = ~v915;\n\tif (v916) goto L_024D;\n\tv884 = 0 & v752;\n\tv836 = v884 == 0;\n\tv786 = ~v836;\n\tif (v786) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v569 @ stack_-A8_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_01F0:\n\tv913 = v754 > 5;\n\tif (v913) goto L_0225;\n\tv928 = v754 != 4;\n\tif (v928) goto L_0257;\n\tv885 = 0 & v752;\n\tv837 = v885 == 0;\n\tv787 = ~v837;\n\tif (v787) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v568 @ stack_-C8_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_0210:\n\tv922 = v754 != 2;\n\tif (v922) goto L_0261;\n\tv886 = 0 & v752;\n\tv838 = v886 == 0;\n\tv788 = ~v838;\n\tif (v788) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v567 @ stack_-B8_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_0225:\n\tv934 = v754 != 6;\n\tif (v934) goto L_026B;\n\tv887 = 0 & v752;\n\tv839 = v887 == 0;\n\tv789 = ~v839;\n\tif (v789) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v566 @ stack_-D8_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_023C:\n\tv790 = v651 < this.wallShapeCount;\n\tif (v790) goto L_01A7;\n\tv774 = v651 << 4;\n\tv892 = this.shapes + v774;\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::ResolveConvexPolygon(this, pos, vel, radius.value, *([v892 @ X8_v30]), &v197 @ stack_-8C_v2 (System.Int32), &v194 @ stack_-98_v2 (Unity.Mathematics.float2), &v958 @ stack_-99 (System.Boolean));\n\tgoto L_01A7;\nL_024D:\n\tv888 = 0 & v752;\n\tv841 = v888 == 0;\n\tv791 = ~v841;\n\tif (v791) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v561 @ stack_-B0_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_0257:\n\tv889 = 0 & v752;\n\tv842 = v889 == 0;\n\tv792 = ~v842;\n\tif (v792) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v560 @ stack_-D0_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_0261:\n\tv890 = 0 & v752;\n\tv843 = v890 == 0;\n\tv793 = ~v843;\n\tif (v793) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v559 @ stack_-C0_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_026B:\n\tv891 = 0 & v752;\n\tv844 = v891 == 0;\n\tv794 = ~v844;\n\tif (v794) goto L_01A7;\nL_FFFFFFFF:\n\tv779 = &v558 @ stack_-E0_v3 (System.Int32);\nL_FFFFFFFF:\n\tv795 = 0;\n\tgoto L_0197;\nL_0029:\n\tv68 = 0;\n\tv71 = state.flags & 7;\n\tv73 = v71 == 0;\n\tv76 = ~v73;\n\tif (v76) goto L_014D;\nL_0068:\n\tv183 = pos.value + v166;\n\tv316 = v296 * v317;\n\tgoto L_0070;\nL_0084:\n\tv385 = v296 * v183;\n\tgoto L_0091;\nL_00A5:\n\tgoto L_00E1;\nL_0091:\n\tgoto L_0093;\nL_010C:\n\tv517 = v157 == 0x7F800000;\n\tv524 = ~v517;\n\tif (v524) goto L_FFFFFFFF;\nL_011C:\n\tv529 = v576 - v162;\n\tv530 = v529 < 0;\n\tv531 = v529 == 0;\n\tv532 = v576 ^ v162;\n\tv533 = v576 ^ v529;\n\tv534 = v532 & v533;\n\tv535 = v534 < 0;\n\tv536 = v530 == v535;\n\tv537 = ~v536;\n\tv538 = v537 | v531;\n\tv159 = ~v538;\n\tif (v159) goto L_FFFFFFFF;\nL_0138:\n\tv552 = v223 == v200;\n\tv553 = ~v552;\n\tv142 = v553 | v219;\n\tif (v142) goto L_FFFFFFFF;\nL_00E1:\n\tv459 = v296 * v460;\n\tgoto L_00E7;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, in ParticleRadius radius, in ParticleState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::Execute");
			}

			[Token(Token = "0x6000569")]
			[Address(RVA = "0x3DA6FD4", Offset = "0x3DA6FD4", Length = "0x380")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv39 = pos.value - this.sdfOrigin;\n\tv40 = v39 / this.sdfCellSize;\n\tv42 = v40 + -0.5f;\n\tv43 = v42 < 0;\n\tv47 = v42 == v42;\n\tv48 = ~v47;\n\tv49 = v43 == v48;\n\tv50 = ~v49;\n\tif (v50) goto L_006B;\n\tv55 = pos.value.y - this.sdfOrigin.y;\n\tv56 = v55 / this.sdfCellSize;\n\tv57 = v56 + -0.5f;\n\tv58 = v57 < 0;\n\tv62 = v57 == v57;\n\tv63 = ~v62;\n\tv66 = this.sdfGridWidth + -1f;\n\tv67 = v58 == v63;\n\tv68 = ~v67;\n\tif (v68) goto L_FFFFFFFF;\n\tv290 = v42 == v66;\n\tv276 = v42 < v66;\n\tv289 = ~v276;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv289 = 1;\nL_FFFFFFFF:\n\tv290 = 0;\n\tv226 = v57 == v243;\n\tv297 = v57 < v243;\n\tv220 = ~v297;\n\tgoto L_0057;\nL_FFFFFFFF:\n\tv220 = 1;\nL_FFFFFFFF:\n\tv226 = 0;\nL_006B:\n\treturn;\nL_006F:\n\t;\n\t// 121 MakeStruct v136 @ AGG3DA70B8_1_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 122 MakeStruct v133 @ AGG3DA70B8_5_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\tv318 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v136, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v133);\n\tv319 = pos.value + this.sdfCellSize;\n\t// 135 MakeStruct v130 @ AGG3DA70E8_1_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 136 MakeStruct v127 @ AGG3DA70E8_5_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v319 @ V3_v4 (System.Single), pos.value.y (System.Single)\n\tv329 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v130, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v127);\n\tv330 = pos.value - this.sdfCellSize;\n\t// 147 MakeStruct v121 @ AGG3DA7110_1_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 148 MakeStruct v118 @ AGG3DA7110_5_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v330 @ V3_v5 (System.Single), pos.value.y (System.Single)\n\tv338 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v121, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v118);\n\tv339 = pos.value.y + this.sdfCellSize;\n\t// 160 MakeStruct v115 @ AGG3DA713C_1_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 161 MakeStruct v112 @ AGG3DA713C_5_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), v339 @ V4_v5 (System.Single)\n\tv347 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v115, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v112);\n\tv139 = pos.value.y - this.sdfCellSize;\n\t// 173 MakeStruct v109 @ AGG3DA7168_1_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 174 MakeStruct v106 @ AGG3DA7168_5_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), v139 @ V4_v6 (System.Single)\n\tv244 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v109, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v106);\n\tv233 = v318 < radius.value;\n\tv350 = v318 == v318;\n\tv172 = radius.value == radius.value;\n\tv215 = v350 & v172;\n\tv209 = ~v215;\n\tv204 = v233 == v209;\n\tif (v204) goto L_006B;\n\tv354 = this.sdfCellSize + this.sdfCellSize;\n\tv355 = v329 - v338;\n\tv356 = v347 - v244;\n\tv252 = 1f / v354;\n\tgoto L_00D3;\n\tv246 = v161 / v239;\n\tv240 = v249 / v239;\n\tv394 = radius.value - v318;\n\tv426 = radius.value * this.maxRadiiPerStep;\n\tv90 = v426 & 0x7FFFFFFF;\n\tv397 = v90 < 0x7F800000;\n\tv398 = ~v397;\n\tv399 = v90 - 0x7F800000;\n\tv401 = v399 == 0;\n\tv404 = ~v398;\n\tv405 = v404 | v401;\n\tv406 = ~v405;\n\tif (v406) goto L_FFFFFFFF;\n\tv423 = v394 < v426;\n\tgoto L_0111;\nL_FFFFFFFF:\n\tv423 = 1;\nL_FFFFFFFF:\n\tv426 = v394;\n\tgoto L_0119;\n\tv201 = -v191;\n\tv435 = v201 < 0x7F800001;\n\tv436 = ~v435;\n\tv445 = ~v436;\n\tv446 = ~v445;\n\tif (v446) goto L_FFFFFFFF;\n\tv464 = v191 < -1f;\n\tgoto L_014C;\nL_FFFFFFFF:\n\tv464 = 1;\nL_FFFFFFFF:\n\tv162 = v201;\n\tgoto L_0154;\nL_FFFFFFFF:\n\tv162 = 1f;\n\tv511 = v155 / v496;\n\tv512 = v257 / v496;\n\tv532 = this.friction * v201;\n\tv516 = v532 < v496;\n\tv525 = ~v516;\n\tv526 = ~v525;\n\tif (v526) goto L_FFFFFFFF;\n\tv547 = v496 < 0x7F800000;\n\tv536 = ~v547;\n\tv549 = v496 - 0x7F800000;\n\tv537 = v549 == 0;\n\tgoto L_019F;\nL_FFFFFFFF:\n\tv536 = 1;\nL_FFFFFFFF:\n\tv537 = 0;\n\tgoto L_01A7;\nL_FFFFFFFF:\n\tv532 = v496;\nL_0044:\n\tv243 = this.sdfGridHeight + -1f;\n\tv293 = ~v289;\n\tv294 = v293 | v290;\n\tv177 = ~v294;\n\tif (v177) goto L_FFFFFFFF;\nL_0057:\n\tv307 = ~v220;\n\tv203 = v307 | v226;\n\tif (v203) goto L_006F;\nL_00D3:\n\tv161 = v252 * v355;\n\tv249 = v252 * v356;\n\tgoto L_00DE;\nL_0111:\n\tv179 = ~v423;\n\tif (v179) goto L_0119;\nL_0119:\n\tv71 = v246 * v426;\n\tv428 = v240 * v426;\n\tv429 = pos.value + v71;\n\tv430 = pos.value.y + v428;\n\tpos.value.x = v429;\n\tpos.value.y = v430;\n\tv431 = v246 * vel.value;\n\tv185 = v240 * vel.value.y;\n\tv191 = v431 + v185;\n\tv235 = v191 < 0;\n\tv205 = ~v235;\n\tif (v205) goto L_006B;\nL_014C:\n\tv466 = ~v464;\n\tv467 = ~v466;\n\tif (v467) goto L_FFFFFFFF;\nL_0154:\n\tv253 = v246 * v191;\n\tv199 = v240 * v191;\n\tgoto L_0162;\nL_016C:\n\tv493 = v155 * v155;\n\tv494 = v257 * v257;\n\tv495 = v493 + v494;\n\tv496 = UnityEngine.Mathf::Sqrt(v495);\n\tv500 = v496 < 0x358637BD;\n\tv501 = v496 == 0x358637BD;\n\tv504 = v496 == v496;\n\tv507 = ~v504;\n\tv508 = v500 == v507;\n\tv509 = ~v508;\n\tv510 = v509 | v501;\n\tif (v510) goto L_01AA;\nL_01AA:\n\tv543 = this.restitution * v162;\n\tv544 = -v543;\n\tv545 = v253 * v544;\n\tv546 = v199 * v544;\n\tv241 = v545 + v155;\n\tv247 = v546 + v257;\n\tvel.value.x = v241;\n\tvel.value.y = v247;\n\tgoto L_006B;\nL_019F:\n\tv560 = ~v537;\n\tv533 = v536 & v560;\n\tv531 = ~v533;\n\tif (v531) goto L_FFFFFFFF;\nL_01A7:\n\tv541 = v496 - v532;\n\tv155 = v511 * v541;\n\tv257 = v512 * v541;\nL_00DE:\n\tv387 = v161 * v161;\n\tv388 = v249 * v249;\n\tv389 = v387 + v388;\n\tv239 = UnityEngine.Mathf::Sqrt(v389);\n\tv234 = v239 < 0x3727C5AC;\n\tif (v234) goto L_006B;\nL_0162:\n\tv155 = vel.value - v253;\n\tv257 = vel.value.y - v199;\n\tgoto L_016C;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void ResolveWallsViaSDF(ref ParticlePosition pos, ref ParticleVelocity vel, in ParticleRadius radius)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::ResolveWallsViaSDF");
			}

			[Token(Token = "0x600056A")]
			[Address(RVA = "0x3DA7424", Offset = "0x3DA7424", Length = "0x3F8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv107 = v85 / v49;\n\tv108 = v107 * v49;\n\tv109 = v85 - v108;\n\tv98 = this.vertices;\n\tv95 = v87 >> 0x1D;\n\tv110 = v109 + shape.vertexStart;\n\tv90 = *([v98 @ X13_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v110 @ X12_v5*8]) - *([v98 @ X13_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v95 @ X14_v3 (System.Int32)]);\n\tv113 = pos.value - *([v98 @ X13_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v95 @ X14_v3 (System.Int32)]);\n\t// 61 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv92 = v113 * v90;\n\t// 63 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 64 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\tv87 = v87 + 0x100000000;\n\tv104 = v104 - 1;\n\tv85 = v85 + 1;\n\tv114 = v92 & 1;\n\tv103 = v114 == 0;\n\tif (v103) goto L_0031;\n\tv136 = v49 < 1;\n\tif (v136) goto L_01E4;\n\tv349 = v49 & 0x7FFFFFFF;\n\tv322 = 0 - v349;\nL_FFFFFFFF:\n\tv413 = 1;\nL_FFFFFFFF:\n\tv450 = 0;\n\tgoto L_006C;\nL_FFFFFFFF:\n\tv450 = v413;\n\tgoto L_01E4;\nL_0093:\n\tv125 = v49 < 1;\n\tif (v125) goto L_01E4;\n\tv146 = v49 & 0x7FFFFFFF;\n\tv388 = *([B193A96]);\n\tv152 = 0 - v146;\n\tv162 = 0xB193000;\nL_FFFFFFFF:\n\tv360 = 1;\nL_FFFFFFFF:\n\tv220 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv226 = v141.zero.y;\nL_FFFFFFFF:\n\tv229 = v141.zero;\nL_FFFFFFFF:\n\tv292 = 0xB193000;\n\tgoto L_00BC;\nL_00AF:\n\tv412 = v412 + 0x100000000;\n\tv360 = v360 + 1;\n\tv289 = v152 + v360;\n\tv374 = v289 == 1;\n\tif (v374) goto L_0110;\nL_00BC:\n\tv390 = v152 + v360;\n\tv393 = v390 == 0;\n\tv400 = v412 >> 0x1D;\n\tv401 = this.vertices + v400;\n\tv200 = ~v393;\n\tif (v200) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv444 = 0;\n\tgoto L_00D0;\nL_FFFFFFFF:\n\tv444 = v360;\n\t*([v162 @ X19_v4 (System.Int32)+A96]) = 1;\nL_FFFFFFFF:\n\tv292 = 0xB193000;\nL_FFFFFFFF:\n\tv388 = 1;\n\tgoto L_00E8;\n\tv481 = -v467;\n\tv482 = v468 / v472;\n\tv483 = v481 / v472;\n\tv485 = pos.value - *([v401 @ X10_v4]);\n\tv486 = v151 - *([v401 @ X10_v4+4]);\n\tv487 = v485 * v482;\n\tv488 = v486 * v483;\n\tv489 = v487 + v488;\n\tv490 = v489 < v220;\n\tv498 = ~v490;\n\tif (v498) goto L_00AF;\nL_FFFFFFFF:\n\tv220 = v489;\nL_FFFFFFFF:\n\tv226 = v483;\nL_FFFFFFFF:\n\tv229 = v482;\n\tgoto L_00AF;\nL_0110:\n\tv271 = v220 < 0x7F7FFFFF;\n\tv241 = ~v271;\n\tif (v241) goto L_01E4;\n\tv302 = r - v220;\n\tv242 = r <= v220;\n\tif (v242) goto L_01E4;\n\t*([hadWallContact @ X7 (System.Boolean&)]) = 1;\n\tv516 = *([vertexHitCount @ X5 (System.Int32&)]) + 1;\n\t*([vertexHitCount @ X5 (System.Int32&)]) = v516;\n\tv519 = v229 + accVertexNormal.x;\n\tv520 = v226 + accVertexNormal.y;\n\taccVertexNormal.x = v519;\n\taccVertexNormal.y = v520;\n\tv195 = v229 * v302;\n\tv522 = v226 * v302;\n\tv523 = v195 + pos.value;\n\tv524 = v522 + pos.value.y;\n\tpos.value.x = v523;\n\tpos.value.y = v524;\n\tv525 = v229 * vel.value;\n\tv297 = v226 * vel.value.y;\n\tv303 = v525 + v297;\n\tv273 = v303 < 0;\n\tv243 = ~v273;\n\tif (v243) goto L_01E4;\n\tv219 = -v303;\n\tv530 = v219 < 0x7F800001;\n\tv531 = ~v530;\n\tv540 = ~v531;\n\tv541 = ~v540;\n\tif (v541) goto L_FFFFFFFF;\n\tv557 = v303 < -1f;\n\tgoto L_016A;\nL_FFFFFFFF:\n\tv557 = 1;\nL_FFFFFFFF:\n\tv326 = v219;\n\tgoto L_0174;\nL_FFFFFFFF:\n\tv326 = 1f;\n\t*([v292 @ X11_v7 (System.Int32)+A96]) = 1;\nL_0189:\n\tv584 = v205 * v205;\n\tv585 = v216 * v216;\n\tv586 = v584 + v585;\n\tv587 = UnityEngine.Mathf::Sqrt(v586);\n\tv591 = v587 < 0x358637BD;\n\tv592 = v587 == 0x358637BD;\n\tv595 = v587 == v587;\n\tv598 = ~v595;\n\tv599 = v591 == v598;\n\tv600 = ~v599;\n\tv601 = v600 | v592;\n\tif (v601) goto L_01C7;\n\tv602 = v205 / v587;\n\tv603 = v216 / v587;\n\tv618 = this.friction * v219;\n\tv607 = v618 < v587;\n\tv616 = ~v607;\n\tv617 = ~v616;\n\tif (v617) goto L_FFFFFFFF;\n\tv638 = v587 < 0x7F800000;\n\tv630 = ~v638;\n\tv640 = v587 - 0x7F800000;\n\tv627 = v640 == 0;\n\tgoto L_01BC;\nL_FFFFFFFF:\n\tv627 = 0;\nL_FFFFFFFF:\n\tv630 = 1;\n\tgoto L_01C4;\nL_FFFFFFFF:\n\tv618 = v587;\nL_002B:\n\tv79 = ~v49;\n\tv104 = v49 & v79;\n\tv412 = shape.vertexStart << 0x20;\nL_FFFFFFFF:\n\tv85 = 1;\nL_FFFFFFFF:\n\tv87 = v412;\nL_0031:\n\tv106 = v104 == 0;\n\tif (v106) goto L_0093;\nL_01E4:\n\treturn;\nL_006C:\n\tv451 = v450 + shape.vertexStart;\n\tv288 = v451 << 0x20;\n\tv212 = v288 >> 0x1D;\n\tv452 = this.vertices + v212;\n\t// 119 MakeStruct v168 @ AGG3DA7548_4_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), [v439 @ X9_v19], [v439 @ X9_v19+4]\n\t// 120 MakeStruct v165 @ AGG3DA7548_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), [v452 @ X8_v36], [v452 @ X8_v36+4]\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::ResolveEdgeTwoSided(this, pos, vel, r, v168, v165, hadWallContact);\n\tv412 = v412 + 0x100000000;\n\tv413 = v413 + 1;\n\tv317 = v322 + v413;\n\tv240 = v317 != 1;\n\tif (v240) goto L_0058;\nL_0058:\n\tv429 = v322 + v413;\n\tv432 = v429 == 0;\n\tv438 = v412 >> 0x1D;\n\tv439 = this.vertices + v438;\n\tv199 = ~v432;\n\tif (v199) goto L_FFFFFFFF;\nL_00D0:\n\tv445 = v444 + shape.vertexStart;\n\tv208 = v445 << 0x20;\n\tv210 = v208 >> 0x1D;\n\tv446 = this.vertices + v210;\n\tv447 = v388 & 1;\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_00E2;\nL_00E8:\n\tv467 = *([v446 @ X9_v10]) - *([v401 @ X10_v4]);\n\tv468 = *([v446 @ X9_v10+4]) - *([v401 @ X10_v4+4]);\n\tv469 = v467 * v467;\n\tv470 = v468 * v468;\n\tv471 = v469 + v470;\n\tv472 = UnityEngine.Mathf::Sqrt(v471);\n\tv473 = v472 < 0x358637BD;\n\tif (v473) goto L_00AF;\nL_016A:\n\tv561 = ~v557;\n\tv562 = ~v561;\n\tif (v562) goto L_FFFFFFFF;\nL_0174:\n\tv176 = v229 * v303;\n\tv179 = v226 * v303;\n\tv568 = *([v292 @ X11_v7 (System.Int32)+A96]) & 1;\n\tv569 = v568 == 0;\n\tv570 = ~v569;\n\tif (v570) goto L_0181;\nL_01C7:\n\tv634 = this.restitution * v326;\n\tv635 = -v634;\n\tv636 = v176 * v635;\n\tv637 = v179 * v635;\n\tv294 = v636 + v205;\n\tv299 = v637 + v216;\n\tvel.value.x = v294;\n\tvel.value.y = v299;\nL_01BC:\n\tv651 = ~v627;\n\tv622 = v630 & v651;\n\tv619 = ~v622;\n\tif (v619) goto L_FFFFFFFF;\nL_01C4:\n\tv633 = v587 - v618;\n\tv205 = v602 * v633;\n\tv216 = v603 * v633;\nL_00E2:\n\tgoto L_FFFFFFFF;\nL_0181:\n\tv205 = vel.value - v176;\n\tv216 = vel.value.y - v179;\n\tgoto L_0189;\n")]
			private void ResolveConvexPolygon(ref ParticlePosition pos, ref ParticleVelocity vel, float r, CollisionShape shape, ref int vertexHitCount, ref float2 accVertexNormal, ref bool hadWallContact)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::ResolveConvexPolygon");
			}

			[Token(Token = "0x600056B")]
			[Address(RVA = "0x3DA79C0", Offset = "0x3DA79C0", Length = "0x174")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = b - a;\n\tv5 = b.y - a.y;\n\tv6 = v4 * v4;\n\tv7 = v5 * v5;\n\tv8 = v6 + v7;\n\tv12 = v8 < 0x322BCC77;\n\tv20 = ~v12;\n\tif (v20) goto L_0027;\n\treturn;\nL_0027:\n\tv54 = v106.value - a;\n\tv55 = v106.value.y - a.y;\n\tv56 = v4 * v54;\n\tv57 = v5 * v55;\n\tv58 = v57 + v56;\n\tv185 = v58 / v8;\n\tv61 = v185 & 0x7FFFFFFF;\n\tv64 = v61 < 0x7F800001;\n\tv65 = ~v64;\n\tv74 = ~v65;\n\tv75 = ~v74;\n\tif (v75) goto L_FFFFFFFF;\n\tv208 = v185 < 1f;\n\tv207 = v185 == 1f;\n\tv196 = v185 == v185;\n\tv197 = 1f == 1f;\n\tv198 = v196 & v197;\n\tv204 = ~v198;\n\tgoto L_004C;\nL_FFFFFFFF:\n\tv204 = 0;\nL_FFFFFFFF:\n\tv207 = 0;\nL_FFFFFFFF:\n\tv208 = 0;\n\tgoto L_0055;\nL_FFFFFFFF:\n\tv185 = 1f;\nL_FFFFFFFF:\n\tv185 = 0;\n\tgoto L_0062;\nL_004C:\n\tv209 = v208 == v204;\n\tv210 = ~v209;\n\tv167 = v210 | v207;\n\tv211 = ~v167;\n\tif (v211) goto L_FFFFFFFF;\nL_0055:\n\tv179 = v185 < 0;\n\tv122 = ~v179;\n\tif (v122) goto L_0062;\nL_0062:\n\tv218 = v4 * v185;\n\tv189 = v5 * v185;\n\tv219 = a + v218;\n\tv220 = a.y + v189;\n\tgoto L_007E;\nL_0091:\n\tv278 = v258 * v258;\n\tv279 = v259 * v259;\n\tv280 = v278 + v279;\n\tv187 = UnityEngine.Mathf::Sqrt(v280);\n\t// 166 MakeStruct v81 @ AGG3DA7B30_4_v1 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v258 @ V8_v2 (System.Single), v259 @ V9_v2 (System.Single)\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::ResolveEdgeTwoSidedCore(v117, v106, v101, v104, v81, v187, v98);\n\treturn;\nL_007E:\n\tv258 = v106.value - v219;\n\tv259 = v106.value.y - v220;\n\tgoto L_0091;\n")]
			private void ResolveEdgeTwoSided(ref ParticlePosition pos, ref ParticleVelocity vel, float r, float2 a, float2 b, ref bool hadWallContact)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::ResolveEdgeTwoSided");
			}

			[Token(Token = "0x600056C")]
			[Address(RVA = "0x3DA7B34", Offset = "0x3DA7B34", Length = "0x190")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = v224.twoSidedCatchRadii * r;\n\tv9 = dist < 0x358637BD;\n\tv11 = dist == 0x358637BD;\n\tv14 = dist == dist;\n\tv17 = ~v14;\n\tv18 = v9 == v17;\n\tv19 = ~v11;\n\tv20 = v18 & v19;\n\tv21 = ~v20;\n\tif (v21) goto L_FFFFFFFF;\n\tv39 = v4 < dist;\n\tv38 = v4 == dist;\n\tv26 = v4 == v4;\n\tv27 = dist == dist;\n\tv28 = v26 & v27;\n\tv34 = ~v28;\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv34 = 0;\nL_FFFFFFFF:\n\tv38 = 1;\nL_FFFFFFFF:\n\tv39 = 0;\n\t*([hadWallContact @ X3 (System.Boolean&)]) = 1;\n\t// 40 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv47 = diff / diff.y;\n\tv180 = r - dist;\n\tv57 = r <= dist;\n\tif (v57) goto L_0049;\n\tv177 = v47 * v178;\n\tv180 = v177 + pos.value;\n\tpos.value = v180;\n\t// 82 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv194 = -v180;\n\tv198 = v194 < 0x7F800001;\n\tv199 = ~v198;\n\tv208 = ~v199;\n\tv209 = ~v208;\n\tif (v209) goto L_FFFFFFFF;\n\tv262 = v180 < -1f;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv262 = 1;\n\tgoto L_007C;\n\t// 173 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv319 = v216 / 0x358637BD;\n\tv321 = v224.friction * v194;\n\tv323 = v321 < v304;\n\tv332 = ~v323;\n\tv333 = ~v332;\n\tif (v333) goto L_FFFFFFFF;\n\tv351 = v304 < 0x7F800000;\n\tv344 = ~v351;\n\tv353 = v304 - 0x7F800000;\n\tv345 = v353 == 0;\n\tgoto L_00CD;\nL_FFFFFFFF:\n\tv344 = 1;\nL_FFFFFFFF:\n\tv345 = 0;\n\tgoto L_00D6;\nL_0021:\n\tv40 = v39 == v34;\n\tv41 = ~v40;\n\tv42 = v41 | v38;\n\tif (v42) goto L_00E9;\nL_0049:\n\t// 73 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv186 = v180 < 0;\n\tv192 = ~v186;\n\tif (v192) goto L_00E9;\nL_0074:\n\tv264 = ~v262;\n\tv265 = ~v264;\n\tif (v265) goto L_007C;\nL_007C:\n\tv212 = v47 * v45;\n\tgoto L_008F;\nL_009B:\n\tv303 = v216 * v216;\n\t// 156 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv304 = UnityEngine.Mathf::Sqrt(v303);\n\tv308 = v304 < 0x358637BD;\n\tv309 = v304 == 0x358637BD;\n\tv312 = v304 == v304;\n\tv315 = ~v312;\n\tv316 = v308 == v315;\n\tv317 = ~v316;\n\tv318 = v317 | v309;\n\tif (v318) goto L_00D9;\nL_00D9:\n\tv350 = v212 * v178;\n\tv233 = v350 + v216;\n\tv221.value = v233;\nL_00CD:\n\tv364 = ~v345;\n\tv340 = v344 & v364;\n\tv339 = ~v340;\n\tif (v339) goto L_00D6;\nL_00D6:\n\tv216 = v319 * v178;\nL_00E9:\n\treturn;\nL_008F:\n\tv216 = v221.value - v212;\n\tgoto L_009B;\n")]
			private void ResolveEdgeTwoSidedCore(ref ParticlePosition pos, ref ParticleVelocity vel, float r, float2 diff, float dist, ref bool hadWallContact)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::ResolveEdgeTwoSidedCore");
			}

			[CompilerGenerated]
			[Token(Token = "0x600056D")]
			[Address(RVA = "0x3DA7CC4", Offset = "0x3DA7CC4", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0x100;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00EC;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v60 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_011F;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = 0;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = v517;\n\tv452 = ~v443;\n\tv454 = ~v420;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v195 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v452, v454);\n\tv288 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v195);\n\tv293 = v288 == 0;\n\tif (v293) goto L_01B4;\n\tv541 = v420 + v297;\n\tv517 = v288 + v541;\n\tv527 = v541 >= v517;\nL_FFFFFFFF:\n\tv579 = v288;\n\tif (v527) goto L_FFFFFFFF;\nL_00B3:\n\t;\n\tv584 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v541);\n\tv617 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v541);\n\tv640 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v541);\n\tv652 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v541);\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::Execute(this, v584, v617, v640, v652);\n\tv541 = v541 + 1;\n\tv580 = v579 - 1;\n\tv546 = v579 != 1;\nL_FFFFFFFF:\n\tv579 = v580;\n\tif (v546) goto L_00B3;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01B4;\nL_FFFFFFFF:\n\tv385 = 0;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v385);\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::Execute(this, v403, v426, v449, v488);\n\tv385 = v385 + 1;\n\tv218 = v109 != v385;\n\tif (v218) goto L_00FA;\n\tgoto L_01B4;\nL_011F:\n\tv156 = v109 - 0x40;\n\tv157 = v156 < 0;\n\tv159 = v109 ^ 0x40;\n\tv160 = v109 ^ v156;\n\tv161 = v159 & v160;\n\tv162 = v161 < 0;\n\tv164 = v157 == v162;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = v109;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv298 = 0x40;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv483 = 0;\n\tgoto L_014C;\nL_0140:\n\tv302 = v302 >> 1;\n\tv483 = v483 + 1;\n\tv469 = v298 == v483;\n\tif (v469) goto L_017B;\nL_014C:\n\tv484 = v302 & 1;\n\tv294 = v484 == 0;\n\tif (v294) goto L_0140;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v483);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v483);\n\tv533 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v483);\n\tv592 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v483);\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::Execute(this, v495, v511, v533, v592);\n\tgoto L_0140;\nL_017B:\n\tv219 = v109 < 0x41;\n\tif (v219) goto L_01B4;\n\tv535 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv596 = 0x40;\n\tgoto L_018D;\nL_0181:\n\tv299 = v535 >> 1;\n\tv596 = v596 + 1;\n\tv249 = v109 == v596;\nL_FFFFFFFF:\n\tv535 = v299;\n\tif (v249) goto L_01B4;\nL_018D:\n\tv613 = v535 & 1;\n\tv295 = v613 == 0;\n\tif (v295) goto L_0181;\n\tv623 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v596);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v596);\n\tv658 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v596);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v596);\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::Execute(this, v623, v646, v658, v663);\n\tgoto L_0181;\nL_01B4:\n\tv324 = *([A4731E0]);\n\tv335 = *([v324 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v335) goto L_01CF;\n\treturn;\nL_01CF:\n\tv416 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x88;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0xB0;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0xD8;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v92);\nL_0080:\n\tv375 = v271;\n\tv379 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v297);\n\tv375 = v379;\n\tv420 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v379);\n\tv443 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v420);\nL_00FA:\n\tv403 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v385);\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v385);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v385);\nL_0139:\n\tv220 = v109 < 1;\n\tif (v220) goto L_01B4;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::Execute");
			}

			[Token(Token = "0x600056E")]
			[Address(RVA = "0x3DA81D0", Offset = "0x3DA81D0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem.WallCollisionJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x600056F")]
			[Address(RVA = "0x3DA8224", Offset = "0x3DA8224", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000570")]
			[Address(RVA = "0x3DA8230", Offset = "0x3DA8230", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000571")]
			[Address(RVA = "0x3DA823C", Offset = "0x3DA823C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000572")]
			[Address(RVA = "0x3DA8248", Offset = "0x3DA8248", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000573")]
			[Address(RVA = "0x3DA8254", Offset = "0x3DA8254", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000574")]
			[Address(RVA = "0x3DA8260", Offset = "0x3DA8260", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000575")]
			[Address(RVA = "0x3DA826C", Offset = "0x3DA826C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000576")]
			[Address(RVA = "0x3DA8278", Offset = "0x3DA8278", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000577")]
			[Address(RVA = "0x3DA8284", Offset = "0x3DA8284", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000578")]
			[Address(RVA = "0x3DA8290", Offset = "0x3DA8290", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000579")]
			[Address(RVA = "0x3DA829C", Offset = "0x3DA829C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600057A")]
			[Address(RVA = "0x3DA82A8", Offset = "0x3DA82A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600057B")]
			[Address(RVA = "0x3DA82B4", Offset = "0x3DA82B4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600057C")]
			[Address(RVA = "0x3DA82C0", Offset = "0x3DA82C0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600057D")]
			[Address(RVA = "0x3DA82CC", Offset = "0x3DA82CC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600057E")]
			[Address(RVA = "0x3DA82D8", Offset = "0x3DA82D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600057F")]
			[Address(RVA = "0x3DA82E4", Offset = "0x3DA82E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000580")]
			[Address(RVA = "0x3DA82F0", Offset = "0x3DA82F0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000581")]
			[Address(RVA = "0x3DA82FC", Offset = "0x3DA82FC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000582")]
			[Address(RVA = "0x3DA8308", Offset = "0x3DA8308", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000583")]
			[Address(RVA = "0x3DA8314", Offset = "0x3DA8314", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000584")]
			[Address(RVA = "0x3DA8320", Offset = "0x3DA8320", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000585")]
			[Address(RVA = "0x3DA832C", Offset = "0x3DA832C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x2000105")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000363")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public WallCollisionJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_WallCollisionSystem_WallCollisionJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6000592")]
			[Address(RVA = "0x3DA8A60", Offset = "0x3DA8A60", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x3DA8484(this, state, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv36 = 0x3DA8610(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8484 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8610 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::Init +0x38)");
			}
		}

		[Token(Token = "0x4000341")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x6000560")]
		[Address(RVA = "0x3DA6510", Offset = "0x3DA6510", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x6000561")]
		[Address(RVA = "0x3DA6564", Offset = "0x3DA6564", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = *([B78E042]) & 1;\n\tv41 = v40 == 0;\n\tif (v41) goto L_002F;\n\tv67 = 0xB293000 + 0xDC8;\n\tv46 = *([B193A9A]) & 1;\n\tv47 = v46 == 0;\n\tv81 = v67;\n\tif (v47) goto L_003C;\nL_0021:\n\tv75 = *([v67 @ X22_v9 (System.Int32)]);\n\tv76 = *([v75 @ X8_v18+B8]);\n\tv91 = *([v76 @ X8_v19]);\n\tv78 = *([v76 @ X8_v19]) == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0048;\n\tgoto L_00D8;\nL_002F:\n\t*([B193042]) = 1;\n\tv67 = 0xB293000 + 0xDC8;\n\tv108 = *([B193A9A]) & 1;\n\tv109 = v108 == 0;\n\tv70 = ~v109;\n\tv81 = v67;\n\tif (v70) goto L_0021;\nL_003C:\n\t*([B193A9A]) = 1;\n\tv105 = *([v81 @ X22_v5 (System.Int32)]);\n\tv96 = *([v105 @ X8_v13+B8]);\n\tv91 = *([v96 @ X8_v14]);\n\tv94 = *([v96 @ X8_v14]) == 0;\n\tif (v94) goto L_00D8;\nL_0048:\n\tgoto L_004C;\nL_004C:\n\tv257 = UnityEngine.Object::op_Equality(*([v91 @ X22_v3+48]), 0);\n\tv264 = v257 == 0;\n\tif (v264) goto L_005A;\n\tgoto L_00D8;\nL_005A:\n\tv271 = *([v91 @ X22_v3+10]);\n\tv244 = *([v91 @ X22_v3+10]) + 0x58;\n\tv266 = *([v244 @ X11_v4]) == 0;\n\tif (v266) goto L_00D8;\n\tv267 = *([v271 @ X8_v7+70]) == 0;\n\tif (v267) goto L_00D8;\n\tv238 = *([v91 @ X22_v3+68]);\n\tv268 = *([v91 @ X22_v3+68]) == 0;\n\tif (v268) goto L_00D8;\n\tv205 = *([v238 @ X9_v4+3C]) != 1;\n\tif (v205) goto L_00D8;\n\tv242 = &v160 @ stack_-200;\n\t// 137 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 138 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv270 = &v160 @ stack_-200 + 0x88;\n\t*([v270 @ X8_v10+80]) = 0;\n\t*([v270 @ X8_v10+90]) = 0;\n\t*([v242 @ X11_v5+F8]) = 0;\n\t*([v242 @ X11_v5+E8]) = 0;\n\t*([v242 @ X11_v5+D8]) = 0;\n\t*([v242 @ X11_v5+C8]) = 0;\n\t*([v242 @ X11_v5+B8]) = 0;\n\t*([v242 @ X11_v5+A8]) = 0;\n\t*([v242 @ X11_v5+98]) = 0;\n\t*([v242 @ X11_v5+88]) = 0;\n\tv397 = Unity.Entities.SystemState::get_Dependency(state);\n\tv160 = *([v244 @ X11_v4]);\n\tv406 = 0x3DA67FC(this, &v160 @ stack_-200, this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_WallCollisionSystem_WallCollisionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_WallCollisionSystem_WallCollisionJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery.__seqno, v397, 0, state, 0, *([v238 @ X9_v4+18]), *([v271 @ X8_v7+98]), clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tUnity.Entities.SystemState::set_Dependency(state, v406);\nL_00D8:\n\treturn;\n")]
		public void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000562")]
		[Address(RVA = "0x3DA689C", Offset = "0x3DA689C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0023;\nL_0023:\n\tv58 = job + 0x88;\n\tv61 = 0x8BF6A34(v58, this, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(WallCollisionJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallCollisionSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000563")]
		[Address(RVA = "0x3DA6A14", Offset = "0x3DA6A14", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x6000564")]
		[Address(RVA = "0x3DA6A58", Offset = "0x3DA6A58", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3DA8484(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3DA8610(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8484 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8610 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000565")]
		[Address(RVA = "0x3DA6444", Offset = "0x3DA6444", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000566")]
		[Address(RVA = "0x3DA6498", Offset = "0x3DA6498", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.WallCollisionSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((WallCollisionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000567")]
		[Address(RVA = "0x3DA649C", Offset = "0x3DA649C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3DA8484(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3DA8610(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8484 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3DA8610 (inside _game.CoreSystem.SandPhysics.Systems.WallCollisionSystem+WallCollisionJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}
	}
}
