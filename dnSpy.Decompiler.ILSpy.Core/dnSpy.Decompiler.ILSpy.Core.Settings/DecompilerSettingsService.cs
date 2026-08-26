using System.Threading;

namespace dnSpy.Decompiler.ILSpy.Core.Settings;

internal class DecompilerSettingsService
{
	private static DecompilerSettingsService __instance_DONT_USE;

	public static DecompilerSettingsService __Instance_DONT_USE
	{
		get
		{
			if (__instance_DONT_USE == null)
			{
				Interlocked.CompareExchange(ref __instance_DONT_USE, new DecompilerSettingsService(), null);
			}
			return __instance_DONT_USE;
		}
	}

	public CSharpVBDecompilerSettings CSharpVBDecompilerSettings { get; protected set; }

	public ILDecompilerSettings ILDecompilerSettings { get; protected set; }

	protected DecompilerSettingsService()
	{
		CSharpVBDecompilerSettings = new CSharpVBDecompilerSettings();
		ILDecompilerSettings = new ILDecompilerSettings();
	}
}
