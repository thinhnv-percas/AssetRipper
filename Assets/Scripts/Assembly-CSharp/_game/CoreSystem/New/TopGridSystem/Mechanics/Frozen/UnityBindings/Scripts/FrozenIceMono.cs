using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts
{
	[Token(Token = "0x2000239")]
	public class FrozenIceMono : MonoBehaviour
	{
		[Tooltip("Optional. If set, receives a 0..1 float (= 1 - remaining/total) on each update.")]
		[SerializeField]
		[Token(Token = "0x40006D9")]
		[FieldOffset(Offset = "0x20")]
		private Animator m_animator;

		[SerializeField]
		[Token(Token = "0x40006DA")]
		[FieldOffset(Offset = "0x28")]
		private string m_thawProgressParam;

		[Token(Token = "0x40006DB")]
		[FieldOffset(Offset = "0x30")]
		internal int _total;

		[Token(Token = "0x60009BB")]
		[Address(RVA = "0x3E99FF8", Offset = "0x3E99FF8", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ~totalFreezers;\n\tv2 = totalFreezers & v0;\n\tthis._total = v2;\n\t_game.CoreSystem.New.TopGridSystem.Mechanics.Frozen.UnityBindings.Scripts.FrozenIceMono::SetRemaining(this, v2);\n\treturn;\n")]
		public void Init(int totalFreezers)
		{
			int num = ~totalFreezers;
			SetRemaining(_total = totalFreezers & num);
		}

		[Token(Token = "0x60009BC")]
		[Address(RVA = "0x3E9A004", Offset = "0x3E9A004", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0019;\nL_0019:\n\tv56 = UnityEngine.Object::op_Equality(this.m_animator, 0);\n\tv65 = v56 == 0;\n\tif (v65) goto L_0034;\n\tgoto L_007D;\nL_0034:\n\tv79 = System.String::IsNullOrEmpty(this.m_thawProgressParam);\n\tv124 = v79 == 0;\n\tv113 = ~v124;\n\tif (v113) goto L_007D;\n\tv84 = this._total < 1;\n\tif (v84) goto L_007D;\n\tv179 = remaining / this._total;\n\tv180 = v179 < 1f;\n\tv181 = v179 == 1f;\n\tv184 = v179 == v179;\n\tv146 = 1f == 1f;\n\tv185 = v184 & v146;\n\tv186 = ~v185;\n\tv187 = v180 == v186;\n\tv133 = ~v181;\n\tv140 = v187 & v133;\n\tv188 = ~v140;\n\tif (v188) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv191 = 1f;\n\tgoto L_005F;\nL_FFFFFFFF:\n\tv191 = v179;\nL_FFFFFFFF:\n\tv138 = 1f;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv138 = v128;\nL_007D:\n\treturn;\nL_005F:\n\tv128 = 1f - v191;\n\tv150 = v179 < 0;\n\tv130 = ~v150;\n\tif (v130) goto L_FFFFFFFF;\nL_0074:\n\tUnityEngine.Animator::SetFloat(this.m_animator, this.m_thawProgressParam, v138);\n\treturn;\n")]
		public void SetRemaining(int remaining)
		{
			//IL_0152: Expected O, but got I4
			//IL_0145: Expected O, but got F4
			if (!(m_animator == null) && !string.IsNullOrEmpty(m_thawProgressParam) && _total >= 1)
			{
				int num = remaining / _total;
				bool flag = (float)num < 1f;
				bool flag2 = (float)num == 1f;
				bool flag3 = num == num;
				bool flag4 = 1f == 1f;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				object obj = ((!(flag7 && flag8)) ? ((object)num) : ((object)1f));
				float num2 = 1f - (float)obj;
				float value = ((num >= 0) ? num2 : 1f);
				m_animator.SetFloat(m_thawProgressParam, value);
			}
		}

		[Token(Token = "0x60009BD")]
		[Address(RVA = "0x3E9A108", Offset = "0x3E9A108", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.m_thawProgressParam = \"ThawProgress\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public FrozenIceMono()
		{
			m_thawProgressParam = "ThawProgress";
		}
	}
}
