using System;
using System.Collections.Generic;
using System.Text;

namespace SpirV
{
	public class Disassembler
	{
		internal readonly StringBuilder _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A = new StringBuilder();

		public string Disassemble(Module module)
		{
			return Disassemble(module, DisassemblyOptions.Default);
		}

		public string Disassemble(Module module, DisassemblyOptions options)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.AppendLine("; SPIR-V");
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append("; Version: ").Append(module.Header.Version).AppendLine();
			if (module.Header.GeneratorName == null)
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append("; Generator: unknown; ").Append(module.Header.GeneratorVersion).AppendLine();
			}
			else
			{
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append("; Generator: ").Append(module.Header.GeneratorVendor).Append(' ')
					.Append(module.Header.GeneratorName)
					.Append("; ")
					.Append(module.Header.GeneratorVersion)
					.AppendLine();
			}
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append("; Bound: ").Append(module.Header.Bound).AppendLine();
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append("; Schema: ").Append(module.Header.Reserved).AppendLine();
			string[] array = new string[module.Instructions.Count + 1];
			array[0] = _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.ToString();
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Clear();
			for (int i = 0; i < module.Instructions.Count; i++)
			{
				ParsedInstruction _0020_000A = module.Instructions[i];
				_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020(_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A, _0020_000A, options);
				array[i + 1] = _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.ToString();
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Clear();
			}
			int num = 0;
			foreach (string text in array)
			{
				num = Math.Max(num, text.IndexOf('='));
				if (num > 50)
				{
					num = 50;
					break;
				}
			}
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(array[0]);
			for (int k = 1; k < array.Length; k++)
			{
				string text2 = array[k];
				int num2 = text2.IndexOf('=');
				if (num2 == -1)
				{
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(' ', num + 4);
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(text2);
				}
				else
				{
					int repeatCount = Math.Max(0, num - num2);
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(' ', repeatCount);
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(text2, 0, num2);
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append('=');
					_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Append(text2, num2 + 1, text2.Length - num2 - 1);
				}
				_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.AppendLine();
			}
			string result = _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.ToString();
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A.Clear();
			return result;
		}

		internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020(StringBuilder _0020, ParsedInstruction _0020_000A, DisassemblyOptions _0020_0020)
		{
			if (_0020_000A.Operands.Count == 0)
			{
				_0020.Append(_0020_000A.Instruction.Name);
				return;
			}
			int i = 0;
			if (_0020_000A.Instruction.Operands[i].Type is IdResultType)
			{
				if (_0020_0020.HasFlag(DisassemblyOptions.ShowTypes))
				{
					_0020_000A.ResultType.ToString(_0020).Append(' ');
				}
				i++;
			}
			if (i < _0020_000A.Operands.Count && _0020_000A.Instruction.Operands[i].Type is IdResult)
			{
				if (!_0020_0020.HasFlag(DisassemblyOptions.ShowNames) || string.IsNullOrWhiteSpace(_0020_000A.Name))
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020, _0020_000A.Operands[i].Value, _0020_0020);
				}
				else
				{
					_0020.Append(_0020_000A.Name);
				}
				_0020.Append(" = ");
				i++;
			}
			_0020.Append(_0020_000A.Instruction.Name);
			_0020.Append(' ');
			for (; i < _0020_000A.Operands.Count; i++)
			{
				_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020, _0020_000A.Operands[i].Value, _0020_0020);
				_0020.Append(' ');
			}
		}

		internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A(StringBuilder _0020, object _0020_000A, DisassemblyOptions _0020_0020)
		{
			if (_0020_000A != null)
			{
				System.Type type;
				if ((object)(type = (_0020_000A as System.Type)) != null)
				{
					System.Type type2 = type;
					_0020.Append(type2.Name);
					return;
				}
				string text;
				if ((text = (_0020_000A as string)) != null)
				{
					string value = text;
					_0020.Append('"');
					_0020.Append(value);
					_0020.Append('"');
					return;
				}
				ObjectReference objectReference;
				if ((objectReference = (_0020_000A as ObjectReference)) != null)
				{
					ObjectReference objectReference2 = objectReference;
					if (_0020_0020.HasFlag(DisassemblyOptions.ShowNames) && objectReference2.Reference != null && !string.IsNullOrWhiteSpace(objectReference2.Reference.Name))
					{
						_0020.Append(objectReference2.Reference.Name);
					}
					else
					{
						objectReference2.ToString(_0020);
					}
					return;
				}
				IBitEnumOperandValue bitEnumOperandValue;
				if ((bitEnumOperandValue = (_0020_000A as IBitEnumOperandValue)) != null)
				{
					IBitEnumOperandValue _0020_000A2 = bitEnumOperandValue;
					_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(_0020, _0020_000A2, _0020_0020);
					return;
				}
				IValueEnumOperandValue valueEnumOperandValue;
				if ((valueEnumOperandValue = (_0020_000A as IValueEnumOperandValue)) != null)
				{
					IValueEnumOperandValue _0020_000A3 = valueEnumOperandValue;
					_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A(_0020, _0020_000A3, _0020_0020);
					return;
				}
				VaryingOperandValue varyingOperandValue;
				if ((varyingOperandValue = (_0020_000A as VaryingOperandValue)) != null)
				{
					varyingOperandValue.ToString(_0020);
					return;
				}
			}
			_0020.Append(_0020_000A);
		}

		internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020(StringBuilder _0020, IBitEnumOperandValue _0020_000A, DisassemblyOptions _0020_0020)
		{
			foreach (uint key in _0020_000A.Values.Keys)
			{
				_0020.Append(_0020_000A.EnumerationType.GetEnumName(key));
				IList<object> list = _0020_000A.Values[key];
				if (list.Count != 0)
				{
					_0020.Append(' ');
					foreach (object item in list)
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020, item, _0020_0020);
					}
				}
			}
		}

		internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A(StringBuilder _0020, IValueEnumOperandValue _0020_000A, DisassemblyOptions _0020_0020)
		{
			_0020.Append(_0020_000A.Key);
			IList<object> value;
			if ((value = _0020_000A.Value) != null && value.Count > 0)
			{
				_0020.Append(' ');
				foreach (object item in value)
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A(_0020, item, _0020_0020);
				}
			}
		}
	}
}
