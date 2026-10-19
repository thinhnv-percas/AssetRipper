using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine
{
	[Serializable]
	[Token(Token = "0x2000004")]
	public class HotKey
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		public bool m_Shift;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x11")]
		public bool m_Control;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x12")]
		public bool m_Alt;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x14")]
		public KeyCode m_Key;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3C44D70", Offset = "0x3C44D70", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public HotKey()
		{
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3C44D78", Offset = "0x3C44D78", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.m_Shift = shift;\n\tthis.m_Control = control;\n\tthis.m_Alt = alt;\n\tthis.m_Key = key;\n\treturn;\n")]
		public HotKey(bool shift, bool control, bool alt, KeyCode key)
		{
			m_Shift = shift;
			m_Control = control;
			m_Alt = alt;
			m_Key = key;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3C44DCC", Offset = "0x3C44DCC", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.m_Key == 0;\n\tif (v2) goto L_0067;\n\tv24 = this.m_Shift != 1;\n\tif (v24) goto L_002C;\n\tv28 = UnityEngine.Input::GetKey(0x130);\n\tv117 = v28 == 0;\n\tv36 = ~v117;\n\tif (v36) goto L_002C;\n\tv33 = UnityEngine.Input::GetKey(0x12F);\n\tv35 = ~v33;\n\tif (v35) goto L_0065;\nL_002C:\n\tv47 = this.m_Control != 1;\n\tif (v47) goto L_0044;\n\tv120 = UnityEngine.Input::GetKey(0x132);\n\tv131 = v120 == 0;\n\tv127 = ~v131;\n\tif (v127) goto L_0044;\n\tv124 = UnityEngine.Input::GetKey(0x131);\n\tv126 = ~v124;\n\tif (v126) goto L_0065;\nL_0044:\n\tv61 = this.m_Alt != 1;\n\tif (v61) goto L_0054;\n\tv134 = UnityEngine.Input::GetKey(0x134);\n\tv146 = v134 == 0;\n\tv141 = ~v146;\n\tif (v141) goto L_0054;\n\tv138 = UnityEngine.Input::GetKey(0x133);\n\tv140 = ~v138;\n\tif (v140) goto L_0065;\nL_0054:\n\tv143 = UnityEngine.Input::GetKeyUp(this.m_Key);\n\tv111 = v143 == 0;\n\tif (v111) goto L_0065;\n\treturn 1;\nL_0065:\n\treturn 0;\nL_0067:\n\treturn 0;\n")]
		public bool IsPressed()
		{
			if (m_Key != KeyCode.None)
			{
				if ((!m_Shift || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) && (!m_Control || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && (!m_Alt || Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt)) && Input.GetKeyUp(m_Key))
				{
					return true;
				}
				return false;
			}
			return false;
		}
	}
}
