using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CF08", Offset = "0x74CF08")]
	[Token(Token = "0x2000072")]
	public class PlayMakerUiDragEvents : PlayMakerUiEventBase, IDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler
	{
		[Token(Token = "0x600033D")]
		[Address(RVA = "0x98B814", Offset = "0x98B814", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF9BC8]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216D6]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EE0108]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([2021714]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiBeginDrag>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnBeginDrag(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiBeginDrag);
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0x98B8E0", Offset = "0x98B8E0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EBF970]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216D7]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EAC728]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([2021715]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiDrag>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDrag(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiDrag);
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0x98B9AC", Offset = "0x98B9AC", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EACA78]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216D8]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1EC3670]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([2021716]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiEndDrag>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEndDrag(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiEndDrag);
		}

		[Token(Token = "0x6000340")]
		[Address(RVA = "0x98BA78", Offset = "0x98BA78", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiDragEvents()
		{
		}
	}
}
