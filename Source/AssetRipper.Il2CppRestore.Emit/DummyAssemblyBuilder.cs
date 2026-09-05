using AssetRipper.Il2CppRestore.Metadata;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace AssetRipper.Il2CppRestore.Emit;

/// <summary>
/// Builds a set of loadable-but-empty .dll files from metadata alone (guide §9 / §14's "fields only"
/// mode) — a type resolver, something dnSpy/ILSpy can open, and a compile-time reference set. Method
/// bodies are a single <c>throw null;</c>; the human-readable, lifted source comes from
/// <see cref="CSharpWriter"/> instead, once a binary is available to lift from.
/// </summary>
public sealed class DummyAssemblyBuilder
{
	private readonly Il2CppMetadata _metadata;
	private readonly Dictionary<int, TypeDefinition> _byTypeDefIndex = [];

	public DummyAssemblyBuilder(Il2CppMetadata metadata)
	{
		_metadata = metadata;
	}

	public List<AssemblyDefinition> Build()
	{
		List<AssemblyDefinition> assemblies = [];

		// Pass 1: shells. A type can inherit from another declared later in the file, so every
		// TypeDefinition has to exist (even empty) before pass 2 wires up any relationship between them.
		foreach (Il2CppImageDefinition image in _metadata.Images)
		{
			string imageName = _metadata.GetString(image.nameIndex);
			AssemblyDefinition assembly = AssemblyDefinition.CreateAssembly(
				new AssemblyNameDefinition(Path.GetFileNameWithoutExtension(imageName), new Version(0, 0, 0, 0)),
				imageName, ModuleKind.Dll);
			assemblies.Add(assembly);

			for (int i = 0; i < image.typeCount; i++)
			{
				int typeDefIndex = image.typeStart + i;
				Il2CppTypeDefinition typeDef = _metadata.TypeDefs[typeDefIndex];
				TypeDefinition type = new(
					_metadata.GetString(typeDef.namespaceIndex),
					_metadata.GetString(typeDef.nameIndex),
					(TypeAttributes)typeDef.flags);
				_byTypeDefIndex[typeDefIndex] = type;

				// A nested type must NOT also be added to its module's top-level Types, or Cecil throws
				// when writing the assembly out — it belongs only under its declaring type's NestedTypes.
				if (typeDef.declaringTypeIndex < 0)
				{
					assembly.MainModule.Types.Add(type);
				}
			}
		}

		// Pass 2: relationships and members.
		foreach ((int typeDefIndex, TypeDefinition type) in _byTypeDefIndex)
		{
			Il2CppTypeDefinition typeDef = _metadata.TypeDefs[typeDefIndex];
			ModuleDefinition module = type.Module;

			if (typeDef.declaringTypeIndex >= 0)
			{
				int outerTypeDefIndex = _metadata.GetTypeDefIndexFromTypeIndex(typeDef.declaringTypeIndex);
				if (_byTypeDefIndex.TryGetValue(outerTypeDefIndex, out TypeDefinition? outer))
				{
					outer.NestedTypes.Add(type);
				}
			}

			if (typeDef.parentIndex >= 0)
			{
				type.BaseType = ResolveTypeRef(module, _metadata.ResolveType(typeDef.parentIndex));
			}

			for (int i = 0; i < typeDef.interfaces_count; i++)
			{
				int interfaceTypeIndex = _metadata.InterfaceIndices[typeDef.interfacesStart + i];
				type.Interfaces.Add(new InterfaceImplementation(ResolveTypeRef(module, _metadata.ResolveType(interfaceTypeIndex))));
			}

			AddFields(type, module, typeDef);
			AddMethods(type, module, typeDef);
		}

		return assemblies;
	}

	private void AddFields(TypeDefinition type, ModuleDefinition module, Il2CppTypeDefinition typeDef)
	{
		for (int i = 0; i < typeDef.field_count; i++)
		{
			int fieldIndex = typeDef.fieldStart + i;
			Il2CppFieldDefinition fieldDef = _metadata.Fields[fieldIndex];
			Il2CppType fieldType = _metadata.ResolveType(fieldDef.typeIndex);

			FieldDefinition field = new(
				_metadata.GetString(fieldDef.nameIndex),
				(FieldAttributes)fieldType.attrs,
				ResolveTypeRef(module, fieldType));

			// A literal needs Constant set explicitly or ILSpy/dnSpy render it as if it had none.
			if (_metadata.TryGetFieldDefaultValue(fieldIndex, out object? constant))
			{
				field.Constant = constant;
			}

			type.Fields.Add(field);
		}
	}

	private void AddMethods(TypeDefinition type, ModuleDefinition module, Il2CppTypeDefinition typeDef)
	{
		for (int i = 0; i < typeDef.method_count; i++)
		{
			Il2CppMethodDefinition methodDef = _metadata.Methods[typeDef.methodStart + i];
			MethodDefinition method = new(
				_metadata.GetString(methodDef.nameIndex),
				(MethodAttributes)methodDef.flags,
				ResolveTypeRef(module, _metadata.ResolveType(methodDef.returnType)));

			for (int p = 0; p < methodDef.parameterCount; p++)
			{
				Il2CppParameterDefinition parameterDef = _metadata.Parameters[methodDef.parameterStart + p];
				method.Parameters.Add(new ParameterDefinition(
					_metadata.GetString(parameterDef.nameIndex),
					ParameterAttributes.None,
					ResolveTypeRef(module, _metadata.ResolveType(parameterDef.typeIndex))));
			}

			if (!method.IsAbstract && !methodDef.IsPInvokeImpl)
			{
				ILProcessor il = method.Body.GetILProcessor();
				il.Append(il.Create(OpCodes.Ldnull));
				il.Append(il.Create(OpCodes.Throw));
			}

			// The method's native address (when a binary is available) is surfaced as an
			// "// RVA: 0x.. VA: 0x.." comment by Il2CppRestore.Emit.CSharpWriter instead of as a custom
			// attribute here: a synthetic, unresolvable attribute type risks Mono.Cecil failing to write
			// a valid token for it, which is a worse failure mode than simply not decorating the dummy dll.
			type.Methods.Add(method);
		}
	}

	private TypeReference ResolveTypeRef(ModuleDefinition module, Il2CppType type)
	{
		TypeReference? reference = type.type switch
		{
			Il2CppTypeEnum.Void => module.TypeSystem.Void,
			Il2CppTypeEnum.Boolean => module.TypeSystem.Boolean,
			Il2CppTypeEnum.Char => module.TypeSystem.Char,
			Il2CppTypeEnum.I1 => module.TypeSystem.SByte,
			Il2CppTypeEnum.U1 => module.TypeSystem.Byte,
			Il2CppTypeEnum.I2 => module.TypeSystem.Int16,
			Il2CppTypeEnum.U2 => module.TypeSystem.UInt16,
			Il2CppTypeEnum.I4 => module.TypeSystem.Int32,
			Il2CppTypeEnum.U4 => module.TypeSystem.UInt32,
			Il2CppTypeEnum.I8 => module.TypeSystem.Int64,
			Il2CppTypeEnum.U8 => module.TypeSystem.UInt64,
			Il2CppTypeEnum.R4 => module.TypeSystem.Single,
			Il2CppTypeEnum.R8 => module.TypeSystem.Double,
			Il2CppTypeEnum.String => module.TypeSystem.String,
			Il2CppTypeEnum.I => module.TypeSystem.IntPtr,
			Il2CppTypeEnum.U => module.TypeSystem.UIntPtr,
			Il2CppTypeEnum.Object => module.TypeSystem.Object,
			_ => null,
		};
		if (reference is not null)
		{
			return reference;
		}

		if (type.type is Il2CppTypeEnum.Class or Il2CppTypeEnum.ValueType or Il2CppTypeEnum.Enum
			&& _byTypeDefIndex.TryGetValue(type.datapoint, out TypeDefinition? target))
		{
			return target.Module == module ? target : module.ImportReference(target);
		}

		if (type.type is Il2CppTypeEnum.SzArray or Il2CppTypeEnum.Array)
		{
			return new ArrayType(ResolveTypeRef(module, _metadata.ResolveType(type.datapoint)));
		}

		// A type we could not resolve (generics/pointers not attempted, or a reference outside anything
		// this run built) degrades to object rather than failing the whole assembly.
		return module.TypeSystem.Object;
	}
}
