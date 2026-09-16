using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F96C", Offset = "0x75F96C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F96C", Offset = "0x75F96C")]
	[Token(Token = "0x200038B")]
	public class SelectRandomString : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7CCC08", Offset = "0x7CCC08")]
		[Token(Token = "0x4001C76")]
		[FieldOffset(Offset = "0x50")]
		public FsmString[] strings;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7CCC70", Offset = "0x7CCC70")]
		[Token(Token = "0x4001C77")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] weights;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CCC88", Offset = "0x7CCC88")]
		[Token(Token = "0x4001C78")]
		[FieldOffset(Offset = "0x60")]
		public FsmString storeString;

		[Token(Token = "0x60011A6")]
		[Address(RVA = "0xB26784", Offset = "0xB26784", Length = "0x144")]
		public override void Reset()
		{
			//IL_00ce: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			FsmString[] array = new FsmString[3];
			strings = array;
			FsmFloat[] array2 = new FsmFloat[3];
			FsmFloat fsmFloat = 1f;
			if (fsmFloat != null)
			{
				object obj = fsmFloat as FsmFloat;
			}
			if (array2.Length != 0)
			{
				array2[0] = fsmFloat;
				FsmFloat fsmFloat2 = 1f;
				if (fsmFloat2 != null)
				{
					object obj2 = fsmFloat2 as FsmFloat;
				}
				bool flag = array2.Length < 1;
				bool flag2 = !flag;
				object obj3 = array2.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array2[1] = fsmFloat2;
					FsmFloat fsmFloat3 = 1f;
					if (fsmFloat3 != null)
					{
						object obj4 = fsmFloat3 as FsmFloat;
					}
					bool flag5 = array2.Length < 2;
					bool flag6 = !flag5;
					object obj5 = array2.Length - 2;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array2[2] = fsmFloat3;
						weights = array2;
						storeString = null;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60011A7")]
		[Address(RVA = "0xB268C8", Offset = "0xB268C8", Length = "0x28")]
		public override void OnEnter()
		{
			DoSelectRandomString();
			Finish();
		}

		[Token(Token = "0x60011A8")]
		[Address(RVA = "0xB268F0", Offset = "0xB268F0", Length = "0x98")]
		private void DoSelectRandomString()
		{
			FsmString[] array = strings;
			if (strings == null || array.Length == 0 || storeString == null)
			{
				return;
			}
			int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
			if (randomWeightedIndex + 1 != 0)
			{
				FsmString[] array2 = strings;
				if (randomWeightedIndex >= array2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmString fsmString = storeString;
				string value = array2[randomWeightedIndex].Value;
				fsmString.Value = value;
			}
		}

		[Token(Token = "0x60011A9")]
		[Address(RVA = "0xB26988", Offset = "0xB26988", Length = "0x8")]
		public SelectRandomString()
		{
		}
	}
}
