namespace DetectionFilterForm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btnNightFilter = new System.Windows.Forms.Button();
            this.btnSaveNewImage = new System.Windows.Forms.Button();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.Laplacian3x3 = new System.Windows.Forms.Button();
            this.Laplacian5x5 = new System.Windows.Forms.Button();
            this.LaplacianGaussian = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(30, 335);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 45);
            this.button2.TabIndex = 43;
            this.button2.Text = "No filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(210, 653);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 50);
            this.button1.TabIndex = 42;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(30, 137);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(128, 45);
            this.button12.TabIndex = 41;
            this.button12.Text = "Black White";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnNightFilter
            // 
            this.btnNightFilter.Location = new System.Drawing.Point(30, 204);
            this.btnNightFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnNightFilter.Name = "btnNightFilter";
            this.btnNightFilter.Size = new System.Drawing.Size(128, 45);
            this.btnNightFilter.TabIndex = 40;
            this.btnNightFilter.Text = "Swap";
            this.btnNightFilter.UseVisualStyleBackColor = true;
            this.btnNightFilter.Click += new System.EventHandler(this.btnNightFilter_Click);
            // 
            // btnSaveNewImage
            // 
            this.btnSaveNewImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveNewImage.Location = new System.Drawing.Point(937, 653);
            this.btnSaveNewImage.Name = "btnSaveNewImage";
            this.btnSaveNewImage.Size = new System.Drawing.Size(183, 46);
            this.btnSaveNewImage.TabIndex = 38;
            this.btnSaveNewImage.Text = "Save Image";
            this.btnSaveNewImage.UseVisualStyleBackColor = true;
            this.btnSaveNewImage.Click += new System.EventHandler(this.btnSaveNewImage_Click);
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.Color.Silver;
            this.picPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picPreview.Location = new System.Drawing.Point(210, 35);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(910, 585);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 37;
            this.picPreview.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 267);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 45);
            this.button3.TabIndex = 44;
            this.button3.Text = "Mega Pink";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Laplacian3x3
            // 
            this.Laplacian3x3.Location = new System.Drawing.Point(1145, 142);
            this.Laplacian3x3.Name = "Laplacian3x3";
            this.Laplacian3x3.Size = new System.Drawing.Size(181, 40);
            this.Laplacian3x3.TabIndex = 45;
            this.Laplacian3x3.Text = "Laplacian 3x3";
            this.Laplacian3x3.UseVisualStyleBackColor = true;
            this.Laplacian3x3.Click += new System.EventHandler(this.Laplacian3x3_Click);
            // 
            // Laplacian5x5
            // 
            this.Laplacian5x5.Location = new System.Drawing.Point(1145, 209);
            this.Laplacian5x5.Name = "Laplacian5x5";
            this.Laplacian5x5.Size = new System.Drawing.Size(181, 40);
            this.Laplacian5x5.TabIndex = 46;
            this.Laplacian5x5.Text = "Laplacian 5x5";
            this.Laplacian5x5.UseVisualStyleBackColor = true;
            this.Laplacian5x5.Click += new System.EventHandler(this.Laplacian5x5_Click);
            // 
            // LaplacianGaussian
            // 
            this.LaplacianGaussian.Location = new System.Drawing.Point(1145, 272);
            this.LaplacianGaussian.Name = "LaplacianGaussian";
            this.LaplacianGaussian.Size = new System.Drawing.Size(181, 40);
            this.LaplacianGaussian.TabIndex = 47;
            this.LaplacianGaussian.Text = "Laplacian of Gaussian";
            this.LaplacianGaussian.UseVisualStyleBackColor = true;
            this.LaplacianGaussian.Click += new System.EventHandler(this.LaplacianGaussian_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(1145, 340);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(181, 40);
            this.Reset.TabIndex = 48;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Filters Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1154, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 17);
            this.label2.TabIndex = 50;
            this.label2.Text = "Edge Detection Options";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 745);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.LaplacianGaussian);
            this.Controls.Add(this.Laplacian5x5);
            this.Controls.Add(this.Laplacian3x3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.btnNightFilter);
            this.Controls.Add(this.btnSaveNewImage);
            this.Controls.Add(this.picPreview);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btnNightFilter;
        private System.Windows.Forms.Button btnSaveNewImage;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button Laplacian3x3;
        private System.Windows.Forms.Button Laplacian5x5;
        private System.Windows.Forms.Button LaplacianGaussian;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

