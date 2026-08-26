using System;
using System.Linq;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class SubcommandAttributeConvention : IConvention
{
	private static readonly MethodInfo s_addSubcommandMethod = typeof(SubcommandAttributeConvention).GetRuntimeMethods().Single((MethodInfo m) => m.Name == "AddSubcommandImpl");

	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		foreach (SubcommandAttribute customAttribute in context.ModelType.GetTypeInfo().GetCustomAttributes<SubcommandAttribute>())
		{
			object[] parameters = new object[2] { context, customAttribute };
			Type[] types = customAttribute.Types;
			foreach (Type type in types)
			{
				MethodInfo methodInfo = s_addSubcommandMethod.MakeGenericMethod(type);
				try
				{
					methodInfo.Invoke(this, parameters);
				}
				catch (TargetInvocationException ex)
				{
					throw ex.InnerException ?? ex;
				}
			}
		}
	}

	private void AddSubcommandImpl<TSubCommand>(ConventionContext context, SubcommandAttribute subcommand) where TSubCommand : class
	{
		context.Application.Command<TSubCommand>(subcommand.Name, subcommand.Configure);
	}
}
