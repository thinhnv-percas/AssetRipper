using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;
using UnityEngine;

namespace Morpeh.Globals
{
	[Token(Token = "0x200001D")]
	public abstract class BaseGlobalVariable<TData> : BaseGlobalEvent<TData>
	{
		[Space]
		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x73DCC0", Offset = "0x73DCC0")]
		[SerializeField]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x0")]
		public TData value;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x0")]
		private TData lastValue;

		[Token(Token = "0x4000047")]
		private const string COMMON_KEY = "MORPEH__GLOBALS_VARIABLES_";

		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x0")]
		private string customKey;

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x0")]
		private string __internalKey;

		[AttributeAttribute(Type = typeof(HeaderAttribute), RVA = "0x73DD2C", Offset = "0x73DD2C")]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x0")]
		public bool AutoSave;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x0")]
		private bool isLoaded;

		[Token(Token = "0x17000014")]
		private string Key
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x109BB18", Offset = "0x109BB18", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF1C60]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026AF1]) = v38;\nL_0015:\n\tv41 = System.String::IsNullOrEmpty(this.__internalKey);\n\tv43 = v41 == 0;\n\tif (v43) goto L_0021;\n\treturnVal1 = System.String::Concat(\"MORPEH__GLOBALS_VARIABLES_\", this.customKey);\n\tthis.__internalKey = returnVal1;\n\tgoto L_0027;\nL_0021:\n\treturnVal1 = this.__internalKey;\nL_0027:\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return (!string.IsNullOrEmpty(__internalKey)) ? __internalKey : (__internalKey = "MORPEH__GLOBALS_VARIABLES_" + customKey);
			}
		}

		[Token(Token = "0x17000015")]
		public TData Value
		{
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x109BB8C", Offset = "0x109BB8C", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = ~this.isLoaded;\n\tv12 = ~v11;\n\tif (v12) goto L_0017;\n\tv19 = Morpeh.Globals.BaseGlobalVariable`1<TData>::LoadData(this);\n\tthis.isLoaded = 1;\nL_0017:\n\treturn this.value;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				if (!isLoaded)
				{
					LoadData();
					isLoaded = true;
				}
				return value;
			}
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x109BBD4", Offset = "0x109BBD4", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X3_v1, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), value @ X1 (TData), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::SetValue), v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000e: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x109BBF8", Offset = "0x109BBF8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.value = newValue;\n\tv6 = Il2CppMethodInfo;\n\tv7 = *([v6 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 7 IndirectJump v7 @ X3_v1, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), newValue @ X1 (TData), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::OnChange), v7 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetValue(TData newValue)
		{
			//IL_001d: Expected O, but got I
			value = newValue;
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v7 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x109BC20", Offset = "0x109BC20", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = UnityEngine.Application::get_isPlaying();\n\tv21 = v19 == 0;\n\tif (v21) goto L_0030;\n\tv33 = Morpeh.Globals.BaseGlobalEvent`1<TData>::CheckIsInitialized(this);\n\tv53 = Morpeh.Globals.BaseGlobalEvent`1<TData>::Publish(this, newValue);\n\tv61 = Il2CppMethodInfo;\n\tv62 = *([v61 @ X1_v3 (Il2CppMethodInfo)]);\n\t// 41 IndirectJump v62 @ X2_v2, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::SaveData), v62 @ X2_v2, v34 @ X3, v35 @ X4, v36 @ X5, v37 @ X6, v38 @ X7, v39 @ V0, v40 @ V1, v41 @ V2, v42 @ V3, v43 @ V4, v44 @ V5, v45 @ V6, v46 @ V7\nL_0030:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnChange(TData newValue)
		{
			//IL_0044: Expected O, but got I
			if (Application.isPlaying)
			{
				CheckIsInitialized();
				Publish(newValue);
				IntPtr intPtr = (IntPtr)0;
				object obj = (long)intPtr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X2_v2 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600009E")]
		protected abstract TData Load([NotNull] string serializedData);

		[Token(Token = "0x600009F")]
		protected abstract string Save();

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x109BCBC", Offset = "0x109BCBC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1EF48F8]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026AF2]) = v47;\nL_001F:\n\tv54 = Morpeh.Globals.BaseGlobalEvent`1<TData>::OnEnable(this);\n\tgoto L_0032;\n\tv63 = *([v57 @ X0_v9 (Il2CppClass<Morpeh.Globals.MApplicationFocusHook>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v57, v52, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = Morpeh.Globals.MApplicationFocusHook;\nL_0032:\n\tv75 = new System.Action();\n\tSystem.Action::.ctor(v75, this, Il2CppMethodInfo);\n\tv138 = System.Delegate::Combine(v71.OnApplicationFocusLost, v75);\n\tv134 = v138 == 0;\n\tif (v134) goto L_0049;\n\t// 70 IsInst v138 @ X0_v15 (System.Delegate), typeof(System.Action), v138 @ X0_v15 (System.Delegate)\n\tv90 = v138 == 0;\n\tif (v90) goto L_005D;\nL_0049:\n\tv84.OnApplicationFocusLost = v138;\n\tv119 = Il2CppMethodInfo;\n\tv112 = *([v119 @ X1_v7 (Il2CppMethodInfo)]);\n\t// 88 IndirectJump v112 @ X2_v4, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::LoadData), v112 @ X2_v4, 0, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\nL_005D:\n\tthrow System.InvalidCastException;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnEnable()
		{
			//IL_006e: Expected O, but got I
			base.OnEnable();
			Action b = SaveData;
			Delegate obj = Delegate.Combine(MApplicationFocusHook.OnApplicationFocusLost, b);
			if (obj != null)
			{
				obj = obj as Action;
				if ((object)obj == null)
				{
					goto IL_0078;
				}
			}
			MApplicationFocusHook.OnApplicationFocusLost = (Action)obj;
			IntPtr intPtr = (IntPtr)0;
			object obj2 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X2_v4 (should have been resolved before IL gen)");
			goto IL_0078;
			IL_0078:
			throw new InvalidCastException();
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x109BDE4", Offset = "0x109BDE4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv28 = *([1ECDD20]);\n\tv29 = *([v28 @ X8_v18]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2026AF3]) = v47;\nL_001F:\n\tv54 = Morpeh.Globals.BaseGlobalEvent`1<TData>::OnDisable(this);\n\tgoto L_0032;\n\tv63 = *([v57 @ X0_v9 (Il2CppClass<Morpeh.Globals.MApplicationFocusHook>)+E0]);\n\tv64 = v63 == 0;\n\tv65 = ~v64;\n\tif (v65) goto L_0032;\n\tv98 = \"il2cpp_codegen_runtime_class_init\"(v57, v52, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv67 = Morpeh.Globals.MApplicationFocusHook;\nL_0032:\n\tv75 = new System.Action();\n\tSystem.Action::.ctor(v75, this, Il2CppMethodInfo);\n\tv138 = System.Delegate::Remove(v71.OnApplicationFocusLost, v75);\n\tv134 = v138 == 0;\n\tif (v134) goto L_0049;\n\t// 70 IsInst v138 @ X0_v15 (System.Delegate), typeof(System.Action), v138 @ X0_v15 (System.Delegate)\n\tv90 = v138 == 0;\n\tif (v90) goto L_005D;\nL_0049:\n\tv84.OnApplicationFocusLost = v138;\n\tv119 = Il2CppMethodInfo;\n\tv112 = *([v119 @ X1_v7 (Il2CppMethodInfo)]);\n\t// 88 IndirectJump v112 @ X2_v4, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::SaveData), v112 @ X2_v4, 0, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\nL_005D:\n\tthrow System.InvalidCastException;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override void OnDisable()
		{
			//IL_006e: Expected O, but got I
			base.OnDisable();
			Action action = SaveData;
			Delegate obj = Delegate.Remove(MApplicationFocusHook.OnApplicationFocusLost, action);
			if (obj != null)
			{
				obj = obj as Action;
				if ((object)obj == null)
				{
					goto IL_0078;
				}
			}
			MApplicationFocusHook.OnApplicationFocusLost = (Action)obj;
			IntPtr intPtr = (IntPtr)0;
			object obj2 = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v112 @ X2_v4 (should have been resolved before IL gen)");
			goto IL_0078;
			IL_0078:
			throw new InvalidCastException();
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x109BF0C", Offset = "0x109BF0C", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = ~this.AutoSave;\n\tif (v15) goto L_0037;\n\tv21 = Morpeh.Globals.BaseGlobalVariable`1<TData>::get_Key(this);\n\tv37 = UnityEngine.PlayerPrefs::HasKey(v21);\n\tv41 = v37 == 0;\n\tif (v41) goto L_0037;\n\tv75 = Morpeh.Globals.BaseGlobalVariable`1<TData>::get_Key(this);\n\tv77 = UnityEngine.PlayerPrefs::GetString(v75);\n\tv78 = this->klass;\n\t*([v78 @ X8_v9 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1A0])(v83, this, v77, *([v78 @ X8_v9 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1A8]), v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tthis.value = v83;\n\tv53 = Il2CppMethodInfo;\n\tv49 = *([v53 @ X2_v2 (Il2CppMethodInfo)]);\n\t// 49 IndirectJump v49 @ X3_v1, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), v83 @ X0_v9 (TData), methodof(Morpeh.Globals.BaseGlobalVariable`1<TData>::OnChange), v49 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_0037:\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LoadData()
		{
			//IL_006b: Expected I, but got O
			//IL_008d: Expected O, but got I
			if (AutoSave)
			{
				string key = Key;
				if (PlayerPrefs.HasKey(key))
				{
					string key2 = Key;
					string text = PlayerPrefs.GetString(key2);
					IntPtr intPtr = (IntPtr)this;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v78 @ X8_v9 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1A0] (should have been resolved before IL gen)");
					TData val = default(TData);
					value = val;
					IntPtr intPtr2 = (IntPtr)0;
					object obj = (long)intPtr2;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v49 @ X3_v1 (should have been resolved before IL gen)");
				}
			}
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x109BFB8", Offset = "0x109BFB8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = ~this.AutoSave;\n\tif (v13) goto L_0025;\n\tv20 = Morpeh.Globals.BaseGlobalVariable`1<TData>::get_Key(this);\n\tv35 = this->klass;\n\t*([v35 @ X8_v5 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1B0])(v40, this, *([v35 @ X8_v5 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1B8]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tUnityEngine.PlayerPrefs::SetString(v20, v40);\n\treturn;\nL_0025:\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SaveData()
		{
			//IL_002a: Expected I, but got O
			if (AutoSave)
			{
				string key = Key;
				IntPtr intPtr = (IntPtr)this;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v35 @ X8_v5 (Il2CppClass<Morpeh.Globals.BaseGlobalVariable`1<TData>>)+1B0] (should have been resolved before IL gen)");
				string text = default(string);
				PlayerPrefs.SetString(key, text);
			}
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x109C020", Offset = "0x109C020", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X1_v1 (Il2CppMethodInfo)]);\n\t// 6 IndirectJump v6 @ X2_v1, this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), this @ X0 (Morpeh.Globals.BaseGlobalVariable`1<TData>), methodof(Morpeh.Globals.BaseGlobalEvent`1<TData>::.ctor), v6 @ X2_v1, v7 @ X3, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BaseGlobalVariable()
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		}
	}
}
