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

	[TestCase(0, 4, 0)]
	[TestCase(1, 1, 1)]
	[TestCase(10, 8, 16)]
	[TestCase(12, 4, 12)]
	[TestCase(21, 4, 24)]
	[TestCase(60, 8, 64)]
	public void SizesRoundUpToAlignmentTheWayACompilerPadsAStruct(int size, int alignment, int expected)
	{
		Assert.That(Il2CppTypeLayout.AlignUp(size, alignment), Is.EqualTo(expected));
	}

	private static Il2CppTypeLayout.Layout Struct(string name, int size, params (int Offset, string Name, string CType)[] fields)
	{
		return new Il2CppTypeLayout.Layout(name, size, true, [.. Fields(fields)]);
	}

	private static List<Il2CppTypeLayout.Field> Fields(params (int Offset, string Name, string CType)[] fields)
	{
		return [.. fields.Select(f => new Il2CppTypeLayout.Field(f.Offset, f.Name, f.CType))];
	}

	private static readonly Dictionary<string, Il2CppTypeLayout.StructInfo> NoStructs = [];

	private static bool TryDescribe(int size, params (int Offset, string Name, string CType)[] fields)
	{
		return Il2CppTypeLayout.TryDescribeValueType(size, Fields(fields), NoStructs, out _, out _);
	}

	/// <summary>
	/// A struct is passed by value on the strength of its fields, so the layout has to reproduce the
	/// declared size exactly once the fields are laid out the way a compiler would.
	/// </summary>
	[Test]
	public void FieldsThatAccountForEveryByteDescribeTheStruct()
	{
		Assert.That(TryDescribe(12, (0, "x", "float"), (4, "y", "float"), (8, "z", "float")), Is.True);
	}

	/// <summary>
	/// Most structs end in padding no field covers. Refusing those would rule out a large share of the
	/// types games pass around, and the padding changes nothing about how the struct travels.
	/// </summary>
	[Test]
	public void TrailingAlignmentPaddingIsAccepted()
	{
		Assert.That(TryDescribe(16, (0, "ptr", "void *"), (8, "len", "int")), Is.True);
	}

	/// <summary>
	/// Padding beyond what alignment explains means a field is missing, and a struct missing a field
	/// may be classified wrongly.
	/// </summary>
	[Test]
	public void PaddingAlignmentCannotExplainIsRefused()
	{
		Assert.That(TryDescribe(64, (0, "first", "int"), (4, "second", "int")), Is.False);
	}

	/// <summary>
	/// A field running past the declared size means the size and the offsets disagree.
	/// </summary>
	[Test]
	public void AFieldRunningPastTheDeclaredSizeIsRefused()
	{
		Assert.That(TryDescribe(1, (0, "m_value", "ushort")), Is.False);
	}

	[Test]
	public void AnUnmappedFieldIsRefused()
	{
		Assert.That(TryDescribe(8, (0, "known", "int"), (4, "unknown", "")), Is.False);
	}

	/// <summary>
	/// An explicit layout compiles to a union, which a struct definition cannot hold. Only one member
	/// per range of bytes is described, and the emitted layout says so rather than leaving Ghidra to
	/// overwrite one with the other.
	/// </summary>
	[Test]
	public void OverlappingFieldsAreReducedToOnePerRange()
	{
		bool described = Il2CppTypeLayout.TryDescribeValueType(
			16,
			Fields((0, "flags", "int"), (4, "hi", "int"), (8, "lo", "int"), (12, "mid", "int"), (8, "ulomidLE", "ulonglong")),
			NoStructs,
			out List<Il2CppTypeLayout.Field> kept,
			out _);

		Assert.Multiple(() =>
		{
			Assert.That(described, Is.True);
			Assert.That(kept.Select(static f => f.Name), Is.EqualTo(new[] { "flags", "hi", "ulomidLE" }));
		});
	}

	/// <summary>
	/// A union of a float and an int is not passed like a float, so describing it by its floating point
	/// members alone would put it in the wrong registers. Preferring the other member avoids that.
	/// </summary>
	[Test]
	public void AMixedUnionIsNotDescribedAsFloatingPoint()
	{
		bool described = Il2CppTypeLayout.TryDescribeValueType(
			16,
			Fields((0, "double_0", "double"), (0, "int64_0", "longlong"), (8, "double_1", "double"), (8, "int64_1", "longlong")),
			NoStructs,
			out List<Il2CppTypeLayout.Field> kept,
			out Il2CppTypeLayout.StructInfo info);

		Assert.Multiple(() =>
		{
			Assert.That(described, Is.True);
			Assert.That(kept.Select(static f => f.CType), Is.All.EqualTo("longlong"));
			Assert.That(info.NonFloating, Is.True);
		});
	}

	/// <summary>
	/// A struct of floats is passed like floats, so one only proves the type is not floating point when
	/// it was itself resolved to hold something that is not.
	/// </summary>
	[Test]
	public void NonFloatingNessCarriesThroughANestedStruct()
	{
		Dictionary<string, Il2CppTypeLayout.StructInfo> resolved = new()
		{
			["v128"] = new Il2CppTypeLayout.StructInfo(16, 8, NonFloating: true),
			["floats4"] = new Il2CppTypeLayout.StructInfo(16, 4, NonFloating: false),
		};

		bool viaNonFloating = Il2CppTypeLayout.TryDescribeValueType(
			32,
			Fields((0, "Lo128", "v128"), (16, "Hi128", "v128"), (0, "Float0", "float")),
			resolved,
			out _,
			out _);

		bool viaFloating = Il2CppTypeLayout.TryDescribeValueType(
			32,
			Fields((0, "Lo", "floats4"), (16, "Hi", "floats4"), (0, "Int0", "int")),
			resolved,
			out _,
			out _);

		Assert.Multiple(() =>
		{
			Assert.That(viaNonFloating, Is.True, "a union of structs that are known not to be floating point is not floating point either");
			Assert.That(viaFloating, Is.False, "dropping the only member that proves the union is not floating point must refuse it");
		});
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
