using Cpp2IL.Core.Model.Contexts;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Checks <see cref="Il2CppFieldLayout"/> against the layout a game's metadata already records.
/// </summary>
/// <remarks>
/// The calculation exists in order to describe types the metadata says nothing about, so there is no
/// way to check it where it is needed. Every other type is the check: the metadata carries a size and
/// an offset for each of them, produced by the same rule, so running the calculation over a whole game
/// and comparing says whether it is faithful. That has to be re-run per game rather than assumed, since
/// a different Unity version or a different compiler is exactly what would break it.
/// </remarks>
public static class Il2CppFieldLayoutReport
{
	/// <param name="Considered">Types with a recorded layout to compare against.</param>
	/// <param name="Refused">Types the calculation declined, which is not a disagreement.</param>
	/// <param name="Examples">The first few disagreements, for working out which rule is wrong.</param>
	public readonly record struct Summary(
		int Considered,
		int Refused,
		int SizeMatched,
		int SizeMismatched,
		int OffsetsMatched,
		int OffsetsMismatched,
		int StaticMatched,
		int StaticMismatched,
		int StaticUnknown,
		List<string> Examples);

	/// <summary>
	/// Lays out every type the metadata records a size for and compares the results.
	/// </summary>
	/// <remarks>
	/// A generic definition is skipped because the runtime never lays one out, so the metadata has
	/// nothing recorded to compare with. A type with an explicit layout is compared on neither size nor
	/// offsets, for the same reason the runtime's own check skips it: the offsets came from the
	/// declaration rather than from the calculation, and the size may have too.
	/// </remarks>
	public static Summary Verify(ApplicationAnalysisContext context, Il2CppFieldLayout layout, int maximumExamples = 20)
	{
		int considered = 0, refused = 0;
		int sizeMatched = 0, sizeMismatched = 0;
		int offsetsMatched = 0, offsetsMismatched = 0;
		int staticMatched = 0, staticMismatched = 0, staticUnknown = 0;
		List<string> examples = [];

		foreach (TypeAnalysisContext type in context.AllTypes)
		{
			if (type.Definition is null || type.GenericParameters.Count > 0 || type.Definition.RawSizes.instance_size == 0)
			{
				continue;
			}

			considered++;

			if (!layout.TryGetLayout(type, out Il2CppFieldLayout.TypeLayout computed))
			{
				refused++;
				continue;
			}

			int declaredSize = (int)type.Definition.RawSizes.instance_size;
			bool explicitLayout = (type.Attributes & TypeAttributes.ExplicitLayout) != 0;

			if (!explicitLayout && type.BaseType is not null)
			{
				if (computed.InstanceSize == declaredSize)
				{
					sizeMatched++;
				}
				else
				{
					sizeMismatched++;
					Add(examples, maximumExamples, $"size {type.FullName}: computed {computed.InstanceSize}, recorded {declaredSize}");
				}
			}

			if (!explicitLayout)
			{
				if (OffsetsAgree(type, layout, computed))
				{
					offsetsMatched++;
				}
				else
				{
					offsetsMismatched++;
					Add(examples, maximumExamples, $"offsets {type.FullName}: computed [{string.Join(',', computed.InstanceFieldOffsets)}]");
				}
			}

			int declaredStatic = (int)type.Definition.RawSizes.static_fields_size;
			if (computed.StaticFieldsSize == Il2CppFieldLayout.StaticSizeUnknown)
			{
				staticUnknown++;
			}
			else if (computed.StaticFieldsSize == declaredStatic)
			{
				staticMatched++;
			}
			else
			{
				staticMismatched++;
				Add(examples, maximumExamples, $"statics {type.FullName}: computed {computed.StaticFieldsSize}, recorded {declaredStatic}");
			}
		}

		return new Summary(considered, refused, sizeMatched, sizeMismatched, offsetsMatched, offsetsMismatched, staticMatched, staticMismatched, staticUnknown, examples);
	}

	private static bool OffsetsAgree(TypeAnalysisContext type, Il2CppFieldLayout layout, Il2CppFieldLayout.TypeLayout computed)
	{
		int index = 0;
		foreach (FieldAnalysisContext field in type.Fields)
		{
			if (field.IsStatic)
			{
				continue;
			}

			if (index >= computed.InstanceFieldOffsets.Count || layout.RuntimeFieldOffset(type, field) != computed.InstanceFieldOffsets[index])
			{
				return false;
			}

			index++;
		}

		return index == computed.InstanceFieldOffsets.Count;
	}

	private static void Add(List<string> examples, int maximum, string line)
	{
		if (examples.Count < maximum)
		{
			examples.Add(line);
		}
	}

	public static string Format(Summary summary)
	{
		StringBuilder builder = new();
		builder.Append(CultureInfo.InvariantCulture, $"{summary.Considered} types compared, {summary.Refused} refused");
		builder.AppendLine();
		builder.Append(CultureInfo.InvariantCulture, $"instance size: {summary.SizeMatched} matched, {summary.SizeMismatched} not");
		builder.AppendLine();
		builder.Append(CultureInfo.InvariantCulture, $"field offsets: {summary.OffsetsMatched} matched, {summary.OffsetsMismatched} not");
		builder.AppendLine();
		builder.Append(CultureInfo.InvariantCulture, $"static size: {summary.StaticMatched} matched, {summary.StaticMismatched} not, {summary.StaticUnknown} unknown");
		builder.AppendLine();

		foreach (string example in summary.Examples)
		{
			builder.Append("  ").AppendLine(example);
		}

		return builder.ToString();
	}
}
