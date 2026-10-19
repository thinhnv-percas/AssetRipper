using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Analysis
{
	[Token(Token = "0x20003C6")]
	public static class AlternativePathExplorer
	{
		[Token(Token = "0x6000F9C")]
		[Address(RVA = "0x3CA21C4", Offset = "0x3CA21C4", Length = "0x1A4")]
		public static AlternativePathsResult Parse(string stdoutText)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AlternativePathExplorer::Parse");
			return default;
		}

		[Token(Token = "0x6000F9D")]
		[Address(RVA = "0x3CA2368", Offset = "0x3CA2368", Length = "0xA14")]
		public static AlternativePathsResult Run(string levelCreationJson, IReadOnlyList<GridCoord> taps, string scriptPath, Action<string> log, int rollouts = 300, int budgetMs = 12000, int timeoutMs = 60000)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AlternativePathExplorer::Run");
			return default;
		}

		[Token(Token = "0x6000F9E")]
		[Address(RVA = "0x3CA2D7C", Offset = "0x3CA2D7C", Length = "0x2C0")]
		private static string TapsToJson(IReadOnlyList<GridCoord> taps)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("AlternativePathExplorer::TapsToJson");
			return default;
		}

		[Token(Token = "0x6000F9F")]
		[Address(RVA = "0x3CA303C", Offset = "0x3CA303C", Length = "0x94")]
		private static string Truncate(string s, int max)
		{
			string text = default(string);
			if (text.Length > max)
			{
				string text2 = text.Substring(0, max);
				return text2 + "…";
			}
			return text;
		}

		[Token(Token = "0x6000FA0")]
		[Address(RVA = "0x3CA30D0", Offset = "0x3CA30D0", Length = "0xAC")]
		private static void TryDelete(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				File.Delete(path);
			}
		}
	}
}
