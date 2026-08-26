using ICSharpCode.NRefactory.Semantics;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class UnresolvedSecurityDeclarationBlob
	{
		private static readonly ITypeReference securityActionTypeReference = ReflectionHelper.ToTypeReference(typeof(SecurityAction));

		private static readonly ITypeReference permissionSetAttributeTypeReference = ReflectionHelper.ToTypeReference(typeof(PermissionSetAttribute));

		private readonly IConstantValue securityAction;

		private readonly byte[] blob;

		private readonly IList<IUnresolvedAttribute> unresolvedAttributes = new List<IUnresolvedAttribute>();

		public IList<IUnresolvedAttribute> UnresolvedAttributes => unresolvedAttributes;

		public UnresolvedSecurityDeclarationBlob(int securityAction, byte[] blob)
		{
			BlobReader blobReader = new BlobReader(blob, null);
			this.securityAction = new SimpleConstantValue(securityActionTypeReference, securityAction);
			this.blob = blob;
			if (blobReader.ReadByte() == 46)
			{
				uint num = blobReader.ReadCompressedUInt32();
				for (uint num2 = 0u; num2 < num; num2++)
				{
					unresolvedAttributes.Add(new UnresolvedSecurityAttribute(this, (int)num2));
				}
			}
			else
			{
				DefaultUnresolvedAttribute defaultUnresolvedAttribute = new DefaultUnresolvedAttribute(permissionSetAttributeTypeReference);
				defaultUnresolvedAttribute.ConstructorParameterTypes.Add(securityActionTypeReference);
				defaultUnresolvedAttribute.PositionalArguments.Add(this.securityAction);
				string @string = Encoding.Unicode.GetString(blob);
				defaultUnresolvedAttribute.AddNamedPropertyArgument("XML", new SimpleConstantValue(KnownTypeReference.String, @string));
				unresolvedAttributes.Add(defaultUnresolvedAttribute);
			}
		}

		public IList<IAttribute> Resolve(IAssembly currentAssembly)
		{
			ITypeResolveContext context = new SimpleTypeResolveContext(currentAssembly);
			BlobReader blobReader = new BlobReader(blob, currentAssembly);
			if (blobReader.ReadByte() != 46)
			{
				throw new InvalidOperationException();
			}
			ResolveResult securityActionRR = securityAction.Resolve(context);
			IAttribute[] array = new IAttribute[blobReader.ReadCompressedUInt32()];
			try
			{
				ReadSecurityBlob(blobReader, array, context, securityActionRR);
			}
			catch (NotSupportedException)
			{
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					array[i] = new CecilResolvedAttribute(context, SpecialType.UnknownType);
				}
			}
			return array;
		}

		private void ReadSecurityBlob(BlobReader reader, IAttribute[] attributes, ITypeResolveContext context, ResolveResult securityActionRR)
		{
			for (int i = 0; i < attributes.Length; i++)
			{
				IType attributeType = ReflectionHelper.ParseReflectionName(reader.ReadSerString()).Resolve(context);
				reader.ReadCompressedUInt32();
				uint num = reader.ReadCompressedUInt32();
				List<KeyValuePair<IMember, ResolveResult>> list = new List<KeyValuePair<IMember, ResolveResult>>((int)num);
				for (uint num2 = 0u; num2 < num; num2++)
				{
					KeyValuePair<IMember, ResolveResult> item = reader.ReadNamedArg(attributeType);
					if (item.Key != null)
					{
						list.Add(item);
					}
				}
				attributes[i] = new DefaultAttribute(attributeType, new ResolveResult[1]
				{
					securityActionRR
				}, list);
			}
		}
	}
}
