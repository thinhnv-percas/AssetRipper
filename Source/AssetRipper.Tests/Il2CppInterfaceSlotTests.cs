using Cpp2IL.Core.Analysis;

namespace AssetRipper.Tests;

/// <summary>
/// An interface dispatch names its method by the slot the metadata records for it, never by the
/// method's position in the interface's declaration list.
/// </summary>
/// <remarks>
/// <see cref="InterfaceInvokeDataRecovery"/> first took <c>methods[slot]</c>. A member that holds no
/// slot - static, or not virtual - still takes a position, so from it on the two part company and
/// the call is resolved to the wrong method with nothing to say so.
/// </remarks>
public class Il2CppInterfaceSlotTests
{
	private sealed record Member(string Name, ushort? Slot);

	private static Member? Holding(int slot, params Member[] members)
		=> InterfaceInvokeDataRecovery.MemberHoldingSlot(members, member => member.Slot, slot);

	[Test]
	public void TheSlotNamesTheMethodNotThePosition()
	{
		Member[] members = [new("Create", ushort.MaxValue), new("get_Count", 0), new("CopyTo", 1)];

		Assert.That(Holding(1, members)!.Name, Is.EqualTo("CopyTo"), "position 1 is get_Count, slot 1 is CopyTo");
	}

	[Test]
	public void AMemberWithNoSlotHoldsNone()
		=> Assert.That(Holding(ushort.MaxValue, new Member("Create", ushort.MaxValue)), Is.Null);

	[Test]
	public void ASlotNothingHoldsIsNotGuessed()
		=> Assert.That(Holding(5, new Member("get_Count", 0), new Member("CopyTo", 1)), Is.Null);

	[Test]
	public void AnUnknownSlotIsNotZero()
		=> Assert.That(Holding(0, new Member("Unread", null)), Is.Null);
}
