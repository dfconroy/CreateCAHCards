using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CreateCAH
{
    class Program
    {
   
       
        static void MakeWhitecards()
        {
            int counter = 0;
            string line;

            PointF firstLocation = new PointF(400f, 500f);

            string imageFilePath = "custom-white.png";
            Bitmap bitmapLoad = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            RectangleF drawRect = new RectangleF(400f, 500f, 2500f, 2500f);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;

            System.IO.StreamReader file =
            new System.IO.StreamReader("white.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                using (Bitmap bitmap = (Bitmap)bitmapLoad.Clone())
                {


                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font arialFont = new Font("Helvetica", 13, FontStyle.Bold))
                        {
                            graphics.DrawString(line, arialFont, Brushes.Black, drawRect, sf);

                        }
                    }

                    bitmap.Save("white" + counter + ".png");//save the image file
                }
                counter++;
            }

            file.Close();
        }
        static void MakeBlackcards()
        {
            int counter = 0;
            string line;

            PointF firstLocation = new PointF(400f, 500f);

            string imageFilePath = "custom-black.png";
            Bitmap bitmapLoad = (Bitmap)Image.FromFile(imageFilePath);//load the image file
            RectangleF drawRect = new RectangleF(400f, 500f, 2500f, 2500f);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Near;
            sf.Alignment = StringAlignment.Near;

            System.IO.StreamReader file =
            new System.IO.StreamReader("black.txt");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                using (Bitmap bitmap = (Bitmap)bitmapLoad.Clone())
                {
                    line = line.Replace("_,", Environment.NewLine + "______________," + Environment.NewLine);
                    line = line.Replace(" _.", Environment.NewLine + "______________." + Environment.NewLine);
                    line = line.Replace(" _\".", Environment.NewLine + "______________\"." + Environment.NewLine);
                    line = line.Replace(" _\"", Environment.NewLine + "______________\"" + Environment.NewLine);
                    line = line.Replace("\"_", Environment.NewLine + "\"______________" + Environment.NewLine);
                    line = line.Replace(" _ ", Environment.NewLine + "______________" + Environment.NewLine);
                    line = line.Replace(" _!", Environment.NewLine + "______________!" + Environment.NewLine);
                    line = line.Replace("_??", Environment.NewLine + "______________??" + Environment.NewLine);
                    line = line.Replace(" _", Environment.NewLine + "______________" + Environment.NewLine);

                    if (line.Substring(0, 2) == "_ ")
                    {
                        line = line.Replace("_ ", Environment.NewLine + "______________" + Environment.NewLine);
                    }


                    //   line = line.Replace("_", Environment.NewLine + "______________" + Environment.NewLine);


                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        using (Font arialFont = new Font("Helvetica", 13, FontStyle.Bold))
                        {
                            graphics.DrawString(line, arialFont, Brushes.White, drawRect, sf);

                        }
                    }

                    bitmap.Save("black" + counter + ".png");//save the image file
                }
                counter++;
            }

            file.Close();
        }

    
        static void Main(string[] args)
        {

            MakeWhitecards();
            MakeBlackcards();   
        }
    }
}
