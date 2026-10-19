using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Reflex.Attributes;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems;

namespace _game.CoreSystem.New.TopGridSystem.Runtime
{
	[Token(Token = "0x2000145")]
	public class TopGridReconcileTick_Runtime : MonoBehaviour
	{
		[Inject(false)]
		[Token(Token = "0x400040D")]
		[FieldOffset(Offset = "0x20")]
		private EntityManager _em;

		[Inject(false)]
		[Token(Token = "0x400040E")]
		[FieldOffset(Offset = "0x28")]
		private TopGridHandler _gridHandler;

		[Inject(false)]
		[Token(Token = "0x400040F")]
		[FieldOffset(Offset = "0x30")]
		private LockGroupHandler _lockGroups;

		[Inject(false)]
		[Token(Token = "0x4000410")]
		[FieldOffset(Offset = "0x38")]
		private TopGridEntitySystemCreator _entityCreator;

		[Inject(false)]
		[Token(Token = "0x4000411")]
		[FieldOffset(Offset = "0x40")]
		private ITopGridCmdProcessor _cmdProcessor;

		[Inject(false)]
		[Token(Token = "0x4000412")]
		[FieldOffset(Offset = "0x48")]
		private TopGridReconcile_RespCleanupSystem _respCleanup;

		[Inject(false)]
		[Token(Token = "0x4000413")]
		[FieldOffset(Offset = "0x50")]
		private TopGridReconcile_BlockerCheckSystem _blockerCheck;

		[Inject(false)]
		[Token(Token = "0x4000414")]
		[FieldOffset(Offset = "0x58")]
		private SandReconcile_NeighborDirtySystem _neighborDirty;

		[Inject(false)]
		[Token(Token = "0x4000415")]
		[FieldOffset(Offset = "0x60")]
		private SandReconcile_GridReleaseSystem _gridRelease;

		[Inject(false)]
		[Token(Token = "0x4000416")]
		[FieldOffset(Offset = "0x68")]
		private SandReconcile_TapEventSystem _tapEvent;

		[Inject(false)]
		[Token(Token = "0x4000417")]
		[FieldOffset(Offset = "0x70")]
		private SandReconcile_LinkedBreakSystem _linkedBreak;

		[Inject(false)]
		[Token(Token = "0x4000418")]
		[FieldOffset(Offset = "0x78")]
		private SandReconcile_LinkedCoverShareSystem _linkedCoverShare;

		[Inject(false)]
		[Token(Token = "0x4000419")]
		[FieldOffset(Offset = "0x80")]
		private SandReconcile_LinkedReevalShareSystem _linkedReevalShare;

		[Inject(false)]
		[Token(Token = "0x400041A")]
		[FieldOffset(Offset = "0x88")]
		private SandReconcile_SnakeShiftSystem _snakeShift;

		[Inject(false)]
		[Token(Token = "0x400041B")]
		[FieldOffset(Offset = "0x90")]
		private SandReconcile_SnakeBodySplitSystem _snakeBodySplit;

		[Inject(false)]
		[Token(Token = "0x400041C")]
		[FieldOffset(Offset = "0x98")]
		private SandReconcile_ParticleSpawnSystem _particleSpawn;

		[Inject(false)]
		[Token(Token = "0x400041D")]
		[FieldOffset(Offset = "0xA0")]
		private SandReconcile_PinTriggerSystem _pinTrigger;

		[Inject(false)]
		[Token(Token = "0x400041E")]
		[FieldOffset(Offset = "0xA8")]
		private SandReconcile_PinResolveSystem _pinResolve;

		[Inject(false)]
		[Token(Token = "0x400041F")]
		[FieldOffset(Offset = "0xB0")]
		private SandReconcile_CellStateSystem _cellState;

		[Inject(false)]
		[Token(Token = "0x4000420")]
		[FieldOffset(Offset = "0xB8")]
		private SandReconcile_TunnelSystem _tunnel;

		[Inject(false)]
		[Token(Token = "0x4000421")]
		[FieldOffset(Offset = "0xC0")]
		private SandReconcile_UnlockSystem _unlock;

		[Inject(false)]
		[Token(Token = "0x4000422")]
		[FieldOffset(Offset = "0xC8")]
		private SandReconcile_GarageCounterSystem _garageCounter;

		[Inject(false)]
		[Token(Token = "0x4000423")]
		[FieldOffset(Offset = "0xD0")]
		private HammerAreaReconcile_LandingSystem _hammerAreaLanding;

		[Inject(false)]
		[Token(Token = "0x4000424")]
		[FieldOffset(Offset = "0xD8")]
		private TopGridReconcile_CoverSystem _cover;

		[Inject(false)]
		[Token(Token = "0x4000425")]
		[FieldOffset(Offset = "0xE0")]
		private TopGridReconcile_RevealSystem _reveal;

		[Inject(false)]
		[Token(Token = "0x4000426")]
		[FieldOffset(Offset = "0xE8")]
		private SandReconcile_PourableEvaluatorSystem _pourableEvaluator;

		[Inject(true)]
		[Token(Token = "0x4000427")]
		[FieldOffset(Offset = "0xF0")]
		private SandReconcile_FrozenVisualSystem _frozenVisual;

		[Inject(false)]
		[Token(Token = "0x4000428")]
		[FieldOffset(Offset = "0xF8")]
		private SandReconcile_MaterialSystem _material;

		[Token(Token = "0x4000429")]
		[FieldOffset(Offset = "0x100")]
		private bool _isConstructed;

		[Inject(false)]
		[Token(Token = "0x6000663")]
		[Address(RVA = "0x3DB5C48", Offset = "0x3DB5C48", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._isConstructed = 1;\n\treturn;\n")]
		private void Construct()
		{
			_isConstructed = true;
		}

		[Token(Token = "0x6000664")]
		[Address(RVA = "0x3DB5C54", Offset = "0x3DB5C54", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._isConstructed != 1;\n\tif (v11) goto L_001D;\n\tv24 = UnityEngine.Time::get_deltaTime();\n\t_game.CoreSystem.New.TopGridSystem.Runtime.TopGridReconcileTick_Runtime::Tick(this, v24);\n\treturn;\nL_001D:\n\treturn;\n")]
		private void Update()
		{
			if (_isConstructed)
			{
				float deltaTime = Time.deltaTime;
				Tick(deltaTime);
			}
		}

		[Token(Token = "0x6000665")]
		[Address(RVA = "0x3DB5C8C", Offset = "0x3DB5C8C", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv52 = *([v47 @ X20_v2 (_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor)]);\n\tv235 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+12E]);\n\tv54 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+12E]) == 0;\n\tif (v54) goto L_0042;\n\tv118 = *([v52 @ X8_v4 (Il2CppClass<_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor>)+B0]) + 8;\n\tv118 = v118 + 0x10;\n\tv223 = v235 - 1;\n\tv213 = v235 != 1;\n\tv235 = v223;\n\tif (v213) goto L_0028;\nL_0042:\n\tv238 = _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::Tick(v47, *([v225 @ X0_v34+8]));\n\tv299 = this._respCleanup;\n\tv239 = this._respCleanup == 0;\n\tv179 = ~v239;\n\tif (v179) goto L_0055;\n\tgoto L_0101;\nL_0049:\n\tv62 = *([v118 @ X10_v12]) << 4;\n\tv294 = v52 + v62;\n\tv295 = v294 + 0x138;\n\t*([v295 @ X0_v38])(v297, v47, *([v295 @ X0_v38+8]), v31, v32, v33, v34, v35, v36, dt, v37, v38, v39, v40, v41, v42, v43);\n\tv299 = this._respCleanup;\nL_0055:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RespCleanupSystem::Execute(v299);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_BlockerCheckSystem::Execute(this._blockerCheck);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_GridReleaseSystem::Execute(this._gridRelease);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_TapEventSystem::Execute(this._tapEvent);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedBreakSystem::Execute(this._linkedBreak);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Systems.SandReconcile_UnlockSystem::Execute(this._unlock);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeShiftSystem::Execute(this._snakeShift);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Systems.SandReconcile_SnakeBodySplitSystem::Execute(this._snakeBodySplit);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_ParticleSpawnSystem::Execute(this._particleSpawn);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinTriggerSystem::Execute(this._pinTrigger);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_CellStateSystem::Execute(this._cellState);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Systems.SandReconcile_TunnelSystem::Execute(this._tunnel);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Systems.SandReconcile_GarageCounterSystem::Execute(this._garageCounter);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Systems.HammerAreaReconcile_LandingSystem::Execute(this._hammerAreaLanding);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_NeighborDirtySystem::Execute(this._neighborDirty);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteRevealDoneCleanup(this._reveal);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedReevalShareSystem::Execute(this._linkedReevalShare);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Systems.SandReconcile_PinResolveSystem::Execute(this._pinResolve);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_PourableEvaluatorSystem::Execute(this._pourableEvaluator);\n\tv303 = this._frozenVisual == 0;\n\tif (v303) goto L_00B9;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.ECS.Systems.SandReconcile_FrozenVisualSystem::Execute(this._frozenVisual);\nL_00B9:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_CoverSystem::Execute(this._cover);\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Systems.SandReconcile_LinkedCoverShareSystem::Execute(this._linkedCoverShare);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.TopGridReconcile_RevealSystem::ExecuteCmdRevealIssue(this._reveal);\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.SandReconcile_MaterialSystem::Execute(this._material);\n\tgoto L_0100;\nL_0101:\n\tthrow System.NullReferenceException;\nL_0017:\n\tv47 = this._cmdProcessor;\nL_0028:\n\tv98 = *([v118 @ X10_v12-8]) == _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor;\n\tif (v98) goto L_0049;\nL_0100:\n\t_game.CoreSystem.New.TopGridSystem.Core.Reconciliation.ITopGridCmdProcessor::ProcessCommands(this._cmdProcessor);\n\treturn;\n")]
		public void Tick(float dt)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TopGridReconcileTick_Runtime::Tick");
		}

		[Token(Token = "0x6000666")]
		[Address(RVA = "0x3DB5F44", Offset = "0x3DB5F44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TopGridReconcileTick_Runtime()
		{
		}
	}
}
