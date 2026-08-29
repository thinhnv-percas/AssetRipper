using AssetRipper.IO.Files;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// Repoints a project's references from a ripped package at the official one.
/// </summary>
/// <remarks>
/// Only a guid written as part of a reference is rewritten. A bare <c>guid:</c> line is an asset's own
/// identity, and rewriting one would hand the official package's identity to a file that is still the
/// ripped copy, leaving two assets claiming to be the same thing. Restricting the rewrite to the two
/// forms Unity actually writes references in keeps that from happening anywhere, including inside meta
/// files, which carry both kinds of guid in the same document.
/// </remarks>
public static partial class ProjectReferenceRewriter
{
	/// <summary>
	/// A reference from one asset to another, as it appears in a serialised file.
	/// </summary>
	[GeneratedRegex(@"\{fileID:\s*(?<fileID>-?\d+)\s*,\s*guid:\s*(?<guid>[0-9a-fA-F]{32})\s*,\s*type:\s*(?<type>\d+)\s*\}", RegexOptions.CultureInvariant)]
	private static partial Regex ReferenceRegex { get; }

	/// <summary>
	/// How an assembly definition names another one it depends on.
	/// </summary>
	[GeneratedRegex(@"GUID:(?<guid>[0-9a-fA-F]{32})", RegexOptions.CultureInvariant)]
	private static partial Regex AssemblyDefinitionReferenceRegex { get; }

	/// <summary>
	/// The file kinds that can hold a reference. Anything else is left alone, so a rewrite cannot
	/// corrupt source, binaries or documentation that happen to contain something guid shaped.
	/// </summary>
	private static readonly HashSet<string> RewritableExtensions = new(StringComparer.OrdinalIgnoreCase)
	{
		".prefab", ".unity", ".asset", ".mat", ".controller", ".overridecontroller", ".anim", ".mask",
		".spriteatlas", ".spriteatlasv2", ".playable", ".signal", ".physicmaterial", ".physicsmaterial2d",
		".guiskin", ".fontsettings", ".terrainlayer", ".shadervariants", ".lighting", ".giparams",
		".renderTexture", ".cubemap", ".flare", ".mixer", ".preset", ".brush", ".asmdef", ".asmref",
		".meta",
	};

	/// <summary>
	/// Rewrites the references in one file's text.
	/// </summary>
	public static string Rewrite(string text, ProjectRemapPlan plan, RemapReport report)
	{
		string rewritten = ReferenceRegex.Replace(text, match => RewriteReference(match, plan, report));
		return AssemblyDefinitionReferenceRegex.Replace(rewritten, match => RewriteAssemblyDefinitionReference(match, plan, report));
	}

	private static string RewriteReference(Match match, ProjectRemapPlan plan, RemapReport report)
	{
		string guid = match.Groups["guid"].Value;
		string type = match.Groups["type"].Value;

		if (!long.TryParse(match.Groups["fileID"].ValueSpan, NumberStyles.Integer, CultureInfo.InvariantCulture, out long fileId))
		{
			return match.Value;
		}

		// A script moves both halves of the reference, so it is matched on the pair rather than on the
		// guid alone. Nothing else can match the pair, because a decompiled script's guid is derived
		// from the type it holds and belongs to that one file.
		if (plan.ScriptMap.TryGetValue(new AssetReference(fileId, guid), out AssetReference replacement))
		{
			report.ScriptReferencesRewritten++;
			return Format(replacement.FileId, replacement.Guid, type);
		}

		if (plan.GuidMap.TryGetValue(guid, out string? newGuid))
		{
			// A reference into an assembly is a reference to a script, even though only the guid moves:
			// the fileID is already the hash Unity computes from the namespace and class name.
			if (plan.AssemblyGuids.Contains(guid))
			{
				report.ScriptReferencesRewritten++;
			}
			else
			{
				report.GuidsRewritten++;
			}

			return Format(fileId, newGuid, type);
		}

		CountIfUnresolved(guid, plan, report);
		return match.Value;
	}

	private static string RewriteAssemblyDefinitionReference(Match match, ProjectRemapPlan plan, RemapReport report)
	{
		string guid = match.Groups["guid"].Value;

		if (plan.GuidMap.TryGetValue(guid, out string? newGuid))
		{
			report.GuidsRewritten++;
			return $"GUID:{newGuid}";
		}

		CountIfUnresolved(guid, plan, report);
		return match.Value;
	}

	private static void CountIfUnresolved(string guid, ProjectRemapPlan plan, RemapReport report)
	{
		if (plan.UnmappedRippedGuids.Contains(guid))
		{
			report.UnresolvedByGuid[guid] = report.UnresolvedByGuid.GetValueOrDefault(guid) + 1;
		}
	}

	private static string Format(long fileId, string guid, string type)
	{
		return $"{{fileID: {fileId.ToString(CultureInfo.InvariantCulture)}, guid: {guid}, type: {type}}}";
	}

	private static readonly UTF8Encoding Utf8NoBom = new(false);

	/// <summary>
	/// Rewrites every file under a directory.
	/// </summary>
	/// <param name="root">Usually the project's Assets folder.</param>
	/// <param name="dryRun">
	/// When true nothing is written and the report says what would have changed. This is the default
	/// way to run it: the rewrite edits a whole project in place and is expensive to undo by hand.
	/// </param>
	/// <param name="backupDirectory">
	/// Where to copy a file before it is changed, keeping its path relative to <paramref name="root"/>.
	/// Null skips the backup, which is only reasonable when the project is under version control.
	/// </param>
	/// <param name="fileSystem">
	/// Where to read and write. An export may be written somewhere other than the local disk.
	/// </param>
	public static RemapReport Apply(string root, ProjectRemapPlan plan, bool dryRun = true, string? backupDirectory = null, FileSystem? fileSystem = null)
	{
		fileSystem ??= LocalFileSystem.Instance;
		RemapReport report = new();

		if (plan.IsEmpty || !fileSystem.Directory.Exists(root))
		{
			return report;
		}

		foreach (string path in fileSystem.Directory.EnumerateFiles(root, "*", SearchOption.AllDirectories))
		{
			if (!RewritableExtensions.Contains(Path.GetExtension(path)))
			{
				continue;
			}

			string text;
			try
			{
				text = fileSystem.File.ReadAllText(path);
			}
			catch (IOException)
			{
				continue;
			}

			report.FilesScanned++;

			string rewritten = Rewrite(text, plan, report);
			if (string.Equals(rewritten, text, StringComparison.Ordinal))
			{
				continue;
			}

			report.FilesChanged++;

			if (dryRun)
			{
				continue;
			}

			if (backupDirectory is not null)
			{
				string backupPath = fileSystem.Path.Join(backupDirectory, MetaGuidScanner.GetRelativePath(root, path));
				fileSystem.Directory.Create(fileSystem.Path.GetDirectoryName(backupPath));
				fileSystem.File.WriteAllText(backupPath, text, Utf8NoBom);
			}

			// Unity's files are utf8 and it writes no byte order mark, so neither does this.
			fileSystem.File.WriteAllText(path, rewritten, Utf8NoBom);
		}

		return report;
	}
}
