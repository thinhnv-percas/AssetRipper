using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;

namespace ICSharpCode.NRefactory.CSharp
{
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
			PrimitiveType primitiveType = other as PrimitiveType;
			if (primitiveType != null)
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
			switch (keyword)
			{
			case "string":
				return KnownTypeCode.String;
			case "int":
				return KnownTypeCode.Int32;
			case "uint":
				return KnownTypeCode.UInt32;
			case "object":
				return KnownTypeCode.Object;
			case "bool":
				return KnownTypeCode.Boolean;
			case "sbyte":
				return KnownTypeCode.SByte;
			case "byte":
				return KnownTypeCode.Byte;
			case "short":
				return KnownTypeCode.Int16;
			case "ushort":
				return KnownTypeCode.UInt16;
			case "long":
				return KnownTypeCode.Int64;
			case "ulong":
				return KnownTypeCode.UInt64;
			case "float":
				return KnownTypeCode.Single;
			case "double":
				return KnownTypeCode.Double;
			case "decimal":
				return KnownTypeCode.Decimal;
			case "char":
				return KnownTypeCode.Char;
			case "void":
				return KnownTypeCode.Void;
			default:
				return KnownTypeCode.None;
			}
		}
	}
}
