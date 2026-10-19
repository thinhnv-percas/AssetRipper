using Cpp2IL.Core.Utils.AsmResolver;

namespace AssetRipper.Tests;

/// <summary>
/// Which stub types lose <c>abstract</c>: the ones a decompiler will write as <c>struct</c>.
/// </summary>
/// <remarks>
/// il2cpp generates <c>__Il2CppFullySharedGenericType</c> and <c>__Il2CppFullySharedGenericStructType</c> in
/// <c>__Generated</c> as <c>abstract sealed</c> over <c>System.ValueType</c>, and C# has no abstract struct (CS0106).
/// The first of the two is not a value type by il2cpp's own flag, so a rule keyed on that flag fixed one and left the
/// other: the base type is what makes a decompiler write <c>struct</c>, so it is what decides.
/// </remarks>
public sealed class Il2CppAbstractValueTypeTests
{
	[TestCase("System.ValueType", "Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType")]
	[TestCase("System.ValueType", "UnityEngine.Vector3")]
	[TestCase("System.Enum", "UnityEngine.KeyCode")]
	public void ATypeOverValueTypeOrEnumIsAStruct(string baseType, string type)
	{
		Assert.That(AsmResolverAssemblyPopulator.IsValueTypeOver(baseType, type), Is.True);
	}

	[TestCase("System.ValueType", "System.Enum")]
	[TestCase("System.Object", "System.ValueType")]
	[TestCase("System.Object", "UnityEngine.MonoBehaviour")]
	[TestCase(null, "System.Object")]
	public void AnAbstractClassKeepsItsAbstract(string? baseType, string type)
	{
		// System.Enum is the one abstract type over System.ValueType that is a class; without the exception the
		// decompiled corlib would declare `struct Enum`, and every enum in every assembly derives from it.
		Assert.That(AsmResolverAssemblyPopulator.IsValueTypeOver(baseType, type), Is.False);
	}
}
