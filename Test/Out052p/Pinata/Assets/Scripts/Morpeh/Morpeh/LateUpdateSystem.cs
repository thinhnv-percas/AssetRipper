using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x2000019")]
	public abstract class LateUpdateSystem : ScriptableObject, ILateSystem, ISystem, IInitializer, IDisposable
	{
		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x18")]
		private World world;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x20")]
		private FilterProvider filter;

		[Token(Token = "0x1700000D")]
		public World World
		{
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x15F8424", Offset = "0x15F8424", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.world;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return World;
			}
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x15F842C", Offset = "0x15F842C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.world = value;\n\treturn;\n")]
			set
			{
				World = value;
			}
		}

		[Token(Token = "0x1700000E")]
		public FilterProvider Filter
		{
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x15F8434", Offset = "0x15F8434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.filter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Filter;
			}
			[Token(Token = "0x600007C")]
			[Address(RVA = "0x15F843C", Offset = "0x15F843C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.filter = value;\n\treturn;\n")]
			set
			{
				Filter = value;
			}
		}

		[Token(Token = "0x600007D")]
		public abstract void OnAwake();

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x15F8444", Offset = "0x15F8444", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStart()
		{
		}

		[Token(Token = "0x600007F")]
		public abstract void OnUpdate(float deltaTime);

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x15F8448", Offset = "0x15F8448", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Dispose()
		{
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x15F844C", Offset = "0x15F844C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LateUpdateSystem()
		{
		}
	}
}
