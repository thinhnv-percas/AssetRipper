internal class 子例子
{
	internal const string JustRandomString = "sg343555T4f";

	internal const string RND1_TXT = "53433t45gdfgdfhsdfh#RND1@GN16#F8E371695B718976";

	internal const string RND2_TXT = "533DFD9332CD416CB79#RND2@GN16#FA890FD169CBFDAF";

	internal const string RND3_TXT = "9005F3E4A466B46A9B7#RND3@GN16#19816B228E16324F";

	internal const string RND4_TXT = "78171A0063B24DB3B3E#RND4@GN16#97441667F6469F43";

	internal static string 子例子子 = "53433t45gdfgdfhsdfh#RND1@GN16#F8E371695B718976";

	internal static string 例子子子 = "533DFD9332CD416CB79#RND2@GN16#FA890FD169CBFDAF";

	internal static string 子例例 = "9005F3E4A466B46A9B7#RND3@GN16#19816B228E16324F";

	internal static string キスト = "78171A0063B24DB3B3E#RND4@GN16#97441667F6469F43";

	internal static string スキト = "ERG34t3REGTHTRY#RND5@GN16#F0730A28B1186013";

	internal static string rand;

	internal static string RND1()
	{
		return 子例子子;
	}

	internal static string RND2()
	{
		string result = 例子子子;
		例子子子 = "";
		return result;
	}

	internal static string RND3()
	{
		string result = 子例例;
		子例例 = "";
		return result;
	}

	internal static string RND4()
	{
		return キスト;
	}

	internal static string RND6()
	{
		return スキト;
	}

	internal static string RandomString()
	{
		return rand;
	}
}
