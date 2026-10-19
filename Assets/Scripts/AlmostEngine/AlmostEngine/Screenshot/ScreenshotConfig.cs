using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x2000017")]
	public class ScreenshotConfig
	{
		[Token(Token = "0x2000018")]
		public enum AntiAliasing
		{
			[Token(Token = "0x40000B3")]
			NONE = 0,
			[Token(Token = "0x40000B4")]
			TWO = 2,
			[Token(Token = "0x40000B5")]
			FOUR = 4,
			[Token(Token = "0x40000B6")]
			EIGHT = 8
		}

		[Token(Token = "0x2000019")]
		public enum ShotMode
		{
			[Token(Token = "0x40000B8")]
			ONE_SHOT = 0,
			[Token(Token = "0x40000B9")]
			BURST = 1
		}

		[Token(Token = "0x200001A")]
		public enum CamerasMode
		{
			[Token(Token = "0x40000BB")]
			GAME_VIEW = 0,
			[Token(Token = "0x40000BC")]
			SCENE_VIEW = 1,
			[Token(Token = "0x40000BD")]
			CUSTOM_CAMERAS = 2
		}

		[Token(Token = "0x200001B")]
		public enum ResolutionMode
		{
			[Token(Token = "0x40000BF")]
			GAME_VIEW = 0,
			[Token(Token = "0x40000C0")]
			CUSTOM_RESOLUTIONS = 1
		}

		[Token(Token = "0x200001C")]
		public enum CompositionMode
		{
			[Token(Token = "0x40000C2")]
			SIMPLE_CAPTURE = 0,
			[Token(Token = "0x40000C3")]
			COMPOSITION = 1
		}

		[Token(Token = "0x200001D")]
		public enum BatchMode
		{
			[Token(Token = "0x40000C5")]
			SIMPLE_CAPTURE = 0,
			[Token(Token = "0x40000C6")]
			BATCHES = 1
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x200001E")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000C7")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000C8")]
			public static Func<ScreenshotComposition, bool> _003C_003E9__57_0;

			[Token(Token = "0x40000C9")]
			public static Func<ScreenshotBatch, bool> _003C_003E9__61_0;

			[Token(Token = "0x600005B")]
			[Address(RVA = "0x3C33DB8", Offset = "0x3C33DB8", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new AlmostEngine.Screenshot.ScreenshotConfig+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x600005C")]
			[Address(RVA = "0x3C33E1C", Offset = "0x3C33E1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CGetActiveCompositions_003Eb__57_0(ScreenshotComposition x)
			{
				return x.m_Active;
			}

			internal bool _003CGetActiveBatches_003Eb__61_0(ScreenshotBatch x)
			{
				return x.m_Active;
			}
		}

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x10")]
		public ScreenshotNameParser.DestinationFolder m_DestinationFolder;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x18")]
		public string m_RelativePath;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x20")]
		public string m_RootedPath;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x28")]
		public bool m_ExportToPhoneGallery;

		[Tooltip("After the capture process, asynchronously encode and export the screenshot. Doesn't block the main thread but uses more memory. Only available with NET 4.0 and Net Standard 2.0.")]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x29")]
		public bool m_ExportAsync;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x30")]
		public string m_FileName;

		[Tooltip("Overwrite files or increment automatically the filenames.")]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x38")]
		public bool m_OverwriteFiles;

		[Tooltip("How many left zeros should there be in the numbers.")]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x3C")]
		public int m_NumberLeftPadding;

		[Tooltip("Use PNG to create screenshots with a transparent background.")]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x40")]
		public TextureExporter.ImageFileFormat m_FileFormat;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x44")]
		public float m_JPGQuality;

		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x48")]
		public string m_ShareTitle;

		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x50")]
		public string m_ShareSubject;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x58")]
		public string m_ShareText;

		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x60")]
		public ScreenshotTaker.CaptureMode m_CaptureMode;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x64")]
		public AntiAliasing m_MultisamplingAntiAliasing;

		[Tooltip("RGB is the default color format.\nUse RGBA to create screenshots with an alpha layer, enabling transparent backgrounds.")]
		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x68")]
		public ScreenshotTaker.ColorFormat m_ColorFormat;

		[Tooltip("Force alpha layer to be recomputed. This is a costly process. Use only if you have alpha problems in RGBA mode.")]
		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x6C")]
		public bool m_RecomputeAlphaLayer;

		[Tooltip("When alpha layer is recomputed in HDRP, disable all FX during alpha recomputation.")]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x6D")]
		public bool m_DisableHDRPFX;

		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x70")]
		public ShotMode m_ShotMode;

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x74")]
		public int m_MaxBurstShotsNumber;

		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x78")]
		public int m_MaxShotPerSeconds;

		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0x7C")]
		public bool m_FixedFrameRate;

		[Tooltip("GAME_VIEW will capture what you see on the screen.\nCUSTOM_CAMERAS allows you to customize the cameras to be used, and their rendering properties.")]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x80")]
		public CamerasMode m_CameraMode;

		[Tooltip("When enabled, one screenshot is taken for each camera, to be used as independent layers for compositing.")]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x84")]
		public bool m_ExportToDifferentLayers;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x88")]
		public List<ScreenshotCamera> m_Cameras;

		[Tooltip("GAME_VIEW will capture what you see on the screen.\nCUSTOM_RESOLUTIONS allows you to customize the resolutions to be used.")]
		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x90")]
		public ResolutionMode m_ResolutionCaptureMode;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x98")]
		public List<ScreenshotResolution> m_Resolutions;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0xA0")]
		public ScreenshotResolution m_GameViewResolution;

		[Tooltip("Capture or not the active UI Canvas.")]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0xA8")]
		public bool m_CaptureActiveUICanvas;

		[Tooltip("When true, Canvas and UI elements that are not in any culling layers of the capture cameras will be disabled. Only work in custom camera mode.")]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0xA9")]
		public bool m_ForceUICullingLayer;

		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0xB0")]
		public List<ScreenshotOverlay> m_Overlays;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0xB8")]
		public CompositionMode m_CompositionMode;

		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0xC0")]
		public List<ScreenshotComposition> m_Compositions;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0xC8")]
		public BatchMode m_BatchMode;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0xD0")]
		public List<ScreenshotBatch> m_Batches;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0xD8")]
		public bool m_ShowGuidesInPreview;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0xE0")]
		public Canvas m_GuideCanvas;

		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0xE8")]
		public Color m_GuidesColor;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0xF8")]
		public bool m_ShowPreview;

		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0xFC")]
		public float m_PreviewSize;

		[Tooltip("If set to true, the camera and overlay settings will be applied when the application starts playing.")]
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x100")]
		public bool m_PreviewInGameViewWhilePlaying;

		[Tooltip("If set to true, the manager is moved at startup in the persistent scene and not destroyed when the scene changes.")]
		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x101")]
		public bool m_DontDestroyOnLoad;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x102")]
		public bool m_StopTimeOnCapture;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x103")]
		public bool m_PlaySoundOnCapture;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x108")]
		public AudioClip m_ShotSound;

		[NonSerialized]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x110")]
		public float m_Time;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x118")]
		public HotKey m_CaptureHotkey;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x120")]
		public HotKey m_UpdatePreviewHotkey;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x128")]
		public HotKey m_AlignHotkey;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x130")]
		public HotKey m_PauseHotkey;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x138")]
		public ScreenshotTaker.GameViewResizingWaitingMode m_GameViewResizingWaitingMode;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x13C")]
		public float m_ResizingWaitingTime;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x140")]
		public int m_ResizingWaitingFrames;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x144")]
		public int m_ItemsPerPage;

		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x148")]
		public bool m_ShowDestination;

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x149")]
		public bool m_ShowName;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x14A")]
		public bool m_ShowCaptureMode;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x14B")]
		public bool m_ShowResolutions;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x14C")]
		public bool m_ShowCameras;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x14D")]
		public bool m_ShowCanvas;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x14E")]
		public bool m_ShowComposition;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x14F")]
		public bool m_ShowBatches;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x150")]
		public bool m_ShowPreviewGUI;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x151")]
		public bool m_ShowCapture;

		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x152")]
		public bool m_ShowHotkeys;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x153")]
		public bool m_ShowGallery;

		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x154")]
		public bool m_ShowUtils;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x155")]
		public bool m_ShowUsage;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x156")]
		public bool m_ShowInstall;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x157")]
		public bool m_ShowDelay;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x158")]
		public bool m_ShowShare;

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3C30DD0", Offset = "0x3C30DD0", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005E;\n\tthis.m_JPGQuality = 75f;\n\tthis.m_ShareTitle = \"Share the screenshot\";\n\tthis.m_ShareSubject = \"Nice screenshot\";\n\tthis.m_ShareText = \"Look at this nice screenshot.\";\n\tthis.m_CaptureMode = 1.69759663287E-313d;\n\tthis.m_DisableHDRPFX = 1;\n\tthis.m_MaxBurstShotsNumber = 6.3659873739E-313d;\n\tthis.m_FixedFrameRate = 1;\n\tv121 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v121);\n\tthis.m_Cameras = v121;\n\tthis.m_ResolutionCaptureMode = 1;\n\tv142 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v142);\n\tthis.m_Resolutions = v142;\n\tthis.m_CaptureActiveUICanvas = 1;\n\tv163 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotOverlay>::.ctor(v163);\n\tthis.m_Overlays = v163;\n\tv184 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotComposition>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotComposition>::.ctor(v184);\n\tthis.m_Compositions = v184;\n\tv201 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch>::.ctor(v201);\n\tthis.m_Batches = v201;\n\tthis.m_GuidesColor = 0;\n\tthis.m_ShowPreview = 1;\n\tthis.m_PreviewSize = 1f;\n\tthis.m_DontDestroyOnLoad = 0x101;\n\tthis.m_PlaySoundOnCapture = 1;\n\tthis.m_Time = 1f;\n\tv215 = new AlmostEngine.HotKey();\n\tAlmostEngine.HotKey::.ctor(v215, 0, 0, 0, 0);\n\tthis.m_CaptureHotkey = v215;\n\tv226 = new AlmostEngine.HotKey();\n\tAlmostEngine.HotKey::.ctor(v226, 0, 0, 0, 0);\n\tthis.m_UpdatePreviewHotkey = v226;\n\tv237 = new AlmostEngine.HotKey();\n\tAlmostEngine.HotKey::.ctor(v237, 0, 0, 0, 0);\n\tthis.m_AlignHotkey = v237;\n\tv248 = new AlmostEngine.HotKey();\n\tAlmostEngine.HotKey::.ctor(v248, 0, 0, 0, 0);\n\tthis.m_PauseHotkey = v248;\n\tthis.m_ResizingWaitingTime = 1f;\n\tthis.m_ResizingWaitingFrames = 4.24399158203E-313d;\n\tthis.m_ShowDestination = 0x101010101010101;\n\tthis.m_ShowPreviewGUI = 0x101010101010101;\n\tthis.m_ShowShare = 0x101010101010101;\n\tSystem.Object::.ctor(this);\n\tv266 = new AlmostEngine.Screenshot.ScreenshotResolution();\n\tAlmostEngine.Screenshot.ScreenshotResolution::.ctor(v266);\n\tthis.m_GameViewResolution = v266;\n\treturn;\nL_005E:\n\tthis.m_DestinationFolder = 3;\n\tthis.m_RelativePath = \"Screenshots/\";\n\tthis.m_RootedPath = \"\";\n\tthis.m_ExportToPhoneGallery = 1;\n\tthis.m_FileName = \"{width}x{height}-screenshot\";\n")]
		public ScreenshotConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::.ctor");
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x3C31218", Offset = "0x3C31218", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.m_DestinationFolder != 0;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 0x20;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv16 = 0x18;\nL_0013:\n\treturnVal1 = AlmostEngine.Screenshot.ScreenshotNameParser::ParsePath(this, *([this @ X0 (AlmostEngine.Screenshot.ScreenshotConfig)+v16 @ X8_v3 (System.Int32)]));\n\treturn returnVal1;\n")]
		public string GetPath()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::GetPath");
			return default;
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x3C3135C", Offset = "0x3C3135C", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv76 = this.m_Cameras == 0;\n\tv228 = Il2CppMethodInfo;\n\tif (v76) goto L_00D7;\n\tv201 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::GetEnumerator(this.m_Cameras);\n\tv118 = v201.Current;\n\tv107 = v201._list;\n\tv289 = v52 == 0;\n\tif (v289) goto L_00A2;\n\tgoto L_0066;\nL_0063:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::Add(v52, v118);\nL_0066:\n\tv341 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v107 @ stack_-60_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv403 = v341 == 0;\n\tif (v403) goto L_00C9;\n\tv346 = v118.m_Active == 0;\n\tif (v346) goto L_0066;\n\tgoto L_007B;\nL_007B:\n\tv342 = UnityEngine.Object::op_Equality(v118.m_Camera, 0);\n\tv477 = v342 == 0;\n\tv347 = ~v477;\n\tif (v347) goto L_0066;\n\tv482 = v52._version + 1;\n\tv52._version = v482;\n\tv345 = v52._items == 0;\n\tif (v345) goto L_00C3;\n\tgoto L_0063;\n\tv363 = v118.m_Active != 1;\n\tif (v363) goto L_00A2;\n\tgoto L_00BE;\nL_00BE:\n\tv385 = UnityEngine.Object::op_Equality(v118.m_Camera, 0);\n\tv479 = v385 == 0;\n\tv388 = ~v479;\n\tif (v388) goto L_00A2;\nL_00C3:\n\tv460 = new System.NullReferenceException();\n\tgoto L_00D6;\nL_00C9:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v107 @ stack_-60_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\nL_00D4:\n\treturn v52;\nL_00D6:\n\t// 214 Interrupt\n\tv135 = 0;\n\tv228 = v229;\nL_00EA:\n\tv139 = v228 != 1;\n\tv280 = v240;\n\tif (v139) goto L_00FC;\n\tv396 = 0x8BF5BC4(v240, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv405 = 0x8BF5BF4(v396, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v107 @ stack_-60_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv172 = *([v396 @ X0_v16]) == 0;\n\tif (v172) goto L_00D4;\n\tv398 = new System.OutOfMemoryException();\n\tv135 = *([v396 @ X0_v16]);\n\tv280 = v398;\n\treturn returnVal2;\nL_0030:\n\tv52 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::.ctor(v52);\n\tv71 = this.m_CameraMode != 2;\n\tif (v71) goto L_00D4;\nL_00D7:\n\tv240 = new System.NullReferenceException();\n\tgoto L_00EA;\nL_00A2:\n\tv384 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v107 @ stack_-60_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>));\n\tv404 = ~v384;\n\tif (v404) goto L_00C9;\nL_00FC:\n\tv401 = 0x3176E88(&v135 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv407 = 0x8BF0368(v280, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v407, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe List<ScreenshotCamera> GetActiveCameras()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::GetActiveCameras");
			return default;
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3C3162C", Offset = "0x3C3162C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void AlignToView()
		{
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3C31630", Offset = "0x3C31630", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv55 = v40.Count < 1;\n\tif (v55) goto L_0037;\n\treturnVal3 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(v40, 0);\n\treturn returnVal3;\nL_0037:\n\treturn this.m_GameViewResolution;\nL_0016:\n\tv40 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this);\n")]
		public ScreenshotResolution GetFirstActiveResolution()
		{
			List<ScreenshotResolution> activeResolutions = GetActiveResolutions();
			if (activeResolutions.Count >= 1)
			{
				return activeResolutions[0];
			}
			return m_GameViewResolution;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3C316B4", Offset = "0x3C316B4", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0030;\n\tv87 = this.m_ResolutionCaptureMode != 1;\n\tv251 = Il2CppMethodInfo;\n\tif (v87) goto L_009E;\n\tv192 = this.m_Resolutions == 0;\n\tv251 = Il2CppMethodInfo;\n\tif (v192) goto L_012D;\n\tv224 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv125 = v224.Current;\n\tv115 = v224._list;\n\tv310 = v53 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_00DB;\n\tgoto L_0094;\nL_0069:\n\tv476 = v224.Current == 0;\n\tv251 = Il2CppMethodInfo;\n\tif (v476) goto L_0129;\n\tv437 = v125.m_Active != 1;\n\tif (v437) goto L_0094;\n\tv438 = v125.m_Width < 1;\n\tif (v438) goto L_0094;\n\tv436 = v125.m_Height > 0;\n\tv251 = Il2CppMethodInfo;\n\tif (v436) goto L_012B;\nL_0094:\n\tv474 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v115 @ stack_-50_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv490 = ~v474;\n\tv491 = ~v490;\n\tif (v491) goto L_0069;\nL_009C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v115 @ stack_-50_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv135 = &v115 @ stack_-50_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>);\n\tv142 = 0;\n\tv251 = Il2CppMethodInfo;\nL_009E:\n\tv187 = this.m_ResolutionCaptureMode == 0;\n\tif (v187) goto L_00AE;\n\tv194 = this.m_CaptureMode - 2;\n\tv195 = v194 < 2;\n\tv196 = ~v195;\n\tv197 = v194 - 2;\n\tv199 = v197 == 0;\n\tv204 = ~v199;\n\tv205 = v196 & v204;\n\tif (v205) goto L_00D3;\nL_00AE:\n\tv216 = v53 == 0;\n\tif (v216) goto L_012D;\n\tv302 = v53._version + 1;\n\tv53._version = v302;\n\tv258 = v53._items == 0;\n\tv251 = this.m_GameViewResolution;\n\tif (v258) goto L_012D;\n\tgoto L_011F;\nL_00D3:\n\treturn v53;\nL_00D8:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v53, v224.Current);\nL_00DB:\n\tv411 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v115 @ stack_-50_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv482 = v411 == 0;\n\tif (v482) goto L_009C;\n\tv492 = v224.Current == 0;\n\tv251 = v224.Current;\n\tif (v492) goto L_0129;\n\tv415 = v125.m_Active == 0;\n\tif (v415) goto L_00DB;\n\tv374 = v125.m_Width < 1;\n\tif (v374) goto L_00DB;\n\tv373 = v125.m_Height < 1;\n\tif (v373) goto L_00DB;\n\tgoto L_00D8;\nL_011F:\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Add(v53, this.m_GameViewResolution);\n\treturn v53;\nL_0129:\n\tv520 = new System.NullReferenceException();\n\tgoto L_012C;\nL_012B:\n\tv545 = new System.NullReferenceException();\nL_012C:\n\t// 300 Interrupt\n\tv135 = &v115 @ stack_-50_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>);\n\tv142 = 0;\nL_013C:\n\tv146 = v251 != 1;\n\tv349 = v263;\n\tif (v146) goto L_014E;\n\tv484 = 0x8BF5BC4(v263, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv497 = 0x8BF5BF4(v484, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v135);\n\tv179 = *([v484 @ X0_v13]) == 0;\n\tv142 = *([v484 @ X0_v13]);\n\tv251 = Il2CppMethodInfo;\n\tif (v179) goto L_009E;\n\tv486 = new System.OutOfMemoryException();\n\tv142 = *([v484 @ X0_v13]);\n\tv349 = v486;\n\treturn returnVal3;\nL_0030:\n\tv53 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::.ctor(v53);\n\tv63 = this.m_CaptureMode - 2;\n\tv64 = v63 < 3;\n\tv65 = ~v64;\n\tv73 = ~v65;\n\tv251 = Il2CppMethodInfo;\n\tif (v73) goto L_009E;\nL_012D:\n\tv263 = new System.NullReferenceException();\n\tgoto L_013C;\nL_014E:\n\tv489 = 0x3176EC8(&v142 @ stack_-68 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv499 = 0x8BF0368(v349, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v499, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe List<ScreenshotResolution> GetActiveResolutions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::GetActiveResolutions");
			return default;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3C319E4", Offset = "0x3C319E4", Length = "0x238")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv149 = v53.m_MultiDisplayCamera;\n\tv55 = v53.m_MultiDisplayCamera == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0049;\n\tgoto L_00CF;\nL_0049:\n\tv81 = v149.Count < 1;\n\tif (v81) goto L_0089;\n\tgoto L_005A;\nL_005A:\n\tv137 = System.Collections.Generic.List`1<AlmostEngine.MultiDisplayCameraCapture>::get_Item(v53.m_MultiDisplayCamera, 0);\n\tv263 = UnityEngine.Component::GetComponent(v137);\nL_FFFFFFFF:\n\tv153 = v263;\n\tgoto L_006B;\nL_006B:\n\tv300 = UnityEngine.Object::op_Inequality(v153, 0);\n\tv318 = ~v300;\n\tif (v318) goto L_00B7;\n\tv338 = UnityEngine.Camera::get_pixelRect(v153);\n\tv350 = UnityEngine.Camera::get_pixelRect(v153);\n\treturn v338.width;\nL_0089:\n\tv139 = this.m_Cameras;\n\tv97 = v139.Count < 1;\n\tif (v97) goto L_00CD;\n\tv140 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotCamera>::get_Item(v139, 0);\n\tv153 = v140.m_Camera;\n\tgoto L_006B;\nL_00B7:\n\tgoto L_00CB;\nL_00CD:\n\tv263 = UnityEngine.Camera::get_main();\n\tgoto L_FFFFFFFF;\nL_00CF:\n\tthrow System.NullReferenceException;\nL_00CB:\n\treturn v226.zero;\n")]
		public Vector2 GetFixedGameviewMultiDisplayResolution()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::GetFixedGameviewMultiDisplayResolution");
			return default;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x3C31C1C", Offset = "0x3C31C1C", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Screen::get_width();\n\tv16 = UnityEngine.Screen::get_height();\n\tv29 = this.m_CaptureMode != 2;\n\tif (v29) goto L_0025;\n\tv33 = AlmostEngine.MultiDisplayUtils::IsMultiDisplay();\n\tv35 = ~v33;\n\tif (v35) goto L_0025;\n\tv45 = AlmostEngine.Screenshot.ScreenshotConfig::GetFixedGameviewMultiDisplayResolution(this);\n\tAlmostEngine.Screenshot.ScreenshotConfig::InitGameViewResolution(this);\n\tv60 = this.m_GameViewResolution;\nL_0034:\n\t// 52 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 53 NotImplemented \"Instruction FCMEQ not yet implemented.\"\n\t// 54 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 57 NotImplemented \"Instruction BSL not yet implemented.\"\n\tv60.m_Width = v72;\n\treturn;\nL_0025:\n\tv60 = this.m_GameViewResolution;\n\tv50 = this.m_GameViewResolution == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_0034;\n")]
		public void UpdateGameviewResolution()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::UpdateGameviewResolution");
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x3C31D00", Offset = "0x3C31D00", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv38.m_ResolutionName = \"GameView\";\n\tv38.m_Active = 1;\n\tv89 = this.m_GameViewResolution;\n\tv89.m_Scale = 1f;\n\tv93 = UnityEngine.Screen::get_width();\n\tv89.m_Width = v93;\n\tv90 = this.m_GameViewResolution;\n\tv79 = UnityEngine.Screen::get_height();\n\tv90.m_Height = v79;\n\tv52 = this.m_CaptureMode != 2;\n\tif (v52) goto L_004E;\n\tv131 = AlmostEngine.MultiDisplayUtils::IsMultiDisplay();\n\tv135 = ~v131;\n\tif (v135) goto L_004E;\n\tv49 = AlmostEngine.Screenshot.ScreenshotConfig::GetFixedGameviewMultiDisplayResolution(this);\n\tv87 = this.m_GameViewResolution;\n\t// 67 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 68 NotImplemented \"Instruction FCMEQ not yet implemented.\"\n\t// 69 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 71 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv87.m_Width = v49;\nL_0012:\n\tv38 = this.m_GameViewResolution;\nL_004E:\n\treturn;\n")]
		protected void InitGameViewResolution()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::InitGameViewResolution");
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x3C31DDC", Offset = "0x3C31DDC", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\n\tgoto L_001D;\nL_001D:\n\tv85 = System.DateTime::get_Now();\n\tv103 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(resolutions);\n\tv115 = v103._list;\n\tv119 = v103.Current;\n\tv137 = this.m_DestinationFolder != 0;\n\tif (v137) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv186 = 0x20;\n\tgoto L_0054;\nL_FFFFFFFF:\n\tv186 = 0x18;\n\tv119.m_FileName = v178;\n\tgoto L_0038;\nL_005F:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v115 @ stack_-68_v7 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_006B:\n\treturn;\nL_008C:\n\tv190 = new System.NullReferenceException();\n\tgoto L_009A;\nL_009A:\n\tv232 = resolutions != 1;\nL_FFFFFFFF:\n\tv247 = v190;\n\tif (v232) goto L_00AA;\n\tv238 = 0x8BF5BC4(v190, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv300 = 0x8BF5BF4(v238, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v163);\n\tv246 = *([v238 @ X0_v10]) == 0;\n\tif (v246) goto L_006B;\n\tv244 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv166 = *([v238 @ X0_v10]);\nL_FFFFFFFF:\n\tv247 = v244;\n\treturn;\nL_0054:\n\tv178 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseFileName(this.m_FileName, v103.Current, methodInfo, *([this @ X0 (AlmostEngine.Screenshot.ScreenshotConfig)+v186 @ X8_v14 (System.Int32)]), this.m_FileFormat, this.m_OverwriteFiles, v85, this.m_NumberLeftPadding);\n\tv183 = v103.Current == 0;\nL_FFFFFFFF:\n\t;\n\tif (v183) goto L_008C;\nL_0038:\n\tv217 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v115 @ stack_-68_v7 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv221 = v217 == 0;\n\tif (v221) goto L_005F;\nL_00AA:\n\tv250 = 0x3176EC8(&v166 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv302 = 0x8BF0368(v247, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv333 = 0xA1B8(v302, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateResolutionFilenames(List<ScreenshotResolution> resolutions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::UpdateResolutionFilenames");
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3C32020", Offset = "0x3C32020", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = this.m_DestinationFolder != 0;\n\tif (v19) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv22 = 0x20;\n\tgoto L_001D;\nL_FFFFFFFF:\n\tv22 = 0x18;\nL_001D:\n\treturnVal1 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseFileName(this.m_FileName, resolution, time, *([this @ X0 (AlmostEngine.Screenshot.ScreenshotConfig)+v22 @ X8_v3 (System.Int32)]), this.m_FileFormat, this.m_OverwriteFiles, time, this.m_NumberLeftPadding);\n\treturn returnVal1;\n")]
		public string ParseFileName(ScreenshotResolution resolution, DateTime time)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::ParseFileName");
			return default;
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3C31FB8", Offset = "0x3C31FB8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.m_DestinationFolder != 0;\n\tif (v25) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv28 = 0x20;\n\tgoto L_0020;\nL_FFFFFFFF:\n\tv28 = 0x18;\n\tresolution.m_FileName = v37;\n\treturn;\nL_0020:\n\tv37 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseFileName(this.m_FileName, resolution, time, *([this @ X0 (AlmostEngine.Screenshot.ScreenshotConfig)+v28 @ X8_v3 (System.Int32)]), this.m_FileFormat, this.m_OverwriteFiles, time, this.m_NumberLeftPadding);\n")]
		public void UpdateFileName(ScreenshotResolution resolution, DateTime time)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::UpdateFileName");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x3C321E0", Offset = "0x3C321E0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tAlmostEngine.Screenshot.ScreenshotResolution::UpdateRatio(v60.Current);\n\tgoto L_0037;\nL_0042:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004A:\n\treturn;\nL_005A:\n\tv114 = Il2CppMethodInfo != 1;\n\tv127 = v92;\n\tif (v114) goto L_006A;\n\tv118 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v92);\n\tv134 = 0x8BF5BF4(v118, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv126 = ~v118.m_value;\n\tif (v126) goto L_004A;\n\tv124 = new System.OutOfMemoryException();\n\tv64 = v118.m_value;\n\tv127 = v124;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004D;\nL_0037:\n\tv103 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv116 = v103 == 0;\n\tif (v116) goto L_0042;\nL_006A:\n\tv130 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv136 = 0x8BF0368(v127, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv177 = 0xA1B8(v136, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004D:\n\tv92 = new System.NullReferenceException();\n\tgoto L_005A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateRatios()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::UpdateRatios");
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x3C32830", Offset = "0x3C32830", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv71.m_Orientation = 2;\n\tgoto L_0038;\nL_0043:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004B:\n\treturn;\nL_005A:\n\tv116 = Il2CppMethodInfo != 1;\n\tv129 = v94;\n\tif (v116) goto L_006A;\n\tv120 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v94);\n\tv136 = 0x8BF5BF4(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv128 = ~v120.m_value;\n\tif (v128) goto L_004B;\n\tv126 = new System.OutOfMemoryException();\n\tv64 = v120.m_value;\n\tv129 = v126;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004E;\nL_0038:\n\tv102 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv118 = v102 == 0;\n\tif (v118) goto L_0043;\nL_006A:\n\tv132 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = 0x8BF0368(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = 0xA1B8(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004E:\n\tv94 = new System.NullReferenceException();\n\tgoto L_005A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetAllPortait()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::SetAllPortait");
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3C3296C", Offset = "0x3C3296C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv71.m_Orientation = 0;\n\tgoto L_0037;\nL_0042:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004A:\n\treturn;\nL_0059:\n\tv115 = Il2CppMethodInfo != 1;\n\tv128 = v93;\n\tif (v115) goto L_0069;\n\tv119 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v93);\n\tv135 = 0x8BF5BF4(v119, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv127 = ~v119.m_value;\n\tif (v127) goto L_004A;\n\tv125 = new System.OutOfMemoryException();\n\tv64 = v119.m_value;\n\tv128 = v125;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004D;\nL_0037:\n\tv101 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv117 = v101 == 0;\n\tif (v117) goto L_0042;\nL_0069:\n\tv131 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = 0x8BF0368(v128, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv178 = 0xA1B8(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004D:\n\tv93 = new System.NullReferenceException();\n\tgoto L_0059;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetAllLandscape()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::SetAllLandscape");
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3C32AA4", Offset = "0x3C32AA4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv71.m_Orientation = 1;\n\tgoto L_0038;\nL_0043:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004B:\n\treturn;\nL_005A:\n\tv116 = Il2CppMethodInfo != 1;\n\tv129 = v94;\n\tif (v116) goto L_006A;\n\tv120 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v94);\n\tv136 = 0x8BF5BF4(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv128 = ~v120.m_value;\n\tif (v128) goto L_004B;\n\tv126 = new System.OutOfMemoryException();\n\tv64 = v120.m_value;\n\tv129 = v126;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004E;\nL_0038:\n\tv102 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv118 = v102 == 0;\n\tif (v118) goto L_0043;\nL_006A:\n\tv132 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = 0x8BF0368(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = 0xA1B8(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004E:\n\tv94 = new System.NullReferenceException();\n\tgoto L_005A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetAllLandscapeRight()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::SetAllLandscapeRight");
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3C32BE0", Offset = "0x3C32BE0", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv71.m_Active = 1;\n\tgoto L_0038;\nL_0043:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004B:\n\treturn;\nL_005A:\n\tv116 = Il2CppMethodInfo != 1;\n\tv129 = v94;\n\tif (v116) goto L_006A;\n\tv120 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v94);\n\tv136 = 0x8BF5BF4(v120, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv128 = ~v120.m_value;\n\tif (v128) goto L_004B;\n\tv126 = new System.OutOfMemoryException();\n\tv64 = v120.m_value;\n\tv129 = v126;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004E;\nL_0038:\n\tv102 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv118 = v102 == 0;\n\tif (v118) goto L_0043;\nL_006A:\n\tv132 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = 0x8BF0368(v129, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv179 = 0xA1B8(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004E:\n\tv94 = new System.NullReferenceException();\n\tgoto L_005A;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SelectAllResolutions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::SelectAllResolutions");
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3C32D1C", Offset = "0x3C32D1C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv60 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv81 = v60._list;\n\tv71 = v60.Current;\n\tv71.m_Active = 0;\n\tgoto L_0037;\nL_0042:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_004A:\n\treturn;\nL_0059:\n\tv115 = Il2CppMethodInfo != 1;\n\tv128 = v93;\n\tif (v115) goto L_0069;\n\tv119 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v93);\n\tv135 = 0x8BF5BF4(v119, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv127 = ~v119.m_value;\n\tif (v127) goto L_004A;\n\tv125 = new System.OutOfMemoryException();\n\tv64 = v119.m_value;\n\tv128 = v125;\n\treturn;\nL_001D:\n\tv81 = 0;\n\tv47 = this.m_Resolutions == 0;\n\tv64 = 0;\n\tif (v47) goto L_004D;\nL_0037:\n\tv101 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v81 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv117 = v101 == 0;\n\tif (v117) goto L_0042;\nL_0069:\n\tv131 = 0x3176EC8(&v64 @ stack_-58_v1 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv137 = 0x8BF0368(v128, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv178 = 0xA1B8(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004D:\n\tv93 = new System.NullReferenceException();\n\tgoto L_0059;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearAllResolutions()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::ClearAllResolutions");
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x3C32E54", Offset = "0x3C32E54", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::Clear(v38);\n\tv53 = v38.Count < 1;\n\tif (v53) goto L_0035;\n\treturn;\nL_0035:\n\treturn;\nL_0012:\n\tv38 = this.m_Resolutions;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAllResolutions()
		{
			List<ScreenshotResolution> resolutions = m_Resolutions;
			resolutions.Clear();
			if (resolutions.Count < 1)
			{
			}
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x3C32EC8", Offset = "0x3C32EC8", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0040;\nL_0051:\n\tv94 = System.Linq.Enumerable::Where(this.m_Compositions, v89);\n\treturnVal1 = System.Linq.Enumerable::ToList(v94);\n\treturn returnVal1;\nL_0029:\n\tgoto L_0032;\nL_0040:\n\tv105 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotComposition, System.Boolean>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotComposition, System.Boolean>::.ctor(v105, v100.<>9, Il2CppMethodInfo);\n\tv122.<>9__57_0 = v105;\n\tv89 = v105;\nL_0032:\n\tv66 = v64.<>9__57_0 == 0;\n\tv67 = ~v66;\n\tv89 = v64.<>9__57_0;\n\tif (v67) goto L_0051;\n")]
		public List<ScreenshotComposition> GetActiveCompositions()
		{
			bool flag = _003C_003Ec._003C_003E9__57_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__57_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__57_0 = (ScreenshotComposition x) => x.m_Active);
			}
			IEnumerable<object> source = m_Compositions.Where(predicate);
			return (List<ScreenshotComposition>)(object)source.ToList();
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x3C32FEC", Offset = "0x3C32FEC", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0040;\nL_0051:\n\tv94 = System.Linq.Enumerable::Where(this.m_Batches, v89);\n\treturnVal1 = System.Linq.Enumerable::ToList(v94);\n\treturn returnVal1;\nL_0029:\n\tgoto L_0032;\nL_0040:\n\tv105 = new System.Func`2<AlmostEngine.Screenshot.ScreenshotBatch, System.Boolean>();\n\tSystem.Func`2<AlmostEngine.Screenshot.ScreenshotBatch, System.Boolean>::.ctor(v105, v100.<>9, Il2CppMethodInfo);\n\tv122.<>9__61_0 = v105;\n\tv89 = v105;\nL_0032:\n\tv66 = v64.<>9__61_0 == 0;\n\tv67 = ~v66;\n\tv89 = v64.<>9__61_0;\n\tif (v67) goto L_0051;\n")]
		public List<ScreenshotBatch> GetActiveBatches()
		{
			bool flag = _003C_003Ec._003C_003E9__61_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__61_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__61_0 = (ScreenshotBatch x) => x.m_Active);
			}
			IEnumerable<object> source = m_Batches.Where(predicate);
			return (List<ScreenshotBatch>)(object)source.ToList();
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x3C33110", Offset = "0x3C33110", Length = "0x4A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv68 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch>::GetEnumerator(this.m_Batches);\n\tv77 = v68.Current;\n\tv92 = v68._list;\n\tv308 = v68.Current == 0;\n\tif (v308) goto L_012B;\n\tv318 = this.m_Resolutions;\n\tv309 = this.m_Resolutions == 0;\n\tif (v309) goto L_012D;\n\tAlmostEngine.ListExtras::Resize(v77.m_ActiveResolutions, v318.Count, 0);\n\tv427 = this.m_Resolutions;\n\tv403 = this.m_Resolutions == 0;\n\tif (v403) goto L_0111;\n\tv323 = 0;\n\tv429 = v77.m_ActiveResolutions;\n\tv297 = v77.m_ActiveResolutions == 0;\n\tif (v297) goto L_0113;\n\tv179 = v323 >= v429.Count;\n\tif (v179) goto L_00B2;\n\tv437 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::get_Item(v77.m_ActiveResolutions, v323);\n\tv302 = this.m_Resolutions == 0;\n\tif (v302) goto L_011F;\n\tv447 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::get_Item(this.m_Resolutions, v323);\n\tv300 = v447 == 0;\n\tif (v300) goto L_011B;\n\tv460 = AlmostEngine.Screenshot.ScreenshotResolution::ToString(v447);\n\tv301 = v437 == 0;\n\tif (v301) goto L_011D;\n\tv437.m_Name = v460;\n\tv299 = v77.m_ActiveResolutions == 0;\n\tif (v299) goto L_0119;\n\tv410 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::get_Item(v77.m_ActiveResolutions, v323);\n\tv298 = v410 == 0;\n\tif (v298) goto L_0117;\n\tv410.m_Id = v323;\n\tv323 = v323 + 1;\n\tv427 = this.m_Resolutions;\n\tv468 = this.m_Resolutions == 0;\n\tv411 = ~v468;\n\tif (v411) goto L_007B;\n\tgoto L_0111;\nL_00B2:\n\tv319 = this.m_Compositions;\n\tv310 = this.m_Compositions == 0;\n\tif (v310) goto L_012F;\n\tAlmostEngine.ListExtras::Resize(v77.m_ActiveCompositions, v319.Count, 0);\n\tv457 = this.m_Compositions;\n\tv439 = this.m_Compositions == 0;\n\tif (v439) goto L_00FA;\n\tv160 = 0;\n\tv152 = v77.m_ActiveCompositions;\n\tv155 = v77.m_ActiveCompositions == 0;\n\tif (v155) goto L_0115;\n\tv109 = v160 >= v152.Count;\n\tif (v109) goto L_005E;\n\tv464 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::get_Item(v77.m_ActiveCompositions, v160);\n\tv304 = this.m_Compositions == 0;\n\tif (v304) goto L_0123;\n\tv467 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotComposition>::get_Item(this.m_Compositions, v160);\n\tv303 = v467 == 0;\n\tif (v303) goto L_0121;\n\tv306 = v464 == 0;\n\tif (v306) goto L_0127;\n\tv464.m_Name = v467.m_Name;\n\tv305 = v77.m_ActiveCompositions == 0;\n\tif (v305) goto L_0125;\n\tv443 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::get_Item(v77.m_ActiveCompositions, v160);\n\tv307 = v443 == 0;\n\tif (v307) goto L_0129;\n\tv443.m_Id = v160;\n\tv160 = v160 + 1;\n\tv457 = this.m_Compositions;\n\tv472 = this.m_Compositions == 0;\n\tv444 = ~v472;\n\tif (v444) goto L_00C8;\nL_00FA:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\n\treturn;\nL_0111:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0113:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0115:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0117:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0119:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_011B:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_011D:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_011F:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0121:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0123:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0125:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0127:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0129:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_012B:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_012D:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_012F:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0131:\n\tv69 = new System.NullReferenceException();\n\tgoto L_018E;\nL_0134:\n\tv293 = new System.OutOfMemoryException();\n\tv69 = v293;\n\tgoto L_018E;\nL_018E:\n\t// 398 Interrupt\n\tv327 = 0x8BF5BF4(v69, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv334 = 0x8BF0368(v69, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv339 = 0xA1B8(v334, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_003C:\n\tv59 = this.m_Batches == 0;\n\tif (v59) goto L_0131;\nL_007B:\n\tv178 = v323 >= v427.Count;\n\tif (v178) goto L_00B2;\nL_005E:\n\tv163 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v92 @ stack_-80_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch>));\n\tv332 = v163 == 0;\n\tif (v332) goto L_00FF;\nL_00C8:\n\tv108 = v160 >= v457.Count;\n\tif (v108) goto L_005E;\nL_00FF:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v92 @ stack_-80_v3 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch>));\n\tgoto L_0134;\n")]
		public unsafe void UpdateBatchesData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::UpdateBatchesData");
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x3C335B4", Offset = "0x3C335B4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.m_Time == time;\n\tv11 = ~v4;\n\tif (v11) goto L_000C;\n\treturn;\nL_000C:\n\tthis.m_Time = time;\n\tUnityEngine.Time::set_timeScale(time);\n\treturn;\n")]
		public void SetTime(float time)
		{
			if (m_Time != time)
			{
				m_Time = time;
				Time.timeScale = time;
			}
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3C335D0", Offset = "0x3C335D0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.m_Time == 0;\n\tv8 = ~v3;\n\tif (v8) goto L_FFFFFFFF;\n\tv11 = this.m_Time == 1f;\n\tv18 = ~v11;\nL_FFFFFFFF:\n\tv22 = 1f;\n\tif (v18) goto L_0016;\n\treturn;\nL_FFFFFFFF:\n\tv22 = 0;\nL_0016:\n\tthis.m_Time = v22;\n\tUnityEngine.Time::set_timeScale(v22);\n\treturn;\n")]
		public void TogglePause()
		{
			float num;
			if (m_Time == 0f)
			{
				bool flag = m_Time == 1f;
				bool flag2 = !flag;
				num = 1f;
				if (!flag2)
				{
					return;
				}
			}
			else
			{
				num = 0f;
			}
			m_Time = num;
			Time.timeScale = num;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3C335FC", Offset = "0x3C335FC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv46.m_Texture = 0;\n\tv84 = this.m_Resolutions == 0;\n\tv59 = 0;\n\tv77 = Il2CppMethodInfo;\n\tif (v84) goto L_0057;\n\tv102 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(this.m_Resolutions);\n\tv74 = v102._list;\n\tv64 = v102.Current;\n\tv64.m_Texture = 0;\n\tgoto L_003E;\nL_004C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_0054:\n\treturn;\nL_0064:\n\tv113 = v77 != 1;\n\tv124 = v91;\n\tif (v113) goto L_0074;\n\tv115 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>+Enumerator<AlmostEngine.Screenshot.ScreenshotResolution>::MoveNext(v91);\n\tv136 = 0x8BF5BF4(v115, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v74 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv123 = ~v115.m_value;\n\tif (v123) goto L_0054;\n\tv121 = new System.OutOfMemoryException();\n\tv59 = v115.m_value;\n\tv124 = v121;\n\treturn;\nL_001D:\n\tv74 = 0;\n\tv46 = this.m_GameViewResolution;\n\tv47 = this.m_GameViewResolution == 0;\n\tv77 = 0;\n\tif (v47) goto L_0057;\nL_0057:\n\tv91 = new System.NullReferenceException();\n\tgoto L_0064;\nL_003E:\n\tv134 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v74 @ stack_-48_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv140 = v134 == 0;\n\tif (v140) goto L_004C;\nL_0074:\n\tv127 = 0x3176EC8(&v59 @ stack_-58 (System.Boolean), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = 0x8BF0368(v124, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv142 = 0xA1B8(v138, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::ClearCache");
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3C33754", Offset = "0x3C33754", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this);\n\treturn;\n")]
		public void ShareAll()
		{
			List<ScreenshotResolution> activeResolutions = GetActiveResolutions();
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x3C33758", Offset = "0x3C33758", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Share(List<ScreenshotResolution> resolutions)
		{
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x3C3375C", Offset = "0x3C3375C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = AlmostEngine.Screenshot.ScreenshotConfig::GetActiveResolutions(this);\n\tAlmostEngine.Screenshot.ScreenshotConfig::ExportToFiles(this, v12);\n\treturn;\n")]
		public void ExportAllToFiles()
		{
			List<ScreenshotResolution> activeResolutions = GetActiveResolutions();
			ExportToFiles(activeResolutions);
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x3C33784", Offset = "0x3C33784", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_001E;\nL_001E:\n\tv81 = System.DateTime::get_Now();\n\tv94 = System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>::GetEnumerator(resolutions);\n\tv107 = v94.Current;\n\tv110 = v94._list;\nL_FFFFFFFF:\n\tv129 = methodInfo;\n\tv309 = new AlmostEngine.Screenshot.ScreenshotConfig+<>c__DisplayClass80_0();\n\tSystem.Object::.ctor(v309);\n\tv142 = this.m_DestinationFolder != 0;\n\tif (v142) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv197 = 0x20;\n\tgoto L_0059;\nL_FFFFFFFF:\n\tv197 = 0x18;\n\tv107.m_FileName = v191;\n\tv309.filename = v107.m_FileName;\n\tv473 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v473, v309, Il2CppMethodInfo);\n\tv480 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v480, v309, Il2CppMethodInfo);\n\tv233 = this.m_JPGQuality == 0x7F800000;\n\tv223 = ~v233;\n\tif (v223) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv215 = 0xFFFFFFFF80000000;\n\tgoto L_00A1;\nL_FFFFFFFF:\n\tv215 = this.m_JPGQuality;\nL_00A7:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v110 @ stack_-90_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\nL_00B7:\n\treturn;\nL_00E1:\n\tv201 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv391 = 0;\n\tgoto L_00E4;\nL_00E4:\n\t// 228 Interrupt\n\tgoto L_00F6;\nL_00F6:\n\tv323 = v191 != 1;\n\tif (v323) goto L_0107;\n\tv390 = 0x8BF5BC4(clobbered_X0, v191, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv452 = 0x8BF5BF4(v390, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v110 @ stack_-90_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv368 = *([v390 @ X0_v8]) == 0;\n\tif (v368) goto L_00B7;\n\tv394 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv391 = *([v390 @ X0_v8]);\nL_0107:\n\tv400 = 0x3176EC8(&v391 @ stack_-A8_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv454 = 0x8BF0368(v394, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv444 = 0xA1B8(v454, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0059:\n\t;\n\tv191 = AlmostEngine.Screenshot.ScreenshotNameParser::ParseFileName(this.m_FileName, v94.Current, v129, *([this @ X0 (AlmostEngine.Screenshot.ScreenshotConfig)+v197 @ X8_v27 (System.Int32)]), this.m_FileFormat, this.m_OverwriteFiles, v81, this.m_NumberLeftPadding);\n\tv193 = v94.Current == 0;\n\tif (v193) goto L_00E1;\nL_00A1:\n\tv244 = AlmostEngine.Screenshot.TextureExporter::ExportToFile(v107.m_Texture, v309.filename, this.m_FileFormat, v215, 1, this.m_ExportAsync, v473, v480);\nL_FFFFFFFF:\n\tv129 = this.m_FileFormat;\n\tgoto L_003B;\nL_003B:\n\tv256 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v110 @ stack_-90_v4 (System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotResolution>));\n\tv261 = v256 == 0;\n\tif (v261) goto L_00A7;\n")]
		public unsafe void ExportToFiles(List<ScreenshotResolution> resolutions)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ScreenshotConfig::ExportToFiles");
		}
	}
}
