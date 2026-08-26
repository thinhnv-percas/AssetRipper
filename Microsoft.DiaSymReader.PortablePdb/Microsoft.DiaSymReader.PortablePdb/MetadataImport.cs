using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.DiaSymReader.PortablePdb;

internal abstract class MetadataImport
{
	private sealed class Legacy : MetadataImport
	{
		private readonly IMetadataImport _import;

		public Legacy(IMetadataImport import)
		{
			_import = import;
		}

		public override void GetTypeDefProps(int typeDefinition, out string qualifiedName)
		{
			_import.GetTypeDefProps(typeDefinition, null, 0, out var qualifiedNameLength, out var attributes, out var baseType);
			StringBuilder stringBuilder = new StringBuilder(qualifiedNameLength + 1);
			_import.GetTypeDefProps(typeDefinition, stringBuilder, stringBuilder.Capacity, out qualifiedNameLength, out attributes, out baseType);
			qualifiedName = stringBuilder.ToString();
		}

		public override void GetTypeRefProps(int typeReference, out string qualifiedName)
		{
			_import.GetTypeRefProps(typeReference, out var resolutionScope, null, 0, out var qualifiedNameLength);
			StringBuilder stringBuilder = new StringBuilder(qualifiedNameLength + 1);
			_import.GetTypeRefProps(typeReference, out resolutionScope, stringBuilder, stringBuilder.Capacity, out qualifiedNameLength);
			qualifiedName = stringBuilder.ToString();
		}

		public unsafe override int GetSigFromToken(int token, out byte* signaturePtr, out int signatureLength)
		{
			return _import.GetSigFromToken(token, out signaturePtr, out signatureLength);
		}
	}

	private sealed class Internal : MetadataImport
	{
		private readonly Microsoft.DiaSymReader.IMetadataImport _import;

		public Internal(Microsoft.DiaSymReader.IMetadataImport import)
		{
			_import = import;
		}

		public unsafe override void GetTypeDefProps(int typeDefinition, out string qualifiedName)
		{
			int num = default(int);
			TypeAttributes typeAttributes = default(TypeAttributes);
			int num2 = default(int);
			Marshal.ThrowExceptionForHR(_import.GetTypeDefProps(typeDefinition, null, 0, &num, &typeAttributes, &num2));
			if (num > 0)
			{
				string text = new string('\0', num);
				fixed (char* qualifiedName2 = text)
				{
					Marshal.ThrowExceptionForHR(_import.GetTypeDefProps(typeDefinition, qualifiedName2, text.Length + 1, null, null, null));
				}
				qualifiedName = text;
			}
			else
			{
				qualifiedName = "";
			}
		}

		public unsafe override void GetTypeRefProps(int typeReference, out string qualifiedName)
		{
			int num = default(int);
			int num2 = default(int);
			Marshal.ThrowExceptionForHR(_import.GetTypeRefProps(typeReference, &num, null, 0, &num2));
			if (num2 > 0)
			{
				string text = new string('\0', num2);
				fixed (char* qualifiedName2 = text)
				{
					Marshal.ThrowExceptionForHR(_import.GetTypeRefProps(typeReference, null, qualifiedName2, text.Length + 1, null));
				}
				qualifiedName = text;
			}
			else
			{
				qualifiedName = "";
			}
		}

		public unsafe override int GetSigFromToken(int token, out byte* signaturePtr, out int signatureLength)
		{
			byte* ptr = default(byte*);
			int num = default(int);
			int sigFromToken = _import.GetSigFromToken(token, &ptr, &num);
			signaturePtr = ptr;
			signatureLength = num;
			return sigFromToken;
		}
	}

	public static MetadataImport FromObject(object obj)
	{
		if (!(obj is IMetadataImport import))
		{
			if (!(obj is Microsoft.DiaSymReader.IMetadataImport import2))
			{
				return null;
			}
			return new Internal(import2);
		}
		return new Legacy(import);
	}

	public string GetQualifiedTypeName(Handle typeDefOrRef)
	{
		string qualifiedName;
		if (typeDefOrRef.Kind == HandleKind.TypeDefinition)
		{
			GetTypeDefProps(MetadataTokens.GetToken(typeDefOrRef), out qualifiedName);
		}
		else
		{
			if (typeDefOrRef.Kind != HandleKind.TypeReference)
			{
				return null;
			}
			GetTypeRefProps(MetadataTokens.GetToken(typeDefOrRef), out qualifiedName);
		}
		return qualifiedName;
	}

	public abstract void GetTypeDefProps(int typeDefinition, out string qualifiedName);

	public abstract void GetTypeRefProps(int typeReference, out string qualifiedName);

	public unsafe abstract int GetSigFromToken(int token, out byte* signaturePtr, out int signatureLength);
}
