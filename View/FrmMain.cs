using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using teste_aula_13.Controller;
using teste_aula_13.Model;

namespace teste_aula_13
{
    public partial class FrmMain : Form
    {
        private EmpregadoController EmpregadoController { get; set; }

        public FrmMain(EmpregadoController controller)
        {
            EmpregadoController = controller;
            InitializeComponent();
        }

        private Empregado Criar()
        {
            Empregado empregado = new Empregado
            {
                Matricula = Int32.Parse(txtMatricula.Text),
                Nome = txtNome.Text,
                Endereco = txtEndereco.Text,
                Salario = float.Parse(txtSalario.Text),
                Coddep = Int32.Parse(txtDepartamento.Text),
                Cargo = txtCargo.Text
            };
            return empregado;
        }

        private void Salvar()
        {
            Empregado empregado = Criar();
            if (EmpregadoController.Salvar(empregado))
            {
                MessageBox.Show("Empregado Salvo Com Sucesso", "Sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao salvar empregado", "Erro");
            }
        }

        private void Recuperar()
        {
            String txtEmpregados = "Empregados\n";
            List<Empregado> empregados = EmpregadoController.Recuperar();

            foreach (Empregado empregado in empregados)
            {
                txtEmpregados += empregado.ToString() + "\n";
            }

            MessageBox.Show(txtEmpregados, "Resultado");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Recuperar();
        }
    }
}
