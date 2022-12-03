
namespace Deployment.Assistant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.deploymentTabPage = new System.Windows.Forms.TabPage();
            this.refreshLogs = new System.Windows.Forms.Button();
            this.nginxPath = new System.Windows.Forms.Label();
            this.nginxLabel = new System.Windows.Forms.Label();
            this.dockerPath = new System.Windows.Forms.Label();
            this.dockerLabel = new System.Windows.Forms.Label();
            this.dotNetProjectLabel = new System.Windows.Forms.Label();
            this.dotNetProjectList = new System.Windows.Forms.ComboBox();
            this.loginAfterDeployButton = new System.Windows.Forms.Button();
            this.customNameBox = new System.Windows.Forms.TextBox();
            this.customName = new System.Windows.Forms.Label();
            this.buildLogLabel = new System.Windows.Forms.Label();
            this.deployLogger = new System.Windows.Forms.RichTextBox();
            this.imageNameLabel = new System.Windows.Forms.Label();
            this.deploymentList = new System.Windows.Forms.ComboBox();
            this.copyStatus = new System.Windows.Forms.Label();
            this.imageName = new System.Windows.Forms.Label();
            this.gookarnaName = new System.Windows.Forms.Label();
            this.deployButton = new System.Windows.Forms.Button();
            this.machineListLabel = new System.Windows.Forms.Label();
            this.browseDockerLabel = new System.Windows.Forms.Label();
            this.machineListcomboBox = new System.Windows.Forms.ComboBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.assistantTabControl = new System.Windows.Forms.TabControl();
            this.deploymentTabPage.SuspendLayout();
            this.assistantTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // deploymentTabPage
            // 
            this.deploymentTabPage.Controls.Add(this.refreshLogs);
            this.deploymentTabPage.Controls.Add(this.nginxPath);
            this.deploymentTabPage.Controls.Add(this.nginxLabel);
            this.deploymentTabPage.Controls.Add(this.dockerPath);
            this.deploymentTabPage.Controls.Add(this.dockerLabel);
            this.deploymentTabPage.Controls.Add(this.dotNetProjectLabel);
            this.deploymentTabPage.Controls.Add(this.dotNetProjectList);
            this.deploymentTabPage.Controls.Add(this.loginAfterDeployButton);
            this.deploymentTabPage.Controls.Add(this.customNameBox);
            this.deploymentTabPage.Controls.Add(this.customName);
            this.deploymentTabPage.Controls.Add(this.buildLogLabel);
            this.deploymentTabPage.Controls.Add(this.deployLogger);
            this.deploymentTabPage.Controls.Add(this.imageNameLabel);
            this.deploymentTabPage.Controls.Add(this.deploymentList);
            this.deploymentTabPage.Controls.Add(this.copyStatus);
            this.deploymentTabPage.Controls.Add(this.imageName);
            this.deploymentTabPage.Controls.Add(this.gookarnaName);
            this.deploymentTabPage.Controls.Add(this.deployButton);
            this.deploymentTabPage.Controls.Add(this.machineListLabel);
            this.deploymentTabPage.Controls.Add(this.browseDockerLabel);
            this.deploymentTabPage.Controls.Add(this.machineListcomboBox);
            this.deploymentTabPage.Controls.Add(this.browseButton);
            this.deploymentTabPage.Location = new System.Drawing.Point(4, 22);
            this.deploymentTabPage.Name = "deploymentTabPage";
            this.deploymentTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.deploymentTabPage.Size = new System.Drawing.Size(890, 745);
            this.deploymentTabPage.TabIndex = 0;
            this.deploymentTabPage.Text = "Deploy Project";
            this.deploymentTabPage.UseVisualStyleBackColor = true;
            // 
            // refreshLogs
            // 
            this.refreshLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshLogs.Location = new System.Drawing.Point(793, 383);
            this.refreshLogs.Name = "refreshLogs";
            this.refreshLogs.Size = new System.Drawing.Size(75, 23);
            this.refreshLogs.TabIndex = 20;
            this.refreshLogs.Text = "Refresh";
            this.refreshLogs.UseVisualStyleBackColor = true;
            this.refreshLogs.Click += new System.EventHandler(this.refreshLogs_Click);
            // 
            // nginxPath
            // 
            this.nginxPath.AutoSize = true;
            this.nginxPath.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.nginxPath.Location = new System.Drawing.Point(145, 293);
            this.nginxPath.Name = "nginxPath";
            this.nginxPath.Size = new System.Drawing.Size(12, 15);
            this.nginxPath.TabIndex = 19;
            this.nginxPath.Text = "-";
            // 
            // nginxLabel
            // 
            this.nginxLabel.AutoSize = true;
            this.nginxLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nginxLabel.Location = new System.Drawing.Point(28, 294);
            this.nginxLabel.Name = "nginxLabel";
            this.nginxLabel.Size = new System.Drawing.Size(89, 26);
            this.nginxLabel.TabIndex = 18;
            this.nginxLabel.Text = "Nginx Path\r\n(Auto-Detected)";
            // 
            // dockerPath
            // 
            this.dockerPath.AutoSize = true;
            this.dockerPath.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.dockerPath.Location = new System.Drawing.Point(145, 239);
            this.dockerPath.Name = "dockerPath";
            this.dockerPath.Size = new System.Drawing.Size(12, 15);
            this.dockerPath.TabIndex = 17;
            this.dockerPath.Text = "-";
            // 
            // dockerLabel
            // 
            this.dockerLabel.AutoSize = true;
            this.dockerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dockerLabel.Location = new System.Drawing.Point(27, 239);
            this.dockerLabel.Name = "dockerLabel";
            this.dockerLabel.Size = new System.Drawing.Size(89, 26);
            this.dockerLabel.TabIndex = 16;
            this.dockerLabel.Text = "Docker Path\r\n(Auto-Detected)";
            // 
            // dotNetProjectLabel
            // 
            this.dotNetProjectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dotNetProjectLabel.AutoSize = true;
            this.dotNetProjectLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dotNetProjectLabel.Location = new System.Drawing.Point(487, 37);
            this.dotNetProjectLabel.Name = "dotNetProjectLabel";
            this.dotNetProjectLabel.Size = new System.Drawing.Size(81, 39);
            this.dotNetProjectLabel.TabIndex = 15;
            this.dotNetProjectLabel.Text = ".Net project to\r\nPublish\r\n\r\n";
            // 
            // dotNetProjectList
            // 
            this.dotNetProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dotNetProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dotNetProjectList.Enabled = false;
            this.dotNetProjectList.FormattingEnabled = true;
            this.dotNetProjectList.Location = new System.Drawing.Point(580, 36);
            this.dotNetProjectList.Name = "dotNetProjectList";
            this.dotNetProjectList.Size = new System.Drawing.Size(261, 21);
            this.dotNetProjectList.TabIndex = 14;
            // 
            // loginAfterDeployButton
            // 
            this.loginAfterDeployButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginAfterDeployButton.Location = new System.Drawing.Point(724, 323);
            this.loginAfterDeployButton.Name = "loginAfterDeployButton";
            this.loginAfterDeployButton.Size = new System.Drawing.Size(117, 23);
            this.loginAfterDeployButton.TabIndex = 13;
            this.loginAfterDeployButton.Text = "Auto Login Browser";
            this.loginAfterDeployButton.UseVisualStyleBackColor = true;
            this.loginAfterDeployButton.Click += new System.EventHandler(this.loginAfterDeployButton_Click);
            // 
            // customNameBox
            // 
            this.customNameBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customNameBox.Enabled = false;
            this.customNameBox.Location = new System.Drawing.Point(587, 167);
            this.customNameBox.Name = "customNameBox";
            this.customNameBox.Size = new System.Drawing.Size(261, 22);
            this.customNameBox.TabIndex = 12;
            this.customNameBox.TextChanged += new System.EventHandler(this.customNameBox_TextChanged);
            // 
            // customName
            // 
            this.customName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customName.AutoSize = true;
            this.customName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customName.Location = new System.Drawing.Point(488, 157);
            this.customName.Name = "customName";
            this.customName.Size = new System.Drawing.Size(79, 39);
            this.customName.TabIndex = 11;
            this.customName.Text = "Custom Name\r\nEg: cadappfe\r\n(Optional)";
            // 
            // buildLogLabel
            // 
            this.buildLogLabel.AutoSize = true;
            this.buildLogLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buildLogLabel.Location = new System.Drawing.Point(6, 344);
            this.buildLogLabel.Name = "buildLogLabel";
            this.buildLogLabel.Size = new System.Drawing.Size(31, 13);
            this.buildLogLabel.TabIndex = 10;
            this.buildLogLabel.Text = "Logs";
            // 
            // deployLogger
            // 
            this.deployLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deployLogger.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deployLogger.Location = new System.Drawing.Point(6, 370);
            this.deployLogger.Name = "deployLogger";
            this.deployLogger.Size = new System.Drawing.Size(878, 375);
            this.deployLogger.TabIndex = 1;
            this.deployLogger.Text = "";
            // 
            // imageNameLabel
            // 
            this.imageNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageNameLabel.AutoSize = true;
            this.imageNameLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageNameLabel.Location = new System.Drawing.Point(488, 98);
            this.imageNameLabel.Name = "imageNameLabel";
            this.imageNameLabel.Size = new System.Drawing.Size(72, 13);
            this.imageNameLabel.TabIndex = 9;
            this.imageNameLabel.Text = "Image Name";
            // 
            // deploymentList
            // 
            this.deploymentList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deploymentList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.deploymentList.Enabled = false;
            this.deploymentList.FormattingEnabled = true;
            this.deploymentList.Location = new System.Drawing.Point(580, 94);
            this.deploymentList.Name = "deploymentList";
            this.deploymentList.Size = new System.Drawing.Size(261, 21);
            this.deploymentList.TabIndex = 8;
            this.deploymentList.SelectedIndexChanged += new System.EventHandler(this.deploymentList_SelectedIndexChanged);
            // 
            // copyStatus
            // 
            this.copyStatus.AutoSize = true;
            this.copyStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.copyStatus.Location = new System.Drawing.Point(129, 197);
            this.copyStatus.Name = "copyStatus";
            this.copyStatus.Size = new System.Drawing.Size(0, 15);
            this.copyStatus.TabIndex = 7;
            // 
            // imageName
            // 
            this.imageName.AutoSize = true;
            this.imageName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.imageName.Location = new System.Drawing.Point(145, 169);
            this.imageName.Name = "imageName";
            this.imageName.Size = new System.Drawing.Size(12, 15);
            this.imageName.TabIndex = 6;
            this.imageName.Text = "-";
            this.imageName.Click += new System.EventHandler(this.imageName_Click);
            // 
            // gookarnaName
            // 
            this.gookarnaName.AutoSize = true;
            this.gookarnaName.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gookarnaName.Location = new System.Drawing.Point(27, 147);
            this.gookarnaName.Name = "gookarnaName";
            this.gookarnaName.Size = new System.Drawing.Size(75, 65);
            this.gookarnaName.TabIndex = 5;
            this.gookarnaName.Text = "Your Gokarna\r\nImage Name\r\n(Click On the\r\nName to\r\ncopy)";
            // 
            // deployButton
            // 
            this.deployButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deployButton.Enabled = false;
            this.deployButton.Location = new System.Drawing.Point(580, 323);
            this.deployButton.Name = "deployButton";
            this.deployButton.Size = new System.Drawing.Size(117, 23);
            this.deployButton.TabIndex = 4;
            this.deployButton.Text = "Build and Deploy";
            this.deployButton.UseVisualStyleBackColor = true;
            this.deployButton.Click += new System.EventHandler(this.deployButton_Click);
            // 
            // machineListLabel
            // 
            this.machineListLabel.AutoSize = true;
            this.machineListLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.machineListLabel.Location = new System.Drawing.Point(27, 94);
            this.machineListLabel.Name = "machineListLabel";
            this.machineListLabel.Size = new System.Drawing.Size(115, 13);
            this.machineListLabel.TabIndex = 3;
            this.machineListLabel.Text = "Deployment Machine";
            // 
            // browseDockerLabel
            // 
            this.browseDockerLabel.AutoSize = true;
            this.browseDockerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseDockerLabel.Location = new System.Drawing.Point(27, 32);
            this.browseDockerLabel.Name = "browseDockerLabel";
            this.browseDockerLabel.Size = new System.Drawing.Size(87, 26);
            this.browseDockerLabel.TabIndex = 2;
            this.browseDockerLabel.Text = "Open .sln file or\r\npackage.json";
            // 
            // machineListcomboBox
            // 
            this.machineListcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.machineListcomboBox.FormattingEnabled = true;
            this.machineListcomboBox.Location = new System.Drawing.Point(148, 89);
            this.machineListcomboBox.Name = "machineListcomboBox";
            this.machineListcomboBox.Size = new System.Drawing.Size(261, 21);
            this.machineListcomboBox.TabIndex = 1;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(148, 34);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // assistantTabControl
            // 
            this.assistantTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.assistantTabControl.Controls.Add(this.deploymentTabPage);
            this.assistantTabControl.Location = new System.Drawing.Point(0, 0);
            this.assistantTabControl.Name = "assistantTabControl";
            this.assistantTabControl.SelectedIndex = 0;
            this.assistantTabControl.Size = new System.Drawing.Size(898, 771);
            this.assistantTabControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 770);
            this.Controls.Add(this.assistantTabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Deployment Assistant";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.deploymentTabPage.ResumeLayout(false);
            this.deploymentTabPage.PerformLayout();
            this.assistantTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage deploymentTabPage;
        private System.Windows.Forms.ComboBox machineListcomboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TabControl assistantTabControl;
        private System.Windows.Forms.Label browseDockerLabel;
        private System.Windows.Forms.Label imageName;
        private System.Windows.Forms.Label gookarnaName;
        private System.Windows.Forms.Button deployButton;
        private System.Windows.Forms.Label copyStatus;
        private System.Windows.Forms.Label imageNameLabel;
        private System.Windows.Forms.ComboBox deploymentList;
        private System.Windows.Forms.RichTextBox deployLogger;
        private System.Windows.Forms.Label buildLogLabel;
        private System.Windows.Forms.TextBox customNameBox;
        private System.Windows.Forms.Label customName;
        private System.Windows.Forms.Label machineListLabel;
        private System.Windows.Forms.Button loginAfterDeployButton;
        private System.Windows.Forms.Label dotNetProjectLabel;
        private System.Windows.Forms.ComboBox dotNetProjectList;
        private System.Windows.Forms.Label nginxPath;
        private System.Windows.Forms.Label nginxLabel;
        private System.Windows.Forms.Label dockerPath;
        private System.Windows.Forms.Label dockerLabel;
        private System.Windows.Forms.Button refreshLogs;
    }
}

