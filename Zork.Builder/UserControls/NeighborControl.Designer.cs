
namespace Zork.Builder
{
    partial class NeighborControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TextBox directionTextBox;
            this.neighborComboBox = new System.Windows.Forms.ComboBox();
            directionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // directionTextBox
            // 
            directionTextBox.Location = new System.Drawing.Point(3, 3);
            directionTextBox.Name = "directionTextBox";
            directionTextBox.Size = new System.Drawing.Size(121, 20);
            directionTextBox.TabIndex = 0;
            // 
            // neighborComboBox
            // 
            this.neighborComboBox.FormattingEnabled = true;
            this.neighborComboBox.Location = new System.Drawing.Point(3, 29);
            this.neighborComboBox.Name = "neighborComboBox";
            this.neighborComboBox.Size = new System.Drawing.Size(121, 21);
            this.neighborComboBox.TabIndex = 1;
            // 
            // NeighborControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.neighborComboBox);
            this.Controls.Add(directionTextBox);
            this.Name = "NeighborControl";
            this.Size = new System.Drawing.Size(129, 57);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox neighborComboBox;
    }
}
