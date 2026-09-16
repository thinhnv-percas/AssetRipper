using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

namespace AssetRipper.Tests;

/// <summary>
/// When an <c>event</c> declaration has to be dropped for the recovered source to be C# at all.
/// </summary>
/// <remarks>
/// il2cpp inlines <c>add_</c> and <c>remove_</c>, so a body that raises an event touches the field
/// it is built on. C# refuses that twice - CS0079 for reading an event, CS0030 for what the read
/// feeds - and 433 of the test game's 1386 compile errors were that one shape. Dropping the row
/// leaves a delegate field, which C# can read and can still <c>+=</c>.
///
/// Each condition below cost a measurement to find. Removing the interface guard put 122 CS0470
/// back; removing the accessor exclusion drops every event in the assembly.
/// </remarks>
public class Il2CppEventDeclarationTests
{
	[Test]
	public void AnEventWhoseFieldABodyReadsIsDropped()
	{
		Assert.That(EventDeclarationPolicy.ShouldDrop(
			storageIsKnown: true, storageReadOutsideAccessors: true,
			implementsInterfaceEvent: false, isFrameworkAssembly: false), Is.True);
	}

	[Test]
	public void AnEventNothingReadsThroughIsLeftAlone()
	{
		// The ordinary case: code that only subscribes compiles against the event as it stands, so
		// there is nothing to fix and the declaration is information the export should keep.
		Assert.That(EventDeclarationPolicy.ShouldDrop(
			storageIsKnown: true, storageReadOutsideAccessors: false,
			implementsInterfaceEvent: false, isFrameworkAssembly: false), Is.False);
	}

	[Test]
	public void AnEventWhoseStorageCouldNotBeIdentifiedIsLeftAlone()
	{
		// Without the field there is nothing to say a body reached, so dropping the row would be
		// removing a declaration on no evidence.
		Assert.That(EventDeclarationPolicy.ShouldDrop(
			storageIsKnown: false, storageReadOutsideAccessors: true,
			implementsInterfaceEvent: false, isFrameworkAssembly: false), Is.False);
	}

	[Test]
	public void AnEventThatSatisfiesAnInterfaceKeepsItsDeclaration()
	{
		// Dropping it leaves add_X an ordinary method, and an ordinary method cannot implement an
		// interface event's accessor: 122 CS0470 when this condition was missing, which is worse than
		// the errors it was removing. The read stays an error, honestly.
		Assert.That(EventDeclarationPolicy.ShouldDrop(
			storageIsKnown: true, storageReadOutsideAccessors: true,
			implementsInterfaceEvent: true, isFrameworkAssembly: false), Is.False);
	}

	[Test]
	public void AFrameworkAssemblysEventIsNotThisExportsToChange()
	{
		// The same limit every widening in this project has: the assembly an exported script is
		// really compiled against is not the recovered one.
		Assert.That(EventDeclarationPolicy.ShouldDrop(
			storageIsKnown: true, storageReadOutsideAccessors: true,
			implementsInterfaceEvent: false, isFrameworkAssembly: true), Is.False);
	}

	[Test]
	public void TheStorageIsTheOneFieldTheAccessorsTouch()
	{
		// There is no metadata row binding an event to its storage; the accessors are the binding.
		string storage = "OnAdOpening";

		Assert.That(EventDeclarationPolicy.SingleTouchedField([storage, storage, storage]), Is.SameAs(storage));
	}

	[Test]
	public void AccessorsThatTouchTwoFieldsAreNotTheSimpleShape()
	{
		// Picking one would be a guess, and an accessor doing more than combine-and-store is exactly
		// the case where the field is not the whole story.
		Assert.That(EventDeclarationPolicy.SingleTouchedField(["OnAdOpening", "somethingElse"]), Is.Null);
	}

	[Test]
	public void AccessorsThatTouchNoFieldOfTheirOwnTypeGiveNoStorage()
	{
		Assert.That(EventDeclarationPolicy.SingleTouchedField(System.Array.Empty<string>()), Is.Null);
	}
}
