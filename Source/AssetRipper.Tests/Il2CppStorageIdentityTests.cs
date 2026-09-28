using System.Runtime.CompilerServices;
using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.ISIL;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="StorageIdentities"/>: where each recovered value lives, and which IL places are
/// one machine location.
/// </summary>
/// <remarks>
/// Every defect this holds down compiled and read plausibly: a parameter written into a local the
/// generator invented (iteration 059), its address taken from one (iteration 058), and four more
/// address sites found in iteration 061. None of them produced a placeholder or changed a count, so
/// these tests are the only thing that says the storage is right.
/// </remarks>
internal sealed class Il2CppStorageIdentityTests
{
	private static readonly string[] Parameters = ["value", "result"];
	private static readonly bool[] ByReference = [false, true];

	private int index;

	private static LocalVariable Local(string name, string? register = null, bool isThis = false)
		=> new(name, new Register(null, register ?? name, 8)) { IsThis = isThis };

	private Instruction At(OpCode opCode, params IOperand[] operands) => new(index++, opCode, [.. operands]);

	private static IReadOnlyDictionary<LocalVariable, StorageIdentity> Analyze(params Instruction[] body)
		=> StorageIdentities.Analyze(body, Parameters, ByReference);

	[Test]
	public void ALocalNamedAfterAParameterIsTheParameter()
	{
		var parameter = Local("value");
		var other = Local("v7");
		var storage = Analyze(At(OpCode.Move, other, parameter), At(OpCode.Return, other));

		Assert.Multiple(() =>
		{
			Assert.That(storage[parameter].Kind, Is.EqualTo(StorageKind.Parameter));
			Assert.That(storage[parameter].AliasGroup, Is.EqualTo("param:0"));
			Assert.That(storage[parameter].Site.Kind, Is.EqualTo(LocalStorageKind.Parameter));
			// A copy of a parameter is a value of its own, not the parameter.
			Assert.That(storage[other].Kind, Is.Not.EqualTo(StorageKind.Parameter));
		});
	}

	[Test]
	public void ARefOrOutParameterIsAlreadyAnAddress()
	{
		var result = Local("result");
		var storage = Analyze(At(OpCode.Move, result, new Immediate(1)));

		Assert.Multiple(() =>
		{
			Assert.That(storage[result].Kind, Is.EqualTo(StorageKind.Parameter));
			Assert.That(storage[result].Site.ByReference, Is.True);
			// A write to it is a definition of the parameter, which is the store iteration 059 lost.
			Assert.That(storage[result].DefinitionSites, Has.Count.EqualTo(1));
		});
	}

	[Test]
	public void AFieldWrittenThroughIsAReadOfItsBase()
	{
		var list = Local("list");
		var storage = Analyze(At(OpCode.Move, new FieldReference(null!, list, 0x10), new Immediate(0)));

		Assert.Multiple(() =>
		{
			Assert.That(storage[list].DefinitionSites, Is.Empty);
			Assert.That(storage[list].UseSites, Has.Count.EqualTo(1));
			var field = StorageIdentities.OfOperand(new FieldReference(null!, list, 0x10), storage);
			Assert.That(field.Kind, Is.EqualTo(StorageKind.Field));
			Assert.That(field.AliasGroup, Does.StartWith("field:local:list."));
		});
	}

	[Test]
	public void AnArrayElementIsNotTheArray()
	{
		var items = Local("items");
		var i = Local("i");
		var element = new ArrayAccess(items, i);
		var storage = Analyze(At(OpCode.Move, element, new Immediate(0)));

		var identity = StorageIdentities.OfOperand(element, storage);
		Assert.Multiple(() =>
		{
			Assert.That(identity.Kind, Is.EqualTo(StorageKind.ArrayElement));
			Assert.That(identity.AliasGroup, Is.EqualTo("elem:local:items[*]"));
			Assert.That(storage[items].Kind, Is.Not.EqualTo(StorageKind.ArrayElement));
			Assert.That(storage[i].UseSites, Has.Count.EqualTo(1));
		});
	}

	[Test]
	public void EveryVersionOfASpillSlotIsOneLocation()
	{
		var before = Local("v3", "stack_-58");
		var after = Local("v5", "stack_-58");
		var storage = Analyze(At(OpCode.Move, before, new Immediate(1)), At(OpCode.Move, after, new Immediate(2)));

		Assert.Multiple(() =>
		{
			Assert.That(storage[before].Kind, Is.EqualTo(StorageKind.Spill));
			Assert.That(storage[after].AliasGroup, Is.EqualTo(storage[before].AliasGroup));
		});
	}

	[Test]
	public void ASplitSlotWithItsAddressTakenIsAHazard()
	{
		// Take the address of one version, write the other: the IL holds them in two locals, so the
		// write never reaches what the address points at.
		var before = Local("v3", "stack_-58");
		var after = Local("v5", "stack_-58");
		var box = Local("v9");
		var storage = Analyze(
			At(OpCode.Move, after, new Immediate(2)),
			At(OpCode.Call, new Immediate(0x1000), box, new AddressOf(before)));

		var hazards = StorageIdentities.Hazards(storage);
		Assert.Multiple(() =>
		{
			Assert.That(storage[before].AddressTaken, Is.True);
			Assert.That(storage[before].Escapes, Is.True, "an address passed to a call leaves the body");
			Assert.That(hazards, Has.Count.EqualTo(1));
			Assert.That(hazards[0].AliasGroup, Is.EqualTo("stack:-58"));
		});
	}

	[Test]
	public void AnAddressTakenOnlyInOnePlaceIsNotAHazard()
	{
		var slot = Local("v3", "stack_-58");
		var storage = Analyze(At(OpCode.Move, slot, new Immediate(2)), At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(slot)));

		Assert.That(StorageIdentities.Hazards(storage), Is.Empty);
	}

	[Test]
	public void ATemporaryIsDefinedOnceAndNeverAddressed()
	{
		var temporary = Local("v1");
		var addressed = Local("v2");
		var storage = Analyze(
			At(OpCode.Move, temporary, new Immediate(1)),
			At(OpCode.Return, temporary),
			At(OpCode.Move, addressed, new Immediate(1)),
			At(OpCode.CallVoid, new Immediate(0x1000), new AddressOf(addressed)));

		Assert.Multiple(() =>
		{
			Assert.That(storage[temporary].Kind, Is.EqualTo(StorageKind.Temporary));
			Assert.That(storage[addressed].Kind, Is.EqualTo(StorageKind.Local));
		});
	}

	[Test]
	public void AnIncrementInPlaceIsAReadAndAWrite()
	{
		// `Add v, v, 1` names one local object in two positions. Skipping every operand equal to the
		// destination made it read nothing, which cost a loop step its place in a scan region.
		var counter = Local("v4");
		var storage = Analyze(At(OpCode.Move, counter, new Immediate(0)), At(OpCode.Add, counter, counter, new Immediate(1)));

		Assert.Multiple(() =>
		{
			Assert.That(storage[counter].DefinitionSites, Has.Count.EqualTo(2));
			Assert.That(storage[counter].UseSites, Has.Count.EqualTo(1));
		});
	}

	[Test]
	public void TheReceiverIsObjectRelativeEvenForAStruct()
	{
		var self = Local("this", isThis: true);
		var storage = StorageIdentities.Analyze([At(OpCode.Return, self)], Parameters, ByReference, _ => true);

		Assert.Multiple(() =>
		{
			Assert.That(storage[self].Kind, Is.EqualTo(StorageKind.This));
			Assert.That(storage[self].Frame, Is.EqualTo(CoordinateFrame.ObjectRelative));
		});
	}

	/// <summary>
	/// The invariant iterations 058, 059 and 061 each broke in a different place: the generator has
	/// three helpers that ask <see cref="LocalStorage"/> where a local lives, and nothing else may
	/// index the map of invented locals, because a parameter has an entry in it too.
	/// </summary>
	[Test]
	public void OnlyTheStorageHelpersIndexTheInventedLocals()
	{
		string path = Path.GetFullPath(Path.Join(Path.GetDirectoryName(ThisFile())!,
			"..", "External", "Cpp2IL.Core", "IlGenerator.cs"));
		if (!File.Exists(path))
		{
			Assert.Inconclusive($"{path} is not present; this test reads the generator's source.");
		}

		string source = File.ReadAllText(path);
		int indexed = CountOf(source, "locals[");
		int looked = CountOf(source, "locals.TryGetValue(");

		Assert.Multiple(() =>
		{
			Assert.That(indexed, Is.EqualTo(3), "LoadLocal, StoreLocal and LoadLocalAddress, and nothing else");
			Assert.That(looked, Is.EqualTo(0), "a TryGetValue hands back the invented local even for a parameter");
		});
	}

	private static int CountOf(string text, string needle)
	{
		int count = 0;
		for (int at = text.IndexOf(needle, StringComparison.Ordinal); at >= 0; at = text.IndexOf(needle, at + 1, StringComparison.Ordinal))
		{
			count++;
		}
		return count;
	}

	private static string ThisFile([CallerFilePath] string path = "") => path;
}
