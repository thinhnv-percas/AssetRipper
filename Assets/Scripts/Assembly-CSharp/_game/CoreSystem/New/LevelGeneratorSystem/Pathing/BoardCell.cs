using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Pathing
{
	[Token(Token = "0x2000356")]
	public readonly struct BoardCell
	{
		[Token(Token = "0x40009CF")]
		[FieldOffset(Offset = "0x0")]
		public readonly GridCoord Coord;

		[Token(Token = "0x40009D0")]
		[FieldOffset(Offset = "0xC")]
		public readonly GameColor Color;

		[Token(Token = "0x40009D1")]
		[FieldOffset(Offset = "0x10")]
		public readonly bool ColorHidden;

		[Token(Token = "0x40009D2")]
		[FieldOffset(Offset = "0x11")]
		public readonly bool Tappable;

		[Token(Token = "0x40009D3")]
		[FieldOffset(Offset = "0x12")]
		public readonly bool IsTunnelTarget;

		[Token(Token = "0x40009D4")]
		[FieldOffset(Offset = "0x14")]
		public readonly int TunnelQueueRemaining;

		[Token(Token = "0x40009D5")]
		[FieldOffset(Offset = "0x18")]
		public readonly bool IsPinMarker;

		[Token(Token = "0x6000DFA")]
		[Address(RVA = "0x3F00E2C", Offset = "0x3F00E2C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Coord = coord;\n\t*([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell)+8]) = coord.IsValid;\n\tthis.Color = color;\n\tthis.ColorHidden = colorHidden;\n\tthis.Tappable = tappable;\n\tthis.IsTunnelTarget = isTunnelTarget;\n\tthis.TunnelQueueRemaining = tunnelQueueRemaining;\n\tthis.IsPinMarker = isPinMarker;\n\treturn;\n")]
		public BoardCell(GridCoord coord, GameColor color, bool colorHidden, bool tappable, bool isTunnelTarget, int tunnelQueueRemaining, bool isPinMarker)
		{
			Coord = coord;
			_ = coord.IsValid;
			Color = color;
			ColorHidden = colorHidden;
			Tappable = tappable;
			IsTunnelTarget = isTunnelTarget;
			TunnelQueueRemaining = tunnelQueueRemaining;
			IsPinMarker = isPinMarker;
		}
	}
}
