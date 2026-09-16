using System;
using System.Runtime.InteropServices;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000D0")]
	internal abstract class InteropObject : IInteropObject, IDisposable
	{
		[Token(Token = "0x40003BC")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		private readonly object locker;

		[Token(Token = "0x40003BD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		protected readonly HandleRef mSelfPointer;

		[Token(Token = "0x40003BE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		protected bool mIsDisposed;

		[Token(Token = "0x17000228")]
		public HandleRef SelfPointer
		{
			[Token(Token = "0x6000785")]
			[Address(RVA = "0xBFF818", Offset = "0xBFF818", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EE6F00]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F87]) = v38;\nL_0014:\n\tv40 = ~this.mIsDisposed;\n\tv41 = ~v40;\n\tif (v41) goto L_0022;\n\treturn this.mSelfPointer;\nL_0022:\n\tv51 = new System.InvalidOperationException();\n\tSystem.InvalidOperationException::.ctor(v51, \"Attempted to use object after it was cleaned up\");\n\tthrow v51;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!mIsDisposed)
				{
					return mSelfPointer;
				}
				InvalidOperationException ex = new InvalidOperationException("Attempted to use object after it was cleaned up");
				throw ex;
			}
		}

		[Token(Token = "0x6000783")]
		protected abstract void AttachHandle(HandleRef selfPointer);

		[Token(Token = "0x6000784")]
		protected abstract void ReleaseHandle(HandleRef selfPointer);

		[Token(Token = "0x6000786")]
		[Address(RVA = "0xBFF8A4", Offset = "0xBFF8A4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mIsDisposed;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsDisposed()
		{
			return mIsDisposed;
		}

		[Token(Token = "0x6000787")]
		[Address(RVA = "0xBFF8AC", Offset = "0xBFF8AC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv22 = *([1EE0D60]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, other, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F88]) = v41;\nL_0016:\n\tv43 = other == 0;\n\tif (v43) goto L_FFFFFFFF;\n\tv45 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\tv49 = other->klass;\n\tv53 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+126]) == 0;\n\tif (v53) goto L_003F;\n\tv155 = *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+B0]) + 8;\nL_002A:\n\tv161 = *([v155 @ X11_v6-8]) == EasyMobile.Internal.IInteropObject;\n\tif (v161) goto L_0044;\n\tv156 = v156 + 1;\n\tv166 = v156 < *([v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+126]);\n\tv137 = ~v166;\n\tv155 = v155 + 0x10;\n\tv121 = ~v137;\n\tif (v121) goto L_002A;\nL_003F:\n\tthis = 0x8909C4(other, EasyMobile.Internal.IInteropObject, 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0049;\n\tgoto L_005C;\nL_0044:\n\tv168 = *([v155 @ X11_v6]) + 3;\n\tv169 = v168 << 4;\n\tv170 = v49 + v169;\n\tthis = v170 + 0x130;\nL_0049:\n\tother = *([this @ X0 (EasyMobile.Internal.InteropObject)+8]);\n\t*([this @ X0 (EasyMobile.Internal.InteropObject)])(this, *([this @ X0 (EasyMobile.Internal.InteropObject)+8]), *([this @ X0 (EasyMobile.Internal.InteropObject)+8]), 3, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t// 82 Box this @ X0 (EasyMobile.Internal.InteropObject), typeof(System.IntPtr), &this @ X0 (EasyMobile.Internal.InteropObject)\n\tv104 = 0xDC4D34(&other @ X1 (EasyMobile.Internal.IInteropObject), this, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005C:\n\treturnVal1 = v104 & 1;\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool HasSamePointerWith(IInteropObject other)
		{
			//IL_0017: Expected I, but got O
			//IL_017d: Expected O, but got I
			//IL_018d: Expected I, but got O
			//IL_0052: Expected O, but got I
			//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e2: Expected O, but got Unknown
			//IL_00ff: Expected O, but got I
			//IL_010e: Expected O, but got I
			//IL_009e: Expected O, but got I
			InteropObject interopObject;
			if (other != null)
			{
				HandleRef selfPointer = SelfPointer;
				IntPtr intPtr = (IntPtr)other;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00b7;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X11_v6-8]");
					if ((IntPtr)0 == (IntPtr)typeof(IInteropObject))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v4 (Il2CppClass<EasyMobile.Internal.IInteropObject>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00b7;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				interopObject = (InteropObject)((long)(IntPtr)obj3 + 304L);
				goto IL_016d;
			}
			int num4 = 0;
			goto IL_0113;
			IL_016d:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (EasyMobile.Internal.InteropObject)+8]");
			IInteropObject interopObject2 = (IInteropObject)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (EasyMobile.Internal.InteropObject)] (should have been resolved before IL gen)");
			interopObject = (InteropObject)(object)(IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4D34 (inside System.IntPtr::get_Size +0xB8)");
			goto IL_0113;
			IL_00b7:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_016d;
			IL_0113:
			return (byte)(num4 & 1) != 0;
		}

		[Token(Token = "0x6000788")]
		[Address(RVA = "0xBFF9D0", Offset = "0xBFF9D0", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\treturn returnVal1;\n")]
		protected HandleRef SelfPtr()
		{
			return SelfPointer;
		}

		[Token(Token = "0x6000789")]
		[Address(RVA = "0xBFF9D4", Offset = "0xBFF9D4", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\tv12 = this->klass;\n\tv17 = this->klass->vtable[9];\n\tv18 = this->klass->vtable[9];\n\t// 19 IndirectJump v17 @ X5_v1, this @ X0 (EasyMobile.Internal.InteropObject), this @ X0 (EasyMobile.Internal.InteropObject), v10 @ X0_v1 (System.Runtime.InteropServices.HandleRef), methodInfo @ X1 (Il2CppMethodInfo), v18 @ X3_v1, methodInfo @ X1 (Il2CppMethodInfo), v17 @ X5_v1, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void AttachHandle()
		{
			//IL_000f: Expected I, but got O
			//IL_001f: Expected O, but got I
			//IL_002f: Expected O, but got I
			HandleRef selfPointer = SelfPointer;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600078A")]
		[Address(RVA = "0xBFFA10", Offset = "0xBFFA10", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\tv12 = this->klass;\n\tv17 = this->klass->vtable[10];\n\tv18 = this->klass->vtable[10];\n\t// 19 IndirectJump v17 @ X5_v1, this @ X0 (EasyMobile.Internal.InteropObject), this @ X0 (EasyMobile.Internal.InteropObject), v10 @ X0_v1 (System.Runtime.InteropServices.HandleRef), methodInfo @ X1 (Il2CppMethodInfo), v18 @ X3_v1, methodInfo @ X1 (Il2CppMethodInfo), v17 @ X5_v1, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected void ReleaseHandle()
		{
			//IL_000f: Expected I, but got O
			//IL_001f: Expected O, but got I
			//IL_002f: Expected O, but got I
			HandleRef selfPointer = SelfPointer;
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v12 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v17 @ X5_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600078B")]
		[Address(RVA = "0xBFFA4C", Offset = "0xBFFA4C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1ED5688]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, pointer, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F89]) = v41;\nL_0018:\n\tv45 = new System.Object();\n\tSystem.Object::.ctor(v45);\n\tthis.locker = v45;\n\tSystem.Object::.ctor(this);\n\tv51 = 0;\n\tv56 = 0xCE3718(&v51 @ stack_-40_v1 (System.Runtime.InteropServices.HandleRef), this, pointer, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = EasyMobile.Internal.PInvokeUtil::CheckNonNull(0);\n\tthis.mSelfPointer = v59;\n\tthis.mSelfPointer.m_handle = 0;\n\tv61 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\tv70 = EasyMobile.Internal.InteropObject::AttachHandle(this, v61);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal InteropObject(IntPtr pointer)
		{
			object obj = new object();
			locker = obj;
			HandleRef handleRef = default(HandleRef);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CE3718 (inside System.Runtime.InteropServices.GuidAttribute::.ctor +0x2C)");
			HandleRef handleRef2 = PInvokeUtil.CheckNonNull(default(HandleRef));
			mSelfPointer = handleRef2;
			mSelfPointer.m_handle = (IntPtr)0;
			HandleRef selfPointer = SelfPointer;
			AttachHandle(selfPointer);
		}

		[Token(Token = "0x600078C")]
		[Address(RVA = "0xBFFBAC", Offset = "0xBFFBAC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = EasyMobile.Internal.InteropObject::Cleanup(this);\n\tSystem.Object::Finalize(this);\n\treturn;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_002E;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19;\n\tX1 = 0;\n\tSystem.Object::Finalize(X0, X1);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002F;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 44 ShiftStack 32\n\treturn;\nL_002E:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_002F:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		~InteropObject()
		{
			Cleanup();
			base.Finalize();
		}

		[Token(Token = "0x600078D")]
		[Address(RVA = "0xBFFC20", Offset = "0xBFFC20", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFD438]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022F8A]) = v38;\nL_0017:\n\tv43 = EasyMobile.Internal.InteropObject::Cleanup(this);\n\tgoto L_002B;\n\tv50 = *([v46 @ X0_v4+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_002B;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v46, v42, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002B:\n\tSystem.GC::SuppressFinalize(this);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			Cleanup();
			GC.SuppressFinalize(this);
		}

		[Token(Token = "0x600078E")]
		[Address(RVA = "0xBFF9B8", Offset = "0xBFF9B8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\treturn methodInfo;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IntPtr ToPointer()
		{
			HandleRef selfPointer = SelfPointer;
			IntPtr result = default(IntPtr);
			return result;
		}

		[Token(Token = "0x600078F")]
		[Address(RVA = "0xBFFC98", Offset = "0xBFFC98", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Threading.Monitor::Enter(this.locker, &v19 @ stack_-34_v2 (System.Boolean));\n\tv23 = ~this.mIsDisposed;\n\tif (v23) goto L_0016;\n\tgoto L_0025;\nL_0016:\n\tv27 = EasyMobile.Internal.InteropObject::get_SelfPointer(this);\n\tv86 = this->klass;\n\tv79 = EasyMobile.Internal.InteropObject::ReleaseHandle(this, v27);\n\tthis.mIsDisposed = 1;\nL_0025:\n\tv84 = ~v19;\n\tif (v84) goto L_002A;\n\tSystem.Threading.Monitor::Exit(this.locker);\nL_002A:\n\tv103 = v67 + 1;\n\tv105 = v103 == 0;\n\tv108 = ~v105;\n\tif (v108) goto L_003B;\n\tv109 = v64 == 0;\n\tv71 = ~v109;\n\tif (v71) goto L_003F;\nL_003B:\n\treturn;\nL_003F:\n\tv118 = new System.TypeLoadException();\n\tgoto L_004B;\nL_004B:\n\tgoto L_0051;\n\tv140 = 0x6D2BC0(v118, 0, 0, *([v86 @ X8_v4 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1D8]), &v19 @ stack_-34_v2 (System.Boolean), v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98);\n\tv64 = *([v140 @ X0_v7]);\n\tv80 = 0x6D2490(v140, 0, 0, *([v86 @ X8_v4 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1D8]), &v19 @ stack_-34_v2 (System.Boolean), v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98);\n\tgoto L_0025;\nL_0051:\n\tv134 = 0x6D2380(v118, 0, 0, *([v86 @ X8_v4 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1D8]), &v19 @ stack_-34_v2 (System.Boolean), v88, v89, v90, v91, v92, v93, v94, v95, v96, v97, v98);\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected virtual void Cleanup()
		{
			//IL_0050: Expected I, but got O
			bool lockTaken = default(bool);
			Monitor.Enter(locker, ref lockTaken);
			int num;
			int num2;
			if (mIsDisposed)
			{
				num = 0;
				num2 = 0;
			}
			else
			{
				HandleRef selfPointer = SelfPointer;
				IntPtr intPtr = (IntPtr)this;
				ReleaseHandle(selfPointer);
				mIsDisposed = true;
				num = 0;
				num2 = 0;
			}
			if (lockTaken)
			{
				Monitor.Exit(locker);
			}
			if (num2 + 1 == 0 && num != 0)
			{
				TypeLoadException ex = new TypeLoadException();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			}
		}

		[Token(Token = "0x6000790")]
		[Address(RVA = "0xBFFD7C", Offset = "0xBFFD7C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE5BF0]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, obj, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2022F8B]) = v41;\nL_0015:\n\tv42 = v92 == 0;\n\tif (v42) goto L_0030;\n\tgoto L_FFFFFFFF;\n\tgoto L_0044;\nL_0030:\n\treturn 0;\n\tv78 = v78_asT == 0;\n\tif (v78) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tv131 = this->klass;\n\tv82 = this->klass->vtable[12];\n\tv80 = this->klass->vtable[12];\n\t// 78 IndirectJump v82 @ X3_v1, this @ X0 (EasyMobile.Internal.InteropObject), this @ X0 (EasyMobile.Internal.InteropObject), v92 @ X1_v1 (System.Object), v80 @ X2_v1, v82 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturn X0;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override bool Equals(object obj)
		{
			//IL_0075: Expected I, but got O
			//IL_0085: Expected O, but got I
			//IL_0095: Expected O, but got I
			object obj2 = default(object);
			if (obj2 == null)
			{
				return false;
			}
			InteropObject interopObject = obj2 as InteropObject;
			if ((object)interopObject == null)
			{
				obj2 = null;
			}
			IntPtr intPtr = (IntPtr)this;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v6 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1F0]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v6 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1F8]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v82 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000791")]
		[Address(RVA = "0xBFFE28", Offset = "0xBFFE28", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = other == 0;\n\tif (v14) goto L_FFFFFFFF;\n\tv16 = EasyMobile.Internal.PInvokeUtil::IsNull(this.mSelfPointer.m_handle);\n\tv28 = v16 == 0;\n\tif (v28) goto L_001A;\n\treturnVal2 = EasyMobile.Internal.PInvokeUtil::IsNull(other.mSelfPointer.m_handle);\n\treturn returnVal2;\nL_001A:\n\tv23 = System.IntPtr::op_Equality(this.mSelfPointer.m_handle, other.mSelfPointer.m_handle);\n\tv25 = v23 == 0;\n\tif (v25) goto L_FFFFFFFF;\n\tv104 = this.mIsDisposed == 0;\n\tv109 = ~v104;\n\tv46 = other.mIsDisposed == 0;\n\tv31 = ~v46;\n\tv61 = v109 ^ v31;\n\tv65 = v61 ^ 1;\n\tgoto L_003F;\nL_003F:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public virtual bool Equals(InteropObject other)
		{
			if ((object)other != null)
			{
				if (PInvokeUtil.IsNull(mSelfPointer.m_handle))
				{
					return PInvokeUtil.IsNull(other.mSelfPointer.m_handle);
				}
				if (mSelfPointer.m_handle == other.mSelfPointer.m_handle)
				{
					bool flag = !mIsDisposed;
					bool flag2 = !flag;
					bool flag3 = !other.mIsDisposed;
					bool flag4 = !flag3;
					bool flag5 = flag2 ^ flag4;
					return (byte)((flag5 ? 1u : 0u) ^ 1u) != 0;
				}
			}
			return false;
		}

		[Token(Token = "0x6000792")]
		[Address(RVA = "0xBFFEC8", Offset = "0xBFFEC8", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.mSelfPointer.m_handle;\n\treturnVal1 = 0xDC4DBC(&v6 @ X8_v1 (System.IntPtr), 0, v12, v13, v14, v15, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25);\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override int GetHashCode()
		{
			IntPtr handle = mSelfPointer.m_handle;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @DC4DBC (inside System.IntPtr::get_Size +0x140)");
			int result = default(int);
			return result;
		}

		[Token(Token = "0x6000793")]
		[Address(RVA = "0xBFFEA4", Offset = "0xBFFEA4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = objA == 0;\n\tif (v0) goto L_000A;\n\tv2 = objA->klass;\n\tv3 = objA->klass->vtable[12];\n\tv4 = objA->klass->vtable[12];\n\t// 5 IndirectJump v3 @ X3_v1, objA @ X0 (EasyMobile.Internal.InteropObject), objA @ X0 (EasyMobile.Internal.InteropObject), objB @ X1 (EasyMobile.Internal.InteropObject), v4 @ X2_v1, v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\nL_000A:\n\tv22 = objB == 0;\n\treturn v22;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator ==(InteropObject objA, InteropObject objB)
		{
			//IL_0025: Expected I, but got O
			//IL_0035: Expected O, but got I
			//IL_0045: Expected O, but got I
			if ((object)objA != null)
			{
				IntPtr intPtr = (IntPtr)objA;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1F0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<EasyMobile.Internal.InteropObject>)+1F8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
			}
			return (object)objB == null;
		}

		[Token(Token = "0x6000794")]
		[Address(RVA = "0xBFFEF4", Offset = "0xBFFEF4", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = objA == 0;\n\tif (v0) goto L_0012;\n\tv55 = EasyMobile.Internal.InteropObject::Equals(objA, objB);\n\tgoto L_0018;\nL_0012:\n\tv32 = objB == 0;\nL_0018:\n\tv67 = ~v55;\n\treturn v67;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool operator !=(InteropObject objA, InteropObject objB)
		{
			bool flag;
			if ((object)objA != null)
			{
				flag = objA.Equals(objB);
			}
			else
			{
				bool flag2 = (object)objB == null;
				flag = flag2;
			}
			return !flag;
		}
	}
}
