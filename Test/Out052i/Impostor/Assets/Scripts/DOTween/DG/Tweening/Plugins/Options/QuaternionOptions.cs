using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Options
{
	[Token(Token = "0x200008A")]
	public struct QuaternionOptions : IPlugOptions
	{
		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x0")]
		public RotateMode rotateMode;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x4")]
		public AxisConstraint axisConstraint;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x8")]
		public Vector3 up;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x14")]
		public bool dynamicLookAt;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x18")]
		public Vector3 dynamicLookAtWorldPosition;

		[Token(Token = "0x600036C")]
		[Address(RVA = "0xC28218", Offset = "0xC28218", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotateMode = 0;\n\tgoto L_0012;\n\tv13 = UnityEngine.Vector3;\n\tv14 = \"il2cpp_codegen_initialize_runtime_metadata\"(v13, methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29);\n\tv32 = 1;\n\t*([1A35519]) = v32;\nL_0012:\n\tv35 = UnityEngine.Vector3;\n\tv36 = *([v35 @ X8_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tthis.dynamicLookAt = 0;\n\tthis.up = v36.zeroVector;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.QuaternionOptions)+10]) = *([v36 @ X9_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\tv39 = *([v35 @ X8_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]);\n\tthis.dynamicLookAtWorldPosition = v39.zeroVector;\n\t*([this @ X0 (DG.Tweening.Plugins.Options.QuaternionOptions)+20]) = *([v39 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			//IL_0027: Expected I, but got O
			//IL_0030: Expected I, but got O
			//IL_005c: Expected I, but got O
			rotateMode = default(RotateMode);
			nint num = (nint)typeof(Vector3);
			nint num2 = (nint)Vector3.zero;
			dynamicLookAt = false;
			up = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X9_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
			nint num3 = (nint)Vector3.zero;
			dynamicLookAtWorldPosition = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			_ = 0;
		}
	}
}
