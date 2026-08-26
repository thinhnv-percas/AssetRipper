using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class ParameterDefinitionCollection : CollectionBase, IReflectionVisitable
	{
		private IMemberReference m_container;

		public ParameterDefinition this[int index]
		{
			get
			{
				return base.List[index] as ParameterDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public IMemberReference Container => m_container;

		public ParameterDefinitionCollection(IMemberReference container)
		{
			m_container = container;
		}

		public void Add(ParameterDefinition value)
		{
			base.List.Add(value);
		}

		public bool Contains(ParameterDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(ParameterDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, ParameterDefinition value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ParameterDefinition value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is ParameterDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(ParameterDefinition).FullName);
			}
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitParameterDefinitionCollection(this);
		}
	}
}
