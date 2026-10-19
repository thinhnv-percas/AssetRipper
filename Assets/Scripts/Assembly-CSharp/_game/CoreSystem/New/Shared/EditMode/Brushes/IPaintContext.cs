using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.Shared.EditMode.Brushes
{
	[Token(Token = "0x2000296")]
	public interface IPaintContext
	{
		[Token(Token = "0x170000E0")]
		EntityManager Entities
		{
			[Token(Token = "0x6000B7D")]
			get;
		}

		[Token(Token = "0x170000E1")]
		IGridSurface Surface
		{
			[Token(Token = "0x6000B7E")]
			get;
		}

		[Token(Token = "0x170000E2")]
		object GridHandler
		{
			[Token(Token = "0x6000B7F")]
			get;
		}

		[Token(Token = "0x170000E3")]
		object Mutations
		{
			[Token(Token = "0x6000B80")]
			get;
		}

		[Token(Token = "0x6000B81")]
		IEnumerable<Entity> GetEntitiesAt(GridCoord coord);
	}
}
