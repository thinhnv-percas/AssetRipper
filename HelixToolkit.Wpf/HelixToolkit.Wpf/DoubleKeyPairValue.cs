namespace HelixToolkit.Wpf;

public class DoubleKeyPairValue<K, T, V>
{
	public K Key1 { get; set; }

	public T Key2 { get; set; }

	public V Value { get; set; }

	public DoubleKeyPairValue(K key1, T key2, V value)
	{
		Key1 = key1;
		Key2 = key2;
		Value = value;
	}

	public override string ToString()
	{
		return string.Concat(Key1, " - ", Key2, " - ", Value);
	}
}
