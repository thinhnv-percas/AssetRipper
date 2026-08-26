using DevX.Cecil.Metadata;
using System.Collections;

namespace DevX.Cecil
{
	internal sealed class TableComparers
	{
		public sealed class TypeDef : IComparer
		{
			public static readonly TypeDef Instance = new TypeDef();

			public int Compare(object x, object y)
			{
				TypeDefinition typeDefinition = x as TypeDefinition;
				TypeDefinition typeDefinition2 = y as TypeDefinition;
				if (typeDefinition == null || typeDefinition2 == null)
				{
					throw new ReflectionException("TypeDefComparer can only compare TypeDefinition");
				}
				if (typeDefinition.Name == "<Module>" && typeDefinition2.Name == "<Module>")
				{
					return 0;
				}
				if (typeDefinition.Name == "<Module>")
				{
					return -1;
				}
				if (typeDefinition2.Name == "<Module>")
				{
					return 1;
				}
				return Comparer.Default.Compare(typeDefinition.FullName, typeDefinition2.FullName);
			}
		}

		public sealed class TypeRef : IComparer
		{
			public static readonly TypeRef Instance = new TypeRef();

			public int Compare(object x, object y)
			{
				TypeReference typeReference = x as TypeReference;
				TypeReference typeReference2 = y as TypeReference;
				if (typeReference == null || typeReference2 == null)
				{
					throw new ReflectionException("TypeRefComparer can only compare TypeReference");
				}
				if (typeReference2.DeclaringType == typeReference)
				{
					return -1;
				}
				if (typeReference.DeclaringType == typeReference2)
				{
					return 1;
				}
				return Comparer.Default.Compare(typeReference.FullName, typeReference2.FullName);
			}
		}

		public sealed class NestedClass : IComparer
		{
			public static readonly NestedClass Instance = new NestedClass();

			public int Compare(object x, object y)
			{
				NestedClassRow nestedClassRow = x as NestedClassRow;
				NestedClassRow nestedClassRow2 = y as NestedClassRow;
				return Comparer.Default.Compare(nestedClassRow.NestedClass, nestedClassRow2.NestedClass);
			}
		}

		public sealed class Constant : IComparer
		{
			public static readonly Constant Instance = new Constant();

			public int Compare(object x, object y)
			{
				ConstantRow constantRow = x as ConstantRow;
				ConstantRow constantRow2 = y as ConstantRow;
				return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.HasConstant, constantRow.Parent), Utilities.CompressMetadataToken(CodedIndex.HasConstant, constantRow2.Parent));
			}
		}

		public sealed class InterfaceImpl : IComparer
		{
			public static readonly InterfaceImpl Instance = new InterfaceImpl();

			public int Compare(object x, object y)
			{
				InterfaceImplRow interfaceImplRow = x as InterfaceImplRow;
				InterfaceImplRow interfaceImplRow2 = y as InterfaceImplRow;
				int num = Comparer.Default.Compare(interfaceImplRow.Class, interfaceImplRow2.Class);
				if (num == 0)
				{
					return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, interfaceImplRow.Interface), Utilities.CompressMetadataToken(CodedIndex.TypeDefOrRef, interfaceImplRow2.Interface));
				}
				return num;
			}
		}

		public sealed class MethodSem : IComparer
		{
			public static readonly MethodSem Instance = new MethodSem();

			public int Compare(object x, object y)
			{
				MethodSemanticsRow methodSemanticsRow = x as MethodSemanticsRow;
				MethodSemanticsRow methodSemanticsRow2 = y as MethodSemanticsRow;
				return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.HasSemantics, methodSemanticsRow.Association), Utilities.CompressMetadataToken(CodedIndex.HasSemantics, methodSemanticsRow2.Association));
			}
		}

		public sealed class CustomAttribute : IComparer
		{
			public static readonly CustomAttribute Instance = new CustomAttribute();

			public int Compare(object x, object y)
			{
				CustomAttributeRow customAttributeRow = x as CustomAttributeRow;
				CustomAttributeRow customAttributeRow2 = y as CustomAttributeRow;
				return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.HasCustomAttribute, customAttributeRow.Parent), Utilities.CompressMetadataToken(CodedIndex.HasCustomAttribute, customAttributeRow2.Parent));
			}
		}

		public sealed class SecurityDeclaration : IComparer
		{
			public static readonly SecurityDeclaration Instance = new SecurityDeclaration();

			public int Compare(object x, object y)
			{
				DeclSecurityRow declSecurityRow = x as DeclSecurityRow;
				DeclSecurityRow declSecurityRow2 = y as DeclSecurityRow;
				return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.HasDeclSecurity, declSecurityRow.Parent), Utilities.CompressMetadataToken(CodedIndex.HasDeclSecurity, declSecurityRow2.Parent));
			}
		}

		public sealed class Override : IComparer
		{
			public static readonly Override Instance = new Override();

			public int Compare(object x, object y)
			{
				MethodImplRow methodImplRow = x as MethodImplRow;
				MethodImplRow methodImplRow2 = y as MethodImplRow;
				return Comparer.Default.Compare(methodImplRow.Class, methodImplRow2.Class);
			}
		}

		public sealed class PInvoke : IComparer
		{
			public static readonly PInvoke Instance = new PInvoke();

			public int Compare(object x, object y)
			{
				ImplMapRow implMapRow = x as ImplMapRow;
				ImplMapRow implMapRow2 = y as ImplMapRow;
				return Comparer.Default.Compare(implMapRow.MemberForwarded.RID, implMapRow2.MemberForwarded.RID);
			}
		}

		public sealed class FieldRVA : IComparer
		{
			public static readonly FieldRVA Instance = new FieldRVA();

			public int Compare(object x, object y)
			{
				FieldRVARow fieldRVARow = x as FieldRVARow;
				FieldRVARow fieldRVARow2 = y as FieldRVARow;
				return Comparer.Default.Compare(fieldRVARow.Field, fieldRVARow2.Field);
			}
		}

		public sealed class FieldLayout : IComparer
		{
			public static readonly FieldLayout Instance = new FieldLayout();

			public int Compare(object x, object y)
			{
				FieldLayoutRow fieldLayoutRow = x as FieldLayoutRow;
				FieldLayoutRow fieldLayoutRow2 = y as FieldLayoutRow;
				return Comparer.Default.Compare(fieldLayoutRow.Field, fieldLayoutRow2.Field);
			}
		}

		public sealed class FieldMarshal : IComparer
		{
			public static readonly FieldMarshal Instance = new FieldMarshal();

			public int Compare(object x, object y)
			{
				FieldMarshalRow fieldMarshalRow = x as FieldMarshalRow;
				FieldMarshalRow fieldMarshalRow2 = y as FieldMarshalRow;
				return Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.HasFieldMarshal, fieldMarshalRow.Parent), Utilities.CompressMetadataToken(CodedIndex.HasFieldMarshal, fieldMarshalRow2.Parent));
			}
		}

		public sealed class TypeLayout : IComparer
		{
			public static readonly TypeLayout Instance = new TypeLayout();

			public int Compare(object x, object y)
			{
				ClassLayoutRow classLayoutRow = x as ClassLayoutRow;
				ClassLayoutRow classLayoutRow2 = y as ClassLayoutRow;
				return Comparer.Default.Compare(classLayoutRow.Parent, classLayoutRow2.Parent);
			}
		}

		public sealed class GenericParam : IComparer
		{
			public static readonly GenericParam Instance = new GenericParam();

			public int Compare(object x, object y)
			{
				GenericParameter genericParameter = x as GenericParameter;
				GenericParameter genericParameter2 = y as GenericParameter;
				int num = Comparer.Default.Compare(Utilities.CompressMetadataToken(CodedIndex.TypeOrMethodDef, genericParameter.Owner.MetadataToken), Utilities.CompressMetadataToken(CodedIndex.TypeOrMethodDef, genericParameter2.Owner.MetadataToken));
				if (num == 0)
				{
					return Comparer.Default.Compare(genericParameter.Position, genericParameter2.Position);
				}
				return num;
			}
		}
	}
}
