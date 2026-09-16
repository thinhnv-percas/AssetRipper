using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x763238", Offset = "0x763238")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x763238", Offset = "0x763238")]
	[Token(Token = "0x200043D")]
	public class SelectRandomVector3 : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7DAA20", Offset = "0x7DAA20")]
		[Token(Token = "0x4001FF5")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3[] vector3Array;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7DAA88", Offset = "0x7DAA88")]
		[Token(Token = "0x4001FF6")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat[] weights;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7DAAA0", Offset = "0x7DAAA0")]
		[Token(Token = "0x4001FF7")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 storeVector3;

		[Token(Token = "0x60014FF")]
		[Address(RVA = "0xB26B94", Offset = "0xB26B94", Length = "0x144")]
		public override void Reset()
		{
			//IL_00ce: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			FsmVector3[] array = new FsmVector3[3];
			vector3Array = array;
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
						storeVector3 = null;
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x6001500")]
		[Address(RVA = "0xB26CD8", Offset = "0xB26CD8", Length = "0x28")]
		public override void OnEnter()
		{
			DoSelectRandomColor();
			Finish();
		}

		[Token(Token = "0x6001501")]
		[Address(RVA = "0xB26D00", Offset = "0xB26D00", Length = "0x9C")]
		private void DoSelectRandomColor()
		{
			FsmVector3[] array = vector3Array;
			if (vector3Array == null || array.Length == 0 || storeVector3 == null)
			{
				return;
			}
			int randomWeightedIndex = ActionHelpers.GetRandomWeightedIndex(weights);
			if (randomWeightedIndex + 1 != 0)
			{
				FsmVector3[] array2 = vector3Array;
				if (randomWeightedIndex >= array2.Length)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmVector3 fsmVector = storeVector3;
				Vector3 vector = (fsmVector.value = array2[randomWeightedIndex].Value);
				fsmVector.value.y = vector.y;
				fsmVector.value.z = vector.z;
			}
		}

		[Token(Token = "0x6001502")]
		[Address(RVA = "0xB26D9C", Offset = "0xB26D9C", Length = "0x8")]
		public SelectRandomVector3()
		{
		}
	}
}
