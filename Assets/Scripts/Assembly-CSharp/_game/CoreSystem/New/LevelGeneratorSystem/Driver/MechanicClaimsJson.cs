using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Newtonsoft.Json.Linq;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Driver
{
	[Token(Token = "0x2000382")]
	public static class MechanicClaimsJson
	{
		[Token(Token = "0x6000EAF")]
		[Address(RVA = "0x3F16998", Offset = "0x3F16998", Length = "0x7CC")]
		public static MechanicClaim[] Parse(string rawDoneJson)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MechanicClaimsJson::Parse");
			return default;
		}

		[Token(Token = "0x6000EB0")]
		[Address(RVA = "0x3F17164", Offset = "0x3F17164", Length = "0xD0")]
		private static int ReadInt(JToken t)
		{
			if (t != null)
			{
				JTokenType type = t.Type;
				if (type == JTokenType.Integer)
				{
					return t.Value<int>();
				}
				object s = t.Value<object>();
				if (int.TryParse((string)s, out var result))
				{
					return result;
				}
				return -1;
			}
			return -1;
		}
	}
}
