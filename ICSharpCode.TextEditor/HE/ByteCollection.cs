using System.Collections;

namespace HE;

internal class ByteCollection : CollectionBase
{
	internal byte this[int index]
	{
		get
		{
			return (byte)base.List[index];
		}
		set
		{
			base.List[index] = value;
		}
	}

	internal ByteCollection()
	{
	}

	internal ByteCollection(byte[] bs)
	{
		AddRange(bs);
	}

	internal void Add(byte b)
	{
		base.List.Add(b);
	}

	internal void AddRange(byte[] bs)
	{
		base.InnerList.AddRange(bs);
	}

	internal void Remove(byte b)
	{
		base.List.Remove(b);
	}

	internal void RemoveRange(int index, int count)
	{
		base.InnerList.RemoveRange(index, count);
	}

	internal void InsertRange(int index, byte[] bs)
	{
		base.InnerList.InsertRange(index, bs);
	}

	internal byte[] GetBytes()
	{
		byte[] array = new byte[base.Count];
		base.InnerList.CopyTo(0, array, 0, array.Length);
		return array;
	}

	internal void Insert(int index, byte b)
	{
		base.InnerList.Insert(index, b);
	}

	internal int IndexOf(byte b)
	{
		return base.InnerList.IndexOf(b);
	}

	internal bool Contains(byte b)
	{
		return base.InnerList.Contains(b);
	}

	internal void CopyTo(byte[] bs, int index)
	{
		base.InnerList.CopyTo(bs, index);
	}

	internal byte[] ToArray()
	{
		byte[] array = new byte[base.Count];
		CopyTo(array, 0);
		return array;
	}
}
