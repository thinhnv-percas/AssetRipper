using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class ControlFlowEdge
	{
		public readonly ControlFlowNode From;

		public readonly ControlFlowNode To;

		public readonly ControlFlowEdgeType Type;

		private List<TryCatchStatement> jumpOutOfTryFinally;

		public bool IsLeavingTryFinally => jumpOutOfTryFinally != null;

		public IEnumerable<TryCatchStatement> TryFinallyStatements
		{
			get
			{
				IEnumerable<TryCatchStatement> enumerable = jumpOutOfTryFinally;
				return enumerable ?? Enumerable.Empty<TryCatchStatement>();
			}
		}

		public ControlFlowEdge(ControlFlowNode from, ControlFlowNode to, ControlFlowEdgeType type)
		{
			if (from == null)
			{
				throw new ArgumentNullException("from");
			}
			if (to == null)
			{
				throw new ArgumentNullException("to");
			}
			From = from;
			To = to;
			Type = type;
		}

		internal void AddJumpOutOfTryFinally(TryCatchStatement tryFinally)
		{
			if (jumpOutOfTryFinally == null)
			{
				jumpOutOfTryFinally = new List<TryCatchStatement>();
			}
			jumpOutOfTryFinally.Add(tryFinally);
		}
	}
}
