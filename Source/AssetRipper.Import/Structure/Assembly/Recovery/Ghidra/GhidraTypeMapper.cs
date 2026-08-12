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
	/// <param name="instanceTypeName">
	/// The struct registered for the declaring type, so field accesses off the instance decompile by
	/// name. Null falls back to an untyped pointer.
	/// </param>
	public static bool TryGetPrototype(MethodAnalysisContext method, string functionName, string? instanceTypeName, [NotNullWhen(true)] out string? prototype)
	{
		return TryGetPrototype(method, functionName, instanceTypeName, [], out prototype);
	}

	/// <param name="layouts">
	/// Known struct layouts. A value type with a complete layout can be named directly, which is what
	/// lets a method taking a Vector3 be typed at all.
	/// </param>
	public static bool TryGetPrototype(
		MethodAnalysisContext method,
		string functionName,
		string? instanceTypeName,
		Dictionary<TypeAnalysisContext, Il2CppTypeLayout.Layout> layouts,
		[NotNullWhen(true)] out string? prototype)
	{
		if (method.ReturnType is null)
		{
			prototype = null;
			return false;
		}

		if (!TryGetTypeName(method.ReturnType, layouts, out string? returnTypeName))
		{
			prototype = null;
			return false;
		}

		string[] parameterTypeNames = new string[method.Parameters.Count];
		Parameter[] parameters = new Parameter[method.Parameters.Count];
		for (int i = 0; i < parameters.Length; i++)
		{
			ParameterAnalysisContext parameter = method.Parameters[i];
			if (!TryGetTypeName(parameter.ParameterType, layouts, out string? parameterTypeName))
			{
				prototype = null;
				return false;
			}

			parameterTypeNames[i] = parameterTypeName;
			parameters[i] = new Parameter(default, parameter.DefaultName, parameter.ParameterIndex);
		}

		return TryBuildPrototypeFromNames(functionName, returnTypeName, method.IsStatic, parameterTypeNames, parameters, instanceTypeName, out prototype);
	}

	/// <summary>
	/// Builds the prototype text from already resolved type names.
	/// </summary>
	private static bool TryBuildPrototypeFromNames(
		string functionName,
		string returnTypeName,
		bool isStatic,
		IReadOnlyList<string> parameterTypeNames,
		IReadOnlyList<Parameter> parameters,
		string? instanceTypeName,
		[NotNullWhen(true)] out string? prototype)
	{
		StringBuilder builder = new();
		builder.Append(returnTypeName).Append(' ').Append(functionName).Append('(');

		bool first = true;

		if (!isStatic)
		{
			builder.Append(string.IsNullOrEmpty(instanceTypeName) ? "void *" : instanceTypeName + " *");
			builder.Append(" __this");
			first = false;
		}

		for (int i = 0; i < parameterTypeNames.Count; i++)
		{
			if (!first)
			{
				builder.Append(", ");
			}
			first = false;

			builder.Append(parameterTypeNames[i]).Append(' ').Append(SanitizeIdentifier(parameters[i].Name, parameters[i].Index));
		}

		if (!first)
		{
			builder.Append(", ");
		}
		builder.Append("void * method)");

		prototype = builder.ToString();
		return true;
	}

	/// <summary>
	/// Builds the prototype text for an Il2Cpp method.
	/// </summary>
	public static bool TryBuildPrototype(
		string functionName,
		Il2CppTypeEnum returnType,
		bool isStatic,
		IReadOnlyList<Parameter> parameters,
		string? instanceTypeName,
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
			// The instance pointer is not part of the managed signature. Naming its type is what makes
			// field accesses inside the body decompile as members rather than pointer arithmetic.
			builder.Append(string.IsNullOrEmpty(instanceTypeName) ? "void *" : instanceTypeName + " *");
			builder.Append(" __this");
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
	/// Maps a type, preferring a named struct for a value type whose layout is fully known.
	/// </summary>
	/// <remarks>
	/// The calling convention for a struct depends on its field types, not only on its size: on ARM64
	/// a struct of four floats goes in floating point registers while one of four integers does not.
	/// A layout with an unmapped field would therefore be classified wrongly, so only a complete one
	/// is used and everything else stays refused.
	/// </remarks>
	private static bool TryGetTypeName(
		TypeAnalysisContext? type,
		Dictionary<TypeAnalysisContext, Il2CppTypeLayout.Layout> layouts,
		[NotNullWhen(true)] out string? name)
	{
		// A reference type is a pointer whatever it points at, so naming the struct it points at costs
		// nothing in size or calling convention and is what lets a field read through a parameter come
		// out as a member rather than as arithmetic. Completeness is not required for the same reason:
		// an incomplete layout names the fields it knows and leaves the rest as padding, which is only
		// ever a question of readability here, never of where the argument goes.
		if (type is not null
			&& !type.IsValueType
			&& !type.IsEnumType
			&& layouts.TryGetValue(type, out Il2CppTypeLayout.Layout reference))
		{
			name = reference.StructName + " *";
			return true;
		}

		// A primitive is described in the metadata as a value type wrapping its own storage, so it has
		// a complete layout like any other struct. Mapping it to the built in type first keeps
		// System.Single a float rather than a one field struct that merely behaves like one.
		if (TryGetCTypeName(type, out name))
		{
			return true;
		}

		// A value type has to be complete before it can be passed by value, because the convention
		// depends on the field types and not only on the size.
		if (type is not null
			&& layouts.TryGetValue(type, out Il2CppTypeLayout.Layout layout)
			&& layout.IsComplete)
		{
			name = layout.StructName;
			return true;
		}

		return false;
	}

	/// <summary>
	/// Maps a type, resolving an enum to whatever primitive it is stored as.
	/// </summary>
	/// <remarks>
	/// An enum is a value type as far as the metadata is concerned, but it holds a single field named
	/// value__ whose type is what the ABI actually passes. Resolving that turns a large share of the
	/// methods that would otherwise be refused into ones with a usable prototype, at no risk, because
	/// the underlying type is always a primitive.
	/// </remarks>
	public static bool TryGetCTypeName(TypeAnalysisContext? type, [NotNullWhen(true)] out string? name)
	{
		if (type is null)
		{
			name = null;
			return false;
		}

		if (type.IsEnumType)
		{
			foreach (FieldAnalysisContext field in type.Fields)
			{
				if (!field.IsStatic && field.FieldType is not null)
				{
					return TryGetCTypeName(field.FieldType.Type, out name);
				}
			}

			name = null;
			return false;
		}

		// A constructed generic is refused on its raw type alone, because its size depends on which
		// arguments it was constructed with. That is only true of a value type: a List<int> is as much
		// a pointer as any other class, and refusing those costs far more methods than the value type
		// instantiations do.
		if (type.Type is Il2CppTypeEnum.IL2CPP_TYPE_GENERICINST && !type.IsValueType)
		{
			name = "void *";
			return true;
		}

		return TryGetCTypeName(type.Type, out name);
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
