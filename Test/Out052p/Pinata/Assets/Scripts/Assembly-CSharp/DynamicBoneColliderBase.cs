using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000005")]
public class DynamicBoneColliderBase : MonoBehaviour
{
	[Token(Token = "0x2000452")]
	public enum Direction
	{
		[Token(Token = "0x4002056")]
		X = 0,
		[Token(Token = "0x4002057")]
		Y = 1,
		[Token(Token = "0x4002058")]
		Z = 2
	}

	[Token(Token = "0x2000453")]
	public enum Bound
	{
		[Token(Token = "0x400205A")]
		Outside = 0,
		[Token(Token = "0x400205B")]
		Inside = 1
	}

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763D18", Offset = "0x763D18")]
	[Token(Token = "0x4000027")]
	[FieldOffset(Offset = "0x18")]
	public Direction m_Direction;

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763D50", Offset = "0x763D50")]
	[Token(Token = "0x4000028")]
	[FieldOffset(Offset = "0x1C")]
	public Vector3 m_Center;

	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x763D88", Offset = "0x763D88")]
	[Token(Token = "0x4000029")]
	[FieldOffset(Offset = "0x28")]
	public Bound m_Bound;

	[Token(Token = "0x6000024")]
	[Address(RVA = "0xA02DB4", Offset = "0xA02DB4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public virtual bool Collide(ref Vector3 particlePosition, float particleRadius)
	{
		return false;
	}

	[Token(Token = "0x6000025")]
	[Address(RVA = "0xA02D34", Offset = "0xA02D34", Length = "0x80")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ED7290]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C6C]) = v38;\nL_0014:\n\tthis.m_Direction = 1;\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv54 = UnityEngine.Vector3::get_zero();\n\tthis.m_Center = v54;\n\tthis.m_Center.y = v54.y;\n\tthis.m_Center.z = v54.z;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DynamicBoneColliderBase()
	{
		m_Direction = Direction.Y;
		Vector3 vector = (m_Center = Vector3.zero);
		m_Center.y = vector.y;
		m_Center.z = vector.z;
	}
}
