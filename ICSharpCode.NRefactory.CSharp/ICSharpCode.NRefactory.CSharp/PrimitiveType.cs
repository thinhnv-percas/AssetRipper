using System;
using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.CSharp;

public class PrimitiveType : AstType
{
	private TextLocation location;

	private string keyword = string.Empty;

	public string Keyword
	{
		get
		{
			return keyword;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			ThrowIfFrozen();
			keyword = value;
		}
	}

	public KnownTypeCode KnownTypeCode => GetTypeCodeForPrimitiveType(Keyword);

	public override TextLocation StartLocation => location;

	public override TextLocation EndLocation => new TextLocation(location.Line, location.Column + keyword.Length);

	public PrimitiveType()
	{
	}

	public PrimitiveType(string keyword)
	{
		Keyword = keyword;
	}

	public PrimitiveType(string keyword, TextLocation location)
	{
		Keyword = keyword;
		this.location = location;
	}

	internal void SetStartLocation(TextLocation value)
	{
		ThrowIfFrozen();
		location = value;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitPrimitiveType(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitPrimitiveType(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitPrimitiveType(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is PrimitiveType primitiveType)
		{
			return AstNode.MatchString(Keyword, primitiveType.Keyword);
		}
		return false;
	}

	public override string ToString(CSharpFormattingOptions formattingOptions)
	{
		return Keyword;
	}

	public override ITypeReference ToTypeReference(NameLookupMode lookupMode, InterningProvider interningProvider = null)
	{
		KnownTypeCode typeCodeForPrimitiveType = GetTypeCodeForPrimitiveType(Keyword);
		if (typeCodeForPrimitiveType == KnownTypeCode.None)
		{
			if (Keyword == "__arglist")
			{
				return SpecialType.ArgList;
			}
			return new UnknownType(null, Keyword);
		}
		return KnownTypeReference.Get(typeCodeForPrimitiveType);
	}

	public static KnownTypeCode GetTypeCodeForPrimitiveType(string keyword)
	{
		return keyword switch
		{
			"string" => KnownTypeCode.String, 
			"int" => KnownTypeCode.Int32, 
			"uint" => KnownTypeCode.UInt32, 
			"object" => KnownTypeCode.Object, 
			"bool" => KnownTypeCode.Boolean, 
			"sbyte" => KnownTypeCode.SByte, 
			"byte" => KnownTypeCode.Byte, 
			"short" => KnownTypeCode.Int16, 
			"ushort" => KnownTypeCode.UInt16, 
			"long" => KnownTypeCode.Int64, 
			"ulong" => KnownTypeCode.UInt64, 
			"float" => KnownTypeCode.Single, 
			"double" => KnownTypeCode.Double, 
			"decimal" => KnownTypeCode.Decimal, 
			"char" => KnownTypeCode.Char, 
			"void" => KnownTypeCode.Void, 
			_ => KnownTypeCode.None, 
		};
	}
}
