using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMKA
{
    public partial class SalesHistoryCard : UserControl
    {
        public SalesHistoryCard(SalesHistory history)
        {
            InitializeComponent();

            lblProduct.Text = history.ProductName;
            lblQuantity.Text = $"Количество: {history.Quantity}";
            lblDate.Text = $"Дата продажи: {history.SaleDate:dd.MM.yyyy}";
        }
    }
}
