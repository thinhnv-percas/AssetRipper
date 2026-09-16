using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000AC")]
	public class DOTweenSettings : ScriptableObject
	{
		[Token(Token = "0x20000AD")]
		public enum SettingsLocation
		{
			[Token(Token = "0x4000205")]
			AssetsDirectory = 0,
			[Token(Token = "0x4000206")]
			DOTweenDirectory = 1,
			[Token(Token = "0x4000207")]
			DemigiantDirectory = 2
		}

		[Serializable]
		[Token(Token = "0x20000AE")]
		public class SafeModeOptions
		{
			[Token(Token = "0x4000208")]
			[FieldOffset(Offset = "0x10")]
			public SafeModeLogBehaviour logBehaviour;

			[Token(Token = "0x4000209")]
			[FieldOffset(Offset = "0x14")]
			public NestedTweenFailureBehaviour nestedTweenFailureBehaviour;

			[Token(Token = "0x6000418")]
			[Address(RVA = "0xC2DE44", Offset = "0xC2DE44", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logBehaviour = 2;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SafeModeOptions()
			{
				logBehaviour = SafeModeLogBehaviour.Warning;
			}
		}

		[Serializable]
		[Token(Token = "0x20000AF")]
		public class ModulesSetup
		{
			[Token(Token = "0x400020A")]
			[FieldOffset(Offset = "0x10")]
			public bool showPanel;

			[Token(Token = "0x400020B")]
			[FieldOffset(Offset = "0x11")]
			public bool audioEnabled;

			[Token(Token = "0x400020C")]
			[FieldOffset(Offset = "0x12")]
			public bool physicsEnabled;

			[Token(Token = "0x400020D")]
			[FieldOffset(Offset = "0x13")]
			public bool physics2DEnabled;

			[Token(Token = "0x400020E")]
			[FieldOffset(Offset = "0x14")]
			public bool spriteEnabled;

			[Token(Token = "0x400020F")]
			[FieldOffset(Offset = "0x15")]
			public bool uiEnabled;

			[Token(Token = "0x4000210")]
			[FieldOffset(Offset = "0x16")]
			public bool textMeshProEnabled;

			[Token(Token = "0x4000211")]
			[FieldOffset(Offset = "0x17")]
			public bool tk2DEnabled;

			[Token(Token = "0x4000212")]
			[FieldOffset(Offset = "0x18")]
			public bool deAudioEnabled;

			[Token(Token = "0x4000213")]
			[FieldOffset(Offset = "0x19")]
			public bool deUnityExtendedEnabled;

			[Token(Token = "0x4000214")]
			[FieldOffset(Offset = "0x1A")]
			public bool epoOutlineEnabled;

			[Token(Token = "0x6000419")]
			[Address(RVA = "0xC2DE54", Offset = "0xC2DE54", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uiEnabled = 0x1010101;\n\tthis.audioEnabled = 0x1010101;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ModulesSetup()
			{
				uiEnabled = true;
				audioEnabled = true;
				physicsEnabled = true;
				physics2DEnabled = true;
				spriteEnabled = true;
			}
		}

		[Token(Token = "0x40001E7")]
		public const string AssetName = "DOTweenSettings";

		[Token(Token = "0x40001E8")]
		public const string AssetFullFilename = "DOTweenSettings.asset";

		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x18")]
		public bool useSafeMode;

		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x20")]
		public SafeModeOptions safeModeOptions;

		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x28")]
		public float timeScale;

		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x2C")]
		public float unscaledTimeScale;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x30")]
		public bool useSmoothDeltaTime;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x34")]
		public float maxSmoothUnscaledTime;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x38")]
		public RewindCallbackMode rewindCallbackMode;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x3C")]
		public bool showUnityEditorReport;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x40")]
		public LogBehaviour logBehaviour;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x44")]
		public bool drawGizmos;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x45")]
		public bool defaultRecyclable;

		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x48")]
		public AutoPlay defaultAutoPlay;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x4C")]
		public UpdateType defaultUpdateType;

		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x50")]
		public bool defaultTimeScaleIndependent;

		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x54")]
		public Ease defaultEaseType;

		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x58")]
		public float defaultEaseOvershootOrAmplitude;

		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x5C")]
		public float defaultEasePeriod;

		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x60")]
		public bool defaultAutoKill;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x64")]
		public LoopType defaultLoopType;

		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x68")]
		public bool debugMode;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x69")]
		public bool debugStoreTargetId;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x6A")]
		public bool showPreviewPanel;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x6C")]
		public SettingsLocation storeSettingsLocation;

		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x70")]
		public ModulesSetup modules;

		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x78")]
		public bool createASMDEF;

		[Token(Token = "0x4000202")]
		[FieldOffset(Offset = "0x79")]
		public bool showPlayingTweens;

		[Token(Token = "0x4000203")]
		[FieldOffset(Offset = "0x7A")]
		public bool showPausedTweens;

		[Token(Token = "0x6000417")]
		[Address(RVA = "0xC2DD58", Offset = "0xC2DD58", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = DG.Tweening.Core.DOTweenSettings+ModulesSetup;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = DG.Tweening.Core.DOTweenSettings+SafeModeOptions;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A357E5]) = v42;\nL_001A:\n\tthis.useSafeMode = 1;\n\tv45 = new DG.Tweening.Core.DOTweenSettings+SafeModeOptions();\n\tv45.logBehaviour = 2;\n\tSystem.Object::.ctor(v45);\n\tthis.safeModeOptions = v45;\n\tthis.drawGizmos = 1;\n\tthis.defaultAutoKill = 1;\n\tthis.timeScale = 0f;\n\tthis.maxSmoothUnscaledTime = 0.15f;\n\tthis.defaultAutoPlay = 3;\n\tthis.defaultEaseType = 0x3FD9CD6000000006;\n\tthis.debugStoreTargetId = 0x101;\n\tv60 = new DG.Tweening.Core.DOTweenSettings+ModulesSetup();\n\tv60.audioEnabled = 0x1010101;\n\tv60.uiEnabled = 0x1010101;\n\tSystem.Object::.ctor(v60);\n\tthis.modules = v60;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenSettings()
		{
			//IL_00dd: Expected I4, but got I8
			base._002Ector();
			useSafeMode = true;
			safeModeOptions = new SafeModeOptions
			{
				logBehaviour = SafeModeLogBehaviour.Warning
			};
			drawGizmos = true;
			defaultAutoKill = true;
			timeScale = 0f;
			maxSmoothUnscaledTime = 0.15f;
			defaultAutoPlay = AutoPlay.All;
			defaultEaseType = Ease.OutQuad;
			debugStoreTargetId = true;
			showPreviewPanel = true;
			ModulesSetup modulesSetup = new ModulesSetup();
			modulesSetup.audioEnabled = true;
			modulesSetup.physicsEnabled = true;
			modulesSetup.physics2DEnabled = true;
			modulesSetup.spriteEnabled = true;
			modulesSetup.uiEnabled = true;
			((ScriptableObject)(object)modulesSetup)._002Ector();
			modules = modulesSetup;
		}
	}
}
