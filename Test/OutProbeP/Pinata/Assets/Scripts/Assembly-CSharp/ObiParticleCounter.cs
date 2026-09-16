using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Obi;
using UnityEngine;

[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74CA48", Offset = "0x74CA48")]
[Token(Token = "0x2000020")]
public class ObiParticleCounter : MonoBehaviour
{
	[Token(Token = "0x40000DA")]
	[FieldOffset(Offset = "0x18")]
	private ObiSolver solver;

	[Token(Token = "0x40000DB")]
	[FieldOffset(Offset = "0x20")]
	public int counter;

	[Token(Token = "0x40000DC")]
	[FieldOffset(Offset = "0x28")]
	public Collider2D targetCollider;

	[Token(Token = "0x40000DD")]
	[FieldOffset(Offset = "0x30")]
	private ObiSolver.ObiCollisionEventArgs frame;

	[Token(Token = "0x40000DE")]
	[FieldOffset(Offset = "0x38")]
	private HashSet<int> particles;

	[Token(Token = "0x60000BD")]
	[Address(RVA = "0x98ECE8", Offset = "0x98ECE8", Length = "0x58")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF88C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021705]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.solver = v43;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Awake()
	{
		ObiSolver component = GetComponent<ObiSolver>();
		solver = component;
	}

	[Token(Token = "0x60000BE")]
	[Address(RVA = "0x98ED40", Offset = "0x98ED40", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED0F98]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021706]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::add_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnEnable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision += value;
	}

	[Token(Token = "0x60000BF")]
	[Address(RVA = "0x98EDD0", Offset = "0x98EDD0", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EECFA0]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021707]) = v40;\nL_0018:\n\tv45 = new Obi.ObiSolver+CollisionCallback();\n\tObi.ObiSolver+CollisionCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiSolver::remove_OnCollision(this.solver, v45);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void OnDisable()
	{
		ObiSolver.CollisionCallback value = Solver_OnCollision;
		solver.OnCollision -= value;
	}

	[Token(Token = "0x60000C0")]
	[Address(RVA = "0x98EE60", Offset = "0x98EE60", Length = "0x278")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv38 = *([1EFCC40]);\n\tv39 = *([v38 @ X8_v37]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, sender, e, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2021708]) = v57;\nL_0021:\n\tv62 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v62);\n\tv68 = e.contacts;\nL_003F:\n\tv98 = v186 >= v68.count;\n\tif (v98) goto L_00C3;\n\tv203 = v68.data;\n\tv319 = v186 < v203.Length;\n\tv320 = ~v319;\n\tif (v320) goto L_00F2;\n\tv96 = v203[v112 @ X28_v7 (System.Int32)].distance >= 0.001f;\n\tif (v96) goto L_00B5;\n\tgoto L_006C;\n\tv204 = *([v403 @ X0_v22 (Il2CppClass<Obi.ObiColliderBase>)+E0]);\n\tv427 = v204 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_006C;\n\tv233 = v30.contacts;\n\tv429 = Obi.ObiColliderBase;\nL_006C:\n\tv237 = v68.data;\n\tv433 = v186 < v237.Length;\n\tv176 = ~v433;\n\tif (v176) goto L_00F2;\n\tv413 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Component>::TryGetValue(v205.idToCollider, v237[v112 @ X28_v7 (System.Int32)].other, &v83 @ stack_-68_v8 (UnityEngine.Component));\n\tv415 = v413 == 0;\n\tif (v415) goto L_00B5;\n\tgoto L_0096;\n\tv439 = *([v435 @ X0_v26+E0]);\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_0096;\n\tv443 = \"il2cpp_codegen_runtime_class_init\"(v435, v411, v408, v93, v43, v44, v45, v46, v101, v48, v49, v50, v51, v52, v53, v54);\nL_0096:\n\tv218 = UnityEngine.Object::op_Equality(v83, this.targetCollider);\n\tv416 = v218 == 0;\n\tif (v416) goto L_00B5;\n\tv68 = e.contacts;\n\tv235 = v68.data;\n\tv447 = v186 < v235.Length;\n\tv177 = ~v447;\n\tif (v177) goto L_00F2;\n\tv412 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v62, v235[v112 @ X28_v7 (System.Int32)].particle);\nL_00B5:\n\tv68 = e.contacts;\n\tv186 = v186 + 1;\n\tv421 = e.contacts == 0;\n\tv222 = ~v421;\n\tif (v222) goto L_003F;\n\tthrow System.NullReferenceException;\nL_00C3:\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::ExceptWith(this.particles, v62);\n\tv236 = this.particles;\n\tthis.particles = v62;\n\tv332 = v236._count + this.counter;\n\tthis.counter = v332;\n\t// 209 Box v336 @ X0_v9 (System.Object), typeof(System.Int32), &v332 @ X8_v13 (System.Int32)\n\tgoto L_00E2;\n\tv422 = *([v385 @ X8_v16+E0]);\n\tv423 = v422 == 0;\n\tv424 = ~v423;\n\tif (v424) goto L_00E2;\n\tv432 = v385;\n\tv426 = \"il2cpp_codegen_runtime_class_init\"(v432, v330, v89, v94, v43, v44, v45, v46, v103, v48, v49, v50, v51, v52, v53, v54);\nL_00E2:\n\tUnityEngine.Debug::Log(v336);\n\treturn;\nL_00F2:\n\tv396 = new System.IndexOutOfRangeException();\n\tthrow v396;\n\tthrow System.NullReferenceException;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Solver_OnCollision(object sender, ObiSolver.ObiCollisionEventArgs e)
	{
		HashSet<int> hashSet = new HashSet<int>();
		ObiList<Oni.Contact> contacts = e.contacts;
		int num = 0;
		int num2 = default(int);
		while (true)
		{
			if (num < contacts.Count)
			{
				Oni.Contact[] data = contacts.Data;
				if (num >= data.Length)
				{
					break;
				}
				if (data[num2].distance < 0.001f)
				{
					Oni.Contact[] data2 = contacts.Data;
					if (num >= data2.Length)
					{
						break;
					}
					if (ObiColliderBase.idToCollider.TryGetValue(data2[num2].other, out var value) && value == targetCollider)
					{
						contacts = e.contacts;
						Oni.Contact[] data3 = contacts.Data;
						if (num >= data3.Length)
						{
							break;
						}
						bool flag = hashSet.Add(data3[num2].particle);
					}
				}
				contacts = e.contacts;
				num++;
				if (e.contacts == null)
				{
					throw new NullReferenceException();
				}
				continue;
			}
			particles.ExceptWith(hashSet);
			HashSet<int> hashSet2 = particles;
			particles = hashSet;
			object message = (counter = hashSet2.Count + counter);
			Debug.Log(message);
			return;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		throw ex;
	}

	[Token(Token = "0x60000C1")]
	[Address(RVA = "0x98F0D8", Offset = "0x98F0D8", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECD760]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021709]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v42);\n\tthis.particles = v42;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ObiParticleCounter()
	{
		HashSet<int> hashSet = new HashSet<int>();
		particles = hashSet;
	}
}
