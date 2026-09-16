using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74C8A8", Offset = "0x74C8A8")]
[Token(Token = "0x200001B")]
public class ColliderHighlighter : MonoBehaviour
{
	[Token(Token = "0x40000CA")]
	[FieldOffset(Offset = "0x18")]
	private ObiSolver solver;

	[Token(Token = "0x60000A5")]
	[Address(RVA = "0x9FDA08", Offset = "0x9FDA08", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAEE08]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C43]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.solver = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		ObiSolver component = GetComponent<ObiSolver>();
		solver = component;
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0x9FDA60", Offset = "0x9FDA60", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EFE708]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C44]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::add_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision += value;
	}

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0x9FDAF0", Offset = "0x9FDAF0", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE7050]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C45]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::remove_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision -= value;
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0x9FDB80", Offset = "0x9FDB80", Length = "0x1EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv34 = *([1F0A230]);\n\tv35 = *([v34 @ X8_v26]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, sender, e, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 0 | 1;\n\t*([2021C46]) = v54;\nL_001D:\n\tv237 = e.contacts;\n\tv140 = v237.data;\nL_0038:\n\tv85 = v136 >= v237.count;\n\tif (v85) goto L_00CE;\n\tv290 = v136 < v140.Length;\n\tv291 = ~v290;\n\tif (v291) goto L_00CF;\n\tv83 = v140[v299 @ X8_v10 (System.Int32)].distance >= 0.01f;\n\tif (v83) goto L_00BA;\n\tgoto L_0068;\n\tv326 = *([v312 @ X0_v12 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv327 = v326 == 0;\n\tv328 = ~v327;\n\t// 95 ConditionalJump @b42, v328 @ TEMP_v36\n\tv337 = \"il2cpp_codegen_runtime_class_init\"(v312, v75, v80, methodInfo, v39, v40, v41, v42, v87, v44, v45, v46, v47, v48, v49, v50);\n\tv330 = Obi.ObiColliderBase;\nL_0068:\n\tv340 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>::get_Item(v333.idToCollider, v140[v299 @ X8_v10 (System.Int32)].other);\n\tv341 = v340 == 0;\n\tif (v341) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0092;\n\tv381 = v381_asT == 0;\n\tif (v381) goto L_FFFFFFFF;\n\tgoto L_0092;\nL_0092:\n\tgoto L_009B;\n\tv389 = *([v385 @ X0_v16+E0]);\n\tv390 = v389 == 0;\n\tv391 = ~v390;\n\tgoto L_009B;\n\tv393 = \"il2cpp_codegen_runtime_class_init\"(v385, v339, v338, methodInfo, v39, v40, v41, v42, v87, v44, v45, v46, v47, v48, v49, v50);\nL_009B:\n\tv160 = UnityEngine.Object::op_Inequality(v175, 0);\n\tv319 = v160 == 0;\n\tif (v319) goto L_00BA;\n\tv399 = UnityEngine.Component::GetComponent(v175);\n\tgoto L_00B2;\n\tv403 = *([v171 @ X8_v19+E0]);\n\tv404 = v403 == 0;\n\tv405 = ~v404;\n\tif (v405) goto L_00B2;\n\tv410 = v171;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v410, v397, v81, methodInfo, v39, v40, v41, v42, v87, v44, v45, v46, v47, v48, v49, v50);\nL_00B2:\n\tv161 = UnityEngine.Object::op_Implicit(v399);\n\tv320 = v161 == 0;\n\tif (v320) goto L_00BA;\n\tBlinker::Blink(v399);\nL_00BA:\n\tv237 = e.contacts;\n\tv136 = v136 + 1;\n\tv322 = e.contacts == 0;\n\tv163 = ~v322;\n\tif (v163) goto L_0038;\n\tthrow System.NullReferenceException;\nL_00CE:\n\treturn;\nL_00CF:\n\tv311 = new System.IndexOutOfRangeException();\n\tthrow v311;\n\tthrow System.NullReferenceException;\n// 152 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Solver_OnCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
	{
		ObiList<Oni.Contact> contacts = e.contacts;
		Oni.Contact[] data = contacts.Data;
		int num = 0;
		int num2 = default(int);
		while (true)
		{
			if (num >= contacts.Count)
			{
				return;
			}
			if (num >= data.Length)
			{
				break;
			}
			if (data[num2].distance < 0.01f)
			{
				Component component = ObiColliderBase.idToCollider.get_Item(data[num2].other);
				UnityEngine.Object obj;
				if ((object)component == null)
				{
					obj = null;
				}
				else
				{
					Collider collider = component as Collider;
					obj = (((object)collider == null) ? null : component);
				}
				if (obj != null)
				{
					Blinker component2 = ((Component)obj).GetComponent<Blinker>();
					if ((bool)component2)
					{
						component2.Blink();
					}
				}
			}
			contacts = e.contacts;
			num++;
			if (e.contacts == null)
			{
				throw new NullReferenceException();
			}
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x60000A9")]
	[Address(RVA = "0x9FDD6C", Offset = "0x9FDD6C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ColliderHighlighter()
	{
	}
}
