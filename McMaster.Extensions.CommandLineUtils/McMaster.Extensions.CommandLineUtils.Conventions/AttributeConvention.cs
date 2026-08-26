using System.Linq;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class AttributeConvention : IConvention
{
	public void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		foreach (IConvention item in context.ModelType.GetTypeInfo().GetCustomAttributes().OfType<IConvention>())
		{
			item.Apply(context);
		}
		MemberInfo[] members = ReflectionHelper.GetMembers(context.ModelType);
		foreach (MemberInfo memberInfo in members)
		{
			foreach (IMemberConvention item2 in memberInfo.GetCustomAttributes().OfType<IMemberConvention>())
			{
				item2.Apply(context, memberInfo);
			}
		}
	}
}
