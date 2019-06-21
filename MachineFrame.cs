using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenCvSharp;

namespace ESMachineMonitorForm
{
    class FrameCorner
    {
        private List<Point2f> points;

        public FrameCorner()
        {
            points = new List<Point2f>();
        }

        public bool isUsabel()
        {
            return points.Count() >= 4;
        }

        public bool isEmpty()
        {
            return points.Count() <= 0;
        }

        public bool PopBack()
        {
            if (isEmpty())
                return false;
            points.Remove(points.Last());
            return true;
        }

        public bool PushBack(System.Drawing.Point point)
        {
            if (isUsabel())
                return false;
            points.Add(new Point(point.X, point.Y));
            return true;
        }

        public List<Point2f> GetPoints()
        {
            return points;
        }
    }
    class MachineFrame
    {
        private FrameCorner corners = new FrameCorner();
        private Mutex frameMutex = new Mutex();
        private Mat frameMat = null;
        private System.Drawing.Imaging.ColorPalette framePalette;
        private double frameScale = 1.0;
        private Size standardSize = new Size(0, 0);

        public System.Drawing.Bitmap frameCut(System.Drawing.Bitmap bitmap = null)
        {
            Mat frame;
            frameMutex.WaitOne();
            if (bitmap == null)
            {
                frame = frameMat.Clone();
            }
            else
            {
                frame = ConvertBitmapToMat(bitmap);
                frameMat = frame.Clone();
                framePalette = bitmap.Palette;
            }

            List<Point2f> points_userClicked = corners.GetPoints();
            if (corners.isUsabel())
            {
                // minRect
                RotatedRect minRect = Cv2.MinAreaRect(points_userClicked);
                List<Point2f> points_minRect = minRect.Points().ToList();

                // sort points
                for (int i = 0; i < 4; i++)
                {
                    double min_distance = Math.Sqrt(frame.Width * frame.Width + frame.Height * frame.Height);
                    for (int j = i; j < 4; j++)
                    {
                        double distance_tmp = points_minRect[j].DistanceTo(points_userClicked[i]);
                        if (distance_tmp < min_distance)
                        {
                            min_distance = distance_tmp;
                            var tmpPoint = points_minRect[i];
                            points_minRect[i] = points_minRect[j];
                            points_minRect[j] = tmpPoint;
                        }
                    }
                }
                //calc correct mat
                Mat warpMatrix = Cv2.GetPerspectiveTransform(points_userClicked, points_minRect);

                //correct img
                Cv2.WarpPerspective(frame, frame, warpMatrix, frame.Size());

                //calc rotate mat
                double angle = minRect.Angle;
                Size size = new Size(minRect.Size.Width, minRect.Size.Height);
                if (angle < -45.0)
                {
                    angle += 90.0;
                    var tmp = size.Width;
                    size.Width = size.Height;
                    size.Height = tmp;
                }
                Mat rotateMatrix = Cv2.GetRotationMatrix2D(minRect.Center, angle, 1.0);

                //rotate img
                Cv2.WarpAffine(frame, frame, rotateMatrix, frame.Size(), InterpolationFlags.Cubic);
                Cv2.GetRectSubPix(frame, size, minRect.Center, frame);
            }
            else
            {
                // draw points & lines
                for (int i = 0; i < points_userClicked.Count(); i++)
                {
                    //draw points
                    Cv2.Circle(frame, points_userClicked[i], (int)(5 * frameScale), new Scalar(189, 73, 17), (int)(5 * frameScale));
                    //draw lines
                    if (i < points_userClicked.Count() - 1)
                        Cv2.Line(frame, points_userClicked[i], points_userClicked[i + 1], new Scalar(232, 162, 0), (int)(5 * frameScale));
                }
            }

            if (standardSize.Height == 0 || standardSize.Width == 0 || !corners.isUsabel())
                Cv2.Resize(frame, frame, new Size((int)(frame.Width * frameScale) / 4 * 4, (int)(frame.Height * frameScale)));
            else
                Cv2.Resize(frame, frame, standardSize);

            System.Drawing.Bitmap bmpImgRet = ConvertMatToBitmap(frame);
            if (frame.Channels() == 1)
            {
                if (bitmap == null)
                    bmpImgRet.Palette = framePalette;//copy palette
                else
                    bmpImgRet.Palette = bitmap.Palette;//copy palette
            }

            frameMutex.ReleaseMutex();
            return bmpImgRet;
        }

        public void addPoint(System.Drawing.Point point)
        {
            frameMutex.WaitOne();
            point.X = (int)(Convert.ToDouble(point.X) / frameScale);
            point.Y = (int)(Convert.ToDouble(point.Y) / frameScale);
            corners.PushBack(point);
            frameMutex.ReleaseMutex();
        }

        public void delPoint()
        {
            frameMutex.WaitOne();
            corners.PopBack();
            frameMutex.ReleaseMutex();
        }

        public bool isPointUsabel()
        {
            return corners.isUsabel();
        }

        public void setScale(double scale)
        {
            frameMutex.WaitOne();
            if (scale < 0.1)
                scale = 0.1;
            else if (scale > 10)
                scale = 10;
            frameScale = scale;
            frameMutex.ReleaseMutex();
        }

        public double getScale()
        {
            return frameScale;
        }

        public void setStandardSize(System.Drawing.Size size)
        {
            standardSize.Width = size.Width;
            standardSize.Height = size.Height;
        }

        public System.Drawing.Bitmap getPreFrame()
        {
            frameMutex.WaitOne();
            if (frameMat == null)
                return null;
            frameMutex.ReleaseMutex();
            return frameCut();
        }

        private System.Drawing.Bitmap ConvertMatToBitmap(Mat cvImg)
        {
            System.Drawing.Bitmap bmpImg;

            //检查图像位深  
            if (cvImg.Depth() != MatType.CV_8U)
            {
                return null;
            }

            //彩色图像  
            if (cvImg.Channels() == 3)
            {
                bmpImg = new System.Drawing.Bitmap(
                    cvImg.Cols,
                    cvImg.Rows,
                    (int)cvImg.Step(),
                    System.Drawing.Imaging.PixelFormat.Format24bppRgb,
                    cvImg.Data);
                return bmpImg;
            }
            //灰度图像  
            else if (cvImg.Channels() == 1)
            {
                bmpImg = new System.Drawing.Bitmap(
                    cvImg.Cols,
                    cvImg.Rows,
                    (int)cvImg.Step(),
                    System.Drawing.Imaging.PixelFormat.Format8bppIndexed,
                    cvImg.Data);
                return bmpImg;
            }

            return null;
        }

        private Mat ConvertBitmapToMat(System.Drawing.Bitmap bmpImg)
        {
            Mat cvImg = null;
            //锁定Bitmap数据  
            System.Drawing.Imaging.BitmapData bmpData = bmpImg.LockBits(
                new System.Drawing.Rectangle(0, 0, bmpImg.Width, bmpImg.Height),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bmpImg.PixelFormat);

            //将 bmpImg 的数据指针复制到 cvImg 中，不拷贝数据  
            if (bmpImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)  // 灰度图像  
            {
                cvImg = new Mat(bmpImg.Height, bmpImg.Width, MatType.CV_8UC1, bmpData.Scan0);
            }
            else if (bmpImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format24bppRgb)   // 彩色图像  
            {
                cvImg = new Mat(bmpImg.Height, bmpImg.Width, MatType.CV_8UC3, bmpData.Scan0);
            }

            //解锁Bitmap数据  
            bmpImg.UnlockBits(bmpData);
            return cvImg;
        }
    }
}
