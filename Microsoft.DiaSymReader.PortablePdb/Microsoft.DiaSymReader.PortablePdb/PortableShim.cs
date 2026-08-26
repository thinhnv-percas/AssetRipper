using System;
using System.IO;
using System.Reflection;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class PortableShim
{
	private static class CoreNames
	{
		internal const string System_IO_FileSystem = "System.IO.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

		internal const string System_IO_FileSystem_Primitives = "System.IO.FileSystem.Primitives, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

		internal const string System_Runtime_Extensions = "System.Runtime.Extensions, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";
	}

	internal static class Environment
	{
		internal const string TypeName = "System.Environment";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.Environment", "System.Runtime.Extensions, Version=4.0.10.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.Environment");

		internal static Func<string, string> GetEnvironmentVariable = (Func<string, string>)Type.GetTypeInfo().GetDeclaredMethod("GetEnvironmentVariable", typeof(string)).CreateDelegate(typeof(Func<string, string>));
	}

	internal static class File
	{
		internal const string TypeName = "System.IO.File";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.IO.File", "System.IO.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.IO.File");

		internal static readonly Func<string, bool> Exists = ReflectionUtilities.CreateDelegate<Func<string, bool>>(Type.GetTypeInfo().GetDeclaredMethod("Exists", typeof(string)));

		internal static readonly Func<string, byte[]> ReadAllBytes = ReflectionUtilities.CreateDelegate<Func<string, byte[]>>(Type.GetTypeInfo().GetDeclaredMethod("ReadAllBytes", typeof(string)));
	}

	internal static class FileMode
	{
		internal const string TypeName = "System.IO.FileMode";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.IO.FileMode", "System.IO.FileSystem.Primitives, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.IO.FileMode");

		internal static readonly object Open = Enum.ToObject(Type, (object)3);
	}

	internal static class FileAccess
	{
		internal const string TypeName = "System.IO.FileAccess";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.IO.FileAccess", "System.IO.FileSystem.Primitives, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.IO.FileAccess");

		internal static readonly object Read = Enum.ToObject(Type, (object)1);
	}

	internal static class FileShare
	{
		internal const string TypeName = "System.IO.FileShare";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.IO.FileShare", "System.IO.FileSystem.Primitives, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.IO.FileShare");

		internal static readonly object ReadOrDelete = Enum.ToObject(Type, (object)5);
	}

	internal static class FileStream
	{
		internal const string TypeName = "System.IO.FileStream";

		internal static readonly Type Type = ReflectionUtilities.GetTypeFromEither(string.Format("{0}, {1}", new object[2] { "System.IO.FileStream", "System.IO.FileSystem, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" }), "System.IO.FileStream");

		private static ConstructorInfo s_Ctor_String_FileMode_FileAccess_FileShare = Type.GetTypeInfo().GetDeclaredConstructor(typeof(string), FileMode.Type, FileAccess.Type, FileShare.Type);

		internal static Stream CreateReadShareDelete(string path)
		{
			return s_Ctor_String_FileMode_FileAccess_FileShare.InvokeConstructor<Stream>(new object[4]
			{
				path,
				FileMode.Open,
				FileAccess.Read,
				FileShare.ReadOrDelete
			});
		}
	}
}
