using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CFE8", Offset = "0x74CFE8")]
	[Token(Token = "0x2000077")]
	public class PlayMakerUiIntValueChangedEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002C9")]
		[FieldOffset(Offset = "0x28")]
		public Dropdown dropdown;

		[Token(Token = "0x6000352")]
		[Address(RVA = "0x98C4BC", Offset = "0x98C4BC", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0E128]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216E4]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tv43 = ~v42;\n\tif (v43) goto L_006E;\n\tthis.initialized = 1;\n\tgoto L_002A;\n\tv70 = *([v48 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv80 = UnityEngine.Object::op_Equality(this.dropdown, 0);\n\tv116 = v80 == 0;\n\tif (v116) goto L_0036;\n\tv121 = UnityEngine.Component::GetComponent(this);\n\tthis.dropdown = v121;\n\tgoto L_003B;\nL_0036:\n\tv64 = this.dropdown;\nL_003B:\n\tgoto L_0044;\n\tv131 = *([v127 @ X0_v8+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0044;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v124, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv58 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006E;\n\tv139 = this.dropdown;\n\tv145 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v145, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::AddListener(v139.m_OnValueChanged, v145);\n\treturn;\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				Dropdown dropdown = ((!(this.dropdown == null)) ? this.dropdown : (this.dropdown = GetComponent<Dropdown>()));
				if (dropdown != null)
				{
					Dropdown dropdown2 = this.dropdown;
					UnityAction<int> call = OnValueChanged;
					dropdown2.onValueChanged.AddListener(call);
				}
			}
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0x98C60C", Offset = "0x98C60C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1ECE338]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216E5]) = v40;\nL_0014:\n\tthis.initialized = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(this.dropdown, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004F;\n\tv61 = this.dropdown;\n\tv72 = new UnityEngine.Events.UnityAction`1<System.Int32>();\n\tUnityEngine.Events.UnityAction`1<System.Int32>::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Int32>::RemoveListener(v61.m_OnValueChanged, v72);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.dropdown != null)
			{
				Dropdown dropdown = this.dropdown;
				UnityAction<int> call = OnValueChanged;
				dropdown.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0x98C700", Offset = "0x98C700", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EE6B10]);\n\tv23 = *([v22 @ X8_v22]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20216E6]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = HutongGames.PlayMaker.Fsm;\nL_0023:\n\tv56 = v55.EventData;\n\tv56.IntData = value;\n\tgoto L_0037;\n\tv67 = *([v61 @ X0_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0037;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v61, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0037:\n\tgoto L_0042;\n\tv79 = *([1EC3C18]);\n\tv80 = *([v79 @ X8_v16]);\n\tv81 = \"il2cpp_codegen_initialize_method\"(v80, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv84 = 0 | 1;\n\t*([202171A]) = v84;\nL_0042:\n\tgoto L_0052;\n\tv107 = *([v85 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tgoto L_0052;\n\tv113 = \"il2cpp_codegen_runtime_class_init\"(v85, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv111 = HutongGames.PlayMaker.FsmEvent;\nL_0052:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v102.<UiIntValueChanged>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValueChanged(int value)
		{
			FsmEventData eventData = Fsm.EventData;
			eventData.IntData = value;
			SendEvent(FsmEvent.UiIntValueChanged);
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0x98C7F4", Offset = "0x98C7F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiIntValueChangedEvent()
		{
		}
	}
}
