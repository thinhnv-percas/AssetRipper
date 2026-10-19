using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Entities;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x200044D")]
	public struct PlannedMold
	{
		[Token(Token = "0x4000DA5")]
		[FieldOffset(Offset = "0x0")]
		public int MoldEntityIndex;

		[Token(Token = "0x4000DA6")]
		[FieldOffset(Offset = "0x4")]
		public int MoldEntityGeneration;

		[Token(Token = "0x4000DA7")]
		[FieldOffset(Offset = "0x8")]
		public GameColor Color;

		[Token(Token = "0x4000DA8")]
		[FieldOffset(Offset = "0xC")]
		public int Row;

		[Token(Token = "0x4000DA9")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000DAA")]
		[FieldOffset(Offset = "0x14")]
		public int Capacity;

		[Token(Token = "0x4000DAB")]
		[FieldOffset(Offset = "0x18")]
		public int DataFill;

		[Token(Token = "0x4000DAC")]
		[FieldOffset(Offset = "0x1C")]
		public int Need;

		[Token(Token = "0x4000DAD")]
		[FieldOffset(Offset = "0x20")]
		public List<Entity> AssignedGrains;

		[Token(Token = "0x4000DAE")]
		[FieldOffset(Offset = "0x28")]
		public float Frontness;

		[Token(Token = "0x4000DAF")]
		[FieldOffset(Offset = "0x2C")]
		public float Conveyorness;

		[Token(Token = "0x4000DB0")]
		[FieldOffset(Offset = "0x30")]
		public float Proximity;

		[Token(Token = "0x4000DB1")]
		[FieldOffset(Offset = "0x34")]
		public float Emptiness;

		[Token(Token = "0x4000DB2")]
		[FieldOffset(Offset = "0x38")]
		public float Score;

		[Token(Token = "0x4000DB3")]
		[FieldOffset(Offset = "0x3C")]
		public int ConveyorGrainCount;

		[Token(Token = "0x4000DB4")]
		[FieldOffset(Offset = "0x40")]
		public float CentroidDist;
	}
}
