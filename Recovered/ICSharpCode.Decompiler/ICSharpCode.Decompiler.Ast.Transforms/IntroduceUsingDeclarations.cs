using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	public class IntroduceUsingDeclarations : IAstTransform
	{
		private sealed class FindRequiredImports : DepthFirstAstVisitor<object, object>
		{
			private readonly IntroduceUsingDeclarations transform;

			private string currentNamespace;

			public FindRequiredImports(IntroduceUsingDeclarations transform)
			{
				this.transform = transform;
				currentNamespace = ((transform.context.CurrentType != null) ? transform.context.CurrentType.Namespace : string.Empty);
			}

			private bool IsParentOfCurrentNamespace(string ns)
			{
				if (ns.Length == 0)
				{
					return true;
				}
				if (currentNamespace.StartsWith(ns, StringComparison.Ordinal))
				{
					if (currentNamespace.Length == ns.Length)
					{
						return true;
					}
					if (currentNamespace[ns.Length] == '.')
					{
						return true;
					}
				}
				return false;
			}

			public override object VisitSimpleType(SimpleType simpleType, object data)
			{
				TypeReference typeReference = simpleType.Annotation<TypeReference>();
				if (typeReference != null && !IsParentOfCurrentNamespace(typeReference.Namespace))
				{
					transform.importedNamespaces.Add(typeReference.Namespace);
				}
				return base.VisitSimpleType(simpleType, data);
			}

			public override object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data)
			{
				string text = currentNamespace;
				foreach (string identifier in namespaceDeclaration.Identifiers)
				{
					currentNamespace = NamespaceDeclaration.BuildQualifiedName(currentNamespace, identifier);
					transform.declaredNamespaces.Add(currentNamespace);
				}
				base.VisitNamespaceDeclaration(namespaceDeclaration, data);
				currentNamespace = text;
				return null;
			}
		}

		private sealed class FullyQualifyAmbiguousTypeNamesVisitor : DepthFirstAstVisitor<object, object>
		{
			private readonly IntroduceUsingDeclarations transform;

			private string currentNamespace;

			private HashSet<string> currentMemberTypes;

			private Dictionary<string, MemberReference> currentMembers;

			private bool isWithinTypeReferenceExpression;

			public FullyQualifyAmbiguousTypeNamesVisitor(IntroduceUsingDeclarations transform)
			{
				this.transform = transform;
				currentNamespace = ((transform.context.CurrentType != null) ? transform.context.CurrentType.Namespace : string.Empty);
			}

			public override object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data)
			{
				string text = currentNamespace;
				foreach (string identifier in namespaceDeclaration.Identifiers)
				{
					currentNamespace = NamespaceDeclaration.BuildQualifiedName(currentNamespace, identifier);
				}
				base.VisitNamespaceDeclaration(namespaceDeclaration, data);
				currentNamespace = text;
				return null;
			}

			public override object VisitTypeDeclaration(TypeDeclaration typeDeclaration, object data)
			{
				HashSet<string> currentMemberType = currentMemberTypes;
				currentMemberTypes = ((currentMemberTypes != null) ? new HashSet<string>(currentMemberTypes) : new HashSet<string>());
				Dictionary<string, MemberReference> dictionary = currentMembers;
				currentMembers = new Dictionary<string, MemberReference>();
				TypeDefinition typeDefinition = typeDeclaration.Annotation<TypeDefinition>();
				bool flag = true;
				ModuleDefinition module = typeDefinition.Module;
				while (typeDefinition != null)
				{
					foreach (GenericParameter genericParameter in typeDefinition.GenericParameters)
					{
						currentMemberTypes.Add(genericParameter.Name);
					}
					foreach (TypeDefinition nestedType in typeDefinition.NestedTypes)
					{
						if (flag || IsVisible(nestedType, module))
						{
							currentMemberTypes.Add(nestedType.Name.Substring(nestedType.Name.LastIndexOf('+') + 1));
						}
					}
					foreach (MethodDefinition method in typeDefinition.Methods)
					{
						if (flag || IsVisible(method, module))
						{
							AddCurrentMember(method);
						}
					}
					foreach (PropertyDefinition property in typeDefinition.Properties)
					{
						if (flag || IsVisible(property.GetMethod, module) || IsVisible(property.SetMethod, module))
						{
							AddCurrentMember(property);
						}
					}
					foreach (EventDefinition @event in typeDefinition.Events)
					{
						if (flag || IsVisible(@event.AddMethod, module) || IsVisible(@event.RemoveMethod, module))
						{
							AddCurrentMember(@event);
						}
					}
					foreach (FieldDefinition field in typeDefinition.Fields)
					{
						if (flag || IsVisible(field, module))
						{
							AddCurrentMember(field);
						}
					}
					typeDefinition = ((typeDefinition.BaseType == null) ? null : typeDefinition.BaseType.Resolve());
					flag = false;
				}
				if (dictionary != null)
				{
					foreach (KeyValuePair<string, MemberReference> item in dictionary)
					{
						if (!currentMembers.ContainsKey(item.Key))
						{
							currentMembers.Add(item.Key, item.Value);
						}
					}
				}
				base.VisitTypeDeclaration(typeDeclaration, data);
				currentMembers = dictionary;
				return null;
			}

			private void AddCurrentMember(MemberReference m)
			{
				if (currentMembers.TryGetValue(m.Name, out MemberReference value))
				{
					if (value != null && value.DeclaringType == m.DeclaringType)
					{
						currentMembers[m.Name] = null;
					}
				}
				else
				{
					currentMembers.Add(m.Name, m);
				}
			}

			private bool IsVisible(MethodDefinition m, ModuleDefinition internalMembersVisibleInModule)
			{
				if (m == null)
				{
					return false;
				}
				switch (m.Attributes & MethodAttributes.MemberAccessMask)
				{
				case MethodAttributes.FamANDAssem:
				case MethodAttributes.Assembly:
					return m.Module == internalMembersVisibleInModule;
				case MethodAttributes.Family:
				case MethodAttributes.FamORAssem:
				case MethodAttributes.Public:
					return true;
				default:
					return false;
				}
			}

			private bool IsVisible(FieldDefinition f, ModuleDefinition internalMembersVisibleInModule)
			{
				if (f == null)
				{
					return false;
				}
				switch (f.Attributes & FieldAttributes.FieldAccessMask)
				{
				case FieldAttributes.FamANDAssem:
				case FieldAttributes.Assembly:
					return f.Module == internalMembersVisibleInModule;
				case FieldAttributes.Family:
				case FieldAttributes.FamORAssem:
				case FieldAttributes.Public:
					return true;
				default:
					return false;
				}
			}

			private bool IsVisible(TypeDefinition t, ModuleDefinition internalMembersVisibleInModule)
			{
				if (t == null)
				{
					return false;
				}
				switch (t.Attributes & TypeAttributes.VisibilityMask)
				{
				case TypeAttributes.NotPublic:
				case TypeAttributes.NestedAssembly:
				case TypeAttributes.NestedFamANDAssem:
					return t.Module == internalMembersVisibleInModule;
				case TypeAttributes.Public:
				case TypeAttributes.NestedPublic:
				case TypeAttributes.NestedFamily:
				case TypeAttributes.VisibilityMask:
					return true;
				default:
					return false;
				}
			}

			public override object VisitSimpleType(SimpleType simpleType, object data)
			{
				base.VisitSimpleType(simpleType, data);
				TypeReference typeReference = simpleType.Annotation<TypeReference>();
				if (typeReference != null && IsAmbiguous(typeReference.Namespace, typeReference.Name))
				{
					AstType target;
					if (string.IsNullOrEmpty(typeReference.Namespace))
					{
						target = new SimpleType("global");
					}
					else
					{
						string[] array = typeReference.Namespace.Split('.');
						target = ((!IsAmbiguous(string.Empty, array[0])) ? ((AstType)new SimpleType(array[0])) : ((AstType)new MemberType
						{
							Target = new SimpleType("global"),
							IsDoubleColon = true,
							MemberName = array[0]
						}));
						for (int i = 1; i < array.Length; i++)
						{
							target = new MemberType
							{
								Target = target,
								MemberName = array[i]
							};
						}
					}
					MemberType memberType = new MemberType();
					memberType.Target = target;
					memberType.IsDoubleColon = string.IsNullOrEmpty(typeReference.Namespace);
					memberType.MemberName = simpleType.Identifier;
					memberType.CopyAnnotationsFrom(simpleType);
					simpleType.TypeArguments.MoveTo(memberType.TypeArguments);
					simpleType.ReplaceWith(memberType);
				}
				return null;
			}

			public override object VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression, object data)
			{
				isWithinTypeReferenceExpression = true;
				base.VisitTypeReferenceExpression(typeReferenceExpression, data);
				isWithinTypeReferenceExpression = false;
				return null;
			}

			private bool IsAmbiguous(string ns, string name)
			{
				if (currentMemberTypes != null && currentMemberTypes.Contains(name))
				{
					return true;
				}
				if (isWithinTypeReferenceExpression && currentMembers != null && currentMembers.TryGetValue(name, out MemberReference value))
				{
					PropertyDefinition propertyDefinition = value as PropertyDefinition;
					FieldDefinition fieldDefinition = value as FieldDefinition;
					if ((propertyDefinition == null || !(propertyDefinition.PropertyType.Namespace == ns) || !(propertyDefinition.PropertyType.Name == name)) && (fieldDefinition == null || !(fieldDefinition.FieldType.Namespace == ns) || !(fieldDefinition.FieldType.Name == name)))
					{
						return true;
					}
				}
				if (ns == currentNamespace && !string.IsNullOrEmpty(ns))
				{
					return false;
				}
				return transform.ambiguousTypeNames.Contains(name);
			}
		}

		private DecompilerContext context;

		private readonly HashSet<string> declaredNamespaces = new HashSet<string>
		{
			string.Empty
		};

		private readonly HashSet<string> importedNamespaces = new HashSet<string>();

		private readonly HashSet<string> availableTypeNames = new HashSet<string>();

		private readonly HashSet<string> ambiguousTypeNames = new HashSet<string>();

		public IntroduceUsingDeclarations(DecompilerContext context)
		{
			this.context = context;
		}

		public void Run(AstNode compilationUnit)
		{
			compilationUnit.AcceptVisitor(new FindRequiredImports(this), null);
			importedNamespaces.Add("System");
			if (context.Settings.UsingDeclarations)
			{
				foreach (string item in from n in importedNamespaces
					orderby n descending
					select n)
				{
					string[] array = item.Split('.');
					AstType astType = new SimpleType(array[0]);
					for (int i = 1; i < array.Length; i++)
					{
						astType = new MemberType
						{
							Target = astType,
							MemberName = array[i]
						};
					}
					compilationUnit.InsertChildAfter(null, new UsingDeclaration
					{
						Import = astType
					}, SyntaxTree.MemberRole);
				}
			}
			if (context.Settings.FullyQualifyAmbiguousTypeNames)
			{
				FindAmbiguousTypeNames(context.CurrentModule, internalsVisible: true);
				foreach (AssemblyNameReference assemblyReference in context.CurrentModule.AssemblyReferences)
				{
					AssemblyDefinition assemblyDefinition = context.CurrentModule.AssemblyResolver.Resolve(assemblyReference);
					if (assemblyDefinition != null)
					{
						FindAmbiguousTypeNames(assemblyDefinition.MainModule, internalsVisible: false);
					}
				}
				compilationUnit.AcceptVisitor(new FullyQualifyAmbiguousTypeNamesVisitor(this), null);
			}
		}

		private void FindAmbiguousTypeNames(ModuleDefinition module, bool internalsVisible)
		{
			foreach (TypeDefinition type in module.Types)
			{
				if ((internalsVisible || type.IsPublic) && (importedNamespaces.Contains(type.Namespace) || declaredNamespaces.Contains(type.Namespace)) && !availableTypeNames.Add(type.Name))
				{
					ambiguousTypeNames.Add(type.Name);
				}
			}
		}
	}
}
