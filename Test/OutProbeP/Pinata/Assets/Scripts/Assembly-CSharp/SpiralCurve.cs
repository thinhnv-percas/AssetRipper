using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[ExecuteInEditMode]
[Token(Token = "0x200002B")]
public class SpiralCurve : MonoBehaviour
{
	[Token(Token = "0x4000101")]
	[FieldOffset(Offset = "0x18")]
	public float radius;

	[Token(Token = "0x4000102")]
	[FieldOffset(Offset = "0x1C")]
	public float radialStep;

	[Token(Token = "0x4000103")]
	[FieldOffset(Offset = "0x20")]
	public float heightStep;

	[Token(Token = "0x4000104")]
	[FieldOffset(Offset = "0x24")]
	public float points;

	[Token(Token = "0x4000105")]
	[FieldOffset(Offset = "0x28")]
	public float rotationalMass;

	[Token(Token = "0x4000106")]
	[FieldOffset(Offset = "0x2C")]
	public float thickness;

	[Token(Token = "0x60000E4")]
	[Address(RVA = "0xB02D6C", Offset = "0xB02D6C", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpiralCurve::Generate(this);\n\treturn;\n")]
	private void Awake()
	{
		Generate();
	}

	[Token(Token = "0x60000E5")]
	[Address(RVA = "0xB02D70", Offset = "0xB02D70", Length = "0x400")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv50 = *([1EA5570]);\n\tv51 = *([v50 @ X8_v31]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([20224CB]) = v70;\nL_002B:\n\tv79 = UnityEngine.Component::GetComponent(this);\n\tgoto L_003D;\n\tv87 = *([v83 @ X8_v5+E0]);\n\tv88 = v87 == 0;\n\tv89 = ~v88;\n\tgoto L_003D;\n\tv98 = v83;\n\tv92 = \"il2cpp_codegen_runtime_class_init\"(v98, v77, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_003D:\n\tv97 = UnityEngine.Object::op_Equality(v79, 0);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_017B;\n\tv352 = Obi.ObiActor::get_blueprint(v79);\n\tv353 = v352 == 0;\n\tif (v353) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0074;\n\tv724 = v724_asT == 0;\n\tif (v724) goto L_FFFFFFFF;\n\tgoto L_0074;\nL_0074:\n\tgoto L_007D;\n\tv732 = *([v728 @ X0_v14+E0]);\n\tv733 = v732 == 0;\n\tv734 = ~v733;\n\tgoto L_007D;\n\tv736 = \"il2cpp_codegen_runtime_class_init\"(v728, v351, v96, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_007D:\n\tv319 = UnityEngine.Object::op_Equality(v327, 0);\n\tv740 = v319 == 0;\n\tv322 = ~v740;\n\tif (v322) goto L_017B;\n\tObi.ObiPath::Clear(*([v327 @ X20_v7 (UnityEngine.Object)+100]));\n\tv754 = this.points <= 0;\n\tif (v754) goto L_0165;\nL_00AA:\n\tgoto L_00B1;\n\tv848 = *([v844 @ X0_v22 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv849 = v848 == 0;\n\tv850 = ~v849;\n\tgoto L_00B1;\n\tv852 = \"il2cpp_codegen_runtime_class_init\"(v844, v838, v837, v385, v56, v57, v58, v59, v836, v829, v830, v822, v389, v391, v66, v67);\nL_00B1:\n\tv856 = 0x6D3020(UnityEngine.Mathf, v838, v837, 0, v56, v57, v58, v59, v835, this.heightStep, this.points, v461, v929.y, v929.z, v66, v67);\n\tv860 = 0x6D2D20(v856, v838, v837, 0, v56, v57, v58, v59, v835, this.heightStep, this.points, v461, v929.y, v929.z, v66, v67);\n\tv862 = v835 * this.radius;\n\tv865 = v835 * this.radius;\n\tv868 = 0x1586898(&v443 @ stack_-B0_v7, 0, v837, 0, v56, v57, v58, v59, v862, v834, v865, v461, v929.y, v929.z, v66, v67);\n\tv437 = 0;\n\tv875 = 0x1586898(&v437 @ stack_-D0_v6, 0, v837, 0, v56, v57, v58, v59, 0, this.heightStep, v443, v461, v929.y, v929.z, v66, v67);\n\tv433 = 0;\n\tv879 = 0x158A710(&v433 @ stack_-C0_v7, 0, v837, 0, v56, v57, v58, v59, 0, this.heightStep, v443, v461, v929.y, v929.z, v66, v67);\n\tgoto L_00E2;\n\tv887 = *([v880 @ X0_v32+E0]);\n\tv888 = v887 == 0;\n\tv889 = ~v888;\n\tif (v889) goto L_00E2;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v880, v878, v837, v385, v56, v57, v58, v59, v873, v870, v871, v822, v389, v391, v66, v67);\nL_00E2:\n\t// 226 MakeStruct v429 @ AGGB02FD8_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, this.heightStep (System.Single), v443 @ stack_-B0_v7\n\tv899 = UnityEngine.Vector3::op_Multiply(v429, 1.3333334f);\n\tv907 = this.radialStep * 0.25f;\n\tv908 = 0x6D25B0(0, 0, v837, 0, v56, v57, v58, v59, v907, 0.25f, v899.z, 1.3333334f, v929.y, v929.z, v66, v67);\n\tv914 = UnityEngine.Vector3::op_Multiply(v899, v907);\n\tv919 = UnityEngine.Vector3::op_Multiply(v914, this.radius);\n\tv929 = UnityEngine.Vector3::op_UnaryNegation(v919);\n\tv933 = UnityEngine.Vector3::get_up();\n\tv475 = UnityEngine.Color::get_white();\n\t// 293 Box v939 @ X0_v42 (System.Object), typeof(System.Int32), &v461 @ X22_v7 (System.Int32)\n\tv505 = System.String::Concat(\"control point \", v939);\n\t// 328 MakeStruct v766 @ AGGB03100_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v443 @ stack_-B0_v7, v926 @ stack_-AC, 0\n\tObi.ObiPath::AddControlPoint(*([v327 @ X20_v7 (UnityEngine.Object)+100]), v766, v929, v919, v919.z, v66, v67, v933, 1, v933.z, v505);\n\tv461 = v461 + 1;\n\tv835 = v835 + this.radialStep;\n\tv834 = v834 + this.heightStep;\n\tv789 = this.points > v461;\n\tif (v789) goto L_00AA;\nL_0165:\n\tObi.ObiPath::FlushEvents(*([v327 @ X20_v7 (UnityEngine.Object)+100]));\nL_017B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 301 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void Generate()
	{
		//IL_00fc: Expected O, but got I
		//IL_039c: Expected O, but got I
		//IL_01ab: Expected O, but got I4
		//IL_01c8: Expected O, but got I4
		//IL_0206: Expected F4, but got O
		//IL_02c5: Expected F4, but got O
		//IL_02d2: Expected F4, but got O
		//IL_0329: Expected O, but got F4
		//IL_0329: Expected O, but got F4
		//IL_0329: Expected O, but got I
		ObiRopeBase component = GetComponent<ObiRopeBase>();
		if (component == null)
		{
			return;
		}
		ObiActorBlueprint blueprint = component.blueprint;
		Object obj;
		if ((object)blueprint == null)
		{
			obj = null;
		}
		else
		{
			ObiRopeBlueprintBase obiRopeBlueprintBase = blueprint as ObiRopeBlueprintBase;
			obj = (((object)obiRopeBlueprintBase == null) ? null : blueprint);
		}
		if (obj == null)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X20_v7 (UnityEngine.Object)+100]");
		((ObiPath)0).Clear();
		if (points > 0f)
		{
			float num = 0f;
			float num2 = 0f;
			int num3 = 0;
			string text = null;
			int num4 = 0;
			Vector3 vector = default(Vector3);
			object obj4 = default(object);
			Vector3 position = default(Vector3);
			object obj6 = default(object);
			float mass = default(float);
			float num8 = default(float);
			bool flag;
			do
			{
				Il2CppRuntime.Boundary("SYSTEM_API:cosf", "Method not found @6D3020 (native cosf)");
				Il2CppRuntime.Boundary("SYSTEM_API:sinf", "Method not found @6D2D20 (native sinf)");
				float num5 = num2 * radius;
				float num6 = num2 * radius;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				object obj2 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				object obj3 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
				vector.x = 0f;
				vector.y = heightStep;
				vector.z = (float)obj4;
				Vector3 vector2 = vector * 1.3333334f;
				float num7 = radialStep * 0.25f;
				Il2CppRuntime.Boundary("SYSTEM_API:tanf", "Method not found @6D25B0 (native tanf)");
				Vector3 vector3 = vector2 * num7;
				Vector3 vector4 = vector3 * radius;
				Vector3 inTangentVector = -vector4;
				Vector3 up = Vector3.up;
				Color white = Color.white;
				object obj5 = num3;
				string text2 = "control point " + obj5;
				position.x = (float)obj4;
				position.y = (float)obj6;
				position.z = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X20_v7 (UnityEngine.Object)+100]");
				((ObiPath)0).AddControlPoint(position, inTangentVector, vector4, (Vector3)vector4.z, mass, num8, up.x, 1, (Color)up.z, text2);
				num3++;
				num2 += radialStep;
				num += heightStep;
				flag = points > (float)num3;
				text = text2;
				num4 = 1;
			}
			while (flag);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v327 @ X20_v7 (UnityEngine.Object)+100]");
		((ObiPath)0).FlushEvents();
	}

	[Token(Token = "0x60000E6")]
	[Address(RVA = "0xB03170", Offset = "0xB03170", Length = "0x1C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.rotationalMass = 1f;\n\tthis.radius = *([1819210]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SpiralCurve()
	{
		//IL_0023: Expected F4, but got I
		base._002Ector();
		rotationalMass = 1f;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1819210]");
		radius = 0f;
	}
}
