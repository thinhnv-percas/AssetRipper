using Cpp2ILInjected;
using HutongGames.PlayMaker;

namespace PlayMaker.ConditionalExpression
{
	[Token(Token = "0x2000003")]
	public interface IEvaluatorContext
	{
		[Token(Token = "0x6000001")]
		FsmVar GetVariable(string name);
	}
}
