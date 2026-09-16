using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200009E")]
	public class TMP_TextParsingUtilities
	{
		[Token(Token = "0x40005DB")]
		private static readonly TMP_TextParsingUtilities s_Instance;

		[Token(Token = "0x40005DC")]
		private const string k_LookupStringL = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@abcdefghijklmnopqrstuvwxyz[-]^_`abcdefghijklmnopqrstuvwxyz{|}~-";

		[Token(Token = "0x40005DD")]
		private const string k_LookupStringU = "-------------------------------- !-#$%&-()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[-]^_`ABCDEFGHIJKLMNOPQRSTUVWXYZ{|}~-";

		[Token(Token = "0x1700016D")]
		public static TMP_TextParsingUtilities instance
		{
			[Token(Token = "0x60005FA")]
			[Address(RVA = "0x161132C", Offset = "0x161132C", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60005F9")]
		[Address(RVA = "0x16112C8", Offset = "0x16112C8", Length = "0x5C")]
		static TMP_TextParsingUtilities()
		{
		}

		[Token(Token = "0x60005FB")]
		[Address(RVA = "0x160D33C", Offset = "0x160D33C", Length = "0xBC")]
		public static int GetHashCode(string s)
		{
			return 0;
		}

		[Token(Token = "0x60005FC")]
		[Address(RVA = "0x160CE8C", Offset = "0x160CE8C", Length = "0x6C")]
		public static int GetHashCodeCaseSensitive(string s)
		{
			return 0;
		}

		[Token(Token = "0x60005FD")]
		[Address(RVA = "0x16113F8", Offset = "0x16113F8", Length = "0x74")]
		public static char ToLowerASCIIFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60005FE")]
		[Address(RVA = "0x1611384", Offset = "0x1611384", Length = "0x74")]
		public static char ToUpperASCIIFast(char c)
		{
			return '\0';
		}

		[Token(Token = "0x60005FF")]
		[Address(RVA = "0x161146C", Offset = "0x161146C", Length = "0x74")]
		public static uint ToUpperASCIIFast(uint c)
		{
			return 0u;
		}

		[Token(Token = "0x6000600")]
		[Address(RVA = "0x16114E0", Offset = "0x16114E0", Length = "0x74")]
		public static uint ToLowerASCIIFast(uint c)
		{
			return 0u;
		}

		[Token(Token = "0x6000601")]
		[Address(RVA = "0x1611554", Offset = "0x1611554", Length = "0x14")]
		public static bool IsHighSurrogate(uint c)
		{
			return false;
		}

		[Token(Token = "0x6000602")]
		[Address(RVA = "0x1611568", Offset = "0x1611568", Length = "0x14")]
		public static bool IsLowSurrogate(uint c)
		{
			return false;
		}

		[Token(Token = "0x6000603")]
		[Address(RVA = "0x161157C", Offset = "0x161157C", Length = "0x14")]
		internal static uint ConvertToUTF32(uint highSurrogate, uint lowSurrogate)
		{
			return 0u;
		}

		[Token(Token = "0x6000604")]
		[Address(RVA = "0x1611324", Offset = "0x1611324", Length = "0x8")]
		public TMP_TextParsingUtilities()
		{
		}
	}
}
