using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ParentPropertyConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		PropertyInfo property = context.ModelType.GetTypeInfo().GetProperty("Parent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (property == null)
		{
			return;
		}
		SetPropertyDelegate setter = ReflectionHelper.GetPropertySetter(property);
		context.Application.OnParsingComplete(delegate(ParseResult r)
		{
			for (CommandLineApplication commandLineApplication = r.SelectedCommand; commandLineApplication != null; commandLineApplication = commandLineApplication.Parent)
			{
				if (context.Application == commandLineApplication)
				{
					if (commandLineApplication.Parent is IModelAccessor modelAccessor)
					{
						setter(context.ModelAccessor.GetModel(), modelAccessor.GetModel());
					}
					break;
				}
			}
		});
	}
}
