using Cpp2ILInjected;

namespace Systems.UINavigatonSystem.Interface
{
	[Token(Token = "0x200002E")]
	public interface ISubNavigable
	{
		[Token(Token = "0x60000A7")]
		void NavigateTo(string subSectionName);
	}
}
