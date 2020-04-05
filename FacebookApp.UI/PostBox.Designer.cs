namespace FacebookApp.UI
{
    partial class PostBox
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
            this.pictureBoxPostProfilePic = new System.Windows.Forms.PictureBox();
            this.labelPostTimeAndFrom = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPostProfilePic
            // 
            this.pictureBoxPostProfilePic.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxPostProfilePic.Name = "pictureBoxPostProfilePic";
            this.pictureBoxPostProfilePic.Size = new System.Drawing.Size(50, 37);
            this.pictureBoxPostProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPostProfilePic.TabIndex = 0;
            this.pictureBoxPostProfilePic.TabStop = false;
            // 
            // labelPostTimeAndFrom
            // 
            this.labelPostTimeAndFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPostTimeAndFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostTimeAndFrom.Location = new System.Drawing.Point(72, 14);
            this.labelPostTimeAndFrom.Name = "labelPostTimeAndFrom";
            this.labelPostTimeAndFrom.Size = new System.Drawing.Size(592, 27);
            this.labelPostTimeAndFrom.TabIndex = 1;
            this.labelPostTimeAndFrom.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPost});
            this.dataGridView1.Location = new System.Drawing.Point(4, 48);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(660, 103);
            this.dataGridView1.TabIndex = 2;
            // 
            // ColumnPost
            // 
            this.ColumnPost.HeaderText = "";
            this.ColumnPost.Name = "ColumnPost";
            this.ColumnPost.ReadOnly = true;
            this.ColumnPost.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPost.Width = 5;
            // 
            // PostBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelPostTimeAndFrom);
            this.Controls.Add(this.pictureBoxPostProfilePic);
            this.Name = "PostBox";
            this.Size = new System.Drawing.Size(667, 154);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPostProfilePic;
        private System.Windows.Forms.Label labelPostTimeAndFrom;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPost;
    }
}
