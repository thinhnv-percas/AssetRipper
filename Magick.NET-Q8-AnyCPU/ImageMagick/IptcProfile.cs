using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace ImageMagick;

public sealed class IptcProfile : ImageProfile
{
	private Collection<IptcValue> _values;

	public IEnumerable<IptcValue> Values
	{
		get
		{
			Initialize();
			return _values;
		}
	}

	public IptcProfile()
		: base("iptc")
	{
	}

	public IptcProfile(byte[] data)
		: base("iptc", data)
	{
	}

	public IptcProfile(string fileName)
		: base("iptc", fileName)
	{
	}

	public IptcProfile(Stream stream)
		: base("iptc", stream)
	{
	}

	public IptcValue GetValue(IptcTag tag)
	{
		foreach (IptcValue value in Values)
		{
			if (value.Tag == tag)
			{
				return value;
			}
		}
		return null;
	}

	public bool RemoveValue(IptcTag tag)
	{
		Initialize();
		for (int i = 0; i < _values.Count; i++)
		{
			if (_values[i].Tag == tag)
			{
				_values.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public void SetEncoding(Encoding encoding)
	{
		Throw.IfNull("encoding", encoding);
		foreach (IptcValue value in Values)
		{
			value.Encoding = encoding;
		}
	}

	public void SetValue(IptcTag tag, Encoding encoding, string value)
	{
		Throw.IfNull("encoding", encoding);
		foreach (IptcValue value2 in Values)
		{
			if (value2.Tag == tag)
			{
				value2.Encoding = encoding;
				value2.Value = value;
				return;
			}
		}
		_values.Add(new IptcValue(tag, encoding, value));
	}

	public void SetValue(IptcTag tag, string value)
	{
		SetValue(tag, Encoding.UTF8, value);
	}

	protected override void UpdateData()
	{
		int num = 0;
		foreach (IptcValue value in Values)
		{
			num += value.Length + 5;
		}
		base.Data = new byte[num];
		int num2 = 0;
		foreach (IptcValue value2 in Values)
		{
			base.Data[num2++] = 28;
			base.Data[num2++] = 2;
			base.Data[num2++] = (byte)value2.Tag;
			base.Data[num2++] = (byte)(value2.Length >> 8);
			base.Data[num2++] = (byte)value2.Length;
			if (value2.Length > 0)
			{
				Buffer.BlockCopy(value2.ToByteArray(), 0, base.Data, num2, value2.Length);
				num2 += value2.Length;
			}
		}
	}

	private void Initialize()
	{
		if (_values != null)
		{
			return;
		}
		_values = new Collection<IptcValue>();
		if (base.Data == null || base.Data[0] != 28)
		{
			return;
		}
		int num = 0;
		while (num + 4 < base.Data.Length)
		{
			if (base.Data[num++] == 28)
			{
				num++;
				IptcTag tag = (IptcTag)base.Data[num++];
				short num2 = ByteConverter.ToShort(base.Data, ref num);
				byte[] array = new byte[num2];
				if (num2 > 0 && num + num2 <= base.Data.Length)
				{
					Buffer.BlockCopy(base.Data, num, array, 0, num2);
				}
				_values.Add(new IptcValue(tag, array));
				num += num2;
			}
		}
	}
}
