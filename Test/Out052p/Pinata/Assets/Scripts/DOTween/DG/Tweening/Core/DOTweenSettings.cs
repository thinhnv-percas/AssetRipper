using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core.Enums;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x200004D")]
	public class DOTweenSettings : ScriptableObject
	{
		[Token(Token = "0x20000B7")]
		public enum SettingsLocation
		{
			[Token(Token = "0x4000246")]
			AssetsDirectory = 0,
			[Token(Token = "0x4000247")]
			DOTweenDirectory = 1,
			[Token(Token = "0x4000248")]
			DemigiantDirectory = 2
		}

		[Serializable]
		[Token(Token = "0x20000B8")]
		public class SafeModeOptions
		{
			[Token(Token = "0x4000249")]
			[FieldOffset(Offset = "0x10")]
			public NestedTweenFailureBehaviour nestedTweenFailureBehaviour;

			[Token(Token = "0x6000416")]
			[Address(RVA = "0x1071F34", Offset = "0x1071F34", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SafeModeOptions()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000B9")]
		public class ModulesSetup
		{
			[Token(Token = "0x400024A")]
			[FieldOffset(Offset = "0x10")]
			public bool showPanel;

			[Token(Token = "0x400024B")]
			[FieldOffset(Offset = "0x11")]
			public bool audioEnabled;

			[Token(Token = "0x400024C")]
			[FieldOffset(Offset = "0x12")]
			public bool physicsEnabled;

			[Token(Token = "0x400024D")]
			[FieldOffset(Offset = "0x13")]
			public bool physics2DEnabled;

			[Token(Token = "0x400024E")]
			[FieldOffset(Offset = "0x14")]
			public bool spriteEnabled;

			[Token(Token = "0x400024F")]
			[FieldOffset(Offset = "0x15")]
			public bool uiEnabled;

			[Token(Token = "0x4000250")]
			[FieldOffset(Offset = "0x16")]
			public bool textMeshProEnabled;

			[Token(Token = "0x4000251")]
			[FieldOffset(Offset = "0x17")]
			public bool tk2DEnabled;

			[Token(Token = "0x6000417")]
			[Address(RVA = "0x1071F3C", Offset = "0x1071F3C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.uiEnabled = 1;\n\tthis.audioEnabled = 0x1010101;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ModulesSetup()
			{
				uiEnabled = true;
				audioEnabled = true;
				physicsEnabled = true;
				physics2DEnabled = true;
				spriteEnabled = true;
			}
		}

		[Token(Token = "0x400013C")]
		public const string AssetName = "DOTweenSettings";

		[Token(Token = "0x400013D")]
		public const string AssetFullFilename = "DOTweenSettings.asset";

		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x18")]
		public bool useSafeMode;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x20")]
		public SafeModeOptions safeModeOptions;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x28")]
		public float timeScale;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x2C")]
		public bool useSmoothDeltaTime;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x30")]
		public float maxSmoothUnscaledTime;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x34")]
		public RewindCallbackMode rewindCallbackMode;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x38")]
		public bool showUnityEditorReport;

		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x3C")]
		public LogBehaviour logBehaviour;

		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x40")]
		public bool drawGizmos;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x41")]
		public bool defaultRecyclable;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x44")]
		public AutoPlay defaultAutoPlay;

		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x48")]
		public UpdateType defaultUpdateType;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x4C")]
		public bool defaultTimeScaleIndependent;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x50")]
		public Ease defaultEaseType;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x54")]
		public float defaultEaseOvershootOrAmplitude;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x58")]
		public float defaultEasePeriod;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x5C")]
		public bool defaultAutoKill;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x60")]
		public LoopType defaultLoopType;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x64")]
		public bool showPreviewPanel;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x68")]
		public SettingsLocation storeSettingsLocation;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x70")]
		public ModulesSetup modules;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x78")]
		public bool showPlayingTweens;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x79")]
		public bool showPausedTweens;

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x1071E58", Offset = "0x1071E58", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EADE48]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2026992]) = v40;\nL_0015:\n\tthis.useSafeMode = 1;\n\tv45 = new DG.Tweening.Core.DOTweenSettings+SafeModeOptions();\n\tSystem.Object::.ctor(v45);\n\tthis.timeScale = 1f;\n\tthis.defaultAutoPlay = 3;\n\tthis.maxSmoothUnscaledTime = 0.15f;\n\tthis.safeModeOptions = v45;\n\tthis.drawGizmos = 1;\n\tthis.defaultAutoKill = 1;\n\tthis.showPreviewPanel = 1;\n\tthis.defaultEaseType = 6;\n\tthis.defaultEaseOvershootOrAmplitude = 1.70158f;\n\tv58 = new DG.Tweening.Core.DOTweenSettings+ModulesSetup();\n\tv58.uiEnabled = 1;\n\tv58.audioEnabled = 0x1010101;\n\tSystem.Object::.ctor(v58);\n\tthis.modules = v58;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenSettings()
		{
			useSafeMode = true;
			SafeModeOptions safeModeOptions = new SafeModeOptions();
			timeScale = 1f;
			defaultAutoPlay = AutoPlay.All;
			maxSmoothUnscaledTime = 0.15f;
			this.safeModeOptions = safeModeOptions;
			drawGizmos = true;
			defaultAutoKill = true;
			showPreviewPanel = true;
			defaultEaseType = Ease.OutQuad;
			defaultEaseOvershootOrAmplitude = 1.70158f;
			ModulesSetup modulesSetup = new ModulesSetup();
			modulesSetup.uiEnabled = true;
			modulesSetup.audioEnabled = true;
			modulesSetup.physicsEnabled = true;
			modulesSetup.physics2DEnabled = true;
			modulesSetup.spriteEnabled = true;
			((ScriptableObject)(object)modulesSetup)._002Ector();
			modules = modulesSetup;
		}
	}
}
