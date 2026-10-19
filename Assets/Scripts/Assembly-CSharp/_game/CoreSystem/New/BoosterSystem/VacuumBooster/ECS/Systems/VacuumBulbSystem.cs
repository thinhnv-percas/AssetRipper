using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Burst.CompilerServices;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(VacuumTubeSystem))]
	[Token(Token = "0x200045F")]
	public struct VacuumBulbSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x2000460")]
		private readonly struct IFE_2056601448_0
		{
			[Token(Token = "0x2000461")]
			public struct ResolvedChunk
			{
				[Token(Token = "0x4000E2A")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public IntPtr item1_IntPtr;

				[Token(Token = "0x4000E2B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public IntPtr item2_IntPtr;

				[Token(Token = "0x4000E2C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
				public IntPtr item3_IntPtr;

				[Token(Token = "0x4000E2D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
				public IntPtr item4_IntPtr;

				[Token(Token = "0x4000E2E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
				public IntPtr item5_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001261")]
				[Address(RVA = "0x3CCF7FC", Offset = "0x3CCF7FC", Length = "0x388")]
				public unsafe (InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumBulbSlot>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>) Get(int index)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.ResolvedChunk::Get");
					return default;
				}
			}

			[Token(Token = "0x2000462")]
			public struct TypeHandle
			{
				[Token(Token = "0x4000E2F")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal ComponentTypeHandle<ParticlePosition> item1_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E30")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				private ComponentTypeHandle<ParticleVelocity> item2_ComponentTypeHandle_RW;

				[ReadOnly]
				[Token(Token = "0x4000E31")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				internal ComponentTypeHandle<VacuumParticlePhase> item3_ComponentTypeHandle_RO;

				[Token(Token = "0x4000E32")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				private ComponentTypeHandle<VacuumBulbSlot> item4_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E33")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				internal ComponentTypeHandle<LocalTransform> item5_ComponentTypeHandle_RW;

				[Token(Token = "0x6001262")]
				[Address(RVA = "0x3CCFB84", Offset = "0x3CCFB84", Length = "0x188")]
				public TypeHandle(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.TypeHandle::.ctor");
					this = default;
				}

				[Token(Token = "0x6001263")]
				[Address(RVA = "0x3CCFD0C", Offset = "0x3CCFD0C", Length = "0xFC")]
				public void Update(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.TypeHandle::Update");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001264")]
				[Address(RVA = "0x3CCFE08", Offset = "0x3CCFE08", Length = "0x4A0")]
				public unsafe ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.TypeHandle::Resolve");
					return default;
				}
			}

			[Token(Token = "0x2000463")]
			public struct Enumerator : IEnumerator<(InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumBulbSlot>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>)>, IEnumerator, IDisposable
			{
				[Token(Token = "0x4000E34")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal InternalEntityQueryEnumerator _entityQueryEnumerator;

				[Token(Token = "0x4000E35")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
				internal TypeHandle _typeHandle;

				[Token(Token = "0x4000E36")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1C0")]
				internal ResolvedChunk _resolvedChunk;

				[Token(Token = "0x4000E37")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1E8")]
				internal int _currentEntityIndex;

				[Token(Token = "0x4000E38")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1EC")]
				internal int _endEntityIndex;

				[Token(Token = "0x17000197")]
				public unsafe (InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumBulbSlot>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>) Current
				{
					[Token(Token = "0x6001268")]
					[Address(RVA = "0x3CCF060", Offset = "0x3CCF060", Length = "0x10")]
					get
					{
						global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.Enumerator::get_Current");
						return default;
					}
				}

				[Token(Token = "0x17000198")]
				object IEnumerator.Current
				{
					[Token(Token = "0x600126B")]
					[Address(RVA = "0x3CD06DC", Offset = "0x3CD06DC", Length = "0x40")]
					get
					{
						int num = 187244544 + 1152;
						NotImplementedException ex = new NotImplementedException();
						throw ex;
					}
				}

				[Token(Token = "0x6001265")]
				[Address(RVA = "0x3CCF594", Offset = "0x3CCF594", Length = "0x12C")]
				public unsafe Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.Enumerator::.ctor");
					this = default;
				}

				[Token(Token = "0x6001266")]
				[Address(RVA = "0x3CD02A8", Offset = "0x3CD02A8", Length = "0x8")]
				public void Dispose()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.Enumerator::Dispose");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001267")]
				[Address(RVA = "0x3CD02B0", Offset = "0x3CD02B0", Length = "0x3EC")]
				public unsafe bool MoveNext()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0.Enumerator::MoveNext");
					return default;
				}

				[Token(Token = "0x6001269")]
				[Address(RVA = "0x3CCF050", Offset = "0x3CCF050", Length = "0x10")]
				public Enumerator GetEnumerator()
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					Enumerator result = default(Enumerator);
					return result;
				}

				[Token(Token = "0x600126A")]
				[Address(RVA = "0x3CD069C", Offset = "0x3CD069C", Length = "0x40")]
				public void Reset()
				{
					int num = 187244544 + 1152;
					NotImplementedException ex = new NotImplementedException();
					throw ex;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x600125F")]
			[Address(RVA = "0x3CCF404", Offset = "0x3CCF404", Length = "0x190")]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem.IFE_2056601448_0::Query");
				return default;
			}

			[Token(Token = "0x6001260")]
			[Address(RVA = "0x3CCF6C0", Offset = "0x3CCF6C0", Length = "0x13C")]
			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRW<ParticlePosition>();
				state.EntityManager.CompleteDependencyBeforeRW<ParticleVelocity>();
				state.EntityManager.CompleteDependencyBeforeRO<VacuumParticlePhase>();
				state.EntityManager.CompleteDependencyBeforeRW<VacuumBulbSlot>();
				state.EntityManager.CompleteDependencyBeforeRW<LocalTransform>();
			}
		}

		[Token(Token = "0x2000464")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000E39")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public IFE_2056601448_0.TypeHandle __IFE_2056601448_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x600126C")]
			[Address(RVA = "0x3CD071C", Offset = "0x3CD071C", Length = "0x84")]
			public void __AssignHandles(ref SystemState state)
			{
				IFE_2056601448_0.TypeHandle _IFE_2056601448_0_TypeHandle = new IFE_2056601448_0.TypeHandle(ref state);
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				__IFE_2056601448_0_TypeHandle = _IFE_2056601448_0_TypeHandle;
				_ = 0;
			}
		}

		[Token(Token = "0x4000E28")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x4000E29")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
		private EntityQuery __query_2056601448_0;

		[Token(Token = "0x600125A")]
		[Address(RVA = "0x3CCE7F0", Offset = "0x3CCE7F0", Length = "0x860")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600125B")]
		[Address(RVA = "0x3CCF070", Offset = "0x3CCF070", Length = "0x300")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<VacuumParticlePhase>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
			entityQueryBuilder3 = entityQueryBuilder4;
			EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
			entityQueryBuilder3 = entityQueryBuilder5;
			EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<VacuumBulbSlot>();
			entityQueryBuilder3 = entityQueryBuilder6;
			EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<LocalTransform>();
			entityQueryBuilder3 = entityQueryBuilder7;
			EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithNone<SandParticle>();
			entityQueryBuilder3 = entityQueryBuilder8;
			EntityQuery _query_2056601448_ = entityQueryBuilder3.Build(ref state);
			__query_2056601448_0 = _query_2056601448_;
			EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x600125C")]
		[Address(RVA = "0x3CCF370", Offset = "0x3CCF370", Length = "0x94")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600125D")]
		[Address(RVA = "0x3CCE758", Offset = "0x3CCE758", Length = "0x4")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((VacuumBulbSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600125E")]
		[Address(RVA = "0x3CCE75C", Offset = "0x3CCE75C", Length = "0x94")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumBulbSystem::__codegen__OnCreateForCompiler");
		}
	}
}
