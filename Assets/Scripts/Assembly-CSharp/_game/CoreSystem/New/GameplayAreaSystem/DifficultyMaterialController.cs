using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreSystem.New.GameplayAreaSystem
{
	[Token(Token = "0x2000430")]
	public class DifficultyMaterialController
	{
		[Inject(false)]
		[Token(Token = "0x600117D")]
		[Address(RVA = "0x3CC1514", Offset = "0x3CC1514", Length = "0x3E8")]
		private void Construct(IEnumerable<IDifficultyMaterialController> controllers, ILevel level)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DifficultyMaterialController::Construct");
		}

		[Token(Token = "0x600117E")]
		[Address(RVA = "0x3CC18FC", Offset = "0x3CC18FC", Length = "0x18")]
		private static int GetBackgroundPresetIndex(LevelDifficulty difficulty)
		{
			int num = (int)(difficulty - 4);
			bool flag = num == 0;
			int result = (int)((flag ? 1u : 0u) << 1);
			if (difficulty - 3 != LevelDifficulty.Null)
			{
				return result;
			}
			return 1;
		}

		[Token(Token = "0x600117F")]
		[Address(RVA = "0x3CC1914", Offset = "0x3CC1914", Length = "0x8")]
		public DifficultyMaterialController()
		{
		}
	}
}
