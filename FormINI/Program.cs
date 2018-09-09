using System;
using Nini.Config;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace FormINI
{
    class Program
    {
        static IConfigSource ini = new IniConfigSource(Environment.GetCommandLineArgs()[1]);

        [STAThread]
        static void Main()
        {
            if (Environment.GetCommandLineArgs().Length > 0)
            {
                Form form = new Form();
                try
                {
                    form.Text = ini.Configs["Form"].Get("Title");
                }
                catch { }
                try
                {
                    form.StartPosition = (FormStartPosition)ini.Configs["Form"].GetInt("StartPosition");
                }
                catch { }
                try { form.Width = ini.Configs["Form"].GetInt("Width"); } catch { }
                try { form.Height = ini.Configs["Form"].GetInt("Height"); } catch { }
                try
                {
                    form.FormBorderStyle = (FormBorderStyle)ini.Configs["Form"].GetInt("FormBorderStyle");
                }
                catch { }
                try
                {
                    form.ShowIcon = ini.Configs["Form"].GetBoolean("ShowIcon");
                }
                catch { }
                try
                {
                    form.BackColor = Color.FromArgb(int.Parse(ini.Configs["Form"].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs["Form"].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs["Form"].Get("BackColor").Split(',')[2]));
                }
                catch { }
                try
                {
                    form.AllowDrop = ini.Configs["Form"].GetBoolean("AllowDrop");
                }
                catch { }
                try
                {
                    Application.VisualStyleState = (System.Windows.Forms.VisualStyles.VisualStyleState)ini.Configs["Form"].GetInt("VisualStyleState");
                }
                catch { }
                try
                {
                    if (ini.Configs["Form"].Get("Icon") != null && File.Exists(Path.Combine(Path.GetFullPath(Environment.GetCommandLineArgs()[1]).Replace(Path.GetFileName(Environment.GetCommandLineArgs()[1]), ""), ini.Configs["Form"].Get("Icon"))))
                            form.Icon = new Icon(Path.Combine(Path.GetFullPath(Environment.GetCommandLineArgs()[1]).Replace(Path.GetFileName(Environment.GetCommandLineArgs()[1]), ""), ini.Configs["Form"].Get("Icon")));
                }
                catch { }
                Label[] labels = new Label[0x7fff];
                TextBox[] textboxes = new TextBox[0x7fff];
                CheckBox[] checkboxes = new CheckBox[0x7fff];
                RadioButton[] radiobuttons = new RadioButton[0x7fff];
                Button[] buttons = new Button[0x7fff];
                try
                {
                    for (int i = 0; i < ini.Configs.Count; i++)
                    {
                        switch (ini.Configs[i].Get("Class"))
                        {
                            case "Label":
                                try
                                {
                                    labels[i] = new Label();
                                    try
                                    {
                                        if (ini.Configs[i].GetInt("Width") > 0 && ini.Configs[i].GetInt("Height") > 0)
                                        {
                                            labels[i].Size = new Size(ini.Configs[i].GetInt("Width"), ini.Configs[i].GetInt("Height"));
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        labels[i].Text = ini.Configs[i].Get("Text");
                                    }
                                    catch { }
                                    try
                                    {
                                        labels[i].Location = new Point(ini.Configs[i].GetInt("X"), ini.Configs[i].GetInt("Y"));
                                    }
                                    catch { }
                                    labels[i].Show();
                                    form.Controls.Add(labels[i]);
                                }
                                catch { }
                                break;
                            case "TextBox":
                                try
                                {
                                    textboxes[i] = new TextBox();
                                    try
                                    {
                                        if (ini.Configs[i].GetInt("Width") > 0 && ini.Configs[i].GetInt("Height") > 0)
                                        {
                                            textboxes[i].Size = new Size(ini.Configs[i].GetInt("Width"), ini.Configs[i].GetInt("Height"));
                                        }
                                        else
                                        {
                                            textboxes[i].Size = new Size(64, 0);
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        textboxes[i].Text = ini.Configs[i].Get("Text");
                                    }
                                    catch { }
                                    try
                                    {
                                        textboxes[i].Location = new Point(ini.Configs[i].GetInt("X"), ini.Configs[i].GetInt("Y"));
                                    }
                                    catch { }
                                    try
                                    {
                                        textboxes[i].HideSelection = ini.Configs[i].GetBoolean("HideSelection");
                                    }
                                    catch { }
                                    try
                                    {
                                        textboxes[i].Multiline = ini.Configs[i].GetBoolean("Multiline");
                                    }
                                    catch { }
                                    try
                                    {
                                        textboxes[i].ReadOnly = ini.Configs[i].GetBoolean("ReadOnly");
                                    }
                                    catch { }
                                    textboxes[i].Show();
                                    form.Controls.Add(textboxes[i]);
                                }
                                catch { }
                                break;
                            case "CheckBox":
                                try
                                {
                                    checkboxes[i] = new CheckBox();
                                    try
                                    {
                                        if (ini.Configs[i].GetInt("Width") > 0 && ini.Configs[i].GetInt("Height") > 0)
                                        {
                                            checkboxes[i].Size = new Size(ini.Configs[i].GetInt("Width"), ini.Configs[i].GetInt("Height"));
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        checkboxes[i].Text = ini.Configs[i].Get("Text");
                                    }
                                    catch { }
                                    try
                                    {
                                        checkboxes[i].Location = new Point(ini.Configs[i].GetInt("X"), ini.Configs[i].GetInt("Y"));
                                    }
                                    catch { }
                                    try
                                    {
                                        checkboxes[i].Checked = ini.Configs[i].GetBoolean("Checked");
                                    }
                                    catch { }
                                    try
                                    {
                                        checkboxes[i].Location = new Point(ini.Configs[i].GetInt("X"), ini.Configs[i].GetInt("Y"));
                                    }
                                    catch { }
                                    checkboxes[i].Show();
                                    form.Controls.Add(checkboxes[i]);
                                }
                                catch { }
                                break;
                            case "RadioButton":
                                try
                                {
                                    radiobuttons[i] = new RadioButton();
                                    try
                                    {
                                        if (ini.Configs[i].GetInt("Width") > 0 && ini.Configs[i].GetInt("Height") > 0)
                                        {
                                            radiobuttons[i].Size = new Size(ini.Configs[i].GetInt("Width"), ini.Configs[i].GetInt("Height"));
                                        }
                                    }
                                    catch { }
                                    try
                                    {
                                        radiobuttons[i].Text = ini.Configs[i].Get("Text");
                                    }
                                    catch { }
                                    try
                                    {
                                        radiobuttons[i].Location = new Point(ini.Configs[i].GetInt("X"), ini.Configs[i].GetInt("Y"));
                                    }
                                    catch { }
                                    try
                                    {
                                        radiobuttons[i].Checked = ini.Configs[i].GetBoolean("Checked");
                                    }
                                    catch { }
                                    radiobuttons[i].Show();
                                    form.Controls.Add(radiobuttons[i]);
                                }
                                catch { }
                                break;
                        }
                        try
                        {
                            labels[i].AllowDrop = ini.Configs[i].GetBoolean("AllowDrop");
                            textboxes[i].AllowDrop = ini.Configs[i].GetBoolean("AllowDrop");
                            checkboxes[i].AllowDrop = ini.Configs[i].GetBoolean("AllowDrop");
                            radiobuttons[i].AllowDrop = ini.Configs[i].GetBoolean("AllowDrop");
                            buttons[i].AllowDrop = ini.Configs[i].GetBoolean("AllowDrop");
                        }
                        catch { }
                        try
                        {
                            labels[i].AutoSize = ini.Configs[i].GetBoolean("AutoSize");
                            textboxes[i].AutoSize = ini.Configs[i].GetBoolean("AutoSize");
                            checkboxes[i].AutoSize = ini.Configs[i].GetBoolean("AutoSize");
                            radiobuttons[i].AutoSize = ini.Configs[i].GetBoolean("AutoSize");
                            buttons[i].AutoSize = ini.Configs[i].GetBoolean("AutoSize");
                        }
                        catch { }
                        try
                        {
                            labels[i].BackColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[2]));
                            textboxes[i].BackColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[2]));
                            checkboxes[i].BackColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[2]));
                            radiobuttons[i].BackColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[2]));
                            buttons[i].BackColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("BackColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("BackColor").Split(',')[2]));
                        }
                        catch { }
                        try
                        {
                            labels[i].ForeColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[2]));
                            textboxes[i].ForeColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[2]));
                            checkboxes[i].ForeColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[2]));
                            radiobuttons[i].ForeColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[2]));
                            buttons[i].ForeColor = Color.FromArgb(int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[0]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[1]), int.Parse(ini.Configs[i].Get("ForeColor").Split(',')[2]));
                        }
                        catch { }
                        /*try
                        {
                            try { labels[i].Visible = ini.Configs[i].GetBoolean("Visible"); } catch { labels[i].Visible = true; }
                            try { textboxes[i].Visible = ini.Configs[i].GetBoolean("Visible"); } catch { textboxes[i].Visible = true; }
                            try { checkboxes[i].Visible = ini.Configs[i].GetBoolean("Visible"); } catch { checkboxes[i].Visible = true; }
                            try { radiobuttons[i].Visible = ini.Configs[i].GetBoolean("Visible"); } catch { radiobuttons[i].Visible = true; }
                            try { buttons[i].Visible = ini.Configs[i].GetBoolean("Visible"); } catch { buttons[i].Visible = true; }
                        }
                        catch { }*/
                    }
                }
                catch { }
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("[Form]\nTitle=Example form\nWidth=640\nHeight=480\nBackColor=255,255,255", "Example of a FormINI:");
            }
        }
    }
}
