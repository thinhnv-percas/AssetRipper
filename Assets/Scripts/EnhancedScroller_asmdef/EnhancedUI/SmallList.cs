using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedUI
{
	[Token(Token = "0x2000004")]
	public class SmallList<T>
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x0")]
		public T[] data;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		public int Count;

		[Token(Token = "0x17000001")]
		public T this[int i]
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x626F4D0", Offset = "0x626F4D0", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data == 0;\n\tif (v2) goto L_0015;\n\tv17 = i << 2;\n\tv18 = this.data + v17;\n\treturn *([v18 @ X8_v2+20]);\nL_0015:\n\treturn 0;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SmallList::get_Item");
				return default;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x626F504", Offset = "0x626F504", Length = "0x34")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv37 = i << 2;\n\tv38 = this.data + v37;\n\t*([v38 @ X8_v2+20]) = value;\n\treturn;\n")]
			set
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SmallList::set_Item");
			}
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x626F538", Offset = "0x626F538", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.data;\n\tv19 = this.data == 0;\n\tif (v19) goto L_003D;\n\tv21 = v18.Length << 1;\n\tv24 = v21 - 0x40;\n\tv25 = v24 < 0;\n\tv26 = v24 == 0;\n\tv27 = v21 ^ 0x40;\n\tv28 = v21 ^ v24;\n\tv29 = v27 & v28;\n\tv30 = v29 < 0;\n\tv32 = v25 == v30;\n\tv33 = ~v26;\n\tv34 = v32 & v33;\n\tv35 = ~v34;\n\tif (v35) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv65 = v21;\n\tgoto L_002B;\nL_FFFFFFFF:\n\tv65 = 0x40;\nL_002E:\n\t// 46 NewArr v80 @ X0_v12 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), v65 @ X21_v5 (System.Int32)\n\tv156 = this.data == 0;\n\tv111 = ~v156;\nL_FFFFFFFF:\n\tv82 = this.data;\nL_FFFFFFFF:\n\tv84 = v80;\n\tif (v111) goto L_0050;\nL_FFFFFFFF:\n\tv132 = v80;\n\tgoto L_0056;\nL_003D:\n\tgoto L_0040;\nL_0040:\n\t// 64 NewArr v64 @ X0_v7 (Il2CppClass<T[]>), typeof(Il2CppClass<T[]>), 64\n\tv76 = this.data == 0;\nL_FFFFFFFF:\n\tv82 = this.data;\nL_FFFFFFFF:\n\tv84 = v64;\nL_FFFFFFFF:\n\tv132 = v64;\n\tif (v76) goto L_0056;\nL_0050:\n\tv124 = this.Count < 1;\nL_FFFFFFFF:\n\tv132 = v84;\n\tif (v124) goto L_0056;\n\tSystem.Array::CopyTo(v82, v84, 0);\nL_FFFFFFFF:\n\tv132 = v84;\nL_0056:\n\tthis.data = v132;\n\treturn;\nL_002B:\n\tgoto L_002E;\n")]
		private void ResizeArray()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::ResizeArray");
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x626F608", Offset = "0x626F608", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Count = 0;\n\treturn;\n")]
		public void Clear()
		{
			Count = 0;
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x626F610", Offset = "0x626F610", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.data;\n\tv2 = this.data == 0;\n\tif (v2) goto L_000C;\n\tv4 = this.Count == 0;\n\tif (v4) goto L_000C;\n\treturn v0[0];\nL_000C:\n\treturn 0;\n")]
		public T First()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::First");
			return default;
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x626F644", Offset = "0x626F644", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data == 0;\n\tif (v2) goto L_0017;\n\tv4 = this.Count == 0;\n\tif (v4) goto L_0017;\n\tv9 = this.Count - 1;\n\tv33 = v9 << 2;\n\tv56 = this.data + v33;\n\treturn *([v56 @ X8_v2+20]);\nL_0017:\n\treturn 0;\n")]
		public T Last()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::Last");
			return default;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x626F684", Offset = "0x626F684", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv70 = this.data;\n\tv15 = this.data == 0;\n\tif (v15) goto L_001C;\n\tv27 = this.Count != v70.Length;\n\tif (v27) goto L_002C;\nL_001C:\n\tEnhancedUI.SmallList`1<T>::ResizeArray(this);\n\tv70 = this.data;\nL_002C:\n\tv83 = this.Count << 2;\n\tv84 = v70 + v83;\n\t*([v84 @ X8_v4+20]) = item;\n\tv86 = this.Count + 1;\n\tthis.Count = v86;\n\treturn;\n")]
		public void Add(T item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::Add");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x626F704", Offset = "0x626F704", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEnhancedUI.SmallList`1<T>::Insert(this, item, 0);\n\treturn;\n")]
		public void AddStart(T item)
		{
			Insert(item, 0);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x626F718", Offset = "0x626F718", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv75 = this.data;\n\tv21 = this.data == 0;\n\tif (v21) goto L_001F;\n\tv73 = this.Count;\n\tv33 = this.Count != v75.Length;\n\tif (v33) goto L_002D;\nL_001F:\n\tEnhancedUI.SmallList`1<T>::ResizeArray(this);\n\tv73 = this.Count;\n\tv75 = this.data;\n\tv94 = v73 << 2;\n\tv95 = v75 + v94;\n\tv211 = v95 + 0x20;\n\tv201 = v73;\nL_004C:\n\tv201 = v201 - 1;\n\tv159 = v211 + -4;\n\t*([v211 @ X12_v7]) = *([v159 @ X13_v7]);\n\tv165 = v201 > index;\n\tv211 = v159;\n\tif (v165) goto L_004C;\n\tgoto L_006F;\nL_006F:\n\tv222 = index << 2;\n\tv223 = v75 + v222;\n\t*([v223 @ X8_v3+20]) = item;\n\tv225 = this.Count + 1;\n\tthis.Count = v225;\n\treturn;\nL_002D:\n\tv88 = v73 <= index;\n\tif (v88) goto L_006F;\n")]
		public void Insert(T item, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::Insert");
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x626F7F8", Offset = "0x626F7F8", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.data;\n\tv8 = this.data == 0;\n\tif (v8) goto L_004A;\n\tv11 = this.Count == 0;\n\tif (v11) goto L_004A;\n\tv72 = this.data + 0x20;\n\tv65 = this.Count - 1;\n\tv101 = v65 < 1;\n\tif (v101) goto L_0036;\n\tv116 = this.data + 0x24;\n\tv114 = 0;\nL_0023:\n\tv114 = v114 + 1;\n\t*([v116 @ X13_v5-4]) = *([v116 @ X13_v5]);\n\tv65 = this.Count - 1;\n\tv116 = v116 + 4;\n\tv136 = v114 < v65;\n\tif (v136) goto L_0023;\nL_0036:\n\tthis.Count = v65;\n\t*([v72 @ X9_v3+v65 @ X14_v3 (System.Int32)*4]) = 0;\n\treturn v6[0];\nL_004A:\n\treturn 0;\n")]
		public T RemoveStart()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::RemoveStart");
			return default;
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x626F88C", Offset = "0x626F88C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.data == 0;\n\tif (v8) goto L_005E;\n\tv11 = this.Count == 0;\n\tif (v11) goto L_005E;\n\tv51 = this.data + 0x20;\n\tv44 = this.Count - 1;\n\tv114 = v44 <= index;\n\tif (v114) goto L_004A;\n\tv116 = index << 2;\n\tv145 = this.data + v116;\n\tv129 = v145 + 0x24;\n\tv128 = index;\nL_0037:\n\tv128 = v128 + 1;\n\t*([v129 @ X12_v6-4]) = *([v129 @ X12_v6]);\n\tv44 = this.Count - 1;\n\tv129 = v129 + 4;\n\tv150 = v128 < v44;\n\tif (v150) goto L_0037;\nL_004A:\n\tthis.Count = v44;\n\t*([v51 @ X9_v2+v44 @ X13_v3 (System.Int32)*4]) = 0;\n\treturn *([v51 @ X9_v2+index @ X1 (System.Int32)*4]);\nL_005E:\n\treturn 0;\n")]
		public T RemoveAt(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::RemoveAt");
			return default;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x626F92C", Offset = "0x626F92C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.data == 0;\n\tif (v20) goto L_00A6;\n\tv33 = this.Count < 1;\n\tif (v33) goto L_00A6;\n\tv52 = 0x20;\n\tv252 = 0;\nL_0022:\n\tv49 = item;\n\t// 39 Box v209 @ X0_v7 (System.Object), typeof(Il2CppClass<T>), &v49 @ stack_-44_v4 (T)\n\tv247 = this.data + v52;\n\tv46 = System.Int32::Equals(v247, v209);\n\tv272 = ~v46;\n\tv98 = ~v272;\n\tif (v98) goto L_004C;\n\tv252 = v252 + 1;\n\tv52 = v52 + 4;\n\tv62 = v252 < this.Count;\n\tif (v62) goto L_0022;\n\tgoto L_00A6;\nL_004C:\n\tv103 = this.data;\n\tv99 = this.data == 0;\n\tif (v99) goto L_00A6;\n\tv100 = this.Count == 0;\n\tif (v100) goto L_00A6;\n\tv124 = this.Count - 1;\n\tv288 = v124 <= v252;\n\tif (v288) goto L_0085;\n\tv291 = this.data + v52;\n\tv248 = v291 + 4;\nL_0072:\n\tv252 = v252 + 1;\n\t*([v248 @ X12_v5-4]) = *([v248 @ X12_v5]);\n\tv124 = this.Count - 1;\n\tv248 = v248 + 4;\n\tv297 = v252 < v124;\n\tif (v297) goto L_0072;\nL_0085:\n\tthis.Count = v124;\n\tv185 = this.data + 0x20;\n\t*([v185 @ X8_v13+v124 @ X11_v4 (System.Int32)*4]) = 0;\n\treturn *([v103 @ X8_v12 (T[])+v52 @ X23_v4 (System.Int32)]);\nL_00A6:\n\treturn 0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe T Remove(T item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::Remove");
			return default;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x626FA80", Offset = "0x626FA80", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.data == 0;\n\tif (v2) goto L_0019;\n\tv4 = this.Count == 0;\n\tif (v4) goto L_0019;\n\tv9 = this.Count - 1;\n\tthis.Count = v9;\n\tv33 = v9 << 2;\n\tv56 = this.data + v33;\n\t*([v56 @ X8_v2+20]) = 0;\n\treturn *([v56 @ X8_v2+20]);\nL_0019:\n\treturn 0;\n")]
		public T RemoveEnd()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::RemoveEnd");
			return default;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x626FAC8", Offset = "0x626FAC8", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = this.data == 0;\n\tif (v20) goto L_0060;\n\tv33 = this.Count < 1;\n\tif (v33) goto L_0060;\n\tv89 = 0x20;\n\tv92 = 0;\nL_0022:\n\tv84 = item;\n\t// 39 Box v164 @ X0_v7 (System.Object), typeof(Il2CppClass<T>), &v84 @ stack_-44_v3 (T)\n\tv192 = this.data + v89;\n\treturnVal3 = System.Int32::Equals(v192, v164);\n\tv194 = returnVal3 == 0;\n\tv127 = ~v194;\n\tif (v127) goto L_0055;\n\tv92 = v92 + 1;\n\tv89 = v89 + 4;\n\tv140 = v92 < this.Count;\n\tif (v140) goto L_0022;\nL_0055:\n\treturn returnVal3;\nL_0060:\n\treturn 0;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Contains(T item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SmallList::Contains");
			return default;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x626FBA0", Offset = "0x626FBA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SmallList()
		{
		}
	}
}
