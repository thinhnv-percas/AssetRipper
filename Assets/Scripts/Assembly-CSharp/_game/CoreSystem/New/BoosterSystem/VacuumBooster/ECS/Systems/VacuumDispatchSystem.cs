using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Core;
using Unity.Entities;
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
	[StructLayout((LayoutKind)0, Size = 1)]
	[UpdateInGroup(typeof(SandPhysicsSystemGroup))]
	[UpdateAfter(typeof(VacuumBulbSystem))]
	[Token(Token = "0x2000466")]
	public struct VacuumDispatchSystem : ISystem, ISystemCompilerGenerated
	{
		[Token(Token = "0x600126D")]
		[Address(RVA = "0x3CD07A8", Offset = "0x3CD07A8", Length = "0xDB8")]
		public unsafe void OnUpdate(ref SystemState state)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumDispatchSystem::OnUpdate");
		}

		[Token(Token = "0x600126E")]
		[Address(RVA = "0x3CD1560", Offset = "0x3CD1560", Length = "0x4")]
		public void OnCreateForCompiler(ref SystemState state)
		{
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x600126F")]
		[Address(RVA = "0x3CD07A0", Offset = "0x3CD07A0", Length = "0x4")]
		internal unsafe static void __codegen__OnUpdate(IntPtr self, IntPtr state)
		{
			((VacuumDispatchSystem*)self)->OnUpdate(ref *(SystemState*)state);
		}

		[AOT.MonoPInvokeCallback(typeof(SystemBaseDelegates.Function))]
		[Token(Token = "0x6001270")]
		[Address(RVA = "0x3CD07A4", Offset = "0x3CD07A4", Length = "0x4")]
		internal static void __codegen__OnCreateForCompiler(IntPtr self, IntPtr state)
		{
		}
	}
}
