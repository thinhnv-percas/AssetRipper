using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;

namespace DG.Tweening
{
	[Token(Token = "0x200006F")]
	public abstract class Tween : ABSSequentiable
	{
		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x28")]
		public float timeScale;

		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x2C")]
		public bool isBackwards;

		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x2D")]
		internal bool isInverted;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x30")]
		public object id;

		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x38")]
		public string stringId;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x40")]
		public int intId;

		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x48")]
		public object target;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x50")]
		internal UpdateType updateType;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x54")]
		internal bool isIndependentUpdate;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x58")]
		public TweenCallback onPlay;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x60")]
		public TweenCallback onPause;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x68")]
		public TweenCallback onRewind;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x70")]
		public TweenCallback onUpdate;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x78")]
		public TweenCallback onStepComplete;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x80")]
		public TweenCallback onComplete;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x88")]
		public TweenCallback onKill;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x90")]
		public TweenCallback<int> onWaypointChange;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x98")]
		internal bool isFrom;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x99")]
		internal bool isBlendable;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x9A")]
		internal bool isRecyclable;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x9B")]
		internal bool isSpeedBased;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x9C")]
		internal bool autoKill;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0xA0")]
		internal float duration;

		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0xA4")]
		internal int loops;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0xA8")]
		internal LoopType loopType;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0xAC")]
		internal float delay;

		[CompilerGenerated]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0xB0")]
		internal bool _003CisRelative_003Ek__BackingField;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0xB4")]
		internal Ease easeType;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0xB8")]
		internal EaseFunction customEase;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0xC0")]
		public float easeOvershootOrAmplitude;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0xC4")]
		public float easePeriod;

		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0xC8")]
		public string debugTargetId;

		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0xD0")]
		internal Type typeofT1;

		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0xD8")]
		internal Type typeofT2;

		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0xE0")]
		internal Type typeofTPlugOptions;

		[CompilerGenerated]
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0xE8")]
		internal bool _003Cactive_003Ek__BackingField;

		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0xE9")]
		internal bool isSequenced;

		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0xF0")]
		internal Sequence sequenceParent;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0xF8")]
		internal int activeId;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0xFC")]
		internal SpecialStartupMode specialStartupMode;

		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x100")]
		internal bool creationLocked;

		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x101")]
		internal bool startupDone;

		[CompilerGenerated]
		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x102")]
		private bool _003CplayedOnce_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x104")]
		internal float _003Cposition_003Ek__BackingField;

		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x108")]
		internal float fullDuration;

		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x10C")]
		internal int completedLoops;

		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x110")]
		internal bool isPlaying;

		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x111")]
		internal bool isComplete;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x114")]
		internal float elapsedDelay;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x118")]
		internal bool delayComplete;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x11C")]
		internal int miscInt;

		[Token(Token = "0x17000004")]
		public bool isRelative
		{
			[CompilerGenerated]
			[Token(Token = "0x6000295")]
			[Address(RVA = "0xC1C8A0", Offset = "0xC1C8A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<isRelative>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isRelative;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000296")]
			[Address(RVA = "0xC1C8A8", Offset = "0xC1C8A8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<isRelative>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				_003CisRelative_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000005")]
		public bool active
		{
			[CompilerGenerated]
			[Token(Token = "0x6000297")]
			[Address(RVA = "0xC1C8B4", Offset = "0xC1C8B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<active>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return active;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000298")]
			[Address(RVA = "0xC1C8BC", Offset = "0xC1C8BC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<active>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				_003Cactive_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000006")]
		public float fullPosition
		{
			[Token(Token = "0x6000299")]
			[Address(RVA = "0xC1C8C8", Offset = "0xC1C8C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.TweenExtensions::Elapsed(this, 1);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return this.Elapsed();
			}
			[Token(Token = "0x600029A")]
			[Address(RVA = "0xC1C8D0", Offset = "0xC1C8D0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::DoGoto(this, value, this.isPlaying, 0);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				TweenExtensions.DoGoto(this, value, isPlaying, withCallbacks: false);
			}
		}

		[Token(Token = "0x17000007")]
		public bool hasLoops
		{
			[Token(Token = "0x600029B")]
			[Address(RVA = "0xC0CE8C", Offset = "0xC0CE8C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.loops + 1;\n\tv4 = v2 == 0;\n\tv10 = this.loops - 1;\n\tv11 = v10 < 0;\n\tv12 = v10 == 0;\n\tv13 = this.loops ^ 1;\n\tv14 = this.loops ^ v10;\n\tv15 = v13 & v14;\n\tv16 = v15 < 0;\n\tv17 = v11 == v16;\n\tv18 = ~v12;\n\tv19 = v17 & v18;\n\treturnVal1 = v4 | v19;\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				int num = loops + 1;
				bool flag = num == 0;
				int num2 = loops - 1;
				bool flag2 = num2 < 0;
				bool flag3 = num2 == 0;
				int num3 = loops ^ 1;
				int num4 = loops ^ num2;
				int num5 = num3 & num4;
				bool flag4 = num5 < 0;
				bool flag5 = flag2 == flag4;
				bool flag6 = !flag3;
				bool flag7 = flag5 && flag6;
				return flag || flag7;
			}
		}

		[Token(Token = "0x17000008")]
		public bool playedOnce
		{
			[CompilerGenerated]
			[Token(Token = "0x600029C")]
			[Address(RVA = "0xC1C8DC", Offset = "0xC1C8DC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<playedOnce>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return playedOnce;
			}
			[CompilerGenerated]
			[Token(Token = "0x600029D")]
			[Address(RVA = "0xC1C8E4", Offset = "0xC1C8E4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<playedOnce>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CplayedOnce_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000009")]
		public float position
		{
			[CompilerGenerated]
			[Token(Token = "0x600029E")]
			[Address(RVA = "0xC1C8F0", Offset = "0xC1C8F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<position>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return position;
			}
			[CompilerGenerated]
			[Token(Token = "0x600029F")]
			[Address(RVA = "0xC1C8F8", Offset = "0xC1C8F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<position>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003Cposition_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xC0EA54", Offset = "0xC0EA54", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeScale = 1f;\n\tthis.intId = 0xFFFFFC19;\n\tthis.duration = 0f;\n\tthis.isBackwards = 0;\n\tthis.id = 0;\n\tthis.stringId = 0;\n\tthis.isIndependentUpdate = 0;\n\tthis.onPlay = 0;\n\tthis.onStart = 0;\n\tthis.debugTargetId = 0;\n\tthis.target = 0;\n\tthis.isSpeedBased = 0;\n\tthis.isFrom = 0;\n\tthis.delay = 0f;\n\tthis.<isRelative>k__BackingField = 0;\n\tthis.customEase = 0;\n\tthis.isSequenced = 0;\n\tthis.sequenceParent = 0;\n\tthis.elapsedDelay = 0f;\n\t*([this @ X0 (DG.Tweening.Tween)+FF]) = 0;\n\tthis.specialStartupMode = 0;\n\tthis.onRewind = 0;\n\tthis.onStepComplete = 0;\n\tthis.onKill = 0;\n\tthis.<position>k__BackingField = 0f;\n\t*([this @ X0 (DG.Tweening.Tween)+10A]) = 0;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal virtual void Reset()
		{
			timeScale = 1f;
			intId = -999;
			duration = 0f;
			isBackwards = false;
			id = null;
			stringId = null;
			isIndependentUpdate = false;
			onPlay = null;
			onStart = null;
			debugTargetId = null;
			target = null;
			isSpeedBased = false;
			isFrom = false;
			isBlendable = false;
			delay = 0f;
			isRelative = false;
			customEase = null;
			isSequenced = false;
			sequenceParent = null;
			elapsedDelay = 0f;
			_ = 0;
			specialStartupMode = default(SpecialStartupMode);
			onRewind = null;
			onStepComplete = null;
			onKill = null;
			position = 0f;
			_ = 0;
			delayComplete = true;
			miscInt = -1;
		}

		[Token(Token = "0x60002A1")]
		internal abstract bool Validate();

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xC1C900", Offset = "0xC1C900", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal virtual float UpdateDelay(float elapsed)
		{
			return 0f;
		}

		[Token(Token = "0x60002A3")]
		internal abstract bool Startup();

		[Token(Token = "0x60002A4")]
		internal abstract bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice);

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0xC1C908", Offset = "0xC1C908", Length = "0x36C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = ~t.startupDone;\n\tv31 = ~v30;\n\tif (v31) goto L_001D;\n\tv49 = DG.Tweening.Tween::Startup(t);\n\tv51 = v49 == 0;\n\tif (v51) goto L_FFFFFFFF;\nL_001D:\n\tv58 = updateMode == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_003A;\n\tv148 = ~t.<playedOnce>k__BackingField;\n\tv149 = ~v148;\n\tif (v149) goto L_003A;\n\tt.<playedOnce>k__BackingField = 1;\n\tv300 = t.onStart == 0;\n\tif (v300) goto L_002F;\n\tv134 = DG.Tweening.Tween::OnTweenCallback(t.onStart, t);\n\tv144 = ~t.<active>k__BackingField;\n\tif (v144) goto L_FFFFFFFF;\nL_002F:\n\tv157 = t.onPlay == 0;\n\tif (v157) goto L_003A;\n\tv135 = DG.Tweening.Tween::OnTweenCallback(t.onPlay, t);\n\tv145 = ~t.<active>k__BackingField;\n\tif (v145) goto L_FFFFFFFF;\nL_003A:\n\tv159 = t.<position>k__BackingField < 0;\n\tv160 = ~v159;\n\tv163 = t.<position>k__BackingField == 0;\n\tv168 = ~v163;\n\tv169 = v160 & v168;\n\tv174 = t.completedLoops < 0;\n\tv175 = t.completedLoops == 0;\n\tv177 = t.completedLoops ^ t.completedLoops;\n\tv178 = t.completedLoops & v177;\n\tv179 = v178 < 0;\n\tv180 = v174 == v179;\n\tv181 = ~v175;\n\tv182 = v180 & v181;\n\tv184 = t.loops + 1;\n\tv186 = v184 == 0;\n\tt.completedLoops = toCompletedLoops;\n\tif (v186) goto L_0066;\n\tv303 = t.loops - toCompletedLoops;\n\tv305 = v303 == 0;\n\tt.isComplete = v305;\nL_0066:\n\tv320 = v169 | v182;\n\tv321 = updateMode == 0;\n\tif (v321) goto L_0087;\n\tv334 = t.tweenType != 1;\n\tif (v334) goto L_FFFFFFFF;\n\tv346 = t.completedLoops - toCompletedLoops;\n\tv347 = t.completedLoops >= toCompletedLoops;\n\tif (v347) goto L_FFFFFFFF;\n\tv80 = -v346;\n\tgoto L_0085;\nL_0085:\n\tgoto L_00C9;\nL_0087:\n\tv336 = ~t.isBackwards;\n\tif (v336) goto L_00A9;\n\tv384 = t.completedLoops - toCompletedLoops;\n\tv361 = t.completedLoops > toCompletedLoops;\n\tif (v361) goto L_00C0;\n\tv416 = toPosition < 0;\n\tv417 = ~v416;\n\tv420 = toPosition == 0;\n\tv425 = ~v417;\n\tv426 = v425 | v420;\n\tif (v426) goto L_FFFFFFFF;\n\tgoto L_00C0;\n\tgoto L_00C9;\nL_00A9:\n\tv364 = toCompletedLoops - t.completedLoops;\n\tv365 = v364 < 0;\n\tv366 = v364 == 0;\n\tv367 = toCompletedLoops ^ t.completedLoops;\n\tv368 = toCompletedLoops ^ v364;\n\tv369 = v367 & v368;\n\tv370 = v369 < 0;\n\tv371 = toCompletedLoops - t.completedLoops;\n\tv372 = v365 == v370;\n\tv373 = ~v366;\n\tv374 = v372 & v373;\n\tv375 = ~v374;\n\tif (v375) goto L_FFFFFFFF;\n\tgoto L_00BA;\nL_00BA:\n\tgoto L_00C9;\nL_00C0:\n\tv397 = t.isComplete == 0;\n\tv387 = ~v397;\n\tv80 = v384 - v387;\nL_00C9:\n\tt.<position>k__BackingField = toPosition;\n\tv409 = t.duration < toPosition;\n\tif (v409) goto L_0105;\n\tv441 = toPosition < 0;\n\tv442 = ~v441;\n\tv445 = toPosition == 0;\n\tv450 = ~v445;\n\tv451 = v442 & v450;\n\tif (v451) goto L_0107;\n\tif (v311) goto L_FFFFFFFF;\n\tv498 = toCompletedLoops - 1;\n\tv470 = v498 < 0;\n\tv501 = toCompletedLoops ^ 1;\n\tv502 = toCompletedLoops ^ v498;\n\tv503 = v501 & v502;\n\tv460 = v503 < 0;\n\tgoto L_00FC;\nL_00FC:\n\tv539 = v470 == v460;\n\tv458 = ~v539;\n\tv456 = ~v458;\n\tif (v456) goto L_FFFFFFFF;\n\tgoto L_0105;\nL_0105:\n\tt.<position>k__BackingField = v452;\nL_0107:\n\tv495 = ~t.isPlaying;\n\tif (v495) goto L_0127;\n\tv510 = ~t.isBackwards;\n\tif (v510) goto L_0125;\n\tv544 = toCompletedLoops == 0;\n\tv549 = ~v544;\n\tv551 = v137 < 0;\n\tv552 = ~v551;\n\tv555 = v137 == 0;\n\tv560 = ~v555;\n\tv561 = v552 & v560;\n\tv512 = v549 | v561;\n\tgoto L_0126;\nL_0125:\n\tv564 = v311 ^ 1;\nL_0126:\n\tt.isPlaying = v512;\nL_0127:\n\tv533 = t.loops + 1;\n\tv535 = v533 == 0;\n\tif (v535) goto L_0143;\n\tv575 = t.loops < 2;\n\tif (v575) goto L_0156;\nL_0143:\n\tv595 = t.loopType != 1;\n\tif (v595) goto L_0156;\n\tv611 = v137 < t.duration;\n\tv618 = toCompletedLoops & 1;\n\tif (v611) goto L_0151;\n\tv618 = v618 ^ 1;\nL_0151:\n\tv694 = ~v320;\n\tv631 = ~v694;\n\tif (v631) goto L_0158;\n\tgoto L_FFFFFFFF;\nL_0156:\n\tv607 = ~v320;\n\tif (v607) goto L_FFFFFFFF;\nL_0158:\n\tv632 = t.loops + 1;\n\tv634 = v632 == 0;\n\tv637 = ~v634;\n\tv641 = t.loops - toCompletedLoops;\n\tv642 = v641 < 0;\n\tv643 = v641 == 0;\n\tv644 = t.loops ^ toCompletedLoops;\n\tv645 = t.loops ^ v641;\n\tv646 = v644 & v645;\n\tv647 = v646 < 0;\n\tv648 = v642 == v647;\n\tv649 = ~v648;\n\tv650 = v649 | v643;\n\tv652 = v637 & v650;\n\tv654 = v652 == 0;\n\tv655 = ~v654;\n\tif (v655) goto L_0189;\n\tv699 = t.completedLoops == toCompletedLoops;\n\tif (v699) goto L_0189;\n\tv713 = t.loopType == 0;\n\tif (v713) goto L_FFFFFFFF;\nL_0189:\n\tv661 = toCompletedLoops > 0;\n\tif (v661) goto L_FFFFFFFF;\n\tv734 = v137 < 0;\n\tv686 = ~v734;\n\tv677 = v137 == 0;\n\tv735 = ~v677;\n\tv662 = v686 & v735;\n\tif (v662) goto L_FFFFFFFF;\n\tgoto L_01A2;\nL_01A2:\n\tv133 = DG.Tweening.Tween::ApplyTween(t, t.<position>k__BackingField, t.completedLoops, v80, v76, updateMode, v74);\n\tv143 = v133 == 0;\n\tif (v143) goto L_01AC;\n\tgoto L_026F;\nL_01AC:\n\tv740 = updateMode == 2;\n\tif (v740) goto L_01B8;\n\tv746 = t.onUpdate == 0;\n\tif (v746) goto L_01B8;\n\tv750 = DG.Tweening.Tween::OnTweenCallback(t.onUpdate, t);\nL_01B8:\n\tv752 = t.<position>k__BackingField < 0;\n\tv753 = ~v752;\n\tv756 = t.<position>k__BackingField == 0;\n\tv761 = ~v756;\n\tv762 = v753 & v761;\n\tif (v762) goto L_01FD;\n\tv767 = t.completedLoops < 0;\n\tv768 = t.completedLoops == 0;\n\tv770 = t.completedLoops ^ t.completedLoops;\n\tv771 = t.completedLoops & v770;\n\tv772 = v771 < 0;\n\tv773 = v767 == v772;\n\tv774 = ~v768;\n\tv775 = v773 & v774;\n\tv777 = t.<position>k__BackingField < 0;\n\tv778 = ~v777;\n\tv781 = t.<position>k__BackingField == 0;\n\tv786 = ~v781;\n\tv787 = v778 & v786;\n\tv800 = t.completedLoops > 0;\n\tif (v800) goto L_01FD;\n\tv816 = v787 | v775;\n\tv819 = ~v816;\n\tif (v819) goto L_01FD;\n\tv818 = t.onRewind == 0;\n\tif (v818) goto L_01FD;\n\tv813 = DG.Tweening.Tween::OnTweenCallback(t.onRewind, t);\nL_01FD:\n\tv830 = v80 < 1;\n\tif (v830) goto L_022E;\n\tv831 = updateMode == 0;\n\tv832 = ~v831;\n\tif (v832) goto L_022E;\n\tv882 = t.onStepComplete == 0;\n\tif (v882) goto L_022E;\n\tv876 = DG.Tweening.Tween::OnTweenCallback(t.onStepComplete, t);\n\tv883 = ~t.<active>k__BackingField;\n\tif (v883) goto L_022E;\n\tv834 = v80 < 2;\n\tif (v834) goto L_022E;\nL_0219:\n\tv874 = DG.Tweening.Tween::OnTweenCallback(t.onStepComplete, t);\n\tv881 = ~t.<active>k__BackingField;\n\tif (v881) goto L_022E;\n\tv868 = v869 + 1;\n\tv833 = v869 < v80;\n\tif (v833) goto L_0219;\nL_022E:\n\tv887 = updateMode == 3;\n\tif (v887) goto L_0240;\n\tv890 = ~t.isComplete;\n\tif (v890) goto L_0240;\n\tv903 = ~t.isComplete;\n\tv899 = ~v903;\n\tif (v899) goto L_0240;\n\tv898 = t.onComplete == 0;\n\tif (v898) goto L_0240;\n\tv894 = DG.Tweening.Tween::OnTweenCallback(t.onComplete, t);\nL_0240:\n\tv901 = t.isPlaying ^ 0xFF;\n\tv902 = t.isPlaying & v901;\n\tv278 = v902 == 0;\n\tif (v278) goto L_0254;\n\tv905 = ~t.isComplete;\n\tif (v905) goto L_024F;\n\tv916 = ~t.autoKill;\n\tv915 = ~v916;\n\tif (v915) goto L_0254;\nL_024F:\n\tv914 = t.onPause == 0;\n\tif (v914) goto L_0254;\n\tv908 = DG.Tweening.Tween::OnTweenCallback(t.onPause, t);\nL_0254:\n\tv297 = ~t.autoKill;\n\tif (v297) goto L_FFFFFFFF;\n\tv279 = t.isComplete == 0;\n\tv269 = ~v279;\n\tgoto L_026F;\nL_026F:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 372 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoGoto(Tween t, float toPosition, int toCompletedLoops, UpdateMode updateMode)
		{
			if (!t.startupDone && !t.Startup())
			{
				goto IL_0920;
			}
			if (updateMode == UpdateMode.Update && !t.playedOnce)
			{
				t.playedOnce = true;
				if (t.onStart != null)
				{
					bool flag = OnTweenCallback(t.onStart, t);
					if (!t.active)
					{
						goto IL_0920;
					}
				}
				if (t.onPlay != null)
				{
					bool flag2 = OnTweenCallback(t.onPlay, t);
					if (!t.active)
					{
						goto IL_0920;
					}
				}
			}
			bool flag3 = t.position < 0f;
			bool flag4 = !flag3;
			bool flag5 = t.position == 0f;
			bool flag6 = !flag5;
			bool flag7 = flag4 && flag6;
			bool flag8 = t.completedLoops < 0;
			bool flag9 = t.completedLoops == 0;
			int num = t.completedLoops ^ t.completedLoops;
			int num2 = t.completedLoops & num;
			bool flag10 = num2 < 0;
			bool flag11 = flag8 == flag10;
			bool flag12 = !flag9;
			bool flag13 = flag11 && flag12;
			int num3 = t.loops + 1;
			bool flag14 = num3 == 0;
			t.completedLoops = toCompletedLoops;
			bool flag15 = t.isComplete;
			if (!flag14)
			{
				int num4 = t.loops - toCompletedLoops;
				flag15 = (t.isComplete = num4 == 0);
			}
			bool flag16 = flag7 || flag13;
			int num6;
			if (updateMode != UpdateMode.Update)
			{
				if (t.tweenType == TweenType.Sequence)
				{
					int num5 = t.completedLoops - toCompletedLoops;
					num6 = ((t.completedLoops >= toCompletedLoops) ? num5 : (-num5));
				}
				else
				{
					num6 = 0;
				}
			}
			else if (t.isBackwards)
			{
				int num7 = t.completedLoops - toCompletedLoops;
				if (t.completedLoops <= toCompletedLoops)
				{
					bool flag17 = toPosition < 0f;
					bool flag18 = !flag17;
					bool flag19 = toPosition == 0f;
					bool flag20 = !flag18;
					num7 = (((flag20 || flag19) && flag16) ? 1 : 0);
				}
				bool flag21 = !t.isComplete;
				bool flag22 = !flag21;
				num6 = num7 - (flag22 ? 1 : 0);
			}
			else
			{
				int num8 = toCompletedLoops - t.completedLoops;
				bool flag23 = num8 < 0;
				bool flag24 = num8 == 0;
				int num9 = toCompletedLoops ^ t.completedLoops;
				int num10 = toCompletedLoops ^ num8;
				int num11 = num9 & num10;
				bool flag25 = num11 < 0;
				int num12 = toCompletedLoops - t.completedLoops;
				bool flag26 = flag23 == flag25;
				bool flag27 = !flag24;
				num6 = ((flag26 && flag27) ? num12 : 0);
			}
			t.position = toPosition;
			bool flag28 = t.duration < toPosition;
			float num13 = t.duration;
			float num14;
			if (!flag28)
			{
				bool flag29 = toPosition < 0f;
				bool flag30 = !flag29;
				bool flag31 = toPosition == 0f;
				bool flag32 = !flag31;
				bool flag33 = flag30 && flag32;
				num14 = toPosition;
				if (flag33)
				{
					goto IL_0e98;
				}
				bool flag34;
				bool flag35;
				if (!flag15)
				{
					int num15 = toCompletedLoops - 1;
					flag34 = num15 < 0;
					int num16 = toCompletedLoops ^ 1;
					int num17 = toCompletedLoops ^ num15;
					int num18 = num16 & num17;
					flag35 = num18 < 0;
				}
				else
				{
					flag35 = false;
					flag34 = false;
				}
				num13 = ((flag34 == flag35) ? t.duration : 0f);
			}
			t.position = num13;
			num14 = num13;
			goto IL_0e98;
			IL_0e98:
			if (t.isPlaying)
			{
				bool flag43;
				if (t.isBackwards)
				{
					bool flag36 = toCompletedLoops == 0;
					bool flag37 = !flag36;
					bool flag38 = num14 < 0f;
					bool flag39 = !flag38;
					bool flag40 = num14 == 0f;
					bool flag41 = !flag40;
					bool flag42 = flag39 && flag41;
					flag43 = flag37 || flag42;
				}
				else
				{
					int num19 = (flag15 ? 1 : 0) ^ 1;
					flag43 = (byte)num19 != 0;
				}
				t.isPlaying = flag43;
			}
			int num20;
			int num21;
			if ((t.loops + 1 == 0 || t.loops >= 2) && t.loopType == LoopType.Yoyo)
			{
				bool flag44 = num14 < t.duration;
				num20 = toCompletedLoops & 1;
				if (!flag44)
				{
					num20 ^= 1;
				}
				if (flag16)
				{
					goto IL_0738;
				}
				num21 = num20;
			}
			else
			{
				bool flag45 = !flag16;
				num20 = 0;
				num21 = 0;
				if (!flag45)
				{
					goto IL_0738;
				}
			}
			goto IL_0909;
			IL_0738:
			int num22 = t.loops + 1;
			bool flag46 = num22 == 0;
			bool flag47 = !flag46;
			int num23 = t.loops - toCompletedLoops;
			bool flag48 = num23 < 0;
			bool flag49 = num23 == 0;
			int num24 = t.loops ^ toCompletedLoops;
			int num25 = t.loops ^ num23;
			int num26 = num24 & num25;
			bool flag50 = num26 < 0;
			bool flag51 = flag48 == flag50;
			bool flag52 = !flag51;
			bool flag53 = flag52 || flag49;
			if (!(flag47 && flag53) && t.completedLoops != toCompletedLoops && t.loopType == LoopType.Restart)
			{
				goto IL_08f3;
			}
			bool flag54 = toCompletedLoops > 0;
			num21 = num20;
			if (!flag54)
			{
				bool flag55 = num14 < 0f;
				bool flag56 = !flag55;
				bool flag57 = num14 == 0f;
				bool flag58 = !flag57;
				bool flag59 = flag56 && flag58;
				num21 = num20;
				if (!flag59)
				{
					goto IL_08f3;
				}
			}
			goto IL_0909;
			IL_0f1e:
			bool useInversePosition;
			UpdateNotice updateNotice;
			if (!t.ApplyTween(t.position, t.completedLoops, num6, useInversePosition, updateMode, updateNotice))
			{
				if (updateMode != UpdateMode.IgnoreOnUpdate && t.onUpdate != null)
				{
					bool flag60 = OnTweenCallback(t.onUpdate, t);
				}
				bool flag61 = t.position < 0f;
				bool flag62 = !flag61;
				bool flag63 = t.position == 0f;
				bool flag64 = !flag63;
				if (!(flag62 && flag64))
				{
					bool flag65 = t.completedLoops < 0;
					bool flag66 = t.completedLoops == 0;
					int num27 = t.completedLoops ^ t.completedLoops;
					int num28 = t.completedLoops & num27;
					bool flag67 = num28 < 0;
					bool flag68 = flag65 == flag67;
					bool flag69 = !flag66;
					bool flag70 = flag68 && flag69;
					bool flag71 = t.position < 0f;
					bool flag72 = !flag71;
					bool flag73 = t.position == 0f;
					bool flag74 = !flag73;
					bool flag75 = flag72 && flag74;
					if (t.completedLoops <= 0 && (flag75 || flag70) && t.onRewind != null)
					{
						bool flag76 = OnTweenCallback(t.onRewind, t);
					}
				}
				if (num6 >= 1 && updateMode == UpdateMode.Update && t.onStepComplete != null)
				{
					bool flag77 = OnTweenCallback(t.onStepComplete, t);
					if (t.active && num6 >= 2)
					{
						int num29 = 2;
						bool flag79;
						do
						{
							bool flag78 = OnTweenCallback(t.onStepComplete, t);
							if (!t.active)
							{
								break;
							}
							int num30 = num29 + 1;
							flag79 = num29 < num6;
							num29 = num30;
						}
						while (flag79);
					}
				}
				if (updateMode != UpdateMode.IgnoreOnComplete && t.isComplete && !t.isComplete && t.onComplete != null)
				{
					bool flag80 = OnTweenCallback(t.onComplete, t);
				}
				int num31 = (t.isPlaying ? 1 : 0) ^ 0xFF;
				if (((t.isPlaying ? 1u : 0u) & (uint)num31) != 0 && (!t.isComplete || !t.autoKill) && t.onPause != null)
				{
					bool flag81 = OnTweenCallback(t.onPause, t);
				}
				if (t.autoKill)
				{
					bool flag82 = !t.isComplete;
					return !flag82;
				}
				return false;
			}
			goto IL_0920;
			IL_08f3:
			updateNotice = UpdateNotice.RewindStep;
			useInversePosition = (byte)num20 != 0;
			goto IL_0f1e;
			IL_0909:
			updateNotice = default(UpdateNotice);
			useInversePosition = (byte)num21 != 0;
			goto IL_0f1e;
			IL_0920:
			return true;
		}

		[Token(Token = "0x60002A6")]
		[Address(RVA = "0xC0FA08", Offset = "0xC0FA08", Length = "0x1C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = DG.Tweening.DOTween;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A35752]) = v40;\nL_0019:\n\tgoto L_001E;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, t, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = DG.Tweening.DOTween;\nL_001E:\n\tv50 = ~v48.useSafeMode;\n\tif (v50) goto L_002C;\n\tv51 = callback == 0;\n\tif (v51) goto L_0035;\n\tDG.Tweening.TweenCallback::Invoke(callback);\n\tgoto L_FFFFFFFF;\nL_002C:\n\tDG.Tweening.TweenCallback::Invoke(callback);\nL_0034:\n\treturn returnVal1;\nL_0035:\n\tv57 = new System.NullReferenceException();\n\tv64 = v176 != 1;\n\tif (v64) goto L_0090;\n\tv164 = 0x1854E70(v57, v176, v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = *([v164 @ X0_v22]);\n\tv118 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v98 @ X8_v13]), v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv215 = v118 & 1;\n\tv120 = v215 == 0;\n\tif (v120) goto L_0086;\n\tv216 = 0x1854E80(v118, *([v98 @ X8_v13]), v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv92 = DG.Tweening.Core.Debugger::ShouldLogSafeModeCapturedError();\n\tv219 = v92 == 0;\n\tif (v219) goto L_0078;\n\tv240 = System.Exception::get_TargetSite(*([v164 @ X0_v22]));\n\tv247 = System.Exception::get_Message(*([v164 @ X0_v22]));\n\tv250 = System.Exception::get_StackTrace(*([v164 @ X0_v22]));\n\tv228 = System.String::Format(\"An error inside a tween callback was taken care of ({0}) ► {1}\\n\\n{2}\\n\\n\", v240, v247, v250);\n\tDG.Tweening.Core.Debugger::LogSafeModeCapturedError(v228, v176);\nL_0078:\n\tgoto L_0080;\n\tv254 = \"il2cpp_codegen_runtime_class_init\"(v237, v225, v222, v129, v127, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0080:\n\tv261 = v258.Version + 0x74;\n\tDG.Tweening.Core.SafeModeReport::Add(v261, 2);\n\tgoto L_0034;\n\tthrow System.NullReferenceException;\nL_0086:\n\tv125 = 0x1854E90(8, v116, v165, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\t*([v125 @ X0_v13]) = *([v121 @ X20_v5]);\n\tv176 = 0x185A000 + 0xF88;\n\tv188 = 0x1854EA0(v125, v176, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv179 = 0x1854E80(v188, v176, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0090:\n\tv186 = 0xBD3CD0(v181, v176, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = 0x9DACB4(v186, v176, 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static bool OnTweenCallback(TweenCallback callback, Tween t)
		{
			//IL_01b4: Expected O, but got I4
			//IL_016d: Expected O, but got I
			if (DOTween.useSafeMode)
			{
				if (callback == null)
				{
					NullReferenceException ex = new NullReferenceException();
					Tween tween = default(Tween);
					bool flag = (nint)tween != 1;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj3 = default(object);
						if ((int)((nint)obj3 & 1) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							if (Debugger.ShouldLogSafeModeCapturedError())
							{
								MethodBase targetSite = ((Exception)obj2).TargetSite;
								string message = ((Exception)obj2).Message;
								string stackTrace = ((Exception)obj2).StackTrace;
								string message2 = $"An error inside a tween callback was taken care of ({targetSite}) ► {message}\n\n{stackTrace}\n\n";
								Debugger.LogSafeModeCapturedError(message2, tween);
							}
							SafeModeReport safeModeReport = (SafeModeReport)((nint)DOTween.Version + 116);
							((SafeModeReport*)safeModeReport)->Add(SafeModeReport.SafeModeReportType.Callback);
							return false;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
						object obj5 = default(object);
						object obj4 = obj5;
						tween = (Tween)(25534464 + 3976);
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
					bool result = default(bool);
					return result;
				}
				callback();
			}
			else
			{
				callback();
			}
			return true;
		}

		[Token(Token = "0x60002A7")]
		[Address(RVA = "0xCAE1EC", Offset = "0xCAE1EC", Length = "0x1C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_001D;\n\tv38 = 0xB3490C(methodInfo, v179, v181, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_001D:\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v45, t, param, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv52 = DG.Tweening.DOTween;\nL_0022:\n\tv55 = ~v53.useSafeMode;\n\tif (v55) goto L_0032;\n\tv57 = callback == 0;\n\tif (v57) goto L_003B;\n\tDG.Tweening.TweenCallback`1<T>::Invoke(callback, v181);\n\tgoto L_FFFFFFFF;\nL_0032:\n\tDG.Tweening.TweenCallback`1<T>::Invoke(callback, v181);\nL_003A:\n\treturn returnVal1;\nL_003B:\n\tv64 = new System.NullReferenceException();\n\tv72 = v179 != 1;\n\tif (v72) goto L_008F;\n\tv169 = 0x1854E70(v64, v179, v181, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv106 = *([v169 @ X0_v22]);\n\tv127 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v106 @ X8_v13]), v181, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv219 = v127 & 1;\n\tv129 = v219 == 0;\n\tif (v129) goto L_0085;\n\tv220 = 0x1854E80(v127, *([v106 @ X8_v13]), v181, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv100 = DG.Tweening.Core.Debugger::ShouldLogSafeModeCapturedError();\n\tv223 = v100 == 0;\n\tif (v223) goto L_0077;\n\tv242 = System.Exception::get_TargetSite(*([v169 @ X0_v22]));\n\tv247 = System.Exception::get_Message(*([v169 @ X0_v22]));\n\tv231 = System.String::Format(\"An error inside a tween callback was taken care of ({0}) ► {1}\", v242, v247);\n\tDG.Tweening.Core.Debugger::LogSafeModeCapturedError(v231, v179);\nL_0077:\n\tgoto L_007F;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v239, v226, v228, v136, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007F:\n\tv258 = v255.Version + 0x74;\n\tDG.Tweening.Core.SafeModeReport::Add(v258, 2);\n\tgoto L_003A;\n\tthrow System.NullReferenceException;\nL_0085:\n\tv134 = 0x1854E90(8, v125, v181, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\t*([v134 @ X0_v13]) = *([v130 @ X20_v5]);\n\tv179 = 0x185A000 + 0xF88;\n\tv193 = 0x1854EA0(v134, v179, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv184 = 0x1854E80(v193, v179, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_008F:\n\tv191 = 0xBD3CD0(v186, v179, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturnVal2 = 0x9DACB4(v191, v179, 0, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal2;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe static bool OnTweenCallback<T>(TweenCallback<T> callback, Tween t, T param)
		{
			//IL_01c9: Expected O, but got I4
			//IL_0182: Expected O, but got I
			T value = default(T);
			if (DOTween.useSafeMode)
			{
				if (callback == null)
				{
					NullReferenceException ex = new NullReferenceException();
					Tween tween = default(Tween);
					bool flag = (nint)tween != 1;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
						object obj2 = default(object);
						object obj = obj2;
						Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj3 = default(object);
						if ((int)((nint)obj3 & 1) != 0)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
							if (Debugger.ShouldLogSafeModeCapturedError())
							{
								MethodBase targetSite = ((Exception)obj2).TargetSite;
								string message = ((Exception)obj2).Message;
								string message2 = $"An error inside a tween callback was taken care of ({targetSite}) ► {message}";
								Debugger.LogSafeModeCapturedError(message2, tween);
							}
							SafeModeReport safeModeReport = (SafeModeReport)((nint)DOTween.Version + 116);
							((SafeModeReport*)safeModeReport)->Add(SafeModeReport.SafeModeReportType.Callback);
							return false;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @1854E90 (native __cxa_allocate_exception)");
						object obj5 = default(object);
						object obj4 = obj5;
						tween = (Tween)(25534464 + 3976);
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @1854EA0 (native __cxa_throw)");
						Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
						NullReferenceException ex3 = default(NullReferenceException);
						ex2 = ex3;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
					bool result = default(bool);
					return result;
				}
				callback(value);
			}
			else
			{
				callback(value);
			}
			return true;
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0xC0E428", Offset = "0xC0E428", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intId = 0xFFFFFC19;\n\tthis.activeId = 0xFFFFFFFF;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\tDG.Tweening.Core.ABSSequentiable::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal Tween()
		{
			intId = -999;
			activeId = -1;
			delayComplete = true;
			miscInt = -1;
		}
	}
}
