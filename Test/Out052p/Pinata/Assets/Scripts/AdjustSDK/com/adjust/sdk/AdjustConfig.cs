using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x200000C")]
	public class AdjustConfig
	{
		[Token(Token = "0x400002A")]
		public const string AdjustAdRevenueSourceMopub = "mopub";

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x10")]
		internal string appToken;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x18")]
		internal string sceneName;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x20")]
		internal string userAgent;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x28")]
		internal string defaultTracker;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x30")]
		internal long? info1;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x40")]
		internal long? info2;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x50")]
		internal long? info3;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x60")]
		internal long? info4;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x70")]
		internal long? secretId;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x80")]
		internal double? delayStart;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x90")]
		internal bool? isDeviceKnown;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x92")]
		internal bool? sendInBackground;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x94")]
		internal bool? eventBufferingEnabled;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x96")]
		internal bool? allowSuppressLogLevel;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x98")]
		internal bool launchDeferredDeeplink;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x9C")]
		internal AdjustLogLevel? logLevel;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0xA4")]
		internal AdjustEnvironment environment;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0xA8")]
		internal Action<string> deferredDeeplinkDelegate;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0xB0")]
		internal Action<AdjustEventSuccess> eventSuccessDelegate;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0xB8")]
		internal Action<AdjustEventFailure> eventFailureDelegate;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0xC0")]
		internal Action<AdjustSessionSuccess> sessionSuccessDelegate;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0xC8")]
		internal Action<AdjustSessionFailure> sessionFailureDelegate;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0xD0")]
		internal Action<AdjustAttribution> attributionChangedDelegate;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0xD8")]
		internal bool? readImei;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0xE0")]
		internal string processName;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0xE8")]
		internal Action<string> logDelegate;

		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x156D434", Offset = "0x156D434", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0E930]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, appToken, environment, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20290B4]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.environment = environment;\n\tthis.appToken = appToken;\n\tthis.sceneName = \"\";\n\tthis.processName = \"\";\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustConfig(string appToken, AdjustEnvironment environment)
		{
			this.environment = environment;
			this.appToken = appToken;
			sceneName = "";
			processName = "";
		}

		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x1565B24", Offset = "0x1565B24", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv30 = *([1EC60B0]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, appToken, environment, allowSuppressLogLevel, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20290B5]) = v47;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tthis.environment = environment;\n\tthis.appToken = appToken;\n\tthis.sceneName = \"\";\n\tthis.processName = \"\";\n\tv54 = 0;\n\tv59 = 0x115B1C8(&v54 @ stack_-34_v1 (System.Nullable`1<System.Boolean>), allowSuppressLogLevel, Il2CppMethodInfo, allowSuppressLogLevel, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tthis.allowSuppressLogLevel = 0;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdjustConfig(string appToken, AdjustEnvironment environment, bool allowSuppressLogLevel)
		{
			this.environment = environment;
			this.appToken = appToken;
			sceneName = "";
			processName = "";
			bool? flag = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B1C8 (inside System.Linq.Set`1<System.Object>::InternalGetHashCode +0xC8)");
			this.allowSuppressLogLevel = null;
		}

		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x1565BC8", Offset = "0x1565BC8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC0220]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, logLevel, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290B6]) = v41;\nL_0019:\n\tv45 = 0;\n\tv48 = System.Nullable`1<com.adjust.sdk.AdjustLogLevel>::.ctor(&v45 @ stack_-28_v1 (System.Nullable`1<com.adjust.sdk.AdjustLogLevel>), logLevel);\n\tthis.logLevel = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setLogLevel(AdjustLogLevel logLevel)
		{
			AdjustLogLevel? adjustLogLevel = null;
			adjustLogLevel = logLevel;
			this.logLevel = null;
		}

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x156D4A8", Offset = "0x156D4A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.defaultTracker = defaultTracker;\n\treturn;\n")]
		public void setDefaultTracker(string defaultTracker)
		{
			this.defaultTracker = defaultTracker;
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x156D4B0", Offset = "0x156D4B0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.launchDeferredDeeplink = launchDeferredDeeplink;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setLaunchDeferredDeeplink(bool launchDeferredDeeplink)
		{
			this.launchDeferredDeeplink = launchDeferredDeeplink;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x1565C38", Offset = "0x1565C38", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF28A0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sendInBackground, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290B7]) = v41;\nL_0019:\n\tv46 = 0;\n\tv48 = System.Nullable`1<System.Boolean>::.ctor(&v46 @ stack_-24_v1 (System.Nullable`1<System.Boolean>), sendInBackground);\n\tthis.sendInBackground = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setSendInBackground(bool sendInBackground)
		{
			bool? flag = null;
			flag = sendInBackground;
			this.sendInBackground = null;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x1565CA8", Offset = "0x1565CA8", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC7798]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventBufferingEnabled, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290B8]) = v41;\nL_0019:\n\tv46 = 0;\n\tv48 = System.Nullable`1<System.Boolean>::.ctor(&v46 @ stack_-24_v1 (System.Nullable`1<System.Boolean>), eventBufferingEnabled);\n\tthis.eventBufferingEnabled = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setEventBufferingEnabled(bool eventBufferingEnabled)
		{
			bool? flag = null;
			flag = eventBufferingEnabled;
			this.eventBufferingEnabled = null;
		}

		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x156D4BC", Offset = "0x156D4BC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EA3FA0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, delayStart, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290B9]) = v41;\nL_0019:\n\tv45 = 0;\n\tv49 = 0x115B9C0(&v45 @ stack_-40_v1 (System.Nullable`1<System.Double>), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, delayStart, v32, v33, v34, v35, v36, v37, v38);\n\tthis.delayStart = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+88]) = 0;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setDelayStart(double delayStart)
		{
			double? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115B9C0 (inside System.Nullable`1<System.DateTime>::Unbox +0xA8)");
			this.delayStart = null;
			_ = 0;
		}

		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x156D534", Offset = "0x156D534", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.userAgent = userAgent;\n\treturn;\n")]
		public void setUserAgent(string userAgent)
		{
			this.userAgent = userAgent;
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x156D53C", Offset = "0x156D53C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE2BF8]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, isDeviceKnown, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20290BA]) = v41;\nL_0019:\n\tv46 = 0;\n\tv48 = System.Nullable`1<System.Boolean>::.ctor(&v46 @ stack_-24_v1 (System.Nullable`1<System.Boolean>), isDeviceKnown);\n\tthis.isDeviceKnown = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setIsDeviceKnown(bool isDeviceKnown)
		{
			bool? flag = null;
			flag = isDeviceKnown;
			this.isDeviceKnown = null;
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x156D5AC", Offset = "0x156D5AC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.deferredDeeplinkDelegate = deferredDeeplinkDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setDeferredDeeplinkDelegate(Action<string> deferredDeeplinkDelegate, string sceneName = "Adjust")
		{
			this.deferredDeeplinkDelegate = deferredDeeplinkDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x156D5B8", Offset = "0x156D5B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.deferredDeeplinkDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<string> getDeferredDeeplinkDelegate()
		{
			return deferredDeeplinkDelegate;
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x156D5C0", Offset = "0x156D5C0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.attributionChangedDelegate = attributionChangedDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setAttributionChangedDelegate(Action<AdjustAttribution> attributionChangedDelegate, string sceneName = "Adjust")
		{
			this.attributionChangedDelegate = attributionChangedDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000CB")]
		[Address(RVA = "0x156D5CC", Offset = "0x156D5CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attributionChangedDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<AdjustAttribution> getAttributionChangedDelegate()
		{
			return attributionChangedDelegate;
		}

		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x156D5D4", Offset = "0x156D5D4", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.eventSuccessDelegate = eventSuccessDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setEventSuccessDelegate(Action<AdjustEventSuccess> eventSuccessDelegate, string sceneName = "Adjust")
		{
			this.eventSuccessDelegate = eventSuccessDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x156D5E0", Offset = "0x156D5E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.eventSuccessDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<AdjustEventSuccess> getEventSuccessDelegate()
		{
			return eventSuccessDelegate;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x156D5E8", Offset = "0x156D5E8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.eventFailureDelegate = eventFailureDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setEventFailureDelegate(Action<AdjustEventFailure> eventFailureDelegate, string sceneName = "Adjust")
		{
			this.eventFailureDelegate = eventFailureDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x156D5F4", Offset = "0x156D5F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.eventFailureDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<AdjustEventFailure> getEventFailureDelegate()
		{
			return eventFailureDelegate;
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x156D5FC", Offset = "0x156D5FC", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sessionSuccessDelegate = sessionSuccessDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setSessionSuccessDelegate(Action<AdjustSessionSuccess> sessionSuccessDelegate, string sceneName = "Adjust")
		{
			this.sessionSuccessDelegate = sessionSuccessDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x156D608", Offset = "0x156D608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sessionSuccessDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<AdjustSessionSuccess> getSessionSuccessDelegate()
		{
			return sessionSuccessDelegate;
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x156D610", Offset = "0x156D610", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.sessionFailureDelegate = sessionFailureDelegate;\n\tthis.sceneName = sceneName;\n\treturn;\n")]
		public void setSessionFailureDelegate(Action<AdjustSessionFailure> sessionFailureDelegate, string sceneName = "Adjust")
		{
			this.sessionFailureDelegate = sessionFailureDelegate;
			this.sceneName = sceneName;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x156D61C", Offset = "0x156D61C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.sessionFailureDelegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Action<AdjustSessionFailure> getSessionFailureDelegate()
		{
			return sessionFailureDelegate;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x156D624", Offset = "0x156D624", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1F0A340]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, secretId, info1, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20290BB]) = v53;\nL_0021:\n\tv57 = 0;\n\tv61 = 0x115C698(&v57 @ stack_-60_v1 (System.Nullable`1<System.Int64>), secretId, Il2CppMethodInfo, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tthis.secretId = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+78]) = 0;\n\tv65 = 0;\n\tv69 = 0x115C698(&v65 @ stack_-70_v1 (System.Nullable`1<System.Int64>), info1, Il2CppMethodInfo, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tthis.info1 = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+38]) = 0;\n\tv73 = 0;\n\tv77 = 0x115C698(&v73 @ stack_-80_v1 (System.Nullable`1<System.Int64>), info2, Il2CppMethodInfo, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tthis.info2 = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+48]) = 0;\n\tv81 = 0;\n\tv85 = 0x115C698(&v81 @ stack_-90_v1 (System.Nullable`1<System.Int64>), info3, Il2CppMethodInfo, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tthis.info3 = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+58]) = 0;\n\tv89 = 0;\n\tv93 = 0x115C698(&v89 @ stack_-A0_v1 (System.Nullable`1<System.Int64>), info4, Il2CppMethodInfo, info2, info3, info4, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tthis.info4 = 0;\n\t*([this @ X0 (com.adjust.sdk.AdjustConfig)+68]) = 0;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void setAppSecret(long secretId, long info1, long info2, long info3, long info4)
		{
			long? num = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
			this.secretId = null;
			_ = 0;
			long? num2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
			this.info1 = null;
			_ = 0;
			long? num3 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
			this.info2 = null;
			_ = 0;
			long? num4 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
			this.info3 = null;
			_ = 0;
			long? num5 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115C698 (inside System.Nullable`1<System.Int32Enum>::Unbox +0xA8)");
			this.info4 = null;
			_ = 0;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x156D72C", Offset = "0x156D72C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.processName = processName;\n\treturn;\n")]
		public void setProcessName(string processName)
		{
			this.processName = processName;
		}

		[Obsolete]
		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x156D734", Offset = "0x156D734", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void setReadMobileEquipmentIdentity(bool readMobileEquipmentIdentity)
		{
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x156D738", Offset = "0x156D738", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logDelegate = logDelegate;\n\treturn;\n")]
		public void setLogDelegate(Action<string> logDelegate)
		{
			this.logDelegate = logDelegate;
		}
	}
}
