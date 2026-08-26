using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class AsyncMethodDebugInfo
{
	public AsyncStepInfo[] StepInfos { get; }

	public FieldDef BuilderFieldOrNull { get; }

	public uint CatchHandlerOffset { get; }

	public uint SetResultOffset { get; }

	public AsyncMethodDebugInfo(AsyncStepInfo[] stepInfos, FieldDef builderField, uint catchHandlerOffset, uint setResultOffset)
	{
		StepInfos = stepInfos ?? throw new ArgumentNullException("stepInfos");
		BuilderFieldOrNull = builderField;
		CatchHandlerOffset = catchHandlerOffset;
		SetResultOffset = setResultOffset;
	}
}
