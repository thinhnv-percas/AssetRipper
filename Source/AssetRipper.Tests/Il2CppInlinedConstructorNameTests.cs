using Cpp2IL.Core;

namespace AssetRipper.Tests;

/// <summary>
/// Which field a constructor parameter is the value of, when il2cpp has inlined the constructor into its caller.
/// </summary>
/// <remarks>
/// SandOut's <c>GlobalScopeContextInstaller(Transform parentTransform)</c> stores into <c>_parentTransform</c>. Matching
/// names exactly found no constructor, the allocation fell back to null, and <c>GameBootstrapper.Initialize</c> threw on
/// the first frame writing a field of nothing.
/// </remarks>
public sealed class Il2CppInlinedConstructorNameTests
{
	[TestCase("parentTransform", "parentTransform")]
	[TestCase("_parentTransform", "parentTransform")]
	[TestCase("m_Value", "value")]
	[TestCase("m_value", "value")]
	[TestCase("mCount", "count")]
	public void TheConventionalPrefixIsNotPartOfTheName(string field, string parameter)
	{
		Assert.That(IlGenerator.NamesTheSameMember(field, parameter), Is.True);
	}

	[TestCase("_parent", "parentTransform")]
	[TestCase("_value", "values")]
	[TestCase("mode", "ode")]
	[TestCase("_", "")]
	[TestCase("m_Value", "Count")]
	public void DifferentNamesStayDifferent(string field, string parameter)
	{
		Assert.That(IlGenerator.NamesTheSameMember(field, parameter), Is.False);
	}
}
