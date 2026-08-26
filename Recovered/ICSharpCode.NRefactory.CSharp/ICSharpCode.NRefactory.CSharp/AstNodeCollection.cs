using ICSharpCode.NRefactory.PatternMatching;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
	public class AstNodeCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable where T : AstNode
	{
		private readonly AstNode node;

		private readonly Role<T> role;

		public int Count
		{
			get
			{
				int num = 0;
				uint index = role.Index;
				for (AstNode astNode = node.FirstChild; astNode != null; astNode = astNode.NextSibling)
				{
					if (astNode.RoleIndex == index)
					{
						num++;
					}
				}
				return num;
			}
		}

		bool ICollection<T>.IsReadOnly => false;

		public AstNodeCollection(AstNode node, Role<T> role)
		{
			if (node == null)
			{
				throw new ArgumentNullException("node");
			}
			if (role == null)
			{
				throw new ArgumentNullException("role");
			}
			this.node = node;
			this.role = role;
		}

		public void Add(T element)
		{
			node.AddChild(element, role);
		}

		public void AddRange(IEnumerable<T> nodes)
		{
			if (nodes != null)
			{
				foreach (T item in nodes.ToList())
				{
					Add(item);
				}
			}
		}

		public void AddRange(T[] nodes)
		{
			if (nodes != null)
			{
				foreach (T element in nodes)
				{
					Add(element);
				}
			}
		}

		public void ReplaceWith(IEnumerable<T> nodes)
		{
			if (nodes != null)
			{
				nodes = nodes.ToList();
			}
			Clear();
			if (nodes != null)
			{
				foreach (T node2 in nodes)
				{
					Add(node2);
				}
			}
		}

		public void MoveTo(ICollection<T> targetCollection)
		{
			if (targetCollection == null)
			{
				throw new ArgumentNullException("targetCollection");
			}
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					current.Remove();
					targetCollection.Add(current);
				}
			}
		}

		public bool Contains(T element)
		{
			if (element != null && element.Parent == node)
			{
				return element.RoleIndex == role.Index;
			}
			return false;
		}

		public bool Remove(T element)
		{
			if (Contains(element))
			{
				element.Remove();
				return true;
			}
			return false;
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					array[arrayIndex++] = current;
				}
			}
		}

		public void Clear()
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					enumerator.Current.Remove();
				}
			}
		}

		public T FirstOrNullObject(Func<T, bool> predicate = null)
		{
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (predicate == null || predicate(current))
					{
						return current;
					}
				}
			}
			return role.NullObject;
		}

		public T LastOrNullObject(Func<T, bool> predicate = null)
		{
			T result = role.NullObject;
			using (IEnumerator<T> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					T current = enumerator.Current;
					if (predicate == null || predicate(current))
					{
						result = current;
					}
				}
				return result;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			uint roleIndex = role.Index;
			AstNode next;
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = next)
			{
				next = astNode.NextSibling;
				if (astNode.RoleIndex == roleIndex)
				{
					yield return (T)astNode;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override int GetHashCode()
		{
			return node.GetHashCode() ^ role.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			AstNodeCollection<T> astNodeCollection = obj as AstNodeCollection<T>;
			if (astNodeCollection == null)
			{
				return false;
			}
			if (node == astNodeCollection.node)
			{
				return role == astNodeCollection.role;
			}
			return false;
		}

		internal bool DoMatch(AstNodeCollection<T> other, Match match)
		{
			return Pattern.DoMatchCollection(role, node.FirstChild, other.node.FirstChild, match);
		}

		public void InsertAfter(T existingItem, T newItem)
		{
			node.InsertChildAfter(existingItem, newItem, role);
		}

		public void InsertBefore(T existingItem, T newItem)
		{
			node.InsertChildBefore(existingItem, newItem, role);
		}

		public void AcceptVisitor(IAstVisitor visitor)
		{
			uint index = role.Index;
			AstNode nextSibling;
			for (AstNode astNode = node.FirstChild; astNode != null; astNode = nextSibling)
			{
				nextSibling = astNode.NextSibling;
				if (astNode.RoleIndex == index)
				{
					astNode.AcceptVisitor(visitor);
				}
			}
		}
	}
}
