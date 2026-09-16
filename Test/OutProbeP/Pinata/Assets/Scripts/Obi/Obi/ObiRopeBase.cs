using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000061")]
	public abstract class ObiRopeBase : ObiActor
	{
		[SerializeField]
		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x80")]
		protected internal bool m_SelfCollisions;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x84")]
		protected float restLength_;

		[HideInInspector]
		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x88")]
		public List<ObiStructuralElement> elements;

		[CompilerGenerated]
		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x90")]
		private ActorCallback m_OnElementsGenerated;

		[Token(Token = "0x170000AB")]
		public float restLength
		{
			[Token(Token = "0x600042F")]
			[Address(RVA = "0xC38538", Offset = "0xC38538", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.restLength_;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return restLength;
			}
		}

		[Token(Token = "0x170000AC")]
		public ObiPath path
		{
			[Token(Token = "0x6000430")]
			[Address(RVA = "0xC2FD20", Offset = "0xC2FD20", Length = "0xE0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EAB200]);\n\tv19 = *([v18 @ X8_v16]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231BE]) = v38;\nL_0017:\n\tv43 = Obi.ObiActor::get_blueprint(this);\n\tv44 = v43 == 0;\n\tif (v44) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0045;\n\tv96 = v96_asT == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0045;\nL_0045:\n\tgoto L_004E;\n\tv122 = *([v118 @ X0_v4+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tgoto L_004E;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004E:\n\tv132 = UnityEngine.Object::op_Inequality(v112, 0);\n\tv136 = v132 == 0;\n\tif (v136) goto L_005C;\n\treturnVal1 = *([v112 @ X19_v2 (UnityEngine.Object)+100]);\nL_005C:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0095: Expected O, but got I
				ObiActorBlueprint obiActorBlueprint = base.blueprint;
				UnityEngine.Object obj;
				if ((object)obiActorBlueprint == null)
				{
					obj = null;
				}
				else
				{
					ObiRopeBlueprintBase obiRopeBlueprintBase = obiActorBlueprint as ObiRopeBlueprintBase;
					obj = (((object)obiRopeBlueprintBase == null) ? null : obiActorBlueprint);
				}
				bool flag = obj != null;
				bool flag2 = !flag;
				ObiPath result = null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X19_v2 (UnityEngine.Object)+100]");
					result = (ObiPath)0;
				}
				return result;
			}
		}

		[Token(Token = "0x14000013")]
		public event ActorCallback OnElementsGenerated
		{
			[CompilerGenerated]
			[Token(Token = "0x600042D")]
			[Address(RVA = "0xC383F0", Offset = "0xC383F0", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA6198]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20231BC]) = v43;\nL_0017:\n\tv45 = this + 0x90;\nL_001D:\n\tv93 = System.Delegate::Combine(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 144L;
				Delegate obj2 = this.m_OnElementsGenerated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x600042E")]
			[Address(RVA = "0xC38494", Offset = "0xC38494", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EA4DF8]);\n\tv25 = *([v24 @ X8_v6]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, value, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20231BD]) = v43;\nL_0017:\n\tv45 = this + 0x90;\nL_001D:\n\tv93 = System.Delegate::Remove(v88, value);\n\tv85 = v93 == 0;\n\tif (v85) goto L_0031;\n\tv105 = *([v93 @ X0_v4 (System.Delegate)]) != Obi.ObiActor+ActorCallback;\n\tif (v105) goto L_0047;\nL_0031:\n\tv83 = 0x874190(v45, v93, v88, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = v88 != v83;\n\tif (v52) goto L_001D;\n\treturn;\nL_0047:\n\tthrow System.InvalidCastException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (long)(IntPtr)this + 144L;
				Delegate obj2 = this.m_OnElementsGenerated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if (obj3 != null && (object)obj3.GetType() != typeof(ActorCallback))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @874190");
					bool flag = obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000431")]
		[Address(RVA = "0xC38540", Offset = "0xC38540", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0022;\n\tv44 = *([1F03E40]);\n\tv45 = *([v44 @ X8_v23]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([20231BF]) = v64;\nL_0022:\n\tv67 = ~this.m_Loaded;\n\tif (v67) goto L_00C0;\n\tv68 = this.elements;\n\tv125 = v68._size < 1;\n\tif (v125) goto L_00C0;\nL_003C:\n\tv279 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv232 = this.elements;\n\tv112 = v237 - 4;\n\tv394 = v112 < v232._size;\n\tv275 = ~v394;\n\tv243 = ~v275;\n\tif (v243) goto L_0050;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0050:\n\tv396 = v232._items;\n\tv292 = *([v396 @ X8_v10 (Obi.ObiStructuralElement[])+v237 @ X22_v6 (System.Int32)*8]);\n\tv398 = Obi.ObiNativeVector4List::get_Item(v279, v292.particle1);\n\tv281 = Obi.ObiSolver::get_positions(this.m_Solver);\n\tv114 = this.elements;\n\tv400 = v112 < v114._size;\n\tv276 = ~v400;\n\tv244 = ~v276;\n\tif (v244) goto L_0077;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0077:\n\tv402 = v114._items;\n\tv294 = *([v402 @ X8_v14 (Obi.ObiStructuralElement[])+v237 @ X22_v6 (System.Int32)*8]);\n\tv405 = Obi.ObiNativeVector4List::get_Item(v281, v294.particle2);\n\tv406 = UnityEngine.Vector4;\n\tv409 = *([v406 @ X0_v18 (Il2CppClass<UnityEngine.Vector4>)+12F]) & 2;\n\tv410 = v409 == 0;\n\tif (v410) goto L_009B;\n\tv412 = *([v406 @ X0_v18 (Il2CppClass<UnityEngine.Vector4>)+E0]) == 0;\n\tv413 = ~v412;\n\tif (v413) goto L_009B;\n\t*([v34 @ X29_v1-34]) = v206;\n\tv97 = *([v34 @ X29_v1-34]);\nL_009B:\n\t// 155 MakeStruct v74 @ AGGC386CC_0_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v206 @ V0_v5 (System.Single), v204 @ V1_v4, v202 @ V2_v4, v200 @ V3_v4\n\t// 156 MakeStruct v71 @ AGGC386CC_1_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v97 @ V4_v6 (System.Single), v204 @ V1_v4, v202 @ V2_v4, v200 @ V3_v4\n\tv206 = UnityEngine.Vector4::Distance(v74, v71);\n\tv166 = v237 - 3;\n\tv237 = v237 + 1;\n\tv119 = v239 + v206;\n\tv124 = v166 < v68._size;\n\tif (v124) goto L_003C;\nL_00C0:\n\treturn v119;\n\tthrow System.NullReferenceException;\n\treturn returnVal2;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public float CalculateLength()
		{
			//IL_00e9: Expected O, but got I
			//IL_0186: Expected O, but got I
			//IL_01af: Expected I, but got O
			//IL_0280: Expected F4, but got O
			//IL_028d: Expected F4, but got O
			//IL_029a: Expected F4, but got O
			//IL_02b4: Expected F4, but got O
			//IL_02c1: Expected F4, but got O
			//IL_02ce: Expected F4, but got O
			//IL_0238: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			bool flag = !isLoaded;
			float num = 0f;
			if (!flag)
			{
				List<ObiStructuralElement> list = elements;
				bool flag2 = list.Count < 1;
				num = 0f;
				if (!flag2)
				{
					int num2 = 4;
					float num3 = 0f;
					float num6 = default(float);
					Vector4 a = default(Vector4);
					object obj3 = default(object);
					object obj4 = default(object);
					object obj5 = default(object);
					Vector4 b = default(Vector4);
					bool flag6;
					do
					{
						ObiNativeVector4List positions = solver.positions;
						List<ObiStructuralElement> list2 = elements;
						int num4 = num2 - 4;
						if (num4 >= list2.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						ObiStructuralElement[] items = list2._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v396 @ X8_v10 (Obi.ObiStructuralElement[])+v237 @ X22_v6 (System.Int32)*8]");
						ObiStructuralElement obiStructuralElement = (ObiStructuralElement)0;
						Vector4 vector = positions.get_Item(obiStructuralElement.particle1);
						ObiNativeVector4List positions2 = solver.positions;
						List<ObiStructuralElement> list3 = elements;
						if (num4 >= list3.Count)
						{
							throw new ArgumentOutOfRangeException();
						}
						ObiStructuralElement[] items2 = list3._items;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v402 @ X8_v14 (Obi.ObiStructuralElement[])+v237 @ X22_v6 (System.Int32)*8]");
						ObiStructuralElement obiStructuralElement2 = (ObiStructuralElement)0;
						Vector4 vector2 = positions2.get_Item(obiStructuralElement2.particle2);
						IntPtr intPtr = (IntPtr)typeof(Vector4);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X0_v18 (Il2CppClass<UnityEngine.Vector4>)+12F]");
						int num5 = 0;
						bool flag3 = num5 == 0;
						float x = num6;
						if (!flag3)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X0_v18 (Il2CppClass<UnityEngine.Vector4>)+E0]");
							bool flag4 = (IntPtr)0 == (IntPtr)0;
							bool flag5 = !flag4;
							x = num6;
							if (!flag5)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
								x = 0f;
							}
						}
						a.x = num6;
						a.y = (float)obj3;
						a.z = (float)obj4;
						a.w = (float)obj5;
						b.x = x;
						b.y = (float)obj3;
						b.z = (float)obj4;
						b.w = (float)obj5;
						num6 = Vector4.Distance(a, b);
						int num7 = num2 - 3;
						num2++;
						num = num3 + num6;
						flag6 = num7 < list.Count;
						num3 = num;
					}
					while (flag6);
				}
			}
			return num;
		}

		[Token(Token = "0x6000432")]
		[Address(RVA = "0xC33E2C", Offset = "0xC33E2C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1EE7390]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20231C0]) = v44;\nL_0016:\n\tv61 = this.elements;\n\tthis.restLength_ = 0f;\n\tv58 = v61._size < 1;\n\tif (v58) goto L_005A;\nL_002A:\n\tv161 = v73 < v61._size;\n\tv108 = ~v161;\n\tv76 = ~v108;\n\tif (v76) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv163 = v61._items;\n\tv116 = v163[v73 @ X21_v5 (System.Int32)];\n\tv73 = v73 + 1;\n\tv70 = v70 + v116.restLength;\n\tthis.restLength_ = v70;\n\tv75 = v73 >= v61._size;\n\tif (v75) goto L_005A;\n\tv61 = this.elements;\n\tv166 = this.elements == 0;\n\tv113 = ~v166;\n\tif (v113) goto L_002A;\n\tthrow System.NullReferenceException;\nL_005A:\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecalculateRestLength()
		{
			List<ObiStructuralElement> list = elements;
			restLength_ = 0f;
			if (list.Count < 1)
			{
				return;
			}
			float num = 0f;
			int num2 = 0;
			while (true)
			{
				if (num2 >= list.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiStructuralElement[] items = list._items;
				ObiStructuralElement obiStructuralElement = items[num2];
				num2++;
				num = (restLength_ = num + obiStructuralElement.restLength);
				if (num2 < list.Count)
				{
					list = elements;
					if (elements == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6000433")]
		[Address(RVA = "0xC38718", Offset = "0xC38718", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv32 = *([1F0DEE0]);\n\tv33 = *([v32 @ X8_v22]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([20231C1]) = v52;\nL_001A:\n\tv53 = this.elements;\n\tv66 = v53._size < 1;\n\tif (v66) goto L_00C1;\nL_0031:\n\tv190 = Obi.ObiSolver::get_restPositions(this.m_Solver);\n\tv117 = this.elements;\n\tv115 = v130 - 4;\n\tv356 = v115 < v117._size;\n\tv184 = ~v356;\n\tv136 = ~v184;\n\tif (v136) goto L_0045;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0045:\n\tv358 = v117._items;\n\tv209 = *([v358 @ X8_v9 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]);\n\tv91 = 0;\n\tv192 = 0x158BA74(&v91 @ stack_-70_v5, 0, *([v372 @ X8_v18 (Il2CppClass<Obi.ObiNativeVector4List>)+198]), v37, v38, v39, v40, v41, v132, 0, 0, 1f, v46, v47, v48, v49);\n\tv210 = *([v190 @ X0_v9 (Obi.ObiNativeVector4List)]);\n\tv193 = Obi.ObiNativeVector4List::set_Item(v190, v209.particle1, Vector4_arg);\n\tv215 = this.elements;\n\tv364 = v115 < v215._size;\n\tv185 = ~v364;\n\tv137 = ~v185;\n\tif (v137) goto L_0070;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0070:\n\tv366 = v215._items;\n\tv211 = *([v366 @ X8_v13 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]);\n\tv195 = Obi.ObiSolver::get_restPositions(this.m_Solver);\n\tv119 = this.elements;\n\tv368 = v115 < v119._size;\n\tv186 = ~v368;\n\tv138 = ~v186;\n\tif (v138) goto L_008C;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_008C:\n\tv370 = v119._items;\n\tv212 = *([v370 @ X8_v16 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]);\n\tv132 = v132 + v211.restLength;\n\tv73 = 0;\n\tv197 = 0x158BA74(&v73 @ stack_-80_v5, 0, *([v210 @ X8_v11 (Il2CppClass<Obi.ObiNativeVector4List>)+198]), v37, v38, v39, v40, v41, v132, 0, 0, 1f, v46, v47, v48, v49);\n\tv372 = *([v195 @ X0_v17 (Obi.ObiNativeVector4List)]);\n\tv264 = Obi.ObiNativeVector4List::set_Item(v195, v212.particle2, Vector4_arg);\n\tv267 = v130 - 3;\n\tv130 = v130 + 1;\n\tv246 = v267 < v53._size;\n\tif (v246) goto L_0031;\nL_00C1:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 145 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RecalculateRestPositions()
		{
			//IL_00c9: Expected O, but got I
			//IL_00d7: Expected O, but got I4
			//IL_00f3: Expected I, but got O
			//IL_010e: Expected F4, but got O
			//IL_0129: Expected F4, but got O
			//IL_01ad: Expected O, but got I
			//IL_022f: Expected O, but got I
			//IL_0251: Expected O, but got I4
			//IL_026d: Expected I, but got O
			//IL_0288: Expected F4, but got O
			//IL_02a3: Expected F4, but got O
			List<ObiStructuralElement> list = elements;
			if (list.Count < 1)
			{
				return;
			}
			int num = 4;
			float num2 = 0f;
			Vector4 value = default(Vector4);
			object obj2 = default(object);
			object obj3 = default(object);
			Vector4 value2 = default(Vector4);
			object obj5 = default(object);
			object obj6 = default(object);
			int num4;
			do
			{
				ObiNativeVector4List restPositions = solver.restPositions;
				List<ObiStructuralElement> list2 = elements;
				int num3 = num - 4;
				if (num3 >= list2.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiStructuralElement[] items = list2._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v358 @ X8_v9 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]");
				ObiStructuralElement obiStructuralElement = (ObiStructuralElement)0;
				object obj = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
				IntPtr intPtr = (IntPtr)restPositions;
				value.x = 0f;
				value.y = (float)obj2;
				value.z = 0f;
				value.w = (float)obj3;
				restPositions.set_Item(obiStructuralElement.particle1, value);
				List<ObiStructuralElement> list3 = elements;
				if (num3 >= list3.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiStructuralElement[] items2 = list3._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v366 @ X8_v13 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]");
				ObiStructuralElement obiStructuralElement2 = (ObiStructuralElement)0;
				ObiNativeVector4List restPositions2 = solver.restPositions;
				List<ObiStructuralElement> list4 = elements;
				if (num3 >= list4.Count)
				{
					throw new ArgumentOutOfRangeException();
				}
				ObiStructuralElement[] items3 = list4._items;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v370 @ X8_v16 (Obi.ObiStructuralElement[])+v130 @ X23_v6 (System.Int32)*8]");
				ObiStructuralElement obiStructuralElement3 = (ObiStructuralElement)0;
				num2 += obiStructuralElement2.restLength;
				object obj4 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
				IntPtr intPtr2 = (IntPtr)restPositions2;
				value2.x = 0f;
				value2.y = (float)obj5;
				value2.z = 0f;
				value2.w = (float)obj6;
				restPositions2.set_Item(obiStructuralElement3.particle2, value2);
				num4 = num - 3;
				num++;
			}
			while (num4 < list.Count);
		}

		[Token(Token = "0x6000434")]
		[Address(RVA = "0xC300C8", Offset = "0xC300C8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = Obi.ObiRopeBase::RebuildElementsFromConstraintsInternal(this);\n\tv29 = this.OnElementsGenerated == 0;\n\tif (v29) goto L_0019;\n\tObi.ObiActor+ActorCallback::Invoke(this.OnElementsGenerated, this);\n\treturn;\nL_0019:\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RebuildElementsFromConstraints()
		{
			RebuildElementsFromConstraints();
			if (this.OnElementsGenerated != null)
			{
				this.OnElementsGenerated(this);
			}
		}

		[Token(Token = "0x6000435")]
		protected abstract void RebuildElementsFromConstraintsInternal();

		[Token(Token = "0x6000436")]
		[Address(RVA = "0xC388EC", Offset = "0xC388EC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void RebuildConstraintsFromElements()
		{
		}

		[Token(Token = "0x6000437")]
		[Address(RVA = "0xC388F0", Offset = "0xC388F0", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF4200]);\n\tv27 = *([v26 @ X8_v14]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, elementMu, methodInfo, v30, v31, v32, v33, v34, mu, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20231C2]) = v44;\nL_0017:\n\tv45 = this.elements;\n\tgoto L_002C;\n\tv56 = *([v50 @ X0_v4+E0]);\n\tv57 = v56 == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_002C;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v50, elementMu, methodInfo, v30, v31, v32, v33, v34, mu, v35, v36, v37, v38, v39, v40, v41);\nL_002C:\n\tv68 = UnityEngine.Mathf::Clamp(mu, 0f, 0.99999f);\n\tv70 = v68 * v45._size;\n\tv73 = v70 - v70;\n\t*([elementMu @ X1 (System.Single&)]) = v73;\n\tv74 = this.elements;\n\tv75 = this.elements == 0;\n\tif (v75) goto L_FFFFFFFF;\n\tv129 = v74._size < v70;\n\tv130 = ~v129;\n\tv131 = v74._size - v70;\n\tv133 = v131 == 0;\n\tv140 = v74._size <= v70;\n\tif (v140) goto L_FFFFFFFF;\n\tv152 = ~v133;\n\tv153 = v130 & v152;\n\tif (v153) goto L_0049;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0049:\n\tv159 = v74._items;\n\tgoto L_0056;\nL_0056:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ObiStructuralElement GetElementAt(float mu, out float elementMu)
		{
			//IL_0056: Expected Ref, but got F4
			elementMu = default(float);
			List<ObiStructuralElement> list = elements;
			float num = Mathf.Clamp(mu, 0f, 0.99999f);
			float num2 = num * (float)list.Count;
			float num3 = num2 - num2;
			ref float reference = ref *(float*)num3;
			List<ObiStructuralElement> list2 = elements;
			if (elements != null)
			{
				bool flag = (float)list2.Count < num2;
				bool flag2 = !flag;
				float num4 = (float)list2.Count - num2;
				bool flag3 = num4 == 0f;
				if ((float)list2.Count > num2)
				{
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						throw new ArgumentOutOfRangeException();
					}
					ObiStructuralElement[] items = list2._items;
					return items[num2];
				}
			}
			return null;
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0xC341CC", Offset = "0xC341CC", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFBAE0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231C3]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<Obi.ObiStructuralElement>();\n\tSystem.Collections.Generic.List`1<Obi.ObiStructuralElement>::.ctor(v42);\n\tthis.elements = v42;\n\tObi.ObiActor::.ctor(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ObiRopeBase()
		{
			List<ObiStructuralElement> list = new List<ObiStructuralElement>();
			elements = list;
		}
	}
}
