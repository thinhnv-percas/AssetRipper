using ICSharpCode.NRefactory.Completion;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class CompletionDataWrapper
	{
		private class TypeCompletionCategory : CompletionCategory
		{
			public IType Type
			{
				get;
				private set;
			}

			public TypeCompletionCategory(IType type)
				: base(type.FullName, null)
			{
				Type = type;
			}

			public override int CompareTo(CompletionCategory other)
			{
				TypeCompletionCategory compareCategory = other as TypeCompletionCategory;
				if (compareCategory == null)
				{
					return -1;
				}
				if (Type.ReflectionName == compareCategory.Type.ReflectionName)
				{
					return 0;
				}
				if (Type.GetAllBaseTypes().Any((IType t) => t.ReflectionName == compareCategory.Type.ReflectionName))
				{
					return -1;
				}
				if (compareCategory.Type.GetAllBaseTypes().Any((IType t) => t.ReflectionName == Type.ReflectionName))
				{
					return 1;
				}
				ITypeDefinition definition = Type.GetDefinition();
				ITypeDefinition definition2 = compareCategory.Type.GetDefinition();
				if (definition2.IsStatic && definition.IsStatic)
				{
					return definition.FullName.CompareTo(definition2.FullName);
				}
				if (definition.IsStatic)
				{
					return 1;
				}
				if (definition2.IsStatic)
				{
					return -1;
				}
				return 0;
			}
		}

		private CSharpCompletionEngine completion;

		private List<ICompletionData> result = new List<ICompletionData>();

		private HashSet<string> usedNamespaces = new HashSet<string>();

		private Dictionary<string, ICompletionData> typeDisplayText = new Dictionary<string, ICompletionData>();

		private Dictionary<IType, ICompletionData> addedTypes = new Dictionary<IType, ICompletionData>();

		private Dictionary<string, List<ICompletionData>> data = new Dictionary<string, List<ICompletionData>>();

		private Dictionary<IType, CompletionCategory> completionCategories = new Dictionary<IType, CompletionCategory>();

		private HashSet<IType> addedEnums = new HashSet<IType>();

		private HashSet<string> anonymousSignatures = new HashSet<string>();

		public List<ICompletionData> Result => result;

		private ICompletionDataFactory Factory => completion.factory;

		internal bool AnonymousDelegateAdded
		{
			get;
			set;
		}

		public CompletionDataWrapper(CSharpCompletionEngine completion)
		{
			this.completion = completion;
		}

		public void Add(ICompletionData data)
		{
			result.Add(data);
		}

		public ICompletionData AddCustom(string displayText, string description = null, string completionText = null)
		{
			ICompletionData item = Factory.CreateLiteralCompletionData(displayText, description, completionText);
			result.Add(item);
			return item;
		}

		private bool IsAccessible(MemberLookup lookup, INamespace ns)
		{
			if (ns.Types.Any((ITypeDefinition t) => lookup.IsAccessible(t, allowProtectedAccess: false)))
			{
				return true;
			}
			foreach (INamespace childNamespace in ns.ChildNamespaces)
			{
				if (IsAccessible(lookup, childNamespace))
				{
					return true;
				}
			}
			return false;
		}

		public void AddNamespace(MemberLookup lookup, INamespace ns)
		{
			if (!usedNamespaces.Contains(ns.Name))
			{
				if (!IsAccessible(lookup, ns))
				{
					usedNamespaces.Add(ns.Name);
					return;
				}
				usedNamespaces.Add(ns.Name);
				result.Add(Factory.CreateNamespaceCompletionData(ns));
			}
		}

		public void AddAlias(string alias)
		{
			result.Add(Factory.CreateLiteralCompletionData(alias));
		}

		public ICompletionData AddConstructors(IType type, bool showFullName, bool isInAttributeContext = false)
		{
			return InternalAddType(type, showFullName, isInAttributeContext, addConstrurs: true);
		}

		public ICompletionData AddType(IType type, bool showFullName, bool isInAttributeContext = false)
		{
			return InternalAddType(type, showFullName, isInAttributeContext, addConstrurs: false);
		}

		private ICompletionData InternalAddType(IType type, bool showFullName, bool isInAttributeContext, bool addConstrurs)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if ((type.Name == "Void" && type.Namespace == "System") || type.Kind == TypeKind.Unknown)
			{
				return null;
			}
			if (addedTypes.ContainsKey(type))
			{
				return addedTypes[type];
			}
			usedNamespaces.Add(type.Name);
			ITypeDefinition definition = type.GetDefinition();
			if (definition != null && definition.ParentAssembly != completion.ctx.CurrentAssembly)
			{
				switch (completion.EditorBrowsableBehavior)
				{
				case EditorBrowsableBehavior.Normal:
					if (definition.GetEditorBrowsableState() != 0)
					{
						return null;
					}
					break;
				case EditorBrowsableBehavior.IncludeAdvanced:
					if (!definition.IsBrowsable())
					{
						return null;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case EditorBrowsableBehavior.Ignore:
					break;
				}
			}
			ICompletionData completionData = Factory.CreateTypeCompletionData(type, showFullName, isInAttributeContext, addConstrurs);
			string displayText = completionData.DisplayText;
			if (typeDisplayText.TryGetValue(displayText, out ICompletionData value))
			{
				value.AddOverload(completionData);
				return value;
			}
			typeDisplayText[displayText] = completionData;
			result.Add(completionData);
			addedTypes[type] = completionData;
			return completionData;
		}

		public ICompletionData AddVariable(IVariable variable)
		{
			if (data.ContainsKey(variable.Name))
			{
				return null;
			}
			data[variable.Name] = new List<ICompletionData>();
			ICompletionData item = Factory.CreateVariableCompletionData(variable);
			result.Add(item);
			return item;
		}

		public ICompletionData AddNamedParameterVariable(IVariable variable)
		{
			string key = variable.Name + ":";
			if (data.ContainsKey(key))
			{
				return null;
			}
			data[key] = new List<ICompletionData>();
			ICompletionData completionData = Factory.CreateVariableCompletionData(variable);
			completionData.CompletionText += ":";
			completionData.DisplayText += ":";
			result.Add(completionData);
			return completionData;
		}

		public void AddTypeParameter(ITypeParameter variable)
		{
			if (!data.ContainsKey(variable.Name))
			{
				data[variable.Name] = new List<ICompletionData>();
				result.Add(Factory.CreateVariableCompletionData(variable));
			}
		}

		public void AddTypeImport(ITypeDefinition type, bool useFullName, bool addForTypeCreation)
		{
			result.Add(Factory.CreateImportCompletionData(type, useFullName, addForTypeCreation));
		}

		public ICompletionData AddMember(IMember member)
		{
			ICompletionData completionData = Factory.CreateEntityCompletionData(member);
			if (member.ParentAssembly != completion.ctx.CurrentAssembly)
			{
				switch (completion.EditorBrowsableBehavior)
				{
				case EditorBrowsableBehavior.Normal:
					if (member.GetEditorBrowsableState() != 0)
					{
						return null;
					}
					break;
				case EditorBrowsableBehavior.IncludeAdvanced:
					if (!member.IsBrowsable())
					{
						return null;
					}
					break;
				default:
					throw new ArgumentOutOfRangeException();
				case EditorBrowsableBehavior.Ignore:
					break;
				}
			}
			string displayText = completionData.DisplayText;
			if (displayText == null)
			{
				return null;
			}
			completionData.CompletionCategory = GetCompletionCategory(member.DeclaringTypeDefinition);
			data.TryGetValue(displayText, out List<ICompletionData> value);
			if (value != null)
			{
				if (member.SymbolKind == SymbolKind.Field || member.SymbolKind == SymbolKind.Property || member.SymbolKind == SymbolKind.Event)
				{
					return null;
				}
				foreach (ICompletionData item in value)
				{
					if (item is IEntityCompletionData)
					{
						IEntity entity = ((IEntityCompletionData)item).Entity;
						if (member == null || entity == null || member.SymbolKind == entity.SymbolKind)
						{
							item.AddOverload(completionData);
							return item;
						}
					}
				}
				if (completionData != null)
				{
					result.Add(completionData);
					data[displayText].Add(completionData);
				}
			}
			else
			{
				result.Add(completionData);
				data[displayText] = new List<ICompletionData>();
				data[displayText].Add(completionData);
			}
			return completionData;
		}

		internal CompletionCategory GetCompletionCategory(IType type)
		{
			if (type == null)
			{
				return null;
			}
			if (!completionCategories.ContainsKey(type))
			{
				completionCategories[type] = new TypeCompletionCategory(type);
			}
			return completionCategories[type];
		}

		public ICompletionData AddEnumMembers(IType resolvedType, CSharpResolver state)
		{
			if (addedEnums.Contains(resolvedType))
			{
				return null;
			}
			addedEnums.Add(resolvedType);
			ICompletionData completionData = AddType(resolvedType, showFullName: true);
			foreach (IField field in resolvedType.GetFields())
			{
				if (field.IsPublic && (field.IsConst || field.IsStatic))
				{
					Result.Add(Factory.CreateMemberCompletionData(resolvedType, field));
				}
			}
			return completionData;
		}

		public bool HasAnonymousDelegateAdded(string signature)
		{
			return anonymousSignatures.Contains(signature);
		}

		public void AddAnonymousDelegateAdded(string signature)
		{
			anonymousSignatures.Add(signature);
		}
	}
}
