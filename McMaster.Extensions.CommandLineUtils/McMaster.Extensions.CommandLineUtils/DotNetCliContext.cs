using System;

namespace McMaster.Extensions.CommandLineUtils;

public static class DotNetCliContext
{
	public static bool IsGlobalVerbose()
	{
		bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_CLI_CONTEXT_VERBOSE"), out var result);
		return result;
	}
}
