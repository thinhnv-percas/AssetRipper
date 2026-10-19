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

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(SettleDetectionSystem))]
	[UpdateBefore(typeof(SyncTransformSystem))]
	[Token(Token = "0x20000D0")]
	public struct GateFreezeSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000D1")]
		private struct WakeUpFrozenJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000D2")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000D3")]
				public struct TypeHandle
				{
					[ReadOnly]
					[Token(Token = "0x40002B5")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[Token(Token = "0x40002B6")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x40002B7")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[Token(Token = "0x40002B8")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x600041F")]
					[Address(RVA = "0x3C87A28", Offset = "0x3C87A28", Length = "0x144")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = *([v97 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v97 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v97 @ X8_v7+20]);\n\tv122 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle = v122.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = v122.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = v122.m_Length;\n\treturn;\nL_002E:\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v70;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = v62;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v72;\n\tv75 = &v83 @ stack_-A0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v75 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v75 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v75 @ X8_v5+20]);\n\tv97 = &v104 @ stack_-C8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv101 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000420")]
					[Address(RVA = "0x3C86994", Offset = "0x3C86994", Length = "0xD8")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\treturn;\nL_002D:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x40002B3")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002B4")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000417")]
				[Address(RVA = "0x3C87440", Offset = "0x3C87440", Length = "0x2A8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = v78;\n\tv86 = Unity.Entities.EntityQueryBuilder::WithAll(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v86;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v93;\n\tv98 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v98;\n\tv103 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv82 = v103;\n\tv109 = Unity.Entities.EntityQueryBuilder::Build(&v82 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v109;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+A8]) = state;\n\tv112 = Unity.Entities.EntityQueryBuilder::Reset(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002F:\n\tv62 = 0;\n\tv66 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v66);\n\tv78 = Unity.Entities.EntityQueryBuilder::WithAll(&v62 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<SandParticle>();
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

				[Token(Token = "0x6000418")]
				[Address(RVA = "0x3C876E8", Offset = "0x3C876E8", Length = "0x17C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C87594(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0020:\n\tv69 = &v70 @ stack_-10_v3;\n\tgoto L_0043;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+50]) = *([v127 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+60]) = *([v127 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+70]) = *([v127 @ X8_v7+20]);\n\tv152 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+78]) = v152.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+88]) = v152.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+98]) = v152.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0020;\nL_0043:\n\tv97 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 1);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+20]) = *([v69 @ X29_v2-48]);\n\tv35.__TypeHandle = *([v69 @ X29_v2-68]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+10]) = *([v69 @ X29_v2-58]);\n\tv105 = &v106 @ stack_-A0;\n\tv109 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+28]) = *([v105 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+38]) = *([v105 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData)+48]) = *([v105 @ X8_v5+20]);\n\tv127 = &v128 @ stack_-C8;\n\tv131 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000419")]
				[Address(RVA = "0x3C87864", Offset = "0x3C87864", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x18;\n\tv54 = 0x8BF6A34(v51, this, 0xA0, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref WakeUpFrozenJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600041A")]
				[Address(RVA = "0x3C878E4", Offset = "0x3C878E4", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x18;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref WakeUpFrozenJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600041B")]
				[Address(RVA = "0x3C8797C", Offset = "0x3C8797C", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x18;\n\tv60 = 0x8BF6A34(v57, this, 0xA0, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref WakeUpFrozenJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600041C")]
				[Address(RVA = "0x3C87A14", Offset = "0x3C87A14", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref WakeUpFrozenJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600041D")]
				[Address(RVA = "0x3C87A18", Offset = "0x3C87A18", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref WakeUpFrozenJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600041E")]
				[Address(RVA = "0x3C87A24", Offset = "0x3C87A24", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref WakeUpFrozenJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000D4")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000421")]
				[Address(RVA = "0x3C87B6C", Offset = "0x3C87B6C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x40002AD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float freezeTop;

			[Token(Token = "0x40002AE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float freezeBottom;

			[Token(Token = "0x40002AF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float gateXMin;

			[Token(Token = "0x40002B0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public float gateXMax;

			[Token(Token = "0x40002B1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public float2 kickVel;

			[Token(Token = "0x40002B2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x3C86D04", Offset = "0x3C86D04", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(pState);\n\tv32 = v30 == 0;\n\tv33 = ~v32;\n\tif (v33) goto L_0068;\n\tv36 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(pState);\n\tv115 = v36 == 0;\n\tv99 = ~v115;\n\tif (v99) goto L_0068;\n\tv105 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsVacuumReserved(pState);\n\tv118 = v105 == 0;\n\tv98 = ~v118;\n\tif (v98) goto L_0068;\n\tv83 = pos.value.y < this.freezeTop;\n\tv77 = pos.value.y == this.freezeTop;\n\tv120 = pos.value.y == pos.value.y;\n\tv59 = this.freezeTop == this.freezeTop;\n\tv65 = v120 & v59;\n\tv53 = ~v65;\n\tv121 = v83 == v53;\n\tv45 = ~v77;\n\tv49 = v121 & v45;\n\tif (v49) goto L_0068;\n\tv84 = pos.value.y < this.freezeBottom;\n\tif (v84) goto L_0068;\n\tv85 = pos.value < this.gateXMin;\n\tif (v85) goto L_0068;\n\tv81 = pos.value < this.gateXMax;\n\tv75 = pos.value == this.gateXMax;\n\tv127 = pos.value == pos.value;\n\tv57 = this.gateXMax == this.gateXMax;\n\tv63 = v127 & v57;\n\tv51 = ~v63;\n\tv128 = v81 == v51;\n\tv43 = ~v75;\n\tv47 = v128 & v43;\n\tif (v47) goto L_0068;\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsSettled(pState, 0);\n\tvel.value = this.kickVel;\n\tcounter.framesBelowThreshold = 1.4044470919183048E+306d;\n\tcounter.anchorPosition.y = 3.4028235E+38f;\nL_0068:\n\treturn;\n")]
			private void Execute(in ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState pState, ref ParticleSettleCounter counter)
			{
				//IL_029a: Expected I4, but got F8
				if (pState.IsExited || pState.IsAbsorbing || pState.IsVacuumReserved)
				{
					return;
				}
				bool flag = pos.value.y < freezeTop;
				bool flag2 = pos.value.y == freezeTop;
				bool flag3 = pos.value.y == pos.value.y;
				bool flag4 = freezeTop == freezeTop;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if (!(flag7 && flag8) && !(pos.value.y < freezeBottom) && !(pos.value.x < gateXMin))
				{
					bool flag9 = pos.value.x < gateXMax;
					bool flag10 = pos.value.x == gateXMax;
					bool flag11 = pos.value.x == pos.value.x;
					bool flag12 = gateXMax == gateXMax;
					bool flag13 = flag11 && flag12;
					bool flag14 = !flag13;
					bool flag15 = flag9 == flag14;
					bool flag16 = !flag10;
					if (!(flag15 && flag16))
					{
						pState.IsSettled = false;
						vel.value = kickVel;
						counter.framesBelowThreshold = 2147483647;
						counter.anchorPosition.y = 3.4028235E+38f;
					}
				}
			}

			[CompilerGenerated]
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0x3C86DD4", Offset = "0x3C86DD4", Length = "0x50C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0042;\n\tv101 = this + 0x90;\n\tv102 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v101);\n\tv109 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv115 = useEnabledMask == 0;\n\tif (v115) goto L_00EC;\n\tv121 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv122 = v121 ^ chunkEnabledMask.Byte0;\n\t// 98 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 99 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 100 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 101 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 102 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 103 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv123 = v60 + v122;\n\tv125 = v123 < 5;\n\tv126 = ~v125;\n\tv127 = v123 - 5;\n\tv129 = v127 == 0;\n\tv134 = ~v129;\n\tv135 = v126 & v134;\n\tif (v135) goto L_011F;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = 0;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv271 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv297 = v517;\n\tv452 = ~v443;\n\tv454 = ~v420;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v195 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v452, v454);\n\tv288 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v195);\n\tv293 = v288 == 0;\n\tif (v293) goto L_01B4;\n\tv541 = v420 + v297;\n\tv517 = v288 + v541;\n\tv527 = v541 >= v517;\nL_FFFFFFFF:\n\tv579 = v288;\n\tif (v527) goto L_FFFFFFFF;\nL_00B3:\n\t;\n\tv584 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v541);\n\tv617 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v541);\n\tv640 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v541);\n\tv652 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v541);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::Execute(this, v584, v617, v640, v652);\n\tv541 = v541 + 1;\n\tv580 = v579 - 1;\n\tv546 = v579 != 1;\nL_FFFFFFFF:\n\tv579 = v580;\n\tif (v546) goto L_00B3;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00EC:\n\tv146 = v109 < 1;\n\tif (v146) goto L_01B4;\nL_FFFFFFFF:\n\tv385 = 0;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v385);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::Execute(this, v403, v426, v449, v488);\n\tv385 = v385 + 1;\n\tv218 = v109 != v385;\n\tif (v218) goto L_00FA;\n\tgoto L_01B4;\nL_011F:\n\tv156 = v109 - 0x40;\n\tv157 = v156 < 0;\n\tv159 = v109 ^ 0x40;\n\tv160 = v109 ^ v156;\n\tv161 = v159 & v160;\n\tv162 = v161 < 0;\n\tv164 = v157 == v162;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv298 = v109;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv298 = 0x40;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv483 = 0;\n\tgoto L_014C;\nL_0140:\n\tv302 = v302 >> 1;\n\tv483 = v483 + 1;\n\tv469 = v298 == v483;\n\tif (v469) goto L_017B;\nL_014C:\n\tv484 = v302 & 1;\n\tv294 = v484 == 0;\n\tif (v294) goto L_0140;\n\tv495 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v483);\n\tv511 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v483);\n\tv533 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v483);\n\tv592 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v483);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::Execute(this, v495, v511, v533, v592);\n\tgoto L_0140;\nL_017B:\n\tv219 = v109 < 0x41;\n\tif (v219) goto L_01B4;\n\tv535 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv596 = 0x40;\n\tgoto L_018D;\nL_0181:\n\tv299 = v535 >> 1;\n\tv596 = v596 + 1;\n\tv249 = v109 == v596;\nL_FFFFFFFF:\n\tv535 = v299;\n\tif (v249) goto L_01B4;\nL_018D:\n\tv613 = v535 & 1;\n\tv295 = v613 == 0;\n\tif (v295) goto L_0181;\n\tv623 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v596);\n\tv646 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v596);\n\tv658 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v596);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v102, v596);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::Execute(this, v623, v646, v658, v663);\n\tgoto L_0181;\nL_01B4:\n\tv324 = *([A4731E0]);\n\tv335 = *([v324 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v335) goto L_01CF;\n\treturn;\nL_01CF:\n\tv416 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0042:\n\tv74 = this + 0x18;\n\tv75 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v74);\n\tv83 = this + 0x40;\n\tv84 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v83);\n\tv92 = this + 0x68;\n\tv93 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v92);\nL_0080:\n\tv375 = v271;\n\tv379 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v297);\n\tv375 = v379;\n\tv420 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v379);\n\tv443 = Unity.Entities.EnabledBitUtility::ShiftRight(&v375 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v420);\nL_00FA:\n\tv403 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v75, v385);\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v84, v385);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v93, v385);\nL_0139:\n\tv220 = v109 < 1;\n\tif (v220) goto L_01B4;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob::Execute");
			}

			[Token(Token = "0x60003FF")]
			[Address(RVA = "0x3C872E0", Offset = "0x3C872E0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.WakeUpFrozenJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000400")]
			[Address(RVA = "0x3C87334", Offset = "0x3C87334", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000401")]
			[Address(RVA = "0x3C87340", Offset = "0x3C87340", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000402")]
			[Address(RVA = "0x3C8734C", Offset = "0x3C8734C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000403")]
			[Address(RVA = "0x3C87358", Offset = "0x3C87358", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000404")]
			[Address(RVA = "0x3C87364", Offset = "0x3C87364", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000405")]
			[Address(RVA = "0x3C87370", Offset = "0x3C87370", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000406")]
			[Address(RVA = "0x3C8737C", Offset = "0x3C8737C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000407")]
			[Address(RVA = "0x3C87388", Offset = "0x3C87388", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000408")]
			[Address(RVA = "0x3C87394", Offset = "0x3C87394", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000409")]
			[Address(RVA = "0x3C873A0", Offset = "0x3C873A0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600040A")]
			[Address(RVA = "0x3C873AC", Offset = "0x3C873AC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600040B")]
			[Address(RVA = "0x3C873B8", Offset = "0x3C873B8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600040C")]
			[Address(RVA = "0x3C873C4", Offset = "0x3C873C4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600040D")]
			[Address(RVA = "0x3C873D0", Offset = "0x3C873D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600040E")]
			[Address(RVA = "0x3C873DC", Offset = "0x3C873DC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600040F")]
			[Address(RVA = "0x3C873E8", Offset = "0x3C873E8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000410")]
			[Address(RVA = "0x3C873F4", Offset = "0x3C873F4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000411")]
			[Address(RVA = "0x3C87400", Offset = "0x3C87400", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000412")]
			[Address(RVA = "0x3C8740C", Offset = "0x3C8740C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000413")]
			[Address(RVA = "0x3C87418", Offset = "0x3C87418", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000414")]
			[Address(RVA = "0x3C87424", Offset = "0x3C87424", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000415")]
			[Address(RVA = "0x3C87430", Offset = "0x3C87430", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000416")]
			[Address(RVA = "0x3C8743C", Offset = "0x3C8743C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000D5")]
		private struct FreezeGateJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000D6")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000D7")]
				public struct TypeHandle
				{
					[Token(Token = "0x40002C1")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x40002C2")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x40002C3")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x6000444")]
					[Address(RVA = "0x3C88744", Offset = "0x3C88744", Length = "0x100")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = v102.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = v102.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = v102.m_Length;\n\treturn;\nL_0024:\n\tv55 = &v63 @ stack_-68_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv59 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = *([v55 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = *([v55 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v55 @ X8_v3+10]);\n\tv77 = &v84 @ stack_-90_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv81 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v77 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v77 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v77 @ X8_v5+20]);\n\tv102 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x6000445")]
					[Address(RVA = "0x3C86B90", Offset = "0x3C86B90", Length = "0xAC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\treturn;\nL_0026:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x40002BF")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002C0")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600043C")]
				[Address(RVA = "0x3C8820C", Offset = "0x3C8820C", Length = "0x260")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv79 = v76;\n\tv83 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v83;\n\tv88 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v88;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v93;\n\tv99 = Unity.Entities.EntityQueryBuilder::Build(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v99;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+80]) = state;\n\tv102 = Unity.Entities.EntityQueryBuilder::Reset(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002A:\n\tv60 = 0;\n\tv64 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v64);\n\tv76 = Unity.Entities.EntityQueryBuilder::WithAll(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
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
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x600043D")]
				[Address(RVA = "0x3C8846C", Offset = "0x3C8846C", Length = "0x114")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = ~assignDefaultQuery;\n\tif (v22) goto L_001D;\n\tv27 = 0x3C8833C(this, state, 0, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tgoto L_002A;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+50]) = v110.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+60]) = v110.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+70]) = v110.m_Length;\n\treturn;\nL_002A:\n\tv63 = &v71 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData+TypeHandle);\n\tv67 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+20]) = *([v63 @ X8_v3+20]);\n\tthis.__TypeHandle = *([v63 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+10]) = *([v63 @ X8_v3+10]);\n\tv85 = &v86 @ stack_-90;\n\tv89 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+28]) = *([v85 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+38]) = *([v85 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData)+48]) = *([v85 @ X8_v5+20]);\n\tv110 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600043E")]
				[Address(RVA = "0x3C88580", Offset = "0x3C88580", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x18;\n\tv54 = 0x8BF6A34(v51, this, 0x78, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref FreezeGateJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600043F")]
				[Address(RVA = "0x3C88600", Offset = "0x3C88600", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x18;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref FreezeGateJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000440")]
				[Address(RVA = "0x3C88698", Offset = "0x3C88698", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x18;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref FreezeGateJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000441")]
				[Address(RVA = "0x3C88730", Offset = "0x3C88730", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref FreezeGateJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000442")]
				[Address(RVA = "0x3C88734", Offset = "0x3C88734", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref FreezeGateJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000443")]
				[Address(RVA = "0x3C88740", Offset = "0x3C88740", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref FreezeGateJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000D8")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x6000446")]
				[Address(RVA = "0x3C88844", Offset = "0x3C88844", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x40002B9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float freezeTop;

			[Token(Token = "0x40002BA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float freezeBottom;

			[Token(Token = "0x40002BB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float gateXMin;

			[Token(Token = "0x40002BC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public float gateXMax;

			[Token(Token = "0x40002BD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public float floorY;

			[Token(Token = "0x40002BE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x6000422")]
			[Address(RVA = "0x3C87B70", Offset = "0x3C87B70", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv57 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(pState);\n\tv137 = v57 == 0;\n\tv125 = ~v137;\n\tif (v125) goto L_0079;\n\tv122 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsVacuumReserved(pState);\n\tv140 = v122 == 0;\n\tv124 = ~v140;\n\tif (v124) goto L_0079;\n\tv108 = pos.value.y < this.freezeTop;\n\tv101 = pos.value.y == this.freezeTop;\n\tv142 = pos.value.y == pos.value.y;\n\tv80 = this.freezeTop == this.freezeTop;\n\tv87 = v142 & v80;\n\tv73 = ~v87;\n\tv143 = v108 == v73;\n\tv64 = ~v101;\n\tv68 = v143 & v64;\n\tif (v68) goto L_0079;\n\tv109 = pos.value.y < this.freezeBottom;\n\tif (v109) goto L_0079;\n\tv110 = pos.value < this.gateXMin;\n\tif (v110) goto L_0079;\n\tv111 = pos.value < this.gateXMax;\n\tv104 = pos.value == this.gateXMax;\n\tv149 = pos.value == pos.value;\n\tv83 = this.gateXMax == this.gateXMax;\n\tv90 = v149 & v83;\n\tv76 = ~v90;\n\tv150 = v111 == v76;\n\tv62 = ~v104;\n\tv69 = v150 & v62;\n\tif (v69) goto L_0079;\n\tvel.value = v154.zero;\n\tv106 = pos.value.y < this.floorY;\n\tv66 = ~v106;\n\tif (v66) goto L_0079;\n\tpos.value.y = this.floorY;\nL_001B:\n\tv51 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(pState);\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0079;\nL_0079:\n\treturn;\n")]
			private void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState pState)
			{
				if (pState.IsExited || pState.IsAbsorbing || pState.IsVacuumReserved)
				{
					return;
				}
				bool flag = pos.value.y < freezeTop;
				bool flag2 = pos.value.y == freezeTop;
				bool flag3 = pos.value.y == pos.value.y;
				bool flag4 = freezeTop == freezeTop;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if ((flag7 && flag8) || pos.value.y < freezeBottom || pos.value.x < gateXMin)
				{
					return;
				}
				bool flag9 = pos.value.x < gateXMax;
				bool flag10 = pos.value.x == gateXMax;
				bool flag11 = pos.value.x == pos.value.x;
				bool flag12 = gateXMax == gateXMax;
				bool flag13 = flag11 && flag12;
				bool flag14 = !flag13;
				bool flag15 = flag9 == flag14;
				bool flag16 = !flag10;
				if (!(flag15 && flag16))
				{
					vel.value = float2.zero;
					if (pos.value.y < floorY)
					{
						pos.value.y = floorY;
					}
				}
			}

			[CompilerGenerated]
			[Token(Token = "0x6000423")]
			[Address(RVA = "0x3C87C58", Offset = "0x3C87C58", Length = "0x454")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0039;\n\tv97 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv104 = useEnabledMask == 0;\n\tif (v104) goto L_00D8;\n\tv109 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv110 = v109 ^ chunkEnabledMask.Byte0;\n\t// 84 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 85 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 86 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 87 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 88 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 89 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv111 = v58 + v110;\n\tv113 = v111 < 5;\n\tv114 = ~v113;\n\tv115 = v111 - 5;\n\tv117 = v115 == 0;\n\tv122 = ~v117;\n\tv123 = v114 & v122;\n\tif (v123) goto L_0103;\nL_FFFFFFFF:\n\tv252 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv295 = 0;\n\tgoto L_0076;\nL_FFFFFFFF:\n\tv252 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv295 = v484;\n\tv428 = ~v418;\n\tv430 = ~v395;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v172 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v428, v430);\n\tv269 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v172);\n\tv274 = v269 == 0;\n\tif (v274) goto L_0184;\n\tv504 = v395 + v295;\n\tv484 = v269 + v504;\n\tv496 = v504 >= v484;\nL_FFFFFFFF:\n\tv540 = v269;\n\tif (v496) goto L_FFFFFFFF;\nL_00A9:\n\t;\n\tv545 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v504);\n\tv570 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v504);\n\tv589 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v504);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::Execute(this, v545, v570, v589);\n\tv504 = v504 + 1;\n\tv541 = v540 - 1;\n\tv511 = v540 != 1;\nL_FFFFFFFF:\n\tv540 = v541;\n\tif (v511) goto L_00A9;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_00D8:\n\tv134 = v97 < 1;\n\tif (v134) goto L_0184;\nL_FFFFFFFF:\n\tv373 = 0;\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::Execute(this, v378, v401, v425);\n\tv373 = v373 + 1;\n\tv199 = v97 != v373;\n\tif (v199) goto L_00E4;\n\tgoto L_0184;\nL_0103:\n\tv145 = v97 - 0x40;\n\tv146 = v145 < 0;\n\tv148 = v97 ^ 0x40;\n\tv149 = v97 ^ v145;\n\tv150 = v148 & v149;\n\tv151 = v150 < 0;\n\tv153 = v146 == v151;\n\tv154 = ~v153;\n\tv155 = ~v154;\n\tif (v155) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv292 = v97;\n\tgoto L_011D;\nL_FFFFFFFF:\n\tv292 = 0x40;\nL_FFFFFFFF:\n\tv192 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv457 = 0;\n\tgoto L_0130;\nL_0124:\n\tv192 = v192 >> 1;\n\tv457 = v457 + 1;\n\tv444 = v292 == v457;\n\tif (v444) goto L_0155;\nL_0130:\n\tv458 = v192 & 1;\n\tv275 = v458 == 0;\n\tif (v275) goto L_0124;\n\tv465 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v457);\n\tv479 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v457);\n\tv500 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v457);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::Execute(this, v465, v479, v500);\n\tgoto L_0124;\nL_0155:\n\tv200 = v97 < 0x41;\n\tif (v200) goto L_0184;\n\tv502 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv563 = 0x40;\n\tgoto L_0167;\nL_015B:\n\tv196 = v502 >> 1;\n\tv563 = v563 + 1;\n\tv230 = v97 == v563;\nL_FFFFFFFF:\n\tv502 = v196;\n\tif (v230) goto L_0184;\nL_0167:\n\tv565 = v502 & 1;\n\tv276 = v565 == 0;\n\tif (v276) goto L_015B;\n\tv576 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v563);\n\tv594 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v563);\n\tv598 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v563);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::Execute(this, v576, v594, v598);\n\tgoto L_015B;\nL_0184:\n\tv303 = *([A4731E0]);\n\tv314 = *([v303 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v314) goto L_019F;\n\treturn;\nL_019F:\n\tv391 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0039:\n\tv71 = this + 0x18;\n\tv72 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v71);\n\tv80 = this + 0x40;\n\tv81 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v80);\n\tv89 = this + 0x68;\n\tv90 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v89);\nL_0076:\n\tv352 = v252;\n\tv356 = Unity.Entities.EnabledBitUtility::ShiftRight(&v352 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v295);\n\tv352 = v356;\n\tv395 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v356);\n\tv418 = Unity.Entities.EnabledBitUtility::ShiftRight(&v352 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v395);\nL_00E4:\n\tv378 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v373);\n\tv401 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v373);\n\tv425 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v90, v373);\nL_011D:\n\tv201 = v97 < 1;\n\tif (v201) goto L_0184;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob::Execute");
			}

			[Token(Token = "0x6000424")]
			[Address(RVA = "0x3C880AC", Offset = "0x3C880AC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem.FreezeGateJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x6000425")]
			[Address(RVA = "0x3C88100", Offset = "0x3C88100", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000426")]
			[Address(RVA = "0x3C8810C", Offset = "0x3C8810C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000427")]
			[Address(RVA = "0x3C88118", Offset = "0x3C88118", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000428")]
			[Address(RVA = "0x3C88124", Offset = "0x3C88124", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000429")]
			[Address(RVA = "0x3C88130", Offset = "0x3C88130", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600042A")]
			[Address(RVA = "0x3C8813C", Offset = "0x3C8813C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600042B")]
			[Address(RVA = "0x3C88148", Offset = "0x3C88148", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600042C")]
			[Address(RVA = "0x3C88154", Offset = "0x3C88154", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600042D")]
			[Address(RVA = "0x3C88160", Offset = "0x3C88160", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600042E")]
			[Address(RVA = "0x3C8816C", Offset = "0x3C8816C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600042F")]
			[Address(RVA = "0x3C88178", Offset = "0x3C88178", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000430")]
			[Address(RVA = "0x3C88184", Offset = "0x3C88184", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000431")]
			[Address(RVA = "0x3C88190", Offset = "0x3C88190", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000432")]
			[Address(RVA = "0x3C8819C", Offset = "0x3C8819C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000433")]
			[Address(RVA = "0x3C881A8", Offset = "0x3C881A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000434")]
			[Address(RVA = "0x3C881B4", Offset = "0x3C881B4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000435")]
			[Address(RVA = "0x3C881C0", Offset = "0x3C881C0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000436")]
			[Address(RVA = "0x3C881CC", Offset = "0x3C881CC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000437")]
			[Address(RVA = "0x3C881D8", Offset = "0x3C881D8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000438")]
			[Address(RVA = "0x3C881E4", Offset = "0x3C881E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000439")]
			[Address(RVA = "0x3C881F0", Offset = "0x3C881F0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600043A")]
			[Address(RVA = "0x3C881FC", Offset = "0x3C881FC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600043B")]
			[Address(RVA = "0x3C88208", Offset = "0x3C88208", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000D9")]
		private struct TypeHandle
		{
			[Token(Token = "0x40002C4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public WakeUpFrozenJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_WakeUpFrozenJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x40002C5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xB0")]
			public FreezeGateJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_FreezeGateJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6000447")]
			[Address(RVA = "0x3C88848", Offset = "0x3C88848", Length = "0x44")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = 0x3C87594(this, state, 0, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv32 = 0x3C87720(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData::Init(&this.___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_FreezeGateJob_WithDefaultQuery_JobEntityTypeHandle (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData), state, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void __AssignHandles(ref SystemState state)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C87594 (inside _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x154)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C87720 (inside _game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData::Init +0x38)");
				___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_FreezeGateJob_WithDefaultQuery_JobEntityTypeHandle.Init(ref state, assignDefaultQuery: true);
			}
		}

		[Token(Token = "0x40002AB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private bool _wasGateClosed;

		[Token(Token = "0x40002AC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x3C86494", Offset = "0x3C86494", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x3C864E8", Offset = "0x3C864E8", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv44 = *([B78D78A]) & 1;\n\tv45 = v44 == 0;\n\tif (v45) goto L_002D;\n\tv70 = 0xB293000 + 0xDC8;\n\tv50 = *([B193A9A]) & 1;\n\tv51 = v50 == 0;\nL_FFFFFFFF:\n\tv84 = v70;\n\tif (v51) goto L_003A;\nL_0022:\n\tv78 = *([v70 @ X22_v12 (System.Int32)]);\n\tv79 = *([v78 @ X8_v33+B8]);\n\tv96 = *([v79 @ X8_v34]);\n\tv81 = *([v79 @ X8_v34]) == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0042;\n\tgoto L_014A;\nL_002D:\n\t*([B19378A]) = 1;\n\tv70 = 0xB293000 + 0xDC8;\n\tv93 = *([B193A9A]) & 1;\n\tv94 = v93 == 0;\n\tv73 = ~v94;\nL_FFFFFFFF:\n\tv84 = v70;\n\tif (v73) goto L_0022;\nL_003A:\n\t*([B193A9A]) = 1;\n\tv110 = *([v84 @ X22_v8 (System.Int32)]);\n\tv101 = *([v110 @ X8_v28+B8]);\n\tv96 = *([v101 @ X8_v29]);\n\tv99 = *([v101 @ X8_v29]) == 0;\n\tif (v99) goto L_014A;\nL_0042:\n\tv105 = *([v96 @ X22_v3+60]);\n\tgoto L_004A;\nL_004A:\n\tv238 = UnityEngine.Object::op_Equality(*([v96 @ X22_v3+60]), 0);\n\tv245 = v238 == 0;\n\tif (v245) goto L_0064;\n\tgoto L_014A;\nL_0064:\n\tv193 = *([v105 @ X21_v5 (UnityEngine.Object)+188]) != 1;\n\tif (v193) goto L_014A;\n\tv369 = *([v105 @ X21_v5 (UnityEngine.Object)+194]) & 1;\n\tv370 = v369 == 0;\n\tif (v370) goto L_00DB;\n\tv378 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMin(*([v96 @ X22_v3+60]));\n\tv384 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMax(*([v96 @ X22_v3+60]));\n\tv396 = Unity.Entities.SystemState::get_Dependency(state);\n\tv447 = *([v105 @ X21_v5 (UnityEngine.Object)+50]);\n\tv452 = this + 0xB8;\n\tgoto L_009E;\n\tgoto L_00CC;\nL_00DB:\n\tv354 = this._wasGateClosed != 1;\n\tif (v354) goto L_FFFFFFFF;\n\tv387 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMin(*([v96 @ X22_v3+60]));\n\tv350 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_GateXMax(*([v96 @ X22_v3+60]));\n\tv481 = &v447 @ stack_-150_v5 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob);\n\tv486 = Unity.Entities.SystemState::get_Dependency(state);\n\tv495 = *([v105 @ X21_v5 (UnityEngine.Object)+54]);\n\tv501 = this + 8;\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v501, state);\n\tgoto L_0112;\nL_FFFFFFFF:\n\tv252 = 0;\nL_014A:\n\treturn;\nL_009E:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v452, state);\n\tv491 = this + 0xE0;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v491, state);\n\tv508 = this + 0x108;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v508, state);\nL_00CC:\n\tv575 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v447 @ stack_-150_v5 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_FreezeGateJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v396);\nL_FFFFFFFF:\n\tv583 = v575;\nL_FFFFFFFF:\n\tv252 = 1;\n\tgoto L_0133;\nL_0133:\n\tUnity.Entities.SystemState::set_Dependency(state, v583);\n\tgoto L_0136;\nL_0112:\n\t*([v481 @ X25_v5+78]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+68]);\n\t*([v481 @ X25_v5+88]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+78]);\n\t*([v481 @ X25_v5+98]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+88]);\n\t*([v481 @ X25_v5+A8]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+98]);\n\t*([v481 @ X25_v5+38]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+28]);\n\t*([v481 @ X25_v5+48]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+38]);\n\t*([v481 @ X25_v5+58]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+48]);\n\t*([v481 @ X25_v5+68]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_WakeUpFrozenJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;\n\t*([v481 @ X25_v5+18]) = this.__TypeHandle;\n\t*([v481 @ X25_v5+28]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem)+18]);\n\tv546 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v495 @ stack_-150_v4 (_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_GateFreezeSystem_WakeUpFrozenJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v486);\nL_FFFFFFFF:\n\tv583 = v546;\nL_FFFFFFFF:\n\tv252 = 0;\nL_0136:\n\tthis._wasGateClosed = v252;\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x3C868F0", Offset = "0x3C868F0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = this + 8;\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+WakeUpFrozenJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v34, state);\n\tgoto L_0024;\nL_0024:\n\tv59 = job + 0x18;\n\tv60 = this + 8;\n\tv62 = 0x8BF6A34(v59, v60, 0xA0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(WakeUpFrozenJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60003F7")]
		[Address(RVA = "0x3C86A6C", Offset = "0x3C86A6C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tgoto L_0047;\nL_002D:\n\tv66 = this + 0xB8;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v66, state);\n\tv72 = this + 0xE0;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(v72, state);\n\tv79 = this + 0x108;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v79, state);\nL_0047:\n\tv94 = job + 0x18;\n\tv95 = this + 0xB8;\n\tv97 = 0x8BF6A34(v94, v95, 0x78, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_1(FreezeGateJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem::__ScheduleViaJobChunkExtension_1");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60003F8")]
		[Address(RVA = "0x3C86C3C", Offset = "0x3C86C3C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0x3C86C80", Offset = "0x3C86C80", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv24 = this + 8;\n\tv27 = 0x3C87594(v24, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv41 = this + 8;\n\tv44 = 0x3C87720(v41, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv45 = this + 0xB8;\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData::Init(v45, state, 1);\n\treturn;\n")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003FA")]
		[Address(RVA = "0x3C863B8", Offset = "0x3C863B8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003FB")]
		[Address(RVA = "0x3C8640C", Offset = "0x3C8640C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((GateFreezeSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003FC")]
		[Address(RVA = "0x3C86410", Offset = "0x3C86410", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv24 = self + 8;\n\tv27 = 0x3C87594(v24, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv41 = self + 8;\n\tv44 = 0x3C87720(v41, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv45 = self + 0xB8;\n\t_game.CoreSystem.SandPhysics.Systems.GateFreezeSystem+FreezeGateJob+InternalCompilerQueryAndHandleData::Init(v45, state, 1);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GateFreezeSystem::__codegen__OnCreateForCompiler");
		}
	}
}
