using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.TutorialSystem.Scripts.Data
{
	[Serializable]
	[Token(Token = "0x200001F")]
	public class MaskData
	{
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x10")]
		public Color color;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x20")]
		public List<RectData> holeDataList;

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x81E3040", Offset = "0x81E3040", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tthis.holeDataList = v54;\n\treturn;\nL_001D:\n\tthis.color = *([9308090]);\n\tSystem.Object::.ctor(this);\n\tv54 = new System.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>();\n\tSystem.Collections.Generic.List`1<Systems.TutorialSystem.Scripts.Data.RectData>::.ctor(v54);\n")]
		public MaskData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskData::.ctor");
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x81E30D8", Offset = "0x81E30D8", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.color = *([9308090]);\n\tSystem.Object::.ctor(this);\n\tthis.color.r = color;\n\tthis.holeDataList = holeDataList;\n\tthis.color.g = color.g;\n\tthis.color.b = color.b;\n\tthis.color.a = color.a;\n\treturn;\n")]
		public MaskData(Color color, List<RectData> holeDataList)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MaskData::.ctor");
		}
	}
}
