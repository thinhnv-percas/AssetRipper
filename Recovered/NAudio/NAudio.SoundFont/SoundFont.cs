using System.IO;

namespace NAudio.SoundFont
{
	public class SoundFont
	{
		private InfoChunk info;

		private PresetsChunk presetsChunk;

		private SampleDataChunk sampleData;

		public InfoChunk FileInfo => info;

		public Preset[] Presets => presetsChunk.Presets;

		public Instrument[] Instruments => presetsChunk.Instruments;

		public SampleHeader[] SampleHeaders => presetsChunk.SampleHeaders;

		public byte[] SampleData => sampleData.SampleData;

		public SoundFont(string fileName)
			: this(new FileStream(fileName, FileMode.Open, FileAccess.Read))
		{
		}

		public SoundFont(Stream sfFile)
		{
			using (sfFile)
			{
				RiffChunk topLevelChunk = RiffChunk.GetTopLevelChunk(new BinaryReader(sfFile));
				if (!(topLevelChunk.ChunkID == "RIFF"))
				{
					throw new InvalidDataException("Not a RIFF file");
				}
				string text = topLevelChunk.ReadChunkID();
				if (text != "sfbk")
				{
					throw new InvalidDataException($"Not a SoundFont ({text})");
				}
				RiffChunk nextSubChunk = topLevelChunk.GetNextSubChunk();
				if (!(nextSubChunk.ChunkID == "LIST"))
				{
					throw new InvalidDataException($"Not info list found ({nextSubChunk.ChunkID})");
				}
				info = new InfoChunk(nextSubChunk);
				RiffChunk nextSubChunk2 = topLevelChunk.GetNextSubChunk();
				sampleData = new SampleDataChunk(nextSubChunk2);
				nextSubChunk2 = topLevelChunk.GetNextSubChunk();
				presetsChunk = new PresetsChunk(nextSubChunk2);
			}
		}

		public override string ToString()
		{
			return $"Info Chunk:\r\n{info}\r\nPresets Chunk:\r\n{presetsChunk}";
		}
	}
}
