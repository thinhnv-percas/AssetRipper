using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CE98", Offset = "0x74CE98")]
	[Token(Token = "0x2000070")]
	public class PlayMakerUiBoolValueChangedEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002C2")]
		[FieldOffset(Offset = "0x28")]
		public Toggle toggle;

		[Token(Token = "0x6000335")]
		[Address(RVA = "0x98B0BC", Offset = "0x98B0BC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EB5798]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216D0]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tv43 = ~v42;\n\tif (v43) goto L_006E;\n\tthis.initialized = 1;\n\tgoto L_002A;\n\tv70 = *([v48 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv80 = UnityEngine.Object::op_Equality(this.toggle, 0);\n\tv116 = v80 == 0;\n\tif (v116) goto L_0036;\n\tv121 = UnityEngine.Component::GetComponent(this);\n\tthis.toggle = v121;\n\tgoto L_003B;\nL_0036:\n\tv64 = this.toggle;\nL_003B:\n\tgoto L_0044;\n\tv131 = *([v127 @ X0_v8+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0044;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v124, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv58 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006E;\n\tv139 = this.toggle;\n\tv145 = new UnityEngine.Events.UnityAction`1<System.Boolean>();\n\tUnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(v145, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::AddListener(v139.onValueChanged, v145);\n\treturn;\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				Toggle toggle = ((!(this.toggle == null)) ? this.toggle : (this.toggle = GetComponent<Toggle>()));
				if (toggle != null)
				{
					Toggle toggle2 = this.toggle;
					UnityAction<bool> call = OnValueChanged;
					toggle2.onValueChanged.AddListener(call);
				}
			}
		}

		[Token(Token = "0x6000336")]
		[Address(RVA = "0x98B20C", Offset = "0x98B20C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECD7A0]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216D1]) = v40;\nL_0014:\n\tthis.initialized = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(this.toggle, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004F;\n\tv61 = this.toggle;\n\tv72 = new UnityEngine.Events.UnityAction`1<System.Boolean>();\n\tUnityEngine.Events.UnityAction`1<System.Boolean>::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Boolean>::RemoveListener(v61.onValueChanged, v72);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.toggle != null)
			{
				Toggle toggle = this.toggle;
				UnityAction<bool> call = OnValueChanged;
				toggle.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x6000337")]
		[Address(RVA = "0x98B300", Offset = "0x98B300", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ECA038]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216D2]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv56.BoolData = value;\n\tgoto L_0038;\n\tv68 = *([v62 @ X0_v6+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0038;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v62, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0038:\n\tgoto L_0043;\n\tv80 = *([1EC8DC8]);\n\tv81 = *([v80 @ X8_v16]);\n\tv82 = \"il2cpp_codegen_initialize_method\"(v81, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv85 = 0 | 1;\n\t*([2021712]) = v85;\nL_0043:\n\tgoto L_0053;\n\tv110 = *([v86 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv111 = v110 == 0;\n\tv112 = ~v111;\n\tgoto L_0053;\n\tv116 = \"il2cpp_codegen_runtime_class_init\"(v86, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv114 = HutongGames.PlayMaker.FsmEvent;\nL_0053:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v105.<UiBoolValueChanged>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValueChanged(bool value)
		{
			FsmEventData eventData = Fsm.EventData;
			eventData.BoolData = value;
			SendEvent(FsmEvent.UiBoolValueChanged);
		}

		[Token(Token = "0x6000338")]
		[Address(RVA = "0x98B4C4", Offset = "0x98B4C4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiBoolValueChangedEvent()
		{
		}
	}
}
