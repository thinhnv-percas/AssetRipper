using System;

namespace DSMCaps
{
	public abstract class InstructionGroup<TId> where TId : Enum
	{
		private readonly string _name;

		public TId Id
		{
			get;
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		public string Name
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _name;
			}
		}

		private protected InstructionGroup(TId id, string name)
		{
			Id = id;
			_name = name;
		}

		public override bool Equals(object @object)
		{
			bool flag = @object != null;
			if (flag)
			{
				InstructionGroup<TId> instructionGroup = @object as InstructionGroup<TId>;
				flag = (instructionGroup != null);
				if (flag)
				{
					flag = (Id.Equals(instructionGroup.Id) && _name == instructionGroup._name);
				}
			}
			return flag;
		}

		public override int GetHashCode()
		{
			int num = 13;
			num = num * 7 + Id.GetHashCode();
			return (_name != null) ? (num * 7 + _name.GetHashCode()) : 0;
		}
	}
}
