using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	public sealed class ExceptionHandlerCollection : CollectionBase, ICodeVisitable
	{
		private MethodBody m_container;

		public ExceptionHandler this[int index]
		{
			get
			{
				return base.List[index] as ExceptionHandler;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public MethodBody Container => m_container;

		public ExceptionHandlerCollection(MethodBody container)
		{
			m_container = container;
		}

		public void Add(ExceptionHandler value)
		{
			base.List.Add(value);
		}

		public bool Contains(ExceptionHandler value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ExceptionHandler value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, ExceptionHandler value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ExceptionHandler value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is ExceptionHandler))
			{
				throw new ArgumentException("Must be of type " + typeof(ExceptionHandler).FullName);
			}
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitExceptionHandlerCollection(this);
		}
	}
}
