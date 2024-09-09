using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        //conectar con la base de datos
        OleDbConnection cnn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ARCHIVOS LESLIE\trabajos personales\Septiembre\2 How to Create a C# MS Access Database Connection with Save, Update, Delete and Search -Full Tutorial\db_11.accdb");

        int checker;
        Bitmap bitmap;
         

        public Form1()
        {
            InitializeComponent();
        }



        void dataviewer() {

            try
            {
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from csave";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }

            //fin try/catch
        }






        private void button1_Click(object sender, EventArgs e)
        {
            //BOTON CERRAR
            this.Close();

        }
        //fin boton cerrar

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into csave(Student_Id,FirtName,SurName,Address,CodePost,Telephone)values('" + txtnum.Text+ "','" + txtnombre.Text + "','" + Txtapellido.Text + "','" + txtdireccion.Text + "','" + txtcpostal.Text + "','" + txttelefono.Text + "')";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Guardado en la base de datos", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }

            //fin try/catch

        }
        //fin boton 2

        private void button8_Click(object sender, EventArgs e)
        {
            //boton salir
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //mostrar en tabla
            dataviewer();
        }

       

      

        private void button3_Click(object sender, EventArgs e)
        {
            //actualizar
            try
            {
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update csave set Student_Id ='" + txtnum.Text + "'where FirtName = '" + txtnombre.Text + "'and SurName = '"+ Txtapellido.Text + "'"; 
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("Actualizado correctamente", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //mostrar en tabla
                dataviewer();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                txtnum.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                txtnombre.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                Txtapellido.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtdireccion.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtcpostal.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txttelefono.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton eliminar

            try
            {
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete * from csave where Student_Id ='" + txtnum.Text + "'";
                cmd.ExecuteNonQuery();
                cnn.Close();
                MessageBox.Show("ELIMINADO correctamente", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //mostrar en tabla
                dataviewer();

                txtnum.Text = "";
                txtnombre.Text = "";
                Txtapellido.Text = "";
                txtdireccion.Text = "";
                txtcpostal.Text = "";
                txttelefono.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //BORRAR DATOS DE CAMPOS
            txtnum.Text = "";
            txtnombre.Text = "";
            Txtapellido.Text = "";
            txtdireccion.Text = "";
            txtcpostal.Text = "";
            txttelefono.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {

            checker  = 0;
            //BOTON BUSCAR
            try
            {
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from csave where Student_Id ='" + txtbuscar.Text + "'or FirtName = '" + txtbuscar.Text + "'or SurName = '" + txtbuscar.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                checker = Convert.ToInt32(dt.Rows.Count.ToString());

                dataGridView1.DataSource = dt;
                cnn.Close();
                if (checker==0){
                    MessageBox.Show("Dato no encontrado", "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtbuscar.Text = "";
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cnn.Close();
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //boton imprimir
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try 
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Acceso correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
