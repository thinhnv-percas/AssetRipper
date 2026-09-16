using System.Reflection;
using System.Runtime.Loader;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AssetRipper.Tools.RuntimeEquivalence;

/// <summary>
/// Executes the methods a runtime-equivalence plan names, against the recovered assembly and, when
/// one is supplied, against an oracle assembly compiled from the game's own source.
/// </summary>
/// <remarks>
/// Every other measurement in this project reads text. This one runs the recovered IL: a body whose
/// operation classes match the source's can still be wrong by a sign, and only invoking it says so.
/// <para>
/// What it will not do is report a result it did not get. A case with no oracle assembly behind it
/// is <c>NOT_RUN</c> with the reason, never a pass; a case whose assembly would not load is
/// <c>LOAD_FAILED</c>. A rate over zero executed cases is not printed at all.
/// </para>
/// </remarks>
internal static class Program
{
	private const string NotRun = "NOT_RUN";
	private const string Equivalent = "EQUIVALENT";
	private const string Different = "DIFFERENT";
	private const string BothThrew = "BOTH_THREW";
	private const string OneThrew = "ONE_THREW";
	private const string NotFound = "METHOD_NOT_FOUND";
	private const string LoadFailed = "LOAD_FAILED";

	private static int Main(string[] arguments)
	{
		string? plan = null, output = null, recovered = null, oracle = null;

		for (int index = 0; index < arguments.Length; index++)
		{
			switch (arguments[index])
			{
				case "--plan": plan = Next(arguments, ref index); break;
				case "--out": output = Next(arguments, ref index); break;
				case "--recovered": recovered = Next(arguments, ref index); break;
				case "--oracle": oracle = Next(arguments, ref index); break;
				default:
					Console.Error.WriteLine($"unknown argument {arguments[index]}");
					return 2;
			}
		}

		if (plan is null || recovered is null)
		{
			Console.Error.WriteLine("usage: RuntimeEquivalence --plan <plan.json> --recovered <dir or dll> [--oracle <dll>] [--out <results.json>]");
			return 2;
		}

		JsonNode? document = JsonNode.Parse(File.ReadAllText(plan));
		JsonArray cases = document?["cases"]?.AsArray() ?? [];

		AssemblyLoader recoveredSide = new(recovered);
		AssemblyLoader? oracleSide = oracle is null ? null : new AssemblyLoader(oracle);

		JsonObject results = [];
		Dictionary<string, int> outcomes = [];
		int executed = 0;

		foreach (JsonNode? entry in cases)
		{
			if (entry is null)
			{
				continue;
			}

			string type = entry["type"]?.GetValue<string>() ?? "";
			string method = entry["method"]?.GetValue<string>() ?? "";
			string signature = entry["signature"]?.GetValue<string>() ?? "";
			JsonArray vectors = entry["arguments"]?.AsArray() ?? [];

			Outcome outcome = Run(recoveredSide, oracleSide, type, method, vectors, out string detail);
			results[$"{type}::{signature}"] = new JsonObject
			{
				["outcome"] = outcome.Name,
				["detail"] = detail,
			};

			outcomes[outcome.Name] = outcomes.GetValueOrDefault(outcome.Name) + 1;
			if (outcome.Executed)
			{
				executed++;
			}
		}

		foreach ((string name, int count) in outcomes.OrderByDescending(pair => pair.Value))
		{
			Console.WriteLine($"{count,6}  {name}");
		}

		Console.WriteLine($"\ncases {cases.Count}, executed {executed}");
		if (executed > 0)
		{
			int equivalent = outcomes.GetValueOrDefault(Equivalent);
			Console.WriteLine($"runtime_equivalence_rate {(double)equivalent / executed:F4} ({equivalent} of {executed})");
		}
		else
		{
			// A rate over nothing is the shape of every false pass this project has had to unpick.
			Console.WriteLine("runtime_equivalence_rate NOT_RUN (no case executed)");
		}

		if (output is not null)
		{
			File.WriteAllText(output, new JsonObject { ["cases"] = results }
				.ToJsonString(new JsonSerializerOptions { WriteIndented = true }));
		}

		return 0;
	}

	private static string Next(string[] arguments, ref int index)
		=> index + 1 < arguments.Length ? arguments[++index] : "";

	private readonly record struct Outcome(string Name, bool Executed);

	private static Outcome Run(AssemblyLoader recovered, AssemblyLoader? oracle, string type,
		string method, JsonArray vectors, out string detail)
	{
		if (oracle is null)
		{
			detail = "no oracle assembly was supplied, so there is nothing to compare against";
			return new Outcome(NotRun, false);
		}

		MethodInfo? left = recovered.Find(type, method, out string leftDetail);
		MethodInfo? right = oracle.Find(type, method, out string rightDetail);

		if (left is null || right is null)
		{
			detail = left is null ? leftDetail : rightDetail;
			return new Outcome(detail.StartsWith("load") ? LoadFailed : NotFound, false);
		}

		List<string> differences = [];
		int compared = 0;

		foreach (JsonNode? vector in vectors)
		{
			object?[] parameters;
			try
			{
				parameters = Bind(left.GetParameters(), vector?.AsArray() ?? []);
			}
			catch (Exception exception)
			{
				differences.Add($"could not bind arguments: {exception.Message}");
				continue;
			}

			(object? leftValue, Exception? leftFault) = Invoke(left, parameters);
			(object? rightValue, Exception? rightFault) = Invoke(right, parameters);
			compared++;

			if (leftFault is not null && rightFault is not null)
			{
				// Both faulting the same way is agreement about the method's contract, not a
				// failure of the comparison - an argument out of range is meant to throw.
				if (leftFault.GetType() != rightFault.GetType())
				{
					differences.Add($"{Describe(parameters)}: threw {leftFault.GetType().Name} vs {rightFault.GetType().Name}");
				}
				continue;
			}

			if (leftFault is not null || rightFault is not null)
			{
				differences.Add($"{Describe(parameters)}: {(leftFault is null ? "oracle" : "recovered")} threw {(leftFault ?? rightFault)!.GetType().Name}");
				continue;
			}

			if (!Equals(leftValue, rightValue))
			{
				differences.Add($"{Describe(parameters)}: {leftValue ?? "null"} vs {rightValue ?? "null"}");
			}
		}

		if (compared == 0)
		{
			detail = "no argument vector could be bound";
			return new Outcome(NotRun, false);
		}

		detail = differences.Count == 0 ? $"{compared} vectors agree" : string.Join("; ", differences.Take(4));
		if (differences.Count == 0)
		{
			return new Outcome(Equivalent, true);
		}

		return new Outcome(differences.All(text => text.Contains("threw")) ? OneThrew : Different, true);
	}

	private static (object? Value, Exception? Fault) Invoke(MethodInfo method, object?[] parameters)
	{
		try
		{
			return (method.Invoke(null, parameters), null);
		}
		catch (TargetInvocationException exception)
		{
			return (null, exception.InnerException ?? exception);
		}
		catch (Exception exception)
		{
			return (null, exception);
		}
	}

	private static object?[] Bind(ParameterInfo[] parameters, JsonArray vector)
	{
		if (parameters.Length != vector.Count)
		{
			throw new ArgumentException($"the plan gives {vector.Count} arguments for {parameters.Length} parameters");
		}

		object?[] bound = new object?[parameters.Length];
		for (int index = 0; index < parameters.Length; index++)
		{
			bound[index] = vector[index].Deserialize(parameters[index].ParameterType);
		}

		return bound;
	}

	private static string Describe(object?[] parameters)
		=> "(" + string.Join(", ", parameters.Select(value => value?.ToString() ?? "null")) + ")";

	/// <summary>Loads a directory of assemblies, or one assembly, and finds a static method in it.</summary>
	private sealed class AssemblyLoader
	{
		private readonly AssemblyLoadContext context = new("equivalence", isCollectible: false);
		private readonly List<Assembly> loaded = [];
		private readonly string root;

		public AssemblyLoader(string path)
		{
			root = path;
			string[] files = Directory.Exists(path)
				? Directory.GetFiles(path, "*.dll")
				: [path];

			// A dependency is resolved out of the same directory, because the recovered assemblies
			// reference the stubbed framework that ships beside them and nothing else can satisfy it.
			string directory = Directory.Exists(path) ? path : Path.GetDirectoryName(path) ?? ".";
			context.Resolving += (_, name) =>
			{
				string candidate = Path.Combine(directory, name.Name + ".dll");
				return File.Exists(candidate) ? context.LoadFromAssemblyPath(Path.GetFullPath(candidate)) : null;
			};

			foreach (string file in files)
			{
				try
				{
					loaded.Add(context.LoadFromAssemblyPath(Path.GetFullPath(file)));
				}
				catch (Exception)
				{
					// An assembly that will not load is not a case's failure; the case that needed
					// it reports LOAD_FAILED when its method cannot be found.
				}
			}
		}

		public MethodInfo? Find(string type, string method, out string detail)
		{
			if (loaded.Count == 0)
			{
				detail = $"load: nothing loaded from {root}";
				return null;
			}

			foreach (Assembly assembly in loaded)
			{
				Type[] types;
				try
				{
					types = assembly.GetTypes();
				}
				catch (ReflectionTypeLoadException exception)
				{
					types = exception.Types.Where(entry => entry is not null).ToArray()!;
				}

				foreach (Type candidate in types)
				{
					if (candidate.Name != type)
					{
						continue;
					}

					MethodInfo? found = candidate.GetMethods(
						BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static)
						.FirstOrDefault(entry => entry.Name == method && !entry.IsGenericMethodDefinition);

					if (found is not null)
					{
						detail = $"{assembly.GetName().Name}!{candidate.FullName}";
						return found;
					}
				}
			}

			detail = $"no static {type}.{method} in {loaded.Count} assemblies from {root}";
			return null;
		}
	}
}
