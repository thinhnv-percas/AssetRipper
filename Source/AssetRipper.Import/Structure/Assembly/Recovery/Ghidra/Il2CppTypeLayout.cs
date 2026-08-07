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
	/// <param name="Size">How many bytes the struct spans.</param>
	public readonly record struct Layout(string StructName, int Size, List<Field> Fields);

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

		List<Field> fields = [];
		int end = 0;

		foreach (FieldAnalysisContext field in type.Fields)
		{
			if (field.IsStatic || field.Offset <= 0)
			{
				continue;
			}

			// A field whose type could not be mapped is left out, which leaves a gap rather than
			// shifting everything after it.
			string cType = GhidraTypeMapper.TryGetCTypeName(field.FieldType?.Type ?? default, out string? name)
				? name
				: "";

			fields.Add(new Field(field.Offset, field.DefaultName ?? $"field_{field.Offset:x}", cType));

			// Sizes are unknown for anything but the mapped types, so a pointer's worth is assumed.
			// Overshooting the struct's size is harmless; undershooting would truncate later fields.
			end = Math.Max(end, field.Offset + 8);
		}

		if (fields.Count < MinimumUsefulFieldCount)
		{
			return false;
		}

		string structName = MakeUniqueName(type, usedNames);
		layout = new Layout(structName, end, fields);
		return true;
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
