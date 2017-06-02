using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.ML;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace KNN
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {

        }

        // module level variables ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        const int RESIZED_IMAGE_WIDTH = 20;

        const int RESIZED_IMAGE_HEIGHT = 30;

        //const int RESIZED_IMAGE_HEIGHT = 30;
        ///''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        private void btnOpenTestImage_Click(object sender, EventArgs e)
        {
            //note: we effectively have to read the first XML file twice
            //first, we read the file to get the number of rows (which is the same as the number of samples)
            //the first time reading the file we can't get the data yet, since we don't know how many rows of data there are
            //next, reinstantiate our classifications Matrix and training images Matrix with the correct number of rows
            //then, read the file again and this time read the data into our resized classifications Matrix and training images Matrix


            Matrix<float> mtxClassifications = new Matrix<float>(1, 1);
            //for the first time through, declare these to be 1 row by 1 column
            Matrix<float> mtxTrainingImages = new Matrix<float>(1, 1);
            //we will resize these when we know the number of rows (i.e. number of training samples)

           
            XmlSerializer xmlSerializer = new XmlSerializer(mtxClassifications.GetType());
            //these variables are for
            StreamReader streamReader = default(StreamReader);
            //reading from the XML files

            try
            {
                streamReader = new StreamReader("classifications.xml");
                //attempt to open classifications file
                //if error is encountered, show error and return
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(Environment.NewLine + "unable to open 'classifications.xml', error: ");
                txtInfo.AppendText(ex.Message + Environment.NewLine);
                return;
            }
            //read from the classifications file the 1st time, this is only to get the number of rows, not the actual data
            mtxClassifications = (Matrix<float>)xmlSerializer.Deserialize(streamReader);

            streamReader.Close();
            //close the classifications XML file

            int intNumberOfTrainingSamples = mtxClassifications.Rows;
            //get the number of rows, i.e. the number of training samples

            //now that we know the number of rows, reinstantiate classifications Matrix and training images Matrix with the actual number of rows
            mtxClassifications = new Matrix<float>(intNumberOfTrainingSamples, 1);
            mtxTrainingImages = new Matrix<float>(intNumberOfTrainingSamples, RESIZED_IMAGE_WIDTH * RESIZED_IMAGE_HEIGHT);

            try
            {
                streamReader = new StreamReader("classifications.xml");
                //reinitialize the stream reader, attempt to open classifications file again
                //if error is encountered, show error and return
            }
            catch (Exception ex)
            {
                txtInfo.AppendText(Environment.NewLine + "unable to open 'classifications.xml', error:" + Environment.NewLine);
                txtInfo.AppendText(ex.Message + Environment.NewLine + Environment.NewLine);
                return;
            }
            //read from the classifications file again, this time we can get the actual data
            mtxClassifications = (Matrix<float>)xmlSerializer.Deserialize(streamReader);

            streamReader.Close();
            //close the classifications XML file


            xmlSerializer = new XmlSerializer(mtxTrainingImages.GetType());
            //reinstantiate file reading variable

            try
            {
                streamReader = new StreamReader("images.xml");
                //attempt to open classifications file
                //if error is encountered, show error and return
            }
            catch (Exception ex)
            {
                txtInfo.AppendText("unable to open 'images.xml', error:" + Environment.NewLine);
                txtInfo.AppendText(ex.Message + Environment.NewLine + Environment.NewLine);
            }

            mtxTrainingImages = (Matrix<float>)xmlSerializer.Deserialize(streamReader);
            //read from training images file
            streamReader.Close();
            //close the training images XML file






            // train '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            KNearest kNearest = new KNearest();


            kNearest.DefaultK = 1;



            kNearest.Train(mtxTrainingImages, Emgu.CV.ML.MlEnum.DataLayoutType.RowSample, mtxClassifications);


            // test '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            DialogResult drChosenFile = default(DialogResult);



            drChosenFile = ofdOpenFile.ShowDialog();
            //open file dialog


            if ((drChosenFile != DialogResult.OK | string.IsNullOrEmpty(ofdOpenFile.FileName)))
            {
                lblChosenFile.Text = "file not chosen";
                //show error message on label
                return;
            }


            Mat imgTestingNumbers = default(Mat);
            //declare the input image







            try
            {
                imgTestingNumbers = CvInvoke.Imread(ofdOpenFile.FileName, LoadImageType.Color);
                //open image
                //if error occurred
            }
            catch (Exception ex)
            {
                lblChosenFile.Text = "unable to open image, error: " + ex.Message;
                //show error message on label
                return;
                //and exit function
            }




            //if image could not be opened
            if ((imgTestingNumbers == null))
            {
                lblChosenFile.Text = "unable to open image";
                //show error message on label
                return;
                //and exit function
            }


            if ((imgTestingNumbers.IsEmpty))
            {
                lblChosenFile.Text = "unable to open image";
                return;
            }


            lblChosenFile.Text = ofdOpenFile.FileName;
            //update label with file name


            Mat imgGrayscale = new Mat();
            //
            Mat imgBlurred = new Mat();
            //declare various images
            Mat imgThresh = new Mat();
            //
            Mat imgThreshCopy = new Mat();
            //




            CvInvoke.CvtColor(imgTestingNumbers, imgGrayscale, ColorConversion.Bgr2Gray);
            //convert to grayscale




            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(5, 5), 0);
            //blur


            //threshold image from grayscale to black and white
            CvInvoke.AdaptiveThreshold(imgBlurred, imgThresh, 255.0, AdaptiveThresholdType.GaussianC, ThresholdType.BinaryInv, 11, 2.0);





            imgThreshCopy = imgThresh.Clone();
            //make a copy of the thresh image, this in necessary b/c findContours modifies the image


            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();













            //get external countours only
            CvInvoke.FindContours(imgThreshCopy, contours, null, RetrType.External, ChainApproxMethod.ChainApproxSimple);







            List<ContourWithData> listOfContoursWithData = new List<ContourWithData>();
            //declare a list of contours with data

            //populate list of contours with data
            //for each contour
            for (int i = 0; i <= contours.Size - 1; i++)
            {
                ContourWithData contourWithData = new ContourWithData();
                //declare new contour with data
                contourWithData.contour = contours[i];
                //populate contour member variable
                contourWithData.boundingRect = CvInvoke.BoundingRectangle(contourWithData.contour);
                //calculate bounding rectangle
                contourWithData.dblArea = CvInvoke.ContourArea(contourWithData.contour);
                //calculate area
                //if contour with data is valis
                if ((contourWithData.CheckIfContourIsValid()))
                {
                    listOfContoursWithData.Add(contourWithData);
                    //add to list of contours with data
                }
            }
            //sort contours with data from left to right
            listOfContoursWithData.Sort((oneContourWithData, otherContourWithData) => oneContourWithData.boundingRect.X.CompareTo(otherContourWithData.boundingRect.X));


            string strFinalString = "";
            //declare final string, this will have the final number sequence by the end of the program


            //for each contour in list of valid contours
            foreach (ContourWithData contourWithData in listOfContoursWithData)
            {



                CvInvoke.Rectangle(imgTestingNumbers, contourWithData.boundingRect, new MCvScalar(0.0, 255.0, 0.0), 2);
                //draw green rect around the current char








                Mat imgROItoBeCloned = new Mat(imgThresh, contourWithData.boundingRect);
                //get ROI image of bounding rect



                Mat imgROI = imgROItoBeCloned.Clone();
                //clone ROI image so we don't change original when we resize


                Mat imgROIResized = new Mat();


                //resize image, this is necessary for char recognition
                CvInvoke.Resize(imgROI, imgROIResized, new Size(RESIZED_IMAGE_WIDTH, RESIZED_IMAGE_HEIGHT));








                //declare a Matrix of the same dimensions as the Image we are adding to the data structure of training images
                Matrix<float> mtxTemp = new Matrix<float>(imgROIResized.Size);



                //declare a flattened (only 1 row) matrix of the same total size
                Matrix<float> mtxTempReshaped = new Matrix<float>(1, RESIZED_IMAGE_WIDTH * RESIZED_IMAGE_HEIGHT);


                imgROIResized.ConvertTo(mtxTemp, DepthType.Cv32F);
                //convert Image to a Matrix of Singles with the same dimensions



                //flatten Matrix into one row by RESIZED_IMAGE_WIDTH * RESIZED_IMAGE_HEIGHT number of columns
                for (int intRow = 0; intRow <= RESIZED_IMAGE_HEIGHT - 1; intRow++)
                {
                    for (int intCol = 0; intCol <= RESIZED_IMAGE_WIDTH - 1; intCol++)
                    {
                        mtxTempReshaped[0, (intRow * RESIZED_IMAGE_WIDTH) + intCol] = mtxTemp[intRow, intCol];
                    }
                }

                float sngCurrentChar = 0;

                sngCurrentChar = kNearest.Predict(mtxTempReshaped);
                //finally we can call Predict !!!

                strFinalString = strFinalString + (char)sngCurrentChar;
                //append current char to full string of chars

            }

            txtInfo.AppendText(Environment.NewLine + Environment.NewLine + "characters read from image = " + strFinalString + Environment.NewLine);

            CvInvoke.Imshow("imgTestingNumbers", imgTestingNumbers);
        }
    }
}
