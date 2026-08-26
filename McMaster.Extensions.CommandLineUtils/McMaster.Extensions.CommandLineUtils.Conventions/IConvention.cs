namespace McMaster.Extensions.CommandLineUtils.Conventions;

public interface IConvention
{
	void Apply(ConventionContext context);
}
