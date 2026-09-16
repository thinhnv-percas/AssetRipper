using System;
using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000C0")]
	public class WaitForSpineAnimation : IEnumerator
	{
		[Flags]
		[Token(Token = "0x20000C1")]
		public enum AnimationEventTypes
		{
			[Token(Token = "0x400043F")]
			Start = 1,
			[Token(Token = "0x4000440")]
			Interrupt = 2,
			[Token(Token = "0x4000441")]
			End = 4,
			[Token(Token = "0x4000442")]
			Dispose = 8,
			[Token(Token = "0x4000443")]
			Complete = 0x10
		}

		[Token(Token = "0x400043D")]
		[FieldOffset(Offset = "0x10")]
		private bool m_WasFired;

		[Token(Token = "0x170001BD")]
		object IEnumerator.Current
		{
			[Token(Token = "0x60006DE")]
			[Address(RVA = "0x1571B6C", Offset = "0x1571B6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60006DA")]
		[Address(RVA = "0x1571864", Offset = "0x1571864", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, eventsToWaitFor);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimation(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor)
		{
			SafeSubscribe(trackEntry, eventsToWaitFor);
		}

		[Token(Token = "0x60006DB")]
		[Address(RVA = "0x1571AA0", Offset = "0x1571AA0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.WaitForSpineAnimation::SafeSubscribe(this, trackEntry, eventsToWaitFor);\n\treturn this;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineAnimation NowWaitFor(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor)
		{
			SafeSubscribe(trackEntry, eventsToWaitFor);
			return this;
		}

		[Token(Token = "0x60006DC")]
		[Address(RVA = "0x1571AB8", Offset = "0x1571AB8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = System.Collections.IEnumerator;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CEB]) = v33;\nL_0011:\n\tv35 = ~this.m_WasFired;\n\tif (v35) goto L_0045;\n\tgoto L_0040;\n\tv103 = *([v37 @ X8_v4+B0]);\n\tv104 = v103 + 8;\n\tv106 = *([v143 @ X10_v8-8]);\n\tv148 = v106 == v40;\n\tif (v148) goto L_0038;\n\tv126 = v142 - 1;\n\tv128 = v143 + 0x10;\n\tv108 = v142 != 1;\n\tif (v108) goto L_FFFFFFFF;\n\tv129 = 2;\n\tv130 = v8;\n\tv131 = 0xB349B4(v130, v40, v129, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0040;\nL_0038:\n\tv154 = *([v143 @ X10_v8]);\n\tv155 = v154 + 2;\n\tv156 = v155 << 4;\n\tv157 = v37 + v156;\n\tv158 = v157 + 0x138;\nL_0040:\n\tSystem.Collections.IEnumerator::Reset(this);\nL_0045:\n\tv94 = this.m_WasFired == 0;\n\treturn v94;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool IEnumerator.MoveNext()
		{
			if (m_WasFired)
			{
				((IEnumerator)this).Reset();
			}
			return !m_WasFired;
		}

		[Token(Token = "0x60006DD")]
		[Address(RVA = "0x1571B64", Offset = "0x1571B64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_WasFired = 0;\n\treturn;\n")]
		void IEnumerator.Reset()
		{
			m_WasFired = false;
		}

		[Token(Token = "0x60006DF")]
		[Address(RVA = "0x1571898", Offset = "0x1571898", Length = "0x208")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = UnityEngine.Debug;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, trackEntry, eventsToWaitFor, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv43 = Spine.AnimationState+TrackEntryDelegate;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, trackEntry, eventsToWaitFor, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, trackEntry, eventsToWaitFor, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv71 = \"TrackEntry was null. Coroutine will continue immediately.\";\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, trackEntry, eventsToWaitFor, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37CEC]) = v40;\nL_001D:\n\tv41 = trackEntry == 0;\n\tif (v41) goto L_0039;\n\tv45 = eventsToWaitFor & 1;\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_0046;\n\tv57 = eventsToWaitFor & 2;\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_0058;\nL_0027:\n\tv86 = eventsToWaitFor & 4;\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_006A;\nL_002B:\n\tv118 = eventsToWaitFor & 8;\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_007C;\nL_002F:\n\tv169 = eventsToWaitFor & 0x10;\n\tv149 = v169 == 0;\n\tif (v149) goto L_0092;\n\tgoto L_0096;\nL_0039:\n\tgoto L_003F;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, trackEntry, eventsToWaitFor, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_003F:\n\tUnityEngine.Debug::LogWarning(\"TrackEntry was null. Coroutine will continue immediately.\");\n\tthis.m_WasFired = 1;\n\tgoto L_0092;\nL_0046:\n\tv63 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v63, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_Start(trackEntry, v63);\n\tv184 = eventsToWaitFor & 2;\n\tv81 = v184 == 0;\n\tif (v81) goto L_0027;\nL_0058:\n\tv99 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v99, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_Interrupt(trackEntry, v99);\n\tv210 = eventsToWaitFor & 4;\n\tv113 = v210 == 0;\n\tif (v113) goto L_002B;\nL_006A:\n\tv131 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v131, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_End(trackEntry, v131);\n\tv221 = eventsToWaitFor & 8;\n\tv166 = v221 == 0;\n\tif (v166) goto L_002F;\nL_007C:\n\tv180 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v180, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_Dispose(trackEntry, v180);\n\tv226 = eventsToWaitFor & 0x10;\n\tv227 = v226 == 0;\n\tv148 = ~v227;\n\tif (v148) goto L_0096;\nL_0092:\n\treturn;\nL_0096:\n\tv220 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v220, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_Complete(trackEntry, v220);\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void SafeSubscribe(TrackEntry trackEntry, AnimationEventTypes eventsToWaitFor)
		{
			if (trackEntry != null)
			{
				if ((eventsToWaitFor & AnimationEventTypes.Start) == 0)
				{
					if ((eventsToWaitFor & AnimationEventTypes.Interrupt) == 0)
					{
						goto IL_0071;
					}
				}
				else
				{
					AnimationState.TrackEntryDelegate value = HandleComplete;
					trackEntry.Start += value;
					if ((eventsToWaitFor & AnimationEventTypes.Interrupt) == 0)
					{
						goto IL_0071;
					}
				}
				AnimationState.TrackEntryDelegate value2 = HandleComplete;
				trackEntry.Interrupt += value2;
				if ((eventsToWaitFor & AnimationEventTypes.End) == 0)
				{
					goto IL_00a7;
				}
				goto IL_01c8;
			}
			Debug.LogWarning("TrackEntry was null. Coroutine will continue immediately.");
			m_WasFired = true;
			return;
			IL_00a7:
			if ((eventsToWaitFor & AnimationEventTypes.Dispose) == 0)
			{
				goto IL_00dd;
			}
			goto IL_0216;
			IL_01c8:
			AnimationState.TrackEntryDelegate value3 = HandleComplete;
			trackEntry.End += value3;
			if ((eventsToWaitFor & AnimationEventTypes.Dispose) == 0)
			{
				goto IL_00dd;
			}
			goto IL_0216;
			IL_0270:
			AnimationState.TrackEntryDelegate value4 = HandleComplete;
			trackEntry.Complete += value4;
			return;
			IL_00dd:
			if ((eventsToWaitFor & AnimationEventTypes.Complete) != 0)
			{
				goto IL_0270;
			}
			return;
			IL_0216:
			AnimationState.TrackEntryDelegate value5 = HandleComplete;
			trackEntry.Dispose += value5;
			if ((eventsToWaitFor & AnimationEventTypes.Complete) == 0)
			{
				return;
			}
			goto IL_0270;
			IL_0071:
			if ((eventsToWaitFor & AnimationEventTypes.End) == 0)
			{
				goto IL_00a7;
			}
			goto IL_01c8;
		}

		[Token(Token = "0x60006E0")]
		[Address(RVA = "0x1571B74", Offset = "0x1571B74", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_WasFired = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleComplete(TrackEntry trackEntry)
		{
			m_WasFired = true;
		}
	}
}
