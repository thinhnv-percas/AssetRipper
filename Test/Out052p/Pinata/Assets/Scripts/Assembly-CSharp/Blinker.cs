using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x200001A")]
public class Blinker : MonoBehaviour
{
	[Token(Token = "0x40000C7")]
	[FieldOffset(Offset = "0x18")]
	public Color highlightColor;

	[Token(Token = "0x40000C8")]
	[FieldOffset(Offset = "0x28")]
	private Renderer rend;

	[Token(Token = "0x40000C9")]
	[FieldOffset(Offset = "0x30")]
	private Color original;

	[Token(Token = "0x60000A1")]
	[Address(RVA = "0x9FCE2C", Offset = "0x9FCE2C", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED3008]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C3E]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.rend = v43;\n\tv46 = UnityEngine.Renderer::get_material(v43);\n\tv53 = UnityEngine.Material::get_color(v46);\n\tthis.original = v53;\n\tthis.original.g = v53.g;\n\tthis.original.b = v53.b;\n\tthis.original.a = v53.a;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		Material material = (rend = GetComponent<Renderer>()).material;
		Color color = (original = material.color);
		original.g = color.g;
		original.b = color.b;
		original.a = color.a;
	}

	[Token(Token = "0x60000A2")]
	[Address(RVA = "0x9FCEA8", Offset = "0x9FCEA8", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = UnityEngine.Renderer::get_material(this.rend);\n\t// 22 MakeStruct v42 @ AGG9FCEE0_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.highlightColor (UnityEngine.Color), this.highlightColor.g (System.Single), this.highlightColor.b (System.Single), this.highlightColor.a (System.Single)\n\tUnityEngine.Material::set_color(v13, v42);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Blink()
	{
		Material material = rend.material;
		Color color = default(Color);
		color.r = highlightColor.r;
		color.g = highlightColor.g;
		color.b = highlightColor.b;
		color.a = highlightColor.a;
		material.color = color;
	}

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0x9FCEE8", Offset = "0x9FCEE8", Length = "0x130")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = UnityEngine.Renderer::get_material(this.rend);\n\tv59 = UnityEngine.Material::get_color(v31);\n\tv72 = UnityEngine.Renderer::get_material(this.rend);\n\tv152 = UnityEngine.Material::get_color(v72);\n\t// 58 MakeStruct v106 @ AGG9FCF84_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.original (UnityEngine.Color), this.original.g (System.Single), this.original.b (System.Single), this.original.a (System.Single)\n\tv165 = UnityEngine.Color::op_Subtraction(v106, v152);\n\tv174 = UnityEngine.Time::get_deltaTime();\n\tv181 = UnityEngine.Color::op_Multiply(v165, v174);\n\tv187 = UnityEngine.Color::op_Multiply(v181, 5f);\n\tv139 = UnityEngine.Color::op_Addition(v59, v187);\n\tUnityEngine.Material::set_color(v31, v139);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 109 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void LateUpdate()
	{
		Material material = rend.material;
		Color color = material.color;
		Material material2 = rend.material;
		Color color2 = material2.color;
		Color color3 = default(Color);
		color3.r = original.r;
		color3.g = original.g;
		color3.b = original.b;
		color3.a = original.a;
		Color color4 = color3 - color2;
		float deltaTime = Time.deltaTime;
		Color color5 = color4 * deltaTime;
		Color color6 = color5 * 5f;
		Color color7 = color + color6;
		material.color = color7;
	}

	[Token(Token = "0x60000A4")]
	[Address(RVA = "0x9FD018", Offset = "0x9FD018", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public Blinker()
	{
	}
}
