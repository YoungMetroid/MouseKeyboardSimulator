using System.Drawing;
using System.Windows.Forms;

namespace MouseKeyBoardSimulation
{
    partial class Form1
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
            
            TextBox textBox1 = new TextBox();
            textBox1.Location = new Point(20, 20);
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(400, 200);
            textBox1.Text = "Enter text here";

            this.Controls.Add(Components.CreateInput(
                "Enter Text Here", new Point(20,20), new Size(400,200)
                ));
            this.Controls.Add(Components.CreateInput(
                "Simulated Key Presses will appear here", new Point(20, 220), new Size(400, 200)
                ));
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";  
        }

        #endregion
    }
}

