using System;
using System.Collections.Generic;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x200038D")]
	public static class UserPromptBuilder
	{
		[Token(Token = "0x6000EED")]
		[Address(RVA = "0x3C8FF30", Offset = "0x3C8FF30", Length = "0xDD0")]
		public static string BuildWallPhase(Vector2Int gridSize, int maxIterations, Vector2Int sandCubeCountRange, string designerIntent, IReadOnlyList<(string name, string definition)> backgroundConcepts, AnimationCurve conveyorFillCurve = null, Vector2Int? entryPointCountRange = null, Vector2Int? colorCountRange = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UserPromptBuilder::BuildWallPhase");
			return default;
		}

		[Token(Token = "0x6000EEE")]
		[Address(RVA = "0x3C90D00", Offset = "0x3C90D00", Length = "0x364")]
		public static string BuildRestPhase()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("UserPromptBuilder::BuildRestPhase");
			return default;
		}

		[Token(Token = "0x6000EEF")]
		[Address(RVA = "0x3C91064", Offset = "0x3C91064", Length = "0x178")]
		public static string BuildIterationPrompt(int attempt, string feedbackFileName)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string value = $"# Iteration {arg}";
			StringBuilder stringBuilder2 = stringBuilder.AppendLine(value);
			StringBuilder stringBuilder3 = stringBuilder.AppendLine();
			string value2 = "Validation flagged issues with your previous attempt. Read `$LG_WORKSPACE/" + feedbackFileName + "`,";
			StringBuilder stringBuilder4 = stringBuilder.AppendLine(value2);
			StringBuilder stringBuilder5 = stringBuilder.AppendLine("fix every error (bypass warnings only where you genuinely cannot fix them, as the file explains),");
			StringBuilder stringBuilder6 = stringBuilder.AppendLine("then write `done.json` when finished.");
			return stringBuilder.ToString();
		}
	}
}
