using System;
using DecompTools.Decompiler.CSharp.OutputVisitor;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Syntax;

public sealed class NewLineNode : AstNode
{
	private const uint newLineMask = 15360u;

	private static readonly UnicodeNewline[] newLineTypes = new UnicodeNewline[9]
	{
		UnicodeNewline.Unknown,
		UnicodeNewline.LF,
		UnicodeNewline.CRLF,
		UnicodeNewline.CR,
		UnicodeNewline.NEL,
		UnicodeNewline.VT,
		UnicodeNewline.FF,
		UnicodeNewline.LS,
		UnicodeNewline.PS
	};

	private TextLocation startLocation;

	public override NodeType NodeType => NodeType.Whitespace;

	public UnicodeNewline NewLineType
	{
		get
		{
			return newLineTypes[(flags & 0x3C00) >> 10];
		}
		set
		{
			ThrowIfFrozen();
			int num = Array.IndexOf(newLineTypes, value);
			if (num < 0)
			{
				num = 0;
			}
			flags &= 4294951935u;
			flags |= checked((uint)num) << 10;
		}
	}

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => new TextLocation(checked(startLocation.Line + 1), 1);

	public NewLineNode()
		: this(TextLocation.Empty)
	{
	}

	public NewLineNode(TextLocation startLocation)
	{
		this.startLocation = startLocation;
	}

	public sealed override string ToString(CSharpFormattingOptions formattingOptions)
	{
		return NewLine.GetString(NewLineType);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitNewLine(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitNewLine(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNewLine(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is NewLineNode;
	}
}
