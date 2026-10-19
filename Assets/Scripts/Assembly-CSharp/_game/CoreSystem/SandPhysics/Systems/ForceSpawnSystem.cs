using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Configs;
using _game.CoreSystem.New.BoosterSystem.ForcePour.Core;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.SandPhysics.Components;

namespace _game.CoreSystem.SandPhysics.Systems
{
	[UpdateInGroup(typeof(SandPhysicsSystemGroup), OrderFirst = true)]
	[UpdateAfter(typeof(SandSpawnSystem))]
	[Token(Token = "0x20000CE")]
	public struct ForceSpawnSystem : ISystem, ISystemCompilerGenerated
	{
		[StructLayout((LayoutKind)0, Size = 1)]
		[Token(Token = "0x20000CF")]
		private struct TypeHandle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[Token(Token = "0x60003F3")]
			[Address(RVA = "0x3C863B4", Offset = "0x3C863B4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			public void __AssignHandles(ref SystemState state)
			{
			}
		}

		[Token(Token = "0x40002A9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		private TypeHandle __TypeHandle;

		[Token(Token = "0x40002AA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		private EntityQuery __query_728272582_0;

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0x3C85664", Offset = "0x3C85664", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		public void OnCreate(ref SystemState state)
		{
			state.RequireForUpdate<ForceBreakEvent>();
		}

		[Token(Token = "0x60003ED")]
		[Address(RVA = "0x3C856B8", Offset = "0x3C856B8", Length = "0xB64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004C;\n\tgoto L_0077;\nL_0077:\n\tv394 = UnityEngine.Object::op_Equality(v107.Config, 0);\n\tv401 = v394 == 0;\n\tif (v401) goto L_008E;\n\tgoto L_0478;\nL_008E:\n\tgoto L_009D;\n\tv373 = v696.<Instance>k__BackingField;\n\tgoto L_00B2;\nL_00B2:\n\tv707 = UnityEngine.Object::op_Equality(v696.<Instance>k__BackingField, 0);\n\tv710 = ~v707;\n\tif (v710) goto L_00EA;\nL_00B5:\n\t;\n\tv715 = Unity.Entities.EntityQuery::GetSingletonEntity(&this.__query_728272582_0 (Unity.Entities.EntityQuery));\n\tv722 = state.EntityManager;\n\tgoto L_00C9;\nL_00C9:\n\tv740 = Unity.Entities.EntityManager::GetBuffer(&v722 @ stack_-138_v3 (Unity.Entities.EntityManager), v715, 0);\n\tv362 = v740;\n\tUnity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::Clear(&v362 @ stack_-148_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>));\n\tv722 = state.EntityManager;\n\tv772 = Unity.Entities.EntityManager::GetBuffer(&v722 @ stack_-138_v3 (Unity.Entities.EntityManager), v715, 0);\n\tv358 = v772;\n\tUnity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>::Clear(&v358 @ stack_-158_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>));\n\tgoto L_0478;\nL_00EA:\n\t;\n\tv750 = Unity.Entities.EntityQuery::GetSingletonEntity(&this.__query_728272582_0 (Unity.Entities.EntityQuery));\n\tv722 = state.EntityManager;\n\tgoto L_00FE;\nL_00FE:\n\tv783 = Unity.Entities.EntityManager::GetBuffer(&v722 @ stack_-138_v3 (Unity.Entities.EntityManager), v750, 0);\n\tv354 = v783;\n\tv352 = v750;\n\tv722 = state.EntityManager;\n\tv790 = Unity.Entities.EntityManager::GetBuffer(&v722 @ stack_-138_v3 (Unity.Entities.EntityManager), v750, 0);\n\tv350 = v790;\n\tv348 = v750;\n\tv795 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::get_Length(&v354 @ stack_-100_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>));\n\tv404 = v795 == 0;\n\tif (v404) goto L_0176;\n\tv799 = &v800 @ stack_-F0_v3;\n\tv801 = v107.<Params>k__BackingField;\n\tv803 = v107.RenderAssets;\n\tv809 = _game.CoreSystem.New.BoosterSystem.ForcePour.Core.ForcePourController::get_AbsorptionProfile(v696.<Instance>k__BackingField);\n\tv893 = _game.CoreSystem.New.BoosterSystem.ForcePour.Core.ForcePourController::get_StaggerDuration(v696.<Instance>k__BackingField);\n\tv938 = v893 & 0x7FFFFFFF;\n\tv940 = v938 < 0x7F800000;\n\tv941 = ~v940;\n\tv942 = v938 - 0x7F800000;\n\tv944 = v942 == 0;\n\tv947 = ~v941;\n\tv870 = v947 | v944;\n\tv948 = ~v870;\n\tif (v948) goto L_FFFFFFFF;\n\tv885 = v893 < 0;\n\tgoto L_0147;\nL_FFFFFFFF:\n\tv885 = 1;\nL_FFFFFFFF:\n\tv893 = 0;\n\tgoto L_0153;\n\tv920 = *([v373 @ X21_v8 (UnityEngine.Object)+20]);\n\tv873 = *([v920 @ X8_v136+38]);\nL_016A:\n\tv913 = UnityEngine.Object::op_Inequality(v107.RenderAssets, 0);\n\tv983 = v913 == 0;\n\tif (v983) goto L_018E;\n\tv284 = *([v803 @ X25_v4 (UnityEngine.Object)+28]);\n\tgoto L_01A0;\nL_0176:\n\tv397 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>::get_Length(&v350 @ stack_-110_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>));\n\tv291 = v397 < 1;\n\tif (v291) goto L_0478;\n\tUnity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>::Clear(&v350 @ stack_-110_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakTarget>));\n\tgoto L_0478;\nL_018E:\n\tgoto L_0195;\n\tv922 = *([v373 @ X21_v8 (UnityEngine.Object)+20]);\n\tv284 = *([v922 @ X8_v135+6C]);\nL_01AE:\n\tUnity.Entities.EntityCommandBuffer::.ctor(&v1017 @ stack_-130_v4 (Unity.Entities.EntityCommandBuffer), v1005);\n\tv1023 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::get_Length(&v354 @ stack_-100_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>));\n\tv1034 = v1023 < 1;\n\tif (v1034) goto L_044B;\n\tv1040 = v873 + v873;\n\tv1041 = v147 + v147;\n\tv1045 = v147 * 0xFFFFFFFFBE99999A;\n\tv1049 = v147 * 0x3E99999A;\n\tv1050 = v1049 - v1045;\nL_FFFFFFFF:\n\tv1621 = v147;\nL_FFFFFFFF:\n\tv1655 = v873;\nL_FFFFFFFF:\n\tv1681 = v147;\nL_FFFFFFFF:\n\tv1168 = 0;\n\tgoto L_01F4;\nL_01DC:\n\tv1168 = v1168 + 1;\n\tv1125 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::get_Length(&v354 @ stack_-100_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>));\n\tv1102 = v1168 >= v1125;\n\tif (v1102) goto L_044B;\nL_01F4:\n\tv1176 = Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>::get_Item(&v354 @ stack_-100_v3 (Unity.Entities.DynamicBuffer`1<_game.CoreSystem.SandPhysics.ForceBreakEvent>), v1168);\n\tv1192 = v1181 < 1;\nL_FFFFFFFF:\n\tv1058 = v1058;\nL_FFFFFFFF:\n\tv1061 = v1061;\nL_FFFFFFFF:\n\tv1062 = v1062;\n\tif (v1192) goto L_01DC;\n\tv1209 = v1621 < 1;\nL_FFFFFFFF:\n\tv1058 = v1058;\nL_FFFFFFFF:\n\tv1061 = v1061;\nL_FFFFFFFF:\n\tv1062 = v1062;\n\tif (v1209) goto L_01DC;\n\tv888 = v107.<Params>k__BackingField - v1621;\n\tv886 = v888 < 0;\n\tv882 = v107.<Params>k__BackingField ^ v1621;\n\tv880 = v107.<Params>k__BackingField ^ v888;\n\tv878 = v882 & v880;\n\tv876 = v878 < 0;\n\tv1456 = v886 == v876;\n\tv871 = ~v1456;\n\tv869 = ~v871;\n\tif (v869) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1460 = v107.<Params>k__BackingField;\n\tgoto L_022F;\nL_FFFFFFFF:\n\tv1460 = v1621;\nL_023F:\n\tv1476 = UnityEngine.Object::op_Inequality(v107.RenderAssets, 0);\n\tv1478 = ~v1476;\n\tif (v1478) goto L_FFFFFFFF;\n\tv1500 = _game.CoreSystem.SandPhysics.SandRenderingAssetsSO::GetParticleColor(v107.RenderAssets, v1061);\nL_FFFFFFFF:\n\tv1301 = v1500;\n\tgoto L_025E;\nL_FFFFFFFF:\n\tv1301 = 1f;\n\tv1412 = v1460 - 1;\n\tv1328 = v1460 < 1;\nL_FFFFFFFF:\n\tv1058 = v1058;\nL_FFFFFFFF:\n\tv1061 = v1061;\nL_FFFFFFFF:\n\tv1062 = v1062;\n\tif (v1328) goto L_01DC;\n\tv1520 = ~v1181;\n\tv1521 = v1181 & v1520;\n\tv1522 = v1521 - 1;\n\tv1684 = v1420.count;\n\tv1527 = v1622 * 0xD;\n\tv1528 = v1061 + v1527;\n\tv1529 = v1528 + 0x3E;\n\tv1530 = v1529 ^ v1529;\n\tv1532 = v1530 ^ 0x3D;\n\tv1289 = v1532 << 3;\n\tv1533 = v1532 + v1289;\n\tv1534 = v1533 ^ v1533;\n\tv1537 = v1534 * 0x27D4EB2D;\n\tv1538 = v1537 ^ v1537;\n\tv1539 = v1538 ^ v1538;\n\tv1540 = v1539 ^ v1539;\n\tv1541 = v1540 ^ v1540;\n\tv1544 = v1058 + 1;\nL_FFFFFFFF:\n\tv1058 = v1058;\nL_FFFFFFFF:\n\tv1061 = v1061;\nL_FFFFFFFF:\n\tv1062 = v1062;\nL_FFFFFFFF:\n\tv1287 = v1541;\nL_FFFFFFFF:\n\tv1571 = 0;\nL_FFFFFFFF:\n\tv1295 = 0;\nL_FFFFFFFF:\n\tv1575 = *([v1466 @ X8_v88]);\nL_FFFFFFFF:\n\tv1417 = 0;\nL_FFFFFFFF:\n\tv1430 = *([v1466 @ X8_v88]);\nL_FFFFFFFF:\n\tv1642 = 0;\n\tv1799 = v1417 + v1058;\n\tgoto L_02F5;\nL_02BC:\n\tv1751 = v1417 - v1522;\n\tv1752 = v1751 < 0;\n\tv1753 = v1751 == 0;\n\tv1754 = v1417 ^ v1522;\n\tv1755 = v1417 ^ v1751;\n\tv1756 = v1754 & v1755;\n\tv1757 = v1756 < 0;\n\tv1758 = v1752 == v1757;\n\tv1759 = ~v1753;\n\tv1760 = v1758 & v1759;\n\tv1651 = ~v1760;\n\tif (v1651) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1687 = v1417;\n\tgoto L_02CC;\nL_FFFFFFFF:\n\tv1687 = v1522;\n\tv1794 = ~v1417;\n\tv1762 = v1687 - v1417;\n\tv1799 = v1544 + v1417;\nL_FFFFFFFF:\n\tv1798 = v1794;\n\tv1798 = v1798 - 1;\n\tv1799 = v1799 + 1;\n\tv1822 = v1762 - 1;\n\tv1823 = v1762 != 1;\nL_FFFFFFFF:\n\tv1762 = v1822;\n\tif (v1823) goto L_02D3;\n\tgoto L_FFFFFFFF;\nL_02F4:\n\tv1417 = 0 - v1798;\n\tv1844 = &v800 @ stack_-F0_v3;\n\t*([v1844 @ X8_v103]) = v1017;\n\t*([v1844 @ X8_v103+10]) = 0;\n\t// 806 MakeStruct v1241 @ AGG3C85F14_4_v9 (Unity.Mathematics.float2), typeof(Unity.Mathematics.float2), v1839.zero (Unity.Mathematics.float2), v1839.zero.y (System.Single)\n\tv1855 = _game.CoreSystem.SandPhysics.SpawnUtility::SpawnParticle(&v800 @ stack_-F0_v3, v107.PrototypeEntity, v1818, v284, v1241, v1061, v1301, v801.ParticleRadius, v107.<Params>k__BackingField.ParticleVisualSize);\n\t_game.CoreSystem.SandPhysics.Components.ParticleState::set_IsAbsorbing(&v1238 @ stack_-174_v11 (_game.CoreSystem.SandPhysics.Components.ParticleState), 1);\n\tgoto L_033B;\nL_033B:\n\tv1891 = v1238 | 0xFF;\n\tv1897 = v1891 & 0xFFFFFF;\n\tUnity.Entities.EntityCommandBuffer::SetComponent(&v1017 @ stack_-130_v4 (Unity.Entities.EntityCommandBuffer), v1855, v1897);\n\tv1902 = v1460 < 2;\n\tv1903 = ~v1902;\n\tv1911 = ~v1903;\nL_FFFFFFFF:\n\tv1919 = 0;\n\tif (v1911) goto L_0356;\n\tv1915 = v1295 / v1412;\n\tv1919 = v893 * v1915;\n\tv1930 = v1287 ^ v1287;\n\tv1931 = v1930 ^ v1930;\n\tv1933 = v1287 >> 9;\n\tv1934 = v1933 & 0x7FFFFF;\n\tv1936 = 0x3F800000 | v1934;\n\tv1937 = v1931 ^ v1931;\n\tv1940 = v1936 + -1f;\n\tv1942 = v1040 * v1\n// ... truncated")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ForceSpawnSystem::OnUpdate");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x60003EE")]
		[Address(RVA = "0x3C8621C", Offset = "0x3C8621C", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv56 = v55;\n\tv61 = Unity.Entities.EntityQueryBuilder::WithOptions(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), 0x10);\n\tv56 = v61;\n\tv67 = Unity.Entities.EntityQueryBuilder::Build(&v56 @ stack_-50_v1 (Unity.Entities.EntityQueryBuilder), state);\n\tthis.__query_728272582_0 = v67;\n\t*([this @ X0 (_game.CoreSystem.SandPhysics.Systems.ForceSpawnSystem)+10]) = state;\n\tv70 = Unity.Entities.EntityQueryBuilder::Reset(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\tUnity.Entities.EntityQueryBuilder::Dispose(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n\treturn;\nL_0017:\n\tv45 = 0;\n\tv49 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(2);\n\tUnity.Entities.EntityQueryBuilder::.ctor(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder), v49);\n\tv55 = Unity.Entities.EntityQueryBuilder::WithAll(&v45 @ stack_-40_v1 (Unity.Entities.EntityQueryBuilder));\n")]
		private void __AssignQueries(ref SystemState state)
		{
			EntityQueryBuilder entityQueryBuilder = default(EntityQueryBuilder);
			AllocatorManager.AllocatorHandle allocator = Allocator.Temp;
			entityQueryBuilder = new EntityQueryBuilder(allocator);
			EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<ForceBreakEvent>();
			EntityQueryBuilder entityQueryBuilder3 = entityQueryBuilder2;
			EntityQueryBuilder entityQueryBuilder4 = entityQueryBuilder3.WithOptions(EntityQueryOptions.IncludeSystems);
			entityQueryBuilder3 = entityQueryBuilder4;
			EntityQuery _query_728272582_ = entityQueryBuilder3.Build(ref state);
			__query_728272582_0 = _query_728272582_;
			EntityQueryBuilder entityQueryBuilder5 = entityQueryBuilder.Reset();
			entityQueryBuilder.Dispose();
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0x3C863AC", Offset = "0x3C863AC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 0x3C862E4(this, state, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		public void OnCreateForCompiler(ref SystemState state)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C862E4 (inside _game.CoreSystem.SandPhysics.Systems.ForceSpawnSystem::__AssignQueries +0xC8)");
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003F0")]
		[Address(RVA = "0x3C85604", Offset = "0x3C85604", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tUnity.Entities.SystemState::RequireForUpdate(state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnCreate(IntPtr self, IntPtr state)
		{
			((SystemState*)state)->RequireForUpdate<ForceBreakEvent>();
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003F1")]
		[Address(RVA = "0x3C85658", Offset = "0x3C85658", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t_game.CoreSystem.SandPhysics.Systems.ForceSpawnSystem::OnUpdate(self, state);\n\treturn;\n")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((ForceSpawnSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x60003F2")]
		[Address(RVA = "0x3C8565C", Offset = "0x3C8565C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 0x3C862E4(self, state, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);\n\treturn;\n")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @3C862E4 (inside _game.CoreSystem.SandPhysics.Systems.ForceSpawnSystem::__AssignQueries +0xC8)");
		}
	}
}
