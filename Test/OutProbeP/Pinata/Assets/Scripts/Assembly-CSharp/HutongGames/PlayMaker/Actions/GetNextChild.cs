using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7562CC", Offset = "0x7562CC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7562CC", Offset = "0x7562CC")]
	[Token(Token = "0x20001EA")]
	public class GetNextChild : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1148", Offset = "0x7B1148")]
		[Token(Token = "0x4001457")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1194", Offset = "0x7B1194")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1194", Offset = "0x7B1194")]
		[Token(Token = "0x4001458")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject storeNextChild;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B11F4", Offset = "0x7B11F4")]
		[Token(Token = "0x4001459")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent loopEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B122C", Offset = "0x7B122C")]
		[Token(Token = "0x400145A")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent finishedEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B1264", Offset = "0x7B1264")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B1264", Offset = "0x7B1264")]
		[Token(Token = "0x400145B")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool resetFlag;

		[Token(Token = "0x400145C")]
		[FieldOffset(Offset = "0x78")]
		private GameObject go;

		[Token(Token = "0x400145D")]
		[FieldOffset(Offset = "0x80")]
		private int nextChildIndex;

		[Token(Token = "0x6000A1A")]
		[Address(RVA = "0xA3040C", Offset = "0xA3040C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.resetFlag = 0;\n\tthis.gameObject = 0;\n\tthis.loopEvent = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			resetFlag = null;
			gameObject = null;
			loopEvent = null;
		}

		[Token(Token = "0x6000A1B")]
		[Address(RVA = "0xA3041C", Offset = "0xA3041C", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = HutongGames.PlayMaker.FsmBool::get_Value(this.resetFlag);\n\tv39 = v13 == 0;\n\tif (v39) goto L_0018;\n\tv41 = this.resetFlag;\n\tthis.nextChildIndex = 0;\n\tv41.value = 0;\nL_0018:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tHutongGames.PlayMaker.Actions.GetNextChild::DoGetNextChild(this, v51);\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (resetFlag.Value)
			{
				FsmBool fsmBool = resetFlag;
				nextChildIndex = 0;
				fsmBool.value = false;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			DoGetNextChild(ownerDefaultTarget);
			Finish();
		}

		[Token(Token = "0x6000A1C")]
		[Address(RVA = "0xA30490", Offset = "0xA30490", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1ED4BC8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, parent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021DED]) = v43;\nL_001C:\n\tgoto L_0025;\n\tv50 = *([v46 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, parent, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0025:\n\tv60 = UnityEngine.Object::op_Equality(parent, 0);\n\tv62 = v60 == 0;\n\tif (v62) goto L_0036;\nL_0030:\n\treturn;\nL_0036:\n\tgoto L_003F;\n\tv174 = *([v112 @ X0_v6+E0]);\n\tv175 = v174 == 0;\n\tv176 = ~v175;\n\tif (v176) goto L_003F;\n\tv178 = \"il2cpp_codegen_runtime_class_init\"(v112, v58, v59, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003F:\n\tv184 = UnityEngine.Object::op_Inequality(this.go, parent);\n\tv186 = v184 == 0;\n\tif (v186) goto L_004E;\n\tv91 = this + 0x80;\n\tthis.nextChildIndex = 0;\n\tthis.go = parent;\n\tv191 = parent == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_0054;\n\tgoto L_00A9;\nL_004E:\n\tv91 = this + 0x80;\n\tv200 = this.nextChildIndex;\n\tv198 = this.go;\nL_0054:\n\tv202 = UnityEngine.GameObject::get_transform(v198);\n\tv250 = UnityEngine.Transform::get_childCount(v202);\n\tv203 = v200 >= v250;\n\tif (v203) goto L_0099;\n\tv232 = UnityEngine.GameObject::get_transform(parent);\n\tv233 = UnityEngine.Transform::GetChild(v232, *([v91 @ X22_v2]));\n\tv258 = UnityEngine.Component::get_gameObject(v233);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeNextChild, v258);\n\tv235 = UnityEngine.GameObject::get_transform(this.go);\n\tv97 = UnityEngine.Transform::get_childCount(v235);\n\tv65 = this.nextChildIndex >= v97;\n\tif (v65) goto L_0099;\n\tv153 = this.loopEvent;\n\tv103 = this.nextChildIndex + 1;\n\tthis.nextChildIndex = v103;\n\tv99 = this.loopEvent == 0;\n\tif (v99) goto L_0030;\n\tv156 = this.fsm;\n\tv268 = this.fsm == 0;\n\tv244 = ~v268;\n\tif (v244) goto L_00A6;\n\tgoto L_00A9;\nL_0099:\n\tv156 = this.fsm;\n\tthis.nextChildIndex = 0;\n\tv153 = this.finishedEvent;\nL_00A6:\n\tHutongGames.PlayMaker.Fsm::Event(v156, v153);\n\treturn;\nL_00A9:\n\tthrow System.NullReferenceException;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoGetNextChild(GameObject parent)
		{
			//IL_00d1: Expected O, but got I
			//IL_0072: Expected O, but got I
			//IL_0147: Expected I4, but got O
			if (parent == null)
			{
				return;
			}
			object obj;
			GameObject gameObject;
			int num;
			if (go != parent)
			{
				obj = (long)(IntPtr)this + 128L;
				nextChildIndex = 0;
				go = parent;
				bool flag = (object)parent == null;
				bool flag2 = !flag;
				gameObject = parent;
				num = 0;
				if (!flag2)
				{
					goto IL_0262;
				}
			}
			else
			{
				obj = (long)(IntPtr)this + 128L;
				num = nextChildIndex;
				gameObject = go;
			}
			Transform transform = gameObject.transform;
			int childCount = transform.childCount;
			FsmEvent fsmEvent;
			Fsm fsm;
			if (num < childCount)
			{
				Transform transform2 = parent.transform;
				Transform child = transform2.GetChild((int)obj);
				GameObject value = child.gameObject;
				storeNextChild.Value = value;
				Transform transform3 = go.transform;
				int childCount2 = transform3.childCount;
				if (nextChildIndex < childCount2)
				{
					fsmEvent = loopEvent;
					int num2 = nextChildIndex + 1;
					nextChildIndex = num2;
					if (loopEvent == null)
					{
						return;
					}
					fsm = Fsm;
					if (Fsm == null)
					{
						goto IL_0262;
					}
					goto IL_0268;
				}
			}
			fsm = Fsm;
			nextChildIndex = 0;
			fsmEvent = finishedEvent;
			goto IL_0268;
			IL_0262:
			throw new NullReferenceException();
			IL_0268:
			fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6000A1D")]
		[Address(RVA = "0xA30640", Offset = "0xA30640", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetNextChild()
		{
		}
	}
}
