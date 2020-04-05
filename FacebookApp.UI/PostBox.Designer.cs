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
            this.listViewPost = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPostProfilePic
            // 
            this.pictureBoxPostProfilePic.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxPostProfilePic.Name = "pictureBoxPostProfilePic";
            this.pictureBoxPostProfilePic.Size = new System.Drawing.Size(56, 47);
            this.pictureBoxPostProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPostProfilePic.TabIndex = 0;
            this.pictureBoxPostProfilePic.TabStop = false;
            // 
            // labelPostTimeAndFrom
            // 
            this.labelPostTimeAndFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPostTimeAndFrom.Location = new System.Drawing.Point(69, 24);
            this.labelPostTimeAndFrom.Name = "labelPostTimeAndFrom";
            this.labelPostTimeAndFrom.Size = new System.Drawing.Size(592, 27);
            this.labelPostTimeAndFrom.TabIndex = 1;
            this.labelPostTimeAndFrom.Text = "label1";
            // 
            // listViewPost
            // 
            this.listViewPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPost.Location = new System.Drawing.Point(3, 57);
            this.listViewPost.Name = "listViewPost";
            this.listViewPost.Size = new System.Drawing.Size(658, 71);
            this.listViewPost.TabIndex = 2;
            this.listViewPost.UseCompatibleStateImageBehavior = false;
            // 
            // PostBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewPost);
            this.Controls.Add(this.labelPostTimeAndFrom);
            this.Controls.Add(this.pictureBoxPostProfilePic);
            this.Name = "PostBox";
            this.Size = new System.Drawing.Size(664, 131);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPostProfilePic;
        private System.Windows.Forms.Label labelPostTimeAndFrom;
        private System.Windows.Forms.ListView listViewPost;
    }
}
