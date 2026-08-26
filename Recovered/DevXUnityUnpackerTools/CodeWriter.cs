using System;
using System.IO;
using System.Runtime.CompilerServices;

public class CodeWriter : IDisposable
{
	public bool EmitComments;

	internal int _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020;

	internal bool _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A;

	internal string _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = "";

	internal readonly string[] _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A;

	[CompilerGenerated]
	internal StreamWriter _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020;

	public StreamWriter Writer
	{
		get;
		internal set;
	}

	public int IndentationLevel => _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020;

	public CodeWriter(StreamWriter writer)
	{
		Writer = writer;
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A = true;
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A = new string[10];
		for (int i = 0; i < _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A.Length; i++)
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A[i] = new string('\t', i);
		}
	}

	public void WriteLine()
	{
		Writer.Write("\n");
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A = true;
	}

	public void WriteLine(string block)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(block);
		Writer.Write("\n");
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A = true;
	}

	public void WriteCommentedLine(string block)
	{
		if (EmitComments)
		{
			block = block.TrimEnd('\\');
			WriteLine("// {0}", block);
		}
	}

	public void WriteCommentedLine(string format, params object[] parameters)
	{
		WriteCommentedLine(string.Format(format, parameters));
	}

	public void WriteStatement(string block)
	{
		WriteLine($"{block};");
	}

	public void WriteLine(string block, params object[] args)
	{
		if (args.Length != 0)
		{
			block = string.Format(block, args);
		}
		WriteLine(block);
	}

	public void Write(string block)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(block);
	}

	public void Write(string block, params object[] args)
	{
		if (args.Length != 0)
		{
			block = string.Format(block, args);
		}
		Write(block);
	}

	public void WriteUnindented(string block, params object[] args)
	{
		if (args.Length != 0)
		{
			block = string.Format(block, args);
		}
		Writer.Write(block + "\n");
	}

	public void Indent(int count = 1)
	{
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020 += count;
		if (_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020 < _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A.Length)
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A[_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020];
		}
		else
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = new string('\t', _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020);
		}
	}

	public void Dedent(int count = 1)
	{
		if (count > _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020)
		{
			throw new ArgumentException("Cannot dedent CppCodeWriter more than it was indented.", "count");
		}
		_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020 -= count;
		if (_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020 < _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A.Length)
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A[_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020];
		}
		else
		{
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020 = new string('\t', _0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020);
		}
	}

	public void BeginBlock()
	{
		WriteLine("{");
		Indent();
	}

	public void BeginBlock(string comment)
	{
		Write("{ // ");
		WriteLine(comment);
		Indent();
	}

	public void EndBlock(bool semicolon = false)
	{
		Dedent();
		if (semicolon)
		{
			WriteLine("};");
		}
		else
		{
			WriteLine("}");
		}
	}

	public void EndBlock(string comment, bool semicolon = false)
	{
		Dedent();
		Write("}");
		if (semicolon)
		{
			Write(";");
		}
		Write(" // ");
		WriteLine(comment);
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A(string _0020)
	{
		if (_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A)
		{
			Writer.Write(_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020);
			_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A = false;
		}
		Writer.Write(_0020);
	}

	public virtual void Dispose()
	{
		Writer.Dispose();
	}
}
