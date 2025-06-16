using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace DEMKA
{
    public partial class SalesHistoryForm : Form
    {
        private int _partnerId;
        private string _partnerName;

        public SalesHistoryForm(int partnerId, string partnerName)
        {
            InitializeComponent();
            _partnerId = partnerId;
            _partnerName = partnerName;

            Text = $"История продаж - {_partnerName} (ID: {_partnerId})";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SalesHistoryForm_Load(object sender, EventArgs e)
        {
            LoadSalesHistory();
        }

        private void LoadSalesHistory()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                var historyItems = GetSalesHistory(_partnerId);

                if (!historyItems.Any())
                {
                    MessageBox.Show("Нет данных о реализации продукции", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            
                foreach (var item in historyItems)
                {
                    var card = new SalesHistoryCard(item);
                    flowLayoutPanel1.Controls.Add(card);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки истории: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<SalesHistory> GetSalesHistory(int partnerId)
        {
            var history = new List<SalesHistory>();

            using (var conn = new NpgsqlConnection(Db.ConnectionString))
            {
                conn.Open();

                string query = @"
                SELECT pp.parthnerproductsid, pn.productname, pp.quantity, pp.saledate
                FROM parthnerproducts pp
                JOIN productname pn ON pp.productnameid = pn.productnameid
                WHERE pp.partnerid = @partnerId
                ORDER BY pp.saledate DESC";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@partnerId", partnerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            history.Add(new SalesHistory
                            {
                                ParthnerProductsId = reader.GetInt32(0),
                                ProductName = reader.GetString(1),
                                Quantity = reader.GetInt32(2),
                                SaleDate = reader.GetDateTime(3)
                            });
                        }
                    }
                }
            }

            return history;
        }
    }
}
