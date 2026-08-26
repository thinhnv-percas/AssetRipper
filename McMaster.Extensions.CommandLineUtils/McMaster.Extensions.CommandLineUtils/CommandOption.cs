using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils;

public class CommandOption
{
	[Obsolete("This property is obsolete and will be removed in a future version.")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public string Template { get; set; }

	public string ShortName { get; set; }

	public string LongName { get; set; }

	public string SymbolName { get; set; }

	public string ValueName { get; set; }

	public string Description { get; set; }

	public List<string> Values { get; } = new List<string>();

	public CommandOptionType OptionType { get; private set; }

	public bool ShowInHelpText { get; set; } = true;

	public bool Inherited { get; set; }

	public ICollection<IOptionValidator> Validators { get; } = new List<IOptionValidator>();

	public CommandOption(string template, CommandOptionType optionType)
	{
		Template = template;
		OptionType = optionType;
		string[] array = template.Split((optionType != CommandOptionType.SingleOrNoValue) ? new char[4] { ' ', '|', ':', '=' } : new char[6] { ' ', '|', ':', '=', '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (text.StartsWith("--"))
			{
				LongName = text.Substring(2);
			}
			else if (text.StartsWith("-"))
			{
				string text2 = text.Substring(1);
				if (text2.Length == 1 && !IsEnglishLetter(text2[0]))
				{
					SymbolName = text2;
				}
				else
				{
					ShortName = text2;
				}
			}
			else
			{
				if (!text.StartsWith("<") || !text.EndsWith(">"))
				{
					throw new ArgumentException("Invalid template pattern '" + template + "'", "template");
				}
				ValueName = text.Substring(1, text.Length - 2);
			}
		}
		if (string.IsNullOrEmpty(LongName) && string.IsNullOrEmpty(ShortName) && string.IsNullOrEmpty(SymbolName))
		{
			throw new ArgumentException("Invalid template pattern '" + template + "'", "template");
		}
	}

	internal CommandOption(CommandOptionType type)
	{
		OptionType = type;
	}

	public bool TryParse(string value)
	{
		switch (OptionType)
		{
		case CommandOptionType.MultipleValue:
			Values.Add(value);
			break;
		case CommandOptionType.SingleValue:
		case CommandOptionType.SingleOrNoValue:
			if (Values.Any())
			{
				return false;
			}
			Values.Add(value);
			break;
		case CommandOptionType.NoValue:
			if (value != null)
			{
				return false;
			}
			Values.Add(null);
			break;
		default:
			throw new NotImplementedException();
		}
		return true;
	}

	public bool HasValue()
	{
		return Values.Any();
	}

	public string Value()
	{
		if (!HasValue())
		{
			return null;
		}
		return Values[0];
	}

	internal string ToTemplateString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(SymbolName))
		{
			stringBuilder.Append('-').Append(SymbolName);
		}
		if (!string.IsNullOrEmpty(ShortName))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append('|');
			}
			stringBuilder.Append('-').Append(ShortName);
		}
		if (!string.IsNullOrEmpty(LongName))
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append('|');
			}
			stringBuilder.Append("--").Append(LongName);
		}
		if (!string.IsNullOrEmpty(ValueName) && OptionType != CommandOptionType.NoValue)
		{
			if (OptionType == CommandOptionType.SingleOrNoValue)
			{
				stringBuilder.Append("[:<").Append(ValueName).Append(">]");
			}
			else
			{
				stringBuilder.Append(" <").Append(ValueName).Append('>');
			}
		}
		return stringBuilder.ToString();
	}

	private bool IsEnglishLetter(char c)
	{
		if (c < 'a' || c > 'z')
		{
			if (c >= 'A')
			{
				return c <= 'Z';
			}
			return false;
		}
		return true;
	}
}
public class CommandOption<T> : CommandOption, IInternalCommandParamOfT
{
	private readonly List<T> _parsedValues = new List<T>();

	private readonly IValueParser<T> _valueParser;

	public T ParsedValue => _parsedValues.FirstOrDefault();

	public IReadOnlyList<T> ParsedValues => _parsedValues;

	public CommandOption(IValueParser<T> valueParser, string template, CommandOptionType optionType)
		: base(template, optionType)
	{
		_valueParser = valueParser ?? throw new ArgumentNullException("valueParser");
	}

	void IInternalCommandParamOfT.Parse(CultureInfo culture)
	{
		_parsedValues.Clear();
		for (int i = 0; i < base.Values.Count; i++)
		{
			_parsedValues.Add(_valueParser.Parse(base.LongName ?? base.ShortName ?? base.SymbolName, base.Values[i], culture));
		}
	}
}
