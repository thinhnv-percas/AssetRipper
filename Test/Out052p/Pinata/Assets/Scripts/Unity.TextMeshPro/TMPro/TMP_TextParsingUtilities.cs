using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000057")]
	public class TMP_TextParsingUtilities
	{
		[Token(Token = "0x40003EA")]
		private static readonly TMP_TextParsingUtilities s_Instance;

		[Token(Token = "0x40003EB")]
		private const string k_LookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		[Token(Token = "0x40003EC")]
		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		[Token(Token = "0x1700013A")]
		public static TMP_TextParsingUtilities instance
		{
			[Token(Token = "0x60004DC")]
			[Address(RVA = "0xC8AA64", Offset = "0xC8AA64", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0xC8A9F8", Offset = "0xC8A9F8", Length = "0x64")]
		static TMP_TextParsingUtilities()
		{
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0xC8AACC", Offset = "0xC8AACC", Length = "0xD8")]
		public static uint GetHashCode(string s)
		{
			return 0u;
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0xC8AC20", Offset = "0xC8AC20", Length = "0x78")]
		public static int GetHashCodeCaseSensitive(string s)
		{
			return 0;
		}

		[Token(Token = "0x60004DF")]
		[Address(RVA = "0xC8AC98", Offset = "0xC8AC98", Length = "0x7C")]
		public static char ToLowerASCIIFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0xC8ABA4", Offset = "0xC8ABA4", Length = "0x7C")]
		public static char ToUpperASCIIFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0xC8AD14", Offset = "0xC8AD14", Length = "0x7C")]
		public static uint ToUpperASCIIFast(uint c)
		{
			return 0u;
		}

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0xC8AD90", Offset = "0xC8AD90", Length = "0x7C")]
		public static uint ToLowerASCIIFast(uint c)
		{
			return 0u;
		}

		[Token(Token = "0x60004E3")]
		[Address(RVA = "0xC8AE0C", Offset = "0xC8AE0C", Length = "0x14")]
		public static bool IsHighSurrogate(uint c)
		{
			return false;
		}

		[Token(Token = "0x60004E4")]
		[Address(RVA = "0xC8AE20", Offset = "0xC8AE20", Length = "0x14")]
		public static bool IsLowSurrogate(uint c)
		{
			return false;
		}

		[Token(Token = "0x60004E5")]
		[Address(RVA = "0xC8AA5C", Offset = "0xC8AA5C", Length = "0x8")]
		public TMP_TextParsingUtilities()
		{
		}
	}
}
