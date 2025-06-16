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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var partners = Db.GetPartners();
            foreach (var partner in partners)
            {
                var card = new PartnerCard(partner);
                card.PartnerClicked += Card_PartnerClicked;
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void Card_PartnerClicked(object sender, int partnerId)
        {
            var editform = new EditPartnerForm(partnerId);
            if (editform.ShowDialog() == DialogResult.OK)
            {
                MainForm_Load(null, null);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new EditPartnerForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                MainForm_Load(null, null); // Обновить список
            }
        }

       
    }
}


