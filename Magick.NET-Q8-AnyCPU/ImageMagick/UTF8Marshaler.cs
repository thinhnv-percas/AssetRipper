using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ImageMagick;

internal sealed class UTF8Marshaler : INativeInstance, IDisposable
{
	public IntPtr Instance { get; private set; }

	private UTF8Marshaler(string value)
	{
		Instance = ManagedToNative(value);
	}

	public void Dispose()
	{
		if (!(Instance == IntPtr.Zero))
		{
			Marshal.FreeHGlobal(Instance);
			Instance = IntPtr.Zero;
		}
	}

	internal static INativeInstance CreateInstance(string value)
	{
		return new UTF8Marshaler(value);
	}

	internal static IntPtr ManagedToNative(string value)
	{
		if (value == null)
		{
			return IntPtr.Zero;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length + 1);
		Marshal.Copy(bytes, 0, intPtr, bytes.Length);
		Marshal.WriteByte(intPtr + bytes.Length, 0);
		return intPtr;
	}

	internal static string NativeToManaged(IntPtr nativeData)
	{
		byte[] array = ByteConverter.ToArray(nativeData);
		if (array == null)
		{
			return null;
		}
		if (array.Length == 0)
		{
			return string.Empty;
		}
		return Encoding.UTF8.GetString(array, 0, array.Length);
	}

	internal static string NativeToManagedAndRelinquish(IntPtr nativeData)
	{
		string result = NativeToManaged(nativeData);
		MagickMemory.Relinquish(nativeData);
		return result;
	}
}
