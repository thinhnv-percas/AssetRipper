using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200001B")]
	public static class Constants
	{
		[Token(Token = "0x400004C")]
		public static readonly string Version = "1.6.4";

		[Token(Token = "0x400004D")]
		public static readonly string UpdateJsonURLFull = "https://raw.githubusercontent.com/SpaceMadness/lunar-unity-console/master/Builder/updater-full.json";

		[Token(Token = "0x400004E")]
		public static readonly string UpdateJsonURLFree = "https://raw.githubusercontent.com/SpaceMadness/lunar-unity-console/master/Builder/updater-free.json";

		[Token(Token = "0x400004F")]
		public static readonly string PluginName = "LunarConsole";

		[Token(Token = "0x4000050")]
		public static readonly string PluginDisplayName = "Lunar Mobile Console";

		[Token(Token = "0x4000051")]
		public static readonly string EditorPrefsKeyBase = "com.spacemadness.lunar.console";
	}
}
