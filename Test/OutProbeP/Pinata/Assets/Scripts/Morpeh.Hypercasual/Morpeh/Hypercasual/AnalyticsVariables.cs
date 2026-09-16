using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;

namespace Morpeh.Hypercasual
{
	[CVarContainer]
	[Token(Token = "0x2000004")]
	public static class AnalyticsVariables
	{
		[Token(Token = "0x4000005")]
		public static readonly CVar FirebaseAppID;

		[Token(Token = "0x4000006")]
		public static readonly CVar FirebaseAppKey;

		[Token(Token = "0x4000007")]
		public static readonly CVar AppMetricaAndroid;

		[Token(Token = "0x4000008")]
		public static readonly CVar AppMetricaiOS;

		[Token(Token = "0x4000009")]
		public static readonly CVar Adjust;

		[Token(Token = "0x400000A")]
		public static readonly CVar Tenjin;

		[Token(Token = "0x400000B")]
		public static readonly CVar AppsFlyerAppID;

		[Token(Token = "0x400000C")]
		public static readonly CVar AppsFlyerDevKey;

		[Token(Token = "0x400000D")]
		public static readonly CVar MyTrackeriOS;

		[Token(Token = "0x400000E")]
		public static readonly CVar MyTrackerAndroid;

		[Token(Token = "0x400000F")]
		public static readonly CVar FacebookAppId;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x1632E70", Offset = "0x1632E70", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1ECFF18]);\n\tv23 = *([v22 @ X8_v70]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 0 | 1;\n\t*([202A4D7]) = v43;\nL_001D:\n\tv52 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v52, \"FirebaseAppID\", v48.Empty, 0);\n\tv63.FirebaseAppID = v52;\n\tv68 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v68, \"FirebaseAppKey\", v66.Empty, 0);\n\tv77.FirebaseAppKey = v68;\n\tv82 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v82, \"AppMetricaAndroid\", v80.Empty, 0);\n\tv91.AppMetricaAndroid = v82;\n\tv96 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v96, \"AppMetricaiOS\", v94.Empty, 0);\n\tv105.AppMetricaiOS = v96;\n\tv110 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v110, \"Adjust\", v108.Empty, 0);\n\tv119.Adjust = v110;\n\tv124 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v124, \"Tenjin\", v122.Empty, 0);\n\tv133.Tenjin = v124;\n\tv138 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v138, \"AppsFlyerAppID\", v136.Empty, 0);\n\tv147.AppsFlyerAppID = v138;\n\tv152 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v152, \"AppsFlyerDevKey\", v150.Empty, 0);\n\tv161.AppsFlyerDevKey = v152;\n\tv166 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v166, \"MyTrackeriOS\", v164.Empty, 0);\n\tv175.MyTrackeriOS = v166;\n\tv180 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v180, \"MyTrackerAndroid\", v178.Empty, 0);\n\tv189.MyTrackerAndroid = v180;\n\tv194 = new LunarConsolePlugin.CVar();\n\tLunarConsolePlugin.CVar::.ctor(v194, \"FacebookAppId\", v192.Empty, 0);\n\tv203.FacebookAppId = v194;\n\treturn;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static AnalyticsVariables()
		{
			CVar firebaseAppID = new CVar("FirebaseAppID", string.Empty);
			FirebaseAppID = firebaseAppID;
			CVar firebaseAppKey = new CVar("FirebaseAppKey", string.Empty);
			FirebaseAppKey = firebaseAppKey;
			CVar appMetricaAndroid = new CVar("AppMetricaAndroid", string.Empty);
			AppMetricaAndroid = appMetricaAndroid;
			CVar appMetricaiOS = new CVar("AppMetricaiOS", string.Empty);
			AppMetricaiOS = appMetricaiOS;
			CVar adjust = new CVar("Adjust", string.Empty);
			Adjust = adjust;
			CVar tenjin = new CVar("Tenjin", string.Empty);
			Tenjin = tenjin;
			CVar appsFlyerAppID = new CVar("AppsFlyerAppID", string.Empty);
			AppsFlyerAppID = appsFlyerAppID;
			CVar appsFlyerDevKey = new CVar("AppsFlyerDevKey", string.Empty);
			AppsFlyerDevKey = appsFlyerDevKey;
			CVar myTrackeriOS = new CVar("MyTrackeriOS", string.Empty);
			MyTrackeriOS = myTrackeriOS;
			CVar myTrackerAndroid = new CVar("MyTrackerAndroid", string.Empty);
			MyTrackerAndroid = myTrackerAndroid;
			CVar facebookAppId = new CVar("FacebookAppId", string.Empty);
			FacebookAppId = facebookAppId;
		}
	}
}
