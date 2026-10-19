using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.OptionalValueSystem
{
	[Serializable]
	[Token(Token = "0x2000004")]
	public struct Optional<T>
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x0")]
		public bool HasValue;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		private T m_value;

		[Token(Token = "0x17000001")]
		public T Value
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x5E9A570", Offset = "0x5E9A570", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.HasValue != 1;\n\tif (v11) goto L_000F;\n\treturn *([this @ X0 (Unco.OptionalValueSystem.Optional`1<T>)+4]);\nL_000F:\n\treturn 0;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("Optional::get_Value");
				return default;
			}
		}

		[Token(Token = "0x17000002")]
		public static Optional<T> None
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x5E9A60C", Offset = "0x5E9A60C", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\treturn 0;\n")]
			get
			{
				return default(Optional<T>);
			}
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x5E9A58C", Offset = "0x5E9A58C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\nL_000F:\n\tv35 = conditional >> 0x20;\n\tv36 = conditional & 1;\n\tv38 = v36 == 0;\n\tv41 = ~v38;\n\tv42 = ~v41;\n\tif (v42) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = v35;\n\tgoto L_0021;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0021:\n\treturn returnVal1;\n")]
		public static implicit operator T(Optional<T> conditional)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Optional::operator T");
			return default;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x5E9A5C8", Offset = "0x5E9A5C8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\treturnVal1 = 1 | value;\n\treturn returnVal1;\n")]
		public static implicit operator Optional<T>(T value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Optional::operator Optional<T>");
			return default;
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x5E9A600", Offset = "0x5E9A600", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.HasValue = hasValue;\n\t*([this @ X0 (Unco.OptionalValueSystem.Optional`1<T>)+4]) = value;\n\treturn;\n")]
		public Optional(T value, bool hasValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Optional::.ctor");
			this = default;
		}
	}
}
