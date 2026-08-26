using System;
using System.Reflection;

namespace DevX.Cecil.Cil
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class GuidAttribute : Attribute
	{
		private Guid m_guid;

		public Guid Guid => m_guid;

		private GuidAttribute()
		{
			m_guid = default(Guid);
		}

		public GuidAttribute(uint a, ushort b, ushort c, byte d, byte e, byte f, byte g, byte h, byte i, byte j, byte k)
		{
			m_guid = new Guid((int)a, (short)b, (short)c, d, e, f, g, h, i, j, k);
		}

		public static int GetValueFromGuid(Guid id, Type enumeration)
		{
			FieldInfo[] fields = enumeration.GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (id == GetGuidAttribute(fieldInfo).Guid)
				{
					return (int)fieldInfo.GetValue(null);
				}
			}
			return -1;
		}

		public static Guid GetGuidFromValue(int value, Type enumeration)
		{
			FieldInfo[] fields = enumeration.GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (value == (int)fieldInfo.GetValue(null))
				{
					return GetGuidAttribute(fieldInfo).Guid;
				}
			}
			return default(Guid);
		}

		private static GuidAttribute GetGuidAttribute(FieldInfo fi)
		{
			GuidAttribute[] array = fi.GetCustomAttributes(typeof(GuidAttribute), inherit: false) as GuidAttribute[];
			if (array == null || array.Length != 1)
			{
				return new GuidAttribute();
			}
			return array[0];
		}
	}
}
