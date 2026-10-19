using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Jobs;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004AC")]
	internal struct FindCandidatesJob : IJobEntity, IJobChunk
	{
		[Token(Token = "0x20004AD")]
		public struct InternalCompilerQueryAndHandleData
		{
			[Token(Token = "0x20004AE")]
			public struct TypeHandle
			{
				[ReadOnly]
				[Token(Token = "0x4000FBA")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[ReadOnly]
				[Token(Token = "0x4000FBB")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RO_ComponentTypeHandle;

				[ReadOnly]
				[Token(Token = "0x4000FBC")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
				public ComponentTypeHandle<ParticleGameColor> ___game_CoreSystem_SandPhysics_Components_ParticleGameColor_RO_ComponentTypeHandle;

				[ReadOnly]
				[Token(Token = "0x4000FBD")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
				public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60013AD")]
				[Address(RVA = "0x3CEE440", Offset = "0x3CEE440", Length = "0x114")]
				public void __AssignHandles(ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
				}

				[Token(Token = "0x60013AE")]
				[Address(RVA = "0x3CED3B0", Offset = "0x3CED3B0", Length = "0xBC")]
				public void Update(ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
				}
			}

			[Token(Token = "0x4000FB8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public TypeHandle __TypeHandle;

			[Token(Token = "0x4000FB9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013A5")]
			[Address(RVA = "0x3CEE074", Offset = "0x3CEE074", Length = "0x208")]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
				AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
				entityQueryBuilder = new EntityQueryBuilder(allocator);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticlePosition>();
				EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
				EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleGameColor>();
				entityQueryBuilder3 = entityQueryBuilder4;
				EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<ParticleState>();
				entityQueryBuilder3 = entityQueryBuilder5;
				EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
				DefaultQuery = defaultQuery;
				EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			[Token(Token = "0x60013A6")]
			[Address(RVA = "0x3CED754", Offset = "0x3CED754", Length = "0x128")]
			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData::Init");
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013A7")]
			[Address(RVA = "0x3CEE27C", Offset = "0x3CEE27C", Length = "0x80")]
			public unsafe void Run(ref FindCandidatesJob job, EntityQuery query)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData::Run");
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013A8")]
			[Address(RVA = "0x3CEE2FC", Offset = "0x3CEE2FC", Length = "0x98")]
			public unsafe JobHandle Schedule(ref FindCandidatesJob job, EntityQuery query, JobHandle dependency)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData::Schedule");
				return default;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013A9")]
			[Address(RVA = "0x3CEE394", Offset = "0x3CEE394", Length = "0x98")]
			public unsafe JobHandle ScheduleParallel(ref FindCandidatesJob job, EntityQuery query, JobHandle dependency)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
				return default;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013AA")]
			[Address(RVA = "0x3CEE42C", Offset = "0x3CEE42C", Length = "0x4")]
			public void UpdateBaseEntityIndexArray(ref FindCandidatesJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013AB")]
			[Address(RVA = "0x3CEE430", Offset = "0x3CEE430", Length = "0xC")]
			public JobHandle UpdateBaseEntityIndexArray(ref FindCandidatesJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013AC")]
			[Address(RVA = "0x3CEE43C", Offset = "0x3CEE43C", Length = "0x4")]
			public void AssignEntityManager(ref FindCandidatesJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x20004AF")]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Token(Token = "0x60013AF")]
			[Address(RVA = "0x3CEE554", Offset = "0x3CEE554", Length = "0x4")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		[Token(Token = "0x4000FB4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public NativeArray<AbsorptionZone> zones;

		[Token(Token = "0x4000FB5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public int columnCount;

		[Token(Token = "0x4000FB6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public NativeQueue<AbsorptionRequest>.ParallelWriter requests;

		[Token(Token = "0x4000FB7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		internal InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[Token(Token = "0x600138B")]
		[Address(RVA = "0x3CED8B4", Offset = "0x3CED8B4", Length = "0x168")]
		private unsafe void Execute(Entity entity, in ParticlePosition pos, in ParticleGameColor color, in ParticleState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob::Execute");
		}

		[CompilerGenerated]
		[Token(Token = "0x600138C")]
		[Address(RVA = "0x3CEDA1C", Offset = "0x3CEDA1C", Length = "0x4F8")]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob::Execute");
		}

		[Token(Token = "0x600138D")]
		[Address(RVA = "0x3CEDF14", Offset = "0x3CEDF14", Length = "0x54")]
		private JobHandle __ThrowCodeGenException()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FindCandidatesJob::__ThrowCodeGenException");
			return default;
		}

		[Token(Token = "0x600138E")]
		[Address(RVA = "0x3CEDF68", Offset = "0x3CEDF68", Length = "0xC")]
		public void Run()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x600138F")]
		[Address(RVA = "0x3CEDF74", Offset = "0x3CEDF74", Length = "0xC")]
		public void RunByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001390")]
		[Address(RVA = "0x3CEDF80", Offset = "0x3CEDF80", Length = "0xC")]
		public void Run(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001391")]
		[Address(RVA = "0x3CEDF8C", Offset = "0x3CEDF8C", Length = "0xC")]
		public void RunByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001392")]
		[Address(RVA = "0x3CEDF98", Offset = "0x3CEDF98", Length = "0xC")]
		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x6001393")]
		[Address(RVA = "0x3CEDFA4", Offset = "0x3CEDFA4", Length = "0xC")]
		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x6001394")]
		[Address(RVA = "0x3CEDFB0", Offset = "0x3CEDFB0", Length = "0xC")]
		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x6001395")]
		[Address(RVA = "0x3CEDFBC", Offset = "0x3CEDFBC", Length = "0xC")]
		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x6001396")]
		[Address(RVA = "0x3CEDFC8", Offset = "0x3CEDFC8", Length = "0xC")]
		public void Schedule()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001397")]
		[Address(RVA = "0x3CEDFD4", Offset = "0x3CEDFD4", Length = "0xC")]
		public void ScheduleByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001398")]
		[Address(RVA = "0x3CEDFE0", Offset = "0x3CEDFE0", Length = "0xC")]
		public void Schedule(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x6001399")]
		[Address(RVA = "0x3CEDFEC", Offset = "0x3CEDFEC", Length = "0xC")]
		public void ScheduleByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x600139A")]
		[Address(RVA = "0x3CEDFF8", Offset = "0x3CEDFF8", Length = "0xC")]
		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x600139B")]
		[Address(RVA = "0x3CEE004", Offset = "0x3CEE004", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x600139C")]
		[Address(RVA = "0x3CEE010", Offset = "0x3CEE010", Length = "0xC")]
		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x600139D")]
		[Address(RVA = "0x3CEE01C", Offset = "0x3CEE01C", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x600139E")]
		[Address(RVA = "0x3CEE028", Offset = "0x3CEE028", Length = "0xC")]
		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x600139F")]
		[Address(RVA = "0x3CEE034", Offset = "0x3CEE034", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013A0")]
		[Address(RVA = "0x3CEE040", Offset = "0x3CEE040", Length = "0xC")]
		public void ScheduleParallel()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013A1")]
		[Address(RVA = "0x3CEE04C", Offset = "0x3CEE04C", Length = "0xC")]
		public void ScheduleParallelByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013A2")]
		[Address(RVA = "0x3CEE058", Offset = "0x3CEE058", Length = "0xC")]
		public void ScheduleParallel(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013A3")]
		[Address(RVA = "0x3CEE064", Offset = "0x3CEE064", Length = "0xC")]
		public void ScheduleParallelByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013A4")]
		[Address(RVA = "0x3CEE070", Offset = "0x3CEE070", Length = "0x4")]
		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
