namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface IOptionValidationBuilder : IValidationBuilder
{
	void Use(IOptionValidator validator);
}
public interface IOptionValidationBuilder<T> : IOptionValidationBuilder, IValidationBuilder, IValidationBuilder<T>
{
}
