namespace McMaster.Extensions.CommandLineUtils.Validation;

public interface IValidationBuilder
{
	void Use(IValidator validator);
}
public interface IValidationBuilder<T> : IValidationBuilder
{
}
