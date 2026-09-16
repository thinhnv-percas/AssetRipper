using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x752014", Offset = "0x752014")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x752014", Offset = "0x752014")]
	[Token(Token = "0x200011D")]
	public class AddAnimationClip : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7A1FD4", Offset = "0x7A1FD4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A1FD4", Offset = "0x7A1FD4")]
		[Token(Token = "0x40010AD")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7A206C", Offset = "0x7A206C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A206C", Offset = "0x7A206C")]
		[Token(Token = "0x40010AE")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject animationClip;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2104", Offset = "0x7A2104")]
		[Token(Token = "0x40010AF")]
		[FieldOffset(Offset = "0x60")]
		public FsmString animationName;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2150", Offset = "0x7A2150")]
		[Token(Token = "0x40010B0")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt firstFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A2188", Offset = "0x7A2188")]
		[Token(Token = "0x40010B1")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt lastFrame;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7A21C0", Offset = "0x7A21C0")]
		[Token(Token = "0x40010B2")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool addLoopFrame;

		[Token(Token = "0x6000687")]
		[Address(RVA = "0xA12044", Offset = "0xA12044", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB0870]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D10]) = v38;\nL_0013:\n\tthis.gameObject = 0;\n\tthis.animationClip = 0;\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"\");\n\tthis.animationName = v43;\n\tv46 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.firstFrame = v46;\n\tv49 = HutongGames.PlayMaker.FsmInt::op_Implicit(0);\n\tthis.lastFrame = v49;\n\tv52 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.addLoopFrame = v52;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			animationClip = null;
			FsmString fsmString = "";
			animationName = fsmString;
			FsmInt fsmInt = 0;
			firstFrame = fsmInt;
			FsmInt fsmInt2 = 0;
			lastFrame = fsmInt2;
			FsmBool fsmBool = false;
			addLoopFrame = fsmBool;
		}

		[Token(Token = "0x6000688")]
		[Address(RVA = "0xA120D0", Offset = "0xA120D0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AddAnimationClip::DoAddAnimationClip(this);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoAddAnimationClip();
			Finish();
		}

		[Token(Token = "0x6000689")]
		[Address(RVA = "0xA120F8", Offset = "0xA120F8", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv24 = *([1EAFF40]);\n\tv25 = *([v24 @ X8_v22]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D11]) = v44;\nL_001B:\n\tv49 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002D;\n\tv165 = *([v105 @ X8_v5+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\tif (v167) goto L_002D;\n\tv173 = v105;\n\tv169 = \"il2cpp_codegen_runtime_class_init\"(v173, v47, v48, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tv172 = UnityEngine.Object::op_Equality(v49, 0);\n\tv175 = v172 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_0067;\n\tv252 = HutongGames.PlayMaker.FsmObject::get_Value(this.animationClip);\n\tv253 = v252 == 0;\n\tif (v253) goto L_FFFFFFFF;\n\tv267 = *([v252 @ X0_v14 (UnityEngine.Object)]) != UnityEngine.AnimationClip;\n\tif (v267) goto L_FFFFFFFF;\n\tgoto L_004C;\nL_004C:\n\tgoto L_0052;\nL_0052:\n\tgoto L_005B;\n\tv277 = *([v273 @ X0_v15+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tgoto L_005B;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v273, v251, v87, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_005B:\n\tv140 = UnityEngine.Object::op_Equality(v108, 0);\n\tv249 = v140 == 0;\n\tif (v249) goto L_006E;\nL_0067:\n\treturn;\nL_006E:\n\tv141 = UnityEngine.GameObject::GetComponent(v49);\n\tv289 = HutongGames.PlayMaker.FsmInt::get_Value(this.firstFrame);\n\tv290 = v289 == 0;\n\tv291 = ~v290;\n\tif (v291) goto L_0084;\n\tv293 = HutongGames.PlayMaker.FsmInt::get_Value(this.lastFrame);\n\tv295 = v293 == 0;\n\tif (v295) goto L_00B1;\nL_0084:\n\tv142 = HutongGames.PlayMaker.FsmString::get_Value(this.animationName);\n\tv143 = HutongGames.PlayMaker.FsmInt::get_Value(this.firstFrame);\n\tv144 = HutongGames.PlayMaker.FsmInt::get_Value(this.lastFrame);\n\tv145 = HutongGames.PlayMaker.FsmBool::get_Value(this.addLoopFrame);\n\tUnityEngine.Animation::AddClip(v141, v108, v142, v143, v144, v145);\n\treturn;\nL_00B1:\n\tv146 = HutongGames.PlayMaker.FsmString::get_Value(this.animationName);\n\tUnityEngine.Animation::AddClip(v141, v108, v146);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 143 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoAddAnimationClip()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			Object value = animationClip.Value;
			Object obj = (((object)value == null) ? null : (((object)value.GetType() != typeof(AnimationClip)) ? null : value));
			if (!(obj == null))
			{
				Animation component = ownerDefaultTarget.GetComponent<Animation>();
				if (firstFrame.Value != 0 || lastFrame.Value != 0)
				{
					string value2 = animationName.Value;
					int value3 = firstFrame.Value;
					int value4 = lastFrame.Value;
					bool value5 = addLoopFrame.Value;
					component.AddClip((AnimationClip)obj, value2, value3, value4, value5);
				}
				else
				{
					string value6 = animationName.Value;
					component.AddClip((AnimationClip)obj, value6);
				}
			}
		}

		[Token(Token = "0x600068A")]
		[Address(RVA = "0xA12310", Offset = "0xA12310", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AddAnimationClip()
		{
		}
	}
}
