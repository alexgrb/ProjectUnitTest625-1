using BLL_;
using DTO_;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectionFilterForm
{
    public partial class Form1 : Form
    {
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap result = null;
        private IFilterManager filterName = new FilterName();
        private IEdgeDetectionManager edgeDetectionName = new EdgeName();
        private FilterManager filtersManagement = new FilterManager();
        private EdgeDetectionManager edgeDetectionManagement = new EdgeDetectionManager();


        public Form1()
        {
            InitializeComponent();
            

         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

   

        private void button1_Click_1(object sender, EventArgs e)
        {
            ImageIO io = new ImageIO();

            //load the image
            originalBitmap = io.readFile();
            previewBitmap = originalBitmap;

            picPreview.Image = originalBitmap;

        }



        private void ApplyFilter(bool preview)
        {
            if (previewBitmap == null)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                //Checks the name of the filter
                if (filterName.GetFilterName() == "None")
                {
                    bitmapResult = originalBitmap;
                }
                //Checks the name of the filter
                else if (filterName.GetFilterName() == "BlackNWhite")
                {
                    //Apply to the bitmap the result of the BlackAndWhite filter
                    bitmapResult = filtersManagement.filterChoice(filterName, selectedSource);

                }
                //Checks the name of the filter
                else if (filterName.GetFilterName() == "Swap")
                {
                    //Apply to the bitmap the result of the Swap filter
                    bitmapResult = filtersManagement.filterChoice(filterName, selectedSource);
                }

                else if (filterName.GetFilterName() == "Mega Pink")
                {
                    //Apply to the bitmap the result of the Mega pink filter
                    bitmapResult = filtersManagement.filterChoice(filterName, selectedSource);
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                }
                else
                {
                    result = bitmapResult;
                }
            }

        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            filterName.SetFilterName("None");
            ApplyFilter(true);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            filterName.SetFilterName("BlackNWhite");
            ApplyFilter(true);
        }

        private void btnNightFilter_Click(object sender, EventArgs e)
        {
            filterName.SetFilterName("Swap");
            ApplyFilter(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            filterName.SetFilterName("Mega Pink");
            ApplyFilter(true);
        }


        private void btnSaveNewImage_Click(object sender, EventArgs e)
        {

            ImageIO io = new ImageIO();


            ApplyFilter(false);
            ApplyEdgeDetection(false);
            //save the image
            io.writeFile(result);
        }

    

        private void ApplyEdgeDetection(bool preview)
        {
            if (previewBitmap == null)
            {
                return;
            }

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (preview == true)
            {
                selectedSource = previewBitmap;
            }
            else
            {
                selectedSource = originalBitmap;
            }

            if (selectedSource != null)
            {
                //Checks the name of the EdgeDetection
                if (edgeDetectionName.GetEdgeDetectionName() == "None")
                {
                    bitmapResult = originalBitmap;
                }
                //Checks the name of the EdgeDetection
                else if (edgeDetectionName.GetEdgeDetectionName() == "Laplacian 3x3")
                {
                    //Apply to the bitmap the result of the Laplacian 3x3 Detection
                    bitmapResult = edgeDetectionManagement.ChoiceEdge(edgeDetectionName, selectedSource);

                }
                //Checks the name of the EdgeDetection
                else if (edgeDetectionName.GetEdgeDetectionName() == "Laplacian 5x5")
                {
                    //Apply to the bitmap the result of the Laplacian Laplacian 5x5
                    bitmapResult = edgeDetectionManagement.ChoiceEdge(edgeDetectionName, selectedSource);
                }
                //Checks the name of the EdgeDetection
                else if (edgeDetectionName.GetEdgeDetectionName() == "Laplacian of Gaussian")
                {
                    //Apply to the bitmap the result of  the Laplacian Laplacian of Gaussian
                    bitmapResult = edgeDetectionManagement.ChoiceEdge(edgeDetectionName, selectedSource);
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    picPreview.Image = bitmapResult;
                }
                else
                {
                    result = bitmapResult;
                }
            }
        }

        private void Laplacian3x3_Click(object sender, EventArgs e)
        {
            edgeDetectionName.SetEdgeDetectionName("Laplacian 3x3");
            ApplyEdgeDetection(true);
        }

        private void Laplacian5x5_Click(object sender, EventArgs e)
        {
            edgeDetectionName.SetEdgeDetectionName("Laplacian 5x5");
            ApplyEdgeDetection(true);
        }

        private void LaplacianGaussian_Click(object sender, EventArgs e)
        {
            edgeDetectionName.SetEdgeDetectionName("Laplacian of Gaussian");
            ApplyEdgeDetection(true);
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            edgeDetectionName.SetEdgeDetectionName("None");
            ApplyEdgeDetection(true);
        }

    
    }
}
