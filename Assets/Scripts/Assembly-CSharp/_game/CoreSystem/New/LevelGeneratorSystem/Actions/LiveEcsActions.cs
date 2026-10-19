using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.PostProcess;
using _game.CoreSystem.New.MoldSystem;
using _game.CoreSystem.New.MoldSystem.Core.Components;
using _game.CoreSystem.New.MoldSystem.Core.Components.Tags;
using _game.CoreSystem.New.MoldSystem.Core.Handlers;
using _game.CoreSystem.New.MoldSystem.EditMode;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;
using _game.CoreSystem.New.TopGridSystem.Core.Reconciliation.HeadlessMode;
using _game.CoreSystem.New.TopGridSystem.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.EditMode;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data;
using _game.CoreSystem.SandPhysics;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003CD")]
	public class LiveEcsActions : IGeneratorActions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003CE")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000BFD")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000BFE")]
			public static Func<Entity, bool> _003C_003E9__51_0;

			[Token(Token = "0x4000BFF")]
			public static Predicate<ICellComponent> _003C_003E9__58_0;

			[Token(Token = "0x4000C00")]
			public static Predicate<ICellComponent> _003C_003E9__58_1;

			[Token(Token = "0x4000C01")]
			public static Predicate<ICellComponent> _003C_003E9__59_0;

			[Token(Token = "0x4000C02")]
			public static Predicate<ICellComponent> _003C_003E9__61_0;

			[Token(Token = "0x4000C03")]
			public static Predicate<ICellComponent> _003C_003E9__62_0;

			[Token(Token = "0x600101D")]
			[Address(RVA = "0x3CAD0A4", Offset = "0x3CAD0A4", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600101E")]
			[Address(RVA = "0x3CAD108", Offset = "0x3CAD108", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal bool _003CRemoveMold_003Eb__51_0(Entity _)
			{
				return true;
			}

			internal bool _003CCountCubesByColor_003Eb__58_0(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions._003C_003Ec::_003CCountCubesByColor_003Eb__58_0");
				return default;
			}

			internal bool _003CCountCubesByColor_003Eb__58_1(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions._003C_003Ec::_003CCountCubesByColor_003Eb__58_1");
				return default;
			}

			internal bool _003CCountMoldsByColor_003Eb__59_0(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions._003C_003Ec::_003CCountMoldsByColor_003Eb__59_0");
				return default;
			}

			internal bool _003CPlacedLockColors_003Eb__61_0(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions._003C_003Ec::_003CPlacedLockColors_003Eb__61_0");
				return default;
			}

			internal bool _003CPlacedKeyColors_003Eb__62_0(ICellComponent c)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions._003C_003Ec::_003CPlacedKeyColors_003Eb__62_0");
				return default;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x20003CF")]
		private sealed class _003C_003Ec__DisplayClass19_0
		{
			[Token(Token = "0x4000C04")]
			[FieldOffset(Offset = "0x10")]
			public Action<string> log;

			[Token(Token = "0x6001025")]
			[Address(RVA = "0x3CAD3AC", Offset = "0x3CAD3AC", Length = "0x8")]
			public _003C_003Ec__DisplayClass19_0()
			{
			}
		}

		[Token(Token = "0x4000BF0")]
		[FieldOffset(Offset = "0x10")]
		private readonly EntityManager _em;

		[Token(Token = "0x4000BF1")]
		[FieldOffset(Offset = "0x18")]
		private readonly TopGridEditorMutations _topGridMutations;

		[Token(Token = "0x4000BF2")]
		[FieldOffset(Offset = "0x20")]
		private readonly MoldEditorMutations _moldMutations;

		[Token(Token = "0x4000BF3")]
		[FieldOffset(Offset = "0x28")]
		private readonly TopGridHandler _gridHandler;

		[Token(Token = "0x4000BF4")]
		[FieldOffset(Offset = "0x30")]
		private readonly MoldGridHandler _moldGridHandler;

		[Token(Token = "0x4000BF5")]
		[FieldOffset(Offset = "0x38")]
		private readonly LinkedCubeEditorMutations _linkedCubeMutations;

		[Token(Token = "0x4000BF6")]
		[FieldOffset(Offset = "0x40")]
		private readonly SandParticleParams _particleParams;

		[Token(Token = "0x4000BF7")]
		[FieldOffset(Offset = "0x50")]
		private readonly Vector2Int _gridSize;

		[Token(Token = "0x4000BF8")]
		[FieldOffset(Offset = "0x58")]
		private readonly FrameController _frameController;

		[Token(Token = "0x4000BF9")]
		[FieldOffset(Offset = "0x60")]
		private readonly FramePresetConfig _framePreset;

		[Token(Token = "0x4000BFA")]
		[FieldOffset(Offset = "0x68")]
		private readonly TopGridReconcileTick_Headless _reconcileTick;

		[Token(Token = "0x4000BFB")]
		[FieldOffset(Offset = "0x70")]
		private GenerationPhase _phase;

		[Token(Token = "0x4000BFC")]
		private const float ReconcileDt = 1f / 60f;

		[Token(Token = "0x17000147")]
		public GenerationPhase CurrentPhase
		{
			[Token(Token = "0x6000FE1")]
			[Address(RVA = "0x3CA387C", Offset = "0x3CA387C", Length = "0x8")]
			get
			{
				return _phase;
			}
		}

		[Token(Token = "0x6000FE2")]
		[Address(RVA = "0x3CA3884", Offset = "0x3CA3884", Length = "0x28")]
		public void Reconcile()
		{
			_reconcileTick.Tick(1f / 60f);
		}

		[Token(Token = "0x6000FE3")]
		[Address(RVA = "0x3CA38AC", Offset = "0x3CA38AC", Length = "0x22C")]
		public ActionResult FinalizeTopGrid()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::FinalizeTopGrid");
			return default;
		}

		[Token(Token = "0x6000FE4")]
		[Address(RVA = "0x3CA3AD8", Offset = "0x3CA3AD8", Length = "0x20C")]
		public unsafe ActionResult RefreshFrameData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RefreshFrameData");
			return default;
		}

		[Token(Token = "0x6000FE5")]
		[Address(RVA = "0x3CA40EC", Offset = "0x3CA40EC", Length = "0x378")]
		public ActionResult SyncRegionPropertiesFromPreset()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::SyncRegionPropertiesFromPreset");
			return default;
		}

		[Token(Token = "0x6000FE6")]
		[Address(RVA = "0x3CA4464", Offset = "0x3CA4464", Length = "0x25C")]
		public ActionResult RunWallClosure(Action<string> log = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RunWallClosure");
			return default;
		}

		[Token(Token = "0x6000FE7")]
		[Address(RVA = "0x3CA3CE4", Offset = "0x3CA3CE4", Length = "0x348")]
		private int CountAllCubes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::CountAllCubes");
			return default;
		}

		[Token(Token = "0x6000FE8")]
		[Address(RVA = "0x3CA46C0", Offset = "0x3CA46C0", Length = "0x100")]
		private bool RequireTopGridPhase(string actionName, out ActionResult error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireTopGridPhase");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FE9")]
		[Address(RVA = "0x4A11258", Offset = "0x4A11258", Length = "0x120")]
		private bool RequireTopGridPhase<T>(string actionName, out ActionResult<T> error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireTopGridPhase");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FEA")]
		[Address(RVA = "0x3CA4B18", Offset = "0x3CA4B18", Length = "0x104")]
		private bool RequireMoldPhase(string actionName, out ActionResult error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireMoldPhase");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FEB")]
		[Address(RVA = "0x4A10F8C", Offset = "0x4A10F8C", Length = "0x128")]
		private bool RequireMoldPhase<T>(string actionName, out ActionResult<T> error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireMoldPhase");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FEC")]
		[Address(RVA = "0x3CA4C1C", Offset = "0x3CA4C1C", Length = "0x1D0")]
		private static bool RequireAllowedColor(GameColor color, out ActionResult error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireAllowedColor");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FED")]
		[Address(RVA = "0x4A10C88", Offset = "0x4A10C88", Length = "0x150")]
		private static bool RequireAllowedColor<T>(GameColor color, out ActionResult<T> error)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RequireAllowedColor");
			error = default;
			return default;
		}

		[Token(Token = "0x6000FEE")]
		[Address(RVA = "0x3CA4DEC", Offset = "0x3CA4DEC", Length = "0x294")]
		public LiveEcsActions(EntityManager em, TopGridEditorMutations topGridMutations, MoldEditorMutations moldMutations, TopGridHandler gridHandler, MoldGridHandler moldGridHandler, LinkedCubeEditorMutations linkedCubeMutations, SandParticleParams particleParams, Vector2Int gridSize, FrameController frameController, FramePresetConfig framePreset, TopGridReconcileTick_Headless reconcileTick)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::.ctor");
		}

		[Token(Token = "0x6000FEF")]
		[Address(RVA = "0x3CA402C", Offset = "0x3CA402C", Length = "0xC0")]
		private static ActionResult Unexpected(Exception ex, string hint)
		{
			Debug.LogException(ex);
			string message = ex.ToString();
			return ActionResult.Fail("UNEXPECTED_FAILURE", message, hint);
		}

		[Token(Token = "0x6000FF0")]
		[Address(RVA = "0x4A11518", Offset = "0x4A11518", Length = "0xD4")]
		private static ActionResult<T> Unexpected<T>(Exception ex, string hint)
		{
			Debug.LogException(ex);
			string message = ex.ToString();
			return ActionResult<T>.Fail("UNEXPECTED_FAILURE", message, hint);
		}

		[Token(Token = "0x6000FF1")]
		[Address(RVA = "0x3CA5080", Offset = "0x3CA5080", Length = "0x4F4")]
		public ActionResult PlaceCube(GridCoord coord, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceCube");
			return default;
		}

		[Token(Token = "0x6000FF2")]
		[Address(RVA = "0x3CA5658", Offset = "0x3CA5658", Length = "0x1A4")]
		public ActionResult PlaceWall(GridCoord coord)
		{
			if (RequireTopGridPhase("PlaceWall", out var error))
			{
				Entity noPlaceWallAt = _gridHandler.GetNoPlaceWallAt(coord);
				if (_em.IsValid(noPlaceWallAt))
				{
					GridCoord gridCoord = coord;
					int num = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					int y = coord.y;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					object arg2 = default(object);
					string message = $"Cell {arg},{arg2} is marked no-wall by the template.";
					return ActionResult.Fail("NO_PLACE_VIOLATION", message, "The template marks this cell as no-placement. Pick a different coord; this marker is permanent for the session.");
				}
				return PlaceWall(coord);
			}
			return error;
		}

		[Token(Token = "0x6000FF3")]
		[Address(RVA = "0x3CA5844", Offset = "0x3CA5844", Length = "0x3D8")]
		private ActionResult PlaceWallInternal(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceWallInternal");
			return default;
		}

		[Token(Token = "0x6000FF4")]
		[Address(RVA = "0x3CA5C1C", Offset = "0x3CA5C1C", Length = "0x35C")]
		public ActionResult RemoveCell(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RemoveCell");
			return default;
		}

		[Token(Token = "0x6000FF5")]
		[Address(RVA = "0x3CA5F78", Offset = "0x3CA5F78", Length = "0x2E8")]
		public ActionResult RemoveWallAt(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RemoveWallAt");
			return default;
		}

		[Token(Token = "0x6000FF6")]
		[Address(RVA = "0x3CA6260", Offset = "0x3CA6260", Length = "0xB3C")]
		public unsafe ActionResult<Entity> PlaceTunnel(GridCoord coord, TunnelDirection direction, IReadOnlyList<GameColor> queue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceTunnel");
			return default;
		}

		[Token(Token = "0x6000FF7")]
		[Address(RVA = "0x3CA6D9C", Offset = "0x3CA6D9C", Length = "0x56C")]
		public ActionResult PlaceLock(GridCoord targetCoord, GameColor lockColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceLock");
			return default;
		}

		[Token(Token = "0x6000FF8")]
		[Address(RVA = "0x3CA7310", Offset = "0x3CA7310", Length = "0x56C")]
		public ActionResult PlaceKey(GridCoord targetCoord, GameColor keyColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceKey");
			return default;
		}

		[Token(Token = "0x6000FF9")]
		[Address(RVA = "0x3CA7308", Offset = "0x3CA7308", Length = "0x8")]
		private static GameColor ToKeyLockColor(GameColor requested)
		{
			return requested & GameColor.Blue;
		}

		[Token(Token = "0x6000FFA")]
		[Address(RVA = "0x3CA787C", Offset = "0x3CA787C", Length = "0x4E8")]
		public ActionResult ApplyHidden(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::ApplyHidden");
			return default;
		}

		[Token(Token = "0x6000FFB")]
		[Address(RVA = "0x3CA7E4C", Offset = "0x3CA7E4C", Length = "0x684")]
		public ActionResult<Entity> PlaceGarage(GridCoord anchor, int sizeX, int sizeY, int counter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceGarage");
			return default;
		}

		[Token(Token = "0x6000FFC")]
		[Address(RVA = "0x3CA84D0", Offset = "0x3CA84D0", Length = "0x684")]
		public ActionResult<Entity> PlaceHammerArea(GridCoord anchor, int sizeX, int sizeY, int counter)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceHammerArea");
			return default;
		}

		[Token(Token = "0x6000FFD")]
		[Address(RVA = "0x3CA8B54", Offset = "0x3CA8B54", Length = "0x864")]
		public ActionResult BuildSnakeAt(IReadOnlyList<GridCoord> headToTailCoords)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::BuildSnakeAt");
			return default;
		}

		[Token(Token = "0x6000FFE")]
		[Address(RVA = "0x3CA93B8", Offset = "0x3CA93B8", Length = "0x708")]
		public unsafe ActionResult BuildPinAt(IReadOnlyList<GridCoord> cellsInPath, GridCoord triggerCoord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::BuildPinAt");
			return default;
		}

		[Token(Token = "0x6000FFF")]
		[Address(RVA = "0x3CA9AC0", Offset = "0x3CA9AC0", Length = "0x7D4")]
		public ActionResult LinkCubesAt(IReadOnlyList<GridCoord> coords)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::LinkCubesAt");
			return default;
		}

		[Token(Token = "0x6001000")]
		[Address(RVA = "0x3CAA294", Offset = "0x3CAA294", Length = "0x5D4")]
		public ActionResult<Entity> PlaceMold(int column, int row, GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlaceMold");
			return default;
		}

		[Token(Token = "0x6001001")]
		[Address(RVA = "0x3CAA868", Offset = "0x3CAA868", Length = "0x204")]
		public ActionResult SetMoldGridRows(int rows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::SetMoldGridRows");
			return default;
		}

		[Token(Token = "0x6001002")]
		[Address(RVA = "0x3CAAA6C", Offset = "0x3CAAA6C", Length = "0x64")]
		public GridCoord MoldGridSize()
		{
			int columns = MoldQueryHelper.GetColumns(_em);
			int rows = MoldQueryHelper.GetRows(_em);
			return new GridCoord(columns, rows);
		}

		[Token(Token = "0x6001003")]
		[Address(RVA = "0x3CAAAD0", Offset = "0x3CAAAD0", Length = "0x310")]
		public ActionResult LinkMolds(GridCoord moldA, GridCoord moldB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::LinkMolds");
			return default;
		}

		[Token(Token = "0x6001004")]
		[Address(RVA = "0x3CAADE0", Offset = "0x3CAADE0", Length = "0x308")]
		public ActionResult SetMoldHidden(GridCoord mold)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::SetMoldHidden");
			return default;
		}

		[Token(Token = "0x6001005")]
		[Address(RVA = "0x3CAB0E8", Offset = "0x3CAB0E8", Length = "0x37C")]
		public ActionResult RecolorMold(GridCoord mold, GameColor newColor)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RecolorMold");
			return default;
		}

		[Token(Token = "0x6001006")]
		[Address(RVA = "0x3CAB464", Offset = "0x3CAB464", Length = "0x350")]
		public ActionResult RemoveMold(GridCoord mold)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::RemoveMold");
			return default;
		}

		[Token(Token = "0x6001007")]
		[Address(RVA = "0x3CAB7B4", Offset = "0x3CAB7B4", Length = "0x314")]
		public ActionResult SwapSandColors(GridCoord a, int queueIndexA, GridCoord b, int queueIndexB)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::SwapSandColors");
			return default;
		}

		[Token(Token = "0x6001008")]
		[Address(RVA = "0x3CABAC8", Offset = "0x3CABAC8", Length = "0x40C")]
		private bool TryResolveSandColorEntity(GridCoord coord, int queueIndex, out Entity entity, out ActionResult fail)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::TryResolveSandColorEntity");
			entity = default;
			fail = default;
			return default;
		}

		[Token(Token = "0x6001009")]
		[Address(RVA = "0x3CABED4", Offset = "0x3CABED4", Length = "0x1E4")]
		private Entity FindTunnelFeeding(GridCoord target)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::FindTunnelFeeding");
			return default;
		}

		[Token(Token = "0x600100A")]
		[Address(RVA = "0x3CAC2C4", Offset = "0x3CAC2C4", Length = "0x13C")]
		private Entity TunnelPointingAt(GridCoord tunnelCoord, TunnelDirection direction)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::TunnelPointingAt");
			return default;
		}

		[Token(Token = "0x600100B")]
		[Address(RVA = "0x3CAC0B8", Offset = "0x3CAC0B8", Length = "0x20C")]
		private unsafe Entity FindQueueSlotSandCube(EntityId tunnelId, int queueIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::FindQueueSlotSandCube");
			return default;
		}

		[Token(Token = "0x600100C")]
		[Address(RVA = "0x3CAC400", Offset = "0x3CAC400", Length = "0x204")]
		public LevelCreatorData Snapshot()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::Snapshot");
			return default;
		}

		[Token(Token = "0x600100D")]
		[Address(RVA = "0x3CA47C0", Offset = "0x3CA47C0", Length = "0x358")]
		public IReadOnlyDictionary<GameColor, int> CountCubesByColor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::CountCubesByColor");
			return default;
		}

		[Token(Token = "0x600100E")]
		[Address(RVA = "0x3CAC604", Offset = "0x3CAC604", Length = "0x288")]
		public IReadOnlyDictionary<GameColor, int> CountMoldsByColor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::CountMoldsByColor");
			return default;
		}

		[Token(Token = "0x600100F")]
		[Address(RVA = "0x3CAC88C", Offset = "0x3CAC88C", Length = "0x18")]
		public IReadOnlyDictionary<GameColor, int> CountTunnelQueueByColor()
		{
			LevelCreatorData data = Snapshot();
			return TunnelQueueSnapshotCounter.CountByColor(data);
		}

		[Token(Token = "0x6001010")]
		[Address(RVA = "0x3CAC8A4", Offset = "0x3CAC8A4", Length = "0x288")]
		public IReadOnlyList<GameColor> PlacedLockColors()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlacedLockColors");
			return default;
		}

		[Token(Token = "0x6001011")]
		[Address(RVA = "0x3CACB2C", Offset = "0x3CACB2C", Length = "0x288")]
		public IReadOnlyList<GameColor> PlacedKeyColors()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::PlacedKeyColors");
			return default;
		}

		[Token(Token = "0x6001012")]
		[Address(RVA = "0x3CACDB4", Offset = "0x3CACDB4", Length = "0x50")]
		public WallDrainageReport CheckWallDrainage()
		{
			FrameController frameController = _frameController;
			LevelCreatorData levelCreatorData = Snapshot();
			FrameData frameData = frameController.m_frameData;
			return WatershedDrainage.Check(frameData, levelCreatorData.sandCubeGrid, null);
		}

		[Token(Token = "0x6001013")]
		[Address(RVA = "0x3CACE04", Offset = "0x3CACE04", Length = "0x150")]
		public int CountEmptyPlayableCells()
		{
			LevelCreatorData levelCreatorData = Snapshot();
			GridData<SandCubeCellData> sandCubeGrid = levelCreatorData.sandCubeGrid;
			int result;
			if (levelCreatorData.sandCubeGrid != null)
			{
				levelCreatorData.sandCubeGrid.EnsureCellsArray();
				int rows = sandCubeGrid.rows;
				if (sandCubeGrid.rows >= 1)
				{
					int columns = sandCubeGrid.columns;
					if (sandCubeGrid.columns >= 1)
					{
						int num = 0;
						int num2 = 0;
						bool flag2;
						do
						{
							if (columns >= 1)
							{
								int num3 = 0;
								do
								{
									GridCoord coord = new GridCoord(num3, num);
									Entity noPlaceAt = _gridHandler.GetNoPlaceAt(coord);
									if (!_em.IsValid(noPlaceAt))
									{
										bool flag = _gridHandler.HasPrimaryAt(coord);
										int num4 = (flag ? 1 : 0) ^ 1;
										num2 += num4;
									}
									num3++;
									columns = sandCubeGrid.columns;
								}
								while (num3 < sandCubeGrid.columns);
								rows = sandCubeGrid.rows;
							}
							num++;
							flag2 = num >= rows;
							result = num2;
						}
						while (!flag2);
						goto IL_01e8;
					}
				}
			}
			result = 0;
			goto IL_01e8;
			IL_01e8:
			return result;
		}

		[Token(Token = "0x6001014")]
		[Address(RVA = "0x3CA5574", Offset = "0x3CA5574", Length = "0x30")]
		public bool IsInsideGrid(GridCoord coord)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LiveEcsActions::IsInsideGrid");
			return default;
		}

		[Token(Token = "0x6001015")]
		[Address(RVA = "0x3CACF54", Offset = "0x3CACF54", Length = "0x20")]
		public bool IsCellOccupied(GridCoord coord)
		{
			return _gridHandler.HasPrimaryAt(coord);
		}

		[Token(Token = "0x6001016")]
		[Address(RVA = "0x3CACF74", Offset = "0x3CACF74", Length = "0x98")]
		public bool IsCubeAt(GridCoord coord)
		{
			GridCoord coord2 = default(GridCoord);
			Entity sandCubeAt = _gridHandler.GetSandCubeAt(coord2);
			Entity entity = sandCubeAt;
			return entity.IsValid;
		}

		[Token(Token = "0x6001017")]
		[Address(RVA = "0x3CAD00C", Offset = "0x3CAD00C", Length = "0x98")]
		public bool IsWallAt(GridCoord coord)
		{
			GridCoord coord2 = default(GridCoord);
			Entity wallAt = _gridHandler.GetWallAt(coord2);
			Entity entity = wallAt;
			return entity.IsValid;
		}

		[Token(Token = "0x6001018")]
		[Address(RVA = "0x3CA55A4", Offset = "0x3CA55A4", Length = "0x48")]
		public bool IsNoPlace(GridCoord coord)
		{
			Entity noPlaceAt = _gridHandler.GetNoPlaceAt(coord);
			return _em.IsValid(noPlaceAt);
		}

		[Token(Token = "0x6001019")]
		[Address(RVA = "0x3CA57FC", Offset = "0x3CA57FC", Length = "0x48")]
		public bool IsNoPlaceWall(GridCoord coord)
		{
			Entity noPlaceWallAt = _gridHandler.GetNoPlaceWallAt(coord);
			return _em.IsValid(noPlaceWallAt);
		}

		[Token(Token = "0x600101A")]
		[Address(RVA = "0x3CA55EC", Offset = "0x3CA55EC", Length = "0x6C")]
		private static ActionResult NoPlaceFail(string what)
		{
			return ActionResult.Fail("NO_PLACE_VIOLATION", what, "The template marks this cell as no-placement. Pick a different coord; this marker is permanent for the session.");
		}

		[Token(Token = "0x600101B")]
		[Address(RVA = "0x4A10B04", Offset = "0x4A10B04", Length = "0x88")]
		private static ActionResult<T> NoPlaceFail<T>(string what)
		{
			return ActionResult<T>.Fail("NO_PLACE_VIOLATION", what, "The template marks this cell as no-placement. Pick a different coord; this marker is permanent for the session.");
		}

		[Token(Token = "0x600101C")]
		[Address(RVA = "0x3CA7D64", Offset = "0x3CA7D64", Length = "0xE8")]
		public bool IsPourableAtStart(GridCoord coord)
		{
			GridCoord coord2 = default(GridCoord);
			Entity sandCubeAt = _gridHandler.GetSandCubeAt(coord2);
			Entity entity = default(Entity);
			bool isValid = entity.IsValid;
			if (!isValid)
			{
				return isValid;
			}
			return _em.HasComponent<CoverOpenTag>(entity);
		}
	}
}
