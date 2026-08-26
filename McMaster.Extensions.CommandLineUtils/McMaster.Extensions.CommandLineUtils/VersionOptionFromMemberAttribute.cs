using System;
using System.Reflection;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Class)]
public sealed class VersionOptionFromMemberAttribute : OptionAttributeBase
{
	public string MemberName { get; set; }

	public VersionOptionFromMemberAttribute()
		: this("--version")
	{
	}

	public VersionOptionFromMemberAttribute(string template)
	{
		base.Template = template;
	}

	internal CommandOption Configure(CommandLineApplication app, Type type, Func<object> targetInstanceFactory)
	{
		Func<string> shortFormVersionGetter = null;
		Func<string> longFormVersionGetter = null;
		if (MemberName != null)
		{
			MethodInfo[] methods = ReflectionHelper.GetPropertyOrMethod(type, MemberName);
			if (methods.Length == 0)
			{
				throw new InvalidOperationException(Strings.NoPropertyOrMethodFound(MemberName, type));
			}
			if (methods.Length > 1)
			{
				throw new AmbiguousMatchException("Multiple properties or methods match the name " + MemberName);
			}
			shortFormVersionGetter = () => methods[0].Invoke(targetInstanceFactory?.Invoke(), Util.EmptyArray<object>()) as string;
		}
		return app.VersionOption(base.Template, shortFormVersionGetter, longFormVersionGetter);
	}
}
