using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;

[Serializable]
[StructLayout((LayoutKind)0, Size = 20)]
[Token(Token = "0x2000019")]
public struct WeaponParametersComponent : IComponent, IEquatable<WeaponParametersComponent>
{
	[Token(Token = "0x400006B")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
	public bool Bought;

	[Token(Token = "0x400006C")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
	public int Ammo;

	[Token(Token = "0x400006D")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
	public int Power;

	[Token(Token = "0x400006E")]
	[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
	public float Speed;

	[Token(Token = "0x400006F")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
	public float Cooldown;

	[Token(Token = "0x6000022")]
	[Address(RVA = "0x84D18C", Offset = "0x84D18C", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this + 0x10;\n\tv11 = other.Bought;\n\tv14 = 0xCCD998(v8, &v11 @ V0_v1 (System.Boolean), methodInfo, v16, v17, v18, v19, v20, other.Bought, v21, v22, v23, v24, v25, v26, v27);\n\treturnVal1 = v14 & 1;\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe bool Equals(WeaponParametersComponent other)
	{
		//IL_000b: Expected O, but got Ref
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
		bool bought = other.Bought;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CCD998 (inside WeaponObject::.ctor +0x8)");
		object obj2 = default(object);
		return (byte)((ulong)(long)(IntPtr)obj2 & 1uL) != 0;
	}

	[Token(Token = "0x6000023")]
	[Address(RVA = "0x84D1C4", Offset = "0x84D1C4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0xCCDA28(v0, obj, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
	public unsafe override bool Equals(object obj)
	{
		//IL_000b: Expected O, but got Ref
		object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CCDA28 (inside WeaponObject::.ctor +0x98)");
		bool result = default(bool);
		return result;
	}

	[Token(Token = "0x6000024")]
	[Address(RVA = "0x84D1CC", Offset = "0x84D1CC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0xCCDAC8(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
	public unsafe override int GetHashCode()
	{
		//IL_000b: Expected O, but got Ref
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CCDAC8 (inside WeaponObject::.ctor +0x138)");
		int result = default(int);
		return result;
	}

	[Token(Token = "0x6000025")]
	[Address(RVA = "0xCCDB44", Offset = "0xCCDB44", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = right.Bought;\n\tv12 = 0xCCD998(left, &v9 @ V0_v1 (System.Boolean), methodInfo, v15, v16, v17, v18, v19, right.Bought, v20, v21, v22, v23, v24, v25, v26);\n\treturnVal1 = v12 & 1;\n\treturn returnVal1;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static bool operator ==(WeaponParametersComponent left, WeaponParametersComponent right)
	{
		bool bought = right.Bought;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CCD998 (inside WeaponObject::.ctor +0x8)");
		object obj = default(object);
		return (byte)((ulong)(long)(IntPtr)obj & 1uL) != 0;
	}

	[Token(Token = "0x6000026")]
	[Address(RVA = "0xCCDB78", Offset = "0xCCDB78", Length = "0x38")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = right.Bought;\n\tv12 = 0xCCD998(left, &v9 @ V0_v1 (System.Boolean), methodInfo, v15, v16, v17, v18, v19, right.Bought, v20, v21, v22, v23, v24, v25, v26);\n\tv29 = ~v12;\n\treturnVal1 = v29 & 1;\n\treturn returnVal1;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static bool operator !=(WeaponParametersComponent left, WeaponParametersComponent right)
	{
		//IL_0025: Expected I4, but got O
		bool bought = right.Bought;
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @CCD998 (inside WeaponObject::.ctor +0x8)");
		object obj = default(object);
		int num = (int)(~obj);
		return (byte)(num & 1) != 0;
	}
}
