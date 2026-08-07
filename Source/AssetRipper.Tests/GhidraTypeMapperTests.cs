using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;
using LibCpp2IL.BinaryStructures;

namespace AssetRipper.Tests;

/// <summary>
/// Ghidra locks parameter storage to whatever prototype it is given, so a wrong one turns a whole
/// function body into a single return of an uninitialised register. These pin down that only types
/// of certain size are ever emitted.
/// </summary>
public sealed class GhidraTypeMapperTests
{
	private static GhidraTypeMapper.Parameter Param(Il2CppTypeEnum type, string? name = null, int index = 0)
	{
		return new GhidraTypeMapper.Parameter(type, name, index);
	}

	[Test]
	public void AStaticMethodTakesOnlyItsParametersAndTheMethodInfo()
	{
		bool built = GhidraTypeMapper.TryBuildPrototype("Foo_Bar", Il2CppTypeEnum.IL2CPP_TYPE_I4, true,
			[Param(Il2CppTypeEnum.IL2CPP_TYPE_R4, "speed")], null, out string? prototype);

		Assert.That(built, Is.True);
		Assert.That(prototype, Is.EqualTo("int Foo_Bar(float speed, void * method)"));
	}

	/// <summary>
	/// Il2Cpp passes the instance as an implicit first argument.
	/// </summary>
	[Test]
	public void AnInstanceMethodTakesTheInstancePointerFirst()
	{
		bool built = GhidraTypeMapper.TryBuildPrototype("Foo_Bar", Il2CppTypeEnum.IL2CPP_TYPE_VOID, false,
			[Param(Il2CppTypeEnum.IL2CPP_TYPE_BOOLEAN, "enabled")], null, out string? prototype);

		Assert.That(built, Is.True);
		Assert.That(prototype, Is.EqualTo("void Foo_Bar(void * __this, bool enabled, void * method)"));
	}

	[Test]
	public void AParameterlessStaticMethodStillTakesTheMethodInfo()
	{
		bool built = GhidraTypeMapper.TryBuildPrototype("Foo_Bar", Il2CppTypeEnum.IL2CPP_TYPE_VOID, true, [], null, out string? prototype);

		Assert.That(built, Is.True);
		Assert.That(prototype, Is.EqualTo("void Foo_Bar(void * method)"));
	}

	/// <summary>
	/// The size of a struct depends on a layout Ghidra has not been given, so guessing corrupts the
	/// argument registers.
	/// </summary>
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_VALUETYPE)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_VAR)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_TYPEDBYREF)]
	public void TypesOfUnknownSizeAreRefused(Il2CppTypeEnum type)
	{
		using (Assert.EnterMultipleScope())
		{
			Assert.That(GhidraTypeMapper.TryGetCTypeName(type, out _), Is.False);

			// Refused as a parameter...
			Assert.That(GhidraTypeMapper.TryBuildPrototype("F", Il2CppTypeEnum.IL2CPP_TYPE_VOID, true, [Param(type)], null, out _), Is.False);
			// ...and as a return type.
			Assert.That(GhidraTypeMapper.TryBuildPrototype("F", type, true, [], null, out _), Is.False);
		}
	}

	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_I4, "int")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_U4, "uint")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_I8, "longlong")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_R4, "float")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_R8, "double")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_BOOLEAN, "bool")]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_VOID, "void")]
	public void PrimitivesMapToTheMatchingBuiltInType(Il2CppTypeEnum type, string expected)
	{
		Assert.That(GhidraTypeMapper.TryGetCTypeName(type, out string? name), Is.True);
		Assert.That(name, Is.EqualTo(expected));
	}

	/// <summary>
	/// Reference types lose their identity but keep the right size, which is what the calling
	/// convention depends on.
	/// </summary>
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_STRING)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_CLASS)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_OBJECT)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_SZARRAY)]
	[TestCase(Il2CppTypeEnum.IL2CPP_TYPE_I)]
	public void ReferenceAndPointerSizedTypesBecomeVoidPointers(Il2CppTypeEnum type)
	{
		Assert.That(GhidraTypeMapper.TryGetCTypeName(type, out string? name), Is.True);
		Assert.That(name, Is.EqualTo("void *"));
	}

	/// <summary>
	/// Typing the instance pointer is what makes field accesses inside the body read as members.
	/// </summary>
	[Test]
	public void TheInstancePointerIsTypedWhenALayoutIsKnown()
	{
		bool built = GhidraTypeMapper.TryBuildPrototype("Foo_Bar", Il2CppTypeEnum.IL2CPP_TYPE_VOID, false, [], "PieceView", out string? prototype);

		Assert.That(built, Is.True);
		Assert.That(prototype, Is.EqualTo("void Foo_Bar(PieceView * __this, void * method)"));
	}

	/// <summary>
	/// An enum is a value type in the metadata but the ABI passes its underlying primitive, so
	/// refusing it would throw away methods that are perfectly safe to type.
	/// </summary>
	[Test]
	public void AnEnumIsRefusedWhenItIsOnlyKnownAsAValueType()
	{
		// Without the declaring type there is no way to reach the underlying primitive.
		Assert.That(GhidraTypeMapper.TryGetCTypeName(Il2CppTypeEnum.IL2CPP_TYPE_VALUETYPE, out _), Is.False);
	}

	[TestCase(null, 3, "param_3")]
	[TestCase("", 0, "param_0")]
	[TestCase("value", 0, "value")]
	[TestCase("has space", 0, "has_space")]
	[TestCase("2nd", 0, "_2nd")]
	public void ParameterNamesAreMadeValidCIdentifiers(string? name, int index, string expected)
	{
		Assert.That(GhidraTypeMapper.SanitizeIdentifier(name, index), Is.EqualTo(expected));
	}
}
