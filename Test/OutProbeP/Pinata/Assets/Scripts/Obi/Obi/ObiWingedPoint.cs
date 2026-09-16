using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 40)]
	[Token(Token = "0x200007B")]
	public struct ObiWingedPoint
	{
		[Token(Token = "0x20000CC")]
		public enum TangentMode
		{
			[Token(Token = "0x4000358")]
			Aligned = 0,
			[Token(Token = "0x4000359")]
			Mirrored = 1,
			[Token(Token = "0x400035A")]
			Free = 2
		}

		[Token(Token = "0x400020E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public TangentMode tangentMode;

		[Token(Token = "0x400020F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public Vector3 inTangent;

		[Token(Token = "0x4000210")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public Vector3 position;

		[Token(Token = "0x4000211")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public Vector3 outTangent;

		[Token(Token = "0x170000C7")]
		public unsafe Vector3 inTangentEndpoint
		{
			[Token(Token = "0x60004CF")]
			[Address(RVA = "0x85608C", Offset = "0x85608C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1034048(v0, methodInfo, v4, v5, v6, v7, v8, v9, returnVal1, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
			get
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034048 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0xB0)");
				Vector3 result = default(Vector3);
				return result;
			}
		}

		[Token(Token = "0x170000C8")]
		public unsafe Vector3 outTangentEndpoint
		{
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0x856094", Offset = "0x856094", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x10340E8(v0, methodInfo, v4, v5, v6, v7, v8, v9, returnVal1, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
			get
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10340E8 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x150)");
				Vector3 result = default(Vector3);
				return result;
			}
		}

		[Token(Token = "0x60004D1")]
		[Address(RVA = "0x85609C", Offset = "0x85609C", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.position = 0;\n\t*([this @ X0 (Obi.ObiWingedPoint)+14]) = inTangent;\n\t*([this @ X0 (Obi.ObiWingedPoint)+18]) = inTangent.y;\n\tthis.outTangent = inTangent.z;\n\t*([this @ X0 (Obi.ObiWingedPoint)+20]) = point;\n\t*([this @ X0 (Obi.ObiWingedPoint)+24]) = point.y;\n\t*([this @ X0 (Obi.ObiWingedPoint)+28]) = point.z;\n\t*([this @ X0 (Obi.ObiWingedPoint)+2C]) = outTangent;\n\t*([this @ X0 (Obi.ObiWingedPoint)+30]) = v7;\n\t*([this @ X0 (Obi.ObiWingedPoint)+34]) = v9;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiWingedPoint(Vector3 inTangent, Vector3 point, Vector3 outTangent)
		{
			//IL_0032: Expected O, but got F4
			position = default(Vector3);
			_ = inTangent.y;
			this.outTangent = (Vector3)inTangent.z;
			_ = point.y;
			_ = point.z;
		}

		[Token(Token = "0x60004D2")]
		[Address(RVA = "0x8560C0", Offset = "0x8560C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this + 0x10;\n\tv5 = 0x10341AC(v3, methodInfo, v7, v8, v9, v10, v11, v12, value, value.y, value.z, v13, v14, v15, v16, v17);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetInTangentEndpoint(Vector3 value)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10341AC (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x214)");
		}

		[Token(Token = "0x60004D3")]
		[Address(RVA = "0x8560C8", Offset = "0x8560C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this + 0x10;\n\tv5 = 0x1034364(v3, methodInfo, v7, v8, v9, v10, v11, v12, value, value.y, value.z, v13, v14, v15, v16, v17);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetOutTangentEndpoint(Vector3 value)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1034364 (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x3CC)");
		}

		[Token(Token = "0x60004D4")]
		[Address(RVA = "0x8560D0", Offset = "0x8560D0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this + 0x10;\n\tv18 = 0x103451C(v13, methodInfo, v20, v21, v22, v23, v24, v25, translation, translation.y, translation.z, rotation, rotation.y, rotation.z, rotation.w, v8);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Transform(Vector3 translation, Quaternion rotation, Vector3 scale)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @103451C (inside Obi.ObiVolumeConstraintsBatch::SetParameters +0x584)");
		}
	}
}
