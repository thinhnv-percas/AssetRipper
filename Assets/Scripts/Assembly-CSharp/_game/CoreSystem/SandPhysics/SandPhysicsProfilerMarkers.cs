using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using Unity.Profiling.LowLevel;
using Unity.Profiling.LowLevel.Unsafe;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A9")]
	internal static class SandPhysicsProfilerMarkers
	{
		[Token(Token = "0x4000211")]
		public static readonly ProfilerMarker Spawn;

		[Token(Token = "0x4000212")]
		public static readonly ProfilerMarker ForceSpawn;

		[Token(Token = "0x4000213")]
		public static readonly ProfilerMarker Gravity;

		[Token(Token = "0x4000214")]
		public static readonly ProfilerMarker IntegratePosition;

		[Token(Token = "0x4000215")]
		public static readonly ProfilerMarker Conveyor;

		[Token(Token = "0x4000216")]
		public static readonly ProfilerMarker ParticleCollision;

		[Token(Token = "0x4000217")]
		public static readonly ProfilerMarker WallCollision;

		[Token(Token = "0x4000218")]
		public static readonly ProfilerMarker MovingCubePush;

		[Token(Token = "0x4000219")]
		public static readonly ProfilerMarker BoundsCheck;

		[Token(Token = "0x400021A")]
		public static readonly ProfilerMarker SettleDetection;

		[Token(Token = "0x400021B")]
		public static readonly ProfilerMarker GateFreeze;

		[Token(Token = "0x400021C")]
		public static readonly ProfilerMarker SyncTransform;

		[Token(Token = "0x400021D")]
		public static readonly ProfilerMarker MoldAbsorption;

		[Token(Token = "0x400021E")]
		public static readonly ProfilerMarker CollisionGather;

		[Token(Token = "0x400021F")]
		public static readonly ProfilerMarker CollisionSolver;

		[Token(Token = "0x4000220")]
		public static readonly ProfilerMarker CollisionSolverIteration;

		[Token(Token = "0x4000221")]
		public static readonly ProfilerMarker CollisionWriteBack;

		[Token(Token = "0x4000222")]
		public static readonly ProfilerMarker SettleGather;

		[Token(Token = "0x4000223")]
		public static readonly ProfilerMarker SettleJob;

		[Token(Token = "0x4000224")]
		public static readonly ProfilerMarker SettleWriteBack;

		[Token(Token = "0x4000225")]
		public static readonly ProfilerMarker SpawnRebuildCollision;

		[Token(Token = "0x4000226")]
		public static readonly ProfilerMarker ConveyorCountJob;

		[Token(Token = "0x4000227")]
		public static readonly ProfilerMarker ConveyorGateUpdate;

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0x3C7B8E4", Offset = "0x3C7B8E4", Length = "0x568")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0075;\n\tv104.Gravity = v99;\n\tv110 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.IntegratePosition\", 1, 0, 0);\n\tv115.IntegratePosition = v110;\n\tv121 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Conveyor\", 1, 0, 0);\n\tv126.Conveyor = v121;\n\tv132 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.ParticleCollision\", 1, 0, 0);\n\tv137.ParticleCollision = v132;\n\tv143 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.WallCollision\", 1, 0, 0);\n\tv148.WallCollision = v143;\n\tv154 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.MovingCubePush\", 1, 0, 0);\n\tv159.MovingCubePush = v154;\n\tv167 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.BoundsCheck\", 1, 0, 0);\n\tv172.BoundsCheck = v167;\n\tv180 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.SettleDetection\", 1, 0, 0);\n\tv185.SettleDetection = v180;\n\tv193 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.GateFreeze\", 1, 0, 0);\n\tv198.GateFreeze = v193;\n\tv206 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.SyncTransform\", 1, 0, 0);\n\tv211.SyncTransform = v206;\n\tv219 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.MoldAbsorption\", 1, 0, 0);\n\tv224.MoldAbsorption = v219;\n\tv232 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Collision.Gather\", 1, 0, 0);\n\tv237.CollisionGather = v232;\n\tv245 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Collision.Solver\", 1, 0, 0);\n\tv250.CollisionSolver = v245;\n\tv258 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Collision.SolverIteration\", 1, 0, 0);\n\tv263.CollisionSolverIteration = v258;\n\tv271 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Collision.WriteBack\", 1, 0, 0);\n\tv276.CollisionWriteBack = v271;\n\tv284 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Settle.Gather\", 1, 0, 0);\n\tv289.SettleGather = v284;\n\tv297 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Settle.Job\", 1, 0, 0);\n\tv302.SettleJob = v297;\n\tv310 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Settle.WriteBack\", 1, 0, 0);\n\tv315.SettleWriteBack = v310;\n\tv323 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Spawn.RebuildCollision\", 1, 0, 0);\n\tv328.SpawnRebuildCollision = v323;\n\tv336 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Conveyor.CountJob\", 1, 0, 0);\n\tv341.ConveyorCountJob = v336;\n\tv349 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Conveyor.GateUpdate\", 1, 0, 0);\n\tv353.ConveyorGateUpdate = v349;\n\treturn;\nL_0075:\n\tv77 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Spawn\", 1, 0, 0);\n\tv82.Spawn = v77;\n\tv88 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.ForceSpawn\", 1, 0, 0);\n\tv93.ForceSpawn = v88;\n\tv99 = Unity.Profiling.LowLevel.Unsafe.ProfilerUnsafeUtility::CreateMarker(\"SandPhysics.Gravity\", 1, 0, 0);\n")]
		static SandPhysicsProfilerMarkers()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsProfilerMarkers::.cctor");
		}
	}
}
