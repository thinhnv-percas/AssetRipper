using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;
using Mono.Xml;
using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Text;

namespace DevX.Cecil
{
	internal sealed class SecurityDeclarationReader
	{
		private SecurityParser m_parser;

		private SignatureReader sr;

		public SecurityParser Parser
		{
			get
			{
				if (m_parser == null)
				{
					m_parser = new SecurityParser();
				}
				return m_parser;
			}
		}

		public SecurityDeclarationReader(MetadataRoot root, ReflectionReader reader)
		{
			sr = new SignatureReader(root, reader);
		}

		public SecurityDeclaration FromByteArray(SecurityAction action, byte[] declaration)
		{
			return FromByteArray(action, declaration, resolve: false);
		}

		private static bool IsEmptyDeclaration(byte[] declaration)
		{
			return declaration == null || declaration.Length == 0 || (declaration.Length == 1 && declaration[0] == 0);
		}

		public SecurityDeclaration FromByteArray(SecurityAction action, byte[] declaration, bool resolve)
		{
			SecurityDeclaration securityDeclaration = new SecurityDeclaration(action, this);
			securityDeclaration.PermissionSet = new PermissionSet(PermissionState.None);
			if (IsEmptyDeclaration(declaration))
			{
				return securityDeclaration;
			}
			if (declaration[0] == 46)
			{
				int pos = 1;
				int start;
				int num = Utilities.ReadCompressedInteger(declaration, pos, out start);
				if (num == 0)
				{
					return securityDeclaration;
				}
				BinaryReader br = new BinaryReader(new MemoryStream(declaration));
				for (int i = 0; i < num; i++)
				{
					pos = start;
					SecurityAttribute securityAttribute = CreateSecurityAttribute(action, br, declaration, pos, out start, resolve);
					if (securityAttribute == null)
					{
						securityDeclaration.Resolved = false;
						securityDeclaration.Blob = declaration;
						return securityDeclaration;
					}
					try
					{
						IPermission perm = securityAttribute.CreatePermission();
						securityDeclaration.PermissionSet.AddPermission(perm);
					}
					catch
					{
						securityDeclaration.Resolved = false;
						securityDeclaration.Blob = declaration;
						return securityDeclaration;
						IL_00b0:;
					}
				}
				securityDeclaration.Resolved = true;
				return securityDeclaration;
			}
			Parser.LoadXml(Encoding.Unicode.GetString(declaration));
			try
			{
				securityDeclaration.PermissionSet.FromXml(Parser.ToXml());
				securityDeclaration.PermissionSet.ToXml();
				securityDeclaration.Resolved = true;
				return securityDeclaration;
			}
			catch
			{
				securityDeclaration.Resolved = false;
				securityDeclaration.Blob = declaration;
				return securityDeclaration;
			}
		}

		private SecurityAttribute CreateSecurityAttribute(SecurityAction action, BinaryReader br, byte[] permset, int pos, out int start, bool resolve)
		{
			string typeName = SignatureReader.ReadUTF8String(permset, pos, out start);
			Type type = null;
			SecurityAttribute securityAttribute = null;
			try
			{
				type = Type.GetType(typeName, throwOnError: false);
				if (type == null)
				{
					return null;
				}
				securityAttribute = (Activator.CreateInstance(type, (System.Security.Permissions.SecurityAction)action) as SecurityAttribute);
			}
			catch
			{
			}
			if (securityAttribute == null)
			{
				return null;
			}
			Utilities.ReadCompressedInteger(permset, start, out pos);
			int num = Utilities.ReadCompressedInteger(permset, pos, out start);
			if (num == 0)
			{
				return securityAttribute;
			}
			br.BaseStream.Position = start;
			for (int i = 0; i < num; i++)
			{
				bool read = true;
				CustomAttrib.NamedArg namedArg = sr.ReadNamedArg(permset, br, ref read, resolve);
				if (!read)
				{
					return null;
				}
				if (namedArg.Field)
				{
					FieldInfo field = type.GetField(namedArg.FieldOrPropName);
					field.SetValue(securityAttribute, namedArg.FixedArg.Elems[0].Value);
				}
				else if (namedArg.Property)
				{
					PropertyInfo property = type.GetProperty(namedArg.FieldOrPropName);
					property.SetValue(securityAttribute, namedArg.FixedArg.Elems[0].Value, null);
				}
			}
			start = (int)br.BaseStream.Position;
			return securityAttribute;
		}
	}
}
