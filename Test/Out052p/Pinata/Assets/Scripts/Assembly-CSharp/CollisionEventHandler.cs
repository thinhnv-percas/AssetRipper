using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74C90C", Offset = "0x74C90C")]
[Token(Token = "0x200001C")]
public class CollisionEventHandler : MonoBehaviour
{
	[Token(Token = "0x40000CB")]
	[FieldOffset(Offset = "0x18")]
	private ObiSolver solver;

	[Token(Token = "0x40000CC")]
	[FieldOffset(Offset = "0x20")]
	private ObiSolver.ObiCollisionEventArgs frame;

	[Token(Token = "0x60000AA")]
	[Address(RVA = "0x9FDD74", Offset = "0x9FDD74", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBE9F0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C47]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.solver = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		ObiSolver component = GetComponent<ObiSolver>();
		solver = component;
	}

	[Token(Token = "0x60000AB")]
	[Address(RVA = "0x9FDDCC", Offset = "0x9FDDCC", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC4D88]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C48]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::add_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision += value;
	}

	[Token(Token = "0x60000AC")]
	[Address(RVA = "0x9FDE5C", Offset = "0x9FDE5C", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EA9170]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C49]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::remove_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision -= value;
	}

	[Token(Token = "0x60000AD")]
	[Address(RVA = "0x9FDEEC", Offset = "0x9FDEEC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.frame = e;\n\treturn;\n")]
	private void Solver_OnCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
	{
		frame = e;
	}

	[Token(Token = "0x60000AE")]
	[Address(RVA = "0x9FDEF4", Offset = "0x9FDEF4", Length = "0x304")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0022;\n\tv44 = *([1EE3FC8]);\n\tv45 = *([v44 @ X8_v38]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([2021C4A]) = v64;\nL_0022:\n\t*([v34 @ X29_v1-88]) = 0;\n\t*([v34 @ X29_v1-90]) = 0;\n\tgoto L_0032;\n\tv72 = *([v68 @ X0_v2+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tgoto L_0032;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v68, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\nL_0032:\n\tv82 = UnityEngine.Object::op_Equality(this.solver, 0);\n\tv84 = v82 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0147;\n\tv86 = this.frame;\n\tv87 = this.frame == 0;\n\tif (v87) goto L_0147;\n\tv285 = v86.contacts == 0;\n\tif (v285) goto L_0147;\n\tv442 = UnityEngine.Component::get_transform(this.solver);\n\tv504 = UnityEngine.Transform::get_localToWorldMatrix(v442);\n\tv272 = v504.m00;\n\tUnityEngine.Gizmos::set_matrix(&v272 @ stack_-160_v3 (System.Single));\n\tv594 = this.frame;\nL_006E:\n\tv290 = v594.contacts;\n\tv153 = v293 >= v290.count;\n\tif (v153) goto L_0147;\n\tv584 = v290.data;\n\tv596 = v293 < v584.Length;\n\tv597 = ~v596;\n\tif (v597) goto L_0148;\n\tv464 = v584[v293 @ X20_v8 (System.Int32)].distance >= 0;\n\tif (v464) goto L_00A0;\n\tv562 = UnityEngine.Color::get_red();\n\tv565 = v562.g;\n\tv556 = v562.b;\n\tv559 = v562.a;\n\tgoto L_00A5;\nL_00A0:\n\tv562 = UnityEngine.Color::get_green();\n\tv565 = v562.g;\n\tv556 = v562.b;\n\tv559 = v562.a;\nL_00A5:\n\t// 165 MakeStruct v444 @ AGG9FE050_0_v6 (UnityEngine.Color), typeof(UnityEngine.Color), v562 @ V0_v8 (UnityEngine.Color), v565 @ V1_v7 (System.Single), v556 @ V2_v7 (System.Single), v559 @ V3_v7 (System.Single)\n\tUnityEngine.Gizmos::set_color(v444);\n\tv585 = this.frame;\n\tv586 = v585.contacts;\n\tv587 = v586.data;\n\tv620 = v293 < v587.Length;\n\tv551 = ~v620;\n\tif (v551) goto L_0148;\n\tv526 = v293 << 7;\n\tv622 = v587 + v526;\n\tgoto L_00D0;\n\tv628 = *([v621 @ X0_v22+E0]);\n\tv629 = v628 == 0;\n\tv630 = ~v629;\n\tif (v630) goto L_00D0;\n\tv632 = \"il2cpp_codegen_runtime_class_init\"(v621, v279, v276, v49, v50, v51, v52, v53, v562, v565, v556, v559, v105, v102, v60, v61);\nL_00D0:\n\t// 208 MakeStruct v450 @ AGG9FE0B0_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v622 @ X8_v22+20], v587[v293 @ X20_v8 (System.Int32)].point.y (System.Single), v587[v293 @ X20_v8 (System.Int32)].point.z (System.Single), v587[v293 @ X20_v8 (System.Int32)].point.w (System.Single)\n\tv563 = UnityEngine.Vector4::op_Implicit(v450);\n\tv588 = this.frame;\n\tv589 = v588.contacts;\n\tv590 = v589.data;\n\tv638 = v293 < v590.Length;\n\tv480 = ~v638;\n\tif (v480) goto L_0148;\n\t// 242 MakeStruct v448 @ AGG9FE0F4_0_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v590[v293 @ X20_v8 (System.Int32)].normal (UnityEngine.Vector4), v590[v293 @ X20_v8 (System.Int32)].normal.y (System.Single), v590[v293 @ X20_v8 (System.Int32)].normal.z (System.Single), v590[v293 @ X20_v8 (System.Int32)].normal.w (System.Single)\n\tv645 = UnityEngine.Vector4::op_Implicit(v448);\n\t*([v34 @ X29_v1-90]) = v645;\n\t*([v34 @ X29_v1-8C]) = v645.y;\n\t*([v34 @ X29_v1-88]) = v645.z;\n\tUnityEngine.Gizmos::DrawSphere(v563, 0.025f);\n\tv649 = &v35 @ stack_-10_v2 - 0x90;\n\tv573 = 0x158A710(v649, 0, v276, v49, v50, v51, v52, v53, v563, v563.y, v563.z, 0.025f, v669.y, v669.z, v60, v61);\n\tv501 = this.frame;\n\tv651 = Obi.ObiList`1<Oni+Contact>::get_Item(v501.contacts, v293);\n\tgoto L_0121;\n\tv657 = *([v652 @ X0_v31+E0]);\n\tv658 = v657 == 0;\n\tv659 = ~v658;\n\tif (v659) goto L_0121;\n\tv661 = \"il2cpp_codegen_runtime_class_init\"(v652, v568, v567, v49, v50, v51, v52, v53, v488, v490, v484, v486, v105, v102, v60, v61);\nL_0121:\n\tv669 = UnityEngine.Vector3::op_Multiply(v563, v653);\n\tUnityEngine.Gizmos::DrawRay(v563, v669);\n\tv594 = this.frame;\n\tv293 = v293 + 1;\n\tv672 = this.frame == 0;\n\tv574 = ~v672;\n\tif (v574) goto L_006E;\n\tthrow System.NullReferenceException;\nL_0147:\n\treturn;\nL_0148:\n\tv611 = new System.IndexOutOfRangeException();\n\tthrow v611;\n\tthrow System.NullReferenceException;\n// 235 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private unsafe void OnDrawGizmos()
	{
		//IL_00c7: Expected O, but got Ref
		//IL_00e0: Expected I, but got O
		//IL_0252: Expected O, but got I
		//IL_026d: Expected F4, but got I
		//IL_03ff: Expected O, but got I
		object obj2 = default(object);
		object obj = obj2;
		_ = 0;
		_ = 0;
		if (solver == null)
		{
			return;
		}
		ObiSolver.ObiCollisionEventArgs e = frame;
		if (frame == null || e.contacts == null)
		{
			return;
		}
		Transform transform = solver.transform;
		float m = transform.localToWorldMatrix.m00;
		Gizmos.matrix = (Matrix4x4)(&m);
		ObiSolver.ObiCollisionEventArgs e2 = frame;
		IntPtr intPtr = (IntPtr)null;
		int num = 0;
		Color color2 = default(Color);
		Vector4 vector = default(Vector4);
		Vector4 vector3 = default(Vector4);
		float num3 = default(float);
		while (true)
		{
			ObiList<Oni.Contact> contacts = e2.contacts;
			if (num < contacts.Count)
			{
				Oni.Contact[] data = contacts.Data;
				if (num >= data.Length)
				{
					break;
				}
				Color color;
				float g;
				float b;
				float a;
				if (data[num].distance < 0f)
				{
					color = Color.red;
					g = color.g;
					b = color.b;
					a = color.a;
				}
				else
				{
					color = Color.green;
					g = color.g;
					b = color.b;
					a = color.a;
				}
				color2.r = color.r;
				color2.g = g;
				color2.b = b;
				color2.a = a;
				Gizmos.color = color2;
				ObiSolver.ObiCollisionEventArgs e3 = frame;
				ObiList<Oni.Contact> contacts2 = e3.contacts;
				Oni.Contact[] data2 = contacts2.Data;
				if (num >= data2.Length)
				{
					break;
				}
				int num2 = num << 7;
				object obj3 = (long)(IntPtr)data2 + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v622 @ X8_v22+20]");
				vector.x = 0f;
				vector.y = data2[num].point.y;
				vector.z = data2[num].point.z;
				vector.w = data2[num].point.w;
				Vector3 vector2 = vector;
				ObiSolver.ObiCollisionEventArgs e4 = frame;
				ObiList<Oni.Contact> contacts3 = e4.contacts;
				Oni.Contact[] data3 = contacts3.Data;
				if (num >= data3.Length)
				{
					break;
				}
				vector3.x = data3[num].normal.x;
				vector3.y = data3[num].normal.y;
				vector3.z = data3[num].normal.z;
				vector3.w = data3[num].normal.w;
				Vector3 vector4 = vector3;
				_ = vector4.y;
				_ = vector4.z;
				Gizmos.DrawSphere(vector2, 0.025f);
				object obj4 = (long)(IntPtr)obj2 - 144L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
				ObiSolver.ObiCollisionEventArgs e5 = frame;
				Oni.Contact contact = e5.contacts.get_Item(num);
				Vector3 direction = vector2 * num3;
				Gizmos.DrawRay(vector2, direction);
				e2 = frame;
				num++;
				bool flag = frame == null;
				bool flag2 = !flag;
				intPtr = (IntPtr)0;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x60000AF")]
	[Address(RVA = "0x9FE1F8", Offset = "0x9FE1F8", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CollisionEventHandler()
	{
	}
}
