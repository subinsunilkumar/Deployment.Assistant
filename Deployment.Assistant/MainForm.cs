using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Threading;
using Renci.SshNet;

namespace Deployment.Assistant
{
    public partial class MainForm : Form
    {
        IWebDriver driver = null;
        string deploymentLogger = Path.Combine(Environment.CurrentDirectory, "Build-Deploy.log");
        string[] csprojFileList;
        DirectoryInfo parentDir;
        string fileName;
        bool dockerIsRunning = false;
        string outputPath = Path.Combine(Environment.CurrentDirectory, "ASP-Output");
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            deployLabel.Text = string.Empty;
            clipboard.Text = string.Empty;
            WindowState = FormWindowState.Maximized;
            var urlList = new List<string>()
            {
                "inblrghma3879ln","inblrghvsan10ln","inblrghman079ln.rd001.onehc.net"
            };
            var deploymentlist = new List<string>()
            {
                "chest-pain-fe","cadbackendservice","launchpage","launchpageservice","loginpage","licenseservice", "unitconversionservice","tika","snomedqueryservice","settingsui","ruleengineservice",
                "reverse-proxy","reportcreationservice","reportconverter","report-type-converter","rabbitmq","postgres","patientdeleteservice","pacs-connector","nlpfhirrenderer","import-orchestrator",
                "nlpaccessservice","logger","imageaccessservice","filesystem-export-device","fhir-import","fhir-export-device","fhir-document-parser-device","fhir","export-orchestrator","error-reporting-device",
                "doc-import","dicommetadata","csvreaderservice","configurationservice","cadriskcalculatorservice","cadconcordanceservice","cad-fe","authservice","auditlogservice","amp-manager"
            };
            deploymentlist.ForEach(deployment =>
            {
                deploymentList.Items.Add(deployment);
            });
            urlList.ForEach(url =>
            {
                machineListcomboBox.Items.Add(url);
            });
            machineListcomboBox.SelectedIndex = 0;
            imageName.Text = "-";
            KillProcessByName("chromedriver");
            if (File.Exists(deploymentLogger))
            {
                File.Delete(deploymentLogger);
            }
        }

        private void KillProcessByName(string name)
        {
            var processList = Process.GetProcessesByName(name);
            try
            {
                foreach (var process in processList)
                {
                    process.Kill();
                }
            }
            catch(Exception ex)
            {
                WriteLogs($"Exception while killing the process {name}\n\n {ex.Message}");
            }
        }

        private async void Login(string machineName)
        {
            KillProcessByName("chromedriver");
            await Task.Factory.StartNew(() =>
            {
                Invoke(new Action(() =>
                {
                    try
                    {
                        var DeviceDriver = ChromeDriverService.CreateDefaultService();
                        DeviceDriver.HideCommandPromptWindow = true;
                        WriteLogs("Opening Chrome..");
                        ChromeOptions options = new ChromeOptions();
                        options.AddExcludedArgument("enable-automation");
                        options.AddAdditionalCapability("useAutomationExtension", false);
                        driver = new ChromeDriver(DeviceDriver, options);
                        driver.Manage().Window.Maximize();
                        WriteLogs($"Navigating to https://{machineName}/");
                        driver.Navigate().GoToUrl($"https://{machineName}/");
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                        var shInputText = driver.FindElements(By.TagName("sh-input-text"));
                        IWebElement userName = shInputText[0];
                        WriteLogs("Username clinical.admin Entered");
                        userName.SendKeys("clinical.admin");
                        IWebElement password = shInputText[1];
                        WriteLogs("Password ******* Entered");
                        password.SendKeys("Siemens123$Siemens123$");
                        IWebElement loginButton = driver.FindElement(By.TagName("sh-button"));
                        loginButton.Click();
                        WriteLogs($"Login Success to https://{machineName}/ as clinical.admin");
                    }
                    catch(Exception ex)
                    {
                        var message = $"Exception Encountered: \n\n{ex.Message}\n\n If exception includes Chrome driver Update Required, Follow the following steps to update. \n\n 1.Visit https://chromedriver.chromium.org/downloads \n\n 2.Download latest chromedriver(chromedriver_win32.zip if prompted)\n\n 3. Extract the zip file and replace chromedriver.exe in the installation folder with the latest one.";
                        WriteLogs(message);
                        MessageBox.Show(message);
                    }
                }));
            });
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            clipboard.Text = string.Empty;
            deployLabel.Text = string.Empty;
            deploymentList.SelectedIndex = -1;
            var dialog = new OpenFileDialog();
            dialog.Filter = ".sln Files, package.json|*.sln;package.json";
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                fileName = dialog.FileName;
                parentDir = Directory.GetParent(fileName);
                var searchOption = fileName.Contains("sln") ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                var fileList = Directory.GetFiles(parentDir.FullName, "Dockerfile", searchOption);
                var dockerFileCount = fileList.Length;
                if (dockerFileCount == 1)
                {
                    imageName.Text = $"gokarna.azurecr.io/{deploymentList.SelectedItem}-{Environment.UserName}:latest";
                    if(fileName.Contains("package.json") )
                    {
                        var nginx = Path.Combine(parentDir.FullName, "nginx.conf");
                        if (File.Exists(nginx))
                        {
                            dotNetProjectList.Enabled = false;
                            dotNetProjectList.Items.Clear();
                            dockerPath.Text = fileList[0];
                            nginxPath.Text = nginx;
                            deploymentList.Enabled = true;
                            deployButton.Enabled = true;
                            customNameBox.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show($"The folder {parentDir.FullName} does not contain any nginx.conf files.\n\nPlease browse the file again.");
                        }
                    }

                    
                    if (fileName.Contains(".sln"))
                    {
                        csprojFileList = Directory.GetFiles(parentDir.FullName, "*.csproj", SearchOption.AllDirectories);
                        if (csprojFileList.Length > 0)
                        {
                            dotNetProjectList.Enabled = true;
                            csprojFileList.ToList().ForEach(file=>
                            {
                                dotNetProjectList.Items.Add(Path.GetFileName(file).Replace(".csproj",string.Empty));
                            });
                            dotNetProjectList.SelectedIndex = 0;
                            dockerPath.Text = fileList[0];
                            nginxPath.Text = "-";
                            deploymentList.Enabled = true;
                            deployButton.Enabled = true;
                            customNameBox.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show($"The folder {parentDir.FullName} does not contain any *.csproj files.\n\nPlease browse the file again.");
                        }
                    }
                    
                }
                else if(dockerFileCount > 1)
                {
                    var dockerPaths = "\n\n";
                    fileList.ToList().ForEach(file =>
                    {
                        dockerPaths = $"{dockerPaths}{file}\n\n";
                    });
                    MessageBox.Show($"{dockerFileCount} docker files found in the project directory at {dockerPaths}Please browse the file again.");
                }
                else
                {
                    MessageBox.Show($"The folder {parentDir.FullName} does not contain any docker files.\n\nPlease browse the file again.");
                }
            }
        }

        private void DockerBuildAndPush(string path)
        {
            var gokarnaLabel = imageName.Text;
            var dockerLabel = gokarnaLabel.Replace("gokarna.azurecr.io/", string.Empty);
            var command = $"/c cd /d {path} & docker build . -t {dockerLabel} >> \"{deploymentLogger}\" 2>&1";
            WriteLogs($"Building Docker Image");
            WriteLogs($"Command Run {command}");
            var cmdProcess = CreateCmdProcess(command);
            cmdProcess.Start();
            cmdProcess.WaitForExit();
            if(cmdProcess.ExitCode == 0)
            {
                dockerIsRunning = true;
                WriteLogs($"Docker Build Successful for {dockerLabel}");
                command = $"/c cd /d {path} & docker tag {dockerLabel} {gokarnaLabel} >> \"{deploymentLogger}\" 2>&1";
                WriteLogs($"Tagging Docker Image");
                WriteLogs($"Command Run {command}");
                cmdProcess = CreateCmdProcess(command);
                cmdProcess.Start();
                cmdProcess.WaitForExit();
                WriteLogs($"Docker Tag Successful to {gokarnaLabel}");
                command = $"/c cd /d {path} & docker push {gokarnaLabel} >> \"{deploymentLogger}\" 2>&1";
                WriteLogs($"Pushing Docker Image");
                WriteLogs($"Command Run {command}");
                cmdProcess = CreateCmdProcess(command);
                cmdProcess.Start();
                cmdProcess.WaitForExit();
                WriteLogs($"Docker Push Successful to {gokarnaLabel}");
            }
            else
            {
                dockerIsRunning = false;
                WriteLogs($"Docker Build Failed for {dockerLabel}");
                WriteLogs("Docker is not running on your machine!\n\nStart Docker and restart the process again");
                MessageBox.Show("Docker is not running on your machine!\n\nStart Docker and restart the process again");
            }
        }

        private async void BuildAspProject()
        {
            var csprojPath = string.Empty;
            csprojFileList.ToList().ForEach(file =>
            {
                if (file.Contains(dotNetProjectList.SelectedItem.ToString() + ".csproj"))
                {
                    csprojPath = file;
                }
            });
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            var dockerFile = dockerPath.Text;
            WriteLogs($"Build started for project {dotNetProjectList.SelectedItem}");
            await Task.Factory.StartNew(() =>
            {
                var buildCommand = $"/c dotnet publish \"{csprojPath}\" -o \"{outputPath}\"  >> \"{deploymentLogger}\" 2>&1";
                WriteLogs($"Command run {buildCommand}");
                var cmdProcess = CreateCmdProcess(buildCommand);
                cmdProcess.Start();
                cmdProcess.WaitForExit();
                WriteLogs("Build Success!");
                var fileContent = File.ReadAllLines(dockerFile);
                var index = 0;
                fileContent.ToList().ForEach(content =>
                {
                    if (content.Contains("COPY"))
                    {
                        WriteLogs($"Replacing {content} with COPY . .");
                        fileContent[index] = "COPY . .";
                    }
                    index++;
                });
                var newPath = Path.Combine(outputPath, "Dockerfile");
                WriteLogs($"Copying {dockerFile} to {newPath}");
                File.WriteAllLines(newPath, fileContent);
                DockerBuildAndPush(outputPath);
            });
            if(dockerIsRunning)
            {
                Connect(machineListcomboBox.SelectedItem.ToString(), deploymentList.SelectedItem.ToString(), imageName.Text);
            }
        }

        private async void BuildAngularProject()
        {
            await Task.Factory.StartNew(() =>
            {
                WriteLogs($"Build started");
                var buildCommand = $"/c cd /d \"{parentDir.FullName}\"& ng build --prod  >> \"{deploymentLogger}\" 2>&1";
                WriteLogs($"Command run {buildCommand}");
                var cmdProcess = CreateCmdProcess(buildCommand);
                cmdProcess.Start();
                cmdProcess.WaitForExit();
                WriteLogs("Build Success!");
                foreach (var file in new[] { nginxPath.Text, dockerPath.Text })
                {
                    var newPath = file.Replace("nginx.conf", "dist\\nginx.conf").Replace("Dockerfile", "dist\\Dockerfile");
                    WriteLogs($"Copying {file} to {newPath}");
                    File.Copy(file, newPath, true);
                    WriteLogs($"Successfully copied {file} to {newPath}");
                }
                DockerBuildAndPush(Path.Combine(parentDir.FullName,"dist"));
            });
            if (dockerIsRunning)
            {
                Connect(machineListcomboBox.SelectedItem.ToString(), deploymentList.SelectedItem.ToString(), imageName.Text);
            }
        }

        private Process CreateCmdProcess(string buildCommand)
        {
            var cmdProcess = new Process();
            var startInfo = new ProcessStartInfo()
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = buildCommand
            };
            cmdProcess.StartInfo = startInfo;
            return cmdProcess;
        }

        private async void Connect(string machineName, string deploymentName, string imageName)
        {
            await Task.Factory.StartNew(() =>
            {
                var client = new SshClient(machineName, "aipcroot", "AIPC_DevOps21@ids.com");
                try
                {
                    WriteLogs($"Connecting to {machineName}");
                    client.Connect();
                    WriteLogs($"Successfully connected to {machineName}");
                    var sudoString = "echo \"" + "AIPC_DevOps21@ids.com" + "\" | sudo -S ";
                    WriteLogs("Command Run : kubectl get pods -n ai-pc-product");
                    var result = client.RunCommand(sudoString + "kubectl get pods -n ai-pc-product");
                    WriteLogs(result.Result);
                    var tmpFile = Path.Combine(Environment.CurrentDirectory, "Temp.txt");
                    File.WriteAllText(tmpFile, result.Result);
                    var podList = File.ReadAllLines(tmpFile).ToList();
                    var readyPosition = podList[0].IndexOf("READY");
                    var currentPodName = string.Empty;                    
                    podList.ForEach(pod =>
                    {
                        pod = pod.Remove(readyPosition).Trim();
                        if (pod.Contains(deploymentName+"-"))
                        {
                            currentPodName = pod;
                        }
                    });
                    WriteLogs($"Command Run : kubectl set image deployment/{deploymentName} {deploymentName}={imageName} -n ai-pc-product");
                    result = client.RunCommand(sudoString + $"kubectl set image deployment/{deploymentName} {deploymentName}={imageName} -n ai-pc-product");
                    WriteLogs(result.Result);
                    WriteLogs($"Command Run : kubectl delete pod {currentPodName} -n ai-pc-product");
                    result = client.RunCommand(sudoString + $"kubectl delete pod {currentPodName} -n ai-pc-product");
                    WriteLogs(result.Result);
                    result = client.RunCommand(sudoString + $"kubectl get pods -n ai-pc-product");
                    WriteLogs(result.Result);
                    WriteLogs("Deployment Successful!");
                }
                finally
                {
                    Invoke(new Action(() =>
                    {
                        deployLabel.Text = "Deployment Successful";
                        deployButton.Enabled = true;
                        deployButton.Enabled = true;
                        dotNetProjectList.Enabled = true;
                        deploymentList.Enabled = true;
                        machineListcomboBox.Enabled = true;
                        browseButton.Enabled = true;
                    }));
                    client.Disconnect();
                }
            });

        }

        private async void imageName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(imageName.Text);
            clipboard.Text = "Copied to clipboard";
        }

        private void deploymentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            clipboard.Text = string.Empty;
            var deploymentName = deploymentList.SelectedItem;
            var userName = $"-{Environment.UserName}";
            if (customNameBox.Text.Replace(" ", string.Empty).Length > 0)
            {
                deploymentName = customNameBox.Text.Replace(" ", string.Empty);
                userName = string.Empty;
            }
            imageName.Text = $"gokarna.azurecr.io/{deploymentName}{userName}:latest";
        }

        private void deployButton_Click(object sender, EventArgs e)
        {
            deployLabel.Text = string.Empty;
            if (deploymentList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the Image name before you proceed!");
            }
            else
            {
                deployButton.Enabled = false;
                dotNetProjectList.Enabled = false;
                deploymentList.Enabled = false;
                machineListcomboBox.Enabled = false;
                browseButton.Enabled = false;
                if (fileName.Contains(".sln"))
                {
                    BuildAspProject();
                }
                else
                {
                    BuildAngularProject();
                }
            }
        }


        private void WriteLogs(string text)
        {
            try
            {
                if (text != string.Empty)
                {
                    if (!File.Exists(deploymentLogger))
                    {
                        var file = File.Create(deploymentLogger);
                        file.Close();
                    }
                    using (var writer = File.AppendText(deploymentLogger))
                    {
                        writer.WriteLine($"\n{DateTime.Now} -----------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                        writer.WriteLine(text);
                    }
                    Invoke(new Action(() =>
                    {
                        if (File.Exists(deploymentLogger))
                        {
                            deployLogger.Text = File.ReadAllText(deploymentLogger);
                            deployLogger.SelectionStart = deployLogger.Text.Length;
                        }
                    }));
                }
            }
            finally
            {
                Invoke(new Action(() =>
                {
                    if (File.Exists(deploymentLogger))
                    {
                        deployLogger.ScrollToCaret();
                    }
                }));
            }
        }


        private void customNameBox_TextChanged(object sender, EventArgs e)
        {
            clipboard.Text = string.Empty;
            var deploymentName = deploymentList.SelectedItem;
            var userName = $"-{Environment.UserName}";
            if (customNameBox.Text.Replace(" ", string.Empty).Length > 0)
            {
                deploymentName = customNameBox.Text.Replace(" ", string.Empty);
                userName = string.Empty;
            }
            imageName.Text = $"gokarna.azurecr.io/{deploymentName}{userName}:latest";
        }

        private void loginAfterDeployButton_Click(object sender, EventArgs e)
        {
            Login(machineListcomboBox.SelectedItem.ToString());
        }

        private void refreshLogs_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(deploymentLogger))
                {
                    var copyFile = Path.Combine(Environment.CurrentDirectory, "Build-Deploy-Copy.log");
                    File.Copy(deploymentLogger, copyFile, true);
                    deployLogger.Text = File.ReadAllText(copyFile);
                    deployLogger.SelectionStart = deployLogger.Text.Length;
                }
            }
            finally
            {
                deployLogger.ScrollToCaret();
            }
        }
    }
    }
