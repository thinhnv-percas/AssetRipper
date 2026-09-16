using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace CodeStage.AntiCheat.Genuine.CodeHash
{
	[Token(Token = "0x2000030")]
	public class HashGeneratorResult
	{
		[CompilerGenerated]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x10")]
		private string _003CErrorMessage_003Ek__BackingField;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x18")]
		private string summaryCodeHash;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x20")]
		private BuildHashes buildHashes;

		[Obsolete("Please use SummaryHash property instead.")]
		[Token(Token = "0x17000023")]
		public string CodeHash
		{
			[Token(Token = "0x600035F")]
			[Address(RVA = "0xBE9BF4", Offset = "0xBE9BF4", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.buildHashes;\n\treturn v2.<SummaryHash>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				BuildHashes buildHashes = this.buildHashes;
				return buildHashes.SummaryHash;
			}
		}

		[Token(Token = "0x17000024")]
		public string SummaryHash
		{
			[Token(Token = "0x6000360")]
			[Address(RVA = "0xBE9C10", Offset = "0xBE9C10", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.buildHashes;\n\treturn v2.<SummaryHash>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				BuildHashes buildHashes = this.buildHashes;
				return buildHashes.SummaryHash;
			}
		}

		[Token(Token = "0x17000025")]
		public FileHash[] FileHashes
		{
			[Token(Token = "0x6000361")]
			[Address(RVA = "0xBE9C2C", Offset = "0xBE9C2C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.buildHashes;\n\treturn v2.<FileHashes>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				BuildHashes buildHashes = this.buildHashes;
				return buildHashes.FileHashes;
			}
		}

		[Token(Token = "0x17000026")]
		public string ErrorMessage
		{
			[CompilerGenerated]
			[Token(Token = "0x6000362")]
			[Address(RVA = "0xBE9C48", Offset = "0xBE9C48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ErrorMessage>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ErrorMessage;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000363")]
			[Address(RVA = "0xBE9C50", Offset = "0xBE9C50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ErrorMessage>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CErrorMessage_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000027")]
		public bool Success
		{
			[Token(Token = "0x6000364")]
			[Address(RVA = "0xBE9C58", Offset = "0xBE9C58", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.<ErrorMessage>k__BackingField == 0;\n\treturn v6;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ErrorMessage == null;
			}
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0xBE9C68", Offset = "0xBE9C68", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35512]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult();\n\tSystem.Object::.ctor(v39);\n\tv39.<ErrorMessage>k__BackingField = errorMessage;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static HashGeneratorResult FromError(string errorMessage)
		{
			HashGeneratorResult hashGeneratorResult = new HashGeneratorResult();
			hashGeneratorResult.ErrorMessage = errorMessage;
			return hashGeneratorResult;
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0xBE9CD4", Offset = "0xBE9CD4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35513]) = v37;\nL_0014:\n\tv39 = new CodeStage.AntiCheat.Genuine.CodeHash.HashGeneratorResult();\n\tSystem.Object::.ctor(v39);\n\tv39.buildHashes = buildHashes;\n\treturn v39;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static HashGeneratorResult FromBuildHashes(BuildHashes buildHashes)
		{
			HashGeneratorResult hashGeneratorResult = new HashGeneratorResult();
			hashGeneratorResult.buildHashes = buildHashes;
			return hashGeneratorResult;
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0xBE9D38", Offset = "0xBE9D38", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = CodeStage.AntiCheat.Genuine.CodeHash.BuildHashes::HasFileHash(this.buildHashes, hash);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasFileHash(string hash)
		{
			return buildHashes.HasFileHash(hash);
		}

		[Token(Token = "0x6000368")]
		[Address(RVA = "0xBE9CCC", Offset = "0xBE9CCC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HashGeneratorResult()
		{
		}
	}
}
