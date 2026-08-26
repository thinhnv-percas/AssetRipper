using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using dnlib.PE;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class SolutionWriter
{
	private readonly ProjectVersion projectVersion;

	private readonly List<Project> projects;

	private readonly string filename;

	private readonly List<string> configs;

	private readonly List<string> platforms;

	public SolutionWriter(ProjectVersion projectVersion, IList<Project> projects, string filename)
	{
		this.projectVersion = projectVersion;
		this.projects = projects.ToList();
		this.projects.Sort(delegate(Project a, Project b)
		{
			int num = (((a.Module.Characteristics & Characteristics.Dll) != 0) ? 1 : 0);
			int value = (((b.Module.Characteristics & Characteristics.Dll) != 0) ? 1 : 0);
			int num2 = num.CompareTo(value);
			return (num2 != 0) ? num2 : StringComparer.OrdinalIgnoreCase.Compare(a.Filename, b.Filename);
		});
		this.filename = filename;
		configs = new List<string>();
		configs.Add("Debug");
		configs.Add("Release");
		HashSet<string> hashSet = new HashSet<string>(projects.Select((Project a) => a.Platform));
		platforms = new List<string>(hashSet.Count);
		platforms.Add("Any CPU");
		hashSet.Remove("AnyCPU");
		if (hashSet.Count > 0)
		{
			platforms.Add("Mixed Platforms");
		}
		foreach (string item in hashSet)
		{
			platforms.Add(item);
		}
	}

	public void Write()
	{
		Directory.CreateDirectory(Path.GetDirectoryName(filename));
		using StreamWriter streamWriter = new StreamWriter(filename, append: false, Encoding.UTF8);
		streamWriter.Write("\r\n");
		switch (projectVersion)
		{
		case ProjectVersion.VS2005:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 9.00\r\n");
			streamWriter.Write("# Visual Studio 2005\r\n");
			break;
		case ProjectVersion.VS2008:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 10.00\r\n");
			streamWriter.Write("# Visual Studio 2008\r\n");
			break;
		case ProjectVersion.VS2010:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 11.00\r\n");
			streamWriter.Write("# Visual Studio 2010\r\n");
			break;
		case ProjectVersion.VS2012:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 12.00\r\n");
			streamWriter.Write("# Visual Studio 2012\r\n");
			break;
		case ProjectVersion.VS2013:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 12.00\r\n");
			streamWriter.Write("# Visual Studio 2013\r\n");
			streamWriter.Write("VisualStudioVersion = 12.0.21005.1\r\n");
			streamWriter.Write("MinimumVisualStudioVersion = 10.0.40219.1\r\n");
			break;
		case ProjectVersion.VS2015:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 12.00\r\n");
			streamWriter.Write("# Visual Studio 14\r\n");
			streamWriter.Write("VisualStudioVersion = 14.0.23107.0\r\n");
			streamWriter.Write("MinimumVisualStudioVersion = 10.0.40219.1\r\n");
			break;
		case ProjectVersion.VS2017:
			streamWriter.Write("Microsoft Visual Studio Solution File, Format Version 12.00\r\n");
			streamWriter.Write("# Visual Studio 15\r\n");
			streamWriter.Write("VisualStudioVersion = 15.0.26228.4\r\n");
			streamWriter.Write("MinimumVisualStudioVersion = 10.0.40219.1\r\n");
			break;
		default:
			throw new InvalidOperationException();
		}
		foreach (Project project in projects)
		{
			streamWriter.Write("Project(\"{0}\") = \"{1}\", \"{1}\\{2}\", \"{3}\"\r\n", project.LanguageGuid.ToString("B").ToUpperInvariant(), Path.GetFileName(Path.GetDirectoryName(project.Filename)), Path.GetFileName(project.Filename), project.Guid.ToString("B").ToUpperInvariant());
			streamWriter.Write("EndProject\r\n");
		}
		streamWriter.Write("Global\r\n");
		streamWriter.Write("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution\r\n");
		foreach (string config in configs)
		{
			foreach (string platform in platforms)
			{
				streamWriter.Write("\t\t{0}|{1} = {0}|{1}\r\n", config, platform);
			}
		}
		streamWriter.Write("\tEndGlobalSection\r\n");
		streamWriter.Write("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution\r\n");
		foreach (Project project2 in projects)
		{
			string text = project2.Guid.ToString("B").ToUpperInvariant();
			string text2 = (project2.Platform.Equals("AnyCPU") ? "Any CPU" : project2.Platform);
			foreach (string config2 in configs)
			{
				foreach (string platform2 in platforms)
				{
					streamWriter.Write("\t\t{0}.{1}|{2}.ActiveCfg = {1}|{3}\r\n", text, config2, platform2, text2);
					streamWriter.Write("\t\t{0}.{1}|{2}.Build.0 = {1}|{3}\r\n", text, config2, platform2, text2);
				}
			}
		}
		streamWriter.Write("\tEndGlobalSection\r\n");
		streamWriter.Write("\tGlobalSection(SolutionProperties) = preSolution\r\n");
		streamWriter.Write("\t\tHideSolutionNode = FALSE\r\n");
		streamWriter.Write("\tEndGlobalSection\r\n");
		streamWriter.Write("EndGlobal\r\n");
	}
}
