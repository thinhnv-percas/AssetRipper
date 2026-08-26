using DevX.Cecil.Metadata;
using System;
using System.Collections;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace DevX.Cecil
{
	public class AssemblyNameReference : IAnnotationProvider, IMetadataScope, IMetadataTokenProvider, IReflectionStructureVisitable
	{
		private string m_name;

		private string m_culture;

		private Version m_version;

		private AssemblyFlags m_flags;

		private byte[] m_publicKey;

		private byte[] m_publicKeyToken;

		private AssemblyHashAlgorithm m_hashAlgo;

		private byte[] m_hash;

		private MetadataToken m_token;

		private IDictionary m_annotations;

		private bool m_fullNameDiscarded = true;

		private string m_fullName;

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

		public string Name
		{
			get
			{
				return m_name;
			}
			set
			{
				m_name = value;
				m_fullNameDiscarded = true;
			}
		}

		public string Culture
		{
			get
			{
				return m_culture;
			}
			set
			{
				m_culture = value;
				m_fullNameDiscarded = true;
			}
		}

		public Version Version
		{
			get
			{
				return m_version;
			}
			set
			{
				m_version = value;
				m_fullNameDiscarded = true;
			}
		}

		public AssemblyFlags Flags
		{
			get
			{
				return m_flags;
			}
			set
			{
				m_flags = value;
			}
		}

		public bool HasPublicKey
		{
			get
			{
				return (m_flags & AssemblyFlags.PublicKey) != AssemblyFlags.SideBySideCompatible;
			}
			set
			{
				if (value)
				{
					m_flags |= AssemblyFlags.PublicKey;
				}
				else
				{
					m_flags &= ~AssemblyFlags.PublicKey;
				}
			}
		}

		public bool IsSideBySideCompatible
		{
			get
			{
				return false;
			}
			set
			{
				if (value)
				{
					m_flags |= AssemblyFlags.SideBySideCompatible;
				}
				else
				{
					m_flags &= (AssemblyFlags)4294967295u;
				}
			}
		}

		public bool IsRetargetable
		{
			get
			{
				return (m_flags & AssemblyFlags.Retargetable) != AssemblyFlags.SideBySideCompatible;
			}
			set
			{
				if (value)
				{
					m_flags |= AssemblyFlags.Retargetable;
				}
				else
				{
					m_flags &= ~AssemblyFlags.Retargetable;
				}
			}
		}

		public byte[] PublicKey
		{
			get
			{
				return m_publicKey;
			}
			set
			{
				m_publicKey = value;
				m_publicKeyToken = null;
				m_fullNameDiscarded = true;
			}
		}

		public byte[] PublicKeyToken
		{
			get
			{
				if ((m_publicKeyToken == null || m_publicKeyToken.Length == 0) && m_publicKey != null && m_publicKey.Length > 0)
				{
					AssemblyHashAlgorithm hashAlgo = m_hashAlgo;
					HashAlgorithm hashAlgorithm = (hashAlgo != AssemblyHashAlgorithm.Reserved) ? ((HashAlgorithm)SHA1.Create()) : ((HashAlgorithm)MD5.Create());
					byte[] array = hashAlgorithm.ComputeHash(m_publicKey);
					m_publicKeyToken = new byte[8];
					Array.Copy(array, array.Length - 8, m_publicKeyToken, 0, 8);
					Array.Reverse(m_publicKeyToken, 0, 8);
				}
				return m_publicKeyToken;
			}
			set
			{
				m_publicKeyToken = value;
				m_fullNameDiscarded = true;
			}
		}

		public string FullName
		{
			get
			{
				if (m_fullName != null && !m_fullNameDiscarded)
				{
					return m_fullName;
				}
				StringBuilder stringBuilder = new StringBuilder();
				string value = ", ";
				stringBuilder.Append(m_name);
				if (m_version != null)
				{
					stringBuilder.Append(value);
					stringBuilder.Append("Version=");
					stringBuilder.Append(m_version.ToString());
				}
				stringBuilder.Append(value);
				stringBuilder.Append("Culture=");
				stringBuilder.Append((m_culture != null && m_culture.Length != 0) ? m_culture : "neutral");
				stringBuilder.Append(value);
				stringBuilder.Append("PublicKeyToken=");
				if (PublicKeyToken != null && m_publicKeyToken.Length > 0)
				{
					for (int i = 0; i < m_publicKeyToken.Length; i++)
					{
						stringBuilder.Append(m_publicKeyToken[i].ToString("x2"));
					}
				}
				else
				{
					stringBuilder.Append("null");
				}
				m_fullName = stringBuilder.ToString();
				m_fullNameDiscarded = false;
				return m_fullName;
			}
		}

		public AssemblyHashAlgorithm HashAlgorithm
		{
			get
			{
				return m_hashAlgo;
			}
			set
			{
				m_hashAlgo = value;
			}
		}

		public virtual byte[] Hash
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

		public MetadataToken MetadataToken
		{
			get
			{
				return m_token;
			}
			set
			{
				m_token = value;
			}
		}

		public AssemblyNameReference()
			: this(string.Empty, string.Empty, new Version(0, 0, 0, 0))
		{
		}

		public AssemblyNameReference(string name, string culture, Version version)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (culture == null)
			{
				throw new ArgumentNullException("culture");
			}
			m_name = name;
			m_culture = culture;
			m_version = version;
			m_hashAlgo = AssemblyHashAlgorithm.None;
		}

		public static AssemblyNameReference Parse(string fullName)
		{
			if (fullName == null)
			{
				throw new ArgumentNullException("fullName");
			}
			if (fullName.Length == 0)
			{
				throw new ArgumentException("Name can not be empty");
			}
			AssemblyNameReference assemblyNameReference = new AssemblyNameReference();
			string[] array = fullName.Split(',');
			for (int i = 0; i < array.Length; i++)
			{
				string text = array[i].Trim();
				if (i == 0)
				{
					assemblyNameReference.Name = text;
					continue;
				}
				string[] array2 = text.Split('=');
				if (array2.Length != 2)
				{
					throw new ArgumentException("Malformed name");
				}
				switch (array2[0])
				{
				case "Version":
					assemblyNameReference.Version = new Version(array2[1]);
					break;
				case "Culture":
					assemblyNameReference.Culture = array2[1];
					break;
				case "PublicKeyToken":
				{
					string text2 = array2[1];
					if (!(text2 == "null"))
					{
						assemblyNameReference.PublicKeyToken = new byte[text2.Length / 2];
						for (int j = 0; j < assemblyNameReference.PublicKeyToken.Length; j++)
						{
							assemblyNameReference.PublicKeyToken[j] = byte.Parse(text2.Substring(j * 2, 2), NumberStyles.HexNumber);
						}
					}
					break;
				}
				}
			}
			return assemblyNameReference;
		}

		public override string ToString()
		{
			return FullName;
		}

		public virtual void Accept(IReflectionStructureVisitor visitor)
		{
			visitor.VisitAssemblyNameReference(this);
		}
	}
}
