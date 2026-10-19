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
using Unity.Transforms;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(IntegratePositionSystem))]
	[Token(Token = "0x20000F9")]
	public struct SyncTransformSystem : ISystem, ISystemCompilerGenerated
	{
		[WithAll(new Type[] { typeof(SandParticle) })]
		[Token(Token = "0x20000FA")]
		private struct SyncJob : IJobEntity, IJobChunk
		{
			[Token(Token = "0x20000FB")]
			public struct InternalCompilerQueryAndHandleData
			{
				[Token(Token = "0x20000FC")]
				public struct TypeHandle
				{
					[ReadOnly]
					[Token(Token = "0x400033E")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
					public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

					[Token(Token = "0x400033F")]
					[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
					public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

					[MethodImpl(MethodImplOptions.AggressiveInlining)]
					[Token(Token = "0x600055C")]
					[Address(RVA = "0x3DA62B0", Offset = "0x3DA62B0", Length = "0xC4")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv53 = &v60 @ stack_-68_v1 (Unity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>);\n\tv57 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData+TypeHandle)+20]) = *([v53 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle = *([v53 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData+TypeHandle)+10]) = *([v53 @ X8_v3+10]);\n\tv78 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\tthis.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle = v78.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData+TypeHandle)+38]) = v78.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData+TypeHandle)+48]) = v78.m_Length;\n\treturn;\n")]
					public void __AssignHandles(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
					}

					[Token(Token = "0x600055D")]
					[Address(RVA = "0x3DA578C", Offset = "0x3DA578C", Length = "0x88")]
					[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tUnity.Entities.ComponentTypeHandle`1<Unity.Transforms.LocalTransform>::Update(&this.__Unity_Transforms_LocalTransform_RW_ComponentTypeHandle (Unity.Entities.ComponentTypeHandle`1<Unity.Transforms.LocalTransform>), state);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
					public void Update(ref SystemState state)
					{
						global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
					}
				}

				[Token(Token = "0x400033C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public TypeHandle __TypeHandle;

				[Token(Token = "0x400033D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				public EntityQuery DefaultQuery;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000554")]
				[Address(RVA = "0x3DA5E0C", Offset = "0x3DA5E0C", Length = "0x208")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv70 = v69;\n\tv74 = Unity.Entities.EntityQueryBuilder::WithAll(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tv70 = v74;\n\tv79 = Unity.Entities.EntityQueryBuilder::WithAllRW(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder));\n\tv70 = v79;\n\tv85 = Unity.Entities.EntityQueryBuilder::Build(&v70 @ stack_-60_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.DefaultQuery = v85;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+58]) = state;\n\tv88 = Unity.Entities.EntityQueryBuilder::Reset(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0023:\n\tv54 = 0;\n\tv58 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), v58);\n\tv69 = Unity.Entities.EntityQueryBuilder::WithAll(&v54 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder));\n")]
				private void __AssignQueries(ref SystemState state)
				{
					EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
					AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
					entityQueryBuilder = new EntityQueryBuilder(allocator);
					EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
					EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
					EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<SandParticle>();
					entityQueryBuilder3 = entityQueryBuilder4;
					EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<LocalTransform>();
					entityQueryBuilder3 = entityQueryBuilder5;
					EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
					DefaultQuery = defaultQuery;
					EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder.Reset();
					entityQueryBuilder.Dispose();
				}

				[Token(Token = "0x6000555")]
				[Address(RVA = "0x3DA6014", Offset = "0x3DA6014", Length = "0xD8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = ~assignDefaultQuery;\n\tif (v22) goto L_001B;\n\tv27 = 0x3DA5F10(this, state, 0, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_001B:\n\tgoto L_0025;\nL_0025:\n\tv61 = &v68 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData+TypeHandle);\n\tv65 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+20]) = *([v61 @ X8_v3+20]);\n\tthis.__TypeHandle = *([v61 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+10]) = *([v61 @ X8_v3+10]);\n\tv86 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+28]) = v86.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+38]) = v86.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData)+48]) = v86.m_Length;\n\treturn;\n")]
				public void Init(ref SystemState state, bool assignDefaultQuery)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob.InternalCompilerQueryAndHandleData::Init");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000556")]
				[Address(RVA = "0x3DA60EC", Offset = "0x3DA60EC", Length = "0x80")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tv54 = 0x8BF6A34(job, this, 0x50, query.__seqno, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tUnity.Entities.JobChunkExtensions::RunByRef(job, query);\n\treturn;\n")]
				public void Run(ref SyncJob job, EntityQuery query)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					JobChunkExtensions.RunByRef(ref job, query);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000557")]
				[Address(RVA = "0x3DA616C", Offset = "0x3DA616C", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv60 = 0x8BF6A34(job, this, 0x50, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public JobHandle Schedule(ref SyncJob job, EntityQuery query, JobHandle dependency)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					return JobChunkExtensions.ScheduleByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000558")]
				[Address(RVA = "0x3DA6204", Offset = "0x3DA6204", Length = "0x98")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv60 = 0x8BF6A34(job, this, 0x50, query.__seqno, dependency, dependency.version, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
				public JobHandle ScheduleParallel(ref SyncJob job, EntityQuery query, JobHandle dependency)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					return JobChunkExtensions.ScheduleParallelByRef(ref job, query, dependency);
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6000559")]
				[Address(RVA = "0x3DA629C", Offset = "0x3DA629C", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void UpdateBaseEntityIndexArray(ref SyncJob job, EntityQuery query, ref SystemState state)
				{
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600055A")]
				[Address(RVA = "0x3DA62A0", Offset = "0x3DA62A0", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn dependency;\n")]
				public JobHandle UpdateBaseEntityIndexArray(ref SyncJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
				{
					return dependency;
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600055B")]
				[Address(RVA = "0x3DA62AC", Offset = "0x3DA62AC", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public void AssignEntityManager(ref SyncJob job, EntityManager entityManager)
				{
				}
			}

			[StructLayout((LayoutKind)0, Size = 1)]
			[Token(Token = "0x20000FD")]
			public struct InternalCompiler
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
				[Token(Token = "0x600055E")]
				[Address(RVA = "0x3DA6374", Offset = "0x3DA6374", Length = "0x4")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
				public static void CheckForErrors(int scheduleType)
				{
				}
			}

			[Token(Token = "0x400033B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

			[Token(Token = "0x600053A")]
			[Address(RVA = "0x3DA5958", Offset = "0x3DA5958", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\ttransform.Position = pos.value;\n\treturn;\n")]
			private void Execute(in ParticlePosition pos, ref LocalTransform transform)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob::Execute");
			}

			[CompilerGenerated]
			[Token(Token = "0x600053B")]
			[Address(RVA = "0x3DA5964", Offset = "0x3DA5964", Length = "0x348")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tgoto L_0032;\n\tv91 = useEnabledMask == 0;\n\tif (v91) goto L_00B2;\n\tv93 = chunkEnabledMask.Byte0 + chunkEnabledMask.Byte0;\n\tv94 = v93 ^ chunkEnabledMask.Byte0;\n\t// 68 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 69 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 70 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 71 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 72 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 73 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv95 = v56 + v94;\n\tv97 = v95 < 5;\n\tv98 = ~v97;\n\tv99 = v95 - 5;\n\tv101 = v99 == 0;\n\tv106 = ~v101;\n\tv107 = v98 & v106;\n\tif (v107) goto L_00D4;\nL_FFFFFFFF:\n\tv220 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv252 = 0;\n\tgoto L_005F;\nL_FFFFFFFF:\n\tv220 = chunkEnabledMask.Byte0;\n\tv374 = ~v367;\n\tv376 = ~v345;\n\tUnity.Burst.Intrinsics.v128::.ctor(&v150 @ stack_-90_v4 (Unity.Burst.Intrinsics.v128), v374, v376);\n\tv234 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v150);\n\tv239 = v234 == 0;\n\tif (v239) goto L_0140;\n\tv456 = v345 + v252;\n\tv252 = v234 + v456;\n\tv429 = v456 >= v252;\nL_FFFFFFFF:\n\tv460 = v234;\n\tif (v429) goto L_FFFFFFFF;\nL_0091:\n\tv465 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v70, v456);\n\tv455 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v79, v456);\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::Execute(v455, v465, v455);\n\tv456 = v456 + 1;\n\tv461 = v460 - 1;\n\tv433 = v460 != 1;\nL_FFFFFFFF:\n\tv460 = v461;\n\tif (v433) goto L_0091;\n\tgoto L_FFFFFFFF;\nL_00B2:\n\tv118 = v86 < 1;\n\tif (v118) goto L_0140;\nL_FFFFFFFF:\n\tv324 = 0;\n\tv324 = v324 + 1;\n\tv167 = v86 != v324;\n\tif (v167) goto L_00BC;\n\tgoto L_0140;\nL_00D4:\n\tv126 = v86 - 0x40;\n\tv127 = v126 < 0;\n\tv129 = v86 ^ 0x40;\n\tv130 = v86 ^ v126;\n\tv131 = v129 & v130;\n\tv132 = v131 < 0;\n\tv134 = v127 == v132;\n\tv135 = ~v134;\n\tv136 = ~v135;\n\tif (v136) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv162 = v86;\n\tgoto L_00EE;\nL_FFFFFFFF:\n\tv162 = 0x40;\nL_FFFFFFFF:\n\tv143 = chunkEnabledMask.Byte0;\nL_FFFFFFFF:\n\tv400 = 0;\n\tgoto L_0103;\nL_00F7:\n\tv143 = v143 >> 1;\n\tv400 = v400 + 1;\n\tv388 = v162 == v400;\n\tif (v388) goto L_011D;\nL_0103:\n\tv401 = v143 & 1;\n\tv240 = v401 == 0;\n\tif (v240) goto L_00F7;\n\tv407 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v70, v400);\n\tv410 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v79, v400);\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::Execute(v410, v407, v410);\n\tgoto L_00F7;\nL_011D:\n\tv168 = v86 < 0x41;\n\tif (v168) goto L_0140;\n\tv430 = chunkEnabledMask.Byte8;\nL_FFFFFFFF:\n\tv480 = 0x40;\n\tgoto L_012E;\nL_0122:\n\tv245 = v430 >> 1;\n\tv480 = v480 + 1;\n\tv198 = v86 == v480;\nL_FFFFFFFF:\n\tv430 = v245;\n\tif (v198) goto L_0140;\nL_012E:\n\tv481 = v430 & 1;\n\tv241 = v481 == 0;\n\tif (v241) goto L_0122;\n\tv488 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v70, v480);\n\tv491 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v79, v480);\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::Execute(v491, v488, v491);\n\tgoto L_0122;\nL_0140:\n\tv263 = *([A4731E0]);\n\tv274 = *([v263 @ X9_v3]) != *([v35 @ X8_v2]);\n\tif (v274) goto L_015B;\n\treturn;\nL_015B:\n\tv341 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0032:\n\tv70 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayReadOnlyIntPtr(chunk.m_Chunk, this);\n\tv78 = this + 0x28;\n\tv79 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetChunkNativeArrayIntPtr(chunk.m_Chunk, v78);\n\tv86 = Unity.Entities.ArchetypeChunk::get_Count(chunk);\nL_005F:\n\tv304 = v220;\n\tv308 = Unity.Entities.EnabledBitUtility::ShiftRight(&v304 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v252);\n\tv304 = v308;\n\tv345 = Unity.Entities.EnabledBitUtility::tzcnt_u128(v308);\n\tv367 = Unity.Entities.EnabledBitUtility::ShiftRight(&v304 @ stack_-80_v3 (Unity.Burst.Intrinsics.v128), v345);\nL_00BC:\n\tv328 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v70, v324);\n\tv235 = Unity.Entities.Internal.InternalCompilerInterface::UnsafeGetRefToNativeArrayPtrElement(v79, v324);\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::Execute(v235, v328, v235);\nL_00EE:\n\tv169 = v86 < 1;\n\tif (v169) goto L_0140;\n")]
			public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob::Execute");
			}

			[Token(Token = "0x600053C")]
			[Address(RVA = "0x3DA5CAC", Offset = "0x3DA5CAC", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB28E000 + 0x98;\n\tv27 = new v10();\n\tv30 = 0xB2FF000 + 0xB40;\n\tSystem.Exception::.ctor(v27, v30);\n\tthrow v27;\n")]
			private JobHandle __ThrowCodeGenException()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.SyncJob::__ThrowCodeGenException");
				return default;
			}

			[Token(Token = "0x600053D")]
			[Address(RVA = "0x3DA5D00", Offset = "0x3DA5D00", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600053E")]
			[Address(RVA = "0x3DA5D0C", Offset = "0x3DA5D0C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x600053F")]
			[Address(RVA = "0x3DA5D18", Offset = "0x3DA5D18", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Run(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000540")]
			[Address(RVA = "0x3DA5D24", Offset = "0x3DA5D24", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void RunByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000541")]
			[Address(RVA = "0x3DA5D30", Offset = "0x3DA5D30", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000542")]
			[Address(RVA = "0x3DA5D3C", Offset = "0x3DA5D3C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000543")]
			[Address(RVA = "0x3DA5D48", Offset = "0x3DA5D48", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000544")]
			[Address(RVA = "0x3DA5D54", Offset = "0x3DA5D54", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x6000545")]
			[Address(RVA = "0x3DA5D60", Offset = "0x3DA5D60", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000546")]
			[Address(RVA = "0x3DA5D6C", Offset = "0x3DA5D6C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000547")]
			[Address(RVA = "0x3DA5D78", Offset = "0x3DA5D78", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void Schedule(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000548")]
			[Address(RVA = "0x3DA5D84", Offset = "0x3DA5D84", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000549")]
			[Address(RVA = "0x3DA5D90", Offset = "0x3DA5D90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054A")]
			[Address(RVA = "0x3DA5D9C", Offset = "0x3DA5D9C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054B")]
			[Address(RVA = "0x3DA5DA8", Offset = "0x3DA5DA8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054C")]
			[Address(RVA = "0x3DA5DB4", Offset = "0x3DA5DB4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054D")]
			[Address(RVA = "0x3DA5DC0", Offset = "0x3DA5DC0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054E")]
			[Address(RVA = "0x3DA5DCC", Offset = "0x3DA5DCC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn returnVal1;\n")]
			public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
			{
				return __ThrowCodeGenException();
			}

			[Token(Token = "0x600054F")]
			[Address(RVA = "0x3DA5DD8", Offset = "0x3DA5DD8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000550")]
			[Address(RVA = "0x3DA5DE4", Offset = "0x3DA5DE4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef()
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000551")]
			[Address(RVA = "0x3DA5DF0", Offset = "0x3DA5DF0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallel(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000552")]
			[Address(RVA = "0x3DA5DFC", Offset = "0x3DA5DFC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = _game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::__ThrowCodeGenException(this);\n\treturn;\n")]
			public void ScheduleParallelByRef(EntityQuery query)
			{
				JobHandle jobHandle = __ThrowCodeGenException();
			}

			[Token(Token = "0x6000553")]
			[Address(RVA = "0x3DA5E08", Offset = "0x3DA5E08", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob::Execute(this, chunk, unfilteredChunkIndex, useEnabledMask, chunkEnabledMask);\n\treturn;\n")]
			void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
			{
				Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
			}
		}

		[Token(Token = "0x20000FE")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000340")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public SyncJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_SandPhysics_Systems_SyncTransformSystem_SyncJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x600055F")]
			[Address(RVA = "0x3DA6378", Offset = "0x3DA6378", Length = "0xCC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = 0x3DA5F10(this, state, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_0021;\nL_0021:\n\tv54 = &v61 @ stack_-68_v1 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob+InternalCompilerQueryAndHandleData);\n\tv58 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+TypeHandle)+20]) = *([v54 @ X8_v3+20]);\n\tthis.___game_CoreSystem_SandPhysics_Systems_SyncTransformSystem_SyncJob_WithDefaultQuery_JobEntityTypeHandle = *([v54 @ X8_v3]);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+TypeHandle)+10]) = *([v54 @ X8_v3+10]);\n\tv79 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+TypeHandle)+28]) = v79.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+TypeHandle)+38]) = v79.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+TypeHandle)+48]) = v79.m_Length;\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x400033A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x6000532")]
		[Address(RVA = "0x3DA5504", Offset = "0x3DA5504", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<SandParticle>();
		}

		[Token(Token = "0x6000533")]
		[Address(RVA = "0x3DA5558", Offset = "0x3DA5558", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = Unity.Entities.SystemState::get_Dependency(state);\n\tgoto L_002C;\nL_002C:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tv73 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<Unity.Transforms.LocalTransform>::Update(v73, state);\n\tgoto L_0046;\nL_0046:\n\tv96 = this.__TypeHandle;\n\tv104 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(&v96 @ stack_-B0_v1 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem+SyncJob), this.__TypeHandle.___game_CoreSystem_SandPhysics_Systems_SyncTransformSystem_SyncJob_WithDefaultQuery_JobEntityTypeHandle.DefaultQuery, v34);\n\tUnity.Entities.SystemState::set_Dependency(state, v104);\n\treturn;\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000534")]
		[Address(RVA = "0x3DA568C", Offset = "0x3DA568C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\tUnity.Entities.ComponentTypeHandle`1<_game.CoreSystem.SandPhysics.Components.ParticlePosition>::Update(this, state);\n\tv71 = this + 0x28;\n\tUnity.Entities.ComponentTypeHandle`1<Unity.Transforms.LocalTransform>::Update(v71, state);\n\tgoto L_0041;\nL_0041:\n\tv89 = 0x8BF6A34(job, this, 0x50, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = Unity.Entities.JobChunkExtensions::ScheduleParallelByRef(job, query, dependency);\n\treturn returnVal1;\n")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(SyncJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000535")]
		[Address(RVA = "0x3DA5814", Offset = "0x3DA5814", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = 0;\n\tv10 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder), v10);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v6 @ stack_-20_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x6000536")]
		[Address(RVA = "0x3DA5858", Offset = "0x3DA5858", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = 0;\n\tv26 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v22 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder), v26);\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v22 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder));\n\tv35 = 0x3DA5F10(this, state, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_002F;\nL_002F:\n\tv66 = &v22 @ stack_-68_v1 (Unity.Entities.EntityQueryBuilder);\n\tv69 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 1);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem)+20]) = *([v66 @ X8_v3+20]);\n\tthis.__TypeHandle = v22._builderDataPtr;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem)+10]) = *([v66 @ X8_v3+10]);\n\tv90 = Unity.Entities.SystemState::GetComponentTypeHandle(state, 0);\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem)+28]) = v90.m_LookupCache;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem)+38]) = v90.m_TypeIndex;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem)+48]) = v90.m_Length;\n\treturn;\n")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000537")]
		[Address(RVA = "0x3DA54A8", Offset = "0x3DA54A8", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<SandParticle>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000538")]
		[Address(RVA = "0x3DA54FC", Offset = "0x3DA54FC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((SyncTransformSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6000539")]
		[Address(RVA = "0x3DA5500", Offset = "0x3DA5500", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SyncTransformSystem::OnCreateForCompiler(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SyncTransformSystem::__codegen__OnCreateForCompiler");
		}
	}
}
