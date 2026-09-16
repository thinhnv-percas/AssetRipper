using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[Token(Token = "0x200001A")]
	public class ConstrainedCamera : MonoBehaviour
	{
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x20")]
		public Transform target;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x28")]
		public Vector3 offset;

		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x34")]
		public Vector3 min;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x40")]
		public Vector3 max;

		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x4C")]
		public float smoothing;

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x150BEBC", Offset = "0x150BEBC", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv27 = UnityEngine.Transform::get_position(this.target);\n\tv141 = UnityEngine.Component::get_transform(this);\n\tv123 = UnityEngine.Component::get_transform(this);\n\tv216 = UnityEngine.Transform::get_position(v123);\n\tv218 = UnityEngine.Time::get_deltaTime();\n\tv219 = this.smoothing * v218;\n\tv110 = UnityEngine.Mathf::Min(v219, 1f);\n\tv51 = v219 < 0;\n\tv33 = ~v51;\n\tv30 = ~v33;\n\tif (v30) goto L_FFFFFFFF;\n\tgoto L_0055;\nL_0055:\n\tv228 = v27 + this.offset;\n\tv230 = v27.y + this.offset.y;\n\tv233 = v27.z + this.offset.z;\n\tv236 = v233 - this.max.z;\n\tv237 = v236 < 0;\n\tv238 = v236 == 0;\n\tv239 = v233 ^ this.max.z;\n\tv240 = v233 ^ v236;\n\tv241 = v239 & v240;\n\tv242 = v241 < 0;\n\tv243 = v237 == v242;\n\tv244 = ~v238;\n\tv245 = v243 & v244;\n\tv246 = ~v245;\n\tif (v246) goto L_FFFFFFFF;\n\tgoto L_0070;\nL_0070:\n\tv252 = v233 - this.min.z;\n\tv253 = v252 < 0;\n\tv259 = ~v253;\n\tv260 = ~v259;\n\tif (v260) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0080:\n\tv266 = v230 - this.max.y;\n\tv267 = v266 < 0;\n\tv268 = v266 == 0;\n\tv269 = v230 ^ this.max.y;\n\tv270 = v230 ^ v266;\n\tv271 = v269 & v270;\n\tv272 = v271 < 0;\n\tv273 = v263 - v216.z;\n\tv274 = v267 == v272;\n\tv275 = ~v268;\n\tv276 = v274 & v275;\n\tv277 = ~v276;\n\tif (v277) goto L_FFFFFFFF;\n\tgoto L_0093;\nL_0093:\n\tv283 = v230 - this.min.y;\n\tv284 = v283 < 0;\n\tv290 = v273 * v114;\n\tv291 = ~v284;\n\tv292 = ~v291;\n\tif (v292) goto L_FFFFFFFF;\n\tgoto L_00A4;\nL_00A4:\n\tv297 = v295 - v216.y;\n\tv204 = v216.z + v290;\n\tv300 = v228 - this.max;\n\tv301 = v300 < 0;\n\tv302 = v300 == 0;\n\tv303 = v228 ^ this.max;\n\tv304 = v228 ^ v300;\n\tv305 = v303 & v304;\n\tv306 = v305 < 0;\n\tv307 = v301 == v306;\n\tv149 = ~v302;\n\tv308 = v307 & v149;\n\tv309 = ~v308;\n\tif (v309) goto L_FFFFFFFF;\n\tgoto L_00BC;\nL_00BC:\n\tv172 = v228 - this.min;\n\tv170 = v172 < 0;\n\tv313 = v297 * v114;\n\tv158 = ~v170;\n\tv156 = ~v158;\n\tif (v156) goto L_FFFFFFFF;\n\tgoto L_00CB;\nL_00CB:\n\tv200 = v316 - v216;\n\tv317 = v200 * v114;\n\tv206 = v216.y + v313;\n\tv208 = v216 + v317;\n\t// 214 MakeStruct v144 @ AGG151000C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v208 @ V0_v12 (System.Single), v206 @ V1_v9 (System.Single), v204 @ V2_v8 (System.Single)\n\tUnityEngine.Transform::set_position(v141, v144);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			//IL_0158: Expected O, but got F4
			//IL_0165: Expected O, but got F4
			//IL_031f: Expected O, but got F4
			//IL_032c: Expected O, but got F4
			//IL_0461: Unknown result type (might be due to invalid IL or missing references)
			//IL_0466: Expected O, but got Unknown
			//IL_0473: Expected O, but got F4
			Vector3 position = target.position;
			Transform transform = base.transform;
			Transform transform2 = base.transform;
			Vector3 position2 = transform2.position;
			float deltaTime = Time.deltaTime;
			float num = smoothing * deltaTime;
			float num2 = Mathf.Min(num, 1f);
			float num3 = ((num < 0f) ? 0f : num2);
			float num4 = position.x + offset.x;
			float num5 = position.y + offset.y;
			float num6 = position.z + offset.z;
			float num7 = num6 - max.z;
			bool flag = num7 < 0f;
			bool flag2 = num7 == 0f;
			object obj = num6 ^ max.z;
			object obj2 = num6 ^ num7;
			int num8 = (int)((nint)obj & (nint)obj2);
			bool flag3 = num8 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float num9 = ((!(flag4 && flag5)) ? num6 : max.z);
			float num10 = num6 - min.z;
			float num11 = ((num10 < 0f) ? min.z : num9);
			float num12 = num5 - max.y;
			bool flag6 = num12 < 0f;
			bool flag7 = num12 == 0f;
			object obj3 = num5 ^ max.y;
			object obj4 = num5 ^ num12;
			int num13 = (int)((nint)obj3 & (nint)obj4);
			bool flag8 = num13 < 0;
			float num14 = num11 - position2.z;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			float num15 = ((!(flag9 && flag10)) ? num5 : max.y);
			float num16 = num5 - min.y;
			bool flag11 = num16 < 0f;
			float num17 = num14 * num3;
			float num18 = (flag11 ? min.y : num15);
			float num19 = num18 - position2.y;
			float z = position2.z + num17;
			float num20 = num4 - max.x;
			bool flag12 = num20 < 0f;
			bool flag13 = num20 == 0f;
			object obj5 = num4 ^ max;
			object obj6 = num4 ^ num20;
			int num21 = (int)((nint)obj5 & (nint)obj6);
			bool flag14 = num21 < 0;
			bool flag15 = flag12 == flag14;
			bool flag16 = !flag13;
			float num22 = ((!(flag15 && flag16)) ? num4 : max.x);
			float num23 = num4 - min.x;
			bool flag17 = num23 < 0f;
			float num24 = num19 * num3;
			float num25 = (flag17 ? min.x : num22);
			float num26 = num25 - position2.x;
			float num27 = num26 * num3;
			float y = position2.y + num24;
			float x = position2.x + num27;
			Vector3 position3 = default(Vector3);
			position3.x = x;
			position3.y = y;
			position3.z = z;
			transform.position = position3;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x150C014", Offset = "0x150C014", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.smoothing = 5f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ConstrainedCamera()
		{
			smoothing = 5f;
		}
	}
}
