using System;
using McMaster.Extensions.CommandLineUtils.Abstractions;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public class ConventionContext
{
	public CommandLineApplication Application { get; private set; }

	public Type ModelType { get; private set; }

	public IModelAccessor ModelAccessor => Application as IModelAccessor;

	public ConventionContext(CommandLineApplication application, Type modelType)
	{
		Application = application ?? throw new ArgumentNullException("application");
		ModelType = modelType;
	}
}
