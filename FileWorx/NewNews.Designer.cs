namespace FileWorx
{
    partial class NewNews
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
            this.Title = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.category = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.titleTB = new System.Windows.Forms.TextBox();
            this.descriptionTB = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.body = new System.Windows.Forms.RichTextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(25, 21);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(50, 24);
            this.Title.TabIndex = 0;
            this.Title.Text = "Title";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(25, 47);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(115, 24);
            this.description.TabIndex = 1;
            this.description.Text = "Description";
            // 
            // category
            // 
            this.category.AutoSize = true;
            this.category.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.category.Location = new System.Drawing.Point(25, 73);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(93, 24);
            this.category.TabIndex = 2;
            this.category.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Body";
            // 
            // titleTB
            // 
            this.titleTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleTB.Location = new System.Drawing.Point(210, 21);
            this.titleTB.MaxLength = 255;
            this.titleTB.Name = "titleTB";
            this.titleTB.Size = new System.Drawing.Size(339, 20);
            this.titleTB.TabIndex = 4;
            // 
            // descriptionTB
            // 
            this.descriptionTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.descriptionTB.Location = new System.Drawing.Point(210, 47);
            this.descriptionTB.MaxLength = 255;
            this.descriptionTB.Name = "descriptionTB";
            this.descriptionTB.Size = new System.Drawing.Size(339, 20);
            this.descriptionTB.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "General",
            "Sports",
            "Health",
            "Politics"});
            this.comboBox1.Location = new System.Drawing.Point(210, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(339, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // body
            // 
            this.body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.body.Location = new System.Drawing.Point(210, 100);
            this.body.MaxLength = 10000;
            this.body.Name = "body";
            this.body.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.body.Size = new System.Drawing.Size(339, 208);
            this.body.TabIndex = 7;
            this.body.Text = "";
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(459, 314);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(91, 31);
            this.cancel.TabIndex = 13;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save.Location = new System.Drawing.Point(359, 314);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(94, 31);
            this.Save.TabIndex = 12;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click_1);
            // 
            // NewNews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(562, 355);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.body);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.descriptionTB);
            this.Controls.Add(this.titleTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.category);
            this.Controls.Add(this.description);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New News";
            this.Load += new System.EventHandler(this.NewNews_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox titleTB;
        private System.Windows.Forms.TextBox descriptionTB;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox body;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button Save;
    }
}

