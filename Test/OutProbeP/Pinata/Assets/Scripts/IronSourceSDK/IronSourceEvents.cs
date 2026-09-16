using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using IronSourceJSON;
using UnityEngine;

[Token(Token = "0x2000007")]
public class IronSourceEvents : MonoBehaviour
{
	[Token(Token = "0x400001C")]
	private const string ERROR_CODE = "error_code";

	[Token(Token = "0x400001D")]
	private const string ERROR_DESCRIPTION = "error_description";

	[Token(Token = "0x400001E")]
	private const string INSTANCE_ID_KEY = "instanceId";

	[Token(Token = "0x400001F")]
	private const string PLACEMENT_KEY = "placement";

	[CompilerGenerated]
	[Token(Token = "0x4000020")]
	private static Action<IronSourceError> m__onRewardedVideoAdShowFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000021")]
	private static Action m__onRewardedVideoAdOpenedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000022")]
	private static Action m__onRewardedVideoAdClosedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000023")]
	private static Action m__onRewardedVideoAdStartedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000024")]
	private static Action m__onRewardedVideoAdEndedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000025")]
	private static Action<IronSourcePlacement> m__onRewardedVideoAdRewardedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000026")]
	private static Action<IronSourcePlacement> m__onRewardedVideoAdClickedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000027")]
	private static Action<bool> m__onRewardedVideoAvailabilityChangedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000028")]
	private static Action<string> m__onRewardedVideoAdLoadedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000029")]
	private static Action<string, IronSourceError> m__onRewardedVideoAdLoadFailedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002A")]
	private static Action<string> m__onRewardedVideoAdOpenedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002B")]
	private static Action<string> m__onRewardedVideoAdClosedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002C")]
	private static Action<string> m__onRewardedVideoAdRewardedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002D")]
	private static Action<string, IronSourceError> m__onRewardedVideoAdShowFailedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002E")]
	private static Action<string> m__onRewardedVideoAdClickedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400002F")]
	private static Action m__onInterstitialAdReadyEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000030")]
	private static Action<IronSourceError> m__onInterstitialAdLoadFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000031")]
	private static Action m__onInterstitialAdOpenedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000032")]
	private static Action m__onInterstitialAdClosedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000033")]
	private static Action m__onInterstitialAdShowSucceededEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000034")]
	private static Action<IronSourceError> m__onInterstitialAdShowFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000035")]
	private static Action m__onInterstitialAdClickedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000036")]
	private static Action<string> m__onInterstitialAdReadyDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000037")]
	private static Action<string, IronSourceError> m__onInterstitialAdLoadFailedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000038")]
	private static Action<string> m__onInterstitialAdOpenedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000039")]
	private static Action<string> m__onInterstitialAdClosedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003A")]
	private static Action<string, IronSourceError> m__onInterstitialAdShowFailedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003B")]
	private static Action<string> m__onInterstitialAdClickedDemandOnlyEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003C")]
	private static Action m__onInterstitialAdRewardedEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003D")]
	private static Action m__onOfferwallOpenedEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003E")]
	private static Action<IronSourceError> m__onOfferwallShowFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x400003F")]
	private static Action m__onOfferwallClosedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000040")]
	private static Action<IronSourceError> m__onGetOfferwallCreditsFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000041")]
	private static Action<Dictionary<string, object>> m__onOfferwallAdCreditedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000042")]
	private static Action<bool> m__onOfferwallAvailableEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000043")]
	private static Action m__onBannerAdLoadedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000044")]
	private static Action<IronSourceError> m__onBannerAdLoadFailedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000045")]
	private static Action m__onBannerAdClickedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000046")]
	private static Action m__onBannerAdScreenPresentedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000047")]
	private static Action m__onBannerAdScreenDismissedEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000048")]
	private static Action m__onBannerAdLeftApplicationEvent;

	[CompilerGenerated]
	[Token(Token = "0x4000049")]
	private static Action<string> m__onSegmentReceivedEvent;

	[Token(Token = "0x14000001")]
	private static event Action<IronSourceError> _onRewardedVideoAdShowFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600006D")]
		[Address(RVA = "0x15942A0", Offset = "0x15942A0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEC410]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296D2]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81._onRewardedVideoAdShowFailedEvent, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdShowFailedEvent;
			Delegate obj3 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj3;
				obj = obj3;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600006E")]
		[Address(RVA = "0x1594354", Offset = "0x1594354", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF03D0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296D3]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004A;\nL_0034:\n\tv85 = 0x874190(v81._onRewardedVideoAdShowFailedEvent, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004A:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdShowFailedEvent;
			Delegate obj3 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj3;
				obj = obj3;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000002")]
	public static event Action<IronSourceError> onRewardedVideoAdShowFailedEvent
	{
		[Token(Token = "0x600006F")]
		[Address(RVA = "0x1594408", Offset = "0x1594408", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECA820]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296D4]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdShowFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdShowFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdShowFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdShowFailedEvent += value;
		}
		[Token(Token = "0x6000070")]
		[Address(RVA = "0x1594494", Offset = "0x1594494", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE9BC0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296D5]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdShowFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdShowFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdShowFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000003")]
	private static event Action _onRewardedVideoAdOpenedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000072")]
		[Address(RVA = "0x15947F8", Offset = "0x15947F8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEC558]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296D7]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 8L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000073")]
		[Address(RVA = "0x15948B0", Offset = "0x15948B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF9BA8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296D8]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 8L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000004")]
	public static event Action onRewardedVideoAdOpenedEvent
	{
		[Token(Token = "0x6000074")]
		[Address(RVA = "0x1594968", Offset = "0x1594968", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBE8D8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296D9]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdOpenedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdOpenedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdOpenedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdOpenedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdOpenedEvent += value;
		}
		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15949F4", Offset = "0x15949F4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED5098]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296DA]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdOpenedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdOpenedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdOpenedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000005")]
	private static event Action _onRewardedVideoAdClosedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000077")]
		[Address(RVA = "0x1594AE8", Offset = "0x1594AE8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECD978]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296DC]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x10;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 16L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000078")]
		[Address(RVA = "0x1594BA0", Offset = "0x1594BA0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0FF08]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296DD]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x10;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 16L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000006")]
	public static event Action onRewardedVideoAdClosedEvent
	{
		[Token(Token = "0x6000079")]
		[Address(RVA = "0x1594C58", Offset = "0x1594C58", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB2300]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296DE]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClosedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdClosedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdClosedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClosedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdClosedEvent += value;
		}
		[Token(Token = "0x600007A")]
		[Address(RVA = "0x1594CE4", Offset = "0x1594CE4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EBED28]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296DF]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdClosedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClosedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdClosedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000007")]
	private static event Action _onRewardedVideoAdStartedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600007C")]
		[Address(RVA = "0x1594DD8", Offset = "0x1594DD8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED9B20]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296E1]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x18;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdStartedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 24L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600007D")]
		[Address(RVA = "0x1594E90", Offset = "0x1594E90", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EDB628]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296E2]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x18;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdStartedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 24L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000008")]
	public static event Action onRewardedVideoAdStartedEvent
	{
		[Token(Token = "0x600007E")]
		[Address(RVA = "0x1594F48", Offset = "0x1594F48", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB5FE8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296E3]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdStartedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdStartedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdStartedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdStartedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdStartedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdStartedEvent += value;
		}
		[Token(Token = "0x600007F")]
		[Address(RVA = "0x1594FD4", Offset = "0x1594FD4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EB83B8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296E4]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdStartedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdStartedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdStartedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdStartedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000009")]
	private static event Action _onRewardedVideoAdEndedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000081")]
		[Address(RVA = "0x15950C8", Offset = "0x15950C8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBED70]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296E6]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x20;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdEndedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 32L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000082")]
		[Address(RVA = "0x1595180", Offset = "0x1595180", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0ABD0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296E7]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x20;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdEndedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 32L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400000A")]
	public static event Action onRewardedVideoAdEndedEvent
	{
		[Token(Token = "0x6000083")]
		[Address(RVA = "0x1595238", Offset = "0x1595238", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECAA60]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296E8]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdEndedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdEndedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdEndedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdEndedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdEndedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdEndedEvent += value;
		}
		[Token(Token = "0x6000084")]
		[Address(RVA = "0x15952C4", Offset = "0x15952C4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF81F8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296E9]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdEndedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdEndedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdEndedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdEndedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400000B")]
	private static event Action<IronSourcePlacement> _onRewardedVideoAdRewardedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000086")]
		[Address(RVA = "0x15953B8", Offset = "0x15953B8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF12F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296EB]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourcePlacement>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x28;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdRewardedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourcePlacement>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 40L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000087")]
		[Address(RVA = "0x1595470", Offset = "0x1595470", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EA6CC0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296EC]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourcePlacement>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x28;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdRewardedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourcePlacement>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 40L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400000C")]
	public static event Action<IronSourcePlacement> onRewardedVideoAdRewardedEvent
	{
		[Token(Token = "0x6000088")]
		[Address(RVA = "0x1595528", Offset = "0x1595528", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECECC0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296ED]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdRewardedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdRewardedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdRewardedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdRewardedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdRewardedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdRewardedEvent += value;
		}
		[Token(Token = "0x6000089")]
		[Address(RVA = "0x15955B4", Offset = "0x15955B4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EBA380]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296EE]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdRewardedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdRewardedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdRewardedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdRewardedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400000D")]
	private static event Action<IronSourcePlacement> _onRewardedVideoAdClickedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600008B")]
		[Address(RVA = "0x15958C8", Offset = "0x15958C8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF8018]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296F0]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourcePlacement>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x30;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourcePlacement>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 48L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600008C")]
		[Address(RVA = "0x1595980", Offset = "0x1595980", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF29C0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296F1]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourcePlacement>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x30;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourcePlacement>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 48L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400000E")]
	public static event Action<IronSourcePlacement> onRewardedVideoAdClickedEvent
	{
		[Token(Token = "0x600008D")]
		[Address(RVA = "0x1595A38", Offset = "0x1595A38", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC84D0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296F2]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClickedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdClickedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdClickedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClickedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdClickedEvent += value;
		}
		[Token(Token = "0x600008E")]
		[Address(RVA = "0x1595AC4", Offset = "0x1595AC4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE7930]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296F3]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdClickedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClickedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdClickedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400000F")]
	private static event Action<bool> _onRewardedVideoAvailabilityChangedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000090")]
		[Address(RVA = "0x1595BEC", Offset = "0x1595BEC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE1118]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296F5]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Boolean>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x38;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAvailabilityChangedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<bool>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 56L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000091")]
		[Address(RVA = "0x1595CA4", Offset = "0x1595CA4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0BDC8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296F6]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Boolean>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x38;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAvailabilityChangedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<bool>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 56L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000010")]
	public static event Action<bool> onRewardedVideoAvailabilityChangedEvent
	{
		[Token(Token = "0x6000092")]
		[Address(RVA = "0x1595D5C", Offset = "0x1595D5C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF6890]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296F7]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAvailabilityChangedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAvailabilityChangedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAvailabilityChangedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAvailabilityChangedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAvailabilityChangedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAvailabilityChangedEvent += value;
		}
		[Token(Token = "0x6000093")]
		[Address(RVA = "0x1595DE8", Offset = "0x1595DE8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EB3970]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296F8]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAvailabilityChangedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAvailabilityChangedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAvailabilityChangedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAvailabilityChangedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000011")]
	private static event Action<string> _onRewardedVideoAdLoadedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000095")]
		[Address(RVA = "0x1595F08", Offset = "0x1595F08", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EA87B0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296FA]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x40;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdLoadedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 64L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000096")]
		[Address(RVA = "0x1595FC0", Offset = "0x1595FC0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv21 = *([1F089E8]);\n\tv22 = *([v21 @ X8_v4]);\n\tv23 = \"il2cpp_codegen_initialize_method\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20296FB]) = v41;\nL_0018:\n\tv45 = 0x159EB1C(v39, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn;\n\tX8 = *([X8+B8]);\n\tX20 = *([X8+40]);\n\tX22 = *([1F0C968]);\nL_001D:\n\tX0 = X20;\n\tX1 = X19;\n\tX2 = 0;\n\tX0 = System.Delegate::Remove(X0, X1, X2);\n\tX8 = X0;\n\tif (TEMP) goto L_0031;\n\tX1 = *([X22]);\n\tX9 = *([X8]);\n\tC = X9 < X1;\n\tC = ~C;\n\tTEMP1 = X9 - X1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X9 ^ X1;\n\tTEMP3 = X9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_004B;\nL_0031:\n\tX9 = *([X21]);\n\tX1 = X8;\n\tX2 = X20;\n\tX9 = *([X9+B8]);\n\tX0 = X9 + 0x40;\n\tX0 = 0x874190(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X20 < X0;\n\tC = ~C;\n\tTEMP1 = X20 - X0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X20 ^ X0;\n\tTEMP3 = X20 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX20 = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_001D;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX22 = stack[0];\n\tX21 = stack[8];\n\t// 73 ShiftStack 48\n\treturn;\nL_004B:\n\tX0 = X8;\n\tX0 = InvalidCastException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @159EB1C (inside IronSourceUtils::.ctor +0xC)");
		}
	}

	[Token(Token = "0x14000012")]
	public static event Action<string> onRewardedVideoAdLoadedDemandOnlyEvent
	{
		[Token(Token = "0x6000097")]
		[Address(RVA = "0x1596078", Offset = "0x1596078", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC1F40]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296FC]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdLoadedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdLoadedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdLoadedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdLoadedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdLoadedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdLoadedDemandOnlyEvent += value;
		}
		[Token(Token = "0x6000098")]
		[Address(RVA = "0x1596104", Offset = "0x1596104", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF6020]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296FD]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdLoadedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdLoadedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdLoadedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdLoadedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000013")]
	private static event Action<string, IronSourceError> _onRewardedVideoAdLoadFailedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600009A")]
		[Address(RVA = "0x1596208", Offset = "0x1596208", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F100C8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20296FF]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x48;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdLoadFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 72L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600009B")]
		[Address(RVA = "0x15962C0", Offset = "0x15962C0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F080F0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029700]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x48;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdLoadFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 72L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000014")]
	public static event Action<string, IronSourceError> onRewardedVideoAdLoadFailedDemandOnlyEvent
	{
		[Token(Token = "0x600009C")]
		[Address(RVA = "0x1596378", Offset = "0x1596378", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE5BE0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029701]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdLoadFailedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdLoadFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdLoadFailedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdLoadFailedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdLoadFailedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdLoadFailedDemandOnlyEvent += value;
		}
		[Token(Token = "0x600009D")]
		[Address(RVA = "0x1596404", Offset = "0x1596404", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE4EA8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029702]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdLoadFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdLoadFailedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdLoadFailedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdLoadFailedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000015")]
	private static event Action<string> _onRewardedVideoAdOpenedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600009F")]
		[Address(RVA = "0x15965D8", Offset = "0x15965D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB1298]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029704]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x50;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdOpenedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 80L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x1596690", Offset = "0x1596690", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECC2C0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029705]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x50;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdOpenedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 80L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000016")]
	public static event Action<string> onRewardedVideoAdOpenedDemandOnlyEvent
	{
		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x1596748", Offset = "0x1596748", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBE390]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029706]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdOpenedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdOpenedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdOpenedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdOpenedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdOpenedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdOpenedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x15967D4", Offset = "0x15967D4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EC89B8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029707]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdOpenedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdOpenedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdOpenedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdOpenedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000017")]
	private static event Action<string> _onRewardedVideoAdClosedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x15968D8", Offset = "0x15968D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED1370]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029709]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x58;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClosedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 88L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x1596990", Offset = "0x1596990", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEE278]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202970A]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x58;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClosedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 88L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000018")]
	public static event Action<string> onRewardedVideoAdClosedDemandOnlyEvent
	{
		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x1596A48", Offset = "0x1596A48", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC0E18]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202970B]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClosedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClosedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdClosedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdClosedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClosedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdClosedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x1596AD4", Offset = "0x1596AD4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE8AD8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202970C]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClosedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdClosedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClosedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdClosedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000019")]
	private static event Action<string> _onRewardedVideoAdRewardedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x1596BD8", Offset = "0x1596BD8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EDF0C8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202970E]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x60;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdRewardedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 96L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x1596C90", Offset = "0x1596C90", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF6E50]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202970F]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x60;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdRewardedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 96L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400001A")]
	public static event Action<string> onRewardedVideoAdRewardedDemandOnlyEvent
	{
		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x1596D48", Offset = "0x1596D48", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC8850]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029710]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdRewardedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdRewardedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdRewardedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdRewardedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdRewardedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdRewardedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x1596DD4", Offset = "0x1596DD4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EEB310]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029711]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdRewardedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdRewardedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdRewardedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdRewardedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400001B")]
	private static event Action<string, IronSourceError> _onRewardedVideoAdShowFailedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x1596ED8", Offset = "0x1596ED8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0FD78]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029713]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x68;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdShowFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 104L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x1596F90", Offset = "0x1596F90", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB49F0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029714]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x68;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdShowFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 104L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400001C")]
	public static event Action<string, IronSourceError> onRewardedVideoAdShowFailedDemandOnlyEvent
	{
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x1597048", Offset = "0x1597048", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB81A8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029715]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdShowFailedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdShowFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdShowFailedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdShowFailedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdShowFailedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdShowFailedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x15970D4", Offset = "0x15970D4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF9328]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029716]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdShowFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdShowFailedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdShowFailedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdShowFailedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400001D")]
	private static event Action<string> _onRewardedVideoAdClickedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x15972A8", Offset = "0x15972A8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF0F60]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029718]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x70;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClickedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 112L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x1597360", Offset = "0x1597360", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE59E8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029719]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x70;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onRewardedVideoAdClickedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 112L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400001E")]
	public static event Action<string> onRewardedVideoAdClickedDemandOnlyEvent
	{
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x1597418", Offset = "0x1597418", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA4210]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202971A]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClickedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClickedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onRewardedVideoAdClickedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onRewardedVideoAdClickedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClickedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onRewardedVideoAdClickedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x15974A4", Offset = "0x15974A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EA9D80]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202971B]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onRewardedVideoAdClickedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onRewardedVideoAdClickedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onRewardedVideoAdClickedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onRewardedVideoAdClickedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400001F")]
	private static event Action _onInterstitialAdReadyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x15975A8", Offset = "0x15975A8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBD330]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202971D]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x78;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdReadyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 120L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x1597660", Offset = "0x1597660", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBCAB0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202971E]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x78;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdReadyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 120L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000020")]
	public static event Action onInterstitialAdReadyEvent
	{
		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x1597718", Offset = "0x1597718", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED2C68]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202971F]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdReadyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdReadyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdReadyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdReadyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdReadyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdReadyEvent += value;
		}
		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x15977A4", Offset = "0x15977A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EB9658]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029720]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdReadyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdReadyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdReadyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdReadyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000021")]
	private static event Action<IronSourceError> _onInterstitialAdLoadFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x1597898", Offset = "0x1597898", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEE240]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029722]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x80;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdLoadFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 128L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x1597950", Offset = "0x1597950", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEAC90]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029723]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x80;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdLoadFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 128L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000022")]
	public static event Action<IronSourceError> onInterstitialAdLoadFailedEvent
	{
		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x1597A08", Offset = "0x1597A08", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC3BC0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029724]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdLoadFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdLoadFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdLoadFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdLoadFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdLoadFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdLoadFailedEvent += value;
		}
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x1597A94", Offset = "0x1597A94", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EE03C0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029725]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdLoadFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdLoadFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdLoadFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdLoadFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000023")]
	private static event Action _onInterstitialAdOpenedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x1597BBC", Offset = "0x1597BBC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF7358]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029727]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x88;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 136L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x1597C74", Offset = "0x1597C74", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEBB08]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029728]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x88;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 136L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000024")]
	public static event Action onInterstitialAdOpenedEvent
	{
		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x1597D2C", Offset = "0x1597D2C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE11A8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029729]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdOpenedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdOpenedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdOpenedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdOpenedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdOpenedEvent += value;
		}
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x1597DB8", Offset = "0x1597DB8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EFC640]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202972A]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdOpenedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdOpenedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdOpenedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000025")]
	private static event Action _onInterstitialAdClosedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x1597EAC", Offset = "0x1597EAC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED7DE0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202972C]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x90;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 144L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x1597F64", Offset = "0x1597F64", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED8FC8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202972D]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x90;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 144L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000026")]
	public static event Action onInterstitialAdClosedEvent
	{
		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x159801C", Offset = "0x159801C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0B2E8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202972E]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClosedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdClosedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdClosedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClosedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdClosedEvent += value;
		}
		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15980A8", Offset = "0x15980A8", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EB6440]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202972F]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdClosedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClosedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdClosedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000027")]
	private static event Action _onInterstitialAdShowSucceededEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x159819C", Offset = "0x159819C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED06A0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029731]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x98;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowSucceededEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 152L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x1598254", Offset = "0x1598254", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC8170]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029732]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x98;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowSucceededEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 152L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000028")]
	public static event Action onInterstitialAdShowSucceededEvent
	{
		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x159830C", Offset = "0x159830C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB2D30]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029733]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdShowSucceededEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowSucceededEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdShowSucceededEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdShowSucceededEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowSucceededEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdShowSucceededEvent += value;
		}
		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x1598398", Offset = "0x1598398", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EBF8F0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029734]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowSucceededEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdShowSucceededEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowSucceededEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdShowSucceededEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000029")]
	private static event Action<IronSourceError> _onInterstitialAdShowFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x159848C", Offset = "0x159848C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB9628]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029736]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xA0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 160L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x1598544", Offset = "0x1598544", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EDCAE0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029737]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xA0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 160L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400002A")]
	public static event Action<IronSourceError> onInterstitialAdShowFailedEvent
	{
		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x15985FC", Offset = "0x15985FC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED5170]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029738]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdShowFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdShowFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdShowFailedEvent += value;
		}
		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x1598688", Offset = "0x1598688", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EA7950]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029739]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdShowFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdShowFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400002B")]
	private static event Action _onInterstitialAdClickedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x15987B0", Offset = "0x15987B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE5C18]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202973B]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xA8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 168L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x1598868", Offset = "0x1598868", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F03D08]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202973C]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xA8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 168L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400002C")]
	public static event Action onInterstitialAdClickedEvent
	{
		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x1598920", Offset = "0x1598920", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F015D8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202973D]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClickedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdClickedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdClickedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClickedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdClickedEvent += value;
		}
		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x15989AC", Offset = "0x15989AC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED3AD0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202973E]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdClickedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClickedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdClickedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400002D")]
	private static event Action<string> _onInterstitialAdReadyDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x1598AA0", Offset = "0x1598AA0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF4148]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029740]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xB0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdReadyDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 176L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x1598B58", Offset = "0x1598B58", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC2800]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029741]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xB0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdReadyDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 176L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400002E")]
	public static event Action<string> onInterstitialAdReadyDemandOnlyEvent
	{
		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x1598C10", Offset = "0x1598C10", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC27E0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029742]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdReadyDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdReadyDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdReadyDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdReadyDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdReadyDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdReadyDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x1598C9C", Offset = "0x1598C9C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED5800]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029743]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdReadyDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdReadyDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdReadyDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdReadyDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400002F")]
	private static event Action<string, IronSourceError> _onInterstitialAdLoadFailedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x1598DA0", Offset = "0x1598DA0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED0B40]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029745]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xB8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdLoadFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 184L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x1598E58", Offset = "0x1598E58", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC0A70]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029746]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xB8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdLoadFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 184L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000030")]
	public static event Action<string, IronSourceError> onInterstitialAdLoadFailedDemandOnlyEvent
	{
		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x1598F10", Offset = "0x1598F10", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE7D88]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029747]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdLoadFailedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdLoadFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdLoadFailedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdLoadFailedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x1598F9C", Offset = "0x1598F9C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED2BE0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029748]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdLoadFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdLoadFailedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdLoadFailedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000031")]
	private static event Action<string> _onInterstitialAdOpenedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x1599170", Offset = "0x1599170", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F05CF0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202974A]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xC0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdOpenedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 192L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x1599228", Offset = "0x1599228", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBE4E8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202974B]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xC0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdOpenedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 192L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000032")]
	public static event Action<string> onInterstitialAdOpenedDemandOnlyEvent
	{
		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x15992E0", Offset = "0x15992E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F079F0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202974C]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdOpenedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdOpenedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdOpenedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdOpenedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdOpenedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdOpenedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x159936C", Offset = "0x159936C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EEE0B8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202974D]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdOpenedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdOpenedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdOpenedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdOpenedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000033")]
	private static event Action<string> _onInterstitialAdClosedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x1599470", Offset = "0x1599470", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EAE3B8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202974F]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xC8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClosedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 200L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x1599528", Offset = "0x1599528", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBA340]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029750]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xC8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClosedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 200L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000034")]
	public static event Action<string> onInterstitialAdClosedDemandOnlyEvent
	{
		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x15995E0", Offset = "0x15995E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA4690]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029751]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClosedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClosedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdClosedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdClosedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClosedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdClosedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x159966C", Offset = "0x159966C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF0228]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029752]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClosedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdClosedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClosedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdClosedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000035")]
	private static event Action<string, IronSourceError> _onInterstitialAdShowFailedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x1599770", Offset = "0x1599770", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBEB90]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029754]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xD0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 208L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x1599828", Offset = "0x1599828", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0D2C0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029755]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`2<System.String, IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xD0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdShowFailedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string, IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 208L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000036")]
	public static event Action<string, IronSourceError> onInterstitialAdShowFailedDemandOnlyEvent
	{
		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x15998E0", Offset = "0x15998E0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC26F8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029756]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdShowFailedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdShowFailedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdShowFailedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowFailedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdShowFailedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x159996C", Offset = "0x159996C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF3AA8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029757]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdShowFailedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdShowFailedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdShowFailedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdShowFailedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000037")]
	private static event Action<string> _onInterstitialAdClickedDemandOnlyEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x1599B40", Offset = "0x1599B40", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECC358]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029759]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xD8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClickedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 216L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000F5")]
		[Address(RVA = "0x1599BF8", Offset = "0x1599BF8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F01808]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202975A]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xD8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdClickedDemandOnlyEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 216L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000038")]
	public static event Action<string> onInterstitialAdClickedDemandOnlyEvent
	{
		[Token(Token = "0x60000F6")]
		[Address(RVA = "0x1599CB0", Offset = "0x1599CB0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F055B8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202975B]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClickedDemandOnlyEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClickedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdClickedDemandOnlyEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdClickedDemandOnlyEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClickedDemandOnlyEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdClickedDemandOnlyEvent += value;
		}
		[Token(Token = "0x60000F7")]
		[Address(RVA = "0x1599D3C", Offset = "0x1599D3C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EA6EA8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202975C]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdClickedDemandOnlyEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdClickedDemandOnlyEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdClickedDemandOnlyEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdClickedDemandOnlyEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000039")]
	private static event Action _onInterstitialAdRewardedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000F9")]
		[Address(RVA = "0x1599E40", Offset = "0x1599E40", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EDFE40]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202975E]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xE0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdRewardedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 224L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x1599EF8", Offset = "0x1599EF8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EB2840]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202975F]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xE0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onInterstitialAdRewardedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 224L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400003A")]
	public static event Action onInterstitialAdRewardedEvent
	{
		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x1599FB0", Offset = "0x1599FB0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF2630]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029760]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdRewardedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdRewardedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onInterstitialAdRewardedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onInterstitialAdRewardedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdRewardedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onInterstitialAdRewardedEvent += value;
		}
		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x159A03C", Offset = "0x159A03C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED39D0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029761]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onInterstitialAdRewardedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onInterstitialAdRewardedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onInterstitialAdRewardedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onInterstitialAdRewardedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400003B")]
	private static event Action _onOfferwallOpenedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x159A130", Offset = "0x159A130", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC3268]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029763]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xE8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 232L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x60000FF")]
		[Address(RVA = "0x159A1E8", Offset = "0x159A1E8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ED1C00]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029764]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xE8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallOpenedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 232L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400003C")]
	public static event Action onOfferwallOpenedEvent
	{
		[Token(Token = "0x6000100")]
		[Address(RVA = "0x159A2A0", Offset = "0x159A2A0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA90A8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029765]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallOpenedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onOfferwallOpenedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onOfferwallOpenedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallOpenedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onOfferwallOpenedEvent += value;
		}
		[Token(Token = "0x6000101")]
		[Address(RVA = "0x159A32C", Offset = "0x159A32C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1F0E120]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029766]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallOpenedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onOfferwallOpenedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallOpenedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onOfferwallOpenedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400003D")]
	private static event Action<IronSourceError> _onOfferwallShowFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000103")]
		[Address(RVA = "0x159A420", Offset = "0x159A420", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EBDB68]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029768]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xF0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallShowFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 240L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000104")]
		[Address(RVA = "0x159A4D8", Offset = "0x159A4D8", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECB450]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029769]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xF0;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallShowFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 240L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400003E")]
	public static event Action<IronSourceError> onOfferwallShowFailedEvent
	{
		[Token(Token = "0x6000105")]
		[Address(RVA = "0x159A590", Offset = "0x159A590", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED0530]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202976A]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onOfferwallShowFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onOfferwallShowFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallShowFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onOfferwallShowFailedEvent += value;
		}
		[Token(Token = "0x6000106")]
		[Address(RVA = "0x159A61C", Offset = "0x159A61C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EBB8A0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202976B]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallShowFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onOfferwallShowFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallShowFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onOfferwallShowFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400003F")]
	private static event Action _onOfferwallClosedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000108")]
		[Address(RVA = "0x159A744", Offset = "0x159A744", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFE758]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202976D]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xF8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 248L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000109")]
		[Address(RVA = "0x159A7FC", Offset = "0x159A7FC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC5FB8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202976E]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0xF8;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallClosedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 248L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000040")]
	public static event Action onOfferwallClosedEvent
	{
		[Token(Token = "0x600010A")]
		[Address(RVA = "0x159A8B4", Offset = "0x159A8B4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0A238]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202976F]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallClosedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onOfferwallClosedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onOfferwallClosedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallClosedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onOfferwallClosedEvent += value;
		}
		[Token(Token = "0x600010B")]
		[Address(RVA = "0x159A940", Offset = "0x159A940", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ECFB78]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029770]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallClosedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onOfferwallClosedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallClosedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onOfferwallClosedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000041")]
	private static event Action<IronSourceError> _onGetOfferwallCreditsFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600010D")]
		[Address(RVA = "0x159AA34", Offset = "0x159AA34", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEA170]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029772]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x100;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onGetOfferwallCreditsFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 256L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600010E")]
		[Address(RVA = "0x159AAEC", Offset = "0x159AAEC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFD360]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029773]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x100;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onGetOfferwallCreditsFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 256L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000042")]
	public static event Action<IronSourceError> onGetOfferwallCreditsFailedEvent
	{
		[Token(Token = "0x600010F")]
		[Address(RVA = "0x159ABA4", Offset = "0x159ABA4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0D148]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029774]) = v38;\nL_0018:\n\tv44 = v42._onGetOfferwallCreditsFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onGetOfferwallCreditsFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onGetOfferwallCreditsFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onGetOfferwallCreditsFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onGetOfferwallCreditsFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onGetOfferwallCreditsFailedEvent += value;
		}
		[Token(Token = "0x6000110")]
		[Address(RVA = "0x159AC30", Offset = "0x159AC30", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1F0BCE0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029775]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onGetOfferwallCreditsFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onGetOfferwallCreditsFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onGetOfferwallCreditsFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onGetOfferwallCreditsFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000043")]
	private static event Action<Dictionary<string, object>> _onOfferwallAdCreditedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000112")]
		[Address(RVA = "0x159AD58", Offset = "0x159AD58", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC1F80]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029777]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x108;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallAdCreditedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<Dictionary<string, object>>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 264L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000113")]
		[Address(RVA = "0x159AE10", Offset = "0x159AE10", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF82D0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029778]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x108;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallAdCreditedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<Dictionary<string, object>>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 264L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000044")]
	public static event Action<Dictionary<string, object>> onOfferwallAdCreditedEvent
	{
		[Token(Token = "0x6000114")]
		[Address(RVA = "0x159AEC8", Offset = "0x159AEC8", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0BA68]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029779]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallAdCreditedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallAdCreditedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onOfferwallAdCreditedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onOfferwallAdCreditedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallAdCreditedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onOfferwallAdCreditedEvent += value;
		}
		[Token(Token = "0x6000115")]
		[Address(RVA = "0x159AF54", Offset = "0x159AF54", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EA9088]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202977A]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallAdCreditedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onOfferwallAdCreditedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallAdCreditedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onOfferwallAdCreditedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000045")]
	private static event Action<bool> _onOfferwallAvailableEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000117")]
		[Address(RVA = "0x159B0A4", Offset = "0x159B0A4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC8C88]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202977C]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Boolean>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x110;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallAvailableEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<bool>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 272L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000118")]
		[Address(RVA = "0x159B15C", Offset = "0x159B15C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EAA700]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202977D]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.Boolean>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x110;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onOfferwallAvailableEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<bool>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 272L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000046")]
	public static event Action<bool> onOfferwallAvailableEvent
	{
		[Token(Token = "0x6000119")]
		[Address(RVA = "0x159B214", Offset = "0x159B214", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F100A0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202977E]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallAvailableEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallAvailableEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onOfferwallAvailableEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onOfferwallAvailableEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallAvailableEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onOfferwallAvailableEvent += value;
		}
		[Token(Token = "0x600011A")]
		[Address(RVA = "0x159B2A0", Offset = "0x159B2A0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EAD818]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202977F]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onOfferwallAvailableEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onOfferwallAvailableEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onOfferwallAvailableEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onOfferwallAvailableEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000047")]
	private static event Action _onBannerAdLoadedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600011C")]
		[Address(RVA = "0x159B3C0", Offset = "0x159B3C0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECF668]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029781]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x118;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLoadedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 280L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600011D")]
		[Address(RVA = "0x159B478", Offset = "0x159B478", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EF1AF8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029782]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x118;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLoadedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 280L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000048")]
	public static event Action onBannerAdLoadedEvent
	{
		[Token(Token = "0x600011E")]
		[Address(RVA = "0x159B530", Offset = "0x159B530", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFBCD8]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029783]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdLoadedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLoadedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdLoadedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdLoadedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLoadedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdLoadedEvent += value;
		}
		[Token(Token = "0x600011F")]
		[Address(RVA = "0x159B5BC", Offset = "0x159B5BC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1F01B00]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029784]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLoadedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdLoadedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLoadedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdLoadedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000049")]
	private static event Action<IronSourceError> _onBannerAdLoadFailedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000121")]
		[Address(RVA = "0x159B6B0", Offset = "0x159B6B0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1ECBA28]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029786]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x120;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLoadFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 288L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000122")]
		[Address(RVA = "0x159B768", Offset = "0x159B768", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EE4878]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029787]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<IronSourceError>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x120;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLoadFailedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<IronSourceError>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 288L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400004A")]
	public static event Action<IronSourceError> onBannerAdLoadFailedEvent
	{
		[Token(Token = "0x6000123")]
		[Address(RVA = "0x159B820", Offset = "0x159B820", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB3098]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029788]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdLoadFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLoadFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdLoadFailedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdLoadFailedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLoadFailedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdLoadFailedEvent += value;
		}
		[Token(Token = "0x6000124")]
		[Address(RVA = "0x159B8AC", Offset = "0x159B8AC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EC31F0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029789]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLoadFailedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdLoadFailedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLoadFailedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdLoadFailedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400004B")]
	private static event Action _onBannerAdClickedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000126")]
		[Address(RVA = "0x159B9D4", Offset = "0x159B9D4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFECF0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202978B]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x128;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 296L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000127")]
		[Address(RVA = "0x159BA8C", Offset = "0x159BA8C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFB060]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202978C]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x128;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdClickedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 296L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400004C")]
	public static event Action onBannerAdClickedEvent
	{
		[Token(Token = "0x6000128")]
		[Address(RVA = "0x159BB44", Offset = "0x159BB44", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFD620]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202978D]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdClickedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdClickedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdClickedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdClickedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdClickedEvent += value;
		}
		[Token(Token = "0x6000129")]
		[Address(RVA = "0x159BBD0", Offset = "0x159BBD0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF1B58]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202978E]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdClickedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdClickedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdClickedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdClickedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400004D")]
	private static event Action _onBannerAdScreenPresentedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600012B")]
		[Address(RVA = "0x159BCC4", Offset = "0x159BCC4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EC19F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029790]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x130;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdScreenPresentedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 304L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600012C")]
		[Address(RVA = "0x159BD7C", Offset = "0x159BD7C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEF6D8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029791]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x130;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdScreenPresentedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 304L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x1400004E")]
	public static event Action onBannerAdScreenPresentedEvent
	{
		[Token(Token = "0x600012D")]
		[Address(RVA = "0x159BE34", Offset = "0x159BE34", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF7568]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029792]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdScreenPresentedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdScreenPresentedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdScreenPresentedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdScreenPresentedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdScreenPresentedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdScreenPresentedEvent += value;
		}
		[Token(Token = "0x600012E")]
		[Address(RVA = "0x159BEC0", Offset = "0x159BEC0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ECEFF0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029793]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdScreenPresentedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdScreenPresentedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdScreenPresentedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdScreenPresentedEvent -= value;
			}
		}
	}

	[Token(Token = "0x1400004F")]
	private static event Action _onBannerAdScreenDismissedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000130")]
		[Address(RVA = "0x159BFB4", Offset = "0x159BFB4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F08F00]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029795]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x138;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdScreenDismissedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 312L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000131")]
		[Address(RVA = "0x159C06C", Offset = "0x159C06C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F0D968]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2029796]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x138;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdScreenDismissedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 312L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000050")]
	public static event Action onBannerAdScreenDismissedEvent
	{
		[Token(Token = "0x6000132")]
		[Address(RVA = "0x159C124", Offset = "0x159C124", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EECE58]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029797]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdScreenDismissedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdScreenDismissedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdScreenDismissedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdScreenDismissedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdScreenDismissedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdScreenDismissedEvent += value;
		}
		[Token(Token = "0x6000133")]
		[Address(RVA = "0x159C1B0", Offset = "0x159C1B0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF2618]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2029798]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdScreenDismissedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdScreenDismissedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdScreenDismissedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdScreenDismissedEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000051")]
	private static event Action _onBannerAdLeftApplicationEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x6000135")]
		[Address(RVA = "0x159C2A4", Offset = "0x159C2A4", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F08210]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202979A]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x140;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLeftApplicationEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 320L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x6000136")]
		[Address(RVA = "0x159C35C", Offset = "0x159C35C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EFB730]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202979B]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x140;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onBannerAdLeftApplicationEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 320L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000052")]
	public static event Action onBannerAdLeftApplicationEvent
	{
		[Token(Token = "0x6000137")]
		[Address(RVA = "0x159C414", Offset = "0x159C414", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECB7F0]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202979C]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdLeftApplicationEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLeftApplicationEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onBannerAdLeftApplicationEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onBannerAdLeftApplicationEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLeftApplicationEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onBannerAdLeftApplicationEvent += value;
		}
		[Token(Token = "0x6000138")]
		[Address(RVA = "0x159C4A0", Offset = "0x159C4A0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1ED1D58]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202979D]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onBannerAdLeftApplicationEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onBannerAdLeftApplicationEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onBannerAdLeftApplicationEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onBannerAdLeftApplicationEvent -= value;
			}
		}
	}

	[Token(Token = "0x14000053")]
	private static event Action<string> _onSegmentReceivedEvent
	{
		[CompilerGenerated]
		[Token(Token = "0x600013A")]
		[Address(RVA = "0x159C594", Offset = "0x159C594", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1EEB268]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202979F]) = v42;\nL_001F:\n\tv95 = System.Delegate::Combine(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x148;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onSegmentReceivedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 328L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		[CompilerGenerated]
		[Token(Token = "0x600013B")]
		[Address(RVA = "0x159C64C", Offset = "0x159C64C", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv22 = *([1F01768]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20297A0]) = v42;\nL_001F:\n\tv95 = System.Delegate::Remove(v90, value);\n\tv87 = v95 == 0;\n\tif (v87) goto L_0034;\n\tv107 = *([v95 @ X0_v4 (System.Delegate)]) != System.Action`1<System.String>;\n\tif (v107) goto L_004B;\nL_0034:\n\tv120 = v119._onRewardedVideoAdShowFailedEvent + 0x148;\n\tv85 = 0x874190(v120, v95, v90, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv54 = v90 != v85;\n\tif (v54) goto L_001F;\n\treturn;\nL_004B:\n\tthrow System.InvalidCastException;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			//IL_003f: Expected O, but got I
			Delegate obj = IronSourceEvents.m__onSegmentReceivedEvent;
			Delegate obj4 = default(Delegate);
			while (true)
			{
				Delegate obj2 = Delegate.Remove(obj, value);
				if (obj2 != null && (object)obj2.GetType() != typeof(Action<string>))
				{
					break;
				}
				object obj3 = (long)(IntPtr)IronSourceEvents._onRewardedVideoAdShowFailedEvent + 328L;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
				bool flag = obj != obj4;
				obj = obj4;
				if (!flag)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
	}

	[Token(Token = "0x14000054")]
	public static event Action<string> onSegmentReceivedEvent
	{
		[Token(Token = "0x600013C")]
		[Address(RVA = "0x159C704", Offset = "0x159C704", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED1650]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297A1]) = v38;\nL_0018:\n\tv44 = v42._onSegmentReceivedEvent == 0;\n\tif (v44) goto L_0032;\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onSegmentReceivedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv60 = v53 == 0;\n\tif (v60) goto L_0032;\n\treturn;\nL_0032:\n\tIronSourceEvents::add__onSegmentReceivedEvent(value);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		add
		{
			if (IronSourceEvents._onSegmentReceivedEvent != null)
			{
				IEnumerable<Delegate> invocationList = IronSourceEvents._onSegmentReceivedEvent.GetInvocationList();
				if (invocationList.Contains(value))
				{
					return;
				}
			}
			_onSegmentReceivedEvent += value;
		}
		[Token(Token = "0x600013D")]
		[Address(RVA = "0x159C790", Offset = "0x159C790", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv18 = *([1EF1370]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297A2]) = v38;\nL_001D:\n\tv48 = System.MulticastDelegate::GetInvocationList(v42._onSegmentReceivedEvent);\n\tv53 = System.Linq.Enumerable::Contains(v48, value);\n\tv56 = v53 == 0;\n\tif (v56) goto L_0033;\n\tIronSourceEvents::remove__onSegmentReceivedEvent(value);\n\treturn;\nL_0033:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		remove
		{
			IEnumerable<Delegate> invocationList = IronSourceEvents._onSegmentReceivedEvent.GetInvocationList();
			if (invocationList.Contains(value))
			{
				_onSegmentReceivedEvent -= value;
			}
		}
	}

	[Token(Token = "0x600006C")]
	[Address(RVA = "0x15941FC", Offset = "0x15941FC", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB0EE0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296D1]) = v38;\nL_0015:\n\tv41 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.Object::set_name(v41, \"IronSourceEvents\");\n\tv50 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_0035;\n\tv77 = *([v54 @ X8_v7+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0035;\n\tv82 = v54;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v82, v49, v45, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0035:\n\tUnityEngine.Object::DontDestroyOnLoad(v50);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		GameObject gameObject = base.gameObject;
		gameObject.name = "IronSourceEvents";
		GameObject target = base.gameObject;
		UnityEngine.Object.DontDestroyOnLoad(target);
	}

	[Token(Token = "0x6000071")]
	[Address(RVA = "0x1594524", Offset = "0x1594524", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EEB948]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20296D6]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onRewardedVideoAdShowFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdShowFailed(string description)
	{
		if (IronSourceEvents._onRewardedVideoAdShowFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onRewardedVideoAdShowFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x6000076")]
	[Address(RVA = "0x1594A84", Offset = "0x1594A84", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EA99D8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296DB]) = v35;\nL_0016:\n\tv41 = v39._onRewardedVideoAdOpenedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onRewardedVideoAdOpenedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdOpened(string empty)
	{
		if (IronSourceEvents._onRewardedVideoAdOpenedEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdOpenedEvent();
		}
	}

	[Token(Token = "0x600007B")]
	[Address(RVA = "0x1594D74", Offset = "0x1594D74", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EBA700]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296E0]) = v35;\nL_0016:\n\tv41 = v39._onRewardedVideoAdClosedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onRewardedVideoAdClosedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdClosed(string empty)
	{
		if (IronSourceEvents._onRewardedVideoAdClosedEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdClosedEvent();
		}
	}

	[Token(Token = "0x6000080")]
	[Address(RVA = "0x1595064", Offset = "0x1595064", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EED718]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296E5]) = v35;\nL_0016:\n\tv41 = v39._onRewardedVideoAdStartedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onRewardedVideoAdStartedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdStarted(string empty)
	{
		if (IronSourceEvents._onRewardedVideoAdStartedEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdStartedEvent();
		}
	}

	[Token(Token = "0x6000085")]
	[Address(RVA = "0x1595354", Offset = "0x1595354", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1F0EA18]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296EA]) = v35;\nL_0016:\n\tv41 = v39._onRewardedVideoAdEndedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onRewardedVideoAdEndedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdEnded(string empty)
	{
		if (IronSourceEvents._onRewardedVideoAdEndedEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdEndedEvent();
		}
	}

	[Token(Token = "0x600008A")]
	[Address(RVA = "0x1595644", Offset = "0x1595644", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDE420]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20296EF]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdRewardedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getPlacementFromObject(v35, description);\n\tSystem.Action`1<IronSourcePlacement>::Invoke(v53._onRewardedVideoAdRewardedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdRewarded(string description)
	{
		if (IronSourceEvents._onRewardedVideoAdRewardedEvent != null)
		{
			IronSourcePlacement placementFromObject = getPlacementFromObject(description);
			IronSourceEvents._onRewardedVideoAdRewardedEvent(placementFromObject);
		}
	}

	[Token(Token = "0x600008F")]
	[Address(RVA = "0x1595B54", Offset = "0x1595B54", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0CB00]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20296F4]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClickedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getPlacementFromObject(v35, description);\n\tSystem.Action`1<IronSourcePlacement>::Invoke(v53._onRewardedVideoAdClickedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdClicked(string description)
	{
		if (IronSourceEvents._onRewardedVideoAdClickedEvent != null)
		{
			IronSourcePlacement placementFromObject = getPlacementFromObject(description);
			IronSourceEvents._onRewardedVideoAdClickedEvent(placementFromObject);
		}
	}

	[Token(Token = "0x6000094")]
	[Address(RVA = "0x1595E78", Offset = "0x1595E78", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED9460]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, stringAvailable, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20296F9]) = v38;\nL_0018:\n\tv44 = System.String::op_Equality(stringAvailable, \"true\");\n\tv50 = v48._onRewardedVideoAvailabilityChangedEvent == 0;\n\tif (v50) goto L_0031;\n\tSystem.Action`1<System.Boolean>::Invoke(v48._onRewardedVideoAvailabilityChangedEvent, v44);\n\treturn;\nL_0031:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAvailabilityChanged(string stringAvailable)
	{
		bool obj = stringAvailable == "true";
		if (IronSourceEvents._onRewardedVideoAvailabilityChangedEvent != null)
		{
			IronSourceEvents._onRewardedVideoAvailabilityChangedEvent(obj);
		}
	}

	[Token(Token = "0x6000099")]
	[Address(RVA = "0x1596194", Offset = "0x1596194", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAEF28]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20296FE]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdLoadedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onRewardedVideoAdLoadedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdLoadedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onRewardedVideoAdLoadedDemandOnlyEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdLoadedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x600009E")]
	[Address(RVA = "0x1596494", Offset = "0x1596494", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECA320]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, args, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029703]) = v40;\nL_0019:\n\tv46 = v44._onRewardedVideoAdLoadFailedDemandOnlyEvent == 0;\n\tif (v46) goto L_0027;\n\tv49 = System.String::IsNullOrEmpty(args);\n\tv53 = v49 == 0;\n\tif (v53) goto L_002B;\nL_0027:\n\treturn;\nL_002B:\n\tv142 = IronSourceJSON.Json+Parser::Parse(args);\n\tgoto L_FFFFFFFF;\n\tv201 = *([v142 @ X0_v10 (System.Object)+18]) < 1;\n\tv102 = ~v201;\n\tv98 = *([v142 @ X0_v10 (System.Object)+18]) - 1;\n\tv90 = v98 == 0;\n\tv202 = ~v90;\n\tv70 = v102 & v202;\n\tif (v70) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv205 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv206 = IronSourceEvents::getErrorFromErrorObject(v204, *([v205 @ X8_v12+28]));\n\tv208 = *([v142 @ X0_v10 (System.Object)+18]) == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv193 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv191 = *([v193 @ X8_v14+20]);\n\tv212 = *([v191 @ X0_v14]);\n\t*([v212 @ X8_v15+160])(v179, v191, *([v212 @ X8_v15+168]), methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Action`2<System.String, IronSourceError>::Invoke(v215._onRewardedVideoAdLoadFailedDemandOnlyEvent, v179, v206);\n\treturn;\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdLoadFailedDemandOnly(string args)
	{
		//IL_0091: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0162: Expected O, but got I
		if (IronSourceEvents._onRewardedVideoAdLoadFailedDemandOnlyEvent != null && !string.IsNullOrEmpty(args))
		{
			object obj = Json.Parser.Parse(args);
			List<object> list = obj as List<object>;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			object obj2 = -1;
			bool flag3 = obj2 == null;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			IronSourceEvents ironSourceEvents = (IronSourceEvents)obj;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v12+28]");
			IronSourceError errorFromErrorObject = ironSourceEvents.getErrorFromErrorObject(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v14+20]");
			object obj5 = 0;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ X8_v15+160] (should have been resolved before IL gen)");
			string arg = default(string);
			IronSourceEvents._onRewardedVideoAdLoadFailedDemandOnlyEvent(arg, errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0x1596864", Offset = "0x1596864", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA7278]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029708]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdOpenedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onRewardedVideoAdOpenedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdOpenedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onRewardedVideoAdOpenedDemandOnlyEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdOpenedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0x1596B64", Offset = "0x1596B64", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC2AE8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202970D]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClosedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onRewardedVideoAdClosedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdClosedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onRewardedVideoAdClosedDemandOnlyEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdClosedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000AD")]
	[Address(RVA = "0x1596E64", Offset = "0x1596E64", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAF700]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029712]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdRewardedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onRewardedVideoAdRewardedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdRewardedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onRewardedVideoAdRewardedDemandOnlyEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdRewardedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000B2")]
	[Address(RVA = "0x1597164", Offset = "0x1597164", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB63F8]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, args, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029717]) = v40;\nL_0019:\n\tv46 = v44._onRewardedVideoAdShowFailedDemandOnlyEvent == 0;\n\tif (v46) goto L_0027;\n\tv49 = System.String::IsNullOrEmpty(args);\n\tv53 = v49 == 0;\n\tif (v53) goto L_002B;\nL_0027:\n\treturn;\nL_002B:\n\tv142 = IronSourceJSON.Json+Parser::Parse(args);\n\tgoto L_FFFFFFFF;\n\tv201 = *([v142 @ X0_v10 (System.Object)+18]) < 1;\n\tv102 = ~v201;\n\tv98 = *([v142 @ X0_v10 (System.Object)+18]) - 1;\n\tv90 = v98 == 0;\n\tv202 = ~v90;\n\tv70 = v102 & v202;\n\tif (v70) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv205 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv206 = IronSourceEvents::getErrorFromErrorObject(v204, *([v205 @ X8_v12+28]));\n\tv208 = *([v142 @ X0_v10 (System.Object)+18]) == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv193 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv191 = *([v193 @ X8_v14+20]);\n\tv212 = *([v191 @ X0_v14]);\n\t*([v212 @ X8_v15+160])(v179, v191, *([v212 @ X8_v15+168]), methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Action`2<System.String, IronSourceError>::Invoke(v215._onRewardedVideoAdShowFailedDemandOnlyEvent, v179, v206);\n\treturn;\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdShowFailedDemandOnly(string args)
	{
		//IL_0091: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0162: Expected O, but got I
		if (IronSourceEvents._onRewardedVideoAdShowFailedDemandOnlyEvent != null && !string.IsNullOrEmpty(args))
		{
			object obj = Json.Parser.Parse(args);
			List<object> list = obj as List<object>;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			object obj2 = -1;
			bool flag3 = obj2 == null;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			IronSourceEvents ironSourceEvents = (IronSourceEvents)obj;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v12+28]");
			IronSourceError errorFromErrorObject = ironSourceEvents.getErrorFromErrorObject(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v14+20]");
			object obj5 = 0;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ X8_v15+160] (should have been resolved before IL gen)");
			string arg = default(string);
			IronSourceEvents._onRewardedVideoAdShowFailedDemandOnlyEvent(arg, errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000B7")]
	[Address(RVA = "0x1597534", Offset = "0x1597534", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED6A18]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202971C]) = v38;\nL_0018:\n\tv44 = v42._onRewardedVideoAdClickedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onRewardedVideoAdClickedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onRewardedVideoAdClickedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onRewardedVideoAdClickedDemandOnlyEvent != null)
		{
			IronSourceEvents._onRewardedVideoAdClickedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000BC")]
	[Address(RVA = "0x1597834", Offset = "0x1597834", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EDB9D8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029721]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdReadyEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdReadyEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdReady()
	{
		if (IronSourceEvents._onInterstitialAdReadyEvent != null)
		{
			IronSourceEvents._onInterstitialAdReadyEvent();
		}
	}

	[Token(Token = "0x60000C1")]
	[Address(RVA = "0x1597B24", Offset = "0x1597B24", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE6A40]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029726]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdLoadFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onInterstitialAdLoadFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdLoadFailed(string description)
	{
		if (IronSourceEvents._onInterstitialAdLoadFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onInterstitialAdLoadFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000C6")]
	[Address(RVA = "0x1597E48", Offset = "0x1597E48", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EFE538]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202972B]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdOpenedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdOpenedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdOpened(string empty)
	{
		if (IronSourceEvents._onInterstitialAdOpenedEvent != null)
		{
			IronSourceEvents._onInterstitialAdOpenedEvent();
		}
	}

	[Token(Token = "0x60000CB")]
	[Address(RVA = "0x1598138", Offset = "0x1598138", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EA7348]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029730]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdClosedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdClosedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdClosed(string empty)
	{
		if (IronSourceEvents._onInterstitialAdClosedEvent != null)
		{
			IronSourceEvents._onInterstitialAdClosedEvent();
		}
	}

	[Token(Token = "0x60000D0")]
	[Address(RVA = "0x1598428", Offset = "0x1598428", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC72A8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029735]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdShowSucceededEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdShowSucceededEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdShowSucceeded(string empty)
	{
		if (IronSourceEvents._onInterstitialAdShowSucceededEvent != null)
		{
			IronSourceEvents._onInterstitialAdShowSucceededEvent();
		}
	}

	[Token(Token = "0x60000D5")]
	[Address(RVA = "0x1598718", Offset = "0x1598718", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDF258]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202973A]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onInterstitialAdShowFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdShowFailed(string description)
	{
		if (IronSourceEvents._onInterstitialAdShowFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onInterstitialAdShowFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000DA")]
	[Address(RVA = "0x1598A3C", Offset = "0x1598A3C", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EF2788]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202973F]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdClickedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdClickedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdClicked(string empty)
	{
		if (IronSourceEvents._onInterstitialAdClickedEvent != null)
		{
			IronSourceEvents._onInterstitialAdClickedEvent();
		}
	}

	[Token(Token = "0x60000DF")]
	[Address(RVA = "0x1598D2C", Offset = "0x1598D2C", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDD670]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029744]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdReadyDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onInterstitialAdReadyDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdReadyDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onInterstitialAdReadyDemandOnlyEvent != null)
		{
			IronSourceEvents._onInterstitialAdReadyDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000E4")]
	[Address(RVA = "0x159902C", Offset = "0x159902C", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC9C48]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, args, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029749]) = v40;\nL_0019:\n\tv46 = v44._onInterstitialAdLoadFailedDemandOnlyEvent == 0;\n\tif (v46) goto L_0027;\n\tv49 = System.String::IsNullOrEmpty(args);\n\tv53 = v49 == 0;\n\tif (v53) goto L_002B;\nL_0027:\n\treturn;\nL_002B:\n\tv142 = IronSourceJSON.Json+Parser::Parse(args);\n\tgoto L_FFFFFFFF;\n\tv201 = *([v142 @ X0_v10 (System.Object)+18]) < 1;\n\tv102 = ~v201;\n\tv98 = *([v142 @ X0_v10 (System.Object)+18]) - 1;\n\tv90 = v98 == 0;\n\tv202 = ~v90;\n\tv70 = v102 & v202;\n\tif (v70) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv205 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv206 = IronSourceEvents::getErrorFromErrorObject(v204, *([v205 @ X8_v12+28]));\n\tv208 = *([v142 @ X0_v10 (System.Object)+18]) == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv193 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv191 = *([v193 @ X8_v14+20]);\n\tv212 = *([v191 @ X0_v14]);\n\t*([v212 @ X8_v15+160])(v179, v191, *([v212 @ X8_v15+168]), methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Action`2<System.String, IronSourceError>::Invoke(v215._onInterstitialAdLoadFailedDemandOnlyEvent, v179, v206);\n\treturn;\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdLoadFailedDemandOnly(string args)
	{
		//IL_0091: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0162: Expected O, but got I
		if (IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent != null && !string.IsNullOrEmpty(args))
		{
			object obj = Json.Parser.Parse(args);
			List<object> list = obj as List<object>;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			object obj2 = -1;
			bool flag3 = obj2 == null;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			IronSourceEvents ironSourceEvents = (IronSourceEvents)obj;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v12+28]");
			IronSourceError errorFromErrorObject = ironSourceEvents.getErrorFromErrorObject(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v14+20]");
			object obj5 = 0;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ X8_v15+160] (should have been resolved before IL gen)");
			string arg = default(string);
			IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent(arg, errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000E9")]
	[Address(RVA = "0x15993FC", Offset = "0x15993FC", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB0B80]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202974E]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdOpenedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onInterstitialAdOpenedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdOpenedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onInterstitialAdOpenedDemandOnlyEvent != null)
		{
			IronSourceEvents._onInterstitialAdOpenedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000EE")]
	[Address(RVA = "0x15996FC", Offset = "0x15996FC", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC7718]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029753]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClosedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onInterstitialAdClosedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdClosedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onInterstitialAdClosedDemandOnlyEvent != null)
		{
			IronSourceEvents._onInterstitialAdClosedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000F3")]
	[Address(RVA = "0x15999FC", Offset = "0x15999FC", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1ECFAE0]);\n\tv21 = *([v20 @ X8_v21]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, args, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 0 | 1;\n\t*([2029758]) = v40;\nL_0019:\n\tv46 = v44._onInterstitialAdLoadFailedDemandOnlyEvent == 0;\n\tif (v46) goto L_0027;\n\tv49 = System.String::IsNullOrEmpty(args);\n\tv53 = v49 == 0;\n\tif (v53) goto L_002B;\nL_0027:\n\treturn;\nL_002B:\n\tv142 = IronSourceJSON.Json+Parser::Parse(args);\n\tgoto L_FFFFFFFF;\n\tv201 = *([v142 @ X0_v10 (System.Object)+18]) < 1;\n\tv102 = ~v201;\n\tv98 = *([v142 @ X0_v10 (System.Object)+18]) - 1;\n\tv90 = v98 == 0;\n\tv202 = ~v90;\n\tv70 = v102 & v202;\n\tif (v70) goto L_005E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_005E:\n\tv205 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv206 = IronSourceEvents::getErrorFromErrorObject(v204, *([v205 @ X8_v12+28]));\n\tv208 = *([v142 @ X0_v10 (System.Object)+18]) == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0068;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0068:\n\tv193 = *([v142 @ X0_v10 (System.Object)+10]);\n\tv191 = *([v193 @ X8_v14+20]);\n\tv212 = *([v191 @ X0_v14]);\n\t*([v212 @ X8_v15+160])(v179, v191, *([v212 @ X8_v15+168]), methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tSystem.Action`2<System.String, IronSourceError>::Invoke(v215._onInterstitialAdShowFailedDemandOnlyEvent, v179, v206);\n\treturn;\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdShowFailedDemandOnly(string args)
	{
		//IL_0091: Expected O, but got I
		//IL_00ee: Expected O, but got I
		//IL_0103: Expected O, but got I
		//IL_0152: Expected O, but got I
		//IL_0162: Expected O, but got I
		if (IronSourceEvents._onInterstitialAdLoadFailedDemandOnlyEvent != null && !string.IsNullOrEmpty(args))
		{
			object obj = Json.Parser.Parse(args);
			List<object> list = obj as List<object>;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			bool flag = 0L < 1L;
			bool flag2 = !flag;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			object obj2 = -1;
			bool flag3 = obj2 == null;
			bool flag4 = !flag3;
			bool flag5 = flag2 && flag4;
			IronSourceEvents ironSourceEvents = (IronSourceEvents)obj;
			if (!flag5)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v12+28]");
			IronSourceError errorFromErrorObject = ironSourceEvents.getErrorFromErrorObject(0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+18]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				throw new ArgumentOutOfRangeException();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v10 (System.Object)+10]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X8_v14+20]");
			object obj5 = 0;
			object obj6 = obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v212 @ X8_v15+160] (should have been resolved before IL gen)");
			string arg = default(string);
			IronSourceEvents._onInterstitialAdShowFailedDemandOnlyEvent(arg, errorFromErrorObject);
		}
	}

	[Token(Token = "0x60000F8")]
	[Address(RVA = "0x1599DCC", Offset = "0x1599DCC", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE1BF8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, instanceId, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202975D]) = v38;\nL_0018:\n\tv44 = v42._onInterstitialAdClickedDemandOnlyEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onInterstitialAdClickedDemandOnlyEvent, instanceId);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdClickedDemandOnly(string instanceId)
	{
		if (IronSourceEvents._onInterstitialAdClickedDemandOnlyEvent != null)
		{
			IronSourceEvents._onInterstitialAdClickedDemandOnlyEvent(instanceId);
		}
	}

	[Token(Token = "0x60000FD")]
	[Address(RVA = "0x159A0CC", Offset = "0x159A0CC", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC8210]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029762]) = v35;\nL_0016:\n\tv41 = v39._onInterstitialAdRewardedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onInterstitialAdRewardedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInterstitialAdRewarded(string empty)
	{
		if (IronSourceEvents._onInterstitialAdRewardedEvent != null)
		{
			IronSourceEvents._onInterstitialAdRewardedEvent();
		}
	}

	[Token(Token = "0x6000102")]
	[Address(RVA = "0x159A3BC", Offset = "0x159A3BC", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC3F20]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029767]) = v35;\nL_0016:\n\tv41 = v39._onOfferwallOpenedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onOfferwallOpenedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOfferwallOpened(string empty)
	{
		if (IronSourceEvents._onOfferwallOpenedEvent != null)
		{
			IronSourceEvents._onOfferwallOpenedEvent();
		}
	}

	[Token(Token = "0x6000107")]
	[Address(RVA = "0x159A6AC", Offset = "0x159A6AC", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB8040]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202976C]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallShowFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onOfferwallShowFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOfferwallShowFailed(string description)
	{
		if (IronSourceEvents._onOfferwallShowFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onOfferwallShowFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x600010C")]
	[Address(RVA = "0x159A9D0", Offset = "0x159A9D0", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EB5D60]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, empty, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029771]) = v35;\nL_0016:\n\tv41 = v39._onOfferwallClosedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onOfferwallClosedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOfferwallClosed(string empty)
	{
		if (IronSourceEvents._onOfferwallClosedEvent != null)
		{
			IronSourceEvents._onOfferwallClosedEvent();
		}
	}

	[Token(Token = "0x6000111")]
	[Address(RVA = "0x159ACC0", Offset = "0x159ACC0", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB1D80]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029776]) = v38;\nL_0018:\n\tv44 = v42._onGetOfferwallCreditsFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onGetOfferwallCreditsFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onGetOfferwallCreditsFailed(string description)
	{
		if (IronSourceEvents._onGetOfferwallCreditsFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onGetOfferwallCreditsFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x6000116")]
	[Address(RVA = "0x159AFE4", Offset = "0x159AFE4", Length = "0xC0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED1260]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, json, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202977B]) = v38;\nL_0018:\n\tv44 = v42._onOfferwallAdCreditedEvent == 0;\n\tif (v44) goto L_0041;\n\tv45 = json == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tv51 = IronSourceJSON.Json+Parser::Parse(json);\n\tv87 = v51 == 0;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_003A:\n\tSystem.Action`1<System.Collections.Generic.Dictionary`2<System.String, System.Object>>::Invoke(v42._onOfferwallAdCreditedEvent, v102);\n\treturn;\nL_0041:\n\treturn;\n\tv137 = v137_asT == 0;\n\tif (v137) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003A;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOfferwallAdCredited(string json)
	{
		if (IronSourceEvents._onOfferwallAdCreditedEvent == null)
		{
			return;
		}
		Dictionary<string, object> obj3;
		if (json != null)
		{
			object obj = Json.Parser.Parse(json);
			if (obj != null)
			{
				Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
				object obj2 = ((dictionary == null) ? null : obj);
				obj3 = (Dictionary<string, object>)obj2;
				goto IL_00c8;
			}
		}
		obj3 = null;
		goto IL_00c8;
		IL_00c8:
		IronSourceEvents._onOfferwallAdCreditedEvent(obj3);
	}

	[Token(Token = "0x600011B")]
	[Address(RVA = "0x159B330", Offset = "0x159B330", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB87F0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, stringAvailable, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2029780]) = v38;\nL_0018:\n\tv44 = System.String::op_Equality(stringAvailable, \"true\");\n\tv50 = v48._onOfferwallAvailableEvent == 0;\n\tif (v50) goto L_0031;\n\tSystem.Action`1<System.Boolean>::Invoke(v48._onOfferwallAvailableEvent, v44);\n\treturn;\nL_0031:\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOfferwallAvailable(string stringAvailable)
	{
		bool obj = stringAvailable == "true";
		if (IronSourceEvents._onOfferwallAvailableEvent != null)
		{
			IronSourceEvents._onOfferwallAvailableEvent(obj);
		}
	}

	[Token(Token = "0x6000120")]
	[Address(RVA = "0x159B64C", Offset = "0x159B64C", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EB94F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029785]) = v35;\nL_0016:\n\tv41 = v39._onBannerAdLoadedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onBannerAdLoadedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdLoaded()
	{
		if (IronSourceEvents._onBannerAdLoadedEvent != null)
		{
			IronSourceEvents._onBannerAdLoadedEvent();
		}
	}

	[Token(Token = "0x6000125")]
	[Address(RVA = "0x159B93C", Offset = "0x159B93C", Length = "0x98")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC3F58]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, description, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202978A]) = v38;\nL_0018:\n\tv44 = v42._onBannerAdLoadFailedEvent == 0;\n\tif (v44) goto L_0032;\n\tv46 = IronSourceEvents::getErrorFromErrorObject(v35, description);\n\tSystem.Action`1<IronSourceError>::Invoke(v53._onBannerAdLoadFailedEvent, v46);\n\treturn;\nL_0032:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdLoadFailed(string description)
	{
		if (IronSourceEvents._onBannerAdLoadFailedEvent != null)
		{
			IronSourceError errorFromErrorObject = getErrorFromErrorObject(description);
			IronSourceEvents._onBannerAdLoadFailedEvent(errorFromErrorObject);
		}
	}

	[Token(Token = "0x600012A")]
	[Address(RVA = "0x159BC60", Offset = "0x159BC60", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EF29F0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202978F]) = v35;\nL_0016:\n\tv41 = v39._onBannerAdClickedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onBannerAdClickedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdClicked()
	{
		if (IronSourceEvents._onBannerAdClickedEvent != null)
		{
			IronSourceEvents._onBannerAdClickedEvent();
		}
	}

	[Token(Token = "0x600012F")]
	[Address(RVA = "0x159BF50", Offset = "0x159BF50", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1F0EE98]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029794]) = v35;\nL_0016:\n\tv41 = v39._onBannerAdScreenPresentedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onBannerAdScreenPresentedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdScreenPresented()
	{
		if (IronSourceEvents._onBannerAdScreenPresentedEvent != null)
		{
			IronSourceEvents._onBannerAdScreenPresentedEvent();
		}
	}

	[Token(Token = "0x6000134")]
	[Address(RVA = "0x159C240", Offset = "0x159C240", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ECD0F8]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029799]) = v35;\nL_0016:\n\tv41 = v39._onBannerAdScreenDismissedEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onBannerAdScreenDismissedEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdScreenDismissed()
	{
		if (IronSourceEvents._onBannerAdScreenDismissedEvent != null)
		{
			IronSourceEvents._onBannerAdScreenDismissedEvent();
		}
	}

	[Token(Token = "0x6000139")]
	[Address(RVA = "0x159C530", Offset = "0x159C530", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ED9DA0]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202979E]) = v35;\nL_0016:\n\tv41 = v39._onBannerAdLeftApplicationEvent == 0;\n\tif (v41) goto L_0023;\n\tSystem.Action::Invoke(v39._onBannerAdLeftApplicationEvent);\n\treturn;\nL_0023:\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onBannerAdLeftApplication()
	{
		if (IronSourceEvents._onBannerAdLeftApplicationEvent != null)
		{
			IronSourceEvents._onBannerAdLeftApplicationEvent();
		}
	}

	[Token(Token = "0x600013E")]
	[Address(RVA = "0x159C820", Offset = "0x159C820", Length = "0x74")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBFC68]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, segmentName, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([20297A3]) = v38;\nL_0018:\n\tv44 = v42._onSegmentReceivedEvent == 0;\n\tif (v44) goto L_002A;\n\tSystem.Action`1<System.String>::Invoke(v42._onSegmentReceivedEvent, segmentName);\n\treturn;\nL_002A:\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onSegmentReceived(string segmentName)
	{
		if (IronSourceEvents._onSegmentReceivedEvent != null)
		{
			IronSourceEvents._onSegmentReceivedEvent(segmentName);
		}
	}

	[Token(Token = "0x600013F")]
	[Address(RVA = "0x15945BC", Offset = "0x15945BC", Length = "0x23C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECC688]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, descriptionObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([20297A4]) = v42;\nL_0019:\n\t// 25 IsInst v47 @ X0_v3, typeof(System.Collections.IDictionary), descriptionObject @ X1 (System.Object)\n\tv48 = v47 == 0;\n\tif (v48) goto L_0043;\n\tv49 = descriptionObject == 0;\n\tif (v49) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv144 = v144_asT == 0;\n\tif (v144) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tgoto L_0057;\nL_0043:\n\tv50 = descriptionObject == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tv89 = *([descriptionObject @ X1 (System.Object)]) == System.String;\n\tif (v89) goto L_00B5;\nL_0057:\n\tv186 = new IronSourceError();\n\tSystem.Object::.ctor(v186);\n\tv186.code = 0xFFFFFFFF;\n\tv186.description = \"\";\n\tv200 = v180 == 0;\n\tif (v200) goto L_00B1;\n\tv206 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v180);\n\tv214 = v206 < 1;\n\tif (v214) goto L_00B1;\n\tv288 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v180, \"error_code\");\n\tv296 = *([v288 @ X0_v12]);\n\t*([v296 @ X8_v15+160])(v299, v288, *([v296 @ X8_v15+168]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0092;\n\tv314 = *([v303 @ X8_v18+E0]);\n\tv315 = v314 == 0;\n\tv316 = ~v315;\n\tif (v316) goto L_0092;\n\tv323 = v303;\n\tv318 = \"il2cpp_codegen_runtime_class_init\"(v323, v298, v287, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0092:\n\tv322 = System.Convert::ToInt32(v299);\n\tv310 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v180, \"error_description\");\n\tv326 = *([v310 @ X0_v20]);\n\t*([v326 @ X8_v21+160])(v328, v310, *([v326 @ X8_v21+168]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv234 = new IronSourceError();\n\tSystem.Object::.ctor(v234);\n\t*([v234 @ X0_v23 (System.Object)+18]) = v322;\n\t*([v234 @ X0_v23 (System.Object)+10]) = v328;\nL_00B1:\n\treturn v237;\nL_00B5:\n\tv189 = System.String::ToString(descriptionObject);\n\tv176 = System.String::IsNullOrEmpty(v189);\n\tv198 = v176 == 0;\n\tv178 = ~v198;\n\tif (v178) goto L_0057;\n\tv116 = System.Object::ToString(descriptionObject);\n\tv119 = v116 == 0;\n\tif (v119) goto L_FFFFFFFF;\n\tv117 = IronSourceJSON.Json+Parser::Parse(v116);\n\tv120 = v117 == 0;\n\tif (v120) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv149 = v149_asT == 0;\n\tif (v149) goto L_FFFFFFFF;\n\tgoto L_00EB;\nL_00EB:\n\tgoto L_0057;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 172 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IronSourceError getErrorFromErrorObject(object descriptionObject)
	{
		object obj = descriptionObject as IDictionary;
		object obj2;
		if (obj != null)
		{
			if (descriptionObject != null)
			{
				Dictionary<string, object> dictionary = descriptionObject as Dictionary<string, object>;
				obj2 = ((dictionary == null) ? null : descriptionObject);
				goto IL_0283;
			}
		}
		else if (descriptionObject != null && (object)descriptionObject.GetType() == typeof(string))
		{
			string value = ((string)descriptionObject).ToString();
			bool flag = string.IsNullOrEmpty(value);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			obj2 = null;
			if (flag3)
			{
				goto IL_0283;
			}
			string text = descriptionObject.ToString();
			if (text != null)
			{
				object obj3 = Json.Parser.Parse(text);
				if (obj3 != null)
				{
					Dictionary<string, object> dictionary2 = obj3 as Dictionary<string, object>;
					obj2 = ((dictionary2 == null) ? null : obj3);
					goto IL_0283;
				}
			}
		}
		obj2 = null;
		goto IL_0283;
		IL_0283:
		IronSourceError ironSourceError = null;
		ironSourceError.code = -1;
		ironSourceError.description = "";
		bool flag4 = obj2 == null;
		IronSourceError result = ironSourceError;
		if (!flag4)
		{
			int count = ((Dictionary<string, object>)obj2).Count;
			bool flag5 = count < 1;
			result = ironSourceError;
			if (!flag5)
			{
				object obj4 = ((Dictionary<string, object>)obj2).get_Item("error_code");
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v296 @ X8_v15+160] (should have been resolved before IL gen)");
				string value2 = default(string);
				int num = Convert.ToInt32(value2);
				object obj6 = ((Dictionary<string, object>)obj2).get_Item("error_description");
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v326 @ X8_v21+160] (should have been resolved before IL gen)");
				object obj8 = null;
				result = (IronSourceError)obj8;
			}
		}
		return result;
	}

	[Token(Token = "0x6000140")]
	[Address(RVA = "0x15956DC", Offset = "0x15956DC", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1ECDD30]);\n\tv23 = *([v22 @ X8_v34]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, placementObject, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 0 | 1;\n\t*([20297A5]) = v42;\nL_0019:\n\t// 25 IsInst v47 @ X0_v3, typeof(System.Collections.IDictionary), placementObject @ X1 (System.Object)\n\tv48 = v47 == 0;\n\tif (v48) goto L_0095;\n\tv49 = placementObject == 0;\n\tif (v49) goto L_00AE;\nL_002E:\n\tgoto L_FFFFFFFF;\n\tv191 = v191_asT == 0;\n\tif (v191) goto L_FFFFFFFF;\n\tv193 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Count(v84);\n\tv120 = v193 < 1;\n\tif (v120) goto L_FFFFFFFF;\n\tv243 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_reward_amount\");\n\tv245 = *([v243 @ X0_v14]);\n\t*([v245 @ X8_v19+160])(v248, v243, *([v245 @ X8_v19+168]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_006D;\n\tv267 = *([v252 @ X8_v22+E0]);\n\tv268 = v267 == 0;\n\tv269 = ~v268;\n\tif (v269) goto L_006D;\n\tv276 = v252;\n\tv271 = \"il2cpp_codegen_runtime_class_init\"(v276, v247, v242, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv275 = System.Convert::ToInt32(v248);\n\tv262 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_reward_name\");\n\tv279 = *([v262 @ X0_v22]);\n\t*([v279 @ X8_v25+160])(v281, v262, *([v279 @ X8_v25+168]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv263 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::get_Item(v84, \"placement_name\");\n\tv284 = *([v263 @ X0_v25]);\n\t*([v284 @ X8_v28+160])(v286, v263, *([v284 @ X8_v28+168]), Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = new IronSourcePlacement();\n\tSystem.Object::.ctor(v156);\n\t*([v156 @ X0_v28 (System.Object)+20]) = v286;\n\t*([v156 @ X0_v28 (System.Object)+10]) = v281;\n\t*([v156 @ X0_v28 (System.Object)+18]) = v275;\n\tgoto L_00AE;\nL_0095:\n\tv50 = placementObject == 0;\n\tif (v50) goto L_00AE;\n\tv67 = *([placementObject @ X1 (System.Object)]) == System.String;\n\tif (v67) goto L_00B2;\nL_00AE:\n\treturn v160;\nL_00B2:\n\tv194 = System.String::ToString(placementObject);\n\tv195 = v194 == 0;\n\tif (v195) goto L_FFFFFFFF;\n\tv81 = IronSourceJSON.Json+Parser::Parse(v194);\n\tv235 = v81 == 0;\n\tv83 = ~v235;\n\tif (v83) goto L_002E;\n\tgoto L_00AE;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IronSourcePlacement getPlacementFromObject(object placementObject)
	{
		object obj = placementObject as IDictionary;
		object obj2;
		object result;
		if (obj != null)
		{
			bool flag = placementObject == null;
			obj2 = placementObject;
			result = placementObject;
			if (!flag)
			{
				goto IL_0037;
			}
		}
		else
		{
			bool flag2 = placementObject == null;
			result = placementObject;
			if (!flag2)
			{
				if ((object)placementObject.GetType() == typeof(string))
				{
					string text = ((string)placementObject).ToString();
					if (text != null)
					{
						object obj3 = Json.Parser.Parse(text);
						bool flag3 = obj3 == null;
						bool flag4 = !flag3;
						obj2 = obj3;
						if (flag4)
						{
							goto IL_0037;
						}
						result = obj3;
						goto IL_0233;
					}
				}
				goto IL_018b;
			}
		}
		goto IL_0233;
		IL_018b:
		result = null;
		goto IL_0233;
		IL_0233:
		return (IronSourcePlacement)result;
		IL_0037:
		Dictionary<string, object> dictionary = obj2 as Dictionary<string, object>;
		if (dictionary != null)
		{
			int count = ((Dictionary<string, object>)obj2).Count;
			if (count >= 1)
			{
				object obj4 = ((Dictionary<string, object>)obj2).get_Item("placement_reward_amount");
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v245 @ X8_v19+160] (should have been resolved before IL gen)");
				string value = default(string);
				int num = Convert.ToInt32(value);
				object obj6 = ((Dictionary<string, object>)obj2).get_Item("placement_reward_name");
				object obj7 = obj6;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v279 @ X8_v25+160] (should have been resolved before IL gen)");
				object obj8 = ((Dictionary<string, object>)obj2).get_Item("placement_name");
				object obj9 = obj8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v284 @ X8_v28+160] (should have been resolved before IL gen)");
				object obj10 = null;
				result = obj10;
				goto IL_0233;
			}
		}
		goto IL_018b;
	}

	[Token(Token = "0x6000141")]
	[Address(RVA = "0x159C894", Offset = "0x159C894", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceEvents()
	{
	}
}
