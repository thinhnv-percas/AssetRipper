using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x200038B")]
	public static class ToolSchemaJson
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200038C")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000AE1")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000AE2")]
			public static Func<GameColor, string> _003C_003E9__0_0;

			[Token(Token = "0x6000EEA")]
			[Address(RVA = "0x3C8FE3C", Offset = "0x3C8FE3C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000EEB")]
			[Address(RVA = "0x3C8FEA0", Offset = "0x3C8FEA0", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal string _003CBuildMarkdown_003Eb__0_0(GameColor c)
			{
				object arg = c;
				return $"`{arg}`";
			}
		}

		[Token(Token = "0x6000EE9")]
		[Address(RVA = "0x3F1BFC8", Offset = "0x3F1BFC8", Length = "0xCF4")]
		public static string BuildMarkdown()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ToolSchemaJson::BuildMarkdown");
			return default;
		}
	}
}
