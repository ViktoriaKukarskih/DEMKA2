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
    public partial class PartnerCard : UserControl
    {
        public int PartnerId { get; private set; }

        public PartnerCard(Partner partner)
        {
            InitializeComponent();
            PartnerId = partner.Id;

            lblTitle.Text = $"{partner.Type} | {partner.Name}";
            lblDirector.Text = partner.Director;
            lblPhone.Text = partner.Phone;
            lblRating.Text = $"Рейтинг: {partner.Rating}";
            lblDiscount.Text = $"{partner.Discount}%";

            this.Click += Card_Click;
            foreach (Control ctrl in this.Controls)
                ctrl.Click += Card_Click;
        }

        public event EventHandler<int> PartnerClicked;

        private void Card_Click(object sender, EventArgs e)
        {
            PartnerClicked?.Invoke(this, PartnerId);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            string partnerName = lblTitle.Text.Split('|').Last().Trim();

            var historyForm = new SalesHistoryForm(PartnerId, partnerName);
            historyForm.ShowDialog();
        }
    }

}
