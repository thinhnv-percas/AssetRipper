using AsmResolver.DotNet;
using AssemblyDefinition = AsmResolver.DotNet.AssemblyDefinition;
using MethodDefinition = AsmResolver.DotNet.MethodDefinition;
using ModuleDefinition = AsmResolver.DotNet.ModuleDefinition;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.CIL;
using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Managers;
using ILVerify;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// Replaces every method body of a saved assembly that the runtime cannot be trusted to execute with a minimal one that
/// does nothing and returns the default.
/// </summary>
/// <remarks>
/// <para>
/// A recovered body that ILSpy can read is not one a runtime can run. ILSpy reads a stack type mismatch as a cast and
/// carries on; a JIT either rejects the method (<c>InvalidProgramException</c>, or "Bad IL format" for a <c>call</c> to an
/// abstract method), or - in a release JIT, where most of its type assertions are compiled out - accepts it and emits
/// code that treats an integer as an object reference, which crashes the process at the next garbage collection.
/// SandOut's DLL export did both: three scenes, two segmentation faults, and the one that ran threw on the first frame.
/// Nothing that only reads the output sees any of this.
/// </para>
/// <para>
/// So a saved assembly is verified one method at a time against the very assemblies it was recovered with
/// (<see cref="IAssemblyManager"/>, the game's own stripped framework included) by ILVerify - the reference verifier of
/// the .NET runtime - and a method that fails for any reason other than those in <see cref="BenignErrors"/> is replaced.
/// A replaced method loses what it did, which is the point: the alternative was never that the method worked, only
/// that it failed somewhere a reader of the project could not see. Every replacement is listed in
/// <see cref="ReportFileName"/> with the error that caused it.
/// </para>
/// <para>
/// The check is deliberately not the one the decompiler path makes (<c>ReplaceIfUnverifiable</c> at generation time,
/// which repairs stack depth only): a decompiled script with a type mismatch still says something true about the
/// program, and stubbing it there would throw that away.
/// </para>
/// </remarks>
public sealed class RuntimeSafeBodies
{
	/// <summary>The file under AuxiliaryFiles that lists every replaced body.</summary>
	public const string ReportFileName = "RuntimeSafeBodies.json";

	/// <summary>
	/// Verifier errors that make a method unverifiable without making it wrong to run.
	/// </summary>
	/// <remarks>
	/// Each is a rule of the verifiable subset that a runtime does not enforce: locals not zero-initialised
	/// (<c>InitLocals</c>), a non-virtual call on a receiver other than <c>this</c> (<c>ThisMismatch</c>), a constructor
	/// that does not call its base (<c>ThisUninitReturn</c>, <c>ThisUninitStore</c>, <c>CallCtor</c>), a readonly field
	/// written outside a constructor (<c>InitOnly</c>), and <c>ldftn</c> of a virtual method (<c>LdftnNonFinalVirtual</c>).
	/// Everything else - a value of the wrong type on the stack, a call to an abstract method, a member the caller cannot
	/// see - is what makes a JIT reject the method or run it wrongly.
	/// </remarks>
	public static readonly IReadOnlySet<VerifierError> BenignErrors = new HashSet<VerifierError>
	{
		VerifierError.InitLocals,
		VerifierError.ThisMismatch,
		VerifierError.ThisUninitReturn,
		VerifierError.ThisUninitStore,
		VerifierError.InitOnly,
		VerifierError.CallCtor,
		VerifierError.LdftnNonFinalVirtual,
	};

	private readonly Verifier verifier;
	private readonly Resolver resolver;
	private readonly List<AssemblyReport> reports = [];

	public RuntimeSafeBodies(IAssemblyManager manager)
	{
		resolver = new Resolver(manager);
		verifier = new Verifier(resolver, new VerifierOptions { SanityChecks = false });
		// A Unity game's corlib is mscorlib; anything else (a test, a .NET build) names its own.
		string corlib = manager.GetAssemblies().Select(static assembly => (string?)assembly.Name)
			.FirstOrDefault(static name => name is "mscorlib" or "System.Private.CoreLib") ?? "mscorlib";
		verifier.SetSystemModuleName(new AssemblyNameInfo(corlib));
	}

	public IReadOnlyList<AssemblyReport> Reports => reports;

	/// <summary>The image of <paramref name="assembly"/> with every unsafe body replaced.</summary>
	public byte[] Neutralise(AssemblyDefinition assembly)
	{
		string name = assembly.Name ?? "";
		byte[] image = resolver.ImageOf(name) ?? throw new ArgumentException($"{name} is not an assembly of this game", nameof(assembly));
		AssemblyReport report = new(name);
		reports.Add(report);

		Dictionary<int, string> unsafeMethods = FindUnsafeMethods(name, report);
		if (unsafeMethods.Count == 0)
		{
			return image;
		}

		ModuleDefinition module = ModuleDefinition.FromBytes(image);
		foreach ((int token, string reason) in unsafeMethods)
		{
			if (module.LookupMember(new MetadataToken((uint)token)) is not MethodDefinition method)
			{
				continue;
			}

			method.ReplaceMethodBodyWithMinimalImplementation();
			report.Replaced.Add(new ReplacedBody($"{method.DeclaringType?.FullName}::{method.Name}", $"0x{token:X8}", reason));
		}

		using MemoryStream output = new();
		module.Write(output);
		Logger.Info(LogCategory.Export, $"Runtime-safe bodies: {name}: {report.Replaced.Count} of {report.Methods} bodies replaced"
			+ (report.ByError.Count > 0 ? " (" + string.Join(", ", report.ByError.OrderByDescending(p => p.Value).Select(p => $"{p.Key} {p.Value}")) + ")" : ""));
		return output.ToArray();
	}

	private Dictionary<int, string> FindUnsafeMethods(string name, AssemblyReport report)
	{
		Dictionary<int, string> found = [];
		PEReader pe = resolver.ResolveAssembly(new AssemblyNameInfo(name))!;
		MetadataReader metadata = pe.GetMetadataReader();

		foreach (MethodDefinitionHandle handle in metadata.MethodDefinitions)
		{
			if (metadata.GetMethodDefinition(handle).RelativeVirtualAddress == 0)
			{
				continue;
			}

			report.Methods++;
			string? reason = null;
			try
			{
				foreach (VerificationResult result in verifier.Verify(pe, handle))
				{
					if (BenignErrors.Contains(result.Code))
					{
						continue;
					}

					reason = Describe(result);
					report.ByError[result.Code.ToString()] = report.ByError.GetValueOrDefault(result.Code.ToString()) + 1;
					break;
				}
			}
			catch (Exception exception)
			{
				// The verifier itself failing on a body - an unresolvable type in its signature, say - says the runtime
				// would fail on it too, so it is not kept on the strength of a check that did not finish.
				reason = $"{exception.GetType().Name}: {exception.Message}";
				report.ByError[exception.GetType().Name] = report.ByError.GetValueOrDefault(exception.GetType().Name) + 1;
			}

			if (reason is not null)
			{
				found[MetadataTokens.GetToken(handle)] = reason;
			}
		}

		return found;
	}

	private static string Describe(VerificationResult result)
	{
		string arguments = result.ErrorArguments is { Length: > 0 }
			? " " + string.Join(" ", result.ErrorArguments.Select(argument => $"{argument.Name}={argument.Value}"))
			: "";
		return $"{result.Code}: {result.Message}{arguments}";
	}

	/// <summary>Writes the report of every replaced body to <paramref name="path"/>.</summary>
	public void WriteReport(string path, FileSystem fileSystem)
	{
		using Stream stream = fileSystem.File.Create(path);
		using Utf8JsonWriter writer = new(stream, new JsonWriterOptions { Indented = true });
		writer.WriteStartObject();
		writer.WriteString("note", "Bodies replaced with a minimal implementation (no effect, default return) because ILVerify found them unsafe to run. The project runs without them; it does not do what they did.");
		writer.WriteNumber("methods", reports.Sum(static report => report.Methods));
		writer.WriteNumber("replaced", reports.Sum(static report => report.Replaced.Count));
		writer.WriteStartObject("assemblies");
		foreach (AssemblyReport report in reports.OrderBy(static report => report.Assembly, StringComparer.Ordinal))
		{
			writer.WriteStartObject(report.Assembly);
			writer.WriteNumber("methods", report.Methods);
			writer.WriteNumber("replaced", report.Replaced.Count);
			writer.WriteStartObject("byError");
			foreach ((string error, int count) in report.ByError.OrderByDescending(static pair => pair.Value))
			{
				writer.WriteNumber(error, count);
			}
			writer.WriteEndObject();
			writer.WriteStartArray("bodies");
			foreach (ReplacedBody body in report.Replaced)
			{
				writer.WriteStartObject();
				writer.WriteString("method", body.Method);
				writer.WriteString("token", body.Token);
				writer.WriteString("reason", body.Reason);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}
		writer.WriteEndObject();
		writer.WriteEndObject();
	}

	public sealed class AssemblyReport(string assembly)
	{
		public string Assembly { get; } = assembly;
		public int Methods { get; set; }
		public Dictionary<string, int> ByError { get; } = new(StringComparer.Ordinal);
		public List<ReplacedBody> Replaced { get; } = [];
	}

	public sealed record ReplacedBody(string Method, string Token, string Reason);

	/// <summary>Every assembly of the game, by name, as the image the export writes.</summary>
	private sealed class Resolver : IResolver
	{
		private readonly Dictionary<string, AssemblyDefinition> assemblies = new(StringComparer.OrdinalIgnoreCase);
		private readonly IAssemblyManager manager;
		private readonly Dictionary<string, PEReader?> readers = new(StringComparer.OrdinalIgnoreCase);
		private readonly Dictionary<string, byte[]?> images = new(StringComparer.OrdinalIgnoreCase);

		public Resolver(IAssemblyManager manager)
		{
			this.manager = manager;
			foreach (AssemblyDefinition assembly in manager.GetAssemblies())
			{
				if (assembly.Name is { } name)
				{
					assemblies.TryAdd(name, assembly);
				}
			}
		}

		public byte[]? ImageOf(string name)
		{
			if (images.TryGetValue(name, out byte[]? image))
			{
				return image;
			}

			if (assemblies.TryGetValue(name, out AssemblyDefinition? assembly))
			{
				Stream stream = manager.GetStreamForAssembly(assembly);
				stream.Position = 0;
				using MemoryStream copy = new();
				stream.CopyTo(copy);
				image = copy.ToArray();
			}

			return images[name] = image;
		}

		public PEReader? ResolveAssembly(AssemblyNameInfo assemblyName) => Get(assemblyName.Name);

		public PEReader? ResolveModule(AssemblyNameInfo referencingAssembly, string fileName) => Get(Path.GetFileNameWithoutExtension(fileName));

		private PEReader? Get(string? name)
		{
			if (name is null)
			{
				return null;
			}

			if (!readers.TryGetValue(name, out PEReader? reader))
			{
				reader = ImageOf(name) is { } image ? new PEReader(new MemoryStream(image, writable: false)) : null;
				readers[name] = reader;
			}

			return reader;
		}
	}
}
