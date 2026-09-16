using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758BFC", Offset = "0x758BFC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758BFC", Offset = "0x758BFC")]
	[Token(Token = "0x2000268")]
	public class GameObjectHasChildren : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6628", Offset = "0x7B6628")]
		[Token(Token = "0x4001639")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6674", Offset = "0x7B6674")]
		[Token(Token = "0x400163A")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent trueEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B66AC", Offset = "0x7B66AC")]
		[Token(Token = "0x400163B")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent falseEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B66E4", Offset = "0x7B66E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B66E4", Offset = "0x7B66E4")]
		[Token(Token = "0x400163C")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6734", Offset = "0x7B6734")]
		[Token(Token = "0x400163D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000C03")]
		[Address(RVA = "0xB7CD7C", Offset = "0xB7CD7C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.falseEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			falseEvent = null;
		}

		[Token(Token = "0x6000C04")]
		[Address(RVA = "0xB7CD8C", Offset = "0xB7CD8C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectHasChildren::DoHasChildren(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoHasChildren();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C05")]
		[Address(RVA = "0xB7CEC4", Offset = "0xB7CEC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectHasChildren::DoHasChildren(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoHasChildren();
		}

		[Token(Token = "0x6000C06")]
		[Address(RVA = "0xB7CDC8", Offset = "0xB7CDC8", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED2DB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202297A]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002A;\n\tv114 = *([v56 @ X8_v7+E0]);\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_002A;\n\tv121 = v56;\n\tv118 = \"il2cpp_codegen_runtime_class_init\"(v121, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv102 = UnityEngine.Object::op_Equality(v43, 0);\n\tv123 = v102 == 0;\n\tif (v123) goto L_0038;\n\treturn;\nL_0038:\n\tv52 = UnityEngine.GameObject::get_transform(v43);\n\tv103 = UnityEngine.Transform::get_childCount(v52);\n\tv109 = this.storeResult;\n\tv88 = v103 < 0;\n\tv85 = v103 == 0;\n\tv79 = v103 ^ v103;\n\tv76 = v103 & v79;\n\tv73 = v76 < 0;\n\tv174 = v88 == v73;\n\tv67 = ~v85;\n\tv70 = v174 & v67;\n\tv109.value = v70;\n\tv154 = this + 0x58;\n\tv129 = this + 0x60;\n\tv145 = v103 < 0;\n\tv143 = v103 == 0;\n\tv139 = v103 ^ v103;\n\tv137 = v103 & v139;\n\tv135 = v137 < 0;\n\tv177 = v145 == v135;\n\tv131 = ~v143;\n\tv133 = v177 & v131;\n\tv126 = ~v133;\n\tif (v126) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v154 @ X9_v7]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoHasChildren()
		{
			//IL_0104: Expected O, but got I
			//IL_0110: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				int childCount = transform.childCount;
				FsmBool fsmBool = storeResult;
				bool flag = childCount < 0;
				bool flag2 = childCount == 0;
				int num = childCount ^ childCount;
				int num2 = childCount & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				bool value = flag4 && flag5;
				fsmBool.value = value;
				object fsmEvent = (long)(IntPtr)this + 88L;
				object obj = (long)(IntPtr)this + 96L;
				bool flag6 = childCount < 0;
				bool flag7 = childCount == 0;
				int num3 = childCount ^ childCount;
				int num4 = childCount & num3;
				bool flag8 = num4 < 0;
				bool flag9 = flag6 == flag8;
				bool flag10 = !flag7;
				if (!(flag9 && flag10))
				{
					fsmEvent = obj;
				}
				Fsm.Event((FsmEvent)fsmEvent);
			}
		}

		[Token(Token = "0x6000C07")]
		[Address(RVA = "0xB7CEC8", Offset = "0xB7CEC8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectHasChildren()
		{
		}
	}
}
