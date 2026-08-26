using System.Globalization;
using System.Text;

namespace ImageMagick;

internal sealed class ClipPathReader
{
	private readonly int _height;

	private readonly int _width;

	private PointD[] _first;

	private int _index;

	private bool _inSubpath;

	private StringBuilder _path;

	private int _knotCount;

	private PointD[] _last;

	public ClipPathReader(int width, int height)
	{
		_width = width;
		_height = height;
	}

	public string Read(byte[] data, int offset, int length)
	{
		Reset(offset);
		while (_index < offset + length)
		{
			switch (ByteConverter.ToShort(data, ref _index))
			{
			case 0:
			case 3:
				SetKnotCount(data);
				break;
			case 1:
			case 2:
			case 4:
			case 5:
				AddPath(data);
				break;
			default:
				_index += 24;
				break;
			}
		}
		return _path.ToString();
	}

	private void AddPath(byte[] data)
	{
		if (_knotCount == 0)
		{
			_index += 24;
			return;
		}
		PointD[] array = CreatePoint(data);
		if (!_inSubpath)
		{
			_path.AppendFormat(CultureInfo.InvariantCulture, "M {0:0.###} {1:0.###}\n", new object[2]
			{
				array[1].X,
				array[1].Y
			});
			for (int i = 0; i < 3; i++)
			{
				_first[i] = array[i];
				_last[i] = array[i];
			}
		}
		else
		{
			if (_last[1].X == _last[2].X && _last[1].Y == _last[2].Y && array[0].X == array[1].X && array[0].Y == array[1].Y)
			{
				_path.AppendFormat(CultureInfo.InvariantCulture, "L {0:0.###} {1:0.###}\n", new object[2]
				{
					array[1].X,
					array[1].Y
				});
			}
			else
			{
				_path.AppendFormat(CultureInfo.InvariantCulture, "C {0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###}\n", _last[2].X, _last[2].Y, array[0].X, array[0].Y, array[1].X, array[1].Y);
			}
			for (int j = 0; j < 3; j++)
			{
				_last[j] = array[j];
			}
		}
		_inSubpath = true;
		_knotCount--;
		if (_knotCount == 0)
		{
			ClosePath();
			_inSubpath = false;
		}
	}

	private void ClosePath()
	{
		if (_last[1].X == _last[2].X && _last[1].Y == _last[2].Y && _first[0].X == _first[1].X && _first[0].Y == _first[1].Y)
		{
			_path.AppendFormat(CultureInfo.InvariantCulture, "L {0:0.###} {1:0.###} Z\n", new object[2]
			{
				_first[1].X,
				_first[1].Y
			});
			return;
		}
		_path.AppendFormat(CultureInfo.InvariantCulture, "C {0:0.###} {1:0.###} {2:0.###} {3:0.###} {4:0.###} {5:0.###} Z\n", _last[2].X, _last[2].Y, _first[0].X, _first[0].Y, _first[1].X, _first[1].Y);
	}

	private PointD[] CreatePoint(byte[] data)
	{
		PointD[] array = new PointD[3];
		for (int i = 0; i < 3; i++)
		{
			uint num = (uint)ByteConverter.ToUInt(data, ref _index);
			int num2 = (int)num;
			if (num > int.MaxValue)
			{
				num2 = (int)num - -1 - 1;
			}
			uint num3 = (uint)ByteConverter.ToUInt(data, ref _index);
			int num4 = (int)num3;
			if (num3 > int.MaxValue)
			{
				num4 = (int)num3 - -1 - 1;
			}
			array[i] = new PointD((double)num4 * (double)_width / 4096.0 / 4096.0, (double)num2 * (double)_height / 4096.0 / 4096.0);
		}
		return array;
	}

	private void Reset(int offset)
	{
		_index = offset;
		_knotCount = 0;
		_inSubpath = false;
		_path = new StringBuilder();
		_first = new PointD[3];
		_last = new PointD[3];
	}

	private void SetKnotCount(byte[] data)
	{
		if (_knotCount != 0)
		{
			_index += 24;
			return;
		}
		_knotCount = ByteConverter.ToShort(data, ref _index);
		_index += 22;
	}
}
