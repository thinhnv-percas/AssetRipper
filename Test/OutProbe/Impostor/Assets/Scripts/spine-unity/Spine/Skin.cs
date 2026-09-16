using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Spine.Collections;

namespace Spine
{
	[Token(Token = "0x200005D")]
	public class Skin
	{
		[Token(Token = "0x200005E")]
		public struct SkinEntry
		{
			[Token(Token = "0x4000259")]
			[FieldOffset(Offset = "0x0")]
			internal readonly int slotIndex;

			[Token(Token = "0x400025A")]
			[FieldOffset(Offset = "0x8")]
			internal readonly string name;

			[Token(Token = "0x400025B")]
			[FieldOffset(Offset = "0x10")]
			internal readonly Attachment attachment;

			[Token(Token = "0x400025C")]
			[FieldOffset(Offset = "0x18")]
			internal readonly int hashCode;

			[Token(Token = "0x17000139")]
			public int SlotIndex
			{
				[Token(Token = "0x60003F8")]
				[Address(RVA = "0x154DF24", Offset = "0x154DF24", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.slotIndex;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return slotIndex;
				}
			}

			[Token(Token = "0x1700013A")]
			public string Name
			{
				[Token(Token = "0x60003F9")]
				[Address(RVA = "0x154DF2C", Offset = "0x154DF2C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return name;
				}
			}

			[Token(Token = "0x1700013B")]
			public Attachment Attachment
			{
				[Token(Token = "0x60003FA")]
				[Address(RVA = "0x154DF34", Offset = "0x154DF34", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachment;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return attachment;
				}
			}

			[Token(Token = "0x60003F7")]
			[Address(RVA = "0x154C97C", Offset = "0x154C97C", Length = "0x40")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.slotIndex = slotIndex;\n\tthis.name = name;\n\tthis.attachment = attachment;\n\tv14 = System.String::GetHashCode(name);\n\tv29 = this.slotIndex * 0x25;\n\tv30 = v14 + v29;\n\tthis.hashCode = v30;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SkinEntry(int slotIndex, string name, Attachment attachment)
			{
				this.slotIndex = slotIndex;
				this.name = name;
				this.attachment = attachment;
				int num = name.GetHashCode();
				int num2 = this.slotIndex * 37;
				int num3 = num + num2;
				hashCode = num3;
			}
		}

		[Token(Token = "0x200005F")]
		private class SkinEntryComparer : IEqualityComparer<SkinEntry>
		{
			[Token(Token = "0x400025D")]
			internal static readonly SkinEntryComparer Instance;

			[Token(Token = "0x60003FB")]
			[Address(RVA = "0x154DF3C", Offset = "0x154DF3C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = e1.slotIndex != e2.slotIndex;\n\tif (v13) goto L_0014;\n\treturnVal2 = System.String::Equals(e1.name, e2.name, 4);\n\treturn returnVal2;\nL_0014:\n\treturn 0;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			bool IEqualityComparer<SkinEntry>.Equals(SkinEntry e1, SkinEntry e2)
			{
				if (e1.slotIndex == e2.slotIndex)
				{
					return string.Equals(e1.name, e2.name, StringComparison.Ordinal);
				}
				return false;
			}

			[Token(Token = "0x60003FC")]
			[Address(RVA = "0x154DF68", Offset = "0x154DF68", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = System.String::GetHashCode(e.name);\n\tv28 = e.slotIndex * 0x25;\n\treturnVal1 = v11 + v28;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			int IEqualityComparer<SkinEntry>.GetHashCode(SkinEntry e)
			{
				int hashCode = e.name.GetHashCode();
				int num = e.slotIndex * 37;
				return hashCode + num;
			}

			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x154DF9C", Offset = "0x154DF9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SkinEntryComparer()
			{
			}

			[Token(Token = "0x60003FE")]
			[Address(RVA = "0x154DFA4", Offset = "0x154DFA4", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = Spine.Skin+SkinEntryComparer;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37BB7]) = v34;\nL_0012:\n\tv36 = new Spine.Skin+SkinEntryComparer();\n\tSystem.Object::.ctor(v36);\n\tv40.Instance = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static SkinEntryComparer()
			{
				SkinEntryComparer instance = new SkinEntryComparer();
				Instance = instance;
			}
		}

		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x10")]
		internal string name;

		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x18")]
		private OrderedDictionary<SkinEntry, Attachment> attachments;

		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x20")]
		internal readonly ExposedList<BoneData> bones;

		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x28")]
		internal readonly ExposedList<ConstraintData> constraints;

		[Token(Token = "0x17000135")]
		public string Name
		{
			[Token(Token = "0x60003E8")]
			[Address(RVA = "0x154C95C", Offset = "0x154C95C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Name;
			}
		}

		[Token(Token = "0x17000136")]
		public OrderedDictionary<SkinEntry, Attachment> Attachments
		{
			[Token(Token = "0x60003E9")]
			[Address(RVA = "0x154C964", Offset = "0x154C964", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.attachments;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Attachments;
			}
		}

		[Token(Token = "0x17000137")]
		public ExposedList<BoneData> Bones
		{
			[Token(Token = "0x60003EA")]
			[Address(RVA = "0x154C96C", Offset = "0x154C96C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.bones;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Bones;
			}
		}

		[Token(Token = "0x17000138")]
		public ExposedList<ConstraintData> Constraints
		{
			[Token(Token = "0x60003EB")]
			[Address(RVA = "0x154C974", Offset = "0x154C974", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.constraints;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Constraints;
			}
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0x1546554", Offset = "0x1546554", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003C;\n\tv32 = Il2CppMethodInfo;\n\tv33 = \"il2cpp_codegen_initialize_runtime_metadata\"(v32, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv79 = Spine.ExposedList`1<Spine.BoneData>;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv85 = Spine.ExposedList`1<Spine.ConstraintData>;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv95 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>;\n\tv96 = \"il2cpp_codegen_initialize_runtime_metadata\"(v95, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv100 = Spine.Skin+SkinEntryComparer;\n\tv49 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv51 = 1;\n\t*([1A37BAB]) = v51;\nL_003C:\n\tgoto L_0042;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v52, name, methodInfo, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv73 = Spine.Skin+SkinEntryComparer;\nL_0042:\n\tv77 = new Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>();\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::.ctor(v77, v74.Instance);\n\tthis.attachments = v77;\n\tv88 = new Spine.ExposedList`1<Spine.BoneData>();\n\tSpine.ExposedList`1<Spine.BoneData>::.ctor(v88);\n\tthis.bones = v88;\n\tv98 = new Spine.ExposedList`1<Spine.ConstraintData>();\n\tSpine.ExposedList`1<Spine.ConstraintData>::.ctor(v98);\n\tthis.constraints = v98;\n\tSystem.Object::.ctor(this);\n\tv105 = name == 0;\n\tif (v105) goto L_0069;\n\tthis.name = name;\n\treturn;\nL_0069:\n\tv139 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v139, \"name\", \"name cannot be null.\");\n\tthrow v139;\n// 89 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Skin(string name)
		{
			//IL_008d: Expected I4, but got O
			base._002Ector();
			OrderedDictionary<SkinEntry, Attachment> orderedDictionary = new OrderedDictionary<SkinEntry, Attachment>((int)SkinEntryComparer.Instance);
			attachments = orderedDictionary;
			ExposedList<BoneData> exposedList = new ExposedList<BoneData>();
			bones = exposedList;
			ExposedList<ConstraintData> exposedList2 = new ExposedList<ConstraintData>();
			constraints = exposedList2;
			if (name != null)
			{
				this.name = name;
				return;
			}
			ArgumentNullException ex = new ArgumentNullException("name", "name cannot be null.");
			throw ex;
		}

		[Token(Token = "0x60003ED")]
		[Address(RVA = "0x154731C", Offset = "0x154731C", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, slotIndex, name, attachment, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 1;\n\t*([1A37BAC]) = v42;\nL_0016:\n\tv43 = attachment == 0;\n\tif (v43) goto L_0042;\n\tv44 = slotIndex & 0x80000000;\n\tv45 = v44 == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_004E;\n\tv73 = System.String::GetHashCode(name);\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::set_Item(this.attachments, &slotIndex @ X1 (System.Int32), attachment);\n\treturn;\n\tthrow System.NullReferenceException;\nL_0042:\n\tv67 = new System.ArgumentNullException();\n\tgoto L_005B;\nL_004E:\n\tv76 = new System.ArgumentNullException();\nL_005B:\n\tSystem.ArgumentNullException::.ctor(v118, v117, v114);\n\tthrow v118;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetAttachment(int slotIndex, string name, Attachment attachment)
		{
			//IL_0017: Expected I4, but got I8
			//IL_0064: Expected O, but got Ref
			ArgumentNullException ex2;
			if (attachment != null)
			{
				if ((int)(slotIndex & 0x80000000L) == 0)
				{
					int hashCode = name.GetHashCode();
					int num = default(int);
					Attachments[(SkinEntry)(&num)] = attachment;
					return;
				}
				ArgumentNullException ex = new ArgumentNullException();
				string text = "slotIndex must be >= 0.";
				string text2 = "slotIndex";
				ex2 = ex;
			}
			else
			{
				ArgumentNullException ex3 = new ArgumentNullException();
				string text = "attachment cannot be null.";
				string text2 = "attachment";
				ex2 = ex3;
			}
			throw ex2;
		}

		[Token(Token = "0x60003EE")]
		[Address(RVA = "0x154C9BC", Offset = "0x154C9BC", Length = "0x5A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0069;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv131 = Il2CppMethodInfo;\n\tv132 = \"il2cpp_codegen_initialize_runtime_metadata\"(v131, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv174 = Il2CppMethodInfo;\n\tv175 = \"il2cpp_codegen_initialize_runtime_metadata\"(v174, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv265 = Il2CppMethodInfo;\n\tv266 = \"il2cpp_codegen_initialize_runtime_metadata\"(v265, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv283 = Il2CppMethodInfo;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv299 = Il2CppMethodInfo;\n\tv300 = \"il2cpp_codegen_initialize_runtime_metadata\"(v299, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv308 = Il2CppMethodInfo;\n\tv309 = \"il2cpp_codegen_initialize_runtime_metadata\"(v308, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv315 = Il2CppMethodInfo;\n\tv316 = \"il2cpp_codegen_initialize_runtime_metadata\"(v315, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv381 = Il2CppMethodInfo;\n\tv382 = \"il2cpp_codegen_initialize_runtime_metadata\"(v381, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv471 = Il2CppMethodInfo;\n\tv472 = \"il2cpp_codegen_initialize_runtime_metadata\"(v471, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv536 = Il2CppMethodInfo;\n\tv537 = \"il2cpp_codegen_initialize_runtime_metadata\"(v536, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv590 = System.IDisposable;\n\tv591 = \"il2cpp_codegen_initialize_runtime_metadata\"(v590, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv653 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>;\n\tv654 = \"il2cpp_codegen_initialize_runtime_metadata\"(v653, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv664 = System.Collections.IEnumerator;\n\tv665 = \"il2cpp_codegen_initialize_runtime_metadata\"(v664, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv670 = Il2CppMethodInfo;\n\tv671 = \"il2cpp_codegen_initialize_runtime_metadata\"(v670, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv673 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v673, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37BAD]) = v53;\nL_0069:\n\tv145 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(skin.bones);\nL_0070:\n\tv281 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v87 @ stack_-C0_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv286 = v281 == 0;\n\tif (v286) goto L_0088;\n\tv273 = Spine.ExposedList`1<Spine.BoneData>::Contains(this.bones, v176);\n\tv318 = v273 == 0;\n\tv276 = ~v318;\n\tif (v276) goto L_0070;\n\tSpine.ExposedList`1<Spine.BoneData>::Add(this.bones, v176);\n\tgoto L_0070;\nL_0088:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v87 @ stack_-C0_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_0089:\n\t;\n\tv336 = Spine.ExposedList`1<Spine.ConstraintData>::GetEnumerator(skin.constraints);\nL_0095:\n\tv487 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v87 @ stack_-C0_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv539 = v487 == 0;\n\tif (v539) goto L_00AF;\n\tv483 = Spine.ExposedList`1<Spine.ConstraintData>::Contains(this.constraints, v176);\n\tv667 = v483 == 0;\n\tv485 = ~v667;\n\tif (v485) goto L_0095;\n\tSpine.ExposedList`1<Spine.ConstraintData>::Add(this.constraints, v176);\n\tgoto L_0095;\nL_00AF:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v87 @ stack_-C0_v5 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00B0:\n\t;\n\tv114 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(skin.attachments);\n\tv164 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>+KeyCollection<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(v114);\nL_00C8:\n\tgoto L_00EE;\n\tv719 = *([v715 @ X8_v33+B0]);\n\tv720 = v719 + 8;\n\tv722 = *([v759 @ X10_v32-8]);\n\tv764 = v722 == v716;\n\tif (v764) goto L_00E7;\n\tv726 = v750 - 1;\n\tv744 = v759 + 0x10;\n\tv724 = v750 != 1;\n\tif (v724) goto L_FFFFFFFF;\n\tv745 = v168;\n\tv746 = 0;\n\tv747 = 0xB349B4(v745, v716, v746, v394, v38, v39, v40, v41, v83, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00EE;\nL_00E7:\n\tv770 = *([v759 @ X10_v32]);\n\tv771 = v770 << 4;\n\tv772 = v715 + v771;\n\tv773 = v772 + 0x138;\nL_00EE:\n\tv428 = System.Collections.IEnumerator::MoveNext(v164);\n\tv430 = v428 == 0;\n\tif (v430) goto L_FFFFFFFF;\n\tgoto L_011D;\n\tv781 = *([v778 @ X8_v36+B0]);\n\tv782 = v781 + 8;\n\tv784 = *([v821 @ X10_v27-8]);\n\tv826 = v784 == v779;\n\tif (v826) goto L_0115;\n\tv788 = v812 - 1;\n\tv806 = v821 + 0x10;\n\tv786 = v812 != 1;\n\tif (v786) goto L_FFFFFFFF;\n\tv807 = v168;\n\tv808 = 0;\n\tv809 = 0xB349B4(v807, v779, v808, v394, v38, v39, v40, v41, v83, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_011D;\nL_0115:\n\tv832 = *([v821 @ X10_v27]);\n\tv833 = v832 << 4;\n\tv834 = v778 + v833;\n\tv835 = v834 + 0x138;\nL_011D:\n\tv842 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>::get_Current(v164);\n\tSpine.Skin::SetAttachment(this, v706, v843, v176);\n\tgoto L_00C8;\nL_0125:\n\tv435 = v257 == 0;\n\tif (v435) goto L_0154;\n\tgoto L_0153;\n\tv540 = *([v488 @ X8_v5+B0]);\n\tv541 = v540 + 8;\n\tv543 = *([v605 @ X10_v9-8]);\n\tv610 = v543 == v492;\n\tif (v610) goto L_014C;\n\tv547 = v596 - 1;\n\tv565 = v605 + 0x10;\n\tv545 = v596 != 1;\n\tif (v545) goto L_FFFFFFFF;\n\tv566 = v257;\n\tv567 = 0;\n\tv568 = 0xB349B4(v566, v492, v567, v178, v38, v39, v40, v41, v229, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0153;\nL_014C:\n\tv656 = *([v605 @ X10_v9]);\n\tv657 = v656 << 4;\n\tv658 = v488 + v657;\n\tv659 = v658 + 0x138;\nL_0153:\n\tSystem.IDisposable::Dispose(v257);\nL_0154:\n\tv512 = v255 == 0;\n\tv253 = ~v512;\n\tif (v253) goto L_016C;\n\treturn;\n\tv310 = new System.NullReferenceException();\n\tv333 = new System.NullReferenceException();\n\tv393 = new System.NullReferenceException();\n\tv111 = new System.NullReferenceException();\n\tv129 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_016C:\n\tv263 = new System.OutOfMemoryException();\n\tgoto L_01C8;\n\tgoto L_0177;\n\tgoto L_0177;\n\tgoto L_019C;\n\tgoto L_019C;\n\tgoto L_01C8;\n\tgoto L_0177;\n\tgoto L_0177;\n\tgoto L_019C;\n\tgoto L_019C;\nL_0177:\n\tX24 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0190;\n\tX0 = X24;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1947728]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_00B0;\n\tX0 = X22;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0190:\n\tX22 = 0;\n\tgoto L_0193;\n\tX24 = X0;\nL_0193:\n\tX8 = 0x1947000;\n\tX8 = *([1947728]);\n\tX1 = *([X8]);\n\tX0 = &stack[20];\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(X0, X1);\n\tif (TEMP) goto L_0205;\n\tX0 = X22;\n\tX0 = OutOfMemoryException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_019C:\n\tX24 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\n// ... truncated")]
		public void AddSkin(Skin skin)
		{
			//IL_017e: Expected I4, but got O
			ExposedList<BoneData>.Enumerator enumerator = skin.Bones.GetEnumerator();
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			Attachment attachment = default(Attachment);
			while (enumerator2.MoveNext())
			{
				if (!Bones.Contains((BoneData)(object)attachment))
				{
					Bones.Add((BoneData)(object)attachment);
				}
			}
			enumerator2.Dispose();
			ExposedList<ConstraintData>.Enumerator enumerator3 = skin.Constraints.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (!Constraints.Contains((ConstraintData)(object)attachment))
				{
					Constraints.Add((ConstraintData)(object)attachment);
				}
			}
			enumerator2.Dispose();
			OrderedDictionary<SkinEntry, Attachment>.KeyCollection keys = skin.Attachments.Keys;
			IEnumerator<SkinEntry> enumerator4 = keys.GetEnumerator();
			int slotIndex = default(int);
			string text = default(string);
			while (enumerator4.MoveNext())
			{
				SkinEntry current = enumerator4.Current;
				SetAttachment(slotIndex, text, attachment);
			}
			int num = 0;
			IEnumerator<SkinEntry> enumerator5 = enumerator4;
			int num2 = default(int);
			object obj = default(object);
			IEnumerator<SkinEntry> enumerator6 = default(IEnumerator<SkinEntry>);
			while (true)
			{
				enumerator5?.Dispose();
				if (num == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num2 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num = (int)obj;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					enumerator5 = enumerator6;
					continue;
				}
				break;
			}
			enumerator6?.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0x154CF5C", Offset = "0x154CF5C", Length = "0x650")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_006C;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv261 = Il2CppMethodInfo;\n\tv262 = \"il2cpp_codegen_initialize_runtime_metadata\"(v261, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv306 = Il2CppMethodInfo;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv400 = Il2CppMethodInfo;\n\tv401 = \"il2cpp_codegen_initialize_runtime_metadata\"(v400, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv405 = Il2CppMethodInfo;\n\tv406 = \"il2cpp_codegen_initialize_runtime_metadata\"(v405, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv422 = Il2CppMethodInfo;\n\tv423 = \"il2cpp_codegen_initialize_runtime_metadata\"(v422, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv429 = Il2CppMethodInfo;\n\tv430 = \"il2cpp_codegen_initialize_runtime_metadata\"(v429, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv455 = Il2CppMethodInfo;\n\tv456 = \"il2cpp_codegen_initialize_runtime_metadata\"(v455, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv565 = Il2CppMethodInfo;\n\tv566 = \"il2cpp_codegen_initialize_runtime_metadata\"(v565, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv688 = Il2CppMethodInfo;\n\tv689 = \"il2cpp_codegen_initialize_runtime_metadata\"(v688, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv741 = System.IDisposable;\n\tv742 = \"il2cpp_codegen_initialize_runtime_metadata\"(v741, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv795 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>;\n\tv796 = \"il2cpp_codegen_initialize_runtime_metadata\"(v795, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv857 = System.Collections.IEnumerator;\n\tv858 = \"il2cpp_codegen_initialize_runtime_metadata\"(v857, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv871 = Il2CppMethodInfo;\n\tv872 = \"il2cpp_codegen_initialize_runtime_metadata\"(v871, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv874 = Spine.MeshAttachment;\n\tv875 = \"il2cpp_codegen_initialize_runtime_metadata\"(v874, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv878 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v878, skin, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37BAE]) = v53;\nL_006C:\n\tv195 = Spine.ExposedList`1<Spine.BoneData>::GetEnumerator(skin.bones);\nL_0073:\n\tv322 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v131 @ stack_-C0_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv403 = v322 == 0;\n\tif (v403) goto L_008B;\n\tv314 = Spine.ExposedList`1<Spine.BoneData>::Contains(this.bones, v263);\n\tv432 = v314 == 0;\n\tv317 = ~v432;\n\tif (v317) goto L_0073;\n\tSpine.ExposedList`1<Spine.BoneData>::Add(this.bones, v263);\n\tgoto L_0073;\nL_008B:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v131 @ stack_-C0_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_008C:\n\t;\n\tv450 = Spine.ExposedList`1<Spine.ConstraintData>::GetEnumerator(skin.constraints);\nL_0098:\n\tv611 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v131 @ stack_-C0_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv692 = v611 == 0;\n\tif (v692) goto L_00B2;\n\tv604 = Spine.ExposedList`1<Spine.ConstraintData>::Contains(this.constraints, v263);\n\tv860 = v604 == 0;\n\tv607 = ~v860;\n\tif (v607) goto L_0098;\n\tSpine.ExposedList`1<Spine.ConstraintData>::Add(this.constraints, v263);\n\tgoto L_0098;\nL_00B2:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v131 @ stack_-C0_v6 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_00B3:\n\t;\n\tv162 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(skin.attachments);\n\tv297 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>+KeyCollection<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(v162);\nL_00CD:\n\tgoto L_00F3;\n\tv927 = *([v923 @ X8_v35+B0]);\n\tv928 = v927 + 8;\n\tv930 = *([v967 @ X10_v45-8]);\n\tv972 = v930 == v924;\n\tif (v972) goto L_00EC;\n\tv934 = v958 - 1;\n\tv952 = v967 + 0x10;\n\tv932 = v958 != 1;\n\tif (v932) goto L_FFFFFFFF;\n\tv953 = v254;\n\tv954 = 0;\n\tv955 = 0xB349B4(v953, v924, v954, v197, v38, v39, v40, v41, v127, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_00F3;\nL_00EC:\n\tv978 = *([v967 @ X10_v45]);\n\tv979 = v978 << 4;\n\tv980 = v923 + v979;\n\tv981 = v980 + 0x138;\nL_00F3:\n\tv645 = System.Collections.IEnumerator::MoveNext(v297);\n\tv647 = v645 == 0;\n\tif (v647) goto L_FFFFFFFF;\n\tgoto L_0122;\n\tv990 = *([v986 @ X8_v38+B0]);\n\tv991 = v990 + 8;\n\tv993 = *([v1030 @ X10_v40-8]);\n\tv1035 = v993 == v987;\n\tif (v1035) goto L_011A;\n\tv997 = v1021 - 1;\n\tv1015 = v1030 + 0x10;\n\tv995 = v1021 != 1;\n\tif (v995) goto L_FFFFFFFF;\n\tv1016 = v254;\n\tv1017 = 0;\n\tv1018 = 0xB349B4(v1016, v987, v1017, v197, v38, v39, v40, v41, v127, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0122;\nL_011A:\n\tv1041 = *([v1030 @ X10_v40]);\n\tv1042 = v1041 << 4;\n\tv1043 = v986 + v1042;\n\tv1044 = v1043 + 0x138;\nL_0122:\n\tv513 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>::get_Current(v297);\n\tv1051 = v263 == 0;\n\tif (v1051) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tv217 = v217_asT != 0;\n\tif (v217) goto L_0159;\n\tv512 = Spine.MeshAttachment::Copy(v263);\n\tv1067 = this == 0;\n\tv515 = ~v1067;\n\tif (v515) goto L_0155;\n\tgoto L_01A5;\nL_0155:\n\tSpine.Skin::SetAttachment(this, v234, v1050, v882);\n\tgoto L_00CD;\nL_0159:\n\tv250 = Spine.MeshAttachment::NewLinkedMesh(v263);\n\tSpine.Skin::SetAttachment(this, v234, v1050, v250);\n\tgoto L_00CD;\nL_0163:\n\tv652 = v297 == 0;\n\tif (v652) goto L_0192;\n\tgoto L_0191;\n\tv745 = *([v693 @ X8_v5+B0]);\n\tv746 = v745 + 8;\n\tv748 = *([v808 @ X10_v9-8]);\n\tv813 = v748 == v697;\n\tif (v813) goto L_018A;\n\tv752 = v799 - 1;\n\tv770 = v808 + 0x10;\n\tv750 = v799 != 1;\n\tif (v750) goto L_FFFFFFFF;\n\tv771 = v392;\n\tv772 = 0;\n\tv773 = 0xB349B4(v771, v697, v772, v324, v38, v39, v40, v41, v364, v43, v44, v45, v46, v47, v48, v49);\n\tgoto L_0191;\nL_018A:\n\tv863 = *([v808 @ X10_v9]);\n\tv864 = v863 << 4;\n\tv865 = v693 + v864;\n\tv866 = v865 + 0x138;\nL_0191:\n\tSystem.IDisposable::Dispose(v297);\nL_0192:\n\tv717 = ~v390;\n\tv388 = ~v717;\n\tif (v388) goto L_01AC;\n\treturn;\n\tv424 = new System.NullReferenceException();\n\tv447 = new System.NullReferenceException();\nL_01A5:\n\tv520 = new System.NullReferenceException();\n\tv597 = new System.NullReferenceException();\n\tv159 = new System.NullReferenceException();\n\tv179 = new System.NullReferenceException();\n\tv259 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_01AC:\n\tv398 = new System.OutOfMemoryException();\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01E0;\n\tgoto L_01E0;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_020C;\n\tgoto L_01BB;\n\tgoto L_01BB;\n\tgoto L_01E0;\n\tgoto L_01E0;\nL_01BB:\n\tX24 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_01D4;\n\tX0 = X24;\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([X0]);\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1947728]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tSpine.ExposedList`1<System\n// ... truncated")]
		public unsafe void CopySkin(Skin skin)
		{
			//IL_01dc: Expected I, but got O
			//IL_03c3: Expected I, but got O
			//IL_0277: Expected O, but got I
			//IL_0295: Expected O, but got I
			//IL_0295: Expected O, but got I4
			//IL_02d9: Expected O, but got I
			//IL_0411: Expected I, but got O
			ExposedList<BoneData>.Enumerator enumerator = skin.Bones.GetEnumerator();
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			MeshAttachment meshAttachment = default(MeshAttachment);
			while (enumerator2.MoveNext())
			{
				if (!Bones.Contains((BoneData)(object)meshAttachment))
				{
					Bones.Add((BoneData)(object)meshAttachment);
				}
			}
			enumerator2.Dispose();
			ExposedList<ConstraintData>.Enumerator enumerator3 = skin.Constraints.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				if (!Constraints.Contains((ConstraintData)(object)meshAttachment))
				{
					Constraints.Add((ConstraintData)(object)meshAttachment);
				}
			}
			enumerator2.Dispose();
			OrderedDictionary<SkinEntry, Attachment>.KeyCollection keys = skin.Attachments.Keys;
			IEnumerator<SkinEntry> enumerator4 = keys.GetEnumerator();
			int slotIndex = default(int);
			string text = default(string);
			while (true)
			{
				if (!enumerator4.MoveNext())
				{
					nint num = unchecked((nint)null);
					bool flag = false;
					while (true)
					{
						if (enumerator4 != null)
						{
							enumerator4.Dispose();
							num = unchecked((nint)null);
						}
						if (!flag)
						{
							return;
						}
						OutOfMemoryException ex = new OutOfMemoryException();
						if (num == 1)
						{
							bool flag2 = ((ExposedList<BoneData>)(object)ex).Contains((BoneData)num);
							flag = ((bool*)(flag2 ? 1 : 0))->m_value;
							bool flag3 = ((ExposedList<BoneData>)flag2).Contains((BoneData)num);
							continue;
						}
						break;
					}
					if (enumerator4 != null)
					{
						enumerator4.Dispose();
						num = unchecked((nint)null);
					}
					OutOfMemoryException ex2 = new OutOfMemoryException();
					bool flag4 = ((ExposedList<BoneData>)(object)ex2).Contains((BoneData)num);
					return;
				}
				SkinEntry current = enumerator4.Current;
				Attachment attachment3;
				if (meshAttachment != null)
				{
					MeshAttachment meshAttachment2 = meshAttachment as MeshAttachment;
					if (meshAttachment2 != null)
					{
						MeshAttachment attachment = meshAttachment.NewLinkedMesh();
						SetAttachment(slotIndex, text, attachment);
						continue;
					}
					Attachment attachment2 = meshAttachment.Copy();
					bool flag5 = this == null;
					bool flag6 = !flag5;
					attachment3 = attachment2;
					if (!flag6)
					{
						break;
					}
				}
				else
				{
					attachment3 = null;
				}
				SetAttachment(slotIndex, text, attachment3);
			}
			NullReferenceException ex3 = new NullReferenceException();
			NullReferenceException ex4 = new NullReferenceException();
			NullReferenceException ex5 = new NullReferenceException();
			NullReferenceException ex6 = new NullReferenceException();
			NullReferenceException ex7 = new NullReferenceException();
			throw new NullReferenceException();
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0x1547454", Offset = "0x1547454", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, slotIndex, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37BAF]) = v39;\nL_001B:\n\tv46 = System.String::GetHashCode(name);\n\tv74 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::TryGetValue(this.attachments, &slotIndex @ X1 (System.Int32), &v67 @ stack_-28_v4 (System.Object));\n\tv83 = v74 == 0;\n\tv86 = ~v83;\n\tv87 = ~v86;\n\tif (v87) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe Attachment GetAttachment(int slotIndex, string name)
		{
			//IL_002a: Expected O, but got Ref
			int hashCode = name.GetHashCode();
			int num = default(int);
			object value;
			if (Attachments.TryGetValue((SkinEntry)(&num), out *(Attachment*)(&value)))
			{
				return (Attachment)value;
			}
			return null;
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0x154D5AC", Offset = "0x154D5AC", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, slotIndex, name, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 1;\n\t*([1A37BB0]) = v39;\nL_0014:\n\tv40 = slotIndex & 0x80000000;\n\tv41 = v40 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_003C;\n\tv62 = System.String::GetHashCode(name);\n\tv81 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::Remove(this.attachments, &slotIndex @ X1 (System.Int32));\n\treturn;\n\tthrow System.NullReferenceException;\nL_003C:\n\tv66 = new System.ArgumentOutOfRangeException();\n\tSystem.ArgumentOutOfRangeException::.ctor(v66, \"slotIndex\", \"slotIndex must be >= 0\");\n\tthrow v66;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RemoveAttachment(int slotIndex, string name)
		{
			//IL_0060: Expected I4, but got I8
			//IL_0026: Expected O, but got Ref
			if ((int)(slotIndex & 0x80000000L) == 0)
			{
				int hashCode = name.GetHashCode();
				int num = default(int);
				bool flag = Attachments.Remove((SkinEntry)(&num));
				return;
			}
			ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException("slotIndex", "slotIndex must be >= 0");
			throw ex;
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0x154D6A8", Offset = "0x154D6A8", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37BB1]) = v33;\nL_001A:\n\treturnVal1 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(this.attachments);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ICollection<SkinEntry> GetAttachments()
		{
			return Attachments.Keys;
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0x154D6F8", Offset = "0x154D6F8", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv36 = System.IDisposable;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv153 = System.Collections.IEnumerator;\n\tv154 = \"il2cpp_codegen_initialize_runtime_metadata\"(v153, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv194 = Il2CppMethodInfo;\n\tv195 = \"il2cpp_codegen_initialize_runtime_metadata\"(v194, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv271 = Il2CppMethodInfo;\n\tv272 = \"il2cpp_codegen_initialize_runtime_metadata\"(v271, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv321 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v321, slotIndex, attachments, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37BB2]) = v54;\nL_0031:\n\tv63 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(this.attachments);\n\tv185 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>+KeyCollection<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(v63);\n\tv128 = &v130 @ stack_-E0_v8 (System.Int32) | 4;\nL_0049:\n\tgoto L_006F;\n\tv402 = *([v387 @ X8_v26+B0]);\n\tv403 = v402 + 8;\n\tv405 = *([v445 @ X10_v35-8]);\n\tv450 = v405 == v388;\n\tif (v450) goto L_0068;\n\tv409 = v436 - 1;\n\tv427 = v445 + 0x10;\n\tv407 = v436 != 1;\n\tif (v407) goto L_FFFFFFFF;\n\tv428 = v146;\n\tv429 = 0;\n\tv430 = 0xB349B4(v428, v388, v429, methodInfo, v39, v40, v41, v42, v341, v337, v45, v46, v47, v48, v49, v50);\n\tgoto L_006F;\nL_0068:\n\tv459 = *([v445 @ X10_v35]);\n\tv460 = v459 << 4;\n\tv461 = v387 + v460;\n\tv462 = v461 + 0x138;\nL_006F:\n\tv255 = System.Collections.IEnumerator::MoveNext(v185);\n\tv484 = v255 == 0;\n\tif (v484) goto L_FFFFFFFF;\n\tgoto L_009E;\n\tv583 = *([v526 @ X8_v29+B0]);\n\tv584 = v583 + 8;\n\tv586 = *([v668 @ X10_v30-8]);\n\tv673 = v586 == v527;\n\tif (v673) goto L_0096;\n\tv590 = v659 - 1;\n\tv608 = v668 + 0x10;\n\tv588 = v659 != 1;\n\tif (v588) goto L_FFFFFFFF;\n\tv609 = v146;\n\tv610 = 0;\n\tv611 = 0xB349B4(v609, v527, v610, methodInfo, v39, v40, v41, v42, v341, v337, v45, v46, v47, v48, v49, v50);\n\tgoto L_009E;\nL_0096:\n\tv717 = *([v668 @ X10_v30]);\n\tv718 = v717 << 4;\n\tv719 = v526 + v718;\n\tv720 = v719 + 0x138;\nL_009E:\n\tv378 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>::get_Current(v185);\n\tv281 = v128.m_value;\n\tv95 = v130 != slotIndex;\n\tif (v95) goto L_0049;\n\tv818 = attachments._items;\n\tv819 = attachments._version + 1;\n\tattachments._version = v819;\n\tv821 = attachments._size < v818.Length;\n\tv369 = ~v821;\n\tif (v369) goto L_00DC;\n\tv351 = attachments._size + 1;\n\tv346 = attachments._size << 5;\n\tv384 = v818 + v346;\n\tattachments._size = v351;\n\t*([v384 @ X8_v37+20]) = slotIndex;\n\tv818[v371 @ X10_v26 (System.Int32)].attachment = *([v128 @ X27_v7 (System.Int32)+C]);\n\t*([v384 @ X8_v37+24]) = v281;\n\tgoto L_0049;\nL_00DC:\n\t*([v128 @ X27_v7 (System.Int32)+C]) = *([v128 @ X27_v7 (System.Int32)+C]);\n\tv128.m_value = v128.m_value;\n\tSystem.Collections.Generic.List`1<Spine.Skin+SkinEntry>::AddWithResize(attachments, &v130 @ stack_-E0_v8 (System.Int32));\n\tgoto L_0049;\nL_00E3:\n\tv548 = v313 == 0;\n\tif (v548) goto L_0110;\n\tv612 = *([v313 @ X19_v4 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv738 = *([v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv615 = *([v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v615) goto L_0106;\n\tv747 = *([v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_00F1:\n\tv752 = *([v747 @ X10_v7-8]) == *([v316 @ X23_v4 (Il2CppClass<System.IDisposable>)]);\n\tif (v752) goto L_0109;\n\tv685 = v738 - 1;\n\tv747 = v747 + 0x10;\n\tv683 = v738 != 1;\n\tif (v683) goto L_00F1;\nL_0106:\n\t;\n\tgoto L_010D;\nL_0109:\n\tv809 = *([v747 @ X10_v7]) << 4;\n\tv810 = v612 + v809;\n\tv812 = v810 + 0x138;\nL_010D:\n\tv517 = *([v812 @ X0_v5+8]);\n\tv255 = System.IDisposable::Dispose(v313);\nL_0110:\n\tv634 = v263 == 0;\n\tv257 = ~v634;\n\tif (v257) goto L_0131;\n\tv285 = *([v21 @ SYSREG+28]) != *([v21 @ SYSREG+28]);\n\tif (v285) goto L_0132;\n\treturn;\n\tv820 = new System.NullReferenceException();\n\tv141 = new System.NullReferenceException();\n\tv151 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0131:\n\tv269 = new System.OutOfMemoryException();\nL_0132:\n\tv319 = 0x1854EB0(v255, v517, v493, methodInfo, v39, v40, v41, v42, v281, v280, v45, v46, v47, v48, v49, v50);\n\tgoto L_0141;\n\tgoto L_0141;\n\tgoto L_0141;\n\tgoto L_0141;\nL_0141:\n\tv401 = v517 != 1;\n\tif (v401) goto L_0149;\n\tv432 = 0x1854E70(v319, v517, v493, methodInfo, v39, v40, v41, v42, v281, v280, v45, v46, v47, v48, v49, v50);\n\tv263 = *([v432 @ X0_v27]);\n\tv255 = 0x1854E80(v432, v517, v493, methodInfo, v39, v40, v41, v42, v281, v280, v45, v46, v47, v48, v49, v50);\n\tgoto L_00E3;\nL_0149:\n\tgoto L_014B;\n\tX21 = X0;\nL_014B:\n\tv457 = v313 == 0;\n\tif (v457) goto L_017A;\n\tv485 = *([v313 @ X19_v4 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv637 = *([v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv488 = *([v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v488) goto L_016E;\n\tv646 = *([v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_0159:\n\tv651 = *([v646 @ X10_v15-8]) == *([v316 @ X23_v4 (Il2CppClass<System.IDisposable>)]);\n\tif (v651) goto L_0171;\n\tv556 = v637 - 1;\n\tv646 = v646 + 0x10;\n\tv554 = v637 != 1;\n\tif (v554) goto L_0159;\nL_016E:\n\t;\n\tgoto L_0175;\nL_0171:\n\tv710 = *([v646 @ X10_v15]) << 4;\n\tv711 = v485 + v710;\n\tv713 = v711 + 0x138;\nL_0175:\n\tv517 = *([v713 @ X0_v20+8]);\n\tv520 = System.IDisposable::Dispose(v313);\nL_017A:\n\tgoto L_017E;\n\tv579 = 0xBD3CD0(v319, v517, v493, methodInfo, v39, v40, v41, v42, v281, v280, v45, v46, v47, v48, v49, v50);\nL_017E:\n\tv582 = new System.OutOfMemoryException();\n\tv656 = 0x9DACB4(v582, v517, v493, methodInfo, v39, v40, v41, v42, v281, v280, v45, v46, v47, v48, v49, v50);\n\treturn;\n// 237 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void GetAttachments(int slotIndex, List<SkinEntry> attachments)
		{
			//IL_01aa: Expected I, but got O
			//IL_02ed: Expected I4, but got O
			//IL_01b7: Expected I, but got O
			//IL_01c7: Expected O, but got I
			//IL_0202: Expected O, but got I
			//IL_0157: Expected O, but got Ref
			//IL_034d: Expected I4, but got O
			//IL_026a: Expected I4, but got O
			//IL_0278: Expected O, but got I
			//IL_0287: Expected O, but got I
			//IL_00d9: Expected O, but got I
			//IL_0109: Expected O, but got I
			//IL_0216: Expected O, but got I
			//IL_0225: Expected O, but got I
			//IL_0373: Expected I, but got O
			//IL_0383: Expected O, but got I
			//IL_03be: Expected O, but got I
			//IL_0426: Expected I4, but got O
			//IL_0434: Expected O, but got I
			//IL_0443: Expected O, but got I
			//IL_03d2: Expected O, but got I
			//IL_03e1: Expected O, but got I
			OrderedDictionary<SkinEntry, Attachment>.KeyCollection keys = Attachments.Keys;
			IEnumerator<SkinEntry> enumerator = keys.GetEnumerator();
			int num2 = default(int);
			int num = (int)((nint)num2 | (nint)4);
			int num5 = default(int);
			while (enumerator.MoveNext())
			{
				SkinEntry current = enumerator.Current;
				int value = ((int*)num)->m_value;
				bool flag = num2 != slotIndex;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X27_v7 (System.Int32)+C]");
				int num3 = 0;
				if (!flag)
				{
					SkinEntry[] items = attachments._items;
					int version = attachments._version + 1;
					attachments._version = version;
					if (attachments.Count < items.Length)
					{
						int size = attachments.Count + 1;
						int num4 = attachments.Count << 5;
						object obj = (nint)items + num4;
						attachments._size = size;
						ref SkinEntry reference = ref items[num5];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X27_v7 (System.Int32)+C]");
						reference.attachment = (Attachment)0;
						num3 = value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X27_v7 (System.Int32)+C]");
						value = 0;
					}
					else
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X27_v7 (System.Int32)+C]");
						_ = 0;
						((int*)num)->m_value = ((int*)num)->m_value;
						attachments.Add((SkinEntry)(&num2));
						num3 = ((int*)num)->m_value;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ X27_v7 (System.Int32)+C]");
						value = 0;
					}
				}
			}
			int num6 = 0;
			int num7 = 0;
			IEnumerator<SkinEntry> enumerator2 = enumerator;
			int num8 = 0;
			nint num9 = (nint)typeof(IDisposable);
			int num13 = default(int);
			int num14 = default(int);
			int num15 = default(int);
			int num16 = default(int);
			IEnumerator<SkinEntry> enumerator3 = default(IEnumerator<SkinEntry>);
			IntPtr intPtr = default(IntPtr);
			object obj7 = default(object);
			while (true)
			{
				if (enumerator2 == null)
				{
					goto IL_04f2;
				}
				nint num10 = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_024d;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ X8_v7 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
				object obj3 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v747 @ X10_v7-8]");
					if (0 == num9)
					{
						break;
					}
					object obj4 = (nint)obj2 - 1;
					obj3 = (nint)obj3 + 16;
					bool flag2 = (nint)obj2 != 1;
					obj2 = obj4;
					if (flag2)
					{
						continue;
					}
					goto IL_024d;
				}
				int num11 = obj3 << 4;
				object obj5 = num10 + num11;
				object obj6 = (nint)obj5 + 312;
				goto IL_053e;
				IL_04f2:
				if (num8 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
					nint num12 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ SYSREG+28]");
					if (num12 == 0)
					{
						return;
					}
				}
				else
				{
					OutOfMemoryException ex = new OutOfMemoryException();
					int num3 = num13;
					int value = num14;
					num6 = num15;
					num7 = num16;
					bool flag3 = (byte)(int)ex != 0;
					enumerator2 = enumerator3;
					num9 = intPtr;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
				if (num7 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num8 = (int)obj7;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					continue;
				}
				break;
				IL_024d:
				num6 = 0;
				goto IL_053e;
				IL_053e:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v812 @ X0_v5+8]");
				num7 = 0;
				enumerator2.Dispose();
				goto IL_04f2;
			}
			if (enumerator2 != null)
			{
				nint num17 = (nint)enumerator2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				if ((nint)0 == 0)
				{
					goto IL_0409;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v485 @ X8_v13 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
				object obj9 = (nint)0 + (nint)8;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v646 @ X10_v15-8]");
					if (0 == num9)
					{
						break;
					}
					object obj10 = (nint)obj8 - 1;
					obj9 = (nint)obj9 + 16;
					bool flag4 = (nint)obj8 != 1;
					obj8 = obj10;
					if (flag4)
					{
						continue;
					}
					goto IL_0409;
				}
				int num18 = obj9 << 4;
				object obj11 = num17 + num18;
				object obj12 = (nint)obj11 + 312;
				goto IL_05ba;
			}
			goto IL_045c;
			IL_05ba:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v713 @ X0_v20+8]");
			num7 = 0;
			enumerator2.Dispose();
			goto IL_045c;
			IL_045c:
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
			return;
			IL_0409:
			num6 = 0;
			goto IL_05ba;
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x154DAB0", Offset = "0x154DAB0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37BB3]) = v34;\nL_001C:\n\tSpine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::Clear(this.attachments);\n\tSpine.ExposedList`1<Spine.BoneData>::Clear(this.bones, 1);\n\tSpine.ExposedList`1<Spine.ConstraintData>::Clear(this.constraints, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			Attachments.Clear();
			Bones.Clear();
			Constraints.Clear();
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x154DB50", Offset = "0x154DB50", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.name;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ToString()
		{
			return Name;
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x154DB58", Offset = "0x154DB58", Length = "0x340")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv28 = System.IDisposable;\n\tv29 = \"il2cpp_codegen_initialize_runtime_metadata\"(v28, skeleton, oldSkin, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv49 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, skeleton, oldSkin, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv121 = System.Collections.IEnumerator;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, skeleton, oldSkin, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv154 = Il2CppMethodInfo;\n\tv155 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, skeleton, oldSkin, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv211 = Il2CppMethodInfo;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v211, skeleton, oldSkin, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37BB4]) = v46;\nL_002B:\n\tv108 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>::get_Keys(oldSkin.attachments);\n\tv145 = Spine.Collections.OrderedDictionary`2<Spine.Skin+SkinEntry, Spine.Attachment>+KeyCollection<Spine.Skin+SkinEntry, Spine.Attachment>::GetEnumerator(v108);\nL_003F:\n\tgoto L_0065;\n\tv278 = *([v271 @ X8_v22+B0]);\n\tv279 = v278 + 8;\n\tv281 = *([v359 @ X10_v36-8]);\n\tv364 = v281 == v272;\n\tif (v364) goto L_005E;\n\tv285 = v350 - 1;\n\tv303 = v359 + 0x10;\n\tv283 = v350 != 1;\n\tif (v283) goto L_FFFFFFFF;\n\tv304 = v113;\n\tv305 = 0;\n\tv306 = 0xB349B4(v304, v272, v305, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0065;\nL_005E:\n\tv442 = *([v359 @ X10_v36]);\n\tv443 = v442 << 4;\n\tv444 = v271 + v443;\n\tv445 = v444 + 0x138;\nL_0065:\n\tv400 = System.Collections.IEnumerator::MoveNext(v145);\n\tv402 = v400 == 0;\n\tif (v402) goto L_FFFFFFFF;\n\tgoto L_0094;\n\tv544 = *([v495 @ X8_v25+B0]);\n\tv545 = v544 + 8;\n\tv547 = *([v632 @ X10_v31-8]);\n\tv637 = v547 == v496;\n\tif (v637) goto L_008C;\n\tv551 = v623 - 1;\n\tv569 = v632 + 0x10;\n\tv549 = v623 != 1;\n\tif (v549) goto L_FFFFFFFF;\n\tv570 = v113;\n\tv571 = 0;\n\tv572 = 0xB349B4(v570, v496, v571, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0094;\nL_008C:\n\tv651 = *([v632 @ X10_v31]);\n\tv652 = v651 << 4;\n\tv653 = v495 + v652;\n\tv654 = v653 + 0x138;\nL_0094:\n\tv261 = System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>::get_Current(v145);\n\tv672 = skeleton.slots;\n\tv705 = v672.Items;\n\tv270 = v705[v54 @ stack_-60_v6 (System.Int32)];\n\tv237 = v270.attachment != v733;\n\tif (v237) goto L_003F;\n\tv262 = Spine.Skin::GetAttachment(this, v54, v735);\n\tv266 = v262 == 0;\n\tif (v266) goto L_003F;\n\tSpine.Slot::set_Attachment(v705[v54 @ stack_-60_v6 (System.Int32)], v262);\n\tgoto L_003F;\nL_00C6:\n\tv406 = v203 == 0;\n\tif (v406) goto L_00F3;\n\tv450 = *([v203 @ X19_v2 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv575 = *([v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv453 = *([v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v453) goto L_00E9;\n\tv584 = *([v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_00D4:\n\tv589 = *([v584 @ X10_v7-8]) == *([v191 @ X23_v1 (Il2CppClass<System.IDisposable>)]);\n\tif (v589) goto L_00EC;\n\tv506 = v575 - 1;\n\tv584 = v584 + 0x10;\n\tv504 = v575 != 1;\n\tif (v504) goto L_00D4;\nL_00E9:\n\t;\n\tgoto L_00F2;\nL_00EC:\n\t;\nL_00F2:\n\tv469 = System.IDisposable::Dispose(v203);\nL_00F3:\n\tv472 = v201 == 0;\n\tv197 = ~v472;\n\tif (v197) goto L_0108;\n\treturn;\n\tv728 = new System.IndexOutOfRangeException();\n\tv730 = new System.NullReferenceException();\n\tv697 = new System.NullReferenceException();\n\tv704 = new System.NullReferenceException();\n\tv107 = new System.NullReferenceException();\n\tv119 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0108:\n\tv209 = new System.OutOfMemoryException();\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\n\tgoto L_011C;\nL_011C:\n\tv224 = v339 != 1;\n\tif (v224) goto L_0124;\n\tv228 = 0x1854E70(v209, v339, v315, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv201 = *([v228 @ X0_v27]);\n\tv276 = 0x1854E80(v228, v339, v315, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00C6;\nL_0124:\n\tgoto L_0126;\n\tX21 = X0;\nL_0126:\n\tv277 = v202 == 0;\n\tif (v277) goto L_0155;\n\tv307 = *([v202 @ X19_v4 (System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>)]);\n\tv475 = *([v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]);\n\tv310 = *([v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]) == 0;\n\tif (v310) goto L_0149;\n\tv484 = *([v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]) + 8;\nL_0134:\n\tv489 = *([v484 @ X10_v15-8]) == *([v190 @ X23_v3 (Il2CppClass<System.IDisposable>)]);\n\tif (v489) goto L_014C;\n\tv414 = v475 - 1;\n\tv484 = v484 + 0x10;\n\tv412 = v475 != 1;\n\tif (v412) goto L_0134;\nL_0149:\n\t;\n\tgoto L_0152;\nL_014C:\n\tv538 = *([v484 @ X10_v15]) << 4;\n\tv539 = v307 + v538;\n\tv541 = v539 + 0x138;\nL_0152:\n\tv342 = System.IDisposable::Dispose(v202);\nL_0155:\n\tgoto L_0159;\n\tv437 = 0xBD3CD0(v209, *([v541 @ X0_v20+8]), 0, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0159:\n\tv440 = new System.OutOfMemoryException();\n\tv494 = 0x9DACB4(v440, *([v541 @ X0_v20+8]), 0, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void AttachAll(Skeleton skeleton, Skin oldSkin)
		{
			//IL_00ea: Expected I, but got O
			//IL_0109: Expected I, but got O
			//IL_0119: Expected O, but got I
			//IL_0154: Expected O, but got I
			//IL_01f4: Expected I4, but got O
			//IL_022b: Expected I, but got O
			//IL_023b: Expected O, but got I
			//IL_0168: Expected O, but got I
			//IL_0177: Expected O, but got I
			//IL_0276: Expected O, but got I
			//IL_02d5: Expected I4, but got O
			//IL_02e3: Expected O, but got I
			//IL_02f2: Expected O, but got I
			//IL_028a: Expected O, but got I
			//IL_0299: Expected O, but got I
			OrderedDictionary<SkinEntry, Attachment>.KeyCollection keys = oldSkin.Attachments.Keys;
			IEnumerator<SkinEntry> enumerator = keys.GetEnumerator();
			int num = default(int);
			object obj = default(object);
			string text = default(string);
			while (enumerator.MoveNext())
			{
				SkinEntry current = enumerator.Current;
				ExposedList<Slot> slots = skeleton.Slots;
				Slot[] items = slots.Items;
				Slot slot = items[num];
				if (slot.Attachment == obj)
				{
					Attachment attachment = GetAttachment(num, text);
					if (attachment != null)
					{
						items[num].Attachment = attachment;
					}
				}
			}
			nint num2 = (nint)typeof(IDisposable);
			int num3 = 0;
			IEnumerator<SkinEntry> enumerator2 = enumerator;
			int num5 = default(int);
			object obj5 = default(object);
			IntPtr intPtr = default(IntPtr);
			IEnumerator<SkinEntry> enumerator3 = default(IEnumerator<SkinEntry>);
			while (true)
			{
				if (enumerator2 != null)
				{
					nint num4 = (nint)enumerator2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ X8_v5 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
						object obj3 = (nint)0 + (nint)8;
						bool flag;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v584 @ X10_v7-8]");
							if (0 != num2)
							{
								object obj4 = (nint)obj2 - 1;
								obj3 = (nint)obj3 + 16;
								flag = (nint)obj2 != 1;
								obj2 = obj4;
								continue;
							}
							break;
						}
						while (flag);
					}
					enumerator2.Dispose();
				}
				if (num3 == 0)
				{
					return;
				}
				OutOfMemoryException ex = new OutOfMemoryException();
				if (num5 == 1)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
					num3 = (int)obj5;
					Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
					num2 = intPtr;
					enumerator2 = enumerator3;
					continue;
				}
				break;
			}
			if (enumerator3 != null)
			{
				nint num6 = (nint)enumerator3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+12E]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X8_v11 (Il2CppClass<System.Collections.Generic.IEnumerator`1<Spine.Skin+SkinEntry>>)+B0]");
					object obj7 = (nint)0 + (nint)8;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X10_v15-8]");
						if ((IntPtr)0 != intPtr)
						{
							object obj8 = (nint)obj6 - 1;
							obj7 = (nint)obj7 + 16;
							flag2 = (nint)obj6 != 1;
							obj6 = obj8;
							continue;
						}
						int num7 = obj7 << 4;
						object obj9 = num6 + num7;
						object obj10 = (nint)obj9 + 312;
						break;
					}
					while (flag2);
				}
				enumerator3.Dispose();
			}
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}
	}
}
