using APK;
using ARMD;
using @as;
using DevXUnityUnpackerTools.Properties;
using DSMCaps.Arm64;
using FMOD;
using ICSharpCode.SharpZipLib.Tar;
using Mono.Cecil;
using System.Drawing;
using System.IO;
using Unity.IO.Compression;
using Unreal;
using Wasm.Interpret;

namespace Unity.CecilTools.Extensions
{
	internal static class _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020
	{
		public static bool SameAs(this MethodDefinition self, MethodDefinition other)
		{
			return self.FullName == other.FullName;
		}

		public static string PropertyName(this MethodDefinition self)
		{
			return self.Name.Substring(4);
		}

		public static bool IsConversionOperator(this MethodDefinition method)
		{
			if (!method.IsSpecialName)
			{
				return false;
			}
			if (!(method.Name == "op_Implicit"))
			{
				return method.Name == "op_Explicit";
			}
			return true;
		}

		public static bool IsSimpleSetter(this MethodDefinition original)
		{
			if (original.IsSetter)
			{
				return original.Parameters.Count == 1;
			}
			return false;
		}

		public static bool IsSimpleGetter(this MethodDefinition original)
		{
			if (original.IsGetter)
			{
				return original.Parameters.Count == 0;
			}
			return false;
		}

		public static bool IsSimplePropertyAccessor(this MethodDefinition method)
		{
			if (!method.IsSimpleGetter())
			{
				return method.IsSimpleSetter();
			}
			return true;
		}

		public static bool IsDefaultConstructor(MethodDefinition m)
		{
			if (m.IsConstructor && !m.IsStatic)
			{
				return m.Parameters.Count == 0;
			}
			return false;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_0020(string _0020, short _0020_000A, bool _0020_0020, DSP_PARAMETER_3DATTRIBUTES _0020_000A_000A)
		{
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A((Stream)null);
			Bitmap title_GameRecovery = Resources.Title_GameRecovery;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_0020(_0020_0020_000A_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020 _0020, _0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A _0020_000A, _0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A _0020_0020)
		{
			ImageResData imageResDatum = ((_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020(object _0020, _0020_000A_0020_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020 _0020_000A, decimal _0020_0020)
		{
			return "1116932108";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_0020(byte[] _0020, int _0020_000A, int _0020_0020, byte[] _0020_000A_000A)
		{
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_0020(Arm64InstructionGroup _0020, decimal _0020_000A)
		{
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020_0020_0020)null).LinkName = null;
			OperatorImpls.Int64Ne(null, null);
			((_0020_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A();
			return 64652813;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020_0020(_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A _0020, string _0020_000A)
		{
			return null;
		}
	}
}
