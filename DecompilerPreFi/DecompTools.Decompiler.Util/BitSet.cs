#define DEBUG
using System;
using System.Diagnostics;
using System.Text;

namespace DecompTools.Decompiler.Util;

public class BitSet
{
	private const int BitsPerWord = 64;

	private const int Log2BitsPerWord = 6;

	private const ulong Mask = ulong.MaxValue;

	private readonly ulong[] words;

	public bool this[int index]
	{
		get
		{
			return (words[WordIndex(index)] & (ulong)(1L << index)) != 0;
		}
		set
		{
			if (value)
			{
				Set(index);
			}
			else
			{
				Clear(index);
			}
		}
	}

	private static int WordIndex(int bitIndex)
	{
		Debug.Assert(bitIndex >= 0);
		return bitIndex >> 6;
	}

	public BitSet(int capacity)
	{
		words = new ulong[Math.Max(1, WordIndex(checked(capacity + 64 - 1)))];
	}

	private BitSet(ulong[] bits)
	{
		words = bits;
	}

	public BitSet Clone()
	{
		return new BitSet((ulong[])words.Clone());
	}

	public bool Any()
	{
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			if (words[i] != 0)
			{
				return true;
			}
		}
		return false;
	}

	public bool All(int startIndex, int endIndex)
	{
		Debug.Assert(startIndex <= endIndex);
		if (startIndex >= endIndex)
		{
			return true;
		}
		int num = WordIndex(startIndex);
		int num2 = WordIndex(checked(endIndex - 1));
		ulong num3 = (ulong)(-1L << startIndex);
		checked
		{
			ulong num4 = ulong.MaxValue >> -endIndex;
			if (num == num2)
			{
				return (words[num] & (num3 & num4)) == (num3 & num4);
			}
			if ((words[num] & num3) != num3)
			{
				return false;
			}
			for (int i = num + 1; i < num2; i++)
			{
				if (words[i] != ulong.MaxValue)
				{
					return false;
				}
			}
			return (words[num2] & num4) == num4;
		}
	}

	public bool SetEquals(BitSet other)
	{
		Debug.Assert(words.Length == other.words.Length);
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			if (words[i] != other.words[i])
			{
				return false;
			}
		}
		return true;
	}

	public bool IsSubsetOf(BitSet other)
	{
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			if ((words[i] & ~other.words[i]) != 0)
			{
				return false;
			}
		}
		return true;
	}

	public bool IsSupersetOf(BitSet other)
	{
		return other.IsSubsetOf(this);
	}

	public bool IsProperSubsetOf(BitSet other)
	{
		return IsSubsetOf(other) && !SetEquals(other);
	}

	public bool IsProperSupersetOf(BitSet other)
	{
		return IsSupersetOf(other) && !SetEquals(other);
	}

	public bool Overlaps(BitSet other)
	{
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			if ((words[i] & other.words[i]) != 0)
			{
				return true;
			}
		}
		return false;
	}

	public void UnionWith(BitSet other)
	{
		Debug.Assert(words.Length == other.words.Length);
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			words[i] |= other.words[i];
		}
	}

	public void IntersectWith(BitSet other)
	{
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			words[i] &= other.words[i];
		}
	}

	public void Set(int index)
	{
		words[WordIndex(index)] |= (ulong)(1L << index);
	}

	public void Set(int startIndex, int endIndex)
	{
		Debug.Assert(startIndex <= endIndex);
		if (startIndex >= endIndex)
		{
			return;
		}
		int num = WordIndex(startIndex);
		int num2 = WordIndex(checked(endIndex - 1));
		ulong num3 = (ulong)(-1L << startIndex);
		checked
		{
			ulong num4 = ulong.MaxValue >> -endIndex;
			if (num == num2)
			{
				words[num] |= num3 & num4;
				return;
			}
			words[num] |= num3;
			for (int i = num + 1; i < num2; i++)
			{
				words[i] = ulong.MaxValue;
			}
			words[num2] |= num4;
		}
	}

	public void Clear(int index)
	{
		words[WordIndex(index)] &= (ulong)(~(1L << index));
	}

	public void Clear(int startIndex, int endIndex)
	{
		Debug.Assert(startIndex <= endIndex);
		if (startIndex >= endIndex)
		{
			return;
		}
		int num = WordIndex(startIndex);
		int num2 = WordIndex(checked(endIndex - 1));
		ulong num3 = (ulong)(-1L << startIndex);
		checked
		{
			ulong num4 = ulong.MaxValue >> -endIndex;
			if (num == num2)
			{
				words[num] &= ~(num3 & num4);
				return;
			}
			words[num] &= ~num3;
			for (int i = num + 1; i < num2; i++)
			{
				words[i] = 0uL;
			}
			words[num2] &= ~num4;
		}
	}

	public void ClearAll()
	{
		for (int i = 0; i < words.Length; i = checked(i + 1))
		{
			words[i] = 0uL;
		}
	}

	public void ReplaceWith(BitSet incoming)
	{
		Debug.Assert(words.Length == incoming.words.Length);
		Array.Copy(incoming.words, 0, words, 0, words.Length);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append('{');
		checked
		{
			for (int i = 0; i < words.Length * 64; i++)
			{
				if (this[i])
				{
					if (stringBuilder.Length > 1)
					{
						stringBuilder.Append(", ");
					}
					if (stringBuilder.Length > 500)
					{
						stringBuilder.Append("...");
						break;
					}
					stringBuilder.Append(i);
				}
			}
			stringBuilder.Append('}');
			return stringBuilder.ToString();
		}
	}
}
