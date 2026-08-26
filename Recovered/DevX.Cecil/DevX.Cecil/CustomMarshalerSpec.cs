using System;

namespace DevX.Cecil
{
	public sealed class CustomMarshalerSpec : MarshalSpec
	{
		private Guid m_guid;

		private string m_unmanagedType;

		private string m_managedType;

		private string m_cookie;

		public Guid Guid
		{
			get
			{
				return m_guid;
			}
			set
			{
				m_guid = value;
			}
		}

		public string UnmanagedType
		{
			get
			{
				return m_unmanagedType;
			}
			set
			{
				m_unmanagedType = value;
			}
		}

		public string ManagedType
		{
			get
			{
				return m_managedType;
			}
			set
			{
				m_managedType = value;
			}
		}

		public string Cookie
		{
			get
			{
				return m_cookie;
			}
			set
			{
				m_cookie = value;
			}
		}

		public CustomMarshalerSpec(IHasMarshalSpec container)
			: base(NativeType.CUSTOMMARSHALER, container)
		{
		}

		public override MarshalSpec CloneInto(IHasMarshalSpec container)
		{
			CustomMarshalerSpec customMarshalerSpec = new CustomMarshalerSpec(container);
			customMarshalerSpec.m_guid = m_guid;
			customMarshalerSpec.m_unmanagedType = m_unmanagedType;
			customMarshalerSpec.m_managedType = m_managedType;
			customMarshalerSpec.m_cookie = m_cookie;
			return customMarshalerSpec;
		}
	}
}
