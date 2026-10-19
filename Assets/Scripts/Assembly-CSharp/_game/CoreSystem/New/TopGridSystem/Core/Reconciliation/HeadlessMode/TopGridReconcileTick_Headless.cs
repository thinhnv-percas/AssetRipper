using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems;

namespace _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode
{
	[Token(Token = "0x2000270")]
	public class TopGridReconcileTick_Headless
	{
		[Inject(false)]
		[Token(Token = "0x4000789")]
		[FieldOffset(Offset = "0x10")]
		private ITopGridCmdProcessor _cmdProcessor;

		[Inject(false)]
		[Token(Token = "0x400078A")]
		[FieldOffset(Offset = "0x18")]
		private TopGridReconcile_RespCleanupSystem _respCleanup;

		[Inject(false)]
		[Token(Token = "0x400078B")]
		[FieldOffset(Offset = "0x20")]
		private TopGridReconcile_BlockerCheckSystem _blockerCheck;

		[Inject(false)]
		[Token(Token = "0x400078C")]
		[FieldOffset(Offset = "0x28")]
		private SandReconcile_NeighborDirtySystem _neighborDirty;

		[Inject(false)]
		[Token(Token = "0x400078D")]
		[FieldOffset(Offset = "0x30")]
		private SandReconcile_GridReleaseSystem _gridRelease;

		[Inject(false)]
		[Token(Token = "0x400078E")]
		[FieldOffset(Offset = "0x38")]
		private SandReconcile_LinkedBreakSystem _linkedBreak;

		[Inject(false)]
		[Token(Token = "0x400078F")]
		[FieldOffset(Offset = "0x40")]
		private SandReconcile_PinTriggerSystem _pinTrigger;

		[Inject(false)]
		[Token(Token = "0x4000790")]
		[FieldOffset(Offset = "0x48")]
		private SandReconcile_PinResolveSystem _pinResolve;

		[Inject(false)]
		[Token(Token = "0x4000791")]
		[FieldOffset(Offset = "0x50")]
		private SandReconcile_CellStateSystem _cellState;

		[Inject(false)]
		[Token(Token = "0x4000792")]
		[FieldOffset(Offset = "0x58")]
		private SandReconcile_TunnelSystem _tunnel;

		[Inject(false)]
		[Token(Token = "0x4000793")]
		[FieldOffset(Offset = "0x60")]
		private SandReconcile_UnlockSystem _unlock;

		[Inject(false)]
		[Token(Token = "0x4000794")]
		[FieldOffset(Offset = "0x68")]
		private SandReconcile_SnakeShiftSystem _snakeShift;

		[Inject(false)]
		[Token(Token = "0x4000795")]
		[FieldOffset(Offset = "0x70")]
		private SandReconcile_SnakeBodySplitSystem _snakeBodySplit;

		[Inject(false)]
		[Token(Token = "0x4000796")]
		[FieldOffset(Offset = "0x78")]
		private SandReconcile_GarageCounterSystem _garageCounter;

		[Inject(false)]
		[Token(Token = "0x4000797")]
		[FieldOffset(Offset = "0x80")]
		private TopGridReconcile_CoverSystem _cover;

		[Inject(false)]
		[Token(Token = "0x4000798")]
		[FieldOffset(Offset = "0x88")]
		private TopGridReconcile_RevealSystem _reveal;

		[Inject(false)]
		[Token(Token = "0x4000799")]
		[FieldOffset(Offset = "0x90")]
		private SandReconcile_PourableEvaluatorSystem _pourableEvaluator;

		[Inject(false)]
		[Token(Token = "0x400079A")]
		[FieldOffset(Offset = "0x98")]
		private SandReconcile_MaterialSystem _material;

		[Token(Token = "0x6000AB4")]
		[Address(RVA = "0x3EBB240", Offset = "0x3EBB240", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv52 = *([v47 @ X20_v2 (_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor)]);\n\tv219 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+12E]);\n\tv54 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+12E]) == 0;\n\tif (v54) goto L_003F;\n\tv120 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+B0]) + 8;\n\tv120 = v120 + 0x10;\n\tv207 = v219 - 1;\n\tv197 = v219 != 1;\n\tv219 = v207;\n\tif (v197) goto L_0028;\nL_003F:\n\t;\n\tv222 = _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::Tick(v47, *([v209 @ X0_v34+8]));\n\tv282 = this._respCleanup;\n\tv223 = this._respCleanup == 0;\n\tv163 = ~v223;\n\tif (v163) goto L_0054;\n\tgoto L_00ED;\nL_0049:\n\tv64 = *([v120 @ X10_v12]) << 4;\n\tv278 = v52 + v64;\n\tv279 = v278 + 0x138;\n\t*([v279 @ X0_v38])(v281, v47, *([v279 @ X0_v38+8]), v72, v32, v33, v34, v35, v36, dt, v37, v38, v39, v40, v41, v42, v43);\n\tv282 = this._respCleanup;\nL_0054:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RespCleanupSystem::Execute(v282);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_BlockerCheckSystem::Execute(this._blockerCheck);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_GridReleaseSystem::Execute(this._gridRelease);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem::Execute(this._linkedBreak);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem::Execute(this._pinTrigger);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_CellStateSystem::Execute(this._cellState);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem::Execute(this._tunnel);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.SandReconcile_UnlockSystem::Execute(this._unlock);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem::Execute(this._snakeShift);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem::Execute(this._snakeBodySplit);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem::Execute(this._garageCounter);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::Execute(this._neighborDirty);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteRevealDoneCleanup(this._reveal);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem::Execute(this._pinResolve);\n\tv191 = this._pourableEvaluator;\n\tgoto L_00A5;\nL_00A5:\n\tv295 = _game.BaseLayerSystems.EntitySystem.Core.EntityManager::Query(v191._em);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_PourableEvaluatorSystem::CheckBlocking(v191, v295);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_CoverSystem::Execute(this._cover);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteCmdRevealIssue(this._reveal);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_MaterialSystem::Execute(this._material);\n\tgoto L_00EC;\nL_00ED:\n\tthrow System.NullReferenceException;\nL_0017:\n\tv47 = this._cmdProcessor;\nL_0028:\n\tv100 = *([v120 @ X10_v12-8]) == _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor;\n\tif (v100) goto L_0049;\nL_00EC:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::ProcessCommands(this._cmdProcessor);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Tick(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcileTick_Headless::Tick");
		}

		[Token(Token = "0x6000AB5")]
		[Address(RVA = "0x3EBB4B0", Offset = "0x3EBB4B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TopGridReconcileTick_Headless()
		{
		}
	}
}
