using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace AlmostEngine.Screenshot
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class ScreenshotBatch
	{
		[Serializable]
		[Token(Token = "0x200000D")]
		public class ActiveItem
		{
			[Token(Token = "0x400001E")]
			[FieldOffset(Offset = "0x10")]
			public bool m_Active;

			[Token(Token = "0x400001F")]
			[FieldOffset(Offset = "0x18")]
			public string m_Name;

			[HideInInspector]
			[Token(Token = "0x4000020")]
			[FieldOffset(Offset = "0x20")]
			public int m_Id;

			[Token(Token = "0x6000018")]
			[Address(RVA = "0x3C2EDD0", Offset = "0x3C2EDD0", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tthis.m_Active = 1;\n\tthis.m_Name = \"\";\n\tthis.m_Id = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public ActiveItem()
			{
				m_Active = true;
				m_Name = "";
				m_Id = -1;
			}
		}

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x10")]
		public bool m_Active = true;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x18")]
		public string m_Name = "";

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x20")]
		public List<ScreenshotProcess> m_PreProcess;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x28")]
		public List<ScreenshotProcess> m_PostProcess;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x30")]
		public bool m_OverrideActiveResolutions;

		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x38")]
		public List<ActiveItem> m_ActiveResolutions;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x40")]
		public bool m_OverrideActiveComposer;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x48")]
		public List<ActiveItem> m_ActiveCompositions;

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x3C2EC74", Offset = "0x3C2EC74", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tthis.m_PreProcess = v70;\n\tv86 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotProcess>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotProcess>::.ctor(v86);\n\tthis.m_PostProcess = v86;\n\tv94 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::.ctor(v94);\n\tthis.m_ActiveResolutions = v94;\n\tv102 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotBatch+ActiveItem>::.ctor(v102);\n\tthis.m_ActiveCompositions = v102;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_002F:\n\tthis.m_Active = 1;\n\tthis.m_Name = \"\";\n\tv70 = new System.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotProcess>();\n\tSystem.Collections.Generic.List`1<AlmostEngine.Screenshot.ScreenshotProcess>::.ctor(v70);\n")]
		public ScreenshotBatch()
		{
			List<ScreenshotProcess> preProcess = new List<ScreenshotProcess>();
			m_PreProcess = preProcess;
			m_PostProcess = new List<ScreenshotProcess>();
			m_ActiveResolutions = new List<ActiveItem>();
			m_ActiveCompositions = new List<ActiveItem>();
		}
	}
}
