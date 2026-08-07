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
}
