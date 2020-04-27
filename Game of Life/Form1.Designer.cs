namespace Game_of_Life
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.panel = new System.Windows.Forms.Panel();
			this.UniversePanel = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.UniversePanel)).BeginInit();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.BackColor = System.Drawing.SystemColors.Control;
			this.panel.Controls.Add(this.UniversePanel);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 0);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(1684, 961);
			this.panel.TabIndex = 0;
			// 
			// UniversePanel
			// 
			this.UniversePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.UniversePanel.Location = new System.Drawing.Point(0, 0);
			this.UniversePanel.Name = "UniversePanel";
			this.UniversePanel.Size = new System.Drawing.Size(1684, 961);
			this.UniversePanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.UniversePanel.TabIndex = 0;
			this.UniversePanel.TabStop = false;
			this.UniversePanel.WaitOnLoad = true;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 20;
			this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1684, 961);
			this.Controls.Add(this.panel);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.MaximumSize = new System.Drawing.Size(1700, 1000);
			this.MinimumSize = new System.Drawing.Size(1700, 1000);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Game of Life";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.UniversePanel)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox UniversePanel;
        private System.Windows.Forms.Timer timer1;
    }
}

