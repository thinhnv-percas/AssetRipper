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
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.ECS.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[Token(Token = "0x2000467")]
	public struct VacuumSuctionSystem : ISystem, ISystemCompilerGenerated
	{
		[Token(Token = "0x2000468")]
		private struct TubePromotion
		{
			[Token(Token = "0x4000E3E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public Entity entity;

			[Token(Token = "0x4000E3F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public VacuumTubeProgress tubeProgress;
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x2000469")]
		private readonly struct IFE_78362322_0
		{
			[Token(Token = "0x200046A")]
			public struct ResolvedChunk
			{
				[Token(Token = "0x4000E40")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public IntPtr item1_IntPtr;

				[Token(Token = "0x4000E41")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public IntPtr item2_IntPtr;

				[Token(Token = "0x4000E42")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
				public IntPtr item3_IntPtr;

				[Token(Token = "0x4000E43")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001278")]
				[Address(RVA = "0x3CD3348", Offset = "0x3CD3348", Length = "0x2C8")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ParticleState>, InternalCompilerInterface.UncheckedRefRO<ParticlePosition>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>> Get(int index)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.ResolvedChunk::Get");
					return default;
				}
			}

			[Token(Token = "0x200046B")]
			public struct TypeHandle
			{
				[ReadOnly]
				[Token(Token = "0x4000E44")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal ComponentTypeHandle<ParticleState> item1_ComponentTypeHandle_RO;

				[ReadOnly]
				[Token(Token = "0x4000E45")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				private ComponentTypeHandle<ParticlePosition> item2_ComponentTypeHandle_RO;

				[ReadOnly]
				[Token(Token = "0x4000E46")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				internal ComponentTypeHandle<VacuumParticlePhase> item3_ComponentTypeHandle_RO;

				[Token(Token = "0x4000E47")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				private EntityTypeHandle Entity_TypeHandle;

				[Token(Token = "0x6001279")]
				[Address(RVA = "0x3CD3610", Offset = "0x3CD3610", Length = "0x110")]
				public TypeHandle(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.TypeHandle::.ctor");
					this = default;
				}

				[Token(Token = "0x600127A")]
				[Address(RVA = "0x3CD3720", Offset = "0x3CD3720", Length = "0xBC")]
				public void Update(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.TypeHandle::Update");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600127B")]
				[Address(RVA = "0x3CD37DC", Offset = "0x3CD37DC", Length = "0x2C0")]
				public unsafe ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.TypeHandle::Resolve");
					return default;
				}
			}

			[Token(Token = "0x200046C")]
			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ParticleState>, InternalCompilerInterface.UncheckedRefRO<ParticlePosition>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>>>, IEnumerator, IDisposable
			{
				[Token(Token = "0x4000E48")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal InternalEntityQueryEnumerator _entityQueryEnumerator;

				[Token(Token = "0x4000E49")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
				internal TypeHandle _typeHandle;

				[Token(Token = "0x4000E4A")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x178")]
				internal ResolvedChunk _resolvedChunk;

				[Token(Token = "0x4000E4B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x198")]
				internal int _currentEntityIndex;

				[Token(Token = "0x4000E4C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x19C")]
				internal int _endEntityIndex;

				[Token(Token = "0x17000199")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRO<ParticleState>, InternalCompilerInterface.UncheckedRefRO<ParticlePosition>, InternalCompilerInterface.UncheckedRefRO<VacuumParticlePhase>> Current
				{
					[Token(Token = "0x600127F")]
					[Address(RVA = "0x3CD2A0C", Offset = "0x3CD2A0C", Length = "0x10")]
					get
					{
						global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.Enumerator::get_Current");
						return default;
					}
				}

				[Token(Token = "0x1700019A")]
				object IEnumerator.Current
				{
					[Token(Token = "0x6001282")]
					[Address(RVA = "0x3CD3BB4", Offset = "0x3CD3BB4", Length = "0x40")]
					get
					{
						int num = 187244544 + 1152;
						NotImplementedException ex = new NotImplementedException();
						throw ex;
					}
				}

				[Token(Token = "0x600127C")]
				[Address(RVA = "0x3CD3138", Offset = "0x3CD3138", Length = "0x12C")]
				public unsafe Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.Enumerator::.ctor");
					this = default;
				}

				[Token(Token = "0x600127D")]
				[Address(RVA = "0x3CD3A9C", Offset = "0x3CD3A9C", Length = "0x8")]
				public void Dispose()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.Enumerator::Dispose");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600127E")]
				[Address(RVA = "0x3CD3AA4", Offset = "0x3CD3AA4", Length = "0xD0")]
				public unsafe bool MoveNext()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0.Enumerator::MoveNext");
					return default;
				}

				[Token(Token = "0x6001280")]
				[Address(RVA = "0x3CD29FC", Offset = "0x3CD29FC", Length = "0x10")]
				public Enumerator GetEnumerator()
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					Enumerator result = default(Enumerator);
					return result;
				}

				[Token(Token = "0x6001281")]
				[Address(RVA = "0x3CD3B74", Offset = "0x3CD3B74", Length = "0x40")]
				public void Reset()
				{
					int num = 187244544 + 1152;
					NotImplementedException ex = new NotImplementedException();
					throw ex;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6001276")]
			[Address(RVA = "0x3CD2FD8", Offset = "0x3CD2FD8", Length = "0x160")]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_0::Query");
				return default;
			}

			[Token(Token = "0x6001277")]
			[Address(RVA = "0x3CD3264", Offset = "0x3CD3264", Length = "0xE4")]
			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRO<ParticleState>();
				state.EntityManager.CompleteDependencyBeforeRO<ParticlePosition>();
				state.EntityManager.CompleteDependencyBeforeRO<VacuumParticlePhase>();
			}
		}

		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x200046D")]
		private readonly struct IFE_78362322_1
		{
			[Token(Token = "0x200046E")]
			public struct ResolvedChunk
			{
				[Token(Token = "0x4000E4D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				public IntPtr item1_IntPtr;

				[Token(Token = "0x4000E4E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
				public IntPtr item2_IntPtr;

				[Token(Token = "0x4000E4F")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
				public IntPtr item3_IntPtr;

				[Token(Token = "0x4000E50")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
				public IntPtr item4_IntPtr;

				[Token(Token = "0x4000E51")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
				public IntPtr item5_IntPtr;

				[Token(Token = "0x4000E52")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				public IntPtr item6_IntPtr;

				[Token(Token = "0x4000E53")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
				public IntPtr Entity_IntPtr;

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001285")]
				[Address(RVA = "0x3CD4038", Offset = "0x3CD4038", Length = "0x480")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumSuctionData>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRW<PostTransformMatrix>> Get(int index)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.ResolvedChunk::Get");
					return default;
				}
			}

			[Token(Token = "0x200046F")]
			public struct TypeHandle
			{
				[Token(Token = "0x4000E54")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal ComponentTypeHandle<ParticlePosition> item1_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E55")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
				private ComponentTypeHandle<ParticleVelocity> item2_ComponentTypeHandle_RW;

				[ReadOnly]
				[Token(Token = "0x4000E56")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
				internal ComponentTypeHandle<VacuumSuctionData> item3_ComponentTypeHandle_RO;

				[Token(Token = "0x4000E57")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
				private ComponentTypeHandle<VacuumParticlePhase> item4_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E58")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xA0")]
				internal ComponentTypeHandle<LocalTransform> item5_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E59")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xC8")]
				private ComponentTypeHandle<PostTransformMatrix> item6_ComponentTypeHandle_RW;

				[Token(Token = "0x4000E5A")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF0")]
				internal EntityTypeHandle Entity_TypeHandle;

				[Token(Token = "0x6001286")]
				[Address(RVA = "0x3CD44B8", Offset = "0x3CD44B8", Length = "0x1DC")]
				public TypeHandle(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.TypeHandle::.ctor");
					this = default;
				}

				[Token(Token = "0x6001287")]
				[Address(RVA = "0x3CD4694", Offset = "0x3CD4694", Length = "0x138")]
				public void Update(ref SystemState systemState)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.TypeHandle::Update");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x6001288")]
				[Address(RVA = "0x3CD47CC", Offset = "0x3CD47CC", Length = "0x590")]
				public unsafe ResolvedChunk Resolve(ArchetypeChunk archetypeChunk)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.TypeHandle::Resolve");
					return default;
				}
			}

			[Token(Token = "0x2000470")]
			public struct Enumerator : IEnumerator<QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumSuctionData>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRW<PostTransformMatrix>>>, IEnumerator, IDisposable
			{
				[Token(Token = "0x4000E5B")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
				internal InternalEntityQueryEnumerator _entityQueryEnumerator;

				[Token(Token = "0x4000E5C")]
				[Cpp2ILInjected.FieldOffset(Offset = "0xF8")]
				internal TypeHandle _typeHandle;

				[Token(Token = "0x4000E5D")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x1F0")]
				internal ResolvedChunk _resolvedChunk;

				[Token(Token = "0x4000E5E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x228")]
				internal int _currentEntityIndex;

				[Token(Token = "0x4000E5F")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x22C")]
				internal int _endEntityIndex;

				[Token(Token = "0x1700019B")]
				public unsafe QueryEnumerableWithEntity<InternalCompilerInterface.UncheckedRefRW<ParticlePosition>, InternalCompilerInterface.UncheckedRefRW<ParticleVelocity>, InternalCompilerInterface.UncheckedRefRO<VacuumSuctionData>, InternalCompilerInterface.UncheckedRefRW<VacuumParticlePhase>, InternalCompilerInterface.UncheckedRefRW<LocalTransform>, InternalCompilerInterface.UncheckedRefRW<PostTransformMatrix>> Current
				{
					[Token(Token = "0x600128C")]
					[Address(RVA = "0x3CD2A2C", Offset = "0x3CD2A2C", Length = "0x10")]
					get
					{
						global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.Enumerator::get_Current");
						return default;
					}
				}

				[Token(Token = "0x1700019C")]
				object IEnumerator.Current
				{
					[Token(Token = "0x600128F")]
					[Address(RVA = "0x3CD4E7C", Offset = "0x3CD4E7C", Length = "0x40")]
					get
					{
						int num = 187244544 + 1152;
						NotImplementedException ex = new NotImplementedException();
						throw ex;
					}
				}

				[Token(Token = "0x6001289")]
				[Address(RVA = "0x3CD3DA4", Offset = "0x3CD3DA4", Length = "0x130")]
				public unsafe Enumerator(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.Enumerator::.ctor");
					this = default;
				}

				[Token(Token = "0x600128A")]
				[Address(RVA = "0x3CD4D5C", Offset = "0x3CD4D5C", Length = "0x8")]
				public void Dispose()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.Enumerator::Dispose");
				}

				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				[Token(Token = "0x600128B")]
				[Address(RVA = "0x3CD4D64", Offset = "0x3CD4D64", Length = "0xD8")]
				public unsafe bool MoveNext()
				{
					global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1.Enumerator::MoveNext");
					return default;
				}

				[Token(Token = "0x600128D")]
				[Address(RVA = "0x3CD2A1C", Offset = "0x3CD2A1C", Length = "0x10")]
				public Enumerator GetEnumerator()
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					Enumerator result = default(Enumerator);
					return result;
				}

				[Token(Token = "0x600128E")]
				[Address(RVA = "0x3CD4E3C", Offset = "0x3CD4E3C", Length = "0x40")]
				public void Reset()
				{
					int num = 187244544 + 1152;
					NotImplementedException ex = new NotImplementedException();
					throw ex;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6001283")]
			[Address(RVA = "0x3CD3BF4", Offset = "0x3CD3BF4", Length = "0x1B0")]
			public static Enumerator Query(EntityQuery entityQuery, TypeHandle typeHandle, ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem.IFE_78362322_1::Query");
				return default;
			}

			[Token(Token = "0x6001284")]
			[Address(RVA = "0x3CD3ED4", Offset = "0x3CD3ED4", Length = "0x164")]
			public static void CompleteDependencies(ref SystemState state)
			{
				state.EntityManager.CompleteDependencyBeforeRW<ParticlePosition>();
				state.EntityManager.CompleteDependencyBeforeRW<ParticleVelocity>();
				state.EntityManager.CompleteDependencyBeforeRO<VacuumSuctionData>();
				state.EntityManager.CompleteDependencyBeforeRW<VacuumParticlePhase>();
				state.EntityManager.CompleteDependencyBeforeRW<LocalTransform>();
				state.EntityManager.CompleteDependencyBeforeRW<PostTransformMatrix>();
			}
		}

		[Token(Token = "0x2000471")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000E60")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public IFE_78362322_0.TypeHandle __IFE_78362322_0_TypeHandle;

			[Token(Token = "0x4000E61")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x80")]
			public IFE_78362322_1.TypeHandle __IFE_78362322_1_TypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x6001290")]
			[Address(RVA = "0x3CD4EBC", Offset = "0x3CD4EBC", Length = "0xE8")]
			public void __AssignHandles(ref SystemState state)
			{
				IFE_78362322_0.TypeHandle _IFE_78362322_0_TypeHandle = new IFE_78362322_0.TypeHandle(ref state);
				_ = 0;
				_ = 0;
				_ = 0;
				_ = 0;
				__IFE_78362322_0_TypeHandle = _IFE_78362322_0_TypeHandle;
				_ = 0;
				_ = 0;
				_ = 0;
				IFE_78362322_1.TypeHandle _IFE_78362322_1_TypeHandle = new IFE_78362322_1.TypeHandle(ref state);
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
				_ = 0;
				__IFE_78362322_1_TypeHandle = _IFE_78362322_1_TypeHandle;
				_ = 0;
				_ = 0;
				_ = 0;
			}
		}

		[Token(Token = "0x4000E3B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x4000E3C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x178")]
		private EntityQuery __query_78362322_0;

		[Token(Token = "0x4000E3D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x188")]
		private EntityQuery __query_78362322_1;

		[Token(Token = "0x6001271")]
		[Address(RVA = "0x3CD165C", Offset = "0x3CD165C", Length = "0x13A0")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6001272")]
		[Address(RVA = "0x3CD2A3C", Offset = "0x3CD2A3C", Length = "0x4A8")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<SandParticle>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithAll<ParticleState>();
			entityQueryBuilder3 = entityQueryBuilder4;
			EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder3.WithAll<ParticlePosition>();
			entityQueryBuilder3 = entityQueryBuilder5;
			EntityQueryBuilder entityQueryBuilder6 = entityQueryBuilder3.WithAll<VacuumParticlePhase>();
			entityQueryBuilder3 = entityQueryBuilder6;
			EntityQuery _query_78362322_ = entityQueryBuilder3.Build(ref state);
			__query_78362322_0 = _query_78362322_;
			EntityQueryBuilder entityQueryBuilder7 = entityQueryBuilder.Reset();
			EntityQueryBuilder entityQueryBuilder8 = entityQueryBuilder.WithAll<VacuumSuctionData>();
			entityQueryBuilder3 = entityQueryBuilder8;
			EntityQueryBuilder entityQueryBuilder9 = entityQueryBuilder3.WithAllRW<ParticlePosition>();
			entityQueryBuilder3 = entityQueryBuilder9;
			EntityQueryBuilder entityQueryBuilder10 = entityQueryBuilder3.WithAllRW<ParticleVelocity>();
			entityQueryBuilder3 = entityQueryBuilder10;
			EntityQueryBuilder entityQueryBuilder11 = entityQueryBuilder3.WithAllRW<VacuumParticlePhase>();
			entityQueryBuilder3 = entityQueryBuilder11;
			EntityQueryBuilder entityQueryBuilder12 = entityQueryBuilder3.WithAllRW<LocalTransform>();
			entityQueryBuilder3 = entityQueryBuilder12;
			EntityQueryBuilder entityQueryBuilder13 = entityQueryBuilder3.WithAllRW<PostTransformMatrix>();
			entityQueryBuilder3 = entityQueryBuilder13;
			EntityQueryBuilder entityQueryBuilder14 = entityQueryBuilder3.WithNone<SandParticle>();
			entityQueryBuilder3 = entityQueryBuilder14;
			EntityQuery _query_78362322_2 = entityQueryBuilder3.Build(ref state);
			__query_78362322_1 = _query_78362322_2;
			EntityQueryBuilder entityQueryBuilder15 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x6001273")]
		[Address(RVA = "0x3CD2EE4", Offset = "0x3CD2EE4", Length = "0xF4")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001274")]
		[Address(RVA = "0x3CD1564", Offset = "0x3CD1564", Length = "0x4")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((VacuumSuctionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001275")]
		[Address(RVA = "0x3CD1568", Offset = "0x3CD1568", Length = "0xF4")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumSuctionSystem::__codegen__OnCreateForCompiler");
		}
	}
}
