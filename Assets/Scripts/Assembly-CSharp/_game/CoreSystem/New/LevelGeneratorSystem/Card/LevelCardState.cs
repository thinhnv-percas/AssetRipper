using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.New.LevelGeneratorSystem.Driver;
using _game.CoreSystem.New.LevelGeneratorSystem.Extractor;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Card
{
	[Token(Token = "0x20003A7")]
	public sealed class LevelCardState
	{
		[Token(Token = "0x4000B27")]
		[FieldOffset(Offset = "0x10")]
		public readonly string Id;

		[Token(Token = "0x4000B28")]
		[FieldOffset(Offset = "0x18")]
		public string DisplayName;

		[Token(Token = "0x4000B29")]
		[FieldOffset(Offset = "0x20")]
		public string DesignerPrompt;

		[Token(Token = "0x4000B2A")]
		[FieldOffset(Offset = "0x28")]
		public LevelDifficulty Difficulty;

		[Token(Token = "0x4000B2B")]
		[FieldOffset(Offset = "0x30")]
		public AnimationCurve ConveyorFillCurve;

		[Token(Token = "0x4000B2C")]
		[FieldOffset(Offset = "0x38")]
		public Vector2Int SandCubeCountRange;

		[Token(Token = "0x4000B2D")]
		[FieldOffset(Offset = "0x40")]
		public bool EntryPointCountAuto;

		[Token(Token = "0x4000B2E")]
		[FieldOffset(Offset = "0x44")]
		public Vector2Int EntryPointCountRange;

		[Token(Token = "0x4000B2F")]
		[FieldOffset(Offset = "0x4C")]
		public bool ColorCountAuto;

		[Token(Token = "0x4000B30")]
		[FieldOffset(Offset = "0x50")]
		public Vector2Int ColorCountRange;

		[Token(Token = "0x4000B31")]
		[FieldOffset(Offset = "0x58")]
		public int MaxIterations;

		[Token(Token = "0x4000B32")]
		[FieldOffset(Offset = "0x5C")]
		public bool IntendedPathGenerationEnabled;

		[Token(Token = "0x4000B33")]
		[FieldOffset(Offset = "0x60")]
		public int VariantCount;

		[Token(Token = "0x4000B34")]
		[FieldOffset(Offset = "0x68")]
		public string ParentId;

		[Token(Token = "0x4000B35")]
		[FieldOffset(Offset = "0x70")]
		public LevelCardPhase Phase;

		[Token(Token = "0x4000B36")]
		[FieldOffset(Offset = "0x78")]
		public string StatusMessage;

		[Token(Token = "0x4000B37")]
		[FieldOffset(Offset = "0x80")]
		public readonly List<string> Log;

		[Token(Token = "0x4000B38")]
		[FieldOffset(Offset = "0x88")]
		public string ReportPath;

		[Token(Token = "0x4000B39")]
		[FieldOffset(Offset = "0x90")]
		public string SavedAssetPath;

		[Token(Token = "0x4000B3A")]
		[FieldOffset(Offset = "0x98")]
		public ExtractionResult LastExtraction;

		[Token(Token = "0x4000B3B")]
		[FieldOffset(Offset = "0xA0")]
		public object LastOutcome;

		[Token(Token = "0x4000B3C")]
		[FieldOffset(Offset = "0xA8")]
		public DateTime? StartedUtc;

		[Token(Token = "0x4000B3D")]
		[FieldOffset(Offset = "0xB8")]
		public DateTime? FinishedUtc;

		[Token(Token = "0x4000B3E")]
		[FieldOffset(Offset = "0xC8")]
		public readonly LlmUsageLedger LlmUsage;

		[Token(Token = "0x4000B3F")]
		[FieldOffset(Offset = "0xD0")]
		public readonly LlmPromptLedger LlmPrompts;

		[Token(Token = "0x6000F4B")]
		[Address(RVA = "0x3C9A758", Offset = "0x3C9A758", Length = "0x22C")]
		public LevelCardState(string idOverride = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelCardState::.ctor");
		}
	}
}
