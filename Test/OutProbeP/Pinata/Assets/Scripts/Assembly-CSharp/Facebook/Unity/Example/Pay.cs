using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x2000060")]
	internal class Pay : MenuBase
	{
		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x60")]
		private string payProduct;

		[Token(Token = "0x600029C")]
		[Address(RVA = "0xA0B504", Offset = "0xA0B504", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1ECA470]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC1]) = v38;\nL_0015:\n\tv41 = this + 0x60;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Product: \", v41);\n\tv48 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Call Pay\");\n\tv50 = v48 == 0;\n\tif (v50) goto L_002A;\n\tFacebook.Unity.Example.Pay::CallFBPay(this);\nL_002A:\n\tUnityEngine.GUILayout::Space(10f);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void GetGui()
		{
			LabelAndTextField("Product: ", ref *(string*)((long)(IntPtr)this + 96L));
			if (Button("Call Pay"))
			{
				CallFBPay();
			}
			GUILayout.Space(10f);
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0xA0B584", Offset = "0xA0B584", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EC62D0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021CC2]) = v40;\nL_0018:\n\tv45 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IPayResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IPayResult>::.ctor(v45, this, Il2CppMethodInfo);\n\tFacebook.Unity.FB+Canvas::Pay(this.payProduct, \"purchaseitem\", 1, 0, 0, 0, 0, 0, v45);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CallFBPay()
		{
			FacebookDelegate<IPayResult> callback = base.HandleResult;
			FB.Canvas.Pay(payProduct, "purchaseitem", 1, null, null, null, null, null, callback);
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0xA0B63C", Offset = "0xA0B63C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEAE80]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CC3]) = v38;\nL_0019:\n\tthis.payProduct = v43.Empty;\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Pay()
		{
			payProduct = string.Empty;
		}
	}
}
