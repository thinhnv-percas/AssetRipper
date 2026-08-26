using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[Serializable]
	public sealed class ParameterizedTypeReference : ITypeReference, ISupportsInterning
	{
		private readonly ITypeReference genericType;

		private readonly ITypeReference[] typeArguments;

		public ITypeReference GenericType => genericType;

		public ReadOnlyCollection<ITypeReference> TypeArguments => Array.AsReadOnly(typeArguments);

		public ParameterizedTypeReference(ITypeReference genericType, IEnumerable<ITypeReference> typeArguments)
		{
			if (genericType == null)
			{
				throw new ArgumentNullException("genericType");
			}
			if (typeArguments == null)
			{
				throw new ArgumentNullException("typeArguments");
			}
			this.genericType = genericType;
			this.typeArguments = typeArguments.ToArray();
			int num = 0;
			while (true)
			{
				if (num < this.typeArguments.Length)
				{
					if (this.typeArguments[num] == null)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			throw new ArgumentNullException("typeArguments[" + num + "]");
		}

		public IType Resolve(ITypeResolveContext context)
		{
			IType type = genericType.Resolve(context);
			ITypeDefinition definition = type.GetDefinition();
			if (definition == null)
			{
				return type;
			}
			int typeParameterCount = definition.TypeParameterCount;
			if (typeParameterCount == 0)
			{
				return definition;
			}
			IType[] array = new IType[typeParameterCount];
			for (int i = 0; i < array.Length; i++)
			{
				if (i < typeArguments.Length)
				{
					array[i] = typeArguments[i].Resolve(context);
				}
				else
				{
					array[i] = SpecialType.UnknownType;
				}
			}
			return new ParameterizedType(definition, array);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(genericType.ToString());
			stringBuilder.Append('[');
			for (int i = 0; i < typeArguments.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append('[');
				stringBuilder.Append(typeArguments[i].ToString());
				stringBuilder.Append(']');
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			int num = genericType.GetHashCode();
			ITypeReference[] array = typeArguments;
			foreach (ITypeReference typeReference in array)
			{
				num *= 27;
				num += typeReference.GetHashCode();
			}
			return num;
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			ParameterizedTypeReference parameterizedTypeReference = other as ParameterizedTypeReference;
			if (parameterizedTypeReference != null && genericType == parameterizedTypeReference.genericType && typeArguments.Length == parameterizedTypeReference.typeArguments.Length)
			{
				for (int i = 0; i < typeArguments.Length; i++)
				{
					if (typeArguments[i] != parameterizedTypeReference.typeArguments[i])
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
	}
}
