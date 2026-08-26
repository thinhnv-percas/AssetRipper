using System;

namespace Unreal
{
	public class UPropAttr : Attribute
	{
		public string Name;

		public UPropAttr()
		{
		}

		public UPropAttr(string name)
		{
			Name = name;
		}
	}
}
