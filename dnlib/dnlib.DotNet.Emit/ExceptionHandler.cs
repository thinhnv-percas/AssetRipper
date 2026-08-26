namespace dnlib.DotNet.Emit;

public sealed class ExceptionHandler
{
	public Instruction TryStart;

	public Instruction TryEnd;

	public Instruction FilterStart;

	public Instruction HandlerStart;

	public Instruction HandlerEnd;

	public ITypeDefOrRef CatchType;

	public ExceptionHandlerType HandlerType;

	public ExceptionHandler()
	{
	}

	public ExceptionHandler(ExceptionHandlerType handlerType)
	{
		HandlerType = handlerType;
	}
}
