using System.Collections.Generic;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[Token(Token = "0x200000E")]
	internal delegate void LunarConsoleNativeMessageHandler(IDictionary<string, string> data);
}
