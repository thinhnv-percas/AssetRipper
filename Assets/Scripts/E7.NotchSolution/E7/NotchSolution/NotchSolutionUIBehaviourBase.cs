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
using UnityEngine.UI;

namespace E7.NotchSolution
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x2000009")]
	public abstract class NotchSolutionUIBehaviourBase : UIBehaviour, ILayoutSelfController, ILayoutController, INotchSimulatorTarget
	{
		[CompilerGenerated]
		[Token(Token = "0x200000A")]
		private sealed class _003CDelayedUpdateRoutine_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000017")]
			[FieldOffset(Offset = "0x10")]
			internal int _003C_003E1__state;

			[Token(Token = "0x4000018")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000019")]
			[FieldOffset(Offset = "0x20")]
			public NotchSolutionUIBehaviourBase _003C_003E4__this;

			[Token(Token = "0x17000007")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000024")]
				[Address(RVA = "0x3F45BEC", Offset = "0x3F45BEC", Length = "0x8")]
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
				[Token(Token = "0x6000026")]
				[Address(RVA = "0x3F45C34", Offset = "0x3F45C34", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x3F45A3C", Offset = "0x3F45A3C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\treturn;\n")]
			public _003CDelayedUpdateRoutine_003Ed__19(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x3F45B2C", Offset = "0x3F45B2C", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000023")]
			[Address(RVA = "0x3F45B30", Offset = "0x3F45B30", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.<>4__this;\n\tv13 = this.<>1__state == 0;\n\tif (v13) goto L_003D;\n\tv23 = this.<>1__state != 1;\n\tif (v23) goto L_0030;\n\tthis.<>1__state = -1;\n\tv38 = UnityEngine.Behaviour::get_enabled(v12);\n\tv45 = ~v38;\n\tif (v45) goto L_0030;\n\tv81 = UnityEngine.Component::get_gameObject(v12);\n\tv39 = UnityEngine.GameObject::get_activeInHierarchy(v81);\n\tv44 = ~v39;\n\tif (v44) goto L_0030;\n\tv37 = E7.NotchSolution.NotchSolutionUIBehaviourBase::UpdateRect(v12);\nL_003D:\n\tthis.<>1__state = -1;\n\tv61 = this + 0x18;\n\tthis.<>2__current = v12.eofWait;\n\t*([v61 @ X0_v3-8]) = 1;\n\tv123 = this.<>1__state == 0;\n\treturn v123;\nL_0030:\n\tv50 = this.<>1__state == 0;\n\treturn v50;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUIBehaviourBase._003CDelayedUpdateRoutine_003Ed__19::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x3F45BF4", Offset = "0x3F45BF4", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = 0xB292000 + 0x4A0;\n\tv27 = new v10();\n\tSystem.NotSupportedException::.ctor(v27);\n\tthrow v27;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}
		}

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x20")]
		private readonly WaitForEndOfFrame eofWait;

		[NonSerialized]
		[Token(Token = "0x4000013")]
		[FieldOffset(Offset = "0x28")]
		private RectTransform m_Rect;

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x30")]
		protected internal DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x38")]
		private Rect[] storedSimulatedCutoutsRelative;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x40")]
		private Rect storedSimulatedSafeAreaRelative;

		[Token(Token = "0x17000005")]
		protected Rect SafeAreaRelative
		{
			[Token(Token = "0x6000012")]
			[Address(RVA = "0x3F453B0", Offset = "0x3F453B0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_001C:\n\treturnVal1 = E7.NotchSolution.NotchSolutionUtility::get_ScreenSafeAreaRelative();\n\treturn returnVal1;\nL_0016:\n\tgoto L_001C;\n")]
			get
			{
				return NotchSolutionUtility.ScreenSafeAreaRelative;
			}
		}

		[Token(Token = "0x17000006")]
		protected internal RectTransform rectTransform
		{
			[Token(Token = "0x6000013")]
			[Address(RVA = "0x3F4541C", Offset = "0x3F4541C", Length = "0xE8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\nL_0011:\n\tv85 = this + 0x28;\n\tgoto L_001A;\nL_001A:\n\tv59 = UnityEngine.Object::op_Equality(this.m_Rect, 0);\n\tv69 = ~v59;\n\tv70 = ~v69;\n\tif (v70) goto L_0042;\n\treturn *([v85 @ X20_v7]);\nL_0042:\n\tv104 = UnityEngine.Component::GetComponent(this);\n\tthis.m_Rect = v104;\n\treturn *([v85 @ X20_v7]);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUIBehaviourBase::get_rectTransform");
				return default;
			}
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x3F45504", Offset = "0x3F45504", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.EventSystems.UIBehaviour::OnEnable(this);\n\tgoto L_0019;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0019:\n\tv45 = new E7.NotchSolution.NotchSolutionUIBehaviourBase+<DelayedUpdateRoutine>d__19();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		protected override void OnEnable()
		{
			base.OnEnable();
			_003CDelayedUpdateRoutine_003Ed__19 _003CDelayedUpdateRoutine_003Ed__20 = (_003CDelayedUpdateRoutine_003Ed__19)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdateRoutine_003Ed__19));
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E1__state = 0;
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CDelayedUpdateRoutine_003Ed__20);
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x3F4560C", Offset = "0x3F4560C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\t;\n\tUnityEngine.DrivenRectTransformTracker::Clear(&this.m_Tracker (UnityEngine.DrivenRectTransformTracker));\n\tv55 = E7.NotchSolution.NotchSolutionUIBehaviourBase::get_rectTransform(this);\n\tgoto L_0025;\nL_0025:\n\tUnityEngine.UI.LayoutRebuilder::MarkLayoutForRebuild(v55);\n\tUnityEngine.EventSystems.UIBehaviour::OnDisable(this);\n\treturn;\n")]
		protected override void OnDisable()
		{
			m_Tracker.Clear();
			RectTransform rect = rectTransform;
			LayoutRebuilder.MarkLayoutForRebuild(rect);
			base.OnDisable();
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x3F45698", Offset = "0x3F45698", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_enabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0023;\n\tv17 = UnityEngine.Component::get_gameObject(this);\n\tv21 = UnityEngine.GameObject::get_activeInHierarchy(v17);\n\tv19 = ~v21;\n\tif (v19) goto L_0023;\n\tv41 = E7.NotchSolution.NotchSolutionUIBehaviourBase::UpdateRect(v41);\n\treturn;\nL_0023:\n\treturn;\n")]
		protected override void OnRectTransformDimensionsChange()
		{
			if (base.enabled)
			{
				GameObject gameObject = base.gameObject;
				if (gameObject.activeInHierarchy)
				{
					NotchSolutionUIBehaviourBase notchSolutionUIBehaviourBase = default(NotchSolutionUIBehaviourBase);
					notchSolutionUIBehaviourBase.UpdateRect();
				}
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3F45760", Offset = "0x3F45760", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_enabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0023;\n\tv17 = UnityEngine.Component::get_gameObject(this);\n\tv21 = UnityEngine.GameObject::get_activeInHierarchy(v17);\n\tv19 = ~v21;\n\tif (v19) goto L_0023;\n\tv41 = E7.NotchSolution.NotchSolutionUIBehaviourBase::UpdateRect(v41);\n\treturn;\nL_0023:\n\treturn;\n")]
		void ILayoutController.SetLayoutHorizontal()
		{
			if (base.enabled)
			{
				GameObject gameObject = base.gameObject;
				if (gameObject.activeInHierarchy)
				{
					NotchSolutionUIBehaviourBase notchSolutionUIBehaviourBase = default(NotchSolutionUIBehaviourBase);
					notchSolutionUIBehaviourBase.UpdateRect();
				}
			}
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x3F457C4", Offset = "0x3F457C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		void ILayoutController.SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x3F457C8", Offset = "0x3F457C8", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.storedSimulatedSafeAreaRelative.x = simulatedSafeAreaRelative;\n\tthis.storedSimulatedSafeAreaRelative.y = simulatedSafeAreaRelative.y;\n\tthis.storedSimulatedSafeAreaRelative.width = simulatedSafeAreaRelative.width;\n\tthis.storedSimulatedSafeAreaRelative.height = simulatedSafeAreaRelative.height;\n\tthis.storedSimulatedCutoutsRelative = simulatedCutoutsRelative;\n\tv31 = UnityEngine.Behaviour::get_enabled(this);\n\tv32 = ~v31;\n\tif (v32) goto L_002E;\n\tv35 = UnityEngine.Component::get_gameObject(this);\n\tv41 = UnityEngine.GameObject::get_activeInHierarchy(v35);\n\tv37 = ~v41;\n\tif (v37) goto L_002E;\n\tv60 = E7.NotchSolution.NotchSolutionUIBehaviourBase::UpdateRect(v60);\n\treturn;\nL_002E:\n\treturn;\n")]
		void INotchSimulatorTarget.SimulatorUpdate(Rect simulatedSafeAreaRelative, Rect[] simulatedCutoutsRelative)
		{
			storedSimulatedSafeAreaRelative.x = simulatedSafeAreaRelative.x;
			storedSimulatedSafeAreaRelative.y = simulatedSafeAreaRelative.y;
			storedSimulatedSafeAreaRelative.width = simulatedSafeAreaRelative.width;
			storedSimulatedSafeAreaRelative.height = simulatedSafeAreaRelative.height;
			storedSimulatedCutoutsRelative = simulatedCutoutsRelative;
			if (base.enabled)
			{
				GameObject gameObject = base.gameObject;
				if (gameObject.activeInHierarchy)
				{
					NotchSolutionUIBehaviourBase notchSolutionUIBehaviourBase = default(NotchSolutionUIBehaviourBase);
					notchSolutionUIBehaviourBase.UpdateRect();
				}
			}
		}

		[Token(Token = "0x600001A")]
		protected abstract void UpdateRect();

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x3F45840", Offset = "0x3F45840", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = *([B78EC1B]) & 1;\n\tv23 = v22 == 0;\n\tif (v23) goto L_0022;\n\tv49 = 0xB2C1000 + 0xD78;\n\tv28 = *([B78EC1C]) & 1;\n\tv29 = v28 == 0;\n\tv61 = v49;\n\tif (v29) goto L_002F;\nL_0019:\n\tv78 = UnityEngine.Component::GetComponentInParent /* +1 sharing this address */(this, *([v49 @ X21_v7 (System.Int32)]));\n\tv72 = v78 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_0036;\n\tgoto L_0061;\nL_0022:\n\t*([B78EC1B]) = 1;\n\tv49 = 0xB2C1000 + 0xD78;\n\tv70 = *([B78EC1C]) & 1;\n\tv71 = v70 == 0;\n\tv52 = ~v71;\n\tv61 = v49;\n\tif (v52) goto L_0019;\nL_002F:\n\t*([B78EC1C]) = 1;\n\tv78 = UnityEngine.Component::GetComponentInParent /* +1 sharing this address */(this, *([v61 @ X21_v4 (System.Int32)]));\nL_0036:\n\tv86 = UnityEngine.Canvas::get_rootCanvas(v78);\n\tv88 = UnityEngine.Component::GetComponent(v86);\n\tv132 = UnityEngine.RectTransform::get_sizeDelta(v88);\n\tgoto L_0060;\nL_0061:\n\tthrow System.NullReferenceException;\nL_0060:\n\treturn v125.zero;\n")]
		protected internal Rect GetCanvasRect()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NotchSolutionUIBehaviourBase::GetCanvasRect");
			return default;
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x3F456FC", Offset = "0x3F456FC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Behaviour::get_enabled(this);\n\tv14 = ~v13;\n\tif (v14) goto L_0023;\n\tv17 = UnityEngine.Component::get_gameObject(this);\n\tv21 = UnityEngine.GameObject::get_activeInHierarchy(v17);\n\tv19 = ~v21;\n\tif (v19) goto L_0023;\n\tv41 = E7.NotchSolution.NotchSolutionUIBehaviourBase::UpdateRect(v41);\n\treturn;\nL_0023:\n\treturn;\n")]
		private void UpdateRectBase()
		{
			if (base.enabled)
			{
				GameObject gameObject = base.gameObject;
				if (gameObject.activeInHierarchy)
				{
					NotchSolutionUIBehaviourBase notchSolutionUIBehaviourBase = default(NotchSolutionUIBehaviourBase);
					notchSolutionUIBehaviourBase.UpdateRect();
				}
			}
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x3F4558C", Offset = "0x3F4558C", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv61 = UnityEngine.MonoBehaviour::StartCoroutine(this, v45);\n\treturn;\nL_0017:\n\tv45 = new E7.NotchSolution.NotchSolutionUIBehaviourBase+<DelayedUpdateRoutine>d__19();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private void DelayedUpdate()
		{
			_003CDelayedUpdateRoutine_003Ed__19 _003CDelayedUpdateRoutine_003Ed__20 = (_003CDelayedUpdateRoutine_003Ed__19)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdateRoutine_003Ed__19));
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E1__state = 0;
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(_003CDelayedUpdateRoutine_003Ed__20);
		}

		[IteratorStateMachine(typeof(_003CDelayedUpdateRoutine_003Ed__19))]
		[Token(Token = "0x600001E")]
		[Address(RVA = "0x3F459C4", Offset = "0x3F459C4", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\treturn v45;\nL_0017:\n\tv45 = new E7.NotchSolution.NotchSolutionUIBehaviourBase+<DelayedUpdateRoutine>d__19();\n\tSystem.Object::.ctor(v45);\n\tv45.<>1__state = 0;\n\tv45.<>4__this = this;\n")]
		private IEnumerator DelayedUpdateRoutine()
		{
			_003CDelayedUpdateRoutine_003Ed__19 _003CDelayedUpdateRoutine_003Ed__20 = (_003CDelayedUpdateRoutine_003Ed__19)FormatterServices.GetUninitializedObject(typeof(_003CDelayedUpdateRoutine_003Ed__19));
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E1__state = 0;
			_003CDelayedUpdateRoutine_003Ed__20._003C_003E4__this = this;
			return _003CDelayedUpdateRoutine_003Ed__20;
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x3F45A68", Offset = "0x3F45A68", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_0030;\nL_001C:\n\tv48 = new UnityEngine.WaitForEndOfFrame();\n\tUnityEngine.WaitForEndOfFrame::.ctor(v48);\n\tthis.eofWait = v48;\nL_0030:\n\tthis.storedSimulatedCutoutsRelative = v64.defaultCutouts;\n\tthis.storedSimulatedSafeAreaRelative = v70.defaultSafeArea;\n\tUnityEngine.EventSystems.UIBehaviour::.ctor(this);\n\treturn;\n")]
		protected internal NotchSolutionUIBehaviourBase()
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			eofWait = waitForEndOfFrame;
			storedSimulatedCutoutsRelative = NotchSolutionUtility.defaultCutouts;
			storedSimulatedSafeAreaRelative = NotchSolutionUtility.defaultSafeArea;
		}
	}
}
