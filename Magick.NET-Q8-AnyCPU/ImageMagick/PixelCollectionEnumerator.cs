using System;
using System.Collections;
using System.Collections.Generic;

namespace ImageMagick;

internal sealed class PixelCollectionEnumerator : IEnumerator<Pixel>, IDisposable, IEnumerator
{
	private readonly PixelCollection _collection;

	private readonly int _height;

	private readonly int _width;

	private byte[] _row;

	private int _x;

	private int _y;

	object IEnumerator.Current => Current;

	public Pixel Current
	{
		get
		{
			if (_x == -1)
			{
				return null;
			}
			byte[] array = new byte[_collection.Channels];
			Array.Copy(_row, _x * _collection.Channels, array, 0, _collection.Channels);
			return Pixel.Create(_collection, _x, _y, array);
		}
	}

	public PixelCollectionEnumerator(PixelCollection collection, int width, int height)
	{
		_collection = collection;
		_width = width;
		_height = height;
		Reset();
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		if (++_x == _width)
		{
			_x = 0;
			_y++;
			SetRow();
		}
		if (_y < _height)
		{
			return true;
		}
		_x = _width - 1;
		_y = _height - 1;
		return false;
	}

	public void Reset()
	{
		_x = -1;
		_y = 0;
		SetRow();
	}

	private void SetRow()
	{
		if (_y < _height)
		{
			_row = _collection.GetAreaUnchecked(0, _y, _width, 1);
		}
	}
}
