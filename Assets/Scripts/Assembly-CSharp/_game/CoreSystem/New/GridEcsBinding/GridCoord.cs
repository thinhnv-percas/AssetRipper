using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.GridEcsBinding
{
	[Serializable]
	[Token(Token = "0x20003D5")]
	public struct GridCoord : IEquatable<GridCoord>, IComparable<GridCoord>
	{
		[Token(Token = "0x4000C0D")]
		[FieldOffset(Offset = "0x0")]
		public int x;

		[Token(Token = "0x4000C0E")]
		[FieldOffset(Offset = "0x4")]
		public int y;

		[Token(Token = "0x4000C0F")]
		[FieldOffset(Offset = "0x8")]
		public bool IsValid;

		[Token(Token = "0x17000148")]
		public static GridCoord Invalid
		{
			[Token(Token = "0x600102F")]
			[Address(RVA = "0x3CAE658", Offset = "0x3CAE658", Length = "0xC")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::get_Invalid");
				return default;
			}
		}

		[Token(Token = "0x17000149")]
		public int Magnitude
		{
			[Token(Token = "0x6001030")]
			[Address(RVA = "0x3CAE664", Offset = "0x3CAE664", Length = "0x90")]
			get
			{
				//IL_0010: Expected F4, but got I4
				//IL_001f: Expected F4, but got I4
				//IL_0077: Expected I4, but got F4
				float num = Mathf.Abs((float)x);
				float num2 = Mathf.Abs((float)y);
				float num3 = num + num2;
				if (num3 == 1f / 0f)
				{
					return -2147483648;
				}
				return (int)num3;
			}
		}

		[Token(Token = "0x6001031")]
		[Address(RVA = "0x3CADFA4", Offset = "0x3CADFA4", Length = "0x10")]
		public GridCoord(int x, int y)
		{
			this.x = x;
			this.y = y;
			IsValid = true;
		}

		[Token(Token = "0x6001032")]
		[Address(RVA = "0x3CAE6F4", Offset = "0x3CAE6F4", Length = "0x28")]
		public bool Equals(GridCoord other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::Equals");
			return default;
		}

		[Token(Token = "0x6001033")]
		[Address(RVA = "0x3CAE71C", Offset = "0x3CAE71C", Length = "0xB4")]
		public override bool Equals(object obj)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::Equals");
			return default;
		}

		[Token(Token = "0x6001034")]
		[Address(RVA = "0x3CAE7D0", Offset = "0x3CAE7D0", Length = "0x80")]
		public override int GetHashCode()
		{
			int num = x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X19_v2 (System.Int32)+4]");
			return HashCode.Combine(0, x);
		}

		[Token(Token = "0x6001035")]
		[Address(RVA = "0x3CAE850", Offset = "0x3CAE850", Length = "0xC")]
		public static bool operator ==(GridCoord left, GridCoord right)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::operator ==");
			return default;
		}

		[Token(Token = "0x6001036")]
		[Address(RVA = "0x3CAE85C", Offset = "0x3CAE85C", Length = "0xC")]
		public static bool operator !=(GridCoord left, GridCoord right)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::operator !=");
			return default;
		}

		[Token(Token = "0x6001037")]
		[Address(RVA = "0x3CAE868", Offset = "0x3CAE868", Length = "0xD0")]
		public override string ToString()
		{
			if (IsValid)
			{
				int num = x;
				int num2 = 192761856 + 1336;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				int num3 = y;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				object arg2 = default(object);
				return $"({arg}, {arg2})";
			}
			return "Invalid";
		}

		[Token(Token = "0x6001038")]
		[Address(RVA = "0x3CAE938", Offset = "0x3CAE938", Length = "0x2C")]
		public unsafe int CompareTo(GridCoord other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridCoord::CompareTo");
			return default;
		}
	}
}
