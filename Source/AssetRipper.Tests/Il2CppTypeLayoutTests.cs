using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

namespace AssetRipper.Tests;

/// <summary>
/// A struct may only be passed by value when its size and every one of its fields are known, because
/// the calling convention is decided from both. These pin down the sizes that decision rests on.
/// </summary>
public sealed class Il2CppTypeLayoutTests
{
	[TestCase("bool", 1)]
	[TestCase("char", 1)]
	[TestCase("byte", 1)]
	[TestCase("short", 2)]
	[TestCase("ushort", 2)]
	[TestCase("int", 4)]
	[TestCase("uint", 4)]
	[TestCase("float", 4)]
	[TestCase("longlong", 8)]
	[TestCase("ulonglong", 8)]
	[TestCase("double", 8)]
	[TestCase("void *", 8)]
	public void BuiltInTypesReportTheSizeTheAbiUses(string cType, int expected)
	{
		Assert.That(Il2CppTypeLayout.GetCTypeSize(cType), Is.EqualTo(expected));
	}

	/// <summary>
	/// An unmapped field has no size, which is what makes a layout incomplete and keeps the type out
	/// of any prototype.
	/// </summary>
	[TestCase("")]
	[TestCase("void")]
	[TestCase("UnityEngine_Vector3")]
	public void TypesWithNoKnownSizeReportZero(string cType)
	{
		Assert.That(Il2CppTypeLayout.GetCTypeSize(cType), Is.Zero);
	}

	private static Il2CppTypeLayout.Layout Struct(string name, int size, params (int Offset, string Name, string CType)[] fields)
	{
		return new Il2CppTypeLayout.Layout(name, size, true, [.. fields.Select(f => new Il2CppTypeLayout.Field(f.Offset, f.Name, f.CType))]);
	}

	private static readonly Il2CppTypeLayout.Layout Vector3 = Struct("Vector3", 12, (0, "x", "float"), (4, "y", "float"), (8, "z", "float"));
	private static readonly Il2CppTypeLayout.Layout Bounds = Struct("Bounds", 24, (0, "m_Center", "Vector3"), (12, "m_Extents", "Vector3"));
	private static readonly Il2CppTypeLayout.Layout Ray = Struct("Ray", 24, (0, "m_Origin", "Vector3"), (12, "m_Direction", "Vector3"));

	/// <summary>
	/// Ghidra resolves a field's type by name against the structs already registered, so one that
	/// embeds another has to come after it however the metadata happened to order them.
	/// </summary>
	[Test]
	public void AnEmbeddedStructIsOrderedBeforeTheStructEmbeddingIt()
	{
		List<Il2CppTypeLayout.Layout> sorted = Il2CppTypeLayout.SortByDependency([Bounds, Vector3, Ray]);

		List<string> names = sorted.Select(static l => l.StructName).ToList();
		Assert.Multiple(() =>
		{
			Assert.That(names, Has.Count.EqualTo(3));
			Assert.That(names.IndexOf("Vector3"), Is.LessThan(names.IndexOf("Bounds")));
			Assert.That(names.IndexOf("Vector3"), Is.LessThan(names.IndexOf("Ray")));
		});
	}

	/// <summary>
	/// A struct embedded by two others is still only defined once.
	/// </summary>
	[Test]
	public void EachStructIsEmittedOnce()
	{
		List<Il2CppTypeLayout.Layout> sorted = Il2CppTypeLayout.SortByDependency([Bounds, Ray, Vector3]);

		Assert.That(sorted.Select(static l => l.StructName), Is.Unique);
	}

	/// <summary>
	/// A value type cannot contain itself, so this should be unreachable, but unexpected metadata must
	/// not be able to hang the export.
	/// </summary>
	[Test]
	public void ACycleTerminates()
	{
		Il2CppTypeLayout.Layout a = Struct("A", 8, (0, "b", "B"));
		Il2CppTypeLayout.Layout b = Struct("B", 8, (0, "a", "A"));

		Assert.That(Il2CppTypeLayout.SortByDependency([a, b]), Has.Count.EqualTo(2));
	}

	/// <summary>
	/// A field whose type could not be mapped names no struct, and a struct may embed one that was not
	/// collected. Neither is allowed to drop the layout from the file.
	/// </summary>
	[Test]
	public void UnresolvedFieldTypesDoNotDropLayouts()
	{
		Il2CppTypeLayout.Layout unmapped = Struct("Unmapped", 8, (0, "unknown", ""), (4, "missing", "NotCollected"));

		Assert.That(Il2CppTypeLayout.SortByDependency([unmapped]).Single().StructName, Is.EqualTo("Unmapped"));
	}
}
