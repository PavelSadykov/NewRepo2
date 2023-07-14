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
    public partial class ManageForm : Form
    {
       
      
        private PictureBox selectedPictureBox; // Переменная для хранения выбранного PictureBox
        private Size originalSize; // Переменная для хранения изначального размера картинки
        private ManageOperation operation; // Переменная для хранения типа операции
        private Point originalLocation;//Переменная для хранения изначальной позиции картинки

        public ManageForm()
        {
            InitializeComponent();
            
    }
       
        private void ManageForm_Load(object sender, EventArgs e)
        {
            
            vScrollBar2.Minimum = 0;
            vScrollBar2.Maximum = 220;
            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = 220;
            
        }

        public void SetSelectedPictureBox(object sender)
        {
          
            selectedPictureBox = (PictureBox)sender;
            selectedPictureBox.BorderStyle = BorderStyle.Fixed3D;
            originalSize = selectedPictureBox.Image.Size;
            originalLocation = selectedPictureBox.Location;
            GetPictureBoxPosition( selectedPictureBox );
        }
        

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            operation = ManageOperation.Resize;

            if (selectedPictureBox != null && operation == ManageOperation.Resize)
            {
                UpdatePictureBoxSize(); 
            }
        }
       
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            operation = ManageOperation.Move;
            if (selectedPictureBox != null && operation == ManageOperation.Move)  
            {
                UpdatePictureBoxPosition(selectedPictureBox);

                
            }
        }
        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            operation = ManageOperation.Move;

            if (selectedPictureBox != null && operation == ManageOperation.Move )
            {
                UpdatePictureBoxPosition(selectedPictureBox);
            }
        }


        private void UpdatePictureBoxSize()
        {
            
                int delta = vScrollBar1.Value; // Значение прокрутки
                float scaleFactor = delta / 100f; // Изменение масштаба на основе приращения прокрутки

                int newWidth = (int)(originalSize.Width * scaleFactor);
                int newHeight = (int)(originalSize.Height * scaleFactor);

                selectedPictureBox.Size = new Size(newWidth, newHeight); // Устанавливаем новый размер выбранной картинки
            
        }

        private void   UpdatePictureBoxPosition(PictureBox pictureBox)
        {
            
            int deltaX = hScrollBar1.Value ;
            int deltaY = vScrollBar2.Value ;
          
           

            selectedPictureBox.Location = new Point(selectedPictureBox.Location.X + deltaX,
             vScrollBar2.Value );

            selectedPictureBox.Location = new Point(selectedPictureBox.Location.Y + deltaY,
               hScrollBar1.Value);
           

        }

        public void GetPictureBoxPosition(PictureBox pictureBox)
        {
            int x = pictureBox.Location.X;
            int y = pictureBox.Location.Y;

           
            
            MessageBox.Show($"Позиция PictureBox: X = {x}, Y = {y}");
        }

    }
    public enum ManageOperation
    {
        Resize,
        Move
        
    }


    
}





