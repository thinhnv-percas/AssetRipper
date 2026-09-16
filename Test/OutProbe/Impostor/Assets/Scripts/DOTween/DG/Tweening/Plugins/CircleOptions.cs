using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[Token(Token = "0x2000073")]
	public struct CircleOptions : IPlugOptions
	{
		[Token(Token = "0x4000159")]
		[FieldOffset(Offset = "0x0")]
		public float endValueDegrees;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x4")]
		public bool relativeCenter;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x5")]
		public bool snapping;

		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x8")]
		internal Vector2 center;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x10")]
		internal float radius;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x14")]
		internal float startValueDegrees;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x18")]
		internal bool initialized;

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0xC1CC9C", Offset = "0xC1CC9C", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initialized = 0;\n\tthis.endValueDegrees = 0f;\n\tthis.startValueDegrees = 0f;\n\tthis.relativeCenter = 0;\n\treturn;\n")]
		public void Reset()
		{
			initialized = false;
			endValueDegrees = 0f;
			startValueDegrees = 0f;
			relativeCenter = false;
			snapping = false;
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0xC1CCB0", Offset = "0xC1CCB0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.initialized = 1;\n\tthis.center = endValue;\n\t*([this @ X0 (DG.Tweening.Plugins.CircleOptions)+C]) = endValue.y;\n\tv26 = ~this.relativeCenter;\n\tif (v26) goto L_001E;\n\tv27 = startValue + endValue;\n\tv30 = startValue.y + endValue.y;\n\tthis.center = v27;\n\t*([this @ X0 (DG.Tweening.Plugins.CircleOptions)+C]) = v30;\nL_001E:\n\tgoto L_0026;\n\tv36 = System.Math;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, startValue, v0, endValue, v2, v45, v46, v47, v48);\n\tv51 = 1;\n\t*([1A3575D]) = v51;\nL_0026:\n\tv54 = v27 - startValue;\n\tv55 = v30 - startValue.y;\n\tgoto L_0030;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v56, methodInfo, v39, v40, v41, v42, v43, v44, startValue, v0, endValue, v2, v45, v46, v47, v48);\nL_0030:\n\tv64 = v54 * v54;\n\tv65 = v55 * v55;\n\tv66 = v64 + v65;\n\tv67 = UnityEngine.Mathf::Sqrt(v66);\n\tthis.radius = v67;\n\tv68 = startValue - this.center;\n\tv69 = startValue.y - *([this @ X0 (DG.Tweening.Plugins.CircleOptions)+C]);\n\tv70 = 0x1854F00(System.Math, methodInfo, v39, v40, v41, v42, v43, v44, v68, v69, this.center, *([this @ X0 (DG.Tweening.Plugins.CircleOptions)+C]), v45, v46, v47, v48);\n\tv76 = v68 * 57.29578f;\n\tthis.startValueDegrees = v76;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize(Vector2 startValue, Vector2 endValue)
		{
			//IL_0090: Expected O, but got F4
			initialized = true;
			center = endValue;
			_ = endValue.y;
			bool flag = !relativeCenter;
			Vector2 vector = default(Vector2);
			float num = vector.x;
			float num2 = endValue.y;
			Vector2 vector2 = default(Vector2);
			if (!flag)
			{
				num = vector2.x + vector.x;
				num2 = startValue.y + endValue.y;
				center = (Vector2)num;
			}
			float num3 = num - vector2.x;
			float num4 = num2 - startValue.y;
			float num5 = num3 * num3;
			float num6 = num4 * num4;
			float f = num5 + num6;
			float num7 = Mathf.Sqrt(f);
			radius = num7;
			float num8 = vector2.x - center.x;
			float num9 = startValue.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Plugins.CircleOptions)+C]");
			float num10 = num9 - 0f;
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @1854F00 (native atan2f)");
			float num11 = num8 * 57.29578f;
			startValueDegrees = num11;
		}
	}
}
