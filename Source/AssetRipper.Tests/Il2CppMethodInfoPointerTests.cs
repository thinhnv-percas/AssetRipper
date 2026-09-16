using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using AssetRipper.Primitives;
using Cpp2IL.Core;
using System.Text;

namespace AssetRipper.Tests;

/// <summary>
/// The three function pointers a <c>MethodInfo</c> carries, and why they may not be written down.
/// </summary>
/// <remarks>
/// <para>
/// A call through one of them means three different things. <c>methodPointer</c> is the method's own
/// entry point, so a call through it on a MethodInfo the analysis has resolved is a direct call to
/// that method - which is what iteration 050 recovered. <c>virtualMethodPointer</c> is the entry
/// point dispatch would have chosen and says nothing without the receiver. <c>invoker_method</c> is
/// the runtime's reflection-style trampoline, taking the pointer, the MethodInfo, a receiver and a
/// boxed argument array: it names no managed target at all and is a runtime boundary rather than an
/// unresolved call.
/// </para>
/// <para>
/// Unity 2022 inserted <c>virtualMethodPointer</c> as the second field, which moved
/// <c>invoker_method</c> from one pointer to two and <c>klass</c> with it. Writing either number
/// down has been the same defect three times in this project, so both are measured from the struct
/// database and a build whose layout is not known answers "not known" rather than another version's
/// offsets.
/// </para>
/// </remarks>
internal sealed class Il2CppMethodInfoPointerTests
{
	private string directory = "";

	[SetUp]
	public void CreateFixtures()
	{
		directory = Path.Join(Path.GetTempPath(), "AssetRipper.MethodInfoTests." + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(directory);
	}

	[TearDown]
	public void DeleteFixtures()
	{
		Il2CppClassOffsetPatcher.Restore();

		if (Directory.Exists(directory))
		{
			Directory.Delete(directory, true);
		}
	}

	[Test]
	public void MethodPointerIsTheFirstFieldInEveryLayout()
	{
		// It is the one offset that is the same either side of the 2022 change, and it is still read
		// through the table so that a measured layout can override it.
		Assert.Multiple(() =>
		{
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: false, out long wide), Is.True);
			Assert.That(wide, Is.Zero);
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: true, out long narrow), Is.True);
			Assert.That(narrow, Is.Zero);
		});
	}

	[Test]
	public void BeforeUnity2022_ThereIsNoVirtualMethodPointerAndInvokerIsAtOnePointer()
	{
		Apply("2019.4.0f1");

		Assert.Multiple(() =>
		{
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", is32Bit: false, out long invoker), Is.True);
			Assert.That(invoker, Is.EqualTo(0x08));

			// Absent from the layout, so absent from the table: an offset for a field this build does
			// not have would be an offset onto whatever is there instead.
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("virtualMethodPointer", is32Bit: false, out _), Is.False);

			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("klass", is32Bit: false, out long klass), Is.True);
			Assert.That(klass, Is.EqualTo(0x18));
		});
	}

	[Test]
	public void FromUnity2022_VirtualMethodPointerSitsBetweenThemAndMovesEverythingAfterIt()
	{
		Apply("2022.3.0f1");

		Assert.Multiple(() =>
		{
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: false, out long pointer), Is.True);
			Assert.That(pointer, Is.Zero);

			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("virtualMethodPointer", is32Bit: false, out long virtualPointer), Is.True);
			Assert.That(virtualPointer, Is.EqualTo(0x08));

			// The whole point: one pointer earlier before 2022, and reading it at 0x08 on this build
			// would read virtualMethodPointer and call it a runtime boundary.
			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", is32Bit: false, out long invoker), Is.True);
			Assert.That(invoker, Is.EqualTo(0x10));

			Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("klass", is32Bit: false, out long klass), Is.True);
			Assert.That(klass, Is.EqualTo(0x20));
		});
	}

	[Test]
	public void TheThreePointersAreDistinctOffsets()
	{
		// They are three fields, so a pass keyed on one must not answer for another. Stated as a
		// property rather than as three numbers, so it keeps meaning on a layout nobody has measured.
		Apply("2022.3.0f1");

		Il2CppMethodInfoUsefulOffsets.TryGetOffset("methodPointer", is32Bit: false, out long pointer);
		Il2CppMethodInfoUsefulOffsets.TryGetOffset("virtualMethodPointer", is32Bit: false, out long virtualPointer);
		Il2CppMethodInfoUsefulOffsets.TryGetOffset("invoker_method", is32Bit: false, out long invoker);

		Assert.That(new[] { pointer, virtualPointer, invoker }, Is.Unique);
	}

	[Test]
	public void TheMeasuredOffsetsDoNotOutliveTheRunTheyWereMeasuredFor()
	{
		Apply("2022.3.0f1");
		Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("virtualMethodPointer", is32Bit: false, out _), Is.True);

		Il2CppClassOffsetPatcher.Restore();

		// A field measured for one Unity version reaching the next run would be the same defect one
		// step removed: an offset from a layout this build does not have.
		Assert.That(Il2CppMethodInfoUsefulOffsets.TryGetOffset("virtualMethodPointer", is32Bit: false, out _), Is.False);
	}

	private void Apply(string version)
	{
		Write($"{version}-x64.json", MethodInfoLayout(pointerSize: 8, virtualMethodPointer: version.StartsWith("2022", StringComparison.Ordinal)));
		Write($"{version}-x32.json", MethodInfoLayout(pointerSize: 4, virtualMethodPointer: version.StartsWith("2022", StringComparison.Ordinal)));

		StructDbCatalog? catalog = StructDbCatalog.TryCreate(directory);
		Assert.That(catalog, Is.Not.Null);
		RuntimeStructDb? db = catalog!.Load(UnityVersion.Parse(version), is32Bit: false);
		Assert.That(db, Is.Not.Null);
		Il2CppClassOffsetPatcher.Apply(db!);
	}

	private void Write(string name, string json)
		=> File.WriteAllBytes(Path.Join(directory, name), Encoding.UTF8.GetBytes(json));

	/// <summary>
	/// A database carrying nothing but the MethodInfo layout, which is all these cases are about.
	/// </summary>
	private static string MethodInfoLayout(int pointerSize, bool virtualMethodPointer)
	{
		int p = pointerSize;
		int step = virtualMethodPointer ? p : 0;
		string virtualField = virtualMethodPointer
			? $$"""{ "name": "virtualMethodPointer", "type": "Il2CppMethodPointer", "offset": {{p}}, "size": {{p}} },"""
			: "";

		return $$"""
		{
			"schema": 1,
			"unityVersion": "fixture",
			"pointerSize": {{p}},
			"source": { "origin": "test", "tool": "fixture" },
			"structs": {
				"MethodInfo": {
					"size": {{(p == 8 ? 80 : 40) + step}},
					"fields": [
						{ "name": "methodPointer", "type": "Il2CppMethodPointer", "offset": 0, "size": {{p}} },
						{{virtualField}}
						{ "name": "invoker_method", "type": "InvokerMethod", "offset": {{p + step}}, "size": {{p}} },
						{ "name": "name", "type": "const char*", "offset": {{(2 * p) + step}}, "size": {{p}} },
						{ "name": "klass", "type": "Il2CppClass*", "offset": {{(p == 8 ? 0x18 : 0x0C) + step}}, "size": {{p}} }
					]
				}
			},
			"enums": {},
			"defines": {},
			"typedefs": {}
		}
		""";
	}
}
