﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Net;

namespace PswgLauncher
{
    public partial class LAUNCHOPTIONS : Form
    {
    	
    	private GuiController Controller;
    	Point mouseDownPoint = Point.Empty;
    	
    	private LauncherButton DonateButton;
    	private LauncherButton SupportButton;
    	private LauncherButton TrefixButton;
    	
        public LAUNCHOPTIONS(GuiController gc)
        {
        	this.Controller = gc;
            InitializeComponent();
            InitializeComponent2();
            
            soundControl.Checked = Controller.soundOption;
            checksumControl.Checked = Controller.checksumOption;
            checkBoxLocalhost.Checked = Controller.LocalhostOption;
             
        }
        
        private void InitializeComponent2() {
        	
        	this.Region = System.Drawing.Region.FromHrgn(GuiController.CreateRoundRectRgn( 0, 0, Width, Height, 24, 24));      	
        	this.Icon= Controller.GetAppIcon();
        	this.BackgroundImage = Controller.GetResourceImage("Background_Options");
        	

        	SupportButton = Controller.SpawnStandardButton("Support", new Point(125, 75));
        	SupportButton.Click += Support_Click;
        	this.Controls.Add(SupportButton);

        	TrefixButton = Controller.SpawnStandardButton("Run Trefix.exe", new Point(300, 75));
        	TrefixButton.Click += button2_Click;
        	this.Controls.Add(TrefixButton);	
        	
        	DonateButton = Controller.SpawnStandardButton("Donate", new Point(125, 180));
        	DonateButton.Click += Donate_Click;
        	this.Controls.Add(DonateButton);
        	
        	
        	this.button1.Image = Controller.GetResourceImage("WButton_minimize");
        	this.close.Image = Controller.GetResourceImage("WButton_close");     	
        	this.close.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        	this.button1.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        	
        	
        }
        

        private void LAUNCHOPTIONS_Load(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void LAUNCHOPTIONS_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void LAUNCHOPTIONS_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void LAUNCHOPTIONS_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void LAUNCHOPTIONS_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mouseDownPoint.X), f.Location.Y + (e.Y - mouseDownPoint.Y));
        }

        private void Donate_Click(object sender, EventArgs e)
        {
        	Controller.PlaySound("Sound_Click");
            Donate donate = new Donate(Controller);
            donate.Show();
        }

        private void Support_Click(object sender, EventArgs e)
        {
        	Controller.PlaySound("Sound_Click");
            SupportWindow support = new SupportWindow(Controller);
            support.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/TREFix.exe"))
            {
            	Controller.PlaySound("Sound_Click");
                System.Diagnostics.Process.Start(Application.StartupPath + "/TREFix.exe");
            }

            else
            {
            	
            	Controller.PlaySound("Sound_Error");

            }

        }
   

        void ChecksumControlCheckedChanged(object sender, EventArgs e)
        {
        	
        	Controller.checksumOption = checksumControl.Checked;
        	
        }
        

        
        void SoundControlCheckedChanged(object sender, EventArgs e)
        {
        	
        	Controller.soundOption = soundControl.Checked;
        	
        }
        
        void LinkDebugWindowLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        	Controller.LaunchDebug();
        }
        

        
        void CheckBoxLocalhostCheckedChanged(object sender, EventArgs e)
        {
        	Controller.LocalhostOption = checkBoxLocalhost.Checked;
        }
    }
}
