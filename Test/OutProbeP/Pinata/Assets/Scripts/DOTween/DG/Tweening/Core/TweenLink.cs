using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x2000052")]
	internal class TweenLink
	{
		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x10")]
		public readonly GameObject target;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x18")]
		public readonly LinkBehaviour behaviour;

		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x1C")]
		public bool lastSeenActive;

		[Token(Token = "0x60002AB")]
		[Address(RVA = "0x1075C1C", Offset = "0x1075C1C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.target = target;\n\tthis.behaviour = behaviour;\n\tv22 = UnityEngine.GameObject::get_activeInHierarchy(target);\n\tthis.lastSeenActive = v22;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TweenLink(GameObject target, LinkBehaviour behaviour)
		{
			this.target = target;
			this.behaviour = behaviour;
			bool activeInHierarchy = target.activeInHierarchy;
			lastSeenActive = activeInHierarchy;
		}
	}
}
