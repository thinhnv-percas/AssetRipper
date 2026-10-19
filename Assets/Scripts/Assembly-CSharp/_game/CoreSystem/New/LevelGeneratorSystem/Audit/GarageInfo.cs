using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003B6")]
	public sealed class GarageInfo
	{
		[Token(Token = "0x4000BAB")]
		[FieldOffset(Offset = "0x10")]
		public GridCoord Anchor;

		[Token(Token = "0x4000BAC")]
		[FieldOffset(Offset = "0x20")]
		public List<GridCoord> Covered;

		[Token(Token = "0x4000BAD")]
		[FieldOffset(Offset = "0x28")]
		public int Counter;

		[Token(Token = "0x6000F79")]
		[Address(RVA = "0x3C9DD6C", Offset = "0x3C9DD6C", Length = "0x8C")]
		public GarageInfo()
		{
			List<GridCoord> covered = new List<GridCoord>();
			Covered = covered;
		}
	}
}
