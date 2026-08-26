using System;
using System.Collections.Generic;

[FunAttr(Num = "E47B28FE108668A6886A190535D79F31")]
internal class RequestManager
{
	private static Dictionary<int, string> RequestResults;

	private static Dictionary<string, string> CrackRequestResults;

	private static string someData;

	public static string TryMakeRequest(string method, string licType, string ver)
	{
		if (method.Contains("@@1298665970") && licType.Contains("UnpackerEditorStudio") && CrackSettings.AllowActivation)
		{
			return "1997406664";
		}
		if (method.Contains("@@4292476482") && licType.Contains("UnpackerEditorStudio") && CrackSettings.AllowActivation)
		{
			return "754242593";
		}
		string text = null;
		string text2 = method + licType + ver + DateTime.UtcNow.ToString("yyyy.MM.dd");
		if (RequestResults.ContainsKey(text2.GetHashCode()))
		{
			return RequestResults[text2.GetHashCode()];
		}
		if (CrackSettings.AllowDemoAssetRead && CrackRequestResults.ContainsKey(method))
		{
			return CrackRequestResults[method];
		}
		if (CrackSettings.AllowDemoAssetRead && method.Contains("@@?"))
		{
			return someData;
		}
		if (!CrackSettings.AllowOffline)
		{
			try
			{
				if (text == null)
				{
					text = GetMethodManager.RequestMethod(method, licType, ver);
				}
				RequestResults[text2.GetHashCode()] = text;
			}
			catch (Exception)
			{
			}
		}
		if (method.Contains("CheckSupportUnityVersion"))
		{
			method = method.Replace("@", "");
			return "#MessageForDebugConsole#Assets UnityVersion: " + method.Split(':')[1];
		}
		return text;
	}

	static RequestManager()
	{
		RequestResults = new Dictionary<int, string>();
		CrackRequestResults = new Dictionary<string, string>();
		someData = "ZgAAAAAAAAAEQUFCQgUAAAANQW5pbWF0aW9uQ2xpcBMAAAAOQW5pbWF0aW9uQ3VydmUxAAAABUFycmF5NwAAAARCYXNlPAAAAAhCaXRGaWVsZEwAAAAEYm9vbFEAAAAEY2hhclYAAAAJQ29sb3JSR0JBagAAAARkYXRhigAAABBGYXN0UHJvcGVydHlOYW1lmwAAAAVmaXJzdKEAAAAFZmxvYXSnAAAABEZvbnSsAAAACkdhbWVPYmplY3S3AAAADEdlbmVyaWMgTW9ub9AAAAAER1VJRN4AAAADaW508QAAAANtYXD1AAAACk1hdHJpeDR4NGYGAQAAD05hdk1lc2hTZXR0aW5ncwcBAAANTW9ub0JlaGF2aW91chUBAAAKTW9ub1NjcmlwdCsBAAAHbV9DdXJ2ZV0BAAAJbV9FbmFibGVkdgEAAAxtX0dhbWVPYmplY3SrAQAABm1fTmFtZeoBAAAIbV9TY3JpcHQHAgAABm1fVHlwZQ4CAAAJbV9WZXJzaW9uHwIAAARwYWlyJAIAAA9QUHRyPENvbXBvbmVudD40AgAAEFBQdHI8R2FtZU9iamVjdD5FAgAADlBQdHI8TWF0ZXJpYWw+aAIAABBQUHRyPE1vbm9TY3JpcHQ+eQIAAAxQUHRyPE9iamVjdD6wAgAADVBQdHI8VGV4dHVyZT6+AgAAD1BQdHI8VGV4dHVyZTJEPs4CAAAPUFB0cjxUcmFuc2Zvcm0+5QIAAAtRdWF0ZXJuaW9uZvECAAAFUmVjdGYKAwAABnNlY29uZBsDAAAEc2l6ZSADAAAGU0ludDE2LgMAAAZTSW50NjRIAwAABnN0cmluZ2oDAAAJVGV4dHVyZTJEdAMAAAlUcmFuc2Zvcm1+AwAADFR5cGVsZXNzRGF0YYsDAAAGVUludDE2oAMAAAVVSW50OKYDAAAMdW5zaWduZWQgaW501QMAAAZ2ZWN0b3LcAwAACFZlY3RvcjJm5QMAAAhWZWN0b3IzZu4DAAAIVmVjdG9yNGYbBAAAA2ludCIAAAAOQW5pbWF0aW9uU3RhdGVFAAAABmJpdHNldGAAAAAJQ29tcG9uZW50bwAAAAVkZXF1ZXUAAAAGZG91YmxlfAAAAA1keW5hbWljX2FycmF5xAAAAAtHcmFkaWVudE5FV9UAAAAIR1VJU3R5bGXiAAAABGxpc3TnAAAACWxvbmcgbG9uZwABAAAGTWRGb3VyIAEAAAptX0J5dGVTaXplMwEAABdtX0VkaXRvckNsYXNzSWRlbnRpZmllcksBAAARbV9FZGl0b3JIaWRlRmxhZ3NnAQAADm1fRXh0ZW5zaW9uUHRygwEAAAdtX0luZGV4iwEAAAltX0lzQXJyYXmVAQAACm1fSXNTdGF0aWOgAQAACm1fTWV0YUZsYWeyAQAAEW1fT2JqZWN0SGlkZUZsYWdzxAEAABBtX1ByZWZhYkludGVybmFs1QEAABRtX1ByZWZhYlBhcmVudE9iamVjdPMBAAATbV9TdGF0aWNFZGl0b3JGbGFncxgCAAAGT2JqZWN0VAIAABNQUHRyPE1vbm9CZWhhdmlvdXI+hgIAAAxQUHRyPFByZWZhYj6TAgAADFBQdHI8U3ByaXRlPqACAAAPUFB0cjxUZXh0QXNzZXQ+3gIAAAZQcmVmYWL3AgAAB1JlY3RJbnT/AgAAClJlY3RPZmZzZXQRAwAAA3NldBUDAAAFc2hvcnQnAwAABlNJbnQzMjUDAAAFU0ludDg7AwAADHN0YXRpY3ZlY3Rvck8DAAAJVGV4dEFzc2V0WQMAAAhUZXh0TWVzaGIDAAAHVGV4dHVyZZIDAAAGVUludDMymQMAAAZVSW50NjSzAwAAEnVuc2lnbmVkIGxvbmcgbG9uZ8YDAAAOdW5zaWduZWQgc2hvcnT3AwAAGm1fU2NyaXB0aW5nQ2xhc3NJZGVudGlmaWVyEgQAAAhHcmFkaWVudA==";
		CrackRequestResults["@@3898299782"] = "3035092468";
		CrackRequestResults["@@3897791124"] = "1076751524";
		CrackRequestResults["@@2234958423"] = "3577986067";
		CrackRequestResults["@@2518039892"] = "2213323814";
		CrackRequestResults["@@939389737"] = "1688034033";
		CrackRequestResults["@@2417559756"] = "1748999237";
		CrackRequestResults["@@1319669872"] = "3866485232";
		CrackRequestResults["@@3991147131"] = "1631395765";
		CrackRequestResults["@@3850102726"] = "215887471";
		CrackRequestResults["@@3250067257"] = "135442069";
		CrackRequestResults["@@1931546080"] = "2085839565";
		CrackRequestResults["@@1213926354"] = "Assets";
		CrackRequestResults["@@4274554885"] = "Resources";
		CrackRequestResults["@@3220308119"] = "Scripts";
		CrackRequestResults["@@3218297017"] = "level";
		CrackRequestResults["@@2747354191"] = "3242429971";
		CrackRequestResults["@@2575018333"] = "138309612";
		CrackRequestResults["@@3488324605"] = "2083425366";
		CrackRequestResults["@@1633165075"] = "2076279982";
		CrackRequestResults["@@3918578960"] = "399377582";
		CrackRequestResults["@@2874200570"] = "1923628594";
		CrackRequestResults["@@2446018660"] = "387989768";
		CrackRequestResults["@@2842711435"] = "1411632015";
		CrackRequestResults["@@3596042941"] = "4212352225";
	}
}
