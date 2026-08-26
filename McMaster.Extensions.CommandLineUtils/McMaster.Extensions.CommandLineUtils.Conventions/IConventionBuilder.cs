namespace McMaster.Extensions.CommandLineUtils.Conventions;

public interface IConventionBuilder
{
	IConventionBuilder AddConvention(IConvention convention);
}
