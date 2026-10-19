using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Serializable]
	[Token(Token = "0x200001B")]
	public class SaveData
	{
		[Token(Token = "0x4000021")]
		[FieldOffset(Offset = "0x10")]
		public DateTime time;

		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		public object obj;

		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x3F40158", Offset = "0x3F40158", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SaveData()
		{
		}

		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x3F40160", Offset = "0x3F40160", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.obj = obj;\n\treturn;\n")]
		public SaveData(object obj)
		{
			this.obj = obj;
		}

		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x3F40194", Offset = "0x3F40194", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_002A:\n\tv47.time = v60.MinValue;\n\treturn v47;\nL_001B:\n\tv47 = new Unco.SaveSystem.Core.Variables.SaveData();\n\tSystem.Object::.ctor(v47);\n\tgoto L_002A;\n")]
		public static SaveData Empty()
		{
			SaveData saveData = new SaveData();
			saveData.time = DateTime.MinValue;
			return saveData;
		}

		[Token(Token = "0x60000C4")]
		[Address(RVA = "0x3F40230", Offset = "0x3F40230", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_0021:\n\t;\n\tv57 = System.DateTime::get_Date(&this.time (System.DateTime));\n\tv62 = System.DateTime::op_Subtraction(v57, v59.UnixEpoch);\n\tv63 = v62;\n\tgoto L_0032;\nL_0032:\n\tv72 = System.TimeSpan::get_TotalSeconds(&v63 @ stack_-38_v1 (System.TimeSpan));\n\tv76 = v72 == 0x7FF0000000000000;\n\tv84 = ~v76;\n\tv85 = ~v84;\n\tif (v85) goto L_FFFFFFFF;\n\tv108 = v72 < 0;\n\tv92 = v72 ^ v72;\n\tv93 = v72 & v92;\n\tv103 = v93 < 0;\n\tgoto L_0050;\nL_FFFFFFFF:\n\tv103 = 0;\nL_FFFFFFFF:\n\tv108 = 1;\nL_001F:\n\tgoto L_0021;\nL_0050:\n\tv109 = v108 == v103;\n\tv110 = ~v109;\n\treturn v110;\n")]
		public bool IsEmpty()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SaveData::IsEmpty");
			return default;
		}
	}
}
