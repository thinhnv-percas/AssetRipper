using System;
using Cpp2ILInjected;

namespace Unco.GameConditions.Implementations
{
	[Token(Token = "0x2000012")]
	public interface IReactiveCondition : ICondition
	{
		[Token(Token = "0x14000001")]
		event Action OnConditionChanged;
	}
}
