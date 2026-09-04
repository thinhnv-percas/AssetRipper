using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using AssetRipper.Primitives;
using Cpp2IL.Core;
using System.IO.Compression;
using System.Text;

namespace AssetRipper.Tests;

/// <summary>
/// Covers the struct database loader, the offset resolver and the Cpp2IL offset patch.
/// </summary>
/// <remarks>
/// The fixtures are written from measured Unity 2019.4.0f1 layouts — <c>sizeof(Il2CppClass) == 304</c> on
/// 64-bit, 188 on 32-bit, <c>vtable</c> at 0x130 and 0xBC respectively — so the numbers asserted here are
/// facts about that Unity release rather than restatements of the code under test.
/// </remarks>
internal sealed class Il2CppStructDbTests
{
	private string directory = "";

	[SetUp]
	public void CreateFixtures()
	{
		directory = Path.Join(Path.GetTempPath(), "AssetRipper.StructDbTests." + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(directory);

		Write("2019.4.0f1-x64.json", Layout(pointerSize: 8), compress: false);
		Write("2019.4.0f1-x32.json", Layout(pointerSize: 4), compress: false);

		// Gzipped on disk, and the loader is expected to sniff that rather than trust the extension.
		Write("2020.2.0a11-x64.json", Layout(pointerSize: 8, vtableOffset: 0x138, classSize: 312), compress: true);
		Write("2020.2.0a11-x32.json", Layout(pointerSize: 4, vtableOffset: 0xC0, classSize: 192), compress: true);

		// Only one width: must not be offered, or a 32-bit game would silently get 64-bit offsets.
		Write("2021.3.0f1-x64.json", Layout(pointerSize: 8), compress: false);
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

	private RuntimeStructDb Load(string version = "2019.4.0f1", bool is32Bit = false)
	{
		StructDbCatalog? catalog = StructDbCatalog.TryCreate(directory);
		Assert.That(catalog, Is.Not.Null);
		RuntimeStructDb? db = catalog!.Load(UnityVersion.Parse(version), is32Bit);
		Assert.That(db, Is.Not.Null);
		return db!;
	}

	[Test]
	public void AMissingDirectoryIsNotAnError()
	{
		Assert.Multiple(() =>
		{
			Assert.That(StructDbCatalog.TryCreate(null), Is.Null);
			Assert.That(StructDbCatalog.TryCreate(Path.Join(directory, "absent")), Is.Null);
		});
	}

	[Test]
	public void OnlyVersionsWithBothWidthsAreOffered()
	{
		StructDbCatalog catalog = StructDbCatalog.TryCreate(directory)!;
		Assert.That(catalog.AvailableVersions, Is.EqualTo((UnityVersion[])
		[
			UnityVersion.Parse("2019.4.0f1"),
			UnityVersion.Parse("2020.2.0a11"),
		]));
	}

	[Test]
	public void SizesMatchUnity()
	{
		RuntimeStructDb db = Load();
		Assert.Multiple(() =>
		{
			Assert.That(db.GetSize("Il2CppClass"), Is.EqualTo(304));
			Assert.That(db.GetSize("MethodInfo"), Is.EqualTo(80));
			Assert.That(db.GetSize("Il2CppType"), Is.EqualTo(16));
			Assert.That(db.GetSize("VirtualInvokeData"), Is.EqualTo(16));
			Assert.That(db.PointerSize, Is.EqualTo(8));
			Assert.That(db.IsExactMatch, Is.True);
		});
	}

	[Test]
	public void AnUnknownStructIsReportedRatherThanGuessed()
	{
		RuntimeStructDb db = Load();
		Assert.Multiple(() =>
		{
			Assert.That(db.GetSize("Il2CppNotAThing"), Is.EqualTo(-1));
			Assert.That(db.TryResolveField("Il2CppNotAThing", 0, out _), Is.False);
			Assert.That(db.TryResolveField("Il2CppClass", 0x1000, out _), Is.False);
			Assert.That(db.TryResolveField("Il2CppClass", -8, out _), Is.False);
		});
	}

	[Test]
	public void PointerFieldCarriesPointeeSize()
	{
		// MethodInfo.klass is an Il2CppClass*, and arrayItemSize must agree with sizeof(Il2CppClass)
		// read independently. This cross-check is what makes a bad layout file detectable.
		RuntimeStructDb db = Load();
		Assert.That(db.TryResolveField("MethodInfo", 0x18, out RuntimeFieldAccess access), Is.True);
		Assert.Multiple(() =>
		{
			Assert.That(access.Path, Is.EqualTo("klass"));
			Assert.That(access.PointeeStruct, Is.EqualTo("Il2CppClass"));
			Assert.That(db.GetSize(access.PointeeStruct!), Is.EqualTo(304));
			Assert.That(access.IsPartial, Is.False);
		});
	}

	[Test]
	public void NestedStructsResolveThroughTheirPath()
	{
		RuntimeStructDb db = Load();
		// Il2CppClass.byval_arg is an embedded Il2CppType at 0x20; +0x28 lands on its bitfield word.
		Assert.That(db.TryResolveField("Il2CppClass", 0x28, out RuntimeFieldAccess access), Is.True);
		Assert.Multiple(() =>
		{
			Assert.That(access.Path, Is.EqualTo("byval_arg.attrs"));
			Assert.That(access.IsBitField, Is.True);
			Assert.That(access.Bits, Is.EqualTo(16));
			Assert.That(access.BitOffset, Is.Zero);
		});
	}

	[Test]
	public void AReadInsideAFieldReportsTheRemainder()
	{
		RuntimeStructDb db = Load();
		// One byte into the 8-byte name pointer: a partial read, not a field of its own.
		Assert.That(db.TryResolveField("Il2CppClass", 0x09, out RuntimeFieldAccess access), Is.True);
		Assert.Multiple(() =>
		{
			Assert.That(access.Path, Is.EqualTo("name"));
			Assert.That(access.IsPartial, Is.True);
			Assert.That(access.Remainder, Is.EqualTo(1));
			Assert.That(access.ToString(), Is.EqualTo("name+0x1"));
		});
	}

	[Test]
	public void BitFieldsCoverExactlyThirtyTwoBits()
	{
		RuntimeStructDb db = Load();
		Assert.That(db.TryGetStruct("Il2CppType", out StructDbStruct? type), Is.True);

		int expectedBit = 0;
		foreach (StructDbField field in type!.Fields.Where(f => f.IsBitField))
		{
			Assert.That(field.BitOffset, Is.EqualTo(expectedBit), $"{field.Name} starts at the wrong bit");
			expectedBit += field.Bits!.Value;
		}

		Assert.That(expectedBit, Is.EqualTo(32));
	}

	[Test]
	public void ThirtyTwoBitLayoutIsNotTheSixtyFourBitOne()
	{
		RuntimeStructDb db32 = Load(is32Bit: true);
		Assert.Multiple(() =>
		{
			Assert.That(db32.PointerSize, Is.EqualTo(4));
			Assert.That(db32.Is32Bit, Is.True);
			Assert.That(db32.GetSize("Il2CppClass"), Is.EqualTo(188));
		});
	}

	[Test]
	public void MissingVersionFallsBackDownwardsAndSaysSo()
	{
		StructDbCatalog catalog = StructDbCatalog.TryCreate(directory)!;
		RuntimeStructDb db = catalog.Load(UnityVersion.Parse("2019.4.99f1"), is32Bit: false)!;
		Assert.Multiple(() =>
		{
			Assert.That(db.IsExactMatch, Is.False);
			Assert.That(db.Version, Is.EqualTo(UnityVersion.Parse("2019.4.0f1")));
		});
	}

	/// <summary>
	/// A game newer than everything in the database gets the newest layout, not the nearest by string.
	/// </summary>
	[Test]
	public void AVersionAboveTheDatabaseGetsTheNewestLayout()
	{
		StructDbCatalog catalog = StructDbCatalog.TryCreate(directory)!;
		RuntimeStructDb db = catalog.Load(UnityVersion.Parse("6000.3.18f1"), is32Bit: false)!;
		Assert.Multiple(() =>
		{
			Assert.That(db.Version, Is.EqualTo(UnityVersion.Parse("2020.2.0a11")));
			Assert.That(db.IsExactMatch, Is.False);
			Assert.That(db.GetSize("Il2CppClass"), Is.EqualTo(312));
		});
	}

	/// <summary>
	/// A game older than everything in the database still gets a layout rather than nothing, since
	/// unnamed offsets are the only alternative.
	/// </summary>
	[Test]
	public void AVersionBelowTheDatabaseGetsTheOldestLayout()
	{
		StructDbCatalog catalog = StructDbCatalog.TryCreate(directory)!;
		RuntimeStructDb db = catalog.Load(UnityVersion.Parse("5.6.1f1"), is32Bit: false)!;
		Assert.Multiple(() =>
		{
			Assert.That(db.Version, Is.EqualTo(UnityVersion.Parse("2019.4.0f1")));
			Assert.That(db.IsExactMatch, Is.False);
		});
	}

	[Test]
	public void GzippedFilesAreReadTransparently()
	{
		RuntimeStructDb db = Load("2020.2.0a11");
		Assert.Multiple(() =>
		{
			Assert.That(db.IsExactMatch, Is.True);
			Assert.That(db.GetSize("Il2CppClass"), Is.EqualTo(312));
		});
	}

	[Test]
	public void VTableSlotsAreCountedFromTheMeasuredOffset()
	{
		StructDbClassOffsets offsets = new(Load());
		Assert.Multiple(() =>
		{
			Assert.That(offsets.VTableOffset, Is.EqualTo(0x130));
			Assert.That(offsets.VTableSlotSize, Is.EqualTo(16));
			Assert.That(offsets.GetVTableSlot(0x150), Is.EqualTo(2));
			Assert.That(offsets.GetVTableSlot(0x130), Is.Zero);
			Assert.That(offsets.GetVTableSlot(0x120), Is.EqualTo(-1));
			Assert.That(offsets.StaticFieldsOffset, Is.EqualTo(0xB8));
			Assert.That(offsets.GetFieldName(0), Is.EqualTo("image"));
		});
	}

	/// <summary>
	/// Cpp2IL ships no 32-bit <c>Il2CppClass</c> offsets at all, so before the patch every 32-bit lookup
	/// fails and after it the measured ones answer.
	/// </summary>
	[Test]
	public void TheOffsetPatchAnswersThirtyTwoBitLookups()
	{
		Assert.That(Il2CppClassUsefulOffsets.GetOffsetName(0xBC, true), Is.Not.EqualTo("vtable"));

		int applied = Il2CppClassOffsetPatcher.Apply(Load(is32Bit: true));

		Assert.Multiple(() =>
		{
			Assert.That(applied, Is.GreaterThan(0));
			Assert.That(Il2CppClassUsefulOffsets.GetOffsetName(0xBC, true), Is.EqualTo("vtable"));
			Assert.That(Il2CppClassUsefulOffsets.IsStaticFieldsPtr(0x5C, true), Is.True);
		});
	}

	/// <summary>
	/// The measured offsets must win over the built-in constants, which are right for two Unity versions
	/// and wrong for the rest.
	/// </summary>
	[Test]
	public void TheOffsetPatchOverridesTheBuiltInConstants()
	{
		Assert.That(Il2CppClassUsefulOffsets.GetOffsetName(0x138, false), Is.EqualTo("vtable"));

		Il2CppClassOffsetPatcher.Apply(Load());

		Assert.That(Il2CppClassUsefulOffsets.GetOffsetName(0x130, false), Is.EqualTo("vtable"),
			"2019.4 puts the vtable at 0x130, not at the hardcoded 0x138");
	}

	[Test]
	public void RestoringLeavesTheBuiltInTableAsItWas()
	{
		int before = Il2CppClassUsefulOffsets.UsefulOffsets.Count;

		Il2CppClassOffsetPatcher.Apply(Load());
		Il2CppClassOffsetPatcher.Apply(Load(is32Bit: true));
		Il2CppClassOffsetPatcher.Restore();

		Assert.Multiple(() =>
		{
			Assert.That(Il2CppClassUsefulOffsets.UsefulOffsets, Has.Count.EqualTo(before));
			Assert.That(Il2CppClassUsefulOffsets.GetOffsetName(0x138, false), Is.EqualTo("vtable"));
		});
	}

	[Test]
	public void CDecorationsAreStrippedFromTypeNames()
	{
		Assert.Multiple(() =>
		{
			Assert.That(RuntimeStructDb.NormalizeTypeName("const struct Il2CppClass**"), Is.EqualTo("Il2CppClass"));
			Assert.That(RuntimeStructDb.NormalizeTypeName("volatile MethodInfo *"), Is.EqualTo("MethodInfo"));
			Assert.That(RuntimeStructDb.IsPointer("Il2CppClass*"), Is.True);
			Assert.That(RuntimeStructDb.IsPointer("Il2CppType"), Is.False);
		});
	}

	private void Write(string fileName, string json, bool compress)
	{
		string path = Path.Join(directory, fileName);
		if (!compress)
		{
			File.WriteAllText(path, json);
			return;
		}

		using FileStream file = File.Create(path);
		using GZipStream gzip = new(file, CompressionLevel.Optimal);
		gzip.Write(Encoding.UTF8.GetBytes(json));
	}

	/// <summary>
	/// A layout file in the shipped schema, holding the structs these tests read.
	/// </summary>
	private static string Layout(int pointerSize, int vtableOffset = 0x130, int classSize = 304)
	{
		bool is64 = pointerSize == 8;
		if (!is64)
		{
			// Measured 2019.4.0f1 32-bit values.
			classSize = classSize == 304 ? 188 : classSize;
			vtableOffset = vtableOffset == 0x130 ? 0xBC : vtableOffset;
		}

		int p = pointerSize;
		int typeSize = is64 ? 16 : 8;
		int byvalArg = is64 ? 0x20 : 0x14;
		int staticFields = is64 ? 0xB8 : 0x5C;
		int methodInfoSize = is64 ? 80 : 40;
		int klassOffset = is64 ? 0x18 : 0x0C;

		return $$"""
		{
			"schema": 1,
			"unityVersion": "fixture",
			"pointerSize": {{p}},
			"source": { "origin": "test", "tool": "fixture" },
			"structs": {
				"Il2CppClass": {
					"size": {{classSize}},
					"fields": [
						{ "name": "image", "type": "Il2CppImage*", "offset": 0, "size": {{p}}, "arrayItemSize": 80 },
						{ "name": "name", "type": "const char*", "offset": {{p}}, "size": {{p}} },
						{ "name": "byval_arg", "type": "Il2CppType", "offset": {{byvalArg}}, "size": {{typeSize}} },
						{ "name": "element_class", "type": "Il2CppClass*", "offset": {{byvalArg + 2 * typeSize}}, "size": {{p}}, "arrayItemSize": {{classSize}} },
						{ "name": "static_fields", "type": "void*", "offset": {{staticFields}}, "size": {{p}} },
						{ "name": "vtable", "type": "VirtualInvokeData", "offset": {{vtableOffset}}, "size": 16 }
					]
				},
				"Il2CppType": {
					"size": {{typeSize}},
					"fields": [
						{ "name": "data", "type": "void*", "offset": 0, "size": {{p}} },
						{ "name": "attrs", "type": "unsigned int", "offset": {{p}}, "bits": 16, "bitOffset": 0, "bitOrdinal": 0 },
						{ "name": "type", "type": "Il2CppTypeEnum", "offset": {{p}}, "bits": 8, "bitOffset": 16, "bitOrdinal": 1 },
						{ "name": "num_mods", "type": "unsigned int", "offset": {{p}}, "bits": 6, "bitOffset": 24, "bitOrdinal": 2 },
						{ "name": "byref", "type": "unsigned int", "offset": {{p}}, "bits": 1, "bitOffset": 30, "bitOrdinal": 3 },
						{ "name": "pinned", "type": "unsigned int", "offset": {{p}}, "bits": 1, "bitOffset": 31, "bitOrdinal": 4 }
					]
				},
				"MethodInfo": {
					"size": {{methodInfoSize}},
					"fields": [
						{ "name": "methodPointer", "type": "Il2CppMethodPointer", "offset": 0, "size": {{p}} },
						{ "name": "invoker_method", "type": "InvokerMethod", "offset": {{p}}, "size": {{p}} },
						{ "name": "name", "type": "const char*", "offset": {{2 * p}}, "size": {{p}} },
						{ "name": "klass", "type": "Il2CppClass*", "offset": {{klassOffset}}, "size": {{p}}, "arrayItemSize": {{classSize}} }
					]
				},
				"VirtualInvokeData": {
					"size": 16,
					"fields": [
						{ "name": "methodPtr", "type": "Il2CppMethodPointer", "offset": 0, "size": {{p}} },
						{ "name": "method", "type": "const MethodInfo*", "offset": {{p}}, "size": {{p}}, "arrayItemSize": {{methodInfoSize}} }
					]
				},
				"Il2CppObject": {
					"size": {{2 * p}},
					"fields": [
						{ "name": "klass", "type": "Il2CppClass*", "offset": 0, "size": {{p}}, "arrayItemSize": {{classSize}} },
						{ "name": "monitor", "type": "MonitorData*", "offset": {{p}}, "size": {{p}} }
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
