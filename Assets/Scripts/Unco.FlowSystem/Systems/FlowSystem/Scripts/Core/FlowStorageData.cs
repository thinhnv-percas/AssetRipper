using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Systems.FlowSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x200000C")]
	public class FlowStorageData
	{
		[Token(Token = "0x17000005")]
		[field: Token(Token = "0x400001E")]
		[field: FieldOffset(Offset = "0x10")]
		public int KillFlow
		{
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x81AC334", Offset = "0x81AC334", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.KillFlow;\n")]
			get;
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x81AC33C", Offset = "0x81AC33C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.KillFlow = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x17000006")]
		[field: Token(Token = "0x400001F")]
		[field: FieldOffset(Offset = "0x18")]
		public Dictionary<string, bool> CompletedFlows
		{
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x81AC344", Offset = "0x81AC344", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CompletedFlows;\n")]
			get;
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x81AC34C", Offset = "0x81AC34C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CompletedFlows = value;\n\treturn;\n")]
			set;
		}

		[Token(Token = "0x6000025")]
		[Address(RVA = "0x81AC354", Offset = "0x81AC354", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Dictionary`2<System.String, System.Boolean>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Boolean>::.ctor(v48);\n\tthis.CompletedFlows = v48;\n")]
		public FlowStorageData()
		{
			Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
			CompletedFlows = dictionary;
		}
	}
}
