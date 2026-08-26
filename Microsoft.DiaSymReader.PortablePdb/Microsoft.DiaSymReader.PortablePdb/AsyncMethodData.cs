using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class AsyncMethodData
{
	public static readonly AsyncMethodData None = new AsyncMethodData();

	public readonly MethodDefinitionHandle KickoffMethod;

	public readonly int CatchHandlerOffset;

	public readonly ImmutableArray<int> YieldOffsets;

	public readonly ImmutableArray<int> ResumeOffsets;

	public readonly ImmutableArray<int> ResumeMethods;

	public bool IsNone => this == None;

	private AsyncMethodData()
	{
	}

	public AsyncMethodData(MethodDefinitionHandle kickoffMethod, int catchHandlerOffset, ImmutableArray<int> yieldOffsets, ImmutableArray<int> resumeOffsets, ImmutableArray<int> resumeMethods)
	{
		KickoffMethod = kickoffMethod;
		CatchHandlerOffset = catchHandlerOffset;
		YieldOffsets = yieldOffsets;
		ResumeOffsets = resumeOffsets;
		ResumeMethods = resumeMethods;
	}
}
