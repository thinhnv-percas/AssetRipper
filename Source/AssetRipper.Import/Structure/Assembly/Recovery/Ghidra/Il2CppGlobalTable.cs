using Cpp2IL.Core.Model.Contexts;
using LibCpp2IL;
using LibCpp2IL.Metadata;
using System.Globalization;
using System.Text;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Names the globals that compiled Il2Cpp code loads its types, strings and methods out of.
/// </summary>
/// <remarks>
/// A disassembler sees these as anonymous words: a call reads <c>PTR_DAT_0459b1c0</c> and nothing says
/// what it is. Cpp2IL knows, because each one holds an encoded metadata token, and on a measured game
/// every one of the 4578 globals the decompiled output referred to resolved. Handing the names over is
/// the cheapest way to make that output readable, and it is not guesswork: the name comes from the
/// metadata, the same place the method names do.
/// </remarks>
public static class Il2CppGlobalTable
{
	/// <param name="Address">Where the global lives, in the binary's own addressing.</param>
	/// <param name="Name">A C identifier naming what the global refers to.</param>
	public readonly record struct Global(ulong Address, string Name);

	/// <summary>
	/// How much of a string literal goes into its name before it is cut short.
	/// </summary>
	private const int MaximumLiteralLength = 40;

	/// <summary>
	/// How long a name may get. A constructed generic method spells out every type argument, which runs
	/// to four hundred characters and makes the line it appears on unreadable rather than readable.
	/// </summary>
	private const int MaximumNameLength = 120;

	/// <summary>
	/// Collects every metadata usage global the binary relocates.
	/// </summary>
	/// <remarks>
	/// Walking the relocations rather than the code is what makes this complete: position independent
	/// code reaches a global through a relocated table entry, so every usage the binary can reach has
	/// one, whether or not the methods being decompiled happen to use it.
	/// </remarks>
	public static List<Global> Collect(ApplicationAnalysisContext context)
	{
		List<Global> globals = [];
		HashSet<string> usedNames = new(StringComparer.Ordinal);

		foreach (ulong address in context.Binary.RelocatedAddresses)
		{
			MetadataUsage? usage = context.LibCpp2IlContext.GetAnyGlobalByAddress(address);
			if (usage is null)
			{
				continue;
			}

			if (TryDescribe(usage, out string? name))
			{
				if (name.Length > MaximumNameLength)
				{
					name = name[..MaximumNameLength];
				}

				globals.Add(new Global(address, MakeUnique(name, usedNames)));
			}
		}

		return globals;
	}

	/// <summary>
	/// What a usage should be called, or false when reading it would throw.
	/// </summary>
	/// <remarks>
	/// A usage's value is decoded on demand and can fail on metadata that does not agree with itself,
	/// which is not a reason to abandon the rest of them.
	/// </remarks>
	private static bool TryDescribe(MetadataUsage usage, [NotNullWhen(true)] out string? name)
	{
		try
		{
			name = usage.Type switch
			{
				MetadataUsageType.TypeInfo => Sanitize(usage.AsType().ToString()) + "_TypeInfo",
				MetadataUsageType.Type => Sanitize(usage.AsType().ToString()) + "_Il2CppType",
				MetadataUsageType.MethodDef => Sanitize(Describe(usage.AsMethod())) + "_MethodInfo",
				// A constructed generic method already knows how to say what it is, type arguments and
				// all, whereas a definition prints its whole record when asked.
				MetadataUsageType.MethodRef => Sanitize(usage.AsGenericMethodRef().ToString()) + "_MethodInfo",
				MetadataUsageType.FieldInfo => Sanitize(usage.AsField().Name) + "_FieldInfo",
				MetadataUsageType.FieldRva => Sanitize(usage.AsField().Name) + "_FieldRva",
				// A literal is named after what it says, which is the whole point of naming it.
				MetadataUsageType.StringLiteral => "StringLiteral_" + Sanitize(Shorten(usage.AsLiteral())),
				_ => null,
			};
		}
		catch (Exception)
		{
			name = null;
		}

		return name is not null;
	}

	/// <summary>
	/// A method definition's own string form is its whole record, so it is named by hand.
	/// </summary>
	private static string Describe(Il2CppMethodDefinition method)
	{
		return method.DeclaringType is { } declaringType ? declaringType.FullName + "_" + method.Name : method.Name ?? "";
	}

	private static string Shorten(string value)
	{
		return value.Length <= MaximumLiteralLength ? value : value[..MaximumLiteralLength];
	}

	/// <summary>
	/// Writes the globals as a tab separated file.
	/// </summary>
	public static void Write(IEnumerable<Global> globals, TextWriter writer)
	{
		writer.WriteLine("# address\tname");
		foreach (Global global in globals)
		{
			writer.Write("0x");
			writer.Write(global.Address.ToString("x", CultureInfo.InvariantCulture));
			writer.Write('\t');
			writer.Write(global.Name);
			writer.WriteLine();
		}
	}

	/// <summary>
	/// Two globals can describe the same thing, and two literals can say the same words.
	/// </summary>
	private static string MakeUnique(string name, HashSet<string> usedNames)
	{
		if (usedNames.Add(name))
		{
			return name;
		}

		for (int i = 2; ; i++)
		{
			string candidate = $"{name}_{i.ToString(CultureInfo.InvariantCulture)}";
			if (usedNames.Add(candidate))
			{
				return candidate;
			}
		}
	}

	private static string Sanitize(string? value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return "_";
		}

		StringBuilder builder = new(value.Length);
		foreach (char c in value)
		{
			builder.Append(char.IsAsciiLetterOrDigit(c) || c == '_' ? c : '_');
		}

		if (char.IsAsciiDigit(builder[0]))
		{
			builder.Insert(0, '_');
		}

		return builder.ToString();
	}
}
