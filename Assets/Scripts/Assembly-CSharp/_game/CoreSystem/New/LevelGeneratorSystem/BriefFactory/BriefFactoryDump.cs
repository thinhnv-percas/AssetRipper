using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003AA")]
	public class BriefFactoryDump
	{
		[Token(Token = "0x4000B45")]
		[FieldOffset(Offset = "0x10")]
		public string band;

		[Token(Token = "0x4000B46")]
		[FieldOffset(Offset = "0x18")]
		public string timestampUtc;

		[Token(Token = "0x4000B47")]
		[FieldOffset(Offset = "0x20")]
		public List<int> pulledLevelIndices;

		[Token(Token = "0x4000B48")]
		[FieldOffset(Offset = "0x28")]
		public List<LevelFeatures> levelFeatures;

		[Token(Token = "0x4000B49")]
		[FieldOffset(Offset = "0x30")]
		public List<float[]> levelCurves;

		[Token(Token = "0x4000B4A")]
		[FieldOffset(Offset = "0x38")]
		public FeatureEnvelope envelope;

		[Token(Token = "0x4000B4B")]
		[FieldOffset(Offset = "0x40")]
		public List<ConceptDumpEntry> concepts;

		[Token(Token = "0x4000B4C")]
		[FieldOffset(Offset = "0x48")]
		public string llmSystemPrompt;

		[Token(Token = "0x4000B4D")]
		[FieldOffset(Offset = "0x50")]
		public string llmUserPrompt;

		[Token(Token = "0x4000B4E")]
		[FieldOffset(Offset = "0x58")]
		public string brief;

		[Token(Token = "0x4000B4F")]
		[FieldOffset(Offset = "0x60")]
		public string error;

		[Token(Token = "0x6000F50")]
		[Address(RVA = "0x3C9B3DC", Offset = "0x3C9B3DC", Length = "0x188")]
		public BriefFactoryDump()
		{
			List<int> list = new List<int>();
			pulledLevelIndices = list;
			List<LevelFeatures> list2 = new List<LevelFeatures>();
			levelFeatures = list2;
			List<float[]> list3 = new List<float[]>();
			levelCurves = list3;
			List<ConceptDumpEntry> list4 = new List<ConceptDumpEntry>();
			concepts = list4;
		}
	}
}
