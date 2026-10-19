using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Audit
{
	[Token(Token = "0x20003B8")]
	public sealed class LinkedGroupInfo
	{
		[Token(Token = "0x4000BB1")]
		[FieldOffset(Offset = "0x10")]
		public List<GridCoord> Members;

		[Token(Token = "0x6000F7B")]
		[Address(RVA = "0x3C9DE00", Offset = "0x3C9DE00", Length = "0x8C")]
		public LinkedGroupInfo()
		{
			List<GridCoord> members = new List<GridCoord>();
			Members = members;
		}
	}
}
