using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils.Conventions;

public interface IMemberConvention
{
	void Apply(ConventionContext context, MemberInfo member);
}
