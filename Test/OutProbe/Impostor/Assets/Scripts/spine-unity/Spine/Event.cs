using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000042")]
	public class Event
	{
		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x10")]
		internal readonly EventData data;

		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x18")]
		internal readonly float time;

		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x1C")]
		internal int intValue;

		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x20")]
		internal float floatValue;

		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x28")]
		internal string stringValue;

		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x30")]
		internal float volume;

		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x34")]
		internal float balance;

		[Token(Token = "0x170000C7")]
		public EventData Data
		{
			[Token(Token = "0x6000254")]
			[Address(RVA = "0x15318D0", Offset = "0x15318D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.data;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Data;
			}
		}

		[Token(Token = "0x170000C8")]
		public float Time
		{
			[Token(Token = "0x6000255")]
			[Address(RVA = "0x15318D8", Offset = "0x15318D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.time;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Time;
			}
		}

		[Token(Token = "0x170000C9")]
		public int Int
		{
			[Token(Token = "0x6000256")]
			[Address(RVA = "0x15318E0", Offset = "0x15318E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.intValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Int;
			}
			[Token(Token = "0x6000257")]
			[Address(RVA = "0x15318E8", Offset = "0x15318E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.intValue = value;\n\treturn;\n")]
			set
			{
				Int = value;
			}
		}

		[Token(Token = "0x170000CA")]
		public float Float
		{
			[Token(Token = "0x6000258")]
			[Address(RVA = "0x15318F0", Offset = "0x15318F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.floatValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Float;
			}
			[Token(Token = "0x6000259")]
			[Address(RVA = "0x15318F8", Offset = "0x15318F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.floatValue = value;\n\treturn;\n")]
			set
			{
				Float = value;
			}
		}

		[Token(Token = "0x170000CB")]
		public string String
		{
			[Token(Token = "0x600025A")]
			[Address(RVA = "0x1531900", Offset = "0x1531900", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.stringValue;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return String;
			}
			[Token(Token = "0x600025B")]
			[Address(RVA = "0x1531908", Offset = "0x1531908", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.stringValue = value;\n\treturn;\n")]
			set
			{
				String = value;
			}
		}

		[Token(Token = "0x170000CC")]
		public float Volume
		{
			[Token(Token = "0x600025C")]
			[Address(RVA = "0x1531910", Offset = "0x1531910", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.volume;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Volume;
			}
			[Token(Token = "0x600025D")]
			[Address(RVA = "0x1531918", Offset = "0x1531918", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.volume = value;\n\treturn;\n")]
			set
			{
				Volume = value;
			}
		}

		[Token(Token = "0x170000CD")]
		public float Balance
		{
			[Token(Token = "0x600025E")]
			[Address(RVA = "0x1531920", Offset = "0x1531920", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.balance;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Balance;
			}
			[Token(Token = "0x600025F")]
			[Address(RVA = "0x1531928", Offset = "0x1531928", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.balance = value;\n\treturn;\n")]
			set
			{
				Balance = value;
			}
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x1531930", Offset = "0x1531930", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv15 = data == 0;\n\tif (v15) goto L_0017;\n\tthis.time = time;\n\tthis.data = data;\n\treturn;\nL_0017:\n\tv50 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v50, \"data\", \"data cannot be null.\");\n\tthrow v50;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Event(float time, EventData data)
		{
			if (data != null)
			{
				this.time = time;
				this.data = data;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("data", "data cannot be null.");
			throw ex;
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x15319C8", Offset = "0x15319C8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data;\n\treturn v2.name;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			EventData eventData = Data;
			return eventData.Name;
		}
	}
}
