using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000076")]
	public interface ObiInterpolator<T>
	{
		[Token(Token = "0x6000493")]
		T Evaluate(T v0, T v1, T v2, T v3, float mu);

		[Token(Token = "0x6000494")]
		T EvaluateFirstDerivative(T v0, T v1, T v2, T v3, float mu);

		[Token(Token = "0x6000495")]
		T EvaluateSecondDerivative(T v0, T v1, T v2, T v3, float mu);
	}
}
