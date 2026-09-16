using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x74CED0", Offset = "0x74CED0")]
	[Token(Token = "0x2000071")]
	public class PlayMakerUiClickEvent : PlayMakerUiEventBase
	{
		[Token(Token = "0x40002C3")]
		[FieldOffset(Offset = "0x28")]
		public Button button;

		[Token(Token = "0x6000339")]
		[Address(RVA = "0x98B538", Offset = "0x98B538", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EF4890]);\n\tv21 = *([v20 @ X8_v23]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216D3]) = v40;\nL_0015:\n\tv42 = ~this.initialized;\n\tv43 = ~v42;\n\tif (v43) goto L_006A;\n\tthis.initialized = 1;\n\tgoto L_002A;\n\tv70 = *([v48 @ X0_v3+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_002A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002A:\n\tv80 = UnityEngine.Object::op_Equality(this.button, 0);\n\tv112 = v80 == 0;\n\tif (v112) goto L_0036;\n\tv117 = UnityEngine.Component::GetComponent(this);\n\tthis.button = v117;\n\tgoto L_003B;\nL_0036:\n\tv64 = this.button;\nL_003B:\n\tgoto L_0044;\n\tv127 = *([v123 @ X0_v8+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tgoto L_0044;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v123, v120, v79, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0044:\n\tv58 = UnityEngine.Object::op_Inequality(v64, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_006A;\n\tv135 = this.button;\n\tv141 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v141, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::AddListener(v135.m_OnClick, v141);\n\treturn;\nL_006A:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				Button button = ((!(this.button == null)) ? this.button : (this.button = GetComponent<Button>()));
				if (button != null)
				{
					Button button2 = this.button;
					UnityAction call = DoOnClick;
					button2.onClick.AddListener(call);
				}
			}
		}

		[Token(Token = "0x600033A")]
		[Address(RVA = "0x98B678", Offset = "0x98B678", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1F04BA8]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216D4]) = v40;\nL_0014:\n\tthis.initialized = 0;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0025:\n\tv58 = UnityEngine.Object::op_Inequality(this.button, 0);\n\tv60 = v58 == 0;\n\tif (v60) goto L_004B;\n\tv61 = this.button;\n\tv72 = new UnityEngine.Events.UnityAction();\n\tUnityEngine.Events.UnityAction::.ctor(v72, this, Il2CppMethodInfo);\n\tUnityEngine.Events.UnityEvent::RemoveListener(v61.m_OnClick, v72);\n\treturn;\nL_004B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void OnDisable()
		{
			initialized = false;
			if (this.button != null)
			{
				Button button = this.button;
				UnityAction call = DoOnClick;
				button.onClick.RemoveListener(call);
			}
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0x98B75C", Offset = "0x98B75C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB1488]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20216D5]) = v40;\nL_001A:\n\tgoto L_0024;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0024;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0024:\n\tgoto L_002F;\n\tv59 = *([1EEC8C0]);\n\tv60 = *([v59 @ X8_v12]);\n\tv61 = \"il2cpp_codegen_initialize_method\"(v60, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv64 = 0 | 1;\n\t*([2021713]) = v64;\nL_002F:\n\tgoto L_003F;\n\tv69 = *([v65 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_003F;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv73 = HutongGames.PlayMaker.FsmEvent;\nL_003F:\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::SendEvent(this, v76.<UiClick>k__BackingField);\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoOnClick()
		{
			SendEvent(FsmEvent.UiClick);
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0x98B810", Offset = "0x98B810", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.PlayMakerUiEventBase::.ctor(this);\n\treturn;\n")]
		public PlayMakerUiClickEvent()
		{
		}
	}
}
