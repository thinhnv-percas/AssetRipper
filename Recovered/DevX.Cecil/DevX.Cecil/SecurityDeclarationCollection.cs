using System;
using System.Collections;

namespace DevX.Cecil
{
	public sealed class SecurityDeclarationCollection : IEnumerable, IReflectionVisitable
	{
		private IDictionary m_items;

		private IHasSecurity m_container;

		public SecurityDeclaration this[int index]
		{
			get
			{
				return m_items[index] as SecurityDeclaration;
			}
			set
			{
				m_items[index] = value;
			}
		}

		public SecurityDeclaration this[SecurityAction action]
		{
			get
			{
				return m_items[action] as SecurityDeclaration;
			}
			set
			{
				m_items[action] = value;
			}
		}

		public IHasSecurity Container => m_container;

		public int Count => m_items.Count;

		public bool IsSynchronized => false;

		public object SyncRoot => this;

		public SecurityDeclarationCollection(IHasSecurity container)
		{
			m_container = container;
			m_items = new Hashtable();
		}

		public void Add(SecurityDeclaration value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			SecurityDeclaration securityDeclaration = (SecurityDeclaration)m_items[value.Action];
			if (securityDeclaration != null)
			{
				securityDeclaration.PermissionSet = securityDeclaration.PermissionSet.Union(value.PermissionSet);
				return;
			}
			m_items.Add(value.Action, value);
			SetHasSecurity(value: true);
		}

		public void Clear()
		{
			m_items.Clear();
			SetHasSecurity(value: false);
		}

		public bool Contains(SecurityAction action)
		{
			return m_items[action] != null;
		}

		public bool Contains(SecurityDeclaration value)
		{
			if (value == null)
			{
				return m_items.Count == 0;
			}
			SecurityDeclaration securityDeclaration = (SecurityDeclaration)m_items[value.Action];
			if (securityDeclaration == null)
			{
				return false;
			}
			return value.PermissionSet.IsSubsetOf(securityDeclaration.PermissionSet);
		}

		public void Remove(SecurityAction action)
		{
			m_items.Remove(action);
			SetHasSecurity(Count > 0);
		}

		public void CopyTo(Array ary, int index)
		{
			m_items.Values.CopyTo(ary, index);
		}

		public IEnumerator GetEnumerator()
		{
			return m_items.Values.GetEnumerator();
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitSecurityDeclarationCollection(this);
		}

		private void SetHasSecurity(bool value)
		{
			TypeDefinition typeDefinition = m_container as TypeDefinition;
			if (typeDefinition != null)
			{
				if (value)
				{
					typeDefinition.Attributes |= TypeAttributes.HasSecurity;
				}
				else
				{
					typeDefinition.Attributes &= ~TypeAttributes.HasSecurity;
				}
				return;
			}
			MethodDefinition methodDefinition = m_container as MethodDefinition;
			if (methodDefinition != null)
			{
				if (value)
				{
					methodDefinition.Attributes |= MethodAttributes.HasSecurity;
				}
				else
				{
					methodDefinition.Attributes &= ~MethodAttributes.HasSecurity;
				}
			}
		}
	}
}
