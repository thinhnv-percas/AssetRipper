using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000C4")]
	public class WaitForSpineEvent : IEnumerator
	{
		[Token(Token = "0x4000444")]
		[FieldOffset(Offset = "0x10")]
		private EventData m_TargetEvent;

		[Token(Token = "0x4000445")]
		[FieldOffset(Offset = "0x18")]
		private string m_EventName;

		[Token(Token = "0x4000446")]
		[FieldOffset(Offset = "0x20")]
		private AnimationState m_AnimationState;

		[Token(Token = "0x4000447")]
		[FieldOffset(Offset = "0x28")]
		private bool m_WasFired;

		[Token(Token = "0x4000448")]
		[FieldOffset(Offset = "0x29")]
		private bool m_unsubscribeAfterFiring;

		[Token(Token = "0x170001BE")]
		public bool WillUnsubscribeAfterFiring
		{
			[Token(Token = "0x60006ED")]
			[Address(RVA = "0x1572150", Offset = "0x1572150", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_unsubscribeAfterFiring;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return WillUnsubscribeAfterFiring;
			}
			[Token(Token = "0x60006EE")]
			[Address(RVA = "0x1572158", Offset = "0x1572158", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_unsubscribeAfterFiring = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_unsubscribeAfterFiring = value;
			}
		}

		[Token(Token = "0x170001BF")]
		object IEnumerator.Current
		{
			[Token(Token = "0x60006F4")]
			[Address(RVA = "0x15724A0", Offset = "0x15724A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60006E5")]
		[Address(RVA = "0x1571C3C", Offset = "0x1571C3C", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = UnityEngine.Debug;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv74 = \"AnimationState argument was null. Coroutine will continue immediately.\";\n\tv75 = \"il2cpp_codegen_initialize_runtime_metadata\"(v74, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv92 = \"eventDataReference argument was null. Coroutine will continue immediately.\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37CED]) = v43;\nL_0022:\n\tv44 = state == 0;\n\tif (v44) goto L_0040;\n\tv48 = eventDataReference == 0;\n\tif (v48) goto L_004B;\n\tthis.m_AnimationState = state;\n\tthis.m_TargetEvent = eventDataReference;\n\tv62 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v62, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(state, v62);\n\tthis.m_unsubscribeAfterFiring = unsubscribe;\n\tgoto L_005B;\nL_0040:\n\tgoto L_FFFFFFFF;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v51, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0051;\nL_004B:\n\tgoto L_FFFFFFFF;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v65, state, eventDataReference, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tUnityEngine.Debug::LogWarning(*([v88 @ X8_v3 (System.String)]));\n\tthis.m_WasFired = 1;\nL_005B:\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Subscribe(AnimationState state, EventData eventDataReference, bool unsubscribe)
		{
			string message;
			if (state != null)
			{
				if (eventDataReference != null)
				{
					m_AnimationState = state;
					m_TargetEvent = eventDataReference;
					AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEvent;
					state.Event += value;
					m_unsubscribeAfterFiring = unsubscribe;
					return;
				}
				message = "eventDataReference argument was null. Coroutine will continue immediately.";
			}
			else
			{
				message = "AnimationState argument was null. Coroutine will continue immediately.";
			}
			Debug.LogWarning(message);
			m_WasFired = true;
		}

		[Token(Token = "0x60006E6")]
		[Address(RVA = "0x1571D68", Offset = "0x1571D68", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = UnityEngine.Debug;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv47 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv67 = \"eventName argument was null. Coroutine will continue immediately.\";\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv89 = \"AnimationState argument was null. Coroutine will continue immediately.\";\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37CEE]) = v43;\nL_0022:\n\tv44 = state == 0;\n\tif (v44) goto L_003B;\n\tv50 = System.String::IsNullOrEmpty(eventName);\n\tv61 = v50 == 0;\n\tif (v61) goto L_0045;\n\tgoto L_FFFFFFFF;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v71, v49, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0041;\nL_003B:\n\tgoto L_FFFFFFFF;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v53, state, eventName, unsubscribe, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0041:\n\tUnityEngine.Debug::LogWarning(*([v84 @ X8_v4 (System.String)]));\n\tthis.m_WasFired = 1;\n\tgoto L_005F;\nL_0045:\n\tthis.m_EventName = eventName;\n\tthis.m_AnimationState = state;\n\tv79 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v79, this, Il2CppMethodInfo);\n\tSpine.AnimationState::add_Event(state, v79);\n\tthis.m_unsubscribeAfterFiring = unsubscribe;\nL_005F:\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SubscribeByName(AnimationState state, string eventName, bool unsubscribe)
		{
			string message;
			if (state != null)
			{
				if (!string.IsNullOrEmpty(eventName))
				{
					m_EventName = eventName;
					m_AnimationState = state;
					AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEventByName;
					state.Event += value;
					m_unsubscribeAfterFiring = unsubscribe;
					return;
				}
				message = "eventName argument was null. Coroutine will continue immediately.";
			}
			else
			{
				message = "AnimationState argument was null. Coroutine will continue immediately.";
			}
			Debug.LogWarning(message);
			m_WasFired = true;
		}

		[Token(Token = "0x60006E7")]
		[Address(RVA = "0x1571E9C", Offset = "0x1571E9C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineEvent::Subscribe(this, state, eventDataReference, unsubscribeAfterFiring);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			Subscribe(state, eventDataReference, unsubscribeAfterFiring);
		}

		[Token(Token = "0x60006E8")]
		[Address(RVA = "0x1571EE0", Offset = "0x1571EE0", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineEvent::Subscribe(this, skeletonAnimation.state, eventDataReference, unsubscribeAfterFiring);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			Subscribe(skeletonAnimation.state, eventDataReference, unsubscribeAfterFiring);
		}

		[Token(Token = "0x60006E9")]
		[Address(RVA = "0x1571F2C", Offset = "0x1571F2C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineEvent::SubscribeByName(this, state, eventName, unsubscribeAfterFiring);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			SubscribeByName(state, eventName, unsubscribeAfterFiring);
		}

		[Token(Token = "0x60006EA")]
		[Address(RVA = "0x1571F70", Offset = "0x1571F70", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineEvent::SubscribeByName(this, skeletonAnimation.state, eventName, unsubscribeAfterFiring);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent(SkeletonAnimation skeletonAnimation, string eventName, bool unsubscribeAfterFiring = true)
		{
			SubscribeByName(skeletonAnimation.state, eventName, unsubscribeAfterFiring);
		}

		[Token(Token = "0x60006EB")]
		[Address(RVA = "0x1571FBC", Offset = "0x1571FBC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CEF]) = v37;\nL_0017:\n\tv41 = e.data;\n\tv64 = System.String::op_Equality(v41.name, this.m_EventName);\n\tv66 = v64 | this.m_WasFired;\n\tthis.m_WasFired = v66;\n\tv67 = v66 == 0;\n\tif (v67) goto L_0044;\n\tv92 = ~this.m_unsubscribeAfterFiring;\n\tif (v92) goto L_0044;\n\tv50 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v50, this, Il2CppMethodInfo);\n\tSpine.AnimationState::remove_Event(this.m_AnimationState, v50);\n\treturn;\nL_0044:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleAnimationStateEventByName(TrackEntry trackEntry, Event e)
		{
			EventData data = e.Data;
			bool flag = data.Name == m_EventName;
			if ((m_WasFired = flag | m_WasFired) && WillUnsubscribeAfterFiring)
			{
				AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEventByName;
				m_AnimationState.Event -= value;
			}
		}

		[Token(Token = "0x60006EC")]
		[Address(RVA = "0x157208C", Offset = "0x157208C", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, trackEntry, e, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CF0]) = v37;\nL_001C:\n\tv46 = e.data - this.m_TargetEvent;\n\tv48 = v46 == 0;\n\tv54 = v48 | this.m_WasFired;\n\tthis.m_WasFired = v54;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0048;\n\tv94 = ~this.m_unsubscribeAfterFiring;\n\tif (v94) goto L_0048;\n\tv83 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v83, this, Il2CppMethodInfo);\n\tSpine.AnimationState::remove_Event(this.m_AnimationState, v83);\n\treturn;\nL_0048:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleAnimationStateEvent(TrackEntry trackEntry, Event e)
		{
			//IL_001b: Expected O, but got I
			object obj = (nint)e.Data - (nint)m_TargetEvent;
			bool flag = obj == null;
			if ((m_WasFired = flag | m_WasFired) && WillUnsubscribeAfterFiring)
			{
				AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEvent;
				m_AnimationState.Event -= value;
			}
		}

		[Token(Token = "0x60006EF")]
		[Address(RVA = "0x1572164", Offset = "0x1572164", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = System.Collections.IEnumerator;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, state, eventDataReference, unsubscribeAfterFiring, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37CF1]) = v46;\nL_001D:\n\tgoto L_0044;\n\tv51 = *([v47 @ X8_v3+B0]);\n\tv52 = v51 + 8;\n\tv54 = *([v102 @ X10_v5-8]);\n\tv107 = v54 == v48;\n\tif (v107) goto L_003C;\n\tv60 = v93 - 1;\n\tv86 = v102 + 0x10;\n\tv57 = v93 != 1;\n\tif (v57) goto L_FFFFFFFF;\n\tv88 = 2;\n\tv89 = v24;\n\tv90 = 0xB349B4(v89, v48, v88, unsubscribeAfterFiring, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0044;\nL_003C:\n\tv113 = *([v102 @ X10_v5]);\n\tv114 = v113 + 2;\n\tv115 = v114 << 4;\n\tv116 = v47 + v115;\n\tv117 = v116 + 0x138;\nL_0044:\n\tSystem.Collections.IEnumerator::Reset(this);\n\tSpine.Unity.WaitForSpineEvent::Clear(this, state);\n\tSpine.Unity.WaitForSpineEvent::Subscribe(this, state, eventDataReference, unsubscribeAfterFiring);\n\treturn this;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent NowWaitFor(AnimationState state, EventData eventDataReference, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			Clear(state);
			Subscribe(state, eventDataReference, unsubscribeAfterFiring);
			return this;
		}

		[Token(Token = "0x60006F0")]
		[Address(RVA = "0x1572310", Offset = "0x1572310", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = System.Collections.IEnumerator;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, state, eventName, unsubscribeAfterFiring, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 1;\n\t*([1A37CF2]) = v46;\nL_001D:\n\tgoto L_0044;\n\tv51 = *([v47 @ X8_v3+B0]);\n\tv52 = v51 + 8;\n\tv54 = *([v102 @ X10_v5-8]);\n\tv107 = v54 == v48;\n\tif (v107) goto L_003C;\n\tv60 = v93 - 1;\n\tv86 = v102 + 0x10;\n\tv57 = v93 != 1;\n\tif (v57) goto L_FFFFFFFF;\n\tv88 = 2;\n\tv89 = v24;\n\tv90 = 0xB349B4(v89, v48, v88, unsubscribeAfterFiring, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tgoto L_0044;\nL_003C:\n\tv113 = *([v102 @ X10_v5]);\n\tv114 = v113 + 2;\n\tv115 = v114 << 4;\n\tv116 = v47 + v115;\n\tv117 = v116 + 0x138;\nL_0044:\n\tSystem.Collections.IEnumerator::Reset(this);\n\tSpine.Unity.WaitForSpineEvent::Clear(this, state);\n\tSpine.Unity.WaitForSpineEvent::SubscribeByName(this, state, eventName, unsubscribeAfterFiring);\n\treturn this;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineEvent NowWaitFor(AnimationState state, string eventName, bool unsubscribeAfterFiring = true)
		{
			((IEnumerator)this).Reset();
			Clear(state);
			SubscribeByName(state, eventName, unsubscribeAfterFiring);
			return this;
		}

		[Token(Token = "0x60006F1")]
		[Address(RVA = "0x1572240", Offset = "0x1572240", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv26 = Spine.AnimationState+TrackEntryEventDelegate;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, state, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, state, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv56 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, state, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A37CF3]) = v45;\nL_001F:\n\tv47 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v47, this, Il2CppMethodInfo);\n\tSpine.AnimationState::remove_Event(state, v47);\n\tv65 = new Spine.AnimationState+TrackEntryEventDelegate();\n\tSpine.AnimationState+TrackEntryEventDelegate::.ctor(v65, this, Il2CppMethodInfo);\n\tSpine.AnimationState::remove_Event(state, v65);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Clear(AnimationState state)
		{
			AnimationState.TrackEntryEventDelegate value = HandleAnimationStateEvent;
			state.Event -= value;
			AnimationState.TrackEntryEventDelegate value2 = HandleAnimationStateEventByName;
			state.Event -= value2;
		}

		[Token(Token = "0x60006F2")]
		[Address(RVA = "0x15723EC", Offset = "0x15723EC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = System.Collections.IEnumerator;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CF4]) = v33;\nL_0011:\n\tv35 = ~this.m_WasFired;\n\tif (v35) goto L_0045;\n\tgoto L_0040;\n\tv103 = *([v37 @ X8_v4+B0]);\n\tv104 = v103 + 8;\n\tv106 = *([v143 @ X10_v8-8]);\n\tv148 = v106 == v40;\n\tif (v148) goto L_0038;\n\tv126 = v142 - 1;\n\tv128 = v143 + 0x10;\n\tv108 = v142 != 1;\n\tif (v108) goto L_FFFFFFFF;\n\tv129 = 2;\n\tv130 = v8;\n\tv131 = 0xB349B4(v130, v40, v129, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0040;\nL_0038:\n\tv154 = *([v143 @ X10_v8]);\n\tv155 = v154 + 2;\n\tv156 = v155 << 4;\n\tv157 = v37 + v156;\n\tv158 = v157 + 0x138;\nL_0040:\n\tSystem.Collections.IEnumerator::Reset(this);\nL_0045:\n\tv94 = this.m_WasFired == 0;\n\treturn v94;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool IEnumerator.MoveNext()
		{
			if (m_WasFired)
			{
				((IEnumerator)this).Reset();
			}
			return !m_WasFired;
		}

		[Token(Token = "0x60006F3")]
		[Address(RVA = "0x1572498", Offset = "0x1572498", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_WasFired = 0;\n\treturn;\n")]
		void IEnumerator.Reset()
		{
			m_WasFired = false;
		}
	}
}
