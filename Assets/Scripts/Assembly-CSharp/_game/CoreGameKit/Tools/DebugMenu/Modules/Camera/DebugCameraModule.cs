using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.CameraControl;
using Debug = UnityEngine.Debug;

namespace _game.CoreGameKit.Tools.DebugMenu.Modules.Camera
{
	[Token(Token = "0x20005BF")]
	public class DebugCameraModule : IDebugModule
	{
		[CompilerGenerated]
		[Token(Token = "0x20005C1")]
		private sealed class _003CGetPinnedTriggers_003Ed__26 : IEnumerable<PinnedTriggerHandle>, IEnumerable, IEnumerator<PinnedTriggerHandle>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40013E2")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40013E3")]
			[FieldOffset(Offset = "0x18")]
			private PinnedTriggerHandle _003C_003E2__current;

			[Token(Token = "0x40013E4")]
			[FieldOffset(Offset = "0x30")]
			internal int _003C_003El__initialThreadId;

			[Token(Token = "0x40013E5")]
			[FieldOffset(Offset = "0x38")]
			public DebugCameraModule _003C_003E4__this;

			[Token(Token = "0x40013E6")]
			[FieldOffset(Offset = "0x40")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x17000255")]
			PinnedTriggerHandle IEnumerator<PinnedTriggerHandle>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018AF")]
				[Address(RVA = "0x3D3F788", Offset = "0x3D3F788", Length = "0x14")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule._003CGetPinnedTriggers_003Ed__26::get_Current");
					return default;
				}
			}

			[Token(Token = "0x17000256")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60018B1")]
				[Address(RVA = "0x3D3F7DC", Offset = "0x3D3F7DC", Length = "0x70")]
				get
				{
					global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule._003CGetPinnedTriggers_003Ed__26::get_Current");
					return default;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60018AC")]
			[Address(RVA = "0x3D39468", Offset = "0x3D39468", Length = "0x38")]
			public _003CGetPinnedTriggers_003Ed__26(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x60018AD")]
			[Address(RVA = "0x3D3F544", Offset = "0x3D3F544", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60018AE")]
			[Address(RVA = "0x3D3F548", Offset = "0x3D3F548", Length = "0x240")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule._003CGetPinnedTriggers_003Ed__26::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60018B0")]
			[Address(RVA = "0x3D3F79C", Offset = "0x3D3F79C", Length = "0x40")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x60018B2")]
			[Address(RVA = "0x3D3F84C", Offset = "0x3D3F84C", Length = "0xB4")]
			IEnumerator<PinnedTriggerHandle> IEnumerable<PinnedTriggerHandle>.GetEnumerator()
			{
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						return this;
					}
				}
				_003CGetPinnedTriggers_003Ed__26 _003CGetPinnedTriggers_003Ed__27 = (_003CGetPinnedTriggers_003Ed__26)FormatterServices.GetUninitializedObject(typeof(_003CGetPinnedTriggers_003Ed__26));
				_003CGetPinnedTriggers_003Ed__27._003C_003E1__state = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				_003CGetPinnedTriggers_003Ed__27._003C_003El__initialThreadId = currentManagedThreadId2;
				_003CGetPinnedTriggers_003Ed__27._003C_003E4__this = _003C_003E4__this;
				return _003CGetPinnedTriggers_003Ed__27;
			}

			[DebuggerHidden]
			[Token(Token = "0x60018B3")]
			[Address(RVA = "0x3D3F900", Offset = "0x3D3F900", Length = "0x4")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<PinnedTriggerHandle>)this).GetEnumerator();
			}
		}

		[Token(Token = "0x40013CF")]
		private const string k_ModuleId = "camera";

		[Token(Token = "0x40013D0")]
		private static readonly string[] k_EaseNames = new string[4] { "Linear", "SmoothStep", "EaseIn", "EaseOut" };

		[Token(Token = "0x40013D1")]
		private static readonly string[] k_SectionNames = new string[3] { "Live", "Presets", "Paths" };

		[Token(Token = "0x40013D2")]
		[FieldOffset(Offset = "0x10")]
		private readonly ICameraControlService _cameraService;

		[Token(Token = "0x40013D3")]
		[FieldOffset(Offset = "0x18")]
		private readonly DebugCameraData _data;

		[Token(Token = "0x40013D4")]
		[FieldOffset(Offset = "0x20")]
		private readonly DebugCameraPathPlayer _player;

		[Token(Token = "0x40013D5")]
		[FieldOffset(Offset = "0x28")]
		private int _activeSection;

		[Token(Token = "0x40013D6")]
		[FieldOffset(Offset = "0x2C")]
		private Vector2 _scroll;

		[Token(Token = "0x40013D7")]
		[FieldOffset(Offset = "0x38")]
		private string _newPresetName;

		[Token(Token = "0x40013D8")]
		[FieldOffset(Offset = "0x40")]
		private float _gotoDuration;

		[Token(Token = "0x40013D9")]
		[FieldOffset(Offset = "0x44")]
		private CameraEaseType _gotoEase;

		[Token(Token = "0x40013DA")]
		[FieldOffset(Offset = "0x48")]
		private string _newPathName;

		[Token(Token = "0x40013DB")]
		[FieldOffset(Offset = "0x50")]
		private int _selectedPathIndex;

		[Token(Token = "0x40013DC")]
		[FieldOffset(Offset = "0x54")]
		private int _hotkeyCaptureTarget;

		[Token(Token = "0x40013DD")]
		[FieldOffset(Offset = "0x58")]
		private CameraPose? _initialPose;

		[Token(Token = "0x40013DE")]
		[FieldOffset(Offset = "0x7C")]
		private Vector3 _eulerEdit;

		[Token(Token = "0x40013DF")]
		[FieldOffset(Offset = "0x88")]
		private bool _eulerSynced;

		[Token(Token = "0x17000252")]
		public string Id
		{
			[Token(Token = "0x600188A")]
			[Address(RVA = "0x3D3918C", Offset = "0x3D3918C", Length = "0x44")]
			get
			{
				return "camera";
			}
		}

		[Token(Token = "0x17000253")]
		public string DisplayName
		{
			[Token(Token = "0x600188B")]
			[Address(RVA = "0x3D391D0", Offset = "0x3D391D0", Length = "0x44")]
			get
			{
				return "Camera";
			}
		}

		[Token(Token = "0x17000254")]
		public int Order
		{
			[Token(Token = "0x600188C")]
			[Address(RVA = "0x3D39214", Offset = "0x3D39214", Length = "0x8")]
			get
			{
				return 10;
			}
		}

		[Token(Token = "0x6001889")]
		[Address(RVA = "0x3D390C0", Offset = "0x3D390C0", Length = "0xCC")]
		public DebugCameraModule(ICameraControlService cameraService, DebugCameraData data, DebugCameraPathPlayer player)
		{
			_newPresetName = "";
			_gotoDuration = 1f;
			_newPathName = "";
			_selectedPathIndex = -1;
			_hotkeyCaptureTarget = -1;
			_cameraService = cameraService;
			_data = data;
			_player = player;
		}

		[Token(Token = "0x600188D")]
		[Address(RVA = "0x3D3921C", Offset = "0x3D3921C", Length = "0x24")]
		public void OnPanelOpened()
		{
			CaptureInitialIfNeeded();
			_eulerSynced = false;
		}

		[Token(Token = "0x600188E")]
		[Address(RVA = "0x3D393DC", Offset = "0x3D393DC", Length = "0x4")]
		public void OnPanelClosed()
		{
		}

		[IteratorStateMachine(typeof(_003CGetPinnedTriggers_003Ed__26))]
		[Token(Token = "0x600188F")]
		[Address(RVA = "0x3D393E0", Offset = "0x3D393E0", Length = "0x88")]
		public IEnumerable<PinnedTriggerHandle> GetPinnedTriggers()
		{
			_003CGetPinnedTriggers_003Ed__26 _003CGetPinnedTriggers_003Ed__27 = new _003CGetPinnedTriggers_003Ed__26(-2);
			int currentManagedThreadId = Environment.CurrentManagedThreadId;
			_003CGetPinnedTriggers_003Ed__27._003C_003El__initialThreadId = currentManagedThreadId;
			_003CGetPinnedTriggers_003Ed__27._003C_003E4__this = this;
			return _003CGetPinnedTriggers_003Ed__27;
		}

		[Token(Token = "0x6001890")]
		[Address(RVA = "0x3D394A0", Offset = "0x3D394A0", Length = "0x2D0")]
		public void DrawGUI(Rect contentArea)
		{
			CaptureInitialIfNeeded();
			HandleHotkeyCapture();
			GUILayout.BeginArea(contentArea);
			string[] array = k_SectionNames;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCC2]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				int num = 187211776 + 1088;
			}
			else
			{
				_ = 1;
				int num = 187211776 + 1088;
				array = array;
			}
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption = GUILayout.Height(34f);
			GUILayoutOption[] array2 = default(GUILayoutOption[]);
			array2[0] = gUILayoutOption;
			int activeSection = GUILayout.Toolbar(_activeSection, array, DebugMenuStyle.s_tabInactive, array2);
			_activeSection = activeSection;
			GUILayout.Space(6f);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ X0_v53 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num3 = (int)((nint)0 & (nint)1);
			bool flag = num3 == 0;
			nint num4 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v272 @ X0_v36+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			Vector2 scrollPosition = default(Vector2);
			scrollPosition.x = _scroll.x;
			scrollPosition.y = _scroll.y;
			Vector2 vector = GUILayout.BeginScrollView(scrollPosition);
			_scroll.x = vector.x;
			_scroll.y = vector.y;
			if (_activeSection != 2)
			{
				if (_activeSection != 1)
				{
					if (_activeSection == 0)
					{
						DrawLive();
					}
				}
				else
				{
					DrawPresets();
				}
			}
			else
			{
				DrawPaths();
			}
			GUILayout.EndScrollView();
			GUILayout.EndArea();
		}

		[Token(Token = "0x6001891")]
		[Address(RVA = "0x3D398E0", Offset = "0x3D398E0", Length = "0x90C")]
		private unsafe void DrawLive()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawLive");
		}

		[Token(Token = "0x6001892")]
		[Address(RVA = "0x3D3AE6C", Offset = "0x3D3AE6C", Length = "0x408")]
		private float AxisRow(string label, float value, float min, float max, float labelWidth = 28f)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCD3]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v95 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			GUILayout.BeginHorizontal();
			int num4 = 187211776 + 1088;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption = GUILayout.Width(labelWidth);
			GUILayoutOption[] array = default(GUILayoutOption[]);
			array[0] = gUILayoutOption;
			GUILayout.Label(label, DebugMenuStyle.s_label, array);
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption2 = GUILayout.ExpandWidth(expand: true);
			GUILayoutOption[] array2 = default(GUILayoutOption[]);
			array2[0] = gUILayoutOption2;
			GUILayoutOption gUILayoutOption3 = GUILayout.Height(22f);
			array2[1] = gUILayoutOption3;
			float num5 = GUILayout.HorizontalSlider(value, min, max, array2);
			float num6 = default(float);
			string text = num6.ToString("0.###");
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption4 = GUILayout.Width(80f);
			GUILayoutOption[] array3 = default(GUILayoutOption[]);
			array3[0] = gUILayoutOption4;
			GUILayoutOption gUILayoutOption5 = GUILayout.Height(22f);
			array3[1] = gUILayoutOption5;
			string s = GUILayout.TextField(text, DebugMenuStyle.s_textField, array3);
			GUILayout.EndHorizontal();
			float num7 = Mathf.Abs(num5);
			float num8 = Mathf.Abs(num6);
			bool flag2 = num7 < num8;
			bool flag3 = num7 == num8;
			bool flag4 = num7 == num7;
			bool flag5 = num8 == num8;
			bool flag6 = flag4 && flag5;
			bool flag7 = !flag6;
			bool flag8 = flag2 == flag7;
			bool flag9 = !flag3;
			if (!(flag8 && flag9))
			{
				num7 = num8;
			}
			float num9 = num7 * 1E-06f;
			float num10 = Mathf.Epsilon * 8f;
			bool flag10 = num9 < num10;
			bool flag11 = num9 == num10;
			bool flag12 = num9 == num9;
			bool flag13 = num10 == num10;
			bool flag14 = flag12 && flag13;
			bool flag15 = !flag14;
			bool flag16 = flag10 == flag15;
			bool flag17 = !flag11;
			if (!(flag16 && flag17))
			{
				num9 = num10;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			bool flag18 = num10 < num9;
			bool flag19 = !flag18;
			float result = num5;
			if (!flag19)
			{
				result = ((!float.TryParse(s, out var result2)) ? num6 : result2);
			}
			return result;
		}

		[Token(Token = "0x6001893")]
		[Address(RVA = "0x3D3B27C", Offset = "0x3D3B27C", Length = "0xF0")]
		private static Vector3 NormalizeEuler(Vector3 euler)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			Vector3 vector = default(Vector3);
			float num = vector.x + vector.z;
			float num2 = num / vector.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			float num3 = num2 * vector.y;
			float num4 = num - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FCMGT not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction DUP not yet implemented.\"");
			float x = num4 + vector.y;
			Vector3 result = default(Vector3);
			result.x = x;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction BIT not yet implemented.\"");
			float num5 = vector.z + 180f;
			float f = num5 / 360f;
			float num6 = Mathf.Floor(f);
			float num7 = num6 * 360f;
			float num8 = num5 - num7;
			bool flag = num8 < 360f;
			bool flag2 = num8 == 360f;
			bool flag3 = num8 == num8;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			if (flag5 && flag6)
			{
			}
			if (num5 < num7)
			{
			}
			return result;
		}

		[Token(Token = "0x6001894")]
		[Address(RVA = "0x3D3B4F0", Offset = "0x3D3B4F0", Length = "0x44")]
		private static float NormalizeAngle(float angle)
		{
			float num = angle + 180f;
			float f = num / 360f;
			float num2 = Mathf.Floor(f);
			float num3 = num2 * 360f;
			float num4 = num - num3;
			bool flag = num4 < 360f;
			bool flag2 = num4 == 360f;
			bool flag3 = num4 == num4;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag2;
			float num5 = ((!(flag5 && flag6)) ? num4 : 360f);
			float result = num5 + -180f;
			if (num < num3)
			{
				return -180f;
			}
			return result;
		}

		[Token(Token = "0x6001895")]
		[Address(RVA = "0x3D3A1EC", Offset = "0x3D3A1EC", Length = "0x5E4")]
		private void DrawPresets()
		{
			BeginSection("Save Current as Preset");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X0_v122 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			GUILayout.BeginHorizontal();
			string text = ((_newPresetName != null) ? _newPresetName : "");
			int num4 = 187211776 + 1088;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption = GUILayout.ExpandWidth(expand: true);
			GUILayoutOption[] array = default(GUILayoutOption[]);
			array[0] = gUILayoutOption;
			GUILayoutOption gUILayoutOption2 = GUILayout.Height(28f);
			array[1] = gUILayoutOption2;
			string newPresetName = GUILayout.TextField(text, DebugMenuStyle.s_textField, array);
			_newPresetName = newPresetName;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption3 = GUILayout.Width(80f);
			GUILayoutOption[] array2 = default(GUILayoutOption[]);
			array2[0] = gUILayoutOption3;
			GUILayoutOption gUILayoutOption4 = GUILayout.Height(28f);
			array2[1] = gUILayoutOption4;
			if (GUILayout.Button("Save", DebugMenuStyle.s_buttonSuccess, array2))
			{
				TrySavePreset(_newPresetName);
				_newPresetName = "";
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.Space(6f);
			BeginSection("Goto Settings");
			float gotoDuration = ((DebugCameraModule)(object)"Goto Settings").AxisRow("Duration", _gotoDuration, 0.05f, 10f, 80f);
			_gotoDuration = gotoDuration;
			CameraEaseType gotoEase = ((DebugCameraModule)(object)"Goto Settings").DrawEaseRow("Ease", _gotoEase);
			_gotoEase = gotoEase;
			GUILayout.EndVertical();
			GUILayout.Space(6f);
			DebugCameraData data = _data;
			List<DebugCameraPreset> presets = data.Presets;
			int count = presets.Count;
			int num5 = 192761856 + 1336;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
			object arg = default(object);
			string text2 = $"Presets ({arg})";
			DebugMenuStyle.EnsureInit();
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ X0_v105 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num7 = (int)((nint)0 & (nint)1);
			bool flag2 = num7 == 0;
			nint num8 = 0;
			if (flag2)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ X0_v91+E4]");
				if ((nint)0 != 0)
				{
				}
			}
			GUILayout.Label(text2, DebugMenuStyle.s_sectionHeader);
			DebugCameraData data2 = _data;
			int num9 = 0;
			while (true)
			{
				List<DebugCameraPreset> presets2 = data2.Presets;
				if (num9 < presets2.Count && !DrawPresetRow(num9))
				{
					num9++;
					data2 = _data;
					if (_data == null)
					{
						throw new NullReferenceException();
					}
					continue;
				}
				break;
			}
		}

		[Token(Token = "0x6001896")]
		[Address(RVA = "0x3D3B534", Offset = "0x3D3B534", Length = "0x368")]
		private void TrySavePreset(string name)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::TrySavePreset");
		}

		[Token(Token = "0x6001897")]
		[Address(RVA = "0x3D3BB6C", Offset = "0x3D3BB6C", Length = "0xAC8")]
		private bool DrawPresetRow(int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawPresetRow");
			return default;
		}

		[Token(Token = "0x6001898")]
		[Address(RVA = "0x3D3C7BC", Offset = "0x3D3C7BC", Length = "0x240")]
		private void RenamePreset(int index, string newName)
		{
			//IL_00ef: Expected I4, but got I8
			string text = ((newName != null) ? newName : "");
			string text2 = text.Trim();
			if (string.IsNullOrEmpty(text2))
			{
				return;
			}
			DebugCameraData data = _data;
			DebugCameraPreset debugCameraPreset = data.Presets[index];
			if (debugCameraPreset.Name == text2)
			{
				return;
			}
			int num = FindPresetIndex(text2);
			if ((int)(num & 0x80000000L) == 0)
			{
				return;
			}
			debugCameraPreset.Name = text2;
			DebugCameraData data2 = _data;
			int num2 = 0;
			while (true)
			{
				List<DebugCameraPath> paths = data2.Paths;
				if (num2 >= paths.Count)
				{
					break;
				}
				DebugCameraPath debugCameraPath = paths[num2];
				if (debugCameraPath != null)
				{
					List<DebugCameraPathSegment> segments = debugCameraPath.Segments;
					if (debugCameraPath.Segments != null)
					{
						int num3 = 0;
						while (num3 < segments.Count)
						{
							DebugCameraPathSegment debugCameraPathSegment = segments[num3];
							if (debugCameraPathSegment.PresetName == debugCameraPreset.Name)
							{
								DebugCameraPathSegment debugCameraPathSegment2 = debugCameraPath.Segments[num3];
								debugCameraPathSegment2.PresetName = text2;
							}
							num3++;
							segments = debugCameraPath.Segments;
						}
					}
				}
				num2++;
				data2 = _data;
			}
			DebugMenuPersistence.Save("camera", data2);
		}

		[Token(Token = "0x6001899")]
		[Address(RVA = "0x3D3A7D0", Offset = "0x3D3A7D0", Length = "0x3FC")]
		private void DrawPaths()
		{
			//IL_0236: Expected I4, but got I8
			BeginSection("New Path");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X0_v84 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			GUILayout.BeginHorizontal();
			string text = ((_newPathName != null) ? _newPathName : "");
			int num4 = 187211776 + 1088;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption = GUILayout.ExpandWidth(expand: true);
			GUILayoutOption[] array = default(GUILayoutOption[]);
			array[0] = gUILayoutOption;
			GUILayoutOption gUILayoutOption2 = GUILayout.Height(28f);
			array[1] = gUILayoutOption2;
			string newPathName = GUILayout.TextField(text, DebugMenuStyle.s_textField, array);
			_newPathName = newPathName;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption3 = GUILayout.Width(80f);
			GUILayoutOption[] array2 = default(GUILayoutOption[]);
			array2[0] = gUILayoutOption3;
			GUILayoutOption gUILayoutOption4 = GUILayout.Height(28f);
			array2[1] = gUILayoutOption4;
			if (GUILayout.Button("Create", DebugMenuStyle.s_buttonSuccess, array2))
			{
				TryCreatePath(_newPathName);
				_newPathName = "";
			}
			GUILayout.EndHorizontal();
			GUILayout.EndVertical();
			GUILayout.Space(6f);
			DrawPathSelector();
			if ((int)(_selectedPathIndex & 0x80000000L) == 0)
			{
				DebugCameraData data = _data;
				List<DebugCameraPath> paths = data.Paths;
				if (_selectedPathIndex < paths.Count)
				{
					DrawPathEditor(_selectedPathIndex);
				}
			}
		}

		[Token(Token = "0x600189A")]
		[Address(RVA = "0x3D3CC6C", Offset = "0x3D3CC6C", Length = "0x47C")]
		private void DrawPathSelector()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawPathSelector");
		}

		[Token(Token = "0x600189B")]
		[Address(RVA = "0x3D3D0E8", Offset = "0x3D3D0E8", Length = "0xDF0")]
		private void DrawPathEditor(int pathIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawPathEditor");
		}

		[Token(Token = "0x600189C")]
		[Address(RVA = "0x3D3E250", Offset = "0x3D3E250", Length = "0x910")]
		private bool DrawSegmentRow(DebugCameraPath path, int segmentIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawSegmentRow");
			return default;
		}

		[Token(Token = "0x600189D")]
		[Address(RVA = "0x3D3EC4C", Offset = "0x3D3EC4C", Length = "0x6B8")]
		private void DrawPresetCycle(DebugCameraPathSegment seg)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawPresetCycle");
		}

		[Token(Token = "0x600189E")]
		[Address(RVA = "0x3D3B89C", Offset = "0x3D3B89C", Length = "0x2D0")]
		private CameraEaseType DrawEaseRow(string label, CameraEaseType current)
		{
			//IL_0009: Expected O, but got I4
			object obj = 192466944;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCDC]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
			}
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X0_v77 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+135]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			nint num3 = 0;
			if (flag)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			GUILayout.BeginHorizontal();
			int num4 = 187211776 + 1088;
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption = GUILayout.Width(80f);
			GUILayoutOption[] array = default(GUILayoutOption[]);
			array[0] = gUILayoutOption;
			GUILayout.Label(label, DebugMenuStyle.s_label, array);
			string[] array2 = k_EaseNames;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B78DCC2]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				_ = 1;
				array2 = array2;
			}
			DebugMenuStyle.EnsureInit();
			Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:SzArrayNew", "Unknown call target operand: \"SzArrayNew\"");
			GUILayoutOption gUILayoutOption2 = GUILayout.Height(26f);
			GUILayoutOption[] array3 = default(GUILayoutOption[]);
			array3[0] = gUILayoutOption2;
			int result = GUILayout.Toolbar((int)current, array2, DebugMenuStyle.s_tabInactive, array3);
			GUILayout.EndHorizontal();
			return (CameraEaseType)result;
		}

		[Token(Token = "0x600189F")]
		[Address(RVA = "0x3D3DED8", Offset = "0x3D3DED8", Length = "0x378")]
		private void DrawHotkeyButton(int pathIndex, DebugCameraPath path)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::DrawHotkeyButton");
		}

		[Token(Token = "0x60018A0")]
		[Address(RVA = "0x3D39770", Offset = "0x3D39770", Length = "0x170")]
		private void HandleHotkeyCapture()
		{
			//IL_018c: Expected I4, but got I8
			if ((int)(_hotkeyCaptureTarget & 0x80000000L) != 0)
			{
				return;
			}
			DebugCameraData data = _data;
			List<DebugCameraPath> paths = data.Paths;
			if (_hotkeyCaptureTarget >= paths.Count)
			{
				return;
			}
			Event current = Event.current;
			if (current == null)
			{
				return;
			}
			EventType type = current.type;
			if (type != EventType.KeyDown)
			{
				return;
			}
			if (current.keyCode != KeyCode.None)
			{
				KeyCode keyCode = current.keyCode;
				if (keyCode != KeyCode.Escape)
				{
					DebugCameraData data2 = _data;
					DebugCameraPath debugCameraPath = data2.Paths[_hotkeyCaptureTarget];
					KeyCode keyCode2 = current.keyCode;
					debugCameraPath.Hotkey = keyCode2;
					_hotkeyCaptureTarget = -1;
					DebugMenuPersistence.Save("camera", _data);
					current.Use();
					return;
				}
			}
			_hotkeyCaptureTarget = -1;
			current.Use();
		}

		[Token(Token = "0x60018A1")]
		[Address(RVA = "0x3D3C9FC", Offset = "0x3D3C9FC", Length = "0x270")]
		private void TryCreatePath(string name)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::TryCreatePath");
		}

		[Token(Token = "0x60018A2")]
		[Address(RVA = "0x3D3C634", Offset = "0x3D3C634", Length = "0xC8")]
		private int FindPresetIndex(string name)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::FindPresetIndex");
			return default;
		}

		[Token(Token = "0x60018A3")]
		[Address(RVA = "0x3D3B36C", Offset = "0x3D3B36C", Length = "0x184")]
		private void ApplyPoseInstant(CameraPose pose)
		{
			UnityEngine.Camera controlledCamera = _cameraService.ControlledCamera;
			if (controlledCamera == null)
			{
				return;
			}
			Transform transform = controlledCamera.transform;
			Vector3 position = default(Vector3);
			position.x = pose.Position.x;
			position.y = pose.Position.y;
			position.z = pose.Position.z;
			transform.position = position;
			Transform transform2 = controlledCamera.transform;
			Quaternion rotation = default(Quaternion);
			rotation.x = pose.Rotation.x;
			rotation.y = pose.Rotation.y;
			rotation.z = pose.Rotation.z;
			rotation.w = pose.Rotation.w;
			transform2.rotation = rotation;
			if (controlledCamera.orthographic)
			{
				bool flag = pose.OrthographicSize < 0f;
				bool flag2 = pose.OrthographicSize == 0f;
				bool flag3 = pose.OrthographicSize == pose.OrthographicSize;
				bool flag4 = !flag3;
				bool flag5 = flag == flag4;
				bool flag6 = !flag5;
				if (!(flag6 || flag2))
				{
					controlledCamera.orthographicSize = pose.OrthographicSize;
				}
			}
		}

		[Token(Token = "0x60018A4")]
		[Address(RVA = "0x3D3C6FC", Offset = "0x3D3C6FC", Length = "0xC0")]
		private static CameraPose CapturePose(UnityEngine.Camera cam)
		{
			Transform transform = cam.transform;
			Vector3 position = transform.position;
			Transform transform2 = cam.transform;
			Quaternion rotation = transform2.rotation;
			bool orthographic = cam.orthographic;
			bool flag = !orthographic;
			float orthographicSize = 0f;
			if (!flag)
			{
				orthographicSize = cam.orthographicSize;
			}
			CameraPose result = default(CameraPose);
			result.Position = position;
			_ = position.y;
			_ = position.z;
			result.Rotation = rotation;
			_ = rotation.y;
			_ = rotation.z;
			_ = rotation.w;
			result.OrthographicSize = orthographicSize;
			return result;
		}

		[Token(Token = "0x60018A5")]
		[Address(RVA = "0x488A4A4", Offset = "0x488A4A4", Length = "0x244")]
		private static void Swap<T>(IList<T> list, int a, int b)
		{
			object value = list[b];
			object value2 = list[a];
			list[a] = (T)value;
			list[b] = (T)value2;
		}

		[Token(Token = "0x60018A6")]
		[Address(RVA = "0x3D39240", Offset = "0x3D39240", Length = "0x19C")]
		private unsafe void CaptureInitialIfNeeded()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::CaptureInitialIfNeeded");
		}

		[Token(Token = "0x60018A7")]
		[Address(RVA = "0x3D3ABCC", Offset = "0x3D3ABCC", Length = "0x2A0")]
		private static void BeginSection(string header)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DebugCameraModule::BeginSection");
		}

		[Token(Token = "0x60018A8")]
		[Address(RVA = "0x3D3B274", Offset = "0x3D3B274", Length = "0x8")]
		private static void EndSection()
		{
			GUILayout.EndVertical();
		}
	}
}
