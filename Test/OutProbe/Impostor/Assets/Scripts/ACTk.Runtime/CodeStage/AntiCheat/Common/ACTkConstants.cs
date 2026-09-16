using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Common
{
	[Token(Token = "0x2000050")]
	public static class ACTkConstants
	{
		[Token(Token = "0x40001A4")]
		public const string Version = "2.2.1";

		[Token(Token = "0x40001A5")]
		internal const string LogPrefix = "[ACTk] ";

		[Token(Token = "0x40001A6")]
		internal const string DocsRootUrl = "http://codestage.net/uas_files/actk/api/";

		[Token(Token = "0x40001A7")]
		internal static readonly char[] StringKey = new char[5] { 'i', 'Ĉ', 'ą', 'Đ', '\u0097' };
	}
}
