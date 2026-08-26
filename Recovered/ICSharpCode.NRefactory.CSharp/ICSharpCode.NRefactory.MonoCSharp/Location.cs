using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public struct Location : IEquatable<Location>
	{
		private struct Checkpoint
		{
			public readonly int LineOffset;

			public readonly int File;

			public Checkpoint(int file, int line)
			{
				File = file;
				LineOffset = line - line % 16777216;
			}
		}

		private readonly long token;

		private const int column_bits = 24;

		private const int line_delta_bits = 24;

		private const int checkpoint_bits = 16;

		private const int column_mask = 16777215;

		private const int max_column = 16777215;

		private static List<SourceFile> source_list;

		private static Checkpoint[] checkpoints;

		private static int checkpoint_index;

		public static readonly Location Null;

		public static bool InEmacs;

		public bool IsNull => token == 0;

		public string Name
		{
			get
			{
				int file = File;
				if (token == 0L || file <= 0)
				{
					return null;
				}
				return source_list[file - 1].Name;
			}
		}

		public string NameFullPath
		{
			get
			{
				int file = File;
				if (token == 0L || file <= 0)
				{
					return null;
				}
				return source_list[file - 1].FullPathName;
			}
		}

		private int CheckpointIndex => (int)(token >> 48) & 0xFFFF;

		public int Row
		{
			get
			{
				if (token == 0L)
				{
					return 1;
				}
				return checkpoints[CheckpointIndex].LineOffset + ((int)(token >> 24) & 0xFFFFFF);
			}
		}

		public int Column
		{
			get
			{
				if (token == 0L)
				{
					return 1;
				}
				return (int)(token & 0xFFFFFF);
			}
		}

		public int File
		{
			get
			{
				if (token == 0L)
				{
					return 0;
				}
				if (checkpoints.Length <= CheckpointIndex)
				{
					throw new Exception($"Should not happen. Token is {token:X04}, checkpoints are {checkpoints.Length}, index is {CheckpointIndex}");
				}
				return checkpoints[CheckpointIndex].File;
			}
		}

		public SourceFile SourceFile
		{
			get
			{
				int file = File;
				if (file == 0)
				{
					return null;
				}
				return source_list[file - 1];
			}
		}

		static Location()
		{
			Reset();
		}

		public static void Reset()
		{
			source_list = new List<SourceFile>();
			checkpoint_index = 0;
		}

		public static void AddFile(SourceFile file)
		{
			source_list.Add(file);
		}

		public static void Initialize(List<SourceFile> files)
		{
			source_list.AddRange(files);
			checkpoints = new Checkpoint[Math.Max(1, source_list.Count * 2)];
			if (checkpoints.Length != 0)
			{
				checkpoints[0] = new Checkpoint(0, 0);
			}
		}

		public Location(SourceFile file, int row, int column)
		{
			if (row <= 0)
			{
				token = 0L;
				return;
			}
			if (column > 16777215)
			{
				column = 16777215;
			}
			long num = -1L;
			long num2 = 0L;
			int num3 = file?.Index ?? 0;
			int num4 = (checkpoint_index < 10) ? checkpoint_index : 10;
			for (int i = 0; i < num4; i++)
			{
				int lineOffset = checkpoints[checkpoint_index - i].LineOffset;
				num2 = row - lineOffset;
				if (num2 >= 0 && num2 < 16777216 && checkpoints[checkpoint_index - i].File == num3)
				{
					num = checkpoint_index - i;
					break;
				}
			}
			if (num == -1)
			{
				AddCheckpoint(num3, row);
				num = checkpoint_index;
				num2 = row % 16777216;
			}
			long num5 = token = column + (num2 << 24) + (num << 48);
		}

		public static Location operator -(Location loc, int columns)
		{
			return new Location(loc.SourceFile, loc.Row, loc.Column - columns);
		}

		private static void AddCheckpoint(int file, int row)
		{
			if (checkpoints.Length == ++checkpoint_index)
			{
				Array.Resize(ref checkpoints, checkpoint_index * 2);
			}
			checkpoints[checkpoint_index] = new Checkpoint(file, row);
		}

		private string FormatLocation(string fileName)
		{
			if (InEmacs)
			{
				return fileName + "(" + Row.ToString() + "):";
			}
			return fileName + "(" + Row.ToString() + "," + Column.ToString() + ((Column == 16777215) ? "+):" : "):");
		}

		public override string ToString()
		{
			return FormatLocation(Name);
		}

		public string ToStringFullName()
		{
			return FormatLocation(NameFullPath);
		}

		public bool Equals(Location other)
		{
			return token == other.token;
		}
	}
}
