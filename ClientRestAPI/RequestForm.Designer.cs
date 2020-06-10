namespace ClientRestAPI
{
    partial class restAPIForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRestAPI = new System.Windows.Forms.TextBox();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.labelResponse = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.labelMethod = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRestAPI
            // 
            this.txtRestAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestAPI.Location = new System.Drawing.Point(56, 71);
            this.txtRestAPI.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRestAPI.Name = "txtRestAPI";
            this.txtRestAPI.Size = new System.Drawing.Size(593, 35);
            this.txtRestAPI.TabIndex = 0;
            // 
            // txtResponse
            // 
            this.txtResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.Location = new System.Drawing.Point(56, 243);
            this.txtResponse.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(593, 222);
            this.txtResponse.TabIndex = 1;
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(51, 27);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(162, 29);
            this.labelURL.TabIndex = 2;
            this.labelURL.Text = "Request URL:";
            // 
            // labelResponse
            // 
            this.labelResponse.AutoSize = true;
            this.labelResponse.Location = new System.Drawing.Point(51, 192);
            this.labelResponse.Name = "labelResponse";
            this.labelResponse.Size = new System.Drawing.Size(129, 29);
            this.labelResponse.TabIndex = 3;
            this.labelResponse.Text = "Response:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(672, 67);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(89, 43);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.comboBoxMethod.Location = new System.Drawing.Point(157, 127);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(121, 37);
            this.comboBoxMethod.TabIndex = 5;
            this.comboBoxMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxMethod_SelectedIndexChanged);
            // 
            // labelMethod
            // 
            this.labelMethod.AutoSize = true;
            this.labelMethod.Location = new System.Drawing.Point(51, 130);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(100, 29);
            this.labelMethod.TabIndex = 6;
            this.labelMethod.Text = "Method:";
            // 
            // restAPIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 770);
            this.Controls.Add(this.labelMethod);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.labelResponse);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.txtRestAPI);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "restAPIForm";
            this.Text = "Clien RestAPI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRestAPI;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.Label labelResponse;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.Label labelMethod;
    }
}

