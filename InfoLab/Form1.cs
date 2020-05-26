using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using dllferramenta;
using Online;
using System.IO;

namespace InfoLab
{
    public partial class tbModId : MaterialForm
    {
        int num = default(int);
        funzioni.attrezzo[] eleAttrezzi = new funzioni.attrezzo[100];
        
        public tbModId()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.LightBlue600, Primary.LightBlue500, Primary.LightBlue400, Accent.LightBlue200, TextShade.WHITE);
            MaximizeBox = false;
        }
        private void tbModId_Load(object sender, EventArgs e)
        {
            bool completato = default(bool);
            bool salvato = false;
            funzioni.leggifile(eleAttrezzi, ref num, "archivio.txt");
            salvato = Database.salva(eleAttrezzi, num);
            if (salvato==true)
            {
                completato = Online.Database.carica(eleAttrezzi, ref num);
                if (completato == false)
                {
                    MessageBox.Show("Impossibile connettersi al server...caricamento da locale");
                    return;
                }
            }
            
        }
        private void btnAcq_Click(object sender, EventArgs e)
        {
            funzioni.attrezzo nuovoA = default(funzioni.attrezzo);

            if (string.IsNullOrEmpty(tbAcqId.Text) || string.IsNullOrEmpty(tbAcqCate.Text) || string.IsNullOrEmpty(tbAcqMarca.Text) || string.IsNullOrEmpty(tbAcqModello.Text) || string.IsNullOrEmpty(tbAcqPrezzo.Text) || string.IsNullOrEmpty(tbAcqQ.Text) || string.IsNullOrEmpty(tbAcqData.Text))
            {
                MessageBox.Show("Inserire tutt i dati");
                return;
            }
            try
            {
                nuovoA.codice = tbAcqId.Text;
                nuovoA.categoria = tbAcqCate.Text;
                nuovoA.marca = tbAcqMarca.Text;
                nuovoA.modello = tbAcqModello.Text;
                nuovoA.prezzo = decimal.Parse(tbAcqPrezzo.Text);
                nuovoA.quantità = int.Parse(tbAcqQ.Text);
                nuovoA.data = DateTime.Parse(tbAcqData.Text);
            }
            catch
            {
                MessageBox.Show("Dati non validi");
                return;
            }

            eleAttrezzi[num] = nuovoA;
            num += 1;

            tbAcqId.Clear();
            tbAcqCate.Clear();
            tbAcqMarca.Clear();
            tbAcqModello.Clear();
            tbAcqPrezzo.Clear();
            tbAcqQ.Clear();
            tbAcqData.Clear();

            MessageBox.Show("Prodotti inseriti con successo");
        }

        private void btnAggiorna1_Click(object sender, EventArgs e)
        {
            if (rbtnPrezzo.Checked == false && rbtnCate.Checked == false && rbtnId.Checked == false && rbtnQ.Checked == false)
            {
                MessageBox.Show("Selezionare un ordinamento");
                return;
            }

            int x = 0;

            if (rbtnId.Checked == true)
                funzioni.ordinacodice(eleAttrezzi, num);

            if (rbtnCate.Checked == true)
                funzioni.ordinacategoria(eleAttrezzi, num);

            if (rbtnPrezzo.Checked == true)
                funzioni.ordinaprezzo(eleAttrezzi, num);

            if (rbtnQ.Checked == true)
                funzioni.ordinaquantità(eleAttrezzi, num);

            ListViewItem riga = default(ListViewItem);
            lvVis.Items.Clear();
            x = 0;
            while (x < num)
            {
                riga = new ListViewItem(new string[]
                                {   eleAttrezzi[x].codice,
                                    eleAttrezzi[x].categoria,
                                    eleAttrezzi[x].marca,
                                    eleAttrezzi[x].modello,
                                    eleAttrezzi[x].prezzo.ToString(),
                                    eleAttrezzi[x].quantità.ToString(),
                                    eleAttrezzi[x].data.ToString()});
                lvVis.Items.Add(riga);
                x = x + 1;
            }
        }
        private void btnAggiorna2_Click(object sender, EventArgs e)
        {
            int x=default(int);
            ListViewItem riga = default(ListViewItem);
            lvVen.Items.Clear();
            x = 0;
            while (x < num)
            {
                riga = new ListViewItem(new string[]
                                {   eleAttrezzi[x].codice,
                                    eleAttrezzi[x].categoria,
                                    eleAttrezzi[x].modello,
                                    eleAttrezzi[x].prezzo.ToString()});
                lvVen.Items.Add(riga);
                x = x + 1;
            }
        }
        private void btnVenCerca_Click(object sender, EventArgs e)
        {
            int x = default(int);

            x = funzioni.ricerca(eleAttrezzi, num, tbVenId.Text);

            if(x<0)
            {
                MessageBox.Show("Attrezzo non trovato");
                return;
            }
            else
            {
                tbVenId.Text=eleAttrezzi[x].codice;
                tbVenCate.Text=eleAttrezzi[x].categoria;
                tbVenMarca.Text=eleAttrezzi[x].marca;
                tbVenModello.Text=eleAttrezzi[x].modello;
                tbVenPrezzo.Text=eleAttrezzi[x].prezzo.ToString();
                tbVenQ.Text=eleAttrezzi[x].quantità.ToString();
                tbVenData.Text=eleAttrezzi[x].data.ToString();
            }
        }
        private void btnVen_Click(object sender, EventArgs e)
        {
            int pos = default(int);
            pos=funzioni.cancellacodice(eleAttrezzi, ref num, tbVenId.Text, int.Parse(tbVenQdaVendere.Text));

            if(pos<0)
            {
                MessageBox.Show("Quantità troppo elevata");
                return;
            }
            else
            {
                tbVenId.Clear();
                tbVenCate.Clear();
                tbVenMarca.Clear();
                tbVenModello.Clear();
                tbVenPrezzo.Clear();
                tbVenQ.Clear();
                tbVenData.Clear();
                MessageBox.Show("Prodotto venduto con successo!");
                return;
            }
            
        }
        private void btnModCerca_Click(object sender, EventArgs e)
        {
            int x = default(int);

            x = funzioni.ricerca(eleAttrezzi, num, textBox7.Text);

            if (x < 0)
            {
                MessageBox.Show("Attrezzo non trovato");
                return;
            }
            else
            {
                textBox7.Text = eleAttrezzi[x].codice;
                tbModCate.Text = eleAttrezzi[x].categoria;
                tbModMarca.Text = eleAttrezzi[x].marca;
                tbModModello.Text = eleAttrezzi[x].modello;
                tbModPrezzo.Text = eleAttrezzi[x].prezzo.ToString();
                tbModQ.Text = eleAttrezzi[x].quantità.ToString();
                tbModData.Text = eleAttrezzi[x].data.ToString();
                textBox7.Enabled = false;
            }
        }
        private void btnMod_Click(object sender, EventArgs e)
        {
            int x = default(int);
            if (!string.IsNullOrEmpty(textBox7.Text))
                x = funzioni.ricerca(eleAttrezzi, num, textBox7.Text);
            else
            {
                MessageBox.Show("Impossibile modificare");
                return;
            }

            eleAttrezzi[x].categoria = tbModCate.Text;
            eleAttrezzi[x].marca = tbModMarca.Text;
            eleAttrezzi[x].modello = tbModModello.Text;
            eleAttrezzi[x].prezzo = decimal.Parse(tbModPrezzo.Text);
            eleAttrezzi[x].quantità = int.Parse(tbModQ.Text);
            eleAttrezzi[x].data = DateTime.Parse(tbModData.Text);

            MessageBox.Show("Prodotto modificato");

            textBox7.Clear();
            tbModCate.Clear();
            tbModMarca.Clear();
            tbModModello.Clear();
            tbModPrezzo.Clear();
            tbModQ.Clear();
            tbModData.Clear();

            textBox7.Enabled = true;
        }
        private void btnMax_Click(object sender, EventArgs e)
        {
            if (num == 0)
            {
                MessageBox.Show("Nessun prodotto presnete");
                return;
            }
            funzioni.attrezzo attrezzoMax = default(funzioni.attrezzo);

            attrezzoMax = funzioni.prezzomassimo(eleAttrezzi, num);

            lbMax.Text = $"Il prezzo max è di {attrezzoMax.prezzo} euro ed è del prodotto di codice {attrezzoMax.codice}";
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            if (num == 0)
            {
                MessageBox.Show("Nessun prodotto presnete");
                return;
            }
            funzioni.attrezzo attrezzoMin = default(funzioni.attrezzo);

            attrezzoMin = funzioni.prezzominimo(eleAttrezzi, num);

            lbMin.Text = $"Il prezzo min è di {attrezzoMin.prezzo} euro ed è del prodotto di codice {attrezzoMin.codice}";
        }
        private void btnMedio_Click(object sender, EventArgs e)
        {
            if(num==0)
            {
                MessageBox.Show("Nessun prodotto presnete");
                return;
            }
            decimal prezzomedio = default(decimal);
            prezzomedio = funzioni.mediaprezzi(eleAttrezzi, num);

            lbMed.Text = $"Il prezzo medio è {prezzomedio} euro";
        }
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            bool completato = default(bool);
            completato = Database.salva(eleAttrezzi, num);

            if(completato==false)
            {
                MessageBox.Show("Errore di collegamento con il server...");
                funzioni.scrivifile(eleAttrezzi, num, "archivio.txt");
            }
            else
            {
                MessageBox.Show("Salvataggio completato");
                return;
            }
        }
        private void tbModId_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool completato = default(bool);
            completato = Database.salva(eleAttrezzi, num);
            funzioni.scrivifile(eleAttrezzi, num, "archivio.txt");

            if (completato == false)
            {
                MessageBox.Show("Salvataggio completato in locale");
                return;
            }
            else
            {
                MessageBox.Show("Salvataggio completato online");
                return;
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
