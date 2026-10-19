using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Core;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Components;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime;
using _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(VacuumSuctionSystem))]
	[Token(Token = "0x2000472")]
	public struct VacuumTubeSystem : ISystem, ISystemCompilerGenerated
	{
		[Token(Token = "0x2000473")]
		private struct BulbPromotion
		{
			[Token(Token = "0x4000E64")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public Entity entity;

			[Token(Token = "0x4000E65")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public VacuumBulbSlot slot;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x2000474")]
		private readonly struct IFE_2085950949_0
		{
			[Token(Token = "0x2000475")]
			public struct ResolvedChunk
			{
				[Token(Token = "0x4000E66")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public IntPtr item1_IntPtr;

				[Token(Token = "0x4000E67")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public IntPtr item2_IntPtr;

				[Token(Token = "0x4000E68")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
				public IntPtr item3_IntPtr;

				[Token(Token = "0x4000E69")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
				public IntPtr item4_IntPtr;

				[Token(Token = "0x4000E6A")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
				public IntPtr item5_IntPtr;

				[Token(Token = "0x4000E6B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001298")]
				[Address(RVA = "0x3CD6588", Offset = "0x3CD6588", Length = "0x3E0")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumTubeProgress>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>> Get(int index)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.ResolvedChunk::Get");
					return default;
				}
			}

			[Token(Token = "0x2000476")]
			public struct TypeHandle
			{
				[Token(Token = "0x4000E6C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal ComponentTypeHandle<ParticlePosition> item1_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E6D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				private ComponentTypeHandle<ParticleVelocity> item2_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E6E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				internal ComponentTypeHandle<VacuumParticlePhase> item3_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E6F")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				private ComponentTypeHandle<VacuumTubeProgress> item4_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E70")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				internal ComponentTypeHandle<LocalTransform> item5_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E71")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
				private EntityTypeHandle Entity_TypeHandle;

				[Token(Token = "0x6001299")]
				[Address(RVA = "0x3CD6968", Offset = "0x3CD6968", Length = "0x198")]
				public TypeHandle(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.TypeHandle::.ctor");
					this = default;
				}

				[Token(Token = "0x600129A")]
				[Address(RVA = "0x3CD6B00", Offset = "0x3CD6B00", Length = "0x10C")]
				public void Update(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.TypeHandle::Update");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600129B")]
				[Address(RVA = "0x3CD6C0C", Offset = "0x3CD6C0C", Length = "0x500")]
				public unsafe ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.TypeHandle::Resolve");
					return default;
				}
			}

			[Token(Token = "0x2000477")]
			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumTubeProgress>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>>>, IEnumerator, IDisposable
			{
				[Token(Token = "0x4000E72")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal InternalEntityQueryEnumerator _entityQueryEnumerator;

				[Token(Token = "0x4000E73")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
				internal TypeHandle _typeHandle;

				[Token(Token = "0x4000E74")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1C8")]
				internal ResolvedChunk _resolvedChunk;

				[Token(Token = "0x4000E75")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1F8")]
				internal int _currentEntityIndex;

				[Token(Token = "0x4000E76")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1FC")]
				internal int _endEntityIndex;

				[Token(Token = "0x1700019D")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<VacuumTubeProgress>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>> Current
				{
					[Token(Token = "0x600129F")]
					[Address(RVA = "0x3CD5DE8", Offset = "0x3CD5DE8", Length = "0x10")]
					get
					{
						global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.Enumerator::get_Current");
						return default;
					}
				}

				[Token(Token = "0x1700019E")]
				object IEnumerator.Current
				{
					[Token(Token = "0x60012A2")]
					[Address(RVA = "0x3CD722C", Offset = "0x3CD722C", Length = "0x40")]
					get
					{
						int num = 187244544 + 1152;
						NotImplementedException ex = new NotImplementedException();
						throw ex;
					}
				}

				[Token(Token = "0x600129C")]
				[Address(RVA = "0x3CD631C", Offset = "0x3CD631C", Length = "0x130")]
				public unsafe Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.Enumerator::.ctor");
					this = default;
				}

				[Token(Token = "0x600129D")]
				[Address(RVA = "0x3CD710C", Offset = "0x3CD710C", Length = "0x8")]
				public void Dispose()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.Enumerator::Dispose");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600129E")]
				[Address(RVA = "0x3CD7114", Offset = "0x3CD7114", Length = "0xD8")]
				public unsafe bool MoveNext()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0.Enumerator::MoveNext");
					return default;
				}

				[Token(Token = "0x60012A0")]
				[Address(RVA = "0x3CD5DD8", Offset = "0x3CD5DD8", Length = "0x10")]
				public Enumerator GetEnumerator()
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					Enumerator result = default(Enumerator);
					return result;
				}

				[Token(Token = "0x60012A1")]
				[Address(RVA = "0x3CD71EC", Offset = "0x3CD71EC", Length = "0x40")]
				public void Reset()
				{
					int num = 187244544 + 1152;
					NotImplementedException ex = new NotImplementedException();
					throw ex;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6001296")]
			[Address(RVA = "0x3CD618C", Offset = "0x3CD618C", Length = "0x190")]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem.IFE_2085950949_0::Query");
				return default;
			}

			[Token(Token = "0x6001297")]
			[Address(RVA = "0x3CD644C", Offset = "0x3CD644C", Length = "0x13C")]
			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRW<ParticlePosition>();
				state.EntityManager.CompleteDependencyBeforeRW<ParticleVelocity>();
				state.EntityManager.CompleteDependencyBeforeRW<VacuumParticlePhase>();
				state.EntityManager.CompleteDependencyBeforeRW<VacuumTubeProgress>();
				state.EntityManager.CompleteDependencyBeforeRW<LocalTransform>();
			}
		}

		[Token(Token = "0x2000478")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000E77")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public IFE_2085950949_0.TypeHandle __IFE_2085950949_0_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60012A3")]
			[Address(RVA = "0x3CD726C", Offset = "0x3CD726C", Length = "0x84")]
			public void __AssignHandles(ref SystemState state)
			{
				IFE_2085950949_0.TypeHandle _IFE_2085950949_0_TypeHandle = new IFE_2085950949_0.TypeHandle(ref state);
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
				__IFE_2085950949_0_TypeHandle = _IFE_2085950949_0_TypeHandle;
				_ = 0;
			}
		}

		[Token(Token = "0x4000E62")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x4000E63")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xD0")]
		private EntityQuery __query_2085950949_0;

		[Token(Token = "0x6001291")]
		[Address(RVA = "0x3CD503C", Offset = "0x3CD503C", Length = "0xD9C")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6001292")]
		[Address(RVA = "0x3CD5DF8", Offset = "0x3CD5DF8", Length = "0x300")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ParticlePosition>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
			entityQueryBuilder3 = entityQueryBuilder4;
			EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAllRW<VacuumParticlePhase>();
			entityQueryBuilder3 = entityQueryBuilder5;
			EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAllRW<VacuumTubeProgress>();
			entityQueryBuilder3 = entityQueryBuilder6;
			EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder3.WithAllRW<LocalTransform>();
			entityQueryBuilder3 = entityQueryBuilder7;
			EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder3.WithNone<SandParticle>();
			entityQueryBuilder3 = entityQueryBuilder8;
			EntityQuery _query_2085950949_ = entityQueryBuilder3.Build(ref state);
			__query_2085950949_0 = _query_2085950949_;
			EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x6001293")]
		[Address(RVA = "0x3CD60F8", Offset = "0x3CD60F8", Length = "0x94")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001294")]
		[Address(RVA = "0x3CD4FA4", Offset = "0x3CD4FA4", Length = "0x4")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((VacuumTubeSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001295")]
		[Address(RVA = "0x3CD4FA8", Offset = "0x3CD4FA8", Length = "0x94")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumTubeSystem::__codegen__OnCreateForCompiler");
		}
	}
}
