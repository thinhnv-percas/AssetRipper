using Cpp2IL.Core.Model.Contexts;
using System.Globalization;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Describes the field layout of Il2Cpp types so that Ghidra can show field accesses by name.
/// </summary>
/// <remarks>
/// Without a layout, reading a field decompiles as arithmetic on the instance pointer, such as
/// <c>*(long *)(__this + 0x28)</c>. Given the layout, the same access reads as <c>__this-&gt;mesh</c>.
/// This is the equivalent of the header Il2CppDumper emits, built from data AssetRipper already has.
/// </remarks>
public static class Il2CppTypeLayout
{
	/// <summary>
	/// One instance field of a type.
	/// </summary>
	/// <param name="Offset">The field's offset from the start of the object.</param>
	/// <param name="Name">The field's name.</param>
	/// <param name="CType">
	/// A Ghidra built in type, the name of another struct, or empty when the type could not be mapped.
	/// </param>
	public readonly record struct Field(int Offset, string Name, string CType);

	/// <summary>
	/// One type and the fields laid out inside it.
	/// </summary>
	/// <param name="StructName">The name the struct is registered under in Ghidra.</param>
	/// <param name="Size">How many bytes the struct spans, taken from the metadata.</param>
	/// <param name="IsComplete">
	/// Whether every byte of the struct is accounted for by a field of known type. Only a complete
	/// layout may be passed by value, because the calling convention depends on the field types and
	/// not merely on the size.
	/// </param>
	public readonly record struct Layout(string StructName, int Size, bool IsComplete, List<Field> Fields);

	/// <summary>
	/// The size of a Ghidra built in type, or zero when it is not one this maps to.
	/// </summary>
	public static int GetCTypeSize(string cType) => cType switch
	{
		"bool" or "char" or "byte" => 1,
		"short" or "ushort" => 2,
		"int" or "uint" or "float" => 4,
		"longlong" or "ulonglong" or "double" => 8,
		// Every pointer this emits is 64 bit, matching the binaries Il2Cpp ships for.
		"void *" => 8,
		_ => 0,
	};

	private const int MinimumUsefulFieldCount = 1;

	private sealed class WorkingField
	{
		public required int Offset { get; init; }
		public required string Name { get; init; }
		public required TypeAnalysisContext? Type { get; init; }
		public string CType { get; set; } = "";
	}

	private sealed class WorkingLayout
	{
		public required TypeAnalysisContext Type { get; init; }
		public required string StructName { get; init; }
		public required int Size { get; init; }
		public required List<WorkingField> Fields { get; init; }
		public bool IsComplete { get; set; }
	}

	/// <summary>
	/// Collects a layout for every type whose size and field offsets are known.
	/// </summary>
	public static Dictionary<TypeAnalysisContext, Layout> Collect(ApplicationAnalysisContext context)
	{
		List<WorkingLayout> working = BuildPreliminaryLayouts(context);
		ResolveNestedValueTypes(working);

		Dictionary<TypeAnalysisContext, Layout> layouts = [];
		foreach (WorkingLayout layout in working)
		{
			List<Field> fields = layout.Fields
				.Select(static f => new Field(f.Offset, f.Name, f.CType))
				.ToList();

			layouts.Add(layout.Type, new Layout(layout.StructName, layout.Size, layout.IsComplete, fields));
		}

		return layouts;
	}

	/// <summary>
	/// Builds every layout with only the fields that map to a built in type resolved.
	/// </summary>
	private static List<WorkingLayout> BuildPreliminaryLayouts(ApplicationAnalysisContext context)
	{
		List<WorkingLayout> working = [];
		HashSet<string> usedNames = new(StringComparer.Ordinal);

		foreach (AssemblyAnalysisContext assembly in context.Assemblies)
		{
			foreach (TypeAnalysisContext type in assembly.Types)
			{
				// An enum is its underlying primitive, not something with a useful field layout.
				if (type.IsEnumType)
				{
					continue;
				}

				// The metadata carries the exact size, including any trailing padding, so there is no
				// need to work it out from the fields and risk getting the alignment rules wrong.
				int declaredSize = GetDeclaredSize(type);
				if (declaredSize <= 0)
				{
					continue;
				}

				// A reference type begins with the object header, so a field at zero is not a real
				// offset. A value type has no header and its first field genuinely sits at zero.
				int lowestValidOffset = type.IsValueType ? 0 : 1;

				List<WorkingField> fields = [];
				foreach (FieldAnalysisContext field in type.Fields)
				{
					if (field.IsStatic || field.Offset < lowestValidOffset)
					{
						continue;
					}

					WorkingField working_ = new()
					{
						Offset = field.Offset,
						Name = field.DefaultName ?? $"field_{field.Offset:x}",
						Type = field.FieldType,
					};

					if (GhidraTypeMapper.TryGetCTypeName(field.FieldType, out string? name))
					{
						working_.CType = name;
					}

					fields.Add(working_);
				}

				if (fields.Count < MinimumUsefulFieldCount)
				{
					continue;
				}

				working.Add(new WorkingLayout
				{
					Type = type,
					StructName = MakeUniqueName(type, usedNames),
					Size = declaredSize,
					Fields = fields,
				});
			}
		}

		return working;
	}

	/// <summary>
	/// Resolves fields that are themselves value types, repeating until nothing more can be resolved.
	/// </summary>
	/// <remarks>
	/// A struct like Bounds is made of Vector3, so it cannot be described until Vector3 is. Resolving
	/// in one pass would depend on the order types happen to appear in, so this iterates instead:
	/// completeness spreads outwards from the types made only of primitives. A value type cannot
	/// contain itself, so the process always settles.
	/// </remarks>
	private static void ResolveNestedValueTypes(List<WorkingLayout> working)
	{
		Dictionary<TypeAnalysisContext, WorkingLayout> byType = working.ToDictionary(static l => l.Type);
		Dictionary<string, int> sizeByStructName = new(StringComparer.Ordinal);

		bool changed = true;
		while (changed)
		{
			changed = false;

			foreach (WorkingLayout layout in working)
			{
				if (layout.IsComplete)
				{
					continue;
				}

				foreach (WorkingField field in layout.Fields)
				{
					if (field.CType.Length > 0 || field.Type is null || !field.Type.IsValueType)
					{
						continue;
					}

					// Only a complete nested layout may be embedded: an incomplete one would leave the
					// outer struct's field types partly guessed, which is what the completeness rule
					// exists to prevent.
					if (byType.TryGetValue(field.Type, out WorkingLayout? nested) && nested.IsComplete)
					{
						field.CType = nested.StructName;
						changed = true;
					}
				}

				if (Recompute(layout, sizeByStructName))
				{
					changed = true;
				}
			}
		}
	}

	/// <summary>
	/// Works out whether every byte of a value type is now accounted for.
	/// </summary>
	private static bool Recompute(WorkingLayout layout, Dictionary<string, int> sizeByStructName)
	{
		if (!layout.Type.IsValueType)
		{
			return false;
		}

		int covered = 0;
		foreach (WorkingField field in layout.Fields)
		{
			int size = GetCTypeSize(field.CType);
			if (size == 0 && field.CType.Length > 0)
			{
				sizeByStructName.TryGetValue(field.CType, out size);
			}

			if (size == 0)
			{
				return false;
			}

			covered = Math.Max(covered, field.Offset + size);
		}

		if (covered != layout.Size || layout.IsComplete)
		{
			return false;
		}

		layout.IsComplete = true;
		sizeByStructName[layout.StructName] = layout.Size;
		return true;
	}

	/// <summary>
	/// Orders layouts so that a struct comes after every struct it embeds.
	/// </summary>
	/// <remarks>
	/// Ghidra resolves a field's type by name against what is already registered, so a struct has to
	/// be defined before anything that contains it.
	/// </remarks>
	public static List<Layout> SortByDependency(IEnumerable<Layout> layouts)
	{
		List<Layout> input = layouts as List<Layout> ?? [.. layouts];
		Dictionary<string, Layout> byName = new(input.Count, StringComparer.Ordinal);
		foreach (Layout layout in input)
		{
			byName[layout.StructName] = layout;
		}

		List<Layout> sorted = new(input.Count);
		HashSet<string> visited = new(StringComparer.Ordinal);

		foreach (Layout layout in input)
		{
			Visit(layout);
		}

		return sorted;

		void Visit(Layout layout)
		{
			// Marking on the way in rather than on the way out is what stops a cycle from recursing
			// forever. A value type cannot contain itself, so this should never trigger, but unexpected
			// metadata should not be able to overflow the stack.
			if (!visited.Add(layout.StructName))
			{
				return;
			}

			foreach (Field field in layout.Fields)
			{
				if (field.CType.Length > 0
					&& byName.TryGetValue(field.CType, out Layout nested)
					&& nested.StructName != layout.StructName)
				{
					Visit(nested);
				}
			}

			sorted.Add(layout);
		}
	}

	/// <summary>
	/// The size the struct should occupy in Ghidra.
	/// </summary>
	/// <remarks>
	/// A value type's size is its unboxed size. A reference type's fields are laid out after the object
	/// header, so its struct has to span the whole instance.
	/// </remarks>
	private static int GetDeclaredSize(TypeAnalysisContext type)
	{
		if (type.Definition is null)
		{
			return 0;
		}

		return type.IsValueType ? type.Definition.Size : (int)type.Definition.RawSizes.instance_size;
	}

	/// <summary>
	/// Writes the layouts in the format the Ghidra script reads.
	/// </summary>
	/// <remarks>
	/// A type line is followed by its field lines, so the file is read in a single pass. The reader
	/// registers each struct as it goes and resolves a field's type by name against what is already
	/// registered, so the layouts are written with the ones being embedded first.
	/// </remarks>
	public static void Write(IEnumerable<Layout> layouts, TextWriter writer)
	{
		writer.WriteLine("# T\tstructName\tsize");
		writer.WriteLine("# F\toffset\tname\tctype");

		foreach (Layout layout in SortByDependency(layouts))
		{
			writer.Write("T\t");
			writer.Write(layout.StructName);
			writer.Write('\t');
			writer.Write(layout.Size.ToString(CultureInfo.InvariantCulture));
			writer.WriteLine();

			foreach (Field field in layout.Fields)
			{
				writer.Write("F\t");
				writer.Write(field.Offset.ToString(CultureInfo.InvariantCulture));
				writer.Write('\t');
				writer.Write(Sanitize(field.Name));
				writer.Write('\t');
				writer.Write(field.CType);
				writer.WriteLine();
			}
		}
	}

	/// <summary>
	/// Builds a C identifier for a type, disambiguating the collisions that sanitising creates.
	/// </summary>
	public static string MakeUniqueName(TypeAnalysisContext type, HashSet<string> usedNames)
	{
		string baseName = Sanitize(type.FullName ?? type.DefaultName ?? "Type");
		if (usedNames.Add(baseName))
		{
			return baseName;
		}

		for (int i = 2; ; i++)
		{
			string candidate = $"{baseName}_{i.ToString(CultureInfo.InvariantCulture)}";
			if (usedNames.Add(candidate))
			{
				return candidate;
			}
		}
	}

	private static string Sanitize(string value)
	{
		StringBuilder builder = new(value.Length);
		foreach (char c in value)
		{
			builder.Append(char.IsAsciiLetterOrDigit(c) || c == '_' ? c : '_');
		}

		if (builder.Length == 0 || char.IsAsciiDigit(builder[0]))
		{
			builder.Insert(0, '_');
		}

		return builder.ToString();
	}
}
