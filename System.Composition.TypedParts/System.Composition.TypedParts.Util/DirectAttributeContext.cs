using System.Collections.Generic;
using System.Composition.Convention;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.TypedParts.Util;

internal class DirectAttributeContext : AttributedModelProvider
{
	public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, MemberInfo member)
	{
		if ((object)reflectedType == null)
		{
			throw new ArgumentNullException("reflectedType");
		}
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (!(member is TypeInfo) && (object)member.DeclaringType != reflectedType)
		{
			return Microsoft.Internal.EmptyArray<Attribute>.Value;
		}
		return CustomAttributeExtensions.GetCustomAttributes(member, inherit: false);
	}

	public override IEnumerable<Attribute> GetCustomAttributes(Type reflectedType, ParameterInfo parameter)
	{
		if ((object)reflectedType == null)
		{
			throw new ArgumentNullException("reflectedType");
		}
		if (parameter == null)
		{
			throw new ArgumentNullException("parameter");
		}
		return CustomAttributeExtensions.GetCustomAttributes(parameter, inherit: false);
	}
}
