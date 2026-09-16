using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x760840", Offset = "0x760840")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x760840", Offset = "0x760840")]
	[Token(Token = "0x20003BB")]
	public class UiEventSystemCurrentRayCastAll : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFCE0", Offset = "0x7CFCE0")]
		[Token(Token = "0x4001D89")]
		[FieldOffset(Offset = "0x50")]
		public FsmVector3 screenPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFD2C", Offset = "0x7CFD2C")]
		[Token(Token = "0x4001D8A")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 orScreenPosition2d;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFD64", Offset = "0x7CFD64")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CFD64", Offset = "0x7CFD64")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7CFD64", Offset = "0x7CFD64")]
		[Token(Token = "0x4001D8B")]
		[FieldOffset(Offset = "0x60")]
		public FsmArray gameObjectList;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFDE8", Offset = "0x7CFDE8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CFDE8", Offset = "0x7CFDE8")]
		[Token(Token = "0x4001D8C")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt hitCount;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CFE38", Offset = "0x7CFE38")]
		[Token(Token = "0x4001D8D")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001D8E")]
		[FieldOffset(Offset = "0x78")]
		private PointerEventData pointer;

		[Token(Token = "0x4001D8F")]
		[FieldOffset(Offset = "0x80")]
		private List<RaycastResult> raycastResults;

		[Token(Token = "0x600129D")]
		[Address(RVA = "0x9A4850", Offset = "0x9A4850", Length = "0x80")]
		public override void Reset()
		{
			screenPosition = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			everyFrame = false;
			gameObjectList = null;
			hitCount = null;
			orScreenPosition2d = fsmVector;
		}

		[Token(Token = "0x600129E")]
		[Address(RVA = "0x9A48D0", Offset = "0x9A48D0", Length = "0x3C")]
		public override void OnEnter()
		{
			ExecuteRayCastAll();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600129F")]
		[Address(RVA = "0x9A4BA8", Offset = "0x9A4BA8", Length = "0x4")]
		public override void OnUpdate()
		{
			ExecuteRayCastAll();
		}

		[Token(Token = "0x60012A0")]
		[Address(RVA = "0x9A490C", Offset = "0x9A490C", Length = "0x29C")]
		private void ExecuteRayCastAll()
		{
			//IL_015c: Expected O, but got I4
			//IL_01a9: Expected O, but got I4
			//IL_0487: Expected O, but got I4
			//IL_04b2: Expected O, but got I4
			//IL_02aa: Expected O, but got I4
			//IL_02dc: Expected O, but got I4
			//IL_0307: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			EventSystem current = EventSystem.current;
			PointerEventData pointerEventData = new PointerEventData(current);
			pointer = pointerEventData;
			bool isNone = orScreenPosition2d.IsNone;
			PointerEventData pointerEventData2 = pointer;
			object obj2 = default(object);
			float num2 = default(float);
			float num = default(float);
			Vector3 vector = default(Vector3);
			object obj3 = default(object);
			float num5 = default(float);
			float num6 = default(float);
			Vector3 vector4 = default(Vector3);
			object obj;
			float num3;
			float num4;
			Vector3 vector3;
			List<RaycastResult> list;
			if (isNone)
			{
				vector = screenPosition.Value;
				Vector3 value = screenPosition.Value;
				num = value.y;
				num2 = value.z;
				Vector2 vector2 = default(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				if (pointer != null)
				{
					pointerEventData2.position = default(Vector2);
					float y = default(float);
					pointerEventData2.position.y = y;
					vector2 = default(Vector2);
					goto IL_0202;
				}
			}
			else
			{
				FsmVector2 fsmVector = orScreenPosition2d;
				bool flag = orScreenPosition2d == null;
				obj = obj2;
				num3 = num2;
				num4 = num;
				vector3 = vector;
				list = null;
				obj3 = 0;
				if (!flag)
				{
					bool flag2 = pointer == null;
					obj = obj2;
					num3 = num5;
					num4 = num6;
					vector3 = vector4;
					list = null;
					obj3 = 0;
					if (!flag2)
					{
						pointerEventData2.position = fsmVector.value;
						pointerEventData2.position.y = fsmVector.value.y;
						num2 = num5;
						num = num6;
						vector = vector4;
						goto IL_0202;
					}
				}
			}
			goto IL_03c1;
			IL_0202:
			EventSystem current2 = EventSystem.current;
			current2.RaycastAll(pointer, raycastResults);
			if (!hitCount.IsNone)
			{
				List<RaycastResult> list2 = raycastResults;
				bool flag3 = raycastResults == null;
				obj = obj2;
				num3 = num5;
				num4 = num6;
				vector3 = vector4;
				list = null;
				obj3 = 0;
				if (!flag3)
				{
					FsmInt fsmInt = hitCount;
					bool flag4 = hitCount == null;
					obj = 0;
					num3 = num2;
					num4 = num;
					vector3 = vector;
					list = raycastResults;
					obj3 = 0;
					if (!flag4)
					{
						fsmInt.Value = list2.Count;
						goto IL_0463;
					}
				}
				goto IL_03c1;
			}
			goto IL_0463;
			IL_03c1:
			NullReferenceException ex = new NullReferenceException();
			List<RaycastResult>.Enumerator enumerator = default(List<RaycastResult>.Enumerator);
			if ((IntPtr)obj3 == (IntPtr)1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj4 = default(object);
				if (obj4 == null)
				{
					return;
				}
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
			IL_0463:
			List<RaycastResult> list3 = raycastResults;
			bool flag5 = raycastResults == null;
			obj = 0;
			num3 = num2;
			num4 = num;
			vector3 = vector;
			list = raycastResults;
			obj3 = 0;
			if (!flag5)
			{
				gameObjectList.Resize(list3.Count);
				List<RaycastResult>.Enumerator enumerator2 = raycastResults.GetEnumerator();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
				object value2 = default(object);
				while (enumerator.MoveNext())
				{
					if (!gameObjectList.IsNone)
					{
						gameObjectList.Set(0, value2);
					}
				}
				enumerator.Dispose();
				return;
			}
			goto IL_03c1;
		}

		[Token(Token = "0x60012A1")]
		[Address(RVA = "0x9A4BAC", Offset = "0x9A4BAC", Length = "0x70")]
		public UiEventSystemCurrentRayCastAll()
		{
			List<RaycastResult> list = new List<RaycastResult>();
			raycastResults = list;
		}
	}
}
