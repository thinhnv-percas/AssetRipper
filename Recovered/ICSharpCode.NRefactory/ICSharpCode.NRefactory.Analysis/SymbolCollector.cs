using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Analysis
{
	public class SymbolCollector
	{
		public bool IncludeOverloads
		{
			get;
			set;
		}

		public bool GroupForRenaming
		{
			get;
			set;
		}

		private static IEnumerable<ISymbol> CollectTypeRelatedMembers(ITypeDefinition type)
		{
			yield return type;
			foreach (IMember member in type.GetDefinition().GetMembers((IUnresolvedMember m) => !m.IsSynthetic && ((m.SymbolKind != SymbolKind.Constructor) ? (m.SymbolKind == SymbolKind.Destructor) : true), GetMemberOptions.IgnoreInheritedMembers))
			{
				yield return member;
			}
		}

		private static IEnumerable<ISymbol> CollectOverloads(IMethod method)
		{
			return from m in method.DeclaringType.GetMethods((IUnresolvedMethod m) => m.Name == method.Name)
				where m != method
				select m;
		}

		private static IMember SearchMember(ITypeDefinition derivedType, IMember method)
		{
			foreach (IMember member in derivedType.Members)
			{
				if (member.ImplementedInterfaceMembers.Contains(method))
				{
					return member;
				}
			}
			return null;
		}

		private static IEnumerable<ISymbol> MakeUnique(List<ISymbol> symbols)
		{
			HashSet<ISymbol> taken = new HashSet<ISymbol>();
			foreach (ISymbol symbol in symbols)
			{
				if (!taken.Contains(symbol))
				{
					taken.Add(symbol);
					yield return symbol;
				}
			}
		}

		public IEnumerable<ISymbol> GetRelatedSymbols(Lazy<TypeGraph> g, ISymbol m)
		{
			switch (m.SymbolKind)
			{
			case SymbolKind.TypeDefinition:
				return CollectTypeRelatedMembers((ITypeDefinition)m);
			case SymbolKind.Field:
			case SymbolKind.Operator:
			case SymbolKind.Variable:
			case SymbolKind.Parameter:
			case SymbolKind.TypeParameter:
				return new ISymbol[1]
				{
					m
				};
			case SymbolKind.Constructor:
			{
				if (GroupForRenaming)
				{
					return GetRelatedSymbols(g, ((IMethod)m).DeclaringTypeDefinition);
				}
				List<ISymbol> list2 = new List<ISymbol>();
				if (IncludeOverloads)
				{
					foreach (ISymbol item in CollectOverloads((IMethod)m))
					{
						list2.Add(item);
					}
					return list2;
				}
				return list2;
			}
			case SymbolKind.Destructor:
				if (GroupForRenaming)
				{
					return GetRelatedSymbols(g, ((IMethod)m).DeclaringTypeDefinition);
				}
				return new ISymbol[1]
				{
					m
				};
			case SymbolKind.Property:
			case SymbolKind.Indexer:
			case SymbolKind.Event:
			case SymbolKind.Method:
			{
				IMember member = (IMember)m;
				List<ISymbol> list = new List<ISymbol>();
				if (!member.IsExplicitInterfaceImplementation)
				{
					list.Add(member);
				}
				if (GroupForRenaming)
				{
					foreach (IMember implementedInterfaceMember in member.ImplementedInterfaceMembers)
					{
						list.AddRange(GetRelatedSymbols(g, implementedInterfaceMember));
					}
				}
				else
				{
					list.AddRange(member.ImplementedInterfaceMembers);
				}
				if (member.DeclaringTypeDefinition != null && member.DeclaringTypeDefinition.Kind == TypeKind.Interface)
				{
					TypeGraphNode node = g.Value.GetNode(member.DeclaringTypeDefinition);
					if (node != null)
					{
						foreach (TypeGraphNode derivedType in node.DerivedTypes)
						{
							IMember member2 = SearchMember(derivedType.TypeDefinition, member);
							if (member2 != null)
							{
								list.Add(member2);
							}
						}
					}
				}
				if (IncludeOverloads)
				{
					IncludeOverloads = false;
					if (member is IMethod)
					{
						foreach (ISymbol item2 in CollectOverloads((IMethod)member))
						{
							list.AddRange(GetRelatedSymbols(g, item2));
						}
					}
					else if (member.SymbolKind == SymbolKind.Indexer)
					{
						list.AddRange(member.DeclaringTypeDefinition.GetProperties((IUnresolvedProperty p) => p.IsIndexer));
					}
				}
				return MakeUnique(list);
			}
			case SymbolKind.Namespace:
				return new ISymbol[1]
				{
					m
				};
			default:
				throw new ArgumentOutOfRangeException("symbol:" + m.SymbolKind);
			}
		}
	}
}
