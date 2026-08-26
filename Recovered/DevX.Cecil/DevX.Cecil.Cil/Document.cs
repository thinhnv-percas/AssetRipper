using System;

namespace DevX.Cecil.Cil
{
	public class Document
	{
		private string m_url;

		private Guid m_type;

		private DocumentHashAlgorithm m_hashAlgorithm;

		private Guid m_language;

		private Guid m_languageVendor;

		private byte[] m_hash;

		public string Url
		{
			get
			{
				return m_url;
			}
			set
			{
				m_url = value;
			}
		}

		public Guid Type
		{
			get
			{
				return m_type;
			}
			set
			{
				m_type = value;
			}
		}

		public DocumentHashAlgorithm HashAlgorithm
		{
			get
			{
				return m_hashAlgorithm;
			}
			set
			{
				m_hashAlgorithm = value;
			}
		}

		public Guid Language
		{
			get
			{
				return m_language;
			}
			set
			{
				m_language = value;
			}
		}

		public Guid LanguageVendor
		{
			get
			{
				return m_languageVendor;
			}
			set
			{
				m_languageVendor = value;
			}
		}

		public byte[] Hash
		{
			get
			{
				return m_hash;
			}
			set
			{
				m_hash = value;
			}
		}

		public Document(string url)
		{
			m_url = url;
			m_hash = new byte[0];
		}
	}
}
