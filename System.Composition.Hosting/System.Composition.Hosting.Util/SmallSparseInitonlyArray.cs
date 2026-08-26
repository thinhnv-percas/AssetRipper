using Microsoft.Internal;

namespace System.Composition.Hosting.Util;

internal class SmallSparseInitonlyArray
{
	private class Element
	{
		public int Index;

		public object Value;
	}

	private const int ElementsCapacity = 128;

	private const int ElementIndexMask = 127;

	private const int LocalOffsetMax = 3;

	private Element[] _elements;

	private SmallSparseInitonlyArray _overflow;

	public void Add(int index, object value)
	{
		if (_elements == null)
		{
			_elements = new Element[128];
		}
		Element element = new Element
		{
			Index = index,
			Value = value
		};
		int num = index & 0x7F;
		Element element2 = _elements[num];
		if (element2 == null)
		{
			_elements[num] = element;
			return;
		}
		Microsoft.Internal.Assumes.IsTrue(element2.Index != index, "An item with the key '{0}' has already been added.", index);
		for (int i = 1; i <= 3; i++)
		{
			int num2 = (index + i) & 0x7F;
			element2 = _elements[num2];
			if (element2 == null)
			{
				_elements[num2] = element;
				return;
			}
			Microsoft.Internal.Assumes.IsTrue(element2.Index != index, "An item with the key '{0}' has already been added.", index);
		}
		if (_overflow == null)
		{
			_overflow = new SmallSparseInitonlyArray();
		}
		_overflow.Add(index, value);
	}

	public bool TryGetValue(int index, out object value)
	{
		if (_elements == null)
		{
			value = null;
			return false;
		}
		int num = index & 0x7F;
		Element element = _elements[num];
		if (element != null && element.Index == index)
		{
			value = element.Value;
			return true;
		}
		for (int i = 1; i <= 3; i++)
		{
			element = _elements[(index + i) & 0x7F];
			if (element == null)
			{
				value = null;
				return false;
			}
			if (element.Index == index)
			{
				value = element.Value;
				return true;
			}
		}
		if (_overflow != null)
		{
			return _overflow.TryGetValue(index, out value);
		}
		value = null;
		return false;
	}
}
