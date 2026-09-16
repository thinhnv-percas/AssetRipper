using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000015")]
	public class StoreService
	{
		[Token(Token = "0x400004A")]
		private static AndroidJavaClass serviceClass;

		[Token(Token = "0x17000015")]
		public static string StoreName
		{
			[Token(Token = "0x600006F")]
			[Address(RVA = "0x15CBFCC", Offset = "0x15CBFCC", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv13 = *([1EEECE8]);\n\tv14 = *([v13 @ X8_v6]);\n\tv15 = \"il2cpp_codegen_initialize_method\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0 | 1;\n\t*([20299EC]) = v34;\nL_0013:\n\treturnVal1 = 0x15CCEB8(v31, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\treturn returnVal1;\n\tX8 = *([X8+B8]);\n\tX19 = *([X8]);\n\tif (TEMP) goto L_0028;\n\tX8 = *([1EFE3C0]);\n\tX1 = 0;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EDAEE8]);\n\tX9 = *([1EBBC78]);\n\tX2 = X0;\n\tX0 = X19;\n\tX1 = *([X8]);\n\tX3 = *([X9]);\n\tX0 = UnityEngine.AndroidJavaObject::CallStatic /* +2 sharing this address */(X0, X1, X2, X3);\n\tgoto L_002B;\nL_0028:\n\tX8 = 0x1EDC000;\n\tX8 = *([1EDC808]);\n\tX0 = *([X8]);\nL_002B:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 46 ShiftStack 32\n\treturn X0;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15CCEB8 (inside UnityEngine.UDP.Utils::.cctor +0x80)");
				string result = default(string);
				return result;
			}
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x15CB93C", Offset = "0x15CB93C", Length = "0x5FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv36 = *([1EC2DD0]);\n\tv37 = *([v36 @ X8_v92]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, appInfo, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([20299E8]) = v55;\nL_001D:\n\tv57 = UnityEngine.Application::get_platform();\n\tv69 = v57 <= 7;\n\tif (v69) goto L_00B7;\n\tv74 = v57 == 0x10;\n\tif (v74) goto L_00CC;\n\tv89 = v57 != 0xB;\n\tif (v89) goto L_0213;\n\tv114 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v114, \"com.unity.udp.sdk.ChannelService\");\n\tv306.serviceClass = v114;\n\tgoto L_005F;\n\tv393 = *([v307 @ X0_v29 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv394 = v393 == 0;\n\tv395 = ~v394;\n\tif (v395) goto L_005F;\n\tv449 = \"il2cpp_codegen_runtime_class_init\"(v307, v268, v266, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv397 = UnityEngine.UDP.MainThreadDispatcher;\nL_005F:\n\tv403 = UnityEngine.GameObject::Find(v400.OBJECT_NAME);\n\tgoto L_0071;\n\tv576 = *([v452 @ X8_v32+E0]);\n\tv577 = v576 == 0;\n\tv578 = ~v577;\n\tgoto L_0071;\n\tv586 = v452;\n\tv580 = \"il2cpp_codegen_runtime_class_init\"(v586, v401, v266, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0071:\n\tv585 = UnityEngine.Object::op_Equality(v403, 0);\n\tv588 = v585 == 0;\n\tif (v588) goto L_0081;\n\tgoto L_007F;\n\tv679 = *([v634 @ X0_v99 (Il2CppClass<UnityEngine.UDP.MainThreadDispatcher>)+E0]);\n\tv680 = v679 == 0;\n\tv681 = ~v680;\n\tif (v681) goto L_007F;\n\tv682 = \"il2cpp_codegen_runtime_class_init\"(v634, v583, v584, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_007F:\n\tUnityEngine.UDP.MainThreadDispatcher::init();\nL_0081:\n\tv239 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v239, \"com.unity3d.player.UnityPlayer\");\n\tv698 = UnityEngine.AndroidJavaObject::GetStatic(v239, \"currentActivity\");\n\tv703 = new UnityEngine.UDP.InitLoginForwardCallback();\n\tUnityEngine.UDP.InitLoginForwardCallback::.ctor(v703, listener);\n\t// 159 NewArr v708 @ X0_v44 (System.Object[]), typeof(System.Object[]), 0\n\tv240 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v240, \"com.unity.udp.sdk.AppInfo\", v708);\n\tv715 = appInfo == 0;\n\tif (v715) goto L_0108;\n\tv207 = appInfo + 0x10;\n\tv729 = appInfo + 0x20;\n\tv198 = appInfo + 0x18;\n\tv195 = appInfo + 0x28;\n\tv716 = v240 == 0;\n\tv245 = ~v716;\n\tif (v245) goto L_013D;\n\tgoto L_020F;\nL_00B7:\n\tv79 = v57 == 0;\n\tif (v79) goto L_00CC;\n\tv91 = v57 != 7;\n\tif (v91) goto L_0213;\nL_00CC:\n\tgoto L_0101;\n\tv271 = *([v182 @ X8_v20+B0]);\n\tv272 = 0;\n\tv273 = v271 + 8;\n\tv275 = *([v373 @ X11_v12-8]);\n\tv388 = v275 == v185;\n\tif (v388) goto L_00EC;\n\tv280 = v374 + 1;\n\tv410 = v280 < v184;\n\tv298 = ~v410;\n\tv278 = v373 + 0x10;\n\tv282 = ~v298;\n\tif (v282) goto L_FFFFFFFF;\n\tv299 = v30;\n\tv300 = 0;\n\tv301 = 0x8909C4(v299, v185, v300, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tgoto L_0101;\nL_00EC:\n\tv411 = *([v373 @ X11_v12]);\n\tv412 = v411 << 4;\n\tv413 = v182 + v412;\n\tv414 = v413 + 0x130;\nL_0101:\n\tUnityEngine.UDP.IInitListener::OnInitialized(listener, 0);\nL_0108:\n\tv723 = UnityEngine.Resources::Load(\"UDP Settings\");\n\tgoto L_0118;\n\tv748 = *([v256 @ X8_v83+E0]);\n\tv749 = v748 == 0;\n\tv750 = ~v749;\n\tif (v750) goto L_0118;\n\tv761 = v256;\n\tv752 = \"il2cpp_codegen_runtime_class_init\"(v761, v722, v219, v199, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0118:\n\tv241 = UnityEngine.Object::op_Equality(v723, 0);\n\tv231 = v241 == 0;\n\tv224 = ~v231;\n\tv190 = ~v224;\n\tif (v190) goto L_FFFFFFFF;\n\tgoto L_0126;\nL_0126:\n\tv771 = v241 == 0;\n\tv685 = ~v771;\n\tif (v685) goto L_022A;\n\tv207 = v193 + 0x20;\n\tv729 = v193 + 0x28;\n\tv198 = v193 + 0x40;\n\tv195 = v193 + 0x30;\nL_013D:\n\tUnityEngine.AndroidJavaObject::Set(v240, \"clientId\", *([v207 @ X9_v15]));\n\tUnityEngine.AndroidJavaObject::Set(v240, \"clientSecret\", *([v729 @ X8_v46]));\n\tUnityEngine.AndroidJavaObject::Set(v240, \"appSlug\", *([v198 @ X10_v15]));\n\tUnityEngine.AndroidJavaObject::Set(v240, \"RSAPublicKey\", *([v195 @ X11_v14]));\n\tv769 = UnityEngine.UDP.StoreService::safetyServiceClass();\n\t// 344 NewArr v670 @ X0_v54 (System.Object[]), typeof(System.Object[]), 3\n\tv773 = v698 == 0;\n\tif (v773) goto L_0165;\n\t// 353 IsInst v777 @ X0_v91, typeof(System.Object), v698 @ X0_v40 (UnityEngine.AndroidJavaObject)\nL_0165:\n\tv499 = v670.Length == 0;\n\tif (v499) goto L_0220;\n\tv670[0] = v698;\n\t// 363 IsInst v497 @ X0_v59, typeof(System.Object), v240 @ X0_v46 (UnityEngine.AndroidJavaObject)\n\tv258 = v670.Length;\n\tv788 = v670.Length < 1;\n\tv494 = ~v788;\n\tv491 = v670.Length - 1;\n\tv486 = v491 == 0;\n\tv789 = ~v494;\n\tv474 = v789 | v486;\n\tif (v474) goto L_0220;\n\tv670[1] = v240;\n\tv790 = v703 == 0;\n\tif (v790) goto L_0185;\n\t// 385 IsInst v785 @ X0_v89, typeof(System.Object), v703 @ X0_v42 (UnityEngine.UDP.InitLoginForwardCallback)\n\tv258 = v670.Length;\nL_0185:\n\tv793 = v258 < 2;\n\tv237 = ~v793;\n\tv235 = v258 - 2;\n\tv232 = v235 == 0;\n\tv794 = ~v237;\n\tv225 = v794 | v232;\n\tif (v225) goto L_0220;\n\tv670[2] = v703;\n\tUnityEngine.AndroidJavaObject::CallStatic(v769, \"init\", v670);\n\tUnityEngine.UDP.Analytics.AnalyticsService::Initialize();\n\tv800 = UnityEngine.UDP.StoreService::get_StoreName();\n\tUnityEngine.UDP.Analytics.AnalyticsClient::Initialize(*([v207 @ X9_v15]), *([v198 @ X10_v15]), v800);\n\tgoto L_01B1;\n\tv810 = *([v806 @ X0_v64 (Il2CppClass<UnityEngine.UDP.UdpGameManager>)+E0]);\n\tv811 = v810 == 0;\n\tv812 = ~v811;\n\tif (v812) goto L_01B1;\n\tv821 = \"il2cpp_codegen_runtime_class_init\"(v806, v803, v801, v201, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv814 = UnityEngine.UDP.UdpGameManager;\nL_01B1:\n\tv820 = UnityEngine.GameObject::Find(v817.OBJECT_NAME);\n\tgoto L_01C1;\n\tv826 = *([v569 @ X8_v67+E0]);\n\tv827 = v826 == 0;\n\tv828 = ~v827;\n\tgoto L_01C1;\n\tv833 = v569;\n\tv830 = \"il2cpp_codegen_runtime_class_init\"(v833, v818, v801, v201, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_01C1:\n\tv558 = UnityEngine.Object::op_Equality(v820, 0);\n\tv560 = v558 == 0;\n\tif (v560) goto L_020D;\n\tgoto L_01D5;\n\tv839 = *([v835 @ X0_v71 (Il2CppClass<UnityEngine.UDP.UdpGameManager>)+E0]);\n\tv840 = v839 == 0;\n\tv841 = ~v840;\n\tif (v841) goto L_01D5;\n\tv850 = \"il2cpp_codegen_runtime_class_init\"(v835, v540, v543, v201, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv843 = UnityEngine.UDP.UdpGameManager;\nL_01D5:\n\tv849 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v849, v847.OBJECT_NAME);\n\tgoto L_01E6;\n\tv856 = *([v852 @ X0_v75+E0]);\n\tv857 = v856 == 0;\n\tv858 = ~v857;\n\tgoto L_01E6;\n\tv860 = \"il2cpp_codegen_runtime_class_init\"(v852, v851, v222, v201, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_01E6:\n\tUnityEngine.Object::DontDestroyOnLoad(v849);\n\tUnityEngine.Object::set_hideFlags(v849, 3);\n\tv557 = UnityEngine.GameObject::AddComponent(v849);\n\treturn;\nL_020D:\n\treturn;\nL_020F:\n\tthrow System.NullReferenceException;\nL_0213:\n\tv357 = new System.InvalidOperationException();\nL_0219:\n\tSystem.InvalidOperationException::.ctor(v357, *([v365 @ X8_v3 (System.String)]));\n\tv409 = new System.TypeLoadException();\nL_0220:\n\tv508 = new System.IndexOutOfRangeException();\n\tgoto L_0225;\n\tv623 = new System.ArrayTypeMismatchException();\nL_0225:\n\tthrow v622;\n\tthrow System.NullReferenceException;\nL_022A:\n\tv357 = new System.InvalidOperationException();\n\tgoto L_0219;\n\treturn;\n// 365 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Initialize(IInitListener listener, AppInfo appInfo = null)
		{
			//IL_012e: Expected O, but got I
			//IL_013d: Expected O, but got I
			//IL_014c: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_0244: Expected O, but got I
			//IL_0253: Expected O, but got I
			//IL_0262: Expected O, but got I
			//IL_0271: Expected O, but got I
			//IL_0360: Expected O, but got I4
			//IL_038c: Expected O, but got I4
			//IL_05ab: Expected O, but got I
			//IL_040c: Expected O, but got I4
			RuntimePlatform platform = Application.platform;
			InvalidOperationException ex;
			string text = default(string);
			if (platform > RuntimePlatform.WindowsEditor)
			{
				if (platform != RuntimePlatform.LinuxEditor)
				{
					if (platform != RuntimePlatform.Android)
					{
						goto IL_04ce;
					}
					AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity.udp.sdk.ChannelService");
					serviceClass = androidJavaClass;
					GameObject gameObject = GameObject.Find(MainThreadDispatcher.OBJECT_NAME);
					if (gameObject == null)
					{
						MainThreadDispatcher.init();
					}
					AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
					AndroidJavaObject androidJavaObject = androidJavaClass2.GetStatic<AndroidJavaObject>("currentActivity");
					InitLoginForwardCallback initLoginForwardCallback = new InitLoginForwardCallback(listener);
					object[] args = new object[0];
					AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("com.unity.udp.sdk.AppInfo", args);
					object obj;
					object val;
					object obj2;
					object val2;
					if (appInfo != null)
					{
						obj = (long)(IntPtr)appInfo + 16L;
						val = (long)(IntPtr)appInfo + 32L;
						obj2 = (long)(IntPtr)appInfo + 24L;
						val2 = (long)(IntPtr)appInfo + 40L;
						if (androidJavaObject2 == null)
						{
							throw new NullReferenceException();
						}
					}
					else
					{
						AppStoreSettings appStoreSettings = Resources.Load<AppStoreSettings>("UDP Settings");
						bool flag = appStoreSettings == null;
						AppStoreSettings appStoreSettings2 = ((!flag) ? appStoreSettings : null);
						if (flag)
						{
							ex = new InvalidOperationException();
							text = "StoreService cannot find valid GameSettings.asset file! Initialization failed!";
							goto IL_0607;
						}
						obj = (long)(IntPtr)appStoreSettings2 + 32L;
						val = (long)(IntPtr)appStoreSettings2 + 40L;
						obj2 = (long)(IntPtr)appStoreSettings2 + 64L;
						val2 = (long)(IntPtr)appStoreSettings2 + 48L;
					}
					androidJavaObject2.Set("clientId", (string)obj);
					androidJavaObject2.Set("clientSecret", (string)val);
					androidJavaObject2.Set("appSlug", (string)obj2);
					androidJavaObject2.Set("RSAPublicKey", (string)val2);
					AndroidJavaClass androidJavaClass3 = safetyServiceClass();
					object[] array = new object[3];
					if (androidJavaObject != null)
					{
						object obj3 = androidJavaObject as object;
					}
					if (array.Length != 0)
					{
						array[0] = androidJavaObject;
						object obj4 = androidJavaObject2 as object;
						object obj5 = array.Length;
						bool flag2 = array.Length < 1;
						bool flag3 = !flag2;
						object obj6 = array.Length - 1;
						bool flag4 = obj6 == null;
						bool flag5 = !flag3;
						if (!(flag5 || flag4))
						{
							array[1] = androidJavaObject2;
							if (initLoginForwardCallback != null)
							{
								object obj7 = initLoginForwardCallback as object;
								obj5 = array.Length;
							}
							bool flag6 = (long)(IntPtr)obj5 < 2L;
							bool flag7 = !flag6;
							object obj8 = (long)(IntPtr)obj5 - 2L;
							bool flag8 = obj8 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								array[2] = initLoginForwardCallback;
								androidJavaClass3.CallStatic("init", array);
								AnalyticsService.Initialize();
								string storeName = StoreName;
								AnalyticsClient.Initialize((string)obj, (string)obj2, storeName);
								GameObject gameObject2 = GameObject.Find(UdpGameManager.OBJECT_NAME);
								if (gameObject2 == null)
								{
									GameObject gameObject3 = new GameObject(UdpGameManager.OBJECT_NAME);
									Object.DontDestroyOnLoad(gameObject3);
									gameObject3.hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;
									UdpGameManager udpGameManager = gameObject3.AddComponent<UdpGameManager>();
								}
								return;
							}
						}
					}
					goto IL_04e9;
				}
			}
			else if (platform != RuntimePlatform.OSXEditor && platform != RuntimePlatform.WindowsEditor)
			{
				goto IL_04ce;
			}
			listener.OnInitialized(null);
			return;
			IL_04ce:
			ex = new InvalidOperationException(text);
			text = "StoreService doesn't support current platform!";
			goto IL_0607;
			IL_04e9:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			IndexOutOfRangeException ex3 = default(IndexOutOfRangeException);
			throw ex3;
			IL_0607:
			TypeLoadException ex4 = new TypeLoadException();
			goto IL_04e9;
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x15CC068", Offset = "0x15CC068", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv32 = *([1ED5288]);\n\tv33 = *([v32 @ X8_v40]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, developerPayload, listener, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20299E9]) = v50;\nL_0022:\n\tgoto L_0029;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0029;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, developerPayload, listener, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0029:\n\tv67 = System.Guid::NewGuid();\n\tv72 = 0xC12510(&v67 @ X0_v5 (System.Guid), 0, listener, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv83 = System.String::Replace(v72, \"-\", v79.Empty);\n\tv115 = UnityEngine.UDP.Analytics.UdpAnalytics::PurchaseAttempt(productId, v83);\n\tv169 = new UnityEngine.UDP.PurchaseForwardCallback();\n\tUnityEngine.UDP.PurchaseForwardCallback::.ctor(v169, listener);\n\t// 74 NewArr v218 @ X0_v20 (System.Object[]), typeof(System.Object[]), 0\n\tv224 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v224, \"com.unity.udp.sdk.PurchaseInfo\", v218);\n\tUnityEngine.AndroidJavaObject::Set(v224, \"productId\", productId);\n\tUnityEngine.AndroidJavaObject::Set(v224, \"gameOrderId\", v83);\n\tUnityEngine.AndroidJavaObject::Set(v224, \"developerPayload\", developerPayload);\n\tv315 = UnityEngine.UDP.StoreService::safetyServiceClass();\n\t// 118 NewArr v99 @ X0_v33 (System.Object[]), typeof(System.Object[]), 2\n\t// 125 IsInst v67 @ X0_v5 (System.Guid), typeof(System.Object), v224 @ X0_v22 (UnityEngine.AndroidJavaObject)\n\tv163 = v99.Length;\n\tv156 = v99.Length == 0;\n\tif (v156) goto L_00AF;\n\tv99[0] = v224;\n\tv318 = v169 == 0;\n\tif (v318) goto L_008D;\n\t// 137 IsInst v67 @ X0_v5 (System.Guid), typeof(System.Object), v169 @ X0_v18 (UnityEngine.UDP.PurchaseForwardCallback)\n\tv163 = v99.Length;\nL_008D:\n\tv321 = v163 < 1;\n\tv142 = ~v321;\n\tv139 = v163 - 1;\n\tv133 = v139 == 0;\n\tv322 = ~v142;\n\tv118 = v322 | v133;\n\tif (v118) goto L_00AF;\n\tv99[1] = v169;\n\tUnityEngine.AndroidJavaObject::CallStatic(v315, \"purchase\", v99);\n\treturn;\n\tv112 = new System.NullReferenceException();\nL_00AF:\n\tv165 = new System.IndexOutOfRangeException();\n\tgoto L_00B6;\n\tv297 = new System.NullReferenceException();\n\tv201 = new System.ArrayTypeMismatchException();\nL_00B6:\n\tthrow v200;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void Purchase(string productId, string developerPayload, IPurchaseListener listener)
		{
			//IL_0105: Expected O, but got I4
			//IL_01df: Expected O, but got I
			//IL_016f: Expected O, but got I4
			Guid guid = Guid.NewGuid();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @C12510 (inside System.Guid::StringToLong +0x320)");
			string text2 = default(string);
			string text = text2.Replace("-", string.Empty);
			AnalyticsResult analyticsResult = UdpAnalytics.PurchaseAttempt(productId, text);
			PurchaseForwardCallback purchaseForwardCallback = new PurchaseForwardCallback(listener);
			object[] args = new object[0];
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.unity.udp.sdk.PurchaseInfo", args);
			androidJavaObject.Set("productId", productId);
			androidJavaObject.Set("gameOrderId", text);
			androidJavaObject.Set("developerPayload", developerPayload);
			AndroidJavaClass androidJavaClass = safetyServiceClass();
			object[] array = new object[2];
			guid = (Guid)(androidJavaObject as object);
			object obj = array.Length;
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				if (purchaseForwardCallback != null)
				{
					guid = (Guid)(purchaseForwardCallback as object);
					obj = array.Length;
				}
				bool flag = (long)(IntPtr)obj < 1L;
				bool flag2 = !flag;
				object obj2 = (long)(IntPtr)obj - 1L;
				bool flag3 = obj2 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = purchaseForwardCallback;
					androidJavaClass.CallStatic("purchase", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x15CA940", Offset = "0x15CA940", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EC6168]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, listener, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20299EA]) = v43;\nL_0019:\n\tv47 = new UnityEngine.UDP.PurchaseForwardCallback();\n\tUnityEngine.UDP.PurchaseForwardCallback::.ctor(v47, listener);\n\tv50 = UnityEngine.UDP.StoreService::safetyServiceClass();\n\t// 36 NewArr v57 @ X0_v6 (System.Object[]), typeof(System.Object[]), 2\n\tv60 = UnityEngine.UDP.StoreService::javaArrayFromCSList(productIds);\n\tv63 = v60 == 0;\n\tif (v63) goto L_0033;\n\t// 48 IsInst v104 @ X0_v24, typeof(System.Object), v60 @ X0_v8 (UnityEngine.AndroidJavaObject)\nL_0033:\n\tv98 = v57.Length;\n\tv111 = v57.Length == 0;\n\tif (v111) goto L_005E;\n\tv57[0] = v60;\n\tv130 = v47 == 0;\n\tif (v130) goto L_0040;\n\t// 60 IsInst v124 @ X0_v22, typeof(System.Object), v47 @ X0_v3 (UnityEngine.UDP.PurchaseForwardCallback)\n\tv98 = v57.Length;\nL_0040:\n\tv164 = v98 < 1;\n\tv90 = ~v164;\n\tv87 = v98 - 1;\n\tv81 = v87 == 0;\n\tv165 = ~v90;\n\tv66 = v165 | v81;\n\tif (v66) goto L_005E;\n\tv57[1] = v47;\n\tUnityEngine.AndroidJavaObject::CallStatic(v50, \"queryInventory\", v57);\n\treturn;\nL_005E:\n\tv145 = new System.IndexOutOfRangeException();\n\tgoto L_0065;\n\tv100 = new System.NullReferenceException();\n\tv129 = new System.ArrayTypeMismatchException();\nL_0065:\n\tthrow v156;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void QueryInventory(List<string> productIds, IPurchaseListener listener)
		{
			//IL_005e: Expected O, but got I4
			//IL_014f: Expected O, but got I
			//IL_00c8: Expected O, but got I4
			PurchaseForwardCallback purchaseForwardCallback = new PurchaseForwardCallback(listener);
			AndroidJavaClass androidJavaClass = safetyServiceClass();
			object[] array = new object[2];
			AndroidJavaObject androidJavaObject = javaArrayFromCSList(productIds);
			if (androidJavaObject != null)
			{
				object obj = androidJavaObject as object;
			}
			object obj2 = array.Length;
			if (array.Length != 0)
			{
				array[0] = androidJavaObject;
				if (purchaseForwardCallback != null)
				{
					object obj3 = purchaseForwardCallback as object;
					obj2 = array.Length;
				}
				bool flag = (long)(IntPtr)obj2 < 1L;
				bool flag2 = !flag;
				object obj4 = (long)(IntPtr)obj2 - 1L;
				bool flag3 = obj4 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = purchaseForwardCallback;
					androidJavaClass.CallStatic("queryInventory", array);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x15CC5B4", Offset = "0x15CC5B4", Length = "0x384")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1F03818]);\n\tv31 = *([v30 @ X8_v55]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, listener, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv49 = 0 | 1;\n\t*([20299EB]) = v49;\nL_001C:\n\tv53 = new UnityEngine.UDP.PurchaseForwardCallback();\n\tUnityEngine.UDP.PurchaseForwardCallback::.ctor(v53, listener);\n\t// 36 NewArr v60 @ X0_v5 (System.Object[]), typeof(System.Object[]), 0\n\tv66 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v66, \"com.unity.udp.sdk.PurchaseInfo\", v60);\n\t// 52 NewArr v75 @ X0_v9 (System.Object[]), typeof(System.Object[]), 1\n\tv151 = purchaseInfo.<ItemType>k__BackingField == 0;\n\tif (v151) goto L_0044;\n\t// 64 IsInst v217 @ X0_v68, typeof(System.Object), purchaseInfo.<ItemType>k__BackingField (System.String)\nL_0044:\n\tv221 = v75.Length == 0;\n\tif (v221) goto L_0111;\n\tv75[0] = purchaseInfo.<ItemType>k__BackingField;\n\tv347 = UnityEngine.AndroidJavaObject::Call(v66, \"setItemType\", v75);\n\t// 84 NewArr v192 @ X0_v24 (System.Object[]), typeof(System.Object[]), 1\n\tv352 = purchaseInfo.<ProductId>k__BackingField == 0;\n\tif (v352) goto L_0062;\n\t// 94 IsInst v319 @ X0_v66, typeof(System.Object), purchaseInfo.<ProductId>k__BackingField (System.String)\nL_0062:\n\tv251 = v192.Length == 0;\n\tif (v251) goto L_0111;\n\tv192[0] = purchaseInfo.<ProductId>k__BackingField;\n\tv359 = UnityEngine.AndroidJavaObject::Call(v66, \"setProductId\", v192);\n\t// 110 NewArr v193 @ X0_v29 (System.Object[]), typeof(System.Object[]), 1\n\tv361 = purchaseInfo.<DeveloperPayload>k__BackingField == 0;\n\tif (v361) goto L_007C;\n\t// 120 IsInst v320 @ X0_v64, typeof(System.Object), purchaseInfo.<DeveloperPayload>k__BackingField (System.String)\nL_007C:\n\tv252 = v193.Length == 0;\n\tif (v252) goto L_0111;\n\tv193[0] = purchaseInfo.<DeveloperPayload>k__BackingField;\n\tv368 = UnityEngine.AndroidJavaObject::Call(v66, \"setDeveloperPayload\", v193);\n\t// 136 NewArr v194 @ X0_v34 (System.Object[]), typeof(System.Object[]), 1\n\tv370 = purchaseInfo.<GameOrderId>k__BackingField == 0;\n\tif (v370) goto L_0096;\n\t// 146 IsInst v321 @ X0_v62, typeof(System.Object), purchaseInfo.<GameOrderId>k__BackingField (System.String)\nL_0096:\n\tv253 = v194.Length == 0;\n\tif (v253) goto L_0111;\n\tv194[0] = purchaseInfo.<GameOrderId>k__BackingField;\n\tv377 = UnityEngine.AndroidJavaObject::Call(v66, \"setGameOrderId\", v194);\n\t// 162 NewArr v195 @ X0_v39 (System.Object[]), typeof(System.Object[]), 1\n\tv379 = purchaseInfo.<OrderQueryToken>k__BackingField == 0;\n\tif (v379) goto L_00B0;\n\t// 172 IsInst v322 @ X0_v60, typeof(System.Object), purchaseInfo.<OrderQueryToken>k__BackingField (System.String)\nL_00B0:\n\tv254 = v195.Length == 0;\n\tif (v254) goto L_0111;\n\tv195[0] = purchaseInfo.<OrderQueryToken>k__BackingField;\n\tv386 = UnityEngine.AndroidJavaObject::Call(v66, \"setOrderQueryToken\", v195);\n\t// 188 NewArr v196 @ X0_v44 (System.Object[]), typeof(System.Object[]), 1\n\tv388 = purchaseInfo.<StorePurchaseJsonString>k__BackingField == 0;\n\tif (v388) goto L_00CA;\n\t// 198 IsInst v323 @ X0_v58, typeof(System.Object), purchaseInfo.<StorePurchaseJsonString>k__BackingField (System.String)\nL_00CA:\n\tv255 = v196.Length == 0;\n\tif (v255) goto L_0111;\n\tv196[0] = purchaseInfo.<StorePurchaseJsonString>k__BackingField;\n\tv396 = UnityEngine.AndroidJavaObject::Call(v66, \"setStorePurchaseJsonString\", v196);\n\tv397 = UnityEngine.UDP.StoreService::safetyServiceClass();\n\t// 217 NewArr v197 @ X0_v50 (System.Object[]), typeof(System.Object[]), 2\n\t// 224 IsInst v249 @ X0_v52, typeof(System.Object), v66 @ X0_v7 (UnityEngine.AndroidJavaObject)\n\tv149 = v197.Length;\n\tv256 = v197.Length == 0;\n\tif (v256) goto L_0111;\n\tv197[0] = v66;\n\tv400 = v53 == 0;\n\tif (v400) goto L_00F0;\n\t// 236 IsInst v324 @ X0_v56, typeof(System.Object), v53 @ X0_v3 (UnityEngine.UDP.PurchaseForwardCallback)\n\tv149 = v197.Length;\nL_00F0:\n\tv403 = v149 < 1;\n\tv114 = ~v403;\n\tv110 = v149 - 1;\n\tv102 = v110 == 0;\n\tv404 = ~v114;\n\tv82 = v404 | v102;\n\tif (v82) goto L_0111;\n\tv197[1] = v53;\n\tUnityEngine.AndroidJavaObject::CallStatic(v397, \"consumePurchase\", v197);\n\treturn;\nL_0111:\n\tv267 = new System.IndexOutOfRangeException();\n\tgoto L_0116;\n\tv342 = new System.ArrayTypeMismatchException();\nL_0116:\n\tthrow v350;\n\tthrow System.NullReferenceException;\n// 197 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void ConsumePurchase(PurchaseInfo purchaseInfo, IPurchaseListener listener)
		{
			//IL_03ef: Expected O, but got I4
			//IL_04e5: Expected O, but got I
			//IL_0459: Expected O, but got I4
			PurchaseForwardCallback purchaseForwardCallback = new PurchaseForwardCallback(listener);
			object[] args = new object[0];
			AndroidJavaObject androidJavaObject = new AndroidJavaObject("com.unity.udp.sdk.PurchaseInfo", args);
			object[] array = new object[1];
			if (purchaseInfo.ItemType != null)
			{
				object obj = purchaseInfo.ItemType as object;
			}
			if (array.Length != 0)
			{
				array[0] = purchaseInfo.ItemType;
				AndroidJavaObject androidJavaObject2 = androidJavaObject.Call<AndroidJavaObject>("setItemType", array);
				object[] array2 = new object[1];
				if (purchaseInfo.ProductId != null)
				{
					object obj2 = purchaseInfo.ProductId as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = purchaseInfo.ProductId;
					AndroidJavaObject androidJavaObject3 = androidJavaObject.Call<AndroidJavaObject>("setProductId", array2);
					object[] array3 = new object[1];
					if (purchaseInfo.DeveloperPayload != null)
					{
						object obj3 = purchaseInfo.DeveloperPayload as object;
					}
					if (array3.Length != 0)
					{
						array3[0] = purchaseInfo.DeveloperPayload;
						AndroidJavaObject androidJavaObject4 = androidJavaObject.Call<AndroidJavaObject>("setDeveloperPayload", array3);
						object[] array4 = new object[1];
						if (purchaseInfo.GameOrderId != null)
						{
							object obj4 = purchaseInfo.GameOrderId as object;
						}
						if (array4.Length != 0)
						{
							array4[0] = purchaseInfo.GameOrderId;
							AndroidJavaObject androidJavaObject5 = androidJavaObject.Call<AndroidJavaObject>("setGameOrderId", array4);
							object[] array5 = new object[1];
							if (purchaseInfo.OrderQueryToken != null)
							{
								object obj5 = purchaseInfo.OrderQueryToken as object;
							}
							if (array5.Length != 0)
							{
								array5[0] = purchaseInfo.OrderQueryToken;
								AndroidJavaObject androidJavaObject6 = androidJavaObject.Call<AndroidJavaObject>("setOrderQueryToken", array5);
								object[] array6 = new object[1];
								if (purchaseInfo.StorePurchaseJsonString != null)
								{
									object obj6 = purchaseInfo.StorePurchaseJsonString as object;
								}
								if (array6.Length != 0)
								{
									array6[0] = purchaseInfo.StorePurchaseJsonString;
									AndroidJavaObject androidJavaObject7 = androidJavaObject.Call<AndroidJavaObject>("setStorePurchaseJsonString", array6);
									AndroidJavaClass androidJavaClass = safetyServiceClass();
									object[] array7 = new object[2];
									object obj7 = androidJavaObject as object;
									object obj8 = array7.Length;
									if (array7.Length != 0)
									{
										array7[0] = androidJavaObject;
										if (purchaseForwardCallback != null)
										{
											object obj9 = purchaseForwardCallback as object;
											obj8 = array7.Length;
										}
										bool flag = (long)(IntPtr)obj8 < 1L;
										bool flag2 = !flag;
										object obj10 = (long)(IntPtr)obj8 - 1L;
										bool flag3 = obj10 == null;
										bool flag4 = !flag2;
										if (!(flag4 || flag3))
										{
											array7[1] = purchaseForwardCallback;
											androidJavaClass.CallStatic("consumePurchase", array7);
											return;
										}
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x15CC2B8", Offset = "0x15CC2B8", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EC9808]);\n\tv35 = *([v34 @ X8_v47]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20299ED]) = v54;\nL_001B:\n\tv55 = values == 0;\n\tif (v55) goto L_FFFFFFFF;\n\tv59 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v59, \"java.lang.reflect.Array\");\n\t// 43 NewArr v166 @ X0_v7 (System.Object[]), typeof(System.Object[]), 2\n\tv227 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v227, \"java.lang.String\");\n\tv234 = v227 == 0;\n\tif (v234) goto L_0040;\n\t// 61 IsInst v322 @ X0_v53, typeof(System.Object), v227 @ X0_v9 (UnityEngine.AndroidJavaClass)\nL_0040:\n\tv347 = v166.Length;\n\tv329 = v166.Length == 0;\n\tif (v329) goto L_0117;\n\tv166[0] = v227;\n\tv347 = values._size;\n\t// 74 Box v350 @ X0_v22, typeof(System.Int32), &v347 @ X8_v16 (System.Int32)\n\tv463 = v350 == 0;\n\tif (v463) goto L_0054;\n\t// 81 IsInst v445 @ X0_v51, typeof(System.Object), v350 @ X0_v22\nL_0054:\n\tv347 = v166.Length;\n\tv469 = v166.Length < 1;\n\tv289 = ~v469;\n\tv285 = v166.Length - 1;\n\tv277 = v285 == 0;\n\tv470 = ~v289;\n\tv257 = v470 | v277;\n\tif (v257) goto L_0117;\n\tv166[1] = v350;\n\tv141 = UnityEngine.AndroidJavaObject::CallStatic(v59, \"newInstance\", v166);\n\tv347 = values._size;\n\tv87 = values._size < 1;\n\tif (v87) goto L_0116;\nL_0082:\n\t// 130 NewArr v343 @ X0_v28 (System.Object[]), typeof(System.Object[]), 3\n\tv485 = v141 == 0;\n\tif (v485) goto L_008E;\n\t// 139 IsInst v446 @ X0_v49, typeof(System.Object), v141 @ X0_v25 (UnityEngine.AndroidJavaObject)\nL_008E:\n\tv347 = v343.Length;\n\tv407 = v343.Length == 0;\n\tif (v407) goto L_0117;\n\tv343[0] = v141;\n\t// 151 Box v493 @ X0_v31, typeof(System.Int32), &v247 @ X28_v9 (System.Int32)\n\tv494 = v493 == 0;\n\tif (v494) goto L_00A1;\n\t// 158 IsInst v447 @ X0_v47, typeof(System.Object), v493 @ X0_v31\nL_00A1:\n\tv347 = v343.Length;\n\tv497 = v343.Length < 1;\n\tv387 = ~v497;\n\tv384 = v343.Length - 1;\n\tv378 = v384 == 0;\n\tv498 = ~v387;\n\tv363 = v498 | v378;\n\tif (v363) goto L_0117;\n\tv343[1] = v493;\n\t// 177 NewArr v500 @ X0_v34 (System.Object[]), typeof(System.Object[]), 1\n\tv347 = values._size;\n\tv501 = values._size < v247;\n\tv290 = ~v501;\n\tv286 = values._size - v247;\n\tv278 = v286 == 0;\n\tv502 = ~v278;\n\tv258 = v290 & v502;\n\tif (v258) goto L_00C4;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C4:\n\tv504 = values._items;\n\tv506 = v504[v247 @ X28_v9 (System.Int32)] == 0;\n\tif (v506) goto L_00D0;\n\t// 205 IsInst v448 @ X0_v44, typeof(System.Object), v504[v247 @ X28_v9 (System.Int32)]\nL_00D0:\n\tv347 = v500.Length;\n\tv409 = v500.Length == 0;\n\tif (v409) goto L_0117;\n\tv500[0] = v504[v247 @ X28_v9 (System.Int32)];\n\tv511 = new UnityEngine.AndroidJavaObject();\n\tUnityEngine.AndroidJavaObject::.ctor(v511, \"java.lang.String\", v500);\n\tv515 = v511 == 0;\n\tif (v515) goto L_00E5;\n\t// 226 IsInst v449 @ X0_v42, typeof(System.Object), v511 @ X0_v38 (UnityEngine.AndroidJavaObject)\nL_00E5:\n\tv347 = v343.Length;\n\tv518 = v343.Length < 2;\n\tv388 = ~v518;\n\tv385 = v343.Length - 2;\n\tv379 = v385 == 0;\n\tv519 = ~v388;\n\tv364 = v519 | v379;\n\tif (v364) goto L_0117;\n\tv343[2] = v511;\n\tUnityEngine.AndroidJavaObject::CallStatic(v59, \"set\", v343);\n\tv247 = v247 + 1;\n\tv88 = v247 < values._size;\n\tif (v88) goto L_0082;\n\tgoto L_0116;\nL_0116:\n\treturn v138;\nL_0117:\n\tv415 = new System.IndexOutOfRangeException();\n\tgoto L_011C;\n\tv462 = new System.ArrayTypeMismatchException();\nL_011C:\n\tthrow v466;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 185 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static AndroidJavaObject javaArrayFromCSList(List<string> values)
		{
			//IL_0129: Expected O, but got I4
			//IL_02ae: Expected O, but got I4
			//IL_048f: Expected O, but got I4
			AndroidJavaObject androidJavaObject;
			AndroidJavaObject result;
			if (values != null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.reflect.Array");
				object[] array = new object[2];
				AndroidJavaClass androidJavaClass2 = new AndroidJavaClass("java.lang.String");
				if (androidJavaClass2 != null)
				{
					object obj = androidJavaClass2 as object;
				}
				int num = array.Length;
				if (array.Length != 0)
				{
					array[0] = androidJavaClass2;
					num = values.Count;
					object obj2 = num;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
					}
					num = array.Length;
					bool flag = array.Length < 1;
					bool flag2 = !flag;
					object obj4 = array.Length - 1;
					bool flag3 = obj4 == null;
					bool flag4 = !flag2;
					if (!(flag4 || flag3))
					{
						array[1] = obj2;
						androidJavaObject = androidJavaClass.CallStatic<AndroidJavaObject>("newInstance", array);
						num = values.Count;
						bool flag5 = values.Count < 1;
						result = androidJavaObject;
						if (flag5)
						{
							goto IL_0560;
						}
						int num2 = 0;
						while (true)
						{
							object[] array2 = new object[3];
							if (androidJavaObject != null)
							{
								object obj5 = androidJavaObject as object;
							}
							num = array2.Length;
							if (array2.Length == 0)
							{
								break;
							}
							array2[0] = androidJavaObject;
							object obj6 = num2;
							if (obj6 != null)
							{
								object obj7 = obj6 as object;
							}
							num = array2.Length;
							bool flag6 = array2.Length < 1;
							bool flag7 = !flag6;
							object obj8 = array2.Length - 1;
							bool flag8 = obj8 == null;
							bool flag9 = !flag7;
							if (flag9 || flag8)
							{
								break;
							}
							array2[1] = obj6;
							object[] array3 = new object[1];
							num = values.Count;
							bool flag10 = values.Count < num2;
							bool flag11 = !flag10;
							int num3 = values.Count - num2;
							bool flag12 = num3 == 0;
							bool flag13 = !flag12;
							if (!(flag11 && flag13))
							{
								throw new ArgumentOutOfRangeException();
							}
							string[] items = values._items;
							if (items[num2] != null)
							{
								object obj9 = items[num2] as object;
							}
							num = array3.Length;
							if (array3.Length == 0)
							{
								break;
							}
							array3[0] = items[num2];
							AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("java.lang.String", array3);
							if (androidJavaObject2 != null)
							{
								object obj10 = androidJavaObject2 as object;
							}
							num = array2.Length;
							bool flag14 = array2.Length < 2;
							bool flag15 = !flag14;
							object obj11 = array2.Length - 2;
							bool flag16 = obj11 == null;
							bool flag17 = !flag15;
							if (flag17 || flag16)
							{
								break;
							}
							array2[2] = androidJavaObject2;
							androidJavaClass.CallStatic("set", array2);
							num2++;
							if (num2 < values.Count)
							{
								continue;
							}
							goto IL_0519;
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			result = null;
			goto IL_0560;
			IL_0560:
			return result;
			IL_0519:
			result = androidJavaObject;
			goto IL_0560;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x15CBF38", Offset = "0x15CBF38", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EEA030]);\n\tv17 = *([v16 @ X8_v15]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20299EE]) = v37;\nL_0016:\n\treturnVal1 = v41.serviceClass;\n\tv43 = v41.serviceClass == 0;\n\tv44 = ~v43;\n\tif (v44) goto L_002F;\n\tv48 = new UnityEngine.AndroidJavaClass();\n\tUnityEngine.AndroidJavaClass::.ctor(v48, \"com.unity.udp.sdk.ChannelService\");\n\tv66.serviceClass = v48;\n\treturnVal1 = v56.serviceClass;\nL_002F:\n\treturn returnVal1;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AndroidJavaClass safetyServiceClass()
		{
			AndroidJavaClass result = serviceClass;
			if (serviceClass == null)
			{
				AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity.udp.sdk.ChannelService");
				serviceClass = androidJavaClass;
				result = serviceClass;
			}
			return result;
		}
	}
}
