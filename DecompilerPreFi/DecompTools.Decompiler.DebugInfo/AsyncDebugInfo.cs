using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace DecompTools.Decompiler.DebugInfo;

internal readonly struct AsyncDebugInfo
{
	public readonly struct Await
	{
		public readonly int YieldOffset;

		public readonly int ResumeOffset;

		public Await(int yieldOffset, int resumeOffset)
		{
			YieldOffset = yieldOffset;
			ResumeOffset = resumeOffset;
		}
	}

	public readonly int CatchHandlerOffset;

	public readonly ImmutableArray<Await> Awaits;

	public AsyncDebugInfo(int catchHandlerOffset, ImmutableArray<Await> awaits)
	{
		CatchHandlerOffset = catchHandlerOffset;
		Awaits = awaits;
	}

	internal BlobBuilder BuildBlob(MethodDefinitionHandle moveNext)
	{
		BlobBuilder blobBuilder = new BlobBuilder();
		checked
		{
			blobBuilder.WriteUInt32((uint)CatchHandlerOffset);
			foreach (Await await in Awaits)
			{
				blobBuilder.WriteUInt32((uint)await.YieldOffset);
				blobBuilder.WriteUInt32((uint)await.ResumeOffset);
				blobBuilder.WriteCompressedInteger(MetadataTokens.GetToken(moveNext));
			}
			return blobBuilder;
		}
	}
}
