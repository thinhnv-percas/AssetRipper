using System;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000669")]
	public abstract class LevelFactory<TCreationData> : ILevelFactory where TCreationData : class, ILevelCreationData
	{
		[Token(Token = "0x6001B02")]
		[Address(RVA = "0x565DD14", Offset = "0x565DD14", Length = "0x420")]
		public bool CreateLevel(ILevel levelData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelFactory::CreateLevel");
			return default;
		}

		[Token(Token = "0x6001B03")]
		protected abstract bool CreateLevel(ILevel levelData, TCreationData creationData);

		[Token(Token = "0x6001B04")]
		[Address(RVA = "0x565E134", Offset = "0x565E134", Length = "0x8")]
		protected internal LevelFactory()
		{
		}
	}
}
