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
	[UpdateAfter(typeof(IntegratePositionSystem))]
	[UpdateBefore(typeof(ParticleCollisionSystem))]
	[Token(Token = "0x20000C0")]
	public struct ConveyorSystem : ISystem, ISystemCompilerGenerated
	{
		[Token(Token = "0x20000C1")]
		private struct CountConveyorParticlesJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000C2")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000C3")]
				public struct TypeHandle
				{
					[ReadOnly]
					[Token(Token = "0x4000286")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x600039A")]
					[Address(RVA = "0x3C8309C", Offset = "0x3C8309C", Length = "0x80")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv50 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle = v50.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v50.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v50.m_Length;\n\treturn;\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x600039B")]
					[Address(RVA = "0x3C826F8", Offset = "0x3C826F8", Length = "0x60")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(this, v43);\n\treturn;\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x4000284")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x4000285")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000392")]
				[Address(RVA = "0x3C82D1C", Offset = "0x3C82D1C", Length = "0xB4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v61;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+30]) = state;\n\tv64 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticleState>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000393")]
				[Address(RVA = "0x3C82DD0", Offset = "0x3C82DD0", Length = "0x108")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = ~assignDefaultQuery;\n\tif (v18) goto L_003A;\n\tgoto L_0019;\n\tv37 = v114;\n\tv117 = Unity.Entities.EntityQueryBuilder::Build(&v37 @ stack_-68_v2 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v117;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+30]) = state;\n\tv120 = Unity.Entities.EntityQueryBuilder::Reset(&v31 @ stack_-58_v3 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v31 @ stack_-58_v3 (Unity.Entities.EntityQueryBuilder));\nL_003A:\n\tgoto L_0044;\nL_0019:\n\tv31 = 0;\n\tv78 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v31 @ stack_-58_v3 (Unity.Entities.EntityQueryBuilder), v78);\n\tv114 = Unity.Entities.EntityQueryBuilder::WithAll(&v31 @ stack_-58_v3 (Unity.Entities.EntityQueryBuilder));\nL_0044:\n\tv89 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.__TypeHandle = v89.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]) = v89.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]) = v89.m_Length;\n\treturn;\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000394")]
				[Address(RVA = "0x3C82ED8", Offset = "0x3C82ED8", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\t*([job @ X1 (CountConveyorParticlesJob&)+30]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]);\n\tjob.__TypeHandle = this.__TypeHandle;\n\t*([job @ X1 (CountConveyorParticlesJob&)+20]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public void Run(ref CountConveyorParticlesJob job, EntityQuery query)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]");
					_ = 0;
					job.__TypeHandle = __TypeHandle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]");
					_ = 0;
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000395")]
				[Address(RVA = "0x3C82F58", Offset = "0x3C82F58", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\t*([job @ X1 (CountConveyorParticlesJob&)+30]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]);\n\tjob.__TypeHandle = this.__TypeHandle;\n\t*([job @ X1 (CountConveyorParticlesJob&)+20]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public JobHandle Schedule(ref CountConveyorParticlesJob job, EntityQuery query, JobHandle dependency)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]");
					_ = 0;
					job.__TypeHandle = __TypeHandle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]");
					_ = 0;
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000396")]
				[Address(RVA = "0x3C82FF0", Offset = "0x3C82FF0", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\t*([job @ X1 (CountConveyorParticlesJob&)+30]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]);\n\tjob.__TypeHandle = this.__TypeHandle;\n\t*([job @ X1 (CountConveyorParticlesJob&)+20]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public JobHandle ScheduleParallel(ref CountConveyorParticlesJob job, EntityQuery query, JobHandle dependency)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+20]");
					_ = 0;
					job.__TypeHandle = __TypeHandle;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData)+10]");
					_ = 0;
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000397")]
				[Address(RVA = "0x3C83088", Offset = "0x3C83088", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref CountConveyorParticlesJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000398")]
				[Address(RVA = "0x3C8308C", Offset = "0x3C8308C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref CountConveyorParticlesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000399")]
				[Address(RVA = "0x3C83098", Offset = "0x3C83098", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref CountConveyorParticlesJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000C4")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x600039C")]
				[Address(RVA = "0x3C8311C", Offset = "0x3C8311C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x4000282")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeReference<int> count;

			[Token(Token = "0x4000283")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x6000378")]
			[Address(RVA = "0x3C82830", Offset = "0x3C82830", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv56 = state.flags;\n\tv45 = state.flags;\n\tv56.lastConveyorSegment = state.lastConveyorSegment;\n\tv62 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(&v45 @ stack_-34_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv88 = v62 == 0;\n\tv77 = ~v88;\n\tif (v77) goto L_0049;\n\tv45 = state.flags;\n\tv56.lastConveyorSegment = state.lastConveyorSegment;\n\tv74 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsOnConveyor(&v45 @ stack_-34_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv76 = ~v74;\n\tif (v76) goto L_0049;\n\tv95 = Unity.Collections.NativeReference`1<System.Int32>::get_Value(this);\n\tv66 = v95 + 1;\n\tUnity.Collections.NativeReference`1<System.Int32>::set_Value(this, v66);\nL_0049:\n\treturn;\nL_0019:\n\tv45 = state.flags;\n\tv56.lastConveyorSegment = state.lastConveyorSegment;\n\tv50 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(&v45 @ stack_-34_v1 (_game.CoreSystem.SandPhysics.Components.ParticleState));\n\tv54 = v50 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0049;\n")]
			private void Execute(in ParticleState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x6000379")]
			[Address(RVA = "0x3C82918", Offset = "0x3C82918", Length = "0x2A4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_0027;\n\tv75 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv76 = v75 ^ chunkEnabledMask.Byte0;\n\t// 52 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 53 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 54 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 55 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 56 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 57 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv77 = v50 + v76;\n\tv79 = v77 < 5;\n\tv80 = ~v79;\n\tv81 = v77 - 5;\n\tv83 = v81 == 0;\n\tv88 = ~v83;\n\tv89 = v80 & v88;\n\tif (v89) goto L_00B6;\nL_FFFFFFFF:\n\tv203 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv224 = 0;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv203 = chunkEnabledMask.Byte0;\n\tv335 = ~v328;\n\tv337 = ~v311;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v130 @ stack_-80_v4 (Unity.Burst.Intrinsics.v128), v335, v337);\n\tv210 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v130);\n\tv215 = v210 == 0;\n\tif (v215) goto L_0116;\n\tv410 = v311 + v224;\n\tv224 = v210 + v410;\n\tv383 = v410 >= v224;\nL_FFFFFFFF:\n\tv412 = v210;\n\tif (v383) goto L_FFFFFFFF;\nL_007F:\n\tv416 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v64, v410);\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::Execute(this, v416);\n\tv410 = v410 + 1;\n\tv413 = v412 - 1;\n\tv389 = v412 != 1;\nL_FFFFFFFF:\n\tv412 = v413;\n\tif (v389) goto L_007F;\n\tgoto L_FFFFFFFF;\nL_009B:\n\tv100 = v70 < 1;\n\tif (v100) goto L_0116;\nL_FFFFFFFF:\n\tv293 = 0;\n\tgoto L_0116;\nL_00B6:\n\tv106 = v70 - 0x40;\n\tv107 = v106 < 0;\n\tv109 = v70 ^ 0x40;\n\tv110 = v70 ^ v106;\n\tv111 = v109 & v110;\n\tv112 = v111 < 0;\n\tv114 = v107 == v112;\n\tv115 = ~v114;\n\tv116 = ~v115;\n\tif (v116) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv147 = v70;\n\tgoto L_00D0;\nL_FFFFFFFF:\n\tv147 = 0x40;\nL_FFFFFFFF:\n\tv121 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv360 = 0;\n\tgoto L_00E3;\nL_00D7:\n\tv121 = v121 >> 1;\n\tv360 = v360 + 1;\n\tv350 = v147 == v360;\n\tif (v350) goto L_00F8;\nL_00E3:\n\tv361 = v121 & 1;\n\tv216 = v361 == 0;\n\tif (v216) goto L_00D7;\n\tv366 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v64, v360);\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::Execute(this, v366);\n\tgoto L_00D7;\nL_00F8:\n\tv151 = v70 < 0x41;\n\tif (v151) goto L_0116;\n\tv384 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv430 = 0x40;\n\tgoto L_0109;\nL_00FD:\n\tv228 = v384 >> 1;\n\tv430 = v430 + 1;\n\tv181 = v70 == v430;\nL_FFFFFFFF:\n\tv384 = v228;\n\tif (v181) goto L_0116;\nL_0109:\n\tv431 = v384 & 1;\n\tv217 = v431 == 0;\n\tif (v217) goto L_00FD;\n\tv435 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v64, v430);\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::Execute(this, v435);\n\tgoto L_00FD;\nL_0116:\n\tv234 = *([A4731E0]);\n\tv245 = *([v234 @ X9_v3]) != *([v31 @ X8_v2]);\n\tif (v245) goto L_012F;\n\treturn;\nL_012F:\n\tv307 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0027:\n\tv63 = this + 0x10;\n\tv64 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v63);\n\tv70 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv73 = useEnabledMask == 0;\n\tif (v73) goto L_009B;\nL_004D:\n\tv274 = v203;\n\tv278 = Unity.Entities.EnabledBitUtility::ShiftRight(&v274 @ stack_-70_v3 (Unity.Burst.Intrinsics.v128), v224);\n\tv274 = v278;\n\tv311 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v278);\n\tv328 = Unity.Entities.EnabledBitUtility::ShiftRight(&v274 @ stack_-70_v3 (Unity.Burst.Intrinsics.v128), v311);\nL_00A3:\n\tv296 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v64, v293);\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::Execute(this, v296);\n\tv293 = v293 + 1;\n\tv150 = v70 != v293;\n\tif (v150) goto L_00A3;\nL_00D0:\n\tv152 = v70 < 1;\n\tif (v152) goto L_0116;\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob::Execute");
			}

			[Token(Token = "0x600037A")]
			[Address(RVA = "0x3C82BBC", Offset = "0x3C82BBC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.CountConveyorParticlesJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x600037B")]
			[Address(RVA = "0x3C82C10", Offset = "0x3C82C10", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600037C")]
			[Address(RVA = "0x3C82C1C", Offset = "0x3C82C1C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600037D")]
			[Address(RVA = "0x3C82C28", Offset = "0x3C82C28", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600037E")]
			[Address(RVA = "0x3C82C34", Offset = "0x3C82C34", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600037F")]
			[Address(RVA = "0x3C82C40", Offset = "0x3C82C40", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000380")]
			[Address(RVA = "0x3C82C4C", Offset = "0x3C82C4C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000381")]
			[Address(RVA = "0x3C82C58", Offset = "0x3C82C58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000382")]
			[Address(RVA = "0x3C82C64", Offset = "0x3C82C64", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000383")]
			[Address(RVA = "0x3C82C70", Offset = "0x3C82C70", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000384")]
			[Address(RVA = "0x3C82C7C", Offset = "0x3C82C7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000385")]
			[Address(RVA = "0x3C82C88", Offset = "0x3C82C88", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000386")]
			[Address(RVA = "0x3C82C94", Offset = "0x3C82C94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000387")]
			[Address(RVA = "0x3C82CA0", Offset = "0x3C82CA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000388")]
			[Address(RVA = "0x3C82CAC", Offset = "0x3C82CAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000389")]
			[Address(RVA = "0x3C82CB8", Offset = "0x3C82CB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600038A")]
			[Address(RVA = "0x3C82CC4", Offset = "0x3C82CC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600038B")]
			[Address(RVA = "0x3C82CD0", Offset = "0x3C82CD0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600038C")]
			[Address(RVA = "0x3C82CDC", Offset = "0x3C82CDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600038D")]
			[Address(RVA = "0x3C82CE8", Offset = "0x3C82CE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600038E")]
			[Address(RVA = "0x3C82CF4", Offset = "0x3C82CF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600038F")]
			[Address(RVA = "0x3C82D00", Offset = "0x3C82D00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000390")]
			[Address(RVA = "0x3C82D0C", Offset = "0x3C82D0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000391")]
			[Address(RVA = "0x3C82D18", Offset = "0x3C82D18", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[WithAll(new Type[] { typeof(SandParticle) })]
		[WithDisabled(new Type[] { typeof(OnConveyorTag) })]
		[Token(Token = "0x20000C5")]
		private struct EntryJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000C6")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000C7")]
				public struct TypeHandle
				{
					[Token(Token = "0x400028E")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[ReadOnly]
					[Token(Token = "0x400028F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[Token(Token = "0x4000290")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<OnConveyorTag> ___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x60003BF")]
					[Address(RVA = "0x3C83D3C", Offset = "0x3C83D3C", Length = "0x100")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tthis.___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle = v102.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = v102.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = v102.m_Length;\n\treturn;\nL_0024:\n\tv55 = &v63 @ stack_-68_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv59 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = *([v55 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = *([v55 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v55 @ X8_v3+10]);\n\tv77 = &v84 @ stack_-90_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv81 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = *([v77 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v77 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v77 @ X8_v5+20]);\n\tv102 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x60003C0")]
					[Address(RVA = "0x3C823D0", Offset = "0x3C823D0", Length = "0xAC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\treturn;\nL_0026:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::Update(&this.___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>), state);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400028C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x400028D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003B7")]
				[Address(RVA = "0x3C83804", Offset = "0x3C83804", Length = "0x260")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv79 = v76;\n\tv83 = Unity.Entities.EntityQueryBuilder::WithAll(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v83;\n\tv88 = Unity.Entities.EntityQueryBuilder::WithAll(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v88;\n\tv93 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tv79 = v93;\n\tv99 = Unity.Entities.EntityQueryBuilder::Build(&v79 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v99;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+80]) = state;\n\tv102 = Unity.Entities.EntityQueryBuilder::Reset(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_002A:\n\tv60 = 0;\n\tv64 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), v64);\n\tv76 = Unity.Entities.EntityQueryBuilder::WithDisabledRW(&v60 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithDisabledRW<OnConveyorTag>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticlePosition>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleState>();
					entityQueryBuilder3 = entityQueryBuilder6;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x60003B8")]
				[Address(RVA = "0x3C83A64", Offset = "0x3C83A64", Length = "0x114")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = ~assignDefaultQuery;\n\tif (v22) goto L_001D;\n\tv27 = 0x3C83934(this, state, 0, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001D:\n\tgoto L_002A;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+50]) = v110.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+60]) = v110.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+70]) = v110.m_Length;\n\treturn;\nL_002A:\n\tv63 = &v71 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData+TypeHandle);\n\tv67 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+20]) = *([v63 @ X8_v3+20]);\n\tthis.__TypeHandle = *([v63 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+10]) = *([v63 @ X8_v3+10]);\n\tv85 = &v86 @ stack_-90;\n\tv89 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+28]) = *([v85 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+38]) = *([v85 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData)+48]) = *([v85 @ X8_v5+20]);\n\tv110 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003B9")]
				[Address(RVA = "0x3C83B78", Offset = "0x3C83B78", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x10;\n\tv54 = 0x8BF6A34(v51, this, 0x78, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref EntryJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003BA")]
				[Address(RVA = "0x3C83BF8", Offset = "0x3C83BF8", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x10;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref EntryJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003BB")]
				[Address(RVA = "0x3C83C90", Offset = "0x3C83C90", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x10;\n\tv60 = 0x8BF6A34(v57, this, 0x78, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref EntryJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003BC")]
				[Address(RVA = "0x3C83D28", Offset = "0x3C83D28", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref EntryJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003BD")]
				[Address(RVA = "0x3C83D2C", Offset = "0x3C83D2C", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref EntryJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003BE")]
				[Address(RVA = "0x3C83D38", Offset = "0x3C83D38", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref EntryJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000C8")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x60003C1")]
				[Address(RVA = "0x3C83E3C", Offset = "0x3C83E3C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x4000287")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float influenceYThreshold;

			[Token(Token = "0x4000288")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float wakeUpY;

			[Token(Token = "0x4000289")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float gateY;

			[Token(Token = "0x400028A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public bool isGateClosed;

			[Token(Token = "0x400028B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x600039D")]
			[Address(RVA = "0x3C83120", Offset = "0x3C83120", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv57 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(state);\n\tv127 = v57 == 0;\n\tv115 = ~v127;\n\tif (v115) goto L_0052;\n\tv112 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsVacuumReserved(state);\n\tv176 = v112 == 0;\n\tv114 = ~v176;\n\tif (v114) goto L_0052;\n\tv101 = pos.value.y < this.wakeUpY;\n\tv96 = pos.value.y == this.wakeUpY;\n\tv178 = pos.value.y == pos.value.y;\n\tv81 = this.wakeUpY == this.wakeUpY;\n\tv86 = v178 & v81;\n\tv76 = ~v86;\n\tv179 = v101 == v76;\n\tv65 = ~v96;\n\tv71 = v179 & v65;\n\tif (v71) goto L_0052;\n\tv99 = pos.value.y < this.influenceYThreshold;\n\tv94 = pos.value.y == this.influenceYThreshold;\n\tv181 = pos.value.y == pos.value.y;\n\tv79 = this.influenceYThreshold == this.influenceYThreshold;\n\tv84 = v181 & v79;\n\tv74 = ~v84;\n\tv182 = v99 == v74;\n\tv183 = ~v182;\n\tv69 = v183 | v94;\n\tif (v69) goto L_005D;\nL_0052:\n\treturn;\nL_005D:\n\tv191 = this.isGateClosed != 1;\n\tif (v191) goto L_006F;\n\tv102 = pos.value.y < this.gateY;\n\tv97 = pos.value.y == this.gateY;\n\tv193 = pos.value.y == pos.value.y;\n\tv82 = this.gateY == this.gateY;\n\tv87 = v193 & v82;\n\tv77 = ~v87;\n\tv194 = v102 == v77;\n\tv67 = ~v97;\n\tv72 = v194 & v67;\n\tif (v72) goto L_0052;\nL_006F:\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsOnConveyor(state, 1);\n\tstate.lastConveyorSegment = 0xFF;\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::set_ValueRW(tag, 1);\n\treturn;\nL_001B:\n\tv51 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(state);\n\tv53 = v51 == 0;\n\tv54 = ~v53;\n\tif (v54) goto L_0052;\n")]
			private unsafe void Execute(ref ParticleState state, in ParticlePosition pos, EnabledRefRW<OnConveyorTag> tag)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x600039E")]
			[Address(RVA = "0x3C8321C", Offset = "0x3C8321C", Length = "0x488")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0039;\n\tv95 = *([v87 @ X8_v6]);\n\tv102 = *([v87 @ X8_v6]);\n\tv95.m_PtrChunkDisabledCount = *([v87 @ X8_v6+10]);\n\tv107 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv113 = useEnabledMask == 0;\n\tif (v113) goto L_00E1;\n\tv118 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv119 = v118 ^ chunkEnabledMask.Byte0;\n\t// 92 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 93 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 94 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 95 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 96 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 97 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv120 = v58 + v119;\n\tv122 = v120 < 5;\n\tv123 = ~v122;\n\tv124 = v120 - 5;\n\tv126 = v124 == 0;\n\tv131 = ~v126;\n\tv132 = v123 & v131;\n\tif (v132) goto L_0117;\nL_FFFFFFFF:\n\tv200 = 0;\nL_FFFFFFFF:\n\tv258 = chunkEnabledMask.Byte0;\n\tgoto L_007B;\nL_FFFFFFFF:\n\tv200 = v552;\nL_FFFFFFFF:\n\tv258 = chunkEnabledMask.Byte0;\n\tv477 = ~v466;\n\tv479 = ~v443;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v189 @ stack_-A0_v12 (Unity.Burst.Intrinsics.v128), v477, v479);\n\tv308 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v189);\n\tv313 = v308 == 0;\n\tif (v313) goto L_01AE;\n\tv619 = v443 + v200;\n\tv552 = v308 + v619;\n\tv562 = v619 >= v552;\nL_FFFFFFFF:\n\tv623 = v308;\n\tif (v562) goto L_FFFFFFFF;\nL_00AE:\n\tv628 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v619);\n\tv663 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v619);\n\tv691 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v102 @ stack_-C0_v1 (Unity.Entities.EnabledMask), v619);\n\tv576 = v691.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::Execute(this, v628, v663, &v576 @ stack_-A0_v14 (Unity.Entities.SafeBitRef));\n\tv619 = v619 + 1;\n\tv624 = v623 - 1;\n\tv580 = v623 != 1;\nL_FFFFFFFF:\n\tv623 = v624;\n\tif (v580) goto L_00AE;\n\tgoto L_FFFFFFFF;\nL_00E1:\n\tv143 = v107 < 1;\n\tif (v143) goto L_01AE;\nL_FFFFFFFF:\n\tv419 = 0;\n\tv191 = v474.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::Execute(this, v426, v449, &v191 @ stack_-A0_v3 (Unity.Entities.SafeBitRef));\n\tv419 = v419 + 1;\n\tv205 = v107 != v419;\n\tif (v205) goto L_00ED;\n\tgoto L_01AE;\nL_0117:\n\tv153 = v107 - 0x40;\n\tv154 = v153 < 0;\n\tv156 = v107 ^ 0x40;\n\tv157 = v107 ^ v153;\n\tv158 = v156 & v157;\n\tv159 = v158 < 0;\n\tv161 = v154 == v159;\n\tv162 = ~v161;\n\tv163 = ~v162;\n\tif (v163) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv318 = v107;\n\tgoto L_0131;\nL_FFFFFFFF:\n\tv318 = 0x40;\nL_FFFFFFFF:\n\tv198 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv515 = 0;\n\tgoto L_0144;\nL_0138:\n\tv198 = v198 >> 1;\n\tv515 = v515 + 1;\n\tv494 = v318 == v515;\n\tif (v494) goto L_0174;\nL_0144:\n\tv516 = v198 & 1;\n\tv314 = v516 == 0;\n\tif (v314) goto L_0138;\n\tv523 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v515);\n\tv547 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v515);\n\tv567 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v102 @ stack_-C0_v1 (Unity.Entities.EnabledMask), v515);\n\tv525 = v567.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::Execute(this, v523, v547, &v525 @ stack_-A0_v5 (Unity.Entities.SafeBitRef));\n\tgoto L_0138;\nL_0174:\n\tv206 = v107 < 0x41;\n\tif (v206) goto L_01AE;\n\tv569 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv655 = 0x40;\n\tgoto L_0186;\nL_017A:\n\tv202 = v569 >> 1;\n\tv655 = v655 + 1;\n\tv236 = v107 == v655;\nL_FFFFFFFF:\n\tv569 = v202;\n\tif (v236) goto L_01AE;\nL_0186:\n\tv659 = v569 & 1;\n\tv315 = v659 == 0;\n\tif (v315) goto L_017A;\n\tv669 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v655);\n\tv697 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v655);\n\tv702 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v102 @ stack_-C0_v1 (Unity.Entities.EnabledMask), v655);\n\tv671 = v702.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::Execute(this, v669, v697, &v671 @ stack_-A0_v8 (Unity.Entities.SafeBitRef));\n\tgoto L_017A;\nL_01AE:\n\tv338 = *([A4731E0]);\n\tv349 = *([v338 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v349) goto L_01C9;\n\treturn;\nL_01C9:\n\tv439 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0039:\n\tv71 = this + 0x10;\n\tv72 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v71);\n\tv80 = this + 0x38;\n\tv81 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, v80);\n\tv87 = &v95 @ stack_-80_v1 (Unity.Entities.EnabledMask);\n\tv89 = this + 0x60;\n\tv91 = Unity.Entities.ArchetypeChunk::GetEnabledMask(chunk, v89);\nL_007B:\n\tv390 = v258;\n\tv394 = Unity.Entities.EnabledBitUtility::ShiftRight(&v390 @ stack_-80_v12 (Unity.Burst.Intrinsics.v128), v200);\n\tv440 = v394;\n\tv443 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v394);\n\tv466 = Unity.Entities.EnabledBitUtility::ShiftRight(&v440 @ stack_-80_v13 (Unity.Burst.Intrinsics.v128), v443);\nL_00ED:\n\tv426 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v72, v419);\n\tv449 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v81, v419);\n\tv474 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v102 @ stack_-C0_v1 (Unity.Entities.EnabledMask), v419);\nL_0131:\n\tv207 = v107 < 1;\n\tif (v207) goto L_01AE;\n")]
			public unsafe void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob::Execute");
			}

			[Token(Token = "0x600039F")]
			[Address(RVA = "0x3C836A4", Offset = "0x3C836A4", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.EntryJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x60003A0")]
			[Address(RVA = "0x3C836F8", Offset = "0x3C836F8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A1")]
			[Address(RVA = "0x3C83704", Offset = "0x3C83704", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A2")]
			[Address(RVA = "0x3C83710", Offset = "0x3C83710", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A3")]
			[Address(RVA = "0x3C8371C", Offset = "0x3C8371C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A4")]
			[Address(RVA = "0x3C83728", Offset = "0x3C83728", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A5")]
			[Address(RVA = "0x3C83734", Offset = "0x3C83734", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A6")]
			[Address(RVA = "0x3C83740", Offset = "0x3C83740", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A7")]
			[Address(RVA = "0x3C8374C", Offset = "0x3C8374C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A8")]
			[Address(RVA = "0x3C83758", Offset = "0x3C83758", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003A9")]
			[Address(RVA = "0x3C83764", Offset = "0x3C83764", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AA")]
			[Address(RVA = "0x3C83770", Offset = "0x3C83770", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AB")]
			[Address(RVA = "0x3C8377C", Offset = "0x3C8377C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AC")]
			[Address(RVA = "0x3C83788", Offset = "0x3C83788", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AD")]
			[Address(RVA = "0x3C83794", Offset = "0x3C83794", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AE")]
			[Address(RVA = "0x3C837A0", Offset = "0x3C837A0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003AF")]
			[Address(RVA = "0x3C837AC", Offset = "0x3C837AC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B0")]
			[Address(RVA = "0x3C837B8", Offset = "0x3C837B8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B1")]
			[Address(RVA = "0x3C837C4", Offset = "0x3C837C4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B2")]
			[Address(RVA = "0x3C837D0", Offset = "0x3C837D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B3")]
			[Address(RVA = "0x3C837DC", Offset = "0x3C837DC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B4")]
			[Address(RVA = "0x3C837E8", Offset = "0x3C837E8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B5")]
			[Address(RVA = "0x3C837F4", Offset = "0x3C837F4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003B6")]
			[Address(RVA = "0x3C83800", Offset = "0x3C83800", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000C9")]
		private struct BeltJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000CA")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000CB")]
				public struct TypeHandle
				{
					[Token(Token = "0x40002A1")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

					[Token(Token = "0x40002A2")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

					[Token(Token = "0x40002A3")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
					public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;

					[Token(Token = "0x40002A4")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
					public ComponentTypeHandle<ParticleSettleCounter> ___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle;

					[Token(Token = "0x40002A5")]
					[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
					public ComponentTypeHandle<OnConveyorTag> ___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x60003E8")]
					[Address(RVA = "0x3C85424", Offset = "0x3C85424", Length = "0x188")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle = *([v103 @ X8_v7]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+60]) = *([v103 @ X8_v7+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+70]) = *([v103 @ X8_v7+20]);\n\tv125 = &v132 @ stack_-100_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>);\n\tv129 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle = *([v125 @ X8_v9]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+88]) = *([v125 @ X8_v9+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+98]) = *([v125 @ X8_v9+20]);\n\tv150 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle = v150.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+B0]) = v150.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+C0]) = v150.m_Length;\n\treturn;\nL_0035:\n\tv71 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = v76;\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle = v68;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = v78;\n\tv81 = &v89 @ stack_-B0_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>);\n\tv85 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle = *([v81 @ X8_v5]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = *([v81 @ X8_v5+10]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = *([v81 @ X8_v5+20]);\n\tv103 = &v111 @ stack_-D8_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>);\n\tv107 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x60003E9")]
					[Address(RVA = "0x3C82520", Offset = "0x3C82520", Length = "0xFC")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleSettleCounter_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleSettleCounter>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::Update(&this.___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>), state);\n\treturn;\nL_0032:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleVelocity>), state);\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(&this.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>), state);\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400029F")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x40002A0")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E0")]
				[Address(RVA = "0x3C84DA0", Offset = "0x3C84DA0", Length = "0x300")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv88 = v84;\n\tv92 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v92;\n\tv100 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v100;\n\tv107 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v107;\n\tv112 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v112;\n\tv117 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder));\n\tv88 = v117;\n\tv123 = Unity.Entities.EntityQueryBuilder::Build(&v88 @ stack_-80_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v123;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+D0]) = state;\n\tv126 = Unity.Entities.EntityQueryBuilder::Reset(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0036:\n\tv68 = 0;\n\tv72 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder), v72);\n\tv84 = Unity.Entities.EntityQueryBuilder::WithAll(&v68 @ stack_-70_v1 (Unity.Entities.EntityQueryBuilder));\n")]
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
					EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithAllRW<OnConveyorTag>();
					entityQueryBuilder3 = entityQueryBuilder8;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x60003E1")]
				[Address(RVA = "0x3C850A0", Offset = "0x3C850A0", Length = "0x1C0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~assignDefaultQuery;\n\tif (v0) goto L_0014;\n\tv17 = 0x3C84F20(v35, v33, 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0022:\n\tv73 = &v74 @ stack_-10_v3;\n\tgoto L_004A;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+50]) = *([v133 @ X8_v7]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+60]) = *([v133 @ X8_v7+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+70]) = *([v133 @ X8_v7+20]);\n\tv155 = &v156 @ stack_-100;\n\tv159 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+78]) = *([v155 @ X8_v9]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+88]) = *([v155 @ X8_v9+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+98]) = *([v155 @ X8_v9+20]);\n\tv180 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+A0]) = v180.m_LookupCache;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+B0]) = v180.m_TypeIndex;\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+C0]) = v180.m_Length;\n\treturn;\nL_0014:\n\tgoto L_0022;\nL_004A:\n\tv103 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+20]) = *([v73 @ X29_v2-58]);\n\tv35.__TypeHandle = *([v73 @ X29_v2-78]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+10]) = *([v73 @ X29_v2-68]);\n\tv111 = &v112 @ stack_-B0;\n\tv115 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+28]) = *([v111 @ X8_v5]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+38]) = *([v111 @ X8_v5+10]);\n\t*([v35 @ X0_v1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData)+48]) = *([v111 @ X8_v5+20]);\n\tv133 = &v134 @ stack_-D8;\n\tv137 = Unity.Entities.SystemState::GetComponentTypeHandle(v33, 0);\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E2")]
				[Address(RVA = "0x3C85260", Offset = "0x3C85260", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv51 = job + 0x68;\n\tv54 = 0x8BF6A34(v51, this, 0xC8, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public unsafe void Run(ref BeltJob job, EntityQuery query)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData::Run");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E3")]
				[Address(RVA = "0x3C852E0", Offset = "0x3C852E0", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x68;\n\tv60 = 0x8BF6A34(v57, this, 0xC8, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle Schedule(ref BeltJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData::Schedule");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E4")]
				[Address(RVA = "0x3C85378", Offset = "0x3C85378", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv57 = job + 0x68;\n\tv60 = 0x8BF6A34(v57, this, 0xC8, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public unsafe JobHandle ScheduleParallel(ref BeltJob job, EntityQuery query, JobHandle dependency)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
					return default;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E5")]
				[Address(RVA = "0x3C85410", Offset = "0x3C85410", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref BeltJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E6")]
				[Address(RVA = "0x3C85414", Offset = "0x3C85414", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref BeltJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60003E7")]
				[Address(RVA = "0x3C85420", Offset = "0x3C85420", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref BeltJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000CC")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x60003EA")]
				[Address(RVA = "0x3C855AC", Offset = "0x3C855AC", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[ReadOnly]
			[Token(Token = "0x4000291")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public NativeArray<float2> sampledPoints;

			[ReadOnly]
			[Token(Token = "0x4000292")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public NativeArray<float2> sampledTangents;

			[ReadOnly]
			[Token(Token = "0x4000293")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public NativeArray<float2> segmentDirs;

			[ReadOnly]
			[Token(Token = "0x4000294")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			public NativeArray<float> segmentInvLenSq;

			[Token(Token = "0x4000295")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			public int sampleCount;

			[Token(Token = "0x4000296")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
			public float beltSpeed;

			[Token(Token = "0x4000297")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
			public float influenceYThreshold;

			[Token(Token = "0x4000298")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
			public float beltAcceleration;

			[Token(Token = "0x4000299")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
			public float corridorHalfWidth;

			[Token(Token = "0x400029A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
			public float corridorStrength;

			[Token(Token = "0x400029B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
			public float2 gravity;

			[Token(Token = "0x400029C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
			public bool isGateClosed;

			[Token(Token = "0x400029D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x64")]
			public float dt;

			[Token(Token = "0x400029E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x3C83E40", Offset = "0x3C83E40", Length = "0x37C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv69 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsExited(state);\n\tv81 = v69 == 0;\n\tv76 = ~v81;\n\tif (v76) goto L_0037;\n\tv73 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsAbsorbing(state);\n\tv75 = ~v73;\n\tif (v75) goto L_004D;\nL_0037:\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::set_ValueRW(tag, 0);\n\tstate.lastConveyorSegment = 0xFF;\nL_004D:\n\tv172 = this.influenceYThreshold + 0x3E4CCCCD;\n\tv166 = pos.value.y < v172;\n\tv162 = pos.value.y == v172;\n\tv279 = pos.value.y == pos.value.y;\n\tv150 = v172 == v172;\n\tv154 = v279 & v150;\n\tv146 = ~v154;\n\tv280 = v166 == v146;\n\tv281 = ~v280;\n\tv142 = v281 | v162;\n\tif (v142) goto L_0073;\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsOnConveyor(state, 0);\n\tstate.lastConveyorSegment = 0xFF;\n\tUnity.Entities.EnabledRefRW`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::set_ValueRW(tag, 0);\n\treturn;\nL_0073:\n\tv183 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(state);\n\tv284 = ~v183;\n\tif (v284) goto L_0080;\n\tv286 = this.isGateClosed == 0;\n\tv186 = ~v286;\n\tif (v186) goto L_0047;\nL_0080:\n\tv294 = state.lastConveyorSegment == 0xFF;\n\tv308 = 0;\n\tif (v294) goto L_00A0;\n\t// 140 MakeStruct v306 @ AGG3C83FA8_1_v4 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::FindClosestSegmentWindowed(this, v306, state.lastConveyorSegment, &v300 @ stack_-64_v5 (System.Int32), &v302 @ stack_-68_v6 (System.Single), &v308 @ stack_-6C_v4 (System.Single));\n\tv344 = this.corridorHalfWidth + 0.5f;\n\tv330 = v344 * v344;\n\tv326 = v308 < v330;\n\tv324 = v308 == v330;\n\tv346 = v308 == v308;\n\tv318 = v330 == v330;\n\tv320 = v346 & v318;\n\tv316 = ~v320;\n\tv347 = v326 == v316;\n\tv348 = ~v347;\n\tv314 = v348 | v324;\n\tv356 = v308;\n\tif (v314) goto L_00A8;\nL_00A0:\n\tv356 = pos.value.y;\n\t// 165 MakeStruct v341 @ AGG3C83FDC_1_v3 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), pos.value (Unity.Mathematics.float2), pos.value.y (System.Single)\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::FindClosestSegmentFull(this, v341, &v300 @ stack_-64_v5 (System.Int32), &v302 @ stack_-68_v6 (System.Single), &v308 @ stack_-6C_v4 (System.Single));\nL_00A8:\n\tstate.lastConveyorSegment = v300;\n\tv363 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsSettled(state);\n\tv364 = ~v363;\n\tif (v364) goto L_00B8;\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsSettled(state, 0);\n\tcounter.framesBelowThreshold = 1.4044470919183048E+306d;\n\tcounter.anchorPosition.y = 3.4028235E+38f;\n\tv460 = v443 < 0;\n\tv461 = v443 == 0;\n\tv464 = v443 == v443;\n\tv465 = ~v464;\n\tv467 = v460 == v465;\n\tv468 = ~v461;\n\tv469 = v467 & v468;\n\tv470 = ~v469;\n\tif (v470) goto L_012B;\n\tgoto L_012B;\n\tgoto L_0134;\nL_0025:\n\tv65 = _game.CoreSystem.SandPhysics.Components.ParticleState::get_IsOnConveyor(state);\n\tv66 = ~v65;\n\tif (v66) goto L_0037;\nL_0047:\n\treturn;\nL_00B8:\n\tv374 = v300 + 1;\n\tv92 = v374 / this.sampleCount;\n\tv375 = v92 * this.sampleCount;\n\tv194 = v374 - v375;\n\tv376 = this.sampledTangents;\n\tv380 = *([v376 @ X8_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v194 @ X22_v4 (System.Int32)*8]) - *([v376 @ X8_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v300 @ stack_-64_v5 (System.Int32)*8]);\n\tv139 = v380 * v381;\n\tgoto L_00D1;\nL_00DB:\n\t// 219 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv408 = UnityEngine.Mathf::Sqrt(v356);\n\tv410 = 1f / v408;\n\tv102 = this.sampledPoints;\n\tv424 = v398 * v425;\n\t// 239 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 240 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 241 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv99 = v424 & v410;\n\t// 245 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv431 = v99 * v86;\n\tv432 = v431 * v433;\n\tv137 = vel.value - v432;\n\t// 252 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv437 = *([v102 @ X9_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v194 @ X22_v4 (System.Int32)*8]) - *([v102 @ X9_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v300 @ stack_-64_v5 (System.Int32)*8]);\n\tv438 = v437 * v381;\n\tv439 = *([v102 @ X9_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v300 @ stack_-64_v5 (System.Int32)*8]) + v438;\n\tvel.value = v137;\n\tv441 = v439 - pos.value;\n\tv442 = v432 * v441;\n\t// 262 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv443 = pos.value - v442;\n\tv444 = UnityEngine.Mathf::Abs(v443);\n\tv446 = v444 < this.corridorHalfWidth;\n\tv447 = v444 == this.corridorHalfWidth;\n\tv450 = v444 == v444;\n\tv151 = this.corridorHalfWidth == this.corridorHalfWidth;\n\tv451 = v450 & v151;\n\tv452 = ~v451;\n\tv453 = v446 == v452;\n\tv454 = ~v453;\n\tv455 = v454 | v447;\n\tif (v455) goto L_013A;\nL_013A:\n\tv480 = v99 * v137;\n\t// 315 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 319 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv484 = this.beltAcceleration * this.dt;\n\tv485 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::MoveToward(v480, this.beltSpeed, v484);\n\tv489 = v99 * v498;\n\tv173 = v137 - v489;\n\tv490 = v99 * v491;\n\tv176 = v173 + v490;\n\tvel.value = v176;\n\tgoto L_0047;\nL_012B:\n\tv472 = pos.value >= v442;\n\tif (v472) goto L_0134;\nL_0134:\n\tv499 = v432 * v491;\n\tv500 = v499 * v433;\n\tv501 = v500 * v425;\n\tv479 = v501 * v381;\n\tv137 = v137 + v479;\n\tvel.value = v137;\nL_00D1:\n\tv398 = *([v376 @ X8_v10 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v300 @ stack_-64_v5 (System.Int32)*8]) + v139;\n\tgoto L_00DB;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe void Execute(ref ParticlePosition pos, ref ParticleVelocity vel, ref ParticleState state, ref ParticleSettleCounter counter, EnabledRefRW<OnConveyorTag> tag)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob::Execute");
			}

			[Token(Token = "0x60003C3")]
			[Address(RVA = "0x3C841BC", Offset = "0x3C841BC", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([bestDistSq @ X3 (System.Single&)]) = 0x7F7FFFFF;\n\t*([bestSegIdx @ X1 (System.Int32&)]) = 0;\n\t*([bestFrac @ X2 (System.Single&)]) = 0;\n\tv92 = this.sampleCount;\n\tv41 = this.sampleCount < 1;\n\tif (v41) goto L_0058;\n\tv114 = 0;\n\tgoto L_003A;\nL_0027:\n\tv114 = v114 + 1;\n\tv74 = v114 >= v92;\n\tif (v74) goto L_0058;\nL_003A:\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v114, &v62 @ stack_-54_v3 (System.Single), &v94 @ stack_-58_v4 (System.Single));\n\tv131 = v94 < *([bestDistSq @ X3 (System.Single&)]);\n\tv139 = ~v131;\n\tif (v139) goto L_0027;\n\t*([bestDistSq @ X3 (System.Single&)]) = v94;\n\t*([bestSegIdx @ X1 (System.Int32&)]) = v114;\n\t*([bestFrac @ X2 (System.Single&)]) = v62;\n\tv92 = this.sampleCount;\n\tgoto L_0027;\nL_0058:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private void FindClosestSegmentFull(float2 p, out int bestSegIdx, out float bestFrac, out float bestDistSq)
			{
				bestSegIdx = default(int);
				bestFrac = default(float);
				bestDistSq = default(float);
				bestDistSq = 3.4028235E+38f;
				bestSegIdx = 0;
				bestFrac = 0f;
				int num = sampleCount;
				if (sampleCount < 1)
				{
					return;
				}
				int num2 = 0;
				do
				{
					EvaluateSegment(p, num2, out var frac, out var distSq);
					if (distSq < bestDistSq)
					{
						bestDistSq = distSq;
						bestSegIdx = num2;
						bestFrac = frac;
						num = sampleCount;
					}
					num2++;
				}
				while (num2 < num);
			}

			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x3C84284", Offset = "0x3C84284", Length = "0x2D0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([bestDistSq @ X4 (System.Single&)]) = 0x7F7FFFFF;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = center;\n\t*([bestFrac @ X3 (System.Single&)]) = 0;\n\tv46 = center - 1;\n\tv241 = this.sampleCount;\n\tv48 = v46 / this.sampleCount;\n\tv49 = v48 * this.sampleCount;\n\tv50 = v46 - v49;\n\tv51 = v50 + this.sampleCount;\n\tv52 = v51 / this.sampleCount;\n\tv53 = v52 * this.sampleCount;\n\tv54 = v51 - v53;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v54, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv239 = bestDistSq->klass;\n\tv63 = v58 < *([bestDistSq @ X4 (System.Single&)]);\n\tv71 = ~v63;\n\tif (v71) goto L_003D;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v54;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v84;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v117;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v150;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v183;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v216;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\n\tv241 = this.sampleCount;\n\tv239 = bestDistSq->klass;\n\t*([bestDistSq @ X4 (System.Single&)]) = v58;\n\t*([bestSegIdx @ X2 (System.Int32&)]) = v249;\n\t*([bestFrac @ X3 (System.Single&)]) = v56;\nL_003D:\n\tv78 = center / v241;\n\tv79 = v78 * v241;\n\tv80 = center - v79;\n\tv81 = v80 + v241;\n\tv82 = v81 / v241;\n\tv83 = v82 * v241;\n\tv84 = v81 - v83;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v84, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv95 = v58 < v239;\n\tv103 = ~v95;\n\tif (v103) goto L_005D;\nL_005D:\n\tv110 = center + 1;\n\tv111 = v110 / v241;\n\tv112 = v111 * v241;\n\tv113 = v110 - v112;\n\tv114 = v113 + v241;\n\tv115 = v114 / v241;\n\tv116 = v115 * v241;\n\tv117 = v114 - v116;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v117, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv128 = v58 < v239;\n\tv136 = ~v128;\n\tif (v136) goto L_007E;\nL_007E:\n\tv143 = center + 2;\n\tv144 = v143 / v241;\n\tv145 = v144 * v241;\n\tv146 = v143 - v145;\n\tv147 = v146 + v241;\n\tv148 = v147 / v241;\n\tv149 = v148 * v241;\n\tv150 = v147 - v149;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v150, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv161 = v58 < v239;\n\tv169 = ~v161;\n\tif (v169) goto L_009F;\nL_009F:\n\tv176 = center + 3;\n\tv177 = v176 / v241;\n\tv178 = v177 * v241;\n\tv179 = v176 - v178;\n\tv180 = v179 + v241;\n\tv181 = v180 / v241;\n\tv182 = v181 * v241;\n\tv183 = v180 - v182;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v183, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv194 = v58 < v239;\n\tv202 = ~v194;\n\tif (v202) goto L_00C0;\nL_00C0:\n\tv209 = center + 4;\n\tv210 = v209 / v241;\n\tv211 = v210 * v241;\n\tv212 = v209 - v211;\n\tv213 = v212 + v241;\n\tv214 = v213 / v241;\n\tv215 = v214 * v241;\n\tv216 = v213 - v215;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v216, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv227 = v58 < v239;\n\tv235 = ~v227;\n\tif (v235) goto L_00E1;\nL_00E1:\n\tv242 = center + 5;\n\tv243 = v242 / v241;\n\tv244 = v243 * v241;\n\tv245 = v242 - v244;\n\tv246 = v245 + v241;\n\tv247 = v246 / v241;\n\tv248 = v247 * v241;\n\tv249 = v246 - v248;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::EvaluateSegment(this, p, v249, &v56 @ stack_-74_v1 (System.Single), &v58 @ stack_-78_v2 (System.Single));\n\tv260 = v58 < v239;\n\tv268 = ~v260;\n\tif (v268) goto L_010F;\nL_010F:\n\treturn;\n")]
			private void FindClosestSegmentWindowed(float2 p, int center, out int bestSegIdx, out float bestFrac, out float bestDistSq)
			{
				//IL_00e7: Expected O, but got F4
				//IL_0153: Expected O, but got F4
				//IL_0196: Expected O, but got F4
				//IL_01d9: Expected O, but got F4
				//IL_021c: Expected O, but got F4
				//IL_025f: Expected O, but got F4
				//IL_02a2: Expected O, but got F4
				bestSegIdx = default(int);
				bestFrac = default(float);
				bestDistSq = default(float);
				bestDistSq = 3.4028235E+38f;
				bestSegIdx = center;
				bestFrac = 0f;
				int num = center - 1;
				int num2 = sampleCount;
				int num3 = num / sampleCount;
				int num4 = num3 * sampleCount;
				int num5 = num - num4;
				int num6 = num5 + sampleCount;
				int num7 = num6 / sampleCount;
				int num8 = num7 * sampleCount;
				int num9 = num6 - num8;
				EvaluateSegment(p, num9, out var frac, out var distSq);
				object obj = bestDistSq;
				if (distSq < bestDistSq)
				{
					bestDistSq = distSq;
					bestSegIdx = num9;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num10 = center / num2;
				int num11 = num10 * num2;
				int num12 = center - num11;
				int num13 = num12 + num2;
				int num14 = num13 / num2;
				int num15 = num14 * num2;
				int num16 = num13 - num15;
				EvaluateSegment(p, num16, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num16;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num17 = center + 1;
				int num18 = num17 / num2;
				int num19 = num18 * num2;
				int num20 = num17 - num19;
				int num21 = num20 + num2;
				int num22 = num21 / num2;
				int num23 = num22 * num2;
				int num24 = num21 - num23;
				EvaluateSegment(p, num24, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num24;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num25 = center + 2;
				int num26 = num25 / num2;
				int num27 = num26 * num2;
				int num28 = num25 - num27;
				int num29 = num28 + num2;
				int num30 = num29 / num2;
				int num31 = num30 * num2;
				int num32 = num29 - num31;
				EvaluateSegment(p, num32, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num32;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num33 = center + 3;
				int num34 = num33 / num2;
				int num35 = num34 * num2;
				int num36 = num33 - num35;
				int num37 = num36 + num2;
				int num38 = num37 / num2;
				int num39 = num38 * num2;
				int num40 = num37 - num39;
				EvaluateSegment(p, num40, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num40;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num41 = center + 4;
				int num42 = num41 / num2;
				int num43 = num42 * num2;
				int num44 = num41 - num43;
				int num45 = num44 + num2;
				int num46 = num45 / num2;
				int num47 = num46 * num2;
				int num48 = num45 - num47;
				EvaluateSegment(p, num48, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num48;
					bestFrac = frac;
					num2 = sampleCount;
					obj = bestDistSq;
				}
				int num49 = center + 5;
				int num50 = num49 / num2;
				int num51 = num50 * num2;
				int num52 = num49 - num51;
				int num53 = num52 + num2;
				int num54 = num53 / num2;
				int num55 = num54 * num2;
				int num56 = num53 - num55;
				EvaluateSegment(p, num56, out frac, out distSq);
				if (distSq < (float)obj)
				{
					bestDistSq = distSq;
					bestSegIdx = num56;
					bestFrac = frac;
				}
			}

			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x3C84590", Offset = "0x3C84590", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.sampledPoints;\n\tv4 = this.segmentDirs;\n\tv5 = this.segmentInvLenSq;\n\tv12 = p - *([v2 @ X8_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\tv13 = v12 * *([v4 @ X9_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]);\n\t// 10 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv66 = v13 * *([v5 @ X10_v1 (Unity.Collections.NativeArray`1<System.Single>)+i @ X1 (System.Int32)*4]);\n\tv16 = v66 & 0x7FFFFFFF;\n\tv19 = v16 < 0x7F800001;\n\tv20 = ~v19;\n\tv29 = ~v20;\n\tv30 = ~v29;\n\tif (v30) goto L_FFFFFFFF;\n\tv46 = v66 < 1f;\n\tv45 = v66 == 1f;\n\tv35 = v66 == v66;\n\tv36 = 1f == 1f;\n\tv37 = v35 & v36;\n\tv43 = ~v37;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv43 = 0;\nL_FFFFFFFF:\n\tv45 = 0;\nL_FFFFFFFF:\n\tv46 = 0;\n\tgoto L_0034;\nL_FFFFFFFF:\n\tv66 = 1f;\nL_FFFFFFFF:\n\tv66 = 0;\n\tgoto L_0041;\nL_002B:\n\tv49 = v46 == v43;\n\tv50 = ~v49;\n\tv51 = v50 | v45;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\nL_0034:\n\tv56 = v66 < 0;\n\tv63 = ~v56;\n\tif (v63) goto L_0041;\nL_0041:\n\t*([frac @ X2 (System.Single&)]) = v66;\n\tv68 = *([v4 @ X9_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) * v11;\n\tv69 = *([v2 @ X8_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+i @ X1 (System.Int32)*8]) + v68;\n\tv70 = v69 - p;\n\tv71 = v70 * v70;\n\t// 70 NotImplemented \"Instruction FADDP not yet implemented.\"\n\t*([distSq @ X3 (System.Single&)]) = v71;\n\treturn;\n")]
			private void EvaluateSegment(float2 p, int i, out float frac, out float distSq)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob::EvaluateSegment");
				frac = default;
				distSq = default;
			}

			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x3C84554", Offset = "0x3C84554", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 0 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv3 = v1 == maxDelta;\n\tv4 = v1 < maxDelta;\n\tv5 = ~v4;\n\tv10 = ~v5;\n\tv11 = v10 | v3;\n\tif (v11) goto L_0029;\n\tv12 = v34 - current;\n\tv15 = v12 < 0;\n\tv16 = v12 == 0;\n\tv19 = v12 == v12;\n\tv20 = ~v19;\n\tv23 = v15 == v20;\n\tv24 = ~v16;\n\tv25 = v23 & v24;\n\tv26 = ~v25;\n\tif (v26) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = 1f;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv49 = 0;\nL_FFFFFFFF:\n\tv49 = v33;\n\tgoto L_0026;\nL_0029:\n\treturn v34;\nL_001F:\n\tv33 = v49 + -1f;\n\tv28 = v34 >= current;\n\tif (v28) goto L_0026;\nL_0026:\n\tv50 = v49 * maxDelta;\n\tv34 = v50 + current;\n")]
			private static float MoveToward(float current, float target, float maxDelta)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				object obj = default(object);
				bool flag = (float)obj == maxDelta;
				bool flag2 = (float)obj < maxDelta;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				float num2 = default(float);
				if (!(flag4 || flag))
				{
					float num = num2 - current;
					bool flag5 = num < 0f;
					bool flag6 = num == 0f;
					bool flag7 = num == num;
					bool flag8 = !flag7;
					bool flag9 = flag5 == flag8;
					bool flag10 = !flag6;
					float num3 = ((!(flag9 && flag10)) ? 0f : 1f);
					float num4 = num3 + -1f;
					if (num2 < current)
					{
						num3 = num4;
					}
					float num5 = num3 * maxDelta;
					return num5 + current;
				}
				return num2;
			}

			[CompilerGenerated]
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x3C84608", Offset = "0x3C84608", Length = "0x638")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_004A;\n\tv103 = this + 0xE0;\n\tv104 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v103);\n\tv110 = &v118 @ stack_-90_v1 (Unity.Entities.EnabledMask);\n\tv112 = this + 0x108;\n\tv114 = Unity.Entities.ArchetypeChunk::GetEnabledMask(chunk, v112);\n\tv118 = *([v110 @ X8_v6]);\n\tv125 = *([v110 @ X8_v6]);\n\tv118.m_PtrChunkDisabledCount = *([v110 @ X8_v6+10]);\n\tv130 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\n\tv136 = useEnabledMask == 0;\n\tif (v136) goto L_011B;\n\tv142 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv143 = v142 ^ chunkEnabledMask.Byte0;\n\t// 121 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 122 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 123 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 124 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 125 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 126 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv144 = v62 + v143;\n\tv146 = v144 < 5;\n\tv147 = ~v146;\n\tv148 = v144 - 5;\n\tv150 = v148 == 0;\n\tv155 = ~v150;\n\tv156 = v147 & v155;\n\tif (v156) goto L_0163;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv361 = 0;\n\tgoto L_0099;\nL_FFFFFFFF:\n\tv302 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv361 = v644;\n\tv551 = ~v541;\n\tv553 = ~v518;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v229 @ stack_-B0_v12 (Unity.Burst.Intrinsics.v128), v551, v553);\n\tv352 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v229);\n\tv357 = v352 == 0;\n\tif (v357) goto L_021E;\n\tv675 = v518 + v361;\n\tv644 = v352 + v675;\n\tv656 = v675 >= v644;\nL_FFFFFFFF:\n\tv721 = v95;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv733 = v352;\n\tif (v656) goto L_FFFFFFFF;\nL_00CC:\n\t;\n\tv738 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v675);\n\tv783 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v675);\n\tv821 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v721, v675);\n\tv836 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v675);\n\tv850 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v125 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v675);\n\tv674 = v850.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::Execute(this, v738, v783, v821, v836, &v674 @ stack_-B0_v14 (Unity.Entities.SafeBitRef));\n\tv675 = v675 + 1;\n\tv734 = v733 - 1;\n\tv678 = v733 != 1;\nL_FFFFFFFF:\n\tv721 = v95;\nL_FFFFFFFF:\n\tv733 = v734;\n\tif (v678) goto L_00CC;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_FFFFFFFF;\nL_011B:\n\tv167 = v130 < 1;\n\tif (v167) goto L_021E;\nL_FFFFFFFF:\n\tv494 = 0;\n\tv599 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v494);\n\tv632 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v125 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v494);\n\tv231 = v632.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::Execute(this, v501, v524, v548, v599, &v231 @ stack_-B0_v3 (Unity.Entities.SafeBitRef));\n\tv494 = v494 + 1;\n\tv247 = v130 != v494;\n\tif (v247) goto L_012B;\n\tgoto L_021E;\nL_0163:\n\tv182 = v130 - 0x40;\n\tv183 = v182 < 0;\n\tv185 = v130 ^ 0x40;\n\tv186 = v130 ^ v182;\n\tv187 = v185 & v186;\n\tv188 = v187 < 0;\n\tv190 = v183 == v188;\n\tv191 = ~v190;\n\tv192 = ~v191;\n\tif (v192) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv366 = v130;\n\tgoto L_017D;\nL_FFFFFFFF:\n\tv366 = 0x40;\nL_FFFFFFFF:\n\tv370 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv594 = 0;\n\tgoto L_0192;\nL_0186:\n\tv370 = v370 >> 1;\n\tv594 = v594 + 1;\n\tv569 = v366 == v594;\n\tif (v569) goto L_01D3;\nL_0192:\n\tv595 = v370 & 1;\n\tv358 = v595 == 0;\n\tif (v358) goto L_0186;\n\tv606 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v594);\n\tv638 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v594);\n\tv662 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v594);\n\tv747 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v594);\n\tv788 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v125 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v594);\n\tv610 = v788.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::Execute(this, v606, v638, v662, v747, &v610 @ stack_-B0_v5 (Unity.Entities.SafeBitRef));\n\tgoto L_0186;\nL_01D3:\n\tv248 = v130 < 0x41;\n\tif (v248) goto L_021E;\n\tv664 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv363 = v130;\nL_FFFFFFFF:\n\tv775 = 0x40;\n\tgoto L_01E5;\nL_01D9:\n\tv367 = v664 >> 1;\n\tv775 = v775 + 1;\n\tv278 = v363 == v775;\nL_FFFFFFFF:\n\tv664 = v367;\n\tif (v278) goto L_021E;\nL_01E5:\n\tv779 = v664 & 1;\n\tv359 = v779 == 0;\n\tif (v359) goto L_01D9;\n\tv794 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v775);\n\tv828 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v775);\n\tv842 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v775);\n\tv856 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v104, v775);\n\tv862 = Unity.Entities.EnabledMask::GetEnabledRefRW(&v125 @ stack_-D0_v1 (Unity.Entities.EnabledMask), v775);\n\tv798 = v862.m_Ptr;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::Execute(this, v794, v828, v842, v856, &v798 @ stack_-B0_v8 (Unity.Entities.SafeBitRef));\nL_FFFFFFFF:\n\tv363 = v130;\n\tgoto L_01D9;\nL_021E:\n\tv399 = *([A4731E0]);\n\tv410 = *([v399 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v410) goto L_0239;\n\treturn;\nL_0239:\n\tv514 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_004A:\n\tv76 = this + 0x68;\n\tv77 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v76);\n\tv85 = this + 0x90;\n\tv86 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v85);\n\tv94 = this + 0xB8;\n\tv95 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v94);\nL_0099:\n\tv461 = v302;\n\tv465 = Unity.Entities.EnabledBitUtility::ShiftRight(&v461 @ stack_-90_v12 (Unity.Burst.Intrinsics.v128), v361);\n\tv515 = v465;\n\tv518 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v465);\n\tv541 = Unity.Entities.EnabledBitUtility::ShiftRight(&v515 @ stack_-90_v13 (Unity.Burst.Intrinsics.v128), v518);\nL_012B:\n\tv501 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v77, v494);\n\tv524 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v86, v494);\n\tv548 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v95, v494);\nL_017D:\n\tv249 = v130 < 1;\n\tif (v249) goto L_021E;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob::Execute");
			}

			[Token(Token = "0x60003C8")]
			[Address(RVA = "0x3C84C40", Offset = "0x3C84C40", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.BeltJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x60003C9")]
			[Address(RVA = "0x3C84C94", Offset = "0x3C84C94", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CA")]
			[Address(RVA = "0x3C84CA0", Offset = "0x3C84CA0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CB")]
			[Address(RVA = "0x3C84CAC", Offset = "0x3C84CAC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CC")]
			[Address(RVA = "0x3C84CB8", Offset = "0x3C84CB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CD")]
			[Address(RVA = "0x3C84CC4", Offset = "0x3C84CC4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CE")]
			[Address(RVA = "0x3C84CD0", Offset = "0x3C84CD0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003CF")]
			[Address(RVA = "0x3C84CDC", Offset = "0x3C84CDC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D0")]
			[Address(RVA = "0x3C84CE8", Offset = "0x3C84CE8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D1")]
			[Address(RVA = "0x3C84CF4", Offset = "0x3C84CF4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D2")]
			[Address(RVA = "0x3C84D00", Offset = "0x3C84D00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D3")]
			[Address(RVA = "0x3C84D0C", Offset = "0x3C84D0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D4")]
			[Address(RVA = "0x3C84D18", Offset = "0x3C84D18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D5")]
			[Address(RVA = "0x3C84D24", Offset = "0x3C84D24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x3C84D30", Offset = "0x3C84D30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x3C84D3C", Offset = "0x3C84D3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D8")]
			[Address(RVA = "0x3C84D48", Offset = "0x3C84D48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003D9")]
			[Address(RVA = "0x3C84D54", Offset = "0x3C84D54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DA")]
			[Address(RVA = "0x3C84D60", Offset = "0x3C84D60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DB")]
			[Address(RVA = "0x3C84D6C", Offset = "0x3C84D6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DC")]
			[Address(RVA = "0x3C84D78", Offset = "0x3C84D78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DD")]
			[Address(RVA = "0x3C84D84", Offset = "0x3C84D84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DE")]
			[Address(RVA = "0x3C84D90", Offset = "0x3C84D90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x60003DF")]
			[Address(RVA = "0x3C84D9C", Offset = "0x3C84D9C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000CD")]
		private struct TypeHandle
		{
			[Token(Token = "0x40002A6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public EntryJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_EntryJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x40002A7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x88")]
			public BeltJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_BeltJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x40002A8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x160")]
			public CountConveyorParticlesJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_CountConveyorParticlesJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60003EB")]
			[Address(RVA = "0x3C855B0", Offset = "0x3C855B0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData::Init(this, state, 1);\n\tv16 = this + 0x88;\n\tv19 = 0x3C84F20(v16, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv32 = this + 0x88;\n\tv35 = 0x3C850D8(v32, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData::Init(&this.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_CountConveyorParticlesJob_WithDefaultQuery_JobEntityTypeHandle (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData), state, 1);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x400027E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private NativeReference<int> _conveyorCount;

		[Token(Token = "0x400027F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private JobHandle _countHandle;

		[Token(Token = "0x4000280")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		private bool _hasPendingCount;

		[Token(Token = "0x4000281")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x600036C")]
		[Address(RVA = "0x3C81BA8", Offset = "0x3C81BA8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tthis._conveyorCount = v64;\n\tthis._hasPendingCount = 0;\n\treturn;\nL_0020:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\tv58 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(4);\n\tUnity.Collections.NativeReference`1<System.Int32>::.ctor(&v64 @ stack_-50_v2 (Unity.Collections.NativeReference`1<System.Int32>), 0, v58);\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
			AllocatorManager.AllocatorHandle allocator = Allocator.Persistent;
			NativeReference<int> conveyorCount = new NativeReference<int>(0, allocator);
			_conveyorCount = conveyorCount;
			_hasPendingCount = false;
		}

		[Token(Token = "0x600036D")]
		[Address(RVA = "0x3C81C58", Offset = "0x3C81C58", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB78D000;\n\tv14 = *([B78D734]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_0030;\n\tv69 = 0xB2B6000 + 0x28;\n\tv23 = this._hasPendingCount == 1;\n\tv85 = v69;\n\tif (v23) goto L_003F;\nL_001B:\n\tv73 = Unity.Collections.NativeReference`1::get_IsCreated /* +1 sharing this address */(this, *([v69 @ X20_v9 (System.Int32)]));\n\tv90 = v73 == 0;\n\tif (v90) goto L_004D;\nL_0027:\n\tUnity.Collections.NativeReference`1<System.Int32>::Dispose(this);\n\treturn;\nL_0030:\n\t*([v12 @ X20_v1+734]) = 1;\n\tv69 = 0xB2B6000 + 0x28;\n\tv48 = this._hasPendingCount != 1;\n\tv85 = v69;\n\tif (v48) goto L_001B;\nL_003F:\n\t;\n\tUnity.Jobs.JobHandle::Complete(&this._countHandle (Unity.Jobs.JobHandle));\n\tv93 = Unity.Collections.NativeReference`1::get_IsCreated /* +1 sharing this address */(this, *([v85 @ X20_v4 (System.Int32)]));\n\tv138 = v93 == 0;\n\tv109 = ~v138;\n\tif (v109) goto L_0027;\nL_004D:\n\treturn;\n")]
		public void OnDestroy(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::OnDestroy");
		}

		[Token(Token = "0x600036E")]
		[Address(RVA = "0x3C81D10", Offset = "0x3C81D10", Length = "0x59C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv94 = v87.Conveyor;\n\tgoto L_0050;\nL_0050:\n\tv307 = UnityEngine.Object::op_Equality(v87.Conveyor, 0);\n\tv312 = v307 == 0;\n\tif (v312) goto L_006A;\n\tgoto L_01DF;\nL_006A:\n\tv253 = *([v94 @ X21_v5 (UnityEngine.Object)+188]) != 1;\n\tif (v253) goto L_01DF;\n\tv510 = *([v94 @ X21_v5 (UnityEngine.Object)+148]) == 0;\n\tv254 = ~v510;\n\tv242 = ~v254;\n\tif (v242) goto L_FFFFFFFF;\n\tv279 = *([v94 @ X21_v5 (UnityEngine.Object)+150]) == 0;\n\tgoto L_008B;\nL_FFFFFFFF:\n\tv279 = 1;\n\tv251 = this._hasPendingCount != 1;\n\tif (v251) goto L_00A6;\n\tUnity.Jobs.JobHandle::Complete(&this._countHandle (Unity.Jobs.JobHandle));\nL_00A6:\n\tv541 = Unity.Collections.NativeReference`1<System.Int32>::get_Value(this);\n\t_game.CoreSystem.ConveyorSystem.ConveyorController::UpdateGateState(v87.Conveyor, v541);\n\tv225 = state.WorldUnmanaged;\n\tgoto L_00B7;\nL_00B7:\n\tv556 = Unity.Entities.WorldUnmanaged::get_Time(&v225 @ stack_-98_v3 (Unity.Entities.WorldUnmanaged));\n\tv562 = Unity.Entities.SystemState::get_Dependency(state);\n\tv489 = *([v94 @ X21_v5 (UnityEngine.Object)+2C]);\n\tgoto L_00E1;\n\tgoto L_0111;\n\tv621 = &v489 @ stack_-200_v3 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob);\n\tgoto L_0138;\nL_01DF:\n\treturn;\nL_003B:\n\tgoto L_0043;\nL_008B:\n\tif (v279) goto L_01DF;\nL_00E1:\n\tv581 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v581, state);\n\tv587 = this + 0x50;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v587, state);\n\tv594 = this + 0x78;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::Update(v594, state);\nL_0111:\n\tv617 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v489 @ stack_-200_v3 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_EntryJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v562);\n\tv620 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_SampleCount(v87.Conveyor);\n\tv498 = _game.CoreSystem.ConveyorSystem.ConveyorController::get_BeltSpeed(v87.Conveyor);\nL_0138:\n\tv644 = &v489 @ stack_-200_v3 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob) + 0x68;\n\t*([v644 @ X26_v4+A0]) = 0;\n\t*([v644 @ X26_v4+B0]) = 0;\n\t*([v621 @ X24_v5+88]) = 0;\n\t*([v621 @ X24_v5+98]) = 0;\n\t*([v621 @ X24_v5+A8]) = 0;\n\t*([v621 @ X24_v5+B8]) = 0;\n\t*([v621 @ X24_v5+C8]) = 0;\n\t*([v621 @ X24_v5+D8]) = 0;\n\t*([v621 @ X24_v5+E8]) = 0;\n\t*([v621 @ X24_v5+F8]) = 0;\n\tv648 = *([v94 @ X21_v5 (UnityEngine.Object)+148]);\n\tv652 = this + 0xB0;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v652, state);\n\tgoto L_016B;\nL_016B:\n\t*([v644 @ X26_v4+A0]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_BeltJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.___game_CoreSystem_SandPhysics_Components_OnConveyorTag_RW_ComponentTypeHandle;\n\t*([v644 @ X26_v4+B0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+160]);\n\t*([v644 @ X26_v4+C0]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+170]);\n\t*([v644 @ X26_v4+60]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+110]);\n\t*([v644 @ X26_v4+70]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+120]);\n\t*([v644 @ X26_v4+80]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+130]);\n\t*([v644 @ X26_v4+90]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+140]);\n\t*([v644 @ X26_v4+20]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+D0]);\n\t*([v644 @ X26_v4+30]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+E0]);\n\t*([v644 @ X26_v4+40]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+F0]);\n\t*([v644 @ X26_v4+50]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_BeltJob_WithDefaultQuery_JobEntityTypeHandle.__TypeHandle.___game_CoreSystem_SandPhysics_Components_ParticleState_RW_ComponentTypeHandle;\n\t*([v644 @ X26_v4]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_BeltJob_WithDefaultQuery_JobEntityTypeHandle;\n\t*([v644 @ X26_v4+10]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+C0]);\n\tv686 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v648 @ stack_-200_v4 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_BeltJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v617);\n\tUnity.Collections.NativeReference`1<System.Int32>::set_Value(this, 0);\n\tv203 = this._conveyorCount;\n\tv206 = this + 0x188;\n\tgoto L_01A8;\nL_01A8:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v206, state);\n\tgoto L_01C2;\nL_01C2:\n\tv724 = Unity.Entities.JobChunkExtensions::ScheduleByRef(&v203 @ stack_-200_v5 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_CountConveyorParticlesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v686);\n\tthis._countHandle = v724;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+18]) = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_CountConveyorParticlesJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery;\n\tthis._hasPendingCount = 1;\n\tUnity.Entities.SystemState::set_Dependency(state, v724);\nL_0043:\n\tv87 = v86.<Current>k__BackingField;\n\tv88 = v86.<Current>k__BackingField == 0;\n\tif (v88) goto L_01DF;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600036F")]
		[Address(RVA = "0x3C822AC", Offset = "0x3C822AC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tgoto L_0047;\nL_002D:\n\tv66 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v66, state);\n\tv72 = this + 0x50;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(v72, state);\n\tv79 = this + 0x78;\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.OnConveyorTag>::Update(v79, state);\nL_0047:\n\tv94 = job + 0x10;\n\tv95 = this + 0x28;\n\tv97 = 0x8BF6A34(v94, v95, 0x78, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(EntryJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000370")]
		[Address(RVA = "0x3C8247C", Offset = "0x3C8247C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = this + 0xB0;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+BeltJob+InternalCompilerQueryAndHandleData+TypeHandle::Update(v34, state);\n\tgoto L_0024;\nL_0024:\n\tv59 = job + 0x68;\n\tv60 = this + 0xB0;\n\tv62 = 0x8BF6A34(v59, v60, 0xC8, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_1(BeltJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__ScheduleViaJobChunkExtension_1");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000371")]
		[Address(RVA = "0x3C8261C", Offset = "0x3C8261C", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = this + 0x188;\n\tgoto L_0027;\nL_0027:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticleState>::Update(v40, state);\n\tgoto L_0038;\nL_0038:\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob)+30]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+1A8]);\n\tjob.__TypeHandle = this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_ConveyorSystem_CountConveyorParticlesJob_WithDefaultQuery_JobEntityTypeHandle;\n\t*([job @ X1 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob)+20]) = *([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ConveyorSystem)+198]);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_2(CountConveyorParticlesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__ScheduleViaJobChunkExtension_2");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000372")]
		[Address(RVA = "0x3C82758", Offset = "0x3C82758", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x6000373")]
		[Address(RVA = "0x3C8279C", Offset = "0x3C8279C", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv24 = this + 0x28;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData::Init(v24, state, 1);\n\tv28 = this + 0xB0;\n\tv31 = 0x3C84F20(v28, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = this + 0xB0;\n\tv47 = 0x3C850D8(v44, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv48 = this + 0x188;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData::Init(v48, state, 1);\n\treturn;\n")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000374")]
		[Address(RVA = "0x3C819A8", Offset = "0x3C819A8", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tself.m_value = v64;\n\t*([self @ X0 (System.IntPtr)+20]) = 0;\n\treturn;\nL_0020:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\tv58 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(4);\n\tUnity.Collections.NativeReference`1<System.Int32>::.ctor(&v64 @ stack_-50_v2 (Unity.Collections.NativeReference`1<System.Int32>), 0, v58);\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__codegen__OnCreate");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000375")]
		[Address(RVA = "0x3C81A58", Offset = "0x3C81A58", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((ConveyorSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000376")]
		[Address(RVA = "0x3C81A5C", Offset = "0x3C81A5C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB78D000;\n\tv14 = *([B78D734]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_0030;\n\tv69 = 0xB2B6000 + 0x28;\n\tv23 = *([self @ X0 (System.IntPtr)+20]) == 1;\n\tv85 = v69;\n\tif (v23) goto L_003F;\nL_001B:\n\tv73 = Unity.Collections.NativeReference`1::get_IsCreated /* +1 sharing this address */(self, *([v69 @ X20_v9 (System.Int32)]));\n\tv90 = v73 == 0;\n\tif (v90) goto L_004D;\nL_0027:\n\tUnity.Collections.NativeReference`1<System.Int32>::Dispose(self);\n\treturn;\nL_0030:\n\t*([v12 @ X20_v1+734]) = 1;\n\tv69 = 0xB2B6000 + 0x28;\n\tv48 = *([self @ X0 (System.IntPtr)+20]) != 1;\n\tv85 = v69;\n\tif (v48) goto L_001B;\nL_003F:\n\tv86 = self + 0x10;\n\tUnity.Jobs.JobHandle::Complete(v86);\n\tv93 = Unity.Collections.NativeReference`1::get_IsCreated /* +1 sharing this address */(self, *([v85 @ X20_v4 (System.Int32)]));\n\tv138 = v93 == 0;\n\tv109 = ~v138;\n\tif (v109) goto L_0027;\nL_004D:\n\treturn;\n")]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__codegen__OnDestroy");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000377")]
		[Address(RVA = "0x3C81B14", Offset = "0x3C81B14", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = 0;\n\tv18 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder), v18);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v14 @ stack_-30_v1 (Unity.Entities.EntityQueryBuilder));\n\tv24 = self + 0x28;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+EntryJob+InternalCompilerQueryAndHandleData::Init(v24, state, 1);\n\tv28 = self + 0xB0;\n\tv31 = 0x3C84F20(v28, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv44 = self + 0xB0;\n\tv47 = 0x3C850D8(v44, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv48 = self + 0x188;\n\t_game.CoreSystem.SandPhysics.Systems.ConveyorSystem+CountConveyorParticlesJob+InternalCompilerQueryAndHandleData::Init(v48, state, 1);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorSystem::__codegen__OnCreateForCompiler");
		}
	}
}
