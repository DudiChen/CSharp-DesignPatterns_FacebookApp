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
            this.richTextBoxPost = new System.Windows.Forms.RichTextBox();
            this.buttonPostLikes = new System.Windows.Forms.Button();
            this.buttonPostComments = new System.Windows.Forms.Button();
            this.richTextBoxLikes = new System.Windows.Forms.RichTextBox();
            this.richTextBoxComments = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).BeginInit();
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
            this.labelPostTimeAndFrom.Size = new System.Drawing.Size(743, 27);
            this.labelPostTimeAndFrom.TabIndex = 1;
            this.labelPostTimeAndFrom.Text = "label1";
            // 
            // richTextBoxPost
            // 
            this.richTextBoxPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxPost.Location = new System.Drawing.Point(0, 44);
            this.richTextBoxPost.Name = "richTextBoxPost";
            this.richTextBoxPost.ReadOnly = true;
            this.richTextBoxPost.Size = new System.Drawing.Size(502, 131);
            this.richTextBoxPost.TabIndex = 2;
            this.richTextBoxPost.Text = "";
            // 
            // buttonPostLikes
            // 
            this.buttonPostLikes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostLikes.Location = new System.Drawing.Point(508, 14);
            this.buttonPostLikes.Name = "buttonPostLikes";
            this.buttonPostLikes.Size = new System.Drawing.Size(112, 27);
            this.buttonPostLikes.TabIndex = 3;
            this.buttonPostLikes.Text = "Likes";
            this.buttonPostLikes.UseVisualStyleBackColor = true;
            this.buttonPostLikes.Click += new System.EventHandler(this.buttonPostLikes_Click);
            // 
            // buttonPostComments
            // 
            this.buttonPostComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPostComments.Location = new System.Drawing.Point(644, 14);
            this.buttonPostComments.Name = "buttonPostComments";
            this.buttonPostComments.Size = new System.Drawing.Size(112, 27);
            this.buttonPostComments.TabIndex = 4;
            this.buttonPostComments.Text = "Comments";
            this.buttonPostComments.UseVisualStyleBackColor = true;
            this.buttonPostComments.Click += new System.EventHandler(this.buttonPostComments_Click);
            // 
            // richTextBoxLikes
            // 
            this.richTextBoxLikes.Location = new System.Drawing.Point(508, 44);
            this.richTextBoxLikes.Name = "richTextBoxLikes";
            this.richTextBoxLikes.Size = new System.Drawing.Size(307, 131);
            this.richTextBoxLikes.TabIndex = 5;
            this.richTextBoxLikes.Text = "";
            // 
            // richTextBoxComments
            // 
            this.richTextBoxComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxComments.Location = new System.Drawing.Point(508, 44);
            this.richTextBoxComments.Name = "richTextBoxComments";
            this.richTextBoxComments.Size = new System.Drawing.Size(307, 131);
            this.richTextBoxComments.TabIndex = 6;
            this.richTextBoxComments.Text = "";
            // 
            // PostBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBoxComments);
            this.Controls.Add(this.richTextBoxLikes);
            this.Controls.Add(this.buttonPostComments);
            this.Controls.Add(this.buttonPostLikes);
            this.Controls.Add(this.richTextBoxPost);
            this.Controls.Add(this.labelPostTimeAndFrom);
            this.Controls.Add(this.pictureBoxPostProfilePic);
            this.Name = "PostBox";
            this.Size = new System.Drawing.Size(818, 175);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPostProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPostProfilePic;
        private System.Windows.Forms.Label labelPostTimeAndFrom;
        private System.Windows.Forms.RichTextBox richTextBoxPost;
        private System.Windows.Forms.Button buttonPostLikes;
        private System.Windows.Forms.Button buttonPostComments;
        private System.Windows.Forms.RichTextBox richTextBoxLikes;
        private System.Windows.Forms.RichTextBox richTextBoxComments;
    }
}
