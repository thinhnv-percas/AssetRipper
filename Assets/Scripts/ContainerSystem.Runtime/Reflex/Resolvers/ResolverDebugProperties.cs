using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Resolvers
{
	[Token(Token = "0x2000012")]
	public sealed class ResolverDebugProperties
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		public int Resolutions;

		[Token(Token = "0x17000009")]
		[field: Token(Token = "0x400001C")]
		[field: FieldOffset(Offset = "0x18")]
		public List<(WeakReference, List<CallSite>)> Instances
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x3F30BD4", Offset = "0x3F30BD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Instances;\n")]
			get;
		}

		[Token(Token = "0x1700000A")]
		[field: Token(Token = "0x400001D")]
		[field: FieldOffset(Offset = "0x20")]
		public List<CallSite> BindingCallsite
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x3F30BDC", Offset = "0x3F30BDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.BindingCallsite;\n")]
			get;
		}

		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3F30BE4", Offset = "0x3F30BE4", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv72 = new System.Collections.Generic.List`1<CallSite>();\n\tSystem.Collections.Generic.List`1<CallSite>::.ctor(v72);\n\tthis.BindingCallsite = v72;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0028:\n\tv56 = new System.Collections.Generic.List`1<System.ValueTuple`2<System.WeakReference, System.Collections.Generic.List`1<CallSite>>>();\n\tSystem.Collections.Generic.List`1<System.ValueTuple`2<System.WeakReference, System.Collections.Generic.List`1<CallSite>>>::.ctor(v56);\n\tthis.Instances = v56;\n")]
		public ResolverDebugProperties()
		{
			List<(WeakReference, List<CallSite>)> list = new List<(WeakReference, List<CallSite>)>();
			Instances = list;
			List<CallSite> list2 = new List<CallSite>();
			BindingCallsite = list2;
		}
	}
}
