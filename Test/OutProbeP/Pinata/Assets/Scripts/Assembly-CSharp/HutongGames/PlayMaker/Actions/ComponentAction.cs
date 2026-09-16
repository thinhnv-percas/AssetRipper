using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Token(Token = "0x20001A7")]
	public abstract class ComponentAction<T> : FsmStateAction where T : Component
	{
		[Token(Token = "0x4001339")]
		[FieldOffset(Offset = "0x0")]
		protected GameObject cachedGameObject;

		[Token(Token = "0x400133A")]
		[FieldOffset(Offset = "0x0")]
		protected internal T cachedComponent;

		[Token(Token = "0x17000056")]
		protected internal Rigidbody rigidbody
		{
			[Token(Token = "0x60008F9")]
			[Address(RVA = "0xD95084", Offset = "0xD95084", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFD940]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240C5]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Rigidbody), typeof(UnityEngine.Rigidbody), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Rigidbody;
			}
		}

		[Token(Token = "0x17000057")]
		protected internal Rigidbody2D rigidbody2d
		{
			[Token(Token = "0x60008FA")]
			[Address(RVA = "0xD950D4", Offset = "0xD950D4", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED51D8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240C6]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Rigidbody2D), typeof(UnityEngine.Rigidbody2D), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Rigidbody2D;
			}
		}

		[Token(Token = "0x17000058")]
		protected internal Renderer renderer
		{
			[Token(Token = "0x60008FB")]
			[Address(RVA = "0xD95124", Offset = "0xD95124", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EC1FF8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240C7]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Renderer), typeof(UnityEngine.Renderer), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Renderer;
			}
		}

		[Token(Token = "0x17000059")]
		protected internal Animation animation
		{
			[Token(Token = "0x60008FC")]
			[Address(RVA = "0xD95174", Offset = "0xD95174", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBC250]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240C8]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Animation), typeof(UnityEngine.Animation), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Animation;
			}
		}

		[Token(Token = "0x1700005A")]
		protected internal AudioSource audio
		{
			[Token(Token = "0x60008FD")]
			[Address(RVA = "0xD951C4", Offset = "0xD951C4", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F04AA8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240C9]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.AudioSource), typeof(UnityEngine.AudioSource), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as AudioSource;
			}
		}

		[Token(Token = "0x1700005B")]
		protected internal Camera camera
		{
			[Token(Token = "0x60008FE")]
			[Address(RVA = "0xD95214", Offset = "0xD95214", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE6BA8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240CA]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Camera), typeof(UnityEngine.Camera), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Camera;
			}
		}

		[Token(Token = "0x1700005C")]
		protected internal GUIText guiText
		{
			[Token(Token = "0x60008FF")]
			[Address(RVA = "0xD95264", Offset = "0xD95264", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EDAFD0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240CB]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.GUIText), typeof(UnityEngine.GUIText), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as GUIText;
			}
		}

		[Token(Token = "0x1700005D")]
		protected internal GUITexture guiTexture
		{
			[Token(Token = "0x6000900")]
			[Address(RVA = "0xD952B4", Offset = "0xD952B4", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF4BE0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240CC]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.GUITexture), typeof(UnityEngine.GUITexture), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as GUITexture;
			}
		}

		[Token(Token = "0x1700005E")]
		protected internal Light light
		{
			[Token(Token = "0x6000901")]
			[Address(RVA = "0xD95304", Offset = "0xD95304", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0A900]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20240CD]) = v38;\nL_001C:\n\t// 28 IsInst returnVal1 @ X0_v3 (UnityEngine.Light), typeof(UnityEngine.Light), this.cachedComponent (T)\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cachedComponent as Light;
			}
		}

		[Token(Token = "0x6000902")]
		[Address(RVA = "0xD95354", Offset = "0xD95354", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EC5CD0]);\n\tv29 = *([v28 @ X8_v34]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, go, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240CE]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, go, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv63 = UnityEngine.Object::op_Equality(go, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_003A;\n\treturn 0;\nL_003A:\n\tgoto L_0043;\n\tv118 = *([v74 @ X0_v6+E0]);\n\tv119 = v118 == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_0043;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v74, v61, v62, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0043:\n\tv128 = UnityEngine.Object::op_Equality(this.cachedComponent, 0);\n\tv130 = v128 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0061;\n\tgoto L_0056;\n\tv149 = *([v132 @ X0_v38+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_0056;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v132, v126, v127, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0056:\n\tv142 = UnityEngine.Object::op_Inequality(this.cachedGameObject, go);\n\tv144 = v142 == 0;\n\tif (v144) goto L_00A6;\nL_0061:\n\tv161 = UnityEngine.GameObject::GetComponent(go);\n\tthis.cachedGameObject = go;\n\tthis.cachedComponent = v161;\n\tgoto L_0072;\n\tv169 = *([v163 @ X0_v22+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0072;\n\tv173 = \"il2cpp_codegen_runtime_class_init\"(v163, v159, v137, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0072:\n\tv179 = UnityEngine.Object::op_Equality(v161, 0);\n\tv197 = v179 == 0;\n\tif (v197) goto L_00A6;\n\tgoto L_0087;\n\tv222 = *([v219 @ X0_v26+E0]);\n\tv223 = v222 == 0;\n\tv224 = ~v223;\n\tif (v224) goto L_0087;\n\tv226 = \"il2cpp_codegen_runtime_class_init\"(v219, v177, v178, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0087:\n\tv183 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv232 = System.Type::get_FullName(v183);\n\tv235 = UnityEngine.Object::get_name(go);\n\tv242 = System.String::Concat(\"Missing component: \", v232, \" on: \", v235);\n\tHutongGames.PlayMaker.FsmStateAction::LogWarning(this, v242);\nL_00A6:\n\tgoto L_00B7;\n\tv209 = *([v203 @ X0_v11+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_00B7;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v203, v192, v190, v82, v80, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B7:\n\treturnVal3 = UnityEngine.Object::op_Inequality(this.cachedComponent, 0);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal bool UpdateCache(GameObject go)
		{
			if (go == null)
			{
				return false;
			}
			if (cachedComponent == null || cachedGameObject != go)
			{
				UnityEngine.Object component = go.GetComponent<T>();
				cachedGameObject = go;
				cachedComponent = (T)component;
				if (component == null)
				{
					Type typeFromHandle = typeof(T);
					string fullName = typeFromHandle.FullName;
					string text = go.name;
					string text2 = "Missing component: " + fullName + " on: " + text;
					LogWarning(text2);
				}
			}
			return cachedComponent != null;
		}

		[Token(Token = "0x6000903")]
		[Address(RVA = "0xD95570", Offset = "0xD95570", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv28 = *([1EEBC08]);\n\tv29 = *([v28 @ X8_v29]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, go, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20240CF]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, go, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv63 = UnityEngine.Object::op_Equality(go, 0);\n\tv65 = v63 == 0;\n\tif (v65) goto L_003A;\n\treturn 0;\nL_003A:\n\tgoto L_0043;\n\tv109 = *([v74 @ X0_v6+E0]);\n\tv110 = v109 == 0;\n\tv111 = ~v110;\n\tif (v111) goto L_0043;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v74, v61, v62, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0043:\n\tv119 = UnityEngine.Object::op_Equality(this.cachedComponent, 0);\n\tv121 = v119 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_0061;\n\tgoto L_0056;\n\tv140 = *([v123 @ X0_v29+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0056;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v123, v117, v118, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0056:\n\tv133 = UnityEngine.Object::op_Inequality(this.cachedGameObject, go);\n\tv135 = v133 == 0;\n\tif (v135) goto L_0087;\nL_0061:\n\tv152 = UnityEngine.GameObject::GetComponent(go);\n\tthis.cachedGameObject = go;\n\tthis.cachedComponent = v152;\n\tgoto L_0072;\n\tv160 = *([v154 @ X0_v22+E0]);\n\tv161 = v160 == 0;\n\tv162 = ~v161;\n\tif (v162) goto L_0072;\n\tv164 = \"il2cpp_codegen_runtime_class_init\"(v154, v150, v128, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0072:\n\tv170 = UnityEngine.Object::op_Equality(v152, 0);\n\tv182 = v170 == 0;\n\tif (v182) goto L_0087;\n\tv173 = UnityEngine.GameObject::AddComponent(go);\n\tthis.cachedComponent = v173;\n\tUnityEngine.Object::set_hideFlags(v173, 4);\nL_0087:\n\tgoto L_0098;\n\tv191 = *([v185 @ X0_v11+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0098;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v185, v178, v176, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0098:\n\treturnVal3 = UnityEngine.Object::op_Inequality(this.cachedComponent, 0);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal bool UpdateCacheAddComponent(GameObject go)
		{
			if (go == null)
			{
				return false;
			}
			if (cachedComponent == null || cachedGameObject != go)
			{
				UnityEngine.Object component = go.GetComponent<T>();
				cachedGameObject = go;
				cachedComponent = (T)component;
				if (component == null)
				{
					(cachedComponent = go.AddComponent<T>()).hideFlags = HideFlags.DontSaveInEditor;
				}
			}
			return cachedComponent != null;
		}

		[Token(Token = "0x6000904")]
		[Address(RVA = "0xD95720", Offset = "0xD95720", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.cachedGameObject, eventTarget, fsmEvent);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal void SendEvent(FsmEventTarget eventTarget, FsmEvent fsmEvent)
		{
			this.fsm.Event(cachedGameObject, eventTarget, fsmEvent);
		}

		[Token(Token = "0x6000905")]
		[Address(RVA = "0xD95764", Offset = "0xD95764", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal ComponentAction()
		{
		}
	}
}
