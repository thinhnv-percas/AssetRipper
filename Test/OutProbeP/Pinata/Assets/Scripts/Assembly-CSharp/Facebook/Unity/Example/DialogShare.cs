using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Facebook.Unity.Example
{
	[Token(Token = "0x200005D")]
	internal class DialogShare : MenuBase
	{
		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x60")]
		private string shareLink;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x68")]
		private string shareTitle;

		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0x70")]
		private string shareDescription;

		[Token(Token = "0x400027D")]
		[FieldOffset(Offset = "0x78")]
		private string shareImage;

		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0x80")]
		private string feedTo;

		[Token(Token = "0x400027F")]
		[FieldOffset(Offset = "0x88")]
		private string feedLink;

		[Token(Token = "0x4000280")]
		[FieldOffset(Offset = "0x90")]
		private string feedTitle;

		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x98")]
		private string feedCaption;

		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0xA0")]
		private string feedDescription;

		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0xA8")]
		private string feedImage;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0xB0")]
		private string feedMediaSource;

		[Token(Token = "0x600028D")]
		[Address(RVA = "0xA07F78", Offset = "0xA07F78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected override bool ShowDialogModeSelector()
		{
			return true;
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0xA07F80", Offset = "0xA07F80", Length = "0x710")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EE8080]);\n\tv35 = *([v34 @ X8_v119]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2021CA7]) = v54;\nL_0021:\n\tgoto L_0028;\n\tv61 = *([v57 @ X0_v2+E0]);\n\tv62 = v61 == 0;\n\tv63 = ~v62;\n\tgoto L_0028;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v57, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0028:\n\tv69 = UnityEngine.GUI::get_enabled();\n\tv75 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Share - Link\");\n\tv77 = v75 == 0;\n\tif (v77) goto L_0062;\n\tv81 = new System.Uri();\n\tSystem.Uri::.ctor(v81, \"https://developers.facebook.com/\");\n\tv119 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>::.ctor(v119, this, Il2CppMethodInfo);\n\tgoto L_005D;\n\tv181 = *([v170 @ X0_v102+E0]);\n\tv182 = v181 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_005D;\n\tv185 = \"il2cpp_codegen_runtime_class_init\"(v170, v156, v157, v158, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_005D:\n\tFacebook.Unity.FB::ShareLink(v81, \"\", \"\", 0, v119);\nL_0062:\n\tv109 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Share - Link Photo\");\n\tv115 = v109 == 0;\n\tif (v115) goto L_009E;\n\tv123 = new System.Uri();\n\tSystem.Uri::.ctor(v123, \"https://developers.facebook.com/\");\n\tv175 = new System.Uri();\n\tSystem.Uri::.ctor(v175, \"http://i.imgur.com/j4M7vCO.jpg\");\n\tv200 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>::.ctor(v200, this, Il2CppMethodInfo);\n\tgoto L_009B;\n\tv230 = *([v217 @ X0_v94+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_009B;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v217, v210, v211, v212, v84, v82, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_009B:\n\tFacebook.Unity.FB::ShareLink(v123, \"Link Share\", \"Look I'm sharing a link\", v175, v200);\nL_009E:\n\tv150 = this + 0x60;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Link\", v150);\n\tv165 = this + 0x68;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Title\", v165);\n\tv178 = this + 0x70;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Description\", v178);\n\tv194 = this + 0x78;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Image\", v194);\n\tv205 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Share - Custom\");\n\tv214 = v205 == 0;\n\tif (v214) goto L_00FC;\n\tv227 = new System.Uri();\n\tSystem.Uri::.ctor(v227, this.shareLink);\n\tv294 = new System.Uri();\n\tSystem.Uri::.ctor(v294, this.shareImage);\n\tv341 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>::.ctor(v341, this, Il2CppMethodInfo);\n\tgoto L_00EF;\n\tv434 = *([v366 @ X0_v84+E0]);\n\tv435 = v434 == 0;\n\tv436 = ~v435;\n\tif (v436) goto L_00EF;\n\tv438 = \"il2cpp_codegen_runtime_class_init\"(v366, v352, v353, v354, v128, v126, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00EF:\n\tFacebook.Unity.FB::ShareLink(v227, this.shareTitle, this.shareDescription, v294, v341);\n\tv451 = v69 == 0;\n\tv268 = ~v451;\n\tif (v268) goto L_00FF;\n\tgoto L_0121;\nL_00FC:\n\tv229 = v69 == 0;\n\tif (v229) goto L_FFFFFFFF;\nL_00FF:\n\tv272 = Facebook.Unity.Constants::get_IsEditor();\n\tv296 = v272 == 0;\n\tif (v296) goto L_FFFFFFFF;\n\tv328 = Facebook.Unity.Constants::get_IsEditor();\n\tv343 = v328 == 0;\n\tif (v343) goto L_FFFFFFFF;\n\tgoto L_0115;\n\tv370 = *([v357 @ X0_v72+E0]);\n\tv371 = v370 == 0;\n\tv372 = ~v371;\n\tif (v372) goto L_0115;\n\tv374 = \"il2cpp_codegen_runtime_class_init\"(v357, v263, v261, v254, v252, v250, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0115:\n\tv378 = Facebook.Unity.FB::get_IsLoggedIn();\n\tgoto L_FFFFFFFF;\n\tgoto L_0121;\nL_0121:\n\tgoto L_0129;\n\tv329 = *([v320 @ X0_v19+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tgoto L_0129;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v320, v313, v312, v306, v305, v304, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0129:\n\tUnityEngine.GUI::set_enabled(v309);\n\tv348 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Feed Share - No To\");\n\tv363 = v348 == 0;\n\tif (v363) goto L_0179;\n\tv389 = new System.Uri();\n\tSystem.Uri::.ctor(v389, \"https://developers.facebook.com/\");\n\tv453 = new System.Uri();\n\tSystem.Uri::.ctor(v453, \"http://i.imgur.com/zkYlB.jpg\");\n\tv473 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>::.ctor(v473, this, Il2CppMethodInfo);\n\tgoto L_0175;\n\tv502 = *([v493 @ X0_v61+E0]);\n\tv503 = v502 == 0;\n\tv504 = ~v503;\n\tif (v504) goto L_0175;\n\tv506 = \"il2cpp_codegen_runtime_class_init\"(v493, v482, v483, v484, v305, v304, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0175:\n\tFacebook.Unity.FB::FeedShare(v385.Empty, v389, \"Test Title\", \"Test caption\", \"Test Description\", v453, v470.Empty, v473);\nL_0179:\n\tv430 = this + 0x80;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"To\", v430);\n\tv446 = this + 0x88;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, *([v302 @ X27_v3 (System.String)]), v446);\n\tv455 = this + 0x90;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Title\", v455);\n\tv464 = this + 0x98;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Caption\", v464);\n\tv475 = this + 0xA0;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, *([v412 @ X22_v6 (System.String)]), v475);\n\tv487 = this + 0xA8;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Image\", v487);\n\tv499 = this + 0xB0;\n\tFacebook.Unity.Example.ConsoleBase::LabelAndTextField(this, \"Media Source\", v499);\n\tv515 = Facebook.Unity.Example.ConsoleBase::Button(this, \"Feed Share - Custom\");\n\tv517 = v515 == 0;\n\tif (v517) goto L_01FB;\n\tv521 = System.String::IsNullOrEmpty(*([v446 @ X25_v3 (System.String&)]));\n\tv571 = v521 == 0;\n\tv572 = ~v571;\n\tif (v572) goto L_01C1;\n\tv598 = new System.Uri();\n\tSystem.Uri::.ctor(v598, *([v446 @ X25_v3 (System.String&)]));\nL_01C1:\n\tv609 = System.String::IsNullOrEmpty(*([v487 @ X26_v3 (System.String&)]));\n\tv612 = v609 == 0;\n\tv613 = ~v612;\n\tif (v613) goto L_01D4;\n\tv618 = new System.Uri();\n\tSystem.Uri::.ctor(v618, *([v487 @ X26_v3 (System.String&)]));\nL_01D4:\n\tv630 = new Facebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>();\n\tFacebook.Unity.FacebookDelegate`1<Facebook.Unity.IShareResult>::.ctor(v630, this, Il2CppMethodInfo);\n\tgoto L_01F3;\n\tv644 = *([v640 @ X0_v47+E0]);\n\tv645 = v644 == 0;\n\tv646 = ~v645;\n\tif (v646) goto L_01F3;\n\tv648 = \"il2cpp_codegen_runtime_class_init\"(v640, v634, v636, v637, v408, v406, v395, v393, v44, v45, v46, v47, v48, v49, v50, v51);\nL_01F3:\n\tFacebook.Unity.FB::FeedShare(*([v430 @ X21_v5 (System.String&)]), v547, *([v455 @ X23_v4 (System.String&)]), *([v464 @ X24_v5 (System.String&)]), *([v475 @ X27_v4 (System.String&)]), v537, this.feedMediaSource, v630);\nL_01FB:\n\tgoto L_0210;\n\tv573 = *([v565 @ X0_v35+E0]);\n\tv574 = v573 == 0;\n\tv575 = ~v574;\n\tgoto L_0210;\n\tv577 = \"il2cpp_codegen_runtime_class_init\"(v565, v553, v551, v544, v542, v540, v526, v524, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0210:\n\tUnityEngine.GUI::set_enabled(v532);\n\treturn;\n// 373 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected unsafe override void GetGui()
		{
			//IL_02d5: Expected O, but got Ref
			bool flag = GUI.enabled;
			if (Button("Share - Link"))
			{
				Uri contentURL = new Uri("https://developers.facebook.com/");
				FacebookDelegate<IShareResult> callback = base.HandleResult;
				FB.ShareLink(contentURL, "", "", null, callback);
			}
			if (Button("Share - Link Photo"))
			{
				Uri contentURL2 = new Uri("https://developers.facebook.com/");
				Uri photoURL = new Uri("http://i.imgur.com/j4M7vCO.jpg");
				FacebookDelegate<IShareResult> callback2 = base.HandleResult;
				FB.ShareLink(contentURL2, "Link Share", "Look I'm sharing a link", photoURL, callback2);
			}
			LabelAndTextField("Link", ref *(string*)((long)(IntPtr)this + 96L));
			LabelAndTextField("Title", ref *(string*)((long)(IntPtr)this + 104L));
			LabelAndTextField("Description", ref *(string*)((long)(IntPtr)this + 112L));
			ref string reference = ref *(string*)((long)(IntPtr)this + 120L);
			LabelAndTextField("Image", ref reference);
			string label;
			string label2;
			string text;
			string text2;
			object obj;
			if (Button("Share - Custom"))
			{
				Uri contentURL3 = new Uri(shareLink);
				Uri photoURL2 = new Uri(shareImage);
				FacebookDelegate<IShareResult> callback3 = base.HandleResult;
				FB.ShareLink(contentURL3, shareTitle, shareDescription, photoURL2, callback3);
				bool flag2 = !flag;
				bool flag3 = !flag2;
				label = "Link";
				label2 = "Description";
				reference = ref *(string*)shareDescription;
				text = "Link";
				text2 = "Description";
				obj = shareDescription;
				if (!flag3)
				{
					goto IL_0282;
				}
			}
			else
			{
				bool flag4 = !flag;
				label = "Link";
				label2 = "Description";
				text = "Link";
				text2 = "Description";
				obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
				if (flag4)
				{
					goto IL_0282;
				}
			}
			int num;
			int num2;
			if (Constants.IsEditor)
			{
				if (Constants.IsEditor)
				{
					bool isLoggedIn = FB.IsLoggedIn;
					num = (isLoggedIn ? 1 : 0);
				}
				else
				{
					num = 0;
				}
				num2 = 1;
				label = text;
				label2 = text2;
				reference = ref *(string*)obj;
			}
			else
			{
				num2 = 1;
				label = text;
				label2 = text2;
				num = 1;
				reference = ref *(string*)obj;
			}
			goto IL_0388;
			IL_0388:
			GUI.enabled = (byte)num != 0;
			if (Button("Feed Share - No To"))
			{
				Uri link = new Uri("https://developers.facebook.com/");
				Uri picture = new Uri("http://i.imgur.com/zkYlB.jpg");
				FacebookDelegate<IShareResult> callback4 = base.HandleResult;
				FB.FeedShare(string.Empty, link, "Test Title", "Test caption", "Test Description", picture, string.Empty, callback4);
			}
			ref string reference2 = ref *(string*)((long)(IntPtr)this + 128L);
			LabelAndTextField("To", ref reference2);
			ref string reference3 = ref *(string*)((long)(IntPtr)this + 136L);
			LabelAndTextField(label, ref reference3);
			ref string reference4 = ref *(string*)((long)(IntPtr)this + 144L);
			LabelAndTextField("Title", ref reference4);
			ref string reference5 = ref *(string*)((long)(IntPtr)this + 152L);
			LabelAndTextField("Caption", ref reference5);
			ref string reference6 = ref *(string*)((long)(IntPtr)this + 160L);
			LabelAndTextField(label2, ref reference6);
			ref string reference7 = ref *(string*)((long)(IntPtr)this + 168L);
			LabelAndTextField("Image", ref reference7);
			LabelAndTextField("Media Source", ref *(string*)((long)(IntPtr)this + 176L));
			if (Button("Feed Share - Custom"))
			{
				bool flag5 = string.IsNullOrEmpty(reference3);
				bool flag6 = !flag5;
				bool flag7 = !flag6;
				Uri link2 = null;
				if (!flag7)
				{
					Uri uri = new Uri(reference3);
					link2 = uri;
				}
				bool flag8 = string.IsNullOrEmpty(reference7);
				bool flag9 = !flag8;
				bool flag10 = !flag9;
				Uri picture2 = null;
				if (!flag10)
				{
					Uri uri2 = new Uri(reference7);
					picture2 = uri2;
				}
				FacebookDelegate<IShareResult> callback5 = base.HandleResult;
				FB.FeedShare(reference2, link2, reference4, reference5, reference6, picture2, feedMediaSource, callback5);
			}
			GUI.enabled = (byte)num2 != 0;
			return;
			IL_0282:
			num2 = 0;
			num = 0;
			goto IL_0388;
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0xA08690", Offset = "0xA08690", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1F0E6D8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021CA8]) = v38;\nL_001B:\n\tthis.shareLink = \"https://developers.facebook.com/\";\n\tthis.shareTitle = \"Link Title\";\n\tthis.shareDescription = \"Link Description\";\n\tthis.shareImage = \"http://i.imgur.com/j4M7vCO.jpg\";\n\tthis.feedTo = v56.Empty;\n\tthis.feedLink = \"https://developers.facebook.com/\";\n\tthis.feedTitle = \"Test Title\";\n\tthis.feedCaption = \"Test Caption\";\n\tthis.feedDescription = \"Test Description\";\n\tthis.feedImage = \"http://i.imgur.com/zkYlB.jpg\";\n\tthis.feedMediaSource = v69.Empty;\n\tFacebook.Unity.Example.MenuBase::.ctor(this);\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DialogShare()
		{
			shareLink = "https://developers.facebook.com/";
			shareTitle = "Link Title";
			shareDescription = "Link Description";
			shareImage = "http://i.imgur.com/j4M7vCO.jpg";
			feedTo = string.Empty;
			feedLink = "https://developers.facebook.com/";
			feedTitle = "Test Title";
			feedCaption = "Test Caption";
			feedDescription = "Test Description";
			feedImage = "http://i.imgur.com/zkYlB.jpg";
			feedMediaSource = string.Empty;
		}
	}
}
