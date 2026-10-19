using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.SaveSystem.Core.Variables
{
	[Token(Token = "0x2000017")]
	public abstract class PermanentVariable<T> : IPermanentVariable
	{
		[CompilerGenerated]
		[Token(Token = "0x200001A")]
		private sealed class _003C_003Ec__DisplayClass32_0
		{
			[Token(Token = "0x400001F")]
			[FieldOffset(Offset = "0x0")]
			public PermanentVariable<T> _003C_003E4__this;

			[Token(Token = "0x4000020")]
			[FieldOffset(Offset = "0x0")]
			public SaveData data;

			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x5DBACE8", Offset = "0x5DBACE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass32_0()
			{
			}

			internal void _003CSaveLocal_003Eb__0(SaveData _)
			{
				_003C_003E4__this.SetRawData(data, isLocal: true);
			}
		}

		[Token(Token = "0x4000014")]
		[FieldOffset(Offset = "0x0")]
		private int LocalCounter;

		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x0")]
		private int RemoteCounter;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		private bool _inPending;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x0")]
		private int SaveLocalThreshold;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x0")]
		private int SaveRemoteThreshold;

		[Token(Token = "0x4000019")]
		[FieldOffset(Offset = "0x0")]
		private SaveData _localData;

		[Token(Token = "0x400001A")]
		[FieldOffset(Offset = "0x0")]
		private SaveData _remoteData;

		[Token(Token = "0x1700000A")]
		public T CurrentValue
		{
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x5ECBB80", Offset = "0x5ECBB80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.CurrentValue;\n")]
			get;
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0x5ECBB88", Offset = "0x5ECBB88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CurrentValue = value;\n\treturn;\n")]
			protected set;
		}

		[Token(Token = "0x1700000B")]
		public T PendingValue
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0x5ECBB90", Offset = "0x5ECBB90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+11]);\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::get_PendingValue");
				return default;
			}
			[CompilerGenerated]
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0x5ECBB98", Offset = "0x5ECBB98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+11]) = value;\n\treturn;\n")]
			private set
			{
			}
		}

		[Token(Token = "0x1700000C")]
		public string SaveKey
		{
			[CompilerGenerated]
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0x5ECBBA0", Offset = "0x5ECBBA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._localData;\n")]
			get
			{
				return (string)(object)_localData;
			}
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x5ECBBA8", Offset = "0x5ECBBA8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv38 = commonRemoteDateTime;\n\tgoto L_0034;\n\tv88 = Unco.SaveSystem.Core.Variables.SaveData::Empty();\n\tthis.SaveRemoteThreshold = v88;\n\tgoto L_0051;\nL_0051:\n\tv105 = Unco.SaveSystem.Core.DataHandler::GetJsonLocal(key, v82);\n\tthis._inPending = v105;\n\tv114 = Unco.SaveSystem.Core.Variables.SaveData::IsEmpty(this._inPending);\n\tv159 = remoteData == 0;\n\tif (v159) goto L_00B0;\n\tv160 = commonRemoteDateTime & 1;\n\tv161 = v160 == 0;\n\tif (v161) goto L_00B0;\n\tv155 = this.SaveRemoteThreshold;\n\tv129 = System.Nullable`1<System.DateTime>::get_Value(&v38 @ stack_-70_v1 (System.Nullable`1<System.DateTime>));\n\t*([v155 @ X22_v8 (System.Int32)+10]) = v129;\n\tv239 = this.SaveRemoteThreshold + 0x18;\n\tv239.m_value = remoteData;\n\tv144 = this.SaveRemoteThreshold;\n\tv267 = v114 == 0;\n\tv237 = ~v267;\n\tif (v237) goto L_FFFFFFFF;\n\tgoto L_008A;\nL_008A:\n\tv275 = this._inPending + 0x10;\n\tv277 = System.DateTime::ToUniversalTime(v275);\n\tv132 = System.DateTime::op_GreaterThanOrEqual(*([v144 @ X8_v15 (System.Int32)+10]), v277);\n\tv145 = this.SaveRemoteThreshold;\n\tv279 = ~v132;\n\tv238 = ~v279;\n\tif (v238) goto L_FFFFFFFF;\n\tgoto L_00A1;\nL_00A1:\n\tv285 = this._inPending + 0x10;\n\tv287 = System.DateTime::ToUniversalTime(v285);\n\tv225 = System.DateTime::op_LessThan(*([v145 @ X8_v17 (System.Int32)+10]), v287);\n\tv227 = ~v225;\n\tif (v227) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\nL_00B0:\n\tv212 = v114 == 0;\n\tif (v212) goto L_FFFFFFFF;\n\tv213 = initialValue;\n\t// 183 Box v218 @ X0_v33, typeof(Il2CppClass<T>), &v213 @ stack_-79_v2 (T)\nL_FFFFFFFF:\n\tv184 = v218;\n\tgoto L_00C2;\nL_FFFFFFFF:\n\tv184 = v261;\nL_0034:\n\tSystem.Object::.ctor(this);\n\tthis._localData = key;\n\tthis.LocalCounter = 0x100000000;\n\tv82 = Unco.SaveSystem.Core.Variables.SaveData::Empty();\nL_00C2:\n\tv192 = this->klass;\n\t*([v192 @ X8_v6 (Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>>)+208])(v186, this, v184, *([v192 @ X8_v6 (Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>>)+210]), remoteData, commonRemoteDateTime, v40, methodInfo, v51, 0x100000000, v53, v54, v55, v56, v57, v58, v59);\n\treturn;\n")]
		protected internal unsafe PermanentVariable(string key, T initialValue, object remoteData, DateTime? commonRemoteDateTime)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::.ctor");
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x5ECBE4C", Offset = "0x5ECBE4C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.CurrentValue;\n\tgoto L_0012;\nL_0012:\n\t;\n\treturnVal1 = System.Boolean::ToString(&v14 @ stack_-21_v1 (System.Boolean));\n\treturn returnVal1;\n")]
		public override string ToString()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::ToString");
			return default;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x5ECBEA4", Offset = "0x5ECBEA4", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.CurrentValue = value;\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::IncreaseCounter(this);\n\treturn;\n")]
		public void Set(T value)
		{
			CurrentValue = value;
			IncreaseCounter();
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x5ECBEB8", Offset = "0x5ECBEB8", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = isLocal == 0;\n\tv12 = ~v5;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 0x28;\n\tgoto L_0012;\nL_FFFFFFFF:\n\tv16 = 0x30;\nL_0012:\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+v16 @ X8_v2 (System.Int32)]) = data;\n\treturn;\n")]
		public void SetRawData(SaveData data, bool isLocal)
		{
			if (isLocal)
			{
				int num = 40;
			}
			else
			{
				int num = 48;
			}
		}

		[Token(Token = "0x60000A8")]
		public abstract void SetCurrentValue(object obj);

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x5ECBED4", Offset = "0x5ECBED4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~isLocal;\n\tif (v12) goto L_0019;\n\tv15 = this._inPending == 0;\nL_FFFFFFFF:\n\treturnVal1 = this._inPending;\n\tif (v15) goto L_0017;\n\tv19 = Unco.SaveSystem.Core.Variables.SaveData::IsEmpty(this._inPending);\n\tv24 = v19 == 0;\n\tif (v24) goto L_0027;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0019:\n\tv17 = this.SaveRemoteThreshold == 0;\nL_FFFFFFFF:\n\treturnVal1 = this.SaveRemoteThreshold;\n\tif (v17) goto L_0017;\n\tv30 = Unco.SaveSystem.Core.Variables.SaveData::IsEmpty(this.SaveRemoteThreshold);\n\tv47 = v30 == 0;\n\tif (v47) goto L_FFFFFFFF;\n\treturn 0;\nL_0027:\n\tv56 = this._inPending;\n\tv57 = ~this._inPending;\n\tv58 = ~v57;\n\tif (v58) goto L_0035;\n\tv64 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv56 = this.SaveRemoteThreshold;\nL_0035:\n\treturn *([v56 @ X8_v5 (System.Boolean)+10]);\nL_0017:\n\treturn returnVal1;\n")]
		public DateTime GetLastSavedTime(bool isLocal)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::GetLastSavedTime");
			return default;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x5ECBF54", Offset = "0x5ECBF54", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = isLocal == 0;\n\tv12 = ~v5;\n\tv13 = ~v12;\n\tif (v13) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv16 = 0x28;\n\tgoto L_0013;\nL_FFFFFFFF:\n\tv16 = 0x30;\nL_0013:\n\treturn *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+v16 @ X8_v2 (System.Int32)]);\n")]
		public SaveData GetRawData(bool isLocal)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::GetRawData");
			return default;
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x5ECBF6C", Offset = "0x5ECBF6C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.CurrentValue;\n\t// 10 Box returnVal1 @ X0_v2 (System.Object), typeof(Il2CppClass<T>), &v11 @ stack_-11_v1 (T)\n\treturn returnVal1;\n")]
		public object GetCurrentValue()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::GetCurrentValue");
			return default;
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x5ECBFA0", Offset = "0x5ECBFA0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.SaveRemoteThreshold;\n\tv2 = this.SaveRemoteThreshold == 0;\n\tif (v2) goto L_0006;\n\treturn *([v0 @ X8_v1 (System.Int32)+18]);\nL_0006:\n\treturn 0;\n")]
		protected internal object GetRemoteDataInner()
		{
			//IL_0036: Expected O, but got I
			int saveRemoteThreshold = SaveRemoteThreshold;
			if (SaveRemoteThreshold != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (System.Int32)+18]");
				return 0;
			}
			return null;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x5ECBFB8", Offset = "0x5ECBFB8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this._inPending;\n\tv2 = ~this._inPending;\n\tif (v2) goto L_0006;\n\treturn *([v0 @ X8_v1 (System.Boolean)+18]);\nL_0006:\n\treturn 0;\n")]
		protected internal object GetLocalDataInner()
		{
			//IL_0032: Expected O, but got I
			bool inPending = _inPending;
			if (_inPending)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v0 @ X8_v1 (System.Boolean)+18]");
				return 0;
			}
			return null;
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x5ECBFD0", Offset = "0x5ECBFD0", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveLocal(this, v24);\n\tv37 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveRemote(this, v37);\n\treturn;\n")]
		public void Save()
		{
			SaveData data = GenerateSaveData();
			SaveLocal(data);
			SaveData data2 = GenerateSaveData();
			SaveRemote(data2);
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0x5ECC060", Offset = "0x5ECC060", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveLocal(this, v17);\n\treturn;\n")]
		public void SaveLocalFromCurrent()
		{
			SaveData data = GenerateSaveData();
			SaveLocal(data);
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0x5ECC0A4", Offset = "0x5ECC0A4", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveRemote(this, v17);\n\treturn;\n")]
		public void SaveRemoteFromCurrent()
		{
			SaveData data = GenerateSaveData();
			SaveRemote(data);
		}

		[Token(Token = "0x60000B1")]
		[Address(RVA = "0x5ECC0E8", Offset = "0x5ECC0E8", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_002A:\n\tv66 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>+<>c__DisplayClass31_0<T>>();\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>+<>c__DisplayClass31_0<T>::.ctor(v66);\n\tv66.<>4__this = this;\n\tv66.data = data;\n\tv87 = v66.data;\n\tv136 = new System.Action`1<System.Object>();\n\tSystem.Action`1<System.Object>::.ctor(v136, v66, Il2CppMethodInfo);\n\tgoto L_0067;\nL_0067:\n\tUnco.SaveSystem.Core.DataHandler::SaveJson(this._localData, v87.obj, 0, v136);\n\treturn;\nL_0028:\n\tgoto L_002A;\n")]
		private void SaveRemote(SaveData data)
		{
			SaveData saveData = data;
			Action<object> onSaveComplete = delegate
			{
				SetRawData(data, isLocal: false);
			};
			DataHandler.SaveJson((string)(object)_localData, saveData.obj, isLocal: false, onSaveComplete);
		}

		[Token(Token = "0x60000B2")]
		[Address(RVA = "0x5ECC22C", Offset = "0x5ECC22C", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_002A:\n\tv66 = new Il2CppClass<Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>+<>c__DisplayClass32_0<T>>();\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>+<>c__DisplayClass32_0<T>::.ctor(v66);\n\tv73 = v66 == 0;\n\tif (v73) goto L_0066;\n\tv66.<>4__this = this;\n\tv66.data = data;\n\tv93 = new System.Action`1<Unco.SaveSystem.Core.Variables.SaveData>();\n\tSystem.Action`1<Unco.SaveSystem.Core.Variables.SaveData>::.ctor(v93, v66, Il2CppMethodInfo);\n\tgoto L_0064;\nL_0064:\n\tUnco.SaveSystem.Core.DataHandler::SaveJson(this._localData, v66.data, 1, v93);\n\treturn;\nL_0066:\n\tthrow v66;\nL_0028:\n\tgoto L_002A;\n")]
		private void SaveLocal(SaveData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::SaveLocal");
		}

		[Token(Token = "0x60000B3")]
		[Address(RVA = "0x5ECC368", Offset = "0x5ECC368", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_0020:\n\tUnco.SaveSystem.Core.DataHandler::DeleteLocal(this._localData);\n\tUnco.SaveSystem.Core.DataHandler::DeleteRemote(this._localData);\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) = 0;\n\tthis.CurrentValue = 0;\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::IncreaseCounter(this);\n\tv70 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveLocal(this, v70);\n\treturn;\nL_001C:\n\tgoto L_0020;\n")]
		public void DeleteData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::DeleteData");
		}

		[Token(Token = "0x60000B4")]
		[Address(RVA = "0x5ECC440", Offset = "0x5ECC440", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) = 0;\n\tthis.CurrentValue = 0;\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::IncreaseCounter(this);\n\tv24 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveLocal(this, v24);\n\treturn;\n")]
		public void ResetData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::ResetData");
		}

		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x5ECC4AC", Offset = "0x5ECC4AC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) != 1;\n\tif (v24) goto L_0022;\n\tthis.CurrentValue = *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+11]);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::IncreaseCounter(this);\nL_0022:\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) = 1;\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+11]) = data;\n\treturn;\n")]
		public void Pend(T data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::Pend");
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x5ECC518", Offset = "0x5ECC518", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]);\n")]
		public bool InPending()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]");
			return false;
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x5ECC520", Offset = "0x5ECC520", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) != 1;\n\tif (v11) goto L_0022;\n\tthis.CurrentValue = *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+11]);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::IncreaseCounter(this);\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+1C]) = 0;\nL_0022:\n\treturn;\n")]
		public void SetPendingToCurrent()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::SetPendingToCurrent");
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x5ECC570", Offset = "0x5ECC570", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~isLocal;\n\tif (v0) goto L_0004;\n\tthis.LocalCounter = index;\n\treturn;\nL_0004:\n\tthis.RemoteCounter = index;\n\treturn;\n")]
		public void SetThreshold(int index, bool isLocal)
		{
			if (isLocal)
			{
				LocalCounter = index;
			}
			else
			{
				RemoteCounter = index;
			}
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x5ECC584", Offset = "0x5ECC584", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv20 = *([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+14]) + 1;\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+14]) = v20;\n\tv34 = v20 <= this.LocalCounter;\n\tif (v34) goto L_0050;\n\t*([this @ X0 (Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>)+14]) = 0;\n\tv42 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveLocal(this, v42);\n\tv72 = this.<PendingValue>k__BackingField > this.RemoteCounter;\n\tif (v72) goto L_0052;\nL_0042:\n\treturn;\nL_0050:\n\tv57 = v44 <= this.RemoteCounter;\n\tif (v57) goto L_0042;\nL_0052:\n\tthis.<PendingValue>k__BackingField = 0;\n\tv100 = Unco.SaveSystem.Core.Variables.PermanentVariable`1<T>::GenerateSaveData(this);\n\tUnco.SaveSystem.Core.Variables.PermanentVariable`1<T>::SaveRemote(this, v100);\n\treturn;\n")]
		protected internal void IncreaseCounter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::IncreaseCounter");
		}

		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x5ECC670", Offset = "0x5ECC670", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_002A:\n\tv65 = System.DateTime::get_Now();\n\tv53.time = v65;\n\tv70 = this.CurrentValue;\n\t// 52 Box v73 @ X0_v10 (System.Object), typeof(Il2CppClass<T>), &v70 @ stack_-41_v1 (T)\n\tv53.obj = v73;\n\treturn v53;\nL_001F:\n\tv53 = new Unco.SaveSystem.Core.Variables.SaveData();\n\tUnco.SaveSystem.Core.Variables.SaveData::.ctor(v53);\n\tgoto L_002A;\n")]
		private SaveData GenerateSaveData()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PermanentVariable::GenerateSaveData");
			return default;
		}
	}
}
