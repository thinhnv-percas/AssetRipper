using Cpp2ILInjected;

[Token(Token = "0x2000001")]
internal interface IActivationFactory
{
	[Token(Token = "0x6000001")]
	virtual object ActivateInstance()
	{
		return null;
	}
}
