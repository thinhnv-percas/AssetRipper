using System;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

internal class InteropUtilities
{
	internal delegate int CountGetter<TEntity>(TEntity entity, out int count);

	internal delegate int ItemsGetter<TEntity, TItem>(TEntity entity, int bufferLength, out int count, TItem[] buffer);

	internal delegate int ItemsGetter<TEntity, TArg1, TItem>(TEntity entity, TArg1 arg1, int bufferLength, out int count, TItem[] buffer);

	internal delegate int ItemsGetter<TEntity, TArg1, TArg2, TItem>(TEntity entity, TArg1 arg1, TArg2 arg2, int bufferLength, out int count, TItem[] buffer);

	private static readonly IntPtr s_ignoreIErrorInfo = new IntPtr(-1);

	internal static T[] NullToEmpty<T>(T[] items)
	{
		if (items != null)
		{
			return items;
		}
		return EmptyArray<T>.Instance;
	}

	internal static void ThrowExceptionForHR(int hr)
	{
		if (hr < 0 && hr != -2147467259 && hr != -2147467263)
		{
			Marshal.ThrowExceptionForHR(hr, s_ignoreIErrorInfo);
		}
	}

	internal unsafe static void CopyQualifiedTypeName(char* qualifiedName, int qualifiedNameBufferLength, int* qualifiedNameLength, string namespaceStr, string nameStr)
	{
		if (namespaceStr == null)
		{
			namespaceStr = string.Empty;
		}
		if (qualifiedNameLength != null)
		{
			int num = ((namespaceStr.Length > 0) ? (namespaceStr.Length + 1) : 0) + nameStr.Length;
			if (qualifiedName != null)
			{
				*qualifiedNameLength = Math.Min(num, Math.Max(0, qualifiedNameBufferLength - 1));
			}
			else
			{
				*qualifiedNameLength = num;
			}
		}
		if (qualifiedName == null || qualifiedNameBufferLength <= 0)
		{
			return;
		}
		char* ptr = qualifiedName;
		char* ptr2 = ptr + qualifiedNameBufferLength - 1;
		if (namespaceStr.Length > 0)
		{
			for (int i = 0; i < namespaceStr.Length; i++)
			{
				if (ptr >= ptr2)
				{
					break;
				}
				*ptr = namespaceStr[i];
				ptr++;
			}
			if (ptr < ptr2)
			{
				*ptr = '.';
				ptr++;
			}
		}
		for (int j = 0; j < nameStr.Length; j++)
		{
			if (ptr >= ptr2)
			{
				break;
			}
			*ptr = nameStr[j];
			ptr++;
		}
		*ptr = '\0';
	}

	internal static string BufferToString(char[] buffer)
	{
		return new string(buffer, 0, buffer.Length - 1);
	}

	internal static void ValidateItems(int actualCount, int bufferLength)
	{
		if (actualCount != bufferLength)
		{
			throw new InvalidOperationException($"Read only {actualCount} of {bufferLength} items.");
		}
	}

	internal static TItem[] GetItems<TEntity, TItem>(TEntity entity, CountGetter<TEntity> countGetter, ItemsGetter<TEntity, TItem> itemsGetter)
	{
		ThrowExceptionForHR(countGetter(entity, out var count));
		if (count == 0)
		{
			return null;
		}
		TItem[] array = new TItem[count];
		ThrowExceptionForHR(itemsGetter(entity, count, out count, array));
		ValidateItems(count, array.Length);
		return array;
	}

	internal static TItem[] GetItems<TEntity, TItem>(TEntity entity, ItemsGetter<TEntity, TItem> getter)
	{
		ThrowExceptionForHR(getter(entity, 0, out var count, null));
		if (count == 0)
		{
			return null;
		}
		TItem[] array = new TItem[count];
		ThrowExceptionForHR(getter(entity, count, out count, array));
		ValidateItems(count, array.Length);
		return array;
	}

	internal static TItem[] GetItems<TEntity, TArg1, TItem>(TEntity entity, TArg1 arg1, ItemsGetter<TEntity, TArg1, TItem> getter)
	{
		ThrowExceptionForHR(getter(entity, arg1, 0, out var count, null));
		if (count == 0)
		{
			return null;
		}
		TItem[] array = new TItem[count];
		ThrowExceptionForHR(getter(entity, arg1, count, out count, array));
		ValidateItems(count, array.Length);
		return array;
	}

	internal static TItem[] GetItems<TEntity, TArg1, TArg2, TItem>(TEntity entity, TArg1 arg1, TArg2 arg2, ItemsGetter<TEntity, TArg1, TArg2, TItem> getter)
	{
		ThrowExceptionForHR(getter(entity, arg1, arg2, 0, out var count, null));
		if (count == 0)
		{
			return null;
		}
		TItem[] array = new TItem[count];
		ThrowExceptionForHR(getter(entity, arg1, arg2, count, out count, array));
		ValidateItems(count, array.Length);
		return array;
	}
}
