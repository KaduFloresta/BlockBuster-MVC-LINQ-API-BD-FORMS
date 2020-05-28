using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using static Locadora_MVC_LINQ_API_BD_IF.Program;

namespace Locadora_MVC_LINQ_API_BD_Interface
{
    public class CadastroCliente : Form
    {
        PictureBox pb_Cadastro;
        // Orientation Labels
        Label lbl_Nome;
        Label lbl_DataNasc;
        Label lbl_CPF;
        Label lbl_DiasDevol;
        RichTextBox rtxt_NomeCliente;
        // Data entry numeric system selection up/down
        NumericUpDown num_DataNascDia;
        NumericUpDown num_DataNascMes;
        NumericUpDown num_DataNascAno;
        MaskedTextBox mtxt_CpfCLiente;
        ComboBox cb_DiasDevol;
        Button btn_Confirmar;
        Button btn_Cancelar;
        Form parent;

        // Customer data entry
        public CadastroCliente(Form parent)
        {
            this.BackColor = ColorTranslator.FromHtml("#6d6a75");
            this.Font = new Font(this.Font, FontStyle.Bold);
            this.Size = new Size(500, 400);
            this.parent = parent;

            // PictureBox
            pb_Cadastro = new PictureBox();
            pb_Cadastro.Location = new Point(10, 10);
            pb_Cadastro.Size = new Size(480, 100);
            pb_Cadastro.ClientSize = new Size(460, 60);
            pb_Cadastro.BackColor = Color.Black;
            pb_Cadastro.Load("./Views/assets/cadastra.jpg");
            pb_Cadastro.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pb_Cadastro);

            // Label
            lbl_Nome = new Label();
            lbl_Nome.Text = "Nome :";
            lbl_Nome.Location = new Point(20, 100);
            lbl_Nome.AutoSize = true;
            this.Controls.Add(lbl_Nome);

            lbl_DataNasc = new Label();
            lbl_DataNasc.Text = "Data de Nascimento :";
            lbl_DataNasc.AutoSize = true;
            lbl_DataNasc.Location = new Point(20, 140);
            this.Controls.Add(lbl_DataNasc);

            lbl_CPF = new Label();
            lbl_CPF.Text = "CPF :";
            lbl_CPF.Location = new Point(20, 180);
            this.Controls.Add(lbl_CPF);

            lbl_DiasDevol = new Label();
            lbl_DiasDevol.Text = "Dias P/ Devolução :";
            lbl_DiasDevol.AutoSize = true;
            lbl_DiasDevol.Location = new Point(20, 220);
            this.Controls.Add(lbl_DiasDevol);

            // RichTextBox (Edited text)
            rtxt_NomeCliente = new RichTextBox();
            rtxt_NomeCliente.SelectionFont = new Font("Tahoma", 10, FontStyle.Bold);
            rtxt_NomeCliente.SelectionColor = System.Drawing.Color.Black;
            rtxt_NomeCliente.Location = new Point(150, 100);
            rtxt_NomeCliente.Size = new Size(300, 20);
            this.Controls.Add(rtxt_NomeCliente);

            // NumericUpDown
            num_DataNascDia = new NumericUpDown();
            num_DataNascDia.Location = new Point(150, 140);
            num_DataNascDia.Size = new Size(50, 20);
            num_DataNascDia.Minimum = 01;
            num_DataNascDia.Maximum = 31;
            this.Controls.Add(num_DataNascDia);

            num_DataNascMes = new NumericUpDown();
            num_DataNascMes.Location = new Point(210, 140);
            num_DataNascMes.Size = new Size(50, 20);
            num_DataNascMes.Minimum = 01;
            num_DataNascMes.Maximum = 12;
            this.Controls.Add(num_DataNascMes);

            num_DataNascAno = new NumericUpDown();
            num_DataNascAno.Location = new Point(270, 140);
            num_DataNascAno.Size = new Size(50, 20);
            num_DataNascAno.Minimum = 1930;
            num_DataNascAno.Maximum = 2020;
            this.Controls.Add(num_DataNascAno);

            // MaskedTextBox
            mtxt_CpfCLiente = new MaskedTextBox();
            mtxt_CpfCLiente.Location = new Point(150, 180);
            mtxt_CpfCLiente.Size = new Size(170, 20);
            mtxt_CpfCLiente.Mask = "000,000,000-00";
            this.Controls.Add(mtxt_CpfCLiente);

            // ComboBox
            cb_DiasDevol = new ComboBox();
            cb_DiasDevol.Items.Add("2 Dias");
            cb_DiasDevol.Items.Add("3 Dias");
            cb_DiasDevol.Items.Add("4 Dias");
            cb_DiasDevol.Items.Add("5 Dias");
            cb_DiasDevol.Items.Add("PLUS - 10 Dias");
            cb_DiasDevol.AutoCompleteMode = AutoCompleteMode.Append;
            cb_DiasDevol.Location = new Point(150, 220);
            cb_DiasDevol.Size = new Size(170, 20);
            this.Controls.Add(cb_DiasDevol);

            // Buttons
            btn_Confirmar = new Button();
            btn_Confirmar.Text = "CONFIRMAR";
            btn_Confirmar.Location = new Point(80, 280);
            btn_Confirmar.Size = new Size(150, 40);
            this.btn_Confirmar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Confirmar.ForeColor = Color.Black;
            btn_Confirmar.Click += new EventHandler(this.btn_ConfirmarClick);
            this.Controls.Add(btn_Confirmar);

            btn_Cancelar = new Button();
            btn_Cancelar.Text = "CANCELAR";
            btn_Cancelar.Location = new Point(260, 280);
            btn_Cancelar.Size = new Size(150, 40);
            this.btn_Cancelar.BackColor = ColorTranslator.FromHtml("#dfb841");
            this.btn_Cancelar.ForeColor = Color.Black;
            btn_Cancelar.Click += new EventHandler(this.btn_CancelarClick);
            this.Controls.Add(btn_Cancelar);
        }

        /// <summary>
        /// Event data button to enter information into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>//
        private void btn_ConfirmarClick(object sender, EventArgs e)
        {
            try
            {
                if (rtxt_NomeCliente.Text != string.Empty)
                {
                    ClienteController.CadastrarCliente(
                    rtxt_NomeCliente.Text,
                    (int)num_DataNascDia.Value,
                    (int)num_DataNascMes.Value,
                    (int)num_DataNascAno.Value,
                    mtxt_CpfCLiente.Text,

                    cb_DiasDevol.Text == "2 Dias"
                        ? 2
                        : cb_DiasDevol.Text == "3 Dias"
                            ? 3
                            : cb_DiasDevol.Text == "4 Dias"
                                ? 4
                                : cb_DiasDevol.Text == "5 Dias"
                                    ? 5
                                    : 10
                    );

                    MessageBox.Show("CADASTRADO!");
                    this.Close();
                    this.parent.Show();
                }
                else
                {
                    MessageBox.Show("PREENCHA OS CAMPOS!");
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "PREENCHA OS CAMPOS!");
            }
        }

        /// <summary>
        /// Event button to cancel and back to main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CancelarClick(object sender, EventArgs e)
        {
            MessageBox.Show("CANCELADO!");
            this.Close();
            this.parent.Show();
        }
    }
}