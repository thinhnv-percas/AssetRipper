using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x2000031")]
	public struct PathOptions : IPlugOptions
	{
		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x0")]
		public PathMode mode;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x4")]
		public OrientType orientType;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x8")]
		public AxisConstraint lockPositionAxis;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0xC")]
		public AxisConstraint lockRotationAxis;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x10")]
		public bool isClosedPath;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x14")]
		public Vector3 lookAtPosition;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x20")]
		public Transform lookAtTransform;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x28")]
		public float lookAhead;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x2C")]
		public bool hasCustomForwardDirection;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x30")]
		public Quaternion forward;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x40")]
		public bool useLocalPosition;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x48")]
		public Transform parent;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x50")]
		public bool isRigidbody;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x54")]
		internal Quaternion startupRot;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x64")]
		internal float startupZRot;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x68")]
		internal bool addedExtraStartWp;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x69")]
		internal bool addedExtraEndWp;

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x85686C", Offset = "0x85686C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1084C88(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe void Reset()
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1084C88 (inside DG.Tweening.Plugins.LongPlugin::.ctor +0x64)");
		}
	}
}
