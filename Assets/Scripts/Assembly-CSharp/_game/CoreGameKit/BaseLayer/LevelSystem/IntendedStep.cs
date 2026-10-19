using System;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000662")]
	public struct IntendedStep
	{
		[Token(Token = "0x40015D6")]
		[FieldOffset(Offset = "0x0")]
		public Vector2Int Cell;

		[Token(Token = "0x40015D7")]
		[FieldOffset(Offset = "0x8")]
		public string Color;

		[Token(Token = "0x6001AF2")]
		[Address(RVA = "0x3D57910", Offset = "0x3D57910", Length = "0x10")]
		public IntendedStep(Vector2Int cell, string color)
		{
			Cell = cell;
			Color = color;
		}
	}
}
