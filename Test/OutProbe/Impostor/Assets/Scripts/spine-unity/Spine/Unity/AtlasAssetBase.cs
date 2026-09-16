using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x2000068")]
	public abstract class AtlasAssetBase : ScriptableObject
	{
		[Token(Token = "0x1700016F")]
		public abstract Material PrimaryMaterial
		{
			[Token(Token = "0x6000485")]
			get;
		}

		[Token(Token = "0x17000170")]
		public abstract IEnumerable<Material> Materials
		{
			[Token(Token = "0x6000486")]
			get;
		}

		[Token(Token = "0x17000171")]
		public abstract int MaterialCount
		{
			[Token(Token = "0x6000487")]
			get;
		}

		[Token(Token = "0x17000172")]
		public abstract bool IsLoaded
		{
			[Token(Token = "0x6000488")]
			get;
		}

		[Token(Token = "0x6000489")]
		public abstract void Clear();

		[Token(Token = "0x600048A")]
		public abstract Atlas GetAtlas();

		[Token(Token = "0x600048B")]
		[Address(RVA = "0x1551404", Offset = "0x1551404", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal AtlasAssetBase()
		{
		}
	}
}
