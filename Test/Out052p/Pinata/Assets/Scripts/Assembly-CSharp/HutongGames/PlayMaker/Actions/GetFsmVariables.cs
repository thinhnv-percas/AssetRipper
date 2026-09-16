using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75E4C8", Offset = "0x75E4C8")]
	[AttributeAttribute(Type = typeof(ActionTarget), RVA = "0x75E4C8", Offset = "0x75E4C8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75E4C8", Offset = "0x75E4C8")]
	[Token(Token = "0x2000364")]
	public class GetFsmVariables : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA968", Offset = "0x7CA968")]
		[Token(Token = "0x4001B95")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CA9B4", Offset = "0x7CA9B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CA9B4", Offset = "0x7CA9B4")]
		[Token(Token = "0x4001B96")]
		[FieldOffset(Offset = "0x58")]
		public FsmString fsmName;

		[RequiredField]
		[HideTypeFilter]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CAA04", Offset = "0x7CAA04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAA04", Offset = "0x7CAA04")]
		[Token(Token = "0x4001B97")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar[] getVariables;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CAA74", Offset = "0x7CAA74")]
		[Token(Token = "0x4001B98")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x4001B99")]
		[FieldOffset(Offset = "0x70")]
		private GameObject cachedGO;

		[Token(Token = "0x4001B9A")]
		[FieldOffset(Offset = "0x78")]
		private string cachedFsmName;

		[Token(Token = "0x4001B9B")]
		[FieldOffset(Offset = "0x80")]
		private PlayMakerFSM sourceFsm;

		[Token(Token = "0x4001B9C")]
		[FieldOffset(Offset = "0x88")]
		private INamedVariable[] sourceVariables;

		[Token(Token = "0x4001B9D")]
		[FieldOffset(Offset = "0x90")]
		private NamedVariable[] targetVariables;

		[Token(Token = "0x60010E2")]
		[Address(RVA = "0xA2E43C", Offset = "0xA2E43C", Length = "0x5C")]
		public override void Reset()
		{
			gameObject = null;
			FsmString fsmString = "";
			fsmName = fsmString;
			getVariables = null;
		}

		[Token(Token = "0x60010E3")]
		[Address(RVA = "0xA2E498", Offset = "0xA2E498", Length = "0x340")]
		private void InitFsmVars()
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
			FsmVar[] array = getVariables;
			INamedVariable[] array2 = new INamedVariable[array.Length];
			FsmVar[] array3 = getVariables;
			sourceVariables = array2;
			NamedVariable[] array4 = new NamedVariable[array3.Length];
			FsmVar[] array5 = getVariables;
			targetVariables = array4;
			int num = 0;
			while (true)
			{
				if (num >= array5.Length)
				{
					return;
				}
				FsmVar fsmVar = array5[num];
				string value2 = fsmName.Value;
				PlayMakerFSM playMakerFSM = (sourceFsm = ActionHelpers.GetGameObjectFsm(ownerDefaultTarget, value2));
				INamedVariable[] array6 = sourceVariables;
				FsmVariables fsmVariables = playMakerFSM.FsmVariables;
				NamedVariable variable = fsmVariables.GetVariable(fsmVar.variableName);
				if (variable != null)
				{
					object obj = variable as INamedVariable;
					if (obj == null)
					{
						break;
					}
				}
				array6[num] = variable;
				Fsm fsm = Fsm;
				NamedVariable[] array7 = targetVariables;
				NamedVariable variable2 = fsm.Variables.GetVariable(fsmVar.variableName);
				if (variable2 != null)
				{
					object obj2 = variable2 as NamedVariable;
					if (obj2 == null)
					{
						break;
					}
				}
				array7[num] = variable2;
				FsmVar[] array8 = getVariables;
				NamedVariable[] array9 = targetVariables;
				VariableType variableType = array9[num].VariableType;
				array8[num].Type = variableType;
				if (!string.IsNullOrEmpty(fsmVar.variableName))
				{
					INamedVariable[] array10 = sourceVariables;
					if (array10[num] == null)
					{
						string text = "Missing Variable: " + fsmVar.variableName;
						LogWarning(text);
					}
				}
				cachedGO = ownerDefaultTarget;
				string value3 = fsmName.Value;
				array5 = getVariables;
				num++;
				cachedFsmName = value3;
				if (getVariables == null)
				{
					throw new NullReferenceException();
				}
			}
			while (true)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				TypeLoadException ex2 = new TypeLoadException();
			}
		}

		[Token(Token = "0x60010E4")]
		[Address(RVA = "0xA2E7D8", Offset = "0xA2E7D8", Length = "0x44")]
		public override void OnEnter()
		{
			InitFsmVars();
			DoGetFsmVariables();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x60010E5")]
		[Address(RVA = "0xA2E900", Offset = "0xA2E900", Length = "0x4")]
		public override void OnUpdate()
		{
			DoGetFsmVariables();
		}

		[Token(Token = "0x60010E6")]
		[Address(RVA = "0xA2E81C", Offset = "0xA2E81C", Length = "0xE4")]
		private void DoGetFsmVariables()
		{
			InitFsmVars();
			FsmVar[] array = getVariables;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				if (num < array.Length)
				{
					INamedVariable[] array2 = sourceVariables;
					if (num < array2.Length)
					{
						array[num].GetValueFrom(array2[num]);
						FsmVar[] array3 = getVariables;
						if (num < array3.Length)
						{
							NamedVariable[] array4 = targetVariables;
							if (num < array4.Length)
							{
								int num2 = num + 1;
								array3[num].ApplyValueTo(array4[num]);
								array = getVariables;
								bool flag = getVariables == null;
								bool flag2 = !flag;
								num = num2;
								if (!flag2)
								{
									break;
								}
								continue;
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x60010E7")]
		[Address(RVA = "0xA2E904", Offset = "0xA2E904", Length = "0x8")]
		public GetFsmVariables()
		{
		}
	}
}
