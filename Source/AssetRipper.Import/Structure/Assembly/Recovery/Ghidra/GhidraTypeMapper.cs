using Cpp2IL.Core.Model.Contexts;
using LibCpp2IL.BinaryStructures;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Turns an Il2Cpp method into a C prototype that Ghidra can apply to the native function.
/// </summary>
/// <remarks>
/// Without this, Ghidra guesses parameter counts and types from the machine code, which is where most
/// of the noise in decompiled output comes from. Il2Cpp passes the instance as an implicit first
/// argument and a MethodInfo pointer as an implicit last one, so getting those right matters as much
/// as the declared parameters.
/// <para>
/// A wrong prototype is far worse than none. Ghidra locks parameter storage to whatever it is told,
/// so a mismatched return type can reduce a whole function body to a single return of an
/// uninitialised register. Everything whose size is not certain is therefore refused.
/// </para>
/// </remarks>
public static class GhidraTypeMapper
{
	/// <summary>
	/// One parameter of a prototype.
	/// </summary>
	public readonly record struct Parameter(Il2CppTypeEnum Type, string? Name, int Index);

	/// <summary>
	/// Builds a prototype for a method, or returns false when a type cannot be mapped safely.
	/// </summary>
	public static bool TryGetPrototype(MethodAnalysisContext method, string functionName, [NotNullWhen(true)] out string? prototype)
	{
		if (method.ReturnType is null)
		{
			prototype = null;
			return false;
		}

		Parameter[] parameters = new Parameter[method.Parameters.Count];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterAnalysisContext parameter = method.Parameters[i];
			if (parameter.ParameterType is null)
			{
				prototype = null;
				return false;
			}

			parameters[i] = new Parameter(parameter.ParameterType.Type, parameter.DefaultName, parameter.ParameterIndex);
		}

		return TryBuildPrototype(functionName, method.ReturnType.Type, method.IsStatic, parameters, out prototype);
	}

	/// <summary>
	/// Builds the prototype text for an Il2Cpp method.
	/// </summary>
	public static bool TryBuildPrototype(
		string functionName,
		Il2CppTypeEnum returnType,
		bool isStatic,
		IReadOnlyList<Parameter> parameters,
		[NotNullWhen(true)] out string? prototype)
	{
		prototype = null;

		if (!TryGetCTypeName(returnType, out string? returnTypeName))
		{
			return false;
		}

		StringBuilder builder = new();
		builder.Append(returnTypeName).Append(' ').Append(functionName).Append('(');

		bool first = true;

		if (!isStatic)
		{
			// The instance pointer is not part of the managed signature.
			builder.Append("void * __this");
			first = false;
		}

		foreach (Parameter parameter in parameters)
		{
			if (!TryGetCTypeName(parameter.Type, out string? parameterType))
			{
				return false;
			}

			if (!first)
			{
				builder.Append(", ");
			}
			first = false;

			builder.Append(parameterType).Append(' ').Append(SanitizeIdentifier(parameter.Name, parameter.Index));
		}

		// Il2Cpp appends the MethodInfo pointer to every compiled method.
		if (!first)
		{
			builder.Append(", ");
		}
		builder.Append("void * method)");

		prototype = builder.ToString();
		return true;
	}

	/// <summary>
	/// Maps an Il2Cpp type to a Ghidra built in type of the same size.
	/// </summary>
	/// <remarks>
	/// Reference types all become void pointers, which is correct for size and calling convention
	/// even though it loses the type. Value types are refused because their size depends on a layout
	/// that has not been given to Ghidra, and guessing it wrong corrupts the whole function.
	/// </remarks>
	public static bool TryGetCTypeName(Il2CppTypeEnum type, [NotNullWhen(true)] out string? name)
	{
		name = type switch
		{
			Il2CppTypeEnum.IL2CPP_TYPE_VOID => "void",
			Il2CppTypeEnum.IL2CPP_TYPE_BOOLEAN => "bool",
			Il2CppTypeEnum.IL2CPP_TYPE_CHAR => "ushort",
			Il2CppTypeEnum.IL2CPP_TYPE_I1 => "char",
			Il2CppTypeEnum.IL2CPP_TYPE_U1 => "byte",
			Il2CppTypeEnum.IL2CPP_TYPE_I2 => "short",
			Il2CppTypeEnum.IL2CPP_TYPE_U2 => "ushort",
			Il2CppTypeEnum.IL2CPP_TYPE_I4 => "int",
			Il2CppTypeEnum.IL2CPP_TYPE_U4 => "uint",
			Il2CppTypeEnum.IL2CPP_TYPE_I8 => "longlong",
			Il2CppTypeEnum.IL2CPP_TYPE_U8 => "ulonglong",
			Il2CppTypeEnum.IL2CPP_TYPE_R4 => "float",
			Il2CppTypeEnum.IL2CPP_TYPE_R8 => "double",
			// Pointer sized, so a void pointer keeps the size right on both 32 and 64 bit.
			Il2CppTypeEnum.IL2CPP_TYPE_I => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_U => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_PTR => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_BYREF => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_STRING => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_CLASS => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_OBJECT => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_ARRAY => "void *",
			Il2CppTypeEnum.IL2CPP_TYPE_SZARRAY => "void *",
			_ => null,
		};

		return name is not null;
	}

	/// <summary>
	/// Parameter names come from metadata and are not guaranteed to be valid C identifiers.
	/// </summary>
	public static string SanitizeIdentifier(string? name, int index)
	{
		if (string.IsNullOrEmpty(name))
		{
			return $"param_{index}";
		}

		StringBuilder builder = new(name.Length);
		foreach (char c in name)
		{
			builder.Append(char.IsAsciiLetterOrDigit(c) || c == '_' ? c : '_');
		}

		// A leading digit would not parse, and neither would an empty name.
		if (builder.Length == 0 || char.IsAsciiDigit(builder[0]))
		{
			builder.Insert(0, '_');
		}

		return builder.ToString();
	}
}
