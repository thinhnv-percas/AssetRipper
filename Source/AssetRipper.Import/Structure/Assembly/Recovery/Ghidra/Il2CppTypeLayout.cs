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
	/// <param name="CType">A Ghidra built in type of the right size, or empty when the type could not be mapped.</param>
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

	/// <summary>
	/// Reference types begin with the object header, so their first field never sits at zero. A
	/// layout whose fields all sit at zero is not a layout Il2Cpp produced.
	/// </summary>
	private const int MinimumUsefulFieldCount = 1;

	/// <summary>
	/// Collects a layout for every type that has instance fields at known offsets.
	/// </summary>
	/// <returns>The layouts, keyed by the struct name used for them.</returns>
	public static Dictionary<TypeAnalysisContext, Layout> Collect(ApplicationAnalysisContext context)
	{
		Dictionary<TypeAnalysisContext, Layout> layouts = [];
		HashSet<string> usedNames = new(StringComparer.Ordinal);

		foreach (AssemblyAnalysisContext assembly in context.Assemblies)
		{
			foreach (TypeAnalysisContext type in assembly.Types)
			{
				if (TryGetLayout(type, usedNames, out Layout layout))
				{
					layouts.Add(type, layout);
				}
			}
		}

		return layouts;
	}

	private static bool TryGetLayout(TypeAnalysisContext type, HashSet<string> usedNames, out Layout layout)
	{
		layout = default;

		// An enum is its underlying primitive, not something with a useful field layout.
		if (type.IsEnumType)
		{
			return false;
		}

		// The metadata carries the exact size, including any trailing padding, so there is no need to
		// work it out from the fields and risk getting the alignment rules wrong.
		int declaredSize = GetDeclaredSize(type);
		if (declaredSize <= 0)
		{
			return false;
		}

		List<Field> fields = [];
		int covered = 0;
		bool everyFieldMapped = true;

		// A reference type begins with the object header, so a field at zero is not a real offset. A
		// value type has no header and its first field genuinely sits at zero.
		int lowestValidOffset = type.IsValueType ? 0 : 1;

		foreach (FieldAnalysisContext field in type.Fields)
		{
			if (field.IsStatic || field.Offset < lowestValidOffset)
			{
				continue;
			}

			// A field whose type could not be mapped is left out, which leaves a gap rather than
			// shifting everything after it.
			string cType = GhidraTypeMapper.TryGetCTypeName(field.FieldType, out string? name)
				? name
				: "";

			fields.Add(new Field(field.Offset, field.DefaultName ?? $"field_{field.Offset:x}", cType));

			int size = GetCTypeSize(cType);
			if (size == 0)
			{
				everyFieldMapped = false;
			}
			else
			{
				covered = Math.Max(covered, field.Offset + size);
			}
		}

		if (fields.Count < MinimumUsefulFieldCount)
		{
			return false;
		}

		// A value type is only safe to pass by value when nothing about it is guessed. A reference type
		// is always handled through a pointer, so completeness does not matter for it.
		bool isComplete = type.IsValueType && everyFieldMapped && covered == declaredSize;

		string structName = MakeUniqueName(type, usedNames);
		layout = new Layout(structName, declaredSize, isComplete, fields);
		return true;
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
	/// A type line is followed by its field lines, so the file is read in a single pass.
	/// </remarks>
	public static void Write(IEnumerable<Layout> layouts, TextWriter writer)
	{
		writer.WriteLine("# T\tstructName\tsize");
		writer.WriteLine("# F\toffset\tname\tctype");

		foreach (Layout layout in layouts)
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
