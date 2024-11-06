using CodingTest.Entities;
using CodingTest.Services;
using System.ComponentModel;

namespace CodingTest.UI
{
    partial class MainForm
    {


        private System.ComponentModel.IContainer components = null;



        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dataGridViewDatas = new DataGridView();
            textBox1 = new TextBox();
            SetPath = new Button();
            MonitoringFrequencyNumeric = new NumericUpDown();
            StartStop = new Button();
            statusStrip1 = new StatusStrip();
            Datas = new Label();
            DirectoryPath = new Label();
            MonitoringFrequency = new Label();
            StartStopMonitoring = new Label();
            ((ISupportInitialize)dataGridViewDatas).BeginInit();
            ((ISupportInitialize)MonitoringFrequencyNumeric).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDatas
            // 
            dataGridViewDatas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDatas.Location = new Point(0, 71);
            dataGridViewDatas.Name = "dataGridViewDatas";
            dataGridViewDatas.RowHeadersWidth = 51;
            dataGridViewDatas.Size = new Size(425, 188);
            dataGridViewDatas.TabIndex = 0;
            dataGridViewDatas.CellContentClick += dataGridViewDatas_CellContentClick;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(455, 44);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(333, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // SetPath
            // 
            SetPath.Location = new Point(571, 99);
            SetPath.Name = "SetPath";
            SetPath.Size = new Size(94, 29);
            SetPath.TabIndex = 2;
            SetPath.Text = "SetPath";
            SetPath.UseVisualStyleBackColor = true;
            SetPath.Click += SetPath_Click;
            // 
            // MonitoringFrequencyNumeric
            // 
            MonitoringFrequencyNumeric.Location = new Point(545, 173);
            MonitoringFrequencyNumeric.Name = "MonitoringFrequencyNumeric";
            MonitoringFrequencyNumeric.Size = new Size(150, 27);
            MonitoringFrequencyNumeric.TabIndex = 3;
            MonitoringFrequencyNumeric.ValueChanged += MonitoringFrequencyNumeric_ValueChanged;
            // 
            // StartStop
            // 
            StartStop.Location = new Point(571, 270);
            StartStop.Name = "StartStop";
            StartStop.Size = new Size(94, 29);
            StartStop.TabIndex = 4;
            StartStop.Text = "Start/Stop";
            StartStop.UseVisualStyleBackColor = true;
            StartStop.Click += StartStop_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // Datas
            // 
            Datas.AutoSize = true;
            Datas.Location = new Point(77, 44);
            Datas.Name = "Datas";
            Datas.Size = new Size(47, 20);
            Datas.TabIndex = 6;
            Datas.Text = "Datas";
            // 
            // DirectoryPath
            // 
            DirectoryPath.AutoSize = true;
            DirectoryPath.Location = new Point(571, 19);
            DirectoryPath.Name = "DirectoryPath";
            DirectoryPath.Size = new Size(102, 20);
            DirectoryPath.TabIndex = 7;
            DirectoryPath.Text = " DirectoryPath";
            // 
            // MonitoringFrequency
            // 
            MonitoringFrequency.AutoSize = true;
            MonitoringFrequency.Location = new Point(545, 150);
            MonitoringFrequency.Name = "MonitoringFrequency";
            MonitoringFrequency.Size = new Size(150, 20);
            MonitoringFrequency.TabIndex = 8;
            MonitoringFrequency.Text = "MonitoringFrequency";
            // 
            // StartStopMonitoring
            // 
            StartStopMonitoring.AutoSize = true;
            StartStopMonitoring.Location = new Point(545, 228);
            StartStopMonitoring.Name = "StartStopMonitoring";
            StartStopMonitoring.Size = new Size(155, 20);
            StartStopMonitoring.TabIndex = 9;
            StartStopMonitoring.Text = "Start/Stop Monitoring";
            StartStopMonitoring.Click += StartStopMonitoring_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(StartStopMonitoring);
            Controls.Add(MonitoringFrequency);
            Controls.Add(DirectoryPath);
            Controls.Add(Datas);
            Controls.Add(statusStrip1);
            Controls.Add(StartStop);
            Controls.Add(MonitoringFrequencyNumeric);
            Controls.Add(SetPath);
            Controls.Add(textBox1);
            Controls.Add(dataGridViewDatas);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((ISupportInitialize)dataGridViewDatas).EndInit();
            ((ISupportInitialize)MonitoringFrequencyNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private void InitializeControls()
        {

            dataGridViewDatas.DataSource = _dataList;
            dataGridViewDatas.AutoGenerateColumns = true;
            dataGridViewDatas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            MonitoringFrequencyNumeric.Value = 5;

        }

        #endregion

        private DataGridView dataGridViewDatas;
        private TextBox textBox1;
        private Button SetPath;
        private NumericUpDown MonitoringFrequencyNumeric;
        private Button StartStop;
        private StatusStrip statusStrip1;
        private Label Datas;
        private Label DirectoryPath;
        private Label MonitoringFrequency;
        private Label StartStopMonitoring;
    }
}