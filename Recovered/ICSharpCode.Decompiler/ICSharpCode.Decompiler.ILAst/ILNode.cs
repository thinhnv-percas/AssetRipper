using System;
using System.Collections.Generic;
using System.IO;

namespace ICSharpCode.Decompiler.ILAst
{
	public abstract class ILNode
	{
		public IEnumerable<T> GetSelfAndChildrenRecursive<T>(Func<T, bool> predicate = null) where T : ILNode
		{
			List<T> list = new List<T>(16);
			AccumulateSelfAndChildrenRecursive(list, predicate);
			return list;
		}

		private void AccumulateSelfAndChildrenRecursive<T>(List<T> list, Func<T, bool> predicate) where T : ILNode
		{
			T val = this as T;
			if (val != null && (predicate == null || predicate(val)))
			{
				list.Add(val);
			}
			foreach (ILNode child in GetChildren())
			{
				child?.AccumulateSelfAndChildrenRecursive(list, predicate);
			}
		}

		public virtual IEnumerable<ILNode> GetChildren()
		{
			yield break;
		}

		public override string ToString()
		{
			StringWriter stringWriter = new StringWriter();
			WriteTo(new PlainTextOutput(stringWriter));
			return stringWriter.ToString().Replace("\r\n", "; ");
		}

		public abstract void WriteTo(ITextOutput output);
	}
}
