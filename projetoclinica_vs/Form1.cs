using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoSistemaClínica
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();


        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {

        }

        private void lblDataConsulta_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizarGridCadastro();
            atualizarGridConsulta();
        }

        private void checkboxOutro_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblTitle2_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle1_Click(object sender, EventArgs e)
        {

        }

        private void clickCadastro(object sender, EventArgs e)
        {
            tabControl1.SelectTab("cadastro");
            lblTitle1.Text = "Cadastro de Pacientes";
        }

        private void clickConsulta(object sender, EventArgs e)
        {
            tabControl1.SelectTab("consultas");
            lblTitle1.Text = "Marcar e cancelar consultas";

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void irConsulta_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("consultas");
        }

        private void irCadastro_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab("cadastro");
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //Cria a estrutura da conexão com o banco de dados (cadastro) e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";

            //Realiza a conexão com o banco de dados (cadastro)
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                //Abre a conexão com o banco de dados
                realizaConexacoBD.Open();

                //Cria um comando SQL
                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO cadastro (nomeCompleto,dataNascimento,sexo,rgPaciente,endereco,contato,planoSaude) " +
                    "VALUES('" + txtbNomeCompleto.Text + "', '" + txtbNascimento.Text + "', '" + cmbbSexo.Text + "', '" + txtbRG.Text + "', '" + txtbEndereco.Text + "', '" + txtbContato.Text + "', '" + cmbbPlanoSaude.Text + "')";
                comandoMySql.ExecuteNonQuery();

                //Fecha a conexão com o banco de dados
                realizaConexacoBD.Close();

                //Exibe a mensagem informado que o Paciente foi cadastrado com sucesso
                MessageBox.Show("Paciente Cadastrado com sucesso!");
                atualizarGridCadastro();
                limparCamposCadastro();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void atualizarGridCadastro()
        {
            //Cria a estrutura da conexão com o banco de dados e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";

            //Realiza a conexão com o banco de dados
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                //Traz todos os itens da tabela cadastro
                comandoMySql.CommandText = "SELECT * from cadastro WHERE ativoPaciente = 0";
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                //Limpa o dataGridView da tela de Cadastro
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[0].Clone();
                    //ID Cadastro
                    row.Cells[0].Value = reader.GetInt32(0);
                    //Nome do Paciente
                    row.Cells[1].Value = reader.GetString(1);
                    //Data de Nascimento
                    row.Cells[2].Value = reader.GetString(2);
                    //Sexo
                    row.Cells[3].Value = reader.GetString(3);
                    //RG
                    row.Cells[4].Value = reader.GetString(4);
                    //Endereço
                    row.Cells[5].Value = reader.GetString(5);
                    //Contato
                    row.Cells[6].Value = reader.GetString(6);
                    //Possui Plano de Saúde?
                    row.Cells[7].Value = reader.GetString(7);
                    dataGridView1.Rows.Add(row);
                }
                realizaConexacoBD.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;

                //Preenche os textbox (txtb) e combobox (cmbb) com as células da linha selecionada
                //Nome do Paciente
                txtbNomeCompleto.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnNome"].FormattedValue.ToString();
                //Data de Nascimento
                txtbNascimento.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnNascimento"].FormattedValue.ToString();
                //Sexo
                cmbbSexo.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnSexo"].FormattedValue.ToString();
                //RG
                txtbRG.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnRG"].FormattedValue.ToString();
                //ID Cadastro
                txtbID.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnID"].FormattedValue.ToString();
                //Endereço
                txtbEndereco.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnEndereco"].FormattedValue.ToString();
                //Contato
                txtbContato.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnContato"].FormattedValue.ToString();
                //Possui Plano de Saúde?
                cmbbPlanoSaude.Text = dataGridView1.Rows[e.RowIndex].Cells["ColumnPlanoSaude"].FormattedValue.ToString();
            }

        }
        private void limparCamposCadastro()//Limpa os textbox (txtb) e combobox(cmbb) 
        {
            //Nome do Paciente
            txtbNomeCompleto.Clear();
            //Data de Nascimento
            txtbNascimento.Clear();
            //Sexo
            cmbbSexo.Text = "";
            //RG
            txtbRG.Clear();
            //ID Cadastro
            txtbID.Clear();
            //Endereço
            txtbEndereco.Clear();
            //Contato
            txtbContato.Clear();
            //Possui Plano de Saúde?
            cmbbPlanoSaude.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCamposCadastro();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE cadastro SET ativoPaciente = 1 WHERE idCadastro = " + txtbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();

                //Exibi mensagem informando que o Paciente foi deletado com sucesso
                MessageBox.Show("Paciente deletado com sucesso!");
                atualizarGridCadastro();
                limparCamposCadastro();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAtualizar_Click_1(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE cadastro SET nomeCompleto = '" + txtbNomeCompleto.Text + "', " +
                    "dataNascimento = '" + txtbNascimento.Text + "', " +
                    "sexo = '" + cmbbSexo.Text + "', " +
                    "rgPaciente = '" + txtbRG.Text + "', " +
                    "endereco = '" + txtbEndereco.Text + "', " +
                    "contato = '" + txtbContato.Text + "', " +
                    "planoSaude = '" + cmbbPlanoSaude.Text + "' WHERE idCadastro = " + txtbID.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();

                //Exibe mensagem informando que os dados do Paciente foram atualizados com sucesso
                MessageBox.Show("Dados do paciente atualizados com sucesso!"); 
                atualizarGridCadastro();
                limparCamposCadastro();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnMarcarConsulta_Click(object sender, EventArgs e)
        {
            //Cria a estrutura da conexão com o banco de dados (marcarconsulta) e passa os parametros
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";

            //Realiza a conexão com o banco de dados (marcarconsulta)
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                //Abre a conexão com o banco de dados (marcarconsulta)
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "INSERT INTO marcarconsulta (nomePaciente,procedimento,especmed,dataConsulta) " +
                    "VALUES('" + txtbNomeCompletoConsulta.Text + "', '" + txtbProcedimento.Text + "', '" + cmbbEspecialidadeMedica.Text + "', '" + txtbDataConsulta.Text + "')";
                comandoMySql.ExecuteNonQuery();

                //Fecha a conexão com o banco de dados (marcarconsulta)
                realizaConexacoBD.Close();

                //Exibe uma mensagem informando que a consulta foi marcada com sucesso
                MessageBox.Show("Consulta marcada com sucesso!");
                atualizarGridConsulta();
                limparCamposConsulta();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void atualizarGridConsulta()
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";
            
            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();

                //Traz todos os itens da tabela marcarconsulta
                comandoMySql.CommandText = "SELECT * from marcarconsulta WHERE ativoConsulta = 0"; 
                MySqlDataReader reader = comandoMySql.ExecuteReader();

                dataGridView2.Rows.Clear();

                while (reader.Read())
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                    //ID Consulta
                    row.Cells[0].Value = reader.GetInt32(0);
                    //Nome do Paciente
                    row.Cells[1].Value = reader.GetString(1);
                    //Procedimento Médico
                    row.Cells[2].Value = reader.GetString(2);
                    //Especialidade Médica
                    row.Cells[3].Value = reader.GetString(3);
                    //Data da Consulta
                    row.Cells[4].Value = reader.GetString(4);
                    dataGridView2.Rows.Add(row);
                }
                realizaConexacoBD.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView2.CurrentRow.Selected = true;

                //Preenche os textbox (txtb) e combobox (cmbb) com as células da linha selecionada
                //Nome do Paciente
                txtbNomeCompletoConsulta.Text = dataGridView2.Rows[e.RowIndex].Cells["ColumnNomeConsulta"].FormattedValue.ToString();
                //Procedimento Médico
                txtbProcedimento.Text = dataGridView2.Rows[e.RowIndex].Cells["ColumnProcedimento"].FormattedValue.ToString();
                //Especialidade Médica
                cmbbEspecialidadeMedica.Text = dataGridView2.Rows[e.RowIndex].Cells["ColumnEspecMed"].FormattedValue.ToString();
                //Data da Consulta
                txtbDataConsulta.Text = dataGridView2.Rows[e.RowIndex].Cells["ColumnData"].FormattedValue.ToString();
                //ID Consulta
                txtbIDConsulta.Text = dataGridView2.Rows[e.RowIndex].Cells["ColumnIDConsulta"].FormattedValue.ToString();

            }

        }
        private void limparCamposConsulta()//Limpa os textbox (txtb) e combobox(cmbb) 
        {
            //Nome do Paciente
            txtbNomeCompletoConsulta.Clear();
            //Especialidade Médica
            cmbbEspecialidadeMedica.Text = ""; 
            //Procedimento Médico
            txtbProcedimento.Clear();
            //Data da Consulta
            txtbDataConsulta.Clear();
            //ID Consulta
            txtbIDConsulta.Clear();
        }

        private void btnLimparConsulta_Click(object sender, EventArgs e)
        {
            limparCamposConsulta();
        }

        private void btnExcluirConsulta_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";

            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE marcarconsulta SET ativoConsulta = 1 WHERE idConsulta = " + txtbIDConsulta.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();

                //Exibe uma mensagem informando que a consulta foi deletada com sucesso
                MessageBox.Show("Consulta deletada com sucesso!");
                atualizarGridConsulta();
                limparCamposConsulta();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnAtualizarConsulta_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder conexaoBD = new MySqlConnectionStringBuilder();
            conexaoBD.Server = "localhost";
            conexaoBD.Database = "projetoclinica";
            conexaoBD.UserID = "root";
            conexaoBD.Password = "";

            MySqlConnection realizaConexacoBD = new MySqlConnection(conexaoBD.ToString());

            try
            {
                realizaConexacoBD.Open();

                MySqlCommand comandoMySql = realizaConexacoBD.CreateCommand();
                comandoMySql.CommandText = "UPDATE marcarconsulta SET nomePaciente = '" + txtbNomeCompletoConsulta.Text + "', " +
                    "procedimento = '" + txtbProcedimento.Text + "', " +
                    "especmed = '" + cmbbEspecialidadeMedica.Text + "', " +
                    "dataConsulta = '" + txtbDataConsulta.Text + "' WHERE idConsulta = " + txtbIDConsulta.Text + "";
                comandoMySql.ExecuteNonQuery();

                realizaConexacoBD.Close();

                //Exibe uma mensagem informando que os dados da consulta foram atualizados com sucesso
                MessageBox.Show("Dados da consulta atualizados com sucesso!");
                atualizarGridConsulta();
                limparCamposConsulta();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
