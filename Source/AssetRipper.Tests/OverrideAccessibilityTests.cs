using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

namespace AssetRipper.Tests;

/// <summary>
/// Iteration 063: widening a base without its overrides (or an override without its base) is CS0507, a
/// declaration error that hides every body error in the assembly.
/// </summary>
public class OverrideAccessibilityTests
{
	/// <summary>Viewport.OnStartShow widened to protected internal; WinScreen's override must follow.</summary>
	[Test]
	public void AnOverrideInTheSameAssemblyFollowsAWidenedBase()
	{
		Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.FamilyOrAssembly, MethodAttributes.Family, sameAssembly: true, baseEditable: true),
			Is.EqualTo((MethodAttributes.FamilyOrAssembly, MethodAttributes.FamilyOrAssembly)));
	}

	/// <summary>A widened override pulls its base up with it, where the base is ours to edit.</summary>
	[Test]
	public void AWidenedOverrideWidensItsBase()
	{
		Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.Family, MethodAttributes.Public, sameAssembly: true, baseEditable: true),
			Is.EqualTo((MethodAttributes.Public, MethodAttributes.Public)));
	}

	/// <summary>Across assemblies, protected internal is overridden as protected, and that is already consistent.</summary>
	[Test]
	public void ProtectedInternalIsOverriddenAsProtectedFromAnotherAssembly()
	{
		Assert.Multiple(() =>
		{
			Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.FamilyOrAssembly, MethodAttributes.Family, sameAssembly: false, baseEditable: true),
				Is.EqualTo((MethodAttributes.FamilyOrAssembly, MethodAttributes.Family)));
			Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.FamilyOrAssembly, MethodAttributes.FamilyOrAssembly, sameAssembly: false, baseEditable: true),
				Is.EqualTo((MethodAttributes.FamilyOrAssembly, MethodAttributes.Family)));
		});
	}

	/// <summary>A framework base is not ours to change; the override states the base's accessibility.</summary>
	[Test]
	public void AFrameworkBaseIsNeverWidened()
	{
		Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.Family, MethodAttributes.FamilyOrAssembly, sameAssembly: false, baseEditable: false),
			Is.EqualTo((MethodAttributes.Family, MethodAttributes.Family)));
	}

	[Test]
	public void AConsistentPairIsLeftAlone()
	{
		Assert.That(OverrideAccessibility.Reconcile(MethodAttributes.Family, MethodAttributes.Family, sameAssembly: true, baseEditable: true),
			Is.EqualTo((MethodAttributes.Family, MethodAttributes.Family)));
	}
}
