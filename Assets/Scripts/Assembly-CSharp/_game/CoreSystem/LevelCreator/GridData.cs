using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.LevelCreator
{
	[Serializable]
	[Token(Token = "0x20004B7")]
	public class GridData<TCell> where TCell : class, new()
	{
		[Token(Token = "0x4000FD5")]
		[FieldOffset(Offset = "0x0")]
		public int columns;

		[Token(Token = "0x4000FD6")]
		[FieldOffset(Offset = "0x0")]
		public int rows;

		[Token(Token = "0x4000FD7")]
		[FieldOffset(Offset = "0x0")]
		public float cellSize;

		[Token(Token = "0x4000FD8")]
		[FieldOffset(Offset = "0x0")]
		public float cellHeight;

		[Token(Token = "0x4000FD9")]
		[FieldOffset(Offset = "0x0")]
		public float padding;

		[Token(Token = "0x4000FDA")]
		[FieldOffset(Offset = "0x0")]
		public TCell[] cells;

		[Token(Token = "0x170001B2")]
		public float EffectiveCellHeight
		{
			[Token(Token = "0x60013DC")]
			[Address(RVA = "0x5371134", Offset = "0x5371134", Length = "0x1C")]
			get
			{
				//IL_00ad: Expected F4, but got I
				bool flag = cellHeight < 0f;
				bool flag2 = cellHeight == 0f;
				bool flag3 = cellHeight == cellHeight;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				if (flag5 && flag6)
				{
					int num = 28;
				}
				else
				{
					int num = 24;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (_game.CoreSystem.LevelCreator.GridData`1<TCell>)+v16 @ X8_v2 (System.Int32)]");
				return 0f;
			}
		}

		[Token(Token = "0x170001B3")]
		public float EffectivePadding
		{
			[Token(Token = "0x60013DD")]
			[Address(RVA = "0x5371150", Offset = "0x5371150", Length = "0x1C")]
			get
			{
				float result = padding;
				bool flag = padding < 0f;
				bool flag2 = padding == 0f;
				bool flag3 = padding == padding;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				if (!(flag5 && flag6))
				{
					result = 0.05f;
				}
				return result;
			}
		}

		[Token(Token = "0x170001B4")]
		public float EffectiveCubeSize
		{
			[Token(Token = "0x60013DE")]
			[Address(RVA = "0x537116C", Offset = "0x537116C", Length = "0x28")]
			get
			{
				//IL_00ad: Expected O, but got I4
				//IL_009f: Expected O, but got F4
				float num = padding + padding;
				bool flag = padding < 0f;
				bool flag2 = padding == 0f;
				bool flag3 = padding == padding;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag2;
				object obj = ((!(flag5 && flag6)) ? ((object)1036831949) : ((object)num));
				return cellSize - (float)obj;
			}
		}

		[Token(Token = "0x60013DF")]
		[Address(RVA = "0x5371194", Offset = "0x5371194", Length = "0xC")]
		public int GetIndex(int col, int row)
		{
			int num = columns * row;
			return col + num;
		}

		[Token(Token = "0x60013E0")]
		[Address(RVA = "0x53711A0", Offset = "0x53711A0", Length = "0x34")]
		public bool IsValidCell(int col, int row)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			if ((int)(col & 0x80000000L) == 0)
			{
				int num = (int)(row & 0x80000000L);
				bool flag = num == 0;
				bool flag2 = !flag;
				bool result = false;
				if (!flag2)
				{
					bool flag3 = columns <= col;
					result = false;
					if (!flag3)
					{
						int num2 = rows - row;
						bool flag4 = num2 < 0;
						bool flag5 = num2 == 0;
						int num3 = rows ^ row;
						int num4 = rows ^ num2;
						int num5 = num3 & num4;
						bool flag6 = num5 < 0;
						bool flag7 = flag4 == flag6;
						bool flag8 = !flag5;
						bool flag9 = flag7 && flag8;
						result = flag9;
					}
				}
				return result;
			}
			return false;
		}

		[Token(Token = "0x60013E1")]
		[Address(RVA = "0x53711D4", Offset = "0x53711D4", Length = "0x140")]
		public void EnsureCellsArray()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridData::EnsureCellsArray");
		}

		[Token(Token = "0x60013E2")]
		[Address(RVA = "0x5371314", Offset = "0x5371314", Length = "0xA8")]
		public TCell GetCell(int col, int row)
		{
			//IL_0012: Expected I4, but got I8
			//IL_0056: Expected I4, but got I8
			int num = (int)(col & 0x80000000L);
			bool flag = num == 0;
			bool flag2 = !flag;
			TCell result = null;
			if (!flag2)
			{
				int num2 = (int)(row & 0x80000000L);
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				result = null;
				if (!flag4)
				{
					bool flag5 = columns <= col;
					result = null;
					if (!flag5)
					{
						if (rows > row)
						{
							EnsureCellsArray();
							TCell[] array = cells;
							int num3 = columns * row;
							int num4 = col + num3;
							return array[num4];
						}
						return null;
					}
				}
			}
			return result;
		}

		[Token(Token = "0x60013E3")]
		[Address(RVA = "0x53713BC", Offset = "0x53713BC", Length = "0xA0")]
		public void SetCell(int col, int row, TCell cell)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			if ((int)(col & 0x80000000L) == 0 && (int)(row & 0x80000000L) == 0 && columns > col && rows > row)
			{
				EnsureCellsArray();
				TCell[] array = cells;
				int num = columns * row;
				int num2 = col + num;
				array[num2] = cell;
			}
		}

		[Token(Token = "0x60013E4")]
		[Address(RVA = "0x537145C", Offset = "0x537145C", Length = "0x208")]
		public void Resize(int newColumns, int newRows)
		{
			bool flag;
			if (columns == newColumns)
			{
				int num = rows - newRows;
				flag = num == 0;
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				return;
			}
			TCell[] array = cells;
			columns = newColumns;
			rows = newRows;
			int num2 = newRows * newColumns;
			TCell[] array2 = null;
			cells = array2;
			TCell[] array3 = cells;
			int num3 = 0;
			int num4 = 32;
			while (num3 < array3.Length)
			{
				object obj = Activator.CreateInstance<object>();
				num3++;
				array3 = cells;
				num4 += 8;
				if (cells == null)
				{
					throw new NullReferenceException();
				}
			}
			if (cells == null)
			{
				return;
			}
			int num5 = Math.Min(columns, newColumns);
			int num6 = Math.Min(rows, newRows);
			if (num6 < 1 || num5 < 1)
			{
				return;
			}
			int num7 = 0;
			int num8 = 0;
			int num9 = 0;
			do
			{
				int num10 = num8;
				int num11 = num9;
				int num12 = num5;
				bool flag2;
				do
				{
					if (num10 < array.Length && array[num10] != null)
					{
						TCell[] array4 = cells;
						array4[num11] = array[num10];
					}
					num11++;
					num10++;
					flag2 = num12 == 1;
					num12--;
				}
				while (!flag2);
				num7++;
				num9 += newColumns;
				num8 += columns;
			}
			while (num7 != num6);
		}

		[Token(Token = "0x60013E5")]
		[Address(RVA = "0x5371664", Offset = "0x5371664", Length = "0x20")]
		public GridData()
		{
			cellSize = 0.85f;
			padding = 0.05f;
		}
	}
}
