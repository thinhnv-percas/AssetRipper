using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000034")]
	internal static class SetPropertyUtility
	{
		[Token(Token = "0x60003CA")]
		[Address(RVA = "0xED78C4", Offset = "0xED78C4", Length = "0x48")]
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			return false;
		}

		[Token(Token = "0x60003CB")]
		[Address(RVA = "0xD6D300", Offset = "0xD6D300", Length = "0x68")]
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			return false;
		}

		[Token(Token = "0x60003CC")]
		[Address(RVA = "0xD6D2AC", Offset = "0xD6D2AC", Length = "0x54")]
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			return false;
		}
	}
}
