namespace Import
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.outputLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.itemsImpOutLabel = new System.Windows.Forms.Label();
            this.countImportLabel = new System.Windows.Forms.Label();
            this.newItemLabel = new System.Windows.Forms.Label();
            this.countNewItemLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // outputLabel
            // 
            this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputLabel.Location = new System.Drawing.Point(13, 498);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(301, 21);
            this.outputLabel.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 13);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(727, 482);
            this.dataGridView1.TabIndex = 2;
            // 
            // itemsImpOutLabel
            // 
            this.itemsImpOutLabel.AutoSize = true;
            this.itemsImpOutLabel.Location = new System.Drawing.Point(12, 529);
            this.itemsImpOutLabel.Name = "itemsImpOutLabel";
            this.itemsImpOutLabel.Size = new System.Drawing.Size(79, 13);
            this.itemsImpOutLabel.TabIndex = 3;
            this.itemsImpOutLabel.Text = "Items Imported:";
            // 
            // countImportLabel
            // 
            this.countImportLabel.AutoSize = true;
            this.countImportLabel.Location = new System.Drawing.Point(100, 529);
            this.countImportLabel.Name = "countImportLabel";
            this.countImportLabel.Size = new System.Drawing.Size(0, 13);
            this.countImportLabel.TabIndex = 4;
            // 
            // newItemLabel
            // 
            this.newItemLabel.AutoSize = true;
            this.newItemLabel.Location = new System.Drawing.Point(13, 546);
            this.newItemLabel.Name = "newItemLabel";
            this.newItemLabel.Size = new System.Drawing.Size(60, 13);
            this.newItemLabel.TabIndex = 5;
            this.newItemLabel.Text = "New Items:";
            // 
            // countNewItemLabel
            // 
            this.countNewItemLabel.AutoSize = true;
            this.countNewItemLabel.Location = new System.Drawing.Point(100, 546);
            this.countNewItemLabel.Name = "countNewItemLabel";
            this.countNewItemLabel.Size = new System.Drawing.Size(0, 13);
            this.countNewItemLabel.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 602);
            this.Controls.Add(this.countNewItemLabel);
            this.Controls.Add(this.newItemLabel);
            this.Controls.Add(this.countImportLabel);
            this.Controls.Add(this.itemsImpOutLabel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label itemsImpOutLabel;
        private System.Windows.Forms.Label countImportLabel;
        private System.Windows.Forms.Label newItemLabel;
        private System.Windows.Forms.Label countNewItemLabel;
    }
}

