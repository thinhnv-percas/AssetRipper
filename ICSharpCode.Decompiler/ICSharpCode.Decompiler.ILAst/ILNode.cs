using System;
using System.Collections;
using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;

namespace ICSharpCode.Decompiler.ILAst;

public abstract class ILNode : IEnumerable<ILNode>, IEnumerable
{
	public struct ILNode_Enumerator : IEnumerator<ILNode>, IDisposable, IEnumerator
	{
		private readonly ILNode node;

		private int index;

		private ILNode current;

		public ILNode Current => current;

		object IEnumerator.Current => current;

		internal ILNode_Enumerator(ILNode node)
		{
			this.node = node;
			index = 0;
			current = null;
		}

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			return (current = node.GetNext(ref index)) != null;
		}

		public void Reset()
		{
			index = 0;
		}
	}

	protected struct BraceInfo
	{
		public int Start { get; }

		public BraceInfo(int start)
		{
			Start = start;
		}
	}

	public readonly List<ILSpan> ILSpans = new List<ILSpan>(1);

	public virtual List<ILSpan> EndILSpans => ILSpans;

	public bool HasEndILSpans => ILSpans != EndILSpans;

	public bool WritesNewLine
	{
		get
		{
			if (!(this is ILLabel) && !(this is ILExpression))
			{
				return !(this is ILSwitch.CaseBlock);
			}
			return false;
		}
	}

	public virtual bool SafeToAddToEndILSpans => false;

	public bool HasChildren
	{
		get
		{
			using (ILNode_Enumerator iLNode_Enumerator = GetChildren().GetEnumerator())
			{
				if (iLNode_Enumerator.MoveNext())
				{
					ILNode current = iLNode_Enumerator.Current;
					return true;
				}
			}
			return false;
		}
	}

	public virtual ILSpan GetAllILSpans(ref long index, ref bool done)
	{
		if (index < ILSpans.Count)
		{
			return ILSpans[(int)index++];
		}
		done = true;
		return default(ILSpan);
	}

	public IEnumerable<ILSpan> GetSelfAndChildrenRecursiveILSpans()
	{
		foreach (ILNode node in GetSelfAndChildrenRecursive<ILNode>())
		{
			long index = 0L;
			bool done = false;
			while (true)
			{
				ILSpan allILSpans = node.GetAllILSpans(ref index, ref done);
				if (done)
				{
					break;
				}
				yield return allILSpans;
			}
		}
	}

	public void AddSelfAndChildrenRecursiveILSpans(List<ILSpan> coll)
	{
		foreach (ILNode item in GetSelfAndChildrenRecursive<ILNode>())
		{
			long index = 0L;
			bool done = false;
			while (true)
			{
				ILSpan allILSpans = item.GetAllILSpans(ref index, ref done);
				if (done)
				{
					break;
				}
				coll.Add(allILSpans);
			}
		}
	}

	public List<ILSpan> GetSelfAndChildrenRecursiveILSpans_OrderAndJoin()
	{
		List<ILSpan> list = new List<ILSpan>();
		AddSelfAndChildrenRecursiveILSpans(list);
		return ILSpan.OrderAndCompactList(list);
	}

	public List<T> GetSelfAndChildrenRecursive<T>(Func<T, bool> predicate = null) where T : ILNode
	{
		List<T> list = new List<T>(16);
		AccumulateSelfAndChildrenRecursive(list, predicate);
		return list;
	}

	public List<T> GetSelfAndChildrenRecursive<T>(List<T> result, Func<T, bool> predicate = null) where T : ILNode
	{
		result.Clear();
		AccumulateSelfAndChildrenRecursive(result, predicate);
		return result;
	}

	private void AccumulateSelfAndChildrenRecursive<T>(List<T> list, Func<T, bool> predicate) where T : ILNode
	{
		if (this is T val && (predicate == null || predicate(val)))
		{
			list.Add(val);
		}
		int index = 0;
		while (true)
		{
			ILNode next = GetNext(ref index);
			if (next != null)
			{
				next.AccumulateSelfAndChildrenRecursive(list, predicate);
				continue;
			}
			break;
		}
	}

	internal virtual ILNode GetNext(ref int index)
	{
		return null;
	}

	public ILNode GetChildren()
	{
		return this;
	}

	public ILNode_Enumerator GetEnumerator()
	{
		return new ILNode_Enumerator(this);
	}

	IEnumerator<ILNode> IEnumerable<ILNode>.GetEnumerator()
	{
		return new ILNode_Enumerator(this);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new ILNode_Enumerator(this);
	}

	public override string ToString()
	{
		StringBuilderDecompilerOutput stringBuilderDecompilerOutput = new StringBuilderDecompilerOutput();
		WriteTo(stringBuilderDecompilerOutput, null);
		return stringBuilderDecompilerOutput.ToString().Replace("\r\n", "; ");
	}

	public abstract void WriteTo(IDecompilerOutput output, MethodDebugInfoBuilder builder);

	protected void UpdateDebugInfo(MethodDebugInfoBuilder builder, int startLoc, int endLoc, IEnumerable<ILSpan> ranges)
	{
		if (builder == null)
		{
			return;
		}
		foreach (ILSpan item in ILSpan.OrderAndCompact(ranges))
		{
			builder.Add(new SourceStatement(item, new TextSpan(startLoc, endLoc - startLoc)));
		}
	}

	protected BraceInfo WriteHiddenStart(IDecompilerOutput output, MethodDebugInfoBuilder builder, IEnumerable<ILSpan> extraILSpans = null)
	{
		int nextPosition = output.NextPosition;
		int nextPosition2 = output.NextPosition;
		output.Write("{", BoxedTextColor.Punctuation);
		List<ILSpan> list = new List<ILSpan>(ILSpans);
		if (extraILSpans != null)
		{
			list.AddRange(extraILSpans);
		}
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, list);
		output.WriteLine();
		output.IncreaseIndent();
		return new BraceInfo(nextPosition2);
	}

	protected void WriteHiddenEnd(IDecompilerOutput output, MethodDebugInfoBuilder builder, BraceInfo info, CodeBracesRangeFlags flags)
	{
		output.DecreaseIndent();
		int nextPosition = output.NextPosition;
		int nextPosition2 = output.NextPosition;
		output.Write("}", BoxedTextColor.Punctuation);
		output.AddBracePair(new TextSpan(info.Start, 1), new TextSpan(nextPosition2, 1), flags);
		UpdateDebugInfo(builder, nextPosition, output.NextPosition, EndILSpans);
		output.WriteLine();
	}
}
