using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace AlmostEngine.Screenshot.Extra
{
	[ExecuteInEditMode]
	[Token(Token = "0x200006C")]
	public class ScreenshotRotation : MonoBehaviour
	{
		[Token(Token = "0x60001EF")]
		[Address(RVA = "0x3C4A230", Offset = "0x3C4A230", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv81 = v80 == 0;\n\tif (v81) goto L_0050;\n\tv85 = 0x21C11D0(v80, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = v85 == 0;\n\tif (v90) goto L_008A;\n\tv106.onResolutionUpdateEndDelegate = v85;\n\tv98 = 0x21C11D0(v80, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v98 == 0;\n\tif (v100) goto L_008D;\n\tgoto L_0057;\nL_0050:\n\tv88.onResolutionUpdateEndDelegate = 0;\n\tv151 = System.Delegate::Combine(v113.onResolutionUpdateEndDelegate, v116);\n\tv171 = v151 == 0;\n\tif (v171) goto L_0079;\n\tv138 = 0x21C11D0(v151, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv140 = v138 == 0;\n\tif (v140) goto L_0090;\n\tv212.onResolutionUpdateEndDelegate = v138;\n\tv160 = 0x21C11D0(v151, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv162 = v160 == 0;\n\tif (v162) goto L_0093;\n\tgoto L_0087;\nL_0079:\n\tv174.onResolutionUpdateEndDelegate = 0;\nL_008A:\n\tthrow System.InvalidCastException;\nL_008D:\n\tthrow System.InvalidCastException;\nL_0090:\n\tthrow System.InvalidCastException;\nL_0093:\n\tthrow System.InvalidCastException;\nL_0028:\n\tgoto L_002E;\nL_0057:\n\tv116 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v116, this, Il2CppMethodInfo);\nL_0087:\n\treturn;\nL_002E:\n\tv70 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v70, this, Il2CppMethodInfo);\n\tv80 = System.Delegate::Remove(v67.onResolutionUpdateEndDelegate, v70);\n")]
		private void OnEnable()
		{
			UnityAction<ScreenshotResolution> value = EndCallback;
			Delegate obj = Delegate.Remove(ScreenshotTaker.onResolutionUpdateEndDelegate, value);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction = default(UnityAction<ScreenshotResolution>);
				if (unityAction == null)
				{
					throw new InvalidCastException();
				}
				ScreenshotTaker.onResolutionUpdateEndDelegate = unityAction;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateEndDelegate = null;
			}
			UnityAction<ScreenshotResolution> b = EndCallback;
			Delegate obj3 = Delegate.Combine(ScreenshotTaker.onResolutionUpdateEndDelegate, b);
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

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0x3C4A410", Offset = "0x3C4A410", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv77 = v76 == 0;\n\tif (v77) goto L_0059;\n\tv81 = 0x21C11D0(v76, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = v81 == 0;\n\tif (v96) goto L_0068;\n\tv98.onResolutionUpdateEndDelegate = v81;\n\tv103 = 0x21C11D0(v76, UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv123 = v103 == 0;\n\tif (v123) goto L_006B;\n\treturn;\nL_0059:\n\tv84.onResolutionUpdateEndDelegate = 0;\n\treturn;\nL_0068:\n\tthrow System.InvalidCastException;\nL_006B:\n\tthrow System.InvalidCastException;\nL_0026:\n\tgoto L_002C;\nL_002C:\n\tv66 = new UnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tUnityEngine.Events.UnityAction`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v66, this, Il2CppMethodInfo);\n\tv76 = System.Delegate::Remove(v63.onResolutionUpdateEndDelegate, v66);\n")]
		private void OnDisable()
		{
			UnityAction<ScreenshotResolution> value = EndCallback;
			Delegate obj = Delegate.Remove(ScreenshotTaker.onResolutionUpdateEndDelegate, value);
			if ((object)obj != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				UnityAction<ScreenshotResolution> unityAction = default(UnityAction<ScreenshotResolution>);
				if (unityAction == null)
				{
					throw new InvalidCastException();
				}
				ScreenshotTaker.onResolutionUpdateEndDelegate = unityAction;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj2 = default(object);
				if (obj2 == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				ScreenshotTaker.onResolutionUpdateEndDelegate = null;
			}
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0x3C4A554", Offset = "0x3C4A554", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.Extra.ScreenshotRotation::RotateScreenshotLeft(res);\n\treturn;\n")]
		private void EndCallback(ScreenshotResolution res)
		{
			RotateScreenshotLeft(res);
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0x3C494C0", Offset = "0x3C494C0", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_0027;\nL_0027:\n\tv62 = UnityEngine.Object::op_Equality(res.m_Texture, 0);\n\tv65 = ~v62;\n\tif (v65) goto L_0052;\nL_0031:\n\tgoto L_003B;\nL_003B:\n\tUnityEngine.Debug::LogError(\"Can not rotate, null texture.\");\n\treturn;\nL_0052:\n\tv104 = AlmostEngine.Screenshot.Extra.ScreenshotRotation::RotateTextureRight(res.m_Texture);\n\tgoto L_005D;\nL_005D:\n\tUnityEngine.Object::DestroyImmediate(res.m_Texture);\n\tres.m_Texture = v104;\n\treturn;\nL_001A:\n\tv43 = res == 0;\n\tif (v43) goto L_0031;\n")]
		public static void RotateScreenshotRight(ScreenshotResolution res)
		{
			if (res == null || res.m_Texture == null)
			{
				Debug.LogError("Can not rotate, null texture.");
				return;
			}
			Texture2D texture = RotateTextureRight(res.m_Texture);
			UnityEngine.Object.DestroyImmediate(res.m_Texture);
			res.m_Texture = texture;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0x3C4A55C", Offset = "0x3C4A55C", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv64 = UnityEngine.Texture::get_height(tex);\n\tv70 = UnityEngine.Texture::get_width(tex);\n\tv74 = UnityEngine.Texture2D::get_format(tex);\n\tv174 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v174, v64, v70, v74, 0);\n\tv158 = UnityEngine.Texture2D::GetPixels(tex);\n\t// 68 NewArr v297 @ X0_v17 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v158.Length\n\tv302 = UnityEngine.Texture::get_width(tex);\n\tv313 = v302 < 1;\n\tif (v313) goto L_00EE;\n\tv161 = v297 == 0;\n\tif (v161) goto L_FFFFFFFF;\n\tv188 = v158 + 0x20;\n\tv186 = v297 + 0x20;\nL_FFFFFFFF:\n\tv184 = -1;\nL_FFFFFFFF:\n\tv190 = 0;\n\tgoto L_0074;\nL_005E:\n\tv190 = v190 + 1;\n\tv343 = UnityEngine.Texture::get_width(tex);\n\tv184 = v184 - 1;\n\tv320 = v190 >= v343;\n\tif (v320) goto L_00EE;\nL_0074:\n\tv378 = UnityEngine.Texture::get_height(tex);\n\tv389 = v378 < 1;\n\tif (v389) goto L_005E;\nL_FFFFFFFF:\n\tv239 = 0;\n\tv496 = v184 + v486;\n\tv235 = v491 * v496;\n\tv230 = v239 + v235;\n\t*([v186 @ X27_v5+v230 @ X9_v21 (System.Int32)*16]) = *([v188 @ X26_v5+v237 @ X8_v24 (System.Int32)*16]);\n\tv239 = v239 + 1;\n\tv445 = UnityEngine.Texture::get_height(tex);\n\tv423 = v239 < v445;\n\tif (v423) goto L_0086;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv168 = 0;\n\tv168 = v168 + 1;\n\tv342 = UnityEngine.Texture::get_width(tex);\n\tv319 = v168 < v342;\n\tif (v319) goto L_00C8;\nL_00EE:\n\tUnityEngine.Texture2D::SetPixels(v174, v297);\n\tUnityEngine.Texture2D::Apply(v174);\n\treturn v174;\nL_0105:\n\tv458 = UnityEngine.Texture::get_width(tex);\n\tv463 = UnityEngine.Texture::get_height(tex);\n\tv157 = UnityEngine.Texture::get_width(tex);\n\tv172 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\nL_0086:\n\tv486 = UnityEngine.Texture::get_width(tex);\n\tv491 = UnityEngine.Texture::get_height(tex);\n\tv232 = UnityEngine.Texture::get_width(tex);\n\tv234 = v232 * v239;\n\tv237 = v190 + v234;\nL_00C8:\n\tv408 = UnityEngine.Texture::get_height(tex);\n\tv95 = v408 > 0;\n\tif (v95) goto L_0105;\n")]
		public static Texture2D RotateTextureRight(Texture2D tex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotRotation::RotateTextureRight");
			return default;
		}

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0x3C49394", Offset = "0x3C49394", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tgoto L_0027;\nL_0027:\n\tv62 = UnityEngine.Object::op_Equality(res.m_Texture, 0);\n\tv65 = ~v62;\n\tif (v65) goto L_0052;\nL_0031:\n\tgoto L_003B;\nL_003B:\n\tUnityEngine.Debug::LogError(\"Can not rotate, null texture.\");\n\treturn;\nL_0052:\n\tv104 = AlmostEngine.Screenshot.Extra.ScreenshotRotation::RotateTextureLeft(res.m_Texture);\n\tgoto L_005D;\nL_005D:\n\tUnityEngine.Object::DestroyImmediate(res.m_Texture);\n\tres.m_Texture = v104;\n\treturn;\nL_001A:\n\tv43 = res == 0;\n\tif (v43) goto L_0031;\n")]
		public static void RotateScreenshotLeft(ScreenshotResolution res)
		{
			if (res == null || res.m_Texture == null)
			{
				Debug.LogError("Can not rotate, null texture.");
				return;
			}
			Texture2D texture = RotateTextureLeft(res.m_Texture);
			UnityEngine.Object.DestroyImmediate(res.m_Texture);
			res.m_Texture = texture;
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0x3C4A7F4", Offset = "0x3C4A7F4", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0025:\n\tv64 = UnityEngine.Texture::get_height(tex);\n\tv70 = UnityEngine.Texture::get_width(tex);\n\tv74 = UnityEngine.Texture2D::get_format(tex);\n\tv174 = new UnityEngine.Texture2D();\n\tUnityEngine.Texture2D::.ctor(v174, v64, v70, v74, 0);\n\tv158 = UnityEngine.Texture2D::GetPixels(tex);\n\t// 68 NewArr v297 @ X0_v17 (UnityEngine.Color[]), typeof(UnityEngine.Color[]), v158.Length\n\tv302 = UnityEngine.Texture::get_width(tex);\n\tv313 = v302 < 1;\n\tif (v313) goto L_00EE;\n\tv161 = v297 == 0;\n\tif (v161) goto L_FFFFFFFF;\n\tv188 = v158 + 0x20;\n\tv186 = v297 + 0x20;\nL_FFFFFFFF:\n\tv190 = 0;\n\tgoto L_0072;\nL_005D:\n\tv190 = v190 + 1;\n\tv343 = UnityEngine.Texture::get_width(tex);\n\tv320 = v190 >= v343;\n\tif (v320) goto L_00EE;\nL_0072:\n\tv378 = UnityEngine.Texture::get_height(tex);\n\tv389 = v378 < 1;\n\tif (v389) goto L_005D;\nL_FFFFFFFF:\n\tv184 = 0;\nL_FFFFFFFF:\n\tv239 = -1;\n\tv235 = v190 * v488;\n\tv498 = v493 + v235;\n\tv230 = v239 + v498;\n\t*([v186 @ X27_v5+v230 @ X9_v21 (System.Int32)*16]) = *([v188 @ X26_v5+v237 @ X8_v24 (System.Int32)*16]);\n\tv184 = v184 + 1;\n\tv447 = UnityEngine.Texture::get_height(tex);\n\tv239 = v239 - 1;\n\tv425 = v184 < v447;\n\tif (v425) goto L_0085;\n\tgoto L_005D;\nL_FFFFFFFF:\n\tv168 = 0;\n\tv168 = v168 + 1;\n\tv342 = UnityEngine.Texture::get_width(tex);\n\tv319 = v168 < v342;\n\tif (v319) goto L_00C8;\nL_00EE:\n\tUnityEngine.Texture2D::SetPixels(v174, v297);\n\tUnityEngine.Texture2D::Apply(v174);\n\treturn v174;\nL_0105:\n\tv460 = UnityEngine.Texture::get_height(tex);\n\tv465 = UnityEngine.Texture::get_height(tex);\n\tv157 = UnityEngine.Texture::get_width(tex);\n\tv172 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\nL_0085:\n\tv488 = UnityEngine.Texture::get_height(tex);\n\tv493 = UnityEngine.Texture::get_height(tex);\n\tv232 = UnityEngine.Texture::get_width(tex);\n\tv234 = v232 * v184;\n\tv237 = v190 + v234;\nL_00C8:\n\tv408 = UnityEngine.Texture::get_height(tex);\n\tv95 = v408 > 0;\n\tif (v95) goto L_0105;\n")]
		public static Texture2D RotateTextureLeft(Texture2D tex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotRotation::RotateTextureLeft");
			return default;
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x3C4AA8C", Offset = "0x3C4AA8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ScreenshotRotation()
		{
		}
	}
}
