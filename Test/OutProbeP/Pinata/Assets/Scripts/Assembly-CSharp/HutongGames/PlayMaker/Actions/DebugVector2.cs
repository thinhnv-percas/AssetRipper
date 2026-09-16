using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762B08", Offset = "0x762B08")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x762B08", Offset = "0x762B08")]
	[Token(Token = "0x2000426")]
	public class DebugVector2 : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9440", Offset = "0x7D9440")]
		[Token(Token = "0x4001F9E")]
		[FieldOffset(Offset = "0x4C")]
		public LogLevel logLevel;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7D9478", Offset = "0x7D9478")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7D9478", Offset = "0x7D9478")]
		[Token(Token = "0x4001F9F")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2 vector2Variable;

		[Token(Token = "0x600149B")]
		[Address(RVA = "0xA85FA0", Offset = "0xA85FA0", Length = "0xC")]
		public override void Reset()
		{
			logLevel = default(LogLevel);
			vector2Variable = null;
		}

		[Token(Token = "0x600149C")]
		[Address(RVA = "0xA85FAC", Offset = "0xA85FAC", Length = "0xE0")]
		public override void OnEnter()
		{
			bool isNone = vector2Variable.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			string text = "None";
			if (!flag2)
			{
				FsmVector2 fsmVector = vector2Variable;
				Vector2 value = fsmVector.value;
				object obj = value;
				string text2 = fsmVector.Name + ": " + obj;
				text = text2;
			}
			ActionHelpers.DebugLog(Fsm, logLevel, text);
			Finish();
		}

		[Token(Token = "0x600149D")]
		[Address(RVA = "0xA8608C", Offset = "0xA8608C", Length = "0x8")]
		public DebugVector2()
		{
		}
	}
}
