using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;

namespace ImageMagick;

public sealed class MagickFormatInfo : IEquatable<MagickFormatInfo>
{
	private static class NativeMethods
	{
		public static class X64
		{
			static X64()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Description_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_CanReadMultithreaded_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_CanWriteMultithreaded_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsMultiFrame_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsReadable_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsWritable_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_MimeType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Module_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_CreateList(out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickFormatInfo_DisposeList(IntPtr instance, UIntPtr length);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_GetInfo(IntPtr list, UIntPtr index, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_GetInfoByName(IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x64.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_Unregister(IntPtr name);
		}

		public static class X86
		{
			static X86()
			{
				NativeLibraryLoader.Load();
			}

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Description_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_CanReadMultithreaded_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_CanWriteMultithreaded_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Format_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsMultiFrame_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsReadable_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_IsWritable_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_MimeType_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_Module_Get(IntPtr instance);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_CreateList(out UIntPtr length, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern void MagickFormatInfo_DisposeList(IntPtr instance, UIntPtr length);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_GetInfo(IntPtr list, UIntPtr index, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			public static extern IntPtr MagickFormatInfo_GetInfoByName(IntPtr name, out IntPtr exception);

			[DllImport("Magick.NET-Q8-x86.Native.dll", CallingConvention = CallingConvention.Cdecl)]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool MagickFormatInfo_Unregister(IntPtr name);
		}
	}

	private sealed class NativeMagickFormatInfo : ConstNativeInstance
	{
		protected override string TypeName => "MagickFormatInfo";

		public string Description
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_Description_Get(base.Instance) : NativeMethods.X64.MagickFormatInfo_Description_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public bool CanReadMultithreaded
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickFormatInfo_CanReadMultithreaded_Get(base.Instance);
				}
				return NativeMethods.X86.MagickFormatInfo_CanReadMultithreaded_Get(base.Instance);
			}
		}

		public bool CanWriteMultithreaded
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickFormatInfo_CanWriteMultithreaded_Get(base.Instance);
				}
				return NativeMethods.X86.MagickFormatInfo_CanWriteMultithreaded_Get(base.Instance);
			}
		}

		public string Format
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_Format_Get(base.Instance) : NativeMethods.X64.MagickFormatInfo_Format_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public bool IsMultiFrame
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickFormatInfo_IsMultiFrame_Get(base.Instance);
				}
				return NativeMethods.X86.MagickFormatInfo_IsMultiFrame_Get(base.Instance);
			}
		}

		public bool IsReadable
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickFormatInfo_IsReadable_Get(base.Instance);
				}
				return NativeMethods.X86.MagickFormatInfo_IsReadable_Get(base.Instance);
			}
		}

		public bool IsWritable
		{
			get
			{
				if (NativeLibrary.Is64Bit)
				{
					return NativeMethods.X64.MagickFormatInfo_IsWritable_Get(base.Instance);
				}
				return NativeMethods.X86.MagickFormatInfo_IsWritable_Get(base.Instance);
			}
		}

		public string MimeType
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_MimeType_Get(base.Instance) : NativeMethods.X64.MagickFormatInfo_MimeType_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		public string Module
		{
			get
			{
				IntPtr nativeData = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_Module_Get(base.Instance) : NativeMethods.X64.MagickFormatInfo_Module_Get(base.Instance));
				return UTF8Marshaler.NativeToManaged(nativeData);
			}
		}

		static NativeMagickFormatInfo()
		{
			Environment.Initialize();
		}

		public IntPtr CreateList(out UIntPtr length)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr intPtr = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_CreateList(out length, out exception) : NativeMethods.X64.MagickFormatInfo_CreateList(out length, out exception));
			MagickException ex = MagickExceptionHelper.Create(exception);
			if (MagickExceptionHelper.IsError(ex))
			{
				if (intPtr != IntPtr.Zero)
				{
					DisposeList(intPtr, (int)(uint)length);
				}
				throw ex;
			}
			RaiseWarning(ex);
			return intPtr;
		}

		public static void DisposeList(IntPtr instance, int length)
		{
			if (NativeLibrary.Is64Bit)
			{
				NativeMethods.X64.MagickFormatInfo_DisposeList(instance, (UIntPtr)(ulong)length);
			}
			else
			{
				NativeMethods.X86.MagickFormatInfo_DisposeList(instance, (UIntPtr)(ulong)length);
			}
		}

		public void GetInfo(IntPtr list, int index)
		{
			IntPtr exception = IntPtr.Zero;
			IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_GetInfo(list, (UIntPtr)(ulong)index, out exception) : NativeMethods.X64.MagickFormatInfo_GetInfo(list, (UIntPtr)(ulong)index, out exception));
			CheckException(exception);
			base.Instance = instance;
		}

		public void GetInfoByName(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			IntPtr exception = IntPtr.Zero;
			IntPtr instance = ((!NativeLibrary.Is64Bit) ? NativeMethods.X86.MagickFormatInfo_GetInfoByName(nativeInstance.Instance, out exception) : NativeMethods.X64.MagickFormatInfo_GetInfoByName(nativeInstance.Instance, out exception));
			CheckException(exception);
			base.Instance = instance;
		}

		public static bool Unregister(string name)
		{
			using INativeInstance nativeInstance = UTF8Marshaler.CreateInstance(name);
			if (NativeLibrary.Is64Bit)
			{
				return NativeMethods.X64.MagickFormatInfo_Unregister(nativeInstance.Instance);
			}
			return NativeMethods.X86.MagickFormatInfo_Unregister(nativeInstance.Instance);
		}
	}

	private static readonly Dictionary<MagickFormat, MagickFormatInfo> _All = LoadFormats();

	public bool CanReadMultithreaded { get; private set; }

	public bool CanWriteMultithreaded { get; private set; }

	public string Description { get; private set; }

	public MagickFormat Format { get; private set; }

	public bool IsMultiFrame { get; private set; }

	public bool IsReadable { get; private set; }

	public bool IsWritable { get; private set; }

	public string MimeType { get; private set; }

	public MagickFormat Module { get; private set; }

	internal static IEnumerable<MagickFormatInfo> All => _All.Values;

	internal static MagickFormat GetFormat(ImageFormat format)
	{
		if (format == ImageFormat.Bmp)
		{
			return MagickFormat.Bmp;
		}
		if (format == ImageFormat.Gif)
		{
			return MagickFormat.Gif;
		}
		if (format == ImageFormat.Icon)
		{
			return MagickFormat.Icon;
		}
		if (format == ImageFormat.Jpeg)
		{
			return MagickFormat.Jpeg;
		}
		if (format == ImageFormat.Png)
		{
			return MagickFormat.Png;
		}
		if (format == ImageFormat.Tiff)
		{
			return MagickFormat.Tiff;
		}
		throw new NotSupportedException("Unsupported image format: " + format.ToString());
	}

	private MagickFormatInfo()
	{
	}

	public static bool operator ==(MagickFormatInfo left, MagickFormatInfo right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(MagickFormatInfo left, MagickFormatInfo right)
	{
		return !object.Equals(left, right);
	}

	public static MagickFormatInfo Create(FileInfo file)
	{
		Throw.IfNull("file", file);
		MagickFormat? magickFormat = null;
		if (file.Extension != null && file.Extension.Length > 1)
		{
			magickFormat = EnumHelper.Parse<MagickFormat>(file.Extension.Substring(1));
		}
		if (!magickFormat.HasValue)
		{
			return null;
		}
		return Create(magickFormat.Value);
	}

	public static MagickFormatInfo Create(MagickFormat format)
	{
		if (!_All.ContainsKey(format))
		{
			return null;
		}
		return _All[format];
	}

	public static MagickFormatInfo Create(string fileName)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		return Create(new FileInfo(text));
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as MagickFormatInfo);
	}

	public bool Equals(MagickFormatInfo other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		return Format == other.Format;
	}

	public override int GetHashCode()
	{
		return Module.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "{0}: {1} ({2}R{3}W{4}M)", Format, Description, IsReadable ? "+" : "-", IsWritable ? "+" : "-", IsMultiFrame ? "+" : "-");
	}

	public bool Unregister()
	{
		return NativeMagickFormatInfo.Unregister(EnumHelper.GetName(Format));
	}

	private static MagickFormatInfo Create(NativeMagickFormatInfo instance)
	{
		if (!instance.HasInstance)
		{
			return null;
		}
		return new MagickFormatInfo
		{
			Format = GetFormat(instance.Format),
			Description = instance.Description,
			CanReadMultithreaded = instance.CanReadMultithreaded,
			CanWriteMultithreaded = instance.CanWriteMultithreaded,
			IsMultiFrame = instance.IsMultiFrame,
			IsReadable = instance.IsReadable,
			IsWritable = instance.IsWritable,
			MimeType = instance.MimeType,
			Module = GetFormat(instance.Module)
		};
	}

	private static MagickFormatInfo Create(NativeMagickFormatInfo instance, string name)
	{
		instance.GetInfoByName(name);
		return Create(instance);
	}

	private static MagickFormat GetFormat(string format)
	{
		format = format.Replace("-", string.Empty);
		switch (format)
		{
		case "3FR":
			format = "ThreeFr";
			break;
		case "3G2":
			format = "ThreeG2";
			break;
		case "3GP":
			format = "ThreeGp";
			break;
		}
		return EnumHelper.Parse(format, MagickFormat.Unknown);
	}

	private static Dictionary<MagickFormat, MagickFormatInfo> LoadFormats()
	{
		Dictionary<MagickFormat, MagickFormatInfo> dictionary = new Dictionary<MagickFormat, MagickFormatInfo>();
		IntPtr intPtr = IntPtr.Zero;
		UIntPtr length = (UIntPtr)0uL;
		NativeMagickFormatInfo nativeMagickFormatInfo = new NativeMagickFormatInfo();
		try
		{
			intPtr = nativeMagickFormatInfo.CreateList(out length);
			IntPtr intPtr2 = intPtr;
			MagickFormatInfo magickFormatInfo;
			for (int i = 0; i < (int)(uint)length; i++)
			{
				nativeMagickFormatInfo.GetInfo(intPtr, i);
				magickFormatInfo = Create(nativeMagickFormatInfo);
				if (magickFormatInfo != null)
				{
					dictionary[magickFormatInfo.Format] = magickFormatInfo;
				}
				intPtr2 = new IntPtr(intPtr2.ToInt64() + i);
			}
			magickFormatInfo = Create(nativeMagickFormatInfo, "DIB");
			if (magickFormatInfo != null)
			{
				dictionary[magickFormatInfo.Format] = magickFormatInfo;
			}
			magickFormatInfo = Create(nativeMagickFormatInfo, "TIF");
			if (magickFormatInfo != null)
			{
				dictionary[magickFormatInfo.Format] = magickFormatInfo;
			}
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				NativeMagickFormatInfo.DisposeList(intPtr, (int)(uint)length);
			}
		}
		return dictionary;
	}
}
