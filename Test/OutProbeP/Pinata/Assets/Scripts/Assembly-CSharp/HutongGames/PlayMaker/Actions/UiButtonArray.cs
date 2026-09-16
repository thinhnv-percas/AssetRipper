using System;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7613D0", Offset = "0x7613D0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7613D0", Offset = "0x7613D0")]
	[Token(Token = "0x20003E0")]
	public class UiButtonArray : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2B2C", Offset = "0x7D2B2C")]
		[Token(Token = "0x4001E39")]
		[FieldOffset(Offset = "0x50")]
		public FsmEventTarget eventTarget;

		[AttributeAttribute(Type = typeof(CompoundArrayAttribute), RVA = "0x7D2B64", Offset = "0x7D2B64")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7D2B64", Offset = "0x7D2B64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2B64", Offset = "0x7D2B64")]
		[Token(Token = "0x4001E3A")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject[] gameObjects;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7D2C40", Offset = "0x7D2C40")]
		[Token(Token = "0x4001E3B")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent[] clickEvents;

		[SerializeField]
		[Token(Token = "0x4001E3C")]
		[FieldOffset(Offset = "0x68")]
		private Button[] buttons;

		[SerializeField]
		[Token(Token = "0x4001E3D")]
		[FieldOffset(Offset = "0x70")]
		private GameObject[] cachedGameObjects;

		[Token(Token = "0x4001E3E")]
		[FieldOffset(Offset = "0x78")]
		private UnityAction[] actions;

		[Token(Token = "0x4001E3F")]
		[FieldOffset(Offset = "0x80")]
		private int clickedButton;

		[Token(Token = "0x600133E")]
		[Address(RVA = "0x9A26C0", Offset = "0x9A26C0", Length = "0x70")]
		public override void Reset()
		{
			FsmGameObject[] array = new FsmGameObject[3];
			gameObjects = array;
			FsmEvent[] array2 = new FsmEvent[3];
			clickEvents = array2;
		}

		[Token(Token = "0x600133F")]
		[Address(RVA = "0x9A2730", Offset = "0x9A2730", Length = "0xAC")]
		public override void OnPreprocess()
		{
			FsmGameObject[] array = gameObjects;
			Button[] array2 = new Button[array.Length];
			FsmGameObject[] array3 = gameObjects;
			buttons = array2;
			GameObject[] array4 = new GameObject[array3.Length];
			FsmGameObject[] array5 = gameObjects;
			cachedGameObjects = array4;
			UnityAction[] array6 = new UnityAction[array5.Length];
			actions = array6;
			InitButtons();
		}

		[Token(Token = "0x6001340")]
		[Address(RVA = "0x9A27DC", Offset = "0x9A27DC", Length = "0x1F4")]
		private void InitButtons()
		{
			GameObject[] array = cachedGameObjects;
			FsmGameObject[] array2;
			if (cachedGameObjects != null)
			{
				array2 = gameObjects;
				if (array.Length == array2.Length)
				{
					goto IL_0049;
				}
			}
			OnPreprocess();
			array2 = gameObjects;
			goto IL_0049;
			IL_0049:
			int num = 0;
			do
			{
				if (num >= array2.Length)
				{
					return;
				}
				GameObject value = array2[num].Value;
				if (value != null)
				{
					GameObject[] array3 = cachedGameObjects;
					if (array3[num] != value)
					{
						Button[] array4 = buttons;
						Button component = value.GetComponent<Button>();
						if ((object)component != null)
						{
							object obj = component as Button;
							if (obj == null)
							{
								goto IL_01ba;
							}
						}
						array4[num] = component;
						GameObject[] array5 = cachedGameObjects;
						object obj2 = value as GameObject;
						if (obj2 == null)
						{
							goto IL_01ba;
						}
						array5[num] = value;
					}
				}
				array2 = gameObjects;
				num++;
				continue;
				IL_01ba:
				while (true)
				{
					ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
					TypeLoadException ex2 = new TypeLoadException();
				}
			}
			while (gameObjects != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001341")]
		[Address(RVA = "0x9A29D0", Offset = "0x9A29D0", Length = "0x1B8")]
		public override void OnEnter()
		{
			//IL_014a: Expected O, but got I
			InitButtons();
			Button[] array = buttons;
			int num = 0;
			do
			{
				if (num >= array.Length)
				{
					return;
				}
				Button[] array2 = buttons;
				UnityEngine.Object obj = array2[num];
				if (!(array2[num] == null))
				{
					int index = num;
					UnityAction[] array3 = actions;
					UnityAction unityAction = delegate
					{
						OnClick(index);
					};
					if (unityAction != null)
					{
						object obj2 = unityAction as UnityAction;
						if (obj2 == null)
						{
							while (true)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								TypeLoadException ex2 = new TypeLoadException();
							}
						}
					}
					array3[num] = unityAction;
					UnityAction[] array4 = actions;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ X20_v10 (UnityEngine.Object)+E8]");
					((UnityEvent)0).AddListener(array4[num]);
				}
				array = buttons;
				num++;
			}
			while (buttons != null);
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001342")]
		[Address(RVA = "0x9A2B90", Offset = "0x9A2B90", Length = "0x144")]
		public override void OnExit()
		{
			FsmGameObject[] array = gameObjects;
			int num = 0;
			while (true)
			{
				if (num >= array.Length)
				{
					return;
				}
				if (num < array.Length)
				{
					GameObject value = array[num].Value;
					if (!(value == null))
					{
						GameObject value2 = array[num].Value;
						Button component = value2.GetComponent<Button>();
						UnityAction[] array2 = actions;
						if (num >= array2.Length)
						{
							goto IL_0155;
						}
						component.onClick.RemoveListener(array2[num]);
					}
					array = gameObjects;
					num++;
					if (gameObjects == null)
					{
						break;
					}
					continue;
				}
				goto IL_0155;
				IL_0155:
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6001343")]
		[Address(RVA = "0x9A2CD4", Offset = "0x9A2CD4", Length = "0xA4")]
		public void OnClick(int index)
		{
			FsmGameObject[] array = gameObjects;
			bool flag = array.Length < index;
			bool flag2 = !flag;
			int num = array.Length - index;
			bool flag3 = num == 0;
			bool flag4 = !flag2;
			if (!(flag4 || flag3))
			{
				GameObject value = array[index].Value;
				FsmEvent[] array2 = clickEvents;
				bool flag5 = array2.Length < index;
				bool flag6 = !flag5;
				int num2 = array2.Length - index;
				bool flag7 = num2 == 0;
				bool flag8 = !flag6;
				if (!(flag8 || flag7))
				{
					Fsm.Event(value, eventTarget, array2[index]);
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6001344")]
		[Address(RVA = "0x9A2D78", Offset = "0x9A2D78", Length = "0x8")]
		public UiButtonArray()
		{
		}
	}
}
