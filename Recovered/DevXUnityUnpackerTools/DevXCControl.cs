using DevXUnityUnpackerTools.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TextEditor;

public class DevXCControl : UserControl
{
	private delegate void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020(object action);

	private System.Windows.Forms.Timer _0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

	private StringBuilder _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020 = new StringBuilder();

	private string _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020;

	private DateTime? _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020;

	private string _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = "Code.devxc";

	private IContainer _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A;

	private TextEditorExtended _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A;

	private ToolStrip _0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020;

	private ToolStripLabel _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020;

	private ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A;

	private ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A;

	private Label _0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020;

	private ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020;

	private ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020;

	private SplitContainer _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020;

	private TextEditorExtended _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A;

	private ToolStrip _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020;

	private ToolStripLabel _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020;

	private ToolStripButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A;

	private ToolStripSeparator _0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A;

	private ToolStripLabel _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A;

	private ToolStripLabel _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A;

	private ToolStrip _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020;

	private ToolStripLabel _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A;

	private ToolStripDropDownButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020;

	private ToolStripDropDownButton _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A;

	private ToolStripSeparator _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020;

	internal string _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A
	{
		get
		{
			return _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020;
		}
		set
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020 = value;
			if (!string.IsNullOrEmpty(value))
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Visible = false;
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020.Text = Path.GetFileName(value);
			}
			else
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Visible = true;
			}
		}
	}

	internal string _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A
	{
		get
		{
			return ((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).Text;
		}
		set
		{
			try
			{
				_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.SetCSharp(value);
			}
			catch (Exception _0020)
			{
				ConsoleManager.WriteEx45(_0020);
			}
		}
	}

	public unsafe DevXCControl()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		_0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
		if (base.DesignMode)
		{
			return;
		}
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.SetCSharp("");
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.OnSave = new SaveHandle(this._0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020);
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new System.Windows.Forms.Timer();
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A.Interval = 200;
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A.Tick += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020;
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A.Start();
		string text = "\r\nConsole message:\r\n- void warning(string message)\r\n- void error(string message)\r\n\r\nAsset search:\r\n- PPtr FindPPtr(string assetName, long pathID)\r\n- PPtr[] FindAssets(string name, string assetType)\r\n- IEnumerable<PPtr> EnumByAssetType(string class_name)\r\n- Item FindItemByPPt(PPtr)\r\n- IEnumerable<PPtr> EnumAllAssets()\r\n- IEnumerable<PPtr> EnumAllAssetsFiltered() - Enum all assets by curret UI filter (treeView filter)\r\n\r\nAsset:\r\n- object MakeAssetObject(PPtr)  - Make full asset info by PPtr or item\r\n- object GetAssetField(asset_object)\r\n- void SetAssetField(asset_object, object)  - Set new value to asset field\r\n- string GetAssetFieldsYamp(asset_object)\r\n- string UnityVersion(PPtr)\r\n- string GetAssetType(PPtr)\r\n- string GetName(object)\r\n- PPtr ChangeToPPtr(object) - Change to PPtr link\r\n- string GetAssetGuid(PPtr)\r\n- string GetAssetID(PPtr)\r\n- string GetMonoScriptGuid(PPtr) - Return Script Guid (Example: fe87c0e1cc204ed48ad3b37840f39efc for MonoBehavior or MonoScript asets. m_Script: {fileID: 11500000, guid: fe87c0e1cc204ed48ad3b37840f39efc, type: 3})\r\n- string GetMonoScriptID(PPtr) - Return Script ID (Example: 11500000 for MonoBehavior or MonoScript asets. m_Script: {fileID: 11500000, guid: fe87c0e1cc204ed48ad3b37840f39efc, type: 3})\r\n\r\n\r\n- void SelectItemOnTreeView(object item) - select treeview item by PPtr/Item/node  \r\n\r\nText tools:\r\nbool BytesIsText(byte[] in_buffer) - is buffer text - return true\r\nsting BytesToText(byte[] in_buffer) - if buffer is text return text\r\nsting BytesToTextUNCODE(byte[] in_buffer) - convert to text as unicode\r\nsting BytesToTextUtf8(byte[] in_buffer) - convert to text as utf8\r\n\r\nUI input tools:\r\n- string EditText(string caption, string text) - show edit text dialog (from 9.02 version)\r\n- string InputTextLine(string caption, string text) - show input text line dialog (from 9.02 version)\r\n- void ShowStatus(string status) - set UI status (status bar) (from 9.02 version)\r\n\r\nVariable tools:\r\n- object GetVariableStatic(string name) - for values stored by process run\r\n- object SetVariableStatic(string name, object value) -for values stored by process run\r\n- object GetSavedVariable(string name) - Save value for restore after close application\r\n- object SaveVariable(string name, object value) - Read saved value\r\n\r\nDirecotry tools:\r\n- string[] GetFiles(string directory_name) - Get files from directory\r\n- string[] GetFiles(string directory_name, string filter) - Get files from directory by filter\r\n- string[] GetFiles(string directory_name, string filter, bool allDirectories) - Get files from directory by filter recursive\r\n\r\n\r\nUnpacker tools:\r\n- void ShowDebug()\r\n- void ClearDebug()\r\n- void Clear()\r\n- void OpenGameDir(string openPath, custom_file_list [])\r\n- void openAutoSelect(string file_name)\r\n- void openAPKFile(string file_name)\r\n- void openIPAFile(string file_name)\r\n- void openUnitypackageFile(string file_name)\r\n- void openWebGLFile(string file_name)\r\n- void openOsgJS(string file_name)\r\n- void MakeScriptsOfProject(string savePath)\r\n- void ExportToDir(string savePath,exp_items [])\r\n- void ExportForRepack(string savePath,exp_items [])\r\n- void ImportForRepack(string openPath)\r\n- void MakePrefabs(string savePath)\r\n- void MakeUnityUnitypackage(string savePath, string name, asset)\r\n- void ExportUassetsFromUnrealEnginePAK(string savePath, exp_items [])\r\n- void SaveSubContents(string savePath)\r\n- void SaveAPK(string out_dir, string APKSignParams)\r\n- void ExportConvertedContent(string savePath, PPtr)\r\n\r\n- void SaveDUMP(string savePath, PPtr) - save asset dump in devxbxml format  (from 9.02 version)\r\n- void SaveOBJ(string savePath, PPtr) - save model as obj format (from 9.02 version)\r\n\r\n- void SavePNG(string savePath, PPtr)\r\n- void SaveAsWAV(string savePath, PPtr)\r\n- void SaveSubContent(string savePath, PPtr)\r\n- void SaveAssetRawWithHeader(string savePath, PPtr)\r\n\r\n- void MakeFBX(string savePath, exp_items=[])\r\n- void ReplaceImage(string sourceFile,PPtr)\r\n- void ReplaceText(string text,PPtr)\r\n\r\n- void ReplaceAudio(string text,PPtr)\r\n\r\n- void ReplaceTextByFile(string sourceFile,PPtr)\r\n\r\nCompressors:\r\n- byte[] GzipCompress(byte[] in_buffer);\r\n- byte[] GzipDecompress(byte[] in_buffer);\r\n- byte[] BrotliDecompress(byte[] in_buffer);\r\n- byte[] LZ4Decompress(byte[] in_buffer);\r\n- byte[] LZ4Decompress(byte[] in_buffer, int decompessed_size);\r\n- byte[] LZMADecompress(byte[] in_buffer);\r\n" + "Common functions:\r\n\r\nprint(expression) - show expression result\r\nLITTLE_ENDIAN() - set LITTLE ENDIAN read\r\nBIG_ENDIAN() - set BIG ENDIAN read\r\nend() - finish current structure\r\n\r\nstring typeof(variable_name) - value type name\r\nstring type(variable_name) - value type name\r\nstring ToString(variable_name) - value to string\r\nbyte[] ToBytes(variable_name) - value to bytes\r\nint len(variable_name) - massive, dictionary or string - length\r\ndouble pow(x, y) - Math Pow\r\ndouble sin(v) - Math Sin\r\ndouble cos(v) - Math Cos\r\ndouble tan(v) - Math Tan\r\ndouble asin(v) - Math Asin\r\ndouble acos(v) - Math Acos\r\ndouble atan(v) - Math Atan\r\ndouble abs(v) - Math Abs\r\ndouble pi() - Math PI value\r\nobject min(v1,v2) - Minimum (param: values or array)\r\nobject max(v1,v2) - Maximum (param: values or array)\r\n " + "\r\nNetwork functions:\r\nstring DownloadString(string url) - download string by url (GET)\r\nstring UploadValues(string url, object structure) - upload structure as parameters (POST)\r\nstring UploadBytes(string url, byte[] buff) - upload buffer (POST)\r\n" + "\r\nRuntime functions:\r\nobject RunScriptCode(string code_text) -  Execute DevC code by source text\r\nobject RunScriptBinary(byte[] code_binary) -  Execute DevXC compiled code\r\n" + "\r\nString functions (String.FunName(params)):\r\n\r\n\r\nint IndexOf(string s)\r\nint IndexOf(string s, int begin)\r\n\r\nint IndexOfWord(string s)\r\n\r\nint IndexOfWord(string s, int begin)\r\n\r\nbool Contains(string s)\r\n\r\nbool ContainsOfWord(string s)\r\n\r\nbool ContainsOfWord(string s, int begin)\r\n\r\n \r\n\r\nint LastIndexOf(string s)\r\n\r\nint LastIndexOf(string s, int begin)\r\n\r\nstring Substring(int begin)\r\n\r\nstring Substring(int begin, int len)\r\n\r\nstring Remove(int begin)\r\n\r\nstring Remove(int begin, int len)\r\n\r\nstring Replace(string s_from, string s_to)\r\n\r\nstring Split(string chars)\r\n\r\nstring Trim()\r\n\r\nstring Trim(string chars)\r\n\r\nstring TrimStart()\r\n\r\nstring TrimEnd(string chars)\r\n\r\nstring Trim()\r\n\r\nstring Trim(string chars)\r\n\r\nstring ToLower()\r\n\r\nstring ToUpper()\r\n\r\nint Length()\r\n" + "\r\nInput binary stream functions:\r\n\r\n\r\nlong offset([stream]) - show relative offset (from last call offset())\r\n\r\noffset([stream,] int) - set relative offset (from current position)\r\n\r\nlong offset_struct() - show relative offset (in structure start)\r\n\r\noffset_struct(int) - set relative offset (from structure start)\r\n\r\nposition([stream,] int) - set global offset (input binary stream)\r\n\r\nlong position([stream]) - show global offset (input binary stream)\r\n\r\nlong lenght([stream]) - lenght of binary stream\r\n\r\n \r\n\r\nalign([stream]) - align by 4 bytes\r\n\r\nalign([stream,] int)\r\n\r\nskip([stream,] int) - skip bytes\r\n\r\n \r\n\r\nbyte[] bytes([stream]) - read from stream bytes count and read bytes buffer\r\n\r\nbyte[] bytes([stream,] int len) - read from stream len bytes\r\n\r\ntype_name read([stream,] type_name) - read from stream value by type_name\r\n\r\nobject[] read([stream,] type1,type2,type3,...) - read from stream values by types\r\n\r\n \r\n\r\n \r\n\r\nstream create(string file_name) - Create file for binary output\r\n\r\nstream openWrite(string file_name) - Open file for binary output (append)\r\n\r\nvoid close([stream]) - Close file for binary output\r\n\r\nvoid write([stream,] val1,val2, ...) - Write variable to output binary stream\r\n\r\nvoid writeText([stream,] val1,val2, ...) - Write variable to output binary stream as text\r\n\r\nvoid writeLine([stream,] val1,val2, ...) - Write variable to output binary stream as text - end with new line\r\n\r\nvoid writeBytes([stream,] val1,val2, ...) - Write variable bytes to default output binary stream\r\n\r\nvoid writeStringNull([stream,] val1,val2, ...) - Write variable string with null end to output binary stream\r\n\r\nvoid writeStringBytes([stream,] val1,val2, ...) - Write variable string bytes to output binary stream\r\n\r\nbyte[] readAllBytes(string file_name) - Read all bytes from local file\r\n\r\nvoid writeAllBytes(string file_name, byte[] buff) - Write all bytes to local file\r\n\r\n \r\n\r\nbool echo(bool) - on/off auto show read from stream value\r\n\r\nechoOff() - off auto show read from stream value\r\n\r\nechoOn() - on auto show read from stream value (default on)\r\n" + "\r\n";
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["Export shaders as dump"] = "list=FindAssets(\"\",\"Shader\")\r\ni = 0;\r\nforeach (v in list)\r\n{\r\n    i++;\r\n    file = @\"out_dir\\\" + i + \"_\" + GetName(v) + \".devxbxml\";\r\n    MakeDump(file, v);\r\n}\r\n",
			["Find and export as PNG textures"] = "list=FindAssets(\"Background\",\"Texture2D\");\r\ni=0;\r\nforeach (v in list)\r\n{\r\n    i++;\r\n    file = @\"out_dir\\\" + i + \"_\" + GetName(v) + \".png\";\r\n    SavePNG(file, v);\r\n}\r\n",
			["Export as .unitypackage for Prefabs"] = "var v = FindAssetsByNameAndType(\"Prefab_\", \"GameObject\");\r\n\r\n?\"Count=\"+len(v)\r\ndir=@\"d:\\_Temp\\\";\r\n\r\nforeach(p in v)\r\n{\r\n   file=dir+ GetName(p) + \".unitypackage\";\r\n   ?file\r\n   MakeUnityUnitypackage(file, GetName(p), p);\r\n}\r\n"
		};
		ToolStripItemCollection dropDownItems = _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.DropDownItems;
		string[] array = text.Replace("\r", "").Split('\n');
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = array[i]?.Trim(' ', '\t', '-', ';');
			if (!string.IsNullOrEmpty(text2) && !text2.StartsWith("//"))
			{
				if (text2.EndsWith(":") || text2.IndexOf("(") < 0)
				{
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(text2);
					dropDownItems = toolStripMenuItem.DropDownItems;
					_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.DropDownItems.Add(toolStripMenuItem);
					continue;
				}
				string str = text2.Split('(')[0].Split(' ').Last();
				List<string> list = new List<string>();
				try
				{
					int num = text2.IndexOf("(") + 1;
					int num2 = text2.IndexOf(")", num);
					string[] array2 = text2.Substring(num, num2 - num).Split(',');
					for (int j = 0; j < array2.Length; j++)
					{
						string item = array2[j].Split(' ').Last();
						list.Add(item);
					}
				}
				catch
				{
				}
				ToolStripItem toolStripItem = dropDownItems.Add(text2);
				toolStripItem.Tag = str + "(" + string.Join(", ", list.ToArray()) + ")";
				toolStripItem.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;
			}
		}
		foreach (KeyValuePair<string, string> item2 in dictionary)
		{
			ToolStripItem toolStripItem2 = _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.DropDownItems.Add(item2.Key);
			toolStripItem2.Tag = item2.Value;
			toolStripItem2.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020;
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020(object _0020, EventArgs _0020_000A)
	{
		ToolStripItem toolStripItem = _0020 as ToolStripItem;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.InsertText((toolStripItem.Tag as string) ?? "");
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020(object _0020, EventArgs _0020_000A)
	{
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.HasValue)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Text = (DateTime.Now - _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.Value).TotalSeconds + TranslationManager.TryGetTranslated(802210065);
		}
		lock (_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020)
		{
			if (_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020.Length > 0)
			{
				((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Text += _0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020.ToString();
			}
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020.Clear();
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A(string _0020)
	{
		lock (_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020)
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020.AppendLine(_0020);
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020(string _0020)
	{
		lock (_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020)
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020.AppendLine(_0020);
		}
	}

	internal void _0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A()
	{
		try
		{
			((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Text = null;
		}
		catch
		{
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A(object _0020, EventArgs _0020_000A)
	{
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Enabled = true;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Enabled = false;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Enabled = false;
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Text = "";
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Refresh();
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A.Start();
		_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020 = DateTime.Now;
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.HasValue)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Text = (DateTime.Now - _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.Value).TotalSeconds + TranslationManager.TryGetTranslated(802210065);
		}
		_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020(_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A);
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020(object _0020, EventArgs _0020_000A)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.Title = "Open DevXC code file";
		openFileDialog.FileName = null;
		openFileDialog.Filter = "DevXC Code file|*.devxc|All file|*.*";
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A = Path.GetFileName(openFileDialog.FileName);
			_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A = File.ReadAllText(openFileDialog.FileName);
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A(object _0020, EventArgs _0020_000A)
	{
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020();
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020()
	{
		string text = _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A;
		if (string.IsNullOrEmpty(text))
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save DevXC code file";
			saveFileDialog.FileName = _0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A;
			saveFileDialog.Filter = "DevXC Code file|*.devxc|All file|*.*";
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			text = saveFileDialog.FileName;
		}
		File.WriteAllText(text, _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A);
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020(object _0020, EventArgs _0020_000A)
	{
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A(object _0020, EventArgs _0020_000A)
	{
		HiddenCalls.CallObjectSafe1(null, "2667073350");
	}

	internal static void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020(Action _0020)
	{
		ThreadPool.QueueUserWorkItem(_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A, _0020);
	}

	private static void _0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A(object _0020)
	{
		try
		{
			((Action)_0020)();
		}
		catch (Exception _00202)
		{
			ConsoleManager.WriteEx9847(_00202);
		}
	}

	internal void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020(Action _0020)
	{
		if (base.InvokeRequired)
		{
			Invoke(new _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020(_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A), _0020);
		}
		else
		{
			try
			{
				_0020();
			}
			catch (Exception _00202)
			{
				ConsoleManager.WriteEx9847(_00202);
			}
		}
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A(object _0020, EventArgs _0020_000A)
	{
		MainForm.instance.ShowDebug();
	}

	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020(object _0020, EventArgs _0020_000A)
	{
		MaybeAlertManager._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A("https://devxdevelopment.com/DevXC");
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A != null)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A.Dispose();
		}
		base.Dispose(disposing);
	}

	private void _0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020()
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A = new Container();
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020 = new ToolStrip();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020 = new ToolStripLabel();
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A = new ToolStripButton();
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020 = new ToolStripButton();
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020 = new ToolStripButton();
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A = new ToolStripButton();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020 = new ToolStripSeparator();
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020 = new Label();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020 = new SplitContainer();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020 = new ToolStrip();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020 = new ToolStripLabel();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A = new ToolStripButton();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020 = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A = new ToolStripButton();
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A = new ToolStripLabel();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A = new ToolStripLabel();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020 = new ToolStrip();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A = new ToolStripLabel();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020 = new ToolStripDropDownButton();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A = new TextEditorExtended();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A = new TextEditorExtended();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A = new ToolStripDropDownButton();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020 = new ToolStripSeparator();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020 = new ToolStripSeparator();
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.SuspendLayout();
		((ISupportInitialize)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020).BeginInit();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.SuspendLayout();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel2.SuspendLayout();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.SuspendLayout();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.SuspendLayout();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.SuspendLayout();
		SuspendLayout();
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Items.AddRange(new ToolStripItem[10]
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020,
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A,
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A,
			_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020,
			_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020,
			_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A,
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020
		});
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Location = new Point(0, 0);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Name = "toolStrip1";
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Size = new Size(687, 25);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.TabIndex = 7;
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.Text = TranslationManager.TryGetTranslated(-409732557);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020.Name = "lb_Rules";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020.Size = new Size(81, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020.Text = TranslationManager.TryGetTranslated(-1891538581);
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A.Name = "toolStripSeparator1";
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_000A_0020_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Image = Resources.Build16;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Name = "bt_Apply";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Size = new Size(67, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Text = TranslationManager.TryGetTranslated(1462825054);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A;
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A.Name = "toolStripSeparator2";
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_000A_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Image = Resources.OpenFolder16;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Name = "bt_open_rules";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Size = new Size(56, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Text = TranslationManager.TryGetTranslated(-389234318);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_0020;
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A.Name = "toolStripSeparator4";
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.Image = Resources.Save16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.Name = "bt_SaveCode";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.Size = new Size(80, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.Text = TranslationManager.TryGetTranslated(-1063725414);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_0020.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A;
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A.Name = "toolStripSeparator3";
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.CheckOnClick = true;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.Image = Resources.Web16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.Name = "bt_Help";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.Size = new Size(52, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.Text = TranslationManager.TryGetTranslated(-799365114);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_0020;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020.Name = "toolStripSeparator7";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_0020_0020.Size = new Size(6, 25);
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.BorderStyle = BorderStyle.Fixed3D;
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.Dock = DockStyle.Top;
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.Location = new Point(0, 0);
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.Name = "label4";
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.Size = new Size(1466, 2);
		_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020.TabIndex = 11;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Dock = DockStyle.Fill;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Location = new Point(0, 2);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Name = "splitContainer1";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.Controls.Add((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.Controls.Add(_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.Controls.Add(_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel2.Controls.Add((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel2.Controls.Add(_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Size = new Size(1466, 683);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.SplitterDistance = 687;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.TabIndex = 12;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.Items.AddRange(new ToolStripItem[9]
		{
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A,
			_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A
		});
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.Location = new Point(0, 0);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.Name = "toolStrip2";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.Size = new Size(775, 25);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.TabIndex = 9;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.Text = TranslationManager.TryGetTranslated(-409535949);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020.Name = "toolStripLabel1";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020.Size = new Size(42, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_0020.Text = TranslationManager.TryGetTranslated(-2058116841);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A.Name = "toolStripSeparator9";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A.Image = Resources.Save16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A.Name = "bt_SaveResult";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A.Size = new Size(83, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_000A_000A.Text = TranslationManager.TryGetTranslated(-810398807);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020.Name = "toolStripSeparator10";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.CheckOnClick = true;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Image = Resources.Wrong16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Name = "bt_Stop";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Size = new Size(56, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Text = TranslationManager.TryGetTranslated(22183322);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Click += _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_000A;
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.Name = "toolStripSeparator5";
		_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A.Name = "toolStripLabel2";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A.Size = new Size(77, 22);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A.Text = TranslationManager.TryGetTranslated(1199771612);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Name = "lb_execute_time";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Size = new Size(13, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Text = "0";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A.Name = "toolStripSeparator8";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_000A_0020_000A.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.Items.AddRange(new ToolStripItem[5]
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A,
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020
		});
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.Location = new Point(0, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.Name = "toolStrip3";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.Size = new Size(687, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.TabIndex = 8;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.Text = TranslationManager.TryGetTranslated(-409601485);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A.Name = "toolStripLabel3";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A.Size = new Size(36, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_000A.Text = TranslationManager.TryGetTranslated(-2001639914);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.Image = Resources.Assembly16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.Name = "toolStrip_Functions";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.Size = new Size(88, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020.Text = TranslationManager.TryGetTranslated(-218309390);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).AllowDrop = true;
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).Dock = DockStyle.Fill;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.set_IsReadOnly(false);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).Location = new Point(0, 50);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).Name = "ed_Code";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.set_ShowFileMenu(false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.set_ShowMenu(false);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).Size = new Size(687, 633);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A).TabIndex = 6;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A.add_TextChanged((EventHandler)_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).AllowDrop = true;
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Dock = DockStyle.Fill;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A.set_IsReadOnly(false);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Location = new Point(0, 25);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Name = "ed_Result";
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A.set_ShowFileMenu(false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A.set_ShowMenu(false);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).Size = new Size(775, 658);
		((Control)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A).TabIndex = 7;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.Image = Resources.code16;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.ImageTransparentColor = Color.Magenta;
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.Name = "toolStrip_Examples";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.Size = new Size(85, 22);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_000A.Text = TranslationManager.TryGetTranslated(211776837);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020.Name = "toolStripSeparator6";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_000A_0020_0020.Size = new Size(6, 25);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020.Name = "toolStripSeparator11";
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020.Size = new Size(6, 25);
		base.AutoScaleDimensions = new SizeF(6f, 13f);
		base.AutoScaleMode = AutoScaleMode.Font;
		base.Controls.Add(_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020);
		base.Controls.Add(_0020_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020);
		base.Name = "DevXCControl";
		base.Size = new Size(1466, 685);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.ResumeLayout(performLayout: false);
		_0020_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020_0020.PerformLayout();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.ResumeLayout(performLayout: false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel1.PerformLayout();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel2.ResumeLayout(performLayout: false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.Panel2.PerformLayout();
		((ISupportInitialize)_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020).EndInit();
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_0020_0020.ResumeLayout(performLayout: false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.ResumeLayout(performLayout: false);
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020_0020.PerformLayout();
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.ResumeLayout(performLayout: false);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020.PerformLayout();
		ResumeLayout(performLayout: false);
	}

	[CompilerGenerated]
	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_000A()
	{
		try
		{
			MaybeAlertManager._0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(fl_lock: true);
			HiddenCalls.CallObjectSafe1(MainForm.instance._0020_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_000A, "4281695458", _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A, new DevXCMethodData._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_0020_0020_0020(_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A));
		}
		finally
		{
			MaybeAlertManager._0020_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A(fl_lock: false);
		}
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020(_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020);
	}

	[CompilerGenerated]
	private void _0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_000A_0020()
	{
		_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A?.Stop();
		_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020(null, null);
		_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A.Enabled = false;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A.Enabled = true;
		_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_0020_0020_0020.Enabled = true;
		if (_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.HasValue)
		{
			_0020_0020_000A_0020_0020_0020_0020_0020_000A_000A_000A_0020_0020_000A_000A.Text = (DateTime.Now - _0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020.Value).TotalSeconds + TranslationManager.TryGetTranslated(802210065);
		}
		_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020 = null;
	}
}
