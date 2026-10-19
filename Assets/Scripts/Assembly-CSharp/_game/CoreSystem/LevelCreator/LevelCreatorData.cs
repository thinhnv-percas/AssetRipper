using System;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.FrameSystem;

namespace _game.CoreSystem.LevelCreator
{
	[Serializable]
	[Token(Token = "0x20004B9")]
	public class LevelCreatorData : ILevelCreationData
	{
		[Token(Token = "0x4000FDB")]
		[FieldOffset(Offset = "0x10")]
		public string levelId;

		[Token(Token = "0x4000FDC")]
		[FieldOffset(Offset = "0x18")]
		public GridData<MoldCellData> moldGrid;

		[Token(Token = "0x4000FDD")]
		[FieldOffset(Offset = "0x20")]
		public GridData<SandCubeCellData> sandCubeGrid;

		[Token(Token = "0x4000FDE")]
		[FieldOffset(Offset = "0x28")]
		public FramePresetType framePresetType;

		[Token(Token = "0x4000FDF")]
		[FieldOffset(Offset = "0x30")]
		public FrameData frameData;

		[Token(Token = "0x4000FE0")]
		[FieldOffset(Offset = "0x50")]
		public float sandCubeGridYPosition;

		[Token(Token = "0x4000FE1")]
		[FieldOffset(Offset = "0x58")]
		public string moldConceptId;

		[Token(Token = "0x4000FE2")]
		[FieldOffset(Offset = "0x60")]
		public LevelDifficulty difficulty;

		[Token(Token = "0x60013E6")]
		[Address(RVA = "0x3CEFED4", Offset = "0x3CEFED4", Length = "0x18")]
		public LevelCreatorData()
		{
			framePresetType = FramePresetType.Standard;
			sandCubeGridYPosition = 3f;
		}
	}
}
