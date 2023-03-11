
namespace Note_Manager
{
    partial class NoteManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteManager));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.Pnl_Notes = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Tb_Search = new System.Windows.Forms.TextBox();
            this.Bbtn_Settings = new System.Windows.Forms.Button();
            this.Bbtn_Search = new System.Windows.Forms.Button();
            this.Bbtn_minimize = new System.Windows.Forms.Button();
            this.Bbtn_Close = new System.Windows.Forms.Button();
            this.Bbtn_AddNote = new System.Windows.Forms.Button();
            this.Pnl_Settings = new System.Windows.Forms.Panel();
            this.Cbb_FontSize = new System.Windows.Forms.ComboBox();
            this.Bbtn_DarkMode = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Settings = new System.Windows.Forms.Label();
            this.Tmr_UpdateNotes = new System.Windows.Forms.Timer(this.components);
            this.Pnl_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 740);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(0, 735);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(483, 1);
            this.panel3.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.Location = new System.Drawing.Point(463, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 740);
            this.panel5.TabIndex = 1;
            // 
            // Pnl_Notes
            // 
            this.Pnl_Notes.AutoScroll = true;
            this.Pnl_Notes.BackColor = System.Drawing.Color.White;
            this.Pnl_Notes.Location = new System.Drawing.Point(1, 89);
            this.Pnl_Notes.Name = "Pnl_Notes";
            this.Pnl_Notes.Size = new System.Drawing.Size(460, 645);
            this.Pnl_Notes.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.Location = new System.Drawing.Point(1, 89);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(464, 1);
            this.panel6.TabIndex = 0;
            // 
            // Tb_Search
            // 
            this.Tb_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.Tb_Search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Tb_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tb_Search.Location = new System.Drawing.Point(12, 42);
            this.Tb_Search.Multiline = true;
            this.Tb_Search.Name = "Tb_Search";
            this.Tb_Search.Size = new System.Drawing.Size(440, 41);
            this.Tb_Search.TabIndex = 9;
            // 
            // Bbtn_Settings
            // 
            this.Bbtn_Settings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Bbtn_Settings.BackgroundImage = global::Note_Manager.Properties.Resources.settings;
            this.Bbtn_Settings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bbtn_Settings.Location = new System.Drawing.Point(352, 9);
            this.Bbtn_Settings.Name = "Bbtn_Settings";
            this.Bbtn_Settings.Size = new System.Drawing.Size(30, 26);
            this.Bbtn_Settings.TabIndex = 0;
            this.Bbtn_Settings.UseVisualStyleBackColor = false;
            this.Bbtn_Settings.Click += new System.EventHandler(this.Bbtn_Settings_Click);
            // 
            // Bbtn_Search
            // 
            this.Bbtn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.Bbtn_Search.BackgroundImage = global::Note_Manager.Properties.Resources.loupe2;
            this.Bbtn_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bbtn_Search.Location = new System.Drawing.Point(420, 49);
            this.Bbtn_Search.Name = "Bbtn_Search";
            this.Bbtn_Search.Size = new System.Drawing.Size(26, 25);
            this.Bbtn_Search.TabIndex = 0;
            this.Bbtn_Search.UseVisualStyleBackColor = false;
            // 
            // Bbtn_minimize
            // 
            this.Bbtn_minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bbtn_minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Bbtn_minimize.BackgroundImage = global::Note_Manager.Properties.Resources.minus;
            this.Bbtn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bbtn_minimize.Location = new System.Drawing.Point(388, 7);
            this.Bbtn_minimize.Name = "Bbtn_minimize";
            this.Bbtn_minimize.Size = new System.Drawing.Size(30, 29);
            this.Bbtn_minimize.TabIndex = 10;
            this.Bbtn_minimize.UseVisualStyleBackColor = false;
            this.Bbtn_minimize.Click += new System.EventHandler(this.Bbtn_minimize_Click);
            // 
            // Bbtn_Close
            // 
            this.Bbtn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bbtn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Bbtn_Close.BackgroundImage = global::Note_Manager.Properties.Resources.close1;
            this.Bbtn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bbtn_Close.Location = new System.Drawing.Point(424, 12);
            this.Bbtn_Close.Name = "Bbtn_Close";
            this.Bbtn_Close.Size = new System.Drawing.Size(26, 24);
            this.Bbtn_Close.TabIndex = 8;
            this.Bbtn_Close.UseVisualStyleBackColor = false;
            this.Bbtn_Close.Click += new System.EventHandler(this.CloseApplication);
            // 
            // Bbtn_AddNote
            // 
            this.Bbtn_AddNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Bbtn_AddNote.BackgroundImage = global::Note_Manager.Properties.Resources.plusSlim;
            this.Bbtn_AddNote.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Bbtn_AddNote.Location = new System.Drawing.Point(12, 12);
            this.Bbtn_AddNote.Name = "Bbtn_AddNote";
            this.Bbtn_AddNote.Size = new System.Drawing.Size(26, 24);
            this.Bbtn_AddNote.TabIndex = 7;
            this.Bbtn_AddNote.UseVisualStyleBackColor = false;
            this.Bbtn_AddNote.Click += new System.EventHandler(this.Bbtn_AddNote_Click);
            // 
            // Pnl_Settings
            // 
            this.Pnl_Settings.AutoScroll = true;
            this.Pnl_Settings.BackColor = System.Drawing.Color.White;
            this.Pnl_Settings.Controls.Add(this.Cbb_FontSize);
            this.Pnl_Settings.Controls.Add(this.Bbtn_DarkMode);
            this.Pnl_Settings.Controls.Add(this.label3);
            this.Pnl_Settings.Controls.Add(this.label1);
            this.Pnl_Settings.Location = new System.Drawing.Point(1, 89);
            this.Pnl_Settings.Name = "Pnl_Settings";
            this.Pnl_Settings.Size = new System.Drawing.Size(460, 645);
            this.Pnl_Settings.TabIndex = 4;
            this.Pnl_Settings.Visible = false;
            // 
            // Cbb_FontSize
            // 
            this.Cbb_FontSize.DropDownHeight = 80;
            this.Cbb_FontSize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Cbb_FontSize.FormattingEnabled = true;
            this.Cbb_FontSize.IntegralHeight = false;
            this.Cbb_FontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.Cbb_FontSize.Location = new System.Drawing.Point(201, 79);
            this.Cbb_FontSize.Name = "Cbb_FontSize";
            this.Cbb_FontSize.Size = new System.Drawing.Size(56, 24);
            this.Cbb_FontSize.TabIndex = 4;
            this.Cbb_FontSize.SelectedValueChanged += new System.EventHandler(this.FontSizeChanged);
            // 
            // Bbtn_DarkMode
            // 
            this.Bbtn_DarkMode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Bbtn_DarkMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bbtn_DarkMode.Location = new System.Drawing.Point(201, 16);
            this.Bbtn_DarkMode.Name = "Bbtn_DarkMode";
            this.Bbtn_DarkMode.Size = new System.Drawing.Size(56, 37);
            this.Bbtn_DarkMode.TabIndex = 3;
            this.Bbtn_DarkMode.Text = "Uit";
            this.Bbtn_DarkMode.UseVisualStyleBackColor = false;
            this.Bbtn_DarkMode.Click += new System.EventHandler(this.Bbtn_DarkMode_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Text Groote:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Donkere modus:";
            // 
            // lbl_Settings
            // 
            this.lbl_Settings.AutoSize = true;
            this.lbl_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.lbl_Settings.Location = new System.Drawing.Point(143, 22);
            this.lbl_Settings.Name = "lbl_Settings";
            this.lbl_Settings.Size = new System.Drawing.Size(161, 32);
            this.lbl_Settings.TabIndex = 11;
            this.lbl_Settings.Text = "Instellingen";
            this.lbl_Settings.Visible = false;
            // 
            // Tmr_UpdateNotes
            // 
            this.Tmr_UpdateNotes.Interval = 4500;
            this.Tmr_UpdateNotes.Tick += new System.EventHandler(this.Tmr_UpdateNotes_Tick);
            // 
            // NoteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(464, 736);
            this.Controls.Add(this.lbl_Settings);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.Bbtn_Settings);
            this.Controls.Add(this.Bbtn_Search);
            this.Controls.Add(this.Bbtn_minimize);
            this.Controls.Add(this.Tb_Search);
            this.Controls.Add(this.Bbtn_Close);
            this.Controls.Add(this.Bbtn_AddNote);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Pnl_Notes);
            this.Controls.Add(this.Pnl_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NoteManager";
            this.Text = "Note Manager";
            this.Load += new System.EventHandler(this.NoteManager_Load);
            this.Resize += new System.EventHandler(this.PreventMazimizingForm);
            this.Pnl_Settings.ResumeLayout(false);
            this.Pnl_Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel Pnl_Notes;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button Bbtn_AddNote;
        private System.Windows.Forms.Button Bbtn_Close;
        private System.Windows.Forms.TextBox Tb_Search;
        private System.Windows.Forms.Button Bbtn_minimize;
        private System.Windows.Forms.Button Bbtn_Search;
        private System.Windows.Forms.Button Bbtn_Settings;
        private System.Windows.Forms.Panel Pnl_Settings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_Settings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Bbtn_DarkMode;
        private System.Windows.Forms.ComboBox Cbb_FontSize;
        private System.Windows.Forms.Timer Tmr_UpdateNotes;
    }
}

