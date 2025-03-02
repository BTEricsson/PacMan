namespace PacMan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            GameTimer = new System.Windows.Forms.Timer(components);
            Pnl_MainMenu = new Panel();
            lbl_score_info = new Label();
            btn_Play = new Button();
            Pnl_MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // GameTimer
            // 
            GameTimer.Interval = 20;
            GameTimer.Tick += GameStartTimerEvent;
            // 
            // Pnl_MainMenu
            // 
            Pnl_MainMenu.BackColor = Color.FromArgb(20, 20, 20);
            Pnl_MainMenu.BorderStyle = BorderStyle.FixedSingle;
            Pnl_MainMenu.Controls.Add(lbl_score_info);
            Pnl_MainMenu.Controls.Add(btn_Play);
            Pnl_MainMenu.Location = new Point(255, 208);
            Pnl_MainMenu.Name = "Pnl_MainMenu";
            Pnl_MainMenu.Size = new Size(282, 196);
            Pnl_MainMenu.TabIndex = 59;
            // 
            // lbl_score_info
            // 
            lbl_score_info.Anchor = AnchorStyles.Top;
            lbl_score_info.BackColor = Color.Transparent;
            lbl_score_info.Font = new Font("Arial Narrow", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_score_info.ForeColor = Color.Yellow;
            lbl_score_info.Location = new Point(-1, 0);
            lbl_score_info.Name = "lbl_score_info";
            lbl_score_info.Size = new Size(280, 149);
            lbl_score_info.TabIndex = 3;
            lbl_score_info.Text = "...::: Pac Man :::...";
            lbl_score_info.TextAlign = ContentAlignment.TopCenter;
            // 
            // btn_Play
            // 
            btn_Play.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Play.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_Play.Location = new Point(85, 152);
            btn_Play.Name = "btn_Play";
            btn_Play.Size = new Size(115, 38);
            btn_Play.TabIndex = 0;
            btn_Play.Text = "Play";
            btn_Play.UseVisualStyleBackColor = true;
            btn_Play.Click += startGameClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(Pnl_MainMenu);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "PacMan";
            KeyDown += KeyDownEvent;
            Pnl_MainMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer GameTimer;
        private Panel Pnl_MainMenu;
        private Button btn_Play;
        private Label lbl_score_info;
    }
}
