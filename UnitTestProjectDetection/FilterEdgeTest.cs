using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using BLL_;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTestProjectDetection
{
    [TestClass]
    public class FilterEdgeTest
    {
        Bitmap bitmap = new Bitmap(UnitTestProjectDetection.Properties.Resource.penguin);

        [TestMethod]
        public void TestBlackAndWhiteFilter()
        {

            var filter = Substitute.For<IFilterManager>();

            FilterManager filtersManagement = new FilterManager();

            //Load two bitmaps that are stored in the project
            
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testblack);

            //Force the use of the BlackAndWhite filter
            filter.GetFilterName().Returns("BlackNWhite");
            bitmap = filtersManagement.filterChoice(filter, bitmap);

            TestPixels(bitmap, bitmapResult);
        }

        [TestMethod]
        public void SwapFilter()
        {

            var filter = Substitute.For<IFilterManager>();

            FilterManager filtersManagement = new FilterManager();

            //Load two bitmaps that are stored in the project
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testSwap);

            //Force the use of the Swap filter
            filter.GetFilterName().Returns("Swap");
            bitmap = filtersManagement.filterChoice(filter, bitmap);

            TestPixels(bitmap, bitmapResult);
        }

        [TestMethod]
        public void FilterMega()
        {

            var filter = Substitute.For<IFilterManager>();

            FilterManager filtersManagement = new FilterManager();

            //Load two bitmaps that are stored in the project
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testMegaPink);

            //Force the use of the Mega Pink filter
            filter.GetFilterName().Returns("Mega Pink");
            bitmap = filtersManagement.filterChoice(filter, bitmap);

            TestPixels(bitmap, bitmapResult);
        }

        [TestMethod]
        public void Laplacian3x3Edge()
        {

            var edge = Substitute.For<IEdgeDetectionManager>();

            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            //Load two bitmaps that are stored in the project
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testLaplacian3);

            //Force the use of the Laplacian 3x3 edge detection
            edge.GetEdgeDetectionName().Returns("Laplacian 3x3");
            bitmap = edgeDetectionManager.ChoiceEdge(edge, bitmap);

            TestPixels(bitmap, bitmapResult);
        }

        [TestMethod]
        public void Laplacian5x5Edge()
        {

            var edge = Substitute.For<IEdgeDetectionManager>();

            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            //Load two bitmaps that are stored in the project
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testLaplacian5);

            //Force the use of the Laplacian 5x5 edge detection
            edge.GetEdgeDetectionName().Returns("Laplacian 5x5");
            bitmap = edgeDetectionManager.ChoiceEdge(edge, bitmap);

            TestPixels(bitmap, bitmapResult);
        }


        [TestMethod]
        public void LaplacianOfGaussianEdge()
        {

            var edge = Substitute.For<IEdgeDetectionManager>();

            EdgeDetectionManager edgeDetectionManager = new EdgeDetectionManager();

            //Load two bitmaps that are stored in the project
            Bitmap bitmapResult = new Bitmap(UnitTestProjectDetection.Properties.Resource.testLaplacianGaussian);

            //Force the use of the Laplacian Laplacian of Gaussian edge detection
            edge.GetEdgeDetectionName().Returns("Laplacian of Gaussian");
            bitmap = edgeDetectionManager.ChoiceEdge(edge, bitmap);

            TestPixels(bitmap, bitmapResult);
        }





        private static void TestPixels(Bitmap bitmap, Bitmap bitmapResult)
        {
            //loop that take every pixel
            for (int i = 0; i < bitmapResult.Width; i++)
            {
                //loop that take every pixel
                for (int j = 0; j < bitmapResult.Height; j++)
                {
                    Color colorFromFile = bitmapResult.GetPixel(i, j);
                    Color colorToTest = bitmap.GetPixel(i, j);

                    //Compares the pixels and throw a fail if they are differents
                    if (colorFromFile != colorToTest)
                    {
                        Assert.Fail();
                    }
                }
            }
        }
    }
}
