using System.Collections;
using System.Security;

namespace DevX.Cecil
{
	public sealed class SecurityDeclaration : IAnnotationProvider, IReflectionVisitable, IRequireResolving
	{
		private SecurityAction m_action;

		private SecurityDeclarationReader m_reader;

		private IDictionary m_annotations;

		private PermissionSet m_permSet;

		private bool m_resolved;

		private byte[] m_blob;

		IDictionary IAnnotationProvider.Annotations
		{
			get
			{
				if (m_annotations == null)
				{
					m_annotations = new Hashtable();
				}
				return m_annotations;
			}
		}

		public SecurityAction Action
		{
			get
			{
				return m_action;
			}
			set
			{
				m_action = value;
			}
		}

		public PermissionSet PermissionSet
		{
			get
			{
				return m_permSet;
			}
			set
			{
				m_permSet = value;
			}
		}

		public bool Resolved
		{
			get
			{
				return m_resolved;
			}
			set
			{
				m_resolved = value;
			}
		}

		public byte[] Blob
		{
			get
			{
				return m_blob;
			}
			set
			{
				m_blob = value;
			}
		}

		public SecurityDeclaration(SecurityAction action)
		{
			m_action = action;
		}

		internal SecurityDeclaration(SecurityAction action, SecurityDeclarationReader reader)
		{
			m_action = action;
			m_reader = reader;
		}

		public SecurityDeclaration Clone()
		{
			return Clone(this);
		}

		internal static SecurityDeclaration Clone(SecurityDeclaration sec)
		{
			SecurityDeclaration securityDeclaration = new SecurityDeclaration(sec.Action);
			if (!sec.Resolved)
			{
				securityDeclaration.Resolved = false;
				securityDeclaration.Blob = sec.Blob;
				return securityDeclaration;
			}
			securityDeclaration.PermissionSet = sec.PermissionSet.Copy();
			return securityDeclaration;
		}

		public bool Resolve()
		{
			if (m_resolved)
			{
				return true;
			}
			if (m_reader == null)
			{
				return false;
			}
			SecurityDeclaration securityDeclaration = m_reader.FromByteArray(m_action, m_blob, resolve: true);
			if (!securityDeclaration.Resolved)
			{
				return false;
			}
			m_action = securityDeclaration.Action;
			m_permSet = securityDeclaration.PermissionSet.Copy();
			m_resolved = true;
			return true;
		}

		public void Accept(IReflectionVisitor visitor)
		{
			visitor.VisitSecurityDeclaration(this);
		}
	}
}
