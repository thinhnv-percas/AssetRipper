using System;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760340", Offset = "0x760340")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760340", Offset = "0x760340")]
	[Token(Token = "0x20003AA")]
	public class Translate : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE91C", Offset = "0x7CE91C")]
		[Token(Token = "0x4001D34")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CE968", Offset = "0x7CE968")]
		[Readonly]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE968", Offset = "0x7CE968")]
		[Token(Token = "0x4001D35")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 vector;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CE9C8", Offset = "0x7CE9C8")]
		[Token(Token = "0x4001D36")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat x;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEA00", Offset = "0x7CEA00")]
		[Token(Token = "0x4001D37")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat y;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEA38", Offset = "0x7CEA38")]
		[Token(Token = "0x4001D38")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat z;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEA70", Offset = "0x7CEA70")]
		[Token(Token = "0x4001D39")]
		[FieldOffset(Offset = "0x78")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEAA8", Offset = "0x7CEAA8")]
		[Token(Token = "0x4001D3A")]
		[FieldOffset(Offset = "0x7C")]
		public bool perSecond;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEAE0", Offset = "0x7CEAE0")]
		[Token(Token = "0x4001D3B")]
		[FieldOffset(Offset = "0x7D")]
		public bool everyFrame;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEB18", Offset = "0x7CEB18")]
		[Token(Token = "0x4001D3C")]
		[FieldOffset(Offset = "0x7E")]
		public bool lateUpdate;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CEB50", Offset = "0x7CEB50")]
		[Token(Token = "0x4001D3D")]
		[FieldOffset(Offset = "0x7F")]
		public bool fixedUpdate;

		[Token(Token = "0x6001245")]
		[Address(RVA = "0x9A0FEC", Offset = "0x9A0FEC", Length = "0xCC")]
		public override void Reset()
		{
			//IL_007a: Expected I4, but got I8
			gameObject = null;
			vector = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			x = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			y = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			z = fsmFloat3;
			space = Space.Self;
		}

		[Token(Token = "0x6001246")]
		[Address(RVA = "0x9A10B8", Offset = "0x9A10B8", Length = "0x60")]
		public override void OnPreprocess()
		{
			if (fixedUpdate)
			{
				Fsm.HandleFixedUpdate = true;
			}
			if (lateUpdate)
			{
				Fsm.HandleLateUpdate = true;
			}
		}

		[Token(Token = "0x6001247")]
		[Address(RVA = "0x9A1118", Offset = "0x9A1118", Length = "0x50")]
		public override void OnEnter()
		{
			if (!everyFrame && !lateUpdate && !fixedUpdate)
			{
				DoTranslate();
				Finish();
			}
		}

		[Token(Token = "0x6001248")]
		[Address(RVA = "0x9A13C8", Offset = "0x9A13C8", Length = "0x18")]
		public override void OnUpdate()
		{
			if (!lateUpdate && !fixedUpdate)
			{
				DoTranslate();
			}
		}

		[Token(Token = "0x6001249")]
		[Address(RVA = "0x9A13E0", Offset = "0x9A13E0", Length = "0x48")]
		public override void OnLateUpdate()
		{
			if (lateUpdate)
			{
				DoTranslate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600124A")]
		[Address(RVA = "0x9A1428", Offset = "0x9A1428", Length = "0x48")]
		public override void OnFixedUpdate()
		{
			if (fixedUpdate)
			{
				DoTranslate();
			}
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600124B")]
		[Address(RVA = "0x9A1168", Offset = "0x9A1168", Length = "0x260")]
		private void DoTranslate()
		{
			//IL_011d: Expected O, but got I
			//IL_008d: Expected O, but got I
			//IL_018e: Expected O, but got F4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				object obj;
				float num;
				Vector3 vector2;
				float num3;
				if (this.vector.IsNone)
				{
					obj = (long)(IntPtr)this + 96L;
					float value = x.Value;
					float value2 = y.Value;
					float value3 = z.Value;
					Vector3 vector = default(Vector3);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					float num2 = default(float);
					num = num2;
					vector2 = default(Vector3);
					num3 = 0f;
				}
				else
				{
					Vector3 value4 = this.vector.Value;
					obj = (long)(IntPtr)this + 96L;
					num = value4.y;
					vector2 = value4;
					num3 = value4.z;
				}
				if (!((NamedVariable)obj).IsNone)
				{
					float value5 = ((FsmFloat)obj).Value;
					vector2 = (Vector3)value5;
				}
				if (!y.IsNone)
				{
					float value6 = y.Value;
					num = value6;
				}
				if (!z.IsNone)
				{
					float value7 = z.Value;
					num3 = value7;
				}
				Transform transform = ownerDefaultTarget.transform;
				Vector3 vector4;
				float num4;
				float num5;
				Space relativeTo;
				if (perSecond)
				{
					float deltaTime = Time.deltaTime;
					Vector3 vector3 = default(Vector3);
					vector3.x = vector2.x;
					vector3.y = num;
					vector3.z = num3;
					vector4 = vector3 * deltaTime;
					num4 = vector4.y;
					num5 = vector4.z;
					relativeTo = space;
				}
				else
				{
					relativeTo = space;
					num4 = num;
					num5 = num3;
					vector4 = vector2;
				}
				Vector3 translation = default(Vector3);
				translation.x = vector4.x;
				translation.y = num4;
				translation.z = num5;
				transform.Translate(translation, relativeTo);
			}
		}

		[Token(Token = "0x600124C")]
		[Address(RVA = "0x9A1470", Offset = "0x9A1470", Length = "0x8")]
		public Translate()
		{
		}
	}
}
