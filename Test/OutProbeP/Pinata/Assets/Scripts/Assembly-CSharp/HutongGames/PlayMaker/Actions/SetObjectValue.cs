using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7629BC", Offset = "0x7629BC")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7629BC", Offset = "0x7629BC")]
	[Token(Token = "0x2000424")]
	public class SetObjectValue : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D93BC", Offset = "0x7D93BC")]
		[Token(Token = "0x4001F99")]
		[FieldOffset(Offset = "0x50")]
		public FsmObject objectVariable;

		[RequiredField]
		[Token(Token = "0x4001F9A")]
		[FieldOffset(Offset = "0x58")]
		public FsmObject objectValue;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9408", Offset = "0x7D9408")]
		[Token(Token = "0x4001F9B")]
		[FieldOffset(Offset = "0x60")]
		public bool everyFrame;

		[Token(Token = "0x6001493")]
		[Address(RVA = "0x997FFC", Offset = "0x997FFC", Length = "0xC")]
		public override void Reset()
		{
			everyFrame = false;
			objectVariable = null;
			objectValue = null;
		}

		[Token(Token = "0x6001494")]
		[Address(RVA = "0x998008", Offset = "0x998008", Length = "0x60")]
		public override void OnEnter()
		{
			FsmObject fsmObject = objectVariable;
			Object value = objectValue.Value;
			fsmObject.Value = value;
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001495")]
		[Address(RVA = "0x998068", Offset = "0x998068", Length = "0x44")]
		public override void OnUpdate()
		{
			FsmObject fsmObject = objectVariable;
			Object value = objectValue.Value;
			fsmObject.Value = value;
		}

		[Token(Token = "0x6001496")]
		[Address(RVA = "0x9980AC", Offset = "0x9980AC", Length = "0x8")]
		public SetObjectValue()
		{
		}
	}
}
