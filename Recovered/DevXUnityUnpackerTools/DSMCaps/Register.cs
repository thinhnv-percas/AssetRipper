using System;

namespace DSMCaps
{
	public abstract class Register<TId> where TId : Enum
	{
		internal readonly string _name;

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

		internal protected Register(TId id, string name)
		{
			Id = id;
			_name = name;
		}

		public override bool Equals(object @object)
		{
			bool flag = @object != null;
			if (flag)
			{
				Register<TId> register = @object as Register<TId>;
				flag = (register != null);
				if (flag)
				{
					flag = (Id.Equals(register.Id) && _name == register._name);
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
