using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B5")]
	internal class TweenLink
	{
		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x10")]
		public readonly GameObject target;

		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x18")]
		public readonly LinkBehaviour behaviour;

		[Token(Token = "0x4000221")]
		[FieldOffset(Offset = "0x1C")]
		public bool lastSeenActive;

		[Token(Token = "0x600042B")]
		[Address(RVA = "0xC2E1AC", Offset = "0xC2E1AC", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.target = target;\n\tthis.behaviour = behaviour;\n\tv18 = UnityEngine.GameObject::get_activeInHierarchy(target);\n\tthis.lastSeenActive = v18;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenLink(GameObject target, LinkBehaviour behaviour)
		{
			this.target = target;
			this.behaviour = behaviour;
			bool activeInHierarchy = target.activeInHierarchy;
			lastSeenActive = activeInHierarchy;
		}
	}
}
