using System.Collections.Generic;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// AssetRipper: when an <c>event</c> declaration has to be dropped for the recovered source to be
/// C# at all, and which field an event is built on.
/// </summary>
/// <remarks>
/// <para>
/// il2cpp inlines <c>add_</c> and <c>remove_</c>, so a body that raises or tests an event touches the
/// field the event is built on rather than calling its accessors. In metadata that is unremarkable -
/// the field, the two methods and the event row are separate things and nothing forbids reaching the
/// first. In C# it is refused twice: an event may only appear on the left of <c>+=</c> or <c>-=</c>
/// outside its own accessors (CS0079), and again for whatever the read feeds (CS0030 casting an
/// <c>EventHandler&lt;T&gt;</c>). 433 errors on the test game across 17 files, the largest single
/// cause by a third.
/// </para>
/// <para>
/// Widening cannot fix it, because accessibility is not what is refused. What is left is the row:
/// an event is a field, two methods and a claim that the three belong together, and dropping the
/// claim leaves a delegate field that C# can read and can still <c>+=</c>. Nothing is removed from
/// the assembly.
/// </para>
/// <para>
/// Written as decisions over plain values rather than over metadata so that each condition can be
/// stated and tested on its own - the same reason <c>NestedFieldResolver</c> is written over
/// delegates.
/// </para>
/// </remarks>
public static class EventDeclarationPolicy
{
	/// <summary>
	/// Whether an event declaration is this export's to drop.
	/// </summary>
	/// <param name="storageIsKnown">
	/// Whether the field the event is built on could be identified at all. Without it there is
	/// nothing to say a body reached, so the declaration stands.
	/// </param>
	/// <param name="storageReadOutsideAccessors">
	/// Whether any body other than the event's own accessors reads that field. Every accessor reads
	/// its own storage, so counting those would drop every event in the assembly; what C# refuses is
	/// a read from anywhere else.
	/// </param>
	/// <param name="implementsInterfaceEvent">
	/// Whether the accessors satisfy an event an interface declares. Dropping the row there leaves
	/// <c>add_X</c> as an ordinary method, and an ordinary method cannot implement an interface
	/// event's accessor - 122 CS0470 when this condition was missing. The read stays an error, which
	/// is honest: the declaration is not this export's to remove.
	/// </param>
	/// <param name="isFrameworkAssembly">
	/// Whether the declaring assembly is one this export did not invent the source for. The same
	/// limit every widening in this file has: the assembly an exported script is really compiled
	/// against is not the recovered one.
	/// </param>
	public static bool ShouldDrop(bool storageIsKnown, bool storageReadOutsideAccessors,
		bool implementsInterfaceEvent, bool isFrameworkAssembly)
		=> storageIsKnown && storageReadOutsideAccessors && !implementsInterfaceEvent && !isFrameworkAssembly;

	/// <summary>
	/// The one field an event's accessors touch, or null when they touch none or several.
	/// </summary>
	/// <remarks>
	/// There is no metadata row binding an event to its storage, and the name rule does not hold:
	/// the field an event is built on carries the event's own name in the recovered metadata, but a
	/// decompiler renames it the moment an event of that name exists, so reading the output to build
	/// the pairing gives <c>m_OnAdOpening</c> and pairing by name found 2 of 433. What does bind them
	/// is the accessors, and the event row names those.
	/// </remarks>
	public static T? SingleTouchedField<T>(IEnumerable<T> fieldsTheAccessorsTouch) where T : class
	{
		T? found = null;

		foreach (T field in fieldsTheAccessorsTouch)
		{
			if (found is not null && !ReferenceEquals(found, field))
			{
				// Two different fields is not the simple shape, and picking one would be a guess.
				return null;
			}

			found = field;
		}

		return found;
	}
}
