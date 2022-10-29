using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelObj = Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace Shop
{
    public partial class Shop : Form
    {
        public int ID = 0;

        public Shop(int ID_log)
        {
            InitializeComponent();
            Get_Info(ID_log);
            ID = ID_log;
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.KeyPress += (sender, e) => e.Handled = true;
            comboBox2.KeyPress += (sender, e) => e.Handled = true;
            comboBox3.KeyPress += (sender, e) => e.Handled = true;
            comboBox4.KeyPress += (sender, e) => e.Handled = true;
            comboBox5.KeyPress += (sender, e) => e.Handled = true;
        }

        private void Shop_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Получаем из БД данные для таблиц программы и выводим их в DataGridView1.
        public void Get_Info(int ID)
        {
            // Вкладка "Номенклатура" - Таблица "Группа".
            string query = "SELECT * FROM types; ";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlDataAdapter sda = new MySqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView1.ClearSelection();
                this.dataGridView1.Columns[0].HeaderText = "Код группы";
                dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].HeaderText = "Наименование группы одежды";
                this.dataGridView1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Columns[1].Width = 215;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Номенклатура" - Таблица "Пол".
            string query1 = "select * from sex; ";
            MySqlConnection conn1 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda1 = new MySqlDataAdapter(query1, conn1);
            DataTable dt1 = new DataTable();
            try
            {
                conn1.Open();
                dataGridView2.DataSource = dt1;
                dataGridView2.ClearSelection();
                sda1.Fill(dt1);
                dataGridView2.DataSource = dt1;
                dataGridView2.ClearSelection();
                this.dataGridView2.Columns[0].HeaderText = "Код пола";
                dataGridView2.Columns[0].Visible = false;
                this.dataGridView2.Columns[1].HeaderText = "Пол";
                this.dataGridView2.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView2.Columns[1].Width = 215;
                dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Номенклатура" - Таблица "Сезон".
            string query2 = "select * from seasons; ";
            MySqlConnection conn2 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda2 = new MySqlDataAdapter(query2, conn2);
            DataTable dt2 = new DataTable();
            try
            {
                conn2.Open();
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                sda2.Fill(dt2);
                dataGridView3.DataSource = dt2;
                dataGridView3.ClearSelection();
                this.dataGridView3.Columns[0].HeaderText = "Код сезона";
                dataGridView3.Columns[0].Visible = false;
                this.dataGridView3.Columns[1].HeaderText = "Сезон";
                this.dataGridView3.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView3.Columns[1].Width = 215;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Номенклатура" - Таблица "Товар".
            string query3 = "SELECT * FROM clothing, types, sex, seasons WHERE clothing.id_type=types.id_type AND clothing.id_sex=sex.id_sex AND clothing.id_seasons=seasons.id_seasons ORDER BY name_cloth; ";
            MySqlConnection conn3 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda3 = new MySqlDataAdapter(query3, conn3);
            DataTable dt3 = new DataTable();
            try
            {
                conn3.Open();
                dataGridView4.DataSource = dt3;
                dataGridView4.ClearSelection();
                sda3.Fill(dt3);
                dataGridView4.DataSource = dt3;
                dataGridView4.ClearSelection();
                //dataGridView4.Columns[0].Visible = false;
                this.dataGridView4.Columns[0].HeaderText = "Код товара";
                this.dataGridView4.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[0].Width = 65;
                this.dataGridView4.Columns[1].HeaderText = "Наименование товара";
                this.dataGridView4.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[1].Width = 135;
                this.dataGridView4.Columns[2].HeaderText = "Код типа";
                dataGridView4.Columns[2].Visible = false;
                this.dataGridView4.Columns[3].HeaderText = "Код пола";
                dataGridView4.Columns[3].Visible = false;
                this.dataGridView4.Columns[4].HeaderText = "Код сезона";
                dataGridView4.Columns[4].Visible = false;
                dataGridView4.Columns[5].DisplayIndex = 11;
                this.dataGridView4.Columns[5].HeaderText = "Цена";
                this.dataGridView4.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[5].Width = 90;
                this.dataGridView4.Columns[6].HeaderText = "Тип";
                dataGridView4.Columns[6].Visible = false;
                this.dataGridView4.Columns[7].HeaderText = "Тип одежды";
                this.dataGridView4.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[7].Width = 150;
                this.dataGridView4.Columns[8].HeaderText = "Код пола";
                dataGridView4.Columns[8].Visible = false;
                this.dataGridView4.Columns[9].HeaderText = "Пол";
                this.dataGridView4.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[9].Width =85;
                this.dataGridView4.Columns[10].HeaderText = "Код сезона";
                dataGridView4.Columns[10].Visible = false;
                this.dataGridView4.Columns[11].HeaderText = "Сезон";
                this.dataGridView4.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView4.Columns[11].Width = 100;
                dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Сотрудники" - Таблица "Должности".
            string query4 = "select * from positions; ";
            MySqlConnection conn4 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda4 = new MySqlDataAdapter(query4, conn4);
            DataTable dt4 = new DataTable();
            try
            {
                conn4.Open();
                dataGridView5.DataSource = dt4;
                dataGridView5.ClearSelection();
                sda4.Fill(dt4);
                dataGridView5.DataSource = dt4;
                dataGridView5.ClearSelection();
                this.dataGridView5.Columns[0].HeaderText = "Код должности";
                dataGridView5.Columns[0].Visible = false;
                this.dataGridView5.Columns[1].HeaderText = "Должность";
                this.dataGridView5.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView5.Columns[1].Width = 215;
                this.dataGridView5.Columns[2].HeaderText = "Заработная плата";
                this.dataGridView5.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView5.Columns[2].Width = 150;
                dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn4.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Сотрудники" - Таблица "Персонал".
            string query5 = "SELECT * FROM workers, positions WHERE workers.id_posistion=positions.id_position ORDER BY id_position;";
            MySqlConnection conn5 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda5 = new MySqlDataAdapter(query5, conn5);
            DataTable dt5 = new DataTable();
            try
            {
                conn5.Open();
                dataGridView6.DataSource = dt5;
                dataGridView6.ClearSelection();
                sda5.Fill(dt5);
                dataGridView6.DataSource = dt5;
                dataGridView6.ClearSelection();
                this.dataGridView6.Columns[0].HeaderText = "Табельный номер работника";
                this.dataGridView6.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView6.Columns[0].Width = 100;
                this.dataGridView6.Columns[1].HeaderText = "ФИО работника";
                this.dataGridView6.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView6.Columns[1].Width = 230;
                this.dataGridView6.Columns[2].HeaderText = "Код должности";
                dataGridView6.Columns[2].Visible = false;
                this.dataGridView6.Columns[3].HeaderText = "Номер телефона";
                this.dataGridView6.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView6.Columns[3].Width = 150;
                this.dataGridView6.Columns[4].HeaderText = "Код должности";
                dataGridView6.Columns[4].Visible = false;
                dataGridView6.Columns[5].DisplayIndex = 2;
                this.dataGridView6.Columns[5].HeaderText = "Должность";
                this.dataGridView6.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView6.Columns[5].Width = 150;
                this.dataGridView6.Columns[6].HeaderText = "Зарплата";
                dataGridView6.Columns[6].Visible = false;
                dataGridView6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn5.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - Таблица "Ассортиментный перечень товаров".
            string query6 = "SELECT * FROM clothing, types, sex, seasons WHERE clothing.id_type=types.id_type AND clothing.id_sex=sex.id_sex AND clothing.id_seasons=seasons.id_seasons ORDER BY name_cloth; ";
            MySqlConnection conn6 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda6 = new MySqlDataAdapter(query6, conn6);
            DataTable dt6 = new DataTable();
            try
            {
                conn6.Open();
                dataGridView7.DataSource = dt6;
                dataGridView7.ClearSelection();
                sda6.Fill(dt6);
                dataGridView7.DataSource = dt6;
                dataGridView7.ClearSelection();
                //dataGridView7.Columns[0].Visible = false;
                this.dataGridView7.Columns[0].HeaderText = "Код товара";
                this.dataGridView7.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[0].Width = 65;
                this.dataGridView7.Columns[1].HeaderText = "Наименование товара";
                this.dataGridView7.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[1].Width = 135;
                this.dataGridView7.Columns[2].HeaderText = "Код типа";
                dataGridView7.Columns[2].Visible = false;
                this.dataGridView7.Columns[3].HeaderText = "Код пола";
                dataGridView7.Columns[3].Visible = false;
                this.dataGridView7.Columns[4].HeaderText = "Код сезона";
                dataGridView7.Columns[4].Visible = false;
                dataGridView7.Columns[5].DisplayIndex = 11;
                this.dataGridView7.Columns[5].HeaderText = "Цена";
                this.dataGridView7.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[5].Width = 90;
                this.dataGridView7.Columns[6].HeaderText = "Тип";
                dataGridView7.Columns[6].Visible = false;
                this.dataGridView7.Columns[7].HeaderText = "Тип одежды";
                this.dataGridView7.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[7].Width = 150;
                this.dataGridView7.Columns[8].HeaderText = "Код пола";
                dataGridView7.Columns[8].Visible = false;
                this.dataGridView7.Columns[9].HeaderText = "Пол";
                this.dataGridView7.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[9].Width = 85;
                this.dataGridView7.Columns[10].HeaderText = "Код сезона";
                dataGridView7.Columns[10].Visible = false;
                this.dataGridView7.Columns[11].HeaderText = "Сезон";
                this.dataGridView7.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView7.Columns[11].Width = 100;
                dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn3.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            // Вкладка "Продажи" - Таблица "Корзина покупателя".
            string query7 = "select * from cart, clothing WHERE cart.id_cloth=clothing.id_cloth; ";
            MySqlConnection conn7 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda7 = new MySqlDataAdapter(query7, conn7);
            DataTable dt7 = new DataTable();
            try
            {
                conn7.Open();
                dataGridView8.DataSource = dt7;
                dataGridView8.ClearSelection();
                sda7.Fill(dt7);
                dataGridView8.DataSource = dt7;
                dataGridView8.ClearSelection();
                dataGridView8.Columns[0].Visible = false;
                this.dataGridView8.Columns[1].HeaderText = "Код товара";
                this.dataGridView8.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[1].Width = 90;
                dataGridView8.Columns[2].Visible = false;
                this.dataGridView8.Columns[3].HeaderText = "Наименование товара";
                this.dataGridView8.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[3].Width = 140;
                dataGridView8.Columns[4].Visible = false;
                dataGridView8.Columns[5].Visible = false;
                dataGridView8.Columns[6].Visible = false;
                this.dataGridView8.Columns[7].HeaderText = "Цена";
                this.dataGridView8.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView8.Columns[7].Width = 105;
                dataGridView8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn7.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }

            int sum = 0;
            for (int i = 0; i < dataGridView8.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView8.Rows[i].Cells[7].Value);
            }

            textBox13.Text = sum.ToString("# ##0", System.Globalization.CultureInfo.InvariantCulture);

            // Вкладка "Продажи" - Таблица "Расчеты покупателей".
            string query8 = "select * from orders, workers WHERE orders.id_worker=workers.id_worker; ";
            MySqlConnection conn8 = DBUtils.GetDBConnection();
            MySqlDataAdapter sda8 = new MySqlDataAdapter(query8, conn8);
            DataTable dt8 = new DataTable();
            try
            {
                conn8.Open();
                dataGridView9.DataSource = dt8;
                dataGridView9.ClearSelection();
                sda8.Fill(dt8);
                dataGridView9.DataSource = dt8;
                dataGridView9.ClearSelection();
                this.dataGridView9.Columns[0].HeaderText = "Номер продажи";
                this.dataGridView9.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[0].Width = 70;
                this.dataGridView9.Columns[1].HeaderText = "Дата продажи";
                this.dataGridView9.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[1].Width = 140;
                dataGridView9.Columns[2].Visible = false;
                this.dataGridView9.Columns[2].HeaderText = "Код продавца";
                this.dataGridView9.Columns[3].HeaderText = "Общая стоимость покупки";
                this.dataGridView9.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[3].Width = 150;
                dataGridView9.Columns[4].Visible = false;
                this.dataGridView9.Columns[4].HeaderText = "Код продавца";
                this.dataGridView9.Columns[5].HeaderText = "Продавец";
                this.dataGridView9.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView9.Columns[5].Width = 250;
                dataGridView9.Columns[6].Visible = false;
                this.dataGridView9.Columns[6].HeaderText = "Код должности";
                dataGridView9.Columns[7].Visible = false;
                this.dataGridView9.Columns[7].HeaderText = "Номер телефона";
                dataGridView9.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                conn8.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденая ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        //Функция, позволяющая отправить команду на сервер БД для оптимизации кода.
        public void do_Action(string query)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            try
            {
                conn.Open();
                cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        // ******************* ВКЛАДКА "НОМЕНКЛАТУРА" *********************
        //                        ТАБЛИЦА "ГРУППЫ"
        // Вывод данных в текстовое поле таблицы "Группы".
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
        }

        // Таблица "Группа" - кнопка "Добавить".
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Введите группу товара.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into types (name_type) VALUES ('" + textBox1.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox1.Clear();
                }
            }
        }

        // Таблица "Группа" - кнопка "Изменить".
        private void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox1.Text == null || textBox1.Text == "")
                MessageBox.Show(
                    "Введите группу товара.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE types SET name_type='" + textBox1.Text + "' WHERE id_type=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox1.Clear();

                    comboBox1.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  types; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox1.Items.Add(reader1.GetString("name_type"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //                        ТАБЛИЦА "СЕЗОН"
        // Вывод данных в текстовое поле таблицы "Сезон".
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
        }

        // Таблица "Сезон" - кнопка "Добавить".
        private void button5_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите наименование сезона.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into seasons (name_seasons) VALUES ('" + textBox2.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox2.Clear();
                }
            }
        }
        // Таблица "Сезон" - кнопка "Изменить".
        private void button6_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox2.Text == null || textBox2.Text == "")
                MessageBox.Show(
                    "Введите группу товара.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView3.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE seasons SET name_seasons='" + textBox2.Text + "' WHERE id_seasons=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox1.Clear();

                    comboBox3.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  seasons; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox3.Items.Add(reader1.GetString("name_seasons"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //                        ТАБЛИЦА "ПОЛ"
        // Вывод данных в текстовое поле таблицы "Пол".
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
        }

        // Таблица "Пол" - кнопка "Добавить".
        private void button3_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите пол.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "INSERT INTO sex (name_sex) VALUES ('" + textBox3.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox3.Clear();
                }
            }
        }
        // Таблица "Пол" - кнопка "Изменить".
        private void button4_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы было заполнено поле ввода.
            if (textBox3.Text == null || textBox3.Text == "")
                MessageBox.Show(
                    "Введите пол.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE sex SET name_sex='" + textBox3.Text + "' WHERE id_sex=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox3.Clear();

                    comboBox2.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  sex; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox2.Items.Add(reader1.GetString("name_sex"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //                        ТАБЛИЦА "ТОВАР"
        // Вывод данных в текстовые поля таблицы "Товар".
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            this.textBox4.ForeColor = System.Drawing.Color.Blue;
            textBox5.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            // int cena = int.Parse(dataGridView4.CurrentRow.Cells[5].Value.ToString());
            // textBox5.Text = cena.ToString("# ##0", System.Globalization.CultureInfo.InvariantCulture) + (" руб.");
            this.textBox5.ForeColor = System.Drawing.Color.Blue;
            comboBox1.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();
            this.comboBox1.ForeColor = System.Drawing.Color.Blue;
            comboBox2.Text = dataGridView4.CurrentRow.Cells[9].Value.ToString();
            this.comboBox2.ForeColor = System.Drawing.Color.Blue;
            comboBox3.Text = dataGridView4.CurrentRow.Cells[11].Value.ToString();
            this.comboBox3.ForeColor = System.Drawing.Color.Blue;
        }

        // Вывод выпадающих списков в поля comboBox ("Тип", "Пол", "Сезон", "Персонал" и "ФИО продавца"). 
        private void Shop_Load(object sender, EventArgs e)
        {
            // Список - Тип.
            try
            {
                string query = "SELECT * FROM  types; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader.GetString("name_type"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список - Пол.
            try
            {
                string query = "SELECT * FROM  sex; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox2.Items.Add(reader.GetString("name_sex"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список - Сезон.
            try
            {
                string query = "SELECT * FROM  seasons; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader.GetString("name_seasons"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список - Должность.
            try
            {
                string query = "SELECT * FROM  positions; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox4.Items.Add(reader.GetString("name_position"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            // Список - ФИО продавца.
            try
            {
                string query = "SELECT * FROM  workers; ";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(query, conn);
                conn.Open();
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox5.Items.Add(reader.GetString("fio_worker"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Выбор типа одежды в выпадающем списке comboBox1.
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_type = comboBox1.Text;
            try
            {
                string ID_type = "SELECT id_type FROM types where name_type='" + id_type + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_type, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_type, conn);
                label_id_type.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Выбор пола в выпадающем списке comboBox2.
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_sex = comboBox2.Text;
            try
            {
                string ID_sex = "SELECT id_sex FROM sex where name_sex='" + id_sex + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_sex, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_sex, conn);
                label_id_sex.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Выбор сезона в выпадающем списке comboBox2.
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_seasons = comboBox3.Text;
            try
            {
                string ID_seasons = "SELECT id_seasons FROM seasons where name_seasons='" + id_seasons + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_seasons, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_seasons, conn);
                label_id_seasons.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Таблица "Товар" - кнопка "Добавить".
        private void button7_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода.
            if (textBox4.Text == null || textBox4.Text == "")
                MessageBox.Show(
                    "Введите наименование одежды.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox1.Text == null || comboBox1.Text == "")
                MessageBox.Show(
                    "Выберете тип одежды.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox2.Text == null || comboBox2.Text == "")
                MessageBox.Show(
                    "Выберете пол.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox3.Text == null || comboBox3.Text == "")
                MessageBox.Show(
                    "Выберете сезон.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox5.Text == null || textBox5.Text == "")
                MessageBox.Show(
                    "Введите цену товара.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into clothing(name_cloth, id_type, id_sex, id_seasons, price) values('" + textBox4.Text + "', '" + label_id_type.Text + "', '" + label_id_sex.Text + "', '" + label_id_seasons.Text + "', '" + textBox5.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }

            }
        }

        // Таблица "Товар" - кнопка "Изменить".
        private void button8_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода.
            if (textBox4.Text == null || textBox4.Text == "")
                MessageBox.Show(
                    "Введите наименование одежды.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox1.Text == null || comboBox1.Text == "")
                MessageBox.Show(
                    "Выберете тип одежды.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox2.Text == null || comboBox2.Text == "")
                MessageBox.Show(
                    "Выберете пол.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox3.Text == null || comboBox3.Text == "")
                MessageBox.Show(
                    "Выберете сезон.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox5.Text == null || textBox5.Text == "")
                MessageBox.Show(
                    "Введите цену товара.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE clothing SET name_cloth='" + textBox4.Text + "', id_type='" + label_id_type.Text + "', id_sex='" + label_id_sex.Text + "', id_seasons='" + label_id_seasons.Text + "', price='" + textBox5.Text + "' WHERE id_cloth=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                }
            }
        }

        // Таблица "Товар" - кнопка "Удалить".
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить информацию?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                string del = "delete from clothing where id_cloth = " + n + ";";
                do_Action(del);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
            Get_Info(ID);
        }

        // Таблица "Товар" - кнопка "Печать".
        private void button10_Click(object sender, EventArgs e)
        {
            int kol = dataGridView4.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView4.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView4.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView4.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView4.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // Таблица "Товар" - кнопка "Поиск".
        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.RowCount; i++)
            {
                dataGridView4.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView4.ColumnCount; j++)
                    if (dataGridView4.Rows[i].Cells[j].Value != null)
                        if (dataGridView4.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox6.Text.ToLower()))
                        {
                            dataGridView4.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // ******************* ВКЛАДКА "СОТРУДНИКИ" *********************
        //                     ТАБЛИЦА "Должности"
        // Вывод данных в текстовые поля таблицы "Должности".
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
            this.textBox7.ForeColor = System.Drawing.Color.Blue;
            textBox8.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
            this.textBox8.ForeColor = System.Drawing.Color.Blue;
        }

        // Таблица "Должности" - кнопка "Добавить".
        private void button12_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля "Должность" и "Зарплата".
            if (textBox7.Text == null || textBox7.Text == "")
                MessageBox.Show(
                    "Введите должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox8.Text == null || textBox8.Text == "")
                MessageBox.Show(
                    "Введите размер заработной платы.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into positions (name_position, salary) VALUES ('" + textBox7.Text + "', '" + textBox8.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }
        }

        // Таблица "Должности" - кнопка "Изменить".
        private void button13_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля "Должность" и "Зарплата".
            if (textBox7.Text == null || textBox7.Text == "")
                MessageBox.Show(
                    "Введите должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (textBox8.Text == null || textBox8.Text == "")
                MessageBox.Show(
                    "Введите размер заработной платы.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView5.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE positions SET name_position='" + textBox7.Text + "', salary='" + textBox8.Text + "' WHERE id_position=" + n + "; ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox7.Clear();
                    textBox8.Clear();
                }
            }
        }

        // Таблица "Должности" - кнопка "Поиск".
        private void button14_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.RowCount; i++)
            {
                dataGridView5.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    if (dataGridView5.Rows[i].Cells[j].Value != null)
                        if (dataGridView5.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox9.Text.ToLower()))
                        {
                            dataGridView5.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        // Таблица "Должности" - кнопка "Печать".
        private void button15_Click(object sender, EventArgs e)
        {
            int kol = dataGridView5.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView5.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView5.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView5.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView5.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView5.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // ******************* ВКЛАДКА "СОТРУДНИКИ" *********************
        //                     ТАБЛИЦА "Персонал"
        // Вывод данных в текстовые поля таблицы "Персонал".
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox10.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
            this.textBox10.ForeColor = System.Drawing.Color.Blue;
            maskedTextBox1.Text = dataGridView6.CurrentRow.Cells[3].Value.ToString();
            this.maskedTextBox1.ForeColor = System.Drawing.Color.Blue;
            comboBox4.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();
            this.comboBox4.ForeColor = System.Drawing.Color.Blue;
        }

        // Выбор должности в выпадающем списке comboBox4.
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_position = comboBox4.Text;
            try
            {
                string ID_seasons = "SELECT id_position FROM positions where name_position='" + id_position + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_seasons, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_seasons, conn);
                label_id_position.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Таблица "Персонал" - кнопка "Добавить".
        private void button16_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода (ФИО сотрудника, должность и телефон).
            if (textBox10.Text == null || textBox10.Text == "")
                MessageBox.Show(
                    "Введите ФИО сотрудника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox4.Text == null || comboBox4.Text == "")
                MessageBox.Show(
                    "Выберете должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox1.Text == null || maskedTextBox1.Text == "")
                MessageBox.Show(
                    "Введите номер телефона.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите добавить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string query = "insert into workers(fio_worker, id_posistion, phone_number) values('" + textBox10.Text + "', '" + label_id_position.Text + "', '" + maskedTextBox1.Text + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox10.Clear();
                    maskedTextBox1.Clear();

                    comboBox5.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  workers; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox5.Items.Add(reader1.GetString("fio_worker"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Таблица "Персонал" - кнопка "Изменить".
        private void button17_Click(object sender, EventArgs e)
        {
            // Проверяем, чтобы были заполнены поля ввода (ФИО сотрудника, должность и телефон).
            if (textBox10.Text == null || textBox10.Text == "")
                MessageBox.Show(
                    "Введите ФИО сотрудника.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (comboBox4.Text == null || comboBox4.Text == "")
                MessageBox.Show(
                    "Выберете должность.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else if (maskedTextBox1.Text == null || maskedTextBox1.Text == "")
                MessageBox.Show(
                    "Введите номер телефона.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Вы уверены что хотите изменить запись?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    int n = int.Parse(dataGridView6.CurrentRow.Cells[0].Value.ToString());
                    string query = " UPDATE workers SET fio_worker='" + textBox10.Text + "', id_posistion='" + label_id_position.Text + "', phone_number='" + maskedTextBox1.Text + "' WHERE id_worker=" + n + "; ";                   
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    Get_Info(ID);
                    textBox10.Clear();
                    maskedTextBox1.Clear();

                    comboBox5.Items.Clear();
                    try
                    {
                        string query1 = "SELECT * FROM  workers; ";
                        MySqlConnection conn1 = DBUtils.GetDBConnection();
                        MySqlCommand cmDB1 = new MySqlCommand(query1, conn1);
                        conn1.Open();
                        MySqlCommand command1 = new MySqlCommand(query1, conn1);
                        MySqlDataReader reader1 = command1.ExecuteReader();
                        while (reader1.Read())
                        {
                            comboBox5.Items.Add(reader1.GetString("fio_worker"));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        // Поисковая строка - кнопка "Найти " для таблицы "Персонал".
        private void button19_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView6.RowCount; i++)
            {
                dataGridView6.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView6.ColumnCount; j++)
                    if (dataGridView6.Rows[i].Cells[j].Value != null)
                        if (dataGridView6.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox12.Text.ToLower()))
                        {
                            dataGridView6.Rows[i].Selected = true;
                            break;                          
                        }
            }

        }
         // Кнопка "Печать" - таблица "Персонал".
        private void button20_Click(object sender, EventArgs e)
        {
            int kol = dataGridView6.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView6.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView6.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView6.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView6.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView6.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }

        // ******************* ВКЛАДКА "ПРОДАЖИ" *********************
        //        ТАБЛИЦА "Ассортиментный перечень товаров"
        // Добавление товаров в покупательскую корзину.
        private void button21_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Добавить товар в корзину?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView7.CurrentRow.Cells[0].Value.ToString());
                string insert = "INSERT INTO cart (id_cloth) VALUES (" + n + ");";
                do_Action(insert);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Добавление невозможно.");
            }
            Get_Info(ID);
        }
        // Кнопка "Найти".
        private void button23_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView7.RowCount; i++)
            {
                dataGridView7.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView7.ColumnCount; j++)
                    if (dataGridView7.Rows[i].Cells[j].Value != null)
                        if (dataGridView7.Rows[i].Cells[j].Value.ToString().ToLower().Contains(textBox11.Text.ToLower()))
                        {
                            dataGridView7.Rows[i].Selected = true;
                            break;
                        }
            }
        }
         // Кнопка "Удалить из корзины".
        private void button22_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены что хотите удалить товар?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int n = int.Parse(dataGridView8.CurrentRow.Cells[1].Value.ToString());
                string del = "delete from cart where id_cloth = " + n + ";";
                do_Action(del);
            }
            else
            {
                MessageBox.Show("Не выбрано ни одной записи! Удаление невозможно.");
            }
            Get_Info(ID);
        }

        // Кнопка "Произвести расчет".
        private void button24_Click(object sender, EventArgs e)
        {
            double final_price = Convert.ToDouble(textBox13.Text);
            // Проверяем, чтобы было заполнено поле ввода.
            if (final_price == 0)
                MessageBox.Show(
                    "Не выбраны товары.",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
            {
                DialogResult res = MessageBox.Show("Произвести расчет?", "Подтвердите действие", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string Date = dateTimePicker1.Value.ToString("yyyy-MM-dd");                    
                    string query = "insert into orders (date_order, id_worker, final_price) VALUES ('" + Date + "', '" + label_id_work.Text + "', '" + final_price + "'); ";
                    MySqlConnection conn = DBUtils.GetDBConnection();
                    MySqlCommand cmDB = new MySqlCommand(query, conn);
                    try
                    {
                        conn.Open();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                    }
                    do_Action(query);
                    textBox13.Clear();
                    string del = "DELETE FROM cart;";
                    do_Action(del);
                    Get_Info(ID);
                }
            }
        }

        // Вывод данных в текстовые поля таблицы "Расчеты покупателей".
        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dateTimePicker1.Text = dataGridView9.CurrentRow.Cells[1].Value.ToString();
            comboBox5.Text = dataGridView9.CurrentRow.Cells[5].Value.ToString();
            this.comboBox5.ForeColor = System.Drawing.Color.Blue;
        }
         // Определение id работника по его ФИО.
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id_work = comboBox5.Text;
            try
            {
                string ID_work = "SELECT id_worker FROM workers where fio_worker='" + id_work + "';";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmDB = new MySqlCommand(ID_work, conn);

                conn.Open();
                MySqlCommand command = new MySqlCommand(ID_work, conn);
                label_id_work.Text = command.ExecuteScalar().ToString();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка "Печать".
        private void button25_Click(object sender, EventArgs e)
        {
            int kol = dataGridView9.Rows.Count;
            if (kol != 0)
            {
                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
                Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
                //Книга.
                ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
                //Таблица.
                ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
                for (int i = 0; i < dataGridView9.ColumnCount; i++)
                {
                    ExcelApp.Cells[1, i + 1] = Convert.ToString(dataGridView9.Columns[i].HeaderText);
                }
                for (int i = 0; i < dataGridView9.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView9.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 2, j + 1] = Convert.ToString(dataGridView9.Rows[i].Cells[j].Value);
                    }
                }
                //Вызываем приложение Excel.
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            else
            {
                MessageBox.Show("Для импорта данных из таблицы в Excel для начала заполните таблицу данными!", "Импорт данных из таблицы в Excel");
            }
        }
    }
}

