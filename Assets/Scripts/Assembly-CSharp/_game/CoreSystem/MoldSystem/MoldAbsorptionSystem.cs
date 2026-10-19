using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Core;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandPhysics.Components;
using _game.CoreSystem.SandPhysics.Systems;

namespace _game.CoreSystem.MoldSystem
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(WallCollisionSystem))]
	[UpdateBefore(typeof(BoundsCheckSystem))]
	[Token(Token = "0x20004A7")]
	public struct MoldAbsorptionSystem : ISystem, ISystemCompilerGenerated
	{
		[Token(Token = "0x20004A8")]
		private struct TypeHandle
		{
			[Token(Token = "0x4000F9D")]
			[FieldOffset(Offset = "0x0")]
			public FindCandidatesJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_MoldSystem_FindCandidatesJob_WithDefaultQuery_JobEntityTypeHandle;

			[Token(Token = "0x4000F9E")]
			[FieldOffset(Offset = "0x90")]
			public AttractToMoldJob.InternalCompilerQueryAndHandleData ___game_CoreSystem_MoldSystem_AttractToMoldJob_WithDefaultQuery_JobEntityTypeHandle;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x600138A")]
			[Address(RVA = "0x3CED710", Offset = "0x3CED710", Length = "0x44")]
			public unsafe void __AssignHandles(ref SystemState state)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem.TypeHandle::__AssignHandles");
			}
		}

		[Token(Token = "0x4000F94")]
		[FieldOffset(Offset = "0x0")]
		private ComponentLookup<ParticleState> _stateLookup;

		[Token(Token = "0x4000F95")]
		[FieldOffset(Offset = "0x28")]
		private ComponentLookup<ParticlePosition> _posLookup;

		[Token(Token = "0x4000F96")]
		[FieldOffset(Offset = "0x50")]
		private ComponentLookup<ParticleVelocity> _velLookup;

		[Token(Token = "0x4000F97")]
		[FieldOffset(Offset = "0x78")]
		private ComponentLookup<AbsorptionArcData> _arcLookup;

		[Token(Token = "0x4000F98")]
		[FieldOffset(Offset = "0xA0")]
		private ComponentLookup<LocalTransform> _transformLookup;

		[Token(Token = "0x4000F99")]
		private const int CurveSamples = 64;

		[Token(Token = "0x4000F9A")]
		[FieldOffset(Offset = "0xC8")]
		private NativeArray<float> _cachedEaseCurve;

		[Token(Token = "0x4000F9B")]
		[FieldOffset(Offset = "0xD8")]
		private NativeArray<float> _cachedDispatchScaleCurve;

		[Token(Token = "0x4000F9C")]
		[FieldOffset(Offset = "0xE8")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x600137F")]
		[Address(RVA = "0x3CEC018", Offset = "0x3CEC018", Length = "0x200")]
		public unsafe void OnCreate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::OnCreate");
		}

		[Token(Token = "0x6001380")]
		[Address(RVA = "0x3CEC218", Offset = "0x3CEC218", Length = "0x80")]
		public unsafe void OnDestroy(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::OnDestroy");
		}

		[Token(Token = "0x6001381")]
		[Address(RVA = "0x3CEC298", Offset = "0x3CEC298", Length = "0x1074")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6001382")]
		[Address(RVA = "0x3CED30C", Offset = "0x3CED30C", Length = "0xA4")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_0(FindCandidatesJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::__ScheduleViaJobChunkExtension_0");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6001383")]
		[Address(RVA = "0x3CED46C", Offset = "0x3CED46C", Length = "0xA4")]
		private unsafe JobHandle __ScheduleViaJobChunkExtension_1(AttractToMoldJob job, EntityQuery query, JobHandle dependency, ref SystemState state, bool hasUserDefinedQuery)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::__ScheduleViaJobChunkExtension_1");
			return default;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6001384")]
		[Address(RVA = "0x3CED648", Offset = "0x3CED648", Length = "0x44")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			new EntityQueryBuilder(allocator).Dispose();
		}

		[Token(Token = "0x6001385")]
		[Address(RVA = "0x3CED68C", Offset = "0x3CED68C", Length = "0x84")]
		public unsafe void OnCreateForCompiler(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::OnCreateForCompiler");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001386")]
		[Address(RVA = "0x3CEBF0C", Offset = "0x3CEBF0C", Length = "0x4")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((MoldAbsorptionSystem*)self)->OnCreate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001387")]
		[Address(RVA = "0x3CEBF10", Offset = "0x3CEBF10", Length = "0x4")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((MoldAbsorptionSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001388")]
		[Address(RVA = "0x3CEBF14", Offset = "0x3CEBF14", Length = "0x80")]
		internal unsafe static void __codegen__OnDestroy(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::__codegen__OnDestroy");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001389")]
		[Address(RVA = "0x3CEBF94", Offset = "0x3CEBF94", Length = "0x84")]
		internal unsafe static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldAbsorptionSystem::__codegen__OnCreateForCompiler");
		}
	}
}
