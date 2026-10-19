using Cpp2ILInjected;

namespace Unco.OverridableSystem.Runtime.OverridableSystem
{
	[Token(Token = "0x200079B")]
	public interface IOverride<T> where T : struct
	{
		[Token(Token = "0x6002014")]
		T Override(T getValue);
	}
}
