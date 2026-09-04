using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;

/// <summary>What a value in a register is known to point at, and how far into it.</summary>
/// <param name="Root">Display name of the value the tag was derived from, for example <c>this</c>.</param>
/// <param name="RuntimeStruct">An IL2CPP runtime struct name, when the value points at one.</param>
/// <param name="ManagedType">A managed type, when the value is a managed object reference.</param>
/// <param name="Offset">Bytes already added to the pointer by preceding arithmetic.</param>
public readonly record struct RuntimeTypeTag(
	string Root,
	string? RuntimeStruct,
	TypeAnalysisContext? ManagedType,
	long Offset)
{
	public bool IsEmpty => RuntimeStruct is null && ManagedType is null;

	public RuntimeTypeTag WithOffset(long delta) => this with { Offset = Offset + delta };

	public static RuntimeTypeTag ForStruct(string root, string structName) => new(root, structName, null, 0);

	public static RuntimeTypeTag ForManaged(string root, TypeAnalysisContext type) => new(root, null, type, 0);
}

/// <summary>
/// Walks a method's ISIL forwards, tracking which registers hold pointers of known type, and names the
/// memory accesses made through them.
/// </summary>
public sealed class RuntimeStructAccessAnnotator(RuntimeStructDb db)
{
	private const string ObjectStruct = "Il2CppObject";
	private const string ClassStruct = "Il2CppClass";
	private const string MethodInfoStruct = "MethodInfo";

	private readonly StructDbClassOffsets classOffsets = new(db);

	/// <summary>
	/// Names what can be named in <paramref name="method"/>. The method must already have been analysed
	/// (<see cref="MethodAnalysisContext.Analyze"/>), otherwise there is no ISIL to walk.
	/// </summary>
	/// <returns>ISIL instruction index to a human readable access, for example <c>this-&gt;klass-&gt;vtable[7].method</c>.</returns>
	public Dictionary<int, string> Annotate(MethodAnalysisContext method)
	{
		Dictionary<int, string> annotations = [];

		List<Instruction>? instructions = method.ConvertedIsil;
		if (instructions is null || instructions.Count == 0)
		{
			return annotations;
		}

		Dictionary<string, RuntimeTypeTag> tags = SeedTags(method);
		if (tags.Count == 0)
		{
			return annotations;
		}

		foreach (Instruction instruction in instructions)
		{
			switch (instruction.OpCode)
			{
				case OpCode.Move:
					HandleMove(instruction, tags, annotations);
					break;

				case OpCode.Add:
					HandleAdd(instruction, tags);
					break;

				default:
					// Anything else: the destination's previous meaning no longer holds.
					ClearDestination(instruction, tags);
					break;
			}
		}

		return annotations;
	}

	private Dictionary<string, RuntimeTypeTag> SeedTags(MethodAnalysisContext method)
	{
		Dictionary<string, RuntimeTypeTag> tags = new(StringComparer.Ordinal);

		foreach (LocalVariable local in method.ParameterLocals)
		{
			string? key = KeyOf(local);
			if (key is null)
			{
				continue;
			}

			if (local.IsThis && method.DeclaringType is { } declaringType)
			{
				tags[key] = RuntimeTypeTag.ForManaged("this", declaringType);
			}
			else if (local.IsMethodInfo)
			{
				tags[key] = RuntimeTypeTag.ForStruct(local.Name, MethodInfoStruct);
			}
			else if (local.Type is { IsValueType: false } parameterType)
			{
				tags[key] = RuntimeTypeTag.ForManaged(local.Name, parameterType);
			}
		}

		return tags;
	}

	private void HandleMove(Instruction instruction, Dictionary<string, RuntimeTypeTag> tags, Dictionary<int, string> annotations)
	{
		if (instruction.Operands.Count < 2)
		{
			return;
		}

		string? destinationKey = KeyOf(instruction.Operands[0]);
		IOperand source = instruction.Operands[1];

		if (source is MemoryOperand memory)
		{
			// A load through a tagged pointer is the case worth naming.
			if (memory.Base is not null
				&& KeyOf(memory.Base) is string baseKey
				&& tags.TryGetValue(baseKey, out RuntimeTypeTag tag)
				&& TryDescribe(tag, tag.Offset + memory.Addend, out string text, out RuntimeTypeTag result))
			{
				annotations[instruction.Index] = text;

				if (destinationKey is not null)
				{
					SetOrClear(tags, destinationKey, result);
				}
				return;
			}

			if (destinationKey is not null)
			{
				tags.Remove(destinationKey);
			}
			return;
		}

		// Register to register: the tag travels with the value.
		if (destinationKey is not null)
		{
			if (KeyOf(source) is string sourceKey && tags.TryGetValue(sourceKey, out RuntimeTypeTag moved))
			{
				tags[destinationKey] = moved;
			}
			else
			{
				tags.Remove(destinationKey);
			}
		}
	}

	private static void HandleAdd(Instruction instruction, Dictionary<string, RuntimeTypeTag> tags)
	{
		if (instruction.Operands.Count < 3)
		{
			return;
		}

		string? destinationKey = KeyOf(instruction.Operands[0]);
		if (destinationKey is null)
		{
			return;
		}

		// Pointer arithmetic with a constant keeps the type and moves the cursor. Anything else is unknown.
		if (KeyOf(instruction.Operands[1]) is string baseKey
			&& tags.TryGetValue(baseKey, out RuntimeTypeTag tag)
			&& instruction.Operands[2] is Immediate immediate)
		{
			tags[destinationKey] = tag.WithOffset(immediate.Value);
		}
		else
		{
			tags.Remove(destinationKey);
		}
	}

	private static void ClearDestination(Instruction instruction, Dictionary<string, RuntimeTypeTag> tags)
	{
		if (instruction.Destination is { } destination && KeyOf(destination) is string key)
		{
			tags.Remove(key);
		}
	}

	private static void SetOrClear(Dictionary<string, RuntimeTypeTag> tags, string key, RuntimeTypeTag tag)
	{
		if (tag.IsEmpty)
		{
			tags.Remove(key);
		}
		else
		{
			tags[key] = tag;
		}
	}

	/// <summary>Describes one load through a tagged pointer, and types the loaded value where possible.</summary>
	private bool TryDescribe(RuntimeTypeTag tag, long offset, out string text, out RuntimeTypeTag result)
	{
		text = "";
		result = default;

		if (offset < 0)
		{
			return false;
		}

		if (tag.ManagedType is { } managedType)
		{
			return TryDescribeManaged(tag.Root, managedType, offset, out text, out result);
		}

		if (tag.RuntimeStruct is not { } structName)
		{
			return false;
		}

		// Inside the vtable the field path is meaningless; the slot number is the useful fact.
		if (structName == ClassStruct)
		{
			int slot = classOffsets.GetVTableSlot(offset);
			if (slot >= 0)
			{
				text = $"{tag.Root}->vtable[{slot}]";
				result = RuntimeTypeTag.ForStruct(text, "VirtualInvokeData");
				return true;
			}
		}

		if (!db.TryResolveField(structName, offset, out RuntimeFieldAccess access))
		{
			return false;
		}

		text = $"{tag.Root}->{access}";

		if (access.IsBitField)
		{
			text += $" /* {access.Bits} bit{(access.Bits == 1 ? "" : "s")} at bit {access.BitOffset} */";
		}

		result = access.PointeeStruct is { } pointee && !access.IsPartial
			? RuntimeTypeTag.ForStruct(text, pointee)
			: default;

		return true;
	}

	private bool TryDescribeManaged(string root, TypeAnalysisContext type, long offset, out string text, out RuntimeTypeTag result)
	{
		text = "";
		result = default;

		// Every managed object starts with the Il2CppObject header: klass, then monitor.
		int headerSize = db.PointerSize * 2;
		if (offset < headerSize)
		{
			if (db.TryResolveField(ObjectStruct, offset, out RuntimeFieldAccess header))
			{
				text = $"{root}->{header}";
				result = header.PointeeStruct is { } pointee
					? RuntimeTypeTag.ForStruct(text, pointee)
					: default;
				return true;
			}

			// Il2CppObject is absent from the older layout files, but its shape has never changed:
			// a class pointer, then the monitor pointer.
			if (offset == 0)
			{
				text = $"{root}->klass";
				result = RuntimeTypeTag.ForStruct(text, ClassStruct);
				return true;
			}

			if (offset == db.PointerSize)
			{
				text = $"{root}->monitor";
				return true;
			}
		}

		foreach (FieldAnalysisContext field in EnumerateInstanceFields(type))
		{
			if (field.Offset != offset)
			{
				continue;
			}

			text = $"{root}.{field.Name}";
			result = field.FieldType is { IsValueType: false } fieldType
				? RuntimeTypeTag.ForManaged(text, fieldType)
				: default;
			return true;
		}

		return false;
	}

	private static IEnumerable<FieldAnalysisContext> EnumerateInstanceFields(TypeAnalysisContext type)
	{
		// Field offsets are absolute within the object, so base type fields are reachable at their own offsets.
		for (TypeAnalysisContext? current = type; current is not null; current = current.BaseType)
		{
			foreach (FieldAnalysisContext field in current.Fields)
			{
				if (!field.IsStatic && field.Offset >= 0)
				{
					yield return field;
				}
			}
		}
	}

	/// <summary>A stable key for the storage an operand names, or null when the operand is not storage.</summary>
	private static string? KeyOf(IOperand operand) => operand switch
	{
		LocalVariable local => "L:" + local.Name,
		Register register => "R:" + register.Name,
		_ => null,
	};
}
