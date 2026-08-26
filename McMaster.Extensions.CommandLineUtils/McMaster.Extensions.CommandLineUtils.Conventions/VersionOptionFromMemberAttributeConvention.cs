using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class VersionOptionFromMemberAttributeConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (!(context.ModelType == null))
		{
			context.ModelType.GetTypeInfo().GetCustomAttribute<VersionOptionFromMemberAttribute>()?.Configure(context.Application, context.ModelType, context.ModelAccessor.GetModel);
		}
	}
}
