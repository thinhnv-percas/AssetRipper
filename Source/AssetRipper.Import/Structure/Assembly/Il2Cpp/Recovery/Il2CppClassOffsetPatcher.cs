using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>
/// Feeds measured <c>Il2CppClass</c> offsets into <see cref="Il2CppClassUsefulOffsets"/>, which ships a
/// hand-maintained table of two Unity versions' worth of 64-bit constants and no 32-bit values at all.
/// </summary>
/// <remarks>
/// <para>
/// <see cref="Il2CppClassUsefulOffsets.GetOffsetName(uint, bool)"/> returns the first matching entry, so
/// prepending the measured offsets makes them win over the built-in ones without removing anything.
/// </para>
/// <para>
/// <see cref="Il2CppClassUsefulOffsets.GetVtableOffset(float, bool)"/> is a method, not data, so it is
/// told separately, through <see cref="Il2CppClassUsefulOffsets.MeasuredVtableOffset"/>.
/// </para>
/// </remarks>
public static class Il2CppClassOffsetPatcher
{
	private const string ClassStruct = "Il2CppClass";

	private const string MethodStruct = "MethodInfo";

	/// <summary>
	/// The names Cpp2IL analysis asks about, paired with the <c>libil2cpp</c> field they correspond to.
	/// Several runtime fields were renamed across versions, hence more than one candidate for some.
	/// </summary>
	private static readonly (string Cpp2IlName, string[] FieldNames)[] interestingFields =
	[
		("static_fields", ["static_fields"]),
		("interfaceOffsets", ["interfaceOffsets"]),
		("interface_offsets_count", ["interface_offsets_count"]),
		("rgctx_data", ["rgctx_data"]),
		("elementType", ["element_class"]),
		("vtable", ["vtable"]),
		("cctor_finished", ["cctor_finished", "cctor_finished_or_no_cctor"]),
		("typeHierarchy", ["typeHierarchy"]),
		("typeHierarchyDepth", ["typeHierarchyDepth"]),
	];

	/// <summary>
	/// The same for <c>MethodInfo</c>, whose layout gained a field in 2022 and so moves as well.
	/// </summary>
	private static readonly (string Cpp2IlName, string[] FieldNames)[] interestingMethodFields =
	[
		("klass", ["klass"]),
		("rgctx_data", ["rgctx_data"]),
	];

	private static readonly object patchLock = new();

	private static List<Il2CppClassUsefulOffsets.UsefulOffset>? originalOffsets;

	private static List<Il2CppMethodInfoUsefulOffsets.UsefulOffset>? originalMethodOffsets;

	/// <summary>
	/// The built-in table, captured before it is ever modified, so a later run starts clean.
	/// </summary>
	/// <remarks>
	/// Snapshotted through a property rather than a field initialiser on purpose. A static field
	/// initialiser on a <c>beforefieldinit</c> type may run as late as the first read of that field,
	/// which in <see cref="Restore"/> is after the list has already been cleared — the snapshot would
	/// then capture nothing and every later restore would leave Cpp2IL with an empty offset table.
	/// </remarks>
	private static List<Il2CppClassUsefulOffsets.UsefulOffset> OriginalOffsets
		=> originalOffsets ??= [.. Il2CppClassUsefulOffsets.UsefulOffsets];

	/// <summary>The same, for <c>MethodInfo</c>. See the remarks above.</summary>
	private static List<Il2CppMethodInfoUsefulOffsets.UsefulOffset> OriginalMethodOffsets
		=> originalMethodOffsets ??= [.. Il2CppMethodInfoUsefulOffsets.UsefulOffsets];

	/// <summary>
	/// Replaces any previous patch with offsets read from <paramref name="db"/>.
	/// </summary>
	/// <returns>How many offsets were contributed.</returns>
	public static int Apply(RuntimeStructDb db)
	{
		lock (patchLock)
		{
			return ApplyCore(db);
		}
	}

	private static int ApplyCore(RuntimeStructDb db)
	{
		RestoreCore();

		int methodOffsets = ApplyMethodInfo(db);

		if (!db.TryGetStruct(ClassStruct, out StructDbStruct? layout))
		{
			return methodOffsets;
		}

		bool is32Bit = db.Is32Bit;
		List<Il2CppClassUsefulOffsets.UsefulOffset> measured = [];

		foreach ((string cpp2IlName, string[] fieldNames) in interestingFields)
		{
			StructDbField? field = Find(layout, fieldNames);

			// Bitfields share a storage unit with their neighbours, so naming that byte would be a guess.
			if (field is null || field.IsBitField || field.Offset < 0)
			{
				continue;
			}

			measured.Add(new Il2CppClassUsefulOffsets.UsefulOffset(cpp2IlName, (uint)field.Offset, DescribeType(field), is32Bit));

			// The vtable bound is read through a method rather than the table, so it needs telling
			// separately. Its version formula is a two-way guess that puts 2019.2's vtable at 0x138
			// when it is at 0x130, and everything that recognises an inlined interface dispatch is
			// measured against it.
			if (cpp2IlName == "vtable")
			{
				Il2CppClassUsefulOffsets.MeasuredVtableOffset = field.Offset;
			}
		}

		if (measured.Count == 0)
		{
			return methodOffsets;
		}

		// Prepended, not substituted: the built-in entries stay reachable for the other pointer size.
		Il2CppClassUsefulOffsets.UsefulOffsets.InsertRange(0, measured);

		Logger.Info(LogCategory.Import,
			$"IL2CPP struct database: applied {measured.Count} measured Il2CppClass and {methodOffsets} MethodInfo offsets " +
			$"for Unity {db.Version} ({(is32Bit ? "32" : "64")}-bit).");

		return measured.Count + methodOffsets;
	}

	/// <summary>
	/// The same for <c>MethodInfo</c>, whose <c>klass</c> and <c>rgctx_data</c> are what generic
	/// sharing is followed through and both of which move between Unity versions.
	/// </summary>
	private static int ApplyMethodInfo(RuntimeStructDb db)
	{
		if (!db.TryGetStruct(MethodStruct, out StructDbStruct? layout))
		{
			return 0;
		}

		List<Il2CppMethodInfoUsefulOffsets.UsefulOffset> measured = [];

		foreach ((string cpp2IlName, string[] fieldNames) in interestingMethodFields)
		{
			StructDbField? field = Find(layout, fieldNames);

			if (field is null || field.IsBitField || field.Offset < 0)
			{
				continue;
			}

			measured.Add(new Il2CppMethodInfoUsefulOffsets.UsefulOffset(cpp2IlName, (uint)field.Offset, DescribeType(field), db.Is32Bit));
		}

		Il2CppMethodInfoUsefulOffsets.UsefulOffsets.InsertRange(0, measured);

		return measured.Count;
	}

	/// <summary>Puts the built-in table back, discarding any patch.</summary>
	public static void Restore()
	{
		lock (patchLock)
		{
			RestoreCore();
		}
	}

	private static void RestoreCore()
	{
		// Read the snapshot before clearing: see the remarks on OriginalOffsets.
		List<Il2CppClassUsefulOffsets.UsefulOffset> pristine = OriginalOffsets;

		List<Il2CppMethodInfoUsefulOffsets.UsefulOffset> pristineMethods = OriginalMethodOffsets;

		Il2CppClassUsefulOffsets.UsefulOffsets.Clear();
		Il2CppClassUsefulOffsets.UsefulOffsets.AddRange(pristine);
		Il2CppClassUsefulOffsets.MeasuredVtableOffset = null;

		Il2CppMethodInfoUsefulOffsets.UsefulOffsets.Clear();
		Il2CppMethodInfoUsefulOffsets.UsefulOffsets.AddRange(pristineMethods);
	}

	private static StructDbField? Find(StructDbStruct layout, string[] names)
	{
		foreach (string name in names)
		{
			foreach (StructDbField field in layout.Fields)
			{
				if (field.Name == name)
				{
					return field;
				}
			}
		}
		return null;
	}

	private static Type DescribeType(StructDbField field)
	{
		if (RuntimeStructDb.IsPointer(field.Type))
		{
			return typeof(IntPtr);
		}

		return field.Size switch
		{
			1 => typeof(byte),
			2 => typeof(ushort),
			8 => typeof(ulong),
			_ => typeof(uint),
		};
	}
}
