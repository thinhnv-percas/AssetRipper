using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Serialization;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.IdentifierTags;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.LevelCreator
{
	[Token(Token = "0x20004BF")]
	public static class LoopLevelColorRemapper
	{
		[Token(Token = "0x4000FE8")]
		private static readonly GameColor[] CubePalette;

		[Token(Token = "0x4000FE9")]
		private static readonly GameColor[] KeyLockPalette;

		[Token(Token = "0x60013EE")]
		[Address(RVA = "0x3CF02E4", Offset = "0x3CF02E4", Length = "0xD8")]
		public static LevelCreatorData RemapColors(LevelCreatorData original, int seed)
		{
			LevelCreatorData levelCreatorData = DeepClone(original);
			Random rng = new Random(seed);
			Dictionary<GameColor, GameColor> cubeMap = BuildPermutation(rng, CubePalette);
			Dictionary<GameColor, GameColor> keyLockMap = BuildPermutation(rng, KeyLockPalette);
			ApplyMapping(levelCreatorData, cubeMap, keyLockMap);
			return levelCreatorData;
		}

		[Token(Token = "0x60013EF")]
		[Address(RVA = "0x3CF0820", Offset = "0x3CF0820", Length = "0x9C")]
		public static int StableHash(string s)
		{
			if (string.IsNullOrEmpty(s))
			{
				return 0;
			}
			bool flag = s.Length < 1;
			int num = -2128831035;
			if (!flag)
			{
				int num2 = 0;
				int num3 = -2128831035;
				bool flag2;
				do
				{
					char c = s[num2];
					int num4 = num3 ^ c;
					num = num4 * 16777619;
					num2++;
					flag2 = num2 < s.Length;
					num3 = num;
				}
				while (flag2);
			}
			return num;
		}

		[Token(Token = "0x60013F0")]
		[Address(RVA = "0x3CF03BC", Offset = "0x3CF03BC", Length = "0xC8")]
		private static LevelCreatorData DeepClone(LevelCreatorData original)
		{
			string value = JsonConvert.SerializeObject(original, LevelCreatorJsonSettings.Settings);
			return JsonConvert.DeserializeObject<LevelCreatorData>(value, LevelCreatorJsonSettings.Settings);
		}

		[Token(Token = "0x60013F1")]
		[Address(RVA = "0x3CF08BC", Offset = "0x3CF08BC", Length = "0x250")]
		private static GameColor[] BuildCubePalette()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::BuildCubePalette");
			return default;
		}

		[Token(Token = "0x60013F2")]
		[Address(RVA = "0x3CF0484", Offset = "0x3CF0484", Length = "0x234")]
		private static Dictionary<GameColor, GameColor> BuildPermutation(Random rng, GameColor[] palette)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::BuildPermutation");
			return default;
		}

		[Token(Token = "0x60013F3")]
		[Address(RVA = "0x3CF0B0C", Offset = "0x3CF0B0C", Length = "0x88")]
		private static GameColor Map(Dictionary<GameColor, GameColor> map, GameColor color)
		{
			Dictionary<GameColor, GameColor> dictionary = default(Dictionary<GameColor, GameColor>);
			if (dictionary.TryGetValue(color, out var value))
			{
				return value;
			}
			return color;
		}

		[Token(Token = "0x60013F4")]
		[Address(RVA = "0x3CF06B8", Offset = "0x3CF06B8", Length = "0x168")]
		private static void ApplyMapping(LevelCreatorData data, Dictionary<GameColor, GameColor> cubeMap, Dictionary<GameColor, GameColor> keyLockMap)
		{
			GridData<SandCubeCellData> sandCubeGrid = data.sandCubeGrid;
			if (data.sandCubeGrid != null)
			{
				SandCubeCellData[] cells = sandCubeGrid.cells;
				if (sandCubeGrid.cells != null && cells.Length >= 1)
				{
					int num = 0;
					Dictionary<GameColor, GameColor> keyLockMap2 = default(Dictionary<GameColor, GameColor>);
					do
					{
						SandCubeCellData sandCubeCellData = cells[num];
						List<ICellComponent> components = ((cells[num] == null) ? null : sandCubeCellData.components);
						RemapSandComponents(components, cubeMap, keyLockMap2);
						num++;
					}
					while (num < cells.Length);
				}
			}
			GridData<MoldCellData> moldGrid = data.moldGrid;
			if (data.moldGrid == null)
			{
				return;
			}
			MoldCellData[] cells2 = moldGrid.cells;
			if (moldGrid.cells != null && cells2.Length >= 1)
			{
				int num2 = 0;
				do
				{
					MoldCellData moldCellData = cells2[num2];
					List<ICellComponent> components2 = ((cells2[num2] == null) ? null : moldCellData.components);
					RemapMoldComponents(components2, cubeMap);
					num2++;
				}
				while (num2 < cells2.Length);
			}
		}

		[Token(Token = "0x60013F5")]
		[Address(RVA = "0x3CF10D4", Offset = "0x3CF10D4", Length = "0x2B4")]
		private unsafe static void RemapMoldComponents(List<ICellComponent> components, Dictionary<GameColor, GameColor> cubeMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::RemapMoldComponents");
		}

		[Token(Token = "0x60013F6")]
		[Address(RVA = "0x3CF0B94", Offset = "0x3CF0B94", Length = "0x540")]
		private unsafe static void RemapSandComponents(List<ICellComponent> components, Dictionary<GameColor, GameColor> cubeMap, Dictionary<GameColor, GameColor> keyLockMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::RemapSandComponents");
		}

		[Token(Token = "0x60013F7")]
		[Address(RVA = "0x3CF1388", Offset = "0x3CF1388", Length = "0x298")]
		private unsafe static void RemapTunnelEntry(TunnelEntryComponent te, Dictionary<GameColor, GameColor> cubeMap, Dictionary<GameColor, GameColor> keyLockMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::RemapTunnelEntry");
		}

		[Token(Token = "0x60013F8")]
		[Address(RVA = "0x3CF1620", Offset = "0x3CF1620", Length = "0x404")]
		private static void RemapDrawableEntity(DrawableEntity drawable, Dictionary<GameColor, GameColor> cubeMap, Dictionary<GameColor, GameColor> keyLockMap)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LoopLevelColorRemapper::RemapDrawableEntity");
		}

		[Token(Token = "0x60013F9")]
		[Address(RVA = "0x3CF1A24", Offset = "0x3CF1A24", Length = "0xB0")]
		static LoopLevelColorRemapper()
		{
			GameColor[] cubePalette = BuildCubePalette();
			CubePalette = cubePalette;
			GameColor[] keyLockPalette = new GameColor[2];
			_ = 1;
			KeyLockPalette = keyLockPalette;
		}
	}
}
