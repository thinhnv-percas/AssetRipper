using System.ComponentModel.DataAnnotations;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class CommandAttributeConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		context.ModelType.GetTypeInfo().GetCustomAttribute<CommandAttribute>()?.Configure(context.Application);
		foreach (CommandLineApplication command in context.Application.Commands)
		{
			if (command is IModelAccessor modelAccessor)
			{
				Apply(new ConventionContext(command, modelAccessor.GetModelType()));
			}
		}
		foreach (ValidationAttribute customAttribute in context.ModelType.GetTypeInfo().GetCustomAttributes<ValidationAttribute>())
		{
			context.Application.Validators.Add(new AttributeValidator(customAttribute));
		}
	}
}
