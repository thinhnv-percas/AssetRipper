using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000008")]
	public static class DOTweenCYInstruction
	{
		[Token(Token = "0x200004A")]
		public class WaitForCompletion : CustomYieldInstruction
		{
			[Token(Token = "0x400005B")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x17000001")]
			public override bool keepWaiting
			{
				[Token(Token = "0x6000115")]
				[Address(RVA = "0x1575428", Offset = "0x1575428", Length = "0x34")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.t;\n\tv9 = v6.<active>k__BackingField;\n\tv10 = ~v6.<active>k__BackingField;\n\tif (v10) goto L_000D;\n\tv28 = DG.Tweening.TweenExtensions::IsComplete(v6);\n\tv31 = v28 ^ 1;\nL_000D:\n\treturnVal1 = v9 & 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Tween tween = t;
					bool flag = tween.active;
					if (tween.active)
					{
						bool flag2 = tween.IsComplete();
						int num = (flag2 ? 1 : 0) ^ 1;
						flag = (byte)num != 0;
					}
					return (byte)((flag ? 1u : 0u) & 1u) != 0;
				}
			}

			[Token(Token = "0x6000116")]
			[Address(RVA = "0x157545C", Offset = "0x157545C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForCompletion(Tween tween)
			{
				t = tween;
			}
		}

		[Token(Token = "0x200004B")]
		public class WaitForRewind : CustomYieldInstruction
		{
			[Token(Token = "0x400005C")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x17000002")]
			public override bool keepWaiting
			{
				[Token(Token = "0x6000117")]
				[Address(RVA = "0x15755FC", Offset = "0x15755FC", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.t;\n\tv12 = ~v8.<active>k__BackingField;\n\tif (v12) goto L_FFFFFFFF;\n\tv30 = ~v8.<playedOnce>k__BackingField;\n\tif (v30) goto L_FFFFFFFF;\n\tv34 = DG.Tweening.TweenExtensions::CompletedLoops(v8);\n\tv71 = v34 + 1;\n\tv67 = v8.<position>k__BackingField * v71;\n\tv59 = v67 < 0;\n\tv56 = v67 == 0;\n\tv50 = v67 ^ v67;\n\tv47 = v67 & v50;\n\tv44 = v47 < 0;\n\tv99 = v59 == v44;\n\tv38 = ~v56;\n\tv41 = v99 & v38;\n\tgoto L_0029;\n\tgoto L_0029;\nL_0029:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_00aa: Expected O, but got F4
					//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
					//IL_00b8: Expected I4, but got Unknown
					Tween tween = t;
					if (tween.active)
					{
						if (tween.playedOnce)
						{
							int num = tween.CompletedLoops();
							int num2 = num + 1;
							float num3 = tween.position * (float)num2;
							bool flag = num3 < 0f;
							bool flag2 = num3 == 0f;
							object obj = num3 ^ num3;
							int num4 = num3 & (long)(IntPtr)obj;
							bool flag3 = num4 < 0;
							bool flag4 = flag == flag3;
							bool flag5 = !flag2;
							return flag4 && flag5;
						}
						return true;
					}
					return false;
				}
			}

			[Token(Token = "0x6000118")]
			[Address(RVA = "0x1575660", Offset = "0x1575660", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForRewind(Tween tween)
			{
				t = tween;
			}
		}

		[Token(Token = "0x200004C")]
		public class WaitForKill : CustomYieldInstruction
		{
			[Token(Token = "0x400005D")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x17000003")]
			public override bool keepWaiting
			{
				[Token(Token = "0x6000119")]
				[Address(RVA = "0x1575510", Offset = "0x1575510", Length = "0x20")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.t;\n\treturn v0.<active>k__BackingField;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Tween tween = t;
					return tween.active;
				}
			}

			[Token(Token = "0x600011A")]
			[Address(RVA = "0x1575530", Offset = "0x1575530", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForKill(Tween tween)
			{
				t = tween;
			}
		}

		[Token(Token = "0x200004D")]
		public class WaitForElapsedLoops : CustomYieldInstruction
		{
			[Token(Token = "0x400005E")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x400005F")]
			[FieldOffset(Offset = "0x18")]
			internal readonly int elapsedLoops;

			[Token(Token = "0x17000004")]
			public override bool keepWaiting
			{
				[Token(Token = "0x600011B")]
				[Address(RVA = "0x1575488", Offset = "0x1575488", Length = "0x4C")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.t;\n\tv13 = ~v10.<active>k__BackingField;\n\tif (v13) goto L_FFFFFFFF;\n\tv31 = DG.Tweening.TweenExtensions::CompletedLoops(v10);\n\tv36 = v31 - this.elapsedLoops;\n\tv37 = v36 < 0;\n\tv39 = v31 ^ this.elapsedLoops;\n\tv40 = v31 ^ v36;\n\tv41 = v39 & v40;\n\tv42 = v41 < 0;\n\tv43 = v37 == v42;\n\tv44 = ~v43;\n\tgoto L_0021;\nL_0021:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Tween tween = t;
					if (tween.active)
					{
						int num = tween.CompletedLoops();
						int num2 = num - elapsedLoops;
						bool flag = num2 < 0;
						int num3 = num ^ elapsedLoops;
						int num4 = num ^ num2;
						int num5 = num3 & num4;
						bool flag2 = num5 < 0;
						bool flag3 = flag == flag2;
						return !flag3;
					}
					return false;
				}
			}

			[Token(Token = "0x600011C")]
			[Address(RVA = "0x15754D4", Offset = "0x15754D4", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\tthis.elapsedLoops = elapsedLoops;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForElapsedLoops(Tween tween, int elapsedLoops)
			{
				t = tween;
				this.elapsedLoops = elapsedLoops;
			}
		}

		[Token(Token = "0x200004E")]
		public class WaitForPosition : CustomYieldInstruction
		{
			[Token(Token = "0x4000060")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x4000061")]
			[FieldOffset(Offset = "0x18")]
			internal readonly float position;

			[Token(Token = "0x17000005")]
			public override bool keepWaiting
			{
				[Token(Token = "0x600011D")]
				[Address(RVA = "0x157555C", Offset = "0x157555C", Length = "0x64")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.t;\n\tv15 = ~v12.<active>k__BackingField;\n\tif (v15) goto L_FFFFFFFF;\n\tv34 = DG.Tweening.TweenExtensions::CompletedLoops(v12);\n\tv37 = v34 + 1;\n\tv39 = v12.<position>k__BackingField * v37;\n\tv42 = v39 - this.position;\n\tv43 = v42 < 0;\n\tgoto L_0025;\nL_0025:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Tween tween = t;
					if (tween.active)
					{
						int num = tween.CompletedLoops();
						int num2 = num + 1;
						float num3 = tween.position * (float)num2;
						float num4 = num3 - position;
						return num4 < 0f;
					}
					return false;
				}
			}

			[Token(Token = "0x600011E")]
			[Address(RVA = "0x15755C0", Offset = "0x15755C0", Length = "0x3C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\tthis.position = position;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForPosition(Tween tween, float position)
			{
				t = tween;
				this.position = position;
			}
		}

		[Token(Token = "0x200004F")]
		public class WaitForStart : CustomYieldInstruction
		{
			[Token(Token = "0x4000062")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Tween t;

			[Token(Token = "0x17000006")]
			public override bool keepWaiting
			{
				[Token(Token = "0x600011F")]
				[Address(RVA = "0x157568C", Offset = "0x157568C", Length = "0x38")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.t;\n\tv4 = ~v0.<active>k__BackingField;\n\tif (v4) goto L_0013;\n\tv32 = v0.<playedOnce>k__BackingField == 0;\n\treturn v32;\nL_0013:\n\treturn 0;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					Tween tween = t;
					if (tween.active)
					{
						return !tween.playedOnce;
					}
					return false;
				}
			}

			[Token(Token = "0x6000120")]
			[Address(RVA = "0x15756C4", Offset = "0x15756C4", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.CustomYieldInstruction::.ctor(this);\n\tthis.t = tween;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public WaitForStart(Tween tween)
			{
				t = tween;
			}
		}
	}
}
