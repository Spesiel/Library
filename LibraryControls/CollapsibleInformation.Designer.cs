namespace Library.Controls
{
    partial class CollapsibleInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CollapsibleInformation));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTag = new System.Windows.Forms.TabPage();
            this.flowTags = new Penelope.Controls.FlowInput();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.tabPageExif = new System.Windows.Forms.TabPage();
            this.listExif = new System.Windows.Forms.ListView();
            this.flowPersons = new Penelope.Controls.FlowInput();
            this.tabControl.SuspendLayout();
            this.tabPageTag.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.tabPageExif.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTag);
            this.tabControl.Controls.Add(this.tabPagePerson);
            this.tabControl.Controls.Add(this.tabPageExif);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageTag
            // 
            this.tabPageTag.Controls.Add(this.flowTags);
            resources.ApplyResources(this.tabPageTag, "tabPageTag");
            this.tabPageTag.Name = "tabPageTag";
            this.tabPageTag.UseVisualStyleBackColor = true;
            // 
            // flowTags
            // 
            resources.ApplyResources(this.flowTags, "flowTags");
            this.flowTags.BackColor = System.Drawing.SystemColors.Control;
            this.flowTags.Name = "flowTags";
            // 
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.flowPersons);
            resources.ApplyResources(this.tabPagePerson, "tabPagePerson");
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // flowPersons
            // 
            resources.ApplyResources(this.flowPersons, "flowPersons");
            this.flowPersons.BackColor = System.Drawing.SystemColors.Control;
            this.flowPersons.Name = "flowPersons";
            // 
            // tabPageExif
            // 
            this.tabPageExif.Controls.Add(this.listExif);
            resources.ApplyResources(this.tabPageExif, "tabPageExif");
            this.tabPageExif.Name = "tabPageExif";
            this.tabPageExif.UseVisualStyleBackColor = true;
            // 
            // listExif
            // 
            resources.ApplyResources(this.listExif, "listExif");
            this.listExif.LabelEdit = true;
            this.listExif.Name = "listExif";
            this.listExif.UseCompatibleStateImageBehavior = false;
            this.listExif.View = System.Windows.Forms.View.List;
            // 
            // CollapsibleInformation
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tabControl);
            this.Name = "CollapsibleInformation";
            resources.ApplyResources(this, "$this");
            this.Title = "Informations";
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.tabControl.ResumeLayout(false);
            this.tabPageTag.ResumeLayout(false);
            this.tabPagePerson.ResumeLayout(false);
            this.tabPageExif.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageExif;
        private System.Windows.Forms.TabPage tabPagePerson;
        private System.Windows.Forms.ListView listExif;
        private System.Windows.Forms.TabPage tabPageTag;
        private Penelope.Controls.FlowInput flowTags;
        private Penelope.Controls.FlowInput flowPersons;
    }
}
