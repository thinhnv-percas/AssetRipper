using System;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler;

public readonly struct MethodSourceStatement : IEquatable<MethodSourceStatement>
{
	public MethodDef Method { get; }

	public SourceStatement Statement { get; }

	public MethodSourceStatement(MethodDef method, SourceStatement statement)
	{
		Method = method ?? throw new ArgumentNullException("method");
		Statement = statement;
	}

	public static bool operator ==(MethodSourceStatement left, MethodSourceStatement right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(MethodSourceStatement left, MethodSourceStatement right)
	{
		return !left.Equals(right);
	}

	public bool Equals(MethodSourceStatement other)
	{
		return Method == other.Method && Statement.Equals(other.Statement);
	}

	public override bool Equals(object obj)
	{
		return obj is MethodSourceStatement && Equals((MethodSourceStatement)obj);
	}

	public override int GetHashCode()
	{
		return Method.GetHashCode() ^ Statement.GetHashCode();
	}

	public override string ToString()
	{
		return "{" + Statement.ToString() + "," + Method.ToString() + "}";
	}
}
