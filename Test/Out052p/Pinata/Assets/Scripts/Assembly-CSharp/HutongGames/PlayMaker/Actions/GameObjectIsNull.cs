using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758C9C", Offset = "0x758C9C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x758C9C", Offset = "0x758C9C")]
	[Token(Token = "0x200026A")]
	public class GameObjectIsNull : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B68D4", Offset = "0x7B68D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B68D4", Offset = "0x7B68D4")]
		[Token(Token = "0x4001643")]
		[FieldOffset(Offset = "0x50")]
		public FsmGameObject gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B6934", Offset = "0x7B6934")]
		[Token(Token = "0x4001644")]
		[FieldOffset(Offset = "0x58")]
		public FsmEvent isNull;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B696C", Offset = "0x7B696C")]
		[Token(Token = "0x4001645")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent isNotNull;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7B69A4", Offset = "0x7B69A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B69A4", Offset = "0x7B69A4")]
		[Token(Token = "0x4001646")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B69F4", Offset = "0x7B69F4")]
		[Token(Token = "0x4001647")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6000C0C")]
		[Address(RVA = "0xB7D04C", Offset = "0xB7D04C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.gameObject = 0;\n\tthis.isNotNull = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			gameObject = null;
			isNotNull = null;
		}

		[Token(Token = "0x6000C0D")]
		[Address(RVA = "0xB7D05C", Offset = "0xB7D05C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectIsNull::DoIsGameObjectNull(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoIsGameObjectNull();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000C0E")]
		[Address(RVA = "0xB7D160", Offset = "0xB7D160", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.GameObjectIsNull::DoIsGameObjectNull(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoIsGameObjectNull();
		}

		[Token(Token = "0x6000C0F")]
		[Address(RVA = "0xB7D098", Offset = "0xB7D098", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBD0D0]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202297C]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.gameObject);\n\tgoto L_0029;\n\tv67 = *([v47 @ X8_v6+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_0029;\n\tv75 = v47;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v75, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0029:\n\tv59 = UnityEngine.Object::op_Equality(v42, 0);\n\tv76 = this.storeResult;\n\tv77 = this.storeResult == 0;\n\tif (v77) goto L_0032;\n\tv76.value = v59;\nL_0032:\n\tv104 = this + 0x58;\n\tv99 = this + 0x60;\n\tv93 = v59 == 0;\n\tv84 = ~v93;\n\tv81 = ~v84;\n\tif (v81) goto L_FFFFFFFF;\n\tgoto L_0048;\nL_0048:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, *([v104 @ X9_v6]));\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoIsGameObjectNull()
		{
			//IL_006e: Expected O, but got I
			//IL_007a: Expected O, but got I
			GameObject value = gameObject.Value;
			bool flag = value == null;
			FsmBool fsmBool = storeResult;
			if (storeResult != null)
			{
				fsmBool.value = flag;
			}
			object fsmEvent = (long)(IntPtr)this + 88L;
			object obj = (long)(IntPtr)this + 96L;
			if (!flag)
			{
				fsmEvent = obj;
			}
			Fsm.Event((FsmEvent)fsmEvent);
		}

		[Token(Token = "0x6000C10")]
		[Address(RVA = "0xB7D164", Offset = "0xB7D164", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameObjectIsNull()
		{
		}
	}
}
