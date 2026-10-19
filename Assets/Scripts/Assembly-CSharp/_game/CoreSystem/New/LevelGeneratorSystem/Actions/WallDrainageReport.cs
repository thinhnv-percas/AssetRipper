using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003D2")]
	public readonly struct WallDrainageReport
	{
		[Token(Token = "0x4000C05")]
		[FieldOffset(Offset = "0x0")]
		public readonly bool Drains;

		[Token(Token = "0x4000C06")]
		[FieldOffset(Offset = "0x4")]
		public readonly int TrappedCellCount;

		[Token(Token = "0x4000C07")]
		[FieldOffset(Offset = "0x8")]
		public readonly IReadOnlyList<GridCoord> TrappedCells;

		[Token(Token = "0x600102A")]
		[Address(RVA = "0x3CADEA4", Offset = "0x3CADEA4", Length = "0x100")]
		public WallDrainageReport(bool drains, int trappedCellCount, IReadOnlyList<GridCoord> trappedCells)
		{
			Drains = drains;
			TrappedCellCount = trappedCellCount;
			bool flag = trappedCells == null;
			bool flag2 = !flag;
			IReadOnlyList<GridCoord> trappedCells2 = trappedCells;
			if (!flag2)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v19 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>>)+135]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag3 = num2 == 0;
				nint num3 = 0;
				if (flag3)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X0_v9+E4]");
					if ((nint)0 != 0)
					{
					}
				}
				trappedCells2 = Array.Empty<GridCoord>();
			}
			TrappedCells = trappedCells2;
		}
	}
}
