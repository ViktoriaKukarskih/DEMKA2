using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Npgsql;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DEMKA
{
    public partial class EditPartnerForm : Form
    {
        private int partnerId;

        public EditPartnerForm(int id) //Редактирование
        {
            InitializeComponent();
            partnerId = id;
            lblTitle.Text = "Редактировать данные партнёра";

            LoadPartner();

        }
        public EditPartnerForm() //Добавление
        {
            InitializeComponent();
            lblTitle.Text = "Добавить нового партнёра";
        }

        private void LoadPartner()
        {
            try
            {
                using (var conn = new NpgsqlConnection (Db.ConnectionString))
                {
                    conn.Open ();

                    string query = @"SELECT * FROM partners WHERE ""Id"" = @id";

                    using (var cmd = new NpgsqlCommand (query, conn)) 
                    {
                        cmd.Parameters.AddWithValue ("@id", partnerId);
                        using (var reader = cmd.ExecuteReader ()) 
                        {
                            if (reader.Read ()) 
                            {
                                // Заполняем поля формы данными из БД
                                txtName.Text = reader["Name"].ToString();
                                cmbType.Text = reader["Type"].ToString();
                                txtRating.Text = reader["Rating"].ToString();
                                txtAddress.Text = reader["Address"].ToString();
                                txtDirector.Text = reader["Director"].ToString();
                                txtPhone.Text = reader["Phone"].ToString();
                                txtEmail.Text = reader["Email"].ToString();
                                txtInn.Text = reader["Inn"].ToString();
                            }

                            else
                            {
                                MessageBox.Show("Партнер не найден.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtRating.Text, out int rating) || rating < 0)
            {
                MessageBox.Show("Рейтинг должен быть неотрицательным целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(cmbType.Text) ||
                string.IsNullOrWhiteSpace(txtRating.Text))
                {
                MessageBox.Show("Заполните обязательные поля: Название, Тип и Рейтинг!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                }

            // Подтверждение для операции редактирования
            if (partnerId > 0) // Если ID > 0 - значит это редактирование существующей записи
            {
                var confirmResult = MessageBox.Show("Вы уверены, что хотите изменить данные партнера?",
                                    "Подтверждение",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);

                if (confirmResult != DialogResult.Yes)
                    return; // Пользователь отказался - прерываем сохранение
            }

            try
            {
                using (var conn = new NpgsqlConnection(Db.ConnectionString))
                {
                    conn.Open();
                    string query;

                    if (partnerId > 0) //Редактирование
                    {
                        query = @"UPDATE partners 
                          SET ""Name"" = @name, ""Type"" = @type, ""Rating"" = @rating, 
                              ""Address"" = @address, ""Director"" = @director, 
                              ""Phone"" = @phone, ""Email"" = @email, ""Inn"" = @inn
                          WHERE ""Id"" = @id";
                    }

                    else //Добавление
                    {
                        query = @"INSERT INTO partners
                          (""Name"", ""Type"", ""Rating"", ""Address"", ""Director"", ""Phone"", ""Email"", ""Inn"")
                          VALUES
                          (@name, @type, @rating, @address, @director, @phone, @email, @inn)";
                    }

                        using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@type", cmbType.Text);
                        cmd.Parameters.AddWithValue("@rating", rating);
                        cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@director", txtDirector.Text);
                        cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@inn", txtInn.Text);

                        if (partnerId > 0)
                        {
                            cmd.Parameters.AddWithValue("@id", partnerId); // Добавляем параметр для UPDATE
                        }

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Данные успешно сохранены.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
