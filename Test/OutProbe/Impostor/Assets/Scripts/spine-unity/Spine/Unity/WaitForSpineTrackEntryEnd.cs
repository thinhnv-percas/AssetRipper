using System.Collections;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000C5")]
	public class WaitForSpineTrackEntryEnd : IEnumerator
	{
		[Token(Token = "0x4000449")]
		[FieldOffset(Offset = "0x10")]
		private bool m_WasFired;

		[Token(Token = "0x170001C0")]
		object IEnumerator.Current
		{
			[Token(Token = "0x60006FB")]
			[Address(RVA = "0x1572688", Offset = "0x1572688", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60006F5")]
		[Address(RVA = "0x15724A8", Offset = "0x15724A8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tSpine.Unity.WaitForSpineTrackEntryEnd::SafeSubscribe(this, trackEntry);\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineTrackEntryEnd(TrackEntry trackEntry)
		{
			SafeSubscribe(trackEntry);
		}

		[Token(Token = "0x60006F6")]
		[Address(RVA = "0x15725B0", Offset = "0x15725B0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_WasFired = 1;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void HandleEnd(TrackEntry trackEntry)
		{
			m_WasFired = true;
		}

		[Token(Token = "0x60006F7")]
		[Address(RVA = "0x15724D4", Offset = "0x15724D4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = UnityEngine.Debug;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, trackEntry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Spine.AnimationState+TrackEntryDelegate;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, trackEntry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = Il2CppMethodInfo;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, trackEntry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv68 = \"TrackEntry was null. Coroutine will continue immediately.\";\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, trackEntry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CF5]) = v37;\nL_001B:\n\tv38 = trackEntry == 0;\n\tif (v38) goto L_0038;\n\tv47 = new Spine.AnimationState+TrackEntryDelegate();\n\tSpine.AnimationState+TrackEntryDelegate::.ctor(v47, this, Il2CppMethodInfo);\n\tSpine.TrackEntry::add_End(trackEntry, v47);\n\treturn;\nL_0038:\n\tgoto L_003E;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v50, trackEntry, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_003E:\n\tUnityEngine.Debug::LogWarning(\"TrackEntry was null. Coroutine will continue immediately.\");\n\tthis.m_WasFired = 1;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SafeSubscribe(TrackEntry trackEntry)
		{
			if (trackEntry != null)
			{
				AnimationState.TrackEntryDelegate value = HandleEnd;
				trackEntry.End += value;
			}
			else
			{
				Debug.LogWarning("TrackEntry was null. Coroutine will continue immediately.");
				m_WasFired = true;
			}
		}

		[Token(Token = "0x60006F8")]
		[Address(RVA = "0x15725BC", Offset = "0x15725BC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.WaitForSpineTrackEntryEnd::SafeSubscribe(this, trackEntry);\n\treturn this;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public WaitForSpineTrackEntryEnd NowWaitFor(TrackEntry trackEntry)
		{
			SafeSubscribe(trackEntry);
			return this;
		}

		[Token(Token = "0x60006F9")]
		[Address(RVA = "0x15725D4", Offset = "0x15725D4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = System.Collections.IEnumerator;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CF6]) = v33;\nL_0011:\n\tv35 = ~this.m_WasFired;\n\tif (v35) goto L_0045;\n\tgoto L_0040;\n\tv103 = *([v37 @ X8_v4+B0]);\n\tv104 = v103 + 8;\n\tv106 = *([v143 @ X10_v8-8]);\n\tv148 = v106 == v40;\n\tif (v148) goto L_0038;\n\tv126 = v142 - 1;\n\tv128 = v143 + 0x10;\n\tv108 = v142 != 1;\n\tif (v108) goto L_FFFFFFFF;\n\tv129 = 2;\n\tv130 = v8;\n\tv131 = 0xB349B4(v130, v40, v129, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0040;\nL_0038:\n\tv154 = *([v143 @ X10_v8]);\n\tv155 = v154 + 2;\n\tv156 = v155 << 4;\n\tv157 = v37 + v156;\n\tv158 = v157 + 0x138;\nL_0040:\n\tSystem.Collections.IEnumerator::Reset(this);\nL_0045:\n\tv94 = this.m_WasFired == 0;\n\treturn v94;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool IEnumerator.MoveNext()
		{
			if (m_WasFired)
			{
				((IEnumerator)this).Reset();
			}
			return !m_WasFired;
		}

		[Token(Token = "0x60006FA")]
		[Address(RVA = "0x1572680", Offset = "0x1572680", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_WasFired = 0;\n\treturn;\n")]
		void IEnumerator.Reset()
		{
			m_WasFired = false;
		}
	}
}
