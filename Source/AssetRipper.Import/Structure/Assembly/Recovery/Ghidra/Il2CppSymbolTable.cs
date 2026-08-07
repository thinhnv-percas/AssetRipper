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
	public readonly record struct Entry(ulong Address, string Group, string Name, string Key, string Signature = "");

	/// <summary>
	/// Writes the entries as a tab separated file.
	/// </summary>
	public static void Write(IEnumerable<Entry> entries, TextWriter writer)
	{
		writer.WriteLine("# address\tgroup\tname\tkey\tsignature");
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
					string signature = GhidraTypeMapper.TryGetPrototype(method, SanitizeFunctionName(name), instanceTypeName, out string? prototype)
						? prototype
						: "";

					entries.Add(new Entry(method.UnderlyingPointer, group, name, key, signature));
				}
			}
		}

		return entries;
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
