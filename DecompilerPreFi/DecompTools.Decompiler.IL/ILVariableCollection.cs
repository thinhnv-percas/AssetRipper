#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.IL;

public class ILVariableCollection : ICollection<ILVariable>, IEnumerable<ILVariable>, IEnumerable, IReadOnlyList<ILVariable>, IReadOnlyCollection<ILVariable>
{
	private readonly ILFunction scope;

	private readonly List<ILVariable> list = new List<ILVariable>();

	public ILVariable this[int index] => list[index];

	public int Count => list.Count;

	bool ICollection<ILVariable>.IsReadOnly => false;

	internal ILVariableCollection(ILFunction scope)
	{
		this.scope = scope;
	}

	public bool Add(ILVariable item)
	{
		if (item.Function != null)
		{
			if (item.Function == scope)
			{
				return false;
			}
			throw new ArgumentException("Variable already belongs to another scope");
		}
		item.Function = scope;
		item.IndexInFunction = list.Count;
		list.Add(item);
		return true;
	}

	void ICollection<ILVariable>.Add(ILVariable item)
	{
		Add(item);
	}

	public void Clear()
	{
		foreach (ILVariable item in list)
		{
			item.Function = null;
		}
		list.Clear();
	}

	public bool Contains(ILVariable item)
	{
		Debug.Assert(item.Function != scope || list[item.IndexInFunction] == item);
		return item.Function == scope;
	}

	public bool Remove(ILVariable item)
	{
		if (item.Function != scope)
		{
			return false;
		}
		Debug.Assert(list[item.IndexInFunction] == item);
		RemoveAt(item.IndexInFunction);
		return true;
	}

	private void RemoveAt(int index)
	{
		list[index].Function = null;
		checked
		{
			list[index] = list[list.Count - 1];
			list[index].IndexInFunction = index;
			list.RemoveAt(list.Count - 1);
		}
	}

	public void RemoveDead()
	{
		int num = 0;
		while (num < list.Count)
		{
			ILVariable iLVariable = list[num];
			int num2 = (iLVariable.HasInitialValue ? 1 : 0);
			if (iLVariable.StoreCount == num2 && iLVariable.LoadCount == 0 && iLVariable.AddressCount == 0 && iLVariable.Kind != VariableKind.DisplayClassLocal)
			{
				RemoveAt(num);
			}
			else
			{
				num = checked(num + 1);
			}
		}
	}

	public void CopyTo(ILVariable[] array, int arrayIndex)
	{
		list.CopyTo(array, arrayIndex);
	}

	public List<ILVariable>.Enumerator GetEnumerator()
	{
		return list.GetEnumerator();
	}

	IEnumerator<ILVariable> IEnumerable<ILVariable>.GetEnumerator()
	{
		return GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
