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
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.MoldSystem
{
	[Token(Token = "0x20004B0")]
	internal struct AttractToMoldJob : IJobEntity, IJobChunk
	{
		[Token(Token = "0x20004B1")]
		public struct InternalCompilerQueryAndHandleData
		{
			[Token(Token = "0x20004B2")]
			public struct TypeHandle
			{
				[ReadOnly]
				[Token(Token = "0x4000FCC")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;

				[Token(Token = "0x4000FCD")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public ComponentTypeHandle<ParticlePosition> ___game_CoreSystem_SandPhysics_Components_ParticlePosition_RW_ComponentTypeHandle;

				[Token(Token = "0x4000FCE")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
				public ComponentTypeHandle<ParticleVelocity> ___game_CoreSystem_SandPhysics_Components_ParticleVelocity_RW_ComponentTypeHandle;

				[ReadOnly]
				[Token(Token = "0x4000FCF")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
				public ComponentTypeHandle<ParticleGameColor> ___game_CoreSystem_SandPhysics_Components_ParticleGameColor_RO_ComponentTypeHandle;

				[ReadOnly]
				[Token(Token = "0x4000FD0")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
				public ComponentTypeHandle<ParticleState> ___game_CoreSystem_SandPhysics_Components_ParticleState_RO_ComponentTypeHandle;

				[Token(Token = "0x4000FD1")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA8")]
				public ComponentTypeHandle<AbsorptionArcData> ___game_CoreSystem_SandPhysics_Components_AbsorptionArcData_RW_ComponentTypeHandle;

				[Token(Token = "0x4000FD2")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xD0")]
				public ComponentTypeHandle<LocalTransform> __Unity_Transforms_LocalTransform_RW_ComponentTypeHandle;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x60013D4")]
				[Address(RVA = "0x3CEF938", Offset = "0x3CEF938", Length = "0x1DC")]
				public void __AssignHandles(ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob.InternalCompilerQueryAndHandleData.TypeHandle::__AssignHandles");
				}

				[Token(Token = "0x60013D5")]
				[Address(RVA = "0x3CED510", Offset = "0x3CED510", Length = "0x138")]
				public void Update(ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob.InternalCompilerQueryAndHandleData.TypeHandle::Update");
				}
			}

			[Token(Token = "0x4000FCA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public TypeHandle __TypeHandle;

			[Token(Token = "0x4000FCB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
			public EntityQuery DefaultQuery;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013CC")]
			[Address(RVA = "0x3CEF298", Offset = "0x3CEF298", Length = "0x4DC")]
			private void __AssignQueries(ref SystemState state)
			{
				EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
				AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
				entityQueryBuilder = new EntityQueryBuilder(allocator);
				EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ParticleGameColor>();
				EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
				EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleState>();
				entityQueryBuilder3 = entityQueryBuilder4;
				EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
				entityQueryBuilder3 = entityQueryBuilder5;
				EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
				entityQueryBuilder3 = entityQueryBuilder6;
				EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<AbsorptionArcData>();
				entityQueryBuilder3 = entityQueryBuilder7;
				EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithAllRW<LocalTransform>();
				entityQueryBuilder3 = entityQueryBuilder8;
				EntityQuery defaultQuery = entityQueryBuilder3.Build(ref state);
				DefaultQuery = defaultQuery;
				EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
				entityQueryBuilder.Dispose();
			}

			[Token(Token = "0x60013CD")]
			[Address(RVA = "0x3CED87C", Offset = "0x3CED87C", Length = "0x38")]
			public void Init(ref SystemState state, bool assignDefaultQuery)
			{
				if (assignDefaultQuery)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3CEF418 (inside _game.CoreSystem.MoldSystem.AttractToMoldJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x180)");
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3CEF598 (inside _game.CoreSystem.MoldSystem.AttractToMoldJob+InternalCompilerQueryAndHandleData::__AssignQueries +0x300)");
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013CE")]
			[Address(RVA = "0x3CEF774", Offset = "0x3CEF774", Length = "0x80")]
			public unsafe void Run(ref AttractToMoldJob job, EntityQuery query)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob.InternalCompilerQueryAndHandleData::Run");
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013CF")]
			[Address(RVA = "0x3CEF7F4", Offset = "0x3CEF7F4", Length = "0x98")]
			public unsafe JobHandle Schedule(ref AttractToMoldJob job, EntityQuery query, JobHandle dependency)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob.InternalCompilerQueryAndHandleData::Schedule");
				return default;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013D0")]
			[Address(RVA = "0x3CEF88C", Offset = "0x3CEF88C", Length = "0x98")]
			public unsafe JobHandle ScheduleParallel(ref AttractToMoldJob job, EntityQuery query, JobHandle dependency)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob.InternalCompilerQueryAndHandleData::ScheduleParallel");
				return default;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013D1")]
			[Address(RVA = "0x3CEF924", Offset = "0x3CEF924", Length = "0x4")]
			public void UpdateBaseEntityIndexArray(ref AttractToMoldJob job, EntityQuery query, ref SystemState state)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013D2")]
			[Address(RVA = "0x3CEF928", Offset = "0x3CEF928", Length = "0xC")]
			public JobHandle UpdateBaseEntityIndexArray(ref AttractToMoldJob job, EntityQuery query, JobHandle dependency, ref SystemState state)
			{
				return dependency;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60013D3")]
			[Address(RVA = "0x3CEF934", Offset = "0x3CEF934", Length = "0x4")]
			public void AssignEntityManager(ref AttractToMoldJob job, EntityManager entityManager)
			{
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x20004B3")]
		public struct InternalCompiler
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
			[Token(Token = "0x60013D6")]
			[Address(RVA = "0x3CEFB14", Offset = "0x3CEFB14", Length = "0x4")]
			public static void CheckForErrors(int scheduleType)
			{
			}
		}

		[ReadOnly]
		[Token(Token = "0x4000FBE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public NativeArray<float2> entityPourPoints;

		[ReadOnly]
		[Token(Token = "0x4000FBF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public NativeArray<float> entityPourPointsZ;

		[ReadOnly]
		[Token(Token = "0x4000FC0")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public NativeArray<float> entityFillRatios;

		[ReadOnly]
		[Token(Token = "0x4000FC1")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public NativeArray<float> easeCurve;

		[ReadOnly]
		[Token(Token = "0x4000FC2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public NativeArray<float> dispatchScaleCurve;

		[Token(Token = "0x4000FC3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public float defaultParticleScale;

		[Token(Token = "0x4000FC4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x54")]
		public float fillTargetBase;

		[Token(Token = "0x4000FC5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x58")]
		public float fillTargetHeight;

		[Token(Token = "0x4000FC6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x5C")]
		public float deltaTime;

		[Token(Token = "0x4000FC7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public NativeQueue<ArrivalRequest>.ParallelWriter arrivals;

		[Token(Token = "0x4000FC8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		public NativeQueue<Entity>.ParallelWriter cancellations;

		[Token(Token = "0x4000FC9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
		private InternalCompilerQueryAndHandleData.TypeHandle __TypeHandle;

		[Token(Token = "0x60013B0")]
		[Address(RVA = "0x3CEE558", Offset = "0x3CEE558", Length = "0x348")]
		private unsafe void Execute(Entity entity, ref ParticlePosition pos, ref ParticleVelocity vel, in ParticleGameColor color, in ParticleState state, ref AbsorptionArcData arcData, ref LocalTransform lt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob::Execute");
		}

		[Token(Token = "0x60013B1")]
		[Address(RVA = "0x3CEE91C", Offset = "0x3CEE91C", Length = "0xF8")]
		private static float AnticipateEase(float t, float s)
		{
			float num = t * t;
			float num2 = s + 1f;
			float num3 = num2 * t;
			float num4 = num3 - s;
			return num * num4;
		}

		[Token(Token = "0x60013B2")]
		[Address(RVA = "0x3CEE8A0", Offset = "0x3CEE8A0", Length = "0x7C")]
		private static float SampleCurve(NativeArray<float> samples, float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob::SampleCurve");
			return default;
		}

		[CompilerGenerated]
		[Token(Token = "0x60013B3")]
		[Address(RVA = "0x3CEEA14", Offset = "0x3CEEA14", Length = "0x724")]
		public void Execute(in ArchetypeChunk chunk, int chunkIndexInQuery, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob::Execute");
		}

		[Token(Token = "0x60013B4")]
		[Address(RVA = "0x3CEF138", Offset = "0x3CEF138", Length = "0x54")]
		private JobHandle __ThrowCodeGenException()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AttractToMoldJob::__ThrowCodeGenException");
			return default;
		}

		[Token(Token = "0x60013B5")]
		[Address(RVA = "0x3CEF18C", Offset = "0x3CEF18C", Length = "0xC")]
		public void Run()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013B6")]
		[Address(RVA = "0x3CEF198", Offset = "0x3CEF198", Length = "0xC")]
		public void RunByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013B7")]
		[Address(RVA = "0x3CEF1A4", Offset = "0x3CEF1A4", Length = "0xC")]
		public void Run(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013B8")]
		[Address(RVA = "0x3CEF1B0", Offset = "0x3CEF1B0", Length = "0xC")]
		public void RunByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013B9")]
		[Address(RVA = "0x3CEF1BC", Offset = "0x3CEF1BC", Length = "0xC")]
		public JobHandle Schedule(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BA")]
		[Address(RVA = "0x3CEF1C8", Offset = "0x3CEF1C8", Length = "0xC")]
		public JobHandle ScheduleByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BB")]
		[Address(RVA = "0x3CEF1D4", Offset = "0x3CEF1D4", Length = "0xC")]
		public JobHandle Schedule(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BC")]
		[Address(RVA = "0x3CEF1E0", Offset = "0x3CEF1E0", Length = "0xC")]
		public JobHandle ScheduleByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BD")]
		[Address(RVA = "0x3CEF1EC", Offset = "0x3CEF1EC", Length = "0xC")]
		public void Schedule()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BE")]
		[Address(RVA = "0x3CEF1F8", Offset = "0x3CEF1F8", Length = "0xC")]
		public void ScheduleByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013BF")]
		[Address(RVA = "0x3CEF204", Offset = "0x3CEF204", Length = "0xC")]
		public void Schedule(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C0")]
		[Address(RVA = "0x3CEF210", Offset = "0x3CEF210", Length = "0xC")]
		public void ScheduleByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C1")]
		[Address(RVA = "0x3CEF21C", Offset = "0x3CEF21C", Length = "0xC")]
		public JobHandle ScheduleParallel(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C2")]
		[Address(RVA = "0x3CEF228", Offset = "0x3CEF228", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C3")]
		[Address(RVA = "0x3CEF234", Offset = "0x3CEF234", Length = "0xC")]
		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C4")]
		[Address(RVA = "0x3CEF240", Offset = "0x3CEF240", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C5")]
		[Address(RVA = "0x3CEF24C", Offset = "0x3CEF24C", Length = "0xC")]
		public JobHandle ScheduleParallel(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C6")]
		[Address(RVA = "0x3CEF258", Offset = "0x3CEF258", Length = "0xC")]
		public JobHandle ScheduleParallelByRef(EntityQuery query, JobHandle dependsOn, NativeArray<int> chunkBaseEntityIndices)
		{
			return __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C7")]
		[Address(RVA = "0x3CEF264", Offset = "0x3CEF264", Length = "0xC")]
		public void ScheduleParallel()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C8")]
		[Address(RVA = "0x3CEF270", Offset = "0x3CEF270", Length = "0xC")]
		public void ScheduleParallelByRef()
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013C9")]
		[Address(RVA = "0x3CEF27C", Offset = "0x3CEF27C", Length = "0xC")]
		public void ScheduleParallel(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013CA")]
		[Address(RVA = "0x3CEF288", Offset = "0x3CEF288", Length = "0xC")]
		public void ScheduleParallelByRef(EntityQuery query)
		{
			JobHandle jobHandle = __ThrowCodeGenException();
		}

		[Token(Token = "0x60013CB")]
		[Address(RVA = "0x3CEF294", Offset = "0x3CEF294", Length = "0x4")]
		void IJobChunk.Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
		{
			Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
		}
	}
}
