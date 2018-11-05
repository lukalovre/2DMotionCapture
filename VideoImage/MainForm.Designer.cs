using System.Windows.Forms;

namespace MoCap
{
    partial class MainForm
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
            if(disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.btnRestartStartPositions = new System.Windows.Forms.Button();
            this.btnSaveStartPosition = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnRewind = new System.Windows.Forms.Button();
            this.progressBarVideo = new System.Windows.Forms.ProgressBar();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.btnAuto = new System.Windows.Forms.Button();
            this.trackBarAnimation = new System.Windows.Forms.TrackBar();
            this.labelAnimationFrames = new System.Windows.Forms.Label();
            this.cbAutoPlay = new System.Windows.Forms.CheckBox();
            this.labelStartPosition = new System.Windows.Forms.Label();
            this.labelEndPosition = new System.Windows.Forms.Label();
            this.pbAnimation = new System.Windows.Forms.PictureBox();
            this.trackBarStart = new System.Windows.Forms.TrackBar();
            this.trackBarEnd = new System.Windows.Forms.TrackBar();
            this.checkBoxReverse = new System.Windows.Forms.CheckBox();
            this.checkBoxLoop = new System.Windows.Forms.CheckBox();
            this.trackBarAnimationSpeed = new System.Windows.Forms.TrackBar();
            this.checkBoxHead = new System.Windows.Forms.CheckBox();
            this.buttonSaveProject = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTimeSeconds = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbMain.Location = new System.Drawing.Point(12, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(347, 544);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PbMainPaint);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbMainMouseClick);
            // 
            // btnRestartStartPositions
            // 
            this.btnRestartStartPositions.Location = new System.Drawing.Point(868, 603);
            this.btnRestartStartPositions.Name = "btnRestartStartPositions";
            this.btnRestartStartPositions.Size = new System.Drawing.Size(75, 23);
            this.btnRestartStartPositions.TabIndex = 2;
            this.btnRestartStartPositions.Text = "ResStartPositions";
            this.btnRestartStartPositions.UseVisualStyleBackColor = true;
            this.btnRestartStartPositions.Click += new System.EventHandler(this.BtnRestartStartPositionsClick);
            // 
            // btnSaveStartPosition
            // 
            this.btnSaveStartPosition.Location = new System.Drawing.Point(869, 574);
            this.btnSaveStartPosition.Name = "btnSaveStartPosition";
            this.btnSaveStartPosition.Size = new System.Drawing.Size(75, 23);
            this.btnSaveStartPosition.TabIndex = 3;
            this.btnSaveStartPosition.Text = "SaveStartPos";
            this.btnSaveStartPosition.UseVisualStyleBackColor = true;
            this.btnSaveStartPosition.Click += new System.EventHandler(this.BtnSaveStartPositionClick);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(829, 11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNextClick);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(789, 11);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 23);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.BtnPreviousClick);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(910, 11);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(34, 23);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.Text = ">>";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlayClick);
            // 
            // btnRewind
            // 
            this.btnRewind.Location = new System.Drawing.Point(749, 11);
            this.btnRewind.Name = "btnRewind";
            this.btnRewind.Size = new System.Drawing.Size(34, 23);
            this.btnRewind.TabIndex = 7;
            this.btnRewind.Text = "<<";
            this.btnRewind.UseVisualStyleBackColor = true;
            this.btnRewind.Click += new System.EventHandler(this.BtnRewindClick);
            // 
            // progressBarVideo
            // 
            this.progressBarVideo.Location = new System.Drawing.Point(749, 65);
            this.progressBarVideo.Name = "progressBarVideo";
            this.progressBarVideo.Size = new System.Drawing.Size(195, 23);
            this.progressBarVideo.Step = 1;
            this.progressBarVideo.TabIndex = 8;
            // 
            // timerAnimation
            // 
            this.timerAnimation.Tick += new System.EventHandler(this.AnimationTimer);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(829, 36);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(75, 23);
            this.btnAuto.TabIndex = 9;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.BtnAutoClick);
            // 
            // trackBarAnimation
            // 
            this.trackBarAnimation.Location = new System.Drawing.Point(405, 574);
            this.trackBarAnimation.Name = "trackBarAnimation";
            this.trackBarAnimation.Size = new System.Drawing.Size(330, 45);
            this.trackBarAnimation.TabIndex = 10;
            this.trackBarAnimation.Scroll += new System.EventHandler(this.TrackBarAnimationScroll);
            // 
            // labelAnimationFrames
            // 
            this.labelAnimationFrames.AutoSize = true;
            this.labelAnimationFrames.Location = new System.Drawing.Point(736, 439);
            this.labelAnimationFrames.Name = "labelAnimationFrames";
            this.labelAnimationFrames.Size = new System.Drawing.Size(47, 13);
            this.labelAnimationFrames.TabIndex = 11;
            this.labelAnimationFrames.Text = "Frames: ";
            // 
            // cbAutoPlay
            // 
            this.cbAutoPlay.AutoSize = true;
            this.cbAutoPlay.Location = new System.Drawing.Point(739, 468);
            this.cbAutoPlay.Name = "cbAutoPlay";
            this.cbAutoPlay.Size = new System.Drawing.Size(70, 17);
            this.cbAutoPlay.TabIndex = 12;
            this.cbAutoPlay.Text = "Auto play";
            this.cbAutoPlay.UseVisualStyleBackColor = true;
            // 
            // labelStartPosition
            // 
            this.labelStartPosition.AutoSize = true;
            this.labelStartPosition.Location = new System.Drawing.Point(367, 627);
            this.labelStartPosition.Name = "labelStartPosition";
            this.labelStartPosition.Size = new System.Drawing.Size(32, 13);
            this.labelStartPosition.TabIndex = 16;
            this.labelStartPosition.Text = "Start:";
            // 
            // labelEndPosition
            // 
            this.labelEndPosition.AutoSize = true;
            this.labelEndPosition.Location = new System.Drawing.Point(367, 678);
            this.labelEndPosition.Name = "labelEndPosition";
            this.labelEndPosition.Size = new System.Drawing.Size(29, 13);
            this.labelEndPosition.TabIndex = 17;
            this.labelEndPosition.Text = "End:";
            // 
            // pbAnimation
            // 
            this.pbAnimation.Location = new System.Drawing.Point(409, 12);
            this.pbAnimation.Name = "pbAnimation";
            this.pbAnimation.Size = new System.Drawing.Size(326, 544);
            this.pbAnimation.TabIndex = 18;
            this.pbAnimation.TabStop = false;
            this.pbAnimation.Paint += new System.Windows.Forms.PaintEventHandler(this.PbAnimationPaint);
            // 
            // trackBarStart
            // 
            this.trackBarStart.Location = new System.Drawing.Point(405, 627);
            this.trackBarStart.Name = "trackBarStart";
            this.trackBarStart.Size = new System.Drawing.Size(330, 45);
            this.trackBarStart.TabIndex = 19;
            this.trackBarStart.Scroll += new System.EventHandler(this.TrackBarStartScroll);
            // 
            // trackBarEnd
            // 
            this.trackBarEnd.Location = new System.Drawing.Point(406, 678);
            this.trackBarEnd.Name = "trackBarEnd";
            this.trackBarEnd.Size = new System.Drawing.Size(329, 45);
            this.trackBarEnd.TabIndex = 20;
            this.trackBarEnd.Scroll += new System.EventHandler(this.TrackBarEndScroll);
            // 
            // checkBoxReverse
            // 
            this.checkBoxReverse.AutoSize = true;
            this.checkBoxReverse.Location = new System.Drawing.Point(815, 468);
            this.checkBoxReverse.Name = "checkBoxReverse";
            this.checkBoxReverse.Size = new System.Drawing.Size(66, 17);
            this.checkBoxReverse.TabIndex = 21;
            this.checkBoxReverse.Text = "Reverse";
            this.checkBoxReverse.UseVisualStyleBackColor = true;
            // 
            // checkBoxLoop
            // 
            this.checkBoxLoop.AutoSize = true;
            this.checkBoxLoop.Location = new System.Drawing.Point(815, 492);
            this.checkBoxLoop.Name = "checkBoxLoop";
            this.checkBoxLoop.Size = new System.Drawing.Size(50, 17);
            this.checkBoxLoop.TabIndex = 22;
            this.checkBoxLoop.Text = "Loop";
            this.checkBoxLoop.UseVisualStyleBackColor = true;
            // 
            // trackBarAnimationSpeed
            // 
            this.trackBarAnimationSpeed.Location = new System.Drawing.Point(741, 196);
            this.trackBarAnimationSpeed.Maximum = 150;
            this.trackBarAnimationSpeed.Name = "trackBarAnimationSpeed";
            this.trackBarAnimationSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAnimationSpeed.Size = new System.Drawing.Size(45, 194);
            this.trackBarAnimationSpeed.TabIndex = 23;
            this.trackBarAnimationSpeed.Scroll += new System.EventHandler(this.TrackBarAnimationSpeedScroll);
            // 
            // checkBoxHead
            // 
            this.checkBoxHead.AutoSize = true;
            this.checkBoxHead.Location = new System.Drawing.Point(815, 536);
            this.checkBoxHead.Name = "checkBoxHead";
            this.checkBoxHead.Size = new System.Drawing.Size(52, 17);
            this.checkBoxHead.TabIndex = 24;
            this.checkBoxHead.Text = "Head";
            this.checkBoxHead.UseVisualStyleBackColor = true;
            this.checkBoxHead.CheckedChanged += new System.EventHandler(this.CheckBoxHeadCheckedChanged);
            // 
            // buttonSaveProject
            // 
            this.buttonSaveProject.Location = new System.Drawing.Point(869, 744);
            this.buttonSaveProject.Name = "buttonSaveProject";
            this.buttonSaveProject.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveProject.TabIndex = 25;
            this.buttonSaveProject.Text = "Save project";
            this.buttonSaveProject.UseVisualStyleBackColor = true;
            this.buttonSaveProject.Click += new System.EventHandler(this.ButtonSaveProjectClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelTime, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeSeconds, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(749, 94);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(118, 13);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(3, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(33, 13);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Time:";
            // 
            // labelTimeSeconds
            // 
            this.labelTimeSeconds.AutoSize = true;
            this.labelTimeSeconds.Location = new System.Drawing.Point(62, 0);
            this.labelTimeSeconds.Name = "labelTimeSeconds";
            this.labelTimeSeconds.Size = new System.Drawing.Size(0, 13);
            this.labelTimeSeconds.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 772);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonSaveProject);
            this.Controls.Add(this.checkBoxHead);
            this.Controls.Add(this.trackBarAnimationSpeed);
            this.Controls.Add(this.checkBoxLoop);
            this.Controls.Add(this.checkBoxReverse);
            this.Controls.Add(this.trackBarEnd);
            this.Controls.Add(this.trackBarStart);
            this.Controls.Add(this.pbAnimation);
            this.Controls.Add(this.labelEndPosition);
            this.Controls.Add(this.labelStartPosition);
            this.Controls.Add(this.cbAutoPlay);
            this.Controls.Add(this.labelAnimationFrames);
            this.Controls.Add(this.trackBarAnimation);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.progressBarVideo);
            this.Controls.Add(this.btnRewind);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnSaveStartPosition);
            this.Controls.Add(this.btnRestartStartPositions);
            this.Controls.Add(this.pbMain);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New project";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAnimation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAnimationSpeed)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Button btnRestartStartPositions;
        private System.Windows.Forms.Button btnSaveStartPosition;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnRewind;
        private System.Windows.Forms.ProgressBar progressBarVideo;
        private System.Windows.Forms.Timer timerAnimation;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.TrackBar trackBarAnimation;
        private System.Windows.Forms.Label labelAnimationFrames;
        private System.Windows.Forms.CheckBox cbAutoPlay;
        private System.Windows.Forms.Label labelStartPosition;
        private System.Windows.Forms.Label labelEndPosition;
        private System.Windows.Forms.PictureBox pbAnimation;
        private System.Windows.Forms.TrackBar trackBarStart;
        private System.Windows.Forms.TrackBar trackBarEnd;
        private System.Windows.Forms.CheckBox checkBoxReverse;
        private System.Windows.Forms.CheckBox checkBoxLoop;
        private System.Windows.Forms.TrackBar trackBarAnimationSpeed;
        private CheckBox checkBoxHead;
        private Button buttonSaveProject;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelTime;
        private Label labelTimeSeconds;
    }
}

