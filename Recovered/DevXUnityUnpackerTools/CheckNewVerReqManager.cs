using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

internal class CheckNewVerReqManager
{
	[FunAttr(Num = "469A3440898E2CE2443ABA2246C54666")]
	public static string CheckNewVerReq()
	{
		string result = CrackWindow.CrackVersion;
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12);
			HttpWebRequest obj = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/Polarmods/DevX-Cracked/releases/latest");
			obj.Accept = "application/json";
			obj.UserAgent = "program/update";
			HttpWebResponse obj2 = (HttpWebResponse)obj.GetResponse();
			string text = null;
			using (Stream stream = obj2.GetResponseStream())
			{
				text = new StreamReader(stream, Encoding.UTF8).ReadToEnd();
			}
			if (string.IsNullOrEmpty(text))
			{
				return result;
			}
			result = (string)(Json.Deserialize(text) as Dictionary<string, object>)["tag_name"];
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}
}
