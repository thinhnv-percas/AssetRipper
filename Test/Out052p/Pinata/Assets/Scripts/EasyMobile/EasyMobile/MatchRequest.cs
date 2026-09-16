using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Token(Token = "0x2000048")]
	public class MatchRequest
	{
		[Token(Token = "0x40001D0")]
		public const uint MinVariant = 0u;

		[Token(Token = "0x40001D1")]
		public const uint MaxVariant = 511u;

		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0x10")]
		private uint mMinPlayers;

		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x14")]
		private uint mMaxPlayers;

		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x18")]
		private uint mVariant;

		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x1C")]
		private uint mExclusiveBitmask;

		[Token(Token = "0x1700011B")]
		public uint MinPlayers
		{
			[Token(Token = "0x60003E1")]
			[Address(RVA = "0xFCB760", Offset = "0xFCB760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMinPlayers;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinPlayers;
			}
			[Token(Token = "0x60003E2")]
			[Address(RVA = "0xFCB768", Offset = "0xFCB768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMinPlayers = value;\n\treturn;\n")]
			set
			{
				MinPlayers = value;
			}
		}

		[Token(Token = "0x1700011C")]
		public uint MaxPlayers
		{
			[Token(Token = "0x60003E3")]
			[Address(RVA = "0xFCB770", Offset = "0xFCB770", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mMaxPlayers;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxPlayers;
			}
			[Token(Token = "0x60003E4")]
			[Address(RVA = "0xFCB778", Offset = "0xFCB778", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMaxPlayers = value;\n\treturn;\n")]
			set
			{
				MaxPlayers = value;
			}
		}

		[Token(Token = "0x1700011D")]
		public uint Variant
		{
			[Token(Token = "0x60003E5")]
			[Address(RVA = "0xFCB780", Offset = "0xFCB780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mVariant;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Variant;
			}
			[Token(Token = "0x60003E6")]
			[Address(RVA = "0xFCB788", Offset = "0xFCB788", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDE2B8]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2025640]) = v41;\nL_001B:\n\tgoto L_0027;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0027;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0027:\n\tv61 = UnityEngine.Mathf::Clamp(value, 0f, 511f);\n\tthis.mVariant = v61;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0027: Expected I4, but got F4
				float num = Mathf.Clamp((int)value, 0f, 511f);
				mVariant = (uint)(int)num;
			}
		}

		[Token(Token = "0x1700011E")]
		public uint ExclusiveBitmask
		{
			[Token(Token = "0x60003E7")]
			[Address(RVA = "0xFCB818", Offset = "0xFCB818", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mExclusiveBitmask;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ExclusiveBitmask;
			}
			[Token(Token = "0x60003E8")]
			[Address(RVA = "0xFCB820", Offset = "0xFCB820", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mExclusiveBitmask = value;\n\treturn;\n")]
			set
			{
				ExclusiveBitmask = value;
			}
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0xFCB828", Offset = "0xFCB828", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = matchType == 0;\n\treturnVal1 = v5 << 3;\n\treturn returnVal1;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static uint GetMaxPlayersAllowed(MatchType matchType)
		{
			bool flag = matchType == MatchType.RealTime;
			return (flag ? 1u : 0u) << 3;
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0xFCB838", Offset = "0xFCB838", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mMinPlayers = 0x200000002;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MatchRequest()
		{
			mMinPlayers = 2u;
			mMaxPlayers = 2u;
		}
	}
}
