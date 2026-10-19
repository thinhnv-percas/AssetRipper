using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.SDF;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(GravitySystem))]
	[UpdateBefore(typeof(ParticleCollisionSystem))]
	[Token(Token = "0x20000E0")]
	public struct IntegratePositionSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000E1")]
		private struct IntegrateJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000E2")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000E3")]
				public struct TypeHandle
				{
					[Token(Token = "0x40002EC")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x40002ED")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x40002EE")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x60004A0")]
					[Address(RVA = "0x3C8B67C", Offset = "0x3C8B67C", Length = "0x100")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = v102.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = v102.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = v102.m_Length;\n\treturn;\nL_0024:\n\tv55 = &v63 @ stack_-68_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv59 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = *([v55 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = *([v55 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v55 @ X8_v3+10]);\n\tv77 = &v84 @ stack_-90_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv81 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v77 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v77 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v77 @ X8_v5+20]);\n\tv102 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x60004A1")]
					[Address(RVA = "0x3C8A6A0", Offset = "0x3C8A6A0", Length = "0xAC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\treturn;\nL_0026:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x40002EA")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002EB")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000498")]
				[Address(RVA = "0x3C8B144", Offset = "0x3C8B144", Length = "0x260")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv79 = v76;\n\tv83 = Unity.Entities.EntityQueryBuilder::WithAll(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v83;\n\tv88 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v88;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v93;\n\tv99 = Unity.Entities.EntityQueryBuilder::Build(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v99;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+80]) = state;\n\tv102 = Unity.Entities.EntityQueryBuilder::Reset(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002A:\n\tv60 = 0;\n\tv64 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v64);\n\tv76 = Unity.Entities.EntityQueryBuilder::WithAll(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticleState>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000499")]
				[Address(RVA = "0x3C8B3A4", Offset = "0x3C8B3A4", Length = "0x114")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = ~assignDefaultQuery;\n\tif (v22) goto L_001D;\n\tv27 = 0x3C8B274(this, state, 0, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tgoto L_002A;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+50]) = v110.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+60]) = v110.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+70]) = v110.m_Length;\n\treturn;\nL_002A:\n\tv63 = &v71 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData+TypeHandle);\n\tv67 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+20]) = *([v63 @ X8_v3+20]);\n\tthis.__TypeHandle = *([v63 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+10]) = *([v63 @ X8_v3+10]);\n\tv85 = &v86 @ stack_-90;\n\tv89 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+28]) = *([v85 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+38]) = *([v85 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData)+48]) = *([v85 @ X8_v5+20]);\n\tv110 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049A")]
				[Address(RVA = "0x3C8B4B8", Offset = "0x3C8B4B8", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x40;\n\tv54 = 0x8BF6A34(v51, this, 0x78, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref IntegrateJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049B")]
				[Address(RVA = "0x3C8B538", Offset = "0x3C8B538", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x40;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref IntegrateJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049C")]
				[Address(RVA = "0x3C8B5D0", Offset = "0x3C8B5D0", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x40;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref IntegrateJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049D")]
				[Address(RVA = "0x3C8B668", Offset = "0x3C8B668", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref IntegrateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049E")]
				[Address(RVA = "0x3C8B66C", Offset = "0x3C8B66C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref IntegrateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600049F")]
				[Address(RVA = "0x3C8B678", Offset = "0x3C8B678", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref IntegrateJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000E4")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x60004A2")]
				[Address(RVA = "0x3C8B77C", Offset = "0x3C8B77C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x40002DF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float dt;

			[ReadOnly]
			[Token(Token = "0x40002E0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public NativeArray<half> sdfValues;

			[Token(Token = "0x40002E1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public float2 sdfOrigin;

			[Token(Token = "0x40002E2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public float sdfCellSize;

			[Token(Token = "0x40002E3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			public int sdfGridWidth;

			[Token(Token = "0x40002E4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			public int sdfGridHeight;

			[Token(Token = "0x40002E5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
			public float restitution;

			[Token(Token = "0x40002E6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public float friction;

			[Token(Token = "0x40002E7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
			public float sandScale;

			[Token(Token = "0x40002E8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			public float conveyorScale;

			[Token(Token = "0x40002E9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x600047E")]
			[Address(RVA = "0x3C8A7F4", Offset = "0x3C8A7F4", Length = "0x39C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = state.flags;\n\tv45 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(&v40 @ stack_-74_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv47 = v45 == 0;\n\tv48 = ~v47;\n\tif (v48) goto L_01D9;\n\tv40 = state.flags;\n\tv55 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(&v40 @ stack_-74_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv206 = v55 == 0;\n\tv176 = ~v206;\n\tif (v176) goto L_01D9;\n\tv40 = state.flags;\n\tv211 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsOnConveyor(&v40 @ stack_-74_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv216 = v211 == 0;\n\tv223 = ~v216;\n\tv224 = ~v223;\n\tif (v224) goto L_0048;\n\tgoto L_0048;\n\t// 99 MakeStruct v259 @ AGG3C8A8F8_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 100 MakeStruct v260 @ AGG3C8A8F8_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v237 @ V3_v3 (System.Single), v244 @ V3.S1\n\tv261 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v259, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v260);\n\tv322 = v261 < 0;\n\tv305 = ~v322;\nL_FFFFFFFF:\n\tv114 = v237;\n\tif (v305) goto L_01C9;\n\tv344 = v237 - pos.value;\n\tv347 = v344 * 0x3F;\n\tv348 = pos.value + v347;\n\t// 125 MakeStruct v284 @ AGG3C8A934_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 126 MakeStruct v283 @ AGG3C8A934_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v348 @ V3_v6 (System.Single), v244 @ V3.S1\n\tv357 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v284, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v283);\n\tv358 = v357 < 0;\n\tv362 = v357 == v357;\n\tv363 = ~v362;\n\tv366 = v358 == v363;\n\tv367 = ~v366;\n\tv368 = ~v367;\n\tif (v368) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv414 = 0.5f;\n\tgoto L_0091;\nL_FFFFFFFF:\n\tv414 = 1f;\nL_FFFFFFFF:\n\tv278 = 0;\n\tgoto L_009B;\nL_FFFFFFFF:\n\tv278 = 0.5f;\nL_FFFFFFFF:\n\tv386 = 0.25f;\n\tgoto L_00A5;\nL_FFFFFFFF:\n\tv386 = 0.75f;\nL_FFFFFFFF:\n\tv414 = v386;\n\tgoto L_00C2;\n\tgoto L_00CA;\nL_FFFFFFFF:\n\tv278 = v386;\nL_FFFFFFFF:\n\tv446 = v276;\n\tgoto L_00EA;\nL_FFFFFFFF:\n\tv446 = v414;\nL_FFFFFFFF:\n\tv280 = v278;\n\tgoto L_00F2;\nL_FFFFFFFF:\n\tv280 = v276;\n\tgoto L_0114;\nL_0137:\n\tv505 = v339 * v339;\n\t// 312 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv300 = UnityEngine.Mathf::Sqrt(v505);\n\tv323 = v300 < 0x3727C5AC;\n\tv319 = v300 == 0x3727C5AC;\n\tv508 = v300 == v300;\n\tv311 = ~v508;\n\tv509 = v323 == v311;\n\tv510 = ~v509;\n\tv306 = v510 | v319;\nL_FFFFFFFF:\n\tv114 = v290;\n\tif (v306) goto L_01C9;\n\t// 329 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv301 = v339 / v300;\n\tv291 = v301 * vel.value;\n\t// 334 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv324 = this.sdfCellSize < 0;\n\tv307 = ~v324;\nL_FFFFFFFF:\n\tv114 = v290;\n\tif (v307) goto L_01C9;\n\t// 343 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv289 = v291 + v244;\n\tv275 = -this.sdfCellSize;\n\tv516 = v275 < 0x7F800001;\n\tv517 = ~v516;\n\tv525 = ~v517;\n\tv526 = ~v525;\n\tif (v526) goto L_FFFFFFFF;\n\tv542 = this.sdfCellSize < -1f;\n\tgoto L_0179;\nL_FFFFFFFF:\n\tv542 = 1;\n\tgoto L_0181;\n\t// 406 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv570 = v551 / 0x358637BD;\n\tv572 = this.friction * v275;\n\tv574 = v572 < v551;\n\tv583 = ~v574;\n\tv584 = ~v583;\n\tif (v584) goto L_FFFFFFFF;\n\tv586 = v551 < 0x7F800000;\n\tv612 = ~v586;\n\tv588 = v551 - 0x7F800000;\n\tv609 = v588 == 0;\n\tgoto L_01B7;\nL_FFFFFFFF:\n\tv609 = 0;\nL_FFFFFFFF:\n\tv612 = 1;\n\tgoto L_01C0;\nL_FFFFFFFF:\n\tv295 = v551;\nL_01D9:\n\treturn;\nL_0048:\n\tv232 = vel.value * v233;\n\tv234 = v232 * v235;\n\tv237 = pos.value + v234;\n\t// 85 MakeStruct v90 @ AGG3C8A8D4_0_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 86 MakeStruct v87 @ AGG3C8A8D4_4_v2 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v237 @ V3_v3 (System.Single), v244 @ V3.S1\n\tv248 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::IsInsideGrid(v90, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v87);\n\tv249 = ~v248;\nL_FFFFFFFF:\n\tv114 = v237;\n\tif (v249) goto L_01C9;\nL_01C9:\n\tpos.value = v114;\nL_0091:\n\tv373 = v358 == v363;\n\tv374 = ~v373;\n\tv375 = ~v374;\n\tif (v375) goto L_FFFFFFFF;\nL_009B:\n\tv381 = v358 == v363;\n\tv382 = ~v381;\n\tv383 = ~v382;\n\tif (v383) goto L_FFFFFFFF;\nL_00A5:\n\tv389 = v386 * v344;\n\tv390 = v386 * v391;\n\tv392 = pos.value + v389;\n\tv394 = v393 + v390;\n\t// 177 MakeStruct v271 @ AGG3C8A988_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 178 MakeStruct v270 @ AGG3C8A988_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v392 @ V3_v7 (System.Single), v394 @ V4_v6 (System.Single)\n\tv402 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v271, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v270);\n\tv403 = v402 < 0;\n\tv407 = v402 == v402;\n\tv408 = ~v407;\n\tv409 = v403 == v408;\n\tv410 = ~v409;\n\tv411 = ~v410;\n\tif (v411) goto L_00C2;\nL_00C2:\n\tv415 = v403 == v408;\n\tv416 = ~v415;\n\tv417 = ~v416;\n\tif (v417) goto L_FFFFFFFF;\nL_00CA:\n\tv420 = v414 + v278;\n\tv276 = v420 * 0.5f;\n\tv423 = v276 * v344;\n\tv424 = v276 * v391;\n\tv425 = pos.value + v423;\n\tv426 = v393 + v424;\n\t// 217 MakeStruct v269 @ AGG3C8A9C8_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 218 MakeStruct v268 @ AGG3C8A9C8_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v425 @ V3_v8 (System.Single), v426 @ V4_v7 (System.Single)\n\tv434 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v269, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v268);\n\tv435 = v434 < 0;\n\tv439 = v434 == v434;\n\tv440 = ~v439;\n\tv441 = v435 == v440;\n\tv442 = ~v441;\n\tv443 = ~v442;\n\tif (v443) goto L_FFFFFFFF;\nL_00EA:\n\tv447 = v435 == v440;\n\tv448 = ~v447;\n\tv449 = ~v448;\n\tif (v449) goto L_FFFFFFFF;\nL_00F2:\n\tv452 = v446 + v280;\n\tv453 = v452 * 0.5f;\n\tv456 = v453 * v344;\n\tv457 = v453 * v391;\n\tv458 = pos.value + v456;\n\tv459 = v393 + v457;\n\t// 257 MakeStruct v267 @ AGG3C8AA08_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 258 MakeStruct v266 @ AGG3C8AA08_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v458 @ V3_v9 (System.Single), v459 @ V4_v8 (System.Single)\n\tv467 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::Sample(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v267, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v266);\n\tv468 = v467 < 0;\n\tv472 = v467 == v467;\n\tv473 = ~v472;\n\tv474 = v468 == v473;\n\tv475 = ~v474;\n\tv303 = ~v475;\n\tif (v303) goto L_0114;\nL_0114:\n\tv480 = v344 * v235;\n\tv290 = pos.value + v480;\n\t// 288 MakeStruct v263 @ AGG3C8AA40_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), this.sdfOrigin (Unity.Mathematics.float2), this.sdfOrigin.y (System.Single)\n\t// 289 MakeStruct v262 @ AGG3C8AA40_5_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v290 @ V3_v10 (System.Single), v244 @ V3.S1\n\tv484 = _game.CoreSystem.SandPhysics.SDF.SandSDFSampler::SampleWithGradient(&this.sdfValues (Unity.Collections.NativeArray`1<Unity.Mathematics.half>), v263, this.sdfCellSize, this.sdfGridWidth, this.sdfGridHeight, v262, &v339 @ stack_-80_v4 (Unity.Mathematics.float2));\n\tgoto L_0135;\nL_0135:\n\tgoto L_0137;\nL_0179:\n\tv546 = ~v542;\n\tv547 = ~v546;\n\tif (v547) goto L_0181;\nL_0181:\n\tv277 = v301 * v550;\n\tv551 = vel.value - v277;\n\tv335 = 0x3C7D8E8(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, c\n// ... truncated")]
			private void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, in ParticleState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x600047F")]
			[Address(RVA = "0x3C8AB90", Offset = "0x3C8AB90", Length = "0x454")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0039;\n\tv97 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv104 = useEnabledMask == 0;\n\tif (v104) goto L_00D8;\n\tv109 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv110 = v109 ^ chunkEnabledMask.Byte0;\n\t// 84 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 85 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 86 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 87 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 88 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 89 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv111 = v58 + v110;\n\tv113 = v111 < 5;\n\tv114 = ~v113;\n\tv115 = v111 - 5;\n\tv117 = v115 == 0;\n\tv122 = ~v117;\n\tv123 = v114 & v122;\n\tif (v123) goto L_0103;\nL_FFFFFFFF:\n\tv252 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv295 = 0;\n\tgoto L_0076;\nL_FFFFFFFF:\n\tv252 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv295 = v484;\n\tv428 = ~v418;\n\tv430 = ~v395;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v172 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v428, v430);\n\tv269 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v172);\n\tv274 = v269 == 0;\n\tif (v274) goto L_0184;\n\tv504 = v395 + v295;\n\tv484 = v269 + v504;\n\tv496 = v504 >= v484;\nL_FFFFFFFF:\n\tv540 = v269;\n\tif (v496) goto L_FFFFFFFF;\nL_00A9:\n\t;\n\tv545 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v504);\n\tv570 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v504);\n\tv589 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v504);\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::Execute(this, v545, v570, v589);\n\tv504 = v504 + 1;\n\tv541 = v540 - 1;\n\tv511 = v540 != 1;\nL_FFFFFFFF:\n\tv540 = v541;\n\tif (v511) goto L_00A9;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00D8:\n\tv134 = v97 < 1;\n\tif (v134) goto L_0184;\nL_FFFFFFFF:\n\tv373 = 0;\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::Execute(this, v378, v401, v425);\n\tv373 = v373 + 1;\n\tv199 = v97 != v373;\n\tif (v199) goto L_00E4;\n\tgoto L_0184;\nL_0103:\n\tv145 = v97 - 0x40;\n\tv146 = v145 < 0;\n\tv148 = v97 ^ 0x40;\n\tv149 = v97 ^ v145;\n\tv150 = v148 & v149;\n\tv151 = v150 < 0;\n\tv153 = v146 == v151;\n\tv154 = ~v153;\n\tv155 = ~v154;\n\tif (v155) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv292 = v97;\n\tgoto L_011D;\nL_FFFFFFFF:\n\tv292 = 0x40;\nL_FFFFFFFF:\n\tv192 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv457 = 0;\n\tgoto L_0130;\nL_0124:\n\tv192 = v192 >> 1;\n\tv457 = v457 + 1;\n\tv444 = v292 == v457;\n\tif (v444) goto L_0155;\nL_0130:\n\tv458 = v192 & 1;\n\tv275 = v458 == 0;\n\tif (v275) goto L_0124;\n\tv465 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v457);\n\tv479 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v457);\n\tv500 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v457);\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::Execute(this, v465, v479, v500);\n\tgoto L_0124;\nL_0155:\n\tv200 = v97 < 0x41;\n\tif (v200) goto L_0184;\n\tv502 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv563 = 0x40;\n\tgoto L_0167;\nL_015B:\n\tv196 = v502 >> 1;\n\tv563 = v563 + 1;\n\tv230 = v97 == v563;\nL_FFFFFFFF:\n\tv502 = v196;\n\tif (v230) goto L_0184;\nL_0167:\n\tv565 = v502 & 1;\n\tv276 = v565 == 0;\n\tif (v276) goto L_015B;\n\tv576 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v563);\n\tv594 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v563);\n\tv598 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v563);\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::Execute(this, v576, v594, v598);\n\tgoto L_015B;\nL_0184:\n\tv303 = *([A4731E0]);\n\tv314 = *([v303 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v314) goto L_019F;\n\treturn;\nL_019F:\n\tv391 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0039:\n\tv71 = this + 0x40;\n\tv72 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v71);\n\tv80 = this + 0x68;\n\tv81 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v80);\n\tv89 = this + 0x90;\n\tv90 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v89);\nL_0076:\n\tv352 = v252;\n\tv356 = Unity.Entities.EnabledBitUtility::ShiftRight(&v352 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v295);\n\tv352 = v356;\n\tv395 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v356);\n\tv418 = Unity.Entities.EnabledBitUtility::ShiftRight(&v352 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v395);\nL_00E4:\n\tv378 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v373);\n\tv401 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v373);\n\tv425 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v373);\nL_011D:\n\tv201 = v97 < 1;\n\tif (v201) goto L_0184;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob::Execute");
			}

			[Token(Token = "0x6000480")]
			[Address(RVA = "0x3C8AFE4", Offset = "0x3C8AFE4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.IntegrateJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000481")]
			[Address(RVA = "0x3C8B038", Offset = "0x3C8B038", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000482")]
			[Address(RVA = "0x3C8B044", Offset = "0x3C8B044", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000483")]
			[Address(RVA = "0x3C8B050", Offset = "0x3C8B050", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000484")]
			[Address(RVA = "0x3C8B05C", Offset = "0x3C8B05C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000485")]
			[Address(RVA = "0x3C8B068", Offset = "0x3C8B068", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000486")]
			[Address(RVA = "0x3C8B074", Offset = "0x3C8B074", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000487")]
			[Address(RVA = "0x3C8B080", Offset = "0x3C8B080", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000488")]
			[Address(RVA = "0x3C8B08C", Offset = "0x3C8B08C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000489")]
			[Address(RVA = "0x3C8B098", Offset = "0x3C8B098", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600048A")]
			[Address(RVA = "0x3C8B0A4", Offset = "0x3C8B0A4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600048B")]
			[Address(RVA = "0x3C8B0B0", Offset = "0x3C8B0B0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600048C")]
			[Address(RVA = "0x3C8B0BC", Offset = "0x3C8B0BC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600048D")]
			[Address(RVA = "0x3C8B0C8", Offset = "0x3C8B0C8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600048E")]
			[Address(RVA = "0x3C8B0D4", Offset = "0x3C8B0D4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600048F")]
			[Address(RVA = "0x3C8B0E0", Offset = "0x3C8B0E0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000490")]
			[Address(RVA = "0x3C8B0EC", Offset = "0x3C8B0EC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000491")]
			[Address(RVA = "0x3C8B0F8", Offset = "0x3C8B0F8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000492")]
			[Address(RVA = "0x3C8B104", Offset = "0x3C8B104", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000493")]
			[Address(RVA = "0x3C8B110", Offset = "0x3C8B110", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000494")]
			[Address(RVA = "0x3C8B11C", Offset = "0x3C8B11C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000495")]
			[Address(RVA = "0x3C8B128", Offset = "0x3C8B128", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000496")]
			[Address(RVA = "0x3C8B134", Offset = "0x3C8B134", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000497")]
			[Address(RVA = "0x3C8B140", Offset = "0x3C8B140", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000E5")]
		private struct TypeHandle
		{
			[Token(Token = "0x40002EF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public IntegrateJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_IntegratePositionSystem_IntegrateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60004A3")]
			[Address(RVA = "0x3C8B780", Offset = "0x3C8B780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData::Init(this, state, 1);\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x40002DE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x6000476")]
		[Address(RVA = "0x3C8A154", Offset = "0x3C8A154", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0x3C8A1A8", Offset = "0x3C8A1A8", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv43 = *([A4731E0]);\n\tgoto L_002D;\nL_0039:\n\tv89 = Unity.Entities.WorldUnmanaged::get_Time(&v77 @ stack_-C8_v1 (Unity.Entities.WorldUnmanaged));\n\tgoto L_0048;\n\tv122 = v110.Config;\n\tv114 = v110.SDF == 0;\n\tif (v114) goto L_FFFFFFFF;\n\tv117 = _game.CoreSystem.SandPhysics.SDF.SandSDFService::get_IsBuilt(v110.SDF);\n\tv121 = v117 == 0;\n\tif (v121) goto L_FFFFFFFF;\n\tv144 = _game.CoreSystem.SandPhysics.SDF.SandSDFService::GetSDFData(v110.SDF);\n\t*([v106 @ X25_v1]) = v144.values;\nL_FFFFFFFF:\n\tv147 = v110.Config;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv122 = 0;\nL_0075:\n\tv158 = UnityEngine.Object::op_Inequality(v147, 0);\n\tv190 = ~v158;\n\tv191 = ~v190;\n\tif (v191) goto L_0121;\n\tgoto L_0081;\nL_0081:\n\tv352 = UnityEngine.Object::op_Inequality(v147, 0);\n\tv439 = ~v352;\n\tv440 = ~v439;\n\tif (v440) goto L_0133;\n\tgoto L_0092;\nL_0092:\n\tv482 = Unity.Entities.SystemState::get_Dependency(state);\n\tv296 = v89.DeltaTime;\n\tgoto L_00BB;\n\tgoto L_00E7;\n\treturn;\nL_0121:\n\tgoto L_0081;\nL_0133:\n\tgoto L_0092;\nL_0138:\n\tv327 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_002D:\n\tv74 = 0;\n\tv75 = 0;\n\tv77 = state.WorldUnmanaged;\n\tgoto L_0039;\nL_0048:\n\tv106 = &v107 @ stack_-E0;\n\tv110 = v109.<Current>k__BackingField;\n\tv111 = v109.<Current>k__BackingField == 0;\n\tif (v111) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv147 = v122;\nL_006D:\n\t*([v106 @ X25_v1+20]) = *([v106 @ X25_v1]);\n\tgoto L_0075;\nL_00BB:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tv512 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v512, state);\n\tv517 = this + 0x50;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v517, state);\nL_00E7:\n\tv539 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v296 @ stack_-198_v1 (_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_IntegratePositionSystem_IntegrateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v482);\n\tUnity.Entities.SystemState::set_Dependency(state, v539);\n\tv543 = *([A4731E0]);\n\tv231 = *([v543 @ X9_v2]) != *([v43 @ X8_v2]);\n\tif (v231) goto L_0138;\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000478")]
		[Address(RVA = "0x3C8A57C", Offset = "0x3C8A57C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tgoto L_0047;\nL_002F:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tv72 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v72, state);\n\tv79 = this + 0x50;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v79, state);\nL_0047:\n\tv94 = job + 0x40;\n\tv97 = 0x8BF6A34(v94, this, 0x78, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(IntegrateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000479")]
		[Address(RVA = "0x3C8A74C", Offset = "0x3C8A74C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x600047A")]
		[Address(RVA = "0x3C8A790", Offset = "0x3C8A790", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData::Init(this, state, 1);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("IntegratePositionSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600047B")]
		[Address(RVA = "0x3C8A098", Offset = "0x3C8A098", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600047C")]
		[Address(RVA = "0x3C8A0EC", Offset = "0x3C8A0EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((IntegratePositionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600047D")]
		[Address(RVA = "0x3C8A0F0", Offset = "0x3C8A0F0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\t_game.CoreSystem.SandPhysics.Systems.IntegratePositionSystem+IntegrateJob+InternalCompilerQueryAndHandleData::Init(self, state, 1);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			((IntegrateJob.InternalCompilerQueryAndHandleData*)self)->Init(ref *(SystemState*)state, assignDefaultQuery: true);
		}
	}
}
