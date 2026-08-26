using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class PointerType : Type
	{
		[CompilerGenerated]
		internal readonly StorageClass _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020;

		[CompilerGenerated]
		internal Type _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public StorageClass StorageClass
		{
			get;
		}

		public Type Type
		{
			get;
			internal set;
		}

		public PointerType(StorageClass storageClass, Type type)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020 = storageClass;
			Type = type;
		}

		public PointerType(StorageClass storageClass)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020 = storageClass;
		}

		public void ResolveForwardReference(Type t)
		{
			Type = t;
		}

		public override string ToString()
		{
			if (Type == null)
			{
				return $"{StorageClass} *";
			}
			return $"{StorageClass} {Type}*";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			sb.Append(StorageClass.ToString()).Append(' ');
			if (Type != null)
			{
				Type.ToString(sb);
			}
			sb.Append('*');
			return sb;
		}
	}
}
