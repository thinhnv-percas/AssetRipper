using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.SandPhysics.Collision;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup), OrderFirst = true)]
	[Token(Token = "0x20000EC")]
	public struct SandSpawnSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x20000ED")]
		private struct TypeHandle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60004DA")]
			[Address(RVA = "0x3C8D80C", Offset = "0x3C8D80C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		[Token(Token = "0x40002FD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x40002FE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private EntityQuery __query_2055703241_0;

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0x3C8D030", Offset = "0x3C8D030", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<CubeBreakEvent>();
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0x3C8D084", Offset = "0x3C8D084", Length = "0x5F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tgoto L_005C;\nL_005C:\n\tv288 = UnityEngine.Object::op_Equality(v98.Config, 0);\n\tv293 = v288 == 0;\n\tif (v293) goto L_006A;\n\tgoto L_0276;\nL_006A:\n\t;\n\tv485 = Unity.Entities.EntityQuery::GetSingletonEntity(&this.__query_2055703241_0 (Unity.Entities.EntityQuery));\n\tv272 = state.EntityManager;\n\tgoto L_007E;\nL_007E:\n\tv506 = Unity.Entities.EntityManager::GetBuffer(&v272 @ stack_-E8_v2 (Unity.Entities.EntityManager), v485, 0);\n\tv267 = v506;\n\tv265 = v485;\n\tv290 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::get_Length(&v267 @ stack_-B8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>));\n\tv295 = v290 == 0;\n\tif (v295) goto L_0276;\n\tv510 = v98.Config;\n\tv611 = v98.RenderAssets;\n\tv514 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tgoto L_009C;\nL_009C:\n\tUnity.Entities.EntityCommandBuffer::.ctor(&v255 @ stack_-E0_v3 (Unity.Entities.EntityCommandBuffer), v514);\n\tv530 = _game.CoreSystem.SandPhysics.Services.SandCollisionService::GetBoundaryData(v98.Collision);\n\tv577 = v530.blockedLoopCount < 1;\n\tif (v577) goto L_FFFFFFFF;\n\tv595 = v530.blockedLoopVertices == 0;\n\tv637 = v510 == 0;\n\tv622 = ~v637;\nL_FFFFFFFF:\n\tv632 = v595;\n\tif (v622) goto L_00C2;\n\tgoto L_0277;\nL_FFFFFFFF:\n\tv632 = 1;\nL_00C2:\n\tv1236 = v510.BreakJitterStrength;\n\tgoto L_00CE;\nL_00CE:\n\tv620 = UnityEngine.Object::op_Inequality(v98.RenderAssets, 0);\n\tv648 = ~v620;\nL_FFFFFFFF:\n\tv221 = 0;\n\tif (v648) goto L_00DC;\nL_FFFFFFFF:\n\tv221 = *([v611 @ X27_v6 (UnityEngine.Object)+28]);\n\tv670 = v98.<Params>k__BackingField >> 0x20;\nL_FFFFFFFF:\n\tv612 = 0;\n\tgoto L_0106;\nL_00F1:\n\tv612 = v612 + 1;\n\tv723 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::get_Length(&v267 @ stack_-B8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>));\n\tv705 = v612 >= v723;\n\tif (v705) goto L_024F;\nL_0106:\n\tv755 = &v208 @ stack_-120 (System.Int32);\n\tv758 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::get_Item(&v267 @ stack_-B8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>), v612);\n\tv208 = v208.m_value;\n\tv773 = _game.CoreSystem.SandPhysics.SpawnUtility::ComputeLayout(*([v755 @ X8_v41+8]), *([v755 @ X8_v41+C]), v98.<Params>k__BackingField);\n\tv208 = v773.gridSize;\n\tgoto L_012D;\nL_012D:\n\tv786 = UnityEngine.Object::op_Inequality(v98.RenderAssets, 0);\n\tv788 = ~v786;\n\tif (v788) goto L_0162;\n\tv820 = _game.CoreSystem.SandPhysics.SandRenderingAssetsSO::GetParticleColor(v98.RenderAssets, *([v755 @ X8_v41+10]));\n\tv837 = v773.gridSize >= 1;\nL_FFFFFFFF:\n\tv825 = v820;\nL_FFFFFFFF:\n\tv1024 = v773.gridSize;\n\tif (v837) goto L_016E;\n\tgoto L_00F1;\nL_0162:\n\tv815 = v773.gridSize < 1;\nL_FFFFFFFF:\n\tv825 = 1f;\nL_FFFFFFFF:\n\tv1024 = v773.gridSize;\n\tif (v815) goto L_00F1;\nL_016E:\n\tv870 = v98.<Params>k__BackingField < 1;\n\tif (v870) goto L_00F1;\nL_FFFFFFFF:\n\tv1068 = 0;\nL_FFFFFFFF:\n\tv1201 = 0;\n\tv1021 = v632 == 0;\n\tif (v1021) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1147 = 1;\n\tv1201 = v1201 + 1;\n\tv1113 = v1147 >= v1103;\nL_FFFFFFFF:\n\tv208 = v255;\nL_FFFFFFFF:\n\tv1024 = v1103;\n\tif (v1113) goto L_0221;\n\tv1147 = v1147 + 1;\n\tv1114 = v1201 < v98.<Params>k__BackingField;\n\tif (v1114) goto L_0182;\nL_FFFFFFFF:\n\tv208 = v255;\nL_FFFFFFFF:\n\tv1024 = v1103;\n\tgoto L_0221;\nL_FFFFFFFF:\n\tv1217 = 0;\nL_FFFFFFFF:\n\tv1249 = v1201;\n\tv951 = v255;\n\tv1018 = _game.CoreSystem.SandPhysics.SpawnUtility::SpawnParticle(&v951 @ stack_-120_v11 (Unity.Entities.EntityCommandBuffer), v98.PrototypeEntity, v954, v221, v1273, *([v755 @ X8_v41+10]), v825, v670, v98.<Params>k__BackingField.ParticleVisualSize);\n\tv1201 = v1249 + 1;\n\tv1217 = v1217 + 1;\n\tv1311 = v1217 >= v1103;\n\tif (v1311) goto L_023D;\n\tv1112 = v1201 < v98.<Params>k__BackingField;\nL_FFFFFFFF:\n\tv208 = v255;\nL_FFFFFFFF:\n\tv1024 = v1103;\nL_FFFFFFFF:\n\tv1249 = v1201;\n\tif (v1112) goto L_01D4;\nL_0221:\n\tv1068 = v1068 + 1;\n\tv959 = v1068 >= v1024;\nL_FFFFFFFF:\n\tv956 = v1236;\n\tif (v959) goto L_00F1;\nL_0237:\n\tv960 = v1201 < v98.<Params>k__BackingField;\nL_FFFFFFFF:\n\tv1236 = v956;\n\tif (v960) goto L_017C;\nL_FFFFFFFF:\n\tv1236 = v956;\n\tgoto L_00F1;\nL_023D:\n\tv1068 = v1068 + 1;\n\tv961 = v1068 < v1103;\nL_FFFFFFFF:\n\tv208 = v255;\nL_FFFFFFFF:\n\tv956 = v1236;\nL_FFFFFFFF:\n\tv1024 = v1103;\n\tif (v961) goto L_0237;\nL_FFFFFFFF:\n\tv208 = v255;\n\tgoto L_00F1;\nL_024F:\n\tUnity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::Clear(&v267 @ stack_-B8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>));\n\tgoto L_025D;\nL_025D:\n\tUnity.Entities.EntityCommandBuffer::Playback(&v255 @ stack_-E0_v3 (Unity.Entities.EntityCommandBuffer), state.EntityManager);\n\tUnity.Entities.EntityCommandBuffer::Dispose(&v255 @ stack_-E0_v3 (Unity.Entities.EntityCommandBuffer));\nL_0276:\n\treturn;\nL_0277:\n\tthrow System.NullReferenceException;\nL_0039:\n\tv73 = 0;\n\tgoto L_004F;\nL_00DC:\n\tv657 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>::get_Length(&v267 @ stack_-B8_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.CubeBreakEvent>));\n\tv668 = v657 < 1;\n\tif (v668) goto L_024F;\nL_0182:\n\tv1089 = v1147 - 1;\n\t// 393 MakeStruct v1088 @ AGG3C8D460_0_v9 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v208 @ stack_-120 (System.Int32), [v755 @ X8_v41+4]\n\tv1210 = _game.CoreSystem.SandPhysics.SpawnUtility::ComputePosition(v1088, &v1103 @ stack_-100_v13 (_game.CoreSystem.SandPhysics.SpawnUtility+GridLayout), v1089, v1068);\n\tv1265 = _game.CoreSystem.SandPhysics.SpawnUtility::ComputeJitter(*([v755 @ X8_v41+14]), v1068, v1089, v1236);\n\tv1108 = v255;\n\tv1153 = _game.CoreSystem.SandPhysics.SpawnUtility::SpawnParticle(&v1108 @ stack_-120_v13 (Unity.Entities.EntityCommandBuffer), v98.PrototypeEntity, v1210, v221, v1265, *([v755 @ X8_v41+10]), v825, v670, v98.<Params>k__BackingField.ParticleVisualSize);\nL_01D4:\n\t// 468 MakeStruct v873 @ AGG3C8D50C_0_v9 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v208 @ stack_-120 (System.Int32), [v755 @ X8_v41+4]\n\tv1258 = _game.CoreSystem.SandPhysics.SpawnUtility::ComputePosition(v873, &v1103 @ stack_-100_v13 (_game.CoreSystem.SandPhysics.SpawnUtility+GridLayout), v1217, v1068);\n\tv1273 = _game.CoreSystem.SandPhysics.SpawnUtility::ComputeJitter(*([v755 @ X8_v41+14]), v1068, v1217, v1236);\n\tv954 = _game.CoreSystem.SandPhysics.SpawnUtility::ClampOutOfBlockedArea(v1258, v670, v530);\nL_017C:\n\tv1086 = v1024 < 1;\n\tif (v1086) goto L_0221;\nL_004F:\n\tv98 = v97.<Current>k__BackingField;\n\tv99 = v97.<Current>k__BackingField == 0;\n\tif (v99) goto L_0276;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandSpawnSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60004D5")]
		[Address(RVA = "0x3C8D674", Offset = "0x3C8D674", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::WithOptions(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), 0x10);\n\tv56 = v61;\n\tv67 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_2055703241_0 = v67;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.SandSpawnSystem)+10]) = state;\n\tv70 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<CubeBreakEvent>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithOptions(EntityQueryOptions.IncludeSystems);
			entityQueryBuilder3 = entityQueryBuilder4;
			EntityQuery _query_2055703241_ = entityQueryBuilder3.Build(ref state);
			__query_2055703241_0 = _query_2055703241_;
			EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0x3C8D804", Offset = "0x3C8D804", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 0x3C8D73C(this, state, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8D73C (inside _game.CoreSystem.SandPhysics.Systems.SandSpawnSystem::__AssignQueries +0xC8)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004D7")]
		[Address(RVA = "0x3C8CFD0", Offset = "0x3C8CFD0", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<CubeBreakEvent>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004D8")]
		[Address(RVA = "0x3C8D024", Offset = "0x3C8D024", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.SandSpawnSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((SandSpawnSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60004D9")]
		[Address(RVA = "0x3C8D028", Offset = "0x3C8D028", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 0x3C8D73C(self, state, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C8D73C (inside _game.CoreSystem.SandPhysics.Systems.SandSpawnSystem::__AssignQueries +0xC8)");
		}
	}
}
