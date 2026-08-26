using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using Wasm.Binary;
using Wasm.Instructions;

namespace Wasm
{
	public sealed class FunctionBody
	{
		[CompilerGenerated]
		private List<LocalEntry> _0020_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		private List<Wasm.Instructions.Instruction> _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020;

		[CompilerGenerated]
		private byte[] _0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020;

		public List<LocalEntry> Locals
		{
			get;
			private set;
		}

		public List<Wasm.Instructions.Instruction> BodyInstructions
		{
			get;
			private set;
		}

		public byte[] ExtraPayload
		{
			get;
			set;
		}

		public bool HasExtraPayload
		{
			get
			{
				if (ExtraPayload != null)
				{
					return ExtraPayload.Length != 0;
				}
				return false;
			}
		}

		public FunctionBody(IEnumerable<LocalEntry> locals, IEnumerable<Wasm.Instructions.Instruction> body)
			: this(locals, body, new byte[0])
		{
		}

		public FunctionBody(IEnumerable<LocalEntry> locals, IEnumerable<Wasm.Instructions.Instruction> body, byte[] extraPayload)
		{
			Locals = new List<LocalEntry>(locals);
			BodyInstructions = new List<Wasm.Instructions.Instruction>(body);
			ExtraPayload = extraPayload;
		}

		public void WriteTo(BinaryWasmWriter writer)
		{
			writer.WriteLengthPrefixed(_0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A);
		}

		private void _0020_0020_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_0020_0020_000A(BinaryWasmWriter _0020)
		{
			_0020.WriteVarUInt32((uint)Locals.Count);
			foreach (LocalEntry local in Locals)
			{
				local.WriteTo(_0020);
			}
			_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.Create(WasmType.Empty, BodyInstructions).WriteContentsTo(_0020);
			if (HasExtraPayload)
			{
				_0020.Writer.Write(ExtraPayload);
			}
		}

		public static FunctionBody ReadFrom(BinaryWasmReader reader)
		{
			uint payloadLength = reader.ReadVarUInt32();
			long position = reader.Position;
			uint num = reader.ReadVarUInt32();
			List<LocalEntry> list = new List<LocalEntry>((int)num);
			for (uint num2 = 0u; num2 < num; num2++)
			{
				list.Add(LocalEntry.ReadFrom(reader));
			}
			BlockInstruction blockInstruction = _0020_0020_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A._0020_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_000A_0020_0020_000A.ReadBlockContents(WasmType.Empty, reader);
			byte[] extraPayload = reader.ReadRemainingPayload(position, payloadLength);
			return new FunctionBody(list, blockInstruction.Contents, extraPayload);
		}

		public void Dump(TextWriter writer)
		{
			if (Locals.Count > 0)
			{
				writer.Write("- Local entries:");
				TextWriter textWriter = DumpHelpers.CreateIndentedTextWriter(writer);
				for (int i = 0; i < Locals.Count; i++)
				{
					textWriter.WriteLine();
					textWriter.Write("#{0}: ", i);
					Locals[i].Dump(textWriter);
				}
				writer.WriteLine();
			}
			else
			{
				writer.WriteLine("- No local entries");
			}
			if (BodyInstructions.Count > 0)
			{
				writer.Write("- Function body:");
				TextWriter textWriter2 = DumpHelpers.CreateIndentedTextWriter(writer);
				foreach (Wasm.Instructions.Instruction bodyInstruction in BodyInstructions)
				{
					textWriter2.WriteLine();
					bodyInstruction.Dump(textWriter2);
				}
				writer.WriteLine();
			}
			else
			{
				writer.WriteLine("- Empty function body");
			}
			if (HasExtraPayload)
			{
				writer.Write("- Extra payload size: ");
				writer.Write(ExtraPayload.Length);
				writer.WriteLine();
				DumpHelpers.DumpBytes(ExtraPayload, writer);
				writer.WriteLine();
			}
		}
	}
}
