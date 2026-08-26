using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ArgumentAttribute : Attribute
{
	public int Order { get; set; }

	public string Name { get; set; }

	public bool ShowInHelpText { get; set; } = true;

	public string Description { get; set; }

	public ArgumentAttribute(int order)
		: this(order, null)
	{
	}

	public ArgumentAttribute(int order, string name)
		: this(order, name, null)
	{
	}

	public ArgumentAttribute(int order, string name, string description)
	{
		Order = order;
		Name = name;
		Description = description;
	}

	internal CommandArgument Configure(PropertyInfo prop)
	{
		return new CommandArgument
		{
			Name = (Name ?? prop.Name),
			Description = Description,
			ShowInHelpText = ShowInHelpText
		};
	}
}
