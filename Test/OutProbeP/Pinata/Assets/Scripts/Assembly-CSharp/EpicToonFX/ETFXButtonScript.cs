using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.UI;

namespace EpicToonFX
{
	[Token(Token = "0x2000061")]
	public class ETFXButtonScript : MonoBehaviour
	{
		[Token(Token = "0x4000288")]
		[FieldOffset(Offset = "0x18")]
		public GameObject Button;

		[Token(Token = "0x4000289")]
		[FieldOffset(Offset = "0x20")]
		private Text MyButtonText;

		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0x28")]
		private string projectileParticleName;

		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0x30")]
		private ETFXFireProjectile effectScript;

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x38")]
		private ETFXProjectileScript projectileScript;

		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x40")]
		public float buttonsX;

		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x44")]
		public float buttonsY;

		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x48")]
		public float buttonsSizeX;

		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x4C")]
		public float buttonsSizeY;

		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x50")]
		public float buttonsDistance;

		[Token(Token = "0x600029F")]
		[Address(RVA = "0xA044C8", Offset = "0xA044C8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC00C0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C81]) = v38;\nL_0017:\n\tv43 = UnityEngine.GameObject::Find(\"ETFXFireProjectile\");\n\tv48 = UnityEngine.GameObject::GetComponent(v43);\n\tthis.effectScript = v48;\n\tEpicToonFX.ETFXButtonScript::getProjectileNames(this);\n\tv57 = UnityEngine.GameObject::get_transform(this.Button);\n\tv58 = UnityEngine.Transform::Find(v57, \"Text\");\n\tv59 = UnityEngine.Component::GetComponent(v58);\n\tthis.MyButtonText = v59;\n\tv83 = *([v59 @ X0_v11 (UnityEngine.UI.Text)]);\n\tv77 = this.projectileParticleName;\n\tv71 = *([v83 @ X8_v12 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv75 = *([v83 @ X8_v12 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 63 IndirectJump v71 @ X3_v1, v59 @ X0_v11 (UnityEngine.UI.Text), v59 @ X0_v11 (UnityEngine.UI.Text), v77 @ X1_v7 (System.String), v75 @ X2_v3, v71 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			//IL_0076: Expected I, but got O
			//IL_0090: Expected O, but got I
			//IL_00a0: Expected O, but got I
			while (true)
			{
				GameObject gameObject = GameObject.Find("ETFXFireProjectile");
				ETFXFireProjectile component = gameObject.GetComponent<ETFXFireProjectile>();
				effectScript = component;
				getProjectileNames();
				Transform transform = Button.transform;
				Transform transform2 = transform.Find("Text");
				IntPtr intPtr = (IntPtr)(MyButtonText = transform2.GetComponent<Text>());
				string text = projectileParticleName;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v12 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X8_v12 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v71 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0xA04648", Offset = "0xA04648", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.MyButtonText;\n\tv4 = *([v2 @ X0_v1 (UnityEngine.UI.Text)]);\n\tv5 = this.projectileParticleName;\n\tv6 = *([v4 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C0]);\n\tv7 = *([v4 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C8]);\n\t// 8 IndirectJump v6 @ X3_v1, v2 @ X0_v1 (UnityEngine.UI.Text), v2 @ X0_v1 (UnityEngine.UI.Text), v5 @ X1_v1 (System.String), v7 @ X2_v1, v6 @ X3_v1, v8 @ X4, v9 @ X5, v10 @ X6, v11 @ X7, v12 @ V0, v13 @ V1, v14 @ V2, v15 @ V3, v16 @ V4, v17 @ V5, v18 @ V6, v19 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Update()
		{
			//IL_0017: Expected I, but got O
			//IL_0031: Expected O, but got I
			//IL_0041: Expected O, but got I
			Text myButtonText = MyButtonText;
			IntPtr intPtr = (IntPtr)myButtonText;
			string text = projectileParticleName;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4 @ X9_v1 (Il2CppClass<UnityEngine.UI.Text>)+5C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0xA04594", Offset = "0xA04594", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F103D8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021C82]) = v38;\nL_0013:\n\tv39 = this.effectScript;\n\tv41 = v39.projectiles;\n\tv76 = v39.currentProjectile;\n\tv85 = v39.currentProjectile < v41.Length;\n\tv70 = ~v85;\n\tif (v70) goto L_0040;\n\tv111 = UnityEngine.GameObject::GetComponent(v41[v76 @ X9_v4 (System.Int32)]);\n\tthis.projectileScript = v111;\n\tv133 = UnityEngine.Object::get_name(v111.projectileParticle);\n\tthis.projectileParticleName = v133;\n\treturn;\n\tthrow System.NullReferenceException;\n\tv84 = new System.NullReferenceException();\nL_0040:\n\tv101 = new System.IndexOutOfRangeException();\n\tthrow v101;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void getProjectileNames()
		{
			ETFXFireProjectile eTFXFireProjectile = effectScript;
			GameObject[] projectiles = eTFXFireProjectile.projectiles;
			int currentProjectile = eTFXFireProjectile.currentProjectile;
			if (eTFXFireProjectile.currentProjectile < projectiles.Length)
			{
				string text = (projectileScript = projectiles[currentProjectile].GetComponent<ETFXProjectileScript>()).projectileParticle.name;
				projectileParticleName = text;
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0xA04674", Offset = "0xA04674", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0;\n\tv14 = 0;\n\tv22 = 0x10CCF64(&v12 @ stack_-30_v1, 0, v23, v24, v25, v26, v27, v28, this.buttonsX, this.buttonsY, this.buttonsSizeX, this.buttonsSizeY, v29, v30, v31, v32);\n\tv40 = this.buttonsX + this.buttonsDistance;\n\tv41 = 0x10CCF64(&v14 @ stack_-40_v1, 0, v23, v24, v25, v26, v27, v28, v40, this.buttonsY, this.buttonsSizeX, this.buttonsSizeY, this.buttonsX, v30, v31, v32);\n\tv43 = UnityEngine.Input::get_mousePosition();\n\tv48 = UnityEngine.Screen::get_height();\n\tv51 = UnityEngine.Input::get_mousePosition();\n\tv55 = v48 - v51.y;\n\tv57 = 0;\n\tv60 = 0x1588A6C(&v57 @ stack_-48_v1, 0, v23, v24, v25, v26, v27, v28, v43, v55, v51.z, this.buttonsSizeY, this.buttonsX, v30, v31, v32);\n\tv66 = 0x10CD1C8(&v12 @ stack_-30_v1, 0, v23, v24, v25, v26, v27, v28, 0, v63, v51.z, this.buttonsSizeY, this.buttonsX, v30, v31, v32);\n\tv67 = v66 & 1;\n\tv68 = v67 == 0;\n\tif (v68) goto L_0039;\n\tgoto L_0054;\nL_0039:\n\tv71 = UnityEngine.Input::get_mousePosition();\n\tv96 = UnityEngine.Screen::get_height();\n\tv98 = UnityEngine.Input::get_mousePosition();\n\tv101 = v96 - v98.y;\n\tv57 = 0;\n\tv105 = 0x1588A6C(&v57 @ stack_-48_v1, 0, v23, v24, v25, v26, v27, v28, v71, v101, v98.z, this.buttonsSizeY, this.buttonsX, v30, v31, v32);\n\tv78 = 0x10CD1C8(&v14 @ stack_-40_v1, 0, v23, v24, v25, v26, v27, v28, 0, v63, v98.z, this.buttonsSizeY, this.buttonsX, v30, v31, v32);\nL_0054:\n\treturnVal1 = v78 & 1;\n\treturn returnVal1;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool overButton()
		{
			//IL_0009: Expected O, but got I4
			//IL_0012: Expected O, but got I4
			//IL_0086: Expected O, but got I4
			//IL_0121: Expected O, but got I4
			object obj = 0;
			object obj2 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			float num = buttonsX + buttonsDistance;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			Vector3 mousePosition = Input.mousePosition;
			int height = Screen.height;
			float num2 = (float)height - Input.mousePosition.y;
			object obj3 = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD1C8 (inside UnityEngine.Rect::MinMaxRect +0x22C)");
			object obj4 = default(object);
			int num3 = default(int);
			if ((uint)((ulong)(long)(IntPtr)obj4 & 1uL) != 0)
			{
				num3 = 1;
			}
			else
			{
				Vector3 mousePosition2 = Input.mousePosition;
				int height2 = Screen.height;
				float num4 = (float)height2 - Input.mousePosition.y;
				obj3 = 0;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD1C8 (inside UnityEngine.Rect::MinMaxRect +0x22C)");
			}
			return (byte)(num3 & 1) != 0;
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0xA04780", Offset = "0xA04780", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXButtonScript()
		{
		}
	}
}
