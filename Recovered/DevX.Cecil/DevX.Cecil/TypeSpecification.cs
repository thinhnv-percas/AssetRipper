using System;

namespace DevX.Cecil
{
	public abstract class TypeSpecification : TypeReference
	{
		private TypeReference m_elementType;

		public override string Name
		{
			get
			{
				return m_elementType.Name;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override string Namespace
		{
			get
			{
				return m_elementType.Namespace;
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public override bool IsValueType
		{
			get
			{
				return m_elementType.IsValueType;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public override IMetadataScope Scope => m_elementType.Scope;

		public override ModuleDefinition Module
		{
			get
			{
				return m_elementType.Module;
			}
			set
			{
				throw new InvalidOperationException();
			}
		}

		public TypeReference ElementType
		{
			get
			{
				return m_elementType;
			}
			set
			{
				m_elementType = value;
			}
		}

		public override string FullName => m_elementType.FullName;

		internal TypeSpecification(TypeReference elementType)
			: base(string.Empty, string.Empty)
		{
			m_elementType = elementType;
		}

		public override TypeReference GetOriginalType()
		{
			return m_elementType.GetOriginalType();
		}
	}
}
