using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class UnresolvedAttributeBlob : IUnresolvedAttribute, ISupportsInterning
{
	internal readonly ITypeReference attributeType;

	internal readonly IList<ITypeReference> ctorParameterTypes;

	internal readonly byte[] blob;

	DomRegion IUnresolvedAttribute.Region => DomRegion.Empty;

	public UnresolvedAttributeBlob(ITypeReference attributeType, IList<ITypeReference> ctorParameterTypes, byte[] blob)
	{
		if (attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		if (ctorParameterTypes == null)
		{
			throw new ArgumentNullException("ctorParameterTypes");
		}
		if (blob == null)
		{
			throw new ArgumentNullException("blob");
		}
		this.attributeType = attributeType;
		this.ctorParameterTypes = ctorParameterTypes;
		this.blob = blob;
	}

	public IAttribute CreateResolvedAttribute(ITypeResolveContext context)
	{
		if (context.CurrentAssembly == null)
		{
			throw new InvalidOperationException("Cannot resolve CecilUnresolvedAttribute without a parent assembly");
		}
		return new CecilResolvedAttribute(context, this);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return attributeType.GetHashCode() ^ ctorParameterTypes.GetHashCode() ^ BlobReader.GetBlobHashCode(blob);
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is UnresolvedAttributeBlob unresolvedAttributeBlob && attributeType == unresolvedAttributeBlob.attributeType && ctorParameterTypes == unresolvedAttributeBlob.ctorParameterTypes)
		{
			return BlobReader.BlobEquals(blob, unresolvedAttributeBlob.blob);
		}
		return false;
	}
}
