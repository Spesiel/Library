﻿namespace Library.Previewer
{
    partial class Preview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preview));
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.picturePrevious = new System.Windows.Forms.PictureBox();
            this.pictureNext = new System.Windows.Forms.PictureBox();
            this.Informations = new Library.Controls.CollapsibleInformation();
            this.table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrevious)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNext)).BeginInit();
            this.SuspendLayout();
            // 
            // table
            // 
            resources.ApplyResources(this.table, "table");
            this.table.Controls.Add(this.pictureBox, 1, 0);
            this.table.Controls.Add(this.picturePrevious, 0, 1);
            this.table.Controls.Add(this.pictureNext, 2, 1);
            this.table.Name = "table";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.table.SetRowSpan(this.pictureBox, 3);
            this.pictureBox.TabStop = false;
            // 
            // picturePrevious
            // 
            resources.ApplyResources(this.picturePrevious, "picturePrevious");
            this.picturePrevious.Name = "picturePrevious";
            this.picturePrevious.TabStop = false;
            // 
            // pictureNext
            // 
            resources.ApplyResources(this.pictureNext, "pictureNext");
            this.pictureNext.Name = "pictureNext";
            this.pictureNext.TabStop = false;
            // 
            // Informations
            // 
            this.Informations.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.Informations, "Informations");
            this.Informations.File = null;
            this.Informations.Name = "Informations";
            this.Informations.Title = "Informations";
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table);
            this.Controls.Add(this.Informations);
            this.DoubleBuffered = true;
            this.Name = "Main";
            this.table.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturePrevious)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureNext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.CollapsibleInformation Informations;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox picturePrevious;
        private System.Windows.Forms.PictureBox pictureNext;
    }
}
