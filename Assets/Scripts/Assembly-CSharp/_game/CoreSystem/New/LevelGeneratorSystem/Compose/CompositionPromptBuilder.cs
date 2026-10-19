using System;
using System.Text;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Compose
{
	[Token(Token = "0x20003A1")]
	public static class CompositionPromptBuilder
	{
		[Token(Token = "0x4000B18")]
		public const string GameScreenshotPath = "Assets/_game/CoreSystem/New/LevelGeneratorSystem/Runtime/Images/game-screenshot.png";

		[Token(Token = "0x6000F3F")]
		[Address(RVA = "0x3C992C4", Offset = "0x3C992C4", Length = "0x438")]
		public static string BuildSystemPrompt()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompositionPromptBuilder::BuildSystemPrompt");
			return default;
		}

		[Token(Token = "0x6000F40")]
		[Address(RVA = "0x3C998F4", Offset = "0x3C998F4", Length = "0x4F8")]
		public static string BuildEditSystemPrompt()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompositionPromptBuilder::BuildEditSystemPrompt");
			return default;
		}

		[Token(Token = "0x6000F41")]
		[Address(RVA = "0x3C99DEC", Offset = "0x3C99DEC", Length = "0xC0")]
		public static string BuildUserPrompt(string rawText)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompositionPromptBuilder::BuildUserPrompt");
			return default;
		}

		[Token(Token = "0x6000F42")]
		[Address(RVA = "0x3C99EAC", Offset = "0x3C99EAC", Length = "0x22C")]
		public static string BuildEditUserPrompt(string currentId, string currentDisplayName, string currentDefinition, string currentDesignerNotes, string editRequest)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CompositionPromptBuilder::BuildEditUserPrompt");
			return default;
		}

		[Token(Token = "0x6000F43")]
		[Address(RVA = "0x3C996FC", Offset = "0x3C996FC", Length = "0x1F8")]
		private static void AppendVisualReference(StringBuilder sb)
		{
			StringBuilder stringBuilder = sb.AppendLine("# Visual reference (read before answering)");
			StringBuilder stringBuilder2 = sb.AppendLine("Open the annotated gameplay screenshot once to understand the game's vocabulary:");
			StringBuilder stringBuilder3 = sb.AppendLine("`Read('Assets/_game/CoreSystem/New/LevelGeneratorSystem/Runtime/Images/game-screenshot.png')`");
			StringBuilder stringBuilder4 = sb.AppendLine();
			StringBuilder stringBuilder5 = sb.AppendLine("The image shows a live Sand Out level with numbered labels. Use this legend to interpret them:");
			StringBuilder stringBuilder6 = sb.AppendLine("- **1 — Wall**: a non-playable cell generated from a `wall` component on the top-grid. Walls act as physics obstacles for falling sand particles AND count as occupied neighbors for the pourability rule. Surrounding a cube with walls makes it closed.");
			StringBuilder stringBuilder7 = sb.AppendLine("- **2 — Sand cube**: a player-breakable cube. Tapping a pourable cube dissolves it into sand particles. The red cube highlighted in the image is **not pourable** because its 4 orthogonal neighbors are 3 walls + 1 other cube — fully closed.");
			StringBuilder stringBuilder8 = sb.AppendLine("- **3 — Playable area**: the region where top-grid elements live and where sand particles flow under gravity after a cube is broken.");
			StringBuilder stringBuilder9 = sb.AppendLine("- **4 — Sand particle**: the per-grain output of a broken cube. Particles fall, collide with walls and other cubes, and eventually enter the conveyor through the gate.");
			StringBuilder stringBuilder10 = sb.AppendLine("- **5 — Conveyor area**: a playable region that continuously rotates. Particles inside are carried by the rotation; a particle whose color matches a front-row mold and which passes close enough to that mold gets absorbed into it. The conveyor connects to the playable area via a **gate** that closes once the conveyor is 100% full.");
			StringBuilder stringBuilder11 = sb.AppendLine("- **6 — Conveyor fill-rate indicator**: shows current conveyor occupancy (0–100%). At 100% the gate closes. **Fail condition (the ONLY fail condition):** conveyor at 100% AND none of the particles inside it can be absorbed by any front-row mold.");
			StringBuilder stringBuilder12 = sb.AppendLine("- **7 — Mold**: a target shape sitting in a column of the mold area. A mold absorbs same-color particles only when it is in the **front row** of its column. When fully filled, the mold disappears and the next mold in that column advances forward. **The goal of every level is to fill every mold.**");
			StringBuilder stringBuilder13 = sb.AppendLine();
		}

		[Token(Token = "0x6000F44")]
		[Address(RVA = "0x3C9A0D8", Offset = "0x3C9A0D8", Length = "0x134")]
		private static void AppendIndented(StringBuilder sb, string body, string indent)
		{
			if (string.IsNullOrEmpty(body))
			{
				StringBuilder stringBuilder = sb.AppendLine(indent);
				return;
			}
			string text = body.Replace("\r\n", "\n");
			string[] array = text.Split('\n');
			if (sb != null)
			{
				if (array.Length >= 1)
				{
					int num = 0;
					do
					{
						StringBuilder stringBuilder2 = sb.Append(indent);
						StringBuilder stringBuilder3 = sb.AppendLine(array[num]);
						num++;
					}
					while (num < array.Length);
				}
			}
			else if (array.Length > 0)
			{
				throw new NullReferenceException();
			}
		}
	}
}
