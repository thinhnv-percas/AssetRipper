using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CF78", Offset = "0x74CF78")]
	[Token(Token = "0x2000074")]
	public class PlayMakerUiEndEditEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002C4")]
		[FieldOffset(Offset = "0x28")]
		public InputField inputField;

		[Token(Token = "0x6000343")]
		[Address(RVA = "0x98BB4C", Offset = "0x98BB4C", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EA77F0]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216DA]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tv43 = ~v42;\n\tif (v43) goto L_006E;\n\tthis.initialized = 1;\n\tgoto L_002A;\n\tv70 = *([v48 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv80 = UnityEngine.Object::op_Equality(this.inputField, 0);\n\tv116 = v80 == 0;\n\tif (v116) goto L_0036;\n\tv121 = UnityEngine.Component::GetComponent(this);\n\tthis.inputField = v121;\n\tgoto L_003B;\nL_0036:\n\tv64 = this.inputField;\nL_003B:\n\tgoto L_0044;\n\tv131 = *([v127 @ X0_v8+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0044;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v124, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv58 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006E;\n\tv139 = this.inputField;\n\tv145 = new UnityEngine.Events.UnityAction`1<System.String>();\n\tUnityEngine.Events.UnityAction`1<System.String>::.ctor(v145, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.String>::AddListener(v139.m_OnEndEdit, v145);\n\treturn;\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				InputField inputField = ((!(this.inputField == null)) ? this.inputField : (this.inputField = GetComponent<InputField>()));
				if (inputField != null)
				{
					InputField inputField2 = this.inputField;
					UnityAction<string> call = DoOnEndEdit;
					inputField2.onEndEdit.AddListener(call);
				}
			}
		}

		[Token(Token = "0x6000344")]
		[Address(RVA = "0x98BC9C", Offset = "0x98BC9C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EE5AD0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216DB]) = v40;\nL_0014:\n\tthis.initialized = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(this.inputField, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004F;\n\tv61 = this.inputField;\n\tv72 = new UnityEngine.Events.UnityAction`1<System.String>();\n\tUnityEngine.Events.UnityAction`1<System.String>::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.String>::RemoveListener(v61.m_OnEndEdit, v72);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.inputField != null)
			{
				InputField inputField = this.inputField;
				UnityAction<string> call = DoOnEndEdit;
				inputField.onEndEdit.RemoveListener(call);
			}
		}

		[Token(Token = "0x6000345")]
		[Address(RVA = "0x98BD90", Offset = "0x98BD90", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE4C30]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216DC]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv56.StringData = value;\n\tgoto L_0037;\n\tv67 = *([v61 @ X0_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0037;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v61, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0037:\n\tgoto L_0042;\n\tv79 = *([1F0E6E0]);\n\tv80 = *([v79 @ X8_v16]);\n\tv81 = \"il2cpp_codegen_initialize_method\"(v80, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv84 = 0 | 1;\n\t*([2021718]) = v84;\nL_0042:\n\tgoto L_0052;\n\tv107 = *([v85 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tgoto L_0052;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v85, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv111 = HutongGames.PlayMaker.FsmEvent;\nL_0052:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v102.<UiEndEdit>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoOnEndEdit(string value)
		{
			FsmEventData eventData = Fsm.EventData;
			eventData.StringData = value;
			SendEvent(FsmEvent.UiEndEdit);
		}

		[Token(Token = "0x6000346")]
		[Address(RVA = "0x98BE84", Offset = "0x98BE84", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiEndEditEvent()
		{
		}
	}
}
