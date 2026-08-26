using System.Collections.Generic;
using System.Linq;

namespace McMaster.Extensions.CommandLineUtils;

internal static class SuggestionCreator
{
	public static IEnumerable<string> GetTopSuggestions(CommandLineApplication command, string input)
	{
		List<string> list = GetCandidates(command).ToList();
		if (list.Count == 0)
		{
			return Enumerable.Empty<string>();
		}
		return StringDistance.GetBestMatchesSorted(StringDistance.DamareuLevenshteinDistance, input, list, 0.33);
	}

	private static IEnumerable<string> GetCandidates(CommandLineApplication command)
	{
		foreach (CommandLineApplication command2 in command.Commands)
		{
			yield return command2.Name;
		}
		foreach (CommandOption option in from o in command.GetOptions()
			where o.ShowInHelpText
			select o)
		{
			if (!string.IsNullOrEmpty(option.LongName))
			{
				yield return option.LongName;
			}
			if (!string.IsNullOrEmpty(option.ShortName))
			{
				yield return option.ShortName;
			}
			if (!string.IsNullOrEmpty(option.SymbolName))
			{
				yield return option.SymbolName;
			}
		}
	}
}
