using System;
using System.Collections;

namespace DevX.Cecil.Cil
{
	public sealed class InstructionCollection : CollectionBase, ICodeVisitable
	{
		private MethodBody m_container;

		public readonly Instruction Outside = new Instruction(int.MaxValue, OpCodes.Nop);

		public Instruction this[int index]
		{
			get
			{
				return base.List[index] as Instruction;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public MethodBody Container => m_container;

		public InstructionCollection(MethodBody container)
		{
			m_container = container;
		}

		internal void Add(Instruction value)
		{
			base.List.Add(value);
		}

		public bool Contains(Instruction value)
		{
			return base.List.Contains(value);
		}

		public int IndexOf(Instruction value)
		{
			return base.List.IndexOf(value);
		}

		internal void Insert(int index, Instruction value)
		{
			base.List.Insert(index, value);
		}

		internal void Remove(Instruction value)
		{
			base.List.Remove(value);
		}

		protected override void OnValidate(object o)
		{
			if (!(o is Instruction))
			{
				throw new ArgumentException("Must be of type " + typeof(Instruction).FullName);
			}
		}

		public void Accept(ICodeVisitor visitor)
		{
			visitor.VisitInstructionCollection(this);
		}
	}
}
