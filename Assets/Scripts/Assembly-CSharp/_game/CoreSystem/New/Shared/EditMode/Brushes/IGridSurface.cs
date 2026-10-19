using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000291")]
	public interface IGridSurface
	{
		[Token(Token = "0x170000DC")]
		int Columns
		{
			[Token(Token = "0x6000B71")]
			get;
		}

		[Token(Token = "0x170000DD")]
		int Rows
		{
			[Token(Token = "0x6000B72")]
			get;
		}

		[Token(Token = "0x170000DE")]
		Plane Plane
		{
			[Token(Token = "0x6000B77")]
			get;
		}

		[Token(Token = "0x6000B73")]
		bool IsValidCoord(GridCoord coord);

		[Token(Token = "0x6000B74")]
		Vector3 GridToWorld(GridCoord coord);

		[Token(Token = "0x6000B75")]
		GridCoord WorldToGrid(Vector3 world);

		[Token(Token = "0x6000B76")]
		void GetCellCorners(GridCoord coord, Vector3[] cornersOut);
	}
}
