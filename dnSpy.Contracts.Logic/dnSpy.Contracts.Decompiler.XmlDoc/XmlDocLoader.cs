using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using dnlib.DotNet;

namespace dnSpy.Contracts.Decompiler.XmlDoc;

public static class XmlDocLoader
{
	private static readonly Lazy<XmlDocumentationProvider> mscorlibDocumentation;

	private static readonly ConditionalWeakTable<object, XmlDocumentationProvider> cache;

	private static readonly string[] refAsmPathsV4;

	private static readonly string referenceAssembliesPath;

	private static readonly string frameworkPath;

	private static readonly List<char> InvalidChars;

	public static XmlDocumentationProvider MscorlibDocumentation => mscorlibDocumentation.Value;

	private static XmlDocumentationProvider LoadMscorlibDocumentation()
	{
		string text = FindXmlDocumentation("mscorlib.dll", "v4.0.30319") ?? FindXmlDocumentation("mscorlib.dll", "v2.0.50727");
		if (text != null)
		{
			return XmlDocumentationProvider.Create(text);
		}
		return null;
	}

	public static XmlDocumentationProvider LoadDocumentation(ModuleDef module)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		return LoadDocumentation(module, module.Location, module.RuntimeVersion);
	}

	public static XmlDocumentationProvider LoadDocumentation(object key, string assemblyFilename, string runtimeVersion = null)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key");
		}
		if (assemblyFilename == null)
		{
			throw new ArgumentNullException("assemblyFilename");
		}
		lock (cache)
		{
			if (!cache.TryGetValue(key, out var value))
			{
				string text = LookupLocalizedXmlDoc(assemblyFilename);
				if (text == null)
				{
					text = FindXmlDocumentation(Path.GetFileName(assemblyFilename), runtimeVersion);
				}
				value = ((text == null) ? null : XmlDocumentationProvider.Create(text));
				cache.Add(key, value);
			}
			return value;
		}
	}

	static XmlDocLoader()
	{
		mscorlibDocumentation = new Lazy<XmlDocumentationProvider>(LoadMscorlibDocumentation);
		cache = new ConditionalWeakTable<object, XmlDocumentationProvider>();
		InvalidChars = new List<char>(Path.GetInvalidPathChars())
		{
			Path.PathSeparator,
			Path.VolumeSeparatorChar,
			Path.DirectorySeparatorChar,
			Path.AltDirectorySeparatorChar
		};
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
		if (string.IsNullOrEmpty(folderPath))
		{
			folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
		}
		referenceAssembliesPath = Path.Combine(folderPath, "Reference Assemblies", "Microsoft", "Framework");
		frameworkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET", "Framework");
		refAsmPathsV4 = GetReferenceV4PathsSortedByHighestestVersion();
	}

	private static string[] GetReferenceV4PathsSortedByHighestestVersion()
	{
		string path = Path.Combine(referenceAssembliesPath, ".NETFramework");
		List<(string, Version)> list = new List<(string, Version)>();
		string[] directories = GetDirectories(path);
		foreach (string text in directories)
		{
			string fileName = Path.GetFileName(text);
			if (fileName.StartsWith("v", StringComparison.OrdinalIgnoreCase) && Version.TryParse(fileName.Substring(1), out var result) && result.Major >= 4)
			{
				list.Add((text, result));
			}
		}
		return (from a in list
			orderby a.version descending
			select a.dir).ToArray();
	}

	private static string[] GetDirectories(string path)
	{
		if (!Directory.Exists(path))
		{
			return Array.Empty<string>();
		}
		try
		{
			return Directory.GetDirectories(path);
		}
		catch
		{
		}
		return Array.Empty<string>();
	}

	private static string FindXmlDocumentation(string assemblyFileName, string runtime)
	{
		if (string.IsNullOrEmpty(assemblyFileName))
		{
			return null;
		}
		if (runtime == null)
		{
			runtime = "v4.0.30319";
		}
		if (runtime.StartsWith("v1.x86") || runtime == "retail" || runtime == "COMPLUS")
		{
			runtime = "v1.0.3705";
		}
		runtime = FixRuntimeString(runtime);
		string result;
		if (runtime.StartsWith("v1.0"))
		{
			result = LookupLocalizedXmlDoc(Path.Combine(frameworkPath, runtime, assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v1.0.3705", assemblyFileName));
		}
		else if (runtime.StartsWith("v1.1"))
		{
			result = LookupLocalizedXmlDoc(Path.Combine(frameworkPath, runtime, assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v1.1.4322", assemblyFileName));
		}
		else if (runtime.StartsWith("v2.0"))
		{
			result = LookupLocalizedXmlDoc(Path.Combine(frameworkPath, runtime, assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v2.0.50727", assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, "v3.5", assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, "v3.0", assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, ".NETFramework", "v3.5", "Profile", "Client", assemblyFileName));
		}
		else
		{
			result = null;
			string[] array = refAsmPathsV4;
			foreach (string path in array)
			{
				result = LookupLocalizedXmlDoc(Path.Combine(path, assemblyFileName));
				if (result != null)
				{
					break;
				}
			}
			result = result ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, runtime, assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v4.0.30319", assemblyFileName));
		}
		return result;
	}

	private static string FixRuntimeString(string runtime)
	{
		int num = int.MaxValue;
		foreach (char invalidChar in InvalidChars)
		{
			int num2 = runtime.IndexOf(invalidChar);
			if (num2 >= 0 && num2 < num)
			{
				num = num2;
			}
		}
		if (num == int.MaxValue)
		{
			return runtime;
		}
		return runtime.Substring(0, num);
	}

	private static string LookupLocalizedXmlDoc(string assemblyFileName)
	{
		if (string.IsNullOrEmpty(assemblyFileName))
		{
			return null;
		}
		IEnumerable<string> xmlDocFileCandidates = GetXmlDocFileCandidates(assemblyFileName);
		return xmlDocFileCandidates.FirstOrDefault(File.Exists);
	}

	private static IEnumerable<string> GetXmlDocFileCandidates(string assemblyFileName)
	{
		string xmlFileName = Path.ChangeExtension(assemblyFileName, ".xml");
		yield return GetLocalizedXmlDocFile(xmlFileName, Thread.CurrentThread.CurrentUICulture.Name);
		yield return GetLocalizedXmlDocFile(xmlFileName, Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
		yield return xmlFileName;
		yield return GetLocalizedXmlDocFile(xmlFileName, "en");
	}

	private static string GetLocalizedXmlDocFile(string xmlFileName, string language)
	{
		string path = Path.Combine(Path.GetDirectoryName(xmlFileName), language);
		return Path.Combine(path, Path.GetFileName(xmlFileName));
	}
}
