using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000390")]
	public sealed class VisualIndexMap
	{
		[Token(Token = "0x2000391")]
		public readonly struct VisualNeighbors
		{
			[Token(Token = "0x4000AEB")]
			[FieldOffset(Offset = "0x0")]
			public readonly int? UpLeft;

			[Token(Token = "0x4000AEC")]
			[FieldOffset(Offset = "0x8")]
			public readonly int? UpRight;

			[Token(Token = "0x4000AED")]
			[FieldOffset(Offset = "0x10")]
			public readonly int? DownLeft;

			[Token(Token = "0x4000AEE")]
			[FieldOffset(Offset = "0x18")]
			public readonly int? DownRight;

			[Token(Token = "0x6000EFC")]
			[Address(RVA = "0x3C91F00", Offset = "0x3C91F00", Length = "0xC")]
			public VisualNeighbors(int? upLeft, int? upRight, int? downLeft, int? downRight)
			{
				UpLeft = upLeft;
				UpRight = upRight;
				DownLeft = downLeft;
				DownRight = downRight;
			}
		}

		[Token(Token = "0x4000AE7")]
		[FieldOffset(Offset = "0x10")]
		internal readonly List<GridCoord> _byIndex;

		[Token(Token = "0x4000AE8")]
		[FieldOffset(Offset = "0x18")]
		internal readonly Dictionary<GridCoord, int> _byCoord;

		[Token(Token = "0x4000AE9")]
		[FieldOffset(Offset = "0x20")]
		private readonly List<VisualCellMarker> _markers;

		[Token(Token = "0x4000AEA")]
		[FieldOffset(Offset = "0x28")]
		internal readonly List<(int screenRow, int first, int last)> _rowRanges;

		[Token(Token = "0x1700012F")]
		public int Count
		{
			[Token(Token = "0x6000EF2")]
			[Address(RVA = "0x3C914A4", Offset = "0x3C914A4", Length = "0x4C")]
			get
			{
				List<GridCoord> byIndex = _byIndex;
				return byIndex.Count;
			}
		}

		[Token(Token = "0x17000130")]
		public IReadOnlyList<(int screenRow, int first, int last)> RowRanges
		{
			[Token(Token = "0x6000EF3")]
			[Address(RVA = "0x3C914F0", Offset = "0x3C914F0", Length = "0x8")]
			get
			{
				return _rowRanges;
			}
		}

		[Token(Token = "0x6000EF4")]
		[Address(RVA = "0x3C914F8", Offset = "0x3C914F8", Length = "0x3E0")]
		public static VisualIndexMap Build(Vector2Int gridSize, Func<GridCoord, bool> isNoPlace, Func<GridCoord, bool> isNoPlaceWall)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::Build");
			return default;
		}

		[Token(Token = "0x6000EF5")]
		[Address(RVA = "0x3C91A60", Offset = "0x3C91A60", Length = "0x14C")]
		public GridCoord ToCoord(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::ToCoord");
			return default;
		}

		[Token(Token = "0x6000EF6")]
		[Address(RVA = "0x3C91BAC", Offset = "0x3C91BAC", Length = "0x7C")]
		public bool TryToIndex(GridCoord coord, out int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::TryToIndex");
			index = default;
			return default;
		}

		[Token(Token = "0x6000EF7")]
		[Address(RVA = "0x3C91C28", Offset = "0x3C91C28", Length = "0xC8")]
		public VisualCellMarker MarkerAt(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::MarkerAt");
			return default;
		}

		[Token(Token = "0x6000EF8")]
		[Address(RVA = "0x3C91CF0", Offset = "0x3C91CF0", Length = "0xC")]
		public int ScreenColumn(GridCoord c)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::ScreenColumn");
			return default;
		}

		[Token(Token = "0x6000EF9")]
		[Address(RVA = "0x3C91CFC", Offset = "0x3C91CFC", Length = "0x110")]
		public VisualNeighbors Neighbors(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualIndexMap::Neighbors");
			return default;
		}

		[Token(Token = "0x6000EFA")]
		[Address(RVA = "0x3C918D8", Offset = "0x3C918D8", Length = "0x188")]
		public VisualIndexMap()
		{
			List<GridCoord> byIndex = new List<GridCoord>();
			_byIndex = byIndex;
			Dictionary<GridCoord, int> byCoord = new Dictionary<GridCoord, int>();
			_byCoord = byCoord;
			List<VisualCellMarker> markers = new List<VisualCellMarker>();
			_markers = markers;
			List<(int, int, int)> rowRanges = new List<(int, int, int)>();
			_rowRanges = rowRanges;
		}
	}
}
