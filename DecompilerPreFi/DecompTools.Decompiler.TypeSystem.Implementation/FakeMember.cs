using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal abstract class FakeMember : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly ICompilation compilation;

	IMember IMember.MemberDefinition => this;

	public IType ReturnType { get; set; } = SpecialType.UnknownType;

	IEnumerable<IMember> IMember.ExplicitlyImplementedInterfaceMembers => EmptyList<IMember>.Instance;

	bool IMember.IsExplicitInterfaceImplementation => false;

	bool IMember.IsVirtual => false;

	bool IMember.IsOverride => false;

	bool IMember.IsOverridable => false;

	TypeParameterSubstitution IMember.Substitution => TypeParameterSubstitution.Identity;

	EntityHandle IEntity.MetadataToken => default(EntityHandle);

	public string Name { get; set; }

	ITypeDefinition IEntity.DeclaringTypeDefinition => DeclaringType?.GetDefinition();

	public IType DeclaringType { get; set; }

	IModule IEntity.ParentModule => DeclaringType?.GetDefinition()?.ParentModule;

	public Accessibility Accessibility { get; set; } = Accessibility.Public;

	public bool IsStatic { get; set; }

	bool IEntity.IsAbstract => false;

	bool IEntity.IsSealed => false;

	public abstract SymbolKind SymbolKind { get; }

	ICompilation ICompilationProvider.Compilation => compilation;

	string INamedElement.FullName
	{
		get
		{
			if (DeclaringType != null)
			{
				return DeclaringType.FullName + "." + Name;
			}
			return Name;
		}
	}

	string INamedElement.ReflectionName
	{
		get
		{
			if (DeclaringType != null)
			{
				return DeclaringType.ReflectionName + "." + Name;
			}
			return Name;
		}
	}

	string INamedElement.Namespace => DeclaringType?.Namespace;

	protected FakeMember(ICompilation compilation)
	{
		this.compilation = compilation ?? throw new ArgumentNullException("compilation");
	}

	IEnumerable<IAttribute> IEntity.GetAttributes()
	{
		return EmptyList<IAttribute>.Instance;
	}

	bool IMember.Equals(IMember obj, TypeVisitor typeNormalization)
	{
		return Equals(obj);
	}

	public abstract IMember Specialize(TypeParameterSubstitution substitution);
}
