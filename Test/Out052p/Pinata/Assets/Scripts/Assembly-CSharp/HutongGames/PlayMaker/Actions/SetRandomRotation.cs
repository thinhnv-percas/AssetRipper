using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7600C0", Offset = "0x7600C0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7600C0", Offset = "0x7600C0")]
	[Token(Token = "0x20003A2")]
	public class SetRandomRotation : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4001CF6")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Token(Token = "0x4001CF7")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool x;

		[RequiredField]
		[Token(Token = "0x4001CF8")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool y;

		[RequiredField]
		[Token(Token = "0x4001CF9")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool z;

		[Token(Token = "0x6001218")]
		[Address(RVA = "0x998D00", Offset = "0x998D00", Length = "0x50")]
		public override void Reset()
		{
			gameObject = null;
			FsmBool fsmBool = true;
			x = fsmBool;
			FsmBool fsmBool2 = true;
			y = fsmBool2;
			FsmBool fsmBool3 = true;
			z = fsmBool3;
		}

		[Token(Token = "0x6001219")]
		[Address(RVA = "0x998D50", Offset = "0x998D50", Length = "0x28")]
		public override void OnEnter()
		{
			DoRandomRotation();
			Finish();
		}

		[Token(Token = "0x600121A")]
		[Address(RVA = "0x998D78", Offset = "0x998D78", Length = "0x19C")]
		private void DoRandomRotation()
		{
			//IL_00a8: Expected O, but got I4
			//IL_010a: Expected O, but got F4
			//IL_016c: Expected O, but got F4
			//IL_00d1: Expected O, but got I4
			//IL_00da: Expected O, but got I4
			//IL_01f5: Expected O, but got I4
			//IL_0133: Expected O, but got I4
			//IL_013c: Expected O, but got I4
			//IL_01be: Expected F4, but got O
			//IL_0195: Expected O, but got I4
			//IL_019e: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Transform transform = ownerDefaultTarget.transform;
				Vector3 localEulerAngles = transform.localEulerAngles;
				bool value = x.Value;
				bool flag = !value;
				object obj = localEulerAngles;
				object obj2 = 0;
				if (!flag)
				{
					int num = Random.Range(0, 360);
					obj = num;
					obj2 = 0;
				}
				bool value2 = y.Value;
				bool flag2 = !value2;
				object obj3 = localEulerAngles.y;
				if (!flag2)
				{
					int num2 = Random.Range(0, 360);
					obj3 = num2;
					obj2 = 0;
				}
				bool value3 = z.Value;
				bool flag3 = !value3;
				object obj4 = localEulerAngles.z;
				if (!flag3)
				{
					int num3 = Random.Range(0, 360);
					obj4 = num3;
					obj2 = 0;
				}
				Transform transform2 = ownerDefaultTarget.transform;
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 localEulerAngles2 = default(Vector3);
				localEulerAngles2.x = 0f;
				object obj6 = default(object);
				localEulerAngles2.y = (float)obj6;
				localEulerAngles2.z = 0f;
				transform2.localEulerAngles = localEulerAngles2;
			}
		}

		[Token(Token = "0x600121B")]
		[Address(RVA = "0x998F14", Offset = "0x998F14", Length = "0x8")]
		public SetRandomRotation()
		{
		}
	}
}
