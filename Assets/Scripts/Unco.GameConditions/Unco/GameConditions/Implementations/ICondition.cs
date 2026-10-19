using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Token(Token = "0x200000F")]
	public interface ICondition
	{
		[Token(Token = "0x6000029")]
		bool IsConditionMet();
	}
}
