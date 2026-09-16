using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75BD20", Offset = "0x75BD20")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75BD20", Offset = "0x75BD20")]
	[Token(Token = "0x2000301")]
	public class RectTransformFlipLayoutAxis : FsmStateAction
	{
		[Token(Token = "0x2000492")]
		public enum RectTransformFlipOptions
		{
			[Token(Token = "0x4002199")]
			Horizontal = 0,
			[Token(Token = "0x400219A")]
			Vertical = 1,
			[Token(Token = "0x400219B")]
			Both = 2
		}

		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7C275C", Offset = "0x7C275C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C275C", Offset = "0x7C275C")]
		[Token(Token = "0x4001949")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C27F4", Offset = "0x7C27F4")]
		[Token(Token = "0x400194A")]
		[FieldOffset(Offset = "0x58")]
		public RectTransformFlipOptions axis;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C282C", Offset = "0x7C282C")]
		[Token(Token = "0x400194B")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool keepPositioning;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7C2864", Offset = "0x7C2864")]
		[Token(Token = "0x400194C")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool recursive;

		[Token(Token = "0x6000F17")]
		[Address(RVA = "0xB1F1F0", Offset = "0xB1F1F0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.axis = 2;\n\tthis.keepPositioning = 0;\n\tthis.recursive = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			axis = RectTransformFlipOptions.Both;
			keepPositioning = null;
			recursive = null;
		}

		[Token(Token = "0x6000F18")]
		[Address(RVA = "0xB1F204", Offset = "0xB1F204", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RectTransformFlipLayoutAxis::DoFlip(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoFlip();
			Finish();
		}

		[Token(Token = "0x6000F19")]
		[Address(RVA = "0xB1F22C", Offset = "0xB1F22C", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB17E0]);\n\tv21 = *([v20 @ X8_v26]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022594]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv149 = *([v105 @ X8_v5+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_002B;\n\tv156 = v105;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v156, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv129 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv158 = v129 == 0;\n\tif (v158) goto L_008D;\n\tv213 = UnityEngine.GameObject::GetComponent(v45);\n\tgoto L_0045;\n\tv247 = *([v237 @ X8_v9+E0]);\n\tv248 = v247 == 0;\n\tv249 = ~v248;\n\tif (v249) goto L_0045;\n\tv254 = v237;\n\tv251 = \"il2cpp_codegen_runtime_class_init\"(v254, v242, v122, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv234 = UnityEngine.Object::op_Inequality(v213, 0);\n\tv235 = v234 == 0;\n\tif (v235) goto L_008D;\n\tv236 = this.axis == 0;\n\tif (v236) goto L_0092;\n\tv68 = this.axis == 1;\n\tif (v68) goto L_00B1;\n\tv47 = this.axis != 2;\n\tif (v47) goto L_008D;\n\tv130 = HutongGames.PlayMaker.FsmBool::get_Value(this.keepPositioning);\n\tv273 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tgoto L_0085;\n\tv312 = *([v223 @ X8_v23+E0]);\n\tv313 = v312 == 0;\n\tv314 = ~v313;\n\tif (v314) goto L_0085;\n\tv318 = v223;\n\tv316 = \"il2cpp_codegen_runtime_class_init\"(v318, v272, v87, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0085:\n\tUnityEngine.RectTransformUtility::FlipLayoutAxes(v213, v130, v273);\n\treturn;\nL_008D:\n\treturn;\nL_0092:\n\tv131 = HutongGames.PlayMaker.FsmBool::get_Value(this.keepPositioning);\n\tv260 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tgoto L_FFFFFFFF;\n\tv281 = *([v267 @ X8_v15+E0]);\n\tv282 = v281 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_FFFFFFFF;\n\tv309 = v267;\n\tv286 = \"il2cpp_codegen_runtime_class_init\"(v309, v259, v87, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00D2;\nL_00B1:\n\tv132 = HutongGames.PlayMaker.FsmBool::get_Value(this.keepPositioning);\n\tv263 = HutongGames.PlayMaker.FsmBool::get_Value(this.recursive);\n\tgoto L_FFFFFFFF;\n\tv298 = *([v277 @ X8_v19+E0]);\n\tv299 = v298 == 0;\n\tv300 = ~v299;\n\tif (v300) goto L_FFFFFFFF;\n\tv317 = v277;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v317, v262, v87, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_00D2:\n\tUnityEngine.RectTransformUtility::FlipLayoutOnAxis(v213, v209, v205, v163);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 146 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoFlip()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget != null))
			{
				return;
			}
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			if (!(component != null))
			{
				return;
			}
			bool flag;
			bool flag2;
			int num;
			if (axis != RectTransformFlipOptions.Horizontal)
			{
				if (axis != RectTransformFlipOptions.Vertical)
				{
					if (axis == RectTransformFlipOptions.Both)
					{
						bool value = keepPositioning.Value;
						bool value2 = recursive.Value;
						RectTransformUtility.FlipLayoutAxes(component, value, value2);
					}
					return;
				}
				bool value3 = keepPositioning.Value;
				bool value4 = recursive.Value;
				flag = value4;
				flag2 = value3;
				num = 1;
			}
			else
			{
				bool value5 = keepPositioning.Value;
				bool value6 = recursive.Value;
				flag = value6;
				flag2 = value5;
				num = 0;
			}
			RectTransformUtility.FlipLayoutOnAxis(component, num, flag2, flag);
		}

		[Token(Token = "0x6000F1A")]
		[Address(RVA = "0xB1F47C", Offset = "0xB1F47C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RectTransformFlipLayoutAxis()
		{
		}
	}
}
