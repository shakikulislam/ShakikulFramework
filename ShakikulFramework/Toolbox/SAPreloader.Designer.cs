namespace ShakikulFramework.Toolbox
{
    partial class SAPreloader
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SAPreloader));
            this.circlePreloader = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // circlePreloader
            // 
            this.circlePreloader.animated = true;
            this.circlePreloader.animationIterval = 1;
            this.circlePreloader.animationSpeed = 10;
            this.circlePreloader.BackColor = System.Drawing.Color.Transparent;
            this.circlePreloader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("circlePreloader.BackgroundImage")));
            this.circlePreloader.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.circlePreloader.ForeColor = System.Drawing.Color.SeaGreen;
            this.circlePreloader.LabelVisible = false;
            this.circlePreloader.LineProgressThickness = 8;
            this.circlePreloader.LineThickness = 5;
            this.circlePreloader.Location = new System.Drawing.Point(22, 22);
            this.circlePreloader.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.circlePreloader.MaxValue = 100;
            this.circlePreloader.Name = "circlePreloader";
            this.circlePreloader.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.circlePreloader.ProgressColor = System.Drawing.Color.SeaGreen;
            this.circlePreloader.Size = new System.Drawing.Size(106, 106);
            this.circlePreloader.TabIndex = 1;
            this.circlePreloader.Value = 20;
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // SAPreloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.circlePreloader);
            this.Name = "SAPreloader";
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuCircleProgressbar circlePreloader;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Timer timer;
    }
}
