using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Scripting;

namespace HutongGames.PlayMaker
{
	[Preserve]
	[Token(Token = "0x200007A")]
	public class FsmProcessor
	{
		[Token(Token = "0x6000360")]
		[Address(RVA = "0x98AB88", Offset = "0x98AB88", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EF9908]);\n\tv19 = *([v18 @ X8_v41]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20216CD]) = v38;\nL_0017:\n\tv42 = PlayMakerFSM::get_Fsm(fsm);\n\tv55 = ~v42.handleLegacyNetworking;\n\tif (v55) goto L_0048;\n\tgoto L_002D;\n\tv97 = *([v58 @ X0_v19+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_002D;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v58, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv107 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(\"PlayMakerLegacyNetworking\");\n\tv67 = HutongGames.PlayMaker.FsmProcessor::AddEventHandlerComponent(fsm, v107);\n\tv110 = v67 == 0;\n\tv70 = ~v110;\n\tif (v70) goto L_0048;\n\tgoto L_0045;\n\tv127 = *([v118 @ X0_v25+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_0045;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v118, v64, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0045:\n\tUnityEngine.Debug::LogError(\"Could not add PlayMakerLegacyNetworking proxy!\");\nL_0048:\n\tv48 = PlayMakerFSM::get_Fsm(fsm);\n\tv84 = v48.handleUiEvents == 0;\n\tif (v84) goto L_008F;\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 1);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0xE);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x10);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x3E0);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x800);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x1000);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x2000);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x4000);\n\tHutongGames.PlayMaker.FsmProcessor::HandleUiEvent(fsm, 0x400);\n\treturn;\nL_008F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void OnPreprocess(PlayMakerFSM fsm)
		{
			Fsm fsm2 = fsm.Fsm;
			if (fsm2.HandleLegacyNetworking)
			{
				Type globalType = ReflectionUtils.GetGlobalType("PlayMakerLegacyNetworking");
				if (!AddEventHandlerComponent(fsm, globalType))
				{
					Debug.LogError("Could not add PlayMakerLegacyNetworking proxy!");
				}
			}
			Fsm fsm3 = fsm.Fsm;
			if (fsm3.HandleUiEvents != UiEvents.None)
			{
				HandleUiEvent<PlayMakerUiClickEvent>(fsm, UiEvents.Click);
				HandleUiEvent<PlayMakerUiDragEvents>(fsm, UiEvents.DragEvents);
				HandleUiEvent<PlayMakerUiDropEvent>(fsm, UiEvents.Drop);
				HandleUiEvent<PlayMakerUiPointerEvents>(fsm, UiEvents.PointerEvents);
				HandleUiEvent<PlayMakerUiBoolValueChangedEvent>(fsm, UiEvents.BoolValueChanged);
				HandleUiEvent<PlayMakerUiFloatValueChangedEvent>(fsm, UiEvents.FloatValueChanged);
				HandleUiEvent<PlayMakerUiIntValueChangedEvent>(fsm, UiEvents.IntValueChanged);
				HandleUiEvent<PlayMakerUiVector2ValueChangedEvent>(fsm, UiEvents.Vector2ValueChanged);
				HandleUiEvent<PlayMakerUiEndEditEvent>(fsm, UiEvents.EndEdit);
			}
		}

		[Token(Token = "0x6000361")]
		[Address(RVA = "0xBB3E90", Offset = "0xBB3E90", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = PlayMakerFSM::get_Fsm(fsm);\n\tv41 = v21.handleUiEvents & uiEvent;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0026;\n\tv52 = Il2CppMethodInfo;\n\tv44 = *([v52 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 31 IndirectJump v44 @ X2_v1, fsm @ X0 (PlayMakerFSM), fsm @ X0 (PlayMakerFSM), methodof(HutongGames.PlayMaker.FsmProcessor::AddUiEventHandler), v44 @ X2_v1, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_0026:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void HandleUiEvent<T>(PlayMakerFSM fsm, UiEvents uiEvent) where T : PlayMakerUiEventBase
		{
			//IL_004f: Expected O, but got I
			Fsm fsm2 = fsm.Fsm;
			if ((fsm2.HandleUiEvents & uiEvent) != UiEvents.None)
			{
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v44 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0xBB3D6C", Offset = "0xBB3D6C", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECAC28]);\n\tv23 = *([v22 @ X8_v19]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022C58]) = v41;\nL_001B:\n\tv47 = UnityEngine.Component::GetComponent(fsm);\n\tgoto L_002D;\n\tv77 = *([v51 @ X8_v9+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002D;\n\tv98 = v51;\n\tv82 = \"il2cpp_codegen_runtime_class_init\"(v98, v45, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002D:\n\tv86 = UnityEngine.Object::op_Equality(v47, 0);\n\tv100 = v86 == 0;\n\tif (v100) goto L_004D;\n\tv92 = UnityEngine.Component::get_gameObject(fsm);\n\tv136 = UnityEngine.GameObject::AddComponent(v92);\n\tgoto L_0049;\n\tv142 = *([v72 @ X8_v16+E0]);\n\tv143 = v142 == 0;\n\tv144 = ~v143;\n\tif (v144) goto L_0049;\n\tv149 = v72;\n\tv146 = \"il2cpp_codegen_runtime_class_init\"(v149, v63, v56, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0049:\n\tv66 = PlayMakerPrefs::get_ShowEventHandlerComponents();\n\tv103 = v66 == 0;\n\tif (v103) goto L_0056;\nL_004D:\n\tv104 = v133 == 0;\n\tv68 = ~v104;\n\tif (v68) goto L_0060;\n\tgoto L_0063;\nL_0056:\n\tUnityEngine.Object::set_hideFlags(v136, 2);\nL_0060:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::AddTargetFsm(v133, fsm);\n\treturn;\nL_0063:\n\tthrow System.NullReferenceException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void AddUiEventHandler<T>(PlayMakerFSM fsm) where T : PlayMakerUiEventBase
		{
			UnityEngine.Object component = fsm.GetComponent<T>();
			bool flag = component == null;
			bool flag2 = !flag;
			UnityEngine.Object obj = component;
			if (!flag2)
			{
				GameObject gameObject = fsm.gameObject;
				UnityEngine.Object obj2 = gameObject.AddComponent<T>();
				bool showEventHandlerComponents = PlayMakerPrefs.ShowEventHandlerComponents;
				bool flag3 = !showEventHandlerComponents;
				obj = obj2;
				if (flag3)
				{
					obj2.hideFlags = HideFlags.HideInInspector;
					obj = obj2;
					goto IL_00e4;
				}
			}
			if ((object)obj == null)
			{
				throw new NullReferenceException();
			}
			goto IL_00e4;
			IL_00e4:
			((PlayMakerUiEventBase)obj).AddTargetFsm(fsm);
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0x98AD5C", Offset = "0x98AD5C", Length = "0x1CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EDE410]);\n\tv23 = *([v22 @ X8_v39]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216CE]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = System.Type::op_Equality(type, 0);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_FFFFFFFF;\n\tv81 = UnityEngine.Component::get_gameObject(fsm);\n\tv121 = HutongGames.PlayMaker.FsmProcessor::GetEventHandlerComponent(v81, type);\n\tgoto L_0041;\n\tv138 = *([v75 @ X8_v12+E0]);\n\tv139 = v138 == 0;\n\tv140 = ~v139;\n\tif (v140) goto L_0041;\n\tv145 = v75;\n\tv142 = \"il2cpp_codegen_runtime_class_init\"(v145, v120, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0041:\n\tv71 = UnityEngine.Object::op_Equality(v121, 0);\n\tv73 = v71 == 0;\n\tif (v73) goto L_004C;\n\tgoto L_0097;\nL_004C:\n\tPlayMakerProxyBase::AddTarget(v121, fsm);\n\tgoto L_005D;\n\tv152 = *([1F0A568]);\n\tv153 = *([v152 @ X8_v34]);\n\tv154 = \"il2cpp_codegen_initialize_method\"(v153, v86, v84, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv157 = 0 | 1;\n\t*([2021711]) = v157;\nL_005D:\n\tv163 = ~v161.<IsEditor>k__BackingField;\n\tv164 = ~v163;\n\tif (v164) goto L_FFFFFFFF;\n\tgoto L_006D;\n\tv180 = *([v167 @ X0_v22+E0]);\n\tv181 = v180 == 0;\n\tv182 = ~v181;\n\tif (v182) goto L_006D;\n\tv184 = \"il2cpp_codegen_runtime_class_init\"(v167, v86, v84, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_006D:\n\tv88 = PlayMakerPrefs::get_LogPerformanceWarnings();\n\tv177 = v88 == 0;\n\tif (v177) goto L_FFFFFFFF;\n\tv192 = System.Type::get_FullName(type);\n\tv198 = System.String::Concat(\"AddEventHandlerComponent: \", v192);\n\tgoto L_008F;\n\tv204 = *([v179 @ X8_v31+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_008F;\n\tv209 = v179;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v209, v195, v172, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_008F:\n\tUnityEngine.Debug::Log(v198);\nL_0097:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 94 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool AddEventHandlerComponent(PlayMakerFSM fsm, Type type)
		{
			if (!(type == null))
			{
				GameObject gameObject = fsm.gameObject;
				PlayMakerProxyBase eventHandlerComponent = GetEventHandlerComponent(gameObject, type);
				if (!(eventHandlerComponent == null))
				{
					eventHandlerComponent.AddTarget(fsm);
					if (!PlayMakerGlobals.IsEditor && PlayMakerPrefs.LogPerformanceWarnings)
					{
						string fullName = type.FullName;
						string message = "AddEventHandlerComponent: " + fullName;
						Debug.Log(message);
					}
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x6000364")]
		[Address(RVA = "0x98AF28", Offset = "0x98AF28", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EF1148]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216CF]) = v41;\nL_001B:\n\tgoto L_0024;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0024;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, type, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0024:\n\tv58 = UnityEngine.Object::op_Equality(go, 0);\n\tv62 = v58 == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0091;\n\tv138 = UnityEngine.GameObject::GetComponent(go, type);\n\tgoto L_0040;\n\tv175 = *([v171 @ X8_v7+E0]);\n\tv176 = v175 == 0;\n\tv177 = ~v176;\n\tif (v177) goto L_0040;\n\tv183 = v171;\n\tv179 = \"il2cpp_codegen_runtime_class_init\"(v183, v136, v137, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0040:\n\tv182 = UnityEngine.Object::op_Equality(v138, 0);\n\tv163 = v182 == 0;\n\tif (v163) goto L_005C;\n\tv186 = UnityEngine.GameObject::AddComponent(go, type);\n\treturnVal3 = 0x98F768(v186, type, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal3;\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0057;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0057;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0057:\n\tX0 = 0;\n\tX0 = PlayMakerPrefs::get_ShowEventHandlerComponents(X0);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0060;\nL_005C:\n\tv187 = v138 == 0;\n\tv124 = ~v187;\n\tif (v124) goto L_0075;\n\tgoto L_FFFFFFFF;\nL_0060:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_0092;\n\tX1 = 0 | 2;\n\tX0 = X20;\n\tX2 = 0;\n\tUnityEngine.Object::set_hideFlags(X0, X1, X2);\nL_0075:\n\tgoto L_FFFFFFFF;\n\tgoto L_0091;\n\tv67 = v67_asT == 0;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0091;\nL_0091:\n\treturn returnVal1;\nL_0092:\n\t;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PlayMakerProxyBase GetEventHandlerComponent(GameObject go, Type type)
		{
			bool flag = go == null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			PlayMakerProxyBase result = null;
			if (!flag3)
			{
				Component component = go.GetComponent(type);
				if (component == null)
				{
					Component component2 = go.AddComponent(type);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @98F768 (inside PEButtonScript::.ctor +0xC)");
					PlayMakerProxyBase result2 = default(PlayMakerProxyBase);
					return result2;
				}
				if ((object)component == null)
				{
					result = null;
				}
				else
				{
					PlayMakerProxyBase playMakerProxyBase = component as PlayMakerProxyBase;
					result = (PlayMakerProxyBase)(((object)playMakerProxyBase == null) ? null : component);
				}
			}
			return result;
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0x98B09C", Offset = "0x98B09C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmProcessor()
		{
		}
	}
}
