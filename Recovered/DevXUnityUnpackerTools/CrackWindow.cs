using System;
using System.Drawing;
using System.Windows.Forms;

public class CrackWindow : Form
{
	internal CheckBox Activation;

	internal CheckBox Demo;

	internal CheckBox DevXCheck;

	internal CheckBox forceDll;

	internal CheckBox offlineMode;

	internal CheckBox folderOpen;

	internal CheckBox fakeInfo;

	internal Label fakeUserL;

	internal TextBox fakeUser;

	internal TextBox fakePC;

	internal Label fakePCL;

	internal RichTextBox richTextBox1;

	internal CheckBox autoScene;

	public static string CrackVersion;

	public CrackWindow()
	{
		Activation = new CheckBox();
		Demo = new CheckBox();
		DevXCheck = new CheckBox();
		forceDll = new CheckBox();
		offlineMode = new CheckBox();
		folderOpen = new CheckBox();
		fakeInfo = new CheckBox();
		fakeUserL = new Label();
		fakeUser = new TextBox();
		fakePC = new TextBox();
		fakePCL = new Label();
		richTextBox1 = new RichTextBox();
		autoScene = new CheckBox();
		SuspendLayout();
		Activation.Checked = CrackSettings.AllowActivation;
		Demo.Checked = CrackSettings.AllowDemoAssetRead;
		DevXCheck.Checked = CrackSettings.DisableDevXCheck;
		forceDll.Checked = CrackSettings.ForceDllLoad;
		offlineMode.Checked = CrackSettings.AllowOffline;
		folderOpen.Checked = CrackSettings.DisableFolderOpen;
		fakeInfo.Checked = CrackSettings.AllowFakeDeviceInfo;
		fakeUser.Text = CrackSettings.FakeUserName;
		fakePC.Text = CrackSettings.FakeMachineName;
		autoScene.Checked = CrackSettings.AutoScene;
		Activation.AutoSize = true;
		Activation.Location = new Point(10, 12);
		Activation.Margin = new Padding(4, 3, 4, 3);
		Activation.Name = "Activation";
		Activation.Size = new Size(228, 19);
		Activation.TabIndex = 0;
		Activation.Text = "Allow DevX-GameRecovery activation";
		Activation.UseVisualStyleBackColor = true;
		Activation.CheckedChanged += Activation_CheckedChanged;
		Demo.AutoSize = true;
		Demo.Location = new Point(10, 37);
		Demo.Margin = new Padding(4, 3, 4, 3);
		Demo.Name = "Demo";
		Demo.Size = new Size(327, 19);
		Demo.TabIndex = 1;
		Demo.Text = "Allow asset parsing without license (like demo version)";
		Demo.UseVisualStyleBackColor = true;
		Demo.CheckedChanged += Demo_CheckedChanged;
		DevXCheck.AutoSize = true;
		DevXCheck.Location = new Point(10, 62);
		DevXCheck.Margin = new Padding(4, 3, 4, 3);
		DevXCheck.Name = "DevXCheck";
		DevXCheck.Size = new Size(535, 19);
		DevXCheck.TabIndex = 3;
		DevXCheck.Text = "Disable checking for DevX Programm and allow you to decrypt and analyze any DevX program";
		DevXCheck.UseVisualStyleBackColor = true;
		DevXCheck.CheckedChanged += DevXCheck_CheckedChanged;
		forceDll.AutoSize = true;
		forceDll.Location = new Point(10, 87);
		forceDll.Margin = new Padding(4, 3, 4, 3);
		forceDll.Name = "forceDll";
		forceDll.Size = new Size(510, 19);
		forceDll.TabIndex = 4;
		forceDll.Text = "Force DevX to load dll even it encrypted (like 'Assemly: Assembly-CSharp.dll - Encrypted.')";
		forceDll.UseVisualStyleBackColor = true;
		forceDll.CheckedChanged += forceDll_CheckedChanged;
		offlineMode.AutoSize = true;
		offlineMode.Location = new Point(10, 112);
		offlineMode.Margin = new Padding(4, 3, 4, 3);
		offlineMode.Name = "offlineMode";
		offlineMode.Size = new Size(577, 19);
		offlineMode.TabIndex = 5;
		offlineMode.Text = "Allow program run offline and disabling all server requests (Allowing activation and demo asset read)";
		offlineMode.UseVisualStyleBackColor = true;
		offlineMode.CheckedChanged += offlineMode_CheckedChanged;
		folderOpen.AutoSize = true;
		folderOpen.Location = new Point(10, 137);
		folderOpen.Margin = new Padding(4, 3, 4, 3);
		folderOpen.Name = "folderOpen";
		folderOpen.Size = new Size(241, 19);
		folderOpen.TabIndex = 6;
		folderOpen.Text = "Disable folder opening after any export";
		folderOpen.UseVisualStyleBackColor = true;
		folderOpen.CheckedChanged += folderOpen_CheckedChanged;
		fakeInfo.AutoSize = true;
		fakeInfo.Location = new Point(10, 162);
		fakeInfo.Margin = new Padding(4, 3, 4, 3);
		fakeInfo.Name = "fakeInfo";
		fakeInfo.Size = new Size(241, 19);
		fakeInfo.TabIndex = 7;
		fakeInfo.Text = "Fake PC name and user account name";
		fakeInfo.UseVisualStyleBackColor = true;
		fakeInfo.CheckedChanged += fakeInfo_CheckedChanged;
		fakeUserL.AutoSize = true;
		fakeUserL.Enabled = false;
		fakeUserL.Location = new Point(10, 184);
		fakeUserL.Margin = new Padding(4, 0, 4, 0);
		fakeUserL.Name = "fakeUserL";
		fakeUserL.Size = new Size(65, 15);
		fakeUserL.TabIndex = 8;
		fakeUserL.Text = "Fake user:";
		fakeUser.Enabled = false;
		fakeUser.Location = new Point(75, 181);
		fakeUser.Margin = new Padding(4, 3, 4, 3);
		fakeUser.Name = "fakeUser";
		fakeUser.Size = new Size(100, 21);
		fakeUser.TabIndex = 9;
		fakeUser.TextChanged += fakeUser_TextChanged;
		fakePC.Enabled = false;
		fakePC.Location = new Point(242, 181);
		fakePC.Margin = new Padding(4, 3, 4, 3);
		fakePC.Name = "fakePC";
		fakePC.Size = new Size(100, 21);
		fakePC.TabIndex = 11;
		fakePC.TextChanged += fakePC_TextChanged;
		fakePCL.AutoSize = true;
		fakePCL.Enabled = false;
		fakePCL.Location = new Point(184, 184);
		fakePCL.Margin = new Padding(4, 0, 4, 0);
		fakePCL.Name = "fakePCL";
		fakePCL.Size = new Size(57, 15);
		fakePCL.TabIndex = 10;
		fakePCL.Text = "Fake PC:";
		richTextBox1.Location = new Point(10, 235);
		richTextBox1.Name = "richTextBox1";
		richTextBox1.ReadOnly = true;
		richTextBox1.RightToLeft = RightToLeft.No;
		richTextBox1.Size = new Size(613, 73);
		richTextBox1.TabIndex = 12;
		richTextBox1.Text = "I do crack for free, if u want, u can support me and my time.\nBTC: bc1q2xc6f35x2f8msudxud66s295q6nq0actmhgeuz\nPlease use version from PolarMods git repo. Anybody how know how to decrypt, can fake address";
		autoScene.AutoSize = true;
		autoScene.Location = new Point(10, 208);
		autoScene.Margin = new Padding(4, 3, 4, 3);
		autoScene.Name = "autoScene";
		autoScene.Size = new Size(317, 19);
		autoScene.TabIndex = 13;
		autoScene.Text = "Automaticly make scene when selecting GameObject";
		autoScene.UseVisualStyleBackColor = true;
		autoScene.CheckedChanged += autoScene_CheckedChanged;
		fakeUserL.Enabled = (fakeUser.Enabled = (fakePCL.Enabled = (fakePC.Enabled = fakeInfo.Checked)));
		base.AutoScaleDimensions = new SizeF(7f, 15f);
		base.AutoScaleMode = AutoScaleMode.Font;
		AutoSize = true;
		base.ClientSize = new Size(634, 321);
		base.Controls.Add(autoScene);
		base.Controls.Add(richTextBox1);
		base.Controls.Add(fakePC);
		base.Controls.Add(fakePCL);
		base.Controls.Add(fakeUser);
		base.Controls.Add(fakeUserL);
		base.Controls.Add(fakeInfo);
		base.Controls.Add(folderOpen);
		base.Controls.Add(offlineMode);
		base.Controls.Add(forceDll);
		base.Controls.Add(DevXCheck);
		base.Controls.Add(Demo);
		base.Controls.Add(Activation);
		Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point);
		base.FormBorderStyle = FormBorderStyle.FixedDialog;
		base.Icon = Loader.getCrackIcon();
		base.Margin = new Padding(4, 3, 4, 3);
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		Text = "Crack " + CrackVersion;
		base.TopMost = true;
		ResumeLayout(performLayout: false);
		PerformLayout();
		richTextBox1.Width = base.Width - richTextBox1.Location.X * 2;
		PerformLayout();
	}

	internal void Activation_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.AllowActivation = Activation.Checked;
		CrackSettings.Save();
	}

	internal void Demo_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.AllowDemoAssetRead = Demo.Checked;
		CrackSettings.Save();
	}

	internal void DevXCheck_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.DisableDevXCheck = DevXCheck.Checked;
		CrackSettings.Save();
	}

	internal void forceDll_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.ForceDllLoad = forceDll.Checked;
		CrackSettings.Save();
	}

	internal void offlineMode_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.AllowOffline = offlineMode.Checked;
		if (offlineMode.Checked)
		{
			CheckBox activation = Activation;
			bool flag = Demo.Checked = CrackSettings.AllowOffline;
			bool allowDemoAssetRead = activation.Checked = flag;
			CrackSettings.AllowActivation = (CrackSettings.AllowDemoAssetRead = allowDemoAssetRead);
		}
		CrackSettings.Save();
	}

	internal void folderOpen_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.DisableFolderOpen = folderOpen.Checked;
		CrackSettings.Save();
	}

	internal void fakeInfo_CheckedChanged(object sender, EventArgs e)
	{
		Label label = fakeUserL;
		TextBox textBox = fakeUser;
		Label label2 = fakePCL;
		bool flag = fakePC.Enabled = fakeInfo.Checked;
		bool flag3 = label2.Enabled = flag;
		bool flag5 = textBox.Enabled = flag3;
		bool allowFakeDeviceInfo = label.Enabled = flag5;
		CrackSettings.AllowFakeDeviceInfo = allowFakeDeviceInfo;
		CrackSettings.Save();
	}

	internal void fakeUser_TextChanged(object sender, EventArgs e)
	{
		CrackSettings.FakeUserName = fakeUser.Text;
		CrackSettings.Save();
	}

	internal void fakePC_TextChanged(object sender, EventArgs e)
	{
		CrackSettings.FakeMachineName = fakePC.Text;
		CrackSettings.Save();
	}

	internal void autoScene_CheckedChanged(object sender, EventArgs e)
	{
		CrackSettings.AutoScene = autoScene.Checked;
		CrackSettings.Save();
	}

	static CrackWindow()
	{
		CrackVersion = "1.0.9";
	}
}
