using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x200035F")]
	public class OrchestratorConfig
	{
		[Token(Token = "0x40009E8")]
		[FieldOffset(Offset = "0x10")]
		public int maxConcurrentLevels;

		[Token(Token = "0x40009E9")]
		[FieldOffset(Offset = "0x18")]
		public PromptGenConfig promptDefaults;

		[Token(Token = "0x40009EA")]
		[FieldOffset(Offset = "0x20")]
		public float usagePollMinutes;

		[Token(Token = "0x40009EB")]
		[FieldOffset(Offset = "0x24")]
		public float monitorMinutes;

		[Token(Token = "0x40009EC")]
		[FieldOffset(Offset = "0x28")]
		public int triageLogTailLines;

		[Token(Token = "0x40009ED")]
		[FieldOffset(Offset = "0x2C")]
		public float briefTimeoutMinutes;

		[Token(Token = "0x40009EE")]
		[FieldOffset(Offset = "0x30")]
		public string briefAuthorEffort;

		[Token(Token = "0x40009EF")]
		[FieldOffset(Offset = "0x38")]
		public int briefMaxRetries;

		[Token(Token = "0x40009F0")]
		[FieldOffset(Offset = "0x3C")]
		public int generationRetries;

		[Token(Token = "0x40009F1")]
		[FieldOffset(Offset = "0x40")]
		public int fixBriefMaxAttempts;

		[Token(Token = "0x40009F2")]
		[FieldOffset(Offset = "0x44")]
		public int freshPromptCycles;

		[Token(Token = "0x40009F3")]
		[FieldOffset(Offset = "0x48")]
		public int circuitBreakerConsecutiveFails;

		[Token(Token = "0x40009F4")]
		[FieldOffset(Offset = "0x50")]
		public string managerModel;

		[Token(Token = "0x40009F5")]
		[FieldOffset(Offset = "0x58")]
		public long tokenBudgetOverride;

		[Token(Token = "0x40009F6")]
		[FieldOffset(Offset = "0x60")]
		public string extractorModel;

		[Token(Token = "0x40009F7")]
		[FieldOffset(Offset = "0x68")]
		public string generatorModel;

		[Token(Token = "0x40009F8")]
		[FieldOffset(Offset = "0x70")]
		public string generatorEffort;

		[Token(Token = "0x40009F9")]
		[FieldOffset(Offset = "0x78")]
		public string claudeBinary;

		[Token(Token = "0x40009FA")]
		[FieldOffset(Offset = "0x80")]
		public string conceptsFolder;

		[Token(Token = "0x40009FB")]
		[FieldOffset(Offset = "0x88")]
		public string templateLevelPath;

		[Token(Token = "0x6000E0B")]
		[Address(RVA = "0x3F02ED8", Offset = "0x3F02ED8", Length = "0x1BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tthis.usagePollMinutes = 8192.001937866211d;\n\tthis.triageLogTailLines = 0x40A00000000000C8;\n\tthis.briefAuthorEffort = \"medium\";\n\tthis.briefMaxRetries = *([9309580]);\n\tthis.circuitBreakerConsecutiveFails = 5;\n\tthis.managerModel = \"haiku\";\n\tthis.extractorModel = \"haiku\";\n\tthis.generatorModel = \"opus\";\n\tthis.generatorEffort = \"medium\";\n\tthis.claudeBinary = \"claude\";\n\tthis.conceptsFolder = \"Assets/_game/CoreSystem/New/LevelGeneratorSystem/Concepts\";\n\tthis.templateLevelPath = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\nL_003B:\n\tthis.maxConcurrentLevels = 4;\n\tv71 = new _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory.PromptGenConfig();\n\t_game.CoreSystem.New.LevelGeneratorSystem.BriefFactory.PromptGenConfig::.ctor(v71);\n\tthis.promptDefaults = v71;\n")]
		public OrchestratorConfig()
		{
			//IL_002a: Expected I4, but got I8
			maxConcurrentLevels = 4;
			PromptGenConfig promptGenConfig = new PromptGenConfig();
			promptDefaults = promptGenConfig;
			usagePollMinutes = 1f;
			monitorMinutes = 6f;
			triageLogTailLines = 200;
			briefAuthorEffort = "medium";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9309580]");
			briefMaxRetries = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9309580]");
			generationRetries = (int)((nuint)0u >> 32);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9309580]");
			fixBriefMaxAttempts = (int)((nuint)0u >> 64);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [9309580]");
			freshPromptCycles = (int)((nuint)0u >> 96);
			circuitBreakerConsecutiveFails = 5;
			managerModel = "haiku";
			extractorModel = "haiku";
			generatorModel = "opus";
			generatorEffort = "medium";
			claudeBinary = "claude";
			conceptsFolder = "Assets/_game/CoreSystem/New/LevelGeneratorSystem/Concepts";
			templateLevelPath = "";
		}
	}
}
