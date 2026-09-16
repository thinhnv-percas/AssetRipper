using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760520", Offset = "0x760520")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x760520", Offset = "0x760520")]
	[Token(Token = "0x20003B0")]
	public class GetAtan2FromVector3 : FsmStateAction
	{
		[Token(Token = "0x200049E")]
		public enum aTan2EnumAxis
		{
			[Token(Token = "0x40021DB")]
			x = 0,
			[Token(Token = "0x40021DC")]
			y = 1,
			[Token(Token = "0x40021DD")]
			z = 2
		}

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF128", Offset = "0x7CF128")]
		[Token(Token = "0x4001D53")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 vector3;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF174", Offset = "0x7CF174")]
		[Token(Token = "0x4001D54")]
		[FieldOffset(Offset = "0x58")]
		public aTan2EnumAxis xAxis;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF1C0", Offset = "0x7CF1C0")]
		[Token(Token = "0x4001D55")]
		[FieldOffset(Offset = "0x5C")]
		public aTan2EnumAxis yAxis;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7CF20C", Offset = "0x7CF20C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF20C", Offset = "0x7CF20C")]
		[Token(Token = "0x4001D56")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat angle;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF26C", Offset = "0x7CF26C")]
		[Token(Token = "0x4001D57")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool RadToDeg;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7CF2A4", Offset = "0x7CF2A4")]
		[Token(Token = "0x4001D58")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x6001266")]
		[Address(RVA = "0xB83000", Offset = "0xB83000", Length = "0x38")]
		public override void Reset()
		{
			//IL_0016: Expected I4, but got I8
			vector3 = null;
			xAxis = aTan2EnumAxis.x;
			FsmBool radToDeg = true;
			angle = null;
			RadToDeg = radToDeg;
			everyFrame = false;
		}

		[Token(Token = "0x6001267")]
		[Address(RVA = "0xB83038", Offset = "0xB83038", Length = "0x3C")]
		public override void OnEnter()
		{
			DoATan();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001268")]
		[Address(RVA = "0xB831CC", Offset = "0xB831CC", Length = "0x4")]
		public override void OnUpdate()
		{
			DoATan();
		}

		[Token(Token = "0x6001269")]
		[Address(RVA = "0xB83074", Offset = "0xB83074", Length = "0x158")]
		private void DoATan()
		{
			//IL_009a: Expected O, but got F4
			//IL_0183: Expected O, but got I4
			//IL_010c: Expected O, but got I4
			//IL_0079: Expected O, but got F4
			//IL_014c: Expected O, but got I4
			Vector3 value = vector3.Value;
			if (xAxis != aTan2EnumAxis.z)
			{
				bool flag = xAxis != aTan2EnumAxis.y;
				Vector3 vector = value;
				if (!flag)
				{
					vector = (Vector3)vector3.Value.y;
				}
			}
			else
			{
				Vector3 vector = (Vector3)vector3.Value.z;
			}
			Vector3 value2 = vector3.Value;
			float z = value2.z;
			float num;
			if (yAxis != aTan2EnumAxis.z)
			{
				bool flag2 = yAxis == aTan2EnumAxis.x;
				bool flag3 = !flag2;
				num = value2.y;
				object obj = 0;
				if (!flag3)
				{
					Vector3 value3 = vector3.Value;
					z = value3.z;
					num = value3.x;
					obj = 0;
				}
			}
			else
			{
				Vector3 value4 = vector3.Value;
				z = value4.z;
				num = value4.z;
				object obj = 0;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
			bool value5 = RadToDeg.Value;
			FsmFloat fsmFloat = angle;
			bool flag4 = !value5;
			float value6 = num * 57.29578f;
			if (flag4)
			{
				value6 = num;
			}
			fsmFloat.Value = value6;
		}

		[Token(Token = "0x600126A")]
		[Address(RVA = "0xB831D0", Offset = "0xB831D0", Length = "0x8")]
		public GetAtan2FromVector3()
		{
		}
	}
}
