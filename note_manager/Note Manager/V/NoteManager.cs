using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Note_Manager
{
    public partial class NoteManager : Form
    {
        //private const int cGrip = 16;      // Grip size
        private const int cCaption = 64;   // Caption bar height;
        M.Settings settings = new M.Settings();
        M.NoteBody nb = new M.NoteBody();
        M.Main main = new M.Main();
        M.DbClass db = new M.DbClass();
        //Label Nlbl = new Label();
        public NoteManager()
        {
            InitializeComponent();
            FormBorder();
            this.TopMost = false;
        }

        private void NoteManager_Load(object sender, EventArgs e)
        {
            SettingSetup();
            ShowNotes();
            BorderlessButtons();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            Tmr_UpdateNotes.Enabled = true;
            //this.Width += 100;
        }

        #region BorderlessButtons
        private void BorderlessButtons()
        {
            var buttons = this.Controls.OfType<Button>().Where(c => c.Name.StartsWith("Bbtn")).OrderByDescending(c => c.Name).ToList();
            var panelbuttons = this.Pnl_Settings.Controls.OfType<Button>().Where(c => c.Name.StartsWith("Bbtn")).OrderByDescending(c => c.Name).ToList();
            buttons.AddRange(panelbuttons); // adds the two lists together
            foreach (var button in buttons)
            {
                button.TabStop = false;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
            }
            Cbb_FontSize.AllowDrop = false;
        }
        #endregion
        #region formScaling and formPosition
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
                //if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                //{
                //    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                //    return;
                //}
            }
            base.WndProc(ref m);
        }
        #endregion
        #region FormBorder
        private void FormBorder()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
            // this.FormBorderStyle = FormBorderStyle.Sizable;
            BorderlessButtons();
        }
        #endregion
        #region PreventMaximizeingForm
        private void PreventMazimizingForm(object sender, EventArgs e)
        {
            if (this.Height > 783)
            {
                this.WindowState = FormWindowState.Normal;
            }
            
        }
        #endregion
        #region closeApplicationClick
        private void CloseApplication(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region minimizeFormClick
        private void Bbtn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion
        #region SettingsBtnClick
        private void Bbtn_Settings_Click(object sender, EventArgs e)
        {
            ToggleSettings(main.ToggleSettings());
        }
        #endregion
        #region ToggleSettings
        private void ToggleSettings(bool settings)
        {
            if (settings)
            {
                Pnl_Notes.Visible = false;
                Pnl_Settings.Visible = true;
                Tb_Search.Visible = false;
                lbl_Settings.Visible = true;
                Bbtn_Search.Visible = false;
                return;
            }
            Pnl_Notes.Visible = true;
            Pnl_Settings.Visible = false;
            Tb_Search.Visible = true;
            lbl_Settings.Visible = false;
            Bbtn_Search.Visible = true;
        }
        #endregion
        #region DarkModeButtonClick
        private void Bbtn_DarkMode_Click(object sender, EventArgs e)
        {
            ToggleDarkMode(main.ToggleDarkMode());
        }
        #endregion
        #region ToggleDarkMode
        private void ToggleDarkMode(bool darkMode)
        {
            if (darkMode)
            {
                Bbtn_DarkMode.Text = "Aan";
                return;
            }
            Bbtn_DarkMode.Text = "Uit";
        }
        #endregion
        #region fontSizeChanged
        private void FontSizeChanged(object sender, EventArgs e)
        {
            main.fontSize = Convert.ToInt32(Cbb_FontSize.Text);
            main.UpdateDbSettings("fontSize", Cbb_FontSize.Text);
        }
        #endregion
        #region SettingSetup
        private void SettingSetup()
        {
            string[] where = {"settingID"};
            string[] value = {"1"};
            string[,] settings = db.SelectWhere("settings",where,value,"*", "settingID");
            if (settings[0,1] == "True")
            {
                ToggleDarkMode(main.ToggleDarkMode());
            }
            main.fontSize = Convert.ToInt32(settings[0, 2]);
            Cbb_FontSize.Text = settings[0, 2];
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
        #region ShowNotes
        private void ShowNotes()
        {
            //select from db
            string[,] notes = db.SelectNotes();
            nb.notes = notes;
            for (int i = 0; i < notes.GetLength(0); i++)
            {
               CreateNoteLabel(10,0,i,notes);
            }
        }
        #endregion
        #region CreateNoteLabel
        private void CreateNoteLabel(int x, int y,int noteIndex,string[,] notes)
        {
            int colorIndex = 0;
            int topSpacing = 0;
            topSpacing = 30;
            string[] colors = { "Orange", "Green", "Pink", "Purple", "Blue", "Gray" };
            int counter = 0;
            foreach (var color in colors)
            {
                if (color == notes[noteIndex, 2])
                {
                    colorIndex = counter;
                }
                counter++;
            }
            Label Nlbl = new Label();
            int offset = noteIndex * 130;
            Nlbl.Location = new System.Drawing.Point(x, y+offset+topSpacing);
            Nlbl.Name = "Lbl_NotePrevieuw" + noteIndex.ToString();
            Nlbl.Size = new System.Drawing.Size(310, 100);
            Nlbl.TabIndex = 0;
            int[,] noteColor = nb.ArraySlicerTwoDim(nb.Colors, colorIndex);
            Nlbl.BackColor = Color.FromArgb(noteColor[1, 0], noteColor[1, 1], noteColor[1, 2]);
            Nlbl.BorderStyle = BorderStyle.None;
            Nlbl.Cursor = Cursors.Default;
            Nlbl.DoubleClick += new System.EventHandler(this.NoteLabelClick);
            string labelText = "";
            try
            {
                labelText = "\n" + notes[noteIndex, 1].Substring(0, 200);
            }
            catch (Exception)
            {
                labelText = "\n" + notes[noteIndex, 1];
            }
            Nlbl.Text = labelText;
            Nlbl.ForeColor = Color.Black;
            Pnl_Notes.Controls.Add(Nlbl);
            Font labelFont = new Font("Segoe UI", 10);
            Nlbl.Font = labelFont;

            //header
            Label NlblH = new Label();
            NlblH.Location = new System.Drawing.Point(x, y + offset + topSpacing-10);
            NlblH.Name = "Lbl_NotePrevieuwHead" + noteIndex.ToString();
            NlblH.Size = new System.Drawing.Size(310, 10);
            NlblH.TabIndex = 0;
            NlblH.BackColor = Color.FromArgb(noteColor[0, 0], noteColor[0, 1], noteColor[0, 2]);
            NlblH.BorderStyle = BorderStyle.None;
            NlblH.Cursor = Cursors.Default;
            Pnl_Notes.Controls.Add(NlblH);

            //date 
            DateTime noteDate = DateTime.Parse(notes[noteIndex,3]);
            DateTime now = DateTime.Now;
            Label NlblDT = new Label();
            NlblDT.Location = new System.Drawing.Point(x+240, y + offset + topSpacing+3);
            NlblDT.Name = "Lbl_NotePrevieuwDateTime" + noteIndex.ToString();
            NlblDT.Size = new System.Drawing.Size(65, 20);
            NlblDT.TabIndex = 0;
            NlblDT.BackColor = Color.FromArgb(noteColor[1, 0], noteColor[1, 1], noteColor[1, 2]);
            NlblDT.BorderStyle = BorderStyle.None;
            NlblDT.Cursor = Cursors.Default;
            string todaysDateString = now.ToString("MM/dd/yyyy");
            string noteDateString = noteDate.ToString("MM/dd/yyyy");
            if (todaysDateString == noteDateString)
            {
                NlblDT.Text = "          " + noteDate.ToString("HH:mm");
            }
            else
            {
                NlblDT.Text = noteDateString;
            }

            
            Pnl_Notes.Controls.Add(NlblDT);
            NlblDT.BringToFront();
            NlblDT.ForeColor = Color.FromArgb(50, 50, 50);

        }
        #endregion
        #region NoteLabelClick
        private void NoteLabelClick(object sender, EventArgs e)
        {
            Control label = (Control)sender;
            string noteIndex = label.Name;
            noteIndex = noteIndex.Remove(0, 16); 
            string[] columns = {"modifyer"};
            string[] columnValues = {"Selected"};
            string[] where = {"ID"};
            string[] whereValues = { nb.notes[Convert.ToInt32(noteIndex), 0] };
            db.Update("note", columns, columnValues, where, whereValues);
            //change the path to your path to the note application
            System.Diagnostics.Process.Start(@"C:\path\to\note\application\Note.application");
        }
        #endregion
        #region BtnAddNoteClick
        private void Bbtn_AddNote_Click(object sender, EventArgs e)
        {
            //change the path to your path to the note application
            System.Diagnostics.Process.Start(@"C:\path\to\note\application\Note.application");
            Bbtn_AddNote.Enabled = false;
            Bbtn_AddNote.Enabled = true;
        }
        #endregion
        #region TmrUpdateNotesTick
        private void Tmr_UpdateNotes_Tick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string[,] notes = db.SelectNotes();
            string[,] checkingNotes = new string[notes.GetLength(0), notes.GetLength(1)];
            string[,] checkingNotesNB = new string[nb.notes.GetLength(0), nb.notes.GetLength(1)];
            for (int i = 0; i < notes.GetLength(0); i++)
            {
                for (int j = 0; j < notes.GetLength(1); j++)
                {
                    checkingNotes[i, j] = notes[i, j];
                    if (j == 4)
                    {
                        checkingNotes[i, j] = "NULL";
                    }
                }
            }
            for (int i = 0; i < nb.notes.GetLength(0); i++)
            {
                for (int j = 0; j < nb.notes.GetLength(1); j++)
                {
                    checkingNotesNB[i, j] = nb.notes[i, j];
                    if (j == 4)
                    {
                        checkingNotesNB[i, j] = "NULL";
                    }
                }
            }
            if (!Enumerable.SequenceEqual(checkingNotes.Cast<String>(), checkingNotesNB.Cast<String>()))
            {
                for (int i = Pnl_Notes.Controls.Count - 1; i >= 0; i--)
                {
                    Label label = Pnl_Notes.Controls[i] as Label;
                    if (label != null)
                    {
                        Pnl_Notes.Controls.RemoveAt(i);
                        label.Dispose();
                    }
                }
                ShowNotes();
            }
            this.Cursor = Cursors.Default;
        }
        #endregion
    }
}
