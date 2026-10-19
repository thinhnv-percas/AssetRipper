using System;
using System.Runtime.CompilerServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SoundSystem.Scripts.Runtime.Data
{
	[Serializable]
	[Token(Token = "0x200001E")]
	public class SoundProperties
	{
		[CompilerGenerated]
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x10")]
		private Action OnValueChangedInspector;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x18")]
		public SoundManager.AudioType Type;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x1C")]
		public float Volume;

		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x20")]
		public float Pitch;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x24")]
		public bool IsLoop;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x25")]
		public bool IsMusic;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x26")]
		public bool IsMultiple;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x28")]
		public float CoolDown;

		[CompilerGenerated]
		[Token(Token = "0x6000065")]
		[Address(RVA = "0x7B9E48C", Offset = "0x7B9E48C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnValueChangedInspector (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Combine(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnValueChangedInspector;\n\tgoto L_002C;\n")]
		public void add_OnValueChangedInspector(Action value)
		{
			Action action = OnValueChangedInspector;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref OnValueChangedInspector, value2, action2);
			}
			while ((object)action != action2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000066")]
		[Address(RVA = "0x7B9E530", Offset = "0x7B9E530", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_001D:\n\tv79 = System.Threading.Interlocked::CompareExchange(&this.OnValueChangedInspector (System.Action), v89, v84);\n\tv63 = v79 == v84;\n\tv84 = v79;\n\tif (v63) goto L_0045;\nL_002C:\n\tv89 = System.Delegate::Remove(v84, value);\n\tv81 = v89 == 0;\n\tif (v81) goto L_001D;\n\tv96 = *([v89 @ X0_v4 (System.Delegate)]) == System.Action;\n\tif (v96) goto L_001D;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0017:\n\t;\n\tv84 = this.OnValueChangedInspector;\n\tgoto L_002C;\n")]
		public void remove_OnValueChangedInspector(Action value)
		{
			Action action = OnValueChangedInspector;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref OnValueChangedInspector, value2, action2);
			}
			while ((object)action != action2);
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x7B9E5D4", Offset = "0x7B9E5D4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.OnValueChangedInspector == 0;\n\tif (v2) goto L_0007;\n\tSystem.Action::Invoke(this.OnValueChangedInspector);\n\treturn;\nL_0007:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ValueChanged()
		{
			if (OnValueChangedInspector != null)
			{
				OnValueChangedInspector();
			}
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x7B9E444", Offset = "0x7B9E444", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Volume = 0f;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SoundProperties()
		{
			Volume = 0f;
		}
	}
}
