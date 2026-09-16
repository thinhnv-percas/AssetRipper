using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CF40", Offset = "0x74CF40")]
	[Token(Token = "0x2000073")]
	public class PlayMakerUiDropEvent : PlayMakerUiEventBase, IDropHandler, IEventSystemHandler
	{
		[Token(Token = "0x6000341")]
		[Address(RVA = "0x98BA7C", Offset = "0x98BA7C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EE4578]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216D9]) = v41;\nL_0019:\n\tv45.lastPointerEventData = eventData;\n\tgoto L_002A;\n\tv52 = *([v48 @ X0_v2+E0]);\n\tv53 = v52 == 0;\n\tv54 = ~v53;\n\tgoto L_002A;\n\tv56 = \"il2cpp_codegen_runtime_class_init\"(v48, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002A:\n\tgoto L_0035;\n\tv64 = *([1ECFE90]);\n\tv65 = *([v64 @ X8_v16]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv69 = 0 | 1;\n\t*([2021717]) = v69;\nL_0035:\n\tgoto L_0045;\n\tv74 = *([v70 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0045;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v70, eventData, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv78 = HutongGames.PlayMaker.FsmEvent;\nL_0045:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v81.<UiDrop>k__BackingField);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnDrop(PointerEventData eventData)
		{
			UiGetLastPointerDataInfo.lastPointerEventData = eventData;
			SendEvent(FsmEvent.UiDrop);
		}

		[Token(Token = "0x6000342")]
		[Address(RVA = "0x98BB48", Offset = "0x98BB48", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiDropEvent()
		{
		}
	}
}
