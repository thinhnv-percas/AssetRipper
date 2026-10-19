using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace HighlightPlus
{
	[RequireComponent(typeof(HighlightEffect))]
	[DefaultExecutionOrder(100)]
	[HelpURL("https://kronnect.com/docs/highlight-plus/")]
	[Token(Token = "0x200002D")]
	public class HighlightManager : MonoBehaviour
	{
		[Tooltip("Enables highlight when pointer is over this object.")]
		[SerializeField]
		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x20")]
		private bool _highlightOnHover = true;

		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x24")]
		public LayerMask layerMask;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0x28")]
		public Camera raycastCamera;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0x30")]
		public RayCastSource raycastSource;

		[Tooltip("Objects in this layer mask will block the highlight if they are between the camera and the target.")]
		[Token(Token = "0x4000212")]
		[FieldOffset(Offset = "0x34")]
		public LayerMask blockingLayerMask;

		[Tooltip("Minimum distance for target.")]
		[Token(Token = "0x4000213")]
		[FieldOffset(Offset = "0x38")]
		public float minDistance;

		[Tooltip("Maximum distance for target. 0 = infinity")]
		[Token(Token = "0x4000214")]
		[FieldOffset(Offset = "0x3C")]
		public float maxDistance;

		[Tooltip("Blocks interaction if pointer is over an UI element")]
		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0x40")]
		public bool respectUI;

		[Tooltip("Unhighlights the object when the pointer is over a UI element")]
		[Token(Token = "0x4000216")]
		[FieldOffset(Offset = "0x41")]
		public bool unhighlightOnUI;

		[Tooltip("If the object will be selected by clicking with mouse or tapping on it.")]
		[Token(Token = "0x4000217")]
		[FieldOffset(Offset = "0x42")]
		public bool selectOnClick;

		[Tooltip("Optional profile for objects selected by clicking on them")]
		[Token(Token = "0x4000218")]
		[FieldOffset(Offset = "0x48")]
		public HighlightProfile selectedProfile;

		[Tooltip("Profile to use when object is selected and highlighted.")]
		[Token(Token = "0x4000219")]
		[FieldOffset(Offset = "0x50")]
		public HighlightProfile selectedAndHighlightedProfile;

		[Tooltip("Automatically deselects other previously selected objects")]
		[Token(Token = "0x400021A")]
		[FieldOffset(Offset = "0x58")]
		public bool singleSelection;

		[Tooltip("Toggles selection on/off when clicking object")]
		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x59")]
		public bool toggle;

		[Tooltip("Keeps current selection when clicking outside of any selectable object")]
		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x5A")]
		public bool keepSelection;

		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x60")]
		private HighlightEffect baseEffect;

		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x68")]
		private HighlightEffect currentEffect;

		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x70")]
		private Transform currentObject;

		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x78")]
		private RaycastHit2D[] hitInfo2D;

		[Token(Token = "0x4000221")]
		private static RaycastHit blockingHit;

		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x80")]
		private readonly List<RaycastResult> cachedRaycastResults;

		[Token(Token = "0x4000223")]
		[FieldOffset(Offset = "0x88")]
		private PointerEventData cachedPointerEventData;

		[Token(Token = "0x4000224")]
		[FieldOffset(Offset = "0x90")]
		private EventSystem cachedEventSystem;

		[Token(Token = "0x4000225")]
		public static readonly List<HighlightEffect> selectedObjects;

		[CompilerGenerated]
		[Token(Token = "0x4000226")]
		[FieldOffset(Offset = "0x98")]
		private OnObjectSelectionEvent OnObjectSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000227")]
		[FieldOffset(Offset = "0xA0")]
		private OnObjectSelectionEvent OnObjectUnSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0xA8")]
		private OnObjectHighlightEvent OnObjectHighlightStart;

		[CompilerGenerated]
		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0xB0")]
		private OnObjectHighlightEvent OnObjectHighlightStay;

		[CompilerGenerated]
		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0xB8")]
		private OnObjectHighlightEvent OnObjectHighlightEnd;

		[CompilerGenerated]
		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0xC0")]
		private OnObjectClickEvent OnObjectClicked;

		[Token(Token = "0x400022C")]
		public static int lastTriggerFrame;

		[Token(Token = "0x400022D")]
		private static HighlightManager _instance;

		[Token(Token = "0x1700000C")]
		public bool highlightOnHover
		{
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x77289C0", Offset = "0x77289C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.highlightOnHover;\n")]
			get
			{
				return _highlightOnHover;
			}
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x77289C8", Offset = "0x77289C8", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tthis.highlightOnHover = value;\n\tv54 = value == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_004C;\n\tgoto L_002F;\nL_002F:\n\tv64 = UnityEngine.Object::op_Inequality(this.currentEffect, 0);\n\tv67 = ~v64;\n\tif (v67) goto L_004C;\n\tHighlightPlus.HighlightManager::Highlight(this, 0);\n\treturn;\nL_004C:\n\treturn;\nL_001A:\n\tv48 = this.highlightOnHover == value;\n\tif (v48) goto L_004C;\n")]
			set
			{
				if (highlightOnHover != value)
				{
					_highlightOnHover = value;
					if (!value && currentEffect != null)
					{
						Highlight(state: false);
					}
				}
			}
		}

		[Token(Token = "0x1700000D")]
		public static HighlightManager instance
		{
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x772953C", Offset = "0x772953C", Length = "0x184")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tv45 = 0xB292000 + 0x5A0;\n\tgoto L_0017;\nL_0017:\n\tv53 = *([v45 @ X21_v12 (System.Int32)]);\n\tv55 = *([v53 @ X0_v48+E4]) == 0;\n\tif (v55) goto L_0052;\n\tv76 = UnityEngine.Object::op_Equality(v51._instance, 0);\n\tv89 = ~v76;\n\tv90 = ~v89;\n\tif (v90) goto L_005D;\nL_0025:\n\tgoto L_002F;\nL_002F:\n\treturn v139._instance;\nL_0052:\n\tv94 = UnityEngine.Object::op_Equality(v51._instance, 0);\n\tv103 = ~v94;\n\tif (v103) goto L_0025;\nL_005D:\n\tgoto L_0061;\nL_0061:\n\tv159 = HighlightPlus.Misc::FindObjectOfType(0);\n\tgoto L_006C;\nL_006C:\n\tv187._instance = v159;\n\tgoto L_002F;\n")]
			get
			{
				//IL_0021: Expected O, but got I4
				int num = 187244544 + 1440;
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X0_v48+E4]");
				if ((nint)0 != 0)
				{
					if (!(_instance == null))
					{
						goto IL_007e;
					}
				}
				else if (!(_instance == null))
				{
					goto IL_007e;
				}
				HighlightManager highlightManager = Misc.FindObjectOfType<HighlightManager>();
				_instance = highlightManager;
				goto IL_007e;
				IL_007e:
				return _instance;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x7728D8C", Offset = "0x7728D8C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectSelected;\n\tgoto L_002C;\n")]
		public void add_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x7728E30", Offset = "0x7728E30", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectSelected;\n\tgoto L_002C;\n")]
		public void remove_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x7728ED4", Offset = "0x7728ED4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectUnSelected;\n\tgoto L_002C;\n")]
		public void add_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x7728F78", Offset = "0x7728F78", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectUnSelected;\n\tgoto L_002C;\n")]
		public void remove_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x772901C", Offset = "0x772901C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStart;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x77290C0", Offset = "0x77290C0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStart;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x7729164", Offset = "0x7729164", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStay (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStay;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightStay(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStay;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStay, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x7729208", Offset = "0x7729208", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStay (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightStay;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightStay(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStay;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStay, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x77292AC", Offset = "0x77292AC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightEnd;\n\tgoto L_002C;\n")]
		public void add_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x7729350", Offset = "0x7729350", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectHighlightEnd;\n\tgoto L_002C;\n")]
		public void remove_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x77293F4", Offset = "0x77293F4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectClicked (HighlightPlus.OnObjectClickEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectClickEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectClicked;\n\tgoto L_002C;\n")]
		public void add_OnObjectClicked(OnObjectClickEvent value)
		{
			OnObjectClickEvent onObjectClickEvent = OnObjectClicked;
			OnObjectClickEvent onObjectClickEvent2;
			do
			{
				onObjectClickEvent2 = onObjectClickEvent;
				OnObjectClickEvent value2 = (OnObjectClickEvent)Delegate.Combine(onObjectClickEvent2, value);
				onObjectClickEvent = Interlocked.CompareExchange(ref OnObjectClicked, value2, onObjectClickEvent2);
			}
			while ((object)onObjectClickEvent != onObjectClickEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x7729498", Offset = "0x7729498", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnObjectClicked (HighlightPlus.OnObjectClickEvent), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectClickEvent;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnObjectClicked;\n\tgoto L_002C;\n")]
		public void remove_OnObjectClicked(OnObjectClickEvent value)
		{
			OnObjectClickEvent onObjectClickEvent = OnObjectClicked;
			OnObjectClickEvent onObjectClickEvent2;
			do
			{
				onObjectClickEvent2 = onObjectClickEvent;
				OnObjectClickEvent value2 = (OnObjectClickEvent)Delegate.Remove(onObjectClickEvent2, value);
				onObjectClickEvent = Interlocked.CompareExchange(ref OnObjectClicked, value2, onObjectClickEvent2);
			}
			while ((object)onObjectClickEvent != onObjectClickEvent2);
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x60000CC")]
		[Address(RVA = "0x77296C0", Offset = "0x77296C0", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0012;\nL_0012:\n\tv57 = v43.selectedObjects;\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Clear(v57);\n\tv72 = v57.Count < 1;\n\tif (v72) goto L_002D;\nL_002D:\n\tv86._instance = 0;\n\tv86.lastTriggerFrame = 0;\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void DomainReloadDisabledSupport()
		{
			List<HighlightEffect> list = selectedObjects;
			list.Clear();
			if (list.Count >= 1)
			{
			}
			_instance = null;
			lastTriggerFrame = 0;
		}

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x7729780", Offset = "0x7729780", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_003E:\n\tv75 = UnityEngine.Object::op_Equality(*([v64 @ X20_v3 (HighlightPlus.HighlightEffect&)]), 0);\n\tv80 = ~v75;\n\tv81 = ~v80;\n\tif (v81) goto L_004F;\n\tgoto L_0068;\nL_004F:\n\tv99 = UnityEngine.Component::TryGetComponent(this, &this.baseEffect (HighlightPlus.HighlightEffect));\n\tv120 = v99 == 0;\n\tv109 = ~v120;\n\tif (v109) goto L_0068;\n\tv131 = UnityEngine.Component::get_gameObject(this);\n\tv165 = UnityEngine.GameObject::AddComponent(v131);\n\t*([v64 @ X20_v3 (HighlightPlus.HighlightEffect&)]) = v165;\nL_0068:\n\tgoto L_006F;\nL_006F:\n\tv128 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv132 = ~v128;\n\tif (v132) goto L_00A2;\n\tgoto L_007A;\nL_007A:\n\tv169 = HighlightPlus.HighlightManager::GetCamera();\n\tthis.raycastCamera = v169;\n\tgoto L_0087;\nL_0087:\n\tv149 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv203 = ~v149;\n\tv153 = ~v203;\n\tif (v153) goto L_0099;\n\tgoto L_00A2;\nL_0099:\n\tgoto L_009F;\nL_009F:\n\tUnityEngine.Debug::LogError(\"Highlight Manager: no camera found!\");\nL_00A2:\n\t// 162 NewArr v162 @ X0_v16 (UnityEngine.RaycastHit2D[]), typeof(UnityEngine.RaycastHit2D[]), 1\n\tthis.hitInfo2D = v162;\n\treturn;\nL_002C:\n\tthis.currentObject = 0;\n\tthis.currentEffect = 0;\n\tv64 = &this.baseEffect (HighlightPlus.HighlightEffect);\n\tgoto L_003E;\n")]
		private void OnEnable()
		{
			currentObject = null;
			currentEffect = null;
			ref HighlightEffect reference = ref baseEffect;
			if (reference == null && !TryGetComponent<HighlightEffect>(out baseEffect))
			{
				GameObject gameObject = base.gameObject;
				HighlightEffect highlightEffect = gameObject.AddComponent<HighlightEffect>();
				reference = highlightEffect;
			}
			if (raycastCamera == null)
			{
				Camera camera = GetCamera();
				raycastCamera = camera;
				if (raycastCamera == null)
				{
					Debug.LogError("Highlight Manager: no camera found!");
				}
			}
			RaycastHit2D[] array = new RaycastHit2D[1];
			hitInfo2D = array;
		}

		[Token(Token = "0x60000CE")]
		[Address(RVA = "0x7729AB8", Offset = "0x7729AB8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightManager::SwitchesObject(this, 0);\n\tHighlightPlus.HighlightManager::internal_DeselectAll(this);\n\treturn;\n")]
		private void OnDisable()
		{
			SwitchesObject(null);
			internal_DeselectAll();
		}

		[Token(Token = "0x60000CF")]
		[Address(RVA = "0x772A03C", Offset = "0x772A03C", Length = "0x894")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\nL_003C:\n\tv80 = UnityEngine.Object::op_Equality(this.raycastCamera, 0);\n\tv86 = v80 == 0;\n\tif (v86) goto L_004B;\n\tgoto L_027A;\nL_004B:\n\tv100 = this.raycastSource == 0;\n\tif (v100) goto L_00BA;\n\tv515 = UnityEngine.Camera::get_pixelWidth(this.raycastCamera);\n\tv734 = UnityEngine.Camera::get_pixelHeight(this.raycastCamera);\n\t// 91 MakeStruct v735 @ AGG772A154_1_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v515 @ X0_v141 (System.Int32), v734 @ X0_v143 (System.Int32)\n\tv738 = HighlightPlus.HighlightManager::CanInteractAt(this, v735);\n\tv739 = v738 == 0;\n\tif (v739) goto L_00CE;\nL_0064:\n\tv744 = this.raycastSource == 0;\n\tif (v744) goto L_00DD;\n\tv669 = UnityEngine.Component::get_transform(this.raycastCamera);\n\tv641 = UnityEngine.Transform::get_position(v669);\n\tv671 = UnityEngine.Component::get_transform(this.raycastCamera);\n\tv842 = UnityEngine.Transform::get_forward(v671);\n\tgoto L_0091;\nL_0093:\n\tv880 = v842 * v842;\n\tv881 = v842.y * v842.y;\n\tv882 = v880 + v881;\n\tv883 = v842.z * v842.z;\n\tv884 = v883 + v882;\n\tv885 = UnityEngine.Mathf::Sqrt(v884);\n\tv893 = v885 < 0x3727C5AC;\n\tv894 = v885 == 0x3727C5AC;\n\tv897 = v885 == v885;\n\tv899 = ~v897;\n\tv900 = v893 == v899;\n\tv901 = ~v900;\n\tv902 = v901 | v894;\n\tif (v902) goto L_0108;\n\tHighlightPlus.HighlightManager::VerifyHighlightStay(this);\n\tv835 = this.maxDistance;\n\tv800 = this.maxDistance < 0;\n\tv798 = this.maxDistance == 0;\n\tv794 = this.maxDistance == this.maxDistance;\n\tv791 = ~v794;\n\tv938 = v800 == v791;\n\tv939 = ~v938;\n\tv789 = v939 | v798;\n\tv614 = v641.z;\n\tv617 = v641.y;\n\tv620 = v641;\n\tif (v789) goto L_0124;\n\tv287 = v641.z;\n\tv290 = v641.y;\n\tv294 = v641;\n\tgoto L_0125;\nL_00BA:\n\tv396 = UnityEngine.Input::get_mousePosition();\n\t// 190 MakeStruct v723 @ AGG772A24C_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v396 @ V0_v6 (UnityEngine.Vector3), v396.y (System.Single)\n\tv724 = HighlightPlus.HighlightManager::CanInteractAt(this, v723);\n\tv731 = v724 == 0;\n\tv732 = ~v731;\n\tif (v732) goto L_0064;\nL_00CE:\n\tv213 = this.unhighlightOnUI != 1;\n\tif (v213) goto L_027A;\n\tgoto L_00D8;\nL_00D8:\n\tv345 = UnityEngine.Object::op_Inequality(this.currentEffect, 0);\n\tv355 = ~v345;\n\tif (v355) goto L_027A;\n\tgoto L_0282;\nL_00DD:\n\tv642 = UnityEngine.Input::get_mousePosition();\n\tv757 = UnityEngine.Camera::ScreenPointToRay(this.raycastCamera, v642);\n\tv758 = v757.origin;\n\tHighlightPlus.HighlightManager::VerifyHighlightStay(this);\n\tv835 = this.maxDistance;\n\tv774 = this.maxDistance < 0;\n\tv775 = this.maxDistance == 0;\n\tv778 = this.maxDistance == this.maxDistance;\n\tv779 = ~v778;\n\tv780 = v774 == v779;\n\tv781 = ~v780;\n\tv782 = v781 | v775;\n\tv614 = v757.m_Origin.z;\n\tv617 = v757.m_Origin.y;\n\tv620 = v757.origin;\n\tif (v782) goto L_0124;\n\tv287 = v757.m_Origin.z;\n\tv290 = v757.m_Origin.y;\n\tv294 = v757.origin;\n\tgoto L_0125;\nL_0108:\n\tgoto L_0114;\nL_0124:\n\tv835 = UnityEngine.Camera::get_farClipPlane(this.raycastCamera);\n\tv287 = v614;\n\tv290 = v617;\n\tv294 = v620;\nL_0125:\n\tv758 = v294;\n\tv644 = HighlightPlus.HighlightManager::GetBlockingDistance(this, &v758 @ stack_-D0_v9 (UnityEngine.Vector3), v835);\n\tv852 = this.maxDistance;\n\tv595 = this.maxDistance < 0;\n\tv589 = this.maxDistance == 0;\n\tv577 = this.maxDistance == this.maxDistance;\n\tv565 = ~v577;\n\tv844 = v595 == v565;\n\tv151 = ~v589;\n\tv559 = v844 & v151;\n\tif (v559) goto L_0142;\n\tv855 = UnityEngine.Camera::get_farClipPlane(this.raycastCamera);\n\tv852 = v855;\nL_014C:\n\tv758 = v294;\n\tv891 = UnityEngine.Physics::Raycast(&v758 @ stack_-D0_v9 (UnityEngine.Vector3), &v67 @ stack_-B0_v1 (UnityEngine.RaycastHit), v852, v862);\n\tv903 = ~v891;\n\tv146 = v644;\n\tif (v903) goto L_01A1;\n\tv913 = UnityEngine.RaycastHit::get_point(&v67 @ stack_-B0_v1 (UnityEngine.RaycastHit));\n\tgoto L_0176;\nL_0178:\n\tv982 = v913.z - v287;\n\tv983 = v913.y - v290;\n\tv984 = v913 - v294;\n\tv300 = v984 * v984;\n\tv985 = v983 * v983;\n\tv986 = v300 + v985;\n\tv987 = v982 * v982;\n\tv988 = v987 + v986;\n\tv928 = UnityEngine.Mathf::Sqrt(v988);\n\tv926 = v928 < this.minDistance;\n\tv993 = v928 == v928;\n\tv918 = this.minDistance == this.minDistance;\n\tv920 = v993 & v918;\n\tv917 = ~v920;\n\tv994 = v926 == v917;\n\tv915 = ~v994;\n\tv146 = v644;\n\tif (v915) goto L_01A1;\n\tv320 = UnityEngine.RaycastHit::get_distance(&v67 @ stack_-B0_v1 (UnityEngine.RaycastHit));\n\tv261 = v320 == v644;\n\tv1023 = v320 < v644;\n\tv252 = ~v1023;\n\tv1025 = ~v252;\n\tv216 = v1025 | v261;\n\tv146 = v644;\n\tif (v216) goto L_02E1;\nL_01A1:\n\tv607 = this.maxDistance;\n\tv596 = this.maxDistance < 0;\n\tv590 = this.maxDistance == 0;\n\tv578 = this.maxDistance == this.maxDistance;\n\tv566 = ~v578;\n\tv936 = v596 == v566;\n\tv149 = ~v590;\n\tv560 = v936 & v149;\n\tif (v560) goto L_01B4;\n\tv957 = UnityEngine.Camera::get_farClipPlane(this.raycastCamera);\n\tv607 = v957;\nL_01BE:\n\tv758 = v294;\n\tv676 = UnityEngine.Physics2D::GetRayIntersectionNonAlloc(&v758 @ stack_-D0_v9 (UnityEngine.Vector3), this.hitInfo2D, v607, v964);\n\tv561 = v676 < 1;\n\tif (v561) goto L_0240;\n\tv1050 = this.hitInfo2D + 0x20;\n\tv1051 = UnityEngine.RaycastHit2D::get_point(v1050);\n\tgoto L_01F0;\nL_01F3:\n\tv1073 = 0 - v287;\n\tv1074 = v1051.y - v290;\n\tv1075 = v1051 - v294;\n\tv299 = v1075 * v1075;\n\tv1076 = v1074 * v1074;\n\tv1077 = v299 + v1076;\n\tv206 = v1073 * v1073;\n\tv1078 = v206 + v1077;\n\tv647 = UnityEngine.Mathf::Sqrt(v1078);\n\tv598 = v647 < this.minDistance;\n\tv1085 = v647 == v647;\n\tv574 = this.minDistance == this.minDistance;\n\tv580 = v1085 & v574;\n\tv568 = ~v580;\n\tv1086 = v598 == v568;\n\tv562 = ~v1086;\n\tif (v562) goto L_0240;\n\tv1094 = this.hitInfo2D + 0x20;\n\tv1095 = UnityEngine.RaycastHit2D::get_point(v1094);\n\tgoto L_0222;\nL_0224:\n\tv1158 = v1095.y - v290;\n\tv1159 = v1095 - v294;\n\tv312 = v1159 * v1159;\n\tv1160 = v1158 * v1158;\n\tv1161 = v312 + v1160;\n\tv1162 = v206 + v1161;\n\tv319 = UnityEngine.Mathf::Sqrt(v1162);\n\tv260 = v319 == v146;\n\tv1165 = v319 < v146;\n\tv251 = ~v1165;\n\tv1167 = ~v251;\n\tv215 = v1167 | v260;\n\tif (v215) goto L_02AC;\nL_0240:\n\tv1022 = this.selectOnClick != 1;\n\tif (v1022) goto L_0268;\n\tv1028 = this.keepSelection == 0;\n\tv1029 = ~v1028;\n\tif (v1029) goto L_0268;\n\tv1043 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv1046 = ~v1043;\n\tif (v1046) goto L_0268;\n\tgoto L_0258;\n\tHighlightPlus.HighlightManager::internal_DeselectAll(this);\nL_0268:\n\tHighlightPlus.HighlightManager::SwitchesObject(this, 0);\nL_027A:\n\treturn;\nL_0282:\n\tv347 = this.currentEffect;\n\tv214 = v347.highlighted != 1;\n\tif (v214) goto L_027A;\n\tHighlightPlus.HighlightEffect::SetHighlighted(v347, 0);\n\treturn;\nL_02AC:\n\tv1168 = this.hitInfo2D + 0x20;\n\tv679 = UnityEngine.RaycastHit2D::get_collider(v1168);\n\tv680 = UnityEngine.Component::get_transform(v679);\n\tv348 = UnityEngine.Component::TryGetComponent(v680, &v69 @ stack_-B8_v1 (HighlightPlus.HighlightTrigger));\n\tv1171 = v348 == 0;\n\tv358 = ~v1171;\n\tif (v358) goto L_027A;\n\tv1174 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv1175 = ~v1174;\n\tif (v1175) goto L_0317;\n\tv1186 = this.selectOnClick != 1;\n\tif (v1186) goto L_0328;\n\tv1197 = this.toggle == 0;\n\tHighlightPlus.HighlightManager::ToggleSelection(this, v680, v1197);\n\tgoto L_0328;\nL_02E1:\n\tv681 = UnityEngine.RaycastHit::get_collider(&v67 @ stack_-B0_v1 (UnityEngine.RaycastHit));\n\tv682 = UnityEngine.Component::get_transform(v681);\n\tv349 = UnityEngine.Component::TryGetComponent(v682, &v69 @ stack_-B8_v1 (HighlightPlus.HighlightTrigger));\n\tv1089 = v349 == 0;\n\tv359 = ~v1089;\n\tif (v359) goto L_027A;\n\tv1092 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv1093 = ~v1092;\n\tif (v1093) goto L_0349;\n\tv1106 = this.selectOnClick != 1;\n\tif (v1106) goto L_0356;\n\tv1122 = this.toggle == 0;\n\tHighlightPlus.HighlightManager::ToggleSelection(this, v682, v1122);\n\tgoto L_0356;\nL_0317:\n\tgoto L_031C;\nL_031C:\n\tv1209 = UnityEngine.Object::op_Inequality(v680, this.currentObject);\n\tv1211 = ~v1209;\n\tif (v1211) goto L_0328;\n\tHighlightPlus.HighlightManager::SwitchesObject(this, v680);\nL_0328:\n\tv1216 = this.hitInfo2D + 0x20;\n\tv321 = UnityEngine.RaycastHit2D::get_point(v1216);\n\tgoto L_0340;\nL_0349:\n\tgoto L_034E;\nL_034E:\n\tv1136 = UnityEngine.Object::op_Inequality(v682, this.currentObject);\n\tv1137 = ~v1136;\n\tif (v1137) goto L_0356;\n\tHighlightPlus.HighlightManager::SwitchesObject(this, v682);\nL_0356:\n\tv1140 = UnityEngine.RaycastHit::get_point(&v67 @ stack_-B0_v1 (UnityEngine.RaycastHit))\n// ... truncated")]
		private unsafe void Update()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::Update");
		}

		[Token(Token = "0x60000D0")]
		[Address(RVA = "0x772AAF4", Offset = "0x772AAF4", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Equality(this.currentObject, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0035;\n\tgoto L_006D;\nL_0035:\n\tgoto L_0039;\nL_0039:\n\tv121 = UnityEngine.Object::op_Equality(this.currentEffect, 0);\n\tv126 = v121 == 0;\n\tif (v126) goto L_0047;\n\tgoto L_006D;\nL_0047:\n\tv187 = this.currentEffect;\n\tv83 = v187.highlighted != 1;\n\tif (v83) goto L_006D;\n\tv129 = this.OnObjectHighlightStay == 0;\n\tif (v129) goto L_006D;\n\tv195 = UnityEngine.Component::get_gameObject(this.currentObject);\n\tv120 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightStay, v195);\n\tv197 = v120 & 1;\n\tv125 = v197 == 0;\n\tif (v125) goto L_0077;\nL_006D:\n\treturn;\nL_0077:\n\tHighlightPlus.HighlightManager::SwitchesObject(this, 0);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void VerifyHighlightStay()
		{
			//IL_00e5: Expected O, but got I4
			if (currentObject == null || currentEffect == null)
			{
				return;
			}
			HighlightEffect highlightEffect = currentEffect;
			if (highlightEffect.highlighted && OnObjectHighlightStay != null)
			{
				GameObject obj = currentObject.gameObject;
				object obj2 = OnObjectHighlightStay(obj);
				if ((int)((nint)obj2 & 1) == 0)
				{
					SwitchesObject(null);
				}
			}
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x7729AE0", Offset = "0x7729AE0", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tv143 = this + 0x68;\n\tgoto L_001F;\nL_001F:\n\tv70 = UnityEngine.Object::op_Inequality(this.currentEffect, 0);\n\tv82 = ~v70;\n\tv83 = ~v82;\n\tif (v83) goto L_004D;\n\tgoto L_0058;\nL_004D:\n\tv111 = this.highlightOnHover != 1;\n\tif (v111) goto L_0052;\n\tHighlightPlus.HighlightManager::Highlight(this, 0);\nL_0052:\n\t*([v143 @ X20_v2]) = 0;\nL_0058:\n\tthis.currentObject = newObject;\n\tgoto L_0062;\nL_0062:\n\tv162 = UnityEngine.Object::op_Equality(newObject, 0);\n\tv165 = v162 == 0;\n\tif (v165) goto L_0080;\nL_006F:\n\treturn;\nL_0080:\n\tv312 = UnityEngine.Component::TryGetComponent(newObject, &v210 @ stack_-48_v3 (HighlightPlus.HighlightTrigger));\n\tv337 = ~v312;\n\tif (v337) goto L_0091;\n\tv203 = UnityEngine.Behaviour::get_enabled(v210);\n\tv351 = v203 == 0;\n\tv215 = ~v351;\n\tif (v215) goto L_006F;\nL_0091:\n\tv346 = UnityEngine.Component::TryGetComponent(newObject, &v212 @ stack_-50_v3 (HighlightPlus.HighlightEffect));\n\tv348 = v346 == 0;\n\tv349 = ~v348;\n\tif (v349) goto L_00C5;\n\tv356 = UnityEngine.Component::GetComponentInParent(newObject);\n\tgoto L_00A3;\nL_00A3:\n\tv365 = UnityEngine.Object::op_Inequality(v356, 0);\n\tv391 = ~v365;\n\tv370 = ~v391;\n\tif (v370) goto L_00B4;\n\tgoto L_00C5;\nL_00B4:\n\tv367 = HighlightPlus.HighlightEffect::Includes(v356, newObject);\n\tv372 = ~v367;\n\tif (v372) goto L_00C5;\n\tthis.currentEffect = v356;\n\tv216 = this.highlightOnHover == 0;\n\tif (v216) goto L_006F;\n\tgoto L_0107;\nL_00C5:\n\tgoto L_00CA;\nL_00CA:\n\tv386 = UnityEngine.Object::op_Inequality(v212, 0);\n\tv396 = this + 0x60;\n\tv318 = v386 == 0;\n\tv313 = ~v318;\n\tv172 = ~v313;\n\tif (v172) goto L_00DE;\n\tv396 = &v212 @ stack_-50_v3 (HighlightPlus.HighlightEffect);\n\tgoto L_00DE;\nL_00EC:\n\tv331 = UnityEngine.Object::op_Equality(this.currentEffect, this.baseEffect);\n\tUnityEngine.Behaviour::set_enabled(this.baseEffect, v331);\n\tHighlightPlus.HighlightEffect::SetTarget(*([v143 @ X20_v2]), this.currentObject);\n\tv177 = this.highlightOnHover != 1;\n\tif (v177) goto L_006F;\nL_0107:\n\tHighlightPlus.HighlightManager::Highlight(this, 1);\n\treturn;\nL_00DE:\n\tthis.currentEffect = this.baseEffect;\n\tgoto L_00EC;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SwitchesObject(Transform newObject)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::SwitchesObject");
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x772B398", Offset = "0x772B398", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tgoto L_002B;\nL_002B:\n\tv78 = UnityEngine.Object::op_Equality(this.currentEffect, 0);\n\tv88 = v78 == 0;\n\tif (v88) goto L_004F;\n\tgoto L_00B1;\nL_004F:\n\tv133 = UnityEngine.Transform::InverseTransformPoint(target, positionWS);\n\tgoto L_007A;\nL_007A:\n\t// 122 MakeStruct v110 @ AGG772B508_2_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v133 @ V0_v5 (UnityEngine.Vector3), v133.y (System.Single), v133.z (System.Single)\n\t// 123 MakeStruct v107 @ AGG772B508_3_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v146.vector3Zero (UnityEngine.Vector3), v146.vector3Zero.y (System.Single), v146.vector3Zero.z (System.Single)\n\tHighlightPlus.HighlightEffect::SetHitPosition(this.currentEffect, target, v110, v107, normalWS);\n\tv139 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv141 = ~v139;\n\tif (v141) goto L_00B1;\n\tv150 = this.OnObjectClicked;\n\tv142 = this.OnObjectClicked == 0;\n\tif (v142) goto L_00B1;\n\tv302 = UnityEngine.Component::get_gameObject(target);\n\tHighlightPlus.OnObjectClickEvent::Invoke(this.OnObjectClicked, v302, v150.method, v150.invoke_impl);\n\treturn;\nL_00B1:\n\treturn;\n")]
		private void UpdateHitPosition(Transform target, Vector3 positionWS, Vector3 normalWS)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::UpdateHitPosition");
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x772A8D8", Offset = "0x772A8D8", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tgoto L_0034;\nL_0034:\n\tv195 = UnityEngine.EventSystems.EventSystem::get_current();\n\tgoto L_003D;\nL_003D:\n\tv167 = UnityEngine.Object::op_Equality(v195, 0);\n\tv171 = v167 == 0;\n\tif (v171) goto L_0063;\n\tgoto L_005D;\nL_005D:\n\treturn 1;\nL_0063:\n\tgoto L_0065;\nL_0065:\n\tv379 = UnityEngine.Application::get_isMobilePlatform();\n\tv381 = ~v379;\n\tv382 = ~v381;\n\tif (v382) goto L_0070;\n\tgoto L_00B4;\nL_0070:\n\tv389 = UnityEngine.Input::get_touchCount();\n\tv270 = v389 < 1;\n\tif (v270) goto L_00B4;\n\tv453 = UnityEngine.Input::GetTouch(0);\n\tv75 = v453;\n\tv460 = UnityEngine.Touch::get_fingerId(&v75 @ stack_-90_v5 (UnityEngine.Touch));\n\tv168 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v195, v460);\n\tv172 = v168 == 0;\n\tif (v172) goto L_00D8;\n\treturn 0;\nL_00B4:\n\tv402 = this.raycastSource == 0;\n\tif (v402) goto L_00C2;\nL_00BB:\n\tv465 = HighlightPlus.HighlightManager::IsUIAtScreenPosition(this, v195, screenPosition);\n\tgoto L_00C3;\nL_00C2:\n\tv465 = UnityEngine.EventSystems.EventSystem::IsPointerOverGameObject(v195, -1);\nL_00C3:\n\treturnVal2 = v465 ^ 1;\n\treturn returnVal2;\nL_00D8:\n\tv139 = this.raycastSource != 1;\n\tif (v139) goto L_005D;\n\tgoto L_00BB;\nL_0029:\n\tv59 = this.respectUI != 1;\n\tif (v59) goto L_005D;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool CanInteractAt(Vector2 screenPosition)
		{
			EventSystem current;
			bool flag;
			if (respectUI)
			{
				current = EventSystem.current;
				if (!(current == null))
				{
					if (Application.isMobilePlatform)
					{
						int touchCount = Input.touchCount;
						if (touchCount >= 1)
						{
							Touch touch = Input.GetTouch(0);
							Touch touch2 = touch;
							int fingerId = touch2.fingerId;
							if (current.IsPointerOverGameObject(fingerId))
							{
								return false;
							}
							if (raycastSource != RayCastSource.CameraDirection)
							{
								goto IL_0049;
							}
							goto IL_0127;
						}
					}
					if (raycastSource != RayCastSource.MousePosition)
					{
						goto IL_0127;
					}
					flag = current.IsPointerOverGameObject(-1);
					goto IL_0155;
				}
			}
			goto IL_0049;
			IL_0049:
			return true;
			IL_0155:
			return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			IL_0127:
			flag = IsUIAtScreenPosition(current, screenPosition);
			goto IL_0155;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x772B5FC", Offset = "0x772B5FC", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::Clear(v54);\n\tv72 = v54.Count < 1;\n\tif (v72) goto L_0046;\nL_0046:\n\tv229 = this.cachedPointerEventData == 0;\n\tif (v229) goto L_0065;\n\tgoto L_0052;\nL_0052:\n\tv246 = UnityEngine.Object::op_Inequality(this.cachedEventSystem, es);\n\tv359 = ~v246;\n\tv249 = ~v359;\n\tif (v249) goto L_0065;\n\tv157 = this.cachedPointerEventData;\n\tv366 = this.cachedPointerEventData == 0;\n\tv202 = ~v366;\n\tif (v202) goto L_0076;\n\tgoto L_00F7;\nL_0065:\n\tv253 = new UnityEngine.EventSystems.PointerEventData();\n\tUnityEngine.EventSystems.PointerEventData::.ctor(v253, es);\n\tthis.cachedPointerEventData = v253;\n\tthis.cachedEventSystem = es;\n\tv157 = this.cachedPointerEventData;\nL_0076:\n\tv157.<position>k__BackingField.x = screenPosition;\n\tv157.<position>k__BackingField.y = screenPosition.y;\n\tUnityEngine.EventSystems.EventSystem::RaycastAll(es, v157, this.cachedRaycastResults);\n\tv211 = this.cachedRaycastResults;\n\tv381 = v211.Count < 1;\n\tif (v381) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv143 = 1;\nL_FFFFFFFF:\n\tv217 = 0;\n\tgoto L_00B2;\nL_0095:\n\tv217 = v217 + 1;\n\tv472 = v217 - v211.Count;\n\tv473 = v472 < 0;\n\tv475 = v217 ^ v211.Count;\n\tv476 = v217 ^ v472;\n\tv477 = v475 & v476;\n\tv478 = v477 < 0;\n\tv479 = v473 == v478;\n\tv412 = ~v479;\n\tv417 = v211.Count == v217;\nL_FFFFFFFF:\n\tv143 = v412;\nL_FFFFFFFF:\n\tv432 = v412;\n\tif (v417) goto L_00F6;\nL_00B2:\n\tv424 = System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::get_Item(this.cachedRaycastResults, v217);\n\tv426 = v424.module == 0;\n\tif (v426) goto L_0095;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v435_asT @ TEMPCOND_v9 (UnityEngine.UI.GraphicRaycaster), typeof(UnityEngine.UI.GraphicRaycaster), v424.module (UnityEngine.EventSystems.BaseRaycaster)\n\tv435 = v435_asT == 0;\n\tif (v435) goto L_0095;\nL_FFFFFFFF:\n\tv432 = v143;\n\tgoto L_00F6;\nL_FFFFFFFF:\n\tv432 = 0;\nL_00F7:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_002B:\n\tv54 = this.cachedRaycastResults;\nL_00F6:\n\treturn v432;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool IsUIAtScreenPosition(EventSystem es, Vector2 screenPosition)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::IsUIAtScreenPosition");
			return default;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x772AC30", Offset = "0x772AC30", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_0030;\nL_0030:\n\tv109 = UnityEngine.LayerMask::op_Implicit(this.blockingLayerMask);\n\tgoto L_0039;\nL_0039:\n\tv76 = ray.origin;\n\tv87 = UnityEngine.Physics::Raycast(&v76 @ stack_-80_v2 (UnityEngine.Vector3), v91.blockingHit, maxRayDistance, v109);\n\tv89 = ~v87;\n\tif (v89) goto L_0068;\n\tgoto L_004E;\nL_0068:\n\treturn 0x7F7FFFFF;\nL_001D:\n\tv51 = UnityEngine.LayerMask::op_Implicit(this.blockingLayerMask);\n\tv54 = v51 == 0;\n\tif (v54) goto L_0068;\nL_004E:\n\tv159 = UnityEngine.RaycastHit::get_distance(v157.blockingHit);\n\treturnVal2 = v159 + 0x3C23D70A;\n\treturn returnVal2;\n")]
		private unsafe float GetBlockingDistance(Ray ray, float maxRayDistance)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::GetBlockingDistance");
			return default;
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x772AD80", Offset = "0x772AD80", Length = "0x618")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_001D;\nL_001D:\n\tv62 = UnityEngine.Object::op_Equality(t, 0);\n\tv71 = v62 == 0;\n\tif (v71) goto L_0053;\n\tgoto L_0156;\nL_0053:\n\tv165 = UnityEngine.Component::GetComponent(t);\n\tgoto L_005C;\nL_005C:\n\tv391 = UnityEngine.Object::op_Equality(v165, 0);\n\tv396 = ~v391;\n\tif (v396) goto L_0079;\n\tv413 = UnityEngine.Component::GetComponentInParent(t);\n\tgoto L_006C;\nL_006C:\n\tv439 = UnityEngine.Object::op_Inequality(v413, 0);\n\tv443 = ~v439;\n\tv444 = ~v443;\n\tif (v444) goto L_0089;\n\tgoto L_00A0;\nL_0079:\n\tv415 = v165 == 0;\n\tv271 = ~v415;\n\tv148 = v165;\n\tif (v271) goto L_00E1;\n\tgoto L_020C;\nL_0089:\n\tv468 = HighlightPlus.HighlightEffect::Includes(v413, t);\n\tv470 = ~v468;\n\tif (v470) goto L_00A0;\n\tgoto L_0091;\nL_0091:\n\tv201 = v413 + 0x4A8;\n\tv490 = UnityEngine.Object::op_Equality(v413.previousSettings, 0);\n\tv492 = ~v490;\n\tv493 = ~v492;\n\tif (v493) goto L_00D6;\n\tv427 = *([v201 @ X23_v24]);\n\tv509 = *([v201 @ X23_v24]) == 0;\n\tv273 = ~v509;\n\tif (v273) goto L_00DF;\n\tgoto L_020C;\nL_00A0:\n\tv254 = UnityEngine.Component::get_gameObject(t);\n\tv255 = UnityEngine.GameObject::AddComponent(v254);\n\tv297 = this.baseEffect;\n\tv255.camerasLayerMask = v297.camerasLayerMask;\n\tv255.ignoreObjectVisibility = v297.ignoreObjectVisibility;\n\tv255.reflectionProbes = v297.reflectionProbes;\n\tv255.normalsOption = v297.normalsOption;\n\tv255.optimizeSkinnedMesh = v297.optimizeSkinnedMesh;\n\tv505 = UnityEngine.ScriptableObject::CreateInstance();\n\tv255.previousSettings = v505;\n\tHighlightPlus.HighlightProfile::Save(v255.previousSettings, this.baseEffect);\n\tHighlightPlus.HighlightProfile::Load(v255.previousSettings, v255);\n\tv148 = v255;\n\tgoto L_00E1;\nL_00D6:\n\tv515 = UnityEngine.ScriptableObject::CreateInstance();\n\t*([v201 @ X23_v24]) = v515;\n\tv427 = *([v201 @ X23_v24]);\nL_00DF:\n\tHighlightPlus.HighlightProfile::Save(v427, v413);\n\tv148 = v413;\nL_00E1:\n\tv432 = v148.isSelected ^ 1;\n\tv120 = v432 & 1;\n\tv150 = v432 | forceSelection;\n\tv144 = v150 & 1;\n\tv93 = v120 != v144;\n\tif (v93) goto L_0156;\n\tv441 = v150 & 1;\n\tv442 = v441 == 0;\n\tif (v442) goto L_0103;\n\tv449 = this.OnObjectSelected == 0;\n\tif (v449) goto L_011A;\n\tv455 = UnityEngine.Component::get_gameObject(t);\n\tv137 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectSelected, v455);\n\tv474 = v137 & 1;\n\tv475 = v474 == 0;\n\tv141 = ~v475;\n\tif (v141) goto L_011A;\n\tgoto L_0156;\nL_0103:\n\t;\n\tv450 = this.OnObjectUnSelected == 0;\n\tif (v450) goto L_011A;\n\tv463 = UnityEngine.Component::get_gameObject(t);\n\tv138 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectUnSelected, v463);\n\tv142 = v138 == 0;\n\tif (v142) goto L_0156;\nL_011A:\n\tv170 = this.singleSelection != 1;\n\tif (v170) goto L_0120;\n\tHighlightPlus.HighlightManager::internal_DeselectAll(this);\nL_0120:\n\tthis.currentEffect = v148;\n\tv239 = v150 & 1;\n\tHighlightPlus.HighlightEffect::set_isSelected(this.currentEffect, v239);\n\tUnityEngine.Behaviour::set_enabled(this.baseEffect, 0);\n\tv301 = this.currentEffect;\n\tv171 = v301.isSelected != 1;\n\tif (v171) goto L_0158;\n\tgoto L_0146;\nL_0146:\n\tv528 = UnityEngine.Object::op_Equality(v301.previousSettings, 0);\n\tv538 = ~v528;\n\tv539 = ~v538;\n\tif (v539) goto L_0174;\n\tgoto L_0183;\nL_0156:\n\treturn;\nL_0158:\n\tgoto L_015B;\nL_015B:\n\tv534 = UnityEngine.Object::op_Inequality(v301.previousSettings, 0);\n\tv544 = ~v534;\n\tv545 = ~v544;\n\tif (v545) goto L_01CC;\n\tv318 = 0xB28F000 + 0x90;\n\tgoto L_0167;\nL_0167:\n\tv580 = v302.selectedObjects == 0;\n\tv283 = ~v580;\n\tif (v283) goto L_01E5;\n\tgoto L_020C;\nL_0174:\n\tv206 = this.currentEffect;\n\tv262 = UnityEngine.ScriptableObject::CreateInstance();\n\tv206.previousSettings = v262;\nL_0183:\n\tHighlightPlus.HighlightProfile::Save(v148.previousSettings, v148);\n\tgoto L_0195;\nL_0195:\n\tv627 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Contains(v308.selectedObjects, this.currentEffect);\n\tv641 = v627 == 0;\n\tv630 = ~v641;\n\tif (v630) goto L_01FD;\n\tgoto L_01A2;\n\tgoto L_01FC;\nL_01CC:\n\tv306 = this.currentEffect;\n\tHighlightPlus.HighlightProfile::Load(v306.previousSettings, v148);\n\tv318 = 0xB28F000 + 0x90;\n\tgoto L_0167;\nL_01E5:\n\tv593 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Contains(v302.selectedObjects, this.currentEffect);\n\tv600 = ~v593;\n\tif (v600) goto L_01FD;\n\tv638 = *([v318 @ X20_v9 (System.Int32)]);\n\tgoto L_01EF;\n\tv629 = System.Collections.Generic.List`1<System.Object>::Remove(*([v310 @ X8_v21+30]), this.currentEffect);\n\tgoto L_01FD;\nL_01FC:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Add(v264, this.currentEffect);\nL_01FD:\n\tv364 = v150 & 1;\n\tHighlightPlus.HighlightManager::Highlight(this, v364);\n\treturn;\nL_020C:\n\tthrow System.NullReferenceException;\nL_01A2:\n\tv264 = v309.selectedObjects;\nL_01EF:\n\tv310 = *([v638 @ X0_v21+B8]);\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ToggleSelection(Transform t, bool forceSelection)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::ToggleSelection");
		}

		[Token(Token = "0x60000D7")]
		[Address(RVA = "0x7728A80", Offset = "0x7728A80", Length = "0x30C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.currentEffect, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0039;\n\treturn;\nL_0039:\n\tv89 = this.currentEffect;\n\tv90 = ~state;\n\tif (v90) goto L_0080;\n\tv235 = v89.highlighted == 0;\n\tv236 = ~v235;\n\tif (v236) goto L_00A3;\n\tv312 = this.OnObjectHighlightStart == 0;\n\tif (v312) goto L_00A3;\n\tgoto L_0050;\nL_0050:\n\tv273 = UnityEngine.Object::op_Inequality(v89.target, 0);\n\tv320 = ~v273;\n\tif (v320) goto L_00A3;\n\tv296 = this.currentEffect;\n\tv275 = UnityEngine.Component::get_gameObject(v296.target);\n\tv318 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightStart, v275);\n\tv393 = v318 & 1;\n\tv394 = v393 == 0;\n\tv186 = ~v394;\n\tif (v186) goto L_00A3;\n\tthis.currentObject = 0;\n\treturn;\nL_0080:\n\tv237 = v89.highlighted != 1;\n\tif (v237) goto L_00A3;\n\tv321 = this.OnObjectHighlightEnd == 0;\n\tif (v321) goto L_00A3;\n\tgoto L_008F;\nL_008F:\n\tv276 = UnityEngine.Object::op_Inequality(v89.target, 0);\n\tv322 = ~v276;\n\tif (v322) goto L_00A3;\n\tv297 = this.currentEffect;\n\tv278 = UnityEngine.Component::get_gameObject(v297.target);\n\tv317 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightEnd, v278);\n\tv332 = v182 == 0;\n\tv289 = ~v332;\n\tif (v289) goto L_00BB;\n\tgoto L_0141;\nL_00AF:\n\tv340 = v182.isSelected == 0;\n\tif (v340) goto L_00DC;\nL_00BB:\n\tv96 = v182.isSelected != 1;\n\tif (v96) goto L_00D1;\n\tv349 = ~state;\n\tif (v349) goto L_00F5;\n\tgoto L_00C7;\nL_00C7:\n\tv361 = UnityEngine.Object::op_Inequality(this.selectedAndHighlightedProfile, 0);\n\tv364 = ~v361;\n\tif (v364) goto L_00F5;\n\tv405 = this.selectedAndHighlightedProfile;\n\tv384 = this.selectedAndHighlightedProfile == 0;\n\tv291 = ~v384;\n\tif (v291) goto L_00FF;\n\tgoto L_0141;\nL_00D1:\n\tv188 = this.highlightOnHover == 0;\n\tif (v188) goto L_00E7;\nL_00DC:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v182, state);\n\treturn;\nL_00E7:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v182, 0);\n\treturn;\nL_00F5:\n\tgoto L_00F9;\nL_00F9:\n\tv374 = UnityEngine.Object::op_Inequality(this.selectedProfile, 0);\n\tv377 = ~v374;\n\tif (v377) goto L_0109;\n\tv405 = this.selectedProfile;\nL_00FF:\n\tv271 = this.currentEffect;\n\tgoto L_010F;\nL_0109:\n\tv271 = this.currentEffect;\n\tv405 = v271.previousSettings;\nL_010F:\n\tHighlightPlus.HighlightProfile::Load(v405, v271);\n\tv183 = this.currentEffect;\n\tv97 = v183.highlighted != 1;\n\tif (v97) goto L_013F;\n\tv131 = v183.fading == -1;\n\tif (v131) goto L_013F;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(v183, 0);\n\treturn;\nL_013F:\n\tHighlightPlus.HighlightEffect::SetHighlighted(v183, 1);\n\treturn;\nL_0141:\n\tthrow System.NullReferenceException;\nL_00A3:\n\tv182 = this.currentEffect;\n\tv328 = this.selectOnClick == 0;\n\tif (v328) goto L_00AF;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Highlight(bool state)
		{
			//IL_01f8: Expected O, but got I4
			//IL_010e: Expected O, but got I4
			if (currentEffect == null)
			{
				return;
			}
			HighlightEffect highlightEffect = currentEffect;
			if (state)
			{
				if (!highlightEffect.highlighted && OnObjectHighlightStart != null && highlightEffect.target != null)
				{
					HighlightEffect highlightEffect2 = currentEffect;
					GameObject obj = highlightEffect2.target.gameObject;
					object obj2 = OnObjectHighlightStart(obj);
					if ((int)((nint)obj2 & 1) == 0)
					{
						currentObject = null;
						return;
					}
				}
			}
			else if (highlightEffect.highlighted && OnObjectHighlightEnd != null && highlightEffect.target != null)
			{
				HighlightEffect highlightEffect3 = currentEffect;
				GameObject obj3 = highlightEffect3.target.gameObject;
				object obj4 = OnObjectHighlightEnd(obj3);
			}
			HighlightEffect highlightEffect4 = currentEffect;
			if (selectOnClick)
			{
				if ((object)highlightEffect4 == null)
				{
					goto IL_0416;
				}
			}
			else if (!highlightEffect4.isSelected)
			{
				goto IL_0309;
			}
			HighlightProfile previousSettings;
			HighlightEffect highlightEffect5;
			if (highlightEffect4.isSelected)
			{
				if (state && selectedAndHighlightedProfile != null)
				{
					previousSettings = selectedAndHighlightedProfile;
					if ((object)selectedAndHighlightedProfile == null)
					{
						goto IL_0416;
					}
				}
				else
				{
					if (!(selectedProfile != null))
					{
						highlightEffect5 = currentEffect;
						previousSettings = highlightEffect5.previousSettings;
						goto IL_0395;
					}
					previousSettings = selectedProfile;
				}
				highlightEffect5 = currentEffect;
				goto IL_0395;
			}
			if (highlightOnHover)
			{
				goto IL_0309;
			}
			highlightEffect4.SetHighlighted(state: false);
			return;
			IL_0416:
			throw new NullReferenceException();
			IL_0395:
			previousSettings.Load(highlightEffect5);
			HighlightEffect highlightEffect6 = currentEffect;
			if (highlightEffect6.highlighted && highlightEffect6.fading != HighlightEffect.FadingState.FadingOut)
			{
				highlightEffect6.UpdateMaterialProperties();
			}
			else
			{
				highlightEffect6.SetHighlighted(state: true);
			}
			return;
			IL_0309:
			highlightEffect4.SetHighlighted(state);
		}

		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x77299B4", Offset = "0x77299B4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB795000;\n\tv14 = *([B7951FF]) & 1;\n\tv15 = v14 == 0;\n\tif (v15) goto L_0035;\n\tv17 = UnityEngine.Camera::get_main();\n\tv90 = v17;\n\tgoto L_0017;\nL_0017:\n\tv54 = UnityEngine.Object::op_Equality(v90, 0);\n\tv63 = ~v54;\n\tif (v63) goto L_004C;\n\tgoto L_0029;\nL_0029:\n\treturnVal2 = HighlightPlus.Misc::FindObjectOfType(0);\n\treturn returnVal2;\nL_0035:\n\t*([v10 @ X19_v1+1FF]) = 1;\n\tv70 = UnityEngine.Camera::get_main();\n\tv90 = v70;\n\tgoto L_0017;\nL_004C:\n\treturn v90;\n")]
		public static Camera GetCamera()
		{
			//IL_0009: Expected O, but got I4
			object obj = 192499712;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951FF]");
			Camera camera;
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				Camera main = Camera.main;
				camera = main;
			}
			else
			{
				_ = 1;
				Camera main2 = Camera.main;
				camera = main2;
			}
			if (camera == null)
			{
				return Misc.FindObjectOfType<Camera>();
			}
			return camera;
		}

		[Token(Token = "0x60000D9")]
		[Address(RVA = "0x7729DD0", Offset = "0x7729DD0", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_0019;\nL_0019:\n\tv72 = v57.selectedObjects;\n\tv59 = v57.selectedObjects == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0045;\n\tgoto L_00E3;\nL_0045:\n\tv85 = v72.Count < 1;\n\tif (v85) goto L_00AF;\n\tv163 = 0;\n\tgoto L_0067;\nL_004F:\n\tHighlightPlus.HighlightEffect::RestorePreviousHighlightEffectSettings(v278);\n\tHighlightPlus.HighlightEffect::set_isSelected(v278, 0);\n\tHighlightPlus.HighlightEffect::SetHighlighted(v278, 0);\nL_0058:\n\tv163 = v163 + 1;\n\tv177 = v72.Count == v163;\n\tif (v177) goto L_00AF;\nL_0067:\n\tgoto L_0070;\nL_0070:\n\tv278 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::get_Item(v161.selectedObjects, v163);\n\tgoto L_0079;\nL_0079:\n\tv284 = UnityEngine.Object::op_Inequality(v278, 0);\n\tv286 = ~v284;\n\tif (v286) goto L_0058;\n\tgoto L_0088;\nL_0088:\n\tv318 = UnityEngine.Component::get_gameObject(v278);\n\tgoto L_008F;\nL_008F:\n\tv303 = UnityEngine.Object::op_Inequality(v318, 0);\n\tv308 = ~v303;\n\tif (v308) goto L_0058;\n\tgoto L_009C;\nL_009C:\n\t;\n\tv328 = this.OnObjectUnSelected == 0;\n\tif (v328) goto L_004F;\n\tv331 = UnityEngine.Component::get_gameObject(v278);\n\tv305 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectUnSelected, v331);\n\tv338 = v305 == 0;\n\tv310 = ~v338;\n\tif (v310) goto L_004F;\n\tgoto L_0058;\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Clear(v160);\n\tv232 = v160.Count < 1;\n\tif (v232) goto L_00E2;\n\treturn;\nL_00E2:\n\treturn;\nL_00E3:\n\tthrow System.NullReferenceException;\nL_00AF:\n\tgoto L_00B3;\nL_00B3:\n\tv160 = v204.selectedObjects;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void internal_DeselectAll()
		{
			//IL_018d: Expected O, but got I4
			List<HighlightEffect> list = selectedObjects;
			if (selectedObjects != null)
			{
				if (list.Count >= 1)
				{
					int num = 0;
					do
					{
						UnityEngine.Object obj = selectedObjects[num];
						if (obj != null)
						{
							GameObject gameObject = ((Component)obj).gameObject;
							if (gameObject != null)
							{
								if (OnObjectUnSelected != null)
								{
									GameObject obj2 = ((Component)obj).gameObject;
									object obj3 = OnObjectUnSelected(obj2);
									if (obj3 == null)
									{
										goto IL_009c;
									}
								}
								((HighlightEffect)obj).RestorePreviousHighlightEffectSettings();
								((HighlightEffect)obj).isSelected = false;
								((HighlightEffect)obj).SetHighlighted(false);
							}
						}
						goto IL_009c;
						IL_009c:
						num++;
					}
					while (list.Count != num);
				}
				List<HighlightEffect> list2 = selectedObjects;
				list2.Clear();
				if (list2.Count < 1)
				{
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x772C3D4", Offset = "0x772C3D4", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_0017;\nL_0017:\n\tv55 = HighlightPlus.HighlightManager::get_instance();\n\tgoto L_001E;\nL_001E:\n\tv88 = UnityEngine.Object::op_Inequality(v55, 0);\n\tv99 = ~v88;\n\tif (v99) goto L_0064;\n\tgoto L_002B;\n\tHighlightPlus.HighlightManager::internal_DeselectAll(v113._instance);\n\treturn;\nL_0064:\n\tgoto L_0069;\n\tv224 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::GetEnumerator(v119.selectedObjects);\n\tv165 = v224._list;\n\tgoto L_008F;\nL_008F:\n\tv313 = UnityEngine.Object::op_Inequality(v224.Current, 0);\n\tv317 = v313 == 0;\n\tif (v317) goto L_0081;\n\tv371 = UnityEngine.Component::get_gameObject(v224.Current);\n\tgoto L_00A2;\nL_00A2:\n\tv314 = UnityEngine.Object::op_Inequality(v371, 0);\n\tv318 = v314 == 0;\n\tif (v318) goto L_0081;\n\tHighlightPlus.HighlightEffect::RestorePreviousHighlightEffectSettings(v224.Current);\n\tHighlightPlus.HighlightEffect::set_isSelected(v224.Current, 0);\n\tHighlightPlus.HighlightEffect::SetHighlighted(v224.Current, 0);\n\tgoto L_0081;\nL_00B6:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v165 @ stack_-60_v3 (System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>));\n\tv186 = &v165 @ stack_-60_v3 (System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>);\n\tv191 = 0;\nL_00BB:\n\tgoto L_00BF;\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Clear(v215);\n\tv236 = v215.Count < 1;\n\tif (v236) goto L_00E0;\nL_00E0:\n\treturn;\nL_00F6:\n\tv237 = v204 != 1;\n\tv300 = v219;\n\tif (v237) goto L_0108;\n\tv326 = 0x8BF5BC4(v219, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv339 = 0x8BF5BF4(v326, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v186);\n\tv331 = *([v326 @ X0_v42]) == 0;\n\tv191 = *([v326 @ X0_v42]);\n\tif (v331) goto L_00BB;\n\tv330 = new System.OutOfMemoryException();\n\tv191 = *([v326 @ X0_v42]);\n\tv300 = v330;\n\treturn;\nL_002B:\n\tv115 = v113._instance == 0;\n\tv186 = &v165 @ stack_-60_v3 (System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>);\n\tv191 = 0;\n\tv204 = 0;\n\tif (v115) goto L_00E3;\nL_0069:\n\tv121 = v119.selectedObjects == 0;\n\tv186 = v185;\n\tv204 = 0;\n\tif (v121) goto L_00E3;\nL_0081:\n\tv324 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v165 @ stack_-60_v3 (System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>));\n\tv337 = v324 == 0;\n\tif (v337) goto L_00B6;\nL_00BF:\n\tv215 = v364.selectedObjects;\n\tv212 = v364.selectedObjects == 0;\n\tv186 = v185;\n\tv204 = 0;\n\tif (v212) goto L_00E3;\nL_0108:\n\tv335 = 0x359B3C0(&v191 @ stack_-78_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv341 = 0x8BF0368(v300, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv289 = 0xA1B8(v341, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00E3:\n\tv219 = new System.NullReferenceException();\n\tgoto L_00F6;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void DeselectAll()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::DeselectAll");
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x772C6E8", Offset = "0x772C6E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0016;\nL_0016:\n\tHighlightPlus.HighlightManager::DeselectAll();\n\treturn;\n")]
		public void UnselectObjects()
		{
			DeselectAll();
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x772C750", Offset = "0x772C750", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightManager::ToggleSelection(this, t, 1);\n\treturn;\n")]
		public void SelectObject(Transform t)
		{
			ToggleSelection(t, forceSelection: true);
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x772C758", Offset = "0x772C758", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = objects.Length < 1;\n\tif (v28) goto L_0034;\n\tv87 = 0;\nL_0034:\n\treturn;\nL_001E:\n\tHighlightPlus.HighlightManager::ToggleSelection(this, objects[v87 @ X21_v4 (System.Int32)], 1);\n\tv87 = v87 + 1;\n\tv59 = v87 < objects.Length;\n\tif (v59) goto L_001E;\n")]
		public void SelectObjects(Transform[] objects)
		{
			if (objects.Length >= 1)
			{
				int num = 0;
				do
				{
					ToggleSelection(objects[num], forceSelection: true);
					num++;
				}
				while (num < objects.Length);
			}
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x772C7BC", Offset = "0x772C7BC", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv65 = System.Collections.Generic.List`1<UnityEngine.Transform>::GetEnumerator(objects);\n\tv70 = v65._list;\n\tHighlightPlus.HighlightManager::ToggleSelection(this, v65.Current, 1);\n\tgoto L_003A;\nL_0045:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v70 @ stack_-58_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\nL_004F:\n\treturn;\nL_0050:\n\tv66 = new System.NullReferenceException();\n\tgoto L_005C;\nL_005C:\n\tv101 = objects != 1;\n\tv114 = v66;\n\tif (v101) goto L_006C;\n\tv104 = 0x8BF5BC4(v66, objects, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv121 = 0x8BF5BF4(v104, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v144);\n\tv113 = *([v104 @ X0_v10]) == 0;\n\tif (v113) goto L_004F;\n\tv111 = new System.OutOfMemoryException();\n\tv107 = *([v104 @ X0_v10]);\n\tv114 = v111;\n\treturn;\nL_0023:\n\tv51 = objects == 0;\n\tif (v51) goto L_0050;\nL_003A:\n\tv90 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v70 @ stack_-58_v3 (System.Collections.Generic.List`1<UnityEngine.Transform>));\n\tv87 = v90 == 0;\n\tif (v87) goto L_0045;\nL_006C:\n\tv117 = 0x3176910(&v107 @ stack_-68, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv123 = 0x8BF0368(v114, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv172 = 0xA1B8(v123, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SelectObjects(List<Transform> objects)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightManager::SelectObjects");
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x772C8FC", Offset = "0x772C8FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightManager::ToggleSelection(this, t, 0);\n\treturn;\n")]
		public void ToggleObject(Transform t)
		{
			ToggleSelection(t, forceSelection: false);
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x772C904", Offset = "0x772C904", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(t, 0);\n\tv62 = v53 == 0;\n\tif (v62) goto L_0039;\n\tgoto L_0071;\nL_0039:\n\tv136 = UnityEngine.Component::GetComponent(t);\n\tgoto L_0042;\nL_0042:\n\tv114 = UnityEngine.Object::op_Equality(v136, 0);\n\tv118 = v114 == 0;\n\tif (v118) goto L_005C;\n\tgoto L_0071;\nL_005C:\n\tv80 = v136.isSelected != 1;\n\tif (v80) goto L_0071;\n\tHighlightPlus.HighlightManager::ToggleSelection(this, t, 0);\n\treturn;\nL_0071:\n\treturn;\n")]
		public void UnselectObject(Transform t)
		{
			if (!(t == null))
			{
				HighlightEffect component = t.GetComponent<HighlightEffect>();
				if (!(component == null) && component.isSelected)
				{
					ToggleSelection(t, forceSelection: false);
				}
			}
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x772CA30", Offset = "0x772CA30", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>::.ctor(v57);\n\tthis.cachedRaycastResults = v57;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_001C:\n\tthis.highlightOnHover = 1;\n\tv50 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.layerMask = v50;\n\tv55 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.blockingLayerMask = v55;\n\tthis.respectUI = 1;\n\tthis.keepSelection = 1;\n\tv57 = new System.Collections.Generic.List`1<UnityEngine.EventSystems.RaycastResult>();\n")]
		public HighlightManager()
		{
			LayerMask layerMask = -1;
			this.layerMask = layerMask;
			LayerMask layerMask2 = -1;
			blockingLayerMask = layerMask2;
			respectUI = true;
			keepSelection = true;
			List<RaycastResult> list = new List<RaycastResult>();
			cachedRaycastResults = list;
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x772CAEC", Offset = "0x772CAEC", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\treturn;\nL_0020:\n\tv49 = new System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>();\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::.ctor(v49);\n\tv58.selectedObjects = v49;\n")]
		static HighlightManager()
		{
			List<HighlightEffect> list = new List<HighlightEffect>();
			selectedObjects = list;
		}
	}
}
