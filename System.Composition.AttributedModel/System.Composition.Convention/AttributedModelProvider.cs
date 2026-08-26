using System.Collections.Generic;
using System.Reflection;

namespace System.Composition.Convention;

public abstract class AttributedModelProvider
{
	public abstract IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, MemberInfo member);

	public abstract IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, ParameterInfo parameter);
}
