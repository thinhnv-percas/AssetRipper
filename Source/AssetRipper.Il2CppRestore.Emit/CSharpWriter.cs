using AssetRipper.Il2CppRestore.Lift;
using AssetRipper.Il2CppRestore.Lift.Registration;
using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Emit;

/// <summary>
/// Writes one type as readable C# — signatures straight from metadata, method bodies from
/// <see cref="LiftEnvironment.Lifter"/> when a binary is available (guide §12.1).
/// </summary>
/// <remarks>
/// No <c>//#DECOMPILER_SEPARATOR#</c>-style string markers between files: that convention exists only
/// because a tool built around shelling out to <c>ILSpy.exe</c> has to reassemble its stdout somehow.
/// Writing straight to a <see cref="TextWriter"/> per type needs none of that.
/// </remarks>
public sealed class CSharpWriter
{
	private readonly Il2CppMetadata _metadata;
	private readonly LiftEnvironment? _lift;
	private readonly string _unityVersion;
	private readonly bool _structDbIsApproximate;

	public CSharpWriter(Il2CppMetadata metadata, LiftEnvironment? lift, string unityVersion, bool structDbIsApproximate)
	{
		_metadata = metadata;
		_lift = lift;
		_unityVersion = unityVersion;
		_structDbIsApproximate = structDbIsApproximate;
	}

	public void WriteType(int typeDefIndex, string moduleName, TextWriter writer)
	{
		Il2CppTypeDefinition td = _metadata.TypeDefs[typeDefIndex];

		writer.WriteLine($"// Assembly: {moduleName}");
		if (_structDbIsApproximate)
		{
			writer.WriteLine($"// WARNING: struct DB is an approximation for {_unityVersion} — field names inside method bodies may be wrong.");
		}

		string ns = _metadata.GetString(td.namespaceIndex);
		bool hasNamespace = ns.Length > 0;
		if (hasNamespace)
		{
			writer.WriteLine($"namespace {ns}");
			writer.WriteLine("{");
		}

		writer.WriteLine($"{Modifiers(td)} {Kind(td)} {Name(td)}{BaseList(typeDefIndex, td)}");
		writer.WriteLine("{");

		foreach ((int fieldIndex, Il2CppFieldDefinition field) in Fields(td))
		{
			Il2CppType fieldType = _metadata.ResolveType(field.typeIndex);
			writer.WriteLine($"\t{FieldModifiers(fieldType)} {TypeName(fieldType)} {_metadata.GetString(field.nameIndex)};   // token 0x{field.token:X}, field #{fieldIndex}");
		}

		foreach ((int methodIndex, Il2CppMethodDefinition method) in Methods(td))
		{
			ulong va = _lift?.Addresses.GetMethodPointer(moduleName, method) ?? 0;
			writer.WriteLine($"\t// token: 0x{method.token:X}" + (va != 0 ? $"  VA: 0x{va:X}" : "  (no code — abstract, extern, or stripped)"));
			writer.WriteLine($"\t{MethodModifiers(method)} {ReturnType(method)} {_metadata.GetString(method.nameIndex)}({Parameters(method)})");
			writer.WriteLine("\t{");
			foreach (string line in LiftBody(methodIndex, method, moduleName, va))
			{
				writer.WriteLine($"\t\t{line}");
			}
			writer.WriteLine("\t}");
		}

		writer.WriteLine("}");
		if (hasNamespace)
		{
			writer.WriteLine("}");
		}
	}

	private IEnumerable<(int Index, Il2CppFieldDefinition Field)> Fields(Il2CppTypeDefinition td)
	{
		for (int i = 0; i < td.field_count; i++)
		{
			int index = td.fieldStart + i;
			yield return (index, _metadata.Fields[index]);
		}
	}

	private IEnumerable<(int Index, Il2CppMethodDefinition Method)> Methods(Il2CppTypeDefinition td)
	{
		for (int i = 0; i < td.method_count; i++)
		{
			int index = td.methodStart + i;
			yield return (index, _metadata.Methods[index]);
		}
	}

	private IEnumerable<string> LiftBody(int methodIndex, Il2CppMethodDefinition method, string moduleName, ulong va)
	{
		if (_lift is null)
		{
			yield return "// Not lifted: no binary was provided (fields-only mode). See DummyAssemblyBuilder for a compile-time-only stand-in.";
			yield break;
		}
		if (va == 0)
		{
			yield return method.IsAbstract ? "// abstract" : "// No code at this address — extern, or stripped from the build.";
			yield break;
		}
		if (!_lift.FunctionBoundaries.TryGetValue(va, out ulong nextVa))
		{
			yield return "// Could not estimate this function's length (no boundary found after it).";
			yield break;
		}

		long start = _lift.Image.MapVaToOffset(va);
		if (start < 0)
		{
			yield return $"// VA 0x{va:X} does not map into any loaded segment of this binary.";
			yield break;
		}

		int length = (int)Math.Min(nextVa - va, (ulong)(_lift.Image.Data.Length - start));
		if (length <= 0)
		{
			yield return "// Zero-length function body.";
			yield break;
		}

		IReadOnlyList<DecodedInstruction> instructions = _lift.Lifter.Disassemble(_lift.Image.Data.Slice((int)start, length), va);

		MethodRef current = MethodRef.Create(_metadata, methodIndex, moduleName, va);
		LiftContext context = new()
		{
			Metadata = _metadata,
			Image = _lift.Image,
			Structs = _lift.Structs,
			Usages = _lift.Usages,
			MethodsByVa = _lift.MethodsByVa,
			Current = current,
		};
		foreach ((ulong helperVa, string helperName) in _lift.KnownHelpers)
		{
			context.KnownHelpers[helperVa] = helperName;
		}

		List<Statement> statements = _lift.Lifter.Lift(instructions, context);
		foreach (Statement statement in statements)
		{
			yield return statement.ToLine();
		}
	}

	private static string Modifiers(Il2CppTypeDefinition td)
	{
		TypeAttributesSubset attrs = (TypeAttributesSubset)td.flags;
		List<string> modifiers = [];
		if ((attrs & TypeAttributesSubset.Public) != 0)
		{
			modifiers.Add("public");
		}
		if (td.IsValueType && !td.IsEnumType)
		{
			// Structs have no further modifiers worth surfacing here.
		}
		else if ((attrs & TypeAttributesSubset.Abstract) != 0 && (attrs & TypeAttributesSubset.Sealed) != 0)
		{
			modifiers.Add("static");
		}
		else if ((attrs & TypeAttributesSubset.Sealed) != 0)
		{
			modifiers.Add("sealed");
		}
		else if ((attrs & TypeAttributesSubset.Abstract) != 0)
		{
			modifiers.Add("abstract");
		}
		return modifiers.Count == 0 ? "internal" : string.Join(' ', modifiers);
	}

	private static string Kind(Il2CppTypeDefinition td) => td.IsEnumType ? "enum" : td.IsValueType ? "struct" : "class";

	private string Name(Il2CppTypeDefinition td) => _metadata.GetString(td.nameIndex);

	private string BaseList(int typeDefIndex, Il2CppTypeDefinition td)
	{
		List<string> baseTypes = [];
		if (td.parentIndex >= 0)
		{
			Il2CppType parent = _metadata.ResolveType(td.parentIndex);
			string parentName = TypeName(parent);
			if (parentName is not ("object" or "System.Object" or "System.ValueType" or "System.Enum"))
			{
				baseTypes.Add(parentName);
			}
		}
		return baseTypes.Count == 0 ? "" : $" : {string.Join(", ", baseTypes)}";
	}

	private string FieldModifiers(Il2CppType fieldType) =>
		((FieldAttributesSubset)fieldType.attrs & FieldAttributesSubset.Public) != 0 ? "public" : "private";

	private string MethodModifiers(Il2CppMethodDefinition method)
	{
		List<string> modifiers = ["public"];
		if (method.IsStatic)
		{
			modifiers.Add("static");
		}
		if (method.IsAbstract)
		{
			modifiers.Add("abstract");
		}
		return string.Join(' ', modifiers);
	}

	private string ReturnType(Il2CppMethodDefinition method) => TypeName(_metadata.ResolveType(method.returnType));

	private string Parameters(Il2CppMethodDefinition method)
	{
		List<string> parts = [];
		for (int i = 0; i < method.parameterCount; i++)
		{
			Il2CppParameterDefinition p = _metadata.Parameters[method.parameterStart + i];
			parts.Add($"{TypeName(_metadata.ResolveType(p.typeIndex))} {_metadata.GetString(p.nameIndex)}");
		}
		return string.Join(", ", parts);
	}

	private string TypeName(Il2CppType type) => type.type switch
	{
		Il2CppTypeEnum.Void => "void",
		Il2CppTypeEnum.Boolean => "bool",
		Il2CppTypeEnum.Char => "char",
		Il2CppTypeEnum.I1 => "sbyte",
		Il2CppTypeEnum.U1 => "byte",
		Il2CppTypeEnum.I2 => "short",
		Il2CppTypeEnum.U2 => "ushort",
		Il2CppTypeEnum.I4 => "int",
		Il2CppTypeEnum.U4 => "uint",
		Il2CppTypeEnum.I8 => "long",
		Il2CppTypeEnum.U8 => "ulong",
		Il2CppTypeEnum.R4 => "float",
		Il2CppTypeEnum.R8 => "double",
		Il2CppTypeEnum.String => "string",
		Il2CppTypeEnum.Object => "object",
		Il2CppTypeEnum.Class or Il2CppTypeEnum.ValueType or Il2CppTypeEnum.Enum => _metadata.GetTypeDefName(type.datapoint),
		Il2CppTypeEnum.SzArray or Il2CppTypeEnum.Array => $"{TypeName(_metadata.ResolveType(type.datapoint))}[]",
		_ => "object",
	};

	[Flags]
	private enum TypeAttributesSubset : uint
	{
		Public = 0x1,
		Sealed = 0x100,
		Abstract = 0x80,
	}

	[Flags]
	private enum FieldAttributesSubset : ushort
	{
		Public = 0x6,
	}
}
