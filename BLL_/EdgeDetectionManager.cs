﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class EdgeDetectionManager 
    {
        public Bitmap ChoiceEdge(IEdgeDetectionManager Edgename, Bitmap previewBitmap)
        {
            
            string Edgevalue = Edgename.GetEdgeDetectionName();
            Bitmap bitmapResult = previewBitmap;

            // Switch to find which Edge Detection we want to use
            switch (Edgevalue)
            {
                case "Laplacian 3x3":
                    bitmapResult = Laplacian3x3Filter(bitmapResult, false);
                    break;
                case "Laplacian 5x5":
                    bitmapResult = Laplacian5x5Filter(bitmapResult, false);
                    break;
                case "Laplacian of Gaussian":
                    bitmapResult = LaplacianOfGaussianFilter(bitmapResult);
                    break;
                default:
                    bitmapResult = previewBitmap;
                    break;
            }

            return bitmapResult;
        }

      
        public Bitmap CopyToSquareCanvas(Bitmap sourceBitmap, int canvasWidthLenght)
        {
            try
            {
                float ratio = 1.0f;
                int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                              sourceBitmap.Width : sourceBitmap.Height;

                ratio = (float)maxSide / (float)canvasWidthLenght;

                Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                        new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                        : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

                using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
                {
                    graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                    graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    graphicsResult.DrawImage(sourceBitmap,
                                            new Rectangle(0, 0,
                                                bitmapResult.Width, bitmapResult.Height),
                                            new Rectangle(0, 0,
                                                sourceBitmap.Width, sourceBitmap.Height),
                                                GraphicsUnit.Pixel);
                    graphicsResult.Flush();
                }

                return bitmapResult;
            }
            //If nothing picked by the user
            catch (Exception)
            {
                return null;
            }
        }

        private Bitmap ConvolutionFilter(Bitmap sourceBitmap,
                                             double[,] filterMatrix,
                                                  double factor = 1,
                                                       int bias = 0,
                                             bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        private Bitmap Laplacian3x3Filter(Bitmap sourceBitmap,
                                                    bool grayscale = true)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                    Matrix.Laplacian3x3, 1.0, 0, grayscale);

            return resultBitmap;
        }

        private Bitmap Laplacian5x5Filter(Bitmap sourceBitmap, bool grayscale = true)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                 Matrix.Laplacian5x5, 1.0, 0, grayscale);

            return resultBitmap;
        }


        private Bitmap LaplacianOfGaussianFilter(Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ConvolutionFilter(sourceBitmap,
                                  Matrix.LaplacianOfGaussian, 1.0, 0, true);

            return resultBitmap;
        }
    
}
}
