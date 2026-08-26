#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using dnlib.DotNet;
using dnlib.PE;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Utilities;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class ProjectWriter
{
	private readonly Project project;

	private readonly ProjectVersion projectVersion;

	private readonly IList<Project> allProjects;

	private readonly IList<string> userGACPaths;

	public ProjectWriter(Project project, ProjectVersion projectVersion, IList<Project> allProjects, IList<string> userGACPaths)
	{
		this.project = project;
		this.projectVersion = projectVersion;
		this.allProjects = allProjects;
		this.userGACPaths = userGACPaths;
	}

	public void Write()
	{
		this.project.OnWrite();
		XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
		{
			Encoding = Encoding.UTF8,
			Indent = true
		};
		if (projectVersion == ProjectVersion.VS2005)
		{
			xmlWriterSettings.OmitXmlDeclaration = true;
		}
		using XmlWriter xmlWriter = XmlWriter.Create(this.project.Filename, xmlWriterSettings);
		this.project.Platform = GetPlatformString();
		xmlWriter.WriteStartDocument();
		xmlWriter.WriteStartElement("Project", "http://schemas.microsoft.com/developer/msbuild/2003");
		string toolsVersion = GetToolsVersion();
		if (toolsVersion != null)
		{
			xmlWriter.WriteAttributeString("ToolsVersion", toolsVersion);
		}
		if (projectVersion <= ProjectVersion.VS2015)
		{
			xmlWriter.WriteAttributeString("DefaultTargets", "Build");
		}
		if (projectVersion >= ProjectVersion.VS2012)
		{
			xmlWriter.WriteStartElement("Import");
			xmlWriter.WriteAttributeString("Project", "$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props");
			xmlWriter.WriteAttributeString("Condition", "Exists('$(MSBuildExtensionsPath)\\$(MSBuildToolsVersion)\\Microsoft.Common.props')");
			xmlWriter.WriteEndElement();
		}
		xmlWriter.WriteStartElement("PropertyGroup");
		xmlWriter.WriteStartElement("Configuration");
		xmlWriter.WriteAttributeString("Condition", " '$(Configuration)' == '' ");
		xmlWriter.WriteString("Debug");
		xmlWriter.WriteEndElement();
		xmlWriter.WriteStartElement("Platform");
		xmlWriter.WriteAttributeString("Condition", " '$(Platform)' == '' ");
		xmlWriter.WriteString(this.project.Platform);
		xmlWriter.WriteEndElement();
		xmlWriter.WriteElementString("ProjectGuid", this.project.Guid.ToString("B").ToUpperInvariant());
		xmlWriter.WriteElementString("OutputType", GetOutputType());
		string appDesignerFolder = GetAppDesignerFolder();
		if (appDesignerFolder != null)
		{
			xmlWriter.WriteElementString("AppDesignerFolder", appDesignerFolder);
		}
		xmlWriter.WriteElementString("RootNamespace", GetRootNamespace());
		string assemblyName = GetAssemblyName();
		if (!string.IsNullOrEmpty(assemblyName))
		{
			xmlWriter.WriteElementString("AssemblyName", GetAssemblyName());
		}
		TargetFrameworkInfo targetFrameworkInfo = TargetFrameworkInfo.Create(this.project.Module);
		if (projectVersion > ProjectVersion.VS2005 || !targetFrameworkInfo.IsDotNetFramework || targetFrameworkInfo.Version != "2.0")
		{
			xmlWriter.WriteElementString("TargetFrameworkVersion", "v" + targetFrameworkInfo.Version);
		}
		if (!string.IsNullOrEmpty(targetFrameworkInfo.Profile))
		{
			xmlWriter.WriteElementString("TargetFrameworkProfile", targetFrameworkInfo.Profile);
		}
		if (!targetFrameworkInfo.IsDotNetFramework)
		{
			xmlWriter.WriteElementString("TargetFrameworkIdentifier", targetFrameworkInfo.Framework);
		}
		xmlWriter.WriteElementString("FileAlignment", GetFileAlignment());
		if (this.project.ProjectTypeGuids.Count != 0)
		{
			string value = string.Join(";", this.project.ProjectTypeGuids.Select((Guid a) => a.ToString("B").ToUpperInvariant()).ToArray());
			xmlWriter.WriteElementString("ProjectTypeGuids", value);
		}
		if (this.project.ApplicationManifest != null)
		{
			xmlWriter.WriteElementString("ApplicationManifest", GetRelativePath(this.project.ApplicationManifest.Filename));
		}
		if (this.project.ApplicationIcon != null)
		{
			xmlWriter.WriteElementString("ApplicationIcon", GetRelativePath(this.project.ApplicationIcon.Filename));
		}
		if (this.project.StartupObject != null)
		{
			xmlWriter.WriteElementString("StartupObject", this.project.StartupObject);
		}
		xmlWriter.WriteEndElement();
		string noWarnList = GetNoWarnList();
		xmlWriter.WriteStartElement("PropertyGroup");
		xmlWriter.WriteAttributeString("Condition", $" '$(Configuration)|$(Platform)' == 'Debug|{this.project.Platform}' ");
		xmlWriter.WriteElementString("PlatformTarget", this.project.Platform);
		xmlWriter.WriteElementString("DebugSymbols", "true");
		xmlWriter.WriteElementString("DebugType", "full");
		xmlWriter.WriteElementString("Optimize", "false");
		xmlWriter.WriteElementString("OutputPath", "bin\\Debug\\");
		xmlWriter.WriteElementString("DefineConstants", "DEBUG;TRACE");
		xmlWriter.WriteElementString("ErrorReport", "prompt");
		xmlWriter.WriteElementString("WarningLevel", "4");
		if (this.project.Options.DontReferenceStdLib)
		{
			xmlWriter.WriteElementString("NoStdLib", "true");
		}
		if (this.project.AllowUnsafeBlocks)
		{
			xmlWriter.WriteElementString("AllowUnsafeBlocks", "true");
		}
		if (noWarnList != null)
		{
			xmlWriter.WriteElementString("NoWarn", noWarnList);
		}
		xmlWriter.WriteEndElement();
		xmlWriter.WriteStartElement("PropertyGroup");
		xmlWriter.WriteAttributeString("Condition", $" '$(Configuration)|$(Platform)' == 'Release|{this.project.Platform}' ");
		xmlWriter.WriteElementString("PlatformTarget", this.project.Platform);
		xmlWriter.WriteElementString("DebugType", "pdbonly");
		xmlWriter.WriteElementString("Optimize", "true");
		xmlWriter.WriteElementString("OutputPath", "bin\\Release\\");
		xmlWriter.WriteElementString("DefineConstants", "TRACE");
		xmlWriter.WriteElementString("ErrorReport", "prompt");
		xmlWriter.WriteElementString("WarningLevel", "4");
		if (this.project.Options.DontReferenceStdLib)
		{
			xmlWriter.WriteElementString("NoStdLib", "true");
		}
		if (this.project.AllowUnsafeBlocks)
		{
			xmlWriter.WriteElementString("AllowUnsafeBlocks", "true");
		}
		if (noWarnList != null)
		{
			xmlWriter.WriteElementString("NoWarn", noWarnList);
		}
		xmlWriter.WriteEndElement();
		AssemblyRef[] array = (from a in this.project.Module.GetAssemblyRefs()
			where a.Name != "mscorlib"
			select a).OrderBy((AssemblyRef a) => a.Name.String, StringComparer.OrdinalIgnoreCase).ToArray();
		if (array.Length != 0 || this.project.ExtraAssemblyReferences.Count > 0)
		{
			xmlWriter.WriteStartElement("ItemGroup");
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			AssemblyRef[] array2 = array;
			foreach (AssemblyRef assemblyRef in array2)
			{
				AssemblyDef assemblyDef = this.project.Module.Context.AssemblyResolver.Resolve(assemblyRef, this.project.Module);
				if (assemblyDef == null || !ExistsInProject(assemblyDef.ManifestModule.Location))
				{
					hashSet.Add(assemblyRef.Name);
					xmlWriter.WriteStartElement("Reference");
					xmlWriter.WriteAttributeString("Include", IdentifierEscaper.Escape(assemblyRef.Name));
					string hintPath = GetHintPath(assemblyDef);
					if (hintPath != null)
					{
						xmlWriter.WriteElementString("HintPath", hintPath);
					}
					xmlWriter.WriteEndElement();
				}
			}
			foreach (string extraAssemblyReference in this.project.ExtraAssemblyReferences)
			{
				if (!hashSet.Contains(extraAssemblyReference) && !AssemblyExistsInProject(extraAssemblyReference))
				{
					hashSet.Add(extraAssemblyReference);
					xmlWriter.WriteStartElement("Reference");
					xmlWriter.WriteAttributeString("Include", IdentifierEscaper.Escape(extraAssemblyReference));
					xmlWriter.WriteEndElement();
				}
			}
			xmlWriter.WriteEndElement();
		}
		xmlWriter.WriteStartElement("ItemGroup");
		xmlWriter.WriteStartElement("AppDesigner");
		xmlWriter.WriteAttributeString("Include", this.project.PropertiesFolder + "\\");
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndElement();
		Write(xmlWriter, BuildAction.Compile);
		Write(xmlWriter, BuildAction.EmbeddedResource);
		Project[] array3 = (from a in this.project.Module.GetAssemblyRefs()
			select this.project.Module.Context.AssemblyResolver.Resolve(a, this.project.Module) into a
			select (a == null) ? null : FindOtherProject(a.ManifestModule.Location) into a
			where a != null
			select a).OrderBy((Project a) => a.Filename, StringComparer.OrdinalIgnoreCase).ToArray();
		if (array3.Length != 0)
		{
			xmlWriter.WriteStartElement("ItemGroup");
			Project[] array4 = array3;
			foreach (Project project in array4)
			{
				xmlWriter.WriteStartElement("ProjectReference");
				xmlWriter.WriteAttributeString("Include", GetRelativePath(project.Filename));
				xmlWriter.WriteStartElement("Project");
				string text = project.Guid.ToString("B");
				if (projectVersion < ProjectVersion.VS2012)
				{
					text = text.ToUpperInvariant();
				}
				xmlWriter.WriteString(text);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("Name");
				xmlWriter.WriteString(IdentifierEscaper.Escape((project.Module.Assembly == null) ? string.Empty : project.Module.Assembly.Name.String));
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
		Write(xmlWriter, BuildAction.None);
		Write(xmlWriter, BuildAction.ApplicationDefinition);
		Write(xmlWriter, BuildAction.Page);
		Write(xmlWriter, BuildAction.Resource);
		Write(xmlWriter, BuildAction.SplashScreen);
		xmlWriter.WriteStartElement("Import");
		xmlWriter.WriteAttributeString("Project", GetLanguageTargets());
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndDocument();
	}

	private static string GetRelativePath(string sourceDir, string destFile)
	{
		string text = FilenameUtils.GetRelativePath(sourceDir, destFile);
		if (Path.DirectorySeparatorChar != '\\')
		{
			text = text.Replace(Path.DirectorySeparatorChar, '\\');
		}
		if (Path.AltDirectorySeparatorChar != '\\')
		{
			text = text.Replace(Path.AltDirectorySeparatorChar, '\\');
		}
		return text;
	}

	private string GetRelativePath(string filename)
	{
		return GetRelativePath(project.Directory, filename);
	}

	private void Write(XmlWriter writer, BuildAction buildAction)
	{
		ProjectFile[] array = project.Files.Where((ProjectFile a) => a.BuildAction == buildAction).OrderBy((ProjectFile a) => a.Filename, StringComparer.OrdinalIgnoreCase).ToArray();
		if (array.Length == 0)
		{
			return;
		}
		writer.WriteStartElement("ItemGroup");
		ProjectFile[] array2 = array;
		foreach (ProjectFile projectFile in array2)
		{
			if (projectFile.BuildAction != BuildAction.DontIncludeInProjectFile)
			{
				writer.WriteStartElement(ToString(buildAction));
				writer.WriteAttributeString("Include", GetRelativePath(projectFile.Filename));
				if (projectFile.DependentUpon != null)
				{
					writer.WriteElementString("DependentUpon", GetRelativePath(Path.GetDirectoryName(projectFile.Filename), projectFile.DependentUpon.Filename));
				}
				if (projectFile.SubType != null)
				{
					writer.WriteElementString("SubType", projectFile.SubType);
				}
				if (projectFile.Generator != null)
				{
					writer.WriteElementString("Generator", projectFile.Generator);
				}
				if (projectFile.LastGenOutput != null)
				{
					writer.WriteElementString("LastGenOutput", GetRelativePath(Path.GetDirectoryName(projectFile.Filename), projectFile.LastGenOutput.Filename));
				}
				if (projectFile.AutoGen)
				{
					writer.WriteElementString("AutoGen", "True");
				}
				if (projectFile.DesignTime)
				{
					writer.WriteElementString("DesignTime", "True");
				}
				if (projectFile.DesignTimeSharedInput)
				{
					writer.WriteElementString("DesignTimeSharedInput", "True");
				}
				writer.WriteEndElement();
			}
		}
		writer.WriteEndElement();
	}

	private static string ToString(BuildAction buildAction)
	{
		return buildAction switch
		{
			BuildAction.None => "None", 
			BuildAction.Compile => "Compile", 
			BuildAction.EmbeddedResource => "EmbeddedResource", 
			BuildAction.ApplicationDefinition => "ApplicationDefinition", 
			BuildAction.Page => "Page", 
			BuildAction.Resource => "Resource", 
			BuildAction.SplashScreen => "SplashScreen", 
			_ => throw new InvalidOperationException(), 
		};
	}

	private string GetToolsVersion()
	{
		return projectVersion switch
		{
			ProjectVersion.VS2005 => null, 
			ProjectVersion.VS2008 => "3.5", 
			ProjectVersion.VS2010 => "4.0", 
			ProjectVersion.VS2012 => "4.0", 
			ProjectVersion.VS2013 => "12.0", 
			ProjectVersion.VS2015 => "14.0", 
			ProjectVersion.VS2017 => "15.0", 
			_ => throw new InvalidOperationException(), 
		};
	}

	private string GetPlatformString()
	{
		Machine machine = project.Module.Machine;
		if (machine.IsI386())
		{
			switch ((project.Module.Is32BitRequired ? 2 : 0) + (project.Module.Is32BitPreferred ? 1 : 0))
			{
			case 0:
				if (!project.Module.IsILOnly)
				{
					return "x86";
				}
				return "AnyCPU";
			case 2:
				return "x86";
			case 3:
				return "AnyCPU";
			default:
				return "AnyCPU";
			}
		}
		if (machine.IsAMD64())
		{
			return "x64";
		}
		if (machine == Machine.IA64)
		{
			return "Itanium";
		}
		if (machine.IsARMNT())
		{
			return "ARM";
		}
		if (machine.IsARM64())
		{
			return "ARM64";
		}
		Debug.Fail("Unknown machine");
		return machine.ToString();
	}

	private string GetOutputType()
	{
		if (project.Module.IsWinMD)
		{
			return "WinMDObj";
		}
		switch (project.Module.Kind)
		{
		case ModuleKind.Console:
			return "Exe";
		case ModuleKind.Windows:
			return "WinExe";
		case ModuleKind.Dll:
			return "Library";
		case ModuleKind.NetModule:
			return "Module";
		default:
			Debug.Fail("Unknown module kind: " + project.Module.Kind);
			return "Library";
		}
	}

	private string GetAppDesignerFolder()
	{
		if (project.Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return null;
		}
		if (projectVersion >= ProjectVersion.VS2017)
		{
			return null;
		}
		return project.PropertiesFolder;
	}

	private string GetNoWarnList()
	{
		if (project.Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return "41999,42016,42017,42018,42019,42020,42021,42022,42032,42036,42314";
		}
		return null;
	}

	private string GetRootNamespace()
	{
		if (!string.IsNullOrEmpty(project.DefaultNamespace))
		{
			return project.DefaultNamespace;
		}
		return GetAssemblyName();
	}

	private string GetAssemblyName()
	{
		return project.AssemblyName;
	}

	private string GetFileAlignment()
	{
		if (project.Module is ModuleDefMD moduleDefMD)
		{
			return moduleDefMD.Metadata.PEImage.ImageNTHeaders.OptionalHeader.FileAlignment.ToString();
		}
		return "512";
	}

	private string GetLanguageTargets()
	{
		if (project.Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_CSHARP)
		{
			return "$(MSBuildToolsPath)\\Microsoft.CSharp.targets";
		}
		if (project.Options.Decompiler.GenericGuid == DecompilerConstants.LANGUAGE_VISUALBASIC)
		{
			return "$(MSBuildToolsPath)\\Microsoft.VisualBasic.targets";
		}
		return "$(MSBuildToolsPath)\\Microsoft.CSharp.targets";
	}

	private string GetHintPath(AssemblyDef asm)
	{
		if (asm == null)
		{
			return null;
		}
		if (IsGacPath(asm.ManifestModule.Location))
		{
			return null;
		}
		if (ExistsInProject(asm.ManifestModule.Location))
		{
			return null;
		}
		return GetRelativePath(asm.ManifestModule.Location);
	}

	private bool IsGacPath(string file)
	{
		return GacInfo.IsGacPath(file) || IsUserGacPath(file);
	}

	private bool IsUserGacPath(string file)
	{
		file = file.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
		foreach (string userGACPath in userGACPaths)
		{
			if (file.StartsWith(userGACPath + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private bool ExistsInProject(string filename)
	{
		return FindOtherProject(filename) != null;
	}

	private bool AssemblyExistsInProject(string asmSimpleName)
	{
		return allProjects.Any((Project a) => StringComparer.OrdinalIgnoreCase.Equals(a.AssemblyName, asmSimpleName));
	}

	private Project FindOtherProject(string filename)
	{
		return allProjects.FirstOrDefault((Project f) => StringComparer.OrdinalIgnoreCase.Equals(Path.GetFullPath(f.Module.Location), Path.GetFullPath(filename)));
	}
}
