using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils;

public class CommandArgument
{
	public string Name { get; set; }

	public bool ShowInHelpText { get; set; } = true;

	public string Description { get; set; }

	public List<string> Values { get; private set; }

	public bool MultipleValues { get; set; }

	public string Value => Values.FirstOrDefault();

	public ICollection<IArgumentValidator> Validators { get; } = new List<IArgumentValidator>();

	public CommandArgument()
	{
		Values = new List<string>();
	}
}
public class CommandArgument<T> : CommandArgument, IInternalCommandParamOfT
{
	private readonly List<T> _parsedValues = new List<T>();

	private readonly IValueParser<T> _valueParser;

	public T ParsedValue => _parsedValues.FirstOrDefault();

	public IReadOnlyList<T> ParsedValues => _parsedValues;

	public CommandArgument(IValueParser<T> valueParser)
	{
		_valueParser = valueParser ?? throw new ArgumentNullException("valueParser");
	}

	void IInternalCommandParamOfT.Parse(CultureInfo culture)
	{
		_parsedValues.Clear();
		for (int i = 0; i < base.Values.Count; i++)
		{
			_parsedValues.Add(_valueParser.Parse(base.Name, base.Values[i], culture));
		}
	}
}
