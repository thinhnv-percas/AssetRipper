using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class SubcommandPropertyConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		PropertyInfo property = context.ModelType.GetTypeInfo().GetProperty("Subcommand", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (property == null)
		{
			return;
		}
		SetPropertyDelegate setter = ReflectionHelper.GetPropertySetter(property);
		context.Application.OnParsingComplete(delegate(ParseResult r)
		{
			for (CommandLineApplication commandLineApplication = r.SelectedCommand; commandLineApplication != null; commandLineApplication = commandLineApplication.Parent)
			{
				if (commandLineApplication.Parent == context.Application)
				{
					if (commandLineApplication is IModelAccessor modelAccessor)
					{
						setter(context.ModelAccessor.GetModel(), modelAccessor.GetModel());
					}
					break;
				}
			}
		});
	}
}
