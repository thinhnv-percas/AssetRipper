#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace dnSpy.Contracts.Resources;

public static class ResourceHelper
{
	private const string PREFIX = "res:";

	private static ResourceManagerTokenCache resourceManagerTokenCache;

	private static readonly Dictionary<Assembly, ResourceManager> asmToMgr = new Dictionary<Assembly, ResourceManager>();

	internal static void SetResourceManagerTokenCache(ResourceManagerTokenCache tokenCache)
	{
		if (tokenCache == null)
		{
			throw new ArgumentNullException("tokenCache");
		}
		if (resourceManagerTokenCache != null)
		{
			throw new InvalidOperationException();
		}
		resourceManagerTokenCache = tokenCache;
	}

	public static string GetString(object obj, string value)
	{
		Debug.Assert(resourceManagerTokenCache != null);
		if (obj == null)
		{
			throw new ArgumentNullException("obj");
		}
		if (value == null || !value.StartsWith("res:"))
		{
			return value;
		}
		string name = value.Substring("res:".Length);
		ResourceManager resourceManager = GetResourceManager((obj as Assembly) ?? obj.GetType().Assembly);
		if (resourceManager == null)
		{
			return "???";
		}
		string text = resourceManager.GetString(name);
		Debug.Assert(text != null);
		return text ?? "???";
	}

	private static ResourceManager GetResourceManager(Assembly assembly)
	{
		if (asmToMgr.TryGetValue(assembly, out var value))
		{
			return value;
		}
		ResourceManagerTokenCache resourceManagerTokenCache = ResourceHelper.resourceManagerTokenCache;
		Debug.Assert(resourceManagerTokenCache != null);
		if (resourceManagerTokenCache != null && resourceManagerTokenCache.TryGetResourceManagerGetMethodMetadataToken(assembly, out var getMethodMetadataToken))
		{
			MethodInfo m;
			try
			{
				m = assembly.ManifestModule.ResolveMethod(getMethodMetadataToken) as MethodInfo;
			}
			catch (ArgumentException)
			{
				Debug.Fail("Couldn't resolve resource manager getter method");
				m = null;
			}
			value = TrySetResourceManager(assembly, m, save: false);
			if (value != null)
			{
				return value;
			}
		}
		Type[] types = assembly.ManifestModule.GetTypes();
		foreach (Type type in types)
		{
			if (type.Namespace == null || !type.Namespace.EndsWith(".Properties", StringComparison.InvariantCultureIgnoreCase))
			{
				continue;
			}
			PropertyInfo property = type.GetProperty("ResourceManager", BindingFlags.Static | BindingFlags.Public);
			if (!(property == null))
			{
				MethodInfo getMethod = property.GetGetMethod();
				value = TrySetResourceManager(assembly, getMethod, save: true);
				if (value != null)
				{
					return value;
				}
			}
		}
		Debug.Fail($"Failed to find the class with the ResourceManager property in assembly {assembly}");
		return null;
	}

	private static ResourceManager TrySetResourceManager(Assembly assembly, MethodInfo m, bool save)
	{
		if (m == null)
		{
			return null;
		}
		if (!m.IsStatic)
		{
			return null;
		}
		if (m.ReturnType != typeof(ResourceManager))
		{
			return null;
		}
		if (m.GetParameters().Length != 0)
		{
			return null;
		}
		ResourceManager resourceManager;
		try
		{
			resourceManager = m.Invoke(null, Array.Empty<object>()) as ResourceManager;
		}
		catch
		{
			return null;
		}
		if (save)
		{
			resourceManagerTokenCache?.SetResourceManagerGetMethodMetadataToken(assembly, m.MetadataToken);
		}
		asmToMgr[assembly] = resourceManager;
		return resourceManager;
	}
}
