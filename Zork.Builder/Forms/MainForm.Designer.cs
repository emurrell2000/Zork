
namespace Zork.Builder
{
    partial class MainForm
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
            System.Windows.Forms.MenuStrip mainMenuStrip;
            System.Windows.Forms.ToolStripMenuItem fileMenu;
            System.Windows.Forms.ToolStripSeparator fileSeperatorMenu;
            System.Windows.Forms.ToolStripMenuItem exitMenu;
            System.Windows.Forms.Label roomNameLabel;
            System.Windows.Forms.GroupBox roomInfoGroupBox;
            this.newMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.roomsGroupBox = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.roomsListBox = new System.Windows.Forms.ListBox();
            this.roomsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gameViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deleteButton = new System.Windows.Forms.Button();
            this.roomNameTextBox = new System.Windows.Forms.TextBox();
            mainMenuStrip = new System.Windows.Forms.MenuStrip();
            fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            fileSeperatorMenu = new System.Windows.Forms.ToolStripSeparator();
            exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            roomNameLabel = new System.Windows.Forms.Label();
            roomInfoGroupBox = new System.Windows.Forms.GroupBox();
            mainMenuStrip.SuspendLayout();
            this.roomsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).BeginInit();
            roomInfoGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            fileMenu});
            mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new System.Drawing.Size(698, 24);
            mainMenuStrip.TabIndex = 0;
            mainMenuStrip.Text = "MainMenuStrip";
            // 
            // fileMenu
            // 
            fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenu,
            this.openMenu,
            fileSeperatorMenu,
            exitMenu});
            fileMenu.Name = "fileMenu";
            fileMenu.Size = new System.Drawing.Size(37, 20);
            fileMenu.Text = "&File";
            // 
            // newMenu
            // 
            this.newMenu.Name = "newMenu";
            this.newMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenu.Size = new System.Drawing.Size(146, 22);
            this.newMenu.Text = "&New";
            this.newMenu.Click += new System.EventHandler(this.newMenu_Click);
            // 
            // openMenu
            // 
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(146, 22);
            this.openMenu.Text = "&Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // fileSeperatorMenu
            // 
            fileSeperatorMenu.Name = "fileSeperatorMenu";
            fileSeperatorMenu.Size = new System.Drawing.Size(143, 6);
            // 
            // exitMenu
            // 
            exitMenu.Name = "exitMenu";
            exitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            exitMenu.Size = new System.Drawing.Size(146, 22);
            exitMenu.Text = "&Exit";
            exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // roomNameLabel
            // 
            roomNameLabel.AutoSize = true;
            roomNameLabel.Location = new System.Drawing.Point(6, 20);
            roomNameLabel.Name = "roomNameLabel";
            roomNameLabel.Size = new System.Drawing.Size(35, 13);
            roomNameLabel.TabIndex = 0;
            roomNameLabel.Text = "&Name";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "JSON Files|*.json";
            // 
            // roomsGroupBox
            // 
            this.roomsGroupBox.Controls.Add(this.addButton);
            this.roomsGroupBox.Controls.Add(this.roomsListBox);
            this.roomsGroupBox.Controls.Add(this.deleteButton);
            this.roomsGroupBox.Location = new System.Drawing.Point(12, 27);
            this.roomsGroupBox.Name = "roomsGroupBox";
            this.roomsGroupBox.Size = new System.Drawing.Size(222, 419);
            this.roomsGroupBox.TabIndex = 1;
            this.roomsGroupBox.TabStop = false;
            this.roomsGroupBox.Text = "Rooms";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(60, 390);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // roomsListBox
            // 
            this.roomsListBox.DataSource = this.roomsBindingSource;
            this.roomsListBox.DisplayMember = "Description";
            this.roomsListBox.FormattingEnabled = true;
            this.roomsListBox.Location = new System.Drawing.Point(6, 20);
            this.roomsListBox.Name = "roomsListBox";
            this.roomsListBox.Size = new System.Drawing.Size(210, 368);
            this.roomsListBox.TabIndex = 0;
            this.roomsListBox.ValueMember = "Description";
            // 
            // roomsBindingSource
            // 
            this.roomsBindingSource.DataMember = "Rooms";
            this.roomsBindingSource.DataSource = this.gameViewModelBindingSource;
            // 
            // gameViewModelBindingSource
            // 
            this.gameViewModelBindingSource.DataSource = typeof(Zork.Builder.GameViewModel);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(141, 390);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "&Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // roomNameTextBox
            // 
            this.roomNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.roomsBindingSource, "Name", true));
            this.roomNameTextBox.Location = new System.Drawing.Point(9, 36);
            this.roomNameTextBox.Name = "roomNameTextBox";
            this.roomNameTextBox.Size = new System.Drawing.Size(264, 20);
            this.roomNameTextBox.TabIndex = 1;
            // 
            // roomInfoGroupBox
            // 
            roomInfoGroupBox.Controls.Add(this.roomNameTextBox);
            roomInfoGroupBox.Controls.Add(roomNameLabel);
            roomInfoGroupBox.Location = new System.Drawing.Point(241, 27);
            roomInfoGroupBox.Name = "roomInfoGroupBox";
            roomInfoGroupBox.Size = new System.Drawing.Size(445, 522);
            roomInfoGroupBox.TabIndex = 2;
            roomInfoGroupBox.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 561);
            this.Controls.Add(roomInfoGroupBox);
            this.Controls.Add(this.roomsGroupBox);
            this.Controls.Add(mainMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = mainMenuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Zork Builder";
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            this.roomsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.roomsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameViewModelBindingSource)).EndInit();
            roomInfoGroupBox.ResumeLayout(false);
            roomInfoGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox roomsGroupBox;
        private System.Windows.Forms.ListBox roomsListBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.BindingSource roomsBindingSource;
        private System.Windows.Forms.BindingSource gameViewModelBindingSource;
        private System.Windows.Forms.TextBox roomNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem newMenu;
    }
}

