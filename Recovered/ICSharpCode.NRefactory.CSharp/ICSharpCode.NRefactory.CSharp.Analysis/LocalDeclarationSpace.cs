using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class LocalDeclarationSpace
	{
		private MultiDictionary<string, AstNode> declarations = new MultiDictionary<string, AstNode>();

		public IList<LocalDeclarationSpace> Children
		{
			get;
			private set;
		}

		public LocalDeclarationSpace Parent
		{
			get;
			private set;
		}

		public ICollection<string> DeclaredNames => declarations.Keys;

		public LocalDeclarationSpace()
		{
			Children = new List<LocalDeclarationSpace>();
		}

		public IEnumerable<AstNode> GetNameDeclarations(string name)
		{
			return declarations[name].Concat(Children.SelectMany((LocalDeclarationSpace child) => child.GetNameDeclarations(name)));
		}

		public void AddChildSpace(LocalDeclarationSpace child)
		{
			if (child == null)
			{
				throw new ArgumentNullException("child");
			}
			if (Children.Contains(child))
			{
				throw new InvalidOperationException("the child was already added");
			}
			Children.Add(child);
			child.Parent = this;
		}

		public void AddDeclaration(string name, AstNode node)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			declarations.Add(name, node);
		}

		public bool ContainsName(string name, bool includeChildren)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (declarations.Keys.Contains(name))
			{
				return true;
			}
			if (includeChildren)
			{
				return Children.Any((LocalDeclarationSpace child) => child.ContainsName(name, includeChildren: true));
			}
			return false;
		}

		public bool IsNameUsed(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (!IsNameUsedBySelfOrParent(name))
			{
				return Children.Any((LocalDeclarationSpace child) => child.ContainsName(name, includeChildren: true));
			}
			return true;
		}

		private bool IsNameUsedBySelfOrParent(string name)
		{
			if (declarations.Keys.Contains(name))
			{
				return true;
			}
			if (Parent != null)
			{
				return Parent.IsNameUsedBySelfOrParent(name);
			}
			return false;
		}
	}
}
