public class DevXSystemInfo
{
	public static string Platform;

	public static bool IsMobilePlatform;

	public static bool IsUnityEditor;

	public static bool IsWin_Unity;

	public static bool IsWin_Forms;

	public static bool IsWin_OS;

	public static bool IsMAC_OS;

	public static bool IsLinux_OS;

	public static bool IsAndroid_OS;

	public static bool IsIOS_OS;

	public static string DeviceName;

	public static string UserName;

	public static string UnpackerRootDirectory;

	public static string FullExecuteblePath;

	public static string TempPath;

	public static bool Is64BitProcess;

	public static string OSVersion = "";

	public static string CurrentCulture = "en";

	public static string LocalApplicationData = ".";

	public static string PersistentDataPath = ".";

	public static string LocalizationDir = ".";

	public static string LogDir = ".";

	public static string PluginsDir = ".";

	public static string StreamingAssets;

	public static string MachineName => DeviceName;
}
