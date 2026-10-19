using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000292")]
	public interface IMultiCellBrush : IGridBrush
	{
		[Token(Token = "0x6000B78")]
		GridCoord GetAnchor(Entity entity, IPaintContext context);
	}
}
