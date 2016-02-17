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
            this.listTag = new System.Windows.Forms.ListView();
            this.tabPageExif = new System.Windows.Forms.TabPage();
            this.listExif = new System.Windows.Forms.ListView();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.listPerson = new System.Windows.Forms.ListView();
            this.tableTags = new System.Windows.Forms.TableLayoutPanel();
            this.pictureTagAdd = new System.Windows.Forms.PictureBox();
            this.pictureTagRemove = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.tabPageTag.SuspendLayout();
            this.tabPageExif.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.tableTags.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTagAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTagRemove)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTag);
            this.tabControl.Controls.Add(this.tabPageExif);
            this.tabControl.Controls.Add(this.tabPagePerson);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageTag
            // 
            this.tabPageTag.Controls.Add(this.tableTags);
            resources.ApplyResources(this.tabPageTag, "tabPageTag");
            this.tabPageTag.Name = "tabPageTag";
            this.tabPageTag.UseVisualStyleBackColor = true;
            // 
            // listTag
            // 
            resources.ApplyResources(this.listTag, "listTag");
            this.listTag.LabelEdit = true;
            this.listTag.Name = "listTag";
            this.tableTags.SetRowSpan(this.listTag, 5);
            this.listTag.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listTag.UseCompatibleStateImageBehavior = false;
            this.listTag.View = System.Windows.Forms.View.List;
            this.listTag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listTagOnKeyPress);
            this.listTag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listTagOnMouseDown);
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
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.listPerson);
            resources.ApplyResources(this.tabPagePerson, "tabPagePerson");
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // listPerson
            // 
            resources.ApplyResources(this.listPerson, "listPerson");
            this.listPerson.LabelEdit = true;
            this.listPerson.Name = "listPerson";
            this.listPerson.UseCompatibleStateImageBehavior = false;
            this.listPerson.View = System.Windows.Forms.View.List;
            // 
            // tableTags
            // 
            resources.ApplyResources(this.tableTags, "tableTags");
            this.tableTags.Controls.Add(this.listTag, 0, 0);
            this.tableTags.Controls.Add(this.pictureTagAdd, 1, 1);
            this.tableTags.Controls.Add(this.pictureTagRemove, 1, 3);
            this.tableTags.Name = "tableTags";
            // 
            // pictureTagAdd
            // 
            resources.ApplyResources(this.pictureTagAdd, "pictureTagAdd");
            this.pictureTagAdd.Name = "pictureTagAdd";
            this.pictureTagAdd.TabStop = false;
            this.pictureTagAdd.Click += new System.EventHandler(this.pictureTagAddOnClick);
            // 
            // pictureTagRemove
            // 
            resources.ApplyResources(this.pictureTagRemove, "pictureTagRemove");
            this.pictureTagRemove.Name = "pictureTagRemove";
            this.pictureTagRemove.TabStop = false;
            this.pictureTagRemove.Click += new System.EventHandler(this.pictureTagRemoveOnClick);
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
            this.tabPageExif.ResumeLayout(false);
            this.tabPagePerson.ResumeLayout(false);
            this.tableTags.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTagAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTagRemove)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageExif;
        private System.Windows.Forms.TabPage tabPageTag;
        private System.Windows.Forms.TabPage tabPagePerson;
        private System.Windows.Forms.ListView listExif;
        private System.Windows.Forms.ListView listPerson;
        private System.Windows.Forms.ListView listTag;
        private System.Windows.Forms.TableLayoutPanel tableTags;
        private System.Windows.Forms.PictureBox pictureTagAdd;
        private System.Windows.Forms.PictureBox pictureTagRemove;
    }
}
