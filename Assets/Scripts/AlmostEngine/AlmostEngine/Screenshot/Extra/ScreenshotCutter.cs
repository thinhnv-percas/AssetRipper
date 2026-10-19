using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace AlmostEngine.Screenshot.Extra
{
	[ExecuteInEditMode]
	[Token(Token = "0x200006A")]
	public class ScreenshotCutter : MonoBehaviour
	{
		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x20")]
		public RectTransform m_SelectionArea;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x28")]
		public bool m_HideSelectionAreaDuringCapture;

		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x2C")]
		public int m_CropBorder;

		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x30")]
		private bool m_WasActive;

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0x3C49650", Offset = "0x3C49650", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv84 = v83 == 0;\n\tif (v84) goto L_0053;\n\tv88 = 0x21C11D0(v83, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv93 = v88 == 0;\n\tif (v93) goto L_00E1;\n\tv109.onResolutionUpdateStartDelegate = v88;\n\tv101 = 0x21C11D0(v83, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv103 = v101 == 0;\n\tif (v103) goto L_00E4;\n\tgoto L_005A;\nL_0053:\n\tv91.onResolutionUpdateStartDelegate = 0;\n\tv201 = System.Delegate::Combine(v135.onResolutionUpdateStartDelegate, v146);\n\tv222 = v201 == 0;\n\tif (v222) goto L_007C;\n\tv129 = 0x21C11D0(v201, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv132 = v129 == 0;\n\tif (v132) goto L_00E1;\n\tv267.onResolutionUpdateStartDelegate = v129;\n\tv160 = 0x21C11D0(v201, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = v160 == 0;\n\tif (v163) goto L_00E4;\n\tgoto L_0085;\nL_007C:\n\tv225.onResolutionUpdateStartDelegate = 0;\n\tv278 = System.Delegate::Remove(v136.onResolutionUpdateEndDelegate, v272);\n\tv279 = v278 == 0;\n\tif (v279) goto L_00A7;\n\tv130 = 0x21C11D0(v278, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv133 = v130 == 0;\n\tif (v133) goto L_00E1;\n\tv293.onResolutionUpdateEndDelegate = v130;\n\tv161 = 0x21C11D0(v278, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = v161 == 0;\n\tif (v164) goto L_00E4;\n\tgoto L_00AE;\nL_00A7:\n\tv282.onResolutionUpdateEndDelegate = 0;\n\tv303 = System.Delegate::Combine(v191.onResolutionUpdateEndDelegate, v298);\n\tv304 = v303 == 0;\n\tif (v304) goto L_00D0;\n\tv187 = 0x21C11D0(v303, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv189 = v187 == 0;\n\tif (v189) goto L_00E7;\n\tv315.onResolutionUpdateEndDelegate = v187;\n\tv211 = 0x21C11D0(v303, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv213 = v211 == 0;\n\tif (v213) goto L_00EA;\n\tgoto L_00DE;\nL_00D0:\n\tv307.onResolutionUpdateEndDelegate = 0;\nL_00E1:\n\tthrow System.InvalidCastException;\nL_00E4:\n\tthrow System.InvalidCastException;\nL_00E7:\n\tthrow System.InvalidCastException;\nL_00EA:\n\tthrow System.InvalidCastException;\nL_002B:\n\tgoto L_0031;\nL_005A:\n\tv146 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v146, this, Il2CppMethodInfo);\nL_0085:\n\tv272 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v272, this, Il2CppMethodInfo);\nL_00AE:\n\tv298 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v298, this, Il2CppMethodInfo);\nL_00DE:\n\treturn;\nL_0031:\n\tv70 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v70, this, Il2CppMethodInfo);\n\tv83 = System.Delegate::Remove(v67.onResolutionUpdateStartDelegate, v70);\n")]
		private void OnEnable()
		{
			UnityAction<ScreenshotResolution> value = StartCallback;
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
			UnityAction<ScreenshotResolution> b = StartCallback;
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
			UnityAction<ScreenshotResolution> value2 = EndCallback;
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
			UnityAction<ScreenshotResolution> b2 = EndCallback;
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

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0x3C49964", Offset = "0x3C49964", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv80 = v79 == 0;\n\tif (v80) goto L_0051;\n\tv84 = 0x21C11D0(v79, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = v84 == 0;\n\tif (v89) goto L_0096;\n\tv107.onResolutionUpdateStartDelegate = v84;\n\tv97 = 0x21C11D0(v79, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv99 = v97 == 0;\n\tif (v99) goto L_0099;\n\tgoto L_005A;\nL_0051:\n\tv87.onResolutionUpdateStartDelegate = 0;\n\tv152 = System.Delegate::Remove(v114.onResolutionUpdateEndDelegate, v117);\n\tv172 = v152 == 0;\n\tif (v172) goto L_0087;\n\tv139 = 0x21C11D0(v152, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv141 = v139 == 0;\n\tif (v141) goto L_009C;\n\tv211.onResolutionUpdateEndDelegate = v139;\n\tv161 = 0x21C11D0(v152, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = v161 == 0;\n\tif (v163) goto L_009F;\n\treturn;\nL_0087:\n\tv175.onResolutionUpdateEndDelegate = 0;\n\treturn;\nL_0096:\n\tthrow System.InvalidCastException;\nL_0099:\n\tthrow System.InvalidCastException;\nL_009C:\n\tthrow System.InvalidCastException;\nL_009F:\n\tthrow System.InvalidCastException;\nL_0029:\n\tgoto L_002F;\nL_005A:\n\tv117 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v117, this, Il2CppMethodInfo);\nL_002F:\n\tv66 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v66, this, Il2CppMethodInfo);\n\tv79 = System.Delegate::Remove(v63.onResolutionUpdateStartDelegate, v66);\n")]
		private void OnDisable()
		{
			UnityAction<ScreenshotResolution> value = StartCallback;
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
			UnityAction<ScreenshotResolution> value2 = EndCallback;
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

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0x3C49B64", Offset = "0x3C49B64", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.m_SelectionArea, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_003B;\n\tgoto L_004E;\nL_003B:\n\tv86 = this.m_HideSelectionAreaDuringCapture != 1;\n\tif (v86) goto L_004E;\n\tAlmostEngine.Screenshot.Extra.ScreenshotCutter::Hide(this);\n\treturn;\nL_004E:\n\treturn;\n")]
		private void StartCallback(ScreenshotResolution res)
		{
			if (!(m_SelectionArea == null) && m_HideSelectionAreaDuringCapture)
			{
				Hide();
			}
		}

		[Token(Token = "0x60001E5")]
		[Address(RVA = "0x3C49C7C", Offset = "0x3C49C7C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.m_SelectionArea, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0043;\n\treturn;\nL_0043:\n\tv99 = this.m_HideSelectionAreaDuringCapture != 1;\n\tif (v99) goto L_0059;\n\tv151 = UnityEngine.Component::get_gameObject(this.m_SelectionArea);\n\tUnityEngine.GameObject::SetActive(v151, this.m_WasActive);\nL_0059:\n\tAlmostEngine.Screenshot.Extra.ScreenshotCutter::CropScreenshot(res, this.m_SelectionArea, this.m_CropBorder);\n\treturn;\n")]
		private void EndCallback(ScreenshotResolution res)
		{
			if (!(m_SelectionArea == null))
			{
				if (m_HideSelectionAreaDuringCapture)
				{
					GameObject gameObject = m_SelectionArea.gameObject;
					gameObject.SetActive(m_WasActive);
				}
				CropScreenshot(res, m_SelectionArea, m_CropBorder);
			}
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0x3C49C20", Offset = "0x3C49C20", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_gameObject(this.m_SelectionArea);\n\tv42 = UnityEngine.GameObject::get_activeSelf(v15);\n\tthis.m_WasActive = v42;\n\tv26 = UnityEngine.Component::get_gameObject(this.m_SelectionArea);\n\tUnityEngine.GameObject::SetActive(v26, 0);\n\treturn;\n")]
		private void Hide()
		{
			GameObject gameObject = m_SelectionArea.gameObject;
			bool activeSelf = gameObject.activeSelf;
			m_WasActive = activeSelf;
			GameObject gameObject2 = m_SelectionArea.gameObject;
			gameObject2.SetActive(value: false);
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0x3C49D64", Offset = "0x3C49D64", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = UnityEngine.Component::get_gameObject(this.m_SelectionArea);\n\tUnityEngine.GameObject::SetActive(v15, this.m_WasActive);\n\treturn;\n")]
		private void Show()
		{
			GameObject gameObject = m_SelectionArea.gameObject;
			gameObject.SetActive(m_WasActive);
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x3C48EB8", Offset = "0x3C48EB8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_002B;\nL_002B:\n\tv68 = UnityEngine.Object::op_Equality(res.m_Texture, 0);\n\tv71 = ~v68;\n\tif (v71) goto L_0050;\nL_0036:\n\tgoto L_0043;\nL_0043:\n\tUnityEngine.Debug::LogError(\"Can not crop, null texture.\");\n\treturn;\nL_0050:\n\tv108 = AlmostEngine.Screenshot.Extra.ScreenshotCutter::CropTexture(res.m_Texture, selection, cropBorder);\n\tgoto L_005B;\nL_005B:\n\tUnityEngine.Object::DestroyImmediate(res.m_Texture);\n\tres.m_Texture = v108;\n\treturn;\nL_001E:\n\tv49 = res == 0;\n\tif (v49) goto L_0036;\n")]
		public static void CropScreenshot(ScreenshotResolution res, RectTransform selection, int cropBorder = 0)
		{
			if (res == null || res.m_Texture == null)
			{
				Debug.LogError("Can not crop, null texture.");
				return;
			}
			Texture2D texture = CropTexture(res.m_Texture, selection, cropBorder);
			UnityEngine.Object.DestroyImmediate(res.m_Texture);
			res.m_Texture = texture;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x3C49DA0", Offset = "0x3C49DA0", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tUnityEngine.RectTransform::GetWorldCorners(selection, v52);\n\tv187 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+30]) - *([v52 @ X0_v3 (UnityEngine.Vector3[])+24]);\n\tv191 = v187 == 0x7F800000;\n\tv199 = ~v191;\n\tif (v199) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv202 = 0xFFFFFFFF80000000;\n\tgoto L_004D;\nL_FFFFFFFF:\n\tv202 = v187;\nL_FFFFFFFF:\n\tv217 = 0xFFFFFFFF80000000;\n\tgoto L_0061;\nL_FFFFFFFF:\n\tv217 = v140;\nL_FFFFFFFF:\n\tv230 = 0xFFFFFFFF80000000;\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv230 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+24]);\nL_FFFFFFFF:\n\tv244 = 0xFFFFFFFF80000000;\n\tgoto L_0080;\nL_FFFFFFFF:\n\tv244 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+20]);\nL_FFFFFFFF:\n\tv268 = v252;\n\tgoto L_009E;\nL_FFFFFFFF:\n\tv268 = v245;\nL_FFFFFFFF:\n\tv284 = 0;\n\tgoto L_00B0;\nL_FFFFFFFF:\n\tv284 = v268;\nL_FFFFFFFF:\n\tv307 = v291;\n\tgoto L_00C9;\nL_FFFFFFFF:\n\tv307 = v231;\nL_FFFFFFFF:\n\tv323 = 0;\n\tgoto L_00DB;\nL_FFFFFFFF:\n\tv323 = v307;\nL_FFFFFFFF:\n\tv346 = v330;\n\tgoto L_00F4;\nL_FFFFFFFF:\n\tv346 = v218;\nL_FFFFFFFF:\n\tv362 = 0;\n\tgoto L_0106;\nL_FFFFFFFF:\n\tv362 = v346;\nL_FFFFFFFF:\n\tv144 = v368;\n\tgoto L_011F;\nL_FFFFFFFF:\n\tv144 = v203;\nL_FFFFFFFF:\n\tv130 = 0;\n\tgoto L_013A;\nL_FFFFFFFF:\n\tv130 = v144;\nL_001C:\n\t// 28 NewArr v52 @ X0_v3 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\nL_004D:\n\tv127 = cropBorder << 1;\n\tv203 = v202 - v127;\n\tv140 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+38]) - *([v52 @ X0_v3 (UnityEngine.Vector3[])+20]);\n\tv207 = v140 == 0x7F800000;\n\tv214 = ~v207;\n\tif (v214) goto L_FFFFFFFF;\nL_0061:\n\tv218 = v217 - v127;\n\tv220 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+24]) == 0x7F800000;\n\tv227 = ~v220;\n\tif (v227) goto L_FFFFFFFF;\nL_0070:\n\tv231 = v230 + cropBorder;\n\tv234 = *([v52 @ X0_v3 (UnityEngine.Vector3[])+20]) == 0x7F800000;\n\tv241 = ~v234;\n\tif (v241) goto L_FFFFFFFF;\nL_0080:\n\tv245 = v244 + cropBorder;\n\tv250 = UnityEngine.Texture::get_width(toCrop);\n\tv252 = v250 - 1;\n\tv254 = v245 < v252;\n\tv255 = v245 == v252;\n\tv258 = v245 == v245;\n\tv259 = v252 == v252;\n\tv260 = v258 & v259;\n\tv261 = ~v260;\n\tv262 = v254 == v261;\n\tv263 = ~v255;\n\tv264 = v262 & v263;\n\tv265 = ~v264;\n\tif (v265) goto L_FFFFFFFF;\nL_009E:\n\tv273 = v245 < 0;\n\tv276 = v245 ^ v245;\n\tv277 = v245 & v276;\n\tv278 = v277 < 0;\n\tv279 = v273 == v278;\n\tv280 = ~v279;\n\tv281 = ~v280;\n\tif (v281) goto L_FFFFFFFF;\nL_00B0:\n\tv289 = UnityEngine.Texture::get_height(toCrop);\n\tv291 = v289 - 1;\n\tv293 = v231 < v291;\n\tv294 = v231 == v291;\n\tv297 = v231 == v231;\n\tv298 = v291 == v291;\n\tv299 = v297 & v298;\n\tv300 = ~v299;\n\tv301 = v293 == v300;\n\tv302 = ~v294;\n\tv303 = v301 & v302;\n\tv304 = ~v303;\n\tif (v304) goto L_FFFFFFFF;\nL_00C9:\n\tv312 = v231 < 0;\n\tv315 = v231 ^ v231;\n\tv316 = v231 & v315;\n\tv317 = v316 < 0;\n\tv318 = v312 == v317;\n\tv319 = ~v318;\n\tv320 = ~v319;\n\tif (v320) goto L_FFFFFFFF;\nL_00DB:\n\tv328 = UnityEngine.Texture::get_width(toCrop);\n\tv330 = v328 - v284;\n\tv332 = v218 < v330;\n\tv333 = v218 == v330;\n\tv336 = v218 == v218;\n\tv337 = v330 == v330;\n\tv338 = v336 & v337;\n\tv339 = ~v338;\n\tv340 = v332 == v339;\n\tv341 = ~v333;\n\tv342 = v340 & v341;\n\tv343 = ~v342;\n\tif (v343) goto L_FFFFFFFF;\nL_00F4:\n\tv351 = v218 < 0;\n\tv354 = v218 ^ v218;\n\tv355 = v218 & v354;\n\tv356 = v355 < 0;\n\tv357 = v351 == v356;\n\tv358 = ~v357;\n\tv359 = ~v358;\n\tif (v359) goto L_FFFFFFFF;\nL_0106:\n\tv366 = UnityEngine.Texture::get_height(toCrop);\n\tv368 = v366 - v323;\n\tv369 = v203 < v368;\n\tv370 = v203 == v368;\n\tv373 = v203 == v203;\n\tv374 = v368 == v368;\n\tv375 = v373 & v374;\n\tv376 = ~v375;\n\tv377 = v369 == v376;\n\tv121 = ~v370;\n\tv378 = v377 & v121;\n\tv379 = ~v378;\n\tif (v379) goto L_FFFFFFFF;\nL_011F:\n\tv158 = v203 < 0;\n\tv152 = v203 ^ v203;\n\tv150 = v203 & v152;\n\tv148 = v150 < 0;\n\tv383 = v158 == v148;\n\tv146 = ~v383;\n\tv132 = ~v146;\n\tif (v132) goto L_FFFFFFFF;\nL_013A:\n\treturnVal2 = AlmostEngine.Screenshot.Extra.ScreenshotCutter::CropTexture(toCrop, v284, v323, v362, v130);\n\treturn returnVal2;\n")]
		public static Texture2D CropTexture(Texture2D toCrop, RectTransform selection, int cropBorder = 0)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotCutter::CropTexture");
			return default;
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0x3C49F74", Offset = "0x3C49F74", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tv59 = UnityEngine.Texture2D::get_format(toCrop);\n\tv107 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v107, width, height, v59, 0);\n\tv176 = width < 3;\n\treturnVal2 = 0;\n\tif (v176) goto L_0062;\n\tv61 = height < 3;\n\treturnVal2 = 0;\n\tif (v61) goto L_0062;\n\tv100 = UnityEngine.Texture2D::GetPixels(toCrop, x0, y0, width, height);\n\tUnityEngine.Texture2D::SetPixels(v107, v100);\n\tUnityEngine.Texture2D::Apply(v107);\n\treturnVal2 = v107;\nL_0062:\n\treturn returnVal2;\n")]
		public static Texture2D CropTexture(Texture2D toCrop, int x0, int y0, int width, int height)
		{
			TextureFormat format = toCrop.format;
			Texture2D texture2D = new Texture2D(width, height, format, mipChain: false);
			bool flag = width < 3;
			Texture2D result = null;
			if (!flag)
			{
				bool flag2 = height < 3;
				result = null;
				if (!flag2)
				{
					Color[] pixels = toCrop.GetPixels(x0, y0, width, height);
					texture2D.SetPixels(pixels);
					texture2D.Apply();
					result = texture2D;
				}
			}
			return result;
		}

		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x3C4A070", Offset = "0x3C4A070", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_CropBorder = 1;\n\tthis.m_WasActive = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ScreenshotCutter()
		{
			m_CropBorder = 1;
			m_WasActive = true;
		}
	}
}
