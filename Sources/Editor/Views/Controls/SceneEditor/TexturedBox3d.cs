using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;


namespace HikerEditor.Views.Controls
{
	public class TexturedBox3D
	{
		/// <summary>
		/// Позиция визуальной сущности
		/// </summary>
		public Vector3D Position 
        {
            get => new Vector3D(_translateTransform.OffsetX, _translateTransform.OffsetY, _translateTransform.OffsetZ);
            set
            {
                _translateTransform = new TranslateTransform3D();
                _translateTransform.OffsetX = value.X;
                _translateTransform.OffsetY = value.Y;
                _translateTransform.OffsetZ = value.Z;
			}
        }

		/// <summary>
		/// Размеры визуальной сущности
		/// </summary>
		public Size Size { get; set; }

        private GeometryModel3D _model;

		private TranslateTransform3D _translateTransform;

		private RotateTransform3D _rotationTransform;

		public TexturedBox3D(Model3DGroup visualEntitiesStore, double x, double y, double z, BitmapImage image, Size size, float axisX = 0, double angle = 0, float axisY = 0, float axisZ = 1)
		{
			this.Size = size;
			this.Position = new Vector3D(x, y, z);
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
			ImageBrush brush = new ImageBrush(image);
            Material material = new DiffuseMaterial(brush);
            _model = new GeometryModel3D(mesh, material);
            visualEntitiesStore.Children.Add(_model);
			_translateTransform = new TranslateTransform3D(x, y, z);
			_rotationTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(axisX, axisY, axisZ), angle), 0.5, 0.5, 0.5);
            Transform3DGroup tgroup = new Transform3DGroup();
			tgroup.Children.Add(_translateTransform);
			tgroup.Children.Add(_rotationTransform);
            _model.Transform = tgroup;
		}

        /// <summary>
		/// Повернуть объект
		/// </summary>
		/// <param name="axis"></param>
		/// <param name="angle"></param>
		/// <param name="centerX"></param>
		/// <param name="centerY"></param>
		/// <param name="centerZ"></param>
		public void Rotation(Vector3D axis, double angle, double centerX = 0.5, double centerY = 0.5, double centerZ = 0.5)
		{
			_rotationTransform.CenterX = _translateTransform.OffsetX;
			_rotationTransform.CenterY = _translateTransform.OffsetY;
			_rotationTransform.CenterZ = _translateTransform.OffsetZ;

			_rotationTransform.Rotation = new AxisAngleRotation3D(axis, angle);
		}

        /// <summary>
        /// Прозрачность визуальной сущности
        /// </summary>
        public double Opacity
        {
            get => ((DiffuseMaterial)_model.Material).Brush.Opacity;
            set => ((DiffuseMaterial)_model.Material).Brush.Opacity = value;
        }
	}
}
