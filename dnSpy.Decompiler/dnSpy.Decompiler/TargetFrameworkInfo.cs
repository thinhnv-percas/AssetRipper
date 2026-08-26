#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using dnlib.DotNet;

namespace dnSpy.Decompiler;

internal readonly struct TargetFrameworkInfo
{
	private enum Dnr2035Version
	{
		V20,
		V30,
		V35
	}

	private static HashSet<string> dotNet30Asms = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"ComSvcConfig, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "infocard, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Microsoft.Transactions.Bridge, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.Transactions.Bridge.Dtc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "PresentationBuildTasks, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationCFFRasterizer, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationFramework.Aero, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationFramework.Classic, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
		"PresentationFramework.Luna, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationFramework.Royale, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "PresentationUI, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "ReachFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "ServiceModelReg, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "SMSvcHost, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.IdentityModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.IdentityModel.Selectors, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.IO.Log, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Printing, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
		"System.Runtime.Serialization, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ServiceModel.Install, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.ServiceModel.WasHosting, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Speech, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Workflow.Activities, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Workflow.ComponentModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Workflow.Runtime, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "UIAutomationClient, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "UIAutomationClientsideProviders, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
		"UIAutomationProvider, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "UIAutomationTypes, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "WindowsFormsIntegration, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "WsatConfig, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
	};

	private static HashSet<string> dotNet35Asms = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"AddInProcess, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "AddInProcess32, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "AddInUtil, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "DataSvcUtil, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "EdmGen, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "Microsoft.Build.Conversion.v3.5, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.Build.Engine, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.Build.Framework, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.Build.Tasks.v3.5, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.Build.Utilities.v3.5, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
		"Microsoft.Data.Entity.Build.Tasks, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Microsoft.VisualC.STLCLR, Version=1.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "MSBuild, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "Sentinel.v3.5Client, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.AddIn, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.AddIn.Contract, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.DataAnnotations, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.DataSetExtensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
		"System.Data.Entity.Design, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.Services, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.Services.Client, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Data.Services.Design, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.DirectoryServices.AccountManagement, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Management.Instrumentation, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Net, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ServiceModel.Web, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Web.Abstractions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35",
		"System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Web.DynamicData.Design, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Web.Entity.Design, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Web.Extensions.Design, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Web.Routing, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Windows.Presentation, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.WorkflowServices, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35", "System.Xml.Linq, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
	};

	public bool IsDotNetFramework => Framework == ".NETFramework";

	public string Framework { get; }

	public string Version { get; }

	public string Profile { get; }

	public bool FromAttribute { get; }

	private TargetFrameworkInfo(string framework, string version, string profile, bool fromAttribute)
	{
		Framework = framework ?? throw new ArgumentNullException("framework");
		Version = version ?? throw new ArgumentNullException("version");
		Profile = profile;
		FromAttribute = fromAttribute;
	}

	public static TargetFrameworkInfo Create(ModuleDef module)
	{
		AssemblyDef assembly = module.Assembly;
		if (assembly != null && module.IsManifestModule)
		{
			TargetFrameworkInfo? targetFrameworkInfo = TryGetTargetFrameworkInfoInternal(assembly);
			if (targetFrameworkInfo.HasValue)
			{
				return targetFrameworkInfo.Value;
			}
		}
		if (module.IsClr10)
		{
			return new TargetFrameworkInfo(".NETFramework", "1.0", null, fromAttribute: false);
		}
		if (module.IsClr11)
		{
			return new TargetFrameworkInfo(".NETFramework", "1.1", null, fromAttribute: false);
		}
		if (module.IsClr20)
		{
			return new TargetFrameworkInfo(".NETFramework", GetDotNetVersion2035(module), null, fromAttribute: false);
		}
		if (module.IsClr40)
		{
			return new TargetFrameworkInfo(".NETFramework", "4.0", null, fromAttribute: false);
		}
		return new TargetFrameworkInfo(".NETFramework", "4.0", null, fromAttribute: false);
	}

	private static TargetFrameworkInfo? TryGetTargetFrameworkInfoInternal(AssemblyDef asm)
	{
		CustomAttribute customAttribute = asm.CustomAttributes.Find("System.Runtime.Versioning.TargetFrameworkAttribute");
		if (customAttribute == null)
		{
			return null;
		}
		if (customAttribute.ConstructorArguments.Count != 1)
		{
			return null;
		}
		CAArgument cAArgument = customAttribute.ConstructorArguments[0];
		if (cAArgument.Type.GetElementType() != ElementType.String)
		{
			return null;
		}
		UTF8String uTF8String = cAArgument.Value as UTF8String;
		if (UTF8String.IsNullOrEmpty(uTF8String))
		{
			return null;
		}
		return TryCreateFromAttributeString(uTF8String);
	}

	private static TargetFrameworkInfo? TryCreateFromAttributeString(string attrString)
	{
		string[] array = attrString.Split(',');
		if (array.Length < 2 || array.Length > 3)
		{
			return null;
		}
		string text = array[0].Trim();
		if (text.Length == 0)
		{
			return null;
		}
		string text2 = null;
		string profile = null;
		for (int i = 1; i < array.Length; i++)
		{
			string[] array2 = array[i].Split('=');
			if (array2.Length != 2)
			{
				return null;
			}
			string text3 = array2[0].Trim();
			string text4 = array2[1].Trim();
			if (text3.Equals("Version", StringComparison.OrdinalIgnoreCase))
			{
				if (text4.StartsWith("v", StringComparison.OrdinalIgnoreCase))
				{
					text4 = text4.Substring(1);
				}
				text2 = text4;
				if (!System.Version.TryParse(text4, out var _))
				{
					return null;
				}
			}
			else if (text3.Equals("Profile", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(text4))
			{
				profile = text4;
			}
		}
		if (text2 == null || text2.Length == 0)
		{
			return null;
		}
		return new TargetFrameworkInfo(text, text2, profile, fromAttribute: true);
	}

	private static string GetDotNetVersion2035(ModuleDef module)
	{
		Dnr2035Version dnr2035Version = Dnr2035Version.V20;
		foreach (ModuleDef module2 in GetModules(module))
		{
			dnr2035Version = Max(dnr2035Version, GetDotNetVersion2035Internal(module2));
			if (dnr2035Version == Dnr2035Version.V35)
			{
				return ToString(dnr2035Version);
			}
		}
		return ToString(dnr2035Version);
	}

	private static IEnumerable<ModuleDef> GetModules(ModuleDef module)
	{
		yield return module;
		foreach (AssemblyRef asmRef in module.GetAssemblyRefs())
		{
			AssemblyDef asm = module.Context.AssemblyResolver.Resolve(asmRef, module);
			if (asm != null)
			{
				yield return asm.ManifestModule;
			}
		}
	}

	private static Dnr2035Version Max(Dnr2035Version a, Dnr2035Version b)
	{
		return (a > b) ? a : b;
	}

	private static string ToString(Dnr2035Version v)
	{
		return v switch
		{
			Dnr2035Version.V20 => "2.0", 
			Dnr2035Version.V30 => "3.0", 
			Dnr2035Version.V35 => "3.5", 
			_ => throw new InvalidOperationException(), 
		};
	}

	private static Dnr2035Version GetDotNetVersion2035Internal(ModuleDef module)
	{
		Dnr2035Version result = Dnr2035Version.V20;
		foreach (AssemblyRef assemblyRef in module.GetAssemblyRefs())
		{
			if (dotNet35Asms.Contains(assemblyRef.FullName))
			{
				return Dnr2035Version.V35;
			}
			if (dotNet30Asms.Contains(assemblyRef.FullName))
			{
				result = Dnr2035Version.V30;
			}
		}
		AssemblyDef assembly = module.Assembly;
		if (assembly != null && module.IsManifestModule)
		{
			if (dotNet35Asms.Contains(assembly.FullName))
			{
				return Dnr2035Version.V35;
			}
			if (dotNet30Asms.Contains(assembly.FullName))
			{
				result = Dnr2035Version.V30;
			}
		}
		return result;
	}

	private string GetDisplayName()
	{
		if (Framework == null)
		{
			return null;
		}
		string text = GetFrameworkDisplayName();
		if (text == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(Profile))
		{
			text = text + " (" + Profile + ")";
		}
		return text;
	}

	private string GetFrameworkDisplayName()
	{
		switch (Framework)
		{
		case ".NETFramework":
		{
			string text = Version;
			if (text == "4.0")
			{
				text = "4";
			}
			return ".NET Framework " + text;
		}
		case ".NETPortable":
			return ".NET Portable " + Version;
		case ".NETCore":
			return ".NET Core " + Version;
		case ".NETCoreApp":
			return ".NET Core App " + Version;
		case ".NETPlatform":
			return ".NET Platform " + Version;
		case ".NETStandard":
			return ".NET Standard " + Version;
		case ".NETStandardApp":
			return ".NET Standard App " + Version;
		case "DNX":
			return "DNX " + Version;
		case "DNXCore":
			return "DNX Core " + Version;
		case "WindowsPhone":
			return "Windows Phone " + Version;
		case "WindowsPhoneApp":
			return "Windows Phone App " + Version;
		case "UAP":
			return "Universal App " + Version;
		case "Silverlight":
			return "Silverlight " + Version;
		case ".NETMicroFramework":
			return ".NET Micro Framework " + Version;
		case "WinRT":
			return "WinRT " + Version;
		case "Windows":
			return "Windows " + Version;
		case "CoreCLR":
			return "Core CLR " + Version;
		case "ASP.Net":
		case "ASP.NET":
			return "ASP.NET " + Version;
		case "ASP.NetCore":
		case "ASP.NETCore":
			return "ASP.NET Core " + Version;
		case "native":
			return "native " + Version;
		case "MonoAndroid":
			return "Mono Android " + Version;
		case "MonoTouch":
			return "Mono Touch " + Version;
		case "MonoMac":
			return "Mono Mac " + Version;
		case "Xamarin.iOS":
			return "Xamarin iOS " + Version;
		case "Xamarin.Mac":
			return "Xamarin Mac " + Version;
		case "Xamarin.PlayStation3":
			return "Xamarin PlayStation 3 " + Version;
		case "Xamarin.PlayStation4":
			return "Xamarin PlayStation 4 " + Version;
		case "Xamarin.PlayStationVita":
			return "Xamarin PlayStation Vita " + Version;
		case "Xamarin.Xbox360":
			return "Xamarin Xbox 360 " + Version;
		case "Xamarin.XboxOne":
			return "Xamarin Xbox One " + Version;
		case "Xamarin.TVOS":
			return "Xamarin TVOS " + Version;
		case "Xamarin.WatchOS":
			return "Xamarin WatchOS " + Version;
		default:
			Debug.Fail("Unknown target framework: " + Framework);
			if (Framework.Length > 20)
			{
				return null;
			}
			return Framework + " " + Version;
		}
	}

	public override string ToString()
	{
		return GetDisplayName();
	}
}
