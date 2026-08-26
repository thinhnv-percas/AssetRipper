using System;
using System.Collections.Generic;
using dnlib.Utils;

namespace dnlib.DotNet;

public class CustomAttributeCollection : LazyList<CustomAttribute, object>
{
	public CustomAttributeCollection()
	{
	}

	public CustomAttributeCollection(int length, object context, Func<object, int, CustomAttribute> readOriginalValue)
		: base(length, context, readOriginalValue)
	{
	}

	public bool IsDefined(string fullName)
	{
		return Find(fullName) != null;
	}

	public void RemoveAll(string fullName)
	{
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].TypeFullName == fullName)
			{
				RemoveAt(num);
			}
		}
	}

	public CustomAttribute Find(string fullName)
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CustomAttribute current = enumerator.Current;
				if (current != null && current.TypeFullName == fullName)
				{
					return current;
				}
			}
		}
		return null;
	}

	public IEnumerable<CustomAttribute> FindAll(string fullName)
	{
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			CustomAttribute ca = enumerator.Current;
			if (ca != null && ca.TypeFullName == fullName)
			{
				yield return ca;
			}
		}
	}

	public CustomAttribute Find(IType attrType)
	{
		return Find(attrType, (SigComparerOptions)0u);
	}

	public CustomAttribute Find(IType attrType, SigComparerOptions options)
	{
		SigComparer sigComparer = new SigComparer(options);
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CustomAttribute current = enumerator.Current;
				if (sigComparer.Equals(current.AttributeType, attrType))
				{
					return current;
				}
			}
		}
		return null;
	}

	public IEnumerable<CustomAttribute> FindAll(IType attrType)
	{
		return FindAll(attrType, (SigComparerOptions)0u);
	}

	public IEnumerable<CustomAttribute> FindAll(IType attrType, SigComparerOptions options)
	{
		SigComparer comparer = new SigComparer(options);
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			CustomAttribute ca = enumerator.Current;
			if (comparer.Equals(ca.AttributeType, attrType))
			{
				yield return ca;
			}
		}
	}
}
