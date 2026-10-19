using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.TextViewSystem
{
	[Token(Token = "0x200001C")]
	public class TimeTextView : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x20")]
		private TextView m_textView;

		[SerializeField]
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x28")]
		private string m_format;

		[SerializeField]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x30")]
		private string m_shortFormat;

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x81C2790", Offset = "0x81C2790", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv46 = UnityEngine.Component::GetComponentInChildren(this);\n\tthis.m_textView = v46;\n\treturn;\n")]
		private void Reset()
		{
			TextView componentInChildren = GetComponentInChildren<TextView>();
			m_textView = componentInChildren;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x81C27F4", Offset = "0x81C27F4", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = time;\n\tgoto L_001D;\n\tgoto L_002A;\nL_002A:\n\tv129 = System.TimeSpan::get_TotalHours(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv164 = v129 < 1d;\n\tv168 = v129 == v129;\n\tv169 = 1d == 1d;\n\tv170 = v168 & v169;\n\tv171 = ~v170;\n\tv85 = v164 == v171;\n\tif (v85) goto L_0057;\n\tgoto L_003E;\nL_003E:\n\tv180 = System.TimeSpan::get_Minutes(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv186 = v180;\n\tv188 = 0xB7D5000 + 0x538;\n\tv191 = \"il2cpp_vm_object_box\"(*([v188 @ X21_v6 (System.Int32)+48]), &v186 @ stack_-3C_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = System.TimeSpan::get_Seconds(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv211 = v208;\n\tv214 = \"il2cpp_vm_object_box\"(*([v188 @ X21_v6 (System.Int32)+48]), &v211 @ stack_-40_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv244 = System.String::Format(\"{0:00}:{1:00}\", v191, v214);\n\tgoto L_0093;\nL_0057:\n\tgoto L_005B;\nL_005B:\n\tv185 = System.TimeSpan::get_TotalHours(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv196 = v185 == 0x7FF0000000000000;\n\tv204 = ~v196;\n\tif (v204) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv215 = 0xFFFFFFFF80000000;\n\tgoto L_006E;\nL_FFFFFFFF:\n\tv215 = v185;\n\tv251 = System.TimeSpan::get_Seconds(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv238 = v251;\n\tv254 = \"il2cpp_vm_object_box\"(*([v218 @ X22_v5 (System.Int32)+48]), &v238 @ stack_-44_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv244 = System.String::Format(\"{0:00}:{1:00}:{2:00}\", v221, v236, v254);\nL_0093:\n\tv112 = Unco.TextViewSystem.TextView::SetText(this.m_textView, v244);\nL_001D:\n\tv46 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv50 = ~v46;\n\tif (v50) goto L_009B;\nL_009B:\n\treturn;\nL_006E:\n\tv216 = v215;\n\tv218 = 0xB7D5000 + 0x538;\n\tv221 = \"il2cpp_vm_object_box\"(*([v218 @ X22_v5 (System.Int32)+48]), &v216 @ stack_-3C_v3 (System.Double), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v185, 0x7FF0000000000000, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv232 = System.TimeSpan::get_Minutes(&v16 @ stack_-38_v1 (System.TimeSpan));\n\tv211 = v232;\n\tv236 = \"il2cpp_vm_object_box\"(*([v218 @ X22_v5 (System.Int32)+48]), &v211 @ stack_-40_v4 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public void SetTimeText(TimeSpan time)
		{
			//IL_015c: Expected F8, but got I4
			TimeSpan timeSpan = time;
			if (base.isActiveAndEnabled)
			{
				double totalHours = timeSpan.TotalHours;
				bool flag = totalHours < 1.0;
				bool flag2 = totalHours == totalHours;
				bool flag3 = 1.0 == 1.0;
				bool flag4 = flag2 && flag3;
				bool flag5 = !flag4;
				string text;
				if (flag != flag5)
				{
					int minutes = timeSpan.Minutes;
					int num = minutes;
					int num2 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					int seconds = timeSpan.Seconds;
					int num3 = seconds;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg = default(object);
					object arg2 = default(object);
					text = $"{arg:00}:{arg2:00}";
				}
				else
				{
					double totalHours2 = timeSpan.TotalHours;
					double num4 = ((totalHours2 != 9.218868437227405E+18) ? totalHours2 : (-2147483648.0));
					double num5 = num4;
					int num6 = 192761856 + 1336;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					int minutes2 = timeSpan.Minutes;
					int num3 = minutes2;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					int seconds2 = timeSpan.Seconds;
					int num7 = seconds2;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:il2cpp_vm_object_box", "Unknown call target operand: \"il2cpp_vm_object_box\"");
					object arg3 = default(object);
					object arg4 = default(object);
					object arg5 = default(object);
					text = $"{arg3:00}:{arg4:00}:{arg5:00}";
				}
				m_textView.SetText(text);
			}
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x81C29D0", Offset = "0x81C29D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public TimeTextView()
		{
		}
	}
}
