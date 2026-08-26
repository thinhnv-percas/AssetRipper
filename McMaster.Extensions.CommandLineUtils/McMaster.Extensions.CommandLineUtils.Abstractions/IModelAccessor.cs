using System;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

public interface IModelAccessor
{
	Type GetModelType();

	object GetModel();
}
