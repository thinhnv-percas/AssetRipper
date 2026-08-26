using NAudio.Wave.Asio;
using System;

namespace NAudio.Wave
{
	public class AsioAudioAvailableEventArgs : EventArgs
	{
		public IntPtr[] InputBuffers
		{
			get;
			private set;
		}

		public IntPtr[] OutputBuffers
		{
			get;
			private set;
		}

		public bool WrittenToOutputBuffers
		{
			get;
			set;
		}

		public int SamplesPerBuffer
		{
			get;
			private set;
		}

		public AsioSampleType AsioSampleType
		{
			get;
			private set;
		}

		public AsioAudioAvailableEventArgs(IntPtr[] inputBuffers, IntPtr[] outputBuffers, int samplesPerBuffer, AsioSampleType asioSampleType)
		{
			InputBuffers = inputBuffers;
			OutputBuffers = outputBuffers;
			SamplesPerBuffer = samplesPerBuffer;
			AsioSampleType = asioSampleType;
		}

		public unsafe int GetAsInterleavedSamples(float[] samples)
		{
			int num = InputBuffers.Length;
			if (samples.Length < SamplesPerBuffer * num)
			{
				throw new ArgumentException("Buffer not big enough");
			}
			int num2 = 0;
			if (AsioSampleType == AsioSampleType.Int32LSB)
			{
				for (int i = 0; i < SamplesPerBuffer; i++)
				{
					for (int j = 0; j < num; j++)
					{
						samples[num2++] = (float)(*(int*)((byte*)(void*)InputBuffers[j] + (long)i * 4L)) / 2.14748365E+09f;
					}
				}
			}
			else if (AsioSampleType == AsioSampleType.Int16LSB)
			{
				for (int k = 0; k < SamplesPerBuffer; k++)
				{
					for (int l = 0; l < num; l++)
					{
						samples[num2++] = (float)(*(short*)((byte*)(void*)InputBuffers[l] + (long)k * 2L)) / 32767f;
					}
				}
			}
			else if (AsioSampleType == AsioSampleType.Int24LSB)
			{
				for (int m = 0; m < SamplesPerBuffer; m++)
				{
					for (int n = 0; n < num; n++)
					{
						byte* ptr = (byte*)(void*)InputBuffers[n] + m * 3;
						int num5 = *ptr | (ptr[1] << 8) | ((sbyte)ptr[2] << 16);
						samples[num2++] = (float)num5 / 8388608f;
					}
				}
			}
			else
			{
				if (AsioSampleType != AsioSampleType.Float32LSB)
				{
					throw new NotImplementedException($"ASIO Sample Type {AsioSampleType} not supported");
				}
				for (int num7 = 0; num7 < SamplesPerBuffer; num7++)
				{
					for (int num8 = 0; num8 < num; num8++)
					{
						samples[num2++] = *(float*)((byte*)(void*)InputBuffers[num8] + (long)num7 * 4L);
					}
				}
			}
			return SamplesPerBuffer * num;
		}

		[Obsolete("Better performance if you use the overload that takes an array, and reuse the same one")]
		public float[] GetAsInterleavedSamples()
		{
			int num = InputBuffers.Length;
			float[] array = new float[SamplesPerBuffer * num];
			GetAsInterleavedSamples(array);
			return array;
		}
	}
}
