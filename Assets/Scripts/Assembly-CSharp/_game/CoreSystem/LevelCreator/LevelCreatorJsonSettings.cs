using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json;
using Unity.Mathematics;

namespace _game.CoreSystem.LevelCreator
{
	[Token(Token = "0x20004BE")]
	public static class LevelCreatorJsonSettings
	{
		[Token(Token = "0x4000FE7")]
		public static readonly JsonSerializerSettings Settings;

		[Token(Token = "0x60013ED")]
		[Address(RVA = "0x3CF0110", Offset = "0x3CF0110", Length = "0x1D4")]
		static LevelCreatorJsonSettings()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelCreatorJsonSettings::.cctor");
		}
	}
}
