using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74D020", Offset = "0x74D020")]
	[Token(Token = "0x2000078")]
	public class PlayMakerUiPointerEvents : PlayMakerUiEventBase, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
	{
		[Token(Token = "0x6000356")]
		[Address(RVA = "0x98C7F8", Offset = "0x98C7F8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBAF70]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216E7]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1ECDFF8]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([202171B]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiPointerClick>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerClick(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiPointerClick);
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0x98C8C4", Offset = "0x98C8C4", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE08E8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216E8]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EF1730]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([202171C]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiPointerDown>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerDown(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiPointerDown);
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0x98C990", Offset = "0x98C990", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC2B30]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216E9]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1F07E00]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([202171D]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiPointerEnter>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerEnter(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiPointerEnter);
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0x98CA5C", Offset = "0x98CA5C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBE058]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216EA]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EA6700]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([202171E]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiPointerExit>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerExit(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiPointerExit);
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0x98CB28", Offset = "0x98CB28", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EEC228]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216EB]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EFA9E0]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([202171F]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiPointerUp>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnPointerUp(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiPointerUp);
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0x98CBF4", Offset = "0x98CBF4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiPointerEvents()
		{
		}
	}
}
