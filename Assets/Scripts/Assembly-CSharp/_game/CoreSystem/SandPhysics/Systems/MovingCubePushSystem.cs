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

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(WallCollisionSystem))]
	[UpdateBefore(typeof(BoundsCheckSystem))]
	[Token(Token = "0x20000E6")]
	public struct MovingCubePushSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000E7")]
		private struct MovingCubePushJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000E8")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000E9")]
				public struct TypeHandle
				{
					[Token(Token = "0x40002F8")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x40002F9")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x40002FA")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[Token(Token = "0x40002FB")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x60004CF")]
					[Address(RVA = "0x3C8CE54", Offset = "0x3C8CE54", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x60004D0")]
					[Address(RVA = "0x3C8BBE8", Offset = "0x3C8BBE8", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x40002F6")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002F7")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004C7")]
				[Address(RVA = "0x3C8C86C", Offset = "0x3C8C86C", Length = "0x2A8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = v78;\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v86;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v93;\n\tv98 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v98;\n\tv103 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v103;\n\tv109 = Unity.Entities.EntityQueryBuilder::Build(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v109;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv112 = Unity.Entities.EntityQueryBuilder::Reset(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002F:\n\tv62 = 0;\n\tv66 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v66);\n\tv78 = Unity.Entities.EntityQueryBuilder::WithAll(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
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
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<ParticleSettleCounter>();
					entityQueryBuilder3 = entityQueryBuilder7;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x60004C8")]
				[Address(RVA = "0x3C8CB14", Offset = "0x3C8CB14", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C8C9C0(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004C9")]
				[Address(RVA = "0x3C8CC90", Offset = "0x3C8CC90", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x20;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref MovingCubePushJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004CA")]
				[Address(RVA = "0x3C8CD10", Offset = "0x3C8CD10", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x20;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref MovingCubePushJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004CB")]
				[Address(RVA = "0x3C8CDA8", Offset = "0x3C8CDA8", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x20;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref MovingCubePushJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004CC")]
				[Address(RVA = "0x3C8CE40", Offset = "0x3C8CE40", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref MovingCubePushJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004CD")]
				[Address(RVA = "0x3C8CE44", Offset = "0x3C8CE44", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref MovingCubePushJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60004CE")]
				[Address(RVA = "0x3C8CE50", Offset = "0x3C8CE50", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref MovingCubePushJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000EA")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x60004D1")]
				[Address(RVA = "0x3C8CF98", Offset = "0x3C8CF98", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			[Token(Token = "0x40002F1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<MovingCubeData> movingCubes;

			[Token(Token = "0x40002F2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public float particleRadius;

			[Token(Token = "0x40002F3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			public float pushStrength;

			[Token(Token = "0x40002F4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public float dt;

			[Token(Token = "0x40002F5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x60004AC")]
			[Address(RVA = "0x3C8BD78", Offset = "0x3C8BD78", Length = "0x23C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv76 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(state);\n\tv186 = v76 == 0;\n\tv162 = ~v186;\n\tif (v162) goto L_00FB;\n\tv123 = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob)+8]) < 1;\n\tif (v123) goto L_00FB;\nL_FFFFFFFF:\n\tv207 = 0;\n\tgoto L_0064;\nL_0048:\n\tv207 = v207 + 1;\n\tv124 = v207 >= *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob)+8]);\n\tif (v124) goto L_00FB;\nL_0064:\n\t// 100 MakeStruct v89 @ AGG3C8BE6C_0_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\tv234 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::ObbCircleOverlap(v89, this.particleRadius, &v106 @ stack_-B0_v4 (_game.CoreSystem.SandPhysics.MovingCubeData), &v95 @ stack_-B8_v4 (Unity.Mathematics.float2), &v91 @ stack_-BC_v4 (System.Single));\n\tv235 = ~v234;\n\tif (v235) goto L_0048;\n\tv238 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(state);\n\tv273 = ~v238;\n\tif (v273) goto L_007D;\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsSettled(state, 0);\n\tcounter.framesBelowThreshold = 1.4044470919183048E+306d;\n\tcounter.anchorPosition.y = 3.4028235E+38f;\n\tv309 = v106 - v308;\n\t// 147 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv242 = v309 / this.dt;\n\tgoto L_00A2;\nL_00A4:\n\tv340 = v242 * v242;\n\t// 165 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv341 = UnityEngine.Mathf::Sqrt(v340);\n\tv246 = this.pushStrength;\n\tv271 = this.pushStrength & 0x7FFFFFFF;\n\tv344 = v271 < 0x7F800000;\n\tv345 = ~v344;\n\tv346 = v271 - 0x7F800000;\n\tv348 = v346 == 0;\n\tv351 = ~v345;\n\tv352 = v351 | v348;\n\tv353 = ~v352;\n\tif (v353) goto L_FFFFFFFF;\n\tv369 = v341 < this.pushStrength;\n\tv368 = v341 == this.pushStrength;\n\tv358 = v341 == v341;\n\tv359 = this.pushStrength == this.pushStrength;\n\tv360 = v358 & v359;\n\tv366 = ~v360;\n\tgoto L_00C5;\nL_FFFFFFFF:\n\tv366 = 0;\nL_FFFFFFFF:\n\tv368 = 0;\nL_FFFFFFFF:\n\tv369 = 0;\nL_FFFFFFFF:\n\tv246 = v341;\n\tgoto L_00CF;\n\tv245 = v95 * v379;\n\tv247 = vel.value + v245;\n\tvel.value = v247;\n\tgoto L_0048;\nL_00E8:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv242 = v318.zero;\n\tgoto L_00A2;\nL_00FB:\n\treturn;\nL_0026:\n\tv70 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(state);\n\tv72 = v70 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_00FB;\nL_007D:\n\tv288 = v95 * v289;\n\tv290 = pos.value + v288;\n\tpos.value = v290;\n\tv295 = this.dt < 0x358637BD;\n\tv296 = this.dt == 0x358637BD;\n\tv299 = this.dt == this.dt;\n\tv302 = ~v299;\n\tv303 = v295 == v302;\n\tv304 = ~v303;\n\tv305 = v304 | v296;\n\tif (v305) goto L_00E8;\nL_00A2:\n\tgoto L_00A4;\nL_00C5:\n\tv372 = v369 == v366;\n\tv239 = ~v368;\n\tv373 = v372 & v239;\n\tv241 = ~v373;\n\tif (v241) goto L_00CF;\nL_00CF:\n\tv244 = v95 * vel.value;\n\t// 208 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv262 = v244 < v246;\n\tv250 = ~v262;\n\tif (v250) goto L_0048;\n")]
			private void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState state, ref ParticleSettleCounter counter)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob::Execute");
			}

			[Token(Token = "0x60004AD")]
			[Address(RVA = "0x3C8BFB4", Offset = "0x3C8BFB4", Length = "0x24C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv108 = v80 == cube.halfSize;\n\tv94 = v80 < cube.halfSize;\n\tv107 = ~v94;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv107 = 1;\nL_FFFFFFFF:\n\tv108 = 0;\n\tv112 = -cube.halfSize;\n\t// 84 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 85 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 87 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 88 NotImplemented \"Instruction CMHI not yet implemented.\"\n\tv114 = v74 | v54;\n\t// 90 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 91 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 92 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 93 NotImplemented \"Instruction CMHI not yet implemented.\"\n\t// 94 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\tv115 = v54 | v114;\n\t// 96 NotImplemented \"Instruction BIF not yet implemented.\"\n\tv116 = v73 - v112;\n\t// 99 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv118 = r * r;\n\tv119 = circleCenter < v118;\n\tv123 = circleCenter == circleCenter;\n\tv124 = v118 == v118;\n\tv125 = v123 & v124;\n\tv126 = ~v125;\n\tv130 = v119 == v126;\n\tv131 = ~v130;\n\tv132 = ~v131;\n\tif (v132) goto L_FFFFFFFF;\n\tv186 = circleCenter < 0x2B8CBCCC;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv186 = 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_011C;\nL_0086:\n\tv296 = cube.halfSize - v54;\n\tv134 = cube.halfSize - v80;\n\tv135 = v296 < v134;\n\tv143 = ~v135;\n\tif (v143) goto L_00CE;\n\tv156 = v73 < 0;\n\tv157 = v73 == 0;\n\tv160 = v73 == v73;\n\tv161 = ~v160;\n\tv164 = v156 == v161;\n\tv165 = ~v157;\n\tv166 = v164 & v165;\n\tv167 = ~v166;\n\tif (v167) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv200 = 1f;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\tv200 = 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv332 = v200;\nL_00B3:\n\tgoto L_00BD;\nL_00BF:\n\tv281 = UnityEngine.Mathf::Sqrt(circleCenter);\n\t// 194 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv287 = v116 / v115;\n\tv288 = v287 * v72;\n\t// 197 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv289 = v287 * v70;\n\tv290 = v289 - v288;\n\tpushNormal.x = v290;\n\tv214 = r - v281;\n\tgoto L_010D;\nL_00CE:\n\tv169 = v77 < 0;\n\tv170 = v77 == 0;\n\tv173 = v77 == v77;\n\tv174 = ~v173;\n\tv177 = v169 == v174;\n\tv178 = ~v170;\n\tv179 = v177 & v178;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv329 = 1f;\n\tgoto L_00E0;\nL_FFFFFFFF:\n\tv329 = 0;\nL_FFFFFFFF:\n\tv329 = v206;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv332 = 0;\n\tgoto L_00FF;\nL_FFFFFFFF:\n\tv329 = 1f;\n\tgoto L_0105;\nL_0025:\n\tpushNormal.x = v62.zero;\n\t*([penetration @ X2 (System.Single&)]) = 0;\n\tv69 = cube.cosAngle * v70;\n\t// 45 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv71 = cube.cosAngle * v72;\n\tv73 = v69 + v71;\n\tv74 = v69 - v71;\n\t// 52 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv82 = v54 == cube.halfSize;\n\tv83 = v54 < cube.halfSize;\n\tv84 = ~v83;\n\tv89 = ~v84;\n\tv90 = v89 | v82;\n\tv91 = ~v90;\n\tif (v91) goto L_FFFFFFFF;\nL_0050:\n\tv110 = ~v107;\n\tv111 = v110 | v108;\n\tif (v111) goto L_0086;\nL_0082:\n\tv187 = ~v186;\n\tif (v187) goto L_00B3;\nL_011C:\n\treturn returnVal1;\nL_00A4:\n\tv332 = v200 + -1f;\n\tv203 = ~v156;\n\tif (v203) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv329 = 0;\n\tgoto L_00E8;\nL_00BD:\n\tgoto L_00BF;\nL_010D:\n\t*([penetration @ X2 (System.Single&)]) = v214;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_00E0:\n\tv206 = v329 + -1f;\n\tv207 = ~v169;\n\tif (v207) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv296 = v134;\nL_FFFFFFFF:\n\tv332 = 0;\nL_00FF:\n\tv324 = ~v313;\n\tif (v324) goto L_0105;\nL_0105:\n\tv336 = v332 * cube.cosAngle;\n\tv326 = v329 * v337;\n\tv323 = v336 - v326;\n\tv325 = v332 * v337;\n\tv338 = v329 * cube.cosAngle;\n\tv327 = v325 + v338;\n\tpushNormal.x = v323;\n\tpushNormal.y = v327;\nL_00E8:\n\tv214 = v296 + r;\n\tv307 = v332 * v332;\n\tv308 = v329 * v329;\n\tv309 = v307 + v308;\n\tv313 = v309 < 0x3DCCCCCD;\n\tv322 = ~v313;\n\tif (v322) goto L_00FF;\n")]
			private static bool ObbCircleOverlap(float2 circleCenter, float r, in MovingCubeData cube, out float2 pushNormal, out float penetration)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob::ObbCircleOverlap");
				pushNormal = default;
				penetration = default;
				return default;
			}

			[CompilerGenerated]
			[Token(Token = "0x60004AE")]
			[Address(RVA = "0x3C8C200", Offset = "0x3C8C200", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0x98;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00EC;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v60 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_011F;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = 0;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = v517;\n\tv452 = ~v443;\n\tv454 = ~v420;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v195 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v452, v454);\n\tv288 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v195);\n\tv293 = v288 == 0;\n\tif (v293) goto L_01B4;\n\tv541 = v420 + v297;\n\tv517 = v288 + v541;\n\tv527 = v541 >= v517;\nL_FFFFFFFF:\n\tv579 = v288;\n\tif (v527) goto L_FFFFFFFF;\nL_00B3:\n\t;\n\tv584 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v541);\n\tv617 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v541);\n\tv640 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v541);\n\tv652 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v541);\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::Execute(this, v584, v617, v640, v652);\n\tv541 = v541 + 1;\n\tv580 = v579 - 1;\n\tv546 = v579 != 1;\nL_FFFFFFFF:\n\tv579 = v580;\n\tif (v546) goto L_00B3;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01B4;\nL_FFFFFFFF:\n\tv385 = 0;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v385);\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::Execute(this, v403, v426, v449, v488);\n\tv385 = v385 + 1;\n\tv218 = v109 != v385;\n\tif (v218) goto L_00FA;\n\tgoto L_01B4;\nL_011F:\n\tv156 = v109 - 0x40;\n\tv157 = v156 < 0;\n\tv159 = v109 ^ 0x40;\n\tv160 = v109 ^ v156;\n\tv161 = v159 & v160;\n\tv162 = v161 < 0;\n\tv164 = v157 == v162;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = v109;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv298 = 0x40;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv483 = 0;\n\tgoto L_014C;\nL_0140:\n\tv302 = v302 >> 1;\n\tv483 = v483 + 1;\n\tv469 = v298 == v483;\n\tif (v469) goto L_017B;\nL_014C:\n\tv484 = v302 & 1;\n\tv294 = v484 == 0;\n\tif (v294) goto L_0140;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v483);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v483);\n\tv533 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v483);\n\tv592 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v483);\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::Execute(this, v495, v511, v533, v592);\n\tgoto L_0140;\nL_017B:\n\tv219 = v109 < 0x41;\n\tif (v219) goto L_01B4;\n\tv535 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv596 = 0x40;\n\tgoto L_018D;\nL_0181:\n\tv299 = v535 >> 1;\n\tv596 = v596 + 1;\n\tv249 = v109 == v596;\nL_FFFFFFFF:\n\tv535 = v299;\n\tif (v249) goto L_01B4;\nL_018D:\n\tv613 = v535 & 1;\n\tv295 = v613 == 0;\n\tif (v295) goto L_0181;\n\tv623 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v596);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v596);\n\tv658 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v596);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v596);\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::Execute(this, v623, v646, v658, v663);\n\tgoto L_0181;\nL_01B4:\n\tv324 = *([A4731E0]);\n\tv335 = *([v324 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v335) goto L_01CF;\n\treturn;\nL_01CF:\n\tv416 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x20;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0x48;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0x70;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v92);\nL_0080:\n\tv375 = v271;\n\tv379 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v297);\n\tv375 = v379;\n\tv420 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v379);\n\tv443 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v420);\nL_00FA:\n\tv403 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v385);\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v385);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v385);\nL_0139:\n\tv220 = v109 < 1;\n\tif (v220) goto L_01B4;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob::Execute");
			}

			[Token(Token = "0x60004AF")]
			[Address(RVA = "0x3C8C70C", Offset = "0x3C8C70C", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem.MovingCubePushJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x60004B0")]
			[Address(RVA = "0x3C8C760", Offset = "0x3C8C760", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B1")]
			[Address(RVA = "0x3C8C76C", Offset = "0x3C8C76C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B2")]
			[Address(RVA = "0x3C8C778", Offset = "0x3C8C778", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B3")]
			[Address(RVA = "0x3C8C784", Offset = "0x3C8C784", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B4")]
			[Address(RVA = "0x3C8C790", Offset = "0x3C8C790", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B5")]
			[Address(RVA = "0x3C8C79C", Offset = "0x3C8C79C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B6")]
			[Address(RVA = "0x3C8C7A8", Offset = "0x3C8C7A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B7")]
			[Address(RVA = "0x3C8C7B4", Offset = "0x3C8C7B4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B8")]
			[Address(RVA = "0x3C8C7C0", Offset = "0x3C8C7C0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004B9")]
			[Address(RVA = "0x3C8C7CC", Offset = "0x3C8C7CC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BA")]
			[Address(RVA = "0x3C8C7D8", Offset = "0x3C8C7D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BB")]
			[Address(RVA = "0x3C8C7E4", Offset = "0x3C8C7E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BC")]
			[Address(RVA = "0x3C8C7F0", Offset = "0x3C8C7F0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BD")]
			[Address(RVA = "0x3C8C7FC", Offset = "0x3C8C7FC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BE")]
			[Address(RVA = "0x3C8C808", Offset = "0x3C8C808", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004BF")]
			[Address(RVA = "0x3C8C814", Offset = "0x3C8C814", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C0")]
			[Address(RVA = "0x3C8C820", Offset = "0x3C8C820", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C1")]
			[Address(RVA = "0x3C8C82C", Offset = "0x3C8C82C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C2")]
			[Address(RVA = "0x3C8C838", Offset = "0x3C8C838", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C3")]
			[Address(RVA = "0x3C8C844", Offset = "0x3C8C844", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C4")]
			[Address(RVA = "0x3C8C850", Offset = "0x3C8C850", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C5")]
			[Address(RVA = "0x3C8C85C", Offset = "0x3C8C85C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60004C6")]
			[Address(RVA = "0x3C8C868", Offset = "0x3C8C868", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000EB")]
		private struct TypeHandle
		{
			[Token(Token = "0x40002FC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public MovingCubePushJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_MovingCubePushSystem_MovingCubePushJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60004D2")]
			[Address(RVA = "0x3C8CF9C", Offset = "0x3C8CF9C", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x3C8C9C0(this, state, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv36 = 0x3C8CB4C(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8C9C0 (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8CB4C (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::Init +0x38)");
			}
		}

		[Token(Token = "0x40002F0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0x3C8B854", Offset = "0x3C8B854", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0x3C8B8A8", Offset = "0x3C8B8A8", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = *([B78D76E]) & 1;\n\tv37 = v36 == 0;\n\tif (v37) goto L_0035;\n\tv63 = 0xB293000 + 0xDC8;\n\tv42 = *([B193A9A]) & 1;\n\tv43 = v42 == 0;\n\tv77 = v63;\n\tif (v43) goto L_0042;\nL_001E:\n\tv71 = *([v63 @ X22_v9 (System.Int32)]);\n\tv72 = *([v71 @ X8_v31+B8]);\n\tv88 = *([v72 @ X8_v32]);\n\tv74 = *([v72 @ X8_v32]) == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_004E;\n\tgoto L_00DD;\nL_0035:\n\t*([B19376E]) = 1;\n\tv63 = 0xB293000 + 0xDC8;\n\tv295 = *([B193A9A]) & 1;\n\tv296 = v295 == 0;\n\tv66 = ~v296;\n\tv77 = v63;\n\tif (v66) goto L_001E;\nL_0042:\n\t*([B193A9A]) = 1;\n\tv102 = *([v77 @ X22_v5 (System.Int32)]);\n\tv93 = *([v102 @ X8_v26+B8]);\n\tv88 = *([v93 @ X8_v27]);\n\tv91 = *([v93 @ X8_v27]) == 0;\n\tif (v91) goto L_00DD;\nL_004E:\n\tgoto L_0052;\nL_0052:\n\tv196 = UnityEngine.Object::op_Equality(*([v88 @ X22_v3+48]), 0);\n\tv204 = v196 == 0;\n\tif (v204) goto L_0060;\n\tgoto L_00DD;\nL_0060:\n\tv210 = *([v88 @ X22_v3+18]);\n\tv214 = *([v210 @ X8_v7+10]);\n\tv182 = *([v210 @ X8_v7+10]);\n\tv206 = *([v210 @ X8_v7+10]) == 0;\n\tif (v206) goto L_00DD;\n\tgoto L_0073;\nL_0073:\n\tv207 = *([v214 @ X21_v7 (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>)+8]) == 0;\n\tif (v207) goto L_00DD;\n\tv177 = state.WorldUnmanaged;\n\tgoto L_0083;\nL_0083:\n\tv324 = Unity.Entities.WorldUnmanaged::get_Time(&v177 @ stack_-80_v3 (Unity.Entities.WorldUnmanaged));\n\tv299 = Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>::AsArray(&v182 @ stack_-78_v3 (Unity.Collections.NativeList`1<_game.CoreSystem.SandPhysics.MovingCubeData>));\n\tv331 = Unity.Entities.SystemState::get_Dependency(state);\n\tv162 = v299;\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_00C6;\nL_00DD:\n\treturn;\nL_00C6:\n\tv355 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v162 @ stack_-140_v2 (_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_MovingCubePushSystem_MovingCubePushJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v331);\n\tUnity.Entities.SystemState::set_Dependency(state, v355);\n")]
		public void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004A6")]
		[Address(RVA = "0x3C8BB48", Offset = "0x3C8BB48", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(this, state);\n\tgoto L_0023;\nL_0023:\n\tv58 = job + 0x20;\n\tv61 = 0x8BF6A34(v58, this, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(MovingCubePushJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MovingCubePushSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004A7")]
		[Address(RVA = "0x3C8BCC0", Offset = "0x3C8BCC0", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0x3C8BD04", Offset = "0x3C8BD04", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C8C9C0(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C8CB4C(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8C9C0 (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8CB4C (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004A9")]
		[Address(RVA = "0x3C8B788", Offset = "0x3C8B788", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004AA")]
		[Address(RVA = "0x3C8B7DC", Offset = "0x3C8B7DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((MovingCubePushSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004AB")]
		[Address(RVA = "0x3C8B7E0", Offset = "0x3C8B7E0", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv27 = 0x3C8C9C0(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = 0x3C8CB4C(self, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8C9C0 (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8CB4C (inside _game.CoreSystem.SandPhysics.Systems.MovingCubePushSystem+MovingCubePushJob+InternalCompilerQueryAndHandleData::Init +0x38)");
		}
	}
}
