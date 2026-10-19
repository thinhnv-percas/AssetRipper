using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.UiControllers
{
	[Token(Token = "0x200001A")]
	public class DistancerUiObject : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x20")]
		internal Action OnDirty;

		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x28")]
		public float distance;

		[CompilerGenerated]
		[Token(Token = "0x600009C")]
		[Address(RVA = "0x81A5DB0", Offset = "0x81A5DB0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnDirty (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnDirty;\n\tgoto L_002C;\n")]
		public void add_OnDirty(Action value)
		{
			Action action = OnDirty;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnDirty, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600009D")]
		[Address(RVA = "0x81A5D0C", Offset = "0x81A5D0C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnDirty (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnDirty;\n\tgoto L_002C;\n")]
		public void remove_OnDirty(Action value)
		{
			Action action = OnDirty;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnDirty, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x81A5F04", Offset = "0x81A5F04", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnDirty == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.OnDirty);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (OnDirty != null)
			{
				OnDirty();
			}
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x81A5F20", Offset = "0x81A5F20", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnDirty == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.OnDirty);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (OnDirty != null)
			{
				OnDirty();
			}
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x81A5F3C", Offset = "0x81A5F3C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public DistancerUiObject()
		{
		}
	}
}
