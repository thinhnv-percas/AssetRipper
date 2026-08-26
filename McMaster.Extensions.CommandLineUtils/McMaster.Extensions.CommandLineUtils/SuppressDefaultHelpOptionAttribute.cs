using System;

namespace McMaster.Extensions.CommandLineUtils;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class, Inherited = true)]
public sealed class SuppressDefaultHelpOptionAttribute : Attribute
{
}
