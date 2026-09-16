using System.Reflection;
using Cpp2ILInjected;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000026")]
	public delegate bool ListMethodsFilter(MethodInfo method);
}
