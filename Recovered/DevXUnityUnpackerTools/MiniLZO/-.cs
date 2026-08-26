using APK;
using ARMD;
using @as;
using DevXForms;
using DevXForms.TreeList;
using DMP4;
using DSMCaps;
using FMOD;
using ProtoBuf;
using SpirV;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using Unreal;
using Xxtea;

namespace MiniLZO
{
	internal class _0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A
	{
		internal static int[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020 = new int[32]
		{
			0,
			1,
			28,
			2,
			29,
			14,
			24,
			3,
			30,
			22,
			20,
			15,
			25,
			17,
			4,
			8,
			31,
			27,
			13,
			23,
			21,
			19,
			16,
			7,
			26,
			12,
			18,
			6,
			11,
			5,
			10,
			9
		};

		internal unsafe static uint _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A(byte* _0020, uint _0020_000A, byte* _0020_0020, ref uint _0020_000A_000A, uint _0020_000A_0020, void* _0020_0020_000A)
		{
			byte* ptr = _0020 + _0020_000A;
			byte* ptr2 = _0020 + _0020_000A - 20;
			byte* ptr3 = _0020_0020;
			byte* ptr4 = _0020;
			byte* ptr5 = _0020 + ((_0020_000A_0020 < 4) ? (4 - _0020_000A_0020) : 0);
			while (true)
			{
				ptr5 += 1 + (ptr5 - ptr4 >> 5);
				while (true)
				{
					byte* ptr6;
					uint num6;
					uint num5;
					if (ptr5 < ptr2)
					{
						uint num = *(uint*)ptr5;
						uint num2 = (405029533 * num >> 18) & 0x3FFF;
						ptr6 = _0020 + (int)(*(ushort*)((byte*)_0020_0020_000A + (long)num2 * 2L));
						*(ushort*)((byte*)_0020_0020_000A + (long)num2 * 2L) = (ushort)(ptr5 - _0020);
						if (num != *(uint*)ptr6)
						{
							break;
						}
						ptr4 -= _0020_000A_0020;
						_0020_000A_0020 = 0u;
						uint num3 = (uint)(ptr5 - ptr4);
						if (num3 != 0)
						{
							if (num3 <= 3)
							{
								byte* intPtr = ptr3 + -2;
								*intPtr = (byte)(*intPtr | (byte)num3);
								*(uint*)ptr3 = *(uint*)ptr4;
								ptr3 += num3;
							}
							else if (num3 <= 16)
							{
								byte* intPtr2 = ptr3;
								ptr3 = intPtr2 + 1;
								*intPtr2 = (byte)(num3 - 3);
								*(uint*)ptr3 = *(uint*)ptr4;
								*(uint*)(ptr3 + 4) = *(uint*)(ptr4 + 4);
								*(uint*)(ptr3 + 8) = *(uint*)(ptr4 + 8);
								*(uint*)(ptr3 + 12) = *(uint*)(ptr4 + 12);
								ptr3 += num3;
							}
							else
							{
								if (num3 <= 18)
								{
									byte* intPtr3 = ptr3;
									ptr3 = intPtr3 + 1;
									*intPtr3 = (byte)(num3 - 3);
								}
								else
								{
									uint num4 = num3 - 18;
									byte* intPtr4 = ptr3;
									ptr3 = intPtr4 + 1;
									*intPtr4 = 0;
									while (num4 > 255)
									{
										num4 -= 255;
										byte* intPtr5 = ptr3;
										ptr3 = intPtr5 + 1;
										*intPtr5 = 0;
									}
									byte* intPtr6 = ptr3;
									ptr3 = intPtr6 + 1;
									*intPtr6 = (byte)num4;
								}
								do
								{
									*(uint*)ptr3 = *(uint*)ptr4;
									*(uint*)(ptr3 + 4) = *(uint*)(ptr4 + 4);
									*(uint*)(ptr3 + 8) = *(uint*)(ptr4 + 8);
									*(uint*)(ptr3 + 12) = *(uint*)(ptr4 + 12);
									ptr3 += 16;
									ptr4 += 16;
									num3 -= 16;
								}
								while (num3 >= 16);
								if (num3 != 0)
								{
									do
									{
										byte* intPtr7 = ptr3;
										ptr3 = intPtr7 + 1;
										byte* intPtr8 = ptr4;
										ptr4 = intPtr8 + 1;
										*intPtr7 = *intPtr8;
									}
									while (--num3 != 0);
								}
							}
						}
						num5 = 4u;
						num6 = (*(uint*)(ptr5 + num5) ^ *(uint*)(ptr6 + num5));
						if (num6 != 0)
						{
							goto IL_01d1;
						}
						while (true)
						{
							num5 += 4;
							num6 = (*(uint*)(ptr5 + num5) ^ *(uint*)(ptr6 + num5));
							if (ptr5 + num5 >= ptr2)
							{
								break;
							}
							if (num6 == 0)
							{
								continue;
							}
							goto IL_01d1;
						}
						goto IL_01df;
					}
					_0020_000A_000A = (uint)(ptr3 - _0020_0020);
					return (uint)(ptr - (ptr4 - _0020_000A_0020));
					IL_01d1:
					num5 += (uint)_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020(num6) / 8u;
					goto IL_01df;
					IL_01df:
					uint num7 = (uint)(ptr5 - ptr6);
					ptr5 += num5;
					ptr4 = ptr5;
					if (num5 <= 8 && num7 <= 2048)
					{
						num7--;
						byte* intPtr9 = ptr3;
						ptr3 = intPtr9 + 1;
						*intPtr9 = (byte)((num5 - 1 << 5) | ((num7 & 7) << 2));
						byte* intPtr10 = ptr3;
						ptr3 = intPtr10 + 1;
						*intPtr10 = (byte)(num7 >> 3);
						continue;
					}
					if (num7 <= 16384)
					{
						num7--;
						if (num5 <= 33)
						{
							byte* intPtr11 = ptr3;
							ptr3 = intPtr11 + 1;
							*intPtr11 = (byte)(0x20 | (num5 - 2));
						}
						else
						{
							num5 -= 33;
							byte* intPtr12 = ptr3;
							ptr3 = intPtr12 + 1;
							*intPtr12 = 32;
							while (num5 > 255)
							{
								num5 -= 255;
								byte* intPtr13 = ptr3;
								ptr3 = intPtr13 + 1;
								*intPtr13 = 0;
							}
							byte* intPtr14 = ptr3;
							ptr3 = intPtr14 + 1;
							*intPtr14 = (byte)num5;
						}
						byte* intPtr15 = ptr3;
						ptr3 = intPtr15 + 1;
						*intPtr15 = (byte)(num7 << 2);
						byte* intPtr16 = ptr3;
						ptr3 = intPtr16 + 1;
						*intPtr16 = (byte)(num7 >> 6);
						continue;
					}
					num7 -= 16384;
					if (num5 <= 9)
					{
						byte* intPtr17 = ptr3;
						ptr3 = intPtr17 + 1;
						*intPtr17 = (byte)(0x10 | ((num7 >> 11) & 8) | (num5 - 2));
					}
					else
					{
						num5 -= 9;
						byte* intPtr18 = ptr3;
						ptr3 = intPtr18 + 1;
						*intPtr18 = (byte)(0x10 | ((num7 >> 11) & 8));
						while (num5 > 255)
						{
							num5 -= 255;
							byte* intPtr19 = ptr3;
							ptr3 = intPtr19 + 1;
							*intPtr19 = 0;
						}
						byte* intPtr20 = ptr3;
						ptr3 = intPtr20 + 1;
						*intPtr20 = (byte)num5;
					}
					byte* intPtr21 = ptr3;
					ptr3 = intPtr21 + 1;
					*intPtr21 = (byte)(num7 << 2);
					byte* intPtr22 = ptr3;
					ptr3 = intPtr22 + 1;
					*intPtr22 = (byte)(num7 >> 6);
				}
			}
		}

		internal static int _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020(uint _0020)
		{
			return _0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020[(uint)((_0020 & (0L - _0020)) * 125613361) >> 27];
		}

		internal unsafe static int _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A(byte* _0020, uint _0020_000A, byte* _0020_0020, ref uint _0020_000A_000A, byte* _0020_000A_0020)
		{
			byte* ptr = _0020;
			byte* ptr2 = _0020_0020;
			uint num = _0020_000A;
			uint num2 = 0u;
			while (num > 20)
			{
				uint num3 = num;
				num3 = ((num3 <= 49152) ? num3 : 49152u);
				ulong num4 = (ulong)((long)ptr + num3);
				if (num4 + (num2 + num3 >> 5) <= num4 || (ulong)(UIntPtr)(void*)(num4 + (num2 + num3 >> 5)) <= (ulong)(ptr + num3))
				{
					break;
				}
				for (int i = 0; i < 32768; i++)
				{
					_0020_000A_0020[i] = 0;
				}
				num2 = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A(ptr, num3, ptr2, ref _0020_000A_000A, num2, _0020_000A_0020);
				ptr += num3;
				ptr2 += _0020_000A_000A;
				num -= num3;
			}
			num2 += num;
			if (num2 != 0)
			{
				byte* ptr3 = _0020 + _0020_000A - num2;
				if (ptr2 == _0020_0020 && num2 <= 238)
				{
					byte* intPtr = ptr2;
					ptr2 = intPtr + 1;
					*intPtr = (byte)(17 + num2);
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
						byte* intPtr6 = ptr2 + -2;
						*intPtr6 = (byte)(*intPtr6 | (byte)num2);
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
					{
						byte* intPtr5 = ptr2;
						ptr2 = intPtr5 + 1;
						*intPtr5 = (byte)(num2 - 3);
						break;
					}
					default:
					{
						uint num5 = num2 - 18;
						byte* intPtr2 = ptr2;
						ptr2 = intPtr2 + 1;
						*intPtr2 = 0;
						while (num5 > 255)
						{
							num5 -= 255;
							byte* intPtr3 = ptr2;
							ptr2 = intPtr3 + 1;
							*intPtr3 = 0;
						}
						byte* intPtr4 = ptr2;
						ptr2 = intPtr4 + 1;
						*intPtr4 = (byte)num5;
						break;
					}
					}
				}
				do
				{
					byte* intPtr7 = ptr2;
					ptr2 = intPtr7 + 1;
					byte* intPtr8 = ptr3;
					ptr3 = intPtr8 + 1;
					*intPtr7 = *intPtr8;
				}
				while (--num2 != 0);
			}
			byte* intPtr9 = ptr2;
			ptr2 = intPtr9 + 1;
			*intPtr9 = 17;
			byte* intPtr10 = ptr2;
			ptr2 = intPtr10 + 1;
			*intPtr10 = 0;
			byte* intPtr11 = ptr2;
			ptr2 = intPtr11 + 1;
			*intPtr11 = 0;
			_0020_000A_000A = (uint)(ptr2 - _0020_0020);
			return 0;
		}

		public unsafe static int lzo1x_decompress(byte* @in, uint in_len, byte* @out, ref uint out_len, void* wrkmem)
		{
			byte* ptr = @in + in_len;
			out_len = 0u;
			byte* ptr2 = @out;
			byte* ptr3 = @in;
			bool flag = false;
			bool flag2 = false;
			if (*ptr3 > 17)
			{
				byte* intPtr = ptr3;
				ptr3 = intPtr + 1;
				uint num = (uint)(*intPtr - 17);
				if (num < 4)
				{
					_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A(ref ptr2, ref ptr3, ref num);
				}
				else
				{
					do
					{
						byte* intPtr2 = ptr2;
						ptr2 = intPtr2 + 1;
						byte* intPtr3 = ptr3;
						ptr3 = intPtr3 + 1;
						*intPtr2 = *intPtr3;
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
					byte* intPtr4 = ptr3;
					ptr3 = intPtr4 + 1;
					num = *intPtr4;
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
						uint num2 = num;
						byte* intPtr5 = ptr3;
						ptr3 = intPtr5 + 1;
						num = (uint)((int)num2 + (15 + *intPtr5));
					}
					*(uint*)ptr2 = *(uint*)ptr3;
					ptr2 += 4;
					ptr3 += 4;
					if (--num != 0)
					{
						if (num >= 4)
						{
							do
							{
								*(uint*)ptr2 = *(uint*)ptr3;
								ptr2 += 4;
								ptr3 += 4;
								num -= 4;
							}
							while (num >= 4);
							if (num != 0)
							{
								do
								{
									byte* intPtr6 = ptr2;
									ptr2 = intPtr6 + 1;
									byte* intPtr7 = ptr3;
									ptr3 = intPtr7 + 1;
									*intPtr6 = *intPtr7;
								}
								while (--num != 0);
							}
						}
						else
						{
							do
							{
								byte* intPtr8 = ptr2;
								ptr2 = intPtr8 + 1;
								byte* intPtr9 = ptr3;
								ptr3 = intPtr9 + 1;
								*intPtr8 = *intPtr9;
							}
							while (--num != 0);
						}
					}
				}
				byte* intPtr10 = ptr3;
				ptr3 = intPtr10 + 1;
				num = *intPtr10;
				if (num < 16)
				{
					byte* ptr4 = ptr2 - 2049;
					ptr4 -= num >> 2;
					byte* intPtr11 = ptr4;
					byte* intPtr12 = ptr3;
					ptr3 = intPtr12 + 1;
					ptr4 = intPtr11 - (*intPtr12 << 2);
					byte* intPtr13 = ptr2;
					ptr2 = intPtr13 + 1;
					byte* intPtr14 = ptr4;
					ptr4 = intPtr14 + 1;
					*intPtr13 = *intPtr14;
					byte* intPtr15 = ptr2;
					ptr2 = intPtr15 + 1;
					byte* intPtr16 = ptr4;
					ptr4 = intPtr16 + 1;
					*intPtr15 = *intPtr16;
					byte* intPtr17 = ptr2;
					ptr2 = intPtr17 + 1;
					*intPtr17 = *ptr4;
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
						ptr4 -= ((num >> 2) & 7);
						byte* intPtr18 = ptr4;
						byte* intPtr19 = ptr3;
						ptr3 = intPtr19 + 1;
						ptr4 = intPtr18 - (*intPtr19 << 3);
						num = (num >> 5) - 1;
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020(ref ptr2, ref ptr4, ref num);
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
								uint num3 = num;
								byte* intPtr20 = ptr3;
								ptr3 = intPtr20 + 1;
								num = (uint)((int)num3 + (31 + *intPtr20));
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
								byte* intPtr21 = ptr4;
								byte* intPtr22 = ptr3;
								ptr3 = intPtr22 + 1;
								ptr4 = intPtr21 - (*intPtr22 << 2);
								byte* intPtr23 = ptr2;
								ptr2 = intPtr23 + 1;
								byte* intPtr24 = ptr4;
								ptr4 = intPtr24 + 1;
								*intPtr23 = *intPtr24;
								byte* intPtr25 = ptr2;
								ptr2 = intPtr25 + 1;
								*intPtr25 = *ptr4;
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
								uint num4 = num;
								byte* intPtr26 = ptr3;
								ptr3 = intPtr26 + 1;
								num = (uint)((int)num4 + (7 + *intPtr26));
							}
							ptr4 -= *(ushort*)ptr3 >> 2;
							ptr3 += 2;
							if (ptr4 == ptr2)
							{
								out_len = (uint)(ptr2 - @out);
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
							*(uint*)ptr2 = *(uint*)ptr4;
							ptr2 += 4;
							ptr4 += 4;
							num -= 2;
							while (true)
							{
								*(uint*)ptr2 = *(uint*)ptr4;
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
										byte* intPtr27 = ptr2;
										ptr2 = intPtr27 + 1;
										byte* intPtr28 = ptr4;
										ptr4 = intPtr28 + 1;
										*intPtr27 = *intPtr28;
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
							byte* intPtr29 = ptr2;
							ptr2 = intPtr29 + 1;
							byte* intPtr30 = ptr4;
							ptr4 = intPtr30 + 1;
							*intPtr29 = *intPtr30;
							byte* intPtr31 = ptr2;
							ptr2 = intPtr31 + 1;
							byte* intPtr32 = ptr4;
							ptr4 = intPtr32 + 1;
							*intPtr31 = *intPtr32;
							do
							{
								byte* intPtr33 = ptr2;
								ptr2 = intPtr33 + 1;
								byte* intPtr34 = ptr4;
								ptr4 = intPtr34 + 1;
								*intPtr33 = *intPtr34;
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
					byte* intPtr35 = ptr2;
					ptr2 = intPtr35 + 1;
					byte* intPtr36 = ptr3;
					ptr3 = intPtr36 + 1;
					*intPtr35 = *intPtr36;
					if (num > 1)
					{
						byte* intPtr37 = ptr2;
						ptr2 = intPtr37 + 1;
						byte* intPtr38 = ptr3;
						ptr3 = intPtr38 + 1;
						*intPtr37 = *intPtr38;
						if (num > 2)
						{
							byte* intPtr39 = ptr2;
							ptr2 = intPtr39 + 1;
							byte* intPtr40 = ptr3;
							ptr3 = intPtr40 + 1;
							*intPtr39 = *intPtr40;
						}
					}
					byte* intPtr41 = ptr3;
					ptr3 = intPtr41 + 1;
					num = *intPtr41;
				}
			}
		}

		internal unsafe static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A(ref byte* _0020, ref byte* _0020_000A, ref uint _0020_0020)
		{
			do
			{
				*(_0020++) = *(_0020_000A++);
			}
			while (--_0020_0020 != 0);
			_0020_0020 = *(_0020_000A++);
		}

		internal unsafe static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020(ref byte* _0020, ref byte* _0020_000A, ref uint _0020_0020)
		{
			*(_0020++) = *(_0020_000A++);
			*(_0020++) = *(_0020_000A++);
			do
			{
				*(_0020++) = *(_0020_000A++);
			}
			while (--_0020_0020 != 0);
		}

		internal unsafe static byte[] _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(byte[] _0020, byte[] _0020_000A)
		{
			uint out_len = 0u;
			fixed (byte* @in = _0020)
			{
				fixed (byte* wrkmem = new byte[IntPtr.Size * 16384])
				{
					fixed (byte* @out = _0020_000A)
					{
						lzo1x_decompress(@in, (uint)_0020.Length, @out, ref out_len, wrkmem);
					}
				}
			}
			return _0020_000A;
		}

		internal unsafe static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(byte* _0020, uint _0020_000A, byte* _0020_0020, ref uint _0020_000A_000A)
		{
			fixed (byte* wrkmem = new byte[IntPtr.Size * 16384])
			{
				lzo1x_decompress(_0020, _0020_000A, _0020_0020, ref _0020_000A_000A, wrkmem);
			}
		}

		internal unsafe static byte[] _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020(byte[] _0020)
		{
			byte[] array = new byte[_0020.Length + _0020.Length / 16 + 64 + 3];
			uint newSize = 0u;
			fixed (byte* _00202 = _0020)
			{
				fixed (byte* _0020_000A_0020 = new byte[IntPtr.Size * 16384])
				{
					fixed (byte* _0020_0020 = array)
					{
						_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A(_00202, (uint)_0020.Length, _0020_0020, ref newSize, _0020_000A_0020);
					}
				}
			}
			Array.Resize(ref array, (int)newSize);
			return array;
		}

		internal unsafe static void _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020(byte* _0020, uint _0020_000A, byte* _0020_0020, ref uint _0020_000A_000A)
		{
			fixed (byte* _0020_000A_0020 = new byte[IntPtr.Size * 16384])
			{
				_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A(_0020, _0020_000A, _0020_0020, ref _0020_000A_000A, _0020_000A_0020);
			}
		}

		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A()
		{
			try
			{
				string text = "News\r\nLZO 2.10 has been released; a small update that fixes various build issues.\r\nKey Facts\r\nLZO is a portable lossless data compression library written in ANSI C.\r\nOffers pretty fast compression and *extremely* fast decompression.\r\nOne of the fastest compression and decompression algorithms around. See the ratings for lzop in the famous Archive Comparison Test .\r\nIncludes slower compression levels achieving a quite competitive compression ratio while still decompressing at this very high speed.\r\nDistributed under the terms of the GNU General Public License (GPL v2+). Commercial licenses are available through our LZO Professional license program.\r\nDownload\r\nLZO is distributed as portable ANSI C source code.\r\n\r\nDownload LZO (source code, 587 kB, SHA1: 4924676a9bae5db58ef129dc1cebce3baa3c4b5d).\r\n\r\nminiLZO\r\nminiLZO is a very lightweight subset of the LZO library intended for easy inclusion with your application. It is generated automatically from the LZO source code and contains the most important LZO functions.\r\n\r\nVery easy to use - it only takes a few minutes to add data compression to your application!\r\n\r\nDownload miniLZO (source code, 62 kB, SHA1: c7432708d49017a3f0b4f44c99d336f8a1be84f5).\r\n\r\nRelated links\r\nLZO Professional is our commercial LZO license program.\r\nIf you need better compression you should take a look at the excellent zlib library. zlib is slower and needs more memory, though.\r\nFor even better compression consider using libbzip2 which is distributed with the bzip2 file compressor.\r\nThe file compressor application lzop uses LZO - it is very similar to gzip but much faster.";
				text = text + text + text + text;
				byte[] bytes = Encoding.UTF7.GetBytes(text);
				if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(bytes))
				{
					return false;
				}
				bytes = Encoding.UTF7.GetBytes("The file compressor application lzop uses LZO - it is very similar to gzip but much faster.");
				if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(bytes))
				{
					return false;
				}
				bytes = new byte[1000];
				for (int i = 0; i < bytes.Length; i++)
				{
					bytes[i] = (byte)i;
				}
				if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(bytes))
				{
					return false;
				}
				bytes = new byte[1000];
				for (int j = 0; j < bytes.Length; j++)
				{
					bytes[j] = (byte)((j * 1011 + 13) % 313);
				}
				if (!_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(bytes))
				{
					return false;
				}
				Console.WriteLine("MiniLZO: OK");
				return true;
			}
			catch (Exception arg)
			{
				Console.Error.WriteLine("MiniLZO - ERROR: " + arg);
				return false;
			}
		}

		[CompilerGenerated]
		internal static bool _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A(byte[] _0020)
		{
			byte[] array = _0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020(_0020);
			byte[] array2 = new byte[_0020.Length];
			_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A(array, array2);
			for (int i = 0; i < _0020.Length; i++)
			{
				if (array2[i] != _0020[i])
				{
					Console.Error.WriteLine("MiniLZO - ERROR3");
					return false;
				}
			}
			Console.WriteLine("MiniLZO: " + array.Length * 100 / _0020.Length + "% from original");
			return true;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020(ref ZipStorer.ZipFileEntry _0020)
		{
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A((string)null, (object)null);
			((_0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020)null)._0020_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020();
			return "119193229";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020(string _0020)
		{
			((_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A)null)._0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020_0020_000A_0020((_0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020)null);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_000A>((_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A)null);
			TextFormatting headerFormat = ((TreeListColumn)null).HeaderFormat;
			bool flag = _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020;
			uint pinned = ((Il2CppType)null).pinned;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A
	{
		internal unsafe void _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020(float _0020, object _0020_000A)
		{
			ImageMathTools.GetImageProtector(null);
			((_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A)null)._0020_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A();
			((StrSth)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A((_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)null);
			_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(ref *(_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A*)null);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020()
		{
			((ProtoReader)null).ReadByte();
			_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_0020((string)null, (byte[])null);
			Dim dim = ((ImageType)null).Dim;
			return 2089081615;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020(int _0020, int _0020_000A)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020(_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A _0020, float _0020_000A)
		{
			return "595341258";
		}
	}
}
