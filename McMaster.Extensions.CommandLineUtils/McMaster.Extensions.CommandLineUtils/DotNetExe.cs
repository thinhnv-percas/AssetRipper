using System;
using System.IO;

namespace McMaster.Extensions.CommandLineUtils;

public static class DotNetExe
{
	private const string FileName = "dotnet";

	public static string FullPath { get; }

	static DotNetExe()
	{
		FullPath = TryFindDotNetExePath();
	}

	public static string FullPathOrDefault()
	{
		return FullPath ?? "dotnet";
	}

	private static string TryFindDotNetExePath()
	{
		string text = "dotnet";
		text += ".exe";
		string environmentVariable = Environment.GetEnvironmentVariable("DOTNET_ROOT");
		if (!string.IsNullOrEmpty(environmentVariable))
		{
			return Path.Combine(environmentVariable, text);
		}
		return null;
	}
}
