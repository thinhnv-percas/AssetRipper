using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200004B")]
	public abstract class IInterpolation
	{
		[Token(Token = "0x40001D4")]
		public static IInterpolation Pow2;

		[Token(Token = "0x40001D5")]
		public static IInterpolation Pow2Out;

		[Token(Token = "0x60002F1")]
		protected abstract float Apply(float a);

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x1533340", Offset = "0x1533340", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Spine.IInterpolation::Apply(this, a);\n\tv29 = end - start;\n\tv30 = v29 * a;\n\treturnVal1 = v30 + start;\n\treturn returnVal1;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float Apply(float start, float end, float a)
		{
			float num = Apply(a);
			float num2 = end - start;
			float num3 = num2 * a;
			return num3 + start;
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x1533378", Offset = "0x1533378", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal IInterpolation()
		{
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0x1533380", Offset = "0x1533380", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Spine.IInterpolation;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv47 = Spine.PowOut;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Spine.Pow;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv43 = 1;\n\t*([1A37B67]) = v43;\nL_001E:\n\tv45 = new Spine.Pow();\n\tSpine.Pow::.ctor(v45, 2f);\n\tv54.Pow2 = v45;\n\tv56 = new Spine.PowOut();\n\tSpine.Pow::.ctor(v56, 2f);\n\tv62.Pow2Out = v56;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static IInterpolation()
		{
			Pow pow = new Pow(2f);
			Pow2 = pow;
			PowOut pow2Out = (PowOut)new Pow(2f);
			Pow2Out = pow2Out;
		}
	}
}
