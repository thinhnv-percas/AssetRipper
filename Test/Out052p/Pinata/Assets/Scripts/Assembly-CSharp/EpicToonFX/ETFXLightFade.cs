using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EpicToonFX
{
	[Token(Token = "0x2000065")]
	public class ETFXLightFade : MonoBehaviour
	{
		[Attribute(Type = typeof(HeaderAttribute), RVA = "0x764D20", Offset = "0x764D20")]
		[Token(Token = "0x40002A9")]
		[FieldOffset(Offset = "0x18")]
		public float life;

		[Token(Token = "0x40002AA")]
		[FieldOffset(Offset = "0x1C")]
		public bool killAfterLife;

		[Token(Token = "0x40002AB")]
		[FieldOffset(Offset = "0x20")]
		private Light li;

		[Token(Token = "0x40002AC")]
		[FieldOffset(Offset = "0x28")]
		private float initIntensity;

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xA04CF0", Offset = "0xA04CF0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F028C0]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C85]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_gameObject(this);\n\tv48 = UnityEngine.GameObject::GetComponent(v43);\n\tgoto L_002D;\n\tv73 = *([v63 @ X8_v6+E0]);\n\tv74 = v73 == 0;\n\tv75 = ~v74;\n\tif (v75) goto L_002D;\n\tv111 = v63;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v111, v47, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv81 = UnityEngine.Object::op_Implicit(v48);\n\tv57 = UnityEngine.Component::get_gameObject(this);\n\tv99 = v81 == 0;\n\tif (v99) goto L_0047;\n\tv58 = UnityEngine.GameObject::GetComponent(v57);\n\tthis.li = v58;\n\tv88 = UnityEngine.Light::get_intensity(v58);\n\tthis.initIntensity = v88;\n\treturn;\nL_0047:\n\tv115 = UnityEngine.Object::get_name(v57);\n\tv97 = System.String::Concat(\"No light object found on \", v115);\n\tUnityEngine.MonoBehaviour::print(v97);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			GameObject gameObject = base.gameObject;
			Light component = gameObject.GetComponent<Light>();
			bool flag = component;
			GameObject gameObject2 = base.gameObject;
			if (flag)
			{
				float intensity = (li = gameObject2.GetComponent<Light>()).intensity;
				initIntensity = intensity;
			}
			else
			{
				string text = gameObject2.name;
				string message = "No light object found on " + text;
				MonoBehaviour.print(message);
			}
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xA04DFC", Offset = "0xA04DFC", Length = "0x168")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EE80E8]);\n\tv27 = *([v26 @ X8_v11]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021C86]) = v46;\nL_0019:\n\tv49 = UnityEngine.Component::get_gameObject(this);\n\tv54 = UnityEngine.GameObject::GetComponent(v49);\n\tgoto L_0030;\n\tv143 = *([v113 @ X8_v5+E0]);\n\tv144 = v143 == 0;\n\tv145 = ~v144;\n\tif (v145) goto L_0030;\n\tv150 = v113;\n\tv147 = \"il2cpp_codegen_runtime_class_init\"(v150, v53, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0030:\n\tv136 = UnityEngine.Object::op_Implicit(v54);\n\tv152 = v136 == 0;\n\tif (v152) goto L_0062;\n\tv221 = UnityEngine.Light::get_intensity(this.li);\n\tv223 = UnityEngine.Time::get_deltaTime();\n\tv224 = v223 / this.life;\n\tv225 = this.initIntensity * v224;\n\tv89 = v221 - v225;\n\tUnityEngine.Light::set_intensity(this.li, v89);\n\tv217 = ~this.killAfterLife;\n\tif (v217) goto L_0062;\n\tv90 = UnityEngine.Light::get_intensity(this.li);\n\tv226 = v90 < 0;\n\tv81 = ~v226;\n\tv72 = v90 == 0;\n\tv227 = ~v81;\n\tv57 = v227 | v72;\n\tif (v57) goto L_0065;\nL_0062:\n\treturn;\nL_0065:\n\tv102 = UnityEngine.Component::get_gameObject(this);\n\tv230 = UnityEngine.GameObject::GetComponent(v102);\n\tgoto L_0081;\n\tv235 = *([v206 @ X8_v8+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0081;\n\tv240 = v206;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v240, v229, v30, v31, v32, v33, v34, v35, v90, v83, v38, v39, v40, v41, v42, v43);\nL_0081:\n\tUnityEngine.Object::Destroy(v230);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			GameObject gameObject = base.gameObject;
			Light component = gameObject.GetComponent<Light>();
			if (!component)
			{
				return;
			}
			float intensity = li.intensity;
			float deltaTime = Time.deltaTime;
			float num = deltaTime / life;
			float num2 = initIntensity * num;
			float intensity2 = intensity - num2;
			li.intensity = intensity2;
			if (killAfterLife)
			{
				float intensity3 = li.intensity;
				bool flag = intensity3 < 0f;
				bool flag2 = !flag;
				bool flag3 = intensity3 == 0f;
				bool flag4 = !flag2;
				if (flag4 || flag3)
				{
					GameObject gameObject2 = base.gameObject;
					Light component2 = gameObject2.GetComponent<Light>();
					Object.Destroy(component2);
				}
			}
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xA04F64", Offset = "0xA04F64", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.life = 0.2f;\n\tthis.killAfterLife = 1;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXLightFade()
		{
			life = 0.2f;
			killAfterLife = true;
		}
	}
}
