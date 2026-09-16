using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CFB0", Offset = "0x74CFB0")]
	[Token(Token = "0x2000076")]
	public class PlayMakerUiFloatValueChangedEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002C7")]
		[FieldOffset(Offset = "0x28")]
		public Slider slider;

		[Token(Token = "0x40002C8")]
		[FieldOffset(Offset = "0x30")]
		public Scrollbar scrollbar;

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x98C010", Offset = "0x98C010", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE3F68]);\n\tv23 = *([v22 @ X8_v42]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20216E1]) = v42;\nL_0016:\n\tv44 = ~this.initialized;\n\tv45 = ~v44;\n\tif (v45) goto L_00B6;\n\tthis.initialized = 1;\n\tgoto L_002B;\n\tv80 = *([v50 @ X0_v3+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_002B;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002B:\n\tv90 = UnityEngine.Object::op_Equality(this.slider, 0);\n\tv127 = v90 == 0;\n\tif (v127) goto L_0037;\n\tv132 = UnityEngine.Component::GetComponent(this);\n\tthis.slider = v132;\n\tgoto L_003C;\nL_0037:\n\tv138 = this.slider;\nL_003C:\n\tgoto L_0045;\n\tv143 = *([v139 @ X0_v8+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tgoto L_0045;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v139, v135, v89, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0045:\n\tv153 = UnityEngine.Object::op_Inequality(v138, 0);\n\tv155 = v153 == 0;\n\tif (v155) goto L_0067;\n\tv156 = this.slider;\n\tv181 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v181, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v156.m_OnValueChanged, v181);\nL_0067:\n\tgoto L_0070;\n\tv195 = *([v173 @ X0_v16+E0]);\n\tv196 = v195 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0070;\n\tv199 = \"il2cpp_codegen_runtime_class_init\"(v173, v163, v161, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0070:\n\tv205 = UnityEngine.Object::op_Equality(this.scrollbar, 0);\n\tv209 = v205 == 0;\n\tif (v209) goto L_007C;\n\tv214 = UnityEngine.Component::GetComponent(this);\n\tthis.scrollbar = v214;\n\tgoto L_0081;\nL_007C:\n\tv73 = this.scrollbar;\nL_0081:\n\tgoto L_008A;\n\tv225 = *([v221 @ X0_v21+E0]);\n\tv226 = v225 == 0;\n\tv227 = ~v226;\n\tgoto L_008A;\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v221, v218, v204, v55, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_008A:\n\tv67 = UnityEngine.Object::op_Inequality(v73, 0);\n\tv69 = v67 == 0;\n\tif (v69) goto L_00B6;\n\tv191 = this.scrollbar;\n\tv188 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v188, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::AddListener(v191.m_OnValueChanged, v188);\n\treturn;\nL_00B6:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				Slider slider = ((!(this.slider == null)) ? this.slider : (this.slider = GetComponent<Slider>()));
				if (slider != null)
				{
					Slider slider2 = this.slider;
					UnityAction<float> call = OnValueChanged;
					slider2.onValueChanged.AddListener(call);
				}
				Scrollbar scrollbar = ((!(this.scrollbar == null)) ? this.scrollbar : (this.scrollbar = GetComponent<Scrollbar>()));
				if (scrollbar != null)
				{
					Scrollbar scrollbar2 = this.scrollbar;
					UnityAction<float> call2 = OnValueChanged;
					scrollbar2.onValueChanged.AddListener(call2);
				}
			}
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0x98C23C", Offset = "0x98C23C", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEBBD0]);\n\tv23 = *([v22 @ X8_v27]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20216E2]) = v42;\nL_0015:\n\tthis.initialized = 0;\n\tgoto L_0026;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0026;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0026:\n\tv60 = UnityEngine.Object::op_Inequality(this.slider, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0048;\n\tv63 = this.slider;\n\tv92 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v92, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::RemoveListener(v63.m_OnValueChanged, v92);\nL_0048:\n\tgoto L_0051;\n\tv121 = *([v84 @ X0_v10+E0]);\n\tv122 = v121 == 0;\n\tv123 = ~v122;\n\tif (v123) goto L_0051;\n\tv125 = \"il2cpp_codegen_runtime_class_init\"(v84, v74, v72, v65, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0051:\n\tv108 = UnityEngine.Object::op_Inequality(this.scrollbar, 0);\n\tv132 = v108 == 0;\n\tif (v132) goto L_007D;\n\tv115 = this.scrollbar;\n\tv109 = new UnityEngine.Events.UnityAction`1<System.Single>();\n\tUnityEngine.Events.UnityAction`1<System.Single>::.ctor(v109, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<System.Single>::RemoveListener(v115.m_OnValueChanged, v109);\n\treturn;\nL_007D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 92 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.slider != null)
			{
				Slider slider = this.slider;
				UnityAction<float> call = OnValueChanged;
				slider.onValueChanged.RemoveListener(call);
			}
			if (this.scrollbar != null)
			{
				Scrollbar scrollbar = this.scrollbar;
				UnityAction<float> call2 = OnValueChanged;
				scrollbar.onValueChanged.RemoveListener(call2);
			}
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0x98C3BC", Offset = "0x98C3BC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EC07F0]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20216E3]) = v43;\nL_001C:\n\tgoto L_0024;\n\tv50 = *([v46 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0024;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v46, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = HutongGames.PlayMaker.Fsm;\nL_0024:\n\tv58 = v57.EventData;\n\tv58.FloatData = value;\n\tgoto L_0038;\n\tv69 = *([v63 @ X0_v6+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tif (v71) goto L_0038;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\nL_0038:\n\tgoto L_0043;\n\tv81 = *([1EA83F8]);\n\tv82 = *([v81 @ X8_v16]);\n\tv83 = \"il2cpp_codegen_initialize_method\"(v82, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv86 = 0 | 1;\n\t*([2021719]) = v86;\nL_0043:\n\tgoto L_0054;\n\tv111 = *([v87 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv112 = v111 == 0;\n\tv113 = ~v112;\n\tgoto L_0054;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v87, methodInfo, v28, v29, v30, v31, v32, v33, value, v34, v35, v36, v37, v38, v39, v40);\n\tv115 = HutongGames.PlayMaker.FsmEvent;\nL_0054:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v106.<UiFloatValueChanged>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValueChanged(float value)
		{
			FsmEventData eventData = Fsm.EventData;
			eventData.FloatData = value;
			SendEvent(FsmEvent.UiFloatValueChanged);
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0x98C4B8", Offset = "0x98C4B8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiFloatValueChangedEvent()
		{
		}
	}
}
