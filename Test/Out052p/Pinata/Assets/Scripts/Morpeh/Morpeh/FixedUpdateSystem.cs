using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh
{
	[Token(Token = "0x2000018")]
	public abstract class FixedUpdateSystem : ScriptableObject, IFixedSystem, ISystem, IInitializer, IDisposable
	{
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x18")]
		private World world;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x20")]
		private FilterProvider filter;

		[Token(Token = "0x1700000B")]
		public World World
		{
			[Token(Token = "0x6000070")]
			[Address(RVA = "0x15F7690", Offset = "0x15F7690", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.world;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return World;
			}
			[Token(Token = "0x6000071")]
			[Address(RVA = "0x15F7698", Offset = "0x15F7698", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.world = value;\n\treturn;\n")]
			set
			{
				World = value;
			}
		}

		[Token(Token = "0x1700000C")]
		public FilterProvider Filter
		{
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x15F76A0", Offset = "0x15F76A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.filter;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Filter;
			}
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x15F76A8", Offset = "0x15F76A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.filter = value;\n\treturn;\n")]
			set
			{
				Filter = value;
			}
		}

		[Token(Token = "0x6000074")]
		public abstract void OnAwake();

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x15F76B0", Offset = "0x15F76B0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void OnStart()
		{
		}

		[Token(Token = "0x6000076")]
		public abstract void OnUpdate(float deltaTime);

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x15F76B4", Offset = "0x15F76B4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public virtual void Dispose()
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x15F76B8", Offset = "0x15F76B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected FixedUpdateSystem()
		{
		}
	}
}
