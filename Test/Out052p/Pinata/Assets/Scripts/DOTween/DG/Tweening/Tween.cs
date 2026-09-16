using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Core;
using DG.Tweening.Core.Enums;

namespace DG.Tweening
{
	[Token(Token = "0x2000019")]
	public abstract class Tween : ABSSequentiable
	{
		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x28")]
		public float timeScale;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x2C")]
		public bool isBackwards;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x30")]
		public object id;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x38")]
		public string stringId;

		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x40")]
		public int intId;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x48")]
		public object target;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x50")]
		internal UpdateType updateType;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x54")]
		internal bool isIndependentUpdate;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x58")]
		public TweenCallback onPlay;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x60")]
		public TweenCallback onPause;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x68")]
		public TweenCallback onRewind;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x70")]
		public TweenCallback onUpdate;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x78")]
		public TweenCallback onStepComplete;

		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x80")]
		public TweenCallback onComplete;

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x88")]
		public TweenCallback onKill;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x90")]
		public TweenCallback<int> onWaypointChange;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x98")]
		internal bool isFrom;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x99")]
		internal bool isBlendable;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x9A")]
		internal bool isRecyclable;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x9B")]
		internal bool isSpeedBased;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x9C")]
		internal bool autoKill;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0xA0")]
		internal float duration;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0xA4")]
		internal int loops;

		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0xA8")]
		public LoopType loopType;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0xAC")]
		internal float delay;

		[CompilerGenerated]
		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0xB0")]
		internal bool _003CisRelative_003Ek__BackingField;

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0xB4")]
		internal Ease easeType;

		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0xB8")]
		internal EaseFunction customEase;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0xC0")]
		public float easeOvershootOrAmplitude;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0xC4")]
		public float easePeriod;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0xC8")]
		internal Type typeofT1;

		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0xD0")]
		internal Type typeofT2;

		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0xD8")]
		internal Type typeofTPlugOptions;

		[CompilerGenerated]
		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0xE0")]
		internal bool _003Cactive_003Ek__BackingField;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0xE1")]
		internal bool isSequenced;

		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0xE8")]
		internal Sequence sequenceParent;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0xF0")]
		internal int activeId;

		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0xF4")]
		internal SpecialStartupMode specialStartupMode;

		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0xF8")]
		internal bool creationLocked;

		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0xF9")]
		internal bool startupDone;

		[CompilerGenerated]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0xFA")]
		private bool _003CplayedOnce_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0xFC")]
		internal float _003Cposition_003Ek__BackingField;

		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x100")]
		internal float fullDuration;

		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x104")]
		public int completedLoops;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x108")]
		internal bool isPlaying;

		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x109")]
		public bool isComplete;

		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x10C")]
		internal float elapsedDelay;

		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x110")]
		internal bool delayComplete;

		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x114")]
		internal int miscInt;

		[Token(Token = "0x17000002")]
		public bool isRelative
		{
			[CompilerGenerated]
			[Token(Token = "0x600015E")]
			[Address(RVA = "0x1601FB0", Offset = "0x1601FB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<isRelative>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return isRelative;
			}
			[CompilerGenerated]
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x1601FB8", Offset = "0x1601FB8", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<isRelative>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				_003CisRelative_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000003")]
		public bool active
		{
			[CompilerGenerated]
			[Token(Token = "0x6000160")]
			[Address(RVA = "0x1601FC4", Offset = "0x1601FC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<active>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return active;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000161")]
			[Address(RVA = "0x1601FCC", Offset = "0x1601FCC", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<active>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal set
			{
				_003Cactive_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000004")]
		public float fullPosition
		{
			[Token(Token = "0x6000162")]
			[Address(RVA = "0x1601FD8", Offset = "0x1601FD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.TweenExtensions::Elapsed(this, 1);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return this.Elapsed();
			}
			[Token(Token = "0x6000163")]
			[Address(RVA = "0x1602094", Offset = "0x1602094", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Goto(this, value, this.isPlaying);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				this.Goto(value, isPlaying);
			}
		}

		[Token(Token = "0x17000005")]
		public bool playedOnce
		{
			[CompilerGenerated]
			[Token(Token = "0x6000164")]
			[Address(RVA = "0x160226C", Offset = "0x160226C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<playedOnce>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return playedOnce;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000165")]
			[Address(RVA = "0x1602274", Offset = "0x1602274", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<playedOnce>k__BackingField = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set
			{
				_003CplayedOnce_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000006")]
		public float position
		{
			[CompilerGenerated]
			[Token(Token = "0x6000166")]
			[Address(RVA = "0x1602280", Offset = "0x1602280", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<position>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return position;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000167")]
			[Address(RVA = "0x1602288", Offset = "0x1602288", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<position>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003Cposition_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x1602290", Offset = "0x1602290", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.timeScale = 1f;\n\tthis.intId = 0xFFFFFC19;\n\tthis.isBackwards = 0;\n\tthis.isIndependentUpdate = 0;\n\tthis.onPlay = 0;\n\tthis.onStart = 0;\n\tthis.target = 0;\n\tthis.isSpeedBased = 0;\n\tthis.isFrom = 0;\n\tthis.delay = 0f;\n\tthis.<isRelative>k__BackingField = 0;\n\tthis.customEase = 0;\n\tthis.isSequenced = 0;\n\tthis.sequenceParent = 0;\n\tthis.elapsedDelay = 0f;\n\tthis.<playedOnce>k__BackingField = 0;\n\tthis.creationLocked = 0;\n\tthis.specialStartupMode = 0;\n\tthis.id = 0;\n\tthis.onStepComplete = 0;\n\tthis.onKill = 0;\n\tthis.onRewind = 0;\n\tthis.duration = 0f;\n\tthis.loops = 1;\n\t*([this @ X0 (DG.Tweening.Tween)+102]) = 0;\n\tthis.<position>k__BackingField = 0f;\n\tthis.delayComplete = 1;\n\tthis.miscInt = 0xFFFFFFFF;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal virtual void Reset()
		{
			timeScale = 1f;
			intId = -999;
			isBackwards = false;
			isIndependentUpdate = false;
			onPlay = null;
			onStart = null;
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
			playedOnce = false;
			creationLocked = false;
			startupDone = false;
			specialStartupMode = default(SpecialStartupMode);
			id = null;
			onStepComplete = null;
			onKill = null;
			onRewind = null;
			duration = 0f;
			loops = 1;
			_ = 0;
			position = 0f;
			delayComplete = true;
			miscInt = -1;
		}

		[Token(Token = "0x6000169")]
		internal abstract bool Validate();

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x1602318", Offset = "0x1602318", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal virtual float UpdateDelay(float elapsed)
		{
			return 0f;
		}

		[Token(Token = "0x600016B")]
		internal abstract bool Startup();

		[Token(Token = "0x600016C")]
		internal abstract bool ApplyTween(float prevPosition, int prevCompletedLoops, int newCompletedSteps, bool useInversePosition, UpdateMode updateMode, UpdateNotice updateNotice);

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x1602320", Offset = "0x1602320", Length = "0x330")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = ~t.startupDone;\n\tv33 = ~v32;\n\tif (v33) goto L_001E;\n\tv51 = DG.Tweening.Tween::Startup(t);\n\tv53 = v51 == 0;\n\tif (v53) goto L_FFFFFFFF;\nL_001E:\n\tv60 = updateMode == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0039;\n\tv151 = ~t.<playedOnce>k__BackingField;\n\tv152 = ~v151;\n\tif (v152) goto L_0039;\n\tt.<playedOnce>k__BackingField = 1;\n\tv300 = t.onStart == 0;\n\tif (v300) goto L_002F;\n\tv137 = DG.Tweening.Tween::OnTweenCallback(t.onStart);\n\tv145 = ~t.<active>k__BackingField;\n\tif (v145) goto L_FFFFFFFF;\nL_002F:\n\tv158 = t.onPlay == 0;\n\tif (v158) goto L_0039;\n\tv138 = DG.Tweening.Tween::OnTweenCallback(t.onPlay);\n\tv146 = ~t.<active>k__BackingField;\n\tif (v146) goto L_FFFFFFFF;\nL_0039:\n\tv160 = t.<position>k__BackingField < 0;\n\tv161 = ~v160;\n\tv164 = t.<position>k__BackingField == 0;\n\tv169 = ~v161;\n\tv170 = v169 | v164;\n\tv174 = t.completedLoops - 1;\n\tv175 = v174 < 0;\n\tv177 = t.completedLoops ^ 1;\n\tv178 = t.completedLoops ^ v174;\n\tv179 = v177 & v178;\n\tv180 = v179 < 0;\n\tv181 = v175 == v180;\n\tv182 = ~v181;\n\tv183 = t.loops + 1;\n\tv185 = v183 == 0;\n\tt.completedLoops = toCompletedLoops;\n\tif (v185) goto L_0064;\n\tv303 = t.loops - toCompletedLoops;\n\tv305 = v303 == 0;\n\tt.isComplete = v305;\nL_0064:\n\tv320 = updateMode == 0;\n\tif (v320) goto L_0084;\n\tv333 = t.tweenType != 1;\n\tif (v333) goto L_FFFFFFFF;\n\tv345 = t.completedLoops - toCompletedLoops;\n\tv346 = t.completedLoops >= toCompletedLoops;\n\tif (v346) goto L_FFFFFFFF;\n\tv87 = -v345;\n\tgoto L_0082;\nL_0082:\n\tgoto L_00DE;\nL_0084:\n\tv335 = ~t.isBackwards;\n\tif (v335) goto L_00A4;\n\tv383 = t.completedLoops - toCompletedLoops;\n\tv360 = t.completedLoops > toCompletedLoops;\n\tif (v360) goto L_00D5;\n\tv413 = toPosition < 0;\n\tv414 = ~v413;\n\tv417 = toPosition == 0;\n\tv422 = ~v414;\n\tv423 = v422 | v417;\n\tif (v423) goto L_00BA;\n\tgoto L_00D5;\n\tgoto L_00DE;\nL_00A4:\n\tv361 = toCompletedLoops - t.completedLoops;\n\tv364 = t.completedLoops - toCompletedLoops;\n\tv365 = v364 < 0;\n\tv367 = t.completedLoops ^ toCompletedLoops;\n\tv368 = t.completedLoops ^ v364;\n\tv369 = v367 & v368;\n\tv370 = v369 < 0;\n\tv371 = v365 == v370;\n\tv372 = ~v371;\n\tv373 = ~v372;\n\tif (v373) goto L_FFFFFFFF;\n\tgoto L_00B6;\nL_00B6:\n\tgoto L_00DE;\nL_00BA:\n\tv488 = t.completedLoops < 0;\n\tv489 = t.completedLoops == 0;\n\tv491 = t.completedLoops ^ t.completedLoops;\n\tv492 = t.completedLoops & v491;\n\tv493 = v492 < 0;\n\tv494 = v488 == v493;\n\tv426 = ~v489;\n\tv495 = v494 & v426;\n\tv497 = t.<position>k__BackingField < 0;\n\tv446 = ~v497;\n\tv440 = t.<position>k__BackingField == 0;\n\tv498 = ~v440;\n\tv430 = v446 & v498;\n\tv427 = v430 | v495;\nL_00D5:\n\tv395 = t.isComplete == 0;\n\tv385 = ~v395;\n\tv87 = v383 - v385;\nL_00DE:\n\tt.<position>k__BackingField = toPosition;\n\tv406 = t.duration < toPosition;\n\tif (v406) goto L_011A;\n\tv450 = toPosition < 0;\n\tv451 = ~v450;\n\tv454 = toPosition == 0;\n\tv459 = ~v454;\n\tv460 = v451 & v459;\n\tif (v460) goto L_011C;\n\tif (v319) goto L_FFFFFFFF;\n\tv521 = toCompletedLoops - 1;\n\tv479 = v521 < 0;\n\tv524 = toCompletedLoops ^ 1;\n\tv525 = toCompletedLoops ^ v521;\n\tv526 = v524 & v525;\n\tv469 = v526 < 0;\n\tgoto L_0111;\nL_0111:\n\tv569 = v479 == v469;\n\tv467 = ~v569;\n\tv465 = ~v467;\n\tif (v465) goto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tt.<position>k__BackingField = v461;\nL_011C:\n\tv69 = v170 & v182;\n\tv518 = ~t.isPlaying;\n\tif (v518) goto L_0147;\n\tv533 = ~t.isBackwards;\n\tif (v533) goto L_013B;\n\tv574 = toCompletedLoops == 0;\n\tv579 = ~v574;\n\tv581 = v148 < 0;\n\tv582 = ~v581;\n\tv585 = v148 == 0;\n\tv590 = ~v585;\n\tv591 = v582 & v590;\n\tv555 = v591 | v579;\n\tgoto L_013C;\nL_013B:\n\tv594 = v319 ^ 1;\nL_013C:\n\tt.isPlaying = v555;\nL_0147:\n\tv567 = t.loopType != 1;\n\tif (v567) goto L_015B;\n\tv598 = v148 < t.duration;\n\tv613 = toCompletedLoops & 1;\n\tif (v598) goto L_0156;\n\tv613 = v613 ^ 1;\nL_0156:\n\tv612 = v69 == 0;\n\tif (v612) goto L_015E;\n\tgoto L_FFFFFFFF;\nL_015B:\n\tv607 = v69 == 0;\n\tv608 = ~v607;\n\tif (v608) goto L_FFFFFFFF;\nL_015E:\n\tv623 = t.loops + 1;\n\tv625 = v623 == 0;\n\tv631 = t.loops - toCompletedLoops;\n\tv632 = v631 < 0;\n\tv633 = v631 == 0;\n\tv634 = t.loops ^ toCompletedLoops;\n\tv635 = t.loops ^ v631;\n\tv636 = v634 & v635;\n\tv637 = v636 < 0;\n\tv638 = v632 == v637;\n\tv639 = ~v633;\n\tv640 = v638 & v639;\n\tv646 = t.completedLoops == toCompletedLoops;\n\tif (v646) goto L_0184;\n\tv677 = t.loopType == 0;\n\tv678 = ~v677;\n\tif (v678) goto L_0184;\n\tv679 = v625 | v640;\n\tv680 = v679 == 0;\n\tif (v680) goto L_0184;\n\tgoto L_0197;\nL_0184:\n\tv681 = v148 < 0;\n\tv671 = ~v681;\n\tv665 = v148 == 0;\n\tv682 = ~v671;\n\tv655 = v682 | v665;\n\tif (v655) goto L_0243;\nL_0197:\n\tv136 = DG.Tweening.Tween::ApplyTween(t, t.<position>k__BackingField, t.completedLoops, v87, v77, updateMode, v75);\n\tv144 = v136 == 0;\n\tif (v144) goto L_01A1;\n\tgoto L_0240;\nL_01A1:\n\tv705 = updateMode == 2;\n\tif (v705) goto L_01AC;\n\tv711 = t.onUpdate == 0;\n\tif (v711) goto L_01AC;\n\tv713 = DG.Tweening.Tween::OnTweenCallback(t.onUpdate);\nL_01AC:\n\tv715 = t.<position>k__BackingField < 0;\n\tv716 = ~v715;\n\tv719 = t.<position>k__BackingField == 0;\n\tv724 = ~v719;\n\tv725 = v716 & v724;\n\tif (v725) goto L_01CF;\n\tv730 = t.completedLoops < 0;\n\tv731 = t.completedLoops == 0;\n\tv733 = t.completedLoops ^ t.completedLoops;\n\tv734 = t.completedLoops & v733;\n\tv735 = v734 < 0;\n\tv736 = v730 == v735;\n\tv737 = ~v731;\n\tv738 = v736 & v737;\n\tv740 = v69 | v738;\n\tv742 = v740 == 0;\n\tv743 = ~v742;\n\tif (v743) goto L_01CF;\n\tv758 = t.onRewind == 0;\n\tif (v758) goto L_01CF;\n\tv754 = DG.Tweening.Tween::OnTweenCallback(t.onRewind);\nL_01CF:\n\tv759 = updateMode == 0;\n\tv760 = ~v759;\n\tif (v760) goto L_0203;\n\tv771 = v87 < 1;\n\tif (v771) goto L_0203;\n\tv803 = t.onStepComplete == 0;\n\tif (v803) goto L_0203;\n\tv772 = v87 < 1;\n\tif (v772) goto L_0203;\n\tv800 = DG.Tweening.Tween::OnTweenCallback(t.onStepComplete);\n\tv786 = v87 == 1;\n\tv840 = v87 - 1;\n\tif (v786) goto L_0203;\nL_01FA:\n\tv798 = DG.Tweening.Tween::OnTweenCallback(t.onStepComplete);\n\tv804 = v840 - 1;\n\tv802 = v840 != 1;\n\tif (v802) goto L_01FA;\nL_0203:\n\tv280 = updateMode == 3;\n\tif (v280) goto L_0213;\n\tv807 = ~t.isComplete;\n\tv808 = ~v807;\n\tif (v808) goto L_0213;\n\tv816 = ~t.isComplete;\n\tif (v816) goto L_0213;\n\tv815 = t.onComplete == 0;\n\tif (v815) goto L_0213;\n\tv810 = DG.Tweening.Tween::OnTweenCallback(t.onComplete);\nL_0213:\n\tv817 = ~t.isPlaying;\n\tif (v817) goto L_0225;\n\tv821 = ~t.isPlaying;\n\tv822 = ~v821;\n\tif (v822) goto L_0225;\n\tv833 = ~t.isComplete;\n\tif (v833) goto L_0221;\n\tv836 = ~t.autoKill;\n\tv831 = ~v836;\n\tif (v831) goto L_0225;\nL_0221:\n\tv830 = t.onPause == 0;\n\tif (v830) goto L_0225;\n\tv824 = DG.Tweening.Tween::OnTweenCallback(t.onPause);\nL_0225:\n\tv294 = ~t.autoKill;\n\tif (v294) goto L_FFFFFFFF;\n\tv281 = t.isComplete == 0;\n\tv271 = ~v281;\n\tgoto L_0240;\nL_0240:\n\treturn returnVal2;\nL_0243:\n\tv692 = toCompletedLoops - 1;\n\tv691 = v692 < 0;\n\tv689 = toCompletedLoops ^ 1;\n\tv688 = toCompletedLoops ^ v692;\n\tv687 = v689 & v688;\n\tv686 = v687 < 0;\n\tv700 = v691 == v686;\n\tv685 = ~v700;\n\tgoto L_0197;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 331 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool DoGoto(Tween t, float toPosition, int toCompletedLoops, UpdateMode updateMode)
		{
			if (!t.startupDone && !t.Startup())
			{
				goto IL_096c;
			}
			if (updateMode == UpdateMode.Update && !t.playedOnce)
			{
				t.playedOnce = true;
				if (t.onStart != null)
				{
					bool flag = OnTweenCallback(t.onStart);
					if (!t.active)
					{
						goto IL_096c;
					}
				}
				if (t.onPlay != null)
				{
					bool flag2 = OnTweenCallback(t.onPlay);
					if (!t.active)
					{
						goto IL_096c;
					}
				}
			}
			bool flag3 = t.position < 0f;
			bool flag4 = !flag3;
			bool flag5 = t.position == 0f;
			bool flag6 = !flag4;
			bool flag7 = flag6 || flag5;
			int num = t.completedLoops - 1;
			bool flag8 = num < 0;
			int num2 = t.completedLoops ^ 1;
			int num3 = t.completedLoops ^ num;
			int num4 = num2 & num3;
			bool flag9 = num4 < 0;
			bool flag10 = flag8 == flag9;
			bool flag11 = !flag10;
			int num5 = t.loops + 1;
			bool flag12 = num5 == 0;
			t.completedLoops = toCompletedLoops;
			bool flag13 = t.isComplete;
			if (!flag12)
			{
				int num6 = t.loops - toCompletedLoops;
				flag13 = (t.isComplete = num6 == 0);
			}
			int num8;
			if (updateMode != UpdateMode.Update)
			{
				if (t.tweenType == TweenType.Sequence)
				{
					int num7 = t.completedLoops - toCompletedLoops;
					num8 = ((t.completedLoops >= toCompletedLoops) ? num7 : (-num7));
				}
				else
				{
					num8 = 0;
				}
			}
			else if (t.isBackwards)
			{
				int num9 = t.completedLoops - toCompletedLoops;
				if (t.completedLoops <= toCompletedLoops)
				{
					bool flag14 = toPosition < 0f;
					bool flag15 = !flag14;
					bool flag16 = toPosition == 0f;
					bool flag17 = !flag15;
					if (!(flag17 || flag16))
					{
						num9 = 0;
					}
					else
					{
						bool flag18 = t.completedLoops < 0;
						bool flag19 = t.completedLoops == 0;
						int num10 = t.completedLoops ^ t.completedLoops;
						int num11 = t.completedLoops & num10;
						bool flag20 = num11 < 0;
						bool flag21 = flag18 == flag20;
						bool flag22 = !flag19;
						bool flag23 = flag21 && flag22;
						bool flag24 = t.position < 0f;
						bool flag25 = !flag24;
						bool flag26 = t.position == 0f;
						bool flag27 = !flag26;
						bool flag28 = flag25 && flag27;
						bool flag29 = flag28 || flag23;
						num9 = (flag29 ? 1 : 0);
					}
				}
				bool flag30 = !t.isComplete;
				bool flag31 = !flag30;
				num8 = num9 - (flag31 ? 1 : 0);
			}
			else
			{
				int num12 = toCompletedLoops - t.completedLoops;
				int num13 = t.completedLoops - toCompletedLoops;
				bool flag32 = num13 < 0;
				int num14 = t.completedLoops ^ toCompletedLoops;
				int num15 = t.completedLoops ^ num13;
				int num16 = num14 & num15;
				bool flag33 = num16 < 0;
				num8 = ((flag32 != flag33) ? num12 : 0);
			}
			t.position = toPosition;
			bool flag34 = t.duration < toPosition;
			float num17 = t.duration;
			float num18;
			if (!flag34)
			{
				bool flag35 = toPosition < 0f;
				bool flag36 = !flag35;
				bool flag37 = toPosition == 0f;
				bool flag38 = !flag37;
				bool flag39 = flag36 && flag38;
				num18 = toPosition;
				if (flag39)
				{
					goto IL_0efd;
				}
				bool flag40;
				bool flag41;
				if (!flag13)
				{
					int num19 = toCompletedLoops - 1;
					flag40 = num19 < 0;
					int num20 = toCompletedLoops ^ 1;
					int num21 = toCompletedLoops ^ num19;
					int num22 = num20 & num21;
					flag41 = num22 < 0;
				}
				else
				{
					flag41 = false;
					flag40 = false;
				}
				num17 = ((flag40 == flag41) ? t.duration : 0f);
			}
			t.position = num17;
			num18 = num17;
			goto IL_0efd;
			IL_0efd:
			bool flag42 = flag7 && flag11;
			if (t.isPlaying)
			{
				bool flag50;
				if (t.isBackwards)
				{
					bool flag43 = toCompletedLoops == 0;
					bool flag44 = !flag43;
					bool flag45 = num18 < 0f;
					bool flag46 = !flag45;
					bool flag47 = num18 == 0f;
					bool flag48 = !flag47;
					bool flag49 = flag46 && flag48;
					flag50 = flag49 || flag44;
				}
				else
				{
					int num23 = (flag13 ? 1 : 0) ^ 1;
					flag50 = (byte)num23 != 0;
				}
				t.isPlaying = flag50;
			}
			int num24;
			int useInversePosition;
			if (t.loopType == LoopType.Yoyo)
			{
				bool flag51 = num18 < t.duration;
				num24 = toCompletedLoops & 1;
				if (!flag51)
				{
					num24 ^= 1;
				}
				if (!flag42)
				{
					goto IL_07bc;
				}
				useInversePosition = num24;
			}
			else
			{
				bool flag52 = !flag42;
				bool flag53 = !flag52;
				num24 = 0;
				useInversePosition = 0;
				if (!flag53)
				{
					goto IL_07bc;
				}
			}
			goto IL_095d;
			IL_07bc:
			int num25 = t.loops + 1;
			bool flag54 = num25 == 0;
			int num26 = t.loops - toCompletedLoops;
			bool flag55 = num26 < 0;
			bool flag56 = num26 == 0;
			int num27 = t.loops ^ toCompletedLoops;
			int num28 = t.loops ^ num26;
			int num29 = num27 & num28;
			bool flag57 = num29 < 0;
			bool flag58 = flag55 == flag57;
			bool flag59 = !flag56;
			bool flag60 = flag58 && flag59;
			UpdateNotice updateNotice;
			if (t.completedLoops != toCompletedLoops && t.loopType == LoopType.Restart && (flag54 || flag60))
			{
				updateNotice = UpdateNotice.RewindStep;
				useInversePosition = num24;
			}
			else
			{
				bool flag61 = num18 < 0f;
				bool flag62 = !flag61;
				bool flag63 = num18 == 0f;
				bool flag64 = !flag62;
				bool flag65 = flag64 || flag63;
				useInversePosition = num24;
				if (!flag65)
				{
					goto IL_095d;
				}
				int num30 = toCompletedLoops - 1;
				bool flag66 = num30 < 0;
				int num31 = toCompletedLoops ^ 1;
				int num32 = toCompletedLoops ^ num30;
				int num33 = num31 & num32;
				bool flag67 = num33 < 0;
				bool flag68 = flag66 == flag67;
				bool flag69 = !flag68;
				updateNotice = (flag69 ? UpdateNotice.RewindStep : UpdateNotice.None);
				useInversePosition = num24;
			}
			goto IL_0f89;
			IL_0f89:
			if (!t.ApplyTween(t.position, t.completedLoops, num8, (byte)useInversePosition != 0, updateMode, updateNotice))
			{
				if (updateMode != UpdateMode.IgnoreOnUpdate && t.onUpdate != null)
				{
					bool flag70 = OnTweenCallback(t.onUpdate);
				}
				bool flag71 = t.position < 0f;
				bool flag72 = !flag71;
				bool flag73 = t.position == 0f;
				bool flag74 = !flag73;
				if (!(flag72 && flag74))
				{
					bool flag75 = t.completedLoops < 0;
					bool flag76 = t.completedLoops == 0;
					int num34 = t.completedLoops ^ t.completedLoops;
					int num35 = t.completedLoops & num34;
					bool flag77 = num35 < 0;
					bool flag78 = flag75 == flag77;
					bool flag79 = !flag76;
					bool flag80 = flag78 && flag79;
					if (!(flag42 || flag80) && t.onRewind != null)
					{
						bool flag81 = OnTweenCallback(t.onRewind);
					}
				}
				if (updateMode == UpdateMode.Update && num8 >= 1 && t.onStepComplete != null && num8 >= 1)
				{
					bool flag82 = OnTweenCallback(t.onStepComplete);
					bool flag83 = num8 == 1;
					int num36 = num8 - 1;
					if (!flag83)
					{
						bool flag85;
						do
						{
							bool flag84 = OnTweenCallback(t.onStepComplete);
							int num37 = num36 - 1;
							flag85 = num36 != 1;
							num36 = num37;
						}
						while (flag85);
					}
				}
				if (updateMode != UpdateMode.IgnoreOnComplete && !t.isComplete && t.isComplete && t.onComplete != null)
				{
					bool flag86 = OnTweenCallback(t.onComplete);
				}
				if (t.isPlaying && !t.isPlaying && (!t.isComplete || !t.autoKill) && t.onPause != null)
				{
					bool flag87 = OnTweenCallback(t.onPause);
				}
				if (t.autoKill)
				{
					bool flag88 = !t.isComplete;
					return !flag88;
				}
				return false;
			}
			goto IL_096c;
			IL_096c:
			return true;
			IL_095d:
			updateNotice = default(UpdateNotice);
			goto IL_0f89;
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x1602650", Offset = "0x1602650", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1F0F188]);\n\tv21 = *([v20 @ X8_v41]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A1B8]) = v40;\nL_001A:\n\tgoto L_0023;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0023;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = DG.Tweening.DOTween;\nL_0023:\n\tv56 = ~v54.useSafeMode;\n\tif (v56) goto L_002D;\n\tv58 = callback == 0;\n\tif (v58) goto L_0037;\n\tDG.Tweening.TweenCallback::Invoke(callback);\n\tgoto L_FFFFFFFF;\nL_002D:\n\tDG.Tweening.TweenCallback::Invoke(callback);\nL_0035:\n\treturn returnVal1;\nL_0037:\n\tv62 = new System.NullReferenceException();\n\tv115 = v144 != 1;\n\tif (v115) goto L_00AC;\n\tv141 = 0x6D2BC0(v62, v144, v142, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv98 = *([v141 @ X0_v23]);\n\tv130 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v98 @ X19_v9 (System.Exception)]), v142, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv228 = v130 & 1;\n\tv132 = v228 == 0;\n\tif (v132) goto L_00A2;\n\tv229 = 0x6D2490(v130, *([v98 @ X19_v9 (System.Exception)]), v142, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_006B;\n\tv234 = *([1EC8838]);\n\tv235 = *([v234 @ X8_v36]);\n\tv236 = \"il2cpp_codegen_initialize_method\"(v235, v65, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv238 = 0 | 1;\n\t*([2022B9B]) = v238;\nL_006B:\n\tv68 = v242._logPriority < 1;\n\tif (v68) goto L_008F;\n\tv267 = System.Exception::get_TargetSite(v98);\n\tv281 = System.Exception::get_Message(v98);\n\tv285 = System.Exception::get_StackTrace(v98);\n\tv254 = System.String::Format(\"An error inside a tween callback was silently taken care of ({0}) ► {1}\\n\\n{2}\\n\\n\", v267, v281, v285);\n\tDG.Tweening.Core.Debugger::LogWarning(v254);\nL_008F:\n\tgoto L_009B;\n\tv268 = *([v261 @ X0_v29 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv269 = v268 == 0;\n\tv270 = ~v269;\n\tif (v270) goto L_009B;\n\tv290 = \"il2cpp_codegen_runtime_class_init\"(v261, v251, v246, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv272 = DG.Tweening.DOTween;\nL_009B:\n\tv275 = v271.Version + 0x68;\n\tv276 = 0x1075B9C(v275, 2, 0, v285, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0035;\n\tthrow System.NullReferenceException;\nL_00A2:\n\tv139 = 0x6D1E60(8, v119, v142, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\t*([v139 @ X0_v11]) = *([v136 @ X20_v7]);\n\tv144 = 0x1E8A000 + 0x870;\n\tv202 = 0x6D2A00(v139, v144, 0, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv156 = 0x6D2490(v202, v144, 0, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00AC:\n\tv164 = 0x6D2380(v158, v144, 0, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturnVal2 = 0x846AA4(v164, v144, 0, v170, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\treturn returnVal2;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool OnTweenCallback(TweenCallback callback)
		{
			//IL_01e4: Expected O, but got I
			if (DOTween.useSafeMode)
			{
				if (callback == null)
				{
					NullReferenceException ex = new NullReferenceException();
					IntPtr intPtr = default(IntPtr);
					bool flag = intPtr != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj = default(object);
						Exception ex3 = (Exception)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj2 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							if (Debugger._logPriority >= 1)
							{
								MethodBase targetSite = ex3.TargetSite;
								string message = ex3.Message;
								string stackTrace = ex3.StackTrace;
								string message2 = $"An error inside a tween callback was silently taken care of ({targetSite}) ► {message}\n\n{stackTrace}\n\n";
								Debugger.LogWarning(message2);
							}
							object obj3 = (long)(IntPtr)DOTween.Version + 104L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1075B9C (inside DG.Tweening.Core.Easing.Flash::WeightedEase +0x170)");
							return false;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj5 = default(object);
						object obj4 = obj5;
						intPtr = (IntPtr)(32022528 + 2160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						NullReferenceException ex4 = default(NullReferenceException);
						ex2 = ex4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
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

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x11B2200", Offset = "0x11B2200", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EE91B0]);\n\tv27 = *([v26 @ X8_v41]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, param, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2027ADA]) = v44;\nL_001D:\n\tgoto L_0026;\n\tv51 = *([v47 @ X0_v2 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0026;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v47, param, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv55 = DG.Tweening.DOTween;\nL_0026:\n\tv60 = ~v58.useSafeMode;\n\tif (v60) goto L_0038;\n\tv62 = callback == 0;\n\tif (v62) goto L_0043;\n\tv69 = DG.Tweening.TweenCallback`1<T>::Invoke(callback, v201);\n\tgoto L_FFFFFFFF;\nL_0038:\n\tv77 = DG.Tweening.TweenCallback`1<T>::Invoke(callback, v201);\nL_0041:\n\treturn returnVal1;\nL_0043:\n\tv71 = new System.NullReferenceException();\n\tv135 = v201 != 1;\n\tif (v135) goto L_00AD;\n\tv191 = 0x6D2BC0(v71, v201, v203, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv114 = *([v191 @ X0_v24]);\n\tv147 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v114 @ X19_v9 (System.Exception)]), v203, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv242 = v147 & 1;\n\tv149 = v242 == 0;\n\tif (v149) goto L_00A3;\n\tv243 = 0x6D2490(v147, *([v114 @ X19_v9 (System.Exception)]), v203, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0077;\n\tv248 = *([1EA8078]);\n\tv249 = *([v248 @ X8_v34]);\n\tv250 = \"il2cpp_codegen_initialize_method\"(v249, v106, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv252 = 0 | 1;\n\t*([2022B9B]) = v252;\nL_0077:\n\tv80 = v256._logPriority < 1;\n\tif (v80) goto L_0092;\n\tv277 = System.Exception::get_TargetSite(v114);\n\tv289 = System.Exception::get_Message(v114);\n\tv266 = System.String::Format(\"An error inside a tween callback was silently taken care of ({0}) ► {1}\", v277, v289);\n\tDG.Tweening.Core.Debugger::LogWarning(v266);\nL_0092:\n\tgoto L_009C;\n\tv278 = *([v271 @ X0_v30 (Il2CppClass<DG.Tweening.DOTween>)+E0]);\n\tv279 = v278 == 0;\n\tv280 = ~v279;\n\tif (v280) goto L_009C;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v271, v261, v263, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv282 = DG.Tweening.DOTween;\nL_009C:\n\tv284 = v281.Version + 0x68;\n\tv285 = 0x1075B9C(v284, 2, 0, 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0041;\n\tthrow System.NullReferenceException;\nL_00A3:\n\tv156 = 0x6D1E60(8, v145, v203, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\t*([v156 @ X0_v13]) = *([v150 @ X20_v5]);\n\tv201 = 0x1E8A000 + 0x870;\n\tv216 = 0x6D2A00(v156, v201, 0, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv206 = 0x6D2490(v216, v201, 0, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00AD:\n\tv214 = 0x6D2380(v209, v201, 0, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturnVal2 = 0x846AA4(v214, v201, 0, v158, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\treturn returnVal2;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool OnTweenCallback<T>(TweenCallback<T> callback, T param)
		{
			//IL_013c: Expected O, but got I4
			//IL_01db: Expected O, but got I
			T val = default(T);
			if (DOTween.useSafeMode)
			{
				if (callback == null)
				{
					NullReferenceException ex = new NullReferenceException();
					bool flag = (IntPtr)val != (IntPtr)1;
					NullReferenceException ex2 = ex;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						object obj = default(object);
						Exception ex3 = (Exception)obj;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj2 = default(object);
						if ((uint)((ulong)(long)(IntPtr)obj2 & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							if (Debugger._logPriority >= 1)
							{
								MethodBase targetSite = ex3.TargetSite;
								string message = ex3.Message;
								string message2 = $"An error inside a tween callback was silently taken care of ({targetSite}) ► {message}";
								Debugger.LogWarning(message2);
							}
							object obj3 = (long)(IntPtr)DOTween.Version + 104L;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1075B9C (inside DG.Tweening.Core.Easing.Flash::WeightedEase +0x170)");
							return false;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj5 = default(object);
						object obj4 = obj5;
						val = (T)(32022528 + 2160);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						NullReferenceException ex4 = default(NullReferenceException);
						ex2 = ex4;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					bool result = default(bool);
					return result;
				}
				callback(val);
			}
			else
			{
				callback(val);
			}
			return true;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x1602A6C", Offset = "0x1602A6C", Length = "0x24")]
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
