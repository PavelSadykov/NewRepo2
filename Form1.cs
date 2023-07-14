using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsIMAGESresizeAPP
{
    public partial class MainForm : Form
    {
        private ManageForm manageForm;
        public MainForm()
        {
            InitializeComponent();
            

        }
       
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
          
            CreateManageForm(pictureBox1);
           

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            CreateManageForm(pictureBox2);
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
           
            CreateManageForm(pictureBox3);
        }



        
        private void CreateManageForm(PictureBox pictureBox)
        {

            if (manageForm == null || manageForm.IsDisposed)
            {
                manageForm = new ManageForm();
            }

           
            manageForm.SetSelectedPictureBox(pictureBox); 
            manageForm.Show();
        }


        

    }


}
