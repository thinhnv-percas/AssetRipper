#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

public class IntersectionType : AbstractType
{
	private readonly ReadOnlyCollection<IType> types;

	public ReadOnlyCollection<IType> Types => types;

	public override TypeKind Kind => TypeKind.Intersection;

	public override string Name
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (IType type in types)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" & ");
				}
				stringBuilder.Append(type.Name);
			}
			return stringBuilder.ToString();
		}
	}

	public override string ReflectionName
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (IType type in types)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(" & ");
				}
				stringBuilder.Append(type.ReflectionName);
			}
			return stringBuilder.ToString();
		}
	}

	public override bool? IsReferenceType
	{
		get
		{
			foreach (IType type in types)
			{
				bool? isReferenceType = type.IsReferenceType;
				if (isReferenceType.HasValue)
				{
					return isReferenceType.Value;
				}
			}
			return null;
		}
	}

	public override IEnumerable<IType> DirectBaseTypes => types;

	private IntersectionType(IType[] types)
	{
		Debug.Assert(types.Length >= 2);
		this.types = Array.AsReadOnly(types);
	}

	public static IType Create(IEnumerable<IType> types)
	{
		IType[] array = Enumerable.ToArray<IType>(Enumerable.Distinct<IType>(types));
		IType[] array2 = array;
		foreach (IType type in array2)
		{
			if (type == null)
			{
				throw new ArgumentNullException();
			}
		}
		if (array.Length == 0)
		{
			return SpecialType.UnknownType;
		}
		if (array.Length == 1)
		{
			return array[0];
		}
		return new IntersectionType(array);
	}

	public override int GetHashCode()
	{
		int num = 0;
		foreach (IType type in types)
		{
			num *= 7137517;
			num += type.GetHashCode();
		}
		return num;
	}

	public override bool Equals(IType other)
	{
		if (other is IntersectionType intersectionType && types.Count == intersectionType.types.Count)
		{
			for (int i = 0; i < types.Count; i = checked(i + 1))
			{
				if (!types[i].Equals(intersectionType.types[i]))
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	public override IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetMethods(this, FilterNonStatic(filter), options);
	}

	public override IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetMethods(this, typeArguments, filter, options);
	}

	public override IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetProperties(this, FilterNonStatic(filter), options);
	}

	public override IEnumerable<IField> GetFields(Predicate<IField> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetFields(this, FilterNonStatic(filter), options);
	}

	public override IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetEvents(this, FilterNonStatic(filter), options);
	}

	public override IEnumerable<IMember> GetMembers(Predicate<IMember> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetMembers(this, FilterNonStatic(filter), options);
	}

	public override IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter, GetMemberOptions options)
	{
		return GetMembersHelper.GetAccessors(this, FilterNonStatic(filter), options);
	}

	private static Predicate<T> FilterNonStatic<T>(Predicate<T> filter) where T : class, IMember
	{
		if (filter == null)
		{
			return (T member) => !member.IsStatic;
		}
		return (T member) => !member.IsStatic && filter(member);
	}
}
