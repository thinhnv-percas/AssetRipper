using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000290")]
	public interface IGridBrush
	{
		[Token(Token = "0x170000DA")]
		string DisplayName
		{
			[Token(Token = "0x6000B6A")]
			get;
		}

		[Token(Token = "0x170000DB")]
		string CellLetter
		{
			[Token(Token = "0x6000B6B")]
			get;
		}

		[Token(Token = "0x6000B6C")]
		IEnumerable<GridCoord> GetFootprint(GridCoord target, IPaintContext context);

		[Token(Token = "0x6000B6D")]
		bool CanPaint(GridCoord target, IPaintContext context);

		[Token(Token = "0x6000B6E")]
		bool Matches(Entity entity, EntityManager em);

		[Token(Token = "0x6000B6F")]
		void DrawParameters();

		[Token(Token = "0x6000B70")]
		void Paint(IReadOnlyList<GridCoord> targets, IPaintContext context);
	}
}
