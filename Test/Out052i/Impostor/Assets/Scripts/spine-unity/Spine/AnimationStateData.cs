using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000027")]
	public class AnimationStateData
	{
		[Token(Token = "0x2000028")]
		public struct AnimationPair
		{
			[Token(Token = "0x40000EB")]
			[FieldOffset(Offset = "0x0")]
			public readonly Animation a1;

			[Token(Token = "0x40000EC")]
			[FieldOffset(Offset = "0x8")]
			public readonly Animation a2;

			[Token(Token = "0x6000143")]
			[Address(RVA = "0x152CA44", Offset = "0x152CA44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.a1 = a1;\n\tthis.a2 = a2;\n\treturn;\n")]
			public AnimationPair(Animation a1, Animation a2)
			{
				this.a1 = a1;
				this.a2 = a2;
			}

			[Token(Token = "0x6000144")]
			[Address(RVA = "0x152CA4C", Offset = "0x152CA4C", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\n\tv14 = \"->\";\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37B29]) = v33;\nL_0010:\n\tv34 = this.a1;\n\tv36 = this.a2;\n\treturnVal2 = System.String::Concat(v34.name, \"->\", v36.name);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public override string ToString()
			{
				Animation animation = a1;
				Animation animation2 = a2;
				return animation.Name + "->" + animation2.Name;
			}
		}

		[Token(Token = "0x2000029")]
		public class AnimationPairComparer : IEqualityComparer<AnimationPair>
		{
			[Token(Token = "0x40000ED")]
			public static readonly AnimationPairComparer Instance;

			[Token(Token = "0x6000145")]
			[Address(RVA = "0x152CAB0", Offset = "0x152CAB0", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = x - methodInfo;\n\tv6 = v4 == 0;\n\tv16 = y - v14;\n\tv18 = v16 == 0;\n\treturnVal1 = v6 & v18;\n\treturn returnVal1;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool IEqualityComparer<AnimationPair>.Equals(AnimationPair x, AnimationPair y)
			{
				//IL_0009: Unknown result type (might be due to invalid IL or missing references)
				//IL_000e: Expected O, but got Unknown
				//IL_0026: Unknown result type (might be due to invalid IL or missing references)
				//IL_002b: Expected O, but got Unknown
				IntPtr intPtr = default(IntPtr);
				object obj = x - (nint)intPtr;
				bool flag = obj == null;
				object obj3 = default(object);
				object obj2 = y - (nint)obj3;
				bool flag2 = obj2 == null;
				return flag && flag2;
			}

			[Token(Token = "0x6000146")]
			[Address(RVA = "0x152CAC8", Offset = "0x152CAC8", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = obj.a1;\n\t*([v8 @ X8_v2 (Spine.Animation)+158])(v15, obj, *([v8 @ X8_v2 (Spine.Animation)+160]), methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv40 = methodInfo->methodPointer;\n\t*([v40 @ X8_v4+158])(v45, methodInfo, *([v40 @ X8_v4+160]), methodInfo, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28);\n\tv46 = v15 << 5;\n\tv47 = v15 + v46;\n\treturnVal1 = v45 ^ v47;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			int IEqualityComparer<AnimationPair>.GetHashCode(AnimationPair obj)
			{
				//IL_0024: Expected O, but got I
				//IL_004b: Expected O, but got I
				Animation a = obj.a1;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v8 @ X8_v2 (Spine.Animation)+158] (should have been resolved before IL gen)");
				IntPtr intPtr = default(IntPtr);
				object obj2 = (nint)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v40 @ X8_v4+158] (should have been resolved before IL gen)");
				object obj3 = default(object);
				int num = (int)((nint)obj3 << 5);
				object obj4 = (nint)obj3 + num;
				object obj5 = default(object);
				return (int)((nint)obj5 ^ (nint)obj4);
			}

			[Token(Token = "0x6000147")]
			[Address(RVA = "0x152CB1C", Offset = "0x152CB1C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public AnimationPairComparer()
			{
			}

			[Token(Token = "0x6000148")]
			[Address(RVA = "0x152CB24", Offset = "0x152CB24", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.AnimationStateData+AnimationPairComparer;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37B2A]) = v34;\nL_0012:\n\tv36 = new Spine.AnimationStateData+AnimationPairComparer();\n\tSystem.Object::.ctor(v36);\n\tv40.Instance = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static AnimationPairComparer()
			{
				AnimationPairComparer instance = new AnimationPairComparer();
				Instance = instance;
			}
		}

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x10")]
		internal SkeletonData skeletonData;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x18")]
		private readonly Dictionary<AnimationPair, float> animationToMixTime;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x20")]
		internal float defaultMix;

		[Token(Token = "0x17000057")]
		public SkeletonData SkeletonData
		{
			[Token(Token = "0x600013C")]
			[Address(RVA = "0x152C6BC", Offset = "0x152C6BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.skeletonData;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SkeletonData;
			}
		}

		[Token(Token = "0x17000058")]
		public float DefaultMix
		{
			[Token(Token = "0x600013D")]
			[Address(RVA = "0x152C6C4", Offset = "0x152C6C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.defaultMix;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultMix;
			}
			[Token(Token = "0x600013E")]
			[Address(RVA = "0x152C6CC", Offset = "0x152C6CC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.defaultMix = value;\n\treturn;\n")]
			set
			{
				DefaultMix = value;
			}
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x152C6D4", Offset = "0x152C6D4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv24 = Spine.AnimationStateData+AnimationPairComparer;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, skeletonData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv53 = Il2CppMethodInfo;\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, skeletonData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv63 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, skeletonData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37B24]) = v43;\nL_0024:\n\tgoto L_002A;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v44, skeletonData, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv57 = Spine.AnimationStateData+AnimationPairComparer;\nL_002A:\n\tv61 = new System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>();\n\tSystem.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>::.ctor(v61, v58.Instance);\n\tthis.animationToMixTime = v61;\n\tSystem.Object::.ctor(this);\n\tv69 = skeletonData == 0;\n\tif (v69) goto L_0041;\n\tthis.skeletonData = skeletonData;\n\treturn;\nL_0041:\n\tv95 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v95, \"skeletonData cannot be null.\", \"skeletonData\");\n\tthrow v95;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimationStateData(SkeletonData skeletonData)
		{
			//IL_0065: Expected I4, but got O
			base._002Ector();
			Dictionary<AnimationPair, float> dictionary = new Dictionary<AnimationPair, float>((int)AnimationPairComparer.Instance);
			animationToMixTime = dictionary;
			if (skeletonData != null)
			{
				this.skeletonData = skeletonData;
				return;
			}
			ArgumentException ex = new ArgumentException("skeletonData cannot be null.", "skeletonData");
			throw ex;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x152C7F0", Offset = "0x152C7F0", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = Spine.SkeletonData::FindAnimation(this.skeletonData, fromName);\n\tv47 = v23 == 0;\n\tif (v47) goto L_002E;\n\tv63 = Spine.SkeletonData::FindAnimation(this.skeletonData, toName);\n\tv68 = v63 == 0;\n\tif (v68) goto L_003D;\n\tSpine.AnimationStateData::SetMix(this, v23, v63, duration);\n\treturn;\n\tthrow System.NullReferenceException;\nL_002E:\n\tv60 = System.String::Concat(\"Animation not found: \", v49);\n\tv69 = new System.ArgumentException();\n\tgoto L_004B;\nL_003D:\n\tv88 = System.String::Concat(\"Animation not found: \", toName);\n\tv123 = new System.ArgumentException();\nL_004B:\n\tSystem.ArgumentException::.ctor(v99, v94, v97);\n\tthrow v99;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMix(string fromName, string toName, float duration)
		{
			Animation animation = SkeletonData.FindAnimation(fromName);
			ArgumentException ex2;
			if (animation != null)
			{
				Animation animation2 = SkeletonData.FindAnimation(toName);
				if (animation2 != null)
				{
					SetMix(animation, animation2, duration);
					return;
				}
				string text = "Animation not found: " + toName;
				ArgumentException ex = new ArgumentException();
				string text2 = text;
				string text3 = "toName";
				ex2 = ex;
			}
			else
			{
				string text5 = default(string);
				string text4 = "Animation not found: " + text5;
				ArgumentException ex3 = new ArgumentException();
				string text2 = text4;
				string text3 = "fromName";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x152C90C", Offset = "0x152C90C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, from, to, methodInfo, v29, v30, v31, v32, duration, v33, v34, v35, v36, v37, v38, v39);\n\tv46 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v46, from, to, methodInfo, v29, v30, v31, v32, duration, v33, v34, v35, v36, v37, v38, v39);\n\tv43 = 1;\n\t*([1A37B25]) = v43;\nL_0019:\n\tv44 = from == 0;\n\tif (v44) goto L_003C;\n\tv47 = to == 0;\n\tif (v47) goto L_0048;\n\tv74 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>::Remove(this.animationToMixTime, from);\n\tSystem.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>::Add(this.animationToMixTime, from, duration);\n\treturn;\n\tthrow System.NullReferenceException;\nL_003C:\n\tv68 = new System.ArgumentNullException();\n\tgoto L_0055;\nL_0048:\n\tv78 = new System.ArgumentNullException();\nL_0055:\n\tSystem.ArgumentNullException::.ctor(v111, v110, v108);\n\tthrow v111;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetMix(Animation from, Animation to, float duration)
		{
			ArgumentNullException ex2;
			if (from != null)
			{
				if (to != null)
				{
					bool flag = animationToMixTime.Remove((AnimationPair)from);
					animationToMixTime.Add((AnimationPair)from, duration);
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "to cannot be null.";
				string text2 = "to";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "from cannot be null.";
				string text2 = "from";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x152AB0C", Offset = "0x152AB0C", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, from, to, methodInfo, v25, v26, v27, v28, returnVal1, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37B26]) = v39;\nL_0014:\n\tv40 = 0;\n\tv41 = from == 0;\n\tif (v41) goto L_003C;\n\tv42 = to == 0;\n\tif (v42) goto L_0048;\n\tv59 = System.Collections.Generic.Dictionary`2<Spine.AnimationStateData+AnimationPair, System.Single>::TryGetValue(this.animationToMixTime, from, to);\n\tv126 = this + 0x20;\n\tv83 = v59 == 0;\n\tv86 = ~v83;\n\tv87 = ~v86;\n\tif (v87) goto L_0038;\n\tgoto L_0038;\nL_0038:\n\treturn *([v126 @ X8_v6]);\nL_003C:\n\tv51 = new System.ArgumentNullException();\n\tgoto L_0055;\nL_0048:\n\tv75 = new System.ArgumentNullException();\nL_0055:\n\tSystem.ArgumentNullException::.ctor(v73, v71, v132);\n\tthrow v73;\n\tthrow System.NullReferenceException;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe float GetMix(Animation from, Animation to)
		{
			//IL_00ed: Expected O, but got I4
			//IL_0045: Expected O, but got I
			//IL_010f: Expected F4, but got O
			object obj = 0;
			ArgumentNullException ex2;
			if (from != null)
			{
				if (to != null)
				{
					bool flag = animationToMixTime.TryGetValue((AnimationPair)from, out *(float*)to);
					object obj2 = (nint)this + 32;
					if (flag)
					{
						obj2 = obj;
					}
					return (float)obj2;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "to cannot be null.";
				string text2 = "to";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "from cannot be null.";
				string text2 = "from";
				ex2 = ex3;
			}
			throw ex2;
		}
	}
}
