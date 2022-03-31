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
            {                                   //������� ���� ��������� ���� ��� ���������� � ���� ����
                bList.Add(Convert.ToByte(c));
            }

            int CountText = bList.Count; // � CountText - ���������� � ������ ������, ������� ����� ������������

            Bitmap bPic = new Bitmap(src);


            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                MessageBox.Show("��������� �������� ���� ��� ���������� ���������� ������", "����������", MessageBoxButtons.OK);
                return;
            }

            //���������, ����� ���� �������� ��� �����������
            if (Cryption.isEncryption(bPic))
            {
                MessageBox.Show("���� ��� ����������", "����������", MessageBoxButtons.OK);
                return;
            }

            //���������, ����������� �� �������� ����� � ��������
            if (CountText > ((bPic.Width * bPic.Height)) - 4)
            {
                MessageBox.Show("��������� �������� ���� ��� ���������� ���������� ������", "����������", MessageBoxButtons.OK);
                return;
            }

            Cryption.SetEncryption(bPic);
            Cryption.WriteCountText(CountText, bPic); //���������� ���������� �������� ��������� ������
            Cryption.Encrypt(bPic, bList);
        }

        private void bDecode_Click(object sender, EventArgs e)
        {
            Bitmap bPic = new Bitmap(src);
            if (!Cryption.isEncryption(bPic))
            {
                MessageBox.Show("� ����� ��� ������������� ����������", "����������", MessageBoxButtons.OK);
                return;
            }

            tbText.Text = Cryption.Decrypt(bPic);
        }
    }
}