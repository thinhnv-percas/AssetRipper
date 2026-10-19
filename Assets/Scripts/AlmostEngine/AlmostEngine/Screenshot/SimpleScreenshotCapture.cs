using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using Debug = UnityEngine.Debug;

namespace AlmostEngine.Screenshot
{
	[Token(Token = "0x2000042")]
	public static class SimpleScreenshotCapture
	{
		[CompilerGenerated]
		[Token(Token = "0x2000043")]
		private sealed class _003C_003Ec__DisplayClass11_0
		{
			[Token(Token = "0x40001B2")]
			[FieldOffset(Offset = "0x10")]
			public string fileName;

			[Token(Token = "0x600014C")]
			[Address(RVA = "0x3C414FC", Offset = "0x3C414FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass11_0()
			{
			}

			internal void _003CCaptureToFileCoroutine_003Eb__0()
			{
				string message = "Screenshot created : " + fileName;
				Debug.Log(message);
			}

			internal void _003CCaptureToFileCoroutine_003Eb__1()
			{
				string message = "Failed to create screenshot : " + fileName;
				Debug.LogError(message);
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000044")]
		private sealed class _003CCaptureScreenToTextureCoroutine_003Ed__9 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001B3")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001B4")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001B5")]
			[FieldOffset(Offset = "0x20")]
			public ScreenshotTaker.ColorFormat colorFormat;

			[Token(Token = "0x40001B6")]
			[FieldOffset(Offset = "0x28")]
			public UnityAction<Texture2D> onTextureCaptured;

			[Token(Token = "0x17000025")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000152")]
				[Address(RVA = "0x3C41758", Offset = "0x3C41758", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000026")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000154")]
				[Address(RVA = "0x3C417A0", Offset = "0x3C417A0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600014F")]
			[Address(RVA = "0x3C41388", Offset = "0x3C41388", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureScreenToTextureCoroutine_003Ed__9(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000150")]
			[Address(RVA = "0x3C4164C", Offset = "0x3C4164C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000151")]
			[Address(RVA = "0x3C41650", Offset = "0x3C41650", Length = "0x108")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv56 = this.<>1__state != 1;\n\tif (v56) goto L_003E;\n\tthis.<>1__state = -1;\n\tgoto L_0031;\nL_0031:\n\tv105 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureScreenToTexture(this.colorFormat);\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Texture2D>::Invoke(this.onTextureCaptured, v105);\nL_004D:\n\tthis.<>1__state = -1;\n\tv61 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v61);\n\tthis.<>2__current = v61;\n\tthis.<>1__state = 1;\n\tv127 = this.<>1__state == 0;\n\treturn v127;\nL_0018:\n\tv44 = this.<>1__state == 0;\n\tif (v44) goto L_004D;\nL_003E:\n\tv88 = this.<>1__state == 0;\n\treturn v88;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						Texture2D arg = ScreenshotTaker.CaptureScreenToTexture(colorFormat);
						onTextureCaptured(arg);
					}
					return _003C_003E1__state == 0;
				}
				_003C_003E1__state = -1;
				WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
				_003C_003E2__current = waitForEndOfFrame;
				_003C_003E1__state = 1;
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000153")]
			[Address(RVA = "0x3C41760", Offset = "0x3C41760", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000045")]
		private sealed class _003CCaptureToFileCoroutine_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001B7")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001B8")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001B9")]
			[FieldOffset(Offset = "0x20")]
			public string fileName;

			[Token(Token = "0x40001BA")]
			[FieldOffset(Offset = "0x28")]
			public int width;

			[Token(Token = "0x40001BB")]
			[FieldOffset(Offset = "0x2C")]
			public int height;

			[Token(Token = "0x40001BC")]
			[FieldOffset(Offset = "0x30")]
			public List<Camera> cameras;

			[Token(Token = "0x40001BD")]
			[FieldOffset(Offset = "0x38")]
			public List<Canvas> canvas;

			[Token(Token = "0x40001BE")]
			[FieldOffset(Offset = "0x40")]
			public ScreenshotTaker.CaptureMode captureMode;

			[Token(Token = "0x40001BF")]
			[FieldOffset(Offset = "0x44")]
			public int antiAliasing;

			[Token(Token = "0x40001C0")]
			[FieldOffset(Offset = "0x48")]
			public bool captureGameUI;

			[Token(Token = "0x40001C1")]
			[FieldOffset(Offset = "0x4C")]
			public ScreenshotTaker.ColorFormat colorFormat;

			[Token(Token = "0x40001C2")]
			[FieldOffset(Offset = "0x50")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x40001C3")]
			[FieldOffset(Offset = "0x58")]
			private _003C_003Ec__DisplayClass11_0 _003C_003E8__1;

			[Token(Token = "0x40001C4")]
			[FieldOffset(Offset = "0x60")]
			public TextureExporter.ImageFileFormat fileFormat;

			[Token(Token = "0x40001C5")]
			[FieldOffset(Offset = "0x64")]
			public int JPGQuality;

			[Token(Token = "0x40001C6")]
			[FieldOffset(Offset = "0x68")]
			public bool exportToGallery;

			[Token(Token = "0x40001C7")]
			[FieldOffset(Offset = "0x69")]
			public bool exportAsync;

			[Token(Token = "0x17000027")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000158")]
				[Address(RVA = "0x3C41A18", Offset = "0x3C41A18", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000028")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600015A")]
				[Address(RVA = "0x3C41A60", Offset = "0x3C41A60", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000155")]
			[Address(RVA = "0x3C414D0", Offset = "0x3C414D0", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureToFileCoroutine_003Ed__11(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000156")]
			[Address(RVA = "0x3C417A8", Offset = "0x3C417A8", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000157")]
			[Address(RVA = "0x3C417AC", Offset = "0x3C417AC", Length = "0x26C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv73 = this.<>1__state != 1;\n\tif (v73) goto L_00B4;\n\tthis.<>1__state = -1;\n\tv87 = v86.m_ScreenshotTaker;\n\tv193 = this.<>8__1;\n\tv256 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v256, this.<>8__1, Il2CppMethodInfo);\n\tv266 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v266, this.<>8__1, Il2CppMethodInfo);\n\tv151 = AlmostEngine.Screenshot.TextureExporter::ExportToFile(v87.m_Texture, v193.fileName, this.fileFormat, this.JPGQuality, this.exportToGallery, this.exportAsync, v256, v266);\n\tgoto L_00B4;\nL_0069:\n\tthis.<>1__state = -1;\n\tv78 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<>c__DisplayClass11_0();\n\tSystem.Object::.ctor(v78);\n\tthis.<>8__1 = v78;\n\tv208 = this.<>8__1;\n\tv208.fileName = this.fileName;\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::InitScreenshotTaker();\n\tgoto L_0094;\n\tv285.canvas = this.canvas;\n\tv285.captureMode = this.captureMode;\n\tv285.captureGameUI = this.captureGameUI;\n\tv285.colorFormat = this.colorFormat;\n\tv285.recomputeAlphaMask = this.recomputeAlphaMask;\n\tv285.exportToGallery = 1;\n\tthis.<>2__current = v285;\n\tthis.<>1__state = 1;\nL_0029:\n\tv60 = this.<>1__state == 0;\n\tif (v60) goto L_0069;\nL_00B4:\n\tv168 = this.<>1__state == 0;\n\treturn v168;\nL_0094:\n\tv285 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureToTextureCoroutine>d__10();\n\tSystem.Object::.ctor(v285);\n\tv285.<>1__state = 0;\n\tv285.width = this.width;\n\tv285.cameras = this.cameras;\n")]
			private bool MoveNext()
			{
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state == 1)
					{
						_003C_003E1__state = -1;
						ScreenshotTaker screenshotTaker = m_ScreenshotTaker;
						_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_1 = _003C_003E8__1;
						UnityAction onExportSuccess = delegate
						{
							string message = "Screenshot created : " + _003C_003E8__1.fileName;
							Debug.Log(message);
						};
						UnityAction onExportFailure = delegate
						{
							string message = "Failed to create screenshot : " + _003C_003E8__1.fileName;
							Debug.LogError(message);
						};
						bool flag = TextureExporter.ExportToFile(screenshotTaker.m_Texture, _003C_003Ec__DisplayClass11_1.fileName, fileFormat, JPGQuality, exportToGallery, exportAsync, onExportSuccess, onExportFailure);
					}
				}
				else
				{
					_003C_003E1__state = -1;
					_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_2 = new _003C_003Ec__DisplayClass11_0();
					_003C_003E8__1 = _003C_003Ec__DisplayClass11_2;
					_003C_003Ec__DisplayClass11_0 _003C_003Ec__DisplayClass11_3 = _003C_003E8__1;
					_003C_003Ec__DisplayClass11_3.fileName = fileName;
					InitScreenshotTaker();
					_003CCaptureToTextureCoroutine_003Ed__10 _003CCaptureToTextureCoroutine_003Ed__11 = (_003CCaptureToTextureCoroutine_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CCaptureToTextureCoroutine_003Ed__10));
					_003CCaptureToTextureCoroutine_003Ed__11._003C_003E1__state = 0;
					_003CCaptureToTextureCoroutine_003Ed__11.width = width;
					_003CCaptureToTextureCoroutine_003Ed__11.height = (int)((uint)width >> 32);
					_003CCaptureToTextureCoroutine_003Ed__11.cameras = cameras;
					_003CCaptureToTextureCoroutine_003Ed__11.canvas = canvas;
					_003CCaptureToTextureCoroutine_003Ed__11.captureMode = captureMode;
					_003CCaptureToTextureCoroutine_003Ed__11.captureGameUI = captureGameUI;
					_003CCaptureToTextureCoroutine_003Ed__11.colorFormat = colorFormat;
					_003CCaptureToTextureCoroutine_003Ed__11.recomputeAlphaMask = recomputeAlphaMask;
					_003CCaptureToTextureCoroutine_003Ed__11.exportToGallery = true;
					_003CCaptureToTextureCoroutine_003Ed__11.exportAsync = false;
					_003C_003E2__current = _003CCaptureToTextureCoroutine_003Ed__11;
					_003C_003E1__state = 1;
				}
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x3C41A20", Offset = "0x3C41A20", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000046")]
		private sealed class _003CCaptureToTextureCoroutine_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001C8")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x40001C9")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001CA")]
			[FieldOffset(Offset = "0x20")]
			public int width;

			[Token(Token = "0x40001CB")]
			[FieldOffset(Offset = "0x24")]
			public int height;

			[Token(Token = "0x40001CC")]
			[FieldOffset(Offset = "0x28")]
			public List<Camera> cameras;

			[Token(Token = "0x40001CD")]
			[FieldOffset(Offset = "0x30")]
			public List<Canvas> canvas;

			[Token(Token = "0x40001CE")]
			[FieldOffset(Offset = "0x38")]
			public ScreenshotTaker.CaptureMode captureMode;

			[Token(Token = "0x40001CF")]
			[FieldOffset(Offset = "0x3C")]
			public int antiAliasing;

			[Token(Token = "0x40001D0")]
			[FieldOffset(Offset = "0x40")]
			public bool captureGameUI;

			[Token(Token = "0x40001D1")]
			[FieldOffset(Offset = "0x44")]
			public ScreenshotTaker.ColorFormat colorFormat;

			[Token(Token = "0x40001D2")]
			[FieldOffset(Offset = "0x48")]
			public bool recomputeAlphaMask;

			[Token(Token = "0x40001D3")]
			[FieldOffset(Offset = "0x49")]
			public bool exportToGallery;

			[Token(Token = "0x40001D4")]
			[FieldOffset(Offset = "0x4A")]
			public bool exportAsync;

			[Token(Token = "0x17000029")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600015E")]
				[Address(RVA = "0x3C42090", Offset = "0x3C42090", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700002A")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000160")]
				[Address(RVA = "0x3C420D8", Offset = "0x3C420D8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600015B")]
			[Address(RVA = "0x3C414A4", Offset = "0x3C414A4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CCaptureToTextureCoroutine_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x600015C")]
			[Address(RVA = "0x3C41A68", Offset = "0x3C41A68", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600015D")]
			[Address(RVA = "0x3C41A6C", Offset = "0x3C41A6C", Length = "0x624")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0062;\n\tv75 = this.<>1__state == 0;\n\tv76 = ~v75;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v76) goto L_019C;\n\tthis.<>1__state = -1;\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::InitScreenshotTaker();\n\tv249 = new AlmostEngine.Screenshot.ScreenshotResolution();\n\tAlmostEngine.Screenshot.ScreenshotResolution::.ctor(v249);\n\tv249.m_Width = this.width;\n\tv349 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v349);\n\tv477 = this.cameras == 0;\n\tif (v477) goto L_00DF;\n\tv486 = System.Collections.Generic.List`1<UnityEngine.Camera>::GetEnumerator(this.cameras);\n\tv444 = v486._list;\n\tv610 = v349 == 0;\n\tif (v610) goto L_00D3;\n\tgoto L_00A7;\nL_00A4:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::Add(v349, v595);\nL_FFFFFFFF:\n\t;\nL_00A7:\n\tv701 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v444 @ stack_-80_v10 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv755 = v701 == 0;\n\tif (v755) goto L_00DB;\n\tv595 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v595, v486.Current);\n\tv849 = v349._version + 1;\n\tv349._version = v849;\n\tv598 = v349._items == 0;\n\tif (v598) goto L_01A5;\n\tgoto L_00A4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_FFFFFFFF:\n\tv183 = -1;\n\tgoto L_018E;\nL_00D3:\n\tv462 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v444 @ stack_-80_v10 (System.Collections.Generic.List`1<UnityEngine.Camera>));\n\tv702 = ~v462;\n\tv464 = ~v702;\n\tif (v464) goto L_01A2;\nL_00DB:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v444 @ stack_-80_v10 (System.Collections.Generic.List`1<UnityEngine.Camera>));\nL_00DF:\n\tv543 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v543);\n\tv624 = this.canvas == 0;\nL_FFFFFFFF:\n\tv222 = v543;\nL_FFFFFFFF:\n\tv242 = v349;\n\tif (v624) goto L_0146;\n\tv707 = System.Collections.Generic.List`1<UnityEngine.Canvas>::GetEnumerator(this.canvas);\n\tv628 = v707._list;\n\tv764 = v543 == 0;\n\tif (v764) goto L_0135;\n\tgoto L_010B;\nL_0108:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::Add(v543, v888);\nL_FFFFFFFF:\n\t;\nL_010B:\n\tv835 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v628 @ stack_-A0_v9 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\n\tv851 = v835 == 0;\n\tif (v851) goto L_013D;\n\tv888 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v888, v707.Current);\n\tv894 = v543._version + 1;\n\tv543._version = v894;\n\tv829 = v543._items == 0;\n\tif (v829) goto L_01AE;\n\tgoto L_0108;\nL_0135:\n\tv787 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v628 @ stack_-A0_v9 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\n\tv836 = ~v787;\n\tv837 = ~v836;\n\tif (v837) goto L_01AB;\nL_013D:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v628 @ stack_-A0_v9 (System.Collections.Generic.List`1<UnityEngine.Canvas>));\nL_FFFFFFFF:\n\tv222 = v543;\nL_FFFFFFFF:\n\tv242 = v349;\nL_0146:\n\tv401 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v401);\n\tgoto L_0171;\nL_0171:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v401, v249);\n\tv899 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureAllCoroutine(v745.m_ScreenshotTaker, v401, v242, v222, this.captureMode, this.antiAliasing, this.captureGameUI, this.colorFormat, this.recomputeAlphaMask, v900, this.exportAsync, 0x100, v901);\n\tv908 = UnityEngine.MonoBehaviour::StartCoroutine(v745.m_ScreenshotTaker, v899);\n\tthis.<>2__current = v908;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_FFFFFFFF:\n\tv183 = 1;\nL_01A2:\n\tv595 = new AlmostEngine.Screenshot.ScreenshotCamera();\n\tAlmostEngine.Screenshot.ScreenshotCamera::.ctor(v595, v441);\nL_01A5:\n\tthrow v595;\nL_01AB:\n\tv888 = new AlmostEngine.Screenshot.ScreenshotOverlay();\n\tAlmostEngine.Screenshot.ScreenshotOverlay::.ctor(v888, v707.Current);\nL_01AE:\n\tthrow v888;\nL_0062:\n\tv67 = this.<>1__state == 1;\n\tif (v67) goto L_FFFFFFFF;\nL_019C:\n\treturn returnVal1;\nL_018E:\n\tthis.<>1__state = v183;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SimpleScreenshotCapture._003CCaptureToTextureCoroutine_003Ed__10::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x3C42098", Offset = "0x3C42098", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x40001B1")]
		private static ScreenshotTaker m_ScreenshotTaker;

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x3C40DE0", Offset = "0x3C40DE0", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv57 = UnityEngine.Object::op_Inequality(v23.m_ScreenshotTaker, 0);\n\tv67 = v57 == 0;\n\tif (v67) goto L_0048;\n\tgoto L_0083;\nL_0048:\n\tgoto L_004C;\nL_004C:\n\tv101 = UnityEngine.Object::op_Equality(v83.m_ScreenshotTaker, 0);\n\tv104 = ~v101;\n\tif (v104) goto L_0083;\n\tv155 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v155);\n\tv132 = v155 == 0;\n\tif (v132) goto L_0084;\n\tUnityEngine.Object::set_name(v155, \"tmp Screenshot Capture\");\n\tUnityEngine.Object::set_hideFlags(v155, 0x3D);\n\tv168 = UnityEngine.GameObject::AddComponent(v155);\n\tv169.m_ScreenshotTaker = v168;\n\treturn;\nL_0083:\n\treturn;\nL_0084:\n\tthrow v155;\n")]
		private static void InitScreenshotTaker()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SimpleScreenshotCapture::InitScreenshotTaker");
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x3C2E2F4", Offset = "0x3C2E2F4", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv66.colorFormat = colorFormat;\n\tv85 = UnityEngine.MonoBehaviour::StartCoroutine(v50.m_ScreenshotTaker, v66);\n\treturn;\nL_0019:\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::InitScreenshotTaker();\n\tgoto L_002B;\nL_002B:\n\tv66 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureScreenToTextureCoroutine>d__9();\n\tSystem.Object::.ctor(v66);\n\tv66.<>1__state = 0;\n\tv66.onTextureCaptured = v46;\n")]
		public static void CaptureScreenToTexture(UnityAction<Texture2D> onTextureCaptured, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB)
		{
			InitScreenshotTaker();
			_003CCaptureScreenToTextureCoroutine_003Ed__9 _003CCaptureScreenToTextureCoroutine_003Ed__10 = (_003CCaptureScreenToTextureCoroutine_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CCaptureScreenToTextureCoroutine_003Ed__9));
			_003CCaptureScreenToTextureCoroutine_003Ed__10._003C_003E1__state = 0;
			UnityAction<Texture2D> onTextureCaptured2 = default(UnityAction<Texture2D>);
			_003CCaptureScreenToTextureCoroutine_003Ed__10.onTextureCaptured = onTextureCaptured2;
			_003CCaptureScreenToTextureCoroutine_003Ed__10.colorFormat = colorFormat;
			Coroutine coroutine = m_ScreenshotTaker.StartCoroutine(_003CCaptureScreenToTextureCoroutine_003Ed__10);
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0x3C2E0F8", Offset = "0x3C2E0F8", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tgoto L_0056;\nL_0056:\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::Add(v59, camera);\n\tgoto L_0068;\nL_0079:\n\treturnVal2 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureCamerasToTexture(width, height, v59, colorFormat);\n\treturn returnVal2;\nL_0026:\n\tv59 = new System.Collections.Generic.List`1<UnityEngine.Camera>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::.ctor(v59);\nL_0068:\n\tgoto L_0079;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Texture2D CaptureCameraToTexture(int width, int height, Camera camera, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB)
		{
			List<Camera> list = new List<Camera>();
			list.Add(camera);
			return ScreenshotTaker.CaptureCamerasToTexture(width, height, list, colorFormat);
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0x3C41004", Offset = "0x3C41004", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_002E:\n\treturnVal1 = AlmostEngine.Screenshot.ScreenshotTaker::CaptureCamerasToTexture(width, height, cameras, colorFormat);\n\treturn returnVal1;\nL_001F:\n\tgoto L_002E;\n")]
		public static Texture2D CaptureCamerasToTexture(int width, int height, List<Camera> cameras, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB)
		{
			return ScreenshotTaker.CaptureCamerasToTexture(width, height, cameras, colorFormat);
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x3C2E4FC", Offset = "0x3C2E4FC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv43 = UnityEngine.Screen::get_width();\n\tv46 = UnityEngine.Screen::get_height();\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureToFile(fileName, v43, v46, fileFormat, JPGQuality, 0, 0, 2, 8, captureGameUI, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);\n\treturn;\n")]
		public static void CaptureScreenToFile(string fileName, TextureExporter.ImageFileFormat fileFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 100, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			int width = Screen.width;
			int height = Screen.height;
			CaptureToFile(fileName, width, height, fileFormat, JPGQuality, null, null, ScreenshotTaker.CaptureMode.FIXED_GAME_VIEW, 8, captureGameUI, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0x3C2E5B8", Offset = "0x3C2E5B8", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tgoto L_0058;\nL_0058:\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::Add(v67, camera);\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureToFile(fileName, width, height, fileFormat, JPGQuality, v67, 0, 1, antiAliasing, 0, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);\n\treturn;\nL_002C:\n\tv67 = new System.Collections.Generic.List`1<UnityEngine.Camera>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Camera>::.ctor(v67);\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void CaptureCameraToFile(string fileName, int width, int height, Camera camera, TextureExporter.ImageFileFormat fileFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 100, int antiAliasing = 8, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			List<Camera> list = new List<Camera>();
			list.Add(camera);
			CaptureToFile(fileName, width, height, fileFormat, JPGQuality, list, null, ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE, antiAliasing, captureGameUI: false, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0x3C41200", Offset = "0x3C41200", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::CaptureToFile(fileName, width, height, fileFormat, JPGQuality, cameras, 0, 1, antiAliasing, 0, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);\n\treturn;\n")]
		public static void CaptureCamerasToFile(string fileName, int width, int height, List<Camera> cameras, TextureExporter.ImageFileFormat fileFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 100, int antiAliasing = 8, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			CaptureToFile(fileName, width, height, fileFormat, JPGQuality, cameras, null, ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE, antiAliasing, captureGameUI: false, colorFormat, recomputeAlphaMask, exportToGallery, exportAsync);
		}

		[Token(Token = "0x6000148")]
		[Address(RVA = "0x3C41084", Offset = "0x3C41084", Length = "0x17C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv98.width = width;\n\tv98.height = height;\n\tv98.fileFormat = fileFormat;\n\tv98.JPGQuality = JPGQuality;\n\tv98.cameras = cameras;\n\tv98.canvas = canvas;\n\tv98.captureMode = captureMode;\n\tv98.antiAliasing = antiAliasing;\n\tv98.captureGameUI = captureGameUI;\n\tv98.colorFormat = colorFormat;\n\tv98.recomputeAlphaMask = recomputeAlphaMask;\n\tv98.exportToGallery = exportToGallery;\n\tv98.exportAsync = exportAsync;\n\tv136 = UnityEngine.MonoBehaviour::StartCoroutine(v82.m_ScreenshotTaker, v98);\n\treturn;\nL_002F:\n\tAlmostEngine.Screenshot.SimpleScreenshotCapture::InitScreenshotTaker();\n\tgoto L_0041;\nL_0041:\n\tv98 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureToFileCoroutine>d__11();\n\tSystem.Object::.ctor(v98);\n\tv98.<>1__state = 0;\n\tv98.fileName = v78;\n")]
		public static void CaptureToFile(string fileName, int width, int height, TextureExporter.ImageFileFormat fileFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 100, List<Camera> cameras = null, List<Canvas> canvas = null, ScreenshotTaker.CaptureMode captureMode = ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE, int antiAliasing = 8, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			InitScreenshotTaker();
			_003CCaptureToFileCoroutine_003Ed__11 _003CCaptureToFileCoroutine_003Ed__12 = (_003CCaptureToFileCoroutine_003Ed__11)FormatterServices.GetUninitializedObject(typeof(_003CCaptureToFileCoroutine_003Ed__11));
			_003CCaptureToFileCoroutine_003Ed__12._003C_003E1__state = 0;
			string fileName2 = default(string);
			_003CCaptureToFileCoroutine_003Ed__12.fileName = fileName2;
			_003CCaptureToFileCoroutine_003Ed__12.width = width;
			_003CCaptureToFileCoroutine_003Ed__12.height = height;
			_003CCaptureToFileCoroutine_003Ed__12.fileFormat = fileFormat;
			_003CCaptureToFileCoroutine_003Ed__12.JPGQuality = JPGQuality;
			_003CCaptureToFileCoroutine_003Ed__12.cameras = cameras;
			_003CCaptureToFileCoroutine_003Ed__12.canvas = canvas;
			_003CCaptureToFileCoroutine_003Ed__12.captureMode = captureMode;
			_003CCaptureToFileCoroutine_003Ed__12.antiAliasing = antiAliasing;
			_003CCaptureToFileCoroutine_003Ed__12.captureGameUI = captureGameUI;
			_003CCaptureToFileCoroutine_003Ed__12.colorFormat = colorFormat;
			_003CCaptureToFileCoroutine_003Ed__12.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureToFileCoroutine_003Ed__12.exportToGallery = exportToGallery;
			_003CCaptureToFileCoroutine_003Ed__12.exportAsync = exportAsync;
			Coroutine coroutine = m_ScreenshotTaker.StartCoroutine(_003CCaptureToFileCoroutine_003Ed__12);
		}

		[IteratorStateMachine(typeof(_003CCaptureScreenToTextureCoroutine_003Ed__9))]
		[Token(Token = "0x6000149")]
		[Address(RVA = "0x3C40F84", Offset = "0x3C40F84", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv46.colorFormat = colorFormat;\n\treturn v46;\nL_0018:\n\tv46 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureScreenToTextureCoroutine>d__9();\n\tSystem.Object::.ctor(v46);\n\tv46.<>1__state = 0;\n\tv46.onTextureCaptured = onTextureCaptured;\n")]
		public static IEnumerator CaptureScreenToTextureCoroutine(UnityAction<Texture2D> onTextureCaptured = null, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB)
		{
			_003CCaptureScreenToTextureCoroutine_003Ed__9 _003CCaptureScreenToTextureCoroutine_003Ed__10 = (_003CCaptureScreenToTextureCoroutine_003Ed__9)FormatterServices.GetUninitializedObject(typeof(_003CCaptureScreenToTextureCoroutine_003Ed__9));
			_003CCaptureScreenToTextureCoroutine_003Ed__10._003C_003E1__state = 0;
			_003CCaptureScreenToTextureCoroutine_003Ed__10.onTextureCaptured = onTextureCaptured;
			_003CCaptureScreenToTextureCoroutine_003Ed__10.colorFormat = colorFormat;
			return _003CCaptureScreenToTextureCoroutine_003Ed__10;
		}

		[IteratorStateMachine(typeof(_003CCaptureToTextureCoroutine_003Ed__10))]
		[Token(Token = "0x600014A")]
		[Address(RVA = "0x3C413B4", Offset = "0x3C413B4", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv70.canvas = canvas;\n\tv70.captureMode = captureMode;\n\tv70.antiAliasing = antiAliasing;\n\tv70.captureGameUI = captureGameUI;\n\tv70.colorFormat = colorFormat;\n\tv70.recomputeAlphaMask = recomputeAlphaMask;\n\tv70.exportToGallery = exportToGallery;\n\tv70.exportAsync = exportAsync;\n\treturn v70;\nL_0027:\n\tv70 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureToTextureCoroutine>d__10();\n\tSystem.Object::.ctor(v70);\n\tv70.<>1__state = 0;\n\tv70.width = width;\n\tv70.height = height;\n\tv70.cameras = cameras;\n")]
		public static IEnumerator CaptureToTextureCoroutine(int width, int height, List<Camera> cameras = null, List<Canvas> canvas = null, ScreenshotTaker.CaptureMode captureMode = ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE, int antiAliasing = 8, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			_003CCaptureToTextureCoroutine_003Ed__10 _003CCaptureToTextureCoroutine_003Ed__11 = (_003CCaptureToTextureCoroutine_003Ed__10)FormatterServices.GetUninitializedObject(typeof(_003CCaptureToTextureCoroutine_003Ed__10));
			_003CCaptureToTextureCoroutine_003Ed__11._003C_003E1__state = 0;
			_003CCaptureToTextureCoroutine_003Ed__11.width = width;
			_003CCaptureToTextureCoroutine_003Ed__11.height = height;
			_003CCaptureToTextureCoroutine_003Ed__11.cameras = cameras;
			_003CCaptureToTextureCoroutine_003Ed__11.canvas = canvas;
			_003CCaptureToTextureCoroutine_003Ed__11.captureMode = captureMode;
			_003CCaptureToTextureCoroutine_003Ed__11.antiAliasing = antiAliasing;
			_003CCaptureToTextureCoroutine_003Ed__11.captureGameUI = captureGameUI;
			_003CCaptureToTextureCoroutine_003Ed__11.colorFormat = colorFormat;
			_003CCaptureToTextureCoroutine_003Ed__11.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureToTextureCoroutine_003Ed__11.exportToGallery = exportToGallery;
			_003CCaptureToTextureCoroutine_003Ed__11.exportAsync = exportAsync;
			return _003CCaptureToTextureCoroutine_003Ed__11;
		}

		[IteratorStateMachine(typeof(_003CCaptureToFileCoroutine_003Ed__11))]
		[Token(Token = "0x600014B")]
		[Address(RVA = "0x3C41258", Offset = "0x3C41258", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv81.width = width;\n\tv81.height = height;\n\tv81.fileFormat = fileFormat;\n\tv81.JPGQuality = JPGQuality;\n\tv81.cameras = cameras;\n\tv81.canvas = canvas;\n\tv81.captureMode = captureMode;\n\tv81.antiAliasing = antiAliasing;\n\tv81.captureGameUI = captureGameUI;\n\tv81.colorFormat = colorFormat;\n\tv81.recomputeAlphaMask = recomputeAlphaMask;\n\tv81.exportToGallery = exportToGallery;\n\tv81.exportAsync = exportAsync;\n\treturn v81;\nL_002F:\n\tv81 = new AlmostEngine.Screenshot.SimpleScreenshotCapture+<CaptureToFileCoroutine>d__11();\n\tSystem.Object::.ctor(v81);\n\tv81.<>1__state = 0;\n\tv81.fileName = fileName;\n")]
		public static IEnumerator CaptureToFileCoroutine(string fileName, int width, int height, TextureExporter.ImageFileFormat fileFormat = TextureExporter.ImageFileFormat.PNG, int JPGQuality = 100, List<Camera> cameras = null, List<Canvas> canvas = null, ScreenshotTaker.CaptureMode captureMode = ScreenshotTaker.CaptureMode.RENDER_TO_TEXTURE, int antiAliasing = 8, bool captureGameUI = true, ScreenshotTaker.ColorFormat colorFormat = ScreenshotTaker.ColorFormat.RGB, bool recomputeAlphaMask = false, bool exportToGallery = true, bool exportAsync = false)
		{
			_003CCaptureToFileCoroutine_003Ed__11 _003CCaptureToFileCoroutine_003Ed__12 = (_003CCaptureToFileCoroutine_003Ed__11)FormatterServices.GetUninitializedObject(typeof(_003CCaptureToFileCoroutine_003Ed__11));
			_003CCaptureToFileCoroutine_003Ed__12._003C_003E1__state = 0;
			_003CCaptureToFileCoroutine_003Ed__12.fileName = fileName;
			_003CCaptureToFileCoroutine_003Ed__12.width = width;
			_003CCaptureToFileCoroutine_003Ed__12.height = height;
			_003CCaptureToFileCoroutine_003Ed__12.fileFormat = fileFormat;
			_003CCaptureToFileCoroutine_003Ed__12.JPGQuality = JPGQuality;
			_003CCaptureToFileCoroutine_003Ed__12.cameras = cameras;
			_003CCaptureToFileCoroutine_003Ed__12.canvas = canvas;
			_003CCaptureToFileCoroutine_003Ed__12.captureMode = captureMode;
			_003CCaptureToFileCoroutine_003Ed__12.antiAliasing = antiAliasing;
			_003CCaptureToFileCoroutine_003Ed__12.captureGameUI = captureGameUI;
			_003CCaptureToFileCoroutine_003Ed__12.colorFormat = colorFormat;
			_003CCaptureToFileCoroutine_003Ed__12.recomputeAlphaMask = recomputeAlphaMask;
			_003CCaptureToFileCoroutine_003Ed__12.exportToGallery = exportToGallery;
			_003CCaptureToFileCoroutine_003Ed__12.exportAsync = exportAsync;
			return _003CCaptureToFileCoroutine_003Ed__12;
		}
	}
}
