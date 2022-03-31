using System.Collections;
using System.IO;
using System.Text;

namespace Kursach
{
    public partial class Steganography : Form
    {
        string src;

        public Steganography()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                src = ofd.FileName;
            }
            pbPicture.ImageLocation = src;
        }

        private void bEncode_Click(object sender, EventArgs e)
        {
            List<byte> bList = new List<byte>();
            Text = tbText.Text;

            foreach (char c in Text)
            {                                   //считали весь текстовый файл для шифрования в лист байт
                bList.Add(Convert.ToByte(c));
            }

            int CountText = bList.Count; // в CountText - количество в байтах текста, который нужно закодировать

            Bitmap bPic = new Bitmap(src);


            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                MessageBox.Show("Выбранная картинка мала для размещения выбранного текста", "Информация", MessageBoxButtons.OK);
                return;
            }

            //проверяем, может быть картинка уже зашифрована
            if (Cryption.isEncryption(bPic))
            {
                MessageBox.Show("Файл уже зашифрован", "Информация", MessageBoxButtons.OK);
                return;
            }

            //проверяем, поместиться ли исходный текст в картинке
            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                MessageBox.Show("Выбранная картинка мала для размещения выбранного текста", "Информация", MessageBoxButtons.OK);
                return;
            }

            Cryption.SetEncryption(bPic);
            Cryption.WriteCountText(CountText, bPic); //записываем количество символов исходного текста
            Cryption.Encrypt(bPic, bList);
        }

        private void bDecode_Click(object sender, EventArgs e)
        {
            Bitmap bPic = new Bitmap(src);
            if (!Cryption.isEncryption(bPic))
            {
                MessageBox.Show("В файле нет зашифрованной информации", "Информация", MessageBoxButtons.OK);
                return;
            }

            tbText.Text = Cryption.Decrypt(bPic);
        }
    }
}