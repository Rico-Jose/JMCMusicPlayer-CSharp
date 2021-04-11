namespace MusicPlayer
{
    partial class MusicPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.AxWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.TBInformation = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.LBSongs = new System.Windows.Forms.ListBox();
            this.TBSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.BtnSort = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // AxWindowsMediaPlayer
            // 
            this.AxWindowsMediaPlayer.Enabled = true;
            this.AxWindowsMediaPlayer.Location = new System.Drawing.Point(14, 15);
            this.AxWindowsMediaPlayer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AxWindowsMediaPlayer.Name = "AxWindowsMediaPlayer";
            this.AxWindowsMediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("AxWindowsMediaPlayer.OcxState")));
            this.AxWindowsMediaPlayer.Size = new System.Drawing.Size(318, 284);
            this.AxWindowsMediaPlayer.TabIndex = 4;
            // 
            // TBInformation
            // 
            this.TBInformation.Location = new System.Drawing.Point(460, 15);
            this.TBInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBInformation.Name = "TBInformation";
            this.TBInformation.ReadOnly = true;
            this.TBInformation.Size = new System.Drawing.Size(208, 22);
            this.TBInformation.TabIndex = 5;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(568, 376);
            this.ButtonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(100, 28);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Add Songs";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // LBSongs
            // 
            this.LBSongs.FormattingEnabled = true;
            this.LBSongs.ItemHeight = 16;
            this.LBSongs.Location = new System.Drawing.Point(460, 45);
            this.LBSongs.Name = "LBSongs";
            this.LBSongs.Size = new System.Drawing.Size(208, 324);
            this.LBSongs.TabIndex = 12;
            // 
            // TBSearch
            // 
            this.TBSearch.Location = new System.Drawing.Point(14, 382);
            this.TBSearch.Name = "TBSearch";
            this.TBSearch.Size = new System.Drawing.Size(318, 22);
            this.TBSearch.TabIndex = 13;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(340, 376);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(100, 28);
            this.BtnSearch.TabIndex = 14;
            this.BtnSearch.Text = "Search";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // BtnSort
            // 
            this.BtnSort.Location = new System.Drawing.Point(460, 376);
            this.BtnSort.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSort.Name = "BtnSort";
            this.BtnSort.Size = new System.Drawing.Size(100, 28);
            this.BtnSort.TabIndex = 15;
            this.BtnSort.Text = "Sort";
            this.BtnSort.UseVisualStyleBackColor = true;
            this.BtnSort.Click += new System.EventHandler(this.BtnSort_Click);
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 423);
            this.Controls.Add(this.BtnSort);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TBSearch);
            this.Controls.Add(this.LBSongs);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.TBInformation);
            this.Controls.Add(this.AxWindowsMediaPlayer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MusicPlayerForm";
            this.Text = "Music Player";
            ((System.ComponentModel.ISupportInitialize)(this.AxWindowsMediaPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private AxWMPLib.AxWindowsMediaPlayer AxWindowsMediaPlayer;
        private System.Windows.Forms.TextBox TBInformation;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.ListBox LBSongs;
        private System.Windows.Forms.TextBox TBSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Button BtnSort;
    }
}

