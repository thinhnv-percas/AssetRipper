using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Serialization;

namespace _game.CoreSystem.LevelCreator
{
	[Serializable]
	[Token(Token = "0x20004C3")]
	public class SandCubeCellData
	{
		[Token(Token = "0x4000FEF")]
		[FieldOffset(Offset = "0x10")]
		public bool occupied;

		[SerializeReference]
		[Token(Token = "0x4000FF0")]
		[FieldOffset(Offset = "0x18")]
		public List<ICellComponent> components;

		[Token(Token = "0x4000FF1")]
		[FieldOffset(Offset = "0x20")]
		public DrawableEntity entity;

		[Token(Token = "0x6001403")]
		[Address(RVA = "0x3CF1ADC", Offset = "0x3CF1ADC", Length = "0x8")]
		public SandCubeCellData()
		{
		}
	}
}
