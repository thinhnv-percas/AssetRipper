using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lean.Common
{
	[Token(Token = "0x2000004")]
	public static class LeanHelper
	{
		[Token(Token = "0x4000006")]
		public const string HelpUrlPrefix = "https://carloswilkes.github.io/Documentation/";

		[Token(Token = "0x4000007")]
		public const string ComponentPathPrefix = "Lean/";

		[Token(Token = "0x6000003")]
		[Address(RVA = "0xC77758", Offset = "0xC77758", Length = "0x588")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0051;\n\tgoto L_0051;\n\tv43 = 0xB3490C(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0051:\n\tgoto L_0055;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v53, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0055:\n\tv64 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv75 = System.Reflection.MemberInfo::get_Name(v64);\n\tv81 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v81, v75);\n\tv373 = UnityEngine.GameObject::AddComponent(v81);\n\tgoto L_0079;\n\tv385 = v219;\n\tv386 = \"il2cpp_codegen_runtime_class_init\"(v385, v372, v150, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0079:\n\tv186 = UnityEngine.Object::op_Equality(parent, 0);\n\tv432 = v186 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_0098;\n\tv462 = UnityEngine.Component::GetComponentInParent(parent);\n\tgoto L_0090;\n\tv480 = v450;\n\tv481 = \"il2cpp_codegen_runtime_class_init\"(v480, v461, v151, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0090:\n\tv446 = UnityEngine.Object::op_Equality(v462, 0);\n\tv448 = v446 == 0;\n\tif (v448) goto L_01A8;\nL_0098:\n\tgoto L_009D;\n\tv463 = \"il2cpp_codegen_runtime_class_init\"(v451, v443, v437, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_009D:\n\tv468 = UnityEngine.Object::FindObjectOfType();\n\tv476 = UnityEngine.Object::op_Equality(v468, 0);\n\tv485 = v476 == 0;\n\tif (v485) goto L_01A2;\n\t// 169 NewArr v493 @ X0_v39 (System.Type[]), typeof(System.Type[]), 4\n\tgoto L_00B7;\n\tv519 = v220;\n\tv520 = \"il2cpp_codegen_runtime_class_init\"(v519, v491, v152, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00B7:\n\tv187 = System.Type::GetTypeFromHandle(UnityEngine.RectTransform);\n\tv527 = v187 == 0;\n\tif (v527) goto L_00C6;\n\t// 192 IsInst v344 @ X0_v96, typeof(System.Type), v187 @ X0_v42 (System.Type)\n\tv351 = v344 == 0;\n\tif (v351) goto L_01CA;\nL_00C6:\n\tv493[0] = v187;\n\tv536 = System.Type::GetTypeFromHandle(UnityEngine.Canvas);\n\tv537 = v536 == 0;\n\tif (v537) goto L_00E2;\n\t// 210 IsInst v345 @ X0_v94, typeof(System.Type), v536 @ X0_v45 (System.Type)\n\tv352 = v345 == 0;\n\tif (v352) goto L_01CA;\nL_00E2:\n\tv493[1] = v536;\n\tv546 = System.Type::GetTypeFromHandle(UnityEngine.UI.CanvasScaler);\n\tv547 = v546 == 0;\n\tif (v547) goto L_00FE;\n\t// 238 IsInst v346 @ X0_v92, typeof(System.Type), v546 @ X0_v48 (System.Type)\n\tv353 = v346 == 0;\n\tif (v353) goto L_01CA;\nL_00FE:\n\tv493[2] = v546;\n\tv556 = System.Type::GetTypeFromHandle(UnityEngine.UI.GraphicRaycaster);\n\tv557 = v556 == 0;\n\tif (v557) goto L_011A;\n\t// 266 IsInst v347 @ X0_v90, typeof(System.Type), v556 @ X0_v51 (System.Type)\n\tv354 = v347 == 0;\n\tif (v354) goto L_01CA;\nL_011A:\n\tv493[3] = v556;\n\tv188 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v188, \"Canvas\", v493);\n\tv189 = UnityEngine.GameObject::GetComponent(v188);\n\tv567 = UnityEngine.Component::get_gameObject(v189);\n\tv190 = UnityEngine.LayerMask::NameToLayer(\"UI\");\n\tUnityEngine.GameObject::set_layer(v567, v190);\n\tUnityEngine.Canvas::set_renderMode(v189, 0);\n\tgoto L_014A;\n\tv583 = \"il2cpp_codegen_runtime_class_init\"(v579, v575, v576, v87, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_014A:\n\tv586 = UnityEngine.EventSystems.EventSystem::get_current();\n\tgoto L_0156;\n\tv589 = v505;\n\tv590 = \"il2cpp_codegen_runtime_class_init\"(v589, v575, v576, v87, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0156:\n\tv501 = UnityEngine.Object::op_Equality(v586, 0);\n\tv503 = v501 == 0;\n\tif (v503) goto L_01A2;\n\t// 348 NewArr v596 @ X0_v70 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_016A;\n\tv600 = v224;\n\tv601 = \"il2cpp_codegen_runtime_class_init\"(v600, v595, v154, v87, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_016A:\n\tv191 = System.Type::GetTypeFromHandle(UnityEngine.EventSystems.EventSystem);\n\tv604 = v191 == 0;\n\tif (v604) goto L_0179;\n\t// 371 IsInst v348 @ X0_v83, typeof(System.Type), v191 @ X0_v73 (System.Type)\n\tv355 = v348 == 0;\n\tif (v355) goto L_01CA;\nL_0179:\n\tv596[0] = v191;\n\tv612 = System.Type::GetTypeFromHandle(UnityEngine.EventSystems.StandaloneInputModule);\n\tv613 = v612 == 0;\n\tif (v613) goto L_0195;\n\t// 389 IsInst v349 @ X0_v81, typeof(System.Type), v612 @ X0_v76 (System.Type)\n\tv356 = v349 == 0;\n\tif (v356) goto L_01CA;\nL_0195:\n\tv596[1] = v612;\n\tv500 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v500, \"EventSystem\", v596);\nL_01A2:\n\tv193 = UnityEngine.Component::get_transform(v213);\nL_01A8:\n\tv194 = UnityEngine.Component::get_gameObject(v215);\n\tv525 = UnityEngine.GameObject::get_layer(v194);\n\tUnityEngine.GameObject::set_layer(v81, v525);\n\tv196 = UnityEngine.Component::get_transform(v373);\n\tUnityEngine.Transform::SetParent(v196, v215, 0);\n\treturn v373;\n\tv227 = new System.NullReferenceException();\n\tv313 = new System.IndexOutOfRangeException();\nL_01CA:\n\tv366 = new System.ArrayTypeMismatchException();\n\tthrow v366;\n\treturn returnVal1;\n// 352 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T CreateElement<T>(Transform parent) where T : Component
		{
			Type typeFromHandle = typeof(T);
			string name = typeFromHandle.Name;
			GameObject gameObject = new GameObject(name);
			Component component = gameObject.AddComponent<T>();
			Transform transform;
			if (!(parent == null))
			{
				Canvas componentInParent = parent.GetComponentInParent<Canvas>();
				bool flag = componentInParent == null;
				bool flag2 = !flag;
				transform = parent;
				if (flag2)
				{
					goto IL_04b1;
				}
			}
			Canvas canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
			bool flag3 = canvas == null;
			bool flag4 = !flag3;
			Canvas canvas2 = canvas;
			if (!flag4)
			{
				Type[] array = new Type[4];
				Type typeFromHandle2 = typeof(RectTransform);
				if ((object)typeFromHandle2 != null)
				{
					object obj = typeFromHandle2 as Type;
					if (obj == null)
					{
						goto IL_050b;
					}
				}
				array[0] = typeFromHandle2;
				Type typeFromHandle3 = typeof(Canvas);
				if ((object)typeFromHandle3 != null)
				{
					object obj2 = typeFromHandle3 as Type;
					if (obj2 == null)
					{
						goto IL_050b;
					}
				}
				array[1] = typeFromHandle3;
				Type typeFromHandle4 = typeof(CanvasScaler);
				if ((object)typeFromHandle4 != null)
				{
					object obj3 = typeFromHandle4 as Type;
					if (obj3 == null)
					{
						goto IL_050b;
					}
				}
				array[2] = typeFromHandle4;
				Type typeFromHandle5 = typeof(GraphicRaycaster);
				if ((object)typeFromHandle5 != null)
				{
					object obj4 = typeFromHandle5 as Type;
					if (obj4 == null)
					{
						goto IL_050b;
					}
				}
				array[3] = typeFromHandle5;
				GameObject gameObject2 = new GameObject("Canvas", array);
				Canvas component2 = gameObject2.GetComponent<Canvas>();
				GameObject gameObject3 = component2.gameObject;
				int layer = LayerMask.NameToLayer("UI");
				gameObject3.layer = layer;
				component2.renderMode = default(RenderMode);
				EventSystem current = EventSystem.current;
				bool flag5 = current == null;
				bool flag6 = !flag5;
				canvas2 = component2;
				if (!flag6)
				{
					Type[] array2 = new Type[2];
					Type typeFromHandle6 = typeof(EventSystem);
					if ((object)typeFromHandle6 != null)
					{
						object obj5 = typeFromHandle6 as Type;
						if (obj5 == null)
						{
							goto IL_050b;
						}
					}
					array2[0] = typeFromHandle6;
					Type typeFromHandle7 = typeof(StandaloneInputModule);
					if ((object)typeFromHandle7 != null)
					{
						object obj6 = typeFromHandle7 as Type;
						if (obj6 == null)
						{
							goto IL_050b;
						}
					}
					array2[1] = typeFromHandle7;
					GameObject gameObject4 = new GameObject("EventSystem", array2);
					canvas2 = component2;
				}
			}
			Transform transform2 = canvas2.transform;
			transform = transform2;
			goto IL_04b1;
			IL_04b1:
			GameObject gameObject5 = transform.gameObject;
			int layer2 = gameObject5.layer;
			gameObject.layer = layer2;
			Transform transform3 = component.transform;
			transform3.SetParent(transform, worldPositionStays: false);
			return (T)component;
			IL_050b:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x135E4F4", Offset = "0x135E4F4", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = dampening < 0;\n\tif (v5) goto L_0015;\n\tv14 = -dampening;\n\tv15 = v14 * elapsed;\n\tv17 = 0x1854FD0(methodInfo, v19, v20, v21, v22, v23, v24, v25, v15, elapsed, dampening, v26, v27, v28, v29, v30);\n\treturnVal1 = 1f - v15;\nL_0015:\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float DampenFactor(float dampening, float elapsed)
		{
			//IL_0031: Expected O, but got F4
			bool flag = dampening < 0f;
			float result = 1f;
			if (!flag)
			{
				object obj = 0f - dampening;
				float num = (float)obj * elapsed;
				Il2CppRuntime.Boundary("SYSTEM_API:expf", "Method not found @1854FD0 (native expf)");
				result = 1f - num;
			}
			return result;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0xC77CE0", Offset = "0xC77CE0", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35832]) = v37;\nL_0017:\n\tgoto L_001C;\n\tv42 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001C:\n\tv47 = UnityEngine.Object::op_Inequality(o, 0);\n\tv49 = v47 == 0;\n\tif (v49) goto L_002F;\n\tgoto L_0028;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v50, v45, v46, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0028:\n\tUnityEngine.Object::Destroy(o);\nL_002F:\n\treturn 0;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T Destroy<T>(T o) where T : UnityEngine.Object
		{
			if (o != null)
			{
				UnityEngine.Object.Destroy(o);
			}
			return null;
		}
	}
}
