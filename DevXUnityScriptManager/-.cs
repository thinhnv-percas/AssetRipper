using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Unity.IO.Compression;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEditor.SceneManagement;
using UnityEditor.TreeViewExamples;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A : IDisposable
{
	public class _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A
	{
		public class _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A
		{
			internal _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020;

			internal uint _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A;

			internal string _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020
			{
				get
				{
					return _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020?._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A);
				}
				set
				{
					if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 != null)
					{
						_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(text);
					}
				}
			}

			internal _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A pool, string val)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = pool;
				_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = val;
			}

			internal _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A pool, uint key)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = pool;
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = key;
			}

			internal _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A pool)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = pool;
			}

			public override string ToString()
			{
				return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
			}

			internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(BinaryWriter P_0)
			{
				uint num = _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A;
				if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020.TryGetValue(num, out var value))
				{
					num = value;
				}
				_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(P_0, (int)num);
			}

			internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(BinaryReader P_0)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = (uint)_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(P_0);
			}
		}

		private struct _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020
		{
			internal uint _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020;

			internal string _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A;
		}

		internal int _0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020;

		internal List<string> _0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A = new List<string>();

		internal Dictionary<string, uint> _0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020 = new Dictionary<string, uint>();

		internal Dictionary<uint, int> _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A = new Dictionary<uint, int>();

		internal Dictionary<uint, uint> _0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020 = new Dictionary<uint, uint>();

		internal _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A()
		{
			_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
		}

		internal void _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A()
		{
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020 = 0;
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.Clear();
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020.Clear();
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A.Clear();
		}

		internal uint _0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(string P_0)
		{
			if (P_0 == null)
			{
				return 0u;
			}
			if (_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020.TryGetValue(P_0, out var value))
			{
				_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A[value] += 1;
				return value;
			}
			uint num = (uint)(_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.Count + 1);
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.Add(P_0);
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_0020[P_0] = num;
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A[num] = 1;
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020 += P_0.Length;
			return num;
		}

		internal _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A _0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020(string P_0)
		{
			return new _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(this, P_0);
		}

		internal string _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(uint P_0)
		{
			if (P_0 == 0)
			{
				return null;
			}
			P_0--;
			if (P_0 >= _0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.Count)
			{
				return null;
			}
			return _0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A[(int)P_0];
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(BinaryWriter P_0)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020.Clear();
			List<string> list = new List<string>();
			list = new List<string>(_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.ToArray());
			int count = list.Count;
			P_0.Write(count);
			MemoryStream memoryStream = new MemoryStream();
			uint num = 0u;
			for (int i = 0; i < list.Count; i++)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(list[i]);
				memoryStream.Write(bytes, 0, bytes.Length);
				int num2 = (int)memoryStream.Position;
				int num3 = num2 - (int)num;
				_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(P_0, num3);
				num = (uint)num2;
			}
			byte[] buffer = memoryStream.ToArray();
			P_0.Write(buffer);
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(BinaryReader P_0)
		{
			_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
			int num = P_0.ReadInt32();
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(P_0);
				_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020 += array[i];
			}
			string[] array2 = new string[num];
			for (int j = 0; j < num; j++)
			{
				array2[j] = Encoding.UTF8.GetString(P_0.ReadBytes(array[j]));
			}
			_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A.AddRange(array2);
		}

		public static void _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(BinaryWriter P_0, int P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020);
			}
			if (P_1 < 0)
			{
				throw new ArgumentOutOfRangeException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A, P_1, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020);
			}
			bool flag = true;
			while (flag || P_1 > 0)
			{
				flag = false;
				byte b = (byte)(P_1 & 0x7F);
				P_1 >>= 7;
				if (P_1 > 0)
				{
					b |= 0x80;
				}
				P_0.Write(b);
			}
		}

		public static int _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(BinaryReader P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A);
			}
			bool flag = true;
			int num = 0;
			int num2 = 0;
			while (flag)
			{
				byte b = P_0.ReadByte();
				flag = (b & 0x80) != 0;
				num |= (b & 0x7F) << num2;
				num2 += 7;
			}
			return num;
		}

		internal static bool _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020()
		{
			try
			{
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A obj = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();
				List<_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020> list = new List<_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020>();
				int num = 0;
				Random random = new Random();
				for (int i = 0; i < 10000; i++)
				{
					string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 + random.Next() % 100;
					num += text.Length;
					list.Add(new _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020
					{
						_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020 = obj._0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(text),
						_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A = text
					});
				}
				for (int j = 0; j < 1000; j++)
				{
					string text2 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A;
					num += text2.Length;
					list.Add(new _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020
					{
						_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020 = obj._0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_000A(text2),
						_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A = text2
					});
				}
				MemoryStream memoryStream = new MemoryStream();
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					obj._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(binaryWriter);
				}
				byte[] buffer = memoryStream.ToArray();
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A obj2 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();
				using (BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer)))
				{
					obj2._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(binaryReader);
				}
				foreach (_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020 item in list)
				{
					uint num2 = item._0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_0020;
					if (obj._0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020.TryGetValue(num2, out var value))
					{
						num2 = value;
					}
					if (obj2._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(num2) != item._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A)
					{
						Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020);
						return false;
					}
				}
				Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A);
				MemoryStream memoryStream2 = new MemoryStream();
				BinaryWriter binaryWriter2 = new BinaryWriter(memoryStream2);
				for (int k = 0; k < 10000; k++)
				{
					_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(binaryWriter2, k);
				}
				for (int l = 10000; l < int.MaxValue && l > 0; l += l / 4)
				{
					try
					{
						_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(binaryWriter2, l);
					}
					catch (Exception ex)
					{
						Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020);
						Console.WriteLine((_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A + l + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + ex) ?? "");
						return false;
					}
				}
				memoryStream2 = new MemoryStream(memoryStream2.ToArray());
				BinaryReader binaryReader2 = new BinaryReader(memoryStream2);
				for (int m = 0; m < 10000; m++)
				{
					if (_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(binaryReader2) != m)
					{
						Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020);
						return false;
					}
				}
				for (int n = 10000; n < int.MaxValue && n > 0; n += n / 4)
				{
					try
					{
						if (_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(binaryReader2) != n)
						{
							Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020);
							return false;
						}
					}
					catch (Exception ex2)
					{
						Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020);
						Console.WriteLine((_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A + n + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + ex2) ?? "");
						return false;
					}
				}
				return true;
			}
			catch (Exception ex3)
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A + ex3);
				return false;
			}
		}
	}

	private static class _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A
	{
		private static int[] _0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A = new int[32]
		{
			0, 1, 28, 2, 29, 14, 24, 3, 30, 22,
			20, 15, 25, 17, 4, 8, 31, 27, 13, 23,
			21, 19, 16, 7, 26, 12, 18, 6, 11, 5,
			10, 9
		};

		private unsafe static uint _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020(byte* P_0, uint P_1, byte* P_2, ref uint P_3, uint P_4, void* P_5)
		{
			byte* ptr = P_0 + P_1;
			byte* ptr2 = P_0 + P_1 - 20;
			byte* ptr3 = P_2;
			byte* ptr4 = P_0;
			byte* ptr5 = ptr4;
			ptr4 += ((P_4 < 4) ? (4 - P_4) : 0);
			while (true)
			{
				ptr4 += 1 + (ptr4 - ptr5 >> 5);
				while (true)
				{
					byte* ptr6;
					uint num7;
					uint num6;
					if (ptr4 < ptr2)
					{
						uint num = *(uint*)ptr4;
						uint num2 = (405029533 * num >> 18) & 0x3FFF;
						ptr6 = P_0 + (int)((ushort*)P_5)[num2];
						((short*)P_5)[num2] = (short)(ushort)(ptr4 - P_0);
						if (num != *(uint*)ptr6)
						{
							break;
						}
						ptr5 -= P_4;
						P_4 = 0u;
						uint num3 = (uint)(ptr4 - ptr5);
						if (num3 != 0)
						{
							if (num3 <= 3)
							{
								byte* num4 = ptr3 + -2;
								*num4 |= (byte)num3;
								*(int*)ptr3 = *(int*)ptr5;
								ptr3 += num3;
							}
							else if (num3 <= 16)
							{
								*(ptr3++) = (byte)(num3 - 3);
								*(int*)ptr3 = *(int*)ptr5;
								((int*)ptr3)[1] = ((int*)ptr5)[1];
								((int*)ptr3)[2] = ((int*)ptr5)[2];
								((int*)ptr3)[3] = ((int*)ptr5)[3];
								ptr3 += num3;
							}
							else
							{
								if (num3 <= 18)
								{
									*(ptr3++) = (byte)(num3 - 3);
								}
								else
								{
									uint num5 = num3 - 18;
									*(ptr3++) = 0;
									while (num5 > 255)
									{
										num5 -= 255;
										*(ptr3++) = 0;
									}
									*(ptr3++) = (byte)num5;
								}
								do
								{
									*(int*)ptr3 = *(int*)ptr5;
									((int*)ptr3)[1] = ((int*)ptr5)[1];
									((int*)ptr3)[2] = ((int*)ptr5)[2];
									((int*)ptr3)[3] = ((int*)ptr5)[3];
									ptr3 += 16;
									ptr5 += 16;
									num3 -= 16;
								}
								while (num3 >= 16);
								if (num3 != 0)
								{
									do
									{
										*(ptr3++) = *(ptr5++);
									}
									while (--num3 != 0);
								}
							}
						}
						num6 = 4u;
						num7 = *(uint*)(ptr4 + num6) ^ *(uint*)(ptr6 + num6);
						if (num7 != 0)
						{
							goto IL_01d1;
						}
						while (true)
						{
							num6 += 4;
							num7 = *(uint*)(ptr4 + num6) ^ *(uint*)(ptr6 + num6);
							if (ptr4 + num6 >= ptr2)
							{
								break;
							}
							if (num7 == 0)
							{
								continue;
							}
							goto IL_01d1;
						}
						goto IL_01df;
					}
					P_3 = (uint)(ptr3 - P_2);
					return (uint)(ptr - (ptr5 - P_4));
					IL_01d1:
					num6 += (uint)_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A(num7) / 8u;
					goto IL_01df;
					IL_01df:
					uint num8 = (uint)(ptr4 - ptr6);
					ptr4 += num6;
					ptr5 = ptr4;
					if (num6 <= 8 && num8 <= 2048)
					{
						num8--;
						*(ptr3++) = (byte)((num6 - 1 << 5) | ((num8 & 7) << 2));
						*(ptr3++) = (byte)(num8 >> 3);
						continue;
					}
					if (num8 <= 16384)
					{
						num8--;
						if (num6 <= 33)
						{
							*(ptr3++) = (byte)(0x20 | (num6 - 2));
						}
						else
						{
							num6 -= 33;
							*(ptr3++) = 32;
							while (num6 > 255)
							{
								num6 -= 255;
								*(ptr3++) = 0;
							}
							*(ptr3++) = (byte)num6;
						}
						*(ptr3++) = (byte)(num8 << 2);
						*(ptr3++) = (byte)(num8 >> 6);
						continue;
					}
					num8 -= 16384;
					if (num6 <= 9)
					{
						*(ptr3++) = (byte)(0x10 | ((num8 >> 11) & 8) | (num6 - 2));
					}
					else
					{
						num6 -= 9;
						*(ptr3++) = (byte)(0x10 | ((num8 >> 11) & 8));
						while (num6 > 255)
						{
							num6 -= 255;
							*(ptr3++) = 0;
						}
						*(ptr3++) = (byte)num6;
					}
					*(ptr3++) = (byte)(num8 << 2);
					*(ptr3++) = (byte)(num8 >> 6);
				}
			}
		}

		private static int _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_000A(uint P_0)
		{
			return _0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_000A[(uint)((P_0 & (0L - (long)P_0)) * 125613361) >> 27];
		}

		private unsafe static int _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020(byte* P_0, uint P_1, byte* P_2, ref uint P_3, byte* P_4)
		{
			byte* ptr = P_0;
			byte* ptr2 = P_2;
			uint num = P_1;
			uint num2 = 0u;
			while (num > 20)
			{
				uint num3 = num;
				num3 = ((num3 <= 49152) ? num3 : 49152u);
				ulong num4 = (ulong)ptr + (ulong)num3;
				if (num4 + (num2 + num3 >> 5) <= num4 || (nuint)(num4 + (num2 + num3 >> 5)) <= (nuint)(ptr + num3))
				{
					break;
				}
				for (int i = 0; i < 32768; i++)
				{
					P_4[i] = 0;
				}
				num2 = _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020(ptr, num3, ptr2, ref P_3, num2, P_4);
				ptr += num3;
				ptr2 += P_3;
				num -= num3;
			}
			num2 += num;
			if (num2 != 0)
			{
				byte* ptr3 = P_0 + P_1 - num2;
				if (ptr2 == P_2 && num2 <= 238)
				{
					*(ptr2++) = (byte)(17 + num2);
				}
				else
				{
					switch (num2)
					{
					case 0u:
					case 1u:
					case 2u:
					case 3u:
					{
						byte* num6 = ptr2 + -2;
						*num6 |= (byte)num2;
						break;
					}
					case 4u:
					case 5u:
					case 6u:
					case 7u:
					case 8u:
					case 9u:
					case 10u:
					case 11u:
					case 12u:
					case 13u:
					case 14u:
					case 15u:
					case 16u:
					case 17u:
					case 18u:
						*(ptr2++) = (byte)(num2 - 3);
						break;
					default:
					{
						uint num5 = num2 - 18;
						*(ptr2++) = 0;
						while (num5 > 255)
						{
							num5 -= 255;
							*(ptr2++) = 0;
						}
						*(ptr2++) = (byte)num5;
						break;
					}
					}
				}
				do
				{
					*(ptr2++) = *(ptr3++);
				}
				while (--num2 != 0);
			}
			*(ptr2++) = 17;
			*(ptr2++) = 0;
			*(ptr2++) = 0;
			P_3 = (uint)(ptr2 - P_2);
			return 0;
		}

		public unsafe static int _0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A(byte* P_0, uint P_1, byte* P_2, ref uint P_3, void* P_4)
		{
			byte* ptr = P_0 + P_1;
			P_3 = 0u;
			byte* ptr2 = P_2;
			byte* ptr3 = P_0;
			bool flag = false;
			bool flag2 = false;
			if (*ptr3 > 17)
			{
				uint num = (uint)(*(ptr3++) - 17);
				if (num < 4)
				{
					_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020(ref ptr2, ref ptr3, ref num);
				}
				else
				{
					do
					{
						*(ptr2++) = *(ptr3++);
					}
					while (--num != 0);
					flag = true;
				}
			}
			while (true)
			{
				uint num;
				if (flag)
				{
					flag = false;
				}
				else
				{
					num = *(ptr3++);
					if (num >= 16)
					{
						goto IL_012a;
					}
					if (num == 0)
					{
						for (; *ptr3 == 0; ptr3++)
						{
							num += 255;
						}
						num += (uint)(15 + *(ptr3++));
					}
					*(int*)ptr2 = *(int*)ptr3;
					ptr2 += 4;
					ptr3 += 4;
					if (--num != 0)
					{
						if (num >= 4)
						{
							do
							{
								*(int*)ptr2 = *(int*)ptr3;
								ptr2 += 4;
								ptr3 += 4;
								num -= 4;
							}
							while (num >= 4);
							if (num != 0)
							{
								do
								{
									*(ptr2++) = *(ptr3++);
								}
								while (--num != 0);
							}
						}
						else
						{
							do
							{
								*(ptr2++) = *(ptr3++);
							}
							while (--num != 0);
						}
					}
				}
				num = *(ptr3++);
				if (num < 16)
				{
					byte* ptr4 = ptr2 - 2049;
					ptr4 -= num >> 2;
					ptr4 -= *(ptr3++) << 2;
					*(ptr2++) = *(ptr4++);
					*(ptr2++) = *(ptr4++);
					*(ptr2++) = *ptr4;
					flag2 = true;
				}
				goto IL_012a;
				IL_012a:
				while (true)
				{
					if (flag2)
					{
						flag2 = false;
					}
					else if (num >= 64)
					{
						byte* ptr4 = ptr2 - 1;
						ptr4 -= (num >> 2) & 7;
						ptr4 -= *(ptr3++) << 3;
						num = (num >> 5) - 1;
						_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A(ref ptr2, ref ptr4, ref num);
					}
					else
					{
						byte* ptr4;
						if (num >= 32)
						{
							num &= 0x1F;
							if (num == 0)
							{
								for (; *ptr3 == 0; ptr3++)
								{
									num += 255;
								}
								num += (uint)(31 + *(ptr3++));
							}
							ptr4 = ptr2 - 1;
							ptr4 -= *(ushort*)ptr3 >> 2;
							ptr3 += 2;
						}
						else
						{
							if (num < 16)
							{
								ptr4 = ptr2 - 1;
								ptr4 -= num >> 2;
								ptr4 -= *(ptr3++) << 2;
								*(ptr2++) = *(ptr4++);
								*(ptr2++) = *ptr4;
								goto IL_029a;
							}
							ptr4 = ptr2;
							ptr4 -= (num & 8) << 11;
							num &= 7;
							if (num == 0)
							{
								for (; *ptr3 == 0; ptr3++)
								{
									num += 255;
								}
								num += (uint)(7 + *(ptr3++));
							}
							ptr4 -= *(ushort*)ptr3 >> 2;
							ptr3 += 2;
							if (ptr4 == ptr2)
							{
								P_3 = (uint)(ptr2 - P_2);
								if (ptr3 != ptr)
								{
									if (ptr3 >= ptr)
									{
										return -4;
									}
									return -8;
								}
								return 0;
							}
							ptr4 -= 16384;
						}
						if (num >= 6 && ptr2 - ptr4 >= 4)
						{
							*(int*)ptr2 = *(int*)ptr4;
							ptr2 += 4;
							ptr4 += 4;
							num -= 2;
							while (true)
							{
								*(int*)ptr2 = *(int*)ptr4;
								ptr2 += 4;
								ptr4 += 4;
								num -= 4;
								switch (num)
								{
								default:
									continue;
								case 1u:
								case 2u:
								case 3u:
									do
									{
										*(ptr2++) = *(ptr4++);
									}
									while (--num != 0);
									break;
								case 0u:
									break;
								}
								break;
							}
						}
						else
						{
							*(ptr2++) = *(ptr4++);
							*(ptr2++) = *(ptr4++);
							do
							{
								*(ptr2++) = *(ptr4++);
							}
							while (--num != 0);
						}
					}
					goto IL_029a;
					IL_029a:
					num = (uint)(ptr3[-2] & 3);
					if (num == 0)
					{
						break;
					}
					*(ptr2++) = *(ptr3++);
					if (num > 1)
					{
						*(ptr2++) = *(ptr3++);
						if (num > 2)
						{
							*(ptr2++) = *(ptr3++);
						}
					}
					num = *(ptr3++);
				}
			}
		}

		private unsafe static void _0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020(ref byte* P_0, ref byte* P_1, ref uint P_2)
		{
			do
			{
				*(P_0++) = *(P_1++);
			}
			while (--P_2 != 0);
			P_2 = *(P_1++);
		}

		private unsafe static void _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A(ref byte* P_0, ref byte* P_1, ref uint P_2)
		{
			*(P_0++) = *(P_1++);
			*(P_0++) = *(P_1++);
			do
			{
				*(P_0++) = *(P_1++);
			}
			while (--P_2 != 0);
		}

		internal unsafe static byte[] _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020(byte[] P_0, byte[] P_1)
		{
			uint num = 0u;
			fixed (byte* ptr = P_0)
			{
				fixed (byte* ptr2 = new byte[IntPtr.Size * 16384])
				{
					fixed (byte* ptr3 = P_1)
					{
						_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A(ptr, (uint)P_0.Length, ptr3, ref num, ptr2);
					}
				}
			}
			return P_1;
		}

		internal unsafe static void _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020(byte* P_0, uint P_1, byte* P_2, ref uint P_3)
		{
			fixed (byte* ptr = new byte[IntPtr.Size * 16384])
			{
				_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A(P_0, P_1, P_2, ref P_3, ptr);
			}
		}

		internal unsafe static byte[] _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(byte[] P_0)
		{
			byte[] array = new byte[P_0.Length + P_0.Length / 16 + 64 + 3];
			uint newSize = 0u;
			fixed (byte* ptr = P_0)
			{
				fixed (byte* ptr2 = new byte[IntPtr.Size * 16384])
				{
					fixed (byte* ptr3 = array)
					{
						_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020(ptr, (uint)P_0.Length, ptr3, ref newSize, ptr2);
					}
				}
			}
			Array.Resize(ref array, (int)newSize);
			return array;
		}

		internal unsafe static void _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(byte* P_0, uint P_1, byte* P_2, ref uint P_3)
		{
			fixed (byte* ptr = new byte[IntPtr.Size * 16384])
			{
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020(P_0, P_1, P_2, ref P_3, ptr);
			}
		}

		internal static bool _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020()
		{
			try
			{
				string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020;
				text = text + text + text + text;
				byte[] bytes = Encoding.UTF7.GetBytes(text);
				if (!_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(bytes))
				{
					return false;
				}
				bytes = new byte[1000];
				for (int i = 0; i < bytes.Length; i++)
				{
					bytes[i] = (byte)i;
				}
				if (!_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(bytes))
				{
					return false;
				}
				bytes = new byte[1000];
				for (int j = 0; j < bytes.Length; j++)
				{
					bytes[j] = (byte)((j * 1011 + 13) % 313);
				}
				if (!_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(bytes))
				{
					return false;
				}
				Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A);
				return true;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 + ex);
				return false;
			}
		}

		[CompilerGenerated]
		internal static bool _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020(byte[] P_0)
		{
			byte[] array = _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(P_0);
			byte[] array2 = new byte[P_0.Length];
			_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020(array, array2);
			for (int i = 0; i < P_0.Length; i++)
			{
				if (array2[i] != P_0[i])
				{
					Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A);
					return false;
				}
			}
			Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020 + array.Length * 100 / P_0.Length + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
			return true;
		}
	}

	private class _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020 : _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020
	{
		internal new string _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020
		{
			get
			{
				byte[] array = _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A();
				if (array == null)
				{
					return null;
				}
				if (array.Length == 0)
				{
					return string.Empty;
				}
				return Encoding.UTF8.GetString(array);
			}
			set
			{
				if (text == null)
				{
					_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(null);
				}
				else if (text.Length == 0)
				{
					_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(new byte[0]);
				}
				else
				{
					_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(Encoding.UTF8.GetBytes(text));
				}
			}
		}

		internal _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020(string str)
		{
			_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = str;
		}

		internal _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020(BinaryReader rd)
		{
			_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(rd);
		}

		public override string ToString()
		{
			return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
		}
	}

	private class _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A : _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020
	{
		internal _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A(byte[] buff)
		{
			base._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = buff;
		}

		internal _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A(BinaryReader rd)
		{
			_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(rd);
		}
	}

	private class _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020
	{
		private const int _0020_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020 = 0;

		private const int _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A = 2;

		internal byte _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020;

		internal int _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A;

		internal byte[] _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;

		private long _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A;

		internal byte[] _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020
		{
			get
			{
				return _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A();
			}
			set
			{
				_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(array);
			}
		}

		internal bool _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020
		{
			get
			{
				if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020 == null)
				{
					return true;
				}
				return false;
			}
		}

		internal int _0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020
		{
			get
			{
				if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020 == null)
				{
					return 0;
				}
				return _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A;
			}
		}

		internal _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020()
		{
		}

		internal _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020(byte[] buff)
		{
			_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(buff);
		}

		internal _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020(BinaryReader rd)
		{
			_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(rd);
		}

		internal static byte[] _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A(byte[] P_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				new _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020(P_0)._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(binaryWriter);
			}
			return memoryStream.ToArray();
		}

		internal static byte[] _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020(byte[] P_0)
		{
			using BinaryReader binaryReader = new BinaryReader(new MemoryStream(P_0));
			_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020 obj = new _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020();
			obj._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(binaryReader);
			return obj._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(BinaryWriter P_0)
		{
			P_0.Write(_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020);
			if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 != 0)
			{
				P_0.Write(_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A);
			}
			P_0.Write(_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020.Length);
			P_0.Write(_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020);
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(BinaryReader P_0)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 = P_0.ReadByte();
			if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 != 0)
			{
				_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = P_0.ReadInt32();
			}
			int num = P_0.ReadInt32();
			_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020 = P_0.ReadBytes(num);
			if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 == 0)
			{
				_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = num;
			}
		}

		internal void _0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A(byte[] P_0)
		{
			_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020 = P_0;
			_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 = 0;
			if (P_0 == null)
			{
				_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = 0;
				return;
			}
			_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A = P_0.Length;
			if (P_0.Length > 100)
			{
				byte[] array = _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A._0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A(P_0);
				if (array.Length + 4 < P_0.Length)
				{
					_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020 = array;
					_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 = 2;
				}
			}
		}

		internal byte[] _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A()
		{
			if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 == 0)
			{
				return _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;
			}
			if (_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020 == 2)
			{
				byte[] array = new byte[_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A];
				_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A._0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020(_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020, array);
				return array;
			}
			return _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020;
		}

		public override string ToString()
		{
			return _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 + _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020?.Length + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A + _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 + _0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_0020;
		}

		internal static bool _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020()
		{
			byte[] array = new byte[10000];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(i / 10);
			}
			byte[] array2 = _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A(array);
			if (array2.Length >= array.Length)
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A);
				return false;
			}
			byte[] array3 = _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020(array2);
			if (!_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020._0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A(array, array3))
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020);
				return false;
			}
			string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020;
			text = text + text + text + text;
			array = Encoding.UTF7.GetBytes(text);
			if (!_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A(array))
			{
				return false;
			}
			array = new byte[1000];
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = (byte)j;
			}
			if (!_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A(array))
			{
				return false;
			}
			array = new byte[1000];
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = (byte)((k * 1011 + 13) % 313);
			}
			if (!_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A(array))
			{
				return false;
			}
			return true;
		}

		[CompilerGenerated]
		internal static bool _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A(byte[] P_0)
		{
			byte[] array = _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A(P_0);
			byte[] array2 = _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020(array);
			if (array2.Length != P_0.Length)
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A);
				return false;
			}
			for (int i = 0; i < P_0.Length; i++)
			{
				if (array2[i] != P_0[i])
				{
					Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A);
					return false;
				}
			}
			Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 + array.Length * 100 / P_0.Length + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A);
			return true;
		}
	}

	private class _0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020
	{
		private ulong _0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A;

		private static ulong _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020 = 25214903917uL;

		private static ulong _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A = 11uL;

		private static ulong _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020 = 281474976710655uL;

		internal _0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020(ulong key)
		{
			_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = key;
		}

		internal int _0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A(int P_0 = 1)
		{
			for (int i = 0; i < P_0; i++)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A = (_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A * _0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020 + _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A) & _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020;
			}
			return Math.Abs((int)_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A);
		}
	}

	public class _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A
	{
		public enum Formats
		{
			Null = 0,
			Bytes = 1,
			BytesCompressedPack = 2,
			StringPoolItem = 3,
			StringCompressedPack = 4,
			String = 5,
			Bool = 6,
			Long = 7,
			ULong = 8,
			Int = 9,
			UInt = 10,
			Short = 11,
			UShort = 12,
			Byte = 13,
			SByte = 14,
			Char = 15,
			Float = 16,
			Double = 17,
			Decimal = 18,
			DateTime = 19,
			XmlBinNode = 20,
			ChildNodes = 21,
			TypesFilter = 63
		}

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A
		{
			public BinaryWriter _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A;
		}

		public List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A> _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020;

		internal _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A;

		public readonly _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020;

		internal object _0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A;

		public object _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020
		{
			get
			{
				if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A obj)
				{
					return obj._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
				}
				if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020 obj2)
				{
					return obj2._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
				}
				if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A obj3)
				{
					return obj3._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;
				}
				return _0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A;
			}
			set
			{
				if (obj is string text)
				{
					if (text.Length < 255)
					{
						_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_0020_0020_000A_0020_0020_000A_0020_0020_0020_0020(text);
					}
					else
					{
						_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = new _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020(text);
					}
				}
				else if (obj is byte[] array && array.Length > 128)
				{
					_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = new _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A(array);
				}
				else
				{
					_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = obj;
				}
			}
		}

		public string _0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020
		{
			get
			{
				if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null && _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						stringBuilder.AppendLine(item?._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020);
					}
					return stringBuilder.ToString();
				}
				return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020?.ToString();
			}
		}

		public string _0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A
		{
			get
			{
				if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null && _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count > 0)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine(string.Concat(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020));
					foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						stringBuilder.AppendLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A + item._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A?.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020));
					}
					return stringBuilder.ToString();
				}
				return string.Concat(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A, _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020?.ToString());
			}
		}

		public void _0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A P_0)
		{
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 == null)
			{
				_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 = new List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A>();
			}
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Add(P_0);
		}

		internal _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A owner)
		{
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A = owner;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(owner._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020);
		}

		internal _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A owner, string name)
		{
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A = owner;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(owner._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020, name);
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(BinaryWriter P_0)
		{
			_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A obj = default(_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A);
			obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A = P_0;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null && _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count > 0)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.ChildNodes, ref obj);
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A, _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count);
				for (int i = 0; i < _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count; i++)
				{
					_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020[i]._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
				}
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A == null)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Null, ref obj);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020 obj2)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.StringCompressedPack, ref obj);
				obj2._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A obj3)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.BytesCompressedPack, ref obj);
				obj3._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is byte[] array)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Bytes, ref obj);
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A, array.Length);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(array);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A obj4)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.StringPoolItem, ref obj);
				obj4._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is string s)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.String, ref obj);
				byte[] bytes = Encoding.UTF8.GetBytes(s);
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A, bytes.Length);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(bytes);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is bool flag)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Bool, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write((byte)(flag ? 1u : 0u));
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is long value)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Long, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is ulong value2)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.ULong, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value2);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is int value3)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Int, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value3);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is uint value4)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.UInt, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value4);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is short value5)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Short, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value5);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is ushort value6)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.UShort, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value6);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is byte value7)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Byte, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value7);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is sbyte value8)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.SByte, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value8);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is char ch)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Char, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(ch);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is float value9)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Float, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value9);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is double value10)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Double, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value10);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is decimal value11)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Decimal, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(value11);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is DateTime dateTime)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.DateTime, ref obj);
				obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write(dateTime.ToBinary());
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj5)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.XmlBinNode, ref obj);
				obj5._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
			}
			else if (_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A is List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A> list)
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.ChildNodes, ref obj);
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_0020(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A, list.Count);
				for (int j = 0; j < list.Count; j++)
				{
					list[j]._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A);
				}
			}
			else
			{
				_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats.Null, ref obj);
			}
		}

		internal void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(BinaryReader P_0)
		{
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 = null;
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(P_0);
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A != null && _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020?.ToString() == _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
			{
				return;
			}
			byte b = P_0.ReadByte();
			switch ((Formats)(b & 0x3F))
			{
			case Formats.Null:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = null;
				break;
			case Formats.Bytes:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadBytes(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(P_0));
				break;
			case Formats.BytesCompressedPack:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = new _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A(P_0);
				break;
			case Formats.String:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = Encoding.UTF8.GetString(P_0.ReadBytes(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(P_0)));
				break;
			case Formats.StringCompressedPack:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = new _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020(P_0);
				break;
			case Formats.StringPoolItem:
			{
				_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A obj3 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020);
				obj3._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(P_0);
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = obj3;
				break;
			}
			case Formats.Bool:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadByte() == 1;
				break;
			case Formats.Long:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadInt64();
				break;
			case Formats.ULong:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadUInt64();
				break;
			case Formats.Int:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadInt32();
				break;
			case Formats.UInt:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadUInt32();
				break;
			case Formats.Short:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadInt16();
				break;
			case Formats.UShort:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadUInt16();
				break;
			case Formats.Byte:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadByte();
				break;
			case Formats.SByte:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadSByte();
				break;
			case Formats.Float:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadSingle();
				break;
			case Formats.Double:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadDouble();
				break;
			case Formats.Decimal:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadDecimal();
				break;
			case Formats.DateTime:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = DateTime.FromBinary(P_0.ReadInt64());
				break;
			case Formats.Char:
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = P_0.ReadChar();
				break;
			case Formats.XmlBinNode:
			{
				_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj2 = new _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A);
				obj2._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(P_0);
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = obj2;
				break;
			}
			case Formats.ChildNodes:
			{
				int num = _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_000A(P_0);
				_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 = null;
				for (int i = 0; i < num; i++)
				{
					_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = new _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A);
					_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
					obj._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(P_0);
					if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A != null && obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020?.ToString() == _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A)
					{
						break;
					}
				}
				_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_000A = null;
				break;
			}
			default:
				throw new Exception(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A + b);
			}
		}

		internal void _0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 P_0, bool P_1 = false)
		{
			string text = null;
			if (_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 == null && (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 == null || _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count == 0))
			{
				P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string.Concat(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020, _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020, text, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020));
				return;
			}
			P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string.Concat(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020, _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020, text, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A));
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null && _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count > 0)
			{
				foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
				{
					item?._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(P_0, P_1);
				}
			}
			else if (_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 != null)
			{
				try
				{
					if (_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 is _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj)
					{
						obj._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(P_0, P_1);
					}
					else if (!P_1 && _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 is byte[] inArray)
					{
						P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(Convert.ToBase64String(inArray));
					}
					else if (_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 is float num)
					{
						P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(num.ToString().Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_0020));
					}
					else
					{
						P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020?.ToString().Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A).Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020)
							.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A)
							.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A)
							.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A));
					}
				}
				catch (Exception value)
				{
					Console.WriteLine(value);
				}
			}
			P_0._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string.Concat(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020, _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A));
		}

		public override string ToString()
		{
			MemoryStream memoryStream = new MemoryStream();
			using (_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 obj = new _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(memoryStream))
			{
				_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(obj);
				obj.Flush();
			}
			if (memoryStream.Length == 0L)
			{
				return null;
			}
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}

		internal void _0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020(_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 P_0, bool P_1 = false)
		{
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 == null || _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count <= 0)
			{
				return;
			}
			foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
			{
				item?._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(P_0, P_1);
			}
		}

		public _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(string P_0)
		{
			string[] array = P_0.Trim('/', '\\').Split('/', '\\');
			if (array.Length == 0)
			{
				return null;
			}
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = null;
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null)
			{
				foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
				{
					if (item._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020?.ToString() == array[0])
					{
						obj = item;
						break;
					}
				}
			}
			if (obj == null)
			{
				return null;
			}
			if (array.Length > 1)
			{
				return obj._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(string.Join(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A, array, 1, array.Length - 1));
			}
			return obj;
		}

		public List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A> _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020(string P_0)
		{
			string[] array = P_0.Trim('/', '\\').Split('/', '\\');
			if (array.Length == 0)
			{
				return null;
			}
			if (array.Length == 1)
			{
				List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A> list = new List<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A>();
				if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null)
				{
					foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
					{
						if (item._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020?.ToString() == array[0])
						{
							list.Add(item);
						}
					}
				}
				return list;
			}
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = null;
			if (_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020 != null)
			{
				foreach (_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item2 in _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
				{
					if (item2._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_0020?.ToString() == array[0])
					{
						obj = item2;
						break;
					}
				}
			}
			return obj?._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020(string.Join(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A, array, 1, array.Length - 1));
		}

		public string _0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(string P_0)
		{
			return _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0)?._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020;
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020(_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A P_0, string P_1, out string P_2)
		{
			P_2 = null;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_1);
			if (obj == null)
			{
				return false;
			}
			P_2 = obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020;
			return true;
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(string P_0, out int P_1)
		{
			P_1 = 0;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0);
			if (obj == null)
			{
				return false;
			}
			return int.TryParse(obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020, out P_1);
		}

		public int _0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020(string P_0)
		{
			int result = 0;
			if (!_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(P_0, out result))
			{
				throw new Exception(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020 + P_0);
			}
			return result;
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A(string P_0, out long P_1)
		{
			P_1 = 0L;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0);
			if (obj == null)
			{
				return false;
			}
			return long.TryParse(obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020, out P_1);
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020(string P_0, out decimal P_1)
		{
			P_1 = 0m;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0);
			if (obj == null)
			{
				return false;
			}
			return _0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020._0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020, out P_1);
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A(string P_0, out bool P_1)
		{
			P_1 = false;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0);
			if (obj == null)
			{
				return false;
			}
			if (obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020 || obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020.ToLower() == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A)
			{
				P_1 = true;
				return true;
			}
			if (obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A || obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020.ToLower() == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020)
			{
				P_1 = false;
				return true;
			}
			return false;
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_0020(string P_0, out TimeSpan P_1)
		{
			try
			{
				P_1 = TimeSpan.Parse(P_0);
				return true;
			}
			catch
			{
			}
			P_1 = default(TimeSpan);
			return false;
		}

		public bool _0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A(string P_0, out byte[] P_1)
		{
			P_1 = null;
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(P_0);
			if (obj == null)
			{
				return false;
			}
			try
			{
				P_1 = Convert.FromBase64String(obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020);
			}
			catch
			{
			}
			if (P_1 == null)
			{
				return false;
			}
			return true;
		}

		public string _0020_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020(string P_0)
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return null;
			}
			string[] array = P_0.Split('@');
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = this;
			if (!string.IsNullOrEmpty(array[0]))
			{
				obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(array[0]);
			}
			if (obj == null)
			{
				return null;
			}
			if (array.Length == 1)
			{
				return obj._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020;
			}
			if (array.Length == 2)
			{
				array[1] = array[1].Trim('[', ']');
				List<string> list = new List<string>();
				return string.Join(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, list.ToArray());
			}
			return null;
		}

		public void _0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_000A(string P_0, string P_1)
		{
			if (!string.IsNullOrEmpty(P_0))
			{
				string[] array = P_0.Split('@');
				_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = this;
				if (!string.IsNullOrEmpty(array[0]))
				{
					obj = _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(array[0]);
				}
				if (obj == null)
				{
					obj = obj._0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(array[0], P_1);
					_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
				}
				if (array.Length == 1)
				{
					obj._0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = P_1;
				}
			}
		}

		[CompilerGenerated]
		internal static void _0020_0020_0020_0020_000A_000A_0020_0020_0020_0020_0020(Formats P_0, ref _0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A P_1)
		{
			P_1._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A.Write((byte)P_0);
		}
	}

	private class _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020 : IDisposable
	{
		private _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A _0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020;

		private string _0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A;

		internal _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020(_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A x, string tag)
		{
			_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020 = x;
			_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A = tag;
		}

		public void Dispose()
		{
			_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020._0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_000A);
		}
	}

	private const string _0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020 = "DEVXSMBX";

	private const byte _0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A = 1;

	internal byte[] _0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020;

	internal _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();

	public _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A;

	internal _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020;

	internal byte _0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A;

	public byte _0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 = 1;

	internal long _0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A;

	public const byte _0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_0020 = 0;

	public const byte _0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_000A = 1;

	private Stream _0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020;

	internal string _0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A;

	public int _0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020 = 3;

	private Stack<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A> _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A = new Stack<_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A>();

	private int _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020;

	private Stack<string> _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A = new Stack<string>();

	internal int _0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A
	{
		get
		{
			int num = 0;
			if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 != null)
			{
				num += _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020;
			}
			return num;
		}
	}

	public string _0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020 => ((_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020 > 0) ? _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020 : "") + string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A, _0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020) + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020;

	public _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A()
	{
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020 = Guid.NewGuid().ToByteArray();
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A = new _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(this);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020 = _0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A;
	}

	public bool _0020_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020(string P_0)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020();
		_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020 = File.Open(P_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
		return _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020);
	}

	public bool _0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A(string P_0, string P_1)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020();
		_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020 = File.Open(P_0, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
		return _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020, P_1);
	}

	public void _0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020()
	{
		try
		{
			_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020?.Close();
		}
		catch
		{
		}
		_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A_0020 = null;
	}

	public void Dispose()
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020();
	}

	public void _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(Stream P_0)
	{
		byte[] bytes = Encoding.ASCII.GetBytes(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A);
		P_0.Write(bytes, 0, bytes.Length);
		P_0.WriteByte(1);
		P_0.WriteByte(_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020);
		P_0.Write(_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020, 0, 16);
		_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A obj = new _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A(P_0);
		long position = P_0.Position;
		BinaryWriter binaryWriter = new BinaryWriter(obj);
		binaryWriter.Write(0);
		long position2 = P_0.Position;
		using (Stream stream = (((_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 & 1) == 0) ? ((Stream)new _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A(obj)) : ((Stream)new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(obj, CompressionMode.Compress, leaveOpen: true))))
		{
			BinaryWriter binaryWriter2 = new BinaryWriter(stream);
			_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(binaryWriter2);
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(binaryWriter2);
			stream.Flush();
		}
		long position3 = P_0.Position;
		P_0.Position = position;
		binaryWriter.Write((int)(position3 - position2));
		P_0.Position = position3;
	}

	public bool _0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(Stream P_0, string P_1 = null)
	{
		_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A = P_1;
		_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();
		_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A = 0L;
		byte[] array = new byte[_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A.Length];
		P_0.Read(array, 0, array.Length);
		if (Encoding.ASCII.GetString(array) != _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A)
		{
			return false;
		}
		_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A = (byte)P_0.ReadByte();
		if (_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A == 1)
		{
			return _0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020(P_0);
		}
		return false;
	}

	internal bool _0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020(Stream P_0)
	{
		_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 = (byte)P_0.ReadByte();
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020 = new byte[16];
		P_0.Read(_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020, 0, _0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020.Length);
		_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020._0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020).ToLower();
		_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020 = new _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A();
		_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A obj = new _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A(P_0);
		int num = 0;
		using (BinaryReader binaryReader = new BinaryReader(obj))
		{
			num = binaryReader.ReadInt32();
		}
		_ = obj.Position;
		_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A obj2 = new _0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A(obj, obj.Position, num);
		using (Stream input = (((_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 & 1) == 0) ? ((Stream)new _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A(obj2)) : ((Stream)new _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(obj2, CompressionMode.Decompress, leaveOpen: true))))
		{
			BinaryReader binaryReader2 = new BinaryReader(input);
			_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(binaryReader2);
			try
			{
				_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(binaryReader2);
			}
			catch (Exception ex)
			{
				Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020 + obj.Position);
				Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A + obj.Length);
				Console.WriteLine(string.Concat(ex));
				return true;
			}
		}
		return true;
	}

	public void _0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(Stream P_0, bool P_1 = false)
	{
		using _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 obj = new _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(P_0);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020(obj, P_1);
		obj.Flush();
	}

	public override string ToString()
	{
		MemoryStream memoryStream = new MemoryStream();
		_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A(memoryStream);
		return Encoding.UTF8.GetString(memoryStream.ToArray());
	}

	internal _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(string P_0, object P_1)
	{
		_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A++;
		return new _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A(this, P_0)
		{
			_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = P_1
		};
	}

	internal void _0020_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A(string P_0)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, null);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020(string P_0, string P_1)
	{
		if (!string.IsNullOrEmpty(P_1))
		{
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
		}
	}

	internal void _0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A(string P_0, string P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string P_0, string P_1)
	{
		if (!string.IsNullOrEmpty(P_1))
		{
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
		}
	}

	public void _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string P_0, byte[] P_1)
	{
		if (P_1 != null)
		{
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
		}
	}

	public void _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string P_0, DateTime P_1)
	{
		P_1 = new DateTime(P_1.ToUniversalTime().Ticks, DateTimeKind.Unspecified).AddHours(_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020);
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_0020(string P_0, DateTime P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	internal void _0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_000A(string P_0, DateTime P_1)
	{
		P_1 = new DateTime(P_1.ToUniversalTime().Ticks, DateTimeKind.Unspecified).AddHours(_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020);
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020(string P_0, decimal P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A(string P_0, int P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020(string P_0, long P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A(string P_0, ulong P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string P_0, bool P_1)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020(string P_0, object P_1)
	{
		if (P_1 != null)
		{
			_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, P_1);
			_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
		}
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_000A(string P_0)
	{
	}

	internal void _0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020(string P_0)
	{
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, null);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
	}

	public IDisposable _0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(string P_0)
	{
		_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(P_0);
		return new _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020(this, P_0);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020(string P_0)
	{
		_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A.Push(_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020);
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020(P_0, null);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020(obj);
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020 = obj;
		_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020++;
		_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A.Push(P_0);
	}

	internal void _0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A()
	{
		_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(null);
	}

	public void _0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A(string P_0)
	{
		if (_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020 == 0)
		{
			throw new Exception(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A);
		}
		string text = _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A.Pop();
		_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020 = _0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A.Pop();
		_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_0020--;
		if (string.IsNullOrEmpty(P_0))
		{
			P_0 = text;
		}
		else if (P_0 != text)
		{
			throw new Exception(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 + P_0 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A + text);
		}
	}

	public static bool _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020()
	{
		_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020();
		_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020();
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020();
		try
		{
			bool flag = true;
			_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(1, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(2, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A, new byte[5] { 1, 2, 3, 4, 5 });
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020, new byte[1000]);
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A, new byte[10000]);
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020, new byte[100000]);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(3, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020);
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A, new string('T', 100));
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020, new string('3', 1000));
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A, new string('4', 10000));
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020, new string('5', 100000));
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(4, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A, 123);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(5, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A, DateTime.UtcNow);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(6, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020, 1.5m);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(7, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			obj._0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 = 1;
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A, new byte[5] { 1, 2, 3, 4, 5 });
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A, new byte[1000]);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(9, obj))
			{
				flag = false;
			}
			obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			obj._0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020 = 1;
			using (obj._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020))
			{
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A, new byte[5] { 1, 2, 3, 4, 5 });
				obj._0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A, new byte[1000]);
			}
			if (!_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(11, obj))
			{
				flag = false;
			}
			if (flag)
			{
				Console.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A);
				return true;
			}
			Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020);
			return false;
		}
		catch (Exception ex)
		{
			Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A + ex);
			return false;
		}
	}

	[CompilerGenerated]
	internal static bool _0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020(int P_0, _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A P_1)
	{
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			P_1._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A(memoryStream);
			byte[] buffer = memoryStream.ToArray();
			string text = P_1.ToString();
			_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A obj = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			MemoryStream memoryStream2 = new MemoryStream(buffer);
			obj._0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_0020(memoryStream2);
			string text2 = obj.ToString();
			if (text != text2)
			{
				Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 + P_0);
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			Console.Error.WriteLine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A + P_0 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + ex);
			return false;
		}
	}
}
internal class _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A
{
	internal class _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A : HashAlgorithm
	{
		internal const uint _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_0020 = 3988292384u;

		internal const uint _0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A = uint.MaxValue;

		private uint _0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020;

		private uint _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;

		private uint[] _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		private static uint[] _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020;

		public override int HashSize => 32;

		internal _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A()
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(3988292384u);
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = uint.MaxValue;
			Initialize();
		}

		internal _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A(uint polynomial, uint seed)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(polynomial);
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = seed;
			Initialize();
		}

		public override void Initialize()
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
		}

		protected override void HashCore(byte[] buffer, int start, int length)
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A, _0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020, buffer, start, length);
		}

		protected override byte[] HashFinal()
		{
			return HashValue = _0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(~_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020);
		}

		internal static uint _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(byte[] P_0)
		{
			return ~_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(3988292384u), uint.MaxValue, P_0, 0, P_0.Length);
		}

		internal static uint _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(uint[] P_0)
		{
			MemoryStream memoryStream = new MemoryStream();
			foreach (uint value in P_0)
			{
				memoryStream.Write(BitConverter.GetBytes(value), 0, 4);
			}
			byte[] array = memoryStream.ToArray();
			return ~_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(3988292384u), uint.MaxValue, array, 0, array.Length);
		}

		internal static uint _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(string P_0)
		{
			if (P_0 == null || string.IsNullOrEmpty(P_0))
			{
				return 0u;
			}
			return _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(Encoding.UTF8.GetBytes(P_0));
		}

		internal static uint _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(uint P_0, byte[] P_1)
		{
			return ~_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(3988292384u), P_0, P_1, 0, P_1.Length);
		}

		internal static uint _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(uint P_0, uint P_1, byte[] P_2)
		{
			return ~_0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(_0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(P_0), P_1, P_2, 0, P_2.Length);
		}

		private static uint[] _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(uint P_0)
		{
			if (P_0 == 3988292384u && _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020 != null)
			{
				return _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020;
			}
			uint[] array = new uint[256];
			for (int i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ P_0));
				}
				array[i] = num;
			}
			if (P_0 == 3988292384u)
			{
				_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_0020 = array;
			}
			return array;
		}

		private static uint _0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A(uint[] P_0, uint P_1, byte[] P_2, int P_3, int P_4)
		{
			uint num = P_1;
			for (int i = P_3; i < P_4; i++)
			{
				num = (num >> 8) ^ P_0[P_2[i] ^ (num & 0xFF)];
			}
			return num;
		}

		private byte[] _0020_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020(uint P_0)
		{
			return new byte[4]
			{
				(byte)((P_0 >> 24) & 0xFF),
				(byte)((P_0 >> 16) & 0xFF),
				(byte)((P_0 >> 8) & 0xFF),
				(byte)(P_0 & 0xFF)
			};
		}
	}

	internal class _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A : HashAlgorithm
	{
		public const ulong DefaultSeed = 0uL;

		private readonly ulong[] _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;

		private readonly ulong _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;

		private ulong _0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020;

		public override int HashSize => 64;

		public _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A(ulong polynomial)
			: this(polynomial, 0uL)
		{
		}

		public _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A(ulong polynomial, ulong seed)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(polynomial);
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A = (_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = seed);
		}

		public override void Initialize()
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A;
		}

		protected override void HashCore(byte[] array, int ibStart, int cbSize)
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020 = CalculateHash(_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020, _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A, array, ibStart, cbSize);
		}

		protected override byte[] HashFinal()
		{
			return HashValue = _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020(_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020);
		}

		protected static ulong CalculateHash(ulong seed, ulong[] table, IList<byte> buffer, int start, int size)
		{
			ulong num = seed;
			for (int i = start; i < start + size; i++)
			{
				num = (num >> 8) ^ table[(buffer[i] ^ num) & 0xFF];
			}
			return num;
		}

		private static byte[] _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020(ulong P_0)
		{
			byte[] bytes = BitConverter.GetBytes(P_0);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		private static ulong[] _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020(ulong P_0)
		{
			if (P_0 == 15564440312192434176uL && _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A != null)
			{
				return _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;
			}
			ulong[] array = CreateTable(P_0);
			if (P_0 == 15564440312192434176uL)
			{
				_0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = array;
			}
			return array;
		}

		protected static ulong[] CreateTable(ulong polynomial)
		{
			ulong[] array = new ulong[256];
			for (int i = 0; i < 256; i++)
			{
				ulong num = (ulong)i;
				for (int j = 0; j < 8; j++)
				{
					num = (((num & 1) != 1) ? (num >> 1) : ((num >> 1) ^ polynomial));
				}
				array[i] = num;
			}
			return array;
		}
	}

	internal class _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020 : _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A
	{
		internal static ulong[] _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A;

		public const ulong Iso3309Polynomial = 15564440312192434176uL;

		public _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020()
			: base(15564440312192434176uL)
		{
		}

		public _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020(ulong seed)
			: base(15564440312192434176uL, seed)
		{
		}

		public static ulong Compute(byte[] buffer)
		{
			return Compute(0uL, buffer);
		}

		internal static ulong _0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(string P_0)
		{
			if (P_0 == null || string.IsNullOrEmpty(P_0))
			{
				return 0uL;
			}
			return Compute(Encoding.UTF8.GetBytes(P_0));
		}

		public static ulong Compute(ulong seed, byte[] buffer)
		{
			if (_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A == null)
			{
				_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A = _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A.CreateTable(15564440312192434176uL);
			}
			return _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A.CalculateHash(seed, _0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A, buffer, 0, buffer.Length);
		}
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A(string P_0)
	{
		return true;
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020()
	{
		return CultureInfo.CurrentCulture.Name.Split('-')[0];
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020(string P_0)
	{
		return false;
	}

	internal static int _0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A(string P_0)
	{
		return 0;
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A(int P_0)
	{
		return string.Concat(P_0);
	}

	internal static string[] _0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A()
	{
		return new string[0];
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020(string P_0)
	{
		return P_0;
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020(string P_0)
	{
		return P_0;
	}

	internal static uint _0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A(string P_0)
	{
		return _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(P_0);
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020(string P_0)
	{
		return _0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(P_0).ToString();
	}

	internal static ulong _0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A(string P_0)
	{
		return _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020._0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(P_0);
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020(string P_0)
	{
		return _0020_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020._0020_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A(P_0).ToString();
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_000A(string P_0)
	{
		return P_0;
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020(string P_0)
	{
		return P_0;
	}

	internal static string _0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A(string P_0)
	{
		return P_0;
	}

	internal static object _0020_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020(string P_0, params object[] args)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(null, null, null, P_0, args);
	}

	internal static object _0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A(object P_0, string P_1, params object[] args)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(null, P_0, null, P_1, args);
	}

	internal static object _0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(Type P_0, object P_1, string P_2, string P_3, params object[] args)
	{
		P_0 = null;
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				P_0 = P_1.GetType();
			}
			if (P_2 != null)
			{
				P_0 = Type.GetType(P_2, throwOnError: false);
			}
			if (P_0 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				_ = method.Name;
				P_0 = method.DeclaringType;
				if (P_0 == null)
				{
					return null;
				}
			}
		}
		MethodInfo method2 = P_0.GetMethod(P_3, (BindingFlags)(((P_1 == null) ? 8 : 12) | 0x10 | 0x20));
		return method2?.Invoke(method2.IsStatic ? null : P_1, args);
	}

	internal static object _0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A(Type P_0, object P_1, string P_2, string P_3)
	{
		P_0 = null;
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				P_0 = P_1.GetType();
			}
			if (P_2 != null)
			{
				P_0 = Type.GetType(P_2, throwOnError: false);
			}
			if (P_0 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				_ = method.Name;
				P_0 = method.DeclaringType;
				if (P_0 == null)
				{
					return null;
				}
			}
		}
		FieldInfo field = P_0.GetField(P_3, (BindingFlags)(((P_1 == null) ? 8 : 12) | 0x10 | 0x20));
		return field?.GetValue(field.IsStatic ? null : P_1);
	}

	internal static bool _0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020(Type P_0, object P_1, string P_2, string P_3, object P_4)
	{
		P_0 = null;
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				P_0 = P_1.GetType();
			}
			if (P_2 != null)
			{
				P_0 = Type.GetType(P_2, throwOnError: false);
			}
			if (P_0 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				_ = method.Name;
				P_0 = method.DeclaringType;
				if (P_0 == null)
				{
					return false;
				}
			}
		}
		FieldInfo field = P_0.GetField(P_3, (BindingFlags)(((P_1 == null) ? 8 : 12) | 0x10 | 0x20));
		if (field == null)
		{
			return false;
		}
		field.SetValue(field.IsStatic ? null : P_1, P_4);
		return true;
	}

	internal static object _0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A(Type P_0, object P_1, string P_2, string P_3)
	{
		P_0 = null;
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				P_0 = P_1.GetType();
			}
			if (P_2 != null)
			{
				P_0 = Type.GetType(P_2, throwOnError: false);
			}
			if (P_0 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				_ = method.Name;
				P_0 = method.DeclaringType;
				if (P_0 == null)
				{
					return null;
				}
			}
		}
		PropertyInfo property = P_0.GetProperty(P_3, (BindingFlags)(((P_1 == null) ? 8 : 12) | 0x10 | 0x20));
		return property?.GetValue((property.GetGetMethod() != null && property.GetGetMethod().IsStatic) ? null : P_1, null);
	}

	internal static bool _0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020(Type P_0, object P_1, string P_2, string P_3, object P_4)
	{
		P_0 = null;
		if (P_0 == null)
		{
			if (P_1 != null)
			{
				P_0 = P_1.GetType();
			}
			if (P_2 != null)
			{
				P_0 = Type.GetType(P_2, throwOnError: false);
			}
			if (P_0 == null)
			{
				MethodBase method = new StackTrace().GetFrames()[1].GetMethod();
				_ = method.Name;
				P_0 = method.DeclaringType;
				if (P_0 == null)
				{
					return false;
				}
			}
		}
		PropertyInfo property = P_0.GetProperty(P_3, (BindingFlags)(((P_1 == null) ? 8 : 12) | 0x10 | 0x20));
		if (property == null)
		{
			return false;
		}
		property.SetValue((property.GetSetMethod() != null && property.GetSetMethod().IsStatic) ? null : P_1, P_4, new object[0]);
		return true;
	}
}
internal static class _0020_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020
{
	internal static object _0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_00601<_0020_0020>(this _0020_0020 P_0, string P_1, params object[] args)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020(null, P_0, null, P_1, args);
	}

	internal static object _0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_00601<_0020_0020>(this _0020_0020 P_0, string P_1)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_000A(null, P_0, null, P_1);
	}

	internal static object _0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_00601<_0020_000A_000A>(this _0020_000A_000A P_0, string P_1, object P_2)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020(null, P_0, null, P_1, P_2);
	}

	internal static object _0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_00601<_0020_0020>(this _0020_0020 P_0, string P_1)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A(null, P_0, null, P_1);
	}

	internal static object _0020_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_00601<_0020_000A_000A>(this _0020_000A_000A P_0, string P_1, object P_2)
	{
		return _0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A._0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_0020(null, P_0, null, P_1, P_2);
	}
}
internal static class _0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020
{
	private static string[] _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020;

	private static Random _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A = new Random((int)DateTime.Now.Ticks);

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020(decimal P_0)
	{
		return Math.Floor(P_0 * 100m) / 100m;
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A(decimal P_0)
	{
		return Math.Round(P_0, 2, MidpointRounding.AwayFromZero);
	}

	internal static string _0020_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020(decimal P_0)
	{
		return string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A, P_0).Trim();
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A(params decimal[] list)
	{
		foreach (decimal num in list)
		{
			if (num != 0m)
			{
				return num;
			}
		}
		return 0m;
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020(params decimal[] list)
	{
		foreach (decimal num in list)
		{
			if (num > 0m)
			{
				return num;
			}
		}
		return 0m;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A(object P_0, object P_1)
	{
		if (P_0 == null || P_0 == DBNull.Value || P_1 == null || P_1 == DBNull.Value)
		{
			return false;
		}
		if (P_0.Equals(P_1))
		{
			return true;
		}
		long num = 0L;
		long num2 = 0L;
		if (P_0 is string)
		{
			num = (long)(_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A((string)P_0) * 100m);
		}
		if (P_0 is decimal)
		{
			num = (long)((decimal)P_0 * 100m);
		}
		if (P_0 is float)
		{
			num = (long)((float)P_0 * 100f);
		}
		if (P_0 is double)
		{
			num = (long)((double)P_0 * 100.0);
		}
		if (P_0 is int)
		{
			num = (long)P_0 * 100;
		}
		if (P_1 is string)
		{
			num2 = (long)(_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A((string)P_1) * 100m);
		}
		if (P_1 is decimal)
		{
			num2 = (long)((decimal)P_1 * 100m);
		}
		if (P_1 is float)
		{
			num2 = (long)((float)P_1 * 100f);
		}
		if (P_1 is double)
		{
			num2 = (long)((double)P_1 * 100.0);
		}
		if (P_1 is int)
		{
			num2 = (long)P_1 * 100;
		}
		return num == num2;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020(object P_0)
	{
		if (P_0 == null || P_0 == DBNull.Value)
		{
			return true;
		}
		long num = 0L;
		if (P_0 is string)
		{
			num = (long)(_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A((string)P_0) * 100m);
		}
		if (P_0 is decimal)
		{
			num = (long)((decimal)P_0 * 100m);
		}
		if (P_0 is float)
		{
			num = (long)((float)P_0 * 100f);
		}
		if (P_0 is double)
		{
			num = (long)((double)P_0 * 100.0);
		}
		if (P_0 is int)
		{
			num = (long)P_0 * 100;
		}
		return num == 0;
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A(string P_0)
	{
		try
		{
			P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "").Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "").Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "")
				.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A)
				.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A, CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
			return decimal.Parse(P_0, NumberStyles.Any);
		}
		catch
		{
			try
			{
				return decimal.Parse(P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_0020), NumberStyles.Any);
			}
			catch
			{
				try
				{
					return decimal.Parse(P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A), NumberStyles.Any);
				}
				catch (Exception innerException)
				{
					throw new Exception(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 + P_0, innerException);
				}
			}
		}
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(string P_0)
	{
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(P_0, 0m);
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(string P_0, decimal P_1)
	{
		decimal result = 0m;
		if (!_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(P_0, out result))
		{
			return P_1;
		}
		return result;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(string P_0, out decimal P_1)
	{
		P_1 = 0m;
		try
		{
			P_1 = _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A(P_0);
			return true;
		}
		catch
		{
			return false;
		}
	}

	internal static int _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(string P_0)
	{
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0, 0);
	}

	internal static bool _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(string P_0, out int P_1)
	{
		P_1 = 0;
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "");
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "");
		if (P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A) || P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020))
		{
			try
			{
				bool flag = P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A);
				P_0 = P_0.TrimStart('-');
				P_0 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A + P_0.Substring(2);
				P_0 = P_0.Substring(P_0.Length - 8);
				P_1 = BitConverter.ToInt32(_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(P_0, _0020_000A: true), 0);
				if (flag)
				{
					P_1 = -P_1;
				}
				return true;
			}
			catch
			{
			}
		}
		if (int.TryParse(P_0, out P_1))
		{
			return true;
		}
		return false;
	}

	internal static int _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(string P_0, int P_1)
	{
		int result = 0;
		if (string.IsNullOrEmpty(P_0))
		{
			return P_1;
		}
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "");
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "");
		if (P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A) || P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020))
		{
			try
			{
				bool flag = P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A);
				P_0 = P_0.TrimStart('-');
				P_0 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A + P_0.Substring(2);
				P_0 = P_0.Substring(P_0.Length - 8);
				result = BitConverter.ToInt32(_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(P_0, _0020_000A: true), 0);
				if (flag)
				{
					result = -result;
				}
				return result;
			}
			catch
			{
			}
		}
		if (int.TryParse(P_0, out result))
		{
			return result;
		}
		return P_1;
	}

	internal static long _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(string P_0)
	{
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(P_0, 0L);
	}

	internal static bool _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(string P_0, out long P_1)
	{
		P_1 = 0L;
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "");
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "");
		if (P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A) || P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020))
		{
			try
			{
				bool flag = P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A);
				P_0 = P_0.TrimStart('-');
				P_0 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 + P_0.Substring(2);
				P_0 = P_0.Substring(P_0.Length - 16);
				P_1 = BitConverter.ToInt64(_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(P_0, _0020_000A: true), 0);
				if (flag)
				{
					P_1 = -P_1;
				}
				return true;
			}
			catch
			{
			}
		}
		if (long.TryParse(P_0, out P_1))
		{
			return true;
		}
		return false;
	}

	internal static long _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(string P_0, long P_1)
	{
		long result = 0L;
		if (string.IsNullOrEmpty(P_0))
		{
			return P_1;
		}
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "");
		P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "");
		if (P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A) || P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020))
		{
			try
			{
				bool flag = P_0.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A);
				P_0 = P_0.TrimStart('-');
				P_0 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 + P_0.Substring(2);
				P_0 = P_0.Substring(P_0.Length - 16);
				result = BitConverter.ToInt64(_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(P_0, _0020_000A: true), 0);
				if (flag)
				{
					result = -result;
				}
				return result;
			}
			catch
			{
			}
		}
		if (long.TryParse(P_0, out result))
		{
			return result;
		}
		return P_1;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(string P_0)
	{
		return _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(P_0, _0020_000A: false);
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(string P_0, out bool P_1)
	{
		P_1 = false;
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		P_0 = P_0.ToLower();
		if (P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020 || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020 || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020)
		{
			P_1 = true;
			return true;
		}
		if (P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020 || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020 || P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A)
		{
			P_1 = false;
			return true;
		}
		return false;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(string P_0, bool P_1)
	{
		bool result = false;
		if (string.IsNullOrEmpty(P_0))
		{
			return P_1;
		}
		if (_0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A(P_0, out result))
		{
			return result;
		}
		return P_1;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020(int P_0, int P_1)
	{
		if ((P_0 & (1 << P_1)) != 0)
		{
			return true;
		}
		return false;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020(long P_0, int P_1)
	{
		if ((P_0 & (1L << P_1)) != 0L)
		{
			return true;
		}
		return false;
	}

	internal static int _0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A(int P_0, int P_1, bool P_2)
	{
		P_0 &= ~(1 << P_1);
		if (P_2)
		{
			P_0 |= 1 << P_1;
		}
		return P_0;
	}

	internal static long _0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A(long P_0, int P_1, bool P_2)
	{
		P_0 &= ~(1L << P_1);
		if (P_2)
		{
			P_0 |= 1L << P_1;
		}
		return P_0;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020(byte[] P_0, byte[] P_1)
	{
		if (P_0 == null || P_1 == null || P_0.Length < P_1.Length)
		{
			return false;
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			if (P_0[i] != P_1[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static bool _0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A(byte[] P_0, byte[] P_1)
	{
		if (P_0 == null || P_1 == null || P_0.Length != P_1.Length)
		{
			return false;
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			if (P_0[i] != P_1[i])
			{
				return false;
			}
		}
		return true;
	}

	internal static byte[] _0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020(byte[] P_0, byte[] P_1)
	{
		byte[] array = new byte[P_0.Length + P_1.Length];
		int num = 0;
		for (int i = 0; i < P_0.Length; i++)
		{
			array[num] = P_0[i];
			num++;
		}
		for (int j = 0; j < P_1.Length; j++)
		{
			array[num] = P_1[j];
			num++;
		}
		return array;
	}

	internal static byte[] _0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(byte[] P_0, int P_1)
	{
		return _0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(P_0, P_1, P_0.Length - P_1);
	}

	internal static byte[] _0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_000A(byte[] P_0, int P_1, int P_2)
	{
		byte[] array = new byte[P_2];
		if (P_2 < 0)
		{
			P_2 = P_0.Length - P_1;
		}
		for (int i = 0; i < P_2; i++)
		{
			array[i] = P_0[i + P_1];
		}
		return array;
	}

	internal static int _0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020(byte[] P_0, byte[] P_1, int P_2 = 0, int P_3 = -1)
	{
		if (P_0 == null || P_1 == null)
		{
			return -1;
		}
		if (P_2 + P_1.Length >= P_0.Length)
		{
			return -1;
		}
		if (P_2 < 0)
		{
			P_2 = 0;
		}
		for (int i = P_2; i < P_0.Length - P_1.Length && (P_3 <= 0 || i <= P_3); i++)
		{
			bool flag = true;
			for (int j = 0; j < P_1.Length; j++)
			{
				if (P_1[j] != P_0[i + j])
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return i;
			}
		}
		return -1;
	}

	public static byte[] Revert(byte[] buff)
	{
		if (buff == null)
		{
			return null;
		}
		if (buff.Length == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[buff.Length];
		for (int i = 0; i < buff.Length; i++)
		{
			array[buff.Length - i - 1] = buff[i];
		}
		return array;
	}

	internal static string _0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A(byte[] P_0, bool P_1 = false, int P_2 = 4, int P_3 = 0, int P_4 = -1)
	{
		if (_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020 == null)
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020 = new string[256];
			for (int i = 0; i < 256; i++)
			{
				_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020[i] = string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020, i);
			}
		}
		StringBuilder stringBuilder = new StringBuilder(P_0.Length * 2);
		P_4 = ((P_4 >= 0) ? Math.Min(P_4, P_0.Length - P_3) : (P_0.Length - P_3));
		for (int j = P_3; j < P_4; j++)
		{
			stringBuilder.Append(_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020[P_0[j]]);
		}
		string text = stringBuilder.ToString();
		if (P_1)
		{
			string text2 = text;
			string text3 = "";
			for (int k = 0; k < text.Length; k += P_2)
			{
				if (!string.IsNullOrEmpty(text3))
				{
					text3 += _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A;
				}
				text3 += text2.Substring(0, Math.Min(P_2, text2.Length));
				text2 = text2.Remove(0, Math.Min(P_2, text2.Length));
			}
			if (text2.Length > 0)
			{
				text3 += text2.Substring(0, Math.Min(4, text2.Length));
				text2 = text2.Remove(0, Math.Min(P_2, text2.Length));
			}
			text = text3;
		}
		return text;
	}

	internal static byte[] _0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_0020(string P_0, bool P_1 = false)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (P_0.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A))
		{
			P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A, "").Trim();
		}
		if (P_0.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020))
		{
			P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020, "").Trim();
		}
		if (P_0.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020))
		{
			P_0 = P_0.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020, "").Trim();
		}
		if ((P_0.Length & 1) != 0)
		{
			return null;
		}
		byte[] array = new byte[P_0.Length / 2];
		for (int i = 0; i < P_0.Length; i += 2)
		{
			if (!byte.TryParse(P_0.Substring(i, 2), NumberStyles.HexNumber, null, out var result))
			{
				return null;
			}
			if (P_1)
			{
				array[array.Length - 1 - i / 2] = result;
			}
			else
			{
				array[i / 2] = result;
			}
		}
		return array;
	}

	internal static int _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A(int P_0 = int.MaxValue)
	{
		return _0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A.Next(P_0);
	}

	internal static float _0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020(object P_0)
	{
		if (P_0 == null)
		{
			return 0f;
		}
		if (P_0 is float)
		{
			return (float)P_0;
		}
		if (P_0 is double)
		{
			return (float)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (float)(decimal)P_0;
		}
		if (P_0 is long)
		{
			return (long)P_0;
		}
		if (P_0 is ulong)
		{
			return (ulong)P_0;
		}
		if (P_0 is int)
		{
			return (int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is byte)
		{
			return (int)(byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (int)(ushort)P_0;
		}
		if (P_0 is char)
		{
			return (int)(char)P_0;
		}
		if (P_0 is bool)
		{
			return ((bool)P_0) ? 1 : 0;
		}
		if (P_0 is string)
		{
			return (float)_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020((string)P_0);
		}
		return (float)_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(P_0.ToString());
	}

	internal static double _0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_000A(object P_0)
	{
		if (P_0 == null)
		{
			return 0.0;
		}
		if (P_0 is float)
		{
			return (float)P_0;
		}
		if (P_0 is double)
		{
			return (double)P_0;
		}
		if (P_0 is decimal)
		{
			return (double)(decimal)P_0;
		}
		if (P_0 is long)
		{
			return (long)P_0;
		}
		if (P_0 is ulong)
		{
			return (ulong)P_0;
		}
		if (P_0 is int)
		{
			return (int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is byte)
		{
			return (int)(byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (int)(ushort)P_0;
		}
		if (P_0 is char)
		{
			return (int)(char)P_0;
		}
		if (P_0 is bool)
		{
			return ((bool)P_0) ? 1 : 0;
		}
		if (P_0 is string)
		{
			return (double)_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020((string)P_0);
		}
		return (double)_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(P_0.ToString());
	}

	internal static decimal _0020_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020(object P_0)
	{
		if (P_0 == null)
		{
			return 0m;
		}
		if (P_0 is float)
		{
			return (decimal)(float)P_0;
		}
		if (P_0 is double)
		{
			return (decimal)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (decimal)P_0;
		}
		if (P_0 is ulong)
		{
			return (ulong)P_0;
		}
		if (P_0 is long)
		{
			return (long)P_0;
		}
		if (P_0 is int)
		{
			return (int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			return ((bool)P_0) ? 1 : 0;
		}
		if (P_0 is string)
		{
			return _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020((string)P_0);
		}
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020(P_0.ToString());
	}

	internal static long _0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A(object P_0)
	{
		if (P_0 == null)
		{
			return 0L;
		}
		if (P_0 is long)
		{
			return (long)P_0;
		}
		if (P_0 is ulong)
		{
			return (long)(ulong)P_0;
		}
		if (P_0 is int)
		{
			return (int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is float)
		{
			return (long)(float)P_0;
		}
		if (P_0 is double)
		{
			return (long)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (long)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			return ((bool)P_0) ? 1 : 0;
		}
		if (P_0 is string)
		{
			return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020((string)P_0);
		}
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(P_0.ToString());
	}

	internal static ulong _0020_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020(object P_0)
	{
		if (P_0 == null)
		{
			return 0uL;
		}
		if (P_0 is string)
		{
			return (ulong)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020((string)P_0);
		}
		if (P_0 is long)
		{
			return (ulong)(long)P_0;
		}
		if (P_0 is ulong)
		{
			return (ulong)P_0;
		}
		if (P_0 is int)
		{
			return (ulong)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is float)
		{
			return (ulong)(float)P_0;
		}
		if (P_0 is double)
		{
			return (ulong)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (ulong)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (ulong)(sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (ulong)(short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			return (ulong)(int)(((bool)P_0) ? 1u : 0u);
		}
		return (ulong)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020(P_0.ToString());
	}

	internal static int _0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A(object P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		if (P_0 is int)
		{
			return (int)P_0;
		}
		if (P_0 is uint)
		{
			return (int)(uint)P_0;
		}
		if (P_0 is string)
		{
			return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A((string)P_0);
		}
		if (P_0 is ulong)
		{
			return (int)(ulong)P_0;
		}
		if (P_0 is long)
		{
			return (int)(long)P_0;
		}
		if (P_0 is float)
		{
			return (int)(float)P_0;
		}
		if (P_0 is double)
		{
			return (int)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (int)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			if (!(bool)P_0)
			{
				return 0;
			}
			return 1;
		}
		return _0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0.ToString());
	}

	internal static uint _0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020(object P_0)
	{
		if (P_0 == null)
		{
			return 0u;
		}
		if (P_0 is int)
		{
			return (uint)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0;
		}
		if (P_0 is string)
		{
			return (uint)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A((string)P_0);
		}
		if (P_0 is ulong)
		{
			return (uint)(ulong)P_0;
		}
		if (P_0 is long)
		{
			return (uint)(long)P_0;
		}
		if (P_0 is float)
		{
			return (uint)(float)P_0;
		}
		if (P_0 is double)
		{
			return (uint)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (uint)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (uint)(sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (uint)(short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			if (!(bool)P_0)
			{
				return 0u;
			}
			return 1u;
		}
		return (uint)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0.ToString());
	}

	internal static short _0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A(object P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		if (P_0 is short)
		{
			return (short)P_0;
		}
		if (P_0 is ushort)
		{
			return (short)(ushort)P_0;
		}
		if (P_0 is string)
		{
			return (short)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A((string)P_0);
		}
		if (P_0 is long)
		{
			return (short)(long)P_0;
		}
		if (P_0 is ulong)
		{
			return (short)(ulong)P_0;
		}
		if (P_0 is int)
		{
			return (short)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (short)(uint)P_0;
		}
		if (P_0 is float)
		{
			return (short)(float)P_0;
		}
		if (P_0 is double)
		{
			return (short)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (short)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0;
		}
		if (P_0 is char)
		{
			return (short)(char)P_0;
		}
		if (P_0 is bool)
		{
			return (short)(((bool)P_0) ? 1 : 0);
		}
		return (short)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0.ToString());
	}

	internal static ushort _0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020(object P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		if (P_0 is string)
		{
			return (ushort)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A((string)P_0);
		}
		if (P_0 is long)
		{
			return (ushort)(long)P_0;
		}
		if (P_0 is ulong)
		{
			return (ushort)(ulong)P_0;
		}
		if (P_0 is int)
		{
			return (ushort)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (ushort)(uint)P_0;
		}
		if (P_0 is float)
		{
			return (ushort)(float)P_0;
		}
		if (P_0 is double)
		{
			return (ushort)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (ushort)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (ushort)(sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (ushort)(short)P_0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			return (ushort)(((bool)P_0) ? 1u : 0u);
		}
		return (ushort)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0.ToString());
	}

	internal static byte _0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A(object P_0)
	{
		if (P_0 == null)
		{
			return 0;
		}
		if (P_0 is string)
		{
			return (byte)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A((string)P_0);
		}
		if (P_0 is long)
		{
			return (byte)(long)P_0;
		}
		if (P_0 is ulong)
		{
			return (byte)(ulong)P_0;
		}
		if (P_0 is int)
		{
			return (byte)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (byte)(uint)P_0;
		}
		if (P_0 is float)
		{
			return (byte)(float)P_0;
		}
		if (P_0 is double)
		{
			return (byte)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (byte)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (byte)(sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (byte)(short)P_0;
		}
		if (P_0 is ushort)
		{
			return (byte)(ushort)P_0;
		}
		if (P_0 is char)
		{
			return (byte)(char)P_0;
		}
		if (P_0 is bool)
		{
			return (byte)(((bool)P_0) ? 1u : 0u);
		}
		return (byte)_0020_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A(P_0.ToString());
	}

	internal static bool _0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is string)
		{
			if (!((string)P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020) && !((string)P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A))
			{
				return (string)P_0 == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A;
			}
			return true;
		}
		if (P_0 is long)
		{
			return (int)(long)P_0 != 0;
		}
		if (P_0 is ulong)
		{
			return (int)(ulong)P_0 != 0;
		}
		if (P_0 is int)
		{
			return (int)P_0 != 0;
		}
		if (P_0 is uint)
		{
			return (uint)P_0 != 0;
		}
		if (P_0 is float)
		{
			return (int)(float)P_0 >= 1;
		}
		if (P_0 is double)
		{
			return (int)(double)P_0 >= 1;
		}
		if (P_0 is decimal)
		{
			return (int)(decimal)P_0 >= 1;
		}
		if (P_0 is byte)
		{
			return (byte)P_0 != 0;
		}
		if (P_0 is sbyte)
		{
			return (sbyte)P_0 != 0;
		}
		if (P_0 is short)
		{
			return (short)P_0 != 0;
		}
		if (P_0 is ushort)
		{
			return (ushort)P_0 != 0;
		}
		if (P_0 is char)
		{
			return (char)P_0 != '\0';
		}
		if (P_0 is bool)
		{
			return (bool)P_0;
		}
		if (P_0 is Array array)
		{
			if (array != null)
			{
				return array.Length > 0;
			}
			return false;
		}
		if (P_0 is List<object> list)
		{
			if (list != null)
			{
				return list.Count > 0;
			}
			return false;
		}
		string text = P_0.ToString();
		if (!(text == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020) && !(text == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A))
		{
			return text == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A;
		}
		return true;
	}

	internal static char _0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A(object P_0)
	{
		if (P_0 == null)
		{
			return '\0';
		}
		if (P_0 is string)
		{
			if (((string)P_0).Length <= 0)
			{
				return '\0';
			}
			return ((string)P_0)[0];
		}
		if (P_0 is long)
		{
			return (char)(long)P_0;
		}
		if (P_0 is ulong)
		{
			return (char)(ulong)P_0;
		}
		if (P_0 is int)
		{
			return (char)(int)P_0;
		}
		if (P_0 is uint)
		{
			return (char)(uint)P_0;
		}
		if (P_0 is float)
		{
			return (char)(float)P_0;
		}
		if (P_0 is double)
		{
			return (char)(double)P_0;
		}
		if (P_0 is decimal)
		{
			return (char)(decimal)P_0;
		}
		if (P_0 is byte)
		{
			return (char)(byte)P_0;
		}
		if (P_0 is sbyte)
		{
			return (char)(sbyte)P_0;
		}
		if (P_0 is short)
		{
			return (char)(short)P_0;
		}
		if (P_0 is ushort)
		{
			return (char)(ushort)P_0;
		}
		if (P_0 is char)
		{
			return (char)P_0;
		}
		if (P_0 is bool)
		{
			return (char)(((bool)P_0) ? 1u : 0u);
		}
		return char.Parse(P_0.ToString());
	}
}
internal class _0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A : Stream
{
	private long _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A;

	private long _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020;

	private Stream _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;

	private long _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A;

	public override bool CanRead => true;

	public override bool CanSeek => true;

	public override bool CanWrite => true;

	public override long Length => _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020;

	public override long Position
	{
		get
		{
			return _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A;
		}
		set
		{
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A = value;
			_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Position = _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A + _0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A;
		}
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A(Stream input, long? begin, long? maxLength)
	{
		Reset(input, begin, maxLength);
	}

	internal void Reset(Stream input, long? _begin, long? _maxLength)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A = input;
		if (_begin.HasValue)
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A = _begin.Value;
		}
		else
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A = (int)input.Position;
		}
		if (!_maxLength.HasValue)
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020 = (int)input.Length - _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A;
		}
		else
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_0020 = Math.Min(input.Length - _0020_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A, _maxLength.Value);
		}
		Position = 0L;
	}

	public override void Close()
	{
		Flush();
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A = null;
	}

	internal void _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020(int P_0)
	{
		Position += P_0;
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		if (Position >= Length)
		{
			return 0;
		}
		int num = 0;
		_ = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;
		if (Position >= 0 && Position < Length)
		{
			Position = Position;
			int num2 = (int)Math.Min(count, Length - Position);
			_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Read(buffer, offset, num2);
			_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A += num2;
			offset += num2;
			count -= num2;
			num += num2;
		}
		return num;
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		if (Position < Length)
		{
			int num = 0;
			Stream stream = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;
			if (Position >= 0 && Position < Length)
			{
				Position = Position;
				int num2 = (int)Math.Min(count, Length - Position);
				stream.Write(buffer, offset, num2);
				_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A += num2;
				offset += num2;
				count -= num2;
				num += num2;
			}
		}
	}

	public override void Flush()
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		if (origin == SeekOrigin.Begin)
		{
			Position = offset;
		}
		if (origin == SeekOrigin.End)
		{
			Position = Length - offset;
		}
		if (origin == SeekOrigin.Current)
		{
			Position += offset;
		}
		return Position;
	}

	public override void SetLength(long value)
	{
	}
}
internal class _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A : Stream
{
	private Stream _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;

	public override bool CanRead => _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.CanRead;

	public override bool CanSeek => _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.CanSeek;

	public override bool CanWrite => _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.CanWrite;

	public override long Length => _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Length;

	public override long Position
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Position;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Position = value;
		}
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A(Stream input)
	{
		Reset(input);
	}

	internal void Reset(Stream input)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A = input;
	}

	public override void Close()
	{
	}

	public void CustomClose()
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A?.Close();
	}

	public override int Read(byte[] buffer, int offset, int count)
	{
		return _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Read(buffer, offset, count);
	}

	public override void Flush()
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		return _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Seek(offset, origin);
	}

	public override void SetLength(long value)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.SetLength(Length);
	}

	public override void Write(byte[] buffer, int offset, int count)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Write(buffer, offset, count);
	}

	protected override void Dispose(bool disposing)
	{
	}
}
internal class _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 : StreamWriter
{
	internal class _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 : IDisposable
	{
		internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A;

		internal int _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020;

		internal static _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 Start(_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 ow_stream, int padding = 1)
		{
			return new _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(ow_stream, padding);
		}

		internal _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020(_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 ow_stream, int padding = 1)
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A = ow_stream;
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A += padding;
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020 = padding;
		}

		public void Dispose()
		{
			_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_000A._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A -= _0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020;
		}
	}

	internal int _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A = 4;

	private int _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020;

	internal int _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A;

	private bool _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = true;

	public int Length => (int)base.BaseStream.Position;

	public _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020(Stream wr)
		: base(wr)
	{
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(string P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(char P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(int P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(float P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(bool P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(uint P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(long P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(double P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A(decimal P_0)
	{
		Write(P_0);
		return this;
	}

	internal _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 _0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020(string P_0, object P_1)
	{
		Write(string.Format(P_0, P_1));
		return this;
	}

	public _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 AppendLine(string s)
	{
		WriteLine(s);
		return this;
	}

	internal IDisposable _0020_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A(int P_0 = 1)
	{
		return _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020.Start(this, P_0);
	}

	public override void Write(string value)
	{
		if (value != null && value.Length > 0 && value.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020))
		{
			WriteLine(value.Substring(0, value.Length - 1));
			return;
		}
		if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020)
		{
			value = new string(' ', _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A * _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A) + value;
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = false;
		}
		if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A > 0 && value != null && value.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020))
		{
			value = value.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + new string(' ', _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A * _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A));
		}
		base.Write(value);
	}

	public override void WriteLine(string value)
	{
		if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020)
		{
			value = new string(' ', _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A * _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A) + value;
			_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = false;
		}
		if (_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A > 0 && value != null && value.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020))
		{
			value = value.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + new string(' ', _0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A * _0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A));
		}
		base.WriteLine(value);
		_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020 = true;
	}

	public override void Close()
	{
		Flush();
	}

	protected override void Dispose(bool disposing)
	{
	}
}
internal class _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A
{
	public struct DelayedQueueItem
	{
		public DateTime time;

		public Action action;
	}

	private class _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020
	{
		internal bool _0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A;

		internal bool _0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020;

		internal Action _0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A;

		internal Exception _0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020;

		internal void _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A()
		{
			try
			{
				_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A();
			}
			catch (Exception ex)
			{
				_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020 = ex;
			}
			finally
			{
				_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020 = true;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020
	{
		public static readonly _0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020 _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A = new _0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020();

		public static Func<DelayedQueueItem, bool> _0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_000A;

		internal bool _0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A(DelayedQueueItem P_0)
		{
			return P_0.time <= DateTime.Now;
		}
	}

	public int maxThreads = 100;

	internal volatile int _0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020;

	private int _0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A;

	private int? _0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020;

	private List<Action> _0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A = new List<Action>();

	private List<DelayedQueueItem> _0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020 = new List<DelayedQueueItem>();

	private List<DelayedQueueItem> _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A = new List<DelayedQueueItem>();

	private List<Action> _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new List<Action>();

	internal int _0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A => _0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020;

	internal int _0020_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 => _0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A.Count + _0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020.Count + _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A.Count + _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020.Count;

	internal void _0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(Action P_0)
	{
		_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(P_0, 0f);
	}

	internal void _0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(Action P_0, float P_1)
	{
		if (P_1 != 0f)
		{
			lock (_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020)
			{
				_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020.Add(new DelayedQueueItem
				{
					time = DateTime.Now.AddSeconds(P_1),
					action = P_0
				});
				return;
			}
		}
		lock (_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A)
		{
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A.Add(P_0);
		}
	}

	internal bool _0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020(Action P_0)
	{
		if (_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020.HasValue && _0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020.Value == Thread.CurrentThread.ManagedThreadId)
		{
			try
			{
				P_0();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 obj = new _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020();
		obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A = P_0;
		_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(obj._0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A);
		int num = 0;
		while (!obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020 && num < 1000000)
		{
			num++;
		}
		while (!obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020)
		{
			Thread.Sleep(1);
		}
		if (obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020 != null)
		{
			return false;
		}
		return true;
	}

	internal bool _0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(Action P_0)
	{
		if (_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020.HasValue && _0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020.Value == Thread.CurrentThread.ManagedThreadId)
		{
			try
			{
				P_0();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 obj = new _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020();
		obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A = P_0;
		_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A(obj._0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A);
		return true;
	}

	internal void _0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020(Action P_0)
	{
		_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 obj = new _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020();
		obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A = true;
		obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A = P_0;
		_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(obj._0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A);
	}

	internal bool _0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A(Action P_0, int P_1 = -1)
	{
		int millisecond = DateTime.Now.Millisecond;
		_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 obj = new _0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020();
		obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_000A = P_0;
		_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(obj._0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A);
		int num = 0;
		while (!obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020 && num < 10000)
		{
			num++;
		}
		while (!obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020 && (P_1 < 0 || DateTime.Now.Millisecond - millisecond < P_1))
		{
			Thread.Sleep(1);
		}
		if (!obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020 || obj._0020_000A_0020_0020_000A_0020_0020_000A_0020_0020_0020 != null)
		{
			return false;
		}
		return true;
	}

	internal Thread _0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(Action P_0)
	{
		lock (this)
		{
			Interlocked.Increment(ref _0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020);
		}
		ThreadPool.UnsafeQueueUserWorkItem(_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020, P_0);
		return null;
	}

	private void _0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020(object P_0)
	{
		try
		{
			((Action)P_0)();
		}
		catch (Exception)
		{
		}
		finally
		{
			lock (this)
			{
				Interlocked.Decrement(ref _0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020);
			}
		}
	}

	internal void _0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020()
	{
		if (!_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020.HasValue)
		{
			_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020 = Thread.CurrentThread.ManagedThreadId;
		}
		lock (_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A)
		{
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020.Clear();
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020.AddRange(_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A);
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A.Clear();
		}
		foreach (Action item in _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020)
		{
			item();
		}
		lock (_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020)
		{
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A.Clear();
			_0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A.AddRange(_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020.Where((DelayedQueueItem P_0) => P_0.time <= DateTime.Now));
			foreach (DelayedQueueItem item2 in _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A)
			{
				_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020.Remove(item2);
			}
		}
		foreach (DelayedQueueItem item3 in _0020_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A)
		{
			item3.action();
		}
	}
}
internal static class _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020
{
	internal class _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A;

		internal string _0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020;

		internal string _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A;

		internal int _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;

		internal string _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A;

		internal int _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020;

		internal string _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A;

		internal string _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020;

		internal string _0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A;

		internal bool _0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020;

		internal bool _0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A;

		internal static _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A P_0)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A obj = new _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A();
			obj._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A = P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020);
			string text = P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A);
			if (string.IsNullOrEmpty(text) || text.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020))
			{
				return obj;
			}
			P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A, out var num);
			string text2 = P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020);
			P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A, out var num2);
			string text3 = P_0._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020);
			obj._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020 = text;
			obj._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A = text2;
			obj._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020 = num;
			obj._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A = text3;
			obj._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020 = num2;
			obj._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(text3 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A);
			obj._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020 = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(text3 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020);
			obj._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(text3 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A);
			return obj;
		}

		internal void _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020()
		{
			if (string.IsNullOrEmpty(_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A))
			{
				return;
			}
			try
			{
				if (File.Exists(Path.Combine(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar))))
				{
					_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020 = true;
				}
				else
				{
					_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020 = false;
				}
			}
			catch
			{
			}
		}

		internal bool _0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(bool P_0)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A == null || _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A == null)
			{
				return false;
			}
			string text = Path.Combine(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar));
			if (!P_0)
			{
				Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 + text));
			}
			if (!File.Exists(text))
			{
				if (!Directory.Exists(Path.GetDirectoryName(text)))
				{
					Directory.CreateDirectory(Path.GetDirectoryName(text));
				}
				File.WriteAllText(text, _0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A);
				File.WriteAllText(text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A, _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020);
				if (!P_0)
				{
					try
					{
						AssetDatabase.Refresh((ImportAssetOptions)257);
						MonoScript val = AssetDatabase.LoadAssetAtPath<MonoScript>(_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A);
						EditorGUIUtility.PingObject((Object)(object)val);
						Selection.objects = (Object[])(object)new Object[1] { (Object)val };
					}
					catch (Exception ex)
					{
						Debug.LogException(ex);
					}
				}
			}
			if (File.Exists(text))
			{
				string text2 = string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A);
				string text3 = string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A);
				_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A(text2, text3, P_0);
				_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, P_0);
				_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020 = true;
				if (!P_0)
				{
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
				}
				return true;
			}
			return false;
		}

		internal bool _0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(bool P_0)
		{
			if (string.IsNullOrEmpty(_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A))
			{
				return false;
			}
			string text = Path.Combine(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar));
			if (File.Exists(text))
			{
				try
				{
					if (!P_0)
					{
						Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A + text));
					}
					File.Delete(text);
					File.Delete(text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A);
				}
				catch
				{
				}
			}
			if (!string.IsNullOrEmpty(_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A))
			{
				try
				{
					string text2 = Path.Combine(Path.Combine(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020), _0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A));
					string text3 = text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A;
					if (File.Exists(text3))
					{
						File.Move(text3, text2);
						if (File.Exists(text3 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A))
						{
							File.Move(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020, text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A);
							if (File.Exists(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A))
							{
								File.Delete(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Debug.LogException(ex);
				}
			}
			string text4 = string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A);
			string text5 = string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020, _0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A);
			_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A(text4, text5, P_0);
			if (_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A == null || _0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020))
			{
				_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A, P_0);
			}
			else
			{
				_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020, Path.GetFileNameWithoutExtension(_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A), P_0);
			}
			_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020 = false;
			if (!P_0)
			{
				try
				{
					AssetDatabase.Refresh((ImportAssetOptions)257);
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
				}
				catch (Exception ex2)
				{
					Debug.LogException(ex2);
				}
			}
			return false;
		}
	}

	internal static bool _0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020;

	internal static decimal _0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = -1m;

	internal static string _0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020;

	internal static bool _0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020 = false;

	internal static _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A;

	internal static _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020;

	internal static _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A _0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A;

	private static bool? _0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020;

	internal static bool _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020
	{
		get
		{
			if (!_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020.HasValue)
			{
				_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
			}
			if (!_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020.HasValue)
			{
				_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 = false;
			}
			return _0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020.Value;
		}
		set
		{
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 = value2;
		}
	}

	internal static void _0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Scene activeScene = SceneManager.GetActiveScene();
			string path = ((Scene)(ref activeScene)).path;
			SceneManager.GetActiveScene();
			if (!string.IsNullOrEmpty(path))
			{
				activeScene = SceneManager.GetActiveScene();
				if (!string.IsNullOrEmpty(((Scene)(ref activeScene)).name))
				{
					activeScene = SceneManager.GetActiveScene();
					SceneManager.UnloadSceneAsync(((Scene)(ref activeScene)).name);
				}
			}
		}
		catch
		{
		}
	}

	internal static void _0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A()
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020 = _0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020 ?? Application.dataPath;
		try
		{
			if (_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A != null)
			{
				return;
			}
			string text = Path.Combine(Path.GetDirectoryName(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020), _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A);
			if (!File.Exists(text))
			{
				Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020 + text));
				Debug.LogWarning((object)_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020);
				return;
			}
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A = new _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A();
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020(text);
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020 = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A) == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020;
			if (_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020.Value)
			{
				Debug.LogWarning((object)_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A);
				return;
			}
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020 = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020);
			_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A = _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_000A._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A);
			Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020 + _0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_000A?._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020?.Count));
			Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A + _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020?._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020?.Count));
		}
		catch (Exception ex)
		{
			Debug.LogWarning((object)string.Concat(ex));
		}
	}

	internal static _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A _0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(long P_0, string P_1, string P_2)
	{
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
		foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
		{
			item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020);
			string text = item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A);
			item._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A, out var num);
			string text2 = item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020);
			item._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A, out var num2);
			string text3 = item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020);
			if (!string.IsNullOrEmpty(P_1) && P_0 != 0L && ((!string.IsNullOrEmpty(P_1) && P_0 != 0L && ((num == P_0 && P_1 == text2) || (num2 == P_0 && P_1 == text3))) || (string.IsNullOrEmpty(P_1) && P_0 == 0L && !string.IsNullOrEmpty(P_2) && text == P_2)))
			{
				return _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item);
			}
		}
		return null;
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(Action P_0)
	{
		ThreadPool.QueueUserWorkItem(_0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020, P_0);
	}

	private static void _0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020(object P_0)
	{
		try
		{
			((Action)P_0)();
		}
		catch (Exception value)
		{
			Console.WriteLine(value);
		}
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A(string P_0, string P_1, bool P_2)
	{
		if (!P_2)
		{
			Debug.LogWarning((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020 + P_0 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A + P_1));
		}
		byte[] bytes = Encoding.ASCII.GetBytes(P_0);
		int num = 0;
		string[] files = Directory.GetFiles(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020, SearchOption.AllDirectories);
		foreach (string text in files)
		{
			try
			{
				string extension = Path.GetExtension(text);
				if (extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A)
				{
					continue;
				}
				using FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				if (_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(bytes, fileStream, 0L) >= 0)
				{
					fileStream.Close();
					File.WriteAllText(text, File.ReadAllText(text).Replace(P_0, P_1));
					if (!P_2)
					{
						Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A + text));
					}
					num++;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError((object)((_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020 + text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + ex) ?? ""));
			}
		}
		if (!P_2)
		{
			try
			{
				Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A + num));
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
			}
			catch
			{
			}
		}
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020(string P_0, string P_1, string P_2, bool P_3)
	{
		if (!P_3)
		{
			Debug.LogWarning((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020 + P_1 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A + P_2));
		}
		byte[] bytes = Encoding.ASCII.GetBytes(P_0);
		byte[] bytes2 = Encoding.ASCII.GetBytes(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020 + P_1);
		int num = 0;
		string[] files = Directory.GetFiles(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020, SearchOption.AllDirectories);
		foreach (string text in files)
		{
			try
			{
				string extension = Path.GetExtension(text);
				if (extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 || extension == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A)
				{
					continue;
				}
				using FileStream fileStream = File.Open(text, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
				if (_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(bytes, fileStream, 0L) < 0 || _0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(bytes2, fileStream, 0L) < 0)
				{
					continue;
				}
				fileStream.Close();
				bool flag = false;
				string[] array = File.ReadAllLines(text);
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].Contains(P_0) && array[j].Contains(P_1))
					{
						array[j] = array[j].Replace(P_1, P_2);
						flag = true;
					}
				}
				if (flag)
				{
					File.WriteAllLines(text, array);
					if (!P_3)
					{
						Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A + text));
					}
					num++;
				}
			}
			catch (Exception ex)
			{
				Debug.LogError((object)((_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020 + text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 + ex) ?? ""));
			}
		}
		if (!P_3)
		{
			try
			{
				Debug.Log((object)(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A + num));
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
			}
			catch
			{
			}
		}
	}

	internal static long _0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A(byte[] P_0, Stream P_1, long P_2 = 0L)
	{
		if (P_2 >= P_1.Length)
		{
			return -1L;
		}
		P_1.Position = P_2;
		int num = P_0.Length * 100;
		byte[] array = new byte[num];
		for (long num2 = P_2; num2 < P_1.Length; num2 += num - P_0.Length)
		{
			int num3 = _0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020._0020_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020(_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020(P_1, num2, num, array), P_0);
			if (num3 >= 0)
			{
				return num2 + num3;
			}
		}
		return -1L;
	}

	private static byte[] _0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020(Stream P_0, long P_1, long P_2, byte[] P_3)
	{
		if (P_3 == null || P_3.Length < P_2)
		{
			P_3 = new byte[P_2];
		}
		long position = P_0.Position;
		P_0.Position = P_1;
		P_0.Read(P_3, 0, (int)P_2);
		P_0.Position = position;
		return P_3;
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(List<_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> P_0)
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = false;
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		foreach (_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A item in P_0)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				break;
			}
			try
			{
				item._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020: true);
				if (!string.IsNullOrEmpty(item._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A) && !hashSet.Contains(item._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A))
				{
					hashSet.Add(item._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				num++;
				_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = (decimal)num / (decimal)P_0.Count;
			}
		}
		_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A();
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(List<_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> P_0)
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = false;
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
		int num = 0;
		foreach (_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A item in P_0)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				break;
			}
			try
			{
				item._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020: true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				num++;
				_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = (decimal)num / (decimal)P_0.Count;
			}
		}
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A()
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = false;
		HashSet<string> hashSet = new HashSet<string>();
		foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				break;
			}
			try
			{
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A obj = _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item);
				if (!string.IsNullOrEmpty(obj._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A) && !hashSet.Contains(obj._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A))
				{
					hashSet.Add(obj._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}
		foreach (string item2 in hashSet)
		{
			bool flag = true;
			foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item3 in _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
			{
				if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
				{
					break;
				}
				try
				{
					_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A obj2 = _0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item3);
					if (!string.IsNullOrEmpty(obj2._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020) && !obj2._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020) && !(obj2._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A != item2) && !string.IsNullOrEmpty(obj2._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A))
					{
						obj2._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020();
						if (!obj2._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020)
						{
							flag = false;
							break;
						}
					}
				}
				catch (Exception ex2)
				{
					Debug.LogException(ex2);
				}
			}
			if (!flag || string.IsNullOrEmpty(item2))
			{
				continue;
			}
			try
			{
				string text = Path.Combine(Path.Combine(_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020), item2.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A));
				string destFileName = text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A;
				if (File.Exists(text))
				{
					File.Move(text, destFileName);
					if (File.Exists(text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A))
					{
						File.Move(text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A, text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020);
					}
				}
			}
			catch (Exception ex3)
			{
				Debug.LogException(ex3);
			}
		}
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020()
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = false;
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
		int num = 0;
		foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				break;
			}
			try
			{
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item)._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020: true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				num++;
				_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = (decimal)num / (decimal)_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count;
			}
		}
		_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A();
	}

	internal static void _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A()
	{
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = false;
		_0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
		_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
		int num = 0;
		foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
		{
			if (_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020)
			{
				break;
			}
			try
			{
				_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item)._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020: true);
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
			finally
			{
				num++;
				_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = (decimal)num / (decimal)_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020.Count;
			}
		}
	}
}
[CustomEditor(typeof(ScriptableObject), true)]
internal class _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020 : _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020
{
}
[CustomEditor(typeof(MonoScript), true)]
internal class _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A : _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020
{
}
[CustomEditor(typeof(MonoBehaviour), true)]
internal class _0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020 : Editor
{
	private bool _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = true;

	[NonSerialized]
	private _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020;

	private string _0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A;

	private long _0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020;

	private string _0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A;

	[NonSerialized]
	private bool _0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020;

	private void OnEnable()
	{
	}

	public override void OnInspectorGUI()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		try
		{
			if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020)
			{
				((Editor)this).OnInspectorGUI();
				return;
			}
			if (!_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020)
			{
				_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020 = true;
				MonoScript val = null;
				Object target = ((Editor)this).target;
				if (((target is MonoScript) ? target : null) != (Object)null)
				{
					Object target2 = ((Editor)this).target;
					val = (MonoScript)(object)((target2 is MonoScript) ? target2 : null);
				}
				else
				{
					Object target3 = ((Editor)this).target;
					if (((target3 is MonoBehaviour) ? target3 : null) != (Object)null)
					{
						val = MonoScript.FromMonoBehaviour((MonoBehaviour)((Editor)this).target);
					}
					else
					{
						Object target4 = ((Editor)this).target;
						if (((target4 is ScriptableObject) ? target4 : null) != (Object)null)
						{
							val = MonoScript.FromScriptableObject((ScriptableObject)((Editor)this).target);
						}
					}
				}
				if ((Object)(object)val != (Object)null)
				{
					_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A = AssetDatabase.GetAssetPath((Object)(object)val);
					AssetDatabase.TryGetGUIDAndLocalFileIdentifier((Object)(object)val, ref _0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A, ref _0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020);
					_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020 = _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020(_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020, _0020_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A, ((object)((Editor)this).target).GetType().FullName);
				}
			}
			if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020 != null)
			{
				_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A = EditorGUILayout.Foldout(_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A);
				if (_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_000A)
				{
					_ = ((object)((Editor)this).target).GetType().FullName;
					EditorGUILayout.LabelField(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020 + _0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A, (GUILayoutOption[])(object)new GUILayoutOption[0]);
					if (_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A))
					{
						if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020, (GUILayoutOption[])(object)new GUILayoutOption[0]))
						{
							_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020 = false;
							_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020: true);
							_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A();
							AssetDatabase.Refresh((ImportAssetOptions)257);
							_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
							return;
						}
					}
					else
					{
						GUILayout.BeginHorizontal((GUILayoutOption[])(object)new GUILayoutOption[0]);
						if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A, (GUILayoutOption[])(object)new GUILayoutOption[0]))
						{
							DevXShowScript._0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020 + _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A, _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A);
						}
						if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020, (GUILayoutOption[])(object)new GUILayoutOption[0]))
						{
							Path.Combine(Application.dataPath, _0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar));
							try
							{
								try
								{
									EditorApplication.LockReloadAssemblies();
									_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020: true);
									_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A();
									return;
								}
								finally
								{
									EditorApplication.UnlockReloadAssemblies();
									GUI.changed = true;
								}
							}
							catch (Exception ex)
							{
								Debug.LogError((object)string.Concat(ex));
							}
							AssetDatabase.Refresh((ImportAssetOptions)257);
							_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A();
							_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020 = false;
						}
						GUILayout.EndHorizontal();
					}
					EditorGUILayout.Separator();
				}
			}
		}
		catch (Exception ex2)
		{
			Debug.LogError((object)ex2);
		}
		((Editor)this).OnInspectorGUI();
	}
}
internal static class _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020
{
	private static int _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020;

	private static int _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A = 5;

	private static int _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020 = 10;

	private static float _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A = 0.5f;

	public static List<ScriptDbTreeElement> GenerateRandomTree(int numTotalElements)
	{
		int num = numTotalElements / 4;
		_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020 = 0;
		List<ScriptDbTreeElement> list = new List<ScriptDbTreeElement>(numTotalElements);
		ScriptDbTreeElement scriptDbTreeElement = new ScriptDbTreeElement(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A, -1, _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020);
		list.Add(scriptDbTreeElement);
		for (int i = 0; i < num; i++)
		{
			int num2 = 6;
			_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(scriptDbTreeElement, Random.Range(_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A, _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020), _0020_0020: true, numTotalElements, ref num2, list);
		}
		return list;
	}

	private static void _0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(TreeElement P_0, int P_1, bool P_2, int P_3, ref int P_4, List<ScriptDbTreeElement> P_5)
	{
		if (P_0.depth >= P_4)
		{
			P_4 = 0;
			return;
		}
		for (int i = 0; i < P_1; i++)
		{
			if (_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020 > P_3)
			{
				break;
			}
			ScriptDbTreeElement scriptDbTreeElement = new ScriptDbTreeElement(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A + _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020, P_0.depth + 1, ++_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020);
			P_5.Add(scriptDbTreeElement);
			if (P_2 || !(Random.value < _0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A))
			{
				_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_000A(scriptDbTreeElement, Random.Range(_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A, _0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020), _0020_0020: false, P_3, ref P_4, P_5);
			}
		}
	}
}
internal class _0020_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A
{
	private class _0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020 : TreeElement
	{
		public _0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020(string name, int depth)
		{
			base.name = name;
			base.depth = depth;
		}
	}
}
internal class _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020 : _0020_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020<ScriptDbTreeElement>
{
	private enum MyColumns
	{
		Name,
		ViewScript,
		UnpackScript,
		RemoveScript
	}

	public enum SortOption
	{
		Name
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020
	{
		public static readonly _0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020 _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A = new _0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_0020();

		public static Func<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>, string> _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020;

		public static Func<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>, string> _0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A;

		public static Func<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>, string> _0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020;

		internal string _0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> P_0)
		{
			return P_0.data.name;
		}

		internal string _0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> P_0)
		{
			return P_0.data.name;
		}

		internal string _0020_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A(_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> P_0)
		{
			return P_0.data.name;
		}
	}

	private const float _0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A = 20f;

	private const float _0020_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020 = 18f;

	public bool showControls;

	private static Texture2D[] _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A = (Texture2D[])(object)new Texture2D[5]
	{
		EditorGUIUtility.FindTexture(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A),
		EditorGUIUtility.FindTexture(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020),
		EditorGUIUtility.FindTexture(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A),
		EditorGUIUtility.FindTexture(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020),
		EditorGUIUtility.FindTexture(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A)
	};

	private SortOption[] _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020;

	public static void TreeToList(TreeViewItem root, IList<TreeViewItem> result)
	{
		if (root == null)
		{
			throw new NullReferenceException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020);
		}
		if (result == null)
		{
			throw new NullReferenceException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A);
		}
		result.Clear();
		if (root.children == null)
		{
			return;
		}
		Stack<TreeViewItem> stack = new Stack<TreeViewItem>();
		for (int num = root.children.Count - 1; num >= 0; num--)
		{
			stack.Push(root.children[num]);
		}
		while (stack.Count > 0)
		{
			TreeViewItem val = stack.Pop();
			result.Add(val);
			if (val.hasChildren && val.children[0] != null)
			{
				for (int num2 = val.children.Count - 1; num2 >= 0; num2--)
				{
					stack.Push(val.children[num2]);
				}
			}
		}
	}

	public _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(TreeViewState state, MultiColumnHeader multicolumnHeader, TreeModel<ScriptDbTreeElement> model)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		showControls = true;
		_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020 = new SortOption[1];
		base._002Ector(state, multicolumnHeader, model);
		((TreeView)this).rowHeight = 20f;
		((TreeView)this).columnIndexForTreeFoldouts = 0;
		((TreeView)this).showAlternatingRowBackgrounds = true;
		((TreeView)this).showBorder = true;
		((TreeView)this).customFoldoutYOffset = (20f - EditorGUIUtility.singleLineHeight) * 0.5f;
		((TreeView)this).extraSpaceBeforeIconAndLabel = 18f;
		multicolumnHeader.sortingChanged += new HeaderCallback(_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A);
		((TreeView)this).Reload();
	}

	protected override IList<TreeViewItem> BuildRows(TreeViewItem root)
	{
		IList<TreeViewItem> list = base.BuildRows(root);
		_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(root, list);
		return list;
	}

	private void _0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_000A(MultiColumnHeader P_0)
	{
		_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(((TreeView)this).rootItem, ((TreeView)this).GetRows());
	}

	private void _0020_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020(TreeViewItem P_0, IList<TreeViewItem> P_1)
	{
		if (P_1.Count > 1 && ((TreeView)this).multiColumnHeader.sortedColumnIndex != -1)
		{
			_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A();
			TreeToList(P_0, P_1);
			((TreeView)this).Repaint();
		}
	}

	private void _0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_000A()
	{
		int[] sortedColumns = ((TreeView)this).multiColumnHeader.state.sortedColumns;
		if (sortedColumns.Length == 0)
		{
			return;
		}
		IEnumerable<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>> enumerable = ((TreeView)this).rootItem.children.Cast<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>>();
		IOrderedEnumerable<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>> source = _0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(enumerable, sortedColumns);
		for (int i = 1; i < sortedColumns.Length; i++)
		{
			SortOption sortOption = _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020[sortedColumns[i]];
			bool flag = ((TreeView)this).multiColumnHeader.IsSortedAscending(sortedColumns[i]);
			if (sortOption == SortOption.Name)
			{
				source = source.ThenBy((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> P_0) => P_0.data.name, flag);
			}
		}
		((TreeView)this).rootItem.children = source.Cast<TreeViewItem>().ToList();
	}

	private IOrderedEnumerable<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>> _0020_0020_000A_0020_0020_000A_000A_0020_0020_0020_0020(IEnumerable<_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>> P_0, int[] P_1)
	{
		SortOption sortOption = _0020_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020[P_1[0]];
		bool flag = ((TreeView)this).multiColumnHeader.IsSortedAscending(P_1[0]);
		if (sortOption == SortOption.Name)
		{
			return P_0.Order((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> obj) => obj.data.name, flag);
		}
		return P_0.Order((_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> obj) => obj.data.name, flag);
	}

	protected override void RowGUI(RowGUIArgs args)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> obj = (_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement>)(object)args.item;
		bool enabled = GUI.enabled;
		if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A > 0m)
		{
			GUI.enabled = false;
		}
		for (int i = 0; i < ((RowGUIArgs)(ref args)).GetNumVisibleColumns(); i++)
		{
			_0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(((RowGUIArgs)(ref args)).GetCellRect(i), obj, (MyColumns)((RowGUIArgs)(ref args)).GetColumn(i), ref args);
		}
		GUI.enabled = enabled;
	}

	private void _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_000A(Rect P_0, _0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A<ScriptDbTreeElement> P_1, MyColumns P_2, ref RowGUIArgs P_3)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		((TreeView)this).CenterRectUsingSingleLineHeight(ref P_0);
		switch (P_2)
		{
		case MyColumns.Name:
		{
			Rect val = P_0;
			((Rect)(ref val)).x = ((Rect)(ref val)).x + ((TreeView)this).GetContentIndent((TreeViewItem)(object)P_1);
			((Rect)(ref val)).width = 18f;
			if (((Rect)(ref val)).xMax < ((Rect)(ref P_0)).xMax)
			{
				P_1.data.selected = EditorGUI.Toggle(val, P_1.data.selected);
			}
			P_3.rowRect = P_0;
			((TreeView)this).RowGUI(P_3);
			break;
		}
		case MyColumns.ViewScript:
			if (showControls && P_1.data.item != null && !string.IsNullOrEmpty(P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A))
			{
				((Rect)(ref P_0)).xMin = ((Rect)(ref P_0)).xMin + 5f;
				if (GUI.Button(P_0, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020))
				{
					DevXShowScript._0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020 + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020 + P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A, P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A);
				}
			}
			break;
		case MyColumns.UnpackScript:
			if (showControls && P_1.data.item != null && !P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020)
			{
				((Rect)(ref P_0)).xMin = ((Rect)(ref P_0)).xMin + 5f;
				if (GUI.Button(P_0, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A))
				{
					P_1.data.item._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_000A(_0020: false);
					_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A();
					AssetDatabase.Refresh((ImportAssetOptions)257);
				}
			}
			break;
		case MyColumns.RemoveScript:
			if (showControls && P_1.data.item != null && P_1.data.item._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020)
			{
				((Rect)(ref P_0)).xMin = ((Rect)(ref P_0)).xMin + 5f;
				if (GUI.Button(P_0, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020))
				{
					P_1.data.item._0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020(_0020: false);
					AssetDatabase.Refresh((ImportAssetOptions)257);
				}
			}
			break;
		}
	}

	protected override bool CanRename(TreeViewItem item)
	{
		return false;
	}

	protected override void RenameEnded(RenameEndedArgs args)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (args.acceptedRename)
		{
			base.treeModel.Find(args.itemID).name = args.newName;
			((TreeView)this).Reload();
		}
	}

	protected override Rect GetRenameRect(Rect rowRect, int row, TreeViewItem item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		Rect cellRectForTreeFoldouts = ((TreeView)this).GetCellRectForTreeFoldouts(rowRect);
		((TreeView)this).CenterRectUsingSingleLineHeight(ref cellRectForTreeFoldouts);
		return ((TreeView)this).GetRenameRect(cellRectForTreeFoldouts, row, item);
	}

	protected override bool CanMultiSelect(TreeViewItem item)
	{
		return true;
	}

	public static MultiColumnHeaderState CreateDefaultMultiColumnHeaderState(float treeViewWidth)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		return new MultiColumnHeaderState((Column[])(object)new Column[4]
		{
			new Column
			{
				headerContent = new GUIContent(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A),
				headerTextAlignment = (TextAlignment)0,
				sortedAscending = true,
				sortingArrowAlignment = (TextAlignment)1,
				width = 400f,
				minWidth = 60f,
				autoResize = false
			},
			new Column
			{
				headerContent = new GUIContent(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020, ""),
				headerTextAlignment = (TextAlignment)2,
				sortedAscending = false,
				sortingArrowAlignment = (TextAlignment)0,
				width = 150f,
				minWidth = 50f,
				autoResize = false
			},
			new Column
			{
				headerContent = new GUIContent(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A, ""),
				headerTextAlignment = (TextAlignment)2,
				sortedAscending = false,
				sortingArrowAlignment = (TextAlignment)0,
				width = 150f,
				minWidth = 50f,
				autoResize = false
			},
			new Column
			{
				headerContent = new GUIContent(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020, ""),
				headerTextAlignment = (TextAlignment)2,
				sortedAscending = false,
				sortingArrowAlignment = (TextAlignment)0,
				width = 150f,
				minWidth = 50f,
				autoResize = false
			}
		});
	}
}
internal static class _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_0020
{
	public static IOrderedEnumerable<T> Order<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector, bool ascending)
	{
		if (ascending)
		{
			return source.OrderBy(selector);
		}
		return source.OrderByDescending(selector);
	}

	public static IOrderedEnumerable<T> ThenBy<T, TKey>(this IOrderedEnumerable<T> source, Func<T, TKey> selector, bool ascending)
	{
		if (ascending)
		{
			return source.ThenBy(selector);
		}
		return source.ThenByDescending(selector);
	}
}
internal class _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A : EditorWindow
{
	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A
	{
		public List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020;
	}

	[StructLayout(LayoutKind.Auto)]
	[CompilerGenerated]
	private struct _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020
	{
		public List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020;
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A
	{
		public static readonly _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A = new _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A();

		public static Action _0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020;

		public static Action _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A;

		internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_000A()
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			GUI.changed = true;
			AssetDatabase.Refresh((ImportAssetOptions)257);
			SceneManager.GetActiveScene();
			Scene activeScene = SceneManager.GetActiveScene();
			EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
		}

		internal void _0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020()
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			GUI.changed = true;
			AssetDatabase.Refresh((ImportAssetOptions)257);
			SceneManager.GetActiveScene();
			Scene activeScene = SceneManager.GetActiveScene();
			EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
		}
	}

	private _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A _0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020 = new _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A();

	[NonSerialized]
	private bool _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A;

	[SerializeField]
	private TreeViewState m_TreeViewState;

	[SerializeField]
	private MultiColumnHeaderState m_MultiColumnHeaderState;

	private SearchField _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020;

	private _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020 _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A;

	private Rect _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			Rect position = ((EditorWindow)this).position;
			float num = ((Rect)(ref position)).width - 40f;
			position = ((EditorWindow)this).position;
			return new Rect(20f, 30f, num, ((Rect)(ref position)).height - 60f);
		}
	}

	private Rect _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
			Rect position = ((EditorWindow)this).position;
			return new Rect(20f, 10f, ((Rect)(ref position)).width - 40f, 20f);
		}
	}

	private Rect _0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			Rect position = ((EditorWindow)this).position;
			float num = ((Rect)(ref position)).height - 28f;
			position = ((EditorWindow)this).position;
			return new Rect(20f, num, ((Rect)(ref position)).width - 40f, 26f);
		}
	}

	public _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020 treeView => _0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A;

	public void Start()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		if (_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020 == null)
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020 = new _0020_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A();
		}
		EditorApplication.update = (CallbackFunction)Delegate.Combine((Delegate)(object)EditorApplication.update, (Delegate)new CallbackFunction(OnEditorUpdate));
	}

	protected virtual void OnEditorUpdate()
	{
		_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020?._0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020();
		if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A != 0m)
		{
			GUI.changed = true;
			((EditorWindow)this).Repaint();
		}
	}

	protected virtual void Update()
	{
		_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020?._0020_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020();
	}

	[MenuItem("DevXUnpacker/Project scripts manager")]
	public static _0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A GetWindow()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020)
		{
			EditorUtility.DisplayDialog(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A);
			return null;
		}
		_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A window = EditorWindow.GetWindow<_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A>();
		((EditorWindow)window).titleContent = new GUIContent(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020);
		((EditorWindow)window).Focus();
		((EditorWindow)window).Repaint();
		return window;
	}

	private void _0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		if (!_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A)
		{
			if (m_TreeViewState == null)
			{
				m_TreeViewState = new TreeViewState();
			}
			bool num = m_MultiColumnHeaderState == null;
			Rect val = _0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020;
			MultiColumnHeaderState val2 = _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020.CreateDefaultMultiColumnHeaderState(((Rect)(ref val)).width);
			if (MultiColumnHeaderState.CanOverwriteSerializedFields(m_MultiColumnHeaderState, val2))
			{
				MultiColumnHeaderState.OverwriteSerializedFields(m_MultiColumnHeaderState, val2);
			}
			m_MultiColumnHeaderState = val2;
			_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 obj = new _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020(val2);
			if (num)
			{
				((MultiColumnHeader)obj).ResizeToFit();
			}
			TreeModel<ScriptDbTreeElement> model = new TreeModel<ScriptDbTreeElement>(_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A());
			_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A = new _0020_0020_000A_0020_0020_000A_0020_000A_000A_000A_0020(m_TreeViewState, (MultiColumnHeader)(object)obj, model);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020 = new SearchField();
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020.downOrUpArrowKeyPressed += new SearchFieldCallback(((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).SetFocusAndEnsureSelectedItem);
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A = true;
		}
	}

	private IList<ScriptDbTreeElement> _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A()
	{
		_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A();
		List<ScriptDbTreeElement> list = new List<ScriptDbTreeElement>();
		int num = 0;
		ScriptDbTreeElement scriptDbTreeElement = new ScriptDbTreeElement(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A, -1, num);
		list.Add(scriptDbTreeElement);
		if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020 == null)
		{
			return list;
		}
		Dictionary<string, ScriptDbTreeElement> dictionary = new Dictionary<string, ScriptDbTreeElement>();
		foreach (_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A item in _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_0020_000A_000A_000A_0020._0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020)
		{
			try
			{
				string text = item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020);
				if (!dictionary.TryGetValue(text, out var value))
				{
					value = new ScriptDbTreeElement(text, scriptDbTreeElement.depth + 1, ++num);
					value.IsAssembly = true;
					dictionary[text] = value;
					list.Add(value);
				}
				string text2 = item._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A);
				if (!string.IsNullOrEmpty(text2) && !text2.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020))
				{
					_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A obj = _0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A(item);
					if (!string.IsNullOrEmpty(obj._0020_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A))
					{
						obj._0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020();
						ScriptDbTreeElement scriptDbTreeElement2 = new ScriptDbTreeElement(text2, value.depth + 1, ++num);
						scriptDbTreeElement2.item = obj;
						list.Add(scriptDbTreeElement2);
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
			}
		}
		return list;
	}

	private void OnGUI()
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020();
		_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A);
		_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020);
		_0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020);
	}

	private void _0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020(Rect P_0)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		((TreeView)treeView).searchString = _0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020.OnGUI(P_0, ((TreeView)treeView).searchString);
	}

	private void _0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_000A(Rect P_0)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		((TreeView)_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A).OnGUI(P_0);
	}

	private List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> _0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020()
	{
		_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A obj = default(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A);
		obj._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A>();
		foreach (ScriptDbTreeElement child in treeView.treeModel.root.children)
		{
			_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(child, ref obj);
		}
		return obj._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020;
	}

	private List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A> _0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A(ScriptDbTreeElement P_0)
	{
		_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 obj = default(_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020);
		obj._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new List<_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A>();
		foreach (ScriptDbTreeElement child in P_0.children)
		{
			_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020(child, ref obj);
		}
		return obj._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020;
	}

	private void _0020_0020_000A_0020_0020_000A_000A_000A_000A_000A_0020(Rect P_0)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		GUILayout.BeginArea(P_0);
		HorizontalScope val = new HorizontalScope((GUILayoutOption[])(object)new GUILayoutOption[0]);
		try
		{
			bool enabled = GUI.enabled;
			if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A >= 0m)
			{
				GUI.enabled = false;
			}
			string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A;
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020, GUIStyle.op_Implicit(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
				GUI.changed = true;
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(delegate
				{
					try
					{
						_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020());
					}
					finally
					{
						_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = -1m;
						_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(delegate
						{
							//IL_0010: Unknown result type (might be due to invalid IL or missing references)
							//IL_0016: Unknown result type (might be due to invalid IL or missing references)
							//IL_001b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0024: Unknown result type (might be due to invalid IL or missing references)
							GUI.changed = true;
							AssetDatabase.Refresh((ImportAssetOptions)257);
							SceneManager.GetActiveScene();
							Scene activeScene = SceneManager.GetActiveScene();
							EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
						});
					}
				});
			}
			if (GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A, GUIStyle.op_Implicit(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = 0m;
				GUI.changed = true;
				_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A(delegate
				{
					try
					{
						_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020());
					}
					finally
					{
						_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = -1m;
						_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(delegate
						{
							//IL_0010: Unknown result type (might be due to invalid IL or missing references)
							//IL_0016: Unknown result type (might be due to invalid IL or missing references)
							//IL_001b: Unknown result type (might be due to invalid IL or missing references)
							//IL_0024: Unknown result type (might be due to invalid IL or missing references)
							GUI.changed = true;
							AssetDatabase.Refresh((ImportAssetOptions)257);
							SceneManager.GetActiveScene();
							Scene activeScene = SceneManager.GetActiveScene();
							EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
						});
					}
				});
			}
			GUI.enabled = enabled;
			if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A >= 0m && GUILayout.Button(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020, GUIStyle.op_Implicit(text), (GUILayoutOption[])(object)new GUILayoutOption[0]))
			{
				_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020 = true;
			}
			if (_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A >= 0m)
			{
				EditorGUILayout.LabelField(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A + Math.Round(_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A * 100m, 2) + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020, (GUILayoutOption[])(object)new GUILayoutOption[0]);
				GUI.changed = true;
				((EditorWindow)this).Repaint();
			}
			GUILayout.FlexibleSpace();
			GUILayout.FlexibleSpace();
			GUILayout.Space(10f);
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
		GUILayout.EndArea();
	}

	[CompilerGenerated]
	internal static void _0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(ScriptDbTreeElement P_0, ref _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		if (P_0.selected && P_0.item != null)
		{
			P_1._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020.Add(P_0.item);
		}
		if (P_0.children == null)
		{
			return;
		}
		foreach (ScriptDbTreeElement child in P_0.children)
		{
			_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A(child, ref P_1);
		}
	}

	[CompilerGenerated]
	internal static void _0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020(ScriptDbTreeElement P_0, ref _0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020 P_1)
	{
		if (P_0 == null)
		{
			return;
		}
		if (P_0.item != null)
		{
			P_1._0020_0020_0020_000A_0020_0020_0020_0020_0020_0020.Add(P_0.item);
		}
		if (P_0.children == null)
		{
			return;
		}
		foreach (ScriptDbTreeElement child in P_0.children)
		{
			_0020_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020(child, ref P_1);
		}
	}

	[CompilerGenerated]
	private void _0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_000A()
	{
		try
		{
			_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A(_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020());
		}
		finally
		{
			_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = -1m;
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(delegate
			{
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Unknown result type (might be due to invalid IL or missing references)
				GUI.changed = true;
				AssetDatabase.Refresh((ImportAssetOptions)257);
				SceneManager.GetActiveScene();
				Scene activeScene = SceneManager.GetActiveScene();
				EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
			});
		}
	}

	[CompilerGenerated]
	private void _0020_0020_000A_0020_0020_000A_000A_000A_0020_000A_0020()
	{
		try
		{
			_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020(_0020_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020());
		}
		finally
		{
			_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020._0020_000A_0020_0020_000A_0020_000A_0020_0020_0020_000A = -1m;
			_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020._0020_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A(delegate
			{
				//IL_0010: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_001b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0024: Unknown result type (might be due to invalid IL or missing references)
				GUI.changed = true;
				AssetDatabase.Refresh((ImportAssetOptions)257);
				SceneManager.GetActiveScene();
				Scene activeScene = SceneManager.GetActiveScene();
				EditorSceneManager.OpenScene(((Scene)(ref activeScene)).path, (OpenSceneMode)0);
			});
		}
	}
}
internal class _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020 : MultiColumnHeader
{
	public enum Mode
	{
		LargeHeader,
		DefaultHeader,
		MinimumHeaderWithoutSorting
	}

	private Mode _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020;

	public Mode mode
	{
		get
		{
			return _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020;
		}
		set
		{
			_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020 = value;
			switch (_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020)
			{
			case Mode.LargeHeader:
				((MultiColumnHeader)this).canSort = true;
				((MultiColumnHeader)this).height = 37f;
				break;
			case Mode.DefaultHeader:
				((MultiColumnHeader)this).canSort = true;
				((MultiColumnHeader)this).height = DefaultGUI.defaultHeight;
				break;
			case Mode.MinimumHeaderWithoutSorting:
				((MultiColumnHeader)this).canSort = false;
				((MultiColumnHeader)this).height = DefaultGUI.minimumHeight;
				break;
			}
		}
	}

	public _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020(MultiColumnHeaderState state)
		: base(state)
	{
		mode = Mode.DefaultHeader;
	}

	protected override void ColumnHeaderGUI(Column column, Rect headerRect, int columnIndex)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		((MultiColumnHeader)this).ColumnHeaderGUI(column, headerRect, columnIndex);
		if (mode == Mode.LargeHeader && columnIndex > 2)
		{
			((Rect)(ref headerRect)).xMax = ((Rect)(ref headerRect)).xMax - 3f;
			TextAnchor alignment = EditorStyles.largeLabel.alignment;
			EditorStyles.largeLabel.alignment = (TextAnchor)2;
			GUI.Label(headerRect, 36 + columnIndex + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020, EditorStyles.largeLabel);
			EditorStyles.largeLabel.alignment = alignment;
		}
	}
}
internal class _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A
{
	private const int _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020 = 5;

	private const int _0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A = 65536;

	public void GetBlock(_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 input, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A output, bool isFinal)
	{
		int num = 0;
		if (input != null)
		{
			num = Math.Min(input._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A, output._0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A - 5 - output._0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020);
			if (num > 65531)
			{
				num = 65531;
			}
		}
		if (isFinal)
		{
			output._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(3, 1u);
		}
		else
		{
			output._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(3, 0u);
		}
		output._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020();
		_0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020((ushort)num, output);
		if (input != null && num > 0)
		{
			output._0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(input._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020, input._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020, num);
			input._0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(num);
		}
	}

	private void _0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020(ushort P_0, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_1)
	{
		P_1._0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(P_0);
		ushort num = (ushort)(~P_0);
		P_1._0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(num);
	}
}
internal static class _0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A
{
	private static readonly uint[] _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A = new uint[256]
	{
		0u, 1996959894u, 3993919788u, 2567524794u, 124634137u, 1886057615u, 3915621685u, 2657392035u, 249268274u, 2044508324u,
		3772115230u, 2547177864u, 162941995u, 2125561021u, 3887607047u, 2428444049u, 498536548u, 1789927666u, 4089016648u, 2227061214u,
		450548861u, 1843258603u, 4107580753u, 2211677639u, 325883990u, 1684777152u, 4251122042u, 2321926636u, 335633487u, 1661365465u,
		4195302755u, 2366115317u, 997073096u, 1281953886u, 3579855332u, 2724688242u, 1006888145u, 1258607687u, 3524101629u, 2768942443u,
		901097722u, 1119000684u, 3686517206u, 2898065728u, 853044451u, 1172266101u, 3705015759u, 2882616665u, 651767980u, 1373503546u,
		3369554304u, 3218104598u, 565507253u, 1454621731u, 3485111705u, 3099436303u, 671266974u, 1594198024u, 3322730930u, 2970347812u,
		795835527u, 1483230225u, 3244367275u, 3060149565u, 1994146192u, 31158534u, 2563907772u, 4023717930u, 1907459465u, 112637215u,
		2680153253u, 3904427059u, 2013776290u, 251722036u, 2517215374u, 3775830040u, 2137656763u, 141376813u, 2439277719u, 3865271297u,
		1802195444u, 476864866u, 2238001368u, 4066508878u, 1812370925u, 453092731u, 2181625025u, 4111451223u, 1706088902u, 314042704u,
		2344532202u, 4240017532u, 1658658271u, 366619977u, 2362670323u, 4224994405u, 1303535960u, 984961486u, 2747007092u, 3569037538u,
		1256170817u, 1037604311u, 2765210733u, 3554079995u, 1131014506u, 879679996u, 2909243462u, 3663771856u, 1141124467u, 855842277u,
		2852801631u, 3708648649u, 1342533948u, 654459306u, 3188396048u, 3373015174u, 1466479909u, 544179635u, 3110523913u, 3462522015u,
		1591671054u, 702138776u, 2966460450u, 3352799412u, 1504918807u, 783551873u, 3082640443u, 3233442989u, 3988292384u, 2596254646u,
		62317068u, 1957810842u, 3939845945u, 2647816111u, 81470997u, 1943803523u, 3814918930u, 2489596804u, 225274430u, 2053790376u,
		3826175755u, 2466906013u, 167816743u, 2097651377u, 4027552580u, 2265490386u, 503444072u, 1762050814u, 4150417245u, 2154129355u,
		426522225u, 1852507879u, 4275313526u, 2312317920u, 282753626u, 1742555852u, 4189708143u, 2394877945u, 397917763u, 1622183637u,
		3604390888u, 2714866558u, 953729732u, 1340076626u, 3518719985u, 2797360999u, 1068828381u, 1219638859u, 3624741850u, 2936675148u,
		906185462u, 1090812512u, 3747672003u, 2825379669u, 829329135u, 1181335161u, 3412177804u, 3160834842u, 628085408u, 1382605366u,
		3423369109u, 3138078467u, 570562233u, 1426400815u, 3317316542u, 2998733608u, 733239954u, 1555261956u, 3268935591u, 3050360625u,
		752459403u, 1541320221u, 2607071920u, 3965973030u, 1969922972u, 40735498u, 2617837225u, 3943577151u, 1913087877u, 83908371u,
		2512341634u, 3803740692u, 2075208622u, 213261112u, 2463272603u, 3855990285u, 2094854071u, 198958881u, 2262029012u, 4057260610u,
		1759359992u, 534414190u, 2176718541u, 4139329115u, 1873836001u, 414664567u, 2282248934u, 4279200368u, 1711684554u, 285281116u,
		2405801727u, 4167216745u, 1634467795u, 376229701u, 2685067896u, 3608007406u, 1308918612u, 956543938u, 2808555105u, 3495958263u,
		1231636301u, 1047427035u, 2932959818u, 3654703836u, 1088359270u, 936918000u, 2847714899u, 3736837829u, 1202900863u, 817233897u,
		3183342108u, 3401237130u, 1404277552u, 615818150u, 3134207493u, 3453421203u, 1423857449u, 601450431u, 3009837614u, 3294710456u,
		1567103746u, 711928724u, 3020668471u, 3272380065u, 1510334235u, 755167117u
	};

	public static uint UpdateCrc32(uint crc32, byte[] buffer, int offset, int length)
	{
		crc32 ^= 0xFFFFFFFFu;
		while (--length >= 0)
		{
			crc32 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A[(crc32 ^ buffer[offset++]) & 0xFF] ^ (crc32 >> 8);
		}
		crc32 ^= 0xFFFFFFFFu;
		return crc32;
	}
}
internal class _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020
{
	internal struct _0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;

		internal int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;
	}

	private byte[] _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A;

	private int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;

	private int _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;

	internal byte[] _0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A = array;
		}
	}

	internal int _0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A
	{
		get
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;
		}
		set
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A = num;
		}
	}

	internal int _0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020
	{
		get
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;
		}
		set
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 = num;
		}
	}

	internal void _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(int P_0)
	{
		_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 += P_0;
		_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A -= P_0;
	}

	internal _0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A()
	{
		_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A result = default(_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A);
		result._0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;
		result._0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 = _0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;
		return result;
	}

	internal void _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A P_0)
	{
		_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A = P_0._0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A;
		_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020 = P_0._0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020;
	}
}
internal class _0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020 : IDeflater, IDisposable
{
	private enum DeflaterState
	{
		NotStarted,
		SlowDownForIncompressible1,
		SlowDownForIncompressible2,
		StartingSmallData,
		CompressThenCheck,
		CheckingForIncompressible,
		HandlingSmallData
	}

	private const int _0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A = 256;

	private const int _0020_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020 = 120;

	private const int _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A = 8072;

	private const double _0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020 = 1.0;

	private _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A;

	private _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020;

	private _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;

	private _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020;

	private DeflaterState _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A;

	private _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020;

	internal _0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020()
	{
		_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A = new _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A();
		_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020 = new _0020_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A();
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A = new _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020();
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A();
		_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.NotStarted;
	}

	private bool _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020()
	{
		return ((IDeflater)this).NeedsInput();
	}

	bool IDeflater.NeedsInput()
	{
		if (_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A == 0)
		{
			return _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A == 0;
		}
		return false;
	}

	void IDeflater.SetInput(byte[] inputBuffer, int startIndex, int count)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020 = inputBuffer;
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A = count;
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020 = startIndex;
		if (count > 0 && count < 256)
		{
			switch (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A)
			{
			case DeflaterState.NotStarted:
			case DeflaterState.CheckingForIncompressible:
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.StartingSmallData;
				break;
			case DeflaterState.CompressThenCheck:
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.HandlingSmallData;
				break;
			}
		}
	}

	int IDeflater.GetDeflateOutput(byte[] outputBuffer)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A(outputBuffer);
		switch (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A)
		{
		case DeflaterState.NotStarted:
		{
			_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A obj3 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A obj4 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A();
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			if (!_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A))
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(obj3);
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(obj4);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.GetBlock(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020, isFinal: false);
				_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020();
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.CheckingForIncompressible;
			}
			else
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.CompressThenCheck;
			}
			break;
		}
		case DeflaterState.CompressThenCheck:
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			if (!_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A))
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.SlowDownForIncompressible1;
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020 = _0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020;
			}
			break;
		case DeflaterState.SlowDownForIncompressible1:
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.SlowDownForIncompressible2;
			goto case DeflaterState.SlowDownForIncompressible2;
		case DeflaterState.SlowDownForIncompressible2:
			if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A > 0)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.GetBlock(_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020, isFinal: false);
			}
			if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A == 0)
			{
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020();
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.CheckingForIncompressible;
			}
			break;
		case DeflaterState.CheckingForIncompressible:
		{
			_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A obj = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A obj2 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A();
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020, 8072);
			if (!_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A(_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A))
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(obj);
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(obj2);
				_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.GetBlock(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020, isFinal: false);
				_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020();
			}
			break;
		}
		case DeflaterState.StartingSmallData:
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A = DeflaterState.HandlingSmallData;
			goto case DeflaterState.HandlingSmallData;
		case DeflaterState.HandlingSmallData:
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
			break;
		}
		return _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020;
	}

	bool IDeflater.Finish(byte[] outputBuffer, out int bytesRead)
	{
		if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A == DeflaterState.NotStarted)
		{
			bytesRead = 0;
			return true;
		}
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A(outputBuffer);
		if (_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A == DeflaterState.CompressThenCheck || _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A == DeflaterState.HandlingSmallData || _0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A == DeflaterState.SlowDownForIncompressible1)
		{
			_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020);
		}
		_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A();
		bytesRead = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020;
		return true;
	}

	void IDisposable.Dispose()
	{
	}

	protected void Dispose(bool disposing)
	{
	}

	private bool _0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A(double P_0)
	{
		return P_0 <= 1.0;
	}

	private void _0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020()
	{
		_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A._0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020();
	}

	private void _0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A()
	{
		_0020_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020.GetBlock(null, _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020, isFinal: true);
	}
}
internal class _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A : Stream
{
	internal delegate void _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020(byte[] array, int offset, int count, bool isAsync);

	private enum WorkerType : byte
	{
		Managed,
		Unknown
	}

	internal const int _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A = 8192;

	private Stream _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020;

	private CompressionMode _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A;

	private bool _0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020;

	private _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020 _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A;

	private IDeflater _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020;

	private byte[] _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A;

	private int _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A;

	private readonly AsyncCallback _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020;

	private readonly _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020 _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A;

	private IFileFormatWriter _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020;

	private bool _0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A;

	private bool _0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020;

	public Stream BaseStream => _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020;

	public override bool CanRead
	{
		get
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 == null)
			{
				return false;
			}
			if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A == CompressionMode.Decompress)
			{
				return _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.CanRead;
			}
			return false;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 == null)
			{
				return false;
			}
			if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A == CompressionMode.Compress)
			{
				return _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.CanWrite;
			}
			return false;
		}
	}

	public override bool CanSeek => false;

	public override long Length
	{
		get
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
		set
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
	}

	public _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(Stream stream, CompressionMode mode)
		: this(stream, mode, leaveOpen: false)
	{
	}

	public _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(Stream stream, CompressionMode mode, bool leaveOpen)
	{
		if (stream == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_0020_000A);
		}
		if (CompressionMode.Compress != mode && mode != CompressionMode.Decompress)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_0020_0020), _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_0020_000A_000A);
		}
		_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 = stream;
		_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A = mode;
		_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020 = leaveOpen;
		switch (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A)
		{
		case CompressionMode.Decompress:
			if (!_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.CanRead)
			{
				throw new ArgumentException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_0020_000A_0020), _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_0020_000A);
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020();
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020;
			break;
		case CompressionMode.Compress:
			if (!_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.CanWrite)
			{
				throw new ArgumentException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_0020_0020_000A), _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_0020_000A);
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A();
			_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A = _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A;
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020;
			break;
		}
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A = new byte[8192];
	}

	private static IDeflater _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A()
	{
		if (_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020() == WorkerType.Managed)
		{
			return new _0020_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020();
		}
		throw new SystemException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_0020_0020_0020);
	}

	[SecuritySafeCritical]
	private static WorkerType _0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020()
	{
		return WorkerType.Managed;
	}

	internal void _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A(IFileFormatReader P_0)
	{
		if (P_0 != null)
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A._0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A(P_0);
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A(IFileFormatWriter P_0)
	{
		if (P_0 != null)
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 = P_0;
		}
	}

	public override void Flush()
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
	}

	public override int Read(byte[] array, int offset, int count)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020();
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(array, offset, count);
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
		int num = offset;
		int num2 = count;
		while (true)
		{
			int num3 = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Inflate(array, num, num2);
			num += num3;
			num2 -= num3;
			if (num2 == 0 || _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Finished())
			{
				break;
			}
			int num4 = _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.Read(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A.Length);
			if (num4 == 0)
			{
				break;
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.SetInput(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, num4);
		}
		return count - num2;
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_000A_000A_000A);
		}
		if (P_1 < 0)
		{
			throw new ArgumentOutOfRangeException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_000A_000A_0020);
		}
		if (P_2 < 0)
		{
			throw new ArgumentOutOfRangeException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_000A_0020_000A);
		}
		if (P_0.Length - P_1 < P_2)
		{
			throw new ArgumentException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_000A_0020_0020));
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A()
	{
		if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 == null)
		{
			throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020()
	{
		if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A != CompressionMode.Decompress)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_0020_000A_000A));
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A()
	{
		if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_0020_000A_0020));
		}
	}

	public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020();
		if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A != 0)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_0020_0020_000A));
		}
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(array, offset, count);
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
		Interlocked.Increment(ref _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A);
		try
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = new _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(this, asyncState, asyncCallback, array, offset, count);
			obj.isWrite = false;
			int num = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Inflate(array, offset, count);
			if (num != 0)
			{
				obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020: true, num);
				return obj;
			}
			if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Finished())
			{
				obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(_0020: true, 0);
				return obj;
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.BeginRead(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A.Length, _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020, obj);
			obj._0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A &= obj.IsCompleted;
			return obj;
		}
		catch
		{
			Interlocked.Decrement(ref _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A);
			throw;
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020(IAsyncResult P_0)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = (_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A)P_0.AsyncState;
		obj._0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A &= P_0.CompletedSynchronously;
		int num = 0;
		try
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
			num = _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.EndRead(P_0);
			if (num <= 0)
			{
				obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(0);
				return;
			}
			_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.SetInput(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, num);
			num = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Inflate(obj.buffer, obj.offset, obj.count);
			if (num == 0 && !_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A.Finished())
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.BeginRead(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A.Length, _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020, obj);
			}
			else
			{
				obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(num);
			}
		}
		catch (Exception ex)
		{
			obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(ex);
		}
	}

	public override int EndRead(IAsyncResult asyncResult)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020();
		_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(asyncResult);
		_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = (_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A)asyncResult;
		_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(obj);
		if (obj._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 is Exception ex)
		{
			throw ex;
		}
		return (int)obj._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020;
	}

	public override void Write(byte[] array, int offset, int count)
	{
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A();
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(array, offset, count);
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(array, offset, count, _0020_000A_000A: false);
	}

	internal void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A(byte[] P_0, int P_1, int P_2, bool P_3)
	{
		_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(P_0, P_1, P_2);
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(P_3);
		_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020.SetInput(P_0, P_1, P_2);
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(P_3);
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(bool P_0)
	{
		while (!_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020.NeedsInput())
		{
			int deflateOutput = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020.GetDeflateOutput(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A);
			if (deflateOutput > 0)
			{
				_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, deflateOutput, P_0);
			}
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A(byte[] P_0, int P_1, int P_2, bool P_3)
	{
		if (P_3)
		{
			IAsyncResult asyncResult = _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.BeginWrite(P_0, P_1, P_2, null, null);
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.EndWrite(asyncResult);
		}
		else
		{
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.Write(P_0, P_1, P_2);
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020(byte[] P_0, int P_1, int P_2)
	{
		if (P_2 <= 0)
		{
			return;
		}
		_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020 = true;
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 != null)
		{
			if (!_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A)
			{
				byte[] header = _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020.GetHeader();
				_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.Write(header, 0, header.Length);
				_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A = true;
			}
			_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020.UpdateWithBytesRead(P_0, P_1, P_2);
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A(bool P_0)
	{
		if (!P_0 || _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 == null)
		{
			return;
		}
		Flush();
		if (_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A != CompressionMode.Compress)
		{
			return;
		}
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020)
		{
			_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020(_0020: false);
			bool flag;
			do
			{
				flag = _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020.Finish(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, out var bytesRead);
				if (bytesRead > 0)
				{
					_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, 0, bytesRead, _0020_000A_000A: false);
				}
			}
			while (!flag);
		}
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020 != null && _0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A)
		{
			byte[] footer = _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020.GetFooter();
			_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.Write(footer, 0, footer.Length);
		}
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A(disposing);
		}
		finally
		{
			try
			{
				if (disposing && !_0020_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020 && _0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 != null)
				{
					_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020.Dispose();
				}
			}
			finally
			{
				_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020 = null;
				try
				{
					if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020 != null)
					{
						_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020.Dispose();
					}
				}
				finally
				{
					_0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020 = null;
					base.Dispose(disposing);
				}
			}
		}
	}

	public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A();
		if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A != 0)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_0020_0020_000A));
		}
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020(array, offset, count);
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
		Interlocked.Increment(ref _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A);
		try
		{
			_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = new _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(this, asyncState, asyncCallback, array, offset, count);
			obj.isWrite = true;
			_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A.BeginInvoke(array, offset, count, isAsync: true, _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020, obj);
			obj._0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A &= obj.IsCompleted;
			return obj;
		}
		catch
		{
			Interlocked.Decrement(ref _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A);
			throw;
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020(IAsyncResult P_0)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = (_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A)P_0.AsyncState;
		obj._0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A &= P_0.CompletedSynchronously;
		try
		{
			_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A.EndInvoke(P_0);
		}
		catch (Exception ex)
		{
			obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(ex);
			return;
		}
		obj._0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(null);
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_000A();
		_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(asyncResult);
		_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A obj = (_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A)asyncResult;
		_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(obj);
		if (obj._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 is Exception ex)
		{
			throw ex;
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A(IAsyncResult P_0)
	{
		if (_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A != 1)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_0020_0020_0020_0020));
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A);
		}
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020_000A();
		if (!(P_0 is _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A))
		{
			throw new ArgumentNullException(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A);
		}
	}

	private void _0020_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020(_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A P_0)
	{
		try
		{
			if (!P_0.IsCompleted)
			{
				P_0.AsyncWaitHandle.WaitOne();
			}
		}
		finally
		{
			Interlocked.Decrement(ref _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A);
			P_0._0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020();
		}
	}
}
internal class _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A : IAsyncResult
{
	public byte[] buffer;

	public int offset;

	public int count;

	public bool isWrite;

	private object _0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A;

	private object _0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020;

	private AsyncCallback _0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A;

	private object _0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020;

	internal bool _0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A;

	private int _0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020;

	private int _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A;

	private object _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020;

	public object AsyncState => _0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020;

	public WaitHandle AsyncWaitHandle
	{
		get
		{
			int num = _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A;
			if (_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020 == null)
			{
				Interlocked.CompareExchange(ref _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020, new ManualResetEvent(num != 0), null);
			}
			ManualResetEvent manualResetEvent = (ManualResetEvent)_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020;
			if (num == 0 && _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A != 0)
			{
				manualResetEvent.Set();
			}
			return manualResetEvent;
		}
	}

	public bool CompletedSynchronously => _0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A;

	public bool IsCompleted => _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A != 0;

	internal object _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020 => _0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020;

	public _0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A(object asyncObject, object asyncState, AsyncCallback asyncCallback, byte[] buffer, int offset, int count)
	{
		this.buffer = buffer;
		this.offset = offset;
		this.count = count;
		_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A = true;
		_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A = asyncObject;
		_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020 = asyncState;
		_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A = asyncCallback;
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020()
	{
		if (_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020 != null)
		{
			((ManualResetEvent)_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020).Close();
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(bool P_0, object P_1)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(P_0, P_1);
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_000A(object P_0)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(P_0);
	}

	private void _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(bool P_0, object P_1)
	{
		_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A = P_0;
		_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(P_1);
	}

	private void _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020(object P_0)
	{
		_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020 = P_0;
		Interlocked.Increment(ref _0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A);
		if (_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020 != null)
		{
			((ManualResetEvent)_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020).Set();
		}
		if (Interlocked.Increment(ref _0020_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020) == 1 && _0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A != null)
		{
			_0020_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A(this);
		}
	}
}
internal class _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A
{
	private _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020 _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020;

	private _0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020 _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A;

	private double _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020;

	internal int _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A => _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.BytesAvailable;

	internal _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020 => _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.UnprocessedInput;

	internal double _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A => _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020;

	public _0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A()
	{
		_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020 = new _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020();
		_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A = new _0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020();
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020()
	{
		_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.FlushWindow();
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020(_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 P_0, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_1, int P_2)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(P_1);
		_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(P_0, P_1, P_2);
		_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(P_1);
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_000A(_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 P_0, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_1)
	{
		_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(P_0, P_1, -1);
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(P_0);
	}

	internal void _0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(P_0);
	}

	private void _0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 P_0, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_1, int P_2)
	{
		int num = P_1._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020;
		int num2 = 0;
		int num3 = _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A + P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A;
		do
		{
			int num4 = ((P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A < _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.FreeWindowSpace) ? P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A : _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.FreeWindowSpace);
			if (P_2 >= 1)
			{
				num4 = Math.Min(num4, P_2 - num2);
			}
			if (num4 > 0)
			{
				_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.CopyBytes(P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020, P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020, num4);
				P_0._0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_000A(num4);
				num2 += num4;
			}
			_0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(P_1);
		}
		while (_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(P_1) && _0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(P_0) && (P_2 < 1 || num2 < P_2));
		int num5 = P_1._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020 - num;
		int num6 = _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A + P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A;
		int num7 = num3 - num6;
		if (num5 != 0)
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020 = (double)num5 / (double)num7;
		}
	}

	private void _0020_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		while (_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020.BytesAvailable > 0 && _0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(P_0))
		{
			_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020._0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A);
			if (_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 == MatchState.HasSymbol)
			{
				_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A(_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A, P_0);
				continue;
			}
			if (_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 == MatchState.HasMatch)
			{
				_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020, _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A, P_0);
				continue;
			}
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A(_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A, P_0);
			_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(_0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020, _0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A, P_0);
		}
	}

	private bool _0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A(_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 P_0)
	{
		if (P_0._0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A <= 0)
		{
			return _0020_0020_000A_000A_0020_0020_0020_000A_000A_000A_000A > 0;
		}
		return true;
	}

	private bool _0020_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		return P_0._0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A > 16;
	}

	private void _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		uint num = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020[256];
		int num2 = (int)(num & 0x1F);
		P_0._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(num2, num >> 5);
	}

	internal static void _0020_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020(int P_0, int P_1, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_2)
	{
		uint num = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020[254 + P_0];
		int num2 = (int)(num & 0x1F);
		if (num2 <= 16)
		{
			P_2._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(num2, num >> 5);
		}
		else
		{
			P_2._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(16, (num >> 5) & 0xFFFF);
			P_2._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(num2 - 16, num >> 21);
		}
		num = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A[_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A(P_1)];
		P_2._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A((int)(num & 0xF), num >> 8);
		int num3 = (int)((num >> 4) & 0xF);
		if (num3 != 0)
		{
			P_2._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(num3, (uint)P_1 & _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020[num3]);
		}
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A(byte P_0, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_1)
	{
		uint num = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020[P_0];
		P_1._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A((int)(num & 0x1F), num >> 5);
	}

	internal static void _0020_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A P_0)
	{
		P_0._0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(_0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020, 0, _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020._0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020.Length);
		P_0._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(9, 34u);
	}
}
internal static class _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020
{
	internal static readonly byte[] _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020;

	internal static readonly byte[] _0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A;

	internal static readonly uint[] _0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020;

	internal static readonly uint[] _0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A;

	internal static readonly uint[] _0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020;

	internal static readonly byte[] _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A;

	internal static readonly byte[] _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020;

	internal const int _0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_000A = 256;

	internal const int _0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020 = 29;

	internal const int _0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_000A = 30;

	internal const uint _0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020 = 34u;

	internal const int _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_000A = 9;

	internal const uint _0020_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020 = 0u;

	internal const int _0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A = 3;

	internal const uint _0020_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020 = 1u;

	internal const int _0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A = 3;

	internal const int _0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020 = 16;

	private static byte[] _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A;

	static _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020()
	{
		_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020 = new byte[98]
		{
			236, 189, 7, 96, 28, 73, 150, 37, 38, 47,
			109, 202, 123, 127, 74, 245, 74, 215, 224, 116,
			161, 8, 128, 96, 19, 36, 216, 144, 64, 16,
			236, 193, 136, 205, 230, 146, 236, 29, 105, 71,
			35, 41, 171, 42, 129, 202, 101, 86, 101, 93,
			102, 22, 64, 204, 237, 157, 188, 247, 222, 123,
			239, 189, 247, 222, 123, 239, 189, 247, 186, 59,
			157, 78, 39, 247, 223, 255, 63, 92, 102, 100,
			1, 108, 246, 206, 74, 218, 201, 158, 33, 128,
			170, 200, 31, 63, 126, 124, 31, 63
		};
		_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_000A = new byte[98]
		{
			237, 189, 7, 96, 28, 73, 150, 37, 38, 47,
			109, 202, 123, 127, 74, 245, 74, 215, 224, 116,
			161, 8, 128, 96, 19, 36, 216, 144, 64, 16,
			236, 193, 136, 205, 230, 146, 236, 29, 105, 71,
			35, 41, 171, 42, 129, 202, 101, 86, 101, 93,
			102, 22, 64, 204, 237, 157, 188, 247, 222, 123,
			239, 189, 247, 222, 123, 239, 189, 247, 186, 59,
			157, 78, 39, 247, 223, 255, 63, 92, 102, 100,
			1, 108, 246, 206, 74, 218, 201, 158, 33, 128,
			170, 200, 31, 63, 126, 124, 31, 63
		};
		_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020 = new uint[513]
		{
			55278u, 317422u, 186350u, 448494u, 120814u, 382958u, 251886u, 514030u, 14318u, 51180u,
			294u, 276462u, 145390u, 407534u, 79854u, 341998u, 210926u, 473070u, 47086u, 309230u,
			178158u, 440302u, 112622u, 374766u, 243694u, 505838u, 30702u, 292846u, 161774u, 423918u,
			6125u, 96238u, 1318u, 358382u, 9194u, 116716u, 227310u, 489454u, 137197u, 25578u,
			2920u, 3817u, 23531u, 5098u, 1127u, 7016u, 3175u, 12009u, 1896u, 5992u,
			3944u, 7913u, 8040u, 16105u, 21482u, 489u, 232u, 8681u, 4585u, 4328u,
			12777u, 13290u, 2280u, 63470u, 325614u, 6376u, 2537u, 1256u, 10729u, 5352u,
			6633u, 29674u, 56299u, 3304u, 15339u, 194542u, 14825u, 3050u, 1513u, 19434u,
			9705u, 10220u, 5609u, 13801u, 3561u, 11242u, 75756u, 48107u, 456686u, 129006u,
			42988u, 31723u, 391150u, 64491u, 260078u, 522222u, 4078u, 806u, 615u, 2663u,
			1639u, 1830u, 7400u, 744u, 3687u, 166u, 108524u, 11753u, 1190u, 359u,
			2407u, 678u, 1383u, 71661u, 1702u, 422u, 1446u, 3431u, 4840u, 2792u,
			7657u, 6888u, 2027u, 202733u, 26604u, 38893u, 169965u, 266222u, 135150u, 397294u,
			69614u, 331758u, 200686u, 462830u, 36846u, 298990u, 167918u, 430062u, 102382u, 364526u,
			233454u, 495598u, 20462u, 282606u, 151534u, 413678u, 85998u, 348142u, 217070u, 479214u,
			53230u, 315374u, 184302u, 446446u, 118766u, 380910u, 249838u, 511982u, 12270u, 274414u,
			143342u, 405486u, 77806u, 339950u, 208878u, 471022u, 45038u, 307182u, 176110u, 438254u,
			110574u, 372718u, 241646u, 503790u, 28654u, 290798u, 159726u, 421870u, 94190u, 356334u,
			225262u, 487406u, 61422u, 323566u, 192494u, 454638u, 126958u, 389102u, 258030u, 520174u,
			8174u, 270318u, 139246u, 401390u, 73710u, 335854u, 204782u, 466926u, 40942u, 303086u,
			172014u, 434158u, 106478u, 368622u, 237550u, 499694u, 24558u, 286702u, 155630u, 417774u,
			90094u, 352238u, 221166u, 483310u, 57326u, 319470u, 188398u, 450542u, 122862u, 385006u,
			253934u, 516078u, 16366u, 278510u, 147438u, 409582u, 81902u, 344046u, 212974u, 475118u,
			49134u, 311278u, 180206u, 442350u, 114670u, 376814u, 245742u, 507886u, 32750u, 294894u,
			163822u, 425966u, 98286u, 104429u, 235501u, 22509u, 360430u, 153581u, 229358u, 88045u,
			491502u, 219117u, 65518u, 327662u, 196590u, 458734u, 131054u, 132u, 3u, 388u,
			68u, 324u, 197u, 709u, 453u, 966u, 1990u, 38u, 1062u, 935u,
			2983u, 1959u, 4007u, 551u, 1575u, 2599u, 3623u, 104u, 2152u, 4200u,
			6248u, 873u, 4969u, 9065u, 13161u, 1770u, 9962u, 18154u, 26346u, 5867u,
			14059u, 22251u, 30443u, 38635u, 46827u, 55019u, 63211u, 15852u, 32236u, 48620u,
			65004u, 81388u, 97772u, 114156u, 130540u, 27629u, 60397u, 93165u, 125933u, 158701u,
			191469u, 224237u, 257005u, 1004u, 17388u, 33772u, 50156u, 66540u, 82924u, 99308u,
			115692u, 7150u, 39918u, 72686u, 105454u, 138222u, 170990u, 203758u, 236526u, 269294u,
			302062u, 334830u, 367598u, 400366u, 433134u, 465902u, 498670u, 92144u, 223216u, 354288u,
			485360u, 616432u, 747504u, 878576u, 1009648u, 1140720u, 1271792u, 1402864u, 1533936u, 1665008u,
			1796080u, 1927152u, 2058224u, 34799u, 100335u, 165871u, 231407u, 296943u, 362479u, 428015u,
			493551u, 559087u, 624623u, 690159u, 755695u, 821231u, 886767u, 952303u, 1017839u, 59376u,
			190448u, 321520u, 452592u, 583664u, 714736u, 845808u, 976880u, 1107952u, 1239024u, 1370096u,
			1501168u, 1632240u, 1763312u, 1894384u, 2025456u, 393203u, 917491u, 1441779u, 1966067u, 2490355u,
			3014643u, 3538931u, 4063219u, 4587507u, 5111795u, 5636083u, 6160371u, 6684659u, 7208947u, 7733235u,
			8257523u, 8781811u, 9306099u, 9830387u, 10354675u, 10878963u, 11403251u, 11927539u, 12451827u, 12976115u,
			13500403u, 14024691u, 14548979u, 15073267u, 15597555u, 16121843u, 16646131u, 262131u, 786419u, 1310707u,
			1834995u, 2359283u, 2883571u, 3407859u, 3932147u, 4456435u, 4980723u, 5505011u, 6029299u, 6553587u,
			7077875u, 7602163u, 8126451u, 8650739u, 9175027u, 9699315u, 10223603u, 10747891u, 11272179u, 11796467u,
			12320755u, 12845043u, 13369331u, 13893619u, 14417907u, 14942195u, 15466483u, 15990771u, 16515059u, 524275u,
			1048563u, 1572851u, 2097139u, 2621427u, 3145715u, 3670003u, 4194291u, 4718579u, 5242867u, 5767155u,
			6291443u, 6815731u, 7340019u, 7864307u, 8388595u, 8912883u, 9437171u, 9961459u, 10485747u, 11010035u,
			11534323u, 12058611u, 12582899u, 13107187u, 13631475u, 14155763u, 14680051u, 15204339u, 15728627u, 16252915u,
			16777203u, 124913u, 255985u, 387057u, 518129u, 649201u, 780273u, 911345u, 1042417u, 1173489u,
			1304561u, 1435633u, 1566705u, 1697777u, 1828849u, 1959921u, 2090993u, 2222065u, 2353137u, 2484209u,
			2615281u, 2746353u, 2877425u, 3008497u, 3139569u, 3270641u, 3401713u, 3532785u, 3663857u, 3794929u,
			3926001u, 4057073u, 18411u
		};
		_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_000A = new uint[32]
		{
			3846u, 130826u, 261899u, 524043u, 65305u, 16152u, 48936u, 32552u, 7991u, 24375u,
			3397u, 12102u, 84u, 7509u, 2148u, 869u, 1140u, 4981u, 3204u, 644u,
			2708u, 1684u, 3748u, 420u, 2484u, 2997u, 1476u, 7109u, 2005u, 6101u,
			0u, 256u
		};
		_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020 = new uint[16]
		{
			0u, 1u, 3u, 7u, 15u, 31u, 63u, 127u, 255u, 511u,
			1023u, 2047u, 4095u, 8191u, 16383u, 32767u
		};
		_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A = new byte[29]
		{
			0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
			1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
			4, 4, 4, 4, 5, 5, 5, 5, 0
		};
		_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020 = new byte[32]
		{
			0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
			4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
			9, 9, 10, 10, 11, 11, 12, 12, 13, 13,
			0, 0
		};
		_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A = new byte[512];
		int num = 0;
		int i;
		for (i = 0; i < 16; i++)
		{
			for (int j = 0; j < 1 << (int)_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020[i]; j++)
			{
				_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A[num++] = (byte)i;
			}
		}
		num >>= 7;
		for (; i < 30; i++)
		{
			for (int k = 0; k < 1 << _0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020[i] - 7; k++)
			{
				_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A[256 + num++] = (byte)i;
			}
		}
	}

	internal static int _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_000A(int P_0)
	{
		return _0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A[(P_0 < 256) ? P_0 : (256 + (P_0 >> 7))];
	}

	public static uint BitReverse(uint code, int length)
	{
		uint num = 0u;
		do
		{
			num |= code & 1;
			num <<= 1;
			code >>= 1;
		}
		while (--length > 0);
		return num >> 1;
	}
}
internal class _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020
{
	private byte[] _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A;

	private int _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;

	private int _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A;

	private const int _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020 = 4;

	private const int _0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A = 2048;

	private const int _0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020 = 2047;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A = 8192;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020 = 8191;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A = 16384;

	internal const int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020 = 258;

	internal const int _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A = 3;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020 = 32;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_000A = 4;

	private const int _0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020 = 32;

	private const int _0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A = 6;

	private ushort[] _0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020;

	private ushort[] _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A;

	public int BytesAvailable => _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;

	public _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020 UnprocessedInput => new _0020_0020_000A_0020_000A_0020_000A_0020_000A_0020_0020
	{
		_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020 = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A,
		_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_0020 = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020,
		_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A = _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020
	};

	public int FreeWindowSpace => 16384 - _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A;

	public _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020()
	{
		_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020();
	}

	public void FlushWindow()
	{
		_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020();
	}

	private void _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020()
	{
		_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A = new byte[16646];
		_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020 = new ushort[8450];
		_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A = new ushort[2048];
		_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = 8192;
		_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
	}

	public void CopyBytes(byte[] inputBuffer, int startIndex, int count)
	{
		Array.Copy(inputBuffer, startIndex, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A, count);
		_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A += count;
	}

	public void MoveWindows()
	{
		Array.Copy(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - 8192, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, 0, 8192);
		for (int i = 0; i < 2048; i++)
		{
			int num = _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[i] - 8192;
			if (num <= 0)
			{
				_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[i] = 0;
			}
			else
			{
				_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[i] = (ushort)num;
			}
		}
		for (int i = 0; i < 8192; i++)
		{
			long num2 = (long)_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[i] - 8192L;
			if (num2 <= 0)
			{
				_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[i] = 0;
			}
			else
			{
				_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[i] = (ushort)num2;
			}
		}
		_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 = 8192;
		_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
	}

	private uint _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(uint P_0, byte P_1)
	{
		return (P_0 << 4) ^ P_1;
	}

	private uint _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ref uint P_0)
	{
		P_0 = _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(P_0, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + 2]);
		uint num = _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[P_0 & 0x7FF];
		_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[P_0 & 0x7FF] = (ushort)_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
		_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 & 0x1FFF] = (ushort)num;
		return num;
	}

	private void _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(ref uint P_0, int P_1)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 <= P_1)
		{
			_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 += P_1 - 1;
			return;
		}
		while (--P_1 > 0)
		{
			_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ref P_0);
			_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020++;
		}
	}

	internal bool _0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020(_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020 P_0)
	{
		uint num = _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(0u, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020]);
		num = _0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A(num, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + 1]);
		int num2 = 0;
		int num3;
		if (_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 <= 3)
		{
			num3 = 0;
		}
		else
		{
			int num4 = (int)_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ref num);
			if (num4 != 0)
			{
				num3 = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(num4, out num2, 32, 32);
				if (_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + num3 > _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A)
				{
					num3 = _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
				}
			}
			else
			{
				num3 = 0;
			}
		}
		if (num3 < 3)
		{
			P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 = MatchState.HasSymbol;
			P_0._0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020];
			_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020++;
		}
		else
		{
			_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020++;
			if (num3 <= 6)
			{
				int num5 = 0;
				int num6 = (int)_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020(ref num);
				int num7;
				if (num6 != 0)
				{
					num7 = _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(num6, out num5, (num3 < 4) ? 32 : 8, 32);
					if (_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + num7 > _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A)
					{
						num7 = _0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_000A - _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020;
					}
				}
				else
				{
					num7 = 0;
				}
				if (num7 > num3)
				{
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 = MatchState.HasSymbolAndMatch;
					P_0._0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - 1];
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A = num5;
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020 = num7;
					_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020++;
					num3 = num7;
					_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(ref num, num3);
				}
				else
				{
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 = MatchState.HasMatch;
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A = num2;
					P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020 = num3;
					num3--;
					_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020++;
					_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(ref num, num3);
				}
			}
			else
			{
				P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020 = MatchState.HasMatch;
				P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A = num2;
				P_0._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020 = num3;
				_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A(ref num, num3);
			}
		}
		if (_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 == 16384)
		{
			MoveWindows();
		}
		return true;
	}

	private int _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A(int P_0, out int P_1, int P_2, int P_3)
	{
		int num = 0;
		int num2 = 0;
		int num3 = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - 8192;
		byte b = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020];
		while (P_0 > num3)
		{
			if (_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[P_0 + num] == b)
			{
				int i;
				for (i = 0; i < 258 && _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + i] == _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[P_0 + i]; i++)
				{
				}
				if (i > num)
				{
					num = i;
					num2 = P_0;
					if (i > 32)
					{
						break;
					}
					b = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 + i];
				}
			}
			if (--P_2 == 0)
			{
				break;
			}
			P_0 = _0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[P_0 & 0x1FFF];
		}
		P_1 = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - num2 - 1;
		if (num == 3 && P_1 >= 16384)
		{
			return 0;
		}
		return num;
	}

	[Conditional("DEBUG")]
	private void _0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020()
	{
		for (int i = 0; i < 2048; i++)
		{
			ushort num = _0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A[i];
			while (num != 0 && _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - num < 8192)
			{
				ushort num2 = _0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020[num & 0x1FFF];
				if (_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_0020 - num2 >= 8192)
				{
					break;
				}
				num = num2;
			}
		}
	}

	private uint _0020_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A(int P_0)
	{
		return (uint)(((_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[P_0] << 8) ^ (_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[P_0 + 1] << 4) ^ _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[P_0 + 2]) & 0x7FF);
	}
}
internal class _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A : IFileFormatReader
{
	internal enum GzipHeaderState
	{
		ReadingID1,
		ReadingID2,
		ReadingCM,
		ReadingFLG,
		ReadingMMTime,
		ReadingXFL,
		ReadingOS,
		ReadingXLen1,
		ReadingXLen2,
		ReadingXLenData,
		ReadingFileName,
		ReadingComment,
		ReadingCRC16Part1,
		ReadingCRC16Part2,
		Done,
		ReadingCRC,
		ReadingFileSize
	}

	[Flags]
	internal enum GZipOptionalHeaderFlags
	{
		CRCFlag = 2,
		ExtraFieldsFlag = 4,
		FileNameFlag = 8,
		CommentFlag = 0x10
	}

	private GzipHeaderState _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020;

	private GzipHeaderState _0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A;

	private int _0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020;

	private int _0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A;

	private uint _0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020;

	private uint _0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020;

	private uint _0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020;

	private long _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A;

	public _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A()
	{
		Reset();
	}

	public void Reset()
	{
		_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingID1;
		_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A = GzipHeaderState.ReadingCRC;
		_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 = 0u;
		_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = 0u;
	}

	public bool ReadHeader(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input)
	{
		switch (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020)
		{
		case GzipHeaderState.ReadingID1:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			if (bits != 31)
			{
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_0020_000A));
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingID2;
			goto case GzipHeaderState.ReadingID2;
		}
		case GzipHeaderState.ReadingID2:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			if (bits != 139)
			{
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_0020_000A));
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingCM;
			goto case GzipHeaderState.ReadingCM;
		}
		case GzipHeaderState.ReadingCM:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			if (bits != 8)
			{
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_0020_0020));
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingFLG;
			goto case GzipHeaderState.ReadingFLG;
		}
		case GzipHeaderState.ReadingFLG:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020 = bits;
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingMMTime;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			goto case GzipHeaderState.ReadingMMTime;
		}
		case GzipHeaderState.ReadingMMTime:
		{
			int bits = 0;
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < 4)
			{
				bits = input.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingXFL;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			goto case GzipHeaderState.ReadingXFL;
		}
		case GzipHeaderState.ReadingXFL:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingOS;
			goto case GzipHeaderState.ReadingOS;
		}
		case GzipHeaderState.ReadingOS:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingXLen1;
			goto case GzipHeaderState.ReadingXLen1;
		}
		case GzipHeaderState.ReadingXLen1:
			if ((_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020 & 4) != 0)
			{
				int bits = input.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A = bits;
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingXLen2;
				goto case GzipHeaderState.ReadingXLen2;
			}
			goto case GzipHeaderState.ReadingFileName;
		case GzipHeaderState.ReadingXLen2:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A |= bits << 8;
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingXLenData;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			goto case GzipHeaderState.ReadingXLenData;
		}
		case GzipHeaderState.ReadingXLenData:
		{
			int bits = 0;
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < _0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A)
			{
				bits = input.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingFileName;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			goto case GzipHeaderState.ReadingFileName;
		}
		case GzipHeaderState.ReadingFileName:
			if ((_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020 & 8) == 0)
			{
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingComment;
			}
			else
			{
				int bits;
				do
				{
					bits = input.GetBits(8);
					if (bits < 0)
					{
						return false;
					}
				}
				while (bits != 0);
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingComment;
			}
			goto case GzipHeaderState.ReadingComment;
		case GzipHeaderState.ReadingComment:
			if ((_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020 & 0x10) == 0)
			{
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingCRC16Part1;
			}
			else
			{
				int bits;
				do
				{
					bits = input.GetBits(8);
					if (bits < 0)
					{
						return false;
					}
				}
				while (bits != 0);
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingCRC16Part1;
			}
			goto case GzipHeaderState.ReadingCRC16Part1;
		case GzipHeaderState.ReadingCRC16Part1:
		{
			if ((_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_0020 & 2) == 0)
			{
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.Done;
				goto case GzipHeaderState.Done;
			}
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.ReadingCRC16Part2;
			goto case GzipHeaderState.ReadingCRC16Part2;
		}
		case GzipHeaderState.ReadingCRC16Part2:
		{
			int bits = input.GetBits(8);
			if (bits < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020 = GzipHeaderState.Done;
			goto case GzipHeaderState.Done;
		}
		case GzipHeaderState.Done:
			return true;
		default:
			throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_000A));
		}
	}

	public bool ReadFooter(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input)
	{
		input.SkipToByteBoundary();
		if (_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A == GzipHeaderState.ReadingCRC)
		{
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < 4)
			{
				int bits = input.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 |= (uint)(bits << 8 * _0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020);
				_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++;
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A = GzipHeaderState.ReadingFileSize;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
		}
		if (_0020_000A_0020_000A_000A_0020_000A_000A_0020_000A_000A == GzipHeaderState.ReadingFileSize)
		{
			if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 == 0)
			{
				_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A = 0u;
			}
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < 4)
			{
				int bits2 = input.GetBits(8);
				if (bits2 < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A |= (uint)(bits2 << 8 * _0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020);
				_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++;
			}
		}
		return true;
	}

	public void UpdateWithBytesRead(byte[] buffer, int offset, int copied)
	{
		_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020 = _0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A.UpdateCrc32(_0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020, buffer, offset, copied);
		long num = _0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A + (uint)copied;
		if (num >= 4294967296L)
		{
			num %= 4294967296L;
		}
		_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A = num;
	}

	public void Validate()
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_0020 != _0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)
		{
			throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_000A_000A));
		}
		if (_0020_000A_0020_000A_000A_0020_000A_0020_000A_0020_000A != _0020_000A_0020_000A_000A_0020_000A_0020_000A_000A_000A)
		{
			throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_0020_000A_000A_000A_0020));
		}
	}
}
internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020 : Stream
{
	private _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A;

	public override bool CanRead
	{
		get
		{
			if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
			{
				return false;
			}
			return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.CanRead;
		}
	}

	public override bool CanWrite
	{
		get
		{
			if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
			{
				return false;
			}
			return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.CanWrite;
		}
	}

	public override bool CanSeek
	{
		get
		{
			if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
			{
				return false;
			}
			return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.CanSeek;
		}
	}

	public override long Length
	{
		get
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
	}

	public override long Position
	{
		get
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
		set
		{
			throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
		}
	}

	public Stream BaseStream
	{
		get
		{
			if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A != null)
			{
				return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.BaseStream;
			}
			return null;
		}
	}

	public _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(Stream stream, CompressionMode mode)
		: this(stream, mode, leaveOpen: false)
	{
	}

	public _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020(Stream stream, CompressionMode mode, bool leaveOpen)
	{
		_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A = new _0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A(stream, mode, leaveOpen);
		_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A(mode);
	}

	private void _0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A(CompressionMode P_0)
	{
		if (P_0 == CompressionMode.Compress)
		{
			IFileFormatWriter fileFormatWriter = new _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A();
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A._0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A(fileFormatWriter);
		}
		else
		{
			IFileFormatReader fileFormatReader = new _0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A();
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A._0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A(fileFormatReader);
		}
	}

	public override void Flush()
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.Flush();
	}

	public override long Seek(long offset, SeekOrigin origin)
	{
		throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
	}

	public override void SetLength(long value)
	{
		throw new NotSupportedException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_000A));
	}

	public override IAsyncResult BeginRead(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.BeginRead(array, offset, count, asyncCallback, asyncState);
	}

	public override int EndRead(IAsyncResult asyncResult)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.EndRead(asyncResult);
	}

	public override IAsyncResult BeginWrite(byte[] array, int offset, int count, AsyncCallback asyncCallback, object asyncState)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.BeginWrite(array, offset, count, asyncCallback, asyncState);
	}

	public override void EndWrite(IAsyncResult asyncResult)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new InvalidOperationException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.EndWrite(asyncResult);
	}

	public override int Read(byte[] array, int offset, int count)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		return _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.Read(array, offset, count);
	}

	public override void Write(byte[] array, int offset, int count)
	{
		if (_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A == null)
		{
			throw new ObjectDisposedException(null, _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_0020_000A_0020));
		}
		_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.Write(array, offset, count);
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing && _0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A != null)
			{
				_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A.Dispose();
			}
			_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A = null;
		}
		finally
		{
			base.Dispose(disposing);
		}
	}
}
internal static class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020
{
	internal const int _0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020 = 3;

	internal const int _0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A = 10;

	internal const long _0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020 = 4294967296L;

	internal const byte _0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_000A = 31;

	internal const byte _0020_000A_0020_000A_000A_000A_0020_0020_0020_000A_0020 = 139;

	internal const byte _0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A = 8;

	internal const int _0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020 = 8;

	internal const byte _0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_000A = 4;

	internal const byte _0020_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020 = 2;
}
internal class _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A : IFileFormatWriter
{
	private byte[] _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A = new byte[10] { 31, 139, 8, 0, 0, 0, 0, 0, 4, 0 };

	private uint _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020;

	private long _0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A;

	internal _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A()
		: this(3)
	{
	}

	internal _0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A(int compressionLevel)
	{
		if (compressionLevel == 10)
		{
			_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A[8] = 2;
		}
	}

	public byte[] GetHeader()
	{
		return _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A;
	}

	public void UpdateWithBytesRead(byte[] buffer, int offset, int bytesToCopy)
	{
		_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020 = _0020_0020_000A_0020_000A_0020_000A_0020_0020_000A_000A.UpdateCrc32(_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020, buffer, offset, bytesToCopy);
		long num = _0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A + (uint)bytesToCopy;
		if (num >= 4294967296L)
		{
			num %= 4294967296L;
		}
		_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A = num;
	}

	public byte[] GetFooter()
	{
		byte[] array = new byte[8];
		_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020(array, _0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020, 0);
		_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020(array, (uint)_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A, 4);
		return array;
	}

	internal void _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020(byte[] P_0, uint P_1, int P_2)
	{
		P_0[P_2] = (byte)P_1;
		P_0[P_2 + 1] = (byte)(P_1 >> 8);
		P_0[P_2 + 2] = (byte)(P_1 >> 16);
		P_0[P_2 + 3] = (byte)(P_1 >> 24);
	}
}
internal class _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A
{
	internal const int _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020 = 288;

	internal const int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A = 32;

	internal const int _0020_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020 = 256;

	internal const int _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A = 19;

	private int _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020;

	private short[] _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;

	private short[] _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A;

	private short[] _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020;

	private byte[] _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A;

	private int _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020;

	private static _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A;

	private static _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020;

	public static _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A StaticLiteralLengthTree => _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A;

	public static _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A StaticDistanceTree => _0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020;

	static _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A()
	{
		_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A());
		_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020 = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020());
	}

	public _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(byte[] codeLengths)
	{
		_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A = codeLengths;
		if (_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length == 288)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020 = 9;
		}
		else
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020 = 7;
		}
		_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020 = (1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020) - 1;
		_0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020();
	}

	private static byte[] _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A()
	{
		byte[] array = new byte[288];
		for (int i = 0; i <= 143; i++)
		{
			array[i] = 8;
		}
		for (int j = 144; j <= 255; j++)
		{
			array[j] = 9;
		}
		for (int k = 256; k <= 279; k++)
		{
			array[k] = 7;
		}
		for (int l = 280; l <= 287; l++)
		{
			array[l] = 8;
		}
		return array;
	}

	private static byte[] _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020()
	{
		byte[] array = new byte[32];
		for (int i = 0; i < 32; i++)
		{
			array[i] = 5;
		}
		return array;
	}

	private uint[] _0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A()
	{
		uint[] array = new uint[17];
		byte[] array2 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A;
		foreach (int num in array2)
		{
			array[num]++;
		}
		array[0] = 0u;
		uint[] array3 = new uint[17];
		uint num2 = 0u;
		for (int j = 1; j <= 16; j++)
		{
			num2 = (array3[j] = num2 + array[j - 1] << 1);
		}
		uint[] array4 = new uint[288];
		for (int k = 0; k < _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length; k++)
		{
			int num3 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A[k];
			if (num3 > 0)
			{
				array4[k] = _0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020.BitReverse(array3[num3], num3);
				array3[num3]++;
			}
		}
		return array4;
	}

	private void _0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020()
	{
		uint[] array = _0020_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A();
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = new short[1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020];
		_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A = new short[2 * _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length];
		_0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020 = new short[2 * _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length];
		short num = (short)_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length;
		for (int i = 0; i < _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A.Length; i++)
		{
			int num2 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A[i];
			if (num2 <= 0)
			{
				continue;
			}
			int num3 = (int)array[i];
			if (num2 <= _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020)
			{
				int num4 = 1 << num2;
				if (num3 >= num4)
				{
					throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_0020));
				}
				int num5 = 1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020 - num2;
				for (int j = 0; j < num5; j++)
				{
					_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A[num3] = (short)i;
					num3 += num4;
				}
				continue;
			}
			int num6 = num2 - _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020;
			int num7 = 1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020;
			int num8 = num3 & ((1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020) - 1);
			short[] array2 = _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;
			do
			{
				short num9 = array2[num8];
				if (num9 == 0)
				{
					array2[num8] = (short)(-num);
					num9 = (short)(-num);
					num++;
				}
				if (num9 > 0)
				{
					throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_0020));
				}
				array2 = (((num3 & num7) != 0) ? _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020 : _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A);
				num8 = -num9;
				num7 <<= 1;
				num6--;
			}
			while (num6 != 0);
			array2[num8] = (short)i;
		}
	}

	public int GetNextSymbol(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input)
	{
		uint num = input.TryLoad16Bits();
		if (input.AvailableBits == 0)
		{
			return -1;
		}
		int num2 = _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A[num & _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020];
		if (num2 < 0)
		{
			uint num3 = (uint)(1 << _0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_0020);
			do
			{
				num2 = -num2;
				num2 = (((num & num3) != 0) ? _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020[num2] : _0020_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A[num2]);
				num3 <<= 1;
			}
			while (num2 < 0);
		}
		int num4 = _0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A[num2];
		if (num4 <= 0)
		{
			throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_0020));
		}
		if (num4 > input.AvailableBits)
		{
			return -1;
		}
		input.SkipBits(num4);
		return num2;
	}
}
internal class _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020
{
	private static readonly byte[] _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A = new byte[29]
	{
		0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
		1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
		4, 4, 4, 4, 5, 5, 5, 5, 0
	};

	private static readonly int[] _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020 = new int[29]
	{
		3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
		15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
		67, 83, 99, 115, 131, 163, 195, 227, 258
	};

	private static readonly int[] _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A = new int[32]
	{
		1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
		33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
		1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577,
		0, 0
	};

	private static readonly byte[] _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020 = new byte[19]
	{
		16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
		11, 4, 12, 3, 13, 2, 14, 1, 15
	};

	private static readonly byte[] _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A = new byte[32]
	{
		0, 16, 8, 24, 4, 20, 12, 28, 2, 18,
		10, 26, 6, 22, 14, 30, 1, 17, 9, 25,
		5, 21, 13, 29, 3, 19, 11, 27, 7, 23,
		15, 31
	};

	private _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020 _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020;

	private _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A;

	private _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020;

	private _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A;

	private InflaterState _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020;

	private bool _0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020;

	private int _0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A;

	private BlockType _0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020;

	private byte[] _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A = new byte[4];

	private int _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020;

	private int _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A;

	private int _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020;

	private int _0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A;

	private byte[] _0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020;

	private byte[] _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A;

	private _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020;

	private IFileFormatReader _0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A;

	public int AvailableOutput => _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.AvailableBytes;

	public _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020()
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020 = new _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020();
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A = new _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020();
		_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020 = new byte[320];
		_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A = new byte[19];
		Reset();
	}

	internal void _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A(IFileFormatReader P_0)
	{
		_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A = P_0;
		_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020 = true;
		Reset();
	}

	private void Reset()
	{
		if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020)
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingHeader;
		}
		else
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBFinal;
		}
	}

	public void SetInput(byte[] inputBytes, int offset, int length)
	{
		_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.SetInput(inputBytes, offset, length);
	}

	public bool Finished()
	{
		if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 != InflaterState.Done)
		{
			return _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.VerifyingFooter;
		}
		return true;
	}

	public bool NeedsInput()
	{
		return _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.NeedsInput();
	}

	public int Inflate(byte[] bytes, int offset, int length)
	{
		int num = 0;
		do
		{
			int num2 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.CopyTo(bytes, offset, length);
			if (num2 > 0)
			{
				if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020)
				{
					_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A.UpdateWithBytesRead(bytes, offset, num2);
				}
				offset += num2;
				num += num2;
				length -= num2;
			}
		}
		while (length != 0 && !Finished() && _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020());
		if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.VerifyingFooter && _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.AvailableBytes == 0)
		{
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A.Validate();
		}
		return num;
	}

	private bool _0020_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020()
	{
		bool flag = false;
		bool flag2 = false;
		if (Finished())
		{
			return true;
		}
		if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020)
		{
			if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.ReadingHeader)
			{
				if (!_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A.ReadHeader(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A))
				{
					return false;
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBFinal;
			}
			else if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.StartReadingFooter || _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.ReadingFooter)
			{
				if (!_0020_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A.ReadFooter(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A))
				{
					return false;
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.VerifyingFooter;
				return true;
			}
		}
		if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.ReadingBFinal)
		{
			if (!_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.EnsureBitsAvailable(1))
			{
				return false;
			}
			_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(1);
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBType;
		}
		if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.ReadingBType)
		{
			if (!_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.EnsureBitsAvailable(2))
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBType;
				return false;
			}
			_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 = (BlockType)_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(2);
			if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 == BlockType.Dynamic)
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingNumLitCodes;
			}
			else if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 == BlockType.Static)
			{
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A.StaticLiteralLengthTree;
				_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A = _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A.StaticDistanceTree;
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.DecodeTop;
			}
			else
			{
				if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 != BlockType.Uncompressed)
				{
					throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_000A_000A));
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.UncompressedAligning;
			}
		}
		if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 == BlockType.Dynamic)
		{
			flag2 = ((_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 >= InflaterState.DecodeTop) ? _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020(out flag) : _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A());
		}
		else if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 == BlockType.Static)
		{
			flag2 = _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020(out flag);
		}
		else
		{
			if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 != BlockType.Uncompressed)
			{
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_000A_000A));
			}
			flag2 = _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A(out flag);
		}
		if (flag && _0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_000A != 0)
		{
			if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020)
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.StartReadingFooter;
			}
			else
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.Done;
			}
		}
		return flag2;
	}

	private bool _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A(out bool P_0)
	{
		P_0 = false;
		while (true)
		{
			switch (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020)
			{
			case InflaterState.UncompressedAligning:
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.SkipToByteBoundary();
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.UncompressedByte1;
				goto case InflaterState.UncompressedByte1;
			case InflaterState.UncompressedByte1:
			case InflaterState.UncompressedByte2:
			case InflaterState.UncompressedByte3:
			case InflaterState.UncompressedByte4:
			{
				int bits = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(8);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A[(int)(_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 - 16)] = (byte)bits;
				if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.UncompressedByte4)
				{
					_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020 = _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A[0] + _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A[1] * 256;
					int num2 = _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A[2] + _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_000A[3] * 256;
					if ((ushort)_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020 != (ushort)(~num2))
					{
						throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_000A_0020));
					}
				}
				break;
			}
			case InflaterState.DecodingUncompressed:
			{
				int num = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.CopyFrom(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A, _0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020);
				_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020 -= num;
				if (_0020_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020 == 0)
				{
					_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBFinal;
					P_0 = true;
					return true;
				}
				if (_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.FreeBytes == 0)
				{
					return true;
				}
				return false;
			}
			default:
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_000A));
			}
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020++;
		}
	}

	private bool _0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020(out bool P_0)
	{
		P_0 = false;
		int num = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.FreeBytes;
		while (num > 258)
		{
			switch (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020)
			{
			case InflaterState.DecodeTop:
			{
				int nextSymbol = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020.GetNextSymbol(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A);
				if (nextSymbol < 0)
				{
					return false;
				}
				if (nextSymbol < 256)
				{
					_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.Write((byte)nextSymbol);
					num--;
					break;
				}
				if (nextSymbol == 256)
				{
					P_0 = true;
					_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingBFinal;
					return true;
				}
				nextSymbol -= 257;
				if (nextSymbol < 8)
				{
					nextSymbol += 3;
					_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A = 0;
				}
				else if (nextSymbol == 28)
				{
					nextSymbol = 258;
					_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A = 0;
				}
				else
				{
					if (nextSymbol < 0 || nextSymbol >= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A.Length)
					{
						throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_0020_0020));
					}
					_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A = _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_000A[nextSymbol];
				}
				_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A = nextSymbol;
				goto case InflaterState.HaveInitialLength;
			}
			case InflaterState.HaveInitialLength:
				if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A > 0)
				{
					_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.HaveInitialLength;
					int bits2 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A);
					if (bits2 < 0)
					{
						return false;
					}
					if (_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A < 0 || _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A >= _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020.Length)
					{
						throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_0020_0020));
					}
					_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A = _0020_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020[_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A] + bits2;
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.HaveFullLength;
				goto case InflaterState.HaveFullLength;
			case InflaterState.HaveFullLength:
				if (_0020_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020 == BlockType.Dynamic)
				{
					_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A.GetNextSymbol(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A);
				}
				else
				{
					_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(5);
					if (_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 >= 0)
					{
						_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A[_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020];
					}
				}
				if (_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 < 0)
				{
					return false;
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.HaveDistCode;
				goto case InflaterState.HaveDistCode;
			case InflaterState.HaveDistCode:
			{
				int distance;
				if (_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 > 3)
				{
					_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A = _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 - 2 >> 1;
					int bits = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A);
					if (bits < 0)
					{
						return false;
					}
					distance = _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A[_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020] + bits;
				}
				else
				{
					distance = _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020 + 1;
				}
				_0020_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020.WriteLengthDistance(_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A, distance);
				num -= _0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_000A;
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.DecodeTop;
				break;
			}
			default:
				throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_000A));
			}
		}
		return true;
	}

	private bool _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A()
	{
		switch (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020)
		{
		case InflaterState.ReadingNumLitCodes:
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(5);
			if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A += 257;
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingNumDistCodes;
			goto case InflaterState.ReadingNumDistCodes;
		case InflaterState.ReadingNumDistCodes:
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020 = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(5);
			if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020 < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020++;
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingNumCodeLengthCodes;
			goto case InflaterState.ReadingNumCodeLengthCodes;
		case InflaterState.ReadingNumCodeLengthCodes:
			_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(4);
			if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A < 0)
			{
				return false;
			}
			_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A += 4;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingCodeLengthCodes;
			goto case InflaterState.ReadingCodeLengthCodes;
		case InflaterState.ReadingCodeLengthCodes:
		{
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A)
			{
				int bits = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(3);
				if (bits < 0)
				{
					return false;
				}
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020]] = (byte)bits;
				_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++;
			}
			for (int l = _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A; l < _0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020.Length; l++)
			{
				_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_0020_000A_000A_0020_0020[l]] = 0;
			}
			_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020 = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(_0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A);
			_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020 = _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A + _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020;
			_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 = 0;
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingTreeCodesBefore;
			goto case InflaterState.ReadingTreeCodesBefore;
		}
		case InflaterState.ReadingTreeCodesBefore:
		case InflaterState.ReadingTreeCodesAfter:
		{
			while (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 < _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020)
			{
				if (_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 == InflaterState.ReadingTreeCodesBefore && (_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A = _0020_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020.GetNextSymbol(_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A)) < 0)
				{
					return false;
				}
				if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A <= 15)
				{
					_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++] = (byte)_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A;
				}
				else
				{
					if (!_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.EnsureBitsAvailable(7))
					{
						_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingTreeCodesAfter;
						return false;
					}
					if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A == 16)
					{
						if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 == 0)
						{
							throw new Unity.IO.Compression.InvalidDataException();
						}
						byte b = _0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 - 1];
						int num = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(2) + 3;
						if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 + num > _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020)
						{
							throw new Unity.IO.Compression.InvalidDataException();
						}
						for (int i = 0; i < num; i++)
						{
							_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++] = b;
						}
					}
					else if (_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A == 17)
					{
						int num = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(3) + 3;
						if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 + num > _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020)
						{
							throw new Unity.IO.Compression.InvalidDataException();
						}
						for (int j = 0; j < num; j++)
						{
							_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++] = 0;
						}
					}
					else
					{
						int num = _0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.GetBits(7) + 11;
						if (_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020 + num > _0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020)
						{
							throw new Unity.IO.Compression.InvalidDataException();
						}
						for (int k = 0; k < num; k++)
						{
							_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020[_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020++] = 0;
						}
					}
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.ReadingTreeCodesBefore;
			}
			byte[] array = new byte[288];
			byte[] array2 = new byte[32];
			Array.Copy(_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020, array, _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A);
			Array.Copy(_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020, _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A, array2, 0, _0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020);
			if (array[256] == 0)
			{
				throw new Unity.IO.Compression.InvalidDataException();
			}
			_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_0020 = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(array);
			_0020_000A_000A_0020_0020_0020_0020_0020_000A_000A_000A = new _0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A(array2);
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = InflaterState.DecodeTop;
			return true;
		}
		default:
			throw new Unity.IO.Compression.InvalidDataException(_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A._0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_0020_000A_0020_000A));
		}
	}
}
internal class _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020
{
	private byte[] _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A;

	private int _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020;

	private int _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;

	private uint _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A;

	private int _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020;

	public int AvailableBits => _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020;

	public int AvailableBytes => _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 - _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 + _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 / 8;

	public bool EnsureBitsAvailable(int count)
	{
		if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 < count)
		{
			if (NeedsInput())
			{
				return false;
			}
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A |= (uint)(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A[_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020++] << _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020);
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 += 8;
			if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 < count)
			{
				if (NeedsInput())
				{
					return false;
				}
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A |= (uint)(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A[_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020++] << _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020);
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 += 8;
			}
		}
		return true;
	}

	public uint TryLoad16Bits()
	{
		if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 < 8)
		{
			if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 < _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020)
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A |= (uint)(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A[_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020++] << _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020);
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 += 8;
			}
			if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 < _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020)
			{
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A |= (uint)(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A[_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020++] << _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020);
				_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 += 8;
			}
		}
		else if (_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 < 16 && _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 < _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020)
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A |= (uint)(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A[_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020++] << _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020);
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 += 8;
		}
		return _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A;
	}

	private uint _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A(int P_0)
	{
		return (uint)((1 << P_0) - 1);
	}

	public int GetBits(int count)
	{
		if (!EnsureBitsAvailable(count))
		{
			return -1;
		}
		uint result = _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A & _0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A(count);
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A >>= count;
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 -= count;
		return (int)result;
	}

	public int CopyTo(byte[] output, int offset, int length)
	{
		int num = 0;
		while (_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 > 0 && length > 0)
		{
			output[offset++] = (byte)_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A;
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A >>= 8;
			_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 -= 8;
			length--;
			num++;
		}
		if (length == 0)
		{
			return num;
		}
		int num2 = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 - _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020;
		if (length > num2)
		{
			length = num2;
		}
		Array.Copy(_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A, _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020, output, offset, length);
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 += length;
		return num + length;
	}

	public bool NeedsInput()
	{
		return _0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 == _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;
	}

	public void SetInput(byte[] buffer, int offset, int length)
	{
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A = buffer;
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020 = offset;
		_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 = offset + length;
	}

	public void SkipBits(int n)
	{
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A >>= n;
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 -= n;
	}

	public void SkipToByteBoundary()
	{
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_000A >>= _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 % 8;
		_0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 -= _0020_000A_000A_0020_0020_0020_000A_0020_0020_0020_0020 % 8;
	}
}
internal class _0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020
{
	private MatchState _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020;

	private int _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;

	private int _0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A;

	private byte _0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020;

	internal MatchState _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020 = matchState;
		}
	}

	internal int _0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020 = num;
		}
	}

	internal int _0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_000A = num;
		}
	}

	internal byte _0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A
	{
		get
		{
			return _0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020;
		}
		set
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_0020_0020 = b;
		}
	}
}
internal class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A
{
	internal struct _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A
	{
		internal int _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;

		internal uint _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;

		internal int _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020;
	}

	private byte[] _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A;

	private int _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;

	private uint _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;

	private int _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020;

	internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020 => _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;

	internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A => _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A.Length - _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;

	internal int _0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020 => _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 / 8 + 1;

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A(byte[] P_0)
	{
		_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A = P_0;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020 = 0;
	}

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020(ushort P_0)
	{
		_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)P_0;
		_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)(P_0 >> 8);
	}

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(int P_0, uint P_1)
	{
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A |= P_1 << _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 += P_0;
		if (_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 >= 16)
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)(_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A >> 8);
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 -= 16;
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A >>= 16;
		}
	}

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020()
	{
		while (_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 >= 8)
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 -= 8;
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A >>= 8;
		}
		if (_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 > 0)
		{
			_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A[_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020++] = (byte)_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A = 0u;
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 = 0;
		}
	}

	internal void _0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A(byte[] P_0, int P_1, int P_2)
	{
		if (_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 == 0)
		{
			Array.Copy(P_0, P_1, _0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_000A, _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020, P_2);
			_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020 += P_2;
		}
		else
		{
			_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020(P_0, P_1, P_2);
		}
	}

	private void _0020_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020(byte[] P_0, int P_1, int P_2)
	{
		for (int i = 0; i < P_2; i++)
		{
			byte b = P_0[P_1 + i];
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A(b);
		}
	}

	private void _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A(byte P_0)
	{
		_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A(8, P_0);
	}

	internal _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A()
	{
		_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A result = default(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A);
		result._0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020 = _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;
		result._0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A = _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;
		result._0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 = _0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020;
		return result;
	}

	internal void _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020(_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A P_0)
	{
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020 = P_0._0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A = P_0._0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_000A;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020 = P_0._0020_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020;
	}
}
internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020
{
	private const int _0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_000A = 32768;

	private const int _0020_000A_000A_0020_0020_0020_000A_000A_000A_000A_0020 = 32767;

	private byte[] _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A = new byte[32768];

	private int _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;

	private int _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A;

	public int FreeBytes => 32768 - _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A;

	public int AvailableBytes => _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A;

	public void Write(byte b)
	{
		_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020++] = b;
		_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 &= 32767;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A++;
	}

	public void WriteLengthDistance(int length, int distance)
	{
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A += length;
		int num = (_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 - distance) & 0x7FFF;
		int num2 = 32768 - length;
		if (num <= num2 && _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 < num2)
		{
			if (length <= distance)
			{
				Array.Copy(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, num, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020, length);
				_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 += length;
			}
			else
			{
				while (length-- > 0)
				{
					_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020++] = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[num++];
				}
			}
		}
		else
		{
			while (length-- > 0)
			{
				_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020++] = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A[num++];
				_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 &= 32767;
				num &= 0x7FFF;
			}
		}
	}

	public int CopyFrom(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020 input, int length)
	{
		length = Math.Min(Math.Min(length, 32768 - _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A), input.AvailableBytes);
		int num = 32768 - _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;
		int num2;
		if (length > num)
		{
			num2 = input.CopyTo(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020, num);
			if (num2 == num)
			{
				num2 += input.CopyTo(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, 0, length - num);
			}
		}
		else
		{
			num2 = input.CopyTo(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020, length);
		}
		_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 = (_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 + num2) & 0x7FFF;
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A += num2;
		return num2;
	}

	public int CopyTo(byte[] output, int offset, int length)
	{
		int num;
		if (length > _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A)
		{
			num = _0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020;
			length = _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A;
		}
		else
		{
			num = (_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020 - _0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A + length) & 0x7FFF;
		}
		int num2 = length;
		int num3 = length - num;
		if (num3 > 0)
		{
			Array.Copy(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, 32768 - num3, output, offset, num3);
			offset += num3;
			length = num;
		}
		Array.Copy(_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_000A, num - length, output, offset, length);
		_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A -= num2;
		return num2;
	}
}
internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A
{
	public const string ArgumentOutOfRange_Enum = "Argument out of range";

	public const string CorruptedGZipHeader = "Corrupted gzip header";

	public const string CannotReadFromDeflateStream = "Cannot read from deflate stream";

	public const string CannotWriteToDeflateStream = "Cannot write to deflate stream";

	public const string GenericInvalidData = "Invalid data";

	public const string InvalidCRC = "Invalid CRC";

	public const string InvalidStreamSize = "Invalid stream size";

	public const string InvalidHuffmanData = "Invalid Huffman data";

	public const string InvalidBeginCall = "Invalid begin call";

	public const string InvalidEndCall = "Invalid end call";

	public const string InvalidBlockLength = "Invalid block length";

	public const string InvalidArgumentOffsetCount = "Invalid argument offset count";

	public const string NotSupported = "Not supported";

	public const string NotWriteableStream = "Not a writeable stream";

	public const string NotReadableStream = "Not a readable stream";

	public const string ObjectDisposed_StreamClosed = "Object disposed";

	public const string UnknownState = "Unknown state";

	public const string UnknownCompressionMode = "Unknown compression mode";

	public const string UnknownBlockType = "Unknown block type";

	private _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A()
	{
	}

	internal static string _0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(string P_0)
	{
		return P_0;
	}
}
internal class _0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A
{
	private static string _0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_000A_000A;

	private static string _0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_000A_0020;

	private static string _0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_0020_0020_000A;

	internal static uint _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = P_0.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))) : ((num >= P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ P_0[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= P_0.Length) ? ((num >= P_0.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ P_0[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}

	internal static byte[] _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020(byte[] P_0, string P_1)
	{
		try
		{
			if (P_0 == null || P_0.Length <= 1)
			{
				return null;
			}
			if (P_1 == null || P_1.Length < 4)
			{
				P_1 += _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_0020_0020;
			}
			uint num = 1162040133 + _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_1.Substring(0, P_1.Length / 2));
			uint num2 = 2506450243u + _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_1.Substring(P_1.Length / 2));
			byte[] array = new byte[P_0.Length - 1];
			byte b = P_0[0];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = P_0[i + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + 22646641) % 4294967294u;
				array[i] -= (byte)num2;
				array[i] = (byte)(array[i] ^ num);
				b = array[i];
			}
			return array;
		}
		catch
		{
			return null;
		}
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A()
	{
		return _0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020;
	}

	internal static bool _0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A(string P_0)
	{
		if (P_0 == null || P_0.Length <= _0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.Length)
		{
			return false;
		}
		return P_0.StartsWith(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A);
	}

	internal static byte[] _0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020(string P_0, string P_1)
	{
		if (!_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A(P_0))
		{
			return null;
		}
		if (string.IsNullOrEmpty(P_1))
		{
			P_1 = _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A();
		}
		int num = P_0.IndexOf(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020);
		if (num >= 0)
		{
			P_0 = P_0.Substring(num + _0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020.Length);
		}
		else if (P_0.StartsWith(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A))
		{
			P_0 = P_0.Substring(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.Length);
		}
		return _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020(Convert.FromBase64String(P_0), P_1);
	}

	internal static string _0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A(string P_0)
	{
		string text = null;
		int num = P_0.IndexOf(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020);
		if (num >= 0 && num > 0)
		{
			text = P_0.Substring(0, num);
			if (text.StartsWith(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A))
			{
				text = text.Substring(_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A.Length);
			}
		}
		return text;
	}

	internal static string _0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(string P_0, string P_1)
	{
		if (!_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A(P_0))
		{
			return P_0;
		}
		byte[] array = _0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020(P_0, P_1);
		if (array == null)
		{
			return null;
		}
		return Encoding.UTF8.GetString(array, 0, array.Length);
	}
}
internal class _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A
{
	internal static long _0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020;

	internal static long _0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A;
}
internal class _0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020
{
	internal const int _0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_000A = 5;

	private static long _0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020 = DateTime.Now.Ticks;

	private static long _0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A = 0L;

	internal static bool _0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020()
	{
		if (_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A() > 0)
		{
			return true;
		}
		return false;
	}

	internal static int _0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A()
	{
		if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A != 0L && _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A < DateTime.Now.Ticks)
		{
			return 3;
		}
		if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 != 0L && _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 < DateTime.Now.Ticks)
		{
			return 2;
		}
		if (_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A != 0L && _0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A < DateTime.Now.Ticks)
		{
			return 1;
		}
		_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020 = DateTime.Now.AddMinutes(1.0).Ticks;
		if (_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A == 0L)
		{
			_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A = DateTime.Now.AddMinutes(5.0).Ticks;
		}
		if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 == 0L)
		{
			_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 = DateTime.Now.AddMinutes(6.0).Ticks;
		}
		if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A == 0L)
		{
			_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_0020_000A_000A = DateTime.Now.AddMinutes(7.0).Ticks;
		}
		return 0;
	}

	internal static void _0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020()
	{
		if (_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A() == 2)
		{
			Environment.Exit(1);
			return;
		}
		_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A();
		_ = 3;
	}

	internal static void _0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A()
	{
		if (_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A() >= 1)
		{
			_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020();
		}
	}

	private static void _0020_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020()
	{
	}

	internal static void _0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A()
	{
		if (_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A != 0L && _0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A < DateTime.Now.Ticks)
		{
			Environment.Exit(1);
		}
		if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 != 0L && _0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 < DateTime.Now.Ticks)
		{
			throw new Exception();
		}
		if (_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020 <= DateTime.Now.Ticks)
		{
			_0020_000A_000A_0020_0020_000A_0020_0020_000A_000A_0020 = DateTime.Now.AddMinutes(1.0).Ticks;
			if (_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A == 0L)
			{
				_0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A = DateTime.Now.AddMinutes(10.0).Ticks;
			}
			if (_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 == 0L)
			{
				_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_000A_0020_0020_000A_0020_0020_000A_0020_0020 = DateTime.Now.AddMinutes(15.0).Ticks;
			}
		}
	}
}
internal class _0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A
{
	internal static string _0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020(string P_0)
	{
		return string.Format(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_0020_000A, _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_0));
	}

	internal static uint _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = P_0.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))) : ((num >= P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ P_0[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= P_0.Length) ? ((num >= P_0.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ P_0[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}
}
internal class _0020_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A
{
}
internal class _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020
{
	private static Dictionary<string, string[]> _0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020 = new Dictionary<string, string[]>();

	internal static string[] _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020(Assembly P_0)
	{
		if (P_0 == null)
		{
			P_0 = typeof(_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020).Assembly;
		}
		string[] array;
		if (!_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020.ContainsKey(P_0.FullName))
		{
			array = P_0.GetManifestResourceNames();
			_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020[P_0.FullName] = array;
		}
		else
		{
			array = _0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020[P_0.FullName];
		}
		return array;
	}

	internal static Stream _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A(Assembly P_0, string P_1)
	{
		if (P_0 == null)
		{
			P_0 = typeof(_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020).Assembly;
		}
		Stream manifestResourceStream = P_0.GetManifestResourceStream(P_1);
		if (manifestResourceStream != null)
		{
			return manifestResourceStream;
		}
		string[] array = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020(P_0);
		foreach (string text in array)
		{
			if (text.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_0020 + P_1))
			{
				return P_0.GetManifestResourceStream(text);
			}
		}
		return null;
	}

	public static byte[] GetResourceStreamBytes(Assembly assembly, string name)
	{
		Stream stream = _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A(assembly, name);
		if (stream == null)
		{
			return null;
		}
		byte[] array = new byte[stream.Length];
		stream.Read(array, 0, (int)stream.Length);
		stream.Close();
		return array;
	}

	public static string GetResourceStreamString(Assembly assembly, string name)
	{
		byte[] resourceStreamBytes = GetResourceStreamBytes(assembly, name);
		if (resourceStreamBytes == null)
		{
			return null;
		}
		return Encoding.UTF8.GetString(resourceStreamBytes, 0, resourceStreamBytes.Length);
	}
}
internal class _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A
{
	private static uint _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A;

	private static Dictionary<int, string> _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020;

	private static Random _0020_0020_0020_0020_000A_000A_000A_000A_000A_000A;

	internal static string _0020_0020_0020_0020_000A_000A_000A_000A_000A_0020;

	internal static string _0020_0020_0020_0020_000A_000A_000A_000A_0020_000A;

	internal static string _0020_0020_0020_0020_000A_000A_000A_000A_0020_0020;

	internal static string _0020_0020_0020_0020_000A_000A_000A_0020_000A_000A;

	internal static string _0020_0020_0020_0020_000A_000A_000A_0020_000A_0020;

	internal static string _0020_0020_0020_0020_000A_000A_000A_0020_0020_000A;

	internal static string _0020_0020_0020_0020_000A_000A_000A_0020_0020_0020;

	internal static string _0020_0020_0020_0020_000A_000A_0020_000A_000A_000A;

	internal static string _0020_0020_0020_0020_000A_000A_0020_000A_000A_0020;

	internal static string _0020_0020_0020_0020_000A_000A_0020_000A_0020_000A;

	internal static string _0020_0020_0020_0020_000A_000A_0020_000A_0020_0020;

	internal static string _0020_0020_0020_0020_000A_000A_0020_0020_000A_000A;

	internal static string _0020_0020_0020_0020_000A_000A_0020_0020_000A_0020;

	internal static string _0020_0020_0020_0020_000A_000A_0020_0020_0020_000A;

	internal static string _0020_0020_0020_0020_000A_000A_0020_0020_0020_0020;

	internal static string _0020_0020_0020_0020_000A_0020_000A_000A_000A_000A;

	internal static string _0020_0020_0020_0020_000A_0020_000A_000A_000A_0020;

	internal static string _0020_0020_0020_0020_000A_0020_000A_000A_0020_000A;

	internal static string _0020_0020_0020_0020_000A_0020_000A_000A_0020_0020;

	internal static string _0020_0020_0020_0020_000A_0020_000A_0020_000A_000A;

	internal static string _0020_0020_0020_0020_000A_0020_000A_0020_000A_0020;

	internal static string _0020_0020_0020_0020_000A_0020_000A_0020_0020_000A;

	internal static string _0020_0020_0020_0020_000A_0020_000A_0020_0020_0020;

	internal static string _0020_0020_0020_0020_000A_0020_0020_000A_000A_000A;

	internal static string _0020_0020_0020_0020_000A_0020_0020_000A_000A_0020;

	internal static string _0020_0020_0020_0020_000A_0020_0020_000A_0020_000A;

	internal static string _0020_0020_0020_0020_000A_0020_0020_000A_0020_0020;

	internal static string _0020_0020_0020_0020_000A_0020_0020_0020_000A_000A;

	internal static string _0020_0020_0020_0020_000A_0020_0020_0020_000A_0020;

	internal static string _0020_0020_0020_0020_000A_0020_0020_0020_0020_000A;

	internal static string _0020_0020_0020_0020_000A_0020_0020_0020_0020_0020;

	internal static string _0020_0020_0020_0020_0020_000A_000A_000A_000A_000A;

	internal static string _0020_0020_0020_0020_0020_000A_000A_000A_000A_0020;

	internal static string _0020_0020_0020_0020_0020_000A_000A_000A_0020_000A;

	internal static string _0020_0020_0020_0020_0020_000A_000A_000A_0020_0020;

	internal static string _0020_0020_0020_0020_0020_000A_000A_0020_000A_000A;

	internal static string _0020_0020_0020_0020_0020_000A_000A_0020_000A_0020;

	internal static string _0020_0020_0020_0020_0020_000A_000A_0020_0020_000A;

	internal static string _0020_0020_0020_0020_0020_000A_000A_0020_0020_0020;

	internal static string _0020_0020_0020_0020_0020_000A_0020_000A_000A_000A;

	internal static string _0020_0020_0020_0020_0020_000A_0020_000A_000A_0020;

	internal static string _0020_0020_0020_0020_0020_000A_0020_000A_0020_000A;

	internal static string _0020_0020_0020_0020_0020_000A_0020_000A_0020_0020;

	internal static string _0020_0020_0020_0020_0020_000A_0020_0020_000A_000A;

	internal static string _0020_0020_0020_0020_0020_000A_0020_0020_000A_0020;

	internal static string _0020_0020_0020_0020_0020_000A_0020_0020_0020_000A;

	internal static string _0020_0020_0020_0020_0020_000A_0020_0020_0020_0020;

	internal static string _0020_0020_0020_0020_0020_0020_000A_000A_000A_000A;

	internal static string _0020_0020_0020_0020_0020_0020_000A_000A_000A_0020;

	internal static string _0020_0020_0020_0020_0020_0020_000A_000A_0020_000A;

	internal static string _0020_0020_0020_0020_0020_0020_000A_000A_0020_0020;

	internal static string _0020_0020_0020_0020_0020_0020_000A_0020_000A_000A;

	internal static string _0020_0020_0020_0020_0020_0020_000A_0020_000A_0020;

	internal static string _0020_0020_0020_0020_0020_0020_000A_0020_0020_000A;

	internal static string _0020_0020_0020_0020_0020_0020_000A_0020_0020_0020;

	internal static string _0020_0020_0020_0020_0020_0020_0020_000A_000A_000A;

	internal static string _0020_0020_0020_0020_0020_0020_0020_000A_000A_0020;

	internal static string _0020_0020_0020_0020_0020_0020_0020_000A_0020_000A;

	internal static string _0020_0020_0020_0020_0020_0020_0020_000A_0020_0020;

	internal static string _0020_0020_0020_0020_0020_0020_0020_0020_000A_000A;

	internal static string _0020_0020_0020_0020_0020_0020_0020_0020_000A_0020;

	internal static string _0020_0020_0020_0020_0020_0020_0020_0020_0020_000A;

	internal static string _0020_0020_0020_0020_0020_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A;

	internal static string _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;

	internal static string _0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020;

	internal static string _0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A;

	internal static uint _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A()
	{
		_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A = 3189709172u;
		return _0020_0020_0020_000A_0020_0020_0020_0020_0020_000A;
	}

	static _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A()
	{
		_0020_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✁✗✗⛮✖✜✂✙✞✢✟✙⛹✥✚✭✦✟✩✰⛷⛞✄✒✓✑✕✣✊✞⛧");
		_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✁✗✗⛮✖✜✂✙✞✢✟✙⛹✥✚✭✦✟✩✰⛷⛞✄✒✓✑✕⛵⛥");
		_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✁✗✗⛮✖✜✂✙✞✢✟✙⛹✥✚✭✦✟✩✰⛪✒✤✳✵⛼⛣✉✗✘✖✚⛓");
		_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✁✗✗⛮✖✜✂✙✞✢✟✙⛹✥✚✭✦✟✩✰⛪✒✤✳✵⛼⛣✉✗✘✖✚");
		_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✁✗✗⛮✖✜✂✙✞✢✟✙⛹✥✚✭✦✟✩✰⛷⛞✎✋");
		_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✏✖✚✍✡");
		_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✋✟✑✁✗✜✕");
		_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗⛡");
		_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗⛠");
		_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗⛟");
		_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗⛞");
		_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛚✏✢✒✓✥✕✧✖✗✙");
		_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗");
		_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✋✣✟✑✠⛡");
		_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✋✣✟✑✠⛠");
		_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✋✣✟✑✠⛟");
		_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✋✣✟✑✠");
		_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✏✞✠");
		_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛉⛗⛋✏✢✠✡✕✟✦⛰");
		_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⫀⫚⫥⫬⫸⫠⫟⫥⫭⫽⫬⛔⫷⫫⫪⛘⫶⫯⛛⫽⫻⫼⬁⫲⫶⬄⬄⬆⬈⫻⬉⛨⬋⫿⬅⬏⬖⬃⬋⬓✋⛲✼❂✒");
		_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⫇⫲⫣⫝⫧⫞⛏⫧⫡⫬⫳⫿⫷⫮⬆⛘⫻⫯⫮⫬⛝⛫⛟⫲⬂⫷⛣⬆⫺⫹⫿⛨⬌⬀⬀⛬⬄⫾⬉⬐⬜⬔⬞");
		_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛣⛚⛛");
		_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛚⛥⛜⛝✫");
		_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛔");
		_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✞✝✑✎✛⛝⛼✖✠✚✨✝⛳");
		_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✞✝✑✎✛⛝✀✠✥✜✨✞✥✥⛵");
		_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭⛯✁✄✀⛻⛱✈");
		_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⫦⫟⛋⫩⫝⫧⫣⫥⫮⛒⫵⫩⫨⛰⛗");
		_0020_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘");
		_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛥⛙");
		_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏✋✛✛✠⛩");
		_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛐");
		_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏✛✠✛✡⛩");
		_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛋");
		_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏✑✟⛧");
		_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏✖✟⛧");
		_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏✋✘✜⛨");
		_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛏");
		_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛧");
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛨");
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛣⛊");
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚳⛊⛋");
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛉⛊");
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛣");
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✞✘✖✚✜✥✝⛐✥✫✣✙⛯⛖");
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛫✋✞✑⛰✝✜✠✣✗✦✧✚✚⛹✭✟✠✠✮✍✟✢✫⛻⛢");
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛫✋✞✑⛰✝✜✠✣✗✦✧✚✚⛹✭✟✠✠✮✍✟✢✫⛡⛯⛣✉✗✘✖✚⛼");
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✙✘✜✟✓✢✣✖✖⛵✩✛✜✜✪✉✛✞✧⛝⛫⛟✅✓✔✒✖⛷");
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✙✘✜✟✓✢✣✖✖⛵✩✛✜✜✪✉✛✞✧⛝⛫⛟✅✓✔✒✖⛶⛦✵✷✽⛪✮✻✺✾❁✵❄❅");
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛕⛊✎✛✚✞✡✕✤✥⛰");
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛕⛊✠✚✐✝✜✠✣✗✦✧✚✚✖✫✢✴✠⛹");
		_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✓✥✑⛪");
		_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛎⛊✑✞✜✛⛏✟✣✛✚✝✣✗✣");
		_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✓✙✕⛹✈⛾⛪⛑");
		_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✓✙✕⛹✈⛾⛐⛞⛒⛸✆✇✅✉⛫");
		_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✓✙✕⛹✈⛾⛐⛞⛒⛸✆✇✅✉⛲⛙");
		_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✓✙✕⛹✈⛾⛪⛑✁⛾");
		_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✏✢✟⚺⚸⛻✊✀⛒⛥⛢⛦⛦⛗✠✚✭⛛✞✢✣✭⛠✳✧✯✩✦✹✬✬✄⛪✬⛬❀✻✰✼✽⛲❈❄✹✷❋✽⛹❎❃✽❑⛾❅❉❙❇❖✄❛❇❙❑❘❟❞✌❏❣❘❜❕✒❜❧❨❫❜❫✧✇✅❇❢❷✟❆❢❥❷❷✒✐❓❢❘✪❴❿✭❯✯➀➀➄➇❵❷➂❼✸➅➉➎➏➉➃➒➓❁➆➄➘➆❆➊➗➖➚➝➑➠➡➘➟➟❒➟➝➗➨➘➪➲❚➲➮➦➲➳➥➯❢➬➲❥➇➕➛➒❪➎❺❚❘➞➶➷➷⟅⟇❵⟆⟉➽⟍⟎⟔❼⟃➿⟒⟔➁⟅⟒⟑⟕⟘⟌⟛⟜⟓⟚⟚➍⟏⟝⟔➑➜⟘⟬⟩⟨⟜⟥⟞⟦⟴➦➝⟤⟠⟳⟵➢⟧⟩⟨⟵⟴⟸⟻⟯⟾⟿⟶⟽⟽➾➞➜⟢⠂⟺➶⠆⟾➹⠎⠃⠁➽⠄⠀⠓⠕⠇⠖⠘⟅⠉⠖⠕⠙⠜⠐⠟⠠⠗⠞⠞⟑⠓⠡⠘⟕⠚⠜⠛⠨⠧⠫⠮⠢⠱⠲⠩⠰⠰⟣⠥⠱⠭⠶⠺⠲⠾⠳⠹⡀⟮⠰⡂⡀⡇⡁⠸⠃⟶⠪⠽⠾⟺⡏⡄⡂⟾⡑⡁⡕⡋⡑⡋⡘⠆⡍⡗⡛⠊⡗⡦⡜⡞⠏⡙⡟⠒⡧⡜⡚⠖⡝⡙⡦⡩⡰⡯⠝⠿⡱⡣⡩⡫⡹⡩⠥⡉⡶⡵⡹⡫⡽⡵⢀⡽⡽⠰⡥⡷⢆⢈⠵⡄⠤⠢⡢⢈⡾⢈⢒⢂⢄⢓⡁⢕⢏⢓⢜⢋⢙⡈⢌⢙⢘⢜⢟⢓⢢⢣⢚⢡⢡⡔⢡⢛⢭⢝⢥⢭⡛⢝⢠⢦⢨⢥⢷⢫⢱⢫⡥⢧⡧⢹⢾⢳⢿⢱⡭⢱⢾⢽⣁⢷⣇⢽⣉⢿⣍⢽⡹⢽⣊⣉⣍⣐⣄⣓⣔⣋⣒⣒⢅⣘⣈⣜⣒⣙⢋⣣⣕⣗⣛⣕⢑⣥⣧⣝⣡⣢⢗⣜⣞⣝⣪⣩⣭⣰⣤⣳⣴⣫⣱⣫⢥⣧⣻⢨⣽⣲⣴⣿⢭⤄⣴⤂⤊⢲⣻⣽⣼⣾⢷⤋⤉⣿⤀⤀⣋⢫⢩⣤⤊⤕⤗⤖⤎⤈⤜⤜⤎⤎⣋⤡⤛⤒⤔⤢⣑⤦⤛⤙⣕⤪⤜⤪⤦⤭⣛⤫⤣⣞⤳⤨⤦⣢⤊⤒⤚⣦⤎⤭⤷⤯⤽⤭⤹⣮⤟⥅⤳⤾⤼⤷⣵⤢⥀⤻⤾⥈⥎⥁⣽⤆⤦⤰⤭⤂⥙⤖⤐⤏⤕⤈⤬⥙⥘⥙⥒⥠⥒⥙⥒⥞⤓⥠⥞⥙⥜⥦⥬⥟⥮⤜⥞⥰⥤⤠⥢⥸⥤⥭⥱⥧⥩⥴⥮⤪⥿⥴⥿⥽⦄⥷⥹⤲⦂⦉⦇⤶⥣⥲⥨⤺⥫⦎⦌⦄⦄⦓⦔⦋⦒⦒⦆⦒⥇⦔⦒⦍⦐⦚⦠⦓⥏⦠⦣⦡⦚⦦⦖⦣⥥⥅⥃⥾⦪⦳⦫⦪⦮⦡⦥⥏⥍⦐⦟⦕⥧⦱⦼⥪⦯⦵⧀⧂⧁⦹⦳⧇⧇⦹⦹⥶⦸⧋⥹⧊⧊⧎⧑⦿⧁⧌⧆⦂⦤⦲⦸⦯⦇⦫⦉⧝⧚⧡⧟⧑⧔⦐⧔⧡⧗⧙⦣⦃⦁⦅⦃⦾⧪⧳⧫⧪⧮⧡⧥⦢⧏⧞⧔⦦⦯⧻⧸⧿⧽⧯⧲⦮⧲⧿⧵⧷⦿⦴⧊⧎⧎⦸⨄⧜⧇⦼⧰⧦⧠⧑⧛⧂⧗⧝⧗⧚⧝⧟⧟⨋⧤⨎⨎⨓⧤⨔⨓⧧⧫⨙⨛⧧⧩⧱⨝⨝⧬⨟⨢⨠⨢⨥⧴⨤⨤⨥⧸⨩⧻⨪⧾⨮⧴⧺⧚⧘⧜⧚⨾⨻⩁⨽⨡⨰⨦⧥⧣⩇⩄⩊⩆⨪⨹⨯⨁⩋⩖⨄⩆⨆⩝⩍⩛⩣⨋⩘⩖⩕⩗⩤⩨⩗⩜⩛⩝⩪⨗⩫⩮⩜⩮⩡⩱⨞⩮⩦⨡⩶⩫⩩⨥⩒⩡⩗⨩⩶⩴⩮⩿⩯⪁⪉⨱⩻⪁⪈⩺⪄⩻⩽⩽⨺⪁⪋⪏⨾⪄⪁⪔⪛⩃⪍⪓⪉⪓⪝⪜⪓⪚⪚⩍⪥⪘⪤⪙⩒⪬⪣⪪⪨⩗⪙⪩⪪⪧⪥⪠⪟⪳⪩⪰⪰⩱⩤⪎⪺⩧⪱⪼⩪⪲⪱⪻⪳⫁⪱⫅⪷⪷⩴⪶⫋⫋⫇⫆⪻⫏⫅⫀⪿⫋⫌⫚⪂⫉⫖⫔⫓⪇⫝̸⫑⫏⪋⪸⫇⪽⪏⫣⫠⫧⫥⫗⫚⪖⫚⫧⫝⫟⪛⫝⫫⫢⪟⫣⫰⫰⫷⫥⫮⫴⫺⪨⫽⫲⫰⪬⫺⫽⬂⬄⪱⫻⬀⬄⬄⬈⬋⫹⬇⬎⪻⫨⫷⫭⪿⬆⬖⬐⬆⬘⬎⬕⬕⬛⫗⪷⪵⪹⪷⬄⬔⬢⬪⫒⬘⬕⬨⬯⫗⬬⬨⫚⬰⬯⬢⫞⫬⫠⬪⬶⫣⬳⬳⬲⭀⫨⬽⬫⬶⬱⭀⫮⬰⫰⬷⬷⭊⫴⭂⬿⭅⭍⭍⬿⭎⫼⭑⭍⫿⭁⭅⭆⬃⭈⭆⭚⭈⬈⭌⭙⭘⭜⭟⭓⭢⭣⭚⭡⭡⬔⭩⭥⬗⭱⭨⭯⭭⬜⭞⭮⭯⭬⭪⭥⭤⭸⭮\u2b75\u2b75⬩⬖⬔⬘⬖⭑⭽⮆⭾⭽⮁\u2b74⭸⬵⮃⮀⮆⮂⭦\u2b75⭫⬽⭆⮒⮏\u2b96⮔⮆⮉⭅⮉\u2b96⮌⮎⭖⭋⭢⭟⭎⮚⭲⭝⭒⮆⭼⭶⭧⭱⭘⮜⭱⭯⭯⭯\u2b75⭯⭸⮥⭶⭼\u2b74⭶⭽⮨⭻⮯⭺⮭⮀⮳⮂⮃⮳⮊⮋⮷⮇⮈⮌⮽⮐⮺⮋⮽⯁⮕⮒⯅⮕⮊⮐⭰⭮⭲⭰⮹⯍⯕⯋⯟⯑⯑⮎⯛⯙⯟⯝⯦⮁⭿⯂⯑⯇⮙⯊⯭⯫⯣⯣⯲⯳⯪⯱⯱⯥⯱⮦⯰⯻⮩⯹Ⰰ⯾⮭⯱⯾⯽⯾⯷Ⰵ⯷⯾⯷Ⰳ⮸⯥⯴⯪⮼ⰉⰇⰂⰅⰏⰕⰈ⯄ⰕⰘⰖⰏⰛⰋⰘ⯚⮺⮸⯸Ⱆ⯑ⰫⰢⰩ⯕ⰤⰜⰝⰝ⯚ⰝⰡⰱⰲⰤⰲ⯡ⰥⰲⰱⰵⰸⰬⰻⰼⰳⰺⰺ⯭ⱇⰾⱅ⯱ⱅⰻⱃⱊⱂⰻ⯸ⱍⰻⱆⱁ⯽ⰿ⯿ⱌⱐⱑⱎⰄⱆⱚⰇⱜⱑⱏⰋⱑⱥⱑⱔⱜⱝⱗⱡⱨⰕⱰⱣⱡⱛⰚⱧⱥⱟⱰⱠⱲⱺⰰⰣⱾⱱⱯⱩⰨⱲⱽⰫⱿⱹⱽⲆⱵⲃⰲⱴⲂⱹⰶⲅⱽⱾⱾⲎⰼⲊⲍⲑⲅⱁⲏⲈⲑⲔⲘⲠⱔⱉⲞⲓⲛⲢⲕⲗⱞⰾⰼⱹⲣⲧⱖⲜⲮⲞⲨⱛⲞⲢⲲⲳⲥⲳⱢⲦⲳⲲⲶⲹⲭⲼⲽⲴⲻⲻⱮⲲⲿⲿⳅⲼⲸⲺⳈⱷⳍⳌⳃⳉⳃⱽⳊⳈⳂⳃⳜⳌⳔⲗⲆⳞⳐⳒⳍⳓⲌⳖⳡⲏⳔⳚ⳥⳧⳦ⳞⳘⳬⳬⳞⳞⲛⳳ⳦Ⳳ⳧Ⲡ\u2cf5⳪⳨Ⲥ⳧ⴀ\u2cf0\u2cf8ⲻⲪ\u2cf1\u2cf5⳹ⳳⲯⳳⴀ⳿ⴃⴆ⳺ⴉⴊⴇⴋⳈⲨⲦ\u2cf1ⴆⴄⳀⴇⴋⴏⴉⳅⴉⴖⴕⴙⴜⴐⴟⴠⴝⴡⳐⴒⴢⴣⴠⴞⴙⴘ\u2d2cⴢ\u2d29\u2d29Ⳝ\u2d29ⴸ\u2d2eⴰⳡⴷⴶ\u2d29ⴸ⳦ⴓⴢⴘ⳪\u2cf8ⳬⴶⵂ\u2cefⴹⵄⳲⵉⴹⵇⵏ\u2cf7ⵋⵂⵇⵄⵈⴾⵐ⳿ⵔⵐⴂⵊⵞⵎⵖⴇⵊⵞⵞⴋⵙⵢⵑⵗⴐⵗⵓⵦ\u2d68ⵚ\u2d68ⴥ");
		_0020_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✞✝✕✛✕⛿✟✠✞⛭⛔⛺✈✉✇✋⛄");
		_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✎✛✑✓⛸✞✥⛥⛥⛮⛕✛✩✪✨✬");
		_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✒⛧");
		_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛮✘✎✛✑✓⛸✞✥⛥⛥⛮⛕✛✩✪✨✬");
		_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✞✝✕✛✕⛿✟✠✞⛭⛔✄✁");
		_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✞✝✕✛✕⛿✟✠✞⛭⛔⛺✈✉✇✋");
		_0020_000A_000A_0020_000A_000A_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✋✣✀✒✡✣");
		_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✏✞✠✌");
		_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✛✏✌✐✒✠");
		_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗✡✒⛎✜✥✤✦⛓✖✚⛖⛧⛘✨✬⛛✣✯✣✠✴✦✴");
		_0020_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗✡✒");
		_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✠✜✔✠✒✠");
		_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✜✠✑");
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛚⛥✄⛟✫");
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✍✓✞✍✏✚✔");
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✛✏✞✑✡");
		_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✘✐✑");
		_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✏✋✗✟✒");
		_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛙");
		_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✘✌✎✙✓");
		_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✏✟");
		_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✘✘");
		_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✝✜✠✑");
		_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛙⛚⛛⛜⛝⛞⛟⛠⛡⛢⛣⛤⛥⛦⛧⛨");
		_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛙⛚⛛⛜⛝⛞⛟⛠");
		_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛖⛚✣");
		_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛙✢");
		_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✟✋✗✡✒⛫");
		_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛕");
		_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛉");
		_0020_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛚⛥⛏⛐⛑⛏⛓⛔⛕⛓⛗⛘⛙⛗⛛⛜⛝⛛⛟⛠⛮⛭⛣⛤✿");
		_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛕⛊");
		_0020_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✒✌✚✔✓⛏✓✠✧✡✨⛯⛖");
		_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛯✓✗✑⛧⛎");
		_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✒✌✚✔✓⛏✙✟⛒✙✝✡✛⛱⛘");
		_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✏✣✑");
		_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✛✑✔");
		_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✙✒✓");
		_0020_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✡✌✢");
		_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✛⛟");
		_0020_000A_000A_000A_0020_0020_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✞✔✒");
		_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✚✙✓");
		_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✑✔✒");
		_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✔✛✓");
		_0020_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✏✎");
		_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✚✏✎");
		_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✎✗✘");
		_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛓⛘⛕");
		_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛉✞✚⛌");
		_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✒✌✚✔✓⛻✙✟✝⛓✚✧✥✤⛘");
		_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄✀✑✡✙✡✦✦⛸⛷⛰⛗✋✜✬✤✬✱✱⛭✃✰✷✱✸✂");
		_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄✀✑✡✙✡✦✦⛸⛷⛰⛗⛹✬✭✠✩✟✪✸⛮✄✱✸✲✹✃");
		_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✝✞✑✚✐✛✩⛽✛✦✨");
		_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✍✝✕✝✢✢");
		_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✗✍✦✓✓⛐✖✪✧✦✖✙✫✡✨✨⛛✫✣⛞✲✣✳✫✳✸✸⛦✺✽✹✺✺✾❁✳✳⛰❀❀✿❍⛵✼❆❊⛹✡✼❉❂✰❄❃❐❘❈❖❞✆❓❑❌❏❙❟❒✎❣❩❡❗✔");
		_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛚");
		_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✓✞✍✏✚✔✔⛵✗✟✕✮✛✛⛽✱✮✭✝✠✲✨✯✯✑✩✗✨✸✰✸✽✽");
		_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✙✟⛌✓✝✤✞✕⛒✆✗✧✟✧✬⛽✜⛵⛜");
		_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄✀✑✡✙✡⛶⛵⛢✙✛✭✰✬✜✳✩✩");
		_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✝✞✑✚✐✛✩⛞⛵✆✜✖✨✧");
		_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✐✠✎⛜✓✙✤✓✕✠✚✚⛥✥✞✮✜");
		_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✐✠✎⛜✓✙✤✓✕✠✚✚");
		_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✎✔✟✎✐✛✕✕");
		_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✖✠✓✖✜✢");
		_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛻✏✘✛✣✓✂✓✣✛✣✨⛯⛖");
		_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✝✞✑✚✐✛✩⛞");
		_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✖✠✓✖✜⛰✣⛞");
		_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤✥✑✕✙✓⛸⛴⛫⛒✮⛤✲⛢⛗✟✮✣✟⛶⛝✹⛰✽⛭⛢✷✽✵✫✁⛨⛼❇❈");
		_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✗✐✠✎");
		_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✛✍✐✙✂✓✣✛✣✨⛯⛖");
		_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛽✎✞✖✞✣");
		_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛷✐✠✎");
		_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛽✎✞✖✞✣⛶✚✞✘✂✖✣✜");
		_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✍✝✕✝✢✎⛶✚✞✘⛻✪✟✛");
		_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✍✝✕✝✢✎⛶✚✞✘⛽⛹");
		_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✖✠✓✖✜✎⛶✚✞✘⛻✪✟✛");
		_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✖✠✓✖✜✎⛶✚✞✘⛽⛹");
		_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✛✍✐✙⛏✣✔✤✜✤✩⛖✝✪✨✧⛛✬✩✳✦✩✯");
		_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛿✓✐✣⛍✡✒✢✚✢✧");
		_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✒✌✚✔✓⛏✣✔✤✜✤✩⛖✣✡✧✥⛛✰✬⛞✏✬✶✩✬✲⛥⛮⛵✬✵✶⛴");
		_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✍✞");
		_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✋✟✔⛍✢✞⛐✤✕✥✝✥✪⛱⛘");
		_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄✂✜✟✑✔✝✘✦⛢⛹✦✦✭✬✪✨");
		_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛻✏✘✛✣✓⛏⛹✥✗✠⛔⛻✨✦✥⛙⛻✮✯✢✲");
		_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛻✏✘✛✣✓⛏⛹✥✗✠");
		_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✞✐✙⛍");
		_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✎✏⛌⛶✢✔✝⛑✆✢⛔⛶✩✪✝✭");
		_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✎✏⛌⛶✢✔✝");
		_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✙✗✘✎✞✢✕⛑⛳✟✠");
		_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛮✢✛✍✛✒⛏⛱✝✞");
		_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✖✓✙✕⛯✣✣✤✠✠");
		_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜");
		_0020_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✙✡✕✛✕⛏✫⛡✯⛓⛽✩✛✤✳⛪✷");
		_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✀⛾");
		_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛮✖✐✙✒✜✣⛐");
		_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✓✍✛✒✛✕✕⛒✘✢✪✣⛗");
		_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛥⛊⛸✡✙✢✘✠✝✗⛓⛲");
		_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛰✏✙✑✟✗✒⛴✣✓✚⛷✤✢✬✥✧⛾✭✝✤✥✨✮✨");
		_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✏✌✞✐✖");
		_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✤✗✔✦✘✞⛱⛘✜✛✩✪✬✲⛟✢✦⛢✱✹✱✲⛧✷✻⛪✰✹✽❂❈");
		_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✝✜✐✑⛍✛✞✔✖✞⛓✦✤✥✫⛘✢✭⛛✪✲✪✫⛮⛡✦✬✨⛥✿✶✽⛩✭✬✸✹⛮✢✵❅✖✴❈✶⛾✀✗");
		_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✒✐⛌✟✝✞✤⛑✛✦⛔✣✫✣✤");
		_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✛✡✡⛎✛✙✤✦⛓✝✩✛✤⛘✚✮⛛✥✫✢✤✸⛡⛳⛣✭✸⛦✨✻✼✿✸✱✱⛮❃✿⛱✺✴❊✺⛶✸⛸✽✿❋❐❅⛾❎❆✁✒");
		_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗⛊⛺✚✙✧⛏✤✙✗⛓✚✞✨✪✬⛙✣✯✡✪⛞⛧✴✩✧⛣✶✴✵✻⛱⛩✽✳✻❂✺✳⛰✹✳❉✹⛵✺✼❈❍❂⛻✾❂❊❎❗✁✒✑");
		_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✕✗✣✨✝⛖✭✙✥✯✠⛜✣✭✱⛠✪✶✨✱⛥✧✻⛨✲✸✯✱❅⛮");
		_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✕✗✣✨✝⛖✠✦✟✩⛛✥✫⛞✨✮✱✷✷⛤✱✯✺✼⛷⛪✏✱✽❂✷⛰✴✳❁❂❄❊⛷❁❇✽❍❁✾❑❄✀❎❑❕❉✅❚❏❉❗✊✜✌❝❓❡✐❣❡❪✢✕✿❥❜❞❲✛❷✭❻✟❨❢❵✣❨❪❶❻❰✩➅✼➉✭➅❷❹❽❷✳❽➃❺❼➐✹➕❍➙✽➆➀➓❁➆➈➔➙➎❇➣❜➧");
		_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✕✓✞✠⛍✗✣✕✞⛒✔✨⛕✟✥✜✞✲⛛⛬⛝✱✧✯✶✮✧⛤✭✧✽✭⛩✫⛫✰✲✾❃✸⛱❁✹⛴✂✇⛷✀❌❃❉✿❂⛾❓❈❊❕✃❗❍❕❜❔❍✊❍❑✍❢❗❕✑❚❜❘❙❛❥✘❫❩❪❰✝❭❥✠❵❪❨✤❹❸❬❭✲✸✫❐❲❾➃❸✱❻➆❎✵");
		_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✕✓✞✠");
		_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✕✓✞✠⛍✡✗✟✦✞✗⛔✝✗✭✝⛙✣✯✡✪✱⛫⛠✤✱✸✲✹⛦✰✻⛩⛺⛷⛬✰✶✴✳✼⛲✵✹✻❅❉✽⛹✽✼❈❉❇❍❇✁✸❄❐❎❊❈❜❎✮❐❜❡❖❅❑❝❧❘❧");
		_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛽✒✐⛌✖✜✟✥✥⛒⛚⛽✁✟✪✬⛵✎⛹⛜✯✣✲✵✭✶⛪⛤✱✯✺✼⛩✳✾⛬✻❃✻✼");
		_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✚✠✣✩✩⛰⛗✡✧✭✠✮✱✧✮✮✊✰✧✩✽⛦✰✻⛩⛷⛼⛸⛭✱✻✹✶❀❇⛴❃✻✼✼❌⛺❏❋⛽❂❄❃❊❆❈✄❜❎❈❜✉❓❙❐❒❦✏❕❝❗❠❙❣❪❪✘❬❢❪❱❩❢✟❢❦✢❵❩❵❧❹❭❷❾❰❰✭❯➃");
		_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✖✐✙✒✜✣⛐✚✥⛓✢✪✢✣");
		_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✖✐✙✒✜✣");
		_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✎✏⛾✜✝✣⛐✚✥⛓✣✣✢✰⛘✚✦✧✫✴✣✣⛠✰✰⛣✩✲✶✻❁⛩✮✬❀✮⛮✻✹❄❆");
		_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✟✑✟✜✐✜⛑⛷✥✦✤✨⛱⛘✝✛✯✝⛝✪✨✳✵⛢✬✷⛥✴✼✴✵");
		_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✛✙✚✠⛍✗✢⛐✟✧✟✠");
		_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✙✋✝✑✛✢⛏✙✤⛒✡✩✡✢");
		_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✙✋✝✑✛✢");
		_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✖✐✙✒✜✣✣⛑⛵✢✩✣✪⛗✡✬⛚⛫⛶⛝✬✮✴✩✫✱✫⛥✺✶⛨✪✮✯");
		_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✖✐✙✒✜✣✣⛑✛✦⛔✣✫✣✤");
		_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✎✖✐✙✒✜✣✣");
		_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✞⛋✕✠⛎✝✟✥⛒✔✠✡✥✮✝✝⛚✯✫⛝✰✤✭✰✸✨⛤✹✮✬⛨✻✹✺❀⛭✳✻✵✾✷❁❈");
		_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✛✡✡⛎✓✑✥✓⛓✝✨⛖✥✭✥✦⛩⛜✂✬✲✵✳✧⛣✭✳✶✼✼⛩✳✾⛬✮⛮✽✿✿⛿❁❉❁❂⛷❄❂❍❏✊");
		_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✍✋✟✍");
		_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛰✋✘✑⛼✐✙✕✔✦⛓⛽✘✥✥");
		_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✀✓✙✐✧✝✝✕⛑⛻✖✣✣");
		_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✋✘✑✟✏⛏⛹✔✡✡");
		_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✟✏✕✜✁✞✥✣✕✘⛔⛾✙✦✦");
		_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛯✙✗✐✒✠⛏⛹✔✡✡");
		_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛻✏✘✛✣✓⛏✃✔✤✜✤✩");
		_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✋✘✑");
		_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✋✎✗⛍✢✞⛐✡✞✨✛✞✤");
		_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✛✍✐✙⛏✃✔✤✜✤✩");
		_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✦⚴");
		_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✦⚴⛚⛛⛍⛾✛✥✘✛✡⛔✡✟✥✣⛳⛚✶✂✦✪✤✉✅⛼⛣");
		_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛕⛊⛲✡✖✒⛩⛐");
		_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚳⛙⛚⛌✀✑✘✠✥⛒✟✝✣✡⛱⛘✴✀✤✨✢✇✃⛺⛡");
		_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚳⛙⛚⛌✀✑✡✙✡✦⛹✝✡✛✅✙✦✟⛵⛜");
		_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛙⛋⛭✠✡✔✝✓✞✬✂✖✣✜⛲⛙");
		_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛿✓✐✣⛍✁✒✢✚✢✧");
		_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✛✏✞✡✙✢");
		_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✛✙✚✠");
		_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✜✚✓✟✓✢✣⛫⛒");
		_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛫✜✐✍✘⛜⛝");
		_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✒✌✚✔✓⛏✜✚✠✞✨⛕✪✦⛘✉✦✰✣✦✬⛟✦✰✴⛣✥✱✲⛧✻✮✶✰✯❁✳✳⛰⛹❄✸❁❄❌✼⛸❌✽❍❅❍❒❒✉");
		_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✛✍✐✙⛏✑✝✞⛓✧✚✢✜✛✭✟✟⛜✰✡✱✩✱✶✶");
		_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛫✟✟✠✜✜");
		_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛥");
		_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛯✟✗✘⛻✏✜✕");
		_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✝✞✑✚✐✛✩⛿✓✠✙");
		_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛻✙✚✠");
		_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄✂✜✟✑✔✝✘✦⛯⛖✊✛✫✣✫✰⛝✫✠✮✢✩✨✶");
		_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✘✕");
		_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✗✍✦✓✓⛐✖✪✧✦✖✙✫✡✨✨⛛✫✣⛞✲✣✳✫✳✸✸⛦✺✽✹✺✺✾❁✳✳⛰❀❀✿❍⛵✼❆❊⛹✡✼❉❂✰❄❃❐❘❈❖❞✆❓❑❌❏❙❟❒✎❣❩❡❗");
		_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✡✄⛍⛾✡✟✛✗✖✨⛕✩✚✪✢✪✯✯⛝✫✠✮✢✩✨✶");
		_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛎");
		_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✊✝✤✚✐✀✔✣✦✞✧");
		_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✖✠✗⛔✘✗✣✤");
		_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✓✗✚✝✣⛖✚✙✥✦");
		_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✋✙✚✜✢⛏✧✣✛✧✙⛕✪✦⛘✝✟✡✨✞✲✤⛠✴✶✵✩✦✳");
		_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✋✙✚✜✢⛏✢✖✓✗⛔✛✨✦✥⛙✞✠✢✩✟✳✥⛡✵✷✶✪✧✴");
		_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✒✤✚✩✢✛✥✬⛙✩✡✢✰✣✳⛠✤✱✸✲✹");
		_0020_0020_0020_0020_0020_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✌✙✠✚✡");
		_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✘✐✑✟✒✢");
		_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✊✜✝✍✦");
		_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛹✜✚✓✟✏✜⛐✖✠✧✙✧✛✛⛘✚✨⛛✱✫✣✷✰✦✥✷✩✩⛦✺✼✪✾✰⛺");
		_0020_0020_0020_0020_0020_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✙✟⛌✎⛎✦✢✚✦✘✕✗✢✜⛘✬✮✭✡✞✫");
		_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✙✟⛌✎⛎✡✕✒✖✔✖✡✛⛗✫✭✬✠✝✪");
		_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✖✙✏✑");
		_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛪✜✒✡✚✓✝✤⛑✡✨✨⛕✥✝⛘✫✛✩✣✢");
		_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✜✞✝✑✎✛");
		_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✤✦✥✙✖✣⛗✫✢✴✠");
		_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐⛴✄⛶");
		_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✖✚✜✥✝⛐✔✡✠✤✧✛✪✫✢✩✩⛜✪✭✣✥");
		_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛬✙✝✞✢✞✣✕✕⛒✚✮✞✦⛗✠✞✛✟✡✯");
		_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛸✌✕✑✐✢⛏✔✚✥✣✣✨✛✛");
		_0020_0020_0020_0020_0020_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛷✙✟⛌✠✣✟✠✠✤✧✙✙");
		_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐⛹✧✙✚✢✗✥⛘✝✛✯✝");
		_0020_0020_0020_0020_0020_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✖✚✜✥✝⛐✤✦✔✨✚");
		_0020_0020_0020_0020_0020_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✓✞✢✗✠⛖✣✝✧✡✯✤");
		_0020_0020_0020_0020_0020_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛾✘✖✚✜✥✝⛐✓✞✢✗✠⛖✫✱✩✟");
		_0020_0020_0020_0020_0020_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛲✘✡✍✙✗✓⛐✕✓✧✕");
		_0020_0020_0020_0020_0020_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛌⛷⛰✀⛮⛲⛰✄⛲⛕⛖");
		_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛌⛯⛹⛯⛿✇⛿✄⛶⛶⛖");
		_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛌⛰⛽⛳⛵⛺✂⛴⛷✀⛺✍⛺✆✎⛾⛜");
		_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛰⛎⛎⛟⛡");
		_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛚⛥✄✪");
		_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗");
		_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✏✓✗✑⛧⛝⛞⛟");
		_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛶✓✎✞✜✡✞✖✥⛠✁✙✩");
		_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✖✝✎✛✟✚✘✒");
		_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛰⛫⛮");
		_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛮✢✐✏✢✢✐✒✝✗✃✕✩✞");
		_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✣✞✠✒✛⛝✇✚✠✗✣✬✩⛥⛾✨✬✨✯⛫⛿✯✰✭✫✦✥✹✯✶✶");
		_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛼✣✞✠✒✛⛝✇✚✠✗✣✬✩⛥⛾✨✬✨✯⛩⛞✕✥✳✵✬✳✳✃⛹⛶⛹⛸⛻⛺⛽⛺⛯✓❆✾❇❉❇✻✔❆✾❏❏❎✾❊✋✀✱❗❅❐❎❉✲❍❢✾❚❗❒❜✬❒✨✩❔✩❘✫✭✩✲✭✯❡✭✶✸");
		_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢⛢⛻✅⛥✚✯✯✫");
		_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢⛢⛻✅");
		_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛭✏✑✍✢✚✣⛟⛽✡✖✕✡✟✱✙✭✣✪✪⛪");
		_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛖✋✠✠✜");
		_0020_0020_0020_0020_000A_0020_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✥");
		_0020_0020_0020_0020_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✅✦");
		_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚲");
		_0020_0020_0020_0020_000A_0020_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✅✞");
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚳");
		_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✅✘");
		_0020_0020_0020_0020_000A_000A_0020_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⚶");
		_0020_0020_0020_0020_000A_000A_0020_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✅✜");
		_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛘⛙");
		_0020_0020_0020_0020_000A_000A_0020_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✋✙✓✢✏✖✕");
		_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢");
		_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢⛢⛠⛥✬✱✮");
		_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛗✞✣✠");
		_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢⛢");
		_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✍✏✑");
		_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢✉✥✦✤✬⛨✧✫✠✟✫✩✻✣✷✭✴✴✦✶✪✷✰");
		_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛵✙✎✍✙✗✩✑✥✛✢✢⛢✚✜✞");
		_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛖");
		_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("⛮⛸");
		_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛫⛭⛝⛡⛱⛱⛳⛳⛟⛹⛩⛮⛪⛤⛬⛬⛮✀⛩⛵⛯⛳⛶⛮⛵✈⛷⛶⛽✍⛾⛽✐⛾⛿⛾❋");
		_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A("✤⛰⛤⛱⛮⛱⛱⛥⛢⛟⛷⛥⛹⛫⛤⛬⛮⛻⛲⛩⛿⛳⛳⛰⛮✅⛵⛹⛹⛻⛺⛻✍✌⛽✎✃❋");
		_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new Dictionary<int, string>();
		_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A = new Random((int)DateTime.Now.Ticks);
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020(string P_0, int P_1)
	{
		if (_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020 == null)
		{
			_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020 = new Dictionary<int, string>();
		}
		if (!_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020.ContainsKey(P_1))
		{
			string text = _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A(P_0);
			_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020[P_1] = text;
			return text;
		}
		return _0020_0020_0020_000A_0020_0020_0020_0020_0020_0020[P_1];
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A(string P_0)
	{
		if (P_0 == null)
		{
			return P_0;
		}
		int num = (int)(_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A() % 5000);
		int num2 = 0;
		char[] array = P_0.ToCharArray();
		num2 += 10;
		num2 += 5;
		if (num2 == 16)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (char)(array[i] - (ushort)(243 + num + i));
			}
		}
		num2 -= 3;
		if (num2 == 15)
		{
			for (int j = 0; j < array.Length; j++)
			{
				array[j] = (char)(array[j] - (ushort)(1452 + num + j));
			}
		}
		num2++;
		num2 += 2;
		if (num2 == 15)
		{
			for (int k = 0; k < array.Length; k++)
			{
				array[k] = (char)(array[k] - (ushort)(5725 + num + k));
			}
		}
		num2 += 7;
		if (num2 == 5)
		{
			for (int l = 0; l < array.Length; l++)
			{
				array[l] = (char)(array[l] - (ushort)(345 - l));
			}
		}
		return new string(array);
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020(string P_0)
	{
		try
		{
			if (string.IsNullOrEmpty(P_0))
			{
				return P_0;
			}
			uint num = 591983395u;
			uint num2 = 1916441025u;
			byte[] array = Convert.FromBase64String(P_0);
			byte[] array2 = new byte[array.Length - 1];
			byte b = array[0];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A()) % 4294967294u;
				array2[i] -= (byte)num2;
				array2[i] = (byte)(array2[i] ^ num);
				b = array2[i];
			}
			return Encoding.UTF8.GetString(array2, 0, array2.Length);
		}
		catch
		{
			return null;
		}
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A(string P_0)
	{
		if (P_0 == null || P_0.Length == 0)
		{
			return null;
		}
		try
		{
			uint num = 591983395u;
			uint num2 = 1916441025u;
			byte[] bytes = Encoding.UTF8.GetBytes(P_0);
			byte[] array = new byte[bytes.Length + 1];
			array[0] = (byte)(_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A.Next() % 256);
			byte b = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = bytes[i - 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A()) % 4294967294u;
				b = array[i];
				array[i] = (byte)(array[i] ^ num);
				array[i] += (byte)num2;
			}
			return Convert.ToBase64String(array);
		}
		catch
		{
			return null;
		}
	}

	internal static string _0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020(string P_0)
	{
		try
		{
			uint num = 591983395u;
			uint num2 = 1916441025u;
			byte[] array = new byte[P_0.Length / 8];
			int num3 = 0;
			int num4 = 0;
			string text = P_0;
			foreach (char c in text)
			{
				if (c == '\r' || c == '\n')
				{
					array[num4] = (byte)(array[num4] | (1 << num3));
				}
				num3++;
				if (num3 >= 8)
				{
					num3 = 0;
					num4++;
				}
			}
			byte[] array2 = new byte[array.Length - 1];
			byte b = array[0];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = array[j + 1];
				num = (num * 4343255 + b + 5235457) % 4294967294u;
				num2 = (num2 * 5354354 + b + _0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A()) % 4294967294u;
				array2[j] -= (byte)num2;
				array2[j] = (byte)(array2[j] ^ num);
				b = array2[j];
			}
			return Encoding.UTF8.GetString(array2, 0, array2.Length);
		}
		catch
		{
			return null;
		}
	}
}
internal class _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020
{
	private static bool _0020_0020_0020_000A_0020_0020_000A_0020_0020_0020;

	internal static Dictionary<int, string> _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A;

	internal static Dictionary<int, string> _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020;

	internal static Dictionary<int, string> _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;

	internal static List<Action> _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020;

	private static Dictionary<string, string> _0020_0020_0020_000A_0020_0020_0020_0020_000A_000A;

	private static string _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020;

	private static void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020(string P_0, string P_1)
	{
		if (P_0 != null)
		{
			_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A[P_0] = P_1;
		}
	}

	private static string _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A(string P_0)
	{
		if (P_0 == null)
		{
			return null;
		}
		if (_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A.ContainsKey(P_0))
		{
			return _0020_0020_0020_000A_0020_0020_0020_0020_000A_000A[P_0];
		}
		return null;
	}

	internal static string _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020()
	{
		string text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_000A_0020_0020;
		text = Thread.CurrentThread.CurrentCulture.Name.Split(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A.ToCharArray())[0].ToUpper();
		if (string.IsNullOrEmpty(text))
		{
			text = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_000A_0020_0020;
		}
		return text;
	}

	static _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020()
	{
		_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020 = false;
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020 = new List<Action>();
		_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A = new Dictionary<string, string>();
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = new Dictionary<int, string>();
		_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_0020);
		_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020 = _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A;
		_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = new Dictionary<int, string>();
		_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A();
	}

	internal static void _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A(string P_0)
	{
		if (_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A == null)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A = new Dictionary<int, string>();
		}
		_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A[(int)_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_0)] = P_0;
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020(string P_0)
	{
		return _0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020((int)_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_0));
	}

	internal static int _0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A(string P_0)
	{
		return (int)_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(P_0);
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020(int P_0)
	{
		if (P_0 == 0)
		{
			return null;
		}
		if (_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A != null && _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A.ContainsKey(P_0))
		{
			return _0020_0020_0020_000A_0020_0020_0020_000A_0020_000A[P_0];
		}
		if (_0020_0020_0020_000A_0020_0020_0020_000A_000A_0020 != null && _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020.ContainsKey(P_0))
		{
			return _0020_0020_0020_000A_0020_0020_0020_000A_000A_0020[P_0];
		}
		if (_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A != null && _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A.ContainsKey(P_0))
		{
			return _0020_0020_0020_000A_0020_0020_0020_000A_000A_000A[P_0];
		}
		return null;
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A(string P_0)
	{
		_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A, P_0);
		_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A();
		for (int num = _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020.Count - 1; num >= 0; num--)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020[num]();
		}
		return true;
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_0020()
	{
		string text = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A);
		if (string.IsNullOrEmpty(text))
		{
			text = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020();
		}
		return text;
	}

	internal static string[] _0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A()
	{
		List<string> list = new List<string>();
		try
		{
			if (_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020)
			{
				string[] array = _0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020();
				foreach (string item in array)
				{
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
			}
			else
			{
				try
				{
					string[] array = _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A();
					foreach (string item2 in array)
					{
						if (!list.Contains(item2))
						{
							list.Add(item2);
						}
					}
				}
				catch
				{
				}
				try
				{
					string[] array = _0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020();
					foreach (string item3 in array)
					{
						if (!list.Contains(item3))
						{
							list.Add(item3);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		list.Sort();
		list.Insert(0, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_0020);
		return list.ToArray();
	}

	internal static string[] _0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020()
	{
		List<string> list = new List<string>();
		try
		{
			string[] array = _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020._0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020(null);
			if (array != null)
			{
				string[] array2 = array;
				foreach (string text in array2)
				{
					int num = text.LastIndexOf(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A);
					if (num >= 0 && text.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
					{
						string text2 = text.Substring(num + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A.Length);
						if (text2.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
						{
							text2 = text2.Substring(0, text2.Length - _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020.Length);
						}
						if (!list.Contains(text2) && text2 != _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_0020)
						{
							list.Add(text2);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list.ToArray();
	}

	internal static string[] _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A()
	{
		List<string> list = new List<string>();
		try
		{
			string text = null;
			try
			{
				text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A();
			}
			catch
			{
			}
			try
			{
				text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020();
			}
			catch
			{
			}
			try
			{
				text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A();
			}
			catch
			{
			}
			if (!string.IsNullOrEmpty(text))
			{
				List<string> list2 = new List<string>();
				if (Directory.Exists(text))
				{
					string[] files = Directory.GetFiles(text, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A, SearchOption.TopDirectoryOnly);
					foreach (string item in files)
					{
						list2.Add(item);
					}
				}
				string path = Path.Combine(text, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020);
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A, SearchOption.TopDirectoryOnly);
					foreach (string item2 in files)
					{
						list2.Add(item2);
					}
				}
				path = Path.Combine(text, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_0020_000A_000A);
				if (Directory.Exists(path))
				{
					string[] files = Directory.GetFiles(path, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_000A, SearchOption.TopDirectoryOnly);
					foreach (string item3 in files)
					{
						list2.Add(item3);
					}
				}
				foreach (string item4 in list2)
				{
					int num = item4.LastIndexOf(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A);
					if (num >= 0 && item4.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
					{
						string text2 = item4.Substring(num + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A.Length);
						if (text2.EndsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
						{
							text2 = text2.Substring(0, text2.Length - _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020.Length);
						}
						if (!list.Contains(text2) && text2 != _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_0020)
						{
							list.Add(text2);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list.ToArray();
	}

	internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020(Action P_0)
	{
		if (_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A(P_0) == null)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020.Add(P_0);
		}
	}

	internal static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A(Action P_0)
	{
		Action action = _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A(P_0);
		if (action != null)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020.Remove(action);
		}
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020(string P_0)
	{
		if (_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A == null)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = new Dictionary<int, string>();
		}
		else
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A.Clear();
		}
		if (P_0 != null)
		{
			string[] array = P_0.Split('\r', '\n');
			foreach (string text in array)
			{
				if (string.IsNullOrEmpty(text) || text.StartsWith(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_0020_000A_0020))
				{
					continue;
				}
				int num = -1;
				for (int j = 1; j < text.Length; j++)
				{
					if (text[j] == '|' && text[j - 1] != '\\')
					{
						num = j;
						break;
					}
				}
				if (num > 0 && num != text.Length)
				{
					string text2 = text.Substring(0, num);
					string value = text.Substring(num + 1).Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_0020_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_0020_0020_0020).Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_000A_0020)
						.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_000A_0020_0020);
					int result = 0;
					if (int.TryParse(text2, NumberStyles.HexNumber, null, out result))
					{
						_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A[result] = value;
						continue;
					}
					result = _0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A(text2.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_000A_000A, _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_000A_0020));
					_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A[result] = value;
				}
			}
			return true;
		}
		return false;
	}

	internal static void _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A()
	{
		if (_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A == null)
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A = new Dictionary<int, string>();
		}
		else
		{
			_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A.Clear();
		}
		string text = _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_0020_000A);
		if (!string.IsNullOrEmpty(text))
		{
			if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + text))
			{
				return;
			}
			if (text.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A))
			{
				string text2 = text.Split('-')[0].Trim();
				if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + text2))
				{
					return;
				}
			}
			if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + text + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_0020_000A))
			{
				return;
			}
			if (text.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A))
			{
				string text3 = text.Split('-')[0].Trim();
				if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_0020_0020 + text3 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_0020_000A))
				{
					return;
				}
			}
		}
		else
		{
			if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020()) || _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020() + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_0020_000A))
			{
				return;
			}
			string text4 = Thread.CurrentThread.CurrentCulture.Name.Split(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_0020_000A_000A.ToCharArray())[0].ToUpper();
			if (_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + text4) || _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_000A + text4 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_000A_0020_0020_000A))
			{
				return;
			}
		}
		if (!_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_000A_000A_000A))
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_000A_000A_0020);
		}
	}

	internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020(string P_0)
	{
		string text = null;
		if (_0020_0020_0020_000A_0020_0020_000A_0020_0020_0020)
		{
			try
			{
				if (text == null)
				{
					text = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A(P_0);
				}
			}
			catch
			{
			}
		}
		else
		{
			try
			{
				if (text == null)
				{
					text = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020(P_0);
				}
			}
			catch
			{
			}
			try
			{
				if (text == null)
				{
					text = _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A(P_0);
				}
			}
			catch
			{
			}
		}
		if (text == null)
		{
			return false;
		}
		if (_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A._0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A(text))
		{
			text = _0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A._0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020(text, null);
		}
		return _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020(text);
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A(string P_0)
	{
		string resourceStreamString = _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020.GetResourceStreamString(null, P_0);
		if (resourceStreamString == null)
		{
			resourceStreamString = _0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020.GetResourceStreamString(null, P_0 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020);
		}
		return resourceStreamString;
	}

	internal static string _0020_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020(string P_0)
	{
		string text = null;
		try
		{
			text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A();
		}
		catch
		{
		}
		try
		{
			text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020();
		}
		catch
		{
		}
		try
		{
			text = text ?? _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A();
		}
		catch
		{
		}
		try
		{
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			string text2 = Path.Combine(text, P_0);
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
			{
				return File.ReadAllText(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020);
			}
			text2 = Path.Combine(text, Path.Combine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_0020_0020, P_0));
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
			{
				return File.ReadAllText(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020);
			}
			text2 = Path.Combine(text, Path.Combine(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_0020_000A_000A, P_0));
			if (File.Exists(text2))
			{
				return File.ReadAllText(text2);
			}
			if (File.Exists(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020))
			{
				return File.ReadAllText(text2 + _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_0020_000A_000A_0020);
			}
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A()
	{
		try
		{
			if (_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 != null)
			{
				return _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020;
			}
			_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020 = Path.GetDirectoryName(Assembly.Load(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_000A_0020_000A).GetType(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_000A_0020_0020).GetProperty(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_0020_000A_000A, BindingFlags.Static | BindingFlags.Public)
				.GetValue(null, null)?.ToString());
			return _0020_0020_0020_000A_0020_0020_0020_0020_000A_0020;
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020()
	{
		try
		{
			return Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
		}
		catch
		{
		}
		return null;
	}

	private static string _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A()
	{
		try
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			if (string.IsNullOrEmpty(codeBase) || (codeBase.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_0020_000A_0020) && codeBase.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_0020_0020_000A) && codeBase.Contains(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_0020_0020_0020_0020_0020)))
			{
				return null;
			}
			if (!string.IsNullOrEmpty(codeBase))
			{
				return Path.GetDirectoryName(codeBase.Replace(_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_0020_000A_000A_000A_000A_000A, ""));
			}
		}
		catch
		{
		}
		return null;
	}

	internal static uint _0020_0020_000A_000A_000A_000A_0020_000A_000A_0020_0020(string P_0)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return 123u;
		}
		int num = 0;
		int num2 = 352654597;
		int num3 = num2;
		for (int num4 = P_0.Length; num4 > 0; num4 -= 4)
		{
			num2 = ((num + 1 < P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))) : ((num >= P_0.Length) ? (((num2 << 5) + num2 + (num2 >> 27)) ^ 0) : (((num2 << 5) + num2 + (num2 >> 27)) ^ P_0[num])));
			if (num4 <= 2)
			{
				break;
			}
			num += 2;
			num3 = ((num + 1 >= P_0.Length) ? ((num >= P_0.Length) ? (((num3 << 5) + num3 + (num3 >> 27)) ^ 0) : (((num3 << 5) + num3 + (num3 >> 27)) ^ P_0[num])) : (((num3 << 5) + num3 + (num3 >> 27)) ^ (int)(P_0[num] | ((uint)P_0[num + 1] << 16))));
			num += 2;
		}
		return (uint)(num2 + num3 * 1566083941);
	}

	internal static Action _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A(Action P_0)
	{
		for (int num = _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020.Count - 1; num >= 0; num--)
		{
			Action action = _0020_0020_0020_000A_0020_0020_0020_000A_0020_0020[num];
			if (action.Target == P_0.Target)
			{
				return action;
			}
		}
		return null;
	}
}
internal class _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A
{
	internal class 湖草空間例子忘記要記住
	{
		private void 間例()
		{
		}
	}

	internal class Vwr34FbdbFWwqpu5dCn3sgLp4
	{
		private void DFd43fx()
		{
		}
	}

	private static string _0020_0020_0020_000A_0020_0020_000A_0020_0020_000A = _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_000A_0020_000A;

	internal static bool _0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020()
	{
		if (_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A == _0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A._0020_0020_0020_0020_000A_000A_000A_000A_000A_0020)
		{
			return true;
		}
		return false;
	}
}
