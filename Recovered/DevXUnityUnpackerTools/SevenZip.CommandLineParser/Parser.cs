using System;
using System.Collections;

namespace SevenZip.CommandLineParser
{
	public class Parser
	{
		public ArrayList NonSwitchStrings = new ArrayList();

		internal SwitchResult[] _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A;

		internal const char _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020 = '-';

		internal const char _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A = '/';

		internal const char _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020 = '-';

		internal const string _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A = "--";

		public SwitchResult this[int index] => _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A[index];

		public Parser(int numSwitches)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A = new SwitchResult[numSwitches];
			for (int i = 0; i < numSwitches; i++)
			{
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A[i] = new SwitchResult();
			}
		}

		internal bool _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020(string _0020, SwitchForm[] _0020_000A)
		{
			int length = _0020.Length;
			if (length == 0)
			{
				return false;
			}
			int num = 0;
			if (!_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020(_0020[num]))
			{
				return false;
			}
			while (num < length)
			{
				if (_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020(_0020[num]))
				{
					num++;
				}
				int num2 = 0;
				int num3 = -1;
				for (int i = 0; i < _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.Length; i++)
				{
					int length2 = _0020_000A[i].IDString.Length;
					if (length2 > num3 && num + length2 <= length && string.Compare(_0020_000A[i].IDString, 0, _0020, num, length2, ignoreCase: true) == 0)
					{
						num2 = i;
						num3 = length2;
					}
				}
				if (num3 == -1)
				{
					throw new Exception("maxLen == kNoLen");
				}
				SwitchResult switchResult = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A[num2];
				SwitchForm switchForm = _0020_000A[num2];
				if (!switchForm.Multi && switchResult.ThereIs)
				{
					throw new Exception("switch must be single");
				}
				switchResult.ThereIs = true;
				num += num3;
				int num4 = length - num;
				SwitchType type = switchForm.Type;
				switch (type)
				{
				case SwitchType.PostMinus:
					if (num4 == 0)
					{
						switchResult.WithMinus = false;
						break;
					}
					switchResult.WithMinus = (_0020[num] == '-');
					if (switchResult.WithMinus)
					{
						num++;
					}
					break;
				case SwitchType.PostChar:
				{
					if (num4 < switchForm.MinLen)
					{
						throw new Exception("switch is not full");
					}
					string postCharSet = switchForm.PostCharSet;
					if (num4 == 0)
					{
						switchResult.PostCharIndex = -1;
						break;
					}
					int num6 = postCharSet.IndexOf(_0020[num]);
					if (num6 < 0)
					{
						switchResult.PostCharIndex = -1;
						break;
					}
					switchResult.PostCharIndex = num6;
					num++;
					break;
				}
				case SwitchType.LimitedPostString:
				case SwitchType.UnLimitedPostString:
				{
					int minLen = switchForm.MinLen;
					if (num4 < minLen)
					{
						throw new Exception("switch is not full");
					}
					if (type == SwitchType.UnLimitedPostString)
					{
						switchResult.PostStrings.Add(_0020.Substring(num));
						return true;
					}
					string text = _0020.Substring(num, minLen);
					num += minLen;
					int num5 = minLen;
					while (num5 < switchForm.MaxLen && num < length)
					{
						char _00202 = _0020[num];
						if (_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020(_00202))
						{
							break;
						}
						text += _00202.ToString();
						num5++;
						num++;
					}
					switchResult.PostStrings.Add(text);
					break;
				}
				}
			}
			return true;
		}

		public void ParseStrings(SwitchForm[] switchForms, string[] commandStrings)
		{
			int num = commandStrings.Length;
			bool flag = false;
			for (int i = 0; i < num; i++)
			{
				string text = commandStrings[i];
				if (flag)
				{
					NonSwitchStrings.Add(text);
				}
				else if (text == "--")
				{
					flag = true;
				}
				else if (!_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020(text, switchForms))
				{
					NonSwitchStrings.Add(text);
				}
			}
		}

		public static int ParseCommand(CommandForm[] commandForms, string commandString, out string postString)
		{
			for (int i = 0; i < commandForms.Length; i++)
			{
				string iDString = commandForms[i].IDString;
				if (commandForms[i].PostStringMode)
				{
					if (commandString.IndexOf(iDString) == 0)
					{
						postString = commandString.Substring(iDString.Length);
						return i;
					}
				}
				else if (commandString == iDString)
				{
					postString = "";
					return i;
				}
			}
			postString = "";
			return -1;
		}

		internal static bool _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A(int _0020, _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020[] _0020_000A, string _0020_0020, ArrayList _0020_000A_000A)
		{
			_0020_000A_000A.Clear();
			int num = 0;
			for (int i = 0; i < _0020; i++)
			{
				_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020 _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020 = _0020_000A[i];
				int num2 = -1;
				int length = _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020.Chars.Length;
				for (int j = 0; j < length; j++)
				{
					char value = _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020.Chars[j];
					int num3 = _0020_0020.IndexOf(value);
					if (num3 >= 0)
					{
						if (num2 >= 0)
						{
							return false;
						}
						if (_0020_0020.IndexOf(value, num3 + 1) >= 0)
						{
							return false;
						}
						num2 = j;
						num++;
					}
				}
				if (num2 == -1 && !_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020.EmptyAllowed)
				{
					return false;
				}
				_0020_000A_000A.Add(num2);
			}
			return num == _0020_0020.Length;
		}

		internal static bool _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020(char _0020)
		{
			if (_0020 != '-')
			{
				return _0020 == '/';
			}
			return true;
		}
	}
}
