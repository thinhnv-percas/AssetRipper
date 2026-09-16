using Cpp2ILInjected;
using LunarConsolePlugin;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000019")]
	public interface ICRegistryDelegate
	{
		[Token(Token = "0x6000099")]
		void OnActionRegistered(CRegistry registry, CAction action);

		[Token(Token = "0x600009A")]
		void OnActionUnregistered(CRegistry registry, CAction action);

		[Token(Token = "0x600009B")]
		void OnVariableRegistered(CRegistry registry, CVar cvar);

		[Token(Token = "0x600009C")]
		void OnVariableUpdated(CRegistry registry, CVar cvar);
	}
}
