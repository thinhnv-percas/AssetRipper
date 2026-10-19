using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000293")]
	public interface IOrderedEraseBrush : IOrderedPathBrush, IGridBrush
	{
		[Token(Token = "0x6000B79")]
		bool TryErase(IReadOnlyList<GridCoord> selection, IPaintContext context);
	}
}
