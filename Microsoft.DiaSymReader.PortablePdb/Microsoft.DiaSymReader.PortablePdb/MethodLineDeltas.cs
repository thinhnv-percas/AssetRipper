using System;
using System.Collections.Immutable;

namespace Microsoft.DiaSymReader.PortablePdb;

internal struct MethodLineDeltas
{
	private readonly int _delta;

	private readonly ImmutableArray<int> _deltas;

	public bool IsDefault => _deltas.IsDefault;

	public MethodLineDeltas(int delta, ImmutableArray<int> deltas)
	{
		_deltas = deltas;
		_delta = delta;
	}

	public MethodLineDeltas Merge(MethodLineDeltas other)
	{
		int initialCapacity = Math.Max(_deltas.Length, other._deltas.Length);
		int num = Math.Min(_deltas.Length, other._deltas.Length);
		ImmutableArray<int>.Builder builder = ImmutableArray.CreateBuilder<int>(initialCapacity);
		for (int i = 0; i < num; i++)
		{
			builder.Add(_deltas[i] + other._deltas[i]);
		}
		builder.AddSubRange(_deltas, num);
		builder.AddSubRange(other._deltas, num);
		return new MethodLineDeltas(_delta + other._delta, builder.MoveToImmutable());
	}

	public int GetDeltaForSequencePoint(int index)
	{
		return _delta + ((!_deltas.IsDefault && index < _deltas.Length) ? _deltas[index] : 0);
	}
}
