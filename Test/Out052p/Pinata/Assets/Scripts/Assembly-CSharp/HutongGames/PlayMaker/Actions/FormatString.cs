using System;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75F7DC", Offset = "0x75F7DC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75F7DC", Offset = "0x75F7DC")]
	[Token(Token = "0x2000386")]
	public class FormatString : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC80C", Offset = "0x7CC80C")]
		[Token(Token = "0x4001C61")]
		[FieldOffset(Offset = "0x50")]
		public FsmString format;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC858", Offset = "0x7CC858")]
		[Token(Token = "0x4001C62")]
		[FieldOffset(Offset = "0x58")]
		public FsmVar[] variables;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7CC890", Offset = "0x7CC890")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC890", Offset = "0x7CC890")]
		[Token(Token = "0x4001C63")]
		[FieldOffset(Offset = "0x60")]
		public FsmString storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7CC8F0", Offset = "0x7CC8F0")]
		[Token(Token = "0x4001C64")]
		[FieldOffset(Offset = "0x68")]
		public bool everyFrame;

		[Token(Token = "0x4001C65")]
		[FieldOffset(Offset = "0x70")]
		private object[] objectArray;

		[Token(Token = "0x600118D")]
		[Address(RVA = "0xB76DD0", Offset = "0xB76DD0", Length = "0x10")]
		public override void Reset()
		{
			everyFrame = false;
			variables = null;
			storeResult = null;
			format = null;
		}

		[Token(Token = "0x600118E")]
		[Address(RVA = "0xB76DE0", Offset = "0xB76DE0", Length = "0x8C")]
		public override void OnEnter()
		{
			FsmVar[] array = variables;
			object[] array2 = new object[array.Length];
			objectArray = array2;
			DoFormatString();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x600118F")]
		[Address(RVA = "0xB7706C", Offset = "0xB7706C", Length = "0x4")]
		public override void OnUpdate()
		{
			DoFormatString();
		}

		[Token(Token = "0x6001190")]
		[Address(RVA = "0xB76E6C", Offset = "0xB76E6C", Length = "0x200")]
		private void DoFormatString()
		{
			//IL_006d: Expected I, but got O
			//IL_00a5: Expected I, but got O
			FsmVar[] array = variables;
			int num = 0;
			IntPtr intPtr = default(IntPtr);
			object obj3 = default(object);
			object obj4 = default(object);
			string text = default(string);
			NullReferenceException ex3 = default(NullReferenceException);
			while (true)
			{
				if (num < array.Length)
				{
					array[num].UpdateValue();
					FsmVar[] array2 = variables;
					object[] array3 = objectArray;
					object value = array2[num].GetValue();
					bool flag = value == null;
					intPtr = (IntPtr)null;
					if (!flag)
					{
						object obj = value as object;
						bool flag2 = obj == null;
						intPtr = (IntPtr)typeof(object);
						if (flag2)
						{
							break;
						}
					}
					array3[num] = value;
					array = variables;
					num++;
					if (variables == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				FsmString fsmString = storeResult;
				string value2 = format.Value;
				string value3 = string.Format(value2, objectArray);
				bool flag3 = storeResult == null;
				int num2 = (int)(long)intPtr;
				if (!flag3)
				{
					fsmString.Value = value3;
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				bool flag4 = intPtr != (IntPtr)1;
				NullReferenceException ex2 = ex;
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj2 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						object obj5 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v339 @ X8_v9+180] (should have been resolved before IL gen)");
						LogError(text);
						Finish();
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
					object obj6 = obj3;
					num2 = 32022528 + 2160;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					ex2 = ex3;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
				return;
			}
			while (true)
			{
				ArrayTypeMismatchException ex4 = new ArrayTypeMismatchException();
				TypeLoadException ex5 = new TypeLoadException();
				NullReferenceException ex6 = new NullReferenceException();
			}
		}

		[Token(Token = "0x6001191")]
		[Address(RVA = "0xB77070", Offset = "0xB77070", Length = "0x8")]
		public FormatString()
		{
		}
	}
}
