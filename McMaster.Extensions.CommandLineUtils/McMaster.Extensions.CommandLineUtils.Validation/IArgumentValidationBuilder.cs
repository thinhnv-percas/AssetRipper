namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface IArgumentValidationBuilder : IValidationBuilder
{
	void Use(IArgumentValidator validator);
}
public interface IArgumentValidationBuilder<T> : IArgumentValidationBuilder, IValidationBuilder, IValidationBuilder<T>
{
}
