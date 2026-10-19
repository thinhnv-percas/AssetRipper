using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003CC")]
	public interface IGeneratorActions
	{
		[Token(Token = "0x17000146")]
		GenerationPhase CurrentPhase
		{
			[Token(Token = "0x6000FB7")]
			get;
		}

		[Token(Token = "0x6000FB8")]
		ActionResult FinalizeTopGrid();

		[Token(Token = "0x6000FB9")]
		void Reconcile();

		[Token(Token = "0x6000FBA")]
		ActionResult RefreshFrameData();

		[Token(Token = "0x6000FBB")]
		ActionResult SyncRegionPropertiesFromPreset();

		[Token(Token = "0x6000FBC")]
		ActionResult RunWallClosure(Action<string> log = null);

		[Token(Token = "0x6000FBD")]
		ActionResult PlaceCube(GridCoord coord, GameColor color);

		[Token(Token = "0x6000FBE")]
		ActionResult PlaceWall(GridCoord coord);

		[Token(Token = "0x6000FBF")]
		ActionResult<Entity> PlaceTunnel(GridCoord coord, TunnelDirection direction, IReadOnlyList<GameColor> queue);

		[Token(Token = "0x6000FC0")]
		ActionResult PlaceLock(GridCoord targetCoord, GameColor lockColor);

		[Token(Token = "0x6000FC1")]
		ActionResult PlaceKey(GridCoord targetCoord, GameColor keyColor);

		[Token(Token = "0x6000FC2")]
		ActionResult ApplyHidden(GridCoord coord);

		[Token(Token = "0x6000FC3")]
		ActionResult<Entity> PlaceGarage(GridCoord anchor, int sizeX, int sizeY, int counter);

		[Token(Token = "0x6000FC4")]
		ActionResult<Entity> PlaceHammerArea(GridCoord anchor, int sizeX, int sizeY, int counter);

		[Token(Token = "0x6000FC5")]
		ActionResult BuildSnakeAt(IReadOnlyList<GridCoord> headToTailCoords);

		[Token(Token = "0x6000FC6")]
		ActionResult BuildPinAt(IReadOnlyList<GridCoord> cellsInPath, GridCoord triggerCoord);

		[Token(Token = "0x6000FC7")]
		ActionResult LinkCubesAt(IReadOnlyList<GridCoord> coords);

		[Token(Token = "0x6000FC8")]
		ActionResult<Entity> PlaceMold(int column, int row, GameColor color);

		[Token(Token = "0x6000FC9")]
		ActionResult SetMoldGridRows(int rows);

		[Token(Token = "0x6000FCA")]
		GridCoord MoldGridSize();

		[Token(Token = "0x6000FCB")]
		ActionResult LinkMolds(GridCoord moldA, GridCoord moldB);

		[Token(Token = "0x6000FCC")]
		ActionResult SetMoldHidden(GridCoord mold);

		[Token(Token = "0x6000FCD")]
		ActionResult RecolorMold(GridCoord mold, GameColor newColor);

		[Token(Token = "0x6000FCE")]
		ActionResult SwapSandColors(GridCoord a, int queueIndexA, GridCoord b, int queueIndexB);

		[Token(Token = "0x6000FCF")]
		ActionResult RemoveCell(GridCoord coord);

		[Token(Token = "0x6000FD0")]
		ActionResult RemoveWallAt(GridCoord coord);

		[Token(Token = "0x6000FD1")]
		ActionResult RemoveMold(GridCoord mold);

		[Token(Token = "0x6000FD2")]
		bool IsInsideGrid(GridCoord coord);

		[Token(Token = "0x6000FD3")]
		bool IsCellOccupied(GridCoord coord);

		[Token(Token = "0x6000FD4")]
		bool IsCubeAt(GridCoord coord);

		[Token(Token = "0x6000FD5")]
		bool IsWallAt(GridCoord coord);

		[Token(Token = "0x6000FD6")]
		bool IsPourableAtStart(GridCoord coord);

		[Token(Token = "0x6000FD7")]
		bool IsNoPlace(GridCoord coord);

		[Token(Token = "0x6000FD8")]
		bool IsNoPlaceWall(GridCoord coord);

		[Token(Token = "0x6000FD9")]
		IReadOnlyDictionary<GameColor, int> CountCubesByColor();

		[Token(Token = "0x6000FDA")]
		IReadOnlyDictionary<GameColor, int> CountMoldsByColor();

		[Token(Token = "0x6000FDB")]
		IReadOnlyDictionary<GameColor, int> CountTunnelQueueByColor();

		[Token(Token = "0x6000FDC")]
		IReadOnlyList<GameColor> PlacedLockColors();

		[Token(Token = "0x6000FDD")]
		IReadOnlyList<GameColor> PlacedKeyColors();

		[Token(Token = "0x6000FDE")]
		WallDrainageReport CheckWallDrainage();

		[Token(Token = "0x6000FDF")]
		int CountEmptyPlayableCells();

		[Token(Token = "0x6000FE0")]
		LevelCreatorData Snapshot();
	}
}
