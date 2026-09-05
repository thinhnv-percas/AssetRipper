using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>One parameter's name and rendered type, for the lifter's calling-convention setup and for printing a signature.</summary>
public readonly record struct MethodParameterRef(string Name, string Type);

/// <summary>
/// A method identified well enough to lift: where its code is, whether it takes an implicit <c>this</c>,
/// and what its parameters are called — everything <see cref="Arm64Lifter"/> needs to seed the register
/// state per the AAPCS64 calling convention (guide §11.2) and everything the address-based lookups in
/// <see cref="LiftContext.MethodsByVa"/>/<see cref="RegistrationLookup"/> need for exact-match callee names.
/// </summary>
public sealed class MethodRef
{
	public required string FullName { get; init; }
	public required string ModuleName { get; init; }
	public required bool IsStatic { get; init; }
	public required IReadOnlyList<MethodParameterRef> Parameters { get; init; }
	public required string ReturnType { get; init; }
	public required ulong Va { get; init; }

	public static MethodRef Create(Il2CppMetadata metadata, int methodIndex, string moduleName, ulong va)
	{
		Il2CppMethodDefinition method = metadata.Methods[methodIndex];
		List<MethodParameterRef> parameters = new(method.parameterCount);
		for (int i = 0; i < method.parameterCount; i++)
		{
			Il2CppParameterDefinition parameterDef = metadata.Parameters[method.parameterStart + i];
			parameters.Add(new MethodParameterRef(metadata.GetString(parameterDef.nameIndex), DescribeType(metadata, parameterDef.typeIndex)));
		}

		return new MethodRef
		{
			FullName = metadata.GetMethodName((uint)methodIndex),
			ModuleName = moduleName,
			IsStatic = method.IsStatic,
			Parameters = parameters,
			ReturnType = DescribeType(metadata, method.returnType),
			Va = va,
		};
	}

	private static string DescribeType(Il2CppMetadata metadata, int typeIndex)
	{
		Il2CppType type = metadata.ResolveType(typeIndex);
		return type.type is Il2CppTypeEnum.Class or Il2CppTypeEnum.ValueType
			? metadata.GetTypeDefName(type.datapoint)
			: type.type.ToString();
	}
}
