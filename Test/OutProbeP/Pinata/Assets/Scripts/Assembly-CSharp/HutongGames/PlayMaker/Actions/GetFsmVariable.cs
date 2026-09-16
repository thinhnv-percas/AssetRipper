using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E40C", Offset = "0x75E40C")]
	[Attribute(Type = typeof(ActionTarget), RVA = "0x75E40C", Offset = "0x75E40C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75E40C", Offset = "0x75E40C")]
	[Token(Token = "0x2000363")]
	public class GetFsmVariable : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA824", Offset = "0x7CA824")]
		[Token(Token = "0x4001B8C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CA870", Offset = "0x7CA870")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA870", Offset = "0x7CA870")]
		[Token(Token = "0x4001B8D")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[HideTypeFilter]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CA8C0", Offset = "0x7CA8C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA8C0", Offset = "0x7CA8C0")]
		[Token(Token = "0x4001B8E")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar storeValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CA930", Offset = "0x7CA930")]
		[Token(Token = "0x4001B8F")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x4001B90")]
		[FieldOffset(Offset = "0x70")]
		private GameObject cachedGO;

		[Token(Token = "0x4001B91")]
		[FieldOffset(Offset = "0x78")]
		private string cachedFsmName;

		[Token(Token = "0x4001B92")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerFSM sourceFsm;

		[Token(Token = "0x4001B93")]
		[FieldOffset(Offset = "0x88")]
		private INamedVariable sourceVariable;

		[Token(Token = "0x4001B94")]
		[FieldOffset(Offset = "0x90")]
		private NamedVariable targetVariable;

		[Token(Token = "0x60010DC")]
		[Address(RVA = "0xA2E100", Offset = "0xA2E100", Length = "0x7C")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			FsmVar fsmVar = new FsmVar();
			storeValue = fsmVar;
		}

		[Token(Token = "0x60010DD")]
		[Address(RVA = "0xA2E17C", Offset = "0xA2E17C", Length = "0x44")]
		public override void OnEnter()
		{
			InitFsmVar();
			DoGetFsmVariable();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010DE")]
		[Address(RVA = "0xA2E430", Offset = "0xA2E430", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFsmVariable();
		}

		[Token(Token = "0x60010DF")]
		[Address(RVA = "0xA2E1C0", Offset = "0xA2E1C0", Length = "0x204")]
		private void InitFsmVar()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			if (!(ownerDefaultTarget != cachedGO))
			{
				string value = fsmName.Value;
				if (!(cachedFsmName != value))
				{
					return;
				}
			}
			string value2 = fsmName.Value;
			FsmVariables fsmVariables = (sourceFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value2)).FsmVariables;
			FsmVar fsmVar = storeValue;
			NamedVariable variable = fsmVariables.GetVariable(fsmVar.variableName);
			Fsm fsm = Fsm;
			sourceVariable = variable;
			FsmVar fsmVar2 = storeValue;
			VariableType variableType = (targetVariable = fsm.Variables.GetVariable(fsmVar2.variableName)).VariableType;
			storeValue.Type = variableType;
			FsmVar fsmVar3 = storeValue;
			if (!string.IsNullOrEmpty(fsmVar3.variableName) && sourceVariable == null)
			{
				FsmVar fsmVar4 = storeValue;
				string text = "Missing Variable: " + fsmVar4.variableName;
				LogWarning(text);
			}
			cachedGO = ownerDefaultTarget;
			string value3 = fsmName.Value;
			cachedFsmName = value3;
		}

		[Token(Token = "0x60010E0")]
		[Address(RVA = "0xA2E3C4", Offset = "0xA2E3C4", Length = "0x6C")]
		private void DoGetFsmVariable()
		{
			if (!storeValue.IsNone)
			{
				InitFsmVar();
				storeValue.GetValueFrom(sourceVariable);
				storeValue.ApplyValueTo(targetVariable);
			}
		}

		[Token(Token = "0x60010E1")]
		[Address(RVA = "0xA2E434", Offset = "0xA2E434", Length = "0x8")]
		public GetFsmVariable()
		{
		}
	}
}
