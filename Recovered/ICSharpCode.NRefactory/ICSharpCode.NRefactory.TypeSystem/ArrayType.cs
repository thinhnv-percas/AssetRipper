using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem
{
	public sealed class ArrayType : TypeWithElementType, ICompilationProvider
	{
		private readonly int dimensions;

		private readonly ICompilation compilation;

		public override TypeKind Kind => TypeKind.Array;

		public ICompilation Compilation => compilation;

		public int Dimensions => dimensions;

		public override string NameSuffix => "[" + new string(',', dimensions - 1) + "]";

		public override bool? IsReferenceType => true;

		public override IEnumerable<IType> DirectBaseTypes
		{
			get
			{
				List<IType> list = new List<IType>();
				IType type = compilation.FindType(KnownTypeCode.Array);
				if (type.Kind != TypeKind.Unknown)
				{
					list.Add(type);
				}
				if (dimensions == 1 && elementType.Kind != TypeKind.Pointer)
				{
					ITypeDefinition typeDefinition = compilation.FindType(KnownTypeCode.IListOfT) as ITypeDefinition;
					if (typeDefinition != null)
					{
						list.Add(new ParameterizedType(typeDefinition, new IType[1]
						{
							elementType
						}));
					}
					typeDefinition = (compilation.FindType(KnownTypeCode.IReadOnlyListOfT) as ITypeDefinition);
					if (typeDefinition != null)
					{
						list.Add(new ParameterizedType(typeDefinition, new IType[1]
						{
							elementType
						}));
					}
				}
				return list;
			}
		}

		public ArrayType(ICompilation compilation, IType elementType, int dimensions = 1)
			: base(elementType)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			if (dimensions <= 0)
			{
				throw new ArgumentOutOfRangeException("dimensions", dimensions, "dimensions must be positive");
			}
			this.compilation = compilation;
			this.dimensions = dimensions;
			ICompilationProvider compilationProvider = elementType as ICompilationProvider;
			if (compilationProvider != null && compilationProvider.Compilation != compilation)
			{
				throw new InvalidOperationException("Cannot create an array type using a different compilation from the element type.");
			}
		}

		public override int GetHashCode()
		{
			return elementType.GetHashCode() * 71681 + dimensions;
		}

		public override bool Equals(IType other)
		{
			ArrayType arrayType = other as ArrayType;
			if (arrayType != null && elementType.Equals(arrayType.elementType))
			{
				return arrayType.dimensions == dimensions;
			}
			return false;
		}

		public override ITypeReference ToTypeReference()
		{
			return new ArrayTypeReference(elementType.ToTypeReference(), dimensions);
		}

		public override IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return compilation.FindType(KnownTypeCode.Array).GetMethods(filter, options);
		}

		public override IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return compilation.FindType(KnownTypeCode.Array).GetMethods(typeArguments, filter, options);
		}

		public override IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IMethod>.Instance;
			}
			return compilation.FindType(KnownTypeCode.Array).GetAccessors(filter, options);
		}

		public override IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
			{
				return EmptyList<IProperty>.Instance;
			}
			return compilation.FindType(KnownTypeCode.Array).GetProperties(filter, options);
		}

		public override IType AcceptVisitor(TypeVisitor visitor)
		{
			return visitor.VisitArrayType(this);
		}

		public override IType VisitChildren(TypeVisitor visitor)
		{
			IType type = elementType.AcceptVisitor(visitor);
			if (type == elementType)
			{
				return this;
			}
			return new ArrayType(compilation, type, dimensions);
		}
	}
}
