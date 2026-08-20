using Cpp2IL.Core.Model.Contexts;
using System.Globalization;

namespace AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

/// <summary>
/// Writes the address of every Il2Cpp method along with its managed name, so that a disassembler can
/// label the native functions.
/// </summary>
/// <remarks>
/// This is the piece that makes native decompilation readable. Il2Cpp keeps full type and method
/// names in its metadata even though the compiled code has no symbols, so every function can be
/// named without any guesswork.
/// </remarks>
public static class Il2CppSymbolTable
{
	/// <summary>
	/// One method: where it lives in the binary, which assembly it belongs to, what it is called, and
	/// the key used to match it back to a managed method when exporting.
	/// </summary>
	/// <param name="Signature">A C prototype for the function, or empty when the types could not be mapped safely.</param>
	/// <param name="Decompile">
	/// Whether the function is worth decompiling as well as naming. Naming costs nothing and makes every
	/// call to the function readable; decompiling is the expensive half, so a function nobody is going to
	/// read is named and skipped.
	/// </param>
	public readonly record struct Entry(ulong Address, string Group, string Name, string Key, string Signature = "", bool Decompile = true);

	/// <summary>
	/// Writes the entries as a tab separated file.
	/// </summary>
	public static void Write(IEnumerable<Entry> entries, TextWriter writer)
	{
		writer.WriteLine("# address\tgroup\tname\tkey\tsignature\tdecompile");
		foreach (Entry entry in entries)
		{
			writer.Write("0x");
			writer.Write(entry.Address.ToString("x", CultureInfo.InvariantCulture));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Group));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Name));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Key));
			writer.Write('\t');
			writer.Write(Sanitize(entry.Signature));
			writer.Write('\t');
			writer.Write(entry.Decompile ? '1' : '0');
			writer.WriteLine();
		}
	}

	/// <summary>
	/// Collects every method that has a native address.
	/// </summary>
	public static List<Entry> Collect(ApplicationAnalysisContext context)
	{
		return Collect(context, []);
	}

	/// <param name="layouts">Struct layouts, so instance methods can be typed against their declaring type.</param>
	public static List<Entry> Collect(ApplicationAnalysisContext context, Dictionary<TypeAnalysisContext, Il2CppTypeLayout.Layout> layouts)
	{
		List<Entry> entries = [];

		foreach (AssemblyAnalysisContext assembly in context.Assemblies)
		{
			string group = assembly.Definition?.AssemblyName.Name ?? "Unknown";

			foreach (TypeAnalysisContext type in assembly.Types)
			{
				foreach (MethodAnalysisContext method in type.Methods)
				{
					// Abstract and runtime provided methods have no code to point at.
					if (method.UnderlyingPointer == 0)
					{
						continue;
					}

					string key = GhidraDecompilationIndex.CreateKey(type.FullName, method.DefaultName, method.Parameters.Count);
					string name = method.FullName;

					string? instanceTypeName = layouts.TryGetValue(type, out Il2CppTypeLayout.Layout layout)
						? layout.StructName
						: null;

					// A prototype is only emitted when every type maps to a known size.
					string signature = GhidraTypeMapper.TryGetPrototype(method, SanitizeFunctionName(name), instanceTypeName, layouts, out string? prototype)
						? prototype
						: "";

					entries.Add(new Entry(method.UnderlyingPointer, group, name, key, signature));
				}
			}
		}

		AddGenericInstantiations(context, layouts, entries);
		AddRuntimeEntryPoints(context, entries);

		return entries;
	}

	/// <summary>
	/// Adds the handful of <c>libil2cpp</c> functions Cpp2IL can locate, which are not managed methods
	/// and so appear in no assembly.
	/// </summary>
	/// <remarks>
	/// Compiled Il2Cpp code calls into its runtime constantly, and those functions are not exported, so
	/// a disassembler has nothing to name them from and every call to one reads as a call to nothing.
	/// Cpp2IL finds twenty one of them by pattern on a shipped game, and three of those alone accounted
	/// for 6313 of the 63930 unnamed calls in a measured run.
	/// </remarks>
	private static void AddRuntimeEntryPoints(ApplicationAnalysisContext context, List<Entry> entries)
	{
		HashSet<ulong> claimed = [.. entries.Select(static entry => entry.Address)];

		foreach (KeyValuePair<string, ulong> pair in context.GetOrCreateKeyFunctionAddresses().Pairs)
		{
			// A function Cpp2IL could not find is reported as zero, and several names can share one
			// address when the exported wrapper is the function.
			if (pair.Value == 0 || !claimed.Add(pair.Value))
			{
				continue;
			}

			entries.Add(new Entry(pair.Value, "il2cpp", pair.Key, "", "", Decompile: false));
		}
	}

	/// <summary>
	/// Adds the generic methods, which have no definition to be found through and so are missed entirely
	/// by walking the types.
	/// </summary>
	/// <remarks>
	/// Il2Cpp compiles a separate function for each set of type arguments a generic method is used with,
	/// and there are more of those than there are methods: 99916 against 85483 on a shipped game, 89243
	/// of them at an address no definition claims. Every call to one decompiles as a call to an unnamed
	/// function, which is what a good share of the noise in the output is.
	/// <para>
	/// They are named but not decompiled. Naming a hundred and sixty thousand extra functions cost about
	/// a minute on the measured run and took 8509 call sites out of the unnamed column; decompiling them
	/// as well would multiply the longest part of the run to produce bodies that are, for the most part,
	/// another instantiation of something already in the output.
	/// </para>
	/// </remarks>
	private static void AddGenericInstantiations(
		ApplicationAnalysisContext context,
		Dictionary<TypeAnalysisContext, Il2CppTypeLayout.Layout> layouts,
		List<Entry> entries)
	{
		HashSet<ulong> claimed = [.. entries.Select(static entry => entry.Address)];

		foreach (ConcreteGenericMethodAnalysisContext method in context.ConcreteGenericMethodsByRef.Values)
		{
			// Several instantiations share one compiled function when Il2Cpp can make the code generic
			// over them, and that function is usually the definition's own.
			if (method.UnderlyingPointer == 0 || !claimed.Add(method.UnderlyingPointer))
			{
				continue;
			}

			string group = method.DeclaringType?.DeclaringAssembly.Definition?.AssemblyName.Name
				?? method.BaseMethodContext?.DeclaringType?.DeclaringAssembly.Definition?.AssemblyName.Name
				?? "Generic";

			string signature = GhidraTypeMapper.TryGetPrototype(method, SanitizeFunctionName(method.FullName), null, layouts, out string? prototype)
				? prototype
				: "";

			// No key, because the exported assemblies hold the generic method once rather than once per
			// instantiation, so there is nothing for a body to be attached to without guessing which
			// instantiation the reader meant.
			entries.Add(new Entry(method.UnderlyingPointer, group, method.FullName, "", signature, Decompile: false));
		}
	}

	/// <summary>
	/// The prototype has to name the function with a valid C identifier.
	/// </summary>
	private static string SanitizeFunctionName(string name)
	{
		System.Text.StringBuilder builder = new(name.Length);
		foreach (char c in name)
		{
			builder.Append(char.IsAsciiLetterOrDigit(c) || c == '_' ? c : '_');
		}

		if (builder.Length == 0 || char.IsAsciiDigit(builder[0]))
		{
			builder.Insert(0, '_');
		}

		return builder.ToString();
	}

	/// <summary>
	/// Removes the characters that would break the tab separated format.
	/// </summary>
	private static string Sanitize(string value)
	{
		if (value.AsSpan().IndexOfAny('\t', '\r', '\n') < 0)
		{
			return value;
		}

		return value.Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ');
	}
}
