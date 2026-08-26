using System;
using System.Collections.Generic;
using dnlib.DotNet.Pdb.Symbols;
using dnlib.IO;

namespace dnlib.DotNet.Pdb.Managed;

internal sealed class DbiModule
{
	private uint cbSyms;

	private uint cbOldLines;

	private uint cbLines;

	public ushort StreamId { get; private set; }

	public string ModuleName { get; private set; }

	public string ObjectName { get; private set; }

	public List<DbiFunction> Functions { get; private set; }

	public List<DbiDocument> Documents { get; private set; }

	public DbiModule()
	{
		Functions = new List<DbiFunction>();
		Documents = new List<DbiDocument>();
	}

	public void Read(ref DataReader reader)
	{
		reader.Position += 34u;
		StreamId = reader.ReadUInt16();
		cbSyms = reader.ReadUInt32();
		cbOldLines = reader.ReadUInt32();
		cbLines = reader.ReadUInt32();
		reader.Position += 16u;
		if ((int)cbSyms < 0)
		{
			cbSyms = 0u;
		}
		if ((int)cbOldLines < 0)
		{
			cbOldLines = 0u;
		}
		if ((int)cbLines < 0)
		{
			cbLines = 0u;
		}
		ModuleName = PdbReader.ReadCString(ref reader);
		ObjectName = PdbReader.ReadCString(ref reader);
		reader.Position = (reader.Position + 3) & 0xFFFFFFFCu;
	}

	public void LoadFunctions(PdbReader pdbReader, ref DataReader reader)
	{
		reader.Position = 0u;
		ReadFunctions(reader.Slice(reader.Position, cbSyms));
		if (Functions.Count > 0)
		{
			reader.Position += cbSyms + cbOldLines;
			ReadLines(pdbReader, reader.Slice(reader.Position, cbLines));
		}
	}

	private void ReadFunctions(DataReader reader)
	{
		if (reader.ReadUInt32() != 4)
		{
			throw new PdbException("Invalid signature");
		}
		while (reader.Position < reader.Length)
		{
			ushort num = reader.ReadUInt16();
			uint position = reader.Position;
			uint num2 = position + num;
			SymbolType symbolType = (SymbolType)reader.ReadUInt16();
			SymbolType symbolType2 = symbolType;
			if (symbolType2 - 4394 <= SymbolType.S_COMPILE)
			{
				DbiFunction dbiFunction = new DbiFunction();
				dbiFunction.Read(ref reader, num2);
				Functions.Add(dbiFunction);
			}
			else
			{
				reader.Position = num2;
			}
		}
	}

	private void ReadLines(PdbReader pdbReader, DataReader reader)
	{
		Dictionary<uint, DbiDocument> documents = new Dictionary<uint, DbiDocument>();
		reader.Position = 0u;
		while (reader.Position < reader.Length)
		{
			ModuleStreamType moduleStreamType = (ModuleStreamType)reader.ReadUInt32();
			uint num = reader.ReadUInt32();
			uint position = reader.Position;
			uint num2 = (position + num + 3) & 0xFFFFFFFCu;
			if (moduleStreamType == ModuleStreamType.FileInfo)
			{
				ReadFiles(pdbReader, documents, ref reader, num2);
			}
			reader.Position = num2;
		}
		DbiFunction[] array = new DbiFunction[Functions.Count];
		Functions.CopyTo(array, 0);
		Array.Sort(array, (DbiFunction a, DbiFunction b) => a.Address.CompareTo(b.Address));
		reader.Position = 0u;
		while (reader.Position < reader.Length)
		{
			ModuleStreamType moduleStreamType2 = (ModuleStreamType)reader.ReadUInt32();
			uint num3 = reader.ReadUInt32();
			uint position2 = reader.Position;
			uint num4 = position2 + num3;
			if (moduleStreamType2 == ModuleStreamType.Lines)
			{
				ReadLines(array, documents, ref reader, num4);
			}
			reader.Position = num4;
		}
	}

	private void ReadFiles(PdbReader pdbReader, Dictionary<uint, DbiDocument> documents, ref DataReader reader, uint end)
	{
		uint position = reader.Position;
		while (reader.Position < end)
		{
			uint key = reader.Position - position;
			uint nameId = reader.ReadUInt32();
			byte b = reader.ReadByte();
			reader.ReadByte();
			DbiDocument document = pdbReader.GetDocument(nameId);
			documents.Add(key, document);
			reader.Position += b;
			reader.Position = (reader.Position + 3) & 0xFFFFFFFCu;
		}
	}

	private void ReadLines(DbiFunction[] funcs, Dictionary<uint, DbiDocument> documents, ref DataReader reader, uint end)
	{
		PdbAddress pdbAddress = PdbAddress.ReadAddress(ref reader);
		int num = 0;
		int num2 = funcs.Length - 1;
		int i = -1;
		while (num <= num2)
		{
			int num3 = num + (num2 - num >> 1);
			PdbAddress address = funcs[num3].Address;
			if (address < pdbAddress)
			{
				num = num3 + 1;
				continue;
			}
			if (address > pdbAddress)
			{
				num2 = num3 - 1;
				continue;
			}
			i = num3;
			break;
		}
		if (i == -1)
		{
			return;
		}
		ushort num4 = reader.ReadUInt16();
		reader.Position += 4u;
		if (funcs[i].Lines == null)
		{
			while (i > 0)
			{
				DbiFunction dbiFunction = funcs[i - 1];
				if (dbiFunction != null || dbiFunction.Address != pdbAddress)
				{
					break;
				}
				i--;
			}
		}
		else
		{
			for (; i < funcs.Length - 1 && funcs[i] != null; i++)
			{
				DbiFunction dbiFunction2 = funcs[i + 1];
				if (dbiFunction2.Address != pdbAddress)
				{
					break;
				}
			}
		}
		DbiFunction dbiFunction3 = funcs[i];
		if (dbiFunction3.Lines != null)
		{
			return;
		}
		dbiFunction3.Lines = new List<SymbolSequencePoint>();
		while (reader.Position < end)
		{
			DbiDocument document = documents[reader.ReadUInt32()];
			uint num5 = reader.ReadUInt32();
			reader.Position += 4u;
			uint position = reader.Position;
			uint num6 = reader.Position + num5 * 8;
			for (uint num7 = 0u; num7 < num5; num7++)
			{
				reader.Position = position + num7 * 8;
				SymbolSequencePoint item = new SymbolSequencePoint
				{
					Document = document
				};
				item.Offset = reader.ReadInt32();
				uint num8 = reader.ReadUInt32();
				item.Line = (int)(num8 & 0xFFFFFF);
				item.EndLine = item.Line + (int)((num8 >> 24) & 0x7F);
				if ((num4 & 1) != 0)
				{
					reader.Position = num6 + num7 * 4;
					item.Column = reader.ReadUInt16();
					item.EndColumn = reader.ReadUInt16();
				}
				dbiFunction3.Lines.Add(item);
			}
		}
	}
}
