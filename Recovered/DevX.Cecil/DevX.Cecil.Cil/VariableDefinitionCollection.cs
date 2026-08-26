using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	public sealed class VariableDefinitionCollection : CollectionBase, ICodeVisitable
	{
		private IVariableDefinitionProvider m_container;

		public VariableDefinition this[int index]
		{
			get
			{
				return base.List[index] as VariableDefinition;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public IVariableDefinitionProvider Container => m_container;

		public VariableDefinitionCollection(IVariableDefinitionProvider container)
		{
			m_container = container;
		}

		public void Add(VariableDefinition value)
		{
			base.List.Add(value);
		}

		public bool Contains(VariableDefinition value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(VariableDefinition value)
		{
			return base.List.IndexOf(value);
		}

		public void Insert(int index, VariableDefinition value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(VariableDefinition value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is VariableDefinition))
			{
				throw new ArgumentException("Must be of type " + typeof(VariableDefinition).FullName);
			}
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitVariableDefinitionCollection(this);
		}
	}
}
