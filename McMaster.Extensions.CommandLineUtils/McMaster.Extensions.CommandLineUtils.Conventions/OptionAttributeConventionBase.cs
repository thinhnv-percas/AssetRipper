using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public abstract class OptionAttributeConventionBase<TAttribute> where TAttribute : OptionAttributeBase
{
	private protected void AddOption(ConventionContext context, CommandOption option, PropertyInfo prop)
	{
		foreach (ValidationAttribute item in prop.GetCustomAttributes().OfType<ValidationAttribute>())
		{
			option.Validators.Add(new AttributeValidator(item));
		}
		if (option.OptionType == CommandOptionType.NoValue && prop.PropertyType != typeof(bool) && prop.PropertyType != typeof(bool?) && prop.PropertyType != typeof(bool[]))
		{
			throw new InvalidOperationException("Cannot specify CommandOptionType.NoValue unless the type is boolean.");
		}
		if (!string.IsNullOrEmpty(option.ShortName))
		{
			if (context.Application._shortOptions.TryGetValue(option.ShortName, out var value))
			{
				throw new InvalidOperationException(Strings.OptionNameIsAmbiguous(option.ShortName, prop, value));
			}
			context.Application._shortOptions.Add(option.ShortName, prop);
		}
		if (!string.IsNullOrEmpty(option.LongName))
		{
			if (context.Application._longOptions.TryGetValue(option.LongName, out var value2))
			{
				throw new InvalidOperationException(Strings.OptionNameIsAmbiguous(option.LongName, prop, value2));
			}
			context.Application._longOptions.Add(option.LongName, prop);
		}
		SetPropertyDelegate setter = ReflectionHelper.GetPropertySetter(prop);
		switch (option.OptionType)
		{
		case CommandOptionType.MultipleValue:
		{
			ICollectionParser collectionParser = CollectionParserProvider.Default.GetParser(prop.PropertyType, context.Application.ValueParsers);
			if (collectionParser == null)
			{
				throw new InvalidOperationException(Strings.CannotDetermineParserType(prop));
			}
			context.Application.OnParsingComplete(delegate
			{
				if (option.HasValue())
				{
					setter(context.ModelAccessor.GetModel(), collectionParser.Parse(option.LongName, option.Values));
				}
			});
			break;
		}
		case CommandOptionType.SingleValue:
		case CommandOptionType.SingleOrNoValue:
		{
			IValueParser parser = context.Application.ValueParsers.GetParser(prop.PropertyType);
			if (parser == null)
			{
				throw new InvalidOperationException(Strings.CannotDetermineParserType(prop));
			}
			context.Application.OnParsingComplete(delegate
			{
				if (option.HasValue())
				{
					setter(context.ModelAccessor.GetModel(), parser.Parse(option.LongName, option.Value(), context.Application.ValueParsers.ParseCulture));
				}
			});
			break;
		}
		case CommandOptionType.NoValue:
			context.Application.OnParsingComplete(delegate
			{
				if (prop.PropertyType == typeof(bool[]))
				{
					if (!option.HasValue())
					{
						setter(context.ModelAccessor.GetModel(), Util.EmptyArray<bool>());
					}
					bool[] array = new bool[option.Values.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = true;
					}
					setter(context.ModelAccessor.GetModel(), array);
				}
				else if (option.HasValue())
				{
					setter(context.ModelAccessor.GetModel(), option.HasValue());
				}
			});
			break;
		default:
			throw new NotImplementedException();
		}
	}

	private protected static void EnsureDoesNotHaveArgumentAttribute(PropertyInfo prop)
	{
		if (prop.GetCustomAttribute<ArgumentAttribute>() != null)
		{
			throw new InvalidOperationException(Strings.BothOptionAndArgumentAttributesCannotBeSpecified(prop));
		}
	}
}
