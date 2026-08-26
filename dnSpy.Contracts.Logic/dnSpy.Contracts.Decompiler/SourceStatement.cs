using System;
using System.Collections.Generic;

namespace dnSpy.Contracts.Decompiler;

public readonly struct SourceStatement : IEquatable<SourceStatement>
{
	private sealed class SpanStartComparerImpl : IComparer<SourceStatement>
	{
		public int Compare(SourceStatement x, SourceStatement y)
		{
			return (int)(x.ilSpan.Start - y.ilSpan.Start);
		}
	}

	internal static readonly IComparer<SourceStatement> SpanStartComparer = new SpanStartComparerImpl();

	private readonly ILSpan ilSpan;

	private readonly TextSpan textSpan;

	public ILSpan ILSpan => ilSpan;

	public TextSpan TextSpan => textSpan;

	public SourceStatement(ILSpan ilSpan, TextSpan textSpan)
	{
		this.ilSpan = ilSpan;
		this.textSpan = textSpan;
	}

	public static bool operator ==(SourceStatement left, SourceStatement right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(SourceStatement left, SourceStatement right)
	{
		return !left.Equals(right);
	}

	public bool Equals(SourceStatement other)
	{
		return ilSpan.Equals(other.ilSpan) && textSpan.Equals(other.textSpan);
	}

	public override bool Equals(object obj)
	{
		return obj is SourceStatement && Equals((SourceStatement)obj);
	}

	public override int GetHashCode()
	{
		return ilSpan.GetHashCode() ^ textSpan.GetHashCode();
	}

	public override string ToString()
	{
		return "{" + ilSpan.ToString() + "," + textSpan.ToString() + "}";
	}
}
