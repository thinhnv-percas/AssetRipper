using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace AlmostEngine.Screenshot.Extra
{
	[ExecuteInEditMode]
	[Token(Token = "0x200005E")]
	public class HideOnCapture : MonoBehaviour
	{
		[Token(Token = "0x60001C1")]
		[Address(RVA = "0x3C47B0C", Offset = "0x3C47B0C", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv84 = v83 == 0;\n\tif (v84) goto L_0053;\n\tv88 = 0x21C11D0(v83, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv93 = v88 == 0;\n\tif (v93) goto L_00E1;\n\tv109.onResolutionUpdateStartDelegate = v88;\n\tv101 = 0x21C11D0(v83, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv103 = v101 == 0;\n\tif (v103) goto L_00E4;\n\tgoto L_005A;\nL_0053:\n\tv91.onResolutionUpdateStartDelegate = 0;\n\tv201 = System.Delegate::Combine(v135.onResolutionUpdateStartDelegate, v146);\n\tv222 = v201 == 0;\n\tif (v222) goto L_007C;\n\tv129 = 0x21C11D0(v201, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv132 = v129 == 0;\n\tif (v132) goto L_00E1;\n\tv267.onResolutionUpdateStartDelegate = v129;\n\tv160 = 0x21C11D0(v201, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = v160 == 0;\n\tif (v163) goto L_00E4;\n\tgoto L_0085;\nL_007C:\n\tv225.onResolutionUpdateStartDelegate = 0;\n\tv278 = System.Delegate::Remove(v136.onResolutionUpdateEndDelegate, v272);\n\tv279 = v278 == 0;\n\tif (v279) goto L_00A7;\n\tv130 = 0x21C11D0(v278, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv133 = v130 == 0;\n\tif (v133) goto L_00E1;\n\tv293.onResolutionUpdateEndDelegate = v130;\n\tv161 = 0x21C11D0(v278, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = v161 == 0;\n\tif (v164) goto L_00E4;\n\tgoto L_00AE;\nL_00A7:\n\tv282.onResolutionUpdateEndDelegate = 0;\n\tv303 = System.Delegate::Combine(v191.onResolutionUpdateEndDelegate, v298);\n\tv304 = v303 == 0;\n\tif (v304) goto L_00D0;\n\tv187 = 0x21C11D0(v303, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv189 = v187 == 0;\n\tif (v189) goto L_00E7;\n\tv315.onResolutionUpdateEndDelegate = v187;\n\tv211 = 0x21C11D0(v303, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = v211 == 0;\n\tif (v213) goto L_00EA;\n\tgoto L_00DE;\nL_00D0:\n\tv307.onResolutionUpdateEndDelegate = 0;\nL_00E1:\n\tthrow System.InvalidCastException;\nL_00E4:\n\tthrow System.InvalidCastException;\nL_00E7:\n\tthrow System.InvalidCastException;\nL_00EA:\n\tthrow System.InvalidCastException;\nL_002B:\n\tgoto L_0031;\nL_005A:\n\tv146 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v146, this, Il2CppMethodInfo);\nL_0085:\n\tv272 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v272, this, Il2CppMethodInfo);\nL_00AE:\n\tv298 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v298, this, Il2CppMethodInfo);\nL_00DE:\n\treturn;\nL_0031:\n\tv70 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v70, this, Il2CppMethodInfo);\n\tv83 = System.Delegate::Remove(v67.onResolutionUpdateStartDelegate, v70);\n")]
		private void OnEnable()
		{
			UnityAction<ScreenshotResolution> value = Hide;
			Delegate obj = Delegate.Remove(ScreenshotTaker.onResolutionUpdateStartDelegate, value);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction = default(UnityAction<ScreenshotResolution>);
				if (unityAction == null)
				{
					goto IL_0253;
				}
				ScreenshotTaker.onResolutionUpdateStartDelegate = unityAction;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					goto IL_0259;
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateStartDelegate = null;
			}
			UnityAction<ScreenshotResolution> b = Hide;
			Delegate obj3 = Delegate.Combine(ScreenshotTaker.onResolutionUpdateStartDelegate, b);
			if ((object)obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction2 = default(UnityAction<ScreenshotResolution>);
				if (unityAction2 == null)
				{
					goto IL_0253;
				}
				ScreenshotTaker.onResolutionUpdateStartDelegate = unityAction2;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_0259;
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateStartDelegate = null;
			}
			UnityAction<ScreenshotResolution> value2 = Show;
			Delegate obj5 = Delegate.Remove(ScreenshotTaker.onResolutionUpdateEndDelegate, value2);
			if ((object)obj5 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction3 = default(UnityAction<ScreenshotResolution>);
				if (unityAction3 == null)
				{
					goto IL_0253;
				}
				ScreenshotTaker.onResolutionUpdateEndDelegate = unityAction3;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj6 = default(object);
				if (obj6 == null)
				{
					goto IL_0259;
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateEndDelegate = null;
			}
			UnityAction<ScreenshotResolution> b2 = Show;
			Delegate obj7 = Delegate.Combine(ScreenshotTaker.onResolutionUpdateEndDelegate, b2);
			if ((object)obj7 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction4 = default(UnityAction<ScreenshotResolution>);
				if (unityAction4 == null)
				{
					throw new InvalidCastException();
				}
				ScreenshotTaker.onResolutionUpdateEndDelegate = unityAction4;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj8 = default(object);
				if (obj8 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateEndDelegate = null;
			}
			return;
			IL_0259:
			throw new InvalidCastException();
			IL_0253:
			throw new InvalidCastException();
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0x3C47E20", Offset = "0x3C47E20", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv80 = v79 == 0;\n\tif (v80) goto L_0051;\n\tv84 = 0x21C11D0(v79, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = v84 == 0;\n\tif (v89) goto L_0096;\n\tv107.onResolutionUpdateStartDelegate = v84;\n\tv97 = 0x21C11D0(v79, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = v97 == 0;\n\tif (v99) goto L_0099;\n\tgoto L_005A;\nL_0051:\n\tv87.onResolutionUpdateStartDelegate = 0;\n\tv152 = System.Delegate::Remove(v114.onResolutionUpdateEndDelegate, v117);\n\tv172 = v152 == 0;\n\tif (v172) goto L_0087;\n\tv139 = 0x21C11D0(v152, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = v139 == 0;\n\tif (v141) goto L_009C;\n\tv211.onResolutionUpdateEndDelegate = v139;\n\tv161 = 0x21C11D0(v152, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = v161 == 0;\n\tif (v163) goto L_009F;\n\treturn;\nL_0087:\n\tv175.onResolutionUpdateEndDelegate = 0;\n\treturn;\nL_0096:\n\tthrow System.InvalidCastException;\nL_0099:\n\tthrow System.InvalidCastException;\nL_009C:\n\tthrow System.InvalidCastException;\nL_009F:\n\tthrow System.InvalidCastException;\nL_0029:\n\tgoto L_002F;\nL_005A:\n\tv117 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v117, this, Il2CppMethodInfo);\nL_002F:\n\tv66 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v66, this, Il2CppMethodInfo);\n\tv79 = System.Delegate::Remove(v63.onResolutionUpdateStartDelegate, v66);\n")]
		private void OnDestroy()
		{
			UnityAction<ScreenshotResolution> value = Hide;
			Delegate obj = Delegate.Remove(ScreenshotTaker.onResolutionUpdateStartDelegate, value);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction = default(UnityAction<ScreenshotResolution>);
				if (unityAction == null)
				{
					throw new InvalidCastException();
				}
				ScreenshotTaker.onResolutionUpdateStartDelegate = unityAction;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateStartDelegate = null;
			}
			UnityAction<ScreenshotResolution> value2 = Show;
			Delegate obj3 = Delegate.Remove(ScreenshotTaker.onResolutionUpdateEndDelegate, value2);
			if ((object)obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction2 = default(UnityAction<ScreenshotResolution>);
				if (unityAction2 == null)
				{
					throw new InvalidCastException();
				}
				ScreenshotTaker.onResolutionUpdateEndDelegate = unityAction2;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateEndDelegate = null;
			}
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0x3C48020", Offset = "0x3C48020", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v7, 0);\n\treturn;\n")]
		private void Hide(ScreenshotResolution res)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: false);
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x3C48048", Offset = "0x3C48048", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = UnityEngine.Component::get_gameObject(this);\n\tUnityEngine.GameObject::SetActive(v7, 1);\n\treturn;\n")]
		private void Show(ScreenshotResolution res)
		{
			GameObject gameObject = base.gameObject;
			gameObject.SetActive(value: true);
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0x3C48070", Offset = "0x3C48070", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public HideOnCapture()
		{
		}
	}
}
