using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

namespace AssetRipper.Tests;

/// <summary>
/// AssetRipper: widening a field changes who can name it and never whether Unity serializes it.
/// </summary>
/// <remarks>
/// Iteration 063 found the defect with an independent oracle: a private UGUI field widened to public for a
/// recovered body joined Unity's serialized layout, 81 MonoBehaviours failed to read and every UI Image lost
/// its sprite. Each case below is one of the shapes the brief lists, and the first two are red against the
/// rule that produced that.
/// </remarks>
public sealed class SerializedFieldPolicyTests
{
	private static readonly SerializedFieldFacts Instance = new(false, false, false, false, false, false);

	[Test]
	public void APrivateFieldMadePublicStaysOutOfTheLayout()
	{
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public, Instance);

		Assert.Multiple(() =>
		{
			Assert.That(decision.AddNotSerialized, Is.True);
			Assert.That(decision.Before, Is.EqualTo(FieldSerialization.RuntimeOnly));
			Assert.That(decision.After, Is.Not.EqualTo(FieldSerialization.Serialized));
			Assert.That(decision.Origin, Is.EqualTo(FieldVisibilityOrigin.GeneratedVisible));
		});
	}

	[Test]
	public void TheLayoutFingerprintIsUnchangedByWidening()
	{
		var before = new (string, FieldAttributes, SerializedFieldFacts)[]
		{
			("m_Sprite", FieldAttributes.Private, Instance with { HasSerializeField = true }),
			("m_Tracked", FieldAttributes.Private, Instance),
			("color", FieldAttributes.Public, Instance),
		};

		var after = before.Select(field =>
		{
			SerializedFieldDecision decision = SerializedFieldPolicy.Decide(field.Item2, FieldAttributes.Public, field.Item3);
			return (field.Item1, decision.Access, field.Item3 with { HasNonSerialized = field.Item3.HasNonSerialized || decision.AddNotSerialized });
		}).ToArray();

		Assert.That(SerializedFieldPolicy.Fingerprint(after), Is.EqualTo(SerializedFieldPolicy.Fingerprint(before)));
	}

	[Test]
	public void APrivateFieldMadeInternalNeedsNothing()
	{
		// Unity does not serialize an internal field, so internal is not a widening of the layout.
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Assembly, Instance);

		Assert.That(decision.AddNotSerialized, Is.False);
	}

	[Test]
	public void ASerializeFieldStaysSerialized()
	{
		// Already in the layout: hiding it would drop data the asset carries.
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public,
			Instance with { HasSerializeField = true });

		Assert.Multiple(() =>
		{
			Assert.That(decision.AddNotSerialized, Is.False);
			Assert.That(decision.Before, Is.EqualTo(FieldSerialization.Serialized));
			Assert.That(decision.After, Is.EqualTo(FieldSerialization.Serialized));
		});
	}

	[Test]
	public void ANonSerializedFieldIsLeftAsItIs()
	{
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public,
			Instance with { HasNonSerialized = true });

		Assert.Multiple(() =>
		{
			Assert.That(decision.AddNotSerialized, Is.False);
			Assert.That(decision.After, Is.EqualTo(FieldSerialization.NonSerialized));
		});
	}

	[Test]
	public void AGeneratedHelperFieldIsTreatedByTheSameRule()
	{
		// A compiler-generated backing field is an instance field like any other to Unity's serializer;
		// being generated is not a reason to let it into the layout.
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public,
			Instance with { IsCompilerGenerated = true });

		Assert.That(decision.AddNotSerialized, Is.True);
	}

	[Test]
	public void StaticConstAndReadonlyFieldsAreNeverInTheLayout()
	{
		Assert.Multiple(() =>
		{
			Assert.That(SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public, Instance with { IsStatic = true }).AddNotSerialized, Is.False);
			Assert.That(SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public, Instance with { IsLiteral = true }).AddNotSerialized, Is.False);
			Assert.That(SerializedFieldPolicy.Decide(FieldAttributes.Private, FieldAttributes.Public, Instance with { IsInitOnly = true }).AddNotSerialized, Is.False);
		});
	}

	[Test]
	public void AFieldThatWasAlreadyPublicIsSourceVisible()
	{
		SerializedFieldDecision decision = SerializedFieldPolicy.Decide(FieldAttributes.Public, FieldAttributes.Public, Instance);

		Assert.Multiple(() =>
		{
			Assert.That(decision.Origin, Is.EqualTo(FieldVisibilityOrigin.SourceVisible));
			Assert.That(decision.AddNotSerialized, Is.False);
		});
	}
}
