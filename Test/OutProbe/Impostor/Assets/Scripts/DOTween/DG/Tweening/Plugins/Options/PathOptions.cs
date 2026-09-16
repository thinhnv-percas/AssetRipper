using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x2000089")]
	public struct PathOptions : IPlugOptions
	{
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x0")]
		public PathMode mode;

		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x4")]
		public OrientType orientType;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x8")]
		public AxisConstraint lockPositionAxis;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0xC")]
		public AxisConstraint lockRotationAxis;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x10")]
		public bool isClosedPath;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x14")]
		public Vector3 lookAtPosition;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x20")]
		public Transform lookAtTransform;

		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x28")]
		public float lookAhead;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x2C")]
		public bool hasCustomForwardDirection;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x30")]
		public Quaternion forward;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x40")]
		public bool useLocalPosition;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x48")]
		public Transform parent;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x50")]
		public bool isRigidbody;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x51")]
		public bool isRigidbody2D;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x52")]
		public bool stableZRotation;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x54")]
		internal Quaternion startupRot;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x64")]
		internal float startupZRot;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x68")]
		internal bool addedExtraStartWp;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x69")]
		internal bool addedExtraEndWp;

		[Token(Token = "0x600036B")]
		[Address(RVA = "0xC28154", Offset = "0xC28154", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mode = 0;\n\tthis.lockPositionAxis = 0;\n\tthis.isClosedPath = 0;\n\tgoto L_0015;\n\tv13 = UnityEngine.Vector3;\n\tv14 = \"il2cpp_codegen_initialize_runtime_metadata\"(v13, methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv32 = 1;\n\t*([1A35519]) = v32;\nL_0015:\n\tv36 = UnityEngine.Vector3;\n\tv37 = *([v36 @ X8_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tthis.lookAtTransform = 0;\n\tthis.lookAhead = 0f;\n\tthis.hasCustomForwardDirection = 0;\n\tthis.lookAtPosition = v37.zeroVector;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.PathOptions)+1C]) = *([v37 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tgoto L_002C;\n\tv44 = UnityEngine.Quaternion;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, methodInfo, v16, v17, v18, v19, v20, v21, v38, v39, v24, v25, v26, v27, v28, v29);\n\tv48 = 1;\n\t*([1A3551A]) = v48;\nL_002C:\n\tthis.useLocalPosition = 0;\n\tthis.parent = 0;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.PathOptions)+4F]) = 0;\n\tthis.forward = v52.identityQuaternion;\n\tthis.startupZRot = 0f;\n\tthis.addedExtraStartWp = 0;\n\tthis.startupRot = v54.identityQuaternion;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			//IL_0046: Expected I, but got O
			//IL_004f: Expected I, but got O
			mode = default(PathMode);
			lockPositionAxis = default(AxisConstraint);
			isClosedPath = false;
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			lookAtTransform = null;
			lookAhead = 0f;
			hasCustomForwardDirection = false;
			lookAtPosition = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			useLocalPosition = false;
			parent = null;
			_ = 0;
			forward = Quaternion.identity;
			startupZRot = 0f;
			addedExtraStartWp = false;
			addedExtraEndWp = false;
			startupRot = Quaternion.identity;
		}
	}
}
