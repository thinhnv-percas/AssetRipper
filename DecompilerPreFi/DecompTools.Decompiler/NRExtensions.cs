using System;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler;

public static class NRExtensions
{
	private class ContainsAnonTypeVisitor : TypeVisitor
	{
		public bool ContainsAnonType;

		public override IType VisitOtherType(IType type)
		{
			if (type.IsAnonymousType())
			{
				ContainsAnonType = true;
			}
			return base.VisitOtherType(type);
		}

		public override IType VisitTypeDefinition(ITypeDefinition type)
		{
			if (type.IsAnonymousType())
			{
				ContainsAnonType = true;
			}
			return base.VisitTypeDefinition(type);
		}
	}

	public static bool IsCompilerGenerated(this IEntity entity)
	{
		return entity?.HasAttribute(KnownAttribute.CompilerGenerated) ?? false;
	}

	public static bool IsCompilerGeneratedOrIsInCompilerGeneratedClass(this IEntity entity)
	{
		if (entity == null)
		{
			return false;
		}
		if (entity.IsCompilerGenerated())
		{
			return true;
		}
		return entity.DeclaringTypeDefinition.IsCompilerGeneratedOrIsInCompilerGeneratedClass();
	}

	public static bool HasGeneratedName(this IMember member)
	{
		return member.Name.StartsWith("<", StringComparison.Ordinal);
	}

	public static bool HasGeneratedName(this IType type)
	{
		return type.Name.StartsWith("<", StringComparison.Ordinal) || type.Name.Contains("<");
	}

	public static bool IsAnonymousType(this IType type)
	{
		if (type == null)
		{
			return false;
		}
		if (string.IsNullOrEmpty(type.Namespace) && type.HasGeneratedName() && (type.Name.Contains("AnonType") || type.Name.Contains("AnonymousType")))
		{
			return type.GetDefinition()?.IsCompilerGenerated() ?? false;
		}
		return false;
	}

	public static bool ContainsAnonymousType(this IType type)
	{
		ContainsAnonTypeVisitor containsAnonTypeVisitor = new ContainsAnonTypeVisitor();
		type.AcceptVisitor(containsAnonTypeVisitor);
		return containsAnonTypeVisitor.ContainsAnonType;
	}
}
