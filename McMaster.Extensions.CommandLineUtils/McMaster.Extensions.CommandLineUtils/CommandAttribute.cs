using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Class)]
public sealed class CommandAttribute : Attribute
{
	private string[] _names = Util.EmptyArray<string>();

	private bool? _clusterOptions;

	public string Name
	{
		get
		{
			if (_names.Length == 0)
			{
				return null;
			}
			return _names[0];
		}
		set
		{
			_names = new string[1] { value };
		}
	}

	public IEnumerable<string> Names => _names;

	public string FullName { get; set; }

	public string Description { get; set; }

	public bool ShowInHelpText { get; set; } = true;

	public string ExtendedHelpText { get; set; }

	public bool ThrowOnUnexpectedArgument { get; set; } = true;

	public bool AllowArgumentSeparator { get; set; }

	public ResponseFileHandling ResponseFileHandling { get; set; }

	public StringComparison OptionsComparison { get; set; } = StringComparison.Ordinal;

	public CultureInfo ParseCulture { get; set; } = CultureInfo.CurrentCulture;

	public bool ClusterOptions
	{
		get
		{
			return _clusterOptions ?? true;
		}
		set
		{
			_clusterOptions = value;
		}
	}

	public CommandAttribute()
	{
	}

	public CommandAttribute(string name)
	{
		Name = name;
	}

	public CommandAttribute(params string[] names)
	{
		_names = names;
	}

	internal void Configure(CommandLineApplication app)
	{
		app.Name = Name ?? app.Name;
		foreach (string item in Names.Skip(1))
		{
			app.AddName(item);
		}
		app.AllowArgumentSeparator = AllowArgumentSeparator;
		app.Description = Description;
		app.ExtendedHelpText = ExtendedHelpText;
		app.FullName = FullName;
		app.ResponseFileHandling = ResponseFileHandling;
		app.ShowInHelpText = ShowInHelpText;
		app.ThrowOnUnexpectedArgument = ThrowOnUnexpectedArgument;
		app.OptionsComparison = OptionsComparison;
		app.ValueParsers.ParseCulture = ParseCulture;
		if (_clusterOptions.HasValue)
		{
			app.ClusterOptions = _clusterOptions.Value;
		}
	}
}
