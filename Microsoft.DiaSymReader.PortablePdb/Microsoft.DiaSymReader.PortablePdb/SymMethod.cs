using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymMethod : ISymUnmanagedMethod2, ISymUnmanagedMethod, ISymUnmanagedAsyncMethod, ISymEncUnmanagedMethod
{
	private RootScopeData _lazyRootScopeData;

	private AsyncMethodData _lazyAsyncMethodData;

	internal MethodDebugInformationHandle DebugHandle { get; }

	internal MethodDefinitionHandle DefinitionHandle => DebugHandle.ToDefinitionHandle();

	internal PortablePdbReader PdbReader { get; }

	internal SymReader SymReader => PdbReader.SymReader;

	internal MetadataReader MetadataReader => PdbReader.MetadataReader;

	private AsyncMethodData AsyncMethodData
	{
		get
		{
			if (_lazyAsyncMethodData == null)
			{
				_lazyAsyncMethodData = ReadAsyncMethodData();
			}
			return _lazyAsyncMethodData;
		}
	}

	internal SymMethod(PortablePdbReader pdbReader, MethodDebugInformationHandle handle)
	{
		PdbReader = pdbReader;
		DebugHandle = handle;
	}

	internal MethodId GetId()
	{
		return PdbReader.GetMethodId(DebugHandle);
	}

	private SequencePointCollection GetSequencePoints()
	{
		return MetadataReader.GetMethodDebugInformation(DebugHandle).GetSequencePoints();
	}

	internal StandaloneSignatureHandle GetLocalSignatureHandle()
	{
		return MetadataReader.GetMethodDebugInformation(DebugHandle).LocalSignature;
	}

	private RootScopeData GetRootScopeData()
	{
		if (_lazyRootScopeData == null)
		{
			_lazyRootScopeData = new RootScopeData(this);
		}
		return _lazyRootScopeData;
	}

	private int GetILSize()
	{
		return GetRootScopeData().EndOffset;
	}

	internal static int GetLocalVariableCount(MetadataReader metadataReader, MethodDebugInformationHandle handle)
	{
		int num = 0;
		foreach (LocalScopeHandle localScope in metadataReader.GetLocalScopes(handle))
		{
			num += metadataReader.GetLocalScope(localScope).GetLocalVariables().Count;
		}
		return num;
	}

	internal void AddLocalVariables(ISymUnmanagedVariable[] variables)
	{
		MetadataReader metadataReader = MetadataReader;
		int num = 0;
		foreach (LocalScopeHandle localScope in metadataReader.GetLocalScopes(DebugHandle))
		{
			foreach (LocalVariableHandle localVariable in metadataReader.GetLocalScope(localScope).GetLocalVariables())
			{
				variables[num++] = new SymVariable(this, localVariable);
			}
		}
	}

	public int GetNamespace([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace @namespace)
	{
		@namespace = null;
		return -2147467263;
	}

	public int GetOffset(ISymUnmanagedDocument document, int line, int column, out int offset)
	{
		if (line <= 0)
		{
			offset = 0;
			return -2147024809;
		}
		SymDocument symDocument = SymReader.AsSymDocument(document);
		if (symDocument == null)
		{
			offset = 0;
			return -2147024809;
		}
		DocumentHandle handle = symDocument.Handle;
		if (!SymReader.TryGetLineDeltas(GetId(), out var deltas))
		{
			deltas = default(MethodLineDeltas);
		}
		int num = 0;
		foreach (SequencePoint sequencePoint in GetSequencePoints())
		{
			if (!sequencePoint.IsHidden && sequencePoint.Document == handle)
			{
				int deltaForSequencePoint = deltas.GetDeltaForSequencePoint(num);
				if (line >= sequencePoint.StartLine + deltaForSequencePoint && line <= sequencePoint.EndLine + deltaForSequencePoint)
				{
					offset = sequencePoint.Offset;
					return 0;
				}
			}
			num++;
		}
		offset = 0;
		return -2147467259;
	}

	public int GetParameters(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] parameters)
	{
		count = 0;
		return -2147467263;
	}

	public int GetRanges(ISymUnmanagedDocument document, int line, int column, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] ranges)
	{
		if (line <= 0)
		{
			count = 0;
			return -2147024809;
		}
		SymDocument symDocument = SymReader.AsSymDocument(document);
		if (symDocument == null)
		{
			count = 0;
			return -2147024809;
		}
		DocumentHandle handle = symDocument.Handle;
		if (!SymReader.TryGetLineDeltas(GetId(), out var deltas))
		{
			deltas = default(MethodLineDeltas);
		}
		bool flag = false;
		int num = 0;
		int num2 = 0;
		foreach (SequencePoint sequencePoint in GetSequencePoints())
		{
			if (flag)
			{
				ranges[num - 1] = sequencePoint.Offset;
				flag = false;
			}
			if (!sequencePoint.IsHidden && sequencePoint.Document == handle)
			{
				int deltaForSequencePoint = deltas.GetDeltaForSequencePoint(num2);
				if (line >= sequencePoint.StartLine + deltaForSequencePoint && line <= sequencePoint.EndLine + deltaForSequencePoint)
				{
					if (num + 1 < bufferLength)
					{
						ranges[num] = sequencePoint.Offset;
						flag = true;
					}
					num += 2;
				}
			}
			num2++;
		}
		if (flag)
		{
			ranges[num - 1] = GetILSize();
		}
		count = num;
		return 0;
	}

	public int GetRootScope([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope)
	{
		scope = new SymScope(GetRootScopeData());
		return 0;
	}

	public int GetScopeFromOffset(int offset, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope)
	{
		scope = null;
		return 0;
	}

	public int GetSequencePointCount(out int count)
	{
		int num = 0;
		foreach (SequencePoint sequencePoint in GetSequencePoints())
		{
			_ = sequencePoint;
			num++;
		}
		count = num;
		return 0;
	}

	public int GetSequencePoints(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] offsets, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startColumns, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endColumns)
	{
		SymDocument symDocument = null;
		if ((startLines == null && endLines == null) || !SymReader.TryGetLineDeltas(GetId(), out var deltas))
		{
			deltas = default(MethodLineDeltas);
		}
		int num = 0;
		foreach (SequencePoint sequencePoint in GetSequencePoints())
		{
			if (bufferLength != 0 && num >= bufferLength)
			{
				break;
			}
			int num2 = ((!sequencePoint.IsHidden) ? deltas.GetDeltaForSequencePoint(num) : 0);
			if (offsets != null)
			{
				offsets[num] = sequencePoint.Offset;
			}
			if (startLines != null)
			{
				startLines[num] = sequencePoint.StartLine + num2;
			}
			if (startColumns != null)
			{
				startColumns[num] = sequencePoint.StartColumn;
			}
			if (endLines != null)
			{
				endLines[num] = sequencePoint.EndLine + num2;
			}
			if (endColumns != null)
			{
				endColumns[num] = sequencePoint.EndColumn;
			}
			if (documents != null)
			{
				if (symDocument == null || symDocument.Handle != sequencePoint.Document)
				{
					symDocument = new SymDocument(PdbReader, sequencePoint.Document);
				}
				documents[num] = symDocument;
			}
			num++;
		}
		count = num;
		return 0;
	}

	public int GetSourceStartEnd(ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] lines, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] columns, out bool defined)
	{
		defined = false;
		return -2147467263;
	}

	public int GetToken(out int methodToken)
	{
		methodToken = PdbReader.GetMethodId(DebugHandle).Token;
		return 0;
	}

	public int GetLocalSignatureToken(out int localSignatureToken)
	{
		StandaloneSignatureHandle localSignatureHandle = GetLocalSignatureHandle();
		if (localSignatureHandle.IsNil)
		{
			localSignatureToken = 0;
			return 1;
		}
		localSignatureToken = MetadataTokens.GetToken(localSignatureHandle);
		return 0;
	}

	private AsyncMethodData ReadAsyncMethodData()
	{
		MetadataReader metadataReader = MetadataReader;
		MethodDefinitionHandle stateMachineKickoffMethod = metadataReader.GetMethodDebugInformation(DebugHandle).GetStateMachineKickoffMethod();
		if (stateMachineKickoffMethod.IsNil)
		{
			return AsyncMethodData.None;
		}
		BlobHandle customDebugInformation = metadataReader.GetCustomDebugInformation(DefinitionHandle, MetadataUtilities.MethodSteppingInformationBlobId);
		if (customDebugInformation.IsNil)
		{
			return AsyncMethodData.None;
		}
		BlobReader blobReader = metadataReader.GetBlobReader(customDebugInformation);
		long num = blobReader.ReadUInt32();
		if (num > 2147483648u)
		{
			throw new BadImageFormatException();
		}
		ImmutableArray<int>.Builder builder = ImmutableArray.CreateBuilder<int>();
		ImmutableArray<int>.Builder builder2 = ImmutableArray.CreateBuilder<int>();
		ImmutableArray<int>.Builder builder3 = ImmutableArray.CreateBuilder<int>();
		while (blobReader.RemainingBytes > 0)
		{
			uint num2 = blobReader.ReadUInt32();
			if (num2 > int.MaxValue)
			{
				throw new BadImageFormatException();
			}
			uint num3 = blobReader.ReadUInt32();
			if (num3 > int.MaxValue)
			{
				throw new BadImageFormatException();
			}
			builder.Add((int)num2);
			builder2.Add((int)num3);
			builder3.Add(MetadataUtilities.MethodDefToken(blobReader.ReadCompressedInteger()));
		}
		return new AsyncMethodData(stateMachineKickoffMethod, (int)(num - 1), builder.ToImmutable(), builder2.ToImmutable(), builder3.ToImmutable());
	}

	public int IsAsyncMethod(out bool value)
	{
		value = !AsyncMethodData.IsNone;
		return 0;
	}

	public int GetKickoffMethod(out int kickoffMethodToken)
	{
		if (AsyncMethodData.IsNone)
		{
			kickoffMethodToken = 0;
			return -2147418113;
		}
		kickoffMethodToken = MetadataTokens.GetToken(AsyncMethodData.KickoffMethod);
		return 0;
	}

	public int HasCatchHandlerILOffset(out bool value)
	{
		if (AsyncMethodData.IsNone)
		{
			value = false;
			return -2147418113;
		}
		value = AsyncMethodData.CatchHandlerOffset >= 0;
		return 0;
	}

	public int GetCatchHandlerILOffset(out int offset)
	{
		if (AsyncMethodData.IsNone || AsyncMethodData.CatchHandlerOffset < 0)
		{
			offset = 0;
			return -2147418113;
		}
		offset = AsyncMethodData.CatchHandlerOffset;
		return 0;
	}

	public int GetAsyncStepInfoCount(out int count)
	{
		if (AsyncMethodData.IsNone)
		{
			count = 0;
			return -2147418113;
		}
		count = AsyncMethodData.YieldOffsets.Length;
		return 0;
	}

	public int GetAsyncStepInfo(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] yieldOffsets, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointOffsets, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] breakpointMethods)
	{
		if (AsyncMethodData.IsNone)
		{
			count = 0;
			return -2147418113;
		}
		int num = Math.Min(bufferLength, AsyncMethodData.YieldOffsets.Length);
		if (yieldOffsets != null)
		{
			AsyncMethodData.YieldOffsets.CopyTo(0, yieldOffsets, 0, num);
		}
		if (breakpointOffsets != null)
		{
			AsyncMethodData.ResumeOffsets.CopyTo(0, breakpointOffsets, 0, num);
		}
		if (breakpointMethods != null)
		{
			AsyncMethodData.ResumeMethods.CopyTo(0, breakpointMethods, 0, num);
		}
		count = num;
		return 0;
	}

	public int GetFileNameFromOffset(int offset, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] char[] name)
	{
		if (offset < 0)
		{
			offset = int.MaxValue;
		}
		DocumentHandle document = MetadataReader.GetMethodDebugInformation(DebugHandle).Document;
		if (document.IsNil)
		{
			foreach (SequencePoint sequencePoint in GetSequencePoints())
			{
				if (sequencePoint.Offset <= offset)
				{
					document = sequencePoint.Document;
				}
				else if (sequencePoint.Offset > offset)
				{
					break;
				}
			}
			if (document.IsNil)
			{
				count = 0;
				return -2147467259;
			}
		}
		Document document2 = MetadataReader.GetDocument(document);
		return InteropUtilities.StringToBuffer(MetadataReader.GetString(document2.Name), bufferLength, out count, name);
	}

	public int GetLineFromOffset(int offset, out int startLine, out int startColumn, out int endLine, out int endColumn, out int sequencePointOffset)
	{
		if (offset < 0)
		{
			offset = int.MaxValue;
		}
		SequencePoint sequencePoint = default(SequencePoint);
		int num = -1;
		int num2 = 0;
		foreach (SequencePoint sequencePoint2 in GetSequencePoints())
		{
			if (sequencePoint2.Offset <= offset)
			{
				sequencePoint = sequencePoint2;
				num = num2;
			}
			else if (sequencePoint2.Offset > offset)
			{
				break;
			}
			num2++;
		}
		if (num < 0)
		{
			startLine = (startColumn = (endLine = (endColumn = (sequencePointOffset = 0))));
			return -2147467259;
		}
		int num3 = ((!sequencePoint.IsHidden && SymReader.TryGetLineDeltas(GetId(), out var deltas)) ? deltas.GetDeltaForSequencePoint(num) : 0);
		startLine = sequencePoint.StartLine + num3;
		startColumn = sequencePoint.StartColumn;
		endLine = sequencePoint.EndLine + num3;
		endColumn = sequencePoint.EndColumn;
		sequencePointOffset = sequencePoint.Offset;
		return 0;
	}

	public int GetDocumentsForMethodCount(out int count)
	{
		int documentsForMethod = GetDocumentsForMethod(0, out count, EmptyArray<ISymUnmanagedDocument>.Instance);
		if (documentsForMethod == -2147024809)
		{
			return 0;
		}
		return documentsForMethod;
	}

	public int GetDocumentsForMethod(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents)
	{
		if (documents == null)
		{
			count = 0;
			return -2147024809;
		}
		var (documentHandle, enumerable) = MethodExtents.GetMethodBodyDocuments(MetadataReader, DebugHandle);
		if (!documentHandle.IsNil)
		{
			count = 1;
			if (documents.Length < 1)
			{
				return -2147024809;
			}
			documents[0] = new SymDocument(PdbReader, documentHandle);
			return 0;
		}
		List<DocumentHandle> list = new List<DocumentHandle>();
		foreach (DocumentHandle item in enumerable)
		{
			if (!list.Contains(item))
			{
				list.Add(item);
			}
		}
		count = list.Count;
		if (documents.Length < list.Count)
		{
			return -2147024809;
		}
		for (int i = 0; i < list.Count; i++)
		{
			documents[i] = new SymDocument(PdbReader, list[i]);
		}
		return 0;
	}

	public int GetSourceExtentInDocument(ISymUnmanagedDocument document, out int startLine, out int endLine)
	{
		return PdbReader.GetMethodSourceExtentInDocument(document, this, out startLine, out endLine);
	}
}
