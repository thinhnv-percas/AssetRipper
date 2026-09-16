using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x762BF8", Offset = "0x762BF8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x762BF8", Offset = "0x762BF8")]
	[Token(Token = "0x2000429")]
	public class SelectRandomVector2 : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D96D0", Offset = "0x7D96D0")]
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7D96D0", Offset = "0x7D96D0")]
		[Token(Token = "0x4001FA7")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector2[] vector2Array;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7D9760", Offset = "0x7D9760")]
		[Token(Token = "0x4001FA8")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] weights;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7D9778", Offset = "0x7D9778")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D9778", Offset = "0x7D9778")]
		[Token(Token = "0x4001FA9")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 storeVector2;

		[Token(Token = "0x60014A8")]
		[Address(RVA = "0xB26990", Offset = "0xB26990", Length = "0x144")]
		public override void Reset()
		{
			//IL_00ce: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			FsmVector2[] array = new FsmVector2[3];
			vector2Array = array;
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
						storeVector2 = null;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60014A9")]
		[Address(RVA = "0xB26AD4", Offset = "0xB26AD4", Length = "0x28")]
		public override void OnEnter()
		{
			DoSelectRandomColor();
			Finish();
		}

		[Token(Token = "0x60014AA")]
		[Address(RVA = "0xB26AFC", Offset = "0xB26AFC", Length = "0x90")]
		private void DoSelectRandomColor()
		{
			FsmVector2[] array = vector2Array;
			if (vector2Array == null || array.Length == 0 || storeVector2 == null)
			{
				return;
			}
			int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
			if (randomWeightedIndex + 1 != 0)
			{
				FsmVector2[] array2 = vector2Array;
				if (randomWeightedIndex >= array2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmVector2 fsmVector = array2[randomWeightedIndex];
				FsmVector2 fsmVector2 = storeVector2;
				fsmVector2.value = fsmVector.value;
				fsmVector2.value.y = fsmVector.value.y;
			}
		}

		[Token(Token = "0x60014AB")]
		[Address(RVA = "0xB26B8C", Offset = "0xB26B8C", Length = "0x8")]
		public SelectRandomVector2()
		{
		}
	}
}
