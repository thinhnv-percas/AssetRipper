using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Api;
using GoogleMobileAds.Unity;
using UnityEngine;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000023")]
	public class DummyClient : IBannerClient, IInterstitialClient, IRewardBasedVideoAdClient, IAdLoaderClient, IMobileAdsClient
	{
		[CompilerGenerated]
		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x10")]
		private EventHandler<EventArgs> m_OnAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x18")]
		private EventHandler<AdFailedToLoadEventArgs> m_OnAdFailedToLoad;

		[CompilerGenerated]
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x20")]
		private EventHandler<EventArgs> m_OnAdOpening;

		[CompilerGenerated]
		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x28")]
		private EventHandler<EventArgs> m_OnAdStarted;

		[CompilerGenerated]
		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x30")]
		private EventHandler<EventArgs> m_OnAdClosed;

		[CompilerGenerated]
		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x38")]
		private EventHandler<Reward> m_OnAdRewarded;

		[CompilerGenerated]
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x40")]
		private EventHandler<EventArgs> m_OnAdLeavingApplication;

		[CompilerGenerated]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x48")]
		private EventHandler<EventArgs> m_OnAdCompleted;

		[CompilerGenerated]
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x50")]
		private EventHandler<AdValueEventArgs> m_OnPaidEvent;

		[CompilerGenerated]
		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x58")]
		private EventHandler<CustomNativeClientEventArgs> m_OnCustomNativeTemplateAdLoaded;

		[CompilerGenerated]
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x60")]
		private EventHandler<CustomNativeClientEventArgs> m_OnCustomNativeTemplateAdClicked;

		[Token(Token = "0x1700000A")]
		public string UserId
		{
			[Token(Token = "0x6000184")]
			[Address(RVA = "0x1350808", Offset = "0x1350808", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv16 = UnityEngine.Debug;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv43 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = \"Dummy \";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv54 = \"UserId\";\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv37 = 1;\n\t*([1A36866]) = v37;\nL_001B:\n\tv38 = Il2CppMethodInfo;\n\tv40 = *([v38 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv41 = v40 == 0;\n\tif (v41) goto L_0022;\n\tv46 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_0022:\n\tv48 = 0xAD947C(v46, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv55 = *([v48 @ X0_v4]);\n\t*([v55 @ X8_v4+1A8])(v64, v48, *([v55 @ X8_v4+1B0]), v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv69 = System.String::Concat(\"Dummy \", v64);\n\tgoto L_003E;\n\tv76 = v71;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v76, v66, v67, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\nL_003E:\n\tUnityEngine.Debug::Log(v69);\n\treturn \"UserId\";\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v2 (Il2CppMethodInfo)+53]");
				int num2 = (int)((nint)0 & (nint)2);
				bool flag = num2 == 0;
				nint num3 = 0;
				if (!flag)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ X8_v4+1A8] (should have been resolved before IL gen)");
				string text = default(string);
				string message = "Dummy " + text;
				Debug.Log(message);
				return "UserId";
			}
			[Token(Token = "0x6000185")]
			[Address(RVA = "0x13508E8", Offset = "0x13508E8", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36867]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, value, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
				int num2 = (int)((nint)0 & (nint)2);
				bool flag = num2 == 0;
				nint num3 = 0;
				if (!flag)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
				object obj2 = default(object);
				object obj = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
				string text = default(string);
				string message = "Dummy " + text;
				Debug.Log(message);
			}
		}

		[Token(Token = "0x1400003F")]
		public event EventHandler<EventArgs> OnAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x600016E")]
			[Address(RVA = "0x134F8E8", Offset = "0x134F8E8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36850]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 16;
				Delegate obj2 = this.m_OnAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600016F")]
			[Address(RVA = "0x134F998", Offset = "0x134F998", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36851]) = v42;\nL_0016:\n\tv44 = this + 0x10;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 16;
				Delegate obj2 = this.m_OnAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000040")]
		public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad
		{
			[CompilerGenerated]
			[Token(Token = "0x6000170")]
			[Address(RVA = "0x134FA48", Offset = "0x134FA48", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36852]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnAdFailedToLoad;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdFailedToLoadEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000171")]
			[Address(RVA = "0x134FAF8", Offset = "0x134FAF8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36853]) = v42;\nL_0016:\n\tv44 = this + 0x18;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdFailedToLoadEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 24;
				Delegate obj2 = this.m_OnAdFailedToLoad;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdFailedToLoadEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000041")]
		public event EventHandler<EventArgs> OnAdOpening
		{
			[CompilerGenerated]
			[Token(Token = "0x6000172")]
			[Address(RVA = "0x134FBA8", Offset = "0x134FBA8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36854]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnAdOpening;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000173")]
			[Address(RVA = "0x134FC58", Offset = "0x134FC58", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36855]) = v42;\nL_0016:\n\tv44 = this + 0x20;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 32;
				Delegate obj2 = this.m_OnAdOpening;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000042")]
		public event EventHandler<EventArgs> OnAdStarted
		{
			[CompilerGenerated]
			[Token(Token = "0x6000174")]
			[Address(RVA = "0x134FD08", Offset = "0x134FD08", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36856]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_OnAdStarted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000175")]
			[Address(RVA = "0x134FDB8", Offset = "0x134FDB8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36857]) = v42;\nL_0016:\n\tv44 = this + 0x28;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 40;
				Delegate obj2 = this.m_OnAdStarted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000043")]
		public event EventHandler<EventArgs> OnAdClosed
		{
			[CompilerGenerated]
			[Token(Token = "0x6000176")]
			[Address(RVA = "0x134FE68", Offset = "0x134FE68", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36858]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdClosed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000177")]
			[Address(RVA = "0x134FF18", Offset = "0x134FF18", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36859]) = v42;\nL_0016:\n\tv44 = this + 0x30;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 48;
				Delegate obj2 = this.m_OnAdClosed;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000044")]
		public event EventHandler<Reward> OnAdRewarded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000178")]
			[Address(RVA = "0x134FFC8", Offset = "0x134FFC8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685A]) = v42;\nL_0018:\n\tv46 = 0x1854C48(v40, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\treturn;\nL_001A:\n\tX0 = X21;\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.Delegate::Combine(X0, X1, X2);\n\tif (TEMP) goto L_0029;\n\tX23 = *([1936000]);\n\tX22 = X0;\n\tX1 = X23;\n\tX0 = 0xAD959C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = X0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002A;\n\tgoto L_0042;\nL_0029:\n\tX1 = 0;\nL_002A:\n\tX0 = X20;\n\tX2 = X21;\n\tX0 = 0xAF4130(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X21 < X0;\n\tC = ~C;\n\tTEMP1 = X21 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ X0;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX21 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_001A;\n\tX20 = stack[30];\n\tX19 = stack[38];\n\tX22 = stack[20];\n\tX21 = stack[28];\n\tX24 = stack[10];\n\tX23 = stack[18];\n\tX30 = stack[0];\n\t// 64 ShiftStack 64\n\treturn;\nL_0042:\n\tX0 = X22;\n\tX1 = X23;\n\tX0 = InvalidCastException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1854C48 (inside System.__Il2CppComDelegate::Finalize +0x34)");
			}
			[CompilerGenerated]
			[Token(Token = "0x6000179")]
			[Address(RVA = "0x1350078", Offset = "0x1350078", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.Reward>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685B]) = v42;\nL_0016:\n\tv44 = this + 0x38;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.Reward>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnAdRewarded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<Reward>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000045")]
		public event EventHandler<EventArgs> OnAdLeavingApplication
		{
			[CompilerGenerated]
			[Token(Token = "0x600017A")]
			[Address(RVA = "0x1350128", Offset = "0x1350128", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685C]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdLeavingApplication;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600017B")]
			[Address(RVA = "0x13501D8", Offset = "0x13501D8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685D]) = v42;\nL_0016:\n\tv44 = this + 0x40;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 64;
				Delegate obj2 = this.m_OnAdLeavingApplication;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000046")]
		public event EventHandler<EventArgs> OnAdCompleted
		{
			[CompilerGenerated]
			[Token(Token = "0x600017C")]
			[Address(RVA = "0x1350288", Offset = "0x1350288", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685E]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_OnAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600017D")]
			[Address(RVA = "0x1350338", Offset = "0x1350338", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<System.EventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A3685F]) = v42;\nL_0016:\n\tv44 = this + 0x48;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<System.EventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 72;
				Delegate obj2 = this.m_OnAdCompleted;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<EventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000047")]
		public event EventHandler<AdValueEventArgs> OnPaidEvent
		{
			[CompilerGenerated]
			[Token(Token = "0x600017E")]
			[Address(RVA = "0x13503E8", Offset = "0x13503E8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36860]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnPaidEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdValueEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600017F")]
			[Address(RVA = "0x1350498", Offset = "0x1350498", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36861]) = v42;\nL_0016:\n\tv44 = this + 0x50;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Api.AdValueEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 80;
				Delegate obj2 = this.m_OnPaidEvent;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<AdValueEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000048")]
		public event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdLoaded
		{
			[CompilerGenerated]
			[Token(Token = "0x6000180")]
			[Address(RVA = "0x1350548", Offset = "0x1350548", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36862]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000181")]
			[Address(RVA = "0x13505F8", Offset = "0x13505F8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36863]) = v42;\nL_0016:\n\tv44 = this + 0x58;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 88;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdLoaded;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x14000049")]
		public event EventHandler<CustomNativeClientEventArgs> OnCustomNativeTemplateAdClicked
		{
			[CompilerGenerated]
			[Token(Token = "0x6000182")]
			[Address(RVA = "0x13506A8", Offset = "0x13506A8", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36864]) = v42;\nL_0016:\n\tv44 = this + 0x60;\nL_001C:\n\tv91 = System.Delegate::Combine(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 96;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000183")]
			[Address(RVA = "0x1350758", Offset = "0x1350758", Length = "0xB0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, value, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A36865]) = v42;\nL_0016:\n\tv44 = this + 0x60;\nL_001C:\n\tv91 = System.Delegate::Remove(v86, value);\n\tv92 = v91 == 0;\n\tif (v92) goto L_FFFFFFFF;\n\t// 34 IsInst v96 @ X0_v8 (System.Int32), typeof(System.EventHandler`1<GoogleMobileAds.Common.CustomNativeClientEventArgs>), v91 @ X0_v4 (System.Delegate)\n\tv99 = v96 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_002B;\n\tgoto L_0043;\nL_002B:\n\tv83 = 0xAF4130(v44, v77, v86, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv51 = v86 != v83;\n\tif (v51) goto L_001C;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0068: Expected O, but got I
				//IL_0012: Expected I4, but got O
				object obj = (nint)this + 96;
				Delegate obj2 = this.m_OnCustomNativeTemplateAdClicked;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null)
					{
						int num = (int)(obj3 as EventHandler<CustomNativeClientEventArgs>);
						bool flag = num == 0;
						bool flag2 = !flag;
						int num2 = num;
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						int num2 = 0;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag3 = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag3)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x133D100", Offset = "0x133D100", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv49 = \"Dummy \";\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A3684F]) = v38;\nL_001B:\n\tSystem.Object::.ctor(this);\n\tv44 = Il2CppMethodInfo;\n\tv46 = *([v44 @ X0_v3 (Il2CppMethodInfo)+53]) & 2;\n\tv47 = v46 == 0;\n\tif (v47) goto L_0023;\n\tv51 = 0xAD94B0(Il2CppMethodInfo, 0, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0023:\n\tv53 = 0xAD947C(v51, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv55 = *([v53 @ X0_v5]);\n\t*([v55 @ X8_v4+1A8])(v62, v53, *([v55 @ X8_v4+1B0]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv67 = System.String::Concat(\"Dummy \", v62);\n\tgoto L_0042;\n\tv74 = v69;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v74, v64, v65, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0042:\n\tUnityEngine.Debug::Log(v67);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DummyClient()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v3 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v55 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			Debug.Log("Dummy " + text);
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0x13509AC", Offset = "0x13509AC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, appId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, appId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, appId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36868]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, appId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(string appId)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0x1350A70", Offset = "0x1350A70", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv20 = UnityEngine.Debug;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, initCompleteAction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv46 = Il2CppMethodInfo;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, initCompleteAction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv53 = GoogleMobileAds.Unity.InitializationStatusDummyClient;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, initCompleteAction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv57 = \"Dummy \";\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, initCompleteAction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv40 = 1;\n\t*([1A36869]) = v40;\nL_001D:\n\tv41 = Il2CppMethodInfo;\n\tv43 = *([v41 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv44 = v43 == 0;\n\tif (v44) goto L_0024;\n\tv49 = 0xAD94B0(Il2CppMethodInfo, initCompleteAction, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0024:\n\tv51 = 0xAD947C(v49, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv58 = *([v51 @ X0_v4]);\n\t*([v58 @ X8_v5+1A8])(v67, v51, *([v58 @ X8_v5+1B0]), methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv72 = System.String::Concat(\"Dummy \", v67);\n\tgoto L_0040;\n\tv93 = v85;\n\tv94 = \"il2cpp_codegen_runtime_class_init\"(v93, v69, v70, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0040:\n\tUnityEngine.Debug::Log(v72);\n\tv81 = new GoogleMobileAds.Unity.InitializationStatusDummyClient();\n\tSystem.Object::.ctor(v81);\n\tSystem.Action`1<GoogleMobileAds.Common.IInitializationStatusClient>::Invoke(initCompleteAction, v81);\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Action<IInitializationStatusClient> initCompleteAction)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v58 @ X8_v5+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			InitializationStatusDummyClient obj3 = new InitializationStatusDummyClient();
			initCompleteAction(obj3);
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0x1350B80", Offset = "0x1350B80", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686A]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DisableMediationInitialization()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0x1350C44", Offset = "0x1350C44", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, muted, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, muted, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, muted, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686B]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, muted, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetApplicationMuted(bool muted)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0x1350D08", Offset = "0x1350D08", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, requestConfiguration, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, requestConfiguration, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, requestConfiguration, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686C]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, requestConfiguration, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetRequestConfiguration(RequestConfiguration requestConfiguration)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0x1350DCC", Offset = "0x1350DCC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686D]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RequestConfiguration GetRequestConfiguration()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0x1350E98", Offset = "0x1350E98", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686E]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, volume, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetApplicationVolume(float volume)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x1350F5C", Offset = "0x1350F5C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, pause, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, pause, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, pause, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3686F]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, pause, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetiOSAppPauseOnBackground(bool pause)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0x1351020", Offset = "0x1351020", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36870]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetDeviceScale()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return 0f;
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0x13510EC", Offset = "0x13510EC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36871]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetDeviceSafeWidth()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return 0;
		}

		[Token(Token = "0x6000190")]
		[Address(RVA = "0x13511B8", Offset = "0x13511B8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adUnitId, adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adUnitId, adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitId, adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36872]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adUnitId, adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), adSize, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, position, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0x135127C", Offset = "0x135127C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adUnitId, adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adUnitId, adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitId, adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36873]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adUnitId, adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), adSize, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, positionX, positionY, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateBannerView(string adUnitId, AdSize adSize, int positionX, int positionY)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0x1351340", Offset = "0x1351340", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36874]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0x1351404", Offset = "0x1351404", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36875]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowBannerView()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0x13514C8", Offset = "0x13514C8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36876]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void HideBannerView()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0x135158C", Offset = "0x135158C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36877]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyBannerView()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0x1351650", Offset = "0x1351650", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36878]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetHeightInPixels()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return 0f;
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0x135171C", Offset = "0x135171C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36879]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, returnVal1, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float GetWidthInPixels()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return 0f;
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0x13517E8", Offset = "0x13517E8", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adPosition, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adPosition, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adPosition, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687A]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adPosition, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(AdPosition adPosition)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0x13518AC", Offset = "0x13518AC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, x, y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, x, y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, x, y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687B]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, x, y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), y, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPosition(int x, int y)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0x1351970", Offset = "0x1351970", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687C]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adUnitId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateInterstitialAd(string adUnitId)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0x1351A34", Offset = "0x1351A34", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687D]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 1;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsLoaded()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return true;
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0x1351B00", Offset = "0x1351B00", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687E]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowInterstitial()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x1351BC4", Offset = "0x1351BC4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A3687F]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyInterstitial()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x1351C88", Offset = "0x1351C88", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36880]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateRewardBasedVideoAd()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0x1351D4C", Offset = "0x1351D4C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, userId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, userId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, userId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36881]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, userId, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetUserId(string userId)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x1351E10", Offset = "0x1351E10", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, request, adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, request, adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, request, adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36882]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, request, adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), adUnitId, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void LoadAd(AdRequest request, string adUnitId)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x1351ED4", Offset = "0x1351ED4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36883]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void DestroyRewardBasedVideoAd()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0x1351F98", Offset = "0x1351F98", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36884]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ShowRewardBasedVideoAd()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x135205C", Offset = "0x135205C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, args, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, args, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, args, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36885]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, args, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CreateAdLoader(AdLoaderClientArgs args)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x1352120", Offset = "0x1352120", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36886]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, request, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Load(AdRequest request)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x13521E4", Offset = "0x13521E4", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, adSize, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, adSize, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, adSize, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36887]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, adSize, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_003C;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_003C:\n\tUnityEngine.Debug::Log(v62);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetAdSize(AdSize adSize)
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x13522A8", Offset = "0x13522A8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36888]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string MediationAdapterClassName()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return null;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x1352374", Offset = "0x1352374", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = UnityEngine.Debug;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv41 = Il2CppMethodInfo;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v41, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv48 = \"Dummy \";\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv35 = 1;\n\t*([1A36889]) = v35;\nL_0017:\n\tv36 = Il2CppMethodInfo;\n\tv38 = *([v36 @ X0_v2 (Il2CppMethodInfo)+53]) & 2;\n\tv39 = v38 == 0;\n\tif (v39) goto L_001E;\n\tv44 = 0xAD94B0(Il2CppMethodInfo, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_001E:\n\tv46 = 0xAD947C(v44, Il2CppClass<GoogleMobileAds.Common.DummyClient>, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv50 = *([v46 @ X0_v4]);\n\t*([v50 @ X8_v4+1A8])(v57, v46, *([v50 @ X8_v4+1B0]), v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv62 = System.String::Concat(\"Dummy \", v57);\n\tgoto L_0038;\n\tv69 = v64;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v69, v59, v60, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\nL_0038:\n\tUnityEngine.Debug::Log(v62);\n\treturn 0;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IResponseInfoClient GetResponseInfoClient()
		{
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X0_v2 (Il2CppMethodInfo)+53]");
			int num2 = (int)((nint)0 & (nint)2);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (!flag)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD94B0");
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD947C");
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v50 @ X8_v4+1A8] (should have been resolved before IL gen)");
			string text = default(string);
			string message = "Dummy " + text;
			Debug.Log(message);
			return null;
		}
	}
}
