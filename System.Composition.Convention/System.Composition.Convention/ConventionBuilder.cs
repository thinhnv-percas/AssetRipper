using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Internal;

namespace System.Composition.Convention;

public class ConventionBuilder : AttributedModelProvider
{
	private static readonly List<object> s_emptyList = new List<object>();

	private readonly ReaderWriterLockSlim _lock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

	private readonly List<PartConventionBuilder> _conventions = new List<PartConventionBuilder>();

	private readonly Dictionary<MemberInfo, List<Attribute>> _memberInfos = new Dictionary<MemberInfo, List<Attribute>>();

	private readonly Dictionary<ParameterInfo, List<Attribute>> _parameters = new Dictionary<ParameterInfo, List<Attribute>>();

	public PartConventionBuilder<T> ForTypesDerivedFrom<T>()
	{
		PartConventionBuilder<T> partConventionBuilder = new PartConventionBuilder<T>((Type t) => IsDescendentOf(t, typeof(T)));
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	public PartConventionBuilder ForTypesDerivedFrom(Type type)
	{
		Microsoft.Internal.Requires.NotNull(type, "type");
		PartConventionBuilder partConventionBuilder = new PartConventionBuilder((Type t) => IsDescendentOf(t, type));
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	public PartConventionBuilder<T> ForType<T>()
	{
		PartConventionBuilder<T> partConventionBuilder = new PartConventionBuilder<T>((Type t) => (object)t == typeof(T));
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	public PartConventionBuilder ForType(Type type)
	{
		Microsoft.Internal.Requires.NotNull(type, "type");
		PartConventionBuilder partConventionBuilder = new PartConventionBuilder((Type t) => (object)t == type);
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	public PartConventionBuilder<T> ForTypesMatching<T>(Predicate<Type> typeFilter)
	{
		Microsoft.Internal.Requires.NotNull(typeFilter, "typeFilter");
		PartConventionBuilder<T> partConventionBuilder = new PartConventionBuilder<T>(typeFilter);
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	public PartConventionBuilder ForTypesMatching(Predicate<Type> typeFilter)
	{
		Microsoft.Internal.Requires.NotNull(typeFilter, "typeFilter");
		PartConventionBuilder partConventionBuilder = new PartConventionBuilder(typeFilter);
		_conventions.Add(partConventionBuilder);
		return partConventionBuilder;
	}

	private IEnumerable<Tuple<object, List<Attribute>>> EvaluateThisTypeInfoAgainstTheConvention(TypeInfo typeInfo)
	{
		List<Tuple<object, List<Attribute>>> list = new List<Tuple<object, List<Attribute>>>();
		List<Attribute> list2 = new List<Attribute>();
		List<Tuple<object, List<Attribute>>> configuredMembers = new List<Tuple<object, List<Attribute>>>();
		bool flag = false;
		bool flag2 = false;
		Type type = typeInfo.AsType();
		foreach (PartConventionBuilder item in _conventions.Where((PartConventionBuilder c) => c.SelectType(type)))
		{
			list2.AddRange(item.BuildTypeAttributes(type));
			flag |= item.BuildConstructorAttributes(type, ref configuredMembers);
			item.BuildPropertyAttributes(type, ref configuredMembers);
			item.BuildOnImportsSatisfiedNotification(type, ref configuredMembers);
			flag2 = true;
		}
		if (flag2 && !flag)
		{
			PartConventionBuilder.BuildDefaultConstructorAttributes(type, ref configuredMembers);
		}
		configuredMembers.Add(Tuple.Create((object)type.GetTypeInfo(), list2));
		return configuredMembers;
	}

	public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, MemberInfo member)
	{
		Microsoft.Internal.Requires.NotNull(member, "member");
		List<Attribute> value = null;
		if (member is TypeInfo typeInfo)
		{
			MemberInfo key = typeInfo;
			_lock.EnterReadLock();
			try
			{
				_memberInfos.TryGetValue(key, out value);
			}
			finally
			{
				_lock.ExitReadLock();
			}
			if (value == null)
			{
				_lock.EnterWriteLock();
				try
				{
					if (!_memberInfos.TryGetValue(key, out value))
					{
						foreach (Tuple<object, List<Attribute>> item2 in EvaluateThisTypeInfoAgainstTheConvention(typeInfo))
						{
							List<Attribute> item = item2.Item2;
							if (item == null)
							{
								continue;
							}
							if (item2.Item1 is MemberInfo memberInfo)
							{
								if ((object)memberInfo != null && (memberInfo.IsMemberInfoForConstructor() || memberInfo.IsMemberInfoForType() || memberInfo.IsMemberInfoForProperty() || memberInfo.IsMemberInfoForMethod()) && !_memberInfos.TryGetValue(memberInfo, out var _))
								{
									_memberInfos.Add(memberInfo, item2.Item2);
								}
								continue;
							}
							ParameterInfo parameterInfo = item2.Item1 as ParameterInfo;
							Microsoft.Internal.Assumes.NotNull(parameterInfo);
							if (!_parameters.TryGetValue(parameterInfo, out var _))
							{
								_parameters.Add(parameterInfo, item2.Item2);
							}
						}
					}
					_memberInfos.TryGetValue(key, out value);
				}
				finally
				{
					_lock.ExitWriteLock();
				}
			}
		}
		else if (member.IsMemberInfoForProperty() || member.IsMemberInfoForConstructor() || member.IsMemberInfoForMethod())
		{
			value = ReadMemberCustomAttributes(reflectedType, member);
		}
		IEnumerable<Attribute> enumerable = ((member is TypeInfo || (object)member.DeclaringType == reflectedType) ? member.GetCustomAttributes<Attribute>(inherit: false) : Enumerable.Empty<Attribute>());
		if (value != null)
		{
			return enumerable.Concat(value);
		}
		return enumerable;
	}

	private List<Attribute> ReadMemberCustomAttributes(Type reflectedType, MemberInfo member)
	{
		List<Attribute> value = null;
		bool flag = false;
		_lock.EnterReadLock();
		try
		{
			if (!_memberInfos.TryGetValue(member, out value))
			{
				if ((object)reflectedType != null && !_memberInfos.TryGetValue(member.DeclaringType.GetTypeInfo(), out value))
				{
					flag = true;
				}
				value = null;
			}
		}
		finally
		{
			_lock.ExitReadLock();
		}
		if (flag)
		{
			GetCustomAttributes(null, reflectedType.GetTypeInfo());
			_lock.EnterReadLock();
			try
			{
				_memberInfos.TryGetValue(member, out value);
			}
			finally
			{
				_lock.ExitReadLock();
			}
		}
		return value;
	}

	public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, ParameterInfo parameter)
	{
		Microsoft.Internal.Requires.NotNull(parameter, "parameter");
		IEnumerable<Attribute> customAttributes = parameter.GetCustomAttributes<Attribute>(inherit: false);
		List<Attribute> list = ReadParameterCustomAttributes(reflectedType, parameter);
		if (list != null)
		{
			return customAttributes.Concat(list);
		}
		return customAttributes;
	}

	private List<Attribute> ReadParameterCustomAttributes(Type reflectedType, ParameterInfo parameter)
	{
		List<Attribute> value = null;
		bool flag = false;
		_lock.EnterReadLock();
		try
		{
			if (!_parameters.TryGetValue(parameter, out value))
			{
				if ((object)reflectedType != null && !_memberInfos.TryGetValue(reflectedType.GetTypeInfo(), out value))
				{
					flag = true;
				}
				value = null;
			}
		}
		finally
		{
			_lock.ExitReadLock();
		}
		if (flag)
		{
			GetCustomAttributes(null, reflectedType.GetTypeInfo());
			_lock.EnterReadLock();
			try
			{
				_parameters.TryGetValue(parameter, out value);
			}
			finally
			{
				_lock.ExitReadLock();
			}
		}
		return value;
	}

	private static bool IsGenericDescendentOf(TypeInfo openType, TypeInfo baseType)
	{
		if ((object)openType.BaseType == null)
		{
			return false;
		}
		if ((object)openType.BaseType == baseType.AsType())
		{
			return true;
		}
		foreach (Type implementedInterface in openType.ImplementedInterfaces)
		{
			if (implementedInterface.IsConstructedGenericType && (object)implementedInterface.GetGenericTypeDefinition() == baseType.AsType())
			{
				return true;
			}
		}
		return IsGenericDescendentOf(openType.BaseType.GetTypeInfo(), baseType);
	}

	private static bool IsDescendentOf(Type type, Type baseType)
	{
		if ((object)type == baseType || (object)type == typeof(object) || (object)type == null)
		{
			return false;
		}
		TypeInfo typeInfo = type.GetTypeInfo();
		TypeInfo typeInfo2 = baseType.GetTypeInfo();
		if (typeInfo.IsGenericTypeDefinition)
		{
			return IsGenericDescendentOf(typeInfo, typeInfo2);
		}
		return typeInfo2.IsAssignableFrom(typeInfo);
	}
}
