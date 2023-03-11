using Note.M;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Note
{
    public partial class Note : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        DbClass db = new DbClass();
        public NoteBody noteBody = new NoteBody();
        public Note()
        {
            InitializeComponent();
            FormBorder();
            this.TopMost = false;
        }
        
        #region Note_Load
        private void Note_Load(object sender, EventArgs e)
        {
            BorderlessButtons();
            SetGlobalSettings();
            NoteSetup();
            FillText();
            ColorNote();
            RecetSettings();
            Tb_body.SelectionStart = Tb_body.Text.Length;
            Tb_body.SelectionLength = 0;
            Tmr_Settings.Enabled = true;

        }
        #endregion
        #region SetGlobalSettings
        private void SetGlobalSettings()
        {
            string[] where = {"settingID"};
            string[] value = {"1"};
            string[,] settings = db.SelectWhere("settings", where, value, "*", "darkMode");
            if (settings[0,1] == "True")
            {
                noteBody.darkMode = true;
            }
            noteBody.fontSize = Convert.ToInt32(settings[0, 2]);
        }
        #endregion
        #region PinClicked
        private void PinClicked(object sender, EventArgs e)
        {
            if (Bbtn_PinWhite.Visible)
            {
                Bbtn_PinWhite.Visible = false;
                Bbtn_PinBlack.Visible = true;
                this.TopMost = true;
            }
            else
            {
                Bbtn_PinWhite.Visible = true;
                Bbtn_PinBlack.Visible = false;
                this.TopMost = false;
            }
        }
        #endregion
        #region DeleteNoteClick
        private void DeleteNote(object sender, EventArgs e)
        {
            if (noteBody.Text == "" && Tb_body.Text == "")
            {
                Tb_body.Text = "";
                noteBody.Text = "";
                CloseNote();
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show("Wilt u de huidige notitie verwijderen?", "", buttons);
                if (result == DialogResult.Yes)
                {
                    Tb_body.Text = "";
                    noteBody.Text = "";
                    CloseNote();
                }
            }
            
        }
        #endregion
        #region CloseNoteClick
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (Tb_body.Text == noteBody.Text)
            {
                CloseNote();
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
                DialogResult result = MessageBox.Show("Wilt u de huidige veranderingen opslaan?", "", buttons);
                if (result == DialogResult.Yes)
                {
                    SaveNote();
                    CloseNote();
                }
                else if (result == DialogResult.No)
                {
                    Tb_body.Text = "";
                    noteBody.Text = "";
                    CloseNote();
                }
            }

        }
        #endregion
        #region SaveNote
        private void SaveNote()
        {
            noteBody.Text = Tb_body.Text;
            noteBody.SaveNote();
        }
        #endregion
        #region FillText
        private void FillText()
        {
            Tb_body.Text = noteBody.Text;
        }
        #endregion
        #region noteSetup
        private void NoteSetup()
        {
            string[] where = { "modifyer" };
            string[] value = { "Selected" };
            string[,] Selected = db.SelectWhere("note", where, value, "*", "ID");
            where[0] = "modifyer";
            value[0] = "CopyStyle";
            string[,] CopyStyle = db.SelectWhere("note", where, value, "*", "ID");
            string[] colors = { "Orange", "Green", "Pink", "Purple", "Blue", "Gray" };
            if (Selected[0, 0] != "")
            {
                noteBody.ID = Convert.ToInt32(Selected[0, 0]);
                noteBody.Text = Selected[0, 1];
                for (int i = 0; i < colors.GetLength(0); i++)
                {
                    if (colors[i] == Selected[0, 2])
                    {
                        noteBody.Color = noteBody.ArraySlicerTwoDim(noteBody.Colors, i);
                        noteBody.ColorName = colors[i];
                    }
                }
                noteBody.Changed = Convert.ToDateTime(Selected[0, 3]);
                noteBody.RecetModifyer("Selected");
            }
            else if (CopyStyle[0, 0] != "")
            {
                for (int i = 0; i < colors.GetLength(0); i++)
                {
                    if (colors[i] == CopyStyle[0, 2])
                    {
                        noteBody.Color = noteBody.ArraySlicerTwoDim(noteBody.Colors, i);
                        noteBody.ColorName = colors[i];
                    }
                }
                noteBody.CreateNewNote(CopyStyle[0, 2]);
                noteBody.RecetModifyer("CopyStyle");
            }
            else
            {
                noteBody.Color = noteBody.ArraySlicerTwoDim(noteBody.Colors, 0);
                noteBody.CreateNewNote("Orange");
            }

        }
        #endregion
        #region AddNoteClick
        private void AddNoteClick(object sender, EventArgs e)
        {
            string savedColor = SelectSavedColor();
            bool different = false;
            if (savedColor != noteBody.ColorName)
            {
                different = true;
            }
            SetDBTempColor();
            noteBody.SetModifyer("CopyStyle",noteBody.ID.ToString());
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Bbtn_AddNote.Enabled = false;
            
            if (different)
            {
                wait(1000);
                UnsetDBTempColor(savedColor);
                Bbtn_AddNote.Enabled = true;
            }
            else
            {
                wait(1000);
                Bbtn_AddNote.Enabled = true;
            }

        }
        #endregion
        #region ToggleSettings
        private void ToggleSettings(object sender, EventArgs e)
        {
            if (noteBody.Settings)
            {
                noteBody.Settings = false;
                Pnl_Settings.Visible = false;
                Tb_body.Height += 35;
            }
            else
            {
                noteBody.Settings = true;
                Pnl_Settings.Visible = true;
                Tb_body.Height -= 35;
            }
        }
        #endregion
        #region RecetSettings
        private void RecetSettings()
        {
            noteBody.Settings = false;
            Pnl_Settings.Visible = false;
            Tb_body.Height += 35;
        }
        #endregion
        #region ChangeColor
        public void ChangeColor(object sender, EventArgs e)
        {
            Control button = (Control)sender;
            string[] colors = { "Orange", "Green","Pink","Purple","Blue","Gray" };
            int counter = 0;
            foreach (var color in colors)
            {
                if (button.Name == "Bbtn_Color" + color)
                {
                    noteBody.ChangeColor(counter);
                    ColorNote();
                }
                counter++;
            }
            button.Enabled = false;
            button.Enabled = true;
        }
        #endregion
        #region ColorNote
        private void ColorNote()
        {
            var headerButtons = this.Controls.OfType<Button>().ToList();
            Color headerColor = Color.FromArgb(noteBody.Color[0, 0], noteBody.Color[0, 1], noteBody.Color[0, 2]);
            Color bodyColor = Color.FromArgb(noteBody.Color[1, 0], noteBody.Color[1, 1], noteBody.Color[1, 2]);
            if (noteBody.darkMode)
            {
                bodyColor = Color.FromArgb(51, 51, 51);
                Tb_body.ForeColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                Tb_body.ForeColor = Color.FromArgb(0, 0, 0);
            }
            foreach (var button in headerButtons)
            {
                button.BackColor = headerColor;
            }
            this.BackColor = headerColor;
            Tb_body.BackColor = bodyColor;
            Pnl_Settings.BackColor = bodyColor;
            Pnl_sideColor.BackColor = bodyColor;
            
            Tb_body.Font = new Font(Tb_body.Font.FontFamily, noteBody.fontSize);
        }
        #endregion
        #region minimize Form
        private void Btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion
        #region FormBorder
        private void FormBorder()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            // this.FormBorderStyle = FormBorderStyle.Sizable;
            BorderlessButtons();
        }
        #endregion
        #region formScaling and formPosition
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        #endregion
        #region BorderlessButtons
        private void BorderlessButtons()
        {
            var buttons = this.Controls.OfType<Button>().Where(c => c.Name.StartsWith("Bbtn")).OrderByDescending(c => c.Name).ToList();
            var pannelButtons = this.Pnl_Settings.Controls.OfType<Button>().Where(c => c.Name.StartsWith("Bbtn")).OrderByDescending(c => c.Name).ToList();
            buttons.AddRange(pannelButtons); // adds the two lists together
            foreach (var button in buttons)
            {
                button.TabStop = false;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
        }
        #endregion
        #region CloseNote
        private void CloseNote()
        {
            if (Tb_body.Text == "")
            {
                noteBody.DeleteNote();
            }
            this.Close();
        }
        #endregion
        #region wait
        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        #endregion
        #region SelectSavedColor
        private string SelectSavedColor()
        {
            string[] where = {"ID"};
            string[] value = {noteBody.ID.ToString()};
            return db.SelectSingleWhere("note",where,value,1,"colorStyle")[0];
        }
        #endregion
        #region SetDBTempColor
        private void SetDBTempColor()
        {
            string[] columns = { "colorStyle" };
            string[] columnValues = { noteBody.ColorName };
            string[] where = { "ID" };
            string[] whereValues = { noteBody.ID.ToString() };
            db.Update("Note", columns, columnValues, where, whereValues);
        }
        #endregion
        #region UnsetDBTempColor
        private void UnsetDBTempColor(string savedColor)
        {
            string[] columns = { "colorStyle" };
            string[] columnValues = { savedColor };
            string[] where = { "ID" };
            string[] whereValues = { noteBody.ID.ToString() };
            db.Update("Note", columns, columnValues, where, whereValues);
        }
        #endregion
        #region CheckSettings
        private void CheckSettings(object sender, EventArgs e)
        {
            string[] where = {"settingID"};
            string[] value = {"1"};
            string[,] settings = db.SelectWhere("settings",where,value,"*","settingID");
            if (settings[0,1] == "True" && noteBody.darkMode == false)
            {
                noteBody.darkMode = true;
                ColorNote();
            }
            else if (settings[0, 1] == "False" && noteBody.darkMode == true)
            {
                noteBody.darkMode = false;
                ColorNote();
            }
            if (noteBody.fontSize.ToString() != settings[0,2])
            {
                noteBody.fontSize = Convert.ToInt32(settings[0, 2]);
                Tb_body.Font = new Font(Tb_body.Font.FontFamily, noteBody.fontSize);
            }
        }
        #endregion
    }
}
