using System.Resources;
using System.Runtime.CompilerServices;
using FxResources.System.Threading.Overlapped;

namespace System;

internal static class SR
{
	private static ResourceManager s_resourceManager;

	private const string s_resourcesName = "FxResources.System.Threading.Overlapped.SR";

	private static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(ResourceType));

	internal static string Argument_AlreadyBoundOrSyncHandle => GetResourceString("Argument_AlreadyBoundOrSyncHandle", null);

	internal static string Argument_InvalidHandle => GetResourceString("Argument_InvalidHandle", null);

	internal static string Argument_NativeOverlappedAlreadyFree => GetResourceString("Argument_NativeOverlappedAlreadyFree", null);

	internal static string Argument_NativeOverlappedWrongBoundHandle => GetResourceString("Argument_NativeOverlappedWrongBoundHandle", null);

	internal static string Argument_PreAllocatedAlreadyAllocated => GetResourceString("Argument_PreAllocatedAlreadyAllocated", null);

	internal static string InvalidOperation_NativeOverlappedReused => GetResourceString("InvalidOperation_NativeOverlappedReused", null);

	internal static Type ResourceType => typeof(FxResources.System.Threading.Overlapped.SR);

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool UsingResourceKeys()
	{
		return false;
	}

	internal static string GetResourceString(string resourceKey, string defaultString)
	{
		string text = null;
		try
		{
			text = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		if (defaultString != null && resourceKey.Equals(text, StringComparison.Ordinal))
		{
			return defaultString;
		}
		return text;
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}
}
