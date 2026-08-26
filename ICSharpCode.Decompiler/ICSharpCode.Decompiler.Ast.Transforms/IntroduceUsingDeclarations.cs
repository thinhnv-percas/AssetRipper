using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class IntroduceUsingDeclarations : IAstTransformPoolObject, IAstTransform
{
	private struct NamespaceRef : IEquatable<NamespaceRef>
	{
		public IAssembly Assembly { get; }

		public string Namespace { get; }

		public NamespaceRef(IAssembly asm, string ns)
		{
			Assembly = asm;
			Namespace = ns;
		}

		public bool Equals(NamespaceRef other)
		{
			return StringComparer.Ordinal.Equals(other.Namespace, Namespace);
		}

		public override bool Equals(object obj)
		{
			if (obj is NamespaceRef)
			{
				return Equals((NamespaceRef)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return StringComparer.Ordinal.GetHashCode(Namespace);
		}
	}

	private sealed class ReverseSortSystemUsingStatementsFirstComparer : IComparer<NamespaceRef>
	{
		public static readonly ReverseSortSystemUsingStatementsFirstComparer Instance = new ReverseSortSystemUsingStatementsFirstComparer();

		public int Compare(NamespaceRef x, NamespaceRef y)
		{
			bool flag = x.Namespace == "System" || x.Namespace.StartsWith("System.");
			bool flag2 = y.Namespace == "System" || y.Namespace.StartsWith("System.");
			if (flag & flag2)
			{
				return StringComparer.OrdinalIgnoreCase.Compare(y.Namespace, x.Namespace);
			}
			if (flag && !flag2)
			{
				return 1;
			}
			if (!flag & flag2)
			{
				return -1;
			}
			return StringComparer.OrdinalIgnoreCase.Compare(y.Namespace, x.Namespace);
		}
	}

	private sealed class ReverseSortNamespacesAlphabeticallyComparer : IComparer<NamespaceRef>
	{
		public static readonly ReverseSortNamespacesAlphabeticallyComparer Instance = new ReverseSortNamespacesAlphabeticallyComparer();

		public int Compare(NamespaceRef x, NamespaceRef y)
		{
			return StringComparer.OrdinalIgnoreCase.Compare(y.Namespace, x.Namespace);
		}
	}

	private sealed class AssemblyEqualityComparer : IEqualityComparer<AssemblyDef>
	{
		public static readonly AssemblyEqualityComparer Instance = new AssemblyEqualityComparer();

		public bool Equals(AssemblyDef x, AssemblyDef y)
		{
			if (x == y)
			{
				return true;
			}
			if (x == null || y == null)
			{
				return false;
			}
			if (!x.Name.String.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase))
			{
				return false;
			}
			if (x.PublicKey.IsNullOrEmpty != y.PublicKey.IsNullOrEmpty)
			{
				return false;
			}
			if (x.PublicKey.IsNullOrEmpty)
			{
				return true;
			}
			return x.PublicKey.Equals(y.PublicKey);
		}

		public int GetHashCode(AssemblyDef obj)
		{
			return obj.Name.ToUpperInvariant().GetHashCode() + obj.PublicKey.GetHashCode();
		}
	}

	private sealed class FindRequiredImports : DepthFirstAstVisitor<object, object>
	{
		private readonly IntroduceUsingDeclarations transform;

		private string currentNamespace;

		public FindRequiredImports(IntroduceUsingDeclarations transform)
		{
			this.transform = transform;
			currentNamespace = ((transform.context.CurrentType != null) ? transform.context.CurrentType.Namespace.String : string.Empty);
		}

		private bool IsParentOfCurrentNamespace(StringBuilder sb)
		{
			if (sb.Length == 0)
			{
				return true;
			}
			if (currentNamespace.StartsWith(sb))
			{
				if (currentNamespace.Length == sb.Length)
				{
					return true;
				}
				if (currentNamespace[sb.Length] == '.')
				{
					return true;
				}
			}
			return false;
		}

		public override object VisitSimpleType(SimpleType simpleType, object data)
		{
			ITypeDefOrRef typeDefOrRef = simpleType.Annotation<ITypeDefOrRef>();
			if (typeDefOrRef != null)
			{
				StringBuilder stringBuilder = GetNamespace(typeDefOrRef);
				if (!IsParentOfCurrentNamespace(stringBuilder))
				{
					string text = stringBuilder.ToString();
					transform.importedNamespaces.Add(new NamespaceRef(typeDefOrRef.DefinitionAssembly, text));
					transform.importedOrDeclaredNamespaces.Add(text);
				}
			}
			return base.VisitSimpleType(simpleType, data);
		}

		private StringBuilder GetNamespace(IType type)
		{
			transform.stringBuilder.Clear();
			if (type == null)
			{
				return transform.stringBuilder;
			}
			return FullNameFactory.NamespaceSB(type, isReflection: false, transform.stringBuilder);
		}

		public override object VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration, object data)
		{
			string text = currentNamespace;
			foreach (string identifier in namespaceDeclaration.Identifiers)
			{
				currentNamespace = NamespaceDeclaration.BuildQualifiedName(currentNamespace, identifier);
				transform.importedOrDeclaredNamespaces.Add(currentNamespace);
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

		private Dictionary<string, IMemberRef> currentMembers;

		private bool isWithinTypeReferenceExpression;

		public FullyQualifyAmbiguousTypeNamesVisitor(IntroduceUsingDeclarations transform)
		{
			this.transform = transform;
			currentNamespace = ((transform.context.CurrentType != null) ? transform.context.CurrentType.Namespace.String : string.Empty);
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
			HashSet<string> hashSet = currentMemberTypes;
			currentMemberTypes = ((currentMemberTypes != null) ? new HashSet<string>(currentMemberTypes) : new HashSet<string>());
			Dictionary<string, IMemberRef> dictionary = currentMembers;
			currentMembers = new Dictionary<string, IMemberRef>();
			TypeDef typeDef = typeDeclaration.Annotation<TypeDef>();
			bool flag = true;
			ModuleDef internalMembersVisibleInModule = typeDef?.Module;
			while (typeDef != null)
			{
				foreach (GenericParam genericParameter in typeDef.GenericParameters)
				{
					currentMemberTypes.Add(genericParameter.Name);
				}
				foreach (TypeDef nestedType in typeDef.NestedTypes)
				{
					if (flag || IsVisible(nestedType, internalMembersVisibleInModule))
					{
						currentMemberTypes.Add(nestedType.Name.Substring(nestedType.Name.LastIndexOf('+') + 1));
					}
				}
				foreach (MethodDef method in typeDef.Methods)
				{
					if (flag || IsVisible(method, internalMembersVisibleInModule))
					{
						AddCurrentMember(method);
					}
				}
				foreach (PropertyDef property in typeDef.Properties)
				{
					if (flag || IsVisible(property.GetMethod, internalMembersVisibleInModule) || IsVisible(property.SetMethod, internalMembersVisibleInModule))
					{
						AddCurrentMember(property);
					}
				}
				foreach (EventDef @event in typeDef.Events)
				{
					if (flag || IsVisible(@event.AddMethod, internalMembersVisibleInModule) || IsVisible(@event.RemoveMethod, internalMembersVisibleInModule))
					{
						AddCurrentMember(@event);
					}
				}
				foreach (FieldDef field in typeDef.Fields)
				{
					if (flag || IsVisible(field, internalMembersVisibleInModule))
					{
						AddCurrentMember(field);
					}
				}
				typeDef = ((typeDef.BaseType == null) ? null : typeDef.BaseType.ResolveTypeDef());
				flag = false;
			}
			if (dictionary != null)
			{
				foreach (KeyValuePair<string, IMemberRef> item in dictionary)
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

		private void AddCurrentMember(IMemberRef m)
		{
			if (currentMembers.TryGetValue(m.Name, out var value))
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

		private bool IsVisible(MethodDef m, ModuleDef internalMembersVisibleInModule)
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

		private bool IsVisible(FieldDef f, ModuleDef internalMembersVisibleInModule)
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

		private bool IsVisible(TypeDef t, ModuleDef internalMembersVisibleInModule)
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
			ITypeDefOrRef typeDefOrRef = simpleType.Annotation<ITypeDefOrRef>();
			if (typeDefOrRef == null)
			{
				return null;
			}
			string text = GetNamespace(typeDefOrRef).ToString();
			if (IsAmbiguous(text, null, GetName(typeDefOrRef)))
			{
				AstType target;
				if (string.IsNullOrEmpty(text))
				{
					target = new SimpleType("global").WithAnnotation(BoxedTextColor.Keyword);
				}
				else
				{
					StringBuilder stringBuilder = transform.stringBuilder;
					string[] array = text.Split('.');
					IAssembly definitionAssembly = typeDefOrRef.DefinitionAssembly;
					stringBuilder.Clear();
					stringBuilder.Append(array[0]);
					if (IsAmbiguous(string.Empty, array[0], null))
					{
						MemberType memberType = new MemberType();
						SimpleType simpleType2 = (SimpleType)(memberType.Target = new SimpleType("global").WithAnnotation(BoxedTextColor.Keyword));
						memberType.IsDoubleColon = true;
						memberType.MemberNameToken = Identifier.Create(array[0]).WithAnnotation(BoxedTextColor.Namespace);
						target = memberType.WithAnnotation(BoxedTextColor.Namespace);
						simpleType2.IdentifierToken.WithAnnotation(BoxedTextColor.Keyword);
					}
					else
					{
						SimpleType simpleType3;
						target = (simpleType3 = new SimpleType(array[0]).WithAnnotation(BoxedTextColor.Namespace));
						simpleType3.IdentifierToken.WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(definitionAssembly, array[0]));
					}
					for (int i = 1; i < array.Length; i++)
					{
						stringBuilder.Append('.');
						stringBuilder.Append(array[i]);
						string text2 = stringBuilder.ToString();
						target = new MemberType
						{
							Target = target,
							MemberNameToken = Identifier.Create(array[i]).WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(definitionAssembly, text2))
						}.WithAnnotation(BoxedTextColor.Namespace);
					}
				}
				MemberType memberType2 = new MemberType();
				memberType2.Target = target;
				memberType2.IsDoubleColon = string.IsNullOrEmpty(text);
				memberType2.MemberNameToken = (Identifier)simpleType.IdentifierToken.Clone();
				memberType2.CopyAnnotationsFrom(simpleType);
				simpleType.TypeArguments.MoveTo(memberType2.TypeArguments);
				simpleType.ReplaceWith(memberType2);
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

		private bool IsAmbiguous(string ns, string name, StringBuilder sbName)
		{
			if (transform.context.Settings.FullyQualifyAllTypes)
			{
				return true;
			}
			if (currentMemberTypes != null && currentMemberTypes.Contains(name ?? (name = sbName.ToString())))
			{
				return true;
			}
			if (isWithinTypeReferenceExpression && currentMembers != null)
			{
				if (name == null)
				{
					name = sbName.ToString();
				}
				if (currentMembers.TryGetValue(name, out var value))
				{
					PropertyDef propertyDef = value as PropertyDef;
					FieldDef fieldDef = value as FieldDef;
					if ((propertyDef == null || !GetNamespace(propertyDef.PropertySig.GetRetType()).CheckEquals(ns) || !GetName(propertyDef.PropertySig.GetRetType()).CheckEquals(name)) && (fieldDef == null || fieldDef.FieldType == null || !GetNamespace(fieldDef.FieldType).CheckEquals(ns) || !GetName(fieldDef.FieldType).CheckEquals(name)))
					{
						return true;
					}
				}
			}
			if (ns == currentNamespace && !string.IsNullOrEmpty(ns))
			{
				return false;
			}
			return transform.ambiguousTypeNames.Contains(name ?? (name = sbName.ToString()));
		}

		private StringBuilder GetNamespace(IType type)
		{
			transform.stringBuilder.Clear();
			if (type == null)
			{
				return transform.stringBuilder;
			}
			return FullNameFactory.NamespaceSB(type, isReflection: false, transform.stringBuilder);
		}

		private StringBuilder GetName(IType type)
		{
			transform.stringBuilder.Clear();
			if (type == null)
			{
				return transform.stringBuilder;
			}
			return FullNameFactory.NameSB(type, isReflection: false, transform.stringBuilder);
		}
	}

	private DecompilerContext context;

	private readonly StringBuilder stringBuilder;

	private readonly Dictionary<string, List<TypeDef>> typesWithNamespace_currentModule = new Dictionary<string, List<TypeDef>>(StringComparer.Ordinal);

	private readonly List<Dictionary<string, List<TypeDef>>> typesWithNamespace_allAsms_list = new List<Dictionary<string, List<TypeDef>>>();

	private readonly List<NamespaceRef> namespaceRefList = new List<NamespaceRef>();

	private ModuleDef lastCheckedModule;

	private static readonly char[] namespaceSep = new char[1] { '.' };

	private readonly HashSet<string> importedOrDeclaredNamespaces = new HashSet<string>(StringComparer.Ordinal);

	private readonly HashSet<NamespaceRef> importedNamespaces = new HashSet<NamespaceRef>();

	private readonly HashSet<string> availableTypeNames = new HashSet<string>(StringComparer.Ordinal);

	private readonly HashSet<string> ambiguousTypeNames = new HashSet<string>(StringComparer.Ordinal);

	public IntroduceUsingDeclarations(DecompilerContext context)
	{
		stringBuilder = new StringBuilder();
		Reset(context);
	}

	public void Reset(DecompilerContext context)
	{
		this.context = context;
		namespaceRefList.Clear();
		ambiguousTypeNames.Clear();
		availableTypeNames.Clear();
		importedNamespaces.Clear();
		importedOrDeclaredNamespaces.Clear();
		importedOrDeclaredNamespaces.Add(string.Empty);
	}

	public void Run(AstNode compilationUnit)
	{
		compilationUnit.AcceptVisitor(new FindRequiredImports(this), null);
		importedNamespaces.Add(new NamespaceRef(context.CurrentModule.CorLibTypes.AssemblyRef, "System"));
		importedOrDeclaredNamespaces.Add("System");
		if (context.CalculateILSpans)
		{
			foreach (NamespaceRef importedNamespace in importedNamespaces)
			{
				context.UsingNamespaces.Add(importedNamespace.Namespace);
			}
		}
		if (context.Settings.UsingDeclarations)
		{
			foreach (NamespaceRef item in GetNamespacesInReverseOrder())
			{
				string[] array = item.Namespace.Split(namespaceSep);
				stringBuilder.Clear();
				stringBuilder.Append(array[0]);
				IAssembly assembly = item.Assembly;
				SimpleType simpleType;
				AstType astType = (simpleType = new SimpleType(array[0]).WithAnnotation(BoxedTextColor.Namespace));
				simpleType.IdentifierToken.WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(assembly, array[0]));
				for (int i = 1; i < array.Length; i++)
				{
					stringBuilder.Append('.');
					stringBuilder.Append(array[i]);
					string text = stringBuilder.ToString();
					astType = new MemberType
					{
						Target = astType,
						MemberNameToken = Identifier.Create(array[i]).WithAnnotation(BoxedTextColor.Namespace).WithAnnotation(new NamespaceReference(assembly, text))
					}.WithAnnotation(BoxedTextColor.Namespace);
				}
				compilationUnit.InsertChildAfter(null, new UsingDeclaration
				{
					Import = astType
				}, SyntaxTree.MemberRole);
			}
		}
		if (!context.Settings.FullyQualifyAmbiguousTypeNames && !context.Settings.FullyQualifyAllTypes)
		{
			return;
		}
		if (context.CurrentModule != null)
		{
			if (lastCheckedModule != context.CurrentModule)
			{
				typesWithNamespace_currentModule.Clear();
				BuildAmbiguousTypeNamesTable(typesWithNamespace_currentModule, context.CurrentModule.Types, internalsVisible: true);
			}
			FindAmbiguousTypeNames(typesWithNamespace_currentModule, internalsVisible: true);
			if (lastCheckedModule != context.CurrentModule)
			{
				Dictionary<AssemblyDef, List<AssemblyDef>> dictionary = new Dictionary<AssemblyDef, List<AssemblyDef>>(AssemblyEqualityComparer.Instance);
				lastCheckedModule = context.CurrentModule;
				foreach (AssemblyRef assemblyRef in context.CurrentModule.GetAssemblyRefs())
				{
					AssemblyDef assemblyDef = context.CurrentModule.Context.AssemblyResolver.Resolve(assemblyRef, context.CurrentModule);
					if (assemblyDef != null)
					{
						if (!dictionary.TryGetValue(assemblyDef, out var value))
						{
							dictionary.Add(assemblyDef, value = new List<AssemblyDef>());
						}
						value.Add(assemblyDef);
					}
				}
				typesWithNamespace_allAsms_list.Clear();
				foreach (List<AssemblyDef> value2 in dictionary.Values)
				{
					Dictionary<string, List<TypeDef>> dictionary2 = new Dictionary<string, List<TypeDef>>(StringComparer.Ordinal);
					BuildAmbiguousTypeNamesTable(dictionary2, GetTypes(value2), internalsVisible: false);
					typesWithNamespace_allAsms_list.Add(dictionary2);
				}
			}
			foreach (Dictionary<string, List<TypeDef>> item2 in typesWithNamespace_allAsms_list)
			{
				FindAmbiguousTypeNames(item2, internalsVisible: false);
			}
		}
		compilationUnit.AcceptVisitor(new FullyQualifyAmbiguousTypeNamesVisitor(this), null);
	}

	private List<NamespaceRef> GetNamespacesInReverseOrder()
	{
		namespaceRefList.Clear();
		foreach (NamespaceRef importedNamespace in importedNamespaces)
		{
			namespaceRefList.Add(importedNamespace);
		}
		if (context.Settings.SortSystemUsingStatementsFirst)
		{
			namespaceRefList.Sort(ReverseSortSystemUsingStatementsFirstComparer.Instance);
		}
		else
		{
			namespaceRefList.Sort(ReverseSortNamespacesAlphabeticallyComparer.Instance);
		}
		return namespaceRefList;
	}

	private static IEnumerable<TypeDef> GetTypes(List<AssemblyDef> asms)
	{
		if (asms.Count == 0)
		{
			return Array.Empty<TypeDef>();
		}
		if (asms.Count == 1)
		{
			if (asms[0].Modules.Count == 1)
			{
				return asms[0].ManifestModule.Types;
			}
			return asms[0].Modules.SelectMany((ModuleDef m) => m.Types);
		}
		HashSet<TypeDef> hashSet = new HashSet<TypeDef>(new TypeEqualityComparer(SigComparerOptions.DontCompareTypeScope));
		foreach (AssemblyDef asm in asms)
		{
			foreach (ModuleDef module in asm.Modules)
			{
				foreach (TypeDef type in module.Types)
				{
					if (!hashSet.Add(type) && type.IsPublic)
					{
						hashSet.Remove(type);
						bool flag = hashSet.Add(type);
					}
				}
			}
		}
		return hashSet;
	}

	private void BuildAmbiguousTypeNamesTable(Dictionary<string, List<TypeDef>> dict, IEnumerable<TypeDef> types, bool internalsVisible)
	{
		foreach (TypeDef type in types)
		{
			if (internalsVisible || type.IsPublic)
			{
				string key = type.Namespace;
				if (!dict.TryGetValue(key, out var value))
				{
					dict.Add(key, value = new List<TypeDef>());
				}
				value.Add(type);
			}
		}
	}

	private void FindAmbiguousTypeNames(Dictionary<string, List<TypeDef>> dict, bool internalsVisible)
	{
		foreach (string importedOrDeclaredNamespace in importedOrDeclaredNamespaces)
		{
			if (!dict.TryGetValue(importedOrDeclaredNamespace, out var value))
			{
				continue;
			}
			foreach (TypeDef item2 in value)
			{
				if (internalsVisible || item2.IsPublic)
				{
					string item = item2.Name;
					if (!availableTypeNames.Add(item))
					{
						ambiguousTypeNames.Add(item);
					}
				}
			}
		}
	}
}
