#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public sealed class MethodDebugInfo
{
	private ILSpan[] cachedUnusedILSpans;

	private Dictionary<TextSpan, SmallList<ILSpan>> statementsDict;

	public string CompilerName { get; }

	public int DecompilerSettingsVersion { get; }

	public StateMachineKind StateMachineKind { get; }

	public MethodDef Method { get; }

	public MethodDef KickoffMethod { get; }

	public SourceParameter[] Parameters { get; }

	public SourceStatement[] Statements { get; }

	public AsyncMethodDebugInfo AsyncInfo { get; }

	public MethodDebugScope Scope { get; }

	public TextSpan Span { get; }

	public bool HasSpan => Span.Start != 0 && Span.End != 0;

	public MethodDebugInfo(string compilerName, int decompilerSettingsVersion, StateMachineKind stateMachineKind, MethodDef method, MethodDef kickoffMethod, SourceParameter[] parameters, SourceStatement[] statements, MethodDebugScope scope, TextSpan? methodSpan, AsyncMethodDebugInfo asyncMethodDebugInfo)
	{
		if (statements == null)
		{
			throw new ArgumentNullException("statements");
		}
		CompilerName = compilerName;
		Method = method ?? throw new ArgumentNullException("method");
		KickoffMethod = kickoffMethod;
		Parameters = parameters ?? Array.Empty<SourceParameter>();
		if (statements.Length > 1)
		{
			Array.Sort(statements, SourceStatement.SpanStartComparer);
		}
		DecompilerSettingsVersion = decompilerSettingsVersion;
		Statements = statements;
		Scope = scope ?? throw new ArgumentNullException("scope");
		Span = methodSpan ?? CalculateMethodSpan(statements) ?? new TextSpan(0, 0);
		AsyncInfo = asyncMethodDebugInfo;
	}

	private static TextSpan? CalculateMethodSpan(SourceStatement[] statements)
	{
		int num = int.MaxValue;
		int num2 = int.MinValue;
		for (int i = 0; i < statements.Length; i++)
		{
			SourceStatement sourceStatement = statements[i];
			if (num > sourceStatement.TextSpan.Start)
			{
				num = sourceStatement.TextSpan.Start;
			}
			if (num2 < sourceStatement.TextSpan.End)
			{
				num2 = sourceStatement.TextSpan.End;
			}
		}
		return (num <= num2) ? new TextSpan?(TextSpan.FromBounds(num, num2)) : ((TextSpan?)null);
	}

	public ILSpan[] GetRanges(ILSpan[] sourceILSpans)
	{
		List<ILSpan> list = new List<ILSpan>(sourceILSpans.Length + GetUnusedILSpans().Length + 1);
		list.AddRange(sourceILSpans);
		list.AddRange(GetUnusedILSpans());
		return ILSpan.OrderAndCompactList(list).ToArray();
	}

	public ILSpan[] GetUnusedRanges()
	{
		return GetUnusedILSpans();
	}

	private ILSpan[] GetUnusedILSpans()
	{
		if (cachedUnusedILSpans != null)
		{
			return cachedUnusedILSpans;
		}
		List<ILSpan> list = new List<ILSpan>(Statements.Length);
		SourceStatement[] statements = Statements;
		foreach (SourceStatement sourceStatement in statements)
		{
			list.Add(sourceStatement.ILSpan);
		}
		return cachedUnusedILSpans = GetUnusedILSpans(list).ToArray();
	}

	private List<ILSpan> GetUnusedILSpans(List<ILSpan> list)
	{
		uint codeSize = (uint)Method.Body.GetCodeSize();
		list = ILSpan.OrderAndCompact(list);
		List<ILSpan> list2 = new List<ILSpan>();
		if (list.Count == 0)
		{
			if (codeSize != 0)
			{
				list2.Add(new ILSpan(0u, codeSize));
			}
			return list2;
		}
		uint num = 0u;
		for (int i = 0; i < list.Count; i++)
		{
			ILSpan iLSpan = list[i];
			Debug.Assert(iLSpan.Start >= num);
			uint num2 = iLSpan.Start - num;
			if (num2 != 0)
			{
				list2.Add(new ILSpan(num, num2));
			}
			num = iLSpan.End;
		}
		Debug.Assert(num <= codeSize);
		if (num < codeSize)
		{
			list2.Add(new ILSpan(num, codeSize - num));
		}
		return list2;
	}

	public SourceStatement? GetSourceStatementByTextOffset(int lineStart, int lineEnd, int textPosition)
	{
		if (lineStart >= Span.End || lineEnd < Span.Start)
		{
			return null;
		}
		SourceStatement? result = null;
		SourceStatement[] statements = Statements;
		for (int i = 0; i < statements.Length; i++)
		{
			SourceStatement value = statements[i];
			if (value.TextSpan.Start <= textPosition)
			{
				if (textPosition < value.TextSpan.End)
				{
					return value;
				}
				if (textPosition == value.TextSpan.End && (!result.HasValue || value.TextSpan.Start > result.Value.TextSpan.Start))
				{
					result = value;
				}
			}
		}
		if (result.HasValue)
		{
			return result;
		}
		List<SourceStatement> list = new List<SourceStatement>();
		SourceStatement[] statements2 = Statements;
		for (int j = 0; j < statements2.Length; j++)
		{
			SourceStatement item = statements2[j];
			if (lineStart < item.TextSpan.End && lineEnd > item.TextSpan.Start)
			{
				list.Add(item);
			}
		}
		list.Sort(delegate(SourceStatement a, SourceStatement b)
		{
			int num = Math.Abs(a.TextSpan.Start - textPosition) - Math.Abs(b.TextSpan.Start - textPosition);
			return (num != 0) ? num : ((int)(a.ILSpan.Start - b.ILSpan.Start));
		});
		if (list.Count > 0)
		{
			return list[0];
		}
		return null;
	}

	public SourceStatement? GetSourceStatementByCodeOffset(uint ilOffset)
	{
		SourceStatement[] statements = Statements;
		for (int i = 0; i < statements.Length; i++)
		{
			SourceStatement value = statements[i];
			if (value.ILSpan.Start <= ilOffset && ilOffset < value.ILSpan.End)
			{
				return value;
			}
		}
		return null;
	}

	public ILSpan[] GetILSpansOfStatement(TextSpan statementSpan)
	{
		if (statementsDict == null)
		{
			Interlocked.CompareExchange(ref statementsDict, CreateStatementsDict(Statements), null);
		}
		if (statementsDict.TryGetValue(statementSpan, out var value))
		{
			ILSpan[] array = value.ToArray();
			for (int i = 1; i < array.Length; i++)
			{
				Debug.Assert(array[i - 1].End <= array[i].Start);
			}
			return array;
		}
		return Array.Empty<ILSpan>();
	}

	private static Dictionary<TextSpan, SmallList<ILSpan>> CreateStatementsDict(SourceStatement[] statements)
	{
		Dictionary<TextSpan, SmallList<ILSpan>> dictionary = new Dictionary<TextSpan, SmallList<ILSpan>>(statements.Length);
		for (int i = 0; i < statements.Length; i++)
		{
			SourceStatement sourceStatement = statements[i];
			dictionary.TryGetValue(sourceStatement.TextSpan, out var value);
			value.Add(sourceStatement.ILSpan);
			dictionary[sourceStatement.TextSpan] = value;
		}
		return dictionary;
	}
}
