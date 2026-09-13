using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// Covers <see cref="BaseChainFieldSearch"/>: finding the field at an offset up a type's base chain,
/// where not every link records its offsets the same way.
/// </summary>
/// <remarks>
/// The case that matters is a generic instance in the middle of the chain -
/// <c>TimeCheatingDetector : ACTkDetectorBase&lt;TimeCheatingDetector&gt;</c>, the ordinary shape of a
/// self-referencing singleton base. Every field of a generic instance is a concrete wrapper with no
/// definition behind it, so it records no offset at all; reading such a link the metadata way finds
/// nothing above offset zero and would find *everything* at offset zero. The walk is written over
/// delegates so these cases need no game behind them.
/// </remarks>
internal sealed class Il2CppBaseChainFieldTests
{
	[Test]
	public void AFieldTheTypeItselfRecordsIsFoundWithNothingToInstantiate()
	{
		Fixture fixture = new();
		Fixture.Type owner = fixture.Plain("Derived", (0x10, "own"));

		Assert.That(fixture.Find(owner, 0x10), Is.EqualTo(("own", (string?)null)));
	}

	[Test]
	public void AFieldARegularBaseRecordsIsFoundUpTheChain()
	{
		Fixture fixture = new();
		Fixture.Type root = fixture.Plain("Base", (0x18, "inherited"));
		Fixture.Type owner = fixture.Plain("Derived", (0x20, "own"));
		owner.Base = root;

		Assert.That(fixture.Find(owner, 0x18), Is.EqualTo(("inherited", (string?)null)));
	}

	[Test]
	public void AFieldAGenericBaseDeclaresComesFromTheComputedLayout()
	{
		// The fix. The instance records nothing, so only the computed layout can answer - and the link
		// has to be reported, because the field it yields is declared by the open definition.
		Fixture fixture = new();
		Fixture.Type generic = fixture.GenericInstance("ACTkDetectorBase<TimeCheatingDetector>", (0x4A, "isRunning"));
		Fixture.Type owner = fixture.Plain("TimeCheatingDetector", (0x60, "timeElapsed"));
		owner.Base = generic;

		Assert.That(fixture.Find(owner, 0x4A), Is.EqualTo(("isRunning", "ACTkDetectorBase<TimeCheatingDetector>")));
	}

	[Test]
	public void AGenericBaseIsNotAskedTheMetadataWay()
	{
		// Its recorded offsets are all zero, so asking it that way matches every one of its fields at
		// offset zero - the same trap the Literal exclusion guards against one level down.
		Fixture fixture = new();
		Fixture.Type generic = fixture.GenericInstance("Holder<int>");
		generic.Recorded.Add((0, "recordedAtZeroBecauseGeneric"));
		Fixture.Type owner = fixture.Plain("Derived");
		owner.Base = generic;

		Assert.That(fixture.Find(owner, 0), Is.EqualTo(((string?)null, (string?)null)));
	}

	[Test]
	public void AnOffsetTheComputedLayoutDoesNotPlaceIsNotInvented()
	{
		Fixture fixture = new();
		Fixture.Type generic = fixture.GenericInstance("Holder<int>", (0x10, "only"));
		Fixture.Type owner = fixture.Plain("Derived");
		owner.Base = generic;

		Assert.That(fixture.Find(owner, 0x38), Is.EqualTo(((string?)null, (string?)null)));
	}

	[Test]
	public void TheNearestLinkWins()
	{
		// A derived type can redeclare a field at an offset its base also uses; the access is through
		// the derived type, so the derived declaration is the one meant.
		Fixture fixture = new();
		Fixture.Type root = fixture.Plain("Base", (0x10, "fromBase"));
		Fixture.Type owner = fixture.Plain("Derived", (0x10, "fromDerived"));
		owner.Base = root;

		Assert.That(fixture.Find(owner, 0x10), Is.EqualTo(("fromDerived", (string?)null)));
	}

	[Test]
	public void AGenericOwnerReportsItselfAsTheLinkToInstantiateOn()
	{
		Fixture fixture = new();
		Fixture.Type owner = fixture.GenericInstance("List<int>", (0x18, "_size"));

		Assert.That(fixture.Find(owner, 0x18), Is.EqualTo(("_size", "List<int>")));
	}

	[Test]
	public void AChainThatPointsAtItselfTerminates()
	{
		Fixture fixture = new();
		Fixture.Type owner = fixture.Plain("Loop", (0x10, "field"));
		owner.Base = owner;

		Assert.That(fixture.Find(owner, 0x99), Is.EqualTo(((string?)null, (string?)null)));
	}

	[Test]
	public void AChainDeeperThanTheLimitStopsRatherThanRunningOn()
	{
		Fixture fixture = new();
		Fixture.Type deepest = fixture.Plain("Deepest", (0x10, "wanted"));
		Fixture.Type link = deepest;

		for (int i = 0; i < BaseChainFieldSearch.MaximumDepth + 2; i++)
		{
			Fixture.Type above = fixture.Plain($"Link{i}");
			above.Base = link;
			link = above;
		}

		Assert.That(fixture.Find(link, 0x10), Is.EqualTo(((string?)null, (string?)null)));
	}

	[Test]
	public void AStaticAccessNeverConsultsTheInstanceLayout()
	{
		// Static fields live in the class's own storage, not in the instance layout, so the caller
		// turns the generic-instance route off for them - and then nothing answers.
		Fixture fixture = new() { Static = true };
		Fixture.Type generic = fixture.GenericInstance("Holder<int>", (0x10, "instanceField"));
		Fixture.Type owner = fixture.Plain("Derived");
		owner.Base = generic;

		Assert.That(fixture.Find(owner, 0x10), Is.EqualTo(((string?)null, (string?)null)));
	}

	[Test]
	public void AFieldTheComputedLayoutPlacesButTheLinkDoesNotDeclareIsLeftToTheLinkThatDoes()
	{
		// PlayMaker's shape: `SomeAction : ComponentAction<InputField> : FsmStateAction`, and `fsm` is
		// FsmStateAction's. The instance's layout places it because a layout covers the whole chain,
		// and instantiating it there would declare the field on a type that does not declare it.
		Fixture fixture = new();
		Fixture.Type root = fixture.Plain("FsmStateAction", (0x18, "fsm"));
		Fixture.Type generic = fixture.GenericInstance("ComponentAction<InputField>", (0x18, "fsm"));
		generic.Base = root;
		fixture.DeclaredByAnAncestor("fsm", root);
		Fixture.Type owner = fixture.Plain("SomeAction");
		owner.Base = generic;

		Assert.That(fixture.Find(owner, 0x18), Is.EqualTo(("fsm", (string?)null)));
	}

	private sealed class Fixture
	{
		/// <summary>Mirrors the caller's own "static access does not use the instance layout" guard.</summary>
		internal bool Static;

		internal sealed class Type(string name)
		{
			internal readonly string Name = name;
			internal Type? Base;
			internal bool IsGenericInstance;

			/// <summary>Offsets the type records in its metadata.</summary>
			internal readonly List<(long Offset, string Field)> Recorded = [];

			/// <summary>
			/// Offsets a computed layout places, which is all a generic instance has - and which
			/// covers the link's whole base chain, so an entry can belong to an ancestor.
			/// </summary>
			internal readonly List<(long Offset, string Field)> Computed = [];

			/// <summary>The open definition behind a generic instance; itself for a plain type.</summary>
			internal Type? Definition;
		}

		internal Type Plain(string name, params (long Offset, string Field)[] fields)
		{
			Type type = new(name);
			type.Recorded.AddRange(fields);
			return type;
		}

		internal Type GenericInstance(string name, params (long Offset, string Field)[] fields)
		{
			Type definition = new(name + "`definition");
			Type type = new(name) { IsGenericInstance = true, Definition = definition };
			type.Computed.AddRange(fields);

			// By default the instance's own definition declares what its layout places.
			foreach ((long offset, string field) in fields)
			{
				declaredBy[field] = definition;
			}

			return type;
		}

		/// <summary>Says that a field the layout places is really declared further up the chain.</summary>
		internal void DeclaredByAnAncestor(string field, Type ancestor) => declaredBy[field] = ancestor;

		private readonly Dictionary<string, Type> declaredBy = [];

		internal (string? Field, string? InstantiateOn) Find(Type owner, long offset)
		{
			(string? field, Type? on) = BaseChainFieldSearch.Find(
				owner,
				offset,
				static type => type.Base,
				type => !Static && type.IsGenericInstance,
				static (type, at) => type.Recorded.FirstOrDefault(entry => entry.Offset == at).Field,
				static (type, at) => type.Computed.FirstOrDefault(entry => entry.Offset == at).Field,
				field => declaredBy.GetValueOrDefault(field),
				static type => type.Definition ?? type);

			return (field, on?.Name);
		}
	}
}
