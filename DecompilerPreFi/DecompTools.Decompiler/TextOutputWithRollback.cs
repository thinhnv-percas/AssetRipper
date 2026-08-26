using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

internal class TextOutputWithRollback : ITextOutput
{
	private List<Action<ITextOutput>> actions;

	private ITextOutput target;

	public TextOutputWithRollback(ITextOutput target)
	{
		this.target = target;
		actions = new List<Action<ITextOutput>>();
	}

	public void Commit()
	{
		foreach (Action<ITextOutput> action in actions)
		{
			action(target);
		}
	}

	public void Indent()
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.Indent();
		});
	}

	public void MarkFoldEnd()
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.MarkFoldEnd();
		});
	}

	public void MarkFoldStart(string collapsedText = "...", bool defaultCollapsed = false)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.MarkFoldStart(collapsedText, defaultCollapsed);
		});
	}

	public void Unindent()
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.Unindent();
		});
	}

	public void Write(char ch)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.Write(ch);
		});
	}

	public void Write(string text)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.Write(text);
		});
	}

	public void WriteLine()
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteLine();
		});
	}

	public void WriteLocalReference(string text, object reference, bool isDefinition = false)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteLocalReference(text, reference, isDefinition);
		});
	}

	public void WriteReference(OpCodeInfo opCode)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteReference(opCode);
		});
	}

	public void WriteReference(PEFile module, EntityHandle handle, string text, bool isDefinition = false)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteReference(module, handle, text, isDefinition);
		});
	}

	public void WriteReference(IType type, string text, bool isDefinition = false)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteReference(type, text, isDefinition);
		});
	}

	public void WriteReference(IMember member, string text, bool isDefinition = false)
	{
		actions.Add(delegate(ITextOutput target)
		{
			target.WriteReference(member, text, isDefinition);
		});
	}
}
