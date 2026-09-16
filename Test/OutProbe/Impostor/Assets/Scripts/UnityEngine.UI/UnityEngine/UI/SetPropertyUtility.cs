using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200006C")]
	internal static class SetPropertyUtility
	{
		[Token(Token = "0x600045F")]
		[Address(RVA = "0x1835E68", Offset = "0x1835E68", Length = "0x48")]
		public static bool SetColor(ref Color currentValue, Color newValue)
		{
			return false;
		}

		[Token(Token = "0x6000460")]
		[Address(RVA = "0xCA2A9C", Offset = "0xCA2A9C", Length = "0x6C")]
		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			return false;
		}

		[Token(Token = "0x6000461")]
		[Address(RVA = "0xCA2A4C", Offset = "0xCA2A4C", Length = "0x50")]
		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			return false;
		}
	}
}
