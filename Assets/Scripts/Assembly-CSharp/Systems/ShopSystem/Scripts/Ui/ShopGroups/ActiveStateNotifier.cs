using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Systems.ShopSystem.Scripts.Ui.ShopGroups
{
	[Token(Token = "0x200004E")]
	public class ActiveStateNotifier : MonoBehaviour
	{
		[CompilerGenerated]
		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x20")]
		internal Action ActiveStateChanged;

		[CompilerGenerated]
		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x3C68348", Offset = "0x3C68348", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.ActiveStateChanged (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.ActiveStateChanged;\n\tgoto L_002C;\n")]
		public void add_ActiveStateChanged(Action value)
		{
			Action action = ActiveStateChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref ActiveStateChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x3C683EC", Offset = "0x3C683EC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.ActiveStateChanged (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.ActiveStateChanged;\n\tgoto L_002C;\n")]
		public void remove_ActiveStateChanged(Action value)
		{
			Action action = ActiveStateChanged;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref ActiveStateChanged, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x3C68490", Offset = "0x3C68490", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ActiveStateChanged == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.ActiveStateChanged);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			if (ActiveStateChanged != null)
			{
				ActiveStateChanged();
			}
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x3C684AC", Offset = "0x3C684AC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ActiveStateChanged == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.ActiveStateChanged);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			if (ActiveStateChanged != null)
			{
				ActiveStateChanged();
			}
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x3C684C8", Offset = "0x3C684C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ActiveStateNotifier()
		{
		}
	}
}
