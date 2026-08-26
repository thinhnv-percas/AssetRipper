using System;
using System.ComponentModel;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
public sealed class SubcommandAttribute : Attribute
{
	public Type[] Types { get; private set; }

	[Obsolete("This property is obsolete and will be removed in a future version. The recommended replacement is to use CommandAttribute to set names for subcommands.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public string Name { get; set; }

	[Obsolete("This property is obsolete and will be replaced in a future version. The recommended replacement is Types.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public Type CommandType
	{
		get
		{
			if (Types.Length == 0)
			{
				return null;
			}
			return Types[0];
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Types = new Type[1] { value };
		}
	}

	[Obsolete("[Subcommand(string, Type)] is obsolete and will be removed in a future version. The recommended alternative is [Subcommand(Type)]. See https://github.com/natemcmaster/CommandLineUtils/issues/139 for details.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public SubcommandAttribute(string name, Type commandType)
	{
		CommandType = commandType;
		Name = name;
	}

	public SubcommandAttribute(params Type[] subcommands)
	{
		if (subcommands == null)
		{
			throw new ArgumentNullException("subcommands");
		}
		if (subcommands.Length == 0)
		{
			throw new ArgumentException("Value cannot be an empty collection.", "subcommands");
		}
		Types = subcommands;
	}

	internal void Configure(CommandLineApplication app)
	{
		if (!string.IsNullOrEmpty(Name))
		{
			app.Name = Name;
		}
	}
}
