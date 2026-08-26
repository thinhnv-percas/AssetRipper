using System.Threading;

namespace System.Diagnostics.Tracing;

public class EventCounter
{
	private readonly string _name;

	private readonly EventCounterGroup _group;

	private const int BufferedSize = 10;

	private const float UnusedBufferSlotValue = float.NegativeInfinity;

	private const int UnsetIndex = -1;

	private volatile float[] _bufferedValues;

	private volatile int _bufferedValuesIndex;

	private int _count;

	private float _sum;

	private float _sumSquared;

	private float _min;

	private float _max;

	private object MyLock => _bufferedValues;

	public EventCounter(string name, EventSource eventSource)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (eventSource == null)
		{
			throw new ArgumentNullException("eventSource");
		}
		InitializeBuffer();
		_name = name;
		_group = EventCounterGroup.GetEventCounterGroup(eventSource);
		_group.Add(this);
	}

	public void WriteMetric(float value)
	{
		Enqueue(value);
	}

	public override string ToString()
	{
		return "EventCounter '" + _name + "' Count " + _count + " Mean " + ((double)_sum / (double)_count).ToString("n3");
	}

	private void InitializeBuffer()
	{
		_bufferedValues = new float[10];
		for (int i = 0; i < _bufferedValues.Length; i++)
		{
			_bufferedValues[i] = float.NegativeInfinity;
		}
	}

	private void Enqueue(float value)
	{
		int num = _bufferedValuesIndex;
		float num2;
		do
		{
			num2 = Interlocked.CompareExchange(ref _bufferedValues[num], value, float.NegativeInfinity);
			num++;
			if (_bufferedValues.Length <= num)
			{
				lock (MyLock)
				{
					Flush();
				}
				num = 0;
			}
		}
		while (num2 != float.NegativeInfinity);
		_bufferedValuesIndex = num;
	}

	private void Flush()
	{
		for (int i = 0; i < _bufferedValues.Length; i++)
		{
			float num = Interlocked.Exchange(ref _bufferedValues[i], float.NegativeInfinity);
			if (num != float.NegativeInfinity)
			{
				OnMetricWritten(num);
			}
		}
		_bufferedValuesIndex = 0;
	}

	private void OnMetricWritten(float value)
	{
		_sum += value;
		_sumSquared += value * value;
		if (_count == 0 || value > _max)
		{
			_max = value;
		}
		if (_count == 0 || value < _min)
		{
			_min = value;
		}
		_count++;
	}

	internal EventCounterPayload GetEventCounterPayload()
	{
		lock (MyLock)
		{
			Flush();
			EventCounterPayload eventCounterPayload = new EventCounterPayload();
			eventCounterPayload.Name = _name;
			eventCounterPayload.Count = _count;
			eventCounterPayload.Mean = _sum / (float)_count;
			eventCounterPayload.StandardDeviation = (float)Math.Sqrt(_sumSquared / (float)_count - _sum * _sum / (float)_count / (float)_count);
			eventCounterPayload.Min = _min;
			eventCounterPayload.Max = _max;
			ResetStatistics();
			return eventCounterPayload;
		}
	}

	private void ResetStatistics()
	{
		_count = 0;
		_sum = 0f;
		_sumSquared = 0f;
		_min = 0f;
		_max = 0f;
	}
}
