using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000295")]
	public interface IOrderedPathBrush : IGridBrush
	{
		[Token(Token = "0x170000DF")]
		OrderedSelectionDrag DragMode
		{
			[Token(Token = "0x6000B7A")]
			get;
		}

		[Token(Token = "0x6000B7B")]
		bool CanAppend(GridCoord next, IReadOnlyList<GridCoord> current, IPaintContext context);

		[Token(Token = "0x6000B7C")]
		bool TryCommit(IReadOnlyList<GridCoord> selection, IPaintContext context);
	}
}
