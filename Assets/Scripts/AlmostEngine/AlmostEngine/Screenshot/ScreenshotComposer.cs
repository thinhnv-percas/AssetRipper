using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000011")]
	public class ScreenshotComposer : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x2000012")]
		private sealed class _003CCaptureCompositionCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400003B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400003C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400003D")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotComposer _003C_003E4__this;

			[Token(Token = "0x400003E")]
			[FieldOffset(Offset = "0x28")]
			public ScreenshotResolution desiredCaptureResolution;

			[Token(Token = "0x17000001")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000027")]
				[Address(RVA = "0x3C2FD64", Offset = "0x3C2FD64", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000002")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000029")]
				[Address(RVA = "0x3C2FDAC", Offset = "0x3C2FDAC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x3C2F968", Offset = "0x3C2F968", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureCompositionCoroutine_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x3C2FA2C", Offset = "0x3C2FA2C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000026")]
			[Address(RVA = "0x3C2FA30", Offset = "0x3C2FA30", Length = "0x238")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv65 = this.<>1__state != 1;\n\tif (v65) goto L_00B5;\n\tv133 = -1;\n\tgoto L_00B0;\nL_0037:\n\tv66 = this.<>4__this;\n\tthis.<>1__state = -1;\n\tv161 = new System.Collections.Generic.List`1<UnityEngine.Camera>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::.ctor(v161);\n\tgoto L_006B;\nL_006B:\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::Add(v161, v66.m_Camera);\n\tv220 = new System.Collections.Generic.List`1<UnityEngine.Canvas>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Canvas>::.ctor(v220);\n\tgoto L_0099;\nL_0099:\n\tSystem.Collections.Generic.List`1<UnityEngine.Canvas>::Add(v220, v66.m_Canvas);\n\tv327 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureResolutionCoroutine(v66.m_ScreenshotTaker, this.desiredCaptureResolution, v161, v220, 0, 8, 0, 0, 0);\n\tv331 = UnityEngine.MonoBehaviour::StartCoroutine(v66.m_ScreenshotTaker, v327);\n\tthis.<>2__current = v331;\n\tv133 = 1;\nL_0028:\n\tv52 = this.<>1__state == 0;\n\tif (v52) goto L_0037;\nL_00B5:\n\tv140 = this.<>1__state == 0;\n\treturn v140;\nL_00B0:\n\tthis.<>1__state = v133;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				int num;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_0158;
					}
					num = -1;
				}
				else
				{
					ScreenshotComposer screenshotComposer = _003C_003E4__this;
					_003C_003E1__state = -1;
					List<Camera> cameras = new List<Camera> { screenshotComposer.m_Camera };
					List<Canvas> canvas = new List<Canvas> { screenshotComposer.m_Canvas };
					IEnumerator routine = screenshotComposer.m_ScreenshotTaker.CaptureResolutionCoroutine(desiredCaptureResolution, cameras, canvas, default(ScreenshotTaker.CaptureMode), 8, captureGameUI: false);
					Coroutine coroutine = screenshotComposer.m_ScreenshotTaker.StartCoroutine(routine);
					_003C_003E2__current = coroutine;
					num = 1;
				}
				_003C_003E1__state = num;
				goto IL_0158;
				IL_0158:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x3C2FD6C", Offset = "0x3C2FD6C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000013")]
		private sealed class _003CCaptureCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400003F")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotComposer _003C_003E4__this;

			[Token(Token = "0x4000042")]
			[FieldOffset(Offset = "0x28")]
			public ScreenshotResolution desiredCaptureResolution;

			[Token(Token = "0x4000043")]
			[FieldOffset(Offset = "0x30")]
			public List<ScreenshotCamera> cameras;

			[Token(Token = "0x4000044")]
			[FieldOffset(Offset = "0x38")]
			public List<ScreenshotOverlay> overlays;

			[Token(Token = "0x4000045")]
			[FieldOffset(Offset = "0x40")]
			public ScreenshotTaker.CaptureMode captureMode;

			[Token(Token = "0x4000046")]
			[FieldOffset(Offset = "0x44")]
			public int antiAliasing;

			[Token(Token = "0x4000047")]
			[FieldOffset(Offset = "0x48")]
			public bool captureGameUI;

			[Token(Token = "0x4000048")]
			[FieldOffset(Offset = "0x4C")]
			public ScreenshotTaker.ColorFormat colorFormat;

			[Token(Token = "0x4000049")]
			[FieldOffset(Offset = "0x50")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x400004A")]
			[FieldOffset(Offset = "0x51")]
			public bool stopTime;

			[Token(Token = "0x400004B")]
			[FieldOffset(Offset = "0x52")]
			public bool restore;

			[Token(Token = "0x400004C")]
			[FieldOffset(Offset = "0x53")]
			public bool forceUICulling;

			[Token(Token = "0x400004D")]
			[FieldOffset(Offset = "0x54")]
			public bool disableHDRPFX;

			[Token(Token = "0x400004E")]
			[FieldOffset(Offset = "0x58")]
			private List<RawImage>.Enumerator _003C_003E7__wrap1;

			[Token(Token = "0x17000003")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600002E")]
				[Address(RVA = "0x3C30208", Offset = "0x3C30208", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000004")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000030")]
				[Address(RVA = "0x3C30250", Offset = "0x3C30250", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x3C2F658", Offset = "0x3C2F658", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureCoroutine_003Ed__4(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x3C2FDB4", Offset = "0x3C2FDB4", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = v76.<>1__state - 1;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tv15 = v76.<>1__state - -3;\n\tv30 = v15 == 0;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv30 = 1;\n\tgoto L_0037;\nL_0043:\n\treturn;\nL_001C:\n\tv34 = ~v30;\n\tif (v34) goto L_0043;\nL_0037:\n\tv76.<>1__state = -1;\n\tv83 = v76 + 0x58;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v83);\n\treturn;\n")]
			unsafe void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotComposer._003CCaptureCoroutine_003Ed__4::Dispose");
			}

			[Token(Token = "0x600002C")]
			[Address(RVA = "0x3C2FE2C", Offset = "0x3C2FE2C", Length = "0x380")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv61 = this.<>4__this;\n\tv66 = this.<>1__state == 1;\nL_FFFFFFFF:\n\tv115 = this;\n\tif (v66) goto L_006C;\n\tv76 = this.<>1__state == 0;\n\tv77 = ~v76;\nL_FFFFFFFF:\n\tv123 = 0;\n\tif (v77) goto L_FFFFFFFF;\n\tthis.<>1__state = -1;\n\tgoto L_004A;\nL_004A:\n\tv314 = UnityEngine.Object::FindObjectOfType();\n\tv409 = this.<>4__this == 0;\n\tif (v409) goto L_00E7;\n\tv61.m_ScreenshotTaker = v314;\n\tv112 = v61.m_Textures == 0;\n\tif (v112) goto L_00E9;\n\tv465 = System.Collections.Generic.List`1<UnityEngine.UI.RawImage>::GetEnumerator(v61.m_Textures);\n\t*([v465 @ X0_v68 (System.Collections.Generic.List`1<UnityEngine.UI.RawImage>+Enumerator<UnityEngine.UI.RawImage>)+58]) = v465._list;\n\t*([v465 @ X0_v68 (System.Collections.Generic.List`1<UnityEngine.UI.RawImage>+Enumerator<UnityEngine.UI.RawImage>)+68]) = v465.Current;\nL_FFFFFFFF:\n\tv115 = v465;\n\tv315 = this.<>4__this == 0;\n\tif (v315) goto L_00EB;\n\tv416 = AlmostEngine.Screenshot.ScreenshotComposer::CaptureInnerTextureCoroutine(this.<>4__this, *([v45 @ stack_-38_v2+68]), *([v45 @ stack_-38_v2+28]), *([v45 @ stack_-38_v2+30]), *([v45 @ stack_-38_v2+38]), *([v45 @ stack_-38_v2+40]), *([v45 @ stack_-38_v2+44]), *([v45 @ stack_-38_v2+48]));\n\tv229 = v61.m_ScreenshotTaker == 0;\n\tif (v229) goto L_00EF;\n\tv436 = UnityEngine.MonoBehaviour::StartCoroutine(v61.m_ScreenshotTaker, v416);\n\tv447 = v45 + 0x18;\n\t*([v447 @ X0_v49]) = v436;\n\t*([v45 @ stack_-38_v2+10]) = 1;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0112;\nL_009D:\n\tthis.<>1__state = -1;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0112;\nL_00A5:\n\tgoto L_00AE;\n\tgoto L_00C8;\n\tv475.desiredCaptureResolution = *([v45 @ stack_-38_v2+28]);\n\tv489 = UnityEngine.MonoBehaviour::StartCoroutine(v61.m_ScreenshotTaker, v475);\n\tv491 = v45 + 0x18;\n\t*([v491 @ X0_v33]) = v489;\n\t*([v45 @ stack_-38_v2+10]) = 2;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0112;\nL_00E7:\n\tv434 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv281 = v133;\n\tgoto L_00F2;\nL_00E9:\n\tv441 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv281 = v314;\nL_FFFFFFFF:\n\tv441 = v434;\n\tgoto L_00F2;\nL_00EB:\n\tv418 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv281 = v314;\n\tgoto L_00F2;\nL_00ED:\n\tv441 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv281 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv441 = v418;\n\tgoto L_00F2;\nL_00EF:\n\tv437 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv281 = Il2CppMethodInfo;\n\tgoto L_00F2;\nL_00F2:\n\t// 242 Interrupt\n\tgoto L_0109;\nL_0109:\n\tv255 = v281 != 1;\nL_FFFFFFFF:\n\tv123 = 0;\nL_FFFFFFFF:\n\tv402 = v441;\n\tif (v255) goto L_0124;\n\tv478 = 0x8BF5BC4(v441, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv291 = 0x8BF5BF4(v478, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv123 = *([v478 @ X0_v56]);\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\treturn returnVal1;\nL_011D:\n\tv304 = &v45 @ stack_-38_v2;\n\tv306 = 0x3177498(*([v304 @ X8_v7]), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv407 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv402 = v407;\n\treturn returnVal2;\nL_0029:\n\tv53 = this.<>1__state == 2;\n\tif (v53) goto L_009D;\nL_006C:\n\tv115.<>1__state = -3;\n\tv121 = v115 + 0x58;\n\tv122 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(v121);\n\tv297 = v122 == 0;\n\tif (v297) goto L_00A5;\nL_0112:\n\tv242 = v123 == 0;\n\tv243 = ~v242;\n\tif (v243) goto L_011D;\nL_00AE:\n\t*([v45 @ stack_-38_v2+10]) = -1;\n\tv429 = v45 + 0x58;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v429);\n\t*([v45 @ stack_-38_v2+60]) = 0;\n\t*([v45 @ stack_-38_v2+68]) = 0;\n\t*([v45 @ stack_-38_v2+58]) = 0;\n\tv439 = this.<>4__this == 0;\n\tif (v439) goto L_00ED;\nL_00C8:\n\tv475 = new AlmostEngine.Screenshot.ScreenshotComposer+<CaptureCompositionCoroutine>d__9();\n\tSystem.Object::.ctor(v475);\n\tv475.<>4__this = this.<>4__this;\n\tv475.<>1__state = 0;\nL_0124:\n\tv444 = 0x3176E00(&v123 @ stack_-48_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv460 = 0x8BF0368(v402, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v460, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotComposer._003CCaptureCoroutine_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x600002D")]
			[Address(RVA = "0x3C301AC", Offset = "0x3C301AC", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.<>1__state = -1;\n\tv46 = this + 0x58;\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v46);\n\treturn;\n")]
			private unsafe void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotComposer._003CCaptureCoroutine_003Ed__4::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x3C30210", Offset = "0x3C30210", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000014")]
		private sealed class _003CCaptureInnerTextureCoroutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400004F")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000050")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000051")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotComposer _003C_003E4__this;

			[Token(Token = "0x4000052")]
			[FieldOffset(Offset = "0x28")]
			public RawImage texture;

			[Token(Token = "0x4000053")]
			[FieldOffset(Offset = "0x30")]
			public ScreenshotResolution desiredCaptureResolution;

			[Token(Token = "0x4000054")]
			[FieldOffset(Offset = "0x38")]
			public List<ScreenshotCamera> cameras;

			[Token(Token = "0x4000055")]
			[FieldOffset(Offset = "0x40")]
			public List<ScreenshotOverlay> overlays;

			[Token(Token = "0x4000056")]
			[FieldOffset(Offset = "0x48")]
			public ScreenshotTaker.CaptureMode captureMode;

			[Token(Token = "0x4000057")]
			[FieldOffset(Offset = "0x4C")]
			public int antiAliasing;

			[Token(Token = "0x4000058")]
			[FieldOffset(Offset = "0x50")]
			public bool captureGameUI;

			[Token(Token = "0x4000059")]
			[FieldOffset(Offset = "0x54")]
			public ScreenshotTaker.ColorFormat colorFormat;

			[Token(Token = "0x400005A")]
			[FieldOffset(Offset = "0x58")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x400005B")]
			[FieldOffset(Offset = "0x59")]
			public bool stopTime;

			[Token(Token = "0x400005C")]
			[FieldOffset(Offset = "0x5A")]
			public bool restore;

			[Token(Token = "0x400005D")]
			[FieldOffset(Offset = "0x5B")]
			public bool forceUICulling;

			[Token(Token = "0x400005E")]
			[FieldOffset(Offset = "0x5C")]
			public bool disableHDRPFX;

			[Token(Token = "0x400005F")]
			[FieldOffset(Offset = "0x60")]
			private ScreenshotResolution _003CtempRes_003E5__2;

			[Token(Token = "0x17000005")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000034")]
				[Address(RVA = "0x3C30808", Offset = "0x3C30808", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000006")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000036")]
				[Address(RVA = "0x3C30850", Offset = "0x3C30850", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x3C2F7C8", Offset = "0x3C2F7C8", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureInnerTextureCoroutine_003Ed__5(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x3C30258", Offset = "0x3C30258", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000033")]
			[Address(RVA = "0x3C3025C", Offset = "0x3C3025C", Length = "0x2F0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv56 = this.<>4__this;\n\tv61 = this.<>1__state == 1;\n\tif (v61) goto L_0051;\n\tv72 = this.<>1__state == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0091;\n\tthis.<>1__state = -1;\n\tv179 = new AlmostEngine.Screenshot.ScreenshotResolution();\n\tAlmostEngine.Screenshot.ScreenshotResolution::.ctor(v179);\n\tthis.<tempRes>5__2 = v179;\n\tv166 = this.desiredCaptureResolution;\n\tv281 = v166.m_IgnoreOrientation == 0;\n\tif (v281) goto L_0093;\nL_FFFFFFFF:\n\tv309 = 0x14;\n\tgoto L_00A7;\nL_0051:\n\tthis.<>1__state = -1;\n\tv154 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v154);\n\tgoto L_0117;\nL_007F:\n\tthis.<>1__state = -1;\n\tv67 = this.<tempRes>5__2;\n\tUnityEngine.UI.RawImage::set_texture(this.texture, v67.m_Texture);\nL_0091:\n\treturn 0;\nL_0093:\n\tv293 = v166.m_Orientation < 2;\n\tv294 = ~v293;\n\tv304 = ~v294;\n\tv305 = ~v304;\n\tif (v305) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv309 = 0x14;\n\tgoto L_00A7;\nL_FFFFFFFF:\n\tv309 = 0x18;\n\tgoto L_00B8;\nL_FFFFFFFF:\n\tv347 = 1f;\nL_FFFFFFFF:\n\tv101 = 0xFFFFFFFF80000000;\n\tgoto L_00CD;\nL_FFFFFFFF:\n\tv101 = v348;\nL_FFFFFFFF:\n\tv383 = 0x18;\n\tgoto L_00E6;\nL_00D2:\n\tv369 = v166.m_Orientation < 2;\n\tv370 = ~v369;\n\tv380 = ~v370;\n\tv381 = ~v380;\n\tif (v381) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv383 = 0x18;\n\tgoto L_00E6;\nL_FFFFFFFF:\n\tv383 = 0x14;\nL_FFFFFFFF:\n\tv90 = 0xFFFFFFFF80000000;\n\tgoto L_00FD;\nL_FFFFFFFF:\n\tv90 = v92;\n\tv403 = UnityEngine.MonoBehaviour::StartCoroutine(v56.m_ScreenshotTaker, v156);\n\tthis.<>2__current = v403;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_0117:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v154, this.<tempRes>5__2);\n\tv337 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureAllCoroutine(v56.m_ScreenshotTaker, v154, this.cameras, this.overlays, this.captureMode, this.antiAliasing, this.captureGameUI, this.colorFormat, this.recomputeAlphaMask, v338, v339, v340, this.disableHDRPFX);\n\tv346 = UnityEngine.MonoBehaviour::StartCoroutine(v56.m_ScreenshotTaker, v337);\n\tthis.<>2__current = v346;\n\tthis.<>1__state = 2;\n\treturn 1;\nL_0022:\n\tv48 = this.<>1__state == 2;\n\tif (v48) goto L_007F;\nL_00A7:\n\tv347 = v166.m_Scale;\n\tv323 = v166.m_Scale < 0;\n\tv324 = v166.m_Scale == 0;\n\tv327 = v166.m_Scale == v166.m_Scale;\n\tv328 = ~v327;\n\tv330 = v323 == v328;\n\tv80 = ~v324;\n\tv331 = v330 & v80;\n\tv332 = ~v331;\n\tif (v332) goto L_FFFFFFFF;\nL_00B8:\n\tv348 = v347 * *([v166 @ X8_v25 (AlmostEngine.Screenshot.ScreenshotResolution)+v309 @ X10_v3 (System.Int32)]);\n\tv352 = v348 == 0x7F800000;\n\tv359 = ~v352;\n\tif (v359) goto L_FFFFFFFF;\nL_00CD:\n\tv366 = v166.m_IgnoreOrientation == 0;\n\tif (v366) goto L_00D2;\nL_00E6:\n\tv92 = v347 * *([v166 @ X8_v25 (AlmostEngine.Screenshot.ScreenshotResolution)+v383 @ X9_v7 (System.Int32)]);\n\tv142 = v92 == 0x7F800000;\n\tv95 = ~v142;\n\tif (v95) goto L_FFFFFFFF;\nL_00FD:\n\tv156 = AlmostEngine.Screenshot.ScreenshotComposer::ComputeInnerTextureSizeCoroutine(v56, this.texture, v101, v90, this.<tempRes>5__2);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				//IL_048c: Expected I4, but got F4
				//IL_048c: Expected I4, but got F4
				if (_003C_003E1__state != 2)
				{
					ScreenshotComposer screenshotComposer = _003C_003E4__this;
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						List<ScreenshotResolution> resolutions = new List<ScreenshotResolution> { _003CtempRes_003E5__2 };
						bool flag = default(bool);
						bool flag2 = default(bool);
						bool forceUICullingLayer = default(bool);
						IEnumerator routine = screenshotComposer.m_ScreenshotTaker.CaptureAllCoroutine(resolutions, cameras, overlays, captureMode, antiAliasing, captureGameUI, colorFormat, recomputeAlphaMask, flag, flag2, forceUICullingLayer, disableHDRPFX);
						Coroutine coroutine = screenshotComposer.m_ScreenshotTaker.StartCoroutine(routine);
						_003C_003E2__current = coroutine;
						_003C_003E1__state = 2;
						return true;
					}
					if (_003C_003E1__state == 0)
					{
						_003C_003E1__state = -1;
						ScreenshotResolution screenshotResolution = new ScreenshotResolution();
						_003CtempRes_003E5__2 = screenshotResolution;
						ScreenshotResolution screenshotResolution2 = desiredCaptureResolution;
						if (screenshotResolution2.m_IgnoreOrientation)
						{
							int num = 20;
						}
						else if ((uint)screenshotResolution2.m_Orientation < 2u)
						{
							int num = 20;
						}
						else
						{
							int num = 24;
						}
						float num2 = screenshotResolution2.m_Scale;
						bool flag3 = screenshotResolution2.m_Scale < 0f;
						bool flag4 = screenshotResolution2.m_Scale == 0f;
						bool flag5 = screenshotResolution2.m_Scale == screenshotResolution2.m_Scale;
						bool flag6 = !flag5;
						bool flag7 = flag3 == flag6;
						bool flag8 = !flag4;
						if (!(flag7 && flag8))
						{
							num2 = 1f;
						}
						float num3 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v25 (AlmostEngine.Screenshot.ScreenshotResolution)+v309 @ X10_v3 (System.Int32)]");
						float num4 = num3 * 0f;
						float num5 = ((num4 != 1f / 0f) ? num4 : -0f);
						if (screenshotResolution2.m_IgnoreOrientation)
						{
							int num6 = 24;
						}
						else if ((uint)screenshotResolution2.m_Orientation < 2u)
						{
							int num6 = 24;
						}
						else
						{
							int num6 = 20;
						}
						float num7 = num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X8_v25 (AlmostEngine.Screenshot.ScreenshotResolution)+v383 @ X9_v7 (System.Int32)]");
						float num8 = num7 * 0f;
						float num9 = ((num8 != 1f / 0f) ? num8 : -0f);
						IEnumerator routine2 = screenshotComposer.ComputeInnerTextureSizeCoroutine(texture, (int)num5, (int)num9, _003CtempRes_003E5__2);
						Coroutine coroutine2 = screenshotComposer.m_ScreenshotTaker.StartCoroutine(routine2);
						_003C_003E2__current = coroutine2;
						_003C_003E1__state = 1;
						return true;
					}
				}
				else
				{
					_003C_003E1__state = -1;
					ScreenshotResolution screenshotResolution3 = _003CtempRes_003E5__2;
					texture.texture = screenshotResolution3.m_Texture;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x3C30810", Offset = "0x3C30810", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000015")]
		private sealed class _003CComputeInnerTextureSizeCoroutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000060")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000061")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000062")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotComposer _003C_003E4__this;

			[Token(Token = "0x4000063")]
			[FieldOffset(Offset = "0x28")]
			public int compositionWidth;

			[Token(Token = "0x4000064")]
			[FieldOffset(Offset = "0x2C")]
			public int compositionHeight;

			[Token(Token = "0x4000065")]
			[FieldOffset(Offset = "0x30")]
			public RawImage image;

			[Token(Token = "0x4000066")]
			[FieldOffset(Offset = "0x38")]
			public ScreenshotResolution resolution;

			[Token(Token = "0x4000067")]
			[FieldOffset(Offset = "0x40")]
			private int _003Cf_003E5__2;

			[Token(Token = "0x17000007")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600003A")]
				[Address(RVA = "0x3C30D14", Offset = "0x3C30D14", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000008")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600003C")]
				[Address(RVA = "0x3C30D5C", Offset = "0x3C30D5C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x3C2F8B0", Offset = "0x3C2F8B0", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CComputeInnerTextureSizeCoroutine_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x3C30858", Offset = "0x3C30858", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000039")]
			[Address(RVA = "0x3C3085C", Offset = "0x3C3085C", Length = "0x2FC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv61 = this.<>1__state == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_0122;\n\tthis.<>1__state = -1;\n\tv207 = UnityEngine.Component::get_gameObject(v51.m_Canvas);\n\tUnityEngine.GameObject::SetActive(v207, 1);\n\tgoto L_004B;\nL_004F:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available  for Editor and Windows Standalone.\");\n\tthis.<f>5__2 = 0;\nL_FFFFFFFF:\n\tv147 = 0;\n\tgoto L_0064;\nL_0054:\n\tthis.<>1__state = -1;\n\tv147 = this.<f>5__2 + 1;\n\tthis.<f>5__2 = v147;\nL_0064:\n\tv85 = v147 >= v51.resizeframe;\n\tif (v85) goto L_009F;\n\tgoto L_007A;\nL_0080:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.\");\n\tv308 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v308);\n\tthis.<>2__current = v308;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_009F:\n\tv209 = UnityEngine.UI.Graphic::get_rectTransform(this.image);\n\tv169 = UnityEngine.RectTransform::get_rect(v209);\n\tv113 = this.resolution;\n\tv211 = UnityEngine.UI.Graphic::get_rectTransform(this.image);\n\tv170 = UnityEngine.Transform::get_lossyScale(v211);\n\tv333 = v169.width * v170;\n\tv171 = v333 * v51.supersampleCoeff;\n\tv183 = v171 == 0x7F800000;\n\tv158 = ~v183;\n\tif (v158) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv230 = 0xFFFFFFFF80000000;\n\tgoto L_00CC;\nL_FFFFFFFF:\n\tv230 = v171;\n\tv233 = this.resolution;\n\tv212 = UnityEngine.UI.Graphic::get_rectTransform(this.image);\n\tv172 = UnityEngine.Transform::get_lossyScale(v212);\n\tv341 = v169.height * v172.y;\n\tv79 = v341 * v51.supersampleCoeff;\n\tv96 = v79 == 0x7F800000;\n\tv70 = ~v96;\n\tif (v70) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv231 = 0xFFFFFFFF80000000;\n\tgoto L_00F0;\nL_FFFFFFFF:\n\tv231 = v79;\n\tv213 = UnityEngine.Component::get_gameObject(v51.m_Canvas);\n\tUnityEngine.GameObject::SetActive(v213, 0);\n\tgoto L_0111;\nL_0115:\n\tUnityEngine.Debug::LogError(\"GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.\");\nL_0122:\n\treturn 0;\nL_0019:\n\tv51 = this.<>4__this;\n\tv56 = this.<>1__state == 1;\n\tif (v56) goto L_0054;\nL_004B:\n\tgoto L_004F;\nL_007A:\n\tgoto L_0080;\nL_00CC:\n\tv113.m_Width = v230;\nL_00F0:\n\tv233.m_Height = v231;\nL_0111:\n\tgoto L_0115;\n")]
			private bool MoveNext()
			{
				//IL_0301: Expected I4, but got F4
				//IL_0313: Expected I4, but got F4
				ScreenshotComposer screenshotComposer = _003C_003E4__this;
				int num;
				if (_003C_003E1__state != 1)
				{
					if (_003C_003E1__state != 0)
					{
						goto IL_02bb;
					}
					_003C_003E1__state = -1;
					GameObject gameObject = screenshotComposer.m_Canvas.gameObject;
					gameObject.SetActive(value: true);
					Debug.LogError("GAMEVIEW_RESIZING capture mode is only available  for Editor and Windows Standalone.");
					_003Cf_003E5__2 = 0;
					num = 0;
				}
				else
				{
					_003C_003E1__state = -1;
					num = ++_003Cf_003E5__2;
				}
				if (num < screenshotComposer.resizeframe)
				{
					Debug.LogError("GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.");
					WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
					_003C_003E2__current = waitForEndOfFrame;
					_003C_003E1__state = 1;
					return true;
				}
				RectTransform rectTransform = image.rectTransform;
				Rect rect = rectTransform.rect;
				ScreenshotResolution screenshotResolution = resolution;
				RectTransform rectTransform2 = image.rectTransform;
				Vector3 lossyScale = rectTransform2.lossyScale;
				float num2 = rect.width * lossyScale.x;
				float num3 = num2 * screenshotComposer.supersampleCoeff;
				float num4 = ((num3 != 1f / 0f) ? num3 : -0f);
				screenshotResolution.m_Width = (int)num4;
				ScreenshotResolution screenshotResolution2 = resolution;
				RectTransform rectTransform3 = image.rectTransform;
				Vector3 lossyScale2 = rectTransform3.lossyScale;
				float num5 = rect.height * lossyScale2.y;
				float num6 = num5 * screenshotComposer.supersampleCoeff;
				float num7 = ((num6 != 1f / 0f) ? num6 : -0f);
				screenshotResolution2.m_Height = (int)num7;
				GameObject gameObject2 = screenshotComposer.m_Canvas.gameObject;
				gameObject2.SetActive(value: false);
				Debug.LogError("GAMEVIEW_RESIZING capture mode is only available for Editor and Windows Standalone.");
				goto IL_02bb;
				IL_02bb:
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x3C30D1C", Offset = "0x3C30D1C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Tooltip("The UI camera to be used to render the canvas.")]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x20")]
		public Camera m_Camera;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x28")]
		public Canvas m_Canvas;

		[Tooltip("The list of rawimage containing a game screenshot.")]
		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x30")]
		public List<RawImage> m_Textures;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x38")]
		private ScreenshotTaker m_ScreenshotTaker;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x40")]
		protected float supersampleCoeff;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x44")]
		protected int resizeframe;

		[IteratorStateMachine(typeof(_003CCaptureCoroutine_003Ed__4))]
		[Token(Token = "0x600001F")]
		[Address(RVA = "0x3C2F52C", Offset = "0x3C2F52C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv76.desiredCaptureResolution = desiredCaptureResolution;\n\tv76.cameras = cameras;\n\tv76.overlays = overlays;\n\tv76.captureMode = captureMode;\n\tv76.antiAliasing = antiAliasing;\n\tv76.captureGameUI = captureGameUI;\n\tv76.colorFormat = colorFormat;\n\tv76.recomputeAlphaMask = recomputeAlphaMask;\n\tv76.stopTime = stopTime;\n\tv76.restore = restore;\n\tv76.forceUICulling = forceUICulling;\n\tv76.disableHDRPFX = disableHDRPFX;\n\treturn v76;\nL_002B:\n\tv76 = new AlmostEngine.Screenshot.ScreenshotComposer+<CaptureCoroutine>d__4();\n\tSystem.Object::.ctor(v76);\n\tv76.<>1__state = 0;\n\tv76.<>4__this = this;\n")]
		public virtual IEnumerator CaptureCoroutine(ScreenshotResolution desiredCaptureResolution, List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, ScreenshotTaker.CaptureMode captureMode, int antiAliasing = 8, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool stopTime = false, bool restore = true, bool forceUICulling = false, bool disableHDRPFX = true)
		{
			_003CCaptureCoroutine_003Ed__4 _003CCaptureCoroutine_003Ed__5 = (_003CCaptureCoroutine_003Ed__4)FormatterServices.GetUninitializedObject(typeof(_003CCaptureCoroutine_003Ed__4));
			_003CCaptureCoroutine_003Ed__5._003C_003E1__state = 0;
			_003CCaptureCoroutine_003Ed__5._003C_003E4__this = this;
			_003CCaptureCoroutine_003Ed__5.desiredCaptureResolution = desiredCaptureResolution;
			_003CCaptureCoroutine_003Ed__5.cameras = cameras;
			_003CCaptureCoroutine_003Ed__5.overlays = overlays;
			_003CCaptureCoroutine_003Ed__5.captureMode = captureMode;
			_003CCaptureCoroutine_003Ed__5.antiAliasing = antiAliasing;
			_003CCaptureCoroutine_003Ed__5.captureGameUI = captureGameUI;
			_003CCaptureCoroutine_003Ed__5.colorFormat = colorFormat;
			_003CCaptureCoroutine_003Ed__5.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureCoroutine_003Ed__5.stopTime = stopTime;
			_003CCaptureCoroutine_003Ed__5.restore = restore;
			_003CCaptureCoroutine_003Ed__5.forceUICulling = forceUICulling;
			_003CCaptureCoroutine_003Ed__5.disableHDRPFX = disableHDRPFX;
			return _003CCaptureCoroutine_003Ed__5;
		}

		[IteratorStateMachine(typeof(_003CCaptureInnerTextureCoroutine_003Ed__5))]
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x3C2F684", Offset = "0x3C2F684", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv79.texture = texture;\n\tv79.desiredCaptureResolution = desiredCaptureResolution;\n\tv79.cameras = cameras;\n\tv79.overlays = overlays;\n\tv79.captureMode = captureMode;\n\tv79.antiAliasing = antiAliasing;\n\tv79.captureGameUI = captureGameUI;\n\tv79.colorFormat = colorFormat;\n\tv79.recomputeAlphaMask = recomputeAlphaMask;\n\tv79.stopTime = stopTime;\n\tv79.restore = restore;\n\tv79.forceUICulling = forceUICulling;\n\tv79.disableHDRPFX = disableHDRPFX;\n\treturn v79;\nL_002D:\n\tv79 = new AlmostEngine.Screenshot.ScreenshotComposer+<CaptureInnerTextureCoroutine>d__5();\n\tSystem.Object::.ctor(v79);\n\tv79.<>1__state = 0;\n\tv79.<>4__this = this;\n")]
		public virtual IEnumerator CaptureInnerTextureCoroutine(RawImage texture, ScreenshotResolution desiredCaptureResolution, List<ScreenshotCamera> cameras, List<ScreenshotOverlay> overlays, ScreenshotTaker.CaptureMode captureMode, int antiAliasing = 8, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool stopTime = false, bool restore = true, bool forceUICulling = false, bool disableHDRPFX = true)
		{
			_003CCaptureInnerTextureCoroutine_003Ed__5 _003CCaptureInnerTextureCoroutine_003Ed__6 = (_003CCaptureInnerTextureCoroutine_003Ed__5)FormatterServices.GetUninitializedObject(typeof(_003CCaptureInnerTextureCoroutine_003Ed__5));
			_003CCaptureInnerTextureCoroutine_003Ed__6._003C_003E1__state = 0;
			_003CCaptureInnerTextureCoroutine_003Ed__6._003C_003E4__this = this;
			_003CCaptureInnerTextureCoroutine_003Ed__6.texture = texture;
			_003CCaptureInnerTextureCoroutine_003Ed__6.desiredCaptureResolution = desiredCaptureResolution;
			_003CCaptureInnerTextureCoroutine_003Ed__6.cameras = cameras;
			_003CCaptureInnerTextureCoroutine_003Ed__6.overlays = overlays;
			_003CCaptureInnerTextureCoroutine_003Ed__6.captureMode = captureMode;
			_003CCaptureInnerTextureCoroutine_003Ed__6.antiAliasing = antiAliasing;
			_003CCaptureInnerTextureCoroutine_003Ed__6.captureGameUI = captureGameUI;
			_003CCaptureInnerTextureCoroutine_003Ed__6.colorFormat = colorFormat;
			_003CCaptureInnerTextureCoroutine_003Ed__6.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureInnerTextureCoroutine_003Ed__6.stopTime = stopTime;
			_003CCaptureInnerTextureCoroutine_003Ed__6.restore = restore;
			_003CCaptureInnerTextureCoroutine_003Ed__6.forceUICulling = forceUICulling;
			_003CCaptureInnerTextureCoroutine_003Ed__6.disableHDRPFX = disableHDRPFX;
			return _003CCaptureInnerTextureCoroutine_003Ed__6;
		}

		[IteratorStateMachine(typeof(_003CComputeInnerTextureSizeCoroutine_003Ed__8))]
		[Token(Token = "0x6000021")]
		[Address(RVA = "0x3C2F7F4", Offset = "0x3C2F7F4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv57.image = image;\n\tv57.compositionWidth = compositionWidth;\n\tv57.compositionHeight = compositionHeight;\n\tv57.resolution = resolution;\n\treturn v57;\nL_001F:\n\tv57 = new AlmostEngine.Screenshot.ScreenshotComposer+<ComputeInnerTextureSizeCoroutine>d__8();\n\tSystem.Object::.ctor(v57);\n\tv57.<>1__state = 0;\n\tv57.<>4__this = this;\n")]
		public virtual IEnumerator ComputeInnerTextureSizeCoroutine(RawImage image, int compositionWidth, int compositionHeight, ScreenshotResolution resolution)
		{
			_003CComputeInnerTextureSizeCoroutine_003Ed__8 _003CComputeInnerTextureSizeCoroutine_003Ed__9 = (_003CComputeInnerTextureSizeCoroutine_003Ed__8)FormatterServices.GetUninitializedObject(typeof(_003CComputeInnerTextureSizeCoroutine_003Ed__8));
			_003CComputeInnerTextureSizeCoroutine_003Ed__9._003C_003E1__state = 0;
			_003CComputeInnerTextureSizeCoroutine_003Ed__9._003C_003E4__this = this;
			_003CComputeInnerTextureSizeCoroutine_003Ed__9.image = image;
			_003CComputeInnerTextureSizeCoroutine_003Ed__9.compositionWidth = compositionWidth;
			_003CComputeInnerTextureSizeCoroutine_003Ed__9.compositionHeight = compositionHeight;
			_003CComputeInnerTextureSizeCoroutine_003Ed__9.resolution = resolution;
			return _003CComputeInnerTextureSizeCoroutine_003Ed__9;
		}

		[IteratorStateMachine(typeof(_003CCaptureCompositionCoroutine_003Ed__9))]
		[Token(Token = "0x6000022")]
		[Address(RVA = "0x3C2F8DC", Offset = "0x3C2F8DC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.desiredCaptureResolution = desiredCaptureResolution;\n\treturn v46;\nL_0018:\n\tv46 = new AlmostEngine.Screenshot.ScreenshotComposer+<CaptureCompositionCoroutine>d__9();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.<>4__this = this;\n")]
		public IEnumerator CaptureCompositionCoroutine(ScreenshotResolution desiredCaptureResolution)
		{
			_003CCaptureCompositionCoroutine_003Ed__9 _003CCaptureCompositionCoroutine_003Ed__10 = (_003CCaptureCompositionCoroutine_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CCaptureCompositionCoroutine_003Ed__9));
			_003CCaptureCompositionCoroutine_003Ed__10._003C_003E1__state = 0;
			_003CCaptureCompositionCoroutine_003Ed__10._003C_003E4__this = this;
			_003CCaptureCompositionCoroutine_003Ed__10.desiredCaptureResolution = desiredCaptureResolution;
			return _003CCaptureCompositionCoroutine_003Ed__10;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0x3C2F994", Offset = "0x3C2F994", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tthis.supersampleCoeff = 1.25f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.UI.RawImage>();\n\tSystem.Collections.Generic.List`1<UnityEngine.UI.RawImage>::.ctor(v48);\n\tthis.m_Textures = v48;\n")]
		public ScreenshotComposer()
		{
			List<RawImage> textures = new List<RawImage>();
			m_Textures = textures;
			supersampleCoeff = 1.25f;
		}
	}
}
