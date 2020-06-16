using System;
using System.Drawing;
using System.Windows.Forms;

namespace Library
{
    public class Button : System.Windows.Forms.Button
    {

        public Button()
        {
            this.Size = new Size(150, 50);
            this.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.ForeColor = Color.Black;
            this.MouseEnter += new EventHandler(this.btn_MouseEnter);
            this.MouseLeave += new EventHandler(this.btn_MouseLeave);
        }

        // Mouse event to change color of button
        private void btn_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#de9d35");
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#dfb841");
        }
    }
}