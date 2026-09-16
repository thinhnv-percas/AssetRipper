using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;
using UnityEngine.Purchasing.Default;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200006F")]
	public class StandardPurchasingModule : AbstractPurchasingModule, IAndroidStoreSelection, IStoreConfiguration
	{
		[Token(Token = "0x2000070")]
		internal class StoreInstance
		{
			[Token(Token = "0x17000054")]
			[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72D06C", Offset = "0x72D06C")]
			[field: Token(Token = "0x400019C")]
			[field: FieldOffset(Offset = "0x10")]
			internal string storeName
			{
				[Token(Token = "0x60001F4")]
				[Address(RVA = "0xC70CB4", Offset = "0xC70CB4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<storeName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
			}

			[Token(Token = "0x17000055")]
			[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72D0A8", Offset = "0x72D0A8")]
			[field: Token(Token = "0x400019D")]
			[field: FieldOffset(Offset = "0x18")]
			internal IStore instance
			{
				[Token(Token = "0x60001F5")]
				[Address(RVA = "0xC70CBC", Offset = "0xC70CBC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<instance>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get;
			}

			[Token(Token = "0x60001F6")]
			[Address(RVA = "0xC70160", Offset = "0xC70160", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<storeName>k__BackingField = name;\n\tthis.<instance>k__BackingField = instance;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal StoreInstance(string name, IStore instance)
			{
				storeName = name;
				this.instance = instance;
			}
		}

		[Token(Token = "0x2000071")]
		private class MicrosoftConfiguration : IMicrosoftConfiguration, IStoreConfiguration
		{
			[Token(Token = "0x400019E")]
			[FieldOffset(Offset = "0x10")]
			private bool useMock;

			[Token(Token = "0x400019F")]
			[FieldOffset(Offset = "0x18")]
			private StandardPurchasingModule module;

			[Token(Token = "0x17000056")]
			public bool useMockBillingSystem
			{
				[Token(Token = "0x60001F8")]
				[Address(RVA = "0xC70C7C", Offset = "0xC70C7C", Length = "0x38")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Purchasing.StandardPurchasingModule::UseMockWindowsStore(this.module, value);\n\tthis.useMock = value;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				set
				{
					module.UseMockWindowsStore(value);
					useMock = value;
				}
			}

			[Token(Token = "0x60001F7")]
			[Address(RVA = "0xC6FDE0", Offset = "0xC6FDE0", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.module = module;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public MicrosoftConfiguration(StandardPurchasingModule module)
			{
				this.module = module;
			}
		}

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x18")]
		private AppStore m_AppStorePlatform;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x20")]
		private INativeStoreProvider m_NativeStoreProvider;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x28")]
		private RuntimePlatform m_RuntimePlatform;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x2C")]
		private bool m_UseCloudCatalog;

		[Token(Token = "0x4000192")]
		private static StandardPurchasingModule ModuleInstance;

		[Token(Token = "0x4000197")]
		private static Dictionary<AppStore, string> AndroidStoreNameMap;

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x50")]
		private CloudCatalogImpl m_CloudCatalog;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72D030", Offset = "0x72D030")]
		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x5C")]
		private bool _003CuseFakeStoreAlways_003Ek__BackingField;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x60")]
		private WinRTStore windowsStore;

		[Token(Token = "0x1700004D")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CF04", Offset = "0x72CF04")]
		[field: Token(Token = "0x4000193")]
		[field: FieldOffset(Offset = "0x30")]
		internal IUtil util
		{
			[Token(Token = "0x60001D5")]
			[Address(RVA = "0xC6F16C", Offset = "0xC6F16C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<util>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60001D6")]
			[Address(RVA = "0xC6F174", Offset = "0xC6F174", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<util>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700004E")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CF40", Offset = "0x72CF40")]
		[field: Token(Token = "0x4000194")]
		[field: FieldOffset(Offset = "0x38")]
		internal ILogger logger
		{
			[Token(Token = "0x60001D7")]
			[Address(RVA = "0xC6F17C", Offset = "0xC6F17C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<logger>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60001D8")]
			[Address(RVA = "0xC6F184", Offset = "0xC6F184", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<logger>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700004F")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CF7C", Offset = "0x72CF7C")]
		[field: Token(Token = "0x4000195")]
		[field: FieldOffset(Offset = "0x40")]
		internal IAsyncWebUtil webUtil
		{
			[Token(Token = "0x60001D9")]
			[Address(RVA = "0xC6F18C", Offset = "0xC6F18C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<webUtil>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60001DA")]
			[Address(RVA = "0xC6F194", Offset = "0xC6F194", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<webUtil>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000050")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CFB8", Offset = "0x72CFB8")]
		[field: Token(Token = "0x4000196")]
		[field: FieldOffset(Offset = "0x48")]
		internal StoreInstance storeInstance
		{
			[Token(Token = "0x60001DB")]
			[Address(RVA = "0xC6F19C", Offset = "0xC6F19C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<storeInstance>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0xC6F1A4", Offset = "0xC6F1A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<storeInstance>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x17000051")]
		public AppStore appStore
		{
			[Token(Token = "0x60001DE")]
			[Address(RVA = "0xC6F294", Offset = "0xC6F294", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_AppStorePlatform;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return appStore;
			}
		}

		[Token(Token = "0x17000052")]
		public FakeStoreUIMode useFakeStoreUIMode
		{
			[CompilerGenerated]
			[Token(Token = "0x60001DF")]
			[Address(RVA = "0xC6F29C", Offset = "0xC6F29C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<useFakeStoreUIMode>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return useFakeStoreUIMode;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0xC6F2A4", Offset = "0xC6F2A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<useFakeStoreUIMode>k__BackingField = value;\n\treturn;\n")]
			set
			{
				useFakeStoreUIMode = value;
			}
		}

		[Token(Token = "0x17000053")]
		public bool useFakeStoreAlways
		{
			[CompilerGenerated]
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0xC6F2AC", Offset = "0xC6F2AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<useFakeStoreAlways>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return useFakeStoreAlways;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0xC6F2B4", Offset = "0xC6F2B4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<useFakeStoreAlways>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_003CuseFakeStoreAlways_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xC6F1AC", Offset = "0xC6F1AC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv46 = *([1EACAE0]);\n\tv47 = *([v46 @ X8_v12]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, util, webUtil, logger, nativeStoreProvider, platform, android, useCloudCatalog, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20233C2]) = v59;\nL_0023:\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::.ctor(this);\n\tthis.<logger>k__BackingField = logger;\n\tthis.<webUtil>k__BackingField = webUtil;\n\tthis.<util>k__BackingField = util;\n\tthis.m_NativeStoreProvider = nativeStoreProvider;\n\tthis.m_RuntimePlatform = platform;\n\tthis.<useFakeStoreUIMode>k__BackingField = 0;\n\tthis.<useFakeStoreAlways>k__BackingField = 0;\n\tthis.m_AppStorePlatform = android;\n\tthis.m_UseCloudCatalog = useCloudCatalog;\n\tgoto L_004D;\n\tv69 = *([v65 @ X0_v3+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_004D;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, v61, webUtil, logger, nativeStoreProvider, platform, android, useCloudCatalog, v49, v50, v51, v52, v53, v54, v55, v56);\nL_004D:\n\tUnityEngine.Purchasing.Promo::InitPromo(platform, logger, \"1.23.1\", util, webUtil);\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal StandardPurchasingModule(IUtil util, IAsyncWebUtil webUtil, ILogger logger, INativeStoreProvider nativeStoreProvider, RuntimePlatform platform, AppStore android, bool useCloudCatalog)
		{
			this.logger = logger;
			this.webUtil = webUtil;
			this.util = util;
			m_NativeStoreProvider = nativeStoreProvider;
			m_RuntimePlatform = platform;
			useFakeStoreUIMode = default(FakeStoreUIMode);
			useFakeStoreAlways = false;
			m_AppStorePlatform = android;
			m_UseCloudCatalog = useCloudCatalog;
			Promo.InitPromo(platform, logger, "1.23.1", util, webUtil);
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0xC6F2C0", Offset = "0xC6F2C0", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F071F0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20233C3]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0022:\n\treturnVal1 = UnityEngine.Purchasing.StandardPurchasingModule::Instance(0);\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static StandardPurchasingModule Instance()
		{
			return Instance(default(AppStore));
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0xC6F320", Offset = "0xC6F320", Length = "0x328")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EABCF8]);\n\tv31 = *([v30 @ X8_v57]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20233C4]) = v50;\nL_001F:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2 (Il2CppClass<UnityEngine.Purchasing.StandardPurchasingModule>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv61 = UnityEngine.Purchasing.StandardPurchasingModule;\nL_0028:\n\tv66 = v64.ModuleInstance == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0116;\n\tgoto L_0038;\n\tv157 = *([v71 @ X0_v9+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0038;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v71, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0038:\n\tv165 = UnityEngine.Debug::get_unityLogger();\n\tv246 = *([v165 @ X0_v12 (UnityEngine.ILogger)]);\n\tv253 = *([v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+126]) == 0;\n\tif (v253) goto L_0063;\n\tv317 = *([v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+B0]) + 8;\nL_004E:\n\tv323 = *([v317 @ X11_v11-8]) == UnityEngine.ILogger;\n\tif (v323) goto L_0066;\n\tv318 = v318 + 1;\n\tv328 = v318 < *([v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+126]);\n\tv299 = ~v328;\n\tv317 = v317 + 0x10;\n\tv283 = ~v299;\n\tif (v283) goto L_004E;\nL_0063:\n\tv347 = 0x8909C4(v165, UnityEngine.ILogger, 4, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_006E;\nL_0066:\n\tv330 = *([v317 @ X11_v11]) + 4;\n\tv331 = v330 << 4;\n\tv332 = v246 + v331;\n\tv347 = v332 + 0x130;\nL_006E:\n\t*([v347 @ X0_v15])(v353, v165, \"UnityIAP Version: 1.23.1\", *([v347 @ X0_v15+8]), v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv357 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v357, \"IAPUtil\");\n\tgoto L_0087;\n\tv369 = *([v365 @ X0_v20+E0]);\n\tv370 = v369 == 0;\n\tv371 = ~v370;\n\tgoto L_0087;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v365, v362, v360, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0087:\n\tUnityEngine.Object::DontDestroyOnLoad(v357);\n\tUnityEngine.Object::set_hideFlags(v357, 3);\n\tv403 = UnityEngine.GameObject::AddComponent(v357);\n\tv408 = UnityEngine.GameObject::AddComponent(v357);\n\tv414 = UnityEngine.Resources::Load(\"BillingMode\");\n\tv415 = v414 == 0;\n\tif (v415) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_00CA;\n\tv457 = v457_asT == 0;\n\tif (v457) goto L_FFFFFFFF;\n\tgoto L_00CA;\nL_00CA:\n\tv462 = UnityEngine.Object::op_Inequality(0, v383);\n\tv464 = v462 == 0;\n\tif (v464) goto L_00D7;\n\tv474 = UnityEngine.TextAsset::get_text(v383);\n\tv467 = UnityEngine.Purchasing.StoreConfiguration::Deserialize(v474);\nL_00D7:\n\tv470 = androidStore == 0;\n\tv471 = ~v470;\n\tif (v471) goto L_00F2;\n\tv475 = v467 == 0;\n\tif (v475) goto L_FFFFFFFF;\n\tv482 = v467.<androidStore>k__BackingField == 0;\n\tv477 = ~v482;\n\tv476 = ~v477;\n\tif (v476) goto L_FFFFFFFF;\n\tgoto L_00ED;\nL_00ED:\n\tgoto L_00F2;\nL_00F2:\n\tv494 = new UnityEngine.Purchasing.NativeStoreProvider();\n\tSystem.Object::.ctor(v494);\n\tv500 = UnityEngine.Application::get_platform();\n\tv503 = new UnityEngine.Purchasing.StandardPurchasingModule();\n\tUnityEngine.Purchasing.StandardPurchasingModule::.ctor(v503, v403, v408, v165, v494, v500, v149, 0);\n\tgoto L_0111;\n\tv509 = *([v505 @ X0_v43 (Il2CppClass<UnityEngine.Purchasing.StandardPurchasingModule>)+E0]);\n\tv510 = v509 == 0;\n\tv511 = ~v510;\n\tif (v511) goto L_0111;\n\tv515 = \"il2cpp_codegen_runtime_class_init\"(v505, v137, v103, v87, v85, v83, v81, v79, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv513 = UnityEngine.Purchasing.StandardPurchasingModule;\nL_0111:\n\tv151.ModuleInstance = v503;\nL_0116:\n\tgoto L_012A;\n\tv166 = *([v144 @ X0_v4 (Il2CppClass<UnityEngine.Purchasing.StandardPurchasingModule>)+E0]);\n\tv167 = v166 == 0;\n\tv168 = ~v167;\n\tgoto L_012A;\n\tv186 = \"il2cpp_codegen_runtime_class_init\"(v144, v136, v102, v86, v84, v82, v80, v78, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv170 = UnityEngine.Purchasing.StandardPurchasingModule;\nL_012A:\n\treturn v173.ModuleInstance;\n\tv274 = new System.NullReferenceException();\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 201 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static StandardPurchasingModule Instance(AppStore androidStore)
		{
			//IL_0020: Expected I, but got O
			//IL_005b: Expected O, but got I
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00ff: Expected O, but got I
			//IL_010e: Expected O, but got I
			//IL_00a7: Expected O, but got I
			ILogger unityLogger;
			if (ModuleInstance == null)
			{
				unityLogger = Debug.unityLogger;
				IntPtr intPtr = (IntPtr)unityLogger;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00c0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X11_v11-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ILogger))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ X8_v17 (Il2CppClass<UnityEngine.ILogger>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00c0;
				}
				object obj2 = obj + 4;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0329;
			}
			goto IL_03a2;
			IL_0329:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v347 @ X0_v15] (should have been resolved before IL gen)");
			GameObject gameObject = new GameObject("IAPUtil");
			Object.DontDestroyOnLoad(gameObject);
			gameObject.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
			UnityUtil unityUtil = gameObject.AddComponent<UnityUtil>();
			AsyncWebUtil asyncWebUtil = gameObject.AddComponent<AsyncWebUtil>();
			Object obj5 = Resources.Load("BillingMode");
			Object obj6;
			if ((object)obj5 == null)
			{
				obj6 = null;
			}
			else
			{
				TextAsset textAsset = obj5 as TextAsset;
				obj6 = (((object)textAsset == null) ? null : obj5);
			}
			bool flag3 = null != obj6;
			bool flag4 = !flag3;
			StoreConfiguration storeConfiguration = null;
			if (!flag4)
			{
				string text = ((TextAsset)obj6).text;
				storeConfiguration = StoreConfiguration.Deserialize(text);
			}
			bool flag5 = androidStore == AppStore.NotSpecified;
			bool flag6 = !flag5;
			AppStore android = androidStore;
			if (!flag6)
			{
				android = ((storeConfiguration == null) ? AppStore.GooglePlay : ((storeConfiguration.androidStore == AppStore.NotSpecified) ? AppStore.GooglePlay : storeConfiguration.androidStore));
			}
			NativeStoreProvider nativeStoreProvider = new NativeStoreProvider();
			RuntimePlatform platform = Application.platform;
			StandardPurchasingModule moduleInstance = new StandardPurchasingModule(unityUtil, asyncWebUtil, unityLogger, nativeStoreProvider, platform, android, useCloudCatalog: false);
			ModuleInstance = moduleInstance;
			goto IL_03a2;
			IL_03a2:
			return ModuleInstance;
			IL_00c0:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0329;
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0xC6F648", Offset = "0xC6F648", Length = "0x798")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv28 = *([1ED7528]);\n\tv29 = *([v28 @ X8_v113]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20233C5]) = v48;\nL_001B:\n\tv52 = new UnityEngine.Purchasing.FakeGooglePlayConfiguration();\n\tSystem.Object::.ctor(v52);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v52);\n\tv63 = new UnityEngine.Purchasing.FakeAppleConfiguation();\n\tSystem.Object::.ctor(v63);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v63);\n\tv74 = new UnityEngine.Purchasing.FakeAppleExtensions();\n\tSystem.Object::.ctor(v74);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v74);\n\tv85 = new UnityEngine.Purchasing.FakeAmazonExtensions();\n\tSystem.Object::.ctor(v85);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v85);\n\tv94 = new UnityEngine.Purchasing.FakeAmazonExtensions();\n\tSystem.Object::.ctor(v94);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v94);\n\tv105 = new UnityEngine.Purchasing.FakeSamsungAppsExtensions();\n\tSystem.Object::.ctor(v105);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v105);\n\tv114 = new UnityEngine.Purchasing.FakeSamsungAppsExtensions();\n\tSystem.Object::.ctor(v114);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v114);\n\tv125 = new UnityEngine.Purchasing.FakeGooglePlayStoreExtensions();\n\tSystem.Object::.ctor(v125);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v125);\n\tv132 = new UnityEngine.Purchasing.FakeGooglePlayStoreExtensions();\n\tSystem.Object::.ctor(v132);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v132);\n\tv143 = new UnityEngine.Purchasing.FakeMoolahConfiguration();\n\tSystem.Object::.ctor(v143);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v143);\n\tv154 = new UnityEngine.Purchasing.FakeMoolahExtensions();\n\tSystem.Object::.ctor(v154);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v154);\n\tv165 = new UnityEngine.Purchasing.FakeUnityChannelConfiguration();\n\tSystem.Object::.ctor(v165);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v165);\n\tv176 = new UnityEngine.Purchasing.FakeUnityChannelExtensions();\n\tSystem.Object::.ctor(v176);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v176);\n\tv187 = new UnityEngine.Purchasing.StandardPurchasingModule+MicrosoftConfiguration();\n\tSystem.Object::.ctor(v187);\n\tv187.module = this;\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v187);\n\tv198 = new UnityEngine.Purchasing.FakeMicrosoftExtensions();\n\tSystem.Object::.ctor(v198);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v198);\n\tv209 = new UnityEngine.Purchasing.FakeTizenStoreConfiguration();\n\tSystem.Object::.ctor(v209);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v209);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, this);\n\tv225 = new UnityEngine.Purchasing.FakeManagedStoreConfig();\n\tv225.catalogDisabled = 0;\n\tv225.trackingOptedOut = 0;\n\tv225.iapBaseUrl = 0;\n\tv225.eventBaseUrl = 0;\n\tSystem.Object::.ctor(v225);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v225);\n\tv236 = new UnityEngine.Purchasing.FakeManagedStoreExtensions();\n\tSystem.Object::.ctor(v236);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v236);\n\tv247 = new UnityEngine.Purchasing.FakeUDPExtension();\n\tSystem.Object::.ctor(v247);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v247);\n\tv258 = new UnityEngine.Purchasing.FakeTransactionHistoryExtensions();\n\tSystem.Object::.ctor(v258);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v258);\n\tv271 = this.<storeInstance>k__BackingField;\n\tv267 = this.<storeInstance>k__BackingField == 0;\n\tv268 = ~v267;\n\tif (v268) goto L_012C;\n\tv271 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateStore(this);\n\tthis.<storeInstance>k__BackingField = v271;\nL_012C:\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::RegisterStore(this, v271.<storeName>k__BackingField, v271.<instance>k__BackingField);\n\tv279 = ~this.m_UseCloudCatalog;\n\tif (v279) goto L_016C;\n\tv365 = System.Object::GetType(this.m_Binder);\n\tv394 = System.Type::GetMethod(v365, \"SetCatalogProviderFunction\");\n\tv397 = v394 == 0;\n\tif (v397) goto L_016C;\n\tv465 = this.<storeInstance>k__BackingField;\n\tv691 = UnityEngine.Purchasing.CloudCatalogImpl::CreateInstance(v465.<storeName>k__BackingField);\n\tthis.m_CloudCatalog = v691;\n\tv710 = new System.Action`1<System.Action`1<System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>>>();\n\tSystem.Action`1<System.Action`1<System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>>>::.ctor(v710, this, Il2CppMethodInfo);\n\t// 343 NewArr v366 @ X0_v116 (System.Object[]), typeof(System.Object[]), 1\n\tv737 = v710 == 0;\n\tif (v737) goto L_0164;\n\t// 352 IsInst v743 @ X0_v121, typeof(System.Object), v710 @ X0_v114 (System.Action`1<System.Action`1<System.Collections.Generic.HashSet`1<UnityEngine.Purchasing.ProductDefinition>>>)\nL_0164:\n\tv396 = v366.Length == 0;\n\tif (v396) goto L_0248;\n\tv366[0] = v710;\n\tv393 = System.Reflection.MethodBase::Invoke(v394, this.m_Binder, v366);\nL_016C:\n\tv402 = this.<storeInstance>k__BackingField;\n\t// 371 IsInst v435 @ X0_v79 (UnityEngine.Purchasing.IStoreInternal), typeof(UnityEngine.Purchasing.IStoreInternal), v402.<instance>k__BackingField (UnityEngine.Purchasing.Extension.IStore)\n\tv470 = v435 == 0;\n\tif (v470) goto L_01A4;\n\tgoto L_01A3;\n\tv547 = *([v523 @ X8_v95+B0]);\n\tv548 = 0;\n\tv549 = v547 + 8;\n\tv551 = *([v678 @ X11_v20-8]);\n\tv683 = v551 == v524;\n\tif (v683) goto L_019B;\n\tv571 = v677 + 1;\n\tv692 = v571 < v525;\n\tv569 = ~v692;\n\tv573 = v678 + 0x10;\n\tv553 = ~v569;\n\tif (v553) goto L_FFFFFFFF;\n\tv574 = v468;\n\tv575 = 0;\n\tv576 = 0x8909C4(v574, v524, v575, v344, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_01A3;\nL_019B:\n\tv693 = *([v678 @ X11_v20]);\n\tv694 = v693 << 4;\n\tv695 = v523 + v694;\n\tv696 = v695 + 0x130;\nL_01A3:\n\tUnityEngine.Purchasing.IStoreInternal::SetModule(v435, this);\nL_01A4:\n\tv467 = this.<storeInstance>k__BackingField;\n\t// 427 IsInst v581 @ X0_v82 (UnityEngine.Purchasing.IManagedStoreExtensions), typeof(UnityEngine.Purchasing.IManagedStoreExtensions), v467.<instance>k__BackingField (UnityEngine.Purchasing.Extension.IStore)\n\tv689 = v581 == 0;\n\tif (v689) goto L_01B4;\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v581);\nL_01B4:\n\tv706 = this.<util>k__BackingField == 0;\n\tif (v706) goto L_0244;\n\tgoto L_01C7;\n\tv727 = *([v713 @ X0_v85+E0]);\n\tv728 = v727 == 0;\n\tv729 = ~v728;\n\tif (v729) goto L_01C7;\n\tv731 = \"il2cpp_codegen_runtime_class_init\"(v713, v704, v352, v344, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_01C7:\n\tv458 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.JSONStore);\n\tv377 = this.<storeInstance>k__BackingField;\n\tv739 = System.Object::GetType(v377.<instance>k__BackingField);\n\tgoto L_0202;\n\tv754 = *([v748 @ X8_v85+B0]);\n\tv755 = 0;\n\tv756 = v754 + 8;\n\tv758 = *([v812 @ X11_v14-8]);\n\tv817 = v758 == v751;\n\tif (v817) goto L_01F8;\n\tv778 = v811 + 1;\n\tv822 = v778 < v750;\n\tv776 = ~v822;\n\tv780 = v812 + 0x10;\n\tv760 = ~v776;\n\tif (v760) goto L_FFFFFFFF;\n\tv781 = 0x11;\n\tv782 = v381;\n\tv783 = 0x8909C4(v782, v751, v781, v344, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tgoto L_0202;\nL_01F8:\n\tv823 = *([v812 @ X11_v14]);\n\tv824 = v823 + 0x11;\n\tv825 = v824 << 4;\n\tv826 = v748 + v825;\n\tv827 = v826 + 0x130;\nL_0202:\n\tv459 = Uniject.IUtil::IsClassOrSubclass(this.<util>k__BackingField, v458, v739);\n\tv721 = v459 == 0;\n\tif (v721) goto L_0244;\n\tv466 = this.<storeInstance>k__BackingField;\n\tv653 = v466.<instance>k__BackingField\n// ... truncated")]
		public override void Configure()
		{
			FakeGooglePlayConfiguration instance = new FakeGooglePlayConfiguration();
			BindConfiguration((IGooglePlayConfiguration)instance);
			FakeAppleConfiguation instance2 = new FakeAppleConfiguation();
			BindConfiguration((IAppleConfiguration)instance2);
			FakeAppleExtensions instance3 = new FakeAppleExtensions();
			BindExtension((IAppleExtensions)instance3);
			FakeAmazonExtensions instance4 = new FakeAmazonExtensions();
			BindConfiguration((IAmazonConfiguration)instance4);
			FakeAmazonExtensions instance5 = new FakeAmazonExtensions();
			BindExtension((IAmazonExtensions)instance5);
			FakeSamsungAppsExtensions instance6 = new FakeSamsungAppsExtensions();
			BindConfiguration((ISamsungAppsConfiguration)instance6);
			FakeSamsungAppsExtensions instance7 = new FakeSamsungAppsExtensions();
			BindExtension((ISamsungAppsExtensions)instance7);
			FakeGooglePlayStoreExtensions instance8 = new FakeGooglePlayStoreExtensions();
			BindConfiguration((IGooglePlayConfiguration)instance8);
			FakeGooglePlayStoreExtensions instance9 = new FakeGooglePlayStoreExtensions();
			BindExtension((IGooglePlayStoreExtensions)instance9);
			FakeMoolahConfiguration instance10 = new FakeMoolahConfiguration();
			BindConfiguration((IMoolahConfiguration)instance10);
			FakeMoolahExtensions instance11 = new FakeMoolahExtensions();
			BindExtension((IMoolahExtension)instance11);
			FakeUnityChannelConfiguration instance12 = new FakeUnityChannelConfiguration();
			BindConfiguration((IUnityChannelConfiguration)instance12);
			FakeUnityChannelExtensions instance13 = new FakeUnityChannelExtensions();
			BindExtension((IUnityChannelExtensions)instance13);
			MicrosoftConfiguration instance14 = new MicrosoftConfiguration(this);
			BindConfiguration((IMicrosoftConfiguration)instance14);
			FakeMicrosoftExtensions instance15 = new FakeMicrosoftExtensions();
			BindExtension((IMicrosoftExtensions)instance15);
			FakeTizenStoreConfiguration instance16 = new FakeTizenStoreConfiguration();
			BindConfiguration((ITizenStoreConfiguration)instance16);
			BindConfiguration((IAndroidStoreSelection)this);
			FakeManagedStoreConfig fakeManagedStoreConfig = new FakeManagedStoreConfig();
			fakeManagedStoreConfig.catalogDisabled = false;
			fakeManagedStoreConfig.testStore = false;
			fakeManagedStoreConfig.trackingOptedOut = null;
			fakeManagedStoreConfig.iapBaseUrl = null;
			fakeManagedStoreConfig.eventBaseUrl = null;
			BindConfiguration((IManagedStoreConfig)fakeManagedStoreConfig);
			FakeManagedStoreExtensions instance17 = new FakeManagedStoreExtensions();
			BindExtension((IManagedStoreExtensions)instance17);
			FakeUDPExtension instance18 = new FakeUDPExtension();
			BindExtension((IUDPExtensions)instance18);
			FakeTransactionHistoryExtensions instance19 = new FakeTransactionHistoryExtensions();
			BindExtension((ITransactionHistoryExtensions)instance19);
			StoreInstance storeInstance = this.storeInstance;
			if (this.storeInstance == null)
			{
				storeInstance = (this.storeInstance = InstantiateStore());
			}
			RegisterStore(storeInstance.storeName, storeInstance.instance);
			IndexOutOfRangeException ex = default(IndexOutOfRangeException);
			if (m_UseCloudCatalog)
			{
				Type type = m_Binder.GetType();
				MethodInfo method = type.GetMethod("SetCatalogProviderFunction");
				if ((object)method != null)
				{
					StoreInstance storeInstance2 = this.storeInstance;
					CloudCatalogImpl cloudCatalog = CloudCatalogImpl.CreateInstance(storeInstance2.storeName);
					m_CloudCatalog = cloudCatalog;
					Action<Action<HashSet<ProductDefinition>>> action = delegate(Action<HashSet<ProductDefinition>> callback)
					{
						Type typeFromHandle2 = typeof(CloudCatalogImpl);
						MethodInfo method2 = typeFromHandle2.GetMethod("FetchProducts");
						if ((object)method2 != null)
						{
							object[] array2 = new object[1];
							if (callback != null)
							{
								object obj3 = callback as object;
							}
							if (array2.Length == 0)
							{
								IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
								IndexOutOfRangeException ex5 = default(IndexOutOfRangeException);
								throw ex5;
							}
							array2[0] = callback;
							object obj4 = method2.Invoke(m_CloudCatalog, array2);
						}
						else
						{
							HashSet<ProductDefinition> obj5 = new HashSet<ProductDefinition>();
							callback(obj5);
						}
					};
					object[] array = new object[1];
					if (action != null)
					{
						object obj = action as object;
					}
					if (array.Length == 0)
					{
						ex = new IndexOutOfRangeException();
						goto IL_056e;
					}
					array[0] = action;
					object obj2 = method.Invoke(m_Binder, array);
				}
			}
			StoreInstance storeInstance3 = this.storeInstance;
			(storeInstance3.instance as IStoreInternal)?.SetModule(this);
			StoreInstance storeInstance4 = this.storeInstance;
			IManagedStoreExtensions managedStoreExtensions = storeInstance4.instance as IManagedStoreExtensions;
			if (managedStoreExtensions != null)
			{
				BindExtension(managedStoreExtensions);
			}
			if (util == null)
			{
				return;
			}
			Type typeFromHandle = typeof(JSONStore);
			StoreInstance storeInstance5 = this.storeInstance;
			Type type2 = storeInstance5.instance.GetType();
			if (!util.IsClassOrSubclass(typeFromHandle, type2))
			{
				return;
			}
			StoreInstance storeInstance6 = this.storeInstance;
			if (storeInstance6.instance != null)
			{
				JSONStore jSONStore = storeInstance6.instance as JSONStore;
				if (jSONStore == null)
				{
					InvalidCastException ex2 = new InvalidCastException();
					ArrayTypeMismatchException ex3 = new ArrayTypeMismatchException();
					goto IL_056e;
				}
			}
			BindExtension((ITransactionHistoryExtensions)storeInstance6.instance);
			return;
			IL_056e:
			throw ex;
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0xC6FE0C", Offset = "0xC6FE0C", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED6138]);\n\tv21 = *([v20 @ X8_v55]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20233C6]) = v40;\nL_0015:\n\tv42 = ~v38.<useFakeStoreAlways>k__BackingField;\n\tif (v42) goto L_003B;\nL_0018:\n\tv100 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateFakeStore(v38);\n\tv167 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\nL_0021:\n\tv264 = *([v173 @ X8_v5 (System.String)]);\nL_0024:\n\tSystem.Object::.ctor(v266);\n\t*([v266 @ X0_v2 (System.Object)+10]) = v264;\n\t*([v266 @ X0_v2 (System.Object)+18]) = v270;\n\treturn v266;\nL_003B:\n\tv49 = v38.m_RuntimePlatform <= 8;\n\tif (v49) goto L_005E;\n\tv45 = v38.m_RuntimePlatform - 0x11;\n\tv118 = v45 < 0xE;\n\tv119 = ~v118;\n\tv120 = v45 - 0xE;\n\tv122 = v120 == 0;\n\tv127 = ~v122;\n\tv128 = v119 & v127;\n\tif (v128) goto L_00A4;\n\tv141 = 0x181A000 + 0x2CC;\n\tv143 = *([v141 @ X8_v45 (System.Int32)+v45 @ X9_v3 (System.Int32)*4]) + v141;\n\t// 78 IndirectJump v143 @ X8_v46, v38 @ X0_v1 (UnityEngine.Purchasing.StandardPurchasingModule), v38 @ X0_v1 (UnityEngine.Purchasing.StandardPurchasingModule), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = X20;\n\tX0 = UnityEngine.Purchasing.StandardPurchasingModule::instantiateWindowsStore(X0, X1);\n\tX8 = *([1EA6088]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1ED1030]);\n\tgoto L_0021;\nL_005E:\n\tv133 = v38.m_RuntimePlatform == 1;\n\tif (v133) goto L_0091;\n\tv74 = v38.m_RuntimePlatform == 2;\n\tif (v74) goto L_0085;\n\tv48 = v38.m_RuntimePlatform != 8;\n\tif (v48) goto L_0018;\n\tv281 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateApple(v38);\n\tv167 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\n\tgoto L_0021;\nL_0085:\n\tv92 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateFacebook(v38);\n\tv94 = v92 == 0;\n\tif (v94) goto L_0018;\n\tv167 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\n\tgoto L_0021;\nL_0091:\n\tv147 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateApple(v38);\n\tv167 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\n\tgoto L_0021;\nL_00A4:\n\tv50 = v38.m_RuntimePlatform != 0xB;\n\tif (v50) goto L_0018;\n\tv241 = v38.m_AppStorePlatform == 6;\n\tif (v241) goto L_00D8;\n\tv150 = v38.m_AppStorePlatform != 3;\n\tif (v150) goto L_00F2;\n\tv284 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateCloudMoolah(v38);\n\tv167 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\n\tgoto L_0021;\n\tX0 = X20;\n\tX0 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateTizen(X0, X1);\n\tX8 = *([1EA6088]);\n\tX19 = X0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EAEAC0]);\n\tgoto L_0021;\nL_00D8:\n\tgoto L_00E7;\n\tv291 = *([v276 @ X0_v22 (Il2CppClass<UnityEngine.Purchasing.StandardPurchasingModule>)+E0]);\n\tv292 = v291 == 0;\n\tv293 = ~v292;\n\t// 220 ConditionalJump @b56, v293 @ TEMP_v15\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v276, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv295 = UnityEngine.Purchasing.StandardPurchasingModule;\nL_00E7:\n\tv327 = System.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::get_Item(v298.AndroidStoreNameMap, v38.m_AppStorePlatform);\n\tv344 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateUDP(v38);\n\tgoto L_010A;\nL_00F2:\n\tgoto L_0101;\n\tv312 = *([v287 @ X0_v30 (Il2CppClass<UnityEngine.Purchasing.StandardPurchasingModule>)+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\t// 246 ConditionalJump @b57, v314 @ TEMP_v21\n\tv332 = \"il2cpp_codegen_runtime_class_init\"(v287, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv316 = UnityEngine.Purchasing.StandardPurchasingModule;\nL_0101:\n\tv337 = System.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::get_Item(v319.AndroidStoreNameMap, v38.m_AppStorePlatform);\n\tv344 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateAndroid(v38);\nL_010A:\n\tv266 = new UnityEngine.Purchasing.StandardPurchasingModule+StoreInstance();\n\tgoto L_0024;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 175 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private StoreInstance InstantiateStore()
		{
			//IL_0311: Expected I, but got O
			//IL_00e2: Expected O, but got I
			//IL_02e1: Expected I, but got O
			StoreInstance storeInstance;
			string text;
			object result;
			IntPtr intPtr;
			IStore store2;
			if (!useFakeStoreAlways)
			{
				if (m_RuntimePlatform > RuntimePlatform.IPhonePlayer)
				{
					int num = (int)(m_RuntimePlatform - 17);
					bool flag = num < 14;
					bool flag2 = !flag;
					int num2 = num - 14;
					bool flag3 = num2 == 0;
					bool flag4 = !flag3;
					if (flag2 && flag4)
					{
						if (m_RuntimePlatform != RuntimePlatform.Android)
						{
							goto IL_0005;
						}
						IStore store3;
						string text3;
						if (appStore != AppStore.UDP)
						{
							if (appStore == AppStore.CloudMoolah)
							{
								IStore store = InstantiateCloudMoolah();
								storeInstance = null;
								text = "MoolahAppStore";
								store2 = store;
								goto IL_0309;
							}
							string text2 = AndroidStoreNameMap.get_Item(appStore);
							store3 = InstantiateAndroid();
							text3 = text2;
						}
						else
						{
							string text4 = AndroidStoreNameMap.get_Item(appStore);
							store3 = InstantiateUDP();
							text3 = text4;
						}
						result = null;
						intPtr = (IntPtr)text3;
						store2 = store3;
						goto IL_031e;
					}
					int num3 = 25272320 + 716;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X8_v45 (System.Int32)+v45 @ X9_v3 (System.Int32)*4]");
					object obj = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v143 @ X8_v46 (should have been resolved before IL gen)");
				}
				if (m_RuntimePlatform != RuntimePlatform.OSXPlayer)
				{
					if (m_RuntimePlatform != RuntimePlatform.WindowsPlayer)
					{
						if (m_RuntimePlatform != RuntimePlatform.IPhonePlayer)
						{
							goto IL_0005;
						}
						IStore store4 = InstantiateApple();
						storeInstance = null;
						text = "AppleAppStore";
						store2 = store4;
					}
					else
					{
						IStore store5 = InstantiateFacebook();
						if (store5 == null)
						{
							goto IL_0005;
						}
						storeInstance = null;
						text = "FacebookStore";
						store2 = store5;
					}
				}
				else
				{
					IStore store6 = InstantiateApple();
					storeInstance = null;
					text = "MacAppStore";
					store2 = store6;
				}
				goto IL_0309;
			}
			goto IL_0005;
			IL_031e:
			return (StoreInstance)result;
			IL_0309:
			intPtr = (IntPtr)text;
			result = storeInstance;
			goto IL_031e;
			IL_0005:
			IStore store7 = InstantiateFakeStore();
			storeInstance = null;
			text = "fake";
			store2 = store7;
			goto IL_0309;
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0xC70430", Offset = "0xC70430", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC8D88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20233C7]) = v38;\nL_0016:\n\tv42 = new UnityEngine.Purchasing.JSONStore();\n\tUnityEngine.Purchasing.JSONStore::.ctor(v42);\n\treturnVal1 = UnityEngine.Purchasing.StandardPurchasingModule::InstantiateAndroidHelper(this, v42);\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateAndroid()
		{
			JSONStore store = new JSONStore();
			return InstantiateAndroidHelper(store);
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0xC70350", Offset = "0xC70350", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EA6ED8]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20233C8]) = v40;\nL_0017:\n\tv44 = new UnityEngine.Purchasing.UDPImpl();\n\tUnityEngine.Purchasing.UDPImpl::.ctor(v44);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v44);\n\tv54 = UnityEngine.Purchasing.StandardPurchasingModule::GetAndroidNativeStore(this, v44);\n\tv56 = v54 == 0;\n\tif (v56) goto L_003E;\n\t// 44 IsInst v62 @ X0_v17 (UnityEngine.Purchasing.INativeUDPStore), typeof(UnityEngine.Purchasing.INativeUDPStore), v54 @ X0_v6 (UnityEngine.Purchasing.INativeStore)\n\tv67 = v62 == 0;\n\tif (v67) goto L_0045;\nL_0034:\n\tUnityEngine.Purchasing.UDPImpl::SetNativeStore(v44, v77);\n\treturn v44;\nL_003E:\n\tv64 = v44 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0034;\n\tthrow System.NullReferenceException;\nL_0045:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateUDP()
		{
			UDPImpl uDPImpl = new UDPImpl();
			BindExtension((IUDPExtensions)uDPImpl);
			INativeStore androidNativeStore = GetAndroidNativeStore(uDPImpl);
			INativeUDPStore nativeStore;
			if (androidNativeStore != null)
			{
				INativeUDPStore nativeUDPStore = androidNativeStore as INativeUDPStore;
				if (nativeUDPStore == null)
				{
					return (IStore)new InvalidCastException();
				}
				nativeStore = nativeUDPStore;
			}
			else
			{
				bool flag = uDPImpl == null;
				bool flag2 = !flag;
				nativeStore = null;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			uDPImpl.SetNativeStore(nativeStore);
			return uDPImpl;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0xC70874", Offset = "0xC70874", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = UnityEngine.Purchasing.StandardPurchasingModule::GetAndroidNativeStore(this, store);\n\tstore.store = v10;\n\treturn store;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateAndroidHelper(JSONStore store)
		{
			INativeStore androidNativeStore = GetAndroidNativeStore(store);
			store.store = androidNativeStore;
			return store;
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0xC708A8", Offset = "0xC708A8", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv26 = *([1F0BAB0]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, store, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20233C9]) = v45;\nL_0023:\n\tgoto L_0056;\n\tv59 = *([v50 @ X8_v3+B0]);\n\tv60 = 0;\n\tv61 = v59 + 8;\n\tv63 = *([v110 @ X11_v5-8]);\n\tv116 = v63 == v55;\n\tif (v116) goto L_0043;\n\tv96 = v111 + 1;\n\tv183 = v96 < v54;\n\tv90 = ~v183;\n\tv93 = v110 + 0x10;\n\tv66 = ~v90;\n\tif (v66) goto L_FFFFFFFF;\n\tv97 = v46;\n\tv98 = 0;\n\tv99 = 0x8909C4(v97, v55, v98, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0056;\nL_0043:\n\tv184 = *([v110 @ X11_v5]);\n\tv185 = v184 << 4;\n\tv186 = v50 + v185;\n\tv187 = v186 + 0x130;\nL_0056:\n\tinterfaceTailCallResult = UnityEngine.Purchasing.INativeStoreProvider::GetAndroidStore(this.m_NativeStoreProvider, store, this.m_AppStorePlatform, this.m_Binder, this.<util>k__BackingField);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private INativeStore GetAndroidNativeStore(JSONStore store)
		{
			return m_NativeStoreProvider.GetAndroidStore(store, appStore, m_Binder, util);
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0xC702AC", Offset = "0xC702AC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0FA90]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20233CA]) = v38;\nL_0017:\n\tv43 = UnityEngine.GameObject::Find(\"IAPUtil\");\n\tv48 = UnityEngine.GameObject::AddComponent(v43);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v48);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v48);\n\treturn v48;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateCloudMoolah()
		{
			GameObject gameObject = GameObject.Find("IAPUtil");
			MoolahStoreImpl moolahStoreImpl = gameObject.AddComponent<MoolahStoreImpl>();
			BindConfiguration((IMoolahConfiguration)moolahStoreImpl);
			BindExtension((IMoolahExtension)moolahStoreImpl);
			return moolahStoreImpl;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0xC70198", Offset = "0xC70198", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC4828]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20233CB]) = v40;\nL_0018:\n\tv45 = new UnityEngine.Purchasing.AppleStoreImpl();\n\tUnityEngine.Purchasing.AppleStoreImpl::.ctor(v45, this.<util>k__BackingField);\n\tv48 = this.m_NativeStoreProvider;\n\tv51 = *([v48 @ X21_v2 (UnityEngine.Purchasing.INativeStoreProvider)]);\n\tv55 = *([v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]) == 0;\n\tif (v55) goto L_0043;\n\tv150 = *([v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]) + 8;\nL_002E:\n\tv156 = *([v150 @ X11_v6-8]) == UnityEngine.Purchasing.INativeStoreProvider;\n\tif (v156) goto L_0046;\n\tv151 = v151 + 1;\n\tv194 = v151 < *([v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]);\n\tv132 = ~v194;\n\tv150 = v150 + 0x10;\n\tv116 = ~v132;\n\tif (v116) goto L_002E;\nL_0043:\n\tv201 = 0x8909C4(v48, UnityEngine.Purchasing.INativeStoreProvider, 1, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_004E;\nL_0046:\n\tv196 = *([v150 @ X11_v6]) + 1;\n\tv197 = v196 << 4;\n\tv198 = v51 + v197;\n\tv201 = v198 + 0x130;\nL_004E:\n\t*([v201 @ X0_v7])(v103, v48, v45, *([v201 @ X0_v7+8]), v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tUnityEngine.Purchasing.AppleStoreImpl::SetNativeStore(v45, v103);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindExtension(this, v45);\n\treturn v45;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateApple()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			AppleStoreImpl appleStoreImpl = new AppleStoreImpl(util);
			INativeStoreProvider nativeStoreProvider = m_NativeStoreProvider;
			IntPtr intPtr = (IntPtr)nativeStoreProvider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeStoreProvider))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016a;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_016a;
			IL_016a:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v201 @ X0_v7] (should have been resolved before IL gen)");
			INativeAppleStore nativeStore = default(INativeAppleStore);
			appleStoreImpl.SetNativeStore(nativeStore);
			BindExtension((IAppleExtensions)appleStoreImpl);
			return appleStoreImpl;
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0xC7098C", Offset = "0xC7098C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.windowsStore == 0;\n\tif (v11) goto L_001C;\n\tv15 = UnityEngine.Purchasing.Default.Factory::Create(value);\n\tUnityEngine.Purchasing.WinRTStore::SetWindowsIAP(this.windowsStore, v15);\n\treturn;\nL_001C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UseMockWindowsStore(bool value)
		{
			if (windowsStore != null)
			{
				IWindowsIAP windowsIAP = Factory.Create(value);
				windowsStore.SetWindowsIAP(windowsIAP);
			}
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xC70490", Offset = "0xC70490", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED7EE0]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20233CC]) = v44;\nL_0018:\n\tv47 = UnityEngine.Purchasing.Default.Factory::Create(0);\n\tv55 = new UnityEngine.Purchasing.WinRTStore();\n\tUnityEngine.Purchasing.WinRTStore::.ctor(v55, v47, this.<util>k__BackingField, this.<logger>k__BackingField);\n\tthis.windowsStore = v55;\n\tv62 = this.<util>k__BackingField;\n\tv65 = new System.Action`1<System.Boolean>();\n\tSystem.Action`1<System.Boolean>::.ctor(v65, v55, Il2CppMethodInfo);\n\tv76 = *([v62 @ X20_v3 (System.Action`1<System.Boolean>)]);\n\tv80 = *([v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+126]) == 0;\n\tif (v80) goto L_005C;\n\tv134 = *([v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]) + 8;\nL_0047:\n\tv140 = *([v134 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v140) goto L_005F;\n\tv135 = v135 + 1;\n\tv198 = v135 < *([v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+126]);\n\tv114 = ~v198;\n\tv134 = v134 + 0x10;\n\tv90 = ~v114;\n\tif (v90) goto L_0047;\nL_005C:\n\tv205 = System.Action`1<System.Boolean>::.ctor(v62, Uniject.IUtil, 0x10);\n\tgoto L_0067;\nL_005F:\n\tv200 = *([v134 @ X11_v5]) + 0x10;\n\tv201 = v200 << 4;\n\tv202 = v76 + v201;\n\tv205 = v202 + 0x130;\nL_0067:\n\t*([v205 @ X0_v10 (System.Action`1<System.Boolean>)])(v208, v62, v65, *([v205 @ X0_v10 (System.Action`1<System.Boolean>)+8]), Il2CppMethodInfo, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn this.windowsStore;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 82 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore instantiateWindowsStore()
		{
			//IL_003a: Expected I, but got O
			//IL_0075: Expected O, but got I
			//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ed: Expected O, but got Unknown
			//IL_010a: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_00c1: Expected O, but got I
			IWindowsIAP win = Factory.Create(mocked: false);
			WinRTStore winRTStore = (windowsStore = new WinRTStore(win, util, logger));
			Action<bool> action = (Action<bool>)(object)util;
			Action<bool> action2 = winRTStore.restoreTransactions;
			IntPtr intPtr = (IntPtr)action;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)typeof(IUtil))
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X8_v10 (Il2CppClass<System.Action`1<System.Boolean>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					object obj2 = obj + 16;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					Action<bool> action3 = (Action<bool>)((long)(IntPtr)obj3 + 304L);
					break;
				}
				while (!flag2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v205 @ X0_v10 (System.Action`1<System.Boolean>)] (should have been resolved before IL gen)");
			return windowsStore;
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xC705DC", Offset = "0xC705DC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF7198]);\n\tv23 = *([v22 @ X8_v14]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20233CD]) = v42;\nL_0019:\n\tv47 = new UnityEngine.Purchasing.TizenStoreImpl();\n\tUnityEngine.Purchasing.TizenStoreImpl::.ctor(v47, this.<util>k__BackingField);\n\tv51 = this.m_NativeStoreProvider;\n\tv54 = *([v51 @ X21_v2 (UnityEngine.Purchasing.INativeStoreProvider)]);\n\tv59 = *([v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]) == 0;\n\tif (v59) goto L_0046;\n\tv157 = *([v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]) + 8;\nL_0031:\n\tv163 = *([v157 @ X11_v6-8]) == UnityEngine.Purchasing.INativeStoreProvider;\n\tif (v163) goto L_0049;\n\tv158 = v158 + 1;\n\tv204 = v158 < *([v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]);\n\tv139 = ~v204;\n\tv157 = v157 + 0x10;\n\tv123 = ~v139;\n\tif (v123) goto L_0031;\nL_0046:\n\tv211 = 0x8909C4(v51, UnityEngine.Purchasing.INativeStoreProvider, 2, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0052;\nL_0049:\n\tv206 = *([v157 @ X11_v6]) + 2;\n\tv207 = v206 << 4;\n\tv208 = v54 + v207;\n\tv211 = v208 + 0x130;\nL_0052:\n\t*([v211 @ X0_v7])(v110, v51, v47, this.m_Binder, *([v211 @ X0_v7+8]), v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tUnityEngine.Purchasing.TizenStoreImpl::SetNativeStore(v47, v110);\n\tUnityEngine.Purchasing.Extension.AbstractPurchasingModule::BindConfiguration(this, v47);\n\treturn v47;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateTizen()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			TizenStoreImpl tizenStoreImpl = new TizenStoreImpl(util);
			INativeStoreProvider nativeStoreProvider = m_NativeStoreProvider;
			IntPtr intPtr = (IntPtr)nativeStoreProvider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X11_v6-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeStoreProvider))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_016a;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_016a;
			IL_016a:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v211 @ X0_v7] (should have been resolved before IL gen)");
			INativeTizenStore nativeStore = default(INativeTizenStore);
			tizenStoreImpl.SetNativeStore(nativeStore);
			BindConfiguration((ITizenStoreConfiguration)tizenStoreImpl);
			return tizenStoreImpl;
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xC70700", Offset = "0xC70700", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EC6F48]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20233CE]) = v40;\nL_0014:\n\tv41 = this.m_NativeStoreProvider;\n\tv44 = *([v41 @ X20_v2 (UnityEngine.Purchasing.INativeStoreProvider)]);\n\tv48 = *([v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]) == 0;\n\tif (v48) goto L_003B;\n\tv190 = *([v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]) + 8;\nL_0026:\n\tv196 = *([v190 @ X11_v13-8]) == UnityEngine.Purchasing.INativeStoreProvider;\n\tif (v196) goto L_003E;\n\tv191 = v191 + 1;\n\tv201 = v191 < *([v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]);\n\tv130 = ~v201;\n\tv190 = v190 + 0x10;\n\tv114 = ~v130;\n\tif (v114) goto L_0026;\nL_003B:\n\tv207 = 0x8909C4(v41, UnityEngine.Purchasing.INativeStoreProvider, 3, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0045;\nL_003E:\n\tv203 = *([v190 @ X11_v13]) + 3;\n\tv204 = v203 << 4;\n\tv205 = v44 + v204;\n\tv207 = v205 + 0x130;\nL_0045:\n\t*([v207 @ X0_v6])(v172, v41, *([v207 @ X0_v6+8]), 3, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0076;\n\tv249 = *([v244 @ X8_v8+B0]);\n\tv250 = 0;\n\tv251 = v249 + 8;\n\tv253 = *([v289 @ X11_v8-8]);\n\tv295 = v253 == v247;\n\tif (v295) goto L_006F;\n\tv275 = v290 + 1;\n\tv300 = v275 < v246;\n\tv271 = ~v300;\n\tv273 = v289 + 0x10;\n\tv255 = ~v271;\n\tif (v255) goto L_FFFFFFFF;\n\tv276 = v106;\n\tv277 = 0;\n\tv278 = 0x8909C4(v276, v247, v277, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0076;\nL_006F:\n\tv301 = *([v289 @ X11_v8]);\n\tv302 = v301 << 4;\n\tv303 = v244 + v302;\n\tv304 = v303 + 0x130;\nL_0076:\n\tv310 = UnityEngine.Purchasing.INativeFacebookStore::Check(v172);\n\tv312 = v310 == 0;\n\tif (v312) goto L_FFFFFFFF;\n\tv98 = new UnityEngine.Purchasing.FacebookStoreImpl();\n\tUnityEngine.Purchasing.FacebookStoreImpl::.ctor(v98, this.<util>k__BackingField);\n\tUnityEngine.Purchasing.FacebookStoreImpl::SetNativeStore(v98, v172);\n\tgoto L_0090;\nL_0090:\n\treturn v320;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateFacebook()
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			INativeStoreProvider nativeStoreProvider = m_NativeStoreProvider;
			IntPtr intPtr = (IntPtr)nativeStoreProvider;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X11_v13-8]");
				if ((IntPtr)0 == (IntPtr)typeof(INativeStoreProvider))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v5 (Il2CppClass<UnityEngine.Purchasing.INativeStoreProvider>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0177;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			goto IL_0177;
			IL_0177:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v207 @ X0_v6] (should have been resolved before IL gen)");
			INativeFacebookStore nativeFacebookStore = default(INativeFacebookStore);
			if (nativeFacebookStore.Check())
			{
				FacebookStoreImpl facebookStoreImpl = new FacebookStoreImpl(util);
				facebookStoreImpl.SetNativeStore(nativeFacebookStore);
				return facebookStoreImpl;
			}
			return null;
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xC700C8", Offset = "0xC700C8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED6D18]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20233CF]) = v38;\nL_0014:\n\tv40 = this.<useFakeStoreUIMode>k__BackingField == 0;\n\tif (v40) goto L_0025;\n\tv44 = new UnityEngine.Purchasing.UIFakeStore();\n\tUnityEngine.Purchasing.UIFakeStore::.ctor(v44);\n\tv44.UIMode = this.<useFakeStoreUIMode>k__BackingField;\n\tgoto L_002E;\nL_0025:\n\tv48 = new UnityEngine.Purchasing.FakeStore();\n\tUnityEngine.Purchasing.FakeStore::.ctor(v48);\nL_002E:\n\treturn v58;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IStore InstantiateFakeStore()
		{
			if (useFakeStoreUIMode != FakeStoreUIMode.Default)
			{
				UIFakeStore uIFakeStore = new UIFakeStore();
				uIFakeStore.UIMode = useFakeStoreUIMode;
				return uIFakeStore;
			}
			return new FakeStore();
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0xC709E4", Offset = "0xC709E4", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECC510]);\n\tv19 = *([v18 @ X8_v19]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([20233D0]) = v39;\nL_0016:\n\tv43 = new System.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::.ctor(v43);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 2, \"AmazonApps\");\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 1, \"GooglePlay\");\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 4, \"SamsungApps\");\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 3, \"MoolahAppStore\");\n\tv98 = UnityEngine.Purchasing.UDP::get_Name();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 6, v98);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Purchasing.AppStore, System.String>::Add(v43, 0, \"GooglePlay\");\n\tv86.AndroidStoreNameMap = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static StandardPurchasingModule()
		{
			Dictionary<AppStore, string> dictionary = new Dictionary<AppStore, string>
			{
				{
					AppStore.AmazonAppStore,
					"AmazonApps"
				},
				{
					AppStore.GooglePlay,
					"GooglePlay"
				},
				{
					AppStore.SamsungApps,
					"SamsungApps"
				},
				{
					AppStore.CloudMoolah,
					"MoolahAppStore"
				}
			};
			string name = UDP.Name;
			dictionary.Add(AppStore.UDP, name);
			dictionary.Add(default(AppStore), "GooglePlay");
			AndroidStoreNameMap = dictionary;
		}
	}
}
