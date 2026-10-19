using System;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003B3")]
	public class PromptGenConfig
	{
		[Token(Token = "0x4000B8B")]
		[FieldOffset(Offset = "0x10")]
		public int count;

		[Token(Token = "0x4000B8C")]
		[FieldOffset(Offset = "0x14")]
		public LevelDifficulty difficulty;

		[Token(Token = "0x4000B8D")]
		[FieldOffset(Offset = "0x18")]
		public string customData;

		[Token(Token = "0x4000B8E")]
		[FieldOffset(Offset = "0x20")]
		public float sampleRatio;

		[Token(Token = "0x4000B8F")]
		[FieldOffset(Offset = "0x24")]
		public int curvePoints;

		[Token(Token = "0x4000B90")]
		[FieldOffset(Offset = "0x28")]
		public float curveJitter;

		[Token(Token = "0x4000B91")]
		[FieldOffset(Offset = "0x2C")]
		public bool withCurve;

		[Token(Token = "0x4000B92")]
		[FieldOffset(Offset = "0x2D")]
		public bool withLlm;

		[Token(Token = "0x4000B93")]
		[FieldOffset(Offset = "0x30")]
		public double briefTimeoutSeconds;

		[Token(Token = "0x4000B94")]
		[FieldOffset(Offset = "0x38")]
		public string briefAuthorEffort;

		[Token(Token = "0x6000F73")]
		[Address(RVA = "0x3C9D9FC", Offset = "0x3C9D9FC", Length = "0xB8")]
		public PromptGenConfig()
		{
			count = 0;
			customData = "";
			sampleRatio = 0.4f;
			curveJitter = 0.03f;
			withCurve = true;
			withLlm = true;
			briefAuthorEffort = "medium";
		}
	}
}
