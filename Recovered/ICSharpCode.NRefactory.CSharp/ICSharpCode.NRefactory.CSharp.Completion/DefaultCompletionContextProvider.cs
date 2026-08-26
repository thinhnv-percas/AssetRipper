using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Editor;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Completion
{
	public class DefaultCompletionContextProvider : ICompletionContextProvider
	{
		private readonly IDocument document;

		private readonly CSharpUnresolvedFile unresolvedFile;

		private readonly List<string> symbols = new List<string>();

		public IList<string> ConditionalSymbols => symbols;

		public DefaultCompletionContextProvider(IDocument document, CSharpUnresolvedFile unresolvedFile)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			if (unresolvedFile == null)
			{
				throw new ArgumentNullException("unresolvedFile");
			}
			this.document = document;
			this.unresolvedFile = unresolvedFile;
		}

		public void AddSymbol(string sym)
		{
			symbols.Add(sym);
		}

		public void GetCurrentMembers(int offset, out IUnresolvedTypeDefinition currentType, out IUnresolvedMember currentMember)
		{
			TextLocation location = document.GetLocation(offset);
			currentType = null;
			foreach (IUnresolvedTypeDefinition topLevelTypeDefinition in unresolvedFile.TopLevelTypeDefinitions)
			{
				if (topLevelTypeDefinition.Region.Begin < location)
				{
					currentType = topLevelTypeDefinition;
				}
			}
			currentType = FindInnerType(currentType, location);
			if (currentType != null && currentType.Region.End < location && !IsInsideType(currentType, location))
			{
				currentType = null;
			}
			currentMember = null;
			if (currentType != null)
			{
				foreach (IUnresolvedMember member in currentType.Members)
				{
					if (member.Region.Begin < location && (currentMember == null || currentMember.Region.Begin < member.Region.Begin))
					{
						currentMember = member;
					}
				}
			}
			if (currentMember != null && currentMember.Region.End < location && currentType.Kind != TypeKind.Enum && !IsInsideType(currentMember, location))
			{
				currentMember = null;
			}
		}

		private IUnresolvedTypeDefinition FindInnerType(IUnresolvedTypeDefinition parent, TextLocation location)
		{
			if (parent == null)
			{
				return null;
			}
			IUnresolvedTypeDefinition result = parent;
			foreach (IUnresolvedTypeDefinition nestedType in parent.NestedTypes)
			{
				if (nestedType.Region.Begin < location && location < nestedType.Region.End)
				{
					result = FindInnerType(nestedType, location);
				}
			}
			return result;
		}

		private bool IsInsideType(IUnresolvedEntity currentType, TextLocation location)
		{
			if (currentType.Region.IsEmpty)
			{
				return false;
			}
			int offset = document.GetOffset(currentType.Region.Begin);
			int offset2 = document.GetOffset(location);
			Stack<char> stack = new Stack<char>();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			for (int i = offset; i < offset2; i++)
			{
				char charAt = document.GetCharAt(i);
				switch (charAt)
				{
				case '(':
				case '[':
				case '{':
					if (!flag && !flag2 && !flag3 && !flag4)
					{
						stack.Push(charAt);
					}
					break;
				case ')':
				case ']':
				case '}':
					if (!flag && !flag2 && !flag3 && !flag4 && stack.Count > 0)
					{
						stack.Pop();
					}
					break;
				case '/':
					if (flag4)
					{
						if (i > 0 && document.GetCharAt(i - 1) == '*')
						{
							flag4 = false;
						}
					}
					else if (!flag && !flag2 && i + 1 < document.TextLength)
					{
						char charAt2 = document.GetCharAt(i + 1);
						if (charAt2 == '/')
						{
							flag3 = true;
						}
						if (!flag3 && charAt2 == '*')
						{
							flag4 = true;
						}
					}
					break;
				case '"':
					if (!(flag2 | flag3 | flag4))
					{
						flag = !flag;
					}
					break;
				case '\'':
					if (!(flag | flag3 | flag4))
					{
						flag2 = !flag2;
					}
					break;
				default:
					if (NewLine.IsNewLine(charAt))
					{
						flag3 = false;
					}
					break;
				}
			}
			return stack.Any((char t) => t == '{');
		}

		public Tuple<string, TextLocation> GetMemberTextToCaret(int caretOffset, IUnresolvedTypeDefinition currentType, IUnresolvedMember currentMember)
		{
			int num;
			for (num = ((currentMember != null && currentType != null && currentType.Kind != TypeKind.Enum) ? document.GetOffset(currentMember.Region.Begin) : ((currentType != null) ? document.GetOffset(currentType.Region.Begin) : 0)); num > 0; num--)
			{
				char charAt = document.GetCharAt(num - 1);
				if (charAt != ' ' && charAt != '\t')
				{
					break;
				}
			}
			return Tuple.Create(document.GetText(num, caretOffset - num), document.GetLocation(num));
		}

		public CSharpAstResolver GetResolver(CSharpResolver resolver, AstNode rootNode)
		{
			return new CSharpAstResolver(resolver, rootNode, unresolvedFile);
		}
	}
}
