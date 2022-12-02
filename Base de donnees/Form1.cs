using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_de_donnees
{
    public partial class Form1 : Form
    {
        string last_click_on = "";
        string Nom;
        string Prenom;
        int id; 

        static string chaine = @"Data Source=DESKTOP-IMTHR3V\SQLEXPRESS;Initial Catalog=tp_c#;Integrated Security=True";
        static SqlConnection cnx = new SqlConnection(chaine);
        static SqlCommand cmd = new SqlCommand();
        static SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        public Form1()
        {
            InitializeComponent();
        }
        public void turn_On_Off(Button btn, bool b)
        {
            btn.Enabled = b;
            if (b)
            {
                btn.BackColor = Color.White;


            }
            else
            {
                btn.BackColor = Color.Gray;
            }
        }

        public bool tableHasRows()
        {
            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "SELECT nom FROM Table_3;";
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                cnx.Close();
                return true;
            }
            else
            {
                reader.Close();
                cnx.Close();
                return true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_tp_c_DataSet1.Table_3' table. You can move, or remove it, as needed.
            this.table_3TableAdapter.Fill(this._tp_c_DataSet1.Table_3);
            

            turn_On_Off(BtnAjouter, true);
            turn_On_Off(BtnModifier, false);
            turn_On_Off(BtnSupprimer, false);
            turn_On_Off(BtnEnregistrer, false);
            turn_On_Off(BtnAnnuler, false);

            cnx.Open();
            cmd.Connection = cnx;
            cmd.CommandText = "select   nom,id  from Table_3";

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            DataRow itemrow = dt.NewRow();
            itemrow[0] = "select name";
            dt.Rows.InsertAt(itemrow, 0);

            cbx.DataSource = dt;
            cbx.ValueMember = "id";
            cbx.DisplayMember = "nom ";

            cnx.Close();

            if (tableHasRows())
            {
                turn_On_Off(BtnModifier, true);
                turn_On_Off(BtnSupprimer, true);
            }

        }

            private void BtnAjouter_Click(object sender, EventArgs e)
            {
                last_click_on = "ajouter";
                {
                    cbx.Enabled = false;
                    cbx.BackColor = Color.Gray;

                    txtBoxNom.Enabled = true;
                    txtBoxNom.BackColor = Color.White;

                txtBoxId.Enabled = true;
                txtBoxId.BackColor = Color.White;


                txtBoxPrenom.Enabled = true;
                    txtBoxPrenom.BackColor = Color.White;

                    turn_On_Off(BtnAjouter, false);
                    turn_On_Off(BtnModifier, false);
                    turn_On_Off(BtnSupprimer, false);
                    turn_On_Off(BtnEnregistrer, true);
                    turn_On_Off(BtnAnnuler, true);
                }
            }
            private void BtnModifier_Click(object sender, EventArgs e)
            {
                last_click_on = "modifier";
                {
                    cbx.Enabled = false;
                    cbx.BackColor = Color.Gray;

                    txtBoxNom.Enabled = true;
                    txtBoxNom.BackColor = Color.White;

                    txtBoxPrenom.Enabled = true;
                    txtBoxPrenom.BackColor = Color.White;

                txtBoxId.Enabled = true;
                txtBoxId.BackColor = Color.White;

                turn_On_Off(BtnAjouter, false);
                    turn_On_Off(BtnModifier, false);
                    turn_On_Off(BtnSupprimer, false);
                    turn_On_Off(BtnEnregistrer, true);
                    turn_On_Off(BtnAnnuler, true);
                }
            }
            private void BtnSupprimer_Click(object sender, EventArgs e)
            {
                last_click_on = "supprimer";
                {
                    cbx.Enabled = true;
                    cbx.BackColor = Color.White;

                    txtBoxNom.Enabled = false;
                    txtBoxNom.BackColor = Color.Gray;

                    txtBoxPrenom.Enabled = false;
                    txtBoxPrenom.BackColor = Color.Gray;

                txtBoxId.Enabled = false;
                txtBoxId.BackColor = Color.Gray;

                turn_On_Off(BtnAjouter, false);
                    turn_On_Off(BtnModifier, false);
                    turn_On_Off(BtnSupprimer, false);
                    turn_On_Off(BtnEnregistrer, true);
                    turn_On_Off(BtnAnnuler, true);
                }
            }
            private void BtnEnregistrer_Click(object sender, EventArgs e)
            {
                if (last_click_on == "ajouter")
                {
                    
                    {
                        cbx.Enabled = true;
                        cbx.BackColor = Color.White;

                        txtBoxNom.Enabled = false;
                        txtBoxNom.BackColor = Color.Gray;

                        txtBoxPrenom.Enabled = false;
                        txtBoxPrenom.BackColor = Color.Gray;

                    txtBoxId.Enabled = false;
                    txtBoxId.BackColor = Color.Gray;

                    turn_On_Off(BtnAjouter, true);
                        turn_On_Off(BtnModifier, true);
                        turn_On_Off(BtnSupprimer, true);
                        turn_On_Off(BtnEnregistrer, false);
                        turn_On_Off(BtnAnnuler, false);
                    }
                   
                    {
                        Nom = txtBoxNom.Text;
                        Prenom = txtBoxPrenom.Text;
                        if (Nom == "" || Prenom == "")
                        {
                            Console.WriteLine("invalid nom et prenom");
                            return;
                        }
                        cnx.Open();
                        cmd.Connection = cnx;
                        cmd.CommandText = "insert into Table_3( prenom,nom,id ) values('" + Prenom + " ','" + Nom + "','"+txtBoxId.Text+"')";
                        cmd.ExecuteNonQuery();
                    cnx.Close();
                        txtBoxNom.Text = "";
                        txtBoxPrenom.Text = "";

                        Nom = txtBoxNom.Text;
                        Prenom = txtBoxPrenom.Text;
                    }
                }
                else if (last_click_on == "supprimer")
                {
                  
                    {
                        cbx.Enabled = true;
                        cbx.BackColor = Color.White;

                        txtBoxNom.Enabled = false;
                        txtBoxNom.BackColor = Color.Gray;

                        txtBoxPrenom.Enabled = false;
                        txtBoxPrenom.BackColor = Color.Gray;

                        turn_On_Off(BtnAjouter, true);
                        turn_On_Off(BtnModifier, false);
                        turn_On_Off(BtnSupprimer, false);
                        turn_On_Off(BtnEnregistrer, false);
                        turn_On_Off(BtnAnnuler, false);
                        if (tableHasRows())
                        {
                            turn_On_Off(BtnModifier, true);
                            turn_On_Off(BtnSupprimer, true);
                        }
                    }
                
                if (MessageBox.Show("Est Vous Sur ?!", "Delete Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                        cnx.Open();
                        cmd.Connection = cnx;
                        string deleted_id = cbx.SelectedValue.ToString();
                        Console.WriteLine(deleted_id);
                        cmd.CommandText = "delete from Table_3 where id ='" + deleted_id + "' ";
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                        MessageBox.Show("deleted"); 
                }
                else
                    MessageBox.Show("Merci !");
                 }
                else if (last_click_on == "modifier")
                {

                    
                    {
                        cbx.Enabled = true;
                        cbx.BackColor = Color.White;

                        txtBoxNom.Enabled = false;
                        txtBoxNom.BackColor = Color.Gray;

                        txtBoxPrenom.Enabled = false;
                        txtBoxPrenom.BackColor = Color.Gray;

                        turn_On_Off(BtnAjouter, true);
                        turn_On_Off(BtnModifier, true);
                        turn_On_Off(BtnSupprimer, true);
                        turn_On_Off(BtnEnregistrer, false);
                        turn_On_Off(BtnAnnuler, false);
                    }
                    
                    {
                        cnx.Open();
                        cmd.Connection = cnx;
                        string modified_id = cbx.SelectedValue.ToString();
                        cmd.CommandText = " update Table_3 set nom ='" + txtBoxNom.Text + "', prenom = '" + txtBoxPrenom.Text + "' where id= '" + modified_id + "' ;";
                        cmd.ExecuteNonQuery();
                        cnx.Close();
                    }
                }

                {
                    cnx.Open();
                    cmd.Connection = cnx;
                    cmd.CommandText = "select   nom,id  from Table_3";
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow itemrow = dt.NewRow();
                    itemrow[0] = "select name";
                    dt.Rows.InsertAt(itemrow, 0);

                    cbx.DataSource = dt;
                    cbx.DisplayMember = "nom ";
                    cbx.ValueMember = "id";
                    cnx.Close();
                }
            }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            if (last_click_on == "ajouter")
            {
                {
                    if (!tableHasRows())
                    {
                        turn_On_Off(BtnModifier, false);
                        turn_On_Off(BtnSupprimer, false);
                    }
                    else
                    {
                        turn_On_Off(BtnModifier, true);
                        turn_On_Off(BtnSupprimer, true);
                    }


                    cbx.Enabled = true;
                    cbx.BackColor = Color.White;

                    txtBoxNom.Enabled = false;
                    txtBoxNom.BackColor = Color.Gray;

                    txtBoxPrenom.Enabled = false;
                    txtBoxPrenom.BackColor = Color.Gray;

                    txtBoxId.Enabled = false;
                    txtBoxId.BackColor = Color.Gray;

                    turn_On_Off(BtnAjouter, true);
                    turn_On_Off(BtnEnregistrer, false);
                    turn_On_Off(BtnAnnuler, false);
                }


            }
            else if (last_click_on == "supprimer")
            {
                {
                    cbx.Enabled = true;
                    cbx.BackColor = Color.White;

                    txtBoxNom.Enabled = false;
                    txtBoxNom.BackColor = Color.Gray;

                    txtBoxPrenom.Enabled = false;
                    txtBoxPrenom.BackColor = Color.Gray;

                    txtBoxId.Enabled = false;
                    txtBoxId.BackColor = Color.Gray;

                    turn_On_Off(BtnAjouter, true);
                    turn_On_Off(BtnModifier, true);
                    turn_On_Off(BtnSupprimer, true);
                    turn_On_Off(BtnEnregistrer, false);
                    turn_On_Off(BtnAnnuler, false);
                }

            }
            else if (last_click_on == "modifier")
            {
                {
                    cbx.Enabled = true;
                    cbx.BackColor = Color.White;

                    txtBoxNom.Enabled = false;
                    txtBoxNom.BackColor = Color.Gray;

                    txtBoxPrenom.Enabled = false;
                    txtBoxPrenom.BackColor = Color.Gray;

                    txtBoxId.Enabled = false;
                    txtBoxId.BackColor = Color.Gray;

                    turn_On_Off(BtnAjouter, true);
                    turn_On_Off(BtnModifier, true);
                    turn_On_Off(BtnSupprimer, true);
                    turn_On_Off(BtnEnregistrer, false);
                    turn_On_Off(BtnAnnuler, false);
                }

            }

  
            {
                cnx.Open();
                cmd.Connection = cnx;
                cmd.CommandText = "select   nom,id  from Etudiant";
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataRow itemrow = dt.NewRow();
                itemrow[0] = "select name";
                dt.Rows.InsertAt(itemrow, 0);

                cbx.DataSource = dt;
                cbx.ValueMember = "id";
                cbx.DisplayMember = "nom ";
                cnx.Close();
            }
        }

    }
}

