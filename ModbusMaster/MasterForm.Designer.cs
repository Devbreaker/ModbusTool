namespace ModbusMaster
{
    partial class MasterForm
    {

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterForm));
            this.groupBoxFunctions = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPollDelay = new System.Windows.Forms.TextBox();
            this.cbPoll = new System.Windows.Forms.CheckBox();
            this.btnReadCoils = new System.Windows.Forms.Button();
            this.btnReadDisInp = new System.Windows.Forms.Button();
            this.btnWriteMultipleReg = new System.Windows.Forms.Button();
            this.btnReadHoldReg = new System.Windows.Forms.Button();
            this.btnWriteMultipleCoils = new System.Windows.Forms.Button();
            this.btnReadInpReg = new System.Windows.Forms.Button();
            this.btnWriteSingleReg = new System.Windows.Forms.Button();
            this.btnWriteSingleCoil = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.pollTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtChartYMax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnChartUIUdate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChartYTitle = new System.Windows.Forms.TextBox();
            this.txtChartXTitle = new System.Windows.Forms.TextBox();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpStart.SuspendLayout();
            this.groupBoxRTU.SuspendLayout();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxTCP.SuspendLayout();
            this.grpExchange.SuspendLayout();
            this.groupBoxFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(8, 697);
            this.groupBox4.Size = new System.Drawing.Size(1002, 149);
            // 
            // listBoxCommLog
            // 
            this.listBoxCommLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBoxCommLog.Location = new System.Drawing.Point(3, 46);
            this.listBoxCommLog.Size = new System.Drawing.Size(996, 100);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 133);
            this.groupBox3.Size = new System.Drawing.Size(220, 102);
            // 
            // radioButtonInteger
            // 
            this.radioButtonInteger.Location = new System.Drawing.Point(100, 18);
            this.radioButtonInteger.Size = new System.Drawing.Size(75, 19);
            // 
            // grpStart
            // 
            this.grpStart.Controls.Add(this.btnConnect);
            this.grpStart.Controls.Add(this.buttonDisconnect);
            this.grpStart.Location = new System.Drawing.Point(8, 0);
            this.grpStart.Size = new System.Drawing.Size(1002, 127);
            this.grpStart.Enter += new System.EventHandler(this.grpStart_Enter);
            this.grpStart.Controls.SetChildIndex(this.buttonDisconnect, 0);
            this.grpStart.Controls.SetChildIndex(this.btnConnect, 0);
            this.grpStart.Controls.SetChildIndex(this.groupBoxTCP, 0);
            this.grpStart.Controls.SetChildIndex(this.groupBoxMode, 0);
            this.grpStart.Controls.SetChildIndex(this.groupBoxRTU, 0);
            // 
            // groupBoxRTU
            // 
            this.groupBoxRTU.Location = new System.Drawing.Point(345, 12);
            this.groupBoxRTU.Size = new System.Drawing.Size(460, 98);
            // 
            // comboBoxSerialPorts
            // 
            this.comboBoxSerialPorts.Items.AddRange(new object[] {
            "COM1",
            "COM3",
            "COM4"});
            // 
            // label1
            // 
            this.label1.Visible = false;
            // 
            // textBoxSlaveDelay
            // 
            this.textBoxSlaveDelay.Visible = false;
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.Items.AddRange(new object[] {
            "Odd",
            "Even",
            "Mark",
            "Space"});
            // 
            // grpExchange
            // 
            this.grpExchange.Location = new System.Drawing.Point(3, 249);
            this.grpExchange.Size = new System.Drawing.Size(337, 92);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(8, 347);
            this.tabControl1.Size = new System.Drawing.Size(999, 342);
            // 
            // radioButtonReverseFloat
            // 
            this.radioButtonReverseFloat.Location = new System.Drawing.Point(100, 37);
            // 
            // groupBoxFunctions
            // 
            this.groupBoxFunctions.Controls.Add(this.label2);
            this.groupBoxFunctions.Controls.Add(this.txtAddress);
            this.groupBoxFunctions.Controls.Add(this.txtPollDelay);
            this.groupBoxFunctions.Controls.Add(this.cbPoll);
            this.groupBoxFunctions.Controls.Add(this.btnReadCoils);
            this.groupBoxFunctions.Controls.Add(this.btnReadDisInp);
            this.groupBoxFunctions.Controls.Add(this.btnWriteMultipleReg);
            this.groupBoxFunctions.Controls.Add(this.btnReadHoldReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteMultipleCoils);
            this.groupBoxFunctions.Controls.Add(this.btnReadInpReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteSingleReg);
            this.groupBoxFunctions.Controls.Add(this.btnWriteSingleCoil);
            this.groupBoxFunctions.Enabled = false;
            this.groupBoxFunctions.Location = new System.Drawing.Point(251, 133);
            this.groupBoxFunctions.Name = "groupBoxFunctions";
            this.groupBoxFunctions.Size = new System.Drawing.Size(397, 118);
            this.groupBoxFunctions.TabIndex = 35;
            this.groupBoxFunctions.TabStop = false;
            this.groupBoxFunctions.Text = "Functions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 12);
            this.label2.TabIndex = 27;
            this.label2.Text = "address index";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(227, 93);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(60, 21);
            this.txtAddress.TabIndex = 26;
            this.txtAddress.Text = "0";
            // 
            // txtPollDelay
            // 
            this.txtPollDelay.Location = new System.Drawing.Point(65, 92);
            this.txtPollDelay.Name = "txtPollDelay";
            this.txtPollDelay.Size = new System.Drawing.Size(60, 21);
            this.txtPollDelay.TabIndex = 25;
            this.txtPollDelay.Text = "1000";
            this.txtPollDelay.Leave += new System.EventHandler(this.txtPollDelay_Leave);
            // 
            // cbPoll
            // 
            this.cbPoll.AutoSize = true;
            this.cbPoll.Location = new System.Drawing.Point(8, 94);
            this.cbPoll.Name = "cbPoll";
            this.cbPoll.Size = new System.Drawing.Size(45, 16);
            this.cbPoll.TabIndex = 24;
            this.cbPoll.Text = "Poll";
            this.cbPoll.UseVisualStyleBackColor = true;
            this.cbPoll.CheckStateChanged += new System.EventHandler(this.cbPoll_CheckStateChanged);
            // 
            // btnReadCoils
            // 
            this.btnReadCoils.Location = new System.Drawing.Point(7, 18);
            this.btnReadCoils.Name = "btnReadCoils";
            this.btnReadCoils.Size = new System.Drawing.Size(91, 32);
            this.btnReadCoils.TabIndex = 11;
            this.btnReadCoils.Text = "Read coils";
            this.btnReadCoils.Click += new System.EventHandler(this.BtnReadCoilsClick);
            // 
            // btnReadDisInp
            // 
            this.btnReadDisInp.Location = new System.Drawing.Point(7, 55);
            this.btnReadDisInp.Name = "btnReadDisInp";
            this.btnReadDisInp.Size = new System.Drawing.Size(91, 32);
            this.btnReadDisInp.TabIndex = 16;
            this.btnReadDisInp.Text = "Read discrete inputs";
            this.btnReadDisInp.Click += new System.EventHandler(this.BtnReadDisInpClick);
            // 
            // btnWriteMultipleReg
            // 
            this.btnWriteMultipleReg.Location = new System.Drawing.Point(290, 55);
            this.btnWriteMultipleReg.Name = "btnWriteMultipleReg";
            this.btnWriteMultipleReg.Size = new System.Drawing.Size(91, 32);
            this.btnWriteMultipleReg.TabIndex = 23;
            this.btnWriteMultipleReg.Text = "Write multiple register";
            this.btnWriteMultipleReg.Click += new System.EventHandler(this.BtnWriteMultipleRegClick);
            // 
            // btnReadHoldReg
            // 
            this.btnReadHoldReg.Location = new System.Drawing.Point(101, 18);
            this.btnReadHoldReg.Name = "btnReadHoldReg";
            this.btnReadHoldReg.Size = new System.Drawing.Size(91, 32);
            this.btnReadHoldReg.TabIndex = 17;
            this.btnReadHoldReg.Text = "Read holding register";
            this.btnReadHoldReg.Click += new System.EventHandler(this.BtnReadHoldRegClick);
            // 
            // btnWriteMultipleCoils
            // 
            this.btnWriteMultipleCoils.Location = new System.Drawing.Point(290, 18);
            this.btnWriteMultipleCoils.Name = "btnWriteMultipleCoils";
            this.btnWriteMultipleCoils.Size = new System.Drawing.Size(91, 32);
            this.btnWriteMultipleCoils.TabIndex = 22;
            this.btnWriteMultipleCoils.Text = "Write multiple coils";
            this.btnWriteMultipleCoils.Click += new System.EventHandler(this.BtnWriteMultipleCoilsClick);
            // 
            // btnReadInpReg
            // 
            this.btnReadInpReg.Location = new System.Drawing.Point(101, 55);
            this.btnReadInpReg.Name = "btnReadInpReg";
            this.btnReadInpReg.Size = new System.Drawing.Size(91, 32);
            this.btnReadInpReg.TabIndex = 18;
            this.btnReadInpReg.Text = "Read input register";
            this.btnReadInpReg.Click += new System.EventHandler(this.BtnReadInpRegClick);
            // 
            // btnWriteSingleReg
            // 
            this.btnWriteSingleReg.Location = new System.Drawing.Point(196, 55);
            this.btnWriteSingleReg.Name = "btnWriteSingleReg";
            this.btnWriteSingleReg.Size = new System.Drawing.Size(91, 32);
            this.btnWriteSingleReg.TabIndex = 21;
            this.btnWriteSingleReg.Text = "Write single register";
            this.btnWriteSingleReg.Click += new System.EventHandler(this.BtnWriteSingleRegClick);
            // 
            // btnWriteSingleCoil
            // 
            this.btnWriteSingleCoil.Location = new System.Drawing.Point(196, 18);
            this.btnWriteSingleCoil.Name = "btnWriteSingleCoil";
            this.btnWriteSingleCoil.Size = new System.Drawing.Size(91, 32);
            this.btnWriteSingleCoil.TabIndex = 19;
            this.btnWriteSingleCoil.Text = "Write single coil";
            this.btnWriteSingleCoil.Click += new System.EventHandler(this.BtnWriteSingleCoilClick);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Enabled = false;
            this.buttonDisconnect.Location = new System.Drawing.Point(849, 59);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(100, 26);
            this.buttonDisconnect.TabIndex = 37;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.Click += new System.EventHandler(this.ButtonDisconnectClick);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(849, 27);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(100, 26);
            this.btnConnect.TabIndex = 36;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.BtnConnectClick);
            // 
            // pollTimer
            // 
            this.pollTimer.Interval = 2000;
            this.pollTimer.Tick += new System.EventHandler(this.pollTimer_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtChartYMax);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.btnChartUIUdate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtChartYTitle);
            this.groupBox1.Controls.Add(this.txtChartXTitle);
            this.groupBox1.Location = new System.Drawing.Point(663, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 114);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chart";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "Axis Y Max";
            // 
            // txtChartYMax
            // 
            this.txtChartYMax.Location = new System.Drawing.Point(94, 87);
            this.txtChartYMax.Name = "txtChartYMax";
            this.txtChartYMax.Size = new System.Drawing.Size(100, 21);
            this.txtChartYMax.TabIndex = 5;
            this.txtChartYMax.Text = "2000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Axis Y Title";
            // 
            // btnChartUIUdate
            // 
            this.btnChartUIUdate.Location = new System.Drawing.Point(209, 52);
            this.btnChartUIUdate.Name = "btnChartUIUdate";
            this.btnChartUIUdate.Size = new System.Drawing.Size(75, 23);
            this.btnChartUIUdate.TabIndex = 3;
            this.btnChartUIUdate.Text = "Update";
            this.btnChartUIUdate.UseVisualStyleBackColor = true;
            this.btnChartUIUdate.Click += new System.EventHandler(this.btnChartUIUdate_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Axis X Title";
            // 
            // txtChartYTitle
            // 
            this.txtChartYTitle.Location = new System.Drawing.Point(94, 58);
            this.txtChartYTitle.Name = "txtChartYTitle";
            this.txtChartYTitle.Size = new System.Drawing.Size(100, 21);
            this.txtChartYTitle.TabIndex = 1;
            // 
            // txtChartXTitle
            // 
            this.txtChartXTitle.Location = new System.Drawing.Point(94, 27);
            this.txtChartXTitle.Name = "txtChartXTitle";
            this.txtChartXTitle.Size = new System.Drawing.Size(100, 21);
            this.txtChartXTitle.TabIndex = 0;
            // 
            // elementHost1
            // 
            this.elementHost1.Dock = System.Windows.Forms.DockStyle.Right;
            this.elementHost1.Location = new System.Drawing.Point(1016, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(849, 861);
            this.elementHost1.TabIndex = 40;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.ClientSize = new System.Drawing.Size(1865, 861);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxFunctions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MasterForm";
            this.ShowDataLength = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Treed Modbus Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MasterFormClosing);
            this.Controls.SetChildIndex(this.groupBoxFunctions, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.grpExchange, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.grpStart, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.elementHost1, 0);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpStart.ResumeLayout(false);
            this.groupBoxRTU.ResumeLayout(false);
            this.groupBoxRTU.PerformLayout();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxMode.PerformLayout();
            this.groupBoxTCP.ResumeLayout(false);
            this.groupBoxTCP.PerformLayout();
            this.grpExchange.ResumeLayout(false);
            this.grpExchange.PerformLayout();
            this.groupBoxFunctions.ResumeLayout(false);
            this.groupBoxFunctions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFunctions;
        private System.Windows.Forms.Button btnReadCoils;
        private System.Windows.Forms.Button btnReadDisInp;
        private System.Windows.Forms.Button btnWriteMultipleReg;
        private System.Windows.Forms.Button btnReadHoldReg;
        private System.Windows.Forms.Button btnWriteMultipleCoils;
        private System.Windows.Forms.Button btnReadInpReg;
        private System.Windows.Forms.Button btnWriteSingleReg;
        private System.Windows.Forms.Button btnWriteSingleCoil;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPollDelay;
        private System.Windows.Forms.CheckBox cbPoll;
        private System.Windows.Forms.Timer pollTimer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtChartYMax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnChartUIUdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChartYTitle;
        private System.Windows.Forms.TextBox txtChartXTitle;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}
