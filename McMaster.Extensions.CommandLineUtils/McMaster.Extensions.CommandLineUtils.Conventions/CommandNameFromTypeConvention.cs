using System;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class CommandNameFromTypeConvention : IConvention
{
	public void Apply(ConventionContext context)
	{
		if (string.IsNullOrEmpty(context.Application.Name) && !(context.ModelType == null))
		{
			string commandName = GetCommandName(context.ModelType.Name);
			if (!string.IsNullOrEmpty(commandName))
			{
				context.Application.Name = commandName;
			}
		}
	}

	internal static string GetCommandName(string typeName)
	{
		if (typeName.Length > "Command".Length && typeName.EndsWith("Command", StringComparison.Ordinal))
		{
			typeName = typeName.Substring(0, typeName.Length - "Command".Length);
		}
		return typeName.ToKebabCase();
	}
}
