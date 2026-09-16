using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75EC88", Offset = "0x75EC88")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75EC88", Offset = "0x75EC88")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75EC88", Offset = "0x75EC88")]
	[Token(Token = "0x2000376")]
	public class SetFsmBool : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB128", Offset = "0x7CB128")]
		[Token(Token = "0x4001BE1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB174", Offset = "0x7CB174")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB174", Offset = "0x7CB174")]
		[Token(Token = "0x4001BE2")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CB1C4", Offset = "0x7CB1C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB1C4", Offset = "0x7CB1C4")]
		[Token(Token = "0x4001BE3")]
		[FieldOffset(Offset = "0x60")]
		public FsmString variableName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB224", Offset = "0x7CB224")]
		[Token(Token = "0x4001BE4")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setValue;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CB270", Offset = "0x7CB270")]
		[Token(Token = "0x4001BE5")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001BE6")]
		[FieldOffset(Offset = "0x78")]
		private GameObject goLastFrame;

		[Token(Token = "0x4001BE7")]
		[FieldOffset(Offset = "0x80")]
		private string fsmNameLastFrame;

		[Token(Token = "0x4001BE8")]
		[FieldOffset(Offset = "0x88")]
		private PlayMakerFSM fsm;

		[Token(Token = "0x600113D")]
		[Address(RVA = "0x9910E0", Offset = "0x9910E0", Length = "0x60")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			setValue = null;
		}

		[Token(Token = "0x600113E")]
		[Address(RVA = "0x991140", Offset = "0x991140", Length = "0x3C")]
		public override void OnEnter()
		{
			DoSetFsmBool();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600113F")]
		[Address(RVA = "0x99117C", Offset = "0x99117C", Length = "0x23C")]
		private void DoSetFsmBool()
		{
			//IL_0137: Expected O, but got I
			//IL_015a: Expected O, but got I
			if (setValue == null)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			object obj;
			PlayMakerFSM playMakerFSM;
			if (!(ownerDefaultTarget != goLastFrame))
			{
				string value = fsmName.Value;
				if (!(value != fsmNameLastFrame))
				{
					obj = (long)(IntPtr)this + 136L;
					playMakerFSM = fsm;
					goto IL_0169;
				}
			}
			goLastFrame = ownerDefaultTarget;
			string value2 = fsmName.Value;
			fsmNameLastFrame = value2;
			string value3 = fsmName.Value;
			PlayMakerFSM gameObjectFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value3);
			obj = (long)(IntPtr)this + 136L;
			fsm = gameObjectFsm;
			playMakerFSM = gameObjectFsm;
			goto IL_0169;
			IL_0169:
			string value4;
			string text;
			if (playMakerFSM == null)
			{
				value4 = fsmName.Value;
				text = "Could not find FSM: ";
			}
			else
			{
				FsmVariables fsmVariables = ((PlayMakerFSM)obj).FsmVariables;
				string value5 = variableName.Value;
				FsmBool fsmBool = fsmVariables.FindFsmBool(value5);
				if (fsmBool != null)
				{
					bool value6 = setValue.Value;
					fsmBool.value = value6;
					return;
				}
				value4 = variableName.Value;
				text = "Could not find variable: ";
			}
			string text2 = text + value4;
			LogWarning(text2);
		}

		[Token(Token = "0x6001140")]
		[Address(RVA = "0x9913B8", Offset = "0x9913B8", Length = "0x4")]
		public override void OnUpdate()
		{
			DoSetFsmBool();
		}

		[Token(Token = "0x6001141")]
		[Address(RVA = "0x9913BC", Offset = "0x9913BC", Length = "0x8")]
		public SetFsmBool()
		{
		}
	}
}
