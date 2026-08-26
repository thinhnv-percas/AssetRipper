using System;
using System.Threading;

namespace ICSharpCode.NRefactory
{
	public abstract class Role
	{
		public const int RoleIndexBits = 9;

		private static readonly Role[] roles = new Role[512];

		private static int nextRoleIndex = 0;

		private readonly uint index;

		[CLSCompliant(false)]
		public uint Index => index;

		internal Role()
		{
			index = (uint)Interlocked.Increment(ref nextRoleIndex);
			if (index >= roles.Length)
			{
				throw new InvalidOperationException("Too many roles");
			}
			roles[index] = this;
		}

		public abstract bool IsValid(object node);

		[CLSCompliant(false)]
		public static Role GetByIndex(uint index)
		{
			return roles[index];
		}
	}
	public class Role<T> : Role where T : class
	{
		private readonly string name;

		private readonly T nullObject;

		public T NullObject => nullObject;

		public override bool IsValid(object node)
		{
			return node is T;
		}

		public Role(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.name = name;
		}

		public Role(string name, T nullObject)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (nullObject == null)
			{
				throw new ArgumentNullException("nullObject");
			}
			this.nullObject = nullObject;
			this.name = name;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
