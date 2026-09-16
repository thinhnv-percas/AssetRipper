using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74D058", Offset = "0x74D058")]
	[Token(Token = "0x2000079")]
	public class PlayMakerUiVector2ValueChangedEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002CA")]
		[FieldOffset(Offset = "0x28")]
		public ScrollRect scrollRect;

		[Token(Token = "0x600035C")]
		[Address(RVA = "0x98CBF8", Offset = "0x98CBF8", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1ED3030]);\n\tv21 = *([v20 @ X8_v25]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216EC]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tv43 = ~v42;\n\tif (v43) goto L_006E;\n\tthis.initialized = 1;\n\tgoto L_002A;\n\tv70 = *([v48 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv80 = UnityEngine.Object::op_Equality(this.scrollRect, 0);\n\tv116 = v80 == 0;\n\tif (v116) goto L_0036;\n\tv121 = UnityEngine.Component::GetComponent(this);\n\tthis.scrollRect = v121;\n\tgoto L_003B;\nL_0036:\n\tv64 = this.scrollRect;\nL_003B:\n\tgoto L_0044;\n\tv131 = *([v127 @ X0_v8+E0]);\n\tv132 = v131 == 0;\n\tv133 = ~v132;\n\tgoto L_0044;\n\tv135 = \"il2cpp_codegen_runtime_class_init\"(v127, v124, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv58 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006E;\n\tv139 = this.scrollRect;\n\tv145 = new UnityEngine.Events.UnityAction`1<UnityEngine.Vector2>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Vector2>::.ctor(v145, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Vector2>::AddListener(v139.m_OnValueChanged, v145);\n\treturn;\nL_006E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				ScrollRect scrollRect = ((!(this.scrollRect == null)) ? this.scrollRect : (this.scrollRect = GetComponent<ScrollRect>()));
				if (scrollRect != null)
				{
					ScrollRect scrollRect2 = this.scrollRect;
					UnityAction<Vector2> call = OnValueChanged;
					scrollRect2.onValueChanged.AddListener(call);
				}
			}
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0x98CD48", Offset = "0x98CD48", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F06B10]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216ED]) = v40;\nL_0014:\n\tthis.initialized = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(this.scrollRect, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004F;\n\tv61 = this.scrollRect;\n\tv72 = new UnityEngine.Events.UnityAction`1<UnityEngine.Vector2>();\n\tUnityEngine.Events.UnityAction`1<UnityEngine.Vector2>::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent`1<UnityEngine.Vector2>::RemoveListener(v61.m_OnValueChanged, v72);\n\treturn;\nL_004F:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.scrollRect != null)
			{
				ScrollRect scrollRect = this.scrollRect;
				UnityAction<Vector2> call = OnValueChanged;
				scrollRect.onValueChanged.RemoveListener(call);
			}
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0x98CE3C", Offset = "0x98CE3C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1F081D8]);\n\tv29 = *([v28 @ X8_v22]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, value, v0, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20216EE]) = v46;\nL_001F:\n\tgoto L_0027;\n\tv53 = *([v49 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v32, v33, v34, v35, v36, v37, value, v0, v38, v39, v40, v41, v42, v43);\n\tv57 = HutongGames.PlayMaker.Fsm;\nL_0027:\n\tv61 = v60.EventData;\n\tv61.Vector2Data = value;\n\tv61.Vector2Data.y = value.y;\n\tgoto L_003C;\n\tv72 = *([v66 @ X0_v6+E0]);\n\tv73 = v72 == 0;\n\tv74 = ~v73;\n\tif (v74) goto L_003C;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v66, methodInfo, v32, v33, v34, v35, v36, v37, value, v0, v38, v39, v40, v41, v42, v43);\nL_003C:\n\tgoto L_0047;\n\tv84 = *([1ED26D0]);\n\tv85 = *([v84 @ X8_v16]);\n\tv86 = \"il2cpp_codegen_initialize_method\"(v85, methodInfo, v32, v33, v34, v35, v36, v37, value, v0, v38, v39, v40, v41, v42, v43);\n\tv89 = 0 | 1;\n\t*([2021720]) = v89;\nL_0047:\n\tgoto L_0059;\n\tv116 = *([v90 @ X0_v9 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv117 = v116 == 0;\n\tv118 = ~v117;\n\tgoto L_0059;\n\tv122 = \"il2cpp_codegen_runtime_class_init\"(v90, methodInfo, v32, v33, v34, v35, v36, v37, value, v0, v38, v39, v40, v41, v42, v43);\n\tv120 = HutongGames.PlayMaker.FsmEvent;\nL_0059:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v111.<UiVector2ValueChanged>k__BackingField);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValueChanged(Vector2 value)
		{
			FsmEventData eventData = Fsm.EventData;
			eventData.Vector2Data = value;
			eventData.Vector2Data.y = value.y;
			SendEvent(FsmEvent.UiVector2ValueChanged);
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x98CF3C", Offset = "0x98CF3C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiVector2ValueChangedEvent()
		{
		}
	}
}
