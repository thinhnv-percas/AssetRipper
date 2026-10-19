using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EnhancedUI.EnhancedScroller
{
	[RequireComponent(typeof(ScrollRect))]
	[Token(Token = "0x200000E")]
	public class EnhancedScroller : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerDownHandler, IPointerUpHandler
	{
		[Token(Token = "0x200000F")]
		public enum ScrollDirectionEnum
		{
			[Token(Token = "0x4000058")]
			Vertical = 0,
			[Token(Token = "0x4000059")]
			Horizontal = 1
		}

		[Token(Token = "0x2000010")]
		public enum CellViewPositionEnum
		{
			[Token(Token = "0x400005B")]
			Before = 0,
			[Token(Token = "0x400005C")]
			After = 1
		}

		[Token(Token = "0x2000011")]
		public enum ScrollbarVisibilityEnum
		{
			[Token(Token = "0x400005E")]
			OnlyIfNeeded = 0,
			[Token(Token = "0x400005F")]
			Always = 1,
			[Token(Token = "0x4000060")]
			Never = 2
		}

		[Token(Token = "0x2000012")]
		public enum LoopJumpDirectionEnum
		{
			[Token(Token = "0x4000062")]
			Closest = 0,
			[Token(Token = "0x4000063")]
			Up = 1,
			[Token(Token = "0x4000064")]
			Down = 2
		}

		[Token(Token = "0x2000013")]
		private enum ListPositionEnum
		{
			[Token(Token = "0x4000066")]
			First = 0,
			[Token(Token = "0x4000067")]
			Last = 1
		}

		[Token(Token = "0x2000014")]
		public enum TweenType
		{
			[Token(Token = "0x4000069")]
			immediate = 0,
			[Token(Token = "0x400006A")]
			linear = 1,
			[Token(Token = "0x400006B")]
			spring = 2,
			[Token(Token = "0x400006C")]
			easeInQuad = 3,
			[Token(Token = "0x400006D")]
			easeOutQuad = 4,
			[Token(Token = "0x400006E")]
			easeInOutQuad = 5,
			[Token(Token = "0x400006F")]
			easeInCubic = 6,
			[Token(Token = "0x4000070")]
			easeOutCubic = 7,
			[Token(Token = "0x4000071")]
			easeInOutCubic = 8,
			[Token(Token = "0x4000072")]
			easeInQuart = 9,
			[Token(Token = "0x4000073")]
			easeOutQuart = 10,
			[Token(Token = "0x4000074")]
			easeInOutQuart = 11,
			[Token(Token = "0x4000075")]
			easeInQuint = 12,
			[Token(Token = "0x4000076")]
			easeOutQuint = 13,
			[Token(Token = "0x4000077")]
			easeInOutQuint = 14,
			[Token(Token = "0x4000078")]
			easeInSine = 15,
			[Token(Token = "0x4000079")]
			easeOutSine = 16,
			[Token(Token = "0x400007A")]
			easeInOutSine = 17,
			[Token(Token = "0x400007B")]
			easeInExpo = 18,
			[Token(Token = "0x400007C")]
			easeOutExpo = 19,
			[Token(Token = "0x400007D")]
			easeInOutExpo = 20,
			[Token(Token = "0x400007E")]
			easeInCirc = 21,
			[Token(Token = "0x400007F")]
			easeOutCirc = 22,
			[Token(Token = "0x4000080")]
			easeInOutCirc = 23,
			[Token(Token = "0x4000081")]
			easeInBounce = 24,
			[Token(Token = "0x4000082")]
			easeOutBounce = 25,
			[Token(Token = "0x4000083")]
			easeInOutBounce = 26,
			[Token(Token = "0x4000084")]
			easeInBack = 27,
			[Token(Token = "0x4000085")]
			easeOutBack = 28,
			[Token(Token = "0x4000086")]
			easeInOutBack = 29,
			[Token(Token = "0x4000087")]
			easeInElastic = 30,
			[Token(Token = "0x4000088")]
			easeOutElastic = 31,
			[Token(Token = "0x4000089")]
			easeInOutElastic = 32,
			[Token(Token = "0x400008A")]
			custom = 33
		}

		[CompilerGenerated]
		[Token(Token = "0x2000015")]
		private sealed class _003CTweenPosition_003Ed__190 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400008B")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x400008C")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400008D")]
			[FieldOffset(Offset = "0x20")]
			public TweenType tweenType;

			[Token(Token = "0x400008E")]
			[FieldOffset(Offset = "0x24")]
			public float time;

			[Token(Token = "0x400008F")]
			[FieldOffset(Offset = "0x28")]
			public EnhancedScroller _003C_003E4__this;

			[Token(Token = "0x4000090")]
			[FieldOffset(Offset = "0x30")]
			public float start;

			[Token(Token = "0x4000091")]
			[FieldOffset(Offset = "0x34")]
			public float end;

			[Token(Token = "0x4000092")]
			[FieldOffset(Offset = "0x38")]
			public bool forceCalculateRange;

			[Token(Token = "0x4000093")]
			[FieldOffset(Offset = "0x40")]
			public Action tweenComplete;

			[Token(Token = "0x4000094")]
			[FieldOffset(Offset = "0x48")]
			private float _003CnewPosition_003E5__2;

			[Token(Token = "0x1700001B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000AB")]
				[Address(RVA = "0x40222F4", Offset = "0x40222F4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x1700001C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000AD")]
				[Address(RVA = "0x402233C", Offset = "0x402233C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A8")]
			[Address(RVA = "0x4020C14", Offset = "0x4020C14", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CTweenPosition_003Ed__190(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0x4021A78", Offset = "0x4021A78", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x4021A7C", Offset = "0x4021A7C", Length = "0x878")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = v115.<>4__this;\n\tv30 = v115.<>1__state == 1;\n\tif (v30) goto L_002F;\n\tv35 = v115.<>1__state == 0;\n\tv36 = ~v35;\n\tif (v36) goto L_FFFFFFFF;\n\tv115.<>1__state = -1;\n\tv41 = v115.tweenType == 0;\n\tif (v41) goto L_002A;\n\tv75 = v115.time;\n\tv146 = v115.time == 0;\n\tv126 = ~v146;\n\tif (v126) goto L_0085;\nL_002A:\n\tv174 = v25 == 0;\n\tv133 = ~v174;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v133) goto L_00BB;\n\tgoto L_0316;\nL_002F:\n\tv115.<>1__state = -1;\n\tv307 = v25._tweenTimeLeft;\n\tv305 = v115.time;\n\tv100 = v25._tweenTimeLeft < v115.time;\n\tv108 = ~v100;\nL_FFFFFFFF:\n\tv247 = v75;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v108) goto L_00BB;\nL_0040:\n\tv267 = v25._interruptTween == 0;\n\tv268 = ~v267;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv75 = v247;\n\tif (v268) goto L_00BB;\n\tv336 = v25.tweenPaused == 0;\n\tv203 = ~v336;\n\tif (v203) goto L_02E8;\n\tv353 = v25._tweenPauseToggledOff != 1;\nL_FFFFFFFF:\n\tv311 = v247;\n\tif (v353) goto L_006B;\n\tv25._tweenPauseToggledOff = 0;\n\tv115.start = v25._scrollPosition;\n\tv311 = v25._tweenPauseNewTweenTime;\n\tv372 = v25._tweenPauseNewTweenTime < 0;\n\tv380 = ~v372;\n\tif (v380) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv389 = 0x18C;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv389 = 0x194;\n\tv303 = 0x9309000 + 0x618;\n\tv292 = *([v303 @ X9_v13 (System.Int32)+v331 @ X8_v22 (System.Int32)*2]) << 2;\n\tv298 = 0x4021B64 + v292;\n\t// 126 IndirectJump v298 @ X10_v2 (System.Int32), v446 @ X0_v25 (EnhancedUI.EnhancedScroller.EnhancedScroller+<TweenPosition>d__190), v446 @ X0_v25 (EnhancedUI.EnhancedScroller.EnhancedScroller+<TweenPosition>d__190), v25 @ X19_v1 (EnhancedUI.EnhancedScroller.EnhancedScroller), 1, v264.method (System.IntPtr), v164 @ X4, v165 @ X5, v166 @ X6, v167 @ X7, v311 @ V0_v12 (System.Single), v168 @ V1, v307 @ V2_v7 (System.Single), v305 @ V3_v7 (System.Single), v169 @ V4, v170 @ V5, v171 @ V6, v172 @ V7\nL_0085:\n\tv119 = v25.ScrollRect;\n\tgoto L_0097;\nL_0097:\n\tv247 = v430.zero;\n\tv119.velocity = v430.zero;\n\tv25.IsTweening = 1;\n\tv264 = v25.scrollerTweeningChanged;\n\tv250 = v25.scrollerTweeningChanged == 0;\n\tif (v250) goto L_00A4;\n\tEnhancedUI.EnhancedScroller.ScrollerTweeningChangedDelegate::Invoke(v25.scrollerTweeningChanged, v25, 1);\nL_00BB:\n\tv127 = v25._interruptTween != 1;\n\tif (v127) goto L_00C5;\n\tv25._interruptTween = 0;\n\tv25._snapJumping = 0;\n\tv161 = v25.ScrollRect;\n\tv161.inertia = v25._snapInertia;\n\tgoto L_00E2;\nL_00C5:\n\tv412 = v115.end;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(v25, v115.end);\n\tv364 = v115.forceCalculateRange == 0;\n\tv365 = ~v364;\n\tif (v365) goto L_00DA;\n\tv409 = v115.tweenType == 0;\n\tif (v409) goto L_00DA;\n\tv412 = v115.time;\n\tv418 = v115.time == 0;\n\tv411 = ~v418;\nL_FFFFFFFF:\n\tv75 = v115.time;\n\tif (v411) goto L_00DB;\nL_00DA:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(v25);\nL_FFFFFFFF:\n\tv75 = v412;\nL_00DB:\n\t;\n\tv400 = v115.tweenComplete == 0;\n\tif (v400) goto L_00E2;\n\tSystem.Action::Invoke(v115.tweenComplete);\n\tEnhancedUI.EnhancedScroller.ScrollerTweeningChangedDelegate::Invoke(v25.scrollerTweeningChanged, v25, 0);\nL_02F0:\n\tgoto L_02E1;\nL_0316:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_02E8:\n\tv115.<>2__current = 0;\n\tv115.<>1__state = 1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_00F8;\nL_006B:\n\tv331 = v115.tweenType - 1;\n\tv391 = v331 < 0x20;\n\tv328 = ~v391;\n\tv326 = v331 - 0x20;\n\tv322 = v326 == 0;\n\tv392 = ~v322;\n\tv309 = v328 & v392;\n\tif (v309) goto L_02F0;\nL_0066:\n\tv305 = *([v25 @ X19_v1 (EnhancedUI.EnhancedScroller.EnhancedScroller)+v389 @ X8_v24 (System.Int32)]);\n\tv115.time = *([v25 @ X19_v1 (EnhancedUI.EnhancedScroller.EnhancedScroller)+v389 @ X8_v24 (System.Int32)]);\n\tv25._tweenTimeLeft = 0f;\nL_FFFFFFFF:\n\tv307 = 0;\nL_00A4:\n\tv25._tweenTimeLeft = 0f;\n\tv115.<newPosition>5__2 = 0f;\n\tv305 = v115.time;\n\tv258 = 0 < v115.time;\nL_FFFFFFFF:\n\tv307 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv75 = v247;\n\tif (v258) goto L_0040;\nL_00E2:\n\tv25.IsTweening = 0;\n\tv78 = v25.scrollerTweeningChanged == 0;\n\tif (v78) goto L_FFFFFFFF;\nL_00F8:\n\treturn returnVal1;\nL_02E1:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(v25, v115.<newPosition>5__2);\n\tv451 = UnityEngine.Time::get_unscaledDeltaTime();\n\tv358 = v25._tweenTimeLeft + v451;\n\tv25._tweenTimeLeft = v358;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller._003CTweenPosition_003Ed__190::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x40222FC", Offset = "0x40222FC", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x20")]
		public ScrollDirectionEnum scrollDirection;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x24")]
		public float spacing;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x28")]
		public RectOffset padding;

		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x30")]
		private bool loop;

		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x31")]
		public bool loopWhileDragging;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x34")]
		public float maxVelocity;

		[SerializeField]
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x38")]
		private ScrollbarVisibilityEnum scrollbarVisibility;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x3C")]
		public bool snapping;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x40")]
		public float snapVelocityThreshold;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x44")]
		public float snapWatchOffset;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x48")]
		public float snapJumpToOffset;

		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x4C")]
		public float snapCellCenterOffset;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x50")]
		public bool snapUseCellSpacing;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x54")]
		public TweenType snapTweenType;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x58")]
		public float snapTweenTime;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x5C")]
		public bool snapWhileDragging;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x5D")]
		public bool forceSnapOnEndDrag;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x5E")]
		public bool forceSnapOnPointerUp;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x5F")]
		public bool interruptTweeningOnDrag;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x60")]
		public bool interruptTweeningOnPointerDown;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x61")]
		public bool tweenPaused;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x64")]
		internal float _lookAheadBefore;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x68")]
		private float _lookAheadAfter;

		[Token(Token = "0x400001F")]
		[FieldOffset(Offset = "0x6C")]
		private float _calculateStartCellBias;

		[Token(Token = "0x4000020")]
		[FieldOffset(Offset = "0x70")]
		public CellViewVisibilityChangedDelegate cellViewVisibilityChanged;

		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x78")]
		public CellViewWillRecycleDelegate cellViewWillRecycle;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x80")]
		public ScrollerScrolledDelegate scrollerScrolled;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x88")]
		public ScrollerSnappedDelegate scrollerSnapped;

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x90")]
		public ScrollerScrollingChangedDelegate scrollerScrollingChanged;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x98")]
		public ScrollerTweeningChangedDelegate scrollerTweeningChanged;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0xA0")]
		public CellViewInstantiated cellViewInstantiated;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0xA8")]
		public CellViewReused cellViewReused;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0xB0")]
		public CustomTweenFunction customTweenFunction;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0xBA")]
		private bool _initialized;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0xBB")]
		private bool _updateSpacing;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0xC0")]
		private ScrollRect _scrollRect;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0xC8")]
		internal RectTransform _scrollRectTransform;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0xD0")]
		private Scrollbar _scrollbar;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0xD8")]
		private RectTransform _container;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0xE0")]
		private HorizontalOrVerticalLayoutGroup _layoutGroup;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0xE8")]
		internal IEnhancedScrollerDelegate _delegate;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0xF0")]
		internal bool _reloadData;

		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0xF1")]
		private bool _refreshActive;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0xF8")]
		private SmallList<EnhancedScrollerCellView> _recycledCellViews;

		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x100")]
		private LayoutElement _firstPadder;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x108")]
		private LayoutElement _lastPadder;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x110")]
		private RectTransform _recycledCellViewContainer;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x118")]
		private SmallList<float> _cellViewSizeArray;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x120")]
		private SmallList<float> _cellViewOffsetArray;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x128")]
		public float _scrollPosition;

		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x130")]
		internal SmallList<EnhancedScrollerCellView> _activeCellViews;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x138")]
		private int _activeCellViewsStartIndex;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x13C")]
		private int _activeCellViewsEndIndex;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x140")]
		private int _loopFirstCellIndex;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x144")]
		private int _loopLastCellIndex;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x148")]
		private float _loopFirstScrollPosition;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x14C")]
		private float _loopLastScrollPosition;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x150")]
		private float _loopFirstJumpTrigger;

		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x154")]
		private float _loopLastJumpTrigger;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x158")]
		private float _lastScrollRectSize;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x15C")]
		private bool _lastLoop;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x160")]
		private int _snapCellViewIndex;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x164")]
		private int _snapDataIndex;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x168")]
		private bool _snapJumping;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x169")]
		private bool _snapInertia;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x16C")]
		private ScrollbarVisibilityEnum _lastScrollbarVisibility;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x170")]
		private float _singleLoopGroupSize;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x174")]
		private bool _snapBeforeDrag;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x175")]
		private bool _loopBeforeDrag;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x176")]
		internal bool _ignoreLoopJump;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x178")]
		private int _dragFingerCount;

		[Token(Token = "0x4000051")]
		[FieldOffset(Offset = "0x17C")]
		private bool _interruptTween;

		[Token(Token = "0x4000052")]
		[FieldOffset(Offset = "0x180")]
		private Vector2 _dragPreviousPos;

		[Token(Token = "0x4000053")]
		[FieldOffset(Offset = "0x188")]
		private bool _dragging;

		[Token(Token = "0x4000054")]
		[FieldOffset(Offset = "0x18C")]
		private float _tweenTimeLeft;

		[Token(Token = "0x4000055")]
		[FieldOffset(Offset = "0x190")]
		private bool _tweenPauseToggledOff;

		[Token(Token = "0x4000056")]
		[FieldOffset(Offset = "0x194")]
		private float _tweenPauseNewTweenTime;

		[Token(Token = "0x17000002")]
		public float lookAheadBefore
		{
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x401C220", Offset = "0x401C220", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lookAheadBefore;\n")]
			get
			{
				return _lookAheadBefore;
			}
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x401C228", Offset = "0x401C228", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = UnityEngine.Mathf::Abs(value);\n\tthis.lookAheadBefore = v0;\n\treturn;\n")]
			set
			{
				float num = Mathf.Abs(value);
				_lookAheadBefore = num;
			}
		}

		[Token(Token = "0x17000003")]
		public float lookAheadAfter
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x401C234", Offset = "0x401C234", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.lookAheadAfter;\n")]
			get
			{
				return _lookAheadAfter;
			}
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x401C23C", Offset = "0x401C23C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = UnityEngine.Mathf::Abs(value);\n\tthis.lookAheadAfter = v0;\n\treturn;\n")]
			set
			{
				float num = Mathf.Abs(value);
				_lookAheadAfter = num;
			}
		}

		[Token(Token = "0x17000004")]
		public float CalculateStartCellBias
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x401C248", Offset = "0x401C248", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CalculateStartCellBias;\n")]
			get
			{
				return _calculateStartCellBias;
			}
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x401C250", Offset = "0x401C250", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CalculateStartCellBias = value;\n\treturn;\n")]
			set
			{
				_calculateStartCellBias = value;
			}
		}

		[Token(Token = "0x17000005")]
		public IEnhancedScrollerDelegate Delegate
		{
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x401C258", Offset = "0x401C258", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Delegate;\n")]
			get
			{
				return _delegate;
			}
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x401C260", Offset = "0x401C260", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Delegate = value;\n\tthis._reloadData = 1;\n\treturn;\n")]
			set
			{
				_delegate = value;
				_reloadData = true;
			}
		}

		[Token(Token = "0x17000006")]
		public float ScrollPosition
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x401C290", Offset = "0x401C290", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._scrollPosition;\n")]
			get
			{
				return _scrollPosition;
			}
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x401C298", Offset = "0x401C298", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = v48.Loop == 0;\n\tv20 = ~v19;\nL_FFFFFFFF:\n\tv53 = value;\n\tif (v20) goto L_002E;\n\tv51 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(v48);\n\tv66 = v51 < value;\n\tv73 = ~v66;\n\tif (v73) goto L_FFFFFFFF;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv51 = value;\nL_FFFFFFFF:\n\tv53 = 0;\n\tgoto L_002E;\nL_FFFFFFFF:\n\tv53 = v51;\n\treturn;\nL_003F:\n\tv48._scrollPosition = v53;\n\tv82 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(v48);\n\tv119 = v48.scrollDirection == 0;\n\tif (v119) goto L_0055;\n\tv104 = v53 / v82;\n\tUnityEngine.UI.ScrollRect::set_horizontalNormalizedPosition(v48.ScrollRect, v104);\n\treturn;\nL_0055:\n\tv133 = v53 / v82;\n\tv105 = 1f - v133;\n\tUnityEngine.UI.ScrollRect::set_verticalNormalizedPosition(v48.ScrollRect, v105);\n\treturn;\nL_002E:\n\tv58 = v48._scrollPosition == v53;\n\tv65 = ~v58;\n\tif (v65) goto L_003F;\nL_001F:\n\tv47 = value < 0;\n\tv29 = ~v47;\n\tif (v29) goto L_FFFFFFFF;\n")]
			set
			{
				bool flag = !Loop;
				bool flag2 = !flag;
				float num = value;
				if (!flag2)
				{
					float num2 = ScrollSize;
					if (!(num2 < value))
					{
						num2 = value;
					}
					num = ((!(value < 0f)) ? num2 : 0f);
				}
				if (_scrollPosition != num)
				{
					_scrollPosition = num;
					float scrollSize = ScrollSize;
					if (scrollDirection != ScrollDirectionEnum.Vertical)
					{
						float horizontalNormalizedPosition = num / scrollSize;
						ScrollRect.horizontalNormalizedPosition = horizontalNormalizedPosition;
					}
					else
					{
						float num3 = num / scrollSize;
						float verticalNormalizedPosition = 1f - num3;
						ScrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
					}
				}
			}
		}

		[Token(Token = "0x17000007")]
		public float ScrollSize
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x401C350", Offset = "0x401C350", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.scrollDirection == 0;\n\tif (v18) goto L_002B;\n\tv22 = UnityEngine.RectTransform::get_rect(this.Container);\n\tv60 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv98 = v22.width - v60.width;\n\treturnVal2 = UnityEngine.Mathf::Max(v98, 0f);\n\treturn returnVal2;\nL_002B:\n\tv37 = UnityEngine.RectTransform::get_rect(this.Container);\n\tv96 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv100 = v37.height - v96.height;\n\treturnVal3 = UnityEngine.Mathf::Max(v100, 0f);\n\treturn returnVal3;\n")]
			get
			{
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					Rect rect = Container.rect;
					Rect rect2 = _scrollRectTransform.rect;
					float a = rect.width - rect2.width;
					return Mathf.Max(a, 0f);
				}
				Rect rect3 = Container.rect;
				Rect rect4 = _scrollRectTransform.rect;
				float a2 = rect3.height - rect4.height;
				return Mathf.Max(a2, 0f);
			}
		}

		[Token(Token = "0x17000008")]
		public float NormalizedScrollPosition
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x401C3EC", Offset = "0x401C3EC", Length = "0x30")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this._scrollPosition == 0;\n\tv15 = this._scrollPosition < 0;\n\tv16 = ~v15;\n\tv19 = ~v16;\n\tv20 = v19 | v14;\n\treturnVal1 = 0;\n\tif (v20) goto L_0018;\n\tv21 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\treturnVal1 = this._scrollPosition / v21;\nL_0018:\n\treturn returnVal1;\n")]
			get
			{
				bool flag = _scrollPosition == 0f;
				bool flag2 = _scrollPosition < 0f;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				bool flag5 = flag4 || flag;
				float result = 0f;
				if (!flag5)
				{
					float scrollSize = ScrollSize;
					result = _scrollPosition / scrollSize;
				}
				return result;
			}
		}

		[Token(Token = "0x17000009")]
		public bool Loop
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x401C41C", Offset = "0x401C41C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Loop;\n")]
			get
			{
				return loop;
			}
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x401C424", Offset = "0x401C424", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.Loop != value;\n\tif (v12) goto L_0016;\n\treturn;\nL_0016:\n\tthis.Loop = value;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_Resize(this, 0);\n\tv92 = this._loopFirstScrollPosition;\n\tv44 = -this._loopFirstScrollPosition;\n\tv79 = this.Loop == 0;\n\tv69 = ~v79;\n\tv41 = ~v69;\n\tif (v41) goto L_FFFFFFFF;\n\tgoto L_002D;\nL_FFFFFFFF:\n\tv92 = v44;\nL_002D:\n\tv47 = this._scrollPosition + v92;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, v47);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollbarVisibility(this, this.ScrollbarVisibility);\n\treturn;\n")]
			set
			{
				if (Loop != value)
				{
					loop = value;
					_Resize(keepPosition: false);
					float num = _loopFirstScrollPosition;
					float num2 = 0f - _loopFirstScrollPosition;
					if (!Loop)
					{
						num = num2;
					}
					float scrollPosition = _scrollPosition + num;
					ScrollPosition = scrollPosition;
					ScrollbarVisibility = ScrollbarVisibility;
				}
			}
		}

		[Token(Token = "0x1700000A")]
		public ScrollbarVisibilityEnum ScrollbarVisibility
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x401CB30", Offset = "0x401CB30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ScrollbarVisibility;\n")]
			get
			{
				return scrollbarVisibility;
			}
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x401C90C", Offset = "0x401C90C", Length = "0x224")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = *([B78F4A2]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0028;\n\tthis.ScrollbarVisibility = value;\n\tv55 = this._scrollbar;\n\tgoto L_001C;\nL_001C:\n\tv60 = UnityEngine.Object::op_Inequality(v55, 0);\n\tv69 = ~v60;\n\tv70 = ~v69;\n\tif (v70) goto L_0037;\n\tgoto L_00D8;\nL_0028:\n\t*([B78F4A2]) = 1;\n\tthis.ScrollbarVisibility = value;\n\tv55 = this._scrollbar;\n\tgoto L_001C;\nL_0037:\n\tv84 = this._cellViewOffsetArray;\n\tv85 = this._cellViewOffsetArray == 0;\n\tif (v85) goto L_00D8;\n\tv99 = v84.Count < 1;\n\tif (v99) goto L_00D8;\n\tv213 = this.scrollDirection == 0;\n\tif (v213) goto L_0059;\n\tUnityEngine.UI.ScrollRect::set_horizontalScrollbar(this.ScrollRect, this._scrollbar);\n\tv308 = this._cellViewOffsetArray;\n\tv306 = this._cellViewOffsetArray == 0;\n\tv289 = ~v306;\n\tif (v289) goto L_0060;\n\tgoto L_00EF;\nL_0059:\n\tUnityEngine.UI.ScrollRect::set_verticalScrollbar(this.ScrollRect, this._scrollbar);\n\tv308 = this._cellViewOffsetArray;\nL_0060:\n\tv224 = EnhancedUI.SmallList`1<System.Single>::Last(v308);\n\tv312 = this.scrollDirection == 0;\n\tif (v312) goto L_007B;\n\tv314 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv320 = v224 < v314.width;\n\tv328 = ~v320;\n\tif (v328) goto L_0093;\n\tgoto L_0099;\nL_007B:\n\tv316 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv333 = v224 < v316.height;\n\tif (v333) goto L_0099;\nL_0093:\n\tv228 = this.Loop != 1;\n\tif (v228) goto L_00B2;\nL_0099:\n\tv282 = UnityEngine.Component::get_gameObject(this._scrollbar);\n\tv255 = this.ScrollbarVisibility - 1;\n\tv247 = v255 == 0;\n\tUnityEngine.GameObject::SetActive(v282, v247);\n\tv353 = this._scrollbar == 0;\n\tv295 = ~v353;\n\tv355 = this._scrollbar;\n\tif (v295) goto L_00C7;\n\tgoto L_00EF;\nL_00B2:\n\tv285 = UnityEngine.Component::get_gameObject(this._scrollbar);\n\tv257 = this.ScrollbarVisibility - 2;\n\tv249 = v257 == 0;\n\tv229 = ~v249;\n\tUnityEngine.GameObject::SetActive(v285, v229);\n\tv355 = this._scrollbar;\nL_00C7:\n\tv287 = UnityEngine.Component::get_gameObject(v355);\n\tv137 = UnityEngine.GameObject::get_activeSelf(v287);\n\tv139 = v137 == 0;\n\tif (v139) goto L_00DE;\nL_00D8:\n\treturn;\nL_00DE:\n\tUnityEngine.UI.ScrollRect::set_verticalScrollbar(this.ScrollRect, 0);\n\tUnityEngine.UI.ScrollRect::set_horizontalScrollbar(this.ScrollRect, 0);\n\treturn;\nL_00EF:\n\tthrow System.NullReferenceException;\n")]
			set
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78F4A2]");
				UnityEngine.Object scrollbar;
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					scrollbarVisibility = value;
					scrollbar = _scrollbar;
				}
				else
				{
					_ = 1;
					scrollbarVisibility = value;
					scrollbar = _scrollbar;
				}
				if (!(scrollbar != null))
				{
					return;
				}
				SmallList<float> cellViewOffsetArray = _cellViewOffsetArray;
				if (_cellViewOffsetArray == null || cellViewOffsetArray.Count < 1)
				{
					return;
				}
				SmallList<float> cellViewOffsetArray2;
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					ScrollRect.horizontalScrollbar = _scrollbar;
					cellViewOffsetArray2 = _cellViewOffsetArray;
					if (_cellViewOffsetArray == null)
					{
						goto IL_035a;
					}
				}
				else
				{
					ScrollRect.verticalScrollbar = _scrollbar;
					cellViewOffsetArray2 = _cellViewOffsetArray;
				}
				float num = cellViewOffsetArray2.Last();
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					if (!(num < _scrollRectTransform.rect.width))
					{
						goto IL_020e;
					}
				}
				else if (!(num < _scrollRectTransform.rect.height))
				{
					goto IL_020e;
				}
				goto IL_0230;
				IL_035a:
				throw new NullReferenceException();
				IL_02ff:
				Component scrollbar2;
				GameObject gameObject = scrollbar2.gameObject;
				if (!gameObject.activeSelf)
				{
					ScrollRect.verticalScrollbar = null;
					ScrollRect.horizontalScrollbar = null;
				}
				return;
				IL_0230:
				GameObject gameObject2 = _scrollbar.gameObject;
				int num2 = (int)(ScrollbarVisibility - 1);
				bool active = num2 == 0;
				gameObject2.SetActive(active);
				bool flag = (object)_scrollbar == null;
				bool flag2 = !flag;
				scrollbar2 = _scrollbar;
				if (flag2)
				{
					goto IL_02ff;
				}
				goto IL_035a;
				IL_020e:
				if (Loop)
				{
					goto IL_0230;
				}
				GameObject gameObject3 = _scrollbar.gameObject;
				int num3 = (int)(ScrollbarVisibility - 2);
				bool flag3 = num3 == 0;
				bool active2 = !flag3;
				gameObject3.SetActive(active2);
				scrollbar2 = _scrollbar;
				goto IL_02ff;
			}
		}

		[Token(Token = "0x1700000B")]
		public Vector2 Velocity
		{
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x401CB80", Offset = "0x401CB80", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.ScrollRect;\n\treturn v0.velocity;\n")]
			get
			{
				ScrollRect scrollRect = ScrollRect;
				return scrollRect.velocity;
			}
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x401CB9C", Offset = "0x401CB9C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ScrollRect;\n\tv2.m_Velocity.x = value;\n\tv2.m_Velocity.y = value.y;\n\treturn;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::set_Velocity");
			}
		}

		[Token(Token = "0x1700000C")]
		public float LinearVelocity
		{
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x401CBB8", Offset = "0x401CBB8", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.ScrollRect;\n\tv9 = this.scrollDirection == 0;\n\tif (v9) goto L_0012;\n\tv12 = 0xB8;\n\treturn *([v8 @ X8_v1 (UnityEngine.UI.ScrollRect)+v12 @ X9_v3 (System.Int32)]);\nL_0012:\n\tv33 = 0xBC;\n\treturn *([v8 @ X8_v1 (UnityEngine.UI.ScrollRect)+v33 @ X9_v2 (System.Int32)]);\n")]
			get
			{
				//IL_0055: Expected F4, but got I
				//IL_003f: Expected F4, but got I
				ScrollRect scrollRect = ScrollRect;
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					int num = 184;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ X8_v1 (UnityEngine.UI.ScrollRect)+v12 @ X9_v3 (System.Int32)]");
					return 0f;
				}
				int num2 = 188;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ X8_v1 (UnityEngine.UI.ScrollRect)+v33 @ X9_v2 (System.Int32)]");
				return 0f;
			}
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x401CBF8", Offset = "0x401CBF8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.ScrollRect;\n\tv9 = this.scrollDirection == 0;\n\tif (v9) goto L_0013;\n\tv17 = 0;\n\tv18 = value;\nL_000C:\n\tv8.m_Velocity.x = v18;\n\tv8.m_Velocity.y = v17;\n\treturn;\nL_0013:\n\tv15 = this.ScrollRect == 0;\n\tv16 = ~v15;\n\tv17 = value;\n\tv18 = 0;\n\tif (v16) goto L_000C;\n\tthrow System.NullReferenceException;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::set_LinearVelocity");
			}
		}

		[Token(Token = "0x1700000D")]
		[field: Token(Token = "0x4000029")]
		[field: FieldOffset(Offset = "0xB8")]
		public bool IsScrolling
		{
			[Token(Token = "0x600004A")]
			[Address(RVA = "0x401CC30", Offset = "0x401CC30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsScrolling;\n")]
			get;
			[Token(Token = "0x600004B")]
			[Address(RVA = "0x401CC38", Offset = "0x401CC38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsScrolling = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700000E")]
		[field: Token(Token = "0x400002A")]
		[field: FieldOffset(Offset = "0xB9")]
		public bool IsTweening
		{
			[Token(Token = "0x600004C")]
			[Address(RVA = "0x401CC40", Offset = "0x401CC40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsTweening;\n")]
			get;
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x401CC48", Offset = "0x401CC48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsTweening = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700000F")]
		public bool IsDragging
		{
			[Token(Token = "0x600004E")]
			[Address(RVA = "0x401CC50", Offset = "0x401CC50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsDragging;\n")]
			get
			{
				return _dragging;
			}
		}

		[Token(Token = "0x17000010")]
		public int StartCellViewIndex
		{
			[Token(Token = "0x600004F")]
			[Address(RVA = "0x401CC58", Offset = "0x401CC58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.StartCellViewIndex;\n")]
			get
			{
				return _activeCellViewsStartIndex;
			}
		}

		[Token(Token = "0x17000011")]
		public int EndCellViewIndex
		{
			[Token(Token = "0x6000050")]
			[Address(RVA = "0x401CC60", Offset = "0x401CC60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.EndCellViewIndex;\n")]
			get
			{
				return _activeCellViewsEndIndex;
			}
		}

		[Token(Token = "0x17000012")]
		public int StartDataIndex
		{
			[Token(Token = "0x6000051")]
			[Address(RVA = "0x401CC68", Offset = "0x401CC68", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0051;\nL_003E:\n\tv52 = this.StartCellViewIndex / 0;\n\tv53 = v52 * 0;\n\treturnVal1 = this.StartCellViewIndex - v53;\n\treturn returnVal1;\nL_0016:\n\tv44 = this.Delegate == 0;\n\tif (v44) goto L_003E;\nL_0051:\n\tv182 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\n\tv142 = this.StartCellViewIndex / v182;\n\tv140 = v142 * v182;\n\treturnVal2 = this.StartCellViewIndex - v140;\n\treturn returnVal2;\n")]
			get
			{
				if (Delegate == null)
				{
					int num = StartCellViewIndex / 0;
					int num2 = num * 0;
					return StartCellViewIndex - num2;
				}
				int numberOfCells = Delegate.GetNumberOfCells(this);
				int num3 = StartCellViewIndex / numberOfCells;
				int num4 = num3 * numberOfCells;
				return StartCellViewIndex - num4;
			}
		}

		[Token(Token = "0x17000013")]
		public int EndDataIndex
		{
			[Token(Token = "0x6000052")]
			[Address(RVA = "0x401CE08", Offset = "0x401CE08", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_0051;\nL_003E:\n\tv52 = this.EndCellViewIndex / 0;\n\tv53 = v52 * 0;\n\treturnVal1 = this.EndCellViewIndex - v53;\n\treturn returnVal1;\nL_0016:\n\tv44 = this.Delegate == 0;\n\tif (v44) goto L_003E;\nL_0051:\n\tv182 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\n\tv142 = this.EndCellViewIndex / v182;\n\tv140 = v142 * v182;\n\treturnVal2 = this.EndCellViewIndex - v140;\n\treturn returnVal2;\n")]
			get
			{
				if (Delegate == null)
				{
					int num = EndCellViewIndex / 0;
					int num2 = num * 0;
					return EndCellViewIndex - num2;
				}
				int numberOfCells = Delegate.GetNumberOfCells(this);
				int num3 = EndCellViewIndex / numberOfCells;
				int num4 = num3 * numberOfCells;
				return EndCellViewIndex - num4;
			}
		}

		[Token(Token = "0x17000014")]
		public int ActiveCellCount
		{
			[Token(Token = "0x6000053")]
			[Address(RVA = "0x401CEE0", Offset = "0x401CEE0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._activeCellViews;\n\treturn v0.Count;\n")]
			get
			{
				SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
				return activeCellViews.Count;
			}
		}

		[Token(Token = "0x17000015")]
		public int NumberOfCells
		{
			[Token(Token = "0x6000054")]
			[Address(RVA = "0x401CD40", Offset = "0x401CD40", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv43 = *([v38 @ X20_v2 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv154 = *([v43 @ X8_v5 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv45 = *([v43 @ X8_v5 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v45) goto L_0042;\n\tv123 = *([v43 @ X8_v5 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv123 = v123 + 0x10;\n\tv87 = v154 - 1;\n\tv57 = v154 != 1;\n\tv154 = v87;\n\tif (v57) goto L_0023;\nL_0042:\n\tinterfaceTailCallResult = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\nL_0042:\n\treturn interfaceTailCallResult;\nL_0049:\n\treturn 0;\nL_004B:\n\tv94 = *([v123 @ X10_v4]) << 4;\n\tv135 = v43 + v94;\n\tv157 = v135 + 0x138;\n\t// 87 IndirectJump [v157 @ X0_v6], this.Delegate (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate), this.Delegate (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate), this @ X0 (EnhancedUI.EnhancedScroller.EnhancedScroller), [v157 @ X0_v6+8], [v157 @ X0_v6], v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0012:\n\tv38 = this.Delegate;\n\tv39 = this.Delegate == 0;\n\tif (v39) goto L_0049;\nL_0023:\n\tv115 = *([v123 @ X10_v4-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v115) goto L_004B;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::get_NumberOfCells");
				return default;
			}
		}

		[Token(Token = "0x17000016")]
		public ScrollRect ScrollRect
		{
			[Token(Token = "0x6000055")]
			[Address(RVA = "0x401CEFC", Offset = "0x401CEFC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ScrollRect;\n")]
			get
			{
				return _scrollRect;
			}
		}

		[Token(Token = "0x17000017")]
		public float ScrollRectSize
		{
			[Token(Token = "0x6000056")]
			[Address(RVA = "0x401CB38", Offset = "0x401CB38", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this.scrollDirection == 0;\n\tif (v9) goto L_0017;\n\tv13 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\treturn v13.width;\nL_0017:\n\tv32 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\treturn v32.height;\n")]
			get
			{
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					return _scrollRectTransform.rect.width;
				}
				return _scrollRectTransform.rect.height;
			}
		}

		[Token(Token = "0x17000018")]
		public LayoutElement FirstPadder
		{
			[Token(Token = "0x6000057")]
			[Address(RVA = "0x401CF04", Offset = "0x401CF04", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FirstPadder;\n")]
			get
			{
				return _firstPadder;
			}
		}

		[Token(Token = "0x17000019")]
		public LayoutElement LastPadder
		{
			[Token(Token = "0x6000058")]
			[Address(RVA = "0x401CF0C", Offset = "0x401CF0C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.LastPadder;\n")]
			get
			{
				return _lastPadder;
			}
		}

		[Token(Token = "0x1700001A")]
		public RectTransform Container
		{
			[Token(Token = "0x6000059")]
			[Address(RVA = "0x401CF14", Offset = "0x401CF14", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Container;\n")]
			get
			{
				return _container;
			}
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x401CF1C", Offset = "0x401CF1C", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0028:\n\tv61 = UnityEngine.Object::op_Equality(v48, 0);\n\tv63 = ~v61;\n\tif (v63) goto L_0099;\n\tv140 = UnityEngine.Component::get_gameObject(cellPrefab);\n\tgoto L_003C;\n\tv106 = UnityEngine.GameObject::GetComponent(v105);\n\tv107 = UnityEngine.Component::get_transform(v106);\n\tUnityEngine.Transform::SetParent(v107, this.Container);\n\tv109 = UnityEngine.Component::get_transform(v106);\n\tgoto L_0068;\nL_0068:\n\t// 104 MakeStruct v85 @ AGG401D06C_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v237.zero (UnityEngine.Vector3), v237.zero.y (System.Single), v237.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v109, v85);\n\tv110 = UnityEngine.Component::get_transform(v106);\n\tgoto L_0086;\nL_0086:\n\t// 134 MakeStruct v188 @ AGG401D0C8_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v255.identity (UnityEngine.Quaternion), v255.identity.y (System.Single), v255.identity.z (System.Single), v255.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(v110, v188);\n\tv256 = this.cellViewInstantiated == 0;\n\tv204 = ~v256;\n\tv206 = this.cellViewInstantiated;\n\tv208 = v106;\n\tif (v204) goto L_00A7;\n\tv218 = v106;\n\tgoto L_00B0;\nL_0099:\n\tv108 = UnityEngine.Component::get_gameObject(v48);\n\tUnityEngine.GameObject::SetActive(v108, 1);\n\tv206 = this.cellViewReused;\n\tv185 = this.cellViewReused == 0;\n\tv208 = v48;\n\tv218 = v48;\n\tif (v185) goto L_00B0;\nL_00A7:\n\tEnhancedUI.EnhancedScroller.CellViewReused::Invoke(v206, this, v208);\n\tv218 = v208;\nL_001F:\n\tv48 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetRecycledCellView(this, cellPrefab);\n\tgoto L_0028;\nL_003C:\n\tv105 = UnityEngine.Object::Instantiate(v140);\nL_00B0:\n\treturn v218;\n")]
		public EnhancedScrollerCellView GetCellView(EnhancedScrollerCellView cellPrefab)
		{
			EnhancedScrollerCellView enhancedScrollerCellView = _GetRecycledCellView(cellPrefab);
			CellViewReused cellViewReused;
			EnhancedScrollerCellView enhancedScrollerCellView2;
			EnhancedScrollerCellView result;
			if (enhancedScrollerCellView == null)
			{
				GameObject original = cellPrefab.gameObject;
				GameObject gameObject = UnityEngine.Object.Instantiate(original);
				EnhancedScrollerCellView component = gameObject.GetComponent<EnhancedScrollerCellView>();
				Transform transform = component.transform;
				transform.SetParent(Container);
				Transform transform2 = component.transform;
				Vector3 localPosition = default(Vector3);
				localPosition.x = Vector3.zero.x;
				localPosition.y = Vector3.zero.y;
				localPosition.z = Vector3.zero.z;
				transform2.localPosition = localPosition;
				Transform transform3 = component.transform;
				Quaternion localRotation = default(Quaternion);
				localRotation.x = Quaternion.identity.x;
				localRotation.y = Quaternion.identity.y;
				localRotation.z = Quaternion.identity.z;
				localRotation.w = Quaternion.identity.w;
				transform3.localRotation = localRotation;
				bool flag = cellViewInstantiated == null;
				bool flag2 = !flag;
				cellViewReused = (CellViewReused)(object)cellViewInstantiated;
				enhancedScrollerCellView2 = component;
				if (flag2)
				{
					goto IL_01d8;
				}
				result = component;
			}
			else
			{
				GameObject gameObject2 = enhancedScrollerCellView.gameObject;
				gameObject2.SetActive(value: true);
				cellViewReused = this.cellViewReused;
				bool flag3 = this.cellViewReused == null;
				enhancedScrollerCellView2 = enhancedScrollerCellView;
				result = enhancedScrollerCellView;
				if (!flag3)
				{
					goto IL_01d8;
				}
			}
			goto IL_0218;
			IL_0218:
			return result;
			IL_01d8:
			cellViewReused(this, enhancedScrollerCellView2);
			result = enhancedScrollerCellView2;
			goto IL_0218;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x401D23C", Offset = "0x401D23C", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = *([B78F511]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0020;\n\tthis._reloadData = 0;\n\tv28 = *([B78F517]) & 1;\n\tv29 = v28 == 0;\n\tif (v29) goto L_002C;\nL_0017:\n\tv161 = this._activeCellViews;\n\tv55 = this._activeCellViews == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0031;\n\tgoto L_004C;\nL_0020:\n\t*([B78F511]) = 1;\n\tthis._reloadData = 0;\n\tv65 = *([B78F517]) & 1;\n\tv66 = v65 == 0;\n\tv49 = ~v66;\n\tif (v49) goto L_0017;\nL_002C:\n\t*([B78F517]) = 1;\n\tv161 = this._activeCellViews;\nL_0031:\n\tv136 = 0xB292000 + 0x5A0;\nL_FFFFFFFF:\n\t;\n\tv189 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v161, 0);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RecycleCell(this, v189);\n\tv161 = this._activeCellViews;\n\tv205 = this._activeCellViews == 0;\n\tv141 = ~v205;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v141) goto L_0040;\nL_004C:\n\tthrow System.NullReferenceException;\nL_004D:\n\tthis.StartCellViewIndex = 0;\n\tv187 = this.Delegate == 0;\n\tif (v187) goto L_0055;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_Resize(this, 0);\nL_0055:\n\tv195 = *([v136 @ X21_v1 (System.Int32)]);\n\tv197 = *([v195 @ X8_v4+E4]) == 0;\n\tif (v197) goto L_0066;\n\tv201 = UnityEngine.Object::op_Equality(this.ScrollRect, 0);\n\tv207 = v201 == 0;\n\tif (v207) goto L_006C;\n\tgoto L_008D;\nL_0066:\n\tv211 = UnityEngine.Object::op_Equality(this.ScrollRect, 0);\n\tv222 = v211 == 0;\n\tv216 = ~v222;\n\tif (v216) goto L_008D;\nL_006C:\n\tv219 = *([v136 @ X21_v1 (System.Int32)]);\n\tv220 = *([v219 @ X8_v6+E4]) == 0;\n\tif (v220) goto L_007D;\n\tv236 = UnityEngine.Object::op_Equality(this._scrollRectTransform, 0);\n\tv241 = v236 == 0;\n\tif (v241) goto L_0083;\n\tgoto L_008D;\nL_007D:\n\tv237 = UnityEngine.Object::op_Equality(this._scrollRectTransform, 0);\n\tv315 = v237 == 0;\n\tv242 = ~v315;\n\tif (v242) goto L_008D;\nL_0083:\n\tv312 = *([v136 @ X21_v1 (System.Int32)]);\n\tv313 = *([v312 @ X0_v8+E4]) == 0;\n\tif (v313) goto L_009C;\n\tv235 = UnityEngine.Object::op_Equality(this.Container, 0);\n\tv240 = ~v235;\nL_FFFFFFFF:\n\t;\n\tif (v240) goto L_00A1;\nL_008D:\n\tthis._scrollPosition = 0f;\n\treturn;\nL_009C:\n\tv238 = UnityEngine.Object::op_Equality(this.Container, 0);\n\tv323 = ~v238;\n\tv243 = ~v323;\nL_FFFFFFFF:\n\t;\n\tif (v243) goto L_008D;\nL_00A1:\n\tv322 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv123 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv326 = v322 * scrollPositionFactor;\n\tv327 = v326 < v123;\n\tv328 = v326 == v123;\n\tv331 = v326 == v326;\n\tv103 = v123 == v123;\n\tv332 = v331 & v103;\n\tv333 = ~v332;\n\tv334 = v327 == v333;\n\tv91 = ~v328;\n\tv95 = v334 & v91;\n\tv335 = ~v95;\n\tif (v335) goto L_FFFFFFFF;\n\tgoto L_00B7;\nL_FFFFFFFF:\n\tv123 = v326;\nL_FFFFFFFF:\n\tv123 = 0;\n\tgoto L_00C4;\n\tUnityEngine.UI.ScrollRect::set_horizontalNormalizedPosition(this.ScrollRect, scrollPositionFactor);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this);\n\treturn;\nL_00DD:\n\tv270 = 1f - scrollPositionFactor;\n\tUnityEngine.UI.ScrollRect::set_verticalNormalizedPosition(this.ScrollRect, v270);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this);\n\treturn;\nL_0040:\n\tv93 = v161.Count <= 0;\n\tif (v93) goto L_004D;\nL_00B7:\n\tv119 = v326 < 0;\n\tv88 = ~v119;\n\tif (v88) goto L_00C4;\nL_00C4:\n\tthis._scrollPosition = v123;\n\tv342 = this.scrollDirection == 0;\n\tif (v342) goto L_00DD;\n")]
		public void ReloadData(float scrollPositionFactor = 0f)
		{
			//IL_01c1: Expected O, but got I4
			//IL_025d: Expected O, but got I4
			//IL_02f9: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78F511]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				_reloadData = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78F517]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0071;
				}
			}
			else
			{
				_ = 1;
				_reloadData = false;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78F517]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					goto IL_0071;
				}
			}
			_ = 1;
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			goto IL_010a;
			IL_0172:
			throw new NullReferenceException();
			IL_010a:
			int num = 187244544 + 1440;
			while (true)
			{
				if (activeCellViews.Count > 0)
				{
					EnhancedScrollerCellView cellView = activeCellViews[0];
					_RecycleCell(cellView);
					activeCellViews = _activeCellViews;
					if (_activeCellViews == null)
					{
						break;
					}
					continue;
				}
				_activeCellViewsStartIndex = 0;
				_activeCellViewsEndIndex = 0;
				if (Delegate != null)
				{
					_Resize(keepPosition: false);
				}
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v195 @ X8_v4+E4]");
				if ((nint)0 != 0)
				{
					if (!(ScrollRect == null))
					{
						goto IL_0255;
					}
				}
				else if (!(ScrollRect == null))
				{
					goto IL_0255;
				}
				goto IL_0348;
				IL_0348:
				_scrollPosition = 0f;
				return;
				IL_02f1:
				object obj2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v312 @ X0_v8+E4]");
				if ((nint)0 != 0)
				{
					if (Container == null)
					{
						goto IL_0348;
					}
				}
				else if (Container == null)
				{
					goto IL_0348;
				}
				float scrollSize = ScrollSize;
				float num2 = ScrollSize;
				float num3 = scrollSize * scrollPositionFactor;
				bool flag = num3 < num2;
				bool flag2 = num3 == num2;
				bool flag3 = num3 == num3;
				bool flag4 = num2 == num2;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if (!(flag7 && flag8))
				{
					num2 = num3;
				}
				if (num3 < 0f)
				{
					num2 = 0f;
				}
				_scrollPosition = num2;
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					ScrollRect.horizontalNormalizedPosition = scrollPositionFactor;
					_RefreshActive();
				}
				else
				{
					float verticalNormalizedPosition = 1f - scrollPositionFactor;
					ScrollRect.verticalNormalizedPosition = verticalNormalizedPosition;
					_RefreshActive();
				}
				return;
				IL_0255:
				object obj3 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v219 @ X8_v6+E4]");
				if ((nint)0 != 0)
				{
					if (!(_scrollRectTransform == null))
					{
						goto IL_02f1;
					}
				}
				else if (!(_scrollRectTransform == null))
				{
					goto IL_02f1;
				}
				goto IL_0348;
			}
			goto IL_0172;
			IL_0071:
			activeCellViews = _activeCellViews;
			if (_activeCellViews != null)
			{
				goto IL_010a;
			}
			goto IL_0172;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x401D638", Offset = "0x401D638", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv95 = 0;\n\tv86 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v108, v95);\n\tv135 = EnhancedUI.EnhancedScroller.EnhancedScrollerCellView::RefreshCellView(v86);\n\tv95 = v95 + 1;\n\tv108 = this._activeCellViews;\n\tv136 = this._activeCellViews == 0;\n\tv88 = ~v136;\n\tif (v88) goto L_0024;\n\tthrow System.NullReferenceException;\nL_003C:\n\treturn;\nL_0014:\n\tv108 = this._activeCellViews;\nL_0024:\n\tv48 = v95 >= v108.Count;\n\tif (v48) goto L_003C;\n")]
		public void RefreshActiveCellViews()
		{
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			int num = 0;
			while (num < activeCellViews.Count)
			{
				EnhancedScrollerCellView enhancedScrollerCellView = activeCellViews[num];
				enhancedScrollerCellView.RefreshCellView();
				num++;
				activeCellViews = _activeCellViews;
				if (_activeCellViews == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x401D6C8", Offset = "0x401D6C8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearActive(this);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ClearRecycled(this);\n\treturn;\n")]
		public void ClearAll()
		{
			ClearActive();
			ClearRecycled();
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x401D6EC", Offset = "0x401D6EC", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv112 = 0;\n\tgoto L_0037;\nL_0028:\n\tUnityEngine.Object::DestroyImmediate(v164);\n\tv112 = v112 + 1;\n\tv127 = this._activeCellViews;\nL_0037:\n\tv69 = v112 >= v127.Count;\n\tif (v69) goto L_0054;\n\tv103 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v127, v112);\n\tv164 = UnityEngine.Component::get_gameObject(v103);\n\tgoto L_0028;\nL_0054:\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::Clear(v127);\n\treturn;\nL_001C:\n\tv127 = this._activeCellViews;\n")]
		public void ClearActive()
		{
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			int num = 0;
			while (num < activeCellViews.Count)
			{
				Component component = activeCellViews[num];
				GameObject obj = component.gameObject;
				UnityEngine.Object.DestroyImmediate(obj);
				num++;
				activeCellViews = _activeCellViews;
			}
			activeCellViews.Clear();
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x401D7D8", Offset = "0x401D7D8", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv112 = 0;\n\tgoto L_0037;\nL_0028:\n\tUnityEngine.Object::DestroyImmediate(v164);\n\tv112 = v112 + 1;\n\tv127 = this._recycledCellViews;\nL_0037:\n\tv69 = v112 >= v127.Count;\n\tif (v69) goto L_0054;\n\tv103 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v127, v112);\n\tv164 = UnityEngine.Component::get_gameObject(v103);\n\tgoto L_0028;\nL_0054:\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::Clear(v127);\n\treturn;\nL_001C:\n\tv127 = this._recycledCellViews;\n")]
		public void ClearRecycled()
		{
			SmallList<EnhancedScrollerCellView> recycledCellViews = _recycledCellViews;
			int num = 0;
			while (num < recycledCellViews.Count)
			{
				Component component = recycledCellViews[num];
				GameObject obj = component.gameObject;
				UnityEngine.Object.DestroyImmediate(obj);
				num++;
				recycledCellViews = _recycledCellViews;
			}
			recycledCellViews.Clear();
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x401D8C4", Offset = "0x401D8C4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.Loop ^ 1;\n\tthis.Loop = v17;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_Resize(this, 0);\n\tv37 = this._loopFirstScrollPosition;\n\tv23 = -this._loopFirstScrollPosition;\n\tv28 = this.Loop == 0;\n\tv33 = ~v28;\n\tv34 = ~v33;\n\tif (v34) goto L_FFFFFFFF;\n\tgoto L_0022;\nL_FFFFFFFF:\n\tv37 = v23;\nL_0022:\n\tv38 = this._scrollPosition + v37;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, v38);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollbarVisibility(this, this.ScrollbarVisibility);\n\treturn;\n")]
		public void ToggleLoop()
		{
			int num = (Loop ? 1 : 0) ^ 1;
			loop = (byte)num != 0;
			_Resize(keepPosition: false);
			float num2 = _loopFirstScrollPosition;
			float num3 = 0f - _loopFirstScrollPosition;
			if (!Loop)
			{
				num2 = num3;
			}
			float scrollPosition = _scrollPosition + num2;
			ScrollPosition = scrollPosition;
			ScrollbarVisibility = ScrollbarVisibility;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x401D928", Offset = "0x401D928", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._ignoreLoopJump = ignore;\n\treturn;\n")]
		public void IgnoreLoopJump(bool ignore)
		{
			_ignoreLoopJump = ignore;
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x401D930", Offset = "0x401D930", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, scrollPosition);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this);\n\treturn;\n")]
		public void SetScrollPositionImmediately(float scrollPosition)
		{
			ScrollPosition = scrollPosition;
			_RefreshActive();
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x401D954", Offset = "0x401D954", Length = "0x694")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv62 = 0xB78F000;\n\tv64 = *([B78F513]) & 1;\n\tv65 = v64 == 0;\n\tif (v65) goto L_00CE;\n\tv68 = cellOffset == 0;\n\tv73 = ~v68;\nL_FFFFFFFF:\n\tv167 = 0;\nL_FFFFFFFF:\n\tv487 = 0;\n\tif (v73) goto L_00D8;\nL_0030:\n\tv102 = scrollerOffset == 1f;\n\tv109 = ~v102;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv361 = v167;\n\tif (v109) goto L_0182;\nL_003D:\n\tv250 = UnityEngine.RectOffset::get_bottom(this.padding);\n\tv361 = v167 + v250;\n\tv317 = this._scrollRectTransform;\n\tv498 = this.scrollDirection == 0;\n\tv390 = ~v498;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv318 = this._scrollRectTransform;\nL_FFFFFFFF:\n\tv362 = v361;\n\tif (v390) goto L_0188;\nL_0048:\n\tv502 = UnityEngine.RectTransform::get_rect(v317);\n\tv594 = v502.height;\n\tv711 = v502.height * scrollerOffset;\n\tv773 = v361 - v711;\n\tv718 = this.Loop == 1;\nL_FFFFFFFF:\n\tv597 = v502.height;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv301 = v773;\n\tif (v718) goto L_019F;\nL_005D:\n\tv794 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForDataIndex(this, dataIndex, 0);\n\tv810 = v773 + v794;\n\tv813 = ~useSpacing;\nL_FFFFFFFF:\n\tv851 = 0;\n\tif (v813) goto L_0065;\n\tv851 = this.spacing;\n\tgoto L_007E;\nL_FFFFFFFF:\n\tv1441 = v1463;\nL_FFFFFFFF:\n\tv1063 = 0;\n\tgoto L_0084;\nL_FFFFFFFF:\n\tv1063 = v1441;\nL_0095:\n\tgoto L_009C;\n\tv1126.tweenType = v1067;\n\tv1126.time = tweenTime;\n\tv1126.start = v1065;\n\tv1126.end = v1063;\n\tv1126.tweenComplete = jumpComplete;\n\tv1126.forceCalculateRange = v1069;\n\tv606 = UnityEngine.MonoBehaviour::StartCoroutine(this, v1126);\n\treturn;\nL_00CE:\n\t*([v62 @ X26_v1+513]) = 1;\n\tv93 = cellOffset == 0;\nL_FFFFFFFF:\n\tv167 = 0;\nL_FFFFFFFF:\n\tv487 = 0;\n\tif (v93) goto L_0030;\nL_00D8:\n\tv120 = this.Delegate == 0;\nL_FFFFFFFF:\n\t;\n\tif (v120) goto L_010B;\n\tgoto L_0109;\n\tv487 = v487 + this.spacing;\n\tv434 = dataIndex < 1;\n\tif (v434) goto L_0176;\n\tgoto L_0127;\n\tgoto L_0165;\nL_015A:\n\tv465 = -1 > dataIndex;\n\tif (v465) goto L_0175;\n\tgoto L_0176;\nL_0175:\n\tv487 = v487 + this.spacing;\nL_0182:\n\tv317 = this._scrollRectTransform;\n\tv202 = this.scrollDirection == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv318 = this._scrollRectTransform;\nL_FFFFFFFF:\n\tv362 = v361;\n\tif (v202) goto L_0048;\nL_0188:\n\tv500 = UnityEngine.RectTransform::get_rect(v318);\n\tv597 = v500.width;\n\tv594 = v500.height;\n\tv694 = v500.width * scrollerOffset;\n\tv773 = v362 - v694;\n\tv706 = this.Loop != 1;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv301 = v773;\n\tif (v706) goto L_005D;\nL_019F:\n\tgoto L_01A7;\n\tgoto L_01D9;\nL_FFFFFFFF:\n\tv378 = this.Delegate;\nL_FFFFFFFF:\n\tv382 = forceCalculateRange;\n\tgoto L_01DC;\n\tv1012 = this.scrollDirection == 0;\n\tif (v1012) goto L_0228;\n\tv1026 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv307 = v1026.width;\n\tv304 = v1026.height;\n\tv1092 = loopJumpDirection - 1;\n\tv1093 = v1092 < 1;\n\tv1094 = ~v1093;\n\tv1095 = v1092 - 1;\n\tv1097 = v1095 == 0;\n\tv1102 = ~v1097;\n\tv1103 = v1094 & v1102;\nL_FFFFFFFF:\n\tv594 = v1026.height;\n\tif (v1103) goto L_FFFFFFFF;\nL_0206:\n\tv374 = this._cellViewOffsetArray;\n\tv1153 = v307 * scrollerOffset;\n\tv1154 = v1153 + this._scrollPosition;\n\tv1158 = v1154 + 0x38D1B717;\n\tv1160 = v374.Count - 1;\n\tv1048 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetCellIndexAtPosition(this, v1158, 0, v1160);\n\tv1186 = v1048 >= v378;\n\tif (v1186) goto L_0307;\nL_FFFFFFFF:\n\tv1164 = 0;\nL_FFFFFFFF:\n\tv1030 = 0;\nL_FFFFFFFF:\n\tv1035 = dataIndex;\nL_FFFFFFFF:\n\tv594 = v304;\nL_FFFFFFFF:\n\tv1061 = 1;\n\tgoto L_023F;\nL_0228:\n\tv1028 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv304 = v1028.height;\n\tv1108 = loopJumpDirection - 1;\n\tv1109 = v1108 < 1;\n\tv1110 = ~v1109;\n\tv1111 = v1108 - 1;\n\tv1113 = v1111 == 0;\n\tv1118 = ~v1110;\n\tv1119 = v1118 | v1113;\nL_FFFFFFFF:\n\tv307 = v1028.height;\nL_FFFFFFFF:\n\tv594 = v1028.height;\n\tif (v1119) goto L_0206;\nL_FFFFFFFF:\n\tv1164 = 0;\nL_FFFFFFFF:\n\tv1030 = 0;\nL_FFFFFFFF:\n\tv1035 = 0;\nL_FFFFFFFF:\n\tv1048 = 0;\nL_FFFFFFFF:\n\tv1061 = 0;\n\tv1227 = loopJumpDirection == 1;\n\tif (v1227) goto L_027E;\n\tv1253 = loopJumpDirection == 0;\n\tv1254 = ~v1253;\nL_FFFFFFFF:\n\tv1063 = 0;\nL_FFFFFFFF:\n\tv1067 = tweenType;\nL_FFFFFFFF:\n\tv1069 = v382;\n\tif (v1254) goto L_02C7;\n\t// 604 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 605 NotImplemented \"Instruction FABD not yet implemented.\"\n\t// 606 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv1298 = v594 < v80;\n\tv1306 = ~v1298;\n\tif (v1306) goto L_032E;\n\tv1343 = v594 < v79;\nL_FFFFFFFF:\n\tv1063 = v1463;\nL_FFFFFFFF:\n\tv1067 = tweenType;\nL_FFFFFFFF:\n\tv1069 = v382;\n\tif (v1343) goto L_02C7;\n\tgoto L_FFFFFFFF;\nL_027E:\n\tv1265 = v1035 < v1048;\n\tif (v1265) goto L_02A9;\n\tv1397 = v1061 ^ 1;\n\tv1365 = v1048 != dataIndex;\n\tif (v1365) goto L_FFFFFFFF;\n\tgoto L_0291;\nL_FFFFFFFF:\n\tv1397 = 1;\n\tv1441 = this._singleLoopGroupSize;\n\tv1063 = v1463 - this._singleLoopGroupSize;\nL_FFFFFFFF:\n\tv1069 = v382;\n\tgoto L_FFFFFFFF;\nL_02A3:\n\tv1243 = v1035 <= v1048;\n\tif (v1243) goto L_0320;\nL_02A9:\n\tv1279 = v1030 == 0;\n\tv1284 = ~v1279;\n\tv1285 = ~v1284;\n\tif (v1285) goto L_02B9;\nL_FFFFFFFF:\n\tv1441 = v597;\n\tgoto L_02B9;\nL_FFFFFFFF:\n\tv1063 = v1463;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1063 = v1441;\n\tv1441 = this.spacing;\n\tv1063 = v1063 - this.spacing;\nL_02D6:\n\tv639 = jumpComplete == 0;\n\tif (v639) goto L_0306;\n\tSystem.Action::Invoke(jumpComplete);\n\treturn;\nL_0306:\n\treturn;\nL_0307:\n\tv1248 = v378 << 1;\n\tv1187 = v1048 >= v1248;\n\tif (v1187) goto L_033C;\nL_FFFFFFFF:\n\tv1164 = 0;\nL_FFFFFFFF:\n\tv1030 = 1;\nL_FFFFFFFF:\n\tv594 = v304;\nL_FFFFFFFF:\n\tv1061 = 0;\n\tgoto L_023F;\nL_0320:\n\tv1392 = v1164 ^ 1;\n\tv1296 = v1048 != v1035;\n\tif (v1296) goto L_FFFFFFFF;\n\tgoto L_0327;\nL_FFFFFFFF:\n\tv1392 = 1;\n\tv1463 = this._singleLoopGroupSize;\n\tv1063 = v1441 + this._singleLoopGroupSize;\n\tgoto L_FFFFFFFF;\nL_032E:\n\tv1344 = v80 < v79;\nL_FFFFFFFF:\n\tv1063 = v597;\nL_FFFFFFFF:\n\tv1067 = tweenType;\nL_FFFFFFFF:\n\tv1069 = v382;\n\tif (v1344) goto L_02C7;\nL_FFFFFFFF:\n\tv1063 = v1441;\nL_FFFFFFFF:\n\tv1067 = tweenType;\nL_FFFFFFFF:\n\tv1069 = v382;\n\tgoto L_02C7;\nL_033C:\n\tv1035 = v1248 + dataIndex;\nL_FFFFFFFF:\n\tv1164 = 1;\nL_FFFFFFFF:\n\tv1030 = 0;\nL_FFFFFFFF:\n\tv594 = v304;\nL_FFFFFFFF:\n\tv1061 = 0;\n\tgoto L_023F;\nL_0343:\n\tv1423 = v1030 == 0;\n\tv1428 = ~v1423;\n\tv1429 = ~v1428;\n\tif (v1429) goto L_FFFFFFFF;\n\tgoto L_0353;\nL_FFFFFFFF:\n\tv1463 = v597;\nL_FFFFFFFF:\n\tv1063 = v1441;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1063 = v1463;\nL_0364:\n\tv1410 = v1030 == 0;\n\tv1415 = ~v1410;\n\tv1416 = ~v1415;\n\tif (v1416) goto L_FFFFFFFF;\n\tgoto L_0374;\nL_FFFFFFFF:\n\tv1441 = v1463;\nL_FFFFFFFF:\n\tv1063 = v597;\n\tgoto L_0380;\nL_FFFFFFFF:\n\tv1063 = v1441;\nL_0065:\n\tv1441 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv1463 = v810 - v851;\n\tv933 = v1463 < v1441;\n\tv934 = v1463 == v1441;\n\tv937 = v1463 == v1463;\n\tv938 = v1441 == v1441;\n\tv939 = v937 & v938;\n\tv940 = ~v939;\n\tv941 = v933 == v940;\n\tv942 = ~v934;\n\tv943 = v941 & v942;\n\tv944 = ~v943;\n\tif (v944) goto L_FFFFFFFF;\nL_007E:\n\tv1011 = v810 >= v851;\n\tif (v1011) goto L_FFFFFFFF;\nL_0084:\n\tv1065 = this._scrollPosition;\n\tv1018 = v1063 == this._scrollPosition;\nL_FFFFFFFF:\n\tv1067 = tweenType;\nL_FFFFFFFF:\n\tv1069 = forceCalculateRange;\n\tif (v1018) goto L_02D6;\nL_009C:\n\tv1126 = new EnhancedUI.EnhancedScroller.EnhancedScroller+<TweenPosition>d__190();\n\tSystem.Object::.ctor(v1126);\n\tv1126.<>1__state = 0;\n\tv1126.<>4__this = this;\nL_010B:\n\tv248 = ~useSpacing;\n\tif (v248) goto L_0176;\nL_0109:\n\tv227 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetCellViewSize(this.Delegate, this, dataIndex);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv487 = scrollerOffset;\nL_0176:\n\tv167 = v487 * cellOffset;\n\tv164 = scrollerOffset == 1f;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv361 = v167;\n\tif (v164) goto L_003D;\nL_0127:\n\tv490 = this.Delegate == 0;\n\tif (v490) goto L_015A;\nL_0165:\n\tv457 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\n\tv494 = v457 - 1;\n\tv466 = v494 <= dataIndex;\n\tif (v466) goto L_0176;\nL_01A7:\n\tv809 = this.Delegate == 0;\n\tif (v809) goto L_FFFFFFFF;\nL_01D9:\n\tv915 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\nL_FFFFFFFF:\n\tv378 = v915;\nL_FFFFFFFF:\n\tv382 = forceCalculateRange;\nL_01DC:\n\tv279 = this._loopFirstCellIndex + dataIndex;\n\tv928 = v279 - v378;\n\tv1035 = v378 + dataIndex;\n\tv931 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this, v9\n// ... truncated")]
		public void JumpToDataIndex(int dataIndex, float scrollerOffset = 0f, float cellOffset = 0f, bool useSpacing = true, TweenType tweenType = TweenType.immediate, float tweenTime = 0f, Action jumpComplete = null, LoopJumpDirectionEnum loopJumpDirection = LoopJumpDirectionEnum.Closest, bool forceCalculateRange = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::JumpToDataIndex");
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x401E430", Offset = "0x401E430", Length = "0x2D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = 0xB78F000;\n\tv30 = *([B78F514]) & 1;\n\tv31 = v30 == 0;\n\tif (v31) goto L_0025;\n\tv34 = *([B78F510]) & 1;\n\tv35 = v34 == 0;\n\tif (v35) goto L_0030;\nL_0019:\n\tv80 = this.Delegate;\n\tv63 = this.Delegate == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0037;\n\tgoto L_0092;\nL_0025:\n\t*([v28 @ X20_v1+514]) = 1;\n\tv89 = *([B78F510]) & 1;\n\tv90 = v89 == 0;\n\tv59 = ~v90;\n\tif (v59) goto L_0019;\nL_0030:\n\t*([B78F510]) = 1;\n\tv80 = this.Delegate;\n\tv77 = this.Delegate == 0;\n\tif (v77) goto L_0092;\nL_0037:\n\tv85 = *([v80 @ X20_v4 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv302 = *([v85 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv87 = *([v85 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v87) goto L_005C;\n\tv138 = *([v85 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv138 = v138 + 0x10;\n\tv184 = v302 - 1;\n\tv174 = v302 != 1;\nL_FFFFFFFF:\n\tv302 = v184;\n\tif (v174) goto L_0042;\nL_005C:\n\tv151 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v80, this);\n\tv155 = v151 == 0;\n\tif (v155) goto L_0092;\nL_0060:\n\tthis._snapJumping = 1;\n\tv270 = this.ScrollRect;\n\tv270.velocity = 0;\n\tthis._snapInertia = v270.inertia;\n\tv270.inertia = 0;\n\tv322 = this.scrollDirection == 0;\n\tif (v322) goto L_0096;\n\tv329 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv342 = v329.width;\n\tv347 = this._cellViewOffsetArray;\n\tv340 = this._cellViewOffsetArray == 0;\n\tv335 = ~v340;\n\tif (v335) goto L_00A0;\n\tgoto L_012F;\nL_007A:\n\tv96 = *([v138 @ X10_v15]) << 4;\n\tv306 = v85 + v96;\n\tv307 = v306 + 0x138;\n\t*([v307 @ X0_v28])(v150, v80, this, *([v307 @ X0_v28+8]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv309 = v150 == 0;\n\tv154 = ~v309;\n\tif (v154) goto L_0060;\nL_0092:\n\treturn;\nL_0096:\n\tv330 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv347 = this._cellViewOffsetArray;\nL_FFFFFFFF:\n\tv342 = v330.height;\nL_00A0:\n\tv350 = this.snapWatchOffset < 1f;\n\tv351 = this.snapWatchOffset == 1f;\n\tv354 = this.snapWatchOffset == this.snapWatchOffset;\n\tv355 = 1f == 1f;\n\tv356 = v354 & v355;\n\tv357 = ~v356;\n\tv358 = v350 == v357;\n\tv204 = ~v351;\n\tv359 = v358 & v204;\n\tv360 = ~v359;\n\tif (v360) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv363 = 1f;\n\tgoto L_00B1;\nL_FFFFFFFF:\n\tv363 = this.snapWatchOffset;\nL_FFFFFFFF:\n\tv373 = 0;\n\tgoto L_00BE;\nL_FFFFFFFF:\n\tv373 = v363;\n\tgoto L_0101;\nL_FFFFFFFF:\n\tv445 = 0;\n\tgoto L_0102;\n\treturn;\nL_012F:\n\tthrow System.NullReferenceException;\nL_0042:\n\tv122 = *([v138 @ X10_v15-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v122) goto L_007A;\nL_00B1:\n\tv364 = this.snapWatchOffset < 0;\n\tv201 = ~v364;\n\tif (v201) goto L_FFFFFFFF;\nL_00BE:\n\tv374 = v342 * v373;\n\tv375 = this._scrollPosition + v374;\n\tv377 = v347.Count - 1;\n\tv380 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetCellIndexAtPosition(this, v375, 0, v377);\n\tthis._snapCellViewIndex = v380;\n\tgoto L_00D2;\nL_00D2:\n\tv393 = this.Delegate == 0;\n\tif (v393) goto L_FFFFFFFF;\nL_0101:\n\tv445 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\nL_0102:\n\tv450 = v380 / v445;\n\tv282 = v450 * v445;\n\tv451 = v380 - v282;\n\tthis._snapDataIndex = v451;\n\tv460 = new System.Action();\n\tSystem.Action::.ctor(v460, this, Il2CppMethodInfo);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::JumpToDataIndex(this, v451, this.snapJumpToOffset, this.snapCellCenterOffset, this.snapUseCellSpacing, this.snapTweenType, this.snapTweenTime, v460, 0, 0);\n")]
		public void Snap()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::Snap");
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x401DFE8", Offset = "0x401DFE8", Length = "0x270")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB78F000;\n\tv26 = *([B78F515]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0021;\n\tv30 = *([B78F510]) & 1;\n\tv31 = v30 == 0;\n\tif (v31) goto L_002C;\nL_0017:\n\tv76 = this.Delegate;\n\tv57 = this.Delegate == 0;\n\tv58 = ~v57;\n\tv70 = 0;\n\tif (v58) goto L_0034;\n\tv144 = 0;\n\tgoto L_008B;\nL_0021:\n\t*([v24 @ X22_v1+515]) = 1;\n\tv67 = *([B78F510]) & 1;\n\tv68 = v67 == 0;\n\tv50 = ~v68;\n\tif (v50) goto L_0017;\nL_002C:\n\t*([B78F510]) = 1;\n\tv76 = this.Delegate;\n\tv73 = this.Delegate == 0;\n\tv70 = 0;\n\tv144 = 0;\n\tif (v73) goto L_008B;\nL_0034:\n\tv81 = *([v76 @ X22_v4 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv313 = *([v81 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv83 = *([v81 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v83) goto L_0059;\n\tv131 = *([v81 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv131 = v131 + 0x10;\n\tv173 = v313 - 1;\n\tv163 = v313 != 1;\n\tv313 = v173;\n\tif (v163) goto L_003F;\nL_0059:\n\tv143 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v76, this);\n\tv147 = v143 == 0;\n\tv144 = v70;\n\tif (v147) goto L_008B;\nL_0067:\n\tv211 = cellViewIndex > 0;\n\tif (v211) goto L_008C;\n\tv336 = insertPosition == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_008C;\n\tv341 = this.scrollDirection == 0;\n\tif (v341) goto L_00BF;\n\tv257 = UnityEngine.RectOffset::get_left(this.padding);\n\tgoto L_00CB;\nL_0076:\n\tv89 = *([v131 @ X10_v6]) << 4;\n\tv317 = v81 + v89;\n\tv318 = v317 + 0x138;\n\t*([v318 @ X0_v23])(v142, v76, this, *([v318 @ X0_v23+8]), methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv320 = v142 == 0;\n\tv146 = ~v320;\n\tv144 = v70;\n\tif (v146) goto L_0067;\nL_008B:\n\treturn v144;\nL_008C:\n\tv256 = this._cellViewOffsetArray;\n\tv268 = ~cellViewIndex;\n\tv342 = cellViewIndex & v268;\n\tv210 = v342 >= v256.Count;\n\tif (v210) goto L_00AD;\n\tv360 = insertPosition == 0;\n\tif (v360) goto L_00CC;\n\tv346 = EnhancedUI.SmallList`1<System.Single>::get_Item(v256, v342);\n\tv371 = this.scrollDirection == 0;\n\tif (v371) goto L_00DF;\n\tv258 = UnityEngine.RectOffset::get_left(this.padding);\n\tgoto L_00E1;\nL_00AD:\n\tv250 = v256.Count - 2;\n\treturnVal3 = EnhancedUI.SmallList`1<System.Single>::get_Item(v256, v250);\n\treturn returnVal3;\nL_00BF:\n\tv257 = UnityEngine.RectOffset::get_top(this.padding);\nL_00CB:\n\treturn v257;\nL_00CC:\n\tv348 = v342 - 1;\n\tv347 = EnhancedUI.SmallList`1<System.Single>::get_Item(v256, v348);\n\tv372 = this.scrollDirection == 0;\n\tif (v372) goto L_00F0;\n\tv259 = UnityEngine.RectOffset::get_left(this.padding);\n\tgoto L_00F1;\nL_00DF:\n\tv258 = UnityEngine.RectOffset::get_top(this.padding);\nL_00E1:\n\tv382 = v346 + v258;\n\treturn v382;\nL_00F0:\n\tv259 = UnityEngine.RectOffset::get_top(this.padding);\nL_00F1:\n\tv383 = v347 + this.spacing;\n\tv384 = v383 + v259;\n\treturn v384;\nL_003F:\n\tv115 = *([v131 @ X10_v6-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v115) goto L_0076;\n")]
		public float GetScrollPositionForCellViewIndex(int cellViewIndex, CellViewPositionEnum insertPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::GetScrollPositionForCellViewIndex");
			return default;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x401E27C", Offset = "0x401E27C", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv55 = this.Delegate;\n\tv113 = *([v55 @ X22_v4 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv220 = *([v113 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv115 = *([v113 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v115) goto L_004D;\n\tv152 = *([v113 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv152 = v152 + 0x10;\n\tv182 = v220 - 1;\n\tv172 = v220 != 1;\n\tv220 = v182;\n\tif (v172) goto L_0033;\nL_004D:\n\tv92 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v55, this);\nL_0050:\n\tv98 = v92 + dataIndex;\nL_005E:\n\tv120 = *([v152 @ X10_v7]) << 4;\n\tv224 = v113 + v120;\n\tv225 = v224 + 0x138;\n\t*([v225 @ X0_v11])(v92, v55, this, *([v225 @ X0_v11+8]), methodInfo, v29, v30, v31, v32, returnVal2, v34, v35, v36, v37, v38, v39, v40);\n\tv227 = this == 0;\n\tv164 = ~v227;\n\tif (v164) goto L_0050;\n\tthrow System.NullReferenceException;\nL_0020:\n\tv54 = this.Loop != 1;\n\tv98 = dataIndex;\n\tif (v54) goto L_005B;\nL_0033:\n\tv140 = *([v152 @ X10_v7-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v140) goto L_005E;\nL_005B:\n\treturnVal1 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this, v98, insertPosition);\n\treturn returnVal1;\n")]
		public float GetScrollPositionForDataIndex(int dataIndex, CellViewPositionEnum insertPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::GetScrollPositionForDataIndex");
			return default;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x401E258", Offset = "0x401E258", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._cellViewOffsetArray;\n\tv4 = v0.Count - 1;\n\treturnVal1 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetCellIndexAtPosition(this, position, 0, v4);\n\treturn returnVal1;\n")]
		public int GetCellViewIndexAtPosition(float position)
		{
			SmallList<float> cellViewOffsetArray = _cellViewOffsetArray;
			int endIndex = cellViewOffsetArray.Count - 1;
			return _GetCellIndexAtPosition(position, 0, endIndex);
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x401E820", Offset = "0x401E820", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv101 = 0;\n\tv90 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v114, v101);\n\tv68 = v90.dataIndex == dataIndex;\n\tif (v68) goto L_0052;\n\tv101 = v101 + 1;\n\tv114 = this._activeCellViews;\n\tv171 = this._activeCellViews == 0;\n\tv93 = ~v171;\n\tif (v93) goto L_0025;\n\tthrow System.NullReferenceException;\nL_0045:\n\treturn 0;\nL_0052:\n\treturnVal2 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(this._activeCellViews, v101);\n\treturn returnVal2;\nL_0015:\n\tv114 = this._activeCellViews;\nL_0025:\n\tv49 = v101 >= v114.Count;\n\tif (v49) goto L_0045;\n")]
		public EnhancedScrollerCellView GetCellViewAtDataIndex(int dataIndex)
		{
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			int num = 0;
			while (true)
			{
				if (num < activeCellViews.Count)
				{
					EnhancedScrollerCellView enhancedScrollerCellView = activeCellViews[num];
					if (enhancedScrollerCellView.dataIndex == dataIndex)
					{
						break;
					}
					num++;
					activeCellViews = _activeCellViews;
					if (_activeCellViews == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				return null;
			}
			return _activeCellViews[num];
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x401E8D8", Offset = "0x401E8D8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.tweenPaused != 1;\n\tif (v11) goto L_0013;\n\tthis._tweenPauseNewTweenTime = newTweenTime;\n\tthis.tweenPaused = 0;\n\tthis._tweenPauseToggledOff = this.tweenPaused;\n\treturn;\nL_0013:\n\tthis.tweenPaused = 1;\n\tthis._tweenPauseToggledOff = 0;\n\treturn;\n")]
		public void ToggleTweenPaused(float newTweenTime = -1f)
		{
			if (tweenPaused)
			{
				_tweenPauseNewTweenTime = newTweenTime;
				tweenPaused = false;
				_tweenPauseToggledOff = tweenPaused;
			}
			else
			{
				tweenPaused = true;
				_tweenPauseToggledOff = false;
			}
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x401E90C", Offset = "0x401E90C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.IsTweening != 1;\n\tif (v11) goto L_000D;\n\tthis._interruptTween = this.IsTweening;\nL_000D:\n\treturn;\n")]
		public void InterruptTween()
		{
			if (IsTweening)
			{
				_interruptTween = IsTweening;
			}
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x401C490", Offset = "0x401C490", Length = "0x47C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv635 = this._scrollPosition;\n\tEnhancedUI.SmallList`1<System.Single>::Clear(this._cellViewSizeArray);\n\tv174 = EnhancedUI.EnhancedScroller.EnhancedScroller::_AddCellViewSizes(this);\n\tv124 = this.Loop != 1;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v124) goto L_00CC;\n\tv238 = this._cellViewSizeArray;\n\tv346 = this.scrollDirection == 0;\n\tif (v346) goto L_0052;\n\tv349 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv356 = v174 < v349.width;\n\tif (v356) goto L_0064;\nL_FFFFFFFF:\n\tv405 = v238.Count;\n\tgoto L_00C1;\nL_0052:\n\tv351 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv369 = v174 < v351.height;\n\tv378 = ~v369;\nL_FFFFFFFF:\n\tv405 = v238.Count;\n\tif (v378) goto L_00C1;\nL_0064:\n\tv381 = this.scrollDirection == 0;\n\tif (v381) goto L_01C0;\n\tv410 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\nL_FFFFFFFF:\n\tv388 = v410.width;\n\tgoto L_007D;\nL_FFFFFFFF:\n\tv392 = 0xFFFFFFFFCE800000;\n\tgoto L_009B;\nL_00A8:\n\tv399 = UnityEngine.Mathf::Ceil(v392);\n\tv639 = v392 << 1;\n\tv395 = v399 == 0x7F800000;\n\tv384 = ~v395;\n\tif (v384) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv387 = 0;\n\tgoto L_00BD;\nL_FFFFFFFF:\n\tv387 = v639;\nL_00CC:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_CalculateCellViewOffsets(this);\n\tv347 = this.scrollDirection == 0;\n\tif (v347) goto L_0108;\n\tv177 = EnhancedUI.SmallList`1<System.Single>::Last(this._cellViewOffsetArray);\n\tv408 = UnityEngine.RectOffset::get_left(this.padding);\n\tv413 = UnityEngine.RectOffset::get_right(this.padding);\n\tv178 = UnityEngine.RectTransform::get_sizeDelta(this.Container);\n\tv493 = v177 + v408;\n\tv495 = v493 + v413;\n\t// 241 MakeStruct v498 @ AGG401C6E4_1_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v495 @ V0_v37 (System.Single), v178.y (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(this.Container, v498);\n\tv517 = this.Loop == 1;\nL_FFFFFFFF:\n\t;\n\tif (v517) goto L_0134;\nL_00FF:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_ResetVisibleCellViews(this);\n\tv564 = keepPosition == 0;\n\tif (v564) goto L_01A6;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_01AB;\nL_0108:\n\tv179 = UnityEngine.RectTransform::get_sizeDelta(this.Container);\n\tv180 = EnhancedUI.SmallList`1<System.Single>::Last(this._cellViewOffsetArray);\n\tv414 = UnityEngine.RectOffset::get_top(this.padding);\n\tv464 = UnityEngine.RectOffset::get_bottom(this.padding);\n\tv471 = v180 + v414;\n\tv473 = v471 + v464;\n\t// 291 MakeStruct v477 @ AGG401C76C_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v179 @ V0_v27 (UnityEngine.Vector2), v473 @ V1_v20 (System.Single)\n\tUnityEngine.RectTransform::set_sizeDelta(this.Container, v477);\n\tv509 = this.Loop != 1;\nL_FFFFFFFF:\n\t;\n\tif (v509) goto L_00FF;\nL_0134:\n\tv533 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this, this._loopFirstCellIndex, 0);\n\tv110 = this.spacing * 0.5f;\n\tv561 = v533 + v110;\n\tthis._loopFirstScrollPosition = v561;\n\tv181 = EnhancedUI.EnhancedScroller.EnhancedScroller::GetScrollPositionForCellViewIndex(this, this._loopLastCellIndex, 1);\n\tv575 = this.scrollDirection == 0;\n\tif (v575) goto L_014E;\n\tv643 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv655 = v643.width;\n\tgoto L_0154;\nL_014E:\n\tv645 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\nL_FFFFFFFF:\n\tv655 = v645.height;\n\tv664 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv670 = this._loopFirstScrollPosition - v664.width;\n\tthis._loopFirstJumpTrigger = v670;\n\tv121 = this._loopLastScrollPosition;\n\tv214 = this._scrollRectTransform;\n\tv674 = this.scrollDirection == 0;\nL_FFFFFFFF:\n\tv122 = this._loopLastScrollPosition;\nL_FFFFFFFF:\n\tv215 = this._scrollRectTransform;\n\tif (v674) goto L_018E;\nL_016F:\n\tv687 = UnityEngine.RectTransform::get_rect(v214);\n\tv603 = v121 + v687.width;\n\tthis._loopLastJumpTrigger = v603;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_ResetVisibleCellViews(this);\n\tv612 = keepPosition == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v612) goto L_01A6;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tgoto L_01AB;\nL_017E:\n\tv666 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv679 = this._loopFirstScrollPosition - v666.height;\n\tthis._loopFirstJumpTrigger = v679;\n\tv121 = this._loopLastScrollPosition;\n\tv214 = this._scrollRectTransform;\n\tv683 = this.scrollDirection == 0;\n\tv684 = ~v683;\nL_FFFFFFFF:\n\tv122 = this._loopLastScrollPosition;\nL_FFFFFFFF:\n\tv215 = this._scrollRectTransform;\n\tif (v684) goto L_016F;\nL_018E:\n\tv688 = UnityEngine.RectTransform::get_rect(v215);\n\tv602 = v122 + v688.height;\n\tthis._loopLastJumpTrigger = v602;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_ResetVisibleCellViews(this);\n\tv692 = keepPosition == 0;\n\tv611 = ~v692;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v611) goto L_01AB;\nL_01A6:\n\tv625 = this.Loop != 1;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv635 = 0;\n\tif (v625) goto L_01AB;\n\tv635 = this._loopFirstScrollPosition;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_01C0:\n\tv412 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv388 = v412.height;\n\tgoto L_007D;\nL_00C1:\n\tthis._loopFirstCellIndex = v405;\n\tv407 = v238.Count + v405;\n\tv343 = v407 - 1;\n\tthis._loopLastCellIndex = v343;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_DuplicateCellViewSizes(this, 2, v238.Count);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_007D:\n\tv392 = v388 / v174;\n\tgoto L_0083;\nL_009B:\n\tgoto L_00A5;\nL_00BD:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_DuplicateCellViewSizes(this, v387, v238.Count);\n\tv662 = v387 >> 1;\n\tv404 = v238.Count * v662;\n\tv405 = v238.Count + v404;\nL_01AB:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, v635);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollbarVisibility(this, this.ScrollbarVisibility);\n\treturn;\nL_0154:\n\tv111 = v181 - v655;\n\tv660 = this.spacing * 0.5f;\n\tv182 = v111 + v660;\n\tthis._loopLastScrollPosition = v182;\n\tv661 = this.scrollDirection == 0;\n\tif (v661) goto L_017E;\nL_0083:\n\tv469 = UnityEngine.Mathf::Ceil(v392);\n\tv482 = v469 == 0x7F800000;\n\tv491 = ~v482;\n\tif (v491) goto L_009B;\nL_00A5:\n\tgoto L_00A8;\n")]
		private void _Resize(bool keepPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_Resize");
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x401EFE8", Offset = "0x401EFE8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._updateSpacing = 0;\n\tUnityEngine.UI.HorizontalOrVerticalLayoutGroup::set_spacing(this._layoutGroup, spacing);\n\tv38 = this._scrollPosition == 0;\n\tv39 = this._scrollPosition < 0;\n\tv40 = ~v39;\n\tv43 = ~v40;\n\tv44 = v43 | v38;\n\tv47 = 0;\n\tif (v44) goto L_0025;\n\tv46 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv47 = this._scrollPosition / v46;\nL_0025:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this, v47);\n\treturn;\n")]
		private void _UpdateSpacing(float spacing)
		{
			_updateSpacing = false;
			_layoutGroup.spacing = spacing;
			bool flag = _scrollPosition == 0f;
			bool flag2 = _scrollPosition < 0f;
			bool flag3 = !flag2;
			bool flag4 = !flag3;
			bool flag5 = flag4 || flag;
			float scrollPositionFactor = 0f;
			if (!flag5)
			{
				float scrollSize = ScrollSize;
				scrollPositionFactor = _scrollPosition / scrollSize;
			}
			ReloadData(scrollPositionFactor);
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x401E920", Offset = "0x401E920", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tgoto L_0071;\nL_0066:\n\tv188 = v168 < 0;\n\tif (v188) goto L_007D;\n\tgoto L_00F0;\nL_007D:\n\tv92 = this.Delegate;\n\tv309 = *([v92 @ X23_v3 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv482 = *([v309 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv311 = *([v309 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v311) goto L_00A8;\n\tv481 = *([v309 @ X8_v8 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv481 = v481 + 0x10;\n\tv467 = v482 - 1;\n\tv447 = v482 != 1;\nL_FFFFFFFF:\n\tv482 = v467;\n\tif (v447) goto L_008D;\nL_00A8:\n\tv497 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetCellViewSize(v92, this, v168);\n\tv498 = v168 == 0;\n\tif (v498) goto L_FFFFFFFF;\nL_00AB:\n\tv383 = this._layoutGroup;\n\tv147 = v383.spacing;\n\tv516 = this._cellViewSizeArray == 0;\n\tv378 = ~v516;\n\tif (v378) goto L_00C4;\n\tgoto L_00F1;\nL_00B4:\n\tv501 = *([v481 @ X10_v11]) + 1;\n\tv502 = v501 << 4;\n\tv503 = v309 + v502;\n\tv504 = v503 + 0x138;\n\t*([v504 @ X0_v17])(v510, v92, this, v168, *([v504 @ X0_v17+8]), v43, v44, v45, v46, v146, v147, v49, v50, v51, v52, v53, v54);\n\tv511 = v168 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_00AB;\nL_FFFFFFFF:\n\tv147 = 0;\nL_00C4:\n\tv317 = v146 + v147;\n\tEnhancedUI.SmallList`1<System.Single>::Add(this._cellViewSizeArray, v317);\n\tv375 = this._cellViewSizeArray;\n\tv371 = v375.Count - 1;\n\tv521 = EnhancedUI.SmallList`1<System.Single>::get_Item(v375, v371);\n\tv318 = this._singleLoopGroupSize + v521;\n\tthis._singleLoopGroupSize = v318;\n\tv134 = this._cellViewSizeArray;\n\tv132 = v134.Count - 1;\n\tv146 = EnhancedUI.SmallList`1<System.Single>::get_Item(v134, v132);\n\tv144 = v144 + v146;\n\tv168 = v168 + 1;\n\tgoto L_00DF;\nL_00DF:\n\tgoto L_0036;\nL_00F0:\n\treturn v144;\nL_00F1:\n\tthrow System.NullReferenceException;\nL_002C:\n\tthis._singleLoopGroupSize = 0f;\nL_FFFFFFFF:\n\tv144 = 0;\nL_FFFFFFFF:\n\tv168 = 0;\n\tgoto L_0036;\nL_0071:\n\tv249 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(this.Delegate, this);\n\tv225 = v168 >= v249;\n\tif (v225) goto L_00F0;\nL_008D:\n\tv487 = *([v481 @ X10_v11-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v487) goto L_00B4;\nL_0036:\n\tv170 = this.Delegate == 0;\n\tif (v170) goto L_0066;\n")]
		private float _AddCellViewSizes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_AddCellViewSizes");
			return default;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x401EB64", Offset = "0x401EB64", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv80 = cellCount < 1;\n\tif (v80) goto L_0088;\n\tv156 = 0;\n\tgoto L_004F;\nL_003E:\n\tv156 = v156 + 1;\n\tv110 = v156 == numberOfTimes;\n\tif (v110) goto L_0088;\nL_004F:\n\tv210 = EnhancedUI.SmallList`1<System.Single>::get_Item(this._cellViewSizeArray, 0);\n\tv122 = this._layoutGroup;\n\tv229 = v210 + v122.spacing;\n\tEnhancedUI.SmallList`1<System.Single>::Add(this._cellViewSizeArray, v229);\n\tv236 = cellCount == 1;\n\tif (v236) goto L_003E;\n\tv228 = 1;\nL_0069:\n\tv269 = EnhancedUI.SmallList`1<System.Single>::get_Item(this._cellViewSizeArray, v228);\n\tEnhancedUI.SmallList`1<System.Single>::Add(this._cellViewSizeArray, v269);\n\tv228 = v228 + 1;\n\tv245 = cellCount != v228;\n\tif (v245) goto L_0069;\n\tgoto L_003E;\nL_0088:\n\treturn;\nL_0029:\n\tv67 = numberOfTimes < 1;\n\tif (v67) goto L_0088;\n")]
		private void _DuplicateCellViewSizes(int numberOfTimes, int cellCount)
		{
			if (numberOfTimes < 1 || cellCount < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				float num2 = _cellViewSizeArray[0];
				HorizontalOrVerticalLayoutGroup layoutGroup = _layoutGroup;
				float item = num2 + layoutGroup.spacing;
				_cellViewSizeArray.Add(item);
				if (cellCount != 1)
				{
					int num3 = 1;
					do
					{
						float item2 = _cellViewSizeArray[num3];
						_cellViewSizeArray.Add(item2);
						num3++;
					}
					while (cellCount != num3);
				}
				num++;
			}
			while (num != numberOfTimes);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x401EC88", Offset = "0x401EC88", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\nL_0022:\n\tEnhancedUI.SmallList`1<System.Single>::Clear(this._cellViewOffsetArray);\n\tv132 = this._cellViewSizeArray;\n\tv89 = 0;\n\tv109 = 0;\n\tv84 = EnhancedUI.SmallList`1<System.Single>::get_Item(v132, v109);\n\tv89 = v89 + v84;\n\tEnhancedUI.SmallList`1<System.Single>::Add(this._cellViewOffsetArray, v89);\n\tv109 = v109 + 1;\n\tv132 = this._cellViewSizeArray;\n\tv160 = this._cellViewSizeArray == 0;\n\tv102 = ~v160;\n\tif (v102) goto L_0036;\n\tthrow System.NullReferenceException;\nL_0051:\n\treturn;\nL_0036:\n\tv56 = v109 >= v132.Count;\n\tif (v56) goto L_0051;\n")]
		private void _CalculateCellViewOffsets()
		{
			_cellViewOffsetArray.Clear();
			SmallList<float> cellViewSizeArray = _cellViewSizeArray;
			float num = 0f;
			int num2 = 0;
			while (num2 < cellViewSizeArray.Count)
			{
				float num3 = cellViewSizeArray[num2];
				num += num3;
				_cellViewOffsetArray.Add(num);
				num2++;
				cellViewSizeArray = _cellViewSizeArray;
				if (_cellViewSizeArray == null)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x401D148", Offset = "0x401D148", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv50 = cellPrefab == 0;\n\tv112 = this._recycledCellViews;\n\tif (v50) goto L_0049;\n\tv97 = 0;\n\tv87 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v138, v97);\n\tv200 = System.String::op_Equality(v87.cellIdentifier, cellPrefab.cellIdentifier);\n\tv202 = v200 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0062;\n\tv97 = v97 + 1;\n\tv138 = this._recycledCellViews;\n\tv204 = this._recycledCellViews == 0;\n\tv90 = ~v204;\n\tif (v90) goto L_002A;\n\tv112 = new System.NullReferenceException();\nL_0049:\n\tv126 = v112._message >= 1;\n\tif (v126) goto L_0066;\nL_0053:\n\treturn 0;\nL_0062:\n\treturnVal3 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::RemoveAt(this._recycledCellViews, v97);\n\treturn returnVal3;\nL_0066:\n\tv167 = EnhancedUI.SmallList`1<System.Object>::get_Item(v112, 0);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_0018:\n\tv138 = this._recycledCellViews;\nL_002A:\n\tv52 = v97 >= v138.Count;\n\tif (v52) goto L_0053;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private EnhancedScrollerCellView _GetRecycledCellView(EnhancedScrollerCellView cellPrefab)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_GetRecycledCellView");
			return default;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x401ED64", Offset = "0x401ED64", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv168 = this._activeCellViews;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv181 = 0;\n\tv160 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v168, v181);\n\tv89 = v160.cellIndex < v57;\n\tif (v89) goto L_0078;\n\tv162 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(this._activeCellViews, v181);\n\tv91 = v162.cellIndex <= v59;\n\tif (v91) goto L_0086;\nL_0078:\n\tv332 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(this._activeCellViews, v181);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RecycleCell(this, v332);\n\tv168 = this._activeCellViews;\n\tv388 = this._activeCellViews == 0;\n\tv174 = ~v388;\nL_FFFFFFFF:\n\t;\n\tif (v174) goto L_0049;\n\tgoto L_012D;\nL_0086:\n\tv166 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(this._activeCellViews, v181);\n\tEnhancedUI.SmallList`1<System.Int32>::Add(v65, v166.cellIndex);\n\tv181 = v181 + 1;\n\tv168 = this._activeCellViews;\n\tv432 = this._activeCellViews == 0;\n\tv178 = ~v432;\n\tif (v178) goto L_0049;\n\tgoto L_012D;\nL_0098:\n\tv242 = v65.Count == 0;\n\tif (v242) goto L_00D5;\n\tv267 = v59 < v57;\n\tif (v267) goto L_00F6;\nL_FFFFFFFF:\n\tv354 = v59;\n\tgoto L_00B9;\nL_00AA:\n\tv354 = v354 - 1;\n\tv334 = v354 < v57;\n\tif (v334) goto L_00F4;\nL_00B9:\n\tv357 = EnhancedUI.SmallList`1<System.Int32>::First(v65);\n\tv381 = v354 >= v357;\nL_FFFFFFFF:\n\t;\n\tif (v381) goto L_00AA;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_AddCellView(this, v354, 0);\nL_FFFFFFFF:\n\t;\n\tgoto L_00AA;\nL_00D5:\n\tv279 = v57 > v59;\n\tif (v279) goto L_00F6;\nL_FFFFFFFF:\n\tv370 = v57;\nL_FFFFFFFF:\n\t;\n\tgoto L_00F6;\nL_00F4:\n\tv286 = v59 >= v57;\n\tif (v286) goto L_FFFFFFFF;\nL_00F6:\n\tthis.StartCellViewIndex = v57;\n\tthis.EndCellViewIndex = v59;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_SetPadders(this);\n\treturn;\nL_FFFFFFFF:\n\tv410 = v57;\n\tgoto L_011A;\nL_010A:\n\tv410 = v410 + 1;\n\tv288 = v410 > v59;\n\tif (v288) goto L_00F6;\nL_011A:\n\tv413 = EnhancedUI.SmallList`1<System.Int32>::Last(v65);\n\tv425 = v410 <= v413;\nL_FFFFFFFF:\n\t;\n\tif (v425) goto L_010A;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_AddCellView(this, v410, 1);\nL_FFFFFFFF:\n\t;\n\tgoto L_010A;\nL_012D:\n\tthrow System.NullReferenceException;\nL_002F:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_CalculateCurrentActiveCellRange(this, &v57 @ stack_-54_v1 (System.Int32), &v59 @ stack_-58_v2 (System.Int32));\n\tv65 = new EnhancedUI.SmallList`1<System.Int32>();\n\tEnhancedUI.SmallList`1<System.Int32>::.ctor(v65);\nL_0049:\n\tv88 = v181 >= v168.Count;\n\tif (v88) goto L_0098;\nL_00DB:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_AddCellView(this, v370, 1);\n\tv370 = v370 + 1;\n\tv287 = v370 <= v59;\n\tif (v287) goto L_00DB;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _ResetVisibleCellViews()
		{
			_CalculateCurrentActiveCellRange(out var startIndex, out var endIndex);
			SmallList<int> smallList = new SmallList<int>();
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			int num = 0;
			do
			{
				IL_0321:
				if (num < activeCellViews.Count)
				{
					EnhancedScrollerCellView enhancedScrollerCellView = activeCellViews[num];
					if (enhancedScrollerCellView.cellIndex >= startIndex)
					{
						EnhancedScrollerCellView enhancedScrollerCellView2 = _activeCellViews[num];
						if (enhancedScrollerCellView2.cellIndex <= endIndex)
						{
							EnhancedScrollerCellView enhancedScrollerCellView3 = _activeCellViews[num];
							smallList.Add(enhancedScrollerCellView3.cellIndex);
							num++;
							activeCellViews = _activeCellViews;
							if (_activeCellViews == null)
							{
								break;
							}
							goto IL_0321;
						}
					}
					EnhancedScrollerCellView cellView = _activeCellViews[num];
					_RecycleCell(cellView);
					activeCellViews = _activeCellViews;
					continue;
				}
				if (smallList.Count != 0)
				{
					if (endIndex >= startIndex)
					{
						int num2 = endIndex;
						do
						{
							int num3 = smallList.First();
							if (num2 < num3)
							{
								_AddCellView(num2, default(ListPositionEnum));
							}
							num2--;
						}
						while (num2 >= startIndex);
						if (endIndex >= startIndex)
						{
							int num4 = startIndex;
							do
							{
								int num5 = smallList.Last();
								if (num4 > num5)
								{
									_AddCellView(num4, ListPositionEnum.Last);
								}
								num4++;
							}
							while (num4 <= endIndex);
						}
					}
				}
				else if (startIndex <= endIndex)
				{
					int num6 = startIndex;
					do
					{
						_AddCellView(num6, ListPositionEnum.Last);
						num6++;
					}
					while (num6 <= endIndex);
				}
				_activeCellViewsStartIndex = startIndex;
				_activeCellViewsEndIndex = endIndex;
				_SetPadders();
				return;
			}
			while (_activeCellViews != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x401D484", Offset = "0x401D484", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv118 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v92, 0);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RecycleCell(this, v118);\n\tv92 = this._activeCellViews;\n\tv120 = this._activeCellViews == 0;\n\tv76 = ~v120;\n\tif (v76) goto L_0023;\n\tthrow System.NullReferenceException;\nL_0030:\n\tthis.StartCellViewIndex = 0;\n\treturn;\nL_0012:\n\tv92 = this._activeCellViews;\nL_0023:\n\tv43 = v92.Count <= 0;\n\tif (v43) goto L_0030;\n")]
		private void _RecycleAllCells()
		{
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			while (activeCellViews.Count > 0)
			{
				EnhancedScrollerCellView cellView = activeCellViews[0];
				_RecycleCell(cellView);
				activeCellViews = _activeCellViews;
				if (_activeCellViews == null)
				{
					throw new NullReferenceException();
				}
			}
			_activeCellViewsStartIndex = 0;
			_activeCellViewsEndIndex = 0;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x401F124", Offset = "0x401F124", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tEnhancedUI.EnhancedScroller.CellViewWillRecycleDelegate::Invoke(this.cellViewWillRecycle, cellView);\nL_0027:\n\tv64 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::Remove(this._activeCellViews, cellView);\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::Add(this._recycledCellViews, cellView);\n\tv73 = UnityEngine.Component::get_transform(cellView);\n\tv74 = UnityEngine.Component::get_gameObject(v73);\n\tUnityEngine.GameObject::SetActive(v74, 0);\n\tcellView.active = 0;\n\tcellView.cellIndex = 0;\n\tv101 = this.cellViewVisibilityChanged == 0;\n\tif (v101) goto L_0056;\n\tEnhancedUI.EnhancedScroller.CellViewVisibilityChangedDelegate::Invoke(this.cellViewVisibilityChanged, cellView);\n\treturn;\nL_0056:\n\treturn;\nL_0018:\n\t;\n\tv45 = this.cellViewWillRecycle == 0;\n\tif (v45) goto L_0027;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void _RecycleCell(EnhancedScrollerCellView cellView)
		{
			if (cellViewWillRecycle != null)
			{
				cellViewWillRecycle(cellView);
			}
			EnhancedScrollerCellView enhancedScrollerCellView = _activeCellViews.Remove(cellView);
			_recycledCellViews.Add(cellView);
			Transform transform = cellView.transform;
			GameObject gameObject = transform.gameObject;
			gameObject.SetActive(value: false);
			cellView.active = false;
			cellView.cellIndex = 0;
			cellView.dataIndex = 0;
			if (cellViewVisibilityChanged != null)
			{
				cellViewVisibilityChanged(cellView);
			}
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x401F22C", Offset = "0x401F22C", Length = "0x4EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0xB78F000;\n\tv26 = *([B78F518]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_0032;\n\tv30 = *([B78F510]) & 1;\n\tv31 = v30 == 0;\n\tif (v31) goto L_003D;\nL_0017:\n\tv75 = this.Delegate;\n\tv57 = this.Delegate == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0044;\n\tgoto L_01DD;\nL_0032:\n\t*([v24 @ X22_v1+518]) = 1;\n\tv513 = *([B78F510]) & 1;\n\tv514 = v513 == 0;\n\tv53 = ~v514;\n\tif (v53) goto L_0017;\nL_003D:\n\t*([B78F510]) = 1;\n\tv75 = this.Delegate;\n\tv72 = this.Delegate == 0;\n\tif (v72) goto L_01DD;\nL_0044:\n\tv80 = *([v75 @ X22_v4 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv299 = *([v80 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv82 = *([v80 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v82) goto L_0069;\n\tv160 = *([v80 @ X8_v4 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv160 = v160 + 0x10;\n\tv211 = v299 - 1;\n\tv201 = v299 != 1;\nL_FFFFFFFF:\n\tv299 = v211;\n\tif (v201) goto L_004F;\nL_0069:\n\tv174 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v75, this);\n\tv302 = v174 == 0;\n\tv180 = ~v302;\n\tif (v180) goto L_007D;\n\tgoto L_01DD;\nL_006F:\n\tv106 = *([v160 @ X10_v20]) << 4;\n\tv307 = v80 + v106;\n\tv308 = v307 + 0x138;\n\t*([v308 @ X0_v66])(v175, v75, this, *([v308 @ X0_v66+8]), methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv181 = v175 == 0;\n\tif (v181) goto L_01DD;\nL_007D:\n\tgoto L_0083;\n\tv346 = *([v341 @ X22_v5 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv540 = *([v346 @ X8_v9 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv348 = *([v346 @ X8_v9 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v348) goto L_00AC;\n\tv437 = *([v346 @ X8_v9 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv437 = v437 + 0x10;\n\tv527 = v540 - 1;\n\tv517 = v540 != 1;\nL_FFFFFFFF:\n\tv540 = v527;\n\tif (v517) goto L_0092;\nL_00AC:\n\tv563 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v341, this);\n\tv510 = this.Delegate;\n\tv543 = this.Delegate == 0;\n\tv474 = ~v543;\n\tif (v474) goto L_00BE;\n\tgoto L_01DE;\nL_00B3:\n\tv360 = *([v437 @ X10_v15]) << 4;\n\tv545 = v346 + v360;\n\tv546 = v545 + 0x138;\n\t*([v546 @ X0_v56])(v563, v341, this, *([v546 @ X0_v56+8]), methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv510 = this.Delegate;\nL_00BE:\n\tv566 = cellIndex / v563;\n\tv567 = v566 * v563;\n\tv469 = cellIndex - v567;\n\tgoto L_00EF;\n\tv467.cellIndex = cellIndex;\n\tv467.dataIndex = v469;\n\tv467.active = 1;\n\tv459 = UnityEngine.Component::get_transform(v467);\n\tUnityEngine.Transform::SetParent(v459, this.Container, 0);\n\tv468 = UnityEngine.Component::get_transform(v467);\n\tgoto L_011A;\nL_011A:\n\t// 282 MakeStruct v95 @ AGG401F508_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v649.one (UnityEngine.Vector3), v649.one.y (System.Single), v649.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(v468, v95);\n\tv655 = UnityEngine.Component::GetComponent(v467);\n\tgoto L_012B;\nL_012B:\n\tv663 = UnityEngine.Object::op_Equality(v655, 0);\n\tv665 = ~v663;\n\tv666 = ~v665;\n\tif (v666) goto L_0157;\n\tv460 = this._cellViewSizeArray;\n\tv678 = this.scrollDirection == 0;\nL_FFFFFFFF:\n\tv178 = v655;\nL_FFFFFFFF:\n\tv462 = this._cellViewSizeArray;\nL_FFFFFFFF:\n\tv472 = v655;\n\tif (v678) goto L_016A;\nL_0139:\n\tv352 = EnhancedUI.SmallList`1<System.Single>::get_Item(v460, cellIndex);\n\tv376 = cellIndex < 1;\n\tif (v376) goto L_FFFFFFFF;\n\tv497 = this._layoutGroup;\n\tv101 = v497.spacing;\n\tv700 = v178 == 0;\n\tv479 = ~v700;\n\tif (v479) goto L_0182;\n\tgoto L_01DE;\nL_0157:\n\tv461 = UnityEngine.Component::get_gameObject(v467);\n\tv694 = UnityEngine.GameObject::AddComponent(v461);\n\tv460 = this._cellViewSizeArray;\n\tv699 = this.scrollDirection == 0;\n\tv687 = ~v699;\nL_FFFFFFFF:\n\tv178 = v694;\nL_FFFFFFFF:\n\tv462 = this._cellViewSizeArray;\nL_FFFFFFFF:\n\tv472 = v694;\n\tif (v687) goto L_0139;\nL_016A:\n\tv353 = EnhancedUI.SmallList`1<System.Single>::get_Item(v462, cellIndex);\n\tv377 = cellIndex < 1;\n\tif (v377) goto L_FFFFFFFF;\n\tv500 = this._layoutGroup;\n\tv101 = v500.spacing;\n\tv707 = v472 == 0;\n\tv483 = ~v707;\n\tif (v483) goto L_0189;\n\tgoto L_01DE;\nL_FFFFFFFF:\n\tv101 = 0;\nL_0182:\n\tv97 = v352 - v101;\nL_FFFFFFFF:\n\tv369 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv714 = 0x338;\nL_FFFFFFFF:\n\tv503 = 0x340;\n\tgoto L_018C;\nL_FFFFFFFF:\n\tv101 = 0;\nL_0189:\n\tv97 = v353 - v101;\nL_FFFFFFFF:\n\tv369 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv714 = 0x358;\nL_FFFFFFFF:\n\tv178 = v472;\nL_FFFFFFFF:\n\tv503 = 0x360;\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::Add(this._activeCellViews, v467);\n\tv379 = listPosition != 1;\n\tif (v379) goto L_01C3;\n\tv740 = UnityEngine.Component::get_transform(v467);\n\tv465 = UnityEngine.Transform::get_childCount(this.Container);\n\tv739 = v465 - 2;\n\tgoto L_01C2;\nL_01BA:\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::AddStart(this._activeCellViews, v467);\n\tv740 = UnityEngine.Component::get_transform(v467);\nL_FFFFFFFF:\n\tv739 = 1;\nL_01C3:\n\t;\n\tv182 = this.cellViewVisibilityChanged == 0;\n\tif (v182) goto L_01DD;\n\tEnhancedUI.EnhancedScroller.CellViewVisibilityChangedDelegate::Invoke(this.cellViewVisibilityChanged, v467);\n\treturn;\nL_01DD:\n\treturn;\nL_01DE:\n\tthrow System.NullReferenceException;\nL_004F:\n\tv140 = *([v160 @ X10_v20-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v140) goto L_006F;\nL_0083:\n\tv341 = this.Delegate;\nL_0092:\n\tv409 = *([v437 @ X10_v15-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v409) goto L_00B3;\nL_00EF:\n\tv467 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetCellView(v510, this, v469, cellIndex);\nL_018C:\n\tv161 = *([v178 @ X23_v8 (UnityEngine.UI.LayoutElement)]);\n\t*([v161 @ X10_v6 (Il2CppClass<UnityEngine.UI.LayoutElement>)+v714 @ X9_v9 (System.Int32)])(v719, v178, *([v161 @ X10_v6 (Il2CppClass<UnityEngine.UI.LayoutElement>)+v503 @ X8_v27 (System.Int32)]), v369, 0, 0, v37, v38, v39, v97, v101, v649.one.z, v43, v44, v45, v46, v47);\n\tv720 = listPosition == 0;\n\tif (v720) goto L_01BA;\nL_01C2:\n\tUnityEngine.Transform::SetSiblingIndex(v740, v739);\n")]
		private void _AddCellView(int cellIndex, ListPositionEnum listPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_AddCellView");
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x401F718", Offset = "0x401F718", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = 0xB78F000;\n\tv22 = *([B78F519]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0021;\n\tv26 = *([B78F510]) & 1;\n\tv27 = v26 == 0;\n\tif (v27) goto L_002C;\nL_0015:\n\tv71 = this.Delegate;\n\tv55 = this.Delegate == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0033;\n\tgoto L_00D0;\nL_0021:\n\t*([v20 @ X20_v1+519]) = 1;\n\tv80 = *([B78F510]) & 1;\n\tv81 = v80 == 0;\n\tv49 = ~v81;\n\tif (v49) goto L_0015;\nL_002C:\n\t*([B78F510]) = 1;\n\tv71 = this.Delegate;\n\tv68 = this.Delegate == 0;\n\tif (v68) goto L_00D0;\nL_0033:\n\tv76 = *([v71 @ X20_v4 (EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate)]);\n\tv257 = *([v76 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]);\n\tv78 = *([v76 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+12E]) == 0;\n\tif (v78) goto L_0058;\n\tv129 = *([v76 @ X8_v6 (Il2CppClass<EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate>)+B0]) + 8;\n\tv129 = v129 + 0x10;\n\tv169 = v257 - 1;\n\tv159 = v257 != 1;\n\tv257 = v169;\n\tif (v159) goto L_003E;\nL_0058:\n\tv141 = EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate::GetNumberOfCells(v71, this);\n\tv144 = v141 == 0;\n\tif (v144) goto L_00D0;\nL_0062:\n\tv283 = EnhancedUI.SmallList`1<System.Single>::get_Item(this._cellViewOffsetArray, this.StartCellViewIndex);\n\tv291 = EnhancedUI.SmallList`1<System.Single>::get_Item(this._cellViewSizeArray, this.StartCellViewIndex);\n\tv292 = EnhancedUI.SmallList`1<System.Single>::Last(this._cellViewOffsetArray);\n\tv288 = v283 - v291;\n\tv293 = EnhancedUI.SmallList`1<System.Single>::get_Item(this._cellViewOffsetArray, this.EndCellViewIndex);\n\tv290 = v292 - v293;\n\tv392 = this.scrollDirection == 0;\n\tif (v392) goto L_00D7;\n\tv393 = UnityEngine.UI.LayoutElement::set_minWidth(this.FirstPadder, v288);\n\tv395 = UnityEngine.Component::get_gameObject(this.FirstPadder);\n\tv346 = UnityEngine.UI.LayoutElement::get_minWidth(this.FirstPadder);\n\tv308 = v288 < 0;\n\tv306 = v288 == 0;\n\tv310 = v288 == v288;\n\tv304 = ~v310;\n\tv398 = v308 == v304;\n\tv284 = ~v306;\n\tv302 = v398 & v284;\n\tUnityEngine.GameObject::SetActive(v395, v302);\n\tv403 = UnityEngine.UI.LayoutElement::set_minWidth(this.LastPadder, v290);\n\tv405 = UnityEngine.Component::get_gameObject(this.LastPadder);\n\tv350 = UnityEngine.UI.LayoutElement::get_minWidth(this.LastPadder);\n\tv407 = v405 == 0;\n\tv368 = ~v407;\n\tv195 = v290;\n\tv418 = v405;\n\tif (v368) goto L_010B;\n\tgoto L_0122;\nL_00BC:\n\tv87 = *([v129 @ X10_v6]) << 4;\n\tv261 = v76 + v87;\n\tv262 = v261 + 0x138;\n\t*([v262 @ X0_v41])(v140, v71, this, *([v262 @ X0_v41+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv264 = v140 == 0;\n\tv143 = ~v264;\n\tif (v143) goto L_0062;\nL_00D0:\n\treturn;\nL_00D7:\n\tv394 = UnityEngine.UI.LayoutElement::set_minHeight(this.FirstPadder, v288);\n\tv396 = UnityEngine.Component::get_gameObject(this.FirstPadder);\n\tv353 = UnityEngine.UI.LayoutElement::get_minHeight(this.FirstPadder);\n\tv309 = v288 < 0;\n\tv307 = v288 == 0;\n\tv311 = v288 == v288;\n\tv305 = ~v311;\n\tv401 = v309 == v305;\n\tv285 = ~v307;\n\tv303 = v401 & v285;\n\tUnityEngine.GameObject::SetActive(v396, v303);\n\tv404 = UnityEngine.UI.LayoutElement::set_minHeight(this.LastPadder, v290);\n\tv406 = UnityEngine.Component::get_gameObject(this.LastPadder);\n\tv357 = UnityEngine.UI.LayoutElement::get_minHeight(this.LastPadder);\n\tv195 = v290;\n\tv418 = v406;\nL_010B:\n\tv216 = v195 < 0;\n\tv213 = v195 == 0;\n\tv219 = v195 == v195;\n\tv204 = ~v219;\n\tv420 = v216 == v204;\n\tv183 = ~v213;\n\tv201 = v420 & v183;\n\tUnityEngine.GameObject::SetActive(v418, v201);\n\treturn;\nL_0122:\n\tthrow System.NullReferenceException;\nL_003E:\n\tv113 = *([v129 @ X10_v6-8]) == EnhancedUI.EnhancedScroller.IEnhancedScrollerDelegate;\n\tif (v113) goto L_00BC;\n")]
		private void _SetPadders()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_SetPadders");
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x401D504", Offset = "0x401D504", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv56 = this._ignoreLoopJump == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0061;\n\tv103 = this._scrollPosition < this._loopFirstJumpTrigger;\n\tv111 = ~v103;\n\tif (v111) goto L_0043;\n\tv124 = this.ScrollRect;\n\tv63 = v124.velocity;\n\tv163 = this._loopFirstJumpTrigger - this._scrollPosition;\n\tv164 = this._loopLastScrollPosition - v163;\n\tv165 = v164 + this.spacing;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, v165);\n\tv96 = this.ScrollRect;\n\tv200 = this.ScrollRect == 0;\n\tv186 = ~v200;\n\tif (v186) goto L_005D;\n\tgoto L_008E;\nL_0043:\n\tv84 = this._scrollPosition < this._loopLastJumpTrigger;\n\tv81 = this._scrollPosition == this._loopLastJumpTrigger;\n\tv127 = this._scrollPosition == this._scrollPosition;\n\tv72 = this._loopLastJumpTrigger == this._loopLastJumpTrigger;\n\tv75 = v127 & v72;\n\tv69 = ~v75;\n\tv128 = v84 == v69;\n\tv129 = ~v128;\n\tv66 = v129 | v81;\n\tif (v66) goto L_0061;\n\tv191 = this.ScrollRect;\n\tv63 = v191.velocity;\n\tv201 = this._scrollPosition - this._loopLastJumpTrigger;\n\tv202 = v201 + this._loopFirstScrollPosition;\n\tv182 = v202 - this.spacing;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollPosition(this, v182);\n\tv96 = this.ScrollRect;\nL_005D:\n\tv96.velocity = v63;\n\tv141 = v100 != this.EndCellViewIndex;\n\tif (v141) goto L_008C;\n\treturn;\nL_008C:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_ResetVisibleCellViews(this);\n\treturn;\nL_008E:\n\tthrow System.NullReferenceException;\nL_001F:\n\tv53 = this.Loop != 1;\n\tif (v53) goto L_0061;\nL_0061:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_CalculateCurrentActiveCellRange(this, &v98 @ stack_-34_v1 (System.Int32), &v100 @ stack_-38_v2 (System.Int32));\n\tv123 = v98 != this.StartCellViewIndex;\n\tif (v123) goto L_008C;\n")]
		internal void _RefreshActive()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_RefreshActive");
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x401F044", Offset = "0x401F044", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([startIndex @ X1 (System.Int32&)]) = 0;\n\t*([endIndex @ X2 (System.Int32&)]) = 0;\n\tv33 = this.scrollDirection == 0;\n\tif (v33) goto L_0028;\n\tv37 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv92 = this._cellViewOffsetArray;\n\tv88 = this._cellViewOffsetArray == 0;\n\tv67 = ~v88;\n\tv43 = v37.width;\n\tif (v67) goto L_0030;\n\tgoto L_0050;\nL_0028:\n\tv61 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv92 = this._cellViewOffsetArray;\n\tv43 = v61.height;\nL_0030:\n\tv93 = this._scrollPosition - this.lookAheadBefore;\n\tv62 = v93 + this.CalculateStartCellBias;\n\tv39 = v92.Count - 1;\n\tv71 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetCellIndexAtPosition(this, v62, 0, v39);\n\t*([startIndex @ X1 (System.Int32&)]) = v71;\n\tv75 = this._cellViewOffsetArray;\n\tv130 = this._scrollPosition + v43;\n\tv108 = v130 + this.lookAheadAfter;\n\tv101 = v75.Count - 1;\n\tv113 = EnhancedUI.EnhancedScroller.EnhancedScroller::_GetCellIndexAtPosition(this, v108, 0, v101);\n\t*([endIndex @ X2 (System.Int32&)]) = v113;\n\treturn;\nL_0050:\n\tthrow System.NullReferenceException;\n")]
		private void _CalculateCurrentActiveCellRange(out int startIndex, out int endIndex)
		{
			startIndex = default(int);
			endIndex = default(int);
			startIndex = 0;
			endIndex = 0;
			SmallList<float> cellViewOffsetArray;
			float num;
			if (scrollDirection != ScrollDirectionEnum.Vertical)
			{
				Rect rect = _scrollRectTransform.rect;
				cellViewOffsetArray = _cellViewOffsetArray;
				bool flag = _cellViewOffsetArray == null;
				bool flag2 = !flag;
				num = rect.width;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				Rect rect2 = _scrollRectTransform.rect;
				cellViewOffsetArray = _cellViewOffsetArray;
				num = rect2.height;
			}
			float num2 = _scrollPosition - lookAheadBefore;
			float position = num2 + CalculateStartCellBias;
			int endIndex2 = cellViewOffsetArray.Count - 1;
			int num3 = _GetCellIndexAtPosition(position, 0, endIndex2);
			startIndex = num3;
			SmallList<float> cellViewOffsetArray2 = _cellViewOffsetArray;
			float num4 = _scrollPosition + num;
			float position2 = num4 + lookAheadAfter;
			int endIndex3 = cellViewOffsetArray2.Count - 1;
			int num5 = _GetCellIndexAtPosition(position2, 0, endIndex3);
			endIndex = num5;
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x401E708", Offset = "0x401E708", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\nL_FFFFFFFF:\n\tv102 = startIndex;\nL_FFFFFFFF:\n\tv104 = endIndex;\n\tv158 = this.scrollDirection == 0;\n\tif (v158) goto L_0041;\n\tv199 = UnityEngine.RectOffset::get_left(this.padding);\n\tv101 = this._cellViewOffsetArray;\n\tv209 = this._cellViewOffsetArray == 0;\n\tv203 = ~v209;\nL_FFFFFFFF:\n\tv91 = v199;\n\tif (v203) goto L_0046;\n\tgoto L_007D;\nL_0041:\n\tv208 = UnityEngine.RectOffset::get_top(this.padding);\n\tv101 = this._cellViewOffsetArray;\nL_FFFFFFFF:\n\tv91 = v208;\nL_0046:\n\tv211 = v121 + v102;\n\tv89 = v211 >> 0x1F;\n\tv99 = v211 + v89;\n\tv121 = v99 >> 1;\n\tv212 = EnhancedUI.SmallList`1<System.Single>::get_Item(v101, v121);\n\tv50 = v91 != 0;\n\tif (v50) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv223 = 0;\n\tgoto L_005E;\nL_FFFFFFFF:\n\tv223 = 0x3F800054;\n\tv102 = v121 + 1;\nL_FFFFFFFF:\n\tv104 = v121;\n\tgoto L_FFFFFFFF;\nL_007C:\n\treturn v102;\nL_007D:\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\nL_002E:\n\tv155 = v102 >= v121;\n\tif (v155) goto L_007C;\nL_005E:\n\tv53 = v223 + position;\n\tv82 = v212 + v91;\n\tv71 = v82 < v53;\n\tv225 = v82 == v82;\n\tv65 = v53 == v53;\n\tv74 = v225 & v65;\n\tv56 = ~v74;\n\tv47 = v71 == v56;\n\tif (v47) goto L_0021;\nL_FFFFFFFF:\n\tv121 = v104;\nL_0021:\n\tgoto L_002E;\n")]
		private int _GetCellIndexAtPosition(float position, int startIndex, int endIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_GetCellIndexAtPosition");
			return default;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x401FA20", Offset = "0x401FA20", Length = "0x9EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004B;\n\tv79 = UnityEngine.Component::GetComponent(this.ScrollRect);\n\tthis._scrollRectTransform = v79;\n\tv391 = this.ScrollRect;\n\tgoto L_006C;\nL_006C:\n\tv571 = UnityEngine.Object::op_Inequality(v391.content, 0);\n\tv576 = ~v571;\n\tv577 = ~v576;\n\tif (v577) goto L_0078;\n\tgoto L_0091;\nL_0078:\n\tv392 = this.ScrollRect;\n\tv680 = UnityEngine.Component::get_gameObject(v392.content);\n\tgoto L_008A;\nL_0091:\n\t// 145 NewArr v670 @ X0_v20 (System.Type[]), typeof(System.Type[]), 1\n\tgoto L_00A0;\n\tv700 = v301 == 0;\n\tif (v700) goto L_00B5;\n\tv534 = 0x21C11D0(v301, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv541 = v534 == 0;\n\tif (v541) goto L_0331;\nL_00B5:\n\tv670[0] = v301;\n\tv302 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v302, \"Container\", v670);\n\tv303 = UnityEngine.GameObject::get_transform(v302);\n\tv715 = 0xB2CA000 + 0x460;\n\tv213 = 0xB2CA000 + 0x2A0;\n\tUnityEngine.Transform::SetParent(v303, this._scrollRectTransform);\n\tv159 = this.scrollDirection != 0;\n\tif (v159) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv724 = v715;\n\tgoto L_00E1;\nL_FFFFFFFF:\n\tv724 = v213;\n\tv735 = this.scrollDirection == 0;\n\tif (v735) goto L_01A2;\n\tgoto L_0106;\nL_0106:\n\t// 262 MakeStruct v129 @ AGG401FD6C_1_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v395.zero (UnityEngine.Vector2), v395.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMin(this.Container, v129);\n\t// 270 MakeStruct v125 @ AGG401FD84_1_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 1f\n\tUnityEngine.RectTransform::set_anchorMax(this.Container, v125);\n\t// 278 MakeStruct v761 @ AGG401FD9C_1_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 0.5f\n\tUnityEngine.RectTransform::set_pivot(this.Container, v761);\nL_FFFFFFFF:\n\tv256 = this.Container;\n\tgoto L_012F;\nL_012F:\n\t// 303 MakeStruct v110 @ AGG401FDE8_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v798.zero (UnityEngine.Vector3), v798.zero.y (System.Single), v798.zero.z (System.Single)\n\tUnityEngine.Transform::set_localPosition(v256, v110);\n\tgoto L_0149;\nL_0149:\n\t// 329 MakeStruct v105 @ AGG401FE34_1_v4 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v811.identity (UnityEngine.Quaternion), v811.identity.y (System.Single), v811.identity.z (System.Single), v811.identity.w (System.Single)\n\tUnityEngine.Transform::set_localRotation(this.Container, v105);\n\tgoto L_0160;\nL_0160:\n\t// 352 MakeStruct v102 @ AGG401FE78_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v822.one (UnityEngine.Vector3), v822.one.y (System.Single), v822.one.z (System.Single)\n\tUnityEngine.Transform::set_localScale(this.Container, v102);\n\tgoto L_0175;\nL_0175:\n\t// 373 MakeStruct v99 @ AGG401FEB4_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v833.zero (UnityEngine.Vector2), v833.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_offsetMax(this.Container, v99);\n\tgoto L_018A;\nL_018A:\n\t// 394 MakeStruct v96 @ AGG401FEF0_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v396.zero (UnityEngine.Vector2), v396.zero.y (System.Single)\n\tUnityEngine.RectTransform::set_offsetMin(this.Container, v96);\n\tv306 = this.ScrollRect;\n\tv306.content = this.Container;\n\tv397 = this.ScrollRect;\n\tv847 = this.scrollDirection == 0;\n\tif (v847) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv227 = 0x48;\n\tgoto L_01CF;\nL_01A2:\n\t// 418 MakeStruct v93 @ AGG401FF38_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 1f\n\tUnityEngine.RectTransform::set_anchorMin(this.Container, v93);\n\tgoto L_01B8;\nL_01B8:\n\t// 440 MakeStruct v89 @ AGG401FF78_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v399.one (UnityEngine.Vector2), v399.one.y (System.Single)\n\tUnityEngine.RectTransform::set_anchorMax(this.Container, v89);\n\t// 448 MakeStruct v765 @ AGG401FF90_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0.5f, 1f\n\tUnityEngine.RectTransform::set_pivot(this.Container, v765);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv256 = this.Container;\n\tgoto L_012F;\nL_FFFFFFFF:\n\tv227 = 0x50;\n\tv856 = UnityEngine.Component::GetComponent(this.Container);\n\tthis._layoutGroup = v856;\n\tUnityEngine.UI.HorizontalOrVerticalLayoutGroup::set_spacing(this._layoutGroup, this.spacing);\n\tUnityEngine.UI.LayoutGroup::set_padding(this._layoutGroup, this.padding);\n\tUnityEngine.UI.LayoutGroup::set_childAlignment(this._layoutGroup, 0);\n\tUnityEngine.UI.HorizontalOrVerticalLayoutGroup::set_childForceExpandHeight(this._layoutGroup, 1);\n\tUnityEngine.UI.HorizontalOrVerticalLayoutGroup::set_childForceExpandWidth(this._layoutGroup, 1);\n\tv401 = this.ScrollRect;\n\tv863 = this.scrollDirection - 1;\n\tv865 = v863 == 0;\n\tv401.horizontal = v865;\n\tv181 = this.scrollDirection == 0;\n\tv401.vertical = v181;\n\t// 537 NewArr v873 @ X0_v64 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_0226;\nL_0226:\n\tv316 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv882 = v316 == 0;\n\tif (v882) goto L_0239;\n\tv535 = 0x21C11D0(v316, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv542 = v535 == 0;\n\tif (v542) goto L_0331;\nL_0239:\n\tv873[0] = v316;\n\tv893 = System.Type::GetTypeFromHandle(UnityEngine.UI.LayoutElement);\n\tv894 = v893 == 0;\n\tif (v894) goto L_0253;\n\tv536 = 0x21C11D0(v893, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv543 = v536 == 0;\n\tif (v543) goto L_0331;\nL_0253:\n\tv873[1] = v893;\n\tv317 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v317, \"First Padder\", v873);\n\tv318 = UnityEngine.GameObject::get_transform(v317);\n\tUnityEngine.Transform::SetParent(v318, this.Container, 0);\n\tv909 = UnityEngine.GameObject::GetComponent(v317);\n\tthis.FirstPadder = v909;\n\t// 627 NewArr v915 @ X0_v88 (System.Type[]), typeof(System.Type[]), 2\n\tv319 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv917 = v319 == 0;\n\tif (v917) goto L_0288;\n\tv537 = 0x21C11D0(v319, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv544 = v537 == 0;\n\tif (v544) goto L_0331;\nL_0288:\n\tv915[0] = v319;\n\tv927 = System.Type::GetTypeFromHandle(UnityEngine.UI.LayoutElement);\n\tv928 = v927 == 0;\n\tif (v928) goto L_02A2;\n\tv538 = 0x21C11D0(v927, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv545 = v538 == 0;\n\tif (v545) goto L_0331;\nL_02A2:\n\tv915[1] = v927;\n\tv320 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v320, \"Last Padder\", v915);\n\tv321 = UnityEngine.GameObject::get_transform(v320);\n\tUnityEngine.Transform::SetParent(v321, this.Container, 0);\n\tv942 = UnityEngine.GameObject::GetComponent(v320);\n\tthis.LastPadder = v942;\n\t// 704 NewArr v948 @ X0_v110 (System.Type[]), typeof(System.Type[]), 1\n\tv322 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv950 = v322 == 0;\n\tif (v950) goto L_02D7;\n\tv539 = 0x21C11D0(v322, System.Type, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv546 = v539 == 0;\n\tif (v546) goto L_0331;\nL_02D7:\n\tv948[0] = v322;\n\tv323 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v323, \"Recycled Cells\", v948);\n\tv961 = UnityEngine.GameObject::get_transform(v323);\n\tv325 = UnityEngine.Component::get_transform(this.ScrollRect);\n\tUnityEngine.Transform::SetParent(v961, v325, 0);\n\tv967 = UnityEngine.GameObject::GetComponent(v323);\n\tthis._recycledCellViewContainer = v967;\n\tv327 = UnityEngine.Component::get_gameObject(this._recycledCellViewContainer);\n\tUnityEngine.GameObject::SetActi\n// ... truncated")]
		private void Awake()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::Awake");
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x402040C", Offset = "0x402040C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.IsTweening != 1;\n\tif (v11) goto L_0019;\n\tv22 = this.interruptTweeningOnPointerDown != 1;\n\tif (v22) goto L_0019;\n\tthis._interruptTween = this.interruptTweeningOnPointerDown;\nL_0019:\n\treturn;\n")]
		public void OnPointerDown(PointerEventData data)
		{
			if (IsTweening && interruptTweeningOnPointerDown)
			{
				_interruptTween = interruptTweeningOnPointerDown;
			}
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x402042C", Offset = "0x402042C", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = this.IsDragging != 1;\n\tif (v17) goto L_001C;\n\tthis.snapping = this._snapBeforeDrag;\n\tv41 = this.snapping != 1;\n\tif (v41) goto L_0058;\n\tv81 = this.ScrollRect;\n\tv85 = this.scrollDirection == 0;\n\tif (v85) goto L_0048;\n\tv57 = 0xB8;\n\tv49 = UnityEngine.Mathf::Abs(*([v81 @ X8_v6 (UnityEngine.UI.ScrollRect)+v57 @ X9_v5 (System.Int32)]));\n\tv73 = v49 < 1f;\n\tv59 = ~v73;\n\tif (v59) goto L_0058;\nL_003E:\n\tthis._interruptTween = 0;\n\tthis._snapJumping = 0;\n\tthis.IsTweening = 0;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::Snap(this);\n\treturn;\nL_0048:\n\tv55 = 0xBC;\n\tv47 = UnityEngine.Mathf::Abs(*([v81 @ X8_v6 (UnityEngine.UI.ScrollRect)+v55 @ X9_v3 (System.Int32)]));\n\tv72 = v47 < 1f;\n\tif (v72) goto L_003E;\nL_0058:\n\treturn;\nL_001C:\n\tv30 = this.forceSnapOnPointerUp != 1;\n\tif (v30) goto L_0058;\n")]
		public void OnPointerUp(PointerEventData data)
		{
			//IL_0108: Expected F4, but got I
			//IL_0098: Expected F4, but got I
			if (IsDragging)
			{
				snapping = _snapBeforeDrag;
			}
			if (!forceSnapOnPointerUp || !snapping)
			{
				return;
			}
			ScrollRect scrollRect = ScrollRect;
			if (scrollDirection != ScrollDirectionEnum.Vertical)
			{
				int num = 184;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v6 (UnityEngine.UI.ScrollRect)+v57 @ X9_v5 (System.Int32)]");
				float num2 = Mathf.Abs(0f);
				if (!(num2 < 1f))
				{
					return;
				}
			}
			else
			{
				int num3 = 188;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ X8_v6 (UnityEngine.UI.ScrollRect)+v55 @ X9_v3 (System.Int32)]");
				float num4 = Mathf.Abs(0f);
				if (!(num4 < 1f))
				{
					return;
				}
			}
			_interruptTween = false;
			_snapJumping = false;
			IsTweening = false;
			Snap();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x40204C4", Offset = "0x40204C4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsDragging = 1;\n\tv3 = this._dragFingerCount + 1;\n\tthis._dragFingerCount = v3;\n\tv15 = v3 > 1;\n\tif (v15) goto L_0029;\n\tthis._snapBeforeDrag = this.snapping;\n\tv19 = this.snapWhileDragging == 0;\n\tif (v19) goto L_002A;\n\tthis._loopBeforeDrag = this.Loop;\n\tv67 = this.loopWhileDragging == 0;\n\tif (v67) goto L_0032;\nL_0023:\n\tv45 = this.IsTweening == 1;\n\tif (v45) goto L_0049;\nL_0029:\n\treturn;\nL_002A:\n\tthis.snapping = 0;\n\tthis._loopBeforeDrag = this.Loop;\n\tv71 = this.loopWhileDragging == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_0023;\nL_0032:\n\tthis.Loop = 0;\n\tv26 = this.IsTweening != 1;\n\tif (v26) goto L_0029;\nL_0049:\n\tv27 = this.interruptTweeningOnDrag != 1;\n\tif (v27) goto L_0029;\n\tthis._interruptTween = this.interruptTweeningOnDrag;\n\treturn;\n")]
		public void OnBeginDrag(PointerEventData data)
		{
			_dragging = true;
			if (++_dragFingerCount > 1)
			{
				return;
			}
			_snapBeforeDrag = snapping;
			if (snapWhileDragging)
			{
				_loopBeforeDrag = Loop;
				if (loopWhileDragging)
				{
					goto IL_0098;
				}
			}
			else
			{
				snapping = false;
				_loopBeforeDrag = Loop;
				if (loopWhileDragging)
				{
					goto IL_0098;
				}
			}
			loop = false;
			if (!IsTweening)
			{
				return;
			}
			goto IL_0126;
			IL_0098:
			if (!IsTweening)
			{
				return;
			}
			goto IL_0126;
			IL_0126:
			if (interruptTweeningOnDrag)
			{
				_interruptTween = interruptTweeningOnDrag;
			}
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x4020548", Offset = "0x4020548", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis._dragPreviousPos = data.position;\n\treturn;\n")]
		public void OnDrag(PointerEventData data)
		{
			_dragPreviousPos = data.position;
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x4020568", Offset = "0x4020568", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsDragging = 0;\n\tv2 = this._dragFingerCount - 1;\n\tv3 = ~v2;\n\tv4 = v2 & v3;\n\tthis._dragFingerCount = v4;\n\tthis.snapping = this._snapBeforeDrag;\n\tthis.Loop = this._loopBeforeDrag;\n\tv17 = this.forceSnapOnEndDrag != 1;\n\tif (v17) goto L_FFFFFFFF;\n\tv35 = this._snapBeforeDrag == 0;\n\tgoto L_0025;\nL_FFFFFFFF:\n\tv35 = 1;\nL_0027:\n\treturn;\nL_002D:\n\tv92 = this._dragPreviousPos - data.position;\n\tv47 = v92 * v92;\n\t// 47 NotImplemented \"Instruction FADDP not yet implemented.\"\n\tv55 = v47 < 0x2EDBE6FE;\n\tv41 = ~v55;\n\tif (v41) goto L_0027;\n\tv110 = this._snapJumping == 0;\n\tv62 = ~v110;\n\tif (v62) goto L_0027;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::Snap(this);\n\treturn;\nL_0025:\n\tv39 = ~v35;\n\tif (v39) goto L_002D;\n")]
		public void OnEndDrag(PointerEventData data)
		{
			_dragging = false;
			int num = _dragFingerCount - 1;
			int num2 = ~num;
			int dragFingerCount = num & num2;
			_dragFingerCount = dragFingerCount;
			snapping = _snapBeforeDrag;
			loop = _loopBeforeDrag;
			if (forceSnapOnEndDrag && _snapBeforeDrag)
			{
				float num3 = _dragPreviousPos.x - data.position.x;
				float num4 = num3 * num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FADDP not yet implemented.\"");
				if (num4 < 9.9999994E-11f && !_snapJumping)
				{
					Snap();
				}
			}
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x40205E8", Offset = "0x40205E8", Length = "0x1F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = this._updateSpacing != 1;\n\tif (v26) goto L_0030;\n\tthis._updateSpacing = 0;\n\tUnityEngine.UI.HorizontalOrVerticalLayoutGroup::set_spacing(this._layoutGroup, this.spacing);\n\tv139 = this._scrollPosition == 0;\n\tv150 = this._scrollPosition < 0;\n\tv145 = ~v150;\n\tv151 = ~v145;\n\tv135 = v151 | v139;\nL_FFFFFFFF:\n\tv132 = 0;\n\tif (v135) goto L_002B;\n\tv194 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv132 = this._scrollPosition / v194;\nL_0030:\n\tv32 = this._reloadData == 0;\n\tif (v32) goto L_0035;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this, 0f);\nL_0035:\n\tv181 = this.Loop;\n\tv75 = this.Loop != 1;\n\tif (v75) goto L_006F;\n\tv152 = this.scrollDirection == 0;\n\tif (v152) goto L_005A;\n\tv287 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv45 = v287.width;\n\tv294 = this._lastScrollRectSize == v287.width;\n\tif (v294) goto L_0069;\n\tgoto L_0077;\nL_005A:\n\tv288 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv295 = this._lastScrollRectSize == v288.height;\n\tv289 = ~v295;\nL_FFFFFFFF:\n\tv45 = v288.height;\n\tif (v289) goto L_0077;\nL_0069:\n\tv181 = this.Loop;\nL_0077:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_Resize(this, 1);\n\tv326 = this.scrollDirection == 0;\n\tif (v326) goto L_0087;\n\tv337 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\n\tv45 = v337.width;\n\tgoto L_008C;\nL_0087:\n\tv339 = UnityEngine.RectTransform::get_rect(this._scrollRectTransform);\nL_FFFFFFFF:\n\tv45 = v339.height;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::set_ScrollbarVisibility(this, this.ScrollbarVisibility);\n\tthis._lastScrollbarVisibility = this.ScrollbarVisibility;\n\tv340 = 0xB8;\n\tv343 = *([v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v340 @ X10_v8 (System.Int32)]) == 0;\n\tif (v343) goto L_00C9;\n\tgoto L_00BC;\nL_00B1:\n\tv348 = 0xBC;\n\tv351 = *([v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v348 @ X10_v7 (System.Int32)]) == 0;\n\tif (v351) goto L_00C9;\nL_00BC:\n\tv366 = this.IsScrolling == 0;\n\tif (v366) goto L_00EB;\nL_00C9:\n\tv390 = this.scrollDirection != 0;\n\tif (v390) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv399 = 0xBC;\n\tgoto L_00CF;\nL_FFFFFFFF:\n\tv399 = 0xB8;\n\tv410 = this.IsScrolling != 1;\n\tif (v410) goto L_0102;\n\tthis.IsScrolling = 0;\n\tv268 = this.scrollerScrollingChanged;\n\tv409 = this.scrollerScrollingChanged == 0;\n\tif (v409) goto L_0102;\nL_FFFFFFFF:\n\tv211 = 0;\n\tgoto L_00FA;\nL_00EB:\n\tthis.IsScrolling = 1;\n\tv268 = this.scrollerScrollingChanged;\n\tv398 = this.scrollerScrollingChanged == 0;\nL_FFFFFFFF:\n\tv211 = 1;\n\tif (v398) goto L_0102;\nL_00FA:\n\tEnhancedUI.EnhancedScroller.ScrollerScrollingChangedDelegate::Invoke(v268, this, v211);\nL_00FA:\n\treturn;\nL_0102:\n\treturn;\nL_002B:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::ReloadData(this, v132);\n\tthis._reloadData = 0;\n\tgoto L_0035;\nL_006F:\n\tv188 = v181 == this._lastLoop;\n\tif (v188) goto L_0095;\nL_008C:\n\tthis._lastScrollRectSize = v45;\n\tthis._lastLoop = this.Loop;\nL_00CF:\n\t;\n\tv402 = *([v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v399 @ X9_v7 (System.Int32)]) == 0;\n\tv407 = ~v402;\n\tif (v407) goto L_0102;\nL_0095:\n\tv97 = this._lastScrollbarVisibility == this.ScrollbarVisibility;\n\tif (v97) goto L_00A0;\nL_00A0:\n\tv113 = this.ScrollRect;\n\tv330 = this.scrollDirection == 0;\n\tif (v330) goto L_00B1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			if (_updateSpacing)
			{
				_updateSpacing = false;
				_layoutGroup.spacing = spacing;
				bool flag = _scrollPosition == 0f;
				bool flag2 = _scrollPosition < 0f;
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				bool flag5 = flag4 || flag;
				float scrollPositionFactor = 0f;
				if (!flag5)
				{
					float scrollSize = ScrollSize;
					scrollPositionFactor = _scrollPosition / scrollSize;
				}
				ReloadData(scrollPositionFactor);
				_reloadData = false;
			}
			else if (_reloadData)
			{
				ReloadData();
			}
			bool flag6 = Loop;
			float width;
			if (Loop)
			{
				if (scrollDirection != ScrollDirectionEnum.Vertical)
				{
					Rect rect = _scrollRectTransform.rect;
					width = rect.width;
					if (_lastScrollRectSize == rect.width)
					{
						goto IL_01d3;
					}
				}
				else
				{
					Rect rect2 = _scrollRectTransform.rect;
					bool flag7 = _lastScrollRectSize == rect2.height;
					bool flag8 = !flag7;
					width = rect2.height;
					if (!flag8)
					{
						goto IL_01d3;
					}
				}
				goto IL_01e2;
			}
			goto IL_03f2;
			IL_01d3:
			flag6 = Loop;
			goto IL_03f2;
			IL_02f1:
			if (scrollDirection == ScrollDirectionEnum.Vertical)
			{
				int num = 188;
			}
			else
			{
				int num = 184;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v399 @ X9_v7 (System.Int32)]");
			ScrollerScrollingChangedDelegate scrollerScrollingChangedDelegate;
			bool scrolling;
			if ((nint)0 == 0 && IsScrolling)
			{
				IsScrolling = false;
				scrollerScrollingChangedDelegate = scrollerScrollingChanged;
				if (scrollerScrollingChanged != null)
				{
					scrolling = false;
					goto IL_03c8;
				}
				return;
			}
			return;
			IL_02d2:
			if (IsScrolling)
			{
				goto IL_02f1;
			}
			IsScrolling = true;
			scrollerScrollingChangedDelegate = scrollerScrollingChanged;
			bool flag9 = scrollerScrollingChanged == null;
			scrolling = true;
			if (!flag9)
			{
				goto IL_03c8;
			}
			return;
			IL_01e2:
			_Resize(keepPosition: true);
			width = ((scrollDirection == ScrollDirectionEnum.Vertical) ? _scrollRectTransform.rect.height : _scrollRectTransform.rect.width);
			_lastScrollRectSize = width;
			_lastLoop = Loop;
			goto IL_045c;
			IL_03f2:
			if (flag6 != _lastLoop)
			{
				goto IL_01e2;
			}
			goto IL_045c;
			IL_045c:
			if (_lastScrollbarVisibility != ScrollbarVisibility)
			{
				ScrollbarVisibility = ScrollbarVisibility;
				_lastScrollbarVisibility = ScrollbarVisibility;
			}
			ScrollRect scrollRect = ScrollRect;
			if (scrollDirection != ScrollDirectionEnum.Vertical)
			{
				int num2 = 184;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v340 @ X10_v8 (System.Int32)]");
				if ((nint)0 != 0)
				{
					goto IL_02d2;
				}
			}
			else
			{
				int num3 = 188;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X8_v8 (UnityEngine.UI.ScrollRect)+v348 @ X10_v7 (System.Int32)]");
				if ((nint)0 != 0)
				{
					goto IL_02d2;
				}
			}
			goto IL_02f1;
			IL_03c8:
			scrollerScrollingChangedDelegate(this, scrolling);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x40207E0", Offset = "0x40207E0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this._initialized != 1;\n\tif (v11) goto L_001B;\n\tv12 = this._layoutGroup;\n\tv29 = this.spacing == v12.spacing;\n\tv23 = ~v29;\n\tif (v23) goto L_001D;\nL_001B:\n\treturn;\nL_001D:\n\tthis._updateSpacing = 1;\n\treturn;\n")]
		private void OnValidate()
		{
			if (_initialized)
			{
				HorizontalOrVerticalLayoutGroup layoutGroup = _layoutGroup;
				if (spacing != layoutGroup.spacing)
				{
					_updateSpacing = true;
				}
			}
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x4020820", Offset = "0x4020820", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv68 = this.maxVelocity;\n\tv8 = this.maxVelocity < 0;\n\tv9 = this.maxVelocity == 0;\n\tv12 = this.maxVelocity == this.maxVelocity;\n\tv13 = ~v12;\n\tv14 = v8 == v13;\n\tv15 = ~v14;\n\tv16 = v15 | v9;\n\tif (v16) goto L_006D;\n\tv18 = this.ScrollRect;\n\tv28 = this.scrollDirection != 1;\n\tif (v28) goto L_0048;\n\tv108 = UnityEngine.Mathf::Abs(v18.velocity);\n\tv122 = v108 < v68;\n\tv123 = v108 == v68;\n\tv126 = v108 == v108;\n\tv89 = v68 == v68;\n\tv127 = v126 & v89;\n\tv128 = ~v127;\n\tv129 = v122 == v128;\n\tv79 = ~v123;\n\tv130 = v129 & v79;\n\tv131 = ~v130;\n\tif (v131) goto L_FFFFFFFF;\n\tgoto L_0031;\nL_FFFFFFFF:\n\tv68 = v108;\nL_FFFFFFFF:\n\tv68 = v81;\n\tgoto L_0040;\nL_0048:\n\tv121 = UnityEngine.Mathf::Abs(v18.m_Velocity.y);\n\tv132 = v121 < this.maxVelocity;\n\tv133 = v121 == this.maxVelocity;\n\tv136 = v121 == v121;\n\tv49 = this.maxVelocity == this.maxVelocity;\n\tv137 = v136 & v49;\n\tv138 = ~v137;\n\tv139 = v132 == v138;\n\tv33 = ~v133;\n\tv140 = v139 & v33;\n\tv141 = ~v140;\n\tif (v141) goto L_FFFFFFFF;\n\tgoto L_005A;\nL_FFFFFFFF:\n\tv68 = v121;\nL_FFFFFFFF:\n\tv68 = v36;\n\tgoto L_0069;\nL_006D:\n\treturn;\nL_0031:\n\tv81 = -v68;\n\tv103 = v18.velocity < 0;\n\tv97 = v18.velocity == v18.velocity;\n\tv95 = ~v97;\n\tv148 = v103 == v95;\n\tv93 = ~v148;\n\tv77 = ~v93;\n\tif (v77) goto L_0040;\nL_0040:\n\tv18.m_Velocity.x = v68;\n\treturn;\nL_005A:\n\tv36 = -v68;\n\tv66 = v18.m_Velocity.y < 0;\n\tv60 = v18.m_Velocity.y == v18.m_Velocity.y;\n\tv58 = ~v60;\n\tv151 = v66 == v58;\n\tv56 = ~v151;\n\tv30 = ~v56;\n\tif (v30) goto L_0069;\nL_0069:\n\tv18.m_Velocity.y = v68;\n")]
		private void LateUpdate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::LateUpdate");
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x40208A0", Offset = "0x40208A0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv54 = new UnityEngine.Events.UnityAction`1<UnityEngine.Vector2>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Vector2>::.ctor(v54, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Vector2>::AddListener(v43.onValueChanged, v54);\n\treturn;\nL_001A:\n\tv43 = this.ScrollRect;\n")]
		private void OnEnable()
		{
			ScrollRect scrollRect = ScrollRect;
			UnityAction<Vector2> call = _ScrollRect_OnValueChanged;
			scrollRect.onValueChanged.AddListener(call);
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x4020950", Offset = "0x4020950", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv54 = new UnityEngine.Events.UnityAction`1<UnityEngine.Vector2>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Vector2>::.ctor(v54, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Vector2>::RemoveListener(v43.onValueChanged, v54);\n\treturn;\nL_001A:\n\tv43 = this.ScrollRect;\n")]
		private void OnDisable()
		{
			ScrollRect scrollRect = ScrollRect;
			UnityAction<Vector2> call = _ScrollRect_OnValueChanged;
			scrollRect.onValueChanged.RemoveListener(call);
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x4020A00", Offset = "0x4020A00", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv28 = 1f - val.y;\n\tv38 = this.scrollDirection != 0;\n\tif (v38) goto L_FFFFFFFF;\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv28 = val;\n\tgoto L_0036;\nL_FFFFFFFF:\n\tv59 = v42;\nL_FFFFFFFF:\n\tv70 = 0;\n\tgoto L_0043;\nL_FFFFFFFF:\n\tv70 = v59;\n\tEnhancedUI.EnhancedScroller.ScrollerScrolledDelegate::Invoke(this.scrollerScrolled, this, v71.method, v80);\n\tv111 = this._snapJumping == 0;\n\tv112 = ~v111;\n\tif (v112) goto L_007D;\n\tv118 = this.ScrollRect;\n\tv170 = this.scrollDirection == 0;\n\tif (v170) goto L_0081;\n\tv156 = v118.velocity;\n\tv158 = UnityEngine.Mathf::Abs(v118.velocity);\n\tv138 = v158 == this.snapVelocityThreshold;\n\tv204 = v158 < this.snapVelocityThreshold;\n\tv150 = ~v204;\n\tv206 = ~v150;\n\tv126 = v206 | v138;\n\tif (v126) goto L_0090;\nL_007D:\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this);\n\treturn;\nL_0081:\n\tv156 = v118.m_Velocity.y;\n\tv159 = UnityEngine.Mathf::Abs(v118.m_Velocity.y);\n\tv139 = v159 == this.snapVelocityThreshold;\n\tv207 = v159 < this.snapVelocityThreshold;\n\tv151 = ~v207;\n\tv209 = ~v139;\n\tv127 = v151 & v209;\n\tif (v127) goto L_007D;\nL_0090:\n\tv140 = v156 == 0;\n\tif (v140) goto L_007D;\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::Snap(this);\n\tEnhancedUI.EnhancedScroller.EnhancedScroller::_RefreshActive(this);\n\treturn;\nL_0021:\n\tv42 = v28 * v25;\n\tthis._scrollPosition = v42;\n\tv59 = EnhancedUI.EnhancedScroller.EnhancedScroller::get_ScrollSize(this);\n\tv45 = v42 < v59;\n\tv46 = v42 == v59;\n\tv49 = v42 == v42;\n\tv50 = v59 == v59;\n\tv51 = v49 & v50;\n\tv52 = ~v51;\n\tv53 = v45 == v52;\n\tv54 = ~v46;\n\tv55 = v53 & v54;\n\tv56 = ~v55;\n\tif (v56) goto L_FFFFFFFF;\nL_0036:\n\tv60 = v42 < 0;\n\tv67 = ~v60;\n\tif (v67) goto L_FFFFFFFF;\nL_0043:\n\tthis._scrollPosition = v70;\n\tv71 = this.scrollerScrolled;\n\tv72 = this.scrollerScrolled == 0;\n\tif (v72) goto L_0058;\nL_0058:\n\tv108 = this.snapping != 1;\n\tif (v108) goto L_007D;\n")]
		private void _ScrollRect_OnValueChanged(Vector2 val)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnhancedScroller::_ScrollRect_OnValueChanged");
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x4020B18", Offset = "0x4020B18", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv42.inertia = this._snapInertia;\n\tv125 = this._activeCellViews;\n\tv105 = 0;\n\tv94 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(v125, v105);\n\tv67 = v94.dataIndex == this._snapDataIndex;\n\tif (v67) goto L_005A;\n\tv105 = v105 + 1;\n\tv125 = this._activeCellViews;\n\tv230 = this._activeCellViews == 0;\n\tv97 = ~v230;\n\tif (v97) goto L_002A;\n\tthrow System.NullReferenceException;\nL_0044:\n\tv165 = this.scrollerSnapped;\n\tv132 = this.scrollerSnapped == 0;\n\tv145 = 0;\n\tif (v132) goto L_0067;\nL_0054:\n\tEnhancedUI.EnhancedScroller.ScrollerSnappedDelegate::Invoke(v165, this, this._snapCellViewIndex, this._snapDataIndex, v145);\nL_0054:\n\treturn;\nL_005A:\n\tv162 = EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::get_Item(this._activeCellViews, v105);\n\tv165 = this.scrollerSnapped;\n\tv231 = this.scrollerSnapped == 0;\n\tv164 = ~v231;\n\tv145 = v162;\n\tif (v164) goto L_0054;\nL_0067:\n\treturn;\nL_0014:\n\tthis._snapJumping = 0;\n\tv42 = this.ScrollRect;\nL_002A:\n\tv48 = v105 >= v125.Count;\n\tif (v48) goto L_0044;\n")]
		private void SnapJumpComplete()
		{
			_snapJumping = false;
			ScrollRect scrollRect = ScrollRect;
			scrollRect.inertia = _snapInertia;
			SmallList<EnhancedScrollerCellView> activeCellViews = _activeCellViews;
			int num = 0;
			while (true)
			{
				ScrollerSnappedDelegate scrollerSnappedDelegate;
				EnhancedScrollerCellView cellView;
				if (num < activeCellViews.Count)
				{
					EnhancedScrollerCellView enhancedScrollerCellView = activeCellViews[num];
					if (enhancedScrollerCellView.dataIndex != _snapDataIndex)
					{
						num++;
						activeCellViews = _activeCellViews;
						if (_activeCellViews == null)
						{
							throw new NullReferenceException();
						}
						continue;
					}
					EnhancedScrollerCellView enhancedScrollerCellView2 = _activeCellViews[num];
					scrollerSnappedDelegate = scrollerSnapped;
					bool flag = scrollerSnapped == null;
					bool flag2 = !flag;
					cellView = enhancedScrollerCellView2;
					if (!flag2)
					{
						break;
					}
				}
				else
				{
					scrollerSnappedDelegate = scrollerSnapped;
					bool flag3 = scrollerSnapped == null;
					cellView = null;
					if (flag3)
					{
						break;
					}
				}
				scrollerSnappedDelegate(this, _snapCellViewIndex, _snapDataIndex, cellView);
				break;
			}
		}

		[IteratorStateMachine(typeof(_003CTweenPosition_003Ed__190))]
		[Token(Token = "0x6000086")]
		[Address(RVA = "0x401E368", Offset = "0x401E368", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv63.tweenType = tweenType;\n\tv63.time = time;\n\tv63.start = start;\n\tv63.end = end;\n\tv63.tweenComplete = tweenComplete;\n\tv63.forceCalculateRange = forceCalculateRange;\n\treturn v63;\nL_0023:\n\tv63 = new EnhancedUI.EnhancedScroller.EnhancedScroller+<TweenPosition>d__190();\n\tSystem.Object::.ctor(v63);\n\tv63.<>1__state = 0;\n\tv63.<>4__this = this;\n")]
		private IEnumerator TweenPosition(TweenType tweenType, float time, float start, float end, Action tweenComplete, bool forceCalculateRange)
		{
			_003CTweenPosition_003Ed__190 _003CTweenPosition_003Ed__191 = (_003CTweenPosition_003Ed__190)FormatterServices.GetUninitializedObject(typeof(_003CTweenPosition_003Ed__190));
			_003CTweenPosition_003Ed__191._003C_003E1__state = 0;
			_003CTweenPosition_003Ed__191._003C_003E4__this = this;
			_003CTweenPosition_003Ed__191.tweenType = tweenType;
			_003CTweenPosition_003Ed__191.time = time;
			_003CTweenPosition_003Ed__191.start = start;
			_003CTweenPosition_003Ed__191.end = end;
			_003CTweenPosition_003Ed__191.tweenComplete = tweenComplete;
			_003CTweenPosition_003Ed__191.forceCalculateRange = forceCalculateRange;
			return _003CTweenPosition_003Ed__191;
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x4020C40", Offset = "0x4020C40", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val < 1f;\n\tv3 = val == 1f;\n\tv6 = val == val;\n\tv7 = 1f == 1f;\n\tv8 = v6 & v7;\n\tv9 = ~v8;\n\tv10 = v1 == v9;\n\tv11 = ~v3;\n\tv12 = v10 & v11;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 1f;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv16 = val;\nL_FFFFFFFF:\n\tv27 = 0;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv27 = v16;\nL_0012:\n\tv17 = val < 0;\n\tv24 = ~v17;\n\tif (v24) goto L_FFFFFFFF;\nL_001F:\n\tv28 = end - start;\n\tv31 = v28 * v27;\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n")]
		private float linear(float start, float end, float val)
		{
			bool flag = val < 1f;
			bool flag2 = val == 1f;
			bool flag3 = val == val;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? val : 1f);
			float num2 = ((!(val < 0f)) ? num : 0f);
			float num3 = end - start;
			float num4 = num3 * num2;
			return num4 + start;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x4020C68", Offset = "0x4020C68", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = val < 1f;\n\tv25 = val == 1f;\n\tv28 = val == val;\n\tv29 = 1f == 1f;\n\tv30 = v28 & v29;\n\tv31 = ~v30;\n\tv32 = v23 == v31;\n\tv33 = ~v25;\n\tv34 = v32 & v33;\n\tv35 = ~v34;\n\tif (v35) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv38 = 1f;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv38 = val;\nL_FFFFFFFF:\n\tv49 = 0;\n\tgoto L_002E;\nL_FFFFFFFF:\n\tv49 = v38;\nL_001E:\n\tv39 = val < 0;\n\tv46 = ~v39;\n\tif (v46) goto L_FFFFFFFF;\nL_002E:\n\tv53 = v49 * 0x40490FDB;\n\tv55 = v49 * 2.5f;\n\tv56 = v49 * v55;\n\tv57 = v49 * v56;\n\tv61 = v57 + 0x3E4CCCCD;\n\tv62 = v53 * v61;\n\tv63 = 0x8BF749C(methodInfo, v65, v66, v67, v68, v69, v70, v71, v62, v61, 0x3E4CCCCD, v72, v73, v74, v75, v76);\n\tv78 = 1f - v49;\n\tv83 = 0x8BF6F2C(v63, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v78, 0x400CCCCD, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv84 = v78 * v62;\n\tv85 = v49 + v84;\n\tv89 = v78 * 0x3F99999A;\n\tv90 = v89 + 1f;\n\tv91 = v90 * v85;\n\tv92 = end - start;\n\tv93 = v92 * v91;\n\treturnVal1 = v93 + start;\n\treturn returnVal1;\n")]
		private static float spring(float start, float end, float val)
		{
			bool flag = val < 1f;
			bool flag2 = val == 1f;
			bool flag3 = val == val;
			bool flag4 = 1f == 1f;
			bool flag5 = flag3 && flag4;
			bool flag6 = !flag5;
			bool flag7 = flag == flag6;
			bool flag8 = !flag2;
			float num = ((!(flag7 && flag8)) ? val : 1f);
			float num2 = ((!(val < 0f)) ? num : 0f);
			float num3 = num2 * (float)Math.PI;
			float num4 = num2 * 2.5f;
			float num5 = num2 * num4;
			float num6 = num2 * num5;
			float num7 = num6 + 0.2f;
			float num8 = num3 * num7;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num9 = 1f - num2;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6F2C");
			float num10 = num9 * num8;
			float num11 = num2 + num10;
			float num12 = num9 * 1.2f;
			float num13 = num12 + 1f;
			float num14 = num13 * num11;
			float num15 = end - start;
			float num16 = num15 * num14;
			return num16 + start;
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x4020D30", Offset = "0x4020D30", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\treturnVal1 = v5 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuad(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			return num3 + start;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x4020D44", Offset = "0x4020D44", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv6 = val + -2f;\n\tv7 = v3 * v6;\n\treturnVal1 = start - v7;\n\treturn returnVal1;\n")]
		private static float easeOutQuad(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = val + -2f;
			float num4 = num2 * num3;
			return start - num4;
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x4020D60", Offset = "0x4020D60", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -1f;\n\tv17 = v2 * -0.5f;\n\tv19 = v15 + -2f;\n\tv20 = v15 * v19;\n\tv21 = v20 + -1f;\n\tv22 = v17 * v21;\n\tv24 = v2 * 0.5f;\n\tv25 = v24 * v0;\n\tv31 = v0 * v25;\n\tv27 = ~v6;\n\tv28 = ~v27;\n\tif (v28) goto L_001F;\n\tv31 = v22;\n\tgoto L_001F;\nL_001F:\n\treturnVal1 = v31 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuad(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -1f;
			float num4 = num2 * -0.5f;
			float num5 = num3 + -2f;
			float num6 = num3 * num5;
			float num7 = num6 + -1f;
			float num8 = num4 * num7;
			float num9 = num2 * 0.5f;
			float num10 = num9 * num;
			float num11 = num * num10;
			if (!flag)
			{
				num11 = num8;
			}
			return num11 + start;
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x4020DB0", Offset = "0x4020DB0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\treturnVal1 = v6 + start;\n\treturn returnVal1;\n")]
		private static float easeInCubic(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			return num4 + start;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x4020DC8", Offset = "0x4020DC8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv9 = v7 + 1f;\n\tv10 = v3 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n")]
		private static float easeOutCubic(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num4 + 1f;
			float num6 = num2 * num5;
			return num6 + start;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x4020DF0", Offset = "0x4020DF0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * 0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv21 = v19 + 2f;\n\tv22 = v17 * v21;\n\tv23 = v17 * v0;\n\tv24 = v0 * v23;\n\tv30 = v0 * v24;\n\tv26 = ~v6;\n\tv27 = ~v26;\n\tif (v27) goto L_001E;\n\tv30 = v22;\n\tgoto L_001E;\nL_001E:\n\treturnVal1 = v30 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutCubic(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num6 + 2f;
			float num8 = num4 * num7;
			float num9 = num4 * num;
			float num10 = num * num9;
			float num11 = num * num10;
			if (!flag)
			{
				num11 = num8;
			}
			return num11 + start;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x4020E3C", Offset = "0x4020E3C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\tv7 = v6 * val;\n\treturnVal1 = v7 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuart(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			float num5 = num4 * val;
			return num5 + start;
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x4020E58", Offset = "0x4020E58", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv8 = v1 * v7;\n\tv9 = v8 + -1f;\n\tv10 = v3 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n")]
		private static float easeOutQuart(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = num5 + -1f;
			float num7 = num2 * num6;
			return start - num7;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x4020E80", Offset = "0x4020E80", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * -0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv20 = v15 * v19;\n\tv21 = v20 + -2f;\n\tv22 = v17 * v21;\n\tv24 = v2 * 0.5f;\n\tv25 = v24 * v0;\n\tv26 = v0 * v25;\n\tv27 = v0 * v26;\n\tv33 = v0 * v27;\n\tv29 = ~v6;\n\tv30 = ~v29;\n\tif (v30) goto L_0021;\n\tv33 = v22;\n\tgoto L_0021;\nL_0021:\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuart(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * -0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num3 * num6;
			float num8 = num7 + -2f;
			float num9 = num4 * num8;
			float num10 = num2 * 0.5f;
			float num11 = num10 * num;
			float num12 = num * num11;
			float num13 = num * num12;
			float num14 = num * num13;
			if (!flag)
			{
				num14 = num9;
			}
			return num14 + start;
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x4020ED8", Offset = "0x4020ED8", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv6 = v5 * val;\n\tv7 = v6 * val;\n\tv8 = v7 * val;\n\treturnVal1 = v8 + start;\n\treturn returnVal1;\n")]
		private static float easeInQuint(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = num3 * val;
			float num5 = num4 * val;
			float num6 = num5 * val;
			return num6 + start;
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x4020EF8", Offset = "0x4020EF8", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv7 = v1 * v6;\n\tv8 = v1 * v7;\n\tv9 = v1 * v8;\n\tv11 = v9 + 1f;\n\tv12 = v3 * v11;\n\treturnVal1 = v12 + start;\n\treturn returnVal1;\n")]
		private static float easeOutQuint(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float num4 = num * num3;
			float num5 = num * num4;
			float num6 = num * num5;
			float num7 = num6 + 1f;
			float num8 = num2 * num7;
			return num8 + start;
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x4020F28", Offset = "0x4020F28", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 < 1f;\n\tv15 = v0 + -2f;\n\tv17 = v2 * 0.5f;\n\tv18 = v15 * v15;\n\tv19 = v15 * v18;\n\tv20 = v15 * v19;\n\tv21 = v15 * v20;\n\tv23 = v21 + 2f;\n\tv24 = v17 * v23;\n\tv25 = v17 * v0;\n\tv26 = v0 * v25;\n\tv27 = v0 * v26;\n\tv28 = v0 * v27;\n\tv34 = v0 * v28;\n\tv30 = ~v6;\n\tv31 = ~v30;\n\tif (v31) goto L_0022;\n\tv34 = v24;\n\tgoto L_0022;\nL_0022:\n\treturnVal1 = v34 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutQuint(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			bool flag = num < 1f;
			float num3 = num + -2f;
			float num4 = num2 * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * num5;
			float num7 = num3 * num6;
			float num8 = num3 * num7;
			float num9 = num8 + 2f;
			float num10 = num4 * num9;
			float num11 = num4 * num;
			float num12 = num * num11;
			float num13 = num * num12;
			float num14 = num * num13;
			float num15 = num * num14;
			if (!flag)
			{
				num15 = num10;
			}
			return num15 + start;
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x4020F84", Offset = "0x4020F84", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x3FC90FDB;\n\tv19 = 0x8BF608C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v17;\n\tv34 = v12 - v33;\n\treturnVal1 = v34 + start;\n\treturn returnVal1;\n")]
		private static float easeInSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF608C");
			float num3 = num * num2;
			float num4 = num - num3;
			return num4 + start;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x4020FC4", Offset = "0x4020FC4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x3FC90FDB;\n\tv19 = 0x8BF749C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v17;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeOutSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * ((float)Math.PI / 2f);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num3 = num * num2;
			return num3 + start;
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x4021000", Offset = "0x4021000", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv17 = val * 0x40490FDB;\n\tv19 = 0x8BF608C(methodInfo, v21, v22, v23, v24, v25, v26, v27, v17, end, val, v28, v29, v30, v31, v32);\n\tv34 = v12 * -0.5f;\n\tv36 = v17 + -1f;\n\tv37 = v34 * v36;\n\treturnVal1 = start + v37;\n\treturn returnVal1;\n")]
		private static float easeInOutSine(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * (float)Math.PI;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF608C");
			float num3 = num * -0.5f;
			float num4 = num2 + -1f;
			float num5 = num3 * num4;
			return start + num5;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x402104C", Offset = "0x402104C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv15 = val + -1f;\n\tv18 = v15 * 10f;\n\tv19 = 0x8BF63A4(methodInfo, v21, v22, v23, v24, v25, v26, v27, v18, 10f, val, v28, v29, v30, v31, v32);\n\tv33 = v12 * v18;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeInExpo(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + -1f;
			float num3 = num2 * 10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x4021088", Offset = "0x4021088", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = end - start;\n\tv15 = val * -10f;\n\tv17 = 0x8BF63A4(methodInfo, v19, v20, v21, v22, v23, v24, v25, v15, end, val, v26, v27, v28, v29, v30);\n\tv32 = 1f - v15;\n\tv33 = v12 * v32;\n\treturnVal1 = v33 + start;\n\treturn returnVal1;\n")]
		private static float easeOutExpo(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num3 = 1f - num2;
			float num4 = num * num3;
			return num4 + start;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x40210C4", Offset = "0x40210C4", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = val + val;\n\tv17 = v14 + -1f;\n\tv19 = v14 < 1f;\n\tv27 = ~v19;\n\tif (v27) goto L_001B;\n\tv50 = v17 * 10f;\n\tv30 = 0x8BF63A4(methodInfo, v32, v33, v34, v35, v36, v37, v38, v50, 10f, 1f, v39, v40, v41, v42, v43);\n\tgoto L_001F;\nL_001B:\n\tv45 = v17 * -10f;\n\tv46 = 0x8BF63A4(methodInfo, v32, v33, v34, v35, v36, v37, v38, v45, -10f, 1f, v39, v40, v41, v42, v43);\n\tv50 = 2f - v45;\nL_001F:\n\tv52 = end - start;\n\tv54 = v52 * 0.5f;\n\tv55 = v54 * v50;\n\treturnVal1 = v55 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutExpo(float start, float end, float val)
		{
			float num = val + val;
			float num2 = num + -1f;
			float num3;
			if (num < 1f)
			{
				num3 = num2 * 10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			}
			else
			{
				float num4 = num2 * -10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
				num3 = 2f - num4;
			}
			float num5 = end - start;
			float num6 = num5 * 0.5f;
			float num7 = num6 * num3;
			return num7 + start;
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x4021134", Offset = "0x4021134", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val * val;\n\tv6 = 1f - v3;\n\tv7 = UnityEngine.Mathf::Sqrt(v6);\n\tv9 = v7 + -1f;\n\tv10 = v0 * v9;\n\treturnVal1 = start - v10;\n\treturn returnVal1;\n")]
		private static float easeInCirc(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val * val;
			float f = 1f - num2;
			float num3 = Mathf.Sqrt(f);
			float num4 = num3 + -1f;
			float num5 = num * num4;
			return start - num5;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x402115C", Offset = "0x402115C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = val + -1f;\n\tv3 = end - start;\n\tv6 = v1 * v1;\n\tv8 = 1f - v6;\n\tv9 = UnityEngine.Mathf::Sqrt(v8);\n\tv10 = v3 * v9;\n\treturnVal1 = v10 + start;\n\treturn returnVal1;\n")]
		private static float easeOutCirc(float start, float end, float val)
		{
			float num = val + -1f;
			float num2 = end - start;
			float num3 = num * num;
			float f = 1f - num3;
			float num4 = Mathf.Sqrt(f);
			float num5 = num2 * num4;
			return num5 + start;
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x4021184", Offset = "0x4021184", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = val + val;\n\tv2 = end - start;\n\tv6 = v0 + -2f;\n\tv7 = v6 * v6;\n\tv8 = v0 * v0;\n\tv10 = v0 < 1f;\n\tv18 = ~v10;\n\tif (v18) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv21 = v8;\n\tgoto L_0017;\nL_FFFFFFFF:\n\tv21 = v7;\nL_FFFFFFFF:\n\tv27 = -0.5f;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv27 = 0.5f;\nL_FFFFFFFF:\n\tv32 = -1f;\n\tgoto L_0024;\nL_FFFFFFFF:\n\tv32 = 1f;\nL_0017:\n\tv24 = ~v10;\n\tif (v24) goto L_FFFFFFFF;\nL_001E:\n\tv29 = ~v10;\n\tif (v29) goto L_FFFFFFFF;\nL_0024:\n\tv33 = 1f - v21;\n\tv34 = UnityEngine.Mathf::Sqrt(v33);\n\tv35 = v2 * v27;\n\tv36 = v34 + v32;\n\tv37 = v35 * v36;\n\treturnVal1 = v37 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutCirc(float start, float end, float val)
		{
			float num = val + val;
			float num2 = end - start;
			float num3 = num + -2f;
			float num4 = num3 * num3;
			float num5 = num * num;
			bool flag = num < 1f;
			float num6 = ((!flag) ? num4 : num5);
			float num7 = ((!flag) ? 0.5f : (-0.5f));
			float num8 = ((!flag) ? 1f : (-1f));
			float f = 1f - num6;
			float num9 = Mathf.Sqrt(f);
			float num10 = num2 * num7;
			float num11 = num9 + num8;
			float num12 = num10 * num11;
			return num12 + start;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x40211D8", Offset = "0x40211D8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = 1f - val;\n\tv6 = v1 < 0x3EBA2E8C;\n\tv14 = ~v6;\n\tif (v14) goto L_0017;\n\tv17 = v1 * 0x40F20000;\n\tv50 = v1 * v17;\n\tgoto L_004D;\nL_0017:\n\tv22 = v1 < 0x3F3A2E8C;\n\tv30 = ~v22;\n\tif (v30) goto L_002E;\n\tv65 = v1 + 0xFFFFFFFFBF0BA2E9;\n\tv68 = v65 * 0x40F20000;\n\tv85 = v65 * v68;\n\tv53 = 0.75f;\n\tgoto L_004C;\nL_002E:\n\tv74 = v1 < 0.9090909090909091d;\n\tv82 = ~v74;\n\tif (v82) goto L_0045;\n\tv93 = v1 + 0xFFFFFFFFBF51745D;\n\tv95 = v93 * 0x40F20000;\n\tv85 = v93 * v95;\n\tv53 = 0.9375f;\n\tgoto L_004C;\nL_0045:\n\tv99 = v1 + 0xFFFFFFFFBF745D17;\n\tv102 = v99 * 0x40F20000;\n\tv85 = v99 * v102;\n\tv53 = 0x3F7C0000;\nL_004D:\n\tv54 = end - start;\n\tv57 = v54 * v50;\n\tv60 = v54 - v57;\n\treturnVal1 = v60 + start;\n\treturn returnVal1;\nL_004C:\n\tv50 = v85 + v53;\n")]
		private static float easeInBounce(float start, float end, float val)
		{
			float num = 1f - val;
			float num3;
			if (num < 0.36363637f)
			{
				float num2 = num * 7.5625f;
				num3 = num * num2;
			}
			else
			{
				float num6;
				float num7;
				if (num < 0.72727275f)
				{
					float num4 = num + -0.54545456f;
					float num5 = num4 * 7.5625f;
					num6 = num4 * num5;
					num7 = 0.75f;
				}
				else if ((double)num < 0.9090909090909091)
				{
					float num8 = num + -0.8181818f;
					float num9 = num8 * 7.5625f;
					num6 = num8 * num9;
					num7 = 0.9375f;
				}
				else
				{
					float num10 = num + -21f / 22f;
					float num11 = num10 * 7.5625f;
					num6 = num10 * num11;
					num7 = 63f / 64f;
				}
				num3 = num6 + num7;
			}
			float num12 = end - start;
			float num13 = num12 * num3;
			float num14 = num12 - num13;
			return num14 + start;
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x40212C8", Offset = "0x40212C8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = val < 0x3EBA2E8C;\n\tv12 = ~v3;\n\tif (v12) goto L_0018;\n\tv15 = val * 0x40F20000;\n\tv16 = v15 * val;\n\tv17 = end - start;\n\tv20 = v17 * v16;\n\treturnVal1 = v20 + start;\n\treturn returnVal1;\nL_0018:\n\tv25 = val < 0x3F3A2E8C;\n\tv33 = ~v25;\n\tif (v33) goto L_0033;\n\tv74 = val + 0xFFFFFFFFBF0BA2E9;\n\tv76 = v74 * 0x40F20000;\n\tv77 = v74 * v76;\n\tv46 = v77 + 0.75f;\n\tv78 = end - start;\n\tv42 = v78 * v46;\n\treturnVal2 = v42 + start;\n\treturn returnVal2;\nL_0033:\n\tv62 = val < 0.9090909090909091d;\n\tv50 = ~v62;\n\tif (v50) goto L_004E;\n\tv86 = val + 0xFFFFFFFFBF51745D;\n\tv88 = v86 * 0x40F20000;\n\tv89 = v86 * v88;\n\tv47 = v89 + 0.9375f;\n\tv90 = end - start;\n\tv43 = v90 * v47;\n\treturnVal3 = v43 + start;\n\treturn returnVal3;\nL_004E:\n\tv94 = val + 0xFFFFFFFFBF745D17;\n\tv97 = v94 * 0x40F20000;\n\tv98 = v94 * v97;\n\tv48 = v98 + 0x3F7C0000;\n\tv99 = end - start;\n\tv44 = v99 * v48;\n\treturnVal4 = v44 + start;\n\treturn returnVal4;\n")]
		private static float easeOutBounce(float start, float end, float val)
		{
			if (val < 0.36363637f)
			{
				float num = val * 7.5625f;
				float num2 = num * val;
				float num3 = end - start;
				float num4 = num3 * num2;
				return num4 + start;
			}
			if (val < 0.72727275f)
			{
				float num5 = val + -0.54545456f;
				float num6 = num5 * 7.5625f;
				float num7 = num5 * num6;
				float num8 = num7 + 0.75f;
				float num9 = end - start;
				float num10 = num9 * num8;
				return num10 + start;
			}
			if ((double)val < 0.9090909090909091)
			{
				float num11 = val + -0.8181818f;
				float num12 = num11 * 7.5625f;
				float num13 = num11 * num12;
				float num14 = num13 + 0.9375f;
				float num15 = end - start;
				float num16 = num15 * num14;
				return num16 + start;
			}
			float num17 = val + -21f / 22f;
			float num18 = num17 * 7.5625f;
			float num19 = num17 * num18;
			float num20 = num19 + 63f / 64f;
			float num21 = end - start;
			float num22 = num21 * num20;
			return num22 + start;
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x40213D0", Offset = "0x40213D0", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val + val;\n\tv6 = val < 0.5f;\n\tv14 = ~v6;\n\tif (v14) goto L_0022;\n\tv16 = 1f - v3;\n\tv20 = v16 < 0x3EBA2E8C;\n\tv28 = ~v20;\n\tif (v28) goto L_0038;\n\tv45 = v16 * 0x40F20000;\n\tv77 = v16 * v45;\n\tgoto L_009C;\nL_0022:\n\tv30 = v3 + -1f;\n\tv34 = v30 < 0x3EBA2E8C;\n\tv42 = ~v34;\n\tif (v42) goto L_004F;\n\tv61 = v30 * 0x40F20000;\n\tv128 = v30 * v61;\n\tgoto L_00B0;\nL_0038:\n\tv50 = v16 < 0x3F3A2E8C;\n\tv58 = ~v50;\n\tif (v58) goto L_0066;\n\tv108 = v16 + 0xFFFFFFFFBF0BA2E9;\n\tv111 = v108 * 0x40F20000;\n\tv192 = v108 * v111;\n\tv96 = 0.75f;\n\tgoto L_009B;\nL_004F:\n\tv66 = v30 < 0x3F3A2E8C;\n\tv74 = ~v66;\n\tif (v74) goto L_007D;\n\tv159 = v30 + 0xFFFFFFFFBF0BA2E9;\n\tv162 = v159 * 0x40F20000;\n\tv212 = v159 * v162;\n\tv147 = 0.75f;\n\tgoto L_00AF;\nL_0066:\n\tv117 = v16 < 0.9090909090909091d;\n\tv125 = ~v117;\n\tif (v125) goto L_0094;\n\tv200 = v16 + 0xFFFFFFFFBF51745D;\n\tv202 = v200 * 0x40F20000;\n\tv192 = v200 * v202;\n\tv96 = 0.9375f;\n\tgoto L_009B;\nL_007D:\n\tv168 = v30 < 0.9090909090909091d;\n\tv176 = ~v168;\n\tif (v176) goto L_00A8;\n\tv220 = v30 + 0xFFFFFFFFBF51745D;\n\tv222 = v220 * 0x40F20000;\n\tv212 = v220 * v222;\n\tv147 = 0.9375f;\n\tgoto L_00AF;\nL_0094:\n\tv206 = v16 + 0xFFFFFFFFBF745D17;\n\tv209 = v206 * 0x40F20000;\n\tv192 = v206 * v209;\n\tv96 = 0x3F7C0000;\nL_00A8:\n\tv226 = v30 + 0xFFFFFFFFBF745D17;\n\tv229 = v226 * 0x40F20000;\n\tv212 = v226 * v229;\n\tv147 = 0x3F7C0000;\nL_009C:\n\tv97 = v0 * v77;\n\tv100 = v0 - v97;\n\tv103 = v100 * 0.5f;\n\treturnVal1 = v103 + start;\n\treturn returnVal1;\nL_00B0:\n\tv148 = v0 * v128;\n\tv152 = v148 * 0.5f;\n\tv153 = v0 * 0.5f;\n\tv154 = v153 + v152;\n\treturnVal2 = v154 + start;\n\treturn returnVal2;\nL_009B:\n\tv77 = v192 + v96;\nL_00AF:\n\tv128 = v212 + v147;\n")]
		private static float easeInOutBounce(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + val;
			if (val < 0.5f)
			{
				float num3 = 1f - num2;
				float num5;
				if (num3 < 0.36363637f)
				{
					float num4 = num3 * 7.5625f;
					num5 = num3 * num4;
				}
				else
				{
					float num8;
					float num9;
					if (num3 < 0.72727275f)
					{
						float num6 = num3 + -0.54545456f;
						float num7 = num6 * 7.5625f;
						num8 = num6 * num7;
						num9 = 0.75f;
					}
					else if ((double)num3 < 0.9090909090909091)
					{
						float num10 = num3 + -0.8181818f;
						float num11 = num10 * 7.5625f;
						num8 = num10 * num11;
						num9 = 0.9375f;
					}
					else
					{
						float num12 = num3 + -21f / 22f;
						float num13 = num12 * 7.5625f;
						num8 = num12 * num13;
						num9 = 63f / 64f;
					}
					num5 = num8 + num9;
				}
				float num14 = num * num5;
				float num15 = num - num14;
				float num16 = num15 * 0.5f;
				return num16 + start;
			}
			float num17 = num2 + -1f;
			float num19;
			if (num17 < 0.36363637f)
			{
				float num18 = num17 * 7.5625f;
				num19 = num17 * num18;
			}
			else
			{
				float num22;
				float num23;
				if (num17 < 0.72727275f)
				{
					float num20 = num17 + -0.54545456f;
					float num21 = num20 * 7.5625f;
					num22 = num20 * num21;
					num23 = 0.75f;
				}
				else if ((double)num17 < 0.9090909090909091)
				{
					float num24 = num17 + -0.8181818f;
					float num25 = num24 * 7.5625f;
					num22 = num24 * num25;
					num23 = 0.9375f;
				}
				else
				{
					float num26 = num17 + -21f / 22f;
					float num27 = num26 * 7.5625f;
					num22 = num26 * num27;
					num23 = 63f / 64f;
				}
				num19 = num22 + num23;
			}
			float num28 = num * num19;
			float num29 = num28 * 0.5f;
			float num30 = num * 0.5f;
			float num31 = num30 + num29;
			return num31 + start;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x40215D4", Offset = "0x40215D4", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = v0 * val;\n\tv5 = v3 * val;\n\tv9 = val * 0x402CE6B0;\n\tv13 = v9 + 0xFFFFFFFFBFD9CD60;\n\tv14 = v5 * v13;\n\treturnVal1 = v14 + start;\n\treturn returnVal1;\n")]
		private static float easeInBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = num * val;
			float num3 = num2 * val;
			float num4 = val * 2.70158f;
			float num5 = num4 + -1.70158f;
			float num6 = num3 * num5;
			return num6 + start;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x402160C", Offset = "0x402160C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv4 = val + -1f;\n\tv6 = v4 * v4;\n\tv10 = v4 * 0x402CE6B0;\n\tv14 = v10 + 0x3FD9CD60;\n\tv15 = v6 * v14;\n\tv17 = v15 + 1f;\n\tv18 = v0 * v17;\n\treturnVal1 = v18 + start;\n\treturn returnVal1;\n")]
		private static float easeOutBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + -1f;
			float num3 = num2 * num2;
			float num4 = num2 * 2.70158f;
			float num5 = num4 + 1.70158f;
			float num6 = num3 * num5;
			float num7 = num6 + 1f;
			float num8 = num * num7;
			return num8 + start;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x4021654", Offset = "0x4021654", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = end - start;\n\tv3 = val + val;\n\tv6 = v3 < 1f;\n\tv15 = v3 + -2f;\n\tv17 = v0 * 0.5f;\n\tv18 = v15 * v15;\n\tv22 = v15 * 0x406612FF;\n\tv26 = v22 + 0x402612FF;\n\tv27 = v18 * v26;\n\tv29 = v27 + 2f;\n\tv30 = v17 * v29;\n\tv31 = v3 * v3;\n\tv35 = v3 * 0x406612FF;\n\tv39 = v35 + 0xFFFFFFFFC02612FF;\n\tv40 = v31 * v39;\n\tv46 = v17 * v40;\n\tv42 = ~v6;\n\tv43 = ~v42;\n\tif (v43) goto L_002E;\n\tv46 = v30;\n\tgoto L_002E;\nL_002E:\n\treturnVal1 = v46 + start;\n\treturn returnVal1;\n")]
		private static float easeInOutBack(float start, float end, float val)
		{
			float num = end - start;
			float num2 = val + val;
			bool flag = num2 < 1f;
			float num3 = num2 + -2f;
			float num4 = num * 0.5f;
			float num5 = num3 * num3;
			float num6 = num3 * 3.5949094f;
			float num7 = num6 + 2.5949094f;
			float num8 = num5 * num7;
			float num9 = num8 + 2f;
			float num10 = num4 * num9;
			float num11 = num2 * num2;
			float num12 = num2 * 3.5949094f;
			float num13 = num12 + -2.5949094f;
			float num14 = num11 * num13;
			float num15 = num4 * num14;
			if (!flag)
			{
				num15 = num10;
			}
			return num15 + start;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x40216E0", Offset = "0x40216E0", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0011;\n\treturn start;\nL_0011:\n\tv23 = end - start;\n\tv27 = val == 1f;\n\tv34 = ~v27;\n\tif (v34) goto L_0027;\n\treturnVal2 = v23 + start;\n\treturn returnVal2;\nL_0027:\n\tv87 = val + -1f;\n\tv89 = v87 * 10f;\n\tv92 = 0x8BF63A4(methodInfo, v93, v94, v95, v96, v97, v98, v99, v89, v89, val, v100, v101, v102, v103, v104);\n\tv109 = v87 + 0xFFFFFFFFBD99999A;\n\tv113 = v109 * 0xFFFFFFFFC0C90FDB;\n\tv116 = v113 / 0x3E99999A;\n\tv42 = 0x8BF749C(v92, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v116, 0x3E99999A, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv36 = v89 * v23;\n\tv61 = v36 * v116;\n\treturnVal3 = start + v61;\n\treturn returnVal3;\n")]
		private static float easeInElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			if (val == 1f)
			{
				return num + start;
			}
			float num2 = val + -1f;
			float num3 = num2 * 10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num4 = num2 + -0.075f;
			float num5 = num4 * ((float)Math.PI * -2f);
			float num6 = num5 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num7 = num3 * num;
			float num8 = num7 * num6;
			return start + num8;
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x4021790", Offset = "0x4021790", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0011;\n\treturn start;\nL_0011:\n\tv23 = end - start;\n\tv27 = val == 1f;\n\tv34 = ~v27;\n\tif (v34) goto L_0027;\n\treturnVal2 = v23 + start;\n\treturn returnVal2;\nL_0027:\n\tv87 = val * -10f;\n\tv91 = 0x8BF63A4(methodInfo, v92, v93, v94, v95, v96, v97, v98, v87, v87, val, v99, v100, v101, v102, v103);\n\tv108 = val + 0xFFFFFFFFBD99999A;\n\tv112 = v108 * 0x40C90FDB;\n\tv115 = v112 / 0x3E99999A;\n\tv42 = 0x8BF749C(v91, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v115, 0x3E99999A, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv36 = v23 * v87;\n\tv116 = v36 * v115;\n\tv61 = v23 + v116;\n\treturnVal3 = v61 + start;\n\treturn returnVal3;\n")]
		private static float easeOutElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			if (val == 1f)
			{
				return num + start;
			}
			float num2 = val * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num3 = val + -0.075f;
			float num4 = num3 * ((float)Math.PI * 2f);
			float num5 = num4 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			float num6 = num * num2;
			float num7 = num6 * num5;
			float num8 = num + num7;
			return num8 + start;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x4021840", Offset = "0x4021840", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = val == 0;\n\tv7 = ~v2;\n\tif (v7) goto L_0013;\n\treturn start;\nL_0013:\n\tv27 = end - start;\n\tv29 = val + val;\n\tv32 = v29 == 2f;\n\tv39 = ~v32;\n\tif (v39) goto L_002D;\n\treturnVal2 = v27 + start;\n\treturn returnVal2;\nL_002D:\n\tv119 = v29 + -1f;\n\tv123 = v119 + 0xFFFFFFFFBD99999A;\n\tv127 = v123 * 0x40C90FDB;\n\tv130 = v127 / 0x3E99999A;\n\tv131 = 0x8BF749C(methodInfo, v132, v133, v134, v135, v136, v137, v138, v130, 0x3E99999A, val, v139, v140, v141, v142, v143);\n\tv116 = v29 < 1f;\n\tv106 = ~v116;\n\tif (v106) goto L_005A;\n\tv149 = v119 * 10f;\n\tv42 = 0x8BF63A4(v131, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v149, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv152 = v27 * v149;\n\tv153 = v152 * v130;\n\tv75 = v153 * -0.5f;\n\treturnVal3 = start + v75;\n\treturn returnVal3;\nL_005A:\n\tv151 = v119 * -10f;\n\tv43 = 0x8BF63A4(v131, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v151, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = v27 * v151;\n\tv156 = v155 * v130;\n\tv158 = v156 * 0.5f;\n\tv76 = v27 + v158;\n\treturnVal4 = v76 + start;\n\treturn returnVal4;\n")]
		private static float easeInOutElastic(float start, float end, float val)
		{
			if (val == 0f)
			{
				return start;
			}
			float num = end - start;
			float num2 = val + val;
			if (num2 == 2f)
			{
				return num + start;
			}
			float num3 = num2 + -1f;
			float num4 = num3 + -0.075f;
			float num5 = num4 * ((float)Math.PI * 2f);
			float num6 = num5 / 0.3f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF749C");
			if (num2 < 1f)
			{
				float num7 = num3 * 10f;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
				float num8 = num * num7;
				float num9 = num8 * num6;
				float num10 = num9 * -0.5f;
				return start + num10;
			}
			float num11 = num3 * -10f;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF63A4");
			float num12 = num * num11;
			float num13 = num12 * num6;
			float num14 = num13 * 0.5f;
			float num15 = num + num14;
			return num15 + start;
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x4021948", Offset = "0x4021948", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv73 = new EnhancedUI.SmallList`1<System.Single>();\n\tEnhancedUI.SmallList`1<System.Single>::.ctor(v73);\n\tthis._cellViewSizeArray = v73;\n\tv80 = new EnhancedUI.SmallList`1<System.Single>();\n\tEnhancedUI.SmallList`1<System.Single>::.ctor(v80);\n\tthis._cellViewOffsetArray = v80;\n\tv87 = new EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>();\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::.ctor(v87);\n\tthis._activeCellViews = v87;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_0028:\n\tthis.loopWhileDragging = 1;\n\tv57 = new EnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>();\n\tEnhancedUI.SmallList`1<EnhancedUI.EnhancedScroller.EnhancedScrollerCellView>::.ctor(v57);\n\tthis._recycledCellViews = v57;\n")]
		public EnhancedScroller()
		{
			loopWhileDragging = true;
			SmallList<EnhancedScrollerCellView> recycledCellViews = new SmallList<EnhancedScrollerCellView>();
			_recycledCellViews = recycledCellViews;
			SmallList<float> cellViewSizeArray = new SmallList<float>();
			_cellViewSizeArray = cellViewSizeArray;
			SmallList<float> cellViewOffsetArray = new SmallList<float>();
			_cellViewOffsetArray = cellViewOffsetArray;
			SmallList<EnhancedScrollerCellView> activeCellViews = new SmallList<EnhancedScrollerCellView>();
			_activeCellViews = activeCellViews;
		}
	}
}
