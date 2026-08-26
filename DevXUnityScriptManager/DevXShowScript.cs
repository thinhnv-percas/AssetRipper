using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DevXShowScript : EditorWindow
{
	internal class _0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020
	{
		internal GUIStyle _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A;

		internal bool _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020;

		internal Vector2 _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A;

		private string _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020;

		private string[] _0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A;

		public string Text
		{
			get
			{
				return _0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020;
			}
			set
			{
				//IL_0014: Unknown result type (might be due to invalid IL or missing references)
				//IL_0020: Unknown result type (might be due to invalid IL or missing references)
				_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A = null;
				_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020 = value;
				_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A = default(Vector2);
				_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A = default(Vector2);
				List<string> list = new List<string>();
				if (value == null || value.Length <= 1000)
				{
					return;
				}
				int num = 0;
				for (int i = 0; i < value.Length; i++)
				{
					if (value[i] == '\n' || i - num > 256)
					{
						list.Add(value.Substring(num, i - num).Trim('\r').Trim('\n'));
						num = i + 1;
					}
				}
				_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A = list.ToArray();
			}
		}

		internal void _0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A(Rect P_0)
		{
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0113: Unknown result type (might be due to invalid IL or missing references)
			//IL_0128: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Unknown result type (might be due to invalid IL or missing references)
			//IL_014a: Unknown result type (might be due to invalid IL or missing references)
			GUIStyle val = _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A ?? GUI.skin.label;
			if (_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A == null)
			{
				if (Text != null)
				{
					if (_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020)
					{
						GUILayout.Label(Text, val, (GUILayoutOption[])(object)new GUILayoutOption[0]);
					}
					else
					{
						GUILayout.TextArea(Text, val, (GUILayoutOption[])(object)new GUILayoutOption[0]);
					}
				}
				return;
			}
			int num = 18;
			int num2 = 0;
			if (_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A == null)
			{
				return;
			}
			int num3 = (_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A.Length + 5) * num;
			num2 = (int)_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A.y / num - 1;
			if (num2 < 0)
			{
				num2 = 0;
			}
			GUILayout.Label(string.Empty, (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.Height((float)num3) });
			float num4 = 0f;
			if (_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A != null)
			{
				Rect val3 = default(Rect);
				for (int i = 0; (float)i < ((Rect)(ref P_0)).height / (float)num && i + num2 < _0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A.Length; i++)
				{
					string text = _0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A[i + num2];
					Vector2 val2 = val.CalcSize(new GUIContent(text));
					((Rect)(ref val3))._002Ector(8f, (float)((num2 + i) * num), Math.Max(val2.x + 30f, ((Rect)(ref P_0)).width), Mathf.Max(val2.y, (float)num));
					num4 = Math.Max(num4, Math.Max(val2.x, ((Rect)(ref P_0)).width));
					if (_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020)
					{
						GUI.Label(val3, text, val);
					}
					else
					{
						GUI.TextArea(val3, text, val);
					}
				}
			}
			GUILayout.Label(string.Empty, (GUILayoutOption[])(object)new GUILayoutOption[1] { GUILayout.Width(num4) });
		}
	}

	private _0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020 _0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020 = new _0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020();

	public string Text
	{
		set
		{
			_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020.Text = value;
		}
	}

	private void OnGUI()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020._0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A = GUILayout.BeginScrollView(_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020._0020_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A, (GUILayoutOption[])(object)new GUILayoutOption[0]);
		try
		{
			_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020._0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height));
		}
		catch
		{
		}
		GUILayout.EndScrollView();
	}

	internal static DevXShowScript _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(string P_0, string P_1)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		DevXShowScript obj = new DevXShowScript
		{
			Text = P_0
		};
		((EditorWindow)obj).titleContent = new GUIContent(P_1);
		((EditorWindow)obj).ShowUtility();
		return obj;
	}
}
