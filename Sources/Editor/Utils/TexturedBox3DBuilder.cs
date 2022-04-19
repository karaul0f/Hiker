using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using HikerEditor.Utils.Extensions;


namespace HikerEditor.Utils
{

    public static class TexturedBox3DBuilder
    {
        public static GeometryModel3D Create(double x, double y, double z, String pathToImage, Size size, float axisX = 0, double angle = 0, float axisY = 0, float axisZ = 1)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Проставляем вершины квадрату
            mesh.Positions = new Point3DCollection(new List<Point3D>
            {
                new Point3D(-size.Width/2, -size.Height/2, 0),
                new Point3D(size.Width/2, -size.Height/2, 0),
                new Point3D(size.Width/2, size.Height/2, 0),
                new Point3D(-size.Width/2, size.Height/2, 0)
            });

            // Указываем индексы для квадрата
            mesh.TriangleIndices = new Int32Collection(new List<int> { 0, 1, 2, 0, 2, 3 });
            mesh.TextureCoordinates = new PointCollection();

            // Устанавливаем текстурные координаты чтоб потом могли натянуть текстуру
            mesh.TextureCoordinates.Add(new Point(0, 1));
            mesh.TextureCoordinates.Add(new Point(1, 1));
            mesh.TextureCoordinates.Add(new Point(1, 0));
            mesh.TextureCoordinates.Add(new Point(0, 0));

            // Натягиваем текстуру
            BitmapImage image = CreateBitmapFromImage(pathToImage);
            ImageBrush brush = new ImageBrush(image);
            Material material = new DiffuseMaterial(brush);

            GeometryModel3D model = new GeometryModel3D(mesh, material);
            model.Move(new Vector3D(x, y, z));
            model.Rotate(new Vector3D(axisX, axisY, axisZ), angle);
            return new GeometryModel3D(mesh, material);
        }

        private static BitmapImage CreateBitmapFromImage(String pathToImage)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(pathToImage, UriKind.Relative);
            image.EndInit();

            return image;
        }
    }
}
