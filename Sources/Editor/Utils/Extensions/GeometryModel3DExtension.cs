using System.Windows.Media.Media3D;

namespace HikerEditor.Utils.Extensions
{
    public static class GeometryModel3DExtension
    {
        public static void Move(this GeometryModel3D model, Vector3D position)
        {
            TranslateTransform3D translateTransform = new TranslateTransform3D();
            translateTransform.OffsetX = position.X;
            translateTransform.OffsetY = position.Y;
            translateTransform.OffsetZ = position.Z;

            model.Transform = translateTransform;
        }

        public static void Rotate(this GeometryModel3D model, Vector3D axis, double angle, double centerX = 0.5, double centerY = 0.5, double centerZ = 0.5)
        {
            RotateTransform3D rotationTransform = new RotateTransform3D();
            rotationTransform.CenterX = model.Transform.Value.OffsetX;
            rotationTransform.CenterY = model.Transform.Value.OffsetY;
            rotationTransform.CenterZ = model.Transform.Value.OffsetZ;
            rotationTransform.Rotation = new AxisAngleRotation3D(axis, angle);

            model.Transform = rotationTransform;
        }

    }
}
