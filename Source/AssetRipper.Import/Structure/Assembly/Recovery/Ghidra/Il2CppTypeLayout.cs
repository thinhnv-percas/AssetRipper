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
	/// Whether the struct is described well enough to be passed by value. Only a complete layout may
	/// be, because the calling convention depends on the field types and not merely on the size.
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

	/// <summary>
	/// The alignment of a Ghidra built in type, which for every type this maps to is its own size.
	/// </summary>
	public static int GetCTypeAlignment(string cType) => GetCTypeSize(cType);

	/// <summary>
	/// Rounds a size up to a multiple of an alignment, the way a C compiler pads a struct.
	/// </summary>
	public static int AlignUp(int size, int alignment)
	{
		return alignment <= 1 ? size : (size + alignment - 1) / alignment * alignment;
	}

	/// <summary>
	/// The size a compiler gives a value type with no fields, so that two of them still have distinct
	/// addresses. Nothing about such a type has to be inferred, which is what makes it safe to describe.
	/// </summary>
	private const int EmptyValueTypeSize = 1;

	/// <summary>
	/// What is known about a struct whose layout is already resolved.
	/// </summary>
	/// <param name="Alignment">The strictest alignment any of its fields requires.</param>
	/// <param name="NonFloating">
	/// Whether the struct holds something that is definitely not a floating point value, which is what
	/// stops it travelling in floating point registers.
	/// </param>
	public readonly record struct StructInfo(int Size, int Alignment, bool NonFloating);

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
		// An Il2Cpp object header is a class pointer and a monitor pointer, so a boxed value type is
		// that much larger than the value itself.
		int headerSize = (int)context.Binary.PointerSize * 2;

		List<WorkingLayout> working = BuildPreliminaryLayouts(context, headerSize);
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
	private static List<WorkingLayout> BuildPreliminaryLayouts(ApplicationAnalysisContext context, int headerSize)
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
				int declaredSize = GetDeclaredSize(type, headerSize);
				if (declaredSize <= 0)
				{
					continue;
				}

				// A reference type begins with the object header, so a field at zero is not a real
				// offset. A value type has no header and its first field genuinely sits at zero.
				int lowestValidOffset = type.IsValueType ? 0 : 1;

				List<WorkingField> fields = [];
				foreach (FieldAnalysisContext field in EnumerateInstanceFields(type))
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

				// A type with nothing in it is worth describing only when it is an empty value type,
				// which still occupies a byte and is still passed as one.
				if (fields.Count == 0 && !(type.IsValueType && declaredSize == EmptyValueTypeSize))
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
	/// A type's own instance fields and the ones it inherits.
	/// </summary>
	/// <remarks>
	/// Field offsets are counted from the start of the object rather than from the start of the class
	/// that declares them, so a base class's fields sit at the low offsets of every derived instance.
	/// Leaving them out is what made a read of an inherited field decompile as arithmetic while the
	/// class's own fields read by name.
	/// </remarks>
	private static IEnumerable<FieldAnalysisContext> EnumerateInstanceFields(TypeAnalysisContext type)
	{
		HashSet<int> declaredOffsets = [];

		foreach (FieldAnalysisContext field in type.Fields)
		{
			// The type's own fields are taken as they are, overlaps included: a type with an explicit
			// layout puts several of them at one offset on purpose, and it is the selection later that
			// decides which to describe it by.
			if (!field.IsStatic)
			{
				declaredOffsets.Add(field.Offset);
			}

			yield return field;
		}

		// A value type inherits nothing to lay out, so walking its bases would only find whatever the
		// metadata says about ValueType and Object and put it where the struct's own fields belong.
		if (type.IsValueType)
		{
			yield break;
		}

		HashSet<TypeAnalysisContext> seen = [type];

		for (TypeAnalysisContext? current = type.BaseType; current is not null && seen.Add(current); current = current.BaseType)
		{
			foreach (FieldAnalysisContext field in current.Fields)
			{
				// A field the derived class already describes at that offset keeps the derived name, so
				// shadowing does not produce two fields claiming the same bytes.
				if (field.IsStatic || declaredOffsets.Add(field.Offset))
				{
					yield return field;
				}
			}
		}
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
		Dictionary<string, StructInfo> resolved = new(StringComparer.Ordinal);

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

				if (Recompute(layout, resolved))
				{
					changed = true;
				}
			}
		}
	}

	/// <summary>
	/// Works out whether a value type is now described well enough to be passed by value.
	/// </summary>
	private static bool Recompute(WorkingLayout layout, Dictionary<string, StructInfo> resolved)
	{
		if (layout.IsComplete || !layout.Type.IsValueType)
		{
			return false;
		}

		List<Field> fields = [.. layout.Fields.Select(static f => new Field(f.Offset, f.Name, f.CType))];
		if (!TryDescribeValueType(layout.Size, fields, resolved, out List<Field> kept, out StructInfo info))
		{
			return false;
		}

		// The working fields carry the type contexts that nested resolution reads, so the selection is
		// applied to them rather than replaced by the plain records it was made from.
		HashSet<(int, string)> keptKeys = [.. kept.Select(static f => (f.Offset, f.Name))];
		layout.Fields.RemoveAll(f => !keptKeys.Contains((f.Offset, f.Name)));

		layout.IsComplete = true;
		resolved[layout.StructName] = info;
		return true;
	}

	/// <summary>
	/// Decides whether a set of fields describes a value type well enough to pass it by value, and
	/// which of them to describe it with.
	/// </summary>
	/// <remarks>
	/// The test is that laying the resolved fields out the way a C compiler would reproduces exactly
	/// the declared size. That is a stronger claim than every field being known: it also rules out a
	/// layout that only appears to fit because a field is missing, and it accepts the very common case
	/// of a struct ending in alignment padding, which no field covers but which changes nothing about
	/// how the struct is passed.
	/// </remarks>
	/// <param name="resolved">Structs already described, keyed by the name they are registered under.</param>
	/// <param name="kept">The fields to describe the struct with, which excludes any that overlap.</param>
	public static bool TryDescribeValueType(
		int declaredSize,
		IReadOnlyList<Field> fields,
		IReadOnlyDictionary<string, StructInfo> resolved,
		out List<Field> kept,
		out StructInfo info)
	{
		kept = [];
		info = default;

		// An empty value type is described exactly by its size: there is no field to resolve, and a
		// single byte cannot hold a floating point value, so it is never passed in those registers.
		if (fields.Count == 0)
		{
			if (declaredSize != EmptyValueTypeSize)
			{
				return false;
			}

			info = new StructInfo(declaredSize, 1, NonFloating: true);
			return true;
		}

		foreach (Field field in fields)
		{
			if (!TryGetFieldSize(field.CType, resolved, out int size, out _, out _))
			{
				return false;
			}

			// A field running past the declared size means the size and the offsets disagree, so one
			// of them is being read wrong and neither can be trusted.
			if (field.Offset > declaredSize - size)
			{
				return false;
			}
		}

		kept = SelectNonOverlapping(fields, resolved, out bool droppedNonFloating);

		int covered = 0;
		int alignment = 1;
		bool keptNonFloating = false;
		foreach (Field field in kept)
		{
			TryGetFieldSize(field.CType, resolved, out int size, out int fieldAlignment, out bool nonFloating);
			covered = Math.Max(covered, field.Offset + size);
			alignment = Math.Max(alignment, fieldAlignment);
			keptNonFloating |= nonFloating;
		}

		// The one thing the selection may not get wrong is whether the struct looks like it is made
		// only of floats, because that is what decides whether it travels in floating point registers.
		// A union holding both a float and an int does not, so dropping every member that proves it is
		// not floating point would classify the whole struct wrongly.
		if ((droppedNonFloating && !keptNonFloating) || declaredSize != AlignUp(covered, alignment))
		{
			kept = [];
			return false;
		}

		info = new StructInfo(declaredSize, alignment, keptNonFloating);
		return true;
	}

	/// <summary>
	/// Picks the fields to describe a struct with, keeping at most one per range of bytes.
	/// </summary>
	/// <remarks>
	/// Fields overlap when the type has an explicit layout, which Il2Cpp compiles to a union. A struct
	/// definition cannot hold two fields at the same offset, so a choice has to be made, and making it
	/// here rather than leaving Ghidra overwrite one with the other is what makes the emitted file say
	/// exactly what Ghidra will get. The largest member is preferred because it is the one most likely
	/// to span the union as declared, and a non floating point member is preferred among equals so that
	/// a union of mixed types is not mistaken for a bundle of floats.
	/// </remarks>
	public static List<Field> SelectNonOverlapping(
		IReadOnlyList<Field> fields,
		IReadOnlyDictionary<string, StructInfo> resolved,
		out bool droppedNonFloating)
	{
		List<Field> ordered = [.. fields
			.OrderBy(static f => f.Offset)
			.ThenByDescending(f => Sized(f, resolved).Size)
			.ThenByDescending(f => Sized(f, resolved).NonFloating)];

		List<Field> kept = new(fields.Count);
		droppedNonFloating = false;
		int end = 0;

		foreach (Field field in ordered)
		{
			if (kept.Count > 0 && field.Offset < end)
			{
				droppedNonFloating |= Sized(field, resolved).NonFloating;
				continue;
			}

			kept.Add(field);
			end = field.Offset + Sized(field, resolved).Size;
		}

		return kept;

		static StructInfo Sized(Field field, IReadOnlyDictionary<string, StructInfo> resolved)
		{
			TryGetFieldSize(field.CType, resolved, out int size, out int alignment, out bool nonFloating);
			return new StructInfo(size, alignment, nonFloating);
		}
	}

	/// <summary>
	/// The size, alignment and floating pointness of a field's type, whether it is a built in type or
	/// another struct.
	/// </summary>
	/// <remarks>
	/// A struct counts as non floating only when it was resolved to hold something that is definitely
	/// not a floating point value, because a struct of floats is passed like floats.
	/// </remarks>
	private static bool TryGetFieldSize(
		string cType,
		IReadOnlyDictionary<string, StructInfo> resolved,
		out int size,
		out int alignment,
		out bool nonFloating)
	{
		size = GetCTypeSize(cType);
		if (size > 0)
		{
			alignment = GetCTypeAlignment(cType);
			nonFloating = cType is not ("float" or "double");
			return true;
		}

		if (cType.Length > 0 && resolved.TryGetValue(cType, out StructInfo nested))
		{
			size = nested.Size;
			alignment = nested.Alignment;
			nonFloating = nested.NonFloating;
			return true;
		}

		alignment = 0;
		nonFloating = false;
		return false;
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
	/// Both sizes come from the instance size, which is what a boxed value occupies. A reference type's
	/// fields are laid out after the object header so its struct spans the whole instance, while a
	/// value type has no header and its size is the instance size less that header.
	/// <para>
	/// The other size the metadata carries, <c>native_size</c>, is the marshalled size and is not the
	/// one to use: it is absent for most non blittable types, and where it differs it describes a
	/// different layout. <c>System.Char</c> marshals to one byte but occupies two, and
	/// <c>HandleRef</c> marshals to a bare handle but holds a reference alongside it.
	/// </para>
	/// </remarks>
	private static int GetDeclaredSize(TypeAnalysisContext type, int headerSize)
	{
		if (type.Definition is null)
		{
			return 0;
		}

		int instanceSize = (int)type.Definition.RawSizes.instance_size;
		return type.IsValueType ? instanceSize - headerSize : instanceSize;
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
