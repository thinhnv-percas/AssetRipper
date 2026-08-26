using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class AppNameFromEntryAssemblyConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.Application.Name == null && context.Application.Parent == null)
		{
			Assembly assembly = Assembly.GetEntryAssembly();
			if (assembly == null && context.ModelType != null)
			{
				assembly = context.ModelType.GetTypeInfo().Assembly;
			}
			if (assembly != null)
			{
				context.Application.Name = assembly.GetName().Name;
			}
		}
	}
}
