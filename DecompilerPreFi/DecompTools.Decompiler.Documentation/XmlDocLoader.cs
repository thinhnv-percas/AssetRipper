#define DEBUG
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.Documentation;

public static class XmlDocLoader
{
	private static readonly Lazy<XmlDocumentationProvider> mscorlibDocumentation = new Lazy<XmlDocumentationProvider>(LoadMscorlibDocumentation);

	private static readonly ConditionalWeakTable<PEFile, XmlDocumentationProvider> cache = new ConditionalWeakTable<PEFile, XmlDocumentationProvider>();

	private static readonly string referenceAssembliesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Reference Assemblies\\Microsoft\\\\Framework");

	private static readonly string frameworkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "Microsoft.NET\\Framework");

	public static XmlDocumentationProvider MscorlibDocumentation => mscorlibDocumentation.Value;

	private static XmlDocumentationProvider LoadMscorlibDocumentation()
	{
		string text = FindXmlDocumentation("mscorlib.dll", TargetRuntime.Net_4_0) ?? FindXmlDocumentation("mscorlib.dll", TargetRuntime.Net_2_0);
		if (text != null)
		{
			return new XmlDocumentationProvider(text);
		}
		return null;
	}

	public static XmlDocumentationProvider LoadDocumentation(PEFile module)
	{
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		lock (cache)
		{
			if (!cache.TryGetValue(module, out var value))
			{
				string text = LookupLocalizedXmlDoc(module.FileName);
				if (text == null)
				{
					text = FindXmlDocumentation(Path.GetFileName(module.FileName), module.GetRuntime());
				}
				if (text != null)
				{
					value = new XmlDocumentationProvider(text);
					cache.Add(module, value);
				}
				else
				{
					cache.Add(module, null);
					value = null;
				}
			}
			return value;
		}
	}

	private static string FindXmlDocumentation(string assemblyFileName, TargetRuntime runtime)
	{
		return runtime switch
		{
			TargetRuntime.Net_1_0 => LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v1.0.3705", assemblyFileName)), 
			TargetRuntime.Net_1_1 => LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v1.1.4322", assemblyFileName)), 
			TargetRuntime.Net_2_0 => LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v2.0.50727", assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, "v3.5")) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, "v3.0")) ?? LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, ".NETFramework\\v3.5\\Profile\\Client")), 
			_ => LookupLocalizedXmlDoc(Path.Combine(referenceAssembliesPath, ".NETFramework\\v4.0", assemblyFileName)) ?? LookupLocalizedXmlDoc(Path.Combine(frameworkPath, "v4.0.30319", assemblyFileName)), 
		};
	}

	private static string LookupLocalizedXmlDoc(string fileName)
	{
		if (string.IsNullOrEmpty(fileName))
		{
			return null;
		}
		string text = Path.ChangeExtension(fileName, ".xml");
		string twoLetterISOLanguageName = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
		string localizedName = GetLocalizedName(text, twoLetterISOLanguageName);
		Debug.WriteLine("Try find XMLDoc @" + localizedName);
		if (File.Exists(localizedName))
		{
			return localizedName;
		}
		Debug.WriteLine("Try find XMLDoc @" + text);
		if (File.Exists(text))
		{
			return text;
		}
		if (twoLetterISOLanguageName != "en")
		{
			string localizedName2 = GetLocalizedName(text, "en");
			Debug.WriteLine("Try find XMLDoc @" + localizedName2);
			if (File.Exists(localizedName2))
			{
				return localizedName2;
			}
		}
		return null;
	}

	private static string GetLocalizedName(string fileName, string language)
	{
		string directoryName = Path.GetDirectoryName(fileName);
		directoryName = Path.Combine(directoryName, language);
		return Path.Combine(directoryName, Path.GetFileName(fileName));
	}
}
