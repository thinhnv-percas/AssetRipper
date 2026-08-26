using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using McMaster.Extensions.CommandLineUtils.Abstractions;
using McMaster.Extensions.CommandLineUtils.Validation;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ArgumentAttributeConvention : IConvention
{
	public virtual void Apply(ConventionContext context)
	{
		if (context.ModelType == null)
		{
			return;
		}
		PropertyInfo[] properties = ReflectionHelper.GetProperties(context.ModelType);
		if (properties == null)
		{
			return;
		}
		SortedList<int, CommandArgument> sortedList = new SortedList<int, CommandArgument>();
		Dictionary<int, PropertyInfo> argPropOrder = new Dictionary<int, PropertyInfo>();
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			ArgumentAttribute customAttribute = propertyInfo.GetCustomAttribute<ArgumentAttribute>();
			if (customAttribute != null)
			{
				if (propertyInfo.GetCustomAttributes().OfType<OptionAttributeBase>().Any())
				{
					throw new InvalidOperationException(Strings.BothOptionAndArgumentAttributesCannotBeSpecified(propertyInfo));
				}
				AddArgument(propertyInfo, customAttribute, context, sortedList, argPropOrder);
			}
		}
		foreach (KeyValuePair<int, CommandArgument> item in sortedList)
		{
			if (context.Application.Arguments.Count > 0)
			{
				CommandArgument commandArgument = context.Application.Arguments[context.Application.Arguments.Count - 1];
				if (commandArgument.MultipleValues)
				{
					throw new InvalidOperationException(Strings.OnlyLastArgumentCanAllowMultipleValues(commandArgument.Name));
				}
			}
			context.Application.Arguments.Add(item.Value);
		}
	}

	private void AddArgument(PropertyInfo prop, ArgumentAttribute argumentAttr, ConventionContext convention, SortedList<int, CommandArgument> argOrder, Dictionary<int, PropertyInfo> argPropOrder)
	{
		CommandArgument argument = argumentAttr.Configure(prop);
		foreach (ValidationAttribute item in prop.GetCustomAttributes().OfType<ValidationAttribute>())
		{
			argument.Validators.Add(new AttributeValidator(item));
		}
		argument.MultipleValues = prop.PropertyType.IsArray || (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string));
		if (argPropOrder.TryGetValue(argumentAttr.Order, out var value))
		{
			throw new InvalidOperationException(Strings.DuplicateArgumentPosition(argumentAttr.Order, prop, value));
		}
		argPropOrder.Add(argumentAttr.Order, prop);
		argOrder.Add(argumentAttr.Order, argument);
		SetPropertyDelegate setter = ReflectionHelper.GetPropertySetter(prop);
		if (argument.MultipleValues)
		{
			ICollectionParser collectionParser = CollectionParserProvider.Default.GetParser(prop.PropertyType, convention.Application.ValueParsers);
			if (collectionParser == null)
			{
				throw new InvalidOperationException(Strings.CannotDetermineParserType(prop));
			}
			convention.Application.OnParsingComplete(delegate(ParseResult r)
			{
				if (argument.Values.Count != 0 && r.SelectedCommand is IModelAccessor modelAccessor)
				{
					setter(modelAccessor.GetModel(), collectionParser.Parse(argument.Name, argument.Values));
				}
			});
			return;
		}
		IValueParser parser = convention.Application.ValueParsers.GetParser(prop.PropertyType);
		if (parser == null)
		{
			throw new InvalidOperationException(Strings.CannotDetermineParserType(prop));
		}
		convention.Application.OnParsingComplete(delegate(ParseResult r)
		{
			if (argument.Values.Count != 0 && r.SelectedCommand is IModelAccessor modelAccessor)
			{
				setter(modelAccessor.GetModel(), parser.Parse(argument.Name, argument.Value, convention.Application.ValueParsers.ParseCulture));
			}
		});
	}
}
